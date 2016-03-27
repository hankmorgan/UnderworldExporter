using UnityEngine;
using System.Collections;

public class Conversation_211 : Conversation {
	
	//conversation #211
	//string block 0x0ed3, name Dantes
	
	public override IEnumerator main() {
		SetupConversation (3795);
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
	
	void func_00b1() {
		
		npc.npc_attitude = param1[0]play_hunger;
		func_0012();
	} // end func
	*/
	void func_00c2() {
		
		npc.npc_attitude = 2;
		func_0012();
	} // end func
	/*
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
		
		int[] locals = new int[23];
		
		if ( privateVariables[0] == 1 ) {
			
			yield return StartCoroutine(func_0420());
		} else {
			
			privateVariables[2] = 1;
			privateVariables[3] = 1;
			yield return StartCoroutine(say( locals, 001 ));
			locals[1] = 2;
			locals[2] = 3;
			locals[3] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_050d());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_037c());
				break;
			} // end if
			
			
			
		} // end switch
		
	} // end func
	
	IEnumerator func_02fb() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 004 ));
		locals[1] = 5;
		locals[2] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		if ( locals[22] == 1 ) {
			
			yield return StartCoroutine(func_032f());
		} // end if
		
	} // end func
	
	IEnumerator func_032f() {
		
		int[] locals = new int[23];
		
		privateVariables[3] = 0;
		yield return StartCoroutine(say( locals, 006 ));
		locals[1] = 7;
		locals[2] = 8;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_037c());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_06d2());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_037c() {
		
		int[] locals = new int[44];
		
		yield return StartCoroutine(say( locals, 009 ));
		locals[22] = privateVariables[2];
		locals[1] = 10;
		locals[23] = 1;
		locals[2] = 11;
		locals[3] = 0;
		//locals[43] = babl_fmenu( 0, locals[1], locals[22] );
		yield return StartCoroutine (babl_fmenu(0,locals,1,22)); locals[43]=PlayerAnswer;
		switch ( locals[43] ) {
			
		case 10:
			
			yield return StartCoroutine(func_060d());
			break;
			
		case 11:
			
			yield return StartCoroutine(func_03d8());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03d8() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 012 ));
		locals[1] = 13;
		locals[2] = 14;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_04b1());
			break;
			
		case 2:
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0420() {
		
		int[] locals = new int[26];
		
		if ( privateVariables[2]==1 ) {
			
			yield return StartCoroutine(say( locals, 015 ));
			locals[2] = 16;
			locals[3] = 17;
			locals[4] = 0;
			yield return StartCoroutine(babl_menu (0,locals,2));   locals[23] = PlayerAnswer;
			switch ( locals[23] ) {
				
			case 1:
				
				yield return StartCoroutine(func_060d());
				break;
				
			case 2:
				
				Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
				break;
			} // end if
			
		} //else {
		
		//break;
		
		//} // end switch
		locals[23]=3;
		locals[1] = random( 1, locals[24] );
		
		locals[25] = locals[1];
		if ( 1 == locals[25] ) {
			
			yield return StartCoroutine(say( locals, 018 ));
		} else {
			
			if ( 2 == locals[25] ) {
				
				yield return StartCoroutine(say( locals, 019 ));
			} else {
				
				if ( 3 == locals[25] ) {
					
					yield return StartCoroutine(say( locals, 020 ));
				} // end if
				
			} // end if
			
		} // end if
		
		Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
	} // end func
	
	IEnumerator func_04b1() {
		
		int[] locals = new int[44];
		
		yield return StartCoroutine(say( locals, 021 ));
		locals[22] = privateVariables[3];
		locals[1] = 22;
		locals[23] = 1;
		locals[2] = 23;
		locals[3] = 0;
		yield return StartCoroutine (babl_fmenu(0,locals,1,22)); locals[43]=PlayerAnswer;
		switch ( locals[43] ) {
			
		case 22:
			
			yield return StartCoroutine(func_032f());
			break;
			
		case 23:
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_050d() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 024 ));
		locals[1] = 25;
		locals[2] = 26;
		locals[3] = 27;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_071a());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0569());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_05b1());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0569() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 028 ));
		locals[1] = 29;
		locals[2] = 30;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_07f3());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_05b1());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_05b1() {
		
		int[] locals = new int[44];
		
		yield return StartCoroutine(say( locals, 031 ));
		locals[22] = privateVariables[3];
		locals[1] = 32;
		locals[23] = 1;
		locals[2] = 33;
		locals[3] = 0;
		yield return StartCoroutine (babl_fmenu(0,locals,1,22)); locals[43]=PlayerAnswer;
		switch ( locals[43] ) {
			
		case 32:
			
			yield return StartCoroutine(func_032f());
			break;
			
		case 33:
			
			yield return StartCoroutine(func_037c());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_060d() {
		
		int[] locals = new int[23];
		
		privateVariables[2] = 0;
		yield return StartCoroutine(say( locals, 034 ));
		locals[1] = 35;
		locals[2] = 36;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_065a());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_065a());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_065a() {
		
		int[] locals = new int[44];
		
		yield return StartCoroutine(say( locals, 037 ));
		locals[22] = 1;
		locals[1] = 38;
		locals[23] = privateVariables[3];
		locals[2] = 39;
		locals[24] = 1;
		locals[3] = 40;
		locals[4] = 0;
		yield return StartCoroutine (babl_fmenu(0,locals,1,22)); locals[43]=PlayerAnswer;
		switch ( locals[43] ) {
			
		case 38:
			
			yield return StartCoroutine(func_03d8());
			break;
			
		case 39:
			
			yield return StartCoroutine(func_032f());
			break;
			
		case 40:
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_06d2() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 041 ));
		locals[1] = 42;
		locals[2] = 43;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00c2();yield break;
			break;
			
		case 2:
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_071a() {
		
		int[] locals = new int[41];
		
		//locals[16] = show_inv( 2, locals[6], locals[1] );
		locals[16] = show_inv (2,locals,6,1);
		locals[18] = 0;
		int counter=0;
		while ( locals[16] != 0 ) {
			
			locals[17] = locals[1+counter];
			if ( (locals[17] == 176) || (locals[17] == 177) || (locals[17] == 178) || (locals[17] == 179) || (locals[17] == 180) || (locals[17] == 181) || (locals[17] == 182) ) {
				
				locals[18] = locals[18] + 1;
				locals[11+counter] = locals[6+counter];
			} // end if
			counter++;
			locals[16] = locals[16] - 1;
		} // while
		
		if ( locals[18] > 0 ) {
			give_to_npc(2,locals,11,locals[18]);
			//give_to_npc( 2, locals[11], locals[18] );
			yield return StartCoroutine(func_02fb());
		} else {
			
			yield return StartCoroutine(say( locals, 044 ));
			locals[19] = 45;
			locals[20] = 46;
			locals[21] = 0;
			//locals[40] = babl_menu( 0, locals[19] );
			yield return StartCoroutine(babl_menu (0,locals,19));   locals[40] = PlayerAnswer;
			switch ( locals[40] ) {
				
			case 1:
				
				yield return StartCoroutine(func_071a());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_05b1());
				break;
			} // end if
			
			//break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_07f3() {
		
		int[] locals = new int[41];
		locals[16] = show_inv(2,locals,6,1);
		//locals[16] = show_inv( 2, locals[6], locals[1] );
		locals[18] = 0;
		int counter=0;
		while ( locals[16] != 0 ) {
			
			locals[17] = locals[1+counter];
			if ( locals[17] == 189 ) {
				
				locals[18] = locals[18] + 1;
				locals[11+counter] = locals[6+counter];
			} // end if
			counter++;
			locals[16] = locals[16] - 1;
		} // while
		
		if ( locals[18] >= 1 ) {//Dantes was thirsy. This used to be >1
			give_to_npc(2,locals,11,locals[18]);
			//give_to_npc( 2, locals[11], locals[18] );
			yield return StartCoroutine(func_02fb());
		} else {
			
			yield return StartCoroutine(say( locals, 047 ));
			locals[19] = 48;
			locals[20] = 49;
			locals[21] = 0;
			//locals[40] = babl_menu( 0, locals[19] );
			yield return StartCoroutine(babl_menu (0,locals,19));   locals[40] = PlayerAnswer;
			switch ( locals[40] ) {
				
			case 1:
				
				yield return StartCoroutine(func_07f3());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_05b1());
				break;
			} // end if
			
			//break;
			
		} // end switch
		
	} // end func
	/*
	void func_08a2() {
		
		int[] locals = new int[45];
		
		setup_to_barter( 0 );
		while ( !privateVariables[1] ) {
			
			locals[1] = 50;
			locals[2] = 51;
			locals[3] = 52;
			locals[4] = 53;
			locals[5] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				func_0953();
				break;
				
			case 2:
				
				func_09ad();
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
		
		locals[23] = 54;
		locals[24] = 0;
		yield return StartCoroutine(babl_menu (0,locals,23));   locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	void func_0953() {
		
		int[] locals = new int[16];
		
		locals[0] = -1;
		locals[6] = -1;
		locals[11] = 55;
		locals[12] = 56;
		locals[13] = 57;
		locals[14] = 58;
		locals[15] = 59;
		if ( do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ) ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	void func_09ad() {
		
		int[] locals = new int[25];
		
		yield return StartCoroutine(say( locals, 060 ));
		locals[1] = 61;
		locals[2] = 62;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			return;
			
			break;
			
		} // end switch
		
		locals[23] = 63;
		locals[24] = 64;
		if ( do_demand( 2, locals[24], locals[23] ) ) {
			
			privateVariables[1] = 1;
		} else {
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
		} // end if
		
	} // end func
*/
}
