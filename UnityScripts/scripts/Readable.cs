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

	public string Activate()
	{//Returns the text of this readable.
		ObjectInteraction objInt = this.gameObject.GetComponent<ObjectInteraction>();
		StringController SC = objInt.getStringController();

		switch (objInt.item_id)
		{
		case 10: //Sign
			{
			return SC.GetString (8,objInt.Link - 0x200);
			break;
			}
		case 11://Book
		case 13://Scroll
			{
			return SC.GetString (3,objInt.Link - 0x200);
			break;
			}
		default: 
			{
			return "READABLE NOT FOUND!";
			break;
			}
		}
	}
}
