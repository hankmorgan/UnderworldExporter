using UnityEngine;
using System.Collections;

public class ShockStartup : MonoBehaviour {
	public StringController StringControl;
	// Use this for initialization
	void Start () {
		StringControl=new StringController();
		StringControl.InitStringController("c:\\shock_strings.txt");
		Debug.Log (StringControl.GetString (2151,037));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
