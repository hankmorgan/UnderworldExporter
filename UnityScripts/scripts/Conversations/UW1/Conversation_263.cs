using UnityEngine;
using System.Collections;

public class Conversation_263 : Conversation_262 {
	//Another variant of green goblin
	//Technically it uses a different string block but it appears identical.
	//conversation #263
	//string block 0x0f07, name 
	public override IEnumerator main() {
		SetupConversation (3847);
		privateVariables[1] = 0;
		yield return StartCoroutine(func_029d());	
		func_0012();
		yield return 0;
	} // end func
}
