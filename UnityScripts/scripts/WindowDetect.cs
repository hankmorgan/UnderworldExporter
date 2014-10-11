using UnityEngine;
using System.Collections;

public class WindowDetect : MonoBehaviour {
	//private UILabel MessageLog;
	//public int InteractionMode;
	UWCharacter playerUW;
	PlayerInventory pInv;
	// Use this for initialization
	void Start () {
		//MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
		playerUW=GameObject.Find ("Gronk").GetComponent <UWCharacter>();
		pInv=GameObject.Find ("Gronk").GetComponent <PlayerInventory>();
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
		if (pInv.ObjectInHand!="")
			{
			if (pInv.JustPickedup==false)
				{
				Debug.Log ("heave ho" + pInv.ObjectInHand);
				GameObject droppedItem = GameObject.Find(pInv.ObjectInHand);
				droppedItem.transform.parent=null;
				droppedItem.transform.position=playerUW.transform.position;
				playerUW.CursorIcon= playerUW.CursorIconDefault;
				playerUW.CurrObjectSprite = "";
				pInv.ObjectInHand="";
				}
			else
			{
				Debug.Log ("wait a mo" + pInv.ObjectInHand);
				pInv.JustPickedup=false;
			}
				//try and drop the item in the world

			}
	}
}
