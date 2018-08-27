using UnityEngine;
using System.Collections;
using UnityEngine.UI;


/// <summary>
/// Class for referencing other hud elements without having to search for them all the time.
/// </summary>
public class UWHUD : HUD
{


    public const int HUD_MODE_INVENTORY = 0;
    public const int HUD_MODE_STATS = 1;
    public const int HUD_MODE_RUNES = 2;
    public const int HUD_MODE_CONV = 3;
    public const int HUD_MODE_MAP = 4;
    public const int HUD_MODE_CUTS_SMALL = 5;
    public const int HUD_MODE_CUTS_FULL = 6;

    public int CURRENT_HUD_MODE = 0;

    public static UWHUD instance;

    //Panel states 
    [Header("Panel States")]
    public bool InventoryEnabled = true;
    public bool RuneBagEnabled = false;
    public bool StatsEnabled = false;
    public bool ConversationEnabled = false;
    public bool CutSceneSmallEnabled = true;
    public bool CutSceneFullEnabled = true;
    public bool MapEnabled = false;
    //bool InteractionEnabled=true;
    public bool isRotating;

    /// Reference to the weapon animation animator.
    [Header("Anim Controls")]
    public WeaponAnimationPlayer wpa;
    public CutsceneAnimationFullscreen CutScenesFull;
    public HudAnimation CutScenesSmall;

    [Header("Input Output")]
    public ScrollController MessageScroll;
    public InputField InputControl;
    public GameObject MessageLogScrollEdgeLeft;
    public GameObject MessageLogScrollEdgeRight;
    public GameObject MessageScrollBackground;
    public GameObject MessageScrollDrag;
    public Text ErrorText;

    [Header("Main Windows")]
    public GameObject main_windowUW1;//The immersive heads up display for UW1
    public GameObject main_windowUW2;//The immersive heads up display for UW2
    public WindowDetectUW window;
    //Hud elements for run time loading
    public RawImage mapBackground;
    public RawImage mainwindow_art;

    [Header("TopLevelUIs")]
    public GameObject gameUi;
    public GameObject gameSelectUi;
    public MainMenuHud mainmenu;


    //Conversation Controls
    [Header("Conversation")]
    public ScrollController Conversation_tl;//Text output.
    public TradeSlot[] playerTrade;//= new TradeSlot[4];
    public TradeSlot[] npcTrade;//= new TradeSlot[4];
    public RawImage[] ConversationPortraits;
    public Text PCName;
    public Text NPCName;
    public RawImage npcTradeArea;
    public RawImage pcTradeArea;
    public RawImage ConvNPCPortraitBG;
    public RawImage ConvPCPortraitBG;
    public RawImage ConvPCTitleBG;
    public RawImage ConvNPCTitleBG;
    public RawImage ConvTextScrollTop;
    public RawImage ConvTextScrollBottom;
    public RawImage UW2ConversationBG;
    public GameObject UW1ScrollTop;
    public GameObject UW1ScrollBottom;
    public GameObject UW1ScrlEdgeLeft1;
    public GameObject UW1ScrlEdgeLeft2;
    public GameObject UW1ScrlEdgeLeft3;
    public GameObject UW1ScrlEdgeRight1;
    public GameObject UW1ScrlEdgeRight2;
    public GameObject UW1ScrlEdgeRight3;
    public GameObject UW1PortraitFramePC;
    public GameObject UW1PortraitFrameNPC;
    public GameObject UW1PCNameFrame;
    public GameObject UW1NPCNameFrame;
    public GameObject UW1PCTradeArea;
    public GameObject UW1NPCTradeArea;
    public GameObject UW1ConversationPaperBackground;



    [Header("Inventory")]
    public RawImage playerBody;
    public Text Encumberance;
    public GameObject ContainerOpened;
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
    public RawImage[] BackPack_Slot = new RawImage[8];
    public Text LeftHand_Qty;
    public Text RightHand_Qty;
    public Text LeftShoulder_Qty;
    public Text RightShoulder_Qty;
    public Text[] Backpack_Slot_Qty = new Text[8];

    public ScrollButtonInventory InvUp;
    public ScrollButtonInventory InvDown;


    [Header("Buttons and Labels")]
    public chains ChainsControl;
    public Text ContextMenu;

