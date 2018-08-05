using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IngameEditor : GuiBase_Draggable {
        public Camera OverheadCam;
		public static int TileX=0;
		public static int TileY=0;

		public ObjectLoaderInfo currObj;

		private bool EditorHidden=false;
		public Material UI_UNLIT;
		public RawImage TileMapView;
		public GameObject EditorBackground;
		public InputField LevelNoToLoad;

		public Dropdown TileTypeSelect;
		public Dropdown FloorTextureSelect;
		public Dropdown WallTextureSelect;
		public Dropdown FloorTextureMapSelect;
		public Dropdown WallTextureMapSelect;
		public Dropdown DoorTextureMapSelect;

		public Dropdown ObjectSelect;
		public Dropdown ObjectItemIds;

		public Toggle ObjectFlagisQuant;
		public Toggle ObjectFlaginVis;
		public Toggle ObjectFlagDoorDir;
		public Toggle ObjectFlagEnchant;
		public InputField ObjectFlagValue;
		public InputField ObjectLink;
		public InputField ObjectOwner;
		public InputField ObjectQuality;
		public InputField ObjectNext;

		public InputField ObjectTileX;
		public InputField ObjectTileY;

		public InputField ObjectXPos;
		public InputField ObjectYPos;
		public InputField ObjectZPos;

		public InputField TileRangeX;
		public InputField TileRangeY;

		public Text LevelDetails;
		public Text TileDetails;

		public InputField TileHeightDetails;

		public RectTransform TileMapDetailsPanel;
		public RectTransform ObjectDetailsPanel;
		public RectTransform TextureMapDetailsPanel;
		public RectTransform MobileObjectDetailsPanel;

		public static IngameEditor instance;

		public GridLayoutGroup FloorTextureMapDisplay;
		public GridLayoutGroup WallTextureMapDisplay;
		public GridLayoutGroup DoorTextureMapDisplay;

		public RawImage SelectedTextureMap;

		public Toggle LockTileType;
		public Toggle LockTileHeight;
		public Toggle LockFloorTextures;
		public Toggle LockWallTextures;

		public InputField npc_whoami;
		public InputField npc_xhome;
		public InputField npc_yhome;
		public InputField npc_hp;
		public Dropdown npc_goal;
		public InputField npc_goaltarget;
		public InputField npc_attitude;
		public InputField npc_talkedto;

        public InputField seed;


		public static bool FollowMeMode=false;

		void Awake()
		{
			instance=this;
		}

		public override void Start ()
		{
			base.Start();
            seed.text = UnderworldGenerator.instance.Seed.ToString();
			if (GameWorldController.instance.LevelNo!=-1)
			{
					SwitchPanel(0);//Tilemap
					UpdateFloorTexturesDropDown();
					UpdateWallTexturesDropDown();
					UpdateDoorTexturesGrid();
					RefreshTileMap();
					RefreshTileInfo();
					UpdateNPCGoals();
			}
			//Initiliase Item Ids
			for (int i=0; i<=GameWorldController.instance.objectMaster.objProp.GetUpperBound(0);i++)
			{
				ObjectItemIds.options.Add(new Dropdown.OptionData(GameWorldController.instance.objectMaster.objProp[i].desc));	
			}
		}

		void UpdateObjectsDropDown()
		{
				ObjectSelect.ClearOptions();
				ObjectLoader objList = GameWorldController.instance.CurrentObjectList();

				for (int i=0; i<=objList.objInfo.GetUpperBound(0);i++ )
				{				
						if (objList.objInfo[i]!=null)		
						{
								string itemtext= ObjectLoader.UniqueObjectNameEditor(GameWorldController.instance.CurrentObjectList().objInfo[i]);
								ObjectSelect.options.Add(new Dropdown.OptionData(itemtext));

						}
				}
				ObjectSelect.RefreshShownValue();
		}


		void UpdateNPCGoals()
		{
				npc_goal.ClearOptions();
				npc_goal.options.Add(new Dropdown.OptionData("0-Stand Still"));
				npc_goal.options.Add(new Dropdown.OptionData("1-Random Movement"));
				npc_goal.options.Add(new Dropdown.OptionData("2-Random Movement"));
				npc_goal.options.Add(new Dropdown.OptionData("3-Follow Target"));
				npc_goal.options.Add(new Dropdown.OptionData("4-Random Movement"));
				npc_goal.options.Add(new Dropdown.OptionData("5-Attack Target"));
				npc_goal.options.Add(new Dropdown.OptionData("6-Flee Target"));
				npc_goal.options.Add(new Dropdown.OptionData("7-Stand Still"));
				npc_goal.options.Add(new Dropdown.OptionData("8-Random Movement"));
				npc_goal.options.Add(new Dropdown.OptionData("9-Attack Target"));
				npc_goal.options.Add(new Dropdown.OptionData("10-Begin Conversation"));
				npc_goal.options.Add(new Dropdown.OptionData("11-Stand Still"));
				npc_goal.options.Add(new Dropdown.OptionData("12-Stand Still"));
				npc_goal.RefreshShownValue();
		}

		void UpdateFloorTexturesDropDown()
		{
			FloorTextureSelect.ClearOptions();
			FloorTextureMapSelect.ClearOptions();
			foreach (Transform child in FloorTextureMapDisplay.transform) {//Remove the texture maps loaded in the controls
					GameObject.Destroy(child.gameObject);
			}

				switch(_RES)
				{
				case GAME_UW2:
						for (int i=0; i<64;i++ )//UW2 entire texture map
						{
							int index= GameWorldController.instance.currentTileMap().texture_map[i];
							string itemtext=index.ToString() +  " " + StringController.instance.GetTextureName(index);
							Texture2D tex =GameWorldController.instance.texLoader.LoadImageAt(index);
							Sprite sprite = Sprite.Create(tex,new Rect(0,0,tex.width,tex.height),new Vector2(0.5f,0.5f) );//THis does not work!!!
							FloorTextureSelect.options.Add(new Dropdown.OptionData(itemtext,sprite));				
							CreateTextureMapButton(GameWorldController.instance.texLoader.LoadImageAt(index),i,index,FloorTextureMapDisplay.transform,TextureMapButton.TextureTypeFloor);									
						}
						for (int index=0; index<256;index++) //All uw2 textures
						{				
								string itemtext=index.ToString() +  " " + StringController.instance.GetTextureName(index);
								Texture2D tex =GameWorldController.instance.texLoader.LoadImageAt(index);	
								Sprite sprite = Sprite.Create(tex,new Rect(0,0,tex.width,tex.height),new Vector2(0.5f,0.5f) );//THis does not work!!!
								FloorTextureMapSelect.options.Add(new Dropdown.OptionData(itemtext,sprite));					
						}

						FloorTextureMapDisplay.constraintCount=20;
						FloorTextureMapDisplay.spacing= new Vector2(-18f,-20f);
						break;

				default:
					{
						for (int i=48; i<=57;i++ )//Uw1 floor texturemap size
						{
							int index= GameWorldController.instance.currentTileMap().texture_map[i];
							string itemtext=index.ToString() +  " " + StringController.instance.GetTextureName(index);
							Texture2D tex =GameWorldController.instance.texLoader.LoadImageAt(index);
							Sprite sprite = Sprite.Create(tex,new Rect(0,0,tex.width,tex.height),new Vector2(0.5f,0.5f) );//THis does not work!!!
							FloorTextureSelect.options.Add(new Dropdown.OptionData(itemtext,sprite));				
							CreateTextureMapButton(GameWorldController.instance.texLoader.LoadImageAt(index),i,index,FloorTextureMapDisplay.transform,TextureMapButton.TextureTypeFloor);
						}

						for (int index=210; index<=261;index++) //All floor textures
						{				
							string itemtext=index.ToString() +  " " + StringController.instance.GetTextureName(index);
							Texture2D tex =GameWorldController.instance.texLoader.LoadImageAt(index);	
							Sprite sprite = Sprite.Create(tex,new Rect(0,0,tex.width,tex.height),new Vector2(0.5f,0.5f) );//THis does not work!!!
							FloorTextureMapSelect.options.Add(new Dropdown.OptionData(itemtext,sprite));					
						}
						break;
					}
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
				switch(_RES)
				{
				case GAME_UW2:
						{
								for (int i=0; i<64;i++ )//Uw2 texturemap size
								{
										int index= GameWorldController.instance.currentTileMap().texture_map[i];
										string itemtext=index.ToString() +  " " + StringController.instance.GetTextureName(index);
										Texture2D tex =GameWorldController.instance.texLoader.LoadImageAt(index);
										Sprite sprite = Sprite.Create(tex,new Rect(0,0,tex.width,tex.height),new Vector2(0.5f,0.5f) );//THis does not work!!!
										WallTextureSelect.options.Add(new Dropdown.OptionData(itemtext,sprite));
										CreateTextureMapButton(GameWorldController.instance.texLoader.LoadImageAt(index),i,index,WallTextureMapDisplay.transform,TextureMapButton.TextureTypeWall);
								}
								for (int index=0; index<256;index++)
								{				
										string itemtext=index.ToString() +  " " + StringController.instance.GetTextureName(index);
										Texture2D tex =GameWorldController.instance.texLoader.LoadImageAt(index);	
										Sprite sprite = Sprite.Create(tex,new Rect(0,0,tex.width,tex.height),new Vector2(0.5f,0.5f) );//THis does not work!!!
										WallTextureMapSelect.options.Add(new Dropdown.OptionData(itemtext,sprite));					
								}
								WallTextureMapDisplay.constraintCount=20;
								WallTextureMapDisplay.spacing= new Vector2(-18f,-20f);
								break;
						}
				default:
						{
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
								break;
						}

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
				switch(_RES)
				{

				case GAME_UW2:
						{
							for (int i=64; i<70;i++ )//Uw2 door textures
							{		
									int index= GameWorldController.instance.currentTileMap().texture_map[i];
									CreateTextureMapButton ( GameWorldController.instance.MaterialDoors[index].mainTexture,i, index, DoorTextureMapDisplay.transform,TextureMapButton.TextureTypeDoor);				
							}	
							for (int i=0; i<=GameWorldController.instance.MaterialDoors.GetUpperBound(0);i++)
							{
									DoorTextureMapSelect.options.Add(new Dropdown.OptionData("Door_" + i.ToString("D2")));
							}
							break;
						}

					default:
					{
						for (int i=58; i<64;i++ )//Uw1 door textures
						{		
								int index= GameWorldController.instance.currentTileMap().texture_map[i];
								CreateTextureMapButton ( GameWorldController.instance.MaterialDoors[index].mainTexture,i, index, DoorTextureMapDisplay.transform,TextureMapButton.TextureTypeDoor);				
						}	
						for (int i=0; i<=GameWorldController.instance.MaterialDoors.GetUpperBound(0);i++)
						{
								DoorTextureMapSelect.options.Add(new Dropdown.OptionData("Door_" + i.ToString("D2")));
						}
						break;
					}

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
												GameWorldController.instance.currentTileMap().Tiles[x,y].VisibleFaces[TileMap.vTOP]=true;
											}
											else
											{
												GameWorldController.instance.currentTileMap().Tiles[x,y].VisibleFaces[TileMap.vTOP]=false;	
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
																GameWorldController.instance.currentTileMap().Tiles[x,y].VisibleFaces[TileMap.vTOP]=true;	
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
																GameWorldController.instance.currentTileMap().Tiles[x,y].VisibleFaces[TileMap.vTOP]=true;
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
																GameWorldController.instance.currentTileMap().Tiles[x,y].VisibleFaces[TileMap.vTOP]=true;	
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
																GameWorldController.instance.currentTileMap().Tiles[x,y].VisibleFaces[TileMap.vTOP]=true;	
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
														GameWorldController.instance.currentTileMap().Tiles[MinX+ xy, MinY+xy].VisibleFaces[TileMap.vTOP]=true;	
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
														GameWorldController.instance.currentTileMap().Tiles[MaxX- xy, MinY+xy].VisibleFaces[TileMap.vTOP]=true;	
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
				if (ObjectDetailsPanel.gameObject.activeInHierarchy)
				{
						if (currObj.tileX!=99)
						{
								targetX=(float)currObj.tileX*1.2f + 0.6f;	
						}
						if (currObj.tileY!=99)
						{
								targetY=(float)currObj.tileY*1.2f + 0.6f;	
						}

				}

				float Height = ((float)(GameWorldController.instance.currentTileMap().GetFloorHeight(TileX,TileY)))*0.15f;
				UWCharacter.Instance.gameObject.transform.position = new Vector3(targetX,Height+0.3f,targetY);
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
			if (Panel!=1)
			{
				MobileObjectDetailsPanel.gameObject.SetActive(false);
			}
		}


		public void TogglePanels()
		{
			if (!EditorHidden)	
			{
				SwitchPanel(-1);
				EditorHidden=true;
			}
			else
			{
				SwitchPanel(0);
				EditorHidden=false;
			}
			EditorBackground.SetActive(!EditorHidden);
		}

		public void RefreshObjectInfo()
		{
			currObj=GameWorldController.instance.CurrentObjectList().objInfo[ObjectSelect.value];
			//string ObjectName=ObjectLoader.UniqueObjectNameEditor(currObj);
			ObjectItemIds.value = currObj.item_id; 
			ObjectFlagDoorDir.isOn = (currObj.doordir==1);
			ObjectFlagEnchant.isOn= (currObj.enchantment==1);
			ObjectFlaginVis.isOn= (currObj.invis==1);
			ObjectFlagisQuant.isOn=(currObj.is_quant==1);
			ObjectFlagValue.text=currObj.flags.ToString();
			ObjectOwner.text=currObj.owner.ToString();
			ObjectLink.text=currObj.link.ToString();
			ObjectNext.text=currObj.next.ToString();
			ObjectQuality.text=currObj.quality.ToString();
			if (currObj.instance!=null)
			{
				currObj.instance.UpdatePosition();
			}
			ObjectTileX.text=currObj.tileX.ToString();
			ObjectTileY.text=currObj.tileY.ToString();

			ObjectXPos.text=currObj.x.ToString();
			ObjectYPos.text=currObj.y.ToString();
			ObjectZPos.text=currObj.zpos.ToString();

			MobileObjectDetailsPanel.gameObject.SetActive((currObj.index<=255));
			if (currObj.index<=255)
			{
				//populate mobile data
				npc_whoami.text=currObj.npc_whoami.ToString();
				npc_xhome.text=currObj.npc_xhome.ToString();
				npc_yhome.text=currObj.npc_yhome.ToString();
				npc_hp.text=currObj.npc_hp.ToString();
				npc_goal.value=currObj.npc_goal;
				npc_goaltarget.text=currObj.npc_gtarg.ToString();
				npc_attitude.text=currObj.npc_attitude.ToString();
				npc_talkedto.text=currObj.npc_talkedto.ToString();
			}
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
			GameWorldController.instance.currentTileMap().Tiles[tileX,tileY].VisibleFaces[TileMap.vTOP]=true;
			IngameEditor.instance.UpdateTile(tileX,tileY,TileTypeSelected,FloorTexture,WallTexture,FloorHeight);
		}


		public void ObjectEditorApplyChanges()
		{
			currObj.item_id= ObjectItemIds.value;
			if (ObjectFlagisQuant.isOn)
			{
				currObj.is_quant=1;
			}
			else
			{
				currObj.is_quant=0;
			}

			if (ObjectFlaginVis.isOn)
			{
					currObj.invis=1;
			}
			else
			{
					currObj.invis=0;
			}

			if (ObjectFlagDoorDir.isOn)
			{
				currObj.doordir=1;
			}
			else
			{
				currObj.doordir=0;
			}

			if (ObjectFlagEnchant.isOn)
			{
				currObj.enchantment=1;
			}
			else
			{
				currObj.enchantment=0;
			}
			int val=0;
			if (int.TryParse(ObjectFlagValue.text, out val))
			{
				currObj.flags= (short)(val & 0x7);
				ObjectFlagValue.text=currObj.flags.ToString();
			}

			if (int.TryParse(ObjectOwner.text, out val))
			{
				currObj.owner= (short)(val & 0x3F);
				ObjectOwner.text=currObj.owner.ToString();
			}

			if (int.TryParse(ObjectLink.text, out val))
			{
				currObj.link= (short)(val & 0x3FF);
				ObjectLink.text=currObj.link.ToString();
			}

			if (int.TryParse(ObjectQuality.text, out val))
			{
				currObj.quality= (short)(val & 0x3F);
				ObjectQuality.text=currObj.quality.ToString();
			}

				if (currObj.index<=255)
				{//A mobile object
						if (int.TryParse(npc_whoami.text, out val))
						{
							currObj.npc_whoami =(short)(val);
							npc_whoami.text=currObj.npc_whoami.ToString();
						}
						if (int.TryParse(npc_xhome.text, out val))
						{
							currObj.npc_xhome =(short)(val);
							npc_xhome.text=currObj.npc_xhome.ToString();
						}
						if (int.TryParse(npc_yhome.text, out val))
						{
							currObj.npc_yhome =(short)(val);
							npc_yhome.text=currObj.npc_yhome.ToString();
						}
						if (int.TryParse(npc_hp.text, out val))
						{
							currObj.npc_hp =(short)(val);
							npc_hp.text=currObj.npc_hp.ToString();
						}

						currObj.npc_goal=(short)npc_goal.value;

						if (int.TryParse(npc_goaltarget.text, out val))
						{
								currObj.npc_gtarg =(short)(val);
								npc_goaltarget.text=currObj.npc_gtarg.ToString();
						}


						if (int.TryParse(npc_attitude.text, out val))
						{
							currObj.npc_attitude =(short)(val);
							npc_attitude.text=currObj.npc_attitude.ToString();
						}
						if (int.TryParse(npc_talkedto.text, out val))
						{
							currObj.npc_talkedto =(short)(val & 0x1);
							npc_talkedto.text=currObj.npc_talkedto.ToString();
						}
				}

			switch(currObj.GetItemType())
			{
				case ObjectInteraction.LOCK:
				case ObjectInteraction.A_USE_TRIGGER:
					if (int.TryParse(ObjectNext.text, out val))
					{
						currObj.next= (short)(val & 0x3Ff);
						ObjectNext.text=currObj.next.ToString();
					}
					break;
				default:
					break;//do not allow changing the next of an object. The engine normally handles this.
			}

			if (int.TryParse(ObjectTileX.text, out val))
			{
				if  ((val <0 ) || (val > TileMap.TileMapSizeX))
				{
					val=TileMap.ObjectStorageTile;
				}
				currObj.tileX= (short)(val);
				ObjectTileX.text=currObj.tileX.ToString();
			}

			if (int.TryParse(ObjectTileY.text, out val))
			{
				if  ((val <0 ) || (val > TileMap.TileMapSizeY))
				{
					val=TileMap.ObjectStorageTile;
				}
				currObj.tileY= (short)(val);
				ObjectTileY.text=currObj.tileY.ToString();
			}


			if (int.TryParse(ObjectXPos.text, out val))
			{
				currObj.x= (short)(val & 0x7);
				ObjectXPos.text=currObj.x.ToString();
			}
			if (int.TryParse(ObjectYPos.text, out val))
			{
				currObj.y= (short)(val & 0x7);
				ObjectYPos.text=currObj.y.ToString();
			}
			if (int.TryParse(ObjectZPos.text, out val))
			{
				currObj.zpos= (short)(val & 0x7F);
				ObjectZPos.text=currObj.zpos.ToString();
			}

			if (currObj.instance!=null)
			{
				Destroy (currObj.instance.gameObject);
				Vector3 pos = ObjectLoader.CalcObjectXYZ(_RES,
						GameWorldController.instance.currentTileMap(), 
						GameWorldController.instance.currentTileMap().Tiles, 
						GameWorldController.instance.CurrentObjectList().objInfo, 
						(long)currObj.index, (short)currObj.tileX, 
						(short)currObj.tileY,0);
				ObjectInteraction.CreateNewObject(GameWorldController.instance.currentTileMap(),
								currObj  ,GameWorldController.instance.CurrentObjectList().objInfo,GameWorldController.instance.DynamicObjectMarker().gameObject, 
						pos );
			}
			else
			{
				if (currObj.tileX<=TileMap.TileMapSizeX)//A object is brought from off map.
				{
					currObj.InUseFlag=1;
					Vector3 pos = ObjectLoader.CalcObjectXYZ(_RES,
							GameWorldController.instance.currentTileMap(), 
							GameWorldController.instance.currentTileMap().Tiles, 
							GameWorldController.instance.CurrentObjectList().objInfo, 
							(long)currObj.index, (short)currObj.tileX, 
							(short)currObj.tileY,0);
					ObjectInteraction.CreateNewObject(GameWorldController.instance.currentTileMap(),
							currObj,GameWorldController.instance.CurrentObjectList().objInfo,GameWorldController.instance.DynamicObjectMarker().gameObject, 
							pos );
				}
			}
		}

    public void ToggleCamera()
    {
        if ( ! OverheadCam.gameObject.activeInHierarchy )
        {
           if (GameWorldController.instance.ceiling != null)
            {
                GameWorldController.instance.ceiling.SetActive(false);
            }
            OverheadCam.gameObject.SetActive(true);
            UWCharacter.Instance.playerCam.tag = "Untagged";
            UWCharacter.Instance.playerCam.enabled = false;
            OverheadCam.tag = "MainCamera";
        }
        else
        {           
            if (GameWorldController.instance.ceiling != null)
            {
                GameWorldController.instance.ceiling.SetActive(true);
            }
            OverheadCam.gameObject.SetActive(false);
            UWCharacter.Instance.playerCam.tag = "MainCamera";
            UWCharacter.Instance.playerCam.enabled = true;
            OverheadCam.tag = "Untagged";
        }
    }

    void OnGUI()
    {
        if (OverheadCam.gameObject.activeInHierarchy)
        {            
            if (Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                if (Input.GetAxis("Mouse ScrollWheel") <= 0)
                {
                    OverheadCam.orthographicSize += 1;
                }
                else
                {
                    OverheadCam.orthographicSize -= 1;
                }
            }
            if (OverheadCam.orthographicSize <= 0)
            {
                OverheadCam.orthographicSize = 1;
            }
        }
    }


    public override void Update()
    {
        base.Update();
        if (OverheadCam.gameObject.activeInHierarchy)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                OverheadCam.gameObject.transform.Translate(new Vector3(10 * Time.deltaTime, 0, 0));
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                OverheadCam.gameObject.transform.Translate(new Vector3(-10 * Time.deltaTime, 0, 0));
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                OverheadCam.gameObject.transform.Translate(new Vector3(0, -10 * Time.deltaTime, 0));
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                OverheadCam.gameObject.transform.Translate(new Vector3(0, 10 * Time.deltaTime, 0));
            }
        }
    }


    public void GenerateRandomLevel()
    {
        int levelseed = 0;
        if (int.TryParse(seed.text, out levelseed))
        {
            UnderworldGenerator.instance.GenerateLevel(levelseed);
            UnderworldGenerator.instance.RoomsToTileMap(GameWorldController.instance.currentTileMap(), GameWorldController.instance.currentTileMap().Tiles);
            GameWorldController.WorldReRenderPending = true;
            GameWorldController.FullReRender = true;

            float targetX = (float)UnderworldGenerator.instance.startX * 1.2f + 0.6f;
            float targetY = (float)UnderworldGenerator.instance.startY * 1.2f + 0.6f;
            float Height = ((float)(GameWorldController.instance.currentTileMap().GetFloorHeight(UnderworldGenerator.instance.startX, UnderworldGenerator.instance.startY))) * 0.15f;
            UWCharacter.Instance.transform.position = new Vector3(targetX, Height + 0.1f, targetY);
        }
    }
}


