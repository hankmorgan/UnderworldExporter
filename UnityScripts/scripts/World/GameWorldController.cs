using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

using UnityEngine.UI;

/// <summary>
/// Game world controller for controlling references and various global activities
/// </summary>

public class GameWorldController : UWEBase {

		public WhatTheHellIsSCD_ARK whatTheHellIsThatFileFor;

		public enum UW1_LevelNames
		{
				EntranceLevel=0,
				MountainMen=1,
				Swamp=2,
				Trolls=3,
				Catacombs=4,
				Seers=5,
				Tybal=6,
				Volcano=7,
				Ethereal=8
		};

		public enum UW2_LevelNames
		{
				Britannia0=0,	
				Britannia1=1,
				Britannia2=2,
				Britannia3=3,
				Britannia4=0,
				Prison0=8,
				Prison1=9,
				Prison2=10,
				Prison3=11,
				Prison4=12,
				Prison5=13,
				Prison6=14,
				Prison7=15,
				Killorn0=16,
				Killorn1=17,
				Ice0=24,
				Ice1=25,
				Talorus0=32,
				Talorus1=33,
				Academy0=40,
				Academy1=41,
				Academy2=42,
				Academy3=43,
				Academy4=44,
				Academy5=45,
				Academy6=46,
				Academy7=47,
				Tomb0=48,
				Tomb1=49,
				Tomb2=50,
				Tomb3=51,
				Pits0=56,
				Pits1=57,
				Pits2=58,
				Ethereal0=64,
				Ethereal1=65,
				Ethereal2=66,
				Ethereal3=67,
				Ethereal4=68,
				Ethereal5=69,
				Ethereal6=70,
				Ethereal7=71,
				Ethereal8=72
		};



		[Header("Controls")]
		public MouseLook MouseX;
		public MouseLook MouseY;


		[Header("World Options")]

		/// <summary>
		/// Generate Nav meshes or not
		/// </summary>
		public bool bGenNavMeshes=true;

		/// <summary>
		/// Enables texture animation effects
		/// </summary>
		public bool EnableTextureAnimation;

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


		/// <summary>
		/// Enable timer triggers
		/// </summary>
		public bool EnableTimerTriggers=true;

		/// <summary>
		/// The timer execution rate.
		/// </summary>
		public float TimerRate = 1f;


		[Header("Parent Objects")]
		/// <summary>
		/// The level model parent object
		/// </summary>
		public GameObject LevelModel;

		public GameObject TNovaLevelModel;

		/// <summary>
		/// The level model parent object
		/// </summary>
		public GameObject SceneryModel;


		/// <summary>
		/// Gameobject to load the objects at
		/// </summary>
		public GameObject _ObjectMarker;

		/// <summary>
		/// The instance of this class
		/// </summary>
		public static GameWorldController instance;

		/// <summary>
		/// The game object that picked up items are parented to.
		/// </summary>
		public GameObject InventoryMarker;

		[Header("Level")]
		/// <summary>
		/// What level number we are currently on.
		/// </summary>	
		public short LevelNo;


		public static bool LoadingGame=false;

		/// <summary>
		/// What level the player starts on in a quick start
		/// </summary>
		public short startLevel=0;
		/// <summary>
		/// What start position for the player.
		/// </summary>
		public Vector3 StartPos=new Vector3(38f, 4f, 2.7f);




		[Header("Palettes")]
		/// <summary>
		/// Array of cycled game palettes for animation effects.
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
		/// Shared palettes for artwork
		/// </summary>
		public PaletteLoader palLoader;


		[Header("LevelMaps")]
		/// <summary>
		/// The tilemap class for the game
		/// </summary>
		public TileMap[] Tilemaps = new TileMap[9];


		/// <summary>
		/// The auto maps.
		/// </summary>
		public AutoMap[] AutoMaps = new AutoMap[9];

		/// <summary>
		/// The object lists for each level.
		/// </summary>
		public ObjectLoader[] objectList= new ObjectLoader[9];


		/// <summary>
		/// The music controller for the game
		/// </summary>
		private MusicController mus;



		[Header("Property Lists")]
		/// <summary>
		/// The object master class for storing and reading object properties in an external file
		/// </summary>
		public ObjectMasters objectMaster;

		/// <summary>
		/// The critter properties from objects.dat
		/// </summary>
		public Critters critterData;


		/// <summary>
		/// The object dat file
		/// </summary>
		public ObjectDatLoader objDat;

		/// <summary>
		/// The common object properties for uw
		/// </summary>
		public CommonObjectDatLoader commonObject;

		public ObjectPropLoader ShockObjProp;

		/// <summary>
		/// The terrain data from terrain.dat
		/// </summary>
		public TerrainDatLoader terrainData;




		[Header("Paths")]
		public string Lev_Ark_File_Selected = "Data\\Lev.ark";
		public string SCD_Ark_File_Selected = "Data\\SCD.ark";
		//Game paths
		public string path_uw0;
		public string path_uw1;
		public string path_uw2;
		public string path_shock;
		public string path_tnova;

		[Header("Material Lists")]
		/// <summary>
		/// The material master list for matching the texture list to materials.
		/// </summary>
		public Material[] MaterialMasterList=new Material[260];

		public Material[] SpecialMaterials=new Material[1];

		/// <summary>
		/// The materials for doors  (doors.gr)
		/// </summary>
		public Material[] MaterialDoors=new Material[13];

		/// <summary>
		/// The materials for tmobj + models (tmobj.gr)
		/// </summary>
		public Material[] MaterialObj=new Material[54];

		/// <summary>
		/// The default model material.
		/// </summary>
		public Material modelMaterial;


		[Header("Nav Meshes")]
		public RAIN.Navigation.NavMesh.NavMeshRig NavRigLand;
		public RAIN.Navigation.NavMesh.NavMeshRig NavRigWater;//To implement for create npc


		[Header("Art Loaders")]
		/// <summary>
		/// The bytloader for bty files
		/// </summary>
		public BytLoader bytloader;
		/// <summary>
		/// The tex loader for textures
		/// </summary>
		public TextureLoader texLoader;
		/// <summary>
		/// The spell icons gr loader
		/// </summary>
		public GRLoader SpellIcons;
		/// <summary>
		/// The object art gr loader
		/// </summary>
		public GRLoader ObjectArt;

		/// <summary>
		/// The door art.
		/// </summary>
		public GRLoader DoorArt;

		/// <summary>
		/// The tm object art.
		/// </summary>
		public GRLoader TmObjArt;

