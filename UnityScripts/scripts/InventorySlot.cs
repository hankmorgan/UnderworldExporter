using UnityEngine;
using System.Collections;

public class InventorySlot : MonoBehaviour {

	private UILabel MessageLog;
	private UISprite slot;
	//public int InteractionMode;
	//public static GameObject player;
	public static UWCharacter playerUW;
	//public static GameObject currInventorySlot;
	//public GameObject ObjectInSlot;
	public string ObjectSpriteString;
	public Texture2D ObjectSprite;
	//private PlayerInventory pInv;
	public GameObject GronkSlot;
	public int slotIndex;//What index of inventory slot is this
	public int SlotCategory; //What type of item is in the slot. Eg armour, rings, boots and general etc.
	//Possible values for the below. Should tally with UWexporter defines
	public const int GeneralItems = -1;
	public const int ARMOUR =2 ;
	public const int HELM =73;
	public const int RING =74;
	public const int BOOT =75;
	public const int GLOVES =76;
	public const int LEGGINGS =77;


	private GameObject QuantityObj=null;
	// Use this for initialization
	void Start () {
		MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
//		slot = GetComponent<UISprite>();

	}
	
	void UseFromSlot()
	{
		//string ObjectName=playerUW.playerInventory.GetObjectAtSlot(slotIndex); //pInv.GetObjectAtSlot(slotIndex);

		GameObject currObj=playerUW.playerInventory.GetGameObjectAtSlot (slotIndex);

		if (currObj !=null)
		{
			//GameObject currObj = GameObject.Find (ObjectName);
			//Debug.Log("you use this " + currObj.name + " InventorySlot.UseFromSlot");
			ObjectInteraction currObjInt = currObj.GetComponent<ObjectInteraction>();
			currObjInt.Use();
		}
	}


	void LookFromSlot()
	{
		//string ObjectName= playerUW.playerInventory.GetObjectAtSlot(slotIndex);
		GameObject objLookedAt = playerUW.playerInventory.GetGameObjectAtSlot(slotIndex);

			//GameObject.Find (ObjectName);


		if (objLookedAt!=null)
		{
			if(objLookedAt.GetComponent<Readable>()!= null)
			{
				objLookedAt.GetComponent<ObjectInteraction>().Use();
			}
			else
			{
				objLookedAt.GetComponent<ObjectInteraction>().LookDescription();
			}
		}
	}

	//void OnPress (bool isPressed)
	//{
		//..if (isPressed==true)
	//{
	//		ClickEvent ();
	//	}
	//}

	void OnClick()
	{
		ClickEvent();
	}

	void ClickEvent()
	{
		bool leftClick=true;
		if (UICamera.currentTouchID == -2)
		{
			leftClick=false;
		}
		switch (UWCharacter.InteractionMode)
		{
		case UWCharacter.InteractionModeTalk://talk
			if (leftClick)
				{//Left Click
					UseFromSlot();
				}
			else 
				{//right click
					LookFromSlot();
				}
			break;
		case UWCharacter.InteractionModePickup://pickup
			if (leftClick)
			{
				LeftClickPickup();
			}
			else
			{
				RightClickPickup();
			}
			break;
		case UWCharacter.InteractionModeLook://look
			if (leftClick)
				{//Left Click
					UseFromSlot();
				}
			else 
				{//right click
					LookFromSlot();
				}
			break;
		case UWCharacter.InteractionModeAttack://attack
			if (leftClick)
				{//Left Click
					UseFromSlot();
				}
			else 
				{//right click
					LookFromSlot();
				}
			break;
		case UWCharacter.InteractionModeUse://use
			UseFromSlot ();
			break;
		case UWCharacter.InteractionModeInConversation:
			ConversationPickup(leftClick);
			break;
		}
	

	}



