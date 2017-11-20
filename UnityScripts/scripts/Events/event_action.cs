using UnityEngine;
using System.Collections;

/// <summary>
/// Class for storing event actions
/// </summary>
public class event_action  {

		public const int RowTypeCondition= 10;
		public const int RowTypeEvent=251;
		public const int RowTypeRaceAdjust=248;//Change the races attitude/other properties towards you.
		public const int RowTypeWhoAmIAdjust=249;//Change the properties of an NPC based on the WHOAMI in offset 6
		public const int RowTypeKillRace=253;//Kill an npc with the specified race???
		public const int RowTypePlaceNPC=254;//??
	public int type;

		//public bool Enabled;

	/// <summary>
	/// The levelNo of the event to be triggered
	/// </summary>
	public int LevelNo=0;  //the level no can also refer to a world eg 247 means any part of the prison tower.
	
	/// <summary>
	/// The tile x to fire scheduled triggers on
	/// </summary>
	public int EventTileX=0;

	/// <summary>
	/// The tile y to fire scheduled triggers on.
	/// </summary>
	public int EventTileY=0;

	/// <summary>
	/// The variable or quest no to test
	/// </summary>
	public int event_variable=0;

	/// <summary>
	/// The the condition a quest variable or a regular variable.
	/// </summary>
	public bool event_isQuest=false;

	/// <summary>
	/// The race that will be affected by this trigger
	/// </summary>
	public int Race;

}