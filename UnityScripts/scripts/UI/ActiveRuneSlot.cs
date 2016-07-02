using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActiveRuneSlot : GuiBase_Draggable {
	/*GUI element for displaying the select spell runes and for casting those selected runes.*/
	public int SlotNumber;
	private int setRune=-2;
	private RawImage thisRune;

	private Texture2D[] runes=new Texture2D[24];
	private Texture2D blank;

	public override void Start()
	{
		base.Start();
		thisRune = this.GetComponent<RawImage>();
		for (int i =0;i<24;i++)
		{
			runes[i]=Resources.Load <Texture2D> ("UW1/HUD/Runes/rune_" + i.ToString("D2"));
		}
		blank= Resources.Load <Texture2D> ("UW1/HUD/Runes/rune_blank");
	}


	// Update is called once per frame
	void Update () {
		/*Checks the set value on the player and if different display the new rune.*/
		if (playerUW.PlayerMagic.ActiveRunes[SlotNumber] != setRune)
		{
			setRune= playerUW.PlayerMagic.ActiveRunes[SlotNumber];
			if (playerUW.PlayerMagic.ActiveRunes[SlotNumber]!=-1)
			{
				thisRune.texture=runes[playerUW.PlayerMagic.ActiveRunes[SlotNumber]];
			}
			else
			{
				thisRune.texture=blank;
			}
		}
	}

	public void OnClick()
	{
		if ((playerUW.playerHud.window.JustClicked==true) || (Dragging==true))
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
