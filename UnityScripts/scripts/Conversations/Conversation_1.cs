using UnityEngine;
using System.Collections;

public class Conversation_1 : Conversation {

	//conversation #1
	//	string block 0x0e01, name Corby
	public int[] global = new int[1];
	
	public override IEnumerator main() {
		SetupConversation (3585);
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
	
	void func_0063() {
		
		npc.npc_gtarg = 1;
		npc.npc_attitude = 1;
		npc.npc_goal = 6;
		func_0012();
	} // end func
	
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
	
	/*void func_00b1() {
		
		npc.npc_attitude = param1[0]global[0];
		func_0012();
	} // end func*/
	
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
		int [] locals = new int[23];
		
		if ( privateVariables[0] == 1 ) {
			
			yield return StartCoroutine(func_04c0());
		} else {
			
			global[0] = 0;
			yield return StartCoroutine(say( "Hast thou come to add to my torment?" ));
			locals[1] = 2;
			locals[2] = 3;
			locals[3] = 4;
			locals[4] = 5;
			locals[5] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_031e());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_064a());
				break;
				
			case 3:
				
				yield return StartCoroutine(func_05f6());
				break;
				
			case 4:
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_0063();
				yield break;
				break;
			} // end if
			

			
		} // end switch
		
	} // end func
	
	IEnumerator func_031e() {
		
		//int locals[22];
		int [] locals = new int[23];
		
		yield return StartCoroutine(say( "Why, the torment of lost hopes... Of disillusionment." ));
		locals[1] = 7;
		locals[2] = 8;
		locals[3] = 9;
		locals[4] = 10;
		locals[5] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			if ( global[0] == 0 ) {
				
				yield return StartCoroutine(func_039a());
			} else {
				
				yield return StartCoroutine(func_06a6());
			} // end if
			
			break;
			
		case 2:
			
			yield return StartCoroutine(func_059a());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_064a());
			break;
			
		case 4:
			
			yield return StartCoroutine(func_05f6());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_039a() {
		
		//int locals[22];
		int [] locals = new int[23];
		
		global[0] = 1;
		yield return StartCoroutine(say( "I shared the great dream of Sir Cabirus, that the Avatar's way could be pursued by all folk.  We sought to gather all intelligent species here in the Abyss and teach them to live in harmony.  Alas, it was not to be. \n"
		   + " The constant bickering proved too much for kindly Sir Cabirus, and he perished in his sleep.  Some said he was poisoned, but I know he died of a broken spirit. \n"
		   + " His life's work was in this place, and as he watched it crumble, his heart broke as well." ));
		locals[1] = 12;
		locals[2] = 13;
		locals[3] = 14;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_03fb());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_03fb());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_04b3());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03fb() {
		
		//int locals[22];
		int [] locals = new int[23];
		
		yield return StartCoroutine(say( "Well, aye, Sir Cabirus did gather a number of artifacts with interesting properties. He thought the use of these artifacts might assist the colonists as they pursued the way of the Avatar. Unfortunately, the objects were misused by the folk he hoped to help." ));
		locals[1] = 16;
		locals[2] = 17;
		locals[3] = 18;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0457());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_059a());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_05f6());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0457() {
		
		//int locals[22];
		int [] locals = new int[23];
		
		yield return StartCoroutine(say( "Each of the eight items gathered by Sir Cabirus embodied one of the Virtues. But those who now possess the items keep them merely for their intrinsic value, not their higher purpose." ));
		locals[1] = 20;
		locals[2] = 21;
		locals[3] = 22;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_04b3());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_059a());
			break;
			
		case 3:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_04b3() {
		
		yield return StartCoroutine(say( "Thou dare to profane his memory!  Begone with thee!" ));
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00d1();
		yield break;

	} // end func
	
	IEnumerator func_04c0() {
		
		//int locals[44];
		int [] locals = new int[45];
		
		if ( npc.npc_attitude == 1 ) {
			
			yield return StartCoroutine(say( "Hast thou returned to torment me further?" ));
			locals[1] = 25;
			locals[2] = 26;
			locals[3] = 27;
			locals[4] = 28;
			locals[5] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_05f6());
				break;
				
			case 2:
				
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_0063();
				yield break;
				break;
				
			case 3:
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00c2();
				yield break;
				break;
				
			case 4:
				
				yield return StartCoroutine(func_064a());
				break;
			} // end if
			
		} else {
			

	
		yield return StartCoroutine(say( "Hast thou indeed found a way to help?" ));
		locals[23] = 30;
		locals[24] = 31;
		locals[25] = 32;
		locals[26] = 0;
		//locals[44] = babl_menu( 0, locals[23] );
		yield return StartCoroutine(babl_menu (0,locals,23));
		locals[44] = PlayerAnswer;
		switch ( locals[44] ) {
			
		case 1:
			
			if ( global[0] == 0 ) {
				
				yield return StartCoroutine(func_039a());
			} else {
				
				yield return StartCoroutine(func_06a6());
			} // end if
			
			break;
			
		case 2:
			
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00d1();
			yield break;
			break;
			
		case 3:
			
			yield return StartCoroutine(func_059a());
			break;
			
		} // end switch
		
		} // end if //moved from above
	} // end func
	
	IEnumerator func_059a() {

		//int locals[22];
		int [] locals = new int[23];
		
		yield return StartCoroutine(say( "Is that all thou hast to say?  Get thee gone from here!" ));
		locals[1] = 34;
		locals[2] = 35;
		locals[3] = 36;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			func_00c2();
			break;
			
		case 2:
			
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_0063();
			yield break;
			break;
			
		case 3:
			
			yield return StartCoroutine(func_064a());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_05f6() {
		
		//int locals[22];
		int [] locals = new int[23];
		
		yield return StartCoroutine(say( "Wait!  My cause is lost, but perhaps I can yet help thee." ));
		locals[1] = 38;
		locals[2] = 39;
		locals[3] = 0;
		///locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			if ( global[0] == 0 ) {
				
				yield return StartCoroutine(func_039a());
			} else {
				
				yield return StartCoroutine(func_06a6());
			} // end if
			
			break;
			
		case 2:
			
			func_00c2();
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_064a() {
		
		//int locals[22];
		int [] locals = new int[23];
		
		yield return StartCoroutine(say( "Well, I am beyond thy help!" ));
		locals[1] = 41;
		locals[2] = 42;
		locals[3] = 43;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			func_00c2();
			break;
			
		case 2:
			
			yield return StartCoroutine(func_059a());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_05f6());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_06a6() {
		
		//int locals[22];
		int [] locals = new int[23];
		
		yield return StartCoroutine(say( "Art thou certain thou dost wish to hear my sorry tale again?" ));
		locals[1] = 45;
		locals[2] = 46;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_059a());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_039a());
			break;
			
		} // end switch
		
	} // end func



}
