using UnityEngine;
using System.Collections;

public class Conversation_192 : Conversation {

	//conversation #192
	//string block 0x0ec0, name Fyrgen

	public override IEnumerator main() {
		SetupConversation (3776);
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
	
	void func_00b1() {
		
		npc.npc_attitude = param1[0]play_hunger;
		func_0012();
	} // end func
	
	void func_00c2() {
		
		npc.npc_attitude = 2;
		func_0012();
	} // end func
	
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
		
		int[] locals = new int[111];
		
		if ( privateVariables[0] ==1) {
			yield return StartCoroutine(say( "Ah, 'tis thee again." ));
			locals[89] = 15;
			locals[90] = 16;
			locals[91] = 0;
			//locals[110] = babl_menu( 0, locals[89] );
			yield return StartCoroutine(babl_menu (0,locals,89));
			locals[110] = PlayerAnswer;
			switch ( locals[110] ) {
				
			case 1:
				
				goto label_03fd;
				
				break;
				
			case 2:
				
				goto label_03fd;
				
				break;
				
			} // end switch
		} else {
			
			yield return StartCoroutine(say( "Aaah!  What's that?\n...  Oh, thou didst startle me.  I was in the midst of a vivid dream, having just used some incense.  I had a terrible vision of a great demon." ));
			locals[1] = 2;
			locals[2] = 3;
			locals[3] = 4;
			locals[4] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				goto label_02fd;
				
				break;
				
			case 2:
				
				goto label_033d;
				
				break;
				
			case 3:
				
				goto label_02fd;
				
				break;
				
			} // end switch
			
		label_02fd:;

			yield return StartCoroutine(say( "It was horrible!  The demon is more powerful than thou canst imagine.  I do not think he can be defeated by any mortal." ));
			locals[23] = 6;
			locals[24] = 7;
			locals[25] = 0;
			yield return StartCoroutine(babl_menu (0,locals,23));   locals[44] = PlayerAnswer;
			switch ( locals[44] ) {
				
			case 1:
				
				goto label_033d;
				
				break;
				
			case 2:
				
				goto label_033d;
				
				break;
				
			} // end switch
			
		label_033d:;
			

			yield return StartCoroutine(say( "This was no ordinary dream, but one dreamt after burning incense.   Incense causes one to have vivid dreams, and they are always true in some way. \n "
			                               + " Simply pass a block of incense over a torch to produce the smoke which, when inhaled, will cause one to dream. \n "
			                               + " If my dream was of a demon, then some demon truly is threatening us." ));
			locals[45] = 9;
			locals[46] = 10;
			locals[47] = 0;
			//locals[66] = babl_menu( 0, locals[45] );
			yield return StartCoroutine(babl_menu (0,locals,45));
			locals[66] = PlayerAnswer;
			switch ( locals[66] ) {
				
			case 1:
				
				goto label_037d;
				
				break;
				
			case 2:
				
				goto label_037d;
				
				break;
				
			} // end switch
			
		label_037d:;

			yield return StartCoroutine(say( "According to my dream, the demon is too powerful to be killed by any mortal. It would have to forced into leaving this world by some other means. I hope it can be done!" ));
			locals[67] = 12;
			locals[68] = 13;
			locals[69] = 0;
			//locals[88] = babl_menu( 0, locals[67] );
			yield return StartCoroutine(babl_menu (0,locals,67));
			locals[88] = PlayerAnswer;
			switch ( locals[88] ) {
				
			case 1:
				
				Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
				break;
				
			case 2:
				
				Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
				break;
			} // end if
			

			
		} // end switch
		

		
	label_03fd:;

		yield return StartCoroutine(say( "I have not used incense since the time of our meeting, so I have had no more dreams of demons.  Perhaps I am better off - that dream was truly terrifying." ));
		Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
	} // end func




}
