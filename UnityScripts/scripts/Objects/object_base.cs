using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// Base class for objects and npcs
/// Works hand in hand with ObjectInteraction
/// </summary>
public class object_base : UWEBase
{
    public bool testUse = false;


    //The Object interaction that is on this object.
    protected ObjectInteraction _objInt;

    //For the context menu
    public static string ItemDesc;
    public static string UseableDesc;
    public static string PickableDesc;
    public static string UseObjectOnDesc;

    public static bool UseAvail;
    public static bool PickAvail;
    public static bool TalkAvail;

    //Static Properties


    public int item_id
    {
        get
        {
            return objInt().item_id;
        }
        set
        {
            objInt().item_id = value;
        }
    }

    public short xpos
    {
        get
        {
            return objInt().xpos;
        }
        set
        {
            objInt().xpos = value;
        }
    }

    public short ypos
    {
        get
        {
            return objInt().ypos;
        }
        set
        {
            objInt().ypos = value;
        }
    }

    public short zpos
    {
        get
        {
            return objInt().zpos;
        }
        set
        {
            objInt().zpos = value;
        }
    }


    public short heading
    {
        get
        {
            return objInt().heading;
        }
        set
        {
            objInt().heading = value;
        }
    }

    public short ObjectTileX
    {
        get
        {
            return objInt().ObjectTileX;
        }
        set
        {
            objInt().ObjectTileX = value;
        }
    }

    public short ObjectTileY
    {
        get
        {
            return objInt().ObjectTileY;
        }
        set
        {
            objInt().ObjectTileY = value;
        }
    }

    public short flags
    {
        get
        {
            return objInt().flags;
        }
        set
        {
            objInt().flags = value;
        }
    }

    public short enchantment
    {
        get
        {
            return objInt().enchantment;
        }
        set
        {
            objInt().enchantment = value;
        }
    }
    public short doordir
    {
        get
        {
            return objInt().doordir;
        }
        set
        {
            objInt().doordir = value;
        }
    }
    public short invis
    {
        get
        {
            return objInt().invis;
        }
        set
        {
            objInt().invis = value;
        }
    }
    public short isquant
    {
        get
        {
            return objInt().isquant;
        }
        set
        {
            objInt().isquant = value;
        }
    }

    public short quality
    {
        get
        {
            return objInt().quality;
        }
        set
        {
            objInt().quality = value;
        }
    }

    public int next
    {
        get
        {
            return objInt().next;
        }
        set
        {
            objInt().next = value;
        }
    }

    public short owner
    {
        get
        {
            return objInt().owner;
        }
        set
        {
            objInt().owner = value;
        }
    }

    public int link
    {
        get
        {
            return objInt().link;
        }
        set
        {
            objInt().link = value;
        }
    }

    

 


    //Mobile Properties
    public short npc_whoami
    {
        get
        {
            return objInt().npc_whoami;
        }
        set
        {
            objInt().npc_whoami = value;
        }
    }

