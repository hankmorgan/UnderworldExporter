using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IngameEditor : GuiBase_Draggable {


	public RawImage TileMapView;
	public InputField LevelNoToLoad;

	public  Dropdown TileTypeSelect;
	public Dropdown FloorTextureSelect;
	public Dropdown WallTextureSelect;
	public Dropdown ObjectSelect;

	public Text LevelDetails;
	public Text TileDetails;
	public Text ObjectInfo;

	public InputField TileHeightDetails;

	public RectTransform TileMapDetailsPanel;
	public RectTransform ObjectDetailsPanel;

	public static int TileX=0;
	public static int TileY=0;

		public static IngameEditor instance;

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
		for (int i=48; i<=57;i++ )//Uw1 floor texturemap size
		{
			int index= GameWorldController.instance.currentTileMap().texture_map[i];
			string itemtext=index.ToString() +  " " + StringController.instance.GetTextureName(index);
			Texture2D tex =GameWorldController.instance.texLoader.LoadImageAt(index);
			Sprite sprite = Sprite.Create(tex,new Rect(0,0,tex.width,tex.height),new Vector2(0.5f,0.5f) );//THis does not work!!!
			FloorTextureSelect.options.Add(new Dropdown.OptionData(itemtext,sprite));
		}
		FloorTextureSelect.RefreshShownValue();
	}


		void UpdateWallTexturesDropDown()
		{
			WallTextureSelect.ClearOptions();
			for (int i=0; i<=47;i++ )//Uw1 wall texturemap size
			{
				int index= GameWorldController.instance.currentTileMap().texture_map[i];
				string itemtext=index.ToString() +  " " + StringController.instance.GetTextureName(index);
				Texture2D tex =GameWorldController.instance.texLoader.LoadImageAt(index);
				Sprite sprite = Sprite.Create(tex,new Rect(0,0,tex.width,tex.height),new Vector2(0.5f,0.5f) );//THis does not work!!!
				WallTextureSelect.options.Add(new Dropdown.OptionData(itemtext,sprite));
			}
				WallTextureSelect.RefreshShownValue();
		}


	public void ChangeLevel()
	{
		int levelnotoload=0;
		if (int.TryParse(LevelNoToLoad.text, out levelnotoload))
		{
			GameWorldController.instance.SwitchLevel(levelnotoload);
			RefreshTileMap();
			RefreshTileInfo();
			UpdateFloorTexturesDropDown();
			UpdateWallTexturesDropDown();
			UpdateObjectsDropDown();
		}		
	}

	public void RefreshTileMap()
		{
			TileMapView.texture= GameWorldController.instance.currentTileMap().TileMapImage();
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

	public void UpdateTile()
		{
			//GameObject tileSelected;
			bool ReRenderNeighbours=false;
			//= GameWorldController.FindTile(TileX,TileX,TileMap.SURFACE_FLOOR);
			//Update entered info
			//TileInfo tileToChange= GameWorldController.instance.currentTileMap().Tiles[TileX,TileY];

				DestroyTile(TileX,TileY);
				switch (TileTypeSelect.value)
				{
					case TileMap.TILE_SLOPE_E:
					case TileMap.TILE_SLOPE_W:
					case TileMap.TILE_SLOPE_N:
					case TileMap.TILE_SLOPE_S:
						GameWorldController.instance.currentTileMap().Tiles[TileX,TileY].shockSteep=1;
						break;
				}
		
			GameWorldController.instance.currentTileMap().Tiles[TileX,TileY].tileType= TileTypeSelect.value;
			int FloorHeight=0;
			if (int.TryParse(TileHeightDetails.text,out FloorHeight))
			{
				GameWorldController.instance.currentTileMap().Tiles[TileX,TileY].floorHeight= FloorHeight*2;	
			}
			
			GameWorldController.instance.currentTileMap().Tiles[TileX,TileY].floorTexture=FloorTextureSelect.value;
			int ActualTextureIndex= GameWorldController.instance.currentTileMap().texture_map[FloorTextureSelect.value+48];
			GameWorldController.instance.currentTileMap().Tiles[TileX,TileY].isWater=TileMap.isTextureWater(ActualTextureIndex);
			GameWorldController.instance.currentTileMap().Tiles[TileX,TileY].isLava=TileMap.isTextureLava(ActualTextureIndex);
			//TileMapRenderer.RenderTile(GameWorldController.instance.LevelModel,TileX,TileY,GameWorldController.instance.currentTileMap().Tiles[TileX,TileY],GameWorldController.instance.currentTileMap().Tiles[TileX,TileY].isWater,false,false,true);

				if (GameWorldController.instance.currentTileMap().Tiles[TileX,TileY].wallTexture!= WallTextureSelect.value)
				{
						if (GameWorldController.instance.currentTileMap().Tiles[TileX,TileY].tileType==TileMap.TILE_SOLID)
						{
							GameWorldController.instance.currentTileMap().Tiles[TileX,TileY].North=WallTextureSelect.value;
							GameWorldController.instance.currentTileMap().Tiles[TileX,TileY].South=WallTextureSelect.value;
							GameWorldController.instance.currentTileMap().Tiles[TileX,TileY].East=WallTextureSelect.value;
							GameWorldController.instance.currentTileMap().Tiles[TileX,TileY].West=WallTextureSelect.value;
						}
						GameWorldController.instance.currentTileMap().Tiles[TileX,TileY].wallTexture=WallTextureSelect.value;

						if (TileY>0)
						{//Change its neighbour, only if the neighbour is not a solid
							if (GameWorldController.instance.currentTileMap().Tiles[TileX,TileY-1].tileType>TileMap.TILE_SOLID)
							{
									GameWorldController.instance.currentTileMap().Tiles[TileX,TileY-1].North=WallTextureSelect.value;	
										ReRenderNeighbours=true;
							}
						}

						if (TileY<TileMap.TileMapSizeY)
						{//Change its neighbour, only if the neighbour is not a solid
								if (GameWorldController.instance.currentTileMap().Tiles[TileX,TileY+1].tileType>TileMap.TILE_SOLID)
								{
										GameWorldController.instance.currentTileMap().Tiles[TileX,TileY+1].South=WallTextureSelect.value;	
										ReRenderNeighbours=true;
								}
						}

						if (TileX>0)
						{//Change its neighbour, only if the neighbour is not a solid
								if (GameWorldController.instance.currentTileMap().Tiles[TileX-1,TileY].tileType>TileMap.TILE_SOLID)
								{
										GameWorldController.instance.currentTileMap().Tiles[TileX-1,TileY].East=WallTextureSelect.value;	
										ReRenderNeighbours=true;
								}
						}

						if (TileY<TileMap.TileMapSizeY)
						{//Change its neighbour, only if the neighbour is not a solid
								if (GameWorldController.instance.currentTileMap().Tiles[TileX+1,TileY].tileType>TileMap.TILE_SOLID)
								{
										GameWorldController.instance.currentTileMap().Tiles[TileX+1,TileY].West=WallTextureSelect.value;
										ReRenderNeighbours=true;
								}
						}

				}


			TileMapRenderer.RenderTile(GameWorldController.instance.LevelModel,TileX,TileY,GameWorldController.instance.currentTileMap().Tiles[TileX,TileY],true,false,false,true);
			TileMapRenderer.RenderTile(GameWorldController.instance.LevelModel,TileX,TileY,GameWorldController.instance.currentTileMap().Tiles[TileX,TileY],false,false,false,true);



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
															DestroyTile(x+TileX,y+TileY);
															TileMapRenderer.RenderTile(GameWorldController.instance.LevelModel,TileX+y,TileY+y,GameWorldController.instance.currentTileMap().Tiles[TileX+x,TileY+y],true,false,false,true);
															TileMapRenderer.RenderTile(GameWorldController.instance.LevelModel,TileX+x,TileY+y,GameWorldController.instance.currentTileMap().Tiles[TileX+x,TileY+y],false,false,false,true);
														}	
												}
										}
								}

						}

				}


			RefreshTileMap();

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

		public void SwitchPanel(int Panel)
		{
			TileMapDetailsPanel.gameObject.SetActive(Panel==0);
			ObjectDetailsPanel.gameObject.SetActive(Panel==1);
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


}


