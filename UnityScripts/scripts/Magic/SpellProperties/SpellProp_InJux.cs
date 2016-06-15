using UnityEngine;
using System.Collections;

public class SpellProp_InJux : SpellProp {
	//Rune of Warding
	public override void init ()
	{
		base.init ();
		//ProjectileSprite = "Sprites/objects_020";
		//Force=200.0f;
		BaseDamage=0;
		//impactFrameStart=21;
		//impactFrameEnd=25;
	}

	public override void onImpact (Transform tf)
	{
		base.onImpact (tf);
		Vector3 TrapPosition = new Vector3(tf.position.x,0,tf.position.z);
		Vector3 PlayerPosition = new Vector3(playerUW.transform.position.x,0,playerUW.transform.position.z);
		Vector3 relativeAngle = TrapPosition-PlayerPosition;
		Debug.Log(Vector3.Angle (TrapPosition, PlayerPosition));
		//Announce to the player the ward has gone off.
		//000~001~245~Your Rune of Warding has been set off 
		playerUW.playerHud.MessageScroll.Add(playerUW.StringControl.GetString(1,245) + getCompassHeading());
	}
	/*
	public override void onImpactPlayer ()
	{
		base.onImpactPlayer ();
		playerUW.playerHud.MessageScroll.Add("TEST");
	}
	*/
	private string getCompassHeading()
		{//Get the relative heading of the detonated ward trap to the player.
				int Offset=0;
				Vector3 TrapPosition = new Vector3(this.transform.position.x,0,this.transform.position.z);
				Vector3 PlayerPosition = new Vector3(playerUW.transform.position.x,0,playerUW.transform.position.z);

				float angle = Mathf.Atan2(TrapPosition.z-PlayerPosition.z, TrapPosition.x-PlayerPosition.x)*180 / Mathf.PI;

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
				return playerUW.StringControl.GetString(1, 36 + Offset);

		}
}
