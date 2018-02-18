using UnityEngine;
using System.Collections;
/// <summary>
/// Cutscene dream 7. Tybal is dead. (Swapped with dream 8)
/// </summary>
public class Cutscene_Dream_7 : Cuts {

		public override void Awake()
		{
				base.Awake();
				noOfImages=4;
				ImageFrames[0] = "cs000_n06";//Fade in Garamon
				ImageTimes[0] = 0f;
				ImageLoops[0] = -1;

				ImageFrames[1] = "cs000_n03";//Garamon speaks
				ImageTimes[1] = 6.0f;
				ImageLoops[1] = -1;

				ImageFrames[2] = "cs000_n03";//Garamon speaks
				ImageTimes[2] = 13.0f;
				ImageLoops[2] = -1;

				ImageFrames[3]="Anim_Base";//To finish.
				ImageTimes[3] = 48f;
				ImageLoops[3] = -1;



				StringBlockNo=3098;//was 3104
				noOfSubs=9;
				for (int i=0;i<noOfSubs;i++)
				{
						SubsStringIndices[i]=i;
						SubsTimes[i]= 5.0f+ i*5.0f;
						SubsDuration[i]=4.5f;	
				}
		}
}
