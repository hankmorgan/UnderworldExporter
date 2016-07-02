using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using RAIN.BehaviorTrees;
using RAIN.Core;
using RAIN.Minds;
using RAIN.Navigation;


public class ObjectInteraction : MonoBehaviour {

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
	public const int MOONSTONE =89;
	public const int LEECH= 91;
	public const int FISHING_POLE= 92;
	//public static Text MessageLog;

	public Sprite InventoryDisplay;
	public Sprite EquipDisplay;
	private Sprite WorldDisplay;

	public string EquipString;

	public int WorldDisplayIndex;
	public int InvDisplayIndex;

	public bool ignoreSprite;//For button handlers that do their own sprite work.

	public int item_id;
	public int flags;
	public bool InUse;

	public static GameObject InvMarker;//=GameObject.Find ("InventoryMarker");

	public static UWCharacter playerUW;

	public bool CanBePickedUp;
	public bool CanBeUsed;//unimplemented
	//public bool CanBeMoved;//unimplemented

	public bool PickedUp; //Test if object is in the inventory or in the open world in case there is different behaviours needed

	private AudioSource audSource;

	public int inventorySlot=-1;

	public int ItemType; //UWexporter item type id

	//UW specific info.
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
	private bool animationStarted;

	//Common properties

	//Object weights unit * 0.1st
	public static int[] Weight
		= {
		24,		40,		32,		8,		16,		24,		32,		16,		24,		32,		34,		32,		36,
		28,		28,		0,		1,		2,		1,		4,		0,		0,		0,		0,		4,		12,
		24,		0,		0,		0,		0,		16,		20,		40,		80,		16,		32,		64,		8,
		12,		16,		12,		16,		20,		8,		12,		16,		32,		4,		16,		16,		0,
		0,		0,		1,		48,		1,		1,		1,		48,		28,		22,		28,		52,		40,
		40,		40,		40,		300,		40,		600,		600,		40,		40,		500,		100,
		600,		600,		600,		0,		600,		40,		40,		300,		700,		800,
		700,		2000,		800,		800,		800,		1000,		300,		800,		800,
		800,		1300,		1,		800,		600,		1,		1,		300,		500,		800,
		600,		500,		500,		500,		500,		600,		1300,		1600,		1,
		4000,		500,		2000,		1000,		1500,		4000,		1000,		4000,		1,
		600,		2000,		0,		0,		613,		2,		2,		4,		4,		6,		6,
		1,		1,		1,		1,		12,		12,		12,		8,		4,		4,		6,		2,		1,
		4,		6,		2,		1,		4,		0,		0,		0,		0,		0,		0,		0,		0,
		1,		4,		1,		1,		1,		1,		1,		1,		4,		8,		12,		8,		16,
		0,		0,		16,		7,		5,		2,		1,		1,		4,		10,		1,		2,		2,		4,
		3,		3,		4,		4,		4,		4,		4,		4,		4,		4,		4,		4,		4,
		4,		4,		4,		4,		4,		4,		4,		4,		4,		4,		4,		4,		4,
		4,		4,		4,		4,		4,		4,		4,		4,		4,		4,		4,		0,		0,
		1,		1,		1,		1,		1,		1,		0,		0,		0,		0,		0,		0,		0,
		0,		0,		0,		0,		0,		0,		0,		0,		0,		0,		0,		0,		0,
		0,		0,		0,		0,		1,		1,		1,		1,		1,		1,		1,		1,		1,
		1,		1,		1,		1,		1,		1,		0,		4,		4,		4,		4,		4,		4,
		4,		4,		20,		12,		40,		8,		1,		30,		3,		4,		4,		12,		0,
		4,		16,		4,		8,		4,		4,		0,		4,		4,		4,		4,		0,		0,
		4,		4,		4,		4,		4,		4,		8,		4,		2,		2,		2,		2,		2,
		2,		2,		2,		0,		0,		0,		0,		0,		0,		0,		0,		0,		0,
		0,		0,		0,		0,		0,		0,		0,		0,		0,		0,		0,		128,		32,
		0,		0,		0,		0,		0,		80,		0,		0,		0,		0,		0,		0,		0,
		0,		0,		0,		0,		0,		0,		0,		0,		0,		0,		0,		0,		0,
		0,		0,		0,		0,		0,		0,		0,		0,		0,		0,		0,		0,		0,
		0,		0,		0,		0,		0,		0,		0,		0,		0,		0,		0,		0,		0,
		0,		0,		0,		0,		0,		0,		0,		0,		0,		0,		0,		0,		0,
		0,		0,		0,		0,		0,		0,		0,		0,		0,		0,		0,		0,		0,
		0,		0,		0,		0,		0,		0,		0,		0,		0,		0,		0,		0,		0,
		0,		0,		0,		0,		0,		0,		0,		0,		0,		0,		0,		0,		0,
		0,		0,		0,		0,		0,		0,		0,		0,		0,		0,		0,		0,		0,
		0,		0,		0,		0
	};


