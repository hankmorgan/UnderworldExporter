using UnityEngine;
using System.Collections;

public class ShockStartup : MonoBehaviour {
	public StringController StringControl;

	void Awake()
	{
		StringControl=new StringController();
		StringController.instance.InitStringController("c:\\shock_strings.txt");
		//Debug.Log (StringController.instance.GetString (2151,037));
		Words.sc=StringControl;
	}

}
