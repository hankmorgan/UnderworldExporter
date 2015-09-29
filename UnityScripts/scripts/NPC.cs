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
		//Debug.Log("Talking to " + WhoAmI) ;
		chains.ActiveControl=3;//Enable UI Elements
		Conversation x = (Conversation)this.GetComponent("Conversation_67");
		Conversation.CurrentConversation=WhoAmI;
		Conversation.InConversation=true;
		Conversation.maincam=Camera.main;

		Camera.main.enabled = false;
		StartCoroutine(x.main ());
		//Debug.Log (x.val);
	}
}