		//private bool KillMe;
	// Use this for initialization

	void Start () {
		//if (MessageLog==null)
		//{
			//MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
		//}

		if (InvMarker==null)
		{
		InvMarker=GameWorldController.instance.InventoryMarker;//GameObject.Find ("InventoryMarker");
		}
		sr= this.gameObject.GetComponentInChildren<SpriteRenderer>();
		/*		if (this.GetComponent<EmptyObjectIdentifier>()!=null)
				{
						//this.gameObject.transform.DestroyChildren();
						//DestroyImmediate(this.gameObject);
						//KillMe=true;
				}*/
				//this.ser
		/*if ( ( (this.gameObject.transform.position==Vector3.zero) || (this.gameObject.transform.position==new Vector3(0,2000,2000)))  && (this.transform.parent==null))
		{
				Debug.Log(this.gameObject.name+"item at zero");
				Destroy(this.gameObject);
		}*/
	}

	void Update()
	{
				//if (KillMe==true)
				//{
				//		this.gameObject.transform.DestroyChildren();
				//		DestroyImmediate(this.gameObject);
				//}
		if (ignoreSprite == false)
		{
			if (animationStarted==false)
			{
				//CancelInvoke("UpdateAnimation");
				animationStarted=true;

				if (isAnimated==true)
				{
					InvokeRepeating("UpdateAnimation",0.2f,0.2f);
				}
				else
				{
					UpdateAnimation();
				}
			}
		}

	}

	public void UpdateAnimation()
	{
		if (sr== null)
		{
			sr=this.GetComponentInChildren<SpriteRenderer>();
		}
		//if (this.PickedUp==true)
		//{
		//	InventoryDisplay= tc.RequestSprite(InvDisplayIndex,isAnimated);
			//InventoryDisplay=sr.sprite;
		//}
		//else
		//{
		if (sr !=null)
		{
			sr.sprite= tc.RequestSprite(WorldDisplayIndex,isAnimated);
			InventoryDisplay= tc.RequestSprite(InvDisplayIndex,isAnimated);
			if (inventorySlot!=-1)
			{
				playerUW.playerInventory.Refresh(inventorySlot);
			}
		}
			
		  //tc.RequestSprite(sr.sprite, WorldDisplayIndex,isAnimated);
			
			//tc.RequestSprite(InventoryDisplay,InvDisplayIndex,isAnimated);
		//}
	}

	public Sprite GetInventoryDisplay()
	{
		if (InventoryDisplay==null)
		{
			InventoryDisplay =tc.RequestSprite(InvDisplayIndex,isAnimated);
		}
		return InventoryDisplay;
	}

	public void SetInventoryDisplay(Sprite NewSprite)
	{
		InventoryDisplay=NewSprite;
	}

