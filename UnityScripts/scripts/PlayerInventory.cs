using UnityEngine;
using System.Collections;

public class PlayerInventory : MonoBehaviour {

	//The game objects at the various slots. (not in use?)

	public int game;
	//TODO:make object in hand private so I can update code usages to use api instead.
	public string ObjectInHand; //What is the current active object held by the player
	public bool JustPickedup; //Has the player just picked something up.
	//The game object name of the item.
	public string sHelm;
	public string sChest;
	public string sLegs;
	public string sBoots;
	public string sGloves;
	public string sLeftHand;
	public string sRightHand;
	public string sLeftRing;
	public string sRightRing;
	public string sLeftShoulder;
	public string sRightShoulder;
	public string[] sBackPack= new string[8];
	//public bool[] runes = new bool[24];

	//Force Redraw on next update.
	public bool bHelm=true;
	public bool bChest=true;
	public bool bLegs=true;
	public bool bBoots=true;
	public bool bGloves=true;
	public bool bLeftHand=true;
	public bool bRightHand=true;
	public bool bLeftRing=true;
	public bool bRightRing=true;
	public bool bLeftShoulder=true;
	public bool bRightShoulder=true;
	public bool[] bBackPack= new bool[8];

	//Links to the slots where the object will be displayed
	public UITexture Helm_f_Slot;
	public UITexture Chest_f_Slot;
	public UITexture Legs_f_Slot;
	public UITexture Boots_f_Slot;
	public UITexture Gloves_f_Slot;
	public UITexture Helm_m_Slot;
	public UITexture Chest_m_Slot;
	public UITexture Legs_m_Slot;
	public UITexture Boots_m_Slot;
	public UITexture Gloves_m_Slot;
	public UITexture LeftHand_Slot;
	public UITexture RightHand_Slot;
	public UITexture LeftRing_Slot;
	public UITexture RightRing_Slot;
	public UITexture LeftShoulder_Slot;
	public UITexture RightShoulder_Slot;
	public UITexture[] BackPack_Slot=new UITexture[8];

	public bool atTopLevel;
	public string currentContainer;

	private UWCharacter playerUW;

	public Texture2D Blank;

	//For calculating light levels
	private Light lt;
	private LightSource ls;

	private Container playerContainer;
	public int ContainerOffset=0;//For scrolling the inventory.

	// Use this for initialization
	void Start () {
		Blank = Resources.Load <Texture2D> ("Sprites/Texture_Blank");
		atTopLevel=true;
		playerUW=this.GetComponent<UWCharacter>();
		playerContainer =this.GetComponent<Container>();
		for (int i =0;i<8;i++)
		{
			bBackPack[i]=true;
		}
	}
	
	// Update is called once per frame
	void Update () {

		switch (game)
		{

		case 2:
			{
			UpdateShock();
				break;
			}
		default:
			{
			UpdateUW();
			break;
			}
		}

	}

	void UpdateShock()
	{
		return;
	}

	void UpdateUW()
	{
		//Check for lights
		if (lt==null)
		{
			lt = this.gameObject.GetComponent<Light>();
		}

		ls = null;
		int MaxBrightness=LightSource.MagicBrightness;//Start with magically generated light.
		for (int i = 5; i<=8; i++)
		{
			ls = null;
			if (GetObjectAtSlot(i) != "")
			{
				GameObject objAtSlot = GetGameObjectAtSlot(i); //GameObject.Find (GetObjectAtSlot(i));
				if (objAtSlot != null)
				{
					ls =objAtSlot.GetComponent<LightSource>();
					if (ls != null)
					{
						if (ls.IsOn==true)
						{
							if (MaxBrightness < ls.Brightness)
							{
								MaxBrightness=ls.Brightness;
							}
						}
					}
				}
			}					
		}
		lt.range=LightSource.BaseBrightness+MaxBrightness;

		if (playerUW.isFemale==true)
		{//female
			DisplayGameObject (sHelm,Helm_f_Slot,true,ref bHelm);
			DisplayGameObject (sChest,Chest_f_Slot,true,ref bChest);
			DisplayGameObject (sLegs,Legs_f_Slot,true,ref bLegs);
			DisplayGameObject (sBoots,Boots_f_Slot,true,ref bBoots);
			DisplayGameObject (sGloves,Gloves_f_Slot,true,ref bGloves);
		}
		else
		{//male
			DisplayGameObject (sHelm,Helm_m_Slot,true,ref bHelm);
			DisplayGameObject (sChest,Chest_m_Slot,true,ref bChest);
			DisplayGameObject (sLegs,Legs_m_Slot,true,ref bLegs);
			DisplayGameObject (sBoots,Boots_m_Slot,true,ref bBoots);
			DisplayGameObject (sGloves,Gloves_m_Slot,true,ref bGloves);
		}
		
		DisplayGameObject(sLeftShoulder,LeftShoulder_Slot,false,ref bLeftShoulder);
		DisplayGameObject(sRightShoulder,RightShoulder_Slot,false,ref bRightShoulder);
		DisplayGameObject(sLeftRing,LeftRing_Slot,false,ref bLeftRing);
		DisplayGameObject(sRightRing,RightRing_Slot,false,ref bRightRing);
		
		DisplayGameObject(sLeftHand,LeftHand_Slot,false,ref bLeftHand);
		DisplayGameObject(sRightHand,RightHand_Slot,false,ref bRightHand);
		
		for (int i = 0 ; i < 8; i++)
		{
			DisplayGameObject (sBackPack[i],BackPack_Slot[i],false,ref bBackPack[i]);
		}
		return;
	}



