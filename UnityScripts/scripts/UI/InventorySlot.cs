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
		GameObject currObj=playerUW.playerInventory.GetGameObjectAtSlot (slotIndex);

		if (currObj !=null)
		{
			ObjectInteraction currObjInt = currObj.GetComponent<ObjectInteraction>();
			currObjInt.Use();
		}
		else
		{
			if (playerUW.playerInventory.ObjectInHand!="")
			{
				playerUW.CursorIcon= playerUW.CursorIconDefault;
				playerUW.playerInventory.ObjectInHand="";
			}
		}
	}


	void LookFromSlot()
	{
		//string ObjectName= playerUW.playerInventory.GetObjectAtSlot(slotIndex);
		GameObject objLookedAt = playerUW.playerInventory.GetGameObjectAtSlot(slotIndex);

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
		if (playerUW.isRoaming==true)
		{//No inventory use while using wizard eye.
				return;
		}
		bool leftClick=true;
		if (pointerID == -2)
		{
			leftClick=false;
		}
		if (playerUW.PlayerMagic.ReadiedSpell=="")
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
			playerUW.PlayerMagic.ObjectInSlot=null;
			if (playerUW.PlayerMagic.InventorySpell==true)
				{
					playerUW.PlayerMagic.ObjectInSlot = playerUW.playerInventory.GetGameObjectAtSlot(slotIndex);
					playerUW.PlayerMagic.castSpell(this.gameObject, playerUW.PlayerMagic.ReadiedSpell,false);
					playerUW.PlayerMagic.SpellCost=0;
					playerUW.playerHud.window.UWWindowWait (1.0f);		
				}
			}
		playerUW.playerInventory.Refresh ();

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
		if ( playerUW.playerInventory.ObjectInHand !="")
			{ 
			ObjectInteraction objInt =playerUW.playerInventory.GetGameObjectInHand().GetComponent<ObjectInteraction>();
			if ((SlotCategory != objInt.ItemType) && (SlotCategory!=-1))
				{//Slot is not a general use one andThis item type does not go in this slot.
					Debug.Log ("cannot pickup an " + objInt.ItemType + " in a " + SlotCategory + " at " + this.name);
					DoNotPickup=true;
				}
				
				//if ((objInt.isQuant==true) && (objInt.isEnchanted==false))
				if (objInt.IsStackable())
					{
					ObjectUsedOn = GameObject.Find (playerUW.playerInventory.GetObjectAtSlot(slotIndex));
					if (ObjectUsedOn !=null)
						{
						if (ObjectInteraction.CanMerge(ObjectUsedOn.GetComponent<ObjectInteraction>(), objInt))
					//if ((objInt.item_id==ObjectUsedOn.GetComponent<ObjectInteraction>().item_id) && (objInt.Quality==ObjectUsedOn.GetComponent<ObjectInteraction>().Quality))
							{
							ObjectInteraction.Merge (ObjectUsedOn.GetComponent<ObjectInteraction>(), objInt);
							playerUW.CursorIcon= playerUW.CursorIconDefault;
							playerUW.playerInventory.ObjectInHand="";
							playerUW.playerInventory.Refresh (slotIndex);

								//merge the items
								/*ObjectUsedOn.GetComponent<ObjectInteraction>().Link=ObjectUsedOn.GetComponent<ObjectInteraction>().Link+objInt.Link;
								playerUW.CursorIcon= playerUW.CursorIconDefault;
								playerUW.playerInventory.ObjectInHand="";
								Destroy(objInt.gameObject);*/
								return;
							}
						}
					}
			}

		if (playerUW.playerInventory.GetObjectAtSlot(slotIndex)=="")//No object in slot
			{
			if (DoNotPickup==false)	
				{
				if (Container.TestContainerRules(playerUW.playerInventory.GetCurrentContainer(),slotIndex))
					{
						playerUW.playerInventory.SetObjectAtSlot(slotIndex,playerUW.playerInventory.ObjectInHand);
						playerUW.CursorIcon= playerUW.CursorIconDefault;
						playerUW.playerInventory.SetObjectInHand("");
					}
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
						if (Container.TestContainerRules(playerUW.playerInventory.GetCurrentContainer(),slotIndex))
							{
								playerUW.playerInventory.SwapObjects(ObjectUsedOn,slotIndex,playerUW.playerInventory.ObjectInHand);
							}
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
			//	Debug.Log ("cannot pickup an " + objInt.ItemType + " in a " + SlotCategory);
				DoNotPickup=true;
			}
			//if ((objInt.isQuant==true) && (objInt.isEnchanted==false))
			if (objInt.IsStackable())
			{
				ObjectUsedOn = playerUW.playerInventory.GetGameObjectAtSlot(slotIndex);//GameObject.Find (pInv.GetObjectAtSlot(slotIndex));
				if (ObjectUsedOn !=null)
				{
					if (ObjectInteraction.CanMerge(ObjectUsedOn.GetComponent<ObjectInteraction>(),objInt))
				//	if ((objInt.item_id==ObjectUsedOn.GetComponent<ObjectInteraction>().item_id) && (objInt.Quality==ObjectUsedOn.GetComponent<ObjectInteraction>().Quality))
					{
						//merge the items
						ObjectInteraction.Merge (ObjectUsedOn.GetComponent<ObjectInteraction>(),objInt);
						//ObjectUsedOn.GetComponent<ObjectInteraction>().Link=ObjectUsedOn.GetComponent<ObjectInteraction>().Link+objInt.Link;
						playerUW.CursorIcon= playerUW.CursorIconDefault;
						playerUW.playerInventory.ObjectInHand="";
						playerUW.playerInventory.Refresh (slotIndex);
						//Destroy(objInt.gameObject);
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
						if (ObjectUsedOn.GetComponent<Container>().isOpenOnPanel==true)
							{
								return ;
							}
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
				if (Container.TestContainerRules(playerUW.playerInventory.GetCurrentContainer(),slotIndex))
					{
						playerUW.playerInventory.SetObjectAtSlot(slotIndex,playerUW.playerInventory.ObjectInHand);
						playerUW.CursorIcon= playerUW.CursorIconDefault;
						playerUW.playerInventory.SetObjectInHand("");// .ObjectInHand="";
					}
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
						if (Container.TestContainerRules(playerUW.playerInventory.GetCurrentContainer(),slotIndex))
							{
								playerUW.playerInventory.SwapObjects(ObjectUsedOn,slotIndex,playerUW.playerInventory.ObjectInHand);
								playerUW.playerInventory.Refresh();
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
							playerUW.playerInventory.ObjectInHand= ObjectUsedOn.name;
							//playerUW.CursorIcon= ObjectUsedOn.GetComponent<ObjectInteraction>().GetInventoryDisplay().texture;
							playerUW.CursorIcon= objIntUsedOn.GetInventoryDisplay ().texture;
							if (this.slotIndex>=11)
							{
								playerUW.playerInventory.GetCurrentContainer().RemoveItemFromContainer(playerUW.playerInventory.ContainerOffset+this.slotIndex-11);
							}
							playerUW.playerInventory.ClearSlot(this.slotIndex);
							}
						else
							{
							//Debug.Log("attempting to pick up a quantity");
							if (Conversation.InConversation==true)
							{
								//playerUW.playerHud.MessageScroll.SetAnchorX(1.0f);//Move off screen.
								//playerUW.playerHud.MessageScrollTemp.SetAnchorX(0.06f);
								InventorySlot.TempLookAt=playerUW.playerHud.MessageScroll.NewUIOUt.text;
								playerUW.playerHud.MessageScroll.Set ("Move how many?");
								Conversation.EnteringQty=true;
							}
							else
							{
								playerUW.playerHud.MessageScroll.Set ("Move how many?");
							}
							//playerUW.playerHud.MessageScroll.Set ("Move how many?");
							InputField inputctrl =playerUW.playerHud.InputControl;//playerHud.MessageScroll.GetComponent<UIInput>();
							inputctrl.GetComponent<GuiBase>().SetAnchorX(0.3f);
						//	UIInput inputctrl =playerUW.playerHud.InputControl;
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
		InputField inputctrl =playerUW.playerHud.InputControl;
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
			playerUW.playerHud.MessageScroll.Clear ();
			Time.timeScale=1.0f;
		}
		else
		{
			//playerUW.playerHud.MessageScroll.SetAnchorX(0.06f);
			//playerUW.playerHud.MessageScrollTemp.SetAnchorX(1.00f);
			playerUW.playerHud.MessageScroll.Set(InventorySlot.TempLookAt);
		}

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
				}
				playerUW.playerInventory.ClearSlot(this.slotIndex);
			}
			else
			{
				//split the obj. Do nothing to the inventory.
				GameObject Split = Instantiate(QuantityObj);//What we are picking up.
				Split.GetComponent<ObjectInteraction>().Link =quant;
				Split.name = Split.name+"_"+playerUW.summonCount++;
				Split.transform.parent=playerUW.playerInventory.InventoryMarker.transform;//this.transform.parent;
				QuantityObj.GetComponent<ObjectInteraction>().Link=QuantityObj.GetComponent<ObjectInteraction>().Link-quant;
				playerUW.playerInventory.ObjectInHand= Split.name;
				playerUW.CursorIcon= Split.GetComponent<ObjectInteraction>().GetInventoryDisplay().texture;
				ObjectInteraction.Split (Split.GetComponent<ObjectInteraction>(),QuantityObj.GetComponent<ObjectInteraction>());
				playerUW.playerInventory.Refresh (slotIndex);
				QuantityObj=null;//Clear out to avoid weirdness.
			}
		}
	}

	public ObjectInteraction GetGameObjectInteration()
	{
		GameObject obj = playerUW.playerInventory.GetGameObjectAtSlot (slotIndex);
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
			//playerUW.playerHud.MessageScroll.SetAnchorX(1.0f);//Move off screen.
			//playerUW.playerHud.MessageScrollTemp.SetAnchorX(0.06f);
			InventorySlot.TempLookAt=playerUW.playerHud.MessageScroll.NewUIOUt.text;
			StartCoroutine(ClearTempLookAt());
			//playerUW.playerHud.MessageScrollTemp.Set (playerUW.StringControl.GetFormattedObjectNameUW(objInt));
			playerUW.playerHud.MessageScroll.Set(playerUW.StringControl.GetFormattedObjectNameUW(objInt));
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
		
		//playerUW.playerHud.MessageScroll.SetAnchorX(0.06f);
		//playerUW.playerHud.MessageScrollTemp.SetAnchorX(1.00f);
		playerUW.playerHud.MessageScroll.Set(InventorySlot.TempLookAt);
	}


}
