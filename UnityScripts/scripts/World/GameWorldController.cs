using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;
using System.Collections.Generic;

public class GameWorldController : UWEBase {
	/*Class for controlling the game world parameters*/

	//List<Material> AnimMaterials=new List<Material>();
	//List<int>AnimMaterialsIndex=new List<int>();
	//List<string>AnimatedTextures=new List<string>();
	public bool EnableTextureAnimation;
	public GameObject[] WorldModel =new GameObject[9];
	public GameObject[] LevelObjects =new GameObject[9];
	public static TextureController tc;
	//public bool hideCeil;
	public static GameWorldController instance;
	public int LevelNo;
	public Texture2D[] paletteArray= new Texture2D[8];
	public int paletteIndex=0;
	public int paletteIndexReverse=0;
	public int[] variables = new int[127];//Variables for the check/set variable traps
	private bool Test;
	public TileMap Tilemap;
	public UWCharacter playerUW;
	public MusicController mus;
	public GameObject InventoryMarker;
	//public Transform LevelMarker;//Where the gameobjects get stored
	public string game;
	public string UI_Name;
	public ObjectMasters objectMaster; //= new ObjectMasters();
	public Shader greyScale;
	//public MeshRenderer ceil;
		void Awake()
		{
			instance=this;
			UWEBase._RES = game;
			UWEBase._UI=UI_Name;
			objectMaster=new ObjectMasters();
			objectMaster.Load(Application.dataPath + "//..//" + UWEBase._RES + "_object_config.txt");

		}

	void Start () {
		instance=this;
		//ceil.enabled=!hideCeil;
		if (EnableTextureAnimation==true)
		{
			InvokeRepeating("UpdateAnimation",0.2f,0.2f);
		}
		//SwitchLevel(LevelNo);

		return;
	}

		public GameObject getCurrentLevelModel()
		{
			return GameWorldController.instance.WorldModel[LevelNo];
		}


	void UpdateAnimation()
	{
		//TODO:Fire and water effects appear to be in different directions to each other!!
		Shader.SetGlobalTexture ("_ColorPaletteIn",paletteArray[paletteIndex]);

		if (paletteIndex<paletteArray.GetUpperBound(0))
		{
			paletteIndex++;
		}
		else
		{
			paletteIndex=0;
		}

		//In Reverse

		Shader.SetGlobalTexture ("_ColorPaletteInReverse",paletteArray[paletteIndexReverse]);
		
		if (paletteIndexReverse>0)
		{
			paletteIndexReverse--;
		}
		else
		{
			paletteIndexReverse=paletteArray.GetUpperBound(0);
		}
		return;
	}

	public static GameObject findDoor(int x, int y)
	{//Finds a door in the tile pointed to by two coordinates.
		//		Debug.Log ("trying to find door called door_" +x .ToString ("D3") + "_" + y.ToString ("D3"));
		return GameObject.Find ("door_" +x .ToString ("D3") + "_" + y.ToString ("D3"));
	}

	public static GameObject FindTile(int x, int y, int surface)
	{//May need to update tile finding to support multiple levels!
		string tileName = GetTileName (x,y,surface);
		return instance.getCurrentLevelModel().transform.FindChild (tileName).gameObject;
	}
	
	public static string GetTileName(int x, int y, int surface)
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
	
	
	public static GameObject FindTileByName(string tileName)
	{//Finds the tile in the level.
		//Debug.Log("Looking for tile " + tileName);
		return instance.getCurrentLevelModel().transform.FindChild (tileName).gameObject;
	}

	public Transform LevelMarker()
	{
		return LevelObjects[LevelNo].transform;
	}

	public void SwitchLevel(int newLevelNo)
	{
		for (int i=0; i <=WorldModel.GetUpperBound(0);i++)
		{
			WorldModel[i].transform.parent.gameObject.SetActive(i==newLevelNo);
			LevelObjects[i].SetActive(i==newLevelNo);
		}	
		LevelNo=newLevelNo;
	}

}
