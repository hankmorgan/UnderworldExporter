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
				if (playerUW==null)
				{
					playerUW= this.GetComponent<UWCharacter>();
				}
				playerUW.isRoaming=true;
				OldMana=playerUW.PlayerMagic.CurMana;
				playerUW.PlayerMagic.CurMana=0;
				OldPosition = playerUW.transform.position;
				playerUW.transform.position=new Vector3(OldPosition.x,5.5f,OldPosition.z);
				base.ApplyEffect();
		}

		/// <summary>
		/// Moves the player back to where they cancelled the spell from
		/// </summary>
		public override void CancelEffect ()
		{
			playerUW.isRoaming=false;
			playerUW.transform.position=OldPosition;
			playerUW.PlayerMagic.CurMana=OldMana;
			base.CancelEffect();
		}
}
