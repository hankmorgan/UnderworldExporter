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


	protected override void DestroyProjectile ()
	{
	//override to prevent destruction. instead the projectile is reflected
		reflectprojectile();
	}


	void reflectprojectile()
	{
		HasHit=false;
		switch (ProjectileHeadingMajor)	
		{//Proper behaviour here will need to reflect based on what is being reflected against rather than just reverse course.
		case 1: //ne
				ProjectileHeadingMajor = 5;break;//ok
		case 2: //e
				ProjectileHeadingMajor = 6;break;//ok
		case 3: //se
				ProjectileHeadingMajor = 7;break;//ok
		case 4: //s
				ProjectileHeadingMajor = 0;break;
		case 5: //sw
				ProjectileHeadingMajor = 1;break;
		case 6: //w
				ProjectileHeadingMajor = 2;break; //ok
		case 7: //nw						
				ProjectileHeadingMajor = 3;break;//ok
		default: //north
		case 0:
				ProjectileHeadingMajor = 4;break;//ok
		}
	}
}
