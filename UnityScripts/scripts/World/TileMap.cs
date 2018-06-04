using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Text;
using System.IO;

/// <summary>
/// Tile map class for storing and accessing the tilemap and tile properties..
/// </summary>
public class TileMap : Loader {
		public const short TILE_SOLID=0;
		public const short TILE_OPEN= 1;
		public const short TILE_DIAG_SE= 2;
		public const short TILE_DIAG_SW =3;
		public const short TILE_DIAG_NE =4;
		public const short TILE_DIAG_NW= 5;
		public const short TILE_SLOPE_N =6;
		public const short TILE_SLOPE_S= 7;
		public const short TILE_SLOPE_E= 8;
		public const short TILE_SLOPE_W= 9;
		public const short TILE_VALLEY_NW =10;
		public const short TILE_VALLEY_NE =11;
		public const short TILE_VALLEY_SE= 12;
		public const short TILE_VALLEY_SW =13;
		public const short TILE_RIDGE_SE =14;
		public const short TILE_RIDGE_SW =15;
		public const short TILE_RIDGE_NW= 16;
		public const short TILE_RIDGE_NE= 17;

		/// <summary>
		/// The tile map size along the x axis
		/// </summary>
		public const short TileMapSizeX=63; //0 to 63

		/// <summary>
		/// The tile map size along the y axis.
		/// </summary>
		public const short TileMapSizeY=63; //0 to 63

		/// <summary>
		/// The object storage tile location where non map objects are kept.
		/// </summary>
		public const short ObjectStorageTile=99;

		public const short SURFACE_FLOOR =1;
		public const short SURFACE_CEIL = 2;
		public const short SURFACE_WALL = 3;
		public const short SURFACE_SLOPE = 4;

		const short SLOPE_BOTH_PARALLEL= 0;
		const short SLOPE_BOTH_OPPOSITE= 1;
		const short SLOPE_FLOOR_ONLY =2;
		const short SLOPE_CEILING_ONLY= 3;

		//Visible faces indices. Used in sorting tile visiblity.
		public const short vTOP =0;
		public const short vEAST =1;
		public const short vBOTTOM= 2;
		public const short vWEST= 3;
		public const short vNORTH= 4;
		public const short vSOUTH= 5;


		//BrushFaces
		const short fSELF =128;
		const short fCEIL= 64;
		const short fNORTH =32;
		const short fSOUTH =16;
		const short fEAST= 8;
		const short fWEST= 4;
		const short fTOP =2;
		const short fBOTTOM= 1;

		public const int UW1_TEXTUREMAPSIZE=64;
		public const int UW2_TEXTUREMAPSIZE=70;
		public const int UWDEMO_TEXTUREMAPSIZE=63;

		public const int UW1_NO_OF_LEVELS=9;
		public const int UW2_NO_OF_LEVELS=80;

		public struct Overlay{
				public int index;
				public int unk1;
				public int tileX;
				public int tileY;
		};

		public Overlay[] Overlays=new Overlay[64];

		public short thisLevelNo; //The number of this level
		public short UW_CEILING_HEIGHT;
		public short CEILING_HEIGHT;
		public short SHOCK_CEILING_HEIGHT;
		public short[] texture_map = new short[272];


		/// <summary>
		/// Tile info storage class
		/// </summary>
		public TileInfo[,] Tiles=new TileInfo[TileMap.TileMapSizeX+1,TileMap.TileMapSizeY+1];



		/// <summary>
		/// The current tile X that the player is in
		/// </summary>
		public static short visitTileX;
		/// <summary>
		/// The current tile Y that the player is in.
		/// </summary>
		public static short visitTileY;

		/// The tile X that the player was in the previously
		/// </summary>
		public static short visitedTileX;
		/// <summary>
		/// The current tile Y that the player was in the previously
		/// </summary>
		public static short visitedTileY;


		/// <summary>
		/// Is the player currently standing on solid ground
		/// </summary>
	//public static bool OnGround=false;
		/// <summary>
		/// Is the player currently standing(swimming) on water
		/// </summary>
	//public static bool OnWater=false;
		/// <summary>
		/// Is the player currently standing on lava.
		/// </summary>
	//public static bool OnLava=false;
	//public GameObject feet;//For detecting the ground.
		/// <summary>
		///Is the player currently on Ice
		/// </summary>
		//public static bool OnIce=false;


		public TileMap(short NewLevelNo)
		{
			thisLevelNo=NewLevelNo;
		}


		/// <summary>
		/// Checks to see if the tile at a specified location is within the valid game world. (eg is rendered and is not a solid).
		/// Assumes the map is positioned at 0,0,0
		/// </summary>
		/// <returns><c>true</c>, if tile was valided, <c>false</c> otherwise.</returns>
		/// <param name="location">Location.</param>
	public bool ValidTile(Vector3 location)
	{
		int tileX = (int)(location.x/1.2f);
		int tileY = (int)(location.y/1.2f);
		if ((tileX>TileMap.TileMapSizeX) || (tileX<0) || (tileY>TileMap.TileMapSizeY) || (tileY<0))
		{//Location is outside the map
				return false;
		}
		int tileType = GetTileType(tileX,tileY);
		bool isRendered = GetTileRender(tileX,tileY);

		return ((tileType!=TILE_SOLID) && (isRendered));
	}

		/// <summary>
		/// Validates the tile to see if it is within the range of tiles.
		/// </summary>
		/// <returns><c>true</c>, if tile was valided, <c>false</c> otherwise.</returns>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
		public static bool ValidTile(int tileX, int tileY)
		{			
			return ( ( (tileX>=0) && (tileX<=TileMapSizeX) ) && ( (tileY>=0) && (tileY<=TileMapSizeY) ) );
		}

	/// <summary>
	/// Tells if the tile is one of the square open types
	/// </summary>
	/// <returns><c>true</c>, if tile open was ised, <c>false</c> otherwise.</returns>
	/// <param name="TileType">Tile type.</param>
	public static bool isTileOpen(int TileType)
	{
		switch (TileType)
		{
		case TILE_OPEN:
		case TILE_SLOPE_N:
		case TILE_SLOPE_S:
		case TILE_SLOPE_E:
		case TILE_SLOPE_W:
			{
			return true;
			}
		default:
			{
			return false;
			}
		}
	}

		/// <summary>
		/// Gets the height of the floor for the specified tile.
		/// </summary>
		/// <returns>The floor height.</returns>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
	public int GetFloorHeight(int tileX, int tileY)
	{
		if (ValidTile(tileX,tileY))
		{
			return Tiles[tileX,tileY].floorHeight;
		}
		else
		{
			return 0;
		}		
	}

		/// <summary>
		/// Gets the height of the ceiling. Will always be the same value in UW1/2 varies in SHOCK.
		/// </summary>
		/// <returns>The ceiling height.</returns>
		/// <param name="LevelNo">Level no.</param>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
	public int GetCeilingHeight(int tileX, int tileY)
	{
		return Tiles[tileX,tileY].ceilingHeight;
	}

		/// <summary>
		/// Sets the height of the floor.
		/// </summary>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
		/// <param name="newHeight">New height.</param>
	public void SetFloorHeight(int tileX, int tileY, short newHeight)
	{
		Tiles[tileX,tileY].floorHeight=newHeight;
	}

		/// <summary>
		/// Sets the height of the ceiling.
		/// </summary>
		/// <param name="LevelNo">Level no.</param>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
		/// <param name="newHeight">New height.</param>
		public void SetCeilingHeight(int tileX, int tileY, short newHeight)
	{
		//Debug.Log ("ceil :" + newHeight + " was " + CeilingHeight[tileX,tileY]);
				Tiles[tileX,tileY].ceilingHeight=newHeight;
	}


		/// <summary>
		/// Gets the type of the tile.
		/// </summary>
		/// <returns>The tile type.</returns>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
		public int GetTileType(int tileX, int tileY)
		{
			//if ((tileX>TileMap.TileMapSizeX) || (tileY>TileMap.TileMapSizeY) || (tileX<0) || (tileY<0))
			if (TileMap.ValidTile(tileX,tileY))
			{//Assume out of bounds is solid
				return TILE_SOLID;
			}
			else
			{
				return Tiles[tileX,tileY].tileType;
			}			
		}

		/// <summary>
		/// Gets the room region at the specified tile
		/// </summary>
		/// <returns>The room.</returns>
		/// <param name="TileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
		public int GetRoom(int tileX, int tileY)
		{
			if (TileMap.ValidTile(tileX,tileY))
			{
				return Tiles[tileX,tileY].roomRegion;
			}
			else
			{
				return 0;
			}
		}

	
	/// <summary>
	/// Gets the tile render state. 
	/// </summary>
	/// <returns>The tile render.</returns>
	/// <param name="LevelNo">Level no.</param>
	/// <param name="tileX">Tile x.</param>
	/// <param name="tileY">Tile y.</param>
	private bool GetTileRender( int tileX, int tileY)
	{				
		return Tiles[tileX,tileY].Render==true;
	}

		/// <summary>
		/// Gets the vector3 at the center of the tile specified.
		/// </summary>
		/// <returns>The tile vector.</returns>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
		public Vector3 getTileVector(int tileX,int tileY)
		{
				return new Vector3( 
						(((float)tileX) *1.2f) +0.6f, 
						(float)GetFloorHeight(tileX,tileY)  * 0.15f,
						(((float)tileY) *1.2f) +0.6f 
				);	
		}

		/// <summary>
		/// Gets the vector3 at the center of the tile specified.
		/// </summary>
		/// <returns>The tile vector.</returns>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
		public Vector3 getTileVector(int tileX,int tileY, float zpos)
		{
				return new Vector3( 
						(((float)tileX) *1.2f) +0.6f, 
						zpos,
						(((float)tileY) *1.2f) +0.6f 
				);	
		}



