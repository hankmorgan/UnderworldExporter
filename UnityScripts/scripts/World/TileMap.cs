using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Text;
using System.IO;

/// <summary>
/// Tile map class.
/// Used for storing tile properties for use in various other scripts and generating the automap.
/// Tile properties are read in from a text file called [UW1|UW2|Shock]_tileprops.txt
/// </summary>
public class TileMap  {
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

		public const int SURFACE_FLOOR =1;
		public const int SURFACE_CEIL = 2;
		public const int SURFACE_WALL = 3;
		public const int SURFACE_SLOPE = 4;

		const int SLOPE_BOTH_PARALLEL= 0;
		const int SLOPE_BOTH_OPPOSITE= 1;
		const int SLOPE_FLOOR_ONLY =2;
		const int  SLOPE_CEILING_ONLY= 3;

		//Visible faces indices
		const int vTOP =0;
		const int vEAST =1;
		const int vBOTTOM= 2;
		const int vWEST= 3;
		const int vNORTH= 4;
		const int vSOUTH= 5;


		//BrushFaces
		const int fSELF =128;
		const int fCEIL= 64;
		const int fNORTH =32;
		const int fSOUTH =16;
		const int fEAST= 8;
		const int fWEST= 4;
		const int fTOP =2;
		const int fBOTTOM= 1;




		public int thisLevelNo; //The number of this level
		public int UW_CEILING_HEIGHT;
		public int CEILING_HEIGHT;
		public int[] texture_map = new int[256];


		/// <summary>
		/// Tile info storage class
		/// </summary>
	public TileInfo[,] Tiles=new TileInfo[64,64];

		/// <summary>
		/// The height of the max ceiling value for this level. Only used in SHOCK moving platform.
		/// </summary>
	public int GlobalCeilingHeight = 32;

	
		/// <summary>
		/// Player written Map notes stored in a list.
		/// </summary>
	public List<MapNote> MapNotes;

	
	/// <summary>
	/// The size of the tile in pixels in the map display
	/// </summary>
	public int TileSize = 4;



		/// <summary>
		/// The current tile X that the player is in
		/// </summary>
	public static int visitTileX;
		/// <summary>
		/// The current tile Y that the player is in.
		/// </summary>
	public static int visitTileY;
		/// <summary>
		/// Is the player currently standing on solid ground
		/// </summary>
	public static bool OnGround=false;
		/// <summary>
		/// Is the player currently standing(swimming) on water
		/// </summary>
	public static bool OnWater=false;
		/// <summary>
		/// Is the player currently standing on lava.
		/// </summary>
	public static bool OnLava=false;
	//public GameObject feet;//For detecting the ground.

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
		/// Checks to see if the tile at a specified location is within the valid game world. (eg is rendered and is not a solid).
		/// Assumes the map is positioned at 0,0,0
		/// </summary>
		/// <returns><c>true</c>, if tile was valided, <c>false</c> otherwise.</returns>
		/// <param name="location">Location.</param>
	public bool ValidTile(Vector3 location)
	{
		int tileX = (int)(location.x/1.2f);
		int tileY = (int)(location.y/1.2f);
		if ((tileX>=64) || (tileX<0) || (tileY>=64) || (tileY<0))
		{//Location is outside the map
				return false;
		}
		int tileType = GetTileType(tileX,tileY);
		int isRendered = GetTileRender(tileX,tileY);

		return ((tileType!=TILE_SOLID) && (isRendered==1));
	}

