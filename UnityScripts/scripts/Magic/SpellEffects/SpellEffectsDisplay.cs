using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpellEffectsDisplay : GuiBase_Draggable {
	public int SlotNumber;
	//public static UWCharacter playerUW;
	private int setSpell=-1;
	private RawImage thisSpell;
	private static Texture2D SpellBlank;
	

	public override void Start()
	{
		base.Start();
		thisSpell = this.GetComponent<RawImage>();
		if (SpellBlank==null)
		{
			SpellBlank=	(Texture2D)Resources.Load <Texture2D> ("HUD/Runes/rune_blank");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (playerUW.ActiveSpell[SlotNumber] != null)
		{
			if (playerUW.ActiveSpell[SlotNumber].EffectIcon()!=setSpell)
			{
				setSpell= playerUW.ActiveSpell[SlotNumber].EffectIcon();
				if (setSpell > -1)
				{
					thisSpell.texture= Resources.Load <Texture2D> ("HUD/Spells/spells_" + playerUW.ActiveSpell[SlotNumber].EffectIcon().ToString("D4"));
				}
				else
				{
					thisSpell.texture= SpellBlank;//Resources.Load <Texture2D> ("HUD/Runes/rune_blank");
				}
			}
		}
		else
		{
			if (setSpell>=-1)
			{
				thisSpell.texture= SpellBlank;//Resources.Load <Texture2D> ("HUD/Runes/rune_blank");
				setSpell=-2;
			}
		}
	}

		public void OnClick(BaseEventData evnt)
		{
				if (Dragging){return;}
				PointerEventData pntr = (PointerEventData)evnt;
				//Debug.Log (pnt.pointerId);
				ClickEvent(pntr.pointerId);
		}
	
	void ClickEvent(int ptrID)
	{
		if (playerUW.ActiveSpell[SlotNumber]==null)
		{
			return;
		}
		switch (ptrID)
		{
		case -1://Left click
		{
			playerUW.ActiveSpell[SlotNumber].CancelEffect();
			break;
		}
		case -2://right click
		{
			playerUW.playerHud.MessageScroll.Add (playerUW.ActiveSpell[SlotNumber].getSpellDescription());
			break;
		}
		}
	
	}
}
