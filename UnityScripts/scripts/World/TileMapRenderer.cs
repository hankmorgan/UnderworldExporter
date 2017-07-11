using UnityEngine;
using System.Collections;

/// <summary>
/// Tile map renderer.
/// </summary>
/// Renders the tile map in 3d
public class TileMapRenderer : Loader{

		const int  TILE_SOLID= 0;
		const int  TILE_OPEN= 1;

		//Note the order of these 4 tiles are actually different in SHOCK. I swap them around in BuildTileMapShock for consistancy

		const int  TILE_DIAG_SE= 2;
		const int  TILE_DIAG_SW =3;
		const int  TILE_DIAG_NE= 4;
		const int  TILE_DIAG_NW =5;

		const int  TILE_SLOPE_N =6;
		const int  TILE_SLOPE_S =7;
		const int  TILE_SLOPE_E =8;
		const int  TILE_SLOPE_W =9;
		const int  TILE_VALLEY_NW =10;
		const int  TILE_VALLEY_NE= 11;
		const int  TILE_VALLEY_SE =12;
		const int  TILE_VALLEY_SW= 13;
		const int  TILE_RIDGE_SE= 14;
		const int  TILE_RIDGE_SW= 15;
		const int  TILE_RIDGE_NW= 16;
		const int  TILE_RIDGE_NE =17;

		const int SLOPE_BOTH_PARALLEL= 0;
		const int SLOPE_BOTH_OPPOSITE= 1;
		const int SLOPE_FLOOR_ONLY =2;
		const int SLOPE_CEILING_ONLY= 3;

		//Visible faces indices
		const int vTOP =0;
		const int vEAST =1;
		const int vBOTTOM= 2;
		const int vWEST= 3;
		const int vNORTH= 4;
		const int vSOUTH= 5;

		//public const int LayerFloor=0;
		//public const int LayerCeil=1;
		

		//BrushFaces
		const int fSELF =128;
		const int fCEIL= 64;
		const int fNORTH =32;
		const int fSOUTH =16;
		const int fEAST= 8;
		const int fWEST= 4;
		const int fTOP =2;
		const int fBOTTOM= 1;

		//Door headings
		const int NORTH=180;
		const int SOUTH=0;
		const int EAST=270;
		const int WEST=90;



		//static int UW_CEILING_HEIGHT;
		static int CEILING_HEIGHT;

		const int CEIL_ADJ =0;
		const int FLOOR_ADJ =0;//-2;

		const float doorwidth = 0.8f;
		const float doorframewidth = 1.2f;
		const float doorSideWidth = (doorframewidth-doorwidth)/2f;
		const float doorheight = 7f * 0.15f;

		/// <summary>
		/// Generates the level from tile map.
		/// </summary>
		/// <param name="parent">Parent.</param>
		/// <param name="sceneryParent">Scenery parent.</param>
		/// <param name="game">Game.</param>
		/// <param name="Level">Level.</param>
		/// <param name="objList">Object list.</param>
		/// <param name="UpdateOnly">If set to <c>true</c> update only.</param>
		public static void GenerateLevelFromTileMap(GameObject parent, GameObject sceneryParent, string game, TileMap Level, ObjectLoader objList, bool UpdateOnly)
		{
			bool skipCeil=true;
			CEILING_HEIGHT=Level.CEILING_HEIGHT;			
			if (game==GAME_SHOCK)
			{
				skipCeil=false;
			}
			
			if (!UpdateOnly)
			{
				//Clear out the children in the transform
				foreach (Transform child in parent.transform) {
						GameObject.Destroy(child.gameObject);
				}
				foreach (Transform child in sceneryParent.transform) {
						GameObject.Destroy(child.gameObject);
				}
			}

			for (int y = 0; y <= TileMap.TileMapSizeY; y++)
			{
				for (int x = 0; x <= TileMap.TileMapSizeX; x++)
				{
					if ( 
							( 
							(UpdateOnly) && (Level.Tiles[x,y].NeedsReRender) 
							)
							||
							(
									!UpdateOnly
							)
					)
					{
							RenderTile(parent, x, y, Level.Tiles[x,y], false, false, false, skipCeil);

							if (game!=GAME_SHOCK)
							{//Water
									RenderTile(parent, x, y, Level.Tiles[x,y], true, false, false, skipCeil);
									Level.Tiles[x,y].NeedsReRender=false;
							}		
					}
					Level.Tiles[x,y].NeedsReRender=false;
				}
			}

			//Do a ceiling

			if (game != GAME_SHOCK)
			{
				if (!UpdateOnly)
				{
					TileInfo tmp=new TileInfo();
					//Ceiling
					tmp.tileType = 1;
					tmp.Render = 1;
					tmp.isWater = false;
					tmp.tileX = 0;
					tmp.tileY = 0;
					tmp.DimX = TileMap.TileMapSizeX+1;
					tmp.DimY = TileMap.TileMapSizeY+1;
					tmp.ceilingHeight = 0;
					tmp.floorTexture = Level.Tiles[0,0].shockCeilingTexture;
					tmp.shockCeilingTexture = Level.Tiles[0,0].shockCeilingTexture;
					tmp.East = Level.Tiles[0,0].shockCeilingTexture;//CAULK;
					tmp.West = Level.Tiles[0,0].shockCeilingTexture;//CAULK;
					tmp.North = Level.Tiles[0,0].shockCeilingTexture;//CAULK;
					tmp.South = Level.Tiles[0,0].shockCeilingTexture;//CAULK;
					tmp.VisibleFaces[vTOP] = 0;
					tmp.VisibleFaces[vEAST] = 0;
					tmp.VisibleFaces[vBOTTOM] = 1;
					tmp.VisibleFaces[vWEST] = 0;
					tmp.VisibleFaces[vNORTH] = 0;
					tmp.VisibleFaces[vSOUTH] = 0;
					// top,east,bottom,west,north,south
					RenderTile(sceneryParent, tmp.tileX, tmp.tileX, tmp, false, false, true, false);	
				
				//And at 99,99 for special stuff.
				for (short x = TileMap.ObjectStorageTile-1; x <= TileMap.ObjectStorageTile+1; x++)
				{
					for (short y = TileMap.ObjectStorageTile-1; y <=TileMap.ObjectStorageTile+1; y++)
					{
						tmp.tileX = x;
						tmp.tileY = y;
						if ((x != TileMap.ObjectStorageTile) || (y != TileMap.ObjectStorageTile))
						{
							tmp.tileType = 0;
						}
						else
						{
							tmp.tileType = 1;
						}
						RenderTile(sceneryParent, x, y, tmp, false, false, false, false);
					}
				}
			}
		}
		if (!UpdateOnly)
			{
				//Render bridges, pillars and door ways
				switch (_RES)
				{
				case GAME_SHOCK:
						break;
				default:
						RenderBridges(sceneryParent,Level,objList);
						RenderPillars(sceneryParent,Level,objList);
						RenderDoorways (sceneryParent,Level,objList);
						break;
				}

			}
		}

		/// <summary>
		/// Renders the doorways.
		/// </summary>
		/// <param name="Parent">Parent.</param>
		/// <param name="level">Level.</param>
		/// <param name="objList">Object list.</param>
		public static void RenderDoorways(GameObject Parent, TileMap level, ObjectLoader objList)
		{
				if (objList==null)
				{
						return;
				}
				for (int i=0; i<=objList.objInfo.GetUpperBound(0);i++)
				{
						if (((objList.objInfo[i].item_id>=320) && (objList.objInfo[i].item_id<=335)) && (objList.objInfo[i].InUseFlag==1))
						{
								RenderDoorwayFront(Parent,level,objList,objList.objInfo[i]);
								RenderDoorwayRear(Parent,level,objList,objList.objInfo[i]);
						}
				}
		}


		/// <summary>
		/// Renders the doorway frame from the rear
		/// </summary>
		/// <param name="Parent">Parent.</param>
		/// <param name="level">Level.</param>
		/// <param name="objList">Object list.</param>
		/// <param name="currDoor">Curr door.</param>
		public static void RenderDoorwayRear(GameObject Parent, TileMap level, ObjectLoader objList, ObjectLoaderInfo currDoor)
		{
				Material[] MatsToUse = new Material[1];
				for (int j = 0; j<=MatsToUse.GetUpperBound(0);j++)
				{
						MatsToUse[j]= GameWorldController.instance.MaterialMasterList[ GameWorldController.instance.currentTileMap().texture_map[GameWorldController.instance.currentTileMap().Tiles[currDoor.tileX,currDoor.tileY].wallTexture]];				
				}
				float floorheight =(float) level.Tiles[currDoor.tileX,currDoor.tileY].floorHeight * 0.15f;

				//Uv ratios across the x axis of the door
				float uvXPos1 = 0f;
				float uvXPos2 = uvXPos1 + doorSideWidth/ 1.2f;
				float uvXPos3 =uvXPos2 + doorwidth/1.2f;
				float uvXPos4 = 1f; // or 1.2f/1.2f

				//positions
				Vector3 position = objList.CalcObjectXYZ(_RES,level,level.Tiles,objList.objInfo,currDoor.index, currDoor.tileX, currDoor.tileY,0);
				//center in the tile and at the bottom of the map.
				switch (currDoor.heading*45)
				{
				case EAST:
				case WEST:
						position =new Vector3( position.x-0.02f, 0f, currDoor.tileY*1.2f + 1.2f / 2f);
						break;
				case NORTH:
				case SOUTH:
						position =new Vector3( currDoor.tileX*1.2f + 1.2f / 2f, 0f, position.z-0.02f);
						break;
				}


				//float y0 = 0f;//+doorthickness /2f;
				float y1 = 0f;//-doorthickness /2f;
				float x0 = -doorframewidth /2f;
				float x1 = +doorframewidth /2f;
				float z0 = 0f;
				float z1 = CEILING_HEIGHT*0.15f;

				//My vertex tris
				Vector3[] leftHand = new Vector3[4];
				switch (currDoor.heading*45)
				{
				case EAST:
				case WEST: //Swap x and y
						leftHand[0] = new Vector3(y1,x0,z0);
						leftHand[1] = new Vector3(y1,x0,z1);
						leftHand[2] = new Vector3(y1,x0 + doorSideWidth,z1);
						leftHand[3] = new Vector3(y1,x0 + doorSideWidth,z0);
						break;
				case NORTH:
				case SOUTH:
				default:
						leftHand[0] = new Vector3(x0,y1,z0);
						leftHand[1] = new Vector3(x0,y1,z1);
						leftHand[2] = new Vector3(x0 + doorSideWidth,y1,z1);
						leftHand[3] = new Vector3(x0 + doorSideWidth,y1,z0);
						break;
				}



				Vector2[] UVs = new Vector2[4];
				UVs[0]= new Vector2(uvXPos1,0f);
				UVs[1]= new Vector2(uvXPos1,4);
				UVs[2]= new Vector2(uvXPos2,4);
				UVs[3]= new Vector2(uvXPos2,0f);

				GameObject tile = RenderCuboid(Parent,leftHand,UVs,position,MatsToUse,1,"rear_leftside_" + ObjectLoader.UniqueObjectName(currDoor));
				tile.transform.Rotate(new Vector3(0f,0f,-180f));


				//y0 = +doorthickness /2f;
				//y1 = -doorthickness /2f;
				x0 = -doorwidth /2f;
				x1 = +doorwidth /2f;
				z0 = 0f+ floorheight + doorheight;
				z1 = CEILING_HEIGHT*0.15f;
				//1.2
				Vector3[] overHead = new Vector3[4];
				switch (currDoor.heading*45)
				{
				case EAST:
				case WEST: //Swap x and y
						overHead[0] = new Vector3(y1,x0,z0);
						overHead[1] = new Vector3(y1,x0,z1);
						overHead[2] = new Vector3(y1,x1,z1);
						overHead[3] = new Vector3(y1,x1,z0);
						break;
				case NORTH:
				case SOUTH:
				default:
						overHead[0] = new Vector3(x0,y1,z0);
						overHead[1] = new Vector3(x0,y1,z1);
						overHead[2] = new Vector3(x1,y1,z1);
						overHead[3] = new Vector3(x1,y1,z0);
						break;					
				}


				float dist = (z0) /0.15f;//Get back to steps.
				dist=dist/8f;


				//Vector2[] UVs = new Vector2[4];
				UVs[0]= new Vector2(uvXPos2, dist);
				UVs[1]= new Vector2(uvXPos2, CEILING_HEIGHT/8f);
				UVs[2]= new Vector2(uvXPos3, CEILING_HEIGHT/8f);
				UVs[3]= new Vector2(uvXPos3, dist);

				tile = RenderCuboid(Parent,overHead,UVs,position,MatsToUse,1,"rear_over_" + ObjectLoader.UniqueObjectName(currDoor));
				tile.transform.Rotate(new Vector3(0f,0f,-180f));//TODO:FIx for headings.
				if ((_RES==GAME_UW1) && (currDoor.tileX==12) && (currDoor.tileY==51) && (level.thisLevelNo==3))
				{//Special case for possible map bug
						tile.layer= LayerMask.NameToLayer ("UWObjects");	
				}
				//y0 = +doorthickness /2f;
				//y1 = -doorthickness /2f;
				x0 = -doorframewidth /2f;
				x1 = +doorframewidth /2f;
				z0 = 0f;
				z1 = CEILING_HEIGHT*0.15f;
				//My vertex tris
				Vector3[] rightHand = new Vector3[4];

				switch (currDoor.heading*45)
				{
				case EAST:
				case WEST: //Swap x and y
						rightHand[0] = new Vector3( y1,x0 + doorSideWidth + doorwidth,z0);
						rightHand[1] = new Vector3( y1,x0 + doorSideWidth + doorwidth,z1);
						rightHand[2] = new Vector3( y1,x0 + doorSideWidth + doorwidth + doorSideWidth,z1);
						rightHand[3] = new Vector3( y1,x0 + doorSideWidth + doorwidth + doorSideWidth,z0);
						break;
				case NORTH:
				case SOUTH:						
				default:
						rightHand[0] = new Vector3(x0 + doorSideWidth + doorwidth, y1,z0);
						rightHand[1] = new Vector3(x0 + doorSideWidth + doorwidth, y1,z1);
						rightHand[2] = new Vector3(x0 + doorSideWidth + doorwidth + doorSideWidth,y1,z1);
						rightHand[3] = new Vector3(x0 + doorSideWidth + doorwidth + doorSideWidth,y1,z0);
						break;
				}

				UVs = new Vector2[4];
				UVs[0]= new Vector2(uvXPos3,0f);
				UVs[1]= new Vector2(uvXPos3,4);
				UVs[2]= new Vector2(uvXPos4,4);
				UVs[3]= new Vector2(uvXPos4,0f);

				tile = RenderCuboid(Parent,rightHand,UVs,position,MatsToUse,1,"rear_rightside_" + ObjectLoader.UniqueObjectName(currDoor));
				tile.transform.Rotate(new Vector3(0f,0f,-180f));

		}


		/// <summary>
		/// Renders the doorway front portion
		/// </summary>
		/// <param name="Parent">Parent.</param>
		/// <param name="level">Level.</param>
		/// <param name="objList">Object list.</param>
		/// <param name="currDoor">Curr door.</param>
		public static void RenderDoorwayFront(GameObject Parent, TileMap level, ObjectLoader objList, ObjectLoaderInfo currDoor)
		{

				Material[] MatsToUse = new Material[1];
				for (int j = 0; j<=MatsToUse.GetUpperBound(0);j++)
				{
						MatsToUse[j]= GameWorldController.instance.MaterialMasterList[ GameWorldController.instance.currentTileMap().texture_map[GameWorldController.instance.currentTileMap().Tiles[currDoor.tileX,currDoor.tileY].wallTexture]];
				}
				//Door params
				float floorheight =(float) level.Tiles[currDoor.tileX,currDoor.tileY].floorHeight * 0.15f;

				//Uv ratios across the x axis of the door
				float uvXPos1 = 0f;
				float uvXPos2 = uvXPos1 + doorSideWidth/ 1.2f;
				float uvXPos3 =uvXPos2 + doorwidth/1.2f;
				float uvXPos4 = 1f; // or 1.2f/1.2f

				//Vector3 doorposition;
				//positions
				Vector3 position = objList.CalcObjectXYZ(_RES,level,level.Tiles,objList.objInfo,currDoor.index, currDoor.tileX, currDoor.tileY,0);
				//doorposition=position;
				//center in the tile and at the bottom of the map.
				switch (currDoor.heading*45)
				{
				case EAST:
				case WEST:
						position =new Vector3( position.x+0.02f, 0f, currDoor.tileY*1.2f + 1.2f / 2f);
						break;
				case NORTH:
				case SOUTH:
						position =new Vector3( currDoor.tileX*1.2f + 1.2f / 2f, 0f, position.z+0.02f);
						break;
				}

				float y0 = 0f;//+doorthickness /2f;
				//float y1 = 0f;//-doorthickness /2f;
				float x0 = -doorframewidth /2f;
				float x1 = +doorframewidth /2f;
				float z0 = 0f;
				float z1 = CEILING_HEIGHT*0.15f;

				//My vertex tris

				Vector3[] leftHand = new Vector3[4];

				switch (currDoor.heading*45)
				{
				case EAST:
				case WEST: //Swap x and y
						leftHand[0] = new Vector3(y0,x0,z0);
						leftHand[1] = new Vector3(y0,x0,z1);
						leftHand[2] = new Vector3(y0,x0 + doorSideWidth,z1);
						leftHand[3] = new Vector3(y0,x0 + doorSideWidth,z0);
						break;
				case NORTH:
				case SOUTH:
				default:
						leftHand[0] = new Vector3(x0,y0,z0);
						leftHand[1] = new Vector3(x0,y0,z1);
						leftHand[2] = new Vector3(x0 + doorSideWidth,y0,z1);
						leftHand[3] = new Vector3(x0 + doorSideWidth,y0,z0);
						break;
				}
				Vector2[] UVs = new Vector2[4];
				//UVs[0]= new Vector2(0f,0f);
				//UVs[1]= new Vector2(0f,4);
				//UVs[2]= new Vector2(doorSideWidth,4);
				//UVs[3]= new Vector2(doorSideWidth,0f);

				UVs[0]= new Vector2(uvXPos1,0f);
				UVs[1]= new Vector2(uvXPos1,4);
				UVs[2]= new Vector2(uvXPos2,4);
				UVs[3]= new Vector2(uvXPos2,0f);


				RenderCuboid(Parent,leftHand,UVs,position,MatsToUse,1,"front_leftside_" + ObjectLoader.UniqueObjectName(currDoor));



				//y0 = +doorthickness /2f;
				//y1 = -doorthickness /2f;
				x0 = -doorwidth /2f;
				x1 = +doorwidth /2f;
				z0 = 0f+ floorheight + doorheight;
				z1 = CEILING_HEIGHT*0.15f;
				//1.2
				Vector3[] overHead = new Vector3[4];

				switch (currDoor.heading*45)
				{
				case EAST:
				case WEST: //Swap x and y
						overHead[0] = new Vector3(y0,x0,z0);
						overHead[1] = new Vector3(y0,x0,z1);
						overHead[2] = new Vector3(y0,x1,z1);
						overHead[3] = new Vector3(y0,x1,z0);
						break;
				case NORTH:
				case SOUTH:
				default:
						overHead[0] = new Vector3(x0,y0,z0);
						overHead[1] = new Vector3(x0,y0,z1);
						overHead[2] = new Vector3(x1,y0,z1);
						overHead[3] = new Vector3(x1,y0,z0);
						break;
				}
				float dist = (z0) /0.15f;//Get back to steps.
				dist=dist/8f;


				//Vector2[] UVs = new Vector2[4];
				//UVs[0]= new Vector2(0+doorSideWidth, dist);
				//UVs[1]= new Vector2(0+doorSideWidth, CEILING_HEIGHT/8f);
				//UVs[2]= new Vector2(doorwidth-doorSideWidth, CEILING_HEIGHT/8f);
				//UVs[3]= new Vector2(doorwidth-doorSideWidth, dist);
				UVs[0]= new Vector2(uvXPos2, dist);
				UVs[1]= new Vector2(uvXPos2, CEILING_HEIGHT/8f);
				UVs[2]= new Vector2(uvXPos3, CEILING_HEIGHT/8f);
				UVs[3]= new Vector2(uvXPos3, dist);


				GameObject tile = RenderCuboid(Parent,overHead,UVs,position,MatsToUse,1,"front_over_" + ObjectLoader.UniqueObjectName(currDoor));
				if ((_RES==GAME_UW1) && (currDoor.tileX==12) && (currDoor.tileY==51) && (level.thisLevelNo==3))
				{//Special case for possible map bug
					tile.layer= LayerMask.NameToLayer ("UWObjects");	
				}

				//y0 = +doorthickness /2f;
				//y1 = -doorthickness /2f;
				x0 = -doorframewidth /2f;
				x1 = +doorframewidth /2f;
				z0 = 0f;
				z1 = CEILING_HEIGHT*0.15f;
				//My vertex tris
				Vector3[] rightHand = new Vector3[4];

				switch (currDoor.heading*45)
				{
				case EAST:
				case WEST: //Swap x and y
						rightHand[0] = new Vector3(y0,x0 + doorSideWidth + doorwidth, z0);
						rightHand[1] = new Vector3(y0,x0 + doorSideWidth + doorwidth, z1);
						rightHand[2] = new Vector3(y0,x0 + doorSideWidth + doorwidth + doorSideWidth,z1);
						rightHand[3] = new Vector3(y0,x0 + doorSideWidth + doorwidth + doorSideWidth,z0);
						break;
				case NORTH:
				case SOUTH:
				default:
						rightHand[0] = new Vector3(x0 + doorSideWidth + doorwidth, y0,z0);
						rightHand[1] = new Vector3(x0 + doorSideWidth + doorwidth, y0,z1);
						rightHand[2] = new Vector3(x0 + doorSideWidth + doorwidth + doorSideWidth,y0,z1);
						rightHand[3] = new Vector3(x0 + doorSideWidth + doorwidth + doorSideWidth,y0,z0);
						break;
				}
				UVs = new Vector2[4];
				//UVs[0]= new Vector2(doorSideWidth + doorwidth,0f);
				//UVs[1]= new Vector2(doorSideWidth + doorwidth,4);
				//UVs[2]= new Vector2(doorSideWidth + doorwidth + doorSideWidth,4);
				//UVs[3]= new Vector2(doorSideWidth + doorwidth + doorSideWidth,0f);

				UVs[0]= new Vector2(uvXPos3,0f);
				UVs[1]= new Vector2(uvXPos3,4);
				UVs[2]= new Vector2(uvXPos4,4);
				UVs[3]= new Vector2(uvXPos4,0f);

				RenderCuboid(Parent,rightHand,UVs,position,MatsToUse,1,"front_rightside_" + ObjectLoader.UniqueObjectName(currDoor));

				//Some filler
				Vector3[] filler= new Vector3[12];
				int v=0;
				position = new Vector3(position.x,floorheight,position.z);
				UVs= new Vector2[12];
				UVs[0]= new Vector2(0,0f);
				UVs[1]= new Vector2(0,1);
				UVs[2]= new Vector2(1,1);
				UVs[3]= new Vector2(1,0f);	
				UVs[4]= new Vector2(0,0f);
				UVs[5]= new Vector2(0,1);
				UVs[6]= new Vector2(1,1);
				UVs[7]= new Vector2(1,0f);	
				UVs[8]= new Vector2(0,0f);
				UVs[9]= new Vector2(0,1);
				UVs[10]= new Vector2(1,1);
				UVs[11]= new Vector2(1,0f);	


				switch (currDoor.heading*45)
				{
				case EAST:
				case WEST: //Swap x and y
						//side
						v=0;
						filler[v++] = new Vector3( 0.04f,-doorwidth/2, doorheight);
						filler[v++] = new Vector3(0.04f,-doorwidth/2, 0f);
						filler[v++] = new Vector3(-0.00f,-doorwidth/2,  0f);
						filler[v++] = new Vector3(-0.00f,-doorwidth/2,  doorheight);
						RenderCuboid(Parent,filler,UVs,position,MatsToUse,1,"side1_filler_" + ObjectLoader.UniqueObjectName(currDoor));
						//over
						v=0;
						filler[v++] = new Vector3(0.00f,+doorwidth/2,  doorheight);
						filler[v++] = new Vector3(0.04f,+doorwidth/2, doorheight);
						filler[v++] = new Vector3(0.04f,-doorwidth/2,  doorheight);
						filler[v++] = new Vector3(0.00f,-doorwidth/2,  doorheight);
						GameObject fillerpiece=RenderCuboid(Parent,filler,UVs,position,MatsToUse,1,"over_filler_" + ObjectLoader.UniqueObjectName(currDoor));
						if ((_RES==GAME_UW1) && (currDoor.tileX==12) && (currDoor.tileY==51) && (level.thisLevelNo==3))
						{//Special case for possible map bug
								fillerpiece.layer= LayerMask.NameToLayer ("UWObjects");	
						}
						v=0;
						//side
						filler[v++] = new Vector3(0.04f,+doorwidth/2,  0f);
						filler[v++] = new Vector3(0.04f,+doorwidth/2, doorheight);
						filler[v++] = new Vector3(0.00f,+doorwidth/2,  doorheight);
						filler[v++] = new Vector3(0.00f,+doorwidth/2, 0f);
						RenderCuboid(Parent,filler,UVs,position,MatsToUse,1,"side2_filler_" + ObjectLoader.UniqueObjectName(currDoor));
						break;


				case NORTH:
				case SOUTH:
				default:
						//side
						v=0;
						filler[v++] = new Vector3(-doorwidth/2, 0.00f, 0f);
						filler[v++] = new Vector3(-doorwidth/2, 0.00f, doorheight);
						filler[v++] = new Vector3(-doorwidth/2, -0.04f, doorheight);
						filler[v++] = new Vector3(-doorwidth/2, -0.04f, 0f);
						RenderCuboid(Parent,filler,UVs,position,MatsToUse,1,"side1_filler_" + ObjectLoader.UniqueObjectName(currDoor));
						//over
						v=0;
						filler[v++] = new Vector3(+doorwidth/2, -0.00f, doorheight);
						filler[v++] = new Vector3(+doorwidth/2, -0.04f, doorheight);
						filler[v++] = new Vector3(-doorwidth/2, -0.04f, doorheight);
						filler[v++] = new Vector3(-doorwidth/2,  0.00f, doorheight);
						GameObject fillerPiece=RenderCuboid(Parent,filler,UVs,position,MatsToUse,1,"over_filler_" + ObjectLoader.UniqueObjectName(currDoor));
						if ((_RES==GAME_UW1) && (currDoor.tileX==12) && (currDoor.tileY==51) && (level.thisLevelNo==3))
						{//Special case for possible map bug
								fillerPiece.layer= LayerMask.NameToLayer ("UWObjects");	
						}
						v=0;
						//side
						filler[v++] = new Vector3(+doorwidth/2, 0.00f, doorheight);
						filler[v++] = new Vector3(+doorwidth/2, 0.00f, 0f);
						filler[v++] = new Vector3(+doorwidth/2, -0.04f, 0f);
						filler[v++] = new Vector3(+doorwidth/2, -0.04f, doorheight);
						RenderCuboid(Parent,filler,UVs,position,MatsToUse,1,"side2_filler_" + ObjectLoader.UniqueObjectName(currDoor));
						break;
				}



				RenderCuboid(Parent,filler,UVs,position,MatsToUse,3,"front_filler_" + ObjectLoader.UniqueObjectName(currDoor));
		}

