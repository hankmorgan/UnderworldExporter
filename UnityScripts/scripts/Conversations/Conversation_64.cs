using UnityEngine;
using System.Collections;

public class Conversation_64 : Conversation {
	
	//conversation #64
	//	string block 0x0e40, name Jaacar
	
	
	public override IEnumerator main() {
		
		SetupConversation (3648);
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
	
	/*void func_0063() {
		
		npc.npc_gtarg = 1;
		npc.npc_attitude = 1;
		npc.npc_goal = 6;
		func_0012();
	} // end func*/
	
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
	
	void func_00b1(int param1) {
		
		npc.npc_attitude = param1;//[0];//play_hunger;
		func_0012();
	} // end func
	
	/*void func_00c2() {
		
		npc.npc_attitude = 2;
		func_0012();
	} // end func*/
	
	/*void func_00d1() {
		
		npc.npc_attitude = 1;
		func_0012();
	} // end func*/
	
	/*void func_00e0() {
		
		func_0012();
	} // end func*/
	
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
		
		//int locals[183];
		int[] locals=new int[184];
		
		if ( privateVariables[0] == 1) {
			
		} else {
			
			yield return StartCoroutine(say( locals, 001 ));
			locals[1] = 2;
			locals[2] = 3;
			locals[3] = 4;
			locals[4] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				goto label_02fd;
				
				break;
				
			case 2:
				
				goto label_038b;
				
				break;
				
			case 3:
				
				goto label_038b;
				
				break;
				
			} // end switch
			
		label_02fd:;
			
			yield return StartCoroutine(say( locals, 005 ));
			locals[23] = 6;
			locals[24] = 7;
			locals[25] = 0;
			//locals[44] = babl_menu( 0, locals[23] );
			yield return StartCoroutine(babl_menu (0,locals,23));
			locals[44] = PlayerAnswer;
			switch ( locals[44] ) {
				
			case 1:
				
				goto label_034b;
				
				break;
				
			case 2:
				
				goto label_033d;
				
				break;
				
			} // end switch
			
		label_033d:;
			
			yield return StartCoroutine(say( locals, 008 ));
			locals[45] = 1;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[45] );
			yield break;
		label_034b:;
			
			yield return StartCoroutine(say(locals, 009 ));
			locals[46] = 10;
			locals[47] = 11;
			locals[48] = 0;
			//locals[67] = babl_menu( 0, locals[46] );
			yield return StartCoroutine(babl_menu (0,locals,46));
			locals[67] = PlayerAnswer;
			switch ( locals[67] ) {
				
			case 1:
				
				goto label_03cb;
				
				break;
				
			case 2:
				
				goto label_03cb;
				
				break;
				
			} // end switch
			
		label_038b:;
			
			//label_038b:;
			
			yield return StartCoroutine(say( locals, 012 ));
			locals[68] = 13;
			locals[69] = 14;
			locals[70] = 0;
			//locals[89] = babl_menu( 0, locals[68] );
			yield return StartCoroutine(babl_menu (0,locals,68));
			locals[89] = PlayerAnswer;
			switch ( locals[89] ) {
				
			case 1:
				
				goto label_03cb;
				
				break;
				
			case 2:
				
				goto label_03cb;
				
				break;
				
			} // end switch
			
		label_03cb:;
			
			//label_03cb:;
			
			//label_03cb:;
			
			//label_03cb:;
			
			yield return StartCoroutine(say( locals, 015 ));
			locals[90] = 16;
			locals[91] = 17;
			locals[92] = 0;
			//locals[111] = babl_menu( 0, locals[90] );
			yield return StartCoroutine(babl_menu (0,locals,90));
			locals[111] = PlayerAnswer;
			switch ( locals[111] ) {
				
			case 1:
				
				goto label_040b;
				
				break;
				
			case 2:
				
				goto label_045d;
				
				break;
				
			} // end switch
			
		label_040b:;
			
			yield return StartCoroutine(say( locals, 018 ));
			locals[112] = 19;
			locals[113] = 20;
			locals[114] = 0;
			//locals[133] = babl_menu( 0, locals[112] );
			yield return StartCoroutine(babl_menu (0,locals,112));
			locals[133] = PlayerAnswer;
			switch ( locals[133] ) {
				
			case 1:
				
				locals[134] = 2;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[134] );
				yield break;
				break;
				
			case 2:
				
				locals[135] = 2;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[135] );
				yield break;
				break;
				
			} // end switch
			
		label_045d:;
			
			yield return StartCoroutine(say( locals, 021 ));
			locals[136] = 22;
			locals[137] = 23;
			locals[138] = 0;
			//locals[157] = babl_menu( 0, locals[136] );
			yield return StartCoroutine(babl_menu (0,locals,136));
			locals[157] = PlayerAnswer;
			switch ( locals[157] ) {
				
			case 1:
				
				locals[158] = 2;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[158] );
				yield break;
				break;
				
			case 2:
				
				locals[159] = 2;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[159] );
				yield break;
				break;
			} // end if
			
			
			
		} // end switch
		
		yield return StartCoroutine(say( locals, 024 ));
		locals[160] = 25;
		locals[161] = 26;
		locals[162] = 0;
		//locals[181] = babl_menu( 0, locals[160] );
		yield return StartCoroutine(babl_menu (0,locals,160));
		locals[181] = PlayerAnswer;
		switch ( locals[181] ) {
			
		case 1:
			
			locals[182] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[182] );
			yield break;
			break;
			
		case 2:
			
			locals[183] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[183] );
			yield break;
			break;
			
			
		} // end switch
		
	} // end func
	
}
