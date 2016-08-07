using UnityEngine;
using System.Collections;

public class Cutscene_EndGame : Cuts {

		public override void Awake()
		{
				base.Awake();
				noOfImages=2;

				ImageFrames[0]="cs001_n01";
				ImageFrames[1]="cs002_n02";

				ImageTimes[0]=0.0f;
				ImageTimes[1]=5.0f;

		}


	public override void PreCutsceneEvent ()
	{
		base.PreCutsceneEvent ();
		GameWorldController.instance.playerUW.transform.position=Vector3.zero;
	}

	public override void PostCutSceneEvent ()
	{
		base.PostCutSceneEvent ();
				Debug.Log("Display the victory screen");
	}
}