	/*	void DisplayGameObject(string objName, UISprite Label, bool isEquipped, ref bool hasChanged)
	{
		if (hasChanged==true)
		{
			if (objName =="")
			{
				Label.spriteName="object_blank";
				hasChanged=false;
				return;
			}
			GameObject objToDisplay=GameObject.Find (objName);
			hasChanged=false;
			if (objToDisplay != null)
			{
				if (isEquipped==true)
				{
					Label.spriteName= objToDisplay.GetComponent<ObjectInteraction>().InventoryString;
				}
				else
				{
					//Debug.Log ("Displaying " + objToDisplay.GetComponent<ObjectInteraction>().InventoryString);
					Label.spriteName= objToDisplay.GetComponent<ObjectInteraction>().InventoryString;
				}
			}
			else
			{
				//Debug.Log ("Displaying blank");
				Label.spriteName="object_blank";
			}
		}

	}*/

	void DisplayGameObject(string objName, UITexture Label, bool isEquipped, ref bool hasChanged)
	{
		hasChanged=true;
		if (hasChanged==true)
		{
			if (objName =="")
			{
				Label.mainTexture=Blank;

				//Label.spriteName="object_blank";
				hasChanged=false;
				return;
			}
			GameObject objToDisplay=GameObject.Find (objName);
			hasChanged=false;
			if (objToDisplay != null)
			{
				if (isEquipped==true)
				{
					//Label.spriteName= objToDisplay.GetComponent<ObjectInteraction>().InventoryIconEquipString;
					Label.mainTexture=objToDisplay.GetComponent<ObjectInteraction>().GetEquipDisplay().texture;
				}
				else
				{
					//Debug.Log ("Displaying " + objToDisplay.GetComponent<ObjectInteraction>().InventoryString);
					//Label.spriteName= objToDisplay.GetComponent<ObjectInteraction>().InventoryString;
					Label.mainTexture=objToDisplay.GetComponent<ObjectInteraction>().GetInventoryDisplay().texture;
				}
			}
			else
			{
				//Debug.Log ("Displaying blank");
				Label.mainTexture=Blank;
				//Label.spriteName="object_blank";
			}
		}
		
	}

	public bool GetObjectDescAtSlot(int SlotIndex)
	{
		string objectName=GetObjectAtSlot (SlotIndex);
		if (objectName!="")
		{
			ObjectInteraction objInt = GameObject.Find (objectName).GetComponent<ObjectInteraction>();
			if (objInt != null)
			{
				return objInt.LookDescription();
			}
			else
			{
				return false;// "DESC NOT FOUND!!";
			}
		}
		else
		{
			return false; //"DESC NOT FOUND!!";
		}
	}

	public GameObject GetGameObjectAtSlot(int slotIndex)
	{
		string objname = GetObjectAtSlot (slotIndex);
		return GameObject.Find (objname);
	}

