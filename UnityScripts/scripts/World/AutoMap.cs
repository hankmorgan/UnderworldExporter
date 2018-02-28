using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Text;
using System.IO;

public class AutoMap : Loader {

		//level tilemap. A valid value in the low nybble means the tile is displayed
		//on the map. Valid values are the same as tile types:
		//SOLID    0x0
		//CLEAR    0x1
		//Diagonal Tiles have a flat floor and are divided diagonally,
		//the direction of the wall normals is given as suffix to 'DIAG_'
		//DIAG_SE  0x2
		//DIAG_SW  0x3
		//DIAG_NE  0x4
		//DIAG_NW  0x5
		//Slope Tiles are treated like ordinary CLEAR tiles
		//SLOPE_N  0x6
		//SLOPE_S  0x7
		//SLOPE_E  0x8
		//SLOPE_W  0x9

		//These seem to be uw2 values!!
		//DEFAULT  0x0
		//DOOR     0x1
		//TELEPORT 0x3
		//WATER    0x4
		//BRIDGE   0x6
		//LAVA     0xc

		public const int DisplayTypeClear=0;  //uw1 + 2
		public const int DisplayTypeWaterUW1=1;
		public const int DisplayTypeWaterUW2=4;
		public const int DisplayTypeLava=2;
		public const int DisplayTypeDoorUW1=4;
		public const int DisplayTypeDoorUW2=1;
		public const int DisplayTypeBridge1UW1=9;
		public const int DisplayTypeBridge2UW1=10;
		public const int DisplayTypeBridgeUW2=6;
		public const int DisplayTypeStairUW1=12;
		public const int DisplayTypeStairUW2=3;

		public const int TILE_SOLID=0;
		public const int TILE_OPEN= 1;
		public const int TILE_DIAG_SE= 2;
		public const int TILE_DIAG_SW =3;
		public const int TILE_DIAG_NE =4;
		public const int TILE_DIAG_NW= 5;
		public const int TILE_SLOPE_N =6;
		public const int TILE_SLOPE_S= 7;
		public const int TILE_SLOPE_E= 8;
		public const int TILE_SLOPE_W= 9;
		public const int TILE_VALLEY_NW =10;
		public const int TILE_VALLEY_NE =11;
		public const int TILE_VALLEY_SE= 12;
		public const int TILE_VALLEY_SW =13;
		public const int TILE_RIDGE_SE =14;
		public const int TILE_RIDGE_SW =15;
		public const int TILE_RIDGE_NW= 16;
		public const int TILE_RIDGE_NE= 17;

		const int NORTH =0;
		const int SOUTH =1;
		const int EAST=2;
		const int WEST=3;
		const int NORTHWEST=4;
		const int NORTHEAST=5;
		const int SOUTHWEST=6;
		const int SOUTHEAST=7;



		/// <summary>
		/// The tile map size along the x axis
		/// </summary>
		public const int TileMapSizeX=63; //0 to 63

		/// <summary>
		/// The tile map size along the y axis.
		/// </summary>
		public const int TileMapSizeY=63; //0 to 63

		public struct AutoMapTile
		{
			public short DisplayType;
			public short tileType;//Or is is visted.
		};

		public int thisLevelNo; //The number of this level

		/// <summary>
		/// Tile info storage class
		/// </summary>
		public AutoMapTile[,] Tiles=new AutoMapTile[TileMap.TileMapSizeX+1,TileMap.TileMapSizeY+1];

		/// <summary>
		/// Player written Map notes stored in a list.
		/// </summary>
		public List<MapNote> MapNotes;

		/// <summary>
		/// The size of the tile in pixels in the map display
		/// </summary>
		public const int TileSize = 4;

		/// <summary>
		/// The open tile colour.
		/// </summary>
		/// RGB as follows
		/// 116,81,56
		/// 102,70,47
		/// 107,75,47
		public static Color[] OpenTileColour=new Color[3];

		/// <summary>
		/// The water tile colour.
		/// </summary>
		/// RGB as follows
		/// 62,61,134
		/// 50,51,115
		public static Color[] WaterTileColour=new Color[2];
		/// <summary>
		/// The lava tile colour.
		/// </summary>
		/// RGB is 
		/// 115,23,27
		/// 78,15,14
		public static Color[] LavaTileColour=new Color[2];

		/// <summary>
		/// The bridge tile colour.
		/// </summary>
		/// RGB is 
		/// 64,28,0
		/// 59,23,0
		/// 74,28,0
		public static Color[] BridgeTileColour=new Color[3];
		/// <summary>
		/// The stairs tile colour.
		/// </summary>
		/// RGB as follows
		/// 79,52,27
		/// 70,41,24
		public static Color[] StairsTileColour=new Color[2];
		/// <summary>
		/// Wall border colour.
		/// </summary>
		/// RBG is
		/// 66,41,22
		/// 93,60,37
		/// 98,65,42
		/// 88,56,33
		public static Color[] BorderColour = new Color[4];

		/// <summary>
		/// The background colour of the map.
		/// </summary>
		public static Color[] Background = new Color[1];


		/// <summary>
		/// The automap note addresses. These need to change dynamically.
		/// </summary>
		public static long[] AutomapNoteAddresses=new long[9];

	void ProcessAutomap (char[] lev_ark, long automapAddress)
	{
		int z = 0;
		for (int y = 0; y <= TileMap.TileMapSizeY; y++) {
			for (int x = 0; x <= TileMap.TileMapSizeX; x++) {
				short val = (short)DataLoader.getValAtAddress (lev_ark, automapAddress + z, 8);
				//The automap contains one byte per tile, in the same order as the
				//level tilemap. A valid value in the low nybble means the tile is displayed
				//on the map. Valid values are the same as tile types:
				Tiles [x, y].tileType = (short)(val & 0xf);
				Tiles [x, y].DisplayType = (short)((val >> 4) & 0xf);
				z++;
			}
		}
	}

