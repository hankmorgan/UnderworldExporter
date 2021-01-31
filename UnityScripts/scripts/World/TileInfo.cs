using UnityEngine;
using System.Collections;

public class TileInfo : Loader
{

    /// <summary>
    /// PTR to the file data in the UW Block for this tile.
    /// </summary>
    public long Ptr
    {
        get
        {
            return tileX * 4 + tileY * 256;
        }
    }

    /// <summary>
    /// Reference to the tilemap containing this tile
    /// </summary>
    public TileMap map;

    /// <summary>
    /// What type of tile this is
    /// </summary>
    public short tileType
    {
        get
        {
            return (short)(map.lev_ark_block.Data[Ptr] & 0x0F);
        }
        set
        {
            int val = (short)(map.lev_ark_block.Data[Ptr]);
            val = val & 0xF0;
            val = val | (value & 0xF);
            map.lev_ark_block.Data[Ptr] = (char)val;
        }
    }

    /// <summary>
    /// How high is the floor.
    /// </summary>
    public short floorHeight
    {
        get
        {
            return (short)(2 * (map.lev_ark_block.Data[Ptr] & 0xF0) >> 4);
        }
        set
        {
            int val = (short)(map.lev_ark_block.Data[Ptr]);
            val = val & 0x0F;
            val = val | (((value / 2) & 0xF) << 4);
            map.lev_ark_block.Data[Ptr] = (char)val;
        }
    }

    /// <summary>
    /// How low is the ceiling
    /// </summary>
    /// Constant in UW. Variable in shock
    public short ceilingHeight;

    //Index into the texture map table for the actual floor texture of this tile.
    //private short _floorTexture;
    public short floorTexture
    {
        get
        {
            return (short)((map.lev_ark_block.Data[Ptr + 1] >> 2) & 0x0F);
            //return _floorTexture;
        }
        set
        {
            int val = (short)(map.lev_ark_block.Data[Ptr + 1]);
            val = val & 0xC3;
            val = val | ((value & 0xF) << 2);
            map.lev_ark_block.Data[Ptr + 1] = (char)val;
        }
    }

    /// <summary>
    /// Index into texture map for the wall texture presented to other tiles by this tile.
    /// </summary>
    public short wallTexture
    {
        get
        {
            return (short)(map.lev_ark_block.Data[Ptr + 2] & 0x3F);
        }
        set
        {
            int val = (short)(map.lev_ark_block.Data[Ptr + 2]);
            val = val & 0xC0;
            val = val | ((value & 0x3F));
            map.lev_ark_block.Data[Ptr + 2] = (char)val;
        }
    }

    /// <summary>
    /// /Points to a linked list of objects in the objects block
    /// </summary>
    public int indexObjectList
    {
        get
        {
             return (short)(getValAtAddress(map.lev_ark_block.Data, Ptr + 2, 16)>>6);
        }
        set
        {
            int val = ((value & 0x3FF) << 6) | (wallTexture & 0x3F);
            map.lev_ark_block.Data[Ptr + 2] = (char)(val & 0xFF);
            map.lev_ark_block.Data[Ptr + 3] = (char)((val >> 8) & 0xFF);
        }
    }

    /// <summary>
    /// Does this tile contain a door per uw-formats.txt
    /// </summary>    /
    public short doorBit
    {
        get
        {
            return (short)((map.lev_ark_block.Data[Ptr + 1] >> 7) & 0x01);
        }
        set
        {
            int val = (short)(map.lev_ark_block.Data[Ptr + 1]);
            val = val & 0x7F;
            val = val | ((value & 0x1) << 7);
            map.lev_ark_block.Data[Ptr + 1] = (char)val;
        }
    }
    /// <summary>
    /// Set when ever a tile does contain a door regardless of the door bit above.
    /// </summary>
    public bool IsDoorForNPC;
    /// <summary>
    /// If set then we output this tile. Is off when it is a subpart of a group or is hidden from sight.
    /// </summary>
    public bool Render=true;
    /// <summary>
    ///  The dimensions on the x-axis of this tile. 1 for a regular tile.
    /// </summary>
    public short DimX = 1;
    /// <summary>
    /// The dimensions on the y-axis of this tile. 1 for a regular tile.
    /// </summary>
    public short DimY = 1;
    /// <summary>
    /// indicates the tile is a child of a group pareted by a tile of DimX>1 or DimY>1
    /// </summary>
    public bool Grouped=false;
    /// <summary>
    /// Which faces are visible on a tile. Used to reduce mesh complexity.
    /// </summary>
    public bool[] VisibleFaces = { true, true, true, true, true, true };
    /// <summary>
    /// The texture to display on the north face of the tile
    /// </summary>
    /// Based on the actual wall texture value of the tile located in that direction 
    public short North;
    /// <summary>
    /// The texture to display on the south face of the tile
    /// </summary>
    /// Based on the actual wall texture value of the tile located in that direction 
    public short South;
    /// <summary>
    /// The texture to display on the east face of the tile
    /// </summary>
    /// Based on the actual wall texture value of the tile located in that direction 
    public short East;
    /// <summary>
    /// The texture to display on the west face of the tile
    /// </summary>
    /// Based on the actual wall texture value of the tile located in that direction 
    public short West;

