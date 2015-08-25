using UnityEngine;
using System.Collections;

public class InventorySlot : MonoBehaviour {

	private UILabel MessageLog;
	private UISprite slot;
	//public int InteractionMode;
	public static GameObject player;
	public static UWCharacter playerUW;
	//public static GameObject currInventorySlot;
	//public GameObject ObjectInSlot;
	public string ObjectSpriteString;
	public Texture2D ObjectSprite;
	private PlayerInventory pInv;
	public GameObject GronkSlot;
	public int slotIndex;//What type of inventory slot is this

	// Use this for initialization
	void Start () {
		MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
//		slot = GetComponent<UISprite>();

	}
	
	// Update is called once per frame
	//void Update () {
		//if (playerUW==null)
		//{
		//	playerUW=player.GetComponent<UWCharacter>();
		//}
	//}



	//void OnMouseEnter()
	//{
	//	MessageLog.text=name +"entered";
	//}
	
	//void OnTriggerEnter()
	//{
	//	//counter++;
	//	MessageLog.text=name +"triggered";
	//}
	
//	void OnHover( bool isOver )
//	{
//		if( isOver )
//		{
//			InventorySlot.currInventorySlot=this.gameObject;
//		//	playerUW.currInventorySlot=this.gameObject;
//			//MessageLog.text=name + "Hovered over";
//		}
//		else
//		{
//			InventorySlot.currInventorySlot=null;
//			//playerUW.currInventorySlot=null;
//			//MessageLog.text=name + "Hovered out";
//		}
//	}

	void PickupFromSlot()
	{
		Debug.Log ("PickupfromSlot");
		pInv = player.GetComponent<PlayerInventory>();
		Container SubContainer;
		string sNewObj;
		
		if (pInv.currentContainer=="Gronk")
		{
			sNewObj= pInv.ObjectPickedUp(slotIndex,pInv.ObjectInHand);
		}
		else
		{
			string slotToTest= pInv.GetObjectAtSlot(slotIndex) ;
			if (slotToTest!="")
			{
				Debug.Log ("Testing slot (" + slotIndex + ")" + slotToTest );
				
				if (GameObject.Find (slotToTest).GetComponent<ObjectInteraction>().isContainer==true)
				{
					//test if object is already open in inventory;
					if (GameObject.Find (slotToTest).GetComponent<Container>().isOpenOnPanel==true)
					{
						Debug.Log ("Attempt to to pick up an already open container at " + slotToTest);
						return;
					}
				}
			}
			
			SubContainer = GameObject.Find (pInv.currentContainer).GetComponent<Container>();
			sNewObj = SubContainer.ObjectPickedUp (slotIndex,pInv.ObjectInHand);
		}
		
		if (sNewObj=="")
		{
			playerUW.CursorIcon= playerUW.CursorIconDefault;
			playerUW.CurrObjectSprite = "";
			pInv.ObjectInHand="";
		}
		else
		{
			GameObject NewObj ;
			NewObj = GameObject.Find (sNewObj);
			if (NewObj != null)
			{
				playerUW.CursorIcon= NewObj.GetComponent<ObjectInteraction>().InventoryIcon.texture;
				playerUW.CurrObjectSprite = NewObj.GetComponent<ObjectInteraction>().InventoryString;
				pInv.ObjectInHand=sNewObj;
			}
			else
			{
				Debug.Log ("unable to find " + sNewObj);
				playerUW.CursorIcon= playerUW.CursorIconDefault;
				playerUW.CurrObjectSprite = "";
				pInv.ObjectInHand="";
			}
			
		}
	}








