using UnityEngine;
using System.Collections;

public class Conversation_12 : Conversation {
	
	//conversation #12
	//string block 0x0e0c, name Dorna Ironfist
	
	
	public override IEnumerator main() {
		SetupConversation (3596);
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
		
		npc.npc_attitude = param1; //param1[0]play_hunger;
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
		
		//int locals[26];
		int [] locals=new int[27];
		locals[2] = 32;
		privateVariables[6] = get_quest( 1, locals[2] );
		locals[3] = 11;
		privateVariables[7] = get_quest( 1, locals[3] );
		
		if ( privateVariables[0] == 0 ) {
			
			yield return StartCoroutine(say( locals, 001 ));
		} // end if
		
		if ( privateVariables[7] == 1 && privateVariables[4] == 0 ) {
			
			if ( privateVariables[5] == 0 ) {
				
				yield return StartCoroutine(func_0ce2());
				yield break;
			} else {
				
				yield return StartCoroutine(func_0d31());
				yield break;
			} // end if
			
		} // end if
		
		locals[4] = privateVariables[6];
		if ( 0 == locals[4] ) {
			if ( privateVariables[0] == 1 ) {
				
				yield return StartCoroutine(func_0395());
			} else {
				
				yield return StartCoroutine(say( locals, 002 ));
				locals[5] = 3;
				locals[6] = 4;
				locals[7] = 5;
				locals[8] = 0;
				//locals[26] = babl_menu( 0, locals[5] );
				yield return StartCoroutine(babl_menu (0,locals,5));
				locals[26] = PlayerAnswer;
				switch ( locals[26] ) {
					
				case 1:
					
					privateVariables[2] = 1;
					yield return StartCoroutine(func_0395());
					break;
					
				case 2:
					
					yield return StartCoroutine(func_085f());
					break;
					
				case 3:
					
					yield return StartCoroutine(func_045b());
					break;
				} // end if
				
				
				
			} // end switch
		} else {
			
			if ( 1 == locals[4] ) {
						yield return StartCoroutine(func_045b());//Added to fix convo ending.
			} else {
				
				if ( 2 == locals[4] ) {
					
					yield return StartCoroutine(func_090f());
					
				} else {
					
					if ( 3 == locals[4] ) {
						
						yield return StartCoroutine(func_0957());
					} else {
						
						if ( 4 == locals[4] ) {
							
							yield return StartCoroutine(func_0f77());
						} // end if
						
					} // end if
					
				} // end if
				
			} // end if
			
		} // end if
		
		
		
	} // end func
	
