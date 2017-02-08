using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using RAIN.BehaviorTrees;
using RAIN.Core;
using RAIN.Minds;
using RAIN.Navigation;

/// <summary>
/// Object interaction. Does a lot....
/// Use for common object actions. Weight, qty, type, how to display the object. 
/// </summary>
public class ObjectInteraction : UWEBase {
		/// <summary>
		/// The start position of the object when it became awake.
		/// </summary>
		private Vector3 startPos;
		//public AudioSource aud;
		public static bool PlaySoundEffects=true;

		public const int NPC_TYPE =0;
		public const int WEAPON =1;
		public const int ARMOUR =2 ;
		public const int AMMO =3 ;
		public const int DOOR =4 ;
		public const int KEY =5 ;
		public const int RUNE =6 ;
		public const int BRIDGE =7 ;
		public const int BUTTON =8 ;
		public const int LIGHT =9 ;
		public const int SIGN =10 ;
		public const int BOOK =11 ;
		public const int WAND =12 ;
		public const int SCROLL= 13; //The reading kind
		public const int POTIONS =14;
		public const int INSERTABLE =15; //Shock style put the circuit board in the slot.
		public const int INVENTORY =16; //Quest items and the like with no special properties
		public const int ACTIVATOR =17; //Crystal balls,magic fountains and surgery machines that have special custom effects when you activate them
		public const int TREASURE =18 ;
		public const int CONTAINER =19 ;
		//public const int TRAP =20 ;
		public const int LOCK =21 ;
		public const int TORCH =22 ;
		public const int CLUTTER =23 ;
		public const int FOOD =24 ;
		public const int SCENERY =25 ;
		public const int INSTRUMENT =26 ;
		public const int FIRE =27 ;
		public const int MAP= 28 ;
		public const int HIDDENDOOR =29 ;
		public const int PORTCULLIS =30 ;
		public const int PILLAR =31 ;
		public const int SOUND= 32 ;
		public const int CORPSE =33 ;
		public const int TMAP_SOLID =34 ;
		public const int TMAP_CLIP= 35 ;
		public const int MAGICSCROLL =36 ;
		public const int A_DAMAGE_TRAP =37 ;
		public const int A_TELEPORT_TRAP =38 ;
		public const int A_ARROW_TRAP =39 ;
		public const int A_DO_TRAP= 40 ;
		public const int A_PIT_TRAP= 41 ;
		public const int A_CHANGE_TERRAIN_TRAP= 42 ;
		public const int A_SPELLTRAP =43 ;
		public const int A_CREATE_OBJECT_TRAP =44 ;
		public const int A_DOOR_TRAP= 45 ;
		public const int A_WARD_TRAP =46 ;
		public const int A_TELL_TRAP =47 ;
		public const int A_DELETE_OBJECT_TRAP= 48 ;
		public const int AN_INVENTORY_TRAP =49 ;
		public const int A_SET_VARIABLE_TRAP =50 ;
		public const int A_CHECK_VARIABLE_TRAP= 51 ;
		public const int A_COMBINATION_TRAP= 52 ;
		public const int A_TEXT_STRING_TRAP =53 ;
		public const int A_MOVE_TRIGGER =54 ;
		public const int A_PICK_UP_TRIGGER= 55 ;
		public const int A_USE_TRIGGER =56 ;
		public const int A_LOOK_TRIGGER =57 ;
		public const int A_STEP_ON_TRIGGER =58 ;
		public const int AN_OPEN_TRIGGER =59 ;
		public const int AN_UNLOCK_TRIGGER =60 ;
		public const int A_FOUNTAIN= 61 ;
		public const int SHOCK_DECAL =62 ;
		public const int COMPUTER_SCREEN=63 ;
		public const int SHOCK_WORDS =64 ;
		public const int SHOCK_GRATING= 65 ;
		public const int SHOCK_DOOR= 66 ;
		public const int SHOCK_DOOR_TRANSPARENT= 67 ;
		public const int UW_PAINTING= 68 ;
		public const int PARTICLE =69 ;
		public const int RUNEBAG =70 ;
		public const int SHOCK_BRIDGE =71 ;
		public const int FORCE_DOOR= 72 ;
		public const int HIDDENPLACEHOLDER = 999 ;
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
		public const int GRAVE = 83;
		public const int SHRINE = 84;
		public const int ANVIL = 85;
		public const int POLE = 86;
		public const int SPIKE = 87;
		public const int REFILLABLE_LANTERN =88;
		public const int OIL =89;
		public const int MOONSTONE =90;
		public const int LEECH= 91;
		public const int FISHING_POLE= 92;
		public const int  ZANIUM= 93;
		public const int  BEDROLL =94;
		public const int  FORCEFIELD= 95;
		public const int  MOONGATE= 96;
		public const int  BOULDER= 97;
		public const int  ORB= 98;
		public const int  SPELL = 99;//used by wands



		public const int HEADINGNORTH =180;
		public const int HEADINGSOUTH= 0;
		public const int HEADINGEAST =270;
		public const int HEADINGWEST= 90;

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

		/// <summary>
		/// Indicates if the object can be picked up.
		/// </summary>
		public bool CanBePickedUp;

		/// <summary>
		/// Indicates if the object can be used.
		/// </summary>
		public bool CanBeUsed;

		/// <summary>
		/// Tells if object is in the inventory or in the open world in case there is different behaviours needed depending on the case.
		/// </summary>
		public bool PickedUp;

		/// <summary>
		/// The inventory slot that the object is in.
		/// </summary>
		public int inventorySlot=-1;

		//UW specific info.
		//public int index;

		public int Owner;	//Used for keys
		public int Link;	//Also quantity
		public int Quality;
		public bool isQuant;
		public bool isEnchanted;
		public bool isIdentified;

		//Display controls
		public static TextureController tc;
		private SpriteRenderer sr =null;
		public bool isAnimated;
		public bool animationStarted;

		public short InUseFlag;
		public short levelno;
		public short tileX;	//Position of the object on the tilemap
		public short tileY;
		public long address;
		public short AlreadyRendered;
		public short DeathWatched;

		//UW Props

		public int index;	//it's own index in case I need to find myself.
		public int item_id;	//0-8
		public int flags;	//9-12
		public short enchantment;	//12
		public short doordir;	//13
		public short invis;		//14
		//public short isquant;	//15

		public int texture;	// Note: some objects don't have flags and use the whole lower byte as a texture number
		//(gravestone, picture, lever, switch, shelf, bridge, ..)

		public int zpos;    //  0- 6   7   "zpos"      Object Z position (0-127)
		public int heading;	//        7- 9   3   "heading"   Heading (*45 deg)
		public int x; //   10-12   3   "ypos"      Object Y position (0-7)
		public int y; //  13-15   3   "xpos"      Object X position (0-7)
		//0004 quality / chain
		public 		int quality;	//;     0- 5   6   "quality"   Quality
		public long next; //    6-15   10  "next"      Index of next object in chain

		//0006 link / special
		//     0- 5   6   "owner"     Owner / special

		public int owner;	//Also special
		//     6-15   10  (*)         Quantity / special link / special property

		public int link	;	//also quantity

		public ObjectLoaderInfo objectloaderinfo;

