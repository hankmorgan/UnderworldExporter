using UnityEngine;
using System.Collections;

public class Conversation_144 : Conversation {

	//conversation #144
	//	string block 0x0e90, name Rawstag
			
	public override IEnumerator main() {
		SetupConversation (3728);
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
	
	void func_008b() {
		
		npc.npc_gtarg = 1;
		npc.npc_goal = 5;
		npc.npc_attitude = 1;
		func_0012();
	} // end func
	
	/*void func_00a4() {
		
		npc.npc_attitude = 6;
	} // end func*/
	
	void func_00b1(int param1) {
		
		npc.npc_attitude =param1;// param1[0]play_hunger;
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
		
		//int locals[45];
		int[] locals = new int[46];
		
		if ( privateVariables[0] == 0 ) {
			
			yield return StartCoroutine(say( "Who are you? I not seen you before." ));
			locals[1] = 2;
			locals[2] = 3;
			locals[3] = 4;
			locals[4] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				break;
				
			case 2:
				
				break;
				
			case 3:
				
				break;
				
			} // end switch
			
			yield return StartCoroutine(say( "All sounds very confusing.  Mind I call you Rodriguez?" ));
			locals[23] = 6;
			locals[24] = 7;
			locals[25] = 8;
			locals[26] = 0;
			//locals[44] = babl_menu( 0, locals[23] );
			yield return StartCoroutine(babl_menu (0,locals,23));
			locals[44] = PlayerAnswer;
			switch ( locals[44] ) {
				
			case 1:
				
				break;
				
			case 2:
				
				if ( npc.npc_attitude < 3 ) {
					
					npc.npc_attitude = npc.npc_attitude + 1;
				} // end if
				
				break;
				
			case 3:
				
				break;
				
			} // end switch
			
			yield return StartCoroutine(say( "Whatever you say, Rodriguez." ));
		} else {
			
			yield return StartCoroutine(say( "Hey, I seen you 'fore.  Hi Rodriguez!" ));
		} // end if
		
		if ( privateVariables[3]  == 1) {
			
			yield return StartCoroutine(func_06ca());
		} else {
			
			if ( privateVariables[2] == 0 ) {
				
				yield return StartCoroutine(func_0382());
			} else {
				
				locals[45] = 1;
				yield return StartCoroutine(func_0521( locals[45] ));
			} // end if
			
		} // end if
		
	} // end func
	
	IEnumerator func_0382() {
		
		//int locals[33];
		int[] locals = new int[34];
		
		while ( true ) {
			
			yield return StartCoroutine(say( "What I do for you?" ));
			locals[2] = 12;
			locals[3] = 13;
			locals[4] = 14;
			locals[5] = 0;
			//locals[23] = babl_menu( 0, locals[2] );
			yield return StartCoroutine(babl_menu (0,locals,2));
			locals[23] = PlayerAnswer;
			switch ( locals[23] ) {
				
			case 1:
				
				yield return StartCoroutine(func_04c8());
				break;
				
			case 2:
				
				break;
				
			case 3:
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00e0();//Endconvo
				yield break;
				break;
				
			} // end switch
			
			//locals[1] = babl_ask( 0 );
			yield return  StartCoroutine(babl_ask(0));
			//say( "\1@SS1\0" );
			yield return StartCoroutine(say( "@SS1" ));
			locals[24] = 16;
			locals[25] = 17;
			//;  // expr. has value on stack!
			if ( (contains( 2, PlayerTypedAnswer, locals[24] ) == 1) || (contains( 2, PlayerTypedAnswer, locals[25] ) == 1)  ) {
				
				func_04c8();
			} else {
				
				locals[26] = 18;
				if ( contains( 2, PlayerTypedAnswer, locals[26] ) == 1) {
					
					yield return StartCoroutine(say( "Oh... I help if I can, I think." ));
				} else {
					
					locals[27] = 20;
					if ( contains( 2, PlayerTypedAnswer, locals[27] ) == 1 ) {
						
						yield return StartCoroutine(say( "I would rather stay here by my door. It safer then going out near the knights." ));
					} else {
						
						locals[28] = 22;
						if ( contains( 2, PlayerTypedAnswer, locals[28] ) == 1 ) {
							
							yield return StartCoroutine(say( "Lava real hot.  Me no go near." ));
						} else {
							
							locals[29] = 24;
							if ( contains( 2, PlayerTypedAnswer, locals[29] ) == 1 ) {
								
								yield return StartCoroutine(say( "Oh, I no good with bridge, it collapse and I hurt meself." ));
							} else {
								
								locals[30] = 26;
								locals[32] = 28;
								locals[31] = 27;
								//;  // expr. has value on stack!

								if ( (compare( 2, PlayerTypedAnswer, locals[30] ) == 1 ) || (contains( 2, PlayerTypedAnswer, locals[31] ) == 1 ) || (contains( 2, PlayerTypedAnswer, locals[32] ) == 1 ) )  {
									
									yield return StartCoroutine(say( "Goodbye, Rodriguez." ));
									locals[33] = 2;
									func_00b1( locals[33] );
								} // end if
								
								yield return StartCoroutine(say( "I no understand you, Rodriguez." ));
							} // end if
							
						} // end if
						
					} // end if
					
				} // end if
				
			} // end if
			
		} // while
		
	} // end func
	
