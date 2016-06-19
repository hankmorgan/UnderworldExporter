using UnityEngine;
using System.Collections;

public class TradeSlot : GuiBase {

	public bool PlayerSlot=false;
	public int SlotNo;
	//static UWCharacter playerUW;
	//static PlayerInventory pInv;
	public bool pressedDown=false;
	public string objectInSlot;
	public bool Hovering=false;
	public UITexture SlotImage;
	public bool Selected=false;
	private Texture2D Blank;
	private Texture2D IndicatorSelected;
	public UITexture Indicator;
	public UILabel Quantity;
	public static bool LookingAt;
	// Use this for initialization
	void Start () {
		//playerUW=GameObject.Find ("Gronk").GetComponent<UWCharacter>();
		//pInv=GameObject.Find ("Gronk").GetComponent<PlayerInventory>();
		SlotImage=this.GetComponent<UITexture>();
		Blank = Resources.Load <Texture2D> ("Sprites/Texture_Blank");
		IndicatorSelected = Resources.Load<Texture2D>("HUD/Cursors/cursors_0018");
		SlotImage.mainTexture=Blank;
		Quantity.text="";
		Indicator.mainTexture=Blank;
	}
	
	// Update is called once per frame
	void Update () {
		//Indicator.SetActive(isSelected ());
		if (isSelected())
		{
			Indicator.mainTexture=IndicatorSelected;
		}
		else
		{
			Indicator.mainTexture=Blank;
		}
		if (objectInSlot=="")
		{
			Quantity.text="";
		}
	}
	
	void PlayerSlotRightClick()
	{//Toggle selected state
		//Make this look description
		//Selected = !Selected;
		if (LookingAt==true)
		{return;}//Only look at one thing at a time.

		ObjectInteraction objInt= GetGameObjectInteraction();
		if (objInt!=null)
		{
			LookingAt=true;
			playerUW.playerHud.MessageScroll.SetAnchorX(1.0f);//Move off screen.
			playerUW.playerHud.MessageScrollTemp.SetAnchorX(0.06f);
			StartCoroutine(ClearTempLookAt());
			playerUW.playerHud.MessageScrollTemp.Set (playerUW.StringControl.GetFormattedObjectNameUW(objInt));
		}
	}

	IEnumerator ClearTempLookAt()
	{
		Time.timeScale=0.1f;
		yield return new WaitForSeconds(0.1f);
		LookingAt=false;
		if (Conversation.InConversation==true)
		{
			Time.timeScale=0.00f;
		}
		else
		{
			Time.timeScale=1.0f;//just in case a conversations is ended while looking.
		}

		playerUW.playerHud.MessageScroll.SetAnchorX(0.06f);
		playerUW.playerHud.MessageScrollTemp.SetAnchorX(1.00f);
		playerUW.playerHud.MessageScrollTemp.Set("");
	}

	void PlayerSlotLeftClick()
	{
		if (playerUW.playerInventory.ObjectInHand != "")
		{
			//put the object in hand in this slot.
			if (objectInSlot=="")
			{//Empty slot
				objectInSlot=playerUW.playerInventory.ObjectInHand;
				playerUW.playerInventory.ObjectInHand="";
				SlotImage.mainTexture=playerUW.CursorIcon;
				playerUW.CursorIcon=playerUW.CursorIconDefault;
				Selected=true;
			}
			else
			{//Swap the objects
				string tmp;
				tmp = objectInSlot;
				objectInSlot=playerUW.playerInventory.ObjectInHand;
				playerUW.playerInventory.ObjectInHand=tmp;
				playerUW.CursorIcon= playerUW.playerInventory.GetGameObject(tmp).GetComponent<ObjectInteraction>().GetInventoryDisplay().texture;
				Selected=true;
			}
		}
		else
		{
			if (objectInSlot!="")
			{
				//Pickup the object in the slot
				playerUW.playerInventory.SetObjectInHand(objectInSlot);
				playerUW.CursorIcon= playerUW.playerInventory.GetGameObject(objectInSlot).GetComponent<ObjectInteraction>().GetInventoryDisplay().texture;
				objectInSlot="";
				SlotImage.mainTexture=Blank;
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


	void NPCSlotClick()
	{
		Selected=!Selected;
	}


	void OnClick()
	{
		//Left click pickup
		//right click toggle.
		//On hover identify?
		if (PlayerSlot==true)
		{
			if (UICamera.currentTouchID == -2)//right click
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
			if (UICamera.currentTouchID == -2)//right click
			{
				PlayerSlotRightClick ();
			}
			else
			{
				NPCSlotClick();
			}
		}
		playerUW.playerInventory.Refresh ();
	}

	public bool isSelected()
	{//is it a selected slot with an item in it.
		return ((Selected==true) && (objectInSlot!=""));
	}

	public void clear()
	{
		objectInSlot="";
		SlotImage.mainTexture=Blank;
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
