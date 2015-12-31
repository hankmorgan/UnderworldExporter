using UnityEngine;
using System.Collections;

public class ActiveRuneSlot : GuiBase {
	/*GUI element for displaying the select spell runes and for casting those selected runes.*/
	public int SlotNumber;
	private int setRune=-2;
	private UITexture thisRune;

	private Texture2D[] runes=new Texture2D[24];
	private Texture2D blank;

	void Start () {
		base.start();
		thisRune = this.GetComponent<UITexture>();
		for (int i =0;i<24;i++)
		{
			runes[i]=Resources.Load <Texture2D> ("HUD/Runes/rune_" + i.ToString("D2"));
		}
		blank= Resources.Load <Texture2D> ("HUD/Runes/rune_blank");
	}


	// Update is called once per frame
	void Update () {
		/*Checks the set value on the player and if different display the new rune.*/
		if (playerUW.PlayerMagic.ActiveRunes[SlotNumber] != setRune)
		{
			setRune= playerUW.PlayerMagic.ActiveRunes[SlotNumber];
			if (playerUW.PlayerMagic.ActiveRunes[SlotNumber]!=-1)
			{
				thisRune.mainTexture=runes[playerUW.PlayerMagic.ActiveRunes[SlotNumber]];
			}
			else
			{
				thisRune.mainTexture=blank;
			}
		}
	}

	void OnClick()
	{
		if (playerUW.playerHud.window.JustClicked==true)
		{
			return;
		}

		if (playerUW.PlayerMagic.ReadiedSpell=="")
		{
			if (playerUW.PlayerMagic.TestSpellCast(playerUW,playerUW.PlayerMagic.ActiveRunes[0],playerUW.PlayerMagic.ActiveRunes[1],playerUW.PlayerMagic.ActiveRunes[2]))
			{
				playerUW.PlayerMagic.castSpell(playerUW.gameObject,playerUW.PlayerMagic.ActiveRunes[0],playerUW.PlayerMagic.ActiveRunes[1],playerUW.PlayerMagic.ActiveRunes[2],true);
				playerUW.PlayerMagic.ApplySpellCost();
			}
		}
	}
}