    public short npc_voidanim
    {
        get
        {
            return objInt().npc_voidanim;
        }
        set
        {
            objInt().npc_voidanim = value;
        }
    }
    public short npc_xhome
    {
        get
        {
            return objInt().npc_xhome;
        }
        set
        {
            objInt().npc_xhome = value;
        }
    }
    public short npc_yhome
    {
        get
        {
            return objInt().npc_yhome;
        }
        set
        {
            objInt().npc_yhome = value;
        }
    }
    public short npc_hunger
    {
        get
        {
            return objInt().npc_hunger;
        }
        set
        {
            objInt().npc_hunger = value;
        }
    }
    public short npc_health
    {
        get
        {
            return objInt().npc_health;
        }
        set
        {
            objInt().npc_health = value;
        }
    }
    public short npc_hp
    {
        get
        {
            return objInt().npc_hp;
        }
        set
        {
            objInt().npc_hp = value;
        }
    }
    public short npc_arms
    {
        get
        {
            return objInt().npc_arms;
        }
        set
        {
            objInt().npc_arms = value;
        }
    }
    public short npc_power
    {
        get
        {
            return objInt().npc_power;
        }
        set
        {
            objInt().npc_power = value;
        }
    }
    public short npc_goal
    {
        get
        {
            return objInt().npc_goal;
        }
        set
        {
            objInt().npc_goal = value;
        }
    }
    public short npc_attitude
    {
        get
        {
            return objInt().npc_attitude;
        }
        set
        {
            objInt().npc_attitude = value;
        }
    }
    public short npc_gtarg
    {
        get
        {
            return objInt().npc_gtarg;
        }
        set
        {
            objInt().npc_gtarg = value;
        }
    }
    public short npc_heading
    {
        get
        {
            return objInt().npc_heading;
        }
        set
        {
            objInt().npc_heading = value;
        }
    }
    public short npc_talkedto
    {
        get
        {
            return objInt().npc_talkedto;
        }
        set
        {
            objInt().npc_talkedto = value;
        }
    }
    public short npc_level
    {
        get
        {
            return objInt().npc_level;
        }
        set
        {
            objInt().npc_level = value;
        }
    }
    public short npc_name
    {
        get
        {
            return objInt().npc_name;
        }
        set
        {
            objInt().npc_name = value;
        }
    }
    public short npc_height
    {
        get
        {
            return objInt().npc_height;
        }
        set
        {
            objInt().npc_height = value;
        }
    }


    public short ProjectileHeadingMajor
    {
        get
        {
            return objInt().ProjectileHeadingMajor;
        }
        set
        {
            objInt().ProjectileHeadingMajor = value;
        }
    }
    public short ProjectileHeadingMinor
    {
        get
        {
            return objInt().ProjectileHeadingMinor;
        }
        set
        {
            objInt().ProjectileHeadingMinor = value;
        }
    }
    public short Projectile_Speed
    {
        get
        {
            return objInt().Projectile_Speed;
        }
        set
        {
            objInt().Projectile_Speed = value;
        }
    }
    public short Projectile_Pitch
    {
        get
        {
            return objInt().Projectile_Pitch;
        }
        set
        {
            objInt().Projectile_Pitch = value;
        }
    }
    public short Projectile_Sign
    {
        get
        {
            return objInt().Projectile_Sign;
        }
        set
        {
            objInt().Projectile_Sign = value;
        }
    }


    ///A trigger to activate when this object is picked up.
    //public string PickupLink;

    /// <summary>
    /// Gets the object interaction that this object base works with
    /// </summary>
    /// <returns>The object interaction.</returns>
    public ObjectInteraction objInt()
    {
        //CheckReferences();
        if (_objInt == null)
        {
            _objInt = this.GetComponent<ObjectInteraction>();
        }
        return _objInt; //this.gameObject.GetComponent<ObjectInteraction>();
    }

    protected virtual void Start()
    {

    }

    /// <summary>
    /// For when this object is activated by code. Eg buttons
    /// </summary>
    public virtual bool Activate(GameObject src)
    {//Unimplemented items 
        return false;
    }

    /// <summary>
    /// Object is attacked or damaged in some way.
    /// </summary>
    /// <returns><c>true</c>, if attack was applyed, <c>false</c> otherwise.</returns>
    /// <param name="damage">Damage.</param>
    public virtual bool ApplyAttack(short damage)
    {
        return false;
    }

    /// <summary>
    /// Applies the attack from a known source
    /// </summary>
    /// <returns><c>true</c>, if attack was applyed, <c>false</c> otherwise.</returns>
    /// <param name="damage">Damage.</param>
    /// <param name="source">Source.</param>
    public virtual bool ApplyAttack(short damage, GameObject source)
    {
        return ApplyAttack(damage);
    }

