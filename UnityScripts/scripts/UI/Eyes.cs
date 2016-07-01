using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Eyes : GuiBase {
	//The glowing gargoyle eyes at the top of the screen.
	//Intended to match the health of the last attacked enemy.

	public int EyeIndex;
	private int PreviousEyeIndex=-1;

	private Texture2D[] eyes =new Texture2D[11];

	public override void Start()
	{
		base.Start();
		for (int i = 0 ; i <=10; i++)
		{
			eyes[i] = Resources.Load <Texture2D> ("HUD/Eyes/Eyes_"+ i.ToString("0000"));
		}
		InvokeRepeating("Cycle",0.0f,1.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
		if (EyeIndex!=PreviousEyeIndex)
		{
			this.GetComponent<RawImage>().texture = eyes[EyeIndex];
			//this.GetComponent<UITexture>().mainTexture=Resources.Load <Texture2D> ("HUD/Eyes/Eyes_"+ EyeIndex.ToString("0000"));
		}
	}

	void Cycle()
	{
		EyeIndex++;
		if (EyeIndex >=10)
		{
			EyeIndex=0;
		}
	}
}
