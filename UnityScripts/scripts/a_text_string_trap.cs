using UnityEngine;
using System.Collections;

public class a_text_string_trap : trap_base {

	public int StringNo;	//What string we are spitting out. (num is based on level no)
	public int StringBlock; //From what block the string is from.


	public override void ExecuteTrap (int triggerX, int triggerY, int State)
	{
		CheckReferences();
		playerUW.GetMessageLog ().text = playerUW.StringControl.GetString(StringBlock,StringNo);
	}

}