	void UseFromSlot()
	{
		Debug.Log ("UseFromSlot");
		pInv = player.GetComponent<PlayerInventory>();
		string ObjectName= pInv.GetObjectAtSlot(slotIndex);
		if (ObjectName !="")
		{
			GameObject currObj = GameObject.Find (ObjectName);
			Debug.Log("you use this " + currObj.name + " InventorySlot.UseFromSlot");
			ObjectInteraction currObjInt = currObj.GetComponent<ObjectInteraction>();
			//TODO move this code to objinteract.activate()
			if (currObjInt.isContainer)
			{//Use a container
				if (pInv.ObjectInHand == "")
				{
					OpenContainer (currObj, currObjInt);
				}
				else
				{
					currObjInt.Activate();
					//pInv.InteractTwoObjects(pInv.ObjectInHand,ObjectName,slotIndex);
				}
				return;
			}
			if (currObjInt.isRuneBag)
			{//Use a rune bag
				if (pInv.ObjectInHand == "")
				{
					OpenRuneBag();
				}
				else
				{
					PickupFromSlot();
				}
				return;
			}

			if(currObjInt.isMap)
			{//Use a map
				Debug.Log ("This is a map");
				GameObject map = GameObject.Find ("Automap");

				//Turn on the camera
				foreach(Transform child in map.transform)
				{
					if (child.name == "Camera")
					{
						child.gameObject.SetActive(true);
					}
				}
				//Turn off the main hud
				GameObject UWHud =GameObject.Find ("UW_HUD");
				foreach(Transform child in UWHud.transform)
				{
					if ((child.name == "Anchor")||(child.name == "Camera"))
					{
						child.gameObject.SetActive(false);
					}
				}
				return;
			}

			//use an object. change the cursor
			if (currObjInt.Activate()==false)
			{
				playerUW.CursorIcon= currObj.GetComponent<ObjectInteraction>().InventoryIcon.texture;
				playerUW.CurrObjectSprite = currObj.GetComponent<ObjectInteraction>().InventoryString;
				pInv.ObjectInHand=ObjectName;
			}
		}
	}


	void LookFromSlot()
	{
		Debug.Log ("LookFromSlot");
		pInv = player.GetComponent<PlayerInventory>();
		//string ObjectName= pInv.GetObjectAtSlot(slotIndex);
		//if (ObjectName !="")
		//{
		//If object has a readable component then activate(and read) otherwise give a generic description.
		if(this.GetComponent<Readable>()!= null)
			{
			this.GetComponent<ObjectInteraction>().Activate();
			}
		else
			{
			MessageLog.text="You see a " + pInv.GetObjectDescAtSlot(slotIndex);
			}

			//MessageLog.text="You see a " + ObjectName;
		//}
		//	return;
	}

	void OnClick()
	{
		bool leftClick=true;
		//Debug.Log (UICamera.currentTouchID);
		if (UICamera.currentTouchID == -2)
		{
			leftClick=false;
		}
		//PlayerInventory pInv = player.GetComponent<PlayerInventory>();
		//Container SubContainer;
		switch (UWCharacter.InteractionMode)
		{
		case 1://talk
			if (leftClick)
				{//Left Click
					UseFromSlot();
				}
			else 
				{//right click
					LookFromSlot();
				}
			break;
		case 2://pickup
			pInv = player.GetComponent<PlayerInventory>();
			if ((leftClick) && (pInv.ObjectInHand!=""))
				{//Left Click and i'm carrying something
				if (pInv.GetObjectAtSlot(slotIndex)=="")//No object in slot
					{
					PickupFromSlot();
					}
				else
					{//There is an object in that slot.
					GameObject ObjectUsedOn = GameObject.Find (pInv.GetObjectAtSlot(slotIndex));
					if (ObjectUsedOn !=null)
						{
						if (ObjectUsedOn.GetComponent<ObjectInteraction>() != null)	
							{
							if (ObjectUsedOn.GetComponent<ObjectInteraction>().Activate()==false)
								{
								//No effect occurred. Swap the two objects.
								Debug.Log("Swapping (no effect 1)" + ObjectUsedOn.name + " with " + pInv.ObjectInHand);
								pInv.SetObjectAtSlot(slotIndex,pInv.ObjectInHand);
								pInv.ObjectInHand= ObjectUsedOn.name;
								playerUW.CursorIcon= ObjectUsedOn.GetComponent<ObjectInteraction>().InventoryIcon.texture;
								playerUW.CurrObjectSprite = ObjectUsedOn.GetComponent<ObjectInteraction>().InventoryString;
								}
							}
						else
							{
							//No effect occurred. Swap the two objects. (should not happen?)
							Debug.Log("Swapping (no effect 2)" + ObjectUsedOn.name + " with " + pInv.ObjectInHand);
							}
						}
					//pInv.InteractTwoObjects(pInv.ObjectInHand,pInv.GetObjectAtSlot(slotIndex),slotIndex);
					//UseFromSlot();
					}
					
				}
			else 
				{//right click
				PickupFromSlot();
				}

			break;
		case 4://look
			if (leftClick)
				{//Left Click
					UseFromSlot();
				}
			else 
				{//right click
					LookFromSlot();
				}
			break;
		case 8://attack
			if (leftClick)
				{//Left Click
					UseFromSlot();
				}
			else 
				{//right click
					LookFromSlot();
				}
			break;
		case 16://use
			UseFromSlot ();
			break;
		}
	

	}

