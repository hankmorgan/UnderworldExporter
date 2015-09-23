using UnityEngine;
using System.Collections;

public class TileInfo : MonoBehaviour {


	//Texture info indices.
	public int east;
	public int west;
	public int north;
	public int south;
	public int top;
	public int bottom;

	public int AutoMapRenderType;

	public int DimX;
	public int DimY;

	public bool TileVisited;
	public bool isLava;
	public bool isWater;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

}
