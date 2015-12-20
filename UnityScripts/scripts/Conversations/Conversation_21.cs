using UnityEngine;
using System.Collections;

public class Conversation_21 : Conversation {

	//conversation #21
	//string block 0x0e15, name Steeltoe

	public override IEnumerator main() {
		SetupConversation (3605);
		privateVariables[1] = 0;
		yield return StartCoroutine(func_029d());
		func_0012();
		yield return 0;
	} // end func
	
	void func_0012() {
		EndConversation();
		privateVariables[0] = 1;
	} // end func
	
/*	void func_0020() {
		
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
		
		npc.npc_attitude = param1;//[0]play_hunger;
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
		
		//int locals[22];
		int[] locals=new int[23];
		
		yield return StartCoroutine(say( "Halt! Who goes there?" ));
		locals[1] = 2;
		locals[2] = 3;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine( babl_menu( 0,locals,1 ));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_02e5());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0379());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_02e5() {
		
		//int locals[24];
		int[] locals = new int[25];
		
		yield return StartCoroutine(say( "What is thy business here?" ));
		locals[2] = 5;
		locals[3] = 8;
		locals[4] = 9;
		locals[5] = 10;
		locals[6] = 0;
		//locals[23] = babl_menu( 0, locals[2] );
		yield return StartCoroutine( babl_menu( 0,locals,2 ));
		locals[23] = PlayerAnswer;
		switch ( locals[23] ) {
			
		case 1:
			
			//locals[1] =
			yield return StartCoroutine( babl_ask( 0 ));
			//locals[24] = 6;
			//if ( contains( 2, locals[1], locals[24] ) ) {
			locals[24] = 16;
			if (contains(2, PlayerTypedAnswer, GetString(locals[24])) == 1){	
				yield return StartCoroutine(func_041c());
			} else {
				
				yield return StartCoroutine(say( "What is that?  Speak up!" ));
				yield return StartCoroutine(func_02e5());
			} // end if
			
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0379());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_0386());
			break;
			
		case 4:
			
			yield return StartCoroutine(func_040f());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0379() {
		
		yield return StartCoroutine(say( "I ask the questions here!" ));
		yield return StartCoroutine(func_02e5());
	} // end func
	
	IEnumerator func_0386() {
		
		//int locals[25];
		int[] locals = new int[26];
		
		yield return StartCoroutine(say( "I doubt your purpose here is legitimate, if ye know not the password!" ));
		locals[2] = 13;
		locals[3] = 14;
		locals[4] = 15;
		locals[5] = 0;
		//locals[23] = babl_menu( 0, locals[2] );
		yield return StartCoroutine( babl_menu( 0,locals,2 ));
		locals[23] = PlayerAnswer;
		switch ( locals[23] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0379());
			break;
			
		case 3:

			//locals[1] = babl_ask( 0 );
			yield return StartCoroutine(babl_ask(0));
			locals[24] = 16;
			//if ( contains( 2, locals[1],  locals[24] ) ) {
			if (contains(2, PlayerTypedAnswer, GetString(locals[24])) == 1){				
				yield return StartCoroutine(func_041c());
			} else {
				
				yield return StartCoroutine(say( "That's not it!  Begone!" ));
				locals[25] = 1;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[25] );
				yield break;
			} // end if
			
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_040f() {
		
		yield return StartCoroutine(say( "We'll have no exploring here!  Now, off with ye!" ));
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00c2();
		yield break;
	} // end func
	
	IEnumerator func_041c() {
		
		//int locals[7];
		int[] locals = new int[8];
		locals[2] = 19;
		locals[3] = 20;		
		locals[1] = sex( 2, locals[3], locals[2] );

		locals[4] = 11;
		locals[5] = 13;
		locals[6] = 0;
		gronk_door( 3, locals[6], locals[5], locals[4] );
		yield return StartCoroutine(say( "Greetings, noble @SS1!  Enter with honor and look upon the magnificent treasure chamber of Lord Goldthirst.  Dare ye not to do any further." ));
		locals[7] = 3;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[7] );
		yield break;
	} // end func




}
