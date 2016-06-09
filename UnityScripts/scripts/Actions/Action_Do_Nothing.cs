using UnityEngine;
using System.Collections;

public class Action_Do_Nothing : MonoBehaviour {
	public string ObjectToActivate;

	public void PerformAction()
	{
		GameObject objToActivate=GameObject.Find (ObjectToActivate);
		Debug.Log (this.name + " Action Do Nothing");
		objToActivate.SendMessage("Activate");
	}
}
