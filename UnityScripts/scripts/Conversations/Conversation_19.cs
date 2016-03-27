using UnityEngine;
using System.Collections;

public class Conversation_19 : Conversation {
	
	//conversation #19
	//	string block 0x0e13, name Hagbard
	
	public int[] global=new int[1];//Seen in hagbard(19) so far. // Should this be declared in subclasses that need it?
	
	public override IEnumerator main() {
		SetupConversation (3603);
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
		
		//int locals[1];
		int[] locals=new int[2];
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
	
	void func_00b1(int param1) {
		
		npc.npc_attitude = param1;//[0];//global[0];
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
		
		//int locals[27];
		int[] locals=new int[28];
		if ( npc.npc_talkedto == 1 ) {
			
			yield return StartCoroutine( func_057c());
		} else {
			
			global[0] = 0;
			locals[2] = 1;
			locals[3] = 2;
			locals[1] = sex( 2, locals[3], locals[2] );
			
			locals[4] = 1;
			locals[5] = 1;
			set_quest( 2, locals[5], locals[4] );
			yield return StartCoroutine(say( locals, 003 ));
			locals[6] = 4;
			locals[7] = 5;
			locals[8] = 6;
			locals[9] = 7;
			locals[10] = 0;
			//locals[27] = babl_menu( 0, locals[6] );
			yield return StartCoroutine(babl_menu (0,locals,6));
			locals[27] = PlayerAnswer;
			switch ( locals[27] ) {
				
			case 1:
				
				yield return StartCoroutine(func_0350());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_03eb());
				break;
				
			case 3:
				
				yield return StartCoroutine(func_0350());
				break;
				
			case 4:
				
				yield return StartCoroutine(func_0648());
				break;
			} // end if
			
			//	break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0350() {
		
		//int locals[44];
		int[] locals = new int[45];
		if (global[0] ==1)
		{
			locals[1] = 0;
		}
		else
		{
			locals[1] = 1;
		}
		//locals[1] = !global[0];replaced with above code
		yield return StartCoroutine(say( locals, 008 ));
		locals[23] = locals[1];
		locals[2] = 9;
		locals[24] = 1;
		locals[3] = 10;
		locals[25] = 1;
		locals[4] = 11;
		locals[26] = 1;
		locals[5] = 12;
		locals[6] = 0;
		//locals[44] = babl_fmenu( 0, locals[2], locals[23] );
		yield return StartCoroutine(babl_fmenu (0,locals,2,23));
		locals[44] = PlayerAnswer;
		switch ( locals[44] ) {
			
		case 9:
			
			yield return StartCoroutine(func_0648());
			break;
			
		case 10:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			//break;
			
		case 11:
			
			yield return StartCoroutine(func_03eb());
			break;
			
		case 12:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00c2();
			yield break;
			//break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03eb() {
		
		//int locals[22];
		int[] locals = new int[23];
		yield return StartCoroutine(say( locals, 013 ));
		locals[1] = 14;
		locals[2] = 15;
		locals[3] = 16;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0447());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0447());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_0447());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0447() {
		
		//int locals[22];
		int[] locals =new int[23];
		
		if ( game_days == 0 ) {
			
			yield return StartCoroutine(say( locals, 017 ));
		} else {
			
			yield return StartCoroutine(say( locals, 018 ));
		} // end if
		
		locals[1] = 19;
		locals[2] = 20;
		locals[3] = 21;
		locals[4] = 22;
		locals[5] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_04c4());
			break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00c2();
			yield break;
			//			break;
			
		case 3:
			
			yield return StartCoroutine(func_06a9());
			break;
			
		case 4:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00c2();
			yield break;
			//break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_04c4() {
		