    [Header("Map")]
    public Text LevelNoDisplay;//Tile map level No	
    public RawImage MapDisplay; //should be in a subclass?
    public Texture2D MapQuill;
    public Texture2D MapQuillWriting;
    public Texture2D MapEraser;
    public RectTransform MapUp;
    public RectTransform MapDown;
    public RectTransform MapEraserButton;
    public RectTransform MapClose;
    public RectTransform WorldSelect;
    public MapWorldSelect[] InWorldGemSelect = new MapWorldSelect[9];

    [Header("Magic")]
    public ActiveRuneSlot[] activeRunes;
    public RuneSlot[] runes;
    public SpellEffectsDisplay[] spelleffectdisplay;


    //Panels
    [Header("Panels")]
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




    [Header("Indicators")]
    public RawImage FlaskHealth;
    public RawImage FlaskMana;
    public Eyes MonsterEyes;
    public Compass HudCompass;
    public Power powergem;

    [Header("Ingame Editor")]
    public Text editorButtonLabel;
    public IngameEditor editor;


    [Header("Interaction Control")]
    public InteractionModeControl InteractionControlUW1;
    public InteractionModeControl InteractionControlUW2;
    public RawImage InteractionControlUW2BG;




    void Awake()
    {
        instance = this;
    }


    public void Begin()
    {
        gameUi.SetActive(true);
        gameSelectUi.SetActive(false);

        //Init the art work for the hud
        //Init hud elements
        mapBackground.texture = GameWorldController.instance.bytloader.LoadImageAt(BytLoader.BLNKMAP_BYT);
        //mainwindow_art.texture=GameWorldController.instance.bytloader.LoadImageAt(BytLoader.MAIN_BYT);

        CursorIcon = GameWorldController.instance.grCursors.LoadImageAt(0);
        CursorIconDefault = GameWorldController.instance.grCursors.LoadImageAt(0);
        CursorIconTarget = GameWorldController.instance.grCursors.LoadImageAt(9);
        MapQuill = GameWorldController.instance.grCursors.LoadImageAt(14);
        MapQuillWriting = GameWorldController.instance.grCursors.LoadImageAt(12);
        MapEraser = GameWorldController.instance.grCursors.LoadImageAt(13);
        //inventoryDownArrow.texture=GameWorldController.instance.grCursors.LoadImageAt(2);
        //inventoryUpArrow.texture=GameWorldController.instance.grCursors.LoadImageAt(1);

        GRLoader grPanels = new GRLoader(GRLoader.PANELS_GR);
        InventoryPanel.GetComponent<RawImage>().texture = grPanels.LoadImageAt(0);
        RuneBagPanel.GetComponent<RawImage>().texture = grPanels.LoadImageAt(1);
        StatsDisplayPanel.GetComponent<RawImage>().texture = grPanels.LoadImageAt(2);

        UWHUD.instance.EnableDisableControl(UWHUD.instance.main_windowUW1, _RES != GAME_UW2);
        UWHUD.instance.EnableDisableControl(UWHUD.instance.main_windowUW2, _RES == GAME_UW2);

        UWHUD.instance.EnableDisableControl(UWHUD.instance.InteractionControlUW1.gameObject, _RES != GAME_UW2);
        UWHUD.instance.EnableDisableControl(UWHUD.instance.InteractionControlUW2.gameObject, _RES == GAME_UW2);

        MapPanel.transform.SetAsLastSibling();
        ConversationPanel.transform.SetAsLastSibling();

        GRLoader grButtons = new GRLoader(GRLoader.BUTTONS_GR);
        if (grButtons!=null)
        {
            InvUp.GetComponent<RawImage>().texture = grButtons.LoadImageAt(27);
            InvDown.GetComponent<RawImage>().texture = grButtons.LoadImageAt(28);
        }


        switch (_RES)
        {
            case GAME_UW2:
                //Set UW2 specific UI positions

                SetUIElementPosition(window, 128f, 210f, new Vector2(-40.8f, 20f));

                SetUIElementPosition(HudCompass, 16f, 52f, new Vector2(-40f, -56f));
                SetUIElementPosition(HudCompass.NorthIndicators[0], 4f, 10f, new Vector2(26.02f - 26f, 13.98f - 8f));
                SetUIElementPosition(HudCompass.NorthIndicators[1], 4f, 10f, new Vector2(33.01f - 26f, 13.99f - 8f));
                SetUIElementPosition(HudCompass.NorthIndicators[2], 5f, 5f, new Vector2(40.46f - 26f, 12.51f - 8f));
                SetUIElementPosition(HudCompass.NorthIndicators[3], 4f, 10f, new Vector2(44.00f - 26f, 12.01f - 8f));
                SetUIElementPosition(HudCompass.NorthIndicators[4], 5f, 7f, new Vector2(48.52f - 26f, 8.5f - 8f));
                SetUIElementPosition(HudCompass.NorthIndicators[5], 6f, 9f, new Vector2(46.51f - 26f, 7.02f - 8f));
                SetUIElementPosition(HudCompass.NorthIndicators[6], 5f, 8f, new Vector2(42.00f - 26f, 4.5f - 8f));
                SetUIElementPosition(HudCompass.NorthIndicators[7], 5f, 11f, new Vector2(33.49f - 26f, 3.5f - 8f));
                SetUIElementPosition(HudCompass.NorthIndicators[8], 5f, 12f, new Vector2(26f - 26f, 2.49f - 8f));
                SetUIElementPosition(HudCompass.NorthIndicators[9], 5f, 11f, new Vector2(18.5f - 26f, 3.49f - 8f));
                SetUIElementPosition(HudCompass.NorthIndicators[10], 5f, 8f, new Vector2(9.99f - 26f, 4.49f - 8f));
                SetUIElementPosition(HudCompass.NorthIndicators[11], 6f, 10f, new Vector2(5.04f - 26f, 7.01f - 8f));
                SetUIElementPosition(HudCompass.NorthIndicators[12], 5f, 7f, new Vector2(3.49f - 26f, 8.49f - 8f));
                SetUIElementPosition(HudCompass.NorthIndicators[13], 5f, 8f, new Vector2(5.98f - 26f, 10.51f - 8f));
                SetUIElementPosition(HudCompass.NorthIndicators[14], 6f, 8f, new Vector2(11.99f - 26f, 11.97f - 8f));
                SetUIElementPosition(HudCompass.NorthIndicators[15], 5f, 10f, new Vector2(19.03f - 26f, 13.5f - 8f));
                SetUIElementPosition(powergem, 5f, 14f, new Vector2(-40f, -53.79f));
                powergem.transform.parent.GetComponent<RectTransform>().SetSiblingIndex(HudCompass.GetComponent<RectTransform>().GetSiblingIndex() + 1);

                SetUIElementPosition(ChainsControl, 32f, 15f, new Vector2(119.7f, -35f));

                FlaskMana.GetComponent<RectTransform>().anchoredPosition = new Vector2(139.5f, -48.4f);
                FlaskHealth.GetComponent<RectTransform>().anchoredPosition = new Vector2(100.14f, -48.5f);

                activeRunes[0].transform.parent.GetComponent<RectTransform>().anchoredPosition = new Vector2(1.9f, -11.6f);

                spelleffectdisplay[0].transform.parent.GetComponent<RectTransform>().anchoredPosition = new Vector2(-35f, -11.6f);

                //InventoryPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(114.7f,36f);
                SetUIElementPosition(InventoryPanel, 112f, 79f, new Vector2(114.6f, 36.7f));
                SetUIElementPosition(RuneBagPanel, 112f, 79f, new Vector2(114.6f, 36.7f));
                SetUIElementPosition(StatsDisplayPanel, 112f, 79f, new Vector2(114.6f, 36.7f));
                //RuneBagPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(114.7f,36f);
                //StatsDisplayPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(114.7f,36f);

                SetUIElementPosition(playerBody, 69f, 36f, new Vector2(1.78f, 20.51f));


                SetUIElementPosition(RightShoulder_Slot, 16f, 16f, new Vector2(16.8f - 39f, 99.4f - 56.3f));
                SetUIElementPosition(LeftShoulder_Slot, 16f, 16f, new Vector2(65.3f - 39f, 99.4f - 56.3f));
                SetUIElementPosition(RightHand_Slot, 16f, 16f, new Vector2(12.8f - 39f, 77f - 56.3f));
                SetUIElementPosition(LeftHand_Slot, 16f, 16f, new Vector2(68.3f - 39f, 76.9f - 56.3f));

                SetUIElementPosition(BackPack_Slot[0], 16f, 16f, new Vector2(11.9f - 39f, 30f - 55.9f));
                SetUIElementPosition(BackPack_Slot[1], 16f, 16f, new Vector2(30.9f - 39f, 30f - 55.9f));
                SetUIElementPosition(BackPack_Slot[2], 16f, 16f, new Vector2(49.9f - 39f, 30f - 55.9f));
                SetUIElementPosition(BackPack_Slot[3], 16f, 16f, new Vector2(68.9f - 39f, 30f - 55.9f));
                SetUIElementPosition(BackPack_Slot[4], 16f, 16f, new Vector2(11.9f - 39f, 12f - 55.9f));
                SetUIElementPosition(BackPack_Slot[5], 16f, 16f, new Vector2(30.9f - 39f, 12f - 55.9f));
                SetUIElementPosition(BackPack_Slot[6], 16f, 16f, new Vector2(49.9f - 39f, 12f - 55.9f));
                SetUIElementPosition(BackPack_Slot[7], 16f, 16f, new Vector2(68.9f - 39f, 12f - 55.9f));

                SetUIElementPosition(ContainerOpened, 16f, 16f, new Vector2(-26f, -4.8f));

                SetUIElementPosition(RightRing_Slot, 8f, 8f, new Vector2(-13.71f, 5.01f));
                SetUIElementPosition(LeftRing_Slot, 8f, 8f, new Vector2(17.69f, 5.01f));

                SetUIElementPosition(MonsterEyes, 3f, 20f, new Vector2(-40.06f, 94.48f));

                SetUIElementPosition(Legs_f_Slot, 51f, 19f, new Vector2(276.83f - 157.83f, 132.71f - 80.71f));
                SetUIElementPosition(Chest_f_Slot, 44f, 33f, new Vector2(277.83f - 157.83f, 137.71f - 80.71f));
                SetUIElementPosition(Helm_f_Slot, 20f, 20f, new Vector2(276.38f - 157.83f, 162.74f - 80.71f));
                SetUIElementPosition(Gloves_f_Slot, 15f, 33f, new Vector2(276.9f - 157.83f, 131.11f - 80.71f));
                SetUIElementPosition(Boots_f_Slot, 14f, 21f, new Vector2(275.83f - 157.83f, 109.01f - 80.71f));

                SetUIElementPosition(Legs_m_Slot, 51f, 19f, new Vector2(276.83f - 157.83f, 132.71f - 80.71f));
                SetUIElementPosition(Chest_m_Slot, 44f, 33f, new Vector2(277.83f - 157.83f, 137.71f - 80.71f));
                SetUIElementPosition(Helm_m_Slot, 20f, 20f, new Vector2(276.38f - 157.83f, 162.74f - 80.71f));
                SetUIElementPosition(Gloves_m_Slot, 15f, 33f, new Vector2(276.9f - 157.83f, 131.11f - 80.71f));
                SetUIElementPosition(Boots_m_Slot, 14f, 21f, new Vector2(275.83f - 157.83f, 109.01f - 80.71f));


                SetUIElementPosition(ContainerOpened.GetComponent<ContainerOpened>().BackpackBg, 0.9f, -34.4f, new Vector2(40.9f, 21.7f));

                MessageLogScrollEdgeRight.GetComponent<RectTransform>().anchoredPosition = new Vector2(65.87f, -64.4f);
                MessageScrollBackground.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 208.68f);
                MessageScrollBackground.GetComponent<RectTransform>().anchoredPosition = new Vector2(-40.8f, -64.8f);
                MessageScrollDrag.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 216f);
                MessageScrollDrag.GetComponent<RectTransform>().anchoredPosition = new Vector2(-41.2f, -64.5f);

