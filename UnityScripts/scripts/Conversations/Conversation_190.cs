using UnityEngine;
using System.Collections;

public class Conversation_190 : Conversation {

	//conversation #190
	//string block 0x0ebe, name Bronus

	public override IEnumerator main() {
		SetupConversation (3774);
		privateVariables[1] = 0;
		yield return StartCoroutine(func_029d());
		func_0012();
		yield return 0;
	} // end func
	
	void func_0012() {
		EndConversation();
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
*/
	void func_00b1(int param1) {
		
		npc.npc_attitude = param1;//param1[0]play_hunger;
		func_0012();
	} // end func
/*	
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
		
		int[] locals = new int[24];
		locals[1] = 8;
		privateVariables[4] = get_quest( 1, locals[1] );

		if ( privateVariables[0]==1 ) {
			
			yield return StartCoroutine(func_0405());
		} else {
			
			privateVariables[2] = 0;
			privateVariables[3] = 0;
			yield return StartCoroutine(say( "Hello, adventurer.  I have a book I must deliver to my fellow mage Morlock, but I have not the time to give it to him in person.  Wilt thou take it to him for me?" ));
			locals[2] = 2;
			locals[3] = 3;
			locals[4] = 4;
			locals[5] = 0;
			yield return StartCoroutine(babl_menu (0,locals,2));   locals[23] = PlayerAnswer;
			switch ( locals[23] ) {
				
			case 1:
				
				yield return StartCoroutine(func_037c());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_031e());
				break;
				
			case 3:
				
				yield return StartCoroutine(func_0334());
				break;
			} // end if
			

			
		} // end switch
		
	} // end func
	
	IEnumerator func_031e() {
		
		int[] locals = new int[2];
		
		yield return StartCoroutine(say( "I am sorry to hear that." ));
		locals[1] = 1;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );
		yield break;
	} // end func
	
	IEnumerator func_0334() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Just the satisfaction of a job well done." ));
		locals[1] = 7;
		locals[2] = 8;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_037c());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_031e());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_037c() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "This book contains very powerful magic that is meant only for  Morlock.  Thou must promise not to open it." ));
		locals[1] = 10;
		locals[2] = 11;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_03c4());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_031e());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03c4() {
		
		int[] locals = new int[4];
		locals[2] = 276;
		locals[1] = take_from_npc( 1, locals[2] );

		if ( (locals[1] == 1 || locals[1] == 2) ) {
			
			privateVariables[2] = 1;
			yield return StartCoroutine(say( "Here is the book.  Please give it to Morlock, and remember not to open it!" ));
		} else {
			
			yield return StartCoroutine(say( "I'm sorry, I seem to have misplaced it." ));
		} // end if
		
		locals[3] = 2;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[3] );
		yield break;
	} // end func
	
	IEnumerator func_0405() {
		
		int[] locals = new int[69];
		
		locals[1] = privateVariables[3];
		if ( 2 == locals[1] ) {
			
			yield return StartCoroutine(say( "I have no more use for thee." ));
			locals[2] = 1;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[2] );
			yield break;
		} else {
			
			if ( 1 == locals[1] ) {
				
				yield return StartCoroutine(say( "It was very kind of thee to run that errand, but I have no more time to talk to thee." ));
				locals[3] = 2;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[3] );
				yield break;
			} else {
				
				if ( 0 == locals[1] ) {
					
					if ( privateVariables[2]==1 ) {
						
						yield return StartCoroutine(say( "Hello again.  Didst thou give that book to Morlock?" ));
						locals[25] = 1;
						locals[4] = 17;
						locals[26] = 1;
						locals[5] = 18;
						locals[27] = privateVariables[4];
						locals[6] = 19;
						locals[7] = 0;
						//locals[46] = babl_fmenu( 0, locals[4], locals[25] );
						yield return StartCoroutine (babl_fmenu (0,locals,4,25));
						locals[46]= PlayerAnswer;
						switch ( locals[46] ) {
							
						case 17:
							
							yield return StartCoroutine(func_0505());
							break;
							
						case 18:
							
							yield return StartCoroutine(func_051b());
							break;
							
						case 19:
							
							yield return StartCoroutine(func_0536());
							break;
						} // end if
						
					} //else {
						

						
					//} // end switch
					
					yield return StartCoroutine(say( "Hello again.  Hast thou reconsidered performing that small errand?" ));
					locals[47] = 21;
					locals[48] = 22;
					locals[49] = 0;
					//locals[68] = babl_menu( 0, locals[47] );
					yield return StartCoroutine (babl_menu (0,locals,47));
					locals[68]=PlayerAnswer;
					switch ( locals[68] ) {
						
					case 1:
						
						yield return StartCoroutine(func_037c());
						break;
						
					case 2:
						
						yield return StartCoroutine(func_031e());
						break;
						
					} // end switch
					
				} // end if
				
			} // end if
			
		} // end if
		
	} // end func
	
	IEnumerator func_0505() {
		
		int[] locals = new int[2];
		
		yield return StartCoroutine(say( "Then do so, please!" ));
		locals[1] = 1;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );
		yield break;
	} // end func
	
	IEnumerator func_051b() {
		
		int[] locals = new int[2];
		
		privateVariables[3] = 1;
		yield return StartCoroutine(say( "I thank thee very much." ));
		locals[1] = 3;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );
		yield break;
	} // end func
	
	IEnumerator func_0536() {
		
		int[] locals = new int[8];
		
		if ( privateVariables[5]==1 ) {
			
			privateVariables[3] = 2;
			yield return StartCoroutine(say( "I should have known better than to trust thee a second time. Perhaps thou shouldst run less dangerous errands in the future." ));
			locals[2] = 1;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[2] );
			yield break;
		} // end if
		
		privateVariables[3] = 0;
		privateVariables[5] = 1;
		locals[3] = 8;
		locals[4] = 1;
		set_quest( 2, locals[4], locals[3] );
		yield return StartCoroutine(say( "A little curious, wert thou?  I expected as much, to be honest.  It is well that I happened to have a second copy of the book.  Please, be more careful with this one!" ));
		locals[5] = 276;
		locals[6] = 276;
		locals[1] = do_inv_create( 1, locals[5] );
		take_from_npc( 1, locals[6] );
		locals[7] = 2;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[7] );
		yield break;
	} // end func
	
	/*void func_05a5() {
		
		int[] locals = new int[45];
		
		setup_to_barter( 0 );
		while ( !privateVariables[1] ) {
			
			locals[1] = 27;
			locals[2] = 28;
			locals[3] = 29;
			locals[4] = 30;
			locals[5] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				func_0656();
				break;
				
			case 2:
				
				func_06b0();
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
		
		locals[23] = 31;
		locals[24] = 0;
		yield return StartCoroutine(babl_menu (0,locals,23));   locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	void func_0656() {
		
		int[] locals = new int[16];
		
		locals[0] = -1;
		locals[6] = -1;
		locals[11] = 32;
		locals[12] = 33;
		locals[13] = 34;
		locals[14] = 35;
		locals[15] = 36;
		if ( do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ) ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	void func_06b0() {
		
		int[] locals = new int[25];
		
		yield return StartCoroutine(say( "Dost thou intend to rob me?" ));
		locals[1] = 38;
		locals[2] = 39;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			return;
			
			break;
			
		} // end switch
		
		locals[23] = 40;
		locals[24] = 41;
		if ( do_demand( 2, locals[24], locals[23] ) ) {
			
			privateVariables[1] = 1;
		} else {
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
		} // end if
		
	} // end func
*/
}
