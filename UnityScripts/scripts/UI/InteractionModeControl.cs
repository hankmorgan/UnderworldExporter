using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class InteractionModeControl : GuiBase_Draggable {

	//The mode selection UI elements master control
	public RawImage[] Controls=new RawImage[6];
	public InteractionModeControlItem[] ControlItems = new InteractionModeControlItem[6];

	public static bool UpdateNow=true;

	public OptionsMenuControl OptionsMenu;
	GRLoader grlfti;


	public Texture2D[] UW2Buttons;

	public override void Start ()
	{
		base.Start ();
		grlfti=new GRLoader(GRLoader.LFTI_GR);
		if (_RES==GAME_UW2)
		{
			SetUpUW2OptBtns();	
		}
		SetImage (ref Controls[0], 0);//Init the options button
	}

	public override void Update ()
	{
		base.Update();
		if (UpdateNow==true)
		{
			UpdateNow=false;
			WindowDetect.ContextUIUse =((UWCharacter.InteractionModeTalk==UWCharacter.InteractionMode) ||(UWCharacter.InteractionModePickup==UWCharacter.InteractionMode) || (UWCharacter.InteractionModeUse==UWCharacter.InteractionMode));//Only context in use or pickup
			for (int i = 1; i<=5;i++)
			{
				if (i != UWCharacter.InteractionMode)
				{//Off version
					//Controls[i].texture= lfti.LoadImageAt((i*2));
					SetImage(ref Controls[i], i*2);
				}
				else
				{//On Version
					//Controls[i].texture= lfti.LoadImageAt(((i*2)+1));
					SetImage(ref Controls[i], (i*2)+1);
				}
			}
			if (UWCharacter.InteractionMode== UWCharacter.InteractionModeOptions)
			{
								if (UWCharacter.Instance.MouseLookEnabled)
								{
										WindowDetectUW.SwitchFromMouseLook ();
								}	
				OptionsMenu.gameObject.SetActive(true);
				OptionsMenu.initMenu();
				this.gameObject.SetActive(false);
			}
		}
	}

	public void TurnOffOthers(int LeaveOn)
	{
		for (int i = 0; i<=5;i++)
		{
			if (i!=LeaveOn)
			{
				Controls[i].gameObject.GetComponent<InteractionModeControlItem>().isOn=false;
			}
		}
	}

	void SetImage(ref RawImage img, int index)
	{	
		if (_RES==GAME_UW2)
			{
				img.texture = UW2Buttons[index];
			}
		else
			{
				img.texture = grlfti.LoadImageAt(index);				
			}		
	}

	void SetUpUW2OptBtns()
	{
		GRLoader grOptBtns = new GRLoader(GRLoader.OPTBTNS_GR);
		Texture2D buttonBG = ArtLoader.CreateBlankImage(25,14);
		UWHUD.instance.InteractionControlUW2BG.texture= grOptBtns.LoadImageAt(2);

		UW2Buttons = new Texture2D[12];
				//In off and on pairs
		UW2Buttons[0] = ArtLoader.InsertImage(grOptBtns.LoadImageAt(0), buttonBG ,-52,0);//options
		UW2Buttons[1] = ArtLoader.InsertImage(grOptBtns.LoadImageAt(1), buttonBG ,-52,0);//options

		UW2Buttons[2] = ArtLoader.InsertImage(grOptBtns.LoadImageAt(0), buttonBG ,0,0);//talk
		UW2Buttons[3] = ArtLoader.InsertImage(grOptBtns.LoadImageAt(1), buttonBG ,0,0);//talk

		UW2Buttons[4] = ArtLoader.InsertImage(grOptBtns.LoadImageAt(0), buttonBG ,-52,-15);//pickup
		UW2Buttons[5] = ArtLoader.InsertImage(grOptBtns.LoadImageAt(1), buttonBG ,-52,-15);//pickup

		UW2Buttons[6] = ArtLoader.InsertImage(grOptBtns.LoadImageAt(0), buttonBG ,-26,0);//look
		UW2Buttons[7] = ArtLoader.InsertImage(grOptBtns.LoadImageAt(1), buttonBG ,-26,0);//look

		UW2Buttons[8] =  ArtLoader.InsertImage(grOptBtns.LoadImageAt(0), buttonBG ,0,-15);//attack
		UW2Buttons[9] =  ArtLoader.InsertImage(grOptBtns.LoadImageAt(1), buttonBG ,0,-15);//attack

		UW2Buttons[10] = ArtLoader.InsertImage(grOptBtns.LoadImageAt(0), buttonBG ,-26,-15);//use
		UW2Buttons[11] = ArtLoader.InsertImage(grOptBtns.LoadImageAt(1), buttonBG ,-26,-15);//use
	}
}