		public bool BuildTileMapUW(int levelNo, DataLoader.UWBlock lev_ark, DataLoader.UWBlock tex_ark, DataLoader.UWBlock ovl_ark)
		{
				//int NoOfBlocks;
				//long AddressOfBlockStart;
				long address_pointer=0;
				//long textureAddress=0;

				//short x;	
				//short y;
				short CeilingTexture=0;

				short textureMapSize=64;//Different for UW2

				UW_CEILING_HEIGHT = ((128 >> 2) * 8 >>3);	//Shifts the scale of the level. Idea borrowed from abysmal

				CEILING_HEIGHT=UW_CEILING_HEIGHT;

				for  (short x=0; x<=TileMap.TileMapSizeX;x++)
				{
						for (short y=0; y<=TileMap.TileMapSizeY;y++)
						{
								Tiles[x,y] =new TileInfo();
						}
				}


				BuildTextureMap (tex_ark, ref CeilingTexture, levelNo );

				for (short y=0; y<=TileMap.TileMapSizeY;y++)
				{
						for (short x=0; x<=TileMap.TileMapSizeX;x++)
						{
								Tiles[x,y].tileX = x;
								Tiles[x,y].tileY = y;

								int FirstTileInt = (int)DataLoader.getValAtAddress(lev_ark,(address_pointer+0),16);
								int SecondTileInt = (int)DataLoader.getValAtAddress(lev_ark,(address_pointer+2),16);
								address_pointer=address_pointer+4;

								Tiles[x,y].tileType = getTile(FirstTileInt) ;
								Tiles[x,y].floorHeight = getHeight(FirstTileInt) ;
								//Tiles[x,y].trueHeight=Tiles[x,y].floorHeight;//Save this value before shifting.
								//Tiles[x,y].floorHeight = ((Tiles[x,y].floorHeight <<3) >> 2)*8 >>3;	//Try and copy this shift from shock.
								//Turns out that shift is just a doubling!
								Tiles[x,y].floorHeight  = (short)(Tiles[x,y].floorHeight*2); //remember to divide when writing this back.
								Tiles[x,y].ceilingHeight = 0;//UW_CEILING_HEIGHT;	//constant for uw				

								Tiles[x,y].flags =(short)((FirstTileInt>>7) & 0x3);
								Tiles[x,y].noMagic =(short)( (FirstTileInt>>14) & 0x1);
								Tiles[x,y].doorBit =(short)( (FirstTileInt>>15) & 0x1);

								switch (UWEBase._RES)
								{
								case UWEBase.GAME_UWDEMO://uwdemo
								case UWEBase.GAME_UW1:	//uw1
								case UWEBase.GAME_UW2:
								default:
										Tiles[x,y].floorTexture = getFloorTex(lev_ark.Data, FirstTileInt);
										Tiles[x,y].wallTexture = getWallTex(lev_ark.Data, SecondTileInt);
										break;
								}
								if (Tiles[x,y].floorTexture<0)
								{
										Tiles[x,y].floorTexture=0;
								}
								if (Tiles[x,y].floorTexture>=262)
								{
										Tiles[x,y].floorTexture=0;
								}		
								if (Tiles[x,y].wallTexture>=256)
								{
										Tiles[x,y].wallTexture =0;
								}	

								switch(_RES)
								{
								case GAME_UW2:
										Tiles[x,y].isIce=isTextureIce(texture_map[Tiles[x,y].floorTexture]);
										Tiles[x,y].isWater=isTextureWater(texture_map[Tiles[x,y].floorTexture]); //lookup into terrain.dat
										Tiles[x,y].isLava=isTextureLava(texture_map[Tiles[x,y].floorTexture]);
										Tiles[x,y].isNothing = isTextureNothing(texture_map[Tiles[x,y].floorTexture]);
										break;
								default:
										Tiles[x,y].isWater=isTextureWater(texture_map[Tiles[x,y].floorTexture+48]); //lookup into terrain.dat
										Tiles[x,y].isLava=isTextureLava(texture_map[Tiles[x,y].floorTexture+48]);
										Tiles[x,y].isNothing = isTextureNothing(texture_map[Tiles[x,y].floorTexture+48]);
										break;
								}							

								Tiles[x,y].isLand= ! ( (Tiles[x,y].isWater) || (Tiles[x,y].isLava) || (Tiles[x,y].isNothing));

								switch(_RES)
								{
									case GAME_UWDEMO:
									case GAME_UW1:
										Tiles[x,y].terrain=GameWorldController.instance.terrainData.Terrain[ 46 + texture_map[Tiles[x,y].floorTexture+48]];
										//GameWorldController.instance.terrainData.Terrain[256 + textureNo-210]
										break;
									case GAME_UW2:
										Tiles[x,y].terrain=GameWorldController.instance.terrainData.Terrain[texture_map[Tiles[x,y].floorTexture]];
										break;
									default:
										Tiles[x,y].terrain=0;
										break;
								}

								//UW only has a single ceiling texture so this is ignored.	
								Tiles[x,y].shockCeilingTexture=CeilingTexture;
								//There is only one possible steepness in UW so I set it's properties to match a similar tile in shock.
								if (Tiles[x,y].tileType >=2)
								{
										Tiles[x,y].shockSteep = 1;
										Tiles[x,y].shockSteep =(short)( ((Tiles[x,y].shockSteep  <<3) >> 2)*8 >>3 );	//Shift copied from shock
										Tiles[x,y].shockSlopeFlag = SLOPE_FLOOR_ONLY ;
								}
								else
								{
										Tiles[x,y].shockSlopeFlag = SLOPE_FLOOR_ONLY ;	
								}
								//Different textures on solid tiles faces
								Tiles[x,y].North = Tiles[x,y].wallTexture;
								Tiles[x,y].South = Tiles[x,y].wallTexture;
								Tiles[x,y].East = Tiles[x,y].wallTexture;
								Tiles[x,y].West = Tiles[x,y].wallTexture;
								Tiles[x,y].Top = Tiles[x,y].floorTexture; 
								Tiles[x,y].Bottom = Tiles[x,y].floorTexture; 
								Tiles[x,y].Diagonal = Tiles[x,y].wallTexture;

								//First index of the linked list of objects.
								Tiles[x,y].indexObjectList = getObject(SecondTileInt);
								Tiles[x,y].Render=true;		
								Tiles[x,y].DimX=1;			
								Tiles[x,y].DimY=1;			
								Tiles[x,y].Grouped=false;	

								for (int v = 0; v < 6; v++)
								{
										Tiles[x,y].VisibleFaces[v]=true;
										Tiles[x,y].VisibleFaces[v]=true;
								}
								Tiles[x,y].waterRegion= 0;
								Tiles[x,y].landRegion = 0;//including connected bridges.
								Tiles[x,y].lavaRegion = 0;
						}
				}

				SetTileMapWallFacesUW ();


				//if (OverlayAddress!=0)
				if (_RES==GAME_UW1)
				{
						if (ovl_ark.DataLen!=0)
						{//read in the next 64 entries of length 6 bytes	
								long OverlayAddress=0;
								for (int overlayIndex=0; overlayIndex<64; overlayIndex++ )
								{
										Overlays[overlayIndex].index = (int)DataLoader.getValAtAddress(ovl_ark,OverlayAddress,16);
										Overlays[overlayIndex].unk1 = (int)DataLoader.getValAtAddress(ovl_ark,OverlayAddress+2,16);
										Overlays[overlayIndex].tileX = (int)DataLoader.getValAtAddress(ovl_ark,OverlayAddress+4,8);
										Overlays[overlayIndex].index = (int)DataLoader.getValAtAddress(ovl_ark,OverlayAddress+5,8);
										OverlayAddress+=6;
								}
						}	
				}



				return true;
		}






	
		/// <summary>
		/// Builds the UW 1 & 2 Tile map from the file data.
		/// </summary>
		/// <returns><c>true</c>, if tile map U was built, <c>false</c> otherwise.</returns>
		/// <param name="lev_ark">Lev ark.</param>
		/// <param name="LevelNo">Level no.</param>
		/// See uw-formats.txt for file specs
		/// Old version
		public bool BuildTileMapUW(char[] lev_ark, int LevelNo)
		{
				Debug.Log("OLD VERSION OF LOADTILEMAP");
				char[] tex_ark=new char[1]; 
				char[] tmp_ark=new char[1];
				int NoOfBlocks;
				long AddressOfBlockStart;
				long address_pointer;
				long textureAddress=0;
				long OverlayAddress=0;
				short x;	
				short y;
				short CeilingTexture=0;
				short textureMapSize=64;

				UW_CEILING_HEIGHT = ((128 >> 2) * 8 >>3);	//Shifts the scale of the level. Idea borrowed from abysmal

				for  (x=0; x<=TileMap.TileMapSizeX;x++)
				{
						for (y=0; y<=TileMap.TileMapSizeY;y++)
						{
								Tiles[x,y] =new TileInfo();
						}
				}

				switch (UWEBase._RES)
				{
				case UWEBase.GAME_UWDEMO:
						{
								textureMapSize=63;
								//Get the number of blocks in this file.
								NoOfBlocks = 1;
								//Get the first map block
								AddressOfBlockStart = 0;	
								textureAddress = 0; //it's in a different file
								address_pointer =0;
								CEILING_HEIGHT=UW_CEILING_HEIGHT;
								DataLoader.ReadStreamFile(Loader.BasePath + "DATA" + sep + "LEVEL13.TXM" , out tex_ark );
								break;
						}


				case UWEBase.GAME_UW1:	//UW1
						{
							CEILING_HEIGHT=UW_CEILING_HEIGHT;
							// 0x7a;
							//Get the number of blocks in this file.
							NoOfBlocks =  (int)DataLoader.getValAtAddress(lev_ark,0,32);
							//Get the first map block
							AddressOfBlockStart =  DataLoader.getValAtAddress(lev_ark,(LevelNo * 4) + 2,32);
							OverlayAddress =  DataLoader.getValAtAddress(lev_ark,((LevelNo+9) * 4) + 2,32);
							textureAddress =  DataLoader.getValAtAddress(lev_ark,((LevelNo+18) * 4) + 2 ,32);

							address_pointer =0;
							break;
						}

				case UWEBase.GAME_UW2:
						{
							//******************
							CEILING_HEIGHT=UW_CEILING_HEIGHT;

							textureMapSize =70;	//0x86;
							tmp_ark =new char[lev_ark.GetUpperBound(0)+1];
							for (int j =0; j<=lev_ark.GetUpperBound(0);j++)
							{
								tmp_ark[j] = lev_ark[j];
							}	

							address_pointer=0;
							NoOfBlocks=(int)DataLoader.getValAtAddress(tmp_ark,0,32);	

							address_pointer=6;

							//int compressionFlag=(int)DataLoader.getValAtAddress(tmp_ark,address_pointer + (NoOfBlocks*4) + (LevelNo*4) ,32)  ;
							int isCompressed =(  (  (int)DataLoader.getValAtAddress(tmp_ark,address_pointer + (NoOfBlocks*4) + (LevelNo*4) ,32)      )    >>1) & 0x01;
							address_pointer=(LevelNo * 4) + 6;
							if ((int)DataLoader.getValAtAddress(tmp_ark,address_pointer,32)==0)
							{
								return false ;
							}
							if (isCompressed == 1)
							{
								long datalen=0;
								lev_ark = DataLoader.unpackUW2(tmp_ark,DataLoader.getValAtAddress(tmp_ark,address_pointer,32), ref datalen);
								address_pointer=address_pointer+4;
								AddressOfBlockStart=0;
								address_pointer=0;
							}
							else
							{
								int BlockStart = (int)DataLoader.getValAtAddress(tmp_ark, address_pointer, 32);
								int j=0;
								AddressOfBlockStart=0;
								address_pointer=0;//Since I am at the start of a fresh array.
								lev_ark = new char[0x7c08];
								for (int i = BlockStart; i < BlockStart + 0x7c08; i++)
								{
									lev_ark[j] = tmp_ark[i];
									j++;
								}
							}

								//Get the texture map data
							textureAddress=DataLoader.getValAtAddress(tmp_ark,6 + (LevelNo * 4)  + (UW2_NO_OF_LEVELS*4),32);	
								//compressionFlag=(int)DataLoader.getValAtAddress(tmp_ark,(LevelNo * 4) + 6 + (80*4)+ (NoOfBlocks*4),32);
							isCompressed =( ( (int)DataLoader.getValAtAddress(tmp_ark,6 + (LevelNo * 4) + (UW2_NO_OF_LEVELS*4)+ (NoOfBlocks*4),32)   )  >>1) & 0x01;

							if (isCompressed == 1)
							{
									long datalen=0;
									tex_ark = DataLoader.unpackUW2(tmp_ark, textureAddress, ref datalen);
									textureAddress=-1;
							}
							break;

						}
				default:
						return false;
				}

				int offset=0;
				for (int i = 0; i<textureMapSize; i++)	//256
				{//TODO: Only use this for texture lookups.
						switch (UWEBase._RES)
						{
						case UWEBase.GAME_UWDEMO:
							{
								if (i<48)	//Wall textures
								{
										texture_map[i] =  (short)DataLoader.getValAtAddress(tex_ark, textureAddress + offset, 16); //(i * 2)
										offset=offset+2;
								}
								else if (i<=57)	//Floor textures are 49 to 56, ceiling is 57
								{
										texture_map[i] =  (short)(DataLoader.getValAtAddress(tex_ark, textureAddress + offset, 16)+48); //(i * 2)
										offset = offset + 2;
										if (i == 57)
										{
											CeilingTexture = (short)i;
										}

								}
								else
								{ //door textures are int 8s
									texture_map[i] = (short)DataLoader.getValAtAddress(tex_ark, textureAddress + offset, 8) ;//+210; //(i * 1)
									offset++;
								}
								break;
							}

						case UWEBase.GAME_UW1:
							{
								if (i<48)	//Wall textures
								{
									texture_map[i] =  (short)DataLoader.getValAtAddress(lev_ark, textureAddress + offset, 16); //(i * 2)
									offset=offset+2;
								}
								else if (i<=57)	//Floor textures are 49 to 56, ceiling is 57
								{
									texture_map[i] =  (short)(DataLoader.getValAtAddress(lev_ark, textureAddress + offset, 16)+210); //(i * 2)
									offset = offset + 2;
									if (i == 57)
									{
										CeilingTexture = (short)i;
									}

								}
								else
								{ //door textures are int 8s
									texture_map[i] = (short)DataLoader.getValAtAddress(lev_ark, textureAddress + offset, 8) ;//+210; //(i * 1)
									offset++;
								}


								break;
							}
						case UWEBase.GAME_UW2: //uw2
								{
									if (textureAddress == -1)//Texture block was decompressed
									{
										//textureAddress=0;//To stop array out of bounds->THis does not work in the original code??
										if (i<64)
										{
											texture_map[i] =(short)DataLoader.getValAtAddress(tex_ark,offset ,16);//tmp //textureAddress+ //(i*2)
											offset = offset + 2;
										}
										else
										{//door textures
											texture_map[i] = (short)DataLoader.getValAtAddress(tex_ark, textureAddress + offset, 8);//tmp //textureAddress+//(i*2)
											offset++;
										}
									}
									else
									{
										if (i<64)
										{
											texture_map[i] =(short)DataLoader.getValAtAddress(tmp_ark,textureAddress+offset,16);//tmp //textureAddress+//(i*2)
											offset = offset + 2;
										}
										else
										{//door textures
											texture_map[i] = (short)DataLoader.getValAtAddress(tmp_ark, textureAddress + offset, 8);//tmp //textureAddress+//(i*2)
											offset++;
										}
									}

									if (i == 0xf)
									{
										CeilingTexture=(short)i;//texture_map[i];
									}
									if (
												(LevelNo==(int)(GameWorldController.UW2_LevelNos.Ethereal4))
												&& 
												(i==16)
												)
									{//Not sure why this is an exceptional case!
										CeilingTexture=(short)i;
									}
									break;
								}
						}
				}

				for (y=0; y<=TileMap.TileMapSizeY;y++)
				{
						for (x=0; x<=TileMap.TileMapSizeX;x++)
						{
								Tiles[x,y].tileX = x;
								Tiles[x,y].tileY = y;

								int FirstTileInt = (int)DataLoader.getValAtAddress(lev_ark,AddressOfBlockStart+(address_pointer+0),16);
								int SecondTileInt = (int)DataLoader.getValAtAddress(lev_ark,AddressOfBlockStart+(address_pointer+2),16);
								address_pointer=address_pointer+4;

								Tiles[x,y].tileType = getTile(FirstTileInt) ;
								Tiles[x,y].floorHeight = getHeight(FirstTileInt) ;
								//Tiles[x,y].trueHeight=Tiles[x,y].floorHeight;//Save this value before shifting.
								//Tiles[x,y].floorHeight = ((Tiles[x,y].floorHeight <<3) >> 2)*8 >>3;	//Try and copy this shift from shock.
								//Turns out that shift is just a doubling!
								Tiles[x,y].floorHeight  = (short)(Tiles[x,y].floorHeight*2); //remember to divide when writing this back.
								Tiles[x,y].ceilingHeight = 0;//UW_CEILING_HEIGHT;	//constant for uw				

								Tiles[x,y].flags =(short)((FirstTileInt>>7) & 0x3);
								Tiles[x,y].noMagic =(short)( (FirstTileInt>>14) & 0x1);
								Tiles[x,y].doorBit =(short)( (FirstTileInt>>15) & 0x1);
								switch (UWEBase._RES)
								{
									case UWEBase.GAME_UWDEMO://uwdemo
									case UWEBase.GAME_UW1:	//uw1
									case UWEBase.GAME_UW2:
									default:
											Tiles[x,y].floorTexture = getFloorTex(lev_ark,  FirstTileInt);
											Tiles[x,y].wallTexture = getWallTex(lev_ark,  SecondTileInt);
											break;
								}
								if (Tiles[x,y].floorTexture<0)
								{
									Tiles[x,y].floorTexture=0;
								}
								if (Tiles[x,y].floorTexture>=262)
								{
									Tiles[x,y].floorTexture=0;
								}		
								if (Tiles[x,y].wallTexture>=256)
								{
										Tiles[x,y].wallTexture =0;
								}	

								switch(_RES)
								{
								case GAME_UW2:
										Tiles[x,y].isIce=isTextureIce(texture_map[Tiles[x,y].floorTexture]);
										Tiles[x,y].isWater=isTextureWater(texture_map[Tiles[x,y].floorTexture]); //lookup into terrain.dat
										Tiles[x,y].isLava=isTextureLava(texture_map[Tiles[x,y].floorTexture]);
										Tiles[x,y].isNothing = isTextureNothing(texture_map[Tiles[x,y].floorTexture]);
										break;
								default:
										Tiles[x,y].isWater=isTextureWater(texture_map[Tiles[x,y].floorTexture+48]); //lookup into terrain.dat
										Tiles[x,y].isLava=isTextureLava(texture_map[Tiles[x,y].floorTexture+48]);
										Tiles[x,y].isNothing = isTextureNothing(texture_map[Tiles[x,y].floorTexture+48]);
										break;
								}							

								Tiles[x,y].isLand= ! ( (Tiles[x,y].isWater) || (Tiles[x,y].isLava) || (Tiles[x,y].isNothing));

								switch(_RES)
								{
									case GAME_UWDEMO:
									case GAME_UW1:
										Tiles[x,y].terrain=GameWorldController.instance.terrainData.Terrain[ 46 + texture_map[Tiles[x,y].floorTexture+48]];
										//GameWorldController.instance.terrainData.Terrain[256 + textureNo-210]
										break;
									case GAME_UW2:
										Tiles[x,y].terrain=GameWorldController.instance.terrainData.Terrain[texture_map[Tiles[x,y].floorTexture]];
										break;
									default:
										Tiles[x,y].terrain=0;
										break;
								}

								//UW only has a single ceiling texture so this is ignored.
								//Tiles[x,y].shockCeilingTexture = Tiles[x,y].floorTexture;					
								Tiles[x,y].shockCeilingTexture=CeilingTexture;
								//There is only one possible steepness in UW so I set it's properties to match a similar tile in shock.
								if (Tiles[x,y].tileType >=2)
								{
										Tiles[x,y].shockSteep = 1;
										Tiles[x,y].shockSteep =(short)( ((Tiles[x,y].shockSteep  <<3) >> 2)*8 >>3 );	//Shift copied from shock
										Tiles[x,y].shockSlopeFlag = SLOPE_FLOOR_ONLY ;
								}
								else
								{
										Tiles[x,y].shockSlopeFlag = SLOPE_FLOOR_ONLY ;	
								}


								//Tiles[x,y].isDoor = getDoors(FirstTileInt);

								//Different textures on solid tiles faces
								Tiles[x,y].North = Tiles[x,y].wallTexture;
								Tiles[x,y].South = Tiles[x,y].wallTexture;
								Tiles[x,y].East = Tiles[x,y].wallTexture;
								Tiles[x,y].West = Tiles[x,y].wallTexture;
								Tiles[x,y].Top = Tiles[x,y].floorTexture; 
								Tiles[x,y].Bottom = Tiles[x,y].floorTexture; 
								Tiles[x,y].Diagonal = Tiles[x,y].wallTexture;
								//First index of the linked list of objects.
								Tiles[x,y].indexObjectList = getObject(SecondTileInt);

								Tiles[x,y].Render=true;		
								Tiles[x,y].DimX=1;			
								Tiles[x,y].DimY=1;			
								Tiles[x,y].Grouped=false;	

								for (int v = 0; v < 6; v++)
								{
										Tiles[x,y].VisibleFaces[v]=true;
										Tiles[x,y].VisibleFaces[v]=true;
								}
								Tiles[x,y].waterRegion= 0;
								Tiles[x,y].landRegion = 0;//including connected bridges.
								Tiles[x,y].lavaRegion = 0;
						}
				}

				SetTileMapWallFacesUW ();


				if (OverlayAddress!=0)
				{//read in the next 64 entries of length 6 bytes						
					for (int overlayIndex=0; overlayIndex<64; overlayIndex++ )
					{
						Overlays[overlayIndex].index = (short)DataLoader.getValAtAddress(lev_ark,OverlayAddress,16);
						Overlays[overlayIndex].unk1 = (short)DataLoader.getValAtAddress(lev_ark,OverlayAddress+2,16);
						Overlays[overlayIndex].tileX = (short)DataLoader.getValAtAddress(lev_ark,OverlayAddress+4,8);
						Overlays[overlayIndex].index = (short)DataLoader.getValAtAddress(lev_ark,OverlayAddress+5,16);
						OverlayAddress+=6;
					}
				}


			return true;
		}


