using UnityEngine;
using System.Collections;

public class Conversation_217 : Conversation {

	//conversation #217
	//	string block 0x0ed9, name Gurstang

	int[] global = new int[2];
	public override IEnumerator main() {
		SetupConversation (3801);
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
		
		npc.npc_attitude = param1[0]global[0];
		func_0012();
	} // end func
	*/
	void func_00c2() {
		
		npc.npc_attitude = 2;
		func_0012();
	} // end func
	/*
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
		
		int[] locals = new int[24];
		locals[1] = 9;
		global[1] = get_quest( 1, locals[1] );

		if ( privateVariables[0] == 1 ) {
			
			yield return StartCoroutine(func_03f7());
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
		} else {
			
			global[0] = 0;
			yield return StartCoroutine(say( "Ahh...So thou must be the one who has vanquished Tyball. Good...good...I sensed his passing but feared I would die here, forgotten." ));
			locals[2] = 2;
			locals[3] = 3;
			locals[4] = 0;
			yield return StartCoroutine(babl_menu (0,locals,2));   locals[23] = PlayerAnswer;
			switch ( locals[23] ) {
				
			case 1:
				
				yield return StartCoroutine(func_0308());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_047d());
				break;
			} // end if
			

			
		} // end switch
		
	} // end func
	
	IEnumerator func_0308() {
		
		int[] locals = new int[44];
		
		yield return StartCoroutine(say( "I am Gurstang. I ventured down here searching for the Key of Truth." ));
		locals[22] = global[1];
		locals[1] = 5;
		locals[23] = 1;
		locals[2] = 6;
		locals[3] = 0;
		//locals[43] = babl_fmenu( 0, locals[1], locals[22] );
		yield return StartCoroutine (babl_fmenu (0,locals,1,22));
		locals[43]=PlayerAnswer;
		switch ( locals[43] ) {
			
		case 5:
			
			yield return StartCoroutine(func_0364());
			break;
			
		case 6:
			
			yield return StartCoroutine(func_0376());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0364() {
		
		global[0] = 1;
		yield return StartCoroutine(say( "Illomo! So, Illomo told thee about me. Good, that means I  can trust thee. I think I've discovered the whereabouts of the key. Tell Illomo 'Folanae.' He'll know where to look, and explain what to do. As for myself, I have other matters to attend to down here. Farewell." ));
		yield return StartCoroutine(func_044c());
	} // end func
	
	IEnumerator func_0376() {
		
		int[] locals = new int[23];
		
		global[0] = 1;
		yield return StartCoroutine(say( "A noble quest, indeed, and one that should be fulfilled, even though I am no longer the man to do it.  Hmm.  I shall have to take a risk and trust thee. Seek out a man in the area of the Seers of the Moonstone.  His name is Illomo.  When thou dost meet him, tell him I recommend thee to him, and say this word: \"Folanae.\" He will know what to do next." ));
		locals[1] = 9;
		locals[2] = 10;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_03c3());
			break;
			
		case 2:
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00c2();yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03c3() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "No thanks are necessary, as long as thou dost succeed in the quest.  Now, go!" ));
		locals[1] = 12;
		locals[2] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		if ( locals[22] == 1 ) {
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
		} // end if
		
	} // end func
	
	IEnumerator func_03f7() {
		
		int[] locals = new int[4];
		
		if ( global[0]==0 ) {
			
			yield return StartCoroutine(say( "Thou art back!" ));
			yield return StartCoroutine(func_0308());
		} else {

			locals[2] = 3;
			locals[1] = random( 1, locals[2] );
			locals[3] = locals[1];
			if ( 1 == locals[3] ) {
				
				yield return StartCoroutine(say( "I've other business.  Farewell." ));
			} else {
				
				if ( 2 == locals[3] ) {
					
					yield return StartCoroutine(say( "Continue thy quest!  I shall be all right." ));
				} else {
					
					if ( 3 == locals[3] ) {
						
						yield return StartCoroutine(say( "Farewell!  I'm too busy to talk!" ));
					} // end if
					
				} // end if
				
			} // end if
			
		} // end if
		
	} // end func
	
	IEnumerator func_044c() {
		
		int[] locals = new int[23];
		
		locals[1] = 17;
		locals[2] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		if ( locals[22] == 1 ) {
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
		} // end if
		
	} // end func
	
	IEnumerator func_047d() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Gone?  Yes, I imagine he is.  But his malice lingers, does it not?" ));
		locals[1] = 19;
		locals[2] = 20;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_04c5());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0308());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_04c5() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Dost thou seek the Key of Truth?  It may help thee." ));
		locals[1] = 22;
		locals[2] = 23;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0376());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0376());
			break;
			
		} // end switch
		
	} // end func
	/*
	void func_050d() {
		
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
				
				func_05be();
				break;
				
			case 2:
				
				func_0618();
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
	
	void func_05be() {
		
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
	
	void func_0618() {
		
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