		/// <summary>
		/// Generates a tile map image for the automap for the specified level.
		/// </summary>
		/// <returns>The map image.</returns>
		/// <param name="LevelNo">Level no.</param>
	public Texture2D TileMapImage()
	{
		InitColours();



		///Sets the map no display
		UWHUD.instance.LevelNoDisplay.text=(thisLevelNo).ToString();
		///Uses a cursor icon to display the player.
		Texture2D playerPosIcon = (Texture2D)Resources.Load (UWEBase._RES +"/HUD/CURSORS/CURSORS_0018");

		///Creates a blank texture2D of 64x64*TileSize in ARGB32 format.
		Texture2D output= new Texture2D(64 * TileSize, 64 * TileSize, TextureFormat.ARGB32, false);
		output.filterMode=FilterMode.Point;
		output.wrapMode=TextureWrapMode.Clamp;
		//Init the tile map as blank first
		for (int i = 0; i<63; i++)
		{
			for (int j = 63; j>0; j--)
			{
				DrawSolidTile(ref output,i,j,TileSize,TileSize,Background);
			}
		}

		///Fills in the tile background colour first
		for (int i = 0; i<63; i++)
		{
			for (int j = 63; j>0; j--)
			{//If the tile has been visited and can be rendered.
				if ((GetTileRender(i,j)==1) && (GetTileVisited(i,j)))
				{
					//fillTile(LevelNo,output,i,j,TileSize,TileSize,Color.gray,Color.blue,Color.red, Color.cyan);
					fillTile(ref output,i,j,TileSize,TileSize,OpenTileColour,WaterTileColour,LavaTileColour,BridgeTileColour);
				}
			}
		}
		///Draws the border lines of the tiles
		for (int i = 0; i<63; i++)
		{
			for (int j = 63; j>0; j--)
			{
				if (GetTileVisited( i,j)==true)
				{
					switch (GetTileType(i,j))
					{
					case TILE_SOLID://Solid
					{
						//DrawSolidTile(ref output,i,j,TileSize,TileSize,Color.clear);
						//output.SetPixel(i, j, Color.blackblack);
						break;
					}
					case TILE_OPEN://Open
					case TILE_SLOPE_E:
					case TILE_SLOPE_W:
					case TILE_SLOPE_S:
					case TILE_SLOPE_N:
					{
						DrawOpenTile(ref output,i,j,TileSize,TileSize,BorderColour);
						//output.SetPixel(i, j, Color.white);
						break;
					}
					case TILE_DIAG_NE:
					{
						//DrawLine (output,i,j,TileSize,TileSize,Color.black,NORTHEAST);
						DrawDiagNE(ref output,i,j,TileSize,TileSize,BorderColour);
						break;
					}
					case TILE_DIAG_SE:
					{
						//DrawLine (output,i,j,TileSize,TileSize,Color.black,SOUTHEAST);
						DrawDiagSE(ref output,i,j,TileSize,TileSize,BorderColour);
						break;
					}
					case TILE_DIAG_NW:
					{
						DrawDiagNW (ref output,i,j,TileSize,TileSize,BorderColour);
						break;
					}
					case TILE_DIAG_SW:
					{
						DrawDiagSW(ref output,i,j,TileSize,TileSize,BorderColour);
						break;
					}
					default:
					{
						//DrawSolidTile(ref output,i,j,TileSize,TileSize,Color.clear);
						//	output.SetPixel(i, j, Color.red);
						break;
					}
					}
				}
				else
				{
					DrawSolidTile(ref output,i,j,TileSize,TileSize,Background);
					//output.SetPixel(i, j, Color.clear);
				}
			}
		}

		for (int i = 0; i<63; i++)
		{
			for (int j = 63; j>0; j--)
			{
				if (GetIsDoor(i,j)==true)			
				{
					if (GetTileVisited(i,j)==true)
					{
						DrawDoor(ref output,i,j,TileSize,TileSize,BorderColour);							
					}
					
				}
			}
		}


		///Only displays the player if they are on the same map as the one being rendered
		if (thisLevelNo==GameWorldController.instance.LevelNo)
		{
			Color[] defaultColour= playerPosIcon.GetPixels();
			float ratioX = GameWorldController.instance.playerUW.transform.position.x / (64.0f*1.2f);
			float ratioY = GameWorldController.instance.playerUW.transform.position.z / (64.0f*1.2f);
			output.SetPixels((int)(output.width*ratioX), (int)(output.width*ratioY),playerPosIcon.width,playerPosIcon.height,defaultColour);								
		}

		// Apply all SetPixel calls
		output.Apply();

	///Display the map notes
	///Delete the map notes in memory
				foreach(Transform child in UWHUD.instance.MapPanel.transform)
				{
						if (child.name.Substring(0,4) == "_Map")
						{								
								GameObject.Destroy(child.transform.gameObject);
						}
				}

				for (int i=0 ; i < MapNotes.Count;i++)
				{///Instantiates the map note template UI control.
					GameObject myObj = (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/_MapNoteTemplate"));
					myObj.transform.parent= UWHUD.instance.MapPanel.transform;
					myObj.GetComponent<Text>().text = MapNotes[i].NoteText;
					myObj.GetComponent<RectTransform>().anchoredPosition= MapNotes[i].NotePosition;
					myObj.GetComponent<MapNoteId>().guid = MapNotes[i].guid;
					//Move the control so that it sits in front of the map,
					myObj.GetComponent<RectTransform>().SetSiblingIndex(4);
				}		

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
	private void fillTile(ref Texture2D OutputTile, int TileX, int TileY, int TileWidth, int TileHeight, Color[] GroundColour,Color[] WaterColour, Color[] LavaColour, Color[] BridgeColour )
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
				DrawSolidTile(ref OutputTile,TileX,TileY,TileWidth,TileHeight,TileColorPrimary);
				break;
				}
			default:
				{//Does not draw anything.
				DrawSolidTile(ref OutputTile,TileX,TileY,TileWidth,TileHeight,Background);
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
	private void DrawSolidTile(ref Texture2D OutputTile, int TileX, int TileY, int TileWidth, int TileHeight, Color[] InputColour)
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
	private void DrawOpenTile(ref Texture2D OutputTile, int TileX, int TileY, int TileWidth, int TileHeight, Color[] InputColour)
	{
		//Check the tile to the north
		if (TileY<63)
			{
			if ((GetTileType( TileX,TileY+1)==TILE_SOLID) && (GetTileRender( TileX,TileY+1)==1))
				{//Solid tile to the north.
				DrawLine (ref OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,NORTH);
				}
			}
		//Check the tile to the south
		if (TileY>0)
			{
			if ((GetTileType( TileX,TileY-1)==TILE_SOLID) && (GetTileRender(TileX,TileY-1)==1))
				{//Solid tile to the south.
					DrawLine (ref OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,SOUTH);
				}
			}
		//Check the tile to the east
		if (TileX <63)
			{
			if ((GetTileType( TileX+1,TileY)==TILE_SOLID) && (GetTileRender( TileX+1,TileY)==1))
				{
					DrawLine (ref OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,EAST);
				}
			}
		//Check the tile to the west
		if (TileX >0)
		{
		if ((GetTileType( TileX-1,TileY)==TILE_SOLID) && (GetTileRender( TileX-1,TileY)==1))
			{
			DrawLine (ref OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,WEST);
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
	private void DrawDoor(ref Texture2D OutputTile,  int TileX, int TileY, int TileWidth, int TileHeight, Color[] InputColour)
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
	private void DrawLine(ref Texture2D OutputTile, int TileX, int TileY, int TileWidth, int TileHeight, Color[] InputColour, int Direction)
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
	void DrawDiagSW(ref Texture2D OutputTile, int TileX, int TileY, int TileWidth, int TileHeight, Color[] InputColour)
	{
		DrawLine (ref OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,SOUTHWEST);

		//Check the tiles to the north and east of this tile to see what needs to be drawn for borders
		if (TileY <63)
			{//north
			int TileToTest = GetTileType(TileX,TileY+1);
			if ((isTileOpen(TileToTest))||(TileToTest==TILE_DIAG_SW))
				{
				DrawLine (ref OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,NORTH);
				}
			}
		if (TileX <63)
			{//east
			int TileToTest = GetTileType(TileX+1,TileY);
			if ((isTileOpen(TileToTest))||(TileToTest==TILE_DIAG_SW))
				{
				DrawLine (ref OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,EAST);
				}
			}

		//Check South and East for solids.
		if (TileY>0)
		{//South
			if (GetTileType (TileX,TileY-1)== TILE_SOLID)
			{
			DrawLine (ref OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,SOUTH);
			}
		}
		
		if (TileX>0)
		{//West
			if (GetTileType (TileX-1,TileY)== TILE_SOLID)
			{
			DrawLine (ref OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,WEST);
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
	void DrawDiagNE(ref Texture2D OutputTile, int TileX, int TileY, int TileWidth, int TileHeight, Color[] InputColour)
	{
		DrawLine (ref OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,NORTHEAST);

		//Check the tiles to the south and west of this tile to see what needs to be drawn.
		if (TileY >0)
		{//South
			int TileToTest = GetTileType(TileX,TileY-1);
			if ((isTileOpen(TileToTest))||(TileToTest==TILE_DIAG_NE))
			{
				DrawLine (ref OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,SOUTH);
			}
		}
		if (TileX >0)
		{//West
			int TileToTest = GetTileType(TileX-1,TileY);
			if ((isTileOpen(TileToTest))||(TileToTest==TILE_DIAG_NE))
			{
				DrawLine (ref OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,WEST);
			}
		}

		//Check North and East for solids.
		if (TileY<63)
		{//North
		if (GetTileType (TileX,TileY+1)== TILE_SOLID)
			{
				DrawLine (ref OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,NORTH);
			}
		}
		
		if (TileX<63)
		{//East
			if (GetTileType (TileX+1,TileY)== TILE_SOLID)
			{
				DrawLine (ref OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,EAST);
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
	void DrawDiagNW(ref Texture2D OutputTile, int TileX, int TileY, int TileWidth, int TileHeight, Color[] InputColour)
	{
		DrawLine (ref OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,NORTHWEST);
		
		//Check the tiles to the south and east of this tile
		if (TileY >0)
		{//South
		int TileToTest = GetTileType(TileX,TileY-1);
			if ((isTileOpen(TileToTest))||(TileToTest==TILE_DIAG_NW))
			{
				DrawLine (ref OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,SOUTH);
			}
		}
		if (TileX <63)
		{//East
			int TileToTest = GetTileType(TileX+1,TileY);
			if ((isTileOpen(TileToTest))||(TileToTest==TILE_DIAG_NW))
			{
				DrawLine (ref OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,EAST);
			}
		}

		//Check North and West for solids.
		if (TileY<63)
		{//North
			if (GetTileType (TileX,TileY+1)== TILE_SOLID)
			{
				DrawLine (ref OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,NORTH);
			}
		}
		
		if (TileX>0)
		{//West
			if (GetTileType (TileX-1,TileY)== TILE_SOLID)
			{
				DrawLine (ref OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,WEST);
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
	void DrawDiagSE(ref Texture2D OutputTile, int TileX, int TileY, int TileWidth, int TileHeight, Color[] InputColour)
	{
		DrawLine (ref OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,SOUTHEAST);
	
		//Check the tiles to the north and west of this tile
		if (TileY <63)
		{//north
			int TileToTest = GetTileType(TileX,TileY+1);
			if ((isTileOpen(TileToTest))||(TileToTest==TILE_DIAG_SE))
			{
				DrawLine (ref OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,NORTH);
			}
		}

		if (TileX >0)
		{//West
			int TileToTest = GetTileType(TileX-1,TileY);
			if ((isTileOpen(TileToTest))||(TileToTest==TILE_DIAG_SE))
			{
				DrawLine (ref OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,WEST);
			}
		}

		//Check South and East for solids.
		if (TileY>0)
			{//South
			if (GetTileType (TileX,TileY-1)== TILE_SOLID)
				{
				DrawLine (ref OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,SOUTH);
				}
			}

		if (TileX<63)
		{//East
			if (GetTileType (TileX+1,TileY)== TILE_SOLID)
			{
				DrawLine (ref OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,EAST);
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
	/// Tells if the tile is one of the square open types
	/// </summary>
	/// <returns><c>true</c>, if tile open was ised, <c>false</c> otherwise.</returns>
	/// <param name="TileType">Tile type.</param>
	public bool isTileOpen(int TileType)
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
		return Tiles[tileX,tileY].floorHeight;
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
	public void SetFloorHeight(int tileX, int tileY, int newHeight)
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
		public void SetCeilingHeight(int tileX, int tileY, int newHeight)
	{
		//Debug.Log ("ceil :" + newHeight + " was " + CeilingHeight[tileX,tileY]);
				Tiles[tileX,tileY].ceilingHeight=newHeight;
	}

		/// <summary>
		/// Sets the tile and it's neighbours as visited. visited.
		/// </summary>
		/// <param name="LevelNo">Level no.</param>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
		public void SetTileVisited(int tileX, int tileY)
		{

				MarkTile(tileX,tileY);
				MarkTile(tileX+1,tileY+1);
				MarkTile(tileX+1,tileY);
				MarkTile(tileX+1,tileY-1);
				MarkTile(tileX+0,tileY+1);
				MarkTile(tileX+0,tileY);
				MarkTile(tileX+0,tileY-1);
				MarkTile(tileX-1,tileY+1);
				MarkTile(tileX-1,tileY);
				MarkTile(tileX-1,tileY-1);
		/*Tiles[tileX,tileY].tileVisited[tileX,tileY]=true;

		Tiles[tileX,tileY].tileVisited[tileX+1,tileY+1]=true;
		Tiles[tileX,tileY].tileVisited[tileX+1,tileY]=true;
		Tiles[tileX,tileY].tileVisited[tileX+1,tileY-1]=true;

		Tiles[tileX,tileY].tileVisited[tileX+0,tileY+1]=true;
		Tiles[tileX,tileY].tileVisited[tileX+0,tileY]=true;
		Tiles[tileX,tileY].tileVisited[tileX+0,tileY-1]=true;

		Tiles[tileX,tileY].tileVisited[tileX-1,tileY+1]=true;
		Tiles[tileX,tileY].tileVisited[tileX-1,tileY]=true;
		Tiles[tileX,tileY].tileVisited[tileX-1,tileY-1]=true;
		*/

		}

		/// <summary>
		/// Marks the tile as visited and checks if it is in range.
		/// </summary>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
		private void MarkTile(int tileX, int tileY)
		{
				if (((tileX>=0) && (tileX<=63)) 
						&& 
						((tileY>=0) && (tileY<=63)))
				{
						Tiles[tileX,tileY].tileVisited=true;
				}
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
		return Tiles[tileX,tileY].tileVisited;
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
		return Tiles[tileX,tileY].isWater;
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
		return Tiles[tileX,tileY].isLava;
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
		return Tiles[tileX,tileY].hasBridge;
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
			return Tiles[tileX,tileY].isDoor;
		}

		/// <summary>
		/// Sets if the tile is a door
		/// </summary>
		/// <param name="LevelNo">Level no.</param>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
		/// <param name="iIsDoor">I is door.</param>
		private void SetIsDoor(int tileX, int tileY,int iIsDoor)
		{
			if (iIsDoor==1)
			{
				Tiles[tileX,tileY].isDoor=true;	
			}
			else
			{
				Tiles[tileX,tileY].isDoor=false;
			}
		}

		/// <summary>
		/// Sets if the tile is water.
		/// </summary>
		/// <param name="LevelNo">Level no.</param>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
		/// <param name="iIsWater">1 is water, 0 is not.</param>
	private void SetIsWater(int tileX, int tileY,int iIsWater)
	{
		if (iIsWater==1)
			{
				Tiles[tileX,tileY].isWater=true;	
			}
		else
			{
				Tiles[tileX,tileY].isWater=false;
			}
	}

	/// <summary>
	/// Sets if the tile is lava.
	/// </summary>
	/// <param name="LevelNo">Level no.</param>
	/// <param name="tileX">Tile x.</param>
	/// <param name="tileY">Tile y.</param>
	/// <param name="iIsLava">I is lava.</param>
	private void SetIsLava(int tileX, int tileY,int iIsLava)
	{
		if (iIsLava==1)
		{
			Tiles[tileX,tileY].isLava=true;	
		}
		else
		{
			Tiles[tileX,tileY].isLava=false;
		}
	}

		/// <summary>
		/// Marks if the tile has a bridge.
		/// </summary>
		/// <param name="LevelNo">Level no.</param>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
		/// <param name="iIsBridge">I is bridge.</param>
		private void SetIsBridge(int tileX, int tileY,int iIsBridge)
		{
			if (iIsBridge==1)
			{
				Tiles[tileX,tileY].hasBridge=true;	
			}
			else
			{
				Tiles[tileX,tileY].hasBridge=false;
			}
		}


		/// <summary>
		/// Sets the type of the tile.
		/// </summary>
		/// <param name="LevelNo">Level no.</param>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
		/// <param name="itileType">Itile type. See tile type constants on this class</param>
	private void SetTileType( int tileX, int tileY,int itileType)
	{
		Tiles[tileX,tileY].tileType=itileType;
	}


		/// <summary>
		/// Gets the type of the tile.
		/// </summary>
		/// <returns>The tile type.</returns>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
		public int GetTileType(int tileX, int tileY)
		{
				if ((tileX>63) || (tileY>63) || (tileX<0) || (tileY<0))
				{//Assume out of bounds is solid
					return TILE_SOLID;
				}
				else
				{
						return Tiles[tileX,tileY].tileType;
				}			
		}



		/// <summary>
		/// Sets the tile render state. Only affects the automap.
		/// </summary>
		/// <param name="LevelNo">Level no.</param>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
		/// <param name="iRender">1= render, 0 = invisible.</param>
	private void SetTileRender(int tileX, int tileY,int iRender)
	{
		Tiles[tileX,tileY].Render=(short)iRender;
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
		return Tiles[tileX,tileY].Render;
	}

		/// <summary>
		/// Sets the tile properties that are read in from tileprops.txt
		/// </summary>
		/// <param name="LevelNo">Level no.</param>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
		/// <param name="itileType">Itile type.</param>
		/// <param name="iRender">I render.</param>
		/// <param name="FloorHeight">Floor height.</param>
		/// <param name="CeilingHeight">Ceiling height.</param>
		/// <param name="iIsWater">is water.</param>
		/// <param name="iIsDoor">is door.</param>
		/// <param name="iIsLava">is lava.</param>
		private void SetTileProp( int tileX, int tileY, int itileType, int iRender, int FloorHeight, int CeilingHeight, int iIsWater, int iIsDoor, int iIsLava, int iIsBridge)
			{
				SetTileType (tileX,tileY,itileType);
				Tiles[tileX,tileY].Render=(short)iRender;
				SetFloorHeight ( tileX,tileY,FloorHeight);
				SetCeilingHeight (tileX,tileY,CeilingHeight);
				SetIsWater( tileX,tileY,iIsWater);
				SetIsLava(tileX,tileY,iIsLava);
				SetIsBridge(tileX,tileY,iIsBridge);
				SetIsDoor(tileX,tileY,iIsDoor);
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
		/// Loads the tile map info from a config file called GAMENAME+ "_tileprops.txt"
		/// </summary>
		/// <returns><c>true</c>, if tile map info was loaded, <c>false</c> otherwise.</returns>
		/// <param name="fileName">File name.</param>
		public bool LoadTileMapInfo(string fileName)
		{
				return false;
		}

		///LEVEL LOADER
		/// 
		/// 
		/// 


		public bool BuildTileMapUW(string filePath, int game, int LevelNo)
		{
				// File pointer
				char[] lev_ark; 
				//char[] tmp_ark; 
				char[] tex_ark; 
				int NoOfBlocks;
				long AddressOfBlockStart;
				long address_pointer;
				long textureAddress;
				long fileSize;
				short x;	
				short y;
				int i;
				int CeilingTexture=0;
				int textureMapSize=64;

				UW_CEILING_HEIGHT = ((128 >> 2) * 8 >>3);	//Shifts the scale of the level. Idea borrowed from abysmal

				for  (x=0; x<64;x++)
				{
						for (y=0; y<64;y++)
						{
								Tiles[x,y] =new TileInfo();
						}
				}

				MapNotes = new List<MapNote>();

				switch (game)
				{
				case 1:	//UW1
						{
								CEILING_HEIGHT=UW_CEILING_HEIGHT;
								if (!DataLoader.ReadStreamFile(filePath, out lev_ark))
								{
										return false;
								}

								// 0x7a;
								//Get the number of blocks in this file.
								NoOfBlocks =  (int)DataLoader.getValAtAddress(lev_ark,0,32);
								//Get the first map block
								AddressOfBlockStart =  DataLoader.getValAtAddress(lev_ark,(LevelNo * 4) + 2,32);	
								textureAddress =  DataLoader.getValAtAddress(lev_ark,((LevelNo+18) * 4) + 2 ,32);
								//long objectsAddress = AddressOfBlockStart + (64*64*4); //+ 1;
								address_pointer =0;
								break;
						}	
				default:
						return false;
				}

				int offset=0;
				for (i = 0; i<textureMapSize; i++)	//256
				{//TODO: Only use this for texture lookups.
						switch (game)
						{
						case 1:
								{
									if (i<48)	//Wall and floor textures are int 16s
									{
											texture_map[i] =  (int)DataLoader.getValAtAddress(lev_ark, textureAddress + offset, 16); //(i * 2)
											offset=offset+2;

									}
									else if (i<=57)	//Wall and floor textures are int 16s
									{
											texture_map[i] =  (int)DataLoader.getValAtAddress(lev_ark, textureAddress + offset, 16)+210; //(i * 2)
											offset = offset + 2;

									}
									else
									{ //door textures are int 8s
											texture_map[i] = (int)DataLoader.getValAtAddress(lev_ark, textureAddress + offset, 8) ;//+210; //(i * 1)
											offset++;
									}
									if (i == 57)
									{
											CeilingTexture = texture_map[i];
									}

									break;
								}
						}
				}
				//Assign door textures to the object masters list
				//Depends on the correct values in the config!!
				//switch (game)
				//{
				//case 1:
				//TODO: Restore this 
				/*objectMasters[320].extraInfo = texture_map[58];
			objectMasters[321].extraInfo = texture_map[59];
			objectMasters[322].extraInfo = texture_map[60];
			objectMasters[323].extraInfo = texture_map[61];
			objectMasters[324].extraInfo = texture_map[62];
			objectMasters[325].extraInfo = texture_map[63];

			objectMasters[328].extraInfo = texture_map[58];
			objectMasters[329].extraInfo = texture_map[59];
			objectMasters[330].extraInfo = texture_map[60];
			objectMasters[331].extraInfo = texture_map[61];
			objectMasters[332].extraInfo = texture_map[62];
			objectMasters[333].extraInfo = texture_map[63];
			break;*/
				//}
				for (y=0; y<64;y++)
				{
						for (x=0; x<64;x++)
						{
								Tiles[x,y].tileX = x;
								Tiles[x,y].tileY = y;
								Tiles[x,y].address = AddressOfBlockStart+address_pointer;
								long FirstTileInt = DataLoader.getValAtAddress(lev_ark,AddressOfBlockStart+(address_pointer+0),16);
								long SecondTileInt = DataLoader.getValAtAddress(lev_ark,AddressOfBlockStart+(address_pointer+2),16);
								address_pointer=address_pointer+4;

								Tiles[x,y].tileType = getTile(FirstTileInt) ;
								Tiles[x,y].floorHeight = getHeight(FirstTileInt) ;
								Tiles[x,y].floorHeight = ((Tiles[x,y].floorHeight <<3) >> 2)*8 >>3;	//Try and copy this shift from shock.

								Tiles[x,y].ceilingHeight = 0;//UW_CEILING_HEIGHT;	//constant for uw				
								Tiles[x,y].noOfNeighbours=0;
								Tiles[x,y].tileTested = 0;
								Tiles[x,y].TerrainChangeCount=0;
								Tiles[x,y].BullFrog = 0;

								Tiles[x,y].flags =(short)((FirstTileInt>>7) & 0x3);
								Tiles[x,y].noMagic =(short)( (FirstTileInt>>13) & 0x1);
								switch (game)
								{
								case 1:	//uw1
										Tiles[x,y].floorTexture = getFloorTex(lev_ark, textureAddress, FirstTileInt);
										if (LevelNo == 6)
										{//Tybals lair. Special case for the maze
												//int val = (FirstTileInt >> 10) & 0x0F;
												if (((FirstTileInt >> 10) & 0x0F) == 4)
												{//Maze floor
														Tiles[x,y].floorTexture = 278;
												}
										}
										Tiles[x,y].wallTexture = getWallTex(lev_ark, textureAddress, SecondTileInt);
										break;
								}
								if (Tiles[x,y].floorTexture<0)
								{
										Tiles[x,y].floorTexture=0;
								}
								if (Tiles[x,y].wallTexture>=256)
								{
										Tiles[x,y].wallTexture =0;
								}					
								//UW only has a single ceiling texture so this is ignored.
								//Tiles[x,y].shockCeilingTexture = Tiles[x,y].floorTexture;					
								Tiles[x,y].shockCeilingTexture=CeilingTexture;
								//There is only one possible steepness in UW so I set it's properties to match a similar tile in shock.
								if (Tiles[x,y].tileType >=2)
								{
										Tiles[x,y].shockSteep = 1;
										Tiles[x,y].shockSteep = ((Tiles[x,y].shockSteep  <<3) >> 2)*8 >>3;	//Shift copied from shock
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

								Tiles[x,y].Render=1;		
								Tiles[x,y].DimX=1;			
								Tiles[x,y].DimY=1;			
								Tiles[x,y].Grouped=0;	
								//Tiles[x,y].VisibleFaces = 63;
								for (int v = 0; v < 6; v++)
								{
										Tiles[x,y].VisibleFaces[v]=1;
								}
								//Restore this when texturesmasters is loaded.
								//Tiles[x,y].isWater = (textureMasters[Tiles[x,y].floorTexture].water == 1) && ((Tiles[x,y].tileType !=0) && (ENABLE_WATER==1));
								//Tiles[x,y].isLava = (textureMasters[Tiles[x,y].floorTexture].lava == 1) && ((Tiles[x,y].tileType != 0));
								Tiles[x,y].waterRegion= 0;
								Tiles[x,y].landRegion = 0;//including connected bridges.
								Tiles[x,y].lavaRegion = 0;

								//Set some easy tile visible settings
								switch (Tiles[x,y].tileType)
								{
								case TILE_SOLID:
										//Bottom and top are invisible
										Tiles[x,y].VisibleFaces[0] = 0;
										Tiles[x,y].VisibleFaces[2] = 0;
										break;
								default:
										//Bottom is invisible
										Tiles[x,y].VisibleFaces[2] = 0;
										break;
								}

								//Force off water to save on compile time during testing.
								//Tiles[x,y].isWater=0;
								//Tiles[x,y].TerrainChange=0;
								//Tiles[x,y].hasElevator=0;
						}
				}
				for (y=0; y<64;y++)
				{
						for (x=0; x<64;x++)
						{
								if (Tiles[x,y].tileType >= 0) //was just solid only. Note: If textures are all wrong it's probably caused here!
								{
										//assign it's north texture
										if (y<63)
										{Tiles[x,y].North =Tiles[x,y+1].wallTexture;}
										else
										{Tiles[x,y].North =-1;}
										//assign it's southern
										if (y>0)
										{Tiles[x,y].South  =Tiles[x,y-1].wallTexture;}
										else
										{Tiles[x,y].South =-1;}
								}
								//it's east
								if (x<63)
								{Tiles[x,y].East =Tiles[x+1,y].wallTexture;}
								else
								{Tiles[x,y].East =-1;}
								//assign it's West
								if (x>0)
								{Tiles[x,y].West =Tiles[x-1,y].wallTexture;}
								else
								{Tiles[x,y].West =-1;}				
						}
						if ((x<64) && (y<64))
						{
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

				//Perform a cleanup of the data
				CleanUp(1);

				return true;
		}




		//***********************

		int getTile(long tileData)
		{
				//gets tile data at bits 0-3 of the tile data
				return (int) (tileData & 0x0F);
		}

		int getHeight(long tileData)
		{//gets height data at bits 4-7 of the tile data
				return (int)(tileData & 0xF0) >> 4;
		}

		int getFloorTex(char[] buffer, long textureOffset, long tileData)
		{//gets floor texture data at bits 10-13 of the tile data
				int val = (int)(tileData >>10) & 0x0F;	//gets the index of the texture
				//look it up in texture block for it's absolute index for wxx.tr
				return (int)DataLoader.getValAtAddress(buffer,textureOffset+96+(val*2),16) +210;			//96 needed?
				//	return ((tileData >>10) & 0x0F);	//was	11
		}

		int getWallTex(char[] buffer, long textureOffset, long tileData)
		{
				//gets wall texture data at bits 0-5 (+16) of the tile data(2nd part)
				//return ((tileData >>17)& 0x3F);
				int val = (int)(tileData & 0x3F);	//gets the index of the texture
				return (int)DataLoader.getValAtAddress(buffer,textureOffset+(val*2),16);
				//return (tileData& 0x3F);
		}

		int getObject(long tileData)
		{
				//gets object data at bits 6-15 (+16) of the tile data(2nd part)
				return (int)tileData >> 6;
		}




		///Cleanup
		/// 
		void CleanUp(int game)
		{
				int x; int y;


				for (x=0;x<64;x++){
						for (y=0;y<64;y++){
								//lets test this tile for visibility
								//A tile is invisible if it only touches other solid tiles and has no objects or does not have a terrain change.
								if ((Tiles[x,y].tileType ==0) && (Tiles[x,y].indexObjectList == 0)  && (Tiles[x,y].TerrainChange == 0)){
										switch (y)
										{
										case 0:	//bottom row
												switch (x)
												{
												case 0:	//bl corner
														if ((Tiles[x + 1,y].tileType == 0) && (Tiles[x,y + 1].tileType == 0)
																&& (Tiles[x + 1,y].TerrainChange == 0) && (Tiles[x,y+1].TerrainChange == 0))
														{Tiles[x,y].Render =0 ; ;break;}
														else {Tiles[x,y].Render =1 ;break;}
												case 63://br corner
														if ((Tiles[x - 1,y].tileType == 0) && (Tiles[x,y + 1].tileType == 0)
																&& (Tiles[x - 1,y].TerrainChange == 0) && (Tiles[x,y+1].TerrainChange == 0))
														{Tiles[x,y].Render =0 ;break;}
														else {Tiles[x,y].Render =1 ;break;}
												default: // invert t
														if ((Tiles[x + 1,y].tileType == 0) && (Tiles[x,y + 1].tileType == 0) && (Tiles[x + 1,y].tileType == 0) 
																&& (Tiles[x+1,y].TerrainChange == 0) && (Tiles[x,y+1].TerrainChange == 0) && (Tiles[x+1,y].TerrainChange == 0))
														{Tiles[x,y].Render =0 ;break;}
														else {Tiles[x,y].Render =1 ;break;}
												}
												break;
										case 63: //Top row
												switch (x)
												{
												case 0:	//tl corner
														if ((Tiles[x + 1,y].tileType == 0) && (Tiles[x,y - 1].tileType == 0) 
																&& (Tiles[x + 1,y].TerrainChange == 0) && (Tiles[x,y-1].TerrainChange == 0))
														{Tiles[x,y].Render =0 ;break;}
														else {Tiles[x,y].Render =1 ;break;}
												case 63://tr corner
														if ((Tiles[x - 1,y].tileType == 0) && (Tiles[x,y - 1].tileType == 0) 
																&& (Tiles[x - 1,y].TerrainChange == 0) && (Tiles[x,y-1].TerrainChange == 0))
														{Tiles[x,y].Render =0 ;break;}
														else {Tiles[x,y].Render =1 ;break;}
												default: //  t
														if ((Tiles[x + 1,y].tileType == 0) && (Tiles[x,y - 1].tileType == 0) && (Tiles[x - 1,y].tileType == 0) 
																&& (Tiles[x + 1,y].TerrainChange == 0) && (Tiles[x,y - 1].TerrainChange == 0) && (Tiles[x-1,y].TerrainChange == 0))
														{Tiles[x,y].Render =0;break;}
														else {Tiles[x,y].Render =1 ;break;}
												}	
												break;
										default: //
												switch (x)
												{
												case 0:		//left edge
														if ((Tiles[x,y + 1].tileType == 0) && (Tiles[x + 1,y].tileType == 0) && (Tiles[x,y - 1].tileType == 0) 
																&& (Tiles[x,y+1].TerrainChange == 0) && (Tiles[x+1,y].TerrainChange == 0) && (Tiles[x,y-1].TerrainChange == 0))
														{Tiles[x,y].Render =0;break;}
														else {Tiles[x,y].Render =1 ;break;}
												case 63:	//right edge
														if ((Tiles[x,y + 1].tileType == 0) && (Tiles[x - 1,y].tileType == 0) && (Tiles[x,y - 1].tileType == 0) 
																&& (Tiles[x,y+1].TerrainChange == 0) && (Tiles[x-1,y].TerrainChange == 0) && (Tiles[x,y-1].TerrainChange == 0))
														{Tiles[x,y].Render =0 ;break;}
														else {Tiles[x,y].Render =1 ;break;}
												default:		//+
														if ((Tiles[x,y + 1].tileType == 0) && (Tiles[x + 1,y].tileType == 0) && (Tiles[x,y - 1].tileType == 0) && (Tiles[x - 1,y].tileType == 0) 
																&& (Tiles[x,y + 1].TerrainChange == 0) && (Tiles[x + 1,y].TerrainChange == 0) && (Tiles[x,y - 1].TerrainChange == 0) && (Tiles[x-1,y].TerrainChange == 0))
														{Tiles[x,y].Render =0; break;}
														else {Tiles[x,y].Render =1 ;break;}
												}
												break;
										}
								}
						}
				}






				//return;
				//if (game == SHOCK) {return;}
				int j=1 ;
				//Now lets combine the solids along particular axis
				for (x=0;x<63;x++){
						for (y=0;y<63;y++){
								if  ((Tiles[x,y].Grouped ==0))
								{
										j=1;
										while ((Tiles[x,y].Render == 1) && (Tiles[x,y + j].Render == 1) && (Tiles[x,y + j].Grouped == 0) && (Tiles[x,y + j].BullFrog == 0))		//&& (Tiles[x,y].tileType ==0) && (Tiles[x,y+j].tileType ==0)
										{
												//combine these two if they match and they are not already part of a group
												if (DoTilesMatch(Tiles[x,y],Tiles[x,y+j])){
														Tiles[x,y+j].Render =0;
														Tiles[x,y+j].Grouped =1;
														Tiles[x,y].Grouped =1;
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
				for (y=0;y<63;y++){
						for (x=0;x<63;x++){
								if  ((Tiles[x,y].Grouped ==0))
								{
										j=1;
										while ((Tiles[x,y].Render == 1) && (Tiles[x + j,y].Render == 1) && (Tiles[x + j,y].Grouped == 0) && (Tiles[x + j,y].BullFrog == 0))		//&& (Tiles[x,y].tileType ==0) && (Tiles[x,y+j].tileType ==0)
										{
												//combine these two if they  match and they are not already part of a group
												if (DoTilesMatch(Tiles[x,y],Tiles[x+j,y])){
														Tiles[x+j,y].Render =0;
														Tiles[x+j,y].Grouped =1;
														Tiles[x,y].Grouped =1;
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
				for (y = 0; y<=63; y++){
						for (x = 0; x<=63; x++){
								if ((Tiles[x,y].tileType == TILE_SOLID))
								{
										int dimx = Tiles[x,y].DimX;
										int dimy = Tiles[x,y].DimY;

										if (x == 0)
										{
												Tiles[x,y].VisibleFaces[vWEST]=0;
										}
										if (x == 63)
										{
												Tiles[x,y].VisibleFaces[vEAST] = 0;
										}
										if (y == 0 )
										{
												Tiles[x,y].VisibleFaces[vSOUTH] = 0;
										}

										if (y == 63)
										{
												Tiles[x,y].VisibleFaces[vNORTH] = 0;
										}
										if ((x+dimx <= 63) && (y+dimy <= 63))
										{
												if ((Tiles[x + dimx,y].tileType == TILE_SOLID) && (Tiles[x + dimx,y].TerrainChange == 0) && (Tiles[x,y].TerrainChange == 0))//Tile to the east is a solid
												{
														Tiles[x,y].VisibleFaces[vEAST] = 0;
														Tiles[x + dimx,y].VisibleFaces[vWEST] = 0;
												}
												if ((Tiles[x,y + dimy].tileType == TILE_SOLID) && (Tiles[x,y].TerrainChange == 0) && (Tiles[x,y + dimy].TerrainChange == 0))//TIle to the north is a solid
												{
														Tiles[x,y].VisibleFaces[vNORTH] = 0;
														Tiles[x,y + dimy].VisibleFaces[vSOUTH] = 0;
												}
										}
								}
						}
				}

				//Clear invisible faces on diagonals
				for (y = 1; y < 63; y++){
						for (x = 1; x < 63; x++){
								switch (Tiles[x,y].tileType)
								{
								case TILE_DIAG_NW:
										{
												if ((Tiles[x,y - 1].tileType == TILE_SOLID) && (Tiles[x,y-1].TerrainChange == 0))
												{
														Tiles[x,y].VisibleFaces[vSOUTH]=0;
														Tiles[x,y - 1].VisibleFaces[vNORTH]=0;
												}
												if ((Tiles[x + 1,y].tileType == TILE_SOLID) && (Tiles[x + 1,y].TerrainChange==0))
												{
														Tiles[x,y].VisibleFaces[vEAST] = 0;
														Tiles[x + 1,y].VisibleFaces[vWEST]=0;
												}
										}
										break;
								case TILE_DIAG_NE:
										{
												if ((Tiles[x,y - 1].tileType == TILE_SOLID) && (Tiles[x,y - 1].TerrainChange == 0))
												{
														Tiles[x,y].VisibleFaces[vSOUTH] = 0;
														Tiles[x,y - 1].VisibleFaces[vNORTH] = 0;
												}
												if ((Tiles[x - 1,y].tileType == TILE_SOLID) && (Tiles[x - 1,y].TerrainChange == 0))
												{
														Tiles[x,y].VisibleFaces[vWEST] = 0;
														Tiles[x - 1,y].VisibleFaces[vEAST] = 0;
												}
										}
										break;
								case TILE_DIAG_SE:
										{
												if ((Tiles[x,y + 1].tileType == TILE_SOLID) && (Tiles[x,y + 1].TerrainChange == 0))
												{
														Tiles[x,y].VisibleFaces[vNORTH] = 0;
														Tiles[x,y + 1].VisibleFaces[vSOUTH] = 0;
												}
												if ((Tiles[x - 1,y].tileType == TILE_SOLID) && (Tiles[x - 1,y].TerrainChange == 0))
												{
														Tiles[x,y].VisibleFaces[vWEST] = 0;
														Tiles[x - 1,y].VisibleFaces[vEAST] = 0;
												}
										}
										break;
								case TILE_DIAG_SW:
										{
												if ((Tiles[x,y + 1].tileType == TILE_SOLID) && (Tiles[x,y + 1].TerrainChange == 0))
												{
														Tiles[x,y].VisibleFaces[vNORTH] = 0;
														Tiles[x,y + 1].VisibleFaces[vSOUTH] = 0;
												}
												if ((Tiles[x + 1,y].tileType == TILE_SOLID) && (Tiles[x + 1,y].TerrainChange == 0))
												{
														Tiles[x,y].VisibleFaces[vEAST] = 0;
														Tiles[x + 1,y].VisibleFaces[vWEST] = 0;
												}
										}
										break;
								}

						}

				}

				for (y = 1; y < 63; y++){
						for (x = 1; x < 63; x++){
								if ((Tiles[x,y].tileType == TILE_OPEN) && (Tiles[x,y].TerrainChange == 0) && (Tiles[x,y].BullFrog == 0))
								{
										if (
												((Tiles[x + 1,y].tileType == TILE_OPEN) && (Tiles[x + 1,y].TerrainChange == 0) && (Tiles[x + 1,y].BullFrog == 0) && (Tiles[x + 1,y].floorHeight >= Tiles[x,y].floorHeight))
												||
												(Tiles[x + 1,y].tileType == TILE_SOLID) && (Tiles[x + 1,y].TerrainChange == 0) && (Tiles[x + 1,y].BullFrog == 0)
										)
										{
												Tiles[x,y].VisibleFaces[vEAST]=0;
										}


										if (
												((Tiles[x - 1,y].tileType == TILE_OPEN) && (Tiles[x - 1,y].TerrainChange == 0) && (Tiles[x - 1,y].BullFrog == 0) && (Tiles[x - 1,y].floorHeight >= Tiles[x,y].floorHeight))
												||
												(Tiles[x - 1,y].tileType == TILE_SOLID) && (Tiles[x - 1,y].TerrainChange == 0) && (Tiles[x - 1,y].BullFrog == 0)
										)
										{
												Tiles[x,y].VisibleFaces[vWEST] = 0;
										}


										if (
												((Tiles[x,y + 1].tileType == TILE_OPEN) && (Tiles[x,y + 1].TerrainChange == 0) && (Tiles[x,y + 1].BullFrog == 0) && (Tiles[x,y + 1].floorHeight >= Tiles[x,y].floorHeight))
												||
												(Tiles[x,y + 1].tileType == TILE_SOLID) && (Tiles[x,y + 1].TerrainChange == 0) && (Tiles[x,y + 1].BullFrog == 0)
										)
										{
												Tiles[x,y].VisibleFaces[vNORTH] = 0;
										}

										if (
												((Tiles[x,y - 1].tileType == TILE_OPEN) && (Tiles[x,y - 1].TerrainChange == 0) && (Tiles[x,y - 1].BullFrog == 0) && (Tiles[x,y - 1].floorHeight >= Tiles[x,y].floorHeight))
												||
												(Tiles[x,y - 1].tileType == TILE_SOLID) && (Tiles[x,y - 1].TerrainChange == 0) && (Tiles[x,y - 1].BullFrog == 0)
										)
										{
												Tiles[x,y].VisibleFaces[vSOUTH] = 0;
										}
								}

						}
				}
				//Make sure solids & opens are still consistently visible.
				for (y = 1; y < 63; y++){
						for (x = 1; x < 63; x++){

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
												if (Tiles[x + i,y].VisibleFaces[vNORTH] == 1)
												{
														Tiles[x,y].VisibleFaces[vNORTH]=1;
												}
												if (Tiles[x + i,y].VisibleFaces[vSOUTH] == 1)
												{
														Tiles[x,y].VisibleFaces[vSOUTH] = 1;
												}
										}

										for (int i = 0; i < Tiles[x,y].DimY; i++)
										{
												if (Tiles[x,y+i].VisibleFaces[vEAST] == 1)
												{
														Tiles[x,y].VisibleFaces[vEAST] = 1;
												}
												if (Tiles[x,y+i].VisibleFaces[vWEST] == 1)
												{
														Tiles[x,y].VisibleFaces[vWEST] = 1;
												}
										}

								}
						}
				}
				for ( y = 0; y <= 63; y++){
						Tiles[0,y].VisibleFaces[vEAST]=1;
						Tiles[63,y].VisibleFaces[vWEST] = 1;
				}
				for ( x = 0; x <= 63; x++){
						Tiles[x,0].VisibleFaces[vNORTH] = 1;
						Tiles[x,63].VisibleFaces[vSOUTH] = 1;
				}
		}



		bool DoTilesMatch(TileInfo t1, TileInfo t2)
		{//TODO:Tiles have a lot more properties now.
				//if ((t1.tileType >1) || (t1.hasElevator==1) || (t1.TerrainChange ==1) ||  (t2.hasElevator==1) || (t2.TerrainChange ==1) || (t1.isWater ==1) || (t2.isWater ==1)){	//autofail no none solid/open/special.
				if ((t1.tileType >1) || (t1.hasElevator == 1) || (t1.TerrainChange == 1) || (t2.hasElevator == 1) || (t2.TerrainChange == 1)){	//autofail no none solid/open/special.
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




}