		void Start () {
			isAnimated=false;
			animationStarted=false;
			sr= this.gameObject.GetComponentInChildren<SpriteRenderer>();
			startPos=this.transform.position;
		}

		void Update()
		{
			if ((animationStarted==false) && (ignoreSprite==false))
			{
				UpdateAnimation();
			}
		}

		public void UpdateAnimation()
		{
			if (sr== null)
			{
				sr=this.GetComponentInChildren<SpriteRenderer>();
			}
			if (sr !=null)
			{
				//sr.sprite= tc.RequestSprite(WorldDisplayIndex,isAnimated);
				sr.sprite=GameWorldController.instance.ObjectArt.RequestSprite(WorldDisplayIndex);
				if (inventorySlot!=-1)
				{
					GameWorldController.instance.playerUW.playerInventory.Refresh(inventorySlot);
				}
				animationStarted=true;
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
			sr.sprite=NewSprite;
		}

		public void RefreshAnim()
		{
			animationStarted=false;
		}

		/// <summary>
		/// Gets the type of the item from object masters. UWE object type codes.
		/// </summary>
		/// <returns>The item type.</returns>
		public int GetItemType()
		{
			return GameWorldController.instance.objectMaster.type[item_id];
		}

		/// <summary>
		/// Applies an attack to this object
		/// </summary>
		/// <param name="damage">Damage.</param>
		/// <param name="source">Source.</param>
		public bool Attack (int damage, GameObject source)
		{
			this.GetComponent<object_base>().ApplyAttack(damage,source);
			return true;	
		}

		/// <summary>
		/// Looks the description to be displayed in a context menu.
		/// </summary>
		/// <returns>The context menu description</returns>
		public string LookDescriptionContext()
		{
			object_base item;
			item= this.GetComponent<object_base>();
			if(item!=null)
			{
				return item.GetContextMenuText(item_id,CanBeUsed && WindowDetect.ContextUIUse,CanBePickedUp&& WindowDetect.ContextUIUse, ( (GameWorldController.instance.playerUW.playerInventory.ObjectInHand ) !="" && (UWCharacter.InteractionMode!=UWCharacter.InteractionModePickup)));
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
			item= this.GetComponent<object_base>();

			if(item!=null)
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
			GameObject ObjectInHand =GameWorldController.instance.playerUW.playerInventory.GetGameObjectInHand();
			object_base item = this.GetComponent<object_base>();//Base object class

			if (ObjectInHand != null)
			{
				//First do a combineobject test. This will implement object combinatiosn defined by UW1/2
				GameObject combined = CombineObject(this.gameObject,ObjectInHand);
				if (combined!=null)
				{
					GameWorldController.instance.playerUW.playerInventory.ObjectInHand = combined.name	;
					return true;
				}	
			}

			if (item!=null)
			{
				return item.use ();
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
			object_base item=null;
			item=this.GetComponent<object_base>();
			if (item!=null)
			{
				return(item.PickupEvent());
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
		public bool PutItemAway(int SlotNo)
		{//What happens when an item is put into a backpack
			inventorySlot=SlotNo;
			object_base item=null;
			item=this.GetComponent<object_base>();
			if( item !=null)
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
		public bool Equip(int SlotNo)
		{//To handle what happens when an item (typically armour is equipped
			object_base item=this.GetComponent<object_base>();
			inventorySlot=SlotNo;
			if( item !=null)
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
		public bool UnEquip(int SlotNo)
		{//To handle what happens when an item (typically armour is unequipped
			object_base item=this.GetComponent<object_base>();
			inventorySlot=-1;
			
			if( item !=null)
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
			object_base item=this.GetComponent<object_base>();
			return item.TalkTo();
		}

		/// <summary>
		/// Failure message for actions that can't be completed
		/// </summary>
		/// <returns><c>true</c>, if message was failed, <c>false</c> otherwise.</returns>
		public bool FailMessage()
		{
			object_base objbase= this.GetComponent<object_base>();
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
			int[] lstInput1= new int[8];
			int[] lstInput2= new int[8];
			int[] lstOutput= new int[8];
			int[] lstDestroy1= new int[8];
			int[] lstDestroy2= new int[8];
			int ItemID1 = InputObject1.GetComponent<ObjectInteraction>().item_id;
			int ItemID2 = InputObject2.GetComponent<ObjectInteraction>().item_id;
			bool Destroyed1=false;
			bool Destroyed2=false;
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
				switch (GameWorldController.instance.game.ToUpper())
				{
				case "UW1"://uw1
					{
						lstInput1= new int[9]{149,225,225,226,225,226,227,149,284};
						lstDestroy1 =new int[9]{0,1,1,1,1,1,1,0,1};
						lstInput2 =new int[9]{278,226,227,227,229,228,230,180,216};
						lstDestroy2=new int[9]{1,1,1,1,1,1,1,1,1};
						lstOutput =new int[9]{277,230,228,229,231,231,231,183,299};
					}
					break;
				case "UW2"://uw2
					lstInput1= new int[5]{216,300,149,149,191};
					lstDestroy1=new int[5]{1,1,0,0,1};
					lstInput2 =new int[5]{300,300,180,186,188};
					lstDestroy2=new int[5]{1,1,1,1,1};
					lstOutput =new int[5]{299,146,183,210,187};
					break;
				}

				for (int i =0; i <= lstInput1.GetUpperBound(0);i++)
				{
				//Debug.Log (i + " is " + lstInput1[i] + " and " + lstInput2[i]);
				if 
					(//Check both input lists for the two items
						((ItemID1 == lstInput1[i]) && (ItemID2==lstInput2[i]))
						||
						((ItemID2 == lstInput1[i]) && (ItemID1==lstInput2[i]))
					)
				{//Matching combination.
					Debug.Log ("Creating a " + lstOutput[i]);
					if((lstInput1[i] == ItemID1) && (lstDestroy1[i]==1) && (Destroyed1==false) )
					{
							Debug.Log("Destroying " + InputObject1.name);
							Destroyed1=true;
					}
					if((lstInput1[i] == ItemID2) && (lstDestroy1[i]==1)&& (Destroyed2==false) )
					{
							Debug.Log("Destroying " + InputObject2.name);
							Destroyed2=true;
					}
					if((lstInput2[i] == ItemID1) && (lstDestroy2[i]==1) && (Destroyed1==false))
					{
							Debug.Log("Destroying " + InputObject1.name);
							Destroyed1=true;
					}
					if((lstInput2[i] == ItemID2) && (lstDestroy2[i]==1)&& (Destroyed2==false) )
					{
							Debug.Log("Destroying " + InputObject2.name);
							Destroyed2=true;
					}

					if (Destroyed1==true)
					{
							InputObject1.GetComponent<ObjectInteraction>().consumeObject();
					}
					if (Destroyed2==true)
					{
							InputObject2.GetComponent<ObjectInteraction>().consumeObject();
					}

					ObjectInteraction CreatedObjectInt = CreateNewObject (lstOutput[i]);
					if (CreatedObjectInt != null) {
							CreatedObjectInt.UpdateAnimation ();
							CreatedObjectInt.PickedUp=true;
							UWHUD.instance.CursorIcon = CreatedObjectInt.GetInventoryDisplay ().texture;
					}
					UWCharacter.InteractionMode=UWCharacter.InteractionModePickup;
					InteractionModeControl.UpdateNow=true;
					return CreatedObjectInt.gameObject;
				}
			}

		return null;
		}

		/// <summary>
		/// Uses up and destroys a single instance of the object. (eg if it was eaten
		/// </summary>
		public void consumeObject()
		{
			if((isQuant ==false) || ((isQuant) && (Link==1)) || (isEnchanted==true))
			{//the last of the item or is not a quantity;
				Container cn = GameWorldController.instance.playerUW.playerInventory.GetCurrentContainer();
				//Code for objects that get destroyed when they are used. Eg food, potion, fuel etc
				if (!cn.RemoveItemFromContainer(this.name))
				{//Try and remove from the paperdoll if not found in the current container.
					GameWorldController.instance.playerUW.playerInventory.RemoveItemFromEquipment(this.name);
				}
				if (GameWorldController.instance.playerUW.playerInventory.ObjectInHand==this.name)
				{
					GameWorldController.instance.playerUW.playerInventory.ObjectInHand="";//Make sure there is not instance of this object in the players hand	
					UWHUD.instance.CursorIcon= UWHUD.instance.CursorIconDefault;
				}
				GameWorldController.instance.playerUW.playerInventory.Refresh();
				objectloaderinfo.InUseFlag=0;//Free up the slot
				Destroy (this.gameObject);
			}
			else
			{//just decrement the quantity value;
				Link--;
				ObjectInteraction.Split (this);
				GameWorldController.instance.playerUW.playerInventory.Refresh();
			}
		}

		/// <summary>
		/// Creates a new game object at run time.
		/// </summary>
		/// <returns>The new object.</returns>
		/// <param name="NewItem_id">New item identifier.</param>
		public static ObjectInteraction CreateNewObject (int NewItem_id)
		{
				//Create the new object
				GameObject myObj = new GameObject ("SummonedObject_" + GameWorldController.instance.playerUW.PlayerMagic.SummonCount++);
				myObj.layer = LayerMask.NameToLayer ("UWObjects");
				myObj.transform.position = GameWorldController.instance.playerUW.playerInventory.InventoryMarker.transform.position;
				myObj.transform.parent = GameWorldController.instance.playerUW.playerInventory.InventoryMarker.transform;
				GameObject SpriteObj = ObjectInteraction.CreateObjectGraphics (myObj, _RES + "/Sprites/Objects/Objects_" + NewItem_id, true);
				ObjectMasters objM = GameWorldController.instance.objectMaster;
				ObjectInteraction objInt = ObjectInteraction.CreateObjectInteraction (myObj, 0.5f, 0.5f, 0.5f, 0.5f, objM.particle [NewItem_id], objM.InvIcon [NewItem_id], objM.InvIcon [NewItem_id], objM.type [NewItem_id], NewItem_id, 1, 40, 0, objM.isMoveable [NewItem_id], 1, 0, 1, 1, 0, 0, 1);
				//Some known examples that occur
				switch (NewItem_id) {
				case 10://Sword of justice
						myObj.AddComponent<WeaponMelee>();
						break;
				case 47://Dragonskin boots
						myObj.AddComponent<Boots>();
						objInt.Link=  SpellEffect.UW1_Spell_Effect_Flameproof_alt01+256-16;
						objInt.isEnchanted=true;
						break;
				case 276://Exploding book
						myObj.AddComponent<ReadableTrap>();
						break;
				case 299:
						//Fishing pole
						myObj.AddComponent<FishingPole> ();
						break;
				case 182://fish
				case 183://Popcorn
				case 217://Rotworm corpse						
						Food fd = myObj.AddComponent<Food> ();
						fd.Nutrition = 5;
						break;
				case 314://Scroll given by biden?
						myObj.AddComponent<Readable>();//Scroll given by Biden
						break;
				case 339://Boulders
				case 340:
				case 341:
				case 342:
						myObj.AddComponent<Boulder>();	
						break;
				default:
						myObj.AddComponent<object_base> ();
						break;
				}
				//GameWorldController.instance.playerUW.playerInventory.ObjectInHand = myObj.name;
				//myObj.AddComponent<StoreInformation>();
				//SpriteObj.AddComponent<StoreInformation>();
				return objInt;//myObj.GetComponent<ObjectInteraction> ();
		}


		/// <summary>
		/// What image frames does an weapon hit on this object create.
		/// </summary>
		/// <returns>The hit frame start.</returns>
		public int GetHitFrameStart()
		{

			if (this.GetComponent<NPC>()==null)
			{
					return 45;//Standard explosion
			}
			else
			{
				switch (GameWorldController.instance.critter.Blood[item_id-64])
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
			if (this.GetComponent<NPC>()==null)
			{
					return 49;//End of explosion
			}
			else
			{
				switch (GameWorldController.instance.critter.Blood[item_id-64])
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
			if ((isEnchanted==true) || (this.GetComponent<Readable>()!=null))
			{
				return 1;
			}
			else
			{
				if (isQuant==true)
				{
					return Link;
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
		public static GameObject CreateObjectGraphics(GameObject myObj,string AssetPath, bool BillBoard)
		{	
			//Create a sprite.
			GameObject SpriteController = new GameObject(myObj.name + "_sprite");
			SpriteController.transform.position = myObj.transform.position;
			SpriteRenderer mysprite = SpriteController.AddComponent<SpriteRenderer>();//Adds the sprite gameobject
			Sprite image = Resources.Load <Sprite> (AssetPath);//Loads the sprite.
			mysprite.sprite = image;//Assigns the sprite to the object.
			SpriteController.transform.parent = myObj.transform;
			SpriteController.transform.Rotate(0f,0f,0f);
			SpriteController.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
			mysprite.material= Resources.Load<Material>("Materials/SpriteShader");
			//Create a billboard script for display
			if (BillBoard)
			{
				SpriteController.AddComponent<Billboard> ();
			}
			return SpriteController;
		}

		/// <summary>
		/// Creates an Object Interaction
		/// </summary>
		/// <returns>The object interaction.</returns>
		/// <param name="myObj">My object.</param>
		/// <param name="DimX">Dim x.</param>
		/// <param name="DimY">Dim y.</param>
		/// <param name="DimZ">Dim z.</param>
		/// <param name="CenterY">Center y.</param>
		/// <param name="WorldString">World string.</param>
		/// <param name="InventoryString">Inventory string.</param>
		/// <param name="EquipString">Equip string.</param>
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
		/// <param name="ChildName">Child name.</param>
		public static ObjectInteraction CreateObjectInteraction(GameObject myObj,float DimX,float DimY,float DimZ, float CenterY, string WorldString, string InventoryString, string EquipString, int ItemType, int ItemId, int link, int Quality, int Owner, int isMoveable, int isUsable, int isAnimated, int useSprite,int isQuant, int isEnchanted, int flags, int inUseFlag ,string ChildName)
		{
			GameObject newObj = new GameObject(myObj.name+"_"+ChildName);

			newObj.transform.parent=myObj.transform;
			newObj.transform.localPosition=new Vector3(0.0f,0.0f,0.0f);
			return CreateObjectInteraction (newObj,DimX,DimY,DimZ,CenterY , WorldString,InventoryString,EquipString,ItemType ,link, Quality, Owner,ItemId,isMoveable,isUsable, isAnimated, useSprite,isQuant,isEnchanted, flags,inUseFlag);
		}

		/// <summary>
		/// Creates an Object Interaction
		/// </summary>
		/// <returns>The object interaction.</returns>
		/// <param name="myObj">My object.</param>
		/// <param name="DimX">Dim x.</param>
		/// <param name="DimY">Dim y.</param>
		/// <param name="DimZ">Dim z.</param>
		/// <param name="CenterY">Center y.</param>
		/// <param name="WorldString">World string.</param>
		/// <param name="InventoryString">Inventory string.</param>
		/// <param name="EquipString">Equip string.</param>
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
		public static ObjectInteraction CreateObjectInteraction(GameObject myObj,float DimX,float DimY,float DimZ, float CenterY, string WorldString, string InventoryString, string EquipString, int ItemType, int ItemId, int link, int Quality, int Owner, int isMoveable, int isUsable, int isAnimated, int useSprite,int isQuant, int isEnchanted, int flags, int inUseFlag)
		{
				return CreateObjectInteraction (myObj,myObj,DimX,DimY,DimZ,CenterY, WorldString,InventoryString,EquipString,ItemType,ItemId,link,Quality,Owner,isMoveable,isUsable, isAnimated, useSprite,isQuant,isEnchanted, flags,inUseFlag);
		}

		/// <summary>
		/// Creates an Object Interaction
		/// </summary>
		/// <returns>The object interaction.</returns>
		/// <param name="myObj">My object.</param>
		/// <param name="parentObj">Parent object.</param>
		/// <param name="DimX">Dim x.</param>
		/// <param name="DimY">Dim y.</param>
		/// <param name="DimZ">Dim z.</param>
		/// <param name="CenterY">Center y.</param>
		/// <param name="WorldString">World string.</param>
		/// <param name="InventoryString">Inventory string.</param>
		/// <param name="EquipString">Equip string.</param>
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
		public static ObjectInteraction CreateObjectInteraction(GameObject myObj, GameObject parentObj,float DimX,float DimY,float DimZ, float CenterY, string WorldString, string InventoryString, string EquipString, int ItemType, int ItemId, int link, int Quality, int Owner, int isMoveable, int isUsable, int isAnimated, int useSprite, int isQuant, int isEnchanted, int flags, int inUseFlag)
		{
			ObjectInteraction objInteract = myObj.AddComponent<ObjectInteraction>();

			BoxCollider box =myObj.GetComponent<BoxCollider>();
			if ((box==null) && (myObj.GetComponent<NPC>()==null) && (isUsable==1))
			{
				//add a mesh for interaction
				box= myObj.AddComponent<BoxCollider>();
				box.size = new Vector3(0.2f,0.2f,0.2f);
				box.center= new Vector3(0.0f,0.1f,0.0f);
				if (isMoveable==1)
				{
					box.material= Resources.Load<PhysicMaterial>("Materials/objects_bounce");
				}
			}

			objInteract.WorldDisplayIndex = int.Parse(WorldString.Substring (WorldString.Length-3,3));
			objInteract.InvDisplayIndex= int.Parse (InventoryString.Substring (InventoryString.Length-3,3));

			if (isUsable==1)
			{
				objInteract.CanBeUsed=true;
			}

			objInteract.item_id=ItemId;//Internal ItemID
			objInteract.Link=link;
			objInteract.Quality=Quality;
			objInteract.Owner=Owner;
			objInteract.flags=flags;

			if (isMoveable==1)
			{
				objInteract.CanBePickedUp=true;
				Rigidbody rgd = parentObj.AddComponent<Rigidbody>();
				rgd.angularDrag=0.0f;
				GameWorldController.FreezeMovement(myObj);
			}

			if (ItemType !=ObjectInteraction.ANIMATION)
			{
				if (isAnimated==1)
				{
					objInteract.isAnimated=true;
				}

				if (useSprite==1)
				{
					objInteract.ignoreSprite=false;
				}
				else
				{
					objInteract.ignoreSprite=true;
				}
			}
			else
			{
				objInteract.ignoreSprite=true;
			}
			if (isQuant==1)
			{
					objInteract.isQuant=true;
			}
			if (isEnchanted==1)
			{
				objInteract.isEnchanted=true;
						//Debug.Log (myObj.name + " is enchanted. Take a look at it please.");
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
			switch(id)
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
			return ((isQuant) && (!isEnchanted));
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
					(mergingInto.Quality==mergingFrom.Quality)
			);
		}


		/// <summary>
		/// Merges the two items together. 
		/// </summary>
		/// <param name="mergingInto">Merging into.</param>
		/// <param name="mergingFrom">Merging from. This will be destroyed</param>
		public static void Merge(ObjectInteraction mergingInto, ObjectInteraction mergingFrom)
		{
			mergingInto.Link += mergingFrom.Link;
			mergingInto.GetComponent<object_base>().MergeEvent();
			Destroy(mergingFrom.gameObject);
		}

		/// <summary>
		/// Events for when two items are split apart. (coins mainly)
		/// </summary>
		/// <param name="splitFrom">Split from.</param>
		/// <param name="splitTo">Split to.</param>
		public static void Split(ObjectInteraction splitFrom, ObjectInteraction splitTo)
		{
			splitFrom.GetComponent<object_base>().Split ();
			splitTo.GetComponent<object_base>().Split();
		}

		/// <summary>
		/// Split the specified item.
		/// </summary>
		/// <param name="splitFrom">Split from.</param>
		public static void Split(ObjectInteraction splitFrom)
		{
			splitFrom.GetComponent<object_base>().Split ();
		}

		/*
		public ObjectInteraction CopyGameObjectInteraction(GameObject target)
		{
			//Copies a uw gameobject and it's properties
			//copy this object interaction.
			ObjectInteraction objIntNew = target.AddComponent<ObjectInteraction>();
			objIntNew.WorldDisplayIndex=WorldDisplayIndex;
			objIntNew.InvDisplayIndex=InvDisplayIndex;
			objIntNew.ignoreSprite=ignoreSprite;//For button handlers that do their own sprite work.
			objIntNew.item_id=item_id;
			objIntNew.flags=flags;
			objIntNew.CanBePickedUp=CanBePickedUp;
			objIntNew.CanBeUsed=CanBeUsed;//unimplemented
			objIntNew.PickedUp=PickedUp; //Test if object is in the inventory or in the open world in case there is different behaviours needed
			objIntNew.inventorySlot=inventorySlot;
			objIntNew.Owner=Owner;	//Used for keys
			objIntNew.Link=Link;	//Also quantity
			objIntNew.Quality=Quality;
			objIntNew.isQuant=isQuant;
			objIntNew.isEnchanted=isEnchanted;
			objIntNew.sr =sr;
			objIntNew.isAnimated=isAnimated;

			if (objIntNew.CanBePickedUp==true)
			{
				Rigidbody rgd = target.AddComponent<Rigidbody>();
				rgd.angularDrag=0.0f;
				GameWorldController.FreezeMovement(target);
			}

			BoxCollider box =objIntNew.GetComponent<BoxCollider>();
			if ((box==null) && (objIntNew.GetComponent<NPC>()==null) && (objIntNew.CanBeUsed==true))
			{
				//add a mesh for interaction
				box=target.AddComponent<BoxCollider>();
				box.size = new Vector3(0.2f,0.2f,0.2f);
				box.center= new Vector3(0.0f,0.1f,0.0f);
				if (objIntNew.CanBePickedUp==true)
				{
					box.material= Resources.Load<PhysicMaterial>("Materials/objects_bounce");
				}
			}
			return objIntNew;
		}
*/
		/// <summary>
		/// Changes the type of this object
		/// </summary>
		/// <returns><c>true</c>, if type was changed, <c>false</c> otherwise.</returns>
		/// <param name="newID">New ID.</param>
		/// <param name="newType">New type.</param>
		public virtual bool ChangeType(int newID, int newType)
		{//Changes the type of the object. Eg when destroyed and it needs to become debris.
			item_id=newID;
			WorldDisplayIndex=newID;
			InvDisplayIndex=newID;
			UpdateAnimation();
			return true;		
		}



		public static void CreateNPC(GameObject myObj, string NPC_ID, string EditorSprite ,int npc_whoami)
		{
				myObj.layer=LayerMask.NameToLayer("NPCs");
				myObj.tag="NPCs";
				NPC npc = myObj.AddComponent<NPC>();

				if (npc_whoami == 0)
				{
						npc.npc_whoami=256+(int.Parse (NPC_ID) -64);
				}

				//Probably only need to add this when an NPC supports ranged attacks?
				GameObject NpcLauncher = new GameObject(myObj.name + "_NPC_Launcher");
				NpcLauncher.transform.position=Vector3.zero; 
				//NpcLauncher.transform.rotation=Vector3.zero; 
				NpcLauncher.transform.parent=myObj.transform;
				NpcLauncher.transform.localPosition=new Vector3(0.0f,0.5f,0.1f);
				npc.NPC_Launcher=NpcLauncher;
				//npc.ai=ai;
				//NpcLauncher.AddComponent<StoreInformation>();

				GameObject myInstance = Resources.Load(_RES + "/animation/" + _RES + "_Base_Animator") as GameObject;
				GameObject newObj = (GameObject)GameObject.Instantiate(myInstance);
				newObj.name=myObj.name + "_Sprite";
				newObj.transform.parent=myObj.transform;
				newObj.transform.position = myObj.transform.position;
				newObj.AddComponent<StoreAnimator>();
				SpriteRenderer mysprite =  newObj.GetComponent<SpriteRenderer>();
				Sprite image = Resources.Load <Sprite> (EditorSprite);//Loads the sprite.

				mysprite.material= Resources.Load<Material>("Materials/SpriteShader");
				mysprite.sprite = image;//Assigns the sprite to the object.
				//CapsuleCollider cap = myObj.AddComponent<CapsuleCollider>();

				CharacterController cap  = myObj.AddComponent<CharacterController>();
				cap = myObj.GetComponent<CharacterController>();
				switch(int.Parse(NPC_ID))
				{
				case 97: //a_ghost
				case 99: //a_ghoul
				case 100: //a_ghost
				case 101: //a_ghost
				case 105: //a_dark_ghoul
				case 110: //a_ghoul	
				case 113: //a_dire_ghost
						npc.isUndead=true;
						break;
				}

				switch (int.Parse(NPC_ID))
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
						cap.isTrigger=false;
						cap.center = new Vector3(0.0f, 0.4f, 0.0f);
						cap.radius=0.2f;
						cap.height=0.7f;
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
						cap.isTrigger=false;
						cap.center = new Vector3(0.0f, 0.3f, 0.0f);
						cap.radius=0.3f;
						cap.height=0.3f;
						cap.skinWidth=0.05f;
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
						cap.isTrigger=false;
						cap.center = new Vector3(0.0f, 0.3f, 0.0f);
						cap.radius=0.3f;
						cap.height=0.3f;
						break;
				}

				cap.stepOffset=0.1f;//Stop npcs from climbing over each other
		}

		public static void SetNPCProps(GameObject myObj, 
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
		}


		public static void SetNPCProps(GameObject myObj, 
				int npc_whoami, int npc_xhome, int npc_yhome,
				int npc_hunger, int npc_health,
				int npc_hp, int npc_arms, int npc_power ,
				int npc_goal, int npc_attitude, int npc_gtarg,
				int npc_talkedto, int npc_level,int npc_name,
				string gtargName,
				string NavMeshRegion
		)
		{
				NPC npc = myObj.GetComponent<NPC>();
				if (npc!=null)
				{

						if ((npc.npc_whoami==0) && (npc_whoami  != 0))
						{
								npc.npc_whoami= npc_whoami;
						}
						npc.npc_xhome=npc_xhome;        //  x coord of home tile
						npc.npc_yhome=npc_yhome;        //  y coord of home tile
						npc.npc_hunger=npc_hunger;
						npc.npc_health=npc_health;
						npc.npc_hp=npc_hp;
						npc.npc_arms=npc_arms;          // (not used in uw1)
						npc.npc_power=npc_power;
						npc.npc_goal=npc_goal;          // goal that NPC has; 5:kill player 6:? 9:?
						npc.npc_attitude=npc_attitude;       //attitude; 0:hostile, 1:upset, 2:mellow, 3:friendly
						npc.npc_gtarg=npc_gtarg;         //goal target; 1:player
						npc.npc_talkedto=npc_talkedto;      // is 1 when player already talked to npc
						npc.npc_level=npc_level;
						npc.npc_name=npc_name;       //    (not used in uw1)
						npc.NavMeshRegion=NavMeshRegion;

						npc.gtargName=gtargName;
						Conversation cnv ;//= myObj.AddComponent<Conversation>();
						cnv=null;

						switch (myObj.GetComponent<NPC>().npc_whoami)
						{
						case 0:
						case 207://A worried spectre named warren
						case 248://Slasher of veils
						case 255://No conversation/monsters
						case 256:
						case 257:
						case 258:
						case 259:
						case 261:
						case 264:
						case 265:
						case 266:
						case 267:
						case 270:
						case 273:
						case 274:
						case 275:
						case 279:
						case 284:
						case 283:
						case 289:
						case 292:
						case 293:
						case 294:
						case 297:
						case 298:
						case 302:
						case 303:
						case 304:
						case 305:
						case 306:
						case 308:
						case 309:
						case 310:
						case 311:
						case 312:
						case 313:
								break;
						case 1://Corby
								cnv=(Conversation)myObj.AddComponent<Conversation_1>();break;
						case 2://Shak
								cnv=(Conversation)myObj.AddComponent<Conversation_2>();break;
						case 3://Goldthirst
								cnv=(Conversation)myObj.AddComponent<Conversation_3>();break;
						case 4://Shanlick
								cnv=(Conversation)myObj.AddComponent<Conversation_4>();break;
						case 5://Eyesnack
								cnv=(Conversation)myObj.AddComponent<Conversation_5>();break;
						case 6://Marrowsuck
								cnv=(Conversation)myObj.AddComponent<Conversation_6>();break;
						case 7://Ketchaval
								cnv=(Conversation)myObj.AddComponent<Conversation_7>();break;
						case 8://Retichall
								cnv=(Conversation)myObj.AddComponent<Conversation_8>();break;
						case 9://Vernix
								cnv=(Conversation)myObj.AddComponent<Conversation_9>();break;
						case 10://Lanugo
								cnv=(Conversation)myObj.AddComponent<Conversation_10>();break;
						case 12:// Dorna Ironfist
								cnv=(Conversation)myObj.AddComponent<Conversation_12>();break;
						case 13:// Morlock
								cnv=(Conversation)myObj.AddComponent<Conversation_13>();break;
						case 14:// Dr Owl
								cnv=(Conversation)myObj.AddComponent<Conversation_14>();break;
						case 15://Sseetharee
								cnv=(Conversation)myObj.AddComponent<Conversation_15>();break;
						case 16://Ishtass
								cnv=(Conversation)myObj.AddComponent<Conversation_16>();break;
						case 17://Sethar Strongarm
								cnv=(Conversation)myObj.AddComponent<Conversation_17>();break;
						case 18://Lakshi Longtooth
								cnv=(Conversation)myObj.AddComponent<Conversation_18>();break;
						case 19://Hagbard
								cnv=(Conversation)myObj.AddComponent<Conversation_19>();break;
						case 20://Gulik
								cnv=(Conversation)myObj.AddComponent<Conversation_20>();break;
						case 21://Steeltoe
								cnv=(Conversation)myObj.AddComponent<Conversation_21>();break;
						case 22://Golem
								cnv=(Conversation)myObj.AddComponent<Conversation_22>();break;
						case 23://Judy
								cnv=(Conversation)myObj.AddComponent<Conversation_23>();break;
						case 24://prisoner
								cnv=(Conversation)myObj.AddComponent<Conversation_24>();break;
						case 25://Talking door
								cnv=(Conversation)myObj.AddComponent<Conversation_25>();break;
						case 27://Garamon
								cnv=(Conversation)myObj.AddComponent<Conversation_27>();break;
						case 28://Zak
								cnv=(Conversation)myObj.AddComponent<Conversation_28>();break;
						case 64://Jaacar
								cnv=(Conversation)myObj.AddComponent<Conversation_64>();break;
						case 65://Eb
								cnv=(Conversation)myObj.AddComponent<Conversation_65>();break;
						case 66://Drog
								cnv=(Conversation)myObj.AddComponent<Conversation_66>();break;
						case 67://Bragit
								cnv=(Conversation)myObj.AddComponent<Conversation_67>();break;
						case 88://Brawnclan
								cnv=(Conversation)myObj.AddComponent<Conversation_88>();break;
						case 89://Hewstone
								cnv=(Conversation)myObj.AddComponent<Conversation_89>();break;
						case 90://Ironwit
								cnv=(Conversation)myObj.AddComponent<Conversation_90>();break;
						case 110://Gazer
								cnv=(Conversation)myObj.AddComponent<Conversation_110>();break;
						case 112://bandit
								cnv=(Conversation)myObj.AddComponent<Conversation_112>();break;
						case 113://bandit
								cnv=(Conversation)myObj.AddComponent<Conversation_113>();break;
						case 114://Iss'leek
								cnv=(Conversation)myObj.AddComponent<Conversation_114>();break;
						case 136://Oradinar
								cnv=(Conversation)myObj.AddComponent<Conversation_136>();break;
						case 137://Linnet
								cnv=(Conversation)myObj.AddComponent<Conversation_137>();break;
						case 138://Derek
								cnv=(Conversation)myObj.AddComponent<Conversation_138>();break;
						case 139://Trisch
								cnv=(Conversation)myObj.AddComponent<Conversation_139>();break;
						case 140://Ree
								cnv=(Conversation)myObj.AddComponent<Conversation_140>();break;
						case 141://Feznor
								cnv=(Conversation)myObj.AddComponent<Conversation_141>();break;
						case 142://Rodrick
								cnv=(Conversation)myObj.AddComponent<Conversation_142>();break;
						case 143://Biden
								cnv=(Conversation)myObj.AddComponent<Conversation_143>();break;
						case 144://Rawstag
								cnv=(Conversation)myObj.AddComponent<Conversation_144>();break;
						case 146://Doris
								cnv=(Conversation)myObj.AddComponent<Conversation_146>();break;
						case 147://Kyle
								cnv=(Conversation)myObj.AddComponent<Conversation_147>();break;
						case 148://Cecil
								cnv=(Conversation)myObj.AddComponent<Conversation_148>();break;
						case 161://Anjor
								cnv=(Conversation)myObj.AddComponent<Conversation_162>();break;
						case 162://Kneeknibble
								cnv=(Conversation)myObj.AddComponent<Conversation_162>();break;
						case 149://Meredith
								cnv=(Conversation)myObj.AddComponent<Conversation_149>();break;
						case 184://Delanrey
								cnv=(Conversation)myObj.AddComponent<Conversation_184>();break;
						case 185://Nilpont
								cnv=(Conversation)myObj.AddComponent<Conversation_185>();break;
						case 187://Illomo
								cnv=(Conversation)myObj.AddComponent<Conversation_187>();break;
						case 188://Gralwart
								cnv=(Conversation)myObj.AddComponent<Conversation_188>();break;
						case 189://Shenilor
								cnv=(Conversation)myObj.AddComponent<Conversation_189>();break;
						case 190://Bronus
								cnv=(Conversation)myObj.AddComponent<Conversation_190>();break;
						case 191://Ranthru
								cnv=(Conversation)myObj.AddComponent<Conversation_191>();break;
						case 192://Fyrgen
								cnv=(Conversation)myObj.AddComponent<Conversation_192>();break;
						case 193://Louvon
								cnv=(Conversation)myObj.AddComponent<Conversation_193>();break;
						case 194://Dominus
								cnv=(Conversation)myObj.AddComponent<Conversation_194>();break;
						case 208://Cardon
								cnv=(Conversation)myObj.AddComponent<Conversation_208>();break;
						case 209://guard (tybals lair checkpoint)
								cnv=(Conversation)myObj.AddComponent<Conversation_209>();break;
						case 210://Narutu
								cnv=(Conversation)myObj.AddComponent<Conversation_210>();break;
						case 211://Dantes
								cnv=(Conversation)myObj.AddComponent<Conversation_211>();break;
						case 212://Kallistan
								cnv=(Conversation)myObj.AddComponent<Conversation_212>();break;
						case 213://Fintor
								cnv=(Conversation)myObj.AddComponent<Conversation_213>();break;
						case 214://Bolinard
								cnv=(Conversation)myObj.AddComponent<Conversation_214>();break;
						case 215://Smonden
								cnv=(Conversation)myObj.AddComponent<Conversation_215>();break;
						case 216://guard (tybals prison troll)
								cnv=(Conversation)myObj.AddComponent<Conversation_216>();break;
						case 217://Gurstang
								cnv=(Conversation)myObj.AddComponent<Conversation_217>();break;
						case 218://guard (tybals lair checkpoint)
								cnv=(Conversation)myObj.AddComponent<Conversation_218>();break;
						case 219://guard (tybals lair checkpoint)
								cnv=(Conversation)myObj.AddComponent<Conversation_219>();break;
						case 220://guard (tybals prison)
								cnv=(Conversation)myObj.AddComponent<Conversation_220>();break;
						case 221://Imp
								cnv=(Conversation)myObj.AddComponent<Conversation_221>();break;
						case 222://guard (tybals lair)
								cnv=(Conversation)myObj.AddComponent<Conversation_222>();break;
						case 231://Tybal
								cnv=(Conversation)myObj.AddComponent<Conversation_231>();break;
						case 232://Caroso
								cnv=(Conversation)myObj.AddComponent<Conversation_232>();break;
						case 262://Generic Green Goblin
								cnv=(Conversation)myObj.AddComponent<Conversation_262>();break;
						case 263://Generic Green Goblin
								cnv=(Conversation)myObj.AddComponent<Conversation_263>();break;
						case 268://Generic Gray Goblin
								cnv=(Conversation)myObj.AddComponent<Conversation_268>();break;
						case 272://Generic Gray Goblin
								cnv=(Conversation)myObj.AddComponent<Conversation_272>();break;
						case 276://Generic Mountainman
								cnv=(Conversation)myObj.AddComponent<Conversation_276>();break;
						case 277://Generic Lizardman
								cnv=(Conversation)myObj.AddComponent<Conversation_277>();break;
						case 280://Generic Lizardman
								cnv=(Conversation)myObj.AddComponent<Conversation_280>();break;
						case 281://Generic Gray Lizardman
								cnv=(Conversation)myObj.AddComponent<Conversation_281>();break;
						case 282://Generic Outcast
								cnv=(Conversation)myObj.AddComponent<Conversation_282>();break;
						case 288://Generic Troll
								cnv=(Conversation)myObj.AddComponent<Conversation_288>();break;
						case 314://Wisp
								cnv=(Conversation)myObj.AddComponent<Conversation_288>();break;
						default:
								cnv=myObj.AddComponent<Conversation>();
								//Debug.Log ("Conversation "  + myObj.GetComponent<NPC>().npc_whoami + " is not implemented for " + myObj.name );
								break;
						}			
						if (cnv!=null)
						{
								cnv.npc= npc;
						}					
				}
		}



		/// <summary>
		/// Bouncing sound when object is thrown.
		/// </summary>
		/// <param name="collision">Collision.</param>
	void OnCollisionEnter(Collision collision) {
		if (PlaySoundEffects)
		{
			//if (aud!=null)
			//{
			//	aud.Play();		
			//}	
		}			
	}

	/// <summary>
	/// Gets the impact point location that will spawn blood when this object is hit.
	/// </summary>
	/// <returns>The impact point.</returns>
	public virtual Vector3 GetImpactPoint()
	{
		object_base item;
		item= this.GetComponent<object_base>();
		return item.GetImpactPoint();
	}


		/// <summary>
		/// Gets the game object that contains the location of the blood spawning.
		/// </summary>
		/// <returns>The impact game object.</returns>
	public virtual GameObject GetImpactGameObject()
	{
		object_base item;
		item= this.GetComponent<object_base>();
		return item.GetImpactGameObject();	
	}



		public void UpdatePosition()
		{
			if (ObjectLoader.isStatic(objectloaderinfo))	
			{
					return;
			}
			float dist =Vector3.Distance(this.transform.position,startPos);
			if (Vector3.Distance(this.transform.position,startPos)<=0.2f)
				{//No movement. Just update heading.
					heading= Mathf.RoundToInt(this.transform.rotation.eulerAngles.y/45f);	
				}
			else
			{
				float ceil = GameWorldController.instance.currentTileMap().CEILING_HEIGHT;
				//Updates the tilex & tileY,
				tileX = (short)Mathf.FloorToInt(this.transform.localPosition.x/1.2f);
				tileY = (short)Mathf.FloorToInt(this.transform.localPosition.z/1.2f);
				if (tileX>=64)
				{
						tileX=99;
				}
				if (tileY>=64)
				{
						tileY=99;
				}
				//updates the x,y and zpos
				zpos =(int)((((this.transform.localPosition.y*100f)/15f)/ ceil)*128f);
				if ((tileX<99) && (tileY<99))
				{//Update x & y
					//Remove corner
					float offX = (this.transform.position.x) - ((float)(tileX*1.2f));
					x = (int)(7f * (offX/1.2f));

					float offY = (this.transform.position.z) - ((float)(tileY*1.2f));
					y = (int)(7f * (offY/1.2f));
				}
				//updates the heading.
				heading= Mathf.RoundToInt(this.transform.rotation.eulerAngles.y/45f);	

			}
				objectloaderinfo.heading=heading;
				objectloaderinfo.x=x;
				objectloaderinfo.y=y;
				objectloaderinfo.tileX=tileX;
				objectloaderinfo.tileY=tileY;
			
			startPos=this.transform.position;
		}



		public static ObjectInteraction CreateNewObject (TileMap tm, ObjectLoaderInfo currObj, GameObject parent, Vector3 position)
		{//TODO: Make sure all object creation uses this function!

				GameObject myObj = new GameObject (ObjectLoader.UniqueObjectName(currObj));
				bool CreateSprite=true;
				bool skipRotate=false;
				bool RemoveBillboard=false;
				bool AddAnimation=false;
				myObj.transform.localPosition = position;
				myObj.transform.Rotate(0.0f,0.0f,0.0f);//Initial rotation.
				myObj.transform.parent = parent.transform;
				myObj.layer = LayerMask.NameToLayer ("UWObjects");
				ObjectMasters objM = GameWorldController.instance.objectMaster;
				ObjectInteraction objInt = ObjectInteraction.CreateObjectInteraction (myObj, 0.5f, 0.5f, 0.5f, 0.5f, objM.particle [currObj.item_id], objM.InvIcon [currObj.item_id], objM.InvIcon [currObj.item_id], objM.type [currObj.item_id], currObj.item_id, currObj.link, currObj.quality, currObj.owner, objM.isMoveable[currObj.item_id], objM.isUseable[currObj.item_id], objM.isAnimated[currObj.item_id], objM.useSprite[currObj.item_id], currObj.is_quant, currObj.enchantment, currObj.flags, currObj.InUseFlag);
				objInt.next=currObj.next;
				objInt.link=currObj.link;
				objInt.quality=currObj.quality;
				objInt.enchantment=currObj.enchantment;
				objInt.doordir=currObj.doordir;
				objInt.invis=currObj.invis;
				objInt.texture=currObj.texture;
				objInt.zpos=currObj.zpos;
				objInt.x=currObj.x;
				objInt.y=currObj.y;
				objInt.heading=currObj.heading;
				objInt.zpos=currObj.zpos;
				objInt.owner=currObj.owner;
				objInt.tileX=currObj.tileX;
				objInt.tileY=currObj.tileY;
				objInt.objectloaderinfo = currObj;//Link back to the list directly.
				//For now just generic.
				switch (GameWorldController.instance.objectMaster.type[currObj.item_id])
				{
				case NPC_TYPE:
						CreateSprite=false;
						CreateNPC(myObj,currObj.item_id.ToString(),"UW1/Sprites/Objects/OBJECTS_" + currObj.item_id.ToString() ,currObj.npc_whoami);
						SetNPCProps(myObj, currObj.npc_whoami,currObj.npc_xhome,currObj.npc_yhome,currObj.npc_hunger,currObj.npc_health,currObj.npc_hp,currObj.npc_arms,currObj.npc_power,currObj.npc_goal,currObj.npc_attitude,currObj.npc_gtarg,currObj.npc_talkedto,currObj.npc_level,currObj.npc_name,"", tm.GetTileRegionName(currObj.tileX,currObj.tileY));
						Container.PopulateContainer(myObj.AddComponent<Container>(),objInt);
						break;
				case HIDDENDOOR:
				case DOOR:
				case PORTCULLIS:
						myObj.AddComponent<DoorControl>();
						DoorControl.CreateDoor(myObj, objInt);
						myObj.transform.Rotate(-90f,(objInt.heading*45f)- 180f,0f,Space.World);//I rotate here since my modelling is crap!

						//UnityRotation(game, -90, currobj.heading - 180 + OpenAdju, 0);
						skipRotate=true;
						CreateSprite=false;
						break;
				case CONTAINER:						
						Container.PopulateContainer(myObj.AddComponent<Container>(),objInt);
						break;
				case KEY:
						myObj.AddComponent<DoorKey>();
						break;
						//case ACTIVATOR:
						//case BUTTON:
						//case A_DO_TRAP:
				case BOOK:
				case SCROLL:
						myObj.AddComponent<Readable>();
						break;
				case SIGN:
						RemoveBillboard=true;
						myObj.AddComponent<Sign>();
						break;
				case RUNE:
						myObj.AddComponent<RuneStone>();
						break;
				case RUNEBAG:
						myObj.AddComponent<RuneBag>();
						break;
				case FOOD:
						myObj.AddComponent<Food>();
						break;
				case MAP:
						myObj.AddComponent<Map>();
						break;
				case HELM:
						myObj.AddComponent<Helm>();
						break;
				case ARMOUR:
						myObj.AddComponent<Armour>();
						break;
				case GLOVES:
						myObj.AddComponent<Gloves>();
						break;
				case BOOT:
						myObj.AddComponent<Boots>();
						break;
				case LEGGINGS:
						myObj.AddComponent<Leggings>();
						break;
				case SHIELD:
						myObj.AddComponent<Shield>();
						break;
				case WEAPON:
						myObj.AddComponent<WeaponMelee>();
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
						AddAnimation=true;
						break;
				case SHRINE:
						myObj.AddComponent<Shrine>();
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
						break;
				case LEECH:
						myObj.AddComponent<Leech>();
						break;
				case FISHING_POLE:
						myObj.AddComponent<FishingPole>();
						break;
				case ZANIUM:
						myObj.AddComponent<Zanium>();
						break;
				case INSTRUMENT:
						myObj.AddComponent<Instrument>();
						break;
				case BEDROLL:
						myObj.AddComponent<Bedroll>();
						break;
				case TREASURE://or gold
						myObj.AddComponent<Coin>();
						break;
				case BOULDER:
						myObj.AddComponent<Boulder>();
						break;
				case ORB:
						myObj.AddComponent<Orb>();
						break;
				case BUTTON:
						myObj.AddComponent<ButtonHandler>();
						RemoveBillboard=true;
						break;
				case A_MOVE_TRIGGER :
				case A_STEP_ON_TRIGGER:
						myObj.AddComponent<a_move_trigger>();
						break;
				case A_PICK_UP_TRIGGER:
						myObj.AddComponent<a_pick_up_trigger>();
						break;
				case A_USE_TRIGGER:
				case A_LOOK_TRIGGER:
				case AN_OPEN_TRIGGER:
				case AN_UNLOCK_TRIGGER:
						myObj.AddComponent<trigger_base>();	
						break;
				case A_DAMAGE_TRAP:
						myObj.AddComponent<a_damage_trap>();
						break;
				case A_TELEPORT_TRAP:
						myObj.AddComponent<a_teleport_trap>();
						break;
				case A_ARROW_TRAP:
						myObj.AddComponent<a_arrow_trap>();
						break;
				case A_PIT_TRAP:
						myObj.AddComponent<a_pit_trap>();
						break;
				case A_CHANGE_TERRAIN_TRAP:
						myObj.AddComponent<a_change_terrain_trap>();
						break;
				case A_SPELLTRAP:
						myObj.AddComponent<a_spelltrap>();
						break;
				case A_CREATE_OBJECT_TRAP:
						myObj.AddComponent<a_create_object_trap>();
						break;
				case A_DOOR_TRAP:
						myObj.AddComponent<a_door_trap>();
						break;
				case A_WARD_TRAP:
						myObj.AddComponent<a_ward_trap>();
						break;
				case A_TELL_TRAP:
						myObj.AddComponent<a_tell_trap>();
						break;
				case A_DELETE_OBJECT_TRAP:
						myObj.AddComponent<a_delete_object_trap>();
						break;
				case AN_INVENTORY_TRAP:
						myObj.AddComponent<an_inventory_trap>();
						break;
				case A_SET_VARIABLE_TRAP:
						myObj.AddComponent<a_set_variable_trap>();
						break;
				case A_CHECK_VARIABLE_TRAP:
						myObj.AddComponent<a_check_variable_trap>();
						break;
				case A_COMBINATION_TRAP:
						myObj.AddComponent<a_combination_trap>();
						break;
				case A_TEXT_STRING_TRAP:
						myObj.AddComponent<a_text_string_trap>();
						break;
				case TMAP_CLIP:
				case TMAP_SOLID:
						myObj.AddComponent<TMAP>();
						CreateSprite=false;
						RemoveBillboard=true;
						break;
				case FOUNTAIN:
				case A_FOUNTAIN:
						myObj.AddComponent<Fountain>();
						break;
				case ANIMATION:
						myObj.AddComponent<object_base>();
						AddAnimation=true;
						break;
				case BRIDGE:
						myObj.AddComponent<object_base>();
						CreateSprite=false;
						break;
				case A_DO_TRAP:
						{
							switch (objInt.quality)	
							{
							case 0x02://Camera
									myObj.AddComponent<a_do_trap_camera>();break;
							case 0x03://platform
									myObj.AddComponent<a_do_trap_platform>();break;
							case 0x18://bullfrog
									myObj.AddComponent<a_do_trapBullfrog>();break;
							case 0x2a://Gronk conversation
									myObj.AddComponent<a_do_trap_conversation>();break;
							case 0x28://emerald puzzle on level 6
									myObj.AddComponent<a_do_trap_emeraldpuzzle>();break;
							case 0x3F://end game sequence
									myObj.AddComponent<a_do_trap_EndGame>();break;
							default:
									myObj.AddComponent<trap_base>();break;
							}
							break;
						}
				default:
						myObj.AddComponent<object_base> ();
						break;
				}



				if(CreateSprite)
				{
						GameObject SpriteObj = ObjectInteraction.CreateObjectGraphics (myObj, _RES + "/Sprites/Objects/Objects_" + currObj.item_id,!RemoveBillboard);		
				}


				if (!skipRotate)
				{
					myObj.transform.Rotate(0.0f,currObj.heading*45f,0.0f);//final rotation		
				}

				if (AddAnimation)
				{//This is a hack!
					AnimationOverlay ao= myObj.AddComponent<AnimationOverlay>();					
					ao.StartFrame=GameWorldController.instance.objectMaster.isAnimated[currObj.item_id] ;
					ao.NoOfFrames=GameWorldController.instance.objectMaster.useSprite[currObj.item_id] ;
				}
				return objInt;
		}



}
