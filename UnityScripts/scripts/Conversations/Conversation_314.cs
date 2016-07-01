using UnityEngine;
using System.Collections;

public class Conversation_314 : Conversation {
	
	//conversation #314
	//string block 0x0f3a, wisp
	
	public override IEnumerator main() {
		SetupConversation (3898);
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
		
		if ( (((npc_goal == 5 || npc_goal == 6) || npc_goal == 9) && npc_gtarg == 1 || npc_attitude == 0) ) {
			
			locals[1] = 0;
		} else {
			
			locals[1] = 1;
		} // end if
		
		return locals[1];
	} // end func
	
	void func_0063() {
		
		npc_gtarg = 1;
		npc_attitude = 1;
		npc_goal = 6;
		func_0012();
	} // end func
	
	void func_007c() {
		
		npc_goal = 1;
		func_0012();
	} // end func
	
	void func_008b() {
		
		npc_gtarg = 1;
		npc_goal = 5;
		npc_attitude = 1;
		func_0012();
	} // end func
	
	void func_00a4() {
		
		npc_attitude = 6;
	} // end func
	
	void func_00b1() {
		
		npc_attitude = param1[0]play_hunger;
		func_0012();
	} // end func
	
	void func_00c2() {
		
		npc_attitude = 2;
		func_0012();
	} // end func
	
	void func_00d1() {
		
		npc_attitude = 1;
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
		
		//int locals[110];
		int[] locals = new int[111];
		
		if ( privateVariables[0] ==1) {
			
		} else {
			
			yield return StartCoroutine(say( locals, 001 ));
			locals[1] = 2;
			locals[2] = 3;
			locals[3] = 0;
			//locals[22] = babl_menu( 0, locasl[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				goto label_02e9;

			case 2:
				
				goto label_02e9;

			} // end switch
			
		label_02e9:;
			
			
			
			yield return StartCoroutine(say( locals, 004 ));
			locals[23] = 5;
			locals[24] = 6;
			locals[25] = 0;
			//locals[44] = babl_menu( 0, locasl[23] );
			yield return StartCoroutine(babl_menu (0,locals,23));
			locals[44] = PlayerAnswer;
			switch ( locals[44] ) {
				
			case 1:
				
				goto label_0329;

			case 2:
				
				goto label_0329;

			} // end switch
			
		label_0329:;
			
			
			
			yield return StartCoroutine(say( locals, 007 ));
			locals[45] = 8;
			locals[46] = 9;
			locals[47] = 0;
			//locals[66] = babl_menu( 0, locasl[45] );
			yield return StartCoroutine(babl_menu (0,locals,45));
			locals[66] = PlayerAnswer;
			switch ( locals[66] ) {
				
			case 1:
				
				goto label_0369;

			case 2:
				
				goto label_0369;

			} // end switch
			
		label_0369:;
			
			
			yield return StartCoroutine(say( locals, 010 ));
			locals[67] = 11;
			locals[68] = 13;
			locals[69] = 0;
			//locals[88] = babl_menu( 0, locasl[67] );
			yield return StartCoroutine(babl_menu (0,locals,67));
			locals[88] = PlayerAnswer;
			switch ( locals[88] ) {
				
			case 1:
				
				yield return StartCoroutine(say( locals, 012 ));
				break;
				
			case 2:
				
				yield return StartCoroutine(say( locals, 014 ));
				break;
				
			} // end switch
			
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
		} // end if
		
		yield return StartCoroutine(say( locals, 015 ));
		locals[89] = 16;
		locals[90] = 18;
		locals[91] = 0;
		//locals[110] = babl_menu( 0, locasl[89] );
		yield return StartCoroutine(babl_menu (0,locals,89));
		locals[110] = PlayerAnswer;
		switch ( locals[110] ) {
			
		case 1:
			
			yield return StartCoroutine(say( locals, 017 ));
			break;
			
		case 2:
			
			yield return StartCoroutine(say( locals, 019 ));
			break;
			
		} // end switch
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00e0();
		yield break;
	} // end func
}