    /// <summary>
    /// Outputs the look description of the object
    /// </summary>
    /// <returns>The <see cref="System.Boolean"/>.</returns>
    public virtual bool LookAt()
    {
        //CheckReferences();
        UWHUD.instance.MessageScroll.Add(StringController.instance.GetFormattedObjectNameUW(objInt()) + OwnershipString());
        if ((link != 0) && (objInt().isQuant() == false) && (enchantment == 0))
        {
            if (ObjectLoader.GetItemTypeAt(link) == ObjectInteraction.A_LOOK_TRIGGER)
            {
                ObjectInteraction obj = ObjectLoader.getObjectIntAt(link);
                if (obj != null)
                {
                    obj.GetComponent<object_base>().Activate(this.gameObject);
                }
            }
        }
        return true;
    }

    /// <summary>
    /// Activation of this object by another. EG key on door
    /// </summary>
    /// <returns><c>true</c>, if by object was activated, <c>false</c> otherwise.</returns>
    /// <param name="ObjectUsed">Object used.</param>
    public virtual bool ActivateByObject(GameObject ObjectUsed)
    {
        //CheckReferences();
        if (UWCharacter.InteractionMode == UWCharacter.InteractionModeUse)
        {
            FailMessage();
            UWHUD.instance.CursorIcon = UWHUD.instance.CursorIconDefault;
            UWCharacter.Instance.playerInventory.ObjectInHand = "";
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// The object is used by the player.
    /// </summary>
    /// Checks if the player is already holding something or using something else on this object.
    public virtual bool use()
    {
        //CheckReferences();
        if (UWCharacter.Instance.playerInventory.ObjectInHand == "")
        {
            if ((objInt().isUsable() == true) && (objInt().PickedUp == true))
            {
                BecomeObjectInHand();
                return true;
            }
            else
            {
                if (objInt().isUsable())
                {//Hope this does'nt mess up everything!
                    if ((link != 0) && (objInt().isQuant() == false) && (enchantment == 0))
                    {//Not a quantity or an enchanted item.
                        if (ObjectLoader.GetItemTypeAt(link) == ObjectInteraction.A_USE_TRIGGER)
                        {
                            ObjectLoader.getGameObjectAt(link).GetComponent<trigger_base>().Activate(this.gameObject);
                        }
                    }
                }
                return false;
            }
        }
        else
        {
            return ActivateByObject(UWCharacter.Instance.playerInventory.GetGameObjectInHand());
        }
    }

    /// <summary>
    /// Checks the external references for this object
    /// </summary>
    /*protected void CheckReferences()
	{
		if (objInt==null)
		{
			objInt = this.gameObject.GetComponent<ObjectInteraction>();
		}
		if ((objInt!=null) && (ml==null))
		{
			ml=UWHUD.instance.MessageScroll;
		}
	}*/

    /// <summary>
    /// This object becomes the object in hand in order to be use
    /// </summary>
    public void BecomeObjectInHand()
    {//In order to use it.
        UWHUD.instance.CursorIcon = objInt().GetInventoryDisplay().texture;
        UWCharacter.Instance.playerInventory.ObjectInHand = this.name;
        UWCharacter.InteractionMode = UWCharacter.InteractionModeUse;
        InteractionModeControl.UpdateNow = true;
    }

    /// <summary>
    /// Player talks to the object.
    /// </summary>
    /// <returns><c>true</c>, if to was talked, <c>false</c> otherwise.</returns>
    public virtual bool TalkTo()
    {
        //000~001~156~You cannot talk to that.
        UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, StringController.str_you_cannot_talk_to_that_));
        return true;
    }

    /// <summary>
    /// Player tries to eat this object.
    /// </summary>
    /// For when the player tries to eat certain objects by dragging them on top of the paper doll face. For future use?
    public virtual bool Eat()
    {
        return false;
    }