	static void ProcessAutoMapNotes (int LevelNo, char[] lev_ark, long automapNotesAddress, long AUTOMAP_EOF_ADDRESS )
	{
		while (automapNotesAddress < AUTOMAP_EOF_ADDRESS) {
			string NoteText = "";
			bool terminated = false;
			int PosX = 0;
			int PosY = 0;
			PosX = (int)DataLoader.getValAtAddress (lev_ark, automapNotesAddress + 0x32, 16);
			PosY = (int)DataLoader.getValAtAddress (lev_ark, automapNotesAddress + 0x34, 16);
			for (int c = 0; c <= 0x31; c++) {
				if ((lev_ark [automapNotesAddress + c].ToString () != "\0") && (!terminated)) {
					NoteText += lev_ark [automapNotesAddress + c];
				}
				else {
					terminated = true;
				}
			}
			if (NoteText == "") {
				break;
			}
			if ((PosY <= 200) && (PosX <= 320)) {
				MapNote newmapnote = new MapNote ();
				newmapnote.PosX = PosX;
				newmapnote.PosY = PosY;
				//newmapnote.NotePosition=new Vector2((float)PosX,(float)PosY-100f);
				newmapnote.NoteText = NoteText;
				newmapnote.guid = System.Guid.NewGuid ();
				GameWorldController.instance.AutoMaps [LevelNo].MapNotes.Add (newmapnote);
			}
			else {
				break;
			}
			automapNotesAddress += 54;
		}
	}

		public void InitAutoMapDemo()
		{
			MapNotes = new List<MapNote>();
			thisLevelNo=0;	
		}

		public void InitAutoMapUW2(int LevelNo, char[] lev_ark)
		{
			//AutomapNoteAddresses=new long[72];
			MapNotes = new List<MapNote>();			
			thisLevelNo=LevelNo;

			int datalen=0;
			long automapAddress=0;
			long automapNotesAddress=0;
			//long AUTOMAP_EOF_ADDRESS=0;

			int NoOfBlocks=(int)DataLoader.getValAtAddress(lev_ark,0,32);	

			automapAddress = DataLoader.getValAtAddress(lev_ark,(LevelNo * 4) + 6 + (160*4),32);	
			
			//Load Automap info
			if (automapAddress!=0)
			{
				int compressionFlag=(int)DataLoader.getValAtAddress(lev_ark,(LevelNo * 4) + 6 + (160*4)+ (NoOfBlocks*4),32);
				if (((compressionFlag>>1) & 0x1) == 1)
				{//automap is compressed
					char[] tmp_ark = DataLoader.unpackUW2(lev_ark, automapAddress, ref datalen );
					ProcessAutomap (tmp_ark , 0);
				}
				else
				{
					ProcessAutomap (lev_ark , automapAddress);
				}				
			}
			

				automapNotesAddress = DataLoader.getValAtAddress(lev_ark,(LevelNo * 4) + 6 + (240*4),32);	
				if (automapNotesAddress!=0)
				{
					int compressionFlag=(int)DataLoader.getValAtAddress(lev_ark,(LevelNo * 4) + 6 + (240*4)+ (NoOfBlocks*4),32);	
					if (((compressionFlag>>1) & 0x1) == 1)
					{//automap is compressed
						char[] tmp_ark = DataLoader.unpackUW2(lev_ark, automapNotesAddress, ref datalen );
						ProcessAutoMapNotes(LevelNo, tmp_ark,0, datalen);
					}
					else
					{
						long nextautomapNotesAddress= lev_ark.GetUpperBound(0);
						if (LevelNo<72)
						{
							nextautomapNotesAddress = DataLoader.getValAtAddress(lev_ark,((LevelNo+1) * 4) + 6 + (240*4),32);			
						}
						Debug.Log("uncompressed automap notes " + LevelNo +  " at " + automapNotesAddress);
						ProcessAutoMapNotes(LevelNo, lev_ark, automapAddress, nextautomapNotesAddress)	;
					}
				}

		}

		/// <summary>
		/// Inits the automap from a uw1 lev.ark file.
		/// </summary>
		/// <param name="LevelNo">Level no.</param>
		/// <param name="lev_ark">Lev ark.</param>
		public void InitAutoMapUW1(int LevelNo, char[] lev_ark)
		{
			MapNotes = new List<MapNote>();
			thisLevelNo=LevelNo;
			long automapAddress=0;
			long automapNotesAddress=0;
			long AUTOMAP_EOF_ADDRESS=0;
				bool initAutoMaps=true;

				//The order the automap notes are saved on file is different from the order of the level nos.
				//Goes in order of when notes are added.
				for (int au=0; au<=AutomapNoteAddresses.GetUpperBound(0); au++)
				{
					AutomapNoteAddresses[au]=DataLoader.getValAtAddress(lev_ark,((au+36) * 4) + 2 ,32);
						if (AutomapNoteAddresses[au]!=0)
						{
								initAutoMaps=false;	
						}
				}

				automapAddress= DataLoader.getValAtAddress(lev_ark,((LevelNo+27) * 4) + 2 ,32);
				automapNotesAddress= DataLoader.getValAtAddress(lev_ark,((LevelNo+36) * 4) + 2 ,32);

				AUTOMAP_EOF_ADDRESS = getNextAutomapBlock(LevelNo,lev_ark);	
				if (initAutoMaps)
				{//No notes have been made yet Init with some dummy data.
						System.Guid guid = System.Guid.NewGuid();
						MapNote newmapnote = new MapNote();
						//newmapnote.NotePosition=pos;
						newmapnote.PosX= 0;
						newmapnote.PosY= 0;
						newmapnote.NoteText= LevelNo.ToString();
						newmapnote.guid=guid;
						MapNotes.Add(newmapnote);
				}

				//Load Automap info
				if (automapAddress!=0)
				{
					ProcessAutomap (lev_ark , automapAddress);
				}

				if ((automapNotesAddress!=0) && (AUTOMAP_EOF_ADDRESS<=lev_ark.GetUpperBound(0)))
				{
					ProcessAutoMapNotes (LevelNo, lev_ark, automapNotesAddress, AUTOMAP_EOF_ADDRESS);
				}
		}

		void WriteDebugMap()
		{
				StreamWriter writer = new StreamWriter( Application.dataPath + "//..//_automap_" + thisLevelNo + ".txt", false);	
				string output="";
				for (int y = TileMap.TileMapSizeY; y>=0; y--)
				{
						for (int x = 0; x<TileMap.TileMapSizeX; x++)
						{
								output+= Tiles[x,y].DisplayType + ",";
						}
						output+= "\n";
				}
				writer.Write(output);
				writer.Close();
		}