		/// <summary>
		/// The tm flat art.
		/// </summary>
		public GRLoader TmFlatArt;

		/// <summary>
		/// Small animations art.
		/// </summary>
		public GRLoader TmAnimo;

		/// <summary>
		/// The lev ark file data.
		/// </summary>
		private char[] lev_ark_file_data;

		/// <summary>
		/// The female armor
		/// </summary>
		public GRLoader armor_f;

		/// <summary>
		/// The male armor.
		/// </summary>
		public GRLoader armor_m;

		/// <summary>
		/// The cursors art
		/// </summary>
		public GRLoader grCursors;

		/// <summary>
		/// The health & mana flasks.
		/// </summary>
		public GRLoader grFlasks;

		/// <summary>
		/// The option menus
		/// </summary>
		public GRLoader grOptbtns;

		/// <summary>
		/// The Compass 
		/// </summary>
		public GRLoader grCompass;

		/// <summary>
		/// Cutscene data
		/// </summary>
		public CutsLoader cutsLoader;

		public CritLoader[] critsLoader= new CritLoader[64];

		/// <summary>
		/// The weapon animation frames.
		/// </summary>
		public WeaponAnimation weaps;
		//public WeaponAnimationPlayer WeaponAnim;
		public WeaponsLoader weapongr;

		public int difficulty=1; //1=standard, 0=easy.

		public static bool LoadingObjects=false;

		public struct bablGlobal
		{
				public int ConversationNo;
				public int Size;
				public int[] Globals;
		};

		public bablGlobal[] bGlobals;
		public ConversationVM convVM;

		public static bool WorldReRenderPending=false;
		public static bool ObjectReRenderPending=false;
		public static bool FullReRender=false;



		public KeyBindings keybinds;

		public event_processor events;

		private int startX=-1; private int startY=-1;


		void LoadPath(string _RES)
		{
				string path="";

				switch(_RES)
				{
				case GAME_UWDEMO: path=GameWorldController.instance.path_uw0;break;
				case GAME_UW1: path=GameWorldController.instance.path_uw1;break;
				case GAME_UW2:path=GameWorldController.instance.path_uw2;break;
				case GAME_SHOCK:path=GameWorldController.instance.path_shock;break;
				case GAME_TNOVA:path=GameWorldController.instance.path_tnova;break;
						break;
				}

				Loader.BasePath= path; 
				if (Loader.BasePath.EndsWith("\\") !=true)
				{
						Loader.BasePath = Loader.BasePath + "\\";
				}
		}

		/// <summary>
		/// Awake this instance.
		/// </summary>
		/// Should be the very first script to run 
		void Awake()
		{
				instance=this;
				LoadConfigFile();
				//LoadPath();
				return;
		}


		void Start () {

				instance=this;
				AtMainMenu=true;
				return;

		}

		void LateUpdate()
		{
				if (WorldReRenderPending)
				{						
						if ((FullReRender) && (!EditorMode))
						{
								//	currentTileMap().CleanUp(_RES);				
						}
						TileMapRenderer.GenerateLevelFromTileMap(GameWorldController.instance.LevelModel,GameWorldController.instance.SceneryModel,_RES,currentTileMap(),GameWorldController.instance.CurrentObjectList(), !FullReRender);
						if(ObjectReRenderPending)
						{								
								ObjectReRenderPending=false;
								ObjectLoader.RenderObjectList(CurrentObjectList(),currentTileMap(),LevelMarker().gameObject);
						}
						WorldReRenderPending=false;
						FullReRender=false;
				}
		}

