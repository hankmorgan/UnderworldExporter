using UnityEngine;
using System.Collections;

public class ScrollButtonInventory : Scrollbutton {

	private int previousScrollValue=-1;
	public PlayerInventory pInv;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (ScrollValue!=previousScrollValue)
		{
			previousScrollValue=ScrollValue;
			pInv.ContainerOffset=ScrollValue;
			pInv.Refresh ();
		}
	}
}
