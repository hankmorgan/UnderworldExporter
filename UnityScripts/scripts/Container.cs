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
		ObjectInteraction currObjInt = this.gameObject.GetComponent<ObjectInteraction>();
		if (currObjInt.PickedUp==false)
			{//The requested container is open in the game world. This can cause problems!
			Debug.Log ("Can't open a container in the real world in this function!");
			return;
			}
		//GameObject.Find("ContainerOpened").GetComponent<UISprite>().spriteName=currObjInt.InventoryString;
		GameObject.Find("ContainerOpened").GetComponent<UITexture>().mainTexture=currObjInt.GetInventoryDisplay().texture;
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


	public static void SetPickedUpFlag(Container cn, bool NewValue)
	{
		for (int i =0; i<40;i++)
		{
			string ItemName=cn.GetItemAt(i);
			if (ItemName != "")
			{
				GameObject item = GameObject.Find (cn.GetItemAt(i));
				item.GetComponent<ObjectInteraction>().PickedUp=NewValue;
				if (item.GetComponent<Container>()!=null)
				{
					Container.SetPickedUpFlag(item.GetComponent<Container>(),NewValue);
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
				item.transform.position=Position;
				if (item.GetComponent<Container>()!=null)
				{
					Container.SetItemsPosition(item.GetComponent<Container>(),Position);
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
				item.transform.parent=Parent;
				if (item.GetComponent<Container>()!=null)
				{
					Container.SetItemsParent(item.GetComponent<Container>(),Parent);
				}
			}
		}
	}

}
