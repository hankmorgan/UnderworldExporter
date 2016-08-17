using UnityEngine;
using System.Collections;

public class Conversation_216 : Conversation {
	
	
	//conversation #216
	//	string block 0x0ed8, name guard
	
	public override IEnumerator main() {
		SetupConversation (3800);
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
	*/
	void func_00b1(int param1) {
		
		npc.npc_attitude = param1;//[0]play_hunger;
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
		
		int[] locals = new int[6];
		locals[1] = 50;
		locals[2] = 10001;		
		privateVariables[5] = x_traps( 2, locals[2], locals[1] );
		
		locals[3] = 51;
		locals[4] = 10001;
		privateVariables[7] = x_traps( 2, locals[4], locals[3] );
		
		if ( privateVariables[0] == 0 ) {
			
			privateVariables[2] = 0;
			privateVariables[3] = 0;
			privateVariables[4] = 0;
			privateVariables[6] = 0;
		} // end if
		
		if ( privateVariables[7] ==1) {
			
			yield return StartCoroutine(func_0684());
		} // end if
		
		if ( (privateVariables[0]==1) && (privateVariables[6]==1) ) {
			
			yield return StartCoroutine(func_056f());
		} else {
			
			if ( privateVariables[5] ==1) {
				
				if ( privateVariables[8]==1 ) {
					
					locals[5] = 1;
					yield return StartCoroutine(func_0328( locals[5] ));
				} else {
					
					yield return StartCoroutine(func_0384());
				} // end if
				
			} else {
				
				yield return StartCoroutine(func_066e());
			} // end if
			
		} // end if
		
	} // end func
	
	IEnumerator func_0328(int param1) {
		
		int[] locals = new int[24];
		
		privateVariables[6] = 1;
		//if ( param1[0]play_hunger ) {
		if (param1==1){
			
			yield return StartCoroutine(say( locals, 001 ));
		} // end if
		
		locals[1] = 2;
		locals[2] = 3;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_03ff());
			break;
			
		case 2:
			
			locals[23] = 1;
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0384() {
		
		int[] locals = new int[25];
		
		privateVariables[6] = 1;
		privateVariables[8] = 1;
		yield return StartCoroutine(say( locals, 004 ));
		locals[1] = 5;
		locals[2] = 6;
		locals[3] = 7;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_03ff());
			break;
			
		case 2:
			
			locals[23] = 1;
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;

		case 3:
			
			yield return StartCoroutine(say( locals, 008 ));
			locals[24] = 0;
			func_0328( locals[24] );
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03ff() {
		
		int[] locals = new int[23];
		
		privateVariables[4] = 1;
		yield return StartCoroutine(say( locals, 009 ));
		locals[1] = 10;
		locals[2] = 11;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_044c());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_044c());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_044c() {
		
		int[] locals = new int[62];
		
		locals[14] = 0;
		locals[12] = 0;
		
	label_045b:;
		
		locals[11]= show_inv (2,locals,6,1);
		//locals[11] = show_inv( 2, locals[6], locals[1] );
		if ( locals[11] > 0 ) {
		//	int counter=0;
			locals[13] = 1;
			while ( locals[13] <= locals[11] ) {
				
				//locals[12] = locals[12] + identify_inv( 4, locals[17], locals[15], locals[16], locals[5] );
				locals[12] = locals[12] + identify_inv( 4, locals,1,2, 3, locals[4] );
				locals[16] = 0;
				locals[17] = 0;
				locals[13] = locals[13] + 1;
			} // while
			
			give_to_npc(2,locals,6,locals[11]);
			locals[12]=21;
			//give_to_npc( 2, locals[6], locals[11] );
			if ( locals[12] > 20 ) {
				
				yield return StartCoroutine(func_063c());
			} else {
				
				yield return StartCoroutine(say( locals, 012 ));
				privateVariables[2] = 1;
				locals[18] = 13;
				locals[19] = 14;
				locals[20] = 0;
				//locals[39] = babl_menu( 0, locals[18] );
				yield return StartCoroutine(babl_menu (0,locals,18));   locals[39] = PlayerAnswer;
				switch ( locals[39] ) {
					
				case 1:
					
					goto label_045b;
					
				case 2:
					
					yield return StartCoroutine(func_062f());
					break;
				} // end if
				
			}// else {
			
			//} // end if
			
			
			
		} // end switch
		
		if ( locals[14] > 5 ) {
			
			yield return StartCoroutine(say( locals, 015 ));
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00d1();yield break;
		} else {
			
			yield return StartCoroutine(say( locals, 016 ));
			locals[40] = 17;
			locals[41] = 18;
			locals[42] = 0;
			//locals[61] = babl_menu( 0, locals[40] );
			yield return StartCoroutine(babl_menu (0,locals,40));   locals[61] = PlayerAnswer;
			switch ( locals[61] ) {
				
			case 1:
				
				locals[14] = locals[14] + 1;
				goto label_045b;
				
			case 2:
				
				yield return StartCoroutine(func_062f());
				break;
			} // end if
			
			
			
		} // end switch
		
		//return;
		yield break;
		
	} // end func
	