    /// <summary>
    /// For special events when an object is picked up. Eg silver seed or pickup traps
    /// </summary>
    /// If object has a pickup link then the object referenced is activated
    public virtual bool PickupEvent()
    {
        if ((link != 0) && (objInt().isQuant() == false) && (enchantment == 0))
        {
            if (ObjectLoader.GetItemTypeAt(link) == ObjectInteraction.A_PICK_UP_TRIGGER)
            {
                ObjectLoader.getGameObjectAt(link).GetComponent<trigger_base>().Activate(this.gameObject);
                link = 0;
            }
        }
        if (CanBeOwned())
        {
            if (((owner & 0x1f)) != 0)
            //if ((owner < 31) && (owner >0))
            {
                if (_RES == GAME_UW1)
                {
                    if ((owner == 13) && (Quest.instance.QuestVariables[32] == 4))
                    {//Do not signal theft if the item belongs to a knight and the player is now a knight
                        owner = 0;
                        return false;
                    }
                }
                SignalTheft(UWCharacter.Instance.transform.position, owner, 4f);
                owner = 0;
            }
        }

        return false;
    }

    /// <summary>
    /// For special events when an object is dropped. Eg setting the map is_quant value back to zero
    /// </summary>
    /// <returns><c>true</c>, if event was droped, <c>false</c> otherwise.</returns>
    public virtual bool DropEvent()
    {
        return false;
    }

    /*
if (PickupLink!="")
{
GameObject obj = GameObject.Find (PickupLink);
if (obj!=null)
{
if (obj.GetComponent<trigger_base>()!=null)
{
obj.GetComponent<trigger_base>().Activate();
}
}
}
return false;*/



    /// <summary>
    /// Event when Item is put into inventory
    /// </summary>
    /// <returns><c>true</c>, if item away was put, <c>false</c> otherwise.</returns>
    /// <param name="slotNo">Slot no.</param>
    public virtual bool PutItemAwayEvent(short slotNo)
    {
        return false;
    }

    /// <summary>
    /// PLayer puts the object on in an inventory slot.
    /// </summary>
    /// <returns><c>true</c>, if event was equiped, <c>false</c> otherwise.</returns>
    /// <param name="slotNo">Slot no.</param>
    public virtual bool EquipEvent(short slotNo)
    {
        return false;
    }

    /// <summary>
    /// Player takes an object out of  an inventory slot.
    /// </summary>
    /// <returns><c>true</c>, if equip event was uned, <c>false</c> otherwise.</returns>
    /// <param name="slotNo">Slot no.</param>
    public virtual bool UnEquipEvent(short slotNo)
    {
        return false;
    }