	public string GetObjectAtSlot(int slotIndex)
	{
		switch (slotIndex)
			{
			case 0://Helm
				return sHelm;
			case 1://Chest
				return sChest;
			case 2://Leggings
				return sLegs;
			case 3://Boots
				return sBoots;
			case 4://Gloves
				return sGloves;
			case 5://ShoulderRight
				return sRightShoulder;
			case 6://ShoulderLeft
				return sLeftShoulder;
			case 7://HandRight
				return sRightHand;
			case 8://HandLeft
				return sLeftHand;
			case 9://RingRight
				return sRightRing;
			case 10://RingLeft
				return sLeftRing;
			default://Inventory Slots 0-7		
				if ((slotIndex>=11)&&(slotIndex<=18))
					{
						return sBackPack[slotIndex-11];
					}
					else
					{
						return "";
					}
		}
	}

	public void SetObjectAtSlot(int slotIndex,string sObject)
	{
		switch (slotIndex)
		{
		case 0://Helm
			 sHelm=sObject;
	         bHelm=true;
			break;
		case 1://Chest
			sChest=sObject;
			bChest=true;
			break;
		case 2://Leggings
			sLegs=sObject;
			bLegs=true;
			break;
		case 3://Boots
			sBoots=sObject;
			bBoots=true;
			break;
		case 4://Gloves
			sGloves=sObject;
			bGloves=true;
			break;
		case 5://ShoulderRight
			sRightShoulder=sObject;
			bRightShoulder=true;
			break;
		case 6://ShoulderLeft
			sLeftShoulder=sObject;
			bLeftShoulder =true;
			break;
		case 7://HandRight
			sRightHand=sObject;
			bRightHand =true;
			break;
		case 8://HandLeft
			sLeftHand=sObject;
			bLeftHand=true;
			break;
		case 9://RingRight
			sRightRing=sObject;
			bRightRing=true;
			break;
		case 10://RingLeft
			sLeftRing=sObject;
			bLeftRing=true;
			break;
		default://Inventory Slots 0-7		
			if ((slotIndex>=11)&&(slotIndex<=18))
			{
				sBackPack[slotIndex-11]=sObject;
				bBackPack[slotIndex-11]=true;
				Container cn = GameObject.Find (currentContainer).GetComponent<Container>();
				cn.items[ContainerOffset + slotIndex-11]=sObject;
			}
			break;
		}
	}

	public void ClearSlot(int slotIndex)
	{
		switch (slotIndex)
		{
		case 0://Helm
			sHelm="";
			bHelm=true;
			break;
		case 1://Chest
			sChest="";
			bChest=true;
			break;
		case 2://Leggings
			sLegs="";
			bLegs=true;
			break;
		case 3://Boots
			sBoots="";
			bBoots=true;
			break;
		case 4://Gloves
			sGloves="";
			bGloves=true;
			break;
		case 5://ShoulderRight
			sRightShoulder="";
			bRightShoulder=true;
			break;
		case 6://ShoulderLeft
			sLeftShoulder="";
			bLeftShoulder=true;
			break;
		case 7://HandRight
			sRightHand="";
			bRightHand=true;
			break;
		case 8://HandLeft
			sLeftHand="";
			bLeftHand=true;
			break;
		case 9://RingRight
			sRightRing="";
			bRightRing=true;
			break;
		case 10://RingLeft
			sLeftRing="";
			bLeftRing=true;
			break;
		default://Inventory Slots 0-7		
			if ((slotIndex>=11)&&(slotIndex<=18))
			{
				sBackPack[slotIndex-11]="";
				bBackPack[slotIndex-11]=true;
			}
			break;
		}
	}

	public void Refresh()
	{//Force a full refresh of inventory display
		Container cn = GameObject.Find(currentContainer).GetComponent<Container>();

		bHelm=true;
		bChest=true;
		bLegs=true;
		bBoots=true;
		bGloves=true;
		bRightShoulder=true;
		bLeftShoulder=true;
		bRightHand=true;
		bLeftHand=true;
		bRightRing=true;
		bLeftRing=true;
		for (int i = 11; i<=18; i++)
			{
				sBackPack[i-11] = cn.GetItemAt(ContainerOffset + i-11);
				bBackPack[i-11]=true;
			}
	}


