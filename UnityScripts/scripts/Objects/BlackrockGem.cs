using UnityEngine;
using System.Collections;

public class BlackrockGem : Model3D {



	protected override void Start ()
	{
		GameObject SpriteController = GameObject.CreatePrimitive(PrimitiveType.Cylinder); 
		SpriteController.name = this.name + "_model";
		SpriteController.transform.position = this.transform.position;
		SpriteController.transform.rotation=this.transform.rotation;
		SpriteController.transform.parent = this.transform;
		//SpriteController.transform.localScale=new Vector3(0.5f,0.5f,0.1f);
		SpriteController.transform.localPosition=new Vector3(0.0f,0.25f,0.0f);
	}

}
