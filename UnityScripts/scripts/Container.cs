using UnityEngine;
using System.Collections;

public class Container : MonoBehaviour {

	//public int NoOfSlots=40;
	public string[] items=new string[40];
	public int start=0;

	public int Capacity;
	public int NoOfSlots;
	public int ObjectsAccepted;

	public bool isOpenOnPanel;
	//public int itemCount=0;
	public string ContainerParent;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
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
			Debug.Log(name + ": invalid item for adding");
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
			Debug.Log (name + " is set to an invalid index " + index);
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
				Debug.Log ("removed " + objectName + " at (" + i + ")");
				return true;
				}
			}
		return false;
	}

   static public bool AddObjectToContainer(GameObject objInHand, GameObject objUseOn)
	{
		Debug.Log ("Adding " + objInHand + " to " + objUseOn);
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

	/*

	public string ObjectPickedUp(int slotIndex, string sObjectInHand)
	{//Returns the game object of the object already in the slot
		PlayerInventory pInv =GameObject.Find ("Gronk").GetComponent<PlayerInventory>();
		string ExistingObject="";

		switch (slotIndex)
		{
		case 0://Helm
			if (InventorySlot.InteractTwoObjects (sObjectInHand,pInv.sHelm,slotIndex) == false)
			{
				pInv.bHelm=true;
				ExistingObject=pInv.sHelm;
				pInv.sHelm=sObjectInHand;
			}
			else
			{
				ExistingObject="";
			}
			break;
		case 1://Chest
			if (InventorySlot.InteractTwoObjects (sObjectInHand,pInv.sChest,slotIndex) == false)
			{
				pInv.bChest=true;
				ExistingObject=pInv.sChest;
				pInv.sChest=sObjectInHand;
			}
			else
			{
				ExistingObject="";
			}
			break;
		case 2://Leggings
			if (InventorySlot.InteractTwoObjects (sObjectInHand,pInv.sLegs,slotIndex) == false)
			{
				pInv.bLegs=true;
				ExistingObject=pInv.sLegs;
				pInv.sLegs=sObjectInHand;
			}
			else
			{
				ExistingObject="";
			}
			break;
		case 3://Boots
			if (InventorySlot.InteractTwoObjects (sObjectInHand,pInv.sBoots,slotIndex) == false)
			{
				pInv.bBoots=true;
				ExistingObject=pInv.sBoots;
				pInv.sBoots=sObjectInHand;
			}
			else
			{
				ExistingObject="";
			}
			break;
		case 4://Gloves
			if (InventorySlot.InteractTwoObjects (sObjectInHand,pInv.sGloves,slotIndex) == false)
			{
				pInv.bGloves=true;
				ExistingObject=pInv.sGloves;
				pInv.sGloves=sObjectInHand;
			}
			else
			{
				ExistingObject="";
			}
			break;
		case 5://ShoulderRight
			if (InventorySlot.InteractTwoObjects (sObjectInHand,pInv.sRightShoulder,slotIndex) == false)
			{
				pInv.bRightShoulder=true;
				ExistingObject=pInv.sRightShoulder;
				pInv.sRightShoulder=sObjectInHand;
			}
			else
			{
				ExistingObject="";
			}
			break;
		case 6://ShoulderLeft
			if (InventorySlot.InteractTwoObjects (sObjectInHand,pInv.sLeftShoulder,slotIndex) == false)
			{
				pInv.bLeftShoulder=true;
				ExistingObject=pInv.sLeftShoulder;
				pInv.sLeftShoulder=sObjectInHand;
			}
			else
			{
				ExistingObject="";
			}
			break;
		case 7://HandRight
			if (InventorySlot.InteractTwoObjects (sObjectInHand,pInv.sRightHand,slotIndex) == false)
			{
				pInv.bRightHand=true;
				ExistingObject=pInv.sRightHand;
				pInv.sRightHand=sObjectInHand;
			}
			else
			{
				ExistingObject="";
			}
			break;
		case 8://HandLeft
			if (InventorySlot.InteractTwoObjects (sObjectInHand,pInv.sLeftHand,slotIndex) == false)
			{
				pInv.bLeftHand=true;
				ExistingObject=pInv.sLeftHand;
				pInv.sLeftHand=sObjectInHand;
			}
			else
			{
				ExistingObject="";
			}
			break;
		case 9://RingRight
			if (InventorySlot.InteractTwoObjects (sObjectInHand,pInv.sRightRing,slotIndex) == false)
			{
				pInv.bRightRing=true;
				ExistingObject=pInv.sRightRing;
				pInv.sRightRing=sObjectInHand;
			}
			else
			{
				ExistingObject="";
			}
			break;
		case 10://RingLeft
			if (InventorySlot.InteractTwoObjects (sObjectInHand,pInv.sLeftRing,slotIndex) == false)
			{
				pInv.bLeftRing=true;
				ExistingObject=pInv.sLeftRing;
				pInv.sLeftRing=sObjectInHand;
			}
			else
			{
				ExistingObject="";
			}
			break;
		default://Inventory Slots 0-7	
			if ((slotIndex>=11)&&(slotIndex<=18))
			{
				if (InventorySlot.InteractTwoObjects (sObjectInHand,pInv.sBackPack[slotIndex-11],slotIndex)==false)
				{
					pInv.bBackPack[slotIndex-11]=true;
					ExistingObject=pInv.sBackPack[slotIndex-11];
					pInv.sBackPack[slotIndex-11]=sObjectInHand;
					RemoveItemFromContainer (slotIndex-11);
					AddItemToContainer (sObjectInHand,slotIndex-11);
				}
				else
				{
					ExistingObject="";
				}

		
			}
			break;
		}
		//	}
		
		return ExistingObject;
		
	}
*/
	public void OpenContainer()
	{

		PlayerInventory pInv = GameObject.Find ("Gronk").GetComponent<PlayerInventory>();
		pInv.ContainerOffset=0;
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
		//GameObject.Find("ContainerOpened").GetComponent<UISprite>().spriteName=currObjInt.InventoryString;
		GameObject.Find("ContainerOpened").GetComponent<UITexture>().mainTexture=currObjInt.GetEquipDisplay().texture;
		//transform.parent.FindChild("ContainerOpened").GetComponent<ContainerOpened>().ContainerTarget = pInv.currentContainer;
		//display the container contents.
		//Container currObjCont = currObj.GetComponent<Container>();
		if (this.isOpenOnPanel==false)
		{
			this.isOpenOnPanel=true;
			ContainerParent=pInv.currentContainer;
		}
		//pInv.atTopLevel=false;
		pInv.currentContainer=this.name;
		if (pInv.currentContainer=="")
		{
			pInv.currentContainer="Gronk";
			this.ContainerParent="Gronk";
		}
		for (int i = 0; i<8; i++)
		{
			string sItem = this.GetItemAt(i);
			pInv.SetObjectAtSlot(i+11,sItem);
		}
	}

	public void SpillContents()
	{//Removes the contents of a container out it in the real world.
		int counter;
		TileMap tm = GameObject.Find("Tilemap").GetComponent<TileMap>();
		WindowDetect.FreezeMovement(this.gameObject);
		BoxCollider bx = this.gameObject.GetComponent<BoxCollider>();
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
}
