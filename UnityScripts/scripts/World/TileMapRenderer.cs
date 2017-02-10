using UnityEngine;
using System.Collections;

public class TileMapRenderer : Loader{

		const int TILE_SOLID= 0;
		const int TILE_OPEN= 1;
		/*
Note the order of these 4 tiles are actually different in SHOCK. I swap them around in BuildTileMapShock for consistancy
*/
		const int  TILE_DIAG_SE= 2;
		const int  TILE_DIAG_SW =3;
		const int  TILE_DIAG_NE= 4;
		const int  TILE_DIAG_NW =5;

		const int  TILE_SLOPE_N =6;
		const int  TILE_SLOPE_S =7;
		const int 	TILE_SLOPE_E =8;
		const int  TILE_SLOPE_W =9;
		const int  TILE_VALLEY_NW =10;
		const int  TILE_VALLEY_NE= 11;
		const int TILE_VALLEY_SE =12;
		const int  TILE_VALLEY_SW= 13;
		const int  TILE_RIDGE_SE= 14;
		const int  TILE_RIDGE_SW= 15;
		const int  TILE_RIDGE_NW= 16;
		const int  TILE_RIDGE_NE =17;


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

		//Door headings
		const int NORTH=180;
		const int SOUTH=0;
		const int EAST=270;
		const int WEST=90;


		static int UW_CEILING_HEIGHT;
		static int CEILING_HEIGHT;




		public static void GenerateLevelFromTileMap(GameObject parent, int game, TileMap Level, ObjectLoader objList)
		{
				UW_CEILING_HEIGHT=Level.UW_CEILING_HEIGHT;
				CEILING_HEIGHT=Level.CEILING_HEIGHT;
				bool skipCeil=true;

				//Clear out the children in the transform
				foreach (Transform child in parent.transform) {
						GameObject.Destroy(child.gameObject);
				}

				//BuildTileMapUW(Path,1,LevelToRetrieve);


				for (int y = 0; y <= 63; y++)
				{
						for (int x = 0; x <= 63; x++)
						{
								RenderTile(parent, game, x, y, Level.Tiles[x,y], false, false, false, skipCeil);
								RenderTile(parent, game, x, y, Level.Tiles[x,y], true, false, false, skipCeil);
						}
				}

				//Do a ceiling

				if (game != 2)
				{
						TileInfo tmp=new TileInfo();
						//Ceiling
						tmp.tileType = 1;
						tmp.Render = 1;
						tmp.isWater = false;
						tmp.tileX = 0;
						tmp.tileY = 0;
						tmp.DimX = 64;
						tmp.DimY = 64;
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
						RenderTile(parent, game, tmp.tileX, tmp.tileX, tmp, false, false, true, false);


						//Now add a room to store objects objects
						tmp.DimX = 1;
						tmp.DimY = 1;
						tmp.floorHeight = 0;
						for (int i = 0; i < 6; i++)
						{
								tmp.VisibleFaces[i] = 1;
						}
						for (short x = 65; x < 68; x++)
						{
								for (short y = 65; y < 68; y++)
								{
										tmp.tileX = x;
										tmp.tileY = y;
										if ((x != 66) || (y != 66))
										{
												tmp.tileType = 0;
										}
										else
										{
												tmp.tileType = 1;
										}
										RenderTile(parent, game, x, y, tmp, false, false, false, false);
								}
						}
						//And at 99,99 for special stuff.
						for (short x = 98; x < 101; x++)
						{
								for (short y = 98; y < 101; y++)
								{
										tmp.tileX = x;
										tmp.tileY = y;
										if ((x != 99) || (y != 99))
										{
												tmp.tileType = 0;
										}
										else
										{
												tmp.tileType = 1;
										}
										RenderTile(parent, game, x, y, tmp, false, false, false, false);
								}
						}


				}

				//Render bridges, pillars and door ways
				RenderBridges(parent,Level,objList);
				RenderPillars(parent,Level,objList);
				RenderDoorways (parent,Level,objList);
		}

		public static void RenderDoorways(GameObject Parent, TileMap level, ObjectLoader objList)
		{
			for (int i=0; i<=objList.objInfo.GetUpperBound(0);i++)
			{
				if (((objList.objInfo[i].item_id>=320) && (objList.objInfo[i].item_id<=335)) && (objList.objInfo[i].InUseFlag==1))
				{
					RenderDoorwayFront(Parent,level,objList,objList.objInfo[i]);
					RenderDoorwayRear(Parent,level,objList,objList.objInfo[i]);
				}
			}
		}



