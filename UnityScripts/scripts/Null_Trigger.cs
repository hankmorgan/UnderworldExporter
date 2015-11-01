using UnityEngine;
using System.Collections;

public class Null_Trigger : MonoBehaviour {
	public int TriggerAction;
	public int[] conditions = new int[4];
	public bool TriggerOnce;
	public bool AlreadyTriggered;

	void Activate()
	{
		switch(TriggerAction)
		{
		case 0:	//Action_Do_Nothing
			this.GetComponent<Action_Do_Nothing>().PerformAction();
			break;
		case 1: //Action_Transport_Level
			this.GetComponent<Action_Transport_Level>().PerformAction ();
			break;
		case 2:	//Action_Resurrection
			this.GetComponent<Action_Resurrection>().PerformAction ();
			break;
		case 3: //Action_Clone
			this.GetComponent<Action_Clone>().PerformAction();
			break;
		case 4: //Action_Set_Variable
			this.GetComponent<Action_Set_Variable>().PerformAction();
			break;
		case 6: //Action_Activate
			this.GetComponent<Action_Activate>().PerformAction();
			break;
		case 7: //Action_Lighting
			this.GetComponent<Action_Lighting>().PerformAction();
			break;
		case 8: //Action_Effect
			this.GetComponent<Action_Effect>().PerformAction();
			break;
		case 9: //Action_Moving_Platform
			this.GetComponent<Action_Moving_Platform>().PerformAction ();
			break;
		case 11: //Action_Timer
			this.GetComponent<Action_Timer>().PerformAction ();
			break;
		case 12: //Action_choice
			this.GetComponent<Action_Choice>().PerformAction ();
			break;
		case 15: //Action_Email
			this.GetComponent<Action_Email>().PerformAction ();
			break;
		case 16: //Action_Radaway
			this.GetComponent<Action_Radaway>().PerformAction ();
			break;
		case 19: //Action_Change_State
			this.GetComponent<Action_Change_State>().PerformAction ();
			break;
		case 21: //Action_Awaken
			this.GetComponent<Action_Awaken>().PerformAction();
			break;
		case 22: //Action_Message
			this.GetComponent<Action_Message>().PerformAction();//Either fail or success depending on conditions!
			break;
		case 23: //Action_Spawn
			this.GetComponent<Action_Spawn>().PerformAction();
			break;
		case 24: //Action_Change_Type
			this.GetComponent<Action_Change_Type>().PerformAction();
			break;
		default:
			this.GetComponent<Action_Default>().PerformAction();
			break;
		}
	}
}
