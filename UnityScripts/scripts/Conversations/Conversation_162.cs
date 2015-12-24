using UnityEngine;
using System.Collections;

public class Conversation_162 : Conversation {

	//conversation #162
	//	string block 0x0ea2, name Kneenibble
			

	
	public override IEnumerator main() {
		SetupConversation (3746);
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
		
		int[] locals = new int[322];
		
		if ( privateVariables[0] ==1) {
			//Has met
			if ( privateVariables[2]== 1 ) {
				//Has told you the code
				yield return StartCoroutine(say( "Thanks for fish again.  Sorry, but me have to go.  So long." ));
				locals[321] = 3;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[321] );
				yield break;

			} else {
				
				if ( privateVariables[3] == 1) {
					//Waiting for fish
					goto label_05fd;
				} // end if
				else
				{
					goto label_02ca;
				}
				
			} 
		}
		else {
				
				privateVariables[2] = 0;
				privateVariables[3] = 0;
				privateVariables[4] = 0;
				goto label_02ca;
		}
				
	label_02ca:;
		
		if ( (privateVariables[4] == 1) || (privateVariables[0] ==1 ) ) {
			
			yield return StartCoroutine(say( "So what you do here again?" ));
		} else {
			
			yield return StartCoroutine(say( "Hey, human.  What you do here, far from home?" ));
		} // end if
		
		locals[3] = 3;
		locals[4] = 4;
		locals[5] = 5;
		locals[6] = 0;
		//locals[24] = babl_menu( 0, locals[3] );
		yield return StartCoroutine(babl_menu (0,locals,3));
		locals[24] = PlayerAnswer;
		switch ( locals[24] ) {
			
		case 1:
			
			goto label_032c;
			
			break;
			
		case 2:
			
			goto label_051a;
			
			break;
			
		case 3:
			
			goto label_059a;
			
			break;
			
		} // end switch
				
	label_032c:;
		
		yield return StartCoroutine(say( "Should no bother exploring Abyss.  Not much to see now - just people try to survive.  Used to be lot going on, before collapse." ));
		locals[25] = 7;
		locals[26] = 8;
		locals[27] = 0;
		//locals[46] = babl_menu( 0, locals[25] );
		yield return StartCoroutine(babl_menu (0,locals,25));
		locals[46] = PlayerAnswer;
		switch ( locals[46] ) {
			
		case 1:
			
			goto label_036c;
			
			break;
			
		case 2:
			
			goto label_03ac;
			
			break;
			
		} // end switch
				
	label_036c:;
		
		yield return StartCoroutine(say( "No one lived here, but they come to state chamber, tombs, and mines.  Diplomats and visitors use state chamber for talks, funerals here, too.  Important people buried in tombs.  Me used to work in mines." ));
		locals[47] = 10;
		locals[48] = 11;
		locals[49] = 0;
		//locals[68] = babl_menu( 0, locals[47] );
		yield return StartCoroutine(babl_menu (0,locals,47));
		locals[68] = PlayerAnswer;
		switch ( locals[68] ) {
			
		case 1:
			
			goto label_03ac;
			
			break;
			
		case 2:
			
			goto label_03ec;
			
			break;
			
		} // end switch
				
	label_03ac:;

		yield return StartCoroutine(say( "Me have important job before collapse.  Me operator of mine dispatch chamber.  Only one who know combination for dispatch unit." ));
		locals[69] = 13;
		locals[70] = 14;
		locals[71] = 0;
		//locals[90] = babl_menu( 0, locals[69] );
		yield return StartCoroutine(babl_menu (0,locals,69));
		locals[90] = PlayerAnswer;
		switch ( locals[90] ) {
			
		case 1:
			
			goto label_042c;
			
			break;
			
		case 2:
			
			goto label_046c;
			
			break;
			
		} // end switch
		
	label_03ec:;

