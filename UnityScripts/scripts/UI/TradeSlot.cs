using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TradeSlot : GuiBase {

	public bool PlayerSlot=false;
	public int SlotNo;
	//static UWCharacter UWCharacter.Instance;
	//static PlayerInventory pInv;
	public bool pressedDown=false;
	public string objectInSlot;
	public bool Hovering=false;
	public RawImage SlotImage;
	public bool Selected=false;
	private Texture2D Blank;
	private Texture2D IndicatorSelected;
	public RawImage Indicator;
	public Text Quantity;
	public static bool LookingAt;
	public static string TempLookAt;

		/// <summary>
		/// Stop the player from taking items out of the tradeslots
		/// </summary>
		public static bool Locked;

	public override void Start()
	{
		base.Start();
		SlotImage=this.GetComponent<RawImage>();
		Blank = Resources.Load <Texture2D> (_RES +"/Sprites/Texture_Blank");
		//IndicatorSelected = Resources.Load<Texture2D>(_RES +"/HUD/Cursors/cursors_0018");
				switch (_RES)
				{
				case GAME_UW1:
						IndicatorSelected = GameWorldController.instance.grCursors.LoadImageAt(18);
						break;
				default:
						IndicatorSelected= GameWorldController.instance.grCursors.LoadImageAt(0);//TODO: find out the correct one to use
						break;
				}
		
		SlotImage.texture=Blank;
		Quantity.text="";
		Indicator.texture=Blank;
	}
	
	// Update is called once per frame
	void Update () {
		if (isSelected())
		{
			Indicator.texture=IndicatorSelected;
		}
		else
		{
			Indicator.texture=Blank;
		}
		if (objectInSlot=="")
		{
			Quantity.text="";
		}
	}
	
	public void PlayerSlotRightClick()
	{//Toggle selected state
		//Make this look description
		//Selected = !Selected;
		if (LookingAt==true)
		{return;}//Only look at one thing at a time.
		if (TradeSlot.Locked){return;}
		ObjectInteraction objInt= GetGameObjectInteraction();
		if (objInt!=null)
		{
			TradeSlot.LookingAt=true;
			//UWHUD.instance.MessageScroll.SetAnchorX(1.0f);//Move off screen.
			TradeSlot.TempLookAt=UWHUD.instance.MessageScroll.NewUIOUt.text;
			//UWHUD.instance.MessageScrollTemp.SetAnchorX(0.06f);
			StartCoroutine(ClearTempLookAt());
			//UWHUD.instance.MessageScrollTemp.Set (StringController.instance.GetFormattedObjectNameUW(objInt));
		}
	}

	IEnumerator ClearTempLookAt()
	{
		Time.timeScale=0.1f;
		yield return new WaitForSeconds(0.1f);
		TradeSlot.LookingAt=false;
		if (ConversationVM.InConversation==true)
		{
			Time.timeScale=0.00f;
		}
		else
		{
			Time.timeScale=1.0f;//just in case a conversations is ended while looking.
		}
				UWHUD.instance.MessageScroll.NewUIOUt.text=TradeSlot.TempLookAt;
		//UWHUD.instance.MessageScroll.SetAnchorX(0.06f);
		//UWHUD.instance.MessageScrollTemp.SetAnchorX(1.00f);
		//UWHUD.instance.MessageScrollTemp.Set("");
	}

	public void PlayerSlotLeftClick()
	{
		if (TradeSlot.Locked){return;}
		if (UWCharacter.Instance.playerInventory.ObjectInHand != "")
		{
			//put the object in hand in this slot.
			if (objectInSlot=="")
			{//Empty slot
				objectInSlot=UWCharacter.Instance.playerInventory.ObjectInHand;
				UWCharacter.Instance.playerInventory.ObjectInHand="";
				SlotImage.texture=UWHUD.instance.CursorIcon;
				UWHUD.instance.CursorIcon=UWHUD.instance.CursorIconDefault;
				Selected=true;
			}
			else
			{//Swap the objects
				string tmp;
				tmp = objectInSlot;
				objectInSlot=UWCharacter.Instance.playerInventory.ObjectInHand;
				UWCharacter.Instance.playerInventory.ObjectInHand=tmp;
				UWHUD.instance.CursorIcon= UWCharacter.Instance.playerInventory.GetGameObject(tmp).GetComponent<ObjectInteraction>().GetInventoryDisplay().texture;
				Selected=true;
			}
		}
		else
		{
			if (objectInSlot!="")
			{
				//Pickup the object in the slot
				UWCharacter.Instance.playerInventory.SetObjectInHand(objectInSlot);
				UWHUD.instance.CursorIcon= UWCharacter.Instance.playerInventory.GetGameObject(objectInSlot).GetComponent<ObjectInteraction>().GetInventoryDisplay().texture;
				objectInSlot="";
				SlotImage.texture=Blank;
				Selected=false;
			}
			
		}
		if (objectInSlot=="")
		{
			Quantity.text="";
		}
		else
		{
			int qty= GetGameObjectInteraction().GetQty();
			if (qty<=1)
			{
				Quantity.text="";
			}
			else
			{
				Quantity.text=qty.ToString();
			}
		}

	}


	public void NPCSlotClick()
	{
		Selected=!Selected;
	}


		public void OnClick(BaseEventData evnt)
		{
				PointerEventData pntr = (PointerEventData)evnt;
				//Debug.Log (pnt.pointerId);
				ClickEvent(pntr.pointerId);
		}

	public void ClickEvent(int ptrID)
	{
		//Left click pickup
		//right click toggle.
		//On hover identify?
		if (TradeSlot.Locked){return;}
		if (PlayerSlot==true)
		{
			if (ptrID == -2)//right click
			{
				PlayerSlotRightClick ();
			}
			else
			{
				PlayerSlotLeftClick ();
			}
		}
		else
		{
			if (ptrID == -2)//right click
			{
				PlayerSlotRightClick ();
			}
			else
			{
				NPCSlotClick();
			}
		}
		UWCharacter.Instance.playerInventory.Refresh ();
	}

	public bool isSelected()
	{//is it a selected slot with an item in it.
		return ((Selected==true) && (objectInSlot!=""));
	}

	public void clear()
	{
		objectInSlot="";
		SlotImage.texture=Blank;
	}


	public int GetObjectID()
	{
		if (isSelected())
		{
			GameObject obj = GameObject.Find (objectInSlot);
			if (obj!=null)
			{
				ObjectInteraction objInt = obj.GetComponent<ObjectInteraction>();
				if (objInt!=null)
				{
					return objInt.item_id;
				}
			}
		}
		return 0;
	}

	public ObjectInteraction GetGameObjectInteraction()
	{
		GameObject obj = GameObject.Find (objectInSlot);
		if (obj!=null)
		{
			return obj.GetComponent<ObjectInteraction>();
		}
		else
		{
			return null;
		}
	}
	//void OnDoubleClick () 
	//{
	//	Debug.Log ("Doubleclick");
	//}
}
