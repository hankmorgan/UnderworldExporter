using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class InteractionModeControl : GuiBase_Draggable {

	//The mode selection UI elements master control
	public RawImage[] Controls=new RawImage[6];


	public static bool UpdateNow=true;


	void Update () {
	
		if (UpdateNow==true)
		{
			UpdateNow=false;
			for (int i = 0; i<=5;i++)
			{
				if (i != UWCharacter.InteractionMode)
				{//Off version
					Controls[i].texture=Resources.Load <Texture2D> ("UW1/HUD/lfti/lfti_"+ (i*2).ToString("0000"));
				}
				else
				{//On Version
					Controls[i].texture=Resources.Load <Texture2D> ("UW1/HUD/lfti/lfti_"+ ((i*2)+1).ToString("0000"));
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
