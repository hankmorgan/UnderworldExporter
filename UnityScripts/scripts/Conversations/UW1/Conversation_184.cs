using UnityEngine;
using System.Collections;

public class Conversation_184 : Conversation {
	
	//conversation #184
	//string block 0x0eb8, name Delanrey
	
	public override IEnumerator main() {
		SetupConversation (3768);
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
		
		npc.npc_attitude = param1;//[0]play_hunger;
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
		
		int[] locals = new int[46];
		locals[2] = 10;
		locals[1] = get_quest( 1, locals[2] );
		
		if ( privateVariables[0] == 1) {
			
			yield return StartCoroutine(func_03d4());
		} else {
			
			privateVariables[2] = 0;
			yield return StartCoroutine(say( locals, 001 ));
			locals[24] = 1;
			locals[3] = 2;
			locals[25] = locals[1];
			locals[4] = 3;
			locals[26] = 1;
			locals[5] = 4;
			locals[6] = 0;
			//locals[45] = babl_fmenu( 0, locals[3], locals[24] );
			yield return StartCoroutine (babl_fmenu(0,locals,3,24));
			locals[45] = PlayerAnswer;
			switch ( locals[45] ) {
				
			case 2:
				
				yield return StartCoroutine(func_0335());
				break;
				
			case 3:
				
				yield return StartCoroutine(func_034b());
				break;
				
			case 4:
				
				yield return StartCoroutine(func_0366());
				break;
			} // end if
			
			
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0335() {
		
		int[] locals = new int[2];
		
		yield return StartCoroutine(say( locals, 005 ));
		locals[1] = 2;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );
		yield break;
	} // end func
	
	IEnumerator func_034b() {
		
		int[] locals = new int[2];
		
		privateVariables[2] = 1;
		yield return StartCoroutine(say( locals, 006 ));
		locals[1] = 2;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );
		yield break;
	} // end func
	
	IEnumerator func_0366() {
		
		int[] locals = new int[46];
		
		locals[1] = get_quest( 1, locals[2] );
		locals[2] = 10;
		yield return StartCoroutine(say( locals, 007 ));
		locals[24] = 1;
		locals[3] = 8;
		locals[25] = locals[1];
		locals[4] = 9;
		locals[5] = 0;
		//locals[45] = babl_fmenu( 0, locals[3], locals[24] );
		yield return StartCoroutine (babl_fmenu(0,locals,3,24));
		locals[45] = PlayerAnswer;
		switch ( locals[45] ) {
			
		case 8:
			
			yield return StartCoroutine(func_0335());
			break;
			
		case 9:
			
			yield return StartCoroutine(func_034b());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03d4() {
		
		int[] locals = new int[47];
		locals[2] = 10;
		locals[1] = get_quest( 1, locals[2] );
		
		if ( privateVariables[2] == 1) {
			
			yield return StartCoroutine(say( locals, 010 ));
			locals[3] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[3] );
			yield break;
		} else {
			
			yield return StartCoroutine(say( locals, 011 ));
			locals[25] = 1;
			locals[4] = 12;
			locals[26] = locals[1];
			locals[5] = 13;
			locals[27] = 1;
			locals[6] = 14;
			locals[7] = 0;
			//locals[46] = babl_fmenu( 0, locals[4], locals[25] );
			yield return StartCoroutine (babl_fmenu(0,locals,4,25));
			locals[46] = PlayerAnswer;
			switch ( locals[46] ) {
				
			case 12:
				
				yield return StartCoroutine(func_0335());
				break;
				
			case 13:
				
				yield return StartCoroutine(func_034b());
				break;
				
			case 14:
				
				yield return StartCoroutine(func_0366());
				break;
			} // end if
			
			
			
		} // end switch
		
	} // end func
	
	/*void func_0473() {
		
		int[] locals = new int[45];
		
		setup_to_barter( 0 );
		while ( privateVariables[1] == 0) {
			
			locals[1] = 15;
			locals[2] = 16;
			locals[3] = 17;
			locals[4] = 18;
			locals[5] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				func_0524();
				break;
				
			case 2:
				
				func_057e();
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
		
		locals[23] = 19;
		locals[24] = 0;
		yield return StartCoroutine(babl_menu (0,locals,23));   locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	void func_0524() {
		
		int[] locals = new int[16];
		
		locals[0] = -1;
		locals[6] = -1;
		locals[11] = 20;
		locals[12] = 21;
		locals[13] = 22;
		locals[14] = 23;
		locals[15] = 24;
		if ( do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ) ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	void func_057e() {
		
		int[] locals = new int[25];
		
		yield return StartCoroutine(say( locals, 025 ));
		locals[1] = 26;
		locals[2] = 27;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			return;
			
			break;
			
		} // end switch
		
		locals[23] = 28;
		locals[24] = 29;
		if ( do_demand( 2, locals[24], locals[23] ) ) {
			
			privateVariables[1] = 1;
		} else {
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
		} // end if
		
	} // end func

*/
}
