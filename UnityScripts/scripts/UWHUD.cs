using UnityEngine;
using System.Collections;

public class UWHUD : MonoBehaviour {
//Class for referencing other hud elements without having to search for them all the time.

	public ScrollController MessageScroll;
	public ScrollController MessageScrollTemp;
	public UIInput InputControl;

	public CutsceneAnimation CutScenesSmall;
	public HealthFlask HealthFlask;
	public HealthFlask ManaFlask;
	public Compass compass;
	public Dragons[] dragons;// new Dragons[2];
	public Eyes eyes;
	public StatsDisplay stats;
	public TradeSlot[] playerTrade ;//= new TradeSlot[4];
	public TradeSlot[] npcTrade ;//= new TradeSlot[4];
	public UITexture[] ConversationPortraits;
	public UILabel Encumberance;

	//Conversation Controls

	//public ScrollController Conversation_Scroll;
	public UITextList Conversation_tl;//Text output.
	//public UITextList Conversation_tl_input;//player choices
	//public UITexture Conversation_OutPutControl;//Where the conversation is printed out
	public UWFonts Conversation_FontController;

	public UITexture main_window;
	public WindowDetectUW window;
}


