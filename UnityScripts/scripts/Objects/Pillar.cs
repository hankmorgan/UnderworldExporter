using UnityEngine;
using System.Collections;

public class Pillar : map_object {


	protected override void Start ()
	{
		base.Start ();
		BoxCollider bx = this.GetComponent<BoxCollider>();
		if (bx!=null)
		{
			bx.center=new Vector3(0.0f, 0.0f, 0.0f);	
			bx.size=new Vector3(0.1f, 12f, 0.1f);
		}
	}

}
