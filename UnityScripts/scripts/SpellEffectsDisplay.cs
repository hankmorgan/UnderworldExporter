using UnityEngine;
using System.Collections;

public class SpellEffectsDisplay : MonoBehaviour {
	public int SlotNumber;
	public static UWCharacter playerUW;
	private int setSpell=-2;
	private UITexture thisSpell;

	void Start () {

		thisSpell = this.GetComponent<UITexture>();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerUW.ActiveSpell[SlotNumber] != setSpell)
		{
			setSpell= playerUW.ActiveSpell[SlotNumber];

			if (playerUW.ActiveSpell[SlotNumber]!=-1)
			{
				thisSpell.mainTexture= Resources.Load <Texture2D> ("HUD/Spells/spells_" + playerUW.ActiveSpell[SlotNumber].ToString("D4"));
			}
			else
			{
				thisSpell.mainTexture= Resources.Load <Texture2D> ("HUD/Runes/rune_blank");
			}
		}
	}
	
	void OnClick()
	{
		switch (UICamera.currentTouchID)
		{
		case -1://Left click
		{
			//TODO: actually cancel the effect!
			playerUW.ActiveSpell[SlotNumber]=-1;
			break;
		}
		case -2://right click
		{
			Debug.Log (setSpell);
			break;
		}
		}
	
	}
}