		/// <summary>
		/// Generates a tile map image for the automap for the specified level.
		/// </summary>
		/// <returns>The map image.</returns>
		/// <param name="LevelNo">Level no.</param>
		public Texture2D TileMapImage()
		{
				InitColours();

				if (_RES==GAME_UW2)
				{
						WriteDebugMap();
				}
				///Sets the map no display
				UWHUD.instance.LevelNoDisplay.text=(thisLevelNo+1).ToString();
				///Uses a cursor icon to display the player.
				Texture2D playerPosIcon;
				switch (_RES)
				{
				case GAME_UWDEMO:
					playerPosIcon =GameWorldController.instance.grCursors.LoadImageAt(10);//This is wrong but good enough for the moment.
					break;
				case GAME_UW1:
				default:
					playerPosIcon =GameWorldController.instance.grCursors.LoadImageAt(18);
					break;
				}


				///Creates a blank texture2D of 64x64*TileSize in ARGB32 format.
				Texture2D output= new Texture2D(64 * TileSize, 64 * TileSize, TextureFormat.ARGB32, false);
				output.filterMode=FilterMode.Point;
				output.wrapMode=TextureWrapMode.Clamp;
				//Init the tile map as blank first
				for (int i = 0; i<TileMap.TileMapSizeX; i++)
				{
						for (int j = TileMap.TileMapSizeY; j>0; j--)
						{
								DrawSolidTile(output,i,j,TileSize,TileSize,Background);
						}
				}

				///Fills in the tile background colour first
				for (int i = 0; i<TileMap.TileMapSizeX; i++)
				{
						for (int j = TileMap.TileMapSizeY; j>0; j--)
						{//If the tile has been visited and can be rendered.
								if ((GetTileRender(i,j)==1) && (GetTileVisited(i,j)))
								{
										//fillTile(LevelNo,output,i,j,TileSize,TileSize,Color.gray,Color.blue,Color.red, Color.cyan);
										fillTile(output,i,j,TileSize,TileSize,OpenTileColour,WaterTileColour,LavaTileColour,BridgeTileColour);
								}
						}
				}
				///Draws the border lines of the tiles
				for (int i = 0; i<TileMap.TileMapSizeX; i++)
				{
						for (int j = TileMap.TileMapSizeY; j>0; j--)
						{
								if (GetTileVisited( i,j)==true)
								{
										switch (GetTileType(i,j))
										{
										case TILE_SOLID://Solid
												{
														//DrawSolidTile(output,i,j,TileSize,TileSize,Color.clear);
														//output.SetPixel(i, j, Color.blackblack);
														break;
												}
										case TILE_OPEN://Open
										case TILE_SLOPE_E:
										case TILE_SLOPE_W:
										case TILE_SLOPE_S:
										case TILE_SLOPE_N:
												{
														DrawOpenTile(output,i,j,TileSize,TileSize,BorderColour);
														//output.SetPixel(i, j, Color.white);
														break;
												}
										case TILE_DIAG_NE:
												{
														//DrawLine (output,i,j,TileSize,TileSize,Color.black,NORTHEAST);
														DrawDiagNE(output,i,j,TileSize,TileSize,BorderColour);
														break;
												}
										case TILE_DIAG_SE:
												{
														//DrawLine (output,i,j,TileSize,TileSize,Color.black,SOUTHEAST);
														DrawDiagSE(output,i,j,TileSize,TileSize,BorderColour);
														break;
												}
										case TILE_DIAG_NW:
												{
														DrawDiagNW (output,i,j,TileSize,TileSize,BorderColour);
														break;
												}
										case TILE_DIAG_SW:
												{
														DrawDiagSW(output,i,j,TileSize,TileSize,BorderColour);
														break;
												}
										default:
												{
														//DrawSolidTile(output,i,j,TileSize,TileSize,Color.clear);
														//	output.SetPixel(i, j, Color.red);
														break;
												}
										}
								}
								else
								{
										DrawSolidTile(output,i,j,TileSize,TileSize,Background);
										//output.SetPixel(i, j, Color.clear);
								}
						}
				}

				for (int i = 0; i<TileMap.TileMapSizeX; i++)
				{
						for (int j = TileMap.TileMapSizeY; j>0; j--)
						{
								if (GetIsDoor(i,j)==true)			
								{
										if (GetTileVisited(i,j)==true)
										{
												DrawDoor(output,i,j,TileSize,TileSize,BorderColour);							
										}

								}
						}
				}


				///Only displays the player if they are on the same map as the one being rendered
				if (thisLevelNo==GameWorldController.instance.LevelNo)
				{
						Color[] defaultColour= playerPosIcon.GetPixels();
						if (UWEBase.EditorMode)
						{
								float ratioX = (IngameEditor.TileX * 1.2f) / (64.0f*1.2f);
								float ratioY = (IngameEditor.TileY * 1.2f) / (64.0f*1.2f);
								output.SetPixels((int)(output.width*ratioX), (int)(output.width*ratioY),playerPosIcon.width,playerPosIcon.height,defaultColour);	
						}
						else
						{
								float ratioX = UWCharacter.Instance.transform.position.x / (64.0f*1.2f);
								float ratioY = UWCharacter.Instance.transform.position.z / (64.0f*1.2f);
								output.SetPixels((int)(output.width*ratioX), (int)(output.width*ratioY),playerPosIcon.width,playerPosIcon.height,defaultColour);			
						}							
				}

			// Apply all SetPixel calls
			output.Apply();
			return  output;		
					
		}



