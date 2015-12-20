using UnityEngine;
using System.Collections;

public class Quest : MonoBehaviour {
	/*
	 * per uw-specs.txt
7.8.1 UW1 quest flags

   flag   description

     0    Dr. Owl's assistant Murgo freed
     1    talked to Hagbard
     2    met Dr. Owl?
     3    permission to speak to king Ketchaval
     4    Goldthirst's quest to kill the gazer (1: gazer killed)
     5    Garamon, find talismans and throw into lava
     6    friend of Lizardman folk
     7    ?? (conv #24, Murgo)
     8    book from Bronus for Morlock
     9    "find Gurstang" quest
    10    where to find Zak, for Delanrey
    11    Rodrick killed

    32    status of "Knight of the Crux" quest
           0: no knight
           1: seek out Dorna Ironfist
           2: started quest to search the "writ of Lorne"
           3: found writ
           4: door to armoury opened


	*/
	public int[] QuestVariables=new int[33];

}
