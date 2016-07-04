using UnityEngine;
using System.Collections;

public class Conversation_23 : Conversation {
	
	//conversation #23
	//string block 0x0e17, name Judy
	
	
	public override IEnumerator main() {
		SetupConversation (3607);
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
		
	} // end func*/
	
	IEnumerator func_029d() {
		
		int[] locals = new int[3];
		
		locals[1] = 272;
		locals[2] = 1;
		if ( find_inv( 2, locals[2], locals[1] ) == 1) {
			
			privateVariables[2] = 1;
		} else {
			
			privateVariables[2] = 0;
		} // end if
		
		if ( privateVariables[0] == 1 ) {
			
			yield return StartCoroutine(func_079e());
		} else {
			
			privateVariables[3] = 0;
			privateVariables[4] = 0;
			privateVariables[5] = 0;
			privateVariables[6] = 0;
			yield return StartCoroutine(func_02ea());
		} // end if
		
	} // end func
	
	IEnumerator func_02ea() {
		
		int[] locals = new int[47];
		
		//locals[1] = !privateVariables[3];
		if (privateVariables[3] == 1)
		{
			locals[1]=0;
		}
		else
		{
			locals[1]=1;
		}
		if ( privateVariables[3] == 0 ) {
			
			locals[2] = 1;
			yield return StartCoroutine(print( 1, locals[2] ));
			privateVariables[3] = 1;
		} else {
			
			yield return StartCoroutine(say( locals, 002 ));
		} // end if
		
		locals[24] = 1;
		locals[3] = 3;
		locals[25] = 1;
		locals[4] = 4;
		locals[26] = locals[1];
		locals[5] = 5;
		locals[27] = 1;
		locals[6] = 6;
		locals[7] = 0;
		//locals[45] = babl_fmenu( 0, locals[3], locals[24] );
		yield return StartCoroutine(babl_fmenu (0,locals,3,24));
		locals[45] = PlayerAnswer;
		switch ( locals[45] ) {
			
		case 3:
			
			yield return StartCoroutine(func_03a9());
			break;
			
		case 4:
			
			yield return StartCoroutine(func_0441());
			break;
			
		case 5:
			
			yield return StartCoroutine(func_04f5());
			break;
			
		case 6:
			
			locals[46] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[46] );//endconvo
			yield break;
		
		} // end switch
		
	} // end func
	
	IEnumerator func_03a9() {
		
		int[] locals = new int[46];
		
		//locals[1] = !privateVariables[4];
		if (privateVariables[4]==0)
		{
			locals[1]=1;
		}
		else
		{
			locals[1]=0;
		}
		if ( privateVariables[4] == 0) {
			
			yield return StartCoroutine(say( locals, 007 ));
			privateVariables[4] = 1;
		} else {
			
			yield return StartCoroutine(say( locals, 008 ));
		} // end if
		
		locals[23] = 1;
		locals[2] = 9;
		locals[24] = locals[1];
		locals[3] = 10;
		locals[25] = 1;
		locals[4] = 11;
		locals[5] = 0;
		//locals[44] = babl_fmenu( 0, locals[2], locals[23] );
		yield return StartCoroutine(babl_fmenu (0,locals,2,23));
		locals[44] = PlayerAnswer;
		switch ( locals[44] ) {
			
		case 9:
			
			yield return StartCoroutine(func_0441());
			break;
			
		case 10:
			
			yield return StartCoroutine(func_04f5());
			break;
			
		case 11:
			
			locals[45] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[45] );//endconvo
			yield break;

		} // end switch
		
	} // end func
	
	IEnumerator func_0441() {
		
		int[] locals = new int[46];
		
		//locals[1] = !privateVariables[5];
		if (privateVariables[5]==1)
		{
			locals[1]=0;
		}
		else
		{
			locals[1]=1;
		}
		if ( privateVariables[5] == 0 ) {
			
			yield return StartCoroutine(say( locals, 012 ));
			privateVariables[5] = 1;
		} else {
			
			yield return StartCoroutine(say( locals, 013 ));
		} // end if
		
		locals[23] = 1;
		locals[2] = 14;
		locals[24] = 1;
		locals[3] = 15;
		locals[25] = locals[1];
		locals[4] = 16;
		locals[26] = 1;
		locals[5] = 17;
		locals[6] = 0;
		//locals[44] = babl_fmenu( 0, locals[2], locals[23] );
		yield return StartCoroutine(babl_fmenu (0,locals,2,23));
		locals[44] = PlayerAnswer;
		switch ( locals[44] ) {
			
		case 14:
			
			yield return StartCoroutine(func_071d());
			break;
			
		case 15:
			
			yield return StartCoroutine(func_067f());
			break;
			
		case 16:
			
			yield return StartCoroutine(func_04f5());
			break;
			
		case 17:
			
			locals[45] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[45] );//endconvo
			yield break;
		
		} // end switch
		
	} // end func
	
	IEnumerator func_04f5() {
		
		int[] locals = new int[29];
		locals[2] = 2;
		locals[1] = random( 1, locals[2] );
		
		if ( privateVariables[7] == 0 ) {
			
			locals[3] = locals[1];
			if ( 1 == locals[3] ) {
				
				yield return StartCoroutine(say( locals, 018 ));
			} else {
				
				if ( 2 == locals[3] ) {
					
					yield return StartCoroutine(say( locals, 019 ));
				} else {
					
					if ( 3 == locals[3] ) {
						
						yield return StartCoroutine(say( locals, 020 ));
					} // end if
					
				} // end if
				
			} // end if
			
			locals[4] = 21;
			locals[5] = 22;
			locals[6] = 23;
			locals[7] = 0;
			//locals[25] = babl_menu( 0, locals[4] );
			yield return StartCoroutine(babl_menu (0,locals,4));
			locals[25] = PlayerAnswer;
			switch ( locals[25] ) {
				
			case 1:
				
				yield return StartCoroutine(func_05cb());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_0669());
				break;
				
			case 3:
				
				locals[26] = 2;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[26] );//endconvo
				yield break;
			} // end if
			
		} else {
			
			locals[27] = locals[1];
			if ( 1 == locals[27] ) {
				
				yield return StartCoroutine(say( locals, 024 ));
			} else {
				
				if ( 2 == locals[27] ) {
					
					yield return StartCoroutine(say( locals, 025 ));
				} // end if
				
			} // end if
			
			locals[28] = 1;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[28] );//endconvo		
			yield break;
			
			
		} // end switch
		
		
	} // end func
	
	IEnumerator func_05cb() {
		
		int[] locals = new int[45];
		
		yield return StartCoroutine(say( locals, 026 ));
		locals[22] = 1;
		locals[1] = 27;
		locals[23] = privateVariables[4];
		locals[2] = 28;
		locals[24] = privateVariables[5];
		locals[3] = 29;
		locals[25] = 1;
		locals[4] = 30;
		locals[5] = 0;
		//locals[43] = babl_fmenu( 0, locals[1], locals[22] );
		yield return StartCoroutine(babl_fmenu (0,locals,1,22));
		locals[43] = PlayerAnswer;
		switch ( locals[43] ) {
			
		case 27:
			
			yield return StartCoroutine(func_02ea());
			break;
			
		case 28:
			
			yield return StartCoroutine(func_03a9());
			break;
			
		case 29:
			
			yield return StartCoroutine(func_0441());
			break;
			
		case 30:
			
			locals[44] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[44] );//endconvo
			yield break;

		} // end switch
		
	} // end func
	
	IEnumerator func_0669() {
		
		int[] locals = new int[2];
		
		yield return StartCoroutine(say( locals, 031 ));
		locals[1] = 1;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );//endconvo
		yield break;
	} // end func
	
	IEnumerator func_067f() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 032 ));
		privateVariables[6] = 1;
		locals[1] = 33;
		locals[2] = 34;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_06cc());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_08d3());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_06cc() {
		
		int[] locals = new int[24];
		
		yield return StartCoroutine(say( locals, 035 ));
		locals[1] = 36;
		locals[2] = 37;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_071d());
			break;
			
		case 2:
			
			locals[23] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );//endconvo
			yield break;
	
		} // end switch
		
	} // end func
	
	IEnumerator func_071d() {
		
		int[] locals = new int[45];
		
		yield return StartCoroutine(say( locals, 038 ));
		locals[22] = 1;
		locals[1] = 39;
		locals[23] = privateVariables[2];
		locals[2] = 40;
		locals[24] = 1;
		locals[3] = 41;
		locals[4] = 0;
		//locals[43] = babl_fmenu( 0, locals[1], locals[22] );
		yield return StartCoroutine(babl_fmenu (0,locals,1,22));
		locals[43] = PlayerAnswer;
		switch ( locals[43] ) {
			
		case 39:
			
			yield return StartCoroutine(func_081f());
			break;
			
		case 40:
			
			yield return StartCoroutine(func_0924());
			break;
			
		case 41:
			
			locals[44] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[44] );//endconvo
			yield break;

		} // end switch
		
	} // end func
	
	IEnumerator func_079e() {
		
		int[] locals = new int[45];
		
		yield return StartCoroutine(say( locals, 042 ));
		locals[22] = privateVariables[2];
		locals[1] = 43;
		locals[23] = 1;
		locals[2] = 44;
		locals[24] = 1;
		locals[3] = 45;
		locals[4] = 0;
		//locals[43] = babl_fmenu( 0, locals[1], locals[22] );
		yield return StartCoroutine(babl_fmenu (0,locals,1,22));
		locals[43] = PlayerAnswer;
		switch ( locals[43] ) {
			
		case 43:
			
			yield return StartCoroutine(func_0924());
			break;
			
		case 44:
			
			yield return StartCoroutine(func_0879());
			break;
			
		case 45:
			
			locals[44] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[44] );//endconvo
			yield break;

		} // end switch
		
	} // end func
	
	IEnumerator func_081f() {
		
		int[] locals = new int[25];
		
		yield return StartCoroutine(say( locals, 046 ));
		locals[1] = 47;
		locals[2] = 48;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			locals[23] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );//endconvo
			yield break;

		case 2:
			
			locals[24] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[24] );//endconvo
			yield break;

		} // end switch
		
	} // end func
	
	IEnumerator func_0879() {
		
		int[] locals = new int[25];
		
		yield return StartCoroutine(say( locals, 049 ));
		locals[1] = 50;
		locals[2] = 51;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			locals[23] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );//endconvo
			yield break;

		case 2:
			
			locals[24] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[24] );//endconvo
			yield break;

		} // end switch
		
	} // end func
	
	IEnumerator func_08d3() {
		
		int[] locals = new int[24];
		
		yield return StartCoroutine(say( locals, 052 ));
		locals[1] = 53;
		locals[2] = 54;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			locals[23] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );//endconvo
			yield break;
			
		case 2:
			
			yield return StartCoroutine(func_0879());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0924() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 055 ));
		locals[1] = 56;
		locals[2] = 57;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_09e5());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_096c());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_096c() {
		
		int[] locals = new int[26];
		locals[2] = 58;
		locals[3] = 59;		
		locals[1] = sex( 2, locals[3], locals[2] );
		yield return StartCoroutine(say( locals, 060 ));
		locals[4] = 61;
		locals[5] = 62;
		locals[6] = 0;
		//locals[25] = babl_menu( 0, locals[4] );
		yield return StartCoroutine(babl_menu (0,locals,4));
		locals[25] = PlayerAnswer;
		switch ( locals[25] ) {
			
		case 1:
			
			yield return StartCoroutine(func_09e5());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_09cf());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_09cf() {
		
		int[] locals = new int[2];
		
		yield return StartCoroutine(say( locals, 063 ));
		locals[1] = 1;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );//endconvo
		yield break;
	} // end func
	
	IEnumerator func_09e5() {
		
		int[] locals = new int[32];
		
	label_09ea:;
		locals[3] = 272;
		locals[2] = find_barter( 1, locals[3] );
		
		if ( locals[2] == 0 ) {
			
			yield return StartCoroutine(say( locals, 064 ));
			locals[4] = 65;
			locals[5] = 66;
			locals[6] = 0;
			//locals[25] = babl_menu( 0, locals[4] );
			yield return StartCoroutine(babl_menu (0,locals,4));
			locals[25] = PlayerAnswer;
			switch ( locals[25] ) {
				
			case 1:
				
				goto label_09ea;
				
			case 2:
				
				yield return StartCoroutine(say( locals, 067 ));
				locals[26] = 1;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[26] );//endconvo
				yield break;
			} // end if
			
		} else {
			
			yield return StartCoroutine(say( locals, 068 ));
			locals[27] = 69;
			yield return StartCoroutine(print( 1, locals[27] ));
			locals[28] = -1;
			give_ptr_npc( 2, locals[28], locals[2] -1 );  //minus 1 to adjust for slot
			locals[29] = 226;
			locals[1] = do_inv_create( 1, locals[29] );
			
			locals[30] = 33;
			locals[31] = 8;
			place_object( 3, locals[31], locals[30], locals[1] );
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			yield break;
		} // end switch
		
		
	} // end func
	
}
