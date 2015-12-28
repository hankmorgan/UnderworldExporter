using UnityEngine;
using System.Collections;

public class Conversation_17 : Conversation {

	//conversation #17
	//string block 0x0e11, name Sethar Strongarm
			
	public int[] global = new int[2];
	
	public override IEnumerator	main() {
		SetupConversation (3601);
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
	
	void func_00b1(int param1) {
		
		npc.npc_attitude = param1; //param1[0]global[0];
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
		
		//int locals[22];
		int [] locals = new int[23];
		
		if ( privateVariables[0] == 1 ) {
			
			if ( global[0]== 1 ) {
				
				yield return StartCoroutine(func_04ed());
			} else {
				
				if ( global[1] == 1) {
					
					yield return StartCoroutine(func_0484());
				} else {
					
					yield return StartCoroutine(func_0348());
				} // end if
				
			} // end if
			
		} else {
			
			yield return StartCoroutine(say( "A human!  When I was younger, I beat up many humans like you. A fine troll I was!" ));
			locals[1] = 2;
			locals[2] = 3;
			locals[3] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_0300());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_0300());
				break;
			} // end if
			

			
		} // end switch
		
	} // end func
	
	IEnumerator func_0300() {
		
		//int locals[22];
		int [] locals = new int[23];
		
		yield return StartCoroutine(say( "Thank you, you nice human.  Ah, those were days.  Lots of glory, nice treasure.  Now I happy with simpler things." ));
		locals[1] = 5;
		locals[2] = 6;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0390());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0439());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0348() {
		
		//int locals[22];
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "You here again?  You go lots of places.  I like that once, go fight things, do things, take things.  Now I stay here." ));
		locals[1] = 8;
		locals[2] = 9;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0390());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0439());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0390() {
		
		//int locals[22];
		int[] locals = new int[23];
		
		global[1] = 1;
		yield return StartCoroutine(say( "Oh, I would love wormy stew.  My mother she made it when I just a little troll.  You have any?" ));
		locals[1] = 11;
		locals[2] = 12;
		locals[3] = 13;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0503());
			break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();//Endconvo
			yield break;
			break;
			
		case 3:
			
			yield return StartCoroutine(func_03f1());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03f1() {
		
		//int locals[22];
		int[] locals= new int[23];
		
		yield return StartCoroutine(say( "Hmm... I no remember.  I know you use dead rotworm.  My mother knew, but she dead.  Maybe someone else.  Oh, that stew delicious!" ));
		locals[1] = 15;
		locals[2] = 16;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();//Endconvo
			yield break;
			break;
			
		case 2:
			
			func_00e0();//end convo
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0439() {
		
		//int locals[22];
		int[] locals =new int[23];
		
		yield return StartCoroutine(say( "Hmm, let me see... Aha!  I still have dragon scales.  I kill nasty dragon when I was a young troll.  Big and breathed fire.  It could sit on lava forever without burning up.  I kill it and save its scales.  Never use them though.  Now I old troll, I like simple pleasures, I no need them. Maybe if you give me something, I trade for scales." ));
		locals[1] = 18;
		locals[2] = 19;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0390());
			break;
			
		case 2:
			
			yield return StartCoroutine(say( "No, I no need treasure any more.  Just simple nice things like wormy stew." ));
			yield return StartCoroutine(func_0390());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0484() {
		
		//int locals[22];
		int [] locals = new int[23];
		
		yield return StartCoroutine(say( "Hello, you again!  You bring wormy stew for me?" ));
		locals[1] = 22;
		locals[2] = 23;
		locals[3] = 24;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0503());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_04e0());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_04e0());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_04e0() {
		
		yield return StartCoroutine(say( "Oh, please bring it when you done!" ));
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00e0();//Endconvo
		yield break;
	} // end func
	
	IEnumerator func_04ed() {
		
		//int locals[1];
		int[] locals = new int[2];
		
		yield return StartCoroutine(say( "It human again!  Good luck with what you do.  That stew delicious!" ));
		locals[1] = 3;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );
		yield break;
	} // end func
	
	IEnumerator func_0503() {
		
		//int locals[24];
		int[] locals = new int[25];
		
		if ( func_057b() == 1) {
			
			yield return StartCoroutine(func_05b1());
		} else {
			
			locals[1] = 1;
			yield return StartCoroutine(say( "You give me stew?" ));
			while ( locals[1] == 1 ) {
				
				locals[2] = 28;
				locals[3] = 30;
				locals[4] = 0;
				//locals[23] = babl_menu( 0, locals[2] );
				yield return StartCoroutine(babl_menu (0,locals,2));
				locals[23] = PlayerAnswer;
				switch ( locals[23] ) {
					
				case 1:
					
					if ( func_057b() == 1) {
						
						yield return StartCoroutine(func_05b1());
					} else {
						
						yield return StartCoroutine(say( "I no see stew." ));
					} // end if
					
					break;
					
				case 2:
					
					locals[1] = 0;
					break;
					
				} // end switch
				
			} // while
			
			yield return StartCoroutine(say( "You make me sad, pretend to have stew and then not." ));
			locals[24] = 1;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[24] );
			yield break;
		} // end if
		
	} // end func
	
	int func_057b() {
		
		//int locals[3];
		int[] locals = new int[4];
		locals[2] = 283;
		locals[1] = find_barter( 1, locals[2] );

		if ( locals[1] == 0 ) {
			return 0;
		} else {
			
			locals[3] = -1;
			give_ptr_npc( 2, locals[3], locals[1] -1);//Adjust position by -1
			return 1;
		} // end if
		
	} // end func
	
	IEnumerator func_05b1() {
		
		//int locals[2];
		int[] locals = new int[3];
		
		yield return StartCoroutine(say( "Oh, wormy stew, just what I love.  Here, take dragon scales. Maybe they help you not get hurt when you go hot places, just like dragon." ));
		locals[2] = 285;
		locals[1] = take_from_npc( 1, locals[2] );

		if ( (locals[1] == 1 || locals[1] == 2) ) {
			
			if ( locals[1] == 2 ) {
				
				yield return StartCoroutine(say( "Your arms full, I leave on floor." ));
			} // end if
			
			global[0] = 1;
		} else {
			
			yield return StartCoroutine(say( "Huh, where they go?  I no find." ));
		} // end if
		
		yield return StartCoroutine(func_05f4());
	} // end func
	
	IEnumerator func_05f4() {
		
		//int locals[22];
		int [] locals = new int[23];
		
		locals[1] = 35;
		locals[2] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		if ( locals[22] == 1 ) {
			
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();//Endconvo
			yield break;
		} // end if
		
	} // end func

}
