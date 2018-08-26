using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MapInteraction : GuiBase
{

    public MapWorldSelect[] MapSelectButtons = new MapWorldSelect[9];

    public const int MapInteractionNormal = 0;
    public const int MapInteractionDelete = 1;
    public const int MapInteractionWriting = 2;
    public static int MapNo;//Current Map being displayed
    public static Vector2 caretAdjustment = Vector2.zero;
    private Text mapNoteCurrent;
    public InputField MapNoteInput;
    private Vector2 pos;
    public static Vector2 CursorPos; //at start of typing
    public static int InteractionMode; //0 = normal. 1 = delete note. 2 =writing
    public GameWorldController.Worlds CurrentWorld = GameWorldController.Worlds.Britannia;   //What world we are in.  

    public static MapInteraction instance;


    /// <summary>
    /// Initialise the button art
    /// </summary>
    private void Awake()
    {
        instance = this;
        if (_RES != GAME_UW2)
        {
            for (int i = 0; i <= MapSelectButtons.GetUpperBound(0); i++)
            {
                if (MapSelectButtons[i] != null)
                {
                    UWHUD.instance.EnableDisableControl(MapSelectButtons[i].gameObject, false);
                }
            }
            return;
        }

        InitMapButtons(MapSelectButtons);
    }

    public static void InitMapButtons(MapWorldSelect[] Buttons)
    {
        GRLoader gempt = new GRLoader(GRLoader.GEMPT_GR, 3);
        for (int i = 0; i <= Buttons.GetUpperBound(0); i++)
        {
            if (Buttons[i] != null)
            {
                switch (Buttons[i].world)
                {
                    case GameWorldController.Worlds.Britannia:
                        Buttons[i].ButtonOff = GRLoader.CreateBlankImage(29, 29);
                        Buttons[i].ButtonOn = gempt.LoadImageAt(16);
                        break;
                    case GameWorldController.Worlds.PrisonTower:
                        Buttons[i].ButtonOff = gempt.LoadImageAt(0);
                        Buttons[i].ButtonOn = gempt.LoadImageAt(8);
                        break;
                    case GameWorldController.Worlds.Killorn:
                        Buttons[i].ButtonOff = gempt.LoadImageAt(1);
                        Buttons[i].ButtonOn = gempt.LoadImageAt(9);
                        break;
                    case GameWorldController.Worlds.Ice:
                        Buttons[i].ButtonOff = gempt.LoadImageAt(2);
                        Buttons[i].ButtonOn = gempt.LoadImageAt(10);
                        break;
                    case GameWorldController.Worlds.Talorus:
                        Buttons[i].ButtonOff = gempt.LoadImageAt(3);
                        Buttons[i].ButtonOn = gempt.LoadImageAt(11);
                        break;
                    case GameWorldController.Worlds.Academy:
                        Buttons[i].ButtonOff = gempt.LoadImageAt(4);
                        Buttons[i].ButtonOn = gempt.LoadImageAt(12);
                        break;
                    case GameWorldController.Worlds.Pits:
                        Buttons[i].ButtonOff = gempt.LoadImageAt(6);
                        Buttons[i].ButtonOn = gempt.LoadImageAt(14);
                        break;
                    case GameWorldController.Worlds.Tomb:
                        Buttons[i].ButtonOff = gempt.LoadImageAt(5);
                        Buttons[i].ButtonOn = gempt.LoadImageAt(13);
                        break;
                    case GameWorldController.Worlds.Ethereal:
                        Buttons[i].ButtonOff = gempt.LoadImageAt(7);
                        Buttons[i].ButtonOn = gempt.LoadImageAt(15);
                        break;
                }
            }
        }
    }

    public void MapClose()
    {
        Time.timeScale = 1f;
        WindowDetect.InMap = false;
        UWCharacter.Instance.playerMotor.jumping.enabled = true;
        InventorySlot.Hovering = false;
        if (MusicController.instance != null)
        {
            MusicController.instance.InMap = false;
        }
        UWHUD.instance.RefreshPanels(UWHUD.HUD_MODE_INVENTORY);
        UWHUD.instance.CursorIcon = UWHUD.instance.CursorIconDefault;
    }

    public void MapUp()
    {
        if (MapNo > 0)
        {
            if (MapNo > (int)CurrentWorld)
            {
                MapNo--;
                UpdateMap(MapNo);
            }
        }
    }

    public void MapDown()
    {//Actually increases the map number!
        if (MapNo < GameWorldController.instance.AutoMaps.GetUpperBound(0))
        {
            if (MapNo < MaxWorld(MapNo))
            {
                MapNo++;
                UpdateMap(MapNo);
            }
        }
    }

    /// <summary>
    /// Updates the map for the specified level no
    /// </summary>
    /// <param name="LevelNo">Level no.</param>
    public static void UpdateMap(int LevelNo)
    {
        WindowDetect.InMap = true;//turns on blocking collider.
        instance.CurrentWorld = GameWorldController.GetWorld(LevelNo);
        ///Sets the map no display
        UWHUD.instance.LevelNoDisplay.text = (1 + (LevelNo - (int)instance.CurrentWorld)).ToString() + " " + instance.CurrentWorld + " (" + LevelNo + ")";
        if (_RES == GAME_UW2)
        {
            for (int i = 0; i <= instance.MapSelectButtons.GetUpperBound(0); i++)
            {
                if (instance.MapSelectButtons[i] != null)
                {
                    if (instance.MapSelectButtons[i].world == instance.CurrentWorld)
                    {
                        instance.MapSelectButtons[i].SetOn();
                    }
                    else
                    {
                        instance.MapSelectButtons[i].SetOff();
                    }
                }
            }
        }
        MapInteraction.MapNo = LevelNo;
        UWHUD.instance.CursorIcon = UWHUD.instance.MapQuill;
        UWHUD.instance.MapDisplay.texture = GameWorldController.instance.AutoMaps[MapInteraction.MapNo].TileMapImage();

        ///Display the map notes
        ///Delete the map notes in memory
        foreach (Transform child in UWHUD.instance.MapPanel.transform)
        {
            if (child.name.Substring(0, 4) == "_Map")
            {
                GameObject.Destroy(child.transform.gameObject);
            }
        }
        if (GameWorldController.instance.AutoMaps[MapInteraction.MapNo] != null)
        {
            if (GameWorldController.instance.AutoMaps[MapInteraction.MapNo].MapNotes != null)
            {
                for (int i = 0; i < GameWorldController.instance.AutoMaps[MapInteraction.MapNo].MapNotes.Count; i++)
                {///Instantiates the map note template UI control.
                    GameObject myObj = (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/_MapNoteTemplate"));
                    myObj.name = "_Map-Note Number " + i;
                    myObj.transform.parent = UWHUD.instance.MapPanel.transform;
                    myObj.GetComponent<Text>().text = GameWorldController.instance.AutoMaps[MapInteraction.MapNo].MapNotes[i].NoteText;
                    myObj.GetComponent<RectTransform>().anchoredPosition = GameWorldController.instance.AutoMaps[MapInteraction.MapNo].MapNotes[i].NotePosition();
                    myObj.GetComponent<MapNoteId>().guid = GameWorldController.instance.AutoMaps[MapInteraction.MapNo].MapNotes[i].guid;
                    //Move the control so that it sits in front of the map,
                    myObj.GetComponent<RectTransform>().SetSiblingIndex(4);
                }
            }
        }
    }

    public void ClickEraser()
    {
        if (InteractionMode == MapInteractionNormal)
        {
            InteractionMode = MapInteractionDelete;
            UWHUD.instance.CursorIcon = UWHUD.instance.MapEraser;
        }
        else
        {
            InteractionMode = MapInteractionNormal;
            UWHUD.instance.CursorIcon = UWHUD.instance.MapQuill;
        }
    }

    public void OnClick(BaseEventData evnt)
    {
        switch (InteractionMode)
        {
            case MapInteractionNormal:
                InteractionMode = MapInteractionWriting;
                UWHUD.instance.CursorIcon = UWHUD.instance.MapQuillWriting;

                pos = Vector2.zero;
                RectTransform rect = this.GetComponent<RectTransform>();
                PointerEventData pntr = (PointerEventData)evnt;
                CursorPos = UWHUD.instance.window.CursorPosition.center;//pntr.pressPosition;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, pntr.pressPosition, pntr.pressEventCamera, out pos);
                pos = pos + new Vector2(150.0f, -4.0f);
                GameObject myObj = (GameObject)Instantiate(Resources.Load("Prefabs/_MapNoteTemplate"));
                mapNoteCurrent = myObj.GetComponent<Text>();
                mapNoteCurrent.transform.parent = this.transform;
                mapNoteCurrent.GetComponent<RectTransform>().anchoredPosition = pos;
                myObj.GetComponent<RectTransform>().SetSiblingIndex(4);
                MapNoteInput.textComponent = mapNoteCurrent;
                MapNoteInput.text = "";
                MapNoteInput.Select();
                break;

            case MapInteractionDelete:
                InteractionMode = MapInteractionNormal;
                UWHUD.instance.CursorIcon = UWHUD.instance.MapQuill;
                break;
            case MapInteractionWriting:
                OnNoteComplete();
                break;
        }
    }

    /// <summary>
    /// Saves the note when player has completed writing
    /// </summary>
    public void OnNoteComplete()
    {
        InteractionMode = MapInteractionNormal;
        if (MapNoteInput.text.TrimEnd() == "")
        {//destroy the text box as nothing has been created
            Destroy(mapNoteCurrent.gameObject);
        }
        else
        {
            //System.Guid guid = System.Guid.NewGuid();
            MapNote newmapnote = new MapNote((int)pos.x, (int)(pos.y + 100f), MapNoteInput.text);
            mapNoteCurrent.GetComponent<ContentSizeFitter>().horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
            GameWorldController.instance.AutoMaps[MapNo].MapNotes.Add(newmapnote);
            mapNoteCurrent.GetComponent<MapNoteId>().guid = newmapnote.guid;
        }
        InteractionMode = MapInteractionNormal;
        caretAdjustment = Vector2.zero;
        UWHUD.instance.CursorIcon = UWHUD.instance.MapQuill;
    }

    public void OnLetterType()
    {
        caretAdjustment = new Vector2(MapNoteInput.text.Length * 9f, 0f);
    }

    public override void Update()
    {
        base.Update();
        if (InteractionMode == MapInteractionWriting)
        {
            MapNoteInput.Select();
        }
    }



    /// <summary>
    /// Gets the maximum no of levels for the current world.
    /// </summary>
    /// <param name="levelNo"></param>
    /// <returns></returns>
    int MaxWorld(int levelNo)
    {
        GameWorldController.Worlds world = GameWorldController.GetWorld(levelNo);
        switch (world)
        {
            case GameWorldController.Worlds.Britannia:
                if (_RES == GAME_UW2)
                {
                    return (int)(GameWorldController.UW2_LevelNos.Britannia4);
                }
                else
                {
                    return GameWorldController.instance.AutoMaps.GetUpperBound(0);
                }
            case GameWorldController.Worlds.PrisonTower:
                return (int)(GameWorldController.UW2_LevelNos.Prison7);
            case GameWorldController.Worlds.Killorn:
                return (int)(GameWorldController.UW2_LevelNos.Killorn1);
            case GameWorldController.Worlds.Ice:
                return (int)(GameWorldController.UW2_LevelNos.Ice1);
            case GameWorldController.Worlds.Talorus:
                return (int)(GameWorldController.UW2_LevelNos.Talorus1);
            case GameWorldController.Worlds.Academy:
                return (int)(GameWorldController.UW2_LevelNos.Academy7);
            case GameWorldController.Worlds.Tomb:
                return (int)(GameWorldController.UW2_LevelNos.Tomb3);
            case GameWorldController.Worlds.Pits:
                return (int)(GameWorldController.UW2_LevelNos.Pits2);
            case GameWorldController.Worlds.Ethereal:
            //return (int)(GameWorldController.UW2_LevelNos.Ethereal8);
            default:
                return GameWorldController.instance.AutoMaps.GetUpperBound(0);
        }
    }

}