	public Sprite GetEquipDisplay()
	{
		if (EquipDisplay==null)
		{
			EquipDisplay= tc.RequestSprite(EquipString);
		}
		return EquipDisplay;
	}
	
	public void SetEquipDisplay(Sprite NewSprite)
	{
		EquipDisplay=NewSprite;
	}

	public Sprite GetWorldDisplay()
	{
		return WorldDisplay;
	}
	
	public void SetWorldDisplay(Sprite NewSprite)
	{
		WorldDisplay=NewSprite;
		sr.sprite=WorldDisplay;
	}

	public void RefreshAnim()
	{
		animationStarted=false;
	}

	public UWCharacter getPlayerUW()
		{//Quickly get the player character for other components.
		return playerUW;
		}

//	public StringController getStringController()
	//{//Quickly get the string controller for other components.
	//	return SC;
	//}

	public ScrollController getMessageLog()
	{
		return playerUW.playerHud.MessageScroll;//MessageLog;
	}

	public bool Attack(int damage)
	{
				/*
		switch(ItemType)
		{
			case NPC_TYPE:
				{
					NPC npc = this.GetComponent<NPC>();
					npc.ApplyAttack(damage);
					break;
				}
			case DOOR:
			case HIDDENDOOR:
				{
				DoorControl dc= this.GetComponent<DoorControl>();
				dc.ApplyAttack(damage);
				break;
				}
		}*/
		this.GetComponent<object_base>().ApplyAttack(damage);
		return true;
	}


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

	public bool Use()
	{//Code to activate objects by type.
		//Objects will return true if they have done everything that needs to be done and false if they expect the calling code to do something instead.
		GameObject ObjectInHand =null;// = new GameObject();
		object_base item=null;//Base object class

		ObjectInHand=playerUW.playerInventory.GetGameObjectInHand();
		if (ObjectInHand != null)
		{
			//First do a combineobject test. This will implement object combinatiosn defined by UW1/2
		    if (CombineObject(this.gameObject,ObjectInHand))
			{
				return true;
			}	
		}


		item = this.GetComponent<object_base>();
		if (item!=null)
		{
			return item.use ();
		}
		else
		{
			return false;
		}
	}


	public bool Pickup()
	{
		//TODO  Do I have to put a pickup trigger test here?
		//To call events when an object is picked up.
		object_base item=null;
		item=this.GetComponent<object_base>();
	//switch(ItemType)
		//{
	//		case  SILVERSEED:
		//		item = (SilverSeed)this.GetComponent<SilverSeed>();
		//		break;
		//}
		if (item!=null)
		{
			return(item.PickupEvent());
		}
		else
		{
			return false;
		}
	}


	public bool Equip(int SlotNo)
	{//To handle what happens when an item (typically armour is equipped
		Debug.Log ("Equip Event on " + this.gameObject.name);
		inventorySlot=SlotNo;
		object_base item=null;
		item=this.GetComponent<object_base>();
		if( item !=null)
		{
			return (item.EquipEvent(SlotNo));
		}
		else
		{
			return false;
		}
	}

	public bool UnEquip(int SlotNo)
	{//To handle what happens when an item (typically armour is unequipped
		Debug.Log ("Unequip Event on " + this.gameObject.name);
		inventorySlot=-1;
		object_base item=null;
		item=this.GetComponent<object_base>();
		if( item !=null)
		{
			return (item.UnEquipEvent(SlotNo));
		}
		else
		{
			return false;
		}
	}

	public bool TalkTo()
	{
		//NPC NPCCharacter = this.GetComponent<NPC>();
		//if (NPCCharacter != null)
		//{
		//	NPCCharacter.TalkTo();
		//}
		object_base item=null;
		item=this.GetComponent<object_base>();
		return item.TalkTo();
	}

	public bool FailMessage()
	{
			object_base objbase= this.GetComponent<object_base>();
			return objbase.FailMessage();
	}