		//int locals[22];
		int[] locals =new int[23];
		yield return StartCoroutine(say( locals, 023 ));
		locals[1] = 24;
		locals[2] = 25;
		locals[3] = 26;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0520());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0520());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_06a9());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0520() {
		
		//int locals[22];
		int[] locals =new int[23];
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
			
			yield return StartCoroutine(func_070e());
			break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			//			break;
			
		case 3:
			
			yield return StartCoroutine(func_06a9());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_057c() {
		
		//int locals[44];
		int[] locals =new int[45];
		
		if ( npc.npc_attitude < 2 ) {
			
			yield return StartCoroutine(say( locals, 031 ));
			locals[1] = 32;
			locals[2] = 33;
			locals[3] = 34;
			locals[4] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_062e());
				break;
				
			case 2:
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_008b();
				yield break;
				//break;
				
			case 3:
				
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00c2();
				yield break;
				//break;
				
			} // end if
			
		} //else {
		
		//break;
		
		//	} // end switch
		
		yield return StartCoroutine(say( locals, 035 ));
		if ( global[0] == 1 ) {
			
			locals[23] = 36;
			locals[24] = 37;
			locals[25] = 0;
			//locals[44] = babl_menu( 0, locals[23] );
			yield return StartCoroutine(babl_menu (0,locals,23));
			locals[44] = PlayerAnswer;
			switch ( locals[44] ) {
				
			case 1:
				
				yield return StartCoroutine(func_063b());
				break;
				
			case 2:
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00e0();
				yield break;
				//				break;
			} // end if
			
		} //else {
		
		//	break;
		
		//} // end switch
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_0648();
		yield break;
	} // end func
	
	IEnumerator func_062e() {
		int[] locals = new int[1];
		yield return StartCoroutine(say( locals, 038 ));
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00c2();
		yield break;
	} // end func
	
	IEnumerator func_063b() {
		int[] locals = new int[1];
		yield return StartCoroutine(say( locals, 039 ));
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00e0();
		yield break;
	} // end func
	
	IEnumerator func_0648() {
		
		//int locals[22];
		int[] locals = new int[23];
		global[0] = 1;
		yield return StartCoroutine(say( locals, 040 ));
		locals[1] = 41;
		locals[2] = 42;
		locals[3] = 43;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_03eb());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_04c4());
			break;
			
		case 3:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			//	break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_06a9() {
		
		//int locals[23];
		int[]locals=new int[24];	
		yield return StartCoroutine(say( locals, 044 ));
		locals[1] = 45;
		locals[2] = 46;
		locals[3] = 47;
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
			//break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			//break;
			
		case 3:
			
			locals[23] = 1;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			//			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_070e() {
		
		//int locals[22];
		int[]locals= new int[23];
		yield return StartCoroutine(say( locals, 048 ));
		locals[1] = 49;
		locals[2] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		if ( locals[22] == 1 ) {
			
			func_00e0();
		} // end if
		
	} // end func
	
	IEnumerator func_0742() {
		
		//int locals[44];
		int[] locals =new int[45];
		
		setup_to_barter( 0 );
		while ( privateVariables[1] != 1) {
			
			locals[1] = 50;
			locals[2] = 51;
			locals[3] = 52;
			locals[4] = 53;
			locals[5] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_07f3());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_084d());
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
		//locals[44] = babl_menu( 0, locals[23] );
		yield return StartCoroutine(babl_menu (0,locals,23));
		locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_07f3() {
		
		//int locals[15];
		int[] locals=new int[16];
		
		locals[0] = -1;
		locals[6] = -1;
		locals[11] = 55;
		locals[12] = 56;
		locals[13] = 57;
		locals[14] = 58;
		locals[15] = 59;
		yield return StartCoroutine( do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ));
		//if ( do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ) == 1) {
		if (PlayerAnswer==1){
			privateVariables[1] = 1;
		} // end if
		yield break;
	} // end func
	
	IEnumerator func_084d() {
		
		//int locals[24];
		int[] locals =new int[24];
		
		yield return StartCoroutine(say( locals, 060 ));
		locals[1] = 61;
		locals[2] = 62;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			yield break;
			//return;
			
			//break;
			
		} // end switch
		
		locals[23] = 63;
		locals[24] = 64;
		yield return StartCoroutine (do_demand( 2, locals[24], locals[23] ));
		//if ( do_demand( 2, locals[24], locals[23] ) == 1 ) {
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
