using UnityEngine;
using System.Collections;

public class Conversation_222 : Conversation {
	
	
	//conversation #222
	//	string block 0x0ede, name guard
	
	
	public override IEnumerator main() {
		SetupConversation (3806);
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
		
		//param1[1] = game_days;
		//param1[2] = game_mins;
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
		
		if ( privateVariables[0] == 0 ) {
			
			privateVariables[2] = 0;
			privateVariables[3] = 0;
			privateVariables[4] = 0;
		} // end if
		
		if ( privateVariables[0] == 1 ) {
			
			yield return StartCoroutine(func_0332());
		} else {
			
			yield return StartCoroutine(func_02ca());
		} // end if
		
	} // end func
	
	IEnumerator func_02ca() {
		
		int[] locals = new int[26];
		
		yield return StartCoroutine(say( locals, 001 ));
		locals[1] = 2;
		locals[2] = 3;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			locals[23] = 9;
			locals[24] = 0;
			locals[25] = 6;
			set_race_attitude( 3, locals[25], locals[24], locals[23] );
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
			break;
			
		case 2:
			
			yield return StartCoroutine(func_03a6());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0332() {
		
		int[] locals = new int[6];
		
		if ( privateVariables[4] == 1 ) {
			
			yield return StartCoroutine(say( locals, 004 ));
			locals[1] = 9;
			locals[2] = 0;
			locals[3] = 6;
			set_race_attitude( 3, locals[3], locals[2], locals[1] );
			locals[4] = 222;
			locals[5] = 0;
			set_attitude( 2, locals[5], locals[4] );
			yield return StartCoroutine(func_0695());
		} else {
			
			if ( privateVariables[3] == 1 ) {
				
				yield return StartCoroutine(say( locals, 005 ));
				privateVariables[4] = 1;
				yield return StartCoroutine(func_0607());
			} else {
				
				if ( privateVariables[2] == 1 ) {
					
					yield return StartCoroutine(say( locals, 006 ));
					privateVariables[3] = 1;
					yield return StartCoroutine(func_0607());
				} // end if
				
			} // end if
			
		} // end if
		
	} // end func
	
	IEnumerator func_03a6() {
		
		int[] locals = new int[86];
		
		locals[13] = 0;
	label_03b0:;
		
		
		//locals[11] = show_inv( 2, locals[6], locals[1] );
		locals[11] = show_inv (2,locals,6,1);
		int counter=0;
		if ( locals[11] > 0 ) {
			
			locals[12] = 1;
			while ( locals[12] <= locals[11] ) {
				
				if ( locals[1+counter] == 300 ) {
					
					yield return StartCoroutine(say( locals, 007 ));
					locals[14] = 29;
					locals[15] = 21;
					locals[16] = 0;
					gronk_door( 3, locals[16], locals[15], locals[14] );
					privateVariables[2] = 1;
					yield return StartCoroutine(func_071e());
				} // end if
				counter++;
				locals[12] = locals[12] + 1;
			} // while
			
			if ( locals[13] > 2 ) {
				yield return StartCoroutine(say( locals, 018 ));
				locals[81] = 9;
				locals[82] = 0;
				locals[83] = 6;
				set_race_attitude( 3, locals[83], locals[82], locals[81] );
				locals[84] = 222;
				locals[85] = 0;
				set_attitude( 2, locals[85], locals[84] );
				Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
			} else {
				
				yield return StartCoroutine(say( locals, 008 ));
				locals[17] = 9;
				locals[18] = 10;
				locals[19] = 12;
				locals[20] = 0;
				//locals[38] = babl_menu( 0, locals[17] );
				yield return StartCoroutine (babl_menu (0,locals,17));
				locals[38] = PlayerAnswer;
				switch ( locals[38] ) {
					
				case 1:
					
					locals[13] = locals[13] + 1;
					goto label_03b0;
					
					break;
					
				case 2:
					
					yield return StartCoroutine(say( locals, 011 ));
					locals[39] = 9;
					locals[40] = 0;
					locals[41] = 6;
					set_race_attitude( 3, locals[41], locals[40], locals[39] );
					locals[42] = 222;
					locals[43] = 0;
					set_attitude( 2, locals[43], locals[42] );
					Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
					break;
					
				case 3:
					
					locals[44] = 9;
					locals[45] = 0;
					locals[46] = 6;
					set_race_attitude( 3, locals[46], locals[45], locals[44] );
					locals[47] = 222;
					locals[48] = 0;
					set_attitude( 2, locals[48], locals[47] );
					Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
					break;
				} // end if
				
			} //else {
			
			//break;
			
		} // end switch
		
		if ( locals[13] > 2 ) {
			yield return StartCoroutine(say( locals, 018 ));
			locals[81] = 9;
			locals[82] = 0;
			locals[83] = 6;
			set_race_attitude( 3, locals[83], locals[82], locals[81] );
			locals[84] = 222;
			locals[85] = 0;
			set_attitude( 2, locals[85], locals[84] );
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
		} else {
			
			yield return StartCoroutine(say( locals, 013 ));
			locals[49] = 14;
			locals[50] = 15;
			locals[51] = 17;
			locals[52] = 0;
			//locals[70] = babl_menu( 0, locals[49] );
			yield return StartCoroutine (babl_menu (0,locals,49));
			locals[70] = PlayerAnswer;
			switch ( locals[70] ) {
				
			case 1:
				
				locals[13] = locals[13] + 1;
				goto label_03b0;
				
				break;
				
			case 2:
				
				yield return StartCoroutine(say( locals, 011 ));
				locals[71] = 9;
				locals[72] = 0;
				locals[73] = 6;
				set_race_attitude( 3, locals[73], locals[72], locals[71] );
				locals[74] = 222;
				locals[75] = 0;
				set_attitude( 2, locals[75], locals[74] );
				Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
				break;
				
			case 3:
				
				locals[76] = 9;
				locals[77] = 0;
				locals[78] = 6;
				set_race_attitude( 3, locals[78], locals[77], locals[76] );
				locals[79] = 222;
				locals[80] = 0;
				set_attitude( 2, locals[80], locals[79] );
				Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
				break;
			} // end if
			
		} // end if
		
		
		
		//} // end switch
		
		
	} // end func
	
	IEnumerator func_0607() {
		
		int[] locals = new int[28];
		
		locals[1] = 19;
		locals[2] = 20;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			func_0683();
			break;
			
		case 2:
			
			locals[23] = 9;
			locals[24] = 0;
			locals[25] = 6;
			set_race_attitude( 3, locals[25], locals[24], locals[23] );
			locals[26] = 222;
			locals[27] = 0;
			set_attitude( 2, locals[27], locals[26] );
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0683() {
		int[] locals = new int[1];
		yield return StartCoroutine(say( locals, 021 ));
		npc.npc_goal = 7;
		Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
	} // end func
	
	IEnumerator func_0695() {
		
		int[] locals = new int[23];
		
		locals[1] = 22;
		locals[2] = 23;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			func_06da();
			break;
			
		case 2:
			
			func_06da();
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_06da() {
		
		int[] locals = new int[6];
		
		yield return StartCoroutine(say( locals, 024 ));
		locals[1] = 9;
		locals[2] = 0;
		locals[3] = 6;
		set_race_attitude( 3, locals[3], locals[2], locals[1] );
		locals[4] = 222;
		locals[5] = 0;
		set_attitude( 2, locals[5], locals[4] );
		Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
	} // end func
	
	IEnumerator func_071e() {
		
		int[] locals = new int[23];
		
		locals[1] = 25;
		locals[2] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		if ( locals[22] == 1 ) {
			
			remove_talker( 0 );
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
		} // end if
		
	} // end func
	
	/*void func_0754() {
		
		int[] locals = new int[45];
		
		setup_to_barter( 0 );
		while ( !privateVariables[1] ) {
			
			locals[1] = 26;
			locals[2] = 27;
			locals[3] = 28;
			locals[4] = 29;
			locals[5] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				func_0805();
				break;
				
			case 2:
				
				func_085f();
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
		
		locals[23] = 30;
		locals[24] = 0;
		yield return StartCoroutine(babl_menu (0,locals,23));   locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	void func_0805() {
		
		int[] locals = new int[16];
		
		locals[0] = -1;
		locals[6] = -1;
		locals[11] = 31;
		locals[12] = 32;
		locals[13] = 33;
		locals[14] = 34;
		locals[15] = 35;
		if ( do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ) ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	void func_085f() {
		
		int[] locals = new int[25];
		
		yield return StartCoroutine(say( locals, 036 ));
		locals[1] = 37;
		locals[2] = 38;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			return;
			
			break;
			
		} // end switch
		
		locals[23] = 39;
		locals[24] = 40;
		if ( do_demand( 2, locals[24], locals[23] ) ) {
			
			privateVariables[1] = 1;
		} else {
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
		} // end if
		
	} // end func

*/
	
}
