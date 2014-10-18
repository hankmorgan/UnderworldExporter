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
	void Update () {
		//if (playerUW==null)
		//{
		//	playerUW=player.GetComponent<UWCharacter>();
		//}
	}



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

	void OnClick()
	{
		PlayerInventory pInv = player.GetComponent<PlayerInventory>();
		Container SubContainer;
		switch (UWCharacter.InteractionMode)
		{
		case 2://pickup
		{
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

			break;

		case 16://use

			string ObjectName= pInv.GetObjectAtSlot(slotIndex);
			if (ObjectName !="")
			{
				GameObject currObj = GameObject.Find (ObjectName);
				Debug.Log("you use this" + currObj.name);
				ObjectInteraction currObjInt = currObj.GetComponent<ObjectInteraction>();
				if (currObjInt.isContainer)
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
						//transform.parent.FindChild ()
						//Debug.Log ("Looking for " + "Backpack_Slot_" + i.ToString ("D2"));
						//Debug.Log ("Parent is " + transform.parent.name);
						//InventorySlot currSlot = transform.parent.FindChild ("Backpack_Slot_" + i.ToString ("D2")).GetComponent<InventorySlot>();
						string sItem = currObjCont.GetItemAt(i);
						pInv.SetObjectAtSlot(i+11,sItem);
					}
				}
			}

			break;
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
