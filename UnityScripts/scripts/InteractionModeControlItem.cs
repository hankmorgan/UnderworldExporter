using UnityEngine;
using System.Collections;

public class InteractionModeControlItem : MonoBehaviour {


	public int InteractionMode;
	private bool isOn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnClick()
	{
		
		
		if (isOn==true)
		{
			isOn=false;
			InteractionModeControl.UpdateNow=true;
			UWCharacter.InteractionMode=UWCharacter.DefaultInteractionMode;
		}
		else
		{
			isOn=true;
			InteractionModeControl.UpdateNow=true;
			UWCharacter.InteractionMode=InteractionMode;
		}
	}
}
