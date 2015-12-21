using UnityEngine;
using System.Collections;

public class Conversation_138 : Conversation {

	//conversation #138
	//	string block 0x0e8a, name Derek
			

	public override IEnumerator main() {
		SetupConversation (3722);
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
	
	/*void func_0063() {
		
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
	} // end func*/
	
	void func_00b1(int param1) {
		
		npc.npc_attitude = param1;//[0]play_hunger;
		func_0012();
	} // end func
	
	/*void func_00c2() {
		
		npc.npc_attitude = 2;
		func_0012();
	} // end func
	
	void func_00d1() {
		
		npc.npc_attitude = 1;
		func_0012();
	} // end func*/
	
	void func_00e0() {
		
		func_0012();
	} // end func
	/*
	void func_00ea() {
		
		param1[1] = game_days;
		param1[2] = game_mins;
	} // end func
	
	void func_0106() {
		
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
		
	} // end func*/
	
	IEnumerator func_029d() {
		
		//int locals[23];
		int[] locals = new int[24];
		locals[1] = 32;
		privateVariables[2] = get_quest( 1, locals[1] );

		if ( privateVariables[0] == 1) {
			
			if ( privateVariables[3] == 1) {
				
				yield return StartCoroutine(func_05ad());
			} else {
				
				yield return StartCoroutine(func_0565());
			} // end if
			
		} // end if
		
		yield return StartCoroutine(say( "I am Derek, a knight and a worker.  Who art thou?" ));
		locals[2] = 2;
		locals[3] = 3;
		locals[4] = 0;
		//locals[23] = babl_menu( 0, locals[2] );
		yield return StartCoroutine(babl_menu (0,locals,2));
		locals[23] = PlayerAnswer;
		switch ( locals[23] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0307());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0307());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0307() {
		
		//int locals[22];
		int[] locals =new int[23];
		
		yield return StartCoroutine(say( "Ah, the adventurous life is not for me.  I am content to remain here and work at my craft." ));
		locals[1] = 5;
		locals[2] = 6;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_034f());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_03b4());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_034f() {
		
		//int locals[23];
		int[] locals = new int[24];
		
		yield return StartCoroutine(say( "Despite thy words, many feel that it is more important to contribute to society by one's work than by one's sword." ));
		locals[1] = 8;
		locals[2] = 9;
		locals[3] = 10;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_03b4());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_03b4());
			break;
			
		case 3:
			
			locals[23] = 1;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03b4() {
		
		//int locals[22];
		int[] locals  = new int[23];
		
		yield return StartCoroutine(say( "I carve gems and work metals.  It is hard and tedious work, especially with poor tools, but I am content with it nonetheless." ));
		locals[1] = 12;
		locals[2] = 13;
		locals[3] = 14;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0410());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_045e());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_0410());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0410() {
		
		//int locals[22];
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Well, if thou hast anything that would help me in my work, I would appreciate it.  Perhaps thou hast collected such an item in thy travels." ));
		while ( true ) {
			
			locals[1] = 16;
			locals[2] = 17;
			locals[3] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_045e());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_05f5());
				break;
				
			} // end switch
			
		} // while
		
	} // end func
	
	IEnumerator func_045e() {
		
		//int locals[60];
		int[] locals = new int[61];
		
		locals[15] = 0;
		//locals[13] = show_inv( 2, locals[6], locals[1] );
		locals[13]= show_inv (2,locals,6,1);
		int counter=0;
		while ( locals[13] > 0 ) {
			
			locals[14] = 1;
			if ( locals[14] <= locals[13] ) {
				
				if ( locals[1+counter] == 275 ) {
					
					locals[15] = locals[14];
					locals[11] = locals[6+counter];
				} // end if
				
				locals[14] = locals[14] + 1;


			} // end if
			counter++;
			locals[13]--;			
		} // while
		
		if ( locals[15] > 0 ) {
			
			yield return StartCoroutine(say( "Ah, that's no ordinary tool, but a true work of art befitting an Avatar!  I can't take it from thee." ));
			locals[16] = 19;
			locals[17] = 20;
			locals[18] = 0;
			//locals[37] = babl_menu( 0, locals[16] );
			yield return StartCoroutine(babl_menu (0,locals,16));
			locals[37] = PlayerAnswer;
			switch ( locals[37] ) {
				
			case 1:
				
				break;
				
			case 2:
				
				yield return StartCoroutine(func_05f5());
				break;
				
			} // end switch
			
			locals[38] = 1;
			//give_to_npc( 2, locals[11], locals[38] );
			give_to_npc(2,locals,11,locals[38]);
			privateVariables[3] = 1;
			npc.npc_attitude = 3;
			yield return StartCoroutine(say( "That is too kind of thee.  I cannot tell thee how much it will help me in my work.  Thou hast demonstrated much humility by giving away this artifact - it is only right that I tell thee of the Ring of Humility./m" ));
			yield return StartCoroutine(say( "There is a room in the northwest portion of the level below us. There you will find four switches.  Flip them in this order: northwest, southeast, northeast, and southwest.  Be careful to stay out of the middle of the room." ));
			yield return StartCoroutine(func_05f5());
		} else {
			
			yield return StartCoroutine(say( "Ah, I'm afraid that is of no use to me." ));
			locals[39] = 24;
			locals[40] = 25;
			locals[41] = 0;
			//locals[60] = babl_menu( 0, locals[39] );
			yield return StartCoroutine(babl_menu (0,locals,39));
			locals[60] = PlayerAnswer;
			switch ( locals[60] ) {
				
			case 1:
				
				yield return StartCoroutine(func_05f5());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_045e());
				break;
			} // end if
			

			
		} // end switch
		
	} // end func
	
	IEnumerator func_0565() {
		
		//int locals[22];
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Greetings, @GS8.  How goes it?" ));
		locals[1] = 27;
		locals[2] = 28;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_045e());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_05f5());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_05ad() {
		
		//int locals[22];
		int[]locals = new int[23];
		
		yield return StartCoroutine(say( "Greetings, @GS8.  I am forever indebted to thee for the gem cutter thou hast given me.  It has increased my productivity tenfold." ));
		locals[1] = 30;
		locals[2] = 31;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_05f5());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_05f5());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_05f5() {
		
		//int locals[22];
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Farewell then." ));
		locals[1] = 33;
		locals[2] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		if ( locals[22] == 1 ) {
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
		} // end if
		
	} // end func

}
