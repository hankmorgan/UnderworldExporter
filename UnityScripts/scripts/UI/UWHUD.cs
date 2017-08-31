using UnityEngine;
using System.Collections;
using UnityEngine.UI;


/// <summary>
/// Class for referencing other hud elements without having to search for them all the time.
/// </summary>
public class UWHUD : HUD {

	public const int HUD_MODE_INVENTORY =0;
	public const int HUD_MODE_STATS =1;
	public const int HUD_MODE_RUNES =2;
	public const int HUD_MODE_CONV =3;
	public const int HUD_MODE_MAP =4;
	public const int HUD_MODE_CUTS_SMALL =5;
	public const int HUD_MODE_CUTS_FULL =6;


	public static UWHUD instance;
	public GameObject gameUi;
	public GameObject gameSelectUi;
	public MainMenuHud mainmenu;
	public HudAnimation CutScenesSmall;

	public TradeSlot[] playerTrade ;//= new TradeSlot[4];
	public TradeSlot[] npcTrade ;//= new TradeSlot[4];
	public RawImage[] ConversationPortraits;
	public Text Encumberance;

	public RawImage playerBody;

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
		public GameObject PaperDollMalePanel;
		public GameObject ConversationPanel;
		public GameObject DragonLeftPanel;
		public GameObject DragonRightPanel;
		public GameObject CutsceneSmallPanel;
		public GameObject CutsceneFullPanel;

		public GameObject currentPanel;

		public GameObject editorPanel;


		//Panel states 
		bool InventoryEnabled=true;
		bool RuneBagEnabled=false;
		bool StatsEnabled=false;
		bool ConversationEnabled=false;
		bool CutSceneSmallEnabled=true;
		bool CutSceneFullEnabled=true;
		bool MapEnabled=false;

		//Hud animation related
		public bool isRotating;

		public Text PCName;
		public Text NPCName;


		//Player inventory slots
		//Links to the slots where the object will be displayed
		public RawImage Helm_f_Slot;
		public RawImage Chest_f_Slot;
		public RawImage Legs_f_Slot;
		public RawImage Boots_f_Slot;
		public RawImage Gloves_f_Slot;
		public RawImage Helm_m_Slot;
		public RawImage Chest_m_Slot;
		public RawImage Legs_m_Slot;
		public RawImage Boots_m_Slot;
		public RawImage Gloves_m_Slot;
		public RawImage LeftHand_Slot;
		public RawImage RightHand_Slot;
		public RawImage LeftRing_Slot;
		public RawImage RightRing_Slot;
		public RawImage LeftShoulder_Slot;
		public RawImage RightShoulder_Slot;
		public RawImage[] BackPack_Slot=new RawImage[8];

		public Text LeftHand_Qty;
		public Text RightHand_Qty;
		public Text LeftShoulder_Qty;
		public Text RightShoulder_Qty;
		public Text[] Backpack_Slot_Qty= new Text[8];

		//Hud elements for run time loading
		public RawImage mapBackground;
		public RawImage mainwindow_art;

		public RawImage npcTradeArea;
		public RawImage pcTradeArea;
		public RawImage ConvNPCPortraitBG;
		public RawImage ConvPCPortraitBG;
		public RawImage ConvPCTitleBG;
		public RawImage ConvNPCTitleBG;
		public RawImage ConvTextScrollTop;
		public RawImage ConvTextScrollBottom;

		//public RawImage inventoryUpArrow;
		//public RawImage inventoryDownArrow;

		public RawImage FlaskHealth;
		public RawImage FlaskMana;

		public Text ContextMenu;

		public Text editorButtonLabel;
		public IngameEditor editor;

		public InteractionModeControl InteractionControl;

		void Awake()
		{
			instance=this;
		}


		public void Begin()
		{
				gameUi.SetActive(true);
				gameSelectUi.SetActive(false);

				//Init the art work for the hud
				//Init hud elements
				mapBackground.texture=GameWorldController.instance.bytloader.LoadImageAt(BytLoader.BLNKMAP_BYT);
				//mainwindow_art.texture=GameWorldController.instance.bytloader.LoadImageAt(BytLoader.MAIN_BYT);

				CursorIcon=GameWorldController.instance.grCursors.LoadImageAt(0);
				CursorIconDefault= GameWorldController.instance.grCursors.LoadImageAt(0);
				CursorIconTarget=GameWorldController.instance.grCursors.LoadImageAt(9);
				MapQuill=GameWorldController.instance.grCursors.LoadImageAt(14);
				MapQuillWriting=GameWorldController.instance.grCursors.LoadImageAt(12);
				MapEraser=GameWorldController.instance.grCursors.LoadImageAt(13);
				//inventoryDownArrow.texture=GameWorldController.instance.grCursors.LoadImageAt(2);
				//inventoryUpArrow.texture=GameWorldController.instance.grCursors.LoadImageAt(1);



				MapPanel.transform.SetAsLastSibling();
				ConversationPanel.transform.SetAsLastSibling();
		}
		//void Start()
		//{
			//RefreshPanels(-1);
		//}

