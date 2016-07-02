using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RuneSlot : MonoBehaviour {

	public static UWCharacter playerUW;
	public int SlotNumber;
	private RawImage thisRune;
	private bool isSet;
		/*
	static string[] Runes=new string[]{"An","Bet","Corp","Des",
		"Ex","Flam","Grav","Hur",
		"In","Jux","Kal","Lor",
		"Mani","Nox","Ort","Por",
		"Quas","Rel","Sanct","Tym",
		"Uus","Vas","Wis","Ylem"};*/
	// Use this for initialization
	void Start () {
		thisRune = this.GetComponent<RawImage>();
		thisRune.texture= Resources.Load <Texture2D> ("UW1/HUD/Runes/rune_blank");
	}
	
	// Update is called once per frame
	void Update () {
			if ((playerUW.PlayerMagic.PlayerRunes[SlotNumber] != false) && (isSet == false))
			{
				thisRune.texture= Resources.Load <Texture2D> ("UW1/HUD/Runes/rune_" + SlotNumber.ToString ("00"));
				isSet=true;
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
			}
		else
			{//right click id the rune.
				playerUW.playerHud.MessageScroll.Add ("You see " + playerUW.StringControl.GetSimpleObjectNameUW(232+SlotNumber));
			}
		}

	}
}
