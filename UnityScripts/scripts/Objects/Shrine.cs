using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;

public class Shrine : Model3D {

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


		/**********************Model Definition***************************/

	public override Vector3[] ModelVertices ()
	{
		Vector3[] ModelVerts = new Vector3[80];
		ModelVerts[0] = new Vector3(-0.09765625f,0.125f,-0.0390625f);
		ModelVerts[1] = new Vector3(-0.1289063f,0.09375f,0.0703125f);
		ModelVerts[2] = new Vector3(-0.1601563f,0f,0.1015625f);
		ModelVerts[3] = new Vector3(-0.09765625f,0.125f,0.0390625f);
		ModelVerts[4] = new Vector3(-0.1992188f,0.4921875f,-0.0390625f);
		ModelVerts[5] = new Vector3(-0.1992188f,0.4921875f,0.0390625f);
		ModelVerts[6] = new Vector3(-0.1992188f,0.640625f,0.0390625f);
		ModelVerts[7] = new Vector3(-0.1992188f,0.640625f,-0.0390625f);
		ModelVerts[8] = new Vector3(-0.0625f,0.625f,0.0390625f);
		ModelVerts[9] = new Vector3(-0.0625f,0.625f,-0.0390625f);
		ModelVerts[10] = new Vector3(0.0625f,0.625f,-0.0390625f);
		ModelVerts[11] = new Vector3(0.0625f,0.625f,0.0390625f);
		ModelVerts[12] = new Vector3(0.1992188f,0.640625f,0.0390625f);
		ModelVerts[13] = new Vector3(0.1992188f,0.640625f,-0.0390625f);
		ModelVerts[14] = new Vector3(0.1992188f,0.4921875f,0.0390625f);
		ModelVerts[15] = new Vector3(0.1992188f,0.4921875f,-0.0390625f);
		ModelVerts[16] = new Vector3(0.09765625f,0.125f,-0.0390625f);
		ModelVerts[17] = new Vector3(0.04296875f,0.5273438f,-0.0390625f);
		ModelVerts[18] = new Vector3(0.04296875f,0.5273438f,0.0390625f);
		ModelVerts[19] = new Vector3(0.09765625f,0.125f,0.0390625f);
		ModelVerts[20] = new Vector3(0.09375f,0.7109375f,-0.0390625f);
		ModelVerts[21] = new Vector3(0.09375f,0.7109375f,0.0390625f);
		ModelVerts[22] = new Vector3(0.09765625f,0.7460938f,-0.0390625f);
		ModelVerts[23] = new Vector3(0.09765625f,0.7460938f,0.0390625f);
		ModelVerts[24] = new Vector3(0.09765625f,0.78125f,-0.0390625f);
		ModelVerts[25] = new Vector3(0.09765625f,0.78125f,0.0390625f);
		ModelVerts[26] = new Vector3(0.078125f,0.8242188f,-0.0390625f);
		ModelVerts[27] = new Vector3(0.078125f,0.8242188f,0.0390625f);
		ModelVerts[28] = new Vector3(0.04296875f,0.8476563f,0.0390625f);
		ModelVerts[29] = new Vector3(0.04296875f,0.8476563f,-0.0390625f);
		ModelVerts[30] = new Vector3(0f,0.8632813f,-0.0390625f);
		ModelVerts[31] = new Vector3(0f,0.8632813f,0.0390625f);
		ModelVerts[32] = new Vector3(0f,0.6679688f,-0.0390625f);
		ModelVerts[33] = new Vector3(0f,0.6679688f,0.0390625f);
		ModelVerts[34] = new Vector3(0.0234375f,0.703125f,0.0390625f);
		ModelVerts[35] = new Vector3(0.0234375f,0.703125f,-0.0390625f);
		ModelVerts[36] = new Vector3(0.03515625f,0.734375f,0.0390625f);
		ModelVerts[37] = new Vector3(0.03515625f,0.734375f,-0.0390625f);
		ModelVerts[38] = new Vector3(0.03515625f,0.7617188f,0.0390625f);
		ModelVerts[39] = new Vector3(0.03515625f,0.7617188f,-0.0390625f);
		ModelVerts[40] = new Vector3(0.02734375f,0.7773438f,0.0390625f);
		ModelVerts[41] = new Vector3(0.02734375f,0.7773438f,-0.0390625f);
		ModelVerts[42] = new Vector3(0.015625f,0.7851563f,0.0390625f);
		ModelVerts[43] = new Vector3(0.015625f,0.7851563f,-0.0390625f);
		ModelVerts[44] = new Vector3(0f,0.7890625f,0.0390625f);
		ModelVerts[45] = new Vector3(0f,0.7890625f,-0.0390625f);
		ModelVerts[46] = new Vector3(-0.03125f,0.7773438f,-0.0390625f);
		ModelVerts[47] = new Vector3(-0.03125f,0.7773438f,0.0390625f);
		ModelVerts[48] = new Vector3(-0.015625f,0.7851563f,0.0390625f);
		ModelVerts[49] = new Vector3(-0.015625f,0.7851563f,-0.0390625f);
		ModelVerts[50] = new Vector3(-0.03515625f,0.7617188f,-0.0390625f);
		ModelVerts[51] = new Vector3(-0.03515625f,0.7617188f,0.0390625f);
		ModelVerts[52] = new Vector3(-0.03515625f,0.734375f,-0.0390625f);
		ModelVerts[53] = new Vector3(-0.03515625f,0.734375f,0.0390625f);
		ModelVerts[54] = new Vector3(-0.0234375f,0.703125f,-0.0390625f);
		ModelVerts[55] = new Vector3(-0.0234375f,0.703125f,0.0390625f);
		ModelVerts[56] = new Vector3(-0.08203125f,0.8242188f,-0.0390625f);
		ModelVerts[57] = new Vector3(-0.08203125f,0.8242188f,0.0390625f);
		ModelVerts[58] = new Vector3(-0.04296875f,0.8476563f,0.0390625f);
		ModelVerts[59] = new Vector3(-0.04296875f,0.8476563f,-0.0390625f);
		ModelVerts[60] = new Vector3(-0.09765625f,0.78125f,-0.0390625f);
		ModelVerts[61] = new Vector3(-0.09765625f,0.78125f,0.0390625f);
		ModelVerts[62] = new Vector3(-0.09765625f,0.7460938f,-0.0390625f);
		ModelVerts[63] = new Vector3(-0.09765625f,0.7460938f,0.0390625f);
		ModelVerts[64] = new Vector3(-0.09375f,0.7109375f,-0.0390625f);
		ModelVerts[65] = new Vector3(-0.09375f,0.7109375f,0.0390625f);
		ModelVerts[66] = new Vector3(0.1289063f,0.09375f,0.0703125f);
		ModelVerts[67] = new Vector3(-0.1289063f,0.09375f,-0.0703125f);
		ModelVerts[68] = new Vector3(0.1289063f,0.09375f,-0.0703125f);
		ModelVerts[69] = new Vector3(0.1601563f,0f,0.1015625f);
		ModelVerts[70] = new Vector3(-0.1601563f,0f,-0.1015625f);
		ModelVerts[71] = new Vector3(0.1601563f,0f,-0.1015625f);
		ModelVerts[72] = new Vector3(-0.04296875f,0.5273438f,0.0390625f);
		ModelVerts[73] = new Vector3(-0.04296875f,0.5273438f,-0.0390625f);
		ModelVerts[74] = new Vector3(0.1992188f,0.59375f,-0.0390625f);
		ModelVerts[75] = new Vector3(0.1992188f,0.59375f,0.0390625f);
		ModelVerts[76] = new Vector3(-0.0859375f,0.203125f,-0.0390625f);
		ModelVerts[77] = new Vector3(0.0859375f,0.203125f,-0.0390625f);
		ModelVerts[78] = new Vector3(-0.1015625f,0.09375f,-0.0703125f);
		ModelVerts[79] = new Vector3(0.1015625f,0.09375f,-0.0703125f);

		return ModelVerts;
	}


