using UnityEngine;
using System.Collections;

public class Cutscene_Credits : Cuts {

	public override void Awake()
	{
		base.Awake();
		noOfImages=2;
		ImageTimes[0]=0.0f;
		ImageTimes[1]=42.0f;

		ImageFrames[0]="cs012_n01";
		ImageFrames[1]="Anim_Base";//To finish.

		ImageLoops[0]=-1;
		ImageLoops[1]=-1;
	}
}