		/// <summary>
		/// Creates the tile map wall textures for each north, south, east and west faces
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
	public void SetTileMapWallFacesUW ()
	{
		short x; short y;
     	for ( y = 0; y <= TileMap.TileMapSizeY; y++) {
			for (x = 0; x <= TileMap.TileMapSizeX; x++) {
				SetTileWallFacesUW (x,y);
			}
						/*
			if ((x <= TileMap.TileMapSizeX) && (y <= TileMap.TileMapSizeY)) {
				Tiles [x, y].UpperEast = Tiles [x, y].East;
				Tiles [x, y].UpperWest = Tiles [x, y].West;
				Tiles [x, y].UpperNorth = Tiles [x, y].North;
				Tiles [x, y].UpperSouth = Tiles [x, y].South;
				Tiles [x, y].LowerEast = Tiles [x, y].East;
				Tiles [x, y].LowerWest = Tiles [x, y].West;
				Tiles [x, y].LowerNorth = Tiles [x, y].North;
				Tiles [x, y].LowerSouth = Tiles [x, y].South;
			}
			*/
		}
	}

		/// <summary>
		/// Sets the tile wall faces for the selected tile
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
	public void SetTileWallFacesUW (short x, short y)
	{
		if (Tiles [x, y].tileType >= 0)//was just solid only. Note: If textures are all wrong it's probably caused here!
		 {
			//assign it's north texture
			if (y < TileMap.TileMapSizeY) {
				Tiles [x, y].North = Tiles [x, y + 1].wallTexture;
			}
			else {
				Tiles [x, y].North = -1;
			}
			//assign it's southern
			if (y > 0) {
				Tiles [x, y].South = Tiles [x, y - 1].wallTexture;
			}
			else {
				Tiles [x, y].South = -1;
			}
			//it's east
			if (x < TileMap.TileMapSizeX) {
				Tiles [x, y].East = Tiles [x + 1, y].wallTexture;
			}
			else {
				Tiles [x, y].East = -1;
			}
			//assign it's West
			if (x > 0) {
				Tiles [x, y].West = Tiles [x - 1, y].wallTexture;
			}
			else {
				Tiles [x, y].West = -1;
			}
		}
	}

