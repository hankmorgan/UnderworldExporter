using UnityEngine;
using System.Collections;

public class Scrollbutton : MonoBehaviour {

	public int stepSize;
	public static int ScrollValue=0;
	public int MaxScrollValue;
	public int MinScrollValue;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

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
