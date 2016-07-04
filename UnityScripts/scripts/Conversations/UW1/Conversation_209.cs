using UnityEngine;
using System.Collections;

public class Conversation_209 : Conversation {
	
	
	//conversation #209
	//string block 0x0ed1, name guard
	
	public override IEnumerator main() {
		SetupConversation (3793);
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
		
		if ( privateVariables[0] == 0 ) {
			
			privateVariables[2] = 0;
			privateVariables[3] = 0;
			privateVariables[4] = 0;
		} // end if
		
		if ( privateVariables[0] == 1 ) {
			
			yield return StartCoroutine(func_03bc());
		} else {
			
			yield return StartCoroutine(func_02ca());
		} // end if
		
	} // end func
	
	IEnumerator func_02ca() {
		
		int[] locals = new int[35];
		
		locals[1] = random( 1, locals[2] );
		locals[2] = 4;
		locals[3] = locals[1];
		if ( 1 == locals[3] ) {
			
			yield return StartCoroutine(say( locals, 001 ));
		} else {
			
			if ( 2 == locals[3] ) {
				
				yield return StartCoroutine(say( locals, 002 ));
			} else {
				
				if ( 3 == locals[3] ) {
					
					yield return StartCoroutine(say( locals, 003 ));
				} else {
					
					if ( 4 == locals[3] ) {
						
						yield return StartCoroutine(say( locals, 004 ));
					} // end if
					
				} // end if
				
			} // end if
			
		} // end if
		
		locals[4] = 5;
		locals[5] = 6;
		locals[6] = 0;
		//locals[25] = babl_menu( 0, locals[4] );
		yield return StartCoroutine(babl_menu (0,locals,4));
		locals[25] = PlayerAnswer;
		switch ( locals[25] ) {
			
		case 1:
			
			locals[26] = 9;
			locals[27] = 0;
			locals[28] = 6;
			set_race_attitude( 3, locals[28], locals[27], locals[26] );
			locals[29] = 19;
			locals[30] = 4;
			locals[31] = 0;
			gronk_door( 3, locals[31], locals[30], locals[29] );
			locals[32] = 22;
			locals[33] = 5;
			locals[34] = 0;
			gronk_door( 3, locals[34], locals[33], locals[32] );
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
		
		case 2:
			
			yield return StartCoroutine(func_0428());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03bc() {
		
		int[] locals = new int[6];
		
		if ( privateVariables[4] == 1 ) {
			
			yield return StartCoroutine(say( locals, 007 ));
			locals[1] = 9;
			locals[2] = 0;
			locals[3] = 6;
			set_race_attitude( 3, locals[3], locals[2], locals[1] );
			locals[4] = 209;
			locals[5] = 0;
			set_attitude( 2, locals[5], locals[4] );
			yield return StartCoroutine(func_08b4());
		} else {
			
			if ( privateVariables[3] == 1 ) {
				
				yield return StartCoroutine(say( locals, 008 ));
				privateVariables[4] = 1;
				yield return StartCoroutine(func_07e6());
			} else {
				
				yield return StartCoroutine(say( locals, 009 ));
				privateVariables[3] = 1;
				yield return StartCoroutine(func_07e6());
			} // end if
			
		} // end if
		
	} // end func
	
	IEnumerator func_0428() {
		
		int[] locals = new int[119];
		
		locals[13] = 0;
		
	label_0432:;
		
		//locals[11] = show_inv( 2, locals[6], locals[1] );
		locals[11] = show_inv (2,locals,6,1);
		if ( locals[11] > 0 ) {
			int counter=0;
			locals[12] = 1;
			while ( locals[12] <= locals[11] ) {
				
				if ( locals[1+counter] == 300 ) {
					
					yield return StartCoroutine(say( locals, 010 ));
					locals[14] = 19;
					locals[15] = 4;
					locals[16] = 0;
					gronk_door( 3, locals[16], locals[15], locals[14] );
					locals[17] = 22;
					locals[18] = 5;
					locals[19] = 0;
					gronk_door( 3, locals[19], locals[18], locals[17] );
					privateVariables[2] = 1;
					yield return StartCoroutine(func_097d());
				} // end if
				counter++;
				locals[12] = locals[12] + 1;
			} // while
			
			if ( locals[13] > 2 ) {
				
			} else {
				
				yield return StartCoroutine(say( locals, 011 ));
				locals[20] = 12;
				locals[21] = 13;
				locals[22] = 15;
				locals[23] = 0;
				//locals[41] = babl_menu( 0, locals[20] );
				yield return StartCoroutine(babl_menu (0,locals,20));
				locals[41] = PlayerAnswer;
				switch ( locals[41] ) {
					
				case 1:
					
					locals[13] = locals[13] + 1;
					goto label_0432;

				case 2:
					
					yield return StartCoroutine(say( locals, 014 ));
					locals[42] = 9;
					locals[43] = 0;
					locals[44] = 6;
					set_race_attitude( 3, locals[44], locals[43], locals[42] );
					locals[45] = 209;
					locals[46] = 0;
					set_attitude( 2, locals[46], locals[45] );
					locals[47] = 19;
					locals[48] = 4;
					locals[49] = 0;
					gronk_door( 3, locals[49], locals[48], locals[47] );
					locals[50] = 22;
					locals[51] = 5;
					locals[52] = 0;
					gronk_door( 3, locals[52], locals[51], locals[50] );
					Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
					
				case 3:
					
					locals[53] = 9;
					locals[54] = 0;
					locals[55] = 6;
					set_race_attitude( 3, locals[55], locals[54], locals[53] );
					locals[56] = 209;
					locals[57] = 0;
					set_attitude( 2, locals[57], locals[56] );
					locals[58] = 19;
					locals[59] = 4;
					locals[60] = 0;
					gronk_door( 3, locals[60], locals[59], locals[58] );
					locals[61] = 22;
					locals[62] = 5;
					locals[63] = 0;
					gronk_door( 3, locals[63], locals[62], locals[61] );
					Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
				} // end if
				
			} //else {
			
		}	//break;
		else
		{
			//} // end switch
			
			if ( locals[13] > 2 ) {
				yield return StartCoroutine(say( locals, 020 ));
				locals[108] = 9;
				locals[109] = 0;
				locals[110] = 6;
				set_race_attitude( 3, locals[110], locals[109], locals[108] );
				locals[111] = 209;
				locals[112] = 0;
				set_attitude( 2, locals[112], locals[111] );
				locals[113] = 19;
				locals[114] = 4;
				locals[115] = 0;
				gronk_door( 3, locals[115], locals[114], locals[113] );
				locals[116] = 22;
				locals[117] = 5;
				locals[118] = 0;
				gronk_door( 3, locals[118], locals[117], locals[116] );
				Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
			} else {
				
				yield return StartCoroutine(say( locals, 016 ));
				locals[64] = 17;
				locals[65] = 18;
				locals[66] = 19;
				locals[67] = 0;
				//locals[85] = babl_menu( 0, locals[64] );
				yield return StartCoroutine(babl_menu (0,locals,64));
				locals[85] = PlayerAnswer;
				switch ( locals[85] ) {
					
				case 1:
					
					locals[13] = locals[13] + 1;
					goto label_0432;
					
				case 2:
					
					locals[86] = 9;
					locals[87] = 0;
					locals[88] = 6;
					set_race_attitude( 3, locals[88], locals[87], locals[86] );
					locals[89] = 209;
					locals[90] = 0;
					set_attitude( 2, locals[90], locals[89] );
					locals[91] = 19;
					locals[92] = 4;
					locals[93] = 0;
					gronk_door( 3, locals[93], locals[92], locals[91] );
					locals[94] = 22;
					locals[95] = 5;
					locals[96] = 0;
					gronk_door( 3, locals[96], locals[95], locals[94] );
					Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
					
				case 3:
					
					locals[97] = 9;
					locals[98] = 0;
					locals[99] = 6;
					set_race_attitude( 3, locals[99], locals[98], locals[97] );
					locals[100] = 209;
					locals[101] = 0;
					set_attitude( 2, locals[101], locals[100] );
					locals[102] = 19;
					locals[103] = 4;
					locals[104] = 0;
					gronk_door( 3, locals[104], locals[103], locals[102] );
					locals[105] = 22;
					locals[106] = 5;
					locals[107] = 0;
					gronk_door( 3, locals[107], locals[106], locals[105] );
					Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
				} // end if
				
			} // end if
			
			//break;
			
		} // end switch
		
		
	} // end func
	
	IEnumerator func_07e6() {
		
		int[] locals = new int[34];
		
		locals[1] = 21;
		locals[2] = 22;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_08a2());
			break;
			
		case 2:
			
			locals[23] = 9;
			locals[24] = 0;
			locals[25] = 6;
			set_race_attitude( 3, locals[25], locals[24], locals[23] );
			locals[26] = 209;
			locals[27] = 0;
			set_attitude( 2, locals[27], locals[26] );
			locals[28] = 19;
			locals[29] = 4;
			locals[30] = 0;
			gronk_door( 3, locals[30], locals[29], locals[28] );
			locals[31] = 22;
			locals[32] = 5;
			locals[33] = 0;
			gronk_door( 3, locals[33], locals[32], locals[31] );
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;

		} // end switch
		
	} // end func
	