	IEnumerator func_0395() {
		
		//int locals[22];
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 006 ));
		yield return StartCoroutine(say( locals, 007 ));
		locals[1] = 8;
		locals[2] = 9;
		locals[3] = 10;
		locals[4] = 11;
		locals[5] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_045b());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_063b());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_0ff4());
			break;
			
		case 4:
			
			yield return StartCoroutine(func_103c());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0408() {
		
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
			
			if ( npc.npc_attitude < 2 ) {
				
				npc.npc_attitude = 2;
			} // end if
			
			break;
			
		case 2:
			
			break;
			
		} // end switch
		
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00e0();
		yield break;
	} // end func
	
	IEnumerator func_045b() {
		
		//int locals[29];
		int [] locals = new int[30];
		locals[3] = 15;
		locals[4] = 16;
		locals[1] = sex( 2, locals[4], locals[3] );
		locals[5] = 32;
		locals[2] = get_quest( 1, locals[5] );
		
		if ( locals[2] == 0 ) {
			
			yield return StartCoroutine(func_0408());
			yield break;
		} // end if
		
		locals[6] = 32;
		locals[7] = 0;
		set_quest( 2, locals[7], locals[6] );
		if ( privateVariables[3] == 1 ) {
			
			yield return StartCoroutine(say( locals, 017 ));
		} else {
			
			yield return StartCoroutine(say( locals, 018 ));
		} // end if
		
		yield return StartCoroutine(say( locals, 019 ));
		locals[8] = 20;
		locals[9] = 22;
		locals[10] = 24;
		locals[11] = 0;
		//locals[29] = babl_menu( 0, locals[8] );
		yield return StartCoroutine(babl_menu (0,locals,8));
		locals[29] = PlayerAnswer;
		switch ( locals[29] ) {
			
		case 1:
			
			yield return StartCoroutine(say( locals, 021 ));
			npc.npc_attitude = 1;
			break;
			
		case 2:
			
			yield return StartCoroutine(say( locals, 023 ));//\m was \p
			npc.npc_attitude = 2;
			break;
			
		case 3:
			
			yield return StartCoroutine(func_0520());
			break;
			
		} // end switch
		
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00e0();
		yield break;
	} // end func
	
	IEnumerator func_0520() {
		
		//int locals[22];
		int [] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 025 ));
		locals[1] = 26;
		locals[2] = 27;
		locals[3] = 28;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_057c());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0620());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_0bd2());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_057c() {
		
		//int locals[22];
		int [] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 029 ));
		locals[1] = 30;
		locals[2] = 31;
		locals[3] = 32;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_05d8());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0620());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_0bd2());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_05d8() {
		
		//int locals[22];
		int [] locals =new int[23];
		
		yield return StartCoroutine(say( locals, 033 ));
		locals[1] = 34;
		locals[2] = 35;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_068f());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0620());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0620() {
		
		//int locals[1];
		int [] locals = new int[2];
		
		yield return StartCoroutine(say( locals, 036 ));
		privateVariables[3] = 1;
		locals[1] = 1;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );
		yield break;
	} // end func
	
	IEnumerator func_063b() {
		
		//int locals[22];
		int [] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 037 ));
		locals[1] = 38;
		locals[2] = 39;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			if ( privateVariables[6] == 0 ) {
				
				yield return StartCoroutine(func_0408());
			} else {
				
				yield return StartCoroutine(func_045b());
			} // end if
			
			break;
			
		case 2:
			
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_068f() {
		
		//int locals[23];
		int [] locals =new int[24];
		
		locals[1] = 40;
		yield return StartCoroutine(print( 1, locals[1] ));
		locals[2] = 41;
		locals[3] = 42;
		locals[4] = 0;
		//locals[23] = babl_menu( 0, locals[2] );
		yield return StartCoroutine(babl_menu (0,locals,2));
		locals[23] = PlayerAnswer;
		switch ( locals[23] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0620());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_06e2());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_06e2() {
		
		//int locals[30];
		int [] locals = new int[31];
		locals[4] = 43;
		locals[5] = 44;
		locals[1] = sex( 2, locals[5], locals[4] );
		locals[6] = 45;
		locals[7] = 46;
		locals[2] = sex( 2, locals[7], locals[6] );
		
		locals[8] = 47;
		yield return StartCoroutine(print( 1, locals[8] ));
		yield return StartCoroutine(say( locals, 048 ));
		locals[9] = 49;
		locals[10] = 50;
		locals[11] = 0;
		//locals[30] = babl_menu( 0, locals[9] );
		yield return StartCoroutine(babl_menu (0,locals,9));
		locals[30] = PlayerAnswer;
		switch ( locals[30] ) {
			
		case 1:
			
			yield return StartCoroutine(func_076e());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0620());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_076e() {
		
		//int locals[24];
		int[] locals = new int[25];
		
		privateVariables[3] = 0;
		yield return StartCoroutine(say( locals, 051 ));
		yield return StartCoroutine(say( locals, 052 ));
		locals[1] = 32;
		locals[2] = 2;
		set_quest( 2, locals[2], locals[1] );
		locals[3] = 53;
		locals[4] = 54;
		locals[5] = 0;
		//locals[24] = babl_menu( 0, locals[3] );
		yield return StartCoroutine(babl_menu (0,locals,3));
		locals[24] = PlayerAnswer;
		switch ( locals[24] ) {
			
		case 1:
			
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;

		case 2:
			
			yield return StartCoroutine(func_07d5());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_07d5() {
		
		//int locals[47];
		int [] locals = new int[48];
		
		//locals[1] = !privateVariables[7];
		if (privateVariables[7]==1)
		{
			locals[1]=0;
		}
		else
		{
			locals[1]=1;
		}
		locals[3] = 55;
		locals[4] = 56;
		locals[2] = sex( 2, locals[4], locals[3] );
		
		yield return StartCoroutine(say( locals, 057 ));
		if ( privateVariables[7] == 1) {
			
			yield return StartCoroutine(say( locals, 058 ));
		} else {
			
			yield return StartCoroutine(say( locals, 059 ));
		} // end if
		
		locals[26] = 1;
		locals[5] = 60;
		locals[27] = 1;
		locals[6] = 61;
		locals[7] = 0;
		//locals[47] = babl_fmenu( 0, locals[5], locals[26] );
		yield return StartCoroutine(babl_fmenu (0,locals,5,26));
		locals[47] = PlayerAnswer;
		switch ( locals[47] ) {
			
		case 60:
			
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;

		case 61:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00c2();
			yield break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_085f() {
		
		//int locals[22];
		int [] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 062 ));
		locals[1] = 63;
		locals[2] = 64;
		locals[3] = 65;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_063b());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_08bb());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_103c());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_08bb() {
		
		//int locals[22];
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 066 ));
		locals[1] = 67;
		locals[2] = 68;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			
		case 2:
			
			if ( privateVariables[6] == 0 ) {
				
				yield return StartCoroutine(func_0408());
			} else {
				
				yield return StartCoroutine(func_045b());
			} // end if
			
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_090f() {
		
		//int locals[22];
		int [] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 069 ));
		locals[1] = 70;
		locals[2] = 71;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0b48());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0f2f());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0957() {
		
		//int locals[25];
		int [] locals = new int[26];
		locals[2] = 72;
		locals[3] = 73;
		locals[1] = sex( 2, locals[3], locals[2] );
		
		yield return StartCoroutine(say( locals, 074 ));
		locals[4] = 75;
		locals[5] = 76;
		locals[6] = 0;
		//locals[25] = babl_menu( 0, locals[4] );
		yield return StartCoroutine(babl_menu (0,locals,4));
		locals[25] = PlayerAnswer;
		switch ( locals[25] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0c2e());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0f2f());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_09ba() {
		
		//int locals[26];
		int[] locals = new int[27];
		locals[2] = 77;
		locals[3] = 78;
		locals[1] = sex( 2, locals[3], locals[2] );
		
		yield return StartCoroutine(say( locals, 079 ));
		locals[4] = 46;
		if ( take_from_npc( 1, locals[4] ) == 2 ) {
			
			yield return StartCoroutine(say( locals, 080 ));
		} // end if
		
		locals[5] = 81;
		locals[6] = 82;
		locals[7] = 0;
		//locals[26] = babl_menu( 0, locals[5] );
		yield return StartCoroutine(babl_menu (0,locals,5));
		locals[26] = PlayerAnswer;
		switch ( locals[26] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0eb3());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0eb3());
			break;
			
		} // end switch
		
	} // end func
	
