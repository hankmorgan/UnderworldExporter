using UnityEngine;
using System.Collections;

public class Conversation_18 : Conversation {
	
	//conversation #18
	//	string block 0x0e12, name Lakshi Longtooth
	
	
	public override IEnumerator main() {
		SetupConversation (3602);
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
		
		//int locals[24];
		int [] locals = new int[25];
		
		if ( npc.npc_goal == 11 ) {
			
			npc.npc_goal = 7;
		} // end if
		locals[2] = 32;
		locals[1] = get_quest( 1, locals[2] );
		
		if ( privateVariables[0] == 1) {
			
			if ( locals[1] > 1 ) {
				
				yield return StartCoroutine(say( locals, 001 ));
			} else {
				
				yield return StartCoroutine(say( locals, 002 ));
			} // end if
			
		} else {
			
			if ( locals[1] > 1 ) {
				
				if ( play_drawn == 1 ) {
					
					yield return StartCoroutine(say( locals, 003 ));
					npc.npc_attitude = 1;
				} else {
					
					yield return StartCoroutine(say( locals, 004 ));
				} // end if
				
			} else {
				
				yield return StartCoroutine(say( locals, 005 ));
			} // end if
			
		} // end if
		
		locals[3] = 6;
		locals[4] = 7;
		locals[5] = 8;
		locals[6] = 0;
		//locals[24] = babl_menu( 0, locals[3] );
		yield return StartCoroutine(babl_menu (0,locals,3));
		locals[24] = PlayerAnswer;
		switch ( locals[24] ) {
			
		case 1:
			
			yield return StartCoroutine(func_034b());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_034b());
			break;
			
		case 3:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();//Endconvo
			yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_034b() {
		int[] locals = new int[1];
		yield return StartCoroutine(say( locals, 009 ));
		yield return StartCoroutine(func_0358());
	} // end func
	
	IEnumerator func_0358() {
		
		//int locals[31];
		int[] locals = new int[32];
		
		while ( true ) {//?
			
			locals[2] = 10;
			locals[3] = 11;
			locals[4] = 0;
			//locals[23] = babl_menu( 0, locals[2] );
			yield return StartCoroutine(babl_menu (0,locals,2));
			locals[23] = PlayerAnswer;
			switch ( locals[23] ) {
				
			case 1:
				
				break;
				
			case 2:
				
				yield return StartCoroutine(func_0479());
				break;
				
			} // end switch
			
			//locals[1] = babl_ask( 0 );
			yield return StartCoroutine( babl_ask( 0 ));
			//say( locals, 012 );
			yield return StartCoroutine(say( locals, 012 ));
			locals[24] = 13;
			locals[25] = 14; 
			//;  // expr. has value on stack!
			if ( (contains( 2, PlayerTypedAnswer, locals[24] ) == 1) || (contains( 2, PlayerTypedAnswer, locals[25] )== 1 ) ) {
				
				yield return StartCoroutine(say( locals, 015 ));
			} else {
				
				locals[26] = 16;
				if ( contains( 2, PlayerTypedAnswer, locals[26] )== 1 ) {
					
					yield return StartCoroutine(say( locals, 017 ));
				} else {
					
					locals[27] = 18;
					locals[28] = 19;
					//;  // expr. has value on stack!
					if ( (contains( 2, PlayerTypedAnswer, locals[27] )== 1) || (contains( 2, PlayerTypedAnswer, locals[28] ) == 1)  ) {
						
						yield return StartCoroutine(say( locals, 020 ));
					} else {
						
						locals[29] = 21;
						if ( contains( 2, PlayerTypedAnswer, locals[29] )== 1 ) {
							
							yield return StartCoroutine(say( locals, 022 ));
						} else {
							
							locals[30] = 23;
							locals[31] = 24;
							//;  // expr. has value on stack!
							if  ( (contains( 2, PlayerTypedAnswer, locals[30] )== 1 ) || (contains( 2, PlayerTypedAnswer, locals[31] )== 1 ) ) {
								
								yield return StartCoroutine(say( locals, 025 ));
							} else {
								
								if ( length( 1, PlayerTypedAnswer ) == 0 ) {
									
									yield return StartCoroutine(say( locals, 026 ));
								} else {
									
									yield return StartCoroutine(say( locals, 027 ));
								} // end if
								
							} // end if
							
						} // end if
						
					} // end if
					
				} // end if
				
			} // end if
			
		} // while
		
	} // end func
	
	IEnumerator func_0479() {
		int[] locals = new int[1];
		yield return StartCoroutine(say( locals, 028 ));
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00e0();//endconvo
		yield break;
	} // end func
	
	IEnumerator func_0486() {
		//This function is not called!
		//int locals[10];
		int[] locals = new int[11];
		
		locals[8] = 1;
		locals[9] = 1;
		while ( locals[8] <= 6 ) {
			
			//if ( privateVariables[2][0] == 0 ) {
			if ( privateVariables[2] == 0 ) {
				locals[0] = locals[8];
				locals[9] = locals[9] + 1;
			} // end if
			
			locals[8] = locals[8] + 1;
		} // while
		
		if ( locals[9] == 0 ) {
			
			yield return StartCoroutine(say( locals, 029 ));
			locals[8] = 1;
		} // end if
		
		if ( locals[8] <= 6 ) {
			
			//privateVariables[2][0] = 0;
			privateVariables[2] = 0;
		} else {
			
		} // end if
		
		
		locals[9] = locals[0];
		locals[8] = random( 1, locals[9] );
		//privateVariables[2][0] = 1;
		privateVariables[2] = 1;
		locals[10] = locals[9];
		if ( 1 == locals[10] ) {
			
			yield return StartCoroutine(say( locals, 030 ));
		} else {
			
			if ( 2 == locals[10] ) {
				
				yield return StartCoroutine(say( locals, 031 ));
			} else {
				
				if ( 3 == locals[10] ) {
					
					yield return StartCoroutine(say( locals, 032 ));
				} else {
					
					if ( 4 == locals[10] ) {
						
						yield return StartCoroutine(say( locals, 033 ));
					} else {
						
						if ( 5 == locals[10] ) {
							
							yield return StartCoroutine(say( locals, 034 ));
						} else {
							
							if ( 6 == locals[10] ) {
								
								yield return StartCoroutine(say( locals, 035 ));
							} // end if
							
						} // end if
						
					} // end if
					
				} // end if
				
			} // end if
			
		} // end if
		
	} // end func
	
	IEnumerator func_0563() {
		
		//int locals[23];
		int[] locals = new int[24];
		
		yield return StartCoroutine(say( locals, 036 ));
		locals[1] = 37;
		locals[2] = 38;
		locals[3] = 39;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_008b();//Endconvo
			yield break;
			break;
			
		case 2:
			
			break;
			
		case 3:
			
			yield return StartCoroutine(func_05cb());
			break;
			
		} // end switch
		
		yield return StartCoroutine(say( locals, 040 ));
		locals[23] = 1;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[23] );//Endconvo
		yield break;
	} // end func
	
	IEnumerator func_05cb() {
		
		//int locals[1];
		int [] locals = new int[2];
		
		if ( play_level + play_drawn > npc.npc_level + 5 ) {
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_0063();//Endconvo
			yield break;
		} // end if
		
		if ( play_level + play_drawn < npc.npc_level - 1 ) {
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_008b();//Endconvo
			yield break;
		} // end if
		
		locals[1] = 1;			
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );//end convo
		yield break;
	} // end func
	
}
