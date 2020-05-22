using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerInventory : UWEBase
{
    /// <summary>
    /// What is the current active object held by the player
    /// </summary>
    private ObjectInteraction _ObjectInHand;
    public ObjectInteraction ObjectInHand
    {
        get
        {
            return _ObjectInHand;
        }
        set
        {
            _ObjectInHand = value;
            if (_ObjectInHand == null)
            {
                UWHUD.instance.CursorIcon = UWHUD.instance.CursorIconDefault;
            }
            else
            {
                _ObjectInHand.UpdateAnimation();
                UWHUD.instance.CursorIcon = _ObjectInHand.GetInventoryDisplay().texture;
            }
        }
    }
    
    public bool JustPickedup; //Has the player just picked something up.
                             
    public ObjectInteraction _sHelm;
    public ObjectInteraction sHelm
        {
            get
            {
                return _sHelm;
            }
            set
            {
                _sHelm = value;
                if (playerUW.isFemale == true)
                {
                    DisplayGameObject(_sHelm, UWHUD.instance.Helm_f_Slot, null, true);
                }
                else
                {
                    DisplayGameObject(_sHelm, UWHUD.instance.Helm_m_Slot, null, true);
                }                
            }
        }

    public ObjectInteraction _sChest;
    public ObjectInteraction sChest
    {
        get
        {
            return _sChest;
        }
        set
        {
            _sChest = value;
            if (playerUW.isFemale == true)
            {
                DisplayGameObject(_sChest, UWHUD.instance.Chest_f_Slot, null, true);
            }
            else
            {
                DisplayGameObject(_sChest, UWHUD.instance.Chest_m_Slot, null, true);
            }
        }
    }


    public ObjectInteraction _sLegs;
    public ObjectInteraction sLegs
    {
        get
        {
            return _sLegs;
        }
        set
        {
            _sLegs = value;
            if (playerUW.isFemale == true)
            {
                DisplayGameObject(_sLegs, UWHUD.instance.Legs_f_Slot, null, true);
            }
            else
            {
                DisplayGameObject(_sLegs, UWHUD.instance.Legs_m_Slot, null, true);
            }
        }
    }

    public ObjectInteraction _sBoots;
    public ObjectInteraction sBoots
    {
        get
        {
            return _sBoots;
        }
        set
        {
            _sBoots = value;
            if (playerUW.isFemale == true)
            {
                DisplayGameObject(_sBoots, UWHUD.instance.Boots_f_Slot, null, true);
            }
            else
            {
                DisplayGameObject(_sBoots, UWHUD.instance.Boots_m_Slot, null, true);
            }
        }
    }

    public ObjectInteraction _sGloves;
    public ObjectInteraction sGloves
    {
            get
            {
                return _sGloves;
            }
            set
            {
                _sHelm = value;
                if (playerUW.isFemale == true)
                {
                    DisplayGameObject(_sHelm, UWHUD.instance.Gloves_f_Slot, null, true);
                }
                else
                {
                    DisplayGameObject(_sHelm, UWHUD.instance.Gloves_m_Slot, null, true);
                }
            }
    }

    public ObjectInteraction _sLeftHand;
    public ObjectInteraction sLeftHand
    {
        get
        {
            return _sLeftHand;
        }
        set
        {
            _sLeftHand = value;
            DisplayGameObject(_sLeftHand, UWHUD.instance.LeftHand_Slot, UWHUD.instance.LeftHand_Qty, false);
        }
    }

    public ObjectInteraction _sRightHand;
    public ObjectInteraction sRightHand
    {
        get
            {
                return _sRightHand;
            }
        set
        {
            _sRightHand = value;
            DisplayGameObject(_sRightHand, UWHUD.instance.RightHand_Slot, UWHUD.instance.RightHand_Qty, false);
        }
    }

    public ObjectInteraction _sLeftRing;
    public ObjectInteraction sLeftRing
    {
        get
        {
            return _sLeftRing;
        }
        set
        {
            _sLeftRing = value;
            DisplayGameObject(_sLeftRing, UWHUD.instance.LeftRing_Slot, null, false);
        }
    }

    public ObjectInteraction _sRightRing;
    public ObjectInteraction sRightRing
    {
        get
        {
            return _sRightRing;
        }
        set
        {
            _sRightRing = value;
            DisplayGameObject(_sRightRing, UWHUD.instance.RightRing_Slot, null, false);
        }
    }

    public ObjectInteraction _sLeftShoulder;
    public ObjectInteraction sLeftShoulder
    {
        get
        {
            return _sLeftShoulder;
        }
        set
        {
            _sLeftShoulder = value;
            DisplayGameObject(_sLeftShoulder, UWHUD.instance.LeftShoulder_Slot, UWHUD.instance.LeftShoulder_Qty, false);
        }
    }

    public ObjectInteraction _sRightShoulder;
    public ObjectInteraction sRightShoulder
    {
        get
        {
            return _sRightShoulder;
        }
        set
        {
            _sRightShoulder = value;
            DisplayGameObject(_sRightShoulder, UWHUD.instance.RightShoulder_Slot, UWHUD.instance.RightShoulder_Qty, false);
        }
    }

    public ObjectInteraction[] _sBackPack = new ObjectInteraction[8];
        
    public void setBackPack(int index, ObjectInteraction value)
    {
        _sBackPack[index] = value;
        DisplayGameObject(_sBackPack[index], UWHUD.instance.BackPack_Slot[index], UWHUD.instance.Backpack_Slot_Qty[index], false);
    }

    public ObjectInteraction getBackPack(int index)
    {
        return _sBackPack[index];
    }

    //Force Redraw on next update.
    /*public bool bHelm = true;
     public bool bChest = true;
     public bool bLegs = true;
     public bool bBoots = true;
     public bool bGloves = true;
     public bool bLeftHand = true;
     public bool bRightHand = true;
     public bool bLeftRing = true;
     public bool bRightRing = true;
     public bool bLeftShoulder = true;
     public bool bRightShoulder = true;
     public bool[] bBackPack = new bool[8];*/


    public GameObject InventoryMarker;
    private ObjectInteraction[] LightGameObjects = new ObjectInteraction[4];

    //public bool atTopLevel;
    public Container currentContainer;
    private UWCharacter playerUW;

    public Texture2D Blank;

    //For calculating light levels
    public Light lt;
    private LightSource ls;

    public Container playerContainer;
    public short ContainerOffset = 0;//For scrolling the inventory.

    public static bool Ready;

    public void Begin()
    {
        if (_RES == GAME_SHOCK) { return; }
        GRLoader bodies = new GRLoader(GRLoader.BODIES_GR);
        Blank = Resources.Load<Texture2D>(_RES + "/Sprites/Texture_Blank");
        //atTopLevel=true;
        playerUW = this.GetComponent<UWCharacter>();
        playerContainer = this.GetComponent<Container>();
        for (int i = 0; i < 8; i++)
        {
            //bBackPack[i] = true;
            setBackPack(i, null);
        }
        UWHUD.instance.Encumberance.text = getEncumberance().ToString();
        if (playerUW.isFemale)
        {
            //UWHUD.instance.playerBody.texture =(Texture2D)Resources.Load(_RES +"/Hud/Bodies/bodies_" + (5+playerUW.Body).ToString("0000"));		
            UWHUD.instance.playerBody.texture = bodies.LoadImageAt(5 + playerUW.Body);
        }
        else
        {
            //UWHUD.instance.playerBody.texture =(Texture2D)Resources.Load(_RES +"/Hud/Bodies/bodies_" + (playerUW.Body).ToString("0000"));		
            UWHUD.instance.playerBody.texture = bodies.LoadImageAt(playerUW.Body);
        }

        Ready = true;
        Refresh();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Ready) { return; }
        switch (_RES)
        {
            case GAME_SHOCK:
                {
                    UpdateShock();
                    break;
                }
            default:
                {
                    //UpdateUW();
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
        /*
        if (playerUW.isFemale == true)
        {//female
            DisplayGameObject(sHelm, UWHUD.instance.Helm_f_Slot, null, true, ref bHelm);
            DisplayGameObject(sChest, UWHUD.instance.Chest_f_Slot, null, true, ref bChest);
            DisplayGameObject(sLegs, UWHUD.instance.Legs_f_Slot, null, true, ref bLegs);
            DisplayGameObject(sBoots, UWHUD.instance.Boots_f_Slot, null, true, ref bBoots);
            DisplayGameObject(sGloves, UWHUD.instance.Gloves_f_Slot, null, true, ref bGloves);
        }
        else
        {//male
            DisplayGameObject(sHelm, UWHUD.instance.Helm_m_Slot, null, true, ref bHelm);
            DisplayGameObject(sChest, UWHUD.instance.Chest_m_Slot, null, true, ref bChest);
            DisplayGameObject(sLegs, UWHUD.instance.Legs_m_Slot, null, true, ref bLegs);
            DisplayGameObject(sBoots, UWHUD.instance.Boots_m_Slot, null, true, ref bBoots);
            DisplayGameObject(sGloves, UWHUD.instance.Gloves_m_Slot, null, true, ref bGloves);
        }

        DisplayGameObject(sLeftShoulder, UWHUD.instance.LeftShoulder_Slot, UWHUD.instance.LeftShoulder_Qty, false, ref bLeftShoulder);
        DisplayGameObject(sRightShoulder, UWHUD.instance.RightShoulder_Slot, UWHUD.instance.RightShoulder_Qty, false, ref bRightShoulder);
        DisplayGameObject(sLeftRing, UWHUD.instance.LeftRing_Slot, null, false, ref bLeftRing);
        DisplayGameObject(sRightRing, UWHUD.instance.RightRing_Slot, null, false, ref bRightRing);

        DisplayGameObject(sLeftHand, UWHUD.instance.LeftHand_Slot, UWHUD.instance.LeftHand_Qty, false, ref bLeftHand);
        DisplayGameObject(sRightHand, UWHUD.instance.RightHand_Slot, UWHUD.instance.RightHand_Qty, false, ref bRightHand);

        for (int i = 0; i < 8; i++)
        {
            DisplayGameObject(sBackPack[i], UWHUD.instance.BackPack_Slot[i], UWHUD.instance.Backpack_Slot_Qty[i], false, ref bBackPack[i]);
        }
        return;
        */
    }

    /// <summary>
    /// Checks the light sources equiped by the player and makes sure the brightest one is in use
    /// </summary>
    public void UpdateLightSources()
    {
        //Check for lights
        if (lt == null)
        {
            lt = this.gameObject.GetComponentInChildren<Light>();
        }
        ls = null;
        float MaxBrightness = LightSource.MagicBrightness;
        //Start with magically generated light.
        for (int i = 5; i <= 8; i++)
        {
            ls = null;
            //Update the gameobject at the slot if needed
            if (LightGameObjects[i - 5] != null)
            {
                if (GetObjectAtSlot(i) != LightGameObjects[i - 5])
                {
                    LightGameObjects[i - 5] = GetObjectIntAtSlot(i);
                }
            }
            else
            {
                //No object
                if (GetObjectAtSlot(i) != null)
                {
                    LightGameObjects[i - 5] = GetObjectIntAtSlot(i);
                }
            }
            if (GetObjectAtSlot(i) != null)
            {
                if (LightGameObjects[i - 5] != null)
                {
                    ls = LightGameObjects[i - 5].GetComponent<LightSource>();
                    if (ls != null)
                    {
                        if (ls.IsOn() == true)
                        {
                            if (MaxBrightness < ls.Brightness())
                            {
                                MaxBrightness = ls.Brightness();
                            }
                        }
                    }
                }
            }
        }
        lt.range = LightSource.BaseBrightness + MaxBrightness;
        if (MaxBrightness > 0)
        {
            playerUW.LightActive = true;
        }
        else
        {
            playerUW.LightActive = false;
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

    void DisplayGameObject(ObjectInteraction obj, RawImage Label, Text qtyDisplay, bool isEquipped)
    {
        if (obj == null)
        {
            Label.texture = Blank;
            if (qtyDisplay != null)
            {
                qtyDisplay.text = "";
            }
            return;
        }
        if (obj != null)
        {
            if (isEquipped == true)
            {
                Label.texture = obj.GetEquipDisplay().texture;
            }
            else
            {
                Label.texture = obj.GetInventoryDisplay().texture;
                if (qtyDisplay != null)
                {
                    int qty = obj.GetQty();
                    if (qty <= 1)
                    {
                        qtyDisplay.text = "";
                    }
                    else
                    {
                        qtyDisplay.text = qty.ToString();
                    }
                }
            }
        }
        else
        {
            Label.texture = Blank;
            if (qtyDisplay != null)
            {
                qtyDisplay.text = "";
            }
        }
    }



    void DisplayGameObject(ObjectInteraction obj, RawImage Label, Text qtyDisplay, bool isEquipped, ref bool hasChanged)
    {
        if (hasChanged == true)
        {
            if (obj == null)
            {
                Label.texture = Blank;
                if (qtyDisplay != null)
                {
                    qtyDisplay.text = "";
                }
                hasChanged = false;
                return;
            }
            hasChanged = false;
            if (obj != null)
            {
                if (isEquipped == true)
                {
                    Label.texture = obj.GetEquipDisplay().texture;
                }
                else
                {
                    Label.texture = obj.GetInventoryDisplay().texture;
                    if (qtyDisplay != null)
                    {
                        int qty = obj.GetQty();
                        if (qty <= 1)
                        {
                            qtyDisplay.text = "";
                        }
                        else
                        {
                            qtyDisplay.text = qty.ToString();
                        }
                    }
                }
            }
            else
            {
                Label.texture = Blank;
                if (qtyDisplay != null)
                {
                    qtyDisplay.text = "";
                }
            }
        }
    }

    public bool GetObjectDescAtSlot(int SlotIndex)
    {
        //string objectName = GetObjectAtSlot(SlotIndex);
        ObjectInteraction objInt = GetObjectAtSlot(SlotIndex);
       // if (objectName != "")
        //{
            //ObjectInteraction objInt = GameObject.Find(objectName).GetComponent<ObjectInteraction>();
            if (objInt != null)
            {
                return objInt.LookDescription();
            }
            else
            {
                return false;// "DESC NOT FOUND!!";
            }
      //  }
        //else
        //{
        //    return false; //"DESC NOT FOUND!!";
       // }
    }

    public ObjectInteraction GetObjectIntAtSlot(int slotIndex)
    {
        return GetObjectAtSlot(slotIndex);
        //string objname = GetObjectAtSlot(slotIndex);
       // GameObject obj= GameObject.Find(objname);
       // if (obj!=null)
       // {
       //     return obj.GetComponent<ObjectInteraction>();
       // }
        //return null;
    }

    //public GameObject GetGameObjectAtSlot(int slotIndex)
    //{
    //    Debug.Log("REMOVE");
    //    string objname = GetObjectAtSlot(slotIndex);
    //    return GameObject.Find(objname);
    //}

    public ObjectInteraction GetObjectAtSlot(int slotIndex)
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
                if ((slotIndex >= 11) && (slotIndex <= 18))
                {
                    return getBackPack(slotIndex - 11);//sBackPack[slotIndex - 11];
                }
                else
                {
                    return null;
                }
        }
    }

    public void SetObjectAtSlot(short slotIndex, ObjectInteraction sObject)
    {
        //string sObject = "";
        //if (oObject != null) { sObject = oObject.name; };
        switch (slotIndex)
        {
            case 0://Helm
                sHelm = sObject;
                //bHelm = true;
                EquipItemEvent(slotIndex);
                break;
            case 1://Chest
                sChest = sObject;
                //bChest = true;
                EquipItemEvent(slotIndex);
                break;
            case 2://Leggings
                sLegs = sObject;
                //bLegs = true;
                EquipItemEvent(slotIndex);
                break;
            case 3://Boots
                sBoots = sObject;
                //bBoots = true;
                EquipItemEvent(slotIndex);
                break;
            case 4://Gloves
                sGloves = sObject;
               // bGloves = true;
                EquipItemEvent(slotIndex);
                break;
            case 5://ShoulderRight
                sRightShoulder = sObject;
                //bRightShoulder = true;
                break;
            case 6://ShoulderLeft
                sLeftShoulder = sObject;
                //bLeftShoulder = true;
                break;
            case 7://HandRight
                sRightHand = sObject;
                //bRightHand = true;
                EquipItemEvent(slotIndex);
                break;
            case 8://HandLeft
                sLeftHand = sObject;
                //bLeftHand = true;
                EquipItemEvent(slotIndex);
                break;
            case 9://RingRight
                sRightRing = sObject;
                //bRightRing = true;
                EquipItemEvent(slotIndex);
                break;
            case 10://RingLeft
                sLeftRing = sObject;
                //bLeftRing = true;
                EquipItemEvent(slotIndex);
                break;
            default://Inventory Slots 0-7		
                if ((slotIndex >= 11) && (slotIndex <= 18))
                {
                    setBackPack(slotIndex - 11, sObject);
                    //sBackPack[slotIndex - 11] = sObject;
                    //bBackPack[slotIndex - 11] = true;
                    //Container cn = GameObject.Find(currentContainer).GetComponent<Container>();
                    //cn.items[ContainerOffset + slotIndex - 11] = sObject;
                    currentContainer.items[ContainerOffset + slotIndex - 11] = sObject;
                    PutItemAwayEvent(slotIndex);
                }
                break;
        }
    }


    /// <summary>
    /// Clears the specified container slot
    /// </summary>
    /// <param name="slotIndex"></param>
    public void ClearSlot(short slotIndex)
    {
        switch (slotIndex)
        {
            case 0://Helm
                UnEquipItemEvent(slotIndex);
                sHelm = null;
               // bHelm = true;
                break;
            case 1://Chest
                UnEquipItemEvent(slotIndex);
                sChest = null;
               // bChest = true;
                break;
            case 2://Leggings
                UnEquipItemEvent(slotIndex);
                sLegs = null;
                //bLegs = true;
                break;
            case 3://Boots
                UnEquipItemEvent(slotIndex);
                sBoots = null;
                //bBoots = true;
                break;
            case 4://Gloves
                UnEquipItemEvent(slotIndex);
                sGloves = null;
               // bGloves = true;
                break;
            case 5://ShoulderRight
                sRightShoulder = null;
                //bRightShoulder = true;
                break;
            case 6://ShoulderLeft
                sLeftShoulder = null;
               // bLeftShoulder = true;
                break;
            case 7://HandRight
                UnEquipItemEvent(slotIndex);
                sRightHand = null;
                //bRightHand = true;
                break;
            case 8://HandLeft
                UnEquipItemEvent(slotIndex);
                sLeftHand = null;
               // bLeftHand = true;
                break;
            case 9://RingRight
                UnEquipItemEvent(slotIndex);
                sRightRing = null;
                //bRightRing = true;
                break;
            case 10://RingLeft
                UnEquipItemEvent(slotIndex);
                sLeftRing = null;
                //bLeftRing = true;
                break;
            default://Inventory Slots 0-7		
                if ((slotIndex >= 11) && (slotIndex <= 18))
                {
                    setBackPack(slotIndex - 11, null);
                    //sBackPack[slotIndex - 11] = null;
                   // bBackPack[slotIndex - 11] = true;
                }
                break;
        }
    }
 

    /// <summary>
    /// Force a full refresh of inventory display
    /// </summary>
    public void Refresh()
    {
        sHelm = sHelm;
        sChest = sChest;
        sLegs = sLegs;
        sBoots = sBoots;
        sGloves = sGloves;
        sRightShoulder = sRightShoulder;
        sLeftShoulder = sLeftShoulder;
        sRightHand = sRightHand;
       // sRightHand = null;
        sLeftHand = sLeftHand;
        sRightRing = sRightRing;
        sLeftRing = sLeftRing;
        for (short i = 11; i <= 18; i++)
        {
            setBackPack(i - 11, currentContainer.GetItemAt((short)(ContainerOffset + i - 11)));
        }
        if (UWHUD.instance.Encumberance.enabled == true)
        {
            UWHUD.instance.Encumberance.text = getEncumberance().ToString();
        }
        UpdateLightSources();
    }


    /// <summary>
    /// Swaps two objects with each other
    /// </summary>
    /// <param name="ObjInSlot"></param>
    /// <param name="slotIndex"></param>
    /// <param name="cObjectInHand"></param>
    public void SwapObjects(ObjectInteraction ObjInSlot, short slotIndex, ObjectInteraction cObjectInHand)
    {
        RemoveItem(ObjInSlot);
        SetObjectAtSlot(slotIndex, cObjectInHand);
        if (slotIndex >= 11)
        {
            currentContainer.AddItemToContainer(cObjectInHand, ContainerOffset + slotIndex - 11);
        }
        ObjectInHand = ObjInSlot;
        Refresh();
    }

    /// <summary>
    /// Removes item from the paperdoll and/or the player inventory.
    /// </summary>
    /// <param name="ObjectToRemove"></param>
    /// <returns></returns>
    public bool RemoveItem(ObjectInteraction ObjectToRemove)
    {
        if (sHelm == ObjectToRemove)
        {
            UnEquipItemEvent(0);
            sHelm = null;
            return true;
        }
        if (sChest == ObjectToRemove)
        {
            UnEquipItemEvent(1);
            sChest = null;
            return true;
        }

        if (sLegs == ObjectToRemove)
        {
            UnEquipItemEvent(2);
            sLegs = null;
            return true;
        }

        if (sBoots == ObjectToRemove)
        {
            UnEquipItemEvent(3);
            sBoots = null;
            return true;
        }

        if (sGloves == ObjectToRemove)
        {
            UnEquipItemEvent(4);
            sGloves = null;
            return true;
        }

        if (sRightShoulder == ObjectToRemove)
        {
            sRightShoulder = null;
            return true;
        }

        if (sLeftShoulder == ObjectToRemove)
        {
            sLeftShoulder = null;
            return true;
        }

        if (sRightHand == ObjectToRemove)
        {
            UnEquipItemEvent(7);
            sRightHand = null;
            return true;
        }

        if (sLeftHand == ObjectToRemove)
        {
            UnEquipItemEvent(8);
            sLeftHand = null;
            return true;
        }

        if (sRightRing == ObjectToRemove)
        {
            UnEquipItemEvent(9);
            sRightRing = null;
            return true;
        }

        if (sLeftRing == ObjectToRemove)
        {
            UnEquipItemEvent(10);
            sLeftRing = null;
            return true;
        }

        Container backpack = this.playerContainer;
        for (int i = 0; i < 8; i++)
        {
            if (backpack.items[i]!=null)
            {
                if (ObjectToRemove == backpack.items[i])
                {
                    backpack.items[i] = null;
                    setBackPack(i, null);
                    return true;
                }
            }
        }

        foreach (Transform child in GameWorldController.instance.InventoryMarker.transform)
        {//Remove from subcontainers if the object is still not found
            if (child.GetComponent<Container>() != null)
            {
                Container cn = child.GetComponent<Container>();
                if (cn != null)
                {
                    for (int i = 0; i <= cn.items.GetUpperBound(0); i++)
                    {
                        if (cn.items[i] == ObjectToRemove)
                        {
                            cn.items[i] = null;
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }



    public bool RemoveItemFromEquipment(ObjectInteraction ObjectToRemove)
    {//Remove the object from wherever it is on the characters paperdoll.
        if (sHelm == ObjectToRemove)
        {
            UnEquipItemEvent(0);
            sHelm = null;
            //bHelm = true;
            return true;
        }
        if (sChest == ObjectToRemove)
        {
            UnEquipItemEvent(1);
            sChest = null;
            //bChest = true;
            return true;
        }

        if (sLegs == ObjectToRemove)
        {
            UnEquipItemEvent(2);
            sLegs = null;
            //bLegs = true;
            return true;
        }

        if (sBoots == ObjectToRemove)
        {
            UnEquipItemEvent(3);
            sBoots = null;
            //bBoots = true;
            return true;
        }

        if (sGloves == ObjectToRemove)
        {
            UnEquipItemEvent(4);
            sGloves = null;
            //bGloves = true;
            return true;
        }

        if (sRightShoulder == ObjectToRemove)
        {
            sRightShoulder = null;
            //bRightShoulder = true;
            return true;
        }

        if (sLeftShoulder == ObjectToRemove)
        {
            sLeftShoulder = null;
            //bLeftShoulder = true;
            return true;
        }

        if (sRightHand == ObjectToRemove)
        {
            UnEquipItemEvent(7);
            sRightHand = null;
            //bRightHand = true;
            return true;
        }

        if (sLeftHand == ObjectToRemove)
        {
            UnEquipItemEvent(8);
            sLeftHand = null;
           // bLeftHand = true;
            return true;
        }

        if (sRightRing == ObjectToRemove)
        {
            UnEquipItemEvent(9);
            sRightRing = null;
            //bRightRing = true;
            return true;
        }

        if (sLeftRing == ObjectToRemove)
        {
            UnEquipItemEvent(10);
            sLeftRing = null;
            //bLeftRing = true;
            return true;
        }
        return false;
    }


   /* public string GetObjectInHand()
    {
        return ObjectInHand;
    }*/

   /* public GameObject GetGameObjectInHand()
    {
        if (ObjectInHand != null)
            {
            return ObjectInHand.gameObject;
        }
        else
        {
            return null;
        }
        
        //if (ObjectInHand != "")
        //{
        //    return GameObject.Find(ObjectInHand);
        //}
        //else
        //{
        //    return null;
        }

    }*/

  /*  public ObjectInteraction GetObjIntInHand()
    {
        if (ObjectInHand != "")
        {
            GameObject obj = GetGameObjectInHand();
            if (obj != null)
            {
                return obj.GetComponent<ObjectInteraction>();
            }
        }
        return null;
    }*/

    //public void SetObjectInHand(GameObject obj)
    //{
    //	ObjectInHand=obj.name;
    //}

  /*  public void SetObjectInHand(string obj)
    {
        ObjectInHand = obj;
    }*/

    //public Container GetCurrentContainer()
    //{
    //    return GameObject.Find(currentContainer).GetComponent<Container>();
    //}

    //public GameObject GetGameObject(string name)
    //{
    //    return GameObject.Find(name);
    //}

    public void PutItemAwayEvent(short slotNo)
    {
        ObjectInteraction objInt = GetObjectIntAtSlot(slotNo);
        if (objInt != null)
        {
            objInt.PutItemAway(slotNo);
        }
    }

    public void EquipItemEvent(short slotNo)
    {//This must be called after the item is finally set.
        ObjectInteraction objInt = GetObjectIntAtSlot(slotNo);
        if (objInt != null)
        {
            objInt.Equip(slotNo);
        }
    }

    public void UnEquipItemEvent(short slotNo)
    {//This must be called before the item is finally removed.
        ObjectInteraction objInt = GetObjectIntAtSlot(slotNo);
        if (objInt != null)
        {
            objInt.UnEquip(slotNo);
        }
    }

    public float getInventoryWeight()
    {
        float answer = 0.0f;
        //Get the weight of all the equipment slots
        for (int i = 0; i <= 10; i++)
        {
            ObjectInteraction objItem = GetObjectIntAtSlot(i);
            if (objItem != null)
            {
                answer += objItem.GetWeight();
            }
        }

        //Get the weight of the gronk container as that is alway the top level of the inventory
        for (short i = 0; i <= playerContainer.MaxCapacity(); i++)
        {
            ObjectInteraction objItem = playerContainer.GetItemAt(i); //GameObject.Find (playerContainer.GetItemAt(i));
            if (objItem != null)
            {
                answer += objItem.GetWeight();
            }
            else
            {
                answer += 0;
            }
        }
        return answer;
    }


    /// <summary>
    /// What remaining weight the player can carry.
    /// </summary>
    /// <returns></returns>
    public float getEncumberance()
    {

        float InventoryWeight = getInventoryWeight();
        float CarryWeight = 0f;
        switch (_RES)
        {
            case GAME_UW2:
                //IN UW2 Weight is calcuated based on the a base carry weight of 300  + str * 13. In units of 0.1 stones
                CarryWeight = (300f + (playerUW.PlayerSkills.STR * 13f)) * 0.1f;//estimate
                break;
            default:
                CarryWeight = playerUW.PlayerSkills.STR * 2.0f;
                break;
        }

        return CarryWeight - InventoryWeight;
    }


    /// <summary>
    /// Returns the first instance of a particular Item id in the players inventory
    /// </summary>
    /// <param name="item_id">Item ID to find</param>
    /// <returns></returns>
    public ObjectInteraction findObjInteractionByID(int item_id)
    {
        for (int i = 0; i <= 10; i++)
        {//Search the paperdoll slots first.
            ObjectInteraction objInt = GetObjectIntAtSlot(i);
            //ObjectInteraction objInt = obj.GetComponent<ObjectInteraction>();
            if (objInt != null)
            {
                if (objInt.item_id == item_id)
                {
                    return objInt;
                }
                else
                {
                    if (objInt.GetItemType() == ObjectInteraction.CONTAINER)
                    {
                        ObjectInteraction find2 = objInt.GetComponent<Container>().findItemOfType(item_id);
                        if (find2 != null)
                        {
                            if (find2.item_id == item_id)
                            {
                                return find2;
                            }
                        }
                    }
                }
            }

        }
        //playerUW.GetComponent<Container>();
        ObjectInteraction find = playerContainer.findItemOfType(item_id);
        if (find != null)
        {
            //GameObject obj = GameObject.Find(find);
           // ObjectInteraction objInt = obj.GetComponent<ObjectInteraction>();
            //if (objInt != null)
           // {
                if (find.item_id == item_id)
                {
                    return find;
                }
            //}
        }
        return null;
    }

    /// <summary>
    /// Gets the armour score of all equiped armour plus the players toughness bonus
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
        return (short)(result + UWCharacter.Instance.Resistance);
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
        int[] slots = { 0, 1, 2, 3, 4, 7, 8 };
        int PieceToDamage = slots[Random.Range(0, slots.GetUpperBound(0))];
        PieceToDamage = 2;//test
        ObjectInteraction obj = GetObjectIntAtSlot(PieceToDamage);
        if (obj != null)
        {
            switch (PieceToDamage)
            {
                case 0://Helm								
                case 1://Chest								
                case 2://Leggings								
                case 3://Boots								
                case 4://Gloves	
                    if (obj.GetComponent<Armour>() != null)
                    {
                        short durability = obj.GetComponent<Armour>().getDurability();
                        if (durability <= 30)
                        {
                            obj.GetComponent<Armour>().SelfDamage((short)(Mathf.Max(0, armourDamage - durability)));
                            if (obj.quality <= 0)
                            {
                                playerUW.playerInventory.ClearSlot((short)PieceToDamage);
                                obj.transform.parent = GameWorldController.instance.DynamicObjectMarker().transform;
                                obj.transform.position = playerUW.transform.position;
                                GameWorldController.MoveToWorld(obj);
                                UnFreezeMovement(obj);
                                playerUW.playerInventory.Refresh();
                            }
                        }
                    }
                    break;
                case 7://HandRight
                    if (!UWCharacter.Instance.isLefty)
                    {
                        if (obj.gameObject.GetComponent<Shield>() != null)
                        {
                            short durability = obj.GetComponent<Shield>().getDurability();
                            if (durability <= 30)
                            {
                                obj.GetComponent<Shield>().SelfDamage((short)(Mathf.Max(0, armourDamage - durability)));
                                if (obj.quality <= 0)
                                {
                                    playerUW.playerInventory.Refresh();
                                }
                            }
                        }
                    }
                    break;
                case 8://HandLeft
                    if (UWCharacter.Instance.isLefty)
                    {
                        if (obj.gameObject.GetComponent<Shield>() != null)
                        {
                            short durability = obj.GetComponent<Shield>().getDurability();
                            if (durability <= 30)
                            {
                                obj.GetComponent<Shield>().SelfDamage((short)(Mathf.Max(0, armourDamage - durability)));
                                if (obj.quality <= 0)
                                {
                                    playerUW.playerInventory.Refresh();
                                }
                            }
                        }
                    }
                    break;
            }
        }
    }


    short getDefenceAtSlot(int slot)
    {
        ObjectInteraction obj = GetObjectIntAtSlot(slot);
        if (obj != null)
        {
            switch (slot)
            {
                case 0://Helm								
                case 1://Chest								
                case 2://Leggings								
                case 3://Boots								
                case 4://Gloves		
                    if (obj.GetComponent<Armour>() != null)
                    {
                        return obj.GetComponent<Armour>().getDefence();
                    }
                    break;
                case 5://rings
                    {
                        if (obj.GetComponent<Ring>() != null)
                        {
                            return obj.GetComponent<Ring>().getDefence();
                        }
                        break;
                    }
                case 7://HandRight
                    if (UWCharacter.Instance.isLefty)
                    {
                        return 0;
                    }
                    else
                    {
                        if (obj.GetComponent<Shield>() != null)
                        {
                            return obj.GetComponent<Shield>().getDefence();
                        }
                    }
                    break;
                case 8://HandLeft
                    if (!UWCharacter.Instance.isLefty)
                    {
                        return 0;
                    }
                    else
                    {
                        if (obj.GetComponent<Shield>() != null)
                        {
                            return obj.GetComponent<Shield>().getDefence();
                        }
                    }
                    break;
            }
        }

        return 0;
    }
}
