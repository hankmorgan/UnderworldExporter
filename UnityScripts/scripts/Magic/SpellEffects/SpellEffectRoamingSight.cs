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
			GameWorldController.instance.playerUW.isRoaming=true;
			OldMana=GameWorldController.instance.playerUW.PlayerMagic.CurMana;
			GameWorldController.instance.playerUW.PlayerMagic.CurMana=0;
			OldPosition = GameWorldController.instance.playerUW.transform.position;
			GameWorldController.instance.playerUW.transform.position=new Vector3(OldPosition.x,5.5f,OldPosition.z);
			base.ApplyEffect();
		}

		/// <summary>
		/// Moves the player back to where they cancelled the spell from
		/// </summary>
		public override void CancelEffect ()
		{
			GameWorldController.instance.playerUW.isRoaming=false;
			GameWorldController.instance.playerUW.transform.position=OldPosition;
			GameWorldController.instance.playerUW.PlayerMagic.CurMana=OldMana;
			base.CancelEffect();
		}
}
