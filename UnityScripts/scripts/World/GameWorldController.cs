using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine.AI;
using UnityEngine.UI;

/// <summary>
/// Game world controller for controlling references and various global activities
/// </summary>

public class GameWorldController : UWEBase
{
    //public Texture2D[] allnova;

    public bool EnableUnderworldGenerator = false;
    public bool DoCleanUp = true;
    public GameObject ceiling;

    public WhatTheHellIsSCD_ARK whatTheHellIsThatFileFor;

    public enum UW1_LevelNos
    {
        EntranceLevel = 0,
        MountainMen = 1,
        Swamp = 2,
        Knights = 3,
        Catacombs = 4,
        Seers = 5,
        Tybal = 6,
        Volcano = 7,
        Ethereal = 8
    };

    public static string[] UW1_LevelNames = new string[]
    {
        "Outcast",
        "Dwarf",
        "Swamp",
        "Knight",
        "Tombs",
        "Seers",
        "Tybal",
        "Abyss",
        "Void"
    };

    /// <summary>
    /// First index of the level no for a world
    /// </summary>
    public enum Worlds
    {
        Britannia = 0,
        PrisonTower = 8,
        Killorn = 16,
        Ice = 24,
        Talorus = 32,
        Academy = 40,
        Tomb = 48,
        Pits = 56,
        Ethereal = 64
    };

    public enum UW2_LevelNos
    {
        Britannia0 = 0,
        Britannia1 = 1,
        Britannia2 = 2,
        Britannia3 = 3,
        Britannia4 = 4,
        Prison0 = 8,
        Prison1 = 9,
        Prison2 = 10,
        Prison3 = 11,
        Prison4 = 12,
        Prison5 = 13,
        Prison6 = 14,
        Prison7 = 15,
        Killorn0 = 16,
        Killorn1 = 17,
        Ice0 = 24,
        Ice1 = 25,
        Talorus0 = 32,
        Talorus1 = 33,
        Academy0 = 40,
        Academy1 = 41,
        Academy2 = 42,
        Academy3 = 43,
        Academy4 = 44,
        Academy5 = 45,
        Academy6 = 46,
        Academy7 = 47,
        Tomb0 = 48,
        Tomb1 = 49,
        Tomb2 = 50,
        Tomb3 = 51,
        Pits0 = 56,
        Pits1 = 57,
        Pits2 = 58,
        Ethereal0 = 64,
        Ethereal1 = 65,
        Ethereal2 = 66,
        Ethereal3 = 67,
        Ethereal4 = 68,
        Ethereal5 = 69,
        Ethereal6 = 70,
        Ethereal7 = 71,
        Ethereal8 = 72
    };
        

    [Header("Controls")]
    public MouseLook MouseX;
    public MouseLook MouseY;

    [Header("World Options")]
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
    public bool EnableTimerTriggers = true;

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
    public Terrain TNovaTerrain;

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

    public static bool LoadingGame = false;
    public static bool NavMeshReady = false;
    public bool[] NavMeshesReady = new bool[4];
    private static string LevelSignature;

    /// <summary>
    /// What level the player starts on in a quick start
    /// </summary>
    public short startLevel = 0;
    /// <summary>
    /// What start position for the player.
    /// </summary>
    public Vector3 StartPos = new Vector3(38f, 4f, 2.7f);

    /// <summary>
    /// Create object reports
    /// </summary>
    public bool CreateReports;
    public bool ShowOnlyInUse;

    [Header("Palettes")]
    /// <summary>
    /// Array of cycled game palettes for animation effects.
    /// </summary>
    public Texture2D[] paletteArray = new Texture2D[8];

    /// <summary>
    /// The index of the palette currently in use
    /// </summary>
    public int paletteIndex = 0;

    /// <summary>
    /// The palette index when going in reverse.
    /// </summary>
    public int paletteIndexReverse = 0;

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
    public ObjectLoader[] objectList = new ObjectLoader[9];

    /// <summary>
    /// Object list for the player inventory.
    /// </summary>
    public ObjectLoader inventoryLoader = new ObjectLoader();

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
    public string Lev_Ark_File_Selected = "";//"DATA\\Lev.ark";
    public string SCD_Ark_File_Selected = "";//"DATA\\SCD.ark";
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
    public Material[] MaterialMasterList = new Material[260];

    public Material[] SpecialMaterials = new Material[1];

    /// <summary>
    /// Default material for the editor
    /// </summary>
    public Material Jorge;

    /// <summary>
    /// The materials for doors  (doors.gr)
    /// </summary>
    public Material[] MaterialDoors = new Material[13];

    /// <summary>
    /// The materials for tmobj + models (tmobj.gr)
    /// </summary>
    public Material[] MaterialObj = new Material[54];

    /// <summary>
    /// The default model material.
    /// </summary>
    public Material modelMaterial;


    [Header("Nav Meshes")]
    /// <summary>
    /// Generate Nav meshes or not
    /// </summary>
    public bool bGenNavMeshes = true;
    public int GenNavMeshNextFrame = -1;
    public NavMeshSurface NavMeshLand;
    public NavMeshSurface NavMeshWater;
    public NavMeshSurface NavMeshAir;
    public NavMeshSurface NavMeshLava;
    public int MapMeshLayerMask = 0;
    public int DoorLayerMask = 0;


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

    public CritLoader[] critsLoader = new CritLoader[64];

    /// <summary>
    /// The weapon animation frames.
    /// </summary>
    public WeaponAnimation weaps;
    //public WeaponAnimationPlayer WeaponAnim;
    public WeaponsLoader weapongr;

    public int difficulty = 1; //1=standard, 0=easy.

    public static bool LoadingObjects = false;

    public struct bablGlobal
    {
        public int ConversationNo;
        public int Size;
        public int[] Globals;
    };

    /// <summary>
    /// Conversation Global data
    /// </summary>
    public bablGlobal[] bGlobals;

    /// <summary>
    /// The virtual machine that runs conversations.
    /// </summary>
    public ConversationVM convVM;

    /// <summary>
    /// Does the world need to be redrawn (partially or completely.
    /// </summary>
    public static bool WorldReRenderPending = false;
    /// <summary>
    /// Does the game objects need to be redrawn. Used by the in game editor.
    /// </summary>
    public static bool ObjectReRenderPending = false;
    /// <summary>
    /// Force the entire world to be redrawn
    /// </summary>
    public static bool FullReRender = false;

    /// <summary>
    /// Key bindings for the game.
    /// </summary>
    public KeyBindings keybinds;

    /// <summary>
    /// Event engine for running scd.ark events.
    /// </summary>
    public event_processor events;

    /// <summary>
    /// Starting X position on the map.
    /// </summary>
    private int startX = -1;
    /// <summary>
    /// Starting Y position on the map
    /// </summary>
    private int startY = -1;
    /// <summary>
    /// Starting height on the map.
    /// </summary>
    private int StartHeight = -1;


    /// <summary>
    /// Load the appropiate game path fro the selected _RES
    /// </summary>
    /// <param name="_RES"></param>
    void LoadPath(string _RES)
    {
        string path = "";

        switch (_RES)
        {
            case GAME_UWDEMO: path = GameWorldController.instance.path_uw0; break;
            case GAME_UW1: path = GameWorldController.instance.path_uw1; break;
            case GAME_UW2: path = GameWorldController.instance.path_uw2; break;
            case GAME_SHOCK: path = GameWorldController.instance.path_shock; break;
            case GAME_TNOVA: path = GameWorldController.instance.path_tnova; break;
        }

        Loader.BasePath = path;
        //Loader.sep = sep;
    }

    /// <summary>
    /// Awake this instance.
    /// </summary>
    /// Should be the very first script to run 
    void Awake()
    {
        instance = this;
        //Set the seperator in file paths.
        UWClass.sep = Path.AltDirectorySeparatorChar;
        Lev_Ark_File_Selected = "DATA" + sep + "LEV.ARK";
        SCD_Ark_File_Selected = "DATA" + sep + "SCD.ARK";

        LoadConfigFile();
        //LoadPath();
        return;
    }


