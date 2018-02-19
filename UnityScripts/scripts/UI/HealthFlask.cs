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

	public override void Update ()
		{
		base.Update();
		if (isHealthDisplay==true)
		{//Health flask
			Level=UWCharacter.Instance.CurVIT;
			MaxLevel=UWCharacter.Instance.MaxVIT;
		}
		else
		{//mana flask
			Level=UWCharacter.Instance.PlayerMagic.CurMana;
			MaxLevel=UWCharacter.Instance.PlayerMagic.MaxMana;
		}

		if ((isHealthDisplay) && ((UWCharacter.Instance.play_poison!= 0) !=Poisoned))
		{
			Poisoned = UWCharacter.Instance.play_poison!=0;
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
			else
			{
				for (int i = 0; i <13; i++)
				{
					LevelImages[i].enabled=false;
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
		if(ConversationVM.InConversation){return;}
		string output=""; 
		if (isHealthDisplay == true)
		{
			switch(UWCharacter.Instance.play_poison)
			{
				case 1:
				case 2:
				case 3:
					output = "You are barely poisoned\n";break;
				case 4:
				case 5:
				case 6:
					output = "You are mildly poisoned\n";break;								
				case 7:
				case 8:
				case 9:
					output = "You are badly poisoned\n";break;
				case 10:
				case 11:
				case 12:
					output = "You are seriously poisoned\n";break;
				case 13:
				case 14:
				case 15:
					output = "You are egregiously poisoned\n";break;							
			}
			if (output!="")
			{
					UWHUD.instance.MessageScroll.Add(output);
					output="";
			}


			//Your current vitality is out of 
			//if (UWCharacter.Instance.Poisoned==true)
			//{
			//	output = "You are [barely/mildly/badly] poisoned\n";
			//}
			output= "Your current vitality is " +UWCharacter.Instance.CurVIT + " out of " + UWCharacter.Instance.MaxVIT;
		}
		else
		{//your current mana points are 
			output= output + "Your current mana points are " +UWCharacter.Instance.PlayerMagic.CurMana + " out of " + UWCharacter.Instance.PlayerMagic.MaxMana;
		}

		UWHUD.instance.MessageScroll.Add(output);
	}
}
