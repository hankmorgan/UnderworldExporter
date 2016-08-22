using UnityEngine;
using System.Collections;

public class Cutscene_EndGame : Cuts {

		public override void Awake()
		{
			base.Awake();
			noOfImages=15;

			ImageFrames[0] = "cs001_n01";//Lava flowing 6.0s
			ImageTimes[0]=0.0f;
			ImageLoops[0]=0;

			ImageFrames[1] = "cs001_n02";//Avatar being rescued 7.8s
			ImageTimes[1]=5.8f;
			ImageLoops[1]=0;

			ImageFrames[2] = "cs001_n03";//Almric speaking 4.2s
			ImageTimes[2]=13.8f;
			ImageLoops[2]=-1;

			ImageFrames[3] = "cs001_n04";//Almric speaking 5.8s
			ImageTimes[3]=18.0f;
			ImageLoops[3]=-1;

			ImageFrames[4] = "cs001_n05";//Almric speaking 10s
			ImageTimes[4]=23.8f;
			ImageLoops[4]=-1;

			ImageFrames[5] = "cs001_n06";//Ariel speaking 4.2s
			ImageTimes[5]=33.8f;
			ImageLoops[5]=-1;

			ImageFrames[6] = "cs001_n07";//Ariel speaking 5.8s
			ImageTimes[6]=38.0f;
			ImageLoops[6]=-1;

			ImageFrames[7] = "cs001_n10";//Boat sailing away 11.2s
			ImageTimes[7]=45.8f;
			ImageLoops[7]=-1;

			ImageFrames[8] = "cs000_n01";//Fade to black ?
			ImageTimes[8]=55.0f;
			ImageLoops[8]=0;

			ImageFrames[9] = "cs000_n06";//Fade in Garamon 4s
			ImageTimes[9]=63.0f;
			ImageLoops[9]=-1;

			ImageFrames[10] = "cs000_n03";//Garamon speaks 2.6s
			ImageTimes[10]=67.0f;
			ImageLoops[10]=-1;

			ImageFrames[11] = "cs000_n04";//Garamon speaks 4.2s
			ImageTimes[11]=69.6f;
			ImageLoops[11]=-1;

			ImageFrames[12] = "cs000_n05";//More Garamon speaks 5.8s
			ImageTimes[12]=74.8f;
			ImageLoops[12]=-1;

			ImageFrames[13] = "VictorySplash";
			ImageTimes[13] = 90.6f;
			ImageLoops[13]=-1;

			ImageFrames[14]="Anim_Base";//To finish.
			ImageTimes[14] = 100.0f;
			ImageLoops[14] = -1;

			StringBlockNo=3073;
			noOfSubs=20;

			SubsStringIndices[0]=0;//You dash down
			SubsTimes[0]=0.2f;
			SubsDuration[0]=2.5f;

			SubsStringIndices[1]=1;//Diving into the ocean
			SubsTimes[1]=ImageTimes[1];
			SubsDuration[1]=2.9f;

			SubsStringIndices[2]=2;//You are helped aboard
			SubsTimes[2]=SubsTimes[1]+2.5f;
			SubsDuration[2]=2.5f;

			SubsStringIndices[3]=3;//Thou has earn
				SubsTimes[3]=ImageTimes[2];
				SubsDuration[3]=2.9f;

			SubsStringIndices[4]=4;//Were it not for thee
				SubsTimes[4]=SubsTimes[3]+4.0f;
				SubsDuration[4]=2.9f;

			SubsStringIndices[5]=5;//I was a fool
				SubsTimes[5]=ImageTimes[4];
				SubsDuration[5]=2.5f;

			SubsStringIndices[6]=6;//greatest hero
				SubsTimes[6]=ImageTimes[5];
				SubsDuration[6]=2.9f;

			SubsStringIndices[7]=7;//when i returned
				SubsTimes[7]=SubsTimes[6]+3.0f;
				SubsDuration[7]=2.9f;

			SubsStringIndices[8]=8;//You have accomplished
				SubsTimes[8]=SubsTimes[7]+3.0f;
				SubsDuration[8]=2.9f;

			SubsStringIndices[9]=9;//swiftly
				SubsTimes[9]=ImageTimes[7];
				SubsDuration[9]=2.9f;

			SubsStringIndices[10]=10;//at last
				SubsTimes[10]=ImageTimes[8];
				SubsDuration[10]=2.9f;

			SubsStringIndices[11]=11;//for the last 3 nights
				SubsTimes[11]=SubsTimes[10]+3.0f;
				SubsDuration[11]=2.9f;

			SubsStringIndices[12]=12;//Just as you are drifting
				SubsTimes[12]=ImageTimes[9];
				SubsDuration[12]=2.9f;

			SubsStringIndices[13]=13;//Hail to thee
				SubsTimes[13]=ImageTimes[10];
				SubsDuration[13]=2.9f;

			SubsStringIndices[14]=14;//I wish to thank
				SubsTimes[14]=SubsTimes[13]+3.0f;
				SubsDuration[14]=2.9f;

			SubsStringIndices[15]=15;//I regret
				SubsTimes[15]=SubsTimes[14]+3.0f;
				SubsDuration[15]=2.9f;

			SubsStringIndices[16]=16;//But I was marshalling
				SubsTimes[16]=SubsTimes[15]+3.0f;
				SubsDuration[16]=2.9f;

			SubsStringIndices[17]=17;//IN destard
				SubsTimes[17]=SubsTimes[16]+3.0f;
				SubsDuration[17]=2.9f;

			SubsStringIndices[18]=18;//Farewell
				SubsTimes[18]=SubsTimes[17]+3.0f;
				SubsDuration[18]=2.9f;

			SubsStringIndices[19]=19;//Visit next time
				SubsTimes[19]=SubsTimes[18]+3.0f;
				SubsDuration[19]=2.9f;
		}


	public override void PreCutsceneEvent ()
	{
		base.PreCutsceneEvent ();
		GameWorldController.instance.playerUW.transform.position=Vector3.zero;
		GameWorldController.instance.mus.EndGame=true;		
	}

	public override void PostCutSceneEvent ()
	{
		base.PostCutSceneEvent ();
			//Debug.Log("Display the victory screen");
				//Switch to the closing stats screen.
	}
}
