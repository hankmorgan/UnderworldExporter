using UnityEngine;
using System.Collections;

public class ObjectInteraction : MonoBehaviour {
	private UILabel MessageLog;
	public Sprite InventoryIcon;
	public string InventoryString;
	public Sprite InventoryIconEquip;
	public string InventoryIconEquipString;

	public int item_id;

	public static GameObject player;
	public static GameObject InvMarker;//=GameObject.Find ("InventoryMarker");
	public static StringController SC;	//String controller reference

	private UWCharacter playerUW;
	private PlayerInventory pInv;
	public bool CanBePickedUp;	//unimplemented
	public bool CanBeUsed;//unimplemented
	public bool CanBeMoved;//unimplemented

	public bool isContainer;
	public bool isRuneBag;
	public bool isRuneStone;
	public bool isMap;
	public bool isDoor;
	public bool isKey;

	public int ItemType; //UWexporter item type id

	//UW specific info.
	public int Owner;	//Used for keys
	public int Link;

	// Use this for initialization

	void Start () {
		MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
		if (player!=null)
		{
			playerUW=player.GetComponent<UWCharacter>();
			pInv=player.GetComponent<PlayerInventory>();
		}

		if (InvMarker==null)
		{
			InvMarker=GameObject.Find ("InventoryMarker");
		}
	}

	public string LookDescription()
	{//Returns the description of this object.
		return SC.GetString("004",item_id.ToString ("000"));
	}

	public string LookDescription(ObjectInteraction objInt)
	{//Returns the description of this object.
		switch (objInt.ItemType)
		{
		case 10://signs
			{
				return objInt.MessageLog.text = SC.GetString (8,objInt.Link - 0x200);
				break;
			}
		default:
			{
				return SC.GetString("004",item_id.ToString ("000"));
			}

		}

	}

	static public void Activate(ObjectInteraction objInt)
	{//Code to handle using specific objects
		switch (objInt.ItemType)
		{
		case 4://Door
			{
				DoorControl objDoor = objInt.gameObject.GetComponent<DoorControl>();
				if (objDoor!=null)
				{
					objDoor.Activate();
					return;
				}
				break;
			}
		case 10://Signs
		{
			objInt.MessageLog.text = SC.GetString (8,objInt.Link - 0x200);
			break;
		}
		default:
			{
				objInt.MessageLog.text = "Default: Type=" + objInt.ItemType + ", You use a " + objInt.gameObject.name;
				break;
			}
		}
	}
/*
	// Update is called once per frame
	void Update () {
		return;
		if ((player!=null) && (playerUW==null))
			{
			playerUW=player.GetComponent<UWCharacter>();
			}
		if ((player!=null) && (pInv==null))
		{
			pInv=player.GetComponent<PlayerInventory>();
		}
		if (InvMarker==null)
			{
			InvMarker=GameObject.Find ("InventoryMarker");
			}
	}

	void OnMouseDown()
	{
		return;
		float distance;
		if (playerUW.CursorInMainWindow==false)
		{//Stop items outside the viewport from being triggered.
			return;
		}


		switch (UWCharacter.InteractionMode)
		{
		case 0://Options
			MessageLog.text = "Nothing will happen in options mode " + name;
			break;
		case 1://Talk
			MessageLog.text = "You can't talk to " + name;
			break;
		case 2://Pickup
			if (playerUW==null)
			{
				player.GetComponent<UWCharacter>();
			}

			if (pInv.ObjectInHand=="")
			{
				//distance =Vector3.Distance(transform.position,player.transform.position);
				//if (distance<=playerUW.InteractionDistance)
				//{
					MessageLog.text = "You pick up a " + name;
					//Cursor.SetCursor (InventoryIcon.texture,Vector2.zero, CursorMode.ForceSoftware);
					playerUW.CursorIcon= InventoryIcon.texture;
					playerUW.CurrObjectSprite = InventoryString;
					pInv.ObjectInHand=name;
					pInv.JustPickedup=true;//To stop me throwing it away immediately.
					//Move the selected gameobject to the box.
					this.transform.position = InvMarker.transform.position;
					this.transform.parent=InvMarker.transform;//Adds to the marker so it will persist.

				//}
				//else
				//{
				//	MessageLog.text = "That is too far away to take";
				//}
			}

			break;
		case 4://Look
			MessageLog.text = "You see a " + name;
			break;
		case 8://Attack
			MessageLog.text = "You attack a " + name;
			break;
		case 16://Use
			//distance =Vector3.Distance(transform.position,player.transform.position);
			//if (distance<=playerUW.InteractionDistance)
			//{
			MessageLog.text = "You use a " + name + "ObjectInteraction.OnMouseDown";
			//}
			//else
			//{
			//	MessageLog.text = "That is too far away to use";
			//}
			break;
		}
	}
	*/
}
