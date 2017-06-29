using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Container : object_base {

	public string[] items=new string[40];

	/// <summary>
	/// The capacity of the container
	/// </summary>
	public int Capacity;

	/// <summary>
	/// What objects the container accepts
	/// </summary>
	public int ObjectsAccepted;//TODO:Make this work off of common obj

	/// <summary>
	/// Is the container open on the players inventory.
	/// </summary>
	public bool isOpenOnPanel;//

	/// <summary>
	/// What container is above this one. For passing objects out of the container in the inventory
	/// </summary>
	public string ContainerParent; 

	/// <summary>
	/// Gets the max capacity of the container.
	/// </summary>
	/// <returns>The capacity.</returns>
	public int MaxCapacity()
	{
		return items.GetUpperBound (0);
	}

	/// <summary>
	/// Gets the item name at index.
	/// </summary>
	/// <returns>The <see cref="System.String"/>.</returns>
	/// <param name="index">Index.</param>
	public string GetItemAt(int index)
	{
		if ((index >=0) && (index<=MaxCapacity()))
		{
			return items[index];
		}
		else
		{
			return "";
		}
	}

	/// <summary>
	/// Gets the game object at index.
	/// </summary>
	/// <returns>The <see cref="UnityEngine.GameObject"/>.</returns>
	/// <param name="index">Index.</param>
	public GameObject GetGameObjectAt(int index)
	{
		if (GetItemAt(index)!="")
		{
			return GameObject.Find (GetItemAt (index));
		}
		else
		{
			return null;
		}
	}

	public bool AddItemMergedItemToContainer(GameObject item)
	{
		for (int i=0; i<=MaxCapacity (); i++)
		{
			if (items[i]!="")
			{
				GameObject founditem = GameObject.Find (items[i]);
				if (ObjectInteraction.CanMerge(founditem.GetComponent<ObjectInteraction>(),item.GetComponent<ObjectInteraction>()))
				{
					ObjectInteraction.Merge(founditem.GetComponent<ObjectInteraction>(),item.GetComponent<ObjectInteraction>());
					return true;
				}
			}
		}
		//otherwise just add in the usual way.
		return AddItemToContainer(item.name);
	}


	public bool AddItemToContainer(string item)
	{
		int i =0;
		while (((items[i] != null) && (items[i] !="")) && (i <=MaxCapacity()))
			{
				i++;
			}
		if (i<=MaxCapacity())
			{
				return AddItemToContainer(item,i);
			}
		else
			{
				//no room
				Debug.Log (name + " is full");
				return false;
			}
	}

	public bool AddItemToContainer(string item,int index)
	{
		if (item =="")
		{
			return false;
		}
		if (index<=MaxCapacity())
		{
			items[index]=item;
			return true;
		}
		else
		{
			return false;
		}
	}

	public bool RemoveItemFromContainer(int index)
		{
		if (items[index] != "")
			{
			items[index]="";
			return true;
			}
		else
			{
			return false;
			}
		}

	public bool RemoveItemFromContainer(string objectName)
	{
		for (int i =0; i<=MaxCapacity ();i++)
			{
			if (items[i] == objectName)
				{
				RemoveItemFromContainer(i);
				return true;
				}
			}
		return false;
	}

	public static bool RemoveItemFromSubContainers(Container cn, string objectName)
	{
		for (int i =0; i<=cn.MaxCapacity ();i++)
		{
			if (cn.items[i] == objectName)
			{
				cn.RemoveItemFromContainer(i);
				return true;
			}
			else
			{
				if (cn.items[i] !="")
				{
					GameObject obj = GameObject.Find (cn.items[i]);
					if (obj!=null)
					{
						if (obj.GetComponent<Container>()!=null)
						{
							return RemoveItemFromSubContainers(obj.GetComponent<Container>(),objectName);
						}
					}
				}
			}
		}
		return false;
	}

	public void OpenContainer()
	{
		GameWorldController.instance.playerUW.playerInventory.ContainerOffset=0;
		ScrollButtonStatsDisplay.ScrollValue=0;
		ObjectInteraction currObjInt = this.gameObject.GetComponent<ObjectInteraction>();
		if (currObjInt.PickedUp==false)
			{//The requested container is open in the game world. This can cause problems!
			SpillContents();
			return;
			}
		//Sort the container
		Container.SortContainer(this);
		UWHUD.instance.ContainerOpened.GetComponent<RawImage>().texture=currObjInt.GetEquipDisplay().texture;
		if (this.isOpenOnPanel==false)
		{
			this.isOpenOnPanel=true;
			ContainerParent=GameWorldController.instance.playerUW.playerInventory.currentContainer;
		}
		GameWorldController.instance.playerUW.playerInventory.currentContainer=this.name;
		if (GameWorldController.instance.playerUW.playerInventory.currentContainer=="")
		{
			GameWorldController.instance.playerUW.playerInventory.currentContainer=GameWorldController.instance.playerUW.name;
			this.ContainerParent=GameWorldController.instance.playerUW.name;
		}
		for (int i = 0; i<8; i++)
		{
			string sItem = this.GetItemAt(i);
			GameWorldController.instance.playerUW.playerInventory.SetObjectAtSlot(i+11,sItem);
		}
		UWHUD.instance.ContainerOpened.GetComponent<ContainerOpened>().BackpackBg.SetActive(true);
		if (CountItems()>=8)
		{
			UWHUD.instance.ContainerOpened.GetComponent<ContainerOpened>().InvUp.SetActive(true);
			UWHUD.instance.ContainerOpened.GetComponent<ContainerOpened>().InvDown.SetActive(true);
		}
		else
		{	
			UWHUD.instance.ContainerOpened.GetComponent<ContainerOpened>().InvUp.SetActive(false);
			UWHUD.instance.ContainerOpened.GetComponent<ContainerOpened>().InvDown.SetActive(false);						
		}
	}

	public void SpillContents()
	{//Removes the contents of a container out in the real world.
		int counter;
		TileMap tm =GameWorldController.instance.currentTileMap(); //GameObject.Find("Tilemap").GetComponent<TileMap>();
		GameWorldController.FreezeMovement(this.gameObject);
		ObjectInteraction objInt = this.gameObject.GetComponent<ObjectInteraction>();
		objInt.SetWorldDisplay(objInt.GetEquipDisplay());
		for (int i=0; i<=MaxCapacity ();i++)
		{
			GameObject Spilled = GetGameObjectAt(i);//GameObject.Find (GetItemAt (i));
			if (Spilled!=null)
			{	
				if(Spilled.GetComponent<trigger_base>()!=null)
				{
					Spilled.GetComponent<trigger_base>().Activate();		
				}
				bool flag=false;
				Vector3 randomPoint=this.transform.position;
				counter=0;
				while ((flag==false) && (counter<25))
				{
					randomPoint = this.transform.position+Random.insideUnitSphere;
					if(randomPoint.y<this.transform.position.y)
					{
						randomPoint.y=this.transform.position.y+0.1f;
					}
					flag = ((!Physics.CheckSphere(randomPoint,0.5f)) && (tm.ValidTile(randomPoint)));
					counter++;
				}
				if (flag==true)
				{//No object interferes with the spill
					RemoveItemFromContainer(i);
					Spilled.transform.position=randomPoint;
					Spilled.GetComponent<ObjectInteraction>().PickedUp=false;
					GameWorldController.UnFreezeMovement(Spilled);
				}
				else
				{//No where to put the item. Put it at the containers position.
					RemoveItemFromContainer(i);
					Spilled.transform.position=this.transform.position;
					Spilled.GetComponent<ObjectInteraction>().PickedUp=false;
					GameWorldController.UnFreezeMovement(Spilled);
				}
			}
		}
		GameWorldController.UnFreezeMovement(this.gameObject);
	}


	public static void SetPickedUpFlag(Container cn, bool NewValue)
	{//Recursivly sets the picked up flag on all items in the container and all sub-container contents.
		for (int i =0; i<=cn.MaxCapacity();i++)
		{
			GameObject item =cn.GetGameObjectAt(i); // GameObject.Find (cn.GetItemAt(i));
			if (item !=null)
			{
				if (item.GetComponent<ObjectInteraction>()!=null)
				{
					item.GetComponent<ObjectInteraction>().PickedUp=NewValue;
					if (item.GetComponent<ObjectInteraction>().GetItemType()==ObjectInteraction.A_PICK_UP_TRIGGER)
					{//Special case
						item.GetComponent<a_pick_up_trigger>().Activate();
						cn.RemoveItemFromContainer(i);
					}
					else if (item.GetComponent<Container>()!=null)
					{
						Container.SetPickedUpFlag(item.GetComponent<Container>(),NewValue);
					}
				}
			}
		}
	}

	public static void SetItemsPosition(Container cn, Vector3 Position)
	{
		for (int i =0; i<=cn.MaxCapacity();i++)
		{
			string ItemName=cn.GetItemAt(i);
			if (ItemName != "")
			{
				GameObject item = cn.GetGameObjectAt(i);//GameObject.Find (cn.GetItemAt(i));
				if (item!=null)
				{
					item.transform.position=Position;
					if (item.GetComponent<Container>()!=null)
					{
						Container.SetItemsPosition(item.GetComponent<Container>(),Position);
					}
				}
			}
		}
	}

	public static void SetItemsParent(Container cn, Transform Parent)
	{
		for (int i =0; i<=cn.MaxCapacity ();i++)
		{
			string ItemName=cn.GetItemAt(i);
			if (ItemName != "")
			{
				GameObject item = cn.GetGameObjectAt(i); //GameObject.Find (cn.GetItemAt(i));
				if (item != null)
				{
					item.transform.parent=Parent;
					if (Parent == GameWorldController.instance.LevelMarker())
					{
						GameWorldController.MoveToWorld(item);
					}
					else
					{
						GameWorldController.MoveToInventory(item);
					}
					if (item.GetComponent<Container>()!=null)
					{
						Container.SetItemsParent(item.GetComponent<Container>(),Parent);
					}
				}
			}
		}
	}

	public static int GetFreeSlot(Container cn)
	{//Returns an available slot on the current container.
		for (int i=0;i<=cn.MaxCapacity();i++)
		{
			if (cn.GetItemAt (i)=="")
			{
				return i;
			}
		}
		return -1;
	}


	public static void SortContainer(Container cn)
	{
		//Debug.Log ("Sorting container");
		//Flattens the contents of a container so that they occupy the first slots 
		int currFreeSlot=-1;
		string ItemName;
		bool GetNextSlot=true;
		for (int i=0;i<=cn.MaxCapacity();i++)
		{
			//Find the first free slot
			if (GetNextSlot==true)
			{
				for (int j=0;j<=cn.MaxCapacity();j++)
				{
					ItemName=cn.GetItemAt(j);
					if (ItemName=="")
					{
						currFreeSlot=j;
						GetNextSlot=false;
						break;
					}
				}
			}
			if ((i>currFreeSlot) &&(currFreeSlot!=-1))
			{
				ItemName=cn.GetItemAt(i);
				if (ItemName!="")
				{//Move this item to the free slot
					cn.RemoveItemFromContainer(i);
					cn.AddItemToContainer(ItemName,currFreeSlot);
					GetNextSlot=true;
					currFreeSlot=-1;
				}
			}
		}
	}


	public override bool use ()
	{
		GameObject ObjectInHand=GameWorldController.instance.playerUW.playerInventory.GetGameObjectInHand();
		//TODO:add object to container or open container.
		//Container cn = this.gameObject.GetComponent<Container>();
		if (ObjectInHand == null)
		{//Open the container
			OpenContainer();
			return true;
		}
		else
		{//Put the item in the container.
			bool Valid=true;
			if (ObjectInHand.GetComponent<Container>() != null)
			{
				if (this.gameObject.name == ObjectInHand.GetComponent<Container>().name)
				{
					Valid=false;
					Debug.Log ("Attempt to add a container to itself");
				}
			}

			if (Container.TestContainerRules(this,11,false)==false)
			{
				Valid=false;
				return true;
			}

			if (Valid)
			{
				if ((ObjectInHand.GetComponent<ObjectInteraction>().isQuant()==false) || (ObjectInHand.GetComponent<ObjectInteraction>().isEnchanted()))
				{
					AddItemToContainer(GameWorldController.instance.playerUW.playerInventory.ObjectInHand);
				}
				else
				{
					AddItemMergedItemToContainer(ObjectInHand.gameObject);
				}
				//If the item is already in the current player container then remove it's reference
				//if(GameWorldController.instance.playerUW.playerInventory.GetCurrentContainer())
				//	{}

				if (isOpenOnPanel == true)
				{//Container is open for display force a refresh.
					OpenContainer();
				}
				else
				{
					//Remove to prevent item duplication
					removeFromContainer(GameWorldController.instance.playerUW.playerInventory.GetCurrentContainer(),GameWorldController.instance.playerUW.playerInventory.ObjectInHand);
				}
				GameWorldController.instance.playerUW.playerInventory.ObjectInHand= "";
				UWHUD.instance.CursorIcon= UWHUD.instance.CursorIconDefault;

				return true;
			}
			else
			{
				return false;
			}
		}
	}

	public override float GetWeight ()
	{//Get the weight of all items in the container
		float answer=base.GetWeight();//The container has it's own weight as well.
		for (int i=0; i<=MaxCapacity();i++)
		{
			if (GetItemAt(i)!="")
			{
				GameObject ItemAt = GetGameObjectAt(i); //GameObject.Find (GetItemAt(i));
				if (ItemAt!=null)
				{
					ObjectInteraction objContainerItem = ItemAt.GetComponent<ObjectInteraction>();
					if (objContainerItem!=null)
					{
						answer+=objContainerItem.GetWeight();							
					}						
				}
			}
		}
		return answer;
	}

	public float GetBaseWeight()
	{//What weight is the container itself.
		return base.GetWeight();
	}

	public float GetCapacity()
	{
		return (float)(Capacity);
	}

	public float GetFreeCapacity()
	{
		if (this.gameObject.name==GameWorldController.instance.playerUW.name)
		{
			return 999;
		}
		return GetCapacity() - GetWeight() - GetBaseWeight();
	}

	public static bool TestContainerRules(Container cn, int SlotIndex, bool Swapping)
	{
		if (SlotIndex<11)
		{
			return true;
		}
		if (GameWorldController.instance.playerUW.playerInventory.ObjectInHand=="")
		{
			return true;
		}
		//Test the various rules for this slot
		ObjectInteraction objInt = GameWorldController.instance.playerUW.playerInventory.GetGameObjectInHand().GetComponent<ObjectInteraction>();
		//If in a non player container check that the object in hand can be added to it.
		bool TypeTest=false;
		//If in a non player container check that the container has the weight capacity to accept it.
		bool WeightTest=false;
//		Container curContainer = this;
		bool CapacityTest=false;
				if (EditorMode)//Anything is allowed in editor mode.
				{return true;}
		switch (cn.ObjectsAccepted)
		{//objects accepted; 0: runes, 1: arrows, 2: scrolls, 3: edibles, 0xFF: any
		case 0://runes
			TypeTest=(objInt.GetItemType()==ObjectInteraction.RUNE);break;
		case 1://Arrows
			TypeTest=(objInt.GetItemType()==ObjectInteraction.AMMO);break;
		case 2://Scrolls
			TypeTest=(
				(objInt.GetItemType()==ObjectInteraction.SCROLL)
				||
				(objInt.GetItemType()==ObjectInteraction.MAGICSCROLL)
				||
				(objInt.GetItemType()==ObjectInteraction.MAP)
				||
				(objInt.GetItemType()==ObjectInteraction.BOOK)
				);
			break;
		case 3: //Edibles
			TypeTest=((objInt.GetItemType()==ObjectInteraction.FOOD) || (objInt.GetItemType()==ObjectInteraction.POTIONS));break;
		default:
			TypeTest=true;break;
		}
		
		if (TypeTest==true)
		{
			if (objInt.GetWeight() >= cn.GetFreeCapacity())
			{
				WeightTest=false;
				UWHUD.instance.MessageScroll.Add ("The " + StringController.instance.GetSimpleObjectNameUW(cn.objInt()) + " is too full.");
			}
			else
			{
				WeightTest=true;
			}
		}
		else
		{//000~001~248~That item does not fit.
			UWHUD.instance.MessageScroll.Add (StringController.instance.GetString(1,248));
		}
		
		if (WeightTest==true)
		{
			if (cn.CountItems()<=cn.MaxCapacity())
			{
				CapacityTest=true;
			}
			else
			{//000~001~248~That item does not fit.
				UWHUD.instance.MessageScroll.Add (StringController.instance.GetString(1,248));				
			}
		}
		return (TypeTest && WeightTest && (CapacityTest | Swapping));
	}

		/// <summary>
		/// Finds the first item of a particular type in the container.
		/// </summary>
		/// <returns>The name of the object that matches the itemid</returns>
		/// <param name="itemid">Itemid.</param>
	public string findItemOfType(int itemid)
	{
		for (int i =0; i<=MaxCapacity(); i++ )
		{
			GameObject obj = GetGameObjectAt(i);
			if (obj!=null)
			{
				if (obj.GetComponent<ObjectInteraction>()!=null)
				{
					if (obj.GetComponent<ObjectInteraction>().item_id==itemid)
					{
						return obj.name;
					}
					else
					{
						if (obj.GetComponent<ObjectInteraction>().GetItemType()==ObjectInteraction.CONTAINER)
						{
							string ans= obj.GetComponent<Container>().findItemOfType(itemid);
							if (ans!="")
							{
								return ans;
							}
						}
					}
				}
			}
		}
		return "";
	}
		/// <summary>
		/// Counts the number of items in the container..
		/// </summary>
		/// <returns>The items.</returns>
		public int CountItems()
		{
				int count=0;
				for (int i =0; i<=MaxCapacity(); i++ )
				{
						if (items[i]!="")
						{
							count++;
						}
				}
				return count;
		}

	/*public override string getEquipString ()
	{//Assumes no container is generated as an opened one.
		return GameWorldController.instance.objectMaster.particle[objInt().item_id+1];
	}*/

	public override string UseVerb ()
	{
		return "open";
	}

	public override string UseObjectOnVerb_Inv ()
	{
		return "place object in bag";
	}

	public static void removeFromContainer(Container cn, string objectName)
		{	//Only removes from the top level container cn	
				for (int i =0; i<=cn.MaxCapacity ();i++)
				{
						if (cn.items[i] == objectName)
						{
								cn.RemoveItemFromContainer(i);
								return;
						}
				}
	}

		/// <summary>
		/// Populates the container based on what is linked to the objInt
		/// </summary>
		/// <param name="cn">Cn.</param>
		/// <param name="objInt">Object int.</param>
		public static void PopulateContainer(Container cn, ObjectInteraction objInt, ObjectLoader objList)
		{
				cn.ObjectsAccepted=-1;//For now default to accept all
				cn.Capacity=40;
				for (int i =0; i<=cn.MaxCapacity();i++)
				{//init the variables.
						if (cn.items[i]==null)
						{cn.items[i]="";}
				}
				if (objInt.link != 0)	//Container has objects
				{
						ObjectLoaderInfo tmpobj = ObjectLoader.getObjectInfoAt(objInt.link,objList);
						//int count = 0;
						if (ObjectLoader.GetItemTypeAt(objInt.link,objList) !=ObjectInteraction.LOCK)
						{
							cn.AddItemToContainer(ObjectLoader.UniqueObjectName(tmpobj));
						}
						while (tmpobj.next != 0)
						{
							tmpobj = ObjectLoader.getObjectInfoAt((int)tmpobj.next, objList);//objList[tmpobj.next];
							cn.AddItemToContainer(ObjectLoader.UniqueObjectName(tmpobj));
						}
				}

		}

	/// <summary>
	/// Finds the item index of a specfic item in the container.
	/// </summary>
	/// <returns>The item in container.</returns>
	public static int FindItemInContainer(Container cn, string ItemToFind)
	{
		for (int i =0; i<=cn.MaxCapacity ();i++)
		{
			if (cn.items[i] == ItemToFind)
			{					
				return i;
			}
		}
		return -1;
	}

}
