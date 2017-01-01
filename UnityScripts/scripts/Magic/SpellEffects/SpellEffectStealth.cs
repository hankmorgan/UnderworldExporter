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
				//GameWorldController.instance.playerUW.DetectionRange=6-StealthLevel;
			GameWorldController.instance.playerUW.StealthLevel= Mathf.Max(StealthLevel,GameWorldController.instance.playerUW.StealthLevel);
		}

		public override void CancelEffect ()
		{
			base.CancelEffect ();
			//GameWorldController.instance.playerUW.DetectionRange=6;
			//Cancel the players stealth rating if this is the only stealth effect active.
			GameWorldController.instance.playerUW.StealthLevel=0;	
		}

		void Update()
		{//Keep the effect applied.
				if (Active)
				{
					//GameWorldController.instance.playerUW.DetectionRange=6-StealthLevel;
					GameWorldController.instance.playerUW.StealthLevel= Mathf.Max(StealthLevel,GameWorldController.instance.playerUW.StealthLevel);
				}
		}




}
