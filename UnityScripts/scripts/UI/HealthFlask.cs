using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthFlask : GuiBase_Draggable {
	/*The health, mana and poisoned state indicators*/
	public RawImage[] LevelImages=new RawImage[13];
	public float Level;
	public float MaxLevel;
	public float FlaskLevel;

	private float PreviousLevel;
	private float PreviousMaxLevel;

	public bool isHealthDisplay;
	private bool Poisoned;


		public override void Start ()
		{
			for (int i=0; i<=LevelImages.GetUpperBound(0);i++)
			{
				if (isHealthDisplay)
				{
					LevelImages[i].texture=GameWorldController.instance.grFlasks.LoadImageAt(i);					
				}
				else
				{
					LevelImages[i].texture=GameWorldController.instance.grFlasks.LoadImageAt(25+i);					
				}
			}
			this.GetComponent<RawImage>().texture=GameWorldController.instance.grFlasks.LoadImageAt(75);			
		}

	void Update () {
		if (isHealthDisplay==true)
		{//Health flask
			Level=GameWorldController.instance.playerUW.CurVIT;
			MaxLevel=GameWorldController.instance.playerUW.MaxVIT;
		}
		else
		{//mana flask
			Level=GameWorldController.instance.playerUW.PlayerMagic.CurMana;
			MaxLevel=GameWorldController.instance.playerUW.PlayerMagic.MaxMana;
		}

		if ((isHealthDisplay) && (GameWorldController.instance.playerUW.Poisoned!=Poisoned))
		{
			Poisoned = GameWorldController.instance.playerUW.Poisoned;
			UpdatePoisonDisplay();
		}

		if ((Level!=PreviousLevel) || (MaxLevel!=PreviousMaxLevel))
		{
			PreviousLevel=Level;
			PreviousMaxLevel=MaxLevel;
			if (MaxLevel>0)
			{
				FlaskLevel = (Level/MaxLevel) * 13.0f; 
				
				for (int i = 0; i <13; i++)
				{
					LevelImages[i].enabled=(i<FlaskLevel);
				}
			}
		}
	}


	void UpdatePoisonDisplay()
	{
		//Debug.Log("Updating poison display");
		for (int i = 0; i <13; i++)
		{
			if (Poisoned==true)
			{//Load the poisoned versions of the flask images.
				//LevelImages[i].texture=Resources.Load <Texture2D> (_RES +"/HUD/Flask/Flasks_"+ (i+50).ToString("0000"));
				LevelImages[i].texture=GameWorldController.instance.grFlasks.LoadImageAt(i+50);
			}
			else
			{//Load the healthy versions of the flask images.
				//LevelImages[i].texture=Resources.Load <Texture2D> (_RES +"/HUD/Flask/Flasks_"+ (i).ToString("0000"));
				LevelImages[i].texture=GameWorldController.instance.grFlasks.LoadImageAt(i);
			}
		}
	}

	public void OnClick()
	{
		if (Dragging==true){return;}				
		string output=""; 
		if (isHealthDisplay == true)
		{
			//Your current vitality is out of 
			if (GameWorldController.instance.playerUW.Poisoned==true)
			{
				output = "You are [barely/mildly/badly] poisoned\n";
			}
			output= output + "Your current vitality is " +GameWorldController.instance.playerUW.CurVIT + " out of " + GameWorldController.instance.playerUW.MaxVIT;
		}
		else
		{//your current mana points are 
			output= output + "Your current mana points are " +GameWorldController.instance.playerUW.PlayerMagic.CurMana + " out of " + GameWorldController.instance.playerUW.PlayerMagic.MaxMana;
		}

		UWHUD.instance.MessageScroll.Add(output);
	}
}
