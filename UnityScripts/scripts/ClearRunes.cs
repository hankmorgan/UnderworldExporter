using UnityEngine;
using System.Collections;

public class ClearRunes : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick()
	{
		//Debug.Log("Clearing Runes - find player");
		UWCharacter playerUW= GameObject.Find ("Gronk").GetComponent<UWCharacter>();
		if (playerUW!=null)
		{
			//Debug.Log("Clearing Runes");
			playerUW.PlayerMagic.ActiveRunes[0]=-1;
			playerUW.PlayerMagic.ActiveRunes[1]=-1;
			playerUW.PlayerMagic.ActiveRunes[2]=-1;
		}
	}
}
