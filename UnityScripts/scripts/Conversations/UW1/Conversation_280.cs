using UnityEngine;
using System.Collections;

public class Conversation_280 : Conversation_277 {

	//could not find string block 0x0f17.
	//	conversation #280
	//		string block 0x0f18, name

	public override IEnumerator main() {
		SetupConversation (3864);
		privateVariables[1] = 0;
		yield return StartCoroutine(func_029d());
		func_0012();
		yield return 0;
	} // end func

}