		/// <summary>
		/// Refreshs the panels depending on the active mode
		/// </summary>
		/// <param name="ActivePanelMode">Active panel mode.</param>
		public void RefreshPanels(int ActivePanelMode)
		{
				
					switch (ActivePanelMode)
						{
						case -1:
								UpdatePanelStates();
								break;
						case HUD_MODE_INVENTORY://Inventory
								InventoryEnabled=true;
								RuneBagEnabled=false;
								StatsEnabled=false;
								ConversationEnabled=false;
								CutSceneSmallEnabled=true;
								CutSceneFullEnabled=false;
								MapEnabled=false;
								if (chains.ActiveControl>2)
								{
										chains.ActiveControl = ActivePanelMode;
										UpdatePanelStates();
								}
								else
								{
										StartCoroutine(RotatePanels(currentPanel,InventoryPanel));
										chains.ActiveControl = ActivePanelMode;
								}

								break;
						case HUD_MODE_STATS://Stats display
								StatsDisplay.UpdateNow=true	;	
								InventoryEnabled=false;
								RuneBagEnabled=false;
								StatsEnabled=true;
								ConversationEnabled=false;
								CutSceneSmallEnabled=true;
								CutSceneFullEnabled=false;
								MapEnabled=false;
								if (chains.ActiveControl>2)
								{
										chains.ActiveControl = ActivePanelMode;
										UpdatePanelStates();
								}
								else
								{
										StartCoroutine(RotatePanels(currentPanel,StatsDisplayPanel));
										chains.ActiveControl = ActivePanelMode;
								}


								break;	
						case HUD_MODE_RUNES://Runebag
								InventoryEnabled=false;
								RuneBagEnabled=true;
								StatsEnabled=false;
								ConversationEnabled=false;
								CutSceneSmallEnabled=true;
								CutSceneFullEnabled=false;
								MapEnabled=false;
								if (chains.ActiveControl>2)
								{
										chains.ActiveControl = ActivePanelMode;
										UpdatePanelStates();
								}
								else
								{
										StartCoroutine(RotatePanels(currentPanel,RuneBagPanel));
										chains.ActiveControl = ActivePanelMode;
								}

								break;	
						case HUD_MODE_CONV://Conversation
								GRLoader grConv = new GRLoader(GRLoader.CONVERSE_GR);
								InventoryPanel.GetComponent<RectTransform>().rotation=new Quaternion(0.0f,0.0f,0.0f,0.0f);
								PaperDollFemalePanel.GetComponent<RectTransform>().rotation=new Quaternion(0.0f,0.0f,0.0f,0.0f);
								PaperDollMalePanel.GetComponent<RectTransform>().rotation=new Quaternion(0.0f,0.0f,0.0f,0.0f);
								StatsDisplayPanel.GetComponent<RectTransform>().rotation=new Quaternion(0.0f,-1.0f,0.0f,0.0f);
								RuneBagPanel.GetComponent<RectTransform>().rotation=new Quaternion(0.0f,-1.0f,0.0f,0.0f);

								InventoryEnabled=true;
								RuneBagEnabled=false;
								StatsEnabled=false;
								ConversationEnabled=true;
								CutSceneSmallEnabled=false;
								CutSceneFullEnabled=false;
								MapEnabled=false;
								npcTradeArea.texture=grConv.LoadImageAt(1);
								pcTradeArea.texture=grConv.LoadImageAt(1);
								ConvNPCPortraitBG.texture=grConv.LoadImageAt(2);
								ConvPCPortraitBG.texture=grConv.LoadImageAt(2);
								ConvTextScrollTop.texture=grConv.LoadImageAt(3);
								ConvTextScrollBottom.texture=grConv.LoadImageAt(4);
								ConvPCTitleBG.texture=grConv.LoadImageAt(0);
								ConvNPCTitleBG.texture=grConv.LoadImageAt(0);
								UpdatePanelStates();
								break;	
						case HUD_MODE_MAP://Map
								InventoryPanel.GetComponent<RectTransform>().rotation=new Quaternion(0.0f,0.0f,0.0f,0.0f);
								PaperDollFemalePanel.GetComponent<RectTransform>().rotation=new Quaternion(0.0f,0.0f,0.0f,0.0f);
								PaperDollMalePanel.GetComponent<RectTransform>().rotation=new Quaternion(0.0f,0.0f,0.0f,0.0f);
								StatsDisplayPanel.GetComponent<RectTransform>().rotation=new Quaternion(0.0f,-1.0f,0.0f,0.0f);
								RuneBagPanel.GetComponent<RectTransform>().rotation=new Quaternion(0.0f,-1.0f,0.0f,0.0f);


								InventoryEnabled=false;
								RuneBagEnabled=false;
								StatsEnabled=false;
								ConversationEnabled=false;
								CutSceneSmallEnabled=false;
								CutSceneFullEnabled=false;
								MapEnabled=true;
								UpdatePanelStates();
								break;
						}	
				if(ActivePanelMode!=-1)
				{
						chains.ActiveControl=ActivePanelMode;
				}
						
		}


