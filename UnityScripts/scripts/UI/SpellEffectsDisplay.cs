using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpellEffectsDisplay : GuiBase_Draggable {
	public int SlotNumber;
	//public static UWCharacter UWCharacter.Instance;
	private int setSpell=-1;
	private RawImage thisSpell;
	private static Texture2D SpellBlank;
	

	public override void Start()
	{
		base.Start();
		thisSpell = this.GetComponent<RawImage>();
		if (SpellBlank==null)
		{
			SpellBlank=	(Texture2D)Resources.Load <Texture2D> (_RES +"/HUD/Runes/rune_blank");
		}
	}
	
	// Update is called once per frame
	public override void Update ()
	{
		base.Update();
		if (UWCharacter.Instance.ActiveSpell[SlotNumber] != null)
		{
			if (UWCharacter.Instance.ActiveSpell[SlotNumber].EffectIcon()!=setSpell)
			{
				setSpell= UWCharacter.Instance.ActiveSpell[SlotNumber].EffectIcon();
				if (setSpell > -1)
				{
					//thisSpell.texture= Resources.Load <Texture2D> (_RES +"/HUD/Spells/spells_" + UWCharacter.Instance.ActiveSpell[SlotNumber].EffectIcon().ToString("D4"));

					thisSpell.texture = GameWorldController.instance.SpellIcons.LoadImageAt(UWCharacter.Instance.ActiveSpell[SlotNumber].EffectIcon());
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
		if (UWCharacter.Instance.ActiveSpell[SlotNumber]==null)
		{
			return;
		}
		switch (ptrID)
		{
		case -1://Left click
		{
			UWCharacter.Instance.ActiveSpell[SlotNumber].CancelEffect();
			break;
		}
		case -2://right click
		{
			UWHUD.instance.MessageScroll.Add (UWCharacter.Instance.ActiveSpell[SlotNumber].getSpellDescription());
			break;
		}
		}
	
	}
}
