using UnityEngine;
using System.Collections;

public class a_jump_trap : trap_base {
		//based on https://answers.unity.com/questions/242648/force-on-character-controller-knockback.html

	Vector3 impact = Vector3.zero;
	const float mass =3f;
	public float force=60f;

	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
			//Try and launch the character in their direction of motion and upwards.
		AddImpact( (2 * UWCharacter.Instance.transform.forward) + (5*Vector3.up), force);
	}



	// call this function to add an impact force:
	void AddImpact( Vector3 dir, float force){
			dir.Normalize();
			if (dir.y < 0) dir.y = -dir.y; // reflect down force on the ground
			impact += dir.normalized * force / mass;
	}

	void Update(){
			// apply the impact force:
		if (impact.magnitude > 0.2) 
			{
				UWCharacter.Instance.playerController.Move(impact * Time.deltaTime);		
			}
			// consumes the impact energy each cycle:
		impact = Vector3.Lerp(impact, Vector3.zero, 5*Time.deltaTime);
	}

	public override void PostActivate ()
	{//do not delete
	
	}
}
