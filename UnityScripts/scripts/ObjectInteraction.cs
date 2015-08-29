using UnityEngine;
using System.Collections;

public class ObjectInteraction : MonoBehaviour {
	private UILabel MessageLog;
	public Sprite InventoryIcon;
	public string InventoryString;
	public Sprite InventoryIconEquip;
	public string InventoryIconEquipString;

	public int item_id;

	public static GameObject player;
	public static GameObject InvMarker;//=GameObject.Find ("InventoryMarker");
	public static StringController SC;	//String controller reference

	private UWCharacter playerUW;
	private PlayerInventory pInv;
	public bool CanBePickedUp;	//unimplemented
	public bool CanBeUsed;//unimplemented
	public bool CanBeMoved;//unimplemented

	public bool PickedUp; //Test if object is in the inventory or in the open world in case there is different behaviours needed


	//TODO: remove these!
	public bool isContainer;
	public bool isRuneBag;
	public bool isRuneStone;
	public bool isMap;
	public bool isDoor;
	public bool isKey;

	public int ItemType; //UWexporter item type id

	//UW specific info.
	public int Owner;	//Used for keys
	public int Link;
	public int Quality;

	// Use this for initialization

	void Start () {
		MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
		if (player!=null)
		{
			playerUW=player.GetComponent<UWCharacter>();
			pInv=player.GetComponent<PlayerInventory>();
		}

		if (InvMarker==null)
		{
			InvMarker=GameObject.Find ("InventoryMarker");
		}
	}

	public UWCharacter getPlayerUW()
		{//Quickly get the player character for other components.
		return playerUW;
		}

	public StringController getStringController()
	{//Quickly get the string controller for other components.
		return SC;
	}

	public Container getCurrentContainer()
	{
		Container cn = GameObject.Find (pInv.currentContainer).GetComponent<Container>();
		return cn;
	}

	public PlayerInventory getPlayerInventory()
		{
		return pInv;
		}

	public UILabel getMessageLog()
	{
		return MessageLog;
	}

