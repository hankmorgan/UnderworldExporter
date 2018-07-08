using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellEffectBounce : SpellEffect {
		public override void ApplyEffect ()
		{
				if (UWCharacter.Instance==null)
				{
						UWCharacter.Instance= this.GetComponent<UWCharacter>();
				}
				UWCharacter.Instance.isBouncy=true;
				base.ApplyEffect ();
		}


		void Update()
		{
				if (Active)
				{//Maintain the effect
						UWCharacter.Instance.isBouncy=true;
				}
		}

		public override void CancelEffect ()
		{
				UWCharacter.Instance.isBouncy=false;
				base.CancelEffect ();
		}

}
