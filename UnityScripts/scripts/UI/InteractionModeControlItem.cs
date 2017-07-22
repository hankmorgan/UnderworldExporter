using UnityEngine;
using System.Collections;

/// <summary>
/// Interaction mode button code for controlling the interaction mode of the character.
/// </summary>
public class InteractionModeControlItem : GuiBase {
	//Individual interface modes controls

	public int InteractionMode;
	public bool isOn;
	public InteractionModeControl imc;
	public KeyCode ShortCutKey;

	public void OnClick()
	{
		if ((GameWorldController.instance.playerUW.playerInventory.ObjectInHand!="") || (ConversationVM.InConversation) || (WindowDetect.WaitingForInput))
		{
			return;
		}
		if ((isOn==true) && (InteractionMode!=UWCharacter.InteractionModeOptions))
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


	void Update()
	{
		if (Input.GetKeyUp(ShortCutKey))	
		{
				OnClick();
		}
	}
}