	IEnumerator func_056f() {
		
		int[] locals = new int[46];
		
		if ( privateVariables[3] == 1 ) {
			
			yield return StartCoroutine(say( locals, 019 ));
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00d1();yield break;
		} else {
			
			if ( privateVariables[4] ==1) {
				
				privateVariables[2] = 1;
				yield return StartCoroutine(say( locals, 020 ));
				locals[1] = 21;
				locals[2] = 22;
				locals[3] = 0;
				yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
				switch ( locals[22] ) {
					
				case 1:
					
					yield return StartCoroutine(func_044c());
					break;
					
				case 2:
					
					yield return StartCoroutine(func_062f());
					break;
				} // end if
				
			} //else {
			
			//	break;
			
			//} // end switch
			
			yield return StartCoroutine(say( locals, 023 ));
			locals[23] = 24;
			locals[24] = 25;
			locals[25] = 26;
			locals[26] = 0;
			yield return StartCoroutine(babl_menu (0,locals,23));   locals[44] = PlayerAnswer;
			switch ( locals[44] ) {
				
			case 1:
				
				yield return StartCoroutine(func_03ff());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_03ff());
				break;
				
			case 3:
				
				locals[45] = 1;
				Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[45] );
				yield break;
			} // end if
			
			
			
		} // end switch
		
	} // end func
	
	IEnumerator func_062f() {
		int[] locals = new int[1];
		yield return StartCoroutine(say( locals, 027 ));
		Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
	} // end func
	
	IEnumerator func_063c() {
		
		int[] locals = new int[4];
		
		yield return StartCoroutine(say( locals, 028 ));
		locals[1] = 21;
		locals[2] = 56;
		locals[3] = 0;
		gronk_door( 3, locals[3], locals[2], locals[1] );
		privateVariables[3] = 1;
		Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00d1();yield break;
	} // end func
	
	IEnumerator func_066e() {
		
		int[] locals = new int[2];
		
		yield return StartCoroutine(say( locals, 029 ));
		locals[1] = 1;
		Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );
		yield break;
	} // end func
	
	IEnumerator func_0684() {
		int[] locals = new int[1];
		yield return StartCoroutine(say( locals, 030 ));
		Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
	} // end func
	/*
	void func_0691() {
		
		int[] locals = new int[45];
		
		setup_to_barter( 0 );
		while ( !privateVariables[1] ) {
			
			locals[1] = 31;
			locals[2] = 32;
			locals[3] = 33;
			locals[4] = 34;
			locals[5] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				func_0742();
				break;
				
			case 2:
				
				func_079c();
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
		
		locals[23] = 35;
		locals[24] = 0;
		yield return StartCoroutine(babl_menu (0,locals,23));   locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	void func_0742() {
		
		int[] locals = new int[16];
		
		locals[0] = -1;
		locals[6] = -1;
		locals[11] = 36;
		locals[12] = 37;
		locals[13] = 38;
		locals[14] = 39;
		locals[15] = 40;
		if ( do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ) ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	void func_079c() {
		
		int[] locals = new int[25];
		
		yield return StartCoroutine(say( locals, 041 ));
		locals[1] = 42;
		locals[2] = 43;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			return;
			
			break;
			
		} // end switch
		
		locals[23] = 44;
		locals[24] = 45;
		if ( do_demand( 2, locals[24], locals[23] ) ) {
			
			privateVariables[1] = 1;
		} else {
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
		} // end if
		
	} // end func

*/
}
