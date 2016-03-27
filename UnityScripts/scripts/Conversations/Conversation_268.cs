using UnityEngine;
using System.Collections;

public class Conversation_268 : Conversation {
	
	//conversation #268
	//	string block 0x0f0c, name  Grey Goblin Generic
	
	public override IEnumerator main() {
		SetupConversation (3852);
		privateVariables[1] = 0;
		yield return StartCoroutine(func_029d());
		func_0012();
		yield return 0;
	} // end func
	
	protected void func_0012() {
		EndConversation ();
		privateVariables[0] = 1;
	} // end func
	
	int func_0020() {
		
		//int locals[1];
		int[] locals=new int[2];
		
		if ( (((npc.npc_goal == 5 || npc.npc_goal == 6) || npc.npc_goal == 9) && npc.npc_gtarg == 1 || npc.npc_attitude == 0) ) {
			
			locals[1] = 0;
		} else {
			
			locals[1] = 1;
		} // end if
		
		return locals[1];
	} // end func
	
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
	
	void func_008b() {
		
		npc.npc_gtarg = 1;
		npc.npc_goal = 5;
		npc.npc_attitude = 1;
		func_0012();
	} // end func
	
	/*void func_00a4() {
		
		npc.npc_attitude = 6;
	} // end func*/
	
	/*void func_00b1() {
		
		npc.npc_attitude = param1[0]play_hunger;
		func_0012();
	} // end func*/
	
	/*void func_00c2() {
		
		npc.npc_attitude = 2;
		func_0012();
	} // end func*/
	
	/*void func_00d1() {
		
		npc.npc_attitude = 1;
		func_0012();
	} // end func*/
	
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
	
	protected IEnumerator func_029d() {
		
		//int locals[88];
		int[] locals=new int[89];
		if ( privateVariables[0] == 1) {
			
			yield return StartCoroutine(say( locals, 001 ));
		} else {
			
			yield return StartCoroutine(say( locals, 002 ));
		} // end if
		
		privateVariables[2] = 1;
		privateVariables[3] = 1;
		locals[1] = 3;
		locals[2] = 4;
		locals[3] = 5;
		locals[4] = 6;
		locals[5] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		
		switch ( locals[22] ) {
			
		case 1:
			
			goto label_031e;
			
			break;
			
		case 2:
			
			goto label_03b2;
			
			break;
			
		case 3:
			
			goto label_03f2;
			
			break;
			
		case 4:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			break;
			
		} // end switch
		
	label_031e:;
		
		yield return StartCoroutine(say( locals, 007 ));
		locals[23] = 8;
		locals[24] = 9;
		locals[25] = 0;
		//locals[44] = babl_menu( 0, locals[23] );
		yield return StartCoroutine(babl_menu (0,locals,23));
		locals[44] = PlayerAnswer;
		
		switch ( locals[44] ) {
			
		case 1:
			
			goto label_035e;
			
			break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			break;
			
		} // end switch
		
	label_035e:;
		
		//label_035e:;
		
		yield return StartCoroutine(say( locals, 010 ));
		locals[45] = 11;
		locals[46] = 12;
		locals[47] = 13;
		locals[48] = 0;
		//locals[66] = babl_menu( 0, locals[45] );
		yield return StartCoroutine(babl_menu (0,locals,45));
		locals[66] = PlayerAnswer;
		
		switch ( locals[66] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			break;
			
		case 2:
			
			goto label_03f2;
			
			break;
			
		case 3:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			break;
			
		} // end switch
		
	label_03b2:;
		
		yield return StartCoroutine(say( locals, 014 ));
		locals[67] = 15;
		locals[68] = 16;
		locals[69] = 0;
		//locals[88] = babl_menu( 0, locals[67] );
		yield return StartCoroutine(babl_menu (0,locals,67));
		locals[88] = PlayerAnswer;
		
		switch ( locals[88] ) {
			
		case 1:
			
			goto label_035e;
			
			break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			break;
			
		} // end switch
		
	label_03f2:;
		
		//label_03f2:;
		
		if ( func_0020() != 1 ) {
			
			yield return StartCoroutine(say( locals, 017 ));
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
		} else {
			
			yield return StartCoroutine(say( locals, 018 ));
		} // end if
		
		yield return StartCoroutine(func_040c());
		yield return StartCoroutine(say( locals, 019 ));
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00e0();
		yield break;
	} // end func
	
	IEnumerator func_040c() {
		
		//int locals[44];
		int[] locals=new int[45];
		setup_to_barter( 0 );
		while ( privateVariables[1]  != 1) {
			
			locals[1] = 20;
			locals[2] = 21;
			locals[3] = 22;
			locals[4] = 23;
			locals[5] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_04bd());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_0517());
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
		
		locals[23] = 24;
		locals[24] = 0;
		//locals[44] = babl_menu( 0, locals[23] );
		yield return StartCoroutine(babl_menu (0,locals,23));
		locals[44] = PlayerAnswer;
		
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_04bd() {
		
		//int locals[15];
		int[] locals=new int[16];
		
		locals[0] = -1;
		locals[6] = -1;
		locals[11] = 25;
		locals[12] = 26;
		locals[13] = 27;
		locals[14] = 28;
		locals[15] = 29;
		yield return StartCoroutine (do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ));
		//if ( do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ) == 1 ) {
		if (PlayerAnswer==1){
			privateVariables[1] = 1;
		} // end if
		yield return null;
	} // end func
	
	IEnumerator func_0517() {
		
		//int locals[24];
		int[] locals=new int[25];
		
		yield return StartCoroutine(say( locals, 030 ));
		locals[1] = 31;
		locals[2] = 32;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			yield return null;
			
			break;
			
		} // end switch
		
		locals[23] = 33;
		locals[24] = 34;
		yield return StartCoroutine (do_demand( 2, locals[24], locals[23] ));
		//if ( do_demand( 2, locals[24], locals[23] ) == 1 ) {
		if (PlayerAnswer==1){
			privateVariables[1] = 1;
		} else {
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_008b();
			yield break;
		} // end if
		yield return null;
	} // end func
	
	
	
	
}