		public bool BuildTileMapShock(char[] archive_ark, int LevelNo)
		{
				long address_pointer=4;
				//LevelInfo=new TileInfo[64,64];

				//char[] archive_ark; //file data
				DataLoader.Chunk lev_ark; 
				/*  unsigned char *tmp_ark; 
  unsigned char *sub_ark;*/ 
				DataLoader.Chunk tex_ark;
				DataLoader.Chunk  inf_ark;




				//Read in the archive.
				//if (!DataLoader.ReadStreamFile(filePath, out archive_ark))
				//{
			//			return false;
				//}

				if (!DataLoader.LoadChunk(archive_ark, LevelNo*100+4004, out inf_ark))
				{//Read in the evel properties.
						return false;
				}
				//Process level properties (height c-space)
				int HeightUnits = (int) DataLoader.getValAtAddress(inf_ark.data,16,32);  //Log2 value. The higher the value the lower the level height.
				if (HeightUnits > 3)  //Any higher we lose data, 
				{
						HeightUnits=3;
				}
				//int cSpace = (int)DataLoader.getValAtAddress(inf_ark.data,24,32);  //Per docs should return 1 on cyberspace. Does'nt appear to work.
				SHOCK_CEILING_HEIGHT = (short)(((256 >> HeightUnits) * 8 >>3));  //Shifts the scale of the level.
				CEILING_HEIGHT= SHOCK_CEILING_HEIGHT;


				//long sizeV = getValAtAddress(inf_ark,0,32);
				//long sizeH = getValAtAddress(inf_ark,4,32);
				//long always6_1 = getValAtAddress(inf_ark,8,32);
				//long always6_2 = getValAtAddress(inf_ark,12,32);  

				if (!DataLoader.LoadChunk(archive_ark, LevelNo*100+4005, out lev_ark))
				{//Read in the level tilemap data
						return false;
				}
				//Read the main level data in
				/* blockAddress =getShockBlockAddress(LevelNo*100+4005,archive_ark, ref chunkPackedLength,ref chunkUnpackedLength,ref chunkType); 
    if (blockAddress == -1) {return false;}
    lev_ark=new char[chunkUnpackedLength]; //or 64*64*16
    LoadShockChunk(blockAddress, chunkType, archive_ark, ref lev_ark,chunkPackedLength,chunkUnpackedLength);
    AddressOfBlockStart=0;
    address_pointer=0;  */


				if (!DataLoader.LoadChunk(archive_ark, LevelNo*100+4007, out tex_ark))
				{//Read in the level texture data
						return false;
				}

				//get the texture data from the archive.is never compressed?
				//AddressOfBlockStart = getShockBlockAddress(4007+ LevelNo*100, archive_ark, ref chunkPackedLength, ref chunkUnpackedLength,ref chunkType);
				//tex_ark = new char[chunkUnpackedLength]; 
				address_pointer=0;
				for (long k=0; k< tex_ark.chunkUnpackedLength/2; k++)
				{
						texture_map[k] =  (short)DataLoader.getValAtAddress(tex_ark.data,address_pointer,16);
						address_pointer =address_pointer+2;   //tmp_ark[AddressOfBlockStart+k];
				}
				address_pointer=0;  


				//Reactor   Map 0  (chunk 40xx)
				//Levels 1-9  Map L  (chunk 4Lxx)
				//SHODAN c/space  Map 10 (chunk 50xx)
				//Delta grove Map 11 (chunk 51xx)
				//Alpha grove Map 12 (chunk 52xx)
				//Beta grove  Map 13 (chunk 53xx)
				//C/space L1-2    Map 14 (chunk 54xx)
				//C/space other Map 15 (chunk 55xx)
				for (int y=0; y<=TileMap.TileMapSizeY;y++)
				{
						for (int x = 0; x <=TileMap.TileMapSizeX; x++)
						{
								//Read in the tile data 
								Tiles[x,y]=new TileInfo();
								Tiles[x,y].tileX = (short)x;
								Tiles[x,y].tileY = (short)y;
								Tiles[x,y].tileType = (short)lev_ark.data[address_pointer];
								switch (Tiles[x,y].tileType)
								{//Need to swap some tile types around so that they conform to uw naming standards.
								case 4: {Tiles[x,y].tileType = 5; break; }
								case 5: {Tiles[x,y].tileType = 4; break; }
								case 7: {Tiles[x,y].tileType = 8; break; }
								case 8: {Tiles[x,y].tileType = 7; break; }
								}
								Tiles[x,y].indexObjectList = 0;
								Tiles[x,y].Render = true;
								Tiles[x,y].DimX = 1;
								Tiles[x,y].DimY = 1;
								Tiles[x,y].Grouped = false;
								for (int v = 0; v < 6; v++)
								{
									Tiles[x,y].VisibleFaces[v] = true;
								}
								/* word 6 contains
        0-5 Wall texture (index into texture list)
        6-10  Ceiling texture
        11-15 Floor texture
        */
								//Tiles[x,y].wallTexture = texture_map[(int)DataLoader.getValAtAddress(lev_ark.data, address_pointer + 6, 16) & 0x3F];
								Tiles[x,y].wallTexture =(short)(DataLoader.getValAtAddress(lev_ark.data, address_pointer + 6, 16) & 0x3F);
								//Tiles[x,y].shockCeilingTexture = texture_map[((int)DataLoader.getValAtAddress(lev_ark.data, address_pointer + 6, 16) >> 6) & 0x1F];
								Tiles[x,y].shockCeilingTexture =(short)((DataLoader.getValAtAddress(lev_ark.data, address_pointer + 6, 16) >> 6) & 0x1F);
								//Tiles[x,y].floorTexture = texture_map[((int)DataLoader.getValAtAddress(lev_ark.data, address_pointer + 6, 16) >> 11) & 0x1F];
								Tiles[x,y].floorTexture = (short)((DataLoader.getValAtAddress(lev_ark.data, address_pointer + 6, 16) >> 11) & 0x1F);
								//Tiles[x,y].wallTexture = 270;//debug
								//Tiles[x,y].shockCeilingTexture = 273;
								Tiles[x,y].North = Tiles[x,y].wallTexture;
								Tiles[x,y].South = Tiles[x,y].wallTexture;
								Tiles[x,y].East = Tiles[x,y].wallTexture;
								Tiles[x,y].West = Tiles[x,y].wallTexture;

								Tiles[x,y].isWater = false;  //No swimming in shock.
								Tiles[x,y].landRegion=0;
								Tiles[x,y].lavaRegion = 0;
								Tiles[x,y].waterRegion = 0;
								Tiles[x,y].floorHeight = (short)((lev_ark.data[address_pointer + 1]) & 0x1F);
								Tiles[x,y].floorHeight = (short)(((Tiles[x,y].floorHeight << 3) >> HeightUnits) * 8 >> 3); //Shift it for varying height scales

								Tiles[x,y].ceilingHeight = (short)((lev_ark.data[address_pointer + 2]) & 0x1F);
								Tiles[x,y].ceilingHeight = (short)(((Tiles[x,y].ceilingHeight << 3) >> HeightUnits) * 8 >> 3); //Shift it for varying height scales

								Tiles[x,y].shockFloorOrientation = (short)(((lev_ark.data[address_pointer + 1]) >> 5) & 0x3);
								Tiles[x,y].shockCeilOrientation =(short)(((lev_ark.data[address_pointer + 2]) >> 5) & 0x3);

								//Need to know heights in various directions for alignments.
								//Will set these properly after loading levels.
								Tiles[x,y].shockNorthCeilHeight = Tiles[x,y].ceilingHeight;
								Tiles[x,y].shockSouthCeilHeight = Tiles[x,y].ceilingHeight;
								Tiles[x,y].shockEastCeilHeight = Tiles[x,y].ceilingHeight;
								Tiles[x,y].shockWestCeilHeight = Tiles[x,y].ceilingHeight;

								Tiles[x,y].shockSteep = (short)(lev_ark.data[address_pointer + 3] & 0x0f);
								Tiles[x,y].shockSteep = (short)(((Tiles[x,y].shockSteep << 3) >> HeightUnits) * 8 >> 3); //Shift it for varying height scales

								if ((Tiles[x,y].shockSteep == 0) && (Tiles[x,y].tileType >= 6))//If a sloped tile has no slope then it's a open tile.
								{
										Tiles[x,y].tileType = 1;
								}
								if ((Tiles[x,y].tileType == 1) && (Tiles[x,y].shockSteep > 0))  //similarly an open tile can't have a slope at all
								{
										Tiles[x,y].shockSteep = 0;
								}
								Tiles[x,y].indexObjectList = (int)DataLoader.getValAtAddress(lev_ark.data, address_pointer + 4, 16);


								//if(Tiles[x,y].indexObjectList!=0)
								//  {
								//  fprintf(LOGFILE,"At %d %d we have: %d\n", x,y,Tiles[x,y].indexObjectList);
								//  }

								/*
        xxxxx0xx  Floor & ceiling, same direction
        xxxxx4xx  Floor & ceiling, ceiling opposite dir to tile type
        xxxxx8xx  Floor only
        xxxxxCxx  Ceiling only
        */
								Tiles[x,y].shockSlopeFlag =(short)((DataLoader.getValAtAddress(lev_ark.data, address_pointer + 8, 32) >> 10) & 0x03);
								Tiles[x,y].UseAdjacentTextures = (short)((DataLoader.getValAtAddress(lev_ark.data, address_pointer + 8, 32) >> 8) & 0x01);
								Tiles[x,y].shockTextureOffset = (short)(DataLoader.getValAtAddress(lev_ark.data, address_pointer + 8, 32) & 0xF);
								//unknownflags
								//70E000E0
								//  fprintf(LOGFILE,"\nUnknownflags @ %d %d= %d",x,y, getValAtAddress(lev_ark,address_pointer+8,32) & 0x70E000E0);
								Tiles[x,y].shockShadeLower = (short)(((int)DataLoader.getValAtAddress(lev_ark.data, address_pointer + 8, 32) >> 16) & 0x0F);
								Tiles[x,y].shockShadeUpper = (short)(((int)DataLoader.getValAtAddress(lev_ark.data, address_pointer + 8, 32) >> 24) & 0x0F);
								//Tiles[x,y].shadeUpperGlobal = 0;
								// Tiles[x,y].shadeLowerGlobal = 0;
								Tiles[x,y].shockNorthOffset = Tiles[x,y].shockTextureOffset;
								Tiles[x,y].shockSouthOffset = Tiles[x,y].shockTextureOffset;
								Tiles[x,y].shockEastOffset = Tiles[x,y].shockTextureOffset;
								Tiles[x,y].shockWestOffset = Tiles[x,y].shockTextureOffset;

								Tiles[x,y].SHOCKSTATE[0] = (int)DataLoader.getValAtAddress(lev_ark.data, address_pointer + 0xC, 8);
								Tiles[x,y].SHOCKSTATE[1] = (int)DataLoader.getValAtAddress(lev_ark.data, address_pointer + 0xD, 8);
								Tiles[x,y].SHOCKSTATE[2] = (int)DataLoader.getValAtAddress(lev_ark.data, address_pointer + 0xE, 8);
								Tiles[x,y].SHOCKSTATE[3] = (int)DataLoader.getValAtAddress(lev_ark.data, address_pointer + 0xF, 8);

								//Tiles[x,y].indexObjectList=0;
								//if (y == 0)
								//{
								//  Tiles[x,y].tileType = TILE_SLOPE_N;
								//  Tiles[x,y].shockSlopeFlag=SLOPE_FLOOR_ONLY;
								//  Tiles[x,y].floorHeight=x;
								//  Tiles[x,y].shockSteep=11;
								//}
								address_pointer=address_pointer+16;
						}
				}

				for (int y=1; y<TileMap.TileMapSizeY;y++) //skip the outer textures.
				{
						for (int x=1; x<TileMap.TileMapSizeX;x++)
						{
								//if (
								//  (Tiles[x,y].tileType  != TILE_OPEN) 
								//  ||  ((Tiles[x,y].tileType  != TILE_OPEN) && (Tiles[x,y].UseAdjacentTextures == 1))
								//  )
								//  {
								//if (Tiles[x,y].UseAdjacentTextures != 1)
								//  {
								if (Tiles[x+1,y].UseAdjacentTextures != 1)
								{
										Tiles[x,y].East = Tiles[x+1,y].wallTexture   ;
										Tiles[x,y].shockEastOffset =Tiles[x+1,y].shockTextureOffset;
										//Tiles[x,y].shockEastCeilHeight =LevelInfo[x+1,y].ceilingHeight - LevelInfo[x+1,y].shockSteep ;

								}
								if (Tiles[x-1,y].UseAdjacentTextures != 1)
								{         
										Tiles[x,y].West = Tiles[x-1,y].wallTexture   ;
										Tiles[x,y].shockWestOffset =Tiles[x-1,y].shockTextureOffset;
										//Tiles[x,y].shockWestCeilHeight =LevelInfo[x-1,y].ceilingHeight - LevelInfo[x-1,y].shockSteep ;

								}
								if (Tiles[x,y+1].UseAdjacentTextures != 1)
								{
										Tiles[x,y].North = Tiles[x,y+1].wallTexture   ;
										Tiles[x,y].shockNorthOffset =Tiles[x,y+1].shockTextureOffset;
										//Tiles[x,y].shockNorthCeilHeight =LevelInfo[x,y+1].ceilingHeight - LevelInfo[x,y+1].shockSteep ;

								}
								if (Tiles[x,y-1].UseAdjacentTextures != 1)
								{
										Tiles[x,y].South  =Tiles[x,y-1].wallTexture   ;
										Tiles[x,y].shockSouthOffset =Tiles[x,y-1].shockTextureOffset;
										//Tiles[x,y].shockSouthCeilHeight =LevelInfo[x,y-1].ceilingHeight - LevelInfo[x,y-1].shockSteep ;

								}
								//Need to calculate the adjustment here with the steepness and the direction of the slope.
								Tiles[x,y].shockEastCeilHeight=(short)CalcNeighbourCeilHeight(Tiles[x,y],Tiles[x+1,y],fEAST);
								Tiles[x,y].shockWestCeilHeight= (short)CalcNeighbourCeilHeight(Tiles[x,y],Tiles[x-1,y],fWEST);
								Tiles[x,y].shockNorthCeilHeight= (short)CalcNeighbourCeilHeight(Tiles[x,y],Tiles[x,y+1],fNORTH);
								Tiles[x,y].shockSouthCeilHeight= (short)CalcNeighbourCeilHeight(Tiles[x,y],Tiles[x,y-1],fSOUTH);
								/*        Tiles[x,y].shockEastCeilHeight =LevelInfo[x+1,y].ceilingHeight - LevelInfo[x+1,y].shockSteep ;
        Tiles[x,y].shockWestCeilHeight =LevelInfo[x-1,y].ceilingHeight - LevelInfo[x-1,y].shockSteep ;
        Tiles[x,y].shockNorthCeilHeight =LevelInfo[x,y+1].ceilingHeight - LevelInfo[x,y+1].shockSteep ;
        Tiles[x,y].shockSouthCeilHeight =LevelInfo[x,y-1].ceilingHeight - LevelInfo[x,y-1].shockSteep ;*/  
								//}

								Tiles[x,y].UpperEast = Tiles[x,y].East;
								Tiles[x,y].UpperWest = Tiles[x,y].West;
								Tiles[x,y].UpperNorth = Tiles[x,y].North;
								Tiles[x,y].UpperSouth = Tiles[x,y].South;
								Tiles[x,y].LowerEast = Tiles[x,y].East;
								Tiles[x,y].LowerWest = Tiles[x,y].West;
								Tiles[x,y].LowerNorth = Tiles[x,y].North;
								Tiles[x,y].LowerSouth = Tiles[x,y].South;
						}
				}
				return true;
		}










		//***********************

		short getTile(int tileData)
		{
				//gets tile data at bits 0-3 of the tile data
				return (short) (tileData & 0x0F);
		}

		short getHeight(int tileData)
		{//gets height data at bits 4-7 of the tile data
				return (short)((tileData & 0xF0) >> 4);
		}

		short getFloorTex(char[] buffer, long tileData)
		{//gets floor texture data at bits 10-13 of the tile data

				return (short)((tileData >>10) & 0x0F);
				//int val = (int)(tileData >>10) & 0x0F;	//gets the index of the texture
				//look it up in texture block for it's absolute index for wxx.tr
				//return (int)DataLoader.getValAtAddress(buffer,textureOffset+96+(val*2),16) +210;			//96 needed?
				//	return ((tileData >>10) & 0x0F);	//was	11
		}

		short getWallTex(char[] buffer, long tileData)
		{
				//gets wall texture data at bits 0-5 (+16) of the tile data(2nd part)
				//return ((tileData >>17)& 0x3F);
				return (short)(tileData & 0x3F);
				//int val = (int)(tileData & 0x3F);	//gets the index of the texture
				//return (int)DataLoader.getValAtAddress(buffer,textureOffset+(val*2),16);
				//return (tileData& 0x3F);
		}

		short getFloorTexUw2(char[] buffer, long textureOffset, long tileData)
		{//gets floor texture data at bits 10-13 of the tile data
				return (short)((tileData >>10) & 0x0F);

				//long val = (tileData >>10) & 0x0F;	//gets the index of the texture
				//look it up in texture block for it's absolute index for wxx.tr
				//return (int)DataLoader.getValAtAddress(buffer,textureOffset+(val*2),16);	
		}

		short getWallTexUw2(char[]  buffer, long textureOffset, long tileData)
		{
				//gets wall texture data at bits 0-5 (+16) of the tile data(2nd part)
				//long val = (tileData & 0x3F);	//gets the index of the texture
				return (short)((tileData & 0x3F));
				//return (int)DataLoader.getValAtAddress(buffer,textureOffset+(val*2),16);
		}


		int getObject(long tileData)
		{
				//gets object data at bits 6-15 (+16) of the tile data(2nd part)
				return (int)tileData >> 6;
		}


