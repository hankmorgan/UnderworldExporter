using UnityEngine;
using System.Collections;

public class ActiveRuneSlot : MonoBehaviour {
	public int SlotNumber;
	public static UWCharacter playerUW;
	// Use this for initialization
	private int setRune=-2;
	private UITexture thisRune;

	private Texture2D[] runes=new Texture2D[24];
	private Texture2D blank;

	void Start () {
		//label = this.GetComponent<UISprite>();
		thisRune = this.GetComponent<UITexture>();
		for (int i =0;i<24;i++)
		{
			runes[i]=Resources.Load <Texture2D> ("HUD/Runes/rune_" + i.ToString("D2"));
		}
		blank= Resources.Load <Texture2D> ("HUD/Runes/rune_blank");
	}
	
	// Update is called once per frame
	void Update () {
		if (playerUW.PlayerMagic.ActiveRunes[SlotNumber] != setRune)
		{
			setRune= playerUW.PlayerMagic.ActiveRunes[SlotNumber];
			if (playerUW.PlayerMagic.ActiveRunes[SlotNumber]!=-1)
			{
				//thisRune.mainTexture= Resources.Load <Texture2D> ("HUD/Runes/rune_" + playerUW.PlayerMagic.ActiveRunes[SlotNumber].ToString("D2"));
				thisRune.mainTexture=runes[playerUW.PlayerMagic.ActiveRunes[SlotNumber]];
			}
			else
			{
				//label.spriteName= "rune_blank";
				//thisRune.mainTexture= Resources.Load <Texture2D> ("HUD/Runes/rune_blank");
				thisRune.mainTexture=blank;
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
