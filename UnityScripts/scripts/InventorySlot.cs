using UnityEngine;
using System.Collections;

public class InventorySlot : MonoBehaviour {

	private UILabel MessageLog;
	private UISprite slot;
	//public int InteractionMode;
	public static GameObject player;
	public static UWCharacter playerUW;
	//public static GameObject currInventorySlot;
	//public GameObject ObjectInSlot;
	public string ObjectSpriteString;
	public Texture2D ObjectSprite;
	private PlayerInventory pInv;
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
	
	// Update is called once per frame
	//void Update () {
		//if (playerUW==null)
		//{
		//	playerUW=player.GetComponent<UWCharacter>();
		//}
	//}



	//void OnMouseEnter()
	//{
	//	MessageLog.text=name +"entered";
	//}
	
	//void OnTriggerEnter()
	//{
	//	//counter++;
	//	MessageLog.text=name +"triggered";
	//}
	
//	void OnHover( bool isOver )
//	{
//		if( isOver )
//		{
//			InventorySlot.currInventorySlot=this.gameObject;
//		//	playerUW.currInventorySlot=this.gameObject;
//			//MessageLog.text=name + "Hovered over";
//		}
//		else
//		{
//			InventorySlot.currInventorySlot=null;
//			//playerUW.currInventorySlot=null;
//			//MessageLog.text=name + "Hovered out";
//		}
//	}

	/*
	void PickupFromSlot()
	{
		//Debug.Log ("PickupfromSlot");
		pInv = player.GetComponent<PlayerInventory>();
		Container SubContainer;
		string sNewObj;
		
		if (pInv.currentContainer=="Gronk")
		{
			sNewObj= pInv.ObjectPickedUp(slotIndex,pInv.ObjectInHand);
		}
		else
		{
			string slotToTest= pInv.GetObjectAtSlot(slotIndex) ;
			if (slotToTest!="")
			{
				Debug.Log ("Testing slot (" + slotIndex + ")" + slotToTest );
				
				if (GameObject.Find (slotToTest).GetComponent<ObjectInteraction>().isContainer==true)
				{
					//test if object is already open in inventory;
					if (GameObject.Find (slotToTest).GetComponent<Container>().isOpenOnPanel==true)
					{
						Debug.Log ("Attempt to to pick up an already open container at " + slotToTest);
						return;
					}
				}
			}

			SubContainer = GameObject.Find (pInv.currentContainer).GetComponent<Container>();

			if (slotIndex >=11)
			{
			Container TestContainer = GameObject.Find (pInv.ObjectInHand).GetComponent<Container>();
				if (TestContainer != null)
				{
					if (TestContainer.name == pInv.currentContainer)
					{
						Debug.Log ("Cannot add a container to itself");
						return;
					}
				}
			}

			sNewObj = SubContainer.ObjectPickedUp (slotIndex,pInv.ObjectInHand);
		}
		
		if (sNewObj=="")
		{
			playerUW.CursorIcon= playerUW.CursorIconDefault;
			playerUW.CurrObjectSprite = "";
			pInv.ObjectInHand="";
		}
		else
		{
			GameObject NewObj ;
			NewObj = GameObject.Find (sNewObj);
			if (NewObj != null)
			{
				playerUW.CursorIcon= NewObj.GetComponent<ObjectInteraction>().InventoryIcon.texture;
				playerUW.CurrObjectSprite = NewObj.GetComponent<ObjectInteraction>().InventoryString;
				pInv.ObjectInHand=sNewObj;
			}
			else
			{
				Debug.Log ("unable to find " + sNewObj);
				playerUW.CursorIcon= playerUW.CursorIconDefault;
				playerUW.CurrObjectSprite = "";
				pInv.ObjectInHand="";
			}
			
		}
	}



*/




	void UseFromSlot()
	{
		//Debug.Log ("UseFromSlot");
		pInv = player.GetComponent<PlayerInventory>();
		string ObjectName= pInv.GetObjectAtSlot(slotIndex);
		if (ObjectName !="")
		{
			GameObject currObj = GameObject.Find (ObjectName);
			//Debug.Log("you use this " + currObj.name + " InventorySlot.UseFromSlot");
			ObjectInteraction currObjInt = currObj.GetComponent<ObjectInteraction>();
			//TODO move this code to objinteract.activate()
			/*if (currObjInt.isContainer)
			{//Use a container
				if (pInv.ObjectInHand == "")
				{
					OpenContainer (currObj, currObjInt);
				}
				else
				{
					currObjInt.Activate();
					//pInv.InteractTwoObjects(pInv.ObjectInHand,ObjectName,slotIndex);
				}
				return;
			}*/

			/*
			if (currObjInt.isRuneBag)
			{//Use a rune bag
				if (pInv.ObjectInHand == "")
				{
					OpenRuneBag();
				}
				else
				{
					PickupFromSlot();
				}
				return;
			}
			*/


			currObjInt.Use();
			//use an object. change the cursor
			///if (currObjInt.Use()==false)
			//{
			//	playerUW.CursorIcon= currObj.GetComponent<ObjectInteraction>().InventoryIcon.texture;
			//	playerUW.CurrObjectSprite = currObj.GetComponent<ObjectInteraction>().InventoryString;
			//	pInv.ObjectInHand=ObjectName;
			//}
		}
	}


