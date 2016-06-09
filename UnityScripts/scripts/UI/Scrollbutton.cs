using UnityEngine;
using System.Collections;

public class Scrollbutton : MonoBehaviour {

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
		//Debug.Log("Scrolling" + ScrollValue);
	}
}
