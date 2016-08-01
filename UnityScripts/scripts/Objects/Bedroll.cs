using UnityEngine;
using System.Collections;

public class Bedroll : object_base {

	public override bool use ()
	{
		if (playerUW.playerInventory.ObjectInHand=="")
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
				ObjectInteraction incense =playerUW.playerInventory.findObjInteractionByID(277); 
				if (incense!=null)
					{
					UWHUD.instance.CutScenesFull.SetAnimation="FadeToBlackSleep";
					incense.consumeObject ();
					switch (playerUW.quest().getIncenseDream())
						{
						case 0:
						UWHUD.instance.CutScenesFull.SetAnimation="cs013_n01";break;
						case 1:
						UWHUD.instance.CutScenesFull.SetAnimation="cs014_n01";break;
						case 2:
						UWHUD.instance.CutScenesFull.SetAnimation="cs015_n01";break;
						}
					}
				else
					{	
						if (playerUW.FoodLevel>=3)					
						{
								if (IsGaramonTime())
								{//PLay a garamon dream
										UWHUD.instance.CutScenesFull.SetAnimation="FadeToBlackSleep";
										UWHUD.instance.CutScenesFull.SetAnimation="cs000_n04";
								}
								else
								{//Regular sleep with a fade to black
										UWHUD.instance.CutScenesFull.SetAnimation="FadeToBlackSleep";
								}	
						}
					
					}
				for (int i=playerUW.Fatigue; i<29;i=i+3)//Sleep restores at a rate of 3 points per hour
					{
					if (playerUW.FoodLevel>=3)
						{
						GameClock.Advance();//Move time forward.
						}
					else
						{//Too hungry to sleep.
						UWHUD.instance.MessageScroll.Add(StringController.instance.GetString (1,17));
						UWHUD.instance.EnableDisableControl(UWHUD.instance.CutsceneFullPanel,false);		
						playerUW.Fatigue+=i;
						return true;
						}
					}
				playerUW.Fatigue=29;//Fully rested
				if (playerUW.CurVIT<playerUW.MaxVIT)
					{//Random regen of an amount of health
					playerUW.CurVIT += Random.Range (1, playerUW.MaxVIT-playerUW.CurVIT+1);
					}
				if (playerUW.PlayerMagic.CurMana<playerUW.PlayerMagic.MaxMana)
				{//Random regen of an amount of mana
					playerUW.PlayerMagic.CurMana += Random.Range (1, playerUW.PlayerMagic.MaxMana-playerUW.PlayerMagic.CurMana+1);
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
			return ActivateByObject(playerUW.playerInventory.GetGameObjectInHand());
		}
	}

	private bool CheckForMonsters()
	{//Finds monsters in the area.
		return false;
	}

	private bool IsGaramonTime()
	{//Is it time for a garamon dream
		return false;
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


}
