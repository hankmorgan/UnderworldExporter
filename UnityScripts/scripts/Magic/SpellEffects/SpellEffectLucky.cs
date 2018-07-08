using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellEffectLucky : SpellEffect {
		public override void ApplyEffect ()
		{
				if (UWCharacter.Instance==null)
				{
						UWCharacter.Instance= this.GetComponent<UWCharacter>();
				}
				UWCharacter.Instance.isLucky=true;
				base.ApplyEffect ();
		}


		void Update()
		{
				if (Active)
				{//Maintain the effect
					UWCharacter.Instance.isLucky=true;
				}
		}

		public override void CancelEffect ()
		{
				UWCharacter.Instance.isLucky=false;
				base.CancelEffect ();
		}

}
