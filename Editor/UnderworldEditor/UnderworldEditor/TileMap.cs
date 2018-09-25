using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderworldEditor
{
    public class TileMap
    {
        public const short TILE_SOLID = 0;
        public const short TILE_OPEN = 1;
        public const short TILE_DIAG_SE = 2;
        public const short TILE_DIAG_SW = 3;
        public const short TILE_DIAG_NE = 4;
        public const short TILE_DIAG_NW = 5;
        public const short TILE_SLOPE_N = 6;
        public const short TILE_SLOPE_S = 7;
        public const short TILE_SLOPE_E = 8;
        public const short TILE_SLOPE_W = 9;
        public const short TILE_VALLEY_NW = 10;
        public const short TILE_VALLEY_NE = 11;
        public const short TILE_VALLEY_SE = 12;
        public const short TILE_VALLEY_SW = 13;
        public const short TILE_RIDGE_SE = 14;
        public const short TILE_RIDGE_SW = 15;
        public const short TILE_RIDGE_NW = 16;
        public const short TILE_RIDGE_NE = 17;

        public const int UW1_TEXTUREMAPSIZE = 64;
        public const int UW2_TEXTUREMAPSIZE = 70;
        public const int UWDEMO_TEXTUREMAPSIZE = 63;

        //BrushFaces
        public const int fSELF = 128;
        public const int fCEIL = 64;
        public const int fNORTH = 32;
        public const int fSOUTH = 16;
        public const int fEAST = 8;
        public const int fWEST = 4;
        public const int fTOP = 2;
        public const int fBOTTOM = 1;


        public struct TileInfo
        {
            public long FileAddress;//Where this tile is located on file.
            public int tileX;
            public int tileY;
            public short tileType;  //What type of tile I am.
            public short floorHeight;   //How high is the floor.
            public short flags;
            //public short unk1;
            //public short unk2;
            public short floorTexture;
            public short noMagic;
            public short doorBit;
            public short wallTexture;
            public int indexObjectList; //Points to a linked list of objects in the objects block
                                        
            public short North; public short South;
            public short East; public short West;
            //etc
        };

        public TileInfo[,] Tiles;


        public short[] texture_map = new short[272];

        public short ceilingtexture;

        public void InitTileMap(char[] lev_ark, int address_pointer, int thisblock, long BlockAddress)
        {
           // if (game == 1)//uw1
           // {
                //OverlayBlock = TileMapBlock + 9;
                //TextureMapBlock = TileMapBlock + 18;
                //AutoMapBlock = TileMapBlock + 27;
           // }            
            Tiles = new TileInfo[64, 64];
            for (short y = 0; y <= 63; y++)
            {
                for (short x = 0; x <= 63; x++)
                {
                    int FirstTileInt = (int)Util.getValAtAddress(lev_ark, (address_pointer + 0), 16);
                    int SecondTileInt = (int)Util.getValAtAddress(lev_ark, (address_pointer + 2), 16);
                    Tiles[x, y] = BuildTileInfo(x, y, FirstTileInt, SecondTileInt, ceilingtexture);//TODO:Texturemappings
                    Tiles[x, y].FileAddress = BlockAddress + address_pointer;
                    address_pointer = address_pointer + 4;
                }
            }
            SetTileMapWallFacesUW();
        }

        /// <summary>
        /// Builds a texture map from file data
        /// </summary>
        /// <param name="tex_ark"></param>
        /// <param name="CeilingTexture"></param>
       public void BuildTextureMap(char[] tex_ark, ref short CeilingTexture)
        {
            short textureMapSize;//=UW1_TEXTUREMAPSIZE;
            switch (main.curgame)
            {
                case main.GAME_UW2:
                    textureMapSize = UW2_TEXTUREMAPSIZE;
                    break;
                //case GAME_UWDEMO:
                //    textureMapSize = UWDEMO_TEXTUREMAPSIZE;
                //    break;
                default:
                    textureMapSize = UW1_TEXTUREMAPSIZE;
                    break;
            }
            int offset = 0;
            for (int i = 0; i < textureMapSize; i++)//256
            {
                switch (main.curgame)
                {
                    case main.GAME_UW1:
                        {
                            if (i < 48)//Wall textures
                            {
                                texture_map[i] = (short)Util.getValAtAddress(tex_ark, offset, 16);
                                offset = offset + 2;
                            }
                            else
                                if (i <= 57)//Floor textures are 48 to 56, ceiling is 57
                            {
                                texture_map[i] = (short)(Util.getValAtAddress(tex_ark, offset, 16) + 210);
                                offset = offset + 2;
                                if (i == 57)
                                {
                                    CeilingTexture = (short)i;
                                }
                            }
                            else
                            {
                                texture_map[i] = (short)Util.getValAtAddress(tex_ark, offset, 8);
                                offset++;
                            }
                            break;
                        }
                    case main.GAME_UW2://uw2
                        {
                            if (i < 64)
                            {
                                texture_map[i] = (short)Util.getValAtAddress(tex_ark, offset, 16);
                                offset = offset + 2;
                            }
                            else
                            {
                                //door textures
                                texture_map[i] = (short)Util.getValAtAddress(tex_ark, offset, 8);
                                offset++;
                            }
                        }
                        if (i == 0xf)
                        {
                            CeilingTexture = (short)i;
                        }
                        //if ((LevelNo == (int)(GameWorldController.UW2_LevelNos.Ethereal4)) && (i == 16))
                        //{
                        //    //Not sure why this is an exceptional case!
                        //    CeilingTexture = (short)i;
                        //}
                        break;
                }
            }
        }

        public TileInfo BuildTileInfo(short X, short Y, int FirstTileInt, int SecondTileInt, short CeilingTexture)
        {
            short newtileType = getTile(FirstTileInt);
            short newfloorHeight = (short)getHeight(FirstTileInt) ;
            short newceilingHeight = 0;//UW_CEILING_HEIGHT;	//constant for uw				

            short newFlags = (short)((FirstTileInt >> 7) & 0x3);
            short newnoMagic = (short)((FirstTileInt >> 14) & 0x1);
            short newdoorBit = (short)((FirstTileInt >> 15) & 0x1);
            short newindexObjectList = getObject(SecondTileInt);

            short newfloorTexture = getFloorTex(FirstTileInt);
            short newwallTexture = getWallTex(SecondTileInt);

            return InitTileInfo(X, Y, newtileType,
                newfloorHeight, newceilingHeight,
                newfloorTexture, newwallTexture, CeilingTexture,
                newFlags, newnoMagic, newdoorBit, newindexObjectList);
        }

       TileInfo InitTileInfo( short X, short Y, short newtiletype,
            short newfloorHeight, short newceilingHeight,
            short newfloorTexture, short newwallTexture, short newceilTexture,
            short newFlags, short newnoMagic, short newdoorBit, int newindexObjectList)
        {
            TileInfo ti=new TileInfo();
            ti.tileType = newtiletype;
            ti.tileX = X;
            ti.tileY = Y;
            ti.floorHeight = newfloorHeight;                       
            ti.flags = newFlags;
            ti.floorTexture = newfloorTexture;
            ti.noMagic = newnoMagic;
            ti.doorBit = newdoorBit;
            ti.wallTexture = newwallTexture;
            ti.indexObjectList = newindexObjectList;
            return ti;
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

        public static string GetTileTypeText(int tiletype)
        {
            switch (tiletype)
            {
                case TILE_SOLID:
                    return "TILE_SOLID";
                case TILE_OPEN:
                    return "TILE_OPEN";
                case TILE_DIAG_SE:
                    return "TILE_DIAG_SE";
                case TILE_DIAG_SW:
                    return "TILE_DIAG_SW";
                case TILE_DIAG_NE:
                    return "TILE_DIAG_NE";
                case TILE_DIAG_NW:
                    return "TILE_DIAG_NW";
                case TILE_SLOPE_N:
                    return "TILE_SLOPE_N";
                case TILE_SLOPE_S:
                    return "TILE_SLOPE_S";
                case TILE_SLOPE_E:
                    return "TILE_SLOPE_E";
                case TILE_SLOPE_W:
                    return "TILE_SLOPE_W";
                default:
                    return "";
            }
        }

        public static int GetTileTypeInt(string tiletype)
        {

            switch (tiletype)
            {
                case "TILE_SOLID":
                    return TILE_SOLID;
                case "TILE_OPEN":
                    return TILE_OPEN;
                case "TILE_DIAG_SE":
                    return TILE_DIAG_SE;
                case "TILE_DIAG_SW":
                    return TILE_DIAG_SW;
                case "TILE_DIAG_NE":
                    return TILE_DIAG_NE;
                case "TILE_DIAG_NW":
                    return TILE_DIAG_NW;
                case "TILE_SLOPE_N":
                    return TILE_SLOPE_N;
                case "TILE_SLOPE_S":
                    return TILE_SLOPE_S;
                case "TILE_SLOPE_E":
                    return TILE_SLOPE_E;
                case "TILE_SLOPE_W":
                    return TILE_SLOPE_W;
                default:
                    return 0;
            }
        }


        /// <summary>
        /// Gets the wall texture for the specified face
        /// </summary>
        /// <returns>The texture.</returns>
        /// <param name="face">Face.</param>
        /// <param name="t">T.</param>
        public int GetMappedWallTexture(int face, TileInfo t)
        {
            int wallTexture;
            wallTexture = t.wallTexture;
            switch (face)
            {
                case fSOUTH:
                    wallTexture = t.South;
                    break;
                case fNORTH:
                    wallTexture = t.North;
                    break;
                case fEAST:
                    wallTexture = t.East;
                    break;
                case fWEST:
                    wallTexture = t.West;
                    break;
            }
            if ((wallTexture < 0) || (wallTexture > 512))
            {
                wallTexture = 0;
            }
            return texture_map[wallTexture];
        }

        /// <summary>
        /// Returns the floor texture from the texture map.
        /// </summary>
        /// <returns>The texture.</returns>
        /// <param name="face">Face.</param>
        /// <param name="t">T.</param>
        public int GetMappedFloorTexture(int face, TileInfo t)
        {
            int floorTexture;

            if (face == fCEIL)
            {
                floorTexture = texture_map[ceilingtexture];
            }
            else
            {
                //floorTexture = t.floorTexture;
                switch (main.curgame)
                {
                    case main.GAME_UW2:
                        floorTexture = texture_map[t.floorTexture];
                          break;
                    default:
                        floorTexture = texture_map[t.floorTexture + 48];
                        break;
                }

            }

            if ((floorTexture < 0) || (floorTexture > 512))
            {
                floorTexture = 0;
            }
            return floorTexture;
        }


        /// <summary>
        /// Creates the tile map wall textures for each north, south, east and west faces
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        public void SetTileMapWallFacesUW()
        {
            short x; short y;
            for (y = 0; y <= 63; y++)
            {
                for (x = 0; x <= 63; x++)
                {
                    SetTileWallFacesUW(x, y);
                }
            }
        }

        /// <summary>
        /// Sets the tile wall faces for the selected tile
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        public void SetTileWallFacesUW(short x, short y)
        {
            if (Tiles[x, y].tileType >= 0)//was just solid only. Note: If textures are all wrong it's probably caused here!
            {
                //assign it's north texture
                if (y < 63)
                {
                    Tiles[x, y].North = Tiles[x, y + 1].wallTexture;
                }
                else
                {
                    Tiles[x, y].North = -1;
                }
                //assign it's southern
                if (y > 0)
                {
                    Tiles[x, y].South = Tiles[x, y - 1].wallTexture;
                }
                else
                {
                    Tiles[x, y].South = -1;
                }
                //it's east
                if (x < 63)
                {
                    Tiles[x, y].East = Tiles[x + 1, y].wallTexture;
                }
                else
                {
                    Tiles[x, y].East = -1;
                }
                //assign it's West
                if (x > 0)
                {
                    Tiles[x, y].West = Tiles[x - 1, y].wallTexture;
                }
                else
                {
                    Tiles[x, y].West = -1;
                }
            }
        }




    }//end class  


}

