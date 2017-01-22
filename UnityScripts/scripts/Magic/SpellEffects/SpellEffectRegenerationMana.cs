using UnityEngine;
using System.Collections;
/// <summary>
/// Mana regeneration
/// </summary>
public class SpellEffectRegenerationMana : SpellEffect {
		///The amount of man per counter tick.
		public int DOT; 

		public override void ApplyEffect ()
		{
				DOT=Value/counter;
				base.ApplyEffect ();
		}

		public override void EffectOverTime ()
		{
			base.EffectOverTime ();
			GameWorldController.instance.playerUW.PlayerMagic.CurMana=GameWorldController.instance.playerUW.PlayerMagic.CurMana+DOT;
			if (GameWorldController.instance.playerUW.PlayerMagic.CurMana>=GameWorldController.instance.playerUW.PlayerMagic.MaxMana)
			{
				GameWorldController.instance.playerUW.PlayerMagic.CurMana=GameWorldController.instance.playerUW.PlayerMagic.MaxMana;
			}
		}
}
