using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuButton : GuiBase {
	public int ButtonOffIndex;
	public int ButtonOnIndex;
	public RawImage ButtonBG;
	public int Value;
	public MainMenuHud SubmitTarget;
	static GRLoader ButtonLoader;

	public override void Start ()
	{
		switch (_RES)
		{
		case GAME_UWDEMO:
			return;
		default:
			if (ButtonLoader== null)
			{
				ButtonLoader= new GRLoader(GRLoader.OPBTN_GR);
				ButtonLoader.PaletteNo=6;
			}
			ButtonBG.texture= ButtonLoader.LoadImageAt(ButtonOffIndex,false);
			break;
		}	
	}

		public void OnHoverEnter()
		{
			ButtonBG.texture = ButtonLoader.LoadImageAt(ButtonOnIndex,false);
		}

		public void OnHoverExit()
		{
			ButtonBG.texture = ButtonLoader.LoadImageAt(ButtonOffIndex,false);
		}

		public virtual void OnClick()
		{
			SubmitTarget.ButtonClickMainMenu(Value);
		}

}
