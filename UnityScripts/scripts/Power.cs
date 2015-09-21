using UnityEngine;
using System.Collections;

public class Power : MonoBehaviour {

	public string CurrentPower;
	private float PreviousCharge=-1.0f;
	private int RepeatCounter=0;
	private int PreviousIndex=-1;
	//float PowerLevel;
	private UWCharacter playerUW;
	private UITexture uiText;
	// Use this for initialization
	void Start () {
		//InvokeRepeating("UpdateUW",0.0f,0.2f);
	}
	

	void Update () {
	if (playerUW==null)
		{
			playerUW= GameObject.Find ("Gronk").GetComponent<UWCharacter>();
		}

		if (uiText==null)
		{
			uiText= this.gameObject.GetComponent<UITexture>();
		}

	if ((PreviousCharge!=playerUW.Charge)||(playerUW.AttackCharging==true))
		{
			PreviousCharge=playerUW.Charge;
			 
			int index= (int)playerUW.Charge/10;
	
			if (index==10)
			{
				if (!IsInvoking("UpdateMaxCharge"))
				{
					InvokeRepeating("UpdateMaxCharge",0.0f,0.1f);
				}
			}
			else
			{
				if (index!=PreviousIndex)
				{
					RepeatCounter=0;
					uiText.mainTexture=Resources.Load <Texture2D> ("HUD/Power/Power_"+ index.ToString("0000"));
					CurrentPower="HUD/Power/Power_"+ index.ToString("0000");
				}
			}
		}
	else
		{
			if (IsInvoking("UpdateMaxCharge"))
			{
				CancelInvoke("UpdateMaxCharge");
				uiText.mainTexture=Resources.Load <Texture2D> ("HUD/Power/Power_"+ 0.ToString("0000"));
			}
			RepeatCounter=0;
		}
	}

	void UpdateMaxCharge()
	{
		uiText.mainTexture=Resources.Load <Texture2D> ("HUD/Power/Power_"+ (10+RepeatCounter).ToString("0000"));
		CurrentPower="HUD/Power/Power_"+ (10+RepeatCounter).ToString("0000");
		RepeatCounter++;
		if (RepeatCounter>3)
		{
			RepeatCounter=0;
		}
	}
}
