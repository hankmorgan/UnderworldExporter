using UnityEngine;
using System.Collections;

public class Conversation_149 : Conversation {
	
	//conversation #149
	//string block 0x0e95, name Meredith
	//	3733
	
	
	public override IEnumerator main() {
		SetupConversation (3733);
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
		
		//int locals[2];
		int [] locals = new int[3];
		locals[1] = 32;
		privateVariables[3] = get_quest( 1, locals[1] );
		
		locals[2] = privateVariables[3];
		if ( 0 == locals[2] ) {
			
			if ( privateVariables[0] == 1 ) {
				
				yield return StartCoroutine(func_03d2());
			} else {
				
				yield return StartCoroutine(func_0362());
			} // end if
			
		} else {
			
			if ( 1 == locals[2] ) {
				
				yield return StartCoroutine(func_0306());
			} else {
				
				if ( 2 == locals[2] ) {
					
					yield return StartCoroutine(func_054e());
				} else {
					
					if ( 3 == locals[2] ) {
						
						yield return StartCoroutine(func_0687());
					} else {
						
						if ( 4 == locals[2] ) {
							
							yield return StartCoroutine(func_04c3());
						} // end if
						
					} // end if
					
				} // end if
				
			} // end if
			
		} // end if
		
	} // end func
	
	IEnumerator func_0306() {
		
		//int locals[22];
		int[]locals=new int[23];
		
		if ( (npc.npc_whoami == 146 || npc.npc_whoami == 147) ) {
			
			yield return StartCoroutine(say( locals, 001 ));
		} else {
			
			yield return StartCoroutine(say( locals, 002 ));
		} // end if
		
		locals[1] = 3;
		locals[2] = 4;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		
		switch ( locals[22] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();//endconvo
			yield break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();//endconvo
			yield break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0362() {
		
		//int locals[22];
		int[]locals=new int[23];
		
		yield return StartCoroutine(say( locals, 005 ));
		locals[1] = 6;
		locals[2] = 7;
		locals[3] = 8;
		locals[4] = 9;
		locals[5] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_073f());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_07af());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_07f7());
			break;
			
		case 4:
			
			yield return StartCoroutine(func_08cc());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03d2() {
		
		//int locals[46];
		int[]locals=new int[47];
		
		yield return StartCoroutine(say( locals, 010 ));
		if ( privateVariables[2]==1 ) {
			
		} else {
			
			locals[1] = 11;
			locals[2] = 12;
			locals[3] = 13;
			locals[4] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_073f());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_04a2());
				break;
				
