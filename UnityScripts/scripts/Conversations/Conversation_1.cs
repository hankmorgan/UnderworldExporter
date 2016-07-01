using UnityEngine;
using System.Collections;

public class Conversation_1 : Conversation {
	
	//conversation #1
	//	string block 0x0e01, name Corby
	public int[] global = new int[1];
	
	public override IEnumerator main() {
		SetupConversation (3585);
		privateVariables[1] = 0;
		yield return StartCoroutine(func_029d());
		func_0012();
		yield return 0;
	} // end func
	
	void func_0012() {
		EndConversation();
		privateVariables[0] = 1;
	} // end func
	
	/*void func_0020() {
		
		int locals[1];
		
		if ( (((npc.npc_goal == 5 || npc.npc_goal == 6) || npc.npc_goal == 9) && npc.npc_gtarg == 1 || npc.npc_attitude == 0) ) {
			
			locals[1] = 0;
		} else {
			
			locals[1] = 1;
		} // end if
		
		return locals[1];
	} // end func*/
	
	void func_0063() {
		
		npc.npc_gtarg = 1;
		npc.npc_attitude = 1;
		npc.npc_goal = 6;
		func_0012();
	} // end func
	
	/*void func_007c() {
		
		npc.npc_goal = 1;
		func_0012();
	} // end func*/
	
	/*void func_008b() {
		
		npc.npc_gtarg = 1;
		npc.npc_goal = 5;
		npc.npc_attitude = 1;
		func_0012();
	} // end func*/
	
	/*void func_00a4() {
		
		npc.npc_attitude = 6;
	} // end func*/
	
	/*void func_00b1() {
		
		npc.npc_attitude = param1[0]global[0];
		func_0012();
	} // end func*/
	
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
	
	/*void func_00ea() {
		
		param1[1] = game_days;
		param1[2] = game_mins;
	} // end func*/
	
	/*void func_0106() {
		
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
	} // end func*/
	
	/*void func_018f() {
		
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
		
	} // end func*/
	
	/*void func_0243() {
		
		param1[1] = game_days - param2[1];
		param1[2] = game_mins - param2[2];
		if ( param1[2] < 0 ) {
			
			param1[2] = param1[2] + 1440;
			param1[1] = param1[1] - 1;
		} // end if
		
	} // end func*/
	
	IEnumerator func_029d() {
		
		//int locals[22];
		int [] locals = new int[23];
		
		if ( privateVariables[0] == 1 ) {
			
			yield return StartCoroutine(func_04c0());
		} else {
			
			global[0] = 0;
			yield return StartCoroutine(say( locals, 001 ));
			locals[1] = 2;
			locals[2] = 3;
			locals[3] = 4;
			locals[4] = 5;
			locals[5] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_031e());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_064a());
				break;
				
			case 3:
				
				yield return StartCoroutine(func_05f6());
				break;
				
			case 4:
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_0063();
				yield break;
			} // end if
			
			
			
		} // end switch
		
	} // end func
	
	IEnumerator func_031e() {
		
		//int locals[22];
		int [] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 006 ));
		locals[1] = 7;
		locals[2] = 8;
		locals[3] = 9;
		locals[4] = 10;
		locals[5] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			if ( global[0] == 0 ) {
				
				yield return StartCoroutine(func_039a());
			} else {
				
				yield return StartCoroutine(func_06a6());
			} // end if
			
			break;
			
		case 2:
			
			yield return StartCoroutine(func_059a());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_064a());
			break;
			
		case 4:
			
			yield return StartCoroutine(func_05f6());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_039a() {
		
		//int locals[22];
		int [] locals = new int[23];

		global[0] = 1;
		yield return StartCoroutine(say( locals, 011 ));
		locals[1] = 12;
		locals[2] = 13;
		locals[3] = 14;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_03fb());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_03fb());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_04b3());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03fb() {
		
		//int locals[22];
		int [] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 015 ));
		locals[1] = 16;
		locals[2] = 17;
		locals[3] = 18;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0457());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_059a());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_05f6());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0457() {
		
		//int locals[22];
		int [] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 019 ));
		locals[1] = 20;
		locals[2] = 21;
		locals[3] = 22;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_04b3());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_059a());
			break;
			
		case 3:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;

		} // end switch
		
	} // end func
	
	IEnumerator func_04b3() {
		int [] locals = new int[1];
		yield return StartCoroutine(say( locals, 023 ));
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00d1();
		yield break;
		
	} // end func
	
	IEnumerator func_04c0() {
		
		//int locals[44];
		int [] locals = new int[45];
		
		if ( npc.npc_attitude == 1 ) {
			
			yield return StartCoroutine(say( locals, 024 ));
			locals[1] = 25;
			locals[2] = 26;
			locals[3] = 27;
			locals[4] = 28;
			locals[5] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_05f6());
				break;
				
			case 2:
				
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_0063();
				yield break;
				
			case 3:
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00c2();
				yield break;
				
			case 4:
				
				yield return StartCoroutine(func_064a());
				break;
			} // end if
			
		} else {
			
			
			
			yield return StartCoroutine(say( locals, 029 ));
			locals[23] = 30;
			locals[24] = 31;
			locals[25] = 32;
			locals[26] = 0;
			//locals[44] = babl_menu( 0, locals[23] );
			yield return StartCoroutine(babl_menu (0,locals,23));
			locals[44] = PlayerAnswer;
			switch ( locals[44] ) {
				
			case 1:
				
				if ( global[0] == 0 ) {
					
					yield return StartCoroutine(func_039a());
				} else {
					
					yield return StartCoroutine(func_06a6());
				} // end if
				
				break;
				
			case 2:
				
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00d1();
				yield break;

			case 3:
				
				yield return StartCoroutine(func_059a());
				break;
				
			} // end switch
			
		} // end if //moved from above
	} // end func
	
	IEnumerator func_059a() {
		
		//int locals[22];
		int [] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 033 ));
		locals[1] = 34;
		locals[2] = 35;
		locals[3] = 36;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			func_00c2();
			break;
			
		case 2:
			
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_0063();
			yield break;

		case 3:
			
			yield return StartCoroutine(func_064a());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_05f6() {
		
		//int locals[22];
		int [] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 037 ));
		locals[1] = 38;
		locals[2] = 39;
		locals[3] = 0;
		///locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			if ( global[0] == 0 ) {
				
				yield return StartCoroutine(func_039a());
			} else {
				
				yield return StartCoroutine(func_06a6());
			} // end if
			
			break;
			
		case 2:
			
			func_00c2();
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_064a() {
		
		//int locals[22];
		int [] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 040 ));
		locals[1] = 41;
		locals[2] = 42;
		locals[3] = 43;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			func_00c2();
			break;
			
		case 2:
			
			yield return StartCoroutine(func_059a());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_05f6());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_06a6() {
		
		//int locals[22];
		int [] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 044 ));
		locals[1] = 45;
		locals[2] = 46;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_059a());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_039a());
			break;
			
		} // end switch
		
	} // end func
	
	
	
}
