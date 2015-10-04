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
	
	// Update is called once per frame
	void Update () {
	
	}
	public GameObject findDoor(int x, int y)
	{//Finds a door in the tile pointed to by two coordinates.
//		Debug.Log ("trying to find door called door_" +x .ToString ("D3") + "_" + y.ToString ("D3"));
		return GameObject.Find ("door_" +x .ToString ("D3") + "_" + y.ToString ("D3"));
	}

	public GameObject FindTile(int x, int y, int surface)
	{//May need to update tile finding to support multiple levels!
		string tileName = GetTileName (x,y,surface);
	//	Debug.Log("Looking for tile " + tileName);
		//Debug.Log ("level is " + level.name);
		return level.transform.FindChild (tileName).gameObject;
	}

	public string GetTileName(int x, int y, int surface)
	{//Assumes we'll only ever need to deal with open/solid tiles with floors and ceilings.
		string tileName;
		string X; string Y;
		X=x.ToString ("D2");
		Y=y.ToString ("D2");
		switch (surface)
		{
		case 3:  //SURFACE_WALL:
		{
			tileName= "Wall_" + X + "_" + Y;
			//sprintf_s(tileName, 20, "Tile_%02d_%02d\0", x, y);
			break;
		}
		case 2: //SURFACE_CEIL:
		{
			tileName="Ceiling_" + X + "_" + Y;
			//if (part == 0)
			//{
			//	sprintf_s(str, 20, "Ceiling_%02d_%02d\0", x, y);
			//}
			//else
			//{
			//	sprintf_s(str, 20, "Ceiling_%02d_%02d_%d\0", x, y, part);
			//}
			break;
		}
		case 1://SURFACE_FLOOR:
		case 4://SURFACE_SLOPE:
		default:
		{
			tileName="Tile_" + X  + "_" + Y;
			//if (part == 0)
			//{
			//	sprintf_s(str, 20, "Floor_%02d_%02d\0", x, y);
			//}
			//else
			//{
			//	sprintf_s(str, 20, "Floor_%02d_%02d_%d\0", x, y, part);
			//}
			break;
		}
		}
		return tileName;
	}


	public GameObject FindTileByName(string tileName)
	{//Finds the tile in the level.
		//Debug.Log("Looking for tile " + tileName);
		return level.transform.FindChild (tileName).gameObject;
	}
	public static string LookupString(int BlockNo, int StringNo)
	{//Finds the string
		return BlockNo + "_" + StringNo;
	}
}
