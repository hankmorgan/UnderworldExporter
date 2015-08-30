using UnityEngine;
using System.Collections;

public class Readable : MonoBehaviour {
	//public static StringController SC;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool Activate()
	{//Returns the text of this readable.
		ObjectInteraction objInt = this.gameObject.GetComponent<ObjectInteraction>();
		StringController SC = objInt.getStringController();
		UILabel ml = objInt.getMessageLog();

		switch (objInt.ItemType)
		{
		case ObjectInteraction.SIGN: //Sign
			{
			ml.text = SC.GetString (8,objInt.Link - 0x200);
			return true;
			break;
			}
		case ObjectInteraction.BOOK://Book
		case ObjectInteraction.SCROLL://Scroll
			{
			ml.text = SC.GetString (3,objInt.Link - 0x200);
			return true;
			break;
			}
		default: 
			{
			ml.text = "READABLE TYPE NOT FOUND! (" + objInt.item_id +")";
			return false;
			break;
			}
		}
	}
}
