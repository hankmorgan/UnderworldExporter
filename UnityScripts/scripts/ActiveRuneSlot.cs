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
		if (playerUW.PlayerMagic.ActiveRunes[SlotNumber] != setRune)
		{
			setRune= playerUW.PlayerMagic.ActiveRunes[SlotNumber];
			if (playerUW.PlayerMagic.ActiveRunes[SlotNumber]!=-1)
			{
				thisRune.mainTexture= Resources.Load <Texture2D> ("HUD/Runes/rune_" + playerUW.PlayerMagic.ActiveRunes[SlotNumber].ToString("D2"));
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
		if (playerUW.PlayerMagic.ReadiedSpell=="")
		{
			playerUW.gameObject.GetComponent<Magic>().castSpell(playerUW.gameObject,playerUW.PlayerMagic.ActiveRunes[0],playerUW.PlayerMagic.ActiveRunes[1],playerUW.PlayerMagic.ActiveRunes[2],true);
		}
	}
}