	public bool CombineObject(GameObject InputObject1, GameObject InputObject2)
	{//Combines two objects per the UW1/UW2 cmb.dat lists
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
		switch (playerUW.game)
		{
		case 1://uw1
			{
			lstInput1= new int[9]{149,225,225,226,225,226,227,149,284};
			lstDestroy1 =new int[9]{0,1,1,1,1,1,1,0,1};
			lstInput2 =new int[9]{278,226,227,227,229,228,230,180,216};
			lstDestroy2=new int[9]{1,1,1,1,1,1,1,1,1};
			lstOutput =new int[9]{277,230,228,229,231,231,231,183,299};
			}
			break;
		case 2://uw2
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

				//Create the new object
				GameObject myObj=  new GameObject("SummonedObject_" + playerUW.PlayerMagic.SummonCount++);
				myObj.layer=LayerMask.NameToLayer("UWObjects");
				myObj.transform.position = playerUW.playerInventory.InventoryMarker.transform.position;
				myObj.transform.parent=playerUW.playerInventory.InventoryMarker.transform;
				ObjectInteraction.CreateObjectGraphics(myObj,"UW1/Sprites/OBJECTS_" + lstOutput[i],true);

				switch (lstOutput[i])
				{
				case 299://Fishing pole
					ObjectInteraction.CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/OBJECTS_" + lstOutput[i].ToString("000"), "UW1/Sprites/OBJECTS_" + lstOutput[i].ToString("000"), "UW1/Sprites/OBJECTS_" + lstOutput[i].ToString("000"), ObjectInteraction.FISHING_POLE, lstOutput[i], 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
					myObj.AddComponent<FishingPole>();break;
				case 183://Popcorn
					ObjectInteraction.CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/OBJECTS_" + lstOutput[i].ToString("000"), "UW1/Sprites/OBJECTS_" + lstOutput[i].ToString("000"), "UW1/Sprites/OBJECTS_" + lstOutput[i].ToString("000"), ObjectInteraction.FOOD, lstOutput[i], 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
					Food fd = myObj.AddComponent<Food>();
					fd.Nutrition=5;
					break;
				default:
					ObjectInteraction.CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/OBJECTS_" + lstOutput[i].ToString("000"), "UW1/Sprites/OBJECTS_" + lstOutput[i].ToString("000"), "UW1/Sprites/OBJECTS_" + lstOutput[i].ToString("000"), 23, lstOutput[i], 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
					myObj.AddComponent<object_base>();break;
				}
				playerUW.playerInventory.ObjectInHand=myObj.name;
				ObjectInteraction CreatedObjectInt = myObj.GetComponent<ObjectInteraction>();
				if (CreatedObjectInt!=null)
					{
					CreatedObjectInt.UpdateAnimation();
					playerUW.CursorIcon=CreatedObjectInt.InventoryDisplay.texture;
					}
				
				UWCharacter.InteractionMode=UWCharacter.InteractionModePickup;
				InteractionModeControl.UpdateNow=true;
					return true;
				}
			}

