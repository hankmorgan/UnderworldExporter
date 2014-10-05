using UnityEngine;
using System.Collections;

public class ObjectInteraction : MonoBehaviour {
	private UILabel MessageLog;
	public Sprite InventoryIcon;
	public string InventoryString;
	public Sprite InventoryIconEquip;
	public string InventoryIconEquipString;

	public static GameObject player;
	public static GameObject InvMarker;//=GameObject.Find ("InventoryMarker");
	private UWCharacter playerUW;
	public bool isContainer;
	// Use this for initialization
	void Start () {
		MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
		if (player!=null)
		{
			playerUW=player.GetComponent<UWCharacter>();
		}

		if (InvMarker==null)
		{
			InvMarker=GameObject.Find ("InventoryMarker");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if ((player!=null) && (playerUW==null))
			{
			playerUW=player.GetComponent<UWCharacter>();
			}
		if (InvMarker==null)
			{
			InvMarker=GameObject.Find ("InventoryMarker");
			}
	}

	void OnMouseDown()
	{
		if (playerUW.CursorInMainWindow==false)
		{//Stop items outside the viewport from being triggered.
			return;
		}
		switch (ObjectVariables.InteractionMode)
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
			if (playerUW.ObjectInHand=="")
			{
				MessageLog.text = "You pick up a " + name;
				//Cursor.SetCursor (InventoryIcon.texture,Vector2.zero, CursorMode.ForceSoftware);
				playerUW.CursorIcon= InventoryIcon.texture;
				playerUW.CurrObjectSprite = InventoryString;
				playerUW.ObjectInHand=name;
				playerUW.JustPickedup=true;//To stop me throwing it away immediately.
				//Move the selected gameobject to the box.
				this.transform.position = InvMarker.transform.position;
			}

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
