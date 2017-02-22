using UnityEngine;
using System.Collections;

public class Loader  {
	public const string GAME_UWDEMO = "UW0";
	public const string GAME_UW1 = "UW1";
	public const string GAME_UW2 = "UW2";
	public const string GAME_SHOCK = "SHOCK";

	public static string _RES="UW1";
	public static string BasePath = "c:\\games\\uw1\\";
	public string Path;//To the file relative to the root of the game folder
	public bool DataLoaded;

}
