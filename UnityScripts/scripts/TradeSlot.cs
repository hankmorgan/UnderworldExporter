using UnityEngine;
using System.Collections;

public class TradeSlot : MonoBehaviour {

	public bool PlayerSlot=false;
	public int SlotNo;
	static UWCharacter playerUW;
	static PlayerInventory pInv;
	public bool pressedDown=false;
	public string objectInSlot;
	public bool Hovering=false;
	public UITexture SlotImage;
	public bool Selected=false;
	private Texture2D Blank;
	public GameObject Indicator;
	// Use this for initialization
	void Start () {
		playerUW=GameObject.Find ("Gronk").GetComponent<UWCharacter>();
		pInv=GameObject.Find ("Gronk").GetComponent<PlayerInventory>();
		SlotImage=this.GetComponent<UITexture>();
		Blank = Resources.Load <Texture2D> ("Sprites/Texture_Blank");

		SlotImage.mainTexture=Blank;
	}
	
	// Update is called once per frame
	void Update () {
			Indicator.SetActive(isSelected ());
	}

	void PlayerSlotRightClick()
	{//Toggle selected state
		Selected = !Selected;
	}


	void PlayerSlotLeftClick()
	{
		if (playerUW!=null)
		{
			if (pInv.ObjectInHand != "")
			{
				//put the object in hand in this slot.
				if (objectInSlot=="")
				{//Empty slot
					objectInSlot=pInv.ObjectInHand;
					pInv.ObjectInHand="";
					SlotImage.mainTexture=playerUW.CursorIcon;
					playerUW.CursorIcon=playerUW.CursorIconDefault;
				}
				else
				{//Swap the objects
					string tmp;
					tmp = objectInSlot;
					objectInSlot=pInv.ObjectInHand;
					pInv.ObjectInHand=tmp;
					playerUW.CursorIcon= GameObject.Find(tmp).GetComponent<ObjectInteraction>().GetInventoryDisplay().texture;
					
				}
				
			}
			else
			{
				if (objectInSlot=="")
				{
					//Do nothing
				}
				else
				{
					//Pickup the object in the slot
					pInv.ObjectInHand=objectInSlot;
					playerUW.CursorIcon= GameObject.Find(objectInSlot).GetComponent<ObjectInteraction>().GetInventoryDisplay().texture;
					objectInSlot="";
					SlotImage.mainTexture=Blank;
				}
				
			}
		}
		//Debug.Log ("Slot " + PlayerSlot + " " + SlotNo);
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
			NPCSlotClick ();
		}

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
	//void OnDoubleClick () 
	//{
	//	Debug.Log ("Doubleclick");
	//}
}
