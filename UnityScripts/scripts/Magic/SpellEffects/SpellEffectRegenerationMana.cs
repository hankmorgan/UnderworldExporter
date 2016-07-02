using UnityEngine;
using System.Collections;
/// <summary>
/// Mana regeneration
/// </summary>
public class SpellEffectRegenerationMana : SpellEffect {
		///The amount of man per counter tick.
		private int DOT; 

		public override void ApplyEffect ()
		{
				DOT=Value/counter;
				base.ApplyEffect ();
		}

		public override void EffectOverTime ()
		{
			base.EffectOverTime ();
			playerUW.PlayerMagic.CurMana=playerUW.PlayerMagic.CurMana+DOT;
			if (playerUW.PlayerMagic.CurMana>=playerUW.PlayerMagic.MaxMana)
			{
				playerUW.PlayerMagic.CurMana=playerUW.PlayerMagic.MaxMana;
			}
		}
}