		/// <summary>
		/// Fills in a single tile.
		/// </summary>
		/// <param name="LevelNo">Level no.</param>
		/// <param name="OutputTile">Output tile.</param>
		/// <param name="TileX">Tile x.</param>
		/// <param name="TileY">Tile y.</param>
		/// <param name="TileWidth">Tile width.</param>
		/// <param name="TileHeight">Tile height.</param>
		/// <param name="GroundColour">Ground colour.</param>
		/// <param name="WaterColour">Water colour.</param>
		/// <param name="LavaColour">Lava colour.</param>
		/// <param name="BridgeColour">Bridge colour.</param>
		private void fillTile(Texture2D OutputTile, int TileX, int TileY, int TileWidth, int TileHeight, Color[] GroundColour,Color[] WaterColour, Color[] LavaColour, Color[] BridgeColour )
		{
				Color[] TileColorPrimary;
				Color TileColorSecondary;
				///Picks which colour to use based on the tile properties.
				if (GetIsBridge(TileX,TileY)==true)
				{
						TileColorPrimary=BridgeColour;
						TileColorSecondary=Color.clear;	
				}
				else if (GetIsWater(TileX,TileY)==true)
				{
						TileColorPrimary=WaterColour;
						TileColorSecondary=Color.clear;
				}
				else if (GetIsLava(TileX,TileY) == true)
				{
						TileColorPrimary=LavaColour;
						TileColorSecondary=Color.clear;
				}
				else if (GetIsStair(TileX,TileY) == true)
				{
						TileColorPrimary=StairsTileColour;
						TileColorSecondary=Color.clear;
				}
				else
				{
						TileColorPrimary=GroundColour;
						TileColorSecondary=Color.clear;
				}
				switch(GetTileType(TileX,TileY))
				{
				case TILE_SOLID:
						{
								break;
						}	
				case TILE_DIAG_NE:
						{//Fills diagonally.
								for (int i = 0; i<=TileWidth;i++)
								{
										for (int j=0;j<=TileHeight;j++)
										{
												if (i>=TileHeight-j)
												{
														OutputTile.SetPixel(i+TileX*TileWidth,j+TileY*TileHeight,PickColour(TileColorPrimary));
												}
												else
												{
														OutputTile.SetPixel(i+TileX*TileWidth,j+TileY*TileHeight,TileColorSecondary);
												}
										}
								}
								break;
						}
				case TILE_DIAG_NW:
						{//Fills diagonally.
								for (int i = 0; i<=TileWidth;i++)
								{
										for (int j=0;j<=TileHeight;j++)
										{
												if (i<=j)
												{
														OutputTile.SetPixel(i+TileX*TileWidth,j+TileY*TileHeight,PickColour(TileColorPrimary));
												}
												else
												{
														OutputTile.SetPixel(i+TileX*TileWidth,j+TileY*TileHeight,TileColorSecondary);
												}
										}
								}
								break;
						}
				case TILE_DIAG_SE:
						{//Fills diagonally.	
								for (int i = 0; i<=TileWidth;i++)
								{
										for (int j=0;j<=TileHeight;j++)
										{
												if (i>=j)
												{
														OutputTile.SetPixel(i+TileX*TileWidth,j+TileY*TileHeight,PickColour(TileColorPrimary));
												}
												else
												{
														OutputTile.SetPixel(i+TileX*TileWidth,j+TileY*TileHeight,TileColorSecondary);
												}
										}
								}
								break;
						}
				case TILE_DIAG_SW:
						{//Fills diagonally.
								for (int i = 0; i<=TileWidth;i++)
								{
										for (int j=0;j<=TileHeight;j++)
										{
												if (TileWidth-i>=j)
												{
														OutputTile.SetPixel(i+TileX*TileWidth,j+TileY*TileHeight,PickColour(TileColorPrimary));
												}
												else
												{
														OutputTile.SetPixel(i+TileX*TileWidth,j+TileY*TileHeight,TileColorSecondary);
												}
										}
								}
								break;
						}
				case TILE_OPEN:
				case TILE_SLOPE_E:
				case TILE_SLOPE_N:
				case TILE_SLOPE_S:
				case TILE_SLOPE_W:
						{//Fills an open tile.
								DrawSolidTile(OutputTile,TileX,TileY,TileWidth,TileHeight,TileColorPrimary);
								break;
						}
				default:
						{//Does not draw anything.
								DrawSolidTile(OutputTile,TileX,TileY,TileWidth,TileHeight,Background);
								break;
						}
				}

		}


		/// <summary>
		/// Draws a solid tile with no border.
		/// </summary>
		/// <param name="OutputTile">Output tile.</param>
		/// <param name="TileX">Tile x.</param>
		/// <param name="TileY">Tile y.</param>
		/// <param name="TileWidth">Tile width.</param>
		/// <param name="TileHeight">Tile height.</param>
		/// <param name="InputColour">Input colour.</param>
		private void DrawSolidTile(Texture2D OutputTile, int TileX, int TileY, int TileWidth, int TileHeight, Color[] InputColour)
		{
				for (int i = 0; i<TileWidth; i++)
				{
						for (int j=0; j<TileHeight;j++)
						{
								OutputTile.SetPixel(i+ TileX * TileWidth, j+ TileY * TileHeight,PickColour(InputColour));
						}
				}

		}

