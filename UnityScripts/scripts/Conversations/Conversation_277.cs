using UnityEngine;
using System.Collections;

public class Conversation_277 : Conversation {
	
	//Generic Green Lizardman
	//	conversation #277 
	//		string block 0x0f15, name 
	
	public int[] global =new int[1];
	
	public override IEnumerator main() {
		SetupConversation (3861);
		privateVariables[1] = 0;
		yield return StartCoroutine(func_029d());
		func_0012();
		yield return 0;
	} // end func
	
	protected void func_0012() {
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
	
	void func_00b1(int param1) {
		
		npc.npc_attitude = param1;// param1[0]global[0];
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
	
	/*void func_00e0() {
		
		func_0012();
	} // end func*/
	
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
	
	protected IEnumerator func_029d() {
		
		//int locals[22];
		int[] locals=new int[23];
		
		if ( privateVariables[0] == 0) {
			
			global[0] = 0;
		} // end if
		
		if ( global[0] == 1 ) {
			
			yield return StartCoroutine(func_06a1());
		} // end if
		
		yield return StartCoroutine(say( locals, 001 ));
		locals[1] = 2;
		locals[2] = 3;
		locals[3] = 4;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_030e());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_036a());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_0565());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_030e() {
		
		//int locals[22];
		int[] locals=new int[23];
		
		yield return StartCoroutine(say( locals, 005 ));
		locals[1] = 6;
		locals[2] = 7;
		locals[3] = 8;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_03da());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0506());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_0565());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_036a() {
		
		//int locals[22];
		int[] locals=new int[23];
		
		yield return StartCoroutine(say( locals, 009 ));
		locals[1] = 10;
		locals[2] = 11;
		locals[3] = 12;
		locals[4] = 13;
		locals[5] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0506());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0436());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_0506());
			break;
			
		case 4:
			
			yield return StartCoroutine(func_0565());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03da() {
		
		//int locals[22];
		int[] locals=new int[23];
		
		yield return StartCoroutine(say( locals, 014 ));
		locals[1] = 15;
		locals[2] = 16;
		locals[3] = 17;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0436());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_04a2());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_036a());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0436() {
		
		//int locals[22];
		int[] locals=new int[23];
		
		yield return StartCoroutine(say( locals, 018 ));
		locals[1] = 19;
		locals[2] = 20;
		locals[3] = 21;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			global[0] = 1;
			yield return StartCoroutine(func_072d());
			break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( 22 );
			yield break;

		case 3:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( 22 );
			yield break;

		} // end switch
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( 22 );
		yield break;
	} // end func
	
	IEnumerator func_04a2() {
		
		//int locals[22];
		int[] locals=new int[23];
		
		yield return StartCoroutine(say( locals, 022 ));
		locals[1] = 23;
		locals[2] = 24;
		locals[3] = 25;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			global[0] = 1;
			yield return StartCoroutine(func_072d());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_059c());
			break;
			
		case 3:
			
			break;
			
		} // end switch
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( 22 );
		yield break;
	} // end func
	
	IEnumerator func_0506() {
		
		//int locals[24];
		int[] locals=new int[25];
		
		yield return StartCoroutine(say( locals, 026 ));
		locals[1] = 27;
		yield return StartCoroutine(print( 1, locals[1] ));
		locals[2] = 28;
		locals[3] = 29;
		locals[4] = 0;
		//locals[23] = babl_menu( 0, locals[2] );
		yield return StartCoroutine(babl_menu (0,locals,2));
		locals[23] = PlayerAnswer;
		switch ( locals[23] ) {
			
		case 1:
			
			locals[24] = 1;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[24] );
			yield break ;

		case 2:
			
			break;
			
		} // end switch
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_008b();
		yield break;
	} // end func
	
	IEnumerator func_0565() {
		
		//int locals[22];
		int[] locals=new int[23];
		
		yield return StartCoroutine(say( locals, 030 ));
		locals[1] = 31;
		locals[2] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		if ( locals[22] == 1 ) {
			
		} // end if
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( 22 );
		yield break;
	} // end func
	
	IEnumerator func_059c() {
		
		//int locals[44];
		int[] locals=new int[45];
		
		yield return StartCoroutine(say( locals, 032 ));
		locals[1] = 33;
		locals[2] = 34;
		locals[3] = 35;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0506());
			break;
			
		case 2:
			
			break;
			
		case 3:
			
			yield return StartCoroutine(func_0565());
			break;
			
		} // end switch
		
		yield return StartCoroutine(say( locals, 036 ));
		locals[23] = 37;
		locals[24] = 38;
		locals[25] = 39;
		locals[26] = 0;
		//locals[44] = babl_menu( 0, locals[23] );
		yield return StartCoroutine(babl_menu (0,locals,23));
		locals[44] = PlayerAnswer;
		switch ( locals[44] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0436());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_064d());
			break;
			
		case 3:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( 22 );
			yield break;

		} // end switch
		
	} // end func
	
	IEnumerator func_064d() {
		
		//int locals[23];
		int[] locals=new int[24];
		
		yield return StartCoroutine(say( locals, 040 ));
		locals[1] = 41;
		locals[2] = 42;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			locals[23] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break ;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( 22 );
			yield break;
		} // end switch
		
	} // end func
	
	IEnumerator func_06a1() {
		
		//int locals[44];
		int[] locals=new int[45];
		
		yield return StartCoroutine(say( locals, 043 ));
		locals[1] = 44;
		locals[2] = 45;
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
			func_00b1( 22 );
			yield break ;
		} // end switch
		
		yield return StartCoroutine(say( locals, 046 ));
		locals[23] = 47;
		locals[24] = 48;
		locals[25] = 0;
		//locals[44] = babl_menu( 0, locals[23] );
		yield return StartCoroutine(babl_menu (0,locals,23));
		locals[44] = PlayerAnswer;
		switch ( locals[44] ) {
			
		case 1:
			
			yield return StartCoroutine(func_072d());
			break;
			
		case 2:
			
			break;
			
		} // end switch
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( 22 );
		yield break;
	} // end func
	
	IEnumerator func_072d() {
		
		//int locals[22];
		int[] locals=new int[23];
		
		if ( func_0020() == 0 ) {
			
		} else {
			
			yield return StartCoroutine(say( locals, 049 ));
			locals[1] = 50;
			locals[2] = 51;
			locals[3] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_077d());
				break;
				
			case 2:
				yield break;
				
			} // end if			
			
		} // end switch
		
	} // end func
	
	IEnumerator func_077d() {
		
		//int locals[44];
		int[] locals=new int[45];
		
		setup_to_barter( 0 );
		while ( privateVariables[1] == 0 ) {
			
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
				
				yield return StartCoroutine(func_082e());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_0870());
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
		
		locals[23] = 56;
		locals[24] = 0;
		//locals[44] = babl_menu( 0, locals[23] );
		yield return StartCoroutine(babl_menu (0,locals,23));
		locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_082e() {
		
		//int locals[5];
		int[] locals=new int[6];
		
		locals[1] = 57;
		locals[2] = 58;
		locals[3] = 59;
		locals[4] = 60;
		locals[5] = 61;
		//if ( do_offer( 5, locals[5], locals[4], locals[3], locals[2], locals[1] ) ) {
		yield return StartCoroutine (do_offer( 5, locals[5], locals[4], locals[3], locals[2], locals[1], 0,0) );
		if (PlayerAnswer==1)	{
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_0870() {
		
		//int locals[24];
		int[] locals=new int[25];
		
		yield return StartCoroutine(say( locals, 062 ));
		locals[1] = 63;
		locals[2] = 64;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			//return;
			yield break;
			
		} // end switch
		
		locals[23] = 65;
		locals[24] = 66;
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