	public override int[] ModelTriangles (int meshNo)
	{
		Debug.Log("reverse this array permanently");
		//For some reason this mesh triangle list needs reversing!!!!
		return new int[]{44,31,28,44,58,31,42,28,27,40,27,25,38,25,23,36,23,21,34,21,11,48,57,58,47,61,57,51,63,61,53,65,63,55,8,65,8,55,33,8,33,11,11,33,34,65,53,55,53,63,51,51,51,51,51,61,47,47,57,48,48,58,44,44,28,42,42,27,40,40,25,38,38,23,36,36,21,34,8,5,6,8,72,5,11,12,14,11,14,18,72,8,18,18,8,11,3,72,18,19,3,18,1,3,19,66,1,19,69,2,1,69,1,66,45,30,59,49,59,56,46,56,60,50,60,62,52,62,64,54,64,9,45,29,30,43,24,26,39,22,24,37,20,22,35,10,20,9,10,32,9,7,4,9,4,73,10,15,13,10,17,15,9,73,10,10,73,17,17,73,76,17,76,77,76,0,77,77,0,16,0,67,16,16,67,68,67,70,68,68,70,71,32,10,35,35,20,37,37,22,39,39,24,43,43,29,45,45,59,49,46,49,56,50,46,60,52,50,62,54,52,64,32,54,9,2,70,1,70,67,1,67,0,1,1,0,3,3,0,73,3,73,72,72,73,4,72,4,5,5,4,6,6,4,7,8,6,7,8,7,9,65,8,9,65,9,64,63,65,64,63,64,62,61,63,62,61,62,60,57,61,60,57,60,56,58,57,56,58,56,59,31,58,59,31,59,30,28,31,30,28,30,29,27,28,29,27,29,26,25,27,26,25,26,24,23,25,24,23,24,22,21,23,22,21,22,20,11,21,20,11,20,10,12,11,10,12,10,13,14,12,13,14,13,15,18,14,15,18,15,17,19,18,17,19,17,16,66,19,16,66,16,68,69,66,68,69,68,71,2,69,71,2,71,70,45,44,42,43,42,40,41,40,38,39,38,36,37,36,34,35,34,33,32,33,55,54,55,53,52,53,51,50,51,47,46,47,48,49,48,44,42,43,45,40,41,43,38,39,41,36,37,39,34,35,37,33,32,35,55,54,32,53,52,54,51,50,52,47,46,50,48,49,46,44,45,49,26,29,43}.Reverse().ToArray();
	}
}

