using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {


	public int WhoAmI;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void TalkTo()
	{
		Debug.Log("Talking to " + WhoAmI) ;
		Conversation x = (Conversation)this.GetComponent("Conversation_67");
		x.main();
		//Debug.Log (x.val);
	}
}
