using UnityEngine;
using System.Collections;

public class LevelChanger : MonoBehaviour {
	public string LevelName;
	public bool skipSave;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter()
	{
		if (skipSave==false)
		{
			//RoomManager.SaveCurrentRoom();
		}
		//RoomManager.LoadRoom(LevelName); TODO Replace this UNITY5
	}
}
