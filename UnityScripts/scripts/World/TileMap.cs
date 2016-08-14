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
public class TileMap : UWEBase {
		/// <summary>
		/// Tile info storage class
		/// </summary>
	public TileInfo[] Tiles=new TileInfo[9];

		/// <summary>
		/// The height of the max ceiling value for this level. Only used in SHOCK moving platform.
		/// </summary>
	public int GlobalCeilingHeight = 32;

	
		/// <summary>
		/// Player written Map notes stored in a list.
		/// </summary>
	public List<MapNote>[] MapNotes = new List<MapNote>[10];


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

		/// <summary>
		/// The current tile X that the player is in
		/// </summary>
	public int visitTileX;
		/// <summary>
		/// The current tile Y that the player is in.
		/// </summary>
	public int visitTileY;
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
		/// Detects where the player currently is an updates their swimming state and auto map as needed.
		/// </summary>
	public void PositionDetect()
	{
		if (GameWorldController.instance.AtMainMenu==true)
		{
				return;
		}
		visitTileX =(int)(GameWorldController.instance.playerUW.transform.position.x/1.2f);
		visitTileY =(int)(GameWorldController.instance.playerUW.transform.position.z/1.2f);
		SetTileVisited(GameWorldController.instance.LevelNo,visitTileX,visitTileY);
		GameWorldController.instance.playerUW.isSwimming=((OnWater) && (!GameWorldController.instance.playerUW.isWaterWalking)) ;

	}

		/// <summary>
		/// Returns the current levels tile map info.
		/// </summary>
		public TileInfo current()
		{//Returns the current tile Map info.
			return Tiles[GameWorldController.instance.LevelNo];
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
		if ((tileX>=64) || (tileX<0) || (tileY>=64) || (tileY<0))
		{//Location is outside the map
				return false;
		}
		int tileType = GetTileType(GameWorldController.instance.LevelNo,tileX,tileY);
		int isRendered = GetTileRender(GameWorldController.instance.LevelNo,tileX,tileY);

		return ((tileType!=TILE_SOLID) && (isRendered==1));
	}

		/// <summary>
		/// Generates a tile map image for the automap for the current level.
		/// </summary>
		/// <returns>The map image.</returns>
		public Texture2D TileMapImage()
		{
			return  TileMapImage(GameWorldController.instance.LevelNo);
		}

