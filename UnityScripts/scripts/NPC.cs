using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {


	public int WhoAmI;
	public static UWCharacter playerUW;

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
		chains.Refresh();

		UITexture portrait = GameObject.Find ("Conversation_Portrait_Right").GetComponent<UITexture>();
		portrait.mainTexture=Resources.Load <Texture2D> ("HUD/PlayerHeads/heads_"+ (playerUW.Body).ToString("0000"));
		
		if (this.WhoAmI<=28)
		{
			//head in charhead.gr
			portrait = GameObject.Find ("Conversation_Portrait_Left").GetComponent<UITexture>();
			portrait.mainTexture=Resources.Load <Texture2D> ("HUD/Charheads/charhead_"+ (WhoAmI-1).ToString("0000"));
			
		}	
		else
		{
			//head in charhead.gr
			int HeadToUse = this.GetComponent<ObjectInteraction>().item_id-64;
			if (HeadToUse >59)
			{
				HeadToUse=0;
			}
			portrait = GameObject.Find ("Conversation_Portrait_Left").GetComponent<UITexture>();
			portrait.mainTexture=Resources.Load <Texture2D> ("HUD/genhead/genhead_"+ (HeadToUse).ToString("0000"));
		}



		Conversation x = (Conversation)this.GetComponent("Conversation_67");
		Conversation.CurrentConversation=WhoAmI;
		Conversation.InConversation=true;
		Conversation.maincam=Camera.main;

		Camera.main.enabled = false;
		StartCoroutine(x.main ());
		//Debug.Log (x.val);
	}
}
