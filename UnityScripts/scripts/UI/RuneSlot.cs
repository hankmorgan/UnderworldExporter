using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RuneSlot : GuiBase {

	public static UWCharacter playerUW;
	public int SlotNumber;
	private RawImage thisRune;
	public bool isSet;
		/*
	static string[] Runes=new string[]{"An","Bet","Corp","Des",
		"Ex","Flam","Grav","Hur",
		"In","Jux","Kal","Lor",
		"Mani","Nox","Ort","Por",
		"Quas","Rel","Sanct","Tym",
		"Uus","Vas","Wis","Ylem"};*/
	// Use this for initialization
	public override void Start () {
		base.Start();
		thisRune = this.GetComponent<RawImage>();
		//thisRune.texture= Resources.Load <Texture2D> (_RES +"/HUD/Runes/rune_blank");
	}
	
	
	public static void UpdateRuneDisplay () {
		for  (int i=0; i<24; i++)
		{
						if (UWHUD.instance.runes[i].thisRune==null)
						{
								UWHUD.instance.runes[i].thisRune=UWHUD.instance.runes[i].gameObject.GetComponent<RawImage>();
						}
		if ((playerUW.PlayerMagic.PlayerRunes[i] != false))
			{					
				UWHUD.instance.runes[i].thisRune.texture=Resources.Load <Texture2D> (_RES +"/HUD/Runes/rune_" + i.ToString ("00"));
				UWHUD.instance.runes[i].isSet=true;
			}
			else
			{
				UWHUD.instance.runes[i].thisRune.texture=Resources.Load <Texture2D> (_RES +"/HUD/Runes/rune_blank");
				UWHUD.instance.runes[i].isSet=false;	
			}
		}

	}

		public void OnClick(BaseEventData evnt)
		{
				PointerEventData pntr = (PointerEventData)evnt;
				//Debug.Log (pnt.pointerId);
				ClickEvent(pntr.pointerId);
		}

		public void ClickEvent(int ptrID)
	{

		if (playerUW.PlayerMagic.PlayerRunes[SlotNumber] == false)
		{
			return;//Slot is unfilled
		}
		else
		{
			if (ptrID==-1)
			{//left click select the rune.
				//add the rune to the first available active slot.
				//If all the slots are in use then push the stack down.
				if (playerUW.PlayerMagic.ActiveRunes[0]==-1)
				{
					playerUW.PlayerMagic.ActiveRunes[0]=SlotNumber;
				}
				else if(playerUW.PlayerMagic.ActiveRunes[1]==-1)
				{
					playerUW.PlayerMagic.ActiveRunes[1]=SlotNumber;
				}
				else if(playerUW.PlayerMagic.ActiveRunes[2]==-1)
				{
					playerUW.PlayerMagic.ActiveRunes[2]=SlotNumber;
				}
				else
				{//No free slot. Push everything down.
					playerUW.PlayerMagic.ActiveRunes[0]=playerUW.PlayerMagic.ActiveRunes[1];
					playerUW.PlayerMagic.ActiveRunes[1]=playerUW.PlayerMagic.ActiveRunes[2];
					playerUW.PlayerMagic.ActiveRunes[2]=SlotNumber;
				}
				ActiveRuneSlot.UpdateRuneSlots();
			}
		else
			{//right click id the rune.
				UWHUD.instance.MessageScroll.Add ("You see " + StringController.instance.GetSimpleObjectNameUW(232+SlotNumber));
			}
		}

	}
}
