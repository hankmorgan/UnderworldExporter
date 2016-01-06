using UnityEngine;
using System.Collections;

public class Cutscene_Intro : Cuts {

	void Awake()
	{
		//Sample script (of sorts) Plays some clips from the intro.
		//Prints a couple of subtitles and plays an audio clip.
		//Define the array values here.


		noOfImages=8;
		ImageTimes[0]=0.0f;
		ImageTimes[1]=5.0f;
		ImageTimes[2]=10.0f;
		ImageTimes[3]=15.0f;
		ImageTimes[4]=20.0f;
		ImageTimes[5]=25.0f;
		ImageTimes[6]=30.0f;
		ImageTimes[7]=45.0f;

		ImageFrames[0]="cs000_n01";
		ImageFrames[1]="cs000_n02";
		ImageFrames[2]="cs000_n03";
		ImageFrames[3]="cs000_n04";
		ImageFrames[4]="cs000_n05";
		ImageFrames[5]="cs000_n06";
		ImageFrames[6]="cs000_n10";
		ImageFrames[7]="Anim_Base";//To finish.

		ImageLoops[0]=1;
		ImageLoops[1]=-1;
		ImageLoops[2]=-1;
		ImageLoops[3]=-1;
		ImageLoops[4]=-1;
		ImageLoops[5]=-1;
		ImageLoops[6]=1;
		ImageLoops[7]=-1;

		StringBlockNo=3072;
		noOfSubs=2;

		SubsTimes[0]=0.2f;
		SubsTimes[1]=30.0f;

		SubsDuration[0]=10.0f;
		SubsDuration[1]=10.0f;

		SubsStringIndices[0]=0;
		SubsStringIndices[1]=8;

		noOfAudioClips=1;
		AudioTimes[0]=2.0f;
		AudioClipName[0]="sfx/voice/37";
	}




}
