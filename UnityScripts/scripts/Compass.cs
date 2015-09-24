using UnityEngine;
using System.Collections;

public class Compass : MonoBehaviour {

	private int PreviousHeading=-1;

	public static UWCharacter playerUW;

	public const int NORTH = 0;
	public const int NORTHNORTHEAST = 1;
	public const int NORTHEAST = 2;
	public const int EASTNORTHEAST = 3;
	public const int EAST = 4 ;
	public const int EASTSOUTHEAST = 5 ;
	public const int SOUTHEAST = 6 ;
	public const int SOUTHSOUTHEAST = 7 ;
	public const int SOUTH = 8;
	public const int SOUTHSOUTHWEST = 9 ;
	public const int SOUTHWEST = 10 ;
	public const int WESTSOUTHWEST = 11 ;
	public const int WEST = 12;
	public const int WESTNORTHWEST = 13 ;
	public const int NORTHWEST = 14 ;
	public const int NORTHNORTHWEST = 15 ;

	private UITexture comp;
	public UITexture[] NorthIndicators=new UITexture[16];

	// Use this for initialization
	void Start () {
		comp=this.GetComponent<UITexture>();
	}


	
	// Update is called once per frame
	void Update () {
	
		if (PreviousHeading!=playerUW.currentHeading)
		{
			UpdateNorthIndicator();
			PreviousHeading=playerUW.currentHeading;
			switch (playerUW.currentHeading)
			{
				case NORTH:
				case SOUTH:
				case WEST:
				case EAST:
					{
					comp.mainTexture=Resources.Load <Texture2D> ("HUD/Compass/Compass_0000");
					break;
					}
				case NORTHWEST:
				case NORTHEAST:
				case SOUTHEAST:
				case SOUTHWEST:
					{
						comp.mainTexture=Resources.Load <Texture2D> ("HUD/Compass/Compass_0002");
						break;
					}
				case NORTHNORTHWEST:
				case EASTNORTHEAST:
				case SOUTHSOUTHEAST:
				case WESTSOUTHWEST:
					{
						comp.mainTexture=Resources.Load <Texture2D> ("HUD/Compass/Compass_0001");
						break;
					}
				default:
					{
					comp.mainTexture=Resources.Load <Texture2D> ("HUD/Compass/Compass_0003");
					break;
					}
		
			}
		}
	}

	void UpdateNorthIndicator()
	{
		for (int i =0; i<16;i++)
		{
			NorthIndicators[i].enabled=(i==playerUW.currentHeading);
		}
	}
}
