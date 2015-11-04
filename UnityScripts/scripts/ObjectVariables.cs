using UnityEngine;
using System.Collections;

public class ObjectVariables : MonoBehaviour {

	//USED IN SHOCK ONLY
	public int triggerX;
	public int triggerY;
	public int Hidden;//Is the object visible
	public int state;

	public string trigger;
	private GameObject level;

//public string SpriteNameOpened;
	//public string triggeringObject;

	// Use this for initialization
	void Start () {
		level=GameObject.Find("level");
	}
	
	public GameObject findDoor(int x, int y)
	{//Finds a door in the tile pointed to by two coordinates.
//		Debug.Log ("trying to find door called door_" +x .ToString ("D3") + "_" + y.ToString ("D3"));
		return GameObject.Find ("door_" +x .ToString ("D3") + "_" + y.ToString ("D3"));
	}


	//public static string LookupString(int BlockNo, int StringNo)
	//{//Finds the string
	//	return BlockNo + "_" + StringNo;
	//}
}
