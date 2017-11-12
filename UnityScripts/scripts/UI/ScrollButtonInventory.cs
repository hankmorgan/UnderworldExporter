using UnityEngine;
using System.Collections;

public class ScrollButtonInventory : Scrollbutton {


		public short stepSize;
		public static short ScrollValue=0;
		public short MaxScrollValue;
		public short MinScrollValue;


	private int previousScrollValue=-1;
	//public PlayerInventory pInv;

	public void OnClick()
	{
			ScrollValue = (short)(ScrollValue + stepSize);
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
			UWCharacter.Instance.playerInventory.ContainerOffset=ScrollValue;
			UWCharacter.Instance.playerInventory.Refresh ();
		}
	}
}
