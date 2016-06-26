using UnityEngine;
using System.Collections;

public class InteractionModeControlItem : GuiBase {
	//Individual interface modes controls

	public int InteractionMode;
	public bool isOn;
	public InteractionModeControl imc;


	public void OnClick()
	{
		if ((playerUW.playerInventory.ObjectInHand!="") || (Conversation.InConversation) || (WindowDetect.WaitingForInput))
		{
			return;
		}
		if (isOn==true)
		{
			isOn=false;
			InteractionModeControl.UpdateNow=true;
			UWCharacter.InteractionMode=UWCharacter.DefaultInteractionMode;
		}
		else
		{
			isOn=true;
			imc.TurnOffOthers(InteractionMode);
			InteractionModeControl.UpdateNow=true;
			UWCharacter.InteractionMode=InteractionMode;
		}
	}
}