		/// <summary>
		/// Cleans up the tilemap. Splits up the tiles into strips of tiles along the x or y axis and sets tile face visibility as required
		/// </summary>
		/// <param name="game">Game.</param>
		/// Although the tile map renderer supports tiles of size X*Y I'm only smart enought to optimise the tilemap into strips of X*1 or Y*1 !!
		public void CleanUp(string game)
		{
				int x; int y;

						for (x=0;x<=TileMap.TileMapSizeX;x++){
							for (y=0;y<=TileMap.TileMapSizeY;y++){
										//Set some easy tile visible settings
										switch (Tiles[x,y].tileType)
										{
										case TILE_SOLID:
												//Bottom and top are invisible
												Tiles[x,y].VisibleFaces[vBOTTOM] = false;
												Tiles[x,y].VisibleFaces[vTOP] = false;
												break;
										default:
												//Bottom and top is invisible
												Tiles[x,y].VisibleFaces[vBOTTOM] = false;
												Tiles[x,y].VisibleFaces[vTOP]=false;
												break;
										}
								}

						for (x=0;x<=TileMap.TileMapSizeX;x++){
								for (y=0;y<=TileMap.TileMapSizeY;y++){
										//lets test this tile for visibility
										//A tile is invisible if it only touches other solid tiles and has no objects or does not have a terrain change.
										if ((Tiles[x,y].tileType ==0) && (Tiles[x,y].indexObjectList == 0)  && (Tiles[x,y].TerrainChange == false)){
												switch (y)
												{
												case 0:	//bottom row
														switch (x)
														{
														case 0:	//bl corner
																if ((Tiles[x + 1,y].tileType == 0) && (Tiles[x,y + 1].tileType == 0)
																		&& (Tiles[x + 1,y].TerrainChange == false) && (Tiles[x,y+1].TerrainChange == false))
																{Tiles[x,y].Render =false ; ;break;}
																else {Tiles[x,y].Render =true ;break;}
														case TileMap.TileMapSizeX://br corner
																if ((Tiles[x - 1,y].tileType == 0) && (Tiles[x,y + 1].tileType == 0)
																		&& (Tiles[x - 1,y].TerrainChange == false) && (Tiles[x,y+1].TerrainChange == false))
																{Tiles[x,y].Render =false ;break;}
																else {Tiles[x,y].Render =true ;break;}
														default: // invert t
																if ((Tiles[x + 1,y].tileType == 0) && (Tiles[x,y + 1].tileType == 0) && (Tiles[x + 1,y].tileType == 0) 
																		&& (Tiles[x+1,y].TerrainChange == false) && (Tiles[x,y+1].TerrainChange == false) && (Tiles[x+1,y].TerrainChange == false))
																{Tiles[x,y].Render =false ;break;}
																else {Tiles[x,y].Render =true ;break;}
														}
														break;
												case TileMap.TileMapSizeY: //Top row
														switch (x)
														{
														case 0:	//tl corner
																if ((Tiles[x + 1,y].tileType == 0) && (Tiles[x,y - 1].tileType == 0) 
																		&& (Tiles[x + 1,y].TerrainChange == false) && (Tiles[x,y-1].TerrainChange == false))
																{Tiles[x,y].Render =false ;break;}
																else {Tiles[x,y].Render =true ;break;}
														case TileMap.TileMapSizeX://tr corner
																if ((Tiles[x - 1,y].tileType == 0) && (Tiles[x,y - 1].tileType == 0) 
																		&& (Tiles[x - 1,y].TerrainChange == false) && (Tiles[x,y-1].TerrainChange == false))
																{Tiles[x,y].Render =false ;break;}
																else {Tiles[x,y].Render =true ;break;}
														default: //  t
																if ((Tiles[x + 1,y].tileType == 0) && (Tiles[x,y - 1].tileType == 0) && (Tiles[x - 1,y].tileType == 0) 
																		&& (Tiles[x + 1,y].TerrainChange == false) && (Tiles[x,y - 1].TerrainChange == false) && (Tiles[x-1,y].TerrainChange == false))
																{Tiles[x,y].Render =false;break;}
																else {Tiles[x,y].Render =true ;break;}
														}	
														break;
												default: //
														switch (x)
														{
														case 0:		//left edge
																if ((Tiles[x,y + 1].tileType == 0) && (Tiles[x + 1,y].tileType == 0) && (Tiles[x,y - 1].tileType == 0) 
																		&& (Tiles[x,y+1].TerrainChange == false) && (Tiles[x+1,y].TerrainChange == false) && (Tiles[x,y-1].TerrainChange == false))
																{Tiles[x,y].Render =false;break;}
																else {Tiles[x,y].Render =true ;break;}
														case TileMap.TileMapSizeX:	//right edge
																if ((Tiles[x,y + 1].tileType == 0) && (Tiles[x - 1,y].tileType == 0) && (Tiles[x,y - 1].tileType == 0) 
																		&& (Tiles[x,y+1].TerrainChange == false) && (Tiles[x-1,y].TerrainChange == false) && (Tiles[x,y-1].TerrainChange == false))
																{Tiles[x,y].Render =false ;break;}
																else {Tiles[x,y].Render =true ;break;}
														default:		//+
																if ((Tiles[x,y + 1].tileType == 0) && (Tiles[x + 1,y].tileType == 0) && (Tiles[x,y - 1].tileType == 0) && (Tiles[x - 1,y].tileType == 0) 
																		&& (Tiles[x,y + 1].TerrainChange == false) && (Tiles[x + 1,y].TerrainChange == false) && (Tiles[x,y - 1].TerrainChange == false) && (Tiles[x-1,y].TerrainChange == false))
																{Tiles[x,y].Render =false; break;}
																else {Tiles[x,y].Render =true ;break;}
														}
														break;
												}
										}
								}
						}	
				}







				//return;
				if (game == GAME_SHOCK) 
				{//TODO:FIx some z-fighting due to tile visibility.
						return;		
				}
				int j=1 ;
				//Now lets combine the solids along particular axis
				for (x=0;x<TileMap.TileMapSizeX;x++){
						for (y=0;y<TileMap.TileMapSizeY;y++){
								if  ((Tiles[x,y].Grouped ==false))
								{
										j=1;
										while ((Tiles[x,y].Render == true) && (Tiles[x,y + j].Render == true) && (Tiles[x,y + j].Grouped == false))		//&& (Tiles[x,y].tileType ==0) && (Tiles[x,y+j].tileType ==0)
										{
												//combine these two if they match and they are not already part of a group
												if (DoTilesMatch(Tiles[x,y],Tiles[x,y+j])){
														Tiles[x,y+j].Render =false;
														Tiles[x,y+j].Grouped =true;
														Tiles[x,y].Grouped =true;
														//Tiles[x,y].DimY++;
														j++;
												}
												else
												{
														break;
												}

										}
										Tiles[x,y].DimY =(short)( Tiles[x,y].DimY +j-1);
										j=1;
								}
						}
				}
				j=1;

				////Now lets combine solids along the other axis
				for (y=0;y<TileMap.TileMapSizeY;y++){
						for (x=0;x<TileMap.TileMapSizeX;x++){
								if  ((Tiles[x,y].Grouped ==false))
								{
										j=1;
										while ((Tiles[x,y].Render == true) && (Tiles[x + j,y].Render == true) && (Tiles[x + j,y].Grouped == false))		//&& (Tiles[x,y].tileType ==0) && (Tiles[x,y+j].tileType ==0)
										{
												//combine these two if they  match and they are not already part of a group
												if (DoTilesMatch(Tiles[x,y],Tiles[x+j,y])){
														Tiles[x+j,y].Render =false;
														Tiles[x+j,y].Grouped =true;
														Tiles[x,y].Grouped =true;
														//Tiles[x,y].DimY++;
														j++;
												}
												else
												{
														break;
												}

										}
										Tiles[x,y].DimX =(short)( Tiles[x,y].DimX +j-1);
										j=1;
								}
						}
				}

				//Clear invisible faces on solid tiles. 
				//TODO:Support all 64x64 tiles
				for (y = 0; y<=TileMap.TileMapSizeY; y++){
						for (x = 0; x<=TileMap.TileMapSizeX; x++){
								if ((Tiles[x,y].tileType == TILE_SOLID))
								{
										int dimx = Tiles[x,y].DimX;
										int dimy = Tiles[x,y].DimY;

										if (x == 0)
										{
												Tiles[x,y].VisibleFaces[vWEST]=false;
										}
										if (x == TileMap.TileMapSizeX)
										{
												Tiles[x,y].VisibleFaces[vEAST] = false;
										}
										if (y == 0 )
										{
												Tiles[x,y].VisibleFaces[vSOUTH] = false;
										}

										if (y == TileMap.TileMapSizeY)
										{
												Tiles[x,y].VisibleFaces[vNORTH] = false;
										}
										if ((x+dimx <= TileMap.TileMapSizeX) && (y+dimy <= TileMap.TileMapSizeY))
										{
												if ((Tiles[x + dimx,y].tileType == TILE_SOLID) && (Tiles[x + dimx,y].TerrainChange == false) && (Tiles[x,y].TerrainChange == false))//Tile to the east is a solid
												{
														Tiles[x,y].VisibleFaces[vEAST] = false;
														Tiles[x + dimx,y].VisibleFaces[vWEST] = false;
												}
												if ((Tiles[x,y + dimy].tileType == TILE_SOLID) && (Tiles[x,y].TerrainChange == false) && (Tiles[x,y + dimy].TerrainChange == false))//TIle to the north is a solid
												{
														Tiles[x,y].VisibleFaces[vNORTH] = false;
														Tiles[x,y + dimy].VisibleFaces[vSOUTH] = false;
												}
										}
								}
						}
				}

				//Clear invisible faces on diagonals
				for (y = 1; y < TileMap.TileMapSizeY; y++){
						for (x = 1; x < TileMap.TileMapSizeX; x++){
								switch (Tiles[x,y].tileType)
								{
								case TILE_DIAG_NW:
										{
												if ((Tiles[x,y - 1].tileType == TILE_SOLID) && (Tiles[x,y-1].TerrainChange == false))
												{
														Tiles[x,y].VisibleFaces[vSOUTH]=false;
														Tiles[x,y - 1].VisibleFaces[vNORTH]=false;
												}
												if ((Tiles[x + 1,y].tileType == TILE_SOLID) && (Tiles[x + 1,y].TerrainChange== false))
												{
														Tiles[x,y].VisibleFaces[vEAST] = false;
														Tiles[x + 1,y].VisibleFaces[vWEST]=false;
												}
										}
										break;
								case TILE_DIAG_NE:
										{
												if ((Tiles[x,y - 1].tileType == TILE_SOLID) && (Tiles[x,y - 1].TerrainChange == false))
												{
														Tiles[x,y].VisibleFaces[vSOUTH] = false;
														Tiles[x,y - 1].VisibleFaces[vNORTH] = false;
												}
												if ((Tiles[x - 1,y].tileType == TILE_SOLID) && (Tiles[x - 1,y].TerrainChange == false))
												{
														Tiles[x,y].VisibleFaces[vWEST] = false;
														Tiles[x - 1,y].VisibleFaces[vEAST] = false;
												}
										}
										break;
								case TILE_DIAG_SE:
										{
												if ((Tiles[x,y + 1].tileType == TILE_SOLID) && (Tiles[x,y + 1].TerrainChange == false))
												{
														Tiles[x,y].VisibleFaces[vNORTH] = false;
														Tiles[x,y + 1].VisibleFaces[vSOUTH] = false;
												}
												if ((Tiles[x - 1,y].tileType == TILE_SOLID) && (Tiles[x - 1,y].TerrainChange == false))
												{
														Tiles[x,y].VisibleFaces[vWEST] = false;
														Tiles[x - 1,y].VisibleFaces[vEAST] = false;
												}
										}
										break;
								case TILE_DIAG_SW:
										{
												if ((Tiles[x,y + 1].tileType == TILE_SOLID) && (Tiles[x,y + 1].TerrainChange == false))
												{
														Tiles[x,y].VisibleFaces[vNORTH] = false;
														Tiles[x,y + 1].VisibleFaces[vSOUTH] = false;
												}
												if ((Tiles[x + 1,y].tileType == TILE_SOLID) && (Tiles[x + 1,y].TerrainChange == false))
												{
														Tiles[x,y].VisibleFaces[vEAST] = false;
														Tiles[x + 1,y].VisibleFaces[vWEST] = false;
												}
										}
										break;
								}

						}

				}

				for (y = 1; y < TileMap.TileMapSizeY; y++){
						for (x = 1; x < TileMap.TileMapSizeX; x++){
								if ((Tiles[x,y].tileType == TILE_OPEN) && (Tiles[x,y].TerrainChange == false))
								{
										if (
												((Tiles[x + 1,y].tileType == TILE_OPEN) && (Tiles[x + 1,y].TerrainChange == false) && (Tiles[x + 1,y].floorHeight >= Tiles[x,y].floorHeight))
												||
												(Tiles[x + 1,y].tileType == TILE_SOLID) && (Tiles[x + 1,y].TerrainChange == false) 
										)
										{
												Tiles[x,y].VisibleFaces[vEAST]=false;
										}


										if (
												((Tiles[x - 1,y].tileType == TILE_OPEN) && (Tiles[x - 1,y].TerrainChange == false) && (Tiles[x - 1,y].floorHeight >= Tiles[x,y].floorHeight))
												||
												(Tiles[x - 1,y].tileType == TILE_SOLID) && (Tiles[x - 1,y].TerrainChange == false)
										)
										{
												Tiles[x,y].VisibleFaces[vWEST] = false;
										}


										if (
												((Tiles[x,y + 1].tileType == TILE_OPEN) && (Tiles[x,y + 1].TerrainChange == false) && (Tiles[x,y + 1].floorHeight >= Tiles[x,y].floorHeight))
												||
												(Tiles[x,y + 1].tileType == TILE_SOLID) && (Tiles[x,y + 1].TerrainChange == false) 
										)
										{
												Tiles[x,y].VisibleFaces[vNORTH] = false;
										}

										if (
												((Tiles[x,y - 1].tileType == TILE_OPEN) && (Tiles[x,y - 1].TerrainChange == false) && (Tiles[x,y - 1].floorHeight >= Tiles[x,y].floorHeight))
												||
												(Tiles[x,y - 1].tileType == TILE_SOLID) && (Tiles[x,y - 1].TerrainChange == false)
										)
										{
												Tiles[x,y].VisibleFaces[vSOUTH] = false;
										}
								}

						}
				}
				//Make sure solids & opens are still consistently visible.
				for (y = 1; y < TileMap.TileMapSizeY; y++){
						for (x = 1; x < TileMap.TileMapSizeX; x++){

								if ((Tiles[x,y].tileType == TILE_SOLID) || (Tiles[x,y].tileType == TILE_OPEN))
								{
										int dimx = Tiles[x,y].DimX;
										int dimy = Tiles[x,y].DimY;
										if (dimx>1)
										{//Make sure the ends are set properly
												Tiles[x,y].VisibleFaces[vEAST] = Tiles[x + dimx - 1,y].VisibleFaces[vEAST];
										}
										if (dimy>1)
										{
												Tiles[x,y].VisibleFaces[vNORTH] = Tiles[x,y + dimy - 1].VisibleFaces[vNORTH];
										}

										//Check along each axis
										for (int i = 0; i < Tiles[x,y].DimX; i++)
										{
												if (Tiles[x + i,y].VisibleFaces[vNORTH] == true)
												{
														Tiles[x,y].VisibleFaces[vNORTH]=true;
												}
												if (Tiles[x + i,y].VisibleFaces[vSOUTH] == true)
												{
														Tiles[x,y].VisibleFaces[vSOUTH] = true;
												}
										}

										for (int i = 0; i < Tiles[x,y].DimY; i++)
										{
												if (Tiles[x,y+i].VisibleFaces[vEAST] == true)
												{
														Tiles[x,y].VisibleFaces[vEAST] = true;
												}
												if (Tiles[x,y+i].VisibleFaces[vWEST] == true)
												{
														Tiles[x,y].VisibleFaces[vWEST] = true;
												}
										}

								}
						}
				}
				for ( y = 0; y <= TileMap.TileMapSizeY; y++){
						Tiles[0,y].VisibleFaces[vEAST]=true;
						Tiles[TileMap.TileMapSizeX,y].VisibleFaces[vWEST] = true;
				}
				for ( x = 0; x <= TileMap.TileMapSizeX; x++){
						Tiles[x,0].VisibleFaces[vNORTH] = true;
						Tiles[x,TileMap.TileMapSizeY].VisibleFaces[vSOUTH] = true;
				}
		}



