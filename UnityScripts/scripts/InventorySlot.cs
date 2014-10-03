using UnityEngine;
using System.Collections;

public class InventorySlot : MonoBehaviour {

	private UILabel MessageLog;
	private UISprite slot;
	//public int InteractionMode;
	public static GameObject player;
	// Use this for initialization
	void Start () {
		MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
		slot = GetComponent<UISprite>();
	}
	
	// Update is called once per frame
	void Update () {
		
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
			player.GetComponent<UWCharacter>().currInventorySlot=this.gameObject;
			//MessageLog.text=name + "Hovered over";
		}

		else
		{
			player.GetComponent<UWCharacter>().currInventorySlot=null;
			//MessageLog.text=name + "Hovered out";
		}
			
	}
	
	void OnClick()
	{
		//MessageLog.text=  name + "clicked1";
		slot.spriteName=player.GetComponent<UWCharacter>().CurrObjectSprite;
		player.GetComponent<UWCharacter>().CursorIcon=player.GetComponent<UWCharacter>().CursorIconDefault;
		player.GetComponent<UWCharacter>().currInventorySlot=null;
		player.GetComponent<UWCharacter>().CurrObjectSprite=null;
		MessageLog.text=  name + "clicked";
	}
}