	void LookFromSlot()
	{
		Debug.Log ("LookFromSlot");
		pInv = player.GetComponent<PlayerInventory>();
		string ObjectName= pInv.GetObjectAtSlot(slotIndex);
		GameObject objLookedAt = GameObject.Find (ObjectName);
		//if (ObjectName !="")
		//{
		//If object has a readable component then activate(and read) otherwise give a generic description.
		if(objLookedAt.GetComponent<Readable>()!= null)
			{
			objLookedAt.GetComponent<ObjectInteraction>().Use();
			}
		else
			{
			//MessageLog.text="You see a " + pInv.GetObjectDescAtSlot(slotIndex);
			objLookedAt.GetComponent<ObjectInteraction>().LookDescription();
			}

			//MessageLog.text="You see a " + ObjectName;
		//}
		//	return;
	}

	void OnClick()
	{
		//Debug.Log(this.name + " clicked");
		bool leftClick=true;
		//Debug.Log (UICamera.currentTouchID);
		if (UICamera.currentTouchID == -2)
		{
			leftClick=false;
		}
		//PlayerInventory pInv = player.GetComponent<PlayerInventory>();
		//Container SubContainer;
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
		}
	

	}


	void LeftClickPickup()
	{//Code for when I left click in pickup mode

		pInv = player.GetComponent<PlayerInventory>();
		GameObject ObjectUsedOn=null;
		bool DoNotPickup=false;
		if (pInv.ObjectInHand !="")
			{
			ObjectInteraction objInt = GameObject.Find (pInv.ObjectInHand).GetComponent<ObjectInteraction>();
			if ((SlotCategory != objInt.ItemType) && (SlotCategory!=-1))
				{//Slot is not a general use on andThis item type does not go in this slot.
					Debug.Log ("cannot pickup an " + objInt.ItemType + " in a " + SlotCategory);
					DoNotPickup=true;
				}
				
				if (objInt.isQuant==true)
					{
					ObjectUsedOn = GameObject.Find (pInv.GetObjectAtSlot(slotIndex));
					if (ObjectUsedOn !=null)
						{
						if (objInt.item_id==ObjectUsedOn.GetComponent<ObjectInteraction>().item_id)
							{
								//merge the items
								ObjectUsedOn.GetComponent<ObjectInteraction>().Link=ObjectUsedOn.GetComponent<ObjectInteraction>().Link+objInt.Link;
								playerUW.CursorIcon= playerUW.CursorIconDefault;
								pInv.ObjectInHand="";
								Destroy(objInt.gameObject);
								return;
							}
						}
					}
			}

		if (pInv.GetObjectAtSlot(slotIndex)=="")//No object in slot
			{
			if (DoNotPickup==false)	
				{
				pInv.SetObjectAtSlot(slotIndex,pInv.ObjectInHand);
				playerUW.CursorIcon= playerUW.CursorIconDefault;
				pInv.ObjectInHand="";
				}
			//PickupFromSlot();
			}
		else
			{
			//Get the object at the slot and test it's activation.
			ObjectUsedOn = GameObject.Find (pInv.GetObjectAtSlot(slotIndex));
			if (ObjectUsedOn.GetComponent<ObjectInteraction>().Use()==false)
				{//if nothing happened when I clicked on the object at the slot.
					if (pInv.ObjectInHand != "")
						{
						//TODO: Make sure this works with Equipment slots
						//No effect occurred. Swap the two objects.
					if (DoNotPickup==false)
						{
						pInv.SwapObjects(ObjectUsedOn,slotIndex,pInv.ObjectInHand);
						}
					}
					else
						{//Pick up the item at that slot.
						//TODO: Make this work with Equipment slots
						pInv.ObjectInHand= ObjectUsedOn.name;
						playerUW.CursorIcon= ObjectUsedOn.GetComponent<ObjectInteraction>().GetInventoryDisplay().texture;
						//playerUW.CurrObjectSprite = ObjectUsedOn.GetComponent<ObjectInteraction>().InventoryString;
						if (this.slotIndex>=11)
							{
							Container cn = GameObject.Find(pInv.currentContainer).GetComponent<Container>();
							cn.RemoveItemFromContainer(pInv.ContainerOffset+this.slotIndex-11);
							}
						pInv.ClearSlot(this.slotIndex);
					}
				}
			}
	}


	void RightClickPickup()
	{	
		pInv = player.GetComponent<PlayerInventory>();
		GameObject ObjectUsedOn=null;//The object at the clicked slot
		bool DoNotPickup=false;
		if (pInv.ObjectInHand !="")
		{
			ObjectInteraction objInt = GameObject.Find (pInv.ObjectInHand).GetComponent<ObjectInteraction>();
			if ((SlotCategory != objInt.ItemType) && (SlotCategory!=-1))
			{//Slot is not a general use on andThis item type does not go in this slot.
				Debug.Log ("cannot pickup an " + objInt.ItemType + " in a " + SlotCategory);
				DoNotPickup=true;
			}
			if (objInt.isQuant==true)
			{
				ObjectUsedOn = GameObject.Find (pInv.GetObjectAtSlot(slotIndex));
				if (ObjectUsedOn !=null)
				{
					if (objInt.item_id==ObjectUsedOn.GetComponent<ObjectInteraction>().item_id)
					{
						//merge the items
						ObjectUsedOn.GetComponent<ObjectInteraction>().Link=ObjectUsedOn.GetComponent<ObjectInteraction>().Link+objInt.Link;
						playerUW.CursorIcon= playerUW.CursorIconDefault;
						pInv.ObjectInHand="";
						Destroy(objInt.gameObject);
						return;
					}
				}
			}
		}
		//Code for when I right click in pickup mode.
		if (pInv.GetObjectAtSlot(slotIndex) !="")
			{//Special case for opening containers in pickup mode.
				ObjectUsedOn = GameObject.Find (pInv.GetObjectAtSlot(slotIndex));
				if ((pInv.ObjectInHand==""))
				{
					if (ObjectUsedOn.GetComponent<Container>() !=null)
					{
						pInv.ObjectInHand= ObjectUsedOn.name;
						playerUW.CursorIcon= ObjectUsedOn.GetComponent<ObjectInteraction>().GetInventoryDisplay().texture;
						//playerUW.CurrObjectSprite = ObjectUsedOn.GetComponent<ObjectInteraction>().InventoryString;
						if (this.slotIndex>=11)
						{
							Container cn = GameObject.Find(pInv.currentContainer).GetComponent<Container>();
							cn.RemoveItemFromContainer(pInv.ContainerOffset+this.slotIndex-11);
						}
						pInv.ClearSlot(this.slotIndex);
						return;
					}
				}
			}

		if (pInv.GetObjectAtSlot(slotIndex)=="")//No object in slot
			{
			if (DoNotPickup==false)
				{
				pInv.SetObjectAtSlot(slotIndex,pInv.ObjectInHand);
				playerUW.CursorIcon= playerUW.CursorIconDefault;
				pInv.ObjectInHand="";
				}
			}
		else
			{
			bool ObjectActivated =false;
			//Get the object at the slot and test it's activation.
			ObjectUsedOn = GameObject.Find (pInv.GetObjectAtSlot(slotIndex));
			//When right clicking only try to activate when an object in in the hand
			if (pInv.ObjectInHand !="")
				{
				ObjectActivated = ObjectUsedOn.GetComponent<ObjectInteraction>().Use();
				}
			if (ObjectActivated==false)
				{//if nothing happened when I clicked on the object at the slot with something in hand.
					if (pInv.ObjectInHand != "")
					{
						if (DoNotPickup==false)
							{
							//TODO: Make sure this works with Equipment slots
							//No effect occurred. Swap the two objects.
							pInv.SwapObjects(ObjectUsedOn,slotIndex,pInv.ObjectInHand);
							pInv.Refresh();
							}
					}
					else
					{//Pick up the item at that slot.
					//TODO: Make this work with Equipment slots
					if (DoNotPickup==false)
						{
						if ((ObjectUsedOn.GetComponent<ObjectInteraction>().isQuant ==false) || ((ObjectUsedOn.GetComponent<ObjectInteraction>().isQuant)&&(ObjectUsedOn.GetComponent<ObjectInteraction>().Link==1)))
							{//Is either not a quant or is a quantity of 1
							pInv.ObjectInHand= ObjectUsedOn.name;
							playerUW.CursorIcon= ObjectUsedOn.GetComponent<ObjectInteraction>().GetInventoryDisplay().texture;
							if (this.slotIndex>=11)
							{
								Container cn = GameObject.Find(pInv.currentContainer).GetComponent<Container>();
								cn.RemoveItemFromContainer(pInv.ContainerOffset+this.slotIndex-11);
							}
							pInv.ClearSlot(this.slotIndex);
							}
						else
							{
							Debug.Log("attempting to pick up a quantity");
							UIInput inputctrl =MessageLog.gameObject.GetComponent<UIInput>();
							inputctrl.eventReceiver=this.gameObject;
							inputctrl.selected=true;
							QuantityObj=ObjectUsedOn;
							}
						}						
					}
				}
			}
	}


	public void OnSubmitPickup()
	{
		
		Debug.Log ("Value summited to slot");
		PlayerInventory pInv = player.GetComponent<PlayerInventory>();
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
				pInv.ObjectInHand= QuantityObj.name;
				playerUW.CursorIcon= QuantityObj.GetComponent<ObjectInteraction>().GetInventoryDisplay().texture;
				if (this.slotIndex>=11)
				{
					Container cn = GameObject.Find(pInv.currentContainer).GetComponent<Container>();
					cn.RemoveItemFromContainer(pInv.ContainerOffset+this.slotIndex-11);
				}
				pInv.ClearSlot(this.slotIndex);
			}
			else
			{
				//split the obj. Do nothing to the inventory.
				GameObject Split = Instantiate(QuantityObj);//What we are picking up.
				Split.GetComponent<ObjectInteraction>().Link =quant;
				Split.name = Split.name+"_"+playerUW.summonCount++;
				Split.transform.parent=this.transform.parent;
				QuantityObj.GetComponent<ObjectInteraction>().Link=QuantityObj.GetComponent<ObjectInteraction>().Link-quant;
				pInv.ObjectInHand= Split.name;
				playerUW.CursorIcon= Split.GetComponent<ObjectInteraction>().GetInventoryDisplay().texture;
				QuantityObj=null;//Clear out to avoid weirdness.
			}
		}
	}


	void OpenRuneBag()
	{
		//chains chainControl = GameObject.Find ("Chain").GetComponent<chains>();
		//if (chainControl!=null)
		//{
		chains.ActiveControl=2;
			//chainControl.ActiveControl=2;
		//}
	}

