using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using RAIN.BehaviorTrees;
//using RAIN.Core;
//using RAIN.Minds;
//using RAIN.Navigation;

/// <summary>
/// Object interaction. Does a lot....
/// Use for common object actions. Weight, qty, type, how to display the object. 
/// </summary>
public class ObjectInteraction : UWEBase
{

    public int debugindex;

    public static bool PlaySoundEffects = true;


    public const int NPC_TYPE = 0;
    public const int WEAPON = 1;
    public const int ARMOUR = 2;
    public const int AMMO = 3;
    public const int DOOR = 4;
    public const int KEY = 5;
    public const int RUNE = 6;
    public const int BRIDGE = 7;
    public const int BUTTON = 8;
    public const int LIGHT = 9;
    public const int SIGN = 10;
    public const int BOOK = 11;
    public const int WAND = 12;
    public const int SCROLL = 13; //The reading kind
    public const int POTIONS = 14;
    public const int INSERTABLE = 15; //Shock style put the circuit board in the slot.
    public const int INVENTORY = 16; //Quest items and the like with no special properties
    public const int ACTIVATOR = 17; //Crystal balls,magic fountains and surgery machines that have special custom effects when you activate them
    public const int TREASURE = 18;
    public const int CONTAINER = 19;
    //public const int TRAP =20 ;
    public const int LOCK = 21;
    public const int TORCH = 22;
    public const int CLUTTER = 23;
    public const int FOOD = 24;
    public const int SCENERY = 25;
    public const int INSTRUMENT = 26;
    public const int FIRE = 27;
    public const int MAP = 28;
    public const int HIDDENDOOR = 29;
    public const int PORTCULLIS = 30;
    public const int PILLAR = 31;
    public const int SOUND = 32;
    public const int CORPSE = 33;
    public const int TMAP_SOLID = 34;
    public const int TMAP_CLIP = 35;
    public const int MAGICSCROLL = 36;
    public const int A_DAMAGE_TRAP = 37;
    public const int A_TELEPORT_TRAP = 38;
    public const int A_ARROW_TRAP = 39;
    public const int A_DO_TRAP = 40;
    public const int A_PIT_TRAP = 41;
    public const int A_CHANGE_TERRAIN_TRAP = 42;
    public const int A_SPELLTRAP = 43;
    public const int A_CREATE_OBJECT_TRAP = 44;
    public const int A_DOOR_TRAP = 45;
    public const int A_WARD_TRAP = 46;
    public const int A_TELL_TRAP = 47;
    public const int A_DELETE_OBJECT_TRAP = 48;
    public const int AN_INVENTORY_TRAP = 49;
    public const int A_SET_VARIABLE_TRAP = 50;
    public const int A_CHECK_VARIABLE_TRAP = 51;
    public const int A_COMBINATION_TRAP = 52;
    public const int A_TEXT_STRING_TRAP = 53;
    public const int A_MOVE_TRIGGER = 54;
    public const int A_PICK_UP_TRIGGER = 55;
    public const int A_USE_TRIGGER = 56;
    public const int A_LOOK_TRIGGER = 57;
    public const int A_STEP_ON_TRIGGER = 58;
    public const int AN_OPEN_TRIGGER = 59;
    public const int AN_UNLOCK_TRIGGER = 60;
    public const int A_FOUNTAIN = 61;
    public const int SHOCK_DECAL = 62;
    public const int COMPUTER_SCREEN = 63;
    public const int SHOCK_WORDS = 64;
    public const int SHOCK_GRATING = 65;
    public const int SHOCK_DOOR = 66;
    public const int SHOCK_DOOR_TRANSPARENT = 67;
    public const int UW_PAINTING = 68;
    public const int PARTICLE = 69;
    public const int RUNEBAG = 70;
    public const int SHOCK_BRIDGE = 71;
    public const int FORCE_DOOR = 72;
    public const int HIDDENPLACEHOLDER = 999;
    public const int HELM = 73;
    public const int RING = 74;
    public const int BOOT = 75;
    public const int GLOVES = 76;
    public const int LEGGINGS = 77;
    public const int SHIELD = 78;
    public const int LOCKPICK = 79;
    public const int ANIMATION = 80;
    public const int SILVERSEED = 81;
    public const int FOUNTAIN = 82;
    public const int SHRINE = 83;
    public const int GRAVE = 84;
    public const int ANVIL = 85;
    public const int POLE = 86;
    public const int SPIKE = 87;
    public const int REFILLABLE_LANTERN = 88;
    public const int OIL = 89;
    public const int MOONSTONE = 90;
    public const int LEECH = 91;
    public const int FISHING_POLE = 92;
    public const int ZANIUM = 93;
    public const int BEDROLL = 94;
    public const int FORCEFIELD = 95;
    public const int MOONGATE = 96;
    public const int BOULDER = 97;
    public const int ORB = 98;
    public const int SPELL = 99;//used by wands
    public const int AN_OSCILLATOR = 100;
    public const int A_TIMER_TRIGGER = 101;
    public const int A_SCHEDULED_TRIGGER = 102;
    public const int A_CHANGE_FROM_TRAP = 103;
    public const int A_CHANGE_TO_TRAP = 104;
    public const int AN_EXPERIENCE_TRAP = 105;
    public const int A_POCKETWATCH = 106;
    public const int A_3D_MODEL = 107;
    public const int A_LARGE_BLACKROCK_GEM = 108;
    public const int A_NULL_TRAP = 109;
    public const int AN_ORB_ROCK = 110;
    public const int AN_EXPLODING_BOOK = 111;
    public const int A_MAGIC_PROJECTILE = 112;
    public const int A_MOVING_DOOR = 113;
    public const int A_PRESSURE_TRIGGER = 114;
    public const int A_CLOSE_TRIGGER = 115;
    public const int A_BLACKROCK_GEM = 116;
    public const int AN_ENTER_TRIGGER = 117;
    public const int A_JUMP_TRAP = 118;
    public const int A_SKILL_TRAP = 119;
    public const int AN_EXIT_TRIGGER = 120;
    public const int UNIMPLEMENTED_TRAP = 121;
    public const int A_STORAGECRYSTAL = 122;
    public const int NPC_WISP = 123;
    public const int NPC_VOID = 124;
    public const int DREAM_PLANT = 125;
    public const int BED = 126;
    public const int ARROW = 127;
    public const int A_PROXIMITY_TRAP = 128;
    public const int BOUNCING_PROJECTILE = 129;

    /*SYSTEM SHOCK TRIGGER TYPES. I'm adding 1000 to keep them seperate from the above*/
    public const int SHOCK_TRIGGER_ENTRY = 1000;    //Player enters trigger's tile
    public const int SHOCK_TRIGGER_NULL = 1001;//Not set off automatically, must be explicitly activated by a switch or another trigger
    public const int SHOCK_TRIGGER_FLOOR = 1002;
    public const int SHOCK_TRIGGER_PLAYER_DEATH = 1003;
    public const int SHOCK_TRIGGER_DEATHWATCH = 1004;   //Object is destroyed / dies
    public const int SHOCK_TRIGGER_AOE_ENTRY = 1005;
    public const int SHOCK_TRIGGER_AOE_CONTINOUS = 1006;
    public const int SHOCK_TRIGGER_AI_HINT = 1007;
    public const int SHOCK_TRIGGER_LEVEL = 1008;    //Player enters level
    public const int SHOCK_TRIGGER_CONTINUOUS = 1009;
    public const int SHOCK_TRIGGER_REPULSOR = 1010; //Repulsor lift floor
    public const int SHOCK_TRIGGER_ECOLOGY = 1011;
    public const int SHOCK_TRIGGER_SHODAN = 1012;
    public const int SHOCK_TRIGGER_TRIPBEAM = 1013;
    public const int SHOCK_TRIGGER_BIOHAZARD = 1014;
    public const int SHOCK_TRIGGER_RADHAZARD = 1015;
    public const int SHOCK_TRIGGER_CHEMHAZARD = 1016;
    public const int SHOCK_TRIGGER_MAPNOTE = 1017;  //Map note placed by player (presumably)
    public const int SHOCK_TRIGGER_MUSIC = 1018;


    public const int ACTION_DO_NOTHING = 0;
    public const int ACTION_TRANSPORT_LEVEL = 1;
    public const int ACTION_RESURRECTION = 2;
    public const int ACTION_CLONE = 3;
    public const int ACTION_SET_VARIABLE = 4;
    public const int ACTION_ACTIVATE = 6;
    public const int ACTION_LIGHTING = 7;
    public const int ACTION_EFFECT = 8;
    public const int ACTION_MOVING_PLATFORM = 9;
    public const int ACTION_TIMER = 11; //This is an assumption
    public const int ACTION_CHOICE = 12;
    public const int ACTION_EMAIL = 15;
    public const int ACTION_RADAWAY = 16;
    public const int ACTION_CHANGE_STATE = 19;
    public const int ACTION_AWAKEN = 21;
    public const int ACTION_MESSAGE = 22;
    public const int ACTION_SPAWN = 23;
    public const int ACTION_CHANGE_TYPE = 24;




    public const int HEADINGNORTH = 180;
    public const int HEADINGSOUTH = 0;
    public const int HEADINGEAST = 270;
    public const int HEADINGWEST = 90;
    public const int HEADINGNORTHEAST = 225;
    public const int HEADINGSOUTHEAST = 315;
    public const int HEADINGNORTHWEST = 135;
    public const int HEADINGSOUTHWEST = 45;

    //UW Props

    [Header("UW Properties")]
    public int item_id; //0-8
    public short flags; //9-12
    public short enchantment;   //12
    public short doordir;   //13
    public short invis;     //14
    public short isquant;   //15

    public short zpos;    //  0- 6   7   "zpos"      Object Z position (0-127)
    public short heading;   //        7- 9   3   "heading"   Heading (*45 deg)
    public short x; //   10-12   3   "ypos"      Object Y position (0-7)
    public short y; //  13-15   3   "xpos"      Object X position (0-7)
                    //0004 quality / chain
    public short quality;   //;     0- 5   6   "quality"   Quality
    public int next; //    6-15   10  "next"      Index of next object in chain
                     //0006 link / special
                     //     0- 5   6   "owner"     Owner / special
    public short owner; //Also special
                        //     6-15   10  (*)         Quantity / special link / special property
    public int link;    //also quantity



    [Header("Display Settings")]
    /// <summary>
    /// The sprite index number to use when displaying this object in the game world.
    /// </summary>
    public int WorldDisplayIndex;

    /// <summary>
    /// The Sprite index number to use when displaying this object in the inventory. (Note that armour is handled differently on the paperdoll- Uses equip string from objectmasters)
    /// </summary>
    public int InvDisplayIndex;

    /// <summary>
    /// Ignores the sprite indices and just uses what it is generated with. Usually switches and signs that use tmobj.
    /// </summary>
    public bool ignoreSprite;//For button handlers that do their own sprite work.

    //Display controls
    private SpriteRenderer sr = null;
    //public bool isAnimated;
    public bool animationStarted;


    [Header("Interaction Options")]
    /// <summary>
    /// Indicates if the object can be used.
    /// </summary>
    //public bool CanBeUsed;

    /// <summary>
    /// Tells if object is in the inventory or in the open world in case there is different behaviours needed depending on the case.
    /// </summary>
    public bool PickedUp;

    /// <summary>
    /// The inventory slot that the object is in.
    /// </summary>
    public short inventorySlot = -1;
    //	public short InUseFlag;

    [Header("Positioning")]
    public short tileX; //Position of the object on the tilemap
    public short tileY;

    /// <summary>
    /// The start position of the object when it became awake.
    /// </summary>
    public Vector3 startPos;

    [Header("Links")]
    public AudioSource aud;
    public Rigidbody rg;


