using UnityEngine;
using System.Collections;
/// <summary>
/// Allows the user to explore the level from above it.
/// </summary>
public class SpellEffectRoamingSight : SpellEffect {
		public int OldMana;
		public Vector3 OldPosition;

		/// <summary>
		/// Moves the player above the map. Records their position
		/// </summary>
		public override void ApplyEffect ()
		{
			UWCharacter.Instance.isRoaming=true;
			OldMana=UWCharacter.Instance.PlayerMagic.CurMana;
			UWCharacter.Instance.PlayerMagic.CurMana=0;
			OldPosition = UWCharacter.Instance.transform.position;
			UWCharacter.Instance.transform.position=new Vector3(OldPosition.x,5.5f,OldPosition.z);
			base.ApplyEffect();
		}

		/// <summary>
		/// Moves the player back to where they cancelled the spell from
		/// </summary>
		public override void CancelEffect ()
		{
			UWCharacter.Instance.isRoaming=false;
			UWCharacter.Instance.transform.position=OldPosition;
			UWCharacter.Instance.PlayerMagic.CurMana=OldMana;
			base.CancelEffect();
		}
}
