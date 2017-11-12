using UnityEngine;
using System.Collections;
/// <summary>
/// Player stealth and invisibility
/// </summary>
public class SpellEffectStealth : SpellEffect {
		//Unimplemented.
		/// <summary>
		/// The stealth level the spell provides
		/// </summary>
		public int StealthLevel;

		public override void ApplyEffect ()
		{
			base.ApplyEffect();
				//UWCharacter.Instance.DetectionRange=6-StealthLevel;
			UWCharacter.Instance.StealthLevel= Mathf.Max(StealthLevel,UWCharacter.Instance.StealthLevel);
		}

		public override void CancelEffect ()
		{
			base.CancelEffect ();
			//UWCharacter.Instance.DetectionRange=6;
			//Cancel the players stealth rating if this is the only stealth effect active.
			UWCharacter.Instance.StealthLevel=0;	
		}

		void Update()
		{//Keep the effect applied.
				if (Active)
				{
					//UWCharacter.Instance.DetectionRange=6-StealthLevel;
					UWCharacter.Instance.StealthLevel= Mathf.Max(StealthLevel,UWCharacter.Instance.StealthLevel);
				}
		}




}
