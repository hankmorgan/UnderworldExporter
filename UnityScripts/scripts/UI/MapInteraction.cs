using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MapInteraction : GuiBase {
    
        //Index of the first level no for a world
        public enum Worlds
        {
            Britannia = 0,
            PrisonTower = 8,
            Killorn = 16,
            Ice = 24,
            Talorus = 32,
            Academy = 40,
            Tomb = 48,
            Pits = 56,
            Ethereal = 64
        };

     public MapWorldSelect[] MapSelectButtons = new MapWorldSelect[9];

        public const int MapInteractionNormal=0;
		public const int MapInteractionDelete=1;
		public const int MapInteractionWriting=2;
		public static int MapNo;//Current Map being displayed
		public static Vector2 caretAdjustment= Vector2.zero;
		private Text mapNoteCurrent;
		public InputField MapNoteInput;
		private Vector2 pos;
		public static Vector2 CursorPos; //at start of typing
		public static int InteractionMode; //0 = normal. 1 = delete note. 2 =writing
        public Worlds CurrentWorld = Worlds.Britannia;   //What world we are in.  

        public static MapInteraction instance;

    private GRLoader gempt;

    private void Awake()
        {
        instance = this;
        if (gempt == null)
        {
            gempt = new GRLoader(GRLoader.GEMPT_GR, 3);
        }
        for (int i = 0; i <= MapSelectButtons.GetUpperBound(0); i++)
        {
            if (MapSelectButtons[i] != null)
            {
                switch (MapSelectButtons[i].world)
                {
                    case Worlds.Britannia:
                        MapSelectButtons[i].ButtonOff = GRLoader.CreateBlankImage(29, 29);
                        MapSelectButtons[i].ButtonOn = gempt.LoadImageAt(16);
                        break;
                    case Worlds.PrisonTower:
                        MapSelectButtons[i].ButtonOff = gempt.LoadImageAt(0);
                        MapSelectButtons[i].ButtonOn = gempt.LoadImageAt(8);
                        break;
                    case Worlds.Killorn:
                        MapSelectButtons[i].ButtonOff = gempt.LoadImageAt(1);
                        MapSelectButtons[i].ButtonOn = gempt.LoadImageAt(9);
                        break;
                    case Worlds.Ice:
                        MapSelectButtons[i].ButtonOff = gempt.LoadImageAt(2);
                        MapSelectButtons[i].ButtonOn = gempt.LoadImageAt(10);
                        break;
                    case Worlds.Talorus:
                        MapSelectButtons[i].ButtonOff = gempt.LoadImageAt(3);
                        MapSelectButtons[i].ButtonOn = gempt.LoadImageAt(11);
                        break;
                    case Worlds.Academy:
                        MapSelectButtons[i].ButtonOff = gempt.LoadImageAt(4);
                        MapSelectButtons[i].ButtonOn = gempt.LoadImageAt(12);
                        break;
                    case Worlds.Pits:
                        MapSelectButtons[i].ButtonOff = gempt.LoadImageAt(6);
                        MapSelectButtons[i].ButtonOn = gempt.LoadImageAt(14);
                        break;
                    case Worlds.Tomb:
                        MapSelectButtons[i].ButtonOff = gempt.LoadImageAt(5);
                        MapSelectButtons[i].ButtonOn = gempt.LoadImageAt(13);
                        break;
                    case Worlds.Ethereal:
                        MapSelectButtons[i].ButtonOff = gempt.LoadImageAt(7);
                        MapSelectButtons[i].ButtonOn = gempt.LoadImageAt(15);
                        break;
                }
            }
        }
     }
    
    public void MapClose()
		{
			WindowDetect.InMap=false;
			UWCharacter.Instance.playerMotor.jumping.enabled=true;
			InventorySlot.Hovering=false;
			if  (GameWorldController.instance.getMus()!=null)
			{
			GameWorldController.instance.getMus().InMap=false;
			}
			UWHUD.instance.RefreshPanels(UWHUD.HUD_MODE_INVENTORY);
			UWHUD.instance.CursorIcon = UWHUD.instance.CursorIconDefault;
		}

		public void MapUp()
		{            
			if (MapNo>0)	
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
			if (MapNo<GameWorldController.instance.AutoMaps.GetUpperBound(0))	
			{
                if (MapNo< MaxWorld(MapNo))
                    {
                    MapNo++;
                    UpdateMap(MapNo);
                    }
			}
		}

		/// <summary>
		/// Updates the map.
		/// </summary>
		/// <param name="LevelNo">Level no.</param>
		public static void UpdateMap(int LevelNo)
		{
			WindowDetect.InMap=true;//turns on blocking collider.
            instance.CurrentWorld = MapInteraction.GetWorld(LevelNo);
        ///Sets the map no display
        // UWHUD.instance.LevelNoDisplay.text = ((LevelNo + 1) - instance.CurrentWorld).ToString();
        UWHUD.instance.LevelNoDisplay.text = (1+(LevelNo-(int)instance.CurrentWorld)).ToString() + " " + instance.CurrentWorld;
        if (_RES==GAME_UW2)
            {
                for (int i=0; i<= instance.MapSelectButtons.GetUpperBound(0);i++)
                {
                    if (instance.MapSelectButtons[i]!=null)
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
			UWHUD.instance.MapDisplay.texture=GameWorldController.instance.AutoMaps[MapInteraction.MapNo].TileMapImage();

			///Display the map notes
			///Delete the map notes in memory
			foreach(Transform child in UWHUD.instance.MapPanel.transform)
			{
				if (child.name.Substring(0,4) == "_Map")
				{								
					GameObject.Destroy(child.transform.gameObject);
				}
			}
			if (GameWorldController.instance.AutoMaps[MapInteraction.MapNo]!=null)
			{
				if (GameWorldController.instance.AutoMaps[MapInteraction.MapNo].MapNotes!=null)
				{
					for (int i=0 ; i < GameWorldController.instance.AutoMaps[MapInteraction.MapNo].MapNotes.Count;i++)
					{///Instantiates the map note template UI control.
						GameObject myObj = (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/_MapNoteTemplate"));
						myObj.name = "_Map-Note Number " + i;
						myObj.transform.parent= UWHUD.instance.MapPanel.transform;
						myObj.GetComponent<Text>().text = GameWorldController.instance.AutoMaps[MapInteraction.MapNo].MapNotes[i].NoteText;
						myObj.GetComponent<RectTransform>().anchoredPosition= GameWorldController.instance.AutoMaps[MapInteraction.MapNo].MapNotes[i].NotePosition();
						myObj.GetComponent<MapNoteId>().guid = GameWorldController.instance.AutoMaps[MapInteraction.MapNo].MapNotes[i].guid;
						//Move the control so that it sits in front of the map,
						myObj.GetComponent<RectTransform>().SetSiblingIndex(4);
					}		
				}					
			}
		}

		public void ClickEraser()
		{
				if (InteractionMode==MapInteractionNormal)	
				{
						InteractionMode=MapInteractionDelete;
						UWHUD.instance.CursorIcon=UWHUD.instance.MapEraser;
				}
				else
				{
						InteractionMode=MapInteractionNormal;
						UWHUD.instance.CursorIcon=UWHUD.instance.MapQuill;
				}
		}

		public void OnClick(BaseEventData evnt)
		{
				switch (InteractionMode)
				{
				case MapInteractionNormal:
						InteractionMode=MapInteractionWriting;
						UWHUD.instance.CursorIcon=UWHUD.instance.MapQuillWriting;

						pos = Vector2.zero;
						RectTransform rect = this.GetComponent<RectTransform>();
						PointerEventData pntr = (PointerEventData)evnt;		
						CursorPos=UWHUD.instance.window.CursorPosition.center;//pntr.pressPosition;
						RectTransformUtility.ScreenPointToLocalPointInRectangle(rect,pntr.pressPosition,pntr.pressEventCamera, out pos);
						pos = pos + new Vector2 (150.0f, -4.0f);
						GameObject myObj = (GameObject)Instantiate(Resources.Load("Prefabs/_MapNoteTemplate"));
						mapNoteCurrent=myObj.GetComponent<Text>();
						mapNoteCurrent.transform.parent=this.transform;
						mapNoteCurrent.GetComponent<RectTransform>().anchoredPosition=pos;
						myObj.GetComponent<RectTransform>().SetSiblingIndex(4);
						MapNoteInput.textComponent= mapNoteCurrent;
						MapNoteInput.text="";	
						MapNoteInput.Select();
						break;

				case MapInteractionDelete:
						InteractionMode=MapInteractionNormal;
						UWHUD.instance.CursorIcon=UWHUD.instance.MapQuill;							
						break;
				case MapInteractionWriting:
						OnNoteComplete();
						break;
				}		
		}

		public void OnNoteComplete()
		{
				InteractionMode=MapInteractionNormal;
				if (MapNoteInput.text.TrimEnd()=="")
				{//destroy the text box as nothing has been created
						Destroy(mapNoteCurrent.gameObject);
				}
				else
				{
					//System.Guid guid = System.Guid.NewGuid();
					MapNote newmapnote = new MapNote((int)pos.x, (int)(pos.y + 100f), MapNoteInput.text);
     //               //newmapnote.NotePosition=pos;
     //               newmapnote.PosX= (int)pos.x;
					//newmapnote.PosY= (int)(pos.y+100f);
					//newmapnote.NoteText= MapNoteInput.text;
					//newmapnote.guid=guid;
					mapNoteCurrent.GetComponent<ContentSizeFitter>().horizontalFit= ContentSizeFitter.FitMode.PreferredSize;
					//mapNoteCurrent.GetComponent<ContentSizeFitter>().SetLayoutHorizontal();
					GameWorldController.instance.AutoMaps[MapNo].MapNotes.Add(newmapnote);
					mapNoteCurrent.GetComponent<MapNoteId>().guid= newmapnote.guid;								
				}
				InteractionMode=MapInteractionNormal;
				caretAdjustment= Vector2.zero;
				UWHUD.instance.CursorIcon=UWHUD.instance.MapQuill;
		}

		public void OnLetterType()
		{
			caretAdjustment = new Vector2(MapNoteInput.text.Length* 9f,0f);
		}

		public override void Update ()
		{
			base.Update();
			if (InteractionMode==MapInteractionWriting)
			{
				MapNoteInput.Select();
			}
		}

    public static Worlds GetWorld(int levelNo)
    {
        if (_RES != GAME_UW2) { return Worlds.Britannia; }
        switch ((GameWorldController.UW2_LevelNos)levelNo)
        {
            case GameWorldController.UW2_LevelNos.Britannia0:
            case GameWorldController.UW2_LevelNos.Britannia1:
            case GameWorldController.UW2_LevelNos.Britannia2:
            case GameWorldController.UW2_LevelNos.Britannia3:
            case GameWorldController.UW2_LevelNos.Britannia4:
                return Worlds.Britannia;
            case GameWorldController.UW2_LevelNos.Prison0:
            case GameWorldController.UW2_LevelNos.Prison1:
            case GameWorldController.UW2_LevelNos.Prison2:
            case GameWorldController.UW2_LevelNos.Prison3:
            case GameWorldController.UW2_LevelNos.Prison4:
            case GameWorldController.UW2_LevelNos.Prison5:
            case GameWorldController.UW2_LevelNos.Prison6:
            case GameWorldController.UW2_LevelNos.Prison7:
                return Worlds.PrisonTower;
            case GameWorldController.UW2_LevelNos.Killorn0:
            case GameWorldController.UW2_LevelNos.Killorn1:
                return Worlds.Killorn;
            case GameWorldController.UW2_LevelNos.Ice0:
            case GameWorldController.UW2_LevelNos.Ice1:
                return Worlds.Ice;
            case GameWorldController.UW2_LevelNos.Talorus0:
            case GameWorldController.UW2_LevelNos.Talorus1:
                return Worlds.Talorus;
            case GameWorldController.UW2_LevelNos.Academy0:
            case GameWorldController.UW2_LevelNos.Academy1:
            case GameWorldController.UW2_LevelNos.Academy2:
            case GameWorldController.UW2_LevelNos.Academy3:
            case GameWorldController.UW2_LevelNos.Academy4:
            case GameWorldController.UW2_LevelNos.Academy5:
            case GameWorldController.UW2_LevelNos.Academy6:
            case GameWorldController.UW2_LevelNos.Academy7:
                return Worlds.Academy;
            case GameWorldController.UW2_LevelNos.Tomb0:
            case GameWorldController.UW2_LevelNos.Tomb1:
            case GameWorldController.UW2_LevelNos.Tomb2:
            case GameWorldController.UW2_LevelNos.Tomb3:
                return Worlds.Tomb;
            case GameWorldController.UW2_LevelNos.Pits0:
            case GameWorldController.UW2_LevelNos.Pits1:
            case GameWorldController.UW2_LevelNos.Pits2:
                return Worlds.Pits;
            case GameWorldController.UW2_LevelNos.Ethereal0:
            case GameWorldController.UW2_LevelNos.Ethereal1:
            case GameWorldController.UW2_LevelNos.Ethereal2:
            case GameWorldController.UW2_LevelNos.Ethereal3:
            case GameWorldController.UW2_LevelNos.Ethereal4:
            case GameWorldController.UW2_LevelNos.Ethereal5:
            case GameWorldController.UW2_LevelNos.Ethereal6:
            case GameWorldController.UW2_LevelNos.Ethereal7:
            case GameWorldController.UW2_LevelNos.Ethereal8:
                return Worlds.Ethereal;
            default:
                Debug.Log("Unknown level/world");
                return Worlds.Ethereal;
        }

    }

    int MaxWorld(int levelNo)
    {
        Worlds world = GetWorld(levelNo);
        switch (world)
        {
            case Worlds.Britannia:
                if (_RES==GAME_UW2)
                {
                    return (int)(GameWorldController.UW2_LevelNos.Britannia4);
                }
                else
                {
                    return GameWorldController.instance.AutoMaps.GetUpperBound(0);
                }
            case Worlds.PrisonTower:
                return (int)(GameWorldController.UW2_LevelNos.Prison7);
            case Worlds.Killorn:
                return (int)(GameWorldController.UW2_LevelNos.Killorn1);
            case Worlds.Ice:
                return (int)(GameWorldController.UW2_LevelNos.Ice1);
            case Worlds.Talorus:
                return (int)(GameWorldController.UW2_LevelNos.Talorus1);
            case Worlds.Academy:
                return (int)(GameWorldController.UW2_LevelNos.Academy7);
            case Worlds.Tomb:
                return (int)(GameWorldController.UW2_LevelNos.Tomb3);
            case Worlds.Pits:
                return (int)(GameWorldController.UW2_LevelNos.Pits2);
            case Worlds.Ethereal:
                //return (int)(GameWorldController.UW2_LevelNos.Ethereal8);
            default:
                return GameWorldController.instance.AutoMaps.GetUpperBound(0);
        }
    }

}
