using UnityEngine;
using System.Collections;

public class Conversation_215 : Conversation {

	//conversation #215
	//string block 0x0ed7, name Smonden
	int[] global = new int[1];
	public override IEnumerator main() {
		SetupConversation (3799);
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
			
			yield return StartCoroutine(func_03fa());
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);yield break;
		} else {
			
			global[0] = 0;
			yield return StartCoroutine(say( "I shall tell thee nothing, thou minion of Tyball!" ));
			locals[1] = 2;
			locals[2] = 3;
			locals[3] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_04dc());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_04dc());
				break;
			} // end if
			
			//break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_02f6() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "I was captured while on a quest for the Key of Courage." ));
		locals[1] = 5;
		locals[2] = 6;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_033e());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_044c());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_033e() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Indeed?  Then know this: I believe the entrance lies directly north of this very spot." ));
		locals[1] = 8;
		locals[2] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		if ( locals[22] == 1 ) {
			
			yield return StartCoroutine(func_0372());
		} // end if
		
	} // end func
	
	IEnumerator func_0372() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "A locked door blocks the way. But I still have the key hidden here in my cell.  The key to the Key, as it were." ));
		locals[1] = 10;
		locals[2] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		if ( locals[22] == 1 ) {
			
			yield return StartCoroutine(func_03a6());
		} // end if
		
	} // end func
	
	IEnumerator func_03a6() {
	
		int[] locals = new int[2];
		
		yield return StartCoroutine(say( "Yes, for I have been imprisoned too long and have neither heart nor strength left for this quest." ));
		locals[1] = 1016;
		take_from_npc( 1, locals[1] );
		yield return StartCoroutine(say( "It is thine." ));
		global[0] = 1;
		yield return StartCoroutine(func_03c9());
	} // end func
	
	IEnumerator func_03c9() {
		
		int[] locals = new int[23];
		
		locals[1] = 13;
		locals[2] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		if ( locals[22] == 1 ) {
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
		} // end if
		
	} // end func
	
	IEnumerator func_03fa() {
		
		int[] locals = new int[4];
		
		if ( global[0]==0 ) {
			
			yield return StartCoroutine(func_056c());
		} else {
			locals[2]=3;
			locals[1] = random( 1, locals[2] );

			locals[3] = locals[1];
			if ( 1 == locals[3] ) {
				
				yield return StartCoroutine(say( "I am too weary to talk." ));
			} else {
				
				if ( 2 == locals[3] ) {
					
					yield return StartCoroutine(say( "Go on, do what thou must." ));
				} else {
					
					if ( 3 == locals[3] ) {
						
						yield return StartCoroutine(say( "Farewell, friend!  I shall leave here as soon as I rest a bit." ));
					} // end if
					
				} // end if
				
			} // end if
			
		} // end if
		
	} // end func
	
	IEnumerator func_044c() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Nay, for even as I discovered the location of my objective, I was captured by Tyball.  He seemed to think I had been speaking with his deceased brother, ridiculous as that sounds.  He would not release me.  A pity, since I believed that the recovery of the three keys would help right the wrongs of this place." ));
		locals[1] = 18;
		locals[2] = 19;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_033e());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0494());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0494() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "No, I cannot!  I am too weak now.  Would that thou could continue my quest for me!" ));
		locals[1] = 21;
		locals[2] = 22;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_033e());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_033e());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_04dc() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Of course!  I have not seen thee in the ranks of his lackeys.  How may I help thee?" ));
		locals[1] = 24;
		locals[2] = 25;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_02f6());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0524());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0524() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Nay, thou canst not help me!  My freedom is not restored by unlocking these bars, for I am in ill health and can no longer follow my quest: to find the Key of Courage." ));
		locals[1] = 27;
		locals[2] = 28;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_033e());
			break;
			
		case 2:
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00c2();yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_056c() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Please, thou must undertake to complete my quest.  Seek thou the Key of Courage." ));
		locals[1] = 30;
		locals[2] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		if ( locals[22] == 1 ) {
			
			yield return StartCoroutine(func_033e());
		} // end if
		
	} // end func
	/*
	void func_05a0() {
		
		int[] locals = new int[45];
		
		setup_to_barter( 0 );
		while ( !privateVariables[1] ) {
			
			locals[1] = 31;
			locals[2] = 32;
			locals[3] = 33;
			locals[4] = 34;
			locals[5] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				func_0651();
				break;
				
			case 2:
				
				func_06ab();
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
		
		locals[23] = 35;
		locals[24] = 0;
		yield return StartCoroutine(babl_menu (0,locals,23));   locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	void func_0651() {
		
		int[] locals = new int[16];
		
		locals[0] = -1;
		locals[6] = -1;
		locals[11] = 36;
		locals[12] = 37;
		locals[13] = 38;
		locals[14] = 39;
		locals[15] = 40;
		if ( do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ) ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	void func_06ab() {
		
		int[] locals = new int[25];
		
		yield return StartCoroutine(say( "Dost thou intend to rob me?" ));
		locals[1] = 42;
		locals[2] = 43;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			return;
			
			break;
			
		} // end switch
		
		locals[23] = 44;
		locals[24] = 45;
		if ( do_demand( 2, locals[24], locals[23] ) ) {
			
			privateVariables[1] = 1;
		} else {
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
		} // end if
		
	} // end func

*/

}
