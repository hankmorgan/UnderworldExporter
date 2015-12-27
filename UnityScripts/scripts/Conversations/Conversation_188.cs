using UnityEngine;
using System.Collections;

public class Conversation_188 : Conversation {

	//conversation #188
	//string block 0x0ebc, name Gralwart

	
	public override IEnumerator main() {
		SetupConversation (3772);
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
	*/
	void func_00b1(int param1) {
		
		npc.npc_attitude = param1;//param1[0]play_hunger;
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
			
			yield return StartCoroutine(func_03d1());
		} else {
			
			privateVariables[2] = 0;
			privateVariables[3] = 0;
			yield return StartCoroutine(say( "A new adventurer in our midst, eh?  Perhaps thou wouldst like to increase thy magical powers?" ));
			locals[1] = 2;
			locals[2] = 3;
			locals[3] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_034e());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_02f8());
				break;
			} // end if
			

			
		} // end switch
		
	} // end func
	
	IEnumerator func_02f8() {
		
		int[] locals = new int[24];
		
		yield return StartCoroutine(say( "Yes, I now see that thou art not as powerful as I first thought.  I'm sure thou hast not the power to use a Vas runestone anyways." ));
		locals[1] = 5;
		locals[2] = 6;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			locals[23] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			break;
			
		case 2:
			
			yield return StartCoroutine(say( "Well then, here's how to obtain one." ));
			yield return StartCoroutine(func_035d());
			yield return StartCoroutine(func_036d());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_034e() {
		
		yield return StartCoroutine(say( "Well, listen carefully, for I shall tell thee how to obtain a Vas runestone, the most powerful runestone there is." ));
		yield return StartCoroutine(func_035d());
		yield return StartCoroutine(func_036d());
	} // end func
	
	IEnumerator func_035d() {
		
		privateVariables[2] = 1;
		yield return StartCoroutine(say( "Go to the meeting hall to the east and shoot right between the eyes.  Then put an emerald on each of the four platforms in the corners, walk back to the middle of the room, and press the gray button." ));
	} // end func
	
	IEnumerator func_036d() {
		
		int[] locals = new int[24];
		
		locals[1] = 10;
		locals[2] = 11;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			locals[23] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			break;
			
		case 2:
			
			yield return StartCoroutine(func_03bb());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03bb() {
		
		int[] locals = new int[2];
		
		yield return StartCoroutine(say( "'Tis true - they are.  'Tis also true that if thou canst not follow them, thou art perhaps not worthy to reap the reward gained by doing so.  Good luck." ));
		locals[1] = 2;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );
		yield break;
	} // end func
	
	IEnumerator func_03d1() {
		
		if ( privateVariables[2]==1 ) {
			
			if ( privateVariables[3] ==1) {
				
				yield return StartCoroutine(func_03ed());
			} else {
				
				yield return StartCoroutine(func_0457());
			} // end if
			
		} else {
			
			yield return StartCoroutine(func_0403());
		} // end if
		
	} // end func
	
	IEnumerator func_03ed() {
		
		int[] locals = new int[2];
		
		yield return StartCoroutine(say( "Thou hast gained the runestone already.  Thou hast no further need of me. Use thy new powers as thou wilt!" ));
		locals[1] = 3;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );
		yield break;
	} // end func
	
	IEnumerator func_0403() {
		
		int[] locals = new int[24];
		
		yield return StartCoroutine(say( "Hello again, adventurer!  Hast thou decided to seek greater magical power after all?" ));
		locals[1] = 15;
		locals[2] = 16;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_034e());
			break;
			
		case 2:
			
			yield return StartCoroutine(say( "Very well, then." ));
			locals[23] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0457() {
		
		int[] locals = new int[24];
		
		yield return StartCoroutine(say( "Hello again!  Wert thou successful in finding what thou sought?" ));
		locals[1] = 19;
		locals[2] = 20;
		locals[3] = 21;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_04bf());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_04da());
			break;
			
		case 3:
			
			yield return StartCoroutine(say( "Good luck!" ));
			locals[23] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_04bf() {
		
		int[] locals = new int[2];
		
		privateVariables[3] = 1;
		yield return StartCoroutine(say( "Well done.  I wish thee luck with thy new power." ));
		locals[1] = 3;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );
		yield break;
	} // end func
	
	IEnumerator func_04da() {
		
		int[] locals = new int[24];
		
		yield return StartCoroutine(say( "Very well, I shall repeat them." ));
		yield return StartCoroutine(func_035d());
		locals[1] = 25;
		locals[2] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		if ( locals[22] == 1 ) {
			
			locals[23] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
		} // end if
		
	} // end func
	/*
	void func_0519() {
		
		int[] locals = new int[45];
		
		setup_to_barter( 0 );
		while ( !privateVariables[1] ) {
			
			locals[1] = 26;
			locals[2] = 27;
			locals[3] = 28;
			locals[4] = 29;
			locals[5] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				func_05ca();
				break;
				
			case 2:
				
				func_0624();
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
		
		locals[23] = 30;
		locals[24] = 0;
		yield return StartCoroutine(babl_menu (0,locals,23));   locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	void func_05ca() {
		
		int[] locals = new int[16];
		
		locals[0] = -1;
		locals[6] = -1;
		locals[11] = 31;
		locals[12] = 32;
		locals[13] = 33;
		locals[14] = 34;
		locals[15] = 35;
		if ( do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ) ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	void func_0624() {
		
		int[] locals = new int[25];
		
		yield return StartCoroutine(say( "Dost thou intend to rob me?" ));
		locals[1] = 37;
		locals[2] = 38;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			return;
			
			break;
			
		} // end switch
		
		locals[23] = 39;
		locals[24] = 40;
		if ( do_demand( 2, locals[24], locals[23] ) ) {
			
			privateVariables[1] = 1;
		} else {
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
		} // end if
		
	} // end func

*/
}
