using UnityEngine;
using System.Collections;

public class RuneSlot : MonoBehaviour {

	public static UWCharacter playerUW;
	public int SlotNumber;
	private UISprite label;

	//private int setRune=-1;
	static string[] Runes=new string[]{"An","Bet","Corp","Des",
		"Ex","Flam","Grav","Hur",
		"In","Jux","Kal","Lor",
		"Mani","Nox","Ort","Por",
		"Quas","Rel","Sanct","Tym",
		"Uus","Vas","Wis","Ylem"};
	// Use this for initialization
	void Start () {
		label = this.GetComponent<UISprite>();
	}
	
	// Update is called once per frame
	void Update () {
			if (playerUW.Runes[SlotNumber] != false)
			{
				label.spriteName= "rune_" + SlotNumber.ToString("D2");
			}
			else
			{
				label.spriteName= "rune_blank";
			}

	}


	public static string GetRuneName(int index)
	{
		return Runes[index];
	}

	void OnClick()
	{
		if (playerUW.Runes[SlotNumber] == false)
		{
			return;//Slot is unfilled
		}
		else
		{
			//add the rune to the first available active slot.
			//If all the slots are in use then push the stack down.
			if (playerUW.ActiveRunes[0]==-1)
			{
				playerUW.ActiveRunes[0]=SlotNumber;
			}
			else if(playerUW.ActiveRunes[1]==-1)
			{
				playerUW.ActiveRunes[1]=SlotNumber;
			}
			else if(playerUW.ActiveRunes[2]==-1)
			{
				playerUW.ActiveRunes[2]=SlotNumber;
			}
			else
			{//No free slot. Push everything down.
				playerUW.ActiveRunes[0]=playerUW.ActiveRunes[1];
				playerUW.ActiveRunes[1]=playerUW.ActiveRunes[2];
				playerUW.ActiveRunes[2]=SlotNumber;
			}
		}
	}
}
