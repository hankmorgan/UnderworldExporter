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
		if ((UWCharacter.Instance.playerInventory.ObjectInHand!="") || (ConversationVM.InConversation) || (WindowDetect.WaitingForInput))
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
        UWHUD.instance.EnableDisableControl(UWHUD.instance.InteractionControlUW2BG.gameObject, _RES == GAME_UW2 && UWCharacter.InteractionMode == UWCharacter.InteractionModeOptions);
    }


	public override void Update ()
	{
		base.Update();
		if (Input.GetKeyUp(ShortCutKey))	
		{
				OnClick();
		}
	}
}
