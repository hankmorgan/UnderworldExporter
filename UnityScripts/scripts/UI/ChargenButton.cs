using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChargenButton :  GuiBase{

		public Text ButtonText;
		public RawImage ButtonImage;//The image displayed if this is a character portrait button.
		public Texture2D ButtonOff;
		public Texture2D ButtonOn;
		public RawImage ButtonBG;
		public int Value;
		public MainMenuHud SubmitTarget;
		static GRLoader ButtonLoader;

    public override void Start()
    {
        base.Start();
        if (_RES==GAME_UW2)
        {
            if (ButtonText!=null)
            {
                ButtonText.color = Color.white;
            }            
        }
    }

    public void OnHoverEnter()
		{
			ButtonBG.texture = ButtonOn; // ButtonLoader.LoadImageAt(ButtonOnIndex,false);
		}

		public void OnHoverExit()
		{
			ButtonBG.texture= ButtonOff; // = ButtonLoader.LoadImageAt(ButtonOffIndex,false);
		}

		public virtual void OnClick()
		{
			SubmitTarget.ButtonClickMainMenu(Value);
		}

}
