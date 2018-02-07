using UnityEngine;
using System.Collections;
//TODO: Remove hours and just use minutes in range 1 to 1440.

/// <summary>
/// Game clock for the world.
/// </summary>
/// Ticks up the game clock one minute every [clockrate] seconds.
public class GameClock : UWEBase {
	
	public int[] gametimevals=new int[3]; //For save games.

	public int game_time;

	/// <summary>
	/// How long has passed since the last clock tick
	/// </summary>
	public float clockTime;
	/// <summary>
	/// The clock rate. How long is a second relative to the clockTime
	/// </summary>
	public float clockRate=1.0f; 


	/// <summary>
	/// What game second we are at.
	/// </summary>
	public int _second;

	/// <summary>
	///What game minute we are at.
	/// </summary>
	public int _minute;
	/// <summary>
	/// What game hour we are at
	/// </summary>
	//public int _hour;
	/// <summary>
	/// What game day we are at.
	/// </summary>
	public int _day;

	public static GameClock instance;

	void Start()
	{
		instance=this;
	}

	// Update is called once per frame
	void Update () {
		if (ConversationVM.InConversation){return;}						
		clockTime+=Time.deltaTime;
		if (clockTime>=clockRate)
		{
			_second++;
			gametimevals[0]++;
			if(gametimevals[0]>=255)
			{
				gametimevals[0]=0;
				gametimevals[1]++;
				if(gametimevals[1]>=255)
				{
					gametimevals[1]=0;
					gametimevals[2]++;
					if(gametimevals[2]>=255)
					{
						gametimevals[2]=0;
					}
				}
			}
			clockTime=0.0f;	
			if (_second>=60)
			{
				ClockTick ();//Move minute forward
					
				_second=0;
			}
		}
	}

		/// <summary>
		/// Clock tick for every minute
		/// </summary>
		static void ClockTick()
		{//Advance the time.
				instance._minute++;
				if (instance._minute%5==0)
				{
						UWCharacter.Instance.RegenMana();
						UWCharacter.Instance.UpdateHungerAndFatigue();
				}
				if (instance._minute>=1440)
				{
						instance._minute=0;
						instance._day++;
						//instance._hour++;
				}
		}

	/// <summary>
	/// Move the clock forward 1 hour.
	/// </summary>
	public static void Advance()
	{
		for (int i=0; i<60; i++)
		{
			ClockTick();//one minute

			int overflow=0;
			instance.gametimevals[0]+=60;
			if(instance.gametimevals[0]>=255)
			{
				overflow= Mathf.Max(0,instance.gametimevals[0]-255);
				instance.gametimevals[0]=overflow;
				instance.gametimevals[1]++;
				if(instance.gametimevals[1]>=255)
				{
					instance.gametimevals[1]=0;
					instance.gametimevals[2]++;
					if(instance.gametimevals[2]>=255)
					{
						instance.gametimevals[2]=0;
					}
				}
			}



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
				Debug.Log("Convert no you should never use!");
				return 0;
		//return ((iDay*24*60) + (iHour*60)+iMinute); 
	}

	/// <summary>
	/// Turns the current day, hour and minute into a number.
	/// </summary>
	/// <returns>The now.</returns>
	public static int ConvertNow()
	{
			Debug.Log("Convert no you should never use!");
		//return Convert(instance._day,instance._hour,instance._minute);
			return 0;
	}

	public static void setUWTime(long timevalue)
	{//Convert UW time value back into days, hours, minutes and seconds.
		//one day in the real world is 86400 seconds
		//int absoluteseconds = second + (minute*60) + (hour*3600) + (day*86400);

		//in uw this value is gameday << 16 | gamehour <<8 | gamesecond


		System.TimeSpan ts=	System.TimeSpan.FromSeconds((double)timevalue);
		instance._day=ts.Days;
		//instance._hour=ts.Hours;
		instance._minute=ts.Minutes + ts.Hours*60;
		instance._second=ts.Seconds;
		//Debug.Log( instance._day + " days " + instance._hour +" hours " + instance._minute + " minutes " + instance._second + " seconds");


	}

	public static long getUWTime()
	{
		System.TimeSpan ts = new System.TimeSpan(instance._day,0, instance._minute,instance._second);
		return (long)ts.TotalSeconds;
	}



	public static int second()
	{
		return instance._second;
	}

	public static int hour()
	{
		//return instance._hour;
		return instance._minute/60;
	}

	public static int day()
	{
		return instance._day;
	}
		/// <summary>
		/// Returns the clock minute..
		/// </summary>
	public static int minute()
	{
		return instance._minute % 24;
	}

		/// <summary>
		/// Returns the total mintues.
		/// </summary>
		/// <returns>The minimum.</returns>
	public static int game_min()
	{
		return instance._minute;
	}

}
