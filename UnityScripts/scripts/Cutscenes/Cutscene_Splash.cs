using UnityEngine;
using System.Collections;

public class Cutscene_Splash : Cuts {

		public override void Awake()
		{
				base.Awake();
				noOfImages=4;
				ImageTimes[0]=0.0f;
				ImageTimes[1]=2.0f;
				ImageTimes[2]=4.0f;
				ImageTimes[3]=7.0f;
				ImageFrames[0]="SplashOrigin";
				ImageFrames[1]="SplashBlueSky";
				ImageFrames[2]="cs011_n01";//UW splash screen.
				ImageFrames[3]="Anim_Base";//To finish.

				ImageLoops[0]=-1;
				ImageLoops[1]=-1;
				ImageLoops[2]=-1;
				ImageLoops[3]=-1;

				noOfSubs=0;
				noOfAudioClips=0;
		}
}
