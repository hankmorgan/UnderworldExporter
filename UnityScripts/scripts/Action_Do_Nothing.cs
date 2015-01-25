using UnityEngine;
using System.Collections;

public class Action_Do_Nothing : MonoBehaviour {
	public string ObjectToActivate;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PerformAction()
	{
		GameObject objToActivate=GameObject.Find (ObjectToActivate);
		Debug.Log (this.name + " Action Do Nothing");
		objToActivate.SendMessage("Activate");
	}
}
