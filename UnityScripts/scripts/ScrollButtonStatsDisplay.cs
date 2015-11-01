using UnityEngine;
using System.Collections;

public class ScrollButtonStatsDisplay : Scrollbutton {

	private int PreviousValue=-1;
	// Update is called once per frame
	void Update () {
		if (PreviousValue!=ScrollValue)
		{
			PreviousValue=ScrollValue;
			StatsDisplay.Offset=ScrollValue;
			StatsDisplay.UpdateNow=true;
		}
	}
}
