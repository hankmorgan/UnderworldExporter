using UnityEngine;
using System.Collections;

public class HealthFlask : MonoBehaviour {

	public UITexture[] LevelImages=new UITexture[13];
	public float Level;
	public float MaxLevel;
	public float FlaskLevel;

	public bool HealthDisplay;
	public bool Poisoned;
	public static UWCharacter playerUW;
	// Use this for initialization
	void Start () {
				
	}
	
	// Update is called once per frame
	void Update () {
		if (HealthDisplay==true)
		{
			Level=playerUW.CurVIT;
			MaxLevel=playerUW.MaxVIT;
		}
		else
		{
			Level=playerUW.CurMana;
			MaxLevel=playerUW.MaxMana;
		}

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
