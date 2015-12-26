using UnityEngine;
using System.Collections;

public class a_do_trap_conversation : trap_base {

	public override bool Activate (int triggerX, int triggerY, int State)
	{
		NPC_Door np =  this.GetComponent<NPC_Door>();
		if (np!=null)
		{
			UWCharacter.InteractionMode=UWCharacter.InteractionModeTalk;
			InteractionModeControl.UpdateNow=true;
			return np.TalkTo();
		}
		return false;
	}



	public override void PostActivate ()
	{//Do not destroy

	}

}