	void ConversationPickup(bool isLeftClick)
	{

		//Debug.Log("conversationpickup");
		//pInv = player.GetComponent<PlayerInventory>();
		string objectInSlot = playerUW.playerInventory.GetObjectAtSlot(slotIndex);
		//Check if the slot has a container first.
		if (objectInSlot!="")
		{
			GameObject objInSlot=GameObject.Find (objectInSlot)	;
			if (objInSlot.GetComponent<Container>()!=null)
			{
				objInSlot.GetComponent<Container>().OpenContainer ();
				return;
			}
		}
		//Check slot rules



		if (playerUW.playerInventory.ObjectInHand != "")
		{
			ObjectInteraction objInt = playerUW.playerInventory.GetGameObjectInHand().GetComponent<ObjectInteraction>();
			if ((SlotCategory != objInt.ItemType) && (SlotCategory!=-1))
			{//Slot is not a general use on andThis item type does not go in this slot.
				Debug.Log ("cannot pickup an " + objInt.ItemType + " in a " + SlotCategory);
				return;
			}


			//put the object in hand in this slot.
			if (objectInSlot=="")
			{//Empty slot
				playerUW.playerInventory.SetObjectAtSlot(slotIndex,  playerUW.playerInventory.ObjectInHand);
				playerUW.playerInventory.ObjectInHand="";
				playerUW.CursorIcon=playerUW.CursorIconDefault;
			}
			else
			{//Swap the objects
				GameObject objInSlot=GameObject.Find (playerUW.playerInventory.GetObjectAtSlot(slotIndex));
				playerUW.playerInventory.SwapObjects (objInSlot,slotIndex, playerUW.playerInventory.ObjectInHand);
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
				playerUW.playerInventory.ObjectInHand=objectInSlot;
				playerUW.CursorIcon= GameObject.Find( playerUW.playerInventory.ObjectInHand).GetComponent<ObjectInteraction>().GetInventoryDisplay().texture;
				//objectInSlot="";
				if (this.slotIndex>=11)
				{
					Container cn = GameObject.Find( playerUW.playerInventory.currentContainer).GetComponent<Container>();
					cn.RemoveItemFromContainer( playerUW.playerInventory.ContainerOffset+this.slotIndex-11);
				}
				playerUW.playerInventory.ClearSlot(this.slotIndex);
			}
			
		}

		playerUW.playerInventory.Refresh ();
	}



	void LeftClickPickup()
	{//Code for when I left click in pickup mode

		//pInv = player.GetComponent<PlayerInventory>();
		GameObject ObjectUsedOn=null;
		bool DoNotPickup=false;
		if ( playerUW.playerInventory.ObjectInHand !="")
			{ 
			ObjectInteraction objInt =playerUW.playerInventory.GetGameObjectInHand().GetComponent<ObjectInteraction>();
			if ((SlotCategory != objInt.ItemType) && (SlotCategory!=-1))
				{//Slot is not a general use on andThis item type does not go in this slot.
					Debug.Log ("cannot pickup an " + objInt.ItemType + " in a " + SlotCategory);
					DoNotPickup=true;
				}
				
				if ((objInt.isQuant==true) && (objInt.isEnchanted==false))
					{
					ObjectUsedOn = GameObject.Find (playerUW.playerInventory.GetObjectAtSlot(slotIndex));
					if (ObjectUsedOn !=null)
						{
						if (objInt.item_id==ObjectUsedOn.GetComponent<ObjectInteraction>().item_id)
							{
								//merge the items
								ObjectUsedOn.GetComponent<ObjectInteraction>().Link=ObjectUsedOn.GetComponent<ObjectInteraction>().Link+objInt.Link;
								playerUW.CursorIcon= playerUW.CursorIconDefault;
								playerUW.playerInventory.ObjectInHand="";
								Destroy(objInt.gameObject);
								return;
							}
						}
					}
			}

		if (playerUW.playerInventory.GetObjectAtSlot(slotIndex)=="")//No object in slot
			{
			if (DoNotPickup==false)	
				{
				playerUW.playerInventory.SetObjectAtSlot(slotIndex,playerUW.playerInventory.ObjectInHand);
				playerUW.CursorIcon= playerUW.CursorIconDefault;
				playerUW.playerInventory.ObjectInHand="";
				}
			//PickupFromSlot();
			}
		else
			{
			//Get the object at the slot and test it's activation.
			ObjectUsedOn = playerUW.playerInventory.GetGameObjectAtSlot(slotIndex);//GameObject.Find (pInv.GetObjectAtSlot(slotIndex));
			if (ObjectUsedOn.GetComponent<ObjectInteraction>().Use()==false)
				{//if nothing happened when I clicked on the object at the slot.
				if (playerUW.playerInventory.ObjectInHand != "")
						{
						//TODO: Make sure this works with Equipment slots
						//No effect occurred. Swap the two objects.
					if (DoNotPickup==false)
						{
						playerUW.playerInventory.SwapObjects(ObjectUsedOn,slotIndex,playerUW.playerInventory.ObjectInHand);
						}
					}
					else
						{//Pick up the item at that slot.
						//TODO: Make this work with Equipment slots
						playerUW.playerInventory.ObjectInHand= ObjectUsedOn.name;
						playerUW.CursorIcon= ObjectUsedOn.GetComponent<ObjectInteraction>().GetInventoryDisplay().texture;
						//playerUW.CurrObjectSprite = ObjectUsedOn.GetComponent<ObjectInteraction>().InventoryString;
						if (this.slotIndex>=11)
							{
							Container cn = GameObject.Find(playerUW.playerInventory.currentContainer).GetComponent<Container>();
							cn.RemoveItemFromContainer(playerUW.playerInventory.ContainerOffset+this.slotIndex-11);
							}
						playerUW.playerInventory.ClearSlot(this.slotIndex);
					}
				}
			}
	}


