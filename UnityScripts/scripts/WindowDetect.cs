using UnityEngine;
using System.Collections;

public class WindowDetect : MonoBehaviour {
	//private UILabel MessageLog;
	//public int InteractionMode;
	UWCharacter playerUW;
	// Use this for initialization
	void Start () {
		//MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
		playerUW=GameObject.Find ("Gronk").GetComponent <UWCharacter>();
	}

	
	// Update is called once per frame
	void Update () {
	
	}

	void OnHover( bool isOver )
	{
		if( isOver )
		{
			playerUW.CursorInMainWindow=true;
			//MessageLog.text=name + "over window";
		}
		else
		{
			playerUW.CursorInMainWindow=false;
			//MessageLog.text="unHover window";
		}
	}

	void OnClick()
	{
		if (playerUW.ObjectInHand!="")
			{
			if (playerUW.JustPickedup==false)
				{
				Debug.Log ("heave ho" + playerUW.ObjectInHand);
				GameObject droppedItem = GameObject.Find(playerUW.ObjectInHand);
				droppedItem.transform.position=playerUW.transform.position;
				playerUW.CursorIcon= playerUW.CursorIconDefault;
				playerUW.CurrObjectSprite = "";
				playerUW.ObjectInHand="";
				}
			else
			{
				Debug.Log ("wait a mo" + playerUW.ObjectInHand);
				playerUW.JustPickedup=false;
			}
				//try and drop the item in the world

			}
	}
}
