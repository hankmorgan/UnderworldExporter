using UnityEngine;
using System.Collections;
/// <summary>
/// A Talking Door!
/// </summary>
public class a_do_trap_conversation : a_hack_trap {

	protected override void Start ()
	{
		base.Start ();
		//Set up this talking door!
		NPC_Door np =this.gameObject.AddComponent<NPC_Door>();
		np.npc_whoami=25;
	}

	public override bool Activate (object_base src,int triggerX, int triggerY, int State)
	{
	if (ConversationVM.InConversation==false)
		{
			NPC_Door np =  this.GetComponent<NPC_Door>();
			if (np!=null)
			{
				UWCharacter.InteractionMode=UWCharacter.InteractionModeTalk;
				InteractionModeControl.UpdateNow=true;
				return np.TalkTo();
			}
		}
		return false;
	}

	public override void PostActivate (object_base src)	
	{//Do not destroy
        Debug.Log("Overridden PostActivate to test " + this.name);
        base.PostActivate(src);
    }
}