	public void SwapObjects(GameObject ObjInSlot, int slotIndex, string cObjectInHand)
	{//Swaps specified game object as the slot wth the passed object
		//Debug.Log ("Swapping " + ObjInSlot.name + " with " + cObjectInHand + " at slot " +slotIndex);
		Container cn = GameObject.Find(currentContainer).GetComponent<Container>();
		//cn.RemoveItemFromContainer(cObjectInHand);
		cn.RemoveItemFromContainer(ObjInSlot.name);
		SetObjectAtSlot(slotIndex,cObjectInHand);
		if (slotIndex>=11)
			{
			cn.AddItemToContainer(cObjectInHand,ContainerOffset + slotIndex-11);
			}
		ObjectInHand= ObjInSlot.name;
		playerUW.CursorIcon= ObjInSlot.GetComponent<ObjectInteraction>().GetInventoryDisplay().texture;
		//playerUW.CurrObjectSprite = ObjInSlot.GetComponent<ObjectInteraction>().InventoryString;
		Refresh();
	}


	public bool RemoveItem(string ObjectName)
	{//Removes the item from the paperdoll and the current container.
		if (sHelm==ObjectName)
		{
			sHelm="";
			bHelm=true;
			return true;
		}
		if (sChest==ObjectName)
		{
			sChest="";
			bChest=true;
			return true;
		}
		
		if (sLegs==ObjectName)
		{
			sLegs="";
			bLegs=true;
			return true;
		}
		
		if (sBoots==ObjectName)
		{
			sBoots="";
			bBoots=true;
			return true;
		}
		
		if (sGloves==ObjectName)
		{
			sGloves="";
			bGloves=true;
			return true;
		}
		
		if (sRightShoulder==ObjectName)
		{
			sRightShoulder="";
			bRightShoulder=true;
			return true;
		}
		
		if (sLeftShoulder==ObjectName)
		{
			sLeftShoulder="";
			bLeftShoulder=true;
			return true;
		}
		
		if (sRightHand==ObjectName)
		{
			sRightHand="";
			bRightHand=true;
			return true;
		}
		
		if (sLeftHand==ObjectName)
		{
			sLeftHand="";
			bLeftHand=true;
			return true;
		}
		
		if (sRightRing==ObjectName)
		{
			sRightRing="";
			bRightRing=true;
			return true;
		}
		
		if (sLeftRing==ObjectName)
		{
			sLeftRing="";
			bLeftRing=true;
			return true;
		}
		Container backpack = GameObject.Find(this.currentContainer).GetComponent<Container>();
		for (int i =0; i<8;i++)
		{
			if (ObjectName == backpack.items[i])
			{
				backpack.items[i]="";
				sBackPack[i]="";
				bBackPack[i]=true;
				return true;
			}
		}
		return false;
	}

	public bool RemoveItemFromEquipment(string ObjectName)
	{//Remove the object from wherever it is on the characters paperdoll.
		if (sHelm==ObjectName)
		{
			sHelm="";
			bHelm=true;
			return true;
		}
		if (sChest==ObjectName)
		{
			sChest="";
			bChest=true;
			return true;
		}

		if (sLegs==ObjectName)
		{
			sLegs="";
			bLegs=true;
			return true;
		}

		if (sBoots==ObjectName)
		{
			sBoots="";
			bBoots=true;
			return true;
		}

		if (sGloves==ObjectName)
		{
			sGloves="";
			bGloves=true;
			return true;
		}

		if (sRightShoulder==ObjectName)
		{
			sRightShoulder="";
			bRightShoulder=true;
			return true;
		}

		if (sLeftShoulder==ObjectName)
		{
			sLeftShoulder="";
			bLeftShoulder=true;
			return true;
		}

		if (sRightHand==ObjectName)
		{
			sRightHand="";
			bRightHand=true;
			return true;
		}
		
		if (sLeftHand==ObjectName)
		{
			sLeftHand="";
			bLeftHand=true;
			return true;
		}

		if (sRightRing==ObjectName)
		{
			sRightRing="";
			bRightRing=true;
			return true;
		}
		
		if (sLeftRing==ObjectName)
		{
			sLeftRing="";
			bLeftRing=true;
			return true;
		}
		return false;
	}


	public string GetObjectInHand()
	{
		return ObjectInHand;
	}

	public GameObject GetGameObjectInHand()
	{
	if (ObjectInHand !="")
		{
			return GameObject.Find (ObjectInHand);
		}
		else
		{
			return null;
		}

	}

	public void SetObjectInHand(GameObject obj)
	{
		ObjectInHand=obj.name;
	}

	public void SetObjectInHand(string obj)
	{
		ObjectInHand=obj;
	}

	public Container GetCurrentContainer()
	{
		return GameObject.Find (currentContainer).GetComponent<Container>();
	}

	public GameObject GetGameObject(string name)
	{
		return GameObject.Find (name);
	}

}
