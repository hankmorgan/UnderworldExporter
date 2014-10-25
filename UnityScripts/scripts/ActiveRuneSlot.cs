using UnityEngine;
using System.Collections;

public class ActiveRuneSlot : MonoBehaviour {
	public int SlotNumber;
	public static UWCharacter playerUW;
	// Use this for initialization
	private int setRune=-2;
	private UISprite label;
	void Start () {
		label = this.GetComponent<UISprite>();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerUW.ActiveRunes[SlotNumber] != setRune)
		{
			setRune= playerUW.ActiveRunes[SlotNumber];
			//Debug.Log ("setting sprite to " +"rune_" + playerUW.ActiveRunes[SlotNumber].ToString("D2" ));
			if (playerUW.ActiveRunes[SlotNumber]!=-1)
			{
				label.spriteName= "rune_" + playerUW.ActiveRunes[SlotNumber].ToString("D2");
			}
			else
			{
				label.spriteName= "rune_blank";
			}
		}
	}

	void OnClick()
	{
	//cast spell
		Magic.castSpell(playerUW.ActiveRunes[0],playerUW.ActiveRunes[1],playerUW.ActiveRunes[2]);
	}
}
