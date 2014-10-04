using UnityEngine;
using System.Collections;

public class ObjectInteraction : MonoBehaviour {
	private UILabel MessageLog;
	public Sprite InventoryIcon;
	public string InventoryString;
	public Sprite InventoryIconEquip;
	public string InventoryIconEquipString;

	public static GameObject player;
	public static GameObject InvMarker=GameObject.Find ("InventoryMarker");
	private UWCharacter playerUW;
	// Use this for initialization
	void Start () {
		MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
		playerUW=player.GetComponent<UWCharacter>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		switch (ObjectVariables.InteractionMode)
		{
		case 0://Options
			MessageLog.text = "Nothing will happen in options mode " + name;
			break;
		case 1://Talk
			MessageLog.text = "You can't talk to " + name;
			break;
		case 2://Pickup
			if (playerUW.ObjectInHand=="")
			{
				MessageLog.text = "You pick up a " + name;
				//Cursor.SetCursor (InventoryIcon.texture,Vector2.zero, CursorMode.ForceSoftware);
				playerUW.CursorIcon= InventoryIcon.texture;
				playerUW.CurrObjectSprite = InventoryString;
				playerUW.ObjectInHand=name;
				playerUW.JustPickedup=true;
				this.transform.position = InvMarker.transform.position;
			}
			//Move the selected gameobject to the box.
			break;
		case 4://Look
			MessageLog.text = "You see a " + name;
			break;
		case 8://Attack
			MessageLog.text = "You attack a " + name;
			break;
		case 16://Use
			MessageLog.text = "You use a " + name;
			break;
		}
	}
}
