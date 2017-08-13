using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IngameEditor : GuiBase_Draggable {

		public Material UI_UNLIT;
		public RawImage TileMapView;
		public InputField LevelNoToLoad;

		public Dropdown TileTypeSelect;
		public Dropdown FloorTextureSelect;
		public Dropdown WallTextureSelect;
		public Dropdown FloorTextureMapSelect;
		public Dropdown WallTextureMapSelect;
		public Dropdown DoorTextureMapSelect;

		public Dropdown ObjectSelect;

		public InputField TileRangeX;
		public InputField TileRangeY;

		public Text LevelDetails;
		public Text TileDetails;
		public Text ObjectInfo;

		public InputField TileHeightDetails;

		public RectTransform TileMapDetailsPanel;
		public RectTransform ObjectDetailsPanel;
		public RectTransform TextureMapDetailsPanel;

		public static int TileX=0;
		public static int TileY=0;

		public static IngameEditor instance;

		public GridLayoutGroup FloorTextureMapDisplay;
		public GridLayoutGroup WallTextureMapDisplay;
		public GridLayoutGroup DoorTextureMapDisplay;

		public RawImage SelectedTextureMap;

		public Toggle LockTileType;
		public Toggle LockTileHeight;
		public Toggle LockFloorTextures;
		public Toggle LockWallTextures;

		public static bool FollowMeMode=false;

		void Awake()
		{
			instance=this;
		}



		public override void Start ()
		{
				base.Start();	
				if (GameWorldController.instance.LevelNo!=-1)
				{
						SwitchPanel(0);//Tilemap
						UpdateFloorTexturesDropDown();
						UpdateWallTexturesDropDown();
						UpdateDoorTexturesGrid();
						RefreshTileMap();
						RefreshTileInfo();
				}
		}

		void UpdateObjectsDropDown()
		{
				ObjectSelect.ClearOptions();
				for (int i=0; i<=GameWorldController.instance.CurrentObjectList().objInfo.GetUpperBound(0);i++ )
				{						
						string itemtext= ObjectLoader.UniqueObjectName(GameWorldController.instance.CurrentObjectList().objInfo[i]);
						ObjectSelect.options.Add(new Dropdown.OptionData(itemtext));
				}
				FloorTextureSelect.RefreshShownValue();
		}


		void UpdateFloorTexturesDropDown()
		{
			FloorTextureSelect.ClearOptions();
			FloorTextureMapSelect.ClearOptions();
			foreach (Transform child in FloorTextureMapDisplay.transform) {//Remove the texture maps loaded in the controls
					GameObject.Destroy(child.gameObject);
			}
			for (int i=48; i<=57;i++ )//Uw1 floor texturemap size
			{
				int index= GameWorldController.instance.currentTileMap().texture_map[i];
				string itemtext=index.ToString() +  " " + StringController.instance.GetTextureName(index);
				Texture2D tex =GameWorldController.instance.texLoader.LoadImageAt(index);
				Sprite sprite = Sprite.Create(tex,new Rect(0,0,tex.width,tex.height),new Vector2(0.5f,0.5f) );//THis does not work!!!
				FloorTextureSelect.options.Add(new Dropdown.OptionData(itemtext,sprite));				
				CreateTextureMapButton(GameWorldController.instance.texLoader.LoadImageAt(index),i,index,FloorTextureMapDisplay.transform,TextureMapButton.TextureTypeFloor);
			}

			for (int index=210; index<=261;index++)
			{				
				string itemtext=index.ToString() +  " " + StringController.instance.GetTextureName(index);
				Texture2D tex =GameWorldController.instance.texLoader.LoadImageAt(index);	
				Sprite sprite = Sprite.Create(tex,new Rect(0,0,tex.width,tex.height),new Vector2(0.5f,0.5f) );//THis does not work!!!
				FloorTextureMapSelect.options.Add(new Dropdown.OptionData(itemtext,sprite));					
			}

			FloorTextureSelect.RefreshShownValue();
			FloorTextureMapSelect.RefreshShownValue();
		}


		void UpdateWallTexturesDropDown()
		{
				WallTextureSelect.ClearOptions();
				WallTextureMapSelect.ClearOptions();
				foreach (Transform child in WallTextureMapDisplay.transform) {//Remove the texture maps loaded in the controls
						GameObject.Destroy(child.gameObject);
				}
				for (int i=0; i<=47;i++ )//Uw1 wall texturemap size
				{
					int index= GameWorldController.instance.currentTileMap().texture_map[i];
					string itemtext=index.ToString() +  " " + StringController.instance.GetTextureName(index);
					Texture2D tex =GameWorldController.instance.texLoader.LoadImageAt(index);
					Sprite sprite = Sprite.Create(tex,new Rect(0,0,tex.width,tex.height),new Vector2(0.5f,0.5f) );//THis does not work!!!
					WallTextureSelect.options.Add(new Dropdown.OptionData(itemtext,sprite));
					CreateTextureMapButton(GameWorldController.instance.texLoader.LoadImageAt(index),i,index,WallTextureMapDisplay.transform,TextureMapButton.TextureTypeWall);
				}
				for (int index=0; index<210;index++)
				{				
					string itemtext=index.ToString() +  " " + StringController.instance.GetTextureName(index);
					Texture2D tex =GameWorldController.instance.texLoader.LoadImageAt(index);	
					Sprite sprite = Sprite.Create(tex,new Rect(0,0,tex.width,tex.height),new Vector2(0.5f,0.5f) );//THis does not work!!!
					WallTextureMapSelect.options.Add(new Dropdown.OptionData(itemtext,sprite));					
				}

				WallTextureSelect.RefreshShownValue();
				WallTextureMapSelect.RefreshShownValue();
		}


		void UpdateDoorTexturesGrid()
		{
			DoorTextureMapSelect.ClearOptions();
			foreach (Transform child in DoorTextureMapDisplay.transform) {//Remove the texture maps loaded in the controls
					GameObject.Destroy(child.gameObject);
			}
			for (int i=58; i<64;i++ )//Uw1 door textures
			{		
				int index= GameWorldController.instance.currentTileMap().texture_map[i];
				CreateTextureMapButton ( GameWorldController.instance.MaterialDoors[index].mainTexture,i, index, DoorTextureMapDisplay.transform,TextureMapButton.TextureTypeDoor);				
			}	
			for (int i=0; i<=GameWorldController.instance.MaterialDoors.GetUpperBound(0);i++)
			{
				DoorTextureMapSelect.options.Add(new Dropdown.OptionData("Door_" + i.ToString("D2")));
			}
			DoorTextureMapSelect.RefreshShownValue();
		}

		static void CreateTextureMapButton(Texture tex, int index, int textureIndex, Transform parent,short textureType)
		{
			GameObject textureMapDisplay = (GameObject)Instantiate(Resources.Load("Prefabs/_TextureMapButton"));
			textureMapDisplay.transform.parent=parent;
			textureMapDisplay.GetComponent<TextureMapButton>().MapIndex=index;
			textureMapDisplay.GetComponent<RawImage>().texture=tex;
			textureMapDisplay.GetComponent<TextureMapButton>().img=textureMapDisplay.GetComponent<RawImage>();
			textureMapDisplay.GetComponent<TextureMapButton>().textureType=textureType;
			textureMapDisplay.GetComponent<TextureMapButton>().TextureIndex=textureIndex;
		}


		public void ChangeLevel()
		{
				int levelnotoload=0;
				if (int.TryParse(LevelNoToLoad.text, out levelnotoload))
				{
						if (levelnotoload<= GameWorldController.instance.Tilemaps.GetUpperBound(0))
						{
								GameWorldController.instance.SwitchLevel((short)levelnotoload);
								RefreshTileMap();
								RefreshTileInfo();
								UpdateFloorTexturesDropDown();
								UpdateWallTexturesDropDown();
								UpdateObjectsDropDown();	
						}
						else
						{
								UWHUD.instance.MessageScroll.Add("Invalid Level No");
						}
				}		
		}

		public void RefreshTileMap()
		{
				AutoMap automap= GameWorldController.instance.currentAutoMap();
				TileMap tilemap = GameWorldController.instance.currentTileMap();
				//Mark all tiles as visited
				for (int x=0; x<=TileMap.TileMapSizeX;x++)
				{
						for (int y=0; y<=TileMap.TileMapSizeY;y++)
						{
								automap.MarkTile(x,y,tilemap.Tiles[x,y].tileType, AutoMap.GetDisplayType(tilemap.Tiles[x,y]) );
						}	
				}
				TileMapView.texture= GameWorldController.instance.currentAutoMap().TileMapImage();
				LevelDetails.text= "Level + " + GameWorldController.instance.LevelNo;
		}


		public void ChangeTileX(int offset)
		{
				TileX+=offset;
				if (TileX>TileMap.TileMapSizeX){TileX=0;}
				if (TileX<0){TileX=TileMap.TileMapSizeX;}
				RefreshTileInfo();
		}

		public void ChangeTileY(int offset)
		{
				TileY+=offset;
				if (TileY>TileMap.TileMapSizeY){TileY=0;}
				if (TileY<0){TileY=TileMap.TileMapSizeY;}

				RefreshTileInfo();
		}

		public void RefreshTileInfo()
		{
				TileDetails.text= "X=" + TileX + " Y=" +TileY;
				TileTypeSelect.value= GameWorldController.instance.currentTileMap().Tiles[TileX,TileY].tileType;

				TileHeightDetails.text=  ((float)GameWorldController.instance.currentTileMap().Tiles[TileX,TileY].floorHeight/2f).ToString();
				FloorTextureSelect.value = GameWorldController.instance.currentTileMap().Tiles[TileX,TileY].floorTexture;
				WallTextureSelect.value =  GameWorldController.instance.currentTileMap().Tiles[TileX,TileY].wallTexture;
				RefreshTileMap();
		}


		/*
		public void DestroyTile(int x, int y)
		{
				GameObject tileSelected;
				switch (GameWorldController.instance.currentTileMap().Tiles[x,y].tileType)
				{
				case TileMap.TILE_SOLID:
						tileSelected= GameWorldController.FindTile(x,y,TileMap.SURFACE_WALL);
						if (tileSelected!=null)
						{
								DestroyImmediate(tileSelected);		
						}
						break;
				case TileMap.TILE_DIAG_NE:
				case TileMap.TILE_DIAG_NW:
				case TileMap.TILE_DIAG_SE:
				case TileMap.TILE_DIAG_SW:
						tileSelected= GameWorldController.FindTile(x,y,TileMap.SURFACE_FLOOR);
						if (tileSelected!=null)
						{
								DestroyImmediate(tileSelected);		
						}
						tileSelected= GameWorldController.FindTile(x,y,TileMap.SURFACE_WALL);
						if (tileSelected!=null)
						{
								DestroyImmediate(tileSelected);		
						}
						break;
				default:
						tileSelected= GameWorldController.FindTile(x,y,TileMap.SURFACE_FLOOR);
						if (tileSelected!=null)
						{
								DestroyImmediate(tileSelected);		
						}
						break;
				}


		}
		*/


		public void UpdateTile()
		{
				int DimX=0;int DimY=0;
				int FloorHeight=0;
				int WallTexture= WallTextureSelect.value;
				int FloorTexture= FloorTextureSelect.value;
				int TileTypeSelected= TileTypeSelect.value;		
				int.TryParse(TileHeightDetails.text,out FloorHeight);

				if (LockTileHeight.isOn)
				{
					FloorHeight=-1;
				}
				if(LockTileType.isOn)
				{
					TileTypeSelected=-1;		
				}
				if (LockFloorTextures.isOn)
				{					
					FloorTexture=-1;
				}
				if (LockWallTextures.isOn)
				{					
					WallTexture=-1;
				}

				if (!int.TryParse(TileRangeX.text, out DimX))
				{
						DimX=0;	
				}				
				if (!int.TryParse(TileRangeY.text, out DimY))
				{
						DimY=0;	
				}
				if ((DimX==0) && (DimY==0))
				{//Just update the specified tile
						UpdateTile(TileX,TileY,TileTypeSelected,FloorTexture,WallTexture,FloorHeight);	
				}
				else
				{
						//Find min and max, x & y values
						int MinX= Mathf.Min(TileX, TileX+DimX);
						int MaxX= Mathf.Max(TileX, TileX+DimX);
						int MinY= Mathf.Min(TileY, TileY+DimY);
						int MaxY= Mathf.Max(TileY, TileY+DimY);

						switch(TileTypeSelected)
						{
						case -1://Not tile type change.
						case TileMap.TILE_SOLID:
						case TileMap.TILE_OPEN:
								for (int x=MinX;x <=MaxX; x++)
								{
									for (int y=MinY;y <=MaxY; y++)
									{
										if (TileMap.ValidTile(x,y))
										{
											if (FloorHeight!=-1)
											{
												GameWorldController.instance.currentTileMap().Tiles[x,y].floorHeight=(short)FloorHeight;	
											}
										

											if ((TileTypeSelected==TileMap.TILE_OPEN) || (TileTypeSelected==-1))
											{
												GameWorldController.instance.currentTileMap().Tiles[x,y].VisibleFaces[TileMap.vTOP]=1;
											}
											else
											{
												GameWorldController.instance.currentTileMap().Tiles[x,y].VisibleFaces[TileMap.vTOP]=0;	
											}

											UpdateTile(x,y,TileTypeSelected,FloorTexture,WallTexture,FloorHeight);			
																			
										}
									}	
								}
								break;
						case TileMap.TILE_SLOPE_E:
								{
										int HeightToSet=FloorHeight;
										if (MinX<TileX)
										{//Slopes up to this point
												HeightToSet=  (HeightToSet + (Mathf.Abs(DimX) * -1));
										}
										//else
										//{//slopes up from this point
										//		HeightToSet= HeightToSet;//Mathf.Min(15, (HeightToSet + (DimX * 1)));		
										//}
										for (int x=MinX;x <=MaxX; x++)
										{
												for (int y=MinY;y <=MaxY; y++)
												{
														if ( 
																(TileMap.ValidTile(x,y))
																&&
																(HeightToSet>=0)
																&&
																(HeightToSet<=15)
														)
														{
																GameWorldController.instance.currentTileMap().Tiles[x,y].VisibleFaces[TileMap.vTOP]=1;	
																if (FloorHeight!=-1)
																{
																	GameWorldController.instance.currentTileMap().Tiles[x,y].floorHeight=(short)HeightToSet;																	
																}
																GameWorldController.instance.currentTileMap().Tiles[x,y].shockSteep=2;
																
																UpdateTile(x,y,TileTypeSelected,FloorTexture,WallTexture,HeightToSet);	
														}
												}
												HeightToSet++;
										}
								}								
								break;
						case TileMap.TILE_SLOPE_W:
								{
										int HeightToSet=FloorHeight;
										if (MinX<TileX)
										{//Slopes down this point
												HeightToSet=  (HeightToSet + (Mathf.Abs(DimX) * +1));
										}
										//else
										//{//slopes down from this point
										//		HeightToSet= HeightToSet;//Mathf.Min(15, (HeightToSet + (DimX * 1)));		
										//}
										for (int x=MinX;x <=MaxX; x++)
										{
												for (int y=MinY;y <=MaxY; y++)
												{
														if ( 
																(TileMap.ValidTile(x,y))
																&&
																(HeightToSet>=0)
																&&
																(HeightToSet<=15)
														)
														{
																GameWorldController.instance.currentTileMap().Tiles[x,y].VisibleFaces[TileMap.vTOP]=1;
																if (FloorHeight!=-1)
																{
																GameWorldController.instance.currentTileMap().Tiles[x,y].floorHeight=(short)HeightToSet;
																}
																GameWorldController.instance.currentTileMap().Tiles[x,y].shockSteep=2;																
																UpdateTile(x,y,TileTypeSelected,FloorTexture,WallTexture,HeightToSet);	
														}
												}
												HeightToSet--;
										}
								}								
								break;

						case TileMap.TILE_SLOPE_N:
								{
										int HeightToSet=FloorHeight;
										if (MinY<TileY)
										{//Slopes up to this point
												HeightToSet=  (HeightToSet + (Mathf.Abs(DimY) * -1));
										}
										//else
										//{//slopes up from this point
										//		HeightToSet= HeightToSet;//Mathf.Min(15, (HeightToSet + (DimX * 1)));		
										//}
										for (int y=MinY;y <=MaxY; y++)
										{
												for (int x=MinX;x <=MaxX; x++)
												{
														if ( 
																(TileMap.ValidTile(x,y))
																&&
																(HeightToSet>=0)
																&&
																(HeightToSet<=15)
														)
														{
																GameWorldController.instance.currentTileMap().Tiles[x,y].VisibleFaces[TileMap.vTOP]=1;	
																if (FloorHeight!=-1)
																{
																GameWorldController.instance.currentTileMap().Tiles[x,y].floorHeight=(short)HeightToSet;
																}
																GameWorldController.instance.currentTileMap().Tiles[x,y].shockSteep=2;
																UpdateTile(x,y,TileTypeSelected,FloorTexture,WallTexture,HeightToSet);	
														}
												}
												HeightToSet++;
										}
								}								
								break;
						case TileMap.TILE_SLOPE_S:
								{
										int HeightToSet=FloorHeight;
										if (MinX<TileX)
										{//Slopes down this point
												HeightToSet=  (HeightToSet + (Mathf.Abs(DimY) * +1));
										}
										//else
										//{//slopes down from this point
										//		HeightToSet= HeightToSet;//Mathf.Min(15, (HeightToSet + (DimX * 1)));		
										//}
										for (int y=MinY;y <=MaxY; y++)
										{
												for (int x=MinX;x <=MaxX; x++)
												{
														if ( 
																(TileMap.ValidTile(x,y))
																&&
																(HeightToSet>=0)
																&&
																(HeightToSet<=15)
														)
														{
																GameWorldController.instance.currentTileMap().Tiles[x,y].VisibleFaces[TileMap.vTOP]=1;	
																if (FloorHeight!=-1)
																{
																GameWorldController.instance.currentTileMap().Tiles[x,y].floorHeight=(short)HeightToSet;
																}
																GameWorldController.instance.currentTileMap().Tiles[x,y].shockSteep=2;
																UpdateTile(x,y,TileTypeSelected,FloorTexture,WallTexture,HeightToSet);	
														}
												}
												HeightToSet--;
										}
								}								
								break;

						case TileMap.TILE_DIAG_SE:
						case TileMap.TILE_DIAG_NW:
								{//Turns the smallest square of this tile type in the tile
										int MinSquare = Mathf.Abs(Mathf.Min(DimX,DimY));
										for (int xy=0; xy<=MinSquare;xy++)
										{
												if (TileMap.ValidTile(MinX+ xy, MinY+xy))
												{
														GameWorldController.instance.currentTileMap().Tiles[MinX+ xy, MinY+xy].VisibleFaces[TileMap.vTOP]=1;	
														UpdateTile(MinX+ xy, MinY+xy,TileTypeSelected,FloorTexture,WallTexture,FloorHeight);	
												}	
										}
										break;
								}
							case TileMap.TILE_DIAG_SW:
							case TileMap.TILE_DIAG_NE:
								{//Turns the smallest square of this tile type in the tile
									int MinSquare = Mathf.Abs(Mathf.Min(DimX,DimY));
									for (int xy=0; xy<=MinSquare;xy++)
									{
											if (TileMap.ValidTile(MaxX- xy, MinY+xy))
											{
													GameWorldController.instance.currentTileMap().Tiles[MaxX- xy, MinY+xy].VisibleFaces[TileMap.vTOP]=1;	
													UpdateTile(MaxX- xy, MinY+xy,TileTypeSelected,FloorTexture,WallTexture,FloorHeight);	
											}	
									}
									break;

								}
						}
						
				}			
		}

		public void UpdateTile(int tileXtoUpdate, int tileYtoUpdate, int TileTypeSelected, int FloorTextureSelected, int WallTextureSelected, int FloorHeight)
		{
				bool ReRenderNeighbours=false;

				if (!GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate, tileYtoUpdate].NeedsReRender)
				{
						TileMapRenderer.DestroyTile(tileXtoUpdate, tileYtoUpdate);	
				}
				GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate,tileYtoUpdate].TileNeedsUpdate();

				if (TileTypeSelected!=-1)
				{
					switch (TileTypeSelected)
					{
					case TileMap.TILE_SLOPE_E:
					case TileMap.TILE_SLOPE_W:
					case TileMap.TILE_SLOPE_N:
					case TileMap.TILE_SLOPE_S:
							GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate,tileYtoUpdate].shockSteep=2;
							break;
					}
					GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate,tileYtoUpdate].tileType= (short)TileTypeSelected;	
				}

				if(FloorHeight!=-1)
				{	
				GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate,tileYtoUpdate].floorHeight= (short)(FloorHeight*2);	
				}

				if (FloorTextureSelected!=-1)
				{
					GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate,tileYtoUpdate].floorTexture=(short)(FloorTextureSelected);
					int ActualTextureIndex= GameWorldController.instance.currentTileMap().texture_map[FloorTextureSelected+48];
					GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate,tileYtoUpdate].isWater=TileMap.isTextureWater(ActualTextureIndex);
					GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate,tileYtoUpdate].isLava=TileMap.isTextureLava(ActualTextureIndex);
				}
				if (GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate,tileYtoUpdate].wallTexture!= WallTextureSelected)
				{
						if (GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate,tileYtoUpdate].tileType==TileMap.TILE_SOLID)
						{
							if (WallTextureSelected!=-1)
							{
								GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate,tileYtoUpdate].North=(short)WallTextureSelected;
								GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate,tileYtoUpdate].South=(short)WallTextureSelected;
								GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate,tileYtoUpdate].East=(short)WallTextureSelected;
								GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate,tileYtoUpdate].West=(short)WallTextureSelected;
							}
						}
						if (WallTextureSelected!=-1)
							{
							GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate,tileYtoUpdate].wallTexture=(short)WallTextureSelected;
							
							if (tileYtoUpdate>0)
							{//Change its neighbour, only if the neighbour is not a solid
								if (GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate,tileYtoUpdate-1].tileType>TileMap.TILE_SOLID)
								{
									GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate,tileYtoUpdate-1].North=(short)WallTextureSelected;	
									ReRenderNeighbours=true;
								}
								else if ((FollowMeMode) && (WallTextureSelected!=-1))
								{//Repaint neighouring solid walls in follow mode
										GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate-1,tileYtoUpdate].wallTexture=(short)WallTextureSelected;
										GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate-1,tileYtoUpdate].North=(short)WallTextureSelected	;
										GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate-1,tileYtoUpdate].South=(short)WallTextureSelected	;
										GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate-1,tileYtoUpdate].East=(short)WallTextureSelected	;
										GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate-1,tileYtoUpdate].West=(short)WallTextureSelected	;
										ReRenderNeighbours=true;
								}
							}

							if (tileYtoUpdate<TileMap.TileMapSizeY)
							{//Change its neighbour, only if the neighbour is not a solid
								if (GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate,tileYtoUpdate+1].tileType>TileMap.TILE_SOLID)
								{
									GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate,tileYtoUpdate+1].South=(short)WallTextureSelected;	
									ReRenderNeighbours=true;
								}
								else if ((FollowMeMode) && (WallTextureSelected!=-1))
								{//Repaint neighouring solid walls in follow mode
									GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate,tileYtoUpdate+1].wallTexture=(short)WallTextureSelected;
									GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate,tileYtoUpdate+1].North=(short)WallTextureSelected	;
									GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate,tileYtoUpdate+1].South=(short)WallTextureSelected	;
									GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate,tileYtoUpdate+1].East=(short)WallTextureSelected	;
									GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate,tileYtoUpdate+1].West=(short)WallTextureSelected	;
									ReRenderNeighbours=true;
								}
							}

							if (tileXtoUpdate>0)
							{//Change its neighbour, only if the neighbour is not a solid
								if (GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate-1,tileYtoUpdate].tileType>TileMap.TILE_SOLID)
								{
									GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate-1,tileYtoUpdate].East=(short)WallTextureSelected;	
									ReRenderNeighbours=true;
								}
										else if ((FollowMeMode) && (WallTextureSelected!=-1))
										{//Repaint neighouring solid walls in follow mode
												GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate-1,tileYtoUpdate].wallTexture=(short)WallTextureSelected;
												GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate-1,tileYtoUpdate].North=(short)WallTextureSelected	;
												GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate-1,tileYtoUpdate].South=(short)WallTextureSelected	;
												GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate-1,tileYtoUpdate].East=(short)WallTextureSelected	;
												GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate-1,tileYtoUpdate].West=(short)WallTextureSelected	;
												ReRenderNeighbours=true;
										}
							}

							if (tileXtoUpdate<TileMap.TileMapSizeX)
							{//Change its neighbour, only if the neighbour is not a solid
								if (GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate+1,tileYtoUpdate].tileType>TileMap.TILE_SOLID)
								{
									GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate+1,tileYtoUpdate].West=(short)WallTextureSelected;
									ReRenderNeighbours=true;
								}
								else if ((FollowMeMode) && (WallTextureSelected!=-1))
								{//Repaint neighouring solid walls in follow mode
										GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate+1,tileYtoUpdate].wallTexture=(short)WallTextureSelected;
										GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate+1,tileYtoUpdate].North=(short)WallTextureSelected	;
										GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate+1,tileYtoUpdate].South=(short)WallTextureSelected	;
										GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate+1,tileYtoUpdate].East=(short)WallTextureSelected	;
										GameWorldController.instance.currentTileMap().Tiles[tileXtoUpdate+1,tileYtoUpdate].West=(short)WallTextureSelected	;
										ReRenderNeighbours=true;
								}
							}
						}
					}

				if (ReRenderNeighbours)
				{
						for (int x=-1; x<=1; x++)
						{
								for (int y=-1; y<=1; y++)
								{
										if (! ((x==0) && (y==0)))//Not the middle
										{
												if  ((x+tileXtoUpdate<=TileMap.TileMapSizeX) && (x+tileXtoUpdate>=0))
												{
														if ((y+tileYtoUpdate<=TileMap.TileMapSizeY) && (y+tileYtoUpdate>=0))
														{
																if (!GameWorldController.instance.currentTileMap().Tiles[x+tileXtoUpdate, y+tileYtoUpdate].NeedsReRender)
																{
																		TileMapRenderer.DestroyTile(x+tileXtoUpdate, y+tileYtoUpdate);	
																}															
																GameWorldController.instance.currentTileMap().Tiles[x+tileXtoUpdate,y+tileYtoUpdate].TileNeedsUpdate();
														}	
												}
										}
								}

						}

				}
		}

		public void Teleport()
		{
				float targetX=(float)TileX*1.2f + 0.6f;
				float targetY= (float)TileY*1.2f + 0.6f;

				float Height = ((float)(GameWorldController.instance.currentTileMap().GetFloorHeight(TileX,TileY)))*0.15f;
				GameWorldController.instance.playerUW.gameObject.transform.position = new Vector3(targetX,Height+0.3f,targetY);
		}

		public void SelectCurrentTile()
		{
				TileX=TileMap.visitTileX;
				TileY=TileMap.visitTileY;			
				RefreshTileInfo();
		}

		public void SelectTile(int tileX, int tileY)
		{
			TileX=tileX;
			TileY=tileY;			
			RefreshTileInfo();
		}

		public void SwitchPanel(int Panel)
		{
			TileMapDetailsPanel.gameObject.SetActive(Panel==0);
			ObjectDetailsPanel.gameObject.SetActive(Panel==1);
			TextureMapDetailsPanel.gameObject.SetActive(Panel==2);
			if (Panel==1)
			{
				UpdateObjectsDropDown();
			}
		}


		public void RefreshObjectInfo()
		{
			int i= ObjectSelect.value;
			string ObjectName=ObjectLoader.UniqueObjectName(GameWorldController.instance.CurrentObjectList().objInfo[i]);
			int item_id= GameWorldController.instance.CurrentObjectList().objInfo[i].item_id;
			ObjectInfo.text= ObjectName + "\n" + "Item id = " + item_id;		
		}



		public void ToggleFollowMeMode()
		{
			FollowMeMode=!FollowMeMode;
			UWHUD.instance.MessageScroll.Add("Follow me mode = " + FollowMeMode.ToString());
		}


		/// <summary>
		/// Updates the tile based on the select parameters in the tile editor
		/// </summary>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
		/// Will not change the tile type if the type is a solid
		public static void UpdateFollowMeMode(int tileX, int tileY)
		{
			//int DimX=0;int DimY=0;
			int FloorHeight=0;
			int WallTexture= instance.WallTextureSelect.value;
			int FloorTexture= instance.FloorTextureSelect.value;
			int TileTypeSelected= instance.TileTypeSelect.value;		
			int.TryParse(instance.TileHeightDetails.text,out FloorHeight);

			if (instance.LockTileHeight.isOn)
			{
					FloorHeight=-1;
			}
			if((instance.LockTileType.isOn) || (TileTypeSelected==TileMap.TILE_SOLID))
			{
					TileTypeSelected=-1;		
			}
			if (instance.LockFloorTextures.isOn)
			{					
					FloorTexture=-1;
			}
			if (instance.LockWallTextures.isOn)
			{					
					WallTexture=-1;
			}
			GameWorldController.instance.currentTileMap().Tiles[tileX,tileY].VisibleFaces[TileMap.vTOP]=1;
			IngameEditor.instance.UpdateTile(tileX,tileY,TileTypeSelected,FloorTexture,WallTexture,FloorHeight);
		}

}


