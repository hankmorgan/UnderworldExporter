using UnityEngine;
using System.Collections;

public class Conversation_218 : Conversation {

	//conversation #218
	//string block 0x0eda, name Griffle

	public override IEnumerator main() {
		SetupConversation (3802);
		privateVariables[1] = 0;
		yield return StartCoroutine(func_029d());
		func_0012();
		yield return 0;
	} // end func
	
	void func_0012() {
		EndConversation ();
		privateVariables[0] = 1;
	} // end func
	/*
	void func_0020() {
		
		int[] locals = new int[2];
		
		if ( (((npc.npc_goal == 5 || npc.npc_goal == 6) || npc.npc_goal == 9) && npc.npc_gtarg == 1 || npc.npc_attitude == 0) ) {
			
			locals[1] = 0;
		} else {
			
			locals[1] = 1;
		} // end if
		
		return locals[1];
	} // end func
	
	void func_0063() {
		
		npc.npc_gtarg = 1;
		npc.npc_attitude = 1;
		npc.npc_goal = 6;
		func_0012();
	} // end func
	
	void func_007c() {
		
		npc.npc_goal = 1;
		func_0012();
	} // end func
	
	void func_008b() {
		
		npc.npc_gtarg = 1;
		npc.npc_goal = 5;
		npc.npc_attitude = 1;
		func_0012();
	} // end func
	
	void func_00a4() {
		
		npc.npc_attitude = 6;
	} // end func
	
	void func_00b1() {
		
		npc.npc_attitude = param1[0]play_hunger;
		func_0012();
	} // end func
	
	void func_00c2() {
		
		npc.npc_attitude = 2;
		func_0012();
	} // end func
	
	void func_00d1() {
		
		npc.npc_attitude = 1;
		func_0012();
	} // end func
	*/
	void func_00e0() {
		
		func_0012();
	} // end func
	/*
	void func_00ea() {
		
		param1[1] = game_days;
		param1[2] = game_mins;
	} // end func
	
	void func_0106() {
		
		int[] locals = new int[5];
		
		locals[2] = game_days - param2[1];
		locals[3] = game_mins - param2[2];
		if ( locals[3] < 0 ) {
			
			locals[3] = locals[3] + 1440;
			locals[2] = locals[2] - 1;
		} // end if
		
		if ( locals[2] >= param1[1] && locals[3] >= param1[2] ) {
			
			locals[1] = 1;
		} else {
			
			locals[1] = 0;
		} // end if
		
		return locals[1];
	} // end func
	
	void func_018f() {
		
		param1[1] = game_days - param3[1];
		param1[2] = game_mins - param3[2];
		if ( param1[2] < 0 ) {
			
			param1[2] = param1[2] + 1440;
			param1[1] = param1[1] - 1;
		} // end if
		
		param1[1] = param2[1] - param1[1];
		param1[2] = param2[2] - param1[2];
		if ( param1[2] < 0 ) {
			
			param1[2] = param1[2] + 1440;
			param1[1] = param1[1] - 1;
		} // end if
		
	} // end func
	
	void func_0243() {
		
		param1[1] = game_days - param2[1];
		param1[2] = game_mins - param2[2];
		if ( param1[2] < 0 ) {
			
			param1[2] = param1[2] + 1440;
			param1[1] = param1[1] - 1;
		} // end if
		
	} // end func
	*/
	IEnumerator func_029d() {
		
		int[] locals = new int[23];
		
		if ( privateVariables[0] == 1 ) {
			
			yield return StartCoroutine(func_0681());
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			yield break;
		} else {
			
			yield return StartCoroutine(say( "Who art thou?  Art thou here to take me back to the mines?  But no, thou art not one of them... Art thou here to rescue us, then?" ));
			locals[1] = 2;
			locals[2] = 3;
			locals[3] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_02f1());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_02f1());
				break;
			} // end if
			
	
			
		} // end switch
		
	} // end func
	
	IEnumerator func_02f1() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Ah, then, a prisoner like the rest of us..." ));
		locals[1] = 5;
		locals[2] = 6;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0339());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0459());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0339() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Tyball keeps us here. To work the mines 'til we die... if we're lucky that is. Less fortunate ones he takes away to work his evil magicks on." ));
		locals[1] = 8;
		locals[2] = 9;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0381());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0459());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0381() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "There are caverns to the east, filled with the dead. Victims of his  dark arts, gone awry. 'Tis said not even he dares venture there now.  But the dead things wait, taking their vengeance on any living thing  that enters." ));
		locals[1] = 11;
		locals[2] = 12;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_03c9());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0639());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03c9() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Who knows what we dig for? Mayhap materials he needs for his magic.  But it's been days now since I've worked the mines, after what we found on the lower level... And so few of us remain, left to rot in our cells." ));
		locals[1] = 14;
		locals[2] = 15;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0411());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0411());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0411() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "We dug through to the level below this and hit a natural cavern. The walls were veined  with gold, but that's not what we were digging for, I'm sure. It was  here the fell beasts attacked us and killed most of us prisoners. \n"
		                                +" The remaining few of us have been left here for days, with no food or  water. If thou couldst spare a morsel..." ));
		locals[1] = 17;
		locals[2] = 18;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_051d());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_04a1());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0459() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Oh, a hero, eh?  Ruddy great!  Won't Tyball have a time with thee!" ));
		locals[1] = 20;
		locals[2] = 21;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0381());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_04d5());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_04a1() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Farewell, then, and good luck!" ));
		locals[1] = 23;
		locals[2] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		if ( locals[22] == 1 ) {
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
		} // end if
		
	} // end func
	
	IEnumerator func_04d5() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "What I mean is that Tyball eats heroes the way a sailor eats limes!" ));
		locals[1] = 25;
		locals[2] = 26;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_04a1());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0639());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_051d() {
		
		int[] locals = new int[64];
		
		//locals[16] = show_inv( 2, locals[6], locals[1] );
		locals[16] = show_inv (2,locals,6,1);
		locals[18] = 0;
		locals[19] = 0;
		int counter=0;
		while ( locals[16] != 0 ) {
			
			locals[17] = locals[1+counter];
			if ( (locals[17] == 176) || (locals[17] == 177) || (locals[17] == 178) || (locals[17] == 179) || (locals[17] == 180) || (locals[17] == 181) || (locals[17] == 182) ) {
				
				locals[18] = locals[18] + count_inv( 1, locals[6+counter] );
				locals[19] = locals[19] + 1;
				locals[11+counter] = locals[6+counter];
			} // end if
			counter++;
			locals[16] = locals[16] - 1;
		} // while
		
		if ( locals[18] > 0 ) {
			give_to_npc(2,locals,11,locals[19]);
			//give_to_npc( 2, locals[11], locals[19] );
			yield return StartCoroutine(say( "Many thanks!  Thou art a hero as far as I am concerned, just for sharing thy food!" ));
			locals[20] = 28;
			locals[21] = 0;
			//locals[41] = babl_menu( 0, locals[20] );
			yield return StartCoroutine(babl_menu (0,locals,20));   locals[41] = PlayerAnswer;
			if ( locals[41] == 1 ) {
				
				yield return StartCoroutine(func_04a1());
			} // end if
			
		} else {
			
		} // end if
		
		yield return StartCoroutine(say( "Hast thou no food for me?" ));
		locals[42] = 30;
		locals[43] = 31;
		locals[44] = 0;
		//locals[63] = babl_menu( 0, locals[42] );
		yield return StartCoroutine(babl_menu (0,locals,42));   locals[63] = PlayerAnswer;
		switch ( locals[63] ) {
			
		case 1:
			
			yield return StartCoroutine(func_051d());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_04a1());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0639() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "I am no sorcerer.  Whatever he attempts, though, it can mean no good!" ));
		locals[1] = 33;
		locals[2] = 34;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_04a1());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_04a1());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0681() {
		
		int[] locals = new int[4];
		locals[2]=3;
		locals[1] = random( 1, locals[2] );

		locals[3] = locals[1];
		if ( 1 == locals[3] ) {
			
			yield return StartCoroutine(say( "I'm too weak to talk." ));
		} else {
			
			if ( 2 == locals[3] ) {
				
				yield return StartCoroutine(say( "Get away, before the guards come back!" ));
			} else {
				
				if ( 3 == locals[3] ) {
					
					yield return StartCoroutine(say( "Farewell, friend!  I'm too weak to talk!" ));
				} // end if
				
			} // end if
			
		} // end if
		
	} // end func
	/*
	void func_06c9() {
		
		int[] locals = new int[45];
		
		setup_to_barter( 0 );
		while ( !privateVariables[1] ) {
			
			locals[1] = 38;
			locals[2] = 39;
			locals[3] = 40;
			locals[4] = 41;
			locals[5] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				func_077a();
				break;
				
			case 2:
				
				func_07d4();
				break;
				
			case 3:
				
				do_judgement( 0 );
				break;
				
			case 4:
				
				do_decline( 0 );
				privateVariables[1] = 1;
				break;
				
			} // end switch
			
		} // while
		
		locals[23] = 42;
		locals[24] = 0;
		yield return StartCoroutine(babl_menu (0,locals,23));   locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	void func_077a() {
		
		int[] locals = new int[16];
		
		locals[0] = -1;
		locals[6] = -1;
		locals[11] = 43;
		locals[12] = 44;
		locals[13] = 45;
		locals[14] = 46;
		locals[15] = 47;
		if ( do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ) ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	void func_07d4() {
		
		int[] locals = new int[25];
		
		yield return StartCoroutine(say( "Dost thou intend to rob me?" ));
		locals[1] = 49;
		locals[2] = 50;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			return;
			
			break;
			
		} // end switch
		
		locals[23] = 51;
		locals[24] = 52;
		if ( do_demand( 2, locals[24], locals[23] ) ) {
			
			privateVariables[1] = 1;
		} else {
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
		} // end if
		
	} // end func

*/

}
