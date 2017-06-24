using UnityEngine;
using System.Collections;
/// <summary>
/// A Talking Door!
/// </summary>
public class a_do_trap_conversation : trap_base {


	protected override void Start ()
	{
		base.Start ();
		//Set up this talking door!
		NPC_Door np =this.gameObject.AddComponent<NPC_Door>();
		np.npc_whoami=25;
		//this.gameObject.AddComponent<Conversation_25>();

	}

	public override bool Activate (object_base src,int triggerX, int triggerY, int State)
	{
		if (Conversation.InConversation==false)
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



	public override void PostActivate ()
	{//Do not destroy

	}

}