		public static void RenderDoorwayRear(GameObject Parent, TileMap level, ObjectLoader objList, ObjectLoaderInfo currDoor)
		{

				Material[] MatsToUse = new Material[1];
				for (int j = 0; j<=MatsToUse.GetUpperBound(0);j++)
				{
						MatsToUse[j]= GameWorldController.instance.MaterialMasterList[GameWorldController.instance.currentTileMap().Tiles[currDoor.tileX,currDoor.tileY].wallTexture];
				}

				//positions
				Vector3 position = objList.CalcObjectXYZ(1,level,level.Tiles,objList.objInfo,currDoor.index, currDoor.tileX, currDoor.tileY,0);
				//center in the tile and at the bottom of the map.
				switch (currDoor.heading*45)
				{
				case EAST:
				case WEST:
						position =new Vector3( position.x, 0f, currDoor.tileY*1.2f + 1.2f / 2f);
						break;
				case NORTH:
				case SOUTH:
						position =new Vector3( currDoor.tileX*1.2f + 1.2f / 2f, 0f, position.z);
						break;
				}

				float floorheight =(float) level.Tiles[currDoor.tileX,currDoor.tileY].floorHeight * 0.15f;
				float doorthickness = 0.1f;
				float doorwidth = 0.8f;
				float doorframewidth = 1.2f;
				float doorSideWidth = (doorframewidth-doorwidth)/2f;
				float doorheight = 7.3f * 0.15f;
				float y0 = +doorthickness /2f;
				float y1 = -doorthickness /2f;
				float x0 = -doorframewidth /2f;
				float x1 = +doorframewidth /2f;
				float z0 = 0f;
				float z1 = CEILING_HEIGHT*0.15f;

				//My vertex tris
				Vector3[] leftHand = new Vector3[4];
				switch (currDoor.heading*45)
				{
				case EAST:
				case WEST://Swap x and y
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
				UVs[0]= new Vector2(0f,0f);
				//UVs[1]= new Vector2(0f,CEILING_HEIGHT*0.15f);
				//UVs[2]= new Vector2(doorSideWidth,CEILING_HEIGHT*0.15f);
				UVs[1]= new Vector2(0f,4);
				UVs[2]= new Vector2(doorSideWidth,4);
				UVs[3]= new Vector2(doorSideWidth,0f);

				GameObject tile = RenderCuboid(Parent,leftHand,UVs,position,MatsToUse,1,"leftside_" + ObjectLoader.UniqueObjectName(currDoor));
				tile.transform.Rotate(new Vector3(0f,0f,-180f));


				y0 = +doorthickness /2f;
				y1 = -doorthickness /2f;
				x0 = -doorwidth /2f;
				x1 = +doorwidth /2f;
				z0 = 0f+ floorheight + doorheight;
				z1 = CEILING_HEIGHT*0.15f;
				//1.2
				Vector3[] overHead = new Vector3[4];
				switch (currDoor.heading*45)
				{
				case EAST:
				case WEST://Swap x and y
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
				UVs[0]= new Vector2(0+doorSideWidth, dist);
				UVs[1]= new Vector2(0+doorSideWidth, CEILING_HEIGHT/8f);
				UVs[2]= new Vector2(doorwidth-doorSideWidth, CEILING_HEIGHT/8f);
				UVs[3]= new Vector2(doorwidth-doorSideWidth, dist);

				tile = RenderCuboid(Parent,overHead,UVs,position,MatsToUse,1,"over_" + ObjectLoader.UniqueObjectName(currDoor));
				tile.transform.Rotate(new Vector3(0f,0f,-180f));//TODO:FIx for headings.



				y0 = +doorthickness /2f;
				y1 = -doorthickness /2f;
				x0 = -doorframewidth /2f;
				x1 = +doorframewidth /2f;
				z0 = 0f;
				z1 = CEILING_HEIGHT*0.15f;
				//My vertex tris
				Vector3[] rightHand = new Vector3[4];

				switch (currDoor.heading*45)
				{
				case EAST:
				case WEST://Swap x and y
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
				UVs[0]= new Vector2(doorSideWidth + doorwidth,0f);
				UVs[1]= new Vector2(doorSideWidth + doorwidth,4);
				UVs[2]= new Vector2(doorSideWidth + doorwidth + doorSideWidth,4);
				UVs[3]= new Vector2(doorSideWidth + doorwidth + doorSideWidth,0f);

				tile = RenderCuboid(Parent,rightHand,UVs,position,MatsToUse,1,"rightside_" + ObjectLoader.UniqueObjectName(currDoor));
				tile.transform.Rotate(new Vector3(0f,0f,-180f));

		}










		public static void RenderDoorwayFront(GameObject Parent, TileMap level, ObjectLoader objList, ObjectLoaderInfo currDoor)
		{

				Material[] MatsToUse = new Material[1];
				for (int j = 0; j<=MatsToUse.GetUpperBound(0);j++)
				{
						MatsToUse[j]= GameWorldController.instance.MaterialMasterList[GameWorldController.instance.currentTileMap().Tiles[currDoor.tileX,currDoor.tileY].wallTexture];
				}

				//positions
				Vector3 position = objList.CalcObjectXYZ(1,level,level.Tiles,objList.objInfo,currDoor.index, currDoor.tileX, currDoor.tileY,0);
				//center in the tile and at the bottom of the map.
				switch (currDoor.heading*45)
				{
				case EAST:
				case WEST:
						position =new Vector3( position.x, 0f, currDoor.tileY*1.2f + 1.2f / 2f);
						break;
				case NORTH:
				case SOUTH:
						position =new Vector3( currDoor.tileX*1.2f + 1.2f / 2f, 0f, position.z);
						break;
				}


				float floorheight =(float) level.Tiles[currDoor.tileX,currDoor.tileY].floorHeight * 0.15f;
				float doorthickness = 0.1f;
				float doorwidth = 0.8f;
				float doorframewidth = 1.2f;
				float doorSideWidth = (doorframewidth-doorwidth)/2f;
				float doorheight = 7.3f * 0.15f ;
				float y0 = +doorthickness /2f;
				float y1 = -doorthickness /2f;
				float x0 = -doorframewidth /2f;
				float x1 = +doorframewidth /2f;
				float z0 = 0f;
				float z1 = CEILING_HEIGHT*0.15f;

				//My vertex tris

				Vector3[] leftHand = new Vector3[4];

				switch (currDoor.heading*45)
				{
				case EAST:
				case WEST://Swap x and y
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
				UVs[0]= new Vector2(0f,0f);
				UVs[1]= new Vector2(0f,4);
				UVs[2]= new Vector2(doorSideWidth,4);
				UVs[3]= new Vector2(doorSideWidth,0f);

				RenderCuboid(Parent,leftHand,UVs,position,MatsToUse,1,"leftside_" + ObjectLoader.UniqueObjectName(currDoor));



				y0 = +doorthickness /2f;
				y1 = -doorthickness /2f;
				x0 = -doorwidth /2f;
				x1 = +doorwidth /2f;
				z0 = 0f+ floorheight + doorheight;
				z1 = CEILING_HEIGHT*0.15f;
				//1.2
				Vector3[] overHead = new Vector3[4];


				switch (currDoor.heading*45)
				{
				case EAST:
				case WEST://Swap x and y
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
				UVs[0]= new Vector2(0+doorSideWidth, dist);
				UVs[1]= new Vector2(0+doorSideWidth, CEILING_HEIGHT/8f);
				UVs[2]= new Vector2(doorwidth-doorSideWidth, CEILING_HEIGHT/8f);
				UVs[3]= new Vector2(doorwidth-doorSideWidth, dist);

				RenderCuboid(Parent,overHead,UVs,position,MatsToUse,1,"over_" + ObjectLoader.UniqueObjectName(currDoor));




				y0 = +doorthickness /2f;
				y1 = -doorthickness /2f;
				x0 = -doorframewidth /2f;
				x1 = +doorframewidth /2f;
				z0 = 0f;
				z1 = CEILING_HEIGHT*0.15f;
				//My vertex tris
				Vector3[] rightHand = new Vector3[4];

				switch (currDoor.heading*45)
				{
				case EAST:
				case WEST://Swap x and y
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
				UVs[0]= new Vector2(doorSideWidth + doorwidth,0f);
				UVs[1]= new Vector2(doorSideWidth + doorwidth,4);
				UVs[2]= new Vector2(doorSideWidth + doorwidth + doorSideWidth,4);
				UVs[3]= new Vector2(doorSideWidth + doorwidth + doorSideWidth,0f);

				RenderCuboid(Parent,rightHand,UVs,position,MatsToUse,1,"rightside_" + ObjectLoader.UniqueObjectName(currDoor));

		}

		/*
		public static void RendererDoorWayPortions(GameObject Parent, TileMap level, Vector3 position, ObjectLoaderInfo currdoor, float x0, float x1, float y0, float y1, float z0, float z1)
		{

				Vector3[] Verts= new Vector3[24];
				Vector2[] UVs= new Vector2[24];
				int t=0;
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

				Material[] MatsToUse = new Material[6];
				for (int j = 0; j<=MatsToUse.GetUpperBound(0);j++)
				{
						MatsToUse[j]= GameWorldController.instance.MaterialMasterList[GameWorldController.instance.currentTileMap().Tiles[currdoor.tileX,currdoor.tileY].wallTexture];
				}
				RenderCuboid(Parent, Verts,UVs,position,MatsToUse,6,"portion_" + ObjectLoader.UniqueObjectName(currdoor));
					
		}*/


		public static void RenderPillars(GameObject Parent, TileMap level, ObjectLoader objList)
		{
				for (int i=0; i<=objList.objInfo.GetUpperBound(0);i++)
				{
						if ((objList.objInfo[i].item_id==352) && (objList.objInfo[i].InUseFlag==1))
						{
								Vector3 position = objList.CalcObjectXYZ(1,level,level.Tiles,objList.objInfo,i,(int)objList.objInfo[i].tileX,(int)objList.objInfo[i].tileY,0);
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
								if (tmobj.mainTexture==null)
								{//UW1 style bridges UW2 has some differences....
										tmobj.mainTexture=GameWorldController.instance.TmObjArt.LoadImageAt(TextureIndex);
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



		public static void RenderBridges(GameObject Parent, TileMap level, ObjectLoader objList)
		{
				for (int i=0; i<=objList.objInfo.GetUpperBound(0);i++)
				{
						if ((objList.objInfo[i].item_id==356) && (objList.objInfo[i].InUseFlag==1))
						{
								Vector3 position = objList.CalcObjectXYZ(1,level,level.Tiles,objList.objInfo,i,(int)objList.objInfo[i].tileX,(int)objList.objInfo[i].tileY,0);
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
								Material tmobj = (Material)Resources.Load(_RES+"/Materials/tmobj/tmobj_" + (30 + TextureIndex).ToString());
								if (tmobj.mainTexture==null)
								{//UW1 style bridges UW2 has some differences....
									tmobj.mainTexture=GameWorldController.instance.TmObjArt.LoadImageAt(30 + TextureIndex);
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



		public static void RenderTile(GameObject parent, int game, int x, int y, TileInfo t, bool Water, bool invert, bool skipFloor, bool skipCeil)
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
				case 2:
						{//diag se
								if (skipFloor != true) { RenderDiagSETile( parent , x, y, t, Water, false); }//floor
								if ((skipCeil  != true)) { RenderDiagSETile( parent , x, y, t, Water, true); }
								return;
						}

				case 3:
						{	//diag sw
								if (skipFloor != true) { RenderDiagSWTile( parent , x, y, t, Water, false); }//floor
								if ((skipCeil  != true)) { RenderDiagSWTile( parent , x, y, t, Water, true); }
								return;
						}

				case 4:
						{	//diag ne
								if (skipFloor != true) { RenderDiagNETile( parent , x, y, t, Water, invert); }//floor
								if ((skipCeil  != true)) { RenderDiagNETile( parent , x, y, t, Water, true); }
								return;
						}

				case 5:
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
												if ((skipCeil  != true)) { RenderValleyNWTile( parent , x, y, t, Water, true); }
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
												if ((skipCeil  != true)) { RenderValleyNWTile( parent , x, y, t, Water, true); }
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
												if ((skipCeil  != true)) { RenderValleyNETile( parent , x, y, t, Water, true); }
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
												if ((skipCeil  != true)) { RenderValleyNETile( parent , x, y, t, Water, true); }
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
												if ((skipCeil  != true)) { RenderValleySETile( parent , x, y, t, Water, true); }
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
												if ((skipCeil  != true)) { RenderValleySETile( parent , x, y, t, Water, true); }
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
												if ((skipCeil  != true)) { RenderValleySWTile( parent , x, y, t, Water, true); }
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
												if ((skipCeil  != true)) { RenderValleySWTile( parent , x, y, t, Water, true); }
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
												if ((skipCeil  != true)) { RenderRidgeSETile( parent , x, y, t, Water, true); }
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
												if ((skipCeil  != true)) { RenderRidgeSWTile( parent , x, y, t, Water, true); }
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
												if ((skipCeil  != true)) { RenderRidgeNWTile( parent , x, y, t, Water, true); }
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
												if ((skipCeil  != true)) { RenderRidgeNETile( parent , x, y, t, Water, true); }
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
					Tile.layer=LayerMask.NameToLayer("MapMesh");
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
												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[WallTexture(fNORTH, t)];
												verts[0+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,1.2f*dimY, baseHeight);
												verts[1+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,1.2f*dimY, floorHeight);
												verts[2+ (4*FaceCounter)]=  new Vector3(0f,1.2f*dimY, floorHeight);
												verts[3+ (4*FaceCounter)]=  new Vector3(0f,1.2f*dimY, baseHeight);

												uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,uv0);
												uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,uv1);
												uvs[2+ (4*FaceCounter)]=new Vector2(dimX,uv1);
												uvs[3+ (4*FaceCounter)]=new Vector2(dimX,uv0);


												break;
										}

								case vWEST:
										{
												//west wall vertices
												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[WallTexture(fWEST, t)];
												verts[0+ (4*FaceCounter)]=  new Vector3(0f,1.2f*dimY, baseHeight);
												verts[1+ (4*FaceCounter)]=  new Vector3(0f,1.2f*dimY, floorHeight);
												verts[2+ (4*FaceCounter)]=  new Vector3(0f,0f, floorHeight);
												verts[3+ (4*FaceCounter)]=  new Vector3(0f,0f, baseHeight);
												uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,uv0);
												uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,uv1);
												uvs[2+ (4*FaceCounter)]=new Vector2(dimY,uv1);
												uvs[3+ (4*FaceCounter)]=new Vector2(dimY,uv0);

												break;
										}

								case vEAST:
										{
												//east wall vertices
												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[WallTexture(fEAST, t)];
												verts[0+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, baseHeight);
												verts[1+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, floorHeight);
												verts[2+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,1.2f*dimY, floorHeight);
												verts[3+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,1.2f*dimY, baseHeight);
												uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,uv0);
												uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,uv1);
												uvs[2+ (4*FaceCounter)]=new Vector2(dimY,uv1);
												uvs[3+ (4*FaceCounter)]=new Vector2(dimY,uv0);

												break;
										}

								case vSOUTH:
										{
												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[WallTexture(fSOUTH, t)];
												//south wall vertices
												verts[0+ (4*FaceCounter)]=  new Vector3(0f,0f, baseHeight);
												verts[1+ (4*FaceCounter)]=  new Vector3(0f,0f, floorHeight);
												verts[2+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, floorHeight);
												verts[3+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, baseHeight);
												uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,uv0);
												uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,uv1);
												uvs[2+ (4*FaceCounter)]=new Vector2(dimX,uv1);
												uvs[3+ (4*FaceCounter)]=new Vector2(dimX,uv0);

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
								AdjustUpperNorth = -(float)Steepness*0.15f;
								break;
						case TILE_SLOPE_S:
								AdjustUpperSouth = -(float)Steepness*0.15f;
								break;
						case TILE_SLOPE_E:
								AdjustUpperEast =-(float)Steepness*0.15f;
								break;
						case TILE_SLOPE_W:
								AdjustUpperWest = -(float)Steepness*0.15f;
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
				float floorHeight=(float)(Top*0.15f);
				float baseHeight=(float)(Bottom*0.15f);
				float dimX = t.DimX;
				float dimY = t.DimY;

				//Now create the mesh
				GameObject Tile = new GameObject(TileName);
				if (t.isWater==false)
				{
						Tile.layer=LayerMask.NameToLayer("MapMesh");
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
												//north wall vertices
												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[WallTexture(fNORTH, t)];

												verts[0+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,1.2f*dimY, baseHeight +AdjustLowerNorth+AdjustLowerEast);
												verts[1+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,1.2f*dimY, floorHeight+AdjustUpperNorth+AdjustUpperEast);
												verts[2+ (4*FaceCounter)]=  new Vector3(0f,1.2f*dimY, floorHeight+AdjustUpperNorth+AdjustUpperWest);
												verts[3+ (4*FaceCounter)]=  new Vector3(0f,1.2f*dimY, baseHeight+AdjustLowerNorth+AdjustLowerWest);

												uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,uv0);
												uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,uv1);
												uvs[2+ (4*FaceCounter)]=new Vector2(dimX,uv1);
												uvs[3+ (4*FaceCounter)]=new Vector2(dimX,uv0);


												break;
										}

								case vWEST:
										{
												//west wall vertices
												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[WallTexture(fWEST, t)];
												verts[0+ (4*FaceCounter)]=  new Vector3(0f,1.2f*dimY, baseHeight+AdjustLowerWest+AdjustLowerNorth);
												verts[1+ (4*FaceCounter)]=  new Vector3(0f,1.2f*dimY, floorHeight+AdjustUpperWest+AdjustUpperNorth);
												verts[2+ (4*FaceCounter)]=  new Vector3(0f,0f, floorHeight+AdjustUpperWest+AdjustUpperSouth);
												verts[3+ (4*FaceCounter)]=  new Vector3(0f,0f, baseHeight+AdjustLowerWest+AdjustLowerSouth);
												uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,uv0);
												uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,uv1);
												uvs[2+ (4*FaceCounter)]=new Vector2(dimY,uv1);
												uvs[3+ (4*FaceCounter)]=new Vector2(dimY,uv0);

												break;
										}

								case vEAST:
										{
												//east wall vertices
												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[WallTexture(fEAST, t)];
												verts[0+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, baseHeight+AdjustLowerEast+AdjustLowerSouth);
												verts[1+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, floorHeight+AdjustUpperEast+AdjustUpperSouth);
												verts[2+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,1.2f*dimY, floorHeight+AdjustUpperEast+AdjustUpperNorth);
												verts[3+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,1.2f*dimY, baseHeight+AdjustLowerEast+AdjustLowerNorth);
												uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,uv0);
												uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,uv1);
												uvs[2+ (4*FaceCounter)]=new Vector2(dimY,uv1);
												uvs[3+ (4*FaceCounter)]=new Vector2(dimY,uv0);

												break;
										}