		bool DoTilesMatch(TileInfo t1, TileInfo t2)
		{//TODO:Tiles have a lot more properties now.
				if(_RES==GAME_SHOCK)
				{return false;}
				//if ((t1.tileType >1) || (t1.hasElevator==1) || (t1.TerrainChange ==1) ||  (t2.hasElevator==1) || (t2.TerrainChange ==1) || (t1.isWater ==1) || (t2.isWater ==1)){	//autofail no none solid/open/special.
				if ((t1.tileType >1)  || (t1.TerrainChange == true)  || (t2.TerrainChange == true)){	//autofail no none solid/open/special.
						return false;
				}
				else
				{
						if ((t1.tileType==0) && (t2.tileType == 0))	//solid
						{
								return ((t1.wallTexture==t2.wallTexture) && (t1.West == t2.West) && (t1.South == t2.South) && (t1.East == t2.East) && (t1.North == t2.North) && (t1.UseAdjacentTextures == t2.UseAdjacentTextures));
						}
						else
						{
								return (t1.shockCeilingTexture == t2.shockCeilingTexture)
										&& (t1.floorTexture == t2.floorTexture) 
										&& (t1.floorHeight == t2.floorHeight)
										&& (t1.ceilingHeight == t2.ceilingHeight )
										&& (t1.DimX==t2.DimX) && (t1.DimY == t2.DimY ) 
										&& (t1.wallTexture == t2.wallTexture)
										&& (t1.tileType == t2.tileType ) 
										&& (t1.isDoor==false) && (t2.isDoor ==false);//
						}
				}
		}
		/*
		/// <summary>
		/// Merges the room tile list so that each ground tile is part of a "room" or continous connected region. This defines where an NPC can travel to.
		/// </summary>
		/// <param name="">.</param>
		public void setRooms()
		{			
				int RoomIndex=1;
				ResetTileTests();
				for (int x = 0; x<=TileMap.TileMapSizeX; x++)
				{
						for (int y = 0; y<=TileMap.TileMapSizeY; y++)
						{
								currRoomIndex = RoomIndex;
								if (isMergeableRoom(x,y))
								{//Start Merging
										Tiles[x,y].landRegion = (short)RoomIndex;
										MergeCurrentRoomRegion((short)RoomIndex, x, y);
										RoomIndex = RoomIndex+1;
								}
						}
				}
		}
		*/
		/// <summary>
		/// Resets the tile tests state
		/// </summary>
		/// <param name="">.</param>
	//	void ResetTileTests()
	//	{
	//			for (int x = 0; x<=TileMap.TileMapSizeX; x++)
	//			{
	//					for (int y = 0; y<=TileMap.TileMapSizeY; y++)
	//					{
	//							Tiles[x,y].tileTested=0;
	//					}
	//			}
	//	}
		/*

		void MergeCurrentRoomRegion(short currRegion, int x, int y)
		{
				//north
				if (isMergeableRoom(x, y + 1))
				{
						Tiles[x,y+1].landRegion = currRegion;
						MergeCurrentRoomRegion( currRegion, x, y + 1);
				}
				//south
				if (isMergeableRoom( x, y - 1))
				{
						Tiles[x,y-1].landRegion = currRegion;
						MergeCurrentRoomRegion(currRegion, x, y - 1);
				}
				//east
				if (isMergeableRoom( x + 1, y))
				{
						Tiles[x+1,y].landRegion = currRegion;
						MergeCurrentRoomRegion( currRegion, x + 1, y);
				}
				//west
				if (isMergeableRoom( x - 1, y))
				{
						Tiles[x-1,y].landRegion = currRegion;
						MergeCurrentRoomRegion( currRegion, x - 1, y);
				}
		}
*/



		/*
		bool isMergeableRoom(int x, int y)
		{
				if (
						(Tiles[x,y].isWater == false)
						&&
						(Tiles[x,y].isLava == false)
						&&
						(Tiles[x,y].tileType != TILE_SOLID)
						&&
						(Tiles[x,y].landRegion == 0)
				)
				{
						return true;
				}
				else
				{
						if ((Tiles[x,y].hasBridge) && (Tiles[x,y].bridgeRegion == 0))
						{
								Tiles[x,y].bridgeRegion = (short)currRoomIndex;
								return true;
						}
						else
						{
								return false;
						}	
				}
		}

*/



		//Get land region of the tile
		public string GetTileRegionName(int tileX, int tileY)
		{
		if ((tileX != TileMap.ObjectStorageTile) && (tileY != TileMap.ObjectStorageTile))
		{
			if (Tiles[tileX,tileY].isLava)
				{
					return "_LavaMesh_" + thisLevelNo + "_" + Tiles[tileX,tileY].lavaRegion;
				}
				else if (Tiles[tileX,tileY].isWater)
				{
					return "_WaterMesh_" + thisLevelNo+ "_" + Tiles[tileX,tileY].waterRegion;
				}
				else
				{
					return "_GroundMesh_" + thisLevelNo + "_" + Tiles[tileX,tileY].landRegion;

				}

		}
			else
			{
				return "_GroundMesh_" + thisLevelNo + "_0";
			}

		}

		//Temp
		public static bool isTextureWater(int textureNo)
		{
				if (textureNo> GameWorldController.instance.terrainData.Terrain.GetUpperBound(0) )
				{
						return false;
				}
				switch(_RES)
				{
				case GAME_UW2:
					return 
						(
							GameWorldController.instance.terrainData.Terrain[textureNo] == TerrainDatLoader.Water
								||
							GameWorldController.instance.terrainData.Terrain[textureNo] == TerrainDatLoader.Waterfall
								||
							GameWorldController.instance.terrainData.Terrain[textureNo] == TerrainDatLoader.WaterFlowEast
								||
								GameWorldController.instance.terrainData.Terrain[textureNo] == TerrainDatLoader.WaterFlowWest
								||
								GameWorldController.instance.terrainData.Terrain[textureNo] == TerrainDatLoader.WaterFlowNorth
								||
								GameWorldController.instance.terrainData.Terrain[textureNo] == TerrainDatLoader.WaterFlowSouth
						);

				default:
					return GameWorldController.instance.terrainData.Terrain[256 + textureNo-210] == TerrainDatLoader.Water;//Adjust for uw1 texturemap positions
				}
		}

		public static bool isTextureIce(int textureNo)
		{
			if (textureNo> GameWorldController.instance.terrainData.Terrain.GetUpperBound(0) )
			{
					return false;
			}
			switch(_RES)
			{
			case GAME_UW2:
					return (
								

								(GameWorldController.instance.terrainData.Terrain[textureNo] == TerrainDatLoader.Ice_wall)
						);
								//GameWorldController.instance.terrainData.Terrain[textureNo] == TerrainDatLoader.IceNonSlip)
								//||

			default:
					return GameWorldController.instance.terrainData.Terrain[256 + textureNo-210] == TerrainDatLoader.Water;//Adjust for uw1 texturemap positions
			}
		}


		public static bool isTextureLava(int textureNo)
		{
				if (textureNo> GameWorldController.instance.terrainData.Terrain.GetUpperBound(0) )
				{
						return false;
				}
				switch(_RES)
				{
				case GAME_UW2:
						return (
								(GameWorldController.instance.terrainData.Terrain[textureNo] == TerrainDatLoader.Lava)
								||
								(GameWorldController.instance.terrainData.Terrain[textureNo] == TerrainDatLoader.Lavafall)
							);

				default:
						return GameWorldController.instance.terrainData.Terrain[256 + textureNo-210] == TerrainDatLoader.Lava;//Adjust for uw1 texturemap positions
				}			
		}

		/// <summary>
		/// Is the texture nothing.
		/// </summary>
		/// <returns><c>true</c>, if texture nothing was ised, <c>false</c> otherwise.</returns>
		/// <param name="textureNo">Texture no.</param>
		public static bool isTextureNothing(int textureNo)
		{
			switch (textureNo)
				{
				case 236:
					return true;
				}
				return false;	
		}


		/*
		public void MergeWaterRegions()
		{
				int currRegion;
				currRegion =1;
				for (int x = 0; x<=TileMap.TileMapSizeX; x++)
				{
						for (int y = 0; y<=TileMap.TileMapSizeY; y++)
						{
								if (Tiles[x,y].hasBridge != true)
								{
										if ((Tiles[x,y].isWater == true) && (Tiles[x,y].waterRegion == 0))//Unset water region.
										{
												Tiles[x,y].waterRegion = (short)currRegion;
												MergeCurrentWaterRegion(currRegion, x, y);
												currRegion++;
										}
								}
						}
				}
		}

		void MergeCurrentWaterRegion(int currRegion, int x, int y)
		{
				//north
				if ((Tiles[x,y+1].isWater==true) && (Tiles[x,y+1].waterRegion == 0))
				{
						Tiles[x,y + 1].waterRegion = (short)currRegion;
						MergeCurrentWaterRegion(currRegion, x, y+1);
				}
				//south
				if ((Tiles[x,y - 1].isWater == true) && (Tiles[x,y - 1].waterRegion == 0))
				{
						Tiles[x,y - 1].waterRegion = (short)currRegion;
						MergeCurrentWaterRegion(currRegion, x , y-1);
				}
				//east
				if ((Tiles[x + 1,y].isWater == true) && (Tiles[x + 1,y].waterRegion == 0))
				{
						Tiles[x + 1,y].waterRegion = (short)currRegion;
						MergeCurrentWaterRegion(currRegion, x+1, y);
				}
				//west
				if ((Tiles[x - 1,y].isWater == true) && (Tiles[x - 1,y].waterRegion == 0))
				{
						Tiles[x - 1,y].waterRegion = (short)currRegion;
						MergeCurrentWaterRegion(currRegion, x-1, y);
				}
		}
*/
		/*
		/// <summary>
		/// Merges the lava regions into a single region
		/// </summary>
		public void MergeLavaRegions()
		{
				int currRegion;
				currRegion = 1;
				for (int x = 0; x<=TileMap.TileMapSizeX; x++)
				{
						for (int y = 0; y<=TileMap.TileMapSizeY; y++)
						{
								if (Tiles[x,y].hasBridge != true)
								{
										if ((Tiles[x,y].isLava == true) && (Tiles[x,y].lavaRegion == 0))//Unset lava region.
										{
												Tiles[x,y].lavaRegion = (short)currRegion;
												MergeCurrentLavaRegion(currRegion, x, y);
												currRegion++;
										}
								}
						}
				}
		}

		void MergeCurrentLavaRegion( int currRegion, int x, int y)
		{
				//north
				if ((Tiles[x,y + 1].isLava == true) && (Tiles[x,y + 1].lavaRegion == 0))
				{
						Tiles[x,y + 1].lavaRegion = (short)currRegion;
						MergeCurrentLavaRegion(currRegion, x, y + 1);
				}
				//south
				if ((Tiles[x,y - 1].isLava == true) && (Tiles[x,y - 1].lavaRegion == 0))
				{
						Tiles[x,y - 1].lavaRegion =(short) currRegion;
						MergeCurrentLavaRegion( currRegion, x, y - 1);
				}
				//east
				if ((Tiles[x + 1,y].isLava == true) && (Tiles[x + 1,y].lavaRegion == 0))
				{
						Tiles[x + 1,y].lavaRegion =(short) currRegion;
						MergeCurrentLavaRegion( currRegion, x + 1, y);
				}
				//west
				if ((Tiles[x - 1,y].isLava == true) && (Tiles[x - 1,y].lavaRegion == 0))
				{
						Tiles[x - 1,y].lavaRegion = (short)currRegion;
						MergeCurrentLavaRegion(currRegion, x - 1, y);
				}
		}

		*/

