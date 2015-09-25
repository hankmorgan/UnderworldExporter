using UnityEngine;
using System.Collections;

public class ScrollButtonStatsDisplay : Scrollbutton {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		StatsDisplay.Offset=ScrollValue;
	}
}
