using UnityEngine;
using System.Collections;

public class Bedroll : object_base {

	public override bool use ()
	{
	if (GameWorldController.instance.playerUW.playerInventory.ObjectInHand=="")
		{
			//Rules to implement for sleeping
			//Only sleep if there are no hostile monsters nearby.
			//If a normal sleep do a fade to black in the small cutscene window.
			//If hungry then it is an uneasy sleep.
			//There is a small chance of a monster spawning.
			//If a dream/vision use the full screen.
			//Do a incense dream before a garamon dream. Turn the incense into ashes afterwards
			//Do one Garamon dream per game day.
			//When tybal is dead. Jump to the bury the bones dream
			//Restore an amount of health or mana after a sleep.
			//Track the state of the garamon/cup of wonder dreams in Quest.

			/*
			  000~001~014~There are hostile creatures near!
			  000~001~015~You make camp.
			  000~001~016~You go to sleep.
			  000~001~017~You are starving.
			  000~001~018~You feel rested.
			  000~001~019~Your sleep is uneasy.
			  000~001~020~You can't go to sleep here!
			  000~001~021~Your sleep is interrupted!
			*/

			if (!CheckForMonsters())
			    {
				ObjectInteraction incense =GameWorldController.instance.playerUW.playerInventory.findObjInteractionByID(277); 
				if (incense!=null)
					{
					UWHUD.instance.EnableDisableControl(UWHUD.instance.CutsceneFullPanel.gameObject,true);
					//UWHUD.instance.CutScenesFull.SetAnimationFile="FadeToBlackSleep";
					incense.consumeObject ();
					switch (GameWorldController.instance.playerUW.quest().getIncenseDream())
						{
						case 0:
							UWHUD.instance.CutScenesFull.SetAnimationFile="cs013_n01";break;
						case 1:
							UWHUD.instance.CutScenesFull.SetAnimationFile="cs014_n01";break;
						case 2:
							UWHUD.instance.CutScenesFull.SetAnimationFile="cs015_n01";break;
						}
					}
				else
					{	
					if (GameWorldController.instance.playerUW.FoodLevel>=3)					
						{
							if (IsGaramonTime())
							{//PLay a garamon dream
								PlayGaramonDream(GameWorldController.instance.playerUW.quest().GaramonDream++);								
							}
							else
							{//Regular sleep with a fade to black
								StartCoroutine(SleepDelay());
								//UWHUD.instance.EnableDisableControl(UWHUD.instance.CutsceneFullPanel.gameObject,true);
								//UWHUD.instance.CutScenesFull.SetAnimationFile="FadeToBlackSleep";
							}	
						}					
					}
				for (int i=GameWorldController.instance.playerUW.Fatigue; i<29;i=i+3)//Sleep restores at a rate of 3 points per hour
					{
					if (GameWorldController.instance.playerUW.FoodLevel>=3)
						{
						GameClock.Advance();//Move time forward.
						}
					else
						{//Too hungry to sleep.
						UWHUD.instance.MessageScroll.Add(StringController.instance.GetString (1,17));
						UWHUD.instance.EnableDisableControl(UWHUD.instance.CutsceneFullPanel,false);		
						GameWorldController.instance.playerUW.Fatigue+=i;
						return true;
						}
					}
				GameWorldController.instance.playerUW.Fatigue=29;//Fully rested
				if (GameWorldController.instance.playerUW.CurVIT<GameWorldController.instance.playerUW.MaxVIT)
					{//Random regen of an amount of health
					GameWorldController.instance.playerUW.CurVIT += Random.Range (1, GameWorldController.instance.playerUW.MaxVIT-GameWorldController.instance.playerUW.CurVIT+1);
					}
				if (GameWorldController.instance.playerUW.PlayerMagic.CurMana<GameWorldController.instance.playerUW.PlayerMagic.MaxMana)
					{//Random regen of an amount of mana
					GameWorldController.instance.playerUW.PlayerMagic.CurMana += Random.Range (1, GameWorldController.instance.playerUW.PlayerMagic.MaxMana-GameWorldController.instance.playerUW.PlayerMagic.CurMana+1);
					}
				}
			else
			{
				UWHUD.instance.MessageScroll.Add(StringController.instance.GetString (1,14));
			}	
			return true;
		}
		else
		{
		return ActivateByObject(GameWorldController.instance.playerUW.playerInventory.GetGameObjectInHand());
		}
	}

	private bool CheckForMonsters()
	{//Finds monsters in the area.
		return false;
	}

	private bool IsGaramonTime()
	{//Is it time for a garamon dream
		//if (GameWorldController.instance.playerUW.quest().isTybalDead)
		//{
			if (GameWorldController.instance.playerUW.quest().GaramonDream==6)
			{
				return true;//All done.
			}
					if (GameWorldController.instance.playerUW.quest().GaramonDream==7)
					{
						return true;//Tybal is dead. Time to play a dream.
					}	
		//}
		//else
		//{
		//	if (GameWorldController.instance.playerUW.quest().GaramonDream>7)
		//	{
		//		return false;//All done until tybal is dead.
		//	}	
		//}

		if (GameClock.day()>=GameWorldController.instance.playerUW.quest().DayGaramonDream)
		{
			return true;
		}
		else
		{
			return false;
		}		
	}

