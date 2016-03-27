using UnityEngine;
using System.Collections;

public class Conversation_276 : Conversation {
	//Generic Mountainman
	
	//conversation #276
	//	string block 0x0f14, name
	
	public override IEnumerator main() {
		SetupConversation (3860);
		privateVariables[1] = 0;
		yield return StartCoroutine(func_029d());
		func_0012();
		yield return 0;
	} // end func
	
	void func_0012() {
		EndConversation();
		privateVariables[0] = 1;
	} // end func
	
	int func_0020() {
		
		//int locals[1];
		int[] locals=new int[2];
		
		if ( (((npc.npc_goal == 5 || npc.npc_goal == 6) || npc.npc_goal == 9) && npc.npc_gtarg == 1 || npc.npc_attitude == 0) ) {
			
			locals[1] = 0;
		} else {
			
			locals[1] = 1;
		} // end if
		
		return locals[1];
	} // end func
	
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
	
	/*void func_00c2() {
		
		npc.npc_attitude = 2;
		func_0012();
	} // end func*/
	
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
		
		//int locals[195];
		int[] locals=new int[196];
		locals[1] = 4;
		privateVariables[5] = get_quest( 1, locals[1] );
		
		privateVariables[2] = 1;
		privateVariables[3] = 1;
		privateVariables[4] = 1;
		if ( privateVariables[0] == 1 ) {
			
			yield return StartCoroutine(say( locals, 001 ));
		} else {
			
			yield return StartCoroutine(say( locals, 002 ));
		} // end if
		
		locals[2] = 3;
		locals[3] = 4;
		locals[4] = 5;
		locals[5] = 6;
		locals[6] = 0;
		//locals[23] = babl_menu( 0, locals[2] );
		yield return StartCoroutine(babl_menu (0,locals,2));
		locals[23] = PlayerAnswer;
		
		switch ( locals[23] ) {
			
		case 1:
			
			goto label_0335;
			
			break;
			
		case 2:
			
			goto label_03c7;
			
			break;
			
		case 3:
			
			goto label_04f2;
			
			break;
			
		case 4:
			
			goto label_0584;
			
			break;
			
		} // end switch
		
	label_0335:;
		
		privateVariables[2] = 0;
		yield return StartCoroutine(say( locals, 007 ));
		locals[45] = privateVariables[3];
		locals[24] = 8;
		locals[46] = privateVariables[4];
		locals[25] = 9;
		locals[47] = 1;
		locals[26] = 10;
		locals[48] = 1;
		locals[27] = 11;
		locals[28] = 0;
		//locals[66] = babl_fmenu( 0, locals[24], locals[45] );
		yield return StartCoroutine(babl_fmenu (0,locals,24,45));
		locals[66] = PlayerAnswer;
		
		switch ( locals[66] ) {
			
		case 8:
			
			goto label_03c7;
			
			break;
			
		case 9:
			
			goto label_04f2;
			
			break;
			
		case 10:
			
			goto label_0584;
			
			break;
			
		case 11:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			break;
			
		} // end switch
		
	label_03c7:;
		
		privateVariables[3] = 0;
		if ( privateVariables[5] == 1) {
			
		} else {
			
			yield return StartCoroutine(say( locals, 012 ));
			locals[88] = 1;
			locals[67] = 13;
			locals[89] = privateVariables[2];
			locals[68] = 14;
			locals[90] = privateVariables[4];
			locals[69] = 15;
			locals[91] = 1;
			locals[70] = 16;
			locals[71] = 0;
			//locals[109] = babl_fmenu( 0, locals[67], locals[88] );
			yield return StartCoroutine(babl_fmenu (0,locals,67,88));
			locals[109] = PlayerAnswer;
			switch ( locals[109] ) {
				
			case 13:
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00e0();
				yield break;
				break;
				
			case 14:
				
				goto label_0335;
				
				break;
				
			case 15:
				
				goto label_04f2;
				
				break;
				
			case 16:
				
				goto label_0584;
				
				break;
			} // end if
			
			
			
		} // end switch
		
		npc.npc_attitude = 3;
		yield return StartCoroutine(say( locals, 017 ));
		locals[131] = privateVariables[2];
		locals[110] = 18;
		locals[132] = privateVariables[4];
		locals[111] = 19;
		locals[133] = 1;
		locals[112] = 20;
		locals[134] = 1;
		locals[113] = 21;
		locals[114] = 0;
		//locals[152] = babl_fmenu( 0, locals[110], locals[131] );
		yield return StartCoroutine(babl_fmenu (0,locals,110,131));
		locals[152] = PlayerAnswer;
		switch ( locals[152] ) {
			
		case 18:
			
			goto label_0335;
			
			break;
			
		case 19:
			
			goto label_04f2;
			
			break;
			
		case 20:
			
			goto label_0584;
			
			break;
			
		case 21:
			
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			break;
			
		} // end switch
		