		/// <summary>
		/// Renders the pillar models.
		/// </summary>
		/// <param name="Parent">Parent.</param>
		/// <param name="level">Level.</param>
		/// <param name="objList">Object list.</param>
		public static void RenderPillars(GameObject Parent, TileMap level, ObjectLoader objList)
		{
				if (objList==null)
				{
						return;
				}

				for (int i=0; i<=objList.objInfo.GetUpperBound(0);i++)
				{
						if ((GameWorldController.instance.objectMaster.type[objList.objInfo[i].item_id]==ObjectInteraction.PILLAR) && (objList.objInfo[i].InUseFlag==1))
						{
								Vector3 position = objList.CalcObjectXYZ(_RES,level,level.Tiles,objList.objInfo,i,(int)objList.objInfo[i].tileX,(int)objList.objInfo[i].tileY,0);
								//position =new Vector3( objList.objInfo[i].tileX*1.2f + 1.2f / 2f,position.y, objList.objInfo[i].tileY*1.2f + 1.2f / 2f);
								Vector3[] Verts= new Vector3[24];
								Vector2[] UVs= new Vector2[24];
								int t=0;
								float x1=0.03f;
								float x0 =-0.03f;
								float y0=-0.03f;
								float y1=0.03f;
								float z1=(float)(CEILING_HEIGHT * 0.15f)- position.y;
								float z0=- position.y;

								//x1
								Verts[t++] = new Vector3(x0, y1, z0);
								Verts[t++] = new Vector3(x0, y1, z1);
								Verts[t++] = new Vector3(x1, y1, z1);
								Verts[t++] = new Vector3(x1, y1, z0);

								Verts[t++] = new Vector3(x1, y0, z0);
								Verts[t++] = new Vector3(x1, y0, z1);
								Verts[t++] = new Vector3(x0, y0, z1);
								Verts[t++] = new Vector3(x0, y0, z0);

								Verts[t++] = new Vector3(x1, y1, z0);
								Verts[t++] = new Vector3(x1, y1, z1);
								Verts[t++] = new Vector3(x1, y0, z1);
								Verts[t++] = new Vector3(x1, y0, z0);

								Verts[t++] = new Vector3(x0, y0, z0);
								Verts[t++] = new Vector3(x0, y1, z0);
								Verts[t++] = new Vector3(x1, y1, z0);
								Verts[t++] = new Vector3(x1, y0, z0);

								Verts[t++] = new Vector3(x0, y0, z0);
								Verts[t++] = new Vector3(x0, y0, z1);
								Verts[t++] = new Vector3(x0, y1, z1);
								Verts[t++] = new Vector3(x0, y1, z0);

								Verts[t++] = new Vector3(x1, y0, z1);
								Verts[t++] = new Vector3(x1, y1, z1);
								Verts[t++] = new Vector3(x0, y1, z1);
								Verts[t++] = new Vector3(x0, y0, z1);


								for (int j=0; j<6;j++)
								{
										UVs[(j*4)+0]= new Vector2(0f,0f);
										UVs[(j*4)+1]= new Vector2(0f,CEILING_HEIGHT);
										UVs[(j*4)+2]= new Vector2(1f,CEILING_HEIGHT);
										UVs[(j*4)+3]= new Vector2(1f,0f);
								}
								int TextureIndex= objList.objInfo[i].flags & 0x3F;
								Material tmobj = (Material)Resources.Load(_RES+"/Materials/tmobj/tmobj_" + (TextureIndex).ToString("d2"));
								if (tmobj!=null)
								{
										if (tmobj.mainTexture==null)
										{//UW1 style bridges UW2 has some differences....
												tmobj.mainTexture=GameWorldController.instance.TmObjArt.LoadImageAt(TextureIndex);
										}
										Material[] MatsToUse = new Material[6];
										for (int j = 0; j<=MatsToUse.GetUpperBound(0);j++)
										{//tmobj[30]+(objList[x].flags & 0x3F)
												MatsToUse[j]= tmobj;//GameWorldController.instance.MaterialMasterList[j];
										}	
										RenderCuboid(Parent, Verts,UVs,position,MatsToUse,6,"pillar_" + ObjectLoader.UniqueObjectName(objList.objInfo[i]));
								}
								else
								{
										Debug.Log("RenderPillar: Missing material resource for tmobj/" + TextureIndex);
										return;
								}	
						}
				}
		}


		/// <summary>
		/// Renders bridges
		/// </summary>
		/// <param name="Parent">Parent.</param>
		/// <param name="level">Level.</param>
		/// <param name="objList">Object list.</param>
		public static void RenderBridges(GameObject Parent, TileMap level, ObjectLoader objList)
		{
				if (objList==null)
				{
						return;
				}
				for (int i=0; i<=objList.objInfo.GetUpperBound(0);i++)
				{
						if ((GameWorldController.instance.objectMaster.type[objList.objInfo[i].item_id]==ObjectInteraction.BRIDGE) && (objList.objInfo[i].InUseFlag==1))
						{
								Vector3 position = objList.CalcObjectXYZ(_RES,level,level.Tiles,objList.objInfo,i,(int)objList.objInfo[i].tileX,(int)objList.objInfo[i].tileY,0);
								position =new Vector3( objList.objInfo[i].tileX*1.2f + 1.2f / 2f,position.y, objList.objInfo[i].tileY*1.2f + 1.2f / 2f);
								Vector3[] Verts= new Vector3[24];
								Vector2[] UVs= new Vector2[24];
								int t=0;
								float x1=0.6f;
								float x0 =-0.6f;
								float y0=-0.6f;
								float y1=0.6f;
								float z1=0.075f;
								float z0=-0.075f;
								//x1
								Verts[t++] = new Vector3(x0, y1, z0);
								Verts[t++] = new Vector3(x0, y1, z1);
								Verts[t++] = new Vector3(x1, y1, z1);
								Verts[t++] = new Vector3(x1, y1, z0);

								Verts[t++] = new Vector3(x1, y0, z0);
								Verts[t++] = new Vector3(x1, y0, z1);
								Verts[t++] = new Vector3(x0, y0, z1);
								Verts[t++] = new Vector3(x0, y0, z0);

								Verts[t++] = new Vector3(x1, y1, z0);
								Verts[t++] = new Vector3(x1, y1, z1);
								Verts[t++] = new Vector3(x1, y0, z1);
								Verts[t++] = new Vector3(x1, y0, z0);

								Verts[t++] = new Vector3(x0, y0, z0);
								Verts[t++] = new Vector3(x0, y1, z0);
								Verts[t++] = new Vector3(x1, y1, z0);
								Verts[t++] = new Vector3(x1, y0, z0);

								Verts[t++] = new Vector3(x0, y0, z0);
								Verts[t++] = new Vector3(x0, y0, z1);
								Verts[t++] = new Vector3(x0, y1, z1);
								Verts[t++] = new Vector3(x0, y1, z0);

								Verts[t++] = new Vector3(x1, y0, z1);
								Verts[t++] = new Vector3(x1, y1, z1);
								Verts[t++] = new Vector3(x0, y1, z1);
								Verts[t++] = new Vector3(x0, y0, z1);

								for (int j=0; j<6;j++)
								{
										UVs[(j*4)+0]= new Vector2(0f,0f);
										UVs[(j*4)+1]= new Vector2(0f,1f);
										UVs[(j*4)+2]= new Vector2(1f,1f);
										UVs[(j*4)+3]= new Vector2(1f,0f);
								}
								int TextureIndex= objList.objInfo[i].flags & 0x3F;
								Material tmobj;
								if (TextureIndex>=2)
								{
										if (_RES==GAME_UW2)
										{
											TextureIndex= GameWorldController.instance.currentTileMap().texture_map[TextureIndex-2];		
										}
										else
										{
											TextureIndex= GameWorldController.instance.currentTileMap().texture_map[TextureIndex-2+48];	
										}

										tmobj = GameWorldController.instance.MaterialMasterList[TextureIndex];//(Material)Resources.Load(_RES+"/Materials/tmobj/tmobj_" + (30 + TextureIndex).ToString());
								}
								else
								{
										tmobj = (Material)Resources.Load(_RES+"/Materials/tmobj/tmobj_" + (30 + TextureIndex).ToString());		
										if (tmobj.mainTexture==null)
										{//UW1 style bridges UW2 has some differences....
												tmobj.mainTexture=GameWorldController.instance.TmObjArt.LoadImageAt(30 + TextureIndex);
										}
								}

								Material[] MatsToUse = new Material[6];
								for (int j = 0; j<=MatsToUse.GetUpperBound(0);j++)
								{//tmobj[30]+(objList[x].flags & 0x3F)
										MatsToUse[j]= tmobj;//GameWorldController.instance.MaterialMasterList[j];
								}
								RenderCuboid(Parent, Verts,UVs,position,MatsToUse,6,ObjectLoader.UniqueObjectName(objList.objInfo[i]));						
						}
				}
		}


		/// <summary>
		/// Renders the a tile
		/// </summary>
		/// <param name="parent">Parent.</param>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="t">T.</param>
		/// <param name="Water">If set to <c>true</c> water.</param>
		/// <param name="invert">If set to <c>true</c> invert.</param>
		/// <param name="skipFloor">If set to <c>true</c> skip floor.</param>
		/// <param name="skipCeil">If set to <c>true</c> skip ceil.</param>
		public static void RenderTile(GameObject parent, int x, int y, TileInfo t, bool Water, bool invert, bool skipFloor, bool skipCeil)
		{
				//Picks the tile to render based on tile type/flags.
				switch (t.tileType)
				{
				case TILE_SOLID:	//0
						{	//solid
								RenderSolidTile(parent, x, y, t, Water);
								return;
						}
				case TILE_OPEN:		//1
						{//open
								if (skipFloor != true) { RenderOpenTile( parent , x, y, t, Water, false); }	//floor
								if ((skipCeil  != true)) { RenderOpenTile( parent , x, y, t, Water, true); }	//ceiling	
								return;
						}
				case TILE_DIAG_SE:
						{//diag se
								if (skipFloor != true) { RenderDiagSETile( parent , x, y, t, Water, false); }//floor
								if ((skipCeil  != true)) { RenderDiagSETile( parent , x, y, t, Water, true); }
								return;
						}

				case TILE_DIAG_SW:
						{	//diag sw
								if (skipFloor != true) { RenderDiagSWTile( parent , x, y, t, Water, false); }//floor
								if ((skipCeil  != true)) { RenderDiagSWTile( parent , x, y, t, Water, true); }
								return;
						}

				case TILE_DIAG_NE:
						{	//diag ne
								if (skipFloor != true) { RenderDiagNETile( parent , x, y, t, Water, invert); }//floor
								if ((skipCeil  != true)) { RenderDiagNETile( parent , x, y, t, Water, true); }
								return;
						}

				case TILE_DIAG_NW:
						{//diag nw
								if (skipFloor != true) { RenderDiagNWTile( parent , x, y, t, Water, invert); }//floor
								if ((skipCeil  != true)) { RenderDiagNWTile( parent , x, y, t, Water, true); }
								return;
						}

				case TILE_SLOPE_N:	//6
						{//slope n
								switch (t.shockSlopeFlag)
								{
								case SLOPE_BOTH_PARALLEL:
										{
												if (skipFloor != true) { RenderSlopeNTile( parent , x, y, t, Water, false); }//floor
												if ((skipCeil  != true)) { RenderSlopeNTile( parent , x, y, t, Water, true); }
												break;
										}
								case SLOPE_BOTH_OPPOSITE:
										{
												if (skipFloor != true) { RenderSlopeNTile( parent , x, y, t, Water, false); }//floor
												if ((skipCeil  != true)) { RenderSlopeSTile( parent , x, y, t, Water, true); }
												break;
										}
								case SLOPE_FLOOR_ONLY:
										{
												if (skipFloor != true) { RenderSlopeNTile( parent , x, y, t, Water, false); }//floor
												if ((skipCeil  != true)) { RenderOpenTile( parent , x, y, t, Water, true); }	//ceiling
												break;
										}
								case SLOPE_CEILING_ONLY:
										{
												if (skipFloor != true) { RenderOpenTile( parent , x, y, t, Water, false); }	//floor
												RenderSlopeNTile( parent , x, y, t, Water, true);
												break;
										}
								}
								return;
						}
				case TILE_SLOPE_S: //slope s	7
						{
								switch (t.shockSlopeFlag)
								{
								case SLOPE_BOTH_PARALLEL:
										{
												if (skipFloor != true) { RenderSlopeSTile( parent , x, y, t, Water, false); }	//floor
												RenderSlopeSTile( parent , x, y, t, Water, true);
												break;
										}
								case SLOPE_BOTH_OPPOSITE:
										{
												if (skipFloor != true) { RenderSlopeSTile( parent , x, y, t, Water, false); }	//floor
												RenderSlopeNTile( parent , x, y, t, Water, true);
												break;
										}
								case SLOPE_FLOOR_ONLY:
										{
												if (skipFloor != true) { RenderSlopeSTile( parent , x, y, t, Water, false); }	//floor
												if ((skipCeil  != true)) { RenderOpenTile( parent , x, y, t, Water, true); }	//ceiling
												break;
										}
								case SLOPE_CEILING_ONLY:
										{
												if (skipFloor != true) { RenderOpenTile( parent , x, y, t, Water, false); }	//floor
												if ((skipCeil  != true)) { RenderSlopeSTile( parent , x, y, t, Water, true); }
												break;
										}
								}
								return;
						}
				case TILE_SLOPE_E:		//slope e 8	
						{
								switch (t.shockSlopeFlag)
								{
								case SLOPE_BOTH_PARALLEL:
										{
												if (skipFloor != true) { RenderSlopeETile( parent , x, y, t, Water, false); }//floor
												RenderSlopeETile( parent , x, y, t, Water, true);
												break;
										}
								case SLOPE_BOTH_OPPOSITE:
										{
												if (skipFloor != true) { RenderSlopeETile( parent , x, y, t, Water, false); }//floor
												RenderSlopeWTile( parent , x, y, t, Water, true);
												break;
										}
								case SLOPE_FLOOR_ONLY:
										{
												if (skipFloor != true) { RenderSlopeETile( parent , x, y, t, Water, false); }//floor
												if ((skipCeil  != true)) { RenderOpenTile( parent , x, y, t, Water, true); }	//ceiling
												break;
										}
								case SLOPE_CEILING_ONLY:
										{
												if (skipFloor != true) { RenderOpenTile( parent , x, y, t, Water, false); }	//floor
												if ((skipCeil  != true)) { RenderSlopeETile( parent , x, y, t, Water, true); }
												break;
										}
								}
								return;
						}
				case TILE_SLOPE_W: 	//9
						{ //slope w
								switch (t.shockSlopeFlag)
								{
								case SLOPE_BOTH_PARALLEL:
										{
												if (skipFloor != true) { RenderSlopeWTile( parent , x, y, t, Water, false); }//floor
												if ((skipCeil  != true)) { RenderSlopeWTile( parent , x, y, t, Water, true); }
												break;
										}
								case SLOPE_BOTH_OPPOSITE:
										{
												if (skipFloor != true) { RenderSlopeWTile( parent , x, y, t, Water, false); }//floor
												if ((skipCeil  != true)) { RenderSlopeETile( parent , x, y, t, Water, true); }
												break;
										}
								case SLOPE_FLOOR_ONLY:
										{
												if (skipFloor != true) { RenderSlopeWTile( parent , x, y, t, Water, false); }//floor
												if ((skipCeil  != true)) { RenderOpenTile( parent , x, y, t, Water, true); }	//ceiling
												break;
										}
								case SLOPE_CEILING_ONLY:
										{
												if (skipFloor != true) { RenderOpenTile( parent , x, y, t, Water, false); }	//floor
												if ((skipCeil  != true)) { RenderSlopeWTile( parent , x, y, t, Water, true); }
												break;
										}
								}
								return;
						}
				case TILE_VALLEY_NW:
						{	//valleyNw(a)
								switch (t.shockSlopeFlag)
								{
								case SLOPE_BOTH_PARALLEL:
										{
												if (skipFloor != true) { RenderValleyNWTile( parent , x, y, t, Water, false); }//floor
												if ((skipCeil  != true)) { RenderRidgeNWTile( parent , x, y, t, Water, true); }
												break;
										}
								case SLOPE_BOTH_OPPOSITE:
										{
												if (skipFloor != true) { RenderValleyNWTile( parent , x, y, t, Water, false); }//floor
												if ((skipCeil  != true)) { RenderValleySETile( parent , x, y, t, Water, true); }
												break;
										}
								case SLOPE_FLOOR_ONLY:
										{
												if (skipFloor != true) { RenderValleyNWTile( parent , x, y, t, Water, false); }//floor
												if ((skipCeil  != true)) { RenderOpenTile( parent , x, y, t, Water, true); }	//ceiling
												break;
										}
								case SLOPE_CEILING_ONLY:
										{
												if (skipFloor != true) { RenderOpenTile( parent , x, y, t, Water, false); }	//floor
												if ((skipCeil  != true)) { RenderRidgeNWTile( parent , x, y, t, Water, true); }
												break;
										}
								}
								return;
						}
				case TILE_VALLEY_NE:
						{	//valleyne(b)
								switch (t.shockSlopeFlag)
								{
								case SLOPE_BOTH_PARALLEL:
										{
												if (skipFloor != true) { RenderValleyNETile( parent , x, y, t, Water, false); }//floor
												if ((skipCeil  != true)) { RenderRidgeNETile( parent , x, y, t, Water, true); }
												break;
										}
								case SLOPE_BOTH_OPPOSITE:
										{
												if (skipFloor != true) { RenderValleyNETile( parent , x, y, t, Water, false); }//floor
												if ((skipCeil  != true)) { RenderValleySWTile( parent , x, y, t, Water, true); }
												break;
										}
								case SLOPE_FLOOR_ONLY:
										{
												if (skipFloor != true) { RenderValleyNETile( parent , x, y, t, Water, false); }//floor
												if ((skipCeil  != true)) { RenderOpenTile( parent , x, y, t, Water, true); }	//ceiling
												break;
										}
								case SLOPE_CEILING_ONLY:
										{
												if (skipFloor != true) { RenderOpenTile( parent , x, y, t, Water, false); }//floor
												if ((skipCeil  != true)) { RenderRidgeNETile( parent , x, y, t, Water, true); }
												break;
										}
								}
								return;
						}
				case TILE_VALLEY_SE:
						{	//valleyse(c)
								switch (t.shockSlopeFlag)
								{
								case SLOPE_BOTH_PARALLEL:
										{
												if (skipFloor != true) { RenderValleySETile( parent , x, y, t, Water, false); }//floor
												if ((skipCeil  != true)) { RenderRidgeSETile( parent , x, y, t, Water, true); }
												break;
										}
								case SLOPE_BOTH_OPPOSITE:
										{
												if (skipFloor != true) { RenderValleySETile( parent , x, y, t, Water, false); }//floor
												if ((skipCeil  != true)) { RenderValleyNWTile( parent , x, y, t, Water, true); }
												break;
										}
								case SLOPE_FLOOR_ONLY:
										{
												if (skipFloor != true) { RenderValleySETile( parent , x, y, t, Water, false); }//floor
												if ((skipCeil  != true)) { RenderOpenTile( parent , x, y, t, Water, true); }	//ceiling
												break;
										}
								case SLOPE_CEILING_ONLY:
										{
												if (skipFloor != true) { RenderOpenTile( parent , x, y, t, Water, false); }	//floor
												if ((skipCeil  != true)) { RenderRidgeSETile( parent , x, y, t, Water, true); }
												break;
										}
								}
								return;
						}
				case TILE_VALLEY_SW:
						{	//valleysw(d)
								switch (t.shockSlopeFlag)
								{
								case SLOPE_BOTH_PARALLEL:
										{
												if (skipFloor != true) { RenderValleySWTile( parent , x, y, t, Water, false); }//floor
												if ((skipCeil  != true)) { RenderRidgeSWTile( parent , x, y, t, Water, true); }
												break;
										}
								case SLOPE_BOTH_OPPOSITE:
										{
												if (skipFloor != true) { RenderValleySWTile( parent , x, y, t, Water, false); }//floor
												if ((skipCeil  != true)) { RenderValleyNETile( parent , x, y, t, Water, true); }
												break;
										}
								case SLOPE_FLOOR_ONLY:
										{
												if (skipFloor != true) { RenderValleySWTile( parent , x, y, t, Water, false); }//floor
												if ((skipCeil  != true)) { RenderOpenTile( parent , x, y, t, Water, true); }	//ceiling
												break;
										}
								case SLOPE_CEILING_ONLY:
										{
												if (skipFloor != true) { RenderOpenTile( parent , x, y, t, Water, false); }	//floor
												if ((skipCeil  != true)) { RenderRidgeSWTile( parent , x, y, t, Water, true); }
												break;
										}
								}
								return;
						}
				case TILE_RIDGE_SE:
						{	//ridge se(f)
								switch (t.shockSlopeFlag)
								{
								case SLOPE_BOTH_PARALLEL:
										{
												if (skipFloor != true) { RenderRidgeSETile( parent , x, y, t, Water, false); }//floor
												if ((skipCeil  != true)) { RenderValleySETile( parent , x, y, t, Water, true); }
												break;
										}
								case SLOPE_BOTH_OPPOSITE:
										{
												if (skipFloor != true) { RenderRidgeSETile( parent , x, y, t, Water, false); }//floor
												if ((skipCeil  != true)) { RenderRidgeNWTile( parent , x, y, t, Water, true); }
												break;
										}
								case SLOPE_FLOOR_ONLY:
										{
												if (skipFloor != true) { RenderRidgeSETile( parent , x, y, t, Water, false); }//floor
												if ((skipCeil  != true)) { RenderOpenTile( parent , x, y, t, Water, true); }	//ceiling
												break;
										}
								case SLOPE_CEILING_ONLY:
										{
												if (skipFloor != true) { RenderOpenTile( parent , x, y, t, Water, false); }//floor
												if ((skipCeil  != true)) { RenderValleySETile( parent , x, y, t, Water, true); }
												break;
										}
								}
								return;
						}
				case TILE_RIDGE_SW:
						{	//ridgesw(g)
								switch (t.shockSlopeFlag)
								{
								case SLOPE_BOTH_PARALLEL:
										{
												if (skipFloor != true) { RenderRidgeSWTile( parent , x, y, t, Water, false); }//floor
												if ((skipCeil  != true)) { RenderValleySWTile( parent , x, y, t, Water, true); }
												break;
										}
								case SLOPE_BOTH_OPPOSITE:
										{
												if (skipFloor != true) { RenderRidgeSWTile( parent , x, y, t, Water, false); }//floor
												if ((skipCeil  != true)) { RenderRidgeNETile( parent , x, y, t, Water, true); }
												break;
										}
								case SLOPE_FLOOR_ONLY:
										{
												if (skipFloor != true) { RenderRidgeSWTile( parent , x, y, t, Water, false); }//floor
												if ((skipCeil  != true)) { RenderOpenTile( parent , x, y, t, Water, true); }	//ceiling
												break;
										}
								case SLOPE_CEILING_ONLY:
										{
												if (skipFloor != true) { RenderOpenTile( parent , x, y, t, Water, false); }	//floor
												if ((skipCeil  != true)) { RenderValleySWTile( parent , x, y, t, Water, true); }
												break;
										}
								}
								return;
						}
				case TILE_RIDGE_NW:
						{	//ridgenw(h)
								switch (t.shockSlopeFlag)
								{
								case SLOPE_BOTH_PARALLEL:
										{
												if (skipFloor != true) { RenderRidgeNWTile( parent , x, y, t, Water, false); }//floor
												if ((skipCeil  != true)) { RenderValleyNWTile( parent , x, y, t, Water, true); }
												break;
										}
								case SLOPE_BOTH_OPPOSITE:
										{
												if (skipFloor != true) { RenderRidgeNWTile( parent , x, y, t, Water, false); }//floor
												if ((skipCeil  != true)) { RenderRidgeSETile( parent , x, y, t, Water, true); }
												break;
										}
								case SLOPE_FLOOR_ONLY:
										{
												if (skipFloor != true) { RenderRidgeNWTile( parent , x, y, t, Water, false); }//floor
												if ((skipCeil  != true)) { RenderOpenTile( parent , x, y, t, Water, true); }	//ceiling
												break;
										}
								case SLOPE_CEILING_ONLY:
										{
												if (skipFloor != true) { RenderOpenTile( parent , x, y, t, Water, false); }	//floor
												if ((skipCeil  != true)) { RenderValleyNWTile( parent , x, y, t, Water, true); }
												break;
										}
								}
								return;
						}
				case TILE_RIDGE_NE:
						{	//ridgene(i)
								switch (t.shockSlopeFlag)
								{
								case SLOPE_BOTH_PARALLEL:
										{
												if (skipFloor != true) { RenderRidgeNETile( parent , x, y, t, Water, false); }//floor
												if ((skipCeil  != true)) { RenderValleyNETile( parent , x, y, t, Water, true); }
												break;
										}
								case SLOPE_BOTH_OPPOSITE:
										{
												if (skipFloor != true) { RenderRidgeNETile( parent , x, y, t, Water, false); }//floor
												if ((skipCeil  != true)) { RenderRidgeSWTile( parent , x, y, t, Water, true); }
												break;
										}
								case SLOPE_FLOOR_ONLY:
										{
												if (skipFloor != true) { RenderRidgeNETile( parent , x, y, t, Water, false); }//floor
												if ((skipCeil  != true)) { RenderOpenTile( parent , x, y, t, Water, true); }	//ceiling
												break;
										}
								case SLOPE_CEILING_ONLY:
										{
												if (skipFloor != true) { RenderOpenTile( parent , x, y, t, Water, false); }	//floor
												if ((skipCeil  != true)) { RenderValleyNETile( parent , x, y, t, Water, true); }
												break;
										}
								}
								return;
						}
				}
		}

