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
			UWCharacter.Instance.PlayerMagic.CurMana=UWCharacter.Instance.PlayerMagic.CurMana+DOT;
			if (UWCharacter.Instance.PlayerMagic.CurMana>=UWCharacter.Instance.PlayerMagic.MaxMana)
			{
				UWCharacter.Instance.PlayerMagic.CurMana=UWCharacter.Instance.PlayerMagic.MaxMana;
			}
		}
}
