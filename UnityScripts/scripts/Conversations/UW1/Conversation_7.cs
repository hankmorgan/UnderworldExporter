using UnityEngine;
using System.Collections;

public class Conversation_7 : Conversation {
	
	//	conversation #7
	//		string block 0x0e07, name Ketchaval
	
	
	public override IEnumerator main() {
		SetupConversation (3591);
		privateVariables[1] = 0;
		yield return StartCoroutine(func_029d());
		func_0012();
		yield return 0;
	} // end func
	
	void func_0012() {
		EndConversation ();
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
		
		npc.npc_attitude = param1[0]play_hunger;
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
		
		//int locals[23];
		int[] locals=new int[24];
		locals[1] = 3;
		privateVariables[2] = get_quest( 1, locals[1] );
		if ( privateVariables[2] == 0 ) {
			
			yield return StartCoroutine(func_085b());
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			yield break;//convo ends here
		} // end if
		
		if ( privateVariables[6] == 1 ) {
			
			yield return StartCoroutine(func_07ae());
		} else {
			
			privateVariables[6] = 1;
			privateVariables[3] = 1;
			privateVariables[4] = 1;
			privateVariables[5] = 1;
			yield return StartCoroutine(say( locals, 001 ));
			locals[2] = 2;
			locals[3] = 3;
			locals[4] = 0;
			//locals[23] = babl_menu( 0, locals[2] );
			yield return StartCoroutine(babl_menu (0,locals,2));
			locals[23] = PlayerAnswer;
			switch ( locals[23] ) {
				
			case 1:
				
				yield return StartCoroutine(func_0369());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_0321());
				break;
			} // end if
			
			//break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0321() {
		
		//int locals[22];
		int[] locals=new int[23];
		yield return StartCoroutine(say( locals, 004 ));
		locals[1] = 5;
		locals[2] = 6;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0369());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0369());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0369() {
		
		//int locals[22];
		int[] locals=new int[23];
		yield return StartCoroutine(say( locals, 007 ));
		locals[1] = 8;
		locals[2] = 9;
		locals[3] = 10;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_03c5());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_040d());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_0441());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03c5() {
		
		//int locals[22];
		int[] locals=new int[23];
		yield return StartCoroutine(say( locals, 011 ));
		locals[1] = 12;
		locals[2] = 13;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0441());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_040d());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_040d() {
		
		//int locals[22];
		int[] locals=new int[23];
		
		yield return StartCoroutine(say( locals, 014 ));
		locals[1] = 15;
		locals[2] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		if ( locals[22] == 1 ) {
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00d1();
			yield break;
		} // end if
		
	} // end func
	
	IEnumerator func_0441() {
		
		//int locals[22];
		int[] locals=new int[23];
		
		yield return StartCoroutine(say( locals, 016 ));
		locals[1] = 17;
		locals[2] = 18;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0489());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_04d1());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0489() {
		
		//int locals[22];
		int[] locals=new int[23];
		
		yield return StartCoroutine(say( locals, 019 ));
		locals[1] = 20;
		locals[2] = 21;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_05e7());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_066f());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_04d1() {
		
		//int locals[22];
		int[] locals=new int[23];
		
		yield return StartCoroutine(say( locals, 022 ));
		locals[1] = 23;
		locals[2] = 24;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_06e8());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0519());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0519() {
		
		//int locals[43];
		int[] locals=new int[44];
		yield return StartCoroutine(say( locals, 025 ));
		privateVariables[3] = 0;
		locals[22] = privateVariables[5];
		locals[1] = 26;
		locals[23] = 1;
		locals[2] = 27;
		locals[24] = privateVariables[4];
		locals[3] = 28;
		locals[4] = 0;
		//locals[43] = babl_fmenu( 0, locals[1], locals[22] );
		yield return StartCoroutine(babl_fmenu (0,locals,1,22));
		locals[43] = PlayerAnswer;
		switch ( locals[43] ) {
			
		case 26:
			
			yield return StartCoroutine(func_0597());
			break;
			
		case 27:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00c2();
			yield break;
			
		case 28:
			
			yield return StartCoroutine(func_06e8());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0597() {
		
		//int locals[22];
		int[] locals=new int[23];
		
		privateVariables[5] = 0;
		yield return StartCoroutine(say( locals, 029 ));
		locals[1] = 30;
		locals[2] = 31;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0735());
			break;
			
		case 2:
			
			yield return StartCoroutine(say( locals, 032 ));
			yield return StartCoroutine(func_066f());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_05e7() {
		
		//int locals[43];
		int[] locals=new int[44];
		
		yield return StartCoroutine(say( locals, 033 ));
		yield return StartCoroutine(say( locals, 034 ));
		locals[22] = privateVariables[5];
		locals[1] = 35;
		locals[23] = 1;
		locals[2] = 36;
		locals[24] = 1;
		locals[3] = 37;
		locals[4] = 0;
		//locals[43] = babl_fmenu( 0, locals[1], locals[22] );
		yield return StartCoroutine(babl_fmenu (0,locals,1,22));
		locals[43] = PlayerAnswer;
		switch ( locals[43] ) {
			
		case 35:
			
			yield return StartCoroutine(func_0597());
			break;
			
		case 36:
			
			yield return StartCoroutine(func_0662());
			break;
			
		case 37:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;

		} // end switch
		
	} // end func
	
	IEnumerator func_0662() {
		int[] locals = new int[1];
		yield return StartCoroutine(say( locals, 038 ));
		yield return StartCoroutine(func_066f());
	} // end func
	
	IEnumerator func_066f() {
		
		//int locals[43];
		int[] locals=new int[44];
		
		yield return StartCoroutine(say( locals, 039 ));
		locals[22] = privateVariables[3];
		locals[1] = 40;
		locals[23] = privateVariables[4];
		locals[2] = 41;
		locals[24] = 1;
		locals[3] = 42;
		locals[4] = 0;
		//locals[43] = babl_fmenu( 0, locals[1], locals[22] );
		yield return StartCoroutine(babl_fmenu (0,locals,1,22));
		locals[43] = PlayerAnswer;
		switch ( locals[43] ) {
			
		case 40:
			
			yield return StartCoroutine(func_0519());
			break;
			
		case 41:
			
			yield return StartCoroutine(func_06e8());
			break;
			
		case 42:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00c2();
			yield break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_06e8() {
		
		//int locals[22];
		int[] locals=new int[23];
		yield return StartCoroutine(say( locals, 043 ));
		privateVariables[4] = 0;
		locals[1] = 44;
		locals[2] = 45;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0735());
			break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00c2();
			yield break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0735() {
		
		//int locals[43];
		int[] locals=new int[44];
		
		yield return StartCoroutine(say( locals, 046 ));
		locals[22] = 1;
		locals[1] = 47;
		locals[23] = privateVariables[3];
		locals[2] = 48;
		locals[24] = privateVariables[4];
		locals[3] = 49;
		locals[4] = 0;
		//locals[43] = babl_fmenu( 0, locals[1], locals[22] );
		yield return StartCoroutine(babl_fmenu (0,locals,1,22));
		locals[43] = PlayerAnswer;
		switch ( locals[43] ) {
			
		case 47:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			
		case 48:
			
			yield return StartCoroutine(func_0519());
			break;
			
		case 49:
			
			yield return StartCoroutine(func_06e8());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_07ae() {
		
		//int locals[24];
		int[] locals=new int[25];
		if (( privateVariables[3] != 1) && (privateVariables[4] !=1) ){
			
			yield return StartCoroutine(say( locals, 050 ));
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
		} // end if
		
		locals[1] = npc.npc_attitude + 1;
		if ( locals[1] > 3 ) {
			
			locals[1] = 3;
		} // end if
		
		locals[2] = locals[1];
		if ( 1 == locals[2] ) {
			
			yield return StartCoroutine(say( locals, 051 ));
		} else {
			
			if ( 2 == locals[2] ) {
				
				yield return StartCoroutine(say( locals, 052 ));
			} else {
				
				if ( 3 == locals[2] ) {
					
					yield return StartCoroutine(say( locals, 053 ));
				} // end if
				
			} // end if
			
		} // end if
		
		locals[3] = 54;
		locals[4] = 55;
		locals[5] = 56;
		locals[6] = 0;
		//locals[24] = babl_menu( 0, locals[3] );
		yield return StartCoroutine(babl_menu (0,locals,3));
		locals[24] = PlayerAnswer;
		switch ( locals[24] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			
		case 2:
			
			yield return StartCoroutine(func_066f());
			break;
			
		case 3:
			
			yield return StartCoroutine( func_066f());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_085b() {
		
		//int locals[22];
		int[] locals=new int[23];
		
		yield return StartCoroutine(say( locals, 057 ));
		locals[1] = 58;
		locals[2] = 60;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(say( locals, 059 ));
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00c2();
			yield break;

		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00c2();
			yield break;
		
		} // end switch
		
	} // end func
	
	
	
}