	label_04f2:;
		
		privateVariables[4] = 0;
		yield return StartCoroutine(say( locals, 022 ));
		locals[174] = privateVariables[2];
		locals[153] = 23;
		locals[175] = privateVariables[3];
		locals[154] = 24;
		locals[176] = 1;
		locals[155] = 25;
		locals[177] = 1;
		locals[156] = 26;
		locals[157] = 0;
		//locals[195] = babl_fmenu( 0, locals[153], locals[174] );
		yield return StartCoroutine(babl_fmenu (0,locals,153,174));
		locals[195] = PlayerAnswer;
		switch ( locals[195] ) {
			
		case 23:
			
			goto label_0335;
			
			break;
			
		case 24:
			
			goto label_03c7;
			
			break;
			
		case 25:
			
			goto label_0584;
			
			break;
			
		case 26:
			
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			break;
			
		} // end switch
		
	label_0584:;
		
		yield return StartCoroutine(say( locals, 027 ));
		yield return StartCoroutine(func_066e());
		yield return StartCoroutine(say( locals, 028 ));
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00e0();
		yield break;
	} // end func
	
	/*void func_0591() {
		
		privateVariables[6][1] = 1001;
		privateVariables[6][2] = 1002;
		privateVariables[6][3] = 1003;
		privateVariables[6][4] = 1010;
		privateVariables[6][5] = 1016;
		privateVariables[6][6] = 1000;
		privateVariables[6][7] = -1;
		privateVariables[27][1] = 1019;
		privateVariables[27][2] = 1011;
		privateVariables[27][3] = 291;
		privateVariables[27][4] = 32;
		privateVariables[27][5] = 35;
		privateVariables[27][6] = 38;
		privateVariables[27][7] = 44;
		privateVariables[27][8] = -1;
		set_likes_dislikes( 2, 58, 37 );
	} // end func*/
	
	IEnumerator func_061e() {
		
		//int locals[22];
		int[] locals=new int[23];
		
		if ( func_0020() != 1) {
			
		} else {
			
			yield return StartCoroutine(say( locals, 029 ));
			locals[1] = 30;
			locals[2] = 31;
			locals[3] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_066e());
				break;
				
			case 2:
				yield break;
				//return;
				break;	
			} // end if
			
			
			
		} // end switch
		
	} // end func
	
	IEnumerator func_066e() {
		
		//int locals[44];
		int[] locals=new int[45];
		
		setup_to_barter( 0 );
		while ( privateVariables[1] == 0) {
			
			locals[1] = 32;
			locals[2] = 33;
			locals[3] = 34;
			locals[4] = 35;
			locals[5] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_071f());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_0761());
				break;
				
			case 3:
				
				yield return StartCoroutine(do_judgement( 0 ));
				break;
				
			case 4:
				
				do_decline( 0 );
				privateVariables[1] = 1;
				break;
				
			} // end switch
			
		} // while
		
		locals[23] = 36;
		locals[24] = 0;
		//locals[44] = babl_menu( 0, locals[23] );
		yield return StartCoroutine(babl_menu (0,locals,23));
		locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_071f() {
		
		//int locals[5];
		int[] locals=new int[6];
		
		locals[1] = 37;
		locals[2] = 38;
		locals[3] = 39;
		locals[4] = 40;
		locals[5] = 41;
		//if ( do_offer( 5, locals[5], locals[4], locals[3], locals[2], locals[1] ) ) {
		yield return StartCoroutine (do_offer( 5, locals[5], locals[4], locals[3], locals[2], locals[1], 0, 0));
		if (PlayerAnswer==1){
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_0761() {
		
		//int locals[24];
		int[] locals=new int[25];
		
		yield return StartCoroutine(say( locals, 042 ));
		locals[1] = 43;
		locals[2] = 44;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			yield break;
			
			break;
			
		} // end switch
		
		locals[23] = 45;
		locals[24] = 46;
		//if ( do_demand( 2, locals[24], locals[23] ) ) {
		yield return StartCoroutine (do_demand( 2, locals[24], locals[23] ));
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
