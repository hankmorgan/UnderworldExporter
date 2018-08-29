using UnityEngine;
using System.Collections;

public class TileInfo : Loader
{
    public TileMap map;
    public short tileType;  //What type of tile I am.
    public short floorHeight;   //How high is the floor.
    public short ceilingHeight; //Constant in UW. Variable in shock

    //Index into the texture map table
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

    public short wallTexture;
    public int indexObjectList; //Points to a linked list of objects in the objects block
    public short doorBit;
    public bool isDoor;
    public bool Render=true;     //If set then we output this tile. Is off when it is a subpart of a group or is hidden from sight.
    public short DimX = 1;          //The dimensions (in tilesize) of this tile. 1 for a regular tile. 
    public short DimY = 1;          //>1 for when it is a group in which case we do not render it but only render it parent til
    public bool Grouped=false;        // when I group a set of tiles this indicates the tile is a child of a group.
    public bool[] VisibleFaces = { true, true, true, true, true, true };// new bool[6];   //Which faces are visible on a block. 
    public short North; public short South;
    public short East; public short West;

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
    
    public bool hasBridge; //Set when the tile contains a bridge.
    public bool isNothing; //Set when the tile has the nothing textures
    public short roomRegion;    //Index to the contigous room that the tile is part of.
    public short tileX;
    public short tileY;
    public short Flags;//UW Tile flags
    public short noMagic;//Only seems to matter on Level 9 and possibly where there is water? UPDATE>Possible bug in reading data. Retest this.

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

    public bool TerrainChange;  //Indicates that the tile can change into another type of tile or moves in someway.

    public int[] SHOCKSTATE = new int[4];   //These should be ff,00,00,00 on an initial map. I'm just bringing them back for research purposes.

    public bool NeedsReRender = false;


    /// <summary>
    /// Does the tile contain a pressure trigger. Used to test pickups of objects from the tile.
    /// </summary>
    public int PressureTriggerIndex = 0;

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
        Flags = newFlags;
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

    short getTile(int tileData)
    {
        //gets tile data at bits 0-3 of the tile data
        return (short)(tileData & 0x0F);
    }

    short getHeight(int tileData)
    {//gets height data at bits 4-7 of the tile data
        return (short)((tileData & 0xF0) >> 4);
    }

    short getFloorTex(long tileData)
    {//gets floor texture data at bits 10-13 of the tile data
        return (short)((tileData >> 10) & 0x0F);
    }

    short getWallTex(long tileData)
    {
        return (short)(tileData & 0x3F);
    }

    short getObject(long tileData)
    {
        //gets object data at bits 6-15 (+16) of the tile data(2nd part)
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