                //MessageScroll.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 172f);
                //MessageScroll.GetComponent<RectTransform>().anchoredPosition= new Vector2(-39.5f, -62.4f);
                SetUIElementPosition(MessageScroll, 33f, 174f, new Vector2(-40.93f, -62.4f));

                //Conversation element positions
                SetUIElementPosition(Conversation_tl, 80f, 198f, new Vector2(-38.54f, -19.9f));
                SetUIElementPosition(ConversationPortraits[0], 70f, 64f, new Vector2(39.9f, 62f));
                SetUIElementPosition(ConversationPortraits[1], 70f, 64f, new Vector2(-125.9f, 62f));
                PCName.GetComponent<RectTransform>().anchoredPosition = new Vector2(-37.6f, 97.871f);
                PCName.alignment = TextAnchor.MiddleRight;
                NPCName.GetComponent<RectTransform>().anchoredPosition = new Vector2(-46.7f, 29.9f);
                NPCName.alignment = TextAnchor.MiddleLeft;


                //Player Trade

                SetUIElementPosition(playerTrade[0], 16f, 16f, new Vector2(130.7f- 158.6f, 180.8f - 100.69f));
                SetUIElementPosition(playerTrade[1], 16f, 16f, new Vector2(151.2f - 158.6f, 180.8f - 100.69f));
                SetUIElementPosition(playerTrade[2], 16f, 16f, new Vector2(130.7f - 158.6f, 163.2f - 100.69f));
                SetUIElementPosition(playerTrade[3], 16f, 16f, new Vector2(151.2f - 158.6f, 163.2f - 100.69f));
                SetUIElementPosition(playerTrade[4], 16f, 16f, new Vector2(130.7f - 158.6f, 145.62f - 100.69f));
                SetUIElementPosition(playerTrade[5], 16f, 16f, new Vector2(151.2f - 158.6f, 145.6f - 100.69f));

