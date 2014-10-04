using UnityEngine;
using System.Collections;

public class PlayerInventory : MonoBehaviour {

	private GameObject Helm;
	private GameObject Chest;
	private GameObject Legs;
	private GameObject Boots;
	private GameObject Gloves;
	private GameObject LeftHand;
	private GameObject RightHand;
	private GameObject LeftRing;
	private GameObject RightRing;
	private GameObject LeftShoulder;
	private GameObject RightShoulder;
	private GameObject[] BackPack= new GameObject[8];

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

	private bool bHelm=true;
	private bool bChest=true;
	private bool bLegs=true;
	private bool bBoots=true;
	private bool bGloves=true;
	private bool bLeftHand=true;
	private bool bRightHand=true;
	private bool bLeftRing=true;
	private bool bRightRing=true;
	private bool bLeftShoulder=true;
	private bool bRightShoulder=true;
	private bool[] bBackPack= new bool[8];


	public UISprite Helm_f_Slot;
	public UISprite Chest_f_Slot;
	public UISprite Legs_f_Slot;
	public UISprite Boots_f_Slot;
	public UISprite Gloves_f_Slot;
	public UISprite Helm_m_Slot;
	public UISprite Chest_m_Slot;
	public UISprite Legs_m_Slot;
	public UISprite Boots_m_Slot;
	public UISprite Gloves_m_Slot;
	public UISprite LeftHand_Slot;
	public UISprite RightHand_Slot;
	public UISprite LeftRing_Slot;
	public UISprite RightRing_Slot;
	public UISprite LeftShoulder_Slot;
	public UISprite RightShoulder_Slot;
	public UISprite[] BackPack_Slot=new UISprite[8];


	private UWCharacter playerUW;
	// Use this for initialization
	void Start () {
		playerUW=GameObject.Find ("Gronk").GetComponent<UWCharacter>();
		for (int i =0;i<8;i++)
		{
			bBackPack[i]=true;
		}
	}
	
	// Update is called once per frame
	void Update () {
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
	}

	void DisplayGameObject(string objName, UISprite Label, bool isEquipped, ref bool hasChanged)
	{
		if (hasChanged==true)
		{
			GameObject objToDisplay=GameObject.Find (objName);
			hasChanged=false;
			if (objToDisplay != null)
			{
				if (isEquipped==true)
				{
					Label.spriteName= objToDisplay.GetComponent<ObjectInteraction>().InventoryIconEquipString;
				}
				else
				{
					Label.spriteName= objToDisplay.GetComponent<ObjectInteraction>().InventoryString;
				}
			}
			else
			{
				Label.spriteName="object_blank";
			}
		}

	}

	public string ObjectPickedUp(int slotIndex, string sObjectInHand)
	{//Returns the game object of the object already in the slot
		string ExistingObject="";
		//Debug.Log ("looking for object " + sObjectInHand);
		//GameObject ObjectInHand = GameObject.Find (sObjectInHand);
		//if(ObjectInHand!=null)
		//{Debug.Log (ObjectInHand.name);
			//Debug.Log ("Object found");
			switch (slotIndex)
			{
			case 0://Helm
				bHelm=true;
				ExistingObject=sHelm;
				sHelm=sObjectInHand;
				break;
			case 1://Chest
				bChest=true;
				ExistingObject=sChest;
				sChest=sObjectInHand;
				break;
			case 2://Leggings
				bLegs=true;
				ExistingObject=sLegs;
				sLegs=sObjectInHand;
				break;
			case 3://Boots
				bBoots=true;
				ExistingObject=sBoots;
				sBoots=sObjectInHand;
				break;
			case 4://Gloves
				bGloves=true;
				ExistingObject=sGloves;
				sGloves=sObjectInHand;
				break;
			case 5://ShoulderRight
				bRightShoulder=true;
				ExistingObject=sRightShoulder;
				sRightShoulder=sObjectInHand;
				break;
			case 6://ShoulderLeft
				bLeftShoulder=true;
				ExistingObject=sLeftShoulder;
				sLeftShoulder=sObjectInHand;
				break;
			case 7://HandRight
				bRightHand=true;
				ExistingObject=sRightHand;
				sRightHand=sObjectInHand;
				break;
			case 8://HandLeft
				bLeftHand=true;
				ExistingObject=sLeftHand;
				sLeftHand=sObjectInHand;
				break;
			case 9://RingRight
				bRightRing=true;
				ExistingObject=sRightRing;
				sRightRing=sObjectInHand;
				break;
			case 10://RingLeft
				bLeftRing=true;
				ExistingObject=sLeftRing;
				sLeftRing=sObjectInHand;
				break;
			default://Inventory Slots 0-7		
				if ((slotIndex>=11)&&(slotIndex<=18))
				{
					bBackPack[slotIndex-11]=true;
					ExistingObject=sBackPack[slotIndex-11];
					sBackPack[slotIndex-11]=sObjectInHand;
				}
				break;
			}
	//	}

		return ExistingObject;

	}
}
