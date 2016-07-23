using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UWHUD : HUD {
//Class for referencing other hud elements without having to search for them all the time.

		public const int HUD_MODE_INVENTORY =0;
		public const int HUD_MODE_STATS =1;
		public const int HUD_MODE_RUNES =2;
		public const int HUD_MODE_CONV =3;
		public const int HUD_MODE_MAP =4;
		public const int HUD_MODE_CUTS_SMALL =5;
		public const int HUD_MODE_CUTS_FULL =6;


	public static UWHUD instance;
	public MainMenuHud mainmenu;
	public CutsceneAnimation CutScenesSmall;

	public HealthFlask HealthFlask;
	public HealthFlask ManaFlask;
	public Compass compass;
	public Dragons[] dragons;// new Dragons[2];
	public Eyes eyes;
	public StatsDisplay stats;
	public TradeSlot[] playerTrade ;//= new TradeSlot[4];
	public TradeSlot[] npcTrade ;//= new TradeSlot[4];
	public RawImage[] ConversationPortraits;
	public Text Encumberance;

	public Text LevelNoDisplay;//Tile map level No

	public chains ChainsControl;

	//Conversation Controls
	public ScrollController Conversation_tl;//Text output.


	public WindowDetectUW window;


	public GameObject ContainerOpened;

		//UW Cursors
		public Texture2D  MapQuill;
		public Texture2D  MapQuillWriting;
		public Texture2D  MapEraser;

		public ActiveRuneSlot[] activeRunes;

		public RuneSlot[] runes;


	//Panels
		public GameObject RuneBagPanel;
		public GameObject StatsDisplayPanel;
		public GameObject MapPanel;
		public GameObject InventoryPanel;
		public GameObject PaperDollFemalePanel;
		public GameObject ConversationPanel;
		public GameObject DragonLeftPanel;
		public GameObject DragonRightPanel;
		public GameObject CutsceneSmallPanel;
		public GameObject CutsceneFullPanel;




		void Awake()
		{
			instance=this;
		}


		public void RefreshPanels(int ActivePanelMode)
		{
				bool InventoryEnabled=false;
				bool RuneBagEnabled=false;
				bool StatsEnabled=false;
				bool ConversationEnabled=false;
				bool CutSceneSmallEnabled=false;
				bool CutSceneFullEnabled=false;
				bool MapEnabled=true;

				switch (ActivePanelMode)
				{
				case 0://Inventory
						InventoryEnabled=true;
						RuneBagEnabled=false;
						StatsEnabled=false;
						ConversationEnabled=false;
						CutSceneSmallEnabled=true;
						MapEnabled=false;
						break;
				case 1://Stats display
						InventoryEnabled=false;
						RuneBagEnabled=false;
						StatsEnabled=true;
						ConversationEnabled=false;
						CutSceneSmallEnabled=true;
						CutSceneFullEnabled=false;
						MapEnabled=false;
						break;	
				case 2://Runebag
						InventoryEnabled=false;
						RuneBagEnabled=true;
						StatsEnabled=false;
						ConversationEnabled=false;
						CutSceneSmallEnabled=true;
						CutSceneFullEnabled=false;
						MapEnabled=false;
						break;	
				case 3://Conversation
						InventoryEnabled=true;
						RuneBagEnabled=false;
						StatsEnabled=false;
						ConversationEnabled=true;
						CutSceneSmallEnabled=false;
						CutSceneFullEnabled=false;
						MapEnabled=false;
						break;	
				case 4://Map
						InventoryEnabled=false;
						RuneBagEnabled=false;
						StatsEnabled=false;
						ConversationEnabled=false;
						CutSceneSmallEnabled=false;
						CutSceneFullEnabled=false;
						MapEnabled=true;
						break;
				/*
				 * I don't need to switch controls when in cuts. Too error prone.
				 * 
				 * case 5: //Cutscene small;
						InventoryEnabled=false;
						RuneBagEnabled=false;
						StatsEnabled=false;
						ConversationEnabled=false;
						CutSceneSmallEnabled=true;
						CutSceneFullEnabled=true;
						MapEnabled=false;
						break;
				case 5: //Cutscene full;
						InventoryEnabled=false;
						RuneBagEnabled=false;
						StatsEnabled=false;
						ConversationEnabled=false;
						CutSceneSmallEnabled=true;
						CutSceneFullEnabled=true;
						MapEnabled=false;
						break;*/
				}

				EnableDisableControl (RuneBagPanel,RuneBagEnabled);
				if (RuneBagEnabled==true)
				{
						RuneSlot.UpdateRuneDisplay();
				}
				EnableDisableControl(StatsDisplayPanel,StatsEnabled);
				EnableDisableControl(InventoryPanel, InventoryEnabled);
				EnableDisableControl(PaperDollFemalePanel, InventoryEnabled && GameWorldController.instance.playerUW.isFemale);
				EnableDisableControl(ConversationPanel,ConversationEnabled);
				EnableDisableControl(MapPanel,MapEnabled);
				EnableDisableControl(DragonLeftPanel,(((InventoryEnabled) || (StatsEnabled) || (RuneBagEnabled) || (ConversationEnabled)) && (UWHUD.instance.window.FullScreen==false)));
				EnableDisableControl(DragonRightPanel,(((InventoryEnabled) || (StatsEnabled) || (RuneBagEnabled) || (ConversationEnabled)) && (UWHUD.instance.window.FullScreen==false)));
				EnableDisableControl(CutsceneSmallPanel,CutSceneSmallEnabled);
				EnableDisableControl(CutsceneFullPanel,CutSceneFullEnabled);


		}



		public void EnableDisableControl(GameObject control, bool targetState)
		{
				control.SetActive(targetState);
		}

}


