using UnityEngine;
using System.Collections;

public class SpellEffectSlowFall : SpellEffect {
	//private CharacterMotor controllerChar;
	//TODO: Eventually these will have to be come calculated values and these spell effects just act as modifiers to that calcuation?
	//public float OriginalValue=0;//To restore at the end of the effect.
	//private CharacterMotorC cmc;
	public override void ApplyEffect ()
	{
		base.ApplyEffect ();
		playerUW.isFloating=true;
	//	if (cmc==null)
		//{
		//	cmc=this.gameObject.GetComponent<CharacterMotorC>();
		//	controllerChar= this.gameObject.GetComponent<CharacterMotor>();
		//}
		//if (OriginalValue==0)
		//{//Save the value for when the effect is over.
		//	OriginalValue=cmc.movement.maxFallSpeed;
		//}

		//cmc.movement.maxFallSpeed=0.1f;
		//controllerChar.maxFallSpeed=0.1;
	}

	void Update()
	{
		if (Active==true)
		{//Make sure the effect is continually applied.
			//cmc.movement.maxFallSpeed=0.1f;
			playerUW.isFloating=true;
		}
	}

	public override void CancelEffect ()
	{
		//cmc.movement.maxFallSpeed=OriginalValue;
		playerUW.isFloating=false;
		base.CancelEffect ();
	}
}
