using UnityEngine;
using System.Collections;
/// <summary>
/// Magic projectiles that are launched from spells.
/// </summary>
/// Projectiles use properties defined by SpellProp to decide what damage or other special effects should happen.
public class MagicProjectile : MobileObject {
		public float x;
		public float y;
		public float z;
	/// Has the projectile hit something
	public bool HasHit;
	///who has cast the project. It will ignore them to avoid self harm
	public GameObject caster;
	///Spell properties object to define the behaviour of the projectile
	public SpellProp spellprop; 
	public Rigidbody rgd;

	public bool DetonateNow;
	/// <summary>
	/// The Projectile hits something.
	/// </summary>
	/// <param name="collision">Collision.</param>
	/// Does not impact the caster
	/// Calls onImpact
	/// Calls onHit
	/// Applys Attack
	/// Generates an impact effect
	void OnCollisionEnter(Collision collision)
	{//
			if (caster==null)
			{
				caster=this.gameObject;
			}
		if(collision.gameObject.name== caster.name)
		{//Prevents the caster from hitting themselves
			return;
		}
		if (HasHit==true)
		{//Only impact once.
			return;
		}
		else
		{
			Detonate (collision);		
		}
	}

	public virtual void Update()
	{
		//Update the projectile position based on various factors
		//Missile position is based on a cardinal compass heading n,ne,e,se etc and a clockwise rotation of 0 to 31 units to the next heading.
		npc_xhome = (short)(transform.position.x/1.2f);
		npc_yhome = (short)(transform.position.z/1.2f);

		//if (rgd==null)
		//{//Use the stored values for motion control instead of the applied force.
			Vector3 dir;
			Quaternion deflectionXY = Quaternion.AngleAxis(45f * (float)(ProjectileHeadingMinor)/32f,Vector3.up);
				//Quaternion deflectionZ;
				float z;
				if (Projectile_Sign == 0) 
				{//projectile goes down
						//deflectionZ = Quaternion.AngleAxis(-90f * (float)(Projectile_Pitch)/7f,Vector3.right);
						z = -1 * ( (float)(Projectile_Pitch)/7f) ;
				}
				else
				{//projectile goes up
						//deflectionZ = Quaternion.AngleAxis(+90f * (float)(Projectile_Pitch)/7f,Vector3.right);	
						z = +1 * ((float)(Projectile_Pitch)/7f) ;
				}
			switch (ProjectileHeadingMajor)
			{
			case 1: //ne
					dir = new Vector3(1f,z,1f);break;//ok
			case 2: //e
					dir = new Vector3(1f,z,0f);break;//ok
			case 3: //se
					dir = new Vector3(1f,z,-1f);break;//ok
			case 4: //s
					dir = new Vector3(0f,z,-1f);break;
			case 5: //sw
					dir = new Vector3(-1f,z,-1f);break;
			case 6: //w
					dir = new Vector3(-1f,z,0f);break; //ok
			case 7: //nw						
					dir = new Vector3(-1f,z,1f);break;//ok
			default: //north
			case 0:
					dir = new Vector3(0f,z,1f);break;//ok
			}


			this.transform.Translate (deflectionXY * dir * Time.deltaTime);

		//}	
		if (DetonateNow)
		{
			DestroyProjectile ();	
		}
	}


	
	protected virtual void Detonate (Collision collision)
	{
		HasHit = true;
		//Code to execute when a projectile hits a spot (for launching AOE effects)
		spellprop.onImpact (this.transform);
		ObjectInteraction objInt = collision.gameObject.GetComponent<ObjectInteraction> ();
		if (objInt != null)//Has the projectile hit anything
		 {
			//Special code for magic spell direct hits.
			spellprop.onHit (objInt);
			//Applies damage
			objInt.Attack (spellprop.BaseDamage, caster);
			//Create a impact animation to illustrate the collision
			if (objInt.GetHitFrameStart () >= 0) {
				Impact.SpawnHitImpact (Impact.ImpactMagic (), objInt.GetImpactPoint (), objInt.GetHitFrameStart (), objInt.GetHitFrameEnd ());
			}
		}
		else {
			//Test if this is a player.
			if (collision.gameObject.GetComponent<UWCharacter> () != null) {
				int ratio = UWCharacter.Instance.getSpellResistance (spellprop);
				collision.gameObject.GetComponent<UWCharacter> ().ApplyDamage (spellprop.BaseDamage / ratio);
				spellprop.onHitPlayer ();
			}
			else {
				//Do a miss impact 
				Impact.SpawnHitImpact (Impact.ImpactDamage (), this.transform.position, spellprop.impactFrameStart, spellprop.impactFrameEnd);
			}
		}
		DestroyProjectile ();
	}

	protected virtual void DestroyProjectile ()
	{
		ObjectInteraction objIntThis = this.GetComponent<ObjectInteraction> ();
		if (objIntThis != null) {
			objIntThis.objectloaderinfo.InUseFlag = 0;
			//Free up object slot
		}
		DestroyObject (this.gameObject);
	}
}