    /// <summary>
    /// Is the terrain land?
    /// </summary>
    public bool isLand
    {
        get
        {
            return ! ( (isWater) || (isLava) || (isNothing) );
        }       
    }

    /// <summary>
    /// Checks if the tile is water.
    /// </summary>
    public bool isWater
    {
        get
        {
            return TileMap.isTerrainWater(terrain);
        }
    }
    /// <summary>
    /// Checks if the tile is icy
    /// </summary>
    public bool isIce
    {
        get
        {
            return TileMap.isTerrainIce(terrain);
        }
    }
    
    /// <summary>
    /// Check if the tile on on lava
    /// </summary>
    public bool isLava
    {
        get
        {
            return TileMap.isTerrainLava(terrain);
        }
    }
    /// <summary>
    /// Set when the tile contains a bridge.
    /// </summary>
    public bool hasBridge;
    /// <summary>
    /// Set when the tile has the nothing textures
    /// </summary>
    public bool isNothing;
    /// <summary>
    /// Index to the contigous room area that the tile is part of.
    /// </summary>
    /// Used for AI decision making
    public short roomRegion;  
    /// <summary>
    /// The x position of this tile
    /// </summary>
    public short tileX;
    /// <summary>
    /// The y position of this tile.
    /// </summary>
    public short tileY;

    /// <summary>
    /// UW Tile flags - Unknown purpose
    /// </summary>
    public short flags
    {
        get
        {
            return (short)(map.lev_ark_block.Data[Ptr + 1] & 0x03);
        }
        set
        {
            int val = (short)(map.lev_ark_block.Data[Ptr+1]);
            val = val & 0xFC;
            val = val | (value & 0x3);
            map.lev_ark_block.Data[Ptr+1] = (char)val;
        }
    }


    /// <summary>
    /// Only seems to matter on Level 9 and possibly where there is water? 
    /// UPDATE>Possible bug in reading data. Retest this. TODO:
    /// </summary>
    public short noMagic
    {
        get
        {
            return (short)((map.lev_ark_block.Data[Ptr + 1]>>6) & 0x01);
        }
        set
        {
            int val = (short)(map.lev_ark_block.Data[Ptr + 1]);
            val = val & 0xBF;
            val = val | ((value & 0x1)<<6);
            map.lev_ark_block.Data[Ptr + 1] = (char)val;
        }
    }

    //Shock Specific Stuff
    public short shockSlopeFlag = TileMap.SLOPE_FLOOR_ONLY;    //For controlling ceiling slopes for shock.
    public short shockCeilingTexture;

    public short _shockTileSlopeSteepness;
    public short TileSlopeSteepness
    {
        get
        {
            switch(_RES)
            {
                case GAME_SHOCK:
                    return _shockTileSlopeSteepness;
                default:
                    if (tileType >= 2)
                    {
                        return 2;
                    }
                    else
                    {
                        return 0;
                    }
            }
        }
        set
        {
            switch (_RES)
            {
                case GAME_SHOCK:
                    _shockTileSlopeSteepness = value;
                    break;
                default:
                    //do nothing read only.
                    break;  
            }
        }
    }
    public short UseAdjacentTextures;
    public short shockTextureOffset;
    public short shockNorthOffset; public short shockSouthOffset;
    public short shockEastOffset; public short shockWestOffset;
    public short shockShadeUpper;
    public short shockShadeLower;
    public short shockNorthCeilHeight; public short shockSouthCeilHeight;
    public short shockEastCeilHeight; public short shockWestCeilHeight;
    public short shockFloorOrientation; public short shockCeilOrientation;


    /// <summary>
    /// Indicates that the tile can change into another type of tile or moves in someway. Eg change terrain trap.
    /// </summary>
    /// Used to prevent cleanup of this tile.
    public bool TerrainChange;  //

    public int[] SHOCKSTATE = new int[4];   //These should be ff,00,00,00 on an initial map. I'm just bringing them back for research purposes.

    /// <summary>
    /// Indicates the tile needs to be redrawn.
    /// </summary>
    public bool NeedsReRender = false;

    /// <summary>
    /// Does the tile contain a pressure trigger. Used to test pickups of objects from the tile.
    /// </summary>
    public short PressureTriggerIndex = 0;

