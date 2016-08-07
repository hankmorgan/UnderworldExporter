using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Game world controller for controlling references and various global activities
/// </summary>
public class GameWorldController : UWEBase {

		/// <summary>
		/// Enables texture animation effects
		/// </summary>
	public bool EnableTextureAnimation;

		/// <summary>
		/// Array of game objects containing the level meshes
		/// </summary>
	public GameObject[] WorldModel =new GameObject[9];
		/// <summary>
		/// Array of game objects containing the level objects
		/// </summary>
	public GameObject[] LevelObjects =new GameObject[9];
	//public static TextureController tc;

		/// <summary>
		/// The instance of this class
		/// </summary>
	public static GameWorldController instance;
		/// <summary>
		/// What level number we are currently on.
		/// </summary>
	public int LevelNo;
	/// <summary>
	/// Array of cycled game palettes for animatione effects.
	/// </summary>
	public Texture2D[] paletteArray= new Texture2D[8];
	/// <summary>
	/// The index of the palette currently in use
	/// </summary>
	public int paletteIndex=0;
	/// <summary>
	/// The palette index when going in reverse.
	/// </summary>
	public int paletteIndexReverse=0;
	/// <summary>
	/// The Variables for the check/set variable traps
	/// </summary>
	public int[] variables = new int[127];
	
	/// <summary>
	/// The tilemap class for the game
	/// </summary>
	public TileMap Tilemap;
	/// <summary>
	/// The player character.
	/// </summary>
	public UWCharacter playerUW;
	/// <summary>
	/// The music controller for the game
	/// </summary>
	public MusicController mus;
	/// <summary>
	/// The game object that picked up items are parented to.
	/// </summary>
	public GameObject InventoryMarker;
	/// <summary>
	/// The game name.
	/// </summary>
	/// Value is passed to UWEBase and used in all resource file loads
	public string game;
	//public string UI_Name;
	/// <summary>
	/// The object master class for storing and reading object properties in an external file
	/// </summary>
	public ObjectMasters objectMaster;
	/// <summary>
	/// The grey scale shader. Reference to allow loading of a hidden shader.
	/// </summary>
	public Shader greyScale;

		/// <summary>
		/// The vortex effect shader.  Reference to allow loading of a hidden shader.
		/// </summary>
		public Shader vortex;

	/// <summary>
	/// Is the game at the main menu or should it start at the mainmenu.
	/// </summary>
	public bool AtMainMenu;

	void Awake()
	{
		instance=this;
		UWEBase._RES = game;
		objectMaster=new ObjectMasters();
		objectMaster.Load(Application.dataPath + "//..//" + UWEBase._RES + "_object_config.txt");
	}

	void Start () {
		instance=this;
		if (EnableTextureAnimation==true)
		{
			InvokeRepeating("UpdateAnimation",0.2f,0.2f);
		}
		if (AtMainMenu)
		{
			SwitchLevel(-1);//Turn off all level maps
			//Freeze player movement and put them at a set location
			playerUW.playerController.enabled=false;
			playerUW.playerMotor.enabled=false;
			playerUW.transform.position=Vector3.zero;
			mus.InIntro=true;
		}
		return;
	}

	public GameObject getCurrentLevelModel()
	{
		return GameWorldController.instance.WorldModel[LevelNo];
	}

