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
//		MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
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
		pInv = player.GetComponent<PlayerInventory>();
		string ObjectName= pInv.GetObjectAtSlot(slotIndex);
		if (ObjectName !="")
		{
			GameObject currObj = GameObject.Find (ObjectName);
			Debug.Log("you use this " + currObj.name + " InventorySlot.UseFromSlot");
			ObjectInteraction currObjInt = currObj.GetComponent<ObjectInteraction>();
			if (currObjInt.isContainer)
			{
				if (pInv.ObjectInHand == "")
				{
					OpenContainer (currObj, currObjInt);
				}
				else
				{
					pInv.InteractTwoObjects(pInv.ObjectInHand,ObjectName,slotIndex);
				}
			}
			if (currObjInt.isRuneBag)
			{
				if (pInv.ObjectInHand == "")
				{
					OpenRuneBag();
				}
				else
				{
					PickupFromSlot();
				}
			}

			if(currObjInt.isMap)
			{
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


			}
		}
	}


	void LookFromSlot()
	{
		return;
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
					{
					UseFromSlot();
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
}
