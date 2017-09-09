using UnityEngine;
using System.Collections;

public class a_scheduled_trigger : trigger_base {
		//Theory -untested
		//This trigger is fired when a particular variable is set.
		//Possible usage to turn the gem room into ice when the ice caverns are first visited..

		//Probably reads the same variables as those set by set variables so zpos is the likely index used here.
		//Possibly uses xclock variables

		//Known examples
		//for fizzit
		//X clock 15 = 1 or quest 119 to 1
		//Activates the following trigger
		/*
		Name: a_scheduled_trigger_37_38_00_0844
			Object Type : 428 a_scheduled_trigger
			Location Tile(37,38) Position(3,3,96) Heading (0)
			Flags: 5
				Enchantment: 0
				Doordir : 1
				Invis : 1
				Is Quant : 1
			Quality : 38
			Next : 0
			Owner : 39
			Special Property/Link : 845 : 
		*/



		//IS SCD.ARK RELATED TO THIS THING!!!

		//Variable 44 triggers scheduled trap where quality = 33	//waterdam
		//Variable 51 (or 3) triggers scheduled trap where quality = 38  //value =9 (or 32)
		//Quest 119 triggers scheduled trap where quality = 38 , owner =39 //fizit in jail a_scheduled_trigger_37_38_00_0844


		//Changing the owner and quality breaks the trap


		//Is it used to check a set of conditions???

}
