using UnityEngine;
using System.Collections;

public class Action_Moving_Platform : MonoBehaviour {

	public int TileX;
	public int TileY;
	public int TargetFloorHeight;
	public int TargetCeilingHeight;
	public int Flag;
	private GameObject level;
	public static TileMap tm;

	public void PerformAction()
	{

		GameObject floorTile;
		GameObject ceilTile;
		level=GameObject.Find("level");

		int CurrentCeilingHeight=tm.GlobalCeilingHeight - tm.GetCeilingHeight(TileX,TileY);
		int CurrentFloorHeight=tm.GetFloorHeight(TileX,TileY);
		int DisplacementFloor=TargetFloorHeight-CurrentFloorHeight;
		int DisplacementCeiling=(tm.GlobalCeilingHeight-TargetCeilingHeight)-CurrentCeilingHeight;

		floorTile=FindTile (TileX,TileY,1);
		ceilTile=FindTile (TileX,TileY,2);

		switch (Flag)
		{
		case 1://Floor only moves
			Debug.Log ("Displacement is " + DisplacementFloor);
			StartCoroutine(MoveTile (floorTile.transform, new Vector3(0f,+0.15f*DisplacementFloor,0f) ,0.5f));
			tm.SetFloorHeight(TileX,TileY,TargetFloorHeight);
			break;
		case 2://Ceiling only moves
			Debug.Log ("Displacement is " + DisplacementCeiling);
			StartCoroutine(MoveTile (ceilTile.transform, new Vector3(0f,+0.15f*DisplacementCeiling,0f) ,0.5f));
			tm.SetCeilingHeight(TileX,TileY,TargetCeilingHeight);
			break;
		case 3://Both move
			Debug.Log ("Displacement is " + DisplacementFloor);
			StartCoroutine(MoveTile (floorTile.transform, new Vector3(0f,+0.15f*DisplacementFloor,0f) ,0.5f));
			Debug.Log ("Displacement is " + DisplacementCeiling);
			StartCoroutine(MoveTile (ceilTile.transform, new Vector3(0f,+0.15f*DisplacementCeiling,0f) ,0.5f));
			tm.SetFloorHeight(TileX,TileY,TargetCeilingHeight);
			break;
		}

		Debug.Log (this.name + " Action Moving Platform");
	}

	IEnumerator MoveTile(Transform platform, Vector3 dist, float traveltime)
	{
		float rate = 1.0f/traveltime;
		float index = 0.0f;
		Vector3 StartPos = platform.position;
		Vector3 EndPos = StartPos + dist;
		
		while (index <1.0f)
		{
			platform.position = Vector3.Lerp (StartPos,EndPos,index);
			index += rate * Time.deltaTime;
			yield return new WaitForSeconds(0.01f);
		}
		platform.position = EndPos;
	}



	public GameObject FindTile(int x, int y, int surface)
	{
		string tileName = GetTileName (x,y,surface);
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
			break;
		}
		case 2: //SURFACE_CEIL:
		{
			tileName="Ceiling_" + X + "_" + Y;
			break;
		}
		case 1://SURFACE_FLOOR:
		case 4://SURFACE_SLOPE:
		default:
		{
			tileName="Tile_" + X  + "_" + Y;
			break;
		}
		}
		return tileName;
	}


}