		return false;
	}

	public void consumeObject()
	{
		if((isQuant ==false) || ((isQuant) && (Link==1)) || (isEnchanted==true))
		  {//the last of the item or is not a quantity;
			Container cn = playerUW.playerInventory.GetCurrentContainer();
			//Code for objects that get destroyed when they are used. Eg food, potion, fuel etc
			if (!cn.RemoveItemFromContainer(this.name))
				{//Try and remove from the paperdoll if not found in the current container.
				playerUW.playerInventory.RemoveItemFromEquipment(this.name);
				}
				playerUW.playerInventory.Refresh();
				Destroy (this.gameObject);
			}
			else
			{//just decrement the quantity value;
				Link--;
				ObjectInteraction.Split (this);
				playerUW.playerInventory.Refresh();

			}

	}

	public int GetHitFrameStart()
	{//What image frames does an weapon hit on this object create.

		if (this.GetComponent<NPC>()==null)
		{
			return 45;//Standard explosion
		}
		else
		{
			return 0;//Blood spatter.
		}
	}

	public int GetHitFrameEnd()
	{
		if (this.GetComponent<NPC>()==null)
		{
			return 49;//End of explosion
		}
		else
		{
			return 5;//end of blood splatter
		}
	}


	/*
	void OnCollisionEnter(Collision collision)
		
	{

	//	Debug.Log (this.gameObject.name);
		//AudioSource audio= this.GetComponent<AudioSource>();
		if (audSource!=null)
		{
			Debug.Log (collision.gameObject.name);
			audSource.Play();
		}
		else
		{
			audSource= this.GetComponent<AudioSource>();
		}
	}*/

	public int GetQty()
	{//Gets the true quantity of this object
		if (isEnchanted==true)
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


	public float GetWeight()
	{//Return the weight of the object stack
		return this.GetComponent<object_base>().GetWeight();
		//return (float)(GetQty())*Weight[item_id]*0.1f;
	}



	public static void CreateObjectGraphics(GameObject myObj,string AssetPath, bool BillBoard)
	{	
		//Create a sprite.
		GameObject SpriteController = new GameObject(myObj.name + "_sprite");
		SpriteController.transform.position = myObj.transform.position;
		
		SpriteRenderer mysprite = SpriteController.AddComponent<SpriteRenderer>();//Adds the sprite gameobject
		//mysprite.transform.position = new Vector3 (0f, 0f, 0f);
		//Sprite image = Resources.LoadAssetAtPath <Sprite> (AssetPath);//Loads the sprite.
		Sprite image = Resources.Load <Sprite> (AssetPath);//Loads the sprite.
		mysprite.sprite = image;//Assigns the sprite to the object.
		SpriteController.transform.parent = myObj.transform;
		SpriteController.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
		mysprite.material= Resources.Load<Material>("Materials/SpriteShader");
		//Create a billboard script for display
		// Billboard ScriptController = 
		if (BillBoard)
		{
			SpriteController.AddComponent<Billboard> ();
		}
	}
	
	public static ObjectInteraction CreateObjectInteraction(GameObject myObj,float DimX,float DimY,float DimZ, float CenterY, string WorldString, string InventoryString, string EquipString, int ItemType, int ItemId, int link, int Quality, int Owner, int isMoveable, int isUsable, int isAnimated, int useSprite,int isQuant, int isEnchanted, int flags, int inUseFlag ,string ChildName)
	{
		GameObject newObj = new GameObject(myObj.name+"_"+ChildName);
		
		newObj.transform.parent=myObj.transform;
		newObj.transform.localPosition=new Vector3(0.0f,0.0f,0.0f);
		return CreateObjectInteraction (newObj,DimX,DimY,DimZ,CenterY , WorldString,InventoryString,EquipString,ItemType ,link, Quality, Owner,ItemId,isMoveable,isUsable, isAnimated, useSprite,isQuant,isEnchanted, flags,inUseFlag);
	}
	
	public static ObjectInteraction CreateObjectInteraction(GameObject myObj,float DimX,float DimY,float DimZ, float CenterY, string WorldString, string InventoryString, string EquipString, int ItemType, int ItemId, int link, int Quality, int Owner, int isMoveable, int isUsable, int isAnimated, int useSprite,int isQuant, int isEnchanted, int flags, int inUseFlag)
	{
		return CreateObjectInteraction (myObj,myObj,DimX,DimY,DimZ,CenterY, WorldString,InventoryString,EquipString,ItemType,ItemId,link,Quality,Owner,isMoveable,isUsable, isAnimated, useSprite,isQuant,isEnchanted, flags,inUseFlag);
	}
	
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
		
		//SpriteRenderer objSprite =  myObj.transform.FindChild(myObj.name + "_sprite").GetComponent<SpriteRenderer>();
		//		SpriteRenderer objSprite =  parentObj.GetComponentInChildren<SpriteRenderer>();
		
		//		objInteract.WorldString=WorldString;
		//		objInteract.InventoryString=InventoryString;
		objInteract.EquipString=EquipString;
		//objInteract.InventoryDisplay=InventoryString;
		objInteract.ItemType=ItemType;//UWexporter id type
		objInteract.item_id=ItemId;//Internal ItemID
		objInteract.Link=link;
		objInteract.Quality=Quality;
		objInteract.Owner=Owner;
		objInteract.flags=flags;
		if (inUseFlag==1)
		{
			objInteract.InUse=true;
		}
		
		
		
		if (isMoveable==1)
		{
			objInteract.CanBePickedUp=true;
			Rigidbody rgd = parentObj.AddComponent<Rigidbody>();
			rgd.angularDrag=0.0f;
			WindowDetectUW.FreezeMovement(myObj);
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
			Debug.Log (myObj.name + " is enchanted. Take a look at it please.");
		}
		return objInteract;
	}

	public int AliasItemId()
	{
		return this.GetComponent<object_base>().AliasItemId();
	}

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

	public bool IsStackable()
	{//An object is stackable if it has the isQuant flag and is not enchanted.
		return ((isQuant) && (!isEnchanted));
	}

	public static bool CanMerge(ObjectInteraction mergingInto, ObjectInteraction mergingFrom)
	{
		//if ((objInt.item_id==ObjectUsedOn.GetComponent<ObjectInteraction>().item_id) && (objInt.Quality==ObjectUsedOn.GetComponent<ObjectInteraction>().Quality))
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


	public static void Merge(ObjectInteraction mergingInto, ObjectInteraction mergingFrom)
	{
		//ObjectUsedOn.GetComponent<ObjectInteraction>().Link=ObjectUsedOn.GetComponent<ObjectInteraction>().Link+objInt.Link;
		mergingInto.Link += mergingFrom.Link;
		mergingInto.GetComponent<object_base>().MergeEvent();
		Destroy(mergingFrom.gameObject);
	}

	public static void Split(ObjectInteraction splitFrom, ObjectInteraction splitTo)
	{
		splitFrom.GetComponent<object_base>().Split ();
		splitTo.GetComponent<object_base>().Split();
	}

	public static void Split(ObjectInteraction splitFrom)
	{
		splitFrom.GetComponent<object_base>().Split ();
	}

	/*
	void OnCollisionEnter(Collision info) {
		
		if(info.relativeVelocity.magnitude > 3.0f)
		{ 
			Debug.Log ("bounce");
		}
		
	}
*/

		public ObjectInteraction CopyGameObjectInteraction(GameObject target)
		{
				//Copies a uw gameobject and it's properties
				//copy this object interaction.
				ObjectInteraction objIntNew = target.AddComponent<ObjectInteraction>();
				//objIntNew.InventoryDisplay=InventoryDisplay;
				//objIntNew.EquipDisplay=EquipDisplay;
				//objIntNew.WorldDisplay=WorldDisplay;
				objIntNew.EquipString=EquipString;
				objIntNew.WorldDisplayIndex=WorldDisplayIndex;
				objIntNew.InvDisplayIndex=InvDisplayIndex;
				objIntNew.ignoreSprite=ignoreSprite;//For button handlers that do their own sprite work.
				objIntNew.item_id=item_id;
				objIntNew.flags=flags;
				objIntNew.InUse=InUse;
				//objIntNew.InvMarker=InvMarker;//=GameObject.Find ("InventoryMarker");
				//objIntNew.playerUW=playerUW;
				objIntNew.CanBePickedUp=CanBePickedUp;
				objIntNew.CanBeUsed=CanBeUsed;//unimplemented
				//public bool CanBeMoved;//unimplemented
				objIntNew.PickedUp=PickedUp; //Test if object is in the inventory or in the open world in case there is different behaviours needed
				objIntNew.audSource=audSource;
				objIntNew.inventorySlot=inventorySlot;
				objIntNew.ItemType=ItemType; //UWexporter item type id
				//UW specific info.
				objIntNew.Owner=Owner;	//Used for keys
				objIntNew.Link=Link;	//Also quantity
				objIntNew.Quality=Quality;
				objIntNew.isQuant=isQuant;
				objIntNew.isEnchanted=isEnchanted;
				//Display controls
				//objIntNew.tc=tc;
				objIntNew.sr =sr;
				objIntNew.isAnimated=isAnimated;
				//objIntNew.animationStarted=animationStarted;

				if (objIntNew.CanBePickedUp==true)
				{
						Rigidbody rgd = target.AddComponent<Rigidbody>();
						rgd.angularDrag=0.0f;
						WindowDetectUW.FreezeMovement(target);
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

		public virtual bool ChangeType(int newID, int newType)
		{//Changes the type of the object. Eg when destroyed and it needs to become debris.
				item_id=newID;
				ItemType=newType;
				WorldDisplayIndex=newID;
				InvDisplayIndex=newID;
				Destroy(this.gameObject.GetComponent<object_base>());
				UpdateAnimation();
				return true;		
		}


		public static void CreateNPC(GameObject myObj, string NPC_ID, string EditorSprite ,int npc_whoami)
		{
			myObj.layer=LayerMask.NameToLayer("NPCs");
			myObj.tag="NPCs";
			GameObject myInstance = Resources.Load("AI_PREFABS/AI_LAND") as GameObject;
			GameObject newObj = (GameObject)GameObject.Instantiate(myInstance);
			newObj.name = myObj.name + "_AI";
			newObj.transform.position=Vector3.zero; //new Vector3(0,0,0);
			newObj.transform.parent=myObj.transform;
			newObj.transform.localPosition=Vector3.zero; //new Vector3(0,0,0);
			AIRig ai = newObj.GetComponent<AIRig>();
			ai.AI.Body=myObj;

			NPC npc = myObj.AddComponent<NPC>();
			npc.NPC_ID=NPC_ID;
			if (npc_whoami == 0)
			{
					npc.npc_whoami=256+(int.Parse (NPC_ID) -64);
			}

			//Probably only need to add this when an NPC supports ranged attacks?
			GameObject NpcLauncher = new GameObject("NPC_Launcher");
			NpcLauncher.transform.position=Vector3.zero; 
			NpcLauncher.transform.parent=myObj.transform;
			NpcLauncher.transform.localPosition=new Vector3(0.0f,0.5f,0.1f);
			npc.NPC_Launcher=NpcLauncher;

			myInstance = Resources.Load("animation/AI_Base_Animator") as GameObject;
			newObj = (GameObject)GameObject.Instantiate(myInstance);
			newObj.name=myObj.name + "_Sprite";
			newObj.transform.parent=myObj.transform;
			newObj.transform.position = myObj.transform.position;

			SpriteRenderer mysprite =  newObj.GetComponent<SpriteRenderer>();
			Sprite image = Resources.Load <Sprite> (EditorSprite);//Loads the sprite.

			mysprite.material= Resources.Load<Material>("Materials/SpriteShader");
			mysprite.sprite = image;//Assigns the sprite to the object.

			CharacterController cap  = myObj.GetComponent<CharacterController>();
			if (cap==null)
			{
				cap=myObj.GetComponent<CharacterController>();
			}
			
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
					cap.height=0.8f;
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
					cap.center = new Vector3(0.0f, 0.5f, 0.0f);
					cap.radius=0.5f;
					cap.height=0.5f;
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

						Conversation cnv ;//= myObj.AddComponent<Conversation>();
						cnv=null;
						//TODO:Make sure all conversations are added here as implemented.
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
								Debug.Log ("Conversation "  + myObj.GetComponent<NPC>().npc_whoami + " is not implemented for " + myObj.name );
								break;
						}			
						if (cnv!=null)
						{
								cnv.npc= npc;
						}					
				}
		}


}