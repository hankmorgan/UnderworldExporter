using System;
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
		/// Array of game objects containing the nav meshes
		/// </summary>
	//public GameObject[] NavMeshes=new GameObject[9];
		/// <summary>
		/// Array of game objects containing the level objects
		/// </summary>
	//public GameObject[] LevelObjects =new GameObject[9];
	//public static TextureController tc;

	public GameObject LevelModel;
	
		/// <summary>
		/// The instance of this class
		/// </summary>
	public static GameWorldController instance;
		/// <summary>
		/// What level number we are currently on.
		/// </summary>

	public int LevelNo;

		public int startLevel=0;
		public Vector3 StartPos=new Vector3(38f, 4f, 2.7f);

		private static bool UpdateLevel;

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
	public TileMap[] Tilemaps = new TileMap[9];

	/// <summary>
	/// The player character.
	/// </summary>
	[SerializeField]
	private UWCharacter _playerUW;
	public UWCharacter playerUW {
		get { return _playerUW; }
		set { _playerUW=value; }
		}


	/// <summary>
	/// The music controller for the game
	/// </summary>
	private MusicController mus;


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
	/// The critter properties from objects.dat
	/// </summary>
	public Critters critter;

	/// <summary>
	/// Common Object Properties
	/// </summary>
	public CommonObjProps commobj;

	/// <summary>
	/// Weapon properties.
	/// </summary>
	public WeaponProps weaponprops;

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

	public string Lev_Ark_File;
	public string Graves_File;	
	
	public Material[] MaterialMasterList=new Material[260];

	public GameObject ObjectMarker;

	public ObjectLoader[] objectList= new ObjectLoader[9];

	public RAIN.Navigation.NavMesh.NavMeshRig NavRigLand;
	public RAIN.Navigation.NavMesh.NavMeshRig NavRigWater;//To implement for create npc

	void Awake()
	{
		//if(LevelSerializer.IsDeserializing)	return;
		instance=this;
		UWEBase._RES = game;
		objectMaster=new ObjectMasters();
		objectMaster.Load(Application.dataPath + "//..//" + UWEBase._RES + "_object_config.txt");
		critter = new Critters();
		critter.Load(Application.dataPath + "//..//" + UWEBase._RES + "_critters.txt");
		commobj=new CommonObjProps();
		commobj.Load(Application.dataPath + "//..//" + UWEBase._RES + "_comobj.txt");
		weaponprops =new WeaponProps();
		weaponprops.Load(Application.dataPath + "//..//" + UWEBase._RES + "_weapons.txt");
	}

	void Start () {
		char[] lev_ark;
		//if(LevelSerializer.IsDeserializing)	return;
		instance=this;

		//Load up my map materials
		for (int i =0; i<=MaterialMasterList.GetUpperBound(0);i++)
		{
			MaterialMasterList[i]=(Material)Resources.Load("UW1/Maps/Materials/uw1_" + i.ToString("d3"));
		}
		//Load up my tile maps
		//First read in my lev_ark file.
		if (DataLoader.ReadStreamFile(Lev_Ark_File, out lev_ark))
		{			
			for (int i=0; i<=Tilemaps.GetUpperBound(0);i++)
			{
				Tilemaps[i]=new TileMap();
				Tilemaps[i].thisLevelNo=i;
				Tilemaps[i].BuildTileMapUW(lev_ark,1,i);
				objectList[i]=new ObjectLoader();
				objectList[i].LoadObjectList( Tilemaps[i],lev_ark,1);
								//Tilemaps[i].setRooms();
								//Tilemaps[i].MergeWaterRegions();
								//Tilemaps[i].MergeLavaRegions();
				Tilemaps[i].CleanUp(1);//I can reduce the tile map complexity after I know about what tiles change due to objects
			}		
		}




		if (EnableTextureAnimation==true)
		{
			UWHUD.instance.CutsceneFullPanel.SetActive(false);
			InvokeRepeating("UpdateAnimation",0.2f,0.2f);
		}

		if ((AtMainMenu) && (!LevelSerializer.IsDeserializing))
		{
			SwitchLevel(-1);//Turn off all level maps
			UWHUD.instance.CutsceneFullPanel.SetActive(true);
			UWHUD.instance.mainmenu.gameObject.SetActive(true);
			//Freeze player movement and put them at a set location
			playerUW.playerController.enabled=false;
			playerUW.playerMotor.enabled=false;
			playerUW.transform.position=Vector3.zero;

			getMus().InIntro=true;
		}
		else
		{
			AtMainMenu=false;
			UWHUD.instance.CutsceneFullPanel.SetActive(false);	
			UWHUD.instance.mainmenu.gameObject.SetActive(false);


		}
		InvokeRepeating("PositionDetect",0.0f,0.02f);
		return;
	}

		/// <summary>
		/// Gets the current level model.
		/// </summary>
		/// <returns>The current level model gameobject</returns>
	public GameObject getCurrentLevelModel()
	{
		//return GameWorldController.instance.WorldModel[LevelNo].transform.FindChild("Level" + LevelNo + "_model").gameObject;
		return LevelModel;
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
		return ObjectMarker.transform;
		//return LevelObjects[LevelNo].transform;
	}

	/// <summary>
	/// Switches the level to another one. Disables the map and level objects of the old one.
	/// </summary>
	/// <param name="newLevelNo">New level no.</param>
		/// 
		public void SwitchLevel(int newLevelNo)
		{
			if (newLevelNo!=-1)
			{
				//Get my object info into the tile map.
				LevelNo=newLevelNo;
				TileMapRenderer.GenerateLevelFromTileMap(LevelModel,1,Tilemaps[newLevelNo]);
				ObjectLoader.RenderObjectList(objectList[newLevelNo],Tilemaps[newLevelNo],ObjectMarker);
				GenerateNavmesh(NavRigLand);
				GenerateNavmesh(NavRigWater);
						//TODO Lava
			}

		}

		/// <summary>
		/// Switchs the level and puts the player at the floor level of the new level
		/// </summary>
		/// <param name="newLevelNo">New level no.</param>
		/// <param name="newTileX">New tile x.</param>
		/// <param name="newTileY">New tile y.</param>
		public void SwitchLevel(int newLevelNo, int newTileX, int newTileY)
		{
				SwitchLevel(newLevelNo);
				float targetX=(float)newTileX*1.2f + 0.6f;
				float targetY= (float)newTileY*1.2f + 0.6f;
				float Height = ((float)(GameWorldController.instance.Tilemaps[newLevelNo].GetFloorHeight(newTileX,newTileY)))*0.15f;
				GameWorldController.instance.playerUW.transform.position=new Vector3(targetX,Height+0.1f,targetY);
		}

		// This will regenerate the navigation mesh when called
		void GenerateNavmesh(RAIN.Navigation.NavMesh.NavMeshRig NavRig)
		{//From Legacy.rivaltheory.com/forums/topics/runtime-navmesh-generation-and-path-finding-tutorial
				int _threadcount=4;
				// Unregister any navigation mesh we may already have (probably none if you are using this)
				NavRig.NavMesh.UnregisterNavigationGraph();
				NavRig.NavMesh.Size = 20;
				float startTime = Time.time;
				NavRig.NavMesh.StartCreatingContours(_threadcount);
				NavRig.NavMesh.CreateAllContours();
				float endTime = Time.time;
				Debug.Log("NavMesh generated in " + (endTime - startTime) + "s");
				NavRig.NavMesh.RegisterNavigationGraph();
				NavRig.Awake();

		}


	/*
	public void SwitchLevel(int newLevelNo)
	{
		for (int i=0; i <=WorldModel.GetUpperBound(0);i++)
		{
			if(WorldModel[i]==null)
			{
				WorldModel[i]=GameObject.Find("_Level" + i);
			}
			WorldModel[i].SetActive(i==newLevelNo);
			LevelObjects[i].SetActive(i==newLevelNo);
		}	
		LevelNo=newLevelNo;
	}*/

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

		public MusicController getMus()
		{
			if (mus==null)	
			{
				mus=GameObject.Find("_MusicController").GetComponent<MusicController>();
			}
			return mus;
		}


		public TileMap currentTileMap()
		{
			return Tilemaps[LevelNo];	
		}

		/// <summary>
		/// Detects where the player currently is an updates their swimming state and auto map as needed.
		/// </summary>
		public void PositionDetect()
		{
				if (AtMainMenu==true)
				{
						return;
				}
				TileMap.visitTileX =(int)(playerUW.transform.position.x/1.2f);
				TileMap.visitTileY =(int)(playerUW.transform.position.z/1.2f);
				currentTileMap().SetTileVisited(TileMap.visitTileX,TileMap.visitTileY);
				GameWorldController.instance.playerUW.isSwimming=((TileMap.OnWater) && (!GameWorldController.instance.playerUW.isWaterWalking)) ;

		}

		public ObjectLoader CurrentObjectList()
		{
				return objectList[LevelNo];
		}

}