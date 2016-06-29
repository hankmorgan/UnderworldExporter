using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UWHUD : MonoBehaviour {
//Class for referencing other hud elements without having to search for them all the time.

	public ScrollController MessageScroll;

	public InputField InputControl;

	public CutsceneAnimation CutScenesSmall;
	public CutsceneAnimationFullscreen CutScenesFull;
	public HealthFlask HealthFlask;
	public HealthFlask ManaFlask;
	public Compass compass;
	public Dragons[] dragons;// new Dragons[2];
	public Eyes eyes;
	public StatsDisplay stats;
	public TradeSlot[] playerTrade ;//= new TradeSlot[4];
	public TradeSlot[] npcTrade ;//= new TradeSlot[4];
	public RawImage[] ConversationPortraits;
	public Text Encumberance;

	public RawImage MapDisplay;

	//Conversation Controls
	public ScrollController Conversation_tl;//Text output.

	public RawImage main_window;
	public WindowDetectUW window;

	public Camera hudCam;

	public GameObject ContainerOpened;
}


