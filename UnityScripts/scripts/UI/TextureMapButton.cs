using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextureMapButton : GuiBase {
	
	public const short TextureTypeFloor=0;
	public const short TextureTypeWall=1;
	public const short TextureTypeDoor=2;

	public int MapIndex;//The location within the texture map.
	public int TextureIndex;//The index of the texture in question.
	public RawImage img; //The image data of the texture;

	public static Color ColorOn = new Color(1f,1f,1f);
	public static Color ColorOff = new Color(0.5f,0.5f,0.5f);

	public short textureType=0; //0=floor, 1=wall, 2=door

	static short currentTextureType=0;
	static int SelectedTextureMapIndex;
	static TextureMapButton selectedButton;


	public void OnClick()
	{

		SelectedTextureMapIndex=MapIndex;
		IngameEditor.instance.SelectedTextureMap.texture=img.texture;
		selectedButton=this;
		currentTextureType=textureType;
		switch(textureType)
		{
		case TextureTypeFloor:
			IngameEditor.instance.WallTextureMapSelect.gameObject.SetActive(false);
			IngameEditor.instance.DoorTextureMapSelect.gameObject.SetActive(false);
			IngameEditor.instance.FloorTextureMapSelect.gameObject.SetActive(true);
			if (_RES == GAME_UW2)
			{
				IngameEditor.instance.FloorTextureMapSelect.value=TextureIndex;			
			}
			else
			{
				IngameEditor.instance.FloorTextureMapSelect.value=TextureIndex-210;								
			}
			
			break;

		case TextureTypeWall:						
			IngameEditor.instance.WallTextureMapSelect.gameObject.SetActive(true);
			IngameEditor.instance.DoorTextureMapSelect.gameObject.SetActive(false);
			IngameEditor.instance.FloorTextureMapSelect.gameObject.SetActive(false);
			IngameEditor.instance.WallTextureMapSelect.value=TextureIndex;		
			break;

		case TextureTypeDoor:
			IngameEditor.instance.WallTextureMapSelect.gameObject.SetActive(false);
			IngameEditor.instance.DoorTextureMapSelect.gameObject.SetActive(true);
			IngameEditor.instance.FloorTextureMapSelect.gameObject.SetActive(false);
			IngameEditor.instance.DoorTextureMapSelect.value=TextureIndex;			
			break;
		}
	}

	public void OnHoverEnter()
	{
		img.color=ColorOn;
	}

	public void OnHoverExit()
	{
		img.color=ColorOff;	
	}


	public void AcceptChange()
	{
		int newTextureValue=0;
		Texture2D tex= GameWorldController.instance.texLoader.LoadImageAt(0);
		switch (currentTextureType)
		{
		case TextureTypeFloor:
			newTextureValue=IngameEditor.instance.FloorTextureMapSelect.value+210;
			tex = GameWorldController.instance.texLoader.LoadImageAt(newTextureValue);
			break;

		case TextureTypeWall:						
			newTextureValue=IngameEditor.instance.WallTextureMapSelect.value;
			tex = GameWorldController.instance.texLoader.LoadImageAt(newTextureValue);
			break;

		case TextureTypeDoor:
			newTextureValue=IngameEditor.instance.DoorTextureMapSelect.value;
			tex = (Texture2D)GameWorldController.instance.MaterialDoors[newTextureValue].mainTexture;
			break;
		}
		GameWorldController.instance.currentTileMap().texture_map[SelectedTextureMapIndex]=(short)newTextureValue;
		selectedButton.img.texture=tex;
		selectedButton.TextureIndex=newTextureValue;
		GameWorldController.WorldReRenderPending=true;
		GameWorldController.ObjectReRenderPending=true;
		GameWorldController.FullReRender=true;
	}

}