                SetUIElementPosition(npcTrade[0], 16f, 16f, new Vector2(81.5f - 158.6f, 180.8f - 100.69f));
                SetUIElementPosition(npcTrade[1], 16f, 16f, new Vector2(102f - 158.6f, 180.8f - 100.69f));
                SetUIElementPosition(npcTrade[2], 16f, 16f, new Vector2(81.5f - 158.6f, 163.2f - 100.69f));
                SetUIElementPosition(npcTrade[3], 16f, 16f, new Vector2(102f - 158.6f, 163.2f - 100.69f));
                SetUIElementPosition(npcTrade[4], 16f, 16f, new Vector2(81.5f - 158.6f, 145.6f - 100.69f));
                SetUIElementPosition(npcTrade[5], 16f, 16f, new Vector2(102.2f - 158.6f, 145.6f - 100.69f));


                //Automap
                SetUIElementPosition(MapDown, 30f, 30f, new Vector2(145f, 85f));
                SetUIElementPosition(MapUp, 30f, 30f, new Vector2(145f, -85f));
                SetUIElementPosition(MapEraserButton, 30f, 30f, new Vector2(120f, -25f));
                SetUIElementPosition(MapClose, 30f, 60f, new Vector2(120f, -55f));

                MapInteraction.InitMapButtons(InWorldGemSelect);
                break;
        }
    }



    static void SetUIElementPosition(RectTransform rectT, float height, float width, Vector2 anchorPos)
    {
        rectT.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
        rectT.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
        rectT.anchoredPosition = anchorPos;
    }

    static void SetUIElementPosition(GameObject obj, float height, float width, Vector2 anchorPos)
    {
        if (obj.GetComponent<RectTransform>() != null)
        {
            SetUIElementPosition(obj.GetComponent<RectTransform>(), height, width, anchorPos);
        }
    }

    static void SetUIElementPosition(RawImage obj, float height, float width, Vector2 anchorPos)
    {
        if (obj.GetComponent<RectTransform>() != null)
        {
            SetUIElementPosition(obj.GetComponent<RectTransform>(), height, width, anchorPos);
        }
    }

    static void SetUIElementPosition(GuiBase obj, float height, float width, Vector2 anchorPos)
    {
        if (obj.GetComponent<RectTransform>() != null)
        {
            SetUIElementPosition(obj.GetComponent<RectTransform>(), height, width, anchorPos);
        }
    }


    /// <summary>
    /// Refreshs the panels depending on the active mode
    /// </summary>
    /// <param name="ActivePanelMode">Active panel mode.</param>
    public void RefreshPanels(int ActivePanelMode)
    {
        CURRENT_HUD_MODE = ActivePanelMode;
        switch (ActivePanelMode)
        {
            case -1:
                UpdatePanelStates();
                break;
            case HUD_MODE_INVENTORY://Inventory
                InventoryEnabled = true;
                RuneBagEnabled = false;
                StatsEnabled = false;
                ConversationEnabled = false;
                CutSceneSmallEnabled = true;
                CutSceneFullEnabled = false;
                MapEnabled = false;
                //InteractionEnabled=true;
                if (chains.ActiveControl > 2)
                {
                    chains.ActiveControl = ActivePanelMode;
                    UpdatePanelStates();
                }
                else
                {
                    StartCoroutine(RotatePanels(currentPanel, InventoryPanel));
                    chains.ActiveControl = ActivePanelMode;
                }

                break;
            case HUD_MODE_STATS://Stats display
                StatsDisplay.UpdateNow = true;
                InventoryEnabled = false;
                RuneBagEnabled = false;
                StatsEnabled = true;
                ConversationEnabled = false;
                CutSceneSmallEnabled = true;
                CutSceneFullEnabled = false;
                MapEnabled = false;
                //InteractionEnabled=true;
                if (chains.ActiveControl > 2)
                {
                    chains.ActiveControl = ActivePanelMode;
                    UpdatePanelStates();
                }
                else
                {
                    StartCoroutine(RotatePanels(currentPanel, StatsDisplayPanel));
                    chains.ActiveControl = ActivePanelMode;
                }
                break;
            case HUD_MODE_RUNES://Runebag
                InventoryEnabled = false;
                RuneBagEnabled = true;
                StatsEnabled = false;
                ConversationEnabled = false;
                CutSceneSmallEnabled = true;
                CutSceneFullEnabled = false;
                MapEnabled = false;
                //InteractionEnabled=true;
                if (chains.ActiveControl > 2)
                {
                    chains.ActiveControl = ActivePanelMode;
                    UpdatePanelStates();
                }
                else
                {
                    StartCoroutine(RotatePanels(currentPanel, RuneBagPanel));
                    chains.ActiveControl = ActivePanelMode;
                }

                break;
            case HUD_MODE_CONV://Conversation

                InventoryPanel.GetComponent<RectTransform>().rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
                PaperDollFemalePanel.GetComponent<RectTransform>().rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
                PaperDollMalePanel.GetComponent<RectTransform>().rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
                StatsDisplayPanel.GetComponent<RectTransform>().rotation = new Quaternion(0.0f, -1.0f, 0.0f, 0.0f);
                RuneBagPanel.GetComponent<RectTransform>().rotation = new Quaternion(0.0f, -1.0f, 0.0f, 0.0f);
                InventoryEnabled = true;
                RuneBagEnabled = false;
                StatsEnabled = false;
                ConversationEnabled = true;
                CutSceneSmallEnabled = false;
                CutSceneFullEnabled = false;
                MapEnabled = false;
                //InteractionEnabled=false;
                if (_RES != GAME_UW2)
                {
                    GRLoader grConv = new GRLoader(GRLoader.CONVERSE_GR);
                    npcTradeArea.texture = grConv.LoadImageAt(1);
                    pcTradeArea.texture = grConv.LoadImageAt(1);
                    ConvNPCPortraitBG.texture = grConv.LoadImageAt(2);
                    ConvPCPortraitBG.texture = grConv.LoadImageAt(2);
                    ConvTextScrollTop.texture = grConv.LoadImageAt(3);
                    ConvTextScrollBottom.texture = grConv.LoadImageAt(4);
                    ConvPCTitleBG.texture = grConv.LoadImageAt(0);
                    ConvNPCTitleBG.texture = grConv.LoadImageAt(0);
                }
                UpdatePanelStates();
                break;
            case HUD_MODE_MAP://Map
                InventoryPanel.GetComponent<RectTransform>().rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
                PaperDollFemalePanel.GetComponent<RectTransform>().rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
                PaperDollMalePanel.GetComponent<RectTransform>().rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
                StatsDisplayPanel.GetComponent<RectTransform>().rotation = new Quaternion(0.0f, -1.0f, 0.0f, 0.0f);
                RuneBagPanel.GetComponent<RectTransform>().rotation = new Quaternion(0.0f, -1.0f, 0.0f, 0.0f);


                InventoryEnabled = false;
                RuneBagEnabled = false;
                StatsEnabled = false;
                ConversationEnabled = false;
                CutSceneSmallEnabled = false;
                CutSceneFullEnabled = false;
                MapEnabled = true;
                //InteractionEnabled=false;
                UpdatePanelStates();
                break;
        }
        if (ActivePanelMode != -1)
        {
            chains.ActiveControl = ActivePanelMode;
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
        bool refreshed = false;
        if (fromPanel == toPanel)
        {
            UpdatePanelStates();
            yield break;//Don't bother if the same control.
        }
        else
        {
            Quaternion fromQ = fromPanel.GetComponent<RectTransform>().rotation; ;
            Quaternion toQ = toPanel.GetComponent<RectTransform>().rotation;

            fromPanel.GetComponent<RectTransform>().SetSiblingIndex(5);
            toPanel.GetComponent<RectTransform>().SetSiblingIndex(6);

            float rate = 1.0f / 0.5f;
            float index = 0.0f;

            isRotating = true;
            while (index < 1.0f)
            {
                fromPanel.GetComponent<RectTransform>().rotation = Quaternion.Lerp(fromQ, toQ, index);
                toPanel.GetComponent<RectTransform>().rotation = Quaternion.Lerp(toQ, fromQ, index);
                if (index >= 0.5f)
                {
                    if (refreshed == false)
                    {
                        UpdatePanelStates();
                        refreshed = true;
                    }
                    EnableDisableControl(toPanel, true);
                    EnableDisableControl(fromPanel, false);
                }
                else
                {
                    EnableDisableControl(toPanel, false);
                    EnableDisableControl(fromPanel, true);
                }
                index += rate * Time.deltaTime;
                yield return new WaitForSeconds(0.01f);
            }
            fromPanel.GetComponent<RectTransform>().rotation = new Quaternion(0.0f, -1.0f, 0.0f, 0.0f);
            toPanel.GetComponent<RectTransform>().rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
            if (refreshed == false)
            {
                UpdatePanelStates();
                refreshed = true;
            }
            isRotating = false;
            currentPanel = toPanel;
        }
    }



    /// <summary>
    /// Updates the panel states as needed.
    /// </summary>
    void UpdatePanelStates()
    {
        EnableDisableControl(RuneBagPanel, RuneBagEnabled);
        if (RuneBagEnabled == true)
        {
            RuneSlot.UpdateRuneDisplay();
        }
        EnableDisableControl(ContextMenu.gameObject, WindowDetectUW.ContextUIEnabled);
        EnableDisableControl(StatsDisplayPanel, StatsEnabled);
        EnableDisableControl(InventoryPanel, InventoryEnabled);
        EnableDisableControl(PaperDollFemalePanel, InventoryEnabled && UWCharacter.Instance.isFemale);
        EnableDisableControl(PaperDollMalePanel, InventoryEnabled && !UWCharacter.Instance.isFemale);
        EnableDisableControl(ConversationPanel, ConversationEnabled);
        EnableDisableControl(ChainsControl.gameObject, (RuneBagEnabled || StatsEnabled || InventoryEnabled) && ConversationEnabled == false);

        EnableDisableControl(UW2ConversationBG.gameObject, ConversationEnabled && _RES == GAME_UW2);
        EnableDisableControl(UW1ScrollTop, ConversationEnabled && _RES != GAME_UW2);
        EnableDisableControl(UW1ScrollBottom, ConversationEnabled && _RES != GAME_UW2);
        EnableDisableControl(UW1ScrlEdgeLeft1, ConversationEnabled && _RES != GAME_UW2);
        EnableDisableControl(UW1ScrlEdgeLeft2, ConversationEnabled && _RES != GAME_UW2);
        EnableDisableControl(UW1ScrlEdgeLeft3, ConversationEnabled && _RES != GAME_UW2);
        EnableDisableControl(UW1ScrlEdgeRight1, ConversationEnabled && _RES != GAME_UW2);
        EnableDisableControl(UW1ScrlEdgeRight2, ConversationEnabled && _RES != GAME_UW2);
        EnableDisableControl(UW1ScrlEdgeRight3, ConversationEnabled && _RES != GAME_UW2);
        EnableDisableControl(UW1PortraitFramePC, ConversationEnabled && _RES != GAME_UW2);
        EnableDisableControl(UW1PortraitFrameNPC, ConversationEnabled && _RES != GAME_UW2);
        EnableDisableControl(UW1PCNameFrame, ConversationEnabled && _RES != GAME_UW2);
        EnableDisableControl(UW1NPCNameFrame, ConversationEnabled && _RES != GAME_UW2);
        EnableDisableControl(UW1PCTradeArea, ConversationEnabled && _RES != GAME_UW2);
        EnableDisableControl(UW1NPCTradeArea, ConversationEnabled && _RES != GAME_UW2);
        EnableDisableControl(UW1ConversationPaperBackground, ConversationEnabled && _RES != GAME_UW2);

        EnableDisableControl(MapPanel, MapEnabled);
        EnableDisableControl(DragonLeftPanel, ((_RES != GAME_UW2) && (((InventoryEnabled) || (StatsEnabled) || (RuneBagEnabled) || (ConversationEnabled)) && (UWHUD.instance.window.FullScreen == false))));
        EnableDisableControl(DragonRightPanel, ((_RES != GAME_UW2) && (((InventoryEnabled) || (StatsEnabled) || (RuneBagEnabled) || (ConversationEnabled)) && (UWHUD.instance.window.FullScreen == false))));
        EnableDisableControl(CutsceneSmallPanel, CutSceneSmallEnabled);
        EnableDisableControl(CutsceneFullPanel, CutSceneFullEnabled);
        EnableDisableControl(MonsterEyes.gameObject, ((((InventoryEnabled) || (StatsEnabled) || (RuneBagEnabled)) && (!ConversationEnabled)) && (UWHUD.instance.window.FullScreen == false)));
        EnableDisableControl(HudCompass.gameObject, !ConversationEnabled);
        EnableDisableControl(powergem.gameObject, !ConversationEnabled);

        EnableDisableControl(InteractionControlUW1.gameObject, !ConversationEnabled && (RuneBagEnabled || StatsEnabled || InventoryEnabled) && (_RES != GAME_UW2));
        EnableDisableControl(InteractionControlUW2.gameObject, !ConversationEnabled && (RuneBagEnabled || StatsEnabled || InventoryEnabled) && (_RES == GAME_UW2));
        EnableDisableControl(ContextMenu.gameObject, !ConversationEnabled);

        if ((_RES == GAME_UW2) && (ConversationEnabled))
        {
            ConversationPanel.transform.SetSiblingIndex(5);
            MessageScrollBackground.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 300f);
            MessageScrollBackground.GetComponent<RectTransform>().anchoredPosition = new Vector2(-40.8f, -64.8f);
            //MessageScroll.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 250f);
            SetUIElementPosition(MessageScroll, 33f, 250f, new Vector2(4f, -62.4f));
            EnableDisableControl(MessageLogScrollEdgeLeft, false);
            EnableDisableControl(MessageLogScrollEdgeRight, false);
            EnableDisableControl(MessageScrollBackground, false);
            EnableDisableControl(activeRunes[0].gameObject, false);
            EnableDisableControl(activeRunes[1].gameObject, false);
            EnableDisableControl(activeRunes[2].gameObject, false);
        }
        else
        {
            EnableDisableControl(MessageLogScrollEdgeLeft, true);
            EnableDisableControl(MessageLogScrollEdgeRight, true);
            EnableDisableControl(MessageScrollBackground, true);
            EnableDisableControl(activeRunes[0].gameObject, true);
            EnableDisableControl(activeRunes[1].gameObject, true);
            EnableDisableControl(activeRunes[2].gameObject, true);
            if (_RES == GAME_UW2)
            {
                MessageScrollBackground.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 208.68f);
                MessageScrollBackground.GetComponent<RectTransform>().anchoredPosition = new Vector2(-40.8f, -64.8f);
                //MessageScroll.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 172f);
                SetUIElementPosition(MessageScroll, 33f, 174f, new Vector2(-40.93f, -62.4f));
            }
        }

        //additional tradeslots for uw2
        EnableDisableControl(playerTrade[4], ConversationEnabled && _RES==GAME_UW2);
        EnableDisableControl(playerTrade[5], ConversationEnabled && _RES == GAME_UW2);
        EnableDisableControl(npcTrade[4], ConversationEnabled && _RES == GAME_UW2);
        EnableDisableControl(npcTrade[5], ConversationEnabled && _RES == GAME_UW2);

        EnableDisableControl(editorPanel, EditorMode);
    }

    /// <summary>
    /// Enables or disables a control.
    /// </summary>
    /// <param name="control">Control.</param>
    /// <param name="targetState">If set to <c>true</c> target state.</param>
    public void EnableDisableControl(GameObject control, bool targetState)
    {
        if (control != null)
        {
            control.SetActive(targetState);
        }
    }

    /// <summary>
    /// Enables or disables a control.
    /// </summary>
    /// <param name="control">Control.</param>
    /// <param name="targetState">If set to <c>true</c> target state.</param>
    public void EnableDisableControl(GuiBase control, bool targetState)
    {
        if (control!=null)
        {
            EnableDisableControl(control.gameObject,targetState);
        }        
    }

}


