using UnityEngine;
using System.Collections;

public class Container : object_base {

	//public int NoOfSlots=40;
	public string[] items=new string[40];
	public int start=0;

	public int Capacity;
	public int NoOfSlots;
	public int ObjectsAccepted;

//	public static UWCharacter playerUW;

	public bool isOpenOnPanel;
	//public int itemCount=0;
	public string ContainerParent;


	public int MaxCapacity()
	{
		return items.GetUpperBound (0);
	}

	public string GetItemAt(int index)
	{
		if ((index >=0) || (index<40))
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
		//int i =0;

		for (int i=0; i< 40; i++)
		{
			if (items[i]!="")
			{
				GameObject founditem = GameObject.Find (items[i]);
				if (founditem.GetComponent<ObjectInteraction>().item_id==item.GetComponent<ObjectInteraction>().item_id)
				{
					//merge
					Debug.Log ("Merging");
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
			items[i] = item;
			return true;
		}
		else
		{
			//no room
			Debug.Log (name + " is full");
			return false;
		}
		//if (item =="")
		//{
		//	Debug.Log(name + ": invalid item for adding");
		//	return false;
		//}
		//if (itemCount<=39)
		//	{
		////		items[itemCount]=item;
//				itemCount++;
		//		return true;
		//	}
		//else
		//	{
		//		Debug.Log (name + " is full");
		//		return false;
		//	}
		}
	public bool AddItemToContainer(string item,int index)
	{
		if (item =="")
		{
			//Debug.Log(name + ": invalid item for adding");
			return false;
		}
		if (index<=39)
		{
			items[index]=item;
			//itemCount++;
			return true;
		}
		else
		{
			//Debug.Log (name + " is set to an invalid index " + index);
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
		//	Debug.Log (name + "(" +index + ") invalid item for removal");
			return false;
			}
		}

	public bool RemoveItemFromContainer(string objectName)
	{
		for (int i =0; i<40;i++)
			{
			if (items[i] == objectName)
				{
				items[i]="";
				//Debug.Log ("removed " + objectName + " at (" + i + ")");
				return true;
				}
			}
		return false;
	}

   static public bool AddObjectToContainer(GameObject objInHand, GameObject objUseOn)
	{
		//Debug.Log ("Adding " + objInHand + " to " + objUseOn);
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
	}

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
	{//Removes the contents of a container out it in the real world.
		int counter;
		TileMap tm = GameObject.Find("Tilemap").GetComponent<TileMap>();
		WindowDetect.FreezeMovement(this.gameObject);
		//BoxCollider bx = this.gameObject.GetComponent<BoxCollider>();
		ObjectInteraction objInt = this.gameObject.GetComponent<ObjectInteraction>();
		//objInt.SetWorldDisplay(objInt.GetEquipDisplay());
		objInt.SetWorldDisplay(objInt.GetEquipDisplay());
		//objInt.RefreshAnim();
		//bx.enabled=false;
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
						//Debug.Log ("putting " + Spilled.name + " at " + randomPoint);
						Spilled.transform.position=randomPoint;
						Spilled.GetComponent<ObjectInteraction>().PickedUp=false;
						WindowDetect.UnFreezeMovement(Spilled);
						//Spilled.rigidbody.AddForce(Random.insideUnitSphere*0.05f);
					}									
				}
			}
		}
		//bx.enabled=true;
		WindowDetect.UnFreezeMovement(this.gameObject);
	}


	public static void SetPickedUpFlag(Container cn, bool NewValue)
	{
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
					}
					else
					{
						Debug.Log (item.name + " has no object interaction!");
					}
					if (item.GetComponent<Container>()!=null)
					{
						Container.SetPickedUpFlag(item.GetComponent<Container>(),NewValue);
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
				//else
				//	{
						//Debug.Log (">" + ItemName + "< is null!");
				//	}
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
			//	else
				//{
				//	Debug.Log(ItemName + " is null!");
				//}
			}
		}
	}

	public static int GetFreeSlot(Container cn)
	{
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
			
			if (Valid)
			{
				if (ObjectInHand.GetComponent<ObjectInteraction>().isQuant==false)
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



}