		/// <summary>
		/// Draws the open tile. Checks the neighbouring tiles to see if it needs to draw a border.
		/// </summary>
		/// <param name="LevelNo">Level no.</param>
		/// <param name="OutputTile">Output tile.</param>
		/// <param name="TileX">Tile x.</param>
		/// <param name="TileY">Tile y.</param>
		/// <param name="TileWidth">Tile width.</param>
		/// <param name="TileHeight">Tile height.</param>
		/// <param name="InputColour">Input colour.</param>
		private void DrawOpenTile(Texture2D OutputTile, int TileX, int TileY, int TileWidth, int TileHeight, Color[] InputColour)
		{
				//Check the tile to the north
				if (TileY<TileMap.TileMapSizeY)
				{
						//if ((GetTileType( TileX,TileY+1)==TILE_SOLID) && (GetTileRender( TileX,TileY+1)==1))
						if ((GetTileType( TileX,TileY+1)==TILE_SOLID))
						{//Solid tile to the north.
								DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,NORTH);
						}
				}
				//Check the tile to the south
				if (TileY>0)
				{
						//if ((GetTileType( TileX,TileY-1)==TILE_SOLID) && (GetTileRender(TileX,TileY-1)==1))
						if ((GetTileType( TileX,TileY-1)==TILE_SOLID))
						{//Solid tile to the south.
								DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,SOUTH);
						}
				}
				//Check the tile to the east
				if (TileX <TileMap.TileMapSizeX)
				{
						//if ((GetTileType( TileX+1,TileY)==TILE_SOLID) && (GetTileRender( TileX+1,TileY)==1))
						if ((GetTileType( TileX+1,TileY)==TILE_SOLID))
						{
								DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,EAST);
						}
				}
				//Check the tile to the west
				if (TileX >0)
				{
					//	if ((GetTileType( TileX-1,TileY)==TILE_SOLID) && (GetTileRender( TileX-1,TileY)==1))
						if ((GetTileType( TileX-1,TileY)==TILE_SOLID) )
						{
								DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,WEST);
						}
				}
		}

		/// <summary>
		///  Draws a door at the tile specified. Checks the neighbouring tiles to find out which one is open
		/// </summary>
		/// <param name="OutputTile">Output tile.</param>
		/// <param name="LevelNo">Level no.</param>
		/// <param name="TileX">Tile x.</param>
		/// <param name="TileY">Tile y.</param>
		/// <param name="TileWidth">Tile width.</param>
		/// <param name="TileHeight">Tile height.</param>
		/// <param name="InputColour">Input colour.</param>
		private void DrawDoor(Texture2D OutputTile,  int TileX, int TileY, int TileWidth, int TileHeight, Color[] InputColour)
		{
				bool TileTypeNorth = isTileOpen(GetTileType(TileX,TileY+1));
				bool TileTypeSouth = isTileOpen(GetTileType(TileX,TileY-1));
				bool TileTypeEast = isTileOpen(GetTileType(TileX+1,TileY));
				bool TileTypeWest = isTileOpen(GetTileType(TileX-1,TileY));

				if (isTileOpen(GetTileType(TileX,TileY)))
				{	//Don't display if the door is currently in a solid tile
						if ((TileTypeEast) || (TileTypeWest))
						{
								for (int j = 0; j<TileHeight; j++)
								{
										OutputTile.SetPixel(TileWidth/2 + TileX * (TileWidth), j+ TileY * TileHeight,PickColour(InputColour));			
								}
						}
						else if ((TileTypeNorth)|| (TileTypeSouth))
						{
								for (int i = 0; i<TileWidth; i++)
								{
										OutputTile.SetPixel(i+ TileX * TileWidth, TileHeight/2 + TileY * TileHeight,PickColour(InputColour));
								}
						}
				}
		}

		/// <summary>
		/// Draws a line at the specified border direction.
		/// </summary>
		/// <param name="OutputTile">Output tile.</param>
		/// <param name="TileX">Tile x.</param>
		/// <param name="TileY">Tile y.</param>
		/// <param name="TileWidth">Tile width.</param>
		/// <param name="TileHeight">Tile height.</param>
		/// <param name="InputColour">Input colour.</param>
		/// <param name="Direction">The position on the tile where the border has to be drawn.</param>
		private void DrawLine(Texture2D OutputTile, int TileX, int TileY, int TileWidth, int TileHeight, Color[] InputColour, int Direction)
		{
				switch (Direction)
				{
				case NORTH:
						{//Border to the north.
								for (int i = 0; i<TileWidth; i++)
								{
										OutputTile.SetPixel(i+ TileX * TileWidth, TileHeight + TileY * TileHeight,PickColour(InputColour));
								}
								break;
						}
				case SOUTH:
						{//Border to the south.
								for (int i = 0; i<TileWidth; i++)
								{
										OutputTile.SetPixel(i+ TileX * TileWidth, 0 + TileY * TileHeight,PickColour(InputColour));
								}
								break;
						}
				case EAST:
						{//Border to the east.
								for (int j=0; j<TileHeight;j++)
								{
										OutputTile.SetPixel(TileWidth + TileX * TileWidth, j+ TileY * TileHeight,PickColour(InputColour));
								}
								break;
						}
				case WEST:
						{//Border to the west.
								for (int j=0; j<TileHeight;j++)
								{
										OutputTile.SetPixel(0+ TileX * TileWidth, j+ TileY * TileHeight,PickColour(InputColour));
								}
								break;
						}
				case NORTHEAST:
						{//Diagonal
								for (int k=0; k<=TileHeight; k++)
								{
										OutputTile.SetPixel((TileWidth-k)+ TileX * TileWidth, k+ TileY * TileHeight,PickColour(InputColour));
								}
								break;
						}
				case SOUTHWEST:
						{//Diagonal
								for (int k=0; k<=TileWidth; k++)
								{
										OutputTile.SetPixel(k+ TileX * TileWidth, (TileHeight-k)+ TileY * TileHeight,PickColour(InputColour));
								}
								break;
						}
				case NORTHWEST:
						{//Diagonal
								for (int k=0; k<=TileWidth; k++)
								{
										OutputTile.SetPixel(k+ TileX * TileWidth, k+ TileY * TileHeight,PickColour(InputColour));
								}
								break;
						}
				case SOUTHEAST:
						{//Diagonal
								for (int k=0; k<=TileWidth; k++)
								{
										OutputTile.SetPixel(k+ TileX * TileWidth, k+ TileY * TileHeight,PickColour(InputColour));
								}
								break;
						}
				}
		}

		/// <summary>
		/// Draws a diagonal SW tile.
		/// </summary>
		/// <param name="LevelNo">Level no.</param>
		/// <param name="OutputTile">Output tile.</param>
		/// <param name="TileX">Tile x.</param>
		/// <param name="TileY">Tile y.</param>
		/// <param name="TileWidth">Tile width.</param>
		/// <param name="TileHeight">Tile height.</param>
		/// <param name="InputColour">Input colour.</param>
		void DrawDiagSW(Texture2D OutputTile, int TileX, int TileY, int TileWidth, int TileHeight, Color[] InputColour)
		{
				DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,SOUTHWEST);

				//Check the tiles to the north and east of this tile to see what needs to be drawn for borders
				if (TileY <TileMap.TileMapSizeY)
				{//north
						int TileToTest = GetTileType(TileX,TileY+1);
						if ((isTileOpen(TileToTest))||(TileToTest==TILE_DIAG_SW))
						{
								DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,NORTH);
						}
				}
				if (TileX <TileMap.TileMapSizeX)
				{//east
						int TileToTest = GetTileType(TileX+1,TileY);
						if ((isTileOpen(TileToTest))||(TileToTest==TILE_DIAG_SW))
						{
								DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,EAST);
						}
				}

				//Check South and East for solids.
				if (TileY>0)
				{//South
						if (GetTileType (TileX,TileY-1)== TILE_SOLID)
						{
								DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,SOUTH);
						}
				}

				if (TileX>0)
				{//West
						if (GetTileType (TileX-1,TileY)== TILE_SOLID)
						{
								DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,WEST);
						}
				}

		}

		/// <summary>
		/// Draws the diag NE tile.
		/// </summary>
		/// <param name="LevelNo">Level no.</param>
		/// <param name="OutputTile">Output tile.</param>
		/// <param name="TileX">Tile x.</param>
		/// <param name="TileY">Tile y.</param>
		/// <param name="TileWidth">Tile width.</param>
		/// <param name="TileHeight">Tile height.</param>
		/// <param name="InputColour">Input colour.</param>
		void DrawDiagNE(Texture2D OutputTile, int TileX, int TileY, int TileWidth, int TileHeight, Color[] InputColour)
		{
				DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,NORTHEAST);

				//Check the tiles to the south and west of this tile to see what needs to be drawn.
				if (TileY >0)
				{//South
						int TileToTest = GetTileType(TileX,TileY-1);
						if ((isTileOpen(TileToTest))||(TileToTest==TILE_DIAG_NE))
						{
								DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,SOUTH);
						}
				}
				if (TileX >0)
				{//West
						int TileToTest = GetTileType(TileX-1,TileY);
						if ((isTileOpen(TileToTest))||(TileToTest==TILE_DIAG_NE))
						{
								DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,WEST);
						}
				}

				//Check North and East for solids.
				if (TileY<TileMap.TileMapSizeY)
				{//North
						if (GetTileType (TileX,TileY+1)== TILE_SOLID)
						{
								DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,NORTH);
						}
				}

				if (TileX<TileMap.TileMapSizeX)
				{//East
						if (GetTileType (TileX+1,TileY)== TILE_SOLID)
						{
								DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,EAST);
						}
				}

		}

		/// <summary>
		/// Draws the diag NW tile
		/// </summary>
		/// <param name="LevelNo">Level no.</param>
		/// <param name="OutputTile">Output tile.</param>
		/// <param name="TileX">Tile x.</param>
		/// <param name="TileY">Tile y.</param>
		/// <param name="TileWidth">Tile width.</param>
		/// <param name="TileHeight">Tile height.</param>
		/// <param name="InputColour">Input colour.</param>
		void DrawDiagNW(Texture2D OutputTile, int TileX, int TileY, int TileWidth, int TileHeight, Color[] InputColour)
		{
				DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,NORTHWEST);

				//Check the tiles to the south and east of this tile
				if (TileY >0)
				{//South
						int TileToTest = GetTileType(TileX,TileY-1);
						if ((isTileOpen(TileToTest))||(TileToTest==TILE_DIAG_NW))
						{
								DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,SOUTH);
						}
				}
				if (TileX <TileMap.TileMapSizeX)
				{//East
						int TileToTest = GetTileType(TileX+1,TileY);
						if ((isTileOpen(TileToTest))||(TileToTest==TILE_DIAG_NW))
						{
								DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,EAST);
						}
				}

				//Check North and West for solids.
				if (TileY<TileMap.TileMapSizeY)
				{//North
						if (GetTileType (TileX,TileY+1)== TILE_SOLID)
						{
								DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,NORTH);
						}
				}

				if (TileX>0)
				{//West
						if (GetTileType (TileX-1,TileY)== TILE_SOLID)
						{
								DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,WEST);
						}
				}
		}

		/// <summary>
		/// Draws the diag SE tile.
		/// </summary>
		/// <param name="LevelNo">Level no.</param>
		/// <param name="OutputTile">Output tile.</param>
		/// <param name="TileX">Tile x.</param>
		/// <param name="TileY">Tile y.</param>
		/// <param name="TileWidth">Tile width.</param>
		/// <param name="TileHeight">Tile height.</param>
		/// <param name="InputColour">Input colour.</param>
		void DrawDiagSE(Texture2D OutputTile, int TileX, int TileY, int TileWidth, int TileHeight, Color[] InputColour)
		{
				DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,SOUTHEAST);

				//Check the tiles to the north and west of this tile
				if (TileY <TileMap.TileMapSizeY)
				{//north
						int TileToTest = GetTileType(TileX,TileY+1);
						if ((isTileOpen(TileToTest))||(TileToTest==TILE_DIAG_SE))
						{
								DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,NORTH);
						}
				}

				if (TileX >0)
				{//West
						int TileToTest = GetTileType(TileX-1,TileY);
						if ((isTileOpen(TileToTest))||(TileToTest==TILE_DIAG_SE))
						{
								DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,WEST);
						}
				}

				//Check South and East for solids.
				if (TileY>0)
				{//South
						if (GetTileType (TileX,TileY-1)== TILE_SOLID)
						{
								DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,SOUTH);
						}
				}

				if (TileX<TileMap.TileMapSizeX)
				{//East
						if (GetTileType (TileX+1,TileY)== TILE_SOLID)
						{
								DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,EAST);
						}
				}
		}

		/// <summary>
		/// Picks a random colour from the array of colours
		/// </summary>
		/// <returns>The colour selected</returns>
		/// <param name="Selection">Selection.</param>
		public Color PickColour(Color[] Selection)
		{
				return Selection[Random.Range(0,Selection.GetUpperBound(0)+1)];
		}



		/// <summary>
		/// Inits the colours for the players map ui
		/// </summary>
		void InitColours()
		{

				/// RGB as follows
				/// 116,81,56
				/// 102,70,47
				/// 107,75,47
				OpenTileColour[0].r=116f/255f;OpenTileColour[0].g=81f/255f;OpenTileColour[0].b=56f/255f;OpenTileColour[0].a=1f;
				OpenTileColour[1].r=102f/255f;OpenTileColour[1].g=70f/255f;OpenTileColour[1].b=47f/255f;OpenTileColour[1].a=1f;
				OpenTileColour[2].r=107f/255f;OpenTileColour[2].g=75f/255f;OpenTileColour[2].b=47f/255f;OpenTileColour[2].a=1f;

				/// <summary>
				/// The water tile colour.
				/// </summary>
				/// RGB as follows
				/// 62,61,134
				/// 50,51,115
				WaterTileColour[0].r=62f/255f;WaterTileColour[0].g=61f/255f;WaterTileColour[0].b=134f/255f;WaterTileColour[0].a=1f;
				WaterTileColour[1].r=50f/255f;WaterTileColour[1].g=51f/255f;WaterTileColour[1].b=115f/255f;WaterTileColour[1].a=1f;

				/// <summary>
				/// The lava tile colour.
				/// </summary>
				/// RGB is 
				/// 115,23,27
				/// 78,15,14
				LavaTileColour[0].r=115f/255f;LavaTileColour[0].g=23f/255f;LavaTileColour[0].b=27f/255f;LavaTileColour[0].a=1f;
				LavaTileColour[1].r=78f/255f;LavaTileColour[1].g=15f/255f;LavaTileColour[1].b=14f/255f;LavaTileColour[1].a=1f;

				/// <summary>
				/// The bridge tile colour.
				/// </summary>
				/// RGB is 
				/// 64,28,0
				/// 59,23,0
				/// 74,28,0
				BridgeTileColour[0].r=64f/255f;BridgeTileColour[0].g=28f/255f;BridgeTileColour[0].b=0f/255f;BridgeTileColour[0].a=1f;
				BridgeTileColour[1].r=59f/255f;BridgeTileColour[1].g=23f/255f;BridgeTileColour[1].b=0f/255f;BridgeTileColour[1].a=1f;
				BridgeTileColour[2].r=74f/255f;BridgeTileColour[2].g=28f/255f;BridgeTileColour[2].b=0f/255f;BridgeTileColour[2].a=1f;
				/// <summary>
				/// The stairs tile colour.
				/// </summary>
				/// RGB as follows
				/// 79,52,27
				/// 70,41,24
				StairsTileColour[0].r=79f/255f;StairsTileColour[0].g=52f/255f;StairsTileColour[0].b=27f/255f;StairsTileColour[0].a=1f;
				StairsTileColour[1].r=70f/255f;StairsTileColour[1].g=41f/255f;StairsTileColour[1].b=24f/255f;StairsTileColour[1].a=1f;
				/// <summary>
				/// Wall border colour.
				/// </summary>
				/// RBG is
				/// 66,41,22
				/// 93,60,37
				/// 98,65,42
				/// 88,56,33
				BorderColour[0].r=66f/255f;BorderColour[0].g=41f/255f;BorderColour[0].b=22f/255f;BorderColour[0].a=1f;
				BorderColour[1].r=93f/255f;BorderColour[1].g=60f/255f;BorderColour[1].b=37f/255f;BorderColour[1].a=1f;
				BorderColour[2].r=98f/255f;BorderColour[2].g=65f/255f;BorderColour[2].b=42f/255f;BorderColour[2].a=1f;
				BorderColour[3].r=88f/255f;BorderColour[3].g=56f/255f;BorderColour[3].b=33f/255f;BorderColour[3].a=1f;



		}


	/// <summary>
	/// Gets the tile render state. Only affects the automap.
	/// </summary>
	/// <returns>The tile render.</returns>
	/// <param name="LevelNo">Level no.</param>
	/// <param name="tileX">Tile x.</param>
	/// <param name="tileY">Tile y.</param>
	private int GetTileRender( int tileX, int tileY)
	{
		return 1;
		//return Tiles[tileX,tileY].Render;
	}


		/// <summary>
		/// Has the tile been already visited.
		/// </summary>
		/// <returns><c>true</c>, if tile visited was gotten, <c>false</c> otherwise.</returns>
		/// <param name="LevelNo">Level no.</param>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
		private bool GetTileVisited(int tileX, int tileY)
		{
			if (UWEBase.EditorMode==true)
			{
				return true;
			}
			else
			{
				switch (Tiles[tileX,tileY].tileType)
				{
				case TILE_SOLID:
						return false;
				default:
						return true;
				}
			}
		}

		/// <summary>
		/// Gets the type of the tile.
		/// </summary>
		/// <returns>The tile type.</returns>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
		public int GetTileType(int tileX, int tileY)
		{
			if ((tileX>TileMap.TileMapSizeX) || (tileY>TileMap.TileMapSizeY) || (tileX<0) || (tileY<0))
			{//Assume out of bounds is solid
				return TILE_SOLID;
			}
			else
			{
					if ((Tiles[tileX,tileY].tileType==10) && (IngameEditor.EditorMode==false))
					{
						return TILE_SOLID;
					}
					else
					{
						return Tiles[tileX,tileY].tileType;
					}
				
			}			
		}



		/// <summary>
		/// Gets if the tile contains a door.
		/// </summary>
		/// <returns><c>true</c>, if is door was gotten, <c>false</c> otherwise.</returns>
		/// <param name="LevelNo">Level no.</param>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
		private bool GetIsDoor(int tileX, int tileY)
		{
			switch(_RES)
			{
			case GAME_UW2:
					return (Tiles[tileX,tileY].DisplayType==DisplayTypeDoorUW2);
			default:
					return (Tiles[tileX,tileY].DisplayType==DisplayTypeDoorUW1);
			}			
		}


		/// <summary>
		/// Is the tile water.
		/// </summary>
		/// <returns><c>true</c>, if is water was gotten, <c>false</c> otherwise.</returns>
		/// <param name="LevelNo">Level no.</param>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
		private bool GetIsWater(int tileX, int tileY)
		{
				switch(_RES)
				{
					case GAME_UW2:
						return Tiles[tileX,tileY].DisplayType==DisplayTypeWaterUW2;
					default:
						return Tiles[tileX,tileY].DisplayType==DisplayTypeWaterUW1;
				}

		}

		/// <summary>
		/// Is the tile Lava
		/// </summary>
		/// <returns><c>true</c>, if is lava was gotten, <c>false</c> otherwise.</returns>
		/// <param name="LevelNo">Level no.</param>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
		private bool GetIsLava(int tileX, int tileY)
		{
			return Tiles[tileX,tileY].DisplayType==DisplayTypeLava;
		}

		/// <summary>
		/// Gets if the tile is a bridge.
		/// </summary>
		/// <returns><c>true</c>, if is bridge was gotten, <c>false</c> otherwise.</returns>
		/// <param name="LevelNo">Level no.</param>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
		private bool GetIsBridge(int tileX, int tileY)
		{
				switch(_RES)
				{
				case GAME_UW2:
						return Tiles[tileX,tileY].DisplayType==DisplayTypeBridgeUW2;
				default:
					return (Tiles[tileX,tileY].DisplayType==DisplayTypeBridge1UW1 || Tiles[tileX,tileY].DisplayType==DisplayTypeBridge2UW1);
				}
			
		}


		/// <summary>
		/// Gets if the tile contains a stair.
		/// </summary>
		/// <returns><c>true</c>, if is stair was gotten, <c>false</c> otherwise.</returns>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
		private bool GetIsStair(int tileX, int tileY)
		{
			switch(_RES)
			{
			case GAME_UW2:
				return Tiles[tileX,tileY].DisplayType==DisplayTypeStairUW2;
			default:
				return Tiles[tileX,tileY].DisplayType==DisplayTypeStairUW1;			
			}			
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
		/// Marks the tile as visited and checks if it is in range.
		/// </summary>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
		public void MarkTile(int tileX, int tileY, int Mark, int DisplayType)
		{
			if (((tileX>=0) && (tileX<=TileMap.TileMapSizeX)) 
					&& 
					((tileY>=0) && (tileY<=TileMap.TileMapSizeY)))
			{
				Tiles[tileX,tileY].tileType=(short)Mark;
				switch(_RES)
				{
				case GAME_UW2:
					if (Tiles[tileX,tileY].DisplayType!=DisplayTypeStairUW2)
					{
						Tiles[tileX,tileY].DisplayType=(short)DisplayType;				
					}
					break;
				default:
					if (Tiles[tileX,tileY].DisplayType!=DisplayTypeStairUW1)
					{
						Tiles[tileX,tileY].DisplayType=(short)DisplayType;				
					}
					break;
				}			
			}
		}

		/// <summary>
		/// Marks the tile as visited and checks if it is in range.
		/// </summary>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
		public void MarkTileDisplayType(int tileX, int tileY, int DisplayType)
		{
			if (((tileX>=0) && (tileX<=TileMap.TileMapSizeX)) 
					&& 
					((tileY>=0) && (tileY<=TileMap.TileMapSizeY)))
			{
			Tiles[tileX,tileY].DisplayType=(short)DisplayType;	
			}
		}

		/// <summary>
		/// Gets the display type that the passed tile should have based on it's properties
		/// </summary>
		/// <returns>The display type.</returns>
		/// <param name="t">T.</param>
		/// TODO:Update for UW2
		public static int GetDisplayType ( TileInfo t)
		{
				if (t.hasBridge)
				{
						switch(_RES)
						{
						case GAME_UW2:
							return DisplayTypeBridgeUW2;
						default:
							return DisplayTypeBridge1UW1;
						}
					
				}
				else if (t.isWater)
				{
					switch(_RES)
					{
					case GAME_UW2:
						return DisplayTypeWaterUW2;
					default:
						return DisplayTypeWaterUW1;
					}
					
				}
				else if(t.isLava)
				{
					return DisplayTypeLava;
				}
				else if (t.isDoor)
				{
					switch(_RES)
					{

						case GAME_UW2:
							return DisplayTypeDoorUW2;
						default:
							return DisplayTypeDoorUW1;
					}					
				}
				else
				{
					return DisplayTypeClear;
				}
		}

		/*public static long GetFirstAutomapAddress()
		{
				long min=AutomapNoteAddresses[0];
				for (int i=0; i<=AutomapNoteAddresses.GetUpperBound(0);i++)
				{
						if (AutomapNoteAddresses[i]<min)
						{
								min = AutomapNoteAddresses[i];
						}
				}
				return min;
		}*/



		public static long getNextAutomapBlock(int thisLevelNo, char[] lev_ark)
		{//UW does not store map notes in order. In order to find the proper length of an automap note block I need to find the minimum next block address

			long thisAddress = AutomapNoteAddresses[thisLevelNo];
			long selectedAddress=lev_ark.GetUpperBound(0);
			for (int i=0; i<=AutomapNoteAddresses.GetUpperBound(0); i++)
			{
				if (AutomapNoteAddresses[i]> thisAddress)	
				{
					if (selectedAddress> AutomapNoteAddresses[i])
					{
						selectedAddress=AutomapNoteAddresses[i];
					}
				}
			}
			return selectedAddress;
		}


		public char[] AutoMapVisitedToBytes()
		{				
				char[] AutoMapData= new char[(TileMapSizeX+1)*(TileMapSizeY+1)];	
				int add_ptr=0;
				for (int y=0; y<=TileMap.TileMapSizeY;y++)
				{
						for (int x=0; x<=TileMap.TileMapSizeX;x++)
						{														
								int val ;//= (short)DataLoader.getValAtAddress(lev_ark,automapAddress+z,8);
								//The automap contains one byte per tile, in the same order as the
								//level tilemap. A valid value in the low nybble means the tile is displayed
								//on the map. Valid values are the same as tile types:
								val = Tiles[x,y].DisplayType<<4 | Tiles[x,y].tileType;
								AutoMapData[add_ptr]=(char)val;
								add_ptr++;
						}
				}

				return AutoMapData;
		}

		public char[] AutoMapNotesToBytes()
		{
				//return null;
				//char[] TileMapData= new char[TileMapSizeX*TileMapSizeY];	
				if (MapNotes.Count>0)
				{
						int add_ptr=0;
						char[] AutoMapData=new char[MapNotes.Count * 54];	
						foreach (MapNote note in MapNotes)
						{
								bool terminated=false;
							for (int i=0; i<54;i++)	
							{
								if (i<=0x31)
								{
									if (i<note.NoteText.Length)
									{//Lower case notes will crash the game
										char alpha =note.NoteText.ToUpper().ToCharArray()[i];	
										AutoMapData[add_ptr+i]=alpha;
									}		
									else
									{
										if (terminated)
										{//0x6f
												AutoMapData[add_ptr+i]=(char)0x6f;	
										}
										else
										{
												AutoMapData[add_ptr+i]=(char)0;
												terminated=true;
										}										
									}
								}
								else
								{
									switch (i)
									{
									case 0x32:
										{
											int val= note.PosX;
											AutoMapData[add_ptr+i]=(char)(val & 0xFF);
											AutoMapData[add_ptr+i+1]=(char)((val>>8) & 0xFF);
											break;
										}
									case 0x34:
										{
											int val= note.PosY;
											AutoMapData[add_ptr+i]=(char)(val & 0xFF);
											AutoMapData[add_ptr+i+1]=(char)((val>>8) & 0xFF);
											break;
										}
									}
								}
							}
							add_ptr+=54;
						}
					return AutoMapData;
				}
				else
				{
					return null;	
				}
					
		}

}