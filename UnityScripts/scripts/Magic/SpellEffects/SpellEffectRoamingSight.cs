using UnityEngine;
using System.Collections;

public class SpellEffectRoamingSight : SpellEffect {
		public int OldMana;
		public Vector3 OldPosition;

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

		public override void CancelEffect ()
		{
			playerUW.isRoaming=false;
			playerUW.transform.position=OldPosition;
			playerUW.PlayerMagic.CurMana=OldMana;
			base.CancelEffect();

		}
}