		int CalcNeighbourCeilHeight(TileInfo t1, TileInfo t2,int Direction)
		{//TODO:Test me. I'm terrible.
				// fNORTH 32
				// fSOUTH 16
				// fEAST 8
				// fWEST 4
				if  ((t2.tileType <=1) ||(t2.shockSlopeFlag == SLOPE_FLOOR_ONLY))
				{//Don't need to do anything since it has a flat ceiling.
						return t2.ceilingHeight;
				}
				else
				{
						//return t2.ceilingHeight;
						switch (Direction)
						{
						case fNORTH:
								{ 
										switch (t2.tileType)
										{
										case TILE_SLOPE_N:
										case TILE_SLOPE_S:
												if ((t2.shockSlopeFlag == SLOPE_BOTH_OPPOSITE) ||(t2.shockSlopeFlag == SLOPE_CEILING_ONLY))
												{
														return t2.ceilingHeight+t2.shockSteep ;
												}
												else
												{
														return t2.ceilingHeight;
												}
												//break;
										default:
												return t2.ceilingHeight;
												//break;
										}
								} 
						case fSOUTH:
								{
										switch (t2.tileType)
										{
										case TILE_SLOPE_S:
										case TILE_SLOPE_N:
												if ((t2.shockSlopeFlag == SLOPE_BOTH_OPPOSITE) ||(t2.shockSlopeFlag == SLOPE_CEILING_ONLY))
												{
														return t2.ceilingHeight+t2.shockSteep ;
												}
												else
												{
														return t2.ceilingHeight;
												}
												//break;
										default:
												return t2.ceilingHeight;
												//break;
										}
										//if (t2.tileType == TILE_SLOPE_S)
										//  {
										//  if ((t2.shockSlopeFlag == SLOPE_BOTH_OPPOSITE) ||(t2.shockSlopeFlag == SLOPE_CEILING_ONLY))
										//    {
										//    return t2.ceilingHeight+t2.shockSteep ;
										//    }
										//  else
										//    {
										//    return t2.ceilingHeight;
										//    }
										//  }
										//break;
								} 
						case fEAST:
								{
										switch (t2.tileType)
										{
										case TILE_SLOPE_E:
										case TILE_SLOPE_W:
												if ((t2.shockSlopeFlag == SLOPE_BOTH_OPPOSITE) ||(t2.shockSlopeFlag == SLOPE_CEILING_ONLY))
												{
														return t2.ceilingHeight+t2.shockSteep ;
												}
												else
												{
														return t2.ceilingHeight;
												}
												//break;
										default:
												return t2.ceilingHeight;
												//break;
										}
								} 
						case fWEST:
								{
										switch (t2.tileType)
										{
										case TILE_SLOPE_W:
										case TILE_SLOPE_E:
												if ((t2.shockSlopeFlag == SLOPE_BOTH_OPPOSITE) ||(t2.shockSlopeFlag == SLOPE_CEILING_ONLY))
												{
														return t2.ceilingHeight+t2.shockSteep ;
												}
												else
												{
														return t2.ceilingHeight;
												}
												//break;
										default:
												return t2.ceilingHeight;
												//break;
										}
								}
						}
				}
				return t2.ceilingHeight;
		}


	/*	char[] GetUW2TileMapBytes(int LevelNo, char[] lev_ark_file_data, out long datalen)
		{	
				char[] lev_ark;
				long address_pointer=0;
				int NoOfBlocks=(int)DataLoader.getValAtAddress(lev_ark_file_data,0,32);	
				datalen=0;
				address_pointer=6;
				int isCompressed =( ( (int)DataLoader.getValAtAddress(lev_ark_file_data,address_pointer + (NoOfBlocks*4) + (LevelNo*4) ,32)  ) >>1) & 0x01;

				address_pointer=(LevelNo * 4) + 6;

				if ((int)DataLoader.getValAtAddress(lev_ark_file_data,address_pointer,32)==0)
				{
						Debug.Log("This should not happen in getuw2tilemapbytes");
						lev_ark= new char[1];
						return lev_ark ;
				}
				if (isCompressed == 1)
				{
						//long datalen=0;
						lev_ark = DataLoader.unpackUW2(lev_ark_file_data,DataLoader.getValAtAddress(lev_ark_file_data,address_pointer,32), ref datalen);
				}
				else
				{
						datalen = 0x7c08;
						int BlockStart = (int)DataLoader.getValAtAddress(lev_ark_file_data, address_pointer, 32);
						lev_ark = new char[0x7c08];//Make sure this contains the object data as well.
						int j=0;
						for (int i = BlockStart; i < BlockStart + 0x7c08; i++)
						{
								lev_ark[j] = lev_ark_file_data[i];
								j++;
						}
				}
				return lev_ark;
		}*/


		/// <summary>
		/// Converts this tilemap/Objectlist into an array that can be written to file.
		/// </summary>
		/// <returns>The map to bytes.</returns>
		public char[] TileMapToBytes(char[] lev_ark_file_data, out long datalen)
		{
				 
				char[] TileMapData= new char[31752];//Size of tilemap + object list

				DataLoader.UWBlock uwdata = new DataLoader.UWBlock();

				DataLoader.LoadUWBlock(lev_ark_file_data, thisLevelNo, 31752, out uwdata)  ;

				for (int i=0x7afc; i<31752;i++)//07afc
				{
					TileMapData[i]= uwdata.Data[i]; 		
				}

				datalen = uwdata.DataLen;

				long addptr=0;
				for (int y=0; y<=TileMap.TileMapSizeY;y++)
				{
						for (int x=0; x<=TileMap.TileMapSizeX;x++)
						{		
								TileInfo t = Tiles[x,y];

								//Shift the bits to construct my data
								int tileType = t.tileType;
								int floorHeight = (t.floorHeight/2) << 4;


								int ByteToWrite = tileType | floorHeight ;//| floorTexture | noMagic;//This will be set in the original data
								TileMapData[addptr]= (char)(ByteToWrite);

								int floorTexture = t.floorTexture<<2;
								int noMagic = t.noMagic << 6;
								int DoorBit = t.doorBit << 7;
								ByteToWrite= floorTexture | noMagic | DoorBit;
								TileMapData[addptr+1]= (char)(ByteToWrite);

								//if ((x==19) && (y==48))
							//	{
										ByteToWrite = ((t.indexObjectList & 0x3FF) <<6) | (t.wallTexture & 0x3F);
										TileMapData[addptr+2]=(char)(ByteToWrite & 0xFF);
										TileMapData[addptr+3]=(char)((ByteToWrite>>8) & 0xFF);	
								//}


								addptr +=4;
						}	
				}	
				for (int o=0; o<=GameWorldController.instance.objectList[thisLevelNo].objInfo.GetUpperBound(0);o++)
				{
						ObjectLoaderInfo currobj= GameWorldController.instance.objectList[thisLevelNo].objInfo[o];
						if (currobj!=null)
						{
							/*	if (currobj.instance!=null)
								{
										if (currobj.instance.transform.parent == GameWorldController.instance.InventoryMarker.transform)
										{
												Debug.Log("Trying to save object that is in inventory list" + currobj.instance.name);
										}									
								}
								else
								{
										if (currobj.InUseFlag==1)
										{
												Debug.Log("Trying to save in use object that has no current instance:" + o);		
										}
								}	*/

								if (IsObjectFree(o))
								{
										TileMapData[addptr]=(char)0;
										TileMapData[addptr+1]=(char)0;
										TileMapData[addptr+2]=(char)0;
										TileMapData[addptr+3]=(char)0;
										TileMapData[addptr+4]=(char)0;
										TileMapData[addptr+5]=(char)0;
										TileMapData[addptr+6]=(char)0;
										TileMapData[addptr+7]=(char)0;
										if (o<256)
										{
												TileMapData[addptr+8]=(char)0;
												TileMapData[addptr+9]=(char)0;
												TileMapData[addptr+10]=(char)0;
												TileMapData[addptr+11]=(char)0;
												TileMapData[addptr+12]=(char)0;
												TileMapData[addptr+13]=(char)0;
												TileMapData[addptr+14]=(char)0;
												TileMapData[addptr+15]=(char)0;
												TileMapData[addptr+16]=(char)0;
												TileMapData[addptr+17]=(char)0;
												TileMapData[addptr+18]=(char)0;
												TileMapData[addptr+19]=(char)0;
												TileMapData[addptr+20]=(char)0;
												TileMapData[addptr+21]=(char)0;
												TileMapData[addptr+22]=(char)0;
												TileMapData[addptr+23]=(char)0;
												TileMapData[addptr+24]=(char)0;
												TileMapData[addptr+25]=(char)0;
												TileMapData[addptr+26]=(char)0;
												addptr=addptr+8+19;	
										}
										else
										{
												addptr=addptr+8;	
										}
								}
								else
								{
									int ByteToWrite= (currobj.is_quant << 15) |
											(currobj.invis << 14) |
											(currobj.doordir << 13) |
											(currobj.enchantment << 12) |
											((currobj.flags & 0x07) << 9) |
											(currobj.item_id & 0x1FF) ;

									TileMapData[addptr]=(char)(ByteToWrite & 0xFF);
									TileMapData[addptr+1]=(char)((ByteToWrite>>8) & 0xFF);

									ByteToWrite = ((currobj.x & 0x7) << 13) |
											((currobj.y & 0x7) << 10) |
											((currobj.heading & 0x7) << 7) |
											((currobj.zpos & 0x7F));
									TileMapData[addptr+2]=(char)(ByteToWrite & 0xFF);
									TileMapData[addptr+3]=(char)((ByteToWrite>>8) & 0xFF);

									ByteToWrite = (((int)currobj.next & 0x3FF)<<6) |
											(currobj.quality & 0x3F); 
									TileMapData[addptr+4]=(char)(ByteToWrite & 0xFF);
									TileMapData[addptr+5]=(char)((ByteToWrite>>8) & 0xFF);	

									ByteToWrite = ((currobj.link & 0x3FF)<<6) |
											(currobj.owner & 0x3F); 
									TileMapData[addptr+6]=(char)(ByteToWrite & 0xFF);
									TileMapData[addptr+7]=(char)((ByteToWrite>>8) & 0xFF);	


									if (o<256)			
									{//Additional npc mobile data.

											TileMapData[addptr+0x8] = (char)(currobj.npc_hp);
											TileMapData[addptr+0x9] = (char)((currobj.ProjectileHeadingMajor & 0xE0) | ((char)(currobj.ProjectileHeadingMinor  & 0x1F )));
											//+A is copied  unknown value
											//+B   bits 0-3 npc_goal, 4-11 npc_gtarg, 12-15 is unknown but needs to be copied to prevent npcs duplicating.
											ByteToWrite=( 
													((currobj.npc_goal & 0xF))  |
													((currobj.npc_gtarg & 0xFF) <<4)  |
													( (TileMapData[addptr+0xb+1] & 0xf0) << 8 )										
											);
											TileMapData[addptr+0xb] = (char)(ByteToWrite & 0xFF);
											TileMapData[addptr+0xb+1] = (char)((ByteToWrite>>8) & 0xFF);


											int val = (int)DataLoader.getValAtAddress(TileMapData,addptr+0xd,16);
											val = val & 0x1ff0;
											ByteToWrite=((currobj.npc_attitude & 0x3)<<14) |
													((currobj.npc_talkedto & 0x1)<<13) |
													(currobj.npc_level & 0xF)   
													| val
													;

											TileMapData[addptr+0xd] = (char)(ByteToWrite & 0xFF);
											TileMapData[addptr+0xd+1] = (char)((ByteToWrite>>8) & 0xFF);

											//TileMapData[addptr+0x14] =  (char)((TileMapData[addptr+0x14] & 0xC0) | (char)(currobj.Projectile_Pitch & 0x3F));

											TileMapData[addptr+0x14] = (char) ( ( (currobj.Projectile_Sign << 7) & 0x1 ) |  ( (currobj.Projectile_Pitch & 0x3) << 4 ) | ( currobj.Projectile_Speed & 0xf )  );
														
											ByteToWrite=((currobj.npc_xhome & 0x3F)<<10) |
													((currobj.npc_yhome & 0x3F)<<4) |
													( TileMapData[addptr+0x16] & 0xf  ) ;
											TileMapData[addptr+0x16] = (char)(ByteToWrite & 0xFF);
											TileMapData[addptr+0x16+1] = (char)((ByteToWrite>>8) & 0xFF);


											ByteToWrite=(TileMapData[addptr+0x18] & 0xE0)
													|
													(currobj.npc_heading & 0x1F) ;
											TileMapData[addptr+0x18] = (char)(ByteToWrite & 0xFF);
											TileMapData[addptr+0x18+1] = (char)((ByteToWrite>>8) & 0xFF);


											TileMapData[addptr+0x19]= (char)(
													((currobj.npc_hunger & 0x3F)) 
											);

											TileMapData[addptr+0x1a]= (char)(
													((currobj.npc_whoami & 0xFF)) 
											);

											addptr=addptr+8+19;	
									}	
									else
									{													
											addptr=addptr+8;
									}
								}
						}	

				}


				addptr=0x7300;//mobile object list
				int f=0;
				for (int i=0; i<=GameWorldController.instance.objectList[thisLevelNo].NoOfFreeMobile; i++)
				{						
						int ByteToWrite= GameWorldController.instance.objectList[thisLevelNo].FreeMobileList[f];
						TileMapData[addptr] = (char)(ByteToWrite & 0xFF);
						TileMapData[addptr+1] = (char)((ByteToWrite>>8) & 0xFF);
						f++;
						addptr+=2;
				}

				addptr=0x74fc;//static object list
				f=0;
				for (int i=0; i<=GameWorldController.instance.objectList[thisLevelNo].NoOfFreeStatic; i++)
				{						
						int ByteToWrite= GameWorldController.instance.objectList[thisLevelNo].FreeStaticList[f];
						TileMapData[addptr] = (char)(ByteToWrite & 0xFF);
						TileMapData[addptr+1] = (char)((ByteToWrite>>8) & 0xFF);
						f++;
						addptr+=2;
				}

				//Now write the counts of free objects
				TileMapData[0x7c02] = (char)( GameWorldController.instance.objectList[thisLevelNo].NoOfFreeMobile & 0xFF);
				TileMapData[0x7c03] = (char)((GameWorldController.instance.objectList[thisLevelNo].NoOfFreeMobile>>8) & 0xFF);

				TileMapData[0x7c04] = (char)(GameWorldController.instance.objectList[thisLevelNo].NoOfFreeStatic & 0xFF);
				TileMapData[0x7c05] = (char)((GameWorldController.instance.objectList[thisLevelNo].NoOfFreeStatic>>8) & 0xFF);

			return TileMapData;
		}

