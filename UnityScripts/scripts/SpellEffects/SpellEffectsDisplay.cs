using UnityEngine;
using System.Collections;

public class SpellEffectsDisplay : MonoBehaviour {
	public int SlotNumber;
	public static UWCharacter playerUW;
	private int setSpell=-1;
	private UITexture thisSpell;
	private static Texture2D SpellBlank;
	void Start () {

		thisSpell = this.GetComponent<UITexture>();
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
					thisSpell.mainTexture= Resources.Load <Texture2D> ("HUD/Spells/spells_" + playerUW.ActiveSpell[SlotNumber].EffectIcon().ToString("D4"));
				}
				else
				{
					thisSpell.mainTexture= SpellBlank;//Resources.Load <Texture2D> ("HUD/Runes/rune_blank");
				}
			}
		}
		else
		{
			if (setSpell>=-1)
			{
				thisSpell.mainTexture= SpellBlank;//Resources.Load <Texture2D> ("HUD/Runes/rune_blank");
				setSpell=-2;
			}
		}
	}
	
	void OnClick()
	{
		if (playerUW.ActiveSpell[SlotNumber]==null)
		{
			return;
		}
		switch (UICamera.currentTouchID)
		{
		case -1://Left click
		{
			//TODO: actually cancel the effect!
			playerUW.ActiveSpell[SlotNumber].CancelEffect();
			break;
		}
		case -2://right click
		{
			playerUW.GetMessageLog().text = playerUW.ActiveSpell[SlotNumber].getSpellDescription();
			//Debug.Log (setSpell);
			break;
		}
		}
	
	}
}