		/// <summary>
		/// Generates a tile map image for the automap for the specified level.
		/// </summary>
		/// <returns>The map image.</returns>
		/// <param name="LevelNo">Level no.</param>
	public Texture2D TileMapImage(int LevelNo)
	{

		///The size in pixels of the tiles
		int TileSize = 4;

		///Sets the map no display
		UWHUD.instance.LevelNoDisplay.text=(LevelNo+1).ToString();
		///Uses a cursor icon to display the player.
		Texture2D playerPosIcon = (Texture2D)Resources.Load (_RES +"/HUD/CURSORS/CURSORS_0018");

		///Creates a blank texture2D of 64x64*TileSize in ARGB32 format.
		Texture2D output= new Texture2D(64 * TileSize, 64 * TileSize, TextureFormat.ARGB32, false);
		//Init the tile map as blank first
		for (int i = 0; i<63; i++)
		{
			for (int j = 63; j>0; j--)
			{
				DrawSolidTile(output,i,j,TileSize,TileSize,Color.clear);
			}
		}

		///Fills in the tile background colour first
		for (int i = 0; i<63; i++)
		{
			for (int j = 63; j>0; j--)
			{//If the tile has been visited and can be rendered.
				if ((GetTileRender(LevelNo,i,j)==1) && (GetTileVisited(LevelNo,i,j)))
				{
					fillTile(LevelNo,output,i,j,TileSize,TileSize,Color.gray,Color.blue,Color.red, Color.cyan);
				}
			}
		}
		///Draws the border lines of the tiles
		for (int i = 0; i<63; i++)
		{
			for (int j = 63; j>0; j--)
			{
				if (GetTileVisited(LevelNo, i,j)==true)
				{
					switch (GetTileType(LevelNo, i,j))
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
						DrawOpenTile(LevelNo, output,i,j,TileSize,TileSize,Color.black);
						//output.SetPixel(i, j, Color.white);
						break;
					}
					case TILE_DIAG_NE:
					{
						//DrawLine (output,i,j,TileSize,TileSize,Color.black,NORTHEAST);
						DrawDiagNE(LevelNo, output,i,j,TileSize,TileSize,Color.black);
						break;
					}
					case TILE_DIAG_SE:
					{
						//DrawLine (output,i,j,TileSize,TileSize,Color.black,SOUTHEAST);
						DrawDiagSE(LevelNo, output,i,j,TileSize,TileSize,Color.black);
						break;
					}
					case TILE_DIAG_NW:
					{
						DrawDiagNW (LevelNo, output,i,j,TileSize,TileSize,Color.black);
						break;
					}
					case TILE_DIAG_SW:
					{
						DrawDiagSW(LevelNo, output,i,j,TileSize,TileSize,Color.black);
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
					DrawSolidTile(output,i,j,TileSize,TileSize,Color.clear);
					//output.SetPixel(i, j, Color.clear);
				}
			}
		}

		///Only displays the player if they are on the same map as the one being rendered
		if (LevelNo==GameWorldController.instance.LevelNo)
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
								Destroy(child.transform.gameObject);
						}
				}

				for (int i=0 ; i < MapNotes[LevelNo].Count;i++)
				{///Instantiates the map note template UI control.
					GameObject myObj = (GameObject)Instantiate(Resources.Load("Prefabs/_MapNoteTemplate"));
					myObj.transform.parent= UWHUD.instance.MapPanel.transform;
					myObj.GetComponent<Text>().text = MapNotes[LevelNo][i].NoteText;
					myObj.GetComponent<RectTransform>().anchoredPosition= MapNotes[LevelNo][i].NotePosition;
					myObj.GetComponent<MapNoteId>().guid = MapNotes[LevelNo][i].guid;
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
	private void fillTile(int LevelNo, Texture2D OutputTile, int TileX, int TileY, int TileWidth, int TileHeight, Color GroundColour,Color WaterColour, Color LavaColour, Color BridgeColour )
	{
		Color TileColorPrimary;
		Color TileColorSecondary;
		///Picks which colour to use based on the tile properties.
		if (GetIsBridge(LevelNo,TileX,TileY)==true)
			{
				TileColorPrimary=BridgeColour;
				TileColorSecondary=Color.clear;	
			}
		else if (GetIsWater(LevelNo,TileX,TileY)==true)
			{
			TileColorPrimary=WaterColour;
			TileColorSecondary=Color.clear;
			}
		else if (GetIsLava(LevelNo,TileX,TileY) == true)
		{
			TileColorPrimary=LavaColour;
			TileColorSecondary=Color.clear;
		}
		else
			{
			TileColorPrimary=GroundColour;
			TileColorSecondary=Color.clear;
			}
			switch(GetTileType(LevelNo,TileX,TileY))
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
							OutputTile.SetPixel(i+TileX*TileWidth,j+TileY*TileHeight,TileColorPrimary);
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
								OutputTile.SetPixel(i+TileX*TileWidth,j+TileY*TileHeight,TileColorPrimary);
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
								OutputTile.SetPixel(i+TileX*TileWidth,j+TileY*TileHeight,TileColorPrimary);
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
							OutputTile.SetPixel(i+TileX*TileWidth,j+TileY*TileHeight,TileColorPrimary);
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
				{//Files an open tile.
				DrawSolidTile(OutputTile,TileX,TileY,TileWidth,TileHeight,TileColorPrimary);
				break;
				}
			default:
				{//Does not draw anything.
				DrawSolidTile(OutputTile,TileX,TileY,TileWidth,TileHeight,Color.clear);
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
	private void DrawSolidTile(Texture2D OutputTile, int TileX, int TileY, int TileWidth, int TileHeight, Color InputColour)
	{
		for (int i = 0; i<TileWidth; i++)
		{
			for (int j=0; j<TileHeight;j++)
			{
				OutputTile.SetPixel(i+ TileX * TileWidth, j+ TileY * TileHeight,InputColour);
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
	private void DrawOpenTile(int LevelNo, Texture2D OutputTile, int TileX, int TileY, int TileWidth, int TileHeight, Color InputColour)
	{
		//Check the tile to the north
		if (TileY<63)
			{
			if ((GetTileType(LevelNo, TileX,TileY+1)==TILE_SOLID) && (GetTileRender(LevelNo, TileX,TileY+1)==1))
				{//Solid tile to the north.
				DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,Color.black,NORTH);
				}
			}
		//Check the tile to the south
		if (TileY>0)
			{
			if ((GetTileType(LevelNo, TileX,TileY-1)==TILE_SOLID) && (GetTileRender(LevelNo,TileX,TileY-1)==1))
				{//Solid tile to the south.
					DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,Color.black,SOUTH);
				}
			}
		//Check the tile to the east
		if (TileX <63)
			{
			if ((GetTileType(LevelNo, TileX+1,TileY)==TILE_SOLID) && (GetTileRender(LevelNo, TileX+1,TileY)==1))
				{
				DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,Color.black,EAST);
				}
			}
		//Check the tile to the west
		if (TileX >0)
		{
		if ((GetTileType(LevelNo, TileX-1,TileY)==TILE_SOLID) && (GetTileRender(LevelNo, TileX-1,TileY)==1))
			{
				DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,Color.black,WEST);
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
	private void DrawLine(Texture2D OutputTile, int TileX, int TileY, int TileWidth, int TileHeight, Color InputColour, int Direction)
	{
		switch (Direction)
		{
		case NORTH:
			{//Border to the north.
			for (int i = 0; i<TileWidth; i++)
				{
				OutputTile.SetPixel(i+ TileX * TileWidth, TileHeight + TileY * TileHeight,InputColour);
				}
			break;
			}
		case SOUTH:
			{//Border to the south.
			for (int i = 0; i<TileWidth; i++)
				{
				OutputTile.SetPixel(i+ TileX * TileWidth, 0 + TileY * TileHeight,InputColour);
				}
			break;
			}
		case EAST:
			{//Border to the east.
			for (int j=0; j<TileHeight;j++)
				{
				OutputTile.SetPixel(TileWidth + TileX * TileWidth, j+ TileY * TileHeight,InputColour);
				}
			break;
			}
		case WEST:
			{//Border to the west.
			for (int j=0; j<TileHeight;j++)
				{
				OutputTile.SetPixel(0+ TileX * TileWidth, j+ TileY * TileHeight,InputColour);
				}
			break;
			}
		case NORTHEAST:
			{//Diagonal
				for (int k=0; k<=TileHeight; k++)
				{
					OutputTile.SetPixel((TileWidth-k)+ TileX * TileWidth, k+ TileY * TileHeight,InputColour);
				}
				break;
			}
		case SOUTHWEST:
			{//Diagonal
			for (int k=0; k<=TileWidth; k++)
				{
				OutputTile.SetPixel(k+ TileX * TileWidth, (TileHeight-k)+ TileY * TileHeight,InputColour);
				}
			break;
			}
		case NORTHWEST:
		{//Diagonal
			for (int k=0; k<=TileWidth; k++)
			{
				OutputTile.SetPixel(k+ TileX * TileWidth, k+ TileY * TileHeight,InputColour);
			}
			break;
		}
		case SOUTHEAST:
		{//Diagonal
			for (int k=0; k<=TileWidth; k++)
			{
				OutputTile.SetPixel(k+ TileX * TileWidth, k+ TileY * TileHeight,InputColour);
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
	void DrawDiagSW(int LevelNo, Texture2D OutputTile, int TileX, int TileY, int TileWidth, int TileHeight, Color InputColour)
	{
		DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,SOUTHWEST);

		//Check the tiles to the north and east of this tile to see what needs to be drawn for borders
		if (TileY <63)
			{//north
			int TileToTest = GetTileType(LevelNo,TileX,TileY+1);
			if ((isTileOpen(TileToTest))||(TileToTest==TILE_DIAG_SW))
				{
				DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,NORTH);
				}
			}
		if (TileX <63)
			{//east
			int TileToTest = GetTileType(LevelNo,TileX+1,TileY);
			if ((isTileOpen(TileToTest))||(TileToTest==TILE_DIAG_SW))
				{
				DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,EAST);
				}
			}

		//Check South and East for solids.
		if (TileY>0)
		{//South
			if (GetTileType (LevelNo,TileX,TileY-1)== TILE_SOLID)
			{
				DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,SOUTH);
			}
		}
		
		if (TileX>0)
		{//West
			if (GetTileType (LevelNo,TileX-1,TileY)== TILE_SOLID)
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
	void DrawDiagNE(int LevelNo, Texture2D OutputTile, int TileX, int TileY, int TileWidth, int TileHeight, Color InputColour)
	{
		DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,NORTHEAST);

		//Check the tiles to the south and west of this tile to see what needs to be drawn.
		if (TileY >0)
		{//South
			int TileToTest = GetTileType(LevelNo,TileX,TileY-1);
			if ((isTileOpen(TileToTest))||(TileToTest==TILE_DIAG_NE))
			{
				DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,SOUTH);
			}
		}
		if (TileX >0)
		{//West
			int TileToTest = GetTileType(LevelNo,TileX-1,TileY);
			if ((isTileOpen(TileToTest))||(TileToTest==TILE_DIAG_NE))
			{
				DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,WEST);
			}
		}

		//Check North and East for solids.
		if (TileY<63)
		{//North
		if (GetTileType (LevelNo,TileX,TileY+1)== TILE_SOLID)
			{
				DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,NORTH);
			}
		}
		
		if (TileX<63)
		{//East
			if (GetTileType (LevelNo,TileX+1,TileY)== TILE_SOLID)
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
	void DrawDiagNW(int LevelNo, Texture2D OutputTile, int TileX, int TileY, int TileWidth, int TileHeight, Color InputColour)
	{
		DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,NORTHWEST);
		
		//Check the tiles to the south and east of this tile
		if (TileY >0)
		{//South
		int TileToTest = GetTileType(LevelNo,TileX,TileY-1);
			if ((isTileOpen(TileToTest))||(TileToTest==TILE_DIAG_NW))
			{
				DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,SOUTH);
			}
		}
		if (TileX <63)
		{//East
			int TileToTest = GetTileType(LevelNo,TileX+1,TileY);
			if ((isTileOpen(TileToTest))||(TileToTest==TILE_DIAG_NW))
			{
				DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,EAST);
			}
		}

		//Check North and West for solids.
		if (TileY<63)
		{//North
			if (GetTileType (LevelNo,TileX,TileY+1)== TILE_SOLID)
			{
				DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,NORTH);
			}
		}
		
		if (TileX>0)
		{//West
			if (GetTileType (LevelNo,TileX-1,TileY)== TILE_SOLID)
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
	void DrawDiagSE(int LevelNo, Texture2D OutputTile, int TileX, int TileY, int TileWidth, int TileHeight, Color InputColour)
	{
		DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,SOUTHEAST);
	
		//Check the tiles to the north and west of this tile
		if (TileY <63)
		{//north
			int TileToTest = GetTileType(LevelNo,TileX,TileY+1);
			if ((isTileOpen(TileToTest))||(TileToTest==TILE_DIAG_SE))
			{
				DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,NORTH);
			}
		}

		if (TileX >0)
		{//West
			int TileToTest = GetTileType(LevelNo,TileX-1,TileY);
			if ((isTileOpen(TileToTest))||(TileToTest==TILE_DIAG_SE))
			{
				DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,WEST);
			}
		}

		//Check South and East for solids.
		if (TileY>0)
			{//South
			if (GetTileType (LevelNo,TileX,TileY-1)== TILE_SOLID)
				{
				DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,SOUTH);
				}
			}

		if (TileX<63)
		{//East
			if (GetTileType (LevelNo,TileX+1,TileY)== TILE_SOLID)
			{
				DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,EAST);
			}
		}
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
		/// <param name="LevelNo">Level no.</param>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
	public int GetFloorHeight(int LevelNo,int tileX, int tileY)
	{
				return Tiles[LevelNo].FloorHeight[tileX,tileY];
	}

		/// <summary>
		/// Gets the height of the ceiling. Will always be the same value in UW1/2 varies in SHOCK.
		/// </summary>
		/// <returns>The ceiling height.</returns>
		/// <param name="LevelNo">Level no.</param>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
	public int GetCeilingHeight(int LevelNo,int tileX, int tileY)
	{
				return Tiles[LevelNo].CeilingHeight[tileX,tileY];
	}

		/// <summary>
		/// Sets the height of the floor.
		/// </summary>
		/// <param name="LevelNo">Level no.</param>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
		/// <param name="newHeight">New height.</param>
	public void SetFloorHeight(int LevelNo,int tileX, int tileY, int newHeight)
	{
				Tiles[LevelNo].FloorHeight[tileX,tileY]=newHeight;
	}

		/// <summary>
		/// Sets the height of the ceiling.
		/// </summary>
		/// <param name="LevelNo">Level no.</param>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
		/// <param name="newHeight">New height.</param>
		public void SetCeilingHeight(int LevelNo,int tileX, int tileY, int newHeight)
	{
		//Debug.Log ("ceil :" + newHeight + " was " + CeilingHeight[tileX,tileY]);
				Tiles[LevelNo].CeilingHeight[tileX,tileY]=newHeight;
	}

		/// <summary>
		/// Sets the tile and it's neighbours as visited. visited.
		/// </summary>
		/// <param name="LevelNo">Level no.</param>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
		public void SetTileVisited(int LevelNo, int tileX, int tileY)
		{

				MarkTile(LevelNo,tileX,tileY);
				MarkTile(LevelNo,tileX+1,tileY+1);
				MarkTile(LevelNo,tileX+1,tileY);
				MarkTile(LevelNo,tileX+1,tileY-1);
				MarkTile(LevelNo,tileX+0,tileY+1);
				MarkTile(LevelNo,tileX+0,tileY);
				MarkTile(LevelNo,tileX+0,tileY-1);
				MarkTile(LevelNo,tileX-1,tileY+1);
				MarkTile(LevelNo,tileX-1,tileY);
				MarkTile(LevelNo,tileX-1,tileY-1);
		/*Tiles[LevelNo].tileVisited[tileX,tileY]=true;

		Tiles[LevelNo].tileVisited[tileX+1,tileY+1]=true;
		Tiles[LevelNo].tileVisited[tileX+1,tileY]=true;
		Tiles[LevelNo].tileVisited[tileX+1,tileY-1]=true;

		Tiles[LevelNo].tileVisited[tileX+0,tileY+1]=true;
		Tiles[LevelNo].tileVisited[tileX+0,tileY]=true;
		Tiles[LevelNo].tileVisited[tileX+0,tileY-1]=true;

		Tiles[LevelNo].tileVisited[tileX-1,tileY+1]=true;
		Tiles[LevelNo].tileVisited[tileX-1,tileY]=true;
		Tiles[LevelNo].tileVisited[tileX-1,tileY-1]=true;
		*/

		}

		/// <summary>
		/// Marks the tile as visited and checks if it is in range.
		/// </summary>
		/// <param name="LevelNo">Level no.</param>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
		private void MarkTile(int LevelNo, int tileX, int tileY)
		{
				if (((tileX>=0) && (tileX<=63)) 
						&& 
						((tileY>=0) && (tileY<=63)))
				{
						Tiles[LevelNo].tileVisited[tileX,tileY]=true;
				}
		}

		/// <summary>
		/// Has the tile been already visited.
		/// </summary>
		/// <returns><c>true</c>, if tile visited was gotten, <c>false</c> otherwise.</returns>
		/// <param name="LevelNo">Level no.</param>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
	private bool GetTileVisited(int LevelNo, int tileX, int tileY)
	{
		return Tiles[LevelNo].tileVisited[tileX,tileY];
	}

		/// <summary>
		/// Is the tile water.
		/// </summary>
		/// <returns><c>true</c>, if is water was gotten, <c>false</c> otherwise.</returns>
		/// <param name="LevelNo">Level no.</param>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
	private bool GetIsWater(int LevelNo, int tileX, int tileY)
	{
		return Tiles[LevelNo].isWater[tileX,tileY];
	}

	/// <summary>
	/// Is the tile Lava
	/// </summary>
	/// <returns><c>true</c>, if is lava was gotten, <c>false</c> otherwise.</returns>
	/// <param name="LevelNo">Level no.</param>
	/// <param name="tileX">Tile x.</param>
	/// <param name="tileY">Tile y.</param>
	private bool GetIsLava(int LevelNo, int tileX, int tileY)
	{
		return Tiles[LevelNo].isLava[tileX,tileY];
	}

	/// <summary>
	/// Gets if the tile is a bridge.
	/// </summary>
	/// <returns><c>true</c>, if is bridge was gotten, <c>false</c> otherwise.</returns>
	/// <param name="LevelNo">Level no.</param>
	/// <param name="tileX">Tile x.</param>
	/// <param name="tileY">Tile y.</param>
	private bool GetIsBridge(int LevelNo, int tileX, int tileY)
	{
		return Tiles[LevelNo].isBridge[tileX,tileY];
	}

		/// <summary>
		/// Sets if the tile is water.
		/// </summary>
		/// <param name="LevelNo">Level no.</param>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
		/// <param name="iIsWater">1 is water, 0 is not.</param>
	private void SetIsWater(int LevelNo, int tileX, int tileY,int iIsWater)
	{
		if (iIsWater==1)
			{
				Tiles[LevelNo].isWater[tileX,tileY]=true;	
			}
		else
			{
				Tiles[LevelNo].isWater[tileX,tileY]=false;
			}
	}

	/// <summary>
	/// Sets if the tile is lava.
	/// </summary>
	/// <param name="LevelNo">Level no.</param>
	/// <param name="tileX">Tile x.</param>
	/// <param name="tileY">Tile y.</param>
	/// <param name="iIsLava">I is lava.</param>
	private void SetIsLava(int LevelNo, int tileX, int tileY,int iIsLava)
	{
		if (iIsLava==1)
		{
			Tiles[LevelNo].isLava[tileX,tileY]=true;	
		}
		else
		{
			Tiles[LevelNo].isLava[tileX,tileY]=false;
		}
	}

		/// <summary>
		/// Marks if the tile has a bridge.
		/// </summary>
		/// <param name="LevelNo">Level no.</param>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
		/// <param name="iIsBridge">I is bridge.</param>
		private void SetIsBridge(int LevelNo, int tileX, int tileY,int iIsBridge)
		{
			if (iIsBridge==1)
			{
				Tiles[LevelNo].isBridge[tileX,tileY]=true;	
			}
			else
			{
				Tiles[LevelNo].isBridge[tileX,tileY]=false;
			}
		}


		/// <summary>
		/// Sets the type of the tile.
		/// </summary>
		/// <param name="LevelNo">Level no.</param>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
		/// <param name="itileType">Itile type. See tile type constants on this class</param>
	private void SetTileType(int LevelNo, int tileX, int tileY,int itileType)
	{
		Tiles[LevelNo].tileType[tileX,tileY]=itileType;
	}


		/// <summary>
		/// Gets the type of the tile.
		/// </summary>
		/// <returns>The tile type.</returns>
		/// <param name="LevelNo">Level no.</param>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
	public int GetTileType(int LevelNo, int tileX, int tileY)
	{
		return Tiles[LevelNo].tileType[tileX,tileY];
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
						return Tiles[GameWorldController.instance.LevelNo].tileType[tileX,tileY];
				}			
		}



		/// <summary>
		/// Sets the tile render state. Only affects the automap.
		/// </summary>
		/// <param name="LevelNo">Level no.</param>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
		/// <param name="iRender">1= render, 0 = invisible.</param>
	private void SetTileRender(int LevelNo, int tileX, int tileY,int iRender)
	{
		Tiles[LevelNo].Render[tileX,tileY]=iRender;
	}
	
	/// <summary>
	/// Gets the tile render state. Only affects the automap.
	/// </summary>
	/// <returns>The tile render.</returns>
	/// <param name="LevelNo">Level no.</param>
	/// <param name="tileX">Tile x.</param>
	/// <param name="tileY">Tile y.</param>
	private int GetTileRender(int LevelNo, int tileX, int tileY)
	{
		return Tiles[LevelNo].Render[tileX,tileY];
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
		private void SetTileProp(int LevelNo, int tileX, int tileY, int itileType, int iRender, int FloorHeight, int CeilingHeight, int iIsWater, int iIsDoor, int iIsLava, int iIsBridge)
	{
		SetTileType (LevelNo, tileX,tileY,itileType);
		Tiles[LevelNo].Render[tileX,tileY]=iRender;
		SetFloorHeight (LevelNo, tileX,tileY,FloorHeight);
		SetCeilingHeight (LevelNo, tileX,tileY,CeilingHeight);
		SetIsWater(LevelNo, tileX,tileY,iIsWater);
		SetIsLava(LevelNo, tileX,tileY,iIsLava);
		SetIsBridge(LevelNo,tileX,tileY,iIsBridge);
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
						(float)GetFloorHeight(GameWorldController.instance.LevelNo,tileX,tileY)  * 0.15f,
						(((float)tileY) *1.2f) +0.6f 
				);	
		}


	// Use this for initialization
	void Start () {
				//Loads up the tile map info.
		Action_Moving_Platform.tm=this.gameObject.GetComponent<TileMap>();//Shock related. Need to remove.
			for (int i=0; i<9;i++)
			{
				Tiles[i] =new TileInfo();
			}
			for (int i=0; i<MapNotes.GetUpperBound(0); i ++)
			{
					MapNotes[i] = new List<MapNote>();
			}
			LoadTileMapInfo(Application.dataPath + "//..//" + UWEBase._RES + "_tileprops.txt");

			InvokeRepeating("PositionDetect",0.0f,0.02f);
		}

		/// <summary>
		/// Loads the tile map info from a config file called GAMENAME+ "_tileprops.txt"
		/// </summary>
		/// <returns><c>true</c>, if tile map info was loaded, <c>false</c> otherwise.</returns>
		/// <param name="fileName">File name.</param>
		public bool LoadTileMapInfo(string fileName)
		{
				string line;
				StreamReader fileReader = new StreamReader(fileName, Encoding.Default);
				using (fileReader)
				{
						// While there's lines left in the text file, do this:
						do
						{
								line = fileReader.ReadLine();
								if (line != null)
								{
										string[] entries = line.Split(',');
										if (entries.Length > 0)
										{
											//process here
												SetTileProp(
														int.Parse(entries[0]),
														int.Parse(entries[1]),
														int.Parse(entries[2]),
														int.Parse(entries[3]),
														int.Parse(entries[4]),
														int.Parse(entries[5]),
														int.Parse(entries[6]),
														int.Parse(entries[7]),
														int.Parse(entries[8]),
														int.Parse(entries[9]),
														int.Parse(entries[10])
												);
														
										}
								}
						}
						while (line != null);
						fileReader.Close();
						return true;
				}
		}
}