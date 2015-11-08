using UnityEngine;
using System.Collections;

public class UWHUD : MonoBehaviour {
//Class for referencing other hud elements without having to search for them all the time.

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

 
}
