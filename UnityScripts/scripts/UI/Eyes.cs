using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// The glowing gargoyle eyes at the top of the screen.
/// </summary>
public class Eyes : GuiBase {

	const float frameRate = 1f;

	public RawImage output;

	public int TargetSequence;//What sequence should be playing

	public int currentFrame;
	public int targetFrame;

	float currentTime;

	float resetTimer=0f;
	const float resetAtTime=5;

	/// <summary>
	/// The eyes gr for loading the image files
	/// </summary>
	GRLoader EyesGr;

	int[,] ImgSequences = {{0,0,0,0,0}, {1,2,3,2,1}, {4,5,6,5,4}, {7,8,9,8,7}};//blue 0,green 1, orange 2, red 3

	public override void Start()
	{
		base.Start();
		EyesGr = new GRLoader(GRLoader.EYES_GR);
	}
	


	/// <summary>
	/// Sets the target frame when an NPC is hit
	/// </summary>
	/// <param name="currHealth">Curr health.</param>
	/// <param name="maxHealth">Max health.</param>
	public void SetTargetFrame(short currHealth, short maxHealth)
	{
		float ratio = (float)(currHealth)/(float)(maxHealth);
		if (ratio <= 0.15f)
		{
			TargetSequence= 3;
		}
		else if (ratio <=0.6f)
		{
			TargetSequence = 2;
		}
		else
		{
			TargetSequence = 1;
		}
	}



	void Update()
	{
		currentTime+=Time.deltaTime;

		if (currentTime>frameRate)
		{
			currentTime=0f;
			targetFrame++;
			if (targetFrame>=5)
			{
				targetFrame=0;
			}
		}

		resetTimer +=Time.deltaTime;
		if (resetTimer > resetAtTime)
		{
			resetTimer=0f;
			TargetSequence=0;
		}

		if (currentFrame!=targetFrame)
		{			
			output.texture= EyesGr.LoadImageAt(ImgSequences[TargetSequence, targetFrame]);		
			currentFrame=targetFrame;
		}
	}
}