	/// <summary>
	/// Updates the global shader parameter for the colorpalette shaders at set intervals. To enable texture animation
	/// </summary>
	void UpdateAnimation()
	{
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

	/// <summary>
	/// inds a door in the tile pointed to by the two coordinates.
	/// </summary>
	/// <returns>The door.</returns>
	/// <param name="x">The x coordinate.</param>
	/// <param name="y">The y coordinate.</param>
	public static GameObject findDoor(int x, int y)
	{
		return GameObject.Find ("door_" +x .ToString ("D3") + "_" + y.ToString ("D3"));
	}

	/// <summary>
	/// Finds the tile or wall at the specified coordinates.
	/// </summary>
	/// <returns>The tile.</returns>
	/// <param name="x">The x coordinate.</param>
	/// <param name="y">The y coordinate.</param>
	/// <param name="surface">Surface.</param>
	public static GameObject FindTile(int x, int y, int surface)
	{
		string tileName = GetTileName (x,y,surface);
		return instance.getCurrentLevelModel().transform.FindChild (tileName).gameObject;
	}

	


	
		/// <summary>
		/// Gets the gameobject name for the specified tile x,y and surface. Eg Wall_02_03, Tile_22_23
		/// </summary>
		/// <returns>The tile name.</returns>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="surface">Surface.</param>
		/// Surfaces are 
	public static string GetTileName(int x, int y, int surface)
	{//Assumes we'll only ever need to deal with open/solid tiles with floors and ceilings.
		string tileName;
		string X; string Y;
		X=x.ToString ("D2");
		Y=y.ToString ("D2");
		switch (surface)
		{
		case TileMap.SURFACE_WALL:  //SURFACE_WALL:
		{
			tileName= "Wall_" + X + "_" + Y;
			break;
		}
		case TileMap.SURFACE_CEIL: //SURFACE_CEIL:
		{
			tileName="Ceiling_" + X + "_" + Y;
			break;
		}
		case TileMap.SURFACE_FLOOR:
		case TileMap.SURFACE_SLOPE:
		default:
		{
			tileName="Tile_" + X  + "_" + Y;
			break;
		}
		}
		return tileName;
	}
	
	/// <summary>
	/// Finds a tile in the current level by name
	/// </summary>
	/// <returns>The tile by name.</returns>
	/// <param name="tileName">Tile name.</param>
	public static GameObject FindTileByName(string tileName)
	{
		return instance.getCurrentLevelModel().transform.FindChild (tileName).gameObject;
	}
	
	/// <summary>
	/// Returns the transform of the levels object marker. So objects will remain on that level
	/// </summary>
	/// <returns>The marker.</returns>
	public Transform LevelMarker()
	{
		return LevelObjects[LevelNo].transform;
	}

	/// <summary>
	/// Switches the level to another one. Disables the map and level objects of the old one.
	/// </summary>
	/// <param name="newLevelNo">New level no.</param>
	public void SwitchLevel(int newLevelNo)
	{
		for (int i=0; i <=WorldModel.GetUpperBound(0);i++)
		{
			WorldModel[i].transform.parent.gameObject.SetActive(i==newLevelNo);
			LevelObjects[i].SetActive(i==newLevelNo);
		}	
		LevelNo=newLevelNo;
	}

	/// <summary>
	/// Freezes the movement of the specified object if it has a rigid body attached.
	/// </summary>
	/// <param name="myObj">My object.</param>
	public static void FreezeMovement(GameObject myObj)
	{//Stop objects which can move in the 3d world from moving when they are in the inventory or containers.
			Rigidbody rg = myObj.GetComponent<Rigidbody>();
			if (rg!=null)
			{
					rg.useGravity=false;
					rg.constraints = 
							RigidbodyConstraints.FreezeRotationX 
							| RigidbodyConstraints.FreezeRotationY 
							| RigidbodyConstraints.FreezeRotationZ 
							| RigidbodyConstraints.FreezePositionX 
							| RigidbodyConstraints.FreezePositionY 
							| RigidbodyConstraints.FreezePositionZ;
			}
	}

		/// <summary>
		/// Unfreeze the movement of the specified object if it has a rigid body attached.
		/// </summary>
		/// <param name="myObj">My object.</param>
		public static void UnFreezeMovement(GameObject myObj)
		{//Allow objects which can move in the 3d world to moving when they are released.
				Rigidbody rg = myObj.GetComponent<Rigidbody>();
				if (rg!=null)
				{
						rg.useGravity=true;
						rg.constraints = 
								RigidbodyConstraints.FreezeRotationX 
								| RigidbodyConstraints.FreezeRotationY 
								| RigidbodyConstraints.FreezeRotationZ;

				}
		}
}