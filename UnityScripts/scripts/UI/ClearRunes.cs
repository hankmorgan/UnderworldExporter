using UnityEngine;
using System.Collections;

public class ClearRunes : GuiBase {
	//Removes the runes that the character has selected.
	public void OnClick()
	{
			
		//Debug.Log("Clearing Runes - find player");
		//UWCharacter playerUW= GameObject.Find ("Gronk").GetComponent<UWCharacter>();
		if (UWCharacter.Instance!=null)
		{
			//Debug.Log("Clearing Runes");
			UWCharacter.Instance.PlayerMagic.ActiveRunes[0]=-1;
			UWCharacter.Instance.PlayerMagic.ActiveRunes[1]=-1;
			UWCharacter.Instance.PlayerMagic.ActiveRunes[2]=-1;
			ActiveRuneSlot.UpdateRuneSlots();
		}
	}
}
