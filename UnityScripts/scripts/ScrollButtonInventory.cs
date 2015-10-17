using UnityEngine;
using System.Collections;

public class ScrollButtonInventory : Scrollbutton {

	public PlayerInventory pInv;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		pInv.ContainerOffset=ScrollValue;
		pInv.Refresh ();
	}
}