		yield return StartCoroutine(say( "Mines in southwest.  But only way get to them is through mine dispatch chamber." ));
		locals[91] = 16;
		locals[92] = 17;
		locals[93] = 0;
		//locals[112] = babl_menu( 0, locals[91] );
		yield return StartCoroutine(babl_menu (0,locals,91));
		locals[112] = PlayerAnswer;
		switch ( locals[112] ) {
			
		case 1:
			
			goto label_042c;
			
			break;
			
		case 2:
			
			goto label_046c;
			
			break;
			
		} // end switch
		
	label_042c:;
		yield return StartCoroutine(say( "Mine dispatch chamber room where miners go be sent to work in mines.  Me send miners to work by sending them to teleport room.  Get put in part of mine from there." ));
		locals[113] = 19;
		locals[114] = 20;
		locals[115] = 0;
		//locals[134] = babl_menu( 0, locals[113] );
		yield return StartCoroutine(babl_menu (0,locals,113));
		locals[134] = PlayerAnswer;
		switch ( locals[134] ) {
			
		case 1:
			
			goto label_046c;
			
			break;
			
		case 2:
			
			goto label_046c;
			
			break;
			
		} // end switch
		
	label_046c:;
		
		yield return StartCoroutine(say( "Need combination to use chamber.  Why would me give you combination to chamber?" ));
		locals[135] = 22;
		locals[136] = 23;
		locals[137] = 0;
		//locals[156] = babl_menu( 0, locals[135] );
		yield return StartCoroutine(babl_menu (0,locals,135));
		locals[156] = PlayerAnswer;
		switch ( locals[156] ) {
			
		case 1:
			
			goto label_06dd;
			
			break;
			
		case 2:
			
			goto label_04ac;
			
			break;
			
		} // end switch
		
	label_04ac:;
		
		privateVariables[3] = 1;
		yield return StartCoroutine(say( "Me want fish.  Bring me ten fish, me tell you combination." ));
		locals[157] = 25;
		locals[158] = 26;
		locals[159] = 27;
		locals[160] = 0;
		//locals[178] = babl_menu( 0, locals[157] );
		yield return StartCoroutine(babl_menu (0,locals,157));
		locals[178] = PlayerAnswer;
		switch ( locals[178] ) {
			
		case 1:
			
			goto label_05fd;
			
			break;
			
		case 2:
			
			locals[179] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[179] );
			yield break;
			break;
			
		case 3:
			
