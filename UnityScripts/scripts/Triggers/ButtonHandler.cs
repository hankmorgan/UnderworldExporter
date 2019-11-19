using UnityEngine;
using System.Collections;

public class ButtonHandler : Decal
{
    /*Code for buttons and switches*/


    public bool isOn;
    public int itemdIDOn;
    public int itemdIDOff;

    public int[] RotaryImageIDs = new int[8];


    public bool SpriteSet;
    private int currentItemID; //for tracking id changes

    // Use this for initialization
    protected override void Start()
    {
        //base.Start();
        BoxCollider bx = this.GetComponent<BoxCollider>();
        bx.size = new Vector3(0.3f, 0.3f, 0.1f);
        bx.center = new Vector3(0f, 0.16f, 0f);
        flags = flags;
        if (isRotarySwitch() == false)
        {
            //set sprites ids
            if ((item_id >= 368) && (item_id <= 375))
            {//is an off version 
                itemdIDOff = item_id - 368;
                itemdIDOn = item_id - 368 + 8;
                isOn = false;
            }
            else
            {
                itemdIDOff = item_id - 368 - 8;
                itemdIDOn = item_id - 368;
                isOn = true;
            }
            if (isOn == true)
            {
                setSprite(itemdIDOn);
            }
            else
            {
                setSprite(itemdIDOff);
            }
        }
        else
        {
            //Populate the array of item ids
            int StartImageId;
            if (item_id == 353)
            {
                StartImageId = 4;
            }
            else
            {
                StartImageId = 12;
            }
            for (int i = 0; i < 8; i++)
            {
                RotaryImageIDs[i] = StartImageId + i;
            }
            setRotarySprite(flags);
        }
    }

    public override void Update()
    {
        if (isRotarySwitch() == false)
        {
            if ((isOn) && (currentItemID != itemdIDOn))
            {
                setSprite(itemdIDOn);
            }
            if ((!isOn) && (currentItemID != itemdIDOff))
            {
                setSprite(itemdIDOff);
            }
        }
        else
        {
            if (currentItemID != flags)
            {
                setRotarySprite(flags);
            }
        }
    }


    bool isRotarySwitch()
    {
        //353
        //354
        switch (item_id)
        {
            case 353:
            case 354:
                return true;
            default:
                return false;
        }
    }

    public override bool use()
    {
        if (CurrentObjectInHand == null)
        {
            if (invis == 0)
            {
                return Activate(this.gameObject);
            }
            else
            {//Can't use an invisible switch
                return false;
            }
        }
        else
        {
            return ActivateByObject(CurrentObjectInHand);
        }
    }

    public override bool LookAt()
    {
        //public void LookAt()
        //Generally gives the object description but depending on the trigger target type it may activate (lookat trigger)
        //GameObject triggerObj= ObjectLoader.getObjectIntAt(link).gameObject;
        GameObject triggerObj = ObjectLoader.getGameObjectAt(link);
        if (triggerObj != null)
        {
            ObjectInteraction TargetObjInt = triggerObj.GetComponent<ObjectInteraction>();
            UWHUD.instance.MessageScroll.Add(StringController.instance.GetFormattedObjectNameUW(objInt()));
            if (TargetObjInt.GetItemType() == ObjectInteraction.A_LOOK_TRIGGER)//A look trigger.
            {
                base.LookAt();
                this.Activate(this.gameObject);
            }
            else
            {
                base.LookAt();
            }
        }
        else
        {
            base.LookAt();
        }
        return true;
    }


    public override bool Activate(GameObject src)
    {
        if (link != 0)
        {

            if (ObjectLoader.getGameObjectAt(link) == null)
            {
                return false;
            }
            GameObject triggerObj = ObjectLoader.getObjectIntAt(link).gameObject;
            if (triggerObj == null)
            {
                return true;//Cannot activate.
            }
            if (triggerObj.GetComponent<trigger_base>() == null)
            {
                return false;
            }
            else
            {
                if (triggerObj.GetComponent<a_use_trigger>() != null)
                {
                    triggerObj.GetComponent<a_use_trigger>().Activate(this.gameObject, isOn);
                }
                else
                {
                    triggerObj.GetComponent<trigger_base>().Activate(this.gameObject);
                }
                //triggerObj.GetComponent<trigger_base>().flags=flags;//Not sure this needs to be done?				
            }
        }

        if (isRotarySwitch())
        {
            if (flags == 7)
            {
                flags = 0;
            }
            else
            {
                flags++;
            }
        }

        if (isRotarySwitch() == false)
        {
            if (isOn == false)
            {
                isOn = true;
                setSprite(itemdIDOn);
                item_id += 8;
            }
            else
            {
                isOn = false;
                setSprite(itemdIDOff);
                item_id -= 8;
            }
        }
        else
        {
            setRotarySprite(flags);
        }
        return true;
    }

    public void setSprite(int SpriteID)
    {
        if (invis == 0)
        {
            setSpriteTMFLAT(this.GetComponentInChildren<SpriteRenderer>(), SpriteID);//Loads the sprite.;//Assigns the sprite to the object.			
            currentItemID = SpriteID;
        }

    }


    public void setRotarySprite(int spriteId)
    {
        if (invis == 0)
        {
            setSpriteTMOBJ(this.GetComponentInChildren<SpriteRenderer>(), RotaryImageIDs[spriteId]);
            currentItemID = spriteId;
        }
    }


    public override bool ActivateByObject(ObjectInteraction ObjectUsed)
    {
        //ObjectInteraction objIntUsed = ObjectUsed.GetComponent<ObjectInteraction>();
        if (ObjectUsed != null)
        {
            switch (ObjectUsed.GetItemType())
            {
                case ObjectInteraction.POLE:
                    CurrentObjectInHand = null;
                    //UWHUD.instance.CursorIcon = UWHUD.instance.CursorIconDefault;
                    UWHUD.instance.MessageScroll.Set(StringController.instance.GetString(1, StringController.str_using_the_pole_you_trigger_the_switch_));
                    return Activate(this.gameObject);
                default:
                    CurrentObjectInHand = null;
                    //UWHUD.instance.CursorIcon = UWHUD.instance.CursorIconDefault;
                    ObjectUsed.FailMessage();
                    return false;
            }
        }
        return false;
    }


    public override string UseObjectOnVerb_World()
    {
        //ObjectInteraction ObjIntInHand = UWCharacter.Instance.playerInventory.GetObjIntInHand();
        if (CurrentObjectInHand != null)
        {
            switch (CurrentObjectInHand.GetItemType())
            {
                case ObjectInteraction.POLE:
                    return "trigger with pole";
            }
        }

        return base.UseObjectOnVerb_Inv();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        if (link != 0)
        {
            GameObject target = ObjectLoader.getGameObjectAt(link);
            if (target != null)
            {
                Gizmos.DrawLine(transform.position, target.transform.position);
            }
        }
    }

}