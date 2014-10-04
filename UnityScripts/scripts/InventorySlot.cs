using UnityEngine;
using System.Collections;

public class InventorySlot : MonoBehaviour {

	private UILabel MessageLog;
	private UISprite slot;
	//public int InteractionMode;
	public static GameObject player;
	public static UWCharacter playerUW;

	public GameObject ObjectInSlot;
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
	
	void OnHover( bool isOver )
	{
		if( isOver )
		{
			playerUW.currInventorySlot=this.gameObject;
			//MessageLog.text=name + "Hovered over";
		}

		else
		{
			playerUW.currInventorySlot=null;
			//MessageLog.text=name + "Hovered out";
		}
			
	}

	void OnClick()
	{
		Debug.Log (name + " clicked");
		PlayerInventory pInv = player.GetComponent<PlayerInventory>();
		string sNewObj = pInv.ObjectPickedUp(slotIndex,playerUW.ObjectInHand);
		if (sNewObj=="")
		{
			playerUW.CursorIcon= playerUW.CursorIconDefault;
			playerUW.CurrObjectSprite = "";
			playerUW.ObjectInHand="";
		}
		else
		{
			GameObject NewObj = GameObject.Find (sNewObj);
			if (NewObj != null)
			{
				playerUW.CursorIcon= NewObj.GetComponent<ObjectInteraction>().InventoryIcon.texture;
				playerUW.CurrObjectSprite = NewObj.GetComponent<ObjectInteraction>().InventoryString;
				playerUW.ObjectInHand=sNewObj;
			}
			else
			{
				Debug.Log ("unable to find " + sNewObj);
				playerUW.CursorIcon= playerUW.CursorIconDefault;
				playerUW.CurrObjectSprite = "";
				playerUW.ObjectInHand="";
			}

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
