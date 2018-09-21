using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderworldEditor
{
    class TileMap
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


        public struct TileInfo
        {
            public int tileX;
            public int tileY;
            public short tileType;  //What type of tile I am.
            public short floorHeight;   //How high is the floor.
            public short unk1;
            public short unk2;
            public short floorTexture;
            public short noMagic;
            public short doorBit;
            public short wallTexture;
            public int indexObjectList; //Points to a linked list of objects in the objects block
            //etc
        };

        public TileInfo[,] Tiles;


        public int[] texture_map;

        public void InitTileMap(char[] lev_ark, int address_pointer, int thisblock, int game)
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
                    Tiles[x, y] = BuildTileInfo(x, y, FirstTileInt, SecondTileInt, 0);//TODO:Texturemappings
                    address_pointer = address_pointer + 4;
                }
            }
        }

        /// <summary>
        /// Builds a texture map from file data
        /// </summary>
        /// <param name="tex_ark"></param>
        /// <param name="CeilingTexture"></param>
       public void BuildTextureMap(char[] tex_ark, ref short CeilingTexture, int game)
        {
            short textureMapSize;//=UW1_TEXTUREMAPSIZE;
            switch (game)
            {
                case 2:
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
                switch (game)
                {
                    case 1:
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
                    case 2://uw2
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
            ti.floorTexture = newfloorTexture;
            ti.wallTexture = newwallTexture;
            ti.noMagic = newnoMagic;
            ti.doorBit = newdoorBit;
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

    }

}