    void Start()
    {
        instance = this;
        AtMainMenu = true;
    }

    void Update()
    {
        PositionDetect();
    }


    /// <summary>
    /// Generate NAV meshes for the map.
    /// </summary>
    /// <returns></returns>
    IEnumerator UpdateNavMeshes()
    {
        NavMeshReady = false;
        NavMeshesReady[0] = false;//land
        NavMeshesReady[1] = false;//water
        NavMeshesReady[2] = false;//lava
        //NavMeshesReady[3]=false;//air
        while (LoadingGame)
        {
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(GenerateNavmesh(NavMeshLand, 0));//Update nav mesh for the land
        StartCoroutine(GenerateNavmesh(NavMeshWater, 1));//For water
        StartCoroutine(GenerateNavmesh(NavMeshLava, 2));//for lava
        StartCoroutine(GenerateNavmesh(NavMeshAir, 3));//for air


        while (!(
                    (NavMeshesReady[0]) &&
                    (NavMeshesReady[1]) &&
                    (NavMeshesReady[2]) &&
                    (NavMeshesReady[3])
                )
            )
        {
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(1.5f);
        NavMeshReady = true;
        yield return 0;
    }

    /// <summary>
    /// Build a Nav Mesh for the specified layer.
    /// </summary>
    /// <param name="navmeshobj"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    IEnumerator GenerateNavmesh(NavMeshSurface navmeshobj, int index)
    {
        if (navmeshobj.navMeshData == null)
        {
            navmeshobj.BuildNavMesh();
        }
        else
        {
            AsyncOperation task = navmeshobj.UpdateNavMesh(navmeshobj.navMeshData);
            while (!task.isDone)
            {
                yield return new WaitForSeconds(0.1f);
            }
        }
        NavMeshesReady[index] = true;
        yield return 0;
    }

    void LateUpdate()
    {
        if (WorldReRenderPending)
        {//Level Needs redrawing.
            if ((FullReRender) && (!EditorMode))
            {
                //	CurrentTileMap().CleanUp(_RES);				
            }
            TileMapRenderer.GenerateLevelFromTileMap(GameWorldController.instance.LevelModel, GameWorldController.instance.SceneryModel, _RES, CurrentTileMap(), CurrentObjectList(), !FullReRender);
            if (ObjectReRenderPending)
            {
                ObjectReRenderPending = false;
                ObjectLoader.RenderObjectList(CurrentObjectList(), CurrentTileMap(), DynamicObjectMarker().gameObject);
            }
            WorldReRenderPending = false;
            FullReRender = false;
            if (!IngameEditor.EditorMode)
            {
                NavMeshLand.UpdateNavMesh(NavMeshLand.navMeshData);
                NavMeshWater.UpdateNavMesh(NavMeshWater.navMeshData);
                //NavMeshAir.UpdateNavMesh(NavMeshAir.navMeshData);
                NavMeshLava.UpdateNavMesh(NavMeshLava.navMeshData);
            }
            else
            {
                IngameEditor.instance.RefreshTileMap();
            }
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
        UWClass._RES = res;//game;
        keybinds.ApplyBindings();//Applies keybinds to certain controls

        //Set some layers for the AI to use to detect walls and doors.
        MapMeshLayerMask = 1 << LevelModel.layer;
        DoorLayerMask = 1 << LayerMask.NameToLayer("Doors");

        switch (res)
        {
            case GAME_TNOVA:
                UWCharacter.Instance.XAxis.enabled = true;
                UWCharacter.Instance.YAxis.enabled = true;
                UWCharacter.Instance.MouseLookEnabled = true;
                UWCharacter.Instance.speedMultiplier = 20;
                break;
            case GAME_SHOCK:
                palLoader = new PaletteLoader("res" + sep + "DATA" + sep + "GAMEPAL.RES", 700);
                texLoader = new TextureLoader();
                objectMaster = new ObjectMasters();
                ObjectArt = new GRLoader("res" + sep + "DATA" + sep + "OBJART.RES", 1350);
                ShockObjProp = new ObjectPropLoader();
                UWCharacter.Instance.XAxis.enabled = true;
                UWCharacter.Instance.YAxis.enabled = true;
                UWCharacter.Instance.MouseLookEnabled = true;
                UWCharacter.Instance.speedMultiplier = 20;
                break;
            default:
                StartCoroutine(MusicController.instance.Begin());
                objectMaster = new ObjectMasters();
                objDat = new ObjectDatLoader();
                commonObject = new CommonObjectDatLoader();
                palLoader = new PaletteLoader("DATA" + sep + "PALS.DAT", -1);
                //Create palette cycles and store them in the palette array
                PaletteLoader palCycler = new PaletteLoader("DATA" + sep + "PALS.DAT", -1);

                for (int c = 0; c <= 27; c++)
                {//Create palette cycles
                    switch (_RES)
                    {
                        case GAME_UW2:
                            Palette.cyclePalette(palCycler.Palettes[0], 224, 16);
                            Palette.cyclePaletteReverse(palCycler.Palettes[0], 3, 6);
                            break;
                        default:
                            Palette.cyclePalette(palCycler.Palettes[0], 48, 16);//Forward
                            Palette.cyclePaletteReverse(palCycler.Palettes[0], 16, 7);//Reverse direction.
                            break;
                    }
                    paletteArray[c] = Palette.toImage(palCycler.Palettes[0]);
                }


                //Create art loaders
                bytloader = new BytLoader();
                texLoader = new TextureLoader();
                ObjectArt = new GRLoader(GRLoader.OBJECTS_GR);ObjectArt.xfer = true;
                SpellIcons = new GRLoader(GRLoader.SPELLS_GR);
                DoorArt = new GRLoader(GRLoader.DOORS_GR);
                TmObjArt = new GRLoader(GRLoader.TMOBJ_GR);
                TmFlatArt = new GRLoader(GRLoader.TMFLAT_GR);
                TmAnimo = new GRLoader(GRLoader.ANIMO_GR); TmAnimo.xfer = true;
                armor_f = new GRLoader(GRLoader.ARMOR_F_GR);
                armor_m = new GRLoader(GRLoader.ARMOR_M_GR);
                grCursors = new GRLoader(GRLoader.CURSORS_GR);
                grFlasks = new GRLoader(GRLoader.FLASKS_GR);
                grOptbtns = new GRLoader(GRLoader.OPTBTNS_GR);
                grCompass = new GRLoader(GRLoader.COMPASS_GR);
                terrainData = new TerrainDatLoader();
                weaps = new WeaponAnimation();
                break;
        }

        switch (_RES)
        {//Set Start Positions
            case GAME_SHOCK:
            case GAME_TNOVA:
                break;
            case GAME_UW2:
                {
                    if (GameWorldController.instance.startLevel == 0)
                    {//Avatar's bedroom
                        GameWorldController.instance.StartPos = new Vector3(23.43f, 3.95f, 58.29f);
                    }
                    break;
                }
            case GAME_UWDEMO:
                GameWorldController.instance.StartPos = new Vector3(39.06f, 3.96f, 3f); break;
            default:
                {
                    if (GameWorldController.instance.startLevel == 0)
                    {//entrance to the abyss
                        GameWorldController.instance.StartPos = new Vector3(39.06f, 3.96f, 3f);
                    }
                    break;
                }
        }

        switch (res)
        {
            case GAME_TNOVA:
                AtMainMenu = false;
                TileMapRenderer.EnableCollision = false;
                bGenNavMeshes = false;
                UWHUD.instance.gameObject.SetActive(false);
                UWHUD.instance.window.SetFullScreen();
                //UWCharacter.Instance.isFlying = true;
                UWCharacter.Instance.playerMotor.enabled = true;
                UWCharacter.Instance.playerCam.backgroundColor = Color.white;
                UWCharacter.Instance.transform.position = new Vector3(128f, 256f, 128f);
                SwitchTNovaMap("");
                return;
            case GAME_SHOCK:
                TileMapRenderer.EnableCollision = false;
                bGenNavMeshes = false;
                AtMainMenu = false;
                UWCharacter.Instance.isFlying = true;
                UWCharacter.Instance.playerMotor.enabled = true;
                UWHUD.instance.gameObject.SetActive(false);
                UWHUD.instance.window.SetFullScreen();
                SwitchLevel(startLevel);
                return;

            case GAME_UWDEMO:
                //case GAME_UW2:
                //UW Demo does not go to the menu. It will load automatically into the gameworld
                AtMainMenu = false;
                UWCharacter.Instance.transform.position = GameWorldController.instance.StartPos;
                UWHUD.instance.Begin();
                UWCharacter.Instance.Begin();
                UWCharacter.Instance.playerInventory.Begin();
                StringController.instance.LoadStringsPak(Loader.BasePath + "DATA" + sep + "STRINGS.PAK");
                break;
            case GAME_UW2:
                UWHUD.instance.Begin();
                UWCharacter.Instance.Begin();
                UWCharacter.Instance.playerInventory.Begin();
                Quest.instance.QuestVariables = new int[250];//UW has a lot more quests. This value needs to be confirmed.
                StringController.instance.LoadStringsPak(Loader.BasePath + "DATA" + sep + "STRINGS.PAK");
                break;
            default:
                UWHUD.instance.Begin();
                UWCharacter.Instance.Begin();
                UWCharacter.Instance.playerInventory.Begin();
                StringController.instance.LoadStringsPak(Loader.BasePath + "DATA" + sep + "STRINGS.PAK");
                break;
        }

        if (EnableTextureAnimation == true)
        {
            UWHUD.instance.CutsceneFullPanel.SetActive(false);
            InvokeRepeating("UpdateAnimation", 0.2f, 0.2f);
        }

        if (AtMainMenu)
        {            
            SwitchLevel(-1);//Turn off all level maps
            UWHUD.instance.CutsceneFullPanel.SetActive(true);
            UWHUD.instance.mainmenu.gameObject.SetActive(true);
            //Freeze player movement and put them at a set location
            UWCharacter.Instance.playerController.enabled = false;
            UWCharacter.Instance.playerMotor.enabled = false;
            UWCharacter.Instance.transform.position = Vector3.zero;
            MusicController.instance.InIntro = true;//Set music state.
        }
        else
        {
            UWHUD.instance.CutsceneFullPanel.SetActive(false);
            UWHUD.instance.mainmenu.gameObject.SetActive(false);
            UWHUD.instance.RefreshPanels(UWHUD.HUD_MODE_INVENTORY);
            SwitchLevel(startLevel);
        }
        return;
    }


    ///// <summary>
    ///// Gets the current level model.
    ///// </summary>
    ///// <returns>The current level model gameobject</returns>
    //public GameObject getCurrentLevelModel()
    //{
    //    return LevelModel;
    //}

    /// <summary>
    /// Updates the global shader parameter for the colorpalette shaders at set intervals. To enable texture animation
    /// </summary>
    void UpdateAnimation()
    {
        Shader.SetGlobalTexture("_ColorPaletteIn", paletteArray[paletteIndex]);

        if (paletteIndex < paletteArray.GetUpperBound(0))
        {
            paletteIndex++;
        }
        else
        {
            paletteIndex = 0;
        }
        ////In Reverse

        //Shader.SetGlobalTexture("_ColorPaletteInReverse", paletteArray[paletteIndexReverse]);

        //if (paletteIndexReverse > 0)
        //{
        //    paletteIndexReverse--;
        //}
        //else
        //{
        //    paletteIndexReverse = paletteArray.GetUpperBound(0);
        //}
        return;
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
        string tileName = GetTileName(x, y, surface);
        Transform found = GameWorldController.instance.LevelModel.transform.Find(tileName);
        if (found != null)
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
        X = x.ToString("D2");
        Y = y.ToString("D2");
        switch (surface)
        {
            case TileMap.SURFACE_WALL:  //SURFACE_WALL:
                {
                    tileName = "Wall_" + X + "_" + Y;
                    break;
                }
            case TileMap.SURFACE_CEIL: //SURFACE_CEIL:
                {
                    tileName = "Ceiling_" + X + "_" + Y;
                    break;
                }
            case TileMap.SURFACE_FLOOR:
            case TileMap.SURFACE_SLOPE:
            default:
                {
                    tileName = "Tile_" + X + "_" + Y;
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
        return instance.LevelModel.transform.Find(tileName).gameObject;
    }

    /// <summary>
    /// Returns the transform of the levels object marker where objects are generated on.
    /// </summary>
    /// <returns>The marker.</returns>
    public Transform DynamicObjectMarker()
    {
        return _ObjectMarker.transform;
    }

    /// <summary>
    /// Switches the level to another one. Disables the map and level objects of the old one.
    /// </summary>
    /// <param name="newLevelNo">New level no.</param>
    public void SwitchLevel(short newLevelNo)
    {
        if (newLevelNo != -1)
        {
            if (LevelNo == -1)
            {//I'm at the main menu. Load up the file data now.
                critsLoader = new CritLoader[64];//Clear out npc animations
                //Initialise various objects as appropiate for the current game.
                InitLevelData();
            }

            if (_RES == GAME_UW2)
            {//Set the game to use UW2 music.
                MusicController.instance.ChangeTrackListForUW2(newLevelNo);
            }

            //Check loading
            if (Tilemaps[newLevelNo] == null)
            {//Data has not been loaded for this level yet
                Tilemaps[newLevelNo] = new TileMap(newLevelNo);

                if (UWEBase._RES != UWEBase.GAME_SHOCK)
                {
                    DataLoader.UWBlock lev_ark_block = new DataLoader.UWBlock();//Data containing tilemap.
                    DataLoader.UWBlock tex_ark_block = new DataLoader.UWBlock();//Data containing texture map
                    DataLoader.UWBlock ovl_ark_block = new DataLoader.UWBlock();//Data containing animation overlays

                    //Load Lev.ark data for the objects and tile map
                    lev_ark_block = LoadLevArkBlock(newLevelNo);

                    if (_RES == GAME_UW1)
                    {//Load the overlays.
                        DataLoader.LoadUWBlock(LevArk.lev_ark_file_data, newLevelNo + 9, 0x180, out ovl_ark_block);
                    }

                    //Load lev.ark data fror the texture map.
                    tex_ark_block = LoadTexArkBlock(newLevelNo, tex_ark_block);

                    if ((lev_ark_block.DataLen > 0) && (tex_ark_block.DataLen > 0))
                    {
                        if (EnableUnderworldGenerator)
                        {
                            UnderworldGenerator.instance.GenerateLevel(UnderworldGenerator.instance.Seed);
                            Tilemaps[newLevelNo] = UnderworldGenerator.instance.CreateTileMap(newLevelNo);
                            startX = UnderworldGenerator.instance.startX;
                            startY = UnderworldGenerator.instance.startY;
                        }
                        else
                        {
                            Tilemaps[newLevelNo].BuildTileMapUW(newLevelNo, lev_ark_block, tex_ark_block, ovl_ark_block);
                        }

                        //Load game objects from the levark data
                        objectList[newLevelNo] = new ObjectLoader();
                        objectList[newLevelNo].LoadObjectList(Tilemaps[newLevelNo], lev_ark_block);

                        if (CreateReports)
                        {
                            CreateObjectReport(objectList[newLevelNo].objInfo, newLevelNo);
                        }
                        if (EnableUnderworldGenerator)
                        {
                            //Clear all objects for the random generator
                            for (int i = 0; i <= objectList[newLevelNo].objInfo.GetUpperBound(0); i++)
                            {
                                objectList[newLevelNo].objInfo[i].InUseFlag = 0;
                            }
                        }
                    }
                    else
                    {//load an empty level
                     //TODO:
                    }
                }
                else
                {//Build a SS1 level.
                    Tilemaps[newLevelNo].BuildTileMapShock(LevArk.lev_ark_file_data, newLevelNo);
                    objectList[newLevelNo] = new ObjectLoader();
                    objectList[newLevelNo].LoadObjectListShock(Tilemaps[newLevelNo], LevArk.lev_ark_file_data);
                }

                if (UWEBase.EditorMode == false)
                {//Reduce complexity of the level geometry.
                    Tilemaps[newLevelNo].CleanUp(_RES);
                }
            }

            if ((UWEBase._RES != UWEBase.GAME_SHOCK) && (LevelNo != -1))
            {
                //Call special events for inventory objects on level transition out of the current level.
                foreach (Transform t in GameWorldController.instance.InventoryMarker.transform)
                {
                    if (t.gameObject.GetComponent<object_base>() != null)
                    {
                        t.gameObject.GetComponent<object_base>().InventoryEventOnLevelExit();
                    }
                }
            }

            if (LevelNo != -1)
            {//When changing from a level that has already loaded
                if (UWEBase.EditorMode == false)
                {
                    ObjectLoader.UpdateObjectList(CurrentTileMap(), CurrentObjectList());
                }
            }

            //Tell the game we are now using the new level no.
            LevelNo = newLevelNo;

            switch (UWEBase._RES)
            {
                case GAME_SHOCK:
                    break;
                default:
                    if (UWEBase.EditorMode == false)
                    {
                        if (LoadingGame == false)
                        {
                            //Call events for inventory objects on level transition into a new level.
                            foreach (Transform t in GameWorldController.instance.InventoryMarker.transform)
                            {
                                if (t.gameObject.GetComponent<object_base>() != null)
                                {
                                    t.gameObject.GetComponent<object_base>().InventoryEventOnLevelEnter();
                                }
                            }
                        }
                    }
                    break;
            }

            //Render the tile map based on the loaded data.
            TileMapRenderer.GenerateLevelFromTileMap(LevelModel, SceneryModel, _RES, Tilemaps[newLevelNo], objectList[newLevelNo], false);

            //Positions the character on the new level map.
            PlaceCharacter(newLevelNo);

            switch (UWEBase._RES)
            {
                case GAME_SHOCK:
                //break;
                default:
                    ObjectLoader.RenderObjectList(objectList[newLevelNo], Tilemaps[newLevelNo], DynamicObjectMarker().gameObject);
                    break;
            }

            //Update nav meshes when the "signature" of the level loaded is different from the previous one.
            if ((bGenNavMeshes) && (!EditorMode))
            {
                string newSignature = CurrentTileMap().getSignature();
                if (newSignature != LevelSignature)
                {
                    NavMeshReady = false;
                    StartCoroutine(UpdateNavMeshes());
                }
                LevelSignature = newSignature;
            }

            if ((LevelNo == 7) && (UWEBase._RES == UWEBase.GAME_UW1))
            {//Create the special lava for the UW1 endgame.
                CreateShrineLava();
            }
        }
        if ((_RES == GAME_UW2) && (EditorMode == false))
        {
            if (events != null)
            {
                if (!LoadingGame)
                {
                    events.ProcessEvents();
                }
            }
        }
    }

    /// <summary>
    /// Create shrine lava for the abyss in UW1.
    /// </summary>
    private void CreateShrineLava()
    {        
        GameObject shrineLava = new GameObject();
        shrineLava.transform.parent = SceneryModel.transform;
        shrineLava.transform.localPosition = new Vector3(-39f, 39.61f, 0.402f);
        shrineLava.transform.localScale = new Vector3(6f, 0.2f, 4.8f);
        shrineLava.AddComponent<ShrineLava>();
        shrineLava.AddComponent<BoxCollider>();
        shrineLava.GetComponent<BoxCollider>().isTrigger = true;
    }

    /// <summary>
    /// Positions the character on the map.
    /// </summary>
    /// <param name="newLevelNo"></param>
    private void PlaceCharacter(short newLevelNo)
    {
        if ((startX != -1) && (startY != -1))
        {
            float targetX = (float)startX * 1.2f + 0.6f;
            float targetY = (float)startY * 1.2f + 0.6f;
            float Height;
            if (StartHeight == -1)
            {
                Height = ((float)(GameWorldController.instance.Tilemaps[newLevelNo].GetFloorHeight(startX, startY))) * 0.15f;
            }
            else
            {
                Height = (float)StartHeight * 0.15f;
            }

            UWCharacter.Instance.transform.position = new Vector3(targetX, Height + 0.5f, targetY);
            // Debug.Log("Spawning at " + UWCharacter.Instance.transform.position + " using floorheight " + GameWorldController.instance.Tilemaps[newLevelNo].GetFloorHeight(startX, startY));
            UWCharacter.Instance.TeleportPosition = new Vector3(targetX, Height + 0.1f, targetY);
            if (EnableUnderworldGenerator)
            {
                GameWorldController.instance.StartPos = UWCharacter.Instance.transform.position;
            }
        }
        startX = -1; startY = -1;
    }

    /// <summary>
    /// Loads texture map data blocks
    /// </summary>
    /// <param name="newLevelNo"></param>
    /// <param name="tex_ark_block"></param>
    /// <returns></returns>
    private static DataLoader.UWBlock LoadTexArkBlock(short newLevelNo, DataLoader.UWBlock tex_ark_block)
    {
        //Load the texture maps
        switch (_RES)
        {
            case GAME_UWDEMO:
                DataLoader.ReadStreamFile(Loader.BasePath + "DATA" + sep + "LEVEL13.TXM", out tex_ark_block.Data);
                tex_ark_block.DataLen = tex_ark_block.Data.GetUpperBound(0);
                break;
            case GAME_UW2:
                DataLoader.LoadUWBlock(LevArk.lev_ark_file_data, newLevelNo + 80, -1, out tex_ark_block);
                break;
            case GAME_UW1:
            default:
                DataLoader.LoadUWBlock(LevArk.lev_ark_file_data, newLevelNo + 18, 0x7a, out tex_ark_block);
                break;
        }

        return tex_ark_block;
    }


    /// <summary>
    /// Loads the LevArk Block Data
    /// </summary>
    /// <param name="newLevelNo"></param>
    /// <returns>Raw Lev Ark Data</returns>
    private static DataLoader.UWBlock LoadLevArkBlock(short newLevelNo)
    {
        DataLoader.UWBlock lev_ark_block;
        if (_RES == GAME_UWDEMO)
        {//In UWDemo there is no block structure. Just copy the data directly from file.
            lev_ark_block = new DataLoader.UWBlock();
            lev_ark_block.DataLen = 0x7c06;
            lev_ark_block.Data = LevArk.lev_ark_file_data;
        }
        else
        {
            //Load the tile and object blocks
            DataLoader.LoadUWBlock(LevArk.lev_ark_file_data, newLevelNo, 0x7c06, out lev_ark_block);
        }

        return lev_ark_block;
    }

    /// <summary>
    /// Switchs the level and puts the player at the floor level of the new level
    /// </summary>
    /// <param name="newLevelNo">New level no.</param>
    /// <param name="newTileX">New tile x.</param>
    /// <param name="newTileY">New tile y.</param>
    public void SwitchLevel(short newLevelNo, short newTileX, short newTileY)
    {
        startX = newTileX;
        startY = newTileY;
        StartHeight = -1;
        SwitchLevel(newLevelNo);
    }

    /// <summary>
    /// Switchs the level and puts the player at the specified height
    /// </summary>
    /// <param name="newLevelNo"></param>
    /// <param name="newTileX"></param>
    /// <param name="newTileY"></param>
    /// <param name="newStartHeight"></param>
    public void SwitchLevel(short newLevelNo, short newTileX, short newTileY, short newStartHeight)
    {
        startX = newTileX;
        startY = newTileY;
        StartHeight = newStartHeight;
        SwitchLevel(newLevelNo);
    }

     /// <summary>
    /// Detects where the player currently is an updates their swimming state and auto map as needed.
    /// </summary>
    public void PositionDetect()
    {
        if ((AtMainMenu == true) || (WindowDetect.InMap))
        {
            return;
        }
        if ((_RES != GAME_UW1) && (_RES != GAME_UWDEMO) && (_RES != GAME_UW2))
        {
            return;
        }
        TileMap.visitTileX = (short)(UWCharacter.Instance.transform.position.x / 1.2f);
        TileMap.visitTileY = (short)(UWCharacter.Instance.transform.position.z / 1.2f);
        //UWCharacter.Instance.room = CurrentTileMap().Tiles[TileMap.visitTileX, TileMap.visitTileY].roomRegion;

        if (EditorMode)
        {
            if ((TileMap.visitedTileX != TileMap.visitTileX) || (TileMap.visitedTileY != TileMap.visitTileY))
            {
                if (IngameEditor.FollowMeMode)
                {
                    IngameEditor.UpdateFollowMeMode(TileMap.visitTileX, TileMap.visitTileY);
                }
            }
        }

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if
                    (
                        (
                                (TileMap.visitTileX + x >= 0) && (TileMap.visitTileX + x <= TileMap.TileMapSizeX)
                        )
                        &&
                        (
                                (TileMap.visitTileY + y >= 0) && (TileMap.visitTileY + y <= TileMap.TileMapSizeY)
                        )
                    )
                {
                    CurrentAutoMap().MarkTile(TileMap.visitTileX + x, TileMap.visitTileY + y, CurrentTileMap().Tiles[TileMap.visitTileX + x, TileMap.visitTileY + y].tileType, AutoMap.GetDisplayType(CurrentTileMap().Tiles[TileMap.visitTileX + x, TileMap.visitTileY + y]));
                }
            }
        }
        TileMap.visitedTileX = TileMap.visitTileX;
        TileMap.visitedTileY = TileMap.visitTileY;
        UWCharacter.Instance.CurrentTerrain = CurrentTileMap().Tiles[TileMap.visitTileX, TileMap.visitTileY].terrain;
        UWCharacter.Instance.terrainType = TerrainDatLoader.getTerrain(UWCharacter.Instance.CurrentTerrain);
    }


    /// <summary>
    /// Moves the object to the game world where it will be managed by the objectloader list
    /// </summary>
    /// <param name="obj">Object.</param>
    public static void MoveToWorld(GameObject obj)
    {
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
        obj.UpdatePosition();
        //if (obj.transform.parent == GameWorldController.instance.DynamicObjectMarker())
        //{
        //		Debug.Log("Moving to world when object is already in world " + obj.name);
        //}
        obj.transform.parent = GameWorldController.instance.DynamicObjectMarker();
        ObjectLoader.AssignObjectToList(ref obj);
        //	ObjectInteraction.UpdateLinkedList(obj, TileMap.ObjectStorageTile, TileMap.ObjectStorageTile, obj.tileX, obj.tileY);
        //obj.next=0;
        //obj.UpdatePosition();
        //obj.tileX=-1;
        //obj.tileY=-1;//Force an update to linked list.
        obj.GetComponent<object_base>().MoveToWorldEvent();
        if (ConversationVM.InConversation)
        {
            Debug.Log("Use of MoveToWorld in conversation. Review usage to avoid object list corruption! " + obj.name);
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
        obj.objectloaderinfo.InUseFlag = 0;//This frees up the slot to be replaced with another item.	
        obj.objectloaderinfo.instance = null;
        if (_RES == GAME_UW2)//Does this need to be done for uw1 as well.
        {
            ObjectLoaderInfo.CleanUp(obj.objectloaderinfo);
        }
        obj.GetComponent<object_base>().MoveToInventoryEvent();
        //ObjectInteraction.UpdateLinkedList(obj, obj.tileX, obj.tileY, TileMap.ObjectStorageTile,TileMap.ObjectStorageTile);
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
        foreach (Transform t in GameWorldController.instance.DynamicObjectMarker())
        {
            if (t.gameObject.GetComponent<ObjectInteraction>() != null)
            {
                t.gameObject.GetComponent<ObjectInteraction>().UpdatePosition();
            }
        }
    }


    /// <summary>
    /// Inits the level object data, maps and textures objects as required by each game.
    /// </summary>
    void InitLevelData()
    {
        // Path to lev.ark file to load
        string Lev_Ark_File;

        switch (_RES)
        {
            case GAME_SHOCK:
                Tilemaps = new TileMap[15];
                objectList = new ObjectLoader[15];
                break;
            case GAME_UWDEMO:
                Tilemaps = new TileMap[1];
                objectList = new ObjectLoader[1];
                AutoMaps = new AutoMap[1];
                break;
            case GAME_UW2:
                Tilemaps = new TileMap[80];//Not all are in use.
                objectList = new ObjectLoader[80];
                AutoMaps = new AutoMap[80];
                break;
            case GAME_UW1:
            default:
                Tilemaps = new TileMap[9];
                objectList = new ObjectLoader[9];
                AutoMaps = new AutoMap[9];
                break;
        }
        
        switch (UWEBase._RES)
        {
            case UWEBase.GAME_SHOCK:
                MaterialMasterList = new Material[273];
                break;
            case UWEBase.GAME_UWDEMO:
                MaterialMasterList = new Material[58];
                break;
            case UWEBase.GAME_UW2:
                MaterialMasterList = new Material[256];//For each texture in UW2
                break;
            case UWEBase.GAME_UW1:
            default:
                MaterialMasterList = new Material[260];//For each texture in UW1
                break;
        }

        //Load up my map materials
        for (int i = 0; i <= MaterialMasterList.GetUpperBound(0); i++)
        {
            if (File.Exists(texLoader.ModPath(i)))
            {
                MaterialMasterList[i] = (Material)Resources.Load("Materials/ModShaders/" + _RES + "_" + i.ToString("d3"));
            }
            else
            {
                MaterialMasterList[i] = (Material)Resources.Load(_RES + "/Materials/textures/" + _RES + "_" + i.ToString("d3"));
            }            
            switch (MaterialMasterList[i].shader.name.ToUpper())
            {
                case "COLOURREPLACEMENT":
                case "COLOURREPLACEMENTREVERSE":
                    MaterialMasterList[i].mainTexture = texLoader.LoadImageAt(i, 1);//load a greyscale texture for use with the shader.
                    break;
                case "BASICUWSHADER":
                    MaterialMasterList[i].mainTexture = texLoader.LoadImageAt(i, 0);
                    break;
                case "LEGACY SHADERS/BUMPED DIFFUSE":
                    {
                        Texture2D loadedTexture = texLoader.LoadImageAt(i, 2);//Get normal map from mod directory
                        MaterialMasterList[i].mainTexture = texLoader.LoadImageAt(i, 0);
                        if (loadedTexture != null)
                        {
                            MaterialMasterList[i].SetTexture("_BumpMap", TextureLoader.NormalMap(loadedTexture, TextureLoader.BumpMapStrength));
                        }
                    }
                    break;
                default:
                    Debug.Log(i + " is " + MaterialMasterList[i].shader.name);
                    MaterialMasterList[i].mainTexture = texLoader.LoadImageAt(i, 0);
                    break;
            }
        }
        if (_RES == GAME_UW1)
        {
            SpecialMaterials[0] = (Material)Resources.Load(_RES + "/Materials/textures/" + _RES + "_224_maze");
            SpecialMaterials[0].mainTexture = texLoader.LoadImageAt(224);
        }
        MaterialObj = new Material[TmObjArt.NoOfFileImages()];

        //Load the materials for the TMOBJ file
        for (int i = 0; i <= MaterialObj.GetUpperBound(0); i++)
        {
            MaterialObj[i] = (Material)Resources.Load(_RES + "/Materials/tmobj/tmobj_" + i.ToString("d2"));
            if (MaterialObj[i] != null)
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
                for (int i = 0; i <= MaterialDoors.GetUpperBound(0); i++)
                {
                    MaterialDoors[i] = (Material)Resources.Load(_RES + "/Materials/doors/doors_" + i.ToString("d2") + "_material");
                    MaterialDoors[i].mainTexture = DoorArt.LoadImageAt(i);
                }
                break;

        }

        //Load up my tile maps
        //First read in my lev_ark file
        switch (UWEBase._RES)
        {
            case GAME_SHOCK:
                Lev_Ark_File = "RES" + sep + "DATA" + sep + "ARCHIVE.DAT";
                break;
            case UWEBase.GAME_UWDEMO:
                Lev_Ark_File = "DATA" + sep + "LEVEL13.ST";
                break;
            case UWEBase.GAME_UW2:
            case UWEBase.GAME_UW1:
            default:
                Lev_Ark_File = Lev_Ark_File_Selected; //"DATA\\lev.ark";//Eventually this will be a save game.
                break;
        }

        if (!DataLoader.ReadStreamFile(Loader.BasePath + Lev_Ark_File, out LevArk.lev_ark_file_data))
        {
            Debug.Log(Loader.BasePath + Lev_Ark_File + "File not loaded");
            Application.Quit();
        }

        //Load up auto map data
        switch (_RES)
        {
            case GAME_UWDEMO:
                AutoMaps[0] = new AutoMap();
                AutoMaps[0].InitAutoMapDemo();
                break;
            case GAME_UW1:
                for (int i = 0; i <= AutoMaps.GetUpperBound(0); i++)
                {
                    AutoMaps[i] = new AutoMap();
                    AutoMaps[i].InitAutoMapUW1(i, LevArk.lev_ark_file_data);
                }
                break;
            case GAME_UW2:
                for (int i = 0; i <= AutoMaps.GetUpperBound(0); i++)
                {
                    AutoMaps[i] = new AutoMap();
                    AutoMaps[i].InitAutoMapUW2(i, LevArk.lev_ark_file_data);
                }
                break;
        }

        switch (_RES)
        {
            case GAME_UW2:
                events = new event_processor();
                if (whatTheHellIsThatFileFor != null)
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
        if (SlotNo == 0)
        {//Init from BABGLOBS.DAT. Initialise the data.
            if (DataLoader.ReadStreamFile(Loader.BasePath + "DATA" + sep + "BABGLOBS.DAT", out bglob_data))
            {
                int NoOfSlots = bglob_data.GetUpperBound(0) / 4;
                int add_ptr = 0;
                bGlobals = new bablGlobal[NoOfSlots + 1];
                for (int i = 0; i <= NoOfSlots; i++)
                {
                    bGlobals[i].ConversationNo = (int)DataLoader.getValAtAddress(bglob_data, add_ptr, 16);
                    bGlobals[i].Size = (int)DataLoader.getValAtAddress(bglob_data, add_ptr + 2, 16);
                    bGlobals[i].Globals = new int[bGlobals[i].Size];
                    add_ptr = add_ptr + 4;
                }
            }
        }
        else
        {
            int NoOfSlots = 0;//Assumes the same no of slots that is in the babglobs is in bglobals.
            if (DataLoader.ReadStreamFile(Loader.BasePath + "DATA" + sep + "BABGLOBS.DAT", out bglob_data))
            {
                NoOfSlots = bglob_data.GetUpperBound(0) / 4;
                NoOfSlots++;
            }
            if (DataLoader.ReadStreamFile(Loader.BasePath + "SAVE" + SlotNo + sep + "BGLOBALS.DAT", out bglob_data))
            {
                //int NoOfSlots = bglob_data.GetUpperBound(0)/4;
                int add_ptr = 0;
                bGlobals = new bablGlobal[NoOfSlots];
                for (int i = 0; i < NoOfSlots; i++)
                {

                    bGlobals[i].ConversationNo = (int)DataLoader.getValAtAddress(bglob_data, add_ptr, 16);
                    bGlobals[i].Size = (int)DataLoader.getValAtAddress(bglob_data, add_ptr + 2, 16);
                    bGlobals[i].Globals = new int[bGlobals[i].Size];
                    add_ptr += 4;
                    for (int g = 0; g < bGlobals[i].Size; g++)
                    {
                        bGlobals[i].Globals[g] = (int)DataLoader.getValAtAddress(bglob_data, add_ptr, 16);
                        if (bGlobals[i].Globals[g] == 65535)
                        {
                            bGlobals[i].Globals[g] = 0;
                        }
                        add_ptr = add_ptr + 2;
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
        int fileSize = 0;
        for (int c = 0; c <= bGlobals.GetUpperBound(0); c++)
        {
            fileSize += 4;  //No and size
            fileSize += bGlobals[c].Size * 2;
        }
        //Create an output byte array
        Byte[] output = new byte[fileSize];
        int add_ptr = 0;
        for (int c = 0; c <= bGlobals.GetUpperBound(0); c++)
        {
            //Write Slot No
            output[add_ptr] = (byte)(bGlobals[c].ConversationNo & 0xff);
            output[add_ptr + 1] = (byte)((bGlobals[c].ConversationNo >> 8) & 0xff);
            //Write Size
            output[add_ptr + 2] = (byte)(bGlobals[c].Size & 0xff);
            output[add_ptr + 3] = (byte)((bGlobals[c].Size >> 8) & 0xff);
            add_ptr = add_ptr + 4;
            for (int g = 0; g <= bGlobals[c].Globals.GetUpperBound(0); g++)
            {
                output[add_ptr] = (byte)(bGlobals[c].Globals[g] & 0xff);
                output[add_ptr + 1] = (byte)((bGlobals[c].Globals[g] >> 8) & 0xff);
                add_ptr += 2;
            }
        }
        File.WriteAllBytes(Loader.BasePath + "SAVE" + SlotNo + sep + "BGLOBALS.DAT", output);

    }
    
    /// <summary>
    /// Switchs to a Terra nova map.
    /// </summary>
    /// <param name="levelFileName">Level file name.</param>
    public void SwitchTNovaMap(string levelFileName)
    {
        string path;
        if (levelFileName == "")
        {
            path = NovaLevelSelect.MapSelected;
        }
        else
        {
            path = levelFileName;		
        }

        char[] archive_ark;
        if (DataLoader.ReadStreamFile(path, out archive_ark))
        {
            DataLoader.Chunk lev_ark;
            if (!DataLoader.LoadChunk(archive_ark, 86, out lev_ark))
            {
                return;
            }
            UWCharacter.Instance.playerCam.GetComponent<Light>().range = 2000f;
            UWCharacter.Instance.playerCam.farClipPlane = 30000f;
            TNovaTerrain.gameObject.SetActive(true);
            TileMapRenderer.RenderTNovaMapTerrain(TNovaLevelModel.transform, lev_ark.data);
        }

        //Try and play sound file from a tnova res file
        char[] sound_ark;
        if (DataLoader.ReadStreamFile("C:\\Games\\Terra Nova\\CD\\Terra_Nova\\SPEECH\\RESBRK01.RES", out sound_ark))
        {
            DataLoader.Chunk voc_file;
            if (!DataLoader.LoadChunk(sound_ark, 3308, out voc_file))
            {
                return;
            }
            VocLoader voc = new VocLoader(voc_file.data, "tnova");
            MusicController.instance.Aud.clip = voc.Audio;
            MusicController.instance.Aud.loop = true;
            MusicController.instance.Aud.Play();
        }
    }



    /// <summary>
    /// Loads the config file.
    /// </summary>
    /// <returns><c>true</c>, if config file was loaded, <c>false</c> otherwise.</returns>
    bool LoadConfigFile()
    {
        string fileName = Application.dataPath + sep + ".." + sep + "config.ini";
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
                        if (line.Length > 1)
                        {
                            if ((line.Substring(1, 1) != ";") && (line.Contains("=")))//Is not a commment and contains a param
                            {
                                string[] entries = line.Split('=');
                                //int val = 0;
                                //string pathfound="";
                                KeyCode keyCodeToUse;
                                KeyBindings.instance.chartoKeycode.TryGetValue(entries[1].ToLower(), out keyCodeToUse);

                                switch (entries[0].ToUpper())
                                {
                                    case "MOUSEX"://Mouse sensitivity X
                                        {
                                            float val = 15f;
                                            if (float.TryParse(entries[1], out val))
                                            {
                                                MouseX.sensitivityX = val;
                                            }
                                            break;
                                        }
                                    case "MOUSEY"://Mouse sensitivity Y
                                        {
                                            float val = 15f;
                                            if (float.TryParse(entries[1], out val))
                                            {
                                                MouseY.sensitivityY = val;
                                            }
                                            break;
                                        }
                                    case "PATH_UW0":
                                        {
                                            path_uw0 = UWClass.CleanPath(entries[1]);
                                            break;
                                        }
                                    case "PATH_UW1":
                                        {
                                            path_uw1 = UWClass.CleanPath(entries[1]);
                                            break;
                                        }
                                    case "PATH_UW2":
                                        {
                                            path_uw2 = UWClass.CleanPath(entries[1]);
                                            break;
                                        }
                                    case "PATH_SHOCK":
                                        {
                                            path_shock = UWClass.CleanPath(entries[1]);
                                            break;
                                        }
                                    case "PATH_TNOVA":
                                        {
                                            path_tnova = UWClass.CleanPath(entries[1]);
                                            break;
                                        }

                                    case "FLYUP":
                                        KeyBindings.instance.FlyUp = keyCodeToUse; break;
                                    case "FLYDOWN":
                                        KeyBindings.instance.FlyDown = keyCodeToUse; break;
                                    case "TOGGLEMOUSELOOK":
                                        KeyBindings.instance.ToggleMouseLook = keyCodeToUse; break;
                                    case "TOGGLEFULLSCREEN":
                                        KeyBindings.instance.ToggleFullScreen = keyCodeToUse; break;
                                    case "INTERACTIONOPTIONS":
                                        KeyBindings.instance.InteractionOptions = keyCodeToUse; break;
                                    case "INTERACTIONTALK":
                                        KeyBindings.instance.InteractionTalk = keyCodeToUse; break;
                                    case "INTERACTIONPICKUP":
                                        KeyBindings.instance.InteractionPickup = keyCodeToUse; break;
                                    case "INTERACTIONLOOK":
                                        KeyBindings.instance.InteractionLook = keyCodeToUse; break;
                                    case "INTERACTIONATTACK":
                                        KeyBindings.instance.InteractionAttack = keyCodeToUse; break;
                                    case "INTERACTIONUSE":
                                        KeyBindings.instance.InteractionUse = keyCodeToUse; break;
                                    case "CASTSPELL":
                                        KeyBindings.instance.CastSpell = keyCodeToUse; break;
                                    case "TRACKSKILL":
                                        KeyBindings.instance.TrackSkill = keyCodeToUse; break;


                                    case "DEFAULTLIGHTLEVEL":
                                        {
                                            float lightlevel = 16f;
                                            if (float.TryParse(entries[1], out lightlevel))
                                            {
                                                LightSource.BaseBrightness = lightlevel;
                                            }
                                            break;
                                        }

                                    case "FOV":
                                        {
                                            float fov = 75f;
                                            if (float.TryParse(entries[1], out fov))
                                            {
                                                Camera.main.fieldOfView = fov;
                                            }
                                            break;
                                        }
                                    case "INFINITEMANA":
                                        {
                                            Magic.InfiniteMana = (entries[1] == "1");
                                            break;
                                        }

                                    case "GODMODE":
                                        {
                                            UWCharacter.Invincible = (entries[1] == "1");
                                            break;
                                        }

                                    case "CONTEXTUIENABLED":
                                        {
                                            WindowDetectUW.ContextUIEnabled = (entries[1] == "1");
                                            break;
                                        }

                                    case "UW1_SOUNDBANK":
                                        {
                                            MusicController.UW1Path = UWClass.CleanPath(entries[1]);
                                            break;
                                        }
                                    case "UW2_SOUNDBANK":
                                        {
                                            MusicController.UW2Path = UWClass.CleanPath(entries[1]);
                                            break;
                                        }
                                    case "GENREPORT":
                                        {
                                            CreateReports = (entries[1] == "1");
                                            break;
                                        }
                                    case "SHOWINUSE"://only show inuse objects in reports
                                        {
                                            ShowOnlyInUse = (entries[1] == "1");
                                            break;
                                        }
                                    case "AUTOKEYUSE":
                                        {
                                            UWCharacter.AutoKeyUse = (entries[1] == "1");
                                            break;
                                        }
                                    case "AUTOEAT":
                                        {
                                            UWCharacter.AutoEat = (entries[1] == "1");
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


    /// <summary>
    /// Creates a report of the objects in the level in an xml format
    /// </summary>
    /// <param name="objList"></param>
    void CreateObjectReport(ObjectLoaderInfo[] objList, int ReportLevelNo)
    {
        StreamWriter writer = new StreamWriter(Application.dataPath + "//..//_objectreport.xml");// true);
        writer.WriteLine("<ObjectReport level =" + ReportLevelNo + "> ");
        //writer.WriteLine("\t<level>" + ReportLevelNo + "</level>");
        for (int o = 0; o <= objList.GetUpperBound(0); o++)
        {
            if (((objList[o].InUseFlag == 0) && (!ShowOnlyInUse)) || (objList[o].InUseFlag == 1))
            {
                //if
                //((objList[o].GetItemType() == ObjectInteraction.A_CHECK_VARIABLE_TRAP)||(objList[o].GetItemType() == ObjectInteraction.A_SET_VARIABLE_TRAP))
                //{
                    WriteObjectXML(objList, writer, o);
                //}               
            }
        }

        writer.WriteLine("</ObjectReport>");
        writer.Close();
    }

    private static void WriteObjectXML(ObjectLoaderInfo[] objList, StreamWriter writer, int o)
    {
        writer.WriteLine("\t<Object>");
        writer.WriteLine("\t\t<ObjectName>" + ObjectLoader.UniqueObjectNameEditor(objList[o]) + "</ObjectName>");
        writer.WriteLine("\t\t<Index>" + o + "</Index>");
        writer.WriteLine("\t\t<Address>" + objList[o].address + "</Address>");
        writer.WriteLine("\t\t<StaticProperties>");
        writer.WriteLine("\t\t\t<ItemID>" + objList[o].item_id + "</ItemID>");
        writer.WriteLine("\t\t\t<InUse>" + objList[o].InUseFlag + "</InUse>");
        writer.WriteLine("\t\t\t<Flags>" + objList[o].flags + "</Flags>");
        writer.WriteLine("\t\t\t<Enchant>" + objList[o].enchantment + "</Enchant>");
        writer.WriteLine("\t\t\t<DoorDir>" + objList[o].doordir + "</DoorDir>");
        writer.WriteLine("\t\t\t<Invis>" + objList[o].invis + "</Invis>");
        writer.WriteLine("\t\t\t<IsQuant>" + objList[o].is_quant + "</IsQuant>");
        writer.WriteLine("\t\t\t<Texture>" + objList[o].texture + "</Texture>");
        writer.WriteLine("\t\t\t<Position>");
        writer.WriteLine("\t\t\t\t<ObjectTileX>" + objList[o].ObjectTileX + "</ObjectTileX>");
        writer.WriteLine("\t\t\t\t<ObjectTileY>" + objList[o].ObjectTileY + "</ObjectTileY>");
        writer.WriteLine("\t\t\t\t<heading>" + objList[o].heading + "</heading>");
        writer.WriteLine("\t\t\t\t<xpos>" + objList[o].xpos + "</xpos>");
        writer.WriteLine("\t\t\t\t<ypos>" + objList[o].ypos + "</ypos>");
        writer.WriteLine("\t\t\t\t<zpos>" + objList[o].zpos + "</zpos>");
        writer.WriteLine("\t\t\t</Position>");
        writer.WriteLine("\t\t\t<Quality>" + objList[o].quality + "</Quality>");
        writer.WriteLine("\t\t\t<Next>" + objList[o].next + "</Next>");
        writer.WriteLine("\t\t\t<Owner>" + objList[o].owner + "</Owner>");
        writer.WriteLine("\t\t\t<Link>" + objList[o].link + "</Link>");
        writer.WriteLine("\t\t</StaticProperties>");
        if (o < 256)
        {//mobile info
            writer.WriteLine("\t\t<MobileProperties>");
            writer.WriteLine("\t\t\t<npc_hp>" + objList[o].npc_hp + "</npc_hp>");
            writer.WriteLine("\t\t\t<ProjectileHeadingMinor>" + objList[o].ProjectileHeadingMinor + "</ProjectileHeadingMinor>");
            writer.WriteLine("\t\t\t<ProjectileHeadingMajor>" + objList[o].ProjectileHeadingMajor + "</ProjectileHeadingMajor>");
            writer.WriteLine("\t\t\t<MobileUnk01>" + objList[o].MobileUnk01 + "</MobileUnk01>");
            writer.WriteLine("\t\t\t<npc_goal>" + objList[o].npc_goal + "</npc_goal>");
            writer.WriteLine("\t\t\t<npc_gtarg>" + objList[o].npc_gtarg + "</npc_gtarg>");
            writer.WriteLine("\t\t\t<MobileUnk02>" + objList[o].MobileUnk02 + "</MobileUnk02>");
            writer.WriteLine("\t\t\t<npc_level>" + objList[o].npc_level + "</npc_level>");
            writer.WriteLine("\t\t\t<MobileUnk03>" + objList[o].MobileUnk03 + "</MobileUnk03>");
            writer.WriteLine("\t\t\t<MobileUnk04>" + objList[o].MobileUnk04 + "</MobileUnk04>");
            writer.WriteLine("\t\t\t<npc_talkedto>" + objList[o].npc_talkedto + "</npc_talkedto>");
            writer.WriteLine("\t\t\t<npc_attitude>" + objList[o].npc_attitude + "</npc_attitude>");
            writer.WriteLine("\t\t\t<MobileUnk05>" + objList[o].MobileUnk05 + "</MobileUnk05>");
            writer.WriteLine("\t\t\t<npc_height>" + objList[o].npc_height + "</npc_height>");
            writer.WriteLine("\t\t\t<MobileUnk06>" + objList[o].MobileUnk06 + "</MobileUnk06>");
            writer.WriteLine("\t\t\t<MobileUnk07>" + objList[o].MobileUnk07 + "</MobileUnk07>");
            writer.WriteLine("\t\t\t<MobileUnk08>" + objList[o].MobileUnk08 + "</MobileUnk08>");
            writer.WriteLine("\t\t\t<MobileUnk09>" + objList[o].MobileUnk09 + "</MobileUnk09>");
            writer.WriteLine("\t\t\t<Projectile_Speed>" + objList[o].Projectile_Speed + "</Projectile_Speed>");
            writer.WriteLine("\t\t\t<Projectile_Pitch>" + objList[o].Projectile_Pitch + "</Projectile_Pitch>");
            writer.WriteLine("\t\t\t<Projectile_Sign>" + objList[o].Projectile_Sign + "</Projectile_Sign>");
            writer.WriteLine("\t\t\t<npc_voidanim>" + objList[o].npc_voidanim + "</npc_voidanim>");
            writer.WriteLine("\t\t\t<MobileUnk11>" + objList[o].MobileUnk11 + "</MobileUnk11>");
            writer.WriteLine("\t\t\t<MobileUnk12>" + objList[o].MobileUnk12 + "</MobileUnk12>");
            writer.WriteLine("\t\t\t<npc_yhome>" + objList[o].npc_yhome + "</npc_yhome>");
            writer.WriteLine("\t\t\t<npc_xhome>" + objList[o].npc_xhome + "</npc_xhome>");
            writer.WriteLine("\t\t\t<npc_heading>" + objList[o].npc_heading + "</npc_heading>");
            writer.WriteLine("\t\t\t<MobileUnk13>" + objList[o].MobileUnk13 + "</MobileUnk13>");
            writer.WriteLine("\t\t\t<npc_hunger>" + objList[o].npc_hunger + "</npc_hunger>");
            writer.WriteLine("\t\t\t<MobileUnk14>" + objList[o].MobileUnk14 + "</MobileUnk14>");
            writer.WriteLine("\t\t\t<npc_whoami>" + objList[o].npc_whoami + "</npc_whoami>");
            writer.WriteLine("\t\t</MobileProperties>");
        }
        writer.WriteLine("\t</Object>");
    }

    /// <summary>
    /// Gets what world is associated with the current level
    /// </summary>
    /// <param name="levelNo"></param>
    /// <returns></returns>
    public static Worlds GetWorld(int levelNo)
    {
        if (_RES != GAME_UW2) { return Worlds.Britannia; }
        switch ((UW2_LevelNos)levelNo)
        {
            case UW2_LevelNos.Britannia0:
            case UW2_LevelNos.Britannia1:
            case UW2_LevelNos.Britannia2:
            case UW2_LevelNos.Britannia3:
            case UW2_LevelNos.Britannia4:
                return Worlds.Britannia;
            case UW2_LevelNos.Prison0:
            case UW2_LevelNos.Prison1:
            case UW2_LevelNos.Prison2:
            case UW2_LevelNos.Prison3:
            case UW2_LevelNos.Prison4:
            case UW2_LevelNos.Prison5:
            case UW2_LevelNos.Prison6:
            case UW2_LevelNos.Prison7:
                return Worlds.PrisonTower;
            case UW2_LevelNos.Killorn0:
            case UW2_LevelNos.Killorn1:
                return Worlds.Killorn;
            case UW2_LevelNos.Ice0:
            case UW2_LevelNos.Ice1:
                return Worlds.Ice;
            case UW2_LevelNos.Talorus0:
            case UW2_LevelNos.Talorus1:
                return Worlds.Talorus;
            case UW2_LevelNos.Academy0:
            case UW2_LevelNos.Academy1:
            case UW2_LevelNos.Academy2:
            case UW2_LevelNos.Academy3:
            case UW2_LevelNos.Academy4:
            case UW2_LevelNos.Academy5:
            case UW2_LevelNos.Academy6:
            case UW2_LevelNos.Academy7:
                return Worlds.Academy;
            case UW2_LevelNos.Tomb0:
            case UW2_LevelNos.Tomb1:
            case UW2_LevelNos.Tomb2:
            case UW2_LevelNos.Tomb3:
                return Worlds.Tomb;
            case UW2_LevelNos.Pits0:
            case UW2_LevelNos.Pits1:
            case UW2_LevelNos.Pits2:
                return Worlds.Pits;
            case UW2_LevelNos.Ethereal0:
            case UW2_LevelNos.Ethereal1:
            case UW2_LevelNos.Ethereal2:
            case UW2_LevelNos.Ethereal3:
            case UW2_LevelNos.Ethereal4:
            case UW2_LevelNos.Ethereal5:
            case UW2_LevelNos.Ethereal6:
            case UW2_LevelNos.Ethereal7:
            case UW2_LevelNos.Ethereal8:
                return Worlds.Ethereal;
            default:
                Debug.Log("Unknown level/world");
                return Worlds.Ethereal;
        }
    }
}