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
				LevelImages[i].texture=Resources.Load <Texture2D> ("UW1/HUD/Flask/Flasks_"+ (i+50).ToString("0000"));
			}
			else
			{//Load the healthy versions of the flask images.
				LevelImages[i].texture=Resources.Load <Texture2D> ("UW1/HUD/Flask/Flasks_"+ (i).ToString("0000"));
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

		GameWorldController.instance.playerUW.playerHud.MessageScroll.Add(output);
	}
}
