using UnityEngine;
using System.Collections;

public class Conversation_281 : Conversation {
	
	//conversation #281
	//string block 0x0f19, name  Generic Grey Lizardman
	
	
	public override IEnumerator main() {
		SetupConversation (3865);
		privateVariables[1] = 0;
		yield return StartCoroutine(func_029d());
		func_0012();
		yield return 0;
	} // end func
	
	void func_0012() {
		EndConversation();
		privateVariables[0] = 1;
	} // end func
	
	int func_0020() {
		
		//int locals[1];
		int [] locals = new int[2];
		
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
	
	void func_00b1(int param1) {
		
		npc.npc_attitude = param1;//param1[0]play_hunger;
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
		
		//int locals[65];
		int [] locals = new int[66];
		
		if ( privateVariables[0] == 0) {
			
			privateVariables[2] = 1;
		} // end if
		
		if ( npc.npc_attitude != 3 ) {
			
			yield return StartCoroutine (say( locals, 001 ));
		} else {
			
			yield return StartCoroutine (say( locals, 002 ));
		} // end if
		
		locals[22] = 1;
		locals[1] = 3;
		locals[23] = 1;
		locals[2] = 4;
		locals[24] = privateVariables[2];
		locals[3] = 5;
		locals[25] = 1;
		locals[4] = 6;
		locals[5] = 0;
		//locals[43] = babl_fmenu( 0, locals[1], locals[22] );
		yield return StartCoroutine (babl_fmenu(0,locals,1,22));
		locals[43]=PlayerAnswer;
		switch ( locals[43] ) {
			
		case 3:
			
			yield return StartCoroutine (func_055e());
			break;
			
		case 4:
			
			break;
			
		case 5:
			
			yield return StartCoroutine (func_0436());
			break;
			
		case 6:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( 21 );
			yield break;
		
		} // end switch
		
		yield return StartCoroutine (say( locals, 007 ));
		locals[44] = 8;
		locals[45] = 9;
		locals[46] = 10;
		locals[47] = 0;
		//locals[65] = babl_menu( 0, locals[44] );
		yield return StartCoroutine (babl_menu (0,locals,44));
		locals[65]=PlayerAnswer;
		switch ( locals[65] ) {
			
		case 1:
			
			yield return StartCoroutine (func_0446());
			break;
			
		case 2:
			
			yield return StartCoroutine (func_054f());
			break;
			
		case 3:
			
			yield return StartCoroutine (func_039e());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_039e() {
		
		//int locals[27];
		int [] locals = new int[28];
		yield return StartCoroutine (babl_ask (0));
		//locals[1] = babl_ask( 0 );
		locals[2] = 11;
		if ( contains( 2, PlayerTypedAnswer, locals[2] ) == 1 ) {
			
			yield return StartCoroutine (func_0491());
		} // end if
		
		locals[3] = 12;
		if ( contains( 2, PlayerTypedAnswer, locals[3] ) == 1 ) {
			
			yield return StartCoroutine (func_04f0());
		} // end if
		
		locals[4] = 13;
		if ( contains( 2, PlayerTypedAnswer, locals[4] ) == 1 ) {
			
			yield return StartCoroutine (func_054f());
		} // end if
		
		locals[5] = 14;
		if ( contains( 2, PlayerTypedAnswer, locals[5] ) == 1 ) {
			
			yield return StartCoroutine (func_054f());
		} // end if
		
		yield return StartCoroutine (say( locals, 015 ));
		locals[6] = 16;
		locals[7] = 0;
		//locals[27] = babl_menu( 0, locals[6] );
		yield return StartCoroutine (babl_menu(0,locals,6));
		locals[27]=PlayerAnswer;
		if ( locals[27] == 1 ) {
			
		} // end if
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( 21 );
		yield break;
	} // end func
	
	IEnumerator func_0436() {
		int[] locals = new int[1];
		yield return StartCoroutine (say( locals, 017 ));
		privateVariables[2] = 0;
	} // end func
	
	IEnumerator func_0446() {
		
		//int locals[22];
		int [] locals = new int[23];
		
		yield return StartCoroutine (say( locals, 018 ));
		locals[1] = 19;
		locals[2] = 20;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine (babl_menu(0,locals,1));
		locals[22]=PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( 21 );
			yield break;

		case 2:
			
			yield return StartCoroutine (func_039e());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0491() {
		
		//int locals[22];
		int [] locals = new int[23];
		
		yield return StartCoroutine (say( locals, 021 ));
		locals[1] = 22;
		locals[2] = 23;
		locals[3] = 24;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine (babl_menu(0,locals,1));
		locals[22]=PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( 21 );
			yield break;

		case 2:
			
			yield return StartCoroutine (func_0446());
			break;
			
		case 3:
			
			yield return StartCoroutine (func_039e());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_04f0() {
		
		//int locals[22];
		int [] locals = new int[23];
		
		yield return StartCoroutine (say( locals, 025 ));
		locals[1] = 26;
		locals[2] = 27;
		locals[3] = 28;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine (babl_menu(0,locals,1));
		locals[22]=PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( 21 );
			yield break ;

		case 2:
			
			yield return StartCoroutine (func_054f());
			break;
			
		case 3:
			
			yield return StartCoroutine (func_039e());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_054f() {
		
		yield return StartCoroutine (func_05b2());
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( 21 );
		yield break;
	} // end func
	
	IEnumerator func_055e() {
		
		//int locals[23];
		int [] locals = new int[24];
		
		npc.npc_attitude = 3;
		yield return StartCoroutine (say( locals, 029 ));
		locals[1] = 30;
		locals[2] = 31;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine (babl_menu(0,locals,1));
		locals[22]=PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			locals[23] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_05b2() {
		
		//int locals[22];
		int [] locals = new int[23];
		
		if ( func_0020() == 0 ) {
			
		} else {
			
			yield return StartCoroutine (say( locals, 032 ));
			locals[1] = 33;
			locals[2] = 34;
			locals[3] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine (babl_menu(0,locals,1));
			locals[22]=PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine (func_0602());
				break;
				
			case 2:
				yield break;

			} // end if
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0602() {
		
		//int locals[44];
		int [] locals = new int[45];
		
		setup_to_barter( 0 );
		while ( privateVariables[1]==0 ) {
			
			locals[1] = 35;
			locals[2] = 36;
			locals[3] = 37;
			locals[4] = 38;
			locals[5] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine (babl_menu(0,locals,1));
			locals[22]=PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine (func_06b3());
				break;
				
			case 2:
				
				yield return StartCoroutine (func_06f5());
				break;
				
			case 3:
				
				yield return StartCoroutine (do_judgement( 0 ));
				break;
				
			case 4:
				
				do_decline( 0 );
				privateVariables[1] = 1;
				break;
				
			} // end switch
			
		} // while
		
		locals[23] = 39;
		locals[24] = 0;
		//locals[44] = babl_menu( 0, locals[23] );
		yield return StartCoroutine (babl_menu(0,locals,23));
		locals[44]=PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_06b3() {
		
		//int locals[5];
		int [] locals = new int[6];
		
		locals[1] = 40;
		locals[2] = 41;
		locals[3] = 42;
		locals[4] = 43;
		locals[5] = 44;
		//if ( do_offer( 5, locals[5], locals[4], locals[3], locals[2], locals[1] ) ) {
		yield return StartCoroutine (do_offer( 5, locals[5], locals[4], locals[3], locals[2], locals[1], 0,0) );
		if (PlayerAnswer==1)	{	
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_06f5() {
		
		//int locals[24];
		int [] locals = new int[25];
		
		yield return StartCoroutine (say( locals, 045 ));
		locals[1] = 46;
		locals[2] = 47;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine (babl_menu(0,locals,1));
		locals[22]=PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			//return;
			yield break;
			
		} // end switch
		
		locals[23] = 48;
		locals[24] = 49;
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
