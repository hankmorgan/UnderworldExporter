using UnityEngine;
using System.Collections;

/// <summary>
/// Quest variables.
/// </summary>
/// 	 * per uw-specs.txt
/// 7.8.1 UW1 quest flags
/// 
/// flag   description
/// 
/// 0    Dr. Owl's assistant Murgo freed
/// 1    talked to Hagbard
/// 2    met Dr. Owl?
/// 3    permission to speak to king Ketchaval
/// 4    Goldthirst's quest to kill the gazer (1: gazer killed)
/// 5    Garamon, find talismans and throw into lava
/// 6    friend of Lizardman folk
/// 7    ?? (conv #24, Murgo)
/// 8    book from Bronus for Morlock
/// 9    "find Gurstang" quest
/// 10    where to find Zak, for Delanrey
/// 11    Rodrick killed
/// 
/// 32    status of "Knight of the Crux" quest
/// 0: no knight
/// 1: seek out Dorna Ironfist
/// 2: started quest to search the "writ of Lorne"
/// 3: found writ
/// 4: door to armoury opened
public class Quest : UWEBase {

		public const int TalismanSword=10;
		public const int TalismanShield=55;
		public const int TalismanTaper=147;
		public const int TalismanCup =174;
		public const int TalismanBook=310;
		public const int TalismanWine=191;
		public const int TalismanRing=54;
		public const int TalismanBanner=287;

		/// <summary>
		/// The quest variable integers
		/// </summary>
	public int[] QuestVariables=new int[256];

	/// <summary>
	/// The talismans cast into abyss in order to complete the game.
	/// </summary>
	public bool[] TalismansCastIntoAbyss = new bool[8];

		/// <summary>
		/// Tracks which garamon dream we are at.
		/// </summary>
	public int GaramonDream;//The next dreams to play
		/// <summary>
		/// Tracks which incense dream we are at
		/// </summary>
	public int IncenseDream;


	/// <summary>
	/// Gets the next incense dream
	/// </summary>
	/// <returns>The incense dream.</returns>
	public int getIncenseDream()
	{
		if (IncenseDream>=3)
		{//Loop around
			IncenseDream=0;
		}
		return IncenseDream++;
	}

}
