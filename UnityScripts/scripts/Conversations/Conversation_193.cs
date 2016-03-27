using UnityEngine;
using System.Collections;

public class Conversation_193 : Conversation {
	
	//conversation #193
	//	string block 0x0ec1, name Louvnon
	
	public override IEnumerator main() {
		SetupConversation (3777);
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
		
		int[] locals = new int[183];
		
		if ( privateVariables[0] ==1) {
			
		} else {
			
			yield return StartCoroutine(say( locals, 001 ));
			locals[2] = 2;
			locals[3] = 3;
			locals[4] = 4;
			locals[5] = 0;
			yield return StartCoroutine(babl_menu (0,locals,2));   locals[23] = PlayerAnswer;
			switch ( locals[23] ) {
				
			case 1:
				
				goto label_02fd;
				
				break;
				
			case 2:
				
				goto label_02fd;
				
				break;
				
			case 3:
				
				//goto label_032e;
				
				/*moved here*/
				yield return StartCoroutine(say( locals, 007 ));
				locals[46] = 8;
				locals[47] = 0;
				//locals[67] = babl_menu( 0, locals[46] );
				yield return StartCoroutine(babl_menu (0,locals,46));
				locals[67] = PlayerAnswer;
				if ( locals[67] == 1 ) {
					
					goto label_035a;
					
				} // end if
				
				/*end moved here*/
				break;
				
			} // end switch
			
		label_02fd:;
			
			privateVariables[2] = 1;
			yield return StartCoroutine(say( locals, 005 ));
			locals[24] = 6;
			locals[25] = 0;
			//locals[45] = babl_menu( 0, locals[24] );
			yield return StartCoroutine(babl_menu (0,locals,24));
			locals[45] = PlayerAnswer;
			if ( locals[45] == 1 ) {
				
			} else {
				
			label_032e:;
				
				yield return StartCoroutine(say( locals, 007 ));
				locals[46] = 8;
				locals[47] = 0;
				//locals[67] = babl_menu( 0, locals[46] );
				yield return StartCoroutine(babl_menu (0,locals,46));
				locals[67] = PlayerAnswer;
				if ( locals[67] == 1 ) {
					
					goto label_035a;
					
				} // end if
				
			} // end if
			
		label_035a:;
			
			yield return StartCoroutine(say( locals, 009 ));
			locals[68] = 10;
			locals[69] = 11;
			locals[70] = 0;
			//locals[89] = babl_menu( 0, locals[68] );
			yield return StartCoroutine(babl_menu (0,locals,68));
			locals[89] = PlayerAnswer;
			switch ( locals[89] ) {
				
			case 1:
				
				break;
				
			case 2:
				
				break;
				
			} // end switch
			
			yield return StartCoroutine(say( locals, 012 ));
			locals[90] = 13;
			locals[91] = 14;
			locals[92] = 0;
			//locals[111] = babl_menu( 0, locals[90] );
			yield return StartCoroutine(babl_menu (0,locals,90));
			locals[111] = PlayerAnswer;
			switch ( locals[111] ) {
				
			case 1:
				
				break;
				
			case 2:
				
				yield return StartCoroutine(say( locals, 015 ));
				locals[112] = 3;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[112] );
				yield break;
				break;
				
			} // end switch
			
			yield return StartCoroutine(say( locals, 016 ));
			locals[113] = 17;
			locals[114] = 18;
			locals[115] = 0;
			//locals[134] = babl_menu( 0, locals[113] );
			yield return StartCoroutine(babl_menu (0,locals,113));
			locals[134] = PlayerAnswer;
			switch ( locals[134] ) {
				
			case 1:
				
				locals[135] = 2;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[135] );
				yield break;
				break;
				
			case 2:
				
				locals[136] = 3;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[136] );
				yield break;
				break;
			} // end if
			
			
			
		} // end switch
		
		if ( privateVariables[2] ==1) {
			
			locals[1] = 19;
		} else {
			
			locals[1] = 20;
		} // end if
		
		yield return StartCoroutine(say( locals, 021 ));
		locals[137] = 22;
		locals[138] = 23;
		locals[139] = 0;
		//locals[158] = babl_menu( 0, locals[137] );
		yield return StartCoroutine(babl_menu (0,locals,137));
		locals[158] = PlayerAnswer;
		switch ( locals[158] ) {
			
		case 1:
			
			goto label_048c;
			
			break;
			
		case 2:
			
			locals[159] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[159] );
			yield break;
			break;
			
		} // end switch
		
	label_048c:;
		
		yield return StartCoroutine(say( locals, 024 ));
		locals[160] = 25;
		locals[161] = 0;
		//locals[181] = babl_menu( 0, locals[160] );
		yield return StartCoroutine(babl_menu (0,locals,160));
		locals[181] = PlayerAnswer;
		if ( locals[181] == 1 ) {
			
		} // end if
		
		yield return StartCoroutine(say( locals, 026 ));
		locals[182] = 3;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[182] );
		yield break;
	} // end func
	
	
	
}