	IEnumerator func_04c8() {
		
		//int locals[23];
		int[] locals = new int[24];
		
		yield return StartCoroutine(say( "I open door?  Yes, I could.  You want me to?" ));
		locals[1] = 32;
		locals[2] = 33;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00c2();//Endconvo
			yield break;
			break;
			
		} // end switch
		
		yield return StartCoroutine(say( "Maybe I open door if you give me something." ));
		privateVariables[2] = 1;
		locals[23] = 0;
		yield return StartCoroutine(func_0521( locals[23] ));
	} // end func
	
	IEnumerator func_0521(int param1) {
		
		//int locals[23];
		int [] locals = new int[24];
		
		//if ( param1[0]play_hunger ) {
		if ( param1 == 1 ) {
			yield return StartCoroutine(say( "Did you bring me something?  What is it?  I want see!" ));
		} // end if
		
		locals[1] = 0;
		while ( true ) {
			
			locals[2] = 36;
			locals[3] = 37;
			locals[4] = 38;
			locals[5] = 0;
			//locals[23] = babl_menu( 0, locals[2] );
			yield return StartCoroutine(babl_menu (0,locals,2));
			locals[23] = PlayerAnswer;
			switch ( locals[23] ) {
				
			case 1:
				
				yield return StartCoroutine(func_0596( locals[1] ));
				break;
				
			case 2:
				
				yield return StartCoroutine(func_0610());
				break;
				
			case 3:
				
				yield return StartCoroutine(say( "Find something, come back with it.  I may like." ));
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00e0();//Endconvo
				yield break;
				break;
				
			} // end switch
			
		} // while
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00e0();
		yield break;
	} // end func
	
	IEnumerator func_0596(int param1) {
		
		//int locals[22];
		int [] locals = new int[23];
		//if ( param1[0]play_hunger < 2 ) {
			if (param1<2){
			//TODO:Figure this out
			//play_hunger = param1[0]play_hunger + 1;
			yield return StartCoroutine(say( "I no like you demand, Rodriguez." ));
		} else {
			
			if ( npc.npc_attitude > 1 ) {
				
				npc.npc_attitude = npc.npc_attitude - 1;
				yield return StartCoroutine(say( "You be careful, friend Rodriguez." ));
			} else {
				
				yield return StartCoroutine(say( "You no make demand anymore!" ));
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_008b();//endconvo
				yield break;
			} // end if
			
		} // end if
		
		locals[1] = 43;
		locals[2] = 44;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_008b();//Endconvo
			yield break;
			break;
			
		case 2:
			
			break;
			
		} // end switch
		
		yield return StartCoroutine(say( "I get.  I once wait for friend so long, I hurl him off cliff by mistake, I so upset." ));
	} // end func
	
	IEnumerator func_0610() {
		
		//int locals[20];
		int[] locals = new int[21];
		
		//locals[14] = show_inv( 2, locals[6], locals[1] );
		locals[14] = show_inv (2,locals,6,1);
		if ( locals[14] == 0 ) {
			
			yield return StartCoroutine(say( "You no show me nothing.  I no impressed....\n" ));//was \p
			yield return StartCoroutine(say( "You try fool me, Rodriguez?  No luck, I too smart." ));
		} else {
			locals[15] = 162;
			locals[11] = find_barter( 1, locals[15] );
			//Rewritten section. Try to find a ruby in a slot, if not find a redgem. if not exit the function
			if (locals[11]==0)
			{//No ruby found.
				locals[16] = 163;
				locals[11] = find_barter( 1, locals[16] );
				if (locals[11]==0)
				{//No red gem found
					yield return StartCoroutine(say( "Nice. But me no want.  Some other?" ));
					yield break;
				}
			}

			locals[17] = -1;
			give_ptr_npc( 2, locals[17], locals[11]-1);//minus 1 to adjust the positions
			yield return StartCoroutine(say( "Oh, I like!  Thank you!" ));
			locals[18] = 61;
			locals[19] = 5;
			locals[20] = 0;
			locals[13] = gronk_door( 3, locals[20], locals[19], locals[18] );

			if ( locals[13] == 1 ) {
				
				yield return StartCoroutine(say( "Door open now.  You happy?" ));
			} else {
				
				yield return StartCoroutine(say( "Hey.  Who break door?" ));
			} // end if
			
			privateVariables[3] = 1;
			if ( npc.npc_attitude < 2 ) {
				
				npc.npc_attitude = 2;
			} // end if
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();//Endconvo
			yield break;
		} // end if
		
	} // end func
	
	IEnumerator func_06ca() {
		
		//int locals[22];
		int[] locals = new int[23];
		
		locals[1] = 52;
		locals[2] = 53;
		locals[3] = 54;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			break;
			
		case 3:
			
			break;
			
		} // end switch
		
		yield return StartCoroutine(say( "Sorry, Rodriguez, I no have time for chitchat.  I have nice red gem I must play with.  You have fun!" ));
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		yield break;
	} // end func

}
