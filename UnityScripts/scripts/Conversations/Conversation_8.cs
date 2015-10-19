using UnityEngine;
using System.Collections;

public class Conversation_8 : Conversation {

//	conversation #8
//		string block 0x0e08, name Retichall


	public override IEnumerator main() {
		SetupConversation (3592);
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
	
	void func_00b1(int unk) {
		
		npc.npc_attitude = param1[0];//play_hunger;
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
		
		//int locals[71];
		int[] locals=new int[72];
		locals[1] = 3;
		privateVariables[2] = get_quest( 1, locals[1] );

		if ( privateVariables[0] == 1 ) {
			
			if ( privateVariables[2] == 1 ) {
				
				yield return StartCoroutine(say( "I have given thee permission to talk to my husband, and that is enough of my time for thee to waste.  Speak to me no more!" ));
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00e0();
				yield break;;
			} else {
				
				yield return StartCoroutine(say( "It is thee again.  Thou hast a better reason for speaking to my husband this time, I take it?" ));
			} 
		}
		else {
			yield return StartCoroutine(say( "Yes?  What dost thou want, human?" ));	
			// end if
			

			locals[2] = 4;
			locals[3] = 5;
			locals[4] = 0;
			//locals[23] = babl_menu( 0, locals[2] );
			yield return StartCoroutine(babl_menu (0,locals,2));
			locals[23] = PlayerAnswer;
			switch ( locals[23] ) {
				
			case 1:
				
				goto label_030a;
				
				break;
				
			case 2:
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00e0();
				yield break;;
				break;
				
			} // end switch
			
		label_030a:;
			
			yield return StartCoroutine(say( "And what reason hast thou for speaking to him?" ));
		} // end if
	//} 
		locals[24] = 7;
		locals[25] = 8;
		locals[26] = 9;
		locals[27] = 10;
		locals[28] = 0;
		//locals[45] = babl_menu( 0, locals[24] );
		yield return StartCoroutine(babl_menu (0,locals,24));
		locals[45] = PlayerAnswer;
		switch ( locals[45] ) {
			
		case 1:
			
			goto label_0374;
			
			break;
			
		case 2:
			
			goto label_03cb;
			
			break;
			
		case 3:
			
			goto label_03d9;
			
			break;
			
		case 4:
			
			goto label_0374;
			
			break;
			
		} // end switch
		
	//label_0374:;
		
	label_0374:;
		
		yield return StartCoroutine(say( "Very well, thou mayst speak to him.  Do not overstay thy welcome.  He is a busy man." ));
		locals[46] = 3;
		locals[47] = 1;
		set_quest( 2, locals[47], locals[46] );
		locals[48] = 12;
		locals[49] = 13;
		locals[50] = 0;
		//locals[69] = babl_menu( 0, locals[48] );
		yield return StartCoroutine(babl_menu (0,locals,48));
		locals[69] = PlayerAnswer;
		switch ( locals[69] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;;
			break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;;
			break;
			
		} // end switch
		
	label_03cb:;
		
		yield return StartCoroutine(say( "We have no desire to hear from them!  Get thee gone if thou art a Green Goblin-friend!" ));
		locals[70] = 1;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[70] );
		yield break;;
	label_03d9:;
		
		yield return StartCoroutine(say( "Dost thou not know that the time of a king is more precious than that?  Ketchaval has no time for such trifles." ));
		locals[71] = 2;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[71] );
		yield break;;
	} // end func





}
