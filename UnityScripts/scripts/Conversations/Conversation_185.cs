using UnityEngine;
using System.Collections;

public class Conversation_185 : Conversation {


	//conversation #185
	//	string block 0x0eb9, name Nilpont

	public override IEnumerator main() {
		SetupConversation (3769);
		privateVariables[1] = 0;
		yield return StartCoroutine(func_029d());
		func_0012();
		yield return 0;
	} // end func
	
	void func_0012() {
		EndConversation();
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
	*/
	void func_00b1(int param1) {
		
		npc.npc_attitude =param1;// param1[0]play_hunger;
		func_0012();
	} // end func
	/*
	void func_00c2() {
		
		npc.npc_attitude = 2;
		func_0012();
	} // end func
	
	void func_00d1() {
		
		npc.npc_attitude = 1;
		func_0012();
	} // end func
	
	void func_00e0() {
		
		func_0012();
	} // end func
	
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
		
		if ( privateVariables[0]==1 ) {
			
			yield return StartCoroutine(func_03b4());
		} else {
			
			privateVariables[2] = 0;
			privateVariables[3] = 0;
			yield return StartCoroutine(say( "I see thou art an adventurer.  Art thou here searching for a Golem?" ));
			locals[1] = 2;
			locals[2] = 3;
			locals[3] = 4;
			locals[4] = 5;
			locals[5] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_0336());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_0399());
				break;
				
			case 3:
				
				yield return StartCoroutine(func_0320());
				break;
				
			case 4:
				
				yield return StartCoroutine(func_0351());
				break;
			} // end if
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0320() {
		
		int[] locals = new int[2];
		
		yield return StartCoroutine(say( "Well then, I wish thee luck with whatever else thou searchest for." ));
		locals[1] = 2;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );
		yield break;
	} // end func
	
	IEnumerator func_0336() {
		
		int[] locals = new int[2];
		
		privateVariables[2] = 1;
		yield return StartCoroutine(say( "Thou canst find him by heading west from the central chamber as far as thou canst and then turning left.  He's on the island surrounded by lava.  Be warned - he is quite tough!" ));
		locals[1] = 2;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );
		yield break;
	} // end func
	
	IEnumerator func_0351() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "The Golem was created by the Seer Lerin at the Knights' request as a test of valor.  No Knights have come down to test themselves against him for quite a while now, but they used to frequently.  I believe that a suitable prize awaits the one who can defeat him." ));
		locals[1] = 9;
		locals[2] = 10;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0336());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0320());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0399() {
		
		int[] locals = new int[2];
		
		privateVariables[3] = 1;
		yield return StartCoroutine(say( "Congratulations!  Thou art truly as valorous as a Knight." ));
		locals[1] = 3;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );
		yield break;
	} // end func
	
	IEnumerator func_03b4() {
		
		int[] locals = new int[46];
		
		if ( privateVariables[3] ==1) {
			
			yield return StartCoroutine(say( "Congratulations again on defeating the Golem.  I hope that thy valor will enable thee to rid the Abyss of whatever foul creatures remain." ));
			locals[1] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[1] );
			yield break;
		} else {
			
			if ( privateVariables[2] ==1) {
				
				yield return StartCoroutine(say( "Greetings!  Hast thou defeated the Golem I told thee of?" ));
				locals[2] = 14;
				locals[3] = 15;
				locals[4] = 0;
				yield return StartCoroutine(babl_menu (0,locals,2));   locals[23] = PlayerAnswer;
				switch ( locals[23] ) {
					
				case 1:
					
					yield return StartCoroutine(func_0458());
					break;
					
				case 2:
					
					yield return StartCoroutine(func_0399());
					break;
				} // end if
				
			} 
			
			yield return StartCoroutine(say( "Greetings!  Hast thou decided to challenge the Golem after all?" ));
			locals[24] = 17;
			locals[25] = 18;
			locals[26] = 0;
			//locals[45] = babl_menu( 0, locals[24] );
			yield return StartCoroutine(babl_menu (0,locals,24));
			locals[45] = PlayerAnswer;
			switch ( locals[45] ) {
				
			case 1:
				
				yield return StartCoroutine(func_0336());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_0320());
				break;
			} // end if
			

			
		} // end switch
		
	} // end func
	
	IEnumerator func_0458() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "And why not?" ));
		locals[1] = 20;
		locals[2] = 21;
		locals[3] = 22;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0336());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_04b4());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_04b4());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_04b4() {
		
		int[] locals = new int[2];
		
		yield return StartCoroutine(say( "Do not be ashamed - only the most valorous are capable of defeating the Golem." ));
		locals[1] = 2;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );
		yield break;
	} // end func
	
	/*void func_04ca() {
		
		int[] locals = new int[45];
		
		setup_to_barter( 0 );
		while ( !privateVariables[1] ) {
			
			locals[1] = 24;
			locals[2] = 25;
			locals[3] = 26;
			locals[4] = 27;
			locals[5] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				func_057b();
				break;
				
			case 2:
				
				func_05d5();
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
		
		locals[23] = 28;
		locals[24] = 0;
		yield return StartCoroutine(babl_menu (0,locals,23));   locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	void func_057b() {
		
		int[] locals = new int[16];
		
		locals[0] = -1;
		locals[6] = -1;
		locals[11] = 29;
		locals[12] = 30;
		locals[13] = 31;
		locals[14] = 32;
		locals[15] = 33;
		if ( do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ) ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	void func_05d5() {
		
		int[] locals = new int[25];
		
		yield return StartCoroutine(say( "Dost thou intend to rob me?" ));
		locals[1] = 35;
		locals[2] = 36;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			return;
			
			break;
			
		} // end switch
		
		locals[23] = 37;
		locals[24] = 38;
		if ( do_demand( 2, locals[24], locals[23] ) ) {
			
			privateVariables[1] = 1;
		} else {
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
		} // end if
		
	} // end func

*/

}