		/// <summary>
		/// Rotates the inventory panels around.
		/// </summary>
		/// <returns>The panels.</returns>
		/// <param name="fromPanel">From panel.</param>
		/// <param name="toPanel">To panel.</param>
		IEnumerator RotatePanels(GameObject fromPanel, GameObject toPanel)
		{
				bool refreshed=false;
				if (fromPanel==toPanel)
				{
						UpdatePanelStates();
						yield break;//Don't bother if the same control.
				}
				else
				{
					Quaternion fromQ= fromPanel.GetComponent<RectTransform>().rotation;;
					Quaternion toQ = toPanel.GetComponent<RectTransform>().rotation; 

					fromPanel.GetComponent<RectTransform>().SetSiblingIndex(5);
					toPanel.GetComponent<RectTransform>().SetSiblingIndex(6);

					float rate = 1.0f/0.5f;
					float index = 0.0f;

					isRotating=true;
					while (index <1.0f)
					{
							fromPanel.GetComponent<RectTransform>().rotation = Quaternion.Lerp (fromQ,toQ,index);
							toPanel.GetComponent<RectTransform>().rotation = Quaternion.Lerp (toQ,fromQ,index);
							if (index>=0.5f)
							{
										if (refreshed==false)
										{
												UpdatePanelStates();
												refreshed=true;
										}
									EnableDisableControl(toPanel,true);
									EnableDisableControl(fromPanel,false);	
							}
							else
							{
									EnableDisableControl(toPanel,false);
									EnableDisableControl(fromPanel,true);		
							}
							index += rate * Time.deltaTime;
							yield return new WaitForSeconds(0.01f);
					}
					fromPanel.GetComponent<RectTransform>().rotation=new Quaternion(0.0f,-1.0f,0.0f,0.0f);
					toPanel.GetComponent<RectTransform>().rotation=new Quaternion(0.0f,0.0f,0.0f,0.0f);
						if (refreshed==false)
						{
								UpdatePanelStates();
								refreshed=true;
						}
					isRotating=false;
					currentPanel=toPanel;
				}
		}



		/// <summary>
		/// Updates the panel states as needed.
		/// </summary>
		void UpdatePanelStates()
		{
				EnableDisableControl (RuneBagPanel,RuneBagEnabled);
				if (RuneBagEnabled==true)
				{
						RuneSlot.UpdateRuneDisplay();
				}
				EnableDisableControl(StatsDisplayPanel,StatsEnabled);
				EnableDisableControl(InventoryPanel, InventoryEnabled);
				EnableDisableControl(PaperDollFemalePanel, InventoryEnabled && GameWorldController.instance.playerUW.isFemale);
				EnableDisableControl(PaperDollMalePanel, InventoryEnabled && !GameWorldController.instance.playerUW.isFemale);
				EnableDisableControl(ConversationPanel,ConversationEnabled);
				EnableDisableControl(MapPanel,MapEnabled);
				EnableDisableControl(DragonLeftPanel,(((InventoryEnabled) || (StatsEnabled) || (RuneBagEnabled) || (ConversationEnabled)) && (UWHUD.instance.window.FullScreen==false)));
				EnableDisableControl(DragonRightPanel,(((InventoryEnabled) || (StatsEnabled) || (RuneBagEnabled) || (ConversationEnabled)) && (UWHUD.instance.window.FullScreen==false)));
				EnableDisableControl(CutsceneSmallPanel,CutSceneSmallEnabled);
				EnableDisableControl(CutsceneFullPanel,CutSceneFullEnabled);	

				EnableDisableControl(editorPanel,EditorMode);
		}

		/// <summary>
		/// Enables or disables a control.
		/// </summary>
		/// <param name="control">Control.</param>
		/// <param name="targetState">If set to <c>true</c> target state.</param>
		public void EnableDisableControl(GameObject control, bool targetState)
		{
				control.SetActive(targetState);
		}

}


