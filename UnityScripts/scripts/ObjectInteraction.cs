using UnityEngine;
using System.Collections;

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

	public static UILabel MessageLog;

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


	public int ItemType; //UWexporter item type id

	//UW specific info.
	public int Owner;	//Used for keys
	public int Link;	//Also quantity
	public int Quality;
	public bool isQuant;
	public bool isEnchanted;

	//Display controls
	public static TextureController tc;
	private SpriteRenderer sr =null;
	public bool isAnimated;
	private bool animationStarted;
	// Use this for initialization

	void Start () {
		if (MessageLog==null)
		{
			MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
		}

		if (InvMarker==null)
		{
			InvMarker=GameObject.Find ("InventoryMarker");
		}
		sr= this.gameObject.GetComponentInChildren<SpriteRenderer>();
	}

	void Update()
	{
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

	public UILabel getMessageLog()
	{
		return playerUW.GetMessageLog();//MessageLog;
	}

	public bool Attack(int damage)
	{
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
		}
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
		int ItemID1 = this.GetComponent<ObjectInteraction>().item_id;
		int ItemID2 = InputObject2.GetComponent<ObjectInteraction>().item_id;
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
					if((lstInput1[i] == ItemID1) && (lstDestroy1[i]==1) )
						{
						Debug.Log("Destroying " + InputObject1.name);
						}
					if((lstInput1[i] == ItemID2) && (lstDestroy1[i]==1) )
						{
						Debug.Log("Destroying " + InputObject2.name);
						}
					if((lstInput2[i] == ItemID1) && (lstDestroy2[i]==1) )
						{
						Debug.Log("Destroying " + InputObject1.name);
						}
					if((lstInput2[i] == ItemID2) && (lstDestroy2[i]==1) )
						{
						Debug.Log("Destroying " + InputObject2.name);
						}
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
	}
}