								case vSOUTH:
										{
												//south wall vertices
												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[WallTexture(fSOUTH, t)];
												verts[0+ (4*FaceCounter)]=  new Vector3(0f,0f, baseHeight+AdjustLowerSouth+AdjustLowerWest);
												verts[1+ (4*FaceCounter)]=  new Vector3(0f,0f, floorHeight+AdjustUpperSouth+AdjustUpperWest);
												verts[2+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, floorHeight+AdjustUpperSouth+AdjustUpperEast);
												verts[3+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, baseHeight+AdjustLowerSouth+AdjustLowerEast);
												uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,uv0);
												uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,uv1);
												uvs[2+ (4*FaceCounter)]=new Vector2(dimX,uv1);
												uvs[3+ (4*FaceCounter)]=new Vector2(dimX,uv0);

												break;
										}
								case vBOTTOM:
										{
												//bottom wall vertices
												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[FloorTexture(fCEIL, t)];
												//TODO:Get the lower face adjustments for this (shock only)
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

				mr.materials=MatsToUse;
				mesh.RecalculateNormals();
				mesh.RecalculateBounds();
				mf.mesh=mesh;
				mc.sharedMesh=mesh;

		}

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



		static void RenderSolidTile(GameObject parent, int x, int y, TileInfo t, bool Water)
		{
				if (t.Render == 1)
				{
						if (t.isWater == Water)
						{
								string TileName = "Tile_" + x.ToString("D2") + "_" + y.ToString("D2");
								RenderCuboid( parent, x, y, t, Water, -2, CEILING_HEIGHT + 1, TileName);
						}
				}
		}



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
														RenderCuboid(parent, x, y, t, Water, -2, t.floorHeight, TileName);
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
										TileName = "Tile_" + x.ToString("D2") + "_" + y.ToString("D2");
										RenderCuboid( parent, x, y, t, Water, CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + 1, TileName);
								}
						}
				}
		}


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
										RenderDiagSEPortion(parent, -2, CEILING_HEIGHT + 1, t, TileName);

								}
								if (t.isWater == Water)
								{
										//it's floor
										//RenderDiagNWPortion( -2, t.floorHeight, t,"DiagNW1");
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
								//RenderDiagNWPortion( CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + 1, t, "DiagNW2a");
								RenderOpenTile( parent , x, y, t, Water, true);
						}
				}
				return;
		}


		///
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
										RenderDiagSWPortion(parent, -2, CEILING_HEIGHT + 1, t, TileName);
								}
								if (t.isWater == Water)
								{
										//it's floor
										//RenderDiagNEPortion( -2, t.floorHeight, t,"TileNe1");
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
								//RenderDiagNEPortion( CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + 1, t, "TileNe2");
								RenderOpenTile( parent , x, y, t, Water, true);
						}
				}
				return;
		}



		static void RenderDiagNETile(GameObject parent,int x, int y, TileInfo t, bool Water, bool invert)
		{
				string TileName = "";
				if (t.Render == 1){
						if (invert == false)
						{

								if (Water != true)
								{
										TileName = "Wall_" + x.ToString("D2") + "_" + y.ToString("D2");
										RenderDiagNEPortion(parent, -2, CEILING_HEIGHT + 1, t, TileName);
								}
								if (t.isWater == Water)
								{
										//it's floor
										//RenderDiagSWPortion( -2, t.floorHeight, t, "DiagSW2");
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
								//RenderDiagSWPortion( CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + 1, t, "DiagSE3");
								RenderOpenTile( parent , x, y, t, Water, true);
						}
				}
				return;
		}



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
										RenderDiagNWPortion(parent, -2, CEILING_HEIGHT + 1, t, TileName);
								}


								if (t.isWater == Water)
								{
										//it's floor
										//RenderDiagSEPortion( -2, t.floorHeight, t, "DiagSE2");
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
								//RenderDiagSEPortion( CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + 1, t, "DiagSE3");
								RenderOpenTile( parent , x, y, t, Water, true);
						}
				}
				return;
		}




		////
		/// 
		/// 


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
										RenderSlopedCuboid(parent, x, y, t, Water, -2, t.floorHeight, TILE_SLOPE_N, t.shockSteep, 1, TileName);
								}
						}
						else
						{
								//It's invert
								TileName = "Ceiling_" + x.ToString("D2") + "_" + y.ToString("D2");
								RenderSlopedCuboid(parent, x, y, t, Water, CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + 1, TILE_SLOPE_N, t.shockSteep, 0, TileName);
						}
				}
				return;
		}

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
										RenderSlopedCuboid(parent, x, y, t, Water, -2, t.floorHeight, TILE_SLOPE_S, t.shockSteep, 1, TileName);
								}
						}
						else
						{
								//It's invert
								TileName = "Ceiling_" + x.ToString("D2") + "_" + y.ToString("D2");
								RenderSlopedCuboid(parent, x, y, t, Water, CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + 1, TILE_SLOPE_S, t.shockSteep, 0, TileName);
						}
				}
				return;
		}

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
										RenderSlopedCuboid(parent, x, y, t, Water, -2, t.floorHeight, TILE_SLOPE_W, t.shockSteep, 1, TileName);
								}
						}
						else
						{
								//It's invert
								TileName = "Ceiling_" + x.ToString("D2") + "_" + y.ToString("D2");
								RenderSlopedCuboid(parent, x, y, t, Water, CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + 1, TILE_SLOPE_W, t.shockSteep, 0, TileName);
						}
				}
				return;
		}

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
										RenderSlopedCuboid(parent, x, y, t, Water, -2, t.floorHeight, TILE_SLOPE_E, t.shockSteep, 1, TileName);
								}
						}
						else
						{
								//It's invert
								TileName = "Ceiling_" + x.ToString("D2") + "_" + y.ToString("D2");
								RenderSlopedCuboid(parent, x, y, t, Water, CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + 1, TILE_SLOPE_E, t.shockSteep, 0, TileName);
						}
				}
				return;
		}


		static void RenderValleyNWTile(GameObject parent,int x, int y, TileInfo t, bool Water, bool invert)
		{
				int originalTile = t.tileType;
				t.tileType = TILE_SLOPE_N;
				RenderSlopeNTile( parent , x, y, t, Water, invert);
				t.tileType = TILE_SLOPE_W;
				RenderSlopeWTile( parent , x, y, t, Water, invert);
				t.tileType = originalTile;
				return;
		}


		static void RenderValleyNETile(GameObject parent,int x, int y, TileInfo t, bool Water, bool invert)
		{
				int originalTile = t.tileType;
				t.tileType = TILE_SLOPE_E;
				RenderSlopeETile( parent , x, y, t, Water, invert);
				t.tileType = TILE_SLOPE_N;
				RenderSlopeNTile( parent , x, y, t, Water, invert);
				t.tileType = originalTile;
				return;
		}

		static void RenderValleySWTile(GameObject parent,int x, int y, TileInfo t, bool Water, bool invert)
		{
				int originalTile = t.tileType;
				t.tileType = TILE_SLOPE_W;
				RenderSlopeWTile( parent , x, y, t, Water, invert);
				t.tileType = TILE_SLOPE_S;
				RenderSlopeSTile( parent , x, y, t, Water, invert);
				t.tileType = originalTile;
				return;
		}

		static void RenderValleySETile(GameObject parent,int x, int y, TileInfo t, bool Water, bool invert)
		{
				int originalTile = t.tileType;
				t.tileType = TILE_SLOPE_E;
				RenderSlopeETile( parent , x, y, t, Water, invert);
				t.tileType = TILE_SLOPE_S;
				RenderSlopeSTile( parent , x, y, t, Water, invert);
				t.tileType = originalTile;
				return;
		}




		static void RenderRidgeNWTile(GameObject parent, int x, int y, TileInfo t, bool Water, bool invert)
		{

				if (t.Render == 1)
				{
						if (invert == false)

						{//consists of a slope n and a slope w
								if (t.isWater == Water)
								{
										RenderSlopeNTile( parent , x, y, t, Water, invert);
										RenderSlopeWTile( parent , x, y, t, Water, invert);
								}
						}
						else
						{
								//made of upper slope e and upper slope s

								RenderSlopeETile( parent , x, y, t, Water, invert);
								RenderSlopeSTile( parent , x, y, t, Water, invert);
						}

				}
				return;
		}

		static void RenderRidgeNETile(GameObject parent, int x, int y, TileInfo t, bool Water, bool invert)
		{
				//consists of a slope n and a slope e

				if (t.Render == 1){
						if (invert == false){
								if (t.isWater == Water)
								{
										RenderSlopeNTile( parent , x, y, t, Water, invert);
										RenderSlopeETile( parent , x, y, t, Water, invert);
								}
						}
						else
						{//invert is south and west slopes
								RenderSlopeSTile( parent , x, y, t, Water, invert);
								RenderSlopeWTile( parent , x, y, t, Water, invert);
						}
				}

				return;
		}

		static void RenderRidgeSWTile(GameObject parent, int x, int y, TileInfo t, bool Water, bool invert)
		{
				//consists of a slope s and a slope w
				if (t.Render == 1)
				if (invert == false)
				{
						{
								if (t.isWater == Water)
								{
										RenderSlopeSTile( parent , x, y, t, Water, invert);
										RenderSlopeWTile( parent , x, y, t, Water, invert);
								}
						}
				}
				else
				{	//invert is n and w slopes
						//render a ceiling version of this tile
						RenderSlopeNTile( parent , x, y, t, Water, invert);
						RenderSlopeWTile( parent , x, y, t, Water, invert);

				}
				return;
		}

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
										RenderSlopeSTile( parent , x, y, t, Water, invert);
										RenderSlopeETile( parent , x, y, t, Water, invert);
								}
						}
						else
						{//invert is n w
								//render a ceiling version of this tile
								//top and bottom faces move up
								RenderSlopeNTile( parent , x, y, t, Water, invert);
								RenderSlopeWTile( parent , x, y, t, Water, invert);
						}
				}
				return;
		}




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
												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[WallTexture(fNORTH, t)];
												verts[0+ (4*FaceCounter)]=  new Vector3(-1.2f,1.2f, baseHeight);
												verts[1+ (4*FaceCounter)]=  new Vector3(-1.2f,1.2f, floorHeight);
												verts[2+ (4*FaceCounter)]=  new Vector3(0f,1.2f, floorHeight);
												verts[3+ (4*FaceCounter)]=  new Vector3(0f,1.2f, baseHeight);

												uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,uv0);
												uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,uv1);
												uvs[2+ (4*FaceCounter)]=new Vector2(1,uv1);
												uvs[3+ (4*FaceCounter)]=new Vector2(1,uv0);

												break;
										}

								case vWEST:
										{
												//west wall vertices
												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[WallTexture(fWEST, t)];
												verts[0+ (4*FaceCounter)]=  new Vector3(0f,1.2f, baseHeight);
												verts[1+ (4*FaceCounter)]=  new Vector3(0f,1.2f, floorHeight);
												verts[2+ (4*FaceCounter)]=  new Vector3(0f,0f, floorHeight);
												verts[3+ (4*FaceCounter)]=  new Vector3(0f,0f, baseHeight);
												uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,uv0);
												uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,uv1);
												uvs[2+ (4*FaceCounter)]=new Vector2(1,uv1);
												uvs[3+ (4*FaceCounter)]=new Vector2(1,uv0);

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
												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[WallTexture(fNORTH, t)];
												verts[0+ (4*FaceCounter)]=  new Vector3(-1.2f,1.2f, baseHeight);
												verts[1+ (4*FaceCounter)]=  new Vector3(-1.2f,1.2f, floorHeight);
												verts[2+ (4*FaceCounter)]=  new Vector3(0f,1.2f, floorHeight);
												verts[3+ (4*FaceCounter)]=  new Vector3(0f,1.2f, baseHeight);

												uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,uv0);
												uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,uv1);
												uvs[2+ (4*FaceCounter)]=new Vector2(1,uv1);
												uvs[3+ (4*FaceCounter)]=new Vector2(1,uv0);

												break;
										}

								case vEAST:
										{
												//east wall vertices
												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[WallTexture(fEAST, t)];
												verts[0+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, baseHeight);
												verts[1+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, floorHeight);
												verts[2+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,1.2f*dimY, floorHeight);
												verts[3+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,1.2f*dimY, baseHeight);
												uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,uv0);
												uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,uv1);
												uvs[2+ (4*FaceCounter)]=new Vector2(dimY,uv1);
												uvs[3+ (4*FaceCounter)]=new Vector2(dimY,uv0);

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
												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[WallTexture(fEAST, t)];
												verts[0+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, baseHeight);
												verts[1+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, floorHeight);
												verts[2+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,1.2f*dimY, floorHeight);
												verts[3+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,1.2f*dimY, baseHeight);
												uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,uv0);
												uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,uv1);
												uvs[2+ (4*FaceCounter)]=new Vector2(dimY,uv1);
												uvs[3+ (4*FaceCounter)]=new Vector2(dimY,uv0);

												break;
										}

								case vSOUTH:
										{
												//south wall vertices
												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[WallTexture(fSOUTH, t)];
												verts[0+ (4*FaceCounter)]=  new Vector3(0f,0f, baseHeight);
												verts[1+ (4*FaceCounter)]=  new Vector3(0f,0f, floorHeight);
												verts[2+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, floorHeight);
												verts[3+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, baseHeight);
												uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,uv0);
												uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,uv1);
												uvs[2+ (4*FaceCounter)]=new Vector2(dimX,uv1);
												uvs[3+ (4*FaceCounter)]=new Vector2(dimX,uv0);

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
				float dimY = t.DimY;

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
												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[WallTexture(fSOUTH, t)];
												verts[0+ (4*FaceCounter)]=  new Vector3(0f,0f, baseHeight);
												verts[1+ (4*FaceCounter)]=  new Vector3(0f,0f, floorHeight);
												verts[2+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, floorHeight);
												verts[3+ (4*FaceCounter)]=  new Vector3(-1.2f*dimX,0f, baseHeight);
												uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,uv0);
												uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,uv1);
												uvs[2+ (4*FaceCounter)]=new Vector2(dimX,uv1);
												uvs[3+ (4*FaceCounter)]=new Vector2(dimX,uv0);

												break;
										}

								case vWEST:
										{
												//west wall vertices
												MatsToUse[FaceCounter]=GameWorldController.instance.MaterialMasterList[WallTexture(fWEST, t)];
												verts[0+ (4*FaceCounter)]=  new Vector3(0f,1.2f, baseHeight);
												verts[1+ (4*FaceCounter)]=  new Vector3(0f,1.2f, floorHeight);
												verts[2+ (4*FaceCounter)]=  new Vector3(0f,0f, floorHeight);
												verts[3+ (4*FaceCounter)]=  new Vector3(0f,0f, baseHeight);
												uvs[0+ (4*FaceCounter)]=new Vector2(0.0f,uv0);
												uvs[1 +(4*FaceCounter)]=new Vector2(0.0f,uv1);
												uvs[2+ (4*FaceCounter)]=new Vector2(1,uv1);
												uvs[3+ (4*FaceCounter)]=new Vector2(1,uv0);

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


		static int WallTexture(int face, TileInfo t)
		{
				int wallTexture;
				int ceilOffset = 0;
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
				return wallTexture;
		}

		static int FloorTexture(int face, TileInfo t)
		{
				int floorTexture;

				if (face == fCEIL)
				{
						floorTexture = t.shockCeilingTexture;
				}
				else
				{
						floorTexture = t.floorTexture;
				}

				if ((floorTexture<0) || (floorTexture >512))
				{
						floorTexture = 0;
				}
				return floorTexture;
		}

}
