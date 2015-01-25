using UnityEngine;
using System.Collections;

public class Action_Choice : MonoBehaviour {

	public bool state=true;
	public string ActivateTrue;
	public string ActivateFalse;
	private GameObject ActivateObjectTrue;
	private GameObject ActivateObjectFalse;
	// Use this for initialization
	void Start () {
		ActivateObjectTrue=GameObject.Find (ActivateTrue);
		ActivateObjectFalse=GameObject.Find (ActivateFalse);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PerformAction()
	{
		Debug.Log (this.name + " Action Choice");
		if (state==true)
			{
			state=false;
			ActivateObjectTrue.SendMessage("Activate");
			}
		else
			{
			state=true;
			ActivateObjectFalse.SendMessage("Activate");
			}
	}
}