    public enum IdentificationFlags
    {
        Unidentified = 0,
        PartiallyIdentified = 1,
        Identified = 2
    };

    public ObjectLoaderInfo objectloaderinfo;

    void Start()
    {
        //isAnimated=false;
        animationStarted = false;
        sr = this.gameObject.GetComponentInChildren<SpriteRenderer>();
        startPos = this.transform.position;
        if (sr != null)
        {
            sr.gameObject.SetActive(invis == 0);
        }

    }

    void Update()
    {
        //if ((animationStarted==false) && (ignoreSprite==false) && (invis==0))
        if ((animationStarted == false) && (UseSprite() == false) && (invis == 0))
        {
            UpdateAnimation();
        }
        if (objectloaderinfo != null)
        {
            debugindex = objectloaderinfo.index;
        }
        else
        {
            debugindex = -1;
        }


        //if (this.transform.parent==GameWorldController.instance.DynamicObjectMarker())
        //{

        /*					if (PickedUp==false)
                            {
                                    short currTileX=tileX;
                                    short currTileY=tileY;	
                                    UpdatePosition();
                                    if ((currTileX!=tileX) || (currTileY!=tileY))
                                    {
                                        UpdateLinkedList(this, currTileX, currTileY, tileX, tileY);
                                    }	
                            }*/

        //}

    }

    /// <summary>
    /// Updates the linked list as objects move.
    /// </summary>
    /// <param name="obj">Object.</param>
    /// <param name="oldTileX">Old tile x.</param>
    /// <param name="oldTileY">Old tile y.</param>
    /// <param name="newTileX">New tile x.</param>
    /// <param name="newTileY">New tile y.</param>
    public static void UpdateLinkedList(ObjectInteraction obj, int oldTileX, int oldTileY, int newTileX, int newTileY)
    {
        return;
        bool MovingFromValidTile = TileMap.ValidTile(oldTileX, oldTileY);
        bool MovingToValidTile = TileMap.ValidTile(newTileX, newTileY);

        if (MovingFromValidTile && MovingToValidTile)
        {
            Debug.Log("Object traversing " + obj.name + "Tiles(" + oldTileX + "," + oldTileY + ") to (" + newTileX + "," + newTileY + ")");
            TileInfo tOld = GameWorldController.instance.currentTileMap().Tiles[oldTileX, oldTileY];
            TileInfo tNew = GameWorldController.instance.currentTileMap().Tiles[newTileX, newTileY];
            MoveFromLinkedListChain(obj, tOld);
            MoveToLinkedListChain(obj, tNew);
            return;
        }

        if (!MovingToValidTile && MovingFromValidTile)
        {//Object is probably moving off map.
            Debug.Log("Object moving off map " + obj.name + "Tiles(" + oldTileX + "," + oldTileY + ") to (" + newTileX + "," + newTileY + ")");
            TileInfo tOld = GameWorldController.instance.currentTileMap().Tiles[oldTileX, oldTileY];
            MoveFromLinkedListChain(obj, tOld);
            obj.next = 0;
            return;
        }

        if (MovingToValidTile && !MovingFromValidTile)
        {//Object moving from inv to world
            Debug.Log("Object moving on map " + obj.name + "Tiles(" + oldTileX + "," + oldTileY + ") to (" + newTileX + "," + newTileY + ")");
            TileInfo tNew = GameWorldController.instance.currentTileMap().Tiles[newTileX, newTileY];
            MoveToLinkedListChain(obj, tNew);
            return;
        }
        //This should probably not happen.
        if (
                ((newTileX == 99) && (newTileY == 99) && (oldTileX == -1) && (oldTileY == -1))//load game player inventory
                ||
                ((newTileX == 99) && (newTileY == 99) && (oldTileX == 99) && (oldTileY == 99))//Moving from offmap to inventory.
        )

        {
            return;
        }
        Debug.Log("Object moving to/from invalid tile " + obj.name + "Tiles(" + oldTileX + "," + oldTileY + ") to (" + newTileX + "," + newTileY + ")");



    }

    public static void MoveToLinkedListChain(ObjectInteraction obj, TileInfo tNew)
    {
        if (tNew.indexObjectList == 0)
        {
            tNew.indexObjectList = obj.objectloaderinfo.index;
            Debug.Log("Putting " + obj.name + " at head of tile (" + tNew.tileX + "," + tNew.tileY + ")");
        }
        else
        {
            //Traverse the object list to it's end and add the object to the last obj
            int index = tNew.indexObjectList;
            int breaker = 0;
            while ((index != 0) && (breaker <= 1024))
            {
                ObjectInteraction objChain = ObjectLoader.getObjectIntAt(index);
                if (objChain != null)
                {
                    if (objChain.objectloaderinfo.index != obj.objectloaderinfo.index)
                    {
                        if (objChain.next == 0)
                        {
                            //End of chai												
                            Debug.Log("Chaining " + obj.name + " to " + objChain.name);
                            objChain.next = obj.objectloaderinfo.index;
                            index = 0;
                        }
                        else
                        {
                            //Find next obj
                            index = objChain.next;
                        }
                    }
                    else
                    {//Obj is already in this chain. No action needed.
                        Debug.Log("object already in chain");
                        index = 0;
                    }

                }
                else
                {
                    Debug.Log("Null object in chain");
                    index = 0;
                }
                breaker++;
            }
            if (breaker >= 1024)
            {
                Debug.Log("This chain looped " + breaker + " times" + obj.name);
            }
        }
    }

    static void MoveFromLinkedListChain(ObjectInteraction obj, TileInfo tOld)
    {
        if (tOld.indexObjectList == obj.objectloaderinfo.index)
        {
            //Remove from the head of it's previous list
            tOld.indexObjectList = obj.next;
            Debug.Log("Removing " + obj.name + " at head of tile (" + tOld.tileX + "," + tOld.tileY + ")");
        }
        else
        {
            int breaker = 0;
            int index = tOld.indexObjectList;
            while ((index != 0) && (breaker <= 1024))
            {
                ObjectInteraction objChain = ObjectLoader.getObjectIntAt(index);
                if (objChain.next == obj.objectloaderinfo.index)
                {
                    //Found the object that links to this object. Set it's next to the that of the moving object
                    Debug.Log("DeChaining " + obj.name + " from " + objChain.name);
                    objChain.next = obj.next;
                    index = 0;
                }
                else
                {
                    if (index != objChain.next)
                    {
                        index = objChain.next;
                    }
                    else
                    {
                        Debug.Log("possibly looping chaing");
                        index = 0;
                    }

                }
                breaker++;
            }
            if (breaker >= 1024)
            {
                Debug.Log("This chain looped " + breaker + " times (MoveFromLinkedListChain)");
            }
        }
    }

    public void UpdateAnimation()
    {
        if (sr == null)
        {
            sr = this.GetComponentInChildren<SpriteRenderer>();
        }
        if (sr != null)
        {
            //sr.sprite= tc.RequestSprite(WorldDisplayIndex,isAnimated);
            switch (_RES)
            {
                case GAME_SHOCK:
                    sr.sprite = GameWorldController.instance.ObjectArt.RequestSprite(WorldDisplayIndex, GameWorldController.instance.ShockObjProp.properties[item_id].Offset);
                    break;
                default:
                    sr.sprite = GameWorldController.instance.ObjectArt.RequestSprite(WorldDisplayIndex);
                    break;
            }

            if (inventorySlot != -1)
            {
                UWCharacter.Instance.playerInventory.Refresh(inventorySlot);
            }
            animationStarted = true;
        }
    }

    public Sprite GetInventoryDisplay()
    {
        //return tc.RequestSprite(InvDisplayIndex,isAnimated);
        return GameWorldController.instance.ObjectArt.RequestSprite(InvDisplayIndex);
    }

    public Sprite GetEquipDisplay()
    {
        return this.GetComponent<object_base>().GetEquipDisplay();
        //return GameWorldController.instance.ObjectArt.RequestSprite(InvDisplayIndex);
        //return  tc.RequestSprite(GetEquipString());
    }

    /*public string GetEquipString()
    {
        return this.GetComponent<object_base>().getEquipString();
    }*/

    public Sprite GetWorldDisplay()
    {
        return sr.sprite;
    }

    public void SetWorldDisplay(Sprite NewSprite)
    {
        if (sr != null)
        {
            sr.sprite = NewSprite;
        }
    }

    public void RefreshAnim()
    {
        animationStarted = false;
    }

    /// <summary>
    /// Gets the type of the item from object masters. UWE object type codes.
    /// </summary>
    /// <returns>The item type.</returns>
    public int GetItemType()
    {
        return GameWorldController.instance.objectMaster.objProp[item_id].type;
    }

    /// <summary>
    /// Applies an attack to this object
    /// </summary>
    /// <param name="damage">Damage.</param>
    /// <param name="source">Source.</param>
    public bool Attack(short damage, GameObject source)
    {
        this.GetComponent<object_base>().ApplyAttack(damage, source);
        return true;
    }

    /// <summary>
    /// Looks the description to be displayed in a context menu.
    /// </summary>
    /// <returns>The context menu description</returns>
    public string LookDescriptionContext()
    {
        object_base item;
        item = this.GetComponent<object_base>();
        if (item != null)
        {
            return item.GetContextMenuText(item_id, isUsable() && WindowDetect.ContextUIUse, CanBePickedUp() && WindowDetect.ContextUIUse, ((UWCharacter.Instance.playerInventory.ObjectInHand) != "" && (UWCharacter.InteractionMode != UWCharacter.InteractionModePickup)));
        }
        else
        {
            return "";
        }
    }

    /// <summary>
    /// Gets the verb for using the object
    /// </summary>
    /// <returns>The verb.</returns>
    public string UseVerb()
    {
        return this.GetComponent<object_base>().UseVerb();
    }

    /// <summary>
    /// Gets the verb for picking up the object
    /// </summary>
    /// <returns>The verb.</returns>
    public string PickupVerb()
    {
        return this.GetComponent<object_base>().PickupVerb();
    }

    /// <summary>
    /// Gets the verb for examining the object
    /// </summary>
    /// <returns>The verb.</returns>
    public string ExamineVerb()
    {
        return this.GetComponent<object_base>().ExamineVerb();
    }

    /// <summary>
    /// Gets the verb for when another object is being used on the object when in the world
    /// </summary>
    /// <returns>The verb</returns>
    public string UseObjectOnVerb_World()
    {
        return this.GetComponent<object_base>().UseObjectOnVerb_World();
    }

    /// <summary>
    /// Gets the verb for when another object is being used on the object when in the inventory
    /// </summary>
    /// <returns>The verb<returns>
    public string UseObjectOnVerb_Inv()
    {
        return this.GetComponent<object_base>().UseObjectOnVerb_Inv();
    }

