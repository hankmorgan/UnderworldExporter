using UnityEngine;
using System.Collections;

public class Conversation_9 : Conversation {
	
	//conversation #9
	//string block 0x0e09, name Vernix
	//3593
	
	
	public override IEnumerator main() {
		SetupConversation (3593);
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
	
	/*void func_00b1() {
		
		npc.npc_attitude = param1[0];//play_hunger;
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
		
		//int locals[4];
		int[] locals=new int[5];
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
		int[] locals=new int[23];
		if ( npc.npc_talkedto == 1 ) {
			
			yield return StartCoroutine(func_04fd());
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
				
				yield return StartCoroutine(func_0305());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_034d());
				break;
				
			case 3:
				
				yield return StartCoroutine(func_0305());
				break;
			} // end if
			
			//break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0305() {
		
		//int locals[22];
		int[] locals=new int[23];
		yield return StartCoroutine(say( locals, 005 ));
		locals[1] = 6;
		locals[2] = 7;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00d1();
			yield break;
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0405());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_034d() {
		
		//int locals[22];
		int[] locals=new int[23];
		yield return StartCoroutine(say( locals, 008 ));
		locals[1] = 9;
		locals[2] = 10;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_04b6());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0395());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0395() {
		
		//int locals[22];
		int[] locals=new int[23];
		yield return StartCoroutine(say( locals, 011 ));
		locals[1] = 12;
		locals[2] = 13;
		locals[3] = 14;
		locals[4] = 15;
		locals[5] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_04b6());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_04b6());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_04b6());
			break;
			
		case 4:
			
			yield return StartCoroutine(func_0507());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0405() {
		
		//int locals[22];
		int[] locals=new int[23];
		yield return StartCoroutine(say( locals, 016 ));
		locals[1] = 17;
		locals[2] = 18;
		locals[3] = 19;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0395());
			break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00c2();
			yield break;
			break;
			
		case 3:
			
			yield return StartCoroutine(func_04b6());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0461() {
		
		//int locals[3];
		int[] locals=new int[4];
		locals[2] = 4;
		locals[1] = random( 1, locals[2] );
		
		locals[3] = locals[1];
		if ( 1 == locals[3] ) {
			
			yield return StartCoroutine(say( locals, 020 ));
		} else {
			
			if ( 2 == locals[3] ) {
				
				yield return StartCoroutine(say( locals, 021 ));
			} else {
				
				if ( 3 == locals[3] ) {
					
					yield return StartCoroutine(say( locals, 022 ));
				} else {
					
					if ( 4 == locals[3] ) {
						
						yield return StartCoroutine(say( locals, 023 ));
					} // end if
					
				} // end if
				
			} // end if
			
		} // end if
		yield break;
	} // end func
	
	IEnumerator func_04b6() {
		
		//int locals[22];
		int[] locals=new int[23];
		yield return StartCoroutine(func_0461());
		locals[1] = 24;
		locals[2] = 25;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0405());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_06c9());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_04fd() {
		
		yield return StartCoroutine(func_034d());
	} // end func
	
	IEnumerator func_0507() {
		
		//int locals[22];
		int[] locals=new int[23];
		yield return StartCoroutine(say( locals, 026 ));
		locals[1] = 27;
		locals[2] = 28;
		locals[3] = 29;
		locals[4] = 30;
		locals[5] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_04b6());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_04b6());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_04b6());
			break;
			
		case 4:
			
			yield return StartCoroutine(func_0577());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0577() {
		
		//int locals[22];
		int[] locals=new int[23];
		yield return StartCoroutine(say( locals, 031 ));
		yield return StartCoroutine(say( locals, 032 ));
		locals[1] = 33;
		locals[2] = 34;
		locals[3] = 35;
		locals[4] = 36;
		locals[5] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_04b6());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_04b6());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_04b6());
			break;
			
		case 4:
			
			yield return StartCoroutine(func_05ea());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_05ea() {
		
		//int locals[22];
		int[] locals=new int[23];
		yield return StartCoroutine(say( locals, 037 ));
		yield return StartCoroutine(say( locals, 038 ));
		locals[1] = 39;
		locals[2] = 40;
		locals[3] = 41;
		locals[4] = 42;
		locals[5] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_065d());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_04b6());
			break;
			
		case 3:
			
			yield return StartCoroutine( func_04b6());
			break;
			
		case 4:
			
			yield return StartCoroutine(func_04b6());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_065d() {
		
		// int locals[22];
		int[] locals=new int[23];
		yield return StartCoroutine(say( locals, 043 ));
		yield return StartCoroutine(say( locals, 044 ));
		locals[1] = 45;
		locals[2] = 46;
		locals[3] = 47;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_06c9());
			break;
			
		case 2:
			
			yield return StartCoroutine( func_0711());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_06bc());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_06bc() {
		int[] locals = new int[1];
		yield return StartCoroutine(say( locals, 048 ));
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00e0();
		yield break;
	} // end func
	
	IEnumerator func_06c9() {
		
		// int locals[22];
		int[] locals=new int[23];
		yield return StartCoroutine(say( locals, 049 ));
		locals[1] = 50;
		locals[2] = 51;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00d1();
			yield break;
			break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00c2();
			yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0711() {
		
		// int locals[22];
		int[] locals=new int[23];
		yield return StartCoroutine(say( locals, 052 ));
		locals[1] = 53;
		locals[2] = 54;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			//	break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			//	break;
			
		} // end switch
		
	} // end func
	
	
}
