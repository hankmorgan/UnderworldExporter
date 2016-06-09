using UnityEngine;
using System.Collections;

public class InteractionModeControl : GuiBase {

	//The mode selection UI elements master control
	public UITexture[] Controls=new UITexture[6];


	public static bool UpdateNow=true;


	void Update () {
	
		if (UpdateNow==true)
		{
			UpdateNow=false;
			for (int i = 0; i<=5;i++)
			{
				if (i != UWCharacter.InteractionMode)
				{//Off version
					Controls[i].mainTexture=Resources.Load <Texture2D> ("HUD/lfti/lfti_"+ (i*2).ToString("0000"));
				}
				else
				{//On Version
					Controls[i].mainTexture=Resources.Load <Texture2D> ("HUD/lfti/lfti_"+ ((i*2)+1).ToString("0000"));
				}
			}
		}
	}

	public void TurnOffOthers(int LeaveOn)
	{
		for (int i = 0; i<=5;i++)
		{
			if (i!=LeaveOn)
			{
				Controls[i].gameObject.GetComponent<InteractionModeControlItem>().isOn=false;
			}
		}

	}
}
