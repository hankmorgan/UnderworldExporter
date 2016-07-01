using UnityEngine;
using System.Collections;

public class Conversation_16 : Conversation {
	
	//conversation #16
	//string block 0x0e10, name Ishtass
	
	public int[] global=new int[3];
	public override IEnumerator	main() {
		SetupConversation (3600);
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
	
	/*void func_008b() {
		
		npc.npc_gtarg = 1;
		npc.npc_goal = 5;
		npc.npc_attitude = 1;
		func_0012();
	} // end func*/
	
	/*void func_00a4() {
		
		npc.npc_attitude = 6;
	} // end func*/
	
	void func_00b1(int param1) {
		
		npc.npc_attitude = param1;//param1[0]global[0];
		func_0012();
	} // end func
	
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
		int [] locals = new int[24];
		
		if ( privateVariables[0] == 0 ) {
			
			global[0] = 0;
			global[1] = 0;
			global[2] = 0;
		} // end if
		
		if ( privateVariables[0] == 1 ) {
			
			yield return StartCoroutine(func_066d());
		} // end if
		else
		{
			yield return StartCoroutine(say( locals, 001 ));
			locals[1] = 2;
			locals[2] = 3;
			locals[3] = 0;
			//		locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_030d());
				break;
				
			case 2:
				
				locals[23] = 3;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[23] );
				yield break;

			} // end switch
		}
	} // end func
	
	IEnumerator func_030d() {
		
		//int locals[22];
		int [] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 004 ));
		locals[1] = 5;
		locals[2] = 6;
		locals[3] = 7;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_036c());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_03de());
			break;
			
		case 3:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( 3 );//was 24?
			yield break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_036c() {
		
		//int locals[22];
		int [] locals = new int[23];
		
		npc.npc_attitude = npc.npc_attitude + 1;
		if ( npc.npc_attitude > 3 ) {
			
			npc.npc_attitude = 3;
		} // end if
		
		yield return StartCoroutine(say( locals, 008 ));
		locals[1] = 9;
		locals[2] = 10;
		locals[3] = 11;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_03de());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_048e());
			break;
			
		case 3:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00c2();
			yield break;

		} // end switch
		
	} // end func
	
	IEnumerator func_03de() {
		
		//int locals[22];
		int [] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 012 ));
		locals[1] = 13;
		locals[2] = 14;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0426());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_048e());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0426() {
		
		//int locals[23];
		int [] locals = new int[24];
		
		yield return StartCoroutine(say( locals, 015 ));
		locals[1] = 16;
		locals[2] = 17;
		locals[3] = 18;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( 3 );//was 24?
			yield break;
		
		case 2:
			
			locals[23] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			
		case 3:
			
			yield return StartCoroutine(func_048e());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_048e() {
		
		//int locals[46];
		int [] locals = new int[47];
		
		if ( npc.npc_attitude < 2 ) {
			
			yield return StartCoroutine(say( locals, 019 ));
			locals[1] = 20;
			locals[2] = 21;
			locals[3] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				locals[23] = 1;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[23] );
				yield break;
			
			case 2:
				
				locals[24] = 2;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[24] );
				yield break;
				
			} // end if
		} // end switch
		
		if ( global[0] == 0 ) {
			
			yield return StartCoroutine(say( locals, 022 ));
		} else {
			
			yield return StartCoroutine(say( locals, 023 ));
		} // end if
		
		locals[25] = 24;
		locals[26] = 25;
		locals[27] = 0;
		//locals[46] = babl_menu( 0, locals[25] );
		yield return StartCoroutine(babl_menu (0,locals,25));
		locals[46] = PlayerAnswer;
		switch ( locals[46] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0540());
			break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( 3 );//was 24?
			yield break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0540() {
		
		//int locals[91];
		int [] locals = new int[92];
		
		global[0] = 1;
		yield return StartCoroutine(say( locals, 026 ));
		locals[1] = 27;
		locals[2] = 28;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( 3 );//was 24?
			yield break;

		} // end switch
		
		yield return StartCoroutine(say( locals, 029 ));
		locals[23] = 30;
		locals[24] = 31;
		locals[25] = 32;
		locals[26] = 0;
		//locals[44] = babl_menu( 0, locals[23] );
		yield return StartCoroutine(babl_menu (0,locals,23));
		locals[44] = PlayerAnswer;
		switch ( locals[44] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			locals[45] = 1;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[45] );
			yield break;
			
		case 3:
			
			locals[46] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[46] );
			yield break;
			
		} // end switch
		
		yield return StartCoroutine(say( locals, 033 ));
		locals[47] = 34;
		locals[48] = 35;
		locals[49] = 0;
		//locals[68] = babl_menu( 0, locals[47] );
		yield return StartCoroutine(babl_menu (0,locals,47));
		locals[68] = PlayerAnswer;
		switch ( locals[68] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( 3 );//was 24?
			yield break;
			
		case 2:
			
			break;
			
		} // end switch
		
		yield return StartCoroutine(say( locals, 036 ));
		global[1] = 1;
		locals[69] = 37;
		locals[70] = 0;
		//locals[90] = babl_menu( 0, locals[69] );
		yield return StartCoroutine(babl_menu (0,locals,69));
		locals[90] = PlayerAnswer;
		if ( locals[90] == 1 ) {
			
			locals[91] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[91] );
			yield break;
		} // end if
		
	} // end func
	
	IEnumerator func_066d() {
		
		//int locals[69];
		int [] locals = new int[70];
		
		if ( (npc.npc_attitude >= 2) && (global[1] == 0) ) {
			
			locals[1] = 1;
		} else {
			
			if ( npc.npc_attitude == 1 ) {
				
				locals[3] = 1;
			} else {
				
				locals[3] = 0;
			} // end if
			
			locals[1] = 0;
		} // end if
		
		if ( global[1] == 1 && global[2] == 0 ) {
			
			locals[2] = 1;
		} else {
			
			locals[2] = 0;
		} // end if
		
		locals[4] = npc.npc_attitude;
		if ( 1 == locals[4] ) {
			
			yield return StartCoroutine(say( locals, 038 ));
		} else {
			
			if ( 2 == locals[4] ) {
				
				yield return StartCoroutine(say( locals, 039 ));
			} else {
				
				if ( 3 == locals[4] ) {
					
					yield return StartCoroutine(say( locals, 040 ));
				} // end if
				
			} // end if
			
		} // end if
		
		locals[26] = 1;
		locals[5] = 41;
		locals[27] = locals[3];
		locals[6] = 42;
		locals[28] = locals[2];
		locals[7] = 43;
		locals[29] = locals[1];
		locals[8] = 44;
		locals[30] = global[2];
		locals[9] = 45;
		locals[10] = 0;
		//locals[47] = babl_fmenu( 0, locals[5], locals[26] );
		yield return StartCoroutine(babl_fmenu (0,locals,5,26));
		locals[47] = PlayerAnswer;
		switch ( locals[47] ) {
			
		case 41:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( 1 );//was 24?
			yield break;

		case 42:
			
			break;
			
		case 43:
			
			yield return StartCoroutine(func_07e1());
			yield break;

		case 44:
			
			yield return StartCoroutine(func_048e());
			yield break;

		case 45:
			
			yield return StartCoroutine(func_09ba());
			yield break;

		} // end switch
		
		yield return StartCoroutine(say( locals, 046 ));
		locals[48] = 47;
		locals[49] = 48;
		locals[50] = 0;
		//locals[69] = babl_menu( 0, locals[48] );
		yield return StartCoroutine(babl_menu (0,locals,48));
		locals[69] = PlayerAnswer;
		switch ( locals[69] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( 1 );//was 24?
			yield break;
			
		case 2:
			npc.npc_attitude = 2;
			yield return StartCoroutine(say( locals, 049 ));
			yield return StartCoroutine(func_048e());
			yield break;
			
		} // end switch
		
		
	} // end func
	
	IEnumerator func_07e1() {
		
		//int locals[111];
		int [] locals = new int[112];
		
		yield return StartCoroutine(say( locals, 050 ));
		locals[14] = 51;
		locals[15] = 52;
		locals[16] = 0;
		//locals[35] = babl_menu( 0, locals[14] );
		yield return StartCoroutine(babl_menu (0,locals,14));
		locals[35] = PlayerAnswer;
		switch ( locals[35] ) {
			
		case 1:
			
			break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( 3 );//was 24?
			yield break;

		} // end switch
		
	label_0827:;
		
		locals[12] = 0;
		//locals[11] = show_inv( 2, locals[6], locals[1] );
		locals[11] = show_inv( 2, locals,6, 1);
		int counter=0;
		while ( locals[11] != 0 ) {
			
			locals[36] = 0;
			locals[37] = -1;
			locals[38] = -1;
			locals[39] = -1;
			locals[40] = -1;
			locals[41] = -1;
			locals[42] = -1;
			//x_obj_stuff( 9, locals[42], locals[41], locals[40], locals[12], locals[39], locals[38], locals[37], locals[36], locals[5] );
			x_obj_stuff( 10,locals, 42, 41, 40, 12, 39, 38, 37,36,locals[5]);
			if ( locals[12] == 67 ) {
				
				locals[43] = -1;
				give_ptr_npc( 2, locals[43], locals[6]+counter );
				locals[11] = 0;
			} else {
				
				locals[11] = locals[11] - 1;
			} // end if
			counter++;//To the inventory slot
		} // while
		
		if ( locals[12] != 67 ) {
			
			yield return StartCoroutine(say( locals, 053 ));
			locals[44] = 54;
			locals[45] = 55;
			locals[46] = 0;
			//locals[65] = babl_menu( 0, locals[44] );
			yield return StartCoroutine(babl_menu (0,locals,44));
			locals[65] = PlayerAnswer;
			switch ( locals[65] ) {
				
			case 1:
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( 3 ); //was 24?
				yield break;
				
			case 2:
				
				goto label_0827;

			} // end if
			
		} else {
			
			yield return StartCoroutine(say( locals, 056 ));
			locals[66] = 57;
			locals[67] = 0;
			//locals[87] = babl_menu( 0, locals[66] );
			yield return StartCoroutine(babl_menu (0,locals,66));
			locals[87] = PlayerAnswer;
			if ( locals[87] == 1 ) {
				
			} // end if
			
			yield return StartCoroutine(say( locals, 058 ));
			locals[88] = 1;
			locals[13] = take_from_npc( 1, locals[88] );
			
			if ( locals[13] > 0 ) {
				
				if ( take_id_from_npc( 1, locals[13] ) == 2 ) {
					
					yield return StartCoroutine(say( locals, 059 ));
				} // end if
				
			} // end if
			
			global[2] = 1;
			locals[89] = 60;
			locals[90] = 61;
			locals[91] = 0;
			//locals[110] = babl_menu( 0, locals[89] );
			yield return StartCoroutine(babl_menu (0,locals,89));
			locals[110] = PlayerAnswer;
			switch ( locals[110] ) {
				
			case 1:
				
				locals[111] = 3;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[111] );
				yield break;

			case 2:
				
				yield return StartCoroutine(func_09ba());
				break;
				
			} // end switch
		} // end switch
	} // end func
	
	IEnumerator func_09ba() {
		
		//int locals[45];
		int [] locals = new int[46];
		
		yield return StartCoroutine(say( locals, 062 ));
		locals[2] = 63;
		locals[3] = 64;
		locals[4] = 0;
		//locals[23] = babl_menu( 0, locals[2] );
		yield return StartCoroutine(babl_menu (0,locals,2));
		locals[23] = PlayerAnswer;
		switch ( locals[23] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( 3 );//was 24?
			yield break;

		case 2:
			
			break;
			
		} // end switch
		
		yield return StartCoroutine(say( locals, 065 ));
		locals[24] = 66;
		locals[25] = 67;
		locals[26] = 0;
		//locals[45] = babl_menu( 0, locals[24] );
		yield return StartCoroutine(babl_menu (0,locals,24));
		locals[45] = PlayerAnswer;
		switch ( locals[45] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;

		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;

			
		} // end switch
		
	} // end func
}