	void RightClickPickup()
	{	
		//pInv = player.GetComponent<PlayerInventory>();
		GameObject ObjectUsedOn=null;//The object at the clicked slot
		bool DoNotPickup=false;
		if (playerUW.playerInventory.ObjectInHand !="")
		{
			ObjectInteraction objInt = playerUW.playerInventory.GetGameObjectInHand ().GetComponent<ObjectInteraction>();
			if ((SlotCategory != objInt.ItemType) && (SlotCategory!=-1))
			{//Slot is not a general use on andThis item type does not go in this slot.
				Debug.Log ("cannot pickup an " + objInt.ItemType + " in a " + SlotCategory);
				DoNotPickup=true;
			}
			if ((objInt.isQuant==true) && (objInt.isEnchanted==false))
			{
				ObjectUsedOn = playerUW.playerInventory.GetGameObjectAtSlot(slotIndex);//GameObject.Find (pInv.GetObjectAtSlot(slotIndex));
				if (ObjectUsedOn !=null)
				{
					if (objInt.item_id==ObjectUsedOn.GetComponent<ObjectInteraction>().item_id)
					{
						//merge the items
						ObjectUsedOn.GetComponent<ObjectInteraction>().Link=ObjectUsedOn.GetComponent<ObjectInteraction>().Link+objInt.Link;
						playerUW.CursorIcon= playerUW.CursorIconDefault;
						playerUW.playerInventory.ObjectInHand="";
						Destroy(objInt.gameObject);
						return;
					}
				}
			}
		}
		//Code for when I right click in pickup mode.
		if (playerUW.playerInventory.GetObjectAtSlot(slotIndex) !="")
			{//Special case for opening containers in pickup mode.
				ObjectUsedOn = playerUW.playerInventory.GetGameObjectAtSlot(slotIndex);
				if ((playerUW.playerInventory.ObjectInHand==""))
				{
					if (ObjectUsedOn.GetComponent<Container>() !=null)
					{
						playerUW.playerInventory.ObjectInHand= ObjectUsedOn.name;
						playerUW.CursorIcon= ObjectUsedOn.GetComponent<ObjectInteraction>().GetInventoryDisplay().texture;
						if (this.slotIndex>=11)
						{
						//Container cn = //;GameObject.Find(pInv.currentContainer).GetComponent<Container>();
						playerUW.playerInventory.GetCurrentContainer().RemoveItemFromContainer(playerUW.playerInventory.ContainerOffset+this.slotIndex-11);
						}
						playerUW.playerInventory.ClearSlot(this.slotIndex);
						return;
					}
				}
			}

		if (playerUW.playerInventory.GetObjectAtSlot(slotIndex)=="")//No object in slot
			{
			if (DoNotPickup==false)
				{
				playerUW.playerInventory.SetObjectAtSlot(slotIndex,playerUW.playerInventory.ObjectInHand);
				playerUW.CursorIcon= playerUW.CursorIconDefault;
				playerUW.playerInventory.SetObjectInHand("");// .ObjectInHand="";
				}
			}
		else
			{
			bool ObjectActivated =false;
			//Get the object at the slot and test it's activation.
			ObjectUsedOn = playerUW.playerInventory.GetGameObjectAtSlot(slotIndex);//GameObject.Find (pInv.GetObjectAtSlot(slotIndex));
			//When right clicking only try to activate when an object in in the hand
			if (playerUW.playerInventory.GetObjectInHand() !="")
				{
				ObjectActivated = ObjectUsedOn.GetComponent<ObjectInteraction>().Use();
				}
			if (ObjectActivated==false)
				{//if nothing happened when I clicked on the object at the slot with something in hand.
				if (playerUW.playerInventory.GetObjectInHand() != "")
					{
						if (DoNotPickup==false)
							{
							//TODO: Make sure this works with Equipment slots
							//No effect occurred. Swap the two objects.
							playerUW.playerInventory.SwapObjects(ObjectUsedOn,slotIndex,playerUW.playerInventory.ObjectInHand);
							playerUW.playerInventory.Refresh();
							}
					}
					else
					{//Pick up the item at that slot.
					//TODO: Make this work with Equipment slots
					if (DoNotPickup==false)
						{
						if ((ObjectUsedOn.GetComponent<ObjectInteraction>().isQuant ==false) || ((ObjectUsedOn.GetComponent<ObjectInteraction>().isQuant)&&(ObjectUsedOn.GetComponent<ObjectInteraction>().Link==1)) || (ObjectUsedOn.GetComponent<ObjectInteraction>().isEnchanted ==true))
							{//Is either not a quant or is a quantity of 1
							playerUW.playerInventory.ObjectInHand= ObjectUsedOn.name;
							playerUW.CursorIcon= ObjectUsedOn.GetComponent<ObjectInteraction>().GetInventoryDisplay().texture;
							if (this.slotIndex>=11)
							{

								playerUW.playerInventory.GetCurrentContainer().RemoveItemFromContainer(playerUW.playerInventory.ContainerOffset+this.slotIndex-11);
								//Container cn = GameObject.Find(pInv.currentContainer).GetComponent<Container>();
								//cn.RemoveItemFromContainer(pInv.ContainerOffset+this.slotIndex-11);
							}
							playerUW.playerInventory.ClearSlot(this.slotIndex);
							}
						else
							{
							Debug.Log("attempting to pick up a quantity");
							UIInput inputctrl =MessageLog.gameObject.GetComponent<UIInput>();
							inputctrl.eventReceiver=this.gameObject;
							inputctrl.type=UIInput.KeyboardType.NumberPad;
							inputctrl.selected=true;
							WindowDetect.WaitingForInput=true;
							Time.timeScale=0.0f;
							QuantityObj=ObjectUsedOn;
							}
						}						
					}
				}
			}
	}


