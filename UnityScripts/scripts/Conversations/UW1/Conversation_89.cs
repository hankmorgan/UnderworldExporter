using UnityEngine;
using System.Collections;

public class Conversation_89 : Conversation {
	
	//	conversation #89
	//	string block 0x0e59, name Hewstone
	
	public override IEnumerator main() {
		SetupConversation (3673);
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
		
		npc.npc_attitude = param1;//[0]play_hunger;
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
		
		//int locals[134];
		int[] locals = new int[135];
		
		if ( privateVariables[0] == 1 ) {
			
			if ( privateVariables[5] == 1 ) {
				yield return StartCoroutine(say( locals, 022 ));
				locals[112] = 23;
				locals[113] = 24;
				locals[114] = 0;
				//locals[133] = babl_menu( 0, locals[112] );
				yield return StartCoroutine( babl_menu( 0,locals,112 ));
				locals[133] = PlayerAnswer;
				switch ( locals[133] ) {
					
				case 1:
					
					break;
					
				case 2:
					
					yield return StartCoroutine(say( locals, 025 ));
					locals[134] = 1;
					Time.timeScale =SlomoTime;
					yield return new WaitForSeconds(WaitTime);
					func_00b1( locals[134] );
					yield break;
					
				} // end switch
				
				privateVariables[5] = 0;
				yield return StartCoroutine(say( locals, 026 ));
				goto label_0316;
			} else {
				
				yield return StartCoroutine(say( locals, 001 ));
			}
		}
		else {
			
			privateVariables[2] = 1;
			privateVariables[3] = 1;
			privateVariables[4] = 1;
			yield return StartCoroutine(say( locals, 002 ));
			locals[2] = 3;
			locals[3] = 4;
			locals[4] = 0;
			//locals[23] = babl_menu( 0, locals[2] );
			yield return StartCoroutine( babl_menu( 0,locals,2 ));
			locals[23] = PlayerAnswer;
			switch ( locals[23] ) {
				
			case 1:
				
				break;
				
			case 2:
				
				yield return StartCoroutine(say( locals, 005 ));
				privateVariables[5] = 1;
				locals[24] = 1;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[24] );
				yield break;

			} // end switch
			
			yield return StartCoroutine(say( locals, 006 ));
		}	
	label_0316:;
		
		locals[25] = 7;
		locals[26] = 8;
		locals[27] = 9;
		locals[28] = 0;
		//locals[46] = babl_menu( 0, locals[25] );
		yield return StartCoroutine( babl_menu( 0,locals,25 ));
		locals[46] = PlayerAnswer;
		switch ( locals[46] ) {
			
		case 1:
			
			goto label_0367;

		case 2:
			
			goto label_03b0;
		case 3:
			
			goto label_03ba;
			
		} // end switch
		
	label_0367:;
		
		
		privateVariables[2] = 0;
		yield return StartCoroutine(say( locals, 010 ));
		locals[47] = 11;
		locals[48] = 12;
		locals[49] = 0;
		//locals[68] = babl_menu( 0, locals[47] );
		yield return StartCoroutine( babl_menu( 0,locals,47 ));
		locals[68] = PlayerAnswer;
		switch ( locals[68] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			break;
			
		} // end switch
		
		yield return StartCoroutine(say( locals, 013 ));
		yield return StartCoroutine(say( locals, 014 ));
		goto label_03c4;
		
	label_03b0:;
		
		privateVariables[3] = 0;
		yield return StartCoroutine(say( locals, 015 ));
		goto label_03c4;
		
	label_03ba:;
		
		privateVariables[4] = 0;
		yield return StartCoroutine(say( locals, 016 ));
		//} // end if
		
	label_03c4:;
		
		//locals[1] = (((privateVariables[2]!=1) || (privateVariables[3]!=1)) || (privateVariables[4]!=1));
		if (((privateVariables[2]!=1) || (privateVariables[3]!=1)) || (privateVariables[4]!=1)==true)
		{
			locals[1]=1;
		}
		else
		{
			locals[1]=0;
		}
		locals[90] = privateVariables[2];
		locals[69] = 17;
		locals[91] = privateVariables[3];
		locals[70] = 18;
		locals[92] = privateVariables[4];
		locals[71] = 19;
		locals[93] = locals[1];
		locals[72] = 20;
		locals[94] = 1;
		locals[73] = 21;
		locals[74] = 0;
		//locals[111] = babl_fmenu( 0, locals[69], locals[90] );
		yield return StartCoroutine(babl_fmenu (0,locals,69,90));
		locals[111] = PlayerAnswer;
		switch ( locals[111] ) {
			
		case 17:
			
			goto label_0367;

			
		case 18:
			
			goto label_03b0;

			
		case 19:
			
			goto label_03ba;

			
		case 20:
			
			goto label_04d1;
	
			
		case 21:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
		} // end switch
		
		
		
	label_04d1:;
		
		yield return StartCoroutine(say( locals, 027 ));
		yield return StartCoroutine (func_04de());
		yield return StartCoroutine(say( locals, 028 ));
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00e0();
		yield break;
	} // end func
	
	
	IEnumerator func_04de() {
		
		//int locals[44];
		int[] locals = new int[45];
		
		setup_to_barter( 0 );
		while ( privateVariables[1] ==0 ) {
			
			locals[1] = 29;
			locals[2] = 30;
			locals[3] = 31;
			locals[4] = 32;
			locals[5] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine( babl_menu( 0,locals,1 ));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine (func_058f());
				break;
				
			case 2:
				
				yield return StartCoroutine (func_05e9());
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
		
		locals[23] = 33;
		locals[24] = 0;
		//locals[44] = babl_menu( 0, locals[23] );
		yield return StartCoroutine( babl_menu( 0,locals,23));
		locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_058f() {
		
		//int locals[15];
		int[] locals = new int[16];
		
		locals[0] = -1;
		locals[6] = -1;
		locals[11] = 34;
		locals[12] = 35;
		locals[13] = 36;
		locals[14] = 37;
		locals[15] = 38;
		//if ( do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ) ) {
		yield return StartCoroutine (do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ));
		if (PlayerAnswer==1){
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_05e9() {
		
		//int locals[24];
		int[] locals = new int[25];
		
		yield return StartCoroutine(say( locals, 039 ));
		locals[1] = 40;
		locals[2] = 41;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine( babl_menu( 0,locals,1 ));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			yield break;
			//return;

		} // end switch
		
		locals[23] = 42;
		locals[24] = 43;
		//if ( do_demand( 2, locals[24], locals[23] ) ) {
		yield return StartCoroutine (do_demand( 2, locals[24], locals[23] ));
		if (PlayerAnswer==1){
			
			privateVariables[1] = 1;
		} else {
			
			func_008b();
		} // end if
		
	} // end func
	
	
	
}