		/// <summary>
		/// Renders the a cuboid with no slopes
		/// </summary>
		/// <param name="parent">Parent.</param>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="t">T.</param>
		/// <param name="Water">If set to <c>true</c> water.</param>
		/// <param name="Bottom">Bottom.</param>
		/// <param name="Top">Top.</param>
		/// <param name="TileName">Tile name.</param>
		static void RenderCuboid(GameObject parent, int x, int y, TileInfo t, bool Water, int Bottom, int Top, string TileName)
		{

				//Draw a cube with no slopes.
				int NumberOfVisibleFaces=0;
				//Get the number of faces
				for (int i=0; i<6;i++)
				{
						if (t.VisibleFaces[i]==1)
						{
								NumberOfVisibleFaces++;
						}
				}
				//Allocate enough verticea and UVs for the faces
				Vector3[] verts =new Vector3[NumberOfVisibleFaces*4];
				Vector2[] uvs =new Vector2[NumberOfVisibleFaces*4];
				float floorHeight=(float)(Top*0.15f);
				float baseHeight=(float)(Bottom*0.15f);
				float dimX = t.DimX;
				float dimY = t.DimY;

				//Now create the mesh
				GameObject Tile = new GameObject(TileName);
				if (t.isWater==false)
				{
					if (t.isLava)
					{
						Tile.layer=LayerMask.NameToLayer("Lava");
					}
					else
					{
						Tile.layer=LayerMask.NameToLayer("MapMesh");	
					}
				}
				else
				{
						Tile.layer=LayerMask.NameToLayer("Water");
				}
				Tile.transform.parent=parent.transform;
				Tile.transform.position = new Vector3(x*1.2f,0.0f, y*1.2f);

				Tile.transform.localRotation=Quaternion.Euler(0f,0f,0f);
				MeshFilter mf = Tile.AddComponent<MeshFilter>();
				MeshRenderer mr =Tile.AddComponent<MeshRenderer>();
				MeshCollider mc = Tile.AddComponent<MeshCollider>();
				mc.sharedMesh=null;
				Mesh mesh = new Mesh();
				mesh.subMeshCount=NumberOfVisibleFaces;//Should be no of visible faces

				Material[] MatsToUse=new Material[NumberOfVisibleFaces];
				//Now allocate the visible faces to triangles.
				int FaceCounter=0;//Tracks which number face we are now on.
				float PolySize= Top-Bottom;
				float uv0= (float)(Bottom*0.125f);
				float uv1=(PolySize / 8.0f) + (uv0);
				float offset=0f;
				for (int i=0;i<6;i++)
				{
						if (t.VisibleFaces[i]==1)
						{
								switch(i)
								{
								case vTOP:
										{
											//Set the verts	
											MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[FloorTexture(fSELF, t)];
											if (_RES==GAME_UW1)
											if (GameWorldController.instance.LevelNo==6)
											{
												if (t.floorTexture==4)	
												{//Special case for tybals floor
													//MatsToUse[FaceCounter]= (Material)Resources.Load(_RES+ "\\Materials\\Textures\\uw1_224_maze");
													MatsToUse[FaceCounter]=GameWorldController.instance.SpecialMaterials[0];
												}
											}

											verts[0+ (4*FaceCounter)]=  new Vector3(0.0f, 0.0f,floorHeight);
											verts[1+ (4*FaceCounter)]=  new Vector3(0.0f, 1.2f*dimY, floorHeight);
											verts[2+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,1.2f*dimY, floorHeight);
											verts[3+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0.0f, floorHeight);

											//Allocate UVs
											uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,1.0f*dimY);
											uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,0.0f);
											uvs[2+ (4*FaceCounter)]=new Vector2(1.0f*dimX,0.0f);
											uvs[3+ (4*FaceCounter)]=new Vector2(1.0f*dimX,1.0f*dimY);

											break;
										}

								case vNORTH:
										{
												//north wall vertices
												offset = CalcCeilOffset(fNORTH, t);
												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[WallTexture(fNORTH, t)];
												verts[0+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,1.2f*dimY, baseHeight);
												verts[1+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,1.2f*dimY, floorHeight);
												verts[2+ (4*FaceCounter)]=  new Vector3(0f,1.2f*dimY, floorHeight);
												verts[3+ (4*FaceCounter)]=  new Vector3(0f,1.2f*dimY, baseHeight);

												uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,uv0-offset);
												uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,uv1-offset);
												uvs[2+ (4*FaceCounter)]=new Vector2(dimX,uv1-offset);
												uvs[3+ (4*FaceCounter)]=new Vector2(dimX,uv0-offset);


												break;
										}

