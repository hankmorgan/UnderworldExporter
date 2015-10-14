using UnityEngine;
using System.Collections;

public class ActiveRuneSlot : MonoBehaviour {
	public int SlotNumber;
	public static UWCharacter playerUW;
	// Use this for initialization
	private int setRune=-2;
	private UITexture thisRune;
	void Start () {
		//label = this.GetComponent<UISprite>();
		thisRune = this.GetComponent<UITexture>();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerUW.ActiveRunes[SlotNumber] != setRune)
		{
			setRune= playerUW.ActiveRunes[SlotNumber];
			//Debug.Log ("setting sprite to " +"rune_" + playerUW.ActiveRunes[SlotNumber].ToString("D2" ));
			if (playerUW.ActiveRunes[SlotNumber]!=-1)
			{
				//label.spriteName= "rune_" + playerUW.ActiveRunes[SlotNumber].ToString("D2");
//				Debug.Log ("HUD/Runes/rune_" + SlotNumber.ToString ("00"));
				thisRune.mainTexture= Resources.Load <Texture2D> ("HUD/Runes/rune_" + playerUW.ActiveRunes[SlotNumber].ToString("D2"));
			}
			else
			{
				//label.spriteName= "rune_blank";
				thisRune.mainTexture= Resources.Load <Texture2D> ("HUD/Runes/rune_blank");
			}
		}
	}

	void OnClick()
	{
	//cast spell. Readies it if possible.
		if (playerUW.ReadiedSpell=="")
		{
			playerUW.gameObject.GetComponent<Magic>().castSpell(playerUW.gameObject,playerUW.ActiveRunes[0],playerUW.ActiveRunes[1],playerUW.ActiveRunes[2],true);
		}
	}
}
