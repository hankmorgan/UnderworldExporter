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
	public MainMenuHud mainmenu;
	public CutsceneAnimation CutScenesSmall;

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


		public Text ContextMenu;


		void Awake()
		{
			instance=this;
		}


		void Start()
		{
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
						case 0://Inventory
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
						case 1://Stats display
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
						case 2://Runebag
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
						case 3://Conversation
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
								UpdatePanelStates();
								break;	
						case 4://Map
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

					fromPanel.GetComponent<RectTransform>().SetSiblingIndex(4);
					toPanel.GetComponent<RectTransform>().SetSiblingIndex(5);

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