			case 3:
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00e0();//Endconvo
				yield break;
			} // end if
			
			
		} // end switch
		
		locals[23] = 14;
		locals[24] = 15;
		locals[25] = 16;
		locals[26] = 0;
		//locals[44] = babl_menu( 0, locals[23] );
		yield return StartCoroutine(babl_menu (0,locals,23));
		locals[44] = PlayerAnswer;
		switch ( locals[44] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();//Endconvo
			yield break;

		case 2:
			
			break;
			
		case 3:
			
			yield return StartCoroutine(func_04a2());
			break;
			
		} // end switch
		
		locals[45] = 32;
		locals[46] = 1;
		set_quest( 2, locals[46], locals[45] );
		privateVariables[2] = 1;
		yield return StartCoroutine(func_0306());
	} // end func
	
	IEnumerator func_04a2() {
		int[] locals = new int[1];
		if ( (npc.npc_whoami == 146 || npc.npc_whoami == 147) ) {
			
			yield return StartCoroutine(say( locals, 017 ));
		} else {
			
			yield return StartCoroutine(say( locals, 018 ));
		} // end if
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00e0();//EndConvo
		yield break;
	} // end func
	
	IEnumerator func_04c3() {
		
		//int locals[25];
		int[]locals=new int[26];
		locals[2] = 19;
		locals[3] = 20;
		locals[1] = sex( 2, locals[3], locals[2] );
		
		yield return StartCoroutine(say( locals, 021 ));
		locals[4] = 22;
		locals[5] = 23;
		locals[6] = 24;
		locals[7] = 0;
		//locals[25] = babl_menu( 0, locals[4] );
		yield return StartCoroutine(babl_menu (0,locals,4));
		locals[25] = PlayerAnswer;
		switch ( locals[25] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();//Endconvo
			yield break;
			
		case 2:
			
			yield return StartCoroutine(func_05aa());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_053c());
			break;
			
		} // end switch
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00e0();//EndConvo
		yield break;
	} // end func
	
	IEnumerator func_053c() {
		int[] locals = new int[1];
		yield return StartCoroutine(say( locals, 025 ));
		yield return StartCoroutine(func_0928());
		yield return StartCoroutine(say( locals, 026 ));
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00e0();//EndConvo
		yield break;
	} // end func
	
	IEnumerator func_054e() {
		
		//int locals[22];
		int[]locals=new int[23];
		
		yield return StartCoroutine(say( locals, 027 ));
		locals[1] = 28;
		locals[2] = 29;
		locals[3] = 30;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_05aa());
			break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();//Endconvo
			yield break;
			
		case 3:
			
			yield return StartCoroutine(func_063c());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_05aa() {
		
		//int locals[23];
		int[]locals=new int[24];
		
		if ( privateVariables[4] == 1) {
			
			yield return StartCoroutine(say( locals, 031 ));
		} else {
			
			yield return StartCoroutine(say( locals, 032 ));
		} // end if
		
		locals[1] = npc.npc_whoami;
		if ( 146 == locals[1] ) {
			
			yield return StartCoroutine(say( locals, 033 ));
		} else {
			
			if ( 147 == locals[1] ) {
				
				yield return StartCoroutine(say( locals, 034 ));
			} else {
				
				if ( 148 == locals[1] ) {
					
					yield return StartCoroutine(say( locals, 035 ));
				} else {
					
					if ( 149 == locals[1] ) {
						
						yield return StartCoroutine(say( locals, 036 ));
					} // end if
					
				} // end if
				
			} // end if
			
		} // end if
		
		privateVariables[4] = 1;
		locals[2] = 37;
		locals[3] = 38;
		locals[4] = 0;
		//locals[23] = babl_menu( 0, locals[2] );
		yield return StartCoroutine(babl_menu (0,locals,2));
		locals[23] = PlayerAnswer;
		switch ( locals[23] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();//Endconvo
			yield break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();//Endconvo
			yield break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_063c() {
		
		//int locals[22];
		int[]locals=new int[23];
		
		yield return StartCoroutine(say( locals, 039 ));
		locals[1] = 40;
		locals[2] = 41;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();//Endconvo
			yield break;
			
		case 2:
			
			break;
			
		} // end switch
		
		yield return StartCoroutine(say( locals, 042 ));
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00e0();//Endconvo
		yield break;
	} // end func
	
	IEnumerator func_0687() {
		
		//int locals[22];
		int[]locals=new int[23];
		
		yield return StartCoroutine(say( locals, 043 ));
		locals[1] = 44;
		locals[2] = 45;
		locals[3] = 46;
		locals[4] = 47;
		locals[5] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_05aa());
			break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();//Endconvo
			yield break;
			
		case 3:
			
			yield return StartCoroutine(func_06f7());
			break;
			
		case 4:
			
			yield return StartCoroutine(func_053c());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_06f7() {
		
		//int locals[22];
		int[]locals=new int[23];
		
		yield return StartCoroutine(say( locals, 048 ));
		locals[1] = 49;
		locals[2] = 50;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();//Endconvo
			yield break;

		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();//Endconvo
			yield break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_073f() {
		
		//int locals[22];
		int[]locals=new int[23];
		
		yield return StartCoroutine(say( locals, 051 ));
		locals[1] = 52;
		locals[2] = 53;
		locals[3] = 54;
		locals[4] = 55;
		locals[5] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_085b());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_07f7());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_085b());
			break;
			
		case 4:
			
			yield return StartCoroutine(func_07f7());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_07af() {
		
		//int locals[22];
		int[]locals=new int[23];
		
		yield return StartCoroutine(say( locals, 056 ));
		locals[1] = 57;
		locals[2] = 58;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();//Endconvo
			yield break;
			
		case 2:
			
			yield return StartCoroutine(func_073f());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_07f7() {
		
		//int locals[24];
		int[]locals=new int[25];
		
		privateVariables[2] = 1;
		yield return StartCoroutine(say( locals, 059 ));
		locals[1] = 60;
		locals[2] = 61;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0868());
			break;
			
		} // end switch
		
		locals[23] = 32;
		locals[24] = 1;
		set_quest( 2, locals[24], locals[23] );
		yield return StartCoroutine(func_0306());
	} // end func
	
	IEnumerator func_085b() {
		int[] locals = new int[1];
		yield return StartCoroutine(say( locals, 062 ));
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00e0();//Endconvo
		yield break;
	} // end func
	
	IEnumerator func_0868() {
		
		//int locals[24];
		int[]locals=new int[25];
		
		yield return StartCoroutine(say( locals, 063 ));
		locals[1] = 64;
		locals[2] = 65;
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
			func_00e0();//Endconvo
			yield break;

		} // end switch
		
		locals[23] = 32;
		locals[24] = 1;
		set_quest( 2, locals[24], locals[23] );
		privateVariables[2] = 1;
		yield return StartCoroutine(func_0306());
	} // end func
	
	IEnumerator func_08cc() {
		
		//int locals[22];
		int[]locals=new int[23];
		
		yield return StartCoroutine(say( locals, 066 ));
		locals[1] = 67;
		locals[2] = 68;
		locals[3] = 69;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_073f());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_07af());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_07f7());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0928() {
		
		//int locals[44];
		int[]locals=new int[45];
		
		setup_to_barter( 0 );
		while ( privateVariables[1] == 0 ) {
			
			locals[1] = 70;
			locals[2] = 71;
			locals[3] = 72;
			locals[4] = 73;
			locals[5] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_09d9());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_0a33());
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
		
		locals[23] = 74;
		locals[24] = 0;
		//locals[44] = babl_menu( 0, locals[23] );
		yield return StartCoroutine(babl_menu (0,locals,23));
		locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_09d9() {
		
		//int locals[15];
		int[]locals=new int[16];
		
		locals[0] = -1;
		locals[6] = -1;
		locals[11] = 75;
		locals[12] = 76;
		locals[13] = 77;
		locals[14] = 78;
		locals[15] = 79;
		//if ( do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ) ) {
		yield return StartCoroutine (do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6],locals[1]) );
		if (PlayerAnswer==1)	{
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_0a33() {
		
		//int locals[24];
		int[]locals=new int[25];
		
		say( locals, 080 );
		locals[1] = 81;
		locals[2] = 82;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			yield break;

		} // end switch
		
		locals[23] = 83;
		locals[24] = 84;
		//if ( do_demand( 2, locals[24], locals[23] ) ) {
		yield return StartCoroutine (do_demand( 2, locals[24], locals[23] ));
		if (PlayerAnswer==1){
			
			privateVariables[1] = 1;
		} else {
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_008b();//EndConvo
			yield break;
		} // end if
		
	} // end func
	
}
