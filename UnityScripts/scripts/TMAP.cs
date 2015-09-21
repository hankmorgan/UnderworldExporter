using UnityEngine;
using System.Collections;

public class TMAP : MonoBehaviour {

	public string trigger;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

 	public bool LookAt()
	{
		if (trigger != "")
		{
			ObjectInteraction objIntTrigger = GameObject.Find (trigger).GetComponent<ObjectInteraction>();
			if (objIntTrigger.ItemType==ObjectInteraction.A_LOOK_TRIGGER)
				{
				objIntTrigger.Use ();
				return true;
				}
			else
			{
				ObjectInteraction objInt = this.gameObject.GetComponent<ObjectInteraction>();
				UILabel ml =objInt.getMessageLog();
				StringController Sc = objInt.getStringController();
				ml.text = Sc.GetString(1,260) + " " + Sc.GetFormattedObjectNameUW(objInt);
				return true;
			}
		}
		return true;
	}

	public void Use()
	{
//		Debug.Log ("Activating " + trigger);
		if (trigger != "")
		{
			ObjectInteraction objInt = GameObject.Find (trigger).GetComponent<ObjectInteraction>();
			objInt.Use();
		}
	}
}
