using UnityEngine;
using System.Collections;

public class Conversation_140 : Conversation {
	
	//conversation #140
	//	string block 0x0e8c, name Ree
	
	
	
	public override IEnumerator main() {
		SetupConversation (3724);
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
		
		if ( privateVariables[0] == 1) {
			
			yield return StartCoroutine(func_02ee());
		} else {
			
			yield return StartCoroutine(say( locals, 001 ));
			locals[1] = 2;
			locals[2] = 3;
			locals[3] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_034a());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_05d6());
				break;
			} // end if
			
			
			
		} // end switch
		
	} // end func
	
	IEnumerator func_02ee() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 004 ));
		locals[1] = 5;
		locals[2] = 6;
		locals[3] = 7;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_05d6());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_034a());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_034a());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_034a() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 008 ));
		locals[1] = 9;
		locals[2] = 10;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0392());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_05d6());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0392() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 011 ));
		locals[1] = 12;
		locals[2] = 13;
		locals[3] = 14;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_03ee());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0436());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_047f());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03ee() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 015 ));
		locals[1] = 16;
		locals[2] = 17;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0436());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_047f());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0436() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 018 ));
		locals[1] = 19;
		locals[2] = 21;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(say( locals, 020 ));
			break;
			
		case 2:
			
			break;
			
		} // end switch
		
		yield return StartCoroutine(func_05fe());
	} // end func
	
	IEnumerator func_047f() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 022 ));
		locals[1] = 23;
		locals[2] = 24;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0530());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_04c7());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_04c7() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 025 ));
		locals[1] = 26;
		locals[2] = 27;
		locals[3] = 28;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0523());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0523());
			break;
			
		case 3:
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;

		} // end switch
		
	} // end func
	
	IEnumerator func_0523() {
		int[] locals = new int[1];
		yield return StartCoroutine(say( locals, 029 ));
		yield return StartCoroutine(func_05fe());
	} // end func
	
	IEnumerator func_0530() {
		
		int[] locals = new int[47];
		locals[3] = 32;
		locals[1] = get_quest( 1, locals[3] );
		
		if ( locals[1] < 2 ) {
			
			locals[2] = 1;
		} else {
			
			locals[2] = 0;
		} // end if
		
		yield return StartCoroutine(say( locals, 030 ));
		locals[25] = 1;
		locals[4] = 31;
		locals[26] = locals[2];
		locals[5] = 32;
		locals[6] = 0;
		//locals[46] = babl_fmenu( 0, locals[4], locals[25] );
		yield return StartCoroutine (babl_fmenu (0,locals,4,25));
		locals[46]=PlayerAnswer;
		switch ( locals[46] ) {
			
		case 31:
			
			yield return StartCoroutine(func_04c7());
			break;
			
		case 32:
			
			yield return StartCoroutine(func_05b2());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_05b2() {
		
		int[] locals = new int[3];
		
		yield return StartCoroutine(say( locals, 033 ));
		locals[1] = 32;
		locals[2] = 1;
		set_quest( 2, locals[2], locals[1] );
		yield return StartCoroutine(func_05fe());
	} // end func
	
	IEnumerator func_05d6() {
		
		int[] locals = new int[4];
		locals[2] = 34;
		locals[3] = 35;
		locals[1] = sex( 2, locals[3], locals[2] );
		
		yield return StartCoroutine(say( locals, 036 ));
		yield return StartCoroutine(func_05fe());
	} // end func
	
	IEnumerator func_05fe() {
		
		int[] locals = new int[23];
		
		locals[1] = 37;
		locals[2] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		if ( locals[22] == 1 ) {
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
		} // end if
		
	} // end func
	
}
