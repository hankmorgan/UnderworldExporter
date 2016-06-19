using UnityEngine;
using System.Collections;

public class ScrollButtonInventory : Scrollbutton {


		public int stepSize;
		public static int ScrollValue=0;
		public int MaxScrollValue;
		public int MinScrollValue;


	private int previousScrollValue=-1;
	public PlayerInventory pInv;

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
		if (ScrollValue!=previousScrollValue)
		{
			previousScrollValue=ScrollValue;
			pInv.ContainerOffset=ScrollValue;
			pInv.Refresh ();
		}
	}
}