/// <summary>
/// Determines if the correct item has been returned.
/// </summary>
/// <returns>The 0a34.</returns>
/// <param name="param1">Param1.</param>
/// <param name="param2">Param2.</param>
/// <param name="param3">Param3.</param>
	int func_0a34(int param1, int param2, int param3) {
		
		//int locals[25];
		int[] locals = new int[26];
		
		locals[16] = 0;
		//locals[14] = show_inv( 2, locals[7], locals[2] );
		locals[14] = show_inv (2,locals,7,2);
		//while ( locals[14] > 0 ) {
		//if (locals[14]==1){//If only 1 object.
		locals[15] = 1;
		if ( locals[15] <= locals[14] ) {//and again
			
			//if ( locals[1] == param3[0]play_hunger ) {
			if ( locals[2] == param3 ) {					
				locals[16] = locals[15];
				locals[12] = locals[7];
				locals[15] = locals[14];
			} // end if
			
			locals[15] = locals[15] + 1;
			//locals[14]--;
		} // while
		
		//} // end if
		
		if ( locals[16] > 0 ) {
			
			locals[18] = -1;//Added to make sure link is set
			locals[19] = -1;
			locals[20] = -1;
			locals[21] = -1;
			locals[22] = -1;
			locals[23] = -1;
			locals[24] = -1;
			//x_obj_stuff( 9, locals[24], locals[23], locals[22], locals[18], locals[21], locals[17], locals[20], locals[19], locals[12] );
			x_obj_stuff( 10,locals, 24, 23, 22, 18, 21, 17, 20, 19, locals[12] );
			//if ( param2[0]play_hunger != -1 && param2[0]play_hunger != locals[17] ) {
			//locals[18]=101;//Writ
			//locals[17]=31;//Plate
				//Param2 = testing for plate
				//param1 = testing for writ
			locals[1] = 0;
				if (param1== -1)
				{//Testing for plate
					if (param3== locals[19])	
					{
						locals[25] = 1;
						give_to_npc (2,locals,12,locals[25]);
						locals[1] = 1;	
					}
				}
				if (param2== -1)
				{//Testing for writ
						if ((param1== locals[18]) && (param3==locals[19]))	
						{
							locals[25] = 1;
							give_to_npc (2,locals,12,locals[25]);
							locals[1] = 1;	
						}
				}
				/*
				if ( (param2 != -1) && (param2 != locals[20]) ) {//20 was 17
				locals[1] = 0;
			} else {
				
				//if ( param1[0]play_hunger != -1 && param1[0]play_hunger != locals[18] ) {
				if ( (param1 != -1) && (param1 != locals[18]) ) {//20 was once 18
					locals[1] = 0;
				} else {
					
					locals[25] = 1;
					//give_to_npc( 2, locals[12], locals[25] );
					give_to_npc (2,locals,12,locals[25]);
					locals[1] = 1;
				} 
				//else {//Removed this!
				
				//	locals[1] = 0;
				//} // end if
				
			} // end if
			*/
		} // end if
		
		return locals[1];
	} // end func
	
	IEnumerator func_0b48() {
		
		//int locals[27];
		int[] locals = new int[28];
		
		locals[1] = 314;//The writ
		locals[2] = -1;
		locals[3] = 101;
		if ( func_0a34( locals[3], locals[2], locals[1] ) == 1) {
			
			locals[4] = 32;
			locals[5] = 3;
			set_quest( 2, locals[5], locals[4] );
			yield return StartCoroutine(say( locals, 083 ));
			yield return StartCoroutine(func_09ba());
		} else {
			
			yield return StartCoroutine(say( locals, 084 ));
			locals[6] = 85;
			locals[7] = 86;
			locals[8] = 0;
			//locals[27] = babl_menu( 0, locals[6] );
			yield return StartCoroutine(babl_menu (0,locals,6));
			locals[27] = PlayerAnswer;
			switch ( locals[27] ) {
				
			case 1:
				
				yield return StartCoroutine(func_0b48());
				break;
				
			case 2:
				
				break;
				
			} // end switch
			
			yield return StartCoroutine(say( locals, 087 ));
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
		} // end if
		
	} // end func
	
	IEnumerator func_0bd2() {
		
		//int locals[23];
		int [] locals = new int[24];
		
		yield return StartCoroutine(say( locals, 088 ));
		locals[1] = 89;
		locals[2] = 91;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(say( locals, 034 ));
			func_057c();
			break;
			
		case 2:
			
			privateVariables[3] = 1;
			yield return StartCoroutine(say( locals, 092 ));
			locals[23] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0c2e() {
		
		//int locals[30];
		int [] locals = new int[31];
		
		locals[1] = 172;//plate
		locals[2] = 31;
		locals[3] = -1;
		if ( func_0a34( locals[3], locals[2], locals[1] ) == 1 ) {
			
			yield return StartCoroutine(say( locals , 093 ));
			locals[4] = 32;
			locals[5] = 4;
			set_quest( 2, locals[5], locals[4] );
			locals[6] = 3;
			locals[7] = 10;
			locals[8] = 0;
			gronk_door( 3, locals[8], locals[7], locals[6] );
			locals[9] = 94;
			locals[10] = 95;
			locals[11] = 0;
			//locals[30] = babl_menu( 0, locals[9] );
			yield return StartCoroutine(babl_menu (0,locals,9));
			locals[30] = PlayerAnswer;
			switch ( locals[30] ) {
				
			case 1:
				
				yield return StartCoroutine(func_0cd5());
				break;
				
			case 2:
				
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00e0();
				yield break;
			} // end if
			
		} else {
			
			yield return StartCoroutine(say( locals, 096 ));
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			
		} // end switch
		
		
	} // end func
	
	IEnumerator func_0cd5() {
		int[] locals = new int[1];
		yield return StartCoroutine(say( locals, 097 ));
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00e0();
		yield break;
	} // end func
	
	IEnumerator func_0ce2() {
		
		//int locals[22];
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 098 ));
		privateVariables[5] = 1;
		locals[1] = 99;
		locals[2] = 100;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0d92());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0e67());
			break;
			
		} // end switch
		
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00e0();
		yield break;
	} // end func
	
	IEnumerator func_0d31() {
		
		//int locals[22];
		int[] locals =new int[23];
		
		yield return StartCoroutine(say( locals, 101 ));
		locals[1] = 102;
		locals[2] = 103;
		locals[3] = 104;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0d92());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0e67());
			break;
			
		case 3:
			
			yield return StartCoroutine(say( locals, 105 ));
			yield break;//return;
			
		} // end switch
		
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00e0();
		yield break;
	} // end func
	
	IEnumerator func_0d92() {
		
		//int locals[35];
		int[] locals = new int[36];
		
		locals[2] = 106;
		yield return StartCoroutine(print( 1, locals[2] ));
		yield return StartCoroutine(say( locals, 107 ));
		locals[3] = 287;
		locals[4] = 0;
		locals[1] = find_inv( 2, locals[4], locals[3] );
		
		if ( locals[1] > 0 ) {
			
			locals[5] = 1;
			locals[6] = 7;
			locals[7] = -1;
			locals[8] = -1;
			locals[9] = -1;
			locals[10] = -1;
			locals[11] = -1;
			locals[12] = -1;
			//x_obj_stuff( 9, locals[12], locals[11], locals[10], locals[9], locals[8], locals[7], locals[6], locals[5], locals[1] );
			x_obj_stuff( 10,locals, 12, 11, 10, 9, 8, 7, 6, 5,locals[1] );
			locals[13] = 287;
			if ( take_from_npc( 1, locals[13] ) == 2 ) {
				
				yield return StartCoroutine(say( locals, 108 ));
			} // end if
			
			privateVariables[4] = 1;
		} // end if
		
		locals[14] = 109;
		locals[15] = 0;
		//locals[35] = babl_menu( 0, locals[14] );
		yield return StartCoroutine(babl_menu (0,locals,14));
		locals[35] = PlayerAnswer;
		if ( locals[35] == 1 ) {
			
		} // end if
		
	} // end func
	
	IEnumerator func_0e67() {
		
		//int locals[22];
		int[]locals = new int[23];
		
		yield return StartCoroutine(say( locals, 110 ));
		locals[1] = 111;
		locals[2] = 113;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(say( locals, 112 ));
			break;
			
		case 2:
			
			yield return StartCoroutine(say( locals, 114 ));
			break;
			
		} // end switch
		
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00e0();
		yield break;
	} // end func
	
	IEnumerator func_0eb3() {
		
		//int locals[22];
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 115 ));
		locals[1] = 116;
		locals[2] = 117;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			
		case 2:
			
			yield return StartCoroutine(func_0efb());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0efb() {
		
		//int locals[22];
		int [] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 118 ));
		locals[1] = 119;
		locals[2] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		if ( locals[22] == 1 ) {
			
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
		} // end if
		
	} // end func
	
	IEnumerator func_0f2f() {
		
		//int locals[22];
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 120 ));
		locals[1] = 121;
		locals[2] = 122;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00c2();
			yield break;

		case 2:
			
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0f77() {
		
		//int locals[25];
		int[] locals = new int[26];
		
		yield return StartCoroutine(say( locals, 123 ));
		locals[1] = 124;
		locals[2] = 125;
		locals[3] = 127;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			yield return StartCoroutine(say( locals, 126 ));
			locals[23] = 3;
			locals[24] = 10;
			locals[25] = 0;
			gronk_door( 3, locals[25], locals[24], locals[23] );
			break;
			
		case 3:
			
			yield return StartCoroutine(func_07d5());
			break;
			
		} // end switch
		
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00e0();
		yield break;
	} // end func
	
	IEnumerator func_0ff4() {
		
		//int locals[22];
		int[] locals =new int[23];
		
		yield return StartCoroutine(say( locals, 128 ));
		locals[1] = 129;
		locals[2] = 130;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			
		case 2:
			
			yield return StartCoroutine(func_103c());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_103c() {
		
		//int locals[44];
		int[] locals = new int[45];
		
		//locals[1] = !privateVariables[7];
		if (privateVariables[7] == 1)
		{
			locals[1]=0;
		}
		else
		{
			locals[1]=0;
		}
		yield return StartCoroutine(say( locals, 131 ));
		if ( privateVariables[7] == 0 ) {
			
			yield return StartCoroutine(say( locals, 132));
		} // end if
		
		locals[23] = 1;
		locals[2] = 133;
		locals[24] = 1;
		locals[3] = 134;
		locals[25] = locals[1];
		locals[4] = 135;
		locals[5] = 0;
		//locals[44] = babl_fmenu( 0, locals[2], locals[23] );
		yield return StartCoroutine(babl_fmenu(0,locals,2,23));
		locals[44] = PlayerAnswer;
		switch ( locals[44] ) {
			
		case 133:
			
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			
		case 134:
			
			yield return StartCoroutine(func_045b());
			break;
			
		case 135:
			
			yield return StartCoroutine(func_10c4());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_10c4() {
		
		//int locals[22];
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 136 ));
		locals[1] = 137;
		locals[2] = 138;
		locals[3] = 139;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			
		case 2:
			
			yield return StartCoroutine(func_045b());
			break;
			
		case 3:
			
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			
		} // end switch
		
	} // end func
	
}
