using UnityEngine;
using System.Collections;

public class ShockButtonHandler : MonoBehaviour {

	public int TriggerAction;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		Debug.Log (this.name+ " clicked");
		Activate ();
	}

	void Activate()
	{
		switch(TriggerAction)
		{
		case 0:	//Action_Do_Nothing
			this.transform.parent.GetComponent<Action_Do_Nothing>().PerformAction();
			break;
		case 1: //Action_Transport_Level
			this.transform.parent.GetComponent<Action_Transport_Level>().PerformAction ();
			break;
		case 2:	//Action_Resurrection
			this.transform.parent.GetComponent<Action_Resurrection>().PerformAction ();
			break;
		case 3: //Action_Clone
			this.transform.parent.GetComponent<Action_Clone>().PerformAction();
			break;
		case 4: //Action_Set_Variable
			this.transform.parent.GetComponent<Action_Set_Variable>().PerformAction();
			break;
		case 6: //Action_Activate
			this.transform.parent.GetComponent<Action_Activate>().PerformAction();
			break;
		case 7: //Action_Lighting
			this.transform.parent.GetComponent<Action_Lighting>().PerformAction();
			break;
		case 8: //Action_Effect
			this.transform.parent.GetComponent<Action_Effect>().PerformAction();
			break;
		case 9: //Action_Moving_Platform
			this.transform.parent.GetComponent<Action_Moving_Platform>().PerformAction ();
			break;
		case 11: //Action_Timer
			this.transform.parent.GetComponent<Action_Timer>().PerformAction ();
			break;
		case 12: //Action_choice
			this.transform.parent.GetComponent<Action_Choice>().PerformAction ();
			break;
		case 15: //Action_Email
			this.transform.parent.GetComponent<Action_Email>().PerformAction ();
			break;
		case 16: //Action_Radaway
			this.transform.parent.GetComponent<Action_Radaway>().PerformAction ();
			break;
		case 19: //Action_Change_State
			this.transform.parent.GetComponent<Action_Change_State>().PerformAction ();
			break;
		case 21: //Action_Awaken
			this.transform.parent.GetComponent<Action_Awaken>().PerformAction();
			break;
		case 22: //Action_Message
			this.transform.parent.GetComponent<Action_Message>().PerformAction();
			break;
		case 23: //Action_Spawn
			this.transform.parent.GetComponent<Action_Spawn>().PerformAction();
			break;
		case 24: //Action_Change_Type
			this.transform.parent.GetComponent<Action_Change_Type>().PerformAction();
			break;
		default:
			this.transform.parent.GetComponent<Action_Default>().PerformAction();
			break;
		}
	}
}