	void OpenRuneBag()
	{
		chains chainControl = GameObject.Find ("Chain").GetComponent<chains>();
		if (chainControl!=null)
		{
			chainControl.ActiveControl=2;
		}
	}

	void OpenContainer(GameObject currObj, ObjectInteraction currObjInt)
	{
		transform.parent.FindChild("ContainerOpened").GetComponent<UISprite>().spriteName=currObjInt.InventoryString;
		//transform.parent.FindChild("ContainerOpened").GetComponent<ContainerOpened>().ContainerTarget = pInv.currentContainer;
		//display the container contents.
		Container currObjCont = currObj.GetComponent<Container>();
		currObjCont.isOpenOnPanel=true;
		//currObjCont.ContainerParent=pInv.currentContainer;
		//pInv.atTopLevel=false;
		pInv.currentContainer=currObjCont.name;
		if (pInv.currentContainer=="")
		{
			pInv.currentContainer="Gronk";
			currObjCont.ContainerParent="Gronk";
		}
		for (int i = 0; i<8; i++)
		{
			string sItem = currObjCont.GetItemAt(i);
			pInv.SetObjectAtSlot(i+11,sItem);
		}
	}




//	void OnClick()
//	{
	
		//MessageLog.text=  name + "clicked1";
//		if (playerUW.CurrObjectSprite!="")
//		{//Player is holding something.
//			if (ObjectInSlot ==null)
//			{
				//There is nothing in the slot
//				slot.spriteName=playerUW.CurrObjectSprite;
//				ObjectInSlot=playerUW.ObjectInHand;
//				playerUW.currInventorySlot=null;
//				playerUW.CurrObjectSprite=null;
//				playerUW.CursorIcon=playerUW.CursorIconDefault;
//			}
//			else
//			{
				//There is something in the slot ->swap it 
//			}

//		}


//		MessageLog.text=  name + "clicked";
//	}

	public static bool InteractTwoObjects(string sObjectInHand, string sObjectUsedOn,int slotIndex)
	{//How slots act when objects are used on them.
		PlayerInventory pinv = playerUW.gameObject.GetComponent<PlayerInventory>();
		Debug.Log ("Interacting " + sObjectInHand + " and " + sObjectUsedOn);
		//returns true if they have an effect on each other.
		if ((sObjectInHand !="") && (sObjectUsedOn !=""))
		{//Object is being used on something.
			GameObject objInHand= GameObject.Find (sObjectInHand);
			GameObject objUseOn = GameObject.Find (sObjectUsedOn);
			if(objUseOn.GetComponent<ObjectInteraction>() ==null)
			{//Object has no interaction component.
				pinv.ObjectInHand="";
				playerUW.CursorIcon= playerUW.CursorIconDefault;
				playerUW.CurrObjectSprite = "";
				return false;
			}
			else
			{//Object has an interaction. activate it.
				return objUseOn.GetComponent<ObjectInteraction>().Activate();

			}
		}
		else
		{//Object is just being placed in a slot. 
			if (sObjectInHand!="")
			{
				GameObject objInHand= GameObject.Find (sObjectInHand);
				//Container subContainer = objUseOn.GetComponent<Container>();
				if (objInHand.GetComponent<ObjectInteraction>().isContainer)
				{
					//PlayerInventory pInv = GameObject.Find ("Gronk").GetComponent<PlayerInventory>();
					Container subContainer=objInHand.GetComponent<Container>();
					if (slotIndex >=11)
					{//Object is being added to a bag container
						subContainer.ContainerParent=pinv.currentContainer;
					}
					else
					{//object is being added to an equipment slot
						subContainer.ContainerParent="Gronk";
					}
					
				}
			}
			return false;
		}
	}
}
