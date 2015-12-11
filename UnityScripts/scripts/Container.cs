using UnityEngine;
using System.Collections;

public class Container : object_base {

	public string[] items=new string[40];
	public int start=0;

	public int Capacity;
	public int NoOfSlots;
	public int ObjectsAccepted;

	public bool isOpenOnPanel;//Is the container open on the players inventory.
	public string ContainerParent; //What container is above this one. For passing objects out of the container.

	public int MaxCapacity()
	{
		return items.GetUpperBound (0);
	}

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

	public bool AddItemMergedItemToContainer(GameObject item)
	{
		for (int i=0; i< 40; i++)
		{
			if (items[i]!="")
			{
				GameObject founditem = GameObject.Find (items[i]);
				if (founditem.GetComponent<ObjectInteraction>().item_id==item.GetComponent<ObjectInteraction>().item_id)
				{
					//merge
					//Debug.Log ("Merging");
					founditem.GetComponent<ObjectInteraction>().Link =founditem.GetComponent<ObjectInteraction>().Link+ item.GetComponent<ObjectInteraction>().Link;
					GameObject.Destroy (item);
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
		while ((items[i] !="") && (i <40))
			{
				i++;
			}
		if (i<=39)
			{
				//items[i] = item;
				return AddItemToContainer(item,i);
				//return true;
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
		if (index<=39)
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
		for (int i =0; i<40;i++)
			{
			if (items[i] == objectName)
				{
				RemoveItemFromContainer(i);
				return true;
				}
			}
		return false;
	}

   /*static public bool xAddObjectToContainer(GameObject objInHand, GameObject objUseOn)
	{
		Container subContainer = objUseOn.GetComponent<Container>();
		if (subContainer.AddItemToContainer(objInHand.name))
		{
			Container ObjInHandContainer=objInHand.GetComponent<Container>();
			if (ObjInHandContainer!=null)
			{
				subContainer=objInHand.GetComponent<Container>();
				subContainer.ContainerParent=objUseOn.name;
			}
			return true;
		}
		else
		{
			return false;
		}
	}*/

	public void OpenContainer()
	{
		playerUW.playerInventory.ContainerOffset=0;
		ScrollButtonStatsDisplay.ScrollValue=0;
		ObjectInteraction currObjInt = this.gameObject.GetComponent<ObjectInteraction>();
		if (currObjInt.PickedUp==false)
			{//The requested container is open in the game world. This can cause problems!
			//Debug.Log ("Opening a container in the real world");
			SpillContents();
			return;
			}
		//Sort the container
		Container.SortContainer(this);
		GameObject.Find("ContainerOpened").GetComponent<UITexture>().mainTexture=currObjInt.GetEquipDisplay().texture;
		if (this.isOpenOnPanel==false)
		{
			this.isOpenOnPanel=true;
			ContainerParent=playerUW.playerInventory.currentContainer;
		}
		playerUW.playerInventory.currentContainer=this.name;
		if (playerUW.playerInventory.currentContainer=="")
		{
			playerUW.playerInventory.currentContainer=playerUW.name;
			this.ContainerParent=playerUW.name;
		}
		for (int i = 0; i<8; i++)
		{
			string sItem = this.GetItemAt(i);
			playerUW.playerInventory.SetObjectAtSlot(i+11,sItem);
		}
	}

	public void SpillContents()
	{//Removes the contents of a container out in the real world.
		int counter;
		TileMap tm = GameObject.Find("Tilemap").GetComponent<TileMap>();
		WindowDetect.FreezeMovement(this.gameObject);
		ObjectInteraction objInt = this.gameObject.GetComponent<ObjectInteraction>();
		objInt.SetWorldDisplay(objInt.GetEquipDisplay());
		for (int i=0; i<40;i++)
		{
			if (GetItemAt (i)!="")
			{
				GameObject Spilled = GameObject.Find (GetItemAt (i));
				if (Spilled!=null)
				{	
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
						WindowDetect.UnFreezeMovement(Spilled);
					}									
				}
			}
		}
		WindowDetect.UnFreezeMovement(this.gameObject);
	}


	public static void SetPickedUpFlag(Container cn, bool NewValue)
	{//Recursivly sets the picked up flag on all items in the container and all sub-container contents.
		for (int i =0; i<40;i++)
		{
			string ItemName=cn.GetItemAt(i);
			if (ItemName != "")
			{
				GameObject item = GameObject.Find (cn.GetItemAt(i));
				if (item !=null)
				{
					if (item.GetComponent<ObjectInteraction>()!=null)
					{
						item.GetComponent<ObjectInteraction>().PickedUp=NewValue;
						if (item.GetComponent<ObjectInteraction>().ItemType==ObjectInteraction.A_PICK_UP_TRIGGER)
						{//Special case
							item.GetComponent<a_pick_up_trigger>().Activate();
							if (item==null)
							{//Use trigger is no more.
								cn.RemoveItemFromContainer(i);
							}
						}
						else if (item.GetComponent<Container>()!=null)
						{
							Container.SetPickedUpFlag(item.GetComponent<Container>(),NewValue);
						}
					}
				}
			}
		}
	}

	public static void SetItemsPosition(Container cn, Vector3 Position)
	{
		for (int i =0; i<40;i++)
		{
			string ItemName=cn.GetItemAt(i);
			if (ItemName != "")
			{
				GameObject item = GameObject.Find (cn.GetItemAt(i));
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
		for (int i =0; i<40;i++)
		{
			string ItemName=cn.GetItemAt(i);
			if (ItemName != "")
			{
				GameObject item = GameObject.Find (cn.GetItemAt(i));
				if (item != null)
				{
					item.transform.parent=Parent;
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
		for (int i=0;i<40;i++)
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
		for (int i=0;i<40;i++)
		{
			//Find the first free slot
			if (GetNextSlot==true)
			{
				for (int j=0;j<40;j++)
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
		GameObject ObjectInHand=playerUW.playerInventory.GetGameObjectInHand();
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
			//TODO:Do a test for Container capacity  here.


			if (Valid)
			{
				if ((ObjectInHand.GetComponent<ObjectInteraction>().isQuant==false) || (ObjectInHand.GetComponent<ObjectInteraction>().isEnchanted))
				{
					AddItemToContainer(playerUW.playerInventory.ObjectInHand);
				}
				else
				{
					AddItemMergedItemToContainer(ObjectInHand.gameObject);
				}
				
				if (isOpenOnPanel == true)
				{//Container is open for display force a refresh.
					OpenContainer();
				}
				playerUW.playerInventory.ObjectInHand= "";
				playerUW.CursorIcon= playerUW.CursorIconDefault;

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
		for (int i=0; i<MaxCapacity();i++)
		{
			if (GetItemAt(i)!="")
			{
				ObjectInteraction objContainerItem = GameObject.Find (GetItemAt(i)).GetComponent<ObjectInteraction>();
				answer+=objContainerItem.GetWeight();
			}
		}
		return answer;
	}
}
