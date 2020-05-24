using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class InventorySlot : GuiBase
{
    /*The slots containing items on the Inventory display*/

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
            if (!ConversationVM.InConversation)
            {
                UWCharacter.InteractionMode = UWCharacter.InteractionModePickup;
                InteractionModeControl.UpdateNow = true;
            }
            ClickEvent(-2);
        }
    }


    /// <summary>
    /// Handle using objects in inventory
    /// </summary>
    void UseFromSlot()
    {
        ObjectInteraction currObj = UWCharacter.Instance.playerInventory.GetObjectIntAtSlot(slotIndex);

        if (currObj != null)
        {
            currObj.Use();
        }
        else
        {
            if (CurrentObjectInHand != null)
            {
                CurrentObjectInHand = null;
            }
        }
    }

    /// <summary>
    /// Handle looking at objects in inventory
    /// </summary>
    void LookFromSlot()
    {
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
        ClickEvent(pntr.pointerId);
        UWCharacter.Instance.playerInventory.Refresh();
    }


    /// <summary>
    /// Overall handling of clicking slots in the inventory
    /// </summary>
    /// <param name="pointerID"></param>
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
    }


    /// <summary>
    /// Handle clicking on inventory slots when in a conversation
    /// </summary>
    /// <param name="isLeftClick"></param>
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
            return;
        }
        else
        {
            RightClickPickup();
        }

        return;
    }


    /// <summary>
    /// Code for when left clicking in pickup mode
    /// </summary>
    void LeftClickPickup()
    {
        ObjectInteraction ObjectUsedOn = UWCharacter.Instance.playerInventory.GetObjectIntAtSlot(slotIndex);
        bool DoNotPickup = false;
        if (CurrentObjectInHand != null)
        {
            //Special case Eating food dropped on helm slot
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
            {//Slot is not a general use one and this item type does not go in this slot. Eg putting a sword on a ring slot
                DoNotPickup = true;
            }

            if (CurrentObjectInHand.IsStackable())
            {//Check if object is stackable and if so try and merge them together if the object being added is of the same type.
                if (ObjectUsedOn != null)
                {
                    if (ObjectInteraction.CanMerge(ObjectUsedOn, CurrentObjectInHand))
                    {
                        ObjectInteraction.Merge(ObjectUsedOn, CurrentObjectInHand);
                        CurrentObjectInHand = null;
                        UWCharacter.Instance.playerInventory.Refresh();
                        return;
                    }
                }
            }
        }

       
        if (ObjectUsedOn == null)//No object in slot -> add to the slot
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
            //Get the object at the slot and test if it is activated or effected by the object in the players hand
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
                    if (this.slotIndex >= 11)
                    {
                        UWCharacter.Instance.playerInventory.currentContainer.RemoveItemFromContainer(UWCharacter.Instance.playerInventory.ContainerOffset + this.slotIndex - 11);
                    }
                    UWCharacter.Instance.playerInventory.ClearSlot(this.slotIndex);
                }
            }
        }
    }


    void RightClickPickup()
    {
        ObjectInteraction ObjectUsedOn = UWCharacter.Instance.playerInventory.GetObjectIntAtSlot(slotIndex);//The object at the clicked slot
        bool DoNotPickup = false;
        if (CurrentObjectInHand != null)
        {
            if ((SlotCategory != CurrentObjectInHand.GetItemType()) && (SlotCategory != -1))
            {//Slot is not a general use on and This item type does not go in this slot.
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

            if (CurrentObjectInHand.IsStackable())
            {
                if (ObjectUsedOn != null)
                {
                    if (ObjectInteraction.CanMerge(ObjectUsedOn, CurrentObjectInHand))
                    {
                        //merge the items
                        ObjectInteraction.Merge(ObjectUsedOn, CurrentObjectInHand);
                        CurrentObjectInHand = null;
                        UWCharacter.Instance.playerInventory.Refresh();
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
                        if ((!objIntUsedOn.IsStackable()) || ((objIntUsedOn.IsStackable()) && (objIntUsedOn.GetQty() <= 1)))
                        {//Is either not a quant or is a quantity of 1
                            CurrentObjectInHand = ObjectUsedOn;
                            if (this.slotIndex >= 11)
                            {
                                UWCharacter.Instance.playerInventory.currentContainer.RemoveItemFromContainer(UWCharacter.Instance.playerInventory.ContainerOffset + this.slotIndex - 11);
                            }
                            UWCharacter.Instance.playerInventory.ClearSlot(this.slotIndex);
                        }
                        else
                        {
                            if (ConversationVM.InConversation == true)
                            {
                                //InventorySlot.TempLookAt = UWHUD.instance.MessageScroll.NewUIOUt.text;
                                //UWHUD.instance.MessageScroll.NewUIOUt.text = "";
                                UWHUD.instance.ConversationButtonParent.SetActive(false);
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


    /// <summary>
    /// Handle player choosing how many items to pick up in a stack
    /// </summary>
    /// <param name="quant"></param>
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
            UWHUD.instance.ConversationButtonParent.SetActive(true);
            UWHUD.instance.MessageScroll.Set("");
           // UWHUD.instance.MessageScroll.NewUIOUt.text = InventorySlot.TempLookAt;//Restore original text
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
                ObjectInteraction.Split(objI, NewObjI);
                UWCharacter.Instance.playerInventory.Refresh();
                QuantityObj = null;
            }
        }
    }

    public ObjectInteraction GetGameObjectInteration()
    {
        return UWCharacter.Instance.playerInventory.GetObjectIntAtSlot(slotIndex);
    }


    void TemporaryLookAt()
    {/*For looking at items temporarily in conversations where I need to restore the original log text*/
        if (InventorySlot.LookingAt == true)
        { return; }//Only look at one thing at a time.

        ObjectInteraction objInt = GetGameObjectInteration();
        if (objInt != null)
        {
            InventorySlot.LookingAt = true;
            InventorySlot.TempLookAt = UWHUD.instance.MessageScroll.NewUIOUt.text;
            StartCoroutine(ClearTempLookAt());
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
        UWHUD.instance.MessageScroll.DirectSet(InventorySlot.TempLookAt);
    }

    /// <summary>
    /// Handles hovering over the slot
    /// </summary>
    public void OnHoverEnter()
    {
        Hovering = true;
        UWHUD.instance.ContextMenu.text = "";
        ObjectInteraction objInt = UWCharacter.Instance.playerInventory.GetObjectIntAtSlot(slotIndex);

        if (objInt != null)
        {
            string ObjectName = "";
            string UseString = "";
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
