using UnityEngine;
using System.Collections;

public class ObjectVariables : MonoBehaviour {

	public int triggerX;
	public int triggerY;
	public int Hidden;//Is the object visible

	public string trigger;
	private GameObject level;
	// Use this for initialization
	void Start () {
		level=GameObject.Find("uw1_level0");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public GameObject FindTile(int x, int y, int surface)
	{//May need to update tile finding to support multiple levels!
		string tileName = GetTileName (x,y,surface);
		Debug.Log("Looking for tile" + tileName);
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
			tileName= "Tile_" + X + "_" + Y;
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
			tileName="Floor_" + X  + "_" + Y;
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
}