    /// <summary>
    /// Failure message to display when this object is used on a another object that has no use for it. Eg a key on a sign.
    /// </summary>
    /// <returns><c>true</c>, if message was failed, <c>false</c> otherwise.</returns>
    public virtual bool FailMessage()
    {//000~001~152~You cannot use that. \n
        UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, StringController.str_you_cannot_use_that_));
        return false;
    }

    /// <summary>
    /// Return the weight of the object stack
    /// </summary>
    /// <returns>The weight.</returns>
    public virtual float GetWeight()
    {
        if (objInt() == null)
        {
            return 0.0f;
        }
        else
        {

            return (float)(objInt().GetQty()) * GameWorldController.instance.commonObject.properties[item_id].mass * 0.1f;// .Mass[item_id]*0.1f;
                                                                                                                                   //return (float)(objInt().GetQty())* GameWorldController.instance.commobj.Mass[item_id]*0.1f;
        }
    }

    /// <summary>
    /// Code to call when merging two objects. 
    /// To support cases where merging an object means the object becomes something different.
    /// Eg coin into stack of coins
    /// </summary>
    public virtual void MergeEvent()
    {

        return;
    }

    /// <summary>
    /// Another item Id this object could potentially have. Eg coin/gold coin. 
    /// By default it's normal item_id is returned
    /// </summary>
    /// <returns>The item identifier.</returns>
    public virtual int AliasItemId()
    {
        return item_id;
    }

    /// <summary>
    /// Code to call when spliting an item and the split changes the item fundamentally.
    /// </summary>
    public virtual void Split()
    {
        return;
    }


    /// <summary>
    /// Copies the object base.
    /// </summary>
    /// <param name="target">Target.</param>
    /// Possible use in room management when an object is stuck with DontDestroyOnLoan()
    // public virtual void CopyObject_base(GameObject target)
    //	{
    //	object_base objBase=target.AddComponent<object_base>();
    //	objBase.PickupLink=PickupLink;
    //}

    /// <summary>
    /// Changes the type of the object. Eg when destroyed and it needs to become debris.
    /// </summary>
    /// <returns><c>true</c>, if type was changed, <c>false</c> otherwise.</returns>
    /// <param name="newID">New ID.</param>
    /// <param name="itemType">Item type.</param>
    /// You must manually remove the existing object_base from this object when calling this
    public virtual bool ChangeType(int newID)
    {
        objInt().ChangeType(newID);
        return true;
    }


    /// <summary>
    /// Gets the identification Skill levels required for identifying the enchantment..
    /// </summary>
    /// <returns>The identification levels.</returns>
    /// <param name="EffectID">Effect ID to test</param>
    public int getIdentificationLevels(int EffectID)
    {
        //TODO:Decide on what to do about values. More powerful effects are harder to id?
        switch (EffectID)
        {
            default:
                //Debug.Log("EffectID" + EffectID + " unknownn");
                return Random.Range(1, 31);//This is totally wrong!
        }
    }

    /// <summary>
    /// Gets the sprite name that is displayed when the object is equipped in inventory
    /// </summary>
    /// <returns>The equip string.</returns>
    //	public virtual string getEquipString()
    //{
    //	return GameWorldController.instance.objectMaster.particle[item_id];
    //}

    public virtual Sprite GetEquipDisplay()
    {
        return objInt().GetInventoryDisplay();
    }


    /// <summary>
    /// Gets the context menu text.
    /// </summary>
    public string GetContextMenuText(int item_id, bool isUseable, bool isPickable, bool ObjectInHand)
    {
        if (invis == 1)
        {
            UseAvail = false;
            TalkAvail = false;
            PickAvail = false;
            return "";

        }
        ItemDesc = ContextMenuDesc(item_id);
        TalkAvail = false;
        if (isUseable)
        {
            UseableDesc = ContextMenuUsedDesc();//TODO:Controls
            UseAvail = true;
        }
        else
        {
            UseableDesc = "";
            UseAvail = false;
        }
        if (ObjectInHand)
        {
            UseObjectOnDesc = ContextMenuUseObjectOn_World();
        }
        else
        {
            if (isPickable)
            {
                PickableDesc = ContextMenuUsedPickup();
                PickAvail = true;
            }
            else
            {
                PickableDesc = "";
                PickAvail = false;
            }
        }
        if ((UWCharacter.InteractionMode == UWCharacter.InteractionModePickup) && (UWCharacter.Instance.playerInventory.ObjectInHand != ""))
        {//I'm actually throwing something.
            UseAvail = false;
            UseableDesc = "";
            PickableDesc = "";
        }

        if (ObjectInHand)
        {
            if (UseAvail == true)
            {
                return ItemDesc + "\n" + UseObjectOnDesc;// + " " + UseObjectOnDesc;			
            }
            else
            {//I'm throwing an object.
                return ItemDesc;
            }

        }
        else
        {
            if ((UseableDesc != "") || (PickableDesc != ""))
            {
                return ItemDesc + "\n" + UseableDesc + " " + PickableDesc;
            }
            else
            {
                return "";//no object description returned.
            }
        }
    }

    /// <summary>
    /// Item description for the context menu
    /// </summary>
    /// <returns>The menu desc.</returns>
    /// <param name="item_id">Item identifier.</param>
    public virtual string ContextMenuDesc(int item_id)
    {
        return StringController.instance.GetSimpleObjectNameUW(item_id);
    }

    public virtual string ContextMenuUsedDesc()
    {
        return "L-Click to " + UseVerb();
    }

    public virtual string ContextMenuUsedPickup()
    {
        return "R-Click to " + PickupVerb();
    }

    public virtual string ContextMenuUseObjectOn_World()
    {
        return "L-Click to " + UseObjectOnVerb_World();
    }

    public virtual string ContextMenuUseObjectOn_Inv()
    {
        return "R-Click to " + UseObjectOnVerb_Inv();
    }

    public virtual string UseVerb()
    {
        return "use";
    }

    public virtual string PickupVerb()
    {
        return "pickup";
    }

    public virtual string ExamineVerb()
    {
        return "examine";
    }

    public virtual string UseObjectOnVerb_World()
    {
        return "use object on";
    }

    public virtual string UseObjectOnVerb_Inv()
    {
        return "swap/combine";
    }


    //public virtual Vector3 GetImpactPoint()
    //{
    //	return this.gameObject.transform.position;
    //}
    public override Vector3 GetImpactPoint()
    {
        return this.gameObject.transform.position;
    }

    public virtual GameObject GetImpactGameObject()
    {
        return this.gameObject;
    }


    /// <summary>
    /// Requests a sprite from tmOBJ
    /// </summary>
    /// <returns><c>true</c>, if sprite was set, <c>false</c> otherwise.</returns>
    /// <param name="sprt">Sprt.</param>
    /// <param name="SpriteIndex">Sprite index.</param>
    public bool setSpriteTMOBJ(SpriteRenderer sprt, int SpriteIndex)
    {
        if (sprt == null)
        {
            return false;
        }
        if (SpriteIndex != -1)
        {
            //sprt.sprite = Resources.Load <Sprite> (SpriteName);//Loads the sprite.;//Assigns the sprite to the object.
            sprt.sprite = GameWorldController.instance.TmObjArt.RequestSprite(SpriteIndex);
            //currentSpriteName=SpriteName;
            objInt().animationStarted = true;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Sets a sprite from TMFLat
    /// </summary>
    /// <returns><c>true</c>, if sprite TMFLA was set, <c>false</c> otherwise.</returns>
    /// <param name="sprt">Sprt.</param>
    /// <param name="SpriteIndex">Sprite index.</param>
    public bool setSpriteTMFLAT(SpriteRenderer sprt, int SpriteIndex)
    {
        if (sprt == null)
        {
            return false;
        }
        if (SpriteIndex != -1)
        {
            sprt.sprite = GameWorldController.instance.TmFlatArt.RequestSprite(SpriteIndex);
            objInt().animationStarted = true;
            return true;
        }
        return false;
    }



    /// <summary>
    /// Special event to occur when this item is in the inventory and is moved to another level
    /// </summary>
    public virtual void InventoryEventOnLevelEnter()
    {

    }

    /// <summary>
    /// Special event to occur when this item is in the inventory and is moved to another level
    /// </summary>
    /// Used mainly to update wands and their spell object links
    public virtual void InventoryEventOnLevelExit()
    {

    }

    /// <summary>
    /// Event to raise when object is saved.
    /// </summary>
    public virtual void OnSaveObjectEvent()
    {
        //TODO:objects which are in motion (eg projectiles) will be updated to move between the mobile and static object lists as appropiate
        //as well as update their positioning values.

        /*
         if object is in motion
            Reset rotation if needed.
            get direction along xy and z planes
            convert to mobile object files.
            ensure object is in mobile object list
         else
            ensure object is in static object list.
            clear values as needed
         */
    }

    /// <summary>
    /// Determines whether this object type can be picked up regardless of what is set in common object properties.
    /// </summary>
    /// <returns><c>true</c> if this instance can be picked up; otherwise, <c>false</c>.</returns>
    public virtual bool CanBePickedUp()
    {
        return false;
    }

    /// <summary>
    /// Returns if the item in question can be owned by an NPC
    /// </summary>
    /// <returns><c>true</c> if this instance can be owned; otherwise, <c>false</c>.</returns>
    public bool CanBeOwned()
    {
        return (GameWorldController.instance.commonObject.properties[item_id].CanBelongTo == 1);
    }

    /// <summary>
    /// String for displaying the ownership of the object in question.
    /// </summary>
    /// <returns>The string.</returns>
    public virtual string OwnershipString()
    {
        if (CanBeOwned())
        {
            if (((owner & 0x1f)) != 0)
            //if ((owner < 31) && (owner >0))
            {
                return " belonging to" + StringController.instance.GetString(1, 370 + (owner & 0x1f));//This is what uw formats says. I think this is wrong...
            }
        }
        return "";
    }


    /// <summary>
    /// Signals the theft of this object to a specific race
    /// </summary>
    public static void SignalTheft(Vector3 position, int Owner, float range)
    {
        foreach (Collider Col in Physics.OverlapSphere(position, 4.0f))
        {
            if (Col.gameObject.GetComponent<NPC>() != null)
            {
                if ((Col.gameObject.GetComponent<NPC>().GetRace() == (Owner & 0x1f)))
                {
                    string OwnerName = StringController.instance.GetString(1, 370 + (Owner & 0x1f));
                    string reaction = "";
                    Col.gameObject.GetComponent<NPC>().npc_attitude--;//Make the npc angry with the player.
                    if (Col.gameObject.GetComponent<NPC>().npc_attitude <= 0)
                    {
                        Col.gameObject.GetComponent<NPC>().npc_attitude = 0;
                        Col.gameObject.GetComponent<NPC>().npc_gtarg = 1;
                        Col.gameObject.GetComponent<NPC>().gtarg = UWCharacter.Instance.gameObject;
                        Col.gameObject.GetComponent<NPC>().gtargName = UWCharacter.Instance.gameObject.name;
                        Col.gameObject.GetComponent<NPC>().npc_goal = (short)NPC.npc_goals.npc_goal_attack_5;
                        reaction = StringController.instance.GetString(1, StringController.str__is_angered_by_your_action_);
                    }
                    else
                    {
                        reaction = StringController.instance.GetString(1, StringController.str__is_annoyed_by_your_action_);
                        //StringController.instance.GetString(1,370+(owner & 0x1f) )
                    }
                    UWHUD.instance.MessageScroll.Add(OwnerName.Trim() + reaction);
                }
            }
        }
    }


    /// <summary>
    /// Finds the trap of the specified type in chain of execution of linked items
    /// </summary>
    /// <returns><c>true</c>, if trap in chain was found, <c>false</c> otherwise.</returns>
    /// <param name="link">Link.</param>
    /// <param name="TrapType">Trap type.</param>
    public virtual ObjectInteraction FindObjectInChain(int link, int ItemType)
    {
        if (link != 0)
        {
            ObjectInteraction objLink = GameWorldController.instance.CurrentObjectList().objInfo[link].instance;
            if (objLink != null)
            {
                if (objLink.GetItemType() == ObjectInteraction.A_DELETE_OBJECT_TRAP)
                {//Stop infinite loops
                    if (ItemType == ObjectInteraction.A_DELETE_OBJECT_TRAP)
                    {
                        return objLink;
                    }
                    else
                    {
                        return null;
                    }

                }
                if (objLink.GetItemType() == ItemType)
                {
                    return objLink;
                }
                else
                {
                    return FindObjectInChain(objLink.link, ItemType);
                }
            }
        }
        return null;
    }

    /// <summary>
    /// Event to occur when object moves to world object list
    /// </summary>
    public virtual void MoveToWorldEvent()
    {

    }

    /// <summary>
    /// Event to occur when object moves to inventory object list
    /// </summary>
    public virtual void MoveToInventoryEvent()
    {

    }


    public virtual void Update()
    {
        if (testUse)
        {
            testUse = false;
            use();
        }
        //Uncomment this code to watch objects fly off in different directions!
        /*				if  (this.name=="_Gronk")
        {
                return;
        }
        if (this.transform.parent!=GameWorldController.instance.DynamicObjectMarker())
        {
                return;
        }
        if (objInt().debugindex>256) 
        {
                return;
        }
        //Update the projectile position based on various factors
        //Missile position is based on a cardinal compass heading n,ne,e,se etc and a clockwise rotation of 0 to 31 units to the next heading.
        npc_xhome = (short)(transform.position.x/1.2f);
        npc_yhome = (short)(transform.position.z/1.2f);

        //if (rgd==null)
        //{//Use the stored values for motion control instead of the applied force.
        Vector3 dir;
        Quaternion deflectionXY = Quaternion.AngleAxis(45f * (float)(ProjectileHeadingMinor)/32f,Vector3.up);
        //Quaternion deflectionZ;
        float z;
        if (Projectile_Sign == 0) 
        {//projectile goes down
                //deflectionZ = Quaternion.AngleAxis(-90f * (float)(Projectile_Pitch)/7f,Vector3.right);
                z = -1 * ( (float)(Projectile_Pitch)/7f) ;
        }
        else
        {//projectile goes up
                //deflectionZ = Quaternion.AngleAxis(+90f * (float)(Projectile_Pitch)/7f,Vector3.right);	
                z = +1 * ((float)(Projectile_Pitch)/7f) ;
        }
        switch (ProjectileHeadingMajor)
        {
        case 1: //ne
                dir = new Vector3(1f,z,1f);break;//ok
        case 2: //e
                dir = new Vector3(1f,z,0f);break;//ok
        case 3: //se
                dir = new Vector3(1f,z,-1f);break;//ok
        case 4: //s
                dir = new Vector3(0f,z,-1f);break;
        case 5: //sw
                dir = new Vector3(-1f,z,-1f);break;
        case 6: //w
                dir = new Vector3(-1f,z,0f);break; //ok
        case 7: //nw						
                dir = new Vector3(-1f,z,1f);break;//ok
        default: //north
        case 0:
                dir = new Vector3(0f,z,1f);break;//ok
        }
        //this.transform.Translate (deflectionXY * dir * Time.deltaTime);
        timeforce+=Time.deltaTime;
        if (timeforce >=1f)
        {
                timeforce=0f;
                if (this.GetComponent<Rigidbody>()!=null)						
                {
                        this.GetComponent<Rigidbody>().AddForce(deflectionXY * dir );
                }	
        }*/

    }

    /// <summary>
    /// Converts the properties in the mobile object values to a vector
    /// </summary>
    /// <returns>The properties to vector.</returns>
    /// <param name="obj">Object.</param>
    /// Assumes object has no rotation.
    public static Vector3 ProjectilePropsToVector(object_base obj)
    {
        Vector3 dir;
        Quaternion deflectionXY = Quaternion.AngleAxis(45f * (float)(obj.ProjectileHeadingMinor) / 32f, Vector3.up);
        //Quaternion deflectionZ;
        float z;
        if (obj.Projectile_Sign == 0)
        {
            //projectile goes down
            z = -1 * ((float)(obj.Projectile_Pitch) / 7f);
        }
        else
        {
            //projectile goes up
            z = +1 * ((float)(obj.Projectile_Pitch) / 7f);
        }
        switch (obj.ProjectileHeadingMajor)
        {
            case 1:
                //ne
                dir = new Vector3(1f, z, 1f);
                break;
            //ok
            case 2:
                //e
                dir = new Vector3(1f, z, 0f);
                break;
            //ok
            case 3:
                //se
                dir = new Vector3(1f, z, -1f);
                break;
            //ok
            case 4:
                //s
                dir = new Vector3(0f, z, -1f);
                break;
            case 5:
                //sw
                dir = new Vector3(-1f, z, -1f);
                break;
            case 6:
                //w
                dir = new Vector3(-1f, z, 0f);
                break;
            //ok
            case 7:
                //nw						
                dir = new Vector3(-1f, z, 1f);
                break;
            //ok
            default:
            //north
            case 0:
                dir = new Vector3(0f, z, 1f);
                break;
                //ok
        }

        //	Debug.Log(deflectionXY*dir);
        return deflectionXY * dir;
    }

    /// <summary>
    /// Event to call when the object is destroyed fully.
    /// </summary>
    public virtual void DestroyEvent()
    {

    }

}