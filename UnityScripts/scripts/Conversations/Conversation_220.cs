using UnityEngine;
using System.Collections;

public class Conversation_220 : Conversation {
	
	//conversation #220
	//string block 0x0edc, name guard
	
	public override IEnumerator main() {
		SetupConversation (3804);
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
	*/
	void func_008b() {
		
		npc.npc_gtarg = 1;
		npc.npc_goal = 5;
		npc.npc_attitude = 1;
		func_0012();
	} // end func
	/*
	void func_00a4() {
		
		npc.npc_attitude = 6;
	} // end func
	
	void func_00b1() {
		
		npc.npc_attitude = param1[0]play_hunger;
		func_0012();
	} // end func
	
	void func_00c2() {
		
		npc.npc_attitude = 2;
		func_0012();
	} // end func
	
	void func_00d1() {
		
		npc.npc_attitude = 1;
		func_0012();
	} // end func
	*/
	void func_00e0() {
		
		func_0012();
	} // end func
	/*
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
		
		int[] locals = new int[5];
		
		locals[1] = 50;
		locals[2] = 10001;
		privateVariables[5] = x_traps( 2, locals[2], locals[1] );
		locals[3] = 51;
		locals[4] = 10001;
		privateVariables[6] = x_traps( 2, locals[4], locals[3] );
		
		if ( privateVariables[0] == 0 ) {
			
			privateVariables[2] = 0;
			privateVariables[3] = 0;
			privateVariables[4] = 0;
		} // end if
		
		if ( privateVariables[6] ==1) {
			
			yield return StartCoroutine(say( locals, 001 ));
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
		} else {
			
			if ( privateVariables[5]==1) {
				
				yield return StartCoroutine(say( locals, 002 ));
				Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
			} else {
				
				if ( privateVariables[0] == 1 ) {
					
					yield return StartCoroutine(func_03a0());
				} else {
					
					yield return StartCoroutine(func_0318());
				} // end if
				
			} // end if
			
		} // end if
		
	} // end func
	
	IEnumerator func_0318() {
		
		int[] locals = new int[29];
		
		yield return StartCoroutine(say( locals, 003 ));
		locals[1] = 4;
		locals[2] = 5;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			locals[23] = 9;
			locals[24] = 0;
			locals[25] = 6;
			set_race_attitude( 3, locals[25], locals[24], locals[23] );
			locals[26] = 27;
			locals[27] = 54;
			locals[28] = 0;
			gronk_door( 3, locals[28], locals[27], locals[26] );
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
			break;
			
		case 2:
			
			yield return StartCoroutine(func_040c());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03a0() {
		
		int[] locals = new int[6];
		
		if ( privateVariables[4] == 1 ) {
			
			yield return StartCoroutine(say( locals, 006 ));
			locals[1] = 9;
			locals[2] = 0;
			locals[3] = 6;
			set_race_attitude( 3, locals[3], locals[2], locals[1] );
			locals[4] = 220;
			locals[5] = 0;
			set_attitude( 2, locals[5], locals[4] );
			yield return StartCoroutine(func_07bb());
		} else {
			
			if ( privateVariables[3] == 1 ) {
				
				yield return StartCoroutine(say( locals, 007 ));
				privateVariables[4] = 1;
				yield return StartCoroutine(func_070d());
			} else {
				
				yield return StartCoroutine(say( locals, 008 ));
				privateVariables[3] = 1;
				yield return StartCoroutine(func_070d());
			} // end if
			
		} // end if
		
	} // end func
	
	IEnumerator func_040c() {
		
		int[] locals = new int[101];
		
		locals[13] = 0;
	label_0416:;
		
		locals[11]=show_inv (0,locals,6,1);
		int counter=0;
		//locals[11] = show_inv( 2, locals[6], locals[1] );
		if ( locals[11] > 0 ) {
			
			locals[12] = 1;
			while ( locals[12] <= locals[11] ) {
				
				if ( locals[1+counter] == 300 ) {
					
					yield return StartCoroutine(say( locals, 009 ));
					locals[14] = 27;
					locals[15] = 54;
					locals[16] = 0;
					gronk_door( 3, locals[16], locals[15], locals[14] );
					privateVariables[2] = 1;
					yield return StartCoroutine(func_0864());
				} // end if
				
				locals[12] = locals[12] + 1;
			} // while
			
			if ( locals[13] > 2 ) {
				yield return StartCoroutine(say( locals, 020 ));
				locals[93] = 9;
				locals[94] = 0;
				locals[95] = 6;
				set_race_attitude( 3, locals[95], locals[94], locals[93] );
				locals[96] = 220;
				locals[97] = 0;
				set_attitude( 2, locals[97], locals[96] );
				locals[98] = 27;
				locals[99] = 54;
				locals[100] = 0;
				gronk_door( 3, locals[100], locals[99], locals[98] );
				Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
			} else {
				
				yield return StartCoroutine(say( locals, 010 ));
				locals[17] = 11;
				locals[18] = 12;
				locals[19] = 14;
				locals[20] = 0;
				//locals[38] = babl_menu( 0, locals[17] );
				yield return StartCoroutine(babl_menu (0,locals,17));   locals[38] = PlayerAnswer;
				switch ( locals[38] ) {
					
				case 1:
					
					locals[13] = locals[13] + 1;
					goto label_0416;
					
					break;
					
				case 2:
					
					yield return StartCoroutine(say( locals, 013 ));
					locals[39] = 9;
					locals[40] = 0;
					locals[41] = 6;
					set_race_attitude( 3, locals[41], locals[40], locals[39] );
					locals[42] = 220;
					locals[43] = 0;
					set_attitude( 2, locals[43], locals[42] );
					locals[44] = 27;
					locals[45] = 54;
					locals[46] = 0;
					gronk_door( 3, locals[46], locals[45], locals[44] );
					Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
					break;
					
				case 3:
					
					locals[47] = 9;
					locals[48] = 0;
					locals[49] = 6;
					set_race_attitude( 3, locals[49], locals[48], locals[47] );
					locals[50] = 220;
					locals[51] = 0;
					set_attitude( 2, locals[51], locals[50] );
					locals[52] = 27;
					locals[53] = 54;
					locals[54] = 0;
					gronk_door( 3, locals[54], locals[53], locals[52] );
					Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
					break;
				} // end if
				
			} //else {
			
			//break;
			
			//} // end switch
			
			if ( locals[13] > 2 ) {
				yield return StartCoroutine(say( locals, 020 ));
				locals[93] = 9;
				locals[94] = 0;
				locals[95] = 6;
				set_race_attitude( 3, locals[95], locals[94], locals[93] );
				locals[96] = 220;
				locals[97] = 0;
				set_attitude( 2, locals[97], locals[96] );
				locals[98] = 27;
				locals[99] = 54;
				locals[100] = 0;
				gronk_door( 3, locals[100], locals[99], locals[98] );
				Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
			} else {
				
				yield return StartCoroutine(say( locals, 015 ));
				locals[55] = 16;
				locals[56] = 17;
				locals[57] = 19;
				locals[58] = 0;
				//locals[76] = babl_menu( 0, locals[55] );
				yield return StartCoroutine(babl_menu (0,locals,55));   locals[76] = PlayerAnswer;
				switch ( locals[76] ) {
					
				case 1:
					
					locals[13] = locals[13] + 1;
					goto label_0416;
					
					break;
					
				case 2:
					
					yield return StartCoroutine(say( locals, 013 ));
					locals[77] = 9;
					locals[78] = 0;
					locals[79] = 6;
					set_race_attitude( 3, locals[79], locals[78], locals[77] );
					locals[80] = 220;
					locals[81] = 0;
					set_attitude( 2, locals[81], locals[80] );
					locals[82] = 27;
					locals[83] = 54;
					locals[84] = 0;
					gronk_door( 3, locals[84], locals[83], locals[82] );
					Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
					break;
					
				case 3:
					
					locals[85] = 9;
					locals[86] = 0;
					locals[87] = 6;
					set_race_attitude( 3, locals[87], locals[86], locals[85] );
					locals[88] = 220;
					locals[89] = 0;
					set_attitude( 2, locals[89], locals[88] );
					locals[90] = 27;
					locals[91] = 54;
					locals[92] = 0;
					gronk_door( 3, locals[92], locals[91], locals[90] );
					Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
					break;
				} // end if
				
			} // end if
			
			
			
		} // end switch
		
		
	} // end func
	
	IEnumerator func_070d() {
		
		int[] locals = new int[31];
		
		locals[1] = 21;
		locals[2] = 22;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			func_07a9();
			break;
			
		case 2:
			
			locals[23] = 9;
			locals[24] = 0;
			locals[25] = 6;
			set_race_attitude( 3, locals[25], locals[24], locals[23] );
			locals[26] = 220;
			locals[27] = 0;
			set_attitude( 2, locals[27], locals[26] );
			locals[28] = 27;
			locals[29] = 54;
			locals[30] = 0;
			gronk_door( 3, locals[30], locals[29], locals[28] );
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_07a9() {
		int[] locals = new int[1];
		yield return StartCoroutine(say( locals, 023 ));
		npc.npc_goal = 7;
		Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
	} // end func
	
	IEnumerator func_07bb() {
		
		int[] locals = new int[23];
		
		locals[1] = 24;
		locals[2] = 25;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0800());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0800());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0800() {
		
		int[] locals = new int[9];
		
		yield return StartCoroutine(say( locals, 026 ));
		locals[1] = 9;
		locals[2] = 0;
		locals[3] = 6;
		set_race_attitude( 3, locals[3], locals[2], locals[1] );
		locals[4] = 220;
		locals[5] = 0;
		set_attitude( 2, locals[5], locals[4] );
		locals[6] = 27;
		locals[7] = 54;
		locals[8] = 0;
		gronk_door( 3, locals[8], locals[7], locals[6] );
		Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
	} // end func
	
	IEnumerator func_0864() {
		
		int[] locals = new int[23];
		
		locals[1] = 27;
		locals[2] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		if ( locals[22] == 1 ) {
			
			remove_talker( 0 );
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
		} // end if
		
	} // end func
	/*
	void func_089a() {
		
		int[] locals = new int[45];
		
		setup_to_barter( 0 );
		while ( !privateVariables[1] ) {
			
			locals[1] = 28;
			locals[2] = 29;
			locals[3] = 30;
			locals[4] = 31;
			locals[5] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				func_094b();
				break;
				
			case 2:
				
				func_09a5();
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
		
		locals[23] = 32;
		locals[24] = 0;
		yield return StartCoroutine(babl_menu (0,locals,23));   locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	void func_094b() {
		
		int[] locals = new int[16];
		
		locals[0] = -1;
		locals[6] = -1;
		locals[11] = 33;
		locals[12] = 34;
		locals[13] = 35;
		locals[14] = 36;
		locals[15] = 37;
		if ( do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ) ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	void func_09a5() {
		
		int[] locals = new int[25];
		
		yield return StartCoroutine(say( locals, 038 ));
		locals[1] = 39;
		locals[2] = 40;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			return;
			
			break;
			
		} // end switch
		
		locals[23] = 41;
		locals[24] = 42;
		if ( do_demand( 2, locals[24], locals[23] ) ) {
			
			privateVariables[1] = 1;
		} else {
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
		} // end if
		
	} // end func
*/
	
	
}