								case vWEST:
										{
												//west wall vertices
												offset = CalcCeilOffset(fWEST, t);
												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[WallTexture(fWEST, t)];
												verts[0+ (4*FaceCounter)]=  new Vector3(0f,1.2f*dimY, baseHeight);
												verts[1+ (4*FaceCounter)]=  new Vector3(0f,1.2f*dimY, floorHeight);
												verts[2+ (4*FaceCounter)]=  new Vector3(0f,0f, floorHeight);
												verts[3+ (4*FaceCounter)]=  new Vector3(0f,0f, baseHeight);
												uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,uv0-offset);
												uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,uv1-offset);
												uvs[2+ (4*FaceCounter)]=new Vector2(dimY,uv1-offset);
												uvs[3+ (4*FaceCounter)]=new Vector2(dimY,uv0-offset);

												break;
										}

								case vEAST:
										{
												//east wall vertices
												offset = CalcCeilOffset(fEAST, t);
												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[WallTexture(fEAST, t)];
												verts[0+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, baseHeight);
												verts[1+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, floorHeight);
												verts[2+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,1.2f*dimY, floorHeight);
												verts[3+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,1.2f*dimY, baseHeight);
												uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,uv0-offset);
												uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,uv1-offset);
												uvs[2+ (4*FaceCounter)]=new Vector2(dimY,uv1-offset);
												uvs[3+ (4*FaceCounter)]=new Vector2(dimY,uv0-offset);

												break;
										}

								case vSOUTH:
										{
												offset = CalcCeilOffset(fSOUTH, t);
												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[WallTexture(fSOUTH, t)];
												//south wall vertices
												verts[0+ (4*FaceCounter)]=  new Vector3(0f,0f, baseHeight);
												verts[1+ (4*FaceCounter)]=  new Vector3(0f,0f, floorHeight);
												verts[2+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, floorHeight);
												verts[3+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, baseHeight);
												uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,uv0-offset);
												uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,uv1-offset);
												uvs[2+ (4*FaceCounter)]=new Vector2(dimX,uv1-offset);
												uvs[3+ (4*FaceCounter)]=new Vector2(dimX,uv0-offset);

												break;
										}
								case vBOTTOM:
										{
												//bottom wall vertices
												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[FloorTexture(fCEIL, t)];
												verts[0+ (4*FaceCounter)]=  new Vector3(0f,1.2f*dimY, baseHeight);
												verts[1+ (4*FaceCounter)]=  new Vector3(0f,0f, baseHeight);
												verts[2+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, baseHeight);
												verts[3+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,1.2f*dimY, baseHeight);
												//Change default UVs
												uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,0.0f);
												uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,1.0f*dimY);
												uvs[2+ (4*FaceCounter)]=new Vector2(dimX,1.0f*dimY);
												uvs[3+ (4*FaceCounter)]=new Vector2(dimX,0.0f);
												break;
										}
								}
								FaceCounter++;
						}
				}

				//Apply the uvs and create my tris
				mesh.vertices = verts;
				mesh.uv = uvs;
				FaceCounter=0;
				int [] tris = new int[6];
				for (int i=0;i<6;i++)
				{
						if (t.VisibleFaces[i]==1)
						{
								tris[0]=0+(4*FaceCounter);
								tris[1]=1+(4*FaceCounter);
								tris[2]=2+(4*FaceCounter);
								tris[3]=0+(4*FaceCounter);
								tris[4]=2+(4*FaceCounter);
								tris[5]=3+(4*FaceCounter);
								mesh.SetTriangles(tris,FaceCounter);
								FaceCounter++;
						}
				}

				mr.materials= MatsToUse;//mats;
				mesh.RecalculateNormals();
				mesh.RecalculateBounds();
				mf.mesh=mesh;
				mc.sharedMesh=mesh;
		}

		/*
		static void RenderSlopedCuboidOld(GameObject parent, int x, int y, TileInfo t, bool Water, int Bottom, int Top, int SlopeDir, int Steepness, int Floor, string TileName)
		{
				//Draws a cube with sloped tops

				float AdjustUpperNorth = 0f;
				float AdjustUpperSouth = 0f;
				float AdjustUpperEast = 0f;
				float AdjustUpperWest = 0f;

				float AdjustLowerNorth = 0f;
				float AdjustLowerSouth = 0f;
				float AdjustLowerEast = 0f;
				float AdjustLowerWest = 0f;

				if (Floor == 1)
				{
						switch (SlopeDir)
						{
						case TILE_SLOPE_N:
								AdjustUpperNorth = (float)Steepness*0.15f;
								break;
						case TILE_SLOPE_S:
								AdjustUpperSouth = (float)Steepness*0.15f;
								break;
						case TILE_SLOPE_E:
								AdjustUpperEast =(float)Steepness*0.15f;
								break;
						case TILE_SLOPE_W:
								AdjustUpperWest = (float)Steepness*0.15f;
								break;
						}
				}
				if (Floor == 0)
				{
						switch (SlopeDir)
						{
						case TILE_SLOPE_N:
								AdjustLowerNorth = -(float)Steepness*0.15f;
								break;
						case TILE_SLOPE_S:
								AdjustLowerSouth = -(float)Steepness*0.15f;
								break;
						case TILE_SLOPE_E:
								AdjustLowerEast =-(float)Steepness*0.15f;
								break;
						case TILE_SLOPE_W:
								AdjustLowerWest = -(float)Steepness*0.15f;
								break;
						}
				}

				//Draw a cube with no slopes.
				int NumberOfVisibleFaces=0;
				//Get the number of faces
				for (int i=0; i<6;i++)
				{
						if (t.VisibleFaces[i]==1)
						{
								NumberOfVisibleFaces++;
						}
				}
				//Allocate enough verticea and UVs for the faces
				Material[] MatsToUse=new Material[NumberOfVisibleFaces];
				Vector3[] verts =new Vector3[NumberOfVisibleFaces*4];
				Vector2[] uvs =new Vector2[NumberOfVisibleFaces*4];
				float offset=0f;
				float floorHeight=(float)(Top*0.15f);
				float baseHeight=(float)(Bottom*0.15f);
				float dimX = t.DimX;
				float dimY = t.DimY;

				//Now create the mesh
				GameObject Tile = new GameObject(TileName);
				if (t.isWater==false)
				{
						if (t.isLava)
						{
								Tile.layer=LayerMask.NameToLayer("Lava");
						}
						else
						{
								Tile.layer=LayerMask.NameToLayer("MapMesh");	
						}
				}
				else
				{
						Tile.layer=LayerMask.NameToLayer("Water");
				}
				Tile.transform.parent=parent.transform;
				Tile.transform.position = new Vector3(x*1.2f,0.0f, y*1.2f);

				Tile.transform.localRotation=Quaternion.Euler(0f,0f,0f);
				MeshFilter mf = Tile.AddComponent<MeshFilter>();
				MeshRenderer mr =Tile.AddComponent<MeshRenderer>();
				MeshCollider mc = Tile.AddComponent<MeshCollider>();
				mc.sharedMesh=null;

				Mesh mesh = new Mesh();
				mesh.subMeshCount=NumberOfVisibleFaces;//Should be no of visible faces
				//Now allocate the visible faces to triangles.
				int FaceCounter=0;//Tracks which number face we are now on.
				float PolySize= Top-Bottom;
				float uv0= (float)(Bottom*0.125f);
				float uv1=(PolySize / 8.0f) + (uv0);
				for (int i=0;i<6;i++)
				{
						if (t.VisibleFaces[i]==1)
						{
								switch(i)
								{
								case vTOP:
										{
												//Set the verts	
												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[FloorTexture(fSELF, t)];

												verts[0+ (4*FaceCounter)]=  new Vector3(0.0f, 0.0f,floorHeight+AdjustUpperWest+AdjustUpperSouth);
												verts[1+ (4*FaceCounter)]=  new Vector3(0.0f, 1.2f*dimY, floorHeight+AdjustUpperWest+AdjustUpperNorth);
												verts[2+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,1.2f*dimY, floorHeight+AdjustUpperNorth+AdjustUpperEast);
												verts[3+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0.0f, floorHeight+AdjustUpperSouth+AdjustUpperEast);

												//Allocate UVs
												uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,1.0f*dimY);
												uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,0.0f);
												uvs[2+ (4*FaceCounter)]=new Vector2(1.0f*dimX,0.0f);
												uvs[3+ (4*FaceCounter)]=new Vector2(1.0f*dimX,1.0f*dimY);

												break;
										}

								case vNORTH:
										{				
												float uv0InUse=0f; float uv1InUse=0f;
												float uv2InUse=0f; float uv3InUse=0f;
												//CalcUVsForSlopedTiles(t,SlopeDir, fNORTH, Steepness,Floor,uv0,uv1, out uv0InUse, out uv1InUse,out uv2InUse, out uv3InUse);
											//	CalcUVsForSlopedTiles(t,SlopeDir,fNORTH,Steepness,Floor,uv0,uv1, out uv0InUse, out uv1InUse,out uv2InUse, out uv3InUse);
												CalcUVsForSlopedTiles(t,SlopeDir, fNORTH, Steepness,Floor,Top,Bottom,uv0,uv1, out uv0InUse, out uv1InUse,out uv2InUse, out uv3InUse);

												//north wall vertices
												offset = CalcCeilOffset(fNORTH, t);
												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[WallTexture(fNORTH, t)];

												verts[0+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,1.2f*dimY, baseHeight  +AdjustLowerSouth+AdjustLowerWest);
												verts[1+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,1.2f*dimY, floorHeight+AdjustUpperNorth+AdjustUpperEast);
												verts[2+ (4*FaceCounter)]=  new Vector3(0f,1.2f*dimY, floorHeight+AdjustUpperNorth+AdjustUpperWest);
												verts[3+ (4*FaceCounter)]=  new Vector3(0f,1.2f*dimY, baseHeight+AdjustLowerSouth+AdjustLowerEast);

												uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,uv0InUse-offset);//bottom uv
												uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,uv1InUse-offset);//top uv
												uvs[2+ (4*FaceCounter)]=new Vector2(dimX,uv2InUse-offset);//top uv
												uvs[3+ (4*FaceCounter)]=new Vector2(dimX,uv3InUse-offset);//bottom uv

												break;
										}

								case vWEST:
										{
												//west wall vertices
												//float uv0InUse=0f; float uv1InUse=0f;
												float uv0InUse=0f; float uv1InUse=0f;
												float uv2InUse=0f; float uv3InUse=0f;
												//CalcUVsForSlopedTiles(t,SlopeDir, fWEST, Steepness,Floor,uv0,uv1, out uv0InUse, out uv1InUse,out uv2InUse, out uv3InUse);
												CalcUVsForSlopedTiles(t,SlopeDir, fWEST, Steepness,Floor,Top,Bottom,uv0,uv1, out uv0InUse, out uv1InUse,out uv2InUse, out uv3InUse);

												offset = CalcCeilOffset(fWEST, t);

												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[WallTexture(fWEST, t)];
												verts[0+ (4*FaceCounter)]=  new Vector3(0f,1.2f*dimY, baseHeight+AdjustLowerEast+AdjustLowerSouth);
												verts[1+ (4*FaceCounter)]=  new Vector3(0f,1.2f*dimY, floorHeight+AdjustUpperWest+AdjustUpperNorth);
												verts[2+ (4*FaceCounter)]=  new Vector3(0f,0f, floorHeight+AdjustUpperWest+AdjustUpperSouth);
												verts[3+ (4*FaceCounter)]=  new Vector3(0f,0f, baseHeight+AdjustLowerEast+AdjustLowerNorth);
												uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,uv0InUse-offset);
												uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,uv1InUse-offset);
												uvs[2+ (4*FaceCounter)]=new Vector2(dimY,uv2InUse-offset);
												uvs[3+ (4*FaceCounter)]=new Vector2(dimY,uv3InUse-offset);

												break;
										}

								case vEAST:
										{
												//static void CalcUVsForSlopedTiles(TileInfo t, int SlopeDir , int face, int Steepness, int Floor, int uv0_default, int uv1_default, out int UV0_OUT, out int UV1_OUT)
												float uv0InUse=0f; float uv1InUse=0f;
												float uv2InUse=0f; float uv3InUse=0f;
												CalcUVsForSlopedTiles(t,SlopeDir, fEAST, Steepness,Floor,Top,Bottom,uv0,uv1, out uv0InUse, out uv1InUse,out uv2InUse, out uv3InUse);

												//east wall vertices
												offset = CalcCeilOffset(fEAST, t);

												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[WallTexture(fEAST, t)];
												verts[0+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, baseHeight+AdjustLowerWest+AdjustLowerNorth);
												verts[1+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, floorHeight+AdjustUpperEast+AdjustUpperSouth);
												verts[2+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,1.2f*dimY, floorHeight+AdjustUpperEast+AdjustUpperNorth);
												verts[3+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,1.2f*dimY, baseHeight+AdjustLowerWest+AdjustLowerSouth);
												uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,uv0InUse-offset);//0
												uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,uv1InUse-offset);//1
												uvs[2+ (4*FaceCounter)]=new Vector2(dimY,uv2InUse-offset);//1
												uvs[3+ (4*FaceCounter)]=new Vector2(dimY,uv3InUse-offset);//0

												break;
										}

								case vSOUTH:
										{
												float uv0InUse=0f; float uv1InUse=0f;
												float uv2InUse=0f; float uv3InUse=0f;
												//CalcUVsForSlopedTiles(t,SlopeDir, fSOUTH, Steepness,Floor,uv0,uv1, out uv0InUse, out uv1InUse,out uv2InUse, out uv3InUse);
												CalcUVsForSlopedTiles(t,SlopeDir, fSOUTH, Steepness,Floor,Top,Bottom,uv0,uv1, out uv0InUse, out uv1InUse,out uv2InUse, out uv3InUse);

												//south wall vertices
												offset = CalcCeilOffset(fSOUTH, t);
												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[WallTexture(fSOUTH, t)];
												verts[0+ (4*FaceCounter)]=  new Vector3(0f,0f, baseHeight+AdjustLowerNorth+AdjustLowerEast);
												verts[1+ (4*FaceCounter)]=  new Vector3(0f,0f, floorHeight+AdjustUpperSouth+AdjustUpperWest);
												verts[2+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, floorHeight+AdjustUpperSouth+AdjustUpperEast);
												verts[3+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, baseHeight+AdjustLowerNorth+AdjustLowerWest);
												uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,uv0InUse-offset);
												uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,uv1InUse-offset);
												uvs[2+ (4*FaceCounter)]=new Vector2(dimX,uv2InUse-offset);
												uvs[3+ (4*FaceCounter)]=new Vector2(dimX,uv3InUse-offset);

												break;
										}
								case vBOTTOM:
										{
												//bottom wall vertices
												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[FloorTexture(fCEIL, t)];
												//TODO:Get the lower face adjustments for this (shock only)
												verts[0+ (4*FaceCounter)]=  new Vector3(0f,1.2f*dimY, baseHeight+AdjustLowerSouth+AdjustLowerEast);
												verts[1+ (4*FaceCounter)]=  new Vector3(0f,0f, baseHeight+AdjustLowerEast+AdjustLowerNorth);
												verts[2+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, baseHeight+AdjustLowerNorth+AdjustLowerWest);
												verts[3+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,1.2f*dimY, baseHeight+AdjustLowerSouth+AdjustLowerWest);
												//Change default UVs
												uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,0.0f);
												uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,1.0f*dimY);
												uvs[2+ (4*FaceCounter)]=new Vector2(dimX,1.0f*dimY);
												uvs[3+ (4*FaceCounter)]=new Vector2(dimX,0.0f);
												break;
										}
								}
								FaceCounter++;
						}
				}

				//Apply the uvs and create my tris
				mesh.vertices = verts;
				mesh.uv = uvs;
				FaceCounter=0;
				int [] tris = new int[6];
				for (int i=0;i<6;i++)
				{
						if (t.VisibleFaces[i]==1)
						{
								tris[0]=0+(4*FaceCounter);
								tris[1]=1+(4*FaceCounter);
								tris[2]=2+(4*FaceCounter);
								tris[3]=0+(4*FaceCounter);
								tris[4]=2+(4*FaceCounter);
								tris[5]=3+(4*FaceCounter);
								mesh.SetTriangles(tris,FaceCounter);
								FaceCounter++;
						}
				}

				mr.materials=MatsToUse;
				mesh.RecalculateNormals();
				mesh.RecalculateBounds();
				mf.mesh=mesh;
				mc.sharedMesh=mesh;

		}*/



		/// <summary>
		/// Renders the cuboid from an arbitary set of vertices and uvs
		/// </summary>
		/// <param name="parent">Parent.</param>
		/// <param name="verts">Verts.</param>
		/// <param name="uvs">Uvs.</param>
		/// <param name="position">Position.</param>
		/// <param name="MatsToUse">Mats to use.</param>
		/// <param name="NoOfFaces">No of faces.</param>
		/// <param name="name">Name.</param>
		static GameObject RenderCuboid(GameObject parent, Vector3[] verts, Vector2[] uvs, Vector3 position, Material[] MatsToUse ,int NoOfFaces , string name)
		{

				GameObject Tile = new GameObject(name);
				Tile.transform.parent=parent.transform;
				Tile.transform.position = position;
				Tile.transform.localRotation=Quaternion.Euler(0f,0f,0f);
				Tile.layer=LayerMask.NameToLayer("MapMesh");
				MeshFilter mf = Tile.AddComponent<MeshFilter>();
				MeshRenderer mr =Tile.AddComponent<MeshRenderer>();
				MeshCollider mc = Tile.AddComponent<MeshCollider>();
				mc.sharedMesh=null;
				Mesh mesh = new Mesh();
				mesh.vertices = verts;
				mesh.uv = uvs;
				mesh.subMeshCount=NoOfFaces;//VisibleFaces.GetUpperBound(0)+1;

				int FaceCounter=0;
				int [] tris = new int[6];
				for (int i=0;i<NoOfFaces;i++)
				{
						tris[0]=0+(4*FaceCounter);
						tris[1]=1+(4*FaceCounter);
						tris[2]=2+(4*FaceCounter);
						tris[3]=0+(4*FaceCounter);
						tris[4]=2+(4*FaceCounter);
						tris[5]=3+(4*FaceCounter);
						mesh.SetTriangles(tris,FaceCounter);
						FaceCounter++;
				}
				mr.materials= MatsToUse;
				mesh.RecalculateNormals();
				mesh.RecalculateBounds();
				mf.mesh=mesh;
				mc.sharedMesh=mesh;

				return Tile;
		}


		/// <summary>
		/// Renders a solid tile that files the entire tilespace
		/// </summary>
		/// <param name="parent">Parent.</param>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="t">T.</param>
		/// <param name="Water">If set to <c>true</c> water.</param>
		static void RenderSolidTile(GameObject parent, int x, int y, TileInfo t, bool Water)
		{
				if (t.Render == 1)
				{
						if (t.isWater == Water)
						{
								string TileName = "Tile_" + x.ToString("D2") + "_" + y.ToString("D2");
								t.VisibleFaces[vTOP]=0;
								t.VisibleFaces[vBOTTOM]=0;
								RenderCuboid( parent, x, y, t, Water, FLOOR_ADJ, CEILING_HEIGHT + CEIL_ADJ , TileName);
						}
				}
		}


		/// <summary>
		/// Renders an open tile with no slopes
		/// </summary>
		/// <param name="parent">Parent.</param>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="t">T.</param>
		/// <param name="Water">If set to <c>true</c> water.</param>
		/// <param name="invert">If set to <c>true</c> invert.</param>
		static void RenderOpenTile(GameObject parent, int x, int y, TileInfo t, bool Water, bool invert)
		{
				if (t.Render == 1){
						string TileName = "";
						if (t.isWater == Water)
						{
								if (invert == false)
								{
										//Bottom face 
										if ((t.hasElevator == 0))
										{
												if (t.BullFrog >0)
												{
														TileName = "Tile_" + x.ToString("D2") + "_" + y.ToString("D2");
														RenderCuboid(parent,x, y, t, Water, -16, t.floorHeight, TileName);
												}
												else
												{
														TileName = "Tile_" + x.ToString("D2") + "_" + y.ToString("D2");
														RenderCuboid(parent, x, y, t, Water, FLOOR_ADJ, t.floorHeight, TileName);
												}
										}
										else
										{
												TileName = "Tile_" + x.ToString("D2") + "_" + y.ToString("D2");
												RenderCuboid(parent, x, y, t, Water, -CEILING_HEIGHT, t.floorHeight, TileName);
										}
								}
								else
								{
										//Ceiling version of the tile
										short visB= t.VisibleFaces[vBOTTOM];
										short visT= t.VisibleFaces[vTOP];
										t.VisibleFaces[vBOTTOM]=1;
										t.VisibleFaces[vTOP]=0;
										TileName = "Tile_" + x.ToString("D2") + "_" + y.ToString("D2");
										RenderCuboid( parent, x, y, t, Water, CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + CEIL_ADJ, TileName);
										t.VisibleFaces[vBOTTOM]=visB;
										t.VisibleFaces[vTOP]=visT;
								}
						}
				}
		}


		/// <summary>
		/// Renders the diag SE tile.
		/// </summary>
		/// <param name="parent">Parent.</param>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="t">T.</param>
		/// <param name="Water">If set to <c>true</c> water.</param>
		/// <param name="invert">If set to <c>true</c> invert.</param>
		static void RenderDiagSETile(GameObject parent, int x, int y, TileInfo t, bool Water, bool invert)
		{
				string TileName = "";
				//int BLeftX; int BLeftY; int BLeftZ; int TLeftX; int TLeftY; int TLeftZ; int TRightX; int TRightY; int TRightZ;

				if (t.Render == 1)
				{
						if (invert == false)
						{

								if (Water != true)
								{
										//the wall part
										TileName = "Wall_" + x.ToString("D2") + "_" + y.ToString("D2");
										RenderDiagSEPortion(parent, FLOOR_ADJ, CEILING_HEIGHT + CEIL_ADJ, t, TileName);
								}
								if (t.isWater == Water)
								{
										//it's floor
										//RenderDiagNWPortion( FLOOR_ADJ, t.floorHeight, t,"DiagNW1");
										short PreviousNorth = t.VisibleFaces[vNORTH];
										short PreviousWest = t.VisibleFaces[vWEST];
										t.VisibleFaces[vNORTH] = 0;
										t.VisibleFaces[vWEST] = 0;
										RenderOpenTile( parent , x, y, t, Water, false);
										t.VisibleFaces[vNORTH] = PreviousNorth;
										t.VisibleFaces[vWEST] = PreviousWest;
								}
						}
						else
						{//it's ceiling
								//RenderDiagNWPortion( CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + CEIL_ADJ, t, "DiagNW2a");
								short vis= t.VisibleFaces[vBOTTOM];
								t.VisibleFaces[vBOTTOM]=1;
								RenderOpenTile( parent , x, y, t, Water, true);
								t.VisibleFaces[vBOTTOM]=vis;
						}
				}
				return;
		}


		/// <summary>
		/// Renders the diag SW tile.
		/// </summary>
		/// <param name="parent">Parent.</param>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="t">T.</param>
		/// <param name="Water">If set to <c>true</c> water.</param>
		/// <param name="invert">If set to <c>true</c> invert.</param>
		static void RenderDiagSWTile(GameObject parent,int x, int y, TileInfo t, bool Water, bool invert)
		{
				string TileName = "";
				if (t.Render == 1)
				{
						if (invert == false)
						{
								if (Water != true)
								{
										//Its wall
										TileName = "Wall_" + x.ToString("D2") + "_" + y.ToString("D2");
										RenderDiagSWPortion(parent, FLOOR_ADJ, CEILING_HEIGHT + CEIL_ADJ, t, TileName);
								}
								if (t.isWater == Water)
								{
										//it's floor
										//RenderDiagNEPortion( FLOOR_ADJ, t.floorHeight, t,"TileNe1");
										short PreviousNorth = t.VisibleFaces[vNORTH];
										short PreviousEast = t.VisibleFaces[vEAST];
										t.VisibleFaces[vNORTH] = 0;
										t.VisibleFaces[vEAST] = 0;
										RenderOpenTile( parent , x, y, t, Water, false);
										t.VisibleFaces[vNORTH] = PreviousNorth;
										t.VisibleFaces[vEAST] = PreviousEast;
								}
						}
						else
						{
								//its' ceiling.
								//RenderDiagNEPortion( CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + CEIL_ADJ, t, "TileNe2");
								short vis= t.VisibleFaces[vBOTTOM];
								t.VisibleFaces[vBOTTOM]=1;
								RenderOpenTile( parent , x, y, t, Water, true);
								t.VisibleFaces[vBOTTOM]=vis;
						}
				}
				return;
		}


		/// <summary>
		/// Renders the diag NE tile.
		/// </summary>
		/// <param name="parent">Parent.</param>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="t">T.</param>
		/// <param name="Water">If set to <c>true</c> water.</param>
		/// <param name="invert">If set to <c>true</c> invert.</param>
		static void RenderDiagNETile(GameObject parent,int x, int y, TileInfo t, bool Water, bool invert)
		{
				string TileName = "";
				if (t.Render == 1){
						if (invert == false)
						{
								if (Water != true)
								{
										TileName = "Wall_" + x.ToString("D2") + "_" + y.ToString("D2");
										RenderDiagNEPortion(parent, FLOOR_ADJ, CEILING_HEIGHT + CEIL_ADJ, t, TileName);
								}
								if (t.isWater == Water)
								{
										//it's floor
										//RenderDiagSWPortion( FLOOR_ADJ, t.floorHeight, t, "DiagSW2");
										short PreviousSouth = t.VisibleFaces[vSOUTH];
										short PreviousWest = t.VisibleFaces[vWEST];
										t.VisibleFaces[vSOUTH] = 0;
										t.VisibleFaces[vWEST] = 0;
										RenderOpenTile( parent , x, y, t, Water, false);
										t.VisibleFaces[vSOUTH] = PreviousSouth;
										t.VisibleFaces[vWEST] = PreviousWest;
								}
						}
						else
						{//it's ceiling
								//RenderDiagSWPortion( CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + CEIL_ADJ, t, "DiagSE3");
								short vis= t.VisibleFaces[vBOTTOM];
								t.VisibleFaces[vBOTTOM]=1;
								RenderOpenTile( parent , x, y, t, Water, true);
								t.VisibleFaces[vBOTTOM]=vis;
						}
				}
				return;
		}


		/// <summary>
		/// Renders the diag NW tile.
		/// </summary>
		/// <param name="parent">Parent.</param>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="t">T.</param>
		/// <param name="Water">If set to <c>true</c> water.</param>
		/// <param name="invert">If set to <c>true</c> invert.</param>
		static void RenderDiagNWTile(GameObject parent,int x, int y, TileInfo t, bool Water, bool invert)
		{
				string TileName="";
				if (t.Render == 1)
				{
						if (invert == false)
						{
								if (Water != true)
								{
										//It's wall.
										TileName = "Wall_" + x.ToString("D2") + "_" + y.ToString("D2");
										RenderDiagNWPortion(parent, FLOOR_ADJ, CEILING_HEIGHT + CEIL_ADJ, t, TileName);
								}

								if (t.isWater == Water)
								{//TODO:Update these floors to only show the top surface.
										//it's floor
										//RenderDiagSEPortion( FLOOR_ADJ, t.floorHeight, t, "DiagSE2");
										short PreviousSouth = t.VisibleFaces[vSOUTH];
										short PreviousEast = t.VisibleFaces[vEAST];
										t.VisibleFaces[vSOUTH] = 0;
										t.VisibleFaces[vEAST] = 0;
										RenderOpenTile( parent , x, y, t, Water, false);
										t.VisibleFaces[vSOUTH] = PreviousSouth;
										t.VisibleFaces[vEAST] = PreviousEast;
								}
						}
						else
						{//it's ceiling
								//RenderDiagSEPortion( CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + CEIL_ADJ, t, "DiagSE3");
								short vis= t.VisibleFaces[vBOTTOM];
								t.VisibleFaces[vBOTTOM]=1;
								RenderOpenTile( parent , x, y, t, Water, true);
								t.VisibleFaces[vBOTTOM]=vis;
						}
				}
				return;
		}

		/// <summary>
		/// Renders the slope N tile.
		/// </summary>
		/// <param name="parent">Parent.</param>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="t">T.</param>
		/// <param name="Water">If set to <c>true</c> water.</param>
		/// <param name="invert">If set to <c>true</c> invert.</param>
		static void RenderSlopeNTile(GameObject parent,int x, int y, TileInfo t, bool Water, bool invert)
		{
				string TileName="";
				if (t.Render == 1){
						if (invert == false)
						{
								if (t.isWater == Water)
								{
										//A floor
										TileName = "Tile_" + x.ToString("D2") + "_" + y.ToString("D2");
										RenderSlopedCuboid(parent, x, y, t, Water, FLOOR_ADJ, t.floorHeight, TILE_SLOPE_N, t.shockSteep, 1, TileName);
								}
						}
						else
						{
								//It's invert
								TileName = "N_Ceiling_" + x.ToString("D2") + "_" + y.ToString("D2");
								short visB= t.VisibleFaces[vBOTTOM];
								short visT= t.VisibleFaces[vTOP];
								t.VisibleFaces[vBOTTOM]=1;
								t.VisibleFaces[vTOP]=0;
								RenderSlopedCuboid(parent, x, y, t, Water, CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + CEIL_ADJ, TILE_SLOPE_N, t.shockSteep, 0, TileName);
								t.VisibleFaces[vBOTTOM]=visB;
								t.VisibleFaces[vTOP]=visT;
						}
				}
				return;
		}

		/// <summary>
		/// Renders the slope S tile.
		/// </summary>
		/// <param name="parent">Parent.</param>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="t">T.</param>
		/// <param name="Water">If set to <c>true</c> water.</param>
		/// <param name="invert">If set to <c>true</c> invert.</param>
		static void RenderSlopeSTile(GameObject parent,int x, int y, TileInfo t, bool Water, bool invert)
		{
				string TileName="";
				if (t.Render == 1){
						if (invert == false)
						{
								if (t.isWater == Water)
								{
										//A floor
										TileName = "Tile_" + x.ToString("D2") + "_" + y.ToString("D2");
										RenderSlopedCuboid(parent, x, y, t, Water, FLOOR_ADJ, t.floorHeight, TILE_SLOPE_S, t.shockSteep, 1, TileName);
								}
						}
						else
						{
								//It's invert
								TileName = "S_Ceiling_" + x.ToString("D2") + "_" + y.ToString("D2");
								short visB= t.VisibleFaces[vBOTTOM];
								short visT= t.VisibleFaces[vTOP];
								t.VisibleFaces[vBOTTOM]=1;
								t.VisibleFaces[vTOP]=0;
								RenderSlopedCuboid(parent, x, y, t, Water, CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + CEIL_ADJ, TILE_SLOPE_S, t.shockSteep, 0, TileName);
								t.VisibleFaces[vBOTTOM]=visB;
								t.VisibleFaces[vTOP]=visT;
						}
				}
				return;
		}

		/// <summary>
		/// Renders the slope W tile.
		/// </summary>
		/// <param name="parent">Parent.</param>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="t">T.</param>
		/// <param name="Water">If set to <c>true</c> water.</param>
		/// <param name="invert">If set to <c>true</c> invert.</param>
		static void RenderSlopeWTile(GameObject parent,int x, int y, TileInfo t, bool Water, bool invert)
		{
				string TileName="";
				if (t.Render == 1){
						if (invert == false)
						{
								if (t.isWater == Water)
								{
										//A floor
										TileName = "Tile_" + x.ToString("D2") + "_" + y.ToString("D2");
										RenderSlopedCuboid(parent, x, y, t, Water, FLOOR_ADJ, t.floorHeight, TILE_SLOPE_W, t.shockSteep, 1, TileName);
								}
						}
						else
						{
								//It's invert
								TileName = "W_Ceiling_" + x.ToString("D2") + "_" + y.ToString("D2");
								short visB= t.VisibleFaces[vBOTTOM];
								short visT= t.VisibleFaces[vTOP];
								t.VisibleFaces[vBOTTOM]=1;
								t.VisibleFaces[vTOP]=0;
								RenderSlopedCuboid(parent, x, y, t, Water, CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + CEIL_ADJ, TILE_SLOPE_W, t.shockSteep, 0, TileName);
								t.VisibleFaces[vBOTTOM]=visB;
								t.VisibleFaces[vTOP]=visT;
						}
				}
				return;
		}

		/// <summary>
		/// Renders the slope E tile.
		/// </summary>
		/// <param name="parent">Parent.</param>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="t">T.</param>
		/// <param name="Water">If set to <c>true</c> water.</param>
		/// <param name="invert">If set to <c>true</c> invert.</param>
		static void RenderSlopeETile(GameObject parent,int x, int y, TileInfo t, bool Water, bool invert)
		{
				string TileName="";
				if (t.Render == 1){
						if (invert == false)
						{
								if (t.isWater == Water)
								{
										//A floor
										TileName = "Tile_" + x.ToString("D2") + "_" + y.ToString("D2");
										RenderSlopedCuboid(parent, x, y, t, Water, FLOOR_ADJ, t.floorHeight, TILE_SLOPE_E, t.shockSteep, 1, TileName);
								}
						}
						else
						{
								//It's invert
								TileName = "E_Ceiling_" + x.ToString("D2") + "_" + y.ToString("D2");
								short visB= t.VisibleFaces[vBOTTOM];
								short visT= t.VisibleFaces[vTOP];
								t.VisibleFaces[vBOTTOM]=1;
								t.VisibleFaces[vTOP]=0;
								RenderSlopedCuboid(parent, x, y, t, Water, CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + CEIL_ADJ, TILE_SLOPE_E, t.shockSteep, 0, TileName);
								t.VisibleFaces[vBOTTOM]=visB;
								t.VisibleFaces[vTOP]=visT;
						}
				}
				return;
		}

		/// <summary>
		/// Renders the valley NW tile.
		/// </summary>
		/// <param name="parent">Parent.</param>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="t">T.</param>
		/// <param name="Water">If set to <c>true</c> water.</param>
		/// <param name="invert">If set to <c>true</c> invert.</param>
		static void RenderValleyNWTile(GameObject parent,int x, int y, TileInfo t, bool Water, bool invert)
		{
				if (invert == false)
				{
					//int originalTile = t.tileType;
					//t.tileType = TILE_SLOPE_N;
					//RenderSlopeNTile( parent , x, y, t, Water, invert);
					//t.tileType = TILE_SLOPE_W;
					//RenderSlopeWTile( parent , x, y, t, Water, invert);
					//t.tileType = originalTile;
						string TileName = "VNW_" + x.ToString("D2") + "_" + y.ToString("D2");
						RenderSlopedCuboid(parent, x, y, t, Water, FLOOR_ADJ, t.floorHeight, TILE_VALLEY_NW, t.shockSteep, 1, TileName);
				}
				else
				{
					string TileName = "VNW_Ceiling_" + x.ToString("D2") + "_" + y.ToString("D2");
					t.VisibleFaces[vBOTTOM]=1;
					RenderSlopedCuboid(parent, x, y, t, Water, CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + CEIL_ADJ, TILE_RIDGE_SE, t.shockSteep, 0, TileName);
				}
				return;
		}

		/// <summary>
		/// Renders the valley NE tile.
		/// </summary>
		/// <param name="parent">Parent.</param>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="t">T.</param>
		/// <param name="Water">If set to <c>true</c> water.</param>
		/// <param name="invert">If set to <c>true</c> invert.</param>
		static void RenderValleyNETile(GameObject parent,int x, int y, TileInfo t, bool Water, bool invert)
		{
				if (invert==false)
				{
						//int originalTile = t.tileType;
						//t.tileType = TILE_SLOPE_E;
						//RenderSlopeETile( parent , x, y, t, Water, invert);
						//t.tileType = TILE_SLOPE_N;
						//RenderSlopeNTile( parent , x, y, t, Water, invert);
						//t.tileType = originalTile;
						//return;
						string TileName = "VNE_" + x.ToString("D2") + "_" + y.ToString("D2");
						RenderSlopedCuboid(parent, x, y, t, Water, FLOOR_ADJ, t.floorHeight, TILE_VALLEY_NE, t.shockSteep, 1, TileName);
				}
				else
				{
					string TileName = "VNE_Ceiling_" + x.ToString("D2") + "_" + y.ToString("D2");
					t.VisibleFaces[vBOTTOM]=1;
						RenderSlopedCuboid(parent, x, y, t, Water, CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + CEIL_ADJ, TILE_RIDGE_SW, t.shockSteep, 0, TileName);
				}
		}

		/// <summary>
		/// Renders the valley SW tile.
		/// </summary>
		/// <param name="parent">Parent.</param>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="t">T.</param>
		/// <param name="Water">If set to <c>true</c> water.</param>
		/// <param name="invert">If set to <c>true</c> invert.</param>
		static void RenderValleySWTile(GameObject parent,int x, int y, TileInfo t, bool Water, bool invert)
		{
				if (invert==false)
				{
					//int originalTile = t.tileType;
					//t.tileType = TILE_SLOPE_W;
					//RenderSlopeWTile( parent , x, y, t, Water, invert);
					//t.tileType = TILE_SLOPE_S;
					//RenderSlopeSTile( parent , x, y, t, Water, invert);
					//t.tileType = originalTile;
					//return;

						string TileName = "VSW_" + x.ToString("D2") + "_" + y.ToString("D2");
						RenderSlopedCuboid(parent, x, y, t, Water, FLOOR_ADJ, t.floorHeight, TILE_VALLEY_SW, t.shockSteep, 1, TileName);

				}
				else
				{
					string TileName = "VSW_Ceiling_" + x.ToString("D2") + "_" + y.ToString("D2");
					t.VisibleFaces[vBOTTOM]=1;
					RenderSlopedCuboid(parent, x, y, t, Water, CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + CEIL_ADJ, TILE_RIDGE_NE, t.shockSteep, 0, TileName);							
				}
	
		}

		/// <summary>
		/// Renders the valley SE tile.
		/// </summary>
		/// <param name="parent">Parent.</param>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="t">T.</param>
		/// <param name="Water">If set to <c>true</c> water.</param>
		/// <param name="invert">If set to <c>true</c> invert.</param>
		static void RenderValleySETile(GameObject parent,int x, int y, TileInfo t, bool Water, bool invert)
		{
				if (invert==false)
				{
					//	int originalTile = t.tileType;
						//t.tileType = TILE_SLOPE_E;
						//RenderSlopeETile( parent , x, y, t, Water, invert);
						//t.tileType = TILE_SLOPE_S;
						//RenderSlopeSTile( parent , x, y, t, Water, invert);
						//t.tileType = originalTile;
						//return;	
						string TileName = "VSE_" + x.ToString("D2") + "_" + y.ToString("D2");
						RenderSlopedCuboid(parent, x, y, t, Water, FLOOR_ADJ, t.floorHeight, TILE_VALLEY_SE, t.shockSteep, 1, TileName);
				}
				else
				{
						string TileName = "VSE_Ceiling_" + x.ToString("D2") + "_" + y.ToString("D2");
						t.VisibleFaces[vBOTTOM]=1;
						RenderSlopedCuboid(parent, x, y, t, Water, CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + CEIL_ADJ, TILE_RIDGE_NW, t.shockSteep, 0, TileName);							
							
				}

		}

		/// <summary>
		/// Renders the ridge NW tile.
		/// </summary>
		/// <param name="parent">Parent.</param>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="t">T.</param>
		/// <param name="Water">If set to <c>true</c> water.</param>
		/// <param name="invert">If set to <c>true</c> invert.</param>
		static void RenderRidgeNWTile(GameObject parent, int x, int y, TileInfo t, bool Water, bool invert)
		{
				
				if (t.Render == 1)
				{
						if (invert == false)

						{//consists of a slope n and a slope w
								if (t.isWater == Water)
								{
										//RenderSlopeNTile( parent , x, y, t, Water, invert);
										//RenderSlopeWTile( parent , x, y, t, Water, invert);
										string TileName = "TileRNW_" + x.ToString("D2") + "_" + y.ToString("D2");
										RenderSlopedCuboid(parent, x, y, t, Water, FLOOR_ADJ, t.floorHeight, TILE_RIDGE_NW, t.shockSteep, 1, TileName);
								}
						}
						else
						{
								//made of upper slope e and upper slope s
								string TileName = "RNW_Ceiling_" + x.ToString("D2") + "_" + y.ToString("D2");
								t.VisibleFaces[vBOTTOM]=1;
								RenderSlopedCuboid(parent, x, y, t, Water, CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + CEIL_ADJ, TILE_VALLEY_SE, t.shockSteep, 0, TileName);							

								//RenderSlopeETile( parent , x, y, t, Water, invert);
								//RenderSlopeSTile( parent , x, y, t, Water, invert);
						}

				}
				return;
		}

		/// <summary>
		/// Renders the ridge NE tile.
		/// </summary>
		/// <param name="parent">Parent.</param>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="t">T.</param>
		/// <param name="Water">If set to <c>true</c> water.</param>
		/// <param name="invert">If set to <c>true</c> invert.</param>
		static void RenderRidgeNETile(GameObject parent, int x, int y, TileInfo t, bool Water, bool invert)
		{

				if (t.Render == 1){
						if (invert == false){
								if (t.isWater == Water)
								{
										//RenderSlopeNTile( parent , x, y, t, Water, invert);
										//RenderSlopeETile( parent , x, y, t, Water, invert);
										string TileName = "TileRNE_" + x.ToString("D2") + "_" + y.ToString("D2");
										RenderSlopedCuboid(parent, x, y, t, Water, FLOOR_ADJ, t.floorHeight, TILE_RIDGE_NE, t.shockSteep, 1, TileName);
								}
						}
						else
						{//invert is south and west slopes
								//RenderSlopeSTile( parent , x, y, t, Water, invert);
								//RenderSlopeWTile( parent , x, y, t, Water, invert);
								string TileName = "RNE_Ceiling_" + x.ToString("D2") + "_" + y.ToString("D2");
								t.VisibleFaces[vBOTTOM]=1;
								RenderSlopedCuboid(parent, x, y, t, Water, CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + CEIL_ADJ, TILE_VALLEY_SW, t.shockSteep, 0, TileName);							

						}
				}

				return;
		}

		/// <summary>
		/// Renders the ridge SW tile.
		/// </summary>
		/// <param name="parent">Parent.</param>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="t">T.</param>
		/// <param name="Water">If set to <c>true</c> water.</param>
		/// <param name="invert">If set to <c>true</c> invert.</param>
		static void RenderRidgeSWTile(GameObject parent, int x, int y, TileInfo t, bool Water, bool invert)
		{
				//consists of a slope s and a slope w
				if (t.Render == 1)
				if (invert == false)
				{
						{
								if (t.isWater == Water)
								{
										//RenderSlopeSTile( parent , x, y, t, Water, invert);
										//RenderSlopeWTile( parent , x, y, t, Water, invert);
										string TileName = "TileRSW_" + x.ToString("D2") + "_" + y.ToString("D2");
										RenderSlopedCuboid(parent, x, y, t, Water, FLOOR_ADJ, t.floorHeight, TILE_RIDGE_SW, t.shockSteep, 1, TileName);
								}
						}
				}
				else
				{	//invert is n and w slopes
						//render a ceiling version of this tile
						//RenderSlopeNTile( parent , x, y, t, Water, invert);
						//RenderSlopeWTile( parent , x, y, t, Water, invert);
						string TileName = "RSW_Ceiling_" + x.ToString("D2") + "_" + y.ToString("D2");
						t.VisibleFaces[vBOTTOM]=1;
						RenderSlopedCuboid(parent, x, y, t, Water, CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + CEIL_ADJ, TILE_VALLEY_NE, t.shockSteep, 0, TileName);							


				}
				return;
		}

		/// <summary>
		/// Renders the ridge SE tile.
		/// </summary>
		/// <param name="parent">Parent.</param>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="t">T.</param>
		/// <param name="Water">If set to <c>true</c> water.</param>
		/// <param name="invert">If set to <c>true</c> invert.</param>
		static void RenderRidgeSETile(GameObject parent, int x, int y, TileInfo t, bool Water, bool invert)
		{
				//consists of a slope s and a slope e
				//done

				if (t.Render == 1)
				{
						if (invert == false)
						{
								if (t.isWater == Water)
								{
										//RenderSlopeSTile( parent , x, y, t, Water, invert);
										//RenderSlopeETile( parent , x, y, t, Water, invert);
										string TileName = "TileRSE_" + x.ToString("D2") + "_" + y.ToString("D2");
										RenderSlopedCuboid(parent, x, y, t, Water, FLOOR_ADJ, t.floorHeight, TILE_RIDGE_SE, t.shockSteep, 1, TileName);
								}
						}
						else
						{//invert is n w
								//render a ceiling version of this tile
								//top and bottom faces move up
								//RenderSlopeNTile( parent , x, y, t, Water, invert);
								//RenderSlopeWTile( parent , x, y, t, Water, invert);
								string TileName = "RNW_Ceiling_" + x.ToString("D2") + "_" + y.ToString("D2");
								t.VisibleFaces[vBOTTOM]=1;
								RenderSlopedCuboid(parent, x, y, t, Water, CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + CEIL_ADJ, TILE_VALLEY_NW, t.shockSteep, 0, TileName);							


						}
				}
				return;
		}


		/// <summary>
		/// Renders the diag SE portion.
		/// </summary>
		/// <param name="parent">Parent.</param>
		/// <param name="Bottom">Bottom.</param>
		/// <param name="Top">Top.</param>
		/// <param name="t">T.</param>
		/// <param name="TileName">Tile name.</param>
		static void RenderDiagSEPortion(GameObject parent,int Bottom, int Top, TileInfo t, string TileName)
		{
				//Does a thing.
				//Draws 3 meshes. Outward diagonal wall. Back and side if visible.


				int NumberOfVisibleFaces=1;//Will always have the diag.
				//Get the number of faces
				for (int i=0; i<6;i++)
				{
						if ((i==vNORTH) || (i==vWEST))
						{
								if (t.VisibleFaces[i]==1)
								{
										NumberOfVisibleFaces++;
								}
						}
				}
				//Allocate enough verticea and UVs for the faces
				Material[] MatsToUse=new Material[NumberOfVisibleFaces];
				Vector3[] verts =new Vector3[NumberOfVisibleFaces*4];
				Vector2[] uvs =new Vector2[NumberOfVisibleFaces*4];
				float offset=0f;
				float floorHeight=(float)(Top*0.15f);
				float baseHeight=(float)(Bottom*0.15f);
				//float dimX = t.DimX;
				//float dimY = t.DimY;

				//Now create the mesh
				GameObject Tile = new GameObject(TileName);
				Tile.transform.parent=parent.transform;
				Tile.transform.position = new Vector3(t.tileX*1.2f,0.0f, t.tileY*1.2f);

				Tile.transform.localRotation=Quaternion.Euler(0f,0f,0f);
				MeshFilter mf = Tile.AddComponent<MeshFilter>();
				MeshRenderer mr =Tile.AddComponent<MeshRenderer>();
				MeshCollider mc = Tile.AddComponent<MeshCollider>();
				mc.sharedMesh=null;

				Mesh mesh = new Mesh();
				mesh.subMeshCount=NumberOfVisibleFaces;//Should be no of visible faces

				//Now allocate the visible faces to triangles.
				int FaceCounter=0;//Tracks which number face we are now on.
				MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[WallTexture(fSELF, t)];
				float PolySize= Top-Bottom;
				float uv0= (float)(Bottom*0.125f);
				float uv1=(PolySize / 8.0f) + (uv0);
				//Set the diagonal face first

				verts[0]=  new Vector3(0f,0f, baseHeight);
				verts[1]=  new Vector3(0f,0f, floorHeight);
				verts[2]=  new Vector3(-1.2f,1.2f, floorHeight);
				verts[3]=  new Vector3(-1.2f,1.2f, baseHeight);

				uvs[0]=new Vector2(0.0f,uv0);
				uvs[1]=new Vector2(0.0f,uv1);
				uvs[2]=new Vector2(1,uv1);
				uvs[3]=new Vector2(1,uv0);
				FaceCounter++;

				for (int i=0;i<6;i++)
				{
						if ((t.VisibleFaces[i]==1) && ((i==vNORTH) || (i==vWEST)))
						{//Will only render north or west if needed.
								switch(i)
								{
								case vNORTH:
										{
												//north wall vertices
												offset = CalcCeilOffset(fNORTH, t);
												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[WallTexture(fNORTH, t)];
												verts[0+ (4*FaceCounter)]=  new Vector3(-1.2f,1.2f, baseHeight);
												verts[1+ (4*FaceCounter)]=  new Vector3(-1.2f,1.2f, floorHeight);
												verts[2+ (4*FaceCounter)]=  new Vector3(0f,1.2f, floorHeight);
												verts[3+ (4*FaceCounter)]=  new Vector3(0f,1.2f, baseHeight);

												uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,uv0-offset);
												uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,uv1-offset);
												uvs[2+ (4*FaceCounter)]=new Vector2(1,uv1-offset);
												uvs[3+ (4*FaceCounter)]=new Vector2(1,uv0-offset);

												break;
										}
								case vWEST:
										{
												//west wall vertices
												offset = CalcCeilOffset(fWEST, t);
												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[WallTexture(fWEST, t)];
												verts[0+ (4*FaceCounter)]=  new Vector3(0f,1.2f, baseHeight);
												verts[1+ (4*FaceCounter)]=  new Vector3(0f,1.2f, floorHeight);
												verts[2+ (4*FaceCounter)]=  new Vector3(0f,0f, floorHeight);
												verts[3+ (4*FaceCounter)]=  new Vector3(0f,0f, baseHeight);
												uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,uv0-offset);
												uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,uv1-offset);
												uvs[2+ (4*FaceCounter)]=new Vector2(1,uv1-offset);
												uvs[3+ (4*FaceCounter)]=new Vector2(1,uv0-offset);

												break;
										}
								}
								FaceCounter++;
						}
				}

				//Apply the uvs and create my tris
				mesh.vertices = verts;
				mesh.uv = uvs;
				int [] tris = new int[6];
				//Tris for diagonal.

				tris[0]=0;
				tris[1]=1;
				tris[2]=2;
				tris[3]=0;
				tris[4]=2;
				tris[5]=3;
				mesh.SetTriangles(tris,0);
				FaceCounter=1;

				for (int i=0;i<6;i++)
				{
						if ((i==vNORTH) || (i==vWEST))
						{
								if (t.VisibleFaces[i]==1)
								{
										tris[0]=0+(4*FaceCounter);
										tris[1]=1+(4*FaceCounter);
										tris[2]=2+(4*FaceCounter);
										tris[3]=0+(4*FaceCounter);
										tris[4]=2+(4*FaceCounter);
										tris[5]=3+(4*FaceCounter);
										mesh.SetTriangles(tris,FaceCounter);
										FaceCounter++;
								}
						}
				}

				mr.materials= MatsToUse;
				mesh.RecalculateNormals();
				mesh.RecalculateBounds();
				mf.mesh=mesh;
				mc.sharedMesh=mesh;
				return;
		}

		/// <summary>
		/// Renders the diag SW portion.
		/// </summary>
		/// <param name="parent">Parent.</param>
		/// <param name="Bottom">Bottom.</param>
		/// <param name="Top">Top.</param>
		/// <param name="t">T.</param>
		/// <param name="TileName">Tile name.</param>
		static void RenderDiagSWPortion(GameObject parent,int Bottom, int Top, TileInfo t, string TileName)
		{
				//Does a thing.
				//Does a thing.
				//Draws 3 meshes. Outward diagonal wall. Back and side if visible.
				int NumberOfVisibleFaces=1;//Will always have the diag.
				//Get the number of faces
				for (int i=0; i<6;i++)
				{
						if ((i==vNORTH) || (i==vEAST))
						{
								if (t.VisibleFaces[i]==1)
								{
										NumberOfVisibleFaces++;
								}
						}
				}
				//Allocate enough verticea and UVs for the faces
				Material[] MatsToUse=new Material[NumberOfVisibleFaces];
				Vector3[] verts =new Vector3[NumberOfVisibleFaces*4];
				Vector2[] uvs =new Vector2[NumberOfVisibleFaces*4];
				float floorHeight=(float)(Top*0.15f);
				float baseHeight=(float)(Bottom*0.15f);
				float dimX = t.DimX;
				float dimY = t.DimY;
				float offset=0f;
				//Now create the mesh
				GameObject Tile = new GameObject(TileName);
				Tile.transform.parent=parent.transform;
				Tile.transform.position = new Vector3(t.tileX*1.2f,0.0f, t.tileY*1.2f);

				Tile.transform.localRotation=Quaternion.Euler(0f,0f,0f);
				MeshFilter mf = Tile.AddComponent<MeshFilter>();
				MeshRenderer mr =Tile.AddComponent<MeshRenderer>();
				MeshCollider mc = Tile.AddComponent<MeshCollider>();
				mc.sharedMesh=null;

				Mesh mesh = new Mesh();
				mesh.subMeshCount=NumberOfVisibleFaces;//Should be no of visible faces

				//Now allocate the visible faces to triangles.
				int FaceCounter=0;//Tracks which number face we are now on.

				MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[WallTexture(fSELF, t)];

				float PolySize= Top-Bottom;
				float uv0= (float)(Bottom*0.125f);
				float uv1=(PolySize / 8.0f) + (uv0);
				//Set the diagonal face first
				verts[0]=  new Vector3(0f,1.2f, baseHeight);
				verts[1]=  new Vector3(0f,1.2f, floorHeight);
				verts[2]=  new Vector3(-1.2f,0f, floorHeight);
				verts[3]=  new Vector3(-1.2f,0f, baseHeight);

				uvs[0]=new Vector2(0.0f,uv0);
				uvs[1]=new Vector2(0.0f,uv1);
				uvs[2]=new Vector2(1,uv1);
				uvs[3]=new Vector2(1,uv0);
				FaceCounter++;

				for (int i=0;i<6;i++)
				{
						if ((t.VisibleFaces[i]==1) && ((i==vNORTH) || (i==vEAST)))
						{//Will only render north or west if needed.
								switch(i)
								{
								case vNORTH:
										{
												//north wall vertices
												offset = CalcCeilOffset(fNORTH, t);
												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[WallTexture(fNORTH, t)];
												verts[0+ (4*FaceCounter)]=  new Vector3(-1.2f,1.2f, baseHeight);
												verts[1+ (4*FaceCounter)]=  new Vector3(-1.2f,1.2f, floorHeight);
												verts[2+ (4*FaceCounter)]=  new Vector3(0f,1.2f, floorHeight);
												verts[3+ (4*FaceCounter)]=  new Vector3(0f,1.2f, baseHeight);

												uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,uv0-offset);
												uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,uv1-offset);
												uvs[2+ (4*FaceCounter)]=new Vector2(1,uv1-offset);
												uvs[3+ (4*FaceCounter)]=new Vector2(1,uv0-offset);

												break;
										}

								case vEAST:
										{
												//east wall vertices
												offset = CalcCeilOffset(fEAST, t);
												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[WallTexture(fEAST, t)];
												verts[0+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, baseHeight);
												verts[1+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, floorHeight);
												verts[2+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,1.2f*dimY, floorHeight);
												verts[3+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,1.2f*dimY, baseHeight);
												uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,uv0-offset);
												uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,uv1-offset);
												uvs[2+ (4*FaceCounter)]=new Vector2(dimY,uv1-offset);
												uvs[3+ (4*FaceCounter)]=new Vector2(dimY,uv0-offset);

												break;
										}
								}
								FaceCounter++;
						}
				}

				//Apply the uvs and create my tris
				mesh.vertices = verts;
				mesh.uv = uvs;
				int [] tris = new int[6];
				//Tris for diagonal.

				tris[0]=0;
				tris[1]=1;
				tris[2]=2;
				tris[3]=0;
				tris[4]=2;
				tris[5]=3;
				mesh.SetTriangles(tris,0);
				FaceCounter=1;

				for (int i=0;i<6;i++)
				{
						if ((i==vNORTH) || (i==vEAST))
						{
								if (t.VisibleFaces[i]==1)
								{
										tris[0]=0+(4*FaceCounter);
										tris[1]=1+(4*FaceCounter);
										tris[2]=2+(4*FaceCounter);
										tris[3]=0+(4*FaceCounter);
										tris[4]=2+(4*FaceCounter);
										tris[5]=3+(4*FaceCounter);
										mesh.SetTriangles(tris,FaceCounter);
										FaceCounter++;
								}
						}
				}

				mr.materials= MatsToUse;
				mesh.RecalculateNormals();
				mesh.RecalculateBounds();
				mf.mesh=mesh;
				mc.sharedMesh=mesh;
				return;
		}

		/// <summary>
		/// Renders the diag NW portion.
		/// </summary>
		/// <param name="parent">Parent.</param>
		/// <param name="Bottom">Bottom.</param>
		/// <param name="Top">Top.</param>
		/// <param name="t">T.</param>
		/// <param name="TileName">Tile name.</param>
		static void RenderDiagNWPortion(GameObject parent,int Bottom, int Top, TileInfo t, string TileName)
		{
				//Does a thing.
				//Does a thing.
				//Draws 3 meshes. Outward diagonal wall. Back and side if visible.


				int NumberOfVisibleFaces=1;//Will always have the diag.
				//Get the number of faces
				for (int i=0; i<6;i++)
				{
						if ((i==vSOUTH) || (i==vEAST))
						{
								if (t.VisibleFaces[i]==1)
								{
										NumberOfVisibleFaces++;
								}
						}
				}
				//Allocate enough verticea and UVs for the faces
				Material[] MatsToUse=new Material[NumberOfVisibleFaces];
				Vector3[] verts =new Vector3[NumberOfVisibleFaces*4];
				Vector2[] uvs =new Vector2[NumberOfVisibleFaces*4];
				float floorHeight=(float)(Top*0.15f);
				float baseHeight=(float)(Bottom*0.15f);
				float dimX = t.DimX;
				float dimY = t.DimY;
				float offset=0f;

				//Now create the mesh
				GameObject Tile = new GameObject(TileName);
				Tile.transform.parent=parent.transform;
				Tile.transform.position = new Vector3(t.tileX*1.2f,0.0f, t.tileY*1.2f);

				Tile.transform.localRotation=Quaternion.Euler(0f,0f,0f);
				MeshFilter mf = Tile.AddComponent<MeshFilter>();
				MeshRenderer mr =Tile.AddComponent<MeshRenderer>();
				MeshCollider mc = Tile.AddComponent<MeshCollider>();
				mc.sharedMesh=null;

				Mesh mesh = new Mesh();
				mesh.subMeshCount=NumberOfVisibleFaces;//Should be no of visible faces
				//Now allocate the visible faces to triangles.
				int FaceCounter=0;//Tracks which number face we are now on.
				float PolySize= Top-Bottom;
				float uv0= (float)(Bottom*0.125f);
				float uv1=(PolySize / 8.0f) + (uv0);
				//Set the diagonal face first
				MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[WallTexture(fSELF, t)];

				verts[0]=  new Vector3(-1.2f,1.2f, baseHeight);
				verts[1]=  new Vector3(-1.2f,1.2f, floorHeight);
				verts[2]=  new Vector3(0f,0f, floorHeight);
				verts[3]=  new Vector3(0f,0f, baseHeight);

				uvs[0]=new Vector2(0.0f,uv0);
				uvs[1]=new Vector2(0.0f,uv1);
				uvs[2]=new Vector2(1,uv1);
				uvs[3]=new Vector2(1,uv0);
				FaceCounter++;

				for (int i=0;i<6;i++)
				{
						if ((t.VisibleFaces[i]==1) && ((i==vSOUTH) || (i==vEAST)))
						{//Will only render north or west if needed.
								switch(i)
								{
								case vEAST:
										{
												//east wall vertices
												offset = CalcCeilOffset(fEAST, t);
												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[WallTexture(fEAST, t)];
												verts[0+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, baseHeight);
												verts[1+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, floorHeight);
												verts[2+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,1.2f*dimY, floorHeight);
												verts[3+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,1.2f*dimY, baseHeight);
												uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,uv0-offset);
												uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,uv1-offset);
												uvs[2+ (4*FaceCounter)]=new Vector2(dimY,uv1-offset);
												uvs[3+ (4*FaceCounter)]=new Vector2(dimY,uv0-offset);

												break;
										}

								case vSOUTH:
										{
												//south wall vertices
												offset = CalcCeilOffset(fSOUTH, t);
												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[WallTexture(fSOUTH, t)];
												verts[0+ (4*FaceCounter)]=  new Vector3(0f,0f, baseHeight);
												verts[1+ (4*FaceCounter)]=  new Vector3(0f,0f, floorHeight);
												verts[2+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, floorHeight);
												verts[3+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, baseHeight);
												uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,uv0-offset);
												uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,uv1-offset);
												uvs[2+ (4*FaceCounter)]=new Vector2(dimX,uv1-offset);
												uvs[3+ (4*FaceCounter)]=new Vector2(dimX,uv0-offset);

												break;
										}
								}
								FaceCounter++;
						}
				}

				//Apply the uvs and create my tris
				mesh.vertices = verts;
				mesh.uv = uvs;
				int [] tris = new int[6];
				//Tris for diagonal.

				tris[0]=0;
				tris[1]=1;
				tris[2]=2;
				tris[3]=0;
				tris[4]=2;
				tris[5]=3;
				mesh.SetTriangles(tris,0);
				FaceCounter=1;

				for (int i=0;i<6;i++)
				{
						if ((i==vSOUTH) || (i==vEAST))
						{
								if (t.VisibleFaces[i]==1)
								{
										tris[0]=0+(4*FaceCounter);
										tris[1]=1+(4*FaceCounter);
										tris[2]=2+(4*FaceCounter);
										tris[3]=0+(4*FaceCounter);
										tris[4]=2+(4*FaceCounter);
										tris[5]=3+(4*FaceCounter);
										mesh.SetTriangles(tris,FaceCounter);
										FaceCounter++;
								}
						}
				}

				mr.materials= MatsToUse;
				mesh.RecalculateNormals();
				mesh.RecalculateBounds();
				mf.mesh=mesh;
				mc.sharedMesh=mesh;
				return;
		}

		/// <summary>
		/// Renders the diag NE portion.
		/// </summary>
		/// <param name="parent">Parent.</param>
		/// <param name="Bottom">Bottom.</param>
		/// <param name="Top">Top.</param>
		/// <param name="t">T.</param>
		/// <param name="TileName">Tile name.</param>
		static void RenderDiagNEPortion(GameObject parent,int Bottom, int Top, TileInfo t, string TileName)
		{
				//Does a thing.
				//Does a thing.
				//Draws 3 meshes. Outward diagonal wall. Back and side if visible.


				int NumberOfVisibleFaces=1;//Will always have the diag.
				//Get the number of faces
				for (int i=0; i<6;i++)
				{
						if ((i==vSOUTH) || (i==vWEST))
						{
								if (t.VisibleFaces[i]==1)
								{
										NumberOfVisibleFaces++;
								}
						}
				}
				//Allocate enough verticea and UVs for the faces
				Material[] MatsToUse=new Material[NumberOfVisibleFaces];
				Vector3[] verts =new Vector3[NumberOfVisibleFaces*4];
				Vector2[] uvs =new Vector2[NumberOfVisibleFaces*4];

				float floorHeight=(float)(Top*0.15f);
				float baseHeight=(float)(Bottom*0.15f);
				float dimX = t.DimX;
				//float dimY = t.DimY;
				float offset=0f;
				//Now create the mesh
				GameObject Tile = new GameObject(TileName);
				Tile.transform.parent=parent.transform;
				Tile.transform.position = new Vector3(t.tileX*1.2f,0.0f, t.tileY*1.2f);

				Tile.transform.localRotation=Quaternion.Euler(0f,0f,0f);
				MeshFilter mf = Tile.AddComponent<MeshFilter>();
				MeshRenderer mr =Tile.AddComponent<MeshRenderer>();
				MeshCollider mc = Tile.AddComponent<MeshCollider>();
				mc.sharedMesh=null;

				Mesh mesh = new Mesh();
				mesh.subMeshCount=NumberOfVisibleFaces;//Should be no of visible faces

				//Now allocate the visible faces to triangles.
				int FaceCounter=0;//Tracks which number face we are now on.
				float PolySize= Top-Bottom;
				float uv0= (float)(Bottom*0.125f);
				float uv1=(PolySize / 8.0f) + (uv0);
				//Set the diagonal face first
				MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[WallTexture(fSELF, t)];
				verts[0]=  new Vector3(-1.2f,0f, baseHeight);
				verts[1]=  new Vector3(-1.2f,0f, floorHeight);
				verts[2]=  new Vector3(0f,1.2f, floorHeight);
				verts[3]=  new Vector3(0f,1.2f, baseHeight);

				uvs[0]=new Vector2(0.0f,uv0);
				uvs[1]=new Vector2(0.0f,uv1);
				uvs[2]=new Vector2(1,uv1);
				uvs[3]=new Vector2(1,uv0);
				FaceCounter++;

				for (int i=0;i<6;i++)
				{
						if ((t.VisibleFaces[i]==1) && ((i==vSOUTH) || (i==vWEST)))
						{//Will only render north or west if needed.
								switch(i)
								{
								case vSOUTH:
										{
												//south wall vertices
												offset = CalcCeilOffset(fSOUTH, t);
												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[WallTexture(fSOUTH, t)];
												verts[0+ (4*FaceCounter)]=  new Vector3(0f,0f, baseHeight);
												verts[1+ (4*FaceCounter)]=  new Vector3(0f,0f, floorHeight);
												verts[2+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, floorHeight);
												verts[3+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, baseHeight);
												uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,uv0-offset);
												uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,uv1-offset);
												uvs[2+ (4*FaceCounter)]=new Vector2(dimX,uv1-offset);
												uvs[3+ (4*FaceCounter)]=new Vector2(dimX,uv0-offset);

												break;
										}

								case vWEST:
										{
												//west wall vertices
												offset = CalcCeilOffset(fWEST, t);
												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[WallTexture(fWEST, t)];
												verts[0+ (4*FaceCounter)]=  new Vector3(0f,1.2f, baseHeight);
												verts[1+ (4*FaceCounter)]=  new Vector3(0f,1.2f, floorHeight);
												verts[2+ (4*FaceCounter)]=  new Vector3(0f,0f, floorHeight);
												verts[3+ (4*FaceCounter)]=  new Vector3(0f,0f, baseHeight);
												uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,uv0-offset);
												uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,uv1-offset);
												uvs[2+ (4*FaceCounter)]=new Vector2(1,uv1-offset);
												uvs[3+ (4*FaceCounter)]=new Vector2(1,uv0-offset);

												break;
										}
								}
								FaceCounter++;
						}
				}

				//Apply the uvs and create my tris
				mesh.vertices = verts;
				mesh.uv = uvs;
				int [] tris = new int[6];
				//Tris for diagonal.

				tris[0]=0;
				tris[1]=1;
				tris[2]=2;
				tris[3]=0;
				tris[4]=2;
				tris[5]=3;
				mesh.SetTriangles(tris,0);
				FaceCounter=1;

				for (int i=0;i<6;i++)
				{
						if ((i==vSOUTH) || (i==vWEST))
						{
								if (t.VisibleFaces[i]==1)
								{
										tris[0]=0+(4*FaceCounter);
										tris[1]=1+(4*FaceCounter);
										tris[2]=2+(4*FaceCounter);
										tris[3]=0+(4*FaceCounter);
										tris[4]=2+(4*FaceCounter);
										tris[5]=3+(4*FaceCounter);
										mesh.SetTriangles(tris,FaceCounter);
										FaceCounter++;
								}
						}
				}

				mr.materials= MatsToUse;
				mesh.RecalculateNormals();
				mesh.RecalculateBounds();
				mf.mesh=mesh;
				mc.sharedMesh=mesh;
				return;
		}


		/// <summary>
		/// Gets the wall texture for the specified face
		/// </summary>
		/// <returns>The texture.</returns>
		/// <param name="face">Face.</param>
		/// <param name="t">T.</param>
		static int WallTexture(int face, TileInfo t)
		{
				//return 34;
				int wallTexture;
				//int ceilOffset = 0;
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
				if ((wallTexture<0) || (wallTexture >512))
				{
						wallTexture = 0;
				}
				return GameWorldController.instance.currentTileMap().texture_map[wallTexture];
		}

		/// <summary>
		/// Returns the floor texture from the texture map.
		/// </summary>
		/// <returns>The texture.</returns>
		/// <param name="face">Face.</param>
		/// <param name="t">T.</param>
		static int FloorTexture(int face, TileInfo t)
		{
				int floorTexture;

				if (face == fCEIL)
				{
						floorTexture = GameWorldController.instance.currentTileMap().texture_map[t.shockCeilingTexture];
				}
				else
				{
						//floorTexture = t.floorTexture;
						switch(_RES)
						{
						case GAME_SHOCK:
						case GAME_UW2:
								floorTexture = GameWorldController.instance.currentTileMap().texture_map[t.floorTexture];
								//floorTexture = t.floorTexture;
								break;
						default:
								floorTexture = GameWorldController.instance.currentTileMap().texture_map[t.floorTexture+48];
								break;
						}

				}

				if ((floorTexture<0) || (floorTexture >512))
				{
						floorTexture = 0;
				}
				return floorTexture;
		}

		/*
		/// <summary>
		/// Calculates the sloped ceil offset.
		/// </summary>
		/// <returns>The sloped ceil offset.</returns>
		/// <param name="ceilOffset">Ceil offset.</param>
		static float CalcSlopedCeilOffset (long ceilOffset)
		{
				if (_RES != GAME_SHOCK)
				{
						return 0;
				}
				else
				{
					float shock_ceil =GameWorldController.instance.currentTileMap().SHOCK_CEILING_HEIGHT;
					float floorOffset = shock_ceil - ceilOffset - 8;  //The floor of the tile if it is 1 texture tall.
					while (floorOffset >= 8)  //Reduce the offset to 0 to 7 since textures go up in steps of 1/8ths
					{
							floorOffset -= 8;
					}
					return - floorOffset * 0.125f;	
				}
		}
		*/

		static float CalcCeilOffset(int face, TileInfo t)
		{
				int ceilOffset = t.ceilingHeight;

				if (_RES != GAME_SHOCK)
				{
						return 0;
				}
				else
				{
						switch (face)
						{
						case fEAST:
								ceilOffset = (int)t.shockEastCeilHeight; break;
						case fWEST:
								ceilOffset =(int)t.shockWestCeilHeight; break;
						case fSOUTH:
								ceilOffset = (int)t.shockSouthCeilHeight; break;
						case fNORTH:
								ceilOffset = (int)t.shockNorthCeilHeight; break;
						}
						float shock_ceil =GameWorldController.instance.currentTileMap().SHOCK_CEILING_HEIGHT;
						float floorOffset = shock_ceil - ceilOffset - 8;  //The floor of the tile if it is 1 texture tall.
						while (floorOffset >= 8)  //Reduce the offset to 0 to 7 since textures go up in steps of 1/8ths
						{
								floorOffset -= 8;
						}
						return floorOffset * 0.125f;
				}
		}

		/*
		static void CalcUVsForSlopedTiles(TileInfo t, int SlopeDir , int face, int Steepness, int Floor, int Top, int Bottom, float uv0_default, float uv1_default, out float UV0_OUT, out float UV1_OUT, out float UV2_OUT, out float UV3_OUT)
		{//Obsolete?
			UV0_OUT=uv0_default;
			UV1_OUT=uv1_default;
			UV2_OUT=uv1_default;
			UV3_OUT=uv0_default;	
			float PolySize= Top-Bottom;
			float uv0= (float)(Bottom*0.125f);
			float uv1=(PolySize / 8.0f) + (uv0);
			float AdjustedUV = 0;
			if (Floor==1)
			{
				AdjustedUV = (uv1/(PolySize+(float)Steepness)) * (PolySize);	
			}
			else
			{
						//AdjustedUV = (uv0/(PolySize+(float)Steepness)) * (PolySize);
			}
			if (Floor==1)
			{
				switch(SlopeDir)
				{
				case TILE_SLOPE_N:
					{
						if (face==fEAST)
						{
							UV1_OUT= AdjustedUV; //((UV1_OUT/ (float)(t.floorHeight+Steepness)) * t.floorHeight);
						}
						if (face==fWEST)
						{
							UV2_OUT= AdjustedUV;
						}
						break;
					}
			case TILE_SLOPE_S:
					{
							if (face==fEAST)
							{
									//UV2_OUT= UV2_OUT + dir * getUVAdjust(Steepness);
												UV2_OUT= AdjustedUV;
							}
							if (face==fWEST)
							{
									//UV1_OUT= UV1_OUT + dir* getUVAdjust(Steepness);
												UV1_OUT= AdjustedUV;
							}
							break;
					}	

			case TILE_SLOPE_E:
					{
							if (face==fNORTH)
							{
									//UV2_OUT= UV2_OUT + dir *  getUVAdjust(Steepness);
								UV2_OUT= AdjustedUV;
							}
							if (face==fSOUTH)
							{
									//UV1_OUT= UV1_OUT + dir *  getUVAdjust(Steepness);
								UV1_OUT= AdjustedUV;
							}
							break;
					}	
			case TILE_SLOPE_W:
					{
							if (face==fNORTH)
							{
									//UV1_OUT= UV1_OUT + dir *  getUVAdjust(Steepness);
								UV1_OUT= AdjustedUV;
							}
							if (face==fSOUTH)
							{
									//UV2_OUT= UV2_OUT + dir *  getUVAdjust(Steepness);
								UV2_OUT= AdjustedUV;
							}
							break;
					}
				}	
			}
				else
				{
						return;//These don't work yet
						/*switch(SlopeDir)
						{
						case TILE_SLOPE_N:
								{
										if (face==fEAST)
										{
												UV3_OUT= AdjustedUV;

										}
										if (face==fWEST)
										{
												UV0_OUT= AdjustedUV;
										}
										break;
								}	

						case TILE_SLOPE_S:
								{
										if (face==fEAST)
										{
												UV0_OUT= AdjustedUV;
										}
										if (face==fWEST)
										{
												UV3_OUT= AdjustedUV;
										}
										break;
								}	

						case TILE_SLOPE_E:
								{
										if (face==fNORTH)
										{
												UV0_OUT= AdjustedUV;
										}
										if (face==fSOUTH)
										{
												UV3_OUT= AdjustedUV;
										}
										break;
								}	
						case TILE_SLOPE_W:
								{
										if (face==fNORTH)
										{
												UV3_OUT= AdjustedUV;
										}
										if (face==fSOUTH)
										{
												UV0_OUT= AdjustedUV;
										}
										break;
								}
						}*/
			//	}

	//	}

			



		static void CalcUV(int Top, int Bottom, out float uv0, out float uv1)
		{
			float PolySize= Top-Bottom;
			uv0= (float)(Bottom*0.125f);
			uv1=(PolySize / 8.0f) + (uv0);	
		}



		/// <summary>
		/// Renders a cuboid with sloped tops
		/// </summary>
		/// <param name="parent">Parent.</param>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="t">T.</param>
		/// <param name="Water">If set to <c>true</c> water.</param>
		/// <param name="Bottom">Bottom.</param>
		/// <param name="Top">Top.</param>
		/// <param name="SlopeDir">Slope dir.</param>
		/// <param name="Steepness">Steepness.</param>
		/// <param name="Floor">Floor.</param>
		/// <param name="TileName">Tile name.</param>
		static void RenderSlopedCuboid(GameObject parent, int x, int y, TileInfo t, bool Water, int Bottom, int Top, int SlopeDir, int Steepness, int Floor, string TileName)
		{

				//Draws a cube with sloped tops

				float AdjustUpperNorth = 0f;
				float AdjustUpperSouth = 0f;
				float AdjustUpperEast = 0f;
				float AdjustUpperWest = 0f;

				float AdjustLowerNorth = 0f;
				float AdjustLowerSouth = 0f;
				float AdjustLowerEast = 0f;
				float AdjustLowerWest = 0f;

				float AdjustUpperNorthEast = 0f;
				float AdjustUpperNorthWest = 0f;
				float AdjustUpperSouthEast = 0f;
				float AdjustUpperSouthWest = 0f;

				float AdjustLowerNorthEast = 0f;
				float AdjustLowerNorthWest = 0f;
				float AdjustLowerSouthEast = 0f;
				float AdjustLowerSouthWest = 0f;

				if (Floor == 1)
				{
						switch (SlopeDir)
						{
						case TILE_SLOPE_N:
								AdjustUpperNorth = (float)Steepness*0.15f;
								break;
						case TILE_SLOPE_S:
								AdjustUpperSouth = (float)Steepness*0.15f;
								break;
						case TILE_SLOPE_E:
								AdjustUpperEast =(float)Steepness*0.15f;
								break;
						case TILE_SLOPE_W:
								AdjustUpperWest = (float)Steepness*0.15f;
								break;

						case TILE_VALLEY_NE:
								AdjustUpperNorthEast = +(float)Steepness*0.15f;
								AdjustUpperNorthWest = +(float)Steepness*0.15f;
								AdjustUpperSouthEast = +(float)Steepness*0.15f;
								break;
						case TILE_VALLEY_SE:
								AdjustUpperSouthEast = +(float)Steepness*0.15f;
								AdjustUpperSouthWest = +(float)Steepness*0.15f;
								AdjustUpperNorthEast = +(float)Steepness*0.15f;
								break;
						case TILE_VALLEY_NW:
								AdjustUpperNorthWest = +(float)Steepness*0.15f;
								AdjustUpperNorthEast = +(float)Steepness*0.15f;
								AdjustUpperSouthWest = +(float)Steepness*0.15f;
								break;
						case TILE_VALLEY_SW:
								AdjustUpperSouthWest = +(float)Steepness*0.15f;
								AdjustUpperSouthEast = +(float)Steepness*0.15f;
								AdjustUpperNorthWest = +(float)Steepness*0.15f;
								break;
						case TILE_RIDGE_NE:
								AdjustUpperNorthEast = (float)Steepness*0.15f;
								break;
						case TILE_RIDGE_SE:
								AdjustUpperSouthEast = (float)Steepness*0.15f;
								break;
						case TILE_RIDGE_NW:
								AdjustUpperNorthWest = (float)Steepness*0.15f;
								break;
						case TILE_RIDGE_SW:
								AdjustUpperSouthWest = (float)Steepness*0.15f;
								break;
						}
				}
				if (Floor == 0)
				{
						switch (SlopeDir)
						{
						case TILE_SLOPE_N:
								AdjustLowerNorth = -(float)Steepness*0.15f;
								break;
						case TILE_SLOPE_S:
								AdjustLowerSouth = -(float)Steepness*0.15f;
								break;
						case TILE_SLOPE_E:
								AdjustLowerEast =-(float)Steepness*0.15f;
								break;
						case TILE_SLOPE_W:
								AdjustLowerWest = -(float)Steepness*0.15f;
								break;
						case TILE_VALLEY_NE:
								AdjustLowerSouthWest = -(float)Steepness*0.15f;
								break;
						case TILE_VALLEY_SE:
								AdjustLowerNorthWest = -(float)Steepness*0.15f;
								break;
						case TILE_VALLEY_NW:
								AdjustLowerSouthEast = -(float)Steepness*0.15f;
								break;
						case TILE_VALLEY_SW:
								AdjustLowerNorthEast = -(float)Steepness*0.15f;
								break;
						case TILE_RIDGE_NE:
								AdjustLowerNorthWest = -(float)Steepness*0.15f;
								AdjustLowerSouthEast = -(float)Steepness*0.15f;
								AdjustLowerSouthWest = -(float)Steepness*0.15f;
								break;
						case TILE_RIDGE_SE:								
								AdjustLowerNorthWest = -(float)Steepness*0.15f;
								AdjustLowerSouthWest = -(float)Steepness*0.15f;
								AdjustLowerNorthEast = -(float)Steepness*0.15f;
								break;
						case TILE_RIDGE_NW:								
								AdjustLowerSouthWest = -(float)Steepness*0.15f;
								AdjustLowerSouthEast = -(float)Steepness*0.15f;
								AdjustLowerNorthEast = -(float)Steepness*0.15f;
								break;
						case TILE_RIDGE_SW:
								AdjustLowerNorthWest = -(float)Steepness*0.15f;
								AdjustLowerSouthEast = -(float)Steepness*0.15f;
								AdjustLowerNorthEast = -(float)Steepness*0.15f;
								break;

						}
				}

				int NumberOfVisibleFaces=0;
				int NumberOfSlopedFaces=0;
				int SlopesAdded=0;
				//Get the number of faces
				for (int i=0; i<6;i++)
				{
						if (t.VisibleFaces[i]==1)
						{
								NumberOfVisibleFaces++;
								if (  
										( ((SlopeDir==TILE_SLOPE_N) || (SlopeDir==TILE_SLOPE_S)) && ((i==vWEST) || (i==vEAST) ) )
										||
										( ((SlopeDir==TILE_SLOPE_E) || (SlopeDir==TILE_SLOPE_W)) && ((i==vNORTH) || (i==vSOUTH) ) )
									)
								{
										NumberOfSlopedFaces++;	//SHould only be to a max of two
								}
						}
				}
				//Allocate enough verticea and UVs for the faces
				Material[] MatsToUse=new Material[NumberOfVisibleFaces+NumberOfSlopedFaces];
				Vector3[] verts =new Vector3[NumberOfVisibleFaces*4 + +NumberOfSlopedFaces*3];
				Vector2[] uvs =new Vector2[NumberOfVisibleFaces*4 +NumberOfSlopedFaces*3];
				float offset=0f;
				float floorHeight=(float)(Top*0.15f);
				float baseHeight=(float)(Bottom*0.15f);
				float slopeHeight=0;
				float dimX = t.DimX;
				float dimY = t.DimY;

				//Now create the mesh
				GameObject Tile = new GameObject(TileName);
				if (t.isWater==false)
				{
						if (t.isLava)
						{
								Tile.layer=LayerMask.NameToLayer("Lava");
						}
						else
						{
								Tile.layer=LayerMask.NameToLayer("MapMesh");	
						}
				}
				else
				{
						Tile.layer=LayerMask.NameToLayer("Water");
				}
				Tile.transform.parent=parent.transform;
				Tile.transform.position = new Vector3(x*1.2f,0.0f, y*1.2f);

				Tile.transform.localRotation=Quaternion.Euler(0f,0f,0f);
				MeshFilter mf = Tile.AddComponent<MeshFilter>();
				MeshRenderer mr =Tile.AddComponent<MeshRenderer>();
				MeshCollider mc = Tile.AddComponent<MeshCollider>();
				mc.sharedMesh=null;

				Mesh mesh = new Mesh();
				mesh.subMeshCount=NumberOfVisibleFaces+NumberOfSlopedFaces;//Should be no of visible faces
				//Now allocate the visible faces to triangles.
				int FaceCounter=0;//Tracks which number face we are now on.
				//float PolySize= Top-Bottom;
				//float uv0= (float)(Bottom*0.125f);
				//float uv1=(PolySize / 8.0f) + (uv0);
				float uv0=0f;
				float uv1=0f;
				CalcUV(Top,Bottom, out uv0, out uv1);
				float uv0Slope=0f;
				float uv1Slope=1f;
				if (Floor==1)
				{
					CalcUV(Top+Steepness,Bottom, out uv0Slope, out uv1Slope);
						slopeHeight=floorHeight;
				}
				else
				{
					CalcUV(Top,Bottom-Steepness, out uv0Slope, out uv1Slope);
						slopeHeight=baseHeight;
				}


				for (int i=0;i<6;i++)
				{
						if (t.VisibleFaces[i]==1)
						{
								switch(i)
								{
								case vTOP:
										{

												//Set the verts	
												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[FloorTexture(fSELF, t)];

												switch (SlopeDir)
												{
												case TILE_RIDGE_SE:
												case TILE_RIDGE_NW://Vertices rotated for these
												case TILE_VALLEY_SE:
												case TILE_VALLEY_NW://Vertices rotated for these
														verts[3+ (4*FaceCounter)]=  new Vector3(0.0f, 0.0f,floorHeight+AdjustUpperWest+AdjustUpperSouth+AdjustUpperSouthWest);
														verts[0+ (4*FaceCounter)]=  new Vector3(0.0f, 1.2f*dimY, floorHeight+AdjustUpperWest+AdjustUpperNorth+AdjustUpperNorthWest);
														verts[1+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,1.2f*dimY, floorHeight+AdjustUpperNorth+AdjustUpperEast+AdjustUpperNorthEast);
														verts[2+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0.0f, floorHeight+AdjustUpperSouth+AdjustUpperEast+AdjustUpperSouthEast);
														break;
												default:
														verts[0+ (4*FaceCounter)]=  new Vector3(0.0f, 0.0f,floorHeight+AdjustUpperWest+AdjustUpperSouth+AdjustUpperSouthWest);
														verts[1+ (4*FaceCounter)]=  new Vector3(0.0f, 1.2f*dimY, floorHeight+AdjustUpperWest+AdjustUpperNorth+AdjustUpperNorthWest);
														verts[2+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,1.2f*dimY, floorHeight+AdjustUpperNorth+AdjustUpperEast+AdjustUpperNorthEast);
														verts[3+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0.0f, floorHeight+AdjustUpperSouth+AdjustUpperEast+AdjustUpperSouthEast);
														break;
												}


												//Allocate UVs
												uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,1.0f*dimY);
												uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,0.0f);
												uvs[2+ (4*FaceCounter)]=new Vector2(1.0f*dimX,0.0f);
												uvs[3+ (4*FaceCounter)]=new Vector2(1.0f*dimX,1.0f*dimY);

												break;
										}

								case vNORTH:
										{				
												//north wall vertices
												offset = CalcCeilOffset(fNORTH, t);
												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[WallTexture(fNORTH, t)];
												int oldSlopeDir=SlopeDir;
												if ((Floor==0) && (SlopeDir==TILE_SLOPE_S))
												{
													SlopeDir=TILE_SLOPE_N;
												}
												switch (SlopeDir)
													{
														case TILE_SLOPE_N:
															verts[0+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,1.2f*dimY, baseHeight  +AdjustLowerSouth+AdjustLowerWest);
															verts[1+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,1.2f*dimY, floorHeight+AdjustUpperNorth+AdjustUpperEast);
															verts[2+ (4*FaceCounter)]=  new Vector3(0f,1.2f*dimY, floorHeight+AdjustUpperNorth+AdjustUpperWest);
															verts[3+ (4*FaceCounter)]=  new Vector3(0f,1.2f*dimY, baseHeight+AdjustLowerSouth+AdjustLowerEast);
															uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,uv0Slope-offset);//bottom uv
															uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,uv1Slope-offset);//top uv
															uvs[2+ (4*FaceCounter)]=new Vector2(dimX,uv1Slope-offset);//top uv
															uvs[3+ (4*FaceCounter)]=new Vector2(dimX,uv0Slope-offset);//bottom uv
															break;

														default:
															
															verts[0+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,1.2f*dimY, baseHeight  );
															verts[1+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,1.2f*dimY, floorHeight+AdjustUpperNorthEast);
															verts[2+ (4*FaceCounter)]=  new Vector3(0f,1.2f*dimY, floorHeight+AdjustUpperNorthWest);
															verts[3+ (4*FaceCounter)]=  new Vector3(0f,1.2f*dimY, baseHeight);
															uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,uv0-offset);//bottom uv
															uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,uv1-offset);//top uv
															uvs[2+ (4*FaceCounter)]=new Vector2(dimX,uv1-offset);//top uv
															uvs[3+ (4*FaceCounter)]=new Vector2(dimX,uv0-offset);//bottom uv
															break;
													}
												if ((SlopeDir==TILE_SLOPE_E) || (SlopeDir==TILE_SLOPE_W))
												{//Insert my verts for this slope														
														int index = uvs.GetUpperBound(0)-((NumberOfSlopedFaces-SlopesAdded)*3)+1;
														MatsToUse[MatsToUse.GetUpperBound(0)-NumberOfSlopedFaces+SlopesAdded+1]= MatsToUse[FaceCounter];
														int origSlopeDir=SlopeDir;
														if (Floor==0)
														{//flip my tile types when doing ceilings
															if (SlopeDir==TILE_SLOPE_E)	
															{
																SlopeDir=TILE_SLOPE_W;
															}
															else
															{
																SlopeDir=TILE_SLOPE_E;	
															}
														}

														switch (SlopeDir)
														{
														case TILE_SLOPE_E:
																{
																	verts[index+0]=new Vector3(-1.2f*dimX,1.2f*dimY, slopeHeight  +AdjustLowerSouth+AdjustLowerWest);
																	verts[index+1]= new Vector3(-1.2f*dimX,1.2f*dimY, slopeHeight+AdjustUpperNorth+AdjustUpperEast);
																	verts[index+2]=new Vector3(0f,1.2f*dimY, slopeHeight+AdjustUpperNorth+AdjustUpperWest);

																		float uv0edge=0;float uv1edge=0;float uvToUse=0;
																		if (Floor==1)
																		{
																			CalcUV(Top+Steepness,Top, out uv0edge, out uv1edge  );
																			if (offset==0){uvToUse=+uv0edge;}else{uvToUse=uv0edge-offset;}
																			uvs[index+0]= new Vector2(0,uvToUse);//0, vertical alignment
																			uvs[index+1]= new Vector2(0, uvToUse + (float)Steepness*0.125f); //vertical + scale
																			uvs[index+2]= new Vector2(1,uvToUse);	//1, vertical alignment	
																		}
																		else
																		{
																			CalcUV(Bottom,Bottom-Steepness, out uv0edge, out uv1edge  );
																			if (offset==0){uvToUse=+uv0edge;}else{uvToUse=uv0edge-offset;}//Ceil
																			uvs[index+0]= new Vector2(0,uvToUse);//0, vertical alignment
																			uvs[index+1]= new Vector2(0, uvToUse+ (float)Steepness*0.125f); //vertical + scale
																			uvs[index+2]= new Vector2(1,  uvToUse+(float)Steepness*0.125f);	//1, vertical alignment	
																		}
																	break;		
																}

														case TILE_SLOPE_W:
																{
																	
																	verts[index+0]= new Vector3(-1.2f*dimX,1.2f*dimY, slopeHeight +AdjustUpperNorth+AdjustUpperEast);
																	verts[index+1]= new Vector3(0f,1.2f*dimY, slopeHeight +AdjustUpperNorth+AdjustUpperWest);
																	verts[index+2]= new Vector3(0f,1.2f*dimY, slopeHeight +AdjustLowerSouth+AdjustLowerEast);
																	//uvs[index+0]= new Vector2(0,0);
																	//uvs[index+1]= new Vector2(1,1);
																	//uvs[index+2]= new Vector2(1,0);
																		float uv0edge=0;float uv1edge=0;float uvToUse=0;
																	if (offset==0){uvToUse=+uv0edge;}else{uvToUse=uv0edge-offset;}
																		if (Floor==1)
																		{
																				CalcUV(Top+Steepness,Top, out uv0edge, out uv1edge  );
																				if (offset==0){uvToUse=+uv0edge;}else{uvToUse=uv0edge-offset;}
																			uvs[index+0]= new Vector2(0,uvToUse);//0, vertical alignment
																			uvs[index+1]= new Vector2(1, uvToUse+ (float)Steepness*0.125f); //vertical + scale
																			uvs[index+2]= new Vector2(1,uvToUse);	//1, vertical alignment	
																		}
																		else
																		{
																			CalcUV(Bottom,Bottom-Steepness, out uv0edge, out uv1edge  );
																			if (offset==0){uvToUse=+uv0edge;}else{uvToUse=uv0edge-offset;}//Ceil
																			//uvs[index+0]= new Vector2(0,0);//0, vertical alignment
																			//uvs[index+1]= new Vector2(1,  (float)Steepness*0.125f); //vertical + scale
																			//uvs[index+2]= new Vector2(1,  (float)Steepness*0.125f);	//1, vertical alignment	
																			uvs[index+0]= new Vector2(0, uvToUse+ (float)Steepness*0.125f);
																			uvs[index+1]= new Vector2(1, uvToUse+ (float)Steepness*0.125f); 
																			uvs[index+2]= new Vector2(1, uvToUse);	
																		}
																	break;	
																}

														}
														SlopeDir=origSlopeDir;


														SlopesAdded++;
												}

												SlopeDir=oldSlopeDir;
												break;
										}//end north


								case vSOUTH:
										{
												//south wall vertices
												offset = CalcCeilOffset(fSOUTH, t);
												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[WallTexture(fSOUTH, t)];
												int oldSlopeDir=SlopeDir;
												if ((Floor==0) && (SlopeDir==TILE_SLOPE_N))
												{
														SlopeDir=TILE_SLOPE_S;
												}
												switch (SlopeDir)
												{
												case TILE_SLOPE_S:
														verts[0+ (4*FaceCounter)]=  new Vector3(0f,0f, baseHeight+AdjustLowerNorth+AdjustLowerEast);
														verts[1+ (4*FaceCounter)]=  new Vector3(0f,0f, floorHeight+AdjustUpperSouth+AdjustUpperWest);
														verts[2+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, floorHeight+AdjustUpperSouth+AdjustUpperEast);
														verts[3+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, baseHeight+AdjustLowerNorth+AdjustLowerWest);
														uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,uv0Slope-offset);//bottom uv
														uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,uv1Slope-offset);//top uv
														uvs[2+ (4*FaceCounter)]=new Vector2(dimX,uv1Slope-offset);//top uv
														uvs[3+ (4*FaceCounter)]=new Vector2(dimX,uv0Slope-offset);//bottom uv
														break;
												default:
														verts[0+ (4*FaceCounter)]=  new Vector3(0f,0f, baseHeight);
														verts[1+ (4*FaceCounter)]=  new Vector3(0f,0f, floorHeight+AdjustUpperSouthWest);
														verts[2+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, floorHeight+AdjustUpperSouthEast);
														verts[3+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, baseHeight);
														uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,uv0-offset);
														uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,uv1-offset);
														uvs[2+ (4*FaceCounter)]=new Vector2(dimX,uv1-offset);
														uvs[3+ (4*FaceCounter)]=new Vector2(dimX,uv0-offset);
														break;
												}

												if ((SlopeDir==TILE_SLOPE_E) || (SlopeDir==TILE_SLOPE_W))
												{//Insert my verts for this slope

														int origSlopeDir=SlopeDir;
														if (Floor==0)
														{//flip my tile types when doing ceilings
																if (SlopeDir==TILE_SLOPE_E)	
																{
																		SlopeDir=TILE_SLOPE_W;
																}
																else
																{
																		SlopeDir=TILE_SLOPE_E;	
																}
														}


														int index = uvs.GetUpperBound(0)-((NumberOfSlopedFaces-SlopesAdded)*3)+1;
														MatsToUse[MatsToUse.GetUpperBound(0)-NumberOfSlopedFaces+SlopesAdded+1]= MatsToUse[FaceCounter];
														switch (SlopeDir)
														{
														case TILE_SLOPE_W:
																{

																		verts[index+0]=  new Vector3(0f,0f,slopeHeight+AdjustLowerNorth+AdjustLowerEast);
																		verts[index+1]=  new Vector3(0f,0f, slopeHeight+AdjustUpperSouth+AdjustUpperWest);
																		verts[index+2]=  new Vector3(-1.2f*dimX,0f, slopeHeight+AdjustUpperSouth+AdjustUpperEast);
																		float uv0edge=0;float uv1edge=0;float uvToUse=0;
																		if (Floor==1)
																		{
																			CalcUV(Top+Steepness,Top, out uv0edge, out uv1edge  );
																			if (offset==0){uvToUse=+uv0edge;}else{uvToUse=uv0edge-offset;}
																			uvs[index+0]= new Vector2(0, uvToUse);//0, vertical alignment
																			uvs[index+1]= new Vector2(0, uvToUse+ (float)Steepness*0.125f); //vertical + scale
																			uvs[index+2]= new Vector2(1, uvToUse);	//1, vertical alignment	
																		}
																		else
																		{
																			CalcUV(Bottom,Bottom-Steepness, out uv0edge, out uv1edge  );
																			if (offset==0){uvToUse=+uv0edge;}else{uvToUse=uv0edge-offset;}//Ceil
																				uvs[index+0]= new Vector2(0,uvToUse);//0, vertical alignment
																			uvs[index+1]= new Vector2(0,  uvToUse+(float)Steepness*0.125f); //vertical + scale
																			uvs[index+2]= new Vector2(1, uvToUse+ (float)Steepness*0.125f);	//1, vertical alignment	
																		}
																		break;	
																}

														case TILE_SLOPE_E:
																{

																		verts[index+0]=  new Vector3(0f,0f,slopeHeight+AdjustLowerNorth+AdjustLowerEast);
																		verts[index+1]=  new Vector3(-1.2f*dimX,0f, slopeHeight+AdjustUpperSouth+AdjustUpperEast);
																		verts[index+2]=  new Vector3(-1.2f*dimX,0f, slopeHeight+AdjustLowerNorth+AdjustLowerWest);
																		float uv0edge=0;float uv1edge=0;float uvToUse=0;
																		if (Floor==1)
																		{
																				CalcUV(Top+Steepness,Top, out uv0edge, out uv1edge  );
																				if (offset==0){uvToUse=+uv0edge;}else{uvToUse=uv0edge-offset;}
																			uvs[index+0]= new Vector2(0,uvToUse);//0, vertical alignment
																			uvs[index+1]= new Vector2(1,uvToUse+ (float)Steepness*0.125f); //vertical + scale
																			uvs[index+2]= new Vector2(1,uvToUse);	//1, vertical alignment	
																		}
																		else
																		{
																			//uvs[index+0]= new Vector2(0,0);//0, vertical alignment
																			//uvs[index+1]= new Vector2(1,  (float)Steepness*0.125f); //vertical + scale
																			//uvs[index+2]= new Vector2(1,  (float)Steepness*0.125f);	//1, vertical alignment	
																				CalcUV(Bottom,Bottom-Steepness, out uv0edge, out uv1edge  );
																				if (offset==0){uvToUse=+uv0edge;}else{uvToUse=uv0edge-offset;}//Ceil
																			uvs[index+0]= new Vector2(0, uvToUse+ (float)Steepness*0.125f);
																			uvs[index+1]= new Vector2(1, uvToUse+ (float)Steepness*0.125f); 
																			uvs[index+2]= new Vector2(1, uvToUse);	
																		}
																		break;
																}

														}
														SlopeDir=origSlopeDir;


														SlopesAdded++;
												}

												SlopeDir=oldSlopeDir;
												break;
										}//end south

								case vWEST:
										{
												offset = CalcCeilOffset(fWEST, t);

												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[WallTexture(fWEST, t)];

												int oldSlopeDir=SlopeDir;
												if ((Floor==0) && (SlopeDir==TILE_SLOPE_E))
												{
														SlopeDir=TILE_SLOPE_W;
												}

												switch (SlopeDir)
												{
												case TILE_SLOPE_W:
														verts[0+ (4*FaceCounter)]=  new Vector3(0f,1.2f*dimY, baseHeight+AdjustLowerEast+AdjustLowerSouth);
														verts[1+ (4*FaceCounter)]=  new Vector3(0f,1.2f*dimY, floorHeight+AdjustUpperWest+AdjustUpperNorth);
														verts[2+ (4*FaceCounter)]=  new Vector3(0f,0f, floorHeight+AdjustUpperWest+AdjustUpperSouth);
														verts[3+ (4*FaceCounter)]=  new Vector3(0f,0f, baseHeight+AdjustLowerEast+AdjustLowerNorth);
														uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,uv0Slope-offset);//bottom uv
														uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,uv1Slope-offset);//top uv
														uvs[2+ (4*FaceCounter)]=new Vector2(dimX,uv1Slope-offset);//top uv
														uvs[3+ (4*FaceCounter)]=new Vector2(dimX,uv0Slope-offset);//bottom uv
														break;
												default:
														verts[0+ (4*FaceCounter)]=  new Vector3(0f,1.2f*dimY, baseHeight);
														verts[1+ (4*FaceCounter)]=  new Vector3(0f,1.2f*dimY, floorHeight+AdjustUpperNorthWest);
														verts[2+ (4*FaceCounter)]=  new Vector3(0f,0f, floorHeight+AdjustUpperSouthWest);
														verts[3+ (4*FaceCounter)]=  new Vector3(0f,0f, baseHeight);
														uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,uv0-offset);
														uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,uv1-offset);
														uvs[2+ (4*FaceCounter)]=new Vector2(dimY,uv1-offset);
														uvs[3+ (4*FaceCounter)]=new Vector2(dimY,uv0-offset);

														break;
												}

												if ((SlopeDir==TILE_SLOPE_N) || (SlopeDir==TILE_SLOPE_S))
												{//Insert my verts for this slope
														MatsToUse[MatsToUse.GetUpperBound(0)-NumberOfSlopedFaces+SlopesAdded+1]= MatsToUse[FaceCounter];
														int index = uvs.GetUpperBound(0)-((NumberOfSlopedFaces-SlopesAdded)*3)+1;
														int origSlopeDir=SlopeDir;
														if (Floor==0)
														{//flip my tile types when doing ceilings
															if (SlopeDir==TILE_SLOPE_N)	
															{
																SlopeDir=TILE_SLOPE_S;
															}
															else
															{
																SlopeDir=TILE_SLOPE_N;	
															}
														}
														switch (SlopeDir)
														{
															case TILE_SLOPE_N:
																{
																	
																	verts[index+0]=new Vector3(0f,1.2f*dimY, slopeHeight+AdjustLowerEast+AdjustLowerSouth);
																	verts[index+1]= new Vector3(0f,1.2f*dimY, slopeHeight+AdjustUpperWest+AdjustUpperNorth);
																	verts[index+2]=new Vector3(0f,0f, slopeHeight+AdjustUpperWest+AdjustUpperSouth);
																		float uv0edge=0;float uv1edge=0;float uvToUse=0;
																		if (Floor==1)
																		{
																			CalcUV(Top+Steepness,Top, out uv0edge, out uv1edge  );
																			if (offset==0){uvToUse=+uv0edge;}else{uvToUse=uv0edge-offset;}
																			uvs[index+0]= new Vector2(0,uvToUse);//0, vertical alignment
																			uvs[index+1]= new Vector2(0, uvToUse + (float)Steepness*0.125f); //vertical + scale
																			uvs[index+2]= new Vector2(1,uvToUse);	//1, vertical alignment		
																		}
																		else
																		{
																				CalcUV(Bottom,Bottom-Steepness, out uv0edge, out uv1edge  );
																				if (offset==0){uvToUse=+uv0edge;}else{uvToUse=uv0edge-offset;}//Ceil
																			uvs[index+0]= new Vector2(0, uvToUse);//0, vertical alignment
																			uvs[index+1]= new Vector2(0, uvToUse+ (float)Steepness*0.125f); //vertical + scale
																			uvs[index+2]= new Vector2(1, uvToUse+(float)Steepness*0.125f);	//1, vertical alignment	
																		}


																	break;		
																}

															case TILE_SLOPE_S:
																{
																		//ceil n west
																		verts[index+0]=new Vector3(0f,1.2f*dimY, slopeHeight+AdjustUpperWest+AdjustUpperNorth);
																		verts[index+1]= new Vector3(0f,0f, slopeHeight+AdjustUpperWest+AdjustUpperSouth);
																		verts[index+2]=new Vector3(0f,0f, slopeHeight+AdjustLowerEast+AdjustLowerNorth);
																		float uv0edge=0;float uv1edge=0;float uvToUse=0;
	
																		if (Floor==1)
																		{
																				CalcUV(Top+Steepness,Top, out uv0edge, out uv1edge  );
																				if (offset==0){uvToUse=+uv0edge;}else{uvToUse=uv0edge-offset;}
																			uvs[index+0]= new Vector2(0,uvToUse);//0, vertical alignment
																			uvs[index+1]= new Vector2(1,uvToUse + (float)Steepness*0.125f); //vertical + scale
																			uvs[index+2]= new Vector2(1,uvToUse);	//1, vertical alignment	
																		}
																		else
																		{
																			//uvs[index+0]= new Vector2(0,0);//0, vertical alignment
																			//uvs[index+1]= new Vector2(1, (float)Steepness*0.125f); //vertical + scale
																			//uvs[index+2]= new Vector2(1, (float)Steepness*0.125f);	//1, vertical alignment	
																				CalcUV(Bottom,Bottom-Steepness, out uv0edge, out uv1edge  );
																				if (offset==0){uvToUse=+uv0edge;}else{uvToUse=uv0edge-offset;}//Ceil
																			uvs[index+0]= new Vector2(0, uvToUse+(float)Steepness*0.125f);
																			uvs[index+1]= new Vector2(1, uvToUse+(float)Steepness*0.125f); 
																				uvs[index+2]= new Vector2(1, uvToUse);	
																		}
																		break;	
																}

														}
														SlopeDir=origSlopeDir;


														SlopesAdded++;
												}


												SlopeDir=oldSlopeDir;
												break;

										}//end west

								case vEAST:
										{
												//east wall vertices
												offset = CalcCeilOffset(fEAST, t);

												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[WallTexture(fEAST, t)];

												int oldSlopeDir=SlopeDir;
												if ((Floor==0) && (SlopeDir==TILE_SLOPE_W))
												{
													SlopeDir=TILE_SLOPE_E;
												}
												switch (SlopeDir)
												{
												case TILE_SLOPE_E:
													verts[0+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, baseHeight+AdjustLowerWest+AdjustLowerNorth);
													verts[1+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, floorHeight+AdjustUpperEast+AdjustUpperSouth);
													verts[2+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,1.2f*dimY, floorHeight+AdjustUpperEast+AdjustUpperNorth);
													verts[3+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,1.2f*dimY, baseHeight+AdjustLowerWest+AdjustLowerSouth);
													uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,uv0Slope-offset);//bottom uv
													uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,uv1Slope-offset);//top uv
													uvs[2+ (4*FaceCounter)]=new Vector2(dimX,uv1Slope-offset);//top uv
													uvs[3+ (4*FaceCounter)]=new Vector2(dimX,uv0Slope-offset);//bottom uv
													break;
												default:
													verts[0+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, baseHeight);
													verts[1+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, floorHeight+AdjustUpperSouthEast);
													verts[2+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,1.2f*dimY, floorHeight+AdjustUpperNorthEast);
													verts[3+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,1.2f*dimY, baseHeight);
													uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,uv0-offset);//0
													uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,uv1-offset);//1
													uvs[2+ (4*FaceCounter)]=new Vector2(dimY,uv1-offset);//1
													uvs[3+ (4*FaceCounter)]=new Vector2(dimY,uv0-offset);//0
													break;
												}
												if ((SlopeDir==TILE_SLOPE_N) || (SlopeDir==TILE_SLOPE_S))
												{//Insert my verts for this slope
														
														MatsToUse[MatsToUse.GetUpperBound(0)-NumberOfSlopedFaces+SlopesAdded+1]= MatsToUse[FaceCounter];
														int index = uvs.GetUpperBound(0)-((NumberOfSlopedFaces-SlopesAdded)*3)+1;
														int origSlopeDir=SlopeDir;
														if (Floor==0)
														{//flip my tile types when doing ceilings
																if (SlopeDir==TILE_SLOPE_N)	
																{
																		SlopeDir=TILE_SLOPE_S;
																}
																else
																{
																		SlopeDir=TILE_SLOPE_N;	
																}
														}
														switch (SlopeDir)
														{
														case TILE_SLOPE_S:
																{
																//ceil_n east		
																		verts[index+0]= new Vector3(-1.2f*dimX,0f, slopeHeight+AdjustLowerWest+AdjustLowerNorth);
																		verts[index+1]= new Vector3(-1.2f*dimX,0f, slopeHeight+AdjustUpperEast+AdjustUpperSouth);
																		verts[index+2]= new Vector3(-1.2f*dimX,1.2f*dimY, slopeHeight+AdjustUpperEast+AdjustUpperNorth);
																		float uv0edge=0;float uv1edge=0;float uvToUse=0;
																		if (Floor==1)
																		{
																				CalcUV(Top+Steepness,Top, out uv0edge, out uv1edge  );
																				if (offset==0){uvToUse=+uv0edge;}else{uvToUse=uv0edge-offset;}
																			uvs[index+0]= new Vector2(0,uvToUse);//0, vertical alignment
																			uvs[index+1]= new Vector2(0, uvToUse+ (float)Steepness*0.125f); //vertical + scale
																			uvs[index+2]= new Vector2(1,uvToUse);	//1, vertical alignment	
																		}
																		else
																		{
																				CalcUV(Bottom,Bottom-Steepness, out uv0edge, out uv1edge  );
																				if (offset==0){uvToUse=+uv0edge;}else{uvToUse=uv0edge-offset;}//Ceil
																				uvs[index+0]= new Vector2(0, uvToUse);//0, vertical alignment
																				uvs[index+1]= new Vector2(0, uvToUse+ (float)Steepness*0.125f); //vertical + scale
																				uvs[index+2]= new Vector2(1, uvToUse+ (float)Steepness*0.125f);	//1, vertical alignment	
																		}
																		break;		
																}

														case TILE_SLOPE_N:
																{
																		//hey east on tile s ceil
																		verts[index+0]= new Vector3(-1.2f*dimX,0f, slopeHeight+AdjustUpperEast+AdjustUpperSouth);
																		verts[index+1]= new Vector3(-1.2f*dimX,1.2f*dimY,slopeHeight+AdjustUpperEast+AdjustUpperNorth);
																		verts[index+2]= new Vector3(-1.2f*dimX,1.2f*dimY, slopeHeight+AdjustLowerWest+AdjustLowerSouth);
																		float uv0edge=0;float uv1edge=0;float uvToUse=0;

																		//if (t.shockEastOffset==0){uvToUse=+uv1edge;}else{uvToUse=-uv0edge;}
																		//uvToUse=uv0edge;
																		if (Floor==1)
																		{
																			CalcUV(Top+Steepness,Top, out uv0edge, out uv1edge  );
																			if (offset==0){uvToUse=+uv0edge;}else{uvToUse=uv0edge-offset;}
																			uvs[index+0]= new Vector2(0,uvToUse);//0, vertical alignment
																			uvs[index+1]= new Vector2(1,uvToUse + (float)Steepness*0.125f); //vertical + scale
																			uvs[index+2]= new Vector2(1,uvToUse);	//1, vertical alignment	
																		}
																		else
																		{
																			CalcUV(Bottom,Bottom-Steepness, out uv0edge, out uv1edge  );
																			if (offset==0){uvToUse=+uv0edge;}else{uvToUse=uv0edge-offset;}//Ceil
																			uvs[index+0]= new Vector2(0, uvToUse+(float)Steepness*0.125f);
																			uvs[index+1]= new Vector2(1, uvToUse+(float)Steepness*0.125f); 
																			uvs[index+2]= new Vector2(1, uvToUse);	
																		}
																		break;	
																}


														}
														SlopeDir=origSlopeDir;

														SlopesAdded++;
												}

												SlopeDir=oldSlopeDir;
												break;
										}//end east


								case vBOTTOM:
										{
												//bottom wall vertices
												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[FloorTexture(fCEIL, t)];
												//TODO:Get the lower face adjustments for this (shock only)

												switch (SlopeDir)
												{
												case TILE_VALLEY_NE:
												case TILE_VALLEY_SW://Vertices rotated for these
												case TILE_RIDGE_NE:
												case TILE_RIDGE_SW://Vertices rotated for these
														verts[1+ (4*FaceCounter)]=  new Vector3(0f,1.2f*dimY, baseHeight+AdjustLowerSouth+AdjustLowerEast+AdjustLowerSouthEast);
														verts[2+ (4*FaceCounter)]=  new Vector3(0f,0f, baseHeight+AdjustLowerEast+AdjustLowerNorth+AdjustLowerNorthEast);
														verts[3+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, baseHeight+AdjustLowerNorth+AdjustLowerWest+AdjustLowerNorthWest);
														verts[0+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,1.2f*dimY, baseHeight+AdjustLowerSouth+AdjustLowerWest+AdjustLowerSouthWest);
														break;
												default:
														verts[0+ (4*FaceCounter)]=  new Vector3(0f,1.2f*dimY, baseHeight+AdjustLowerSouth+AdjustLowerEast+AdjustLowerSouthEast);
														verts[1+ (4*FaceCounter)]=  new Vector3(0f,0f, baseHeight+AdjustLowerEast+AdjustLowerNorth+AdjustLowerNorthEast);
														verts[2+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, baseHeight+AdjustLowerNorth+AdjustLowerWest+AdjustLowerNorthWest);
														verts[3+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,1.2f*dimY, baseHeight+AdjustLowerSouth+AdjustLowerWest+AdjustLowerSouthWest);
														break;
												}


												//Change default UVs
												uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,0.0f);
												uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,1.0f*dimY);
												uvs[2+ (4*FaceCounter)]=new Vector2(dimX,1.0f*dimY);
												uvs[3+ (4*FaceCounter)]=new Vector2(dimX,0.0f);
												break;
										}
								}
								FaceCounter++;
						}
				}

				//Apply the uvs and create my tris
				mesh.vertices = verts;
				mesh.uv = uvs;
				FaceCounter=0;

				int [] tris = new int[6];
				int LastIndex=0;
				for (int i=0;i<6;i++)
				{
					if (t.VisibleFaces[i]==1)
					{
						tris[0]=0+(4*FaceCounter) ;
						tris[1]=1+(4*FaceCounter) ;
						tris[2]=2+(4*FaceCounter) ;
						tris[3]=0+(4*FaceCounter) ;
						tris[4]=2+(4*FaceCounter) ;
						tris[5]=3+(4*FaceCounter) ;
						LastIndex=3+(4*FaceCounter);
						mesh.SetTriangles(tris,FaceCounter);

						FaceCounter++;
					}
				}
				//Insert any sloped tris at the end
				tris = new int[3];
				//FaceCounter=0;
				SlopesAdded=0;
				LastIndex++;
				for (int i=0;i<6;i++)
				{
						if (t.VisibleFaces[i]==1)
						{
								if (  
										( ((SlopeDir==TILE_SLOPE_N) || (SlopeDir==TILE_SLOPE_S)) && ((i==vWEST) || (i==vEAST) ) )
										||
										( ((SlopeDir==TILE_SLOPE_E) || (SlopeDir==TILE_SLOPE_W)) && ((i==vNORTH) || (i==vSOUTH) ) )
								)
								{
										tris[0]=0 + LastIndex + (3*SlopesAdded) ;
										tris[1]=1 + LastIndex + (3*SlopesAdded) ;
										tris[2]=2 + LastIndex + (3*SlopesAdded) ;
										mesh.SetTriangles(tris,FaceCounter + SlopesAdded);
										SlopesAdded++;
								}
						}
				}

				mr.materials=MatsToUse;
				mesh.RecalculateNormals();
				mesh.RecalculateBounds();
				mf.mesh=mesh;
				mc.sharedMesh=mesh;

		}





		/// <summary>
		/// Updates the tile properties and if necessary it's neighbours
		/// </summary>
		/// <param name="TileX">Tile x.</param>
		/// <param name="TileY">Tile y.</param>
		/// <param name="NewTileType">New tile type.</param>
		/// <param name="NewFloorHeight">New floor height.</param>
		/// <param name="NewFloorTexture">New floor texture.</param>
		/// <param name="NewWallTexture">New wall texture.</param>
		/// <param name="RenderImmediate">If set to <c>true</c> render immediately. Otherwise wait for next frame.</param>
		public static void UpdateTile(int TileX, int TileY, short NewTileType ,short NewFloorHeight, short NewFloorTexture ,short NewWallTexture, bool RenderImmediate)
		{
				//GameObject tileSelected;
				bool ReRenderNeighbours=false;
				//= GameWorldController.FindTile(TileX,TileX,TileMap.SURFACE_FLOOR);
				//Update entered info
				//TileInfo tileToChange= GameWorldController.instance.currentTileMap().Tiles[TileX,TileY];

				if (RenderImmediate)
				{
					DestroyTile(TileX,TileY);	
				}
				switch (NewTileType)
				{
				case TileMap.TILE_SLOPE_E:
				case TileMap.TILE_SLOPE_W:
				case TileMap.TILE_SLOPE_N:
				case TileMap.TILE_SLOPE_S:
						GameWorldController.instance.currentTileMap().Tiles[TileX,TileY].shockSteep=1;
						break;
				}

				GameWorldController.instance.currentTileMap().Tiles[TileX,TileY].tileType= NewTileType;
				//int FloorHeight=0;
				//if (int.TryParse(TileHeightDetails.text,out FloorHeight))
				//{
				GameWorldController.instance.currentTileMap().Tiles[TileX,TileY].floorHeight= NewFloorHeight; //FloorHeight*2;	
				//}

				GameWorldController.instance.currentTileMap().Tiles[TileX,TileY].floorTexture=NewFloorTexture;
				//int ActualTextureIndex= GameWorldController.instance.currentTileMap().texture_map[FloorTextureSelect.value+48];
				//GameWorldController.instance.currentTileMap().Tiles[TileX,TileY].isWater=TileMap.isTextureWater(ActualTextureIndex);
				//GameWorldController.instance.currentTileMap().Tiles[TileX,TileY].isLava=TileMap.isTextureLava(ActualTextureIndex);
				//TileMapRenderer.RenderTile(GameWorldController.instance.LevelModel,TileX,TileY,GameWorldController.instance.currentTileMap().Tiles[TileX,TileY],GameWorldController.instance.currentTileMap().Tiles[TileX,TileY].isWater,false,false,true);

				if (GameWorldController.instance.currentTileMap().Tiles[TileX,TileY].wallTexture!= NewWallTexture)
				{
						if (GameWorldController.instance.currentTileMap().Tiles[TileX,TileY].tileType==TileMap.TILE_SOLID)
						{
								GameWorldController.instance.currentTileMap().Tiles[TileX,TileY].North=NewWallTexture;
								GameWorldController.instance.currentTileMap().Tiles[TileX,TileY].South=NewWallTexture;
								GameWorldController.instance.currentTileMap().Tiles[TileX,TileY].East=NewWallTexture;
								GameWorldController.instance.currentTileMap().Tiles[TileX,TileY].West=NewWallTexture;
						}
						GameWorldController.instance.currentTileMap().Tiles[TileX,TileY].wallTexture=NewWallTexture;

						if (TileY>0)
						{//Change its neighbour, only if the neighbour is not a solid
								//if (GameWorldController.instance.currentTileMap().Tiles[TileX,TileY-1].tileType>TileMap.TILE_SOLID)
								//{
										GameWorldController.instance.currentTileMap().Tiles[TileX,TileY-1].North=NewWallTexture;	
										ReRenderNeighbours=true;
								//}
						}

						if (TileY<TileMap.TileMapSizeY)
						{//Change its neighbour, only if the neighbour is not a solid
								//if (GameWorldController.instance.currentTileMap().Tiles[TileX,TileY+1].tileType>TileMap.TILE_SOLID)
								//{
										GameWorldController.instance.currentTileMap().Tiles[TileX,TileY+1].South=NewWallTexture;	
										ReRenderNeighbours=true;
								//}
						}

						if (TileX>0)
						{//Change its neighbour, only if the neighbour is not a solid
								//if (GameWorldController.instance.currentTileMap().Tiles[TileX-1,TileY].tileType>TileMap.TILE_SOLID)
								//{
										GameWorldController.instance.currentTileMap().Tiles[TileX-1,TileY].East=NewWallTexture;	
										ReRenderNeighbours=true;
								//}
						}

						if (TileY<TileMap.TileMapSizeY)
						{//Change its neighbour, only if the neighbour is not a solid
								//if (GameWorldController.instance.currentTileMap().Tiles[TileX+1,TileY].tileType>TileMap.TILE_SOLID)
								//{
										GameWorldController.instance.currentTileMap().Tiles[TileX+1,TileY].West=NewWallTexture;
										ReRenderNeighbours=true;
								//}
						}

				}


				if (RenderImmediate)
				{
				//TileMapRenderer.RenderTile(GameWorldController.instance.LevelModel,TileX,TileY,GameWorldController.instance.currentTileMap().Tiles[TileX,TileY],true,false,false,true);
				TileMapRenderer.RenderTile(GameWorldController.instance.LevelModel,TileX,TileY,GameWorldController.instance.currentTileMap().Tiles[TileX,TileY],false,false,false,true);
				}


				if (ReRenderNeighbours)
				{
						for (int x=-1; x<=1; x++)
						{
								for (int y=-1; y<=1; y++)
								{
										if (! ((x==0) && (y==0)))//Not the middle
										{
												if  ((x+TileX<=TileMap.TileMapSizeX) && (x+TileX>=0))
												{
														if ((y+TileY<=TileMap.TileMapSizeY) && (y+TileY>=0))
														{
																if (RenderImmediate)
																{
																DestroyTile(x+TileX,y+TileY);
																//TileMapRenderer.RenderTile(GameWorldController.instance.LevelModel,TileX+y,TileY+y,GameWorldController.instance.currentTileMap().Tiles[TileX+x,TileY+y],true,false,false,true);
																TileMapRenderer.RenderTile(GameWorldController.instance.LevelModel,TileX+x,TileY+y,GameWorldController.instance.currentTileMap().Tiles[TileX+x,TileY+y],false,false,false,true);
																}
														}	
												}
										}
								}

						}

				}


				//RefreshTileMap();

		}



		/// <summary>
		/// Destroys the tile at the specified location
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		public static void DestroyTile(int x, int y)
		{
				GameObject tileSelected;
				switch (GameWorldController.instance.currentTileMap().Tiles[x,y].tileType)
				{
				case TileMap.TILE_SOLID:
						tileSelected= GameWorldController.FindTile(x,y,TileMap.SURFACE_FLOOR);
						if (tileSelected!=null)
						{
								tileSelected.gameObject.transform.position= GameWorldController.instance.InventoryMarker.transform.position;//move away until destroyed
								tileSelected.name = tileSelected.name + "_destroyed";
								GameObject.DestroyImmediate(tileSelected);		
						}
						break;
				case TileMap.TILE_DIAG_NE:
				case TileMap.TILE_DIAG_NW:
				case TileMap.TILE_DIAG_SE:
				case TileMap.TILE_DIAG_SW:
						tileSelected= GameWorldController.FindTile(x,y,TileMap.SURFACE_FLOOR);
						if (tileSelected!=null)
						{
								tileSelected.gameObject.transform.position= GameWorldController.instance.InventoryMarker.transform.position;//move away until destroyed
								tileSelected.name = tileSelected.name + "_destroyed";
								GameObject.DestroyImmediate(tileSelected);		
						}
						tileSelected= GameWorldController.FindTile(x,y,TileMap.SURFACE_WALL);
						if (tileSelected!=null)
						{
								tileSelected.gameObject.transform.position= GameWorldController.instance.InventoryMarker.transform.position;//move away until destroyed
								tileSelected.name = tileSelected.name + "_destroyed";
								GameObject.DestroyImmediate(tileSelected);		
						}
						break;
				default:
						tileSelected= GameWorldController.FindTile(x,y,TileMap.SURFACE_FLOOR);
						if (tileSelected!=null)
						{
								tileSelected.gameObject.transform.position= GameWorldController.instance.InventoryMarker.transform.position;//move away until destroyed
								tileSelected.name = tileSelected.name + "_destroyed";
								GameObject.DestroyImmediate(tileSelected);		
						}
						break;
				}
		}
}