using UnityEngine;
using System.Collections;

public class chains : GuiBase_Draggable {
	/*GUI Element for switching panel displays but also controls which other GUI elements are displayed.*/
	public static int ActiveControl;
	public static int setControl=-1;

	public void OnClick()
	{
	if (Dragging==true){return;}
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

	public static GameObject EnableDisableControl(string ControlName, bool targetState)
	{
		GameObject ControlParent= GameObject.Find ("_UI");
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
		bool InventoryEnabled=false;
		bool RuneBagEnabled=false;
		bool StatsEnabled=false;
		bool ConversationEnabled=false;
		bool CutSceneEnabled=false;
		bool MapEnabled=true;

		setControl=ActiveControl;
		switch (ActiveControl)
		{
			case 0://Inventory
				InventoryEnabled=true;
				RuneBagEnabled=false;
				StatsEnabled=false;
				ConversationEnabled=false;
				CutSceneEnabled=false;
				MapEnabled=false;
				break;
			case 1://Stats display
				InventoryEnabled=false;
				RuneBagEnabled=false;
				StatsEnabled=true;
				ConversationEnabled=false;
				CutSceneEnabled=false;
				MapEnabled=false;
				break;	
			case 2://Runebag
				InventoryEnabled=false;
				RuneBagEnabled=true;
				StatsEnabled=false;
				ConversationEnabled=false;
				CutSceneEnabled=false;
				MapEnabled=false;
				break;	
			case 3://Conversation
				InventoryEnabled=true;
				RuneBagEnabled=false;
				StatsEnabled=false;
				ConversationEnabled=true;
				CutSceneEnabled=false;
				MapEnabled=false;
				break;	
			case 4://Map
				InventoryEnabled=false;
				RuneBagEnabled=false;
				StatsEnabled=false;
				ConversationEnabled=false;
				CutSceneEnabled=false;
				MapEnabled=true;
				break;
			case 5: //Cutscene fullscreen;
				InventoryEnabled=false;
				RuneBagEnabled=false;
				StatsEnabled=false;
				ConversationEnabled=false;
				CutSceneEnabled=true;
				MapEnabled=false;
				break;
		}
		EnableDisableControl ("MagicRuneBag",RuneBagEnabled);

				/*
		EnableDisableControl ("RuneBagDisplay",RuneBagEnabled);
		EnableDisableControl ("RuneSlot00",RuneBagEnabled);
		EnableDisableControl ("RuneSlot01",RuneBagEnabled);
		EnableDisableControl ("RuneSlot02",RuneBagEnabled);
		EnableDisableControl ("RuneSlot03",RuneBagEnabled);
		EnableDisableControl ("RuneSlot04",RuneBagEnabled);
		EnableDisableControl ("RuneSlot05",RuneBagEnabled);
		EnableDisableControl ("RuneSlot06",RuneBagEnabled);
		EnableDisableControl ("RuneSlot07",RuneBagEnabled);
		EnableDisableControl ("RuneSlot08",RuneBagEnabled);
		EnableDisableControl ("RuneSlot09",RuneBagEnabled);
		EnableDisableControl ("RuneSlot10",RuneBagEnabled);
		EnableDisableControl ("RuneSlot11",RuneBagEnabled);
		EnableDisableControl ("RuneSlot12",RuneBagEnabled);
		EnableDisableControl ("RuneSlot13",RuneBagEnabled);
		EnableDisableControl ("RuneSlot14",RuneBagEnabled);
		EnableDisableControl ("RuneSlot15",RuneBagEnabled);
		EnableDisableControl ("RuneSlot16",RuneBagEnabled);
		EnableDisableControl ("RuneSlot17",RuneBagEnabled);
		EnableDisableControl ("RuneSlot18",RuneBagEnabled);
		EnableDisableControl ("RuneSlot19",RuneBagEnabled);
		EnableDisableControl ("RuneSlot20",RuneBagEnabled);
		EnableDisableControl ("RuneSlot21",RuneBagEnabled);
		EnableDisableControl ("RuneSlot22",RuneBagEnabled);
		EnableDisableControl ("RuneSlot23",RuneBagEnabled);
		EnableDisableControl ("ClearRunes",RuneBagEnabled);
		*/
		//Turn off Stats
		EnableDisableControl("Stats",StatsEnabled);
				/*
		EnableDisableControl("StatsDisplay",StatsEnabled);
		EnableDisableControl("StatsCharname",StatsEnabled);
		EnableDisableControl("StatsCharClass",StatsEnabled);
		EnableDisableControl("StatsCharClassLevel",StatsEnabled);
		EnableDisableControl("StatsCharSTR",StatsEnabled);
		EnableDisableControl("StatsCharDEX",StatsEnabled);
		EnableDisableControl("StatsCharINT",StatsEnabled);
		EnableDisableControl("StatsCharVIT",StatsEnabled);
		EnableDisableControl("StatsCharMana",StatsEnabled);
		EnableDisableControl("StatsCharEXP",StatsEnabled);
		EnableDisableControl("StatsCharSkillNames",StatsEnabled);
		EnableDisableControl("StatsCharSkillValues",StatsEnabled);
		EnableDisableControl("StatsDisplayUp",StatsEnabled);
		EnableDisableControl("StatsDisplayDown",StatsEnabled);
		*/
		
		EnableDisableControl("Inventory", InventoryEnabled);
		EnableDisableControl("PaperDollFemale", InventoryEnabled && GameWorldController.instance.playerUW.isFemale);
		//Turn on inventory
				/*
		EnableDisableControl("Backpack_Slot_00",InventoryEnabled);
		EnableDisableControl("Backpack_Slot_01",InventoryEnabled);
		EnableDisableControl("Backpack_Slot_02",InventoryEnabled);
		EnableDisableControl("Backpack_Slot_03",InventoryEnabled);
		EnableDisableControl("Backpack_Slot_04",InventoryEnabled);
		EnableDisableControl("Backpack_Slot_05",InventoryEnabled);
		EnableDisableControl("Backpack_Slot_06",InventoryEnabled);
		EnableDisableControl("Backpack_Slot_07",InventoryEnabled);
		EnableDisableControl("Backpack_Count_00",InventoryEnabled);
		EnableDisableControl("Backpack_Count_01",InventoryEnabled);
		EnableDisableControl("Backpack_Count_02",InventoryEnabled);
		EnableDisableControl("Backpack_Count_03",InventoryEnabled);
		EnableDisableControl("Backpack_Count_04",InventoryEnabled);
		EnableDisableControl("Backpack_Count_05",InventoryEnabled);
		EnableDisableControl("Backpack_Count_06",InventoryEnabled);
		EnableDisableControl("Backpack_Count_07",InventoryEnabled);
		EnableDisableControl("LeftShoulder_Slot",InventoryEnabled);
		EnableDisableControl("RightShoulder_Slot",InventoryEnabled);
		EnableDisableControl("LeftHand_Slot",InventoryEnabled);
		EnableDisableControl("RightHand_Slot",InventoryEnabled);
		EnableDisableControl("LeftShoulder_Count",InventoryEnabled);
		EnableDisableControl("RightShoulder_Count",InventoryEnabled);
		EnableDisableControl("LeftHand_Count",InventoryEnabled);
		EnableDisableControl("RightHand_Count",InventoryEnabled);
		EnableDisableControl("LeftRing_Slot",InventoryEnabled);
		EnableDisableControl("RightRing_Slot",InventoryEnabled);
		EnableDisableControl("Helm_f_Slot",InventoryEnabled && playerUW.isFemale);
		EnableDisableControl("Chest_f_Slot",InventoryEnabled && playerUW.isFemale);
		EnableDisableControl("Legs_f_Slot",InventoryEnabled && playerUW.isFemale);
		EnableDisableControl("Boots_f_Slot",InventoryEnabled && playerUW.isFemale);
		EnableDisableControl("Gloves_f_Slot",InventoryEnabled && playerUW.isFemale);
		EnableDisableControl("Helm_m_Slot",InventoryEnabled && !playerUW.isFemale);
		EnableDisableControl("Chest_m_Slot",InventoryEnabled && !playerUW.isFemale);
		EnableDisableControl("Legs_m_Slot",InventoryEnabled && !playerUW.isFemale);
		EnableDisableControl("Boots_m_Slot",InventoryEnabled && !playerUW.isFemale);
		EnableDisableControl("Gloves_m_Slot",InventoryEnabled && !playerUW.isFemale);

		EnableDisableControl("ContainerOpened",InventoryEnabled);
		EnableDisableControl("InventoryDown",InventoryEnabled);
		EnableDisableControl("InventoryUp",InventoryEnabled);
		EnableDisableControl("PlayerWeight",InventoryEnabled);
		*/
		
		//Turn off conversation
		EnableDisableControl("Conversation",ConversationEnabled);
				/*
		EnableDisableControl("Conversation_Portrait_Frame_Left",ConversationEnabled);
		EnableDisableControl("Conversation_Portrait_Left",ConversationEnabled);
		EnableDisableControl("Conversation_Trade_Left",ConversationEnabled);
		EnableDisableControl("Conversation_Portrait_Frame_Right",ConversationEnabled);
		EnableDisableControl("Conversation_Portrait_Right",ConversationEnabled);
		EnableDisableControl("Conversation_Trade_Right",ConversationEnabled);
		EnableDisableControl("Conversation_Scroll",ConversationEnabled);
		EnableDisableControl("Conversation_Name_Left",ConversationEnabled);
		EnableDisableControl("Conversation_Name_Right",ConversationEnabled);
		EnableDisableControl("Conversation_BG",ConversationEnabled);
		EnableDisableControl("Conversation_Scroll_Lower",ConversationEnabled);
		EnableDisableControl("Conversation_Scroll_Upper",ConversationEnabled);
		EnableDisableControl("Conversation_Scroll_Edge_Left",ConversationEnabled);
		EnableDisableControl("Conversation_Scroll_Edge_Right",ConversationEnabled);
		//EnableDisableControl("Conversation_Alpha",ConversationEnabled);
		EnableDisableControl("Trade_Player_Slot_0",ConversationEnabled);
		EnableDisableControl("Trade_Player_Slot_1",ConversationEnabled);
		EnableDisableControl("Trade_Player_Slot_2",ConversationEnabled);
		EnableDisableControl("Trade_Player_Slot_3",ConversationEnabled);
		EnableDisableControl("Trade_NPC_Slot_0",ConversationEnabled);
		EnableDisableControl("Trade_NPC_Slot_1",ConversationEnabled);
		EnableDisableControl("Trade_NPC_Slot_2",ConversationEnabled);
		EnableDisableControl("Trade_NPC_Slot_3",ConversationEnabled);
		EnableDisableControl("Trade_Player_indicator_0",ConversationEnabled);
		EnableDisableControl("Trade_Player_indicator_1",ConversationEnabled);
		EnableDisableControl("Trade_Player_indicator_2",ConversationEnabled);
		EnableDisableControl("Trade_Player_indicator_3",ConversationEnabled);
		EnableDisableControl("Trade_NPC_indicator_0",ConversationEnabled);
		EnableDisableControl("Trade_NPC_indicator_1",ConversationEnabled);
		EnableDisableControl("Trade_NPC_indicator_2",ConversationEnabled);
		EnableDisableControl("Trade_NPC_indicator_3",ConversationEnabled);
		EnableDisableControl("Trade_Player_Count_0",ConversationEnabled);
		EnableDisableControl("Trade_Player_Count_1",ConversationEnabled);
		EnableDisableControl("Trade_Player_Count_2",ConversationEnabled);
		EnableDisableControl("Trade_Player_Count_3",ConversationEnabled);
		EnableDisableControl("Trade_NPC_Count_0",ConversationEnabled);
		EnableDisableControl("Trade_NPC_Count_1",ConversationEnabled);
		EnableDisableControl("Trade_NPC_Count_2",ConversationEnabled);
		EnableDisableControl("Trade_NPC_Count_3",ConversationEnabled);
*/
		//Cutscene related
		//TODO: RESTORE ME! EnableDisableControl("scroll_cutscene",CutSceneEnabled);


		//TUrn on/off map
		EnableDisableControl("Map",MapEnabled);


		//Misc controls
		EnableDisableControl("DragonLeft",(((InventoryEnabled) || (StatsEnabled) || (RuneBagEnabled) || (ConversationEnabled)) && (GameWorldController.instance.playerUW.playerHud.window.FullScreen==false)));
		EnableDisableControl("DragonRight",(((InventoryEnabled) || (StatsEnabled) || (RuneBagEnabled) || (ConversationEnabled)) && (GameWorldController.instance.playerUW.playerHud.window.FullScreen==false)));

		//Cuts
		EnableDisableControl("CutsceneSmall",CutSceneEnabled);
		EnableDisableControl("CutsceneFull",CutSceneEnabled);
	}
}