		bool IsObjectFree(int index)
		{
				
				if (index<256)//mobile list
				{
						for (int i=2; i<=GameWorldController.instance.objectList[thisLevelNo].NoOfFreeMobile;i++)
						{
								if (index == GameWorldController.instance.objectList[thisLevelNo].FreeMobileList[i])
								{//obj is on free list
										return true;
								}
						}
				}
				else
				{//static
						for (int i=0; i<=GameWorldController.instance.objectList[thisLevelNo].NoOfFreeStatic;i++)
						{
							if (index == GameWorldController.instance.objectList[thisLevelNo].FreeStaticList[i])
							{//obj is on free list
									return true;
							}
						}
				}

				return false;
		}

		/// <summary>
		/// Converts the animation overlay data back to bytes
		/// </summary>
		/// <returns>The info to bytes.</returns>
		public char[] OverlayInfoToBytes()
		{
			char[] OverLayData= new char[64*6];	
			int OverlayAddress=0;
			for (int overlayIndex=0; overlayIndex<64; overlayIndex++ )
			{
				OverLayData[OverlayAddress+0]=(char)(Overlays[overlayIndex].index & 0xFF);
				OverLayData[OverlayAddress+1]=(char)((Overlays[overlayIndex].index>>8) & 0xFF);
				OverLayData[OverlayAddress+2]=(char)(Overlays[overlayIndex].unk1 & 0xFF);
				OverLayData[OverlayAddress+3]=(char)((Overlays[overlayIndex].unk1>>8) & 0xFF);
				OverLayData[OverlayAddress+4]=(char)(Overlays[overlayIndex].tileX & 0xFF);
				OverLayData[OverlayAddress+5]=(char)(Overlays[overlayIndex].tileY & 0xFF);
				OverlayAddress+=6;
			}
			return OverLayData;
		}


		/// <summary>
		/// Converts the uw1 texture map to bytes.
		/// </summary>
		/// <returns>The map to bytes.</returns>
		public char[] TextureMapToBytes()
		{
			char[] textureMapData=new char[122];
			short textureMapSize=64;
			int TextureMapAddress=0;
			for (int i=0; i<textureMapSize;i++)
			{
				if (i<48)	//Wall textures
				{
					textureMapData[TextureMapAddress+0]=(char)(texture_map[i] & 0xFF);
					textureMapData[TextureMapAddress+1]=(char)((texture_map[i]>>8) & 0xFF);
					TextureMapAddress+=2;
				}
				else if (i<=57)	//Floor textures are 49 to 56, ceiling is 57
				{
					textureMapData[TextureMapAddress+0]=(char)((texture_map[i]-210) & 0xFF);
					textureMapData[TextureMapAddress+1]=(char)(((texture_map[i]-210)>>8) & 0xFF);
					TextureMapAddress+=2;
				}
				else
				{ //door textures
					textureMapData[TextureMapAddress]= (char)(texture_map[i]);
					TextureMapAddress++;
				}						
			}

			return textureMapData;
		}


		/// <summary>
		/// Defines continous rooms regions.
		/// </summary>
		public void CreateRooms()
		{
			short RegionNo=1;
				//Reset room settings
			for (int y=TileMapSizeY; y>=0;y--)
			{
				for (int x=0; x<=TileMapSizeX;x++)
				{
					Tiles[x,y].roomRegion=0;
				}		
			}

			for (int y=TileMapSizeY; y>=0;y--)
			{
				for (int x=0; x<=TileMapSizeX;x++)
				{
				if (
					(Tiles[x,y].tileType!=TILE_SOLID)
				&& 
						(Tiles[x,y].roomRegion==0)
				)
				{//Tiles is open and room region is not set
					Tiles[x,y].roomRegion=RegionNo;
					fillRoomRegion(x,y, TileTerrainType(x,y) ,RegionNo)	;
					RegionNo++;
				}
			}
		}
		
		/*	if (false)
			{
					
			
			string output="";

			StreamWriter writer = new StreamWriter( Application.dataPath + "//..//_output.txt", true);
				for (int y=TileMapSizeY; y>=0;y--)
				{
					output +="\n";
					for (int x=0; x<=TileMapSizeX;x++)
					{
							output += Tiles[x,y].roomRegion.ToString("d3") + ",";
					}
			}
			writer.WriteLine(output);
			writer.Close();
			}*/

		}


		void fillRoomRegion(int startX, int startY, int terrainType,short RegionNo)
		{
			short thisTileHeight = Tiles[startX,startY].floorHeight;
			//Check in each direction
			for (int x=-1; x<=1; x++)
			{
				for (int y=-1; y<=1; y++)
				{
					if (
						((x==-1) && (y==0))
						||
						((x==1) && (y==0))
						||
						((x==0) && (y==-1))
						||
						((x==0) && (y==+1))
					)								
					{
						if (TileMap.ValidTile(startX+x,startY+y))	
						{
							if (
								(Tiles[startX+x,startY+y].tileType !=TILE_SOLID)
								&& 
								(Tiles[startX+x,startY+y].roomRegion==0)
								&& 
								(terrainType == TileTerrainType(startX+x,startY+y))
								&&
								(isTileOpenFromDirection(startX+x,startY+y, x, y))
								&&
								(
									( 
									(thisTileHeight >= Tiles[startX+x,startY+y].floorHeight-2 ) 
									&& 
									(thisTileHeight <= Tiles[startX+x,startY+y].floorHeight+2 )
									)
									||
									(
										(
										(Tiles[startX+x,startY+y].hasBridge) || (Tiles[startX,startY].hasBridge) 
										) 
										&& (terrainType==0)
									)
								)
							)
							{//Tiles is open and room region is not set and is a matching terrain type and does not drop down too far (unless it has a bridge and I'm testing for land)
								Tiles[startX+x,startY+y].roomRegion=RegionNo;	
								fillRoomRegion(startX+x,startY+y, terrainType ,RegionNo)	;
							}
						}
					}
				}	
			}
		}


		/// <summary>
		/// Terrain types for calculating room regions.
		/// </summary>
		/// <returns>The terrain type.</returns>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		int TileTerrainType(int x, int y)
		{
			if ((Tiles[x,y].isLand) || (Tiles[x,y].hasBridge))
			{
				return 0;	
			}
			else if (Tiles[x,y].isWater)
			{
				return 1;	
			}
			else if (Tiles[x,y].isLava)
			{
				return 2;	
			}
			else if (Tiles[x,y].isNothing)
			{
				return 3;
			}
			else
			{
				return 0;
			}
		}

		/// <summary>
		/// Determines if the tile is open (Ie no wall is in the way) from the specified direction. 
		/// </summary>
		/// <returns><c>true</c>, if tile open from direction was ised, <c>false</c> otherwise.</returns>
		/// <param name="X">X.</param>
		/// <param name="Y">Y.</param>
		/// <param name="directionX">Direction x.</param>
		/// <param name="directionY">Direction y.</param>
		bool isTileOpenFromDirection(int X, int Y, int directionX, int directionY)
		{
				switch (Tiles[X,Y].tileType)	
				{
				case TILE_OPEN:
				case TILE_SLOPE_N:
				case TILE_SLOPE_S:
				case TILE_SLOPE_E:
				case TILE_SLOPE_W:
						return true;
				case TILE_DIAG_NE:
						if ( (directionX==1) || (directionY==-1))
						{
							return true;	
						}
						break;
				case TILE_DIAG_NW:
						if ( (directionX==1) || (directionY==1))
						{
								return true;	
						}
						break;
				case TILE_DIAG_SE:
						if ( (directionX==-1) || (directionY==-1))
						{
								return true;	
						}
						break;
				case TILE_DIAG_SW:
						if ( (directionX==-1) || (directionY==1))
						{
								return true;	
						}
						break;
						
				default:
						return false;
				}
				return false;
		}


		public string getSignature()
		{
			string signature="";
			for (int x=0; x<TileMapSizeX; x++)
			{
				for (int y=0; y<TileMapSizeY; y++)
				{
					signature += Tiles[x,y].tileType.ToString() + Tiles[x,y].floorHeight.ToString();
				}		
			}
			return signature;
		}


		public int getTileAgentID(int tileX, int tileY)
		{
			if (Tiles[tileX,tileY].isWater)
			{
				return GameWorldController.instance.NavMeshWater.agentTypeID;
			}
			if (Tiles[tileX,tileY].isLava)
			{
				return GameWorldController.instance.NavMeshLava.agentTypeID;
			}
			return GameWorldController.instance.NavMeshLand.agentTypeID;
		}

	void BuildTextureMap (DataLoader.UWBlock tex_ark, ref short CeilingTexture, int LevelNo)
	{
			short textureMapSize;//=UW1_TEXTUREMAPSIZE;
			switch(_RES)
			{
			case GAME_UW2:
					textureMapSize=UW2_TEXTUREMAPSIZE;
					break;
			case GAME_UWDEMO:						
					textureMapSize=UWDEMO_TEXTUREMAPSIZE;
					break;
			default:
					textureMapSize=UW1_TEXTUREMAPSIZE;
					break;
			}
		int offset = 0;
		for (int i = 0; i < textureMapSize; i++)//256
		 {
			//TODO: Only use this for texture lookups.
			switch (UWEBase._RES) {
			case UWEBase.GAME_UWDEMO: {
				if (i < 48)//Wall textures
				 {
					texture_map [i] = (short)DataLoader.getValAtAddress (tex_ark, offset, 16);
					//(i * 2)
					offset = offset + 2;
				}
				else
					if (i <= 57)//Floor textures are 49 to 56, ceiling is 57
					 {
						texture_map [i] = (short)(DataLoader.getValAtAddress (tex_ark, offset, 16) + 48);
						//(i * 2)
						offset = offset + 2;
						if (i == 57) {
							CeilingTexture = (short)i;
						}
					}
					else {
						//door textures are int 8s
						texture_map [i] = (short)DataLoader.getValAtAddress (tex_ark, offset, 8);
						//+210; //(i * 1)
						offset++;
					}
				break;
			}
			case UWEBase.GAME_UW1: {
				if (i < 48)//Wall textures
				 {
					texture_map [i] = (short)DataLoader.getValAtAddress (tex_ark, offset, 16);
					offset = offset + 2;
				}
				else
					if (i <= 57)//Floor textures are 49 to 56, ceiling is 57
					 {
						texture_map [i] = (short)(DataLoader.getValAtAddress (tex_ark, offset, 16) + 210);
						offset = offset + 2;
						if (i == 57) {
							CeilingTexture = (short)i;
						}
					}
					else {
						//door textures are int 8s
						texture_map [i] = (short)DataLoader.getValAtAddress (tex_ark, offset, 8);
						//+210; //(i * 1)
						offset++;
					}
				break;
			}
			case UWEBase.GAME_UW2://uw2
			 {
					if (i < 64) {
						texture_map [i] = (short)DataLoader.getValAtAddress (tex_ark, offset, 16);
						//tmp //textureAddress+//(i*2)
						offset = offset + 2;
					}
					else {
						//door textures
						texture_map [i] = (short)DataLoader.getValAtAddress (tex_ark,offset, 8);
						//tmp //textureAddress+//(i*2)
						offset++;
					}
				}
				if (i == 0xf) {
					CeilingTexture = (short)i;
					//texture_map[i];
				}
				if ((LevelNo == (int)(GameWorldController.UW2_LevelNos.Ethereal4)) && (i == 16)) {
					//Not sure why this is an exceptional case!
					CeilingTexture = (short)i;
				}
				break;
			}
		}
	}
}