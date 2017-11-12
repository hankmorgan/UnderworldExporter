using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Shrine : object_base {

	public const string Mantra_FAL  ="FAL"; //Acrobat 
	public const string Mantra_HUNN  ="HUNN"; //Appraise 
	public const string Mantra_RA  ="RA"; //Attack 
	public const string Mantra_SUMM_RA  ="SUMM RA"; //Attack skills 
	public const string Mantra_GAR  ="GAR"; //Axe 
	public const string Mantra_SOL  ="SOL"; //Casting 
	public const string Mantra_UN  ="UN"; //Charm 
	public const string Mantra_ANRA  ="ANRA"; //Defense 
	public const string Mantra_LAHN  ="LAHN"; //Lore 
	public const string Mantra_KOH  ="KOH"; //Mace 
	public const string Mantra_IMU  ="IMU"; //Mana 
	public const string Mantra_MU_AHM  ="MU AHM"; //Magic skills 
	public const string Mantra_OM_CAH  ="OM CAH"; //Other skills 
	public const string Mantra_AAM  ="AAM"; //Picklock 
	public const string Mantra_FAHM  ="FAHM"; //Missile 
	public const string Mantra_LON  ="LON"; //Repair 
	public const string Mantra_LU  ="LU"; //Search 
	public const string Mantra_MUL  ="MUL"; //Sneak 
	public const string Mantra_ONO  ="ONO"; //Swimming 
	public const string Mantra_AMO  ="AMO"; //Sword 
	public const string Mantra_SAHF  ="SAHF"; //Track 
	public const string Mantra_ROMM  ="ROMM"; //Traps 
	public const string Mantra_ORA  = "ORA"; //Unarmed 
	public const string Mantra_INSAHN  = "INSAHN"; //Cup of Wonder 
	public const string Mantra_FANLO  = "FANLO"; //Key of Truth 
	public static bool HasGivenKey;

	private int[] AttackSkills=
	{
		Skills.SkillAttack,
		Skills.SkillDefense,
		Skills.SkillSword,
		Skills.SkillMace,
		Skills.SkillAxe,
		Skills.SkillUnarmed,
		Skills.SkillMissile
	};

	private int[] MagicSkills=
	{
		Skills.SkillMana,
		Skills.SkillCasting,
		Skills.SkillLore
	};

	private int[] OtherSkills=
	{//TODO:Check these!
		Skills.SkillRepair,
		Skills.SkillAppraise,
		Skills.SkillTrack,
		Skills.SkillAcrobat,
		Skills.SkillPicklock
	};

	private bool WaitingForInput=false;
	private InputField inputctrl;

	public override bool use ()
	{
		if (UWCharacter.Instance.playerInventory.ObjectInHand=="")
		{
			if (WaitingForInput==false)
			{
				WaitingForInput=true;
				if (inputctrl==null)
				{
					inputctrl =UWHUD.instance.InputControl;//UWHUD.instance.MessageScroll.gameObject.GetComponent<UIInput>();
				}
				UWHUD.instance.MessageScroll.Set("Chant the mantra");
				inputctrl.gameObject.SetActive(true);
				inputctrl.gameObject.GetComponent<InputHandler>().target=this.gameObject;
				inputctrl.gameObject.GetComponent<InputHandler>().currentInputMode=InputHandler.InputMantraWords;
				inputctrl.contentType= InputField.ContentType.Standard;
				inputctrl.Select();
				Time.timeScale=0.0f;
				WindowDetect.WaitingForInput=true;
			}
			return true;
		}
		else
		{
			return ActivateByObject(UWCharacter.Instance.playerInventory.GetGameObjectInHand());			
		}
	}

	public void OnSubmitPickup(string Mantra)
	{
		SubmitMantra (Mantra);
		WaitingForInput=false;
		Time.timeScale=1.0f;
		inputctrl.text="";
		WindowDetectUW.WaitingForInput=false;
		inputctrl.gameObject.SetActive(false);
	}

		/// <summary>
		/// Submits the mantra and checks if it is valid
		/// </summary>
		/// <param name="Mantra">Mantra.</param>
	private void SubmitMantra(string Mantra)
	{

				if((Mantra.ToUpper()==Mantra_FANLO))
				{
					GiveKeyOfTruth();
					return;
				}
				if((Mantra.ToUpper()==Mantra_INSAHN) )
				{
					TrackCupOfWonder();
					return;
				}

		int SkillPointsToAdd=Random.Range(1,4) ;
		Skills playerSkills= UWCharacter.Instance.PlayerSkills;
		if (UWCharacter.Instance.TrainingPoints==0)
		{
			//000~001~024~You are not ready to advance. \n
			UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1,StringController.str_you_are_not_ready_to_advance_));						
			return;
		}
		string answer="";
		switch (Mantra.ToUpper())
		{
		case Mantra_FAL ://Acrobat 
			playerSkills.AdvanceSkill(Skills.SkillAcrobat,SkillPointsToAdd+ Skills.getSkillAttributeBonus(Skills.SkillAcrobat));
			answer="Acrobat";break;	
		case Mantra_HUNN ://Appraise 
			playerSkills.AdvanceSkill(Skills.SkillAppraise,SkillPointsToAdd+ Skills.getSkillAttributeBonus(Skills.SkillAppraise));
			answer="Appraise";break;
		case Mantra_RA ://Attack 
			playerSkills.AdvanceSkill(Skills.SkillAttack,SkillPointsToAdd+ Skills.getSkillAttributeBonus(Skills.SkillAttack));
			answer="Attack";break;
		case Mantra_SUMM_RA ://Attack skills 
			for (int i =0; i<SkillPointsToAdd;i++)
			{
				int SkillAwarded = AttackSkills[Random.Range(0,AttackSkills.GetUpperBound (0)+1)];
				playerSkills.AdvanceSkill(SkillAwarded,1+ Skills.getSkillAttributeBonus(SkillAwarded));
				if (answer.Length>0)
				{
					answer += " and ";
				}
				answer += playerSkills.GetSkillName (SkillAwarded);
			}
			break;
		case Mantra_GAR ://Axe 
			playerSkills.AdvanceSkill(Skills.SkillAxe,SkillPointsToAdd+ Skills.getSkillAttributeBonus(Skills.SkillAxe));
			answer="Axe";break;
		case Mantra_SOL ://Casting 
			playerSkills.AdvanceSkill(Skills.SkillCasting,SkillPointsToAdd+ Skills.getSkillAttributeBonus(Skills.SkillCasting) );
			answer="Casting";break;
		case Mantra_UN ://Charm 
			playerSkills.AdvanceSkill(Skills.SkillCharm,SkillPointsToAdd + Skills.getSkillAttributeBonus(Skills.SkillCharm) );
			answer="Charm";break;
		case Mantra_ANRA ://Defense
			playerSkills.AdvanceSkill(Skills.SkillDefense,SkillPointsToAdd + Skills.getSkillAttributeBonus(Skills.SkillDefense)  );
			answer="Anra";break;
		case Mantra_LAHN ://Lore 
			playerSkills.AdvanceSkill(Skills.SkillLore,SkillPointsToAdd + Skills.getSkillAttributeBonus(Skills.SkillLore));
			answer="Lore";break;
		case Mantra_KOH ://Mace 
			playerSkills.AdvanceSkill(Skills.SkillMace,SkillPointsToAdd+ Skills.getSkillAttributeBonus(Skills.SkillMace));
			answer="Mace";break;
		case Mantra_IMU ://Mana 
			playerSkills.AdvanceSkill(Skills.SkillMana,SkillPointsToAdd+ Skills.getSkillAttributeBonus(Skills.SkillMana));
			answer="Mana";break;
		case Mantra_MU_AHM ://Magic skills 
			for (int i =0; i<SkillPointsToAdd;i++)
			{
				int SkillAwarded = MagicSkills[Random.Range(0,MagicSkills.GetUpperBound (0)+1)];
				playerSkills.AdvanceSkill(SkillAwarded,1+ Skills.getSkillAttributeBonus(SkillAwarded));
				if (answer.Length>0)
				{
					answer += " and ";
				}
				answer += playerSkills.GetSkillName (SkillAwarded);
			}
			break;
		case Mantra_OM_CAH ://Other skills 
			for (int i =0; i<SkillPointsToAdd;i++)
			{
				int SkillAwarded = OtherSkills[Random.Range(0,OtherSkills.GetUpperBound (0)+1)];
				playerSkills.AdvanceSkill(SkillAwarded,1 + Skills.getSkillAttributeBonus(SkillAwarded) );
				if (answer.Length>0)
				{
					answer += " and ";
				}
				answer += playerSkills.GetSkillName (SkillAwarded);
			}
			break;
		case Mantra_AAM ://Picklock 
			playerSkills.AdvanceSkill(Skills.SkillPicklock,SkillPointsToAdd+ Skills.getSkillAttributeBonus(Skills.SkillPicklock));
			answer="Picklock";break;
		case Mantra_FAHM ://Missile 
			playerSkills.AdvanceSkill(Skills.SkillMissile,SkillPointsToAdd+ Skills.getSkillAttributeBonus(Skills.SkillMissile));
			answer="Missile";break;
		case Mantra_LON ://Repair 
			playerSkills.AdvanceSkill(Skills.SkillRepair,SkillPointsToAdd+ Skills.getSkillAttributeBonus(Skills.SkillRepair));
			answer="Repair";break;
		case Mantra_LU ://Search 
			playerSkills.AdvanceSkill(Skills.SkillSearch,SkillPointsToAdd+ Skills.getSkillAttributeBonus(Skills.SkillSearch));
			answer="Search";break;
		case Mantra_MUL ://Sneak 
			playerSkills.AdvanceSkill(Skills.SkillSneak,SkillPointsToAdd+ Skills.getSkillAttributeBonus(Skills.SkillSneak));
			answer="Sneak";break;
		case Mantra_ONO ://Swimming 
			playerSkills.AdvanceSkill(Skills.SkillSwimming,SkillPointsToAdd+ Skills.getSkillAttributeBonus(Skills.SkillSwimming));
			answer="Swimming";break;
		case Mantra_AMO ://Sword 
			playerSkills.AdvanceSkill(Skills.SkillAcrobat,SkillPointsToAdd+ Skills.getSkillAttributeBonus(Skills.SkillSword));
			answer="Sword";break;
		case Mantra_SAHF ://Track 
			playerSkills.AdvanceSkill(Skills.SkillTrack,SkillPointsToAdd+ Skills.getSkillAttributeBonus(Skills.SkillTrack));
			answer="Track";break;
		case Mantra_ROMM ://Traps 
			playerSkills.AdvanceSkill(Skills.SkillTraps,SkillPointsToAdd+ Skills.getSkillAttributeBonus(Skills.SkillTraps));
			answer="Traps";break;
		case Mantra_ORA ://Unarmed 
			playerSkills.AdvanceSkill(Skills.SkillAcrobat,SkillPointsToAdd+ Skills.getSkillAttributeBonus(Skills.SkillUnarmed));
			answer="Unarmed";break;
		case Mantra_INSAHN ://Cup of Wonder 
			TrackCupOfWonder();
			return;
		case Mantra_FANLO ://Key of Truth 
			GiveKeyOfTruth ();
			return;
		}
		if (answer!="")
		{
			UWHUD.instance.MessageScroll.Add( "You have advanced in " + answer);
			UWCharacter.Instance.TrainingPoints-=1;
		}
		else
		{
			UWHUD.instance.MessageScroll.Add("That is not a mantra");
		}
	}

	public void GiveKeyOfTruth()
	{
		if (HasGivenKey==false)
		{
			//Code to spawn key of truth in player hand
			//Debug.Log ("You get the key of truth");
			UWHUD.instance.MessageScroll.Add(StringController.instance.GetString (1,StringController.str_none_of_your_skills_improved_));//No skills appear
			//inputctrl.text=UWHUD.instance.MessageScroll.text;
			Shrine.HasGivenKey=true;
			//create the key of truth.
			ObjectLoaderInfo newobjt= ObjectLoader.newObject(225,0,0,0,256);
			GameObject key = ObjectInteraction.CreateNewObject(GameWorldController.instance.currentTileMap(),newobjt, GameWorldController.instance.InventoryMarker.gameObject, GameWorldController.instance.InventoryMarker.transform.position).gameObject;
			GameWorldController.MoveToInventory(key);
			ObjectInteraction myObjInt = key.GetComponent<ObjectInteraction>();


			/*ObjectInteraction myObjInt = ObjectInteraction.CreateNewObject(225);
			myObjInt.gameObject.transform.parent=GameWorldController.instance.InventoryMarker.transform;
			GameWorldController.MoveToInventory(myObjInt.gameObject);*/
			UWCharacter.Instance.playerInventory.ObjectInHand=myObjInt.name;
			UWHUD.instance.CursorIcon=myObjInt.GetInventoryDisplay().texture ;
			UWCharacter.InteractionMode=UWCharacter.InteractionModePickup;
			InteractionModeControl.UpdateNow=true;
		}
	}

	public void TrackCupOfWonder()
	{//TODO:Find out what happens when I have the cup of wonder.
				//Cup is in tile 26,43 on level 2 (zero based)
				string CupIs= StringController.instance.GetString(1,35);
				string locLevel = "";
				string locHeading=""; 
				int TileX= TileMap.visitTileX;
				int TileY= TileMap.visitTileY;

				float angle = (float)Mathf.Atan2(TileY-43, TileX-26);
				angle=Mathf.Rad2Deg*angle;
				int headingIndex = facing(angle);
				/*
				000~001~036~to the North
				000~001~037~to the Northeast
				000~001~038~to the East
				000~001~039~to the Southeast
				000~001~040~to the South
				000~001~041~to the Southwest
				000~001~042~to the West
				000~001~043~to the Northwest
				*/
				switch (headingIndex)
				{
				case 0://The the west
						locHeading= StringController.instance.GetString(1,42);break;	
				case 1://To the south west
						locHeading= StringController.instance.GetString(1,41);break;	
				case 2://To the south
						locHeading= StringController.instance.GetString(1,40);break;	
				case 3://To the south east
						locHeading= StringController.instance.GetString(1,39);break;	
				case 4://To the east
						locHeading= StringController.instance.GetString(1,38);break;	
				case 5://To the north east
						locHeading= StringController.instance.GetString(1,37);break;	
				case 6://To the north
						locHeading= StringController.instance.GetString(1,36);break;	
				case 7://To the northwest
				default:
						locHeading= StringController.instance.GetString(1,43);break;	
				}
				switch(GameWorldController.instance.LevelNo)
				{
				case 0:
					locLevel = "and " +StringController.instance.GetString(1,47);break;
				case 1: 
					locLevel = "and " +StringController.instance.GetString(1,48);break;
				case 2:
					locLevel = "";break;
				case 3: 
					locLevel = "and " +StringController.instance.GetString(1,52);break;
				default:
					locLevel = "and " +StringController.instance.GetString(1,55);break;
				}

				/*
000~001~035~The Cup of Wonder is 
000~001~044~far far below you
000~001~045~far far below you
000~001~046~far below you
000~001~047~far below you
000~001~048~below you
000~001~049~below you
000~001~050~underneath you
000~001~052~above you
000~001~053~above you
000~001~054~above you
000~001~055~far above you
000~001~056~far above you
000~001~057~far far above you
000~001~058~far far above you

				*/
		UWHUD.instance.MessageScroll.Add (CupIs + locHeading + locLevel);
		//inputctrl.text=UWHUD.instance.MessageScroll.text;
	}

	public override bool TalkTo ()
	{
		return use ();
	}

	public override string UseVerb ()
	{
		return "meditate";	
	}


		int facing(float angle)
		{//Copied from NPC 
				if ((angle >= -22.5) && (angle <= 22.5)) 
				{
						return 0;//*AnimRange;//Facing forward
				} 
				else 
				{
						if ((angle>22.5)&&(angle<=67.5))
						{//Facing forward left
								return 1;//*AnimRange;
						}
						else
						{
								if ((angle >67.5)&&(angle<=112.5))
								{//facing (right)
										return 2;//*AnimRange;
								}
								else
								{
										if ((angle >112.5)&&(angle<=157.5))
										{//Facing away left
												return 3;//*AnimRange;
										}
										else
										{
												if (((angle >157.5)&&(angle<=180.0)) || ((angle>=-180)&&(angle<=-157.5)))
												{//Facing away
														return 4;//*AnimRange;
												}
												else
												{
														if ((angle >=-157.5)&&(angle<-112.5))
														{//Facing away right
																return 5;//*AnimRange;
														}
														else
														{
																if ((angle >-112.5)&&(angle<-67.5))
																{//Facing (left)
																		return 6;//*AnimRange;
																}
																else
																{
																		if ((angle >-67.5)&&(angle<-22.5))
																		{//Facing forward right
																				return 7;//*AnimRange;
																		}
																		else
																		{
																				return 0;//*AnimRange;//default
																		}
																}
														}
												}
										}
								}
						}
				}
		}



}