    /// <summary>
    /// Returns the look description on the object
    /// </summary>
    /// <returns><c>true</c>, if description was looked at <c>false</c> otherwise.</returns>
    public bool LookDescription()
    {//Returns the description of this object.
        object_base item;
        item = this.GetComponent<object_base>();

        if (item != null)
        {
            return (item.LookAt());
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Uses the object
    /// </summary>
    public bool Use()
    {//Code to activate objects by type.
     //Objects will return true if they have done everything that needs to be done and false if they expect the calling code to do something instead.
        GameObject ObjectInHand = UWCharacter.Instance.playerInventory.GetGameObjectInHand();
        object_base item = this.GetComponent<object_base>();//Base object class

        if (ObjectInHand != null)
        {
            //First do a combineobject test. This will implement object combinatiosn defined by UW1/2
            GameObject combined = CombineObject(this.gameObject, ObjectInHand);
            if (combined != null)
            {
                UWCharacter.Instance.playerInventory.ObjectInHand = combined.name;
                return true;
            }
        }

        if (item != null)
        {
            return item.use();
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Picks up the object and processes related events
    /// </summary>
    public bool Pickup()
    {
        object_base item = null;
        item = this.GetComponent<object_base>();
        if (TileMap.ValidTile(tileX, tileY))
        {
            if (GameWorldController.instance.currentTileMap().Tiles[tileX, tileY].PressureTriggerIndex != 0)
            {
                ObjectInteraction obj = ObjectLoader.getObjectIntAt(GameWorldController.instance.currentTileMap().Tiles[tileX, tileY].PressureTriggerIndex);
                if (obj.GetComponent<a_pressure_trigger>() != null)
                {
                    obj.GetComponent<a_pressure_trigger>().ReleaseWeightFrom();
                }
            }
        }

        if (item != null)
        {
            return (item.PickupEvent());
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Events to call when the object is dropped and thrown in the world..
    /// </summary>
    public bool Drop()
    {
        object_base item = null;
        item = this.GetComponent<object_base>();
        if (item != null)
        {
            return (item.DropEvent());
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// What happens when the item is put away.
    /// </summary>
    /// <returns><c>true</c>, if item away was put, <c>false</c> otherwise.</returns>
    /// <param name="SlotNo">Slot no.</param>
    public bool PutItemAway(short SlotNo)
    {//What happens when an item is put into a backpack
        inventorySlot = SlotNo;
        object_base item = null;
        item = this.GetComponent<object_base>();
        if (item != null)
        {
            return (item.PutItemAwayEvent(SlotNo));
        }
        else
        {
            return false;
        }
    }


    /// <summary>
    /// What happens when the item is equipped
    /// </summary>
    /// <param name="SlotNo">Slot no.</param>
    public bool Equip(short SlotNo)
    {//To handle what happens when an item (typically armour is equipped
        object_base item = this.GetComponent<object_base>();
        inventorySlot = SlotNo;
        if (item != null)
        {
            return (item.EquipEvent(SlotNo));
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    /// What happens when the item is unequipped
    /// </summary>
    /// <returns><c>true</c>, if equip was uned, <c>false</c> otherwise.</returns>
    /// <param name="SlotNo">Slot no.</param>
    public bool UnEquip(short SlotNo)
    {//To handle what happens when an item (typically armour is unequipped
        object_base item = this.GetComponent<object_base>();
        inventorySlot = -1;

        if (item != null)
        {
            return (item.UnEquipEvent(SlotNo));
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// What happens when the item is talked to
    /// </summary>
    /// <returns><c>true</c>, if to was talked, <c>false</c> otherwise.</returns>
    public bool TalkTo()
    {
        object_base item = this.GetComponent<object_base>();
        return item.TalkTo();
    }

    /// <summary>
    /// Failure message for actions that can't be completed
    /// </summary>
    /// <returns><c>true</c>, if message was failed, <c>false</c> otherwise.</returns>
    public bool FailMessage()
    {
        object_base objbase = this.GetComponent<object_base>();
        return objbase.FailMessage();
    }

    /// <summary>
    /// Combines two objects per the UW1/UW2 cmb.dat lists
    /// </summary>
    /// <returns>The object.</returns>
    /// <param name="InputObject1">Input object 1.</param>
    /// <param name="InputObject2">Input object 2.</param>
    public GameObject CombineObject(GameObject InputObject1, GameObject InputObject2)
    {
        int[] lstInput1 = new int[8];
        int[] lstInput2 = new int[8];
        int[] lstOutput = new int[8];
        int[] lstDestroy1 = new int[8];
        int[] lstDestroy2 = new int[8];
        int ItemID1 = InputObject1.GetComponent<ObjectInteraction>().item_id;
        int ItemID2 = InputObject2.GetComponent<ObjectInteraction>().item_id;
        bool Destroyed1 = false;
        bool Destroyed2 = false;
        //UW1 List
        // a_lit_torch(149)(d:0) + a_block_of_incense_blocks_of_incense(278)(d:1) = a_block_of_burning_incense_blocks_of_burning_incense(277)
        // the_Key_of_Truth(225)(d:1) + the_Key_of_Love(226)(d:1) = a_two_part_key(230)
        // the_Key_of_Truth(225)(d:1) + the_Key_of_Courage(227)(d:1) = a_two_part_key(228)
        // the_Key_of_Love(226)(d:1) + the_Key_of_Courage(227)(d:1) = a_two_part_key(229)
        // the_Key_of_Truth(225)(d:1) + a_two_part_key(229)(d:1) = the_Key_of_Infinity(231)
        // the_Key_of_Love(226)(d:1) + a_two_part_key(228)(d:1) = the_Key_of_Infinity(231)
        // the_Key_of_Courage(227)(d:1) + a_two_part_key(230)(d:1) = the_Key_of_Infinity(231)
        // a_lit_torch(149)(d:0) + an_ear_of_corn_ears_of_corn(180)(d:1) = some_popcorn_bunches_of_popcorn(183)
        // some_strong_thread_pieces_of_strong_thread(284)(d:1) + a_pole(216)(d:1) = a_fishing_pole(299)

        //UW2 List
        //a_pole(216)(d:1) + some_thread&pieces_of_thread(300)(d:1) = a_fishing_pole(299)
        //some_thread&pieces_of_thread(300)(d:1) + a_lump_of_wax&lumps_of_wax(210)(d:1) = a_candle(146)
        //a_lit_torch(149)(d:0) + an_ear_of_corn&ears_of_corn(180)(d:1) = some_popcorn&bunches_of_popcorn(183)
        //a_lit_torch(149)(d:0) + a_honeycomb(186)(d:1) = a_lump_of_wax&lumps_of_wax(210)
        //a_nutritious_wafer(191)(d:1) + a_bottle_of_water&bottles_of_water(188)(d:1) = a_bottle_of_ale&bottles_of_ale(187)

        //Debug.Log ("combining" +ItemID1 + " and " + ItemID2 + " in game " + playerUW.game);
        switch (_RES)
        //switch (GameWorldController.instance.game.ToUpper())
        {
            case GAME_UWDEMO:
            case GAME_UW1://uw1
                {
                    lstInput1 = new int[9] { 149, 225, 225, 226, 225, 226, 227, 149, 284 };
                    lstDestroy1 = new int[9] { 0, 1, 1, 1, 1, 1, 1, 0, 1 };
                    lstInput2 = new int[9] { 278, 226, 227, 227, 229, 228, 230, 180, 216 };
                    lstDestroy2 = new int[9] { 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                    lstOutput = new int[9] { 277, 230, 228, 229, 231, 231, 231, 183, 299 };
                }
                break;
            case GAME_UW2://uw2
                lstInput1 = new int[5] { 216, 300, 149, 149, 191 };
                lstDestroy1 = new int[5] { 1, 1, 0, 0, 1 };
                lstInput2 = new int[5] { 300, 300, 180, 186, 188 };
                lstDestroy2 = new int[5] { 1, 1, 1, 1, 1 };
                lstOutput = new int[5] { 299, 146, 183, 210, 187 };
                break;
        }

        for (int i = 0; i <= lstInput1.GetUpperBound(0); i++)
        {
            //Debug.Log (i + " is " + lstInput1[i] + " and " + lstInput2[i]);
            if
                (//Check both input lists for the two items
                    ((ItemID1 == lstInput1[i]) && (ItemID2 == lstInput2[i]))
                    ||
                    ((ItemID2 == lstInput1[i]) && (ItemID1 == lstInput2[i]))
                )
            {//Matching combination.
                Debug.Log("Creating a " + lstOutput[i]);
                if ((lstInput1[i] == ItemID1) && (lstDestroy1[i] == 1) && (Destroyed1 == false))
                {
                    Debug.Log("Destroying " + InputObject1.name);
                    Destroyed1 = true;
                }
                if ((lstInput1[i] == ItemID2) && (lstDestroy1[i] == 1) && (Destroyed2 == false))
                {
                    Debug.Log("Destroying " + InputObject2.name);
                    Destroyed2 = true;
                }
                if ((lstInput2[i] == ItemID1) && (lstDestroy2[i] == 1) && (Destroyed1 == false))
                {
                    Debug.Log("Destroying " + InputObject1.name);
                    Destroyed1 = true;
                }
                if ((lstInput2[i] == ItemID2) && (lstDestroy2[i] == 1) && (Destroyed2 == false))
                {
                    Debug.Log("Destroying " + InputObject2.name);
                    Destroyed2 = true;
                }

                if (Destroyed1 == true)
                {
                    InputObject1.GetComponent<ObjectInteraction>().consumeObject();
                }
                if (Destroyed2 == true)
                {
                    InputObject2.GetComponent<ObjectInteraction>().consumeObject();
                }

                ObjectLoaderInfo newobjt = ObjectLoader.newObject(lstOutput[i], 40, 0, 0, 256);
                GameObject Created = ObjectInteraction.CreateNewObject(GameWorldController.instance.currentTileMap(), newobjt, GameWorldController.instance.CurrentObjectList().objInfo, GameWorldController.instance.InventoryMarker.gameObject, GameWorldController.instance.InventoryMarker.transform.position).gameObject;
                GameWorldController.MoveToInventory(Created);
                UWCharacter.InteractionMode = UWCharacter.InteractionModePickup;
                if (Created != null)
                {
                    Created.GetComponent<ObjectInteraction>().UpdateAnimation();
                    Created.GetComponent<ObjectInteraction>().PickedUp = true;
                    UWHUD.instance.CursorIcon = Created.GetComponent<ObjectInteraction>().GetInventoryDisplay().texture;
                }
                InteractionModeControl.UpdateNow = true;
                return Created;

                /*
    ObjectInteraction CreatedObjectInt = CreateNewObject (lstOutput[i]);
    if (CreatedObjectInt != null) {
            CreatedObjectInt.UpdateAnimation ();
            CreatedObjectInt.PickedUp=true;
            UWHUD.instance.CursorIcon = CreatedObjectInt.GetInventoryDisplay ().texture;
    }
    UWCharacter.InteractionMode=UWCharacter.InteractionModePickup;
    InteractionModeControl.UpdateNow=true;
    return CreatedObjectInt.gameObject;
    */
            }
        }

        return null;
    }

    /// <summary>
    /// Uses up and destroys a single instance of the object. (eg if it was eaten
    /// </summary>
    public void consumeObject()
    {
        if ((isQuant() == false) || ((isQuant()) && (link == 1)) || (isEnchanted() == true))
        {//the last of the item or is not a quantity;
            Container cn = UWCharacter.Instance.playerInventory.GetCurrentContainer();
            //Code for objects that get destroyed when they are used. Eg food, potion, fuel etc
            if (!cn.RemoveItemFromContainer(this.name))
            {//Try and remove from the paperdoll if not found in the current container.
                UWCharacter.Instance.playerInventory.RemoveItemFromEquipment(this.name);
            }
            if (UWCharacter.Instance.playerInventory.ObjectInHand == this.name)
            {
                UWCharacter.Instance.playerInventory.ObjectInHand = "";//Make sure there is not instance of this object in the players hand	
                UWHUD.instance.CursorIcon = UWHUD.instance.CursorIconDefault;
            }
            UWCharacter.Instance.playerInventory.Refresh();
            objectloaderinfo.InUseFlag = 0;//Free up the slot
                                           //if (PickedUp==false)
                                           //{
                                           //	UpdateLinkedList(this, tileX,tileY, TileMap.ObjectStorageTile, TileMap.ObjectStorageTile);
                                           //}
            Destroy(this.gameObject);
        }
        else
        {//just decrement the quantity value;
            link--;
            ObjectInteraction.Split(this);
            UWCharacter.Instance.playerInventory.Refresh();
        }
    }

    /// <summary>
    /// What image frames does an weapon hit on this object create.
    /// </summary>
    /// <returns>The hit frame start.</returns>
    public int GetHitFrameStart()
    {

        if (this.GetComponent<NPC>() == null)
        {
            return 45;//Standard explosion
        }
        else
        {
            switch (GameWorldController.instance.objDat.critterStats[item_id - 64].Blood)
            {
                //Mask 0x0F is the splatter type, 0 for dust, 8 for red blood.
                case 0:
                    return 45;

                case 8://blood
                default:
                    return 0;

            }
        }
    }

    /// <summary>
    /// What image frames does an weapon hit on this object create.
    /// </summary>
    /// <returns>The hit frame end.</returns>
    public int GetHitFrameEnd()
    {
        if (this.GetComponent<NPC>() == null)
        {
            return 49;//End of explosion
        }
        else
        {
            switch (GameWorldController.instance.objDat.critterStats[item_id - 64].Blood)
            {
                //Mask 0x0F is the splatter type, 0 for dust, 8 for red blood.
                case 0:
                    return 49;

                case 8://blood
                default:
                    return 5;
            }
        }
    }

    /// <summary>
    /// Gets the true quantity of the object stack
    /// </summary>
    /// <returns>The qty.</returns>
    public int GetQty()
    {//Gets the true quantity of this object
        if ((isEnchanted() == true) || (this.GetComponent<Readable>() != null))
        {
            return 1;
        }
        else
        {
            if (isQuant() == true)
            {
                return link;
            }
            else
            {
                return 1;
            }
        }
    }


    /// <summary>
    /// Gets the weight of the object stack
    /// </summary>
    /// <returns>The weight.</returns>
    public float GetWeight()
    {//Return the weight of the object stack
        return this.GetComponent<object_base>().GetWeight();
    }

    /// <summary>
    /// Creates the object graphics and sprites for this object
    /// </summary>
    /// <returns>The object graphics.</returns>
    /// <param name="myObj">My object.</param>
    /// <param name="AssetPath">Asset path.</param>
    /// <param name="BillBoard">If set to <c>true</c> bill board.</param>
    public static GameObject CreateObjectGraphics(GameObject myObj, string AssetPath, bool BillBoard)
    {
        //Create a sprite.
        GameObject SpriteController = new GameObject("_sprite");
        SpriteController.transform.position = myObj.transform.position;
        SpriteRenderer mysprite = SpriteController.AddComponent<SpriteRenderer>();//Adds the sprite gameobject
        Sprite image = Resources.Load<Sprite>(AssetPath);//Loads the sprite.
        mysprite.sprite = image;//Assigns the sprite to the object.
        SpriteController.transform.parent = myObj.transform;
        SpriteController.transform.Rotate(0f, 0f, 0f);
        SpriteController.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
        mysprite.material = Resources.Load<Material>("Materials/SpriteShader");
        //Create a billboard script for display
        if (BillBoard)
        {
            SpriteController.AddComponent<Billboard>();
        }
        return SpriteController;
    }


    /// <summary>
    /// Creates the object interaction.
    /// </summary>
    /// <returns>The object interaction.</returns>
    /// <param name="myObj">My object.</param>
    /// <param name="DimX">Dim x.</param>
    /// <param name="DimY">Dim y.</param>
    /// <param name="DimZ">Dim z.</param>
    /// <param name="Worldindex">Worldindex.</param>
    /// <param name="InventoryIndex">Inventory index.</param>
    /// <param name="EquipIndex">Equip index.</param>
    /// <param name="ItemType">Item type.</param>
    /// <param name="ItemId">Item identifier.</param>
    /// <param name="link">Link.</param>
    /// <param name="Quality">Quality.</param>
    /// <param name="Owner">Owner.</param>
    /// <param name="isMoveable">Is moveable.</param>
    /// <param name="isUsable">Is usable.</param>
    /// <param name="isAnimated">Is animated.</param>
    /// <param name="useSprite">Use sprite.</param>
    /// <param name="isQuant">Is quant.</param>
    /// <param name="isEnchanted">Is enchanted.</param>
    /// <param name="flags">Flags.</param>
    /// <param name="inUseFlag">In use flag.</param>
    private static ObjectInteraction CreateObjectInteraction(
            GameObject myObj, float DimX, float DimY, float DimZ,
            ObjectLoaderInfo currObj
          //int Worldindex, int InventoryIndex, int EquipIndex, int ItemType, 
          // int ItemId, int link, int Quality, int Owner, 
          //int isMoveable, int isUsable, int isAnimated, int useSprite, 
          //  int isQuant, int isEnchanted, int flags, int inUseFlag
          )
    {
        ObjectInteraction objInteract = myObj.AddComponent<ObjectInteraction>();
        // ObjectMasters.ObjectProperties ObjectMasterProperties = GameWorldController.instance.objectMaster.objProp[currobj.ItemId];

        BoxCollider box = myObj.GetComponent<BoxCollider>();


        if (
                (box == null)
                && (objInteract.GetItemType() != ObjectInteraction.NPC_TYPE)
                && (objInteract.isUsable())
            )
        {
            //add a mesh for interaction
            box = myObj.AddComponent<BoxCollider>();
            box.size = new Vector3(0.2f, 0.2f, 0.2f);
            box.center = new Vector3(0.0f, 0.08f, 0.0f);
            if (objInteract.isMoveable())
            {
                box.material = Resources.Load<PhysicMaterial>("Materials/objects_bounce");
            }
        }

        objInteract.WorldDisplayIndex = objInteract.WorldIndex();// int.Parse(WorldString.Substring (WorldString.Length-3,3));
        objInteract.InvDisplayIndex = objInteract.InventoryIndex();//int.Parse (InventoryString.Substring (InventoryString.Length-3,3));

        //if (isUsable())
        //{
        //	objInteract.CanBeUsed=true;
        //}

        objInteract.item_id = currObj.item_id;//Internal ItemID
        objInteract.link = currObj.link;
        objInteract.quality = (short)currObj.quality;
        objInteract.owner = (short)currObj.owner;
        objInteract.flags = (short)currObj.flags;

        if (objInteract.isMoveable())
        {
            //objInteract.CanBePickedUp=true;
            objInteract.rg = myObj.AddComponent<Rigidbody>();

            objInteract.rg.angularDrag = 0.0f;
            GameWorldController.FreezeMovement(myObj);
        }

        /*   if (objInteract.GetItemType() != ObjectInteraction.ANIMATION)
           {
              /* if (isAnimated == 1)
               {
                   objInteract.isAnimated = true;
               }*/

        /*    if (objInteract.UseSprite())
            {
                objInteract.ignoreSprite = false;
            }
            else
            {
                objInteract.ignoreSprite = true;
            }
        }
        else
        {
            objInteract.ignoreSprite = true;
        }*/
        objInteract.isquant = (short)currObj.is_quant;
        //if (isQuant==1)
        //{
        //	objInteract.isquant=1;
        //}
        //else
        //{
        //	objInteract.isquant=0;
        //}
        //if (isEnchanted==1)
        //{
        objInteract.enchantment = (short)currObj.enchantment;
        //Debug.Log (myObj.name + " is enchanted. Take a look at it please.");
        //}

        if (PlaySoundEffects)
        {
            objInteract.aud = myObj.AddComponent<AudioSource>();
            objInteract.aud.maxDistance = 3f;//TODO:Tweak this distance
            objInteract.aud.spatialBlend = 1f;
        }
        return objInteract;
    }

    /// <summary>
    /// Gets an item id of an identical item type. Eg coins and coin
    /// </summary>
    /// <returns>The item identifier.</returns>
    public int AliasItemId()
    {
        return this.GetComponent<object_base>().AliasItemId();
    }

    //Returns another possible item id for the item duplicate of above?
    public static int Alias(int id)
    {
        switch (id)
        {
            case 160:
                return 161;
            case 161:
                return 160;
            default:
                return id;
        }
    }

    /// <summary>
    /// Determines whether this instance is a stackable object type.
    /// </summary>
    /// <returns><c>true</c> if this instance is stackable; otherwise, <c>false</c>.</returns>
    public bool IsStackable()
    {//An object is stackable if it has the isQuant flag and is not enchanted.
        return ((isQuant()) && (!isEnchanted()));
    }

    /// <summary>
    /// Determines if the two items can be merged into a stack
    /// </summary>
    /// <returns><c>true</c> if can merge the specified mergingInto mergingFrom; otherwise, <c>false</c>.</returns>
    /// <param name="mergingInto">Merging into.</param>
    /// <param name="mergingFrom">Merging from.</param>
    public static bool CanMerge(ObjectInteraction mergingInto, ObjectInteraction mergingFrom)
    {
        return (
                (
                    (mergingInto.item_id == mergingFrom.item_id)
                    ||
                    (mergingInto.AliasItemId() == mergingFrom.item_id)
                    ||
                    (mergingInto.item_id == mergingFrom.AliasItemId())
                )
                &&
                (mergingInto.quality == mergingFrom.quality)
                &&
                    (
                        (  //Only merge keys if they have the same owner
                            (mergingInto.GetItemType() == ObjectInteraction.KEY)
                            &&
                            (mergingFrom.GetItemType() == ObjectInteraction.KEY)
                            &&
                            (mergingInto.owner == mergingFrom.owner)
                        )
                        ||
                        (
                            (mergingInto.GetItemType() != ObjectInteraction.KEY)
                            ||
                            (mergingFrom.GetItemType() != ObjectInteraction.KEY)
                        )
                    )
        );
    }


    /// <summary>
    /// Merges the two items together. 
    /// </summary>
    /// <param name="mergingInto">Merging into.</param>
    /// <param name="mergingFrom">Merging from. This will be destroyed</param>
    public static void Merge(ObjectInteraction mergingInto, ObjectInteraction mergingFrom)
    {
        mergingInto.link += mergingFrom.link;
        mergingInto.isquant = 1;
        mergingInto.GetComponent<object_base>().MergeEvent();
        mergingFrom.objectloaderinfo.InUseFlag = 0;
        Destroy(mergingFrom.gameObject);
    }

    /// <summary>
    /// Events for when two items are split apart. (coins mainly)
    /// </summary>
    /// <param name="splitFrom">Split from.</param>
    /// <param name="splitTo">Split to.</param>
    public static void Split(ObjectInteraction splitFrom, ObjectInteraction splitTo)
    {
        splitFrom.GetComponent<object_base>().Split();
        splitTo.GetComponent<object_base>().Split();
    }

    /// <summary>
    /// Split the specified item.
    /// </summary>
    /// <param name="splitFrom">Split from.</param>
    public static void Split(ObjectInteraction splitFrom)
    {
        splitFrom.GetComponent<object_base>().Split();
    }

    /// <summary>
    /// Changes the type of this object
    /// </summary>
    /// <returns><c>true</c>, if type was changed, <c>false</c> otherwise.</returns>
    /// <param name="newID">New ID.</param>
    /// <param name="newType">New type.</param>
    public virtual bool ChangeType(int newID, int newType)
    {//Changes the type of the object. Eg when destroyed and it needs to become debris.
        item_id = newID;
        WorldDisplayIndex = newID;
        InvDisplayIndex = newID;
        UpdateAnimation();
        return true;
    }



    //public static void CreateNPC(GameObject myObj, string NPC_ID, string EditorSprite ,int npc_whoami)
    /// <summary>
    /// Creates the NPC entity.
    /// </summary>
    /// <param name="myObj">My object.</param>
    /// <param name="objInt">Object int.</param>
    /// <param name="objI">Object i.</param>
    public static NPC CreateNPC(GameObject myObj, ObjectInteraction objInt, ObjectLoaderInfo objI)
    {
        myObj.layer = LayerMask.NameToLayer("NPCs");
        myObj.tag = "NPCs";
        NPC npc = myObj.AddComponent<NPC>();
        //Probably only need to add this when an NPC supports ranged attacks?
        GameObject NpcLauncher = new GameObject(myObj.name + "_NPC_Launcher");
        NpcLauncher.transform.position = Vector3.zero;
        NpcLauncher.transform.parent = myObj.transform;
        NpcLauncher.transform.localPosition = new Vector3(0.0f, 0.5f, 0.3f);
        npc.NPC_Launcher = NpcLauncher;
        GameObject newObj = new GameObject("_Sprite");
        newObj.transform.parent = myObj.transform;
        newObj.transform.position = myObj.transform.position;
        newObj.AddComponent<BillboardNPC>();
        SpriteRenderer mysprite = newObj.AddComponent<SpriteRenderer>();
        switch (Loader._RES)
        {
            case Loader.GAME_UW2:
                mysprite.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);//Scale up sprites.
                break;
            default:
                mysprite.transform.localScale = new Vector3(2f, 2f, 2f);//Scale up sprites.
                break;
        }

        mysprite.material = Resources.Load<Material>("Materials/SpriteShader");

        CharacterController cap = myObj.AddComponent<CharacterController>();
        cap = myObj.GetComponent<CharacterController>();
        switch (objInt.item_id)
        {//TODO:These are UW1 settings
            case 97: //a_ghost
            case 99: //a_ghoul
            case 100: //a_ghost
            case 101: //a_ghost
            case 105: //a_dark_ghoul
            case 110: //a_ghoul	
            case 113: //a_dire_ghost
                npc.isUndead = true;
                break;
        }

        switch (objInt.item_id)
        {

            //Big
            case 70: //a_goblin
            case 71: //a_goblin
            case 74: //a_skeleton
            case 76: //a_goblin
            case 77: //a_goblin
            case 78: //a_goblin
            case 79: //etherealvoidcreatures
            case 80: //a_goblin
            case 84: //a_mountainman_mountainmen
            case 85: //a_green_lizardman_green_lizardmen
            case 86: //a_mountainman_mountainmen
            case 88: //a_red_lizardman_red_lizardmen
            case 89: //a_gray_lizardman_red_lizardmen
            case 90: //an_outcast
            case 91: //a_headless_headlesses
            case 93: //a_fighter
            case 94: //a_fighter
            case 95: //a_fighter
            case 96: //a_troll
            case 97: //a_ghost
            case 98: //a_fighter
            case 99: //a_ghoul
            case 100: //a_ghost
            case 101: //a_ghost
            case 103: //a_mage
            case 104: //a_fighter
            case 105: //a_dark_ghoul
            case 106: //a_mage
            case 107: //a_mage
            case 108: //a_mage
            case 109: //a_mage
            case 110: //a_ghoul
            case 111: //a_feral_troll
            case 112: //a_great_troll
            case 113: //a_dire_ghost
            case 114: //an_earth_golem
            case 115: //a_mage
            case 116: //a_deep_lurker
            case 117: //a_shadow_beast
            case 118: //a_reaper
            case 119: //a_stone_golem
            case 120: //a_fire_elemental
            case 121: //a_metal_golem
            case 123: //tybal
            case 124: //slasher_of_veils
            case 125: //unknown
            case 126: //unknown
                cap.isTrigger = false;
                cap.center = new Vector3(0.0f, 0.55f, 0.0f);
                cap.radius = 0.3f;
                cap.height = 1.0f;
                cap.skinWidth = 0.02f;
                NpcLauncher.transform.localPosition = new Vector3(0.0f, 0.5f, 0.2f);
                break;

            //Medium
            case 68: //a_giant_spider
            case 67: //a_giant_rat
            case 72: //a_giant_rat
            case 75: //an_imp
            case 81: //a_mongbat
            case 83: //a_wolf_spider
            case 92: //a_dread_spider
            case 102: //a_gazer
                cap.isTrigger = false;
                cap.center = new Vector3(0.0f, 0.3f, 0.0f);
                cap.radius = 0.3f;
                cap.height = 0.7f;
                cap.skinWidth = 0.02f;
                NpcLauncher.transform.localPosition = new Vector3(0.0f, 0.3f, 0.2f);
                break;
            //Small
            case 64: //a_rotworm
            case 65: //a_flesh_slug
            case 66: //a_cave_bat
            case 69: //a_acid_slug
            case 73: //a_vampire_bat
            case 82: //a_bloodworm
            case 87: //a_lurker
            case 122: //a_wisp
                cap.isTrigger = false;
                cap.center = new Vector3(0.0f, 0.3f, 0.0f);
                NpcLauncher.transform.localPosition = new Vector3(0.0f, 0.15f, 0.2f);
                cap.radius = 0.3f;
                cap.height = 0.6f;
                cap.skinWidth = 0.02f;
                break;
        }

        cap.stepOffset = 0.1f;//Stop npcs from climbing over each other

        //Set enemies who can cast spells.
        //TODO: update for UW2
        switch (objInt.item_id)
        {
            case 103: //a_mage
            case 106: //a_mage
            case 107: //a_mage
            case 108: //a_mage
            case 109: //a_mage
            case 110: //a_ghoul
            case 115: //a_mage
            case 120: //A fire elemental
            case 123: //tybal
            case 75: //an_imp
            case 81: //a_mongbat
            case 102: //a_gazer
            case 69: //a_acid_slug
            case 122: //a_wisp
                npc.MagicAttack = true;
                break;
            default:
                npc.MagicAttack = false;
                break;
        }

        return npc;
    }

    /*	public static void SetNPCProps(GameObject myObj, 
				int npc_whoami, int npc_xhome, int npc_yhome,
				int npc_hunger, int npc_health,
				int npc_hp, int npc_arms, int npc_power ,
				int npc_goal, int npc_attitude, int npc_gtarg,
				int npc_talkedto, int npc_level,int npc_name,
				string NavMeshRegion
		)
		{
				SetNPCProps(myObj, 
						npc_whoami, npc_xhome, npc_yhome,
						npc_hunger, npc_health,
						npc_hp, npc_arms, npc_power ,
						npc_goal, npc_attitude, npc_gtarg,
						npc_talkedto, npc_level,npc_name,
						"",
						NavMeshRegion
				)	;
		}*/


    /*public static void SetNPCProps(GameObject myObj, 
            int npc_whoami, int npc_xhome, int npc_yhome,
            int npc_hunger, int npc_health,
            int npc_hp, int npc_arms, int npc_power ,
            int npc_goal, int npc_attitude, int npc_gtarg,
            int npc_talkedto, int npc_level,int npc_name,
            string gtargName,
            string NavMeshRegion
    )*/

    /// <summary>
    /// Sets the NPC properties.
    /// </summary>
    /// <param name="myObj">My object.</param>
    /// <param name="objInt">Object int.</param>
    /// <param name="objI">Object i.</param>
    public static void SetMobileProps(GameObject myObj, object_base npc, ObjectInteraction objInt, ObjectLoaderInfo objI)
    {
        //NPC npc = myObj.GetComponent<NPC>();
        if (npc != null)
        {
            npc.npc_whoami = objI.npc_whoami;
            npc.npc_voidanim = objI.npc_voidanim;
            npc.npc_xhome = objI.npc_xhome;        //  x coord of home tile
            npc.npc_yhome = objI.npc_yhome;        //  y coord of home tile
            npc.npc_hunger = objI.npc_hunger;
            npc.npc_health = objI.npc_health;
            npc.npc_hp = objI.npc_hp;
            npc.npc_arms = objI.npc_arms;          // (not used in uw1)
            npc.npc_power = objI.npc_power;
            npc.npc_goal = objI.npc_goal;          // goal that NPC has; 5:kill player 6:? 9:?
            npc.npc_attitude = objI.npc_attitude;       //attitude; 0:hostile, 1:upset, 2:mellow, 3:friendly
            npc.npc_gtarg = objI.npc_gtarg;         //goal target; 1:player
            npc.npc_talkedto = objI.npc_talkedto;      // is 1 when player already talked to npc
            npc.npc_level = objI.npc_level;
            npc.npc_name = objI.npc_name;       //    (not used in uw1)
                                                //npc.NavMeshRegion=NavMeshRegion;
            npc.npc_heading = objI.npc_heading;
            //npc.gtargName=gtargName;
            npc.Projectile_Speed = objI.Projectile_Speed;
            npc.Projectile_Pitch = objI.Projectile_Pitch;
            npc.ProjectileHeadingMinor = objI.ProjectileHeadingMinor;
            npc.npc_height = objI.npc_height;

            npc.ProjectileHeadingMajor = objI.ProjectileHeadingMajor;
            npc.MobileUnk01 = objI.MobileUnk01;
            npc.MobileUnk02 = objI.MobileUnk02;
            npc.MobileUnk03 = objI.MobileUnk03;
            npc.MobileUnk04 = objI.MobileUnk04;
            npc.MobileUnk05 = objI.MobileUnk05;
            npc.MobileUnk06 = objI.MobileUnk06;
            npc.MobileUnk07 = objI.MobileUnk07;
            npc.MobileUnk08 = objI.MobileUnk08;
            npc.MobileUnk09 = objI.MobileUnk09;
            npc.Projectile_Sign = objI.Projectile_Sign;
            npc.MobileUnk11 = objI.MobileUnk11;
            npc.MobileUnk12 = objI.MobileUnk12;
            npc.MobileUnk13 = objI.MobileUnk13;
            npc.MobileUnk14 = objI.MobileUnk14;

            //	for (int i=0; i<=objI.NPC_DATA.GetUpperBound(0); i++)
            //	{
            //		npc.NPC_DATA[i]=objI.NPC_DATA[i];
            //	}
        }
    }



    /// <summary>
    /// Bouncing sound when object is thrown.
    /// </summary>
    /// <param name="collision">Collision.</param>
    void OnCollisionEnter(Collision collision)
    {
        if (PlaySoundEffects)
        {
            if (rg != null)
            {
                if (rg.useGravity == true)//Object is free to move around
                {
                    if (aud != null)
                    {
                        aud.clip = GameWorldController.instance.getMus().SoundEffects[0];
                        aud.Play();
                    }
                }
            }
        }
    }

    /// <summary>
    /// Gets the impact point location that will spawn blood when this object is hit.
    /// </summary>
    /// <returns>The impact point.</returns>
    public override Vector3 GetImpactPoint()
    {
        object_base item;
        item = this.GetComponent<object_base>();
        return item.GetImpactPoint();
    }
    /*public virtual Vector3 GetImpactPoint()
{
    object_base item;
    item= this.GetComponent<object_base>();
    return item.GetImpactPoint();
}*/



    /// <summary>
    /// Gets the game object that contains the location of the blood spawning.
    /// </summary>
    /// <returns>The impact game object.</returns>
    public virtual GameObject GetImpactGameObject()
    {
        object_base item;
        item = this.GetComponent<object_base>();
        return item.GetImpactGameObject();
    }


    /// <summary>
    /// Updates the position of the object before writing it back to the lev.ark file
    /// </summary>
    public void UpdatePosition()
    {
        if (objectloaderinfo == null)
        {
            Debug.Log(this.name + " has no objectloaderinfo");
            return;
        }
        if (ObjectLoader.isStatic(objectloaderinfo))
        {
            return;
        }

        //if (ObjectLoader.isMobile(objectloaderinfo))
        //{
        //		return;
        //}
        tileX = (short)Mathf.FloorToInt(this.transform.localPosition.x / 1.2f);
        tileY = (short)Mathf.FloorToInt(this.transform.localPosition.z / 1.2f);


        //float dist =Vector3.Distance(this.transform.position,startPos);
        if (
                    //(Vector3.Distance(this.transform.position,startPos)>0.2f)
                    //&& 
                    (tileX != TileMap.ObjectStorageTile)
            )
        //if ((tileX!=TileMap.ObjectStorageTile))
        /*	{//No movement or not on the map Just update heading.
                if (
                            objectloaderinfo.index>=256				
                    )						
                    {//Only update the heading on the mobile objects.
                    heading= (short)Mathf.RoundToInt(this.transform.rotation.eulerAngles.y/45f);
                    }					
            }
        else*/
        {
            float ceil = GameWorldController.instance.currentTileMap().CEILING_HEIGHT;
            //Updates the tilex & tileY,
            //tileX = (short)Mathf.FloorToInt(this.transform.localPosition.x/1.2f);
            //tileY = (short)Mathf.FloorToInt(this.transform.localPosition.z/1.2f);
            if ((tileX > TileMap.TileMapSizeX) | (tileX < 0))
            {//Object is off map.
                tileX = TileMap.ObjectStorageTile;
            }
            if ((tileY > TileMap.TileMapSizeX) | (tileY < 0))
            {
                tileY = TileMap.ObjectStorageTile;
            }
            //updates the x,y and zpos
            switch (GetItemType())
            {
                case DOOR://DO not update heights of doors.
                case HIDDENDOOR:
                    break;
                default:
                    short newzpos = (short)((((this.transform.localPosition.y * 100f) / 15f) / ceil) * 128f);
                    newzpos = (short)Mathf.Min(Mathf.Ceil(newzpos), 128f);
                    if (Mathf.Abs(newzpos - zpos) > 2)
                    {//To avoid drift. Only update zpos if moved by more than 2 units.
                        zpos = newzpos;
                    }
                    break;
            }

            if ((tileX < TileMap.ObjectStorageTile) && (tileY < TileMap.ObjectStorageTile))
            {//Update x & y
             //Remove corner
                float offX = (this.transform.position.x) - ((float)(tileX * 1.2f));
                x = (short)(7f * (offX / 1.2f));

                float offY = (this.transform.position.z) - ((float)(tileY * 1.2f));
                y = (short)(7f * (offY / 1.2f));
            }
            //updates the heading.
            heading = (short)Mathf.RoundToInt(this.transform.rotation.eulerAngles.y / 45f);

        }
        objectloaderinfo.heading = heading;
        objectloaderinfo.x = x;
        objectloaderinfo.y = y;
        objectloaderinfo.zpos = zpos;
        objectloaderinfo.tileX = tileX;
        objectloaderinfo.tileY = tileY;
        startPos = this.transform.position;
    }



    public static ObjectInteraction CreateNewObject(TileMap tm, ObjectLoaderInfo currObj, ObjectLoaderInfo[] objList, GameObject parent, Vector3 position)
    {//TODO: Make sure all object creation uses this function!

        GameObject myObj = new GameObject(ObjectLoader.UniqueObjectName(currObj));
        bool CreateSprite = true;//TODO:restore the following when going live. && (currObj.invis!=1);
        bool skipRotate = false;
        bool RemoveBillboard = false;
        bool AddAnimation = false;
        myObj.transform.localPosition = position;
        myObj.transform.Rotate(0.0f, 0.0f, 0.0f);//Initial rotation.
        myObj.transform.parent = parent.transform;
        myObj.layer = LayerMask.NameToLayer("UWObjects");
        ObjectMasters objM = GameWorldController.instance.objectMaster;
        ObjectInteraction objInt = CreateObjectInteraction(myObj, 0.5f, 0.5f, 0.5f, currObj);

        //objM.objProp[currObj.item_id].WorldIndex, objM.objProp[currObj.item_id].InventoryIndex, objM.objProp[currObj.item_id].InventoryIndex, objM.objProp[currObj.item_id].type, 
        // currObj.item_id, currObj.link, currObj.quality, currObj.owner, 
        //objM.objProp[currObj.item_id].isMoveable, objM.objProp[currObj.item_id].isUseable, objM.objProp[currObj.item_id].startFrame, objM.objProp[currObj.item_id].useSprite, 
        //  currObj.is_quant, currObj.enchantment, currObj.flags, currObj.InUseFlag
        //   );

        objInt.objectloaderinfo = currObj;
        currObj.instance = objInt;
        objInt.link = currObj.link;
        objInt.quality = currObj.quality;
        objInt.enchantment = currObj.enchantment;
        objInt.doordir = currObj.doordir;
        objInt.invis = currObj.invis;
        //objInt.texture=currObj.texture;
        objInt.zpos = currObj.zpos;
        objInt.x = currObj.x;
        objInt.y = currObj.y;
        objInt.heading = currObj.heading;
        objInt.zpos = currObj.zpos;
        objInt.owner = currObj.owner;
        objInt.tileX = currObj.tileX;
        objInt.tileY = currObj.tileY;
        objInt.objectloaderinfo = currObj;//link back to the list directly.
        objInt.next = currObj.next;

        //For now just generic.
        switch (currObj.GetItemType())
        {
            case NPC_TYPE:
                {
                    NPC npc;
                    CreateSprite = false;
                    npc = CreateNPC(myObj, objInt, currObj);
                    //CreateNPC(myObj,currObj.item_id.ToString(),"UW1/Sprites/Objects/OBJECTS_" + currObj.item_id.ToString() ,currObj.npc_whoami);
                    //SetNPCProps(myObj, currObj.npc_whoami,currObj.npc_xhome,currObj.npc_yhome,currObj.npc_hunger,currObj.npc_health,currObj.npc_hp,currObj.npc_arms,currObj.npc_power,currObj.npc_goal,currObj.npc_attitude,currObj.npc_gtarg,currObj.npc_talkedto,currObj.npc_level,currObj.npc_name,"", tm.GetTileRegionName(currObj.tileX,currObj.tileY));
                    //SetNPCProps(myObj,(MobileObject)npc,objInt,currObj, tm.GetTileRegionName(currObj.tileX,currObj.tileY),"");
                    Container.PopulateContainer(myObj.AddComponent<Container>(), objInt, currObj.parentList);
                    break;
                }
            case NPC_WISP:
                myObj.AddComponent<NPC_Wisp>();
                AddAnimation = true;
                break;
            case NPC_VOID:
                {
                    NPC_VoidCreature npc = myObj.AddComponent<NPC_VoidCreature>();
                    //SetNPCProps(myObj,(MobileObject)npc,objInt,currObj, tm.GetTileRegionName(currObj.tileX,currObj.tileY),"");
                    break;
                }
            case HIDDENDOOR:
            case DOOR:
            case PORTCULLIS:
                myObj.AddComponent<DoorControl>();
                DoorControl.CreateDoor(myObj, objInt);
                myObj.transform.Rotate(-90f, (objInt.heading * 45f) - 180f, 0f, Space.World);//I rotate here since my modelling is crap!

                //UnityRotation(game, -90, currobj.heading - 180 + OpenAdju, 0);
                skipRotate = true;
                CreateSprite = false;
                break;
            case CONTAINER:
                {
                    switch (objInt.item_id)
                    {
                        case 349://Chest variant
                            Container.PopulateContainer(myObj.AddComponent<Chest>(), objInt, currObj.parentList); CreateSprite = false; break;
                        case 347://barrel variant
                            Container.PopulateContainer(myObj.AddComponent<Barrel>(), objInt, currObj.parentList); CreateSprite = false; break;
                        default:
                            Container.PopulateContainer(myObj.AddComponent<Container>(), objInt, currObj.parentList); break;
                    }
                    if ((currObj.item_id >= 128) && (currObj.item_id <= 142))
                    {
                        myObj.GetComponent<Container>().Capacity = GameWorldController.instance.objDat.containerStats[currObj.item_id - 128].capacity;
                    }
                    break;
                }
            case KEY:
                myObj.AddComponent<DoorKey>();
                break;
            //case ACTIVATOR:
            //case BUTTON:
            //case A_DO_TRAP:
            case BOOK:
            case SCROLL:
                if ((_RES == GAME_UW1) && (objInt.item_id == 276))
                {
                    myObj.AddComponent<ReadableTrap>();
                }
                else
                {
                    //objInt.isquant=0;
                    if ((objInt.isEnchanted()) && (objInt.link != 0))
                    {
                        myObj.AddComponent<MagicScroll>();
                    }
                    else
                    {
                        myObj.AddComponent<Readable>();
                    }
                }
                break;
            case SIGN:
                RemoveBillboard = true;
                myObj.AddComponent<Sign>();
                break;
            case RUNE:
                myObj.AddComponent<RuneStone>();
                break;
            case RUNEBAG:
                myObj.AddComponent<RuneBag>();
                break;
            case FOOD:
                {
                    myObj.AddComponent<Food>();
                    break;
                }
            case CLUTTER:
                {
                    if ((objInt.isMagicallyEnchanted(currObj, objList)) && (objInt.link > 1))
                    {
                        myObj.AddComponent<Wand>();
                    }
                    else
                    {
                        myObj.AddComponent<object_base>();
                    }
                    break;
                }

            case MAP:
                myObj.AddComponent<Map>();
                break;
            case HELM:
                {
                    Helm h = myObj.AddComponent<Helm>();
                    h.UpdateQuality();
                    break;
                }

            case ARMOUR:
                {
                    Armour a = myObj.AddComponent<Armour>();
                    a.UpdateQuality();
                    break;
                }

            case GLOVES:
                {
                    Gloves g = myObj.AddComponent<Gloves>();
                    g.UpdateQuality();
                    break;
                }


            case BOOT:
                {
                    Boots b = myObj.AddComponent<Boots>();
                    b.UpdateQuality();
                    //if ((currObj.item_id==47) && (_RES==GAME_UW1))										
                    //{//Dragon skin boots special case when creating from a conversation.
                    //	currObj.link =  SpellEffect.UW1_Spell_Effect_Flameproof_alt01+256-16;
                    //	objInt.link =currObj.link;
                    //}
                    break;
                }

            case LEGGINGS:
                {
                    Leggings l = myObj.AddComponent<Leggings>();
                    l.UpdateQuality();
                    break;
                }

            case SHIELD:
                myObj.AddComponent<Shield>();
                break;
            case WEAPON:
                {
                    switch (objInt.item_id)
                    {
                        case 24://sling
                        case 25://bow
                        case 26://crossbow
                        case 31://jewelled bow.
                            myObj.AddComponent<WeaponRanged>();
                            break;
                        default:
                            myObj.AddComponent<WeaponMelee>();
                            break;
                    }
                }
                break;
            case TORCH:
                myObj.AddComponent<LightSource>();
                break;
            case REFILLABLE_LANTERN:
                myObj.AddComponent<Lantern>();
                break;
            case RING:
                myObj.AddComponent<Ring>();
                break;
            case POTIONS:
                myObj.AddComponent<Potion>();
                break;
            case LOCKPICK:
                myObj.AddComponent<LockPick>();
                break;
            case SILVERSEED:
                myObj.AddComponent<SilverSeed>();
                if (currObj.item_id == 458)
                {
                    UWCharacter.Instance.ResurrectPosition = myObj.transform.position;
                }
                AddAnimation = true;
                break;
            case GRAVE:
                myObj.AddComponent<Grave>();
                CreateSprite = false;
                break;
            case SHRINE:
                myObj.AddComponent<Shrine>();
                CreateSprite = false;
                break;
            case ANVIL:
                myObj.AddComponent<Anvil>();
                break;
            case POLE:
                myObj.AddComponent<Pole>();
                break;
            case SPIKE:
                myObj.AddComponent<Spike>();
                break;
            case OIL:
                myObj.AddComponent<Oil>();
                break;
            case WAND:
                myObj.AddComponent<Wand>();
                break;
            case MOONSTONE:
                myObj.AddComponent<MoonStone>();
                UWCharacter.Instance.MoonGatePosition = myObj.transform.position;
                break;
            case MOONGATE:
                myObj.AddComponent<MoonGate>();
                CreateSprite = false;
                break;
            case LEECH:
                myObj.AddComponent<Leech>();
                break;
            case FISHING_POLE:
                myObj.AddComponent<FishingPole>();
                break;
            case ZANIUM:
                myObj.AddComponent<Zanium>();
                myObj.layer = LayerMask.NameToLayer("Zanium");
                myObj.GetComponent<BoxCollider>().isTrigger = true;
                BoxCollider bx = myObj.AddComponent<BoxCollider>();
                bx.size = new Vector3(0.1f, 0.1f, 0.1f);
                bx.center = new Vector3(0.0f, 0.05f, 0.0f);
                break;
            case INSTRUMENT:
                myObj.AddComponent<Instrument>();
                break;
            case BEDROLL:
                myObj.AddComponent<Bedroll>();
                break;
            case BED:
                myObj.AddComponent<Bed>();
                CreateSprite = false;
                break;
            case TREASURE://or gold
                myObj.AddComponent<Coin>();
                break;
            case BOULDER:
                myObj.AddComponent<Boulder>();
                CreateSprite = false;
                break;
            case ORB:
                myObj.AddComponent<Orb>();
                break;
            case A_POCKETWATCH:
                myObj.AddComponent<PocketWatch>();
                break;
            case A_3D_MODEL:
                myObj.AddComponent<GenericModel3D>();
                CreateSprite = false;
                break;
            case A_LARGE_BLACKROCK_GEM:
                myObj.AddComponent<LargeBlackrockGem>();
                CreateSprite = false;
                break;
            case A_BLACKROCK_GEM:
                myObj.AddComponent<BlackrockGem>();
                break;
            case AN_ORB_ROCK:
                myObj.layer = LayerMask.NameToLayer("MagicProjectile");
                myObj.AddComponent<OrbRock>();
                break;
            case AN_EXPLODING_BOOK:
                myObj.AddComponent<ReadableTrap>();
                break;
            case UW_PAINTING:
                CreateSprite = false;
                myObj.AddComponent<UWPainting>();
                break;
            case PILLAR:
                myObj.AddComponent<Pillar>();
                CreateSprite = false;
                break;
            case A_STORAGECRYSTAL:
                myObj.AddComponent<StorageCrystal>();
                break;
            case DREAM_PLANT:
                myObj.AddComponent<DreamPlant>();
                break;
            case FORCEFIELD:
                myObj.AddComponent<forcefield>();
                break;

            //case BENCH:
            //		myObj.AddComponent<bench>();
            //		CreateSprite=false;
            //		break;
            case ARROW:
                myObj.AddComponent<Arrow>();
                CreateSprite = false;
                break;
            case A_MAGIC_PROJECTILE:
                {
                    skipRotate = true;
                    MagicProjectile mgp = myObj.AddComponent<MagicProjectile>();
                    if (GameWorldController.LoadingObjects)
                    {
                        BoxCollider box = myObj.GetComponent<BoxCollider>();
                        box.size = new Vector3(0.2f, 0.2f, 0.2f);
                        box.center = new Vector3(0.0f, 0.1f, 0.0f);
                        switch (_RES)
                        {
                            case GAME_UW2:
                                {
                                    switch (currObj.item_id)
                                    {
                                        case 20://fireball
                                            {
                                                SpellProp_Fireball spFB = new SpellProp_Fireball();
                                                spFB.init(SpellEffect.UW2_Spell_Effect_Fireball, myObj);
                                                mgp.spellprop = spFB;
                                                break;
                                            }
                                        case 21://lightning
                                            {
                                                SpellProp_Fireball spLN = new SpellProp_Fireball();
                                                spLN.init(SpellEffect.UW2_Spell_Effect_ElectricalBolt, myObj);
                                                mgp.spellprop = spLN;
                                                break;
                                            }
                                        case 22://acid
                                            {
                                                SpellProp_Acid spAC = new SpellProp_Acid();
                                                spAC.init(SpellEffect.UW2_Spell_Effect_Acid_alt01, myObj);
                                                mgp.spellprop = spAC;
                                                break;
                                            }
                                        case 27://Homing dart/deadly seeker
                                            {
                                                SpellProp_Homing spHm = new SpellProp_Homing();
                                                spHm.init(SpellEffect.UW2_Spell_Effect_DeadlySeeker, myObj);
                                                mgp.spellprop = spHm;
                                                break;
                                            }
                                        case 23://magic missile
                                        default:
                                            {
                                                SpellProp_MagicArrow spOJ = new SpellProp_MagicArrow();
                                                spOJ.init(SpellEffect.UW2_Spell_Effect_MagicArrow, myObj);
                                                mgp.spellprop = spOJ;
                                                break;
                                            }
                                    }

                                    break;
                                }
                            default:
                                {
                                    switch (currObj.item_id)
                                    {
                                        case 20://fireball
                                            {
                                                SpellProp_Fireball spFB = new SpellProp_Fireball();
                                                spFB.init(SpellEffect.UW1_Spell_Effect_Fireball, myObj);
                                                mgp.spellprop = spFB;
                                                break;
                                            }
                                        case 21://lightning
                                            {
                                                SpellProp_Fireball spLN = new SpellProp_Fireball();
                                                spLN.init(SpellEffect.UW1_Spell_Effect_ElectricalBolt, myObj);
                                                mgp.spellprop = spLN;
                                                break;
                                            }
                                        case 22://acid
                                            {
                                                SpellProp_Acid spAC = new SpellProp_Acid();
                                                spAC.init(SpellEffect.UW1_Spell_Effect_Acid_alt01, myObj);
                                                mgp.spellprop = spAC;
                                                break;
                                            }
                                        case 23://magic missile
                                        default:
                                            {
                                                SpellProp_MagicArrow spOJ = new SpellProp_MagicArrow();
                                                spOJ.init(SpellEffect.UW1_Spell_Effect_MagicArrow, myObj);
                                                mgp.spellprop = spOJ;
                                                break;
                                            }
                                    }
                                    break;
                                }

                        }
                        if (mgp.spellprop.homing)
                        {
                            mgp.BeginHoming();
                        }
                        if (mgp.spellprop.hasTrail)
                        {
                            mgp.BeginVapourTrail();
                        }
                    }

                    break;
                }
            case BOUNCING_PROJECTILE:
                {
                    skipRotate = true;
                    myObj.AddComponent<BouncingProjectile>();
                    break;
                }
            case BUTTON:
                myObj.AddComponent<ButtonHandler>();
                RemoveBillboard = true;
                break;
            case A_MOVE_TRIGGER:
            case A_STEP_ON_TRIGGER:
                myObj.AddComponent<a_move_trigger>();
                CreateSprite = false;
                break;
            case AN_ENTER_TRIGGER:
                myObj.AddComponent<an_enter_trigger>();
                CreateSprite = false;
                break;
            case AN_EXIT_TRIGGER:
                myObj.AddComponent<an_exit_trigger>();
                CreateSprite = false;
                break;
            case A_PICK_UP_TRIGGER:
                myObj.AddComponent<a_pick_up_trigger>();
                CreateSprite = false;
                break;
            case A_USE_TRIGGER:
                myObj.AddComponent<a_use_trigger>();
                CreateSprite = false;
                break;
            case AN_OPEN_TRIGGER:
                myObj.AddComponent<an_open_trigger>();
                CreateSprite = false;
                break;
            case A_CLOSE_TRIGGER:
                myObj.AddComponent<a_close_trigger>();
                CreateSprite = false;
                break;
            case AN_UNLOCK_TRIGGER:
                myObj.AddComponent<an_unlock_trigger>();
                CreateSprite = false;
                break;
            case A_LOOK_TRIGGER:
                myObj.AddComponent<a_look_trigger>();
                CreateSprite = false;
                break;
            case A_TIMER_TRIGGER:
                myObj.AddComponent<a_timer_trigger>();
                CreateSprite = false;
                break;
            case A_SCHEDULED_TRIGGER:
                myObj.AddComponent<a_scheduled_trigger>();
                CreateSprite = false;
                break;
            case A_PRESSURE_TRIGGER:
                myObj.AddComponent<a_pressure_trigger>();
                CreateSprite = false;
                break;
            case A_DAMAGE_TRAP:
                myObj.AddComponent<a_damage_trap>();
                CreateSprite = false;
                break;
            case A_TELEPORT_TRAP:
                myObj.AddComponent<a_teleport_trap>();
                CreateSprite = false;
                break;
            case A_ARROW_TRAP:
                myObj.AddComponent<a_arrow_trap>();
                CreateSprite = false;
                break;
            case A_PIT_TRAP:
                myObj.AddComponent<a_pit_trap>();
                CreateSprite = false;
                break;
            case A_CHANGE_TERRAIN_TRAP:
                myObj.AddComponent<a_change_terrain_trap>();
                CreateSprite = false;
                break;
            case A_SPELLTRAP:
                myObj.AddComponent<a_spelltrap>();
                CreateSprite = false;
                break;
            case A_CREATE_OBJECT_TRAP:
                myObj.AddComponent<a_create_object_trap>();
                CreateSprite = false;
                break;
            case A_DOOR_TRAP:
                myObj.AddComponent<a_door_trap>();
                CreateSprite = false;
                break;
            case A_WARD_TRAP:
                myObj.AddComponent<a_ward_trap>();
                if (_RES != GAME_UW2) { CreateSprite = false; }
                break;
            case A_TELL_TRAP:
                myObj.AddComponent<a_tell_trap>();
                CreateSprite = false;
                break;
            case A_DELETE_OBJECT_TRAP:
                myObj.AddComponent<a_delete_object_trap>();
                CreateSprite = false;
                break;
            case AN_INVENTORY_TRAP:
                myObj.AddComponent<an_inventory_trap>();
                CreateSprite = false;
                break;
            case A_SET_VARIABLE_TRAP:
                myObj.AddComponent<a_set_variable_trap>();
                CreateSprite = false;
                break;
            case A_CHECK_VARIABLE_TRAP:
                myObj.AddComponent<a_check_variable_trap>();
                CreateSprite = false;
                break;
            case A_COMBINATION_TRAP:
                myObj.AddComponent<a_combination_trap>();
                CreateSprite = false;
                break;
            case A_TEXT_STRING_TRAP:
                myObj.AddComponent<a_text_string_trap>();
                CreateSprite = false;
                break;
            case AN_OSCILLATOR:
                myObj.AddComponent<an_oscillator_trap>();
                CreateSprite = false;
                break;
            case A_CHANGE_FROM_TRAP:
                myObj.AddComponent<a_change_from_trap>();
                CreateSprite = false;
                break;
            case A_CHANGE_TO_TRAP:
                myObj.AddComponent<a_change_to_trap>();
                CreateSprite = false;
                break;
            case AN_EXPERIENCE_TRAP:
                myObj.AddComponent<an_experience_trap>();
                CreateSprite = false;
                break;
            case A_NULL_TRAP://A trap that does nothing
                myObj.AddComponent<a_null_trap>();
                CreateSprite = false;
                break;
            case A_JUMP_TRAP:
                myObj.AddComponent<a_jump_trap>();
                CreateSprite = false;
                break;
            case A_SKILL_TRAP:
                myObj.AddComponent<a_skill_trap>();
                CreateSprite = false;
                break;
            case UNIMPLEMENTED_TRAP:
                Debug.Log("Unimplemented trap " + myObj.name);
                myObj.AddComponent<trap_base>();
                CreateSprite = false;
                break;
            case A_PROXIMITY_TRAP:
                myObj.AddComponent<a_proximity_trap>();
                CreateSprite = false;
                break;
            case TMAP_CLIP:
            case TMAP_SOLID:
                myObj.AddComponent<TMAP>();
                CreateSprite = false;
                RemoveBillboard = true;
                break;
            case FOUNTAIN:
            case A_FOUNTAIN:
                myObj.AddComponent<Fountain>();
                break;
            case ANIMATION:
                myObj.AddComponent<object_base>();
                AddAnimation = true;
                break;
            case BRIDGE:
                myObj.AddComponent<Bridge>();
                CreateSprite = false;
                break;
            case SPELL:
                myObj.AddComponent<a_spell>();
                CreateSprite = false;
                break;
            //case ObjectInteraction.LOCK:
            //	myObj.AddComponent<a_lock>();
            //CreateSprite=false;
            //break;
            case A_DO_TRAP:
                {
                    switch (objInt.quality)
                    {
                        case 0x02://Camera
                            myObj.AddComponent<a_do_trap_camera>(); break;
                        case 0x03://platform
                            myObj.AddComponent<a_do_trap_platform>(); break;
                        case 0x5://A trespass trap
                            myObj.AddComponent<a_hack_trap_trespass>(); break;
                        case 0x12://Scint 5 puzzle reset
                            myObj.AddComponent<a_hack_trap_scintpuzzlereset>(); break;
                        case 0x13:
                            myObj.AddComponent<a_hack_trap_scintplatformreset>(); break;
                        case 0xA://Bonus object trap
                            myObj.AddComponent<a_hack_trap_class_item>(); break;
                        case 0xE://colour cycle a room in talorus
                            myObj.AddComponent<a_hack_trap_colour_cycle>(); break;
                        case 0x1a://Forcefield in scint 5										
                            myObj.AddComponent<a_hack_trap_forcefield>(); break;
                        case 0x1E://Avatar is a coward.
                            myObj.AddComponent<a_hack_trap_coward>(); break;
                        case 0x14://Terraform puzzle on scintilus 
                            myObj.AddComponent<a_hack_trap_terraform_puzzle>(); break;
                        case 0x18://bullfrog
                            {
                                if (_RES != GAME_UW2)
                                {
                                    myObj.AddComponent<a_do_trapBullfrog>(); break;
                                }
                                else
                                {
                                    myObj.AddComponent<a_hack_trap_tmap_range_change>(); break;
                                }
                            }
                        case 0x19://Bliy scup spawner
                            myObj.AddComponent<a_hack_trap_skup>(); break;
                        case 0x1B://Unlinker
                            myObj.AddComponent<a_hack_trap_unlink>(); break;
                        case 0x17:
                        case 0x1c://CHange texture of tmap
                            myObj.AddComponent<a_hack_trap_texture>(); break;
                        case 0x1d:
                            myObj.AddComponent<a_hack_trap_button_flicker>(); break;
                        case 0x20://qbert puzzle in the void
                            myObj.AddComponent<a_hack_trap_qbert>(); break;
                        case 0x21://Bottle recycler
                            myObj.AddComponent<a_hack_trap_recycle>(); break;
                        case 0x23://Light sphere recharge
                            myObj.AddComponent<a_hack_trap_light_recharge>(); break;
                        case 0x24://Move castlenpcs
                            myObj.AddComponent<a_hack_trap_castle_npcs>(); break;
                        case 0x27://Change visiblity of linked item
                            myObj.AddComponent<a_hack_trap_visibility>(); break;
                        case 0x28:
                            {
                                if (_RES == GAME_UW2)
                                {
                                    myObj.AddComponent<a_hack_trap_vendingselect>(); break;
                                }
                                else
                                {//emerald puzzle on level 6
                                    myObj.AddComponent<a_do_trap_emeraldpuzzle>(); break;
                                }
                            }
                        case 0x29://vending maching
                            {
                                myObj.AddComponent<a_hack_trap_vending>(); break;
                            }
                        case 0x2a://Gronk conversation/vending machine sign
                            {
                                if (_RES == GAME_UW2)
                                {
                                    myObj.AddComponent<a_hack_trap_vendingsign>();
                                }
                                else
                                {
                                    myObj.AddComponent<a_do_trap_conversation>();
                                }
                                break;
                            }
                        case 0x2c:
                            myObj.AddComponent<a_hack_trap_sleep>(); break;
                        case 0x32:
                            myObj.AddComponent<a_do_trap_jailor>(); break;
                        case 0x3F://end game sequence
                            myObj.AddComponent<a_do_trap_EndGame>(); break;
                        case 0x36:
                            myObj.AddComponent<a_hack_trap_gemrotate>(); break;
                        case 0x37:
                            myObj.AddComponent<a_hack_trap_teleport>(); break;
                        default:
                            myObj.AddComponent<a_hack_trap>(); break;
                    }
                    CreateSprite = false;
                    break;
                }
            default:
                myObj.AddComponent<object_base>();
                break;
        }

        if (parent.transform == GameWorldController.instance.DynamicObjectMarker())
        {
            if (currObj.index < 256)//this is a mobile object
            {
                if (currObj.GetItemType() != NPC_TYPE)
                {
                    skipRotate = true;
                }
                SetMobileProps(myObj, myObj.GetComponent<object_base>(), objInt, currObj);
                if (myObj.GetComponent<Rigidbody>() != null)
                {
                    switch (currObj.GetItemType())
                    {
                        case NPC_TYPE:
                        case A_MAGIC_PROJECTILE:
                        case BOUNCING_PROJECTILE:
                            break;
                        default:
                            GameWorldController.UnFreezeMovement(myObj);

                            myObj.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
                            myObj.GetComponent<Rigidbody>().AddForce(150f * object_base.ProjectilePropsToVector(myObj.GetComponent<object_base>()));
                            break;
                    }
                }
            }
        }


        if ((CreateSprite) || (EditorMode))
        {
            //GameObject SpriteObj =
            ObjectInteraction.CreateObjectGraphics(myObj, _RES + "/Sprites/Objects/Objects_" + currObj.item_id, !RemoveBillboard);
        }


        if (!skipRotate)
        {
            myObj.transform.Rotate(0.0f, currObj.heading * 45f, 0.0f);//final rotation		
        }

        if (AddAnimation)
        {//This is a hack!
            bool looping = true;
            if (_RES == GAME_UW2)
            {
                switch (currObj.item_id)
                {
                    case 448://blood
                    case 450:
                    case 451:
                    case 452://explosions
                    case 453://lightning
                    case 459://flash
                    case 462://vapor trail
                        looping = false; break;
                }
            }
            else
            {
                switch (currObj.item_id)
                {
                    case 450:
                    case 451:
                    case 452://explosions
                    case 453://lightning
                    case 459://damage
                        looping = false; break;
                }
            }


            AnimationOverlay ao = myObj.AddComponent<AnimationOverlay>();
            ao.StartFrame = currObj.StartFrameValue();
            ao.NoOfFrames = currObj.useSpriteValue();
            ao.Looping = looping;
        }
        return objInt;
    }

    /// <summary>
    /// Is the object an enchanted object or does it link to something
    /// </summary>
    /// <returns><c>true</c>, if magically enchanted was ised, <c>false</c> otherwise.</returns>
    public bool isMagicallyEnchanted(ObjectLoaderInfo currObj, ObjectLoaderInfo[] objList)
    {
        if (isquant == 1)
        {
            return false;
        }
        if (enchantment == 1)
        {
            return true;
        }
        else
        {
            if (currObj.link > 0)
            {
                if (currObj.link <= objList.GetUpperBound(0))
                {
                    if ((objList[currObj.link].GetItemType() == ObjectInteraction.SPELL) && (objList[currObj.link].InUseFlag == 1))
                    {
                        return true;
                    }
                }
            }

            //	if (link>=256)
            //{

            //if (GameWorldController.instance.objectMaster.type[ GameWorldController.instance.CurrentObjectList().objInfo[link].item_id]==ObjectInteraction.SPELL)
            //{
            return true;
            //}
            //}
        }
        return false;

    }

    /// <summary>
    /// Returns the enchantment flag as a bool
    /// </summary>
    /// <returns><c>true</c>, if enchanted was ised, <c>false</c> otherwise.</returns>
    public bool isEnchanted()
    {
        return (enchantment == 1);
    }

    /// <summary>
    /// Returns the isQuant flag as a bool
    /// </summary>
    /// <returns><c>true</c>, if quant was ised, <c>false</c> otherwise.</returns>
    ///   Per UWformats If the "is_quant" flag is set, the field is a quantity or a special
    //property. If the value is < 512 or 0x0200 it gives the number of stacked
    //items present. Identical objects may be stacked up to 256 objects at a
    //time. The field name "quantity" is used for this.
    public bool isQuant()
    {
        return ((isquant == 1) && (link < 512));
    }


    /// <summary>
    /// Determines whether this instance can be picked up.
    /// </summary>
    /// <returns><c>true</c> if this instance can be picked up; otherwise, <c>false</c>.</returns>
    public bool CanBePickedUp()
    {
        return (GameWorldController.instance.commonObject.properties[item_id].FlagCanBePickedUp == 1 || this.GetComponent<object_base>().CanBePickedUp());
    }


    /// <summary>
    /// Returns if the object has been identified. Based on the heading value of the object.
    /// </summary>
    public IdentificationFlags identity()
    {
        switch (heading)
        {
            case 7:
            case 6:
            case 5:
            case 4:
            case 3:
            case 2:
                return IdentificationFlags.Identified;
            case 1:
                return IdentificationFlags.PartiallyIdentified;
            default:
            case 0:
                return IdentificationFlags.Unidentified;
        }
    }


    /// <summary>
    /// Sets the invisibility of the object
    /// </summary>
    /// <param name="val">Value.</param>
    public void setInvis(short val)
    {
        invis = val;
        //Debug.Log(this.name + " has it's visiblity changed to " + val);
        if (sr != null)
        {
            sr.gameObject.SetActive(val == 0);
        }
    }

    public bool isMoveable()
    {//GameWorldController.instance.objectMaster
        return (GameWorldController.instance.objectMaster.objProp[item_id].isMoveable == 1);
    }



    public static string UniqueObjectName(ObjectInteraction currObj)
    {//returns a unique name for the object
     //"%s_%02d_%02d_%02d_%04d\0", GameWorldController.instance.objectMaster[currObj.item_id].desc, currObj.tileX, currObj.tileY, currObj.levelno, currObj.index);
        switch (currObj.GetItemType())
        {
            case ObjectInteraction.DOOR:
            case ObjectInteraction.HIDDENDOOR:
            case ObjectInteraction.PORTCULLIS:
                return "door_" + currObj.tileX.ToString("d3") + "_" + currObj.tileY.ToString("d3");
            default:
                return currObj.getDesc() + System.Guid.NewGuid();
        }
    }

    /// <summary>
    /// Event to raise when the object is saved
    /// </summary>
    public void OnSaveObjectEvent()
    {
        this.GetComponent<object_base>().OnSaveObjectEvent();
    }

    public bool isUsable()
    {
        return GameWorldController.instance.objectMaster.objProp[item_id].isUseable == 1;
    }

    /// <summary>
    /// Gets the default world display index.
    /// </summary>
    /// <returns></returns>
    public int WorldIndex()
    {
        return GameWorldController.instance.objectMaster.objProp[item_id].WorldIndex;
    }

    /// <summary>
    /// Gets the default inventory display index
    /// </summary>
    /// <returns></returns>
    public int InventoryIndex()
    {
        return GameWorldController.instance.objectMaster.objProp[item_id].InventoryIndex;
    }

    public bool IsAnimated()
    {
        return GameWorldController.instance.objectMaster.objProp[item_id].startFrame == 1;
    }

    public bool UseSprite()
    {
        return GameWorldController.instance.objectMaster.objProp[item_id].useSprite == 1;
    }

    public string getDesc()
    {
        return GameWorldController.instance.objectMaster.objProp[item_id].desc;
    }

}