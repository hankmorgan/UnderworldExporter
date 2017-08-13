using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerInventory : UWEBase {

	public int ItemCounter=0;
	//public int game;
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



	public GameObject InventoryMarker;
	private GameObject[] LightGameObjects=new GameObject[4];

	public bool atTopLevel;
	public string currentContainer;
	private UWCharacter playerUW;

	public Texture2D Blank;

	//For calculating light levels
	public Light lt;
	private LightSource ls;

	public Container playerContainer;
	public short ContainerOffset=0;//For scrolling the inventory.

		public static bool Ready;
	
	public void Begin () {
		if (_RES==GAME_SHOCK){return;}
		GRLoader bodies = new GRLoader(GRLoader.BODIES_GR);
		Blank = Resources.Load <Texture2D> (_RES +"/Sprites/Texture_Blank");
		atTopLevel=true;
		playerUW=this.GetComponent<UWCharacter>();
		playerContainer =this.GetComponent<Container>();
		for (int i =0;i<8;i++)
		{
			bBackPack[i]=true;
		}
		UWHUD.instance.Encumberance.text=Mathf.Round(getEncumberance()).ToString();
		if (playerUW.isFemale)
		{				
			//UWHUD.instance.playerBody.texture =(Texture2D)Resources.Load(_RES +"/Hud/Bodies/bodies_" + (5+playerUW.Body).ToString("0000"));		
			UWHUD.instance.playerBody.texture = bodies.LoadImageAt(5+playerUW.Body);
		}
		else
		{
			//UWHUD.instance.playerBody.texture =(Texture2D)Resources.Load(_RES +"/Hud/Bodies/bodies_" + (playerUW.Body).ToString("0000"));		
			UWHUD.instance.playerBody.texture = bodies.LoadImageAt(playerUW.Body);
		}
			
		Ready=true;
		Refresh();
	}
	
	// Update is called once per frame
	void Update () {
		if (!Ready){return;}
		switch(_RES)		
		{
		case GAME_SHOCK:
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
		if (playerUW.isFemale==true)
		{//female
			DisplayGameObject (sHelm,UWHUD.instance.Helm_f_Slot,null,true,ref bHelm);
			DisplayGameObject (sChest,UWHUD.instance.Chest_f_Slot,null,true,ref bChest);
			DisplayGameObject (sLegs,UWHUD.instance.Legs_f_Slot,null,true,ref bLegs);
			DisplayGameObject (sBoots,UWHUD.instance.Boots_f_Slot,null,true,ref bBoots);
			DisplayGameObject (sGloves,UWHUD.instance.Gloves_f_Slot,null,true,ref bGloves);
		}
		else
		{//male
			DisplayGameObject (sHelm,UWHUD.instance.Helm_m_Slot,null,true,ref bHelm);
			DisplayGameObject (sChest,UWHUD.instance.Chest_m_Slot,null,true,ref bChest);
			DisplayGameObject (sLegs,UWHUD.instance.Legs_m_Slot,null,true,ref bLegs);
			DisplayGameObject (sBoots,UWHUD.instance.Boots_m_Slot,null,true,ref bBoots);
			DisplayGameObject (sGloves,UWHUD.instance.Gloves_m_Slot,null,true,ref bGloves);
		}
		
		DisplayGameObject(sLeftShoulder,UWHUD.instance.LeftShoulder_Slot,UWHUD.instance.LeftShoulder_Qty,false,ref bLeftShoulder);
		DisplayGameObject(sRightShoulder,UWHUD.instance.RightShoulder_Slot,UWHUD.instance.RightShoulder_Qty,false,ref bRightShoulder);
		DisplayGameObject(sLeftRing,UWHUD.instance.LeftRing_Slot,null,false,ref bLeftRing);
		DisplayGameObject(sRightRing,UWHUD.instance.RightRing_Slot,null,false,ref bRightRing);

		DisplayGameObject(sLeftHand,UWHUD.instance.LeftHand_Slot,UWHUD.instance.LeftHand_Qty,false,ref bLeftHand);
		DisplayGameObject(sRightHand,UWHUD.instance.RightHand_Slot,UWHUD.instance.RightHand_Qty,false,ref bRightHand);
		
		for (int i = 0 ; i < 8; i++)
		{
			DisplayGameObject (sBackPack[i],UWHUD.instance.BackPack_Slot[i],UWHUD.instance.Backpack_Slot_Qty[i],false,ref bBackPack[i]);
		}
		return;
	}

	/// <summary>
	/// Checks the light sources equiped by the player and makes sure the brightest one is in use
	/// </summary>
	public void UpdateLightSources ()
	{
		//Check for lights
		if (lt == null) {
			lt = this.gameObject.GetComponentInChildren<Light> ();
		}
		ls = null;
		int MaxBrightness = LightSource.MagicBrightness;
		//Start with magically generated light.
		for (int i = 5; i <= 8; i++) {
			ls = null;
			//Update the gameobject at the slot if needed
			if (LightGameObjects [i - 5] != null) {
				if (GetObjectAtSlot (i) != LightGameObjects [i - 5].name) {
					LightGameObjects [i - 5] = GetGameObjectAtSlot (i);
				}
			}
			else {
				//No object
				if (GetObjectAtSlot (i) != "") {
					LightGameObjects [i - 5] = GetGameObjectAtSlot (i);
				}
			}
			if (GetObjectAtSlot (i) != "") {
				//GameObject objAtSlot = GetGameObjectAtSlot(i); //GameObject.Find (GetObjectAtSlot(i));
				if (LightGameObjects [i - 5] != null) {
					ls = LightGameObjects [i - 5].GetComponent<LightSource> ();
					if (ls != null) {
						if (ls.IsOn() == true) {
							if (MaxBrightness < ls.Brightness) {
								MaxBrightness = ls.Brightness;
							}
						}
					}
				}
			}
		}
		lt.range = LightSource.BaseBrightness + MaxBrightness;
		if(MaxBrightness>0)
		{
				playerUW.LightActive=true;
		}
		else
		{
				playerUW.LightActive=false;
		}
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

		void DisplayGameObject(string objName, RawImage Label, Text qtyDisplay, bool isEquipped, ref bool hasChanged)
	{
		//hasChanged=true;
		if (hasChanged==true)
		{
			if (objName =="")
						{
				Label.texture=Blank;
				if (qtyDisplay!=null)
				{
					qtyDisplay.text="";
				}
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
					Label.texture=objToDisplay.GetComponent<ObjectInteraction>().GetEquipDisplay().texture;
				}
				else
				{
					//Debug.Log ("Displaying " + objToDisplay.GetComponent<ObjectInteraction>().InventoryString);
					//Label.spriteName= objToDisplay.GetComponent<ObjectInteraction>().InventoryString;
					Label.texture=objToDisplay.GetComponent<ObjectInteraction>().GetInventoryDisplay().texture;
					if (qtyDisplay!=null)
					{
						int qty = objToDisplay.GetComponent<ObjectInteraction>().GetQty();
						if (qty<=1)
						{
							qtyDisplay.text="";
						}
						else
						{
							qtyDisplay.text=qty.ToString();
						}
					}
				}
			}
			else
			{
				//Debug.Log ("Displaying blank");
				Label.texture=Blank;
				if (qtyDisplay!=null)
				{
					qtyDisplay.text="";
				}
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

	public void SetObjectAtSlot(short slotIndex,string sObject)
	{
		switch (slotIndex)
		{
		case 0://Helm
			 sHelm=sObject;
	         bHelm=true;
			 EquipItemEvent(slotIndex);
			break;
		case 1://Chest
			sChest=sObject;
			bChest=true;
			EquipItemEvent(slotIndex);
			break;
		case 2://Leggings
			sLegs=sObject;
			bLegs=true;
			EquipItemEvent(slotIndex);
			break;
		case 3://Boots
			sBoots=sObject;
			bBoots=true;
			EquipItemEvent(slotIndex);
			break;
		case 4://Gloves
			sGloves=sObject;
			bGloves=true;
			EquipItemEvent(slotIndex);
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
			EquipItemEvent(slotIndex);
			break;
		case 8://HandLeft
			sLeftHand=sObject;
			bLeftHand=true;
			EquipItemEvent(slotIndex);
			break;
		case 9://RingRight
			sRightRing=sObject;
			bRightRing=true;
			EquipItemEvent(slotIndex);
			break;
		case 10://RingLeft
			sLeftRing=sObject;
			bLeftRing=true;
			EquipItemEvent(slotIndex);
			break;
		default://Inventory Slots 0-7		
			if ((slotIndex>=11)&&(slotIndex<=18))
			{
				sBackPack[slotIndex-11]=sObject;
				bBackPack[slotIndex-11]=true;
				Container cn = GameObject.Find (currentContainer).GetComponent<Container>();
				cn.items[ContainerOffset + slotIndex-11]=sObject;
				PutItemAwayEvent(slotIndex);
			}
			break;
		}
	}

	public void ClearSlot(short slotIndex)
	{
		switch (slotIndex)
		{
		case 0://Helm
			UnEquipItemEvent(slotIndex);
			sHelm="";
			bHelm=true;
			break;
		case 1://Chest
			UnEquipItemEvent(slotIndex);
			sChest="";
			bChest=true;
			break;
		case 2://Leggings
			UnEquipItemEvent(slotIndex);
			sLegs="";
			bLegs=true;
			break;
		case 3://Boots
			UnEquipItemEvent(slotIndex);
			sBoots="";
			bBoots=true;
			break;
		case 4://Gloves
			UnEquipItemEvent(slotIndex);
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
			UnEquipItemEvent(slotIndex);
			sRightHand="";
			bRightHand=true;
			break;
		case 8://HandLeft
			UnEquipItemEvent(slotIndex);
			sLeftHand="";
			bLeftHand=true;
			break;
		case 9://RingRight
			UnEquipItemEvent(slotIndex);
			sRightRing="";
			bRightRing=true;
			break;
		case 10://RingLeft
			UnEquipItemEvent(slotIndex);
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

	public void Refresh(int slotIndex)
	{//Force a refresh of a specific slot
		switch (slotIndex)
		{
		case 0://Helm
			bHelm=true;
			break;
		case 1://Chest
			bChest=true;
			break;
		case 2://Leggings
			bLegs=true;
			break;
		case 3://Boots
			bBoots=true;
			break;
		case 4://Gloves
			bGloves=true;
			break;
		case 5://ShoulderRight
			bRightShoulder=true;
			break;
		case 6://ShoulderLeft
			bLeftShoulder=true;
			break;
		case 7://HandRight
			bRightHand=true;
			break;
		case 8://HandLeft
			bLeftHand=true;
			break;
		case 9://RingRight
			bRightRing=true;
			break;
		case 10://RingLeft
			bLeftRing=true;
			break;
		default://Inventory Slots 0-7		
			if ((slotIndex>=11)&&(slotIndex<=18))
			{
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
		for (short i = 11; i<=18; i++)
			{
				sBackPack[i-11] = cn.GetItemAt((short)(ContainerOffset + i-11));
				bBackPack[i-11]=true;
			}
		if (UWHUD.instance.Encumberance.enabled==true)
		{
			UWHUD.instance.Encumberance.text=Mathf.Round(getEncumberance()).ToString();
		}
		UpdateLightSources();
	}


	public void SwapObjects(GameObject ObjInSlot, short slotIndex, string cObjectInHand)
	{//Swaps specified game object as the slot wth the passed object
		//Debug.Log ("Swapping " + ObjInSlot.name + " with " + cObjectInHand + " at slot " +slotIndex);
		Container cn = GameObject.Find(currentContainer).GetComponent<Container>();
		//cn.RemoveItemFromContainer(cObjectInHand);
		//cn.RemoveItemFromContainer(ObjInSlot.name);//removed this when adding equip events.
		RemoveItem(ObjInSlot.name);
		SetObjectAtSlot(slotIndex,cObjectInHand);
		if (slotIndex>=11)
			{
			cn.AddItemToContainer(cObjectInHand,ContainerOffset + slotIndex-11);
			}
		ObjectInHand= ObjInSlot.name;
		UWHUD.instance.CursorIcon= ObjInSlot.GetComponent<ObjectInteraction>().GetInventoryDisplay().texture;
		//playerUW.CurrObjectSprite = ObjInSlot.GetComponent<ObjectInteraction>().InventoryString;
		Refresh();
	}


	public bool RemoveItem(string ObjectName)
	{//Removes the item from the paperdoll and/or the player inventory.
		if (sHelm==ObjectName)
		{
			UnEquipItemEvent(0);
			sHelm="";
			bHelm=true;
			return true;
		}
		if (sChest==ObjectName)
		{
			UnEquipItemEvent(1);
			sChest="";
			bChest=true;
			return true;
		}
		
		if (sLegs==ObjectName)
		{
			UnEquipItemEvent(2);
			sLegs="";
			bLegs=true;
			return true;
		}
		
		if (sBoots==ObjectName)
		{
			UnEquipItemEvent(3);
			sBoots="";
			bBoots=true;
			return true;
		}
		
		if (sGloves==ObjectName)
		{
			UnEquipItemEvent(4);
			sGloves="";
			bGloves=true;
			return true;
		}
		
		if (sRightShoulder==ObjectName)
		{
			//UnEquipItemEvent(5);
			sRightShoulder="";
			bRightShoulder=true;
			return true;
		}
		
		if (sLeftShoulder==ObjectName)
		{
			//UnEquipItemEvent(6);
			sLeftShoulder="";
			bLeftShoulder=true;
			return true;
		}
		
		if (sRightHand==ObjectName)
		{
			UnEquipItemEvent(7);
			sRightHand="";
			bRightHand=true;
			return true;
		}
		
		if (sLeftHand==ObjectName)
		{
			UnEquipItemEvent(8);
			sLeftHand="";
			bLeftHand=true;
			return true;
		}
		
		if (sRightRing==ObjectName)
		{
			UnEquipItemEvent(9);
			sRightRing="";
			bRightRing=true;
			return true;
		}
		
		if (sLeftRing==ObjectName)
		{
			UnEquipItemEvent(10);
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
		//Try and find it in the entire inventory
		if (Container.RemoveItemFromSubContainers(playerContainer,ObjectName))
		{
			return true;
		}
		//Try and find it as a container subitem on the paperdoll slots.
		for( int i=0; i<=10;i++)
		{
			GameObject obj = GetGameObjectAtSlot(i);
			if (obj!=null)
			{
				if (obj.GetComponent<Container>()!=null)
				{
					if (Container.RemoveItemFromSubContainers(obj.GetComponent<Container>(),ObjectName))
					{
						return true;
					} 
				}
			}

		}
		return false;
	}



	public bool RemoveItemFromEquipment(string ObjectName)
	{//Remove the object from wherever it is on the characters paperdoll.
		if (sHelm==ObjectName)
		{
			UnEquipItemEvent(0);
			sHelm="";
			bHelm=true;
			return true;
		}
		if (sChest==ObjectName)
		{
			UnEquipItemEvent(1);
			sChest="";
			bChest=true;
			return true;
		}

		if (sLegs==ObjectName)
		{
			UnEquipItemEvent(2);
			sLegs="";
			bLegs=true;
			return true;
		}

		if (sBoots==ObjectName)
		{
			UnEquipItemEvent(3);
			sBoots="";
			bBoots=true;
			return true;
		}

		if (sGloves==ObjectName)
		{
			UnEquipItemEvent(4);
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
			UnEquipItemEvent(7);
			sRightHand="";
			bRightHand=true;
			return true;
		}
		
		if (sLeftHand==ObjectName)
		{
			UnEquipItemEvent(8);
			sLeftHand="";
			bLeftHand=true;
			return true;
		}

		if (sRightRing==ObjectName)
		{
			UnEquipItemEvent(9);
			sRightRing="";
			bRightRing=true;
			return true;
		}
		
		if (sLeftRing==ObjectName)
		{
			UnEquipItemEvent(10);
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

		public ObjectInteraction GetObjIntInHand()
		{
				if (ObjectInHand!="")
				{
						GameObject obj = GetGameObjectInHand();
						if (obj!=null)
						{
							return obj.GetComponent<ObjectInteraction>();
						}
				}
				return null;
		}

	//public void SetObjectInHand(GameObject obj)
	//{
	//	ObjectInHand=obj.name;
	//}

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

	public void PutItemAwayEvent(short slotNo)
	{
		GameObject obj = GetGameObjectAtSlot(slotNo);
		if (obj !=null)
		{
			ObjectInteraction objInt = obj.GetComponent<ObjectInteraction>();
			if (objInt!=null)
			{
				objInt.PutItemAway(slotNo);
			}
		}	
	}

	public void EquipItemEvent(short slotNo)
	{//This must be called after the item is finally set.
		GameObject obj = GetGameObjectAtSlot(slotNo);
		if (obj !=null)
		{
			ObjectInteraction objInt = obj.GetComponent<ObjectInteraction>();
			if (objInt!=null)
			{
				objInt.Equip(slotNo);
			}
		}
	}

	public void UnEquipItemEvent(short slotNo)
	{//This must be called before the item is finally removed.
		GameObject obj = GetGameObjectAtSlot(slotNo);
		if (obj !=null)
		{
			ObjectInteraction objInt = obj.GetComponent<ObjectInteraction>();
			if (objInt!=null)
			{
				objInt.UnEquip(slotNo);
			}
		}
	}

	public float getInventoryWeight()
	{
		float answer=0.0f;
		//Get the weight of all the equipment slots
		for (int i=0;i<=10;i++)
		{
			GameObject objItem = GetGameObjectAtSlot(i);
			if (objItem!=null)
			{
				answer+=objItem.GetComponent<ObjectInteraction>().GetWeight();
			}
		}

		//Get the weight of the gronk container as that is alway the top level of the inventory
		for (short i = 0; i<=playerContainer.MaxCapacity();i++)
		{
			GameObject objItem = playerContainer.GetGameObjectAt(i); //GameObject.Find (playerContainer.GetItemAt(i));
			if (objItem!=null)
			{
				answer+=objItem.GetComponent<ObjectInteraction>().GetWeight();
			}
			else
			{
				answer+=0;
			}
		}
		return answer;
	}



	public float getEncumberance()
	{//What remaining weight the player can carry.

		float InventoryWeight=getInventoryWeight();
		float CarryWeight = playerUW.PlayerSkills.STR*2.0f;
		return CarryWeight-InventoryWeight;
	}


	public ObjectInteraction findObjInteractionByID(int item_id)
	{//Returns the first instance of a particular Item id in the players inventory
		for( int i=0; i<=10;i++)
		{//Search the paperdoll slots first.
			GameObject obj = GetGameObjectAtSlot(i);
			if (obj!=null)
			{
				ObjectInteraction objInt = obj.GetComponent<ObjectInteraction>();
				if (objInt!=null)
				{
					if (objInt.item_id== item_id)
					{
						return objInt;
					}
					else
					{
						if (objInt.GetItemType()==ObjectInteraction.CONTAINER)
						{
							string find2=obj.GetComponent<Container>().findItemOfType(item_id);
							if (find2!="")
							{
								GameObject obj2 = GameObject.Find (find2);
								ObjectInteraction objInt2 = obj2.GetComponent<ObjectInteraction>();
								if (objInt2!=null)
								{
									if (objInt2.item_id== item_id)
									{
										return objInt2;
									}
								}
							}
						}
					}
				}
			}
		}
		//playerUW.GetComponent<Container>();
		string find=playerContainer.findItemOfType(item_id);
		if (find!="")
		{
			GameObject obj = GameObject.Find (find);
			ObjectInteraction objInt = obj.GetComponent<ObjectInteraction>();
			if (objInt!=null)
			{
				if (objInt.item_id== item_id)
				{
					return objInt;
				}
			}
		}
		return null;
	}

		/// <summary>
		/// Gets the armour score of all equiped armour
		/// </summary>
		/// <returns>The armour score.</returns>
		public short getArmourScore()
		{
			//Get helm defence
			short result = 0;

			result += getDefenceAtSlot(0);
			result += getDefenceAtSlot(1);
			result += getDefenceAtSlot(2);
			result += getDefenceAtSlot(3);
			result += getDefenceAtSlot(4);	
			return result;
		}

		/// <summary>
		/// Gets the armour score of all equiped armour
		/// </summary>
		/// <returns>The armour score.</returns>
		public short getArmourDurability()
		{
				//Get helm defence
				short result = 0;

				result += getDefenceAtSlot(0);
				result += getDefenceAtSlot(1);
				result += getDefenceAtSlot(2);
				result += getDefenceAtSlot(3);
				result += getDefenceAtSlot(4);	
				return result;
		}

		/// <summary>
		/// Applies the armour damage to the players armour (random piece)
		/// If no piece is in the slot picked then no damage is applied
		/// </summary>
		public void ApplyArmourDamage(short armourDamage)
		{
			int[] slots={0,1,2,3,4,7,8};
			int PieceToDamage= slots[Random.Range(0,slots.GetUpperBound(0))];
				PieceToDamage=2;//test
			GameObject obj=	GetGameObjectAtSlot(PieceToDamage);
			if (obj!=null)
			{
				switch (PieceToDamage)
				{
				case 0://Helm								
				case 1://Chest								
				case 2://Leggings								
				case 3://Boots								
				case 4://Gloves	
					if (obj.gameObject.GetComponent<Armour>()!=null)
					{
						short durability = obj.gameObject.GetComponent<Armour>().getDurability();				
						obj.gameObject.GetComponent<Armour>().SelfDamage((short)(Mathf.Max(0, armourDamage-durability)));
						if (obj.gameObject.GetComponent<ObjectInteraction>().quality<=0)
						{
							playerUW.playerInventory.ClearSlot((short)PieceToDamage);
							obj.transform.parent=GameWorldController.instance.LevelMarker().transform;
							obj.transform.position=playerUW.transform.position;
							GameWorldController.MoveToWorld(obj.GetComponent<ObjectInteraction>());
							GameWorldController.UnFreezeMovement(obj);
							playerUW.playerInventory.Refresh();
						}
					}
					break;
				case 7://HandRight
						if (! GameWorldController.instance.playerUW.isLefty)
						{								
							if (obj.gameObject.GetComponent<Shield>()!=null)
							{
								short durability = obj.gameObject.GetComponent<Shield>().getDurability();
								obj.gameObject.GetComponent<Shield>().SelfDamage((short)(Mathf.Max(0, armourDamage-durability)));	
								if (obj.gameObject.GetComponent<ObjectInteraction>().quality<=0)
								{														
									playerUW.playerInventory.Refresh();
								}
							}
						}
						break;
				case 8://HandLeft
					if ( GameWorldController.instance.playerUW.isLefty)
					{
						if (obj.gameObject.GetComponent<Shield>()!=null)
						{
							obj.gameObject.GetComponent<Shield>().SelfDamage(armourDamage);	
							if (obj.gameObject.GetComponent<ObjectInteraction>().quality<=0)
							{
								playerUW.playerInventory.Refresh();
							}
						}
					}
					break;
				}
			}
		}


		short getDefenceAtSlot(int slot)
		{

				GameObject obj=	GetGameObjectAtSlot(slot);
				if (obj!=null)
				{
					//ObjectInteraction objInt = obj.GetComponent<ObjectInteraction>();
					switch (slot)
					{
					case 0://Helm								
					case 1://Chest								
					case 2://Leggings								
					case 3://Boots								
					case 4://Gloves		
							if (obj.gameObject.GetComponent<Armour>()!=null)
							{
								return obj.gameObject.GetComponent<Armour>().getDefence();	
							}
							break;
					case 5://rings
							{
								if (obj.gameObject.GetComponent<Ring>()!=null)
								{
									return obj.gameObject.GetComponent<Ring>().getDefence();	
								}	
								break;
							}
					case 7://HandRight
							if (GameWorldController.instance.playerUW.isLefty)
							{
									return 0;
							}
							else
							{
								if (obj.gameObject.GetComponent<Shield>()!=null)
								{
									return obj.gameObject.GetComponent<Shield>().getDefence();	
								}
							}
							break;
					case 8://HandLeft
							if ( ! GameWorldController.instance.playerUW.isLefty)
							{
								return 0;
							}
							else
							{
								if (obj.gameObject.GetComponent<Shield>()!=null)
								{
									return obj.gameObject.GetComponent<Shield>().getDefence();	
								}
							}
							break;
						}
				}

				return 0;
		}
}
