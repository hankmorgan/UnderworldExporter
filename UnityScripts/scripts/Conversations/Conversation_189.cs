using UnityEngine;
using System.Collections;

public class Conversation_189 : Conversation {

	//conversation #189
	//	string block 0x0ebd, name Shenilor

	
	public override IEnumerator main() {
		SetupConversation (3773);
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
			
			yield return StartCoroutine(func_0528());
		} else {
			
			yield return StartCoroutine(say( "Hail, stranger!  Hast thou come to enroll in the Academy?" ));
			locals[1] = 2;
			locals[2] = 3;
			locals[3] = 4;
			locals[4] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_0302());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_030f());
				break;
				
			case 3:
				
				yield return StartCoroutine(func_031c());
				break;
			} // end if
			

			
		} // end switch
		
	} // end func
	
	IEnumerator func_0302() {
		
		yield return StartCoroutine(say( "That is too bad, for it has been closed for years now." ));
		yield return StartCoroutine(func_0329());
	} // end func
	
	IEnumerator func_030f() {
		
		yield return StartCoroutine(say( "'Twould not matter in any case, for the Academy has been closed for many a year." ));
		yield return StartCoroutine(func_0329());
	} // end func
	
	IEnumerator func_031c() {
		
		yield return StartCoroutine(say( "I am not surprised, for the Academy is now closed, and few remember its days of glory." ));
		yield return StartCoroutine(func_0329());
	} // end func
	
	IEnumerator func_0329() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "'Tis a pity that thou wert not here when Sir Cabirus was still alive.  The Abyss was a thriving settlement, and our Academy was the center of it.  Nobody seems to be interested in the higher arts any longer, though." ));
		locals[1] = 9;
		locals[2] = 10;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0371());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_049a());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0371() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "This is so.  Since the Academy was closed, most of us have been content merely to eke out a meager existence in some small corner of the Abyss." ));
		locals[1] = 12;
		locals[2] = 13;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_03b9());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0401());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03b9() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "I am afraid our once proud Academy has been infested by creatures who have no interest in the knowledge and wisdom contained there. To them, its halls offer notihg more than convenient shelter.  It pains my heart to think of the Academy's decline from the days of old." ));
		locals[1] = 15;
		locals[2] = 16;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_049a());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0401());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0401() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Perhaps one day the Abyss will return to its former glory, but I begin to doubt it more and more.  Ah, what I would not give to see the Academy restored!" ));
		locals[1] = 18;
		locals[2] = 19;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0449());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0449());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0449() {
		
		int[] locals = new int[24];
		
		yield return StartCoroutine(say( "It may be that thou art right.  All I can do is hope." ));
		locals[1] = 21;
		locals[2] = 22;
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
			
			yield return StartCoroutine(func_049a());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_049a() {
		
		int[] locals = new int[24];
		
		yield return StartCoroutine(say( "It is possible that in the old library of the Academy thou mayst be able to find some useful information.  But be careful - many monsters inhabit the Academy these days." ));
		locals[1] = 24;
		locals[2] = 25;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_04eb());
			break;
			
		case 2:
			
			locals[23] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_04eb() {
		
		int[] locals = new int[24];
		
		yield return StartCoroutine(say( "Enter the great hall of the Academy and head west.  The library will be on thy left.  Perhaps some of its books, and the knowledge contained therein, are still intact." ));
		locals[1] = 27;
		locals[2] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		if ( locals[22] == 1 ) {
			
			locals[23] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
		} // end if
		
	} // end func
	
	IEnumerator func_0528() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Greetings again!  Hast thou discovered aught in the area of the Academy?" ));
		locals[1] = 29;
		locals[2] = 30;
		locals[3] = 31;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0584());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0584());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_059a());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0584() {
		
		int[] locals = new int[2];
		
		yield return StartCoroutine(say( "I am sorry to hear that.  I fear that the best days of the Academy are past." ));
		locals[1] = 2;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );
		yield break;
	} // end func
	
	IEnumerator func_059a() {
		
		int[] locals = new int[2];
		
		yield return StartCoroutine(say( "Perhaps there is hope yet.  When thy quest is done, perhaps thou canst return to see us restore the Academy to its former state of glory." ));
		locals[1] = 2;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );
		yield break;
	} // end func
	/*
	void func_05b0() {
		
		int[] locals = new int[45];
		
		setup_to_barter( 0 );
		while ( !privateVariables[1] ) {
			
			locals[1] = 34;
			locals[2] = 35;
			locals[3] = 36;
			locals[4] = 37;
			locals[5] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				func_0661();
				break;
				
			case 2:
				
				func_06bb();
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
		
		locals[23] = 38;
		locals[24] = 0;
		yield return StartCoroutine(babl_menu (0,locals,23));   locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	void func_0661() {
		
		int[] locals = new int[16];
		
		locals[0] = -1;
		locals[6] = -1;
		locals[11] = 39;
		locals[12] = 40;
		locals[13] = 41;
		locals[14] = 42;
		locals[15] = 43;
		if ( do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ) ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	void func_06bb() {
		
		int[] locals = new int[25];
		
		yield return StartCoroutine(say( "Dost thou intend to rob me?" ));
		locals[1] = 45;
		locals[2] = 46;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			return;
			
			break;
			
		} // end switch
		
		locals[23] = 47;
		locals[24] = 48;
		if ( do_demand( 2, locals[24], locals[23] ) ) {
			
			privateVariables[1] = 1;
		} else {
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
		} // end if
		
	} // end func
*/
}
