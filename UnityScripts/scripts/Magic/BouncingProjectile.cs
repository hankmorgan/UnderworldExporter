using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingProjectile : MagicProjectile {

	protected override void Start ()
	{
		SpellProp_Fireball spf=		new SpellProp_Fireball();
		spf.init(SpellEffect.UW2_Spell_Effect_Fireball, this.gameObject);
		spellprop = spf;
		this.gameObject.layer = LayerMask.NameToLayer("MagicProjectile");
		BoxCollider box = this.gameObject.GetComponent<BoxCollider>();
		box.size = new Vector3(0.2f,0.2f,0.2f);
		box.center= new Vector3(0.0f,0.1f,0.0f);

		rgd = this.gameObject.GetComponent<Rigidbody>();
		rgd.freezeRotation =true;
		rgd.collisionDetectionMode=CollisionDetectionMode.Continuous;
	}

	public override void Update ()
	{
				Vector3 dir;
				switch (MissileHeading)
				{
				case 1: //ne
						dir = new Vector3(1f,0f,1f);break;//ok
				case 2: //e
						dir = new Vector3(1f,0f,0f);break;//ok
				case 3: //se
						dir = new Vector3(1f,0f,-1f);break;//ok
				case 4: //s
						dir = new Vector3(0f,0f,-1f);break;
				case 5: //sw
						dir = new Vector3(-1f,0f,-1f);break;
				case 6: //w
						dir = new Vector3(-1f,0f,0f);break; //ok
				case 7: //nw						
						dir = new Vector3(-1f,0f,1f);break;//ok
				default: //north
				case 0:
						dir = new Vector3(0f,0f,1f);break;//ok
				}
				this.transform.Translate (dir * Time.deltaTime);

		}


	protected override void DestroyProjectile ()
	{
	//override to prevent destruction. instead the projectile is reflected
		reflectprojectile();
	}


	void reflectprojectile()
	{
		HasHit=false;
		switch (MissileHeading)	
		{//Proper behaviour here will need to reflect based on what is being reflected against rather than just reverse course.
		case 1: //ne
				MissileHeading = 5;break;//ok
		case 2: //e
				MissileHeading = 6;break;//ok
		case 3: //se
				MissileHeading = 7;break;//ok
		case 4: //s
				MissileHeading = 0;break;
		case 5: //sw
				MissileHeading = 1;break;
		case 6: //w
				MissileHeading = 2;break; //ok
		case 7: //nw						
				MissileHeading = 3;break;//ok
		default: //north
		case 0:
				MissileHeading = 4;break;//ok
		}
	}
}
