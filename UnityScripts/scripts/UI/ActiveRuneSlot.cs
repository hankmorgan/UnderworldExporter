using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActiveRuneSlot : GuiBase_Draggable {
	/*GUI element for displaying the select spell runes and for casting those selected runes.*/
	//public int SlotNumber;
	//private int setRune=-2;
	private RawImage thisRune;

	private static Texture2D[] runes=new Texture2D[24];
	private static Texture2D blank;

	public override void Start()
	{
		base.Start();
		thisRune = this.GetComponent<RawImage>();
		for (int i =0;i<24;i++)
		{
			if (runes[i]==null)
			{
				runes[i]=GameWorldController.instance.ObjectArt.LoadImageAt(232 + i);
										//Resources.Load <Texture2D> (_RES +"/HUD/Runes/rune_" + i.ToString("D2"));					
			}
			
		}
		if (blank==null)
		{
				blank= Resources.Load <Texture2D> (_RES +"/HUD/Runes/rune_blank");				
		}		
		
	}



	public static void UpdateRuneSlots () {
		/*Checks the set value on the player and if different display the new rune.*/
		for (int i=0; i<3;i++)
		{
				if (GameWorldController.instance.playerUW.PlayerMagic.ActiveRunes[i]!=-1)
				{
					UWHUD.instance.activeRunes[i].thisRune.texture = runes[GameWorldController.instance.playerUW.PlayerMagic.ActiveRunes[i]];				
				}
				else
				{
						UWHUD.instance.activeRunes[i].thisRune.texture=blank;	
				}
			
		}

				/*
		if (GameWorldController.instance.playerUW.PlayerMagic.ActiveRunes[SlotNumber] != setRune)
		{
			setRune= GameWorldController.instance.playerUW.PlayerMagic.ActiveRunes[SlotNumber];
			if (GameWorldController.instance.playerUW.PlayerMagic.ActiveRunes[SlotNumber]!=-1)
			{
				
				thisRune.texture=runes[GameWorldController.instance.playerUW.PlayerMagic.ActiveRunes[SlotNumber]];
			}
			else
			{
				thisRune.texture=blank;
			}
		}*/
	}

	public void OnClick()
	{
		if ((UWHUD.instance.window.JustClicked==true) || (Dragging==true))
		{
			return;
		}
		if ((WindowDetectUW.InMap==true) || (WindowDetectUW.WaitingForInput) || (ConversationVM.InConversation)){return;}

		if (GameWorldController.instance.playerUW.PlayerMagic.ReadiedSpell=="")
		{
			if (GameWorldController.instance.playerUW.PlayerMagic.TestSpellCast(GameWorldController.instance.playerUW,GameWorldController.instance.playerUW.PlayerMagic.ActiveRunes[0],GameWorldController.instance.playerUW.PlayerMagic.ActiveRunes[1],GameWorldController.instance.playerUW.PlayerMagic.ActiveRunes[2]))
			{
				GameWorldController.instance.playerUW.PlayerMagic.castSpell(GameWorldController.instance.playerUW.gameObject,GameWorldController.instance.playerUW.PlayerMagic.ActiveRunes[0],GameWorldController.instance.playerUW.PlayerMagic.ActiveRunes[1],GameWorldController.instance.playerUW.PlayerMagic.ActiveRunes[2],true);
				GameWorldController.instance.playerUW.PlayerMagic.ApplySpellCost();
			}
		}
	}
}
