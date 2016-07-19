using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class TileMap : UWEBase {
	public TileInfo[] Tiles=new TileInfo[9];
	public int GlobalCeilingHeight = 32;
	//public static GameObject gronk;

	string LevelName;

	public List<MapNote>[] MapNotes = new List<MapNote>[9];


	const int TILE_SOLID=0;
	const int TILE_OPEN= 1;
	const int TILE_DIAG_SE= 2;
	const int TILE_DIAG_SW =3;
	const int TILE_DIAG_NE =4;
	const int TILE_DIAG_NW= 5;
	const int TILE_SLOPE_N =6;
	const int TILE_SLOPE_S= 7;
	const int TILE_SLOPE_E= 8;
	const int TILE_SLOPE_W= 9;
	const int TILE_VALLEY_NW =10;
	const int TILE_VALLEY_NE =11;
	const int TILE_VALLEY_SE= 12;
	const int TILE_VALLEY_SW =13;
	const int TILE_RIDGE_SE =14;
	const int TILE_RIDGE_SW =15;
	const int TILE_RIDGE_NW= 16;
	const int TILE_RIDGE_NE= 17;

	const int NORTH =0;
	const int SOUTH =1;
	const int EAST=2;
	const int WEST=3;
	const int NORTHWEST=4;
	const int NORTHEAST=5;
	const int SOUTHWEST=6;
	const int SOUTHEAST=7;

	//RaycastHit hit = new RaycastHit(); 
	public int visitTileX; public int visitTileY;
	public static bool OnGround=false;
	public static bool OnWater=false;
	public static bool OnLava=false;
	public GameObject feet;//For detecting the ground.
	UWCharacter playerUW;

	public void PositionDetect()
	{
				if (GameWorldController.instance.AtMainMenu==true)
				{
						return;
				}
		if (playerUW==null)
		{
			playerUW=GameWorldController.instance.playerUW;//gronk.GetComponent<UWCharacter>();
		}
		visitTileX =(int)(playerUW.transform.position.x/1.2f);
		visitTileY =(int)(playerUW.transform.position.z/1.2f);
		SetTileVisited(GameWorldController.instance.LevelNo,visitTileX,visitTileY);
		playerUW.isSwimming=((OnWater) && (!playerUW.isWaterWalking)) ;

	}

		public TileInfo current()
		{//Returns the current tile Map info.
			return Tiles[GameWorldController.instance.LevelNo];
		}

	public bool ValidTile(Vector3 location)
	{
		//Checks to see if the tile at a specified location is within the valid game world. (eg is rendered and is not a solid)
		//Assumes the map is aligned to 0,0,0

		int tileX = (int)(location.x/1.2f);
		int tileY = (int)(location.y/1.2f);
		if ((tileX>=64) || (tileX<0) || (tileY>=64) || (tileY<0))
		{//Location is outside the map
				return false;
		}
		int tileType = GetTileType(GameWorldController.instance.LevelNo,tileX,tileY);
		int isRendered = GetTileRender(GameWorldController.instance.LevelNo,tileX,tileY);
		//Debug.Log ("testing at " +location);
		//if ((tileType!=TILE_SOLID) && (isRendered==1))
		//{
			//Debug.Log("valid tile at " + location + " at x=" +tileX + " y=" + tileY + " is a " + tileType + " is " +isRendered);
		//}
		return ((tileType!=TILE_SOLID) && (isRendered==1));
	}

		public Texture2D TileMapImage()
		{
			return  TileMapImage(GameWorldController.instance.LevelNo);
		}

	public Texture2D TileMapImage(int LevelNo)
	{//Generates an image of the tilemap for display
		if (GameWorldController.instance.playerUW.playerHud.LevelNoDisplay!=null)
		{
			GameWorldController.instance.playerUW.playerHud.LevelNoDisplay.text=(LevelNo+1).ToString();
		}

		int TileSize = 4;
		Texture2D playerPosIcon = (Texture2D)Resources.Load (_RES +"/HUD/CURSORS/CURSORS_0018");
		Texture2D output= new Texture2D(64 * TileSize, 64 * TileSize, TextureFormat.ARGB32, false);
		//Init the tile map as blank first
		for (int i = 0; i<63; i++)
		{
			for (int j = 63; j>0; j--)
			{
				DrawSolidTile(output,i,j,TileSize,TileSize,Color.clear);
			}
		}

		for (int i = 0; i<63; i++)
		{
			for (int j = 63; j>0; j--)
			{
				if ((GetTileRender(LevelNo,i,j)==1) && (GetTileVisited(LevelNo,i,j)))
				{
					fillTile(LevelNo,output,i,j,TileSize,TileSize,Color.gray,Color.blue,Color.red, Color.green);
				}
			}
		}
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
		if (LevelNo==GameWorldController.instance.LevelNo)
		{//Only display the player if they are on the same map
			Color[] defaultColour= playerPosIcon.GetPixels();
			float ratioX = playerUW.transform.position.x / (64.0f*1.2f);
			float ratioY = playerUW.transform.position.z / (64.0f*1.2f);
			output.SetPixels((int)(output.width*ratioX), (int)(output.width*ratioY),playerPosIcon.width,playerPosIcon.height,defaultColour);								
		}

		// Apply all SetPixel calls
		output.Apply();

	//Display the map notes
				//Delete the map notes in memory
				foreach(Transform child in playerUW.playerHud.MapPanel.transform)
				{
						//Debug.Log(child.name.Substring(0,4) );
						if (child.name.Substring(0,4) == "_Map")
						{
								Destroy(child.transform.gameObject);
						}
				}

				for (int i=0 ; i < MapNotes[LevelNo].Count;i++)
				{
					GameObject myObj = (GameObject)Instantiate(Resources.Load("Prefabs/_MapNoteTemplate"));
					myObj.transform.parent= playerUW.playerHud.MapPanel.transform;
					myObj.GetComponent<Text>().text = MapNotes[LevelNo][i].NoteText;
					myObj.GetComponent<RectTransform>().anchoredPosition= MapNotes[LevelNo][i].NotePosition;
					myObj.GetComponent<MapNoteId>().guid = MapNotes[LevelNo][i].guid;
					myObj.GetComponent<RectTransform>().SetSiblingIndex(4);
						//myObj.transform.SetAsLastSibling();
				}
			

		return  output;
		
	}

		private void fillTile(Texture2D OutputTile, int TileX, int TileY, int TileWidth, int TileHeight, Color GroundColour,Color WaterColour, Color LavaColour, Color BridgeColour )
		{
			fillTile(GameWorldController.instance.LevelNo, OutputTile, TileX,TileY,TileWidth,TileHeight,GroundColour,WaterColour,LavaColour,BridgeColour);
		}

	private void fillTile(int LevelNo, Texture2D OutputTile, int TileX, int TileY, int TileWidth, int TileHeight, Color GroundColour,Color WaterColour, Color LavaColour, Color BridgeColour )
	{
		Color TileColorPrimary;
		Color TileColorSecondary;
		//Fills a non square tile.
		if (GetIsWater(LevelNo,TileX,TileY)==true)
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
				{
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
				{
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
				{
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
				{
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
				{
				DrawSolidTile(OutputTile,TileX,TileY,TileWidth,TileHeight,TileColorPrimary);
				break;
				}
			default:
				{
				DrawSolidTile(OutputTile,TileX,TileY,TileWidth,TileHeight,Color.clear);
				break;
				}
			}

	}



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

	private void DrawLine(Texture2D OutputTile, int TileX, int TileY, int TileWidth, int TileHeight, Color InputColour, int Direction)
	{//Draws a line at the specified border.
		switch (Direction)
		{
		case NORTH:
			{
			for (int i = 0; i<TileWidth; i++)
				{
				OutputTile.SetPixel(i+ TileX * TileWidth, TileHeight + TileY * TileHeight,InputColour);
				}
			break;
			}
		case SOUTH:
			{
			for (int i = 0; i<TileWidth; i++)
				{
				OutputTile.SetPixel(i+ TileX * TileWidth, 0 + TileY * TileHeight,InputColour);
				}
			break;
			}
		case EAST:
			{
			for (int j=0; j<TileHeight;j++)
				{
				OutputTile.SetPixel(TileWidth + TileX * TileWidth, j+ TileY * TileHeight,InputColour);
				}
			break;
			}
		case WEST:
			{
			for (int j=0; j<TileHeight;j++)
				{
				OutputTile.SetPixel(0+ TileX * TileWidth, j+ TileY * TileHeight,InputColour);
				}
			break;
			}
		case NORTHEAST:
			{
				for (int k=0; k<=TileHeight; k++)
				{
					OutputTile.SetPixel((TileWidth-k)+ TileX * TileWidth, k+ TileY * TileHeight,InputColour);
				}
				break;
			}
		case SOUTHWEST:
			{
			for (int k=0; k<=TileWidth; k++)
				{
				OutputTile.SetPixel(k+ TileX * TileWidth, (TileHeight-k)+ TileY * TileHeight,InputColour);
				}
			break;
			}
		case NORTHWEST:
		{
			for (int k=0; k<=TileWidth; k++)
			{
				OutputTile.SetPixel(k+ TileX * TileWidth, k+ TileY * TileHeight,InputColour);
			}
			break;
		}
		case SOUTHEAST:
		{
			for (int k=0; k<=TileWidth; k++)
			{
				OutputTile.SetPixel(k+ TileX * TileWidth, k+ TileY * TileHeight,InputColour);
			}
			break;
		}
		}
	}

	void DrawDiagSW(int LevelNo, Texture2D OutputTile, int TileX, int TileY, int TileWidth, int TileHeight, Color InputColour)
	{
		//DrawOpenTile(OutputTile,TileX,TileY,TileWidth,TileHeight,Color.magenta);"
		DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,SOUTHWEST);

		//Check the tiles to the north and east of this tile
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


	void DrawDiagNE(int LevelNo, Texture2D OutputTile, int TileX, int TileY, int TileWidth, int TileHeight, Color InputColour)
	{
		//DrawOpenTile(OutputTile,TileX,TileY,TileWidth,TileHeight,Color.magenta);
		DrawLine (OutputTile,TileX,TileY,TileWidth,TileHeight,InputColour,NORTHEAST);

		//Check the tiles to the south and west of this tile
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

	void DrawDiagSE(int LevelNo, Texture2D OutputTile, int TileX, int TileY, int TileWidth, int TileHeight, Color InputColour)
	{
		//DrawOpenTile(OutputTile,TileX,TileY,TileWidth,TileHeight,Color.magenta);
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


		public int GetFloorHeight(int LevelNo,int tileX, int tileY)
	{
				return Tiles[LevelNo].FloorHeight[tileX,tileY];
	}

		public int GetCeilingHeight(int LevelNo,int tileX, int tileY)
	{
				return Tiles[LevelNo].CeilingHeight[tileX,tileY];
	}

		public void SetFloorHeight(int LevelNo,int tileX, int tileY, int newHeight)
	{
		//Debug.Log ("floor :" + newHeight + " was " + FloorHeight[tileX,tileY]);
				Tiles[LevelNo].FloorHeight[tileX,tileY]=newHeight;
	}

		public void SetCeilingHeight(int LevelNo,int tileX, int tileY, int newHeight)
	{
		//Debug.Log ("ceil :" + newHeight + " was " + CeilingHeight[tileX,tileY]);
				Tiles[LevelNo].CeilingHeight[tileX,tileY]=newHeight;
	}

	private void SetTileVisited(int LevelNo, int tileX, int tileY)
		{

		Tiles[LevelNo].tileVisited[tileX,tileY]=true;

		Tiles[LevelNo].tileVisited[tileX+1,tileY+1]=true;
		Tiles[LevelNo].tileVisited[tileX+1,tileY]=true;
		Tiles[LevelNo].tileVisited[tileX+1,tileY-1]=true;

		Tiles[LevelNo].tileVisited[tileX+0,tileY+1]=true;
		Tiles[LevelNo].tileVisited[tileX+0,tileY]=true;
		Tiles[LevelNo].tileVisited[tileX+0,tileY-1]=true;

		Tiles[LevelNo].tileVisited[tileX-1,tileY+1]=true;
		Tiles[LevelNo].tileVisited[tileX-1,tileY]=true;
		Tiles[LevelNo].tileVisited[tileX-1,tileY-1]=true;

		}

	private bool GetTileVisited(int tileX, int tileY)
	{
		return GetTileVisited(GameWorldController.instance.LevelNo,tileX,tileY);
	}

	private bool GetTileVisited(int LevelNo, int tileX, int tileY)
	{
		return Tiles[LevelNo].tileVisited[tileX,tileY];
	}

	private bool GetIsWater(int tileX, int tileY)
	{
		return GetIsWater(GameWorldController.instance.LevelNo,tileX,tileY);
	}

	private bool GetIsWater(int LevelNo, int tileX, int tileY)
	{
		return Tiles[LevelNo].isWater[tileX,tileY];
	}

	private bool GetIsLava(int tileX, int tileY)
	{
		return GetIsLava(GameWorldController.instance.LevelNo,tileX,tileY);
	}

	private bool GetIsLava(int LevelNo, int tileX, int tileY)
	{
		return Tiles[LevelNo].isLava[tileX,tileY];
	}

	private void SetIsWater(int tileX, int tileY,int iIsWater)
	{
		SetIsWater(GameWorldController.instance.LevelNo,tileX,tileY,iIsWater);
	}

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

	private void SetIsLava(int tileX, int tileY,int iIsLava)
	{
		SetIsLava(GameWorldController.instance.LevelNo,tileX,tileY,iIsLava)	;
	}

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

	private void SetTileType(int tileX, int tileY,int itileType)
	{
		SetTileType(GameWorldController.instance.LevelNo,tileX,tileY,itileType);
	}

	private void SetTileType(int LevelNo, int tileX, int tileY,int itileType)
	{
		Tiles[LevelNo].tileType[tileX,tileY]=itileType;
	}


	private int GetTileType( int tileX, int tileY)
	{
		return GetTileType(GameWorldController.instance.LevelNo,tileX,tileY);
	}

	private int GetTileType(int LevelNo, int tileX, int tileY)
	{
		return Tiles[LevelNo].tileType[tileX,tileY];
	}

	private void SetTileRender(int tileX, int tileY,int iRender)
	{
		SetTileRender(GameWorldController.instance.LevelNo,tileX,tileY,iRender);
	}

	private void SetTileRender(int LevelNo, int tileX, int tileY,int iRender)
	{
		Tiles[LevelNo].Render[tileX,tileY]=iRender;
	}
	
	private int GetTileRender(int tileX, int tileY)
	{
		return GetTileRender(GameWorldController.instance.LevelNo,tileX,tileY);
	}

	private int GetTileRender(int LevelNo, int tileX, int tileY)
	{
		return Tiles[LevelNo].Render[tileX,tileY];
	}

	private void SetTileProp(int LevelNo, int tileX, int tileY, int itileType, int iRender, int FloorHeight, int CeilingHeight, int iIsWater, int iIsDoor, int iIsLava)
	{


	//	tileType[tileX,tileY]=tileType;
		SetTileType (LevelNo, tileX,tileY,itileType);
		Tiles[LevelNo].Render[tileX,tileY]=iRender;
		//FloorHeight[tileX,tileY]=FloorHeight;
		SetFloorHeight (LevelNo, tileX,tileY,FloorHeight);
		SetCeilingHeight (LevelNo, tileX,tileY,CeilingHeight);

		SetIsWater(LevelNo, tileX,tileY,iIsWater);
		SetIsLava(LevelNo, tileX,tileY,iIsLava);
		//CeilingHeight[tileX,tileY]=CeilingHeight;

	}

	// Use this for initialization
	void Start () {
		Action_Moving_Platform.tm=this.gameObject.GetComponent<TileMap>();
		//GoblinAI.tm= this.gameObject.GetComponent<TileMap>();
				for (int i=0; i<9;i++)
				{
					Tiles[i] =new TileInfo();
				}
				for (int i=0; i<MapNotes.GetUpperBound(0); i ++)
				{
						MapNotes[i] = new List<MapNote>();
				}
				//THIS IS AWFUL!!!!! 
				LoadTileMapInfo(Application.dataPath + "//..//" + UWEBase._RES + "_tileprops.txt");

				InvokeRepeating("PositionDetect",0.0f,0.02f);
		}


		public bool LoadTileMapInfo(string fileName)
		{
				//Levelno,tilex,tiley,tileType,render,floorheight,ceilingheight,iswater,isdoor,islava
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
														int.Parse(entries[9])
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
