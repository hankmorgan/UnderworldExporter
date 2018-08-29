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

	enum ProjectileHeadings
	{
		NORTH = 0,
		NORTHEAST = 1,
		EAST = 2,
		SOUTHEAST =3,
		SOUTH =4,
		SOUTHWEST =5,
		WEST =6,
		NORTHWEST =7
	};

		public NPC target;

		/*

		    N  NE  E  SE  S  SW  W  NW
--------------------------------------
		N   0  1   1   1  1  -1 -1 -1
		NE -1  0   1   1  1   1 -1 -1
		E  -1  -1  0   1  1   1  1  -1
		SE  -1  -1 -1  0  1   1  1  1
		S   1  -1  -1  -1  0  1  1  1
		SW  1   1  -1  -1 -1  0  1  1
		W   1   1   1  -1 -1  -1  0  1
		NW  1   1   1   1  -1  -1 -1 0



		*/
		short[,] turningHeading = new short[,] {
				{0,  1 ,  1 ,  1,  1 , -1 ,-1, -1},
				{-1,  0,   1 ,  1,  1 ,  1 ,-1, -1},
				{-1,  -1 , 0,   1,  1 ,  1,  1 , -1},
				{-1,  -1, -1 , 0 , 1 ,  1 , 1 , 1},
				{1 , -1 , -1 , -1,  0 , 1,  1 , 1},
				{1 ,  1 , -1 , -1, -1,  0 , 1 , 1},
				{1 ,  1 ,  1 , -1, -1,  -1, 0 , 1},
				{1 ,  1,   1 ,  1,  -1,  -1 ,-1, 0},
		};




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
        if (collision.gameObject.GetComponent<AnimationOverlay>())
        {//This projectile has hit an animation.
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



	public override void Update()
	{
		//Update the projectile position based on various factors
		//Missile position is based on a cardinal compass heading n,ne,e,se etc and a clockwise rotation of 0 to 31 units to the next heading.
		npc_xhome = (short)(transform.position.x/1.2f);
		npc_yhome = (short)(transform.position.z/1.2f);

		//if (rgd==null)
		//{//Use the stored values for motion control instead of the applied force.
			this.transform.Translate (ProjectilePropsToVector(this) * Time.deltaTime);
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
        Object.Destroy(this.gameObject);
		//DestroyObject (this.gameObject);
	}


	/// <summary>
	/// Tells the projectile to start homing in on a target.
	/// </summary>
	public void BeginHoming()
	{
		StartCoroutine (Homing());
	}



	IEnumerator Homing()
	{
		while (true)
		{
			yield return new WaitForSeconds(0.1f);
			//Find target
			//RaycastHit hit = new RaycastHit();
			if (target==null)
			{
					NPC npc = Magic.GetNPCTargetRandom(this.gameObject, 5f);
					if (npc!=null)
					{
							target=npc;//Save target to global so it will continue to track after leaving range.
					}										
			}

			if (target!=null)
			{
					//UWHUD.instance.MessageScroll.Add("Tracking " + npc.name);	
					//steer towards target
					Vector3 dstPosition = new Vector3(target.transform.position.x,0,target.transform.position.z);
					Vector3 srcPosition = new Vector3(this.transform.position.x,0,this.transform.position.z);
					float angle = Mathf.Atan2(dstPosition.z-srcPosition.z, dstPosition.x-srcPosition.x)*180 / Mathf.PI;
					//Debug.Log("Angle is " + angle);
						//mgp.Projectile_Pitch = (short)((projectilePitchAngle /90f) * 7f);
						int targetHeading=0;
						angle +=180;

						if ((angle >=337.5) || (angle<22.5))
						{
							targetHeading = (int)ProjectileHeadings.WEST;								
						}
						else if ((angle >=22.5) && (angle<67.5))
						{
							targetHeading = (int)ProjectileHeadings.SOUTHWEST;								
						}
						else if ((angle >=67.5) && (angle<112.5))
						{
							targetHeading = (int)ProjectileHeadings.SOUTH;								
						}
						else if ((angle >=112.5) && (angle<157.5))
						{
							targetHeading = (int)ProjectileHeadings.SOUTHEAST;								
						}
						else if ((angle >=157.5) && (angle<202.5))
						{
							targetHeading = (int)ProjectileHeadings.EAST;								
						}
						else if ((angle >=202.5) && (angle<247.5))
						{
							targetHeading = (int)ProjectileHeadings.NORTHEAST;								
						}
						else if ((angle >=247.5) && (angle<292.5))
						{
							targetHeading = (int)ProjectileHeadings.NORTH;								
						}
						else if ((angle >=292.5) && (angle<337.5))
						{
							targetHeading = (int)ProjectileHeadings.NORTHWEST;								
						}
						else 
						{//Should not happen. just hold course.
								targetHeading = ProjectileHeadingMajor;
						}
						//Lookup turning angle.
						//change projectile heading by turning angle.
						 

						ProjectileHeadingMajor += (short)turningHeading[ProjectileHeadingMajor,targetHeading ];
						if (ProjectileHeadingMajor <0)						
						{
								ProjectileHeadingMajor = 7;
						}
						if (ProjectileHeadingMajor >7)
						{
								ProjectileHeadingMajor =0;
						}

						if (this.transform.position.y > target.transform.position.y)
						{//needs to go down
							Projectile_Pitch=1;
							Projectile_Sign =0;
						}
						else
						{//needs to go up
							Projectile_Pitch=1;
							Projectile_Sign =1;
						}


			}
			

			
		}
	}

		/// <summary>
		/// Tells the projectile to start homing in on a target.
		/// </summary>
		public void BeginVapourTrail()
		{
			StartCoroutine (VapourTrail());
		}

		/// <summary>
		/// Creates a vapour trail to follow the projectil.
		/// </summary>
		/// <returns>The trail.</returns>
		IEnumerator VapourTrail()
		{
			while (true)
			{
				yield return new WaitForSeconds(0.5f);
				Impact.SpawnHitImpact(462,this.transform.position,56,62);
			}
		}

}
