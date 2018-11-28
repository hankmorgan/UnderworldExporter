using UnityEngine;
using System.Collections;

public class TileInfo : Loader
{
    /// <summary>
    /// Reference to the tilemap containing this tile
    /// </summary>
    public TileMap map;

    /// <summary>
    /// What type of tile I am.
    /// </summary>
    public short tileType;

    /// <summary>
    /// How high is the floor.
    /// </summary>
    public short floorHeight;

    /// <summary>
    /// How low is the ceiling
    /// </summary>
    /// Constant in UW. Variable in shock
    public short ceilingHeight;

    //Index into the texture map table for the actual floor texture of this tile.
    private short _floorTexture;
    public short floorTexture
    {
        get
        {
            return _floorTexture;
        }
        set
        {
            _floorTexture = value;
            UpdateTerrain();
        }
    }

    /// <summary>
    /// Index into texture map for the wall texture presented to other tiles by this tile.
    /// </summary>
    public short wallTexture;

    /// <summary>
    /// /Points to a linked list of objects in the objects block
    /// </summary>
    public int indexObjectList; 
    /// <summary>
    /// Does this tile contain a door per uw-formats.txt
    /// </summary>
    public short doorBit;
    /// <summary>
    /// Set when ever a tile does contain a door regardless of the door bit above.
    /// </summary>
    public bool isDoor;
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
    public short flags;

    /// <summary>
    /// Only seems to matter on Level 9 and possibly where there is water? 
    /// UPDATE>Possible bug in reading data. Retest this. TODO:
    /// </summary>
    public short noMagic;

    //Shock Specific Stuff
    public short shockSlopeFlag;    //For controlling ceiling slopes for shock.
    public short shockCeilingTexture;
    public short shockSteep;
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
    private int _terrain;
    public int terrain
    {
        get
        {
            return _terrain;
        }
    }

    public TileInfo()
    {
        //Empty constructor for shock
    }