//	void OnClick()
//	{
	
		//MessageLog.text=  name + "clicked1";
//		if (playerUW.CurrObjectSprite!="")
//		{//Player is holding something.
//			if (ObjectInSlot ==null)
//			{
				//There is nothing in the slot
//				slot.spriteName=playerUW.CurrObjectSprite;
//				ObjectInSlot=playerUW.ObjectInHand;
//				playerUW.currInventorySlot=null;
//				playerUW.CurrObjectSprite=null;
//				playerUW.CursorIcon=playerUW.CursorIconDefault;
//			}
//			else
//			{
				//There is something in the slot ->swap it 
//			}

//		}


//		MessageLog.text=  name + "clicked";
//	}

	/**
	public static bool InteractTwoObjects(string sObjectInHand, string sObjectUsedOn,int slotIndex)
	{//How slots act when objects are used on them.
		PlayerInventory pinv = playerUW.gameObject.GetComponent<PlayerInventory>();
		//Debug.Log ("Interacting " + sObjectInHand + " and " + sObjectUsedOn);
		//returns true if they have an effect on each other.
		if ((sObjectInHand !="") && (sObjectUsedOn !=""))
		{//Object is being used on something.
			GameObject objInHand= GameObject.Find (sObjectInHand);
			GameObject objUseOn = GameObject.Find (sObjectUsedOn);
			if(objUseOn.GetComponent<ObjectInteraction>() ==null)
			{//Object has no interaction component.
				pinv.ObjectInHand="";
				playerUW.CursorIcon= playerUW.CursorIconDefault;
				playerUW.CurrObjectSprite = "";
				return false;
			}
			else
			{//Object has an interaction. activate it.
				return objUseOn.GetComponent<ObjectInteraction>().Activate();

			}
		}
		else
		{//Object is just being placed in a slot. 
			if (sObjectInHand!="")
			{
				GameObject objInHand= GameObject.Find (sObjectInHand);
				//Container subContainer = objUseOn.GetComponent<Container>();
				if (objInHand.GetComponent<ObjectInteraction>().isContainer)
				{
					//PlayerInventory pInv = GameObject.Find ("Gronk").GetComponent<PlayerInventory>();
					Container subContainer=objInHand.GetComponent<Container>();
					if (slotIndex >=11)
					{//Object is being added to a bag container
						subContainer.ContainerParent=pinv.currentContainer;
					}
					else
					{//object is being added to an equipment slot
						subContainer.ContainerParent="Gronk";
					}
					
				}
			}
			return false;
		}
	}
	*/
}