	void PlayGaramonDream(int dreamIndex)
	{
		int DaysToWait=0;
		switch (dreamIndex)
		{
			case 0:
				Cutscene_Dream_1 d1 = UWHUD.instance.gameObject.AddComponent<Cutscene_Dream_1>();
				UWHUD.instance.CutScenesFull.cs=d1;
				UWHUD.instance.CutScenesFull.Begin();
				DaysToWait=1;
				break;
			case 1:
				Cutscene_Dream_2 d2 = UWHUD.instance.gameObject.AddComponent<Cutscene_Dream_2>();
				UWHUD.instance.CutScenesFull.cs=d2;
				UWHUD.instance.CutScenesFull.Begin();
				DaysToWait=1;
				break;
			case 2:
				Cutscene_Dream_3 d3 = UWHUD.instance.gameObject.AddComponent<Cutscene_Dream_3>();
				UWHUD.instance.CutScenesFull.cs=d3;
				UWHUD.instance.CutScenesFull.Begin();
				DaysToWait=1;
				break;
			case 3:
				Cutscene_Dream_4 d4 = UWHUD.instance.gameObject.AddComponent<Cutscene_Dream_4>();
				UWHUD.instance.CutScenesFull.cs=d4;
				UWHUD.instance.CutScenesFull.Begin();
				DaysToWait=1;
				break;
			case 4:
				Cutscene_Dream_5 d5 = UWHUD.instance.gameObject.AddComponent<Cutscene_Dream_5>();
				UWHUD.instance.CutScenesFull.cs=d5;
				UWHUD.instance.CutScenesFull.Begin();
				DaysToWait=1;
				break;
			case 5:
				Cutscene_Dream_6 d6 = UWHUD.instance.gameObject.AddComponent<Cutscene_Dream_6>();
				UWHUD.instance.CutScenesFull.cs=d6;
				UWHUD.instance.CutScenesFull.Begin();
				DaysToWait=1;
				break;
			case 6:
				Cutscene_Dream_7 d7 = UWHUD.instance.gameObject.AddComponent<Cutscene_Dream_7>();
				UWHUD.instance.CutScenesFull.cs=d7;
				UWHUD.instance.CutScenesFull.Begin();
				DaysToWait=1;
				break;
			case 7: // Tybal is dead.
				Cutscene_Dream_7 d8 = UWHUD.instance.gameObject.AddComponent<Cutscene_Dream_7>();
				UWHUD.instance.CutScenesFull.cs=d8;
				UWHUD.instance.CutScenesFull.Begin();
				GameWorldController.instance.playerUW.quest().GaramonDream=3;//Move back in the sequence
				DaysToWait=1;
				break;
			case 8:
				Cutscene_Dream_9 d9 = UWHUD.instance.gameObject.AddComponent<Cutscene_Dream_9>();
				UWHUD.instance.CutScenesFull.cs=d9;
				UWHUD.instance.CutScenesFull.Begin();
				DaysToWait=1;
				break;
			case 9:
				Cutscene_Dream_10 d10 = UWHUD.instance.gameObject.AddComponent<Cutscene_Dream_10>();
				UWHUD.instance.CutScenesFull.cs=d10;
				UWHUD.instance.CutScenesFull.Begin();
				DaysToWait=1;
				break;		
			}

		GameWorldController.instance.playerUW.quest().DayGaramonDream=GameClock.day()+DaysToWait;
	}

	static void RestoreHealthMana(UWCharacter sunshine)
	{
		sunshine.CurVIT += Random.Range(1,40);
		if (sunshine.CurVIT>sunshine.MaxVIT)
		{
			sunshine.CurVIT=sunshine.MaxVIT;
		}

		sunshine.PlayerMagic.CurMana += Random.Range(1,40);
		if (sunshine.PlayerMagic.CurMana>sunshine.PlayerMagic.MaxMana)
		{
			sunshine.PlayerMagic.CurMana=sunshine.PlayerMagic.MaxMana;
		}
	}

	public static void WakeUp(UWCharacter sunshine)
	{//Todo: Test the quality of the sleep and check for monster interuption.
		RestoreHealthMana(sunshine);
		UWHUD.instance.MessageScroll.Add(StringController.instance.GetString (1,18));
	}


	public override string UseVerb ()
	{
		return "sleep";
	}


		IEnumerator SleepDelay()
		{
			UWHUD.instance.EnableDisableControl(UWHUD.instance.CutsceneFullPanel.gameObject,true);
			UWHUD.instance.CutScenesFull.SetAnimationFile="FadeToBlackSleep";
			yield return new WaitForSeconds(3f);
			UWHUD.instance.CutScenesFull.SetAnimationFile="Anim_Base";
			UWHUD.instance.EnableDisableControl(UWHUD.instance.CutsceneFullPanel.gameObject,false);
		}

}
