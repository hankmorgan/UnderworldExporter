using UnityEngine;
using System.Collections;

public class GameClock : GuiBase {
		/*
		 * The gameclock for the world
		 */

	public float clockTime;
	public float clockRate=60.0f; //How long is a minute relative to the clockTime
	public static int minute;
	public static int hour;
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

	public static void Advance()
	{
	//Move the clock forward 1 hour.
		for (int i=0; i<60; i++)
		{
			ClockTick();
		}
	}

	public static int AddNow(int iDay, int iHour, int iMinute)
	{//Adds a time to now
		return ConvertNow()+ Convert(iDay,iHour,iMinute);
	}


	public static int DiffNow(int iDay, int iHour, int iMinute)
	{//Compares the passed day,hour& minute with now.
		return Convert (iDay,iHour,iMinute)- ConvertNow (); 
	}

	public static int Convert(int iDay, int iHour, int iMinute)
	{//Turns a day hour and minute into a number.
		return ((iDay*24*60) + (iHour*60)+iMinute); 
	}

	public static int ConvertNow()
	{
		return Convert(day,hour,minute);
	}
}
