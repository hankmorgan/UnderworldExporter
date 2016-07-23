using UnityEngine;
using System.Collections;

public class a_text_string_trap : trap_base {
/*
 0190  a_text string trap
 causes the player to get a text message when it is set off. The
 "owner" field specifies string number per level, in game strings
 block 0009. The actual string number printed is (64*level + "owner")

*/
	public int StringNo;	//What string we are spitting out. (num is based on level no)
	public int StringBlock; //From what block the string is from.

	public override void ExecuteTrap (int triggerX, int triggerY, int State)
	{
		//CheckReferences();
		UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(StringBlock,StringNo));
	}

	public override void PostActivate ()
	{//Do not destroy.

	}

}
