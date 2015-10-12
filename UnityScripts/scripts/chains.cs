using UnityEngine;
using System.Collections;

public class chains : MonoBehaviour {
	public static int ActiveControl;
	public static int setControl=-1;
	// Use this for initialization
	void Start () {
	
	}

	void OnClick()
	{
	 switch (ActiveControl)
		{
		case 0://Inventory -> Stats
			ActiveControl=1;
			break;
		case 1://Stats -> Inventory
			ActiveControl=0;
			break;
		case 2://Magic -> Inventory
			ActiveControl=0;
			break;
		}
	}

	// Update is called once per frame
	void Update () {
		if (setControl!=ActiveControl)
		{
			Refresh();
		}
	}

	static GameObject EnableDisableControl(string ControlName, bool targetState)
	{
		GameObject ControlParent= GameObject.Find ("UI_MAIN_PANEL");
		//Debug.Log (ControlParent.name);
		foreach(Transform child in ControlParent.transform)
		{
			if (child.name.ToUpper() == ControlName.ToUpper())
			{
				child.gameObject.SetActive(targetState);
				return child.gameObject;
			}
		}
		Debug.Log ("MODE " + setControl+ "Unable to find " + ControlName);
		return null;
	}


	public static void Refresh()
	{
//		Debug.Log ("Refresh");
		setControl=ActiveControl;
		switch (ActiveControl)
		{
		case 0:	//Main inventory
			//Turn off rune bag
			EnableDisableControl("RuneBagDisplay",false);
			EnableDisableControl ("RuneSlot00",false);
			EnableDisableControl ("RuneSlot01",false);
			EnableDisableControl ("RuneSlot02",false);
			EnableDisableControl ("RuneSlot03",false);
			EnableDisableControl ("RuneSlot04",false);
			EnableDisableControl ("RuneSlot05",false);
			EnableDisableControl ("RuneSlot06",false);
			EnableDisableControl ("RuneSlot07",false);
			EnableDisableControl ("RuneSlot08",false);
			EnableDisableControl ("RuneSlot09",false);
			EnableDisableControl ("RuneSlot10",false);
			EnableDisableControl ("RuneSlot11",false);
			EnableDisableControl ("RuneSlot12",false);
			EnableDisableControl ("RuneSlot13",false);
			EnableDisableControl ("RuneSlot14",false);
			EnableDisableControl ("RuneSlot15",false);
			EnableDisableControl ("RuneSlot16",false);
			EnableDisableControl ("RuneSlot17",false);
			EnableDisableControl ("RuneSlot18",false);
			EnableDisableControl ("RuneSlot19",false);
			EnableDisableControl ("RuneSlot20",false);
			EnableDisableControl ("RuneSlot21",false);
			EnableDisableControl ("RuneSlot22",false);
			EnableDisableControl ("RuneSlot23",false);
			EnableDisableControl ("ClearRunes",false);
			//Turn off Stats
			EnableDisableControl("StatsDisplay",false);
			EnableDisableControl("StatsCharname",false);
			EnableDisableControl("StatsCharClass",false);
			EnableDisableControl("StatsCharClassLevel",false);
			EnableDisableControl("StatsCharSTR",false);
			EnableDisableControl("StatsCharDEX",false);
			EnableDisableControl("StatsCharINT",false);
			EnableDisableControl("StatsCharVIT",false);
			EnableDisableControl("StatsCharMana",false);
			EnableDisableControl("StatsCharEXP",false);
			EnableDisableControl("StatsCharSkillNames",false);
			EnableDisableControl("StatsCharSkillValues",false);
			EnableDisableControl("StatsDisplayUp",false);
			EnableDisableControl("StatsDisplayDown",false);
			
			
			//Turn on inventory
			EnableDisableControl("Backpack_Slot_00",true);
			EnableDisableControl("Backpack_Slot_01",true);
			EnableDisableControl("Backpack_Slot_02",true);
			EnableDisableControl("Backpack_Slot_03",true);
			EnableDisableControl("Backpack_Slot_04",true);
			EnableDisableControl("Backpack_Slot_05",true);
			EnableDisableControl("Backpack_Slot_06",true);
			EnableDisableControl("Backpack_Slot_07",true);
			EnableDisableControl("LeftShoulder_Slot",true);
			EnableDisableControl("RightShoulder_Slot",true);
			EnableDisableControl("LeftHand_Slot",true);
			EnableDisableControl("RightHand_Slot",true);
			EnableDisableControl("LeftRing_Slot",true);
			EnableDisableControl("RightRing_Slot",true);
			EnableDisableControl("Helm_f_Slot",true);
			EnableDisableControl("Chest_f_Slot",true);
			EnableDisableControl("Legs_f_Slot",true);
			EnableDisableControl("Boots_f_Slot",true);
			EnableDisableControl("Gloves_f_Slot",true);
			EnableDisableControl("ContainerOpened",true);
			
			//Turn off conversation
			EnableDisableControl("Conversation_Portrait_Frame_Left",false);
			EnableDisableControl("Conversation_Portrait_Left",false);
			EnableDisableControl("Conversation_Trade_Left",false);
			EnableDisableControl("Conversation_Portrait_Frame_Right",false);
			EnableDisableControl("Conversation_Portrait_Right",false);
			EnableDisableControl("Conversation_Trade_Right",false);
			EnableDisableControl("Conversation_Scroll",false);
			EnableDisableControl("Conversation_Name_Left",false);
			EnableDisableControl("Conversation_Name_Right",false);
			EnableDisableControl("Conversation_BG",false);
			EnableDisableControl("Conversation_Scroll_Lower",false);
			EnableDisableControl("Conversation_Scroll_Upper",false);
			EnableDisableControl("Conversation_Scroll_Edge_Left",false);
			EnableDisableControl("Conversation_Scroll_Edge_Right",false);
			EnableDisableControl("Conversation_Alpha",false);
			
			break;
		case 1://Stats Display
			//Turn on Stats
			EnableDisableControl("StatsDisplay",true);
			EnableDisableControl("StatsCharname",true);
			EnableDisableControl("StatsCharClass",true);
			EnableDisableControl("StatsCharClassLevel",true);
			EnableDisableControl("StatsCharSTR",true);
			EnableDisableControl("StatsCharDEX",true);
			EnableDisableControl("StatsCharINT",true);
			EnableDisableControl("StatsCharVIT",true);
			EnableDisableControl("StatsCharMana",true);
			EnableDisableControl("StatsCharEXP",true);
			EnableDisableControl("StatsCharSkillNames",true);
			EnableDisableControl("StatsCharSkillValues",true);
			EnableDisableControl("StatsDisplayUp",true);
			EnableDisableControl("StatsDisplayDown",true);
			
			//Turn off rune bag (just in case)
			EnableDisableControl("RuneBagDisplay",false);
			EnableDisableControl ("RuneSlot00",false);
			EnableDisableControl ("RuneSlot01",false);
			EnableDisableControl ("RuneSlot02",false);
			EnableDisableControl ("RuneSlot03",false);
			EnableDisableControl ("RuneSlot04",false);
			EnableDisableControl ("RuneSlot05",false);
			EnableDisableControl ("RuneSlot06",false);
			EnableDisableControl ("RuneSlot07",false);
			EnableDisableControl ("RuneSlot08",false);
			EnableDisableControl ("RuneSlot09",false);
			EnableDisableControl ("RuneSlot10",false);
			EnableDisableControl ("RuneSlot11",false);
			EnableDisableControl ("RuneSlot12",false);
			EnableDisableControl ("RuneSlot13",false);
			EnableDisableControl ("RuneSlot14",false);
			EnableDisableControl ("RuneSlot15",false);
			EnableDisableControl ("RuneSlot16",false);
			EnableDisableControl ("RuneSlot17",false);
			EnableDisableControl ("RuneSlot18",false);
			EnableDisableControl ("RuneSlot19",false);
			EnableDisableControl ("RuneSlot20",false);
			EnableDisableControl ("RuneSlot21",false);
			EnableDisableControl ("RuneSlot22",false);
			EnableDisableControl ("RuneSlot23",false);
			EnableDisableControl ("ClearRunes",false);
			
			//Turn off inventory
			EnableDisableControl("Backpack_Slot_00",false);
			EnableDisableControl("Backpack_Slot_01",false);
			EnableDisableControl("Backpack_Slot_02",false);
			EnableDisableControl("Backpack_Slot_03",false);
			EnableDisableControl("Backpack_Slot_04",false);
			EnableDisableControl("Backpack_Slot_05",false);
			EnableDisableControl("Backpack_Slot_06",false);
			EnableDisableControl("Backpack_Slot_07",false);
			EnableDisableControl("LeftShoulder_Slot",false);
			EnableDisableControl("RightShoulder_Slot",false);
			EnableDisableControl("LeftHand_Slot",false);
			EnableDisableControl("RightHand_Slot",false);
			EnableDisableControl("LeftRing_Slot",false);
			EnableDisableControl("RightRing_Slot",false);
			EnableDisableControl("Helm_f_Slot",false);
			EnableDisableControl("chest_f_Slot",false);
			EnableDisableControl("legs_f_Slot",false);
			EnableDisableControl("boots_f_Slot",false);
			EnableDisableControl("gloves_f_Slot",false);
			EnableDisableControl("ContainerOpened",false);
			
			//Turn off conversation
			EnableDisableControl("Conversation_Portrait_Frame_Left",false);
			EnableDisableControl("Conversation_Portrait_Left",false);
			EnableDisableControl("Conversation_Trade_Left",false);
			EnableDisableControl("Conversation_Portrait_Frame_Right",false);
			EnableDisableControl("Conversation_Portrait_Right",false);
			EnableDisableControl("Conversation_Trade_Right",false);
			EnableDisableControl("Conversation_Scroll",false);
			EnableDisableControl("Conversation_Name_Left",false);
			EnableDisableControl("Conversation_Name_Right",false);
			EnableDisableControl("Conversation_BG",false);
			EnableDisableControl("Conversation_Scroll_Lower",false);
			EnableDisableControl("Conversation_Scroll_Upper",false);
			EnableDisableControl("Conversation_Scroll_Edge_Left",false);
			EnableDisableControl("Conversation_Scroll_Edge_Right",false);
			EnableDisableControl("Conversation_Alpha",false);			
			
			break;
		case 2:	//Rune bag
			//Turn on Runes
			EnableDisableControl("RuneBagDisplay",true);
			EnableDisableControl ("RuneSlot00",true);
			EnableDisableControl ("RuneSlot01",true);
			EnableDisableControl ("RuneSlot02",true);
			EnableDisableControl ("RuneSlot03",true);
			EnableDisableControl ("RuneSlot04",true);
			EnableDisableControl ("RuneSlot05",true);
			EnableDisableControl ("RuneSlot06",true);
			EnableDisableControl ("RuneSlot07",true);
			EnableDisableControl ("RuneSlot08",true);
			EnableDisableControl ("RuneSlot09",true);
			EnableDisableControl ("RuneSlot10",true);
			EnableDisableControl ("RuneSlot11",true);
			EnableDisableControl ("RuneSlot12",true);
			EnableDisableControl ("RuneSlot13",true);
			EnableDisableControl ("RuneSlot14",true);
			EnableDisableControl ("RuneSlot15",true);
			EnableDisableControl ("RuneSlot16",true);
			EnableDisableControl ("RuneSlot17",true);
			EnableDisableControl ("RuneSlot18",true);
			EnableDisableControl ("RuneSlot19",true);
			EnableDisableControl ("RuneSlot20",true);
			EnableDisableControl ("RuneSlot21",true);
			EnableDisableControl ("RuneSlot22",true);
			EnableDisableControl ("RuneSlot23",true);
			EnableDisableControl ("ClearRunes",true);
			//Turn off Stats
			EnableDisableControl("StatsDisplay",false);
			EnableDisableControl("StatsCharname",false);
			EnableDisableControl("StatsCharClass",false);
			EnableDisableControl("StatsCharClassLevel",false);
			EnableDisableControl("StatsCharSTR",false);
			EnableDisableControl("StatsCharDEX",false);
			EnableDisableControl("StatsCharINT",false);
			EnableDisableControl("StatsCharVIT",false);
			EnableDisableControl("StatsCharMana",false);
			EnableDisableControl("StatsCharEXP",false);
			EnableDisableControl("StatsCharSkillNames",false);
			EnableDisableControl("StatsCharSkillValues",false);
			EnableDisableControl("StatsDisplayUp",false);
			EnableDisableControl("StatsDisplayDown",false);
			
			//Turn off inventory
			EnableDisableControl("Backpack_Slot_00",false);
			EnableDisableControl("Backpack_Slot_01",false);
			EnableDisableControl("Backpack_Slot_02",false);
			EnableDisableControl("Backpack_Slot_03",false);
			EnableDisableControl("Backpack_Slot_04",false);
			EnableDisableControl("Backpack_Slot_05",false);
			EnableDisableControl("Backpack_Slot_06",false);
			EnableDisableControl("Backpack_Slot_07",false);
			EnableDisableControl("LeftShoulder_Slot",false);
			EnableDisableControl("RightShoulder_Slot",false);
			EnableDisableControl("LeftHand_Slot",false);
			EnableDisableControl("RightHand_Slot",false);
			EnableDisableControl("LeftRing_Slot",false);
			EnableDisableControl("RightRing_Slot",false);
			EnableDisableControl("Helm_f_Slot",false);
			EnableDisableControl("Chest_f_Slot",false);
			EnableDisableControl("Legs_f_Slot",false);
			EnableDisableControl("Boots_f_Slot",false);
			EnableDisableControl("Gloves_f_Slot",false);
			EnableDisableControl("ContainerOpened",false);
			
			//Turn off conversation
			EnableDisableControl("Conversation_Portrait_Frame_Left",false);
			EnableDisableControl("Conversation_Portrait_Left",false);
			EnableDisableControl("Conversation_Trade_Left",false);
			EnableDisableControl("Conversation_Portrait_Frame_Right",false);
			EnableDisableControl("Conversation_Portrait_Right",false);
			EnableDisableControl("Conversation_Trade_Right",false);
			EnableDisableControl("Conversation_Scroll",false);
			EnableDisableControl("Conversation_Name_Left",false);
			EnableDisableControl("Conversation_Name_Right",false);
			EnableDisableControl("Conversation_BG",false);
			EnableDisableControl("Conversation_Scroll_Lower",false);
			EnableDisableControl("Conversation_Scroll_Upper",false);
			EnableDisableControl("Conversation_Scroll_Edge_Left",false);
			EnableDisableControl("Conversation_Scroll_Edge_Right",false);
			EnableDisableControl("Conversation_Alpha",false);
			break;
			
		case 3://Conversation.
			EnableDisableControl("RuneBagDisplay",false);
			EnableDisableControl ("RuneSlot00",false);
			EnableDisableControl ("RuneSlot01",false);
			EnableDisableControl ("RuneSlot02",false);
			EnableDisableControl ("RuneSlot03",false);
			EnableDisableControl ("RuneSlot04",false);
			EnableDisableControl ("RuneSlot05",false);
			EnableDisableControl ("RuneSlot06",false);
			EnableDisableControl ("RuneSlot07",false);
			EnableDisableControl ("RuneSlot08",false);
			EnableDisableControl ("RuneSlot09",false);
			EnableDisableControl ("RuneSlot10",false);
			EnableDisableControl ("RuneSlot11",false);
			EnableDisableControl ("RuneSlot12",false);
			EnableDisableControl ("RuneSlot13",false);
			EnableDisableControl ("RuneSlot14",false);
			EnableDisableControl ("RuneSlot15",false);
			EnableDisableControl ("RuneSlot16",false);
			EnableDisableControl ("RuneSlot17",false);
			EnableDisableControl ("RuneSlot18",false);
			EnableDisableControl ("RuneSlot19",false);
			EnableDisableControl ("RuneSlot20",false);
			EnableDisableControl ("RuneSlot21",false);
			EnableDisableControl ("RuneSlot22",false);
			EnableDisableControl ("RuneSlot23",false);
			EnableDisableControl ("ClearRunes",true);
			//Turn off Stats
			EnableDisableControl("StatsDisplay",false);
			EnableDisableControl("StatsCharname",false);
			EnableDisableControl("StatsCharClass",false);
			EnableDisableControl("StatsCharClassLevel",false);
			EnableDisableControl("StatsCharSTR",false);
			EnableDisableControl("StatsCharDEX",false);
			EnableDisableControl("StatsCharINT",false);
			EnableDisableControl("StatsCharVIT",false);
			EnableDisableControl("StatsCharMana",false);
			EnableDisableControl("StatsCharEXP",false);
			EnableDisableControl("StatsCharSkillNames",false);
			EnableDisableControl("StatsCharSkillValues",false);
			EnableDisableControl("StatsDisplayUp",false);
			EnableDisableControl("StatsDisplayDown",false);
			
			//Turn off inventory
			EnableDisableControl("Backpack_Slot_00",false);
			EnableDisableControl("Backpack_Slot_01",false);
			EnableDisableControl("Backpack_Slot_02",false);
			EnableDisableControl("Backpack_Slot_03",false);
			EnableDisableControl("Backpack_Slot_04",false);
			EnableDisableControl("Backpack_Slot_05",false);
			EnableDisableControl("Backpack_Slot_06",false);
			EnableDisableControl("Backpack_Slot_07",false);
			EnableDisableControl("LeftShoulder_Slot",false);
			EnableDisableControl("RightShoulder_Slot",false);
			EnableDisableControl("LeftHand_Slot",false);
			EnableDisableControl("RightHand_Slot",false);
			EnableDisableControl("LeftRing_Slot",false);
			EnableDisableControl("RightRing_Slot",false);
			EnableDisableControl("Helm_f_Slot",false);
			EnableDisableControl("Chest_f_Slot",false);
			EnableDisableControl("Legs_f_Slot",false);
			EnableDisableControl("Boots_f_Slot",false);
			EnableDisableControl("Gloves_f_Slot",false);
			EnableDisableControl("ContainerOpened",false);
			
			//Turn on conversation
			EnableDisableControl("Conversation_Portrait_Frame_Left",true);
			EnableDisableControl("Conversation_Portrait_Left",true);
			EnableDisableControl("Conversation_Trade_Left",true);
			EnableDisableControl("Conversation_Portrait_Frame_Right",true);
			EnableDisableControl("Conversation_Portrait_Right",true);
			EnableDisableControl("Conversation_Trade_Right",true);
			GameObject scroll = EnableDisableControl("Conversation_Scroll",true);
			if (scroll !=null)
			{
				UITextList tl = scroll.GetComponent<UITextList>();//TODO:Get rid of this!
				if (tl !=null)
				{
					tl.textLabel.lineHeight=340;//TODO:Get rid of this!
					tl.textLabel.lineWidth=420;
				}
			}
			
			EnableDisableControl("Conversation_Name_Left",true);
			EnableDisableControl("Conversation_Name_Right",true);
			EnableDisableControl("Conversation_BG",true);
			EnableDisableControl("Conversation_Scroll_Lower",true);
			EnableDisableControl("Conversation_Scroll_Upper",true);
			EnableDisableControl("Conversation_Scroll_Edge_Left",true);
			EnableDisableControl("Conversation_Scroll_Edge_Right",true);
			EnableDisableControl("Conversation_Alpha",true);
			
			break;
		}
	}
}
