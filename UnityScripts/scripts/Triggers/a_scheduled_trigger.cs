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

		//Removing SCD.ark breaks the trigger.
		//In fizzits usage a particular value changes from 1 to 2.
		//That scd.ark file changes in block no 15 (zero based 0 to 15)
		//In the conversation with fizzit the x_clock function is called with param 15 and the value returned
		//is incremented by 1.
		//A later value in the same block is hex 0x77 (119). Changing this breaks the trigger but does not stop
		//scd.ark from changing.
		//Setting the byte after that to zero also breaks it. The byte 0x0A precedes this.
		//16 bytes later the values are owner-1 and quality-1. 
		//CHaning either of these breaks the trigger. These are preceded by 0xA. Setting these to known owner/quality 
		//of other triggers does not seem to work.

		//SCD.ark structure

		//Standard block structure. 15 uncompressed blocks.

		//Offset 0  int8  No of lines of instructions/conditionals in the block
		//Offset 1 to 325 Unknown and mostly blank data
		//Rest of data. No Of Lines * 16 bytes data. Possible quest flags, variable conditions and points to triggers (owner & quality?) etc to trigger this object


	public override bool Activate (GameObject src)
	{
		Debug.Log("scheduled trigger " + this.name)	;
		return base.Activate(this.gameObject);
	}

}