	public bool LookDescription()
	{//Returns the description of this object.
		Debug.Log ("LookDescription");
		switch (ItemType)
		{
		case 0://	NPC 0
			//nothing to do
		case 1://	WEAPON 1
			//repair with hammer
		case 2://	ARMOUR 2
			//repair with hammer
		case 3://	AMMO 3
			//nothing
			break;
		case 4://	DOOR 4
		case 5://	KEY 5
			//nothing/use
		case 6://	RUNE 6
			//nothing
		case 7://	BRIDGE 7
			//nothing
		case 8://	BUTTON 8	
			//nothing
		case 9://	LIGHT 9
			//?
			{
			MessageLog.text = SC.GetString("004",item_id.ToString ("000"));
			return false;
			break;
			}

		case 10://	SIGN 10
		case 11://	BOOK 11
		case 13://	SCROLL 13	//The reading kind
		{
			Readable rd =this.gameObject.GetComponent<Readable>();
			rd.Activate();
			return true;
			break;
		}
		case 12://	WAND 12	
			//Nothing/use

		case 14://	POTIONS 14	
			//Nothing/use
		case 15://INSERTABLE 15	//Shock style put the circuit board in the slot.
			//?
		case 16://	INVENTORY 16	//Quest items and the like with no special properties
			//Nothing
		case 17:// ACTIVATOR 17	//Crystal balls,magic fountains and surgery machines that have special custom effects when you activate them
			//Nothing
		case 18://TREASURE 18
			//Nothing
			break;
		case 19:// CONTAINER 19
		case 20:// TRAP 20	//not implemented
		case 21://LOCK 21
			//Nothing
		case 22://TORCH 22
			//Nothing. torch effects handled by objcmb /use
		case 23://CLUTTER 23
			//Nothing
			break;
		case 24://FOOD 24
			{
			Food fd = this.GetComponent<Food>();
			fd.LookAt();
			break;
			}
			//Nothing/use
		case 25://SCENERY 25
			//Nothing
		case 26://INSTRUMENT 26
			//Nothing/use
		case 27://FIRE 27
			//Nothing
		case 28:// MAP 28
			//Nothing//use
		case 29://HIDDENDOOR 29
			//?
		case 30://PORTCULLIS 30
			//?
		case 31://PILLAR 31
			//nothing
		case 32://SOUND 32
			//nothing
		case 33://CORPSE 33
			//Nothing
		case 34://TMAP_SOLID 34
		case 35://TMAP_CLIP 35
		case 36://MAGICSCROLL 36
		case 37: //A_DAMAGE_TRAP 37
		case 38://A_TELEPORT_TRAP 38
		case 39://A_ARROW_TRAP 39
		case 40://A_DO_TRAP 40
		case 41://A_PIT_TRAP 41
		case 42://A_CHANGE_TERRAIN_TRAP 42
		case 43://A_SPELLTRAP 43
		case 44://A_CREATE_OBJECT_TRAP 44
		case 45://A_DOOR_TRAP 45
		case 46://A_WARD_TRAP 46
		case 47://A_TELL_TRAP  47
		case 48://A_DELETE_OBJECT_TRAP 48
		case 49://AN_INVENTORY_TRAP 49
		case 50://A_SET_VARIABLE_TRAP 50
		case 51://A_CHECK_VARIABLE_TRAP 51
		case 52://A_COMBINATION_TRAP 52
		case 53://A_TEXT_STRING_TRAP 53
		case 54://A_MOVE_TRIGGER 54
		case 55:// A_PICK_UP_TRIGGER 55
		case 56://A_USE_TRIGGER 56
		case 57://A_LOOK_TRIGGER 57
		case 58://A_STEP_ON_TRIGGER 58
		case 59://AN_OPEN_TRIGGER 59
		case 60://AN_UNLOCK_TRIGGER 60
		case 61://A_FOUNTAIN	61
		case 62://SHOCK_DECAL 62
		case 63://COMPUTER_SCREEN 63
		case 64://SHOCK_WORDS 64
		case 65://SHOCK_GRATING 65 
		case 66://SHOCK_DOOR 66
		case 67://SHOCK_DOOR_TRANSPARENT 67
		case 68://UW_PAINTING	68
		case 69://PARTICLE 69
		case 70://RUNEBAG 70
		case 71://SHOCK_BRIDGE 71
		case 72://FORCE_DOOR 72
		case 73://HIDDENPLACEHOLDER 999
			{
			MessageLog.text =  SC.GetString("004",item_id.ToString ("000"));
			return false;
			}
			break;
		}






		return false;//SC.GetString("004",item_id.ToString ("000"));


	}

/*	public string LookDescription(ObjectInteraction objInt)
	{//Executes the description of this object.
		//Debug.Log ("LookDescription (objint)");

		return "";//false;

		switch (objInt.ItemType)
		{
		case 10://signs
			{
				return objInt.MessageLog.text = SC.GetString (8,objInt.Link - 0x200);
				break;
			}
		default:
			{
				return SC.GetString("004",item_id.ToString ("000"));
			}
		}
	}
*/
	public bool Activate()
	{//Code to activate specific objects
		//Returns a reference to the object in hand at the end of the action.
		//Get a reference to the object currently in hand
		//list each object type in the game.
		//depending on the combination of object in hand/object activate perform all my various actions.
		//Debug.Log ("ObjectInteraction.Activate (" + ItemType + ")");
		GameObject ObjectInHand =null;// = new GameObject();
		ObjectInteraction objInt = this.GetComponent<ObjectInteraction>();
		if (player!=null)
		{
			playerUW=player.GetComponent<UWCharacter>();
			pInv=player.GetComponent<PlayerInventory>();
		}

		if (this.pInv.ObjectInHand !="")
		{
			ObjectInHand =GameObject.Find (this.pInv.ObjectInHand);
			//First do a combineobject test. This will implement object combinatiosn defined by UW1/2
		    if (CombineObject(this.gameObject,ObjectInHand))
			{
				return true;
			}
	
		}

		switch (ItemType)
		{
			case 0://	NPC 0
				//nothing to do
			case 1://	WEAPON 1
				//repair with hammer
			case 2://	ARMOUR 2
				//repair with hammer
			case 3://	AMMO 3
				//nothing
			break;
			case 4://	DOOR 4
					{
						DoorControl objDoor = this.GetComponent<DoorControl>();
						if (objDoor!=null) //This is a door with a control
						{
						if (this.pInv.ObjectInHand !="")
								{
								objDoor.ActivateByObject(ObjectInHand);
								//Clear the object in hand
								playerUW.CursorIcon= playerUW.CursorIconDefault;
								playerUW.CurrObjectSprite = "";
								pInv.ObjectInHand="";
								return true;	
								}
							else
								{//Normal Usage
								objDoor.Activate();
								return true;
								}
						}
						break;
					}
			case 5://	KEY 5
				{//A key just becomes the object in hand
					return false;
				}
				//nothing/use
			case 6://	RUNE 6
				//nothing
			case 7://	BRIDGE 7
				//nothing
			case 8://	BUTTON 8	
				//nothing
				{
					ButtonHandler objButton = this.gameObject.GetComponent<ButtonHandler>();
					if (objButton!=null)
					{
						objButton.Activate();
						return true;
					}
				break;
				}
			case 9://	LIGHT 9
				//?
			break;
			case 12://	WAND 12	
				//Nothing/use
				case 10://	SIGN 10
				case 11://	BOOK 11
				case 13://	SCROLL 13	//The reading kind
				{
					Readable rd =this.gameObject.GetComponent<Readable>();
					rd.Activate();
					return true;
					break;
				}
			case 14://	POTIONS 14	
				//Nothing/use
			case 15://INSERTABLE 15	//Shock style put the circuit board in the slot.
				//?
			case 16://	INVENTORY 16	//Quest items and the like with no special properties
				//Nothing
			case 17:// ACTIVATOR 17	//Crystal balls,magic fountains and surgery machines that have special custom effects when you activate them
				//Nothing
			case 18://TREASURE 18
				//Nothing
				break;
			case 19:// CONTAINER 19
				{
				//TODO:add object to container or open container.
				Container cn = this.gameObject.GetComponent<Container>();
				if (pInv.ObjectInHand=="")
					{//Open the container
					cn.OpenContainer();
					return true;
					}
				else
					{//Put the item in the container.
					bool Valid=true;
					if (ObjectInHand.GetComponent<Container>() != null)
						{
						if (cn.name == ObjectInHand.GetComponent<Container>().name)
							{
							Valid=false;
							Debug.Log ("Attempt to add a container to itself");
							}
						}

				if (Valid)
					{
					cn.AddItemToContainer(pInv.ObjectInHand);
					if (cn.isOpenOnPanel == true)
					{//Container is open for display force a refresh.
						cn.OpenContainer();
						//for (int i = 11; i<18;i++)
						//	{
						//	pInv.bBackPack[i-11]=true;
						//	}
					}
					pInv.ObjectInHand= "";
					playerUW.CursorIcon= playerUW.CursorIconDefault;
					playerUW.CurrObjectSprite = "";
					
					return true;
					}
				else
					{
					return false;
					}

					}
				break;
				}
			case 20:// TRAP 20	//not implemented
			case 21://LOCK 21
				//Nothing
			case 22://TORCH 22
			//Nothing. torch effects handled by objcmb /use
			case 23://CLUTTER 23
				//Nothing
				break;
			case 24://FOOD 24
				{
				if (pInv.ObjectInHand=="")
					{
					Food fd = this.gameObject.GetComponent<Food>();
					fd.Activate();
					return true;
					}
				else
					{
					return false;
					}
				break;
				}
				//Nothing/use
			case 25://SCENERY 25
				//Nothing
			case 26://INSTRUMENT 26
			//Nothing/use
			case 27://FIRE 27
				//Nothing
			case 28:// MAP 28
				//Nothing//use
			case 29://HIDDENDOOR 29
				//?
			case 30://PORTCULLIS 30
				//?
			case 31://PILLAR 31
				//nothing
			case 32://SOUND 32
				//nothing
			case 33://CORPSE 33
				//Nothing
			case 34://TMAP_SOLID 34
			case 35://TMAP_CLIP 35
			case 36://MAGICSCROLL 36
			case 37: //A_DAMAGE_TRAP 37
			case 38://A_TELEPORT_TRAP 38
			case 39://A_ARROW_TRAP 39
			case 40://A_DO_TRAP 40
			case 41://A_PIT_TRAP 41
			case 42://A_CHANGE_TERRAIN_TRAP 42
			case 43://A_SPELLTRAP 43
			case 44://A_CREATE_OBJECT_TRAP 44
			case 45://A_DOOR_TRAP 45
			case 46://A_WARD_TRAP 46
			case 47://A_TELL_TRAP  47
			case 48://A_DELETE_OBJECT_TRAP 48
			case 49://AN_INVENTORY_TRAP 49
			case 50://A_SET_VARIABLE_TRAP 50
			case 51://A_CHECK_VARIABLE_TRAP 51
			case 52://A_COMBINATION_TRAP 52
			case 53://A_TEXT_STRING_TRAP 53
			case 54://A_MOVE_TRIGGER 54
			case 55:// A_PICK_UP_TRIGGER 55
			case 56://A_USE_TRIGGER 56
			case 57://A_LOOK_TRIGGER 57
			case 58://A_STEP_ON_TRIGGER 58
			case 59://AN_OPEN_TRIGGER 59
			case 60://AN_UNLOCK_TRIGGER 60
			case 61://A_FOUNTAIN	61
			case 62://SHOCK_DECAL 62
			case 63://COMPUTER_SCREEN 63
			case 64://SHOCK_WORDS 64
			case 65://SHOCK_GRATING 65 
			case 66://SHOCK_DOOR 66
			case 67://SHOCK_DOOR_TRANSPARENT 67
			case 68://UW_PAINTING	68
			case 69://PARTICLE 69
				break;
			case 70://RUNEBAG 70
				{
				if (ObjectInHand != null)
					{
					//Try and see if I can add the object to the rune bag.
					return this.GetComponent<RuneBag>().ActivateByObject(ObjectInHand);
					}
				else
					{
					//open the rune bag if nothing in hand
					this.GetComponent<RuneBag>().Activate();
					return true;
					}

				break;
				}
				
		case 71://SHOCK_BRIDGE 71
			case 72://FORCE_DOOR 72
			case 73://HIDDENPLACEHOLDER 999
			break;
		}

		//If I haven't returned just swap the two objects if one of them is in the inventory.

		return false;
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

		for (int i =0; i < lstInput1.GetUpperBound(0)-1;i++)
		{
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
//default:
//			{
//				objInt.MessageLog.text = "Default: Type=" + objInt.ItemType + ", You use a " + objInt.gameObject.name;
//				break;
//			}
//		}
//	}
/*
	// Update is called once per frame
	void Update () {
		return;
		if ((player!=null) && (playerUW==null))
			{
			playerUW=player.GetComponent<UWCharacter>();
			}
		if ((player!=null) && (pInv==null))
		{
			pInv=player.GetComponent<PlayerInventory>();
		}
		if (InvMarker==null)
			{
			InvMarker=GameObject.Find ("InventoryMarker");
			}
	}

	void OnMouseDown()
	{
		return;
		float distance;
		if (playerUW.CursorInMainWindow==false)
		{//Stop items outside the viewport from being triggered.
			return;
		}


		switch (UWCharacter.InteractionMode)
		{
		case 0://Options
			MessageLog.text = "Nothing will happen in options mode " + name;
			break;
		case 1://Talk
			MessageLog.text = "You can't talk to " + name;
			break;
		case 2://Pickup
			if (playerUW==null)
			{
				player.GetComponent<UWCharacter>();
			}

			if (pInv.ObjectInHand=="")
			{
				//distance =Vector3.Distance(transform.position,player.transform.position);
				//if (distance<=playerUW.InteractionDistance)
				//{
					MessageLog.text = "You pick up a " + name;
					//Cursor.SetCursor (InventoryIcon.texture,Vector2.zero, CursorMode.ForceSoftware);
					playerUW.CursorIcon= InventoryIcon.texture;
					playerUW.CurrObjectSprite = InventoryString;
					pInv.ObjectInHand=name;
					pInv.JustPickedup=true;//To stop me throwing it away immediately.
					//Move the selected gameobject to the box.
					this.transform.position = InvMarker.transform.position;
					this.transform.parent=InvMarker.transform;//Adds to the marker so it will persist.

				//}
				//else
				//{
				//	MessageLog.text = "That is too far away to take";
				//}
			}

			break;
		case 4://Look
			MessageLog.text = "You see a " + name;
			break;
		case 8://Attack
			MessageLog.text = "You attack a " + name;
			break;
		case 16://Use
			//distance =Vector3.Distance(transform.position,player.transform.position);
			//if (distance<=playerUW.InteractionDistance)
			//{
			MessageLog.text = "You use a " + name + "ObjectInteraction.OnMouseDown";
			//}
			//else
			//{
			//	MessageLog.text = "That is too far away to use";
			//}
			break;
		}
	}
	*/

	public void consumeObject()
	{
		Container cn = getCurrentContainer();
		//Code for objects that get destroyed when they are used. Eg food, potion, fuel etc
		if (!cn.RemoveItemFromContainer(this.name))
		{//Try and remove from the paperdoll if not found in the current container.
			pInv.RemoveItemFromEquipment(this.name);
		}
		pInv.Refresh();
		Destroy (this.gameObject);
	}
}