	IEnumerator func_08a2() {
		int[] locals = new int[1];
		yield return StartCoroutine(say( locals, 023 ));
		npc.npc_goal = 7;
		Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
	} // end func
	
	IEnumerator func_08b4() {
		
		int[] locals = new int[23];
		
		locals[1] = 24;
		locals[2] = 25;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_08f9());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_08f9());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_08f9() {
		
		int[] locals = new int[12];
		
		yield return StartCoroutine(say( locals, 026 ));
		locals[1] = 9;
		locals[2] = 0;
		locals[3] = 6;
		set_race_attitude( 3, locals[3], locals[2], locals[1] );
		locals[4] = 209;
		locals[5] = 0;
		set_attitude( 2, locals[5], locals[4] );
		locals[6] = 19;
		locals[7] = 4;
		locals[8] = 0;
		gronk_door( 3, locals[8], locals[7], locals[6] );
		locals[9] = 22;
		locals[10] = 5;
		locals[11] = 0;
		gronk_door( 3, locals[11], locals[10], locals[9] );
		Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
	} // end func
	
	IEnumerator func_097d() {
		
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
	void func_09b3() {
		
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
				
				func_0a64();
				break;
				
			case 2:
				
				func_0abe();
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
	
	void func_0a64() {
		
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
	
	void func_0abe() {
		
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
