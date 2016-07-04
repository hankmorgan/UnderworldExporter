using UnityEngine;
using System.Collections;

public class Conversation_143 : Conversation {
	
	//conversation #143
	//string block 0x0e8f, name Biden
	
	int func_04db_result;
	int func_074a_result;
	int func_06c9_result;
	int func_082f_result;
	int func_07d6_result;
	int func_078b_result;
	
	public override IEnumerator main() {
		SetupConversation (3727);
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
		
		npc.npc_attitude = param1;//param1[0]play_hunger;
		func_0012();
	} // end func
	
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
		
		if ( npc.npc_goal == 11 ) {
			
			npc.npc_goal = 7;
		} // end if
		
		locals[1] = 32;
		privateVariables[3] = get_quest( 1, locals[1] );
		
		if ( privateVariables[2] == 1) {
			
			if ( npc.npc_goal == 1 ) {
				
				yield return StartCoroutine (func_0692());
			} else {
				
				yield return StartCoroutine (func_05f7());
			} // end if
			
		} else {
			
			locals[2] = 11;
			if ( get_quest( 1, locals[2] ) == 1 ) {
				
				yield return StartCoroutine (func_069f());
			} else {
				
				yield return StartCoroutine (func_02f0());
			} // end if
			
		} // end if
		
	} // end func
	
	IEnumerator func_02f0() {
		
		//int locals[2];
		int[] locals =new int[3];		               
		
		if ( privateVariables[0] == 0 ) {
			
			locals[1] = 1;
			yield return StartCoroutine (func_06c9( locals[1] ) );
			if ( func_06c9_result == 0 ) {
				
				locals[2] = 1;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[2] );//endconvo
				yield break;
			} // end if
			
		} // end if
		
		if ( privateVariables[5] == 1) {
			
			yield return StartCoroutine (func_0327());
		} else {
			
			yield return StartCoroutine (func_0388());
		} // end if
		
	} // end func
	
	IEnumerator func_0327() {
		
		//int locals[22];
		int[] locals = new int[23];
		
		yield return StartCoroutine (say( locals, 001 ));
		locals[1] = 2;
		locals[2] = 4;
		locals[3] = 6;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine (say( locals, 003 ));
			break;
			
		case 2:
			
			yield return StartCoroutine (say( locals, 005 ));
			break;
			
		case 3:
			
			yield return StartCoroutine (say( locals, 007 ));
			break;
			
		} // end switch
		
		yield return StartCoroutine (func_054f());
	} // end func
	
	IEnumerator func_0388() {
		
		//int locals[69];
		int[] locals = new int[70];
		locals[2] = 8;
		locals[3] = 9;		
		locals[1] = sex( 2, locals[3], locals[2] );
		
		if ( privateVariables[3] > 1 ) {
			
			yield return StartCoroutine (say( locals, 010 ));
		} else {
			
			yield return StartCoroutine (say( locals, 011 ));
		} // end if
		
		locals[4] = 12;
		locals[5] = 14;
		locals[6] = 15;
		locals[7] = 0;
		//locals[25] = babl_menu( 0, locals[4] );
		yield return StartCoroutine(babl_menu (0,locals,4));
		locals[25] = PlayerAnswer;
		switch ( locals[25] ) {
			
		case 1:
			
			yield return StartCoroutine (say( locals, 013 ));
			break;
			
		case 2:
			
			break;
			
		case 3:
			
			yield return StartCoroutine (func_04a8());
			break;
			
		} // end switch
		
		privateVariables[5] = 1;
		yield return StartCoroutine (say( locals, 016 ));
		yield return StartCoroutine (say( locals, 017 ));
		locals[26] = 18;
		locals[27] = 19;
		locals[28] = 0;
		//locals[47] = babl_menu( 0, locals[26] );
		yield return StartCoroutine(babl_menu (0,locals,26));
		locals[47] = PlayerAnswer;
		switch ( locals[47] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			break;
			
		} // end switch
		
		yield return StartCoroutine (say( locals, 020 ));
		yield return StartCoroutine (say( locals, 021 ));
		locals[48] = 22;
		locals[49] = 23;
		locals[50] = 25;
		locals[51] = 0;
		//locals[69] = babl_menu( 0, locals[48] );
		yield return StartCoroutine(babl_menu (0,locals,48));
		locals[69] = PlayerAnswer;
		switch ( locals[69] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			yield return StartCoroutine (say( locals, 024 ));
			break;
			
		case 3:
			
			yield return StartCoroutine (say( locals, 026 ));
			break;
			
		} // end switch
		
		yield return StartCoroutine (func_054f());
	} // end func
	
	IEnumerator func_04a8() {
		int[] locals = new int[1];
		yield return StartCoroutine(func_04db());
		if ( func_04db_result == 0 ) {
			
			if ( npc.npc_attitude > 1 ) {
				
				yield return StartCoroutine (say( locals, 027 ));
			} else {
				
				yield return StartCoroutine (say( locals, 028 ));
			} // end if
			
			if ( npc.npc_attitude > 0 ) {
				
				npc.npc_attitude = npc.npc_attitude - 1;
			} // end if
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();//endconvo
			yield break;
		} // end if
		
	} // end func
	
	IEnumerator func_04db() {
		
		//int locals[26];
		int [] locals= new int[27];
		locals[3] = 29;
		locals[4] = 30;		
		locals[2] = sex( 2, locals[4], locals[3] );
		
		yield return StartCoroutine (say( locals, 031 ));
		locals[5] = 32;
		locals[6] = 33;
		locals[7] = 0;
		//locals[26] = babl_menu( 0, locals[5] );
		yield return StartCoroutine(babl_menu (0,locals,5));
		locals[26] = PlayerAnswer;
		switch ( locals[26] ) {
			
		case 1:
			
			locals[1] = 0;
			goto label_0547;

		case 2:
			
			locals[1] = 1;
			goto label_0547;

		} // end switch
		
	label_0547:;
		
		
		
		//return locals[1];
		func_04db_result=locals[1];
	} // end func
	
	IEnumerator func_054f() {
		
		//int locals[45];
		int[] locals=new int[46];
		
		yield return StartCoroutine (say( locals, 034 ));
		locals[1] = 35;
		locals[2] = 37;
		locals[3] = 39;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine (say( locals, 036 ));
			break;
			
		case 2:
			
			yield return StartCoroutine (say( locals, 038 ));
			break;
			
		case 3:
			
			yield return StartCoroutine (say( locals, 040 ));
			break;
			
		} // end switch
		
		yield return StartCoroutine (say( locals, 041 ));
		locals[23] = 42;
		locals[24] = 43;
		locals[25] = 0;
		//locals[44] = babl_menu( 0, locals[23] );
		yield return StartCoroutine(babl_menu (0,locals,23));
		locals[44] = PlayerAnswer;
		switch ( locals[44] ) {
			
		case 1:
			
			locals[45] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[45] );//endconvo
			yield break;

		case 2:
			
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();//endconvo
			yield break;
		
		} // end switch
		
	} // end func
	
	IEnumerator func_05f7() {
		
		//int locals[11];
		int[] locals = new int[12];
		
		if ( privateVariables[6] == 0 ) {
			
			yield return StartCoroutine (say( locals, 044 ));
			locals[2] = 314;
			locals[1] = do_inv_create( 1, locals[2] )+4 ; //Plus 4 for for x_obj
			
			locals[3] = 1;
			locals[4] = -1;
			locals[5] = -1;
			locals[6] = -1;
			locals[7] = 115;
			locals[8] = 0;
			locals[9] = -1;
			locals[10] = -1;
			//x_obj_stuff( 9, locals[10], locals[9], locals[8], locals[7], locals[6], locals[5], locals[4], locals[3], locals[1] );
			x_obj_stuff( 10,locals, 10, 9, 8, 7, 6, 5, 4, 3, locals[1] );
			locals[11] = 314;
			if ( take_from_npc( 1, locals[11] ) == 2 ) {
				
				yield return StartCoroutine (say( locals, 045 ));
			} // end if
			
			privateVariables[6] = 1;
		} else {
			
			yield return StartCoroutine (say( locals, 046 ));
		} // end if
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		yield break;
	} // end func
	
	IEnumerator func_0692() {
		int[] locals = new int[1];
		yield return StartCoroutine (say( locals, 047 ));
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00e0();//endconvo
		yield break;
	} // end func
	
	IEnumerator func_069f() {
		
		//int locals[1];
		int[] locals = new int[2];
		
		yield return StartCoroutine (say( locals, 048 ));
		privateVariables[2] = 1;
		npc.npc_xhome = 3;
		npc.npc_yhome = 16;
		npc.npc_goal = 1;
		locals[1] = 3;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );//endconvo
		yield break;
	} // end func
	
	IEnumerator func_06c9(int param1) {
		
		//int locals[3];
		int[] locals = new int[4];
		
		locals[3] = privateVariables[3];
		if ( 0 == locals[3] ) {
			yield return StartCoroutine (func_074a( param1 ));
			locals[2] = func_074a_result;
		} else {
			
			if ( 1 == locals[3] ) {
				yield return StartCoroutine (func_074a( param1 ));
				locals[2] = func_074a_result;
			} else {
				
				if ( 2 == locals[3] ) {
					yield return StartCoroutine (func_078b( param1 ));
					locals[2] = func_078b_result;
				} else {
					
					if ( 3 == locals[3] ) {
						yield return StartCoroutine (func_078b( param1 ));
						locals[2] = func_078b_result;
					} else {
						
						if ( 4 == locals[3] ) {
							yield return StartCoroutine (func_07d6( param1 ));
							locals[2] = func_07d6_result;
						} // end if
						
					} // end if
					
				} // end if
				
			} // end if
			
		} // end if
		
		locals[1] = locals[2];
		goto label_0742;
		
	label_0742:;
		
		//return locals[1];
		func_06c9_result = locals[1];
	} // end func
	
	IEnumerator func_074a(int param1) {
		
		//int locals[2];
		int[]locals = new int[3];
		
		yield return StartCoroutine (say( locals, 049 ));
		locals[2] = 1;
		yield return StartCoroutine(func_082f( locals[2] ));
		if ( func_082f_result==1 ) {
			
			//if ( param1[0]play_hunger ) {
			if ( param1==1 ) {
				yield return StartCoroutine (say( locals, 050 ));
			} else {
				
				yield return StartCoroutine (say( locals, 051 ));
			} // end if
			
			locals[1] = 1;
		} else {
			
			yield return StartCoroutine (say( locals, 052 ));
			locals[1] = 0;
		} // end if
		
		//return locals[1];
		func_074a_result=locals[1];
	} // end func
	
	IEnumerator func_078b(int param1) {
		
		//int locals[5];
		int [] locals = new int[6];
		locals[3] = 53;
		locals[4] = 54;
		locals[2] = sex( 2, locals[4], locals[3] );
		
		yield return StartCoroutine (say( locals, 055 ));
		locals[5] = 0;
		func_082f( locals[5] );
		//if ( privateVariables[4] && param1[0]play_hunger ) {
		if ( (privateVariables[4] == 1) && (param1 == 1)) {
			yield return StartCoroutine (say( locals, 056 ));
		} // end if
		
		locals[1] = 1;
		goto label_07ce;
		
	label_07ce:;
		
		//return locals[1];
		func_078b_result=locals[1];
	} // end func
	
	IEnumerator func_07d6(int param1) {
		
		//int locals[1];
		int[] locals = new int[2];
		
		yield return StartCoroutine (say( locals, 057 ));
		privateVariables[4] = 1;
		//if ( privateVariables[4] && param1[0]play_hunger ) {
		if ( (privateVariables[4] == 1 )&& (param1==1)) {
			yield return StartCoroutine (say( locals, 058 ));
		} // end if
		
		locals[1] = 1;
		goto label_07f8;
		
	label_07f8:;
		
		//return locals[1];
		func_07d6_result=locals[1];
	} // end func
	
	IEnumerator func_0800(int param1) {
		
		//int locals[1];
		int[] locals = new int[2];
		
		//locals[1] = privateVariables[3] < 2;
		if (privateVariables[3]<2)
		{
			locals[1]=1;
		}
		else
		{
			locals[1]=0;
		}
		yield return StartCoroutine (say( locals, 059 ));
		yield return StartCoroutine( func_082f( locals[1] ));
		if ( func_082f_result == 1 ) {
			
			//if ( param1[0]play_hunger ) {
			if ( param1==1 ) {
				yield return StartCoroutine (say( locals, 060 ));
			} else {
				
				yield return StartCoroutine (say( locals, 061 ));
			} // end if
			
		} else {
			
			yield return StartCoroutine (say( locals, 062 ));
		} // end if
		
	} // end func
	
	IEnumerator func_082f(int param1) {
		
		//int locals[44];
		int[] locals = new int[45];
		
		locals[23] = 1;
		locals[2] = 63;
		locals[24] =param1;// param1[0]play_hunger;
		locals[3] = 64;
		locals[25] = 1;
		locals[4] = 65;
		locals[5] = 0;
		//locals[44] = babl_fmenu( 0, locals[2], locals[23] );
		yield return StartCoroutine(babl_fmenu (0,locals,2,23));
		locals[44]=PlayerAnswer;
		switch ( locals[44] ) {
			
		case 63:
			
			privateVariables[4] = 1;
			break;
			
		case 64:
			
			locals[1] = 0;
			goto label_08b1;
			
		case 65:
			
			break;
			
		} // end switch
		
		locals[1] = 1;
		goto label_08b1;
		
	label_08b1:;
		
		
		
		//return locals[1];
		func_082f_result=locals[1];
	} // end func
	
	IEnumerator func_08b9() {
		
		//int locals[48];
		int[] locals= new int[49];
		locals[2] = 66;
		locals[3] = 67;
		locals[1] = sex( 2, locals[3], locals[2] );
		
		if ( privateVariables[4]==1 ) {
			
			yield return StartCoroutine (say( locals, 068 ));
		} else {
			
			yield return StartCoroutine (say( locals, 069 ));
		} // end if
		
		locals[4] = 70;
		locals[5] = 72;
		locals[6] = 0;
		//locals[25] = babl_menu( 0, locals[4] );
		yield return StartCoroutine(babl_menu (0,locals,4));
		locals[25] = PlayerAnswer;
		switch ( locals[25] ) {
			
		case 1:
			
			yield return StartCoroutine (say( locals, 071 ));
			break;
			
		case 2:
			
			yield return StartCoroutine (say( locals, 073 ));
			break;
			
		} // end switch
		
		locals[26] = 74;
		locals[27] = 75;
		locals[28] = 0;
		//locals[47] = babl_menu( 0, locals[26] );
		yield return StartCoroutine(babl_menu (0,locals,26));
		locals[47] = PlayerAnswer;
		switch ( locals[47] ) {
			
		case 1:
			
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();//endconvo
			yield break;
			
		case 2:
			
			break;
			
		} // end switch
		
		if ( npc.npc_attitude < 3 ) {
			
			locals[48] = 5;
			if ( random( 1, locals[48] ) < 3 ) {
				
				npc.npc_attitude = npc.npc_attitude + 1;
			} // end if
			
		} // end if
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( 21 );//endconvo
		yield break;
	} // end func
	
}
