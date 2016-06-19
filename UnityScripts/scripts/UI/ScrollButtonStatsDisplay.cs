using UnityEngine;
using System.Collections;

public class ScrollButtonStatsDisplay : Scrollbutton {

	private int PreviousValue=-1;
	public int stepSize;
	public static int ScrollValue=0;
	public int MaxScrollValue;
	public int MinScrollValue;

	void OnClick()
	{
		ScrollValue = ScrollValue + stepSize;
		if (ScrollValue >MaxScrollValue)
		{
				ScrollValue=MaxScrollValue;
		}

		if (ScrollValue <MinScrollValue)
		{
				ScrollValue=MinScrollValue;
		}
	}


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
