using UnityEngine;
using System.Collections;

public class Conversation_214 : Conversation {

	//conversation #214
	//string block 0x0ed6, name Bolinard
	public int[] global=new int[1];
	public override IEnumerator main() {
		SetupConversation (3798);
		privateVariables[1] = 0;
		yield return StartCoroutine(func_029d());
		func_0012();
		yield return 0;
	} // end func
	
	void func_0012() {
		EndConversation ();
		privateVariables[0] = 1;
	} // end func
	/*
	void func_0020() {
		
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
	
	void func_00b1() {
		
		npc.npc_attitude = param1[0]global[0];
		func_0012();
	} // end func
	*/
	void func_00c2() {
		
		npc.npc_attitude = 2;
		func_0012();
	} // end func
	/*
	void func_00d1() {
		
		npc.npc_attitude = 1;
		func_0012();
	} // end func
	*/
	void func_00e0() {
		
		func_0012();
	} // end func
	/*
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
		
	} // end func
	*/
	IEnumerator func_029d() {
		
		int[] locals = new int[23];
		
		if ( privateVariables[0] == 1 ) {
			
			yield return StartCoroutine(func_0485());
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);yield break;
		} else {
			
			yield return StartCoroutine(say( "Heh?  What art thou doing here?" ));
			global[0] = 0;
			locals[1] = 2;
			locals[2] = 3;
			locals[3] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_02f6());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_0352());
				break;
			} // end if
			

			
		} // end switch
		
	} // end func
	
	IEnumerator func_02f6() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Ah, I'm not worth saving.  Thou shouldst find something else to do." ));
		locals[1] = 5;
		locals[2] = 6;
		locals[3] = 7;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0352());
			break;
			
		case 2:
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
			break;
			
		case 3:
			
			yield return StartCoroutine(func_039a());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0352() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "I know not how to help thee defeat this demon, but I would help thee any other way I can." ));
		locals[1] = 9;
		locals[2] = 10;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_03e2());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_039a());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_039a() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "I have no food, but I can help thee with a map of the area." ));
		locals[1] = 12;
		locals[2] = 13;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_042a());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0567());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03e2() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "I don't know how useful it might be, but I can sketch thee a map of the immediate area." ));
		locals[1] = 15;
		locals[2] = 16;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_042a());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0567());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_042a() {
		
		int[] locals = new int[24];
		
		global[0] = 1;
		yield return StartCoroutine(say( "Surely.  Here, I'll just sketch it on the back of this old picture.  The corridor goes like this, see, and there are all these little branches going off over here.  We are here. \n"
		                               + " Hmm, this map didn't come out very well.  Oh well, take this picture anyways. It has an inscription that says \"Tom.\"" ));
		locals[1] = 272;
		take_from_npc( 1, locals[1] );
		locals[2] = 18;
		locals[3] = 19;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,2));   locals[23] = PlayerAnswer;
		switch ( locals[23] ) {
			
		case 1:
			
			yield return StartCoroutine(func_051f());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_051f());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0485() {
		
		int[] locals = new int[4];
		
		if ( global[0] ==0) {
			
			yield return StartCoroutine(func_04d7());
		} else {
			locals[2]=3;
			locals[1] = random( 1, locals[2] );

			locals[3] = locals[1];
			if ( 1 == locals[3] ) {
				
				yield return StartCoroutine(say( "Begone! I cannot talk." ));
			} else {
				
				if ( 2 == locals[3] ) {
					
					yield return StartCoroutine(say( "Run along, before the guards come back!" ));
				} else {
					
					if ( 3 == locals[3] ) {
						
						yield return StartCoroutine(say( "Farewell, friend!  I'm bound for a better place!" ));
					} // end if
					
				} // end if
				
			} // end if
			
		} // end if
		
	} // end func
	
	IEnumerator func_04d7() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Hello there!  How can I help thee?" ));
		locals[1] = 24;
		locals[2] = 25;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_03e2());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0352());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_051f() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Thou art most welcome.  May the powers of good be with thee." ));
		locals[1] = 27;
		locals[2] = 28;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
			break;
			
		case 2:
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00c2();yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0567() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Very well.  Don't say I didn't try to help thee." ));
		locals[1] = 30;
		locals[2] = 31;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00c2();yield break;
			break;
			
		case 2:
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
			break;
			
		} // end switch
		
	} // end func
	/*
	void func_05af() {
		
		int[] locals = new int[45];
		
		setup_to_barter( 0 );
		while ( !privateVariables[1] ) {
			
			locals[1] = 32;
			locals[2] = 33;
			locals[3] = 34;
			locals[4] = 35;
			locals[5] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				func_0660();
				break;
				
			case 2:
				
				func_06ba();
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
		
		locals[23] = 36;
		locals[24] = 0;
		yield return StartCoroutine(babl_menu (0,locals,23));   locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	void func_0660() {
		
		int[] locals = new int[16];
		
		locals[0] = -1;
		locals[6] = -1;
		locals[11] = 37;
		locals[12] = 38;
		locals[13] = 39;
		locals[14] = 40;
		locals[15] = 41;
		if ( do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ) ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	void func_06ba() {
		
		int[] locals = new int[25];
		
		yield return StartCoroutine(say( "Dost thou intend to rob me?" ));
		locals[1] = 43;
		locals[2] = 44;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			return;
			
			break;
			
		} // end switch
		
		locals[23] = 45;
		locals[24] = 46;
		if ( do_demand( 2, locals[24], locals[23] ) ) {
			
			privateVariables[1] = 1;
		} else {
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
		} // end if
		
	} // end func
*/


}
