using UnityEngine;
using System.Collections;

public class Conversation_112 : Conversation {
	
	//conversation #112
	//tring block 0x0e70, name bandit
	
	
	
	public override IEnumerator main() {
		SetupConversation (3696);
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
		int[] locals = new int[2];
		
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
		npc.npc_goal = 5;//Kill player!
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
		
		//int locals[44];
		int[] locals = new int[45];
		
		if ( npc.npc_attitude >= 2 ) {
			
			yield return StartCoroutine(func_0484());
		} // end if
		else
		{
			
			
			yield return StartCoroutine(say( locals, 001 ));
			locals[1] = 2;
			locals[2] = 3;
			locals[3] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_0330());
				break;
				
			case 2:
				
				
				
				yield return StartCoroutine(say( locals, 004 ));
				locals[23] = 5;
				locals[24] = 6;
				locals[25] = 0;
				//locals[44] = babl_menu( 0, locals[23] );
				yield return StartCoroutine(babl_menu (0,locals,23));
				locals[44] = PlayerAnswer;
				switch ( locals[44] ) {
					
				case 1:
					
					yield return StartCoroutine(func_0330());
					break;
					
				case 2:
					
					break;
					
				} // end switch
				
				yield return StartCoroutine(say( locals, 007 ));
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_008b();
				yield break;
				break;
			}
		} // end switch
	} // end func
	
	IEnumerator func_0330() {
		
		//int locals[45];
		int[] locals = new int[46];
		
		yield return StartCoroutine(say( locals, 008 ));
		locals[1] = 9;
		locals[2] = 11;
		locals[3] = 13;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(say( locals, 010 ));
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_008b();
			yield break;
			break;
			
		case 2:
			
			yield return StartCoroutine(say( locals, 012 ));
			break;
			
		case 3:
			
			yield return StartCoroutine(say( locals, 014 ));
			break;
			
		} // end switch
		
		yield return StartCoroutine(say( locals, 015 ));
		locals[23] = 16;
		locals[24] = 17;
		locals[25] = 18;
		locals[26] = 0;
		//locals[44] = babl_menu( 0, locals[23] );
		yield return StartCoroutine(babl_menu (0,locals,23));
		locals[44] = PlayerAnswer;
		switch ( locals[44] ) {
			
		case 1:
			
			locals[45] = npc.npc_attitude + 1;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[45] );
			yield break;
			break;
			
		case 2:
			
			break;
			
		case 3:
			
			yield return StartCoroutine(say( locals, 019 ));
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_008b();
			yield break;
			break;
			
		} // end switch
		
		if ( npc.npc_attitude < 3 ) {
			
			yield return StartCoroutine(say( locals, 020 ));
			yield return StartCoroutine(func_040c());
		} else {
			
			yield return StartCoroutine(say( locals, 021 ));
			yield return StartCoroutine(func_059a());
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( 21 );
			yield break;
		} // end if
		
	} // end func
	
	IEnumerator func_040c() {
		
		//int locals[26];
		int[] locals = new int[27];
		
		locals[1] = 22;
		locals[2] = 23;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_008b();
			yield break;
			break;
			
		} // end switch
		
		if ( npc.npc_attitude == 1 ) {
			
			locals[23] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
		} // end if
		
		locals[24] = 113;
		locals[25] = 3;
		set_attitude( 2, locals[25], locals[24] );
		locals[26] = 3;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[26] );
		yield break;
	} // end func
	
	IEnumerator func_0484() {
		
		//int locals[50];
		int[] locals = new int[51];
		
		yield return StartCoroutine(say( locals, 024 ));
		locals[1] = 25;
		locals[2] = 26;
		locals[3] = 27;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			locals[23] = npc.npc_attitude - 1;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			break;
			
		case 3:
			
			yield return StartCoroutine(say( locals, 028 ));
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_008b();
			yield break;
			break;
			
		} // end switch
		
		if ( npc.npc_attitude < 3 ) {
			
			yield return StartCoroutine(say( locals, 029 ));
			locals[24] = 30;
			locals[25] = 31;
			locals[26] = 32;
			locals[27] = 33;
			locals[28] = 0;
			//locals[45] = babl_menu( 0, locals[24] );
			yield return StartCoroutine(babl_menu (0,locals,24));
			locals[45] = PlayerAnswer;
			switch ( locals[45] ) {
				
			case 1:
				
				locals[46] = 1;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[46] );
				yield break;
				break;
				
			case 2:
				
				locals[47] = 2;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[47] );
				yield break;
				break;
				
			case 3:
				
				locals[48] = 113;
				locals[49] = 3;
				set_attitude( 2, locals[49], locals[48] );
				locals[50] = 3;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[50] );
				yield break;
				break;
				
			case 4:
				
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_008b();
				yield break;
				break;
			} // end if
			
			
			
		} // end switch
		
		yield return StartCoroutine(say( locals, 034 ));
		yield return StartCoroutine(func_059a());
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( 21 );
		yield break;
	} // end func
	
	IEnumerator func_059a() {
		
		//int locals[44];
		int[] locals = new int[45];
		
		setup_to_barter( 0 );
		while ( privateVariables[1] == 0) {
			
			locals[1] = 35;
			locals[2] = 36;
			locals[3] = 37;
			locals[4] = 38;
			locals[5] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_064b());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_06a5());
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
		
		locals[23] = 39;
		locals[24] = 0;
		//locals[44] = babl_menu( 0, locals[23] );
		yield return StartCoroutine(babl_menu (0,locals,23));
		locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_064b() {
		
		//int locals[15];
		int[] locals = new int[16];
		
		locals[0] = -1;
		locals[6] = -1;
		locals[11] = 40;
		locals[12] = 41;
		locals[13] = 42;
		locals[14] = 43;
		locals[15] = 44;
		//if ( do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ) ) {
		yield return StartCoroutine (do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6],locals[1]) );
		if (PlayerAnswer==1)	{
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_06a5() {
		
		//int locals[24];
		int[] locals = new int[25];
		
		yield return StartCoroutine(say( locals, 045 ));
		locals[1] = 46;
		locals[2] = 47;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			yield break;
			//return;
			
			break;
			
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
