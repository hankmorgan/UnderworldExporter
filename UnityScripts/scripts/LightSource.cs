using UnityEngine;
using System.Collections;

public class LightSource : MonoBehaviour {

	public int Brightness;
	public int Duration;

	public int ItemIdOn;
	public int ItemIdOff;

	public bool IsOn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Use()
	{
		ObjectInteraction objInt = this.gameObject.GetComponent<ObjectInteraction>();
		UILabel ml =objInt.getMessageLog();

		//Activates or deactivates the torch.
		if (IsOn == true)
		{//Turn off the torch
			IsOn=false;
			objInt.item_id=ItemIdOff;
			objInt.InvDisplayIndex=ItemIdOff;
		}
		else
		{//Turn on the torch
			IsOn=true;
			objInt.item_id=ItemIdOn;
			objInt.InvDisplayIndex=ItemIdOn;
		}
		objInt.RefreshAnim();
	}

	public void LookAt()
	{
		ObjectInteraction objInt = this.gameObject.GetComponent<ObjectInteraction>();
		UILabel ml =objInt.getMessageLog();
		StringController Sc = objInt.getStringController();
		ml.text = Sc.GetString(1,260) + " " + Sc.GetFormattedObjectNameUW(objInt);
	}
}
