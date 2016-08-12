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
		if (GameWorldController.instance.playerUW.playerInventory.ObjectInHand=="")
		{
			if (WaitingForInput==false)
			{
				WaitingForInput=true;
				if (inputctrl==null)
				{
					inputctrl =UWHUD.instance.InputControl;//UWHUD.instance.MessageScroll.gameObject.GetComponent<UIInput>();
				}
				UWHUD.instance.MessageScroll.Set("Chant the mantra");
				//inputctrl.text=UWHUD.instance.MessageScroll.text;
				//TODO:Fix me inputctrl.eventReceiver=this.gameObject;
								//inputctrl.onEndEdit.RemoveAllListeners();
								//inputctrl.onEndEdit.AddListener(delegate {
								//		this.OnSubmitPickup();	
								//} );
								//inputctrl.inputType=InputField.InputType.Standard;
								inputctrl.gameObject.SetActive(true);
								inputctrl.gameObject.GetComponent<InputHandler>().target=this.gameObject;
								inputctrl.gameObject.GetComponent<InputHandler>().currentInputMode=InputHandler.InputMantraWords;


								inputctrl.contentType= InputField.ContentType.Alphanumeric;
								//TODO:Fix me inputctrl.selected=true;
								inputctrl.Select();
								//TODO:Fix me inputctrl.useLabelTextAtStart=true;
				//Debug.Log ("Input ctrl type is" + inputctrl.type);
								//TODO:Fix me inputctrl.type=UIInput.KeyboardType.Default;
				Time.timeScale=0.0f;
				WindowDetect.WaitingForInput=true;
			}
			return true;
		}
		else
		{
			return ActivateByObject(GameWorldController.instance.playerUW.playerInventory.GetGameObjectInHand());			
		}
	}

	public void OnSubmitPickup(string Mantra)
	{//TODO: set this name of the event receiver whereever it is called so that this can make more sense.
		/*if (inputctrl==null)
		{
			inputctrl =UWHUD.instance.InputControl;//UWHUD.instance.MessageScroll.gameObject.GetComponent<UIInput>();
		}*/
		SubmitMantra (Mantra);
		WaitingForInput=false;
		Time.timeScale=1.0f;
		inputctrl.text="";
		WindowDetectUW.WaitingForInput=false;
		inputctrl.gameObject.SetActive(false);
		//Debug.Log ("Value summited");

	}


	private void SubmitMantra(string Mantra)
	{
		bool hasPoints=true;
		int SkillPointsToAdd=2;
		Skills playerSkills= GameWorldController.instance.playerUW.PlayerSkills;
		////if (inputctrl==null)
		//{
		//	inputctrl =UWHUD.instance.InputControl;//UWHUD.instance.MessageScroll.gameObject.GetComponent<UIInput>();
		//}
		if (GameWorldController.instance.playerUW.TrainingPoints==0)
		{
			hasPoints=false;
			return;
		}
		string answer="";
		switch (Mantra.ToUpper())
		{
		case Mantra_FAL ://Acrobat 
			playerSkills.AdvanceSkill(Skills.SkillAcrobat,SkillPointsToAdd);
			answer="Acrobat";break;	
		case Mantra_HUNN ://Appraise 
			playerSkills.AdvanceSkill(Skills.SkillAppraise,SkillPointsToAdd);
			answer="Appraise";break;
		case Mantra_RA ://Attack 
			playerSkills.AdvanceSkill(Skills.SkillAttack,SkillPointsToAdd);
			answer="Attack";break;
		case Mantra_SUMM_RA ://Attack skills 
			for (int i =0; i<SkillPointsToAdd;i++)
			{
				int SkillAwarded = AttackSkills[Random.Range(0,AttackSkills.GetUpperBound (0)+1)];
				playerSkills.AdvanceSkill(SkillAwarded,1);
				if (answer.Length>0)
				{
					answer += " and ";
				}
				answer += playerSkills.GetSkillName (SkillAwarded);
			}
			break;
		case Mantra_GAR ://Axe 
			playerSkills.AdvanceSkill(Skills.SkillAxe,SkillPointsToAdd);
			answer="Axe";break;
		case Mantra_SOL ://Casting 
			playerSkills.AdvanceSkill(Skills.SkillCasting,SkillPointsToAdd);
			answer="Casting";break;
		case Mantra_UN ://Charm 
			playerSkills.AdvanceSkill(Skills.SkillCharm,SkillPointsToAdd);
			answer="Charm";break;
		case Mantra_ANRA ://Defense
			playerSkills.AdvanceSkill(Skills.SkillDefense,SkillPointsToAdd);
			answer="Anra";break;
		case Mantra_LAHN ://Lore 
			playerSkills.AdvanceSkill(Skills.SkillLore,SkillPointsToAdd);
			answer="Lore";break;
		case Mantra_KOH ://Mace 
			playerSkills.AdvanceSkill(Skills.SkillMace,SkillPointsToAdd);
			answer="Mace";break;
		case Mantra_IMU ://Mana 
			playerSkills.AdvanceSkill(Skills.SkillMana,SkillPointsToAdd);
			answer="Mana";break;
		case Mantra_MU_AHM ://Magic skills 
			for (int i =0; i<SkillPointsToAdd;i++)
			{
				int SkillAwarded = MagicSkills[Random.Range(0,MagicSkills.GetUpperBound (0)+1)];
				playerSkills.AdvanceSkill(SkillAwarded,1);
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
				playerSkills.AdvanceSkill(SkillAwarded,1);
				if (answer.Length>0)
				{
					answer += " and ";
				}
				answer += playerSkills.GetSkillName (SkillAwarded);
			}
			break;
		case Mantra_AAM ://Picklock 
			playerSkills.AdvanceSkill(Skills.SkillPicklock,SkillPointsToAdd);
			answer="Picklock";break;
		case Mantra_FAHM ://Missile 
			playerSkills.AdvanceSkill(Skills.SkillMissile,SkillPointsToAdd);
			answer="Missile";break;
		case Mantra_LON ://Repair 
			playerSkills.AdvanceSkill(Skills.SkillRepair,SkillPointsToAdd);
			answer="Repair";break;
		case Mantra_LU ://Search 
			playerSkills.AdvanceSkill(Skills.SkillSearch,SkillPointsToAdd);
			answer="Search";break;
		case Mantra_MUL ://Sneak 
			playerSkills.AdvanceSkill(Skills.SkillSneak,SkillPointsToAdd);
			answer="Sneak";break;
		case Mantra_ONO ://Swimming 
			playerSkills.AdvanceSkill(Skills.SkillSwimming,SkillPointsToAdd);
			answer="Swimming";break;
		case Mantra_AMO ://Sword 
			playerSkills.AdvanceSkill(Skills.SkillAcrobat,SkillPointsToAdd);
			answer="Sword";break;
		case Mantra_SAHF ://Track 
			playerSkills.AdvanceSkill(Skills.SkillTrack,SkillPointsToAdd);
			answer="Track";break;
		case Mantra_ROMM ://Traps 
			playerSkills.AdvanceSkill(Skills.SkillTraps,SkillPointsToAdd);
			answer="Traps";break;
		case Mantra_ORA ://Unarmed 
			playerSkills.AdvanceSkill(Skills.SkillAcrobat,SkillPointsToAdd);
			answer="Unarmed";break;
		case Mantra_INSAHN ://Cup of Wonder 
			TrackCupOfWonder();
			answer="CupofWonder";break;
		case Mantra_FANLO ://Key of Truth 
			GiveKeyOfTruth ();
			answer="KeyofTruth";break;
		}
	
	if (answer!="")
		{
			if (hasPoints)
			{
				UWHUD.instance.MessageScroll.Add( "You have advanced in " + answer);
				GameWorldController.instance.playerUW.TrainingPoints-=1;
			}
			else
			{
				//000~001~024~You are not ready to advance. \n
				UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1,24));
			}
		}
		else
		{
			//Debug.Log ("not a mantra");
			UWHUD.instance.MessageScroll.Add("That is not a mantra");
		}
	}

	public void GiveKeyOfTruth()
	{
		if (HasGivenKey==false)
		{
			//Code to spawn key of truth in player hand
			//Debug.Log ("You get the key of truth");
			UWHUD.instance.MessageScroll.Add(StringController.instance.GetString (1,30));//No skills appear
			//inputctrl.text=UWHUD.instance.MessageScroll.text;
			Shrine.HasGivenKey=true;
			//create the key of truth.
			ObjectInteraction myObjInt = ObjectInteraction.CreateNewObject(225);
			myObjInt.gameObject.transform.parent=GameWorldController.instance.InventoryMarker.transform;
			UWHUD.instance.CursorIcon=myObjInt.GetInventoryDisplay().texture ;
			UWCharacter.InteractionMode=UWCharacter.InteractionModePickup;
			InteractionModeControl.UpdateNow=true;



		}
	}

	public void TrackCupOfWonder()
	{//TODO:Find out what happens when I have the cup of wonder.
		UWHUD.instance.MessageScroll.Add ("The cup of wonder is somewhere...");
		//inputctrl.text=UWHUD.instance.MessageScroll.text;
	}

	public override bool TalkTo ()
	{
		return use ();
	}
}

