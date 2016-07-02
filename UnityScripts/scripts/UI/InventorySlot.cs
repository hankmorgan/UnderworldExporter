using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class InventorySlot : GuiBase {
/*The slots containing items on the Inventory display*/

	//private UISprite slot;
	//private RawImage slot;
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
	public static bool LookingAt;
	public static string TempLookAt;

	private GameObject QuantityObj=null;//Reference to quantity object being picked up


	void UseFromSlot()
	{
		GameObject currObj=GameWorldController.instance.playerUW.playerInventory.GetGameObjectAtSlot (slotIndex);

		if (currObj !=null)
		{
			ObjectInteraction currObjInt = currObj.GetComponent<ObjectInteraction>();
			currObjInt.Use();
		}
		else
		{
			if (GameWorldController.instance.playerUW.playerInventory.ObjectInHand!="")
			{
				GameWorldController.instance.playerUW.CursorIcon= GameWorldController.instance.playerUW.CursorIconDefault;
				GameWorldController.instance.playerUW.playerInventory.ObjectInHand="";
			}
		}
	}


	void LookFromSlot()
	{
		//string ObjectName= GameWorldController.instance.playerUW.playerInventory.GetObjectAtSlot(slotIndex);
		GameObject objLookedAt = GameWorldController.instance.playerUW.playerInventory.GetGameObjectAtSlot(slotIndex);

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

	public void OnClick(BaseEventData evnt)
	{
		PointerEventData pntr = (PointerEventData)evnt;
				//Debug.Log (pnt.pointerId);
		ClickEvent(pntr.pointerId);
	}

		void ClickEvent(int pointerID)
	{
		if (GameWorldController.instance.playerUW.isRoaming==true)
		{//No inventory use while using wizard eye.
				return;
		}
		bool leftClick=true;
		if (pointerID == -2)
		{
			leftClick=false;
		}
		if (GameWorldController.instance.playerUW.PlayerMagic.ReadiedSpell=="")
			{				
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
					ConversationClick(leftClick);
					break;
				}
			}
		else
			{
			GameWorldController.instance.playerUW.PlayerMagic.ObjectInSlot=null;
			if (GameWorldController.instance.playerUW.PlayerMagic.InventorySpell==true)
				{
					GameWorldController.instance.playerUW.PlayerMagic.ObjectInSlot = GameWorldController.instance.playerUW.playerInventory.GetGameObjectAtSlot(slotIndex);
					GameWorldController.instance.playerUW.PlayerMagic.castSpell(this.gameObject, GameWorldController.instance.playerUW.PlayerMagic.ReadiedSpell,false);
					GameWorldController.instance.playerUW.PlayerMagic.SpellCost=0;
					GameWorldController.instance.playerUW.playerHud.window.UWWindowWait (1.0f);		
				}
			}
		GameWorldController.instance.playerUW.playerInventory.Refresh ();

	}



	void ConversationClick(bool isLeftClick)
	{
		if (isLeftClick==false)
		{//Looking at object
			TemporaryLookAt();
			return;
		}
		else
		{
			RightClickPickup();
		}

		return;
	}



	void LeftClickPickup()
	{//Code for when I left click in pickup mode

		GameObject ObjectUsedOn=null;
		bool DoNotPickup=false;
		if ( GameWorldController.instance.playerUW.playerInventory.ObjectInHand !="")
			{ 
			ObjectInteraction objInt =GameWorldController.instance.playerUW.playerInventory.GetGameObjectInHand().GetComponent<ObjectInteraction>();
			if ((SlotCategory != objInt.ItemType) && (SlotCategory!=-1))
				{//Slot is not a general use one andThis item type does not go in this slot.
					Debug.Log ("cannot pickup an " + objInt.ItemType + " in a " + SlotCategory + " at " + this.name);
					DoNotPickup=true;
				}
				
				//if ((objInt.isQuant==true) && (objInt.isEnchanted==false))
				if (objInt.IsStackable())
					{
					ObjectUsedOn = GameObject.Find (GameWorldController.instance.playerUW.playerInventory.GetObjectAtSlot(slotIndex));
					if (ObjectUsedOn !=null)
						{
						if (ObjectInteraction.CanMerge(ObjectUsedOn.GetComponent<ObjectInteraction>(), objInt))
					//if ((objInt.item_id==ObjectUsedOn.GetComponent<ObjectInteraction>().item_id) && (objInt.Quality==ObjectUsedOn.GetComponent<ObjectInteraction>().Quality))
							{
							ObjectInteraction.Merge (ObjectUsedOn.GetComponent<ObjectInteraction>(), objInt);
							GameWorldController.instance.playerUW.CursorIcon= GameWorldController.instance.playerUW.CursorIconDefault;
							GameWorldController.instance.playerUW.playerInventory.ObjectInHand="";
							GameWorldController.instance.playerUW.playerInventory.Refresh (slotIndex);

								//merge the items
								/*ObjectUsedOn.GetComponent<ObjectInteraction>().Link=ObjectUsedOn.GetComponent<ObjectInteraction>().Link+objInt.Link;
								GameWorldController.instance.playerUW.CursorIcon= GameWorldController.instance.playerUW.CursorIconDefault;
								GameWorldController.instance.playerUW.playerInventory.ObjectInHand="";
								Destroy(objInt.gameObject);*/
								return;
							}
						}
					}
			}

		if (GameWorldController.instance.playerUW.playerInventory.GetObjectAtSlot(slotIndex)=="")//No object in slot
			{
			if (DoNotPickup==false)	
				{
				if (Container.TestContainerRules(GameWorldController.instance.playerUW.playerInventory.GetCurrentContainer(),slotIndex))
					{
						GameWorldController.instance.playerUW.playerInventory.SetObjectAtSlot(slotIndex,GameWorldController.instance.playerUW.playerInventory.ObjectInHand);
						GameWorldController.instance.playerUW.CursorIcon= GameWorldController.instance.playerUW.CursorIconDefault;
						GameWorldController.instance.playerUW.playerInventory.SetObjectInHand("");
					}
				}
			//PickupFromSlot();
			}
		else
			{
			//Get the object at the slot and test it's activation.
			ObjectUsedOn = GameWorldController.instance.playerUW.playerInventory.GetGameObjectAtSlot(slotIndex);//GameObject.Find (pInv.GetObjectAtSlot(slotIndex));
			if (ObjectUsedOn.GetComponent<ObjectInteraction>().Use()==false)
				{//if nothing happened when I clicked on the object at the slot.
				if (GameWorldController.instance.playerUW.playerInventory.ObjectInHand != "")
						{
						//TODO: Make sure this works with Equipment slots
						//No effect occurred. Swap the two objects.
					if (DoNotPickup==false)
						{
						if (Container.TestContainerRules(GameWorldController.instance.playerUW.playerInventory.GetCurrentContainer(),slotIndex))
							{
								GameWorldController.instance.playerUW.playerInventory.SwapObjects(ObjectUsedOn,slotIndex,GameWorldController.instance.playerUW.playerInventory.ObjectInHand);
							}
						}
					}
					else
						{//Pick up the item at that slot.
						//TODO: Make this work with Equipment slots
						GameWorldController.instance.playerUW.playerInventory.ObjectInHand= ObjectUsedOn.name;
						GameWorldController.instance.playerUW.CursorIcon= ObjectUsedOn.GetComponent<ObjectInteraction>().GetInventoryDisplay().texture;
						//GameWorldController.instance.playerUW.CurrObjectSprite = ObjectUsedOn.GetComponent<ObjectInteraction>().InventoryString;
						if (this.slotIndex>=11)
							{
							Container cn = GameObject.Find(GameWorldController.instance.playerUW.playerInventory.currentContainer).GetComponent<Container>();
							cn.RemoveItemFromContainer(GameWorldController.instance.playerUW.playerInventory.ContainerOffset+this.slotIndex-11);
							}
						GameWorldController.instance.playerUW.playerInventory.ClearSlot(this.slotIndex);
					}
				}
			}
	}


	void RightClickPickup()
	{	
		//pInv = player.GetComponent<PlayerInventory>();
		GameObject ObjectUsedOn=null;//The object at the clicked slot
		bool DoNotPickup=false;
		if (GameWorldController.instance.playerUW.playerInventory.ObjectInHand !="")
		{
			ObjectInteraction objInt = GameWorldController.instance.playerUW.playerInventory.GetGameObjectInHand ().GetComponent<ObjectInteraction>();
			if ((SlotCategory != objInt.ItemType) && (SlotCategory!=-1))
			{//Slot is not a general use on andThis item type does not go in this slot.
			//	Debug.Log ("cannot pickup an " + objInt.ItemType + " in a " + SlotCategory);
				DoNotPickup=true;
			}
			//if ((objInt.isQuant==true) && (objInt.isEnchanted==false))
			if (objInt.IsStackable())
			{
				ObjectUsedOn = GameWorldController.instance.playerUW.playerInventory.GetGameObjectAtSlot(slotIndex);//GameObject.Find (pInv.GetObjectAtSlot(slotIndex));
				if (ObjectUsedOn !=null)
				{
					if (ObjectInteraction.CanMerge(ObjectUsedOn.GetComponent<ObjectInteraction>(),objInt))
				//	if ((objInt.item_id==ObjectUsedOn.GetComponent<ObjectInteraction>().item_id) && (objInt.Quality==ObjectUsedOn.GetComponent<ObjectInteraction>().Quality))
					{
						//merge the items
						ObjectInteraction.Merge (ObjectUsedOn.GetComponent<ObjectInteraction>(),objInt);
						//ObjectUsedOn.GetComponent<ObjectInteraction>().Link=ObjectUsedOn.GetComponent<ObjectInteraction>().Link+objInt.Link;
						GameWorldController.instance.playerUW.CursorIcon= GameWorldController.instance.playerUW.CursorIconDefault;
						GameWorldController.instance.playerUW.playerInventory.ObjectInHand="";
						GameWorldController.instance.playerUW.playerInventory.Refresh (slotIndex);
						//Destroy(objInt.gameObject);
						return;
					}
				}
			}
		}
		//Code for when I right click in pickup mode.
		if (GameWorldController.instance.playerUW.playerInventory.GetObjectAtSlot(slotIndex) !="")
			{//Special case for opening containers in pickup mode.
				ObjectUsedOn = GameWorldController.instance.playerUW.playerInventory.GetGameObjectAtSlot(slotIndex);
				if ((GameWorldController.instance.playerUW.playerInventory.ObjectInHand==""))
				{
					if (ObjectUsedOn.GetComponent<Container>() !=null)
					{
						if (ObjectUsedOn.GetComponent<Container>().isOpenOnPanel==true)
							{
								return ;
							}
						GameWorldController.instance.playerUW.playerInventory.ObjectInHand= ObjectUsedOn.name;
						GameWorldController.instance.playerUW.CursorIcon= ObjectUsedOn.GetComponent<ObjectInteraction>().GetInventoryDisplay().texture;
						if (this.slotIndex>=11)
						{
						//Container cn = //;GameObject.Find(pInv.currentContainer).GetComponent<Container>();
						GameWorldController.instance.playerUW.playerInventory.GetCurrentContainer().RemoveItemFromContainer(GameWorldController.instance.playerUW.playerInventory.ContainerOffset+this.slotIndex-11);
						}
						GameWorldController.instance.playerUW.playerInventory.ClearSlot(this.slotIndex);
						return;
					}
				}
			}

		if (GameWorldController.instance.playerUW.playerInventory.GetObjectAtSlot(slotIndex)=="")//No object in slot
			{
			if (DoNotPickup==false)
				{
				if (Container.TestContainerRules(GameWorldController.instance.playerUW.playerInventory.GetCurrentContainer(),slotIndex))
					{
						GameWorldController.instance.playerUW.playerInventory.SetObjectAtSlot(slotIndex,GameWorldController.instance.playerUW.playerInventory.ObjectInHand);
						GameWorldController.instance.playerUW.CursorIcon= GameWorldController.instance.playerUW.CursorIconDefault;
						GameWorldController.instance.playerUW.playerInventory.SetObjectInHand("");// .ObjectInHand="";
					}
				}
			}
		else
			{
			bool ObjectActivated =false;
			//Get the object at the slot and test it's activation.
			ObjectUsedOn = GameWorldController.instance.playerUW.playerInventory.GetGameObjectAtSlot(slotIndex);//GameObject.Find (pInv.GetObjectAtSlot(slotIndex));
			//When right clicking only try to activate when an object in in the hand
			if (GameWorldController.instance.playerUW.playerInventory.GetObjectInHand() !="")
				{
				ObjectActivated = ObjectUsedOn.GetComponent<ObjectInteraction>().Use();
				}
			if (ObjectActivated==false)
				{//if nothing happened when I clicked on the object at the slot with something in hand.
				if (GameWorldController.instance.playerUW.playerInventory.GetObjectInHand() != "")
					{
					if (DoNotPickup==false)
						{
						//TODO: Make sure this works with Equipment slots
						//No effect occurred. Swap the two objects.
						if (Container.TestContainerRules(GameWorldController.instance.playerUW.playerInventory.GetCurrentContainer(),slotIndex))
							{
								GameWorldController.instance.playerUW.playerInventory.SwapObjects(ObjectUsedOn,slotIndex,GameWorldController.instance.playerUW.playerInventory.ObjectInHand);
								GameWorldController.instance.playerUW.playerInventory.Refresh();
							}
						}
					}
					else
					{//Pick up the item at that slot.
					//TODO: Make this work with Equipment slots
					if (DoNotPickup==false)
						{
						ObjectInteraction objIntUsedOn = ObjectUsedOn.GetComponent<ObjectInteraction>();
						//if ((ObjectUsedOn.GetComponent<ObjectInteraction>().isQuant ==false) || ((ObjectUsedOn.GetComponent<ObjectInteraction>().isQuant)&&(ObjectUsedOn.GetComponent<ObjectInteraction>().Link==1)) || (ObjectUsedOn.GetComponent<ObjectInteraction>().isEnchanted ==true))
						if ((!objIntUsedOn.IsStackable()) || ( (objIntUsedOn.IsStackable()) &&  (objIntUsedOn.GetQty()==1)))
							{//Is either not a quant or is a quantity of 1
							GameWorldController.instance.playerUW.playerInventory.ObjectInHand= ObjectUsedOn.name;
							//GameWorldController.instance.playerUW.CursorIcon= ObjectUsedOn.GetComponent<ObjectInteraction>().GetInventoryDisplay().texture;
							GameWorldController.instance.playerUW.CursorIcon= objIntUsedOn.GetInventoryDisplay ().texture;
							if (this.slotIndex>=11)
							{
								GameWorldController.instance.playerUW.playerInventory.GetCurrentContainer().RemoveItemFromContainer(GameWorldController.instance.playerUW.playerInventory.ContainerOffset+this.slotIndex-11);
							}
							GameWorldController.instance.playerUW.playerInventory.ClearSlot(this.slotIndex);
							}
						else
							{
							//Debug.Log("attempting to pick up a quantity");
							if (Conversation.InConversation==true)
							{
								//GameWorldController.instance.playerUW.playerHud.MessageScroll.SetAnchorX(1.0f);//Move off screen.
								//GameWorldController.instance.playerUW.playerHud.MessageScrollTemp.SetAnchorX(0.06f);
								InventorySlot.TempLookAt=GameWorldController.instance.playerUW.playerHud.MessageScroll.NewUIOUt.text;
								GameWorldController.instance.playerUW.playerHud.MessageScroll.Set ("Move how many?");
								Conversation.EnteringQty=true;
							}
							else
							{
								GameWorldController.instance.playerUW.playerHud.MessageScroll.Set ("Move how many?");
							}
							//GameWorldController.instance.playerUW.playerHud.MessageScroll.Set ("Move how many?");
							InputField inputctrl =GameWorldController.instance.playerUW.playerHud.InputControl;//playerHud.MessageScroll.GetComponent<UIInput>();
							inputctrl.GetComponent<GuiBase>().SetAnchorX(0.3f);
						//	UIInput inputctrl =GameWorldController.instance.playerUW.playerHud.InputControl;
							inputctrl.text="1";
														//TODO: Fix me inputctrl.label.text="1";
														//TODO: Fix me inputctrl.eventReceiver=this.gameObject;
							//inputctrl.onEndEdit.RemoveAllListeners();
							//inputctrl.onEndEdit.AddListener(delegate {
							//		this.OnSubmitPickup();	
							//} );

							inputctrl.gameObject.GetComponent<InputHandler>().target=this.gameObject;
							inputctrl.gameObject.GetComponent<InputHandler>().currentInputMode=InputHandler.InputInventoryQty;

							inputctrl.contentType= InputField.ContentType.IntegerNumber;

														//TODO: Fix me inputctrl.type=UIInput.KeyboardType.NumberPad;
														//TODO: Fix me inputctrl.selected=true;
							inputctrl.Select();
							WindowDetect.WaitingForInput=true;
							Time.timeScale=0.0f;
							QuantityObj=ObjectUsedOn;
							}
						}						
					}
				}
			}
	}


	public void OnSubmitPickup(int quant)
	{
		//Debug.Log ("Value summited to slot");
		//PlayerInventory pInv = player.GetComponent<PlayerInventory>();
		InputField inputctrl =GameWorldController.instance.playerUW.playerHud.InputControl;
		//Debug.Log (inputctrl.text);
		/*int quant=0;
		if (int.TryParse(inputctrl.text,out quant)==false)
		{
			quant=0;
		}*/
		inputctrl.text="";
		inputctrl.text="";
		WindowDetect.WaitingForInput=false;
		Conversation.EnteringQty=false;
		if (Conversation.InConversation==false)
		{
			GameWorldController.instance.playerUW.playerHud.MessageScroll.Clear ();
			Time.timeScale=1.0f;
		}
		else
		{
			//GameWorldController.instance.playerUW.playerHud.MessageScroll.SetAnchorX(0.06f);
			//GameWorldController.instance.playerUW.playerHud.MessageScrollTemp.SetAnchorX(1.00f);
			GameWorldController.instance.playerUW.playerHud.MessageScroll.Set(InventorySlot.TempLookAt);
		}

		if (quant==0)
		{//cancel
			QuantityObj=null;
		}
		if (QuantityObj!=null)
		{//Just do a normal pickup.
			if (quant >= QuantityObj.GetComponent<ObjectInteraction>().Link)
			{
				GameWorldController.instance.playerUW.playerInventory.ObjectInHand= QuantityObj.name;
				GameWorldController.instance.playerUW.CursorIcon= QuantityObj.GetComponent<ObjectInteraction>().GetInventoryDisplay().texture;
				if (this.slotIndex>=11)
				{
					GameWorldController.instance.playerUW.playerInventory.GetCurrentContainer().RemoveItemFromContainer(GameWorldController.instance.playerUW.playerInventory.ContainerOffset+this.slotIndex-11);
				}
				GameWorldController.instance.playerUW.playerInventory.ClearSlot(this.slotIndex);
			}
			else
			{
				//split the obj. Do nothing to the inventory.
				GameObject Split = Instantiate(QuantityObj);//What we are picking up.
				Split.GetComponent<ObjectInteraction>().Link =quant;
				Split.name = Split.name+"_"+GameWorldController.instance.playerUW.summonCount++;
				Split.transform.parent=GameWorldController.instance.playerUW.playerInventory.InventoryMarker.transform;//this.transform.parent;
				QuantityObj.GetComponent<ObjectInteraction>().Link=QuantityObj.GetComponent<ObjectInteraction>().Link-quant;
				GameWorldController.instance.playerUW.playerInventory.ObjectInHand= Split.name;
				GameWorldController.instance.playerUW.CursorIcon= Split.GetComponent<ObjectInteraction>().GetInventoryDisplay().texture;
				ObjectInteraction.Split (Split.GetComponent<ObjectInteraction>(),QuantityObj.GetComponent<ObjectInteraction>());
				GameWorldController.instance.playerUW.playerInventory.Refresh (slotIndex);
				QuantityObj=null;//Clear out to avoid weirdness.
			}
		}
	}

	public ObjectInteraction GetGameObjectInteration()
	{
		GameObject obj = GameWorldController.instance.playerUW.playerInventory.GetGameObjectAtSlot (slotIndex);
		if (obj!=null)
		{
			return obj.GetComponent<ObjectInteraction>();
		}
		else
		{
			return null;
		}
	}


	void TemporaryLookAt()
	{/*For looking at items temporarily in conversations where I need to restore the original log text*/
		if (InventorySlot.LookingAt==true)
		{return;}//Only look at one thing at a time.
		
		ObjectInteraction objInt= GetGameObjectInteration();
		if (objInt!=null)
		{
			InventorySlot.LookingAt=true;
			//GameWorldController.instance.playerUW.playerHud.MessageScroll.SetAnchorX(1.0f);//Move off screen.
			//GameWorldController.instance.playerUW.playerHud.MessageScrollTemp.SetAnchorX(0.06f);
			InventorySlot.TempLookAt=GameWorldController.instance.playerUW.playerHud.MessageScroll.NewUIOUt.text;
			StartCoroutine(ClearTempLookAt());
			//GameWorldController.instance.playerUW.playerHud.MessageScrollTemp.Set (GameWorldController.instance.playerUW.StringControl.GetFormattedObjectNameUW(objInt));
			GameWorldController.instance.playerUW.playerHud.MessageScroll.Set(GameWorldController.instance.playerUW.StringControl.GetFormattedObjectNameUW(objInt));
		}
	}
	
	IEnumerator ClearTempLookAt()
	{

		Time.timeScale=0.1f;
		yield return new WaitForSeconds(0.1f);
		
		InventorySlot.LookingAt=false;
		if (Conversation.InConversation==true)
		{
			Time.timeScale=0.00f;
		}
		else
		{
			Time.timeScale=1.0f;//just in case a conversation is ended while looking.
		}
		
		//GameWorldController.instance.playerUW.playerHud.MessageScroll.SetAnchorX(0.06f);
		//GameWorldController.instance.playerUW.playerHud.MessageScrollTemp.SetAnchorX(1.00f);
		GameWorldController.instance.playerUW.playerHud.MessageScroll.Set(InventorySlot.TempLookAt);
	}


}
