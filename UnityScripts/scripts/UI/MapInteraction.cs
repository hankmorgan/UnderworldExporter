using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MapInteraction : GuiBase {
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

		public void MapClose()
		{
			WindowDetect.InMap=false;

			if  (GameWorldController.instance.mus!=null)
			{
					GameWorldController.instance.mus.InMap=false;
			}
			chains.ActiveControl=0;
			UWHUD.instance.ChainsControl.Refresh();
			UWHUD.instance.CursorIcon = UWHUD.instance.CursorIconDefault;
		}

		public void MapUp()
		{
				if (MapNo>0)	
				{
					MapNo--;
					UpdateMap(MapNo);
				}	
		}

		public void MapDown()
		{//Actually increases the map number!
				if (MapNo<8)	
				{
					MapNo++;
					UpdateMap(MapNo);
				}
		}

		private void UpdateMap(int LevelNo)
		{
			WindowDetect.InMap=true;//turns on blocking collider.
			UWHUD.instance.MapDisplay.texture=GameWorldController.instance.Tilemap.TileMapImage(LevelNo);
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
						pos = pos + new Vector2 (370.0f, -20.0f);
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
					System.Guid guid = System.Guid.NewGuid();
					MapNote newmapnote = new MapNote();
					newmapnote.NotePosition=pos;
					newmapnote.NoteText= MapNoteInput.text;
					newmapnote.guid=guid;
					mapNoteCurrent.GetComponent<ContentSizeFitter>().horizontalFit= ContentSizeFitter.FitMode.PreferredSize;
					//mapNoteCurrent.GetComponent<ContentSizeFitter>().SetLayoutHorizontal();
					GameWorldController.instance.Tilemap.MapNotes[MapNo].Add(newmapnote);
					mapNoteCurrent.GetComponent<MapNoteId>().guid= guid;								
				}
				InteractionMode=MapInteractionNormal;
				caretAdjustment= Vector2.zero;
				UWHUD.instance.CursorIcon=UWHUD.instance.MapQuill;
		}

		public void OnLetterType()
		{
			caretAdjustment = new Vector2(MapNoteInput.text.Length* 9f,0f);
		}

		void Update()
		{
				//Debug.Log(InteractionMode);
				if (InteractionMode==MapInteractionWriting)
				{
						MapNoteInput.Select();
				}
		}

}
