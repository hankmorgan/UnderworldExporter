using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TradeSlot : GuiBase {
    public static int TradeSlotUBound = 3;//5 for UW2 0,1,2,3

    public bool PlayerSlot=false;
	public int SlotNo;
	//static UWCharacter UWCharacter.Instance;
	//static PlayerInventory pInv;
	public bool pressedDown=false;
	public ObjectInteraction objectInSlot;
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
        if (_RES==GAME_UW2)
        {
            TradeSlotUBound = 5;
        }
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
	public override void Update ()
	{
		base.Update();
		if (isSelected())
		{
			Indicator.texture=IndicatorSelected;
		}
		else
		{
			Indicator.texture=Blank;
		}
		if (objectInSlot==null)
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
        ObjectInteraction objIntAtSlot = GetGameObjectInteraction();
        if (CurrentObjectInHand != null)
		{
			//put the object in hand in this slot.
			if (objectInSlot==null)
			{//Empty slot
				//GameObject objToMove = UWCharacter.Instance.playerInventory.GetGameObjectInHand();
				if (CurrentObjectInHand != null)
				{
					if (CurrentObjectInHand.transform.parent != GameWorldController.instance.DynamicObjectMarker())
					{//Object needs to be moved to world
							//objToMove.transform.parent= GameWorldController.instance.DynamicObjectMarker();
							GameWorldController.MoveToWorld(CurrentObjectInHand);
							ConversationVM.BuildObjectList();
					}
					objectInSlot= CurrentObjectInHand;
					CurrentObjectInHand=null;
					SlotImage.texture=UWHUD.instance.CursorIcon;
					//UWHUD.instance.CursorIcon=UWHUD.instance.CursorIconDefault;
					Selected=true;
				}
			}
			else
			{//Swap the objects
				//GameObject objInSlot = GetGameObjectInteraction().gameObject;
				//GameObject objInHand = UWCharacter.Instance.playerInventory.GetGameObjectInHand();
				if(objIntAtSlot != null)
				{
                    objIntAtSlot.transform.parent=GameWorldController.instance.InventoryMarker.transform;
					GameWorldController.MoveToInventory(objIntAtSlot);//This will call rebuild list
				}
				if (CurrentObjectInHand != null)
				{
					if (CurrentObjectInHand.transform.parent != GameWorldController.instance.DynamicObjectMarker())
					{//Object needs to be moved to world
						//objInHand.transform.parent= GameWorldController.instance.DynamicObjectMarker();
						GameWorldController.MoveToWorld(CurrentObjectInHand);						
					}	
				}
				objectInSlot= CurrentObjectInHand;
				SlotImage.texture = CurrentObjectInHand.GetInventoryDisplay().texture;
                //UWHUD.instance.CursorIcon = objInSlot.GetComponent<ObjectInteraction>().GetInventoryDisplay().texture;
                CurrentObjectInHand = objIntAtSlot;
				ConversationVM.BuildObjectList();
				Selected=true;
			}
		}
		else
		{
			if (objectInSlot!=null)
			{
				//Pickup the object in the slot
				//UWCharacter.Instance.playerInventory.SetObjectInHand(objectInSlot);
                CurrentObjectInHand = objIntAtSlot;
                //UWHUD.instance.CursorIcon= UWCharacter.Instance.playerInventory.GetGameObject(objectInSlot).GetComponent<ObjectInteraction>().GetInventoryDisplay().texture;
                objectInSlot = null;
				SlotImage.texture=Blank;
				Selected=false;
				//GameObject objToMove = UWCharacter.Instance.playerInventory.GetGameObjectInHand();
				if(CurrentObjectInHand != null)
				{
                    CurrentObjectInHand.transform.parent=GameWorldController.instance.InventoryMarker.transform;
					GameWorldController.MoveToInventory(CurrentObjectInHand);//This will call rebuild list
                    CurrentObjectInHand.GetComponent<object_base>().PickupEvent();
				}
			}
			
		}
		if (objectInSlot==null)
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
		return ((Selected==true) && (objectInSlot!=null));
	}

	public void clear()
	{
		objectInSlot=null;
		SlotImage.texture=Blank;
	}


	public int GetObjectID()
	{
		if (isSelected())
		{
			//GameObject obj = GameObject.Find (objectInSlot);
			if (objectInSlot != null)
			{
				//ObjectInteraction objInt = obj.GetComponent<ObjectInteraction>();
				//if (objInt!=null)
				//{
					return objectInSlot.item_id;
				//}
			}
		}
		return 0;
	}

	public ObjectInteraction GetGameObjectInteraction()
	{
        Debug.Log("REMOVE3");
		//GameObject obj = GameObject.Find (objectInSlot);
		//if (objectInSlot != null)
		//{
			return objectInSlot;
		//}
		//else
		//{
		//	return null;
		//}
	}
	//void OnDoubleClick () 
	//{
	//	Debug.Log ("Doubleclick");
	//}
}