    public TileInfo(TileMap tm, short X, short Y, int FirstTileInt, int SecondTileInt, short CeilingTexture)
    {
        short newtileType = getTile(FirstTileInt);
        short newfloorHeight = (short)(getHeight(FirstTileInt) * 2);//remember to divide when writing this back.
        //Tiles[x,y].floorHeight = ((Tiles[x,y].floorHeight <<3) >> 2)*8 >>3;	//Try and copy this shift from shock.
        //Turns out that shift is just a doubling!
        //newfloorHeight = (short)(floorHeight * 2); 
        short newceilingHeight = 0;//UW_CEILING_HEIGHT;	//constant for uw				
        
        short newFlags = (short)((FirstTileInt >> 7) & 0x3);
        short newnoMagic = (short)((FirstTileInt >> 14) & 0x1);
        short newdoorBit = (short)((FirstTileInt >> 15) & 0x1);
        short newindexObjectList = getObject(SecondTileInt);
        
        short newfloorTexture = getFloorTex( FirstTileInt);
        short newwallTexture = getWallTex( SecondTileInt);

        InitTileInfo(tm, X, Y, newtileType,
            newfloorHeight, newceilingHeight,
            newfloorTexture, newwallTexture, CeilingTexture,
            newFlags, newnoMagic, newdoorBit, newindexObjectList);
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
        map = tm;
        tileType = newtiletype;
        tileX = X;
        tileY = Y;
        floorHeight = newfloorHeight;
        ceilingHeight = newceilingHeight;
        floorTexture = newfloorTexture;
        wallTexture = newwallTexture;
        shockCeilingTexture = newceilTexture;
        flags = newFlags;
        noMagic = newnoMagic;
        doorBit = newdoorBit;
        indexObjectList = newindexObjectList;

        Grouped = false;

        if (floorTexture < 0)
        {
            floorTexture = 0;
        }
        if (floorTexture >= 262)
        {
            floorTexture = 0;
        }
        if (wallTexture >= 256)
        {
           wallTexture = 0;
        }


        //Get the terrain type for the tile.
        switch (_RES)
        {
            case GAME_UWDEMO:
            case GAME_UW1:
                _terrain = GameWorldController.instance.terrainData.Terrain[46 + map.texture_map[floorTexture + 48]];
                break;
            case GAME_UW2:
                _terrain = GameWorldController.instance.terrainData.Terrain[map.texture_map[floorTexture]];
                break;
            default:
                _terrain = 0;
                break;
        }

        if (_RES==GAME_UWDEMO)
        {//texture_map[t.floorTexture + 48];
            if (map.texture_map[floorTexture + 48] == 56)
            {
                _terrain = TerrainDatLoader.Water;
            }
        }
        //There is only one possible steepness in UW so I set it's properties to match a similar tile in shock.
        shockSlopeFlag = TileMap.SLOPE_FLOOR_ONLY;
        if (tileType >= 2)
        {
            shockSteep = 2;
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
    /// gets tile data at bits 0-3 of the tile data
    /// </summary>
    /// <param name="tileData"></param>
    /// <returns></returns>
    short getTile(int tileData)
    {
        return (short)(tileData & 0x0F);
    }

    /// <summary>
    /// gets height data at bits 4-7 of the tile data
    /// </summary>
    /// <param name="tileData"></param>
    /// <returns></returns>
    short getHeight(int tileData)
    {
        return (short)((tileData & 0xF0) >> 4);
    }

    /// <summary>
    /// gets floor texture data at bits 10-13 of the tile data
    /// </summary>
    /// <param name="tileData"></param>
    /// <returns></returns>
    short getFloorTex(long tileData)
    {
        return (short)((tileData >> 10) & 0x0F);
    }

    /// <summary>
    /// Gets the wall texture data
    /// </summary>
    /// <param name="tileData"></param>
    /// <returns></returns>
    short getWallTex(long tileData)
    {
        return (short)(tileData & 0x3F);
    }

    /// <summary>
    /// gets object data at bits 6-15 (+16) of the tile data(2nd part)
    /// </summary>
    /// <param name="tileData"></param>
    /// <returns></returns>
    short getObject(long tileData)
    {
        return (short)(tileData >> 6);
    }


    /// <summary>
    /// Tells us the tile needs to be updated next LateUpdate
    /// </summary>
    public void TileNeedsUpdate()
    {
        NeedsReRender = true;
        GameWorldController.WorldReRenderPending = true;
    }

    /// <summary>
    /// Tells us the texture index in the specified direction. If the surface is not visible it returns -1
    /// </summary>
    /// <returns>The visible wall texture.</returns>
    /// <param name="direction">Direction.</param>
    public int VisibleWallTexture(int direction)
    {
        if (VisibleFaces[direction] == false)
        {//Face is invisible.
            return -1;
        }
        else
        {
            switch (direction)
            {
                case TileMap.vSOUTH:
                    {
                        return (int)South;
                    }
                case TileMap.vNORTH:
                    {
                        return (int)North;
                    }
                case TileMap.vEAST:
                    {
                        return (int)East;
                    }
                case TileMap.vWEST:
                    {
                        return (int)West;
                    }

                case TileMap.vBOTTOM:
                case TileMap.vTOP:
                default:
                    {
                        return (int)floorTexture;
                    }
            }
        }
    }


    /// <summary>
    /// Updates the terrain type of the tile
    /// </summary>
    private void UpdateTerrain()
    {
        //Set the terrain type for the tile when the texture changes
        switch (_RES)
        {
            case GAME_UWDEMO:
            case GAME_UW1:
                _terrain = GameWorldController.instance.terrainData.Terrain[46 + map.texture_map[_floorTexture + 48]];
                break;
            case GAME_UW2:
                _terrain = GameWorldController.instance.terrainData.Terrain[map.texture_map[_floorTexture]];
                break;
            default:
                _terrain = 0;
                break;
        }
    }

}
