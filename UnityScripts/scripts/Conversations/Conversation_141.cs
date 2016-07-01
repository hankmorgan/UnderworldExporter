using UnityEngine;
using System.Collections;

public class Conversation_141 : Conversation {
	
	//conversation #141
	//	string block 0x0e8d, name Feznor
	
	public override IEnumerator main() {
		SetupConversation (3725);
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
		
		int locals[1];
		
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
	*/
	void func_008b() {
		
		npc.npc_gtarg = 1;
		npc.npc_goal = 5;
		npc.npc_attitude = 1;
		func_0012();
	} // end func
	/*
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
*/	
	void func_00d1() {
		
		npc.npc_attitude = 1;
		func_0012();
	} // end func
	
	void func_00e0() {
		
		func_0012();
	} // end func
	/*	
	void func_00ea() {
		
		param1[1] = game_days;
		param1[2] = game_mins;
	} // end func
	
	void func_0106() {
		
		int locals[4];
		
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
		
		if ( privateVariables[0] == 0 ) {
			
			privateVariables[2] = 0;
		} // end if
		
		privateVariables[3] = 0;
		yield return StartCoroutine( func_02b9());
	} // end func
	
	IEnumerator func_02b9() {
		int[] locals = new int[1];
		while ( privateVariables[2] < 5 ) {
			
			if ( privateVariables[3] == 0 ) {
				
				yield return StartCoroutine(say( locals, 001 ));
				privateVariables[3] = 1;
			} else {
				
				yield return StartCoroutine(say( locals, 002 ));
			} // end if
			
			yield return StartCoroutine(func_02ef());
		} // while
		
		if ( privateVariables[3] == 0 ) {
			
			yield return StartCoroutine(say( locals, 003 ));
		} // end if
		
		yield return StartCoroutine(func_05b3());
	} // end func
	
	IEnumerator func_02ef() {
		
		//int locals[22];
		int[] locals = new int[23];
		
		locals[1] = 4;
		locals[2] = 6;
		locals[3] = 7;
		locals[4] = 8;
		locals[5] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			if ( privateVariables[9] == 1) {
				
				yield return StartCoroutine(say( locals, 005 ));
				yield return StartCoroutine(func_03d9());
			} else {
				
				yield return StartCoroutine(func_036b());
			} // end if
			
			break;
			
		case 2:
			
			yield return StartCoroutine(func_04b1());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_053a());
			break;
			
		case 4:
			
			yield return StartCoroutine(say( locals, 009 ));
			yield return StartCoroutine(func_05b3());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_036b() {
		
		//int locals[22];
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 010 ));
		locals[1] = 11;
		locals[2] = 12;
		locals[3] = 13;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_03c7());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_05a6());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_03c7());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03c7() {
		int[] locals = new int[1];
		privateVariables[9] = 1;
		yield return StartCoroutine(say( locals, 104 ));
		yield return StartCoroutine(func_03d9());
	} // end func
	
	IEnumerator func_03d9() {
		
		//int locals[22];
		int[] locals = new int[23];
		
		locals[1] = 15;
		locals[2] = 16;
		locals[3] = 17;
		locals[4] = 18;
		locals[5] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0446());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0460());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_0494());
			break;
			
		case 4:
			
			yield return StartCoroutine(func_047a());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0446() {
		int[] locals = new int[1];
		if ( privateVariables[4] == 1) {
			
			yield return StartCoroutine(say( locals, 019 ));
		} // end if
		
		yield return StartCoroutine(say( locals, 020 ));
		privateVariables[4] = 1;
		yield return StartCoroutine(func_02ef());
	} // end func
	
	IEnumerator func_0460() {
		int[] locals = new int[1];
		if ( privateVariables[5] == 1) {
			
			yield return StartCoroutine(say( locals, 019 ));
		} // end if
		
		yield return StartCoroutine(say( locals, 022 ));
		privateVariables[5] = 1;
		yield return StartCoroutine(func_02ef());
	} // end func
	
	IEnumerator func_047a() {
		int[] locals = new int[1];
		if ( privateVariables[7] == 1) {
			
			yield return StartCoroutine(say( locals, 019 ));
		} // end if
		
		yield return StartCoroutine(say( locals, 024 ));
		privateVariables[7] = 1;
		yield return StartCoroutine(func_02ef());
	} // end func
	
	IEnumerator func_0494() {
		int[] locals = new int[1];
		if ( privateVariables[6]== 1 ) {
			
			yield return StartCoroutine(say( locals, 019 ));
		} // end if
		
		yield return StartCoroutine(say( locals, 026 ));
		yield return StartCoroutine(say( locals, 027 ));
		privateVariables[6] = 1;
		yield return StartCoroutine(func_02ef());
	} // end func
	
	IEnumerator func_04b1() {
		
		//int locals[22];
		int []locals= new int[23];
		
		if ( privateVariables[8] == 1) {
			
			yield return StartCoroutine(say( locals, 019 ));
		} // end if
		
		yield return StartCoroutine(say( locals, 029 ));
		privateVariables[8] = 1;
		locals[1] = 30;
		locals[2] = 31;
		locals[3] = 33;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_052a());
			break;
			
		case 2:
			
			yield return StartCoroutine(say( locals, 032 ));
			func_052a();
			break;
			
		case 3:
			
			yield return StartCoroutine(func_051d());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_051d() {
		int[] locals = new int[1];
		yield return StartCoroutine(say( locals, 034 ));
		yield return StartCoroutine(func_02ef());
	} // end func
	
	IEnumerator func_052a() {
		int[] locals = new int[1];
		yield return StartCoroutine(say( locals, 035 ));
		yield return StartCoroutine(say( locals, 036 ));
		yield return StartCoroutine(func_02ef());
	} // end func
	
	IEnumerator func_053a() {
		
		//int locals[22];
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 037 ));
		locals[1] = 38;
		locals[2] = 39;
		locals[3] = 40;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0596());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0596());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_05a6());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0596() {
		int[] locals = new int[1];
		yield return StartCoroutine(say( locals, 041 ));
		yield return StartCoroutine(say( locals, 042 ));
		yield return StartCoroutine(func_02ef());
	} // end func
	
	IEnumerator func_05a6() {
		int[] locals = new int[1];
		yield return StartCoroutine(say( locals, 043 ));
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00d1();
		yield break;
	} // end func
	
	IEnumerator func_05b3() {
		
		//int locals[22];
		int[] locals = new int[23];
		
		locals[1] = 44;
		locals[2] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		if ( locals[22] == 1 ) {
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
		} // end if
		
	} // end func
	
	IEnumerator func_05e4() {
		
		//int locals[44];
		int[] locals =new int[45];
		setup_to_barter( 0 );
		while ( privateVariables[1] == 0 ) {
			
			locals[1] = 45;
			locals[2] = 46;
			locals[3] = 47;
			locals[4] = 48;
			locals[5] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_0695());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_06ef());
				break;
				
			case 3:
				
				yield return StartCoroutine(do_judgement( 0 ));
				break;
				
			case 4:
				
				do_decline( 0 );
				privateVariables[1] = 1;
				break;
				
			} // end switch
			
		} // while
		
		locals[23] = 49;
		locals[24] = 0;
		//locals[44] = babl_menu( 0, locals[23] );
		yield return StartCoroutine(babl_menu (0,locals,23));
		locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_0695() {
		
		//int locals[15];
		int[] locals = new int[16];
		
		locals[0] = -1;
		locals[6] = -1;
		locals[11] = 50;
		locals[12] = 51;
		locals[13] = 52;
		locals[14] = 53;
		locals[15] = 54;
		//if ( do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ) ) {
		yield return StartCoroutine (do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6],locals[1]) );
		if (PlayerAnswer==1)	{
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_06ef() {
		
		//int locals[24];
		int[] locals =  new int[25];
		
		yield return StartCoroutine(say( locals, 055 ));
		locals[1] = 56;
		locals[2] = 57;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			yield break;
			
		} // end switch
		
		locals[23] = 58;
		locals[24] = 59;
		//if ( do_demand( 2, locals[24], locals[23] ) ) {
		yield return StartCoroutine (do_demand( 2, locals[24], locals[23] ));
		if (PlayerAnswer==1){
			
			privateVariables[1] = 1;
		} else {
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_008b();
			yield break;
		} // end if
		
	} // end func
	
}
