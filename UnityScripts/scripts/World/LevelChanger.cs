using UnityEngine;
using System.Collections;

public class LevelChanger : MonoBehaviour {
	public string LevelName;
	public bool skipSave;


	void OnTriggerEnter()
	{
		if (skipSave==false)
		{
			//RoomManager.SaveCurrentRoom();
		}
		//RoomManager.LoadRoom(LevelName); TODO Replace this UNITY5
	}
}
