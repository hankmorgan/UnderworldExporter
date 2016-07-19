using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuButton : GuiBase {
		public Texture2D ButtonOff;
		public Texture2D ButtonOn;
		public RawImage ButtonBG;
		public int Value;
		public MainMenuHud SubmitTarget;

		public void OnHoverEnter()
		{
				ButtonBG.texture=ButtonOn;
		}

		public void OnHoverExit()
		{
				ButtonBG.texture=ButtonOff;
		}

		public virtual void OnClick()
		{
				SubmitTarget.ButtonClickMainMenu(Value);
		}

}
