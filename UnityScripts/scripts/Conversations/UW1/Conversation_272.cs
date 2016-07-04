using UnityEngine;
using System.Collections;

public class Conversation_272 : Conversation_268{

//Another Grey Goblin Variant
	//conversation #272
	//string block 0x0f10, name 

	public override IEnumerator main() {
		SetupConversation (3856);
		privateVariables[1] = 0;
		yield return StartCoroutine(func_029d());
		func_0012();
		yield return 0;
	} // end func
}
