using UnityEngine;
using System.Collections;

public class Conversation_187 : Conversation {
	
	//conversation #187
	//string block 0x0ebb, name Illomo
	
	
	public override IEnumerator main() {
		SetupConversation (3771);
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
		
		npc.npc_attitude = param1;//param1[0]play_hunger;
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
		
		int[] locals = new int[25];
		
		if ( privateVariables[0] ==1) {
			
			if ( privateVariables[4] ==1) {
				
				yield return StartCoroutine(func_0850());
			} else {
				
				yield return StartCoroutine(func_06a0());
			} // end if
			
		} else {
			
			privateVariables[3] = 0;
			privateVariables[2] = 0;
			privateVariables[4] = 0;
			locals[1] = 9;
			locals[2] = 1;
			set_quest( 2, locals[2], locals[1] );
			yield return StartCoroutine(say( locals, 001 ));
			locals[3] = 2;
			locals[4] = 3;
			locals[5] = 4;
			locals[6] = 0;
			//locals[24] = babl_menu( 0, locals[3] );
			yield return StartCoroutine(babl_menu (0,locals,3));   locals[24] = PlayerAnswer;
			switch ( locals[24] ) {
				
			case 1:
				
				yield return StartCoroutine(func_0331());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_05e5());
				break;
				
			case 3:
				
				yield return StartCoroutine(func_05fb());
				break;
			} // end if
			
			
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0331() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 005 ));
		locals[1] = 6;
		locals[2] = 7;
		locals[3] = 8;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_038d());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_03a3());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_05e5());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_038d() {
		
		int[] locals = new int[2];
		
		yield return StartCoroutine(say( locals, 009 ));
		locals[1] = 1;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );
		yield break;
	} // end func
	
	IEnumerator func_03a3() {
		
		int[] locals = new int[24];
		
		yield return StartCoroutine(say( locals, 010 ));
		locals[2] = 11;
		locals[3] = 12;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,2));   locals[23] = PlayerAnswer;
		switch ( locals[23] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0449());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_03eb());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03eb() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 013 ));
		locals[1] = 14;
		locals[2] = 15;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0449());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0433());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0433() {
		
		int[] locals = new int[2];
		
		yield return StartCoroutine(say( locals, 016 ));
		locals[1] = 1;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );
		yield break;
	} // end func
	
	IEnumerator func_0449() {
		
		int[] locals = new int[3];
		
		//locals[1] = babl_ask( 0 );
		yield return StartCoroutine (babl_ask (0));
		locals[2] = 17;
		if ( contains( 2, PlayerTypedAnswer, locals[2] ) == 1) {
			yield return StartCoroutine(func_04ec(PlayerTypedAnswer ));
			//func_04ec( locals[1] );
		} else {
			//func_047a( locals[1] );
			yield return StartCoroutine(func_047a( PlayerTypedAnswer ));
		} // end if
		
	} // end func
	
	IEnumerator func_047a(string param1) {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 018 ));
		locals[1] = 19;
		locals[2] = 20;
		locals[3] = 21;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0449());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_04d6());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_04d6());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_04d6() {
		
		int[] locals = new int[2];
		
		yield return StartCoroutine(say( locals, 022 ));
		locals[1] = 1;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );
		yield break;
	} // end func
	
	IEnumerator func_04ec(string param1) {
		
		int[] locals = new int[24];
		
		privateVariables[3] = 1;
		yield return StartCoroutine(say( locals, 023 ));
		locals[1] = 24;
		locals[2] = 25;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0542());
			break;
			
		case 2:
			
			locals[23] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0542() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 026 ));
		locals[1] = 27;
		locals[2] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		if ( locals[22] == 1 ) {
			
			yield return StartCoroutine(func_0576());
		} // end if
		
	} // end func
	
	IEnumerator func_0576() {
		
		int[] locals = new int[24];
		
		privateVariables[2] = 1;
		yield return StartCoroutine(say( locals, 028 ));
		locals[1] = 29;
		locals[2] = 31;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(say( locals, 030 ));
			locals[23] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			break;
			
		case 2:
			
			yield return StartCoroutine(func_05cf());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_05cf() {
		
		int[] locals = new int[2];
		
		yield return StartCoroutine(say( locals, 032 ));
		locals[1] = 3;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );
		yield break;
	} // end func
	
	IEnumerator func_05e5() {
		
		int[] locals = new int[2];
		
		yield return StartCoroutine(say( locals, 033 ));
		locals[1] = 2;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );
		yield break;
	} // end func
	
	IEnumerator func_05fb() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 034 ));
		locals[1] = 35;
		locals[2] = 36;
		locals[3] = 37;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0331());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_05e5());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_0657());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0657() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 038 ));
		locals[1] = 39;
		locals[2] = 40;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0331());
			break;
			
		case 2:
			
			yield return StartCoroutine(say( locals, 041 ));
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_06a0() {
		
		int[] locals = new int[68];
		
		if ( privateVariables[2] == 1) {
			
			yield return StartCoroutine(say( locals, 042 ));
			locals[1] = 43;
			locals[2] = 44;
			locals[3] = 45;
			locals[4] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_0793());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_07ae());
				break;
				
			case 3:
				
				yield return StartCoroutine(func_07ff());
				break;
			} // end if
			
		}
		
		if ( privateVariables[3] ==1) {
			
			yield return StartCoroutine(say( locals, 046 ));
			locals[23] = 47;
			locals[24] = 48;
			locals[25] = 0;
			yield return StartCoroutine(babl_menu (0,locals,23));   locals[44] = PlayerAnswer;
			switch ( locals[44] ) {
				
			case 1:
				
				yield return StartCoroutine(func_0542());
				break;
				
			case 2:
				
				locals[45] = 2;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[45] );
				yield break;
				break;
			} // end if
			
		} 
		
		yield return StartCoroutine(say( locals, 049 ));
		locals[46] = 50;
		locals[47] = 51;
		locals[48] = 0;
		//locals[67] = babl_menu( 0, locals[46] );
		yield return StartCoroutine(babl_menu (0,locals,46));   locals[67] = PlayerAnswer;
		switch ( locals[67] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0331());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_05e5());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0793() {
		
		int[] locals = new int[2];
		
		privateVariables[4] = 1;
		yield return StartCoroutine(say( locals, 052 ));
		locals[1] = 3;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );
		yield break;
	} // end func
	
	IEnumerator func_07ae() {
		
		int[] locals = new int[24];
		
		yield return StartCoroutine(say( locals, 053 ));
		locals[1] = 54;
		locals[2] = 55;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			locals[23] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			break;
			
		case 2:
			
			yield return StartCoroutine(func_07ff());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_07ff() {
		
		int[] locals = new int[24];
		
		yield return StartCoroutine(say( locals, 056 ));
		locals[1] = 57;
		locals[2] = 58;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			locals[23] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			break;
			
		case 2:
			
			yield return StartCoroutine(func_05cf());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0850() {
		
		int[] locals = new int[2];
		
		yield return StartCoroutine(say( locals, 059 ));
		locals[1] = 3;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );
		yield break;
	} // end func
	/*
	void func_0866() {
		
		int[] locals = new int[45];
		
		setup_to_barter( 0 );
		while ( !privateVariables[1] ) {
			
			locals[1] = 60;
			locals[2] = 61;
			locals[3] = 62;
			locals[4] = 63;
			locals[5] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				func_0917();
				break;
				
			case 2:
				
				func_0971();
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
		
		locals[23] = 64;
		locals[24] = 0;
		yield return StartCoroutine(babl_menu (0,locals,23));   locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	void func_0917() {
		
		int[] locals = new int[16];
		
		locals[0] = -1;
		locals[6] = -1;
		locals[11] = 65;
		locals[12] = 66;
		locals[13] = 67;
		locals[14] = 68;
		locals[15] = 69;
		if ( do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ) ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	void func_0971() {
		
		int[] locals = new int[25];
		
		yield return StartCoroutine(say( locals, 070 ));
		locals[1] = 71;
		locals[2] = 72;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			return;
			
			break;
			
		} // end switch
		
		locals[23] = 73;
		locals[24] = 74;
		if ( do_demand( 2, locals[24], locals[23] ) ) {
			
			privateVariables[1] = 1;
		} else {
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
		} // end if
		
	} // end func

*/
	
	
	
}
