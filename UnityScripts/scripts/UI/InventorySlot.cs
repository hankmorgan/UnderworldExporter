using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class InventorySlot : GuiBase
{
    /*The slots containing items on the Inventory display*/

    //private UISprite slot;
    //private RawImage slot;
    public short slotIndex;//What index of inventory slot is this
    public short SlotCategory; //What type of item is in the slot. Eg armour, rings, boots and general etc.
                               //Possible values for the below. Should tally with UWexporter defines
    public const int GeneralItems = -1;
    public const int ARMOUR = 2;
    public const int HELM = 73;
    public const int RING = 74;
    public const int BOOT = 75;
    public const int GLOVES = 76;
    public const int LEGGINGS = 77;
    public static bool LookingAt;
    public static string TempLookAt;
    //private int InteractionModeValue;
    private ObjectInteraction QuantityObj = null;//Reference to quantity object being picked up
    public static bool Hovering;

    public void BeginDrag()
    {
        if ((UWCharacter.Instance.isRoaming == true) || (Quest.instance.InDreamWorld) || (UWCharacter.InteractionMode == UWCharacter.InteractionModeOptions))
        {//No inventory use
            return;
        }
        if (CurrentObjectInHand == null)
        {
            //InteractionModeValue=UWCharacter.InteractionMode;
            UWCharacter.InteractionMode = UWCharacter.InteractionModePickup;
            InteractionModeControl.UpdateNow = true;
            ClickEvent(-2);
        }
    }

    void UseFromSlot()
    {
        ObjectInteraction currObj = UWCharacter.Instance.playerInventory.GetObjectIntAtSlot(slotIndex);

        if (currObj != null)
        {
            //ObjectInteraction currObjInt = currObj.GetComponent<ObjectInteraction>();
            //currObjInt.Use();
            currObj.Use();

        }
        else
        {
            if (CurrentObjectInHand != null)
            {
                //UWHUD.instance.CursorIcon= UWHUD.instance.CursorIconDefault;
                CurrentObjectInHand = null;
            }
        }
    }


    void LookFromSlot()
    {
        //string ObjectName= UWCharacter.Instance.playerInventory.GetObjectAtSlot(slotIndex);
        ObjectInteraction objLookedAt = UWCharacter.Instance.playerInventory.GetObjectIntAtSlot(slotIndex);

        if (objLookedAt != null)
        {
            if (objLookedAt.GetComponent<Readable>() != null)
            {
                objLookedAt.GetComponent<Readable>().Read();
            }
            else
            {
                objLookedAt.LookDescription();
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
        if ((UWCharacter.Instance.isRoaming == true) || (Quest.instance.InDreamWorld) || (UWCharacter.InteractionMode == UWCharacter.InteractionModeOptions))
        {//No inventory use while using wizard eye.
            return;
        }
        bool leftClick = true;
        if (pointerID == -2)
        {
            leftClick = false;
        }
        if (UWCharacter.Instance.PlayerMagic.ReadiedSpell == "")
        {
            /*if ((WindowDetect.ContextUIEnabled) && (WindowDetect.ContextUIUse))
            {
                    switch (UWCharacter.InteractionMode)
                    {
                    case UWCharacter.InteractionModeUse:
                            //Do nothing
                            if (!leftClick)
                            {//Pickup

                            }
                    case UWCharacter.InteractionModePickup:
                    }
            }*/

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
                    if ((WindowDetect.ContextUIEnabled) && (WindowDetect.ContextUIUse))
                    {
                        if ((leftClick) || (CurrentObjectInHand != null))
                        {
                            UseFromSlot();
                        }
                        else
                        {
                            RightClickPickup();
                            UWCharacter.InteractionMode = UWCharacter.InteractionModePickup;
                            InteractionModeControl.UpdateNow = true;
                        }
                    }
                    else
                    {
                        UseFromSlot();
                    }

                    break;
                case UWCharacter.InteractionModeInConversation:
                    ConversationClick(leftClick);
                    break;
            }
        }
        else
        {
            UWCharacter.Instance.PlayerMagic.ObjectInSlot = null;
            if (UWCharacter.Instance.PlayerMagic.InventorySpell == true)
            {
                UWCharacter.Instance.PlayerMagic.ObjectInSlot = UWCharacter.Instance.playerInventory.GetObjectIntAtSlot(slotIndex);
                UWCharacter.Instance.PlayerMagic.castSpell(this.gameObject, UWCharacter.Instance.PlayerMagic.ReadiedSpell, false);
                UWCharacter.Instance.PlayerMagic.SpellCost = 0;
                UWHUD.instance.window.UWWindowWait(1.0f);
            }
        }
       //HREE UWCharacter.Instance.playerInventory.Refresh();

    }



    void ConversationClick(bool isLeftClick)
    {
        if (isLeftClick == false)
        {//Looking at object

            ObjectInteraction currObj = UWCharacter.Instance.playerInventory.GetObjectIntAtSlot(slotIndex);

            if (currObj != null)
            {
                if (currObj.GetComponent<Container>() != null)
                {
                    currObj.GetComponent<Container>().OpenContainer();
                    return;
                }
            }

            //TemporaryLookAt();
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

        ObjectInteraction ObjectUsedOn = UWCharacter.Instance.playerInventory.GetObjectIntAtSlot(slotIndex);
        bool DoNotPickup = false;
        if (CurrentObjectInHand != null)
        {
            //ObjectInteraction objInt =CurrentObjectInHand;
            //Eating food dropped in helm slot
            if (SlotCategory == HELM)
            {
                if (CurrentObjectInHand.GetItemType() == ObjectInteraction.FOOD)
                {
                    CurrentObjectInHand.Use();
                    DoNotPickup = true;
                    return;
                }
            }

            if ((SlotCategory != CurrentObjectInHand.GetItemType()) && (SlotCategory != -1))
            {//Slot is not a general use one andThis item type does not go in this slot.
             //Debug.Log ("cannot pickup an " + objInt.GetItemType() + " in a " + SlotCategory + " at " + this.name);
                DoNotPickup = true;
            }

            if (CurrentObjectInHand.IsStackable())
            {
                //ObjectUsedOn = UWCharacter.Instance.playerInventory.GetObjectIntAtSlot(slotIndex);
                if (ObjectUsedOn != null)
                {
                    if (ObjectInteraction.CanMerge(ObjectUsedOn, CurrentObjectInHand))
                    {
                        ObjectInteraction.Merge(ObjectUsedOn, CurrentObjectInHand);
                        //UWHUD.instance.CursorIcon= UWHUD.instance.CursorIconDefault;
                        CurrentObjectInHand = null;
                        UWCharacter.Instance.playerInventory.Refresh();
                        return;
                    }
                }
            }
        }

        if (ObjectUsedOn == null)//No object in slot
        {
            if (DoNotPickup == false)
            {
                if (Container.TestContainerRules(UWCharacter.Instance.playerInventory.currentContainer, slotIndex, false))
                {
                    UWCharacter.Instance.playerInventory.SetObjectAtSlot(slotIndex, CurrentObjectInHand);
                    //UWHUD.instance.CursorIcon= UWHUD.instance.CursorIconDefault;
                    CurrentObjectInHand = null;
                }
            }
        }
        else
        {
            //Get the object at the slot and test it's activation.
            //ObjectUsedOn = UWCharacter.Instance.playerInventory.GetObjectIntAtSlot(slotIndex);
            if (ObjectUsedOn.Use() == false)
            {//if nothing happened when I clicked on the object at the slot.
                if (CurrentObjectInHand != null)
                {
                    //TODO: Make sure this works with Equipment slots
                    //No effect occurred. Swap the two objects.
                    if (DoNotPickup == false)
                    {
                        if (Container.TestContainerRules(UWCharacter.Instance.playerInventory.currentContainer, slotIndex, true))
                        {
                            UWCharacter.Instance.playerInventory.SwapObjects(ObjectUsedOn, slotIndex, CurrentObjectInHand);
                        }
                    }
                }
                else
                {//Pick up the item at that slot.
                 //TODO: Make this work with Equipment slots
                    CurrentObjectInHand = ObjectUsedOn;
                    //UWHUD.instance.CursorIcon= ObjectUsedOn.GetComponent<ObjectInteraction>().GetInventoryDisplay().texture;
                    //UWCharacter.Instance.CurrObjectSprite = ObjectUsedOn.GetComponent<ObjectInteraction>().InventoryString;
                    if (this.slotIndex >= 11)
                    {
                        //Container cn = GameObject.Find(UWCharacter.Instance.playerInventory.currentContainer).GetComponent<Container>();
                        UWCharacter.Instance.playerInventory.currentContainer.RemoveItemFromContainer(UWCharacter.Instance.playerInventory.ContainerOffset + this.slotIndex - 11);
                    }
                    UWCharacter.Instance.playerInventory.ClearSlot(this.slotIndex);
                }
            }
        }
    }


    void RightClickPickup()
    {
        //pInv = player.GetComponent<PlayerInventory>();
        ObjectInteraction ObjectUsedOn = UWCharacter.Instance.playerInventory.GetObjectIntAtSlot(slotIndex);//The object at the clicked slot
        bool DoNotPickup = false;
        if (CurrentObjectInHand != null)
        {
            //ObjectInteraction objInt = CurrentObjectInHand;
            if ((SlotCategory != CurrentObjectInHand.GetItemType()) && (SlotCategory != -1))
            {//Slot is not a general use on andThis item type does not go in this slot.
             //	Debug.Log ("cannot pickup an " + objInt.GetItemType() + " in a " + SlotCategory);
                DoNotPickup = true;
            }
            //Eating food dropped in helm slot
            if (SlotCategory == HELM)
            {
                if (CurrentObjectInHand.GetItemType() == ObjectInteraction.FOOD)
                {
                    CurrentObjectInHand.Use();
                    DoNotPickup = true;
                    return;
                }
            }

            //if ((objInt.isQuant()==true) && (objInt.isEnchanted()==false))
            if (CurrentObjectInHand.IsStackable())
            {
                //ObjectUsedOn = UWCharacter.Instance.playerInventory.GetObjectIntAtSlot(slotIndex);//GameObject.Find (pInv.GetObjectAtSlot(slotIndex));
                if (ObjectUsedOn != null)
                {
                    if (ObjectInteraction.CanMerge(ObjectUsedOn, CurrentObjectInHand))
                    //	if ((objInt.item_id==ObjectUsedOn.GetComponent<ObjectInteraction>().item_id) && (objInt.quality==ObjectUsedOn.GetComponent<ObjectInteraction>().quality))
                    {
                        //merge the items
                        ObjectInteraction.Merge(ObjectUsedOn, CurrentObjectInHand);
                        //ObjectUsedOn.GetComponent<ObjectInteraction>().link=ObjectUsedOn.GetComponent<ObjectInteraction>().link+objInt.link;
                        //UWHUD.instance.CursorIcon= UWHUD.instance.CursorIconDefault;
                        CurrentObjectInHand = null;
                        UWCharacter.Instance.playerInventory.Refresh();
                        //Destroy(objInt.gameObject);
                        return;
                    }
                }
            }
        }
        //Code for when I right click in pickup mode.
        if (UWCharacter.Instance.playerInventory.GetObjectAtSlot(slotIndex) != null)
        {//Special case for opening containers in pickup mode.
            if ((CurrentObjectInHand == null))
            {
                if (ObjectUsedOn.GetComponent<Container>() != null)
                {
                    if (ObjectUsedOn.GetComponent<Container>().isOpenOnPanel == true)
                    {
                        return;
                    }
                    CurrentObjectInHand = ObjectUsedOn.GetComponent<ObjectInteraction>();
                    if (this.slotIndex >= 11)
                    {
                        UWCharacter.Instance.playerInventory.currentContainer.RemoveItemFromContainer(UWCharacter.Instance.playerInventory.ContainerOffset + this.slotIndex - 11);
                    }
                    UWCharacter.Instance.playerInventory.ClearSlot(this.slotIndex);
                    return;
                }
            }
        }

        if (UWCharacter.Instance.playerInventory.GetObjectAtSlot(slotIndex) == null)//No object in slot
        {
            if (DoNotPickup == false)
            {
                if (Container.TestContainerRules(UWCharacter.Instance.playerInventory.currentContainer, slotIndex, false))
                {
                    UWCharacter.Instance.playerInventory.SetObjectAtSlot(slotIndex, CurrentObjectInHand);
                    CurrentObjectInHand = null;
                }
            }
        }
        else
        {
            bool ObjectActivated = false;
            //Get the object at the slot and test it's activation.
            //ObjectUsedOn = UWCharacter.Instance.playerInventory.GetGameObjectAtSlot(slotIndex);//GameObject.Find (pInv.GetObjectAtSlot(slotIndex));
            //When right clicking only try to activate when an object in in the hand
            if (CurrentObjectInHand != null)
            {
                ObjectActivated = ObjectUsedOn.GetComponent<ObjectInteraction>().Use();
            }
            if (ObjectActivated == false)
            {//if nothing happened when I clicked on the object at the slot with something in hand.
                if (CurrentObjectInHand != null)
                {
                    if (DoNotPickup == false)
                    {
                        //TODO: Make sure this works with Equipment slots
                        //No effect occurred. Swap the two objects.
                        if (Container.TestContainerRules(UWCharacter.Instance.playerInventory.currentContainer, slotIndex, true))
                        {
                            UWCharacter.Instance.playerInventory.SwapObjects(ObjectUsedOn, slotIndex, CurrentObjectInHand);
                            UWCharacter.Instance.playerInventory.Refresh();
                        }
                    }
                }
                else
                {//Pick up the item at that slot.
                 //TODO: Make this work with Equipment slots
                    if (DoNotPickup == false)
                    {
                        ObjectInteraction objIntUsedOn = ObjectUsedOn.GetComponent<ObjectInteraction>();
                        //if ((ObjectUsedOn.GetComponent<ObjectInteraction>().isQuant() ==false) || ((ObjectUsedOn.GetComponent<ObjectInteraction>().isQuant())&&(ObjectUsedOn.GetComponent<ObjectInteraction>().link==1)) || (ObjectUsedOn.GetComponent<ObjectInteraction>().isEnchanted() ==true))
                        if ((!objIntUsedOn.IsStackable()) || ((objIntUsedOn.IsStackable()) && (objIntUsedOn.GetQty() <= 1)))
                        {//Is either not a quant or is a quantity of 1
                            CurrentObjectInHand = ObjectUsedOn;
                            //UWHUD.instance.CursorIcon= ObjectUsedOn.GetComponent<ObjectInteraction>().GetInventoryDisplay().texture;
                            //UWHUD.instance.CursorIcon= objIntUsedOn.GetInventoryDisplay ().texture;
                            if (this.slotIndex >= 11)
                            {
                                UWCharacter.Instance.playerInventory.currentContainer.RemoveItemFromContainer(UWCharacter.Instance.playerInventory.ContainerOffset + this.slotIndex - 11);
                            }
                            UWCharacter.Instance.playerInventory.ClearSlot(this.slotIndex);
                        }
                        else
                        {
                            //Debug.Log("attempting to pick up a quantity");
                            if (ConversationVM.InConversation == true)
                            {
                                //UWHUD.instance.MessageScroll.SetAnchorX(1.0f);//Move off screen.
                                //UWHUD.instance.MessageScrollTemp.SetAnchorX(0.06f);
                                InventorySlot.TempLookAt = UWHUD.instance.MessageScroll.NewUIOUt.text;
                                UWHUD.instance.MessageScroll.Set("Move how many?");

                                ConversationVM.EnteringQty = true;
                            }
                            else
                            {
                                UWHUD.instance.MessageScroll.Set("Move how many?");
                            }
                            InputField inputctrl = UWHUD.instance.InputControl;

                            inputctrl.gameObject.SetActive(true);
                            inputctrl.text = objIntUsedOn.GetQty().ToString();//"1";


                            inputctrl.gameObject.GetComponent<InputHandler>().target = this.gameObject;
                            inputctrl.gameObject.GetComponent<InputHandler>().currentInputMode = InputHandler.InputInventoryQty;

                            inputctrl.contentType = InputField.ContentType.IntegerNumber;
                            inputctrl.Select();

                            WindowDetect.WaitingForInput = true;
                            Time.timeScale = 0.0f;
                            QuantityObj = ObjectUsedOn;
                        }
                    }
                }
            }
        }
    }


    public void OnSubmitPickup(int quant)
    {

        InputField inputctrl = UWHUD.instance.InputControl;

        inputctrl.text = "";
        inputctrl.gameObject.SetActive(false);
        WindowDetect.WaitingForInput = false;
        ConversationVM.EnteringQty = false;
        if (ConversationVM.InConversation == false)
        {
            UWHUD.instance.MessageScroll.Clear();
            Time.timeScale = 1.0f;
        }
        else
        {
            UWHUD.instance.MessageScroll.NewUIOUt.text = InventorySlot.TempLookAt;//Restore original text
        }

        if (quant == 0)
        {//cancel
            QuantityObj = null;
        }
        if (QuantityObj != null)
        {//Just do a normal pickup.
            if (quant >= QuantityObj.GetComponent<ObjectInteraction>().link)
            {
                CurrentObjectInHand = QuantityObj;
                //UWHUD.instance.CursorIcon= QuantityObj.GetComponent<ObjectInteraction>().GetInventoryDisplay().texture;
                if (this.slotIndex >= 11)
                {
                    UWCharacter.Instance.playerInventory.currentContainer.RemoveItemFromContainer(UWCharacter.Instance.playerInventory.ContainerOffset + this.slotIndex - 11);
                }
                UWCharacter.Instance.playerInventory.ClearSlot(this.slotIndex);
            }
            else
            {
                //split the obj. 
                ObjectInteraction objI = QuantityObj.GetComponent<ObjectInteraction>();
                objI.link = objI.link - quant;
                ObjectLoaderInfo newObj = ObjectLoader.newObject(objI.item_id, objI.quality, objI.owner, quant, -1);
                newObj.is_quant = 1;
                ObjectInteraction NewObjI = ObjectInteraction.CreateNewObject(CurrentTileMap(), newObj, CurrentObjectList().objInfo, GameWorldController.instance.InventoryMarker, GameWorldController.instance.InventoryMarker.transform.position);
                GameWorldController.MoveToInventory(NewObjI);
                CurrentObjectInHand = NewObjI;
                //UWHUD.instance.CursorIcon=NewObjI.GetInventoryDisplay().texture;
                ObjectInteraction.Split(objI, NewObjI);
                UWCharacter.Instance.playerInventory.Refresh();
                QuantityObj = null;


                /*	GameObject Split = Instantiate(QuantityObj);//What we are picking up.
                    Split.GetComponent<ObjectInteraction>().link =quant;
                    Split.name = Split.name+"_"+UWCharacter.Instance.summonCount++;
                    Split.transform.parent=UWCharacter.Instance.playerInventory.InventoryMarker.transform;//this.transform.parent;
                    QuantityObj.GetComponent<ObjectInteraction>().link=QuantityObj.GetComponent<ObjectInteraction>().link-quant;
                    CurrentObjectInHand= Split.name;
                    UWHUD.instance.CursorIcon= Split.GetComponent<ObjectInteraction>().GetInventoryDisplay().texture;
                    ObjectInteraction.Split (Split.GetComponent<ObjectInteraction>(),QuantityObj.GetComponent<ObjectInteraction>());
                    UWCharacter.Instance.playerInventory.Refresh (slotIndex);
                    QuantityObj=null;//Clear out to avoid weirdness.*/
            }
        }
    }

    public ObjectInteraction GetGameObjectInteration()
    {
        return UWCharacter.Instance.playerInventory.GetObjectIntAtSlot(slotIndex);

        //      GameObject obj = UWCharacter.Instance.playerInventory.GetGameObjectAtSlot (slotIndex);
        //if (obj!=null)
        //{
        //	return obj.GetComponent<ObjectInteraction>();
        //}
        //else
        //{
        //	return null;
        //}
    }


    void TemporaryLookAt()
    {/*For looking at items temporarily in conversations where I need to restore the original log text*/
        if (InventorySlot.LookingAt == true)
        { return; }//Only look at one thing at a time.

        ObjectInteraction objInt = GetGameObjectInteration();
        if (objInt != null)
        {
            InventorySlot.LookingAt = true;
            //UWHUD.instance.MessageScroll.SetAnchorX(1.0f);//Move off screen.
            //UWHUD.instance.MessageScrollTemp.SetAnchorX(0.06f);
            InventorySlot.TempLookAt = UWHUD.instance.MessageScroll.NewUIOUt.text;
            StartCoroutine(ClearTempLookAt());
            //UWHUD.instance.MessageScrollTemp.Set (StringController.instance.GetFormattedObjectNameUW(objInt));
            UWHUD.instance.MessageScroll.DirectSet(StringController.instance.GetFormattedObjectNameUW(objInt));
        }
    }

    IEnumerator ClearTempLookAt()
    {

        Time.timeScale = 0.1f;
        yield return new WaitForSeconds(0.1f);

        InventorySlot.LookingAt = false;
        if (ConversationVM.InConversation == true)
        {
            Time.timeScale = 0.00f;
        }
        else
        {
            Time.timeScale = 1.0f;//just in case a conversation is ended while looking.
        }

        //UWHUD.instance.MessageScroll.SetAnchorX(0.06f);
        //UWHUD.instance.MessageScrollTemp.SetAnchorX(1.00f);
        UWHUD.instance.MessageScroll.DirectSet(InventorySlot.TempLookAt);
    }

    /// <summary>
    /// Handles hovering over the slot
    /// </summary>
    public void OnHoverEnter()
    {
        //if (CurrentObjectInHand!="")
        //{
        //	return;
        //}
        Hovering = true;
        UWHUD.instance.ContextMenu.text = "";
        ObjectInteraction objInt = UWCharacter.Instance.playerInventory.GetObjectIntAtSlot(slotIndex);
        //if (currObj!=null)
        //{
        //ObjectInteraction objInt=currObj.GetComponent<ObjectInteraction>();
        if (objInt != null)
        {
            string ObjectName = "";
            string UseString = "";
            //ObjectName=StringController.instance.GetSimpleObjectNameUW(objInt.item_id);
            ObjectName = objInt.GetComponent<object_base>().ContextMenuDesc(objInt.item_id);
            if (CurrentObjectInHand == null)
            {
                switch (UWCharacter.InteractionMode)
                {
                    case UWCharacter.InteractionModeUse:
                        UseString = "L-Click to " + objInt.UseVerb() + " R-Click to " + objInt.PickupVerb();
                        break;
                    case UWCharacter.InteractionModeLook:
                        UseString = "L-Click to " + objInt.UseVerb() + " R-Click to " + objInt.ExamineVerb();
                        break;
                    case UWCharacter.InteractionModePickup:
                        UseString = "L-Click to " + objInt.UseVerb() + " R-Click to " + objInt.PickupVerb();
                        break;

                }
            }
            else
            {
                UseString = "L-Click to " + objInt.UseObjectOnVerb_Inv();
            }
            UWHUD.instance.ContextMenu.text = ObjectName + "\n" + UseString;
        }
        //}
    }

    /// <summary>
    /// Handles cancelling hovering over the slot
    /// </summary>
    public void OnHoverExit()
    {
        UWHUD.instance.ContextMenu.text = "";
        Hovering = false;
    }

}