	public void OnSubmitPickup()
	{
		WindowDetect.WaitingForInput=false;
		Time.timeScale=1.0f;

		Debug.Log ("Value summited to slot");
		//PlayerInventory pInv = player.GetComponent<PlayerInventory>();
		UIInput inputctrl =MessageLog.gameObject.GetComponent<UIInput>();
		Debug.Log (inputctrl.text);
		int quant= int.Parse(inputctrl.text);
		if (quant==0)
		{//cancel
			QuantityObj=null;
		}
		if (QuantityObj!=null)
		{//Just do a normal pickup.
			if (quant >= QuantityObj.GetComponent<ObjectInteraction>().Link)
			{
				playerUW.playerInventory.ObjectInHand= QuantityObj.name;
				playerUW.CursorIcon= QuantityObj.GetComponent<ObjectInteraction>().GetInventoryDisplay().texture;
				if (this.slotIndex>=11)
				{
					playerUW.playerInventory.GetCurrentContainer().RemoveItemFromContainer(playerUW.playerInventory.ContainerOffset+this.slotIndex-11);
					//Container cn = GameObject.Find(pInv.currentContainer).GetComponent<Container>();
					//cn.RemoveItemFromContainer(pInv.ContainerOffset+this.slotIndex-11);
				}
				playerUW.playerInventory.ClearSlot(this.slotIndex);
			}
			else
			{
				//split the obj. Do nothing to the inventory.
				GameObject Split = Instantiate(QuantityObj);//What we are picking up.
				Split.GetComponent<ObjectInteraction>().Link =quant;
				Split.name = Split.name+"_"+playerUW.summonCount++;
				Split.transform.parent=this.transform.parent;
				QuantityObj.GetComponent<ObjectInteraction>().Link=QuantityObj.GetComponent<ObjectInteraction>().Link-quant;
				playerUW.playerInventory.ObjectInHand= Split.name;
				playerUW.CursorIcon= Split.GetComponent<ObjectInteraction>().GetInventoryDisplay().texture;
				QuantityObj=null;//Clear out to avoid weirdness.
			}
		}
	}


//	void OpenRuneBag()
//	{
		//chains chainControl = GameObject.Find ("Chain").GetComponent<chains>();
		//if (chainControl!=null)
		//{
//		chains.ActiveControl=2;
			//chainControl.ActiveControl=2;
		//}
//	}
}