    //The terrain on the tile. Result will change when the floor texture is updated.
   // private int _terrain;
    public int terrain
    {
        get
        {
            //Set the terrain type for the tile when the texture changes
            switch (_RES)
            {
                case GAME_UWDEMO:
                case GAME_UW1:
                    return GameWorldController.instance.terrainData.Terrain[46 + map.texture_map[floorTexture + 48]];
                case GAME_UW2:
                    return  GameWorldController.instance.terrainData.Terrain[map.texture_map[floorTexture]];
                default:
                    return 0;
            }
        }
    }

    public TileInfo()
    {
        //Empty constructor for shock
    }

    /// <summary>
    /// Initialise a tile with parameters for source data and X,Y offset into data.
    /// </summary>
    /// <param name="tm"></param>
    /// <param name="X"></param>
    /// <param name="Y"></param>
    public TileInfo(TileMap tm, short X, short Y)
    {
        map = tm;
        tileX = X;
        tileY = Y;

        //Init default render textures.
        North = wallTexture;
        South = wallTexture;
        East = wallTexture;
        West = wallTexture;
    }

    public TileInfo(TileMap tm, short X, short Y, short newtileType, 
            short newfloorHeight, short newceilingHeight,
            short newfloorTexture, short newwallTexture, short newceilTexture, 
            short newFlags, short newnoMagic, short newdoorBit, int newindexObjectList)
    {
        InitTileInfo(tm, X, Y, newtileType, 
            newfloorHeight, newceilingHeight,
            newfloorTexture, newwallTexture, newceilTexture, 
            newFlags, newnoMagic, newdoorBit, newindexObjectList);
    }

    void InitTileInfo(TileMap tm, short X, short Y, short newtiletype,
            short newfloorHeight, short newceilingHeight,
            short newfloorTexture, short newwallTexture, short newceilTexture,
            short newFlags, short newnoMagic, short newdoorBit, int newindexObjectList)
    {
        Debug.Log("Use of obsolete inittileinfo");
        return;

        map = tm;
        ///tileType = newtiletype;
        tileX = X;
        tileY = Y;
        //floorHeight = newfloorHeight;
        ceilingHeight = newceilingHeight;
        //floorTexture = newfloorTexture;
       // wallTexture = newwallTexture;
        shockCeilingTexture = newceilTexture;
       // flags = newFlags;
        //noMagic = newnoMagic;
        //doorBit = newdoorBit;
       // indexObjectList = newindexObjectList;

        //Grouped = false;

        ////////if (floorTexture < 0)
        ////////{
        ////////    floorTexture = 0;
        ////////}
        ////////if (floorTexture >= 262)
        ////////{
        ////////    floorTexture = 0;
        ////////}
        ////////if (wallTexture >= 256)
        ////////{
        ////////   wallTexture = 0;
        ////////}


        //////////Get the terrain type for the tile.
        ////////switch (_RES)
        ////////{
        ////////    case GAME_UWDEMO:
        ////////    case GAME_UW1:
        ////////        _terrain = GameWorldController.instance.terrainData.Terrain[46 + map.texture_map[floorTexture + 48]];
        ////////        break;
        ////////    case GAME_UW2:
        ////////        _terrain = GameWorldController.instance.terrainData.Terrain[map.texture_map[floorTexture]];
        ////////        break;
        ////////    default:
        ////////        _terrain = 0;
        ////////        break;
        ////////}

        //////////if (_RES==GAME_UWDEMO)
        //////////{//texture_map[t.floorTexture + 48];
        //////////    if (map.texture_map[floorTexture + 48] == 56)
        //////////    {
        //////////        _terrain = TerrainDatLoader.Water;
        //////////    }
        //////////}
        //There is only one possible steepness in UW so I set it's properties to match a similar tile in shock.
        //shockSlopeFlag = TileMap.SLOPE_FLOOR_ONLY;
        if (tileType >= 2)
        {
            TileSlopeSteepness = 2;
            //shockSteep = 1;
           // shockSteep = (short)(((shockSteep << 3) >> 2) * 8 >> 3);    //Shift copied from shock
        }

        //Different textures on solid tiles faces
        North = wallTexture;
        South = wallTexture;
        East = wallTexture;
        West = wallTexture;
        //Top = floorTexture;
        //Bottom = floorTexture;
        //Diagonal = wallTexture;

        isNothing = TileMap.isTextureNothing(map.texture_map[floorTexture]);
        if (isNothing)
        {
            Debug.Log("instance of isnothing Why the hell does this exist?" + X + "," + Y);
        }
    }


    /// <summary>
    /// Tells us the tile needs to be updated next LateUpdate
    /// </summary>
    public void TileNeedsUpdate()
    {
        NeedsReRender = true;
        GameWorldController.WorldReRenderPending = true;
    }
}
