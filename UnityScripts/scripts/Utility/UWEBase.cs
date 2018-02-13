using UnityEngine;
using System.Collections;

/// <summary>
/// Base monobehavior for Underworld Exporter (UWE)
/// </summary>
public class UWEBase : MonoBehaviour {

		public const string GAME_UWDEMO = "UW0";
		public const string GAME_UW1 = "UW1";
		public const string GAME_UW2 = "UW2";
		public const string GAME_SHOCK = "SHOCK";
		public const string GAME_TNOVA = "TNOVA";
		/// <summary>
		/// The folder containing the resources for this game.
		/// </summary>
		public static string _RES= GAME_UW1;

		public static bool EditorMode=false;

		public static char sep;

		/// <summary>
		/// Gets the impact point of this object
		/// </summary>
		/// <returns>The impact point.</returns>
		public virtual Vector3 GetImpactPoint()
		{
			return this.transform.position;	
		}

}
