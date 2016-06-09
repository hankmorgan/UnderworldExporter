using UnityEngine;
using System.Collections;

public class ShockStartup : MonoBehaviour {
	public StringController StringControl;

	void Awake()
	{
		StringControl=new StringController();
		StringControl.InitStringController("c:\\shock_strings.txt");
		//Debug.Log (StringControl.GetString (2151,037));
		Words.sc=StringControl;
	}

}