		/// <summary>
		/// Begins the specified game.
		/// </summary>
		/// <param name="res">Res.</param>
		public void Begin(string res)
		{
				UWHUD.instance.gameSelectUi.SetActive(false);
				LoadPath(res);
				UWEBase._RES = res;//game;
				UWClass._RES= res;//game;
				keybinds.ApplyBindings();//Applies keybinds to certain controls

				switch(res)
				{
				case GAME_TNOVA:
						UWCharacter.Instance.XAxis.enabled=true;
						UWCharacter.Instance.YAxis.enabled=true;
						UWCharacter.Instance.MouseLookEnabled=true;
						UWCharacter.Instance.speedMultiplier=20;
						break;
				case GAME_SHOCK:
						palLoader = new PaletteLoader("res\\data\\gamepal.res", 700);
						//palLoader.Path=Loader.BasePath + "res\\data\\gamepal.res";
						//palLoader.PaletteNo=700;
						//palLoader.LoadPalettes();
						texLoader=new TextureLoader();
						objectMaster=new ObjectMasters();
						ObjectArt=new GRLoader("res\\data\\objart.res",1350);
						ShockObjProp= new ObjectPropLoader();
						UWCharacter.Instance.XAxis.enabled=true;
						UWCharacter.Instance.YAxis.enabled=true;
						UWCharacter.Instance.MouseLookEnabled=true;
						UWCharacter.Instance.speedMultiplier=20;
						break;
				default:
						StartCoroutine(MusicController.instance.Begin());
						objectMaster=new ObjectMasters();
						objDat = new ObjectDatLoader();
						commonObject= new CommonObjectDatLoader();


						palLoader = new PaletteLoader("data\\pals.dat",-1);

						//Create palette cycles and store them in the palette array
						PaletteLoader palCycler = new PaletteLoader("data\\pals.dat",-1);

						for (int c=0; c<=27;c++)
						{
								switch (_RES)
								{
								case GAME_UW2:
										Palette.cyclePalette(palCycler.Palettes[0], 224, 16);
										Palette.cyclePalette(palCycler.Palettes[0], 3, 6);
										break;
								default:
										Palette.cyclePalette(palCycler.Palettes[0], 48, 4);
										Palette.cyclePalette(palCycler.Palettes[0], 16, 7);//Reverse direction.
										break;
								}
								paletteArray[c] = Palette.toImage(palCycler.Palettes[0]);			
						}


						bytloader=new BytLoader();

						texLoader=new TextureLoader();
						ObjectArt=new GRLoader(GRLoader.OBJECTS_GR);
						SpellIcons = new GRLoader(GRLoader.SPELLS_GR);
						DoorArt=new GRLoader(GRLoader.DOORS_GR);
						TmObjArt=new GRLoader(GRLoader.TMOBJ_GR);
						TmFlatArt=new GRLoader(GRLoader.TMFLAT_GR);
						TmAnimo=new GRLoader(GRLoader.ANIMO_GR);
						armor_f=new GRLoader(GRLoader.ARMOR_F_GR);
						armor_m=new GRLoader(GRLoader.ARMOR_M_GR);
						grCursors = new GRLoader(GRLoader.CURSORS_GR);
						grFlasks=new GRLoader(GRLoader.FLASKS_GR);
						grOptbtns= new GRLoader(GRLoader.OPTBTNS_GR);
						grCompass=new GRLoader(GRLoader.COMPASS_GR);
						terrainData= new TerrainDatLoader();
						weaps=new WeaponAnimation();
						break;
				}


				switch(_RES)
				{
				case GAME_SHOCK:
				case GAME_TNOVA:
						break;
				case GAME_UW2:
						{
								if (GameWorldController.instance.startLevel==0)
								{//Avatar's bedroom
										GameWorldController.instance.StartPos=new Vector3(23.43f, 3.95f,58.29f)	;
								}
								break;
						}	
				case GAME_UWDEMO:
						GameWorldController.instance.StartPos=new Vector3(39.06f, 3.96f,3f)	;break;
				default:
						{
								if (GameWorldController.instance.startLevel==0)
								{//entrance to the abyss
										GameWorldController.instance.StartPos=new Vector3(39.06f, 3.96f,3f)	;
								}
								break;
						}			
				}


				switch(res)
				{
				case GAME_TNOVA:
						AtMainMenu=false;
						TileMapRenderer.EnableCollision=false;
						bGenNavMeshes=false;
						UWHUD.instance.gameObject.SetActive(false);
						UWHUD.instance.window.SetFullScreen();
						UWCharacter.Instance.isFlying=true;
						UWCharacter.Instance.playerMotor.enabled=true;
						UWCharacter.Instance.playerCam.backgroundColor=Color.white;
						SwitchTNovaMap("");
						return;
				case GAME_SHOCK:
						TileMapRenderer.EnableCollision=false;
						bGenNavMeshes=false;
						AtMainMenu=false;
						UWCharacter.Instance.isFlying=true;
						UWCharacter.Instance.playerMotor.enabled=true;
						UWHUD.instance.gameObject.SetActive(false);
						UWHUD.instance.window.SetFullScreen();
						SwitchLevel(startLevel);
						return;

				case GAME_UWDEMO:
						//case GAME_UW2:
						//UW Demo does not go to the menu. It will load automatically into the gameworld
						AtMainMenu=false;	
						UWCharacter.Instance.transform.position= GameWorldController.instance.StartPos;
						UWHUD.instance.Begin();
						UWCharacter.Instance.Begin();
						UWCharacter.Instance.playerInventory.Begin();
						StringController.instance.LoadStringsPak(Loader.BasePath+"data\\strings.pak");
						//convVM.LoadCnvArk(Loader.BasePath+"data\\cnv.ark");
						break;
				case GAME_UW2:
						UWHUD.instance.Begin();
						UWCharacter.Instance.Begin();
						UWCharacter.Instance.playerInventory.Begin();
						Quest.instance.QuestVariables = new int[250];//UW has a lot more quests. This value needs to be confirmed.
						StringController.instance.LoadStringsPak(Loader.BasePath+"data\\strings.pak");
						//convVM.LoadCnvArkUW2(Loader.BasePath+"data\\cnv.ark");
						break;		
				default:
						UWHUD.instance.Begin();
						UWCharacter.Instance.Begin();
						UWCharacter.Instance.playerInventory.Begin();
						StringController.instance.LoadStringsPak(Loader.BasePath+"data\\strings.pak");
						//convVM.LoadCnvArk(Loader.BasePath+"data\\cnv.ark");
						break;
				}

				if (EnableTextureAnimation==true)
				{
						UWHUD.instance.CutsceneFullPanel.SetActive(false);
						InvokeRepeating("UpdateAnimation",0.2f,0.2f);
				}

				if (AtMainMenu)
				{
						SwitchLevel(-1);//Turn off all level maps
						UWHUD.instance.CutsceneFullPanel.SetActive(true);
						UWHUD.instance.mainmenu.gameObject.SetActive(true);
						//Freeze player movement and put them at a set location
						UWCharacter.Instance.playerController.enabled=false;
						UWCharacter.Instance.playerMotor.enabled=false;
						UWCharacter.Instance.transform.position=Vector3.zero;

						getMus().InIntro=true;
				}
				else
				{			
						UWHUD.instance.CutsceneFullPanel.SetActive(false);	
						UWHUD.instance.mainmenu.gameObject.SetActive(false);
						UWHUD.instance.RefreshPanels(UWHUD.HUD_MODE_INVENTORY);
						SwitchLevel(startLevel);
				}
				PositionDetect();
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
				Transform found = instance.getCurrentLevelModel().transform.FindChild (tileName);
				if (found!=null)
				{
						return found.gameObject;
				}
				Debug.Log("Cannot find " + tileName);
				return null;
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
		/// Returns the transform of the levels object marker where objects are generated on.
		/// </summary>
		/// <returns>The marker.</returns>
		public Transform LevelMarker()
		{
				return _ObjectMarker.transform;
		}

		/// <summary>
		/// Switches the level to another one. Disables the map and level objects of the old one.
		/// </summary>
		/// <param name="newLevelNo">New level no.</param>
		/// 
		public void SwitchLevel(short newLevelNo)
		{
				if (newLevelNo!=-1)
				{
						if(LevelNo==-1)
						{//I'm at the main menu. Load up the file data now.
								critsLoader= new CritLoader[64];//Clear out animations
								InitLevelData();
						}

						//Check loading
						if (Tilemaps[newLevelNo]==null)
						{//Data has not been loaded for this level
								Tilemaps[newLevelNo]=new TileMap(newLevelNo);

								if (UWEBase._RES!=UWEBase.GAME_SHOCK)
								{
										Tilemaps[newLevelNo].BuildTileMapUW(lev_ark_file_data, newLevelNo);
										objectList[newLevelNo]=new ObjectLoader();
										objectList[newLevelNo].LoadObjectList( Tilemaps[newLevelNo],lev_ark_file_data);	
								}
								else
								{
										Tilemaps[newLevelNo].BuildTileMapShock(lev_ark_file_data, newLevelNo);
										objectList[newLevelNo]=new ObjectLoader();
										objectList[newLevelNo].LoadObjectListShock(Tilemaps[newLevelNo],lev_ark_file_data);
								}
								if (UWEBase.EditorMode==false)
								{
										Tilemaps[newLevelNo].CleanUp(_RES);//I can reduce the tile map complexity after I know about what tiles change due to objects									
								}
								Tilemaps[newLevelNo].CreateRooms();

						}

						if ((UWEBase._RES!=UWEBase.GAME_SHOCK) && (LevelNo!=-1))
						{
								//Call events for inventory objects on level transition.
								foreach (Transform t in GameWorldController.instance.InventoryMarker.transform) 
								{
										if (t.gameObject.GetComponent<object_base>()!=null)
										{
												t.gameObject.GetComponent<object_base>().InventoryEventOnLevelExit();
										}
								}

						}

						if(LevelNo!=-1)
						{//Changing from a level that has already loaded
								//Update the positions of all object interactions in the level
								//UpdatePositions();

								if (UWEBase.EditorMode==false)
								{
										ObjectLoader.UpdateObjectList(GameWorldController.instance.currentTileMap(), GameWorldController.instance.CurrentObjectList());		
								}
								//Store the state of the object list with just the objects in objects transform for when I re

						}


						//Get my object info into the tile map.
						LevelNo=newLevelNo;
						switch(UWEBase._RES)
						{
						case GAME_SHOCK:
								break;
						default:
								//critsLoader= new CritLoader[64];//Clear out animations
								if (UWEBase.EditorMode==false)
								{
										if (LoadingGame==false)
										{
												//Call events for inventory objects on level transition.
												foreach (Transform t in GameWorldController.instance.InventoryMarker.transform) 
												{
														if (t.gameObject.GetComponent<object_base>()!=null)
														{
																t.gameObject.GetComponent<object_base>().InventoryEventOnLevelEnter();
														}
												}		
										}
								}
								break;
						}

						TileMapRenderer.GenerateLevelFromTileMap(LevelModel, SceneryModel,_RES,Tilemaps[newLevelNo],objectList[newLevelNo],false);

						if ((startX !=-1) &&(startY!=-1))
						{
								float targetX=(float)startX*1.2f + 0.6f;
								float targetY= (float)startY*1.2f + 0.6f;
								float Height = ((float)(GameWorldController.instance.Tilemaps[newLevelNo].GetFloorHeight(startX,startY)))*0.15f;

								UWCharacter.Instance.transform.position=new Vector3(targetX,Height+0.05f,targetY);
								Debug.Log("Spawning at " + UWCharacter.Instance.transform.position);
								UWCharacter.Instance.TeleportPosition=new Vector3(targetX,Height+0.05f,targetY);	
						}
						startX=-1;startY=-1;


						switch(UWEBase._RES)
						{
						case GAME_SHOCK:
								//break;
						default:
								ObjectLoader.RenderObjectList(objectList[newLevelNo],Tilemaps[newLevelNo],LevelMarker().gameObject);
								break;
						}


						if ((bGenNavMeshes) && (!EditorMode))
						{
								GenerateNavmesh(NavRigLand);
								GenerateNavmesh(NavRigWater);								
						}

						if ((LevelNo==7) && (UWEBase._RES==UWEBase.GAME_UW1))
						{//Create shrine lava.
								GameObject shrineLava = new GameObject();
								shrineLava.transform.parent=SceneryModel.transform;
								shrineLava.transform.localPosition=new Vector3(-39f,39.61f,0.402f);
								shrineLava.transform.localScale=new Vector3(6f,0.2f,4.8f);
								shrineLava.AddComponent<ShrineLava>();
								shrineLava.AddComponent<BoxCollider>();
								shrineLava.GetComponent<BoxCollider>().isTrigger=true;
						}
				}
				if ((_RES==GAME_UW2) && (EditorMode==false))
				{
						if (events!=null)
						{
								if (!LoadingGame)
								{
										events.ProcessEvents();					
								}
						}
				}
		}

		/// <summary>
		/// Switchs the level and puts the player at the floor level of the new level
		/// </summary>
		/// <param name="newLevelNo">New level no.</param>
		/// <param name="newTileX">New tile x.</param>
		/// <param name="newTileY">New tile y.</param>
		public void SwitchLevel(short newLevelNo, short newTileX, short newTileY)
		{

				//float targetX=(float)newTileX*1.2f + 0.6f;
				//float targetY= (float)newTileY*1.2f + 0.6f;
				//float Height = ((float)(GameWorldController.instance.Tilemaps[newLevelNo].GetFloorHeight(newTileX,newTileY)))*0.15f;

				//UWCharacter.Instance.transform.position=new Vector3(targetX,Height+0.05f,targetY);
				//UWCharacter.Instance.TeleportPosition=new Vector3(targetX,Height+0.05f,targetY);

				startX =newTileX;
				startY =newTileY;
				SwitchLevel(newLevelNo);
		}

		// This will regenerate the navigation mesh when called
		void GenerateNavmesh(RAIN.Navigation.NavMesh.NavMeshRig NavRig)
		{//From Legacy.rivaltheory.com/forums/topics/runtime-navmesh-generation-and-path-finding-tutorial
				int _threadcount=4;
				// Unregister any navigation mesh we may already have (probably none if you are using this)
				NavRig.NavMesh.UnregisterNavigationGraph();
				NavRig.NavMesh.Size = 20;
				//float startTime = Time.time;
				NavRig.NavMesh.StartCreatingContours(_threadcount);
				NavRig.NavMesh.CreateAllContours();
				//float endTime = Time.time;
				//Debug.Log("NavMesh generated in " + (endTime - startTime) + "s");
				NavRig.NavMesh.RegisterNavigationGraph();
				NavRig.Awake();

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

		/// <summary>
		/// Returns the music controller
		/// </summary>
		/// <returns>The mus.</returns>
		public MusicController getMus()
		{
				if (mus==null)	
				{
						mus=GameObject.Find("_MusicController").GetComponent<MusicController>();
				}
				return mus;
		}

		/// <summary>
		/// Returns the current tile map
		/// </summary>
		/// <returns>The tile map.</returns>
		public TileMap currentTileMap()
		{
				if (LevelNo==-1)
				{
						return null;
				}
				else
				{
						return Tilemaps[LevelNo];				
				}

		}

		public AutoMap currentAutoMap()
		{
				if (LevelNo==-1)
				{
						return null;
				}
				else
				{
						return AutoMaps[LevelNo];				
				}
		}

		/// <summary>
		/// Detects where the player currently is an updates their swimming state and auto map as needed.
		/// </summary>
		public void PositionDetect()
		{
				if ((AtMainMenu==true) || (WindowDetect.InMap))
				{
						return;
				}
				if ((_RES!=GAME_UW1) && (_RES!=GAME_UWDEMO) && (_RES!=GAME_UW2) )
				{
						return;
				}
				TileMap.visitTileX =(short)(UWCharacter.Instance.transform.position.x/1.2f);
				TileMap.visitTileY =(short)(UWCharacter.Instance.transform.position.z/1.2f);
				UWCharacter.Instance.room= currentTileMap().Tiles[TileMap.visitTileX, TileMap.visitTileY].roomRegion;

				if (EditorMode)
				{
						if ((TileMap.visitedTileX != TileMap.visitTileX) || (TileMap.visitedTileY != TileMap.visitTileY)) 
						{
								if(IngameEditor.FollowMeMode)
								{
										IngameEditor.UpdateFollowMeMode(TileMap.visitTileX,TileMap.visitTileY);
								}
						}
				}
				//currentTileMap().SetTileVisited(TileMap.visitTileX,TileMap.visitTileY);
				UWCharacter.Instance.isSwimming=((TileMap.OnWater) && (!UWCharacter.Instance.isWaterWalking) && (!GameWorldController.EditorMode)) ;
				UWCharacter.Instance.onIce=((TileMap.OnIce) && (!UWCharacter.Instance.isWaterWalking) && (!GameWorldController.EditorMode)) ;

				for (int x=-1; x<=1;x++)
				{
						for (int y=-1; y<=1;y++)
						{
								if
										(
												( 
														(TileMap.visitTileX+x >=0 ) && (TileMap.visitTileX+x <=TileMap.TileMapSizeX )
												)
												&&
												( 
														(TileMap.visitTileY+y >=0 ) && (TileMap.visitTileY+y <=TileMap.TileMapSizeY)
												)
										)
								{
										currentAutoMap().MarkTile(TileMap.visitTileX+x, TileMap.visitTileY+y, currentTileMap().Tiles[TileMap.visitTileX+x,TileMap.visitTileY+y].tileType, AutoMap.GetDisplayType(currentTileMap().Tiles[TileMap.visitTileX+x,TileMap.visitTileY+y]) );												
								}
						}	
				}
				TileMap.visitedTileX=TileMap.visitTileX;
				TileMap.visitedTileY=TileMap.visitTileY;
		}

		/// <summary>
		/// Returns the current map object list
		/// </summary>
		/// <returns>The object list.</returns>
		public ObjectLoader CurrentObjectList()
		{
				if (LevelNo==-1)
				{
						return null;
				}
				else
				{
						return objectList[LevelNo];
				}
		}

		/// <summary>
		/// Moves the object to the game world where it will be managed by the objectloader list
		/// </summary>
		/// <param name="obj">Object.</param>
		public static void MoveToWorld(GameObject obj)
		{
				//Debug.Log(obj.name + "is moved to world");
				MoveToWorld(obj.GetComponent<ObjectInteraction>());

		}

		/// <summary>
		/// Moves to world and assigns it to the world object list.
		/// </summary>
		/// <returns>The to world.</returns>
		/// <param name="obj">Object.</param>
		public static ObjectInteraction MoveToWorld(ObjectInteraction obj)
		{
				//Add item to a free slot on the item list and point the instance back to this.
				ObjectLoader.AssignObjectToList(ref obj);
				obj.UpdatePosition();
				obj.GetComponent<object_base>().MoveToWorldEvent();
				if (ConversationVM.InConversation)
				{
						ConversationVM.BuildObjectList();//Reflect changes to object lists
				}

				//obj.name = ObjectLoader.UniqueObjectName(obj.objectloaderinfo);
				return obj;
				//Not needed???
		}

		/// <summary>
		/// Moves to inventory where it will no longer be managed by the objectloader list.
		/// </summary>
		/// <param name="obj">Object.</param>
		public static void MoveToInventory(GameObject obj)
		{
				MoveToInventory(obj.GetComponent<ObjectInteraction>());
		}


		/// <summary>
		/// Moves an object to inventory and removes it from the world map instance
		/// </summary>
		/// <param name="obj">Object.</param>
		public static void MoveToInventory(ObjectInteraction obj)
		{//Break the instance back to the object list
				obj.objectloaderinfo.InUseFlag=0;//This frees up the slot to be replaced with another item.	
				obj.GetComponent<object_base>().MoveToInventoryEvent();
				if (ConversationVM.InConversation)
				{
						ConversationVM.BuildObjectList();//Reflect changes to object lists
				}
		}


		/// <summary>
		/// Updates the positions of all game objects
		/// </summary>
		public void UpdatePositions()
		{
				foreach (Transform t in GameWorldController.instance.LevelMarker()) 
				{
						if (t.gameObject.GetComponent<ObjectInteraction>()!=null)
						{
								t.gameObject.GetComponent<ObjectInteraction>().UpdatePosition();	
						}
				}
		}


		/// <summary>
		/// Writes a lev ark file based on a rebuilding of the data.
		/// </summary>
		/// <param name="slotNo">Slot no.</param>
		///<9 blocks level tilemap/master object list>
		///<9 blocks object animation overlay info>
		///<9 blocks texture mapping>
		///<9 blocks automap infos>
		///<9 blocks map notes>
		///The remaining 9 x 10 blocks are unused.
		/// 
		public void WriteBackLevArk(int slotNo)
		{
				DataLoader.UWBlock[] blockData = new DataLoader.UWBlock[45];

				//First update the object list so as to match indices properly
				ObjectLoader.UpdateObjectList(GameWorldController.instance.currentTileMap(), GameWorldController.instance.CurrentObjectList());		

				//First block is always here.
				long AddressToCopyFrom=0;

				//Read in the data for the 9 tile/object maps
				for (int l=0; l<=GameWorldController.instance.Tilemaps.GetUpperBound(0); l++)
				{
						if (GameWorldController.instance.Tilemaps[l]!=null)
						{
								blockData[l].Data= GameWorldController.instance.Tilemaps[l].TileMapToBytes(lev_ark_file_data);							
								blockData[l].DataLen=blockData[l].Data.GetUpperBound(0)+1;
						}///31752
						else
						{
								AddressToCopyFrom =  DataLoader.getValAtAddress(lev_ark_file_data,(l* 4) + 2,32);
								blockData[l].Data=CopyData(AddressToCopyFrom, 31752);//TileMap.TileMapSizeX*TileMap.TileMapSizeY*4  +  256*27 + 768*8);	
								blockData[l].DataLen=blockData[l].Data.GetUpperBound(0)+1;
						}
				}
				//Read in the data for the animation overlays
				for (int l=0; l<=GameWorldController.instance.Tilemaps.GetUpperBound(0); l++)
				{					
						AddressToCopyFrom =  DataLoader.getValAtAddress(lev_ark_file_data,((l+9)* 4) + 2,32);
						blockData[l+9].Data=CopyData(AddressToCopyFrom,64*6);
						blockData[l+9].DataLen=blockData[l+9].Data.GetUpperBound(0)+1;
				}

				//read in the texture maps
				for (int l=0; l<=GameWorldController.instance.Tilemaps.GetUpperBound(0); l++)
				{
						if (GameWorldController.instance.Tilemaps[l]!=null)
						{
								blockData[l+18].Data= GameWorldController.instance.Tilemaps[l].TextureMapToBytes(); 
								blockData[l+18].DataLen=blockData[l+18].Data.GetUpperBound(0)+1;
						}
						else
						{
								AddressToCopyFrom =  DataLoader.getValAtAddress(lev_ark_file_data,((l+18) * 4) + 2,32);
								blockData[l+18].Data=CopyData(AddressToCopyFrom,0x7a);
								blockData[l+18].DataLen=blockData[l+18].Data.GetUpperBound(0)+1;
						}					
				}

				//read in the auto maps
				for (int l=0; l<=GameWorldController.instance.AutoMaps.GetUpperBound(0); l++)
				{
						blockData[l+27].Data=GameWorldController.instance.AutoMaps[l].AutoMapVisitedToBytes();
						if (blockData[l+27].Data!=null)
						{
								blockData[l+27].DataLen=blockData[l+27].Data.GetUpperBound(0)+1;			
						}
						else
						{
								blockData[l+27].DataLen=0;		
						}					
				}


				//read in the auto maps notes
				for (int l=0; l<=GameWorldController.instance.AutoMaps.GetUpperBound(0); l++)
				{
						blockData[l+36].Data=GameWorldController.instance.AutoMaps[l].AutoMapNotesToBytes();
						if (blockData[l+36].Data!=null)
						{
								blockData[l+36].DataLen=blockData[l+36].Data.GetUpperBound(0)+1;			
						}
						else
						{
								blockData[l+36].DataLen=0;		
						}	
				}

				blockData[0].Address=542;
				long prevAddress=blockData[0].Address;
				//Work out the block addresses.
				for (int i=1; i<blockData.GetUpperBound(0);i++)
				{
						if (blockData[i-1].DataLen!=0)
						{
								blockData[i].Address= prevAddress+blockData[i-1].DataLen;	
								prevAddress=blockData[i].Address;
						}
						else
						{
								blockData[i].Address=0;	
						}					
				}

				FileStream file = File.Open(Loader.BasePath + "save" + slotNo + "\\lev.ark",FileMode.Create);
				BinaryWriter writer= new BinaryWriter(file);
				long add_ptr=0;
				add_ptr+=DataLoader.WriteInt8(writer, 0x87);
				add_ptr+=DataLoader.WriteInt8(writer, 0);
				for (int i=0; i<=blockData.GetUpperBound(0); i++)
				{//write block addresses
						add_ptr+=DataLoader.WriteInt32(writer, blockData[i].Address);		
				}

				for (long freespace=add_ptr; freespace<blockData[0].Address;freespace++)
				{//write freespace
						add_ptr+=DataLoader.WriteInt8(writer,0);
				}

				//Now be brave and write all my blocks!!!
				for (int i=0; i<=blockData.GetUpperBound(0); i++)
				{
						if (blockData[i].Data!=null)
						{
								for (long a =0; a<=blockData[i].Data.GetUpperBound(0); a++)
								{
										add_ptr+=DataLoader.WriteInt8(writer,(long)blockData[i].Data[a]);
								}	
						}
				}

				file.Close();

				return;
		}

		/// <summary>
		/// Inits the level data maps and textures.
		/// </summary>
		void InitLevelData()
		{
				// Path to lev.ark file to load
				string Lev_Ark_File;

				switch (_RES)
				{
				case GAME_SHOCK:
						Tilemaps=new TileMap[15];
						objectList=new ObjectLoader[15];
						break;
				case GAME_UWDEMO:
						Tilemaps = new TileMap[1];
						objectList=new ObjectLoader[1];
						AutoMaps=new AutoMap[1];
						break;
				case GAME_UW2:
						Tilemaps = new TileMap[72];//Not all are in use.
						objectList=new ObjectLoader[72];
						AutoMaps=new AutoMap[72];
						break;
				case GAME_UW1:
				default:
						Tilemaps = new TileMap[9];
						objectList=new ObjectLoader[9];
						AutoMaps=new AutoMap[9];
						break;
				}



				switch (UWEBase._RES)
				{
				case UWEBase.GAME_SHOCK:
						MaterialMasterList= new Material[273];
						break;
				case UWEBase.GAME_UWDEMO:
						MaterialMasterList= new Material[58];
						break;
				case UWEBase.GAME_UW2:
						MaterialMasterList= new Material[256];//For each texture in UW2
						break;
				case UWEBase.GAME_UW1:						
				default:
						MaterialMasterList= new Material[260];//For each texture in UW1
						break;
				}

				//Load up my map materials
				for (int i =0; i<=MaterialMasterList.GetUpperBound(0);i++)
				{
						MaterialMasterList[i]=(Material)Resources.Load(_RES+"/Materials/textures/" + _RES + "_" + i.ToString("d3"));
						switch (MaterialMasterList[i].shader.name.ToUpper())
						{
						case "COLOURREPLACEMENT":
						case "COLOURREPLACEMENTREVERSE":
								MaterialMasterList[i].mainTexture= texLoader.LoadImageAt(i,1);//load a greyscale texture for use with the shader.
								break;
						case "LEGACY SHADERS/BUMPED DIFFUSE":
								{
										Texture2D loadedTexture =  texLoader.LoadImageAt(i,2);//Get normal map for mod directory
										MaterialMasterList[i].mainTexture= texLoader.LoadImageAt(i,0);
										if (loadedTexture!=null)
										{
												MaterialMasterList[i].SetTexture("_BumpMap",TextureLoader.NormalMap(loadedTexture,TextureLoader.BumpMapStrength));						
										}
								}
								break;
						default:
								//Debug.Log(i + " is " + MaterialMasterList[i].shader.name);
								MaterialMasterList[i].mainTexture= texLoader.LoadImageAt(i,0);
								break;
						}
				}
				if (_RES==GAME_UW1)
				{
						SpecialMaterials[0]=(Material)Resources.Load(_RES+"/Materials/textures/" + _RES + "_224_maze");
						SpecialMaterials[0].mainTexture=texLoader.LoadImageAt(224);
				}
				MaterialObj = new Material[TmObjArt.NoOfFileImages()];

				//Load the materials for the TMOBJ file
				for (int i=0; i<=MaterialObj.GetUpperBound(0);i++)
				{
						MaterialObj[i]= (Material)Resources.Load(_RES+"/Materials/tmobj/tmobj_" + i.ToString("d2"));	
						if (MaterialObj[i]!=null)
						{
								MaterialObj[i].mainTexture = TmObjArt.LoadImageAt(i);			
						}					
				}

				switch (_RES)
				{
				case GAME_SHOCK:
						break;

				default:
						//Load up my door texture
						for (int i =0; i<=MaterialDoors.GetUpperBound(0);i++)
						{
								MaterialDoors[i]= (Material)Resources.Load(_RES + "/Materials/doors/doors_" +i.ToString("d2") +"_material");	
								MaterialDoors[i].mainTexture = DoorArt.LoadImageAt(i);
						}
						break;

				}

				//Load up my tile maps
				//First read in my lev_ark file
				switch(UWEBase._RES)
				{
				case GAME_SHOCK:
						Lev_Ark_File = "res\\data\\archive.dat";
						break;	
				case UWEBase.GAME_UWDEMO:
						Lev_Ark_File = "Data\\level13.st";
						break;
				case UWEBase.GAME_UW2:
				case UWEBase.GAME_UW1:						
				default:
						Lev_Ark_File =  Lev_Ark_File_Selected; //"Data\\lev.ark";//Eventually this will be a save game.
						break;
				}

				if (!DataLoader.ReadStreamFile(Loader.BasePath + Lev_Ark_File, out lev_ark_file_data))
				{
						Debug.Log(Loader.BasePath + Lev_Ark_File + "File not loaded");
						Application.Quit();
				}		

				//Load up auto map data
				switch(_RES)
				{
				case GAME_UWDEMO:
						AutoMaps[0]=new AutoMap();
						AutoMaps[0].InitAutoMapDemo();
						break;
				case GAME_UW1:
						for (int i=0; i<=AutoMaps.GetUpperBound(0); i++)
						{
								AutoMaps[i]=new AutoMap();
								AutoMaps[i].InitAutoMapUW1(i,lev_ark_file_data);
						}
						break;
				case GAME_UW2:
						for (int i=0; i<=AutoMaps.GetUpperBound(0); i++)
						{
								AutoMaps[i]=new AutoMap();
								AutoMaps[i].InitAutoMapUW2(i, lev_ark_file_data);
						}
						break;
				}

				switch(_RES)
				{
				case GAME_UW2:
						events= new event_processor();		
						if (whatTheHellIsThatFileFor!=null)
						{
								whatTheHellIsThatFileFor.DumpScdArkInfo(SCD_Ark_File_Selected);
						}
						break;
				}
		}


		/// <summary>
		/// Inits the B globals.
		/// </summary>
		/// <param name="SlotNo">Slot no.</param>
		public void InitBGlobals(int SlotNo)
		{
				char[] bglob_data;
				if (SlotNo==0)	
				{//Init from BABGLOBS.DAT. Initialise the data.
						if (DataLoader.ReadStreamFile(Loader.BasePath + "data\\BABGLOBS.DAT", out bglob_data))
						{
								int NoOfSlots = bglob_data.GetUpperBound(0)/4;
								int add_ptr=0;
								bGlobals = new bablGlobal[NoOfSlots+1];
								for (int i=0; i<=NoOfSlots;i++)
								{
										bGlobals[i].ConversationNo =(int)DataLoader.getValAtAddress(bglob_data,add_ptr,16);
										bGlobals[i].Size =(int)DataLoader.getValAtAddress(bglob_data,add_ptr+2,16);
										bGlobals[i].Globals = new int[bGlobals[i].Size];
										add_ptr = add_ptr+4;
								}
						}	
				}
				else
				{
						int NoOfSlots=0;//Assumes the same no of slots that is in the babglobs is in bglobals.
						if (DataLoader.ReadStreamFile(Loader.BasePath + "data\\BABGLOBS.DAT", out bglob_data))
						{
								NoOfSlots = bglob_data.GetUpperBound(0)/4;
								NoOfSlots++;
						}
						if (DataLoader.ReadStreamFile(Loader.BasePath + "Save" + SlotNo + "\\BGLOBALS.DAT", out bglob_data))
						{
								//int NoOfSlots = bglob_data.GetUpperBound(0)/4;
								int add_ptr=0;
								bGlobals = new bablGlobal[NoOfSlots];
								for (int i=0; i<NoOfSlots;i++)
								{

										bGlobals[i].ConversationNo =(int)DataLoader.getValAtAddress(bglob_data,add_ptr,16);
										bGlobals[i].Size =(int)DataLoader.getValAtAddress(bglob_data,add_ptr+2,16);
										bGlobals[i].Globals = new int[bGlobals[i].Size];
										add_ptr+=4;
										for (int g=0; g<bGlobals[i].Size; g++)
										{
												bGlobals[i].Globals[g]=	(int)DataLoader.getValAtAddress(bglob_data,add_ptr,16);	
												if (bGlobals[i].Globals[g]==65535)
												{
														bGlobals[i].Globals[g]=0;	
												}
												add_ptr = add_ptr+2;
										}						
								}
						}		
				}
		}

		/// <summary>
		/// Writes the BGlobals data to file
		/// </summary>
		/// <param name="SlotNo">Slot no.</param>
		public void WriteBGlobals(int SlotNo)
		{
				int fileSize=0;
				for (int c=0; c<=bGlobals.GetUpperBound(0);c++)
				{
						fileSize+=4;	//No and size
						fileSize+=bGlobals[c].Size * 2;				
				}
				//Create an output byte array
				Byte[] output = new byte[fileSize];
				int add_ptr=0;
				for (int c=0; c<=bGlobals.GetUpperBound(0);c++)
				{
						//Write Slot No
						output[add_ptr]=(byte) (bGlobals[c].ConversationNo & 0xff);
						output[add_ptr+1]=(byte)( (bGlobals[c].ConversationNo >>8) & 0xff);
						//Write Size
						output[add_ptr+2]=(byte)( bGlobals[c].Size & 0xff);
						output[add_ptr+3]=(byte) ((bGlobals[c].Size >>8) & 0xff);
						add_ptr=add_ptr+4;
						for (int g = 0; g<=bGlobals[c].Globals.GetUpperBound(0); g++)
						{
								output[add_ptr]=(byte)( bGlobals[c].Globals[g] & 0xff);
								output[add_ptr+1]=(byte) ((bGlobals[c].Globals[g] >>8) & 0xff);
								add_ptr+=2;
						}
				}
				File.WriteAllBytes(Loader.BasePath +  "save" + SlotNo + "\\BGLOBALS.DAT" , output);

		}

		/// <summary>
		/// Copies the data from the cached lev ark file to a new array;
		/// </summary>
		/// <returns>The data.</returns>
		/// <param name="address">Address.</param>
		/// <param name="length">Length.</param>
		public char[] CopyData(long address, long length)
		{
				char[] DataToCopy=new char[length];

				for (int i=0; i<=DataToCopy.GetUpperBound(0);i++)
				{
						DataToCopy[i] = lev_ark_file_data[address+i];
				}
				return DataToCopy;
		}

		/// <summary>
		/// Switchs to a Terra nova map.
		/// </summary>
		/// <param name="levelFileName">Level file name.</param>
		public void SwitchTNovaMap(string levelFileName)
		{			
				string path;
				if (levelFileName=="")
				{
						path= NovaLevelSelect.MapSelected;
				}
				else
				{
						path=levelFileName;//Loader.BasePath + "MAPS\\roadmap.res";		
				}

				char[] archive_ark;
				if (DataLoader.ReadStreamFile(path, out archive_ark))
				{
						DataLoader.Chunk lev_ark;
						if (!DataLoader.LoadChunk(archive_ark, 86, out lev_ark ))
						{
								return;
						}
						UWCharacter.Instance.playerCam.GetComponent<Light>().range=200f;
						UWCharacter.Instance.playerCam.farClipPlane=3000f;
						UWCharacter.Instance.playerCam.renderingPath = RenderingPath.DeferredShading;
						TileMapRenderer.RenderTNovaMap(TNovaLevelModel.transform, lev_ark.data);				

				}
		}



		/// <summary>
		/// Loads the config file.
		/// </summary>
		/// <returns><c>true</c>, if config file was loaded, <c>false</c> otherwise.</returns>
		bool LoadConfigFile()
		{
				string fileName = Application.dataPath + "//..//config.ini";
				if (File.Exists(fileName))
				{
						string line;
						StreamReader fileReader = new StreamReader(fileName, Encoding.Default);
						//string PreviousKey="";
						//string PreviousValue="";
						using (fileReader)
						{
								// While there's lines left in the text file, do this:
								do
								{
										line = fileReader.ReadLine();
										if (line != null)
										{
												if (line.Length >1)
												{
														if ((line.Substring(1,1)!=";") && (line.Contains("=")))//Is not a commment and contains a param
														{
																string[] entries = line.Split('=');
																//int val = 0;
																string pathfound="";
																KeyCode keyCodeToUse;
																KeyBindings.instance.chartoKeycode.TryGetValue(entries[1].ToLower(), out keyCodeToUse);

																switch(entries[0].ToUpper())
																{
																case "MOUSEX"://Mouse sensitivity X
																		{
																				float val=15f;
																				if (float.TryParse(entries[1], out val ))
																				{
																						MouseX.sensitivityX = val;
																				}	
																				break;
																		}
																case "MOUSEY"://Mouse sensitivity Y
																		{
																				float val=15f;
																				if (float.TryParse(entries[1], out val ))
																				{
																						MouseY.sensitivityY = val;
																				}	
																				break;
																		}
																case "PATH_UW0":
																		{
																				path_uw0=entries[1];
																				break;
																		}
																case "PATH_UW1":
																		{
																				path_uw1=entries[1];
																				break;
																		}
																case "PATH_UW2":
																		{
																				path_uw2=entries[1];
																				break;
																		}
																case "PATH_SHOCK":
																		{
																				path_shock=entries[1];
																				break;
																		}
																case "PATH_TNOVA":
																		{
																				path_tnova=entries[1];
																				break;
																		}

																case "FLYUP": 
																		KeyBindings.instance.FlyUp=keyCodeToUse;break;
																case "FLYDOWN": 
																		KeyBindings.instance.FlyDown=keyCodeToUse;break;
																case "TOGGLEMOUSELOOK": 
																		KeyBindings.instance.ToggleMouseLook=keyCodeToUse;break;
																case "TOGGLEFULLSCREEN": 
																		KeyBindings.instance.ToggleFullScreen=keyCodeToUse;break;
																case "INTERACTIONOPTIONS": 
																		KeyBindings.instance.InteractionOptions=keyCodeToUse;break;
																case "INTERACTIONTALK": 
																		KeyBindings.instance.InteractionTalk=keyCodeToUse;break;
																case "INTERACTIONPICKUP": 
																		KeyBindings.instance.InteractionPickup=keyCodeToUse;break;
																case "INTERACTIONLOOK": 
																		KeyBindings.instance.InteractionLook=keyCodeToUse;break;
																case "INTERACTIONATTACK": 
																		KeyBindings.instance.InteractionAttack=keyCodeToUse;break;
																case "INTERACTIONUSE": 
																		KeyBindings.instance.InteractionUse=keyCodeToUse;break;
																case "CASTSPELL": 
																		KeyBindings.instance.CastSpell=keyCodeToUse;break;
																case "TRACKSKILL": 
																		KeyBindings.instance.TrackSkill=keyCodeToUse;break;


																case "DEFAULTLIGHTLEVEL":
																		{
																				float lightlevel=16f;
																				if(float.TryParse(entries[1], out lightlevel))		
																				{
																						LightSource.BaseBrightness=lightlevel;
																				}
																				break;
																		}

																case "FOV":
																		{
																				float fov=75f;
																				if(float.TryParse(entries[1], out fov))		
																				{
																						Camera.main.fieldOfView=fov;
																				}
																				break;
																		}
																case "INFINITEMANA":
																		{
																				Magic.InfiniteMana	= (entries[1]=="1");
																				break;
																		}

																case "GODMODE":
																		{
																				UWCharacter.Invincible = (entries[1]=="1");
																				break;
																		}

																case "CONTEXTUIENABLED":
																		{
																				WindowDetectUW.ContextUIEnabled = (entries[1]=="1");
																				break;
																		}

																case "UW1_SOUNDBANK":
																		{
																				MusicController.UW1Path=entries[1];
																				break;
																		}
																case "UW2_SOUNDBANK":
																		{
																				MusicController.UW2Path=entries[1];
																				break;
																		}
																}	
														}		
												}

										}
								}
								while (line != null);
								fileReader.Close();
								return true;
						}	
				}
				else
				{
						return false;
				}
		}

}