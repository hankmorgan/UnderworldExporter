using UnityEngine;
using System.Collections;

public class Cutscene_Incense : Cuts {

		public override void Awake()
		{
			base.Awake();
			noOfImages=2;
			switch (Quest.instance.getIncenseDream ()) 
				{
				case 0:
						ImageFrames[0] = "cs013_n01";
						break;
				case 1:
						ImageFrames[0] = "cs014_n01";
						break;
				case 2:
						ImageFrames[0] = "cs015_n01";
						break;
				}
			ImageTimes[0] = 0f;
			ImageLoops[0] = -1;

			ImageFrames[1]="Anim_Base";//To finish.
			ImageTimes[1] = 10f;
			ImageLoops[1] = -1;
		}
}
