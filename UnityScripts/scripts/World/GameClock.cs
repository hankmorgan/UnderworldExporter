using UnityEngine;
using System.Collections;
/// <summary>
/// Game clock for the world.
/// </summary>
/// Ticks up the game clock one minute every [clockrate] seconds.
public class GameClock : UWEBase {
	
	/// <summary>
	/// How long has passed since the last clock tick
	/// </summary>
	public float clockTime;
	/// <summary>
	/// The clock rate. How long is a minute relative to the clockTime
	/// </summary>
	public float clockRate=60.0f; 

	/// <summary>
	///What game minute we are at.
	/// </summary>
	public static int minute;
	/// <summary>
	/// What game hour we are at
	/// </summary>
	public static int hour;
	/// <summary>
	/// What game day we are at.
	/// </summary>
	public static int day;


	// Update is called once per frame
	void Update () {
		clockTime+=Time.deltaTime;
		if (clockTime>=clockRate)
		{
			ClockTick ();
			clockTime=0.0f;
		}
	}

	/// <summary>
	/// Clock tick. Activates regeneration, hunger and fatigue methods.
	/// </summary>
	static void ClockTick()
	{//Advance the time.
		minute++;
		if (minute%5==0)
		{
			GameWorldController.instance.playerUW.RegenMana();
		}
		if (minute>=60)
		{
			minute=0;
			hour++;
			GameWorldController.instance.playerUW.UpdateHungerAndFatigue();
			//TODO:Update torches, lightsources and food					
			if (hour>=24)
			{
				hour =0;
				day++;
			}
		}
	}

	/// <summary>
	/// Move the clock forward 1 hour.
	/// </summary>
	public static void Advance()
	{
		for (int i=0; i<60; i++)
		{
			ClockTick();
		}
	}

	/// <summary>
	/// Adds the now.
	/// </summary>
	/// <returns>Adds a period of time onto the current time. For setting appointments with NPCs</returns>
	/// <param name="iDay">I day.</param>
	/// <param name="iHour">I hour.</param>
	/// <param name="iMinute">I minute.</param>
	public static int AddNow(int iDay, int iHour, int iMinute)
	{
		return ConvertNow()+ Convert(iDay,iHour,iMinute);
	}

	/// <summary>
	/// Compares the day,hour& minute passed with the current time
	/// </summary>
	/// <returns>The now.</returns>
	/// <param name="iDay">I day.</param>
	/// <param name="iHour">I hour.</param>
	/// <param name="iMinute">I minute.</param>
	public static int DiffNow(int iDay, int iHour, int iMinute)
	{
		return Convert (iDay,iHour,iMinute)- ConvertNow (); 
	}

	/// <summary>
	/// Turns a day, hour and minute into a number.
	/// </summary>
	/// <param name="iDay">I day.</param>
	/// <param name="iHour">I hour.</param>
	/// <param name="iMinute">I minute.</param>
	public static int Convert(int iDay, int iHour, int iMinute)
	{
		return ((iDay*24*60) + (iHour*60)+iMinute); 
	}

	/// <summary>
	/// Turns the current day, hour and minute into a number.
	/// </summary>
	/// <returns>The now.</returns>
	public static int ConvertNow()
	{
		return Convert(day,hour,minute);
	}
}
