using UnityEngine;
using System.Collections;

public class Conversation_20 : Conversation {
	
	
	//	conversation #20
	//	string block 0x0e14, name Gulik
	
	
	public override IEnumerator main() {
		SetupConversation (3604);
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
	
	/*void func_00b1() {
		
		npc.npc_attitude = param1[0]play_hunger;
		func_0012();
	} // end func*/
	
	void func_00c2() {
		
		npc.npc_attitude = 2;
		func_0012();
	} // end func
	
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
		
	} // end func
	*/
	/*void func_0243() {
		
		param1[1] = game_days - param2[1];
		param1[2] = game_mins - param2[2];
		if ( param1[2] < 0 ) {
			
			param1[2] = param1[2] + 1440;
			param1[1] = param1[1] - 1;
		} // end if
		
	} // end func*/
	
	IEnumerator func_029d() {
		
		//int locals[26];
		int[] locals=new int[27];
		locals[2] = 1;
		privateVariables[3] = get_quest( 1, locals[2] );
		
		if ( privateVariables[0] == 1 ) {
			
			yield return StartCoroutine(func_053a());
		} else {
			
			privateVariables[2] = 0;
			locals[3] = 2;
			locals[1] = random( 1, locals[3] );
			locals[4] = locals[1];
			if ( 1 == locals[4] ) {
				
				yield return StartCoroutine(say( locals, 001 ));
			} else {
				
				if ( 2 == locals[4] ) {
					
					yield return StartCoroutine(say( locals, 002 ));
				} // end if
				
			} // end if
			
			locals[5] = 3;
			locals[6] = 4;
			locals[7] = 5;
			locals[8] = 0;
			//locals[26] = babl_menu( 0, locals[5] );
			yield return StartCoroutine(babl_menu (0,locals,5));
			locals[26] = PlayerAnswer;
			switch ( locals[26] ) {
				
			case 1:
				
				privateVariables[2] = 1;
				yield return StartCoroutine(func_0351());
				break;
				
			case 2:
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00c2();
				yield break;
				//	break;
				
			case 3:
				
				yield return StartCoroutine(func_0351());
				break;
			} // end if
			
			//break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0351() {
		
		//int locals[22];
		int[] locals=new int[23];
		
		yield return StartCoroutine(say( locals, 006 ));
		locals[1] = 7;
		locals[2] = 8;
		locals[3] = 9;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_05b8());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_03ad());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_04de());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03ad() {
		
		//int locals[22];
		int[] locals=new int[23];
		yield return StartCoroutine(say( locals, 010 ));
		locals[1] = 11;
		locals[2] = 12;
		locals[3] = 13;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0755());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0755());
			break;
			
		case 3:
			
			if ( privateVariables[3] == 1) {
				
				yield return StartCoroutine(func_06e0());
			} else {
				
				yield return StartCoroutine(func_0412());
			} // end if
			
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0412() {
		
		//int locals[22];
		int[] locals=new int[23];
		yield return StartCoroutine(say( locals, 014 ));
		locals[1] = 15;
		locals[2] = 16;
		locals[3] = 17;
		locals[4] = 18;
		locals[5] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0482());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0614());
			break;
			
		case 3:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_008b();
			yield break;
			//break;
			
		case 4:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00c2();
			yield break;
			//	break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0482() {
		
		//int locals[22];
		int[] locals=new int[23];
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
			
			yield return StartCoroutine(func_0614());
			break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_008b();
			yield break;
			//break;
			
		case 3:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00c2();
			yield break;
			//break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_04de() {
		
		//int locals[22];
		int[] locals=new int[23];
		yield return StartCoroutine(say( locals, 023 ));
		locals[1] = 24;
		locals[2] = 25;
		locals[3] = 26;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_079d());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_07e5());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_082d());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_053a() {
		
		//int locals[22];
		int[] locals=new int[23];
		if ( privateVariables[2] == 1 ) {
			
			yield return StartCoroutine(say( locals, 027 ));
		} else {
			
			yield return StartCoroutine(say( locals, 028 ));
		} // end if
		
		locals[1] = 29;
		locals[2] = 30;
		locals[3] = 31;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_03ad());
			break;
			
		case 2:
			
			if ( privateVariables[4]==1 ) {
				
				yield return StartCoroutine(func_0670());
			} else {
				
				if ( privateVariables[3]==1 ) {
					
					yield return StartCoroutine(func_06e0());
				} else {
					
					yield return StartCoroutine(func_0412());
				} // end if
				
			} // end if
			
			break;
			
		case 3:
			
			yield return StartCoroutine(say( locals, 032 ));
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			//break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_05b8() {
		
		//int locals[22];
		int[] locals=new int[23];
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
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			//break;
			
		case 2:
			
			yield return StartCoroutine(func_04de());
			break;
			
		case 3:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00c2();
			yield break;
			//break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0614() {
		
		//int locals[22];
		int[] locals=new int[23];
		yield return StartCoroutine(say( locals, 037 ));
		locals[1] = 38;
		locals[2] = 39;
		locals[3] = 40;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			//break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			//break;
			
		case 3:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			//break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0670() {
		
		//int locals[22];
		int[] locals=new int[23];
		yield return StartCoroutine(say( locals, 041 ));
		locals[1] = 42;
		locals[2] = 43;
		locals[3] = 44;
		locals[4] = 45;
		locals[5] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			//break;
			
		case 2:
			
			yield return StartCoroutine(func_0351());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_08bd());
			break;
			
		case 4:
			
			yield return StartCoroutine(func_08f1());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_06e0() {
		
		//int locals[22];
		int[] locals=new int[23];
		privateVariables[4] = 1;
		yield return StartCoroutine(say( locals, 046 ));
		locals[1] = 47;
		locals[2] = 48;
		locals[3] = 49;
		locals[4] = 50;
		locals[5] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			//break;
			
		case 2:
			
			yield return StartCoroutine(func_0351());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_08bd());
			break;
			
		case 4:
			
			yield return StartCoroutine(func_08f1());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0755() {
		
		//int locals[22];
		int[] locals=new int[23];
		yield return StartCoroutine(say( locals, 051 ));
		locals[1] = 52;
		locals[2] = 53;
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
			//break;
			
		case 2:
			
			yield return StartCoroutine(func_04de());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_079d() {
		
		//int locals[22];
		int[] locals=new int[23];
		yield return StartCoroutine(say( locals, 054 ));
		locals[1] = 55;
		locals[2] = 56;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_07e5());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0875());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_07e5() {
		
		//int locals[22];
		int[] locals=new int[23];
		yield return StartCoroutine(say( locals, 057 ));
		locals[1] = 58;
		locals[2] = 59;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0875());
			break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			//break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_082d() {
		
		//int locals[22];
		int[] locals=new int[23];
		yield return StartCoroutine(say( locals, 060 ));
		locals[1] = 61;
		locals[2] = 62;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0875());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0614());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0875() {
		
		//int locals[22];
		int[] locals=new int[23];
		yield return StartCoroutine(say( locals, 063 ));
		locals[1] = 64;
		locals[2] = 65;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00c2();
			yield break;
			//break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			//break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_08bd() {
		
		//int locals[22];
		int[] locals=new int[23];
		yield return StartCoroutine(say( locals, 066 ));
		locals[1] = 67;
		locals[2] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		if ( locals[22] == 1 ) {
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
		} // end if
		
	} // end func
	
	IEnumerator func_08f1() {
		
		//int locals[22];
		int[] locals=new int[23];
		yield return StartCoroutine(say( locals, 068 ));
		yield return StartCoroutine(say( locals, 069 ));
		locals[1] = 70;
		locals[2] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		if ( locals[22] == 1 ) {
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
		} // end if
		
	} // end func
	
	IEnumerator func_0928() {
		
		//int locals[44];
		int[] locals=new int[45];
		setup_to_barter( 0 );
		while ( privateVariables[1] != 1 ) {
			
			locals[1] = 71;
			locals[2] = 72;
			locals[3] = 73;
			locals[4] = 74;
			locals[5] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_09d9());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_0a33());
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
		
		locals[23] = 75;
		locals[24] = 0;
		//locals[44] = babl_menu( 0, locals[23] );
		yield return StartCoroutine(babl_menu (0,locals,23));
		locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_09d9() {
		
		//int locals[15];
		int[] locals=new int[16];
		locals[0] = -1;
		locals[6] = -1;
		locals[11] = 76;
		locals[12] = 77;
		locals[13] = 78;
		locals[14] = 79;
		locals[15] = 80;
		yield return StartCoroutine (do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ) );
		///if ( do_offer( 7, locals[15]do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ) , locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ) == 1 ) {
		if (PlayerAnswer==1)	{
			privateVariables[1] = 1;
		} // end if
		yield return 0;
	} // end func
	
	IEnumerator func_0a33() {
		
		//int locals[24];
		int[] locals=new int[25];
		yield return StartCoroutine(say( locals, 081 ));
		locals[1] = 82;
		locals[2] = 83;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			yield return 0;
			
			break;
			
		} // end switch
		
		locals[23] = 84;
		locals[24] = 85;
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
		
	} // end func
	
	
	
	
}