using UnityEngine;
using System.Collections;

public class UWClass  {
		
	public const string GAME_UWDEMO = "UW0";
	public const string GAME_UW1 = "UW1";
	public const string GAME_UW2 = "UW2";
	public const string GAME_SHOCK = "SHOCK";
	public const string GAME_TNOVA = "TNOVA";

	public static string _RES="UW1";

    /// <summary>
    /// Gets the current object list in use
    /// </summary>
    /// <returns></returns>
    public static ObjectLoader CurrentObjectList()
    {
        return UWEBase.CurrentObjectList();
    }

    /// <summary>
    /// Returns the current tile map
    /// </summary>
    /// <returns>The tile map.</returns>
    public static TileMap CurrentTileMap()
    {
        return UWEBase.CurrentTileMap();
    }

    public static AutoMap CurrentAutoMap()
    {
        return UWEBase.CurrentAutoMap();
    }


}
