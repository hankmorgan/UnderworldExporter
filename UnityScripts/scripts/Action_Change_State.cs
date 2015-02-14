using UnityEngine;
using System.Collections;

public class Action_Change_State : MonoBehaviour {

	public string ObjectToActivate;
	public int NewState;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PerformAction()
	{
		Debug.Log ("Action Change State");
		GameObject objToActivate = GameObject.Find (ObjectToActivate);
		if (objToActivate!=null)
		{
			objToActivate.SendMessage("Activate");
		}
		else
		{
			Debug.Log (this.name + " could not find " + ObjectToActivate);
		}
	}
}