			yield return StartCoroutine(say( "No fish, no combination." ));
			locals[180] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[180] );
			yield break;
			break;
			
		} // end switch
				
	label_051a:;
		
		yield return StartCoroutine(say( "Me live here with rest of Ghouls because me no can work any more. Me work before great collapse." ));
		locals[181] = 30;
		locals[182] = 31;
		locals[183] = 0;
		//locals[202] = babl_menu( 0, locals[181] );
		yield return StartCoroutine(babl_menu (0,locals,181));
		locals[202] = PlayerAnswer;
		switch ( locals[202] ) {
			
		case 1:
			
			goto label_03ac;
			
			break;
			
		case 2:
			
			goto label_055a;
			
			break;
			
		} // end switch
				
	label_055a:;
		
		yield return StartCoroutine(say( "Me used to work in mines.  After collapse, mines no running, so me out of job." ));
		locals[203] = 33;
		locals[204] = 34;
		locals[205] = 0;
		//locals[224] = babl_menu( 0, locals[203] );
		yield return StartCoroutine(babl_menu (0,locals,203));
		locals[224] = PlayerAnswer;
		switch ( locals[224] ) {
			
		case 1:
			
			goto label_03ac;
			
			break;
			
		case 2:
			
			goto label_03ec;
			
			break;
			
		} // end switch
		
	label_059a:;
		
		if ( privateVariables[4]==1 ) {
			
			yield return StartCoroutine(say( "Never mind!  Me no talk to you!" ));
			locals[225] = 1;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[225] );
			yield break;
		} else {
			
			yield return StartCoroutine(say( "You sore human!  Me no talk to you neither!" ));
		} // end if
		
		privateVariables[4] = 1;
		locals[226] = 37;
		locals[227] = 38;
		locals[228] = 0;
		//locals[247] = babl_menu( 0, locals[226] );
		yield return StartCoroutine(babl_menu (0,locals,226));
		locals[247] = PlayerAnswer;
		switch ( locals[247] ) {
			
		case 1:
			
			goto label_02ca;
			
			break;
			
		case 2:
			
			locals[248] = 1;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[248] );
			yield break;
			break;
		} // end if
		

		
	//} // end switch
			
		label_05fd:;

			yield return StartCoroutine(say( "You got fish for me?" ));
		//} // end if
		
	//} // end if
	
	locals[249] = 40;
	locals[250] = 41;
	locals[251] = 0;
	//locals[270] = babl_menu( 0, locals[249] );
		yield return StartCoroutine(babl_menu (0,locals,249));
		locals[270] = PlayerAnswer;
	switch ( locals[270] ) {
		
	case 1:
		
		break;
		
	case 2:
		
		yield return StartCoroutine(say( "Come back with fish!" ));
		locals[271] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[271] );
			yield break;
		break;
		
	} // end switch
	
	locals[272] = 182;
		int[] fishfinder = new int[6];
		//0,1,2,3 = slots with fish
		//4 = no of fish found.
		//5 = no of slots found
 	//find_barter_total( 4, 37, 38, 36, locals[272] );
		//find_barter_total( 4, 6, 8, 36, locals[272], privateVariables );
		find_barter_total(5,4,0,5,locals[272],fishfinder);
		privateVariables[6]= fishfinder[4];
	if ( privateVariables[6] == 0 ) {
		
		yield return StartCoroutine(say( "Me no see any fish there!  You got fish?" ));
	} else {
		
		if ( privateVariables[6] < 10 ) {
			
			yield return StartCoroutine(say( "Me only see @GI37 fish!  You got ten?" ));
		} else {
				give_to_npc(2,fishfinder,0,fishfinder[5]);
			//give_to_npc( 2, 38, 36 );
			//give_to_npc(2,locals,privateVariables[8], privateVariables[6]);
				//give_to_npc(2,privateVariables,8,1);
			privateVariables[2] = 1;
			yield return StartCoroutine(say( "Thanks.  People scarce recently, fish good substitute." ));
			yield return StartCoroutine(say( "There three dials on wall, each goes from zero to seven.  Zero straight up, increases clockwise.  Set dials to 7-2-6 from left to right.  Then pull lever.  Gate to teleport room then open.  Walk in there, teleport to mine." ));
			locals[273] = 47;
			locals[274] = 48;
			locals[275] = 0;
			//locals[294] = babl_menu( 0, locals[273] );
				yield return StartCoroutine(babl_menu (0,locals,273));
				locals[294] = PlayerAnswer;
			switch ( locals[294] ) {
				
			case 1:
				
				locals[295] = 3;
					Time.timeScale =SlomoTime;
					yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[295] );
					yield break;
				break;
				
			case 2:
				
				locals[296] = 3;
					Time.timeScale =SlomoTime;
					yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[296] );
					yield break;
				break;
				
			} // end switch
		}	
	}
		label_06dd:;
			
			yield return StartCoroutine(say( "No way.  Me no give you combination for free.  Me want fish.  Give me ten fish and me give you combination." ));
			locals[297] = 50;
			locals[298] = 51;
			locals[299] = 52;
			locals[300] = 0;
			//locals[318] = babl_menu( 0, locals[297] );
		yield return StartCoroutine(babl_menu (0,locals,297));
		locals[318] = PlayerAnswer;
			switch ( locals[318] ) {
				
			case 1:
				
				goto label_05fd;
				
				break;
				
			case 2:
				
				locals[319] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[319] );
			yield break;
				break;
				
			case 3:
				
				locals[320] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[320] );
			yield break;
				break;
			} // end if
			
			
			
	//	} // end switch
		

	} // end func

}
