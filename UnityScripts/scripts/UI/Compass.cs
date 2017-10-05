using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Compass : GuiBase_Draggable {

	//Updates the compass display based on the characters heading.

	private int PreviousHeading=-1;
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

	private RawImage comp;
	public RawImage[] NorthIndicators=new RawImage[16];

	private Texture2D[] CompassPoles=new Texture2D[4];

	public override void Start()
	{
		base.Start();
		comp=this.GetComponent<RawImage>();

		GRLoader grCompass=new GRLoader(GRLoader.COMPASS_GR);
		for (int i=0;i<4;i++)
		{
			//CompassPoles[i]=Resources.Load <Texture2D> (_RES +"/HUD/Compass/Compass_000"+i.ToString());
			CompassPoles[i] = grCompass.LoadImageAt(i);
		}
	}

	public static int getCompassHeadingOffset(GameObject src, GameObject dst)
	{
		//Get the relative heading in words of the dst from the source.
		int Offset=0;
		Vector3 dstPosition = new Vector3(dst.transform.position.x,0,dst.transform.position.z);
		Vector3 srcPosition = new Vector3(src.transform.position.x,0,src.transform.position.z);

		float angle = Mathf.Atan2(dstPosition.z-srcPosition.z, dstPosition.x-srcPosition.x)*180 / Mathf.PI;

		if  ( (angle>-22.5) && (angle<=+22.5))
		{
				//East";	
				Offset=2;
		}
		else 
				if  ( (angle>22.5) && (angle<=+67.5))
				{
						//return "NorthEast";	
						Offset=1;
				}		
				else 
						if  ( (angle>67.5) && (angle<=+112.5))
						{
								//return "North";
								Offset=0;
						}	
						else 
								if  ( (angle>112.5) && (angle<=+157.5))
								{
										//return "NorthWest";		
										Offset=7;
								}		
								else 
										if  ( (angle>157.5) && (angle<=+180.0))
										{
												//return "West";	
												Offset=6;
										}	
										else 
												if  ( (angle>-180.0) && (angle<=-157.5))
												{
														//return "West";	
														Offset=5;
												}		
												else 
														if  ( (angle>-157.5) && (angle<=-112.5))
														{
																//return "southwest";	
																Offset=5;
														}		
														else 
																if  ( (angle>-112.5) && (angle<=-67.5))
																{
																		//return "south";		
																		Offset=4;
																}
																else if  ( (angle>-67.5) && (angle<=-22.5))
																{
																		//return "southeast";		
																		Offset=3;
																}
							/*
				000~001~036~to the North	0
				000~001~037~to the Northeast 	1
				000~001~038~to the East	2
				000~001~039~to the Southeast 3
				000~001~040~to the South 4
				000~001~041~to the Southwest 5
				000~001~042~to the West	6
				000~001~043~to the Northwest 7
				*/
		return Offset;
	}

	public static string getCompassHeading(GameObject src, GameObject dst)
	{//String representation of the above.
		int Offset= Compass.getCompassHeadingOffset(src,dst);

		return StringController.instance.GetString(1, StringController.str_to_the_north + Offset);	//36	
	}


	
	// Update is called once per frame
	void Update () {
		if (PreviousHeading!=GameWorldController.instance.playerUW.currentHeading)
		{
			UpdateNorthIndicator();
			PreviousHeading=GameWorldController.instance.playerUW.currentHeading;
			switch (GameWorldController.instance.playerUW.currentHeading)
			{
				case NORTH:
				case SOUTH:
				case WEST:
				case EAST:
					{
					comp.texture=CompassPoles[0];//Resources.Load <Texture2D> ("HUD/Compass/Compass_0000");
					break;
					}
				case NORTHWEST:
				case NORTHEAST:
				case SOUTHEAST:
				case SOUTHWEST:
					{
						comp.texture=CompassPoles[2];//Resources.Load <Texture2D> ("HUD/Compass/Compass_0002");
						break;
					}
				case NORTHNORTHWEST:
				case EASTNORTHEAST:
				case SOUTHSOUTHEAST:
				case WESTSOUTHWEST:
					{
						comp.texture=CompassPoles[1];//Resources.Load <Texture2D> ("HUD/Compass/Compass_0001");
						break;
					}
				default:
					{
					comp.texture=CompassPoles[3];//Resources.Load <Texture2D> ("HUD/Compass/Compass_0003");
					break;
					}
		
			}
		}
	}

	void UpdateNorthIndicator()
	{
		for (int i =0; i<16;i++)
		{
						NorthIndicators[i].enabled=(i==GameWorldController.instance.playerUW.currentHeading);
		}
	}



	public void OnClick()
	{
		if (Dragging==true){return;}
				if ((WindowDetectUW.WaitingForInput) || (ConversationVM.InConversation)) {return;}
				UWHUD.instance.MessageScroll.Clear ();
				UWHUD.instance.MessageScroll.Add (StringController.instance.GetString (1,StringController.str_you_are_currently_) 
						+ GameWorldController.instance.playerUW.GetFedStatus() 
		                                      + " and " 
						+ GameWorldController.instance.playerUW.GetFatiqueStatus());

				UWHUD.instance.MessageScroll.Add (StringController.instance.GetString (1,StringController.str_you_are_on_the_) 
						+ StringController.instance.GetString (1,411+GameWorldController.instance.LevelNo) 
						+ StringController.instance.GetString (1,StringController.str__level_of_the_abyss_));
		if (GameClock.day()<10)
		{
						UWHUD.instance.MessageScroll.Add (StringController.instance.GetString (1,StringController.str_it_is_the_) 
								+ StringController.instance.GetString (1,411+GameClock.day())
								+ StringController.instance.GetString (1,StringController.str__day_of_your_imprisonment_));
		}
		else
		{//incountable
			UWHUD.instance.MessageScroll.Add (StringController.instance.GetString (1,StringController.str_it_has_been_an_uncountable_number_of_days_since_you_entered_the_abyss_));
		}

		UWHUD.instance.MessageScroll.Add (StringController.instance.GetString (1,StringController.str_you_guess_that_it_is_currently_) 
						+ StringController.instance.GetString (1,StringController.str_night_1+((GameClock.hour())/2)));


		/*
000~001~064~You are currently 
000~001~065~You are on the 
000~001~066~ level of the Abyss.
000~001~067~It is the 
000~001~068~ day of your imprisonment.
000~001~069~It has been an uncountable number of days since you entered the Abyss.
000~001~070~You guess that it is currently 
000~001~071~night
000~001~072~night
000~001~073~dawn
000~001~074~early morning
000~001~075~morning
000~001~076~late morning
000~001~077~mid-day
000~001~078~afternoon
000~001~079~late afternoon
000~001~080~early evening
000~001~081~evening
000~001~082~night



000~001~113~fatigued
000~001~114~very tired
000~001~115~drowsy
000~001~116~awake
000~001~117~rested
000~001~118~wide awake


000~001~411~first
000~001~412~second
000~001~413~third
000~001~414~fourth
000~001~415~fifth
000~001~416~sixth
000~001~417~seventh
000~001~418~eighth
000~001~419~ninth
000~001~420~tenth
		 */
	}
}
