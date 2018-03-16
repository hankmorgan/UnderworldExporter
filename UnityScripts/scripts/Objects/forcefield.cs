using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class forcefield : object_base {

	protected override void Start ()
	{
		base.Start ();
	
		BoxCollider bx = this.gameObject.AddComponent<BoxCollider>();
		bx.size=new Vector3(1.2f,5f,0.6f);
		bx.center= new Vector3(0f,2.5f,0f);
		this.gameObject.layer= LayerMask.NameToLayer("MapMesh");
		//this.gameObject.AddComponent<NavMeshObstacle>();
		

	}
}
