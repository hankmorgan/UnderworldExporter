using UnityEngine;
using System.Collections;

public class Conversation_3 : Conversation {
	//conversation #3
	//string block 0x0e03, name Goldthirst
	
	
	public override IEnumerator main() {
		SetupConversation (3587);
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
			giii
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
		
		npc.npc_attitude = param1;//[0]play_hunger;
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
		
		//int locals[23];
		int[] locals=new int[24];
		locals[1] = 4;
		privateVariables[6] = get_quest( 1, locals[1] );

		if ( privateVariables[0] == 1 ) {
			
			yield return StartCoroutine(func_09f7());
		} else {
			
			privateVariables[2] = 1;
			privateVariables[4] = 0;
			privateVariables[3] = 0;
			privateVariables[5] = 0;
			yield return StartCoroutine(say( "Greetings, Traveller.  I am Goldthirst, leader of the Mountain-folk.  Welcome to our hall." ));
			locals[2] = 2;
			locals[3] = 3;
			locals[4] = 4;
			locals[5] = 0;
			//locals[23] = babl_menu( 0, locals[2] );
			yield return StartCoroutine( babl_menu( 0,locals,2 ));
			locals[23] = PlayerAnswer;

			switch ( locals[23] ) {
				
			case 1:
				
				yield return StartCoroutine(func_0373());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_03bb());
				break;
				
			case 3:
				
				yield return StartCoroutine(func_032b());
				break;
			} // end if
			

			
		} // end switch
		
	} // end func
	
	IEnumerator func_032b() {
		
		//int locals[22];
		int[] locals=new int[23];
		
		yield return StartCoroutine(say( "Majesty, is it?  Well, thou art good at flattery, if nothing else!" ));
		locals[1] = 6;
		locals[2] = 7;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine( babl_menu( 0,locals,1 ));
		locals[22] = PlayerAnswer;

		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_03c8());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_046c());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0373() {
		
		//int locals[22];
		int[] locals=new int[23];
		
		yield return StartCoroutine(say( "Thou hast a fine tongue, and a sense of courtesy.  Hast thou other Virtues as well?" ));
		locals[1] = 9;
		locals[2] = 10;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine( babl_menu( 0,locals,1 ));
		locals[22] = PlayerAnswer;

		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_07f6());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_071d());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03bb() {
		
		yield return StartCoroutine(say( "Call me that again, and thy tongue shall wag without thy head around it!" ));
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00d1();
		yield break;
	} // end func
	
	IEnumerator func_03c8() {
		
		//int locals[23];
		int[] locals=new int[24];
		
		yield return StartCoroutine(say( "That is quite enough.  Hast thou some reason for coming here?" ));
		locals[2] = 13;
		locals[3] = 14;
		locals[4] = 15;
		locals[5] = 0;
		//locals[23] = babl_menu( 0, locals[2] );
		yield return StartCoroutine( babl_menu( 0,locals,2 ));
		locals[23] = PlayerAnswer;

		switch ( locals[23] ) {
			
		case 1:
			
			yield return StartCoroutine(func_06d5());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0779());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_062c());
			break;
			
		} // end switch
		yield break;	
	} // end func
	
	IEnumerator func_0424() {
		
		//int locals[22];
		int[] locals=new int[23];
		
		yield return StartCoroutine(say( "Thou shalt see it for thyself!  Take thee to the end of the hall from which thou didst enter and say the words 'Deco Morono' to the guard at the door." ));
		locals[1] = 17;
		locals[2] = 18;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine( babl_menu( 0,locals,1 ));
		locals[22] = PlayerAnswer;

		switch ( locals[22] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			break;
			
		case 2:
			
			yield return StartCoroutine(func_03bb());
			break;
			
		} // end switch
		yield break;
	} // end func
	
	IEnumerator func_046c() {
		
		//int locals[22];
		int[] locals=new int[23];
		
		yield return StartCoroutine(say( "Well!  Thou art aware that it is customary to offer a gift when granted an audience?" ));
		locals[1] = 20;
		locals[2] = 21;
		locals[3] = 22;
		locals[4] = 23;
		locals[5] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine( babl_menu( 0,locals,1 ));
		locals[22] = PlayerAnswer;

		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_04dc());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_054c());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_07f6());
			break;
			
		case 4:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00c2();
			yield break;
			break;
			
		} // end switch
		yield break;
	} // end func
	
	IEnumerator func_04dc() {
		
		//int locals[22];
		int[] locals=new int[23];
		
		yield return StartCoroutine(say( "That's quite all right.  Nothing fancy is needed, just a token.  A little . . . GOLD will do." ));
		locals[1] = 25;
		locals[2] = 26;
		locals[3] = 27;
		locals[4] = 28;
		locals[5] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine( babl_menu( 0,locals,1 ));
		locals[22] = PlayerAnswer;

		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_054c());
			break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			break;
			
		case 3:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00c2();
			yield break;
			break;
			
		case 4:
			
			yield return StartCoroutine(func_0779());
			break;
			
		} // end switch
		yield break;
	} // end func
	
	IEnumerator func_054c() {
		
		//int locals[39];
		int[] locals=new int[40];
		
		locals[14] = 0;
	label_0556:;
		
		//locals[11] = show_inv( 2, locals[6], locals[1] );
		locals[11] = show_inv (2,locals,6,1);
		if ( locals[11] > 0 ) {
			
			locals[13] = 1;
			locals[12] = 0;
			while ( locals[13] <= locals[11] ) {
				
				locals[12] = locals[12] + identify_inv( 4, locals[17], locals[15], locals[16], locals[5] );
				locals[16] = 0;
				locals[17] = 0;
				locals[13] = locals[13] + 1;
			} // while
			
			//give_to_npc( 2, locals[6], locals[11] );
			give_to_npc(2,locals,6,locals[11]);
			if ( locals[12] > 5 ) {
				
				yield return StartCoroutine(func_062c());
			} else {
				
				yield return StartCoroutine(func_068d());
			} // end if
			
		} else {
			
			if ( locals[14] > 2 ) {
				
				yield return StartCoroutine(say( "Thou canst not toy with me!" ));
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00d1();
				yield break;
			} else {
				
				yield return StartCoroutine(say( "But thou art empty handed! Dost thou really wish to give me a gift?" ));
				locals[18] = 31;
				locals[19] = 32;
				locals[20] = 0;
				//locals[39] = babl_menu( 0, locals[18] );
				yield return StartCoroutine( babl_menu( 0,locals,18 ));
				locals[39] = PlayerAnswer;

				switch ( locals[39] ) {
					
				case 1:
					
					locals[14] = locals[14] + 1;
					goto label_0556;
					
					break;
					
				case 2:
					
					yield return StartCoroutine(func_04dc());

					break;
				} // end if
				
			} // end if
			

			
		} // end switch
		
		//return;
		
	} // end func
	
	IEnumerator func_062c() {
		
		//int locals[22];
		int[] locals=new int[23];
		
		privateVariables[2] = 0;
		yield return StartCoroutine(say( "This is indeed a goodly gift, and I thank thee for it most kindly.  Wouldst care to see the treasure chamber to which it will be added?" ));
		locals[1] = 34;
		locals[2] = 35;
		locals[3] = 36;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine( babl_menu( 0,locals,1 ));
		locals[22] = PlayerAnswer;

		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_06d5());
			break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			break;
			
		case 3:
			
			yield return StartCoroutine(func_0424());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_068d() {
		
		//int locals[22];
		int[] locals=new int[23];
		
		yield return StartCoroutine(say( "It will do, I suppose.  Thou mayst go now." ));
		locals[1] = 38;
		locals[2] = 39;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine( babl_menu( 0,locals,1 ));
		locals[22] = PlayerAnswer;

		switch ( locals[22] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00d1();
			yield break;
			break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_06d5() {
		
		//int locals[22];
		int[] locals=new int[23];
		
		yield return StartCoroutine(say( "Indeed, I suppose thou wouldst.  Many should like to see my treasure . . .  touch it, stroke it, perhaps STEAL it!  That is what thou wouldst like, isn't it? To rob me blind after I was foolist enough to invite thee here!\n"
		   + " GUARDS!  GUARDS!  ARREST THIS THIEF!" ));
		locals[1] = 41;
		locals[2] = 42;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine( babl_menu( 0,locals,1 ));
		locals[22] = PlayerAnswer;

		switch ( locals[22] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00d1();
			yield break;
			break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_008b();
			yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_071d() {
		
		//int locals[22];
		int[] locals=new int[23];
		
		yield return StartCoroutine(say( "Well then.  What is the reason for thy visit?" ));
		locals[1] = 44;
		locals[2] = 45;
		locals[3] = 46;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine( babl_menu( 0,locals,1 ));
		locals[22] = PlayerAnswer;

		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_054c());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0779());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_046c());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0779() {
		
		//int locals[43];
		int[] locals=new int[44];
		
		privateVariables[4] = 1;
		yield return StartCoroutine(say( "Perhaps we can help each other . . . I have need of such an adventurer as thyself.  Our mines have been invaded by a terrible monster!" ));
		locals[22] = 1;
		locals[1] = 48;
		locals[23] = 1;
		locals[2] = 49;
		locals[24] = privateVariables[6];
		locals[3] = 50;
		locals[4] = 0;
		//locals[43] = babl_fmenu( 0, locals[1], locals[22] );
		yield return StartCoroutine(babl_fmenu (0,locals,1,22));
		locals[43] = PlayerAnswer;

		switch ( locals[43] ) {
			
		case 48:
			
			yield return StartCoroutine(func_0873());
			break;
			
		case 49:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00c2();
			yield break;
			break;
			
		case 50:
			
			yield return StartCoroutine(func_08bb());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_07f6() {
		
		//int locals[43];
		int[] locals=new int[44];
		
		privateVariables[4] = 1;
		yield return StartCoroutine(say( "That is well.  I have need of a paragon, just now.  Art thou aware that my people's mine has been invaded by a monster?" ));
		locals[22] = 1;
		locals[1] = 52;
		locals[23] = 1;
		locals[2] = 53;
		locals[24] = privateVariables[6];
		locals[3] = 54;
		locals[4] = 0;
		//locals[43] = babl_fmenu( 0, locals[1], locals[22] );
		yield return StartCoroutine(babl_fmenu (0,locals,1,22));
		locals[43] = PlayerAnswer;
		switch ( locals[43] ) {
			
		case 52:
			
			yield return StartCoroutine(func_0873());
			break;
			
		case 53:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00c2();
			yield break;
			break;
			
		case 54:
			
			yield return StartCoroutine(func_08bb());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0873() {
		
		//int locals[22];
		int[] locals=new int[23];
		
		yield return StartCoroutine(say( "Excellent!  A hero at last. My people, at least those not too valuable to lose, are all too afraid of the beast to dare face it!  It is a fearsome beast, covered with tentacles and with many eyes.  If thou art brave enough, and you slay the creature, I shall reward thee handsomely!" ));
		locals[1] = 56;
		locals[2] = 57;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine( babl_menu( 0,locals,1 ));
		locals[22] = PlayerAnswer;

		switch ( locals[22] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00c2();
			yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_08bb() {
		
		//int locals[22];
		int[] locals=new int[23];
		
		privateVariables[5] = 1;
		yield return StartCoroutine(say( "I knew thou wert a hero!  Was it difficult?" ));
		locals[1] = 59;
		locals[2] = 60;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine( babl_menu( 0,locals,1 ));
		locals[22] = PlayerAnswer;

		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0908());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0964());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0908() {
		
		//int locals[43];
		int[] locals=new int[44];
		
		yield return StartCoroutine(say( "We are then fortunate that thou wert the one to undertake the task. Thou hast our thanks.  Was there anything else?" ));
		locals[22] = privateVariables[2];
		locals[1] = 62;
		locals[23] = 1;
		locals[2] = 63;
		locals[3] = 0;
		//locals[43] = babl_fmenu( 0, locals[1], locals[22] );
		yield return StartCoroutine(babl_fmenu (0,locals,1,22));
		locals[43] = PlayerAnswer;
		switch ( locals[43] ) {
			
		case 62:
			
			yield return StartCoroutine(func_054c());
			break;
			
		case 63:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0964() {
		
		yield return StartCoroutine(say( "And modest as well!  Truly, thou art worthy of this great reward!  Here!" ));
		yield return StartCoroutine(func_0971());
		yield break;

	} // end func
	
	IEnumerator func_0971() {
		
		//int locals[45];
		int[] locals=new int[46];
		
		privateVariables[3] = 1;
		locals[1] = 65;
		yield return StartCoroutine(print( 1, locals[1] ));
		yield return StartCoroutine(say( "This was the favored tool of Great Coulnes, the best gemcutter ever to grace our tribe.  It is traditionally presented to heroes and those who excel in their craft.  Thou art the first not of our folk to bear it.  May it bring thee fortune.  Again, our thanks." ));
		locals[2] = 275;
		if ( take_from_npc( 1, locals[2] ) == 2 ) {
			
			yield return StartCoroutine(say( "/mI will leave it here for ye." ));
		} // end if
		
		locals[24] = privateVariables[2];
		locals[3] = 68;
		locals[25] = 1;
		locals[4] = 69;
		locals[5] = 0;
		//locals[45] = babl_fmenu( 0, locals[3], locals[24] );
		yield return StartCoroutine(babl_fmenu (0,locals,3,24));
		locals[45] = PlayerAnswer;
		switch ( locals[45] ) {
			
		case 68:
			
			yield return StartCoroutine(func_054c());
			break;
			
		case 69:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_09f7() {
		
		if ( privateVariables[5] == 1 ) {
			
			yield return StartCoroutine(func_0a8b());
		} else {
			
			if ( privateVariables[4] == 1) {
				
				yield return StartCoroutine(func_0a13());
			} else {
				
				yield return StartCoroutine(func_0b77());
			} // end if
			
		} // end if
		yield break;
	} // end func
	
	IEnumerator func_0a13() {
		
		//int locals[43];
		int[] locals=new int[44];
		
		yield return StartCoroutine(say( "Greetings, bold @GS8.  Hast thou managed to kill the vicious monster infesting our mines?" ));
		locals[22] = privateVariables[6];
		locals[1] = 71;
		locals[23] = 1;
		locals[2] = 72;
		locals[24] = 1;
		locals[3] = 73;
		locals[4] = 0;
		//locals[43] = babl_fmenu( 0, locals[1], locals[22] );
		yield return StartCoroutine(babl_fmenu (0,locals,1,22));
		locals[43] = PlayerAnswer;
		switch ( locals[43] ) {
			
		case 71:
			
			yield return StartCoroutine(func_08bb());
			break;
			
		case 72:
			
			yield return StartCoroutine(func_0b1d());
			break;
			
		case 73:
			
			yield return StartCoroutine(func_0b1d());
			break;
			
		} // end switch
		yield break;
	} // end func
	
	IEnumerator func_0a8b() {
		
		//int locals[23];
		int[] locals=new int[24];
		
		yield return StartCoroutine(say( "Ah, @GS8!  It is a pleasure to see thee again.  Thy name shall go down in the history of our clan!" ));
		locals[2] = 75;
		locals[3] = 76;
		locals[4] = 77;
		locals[5] = 0;
		//locals[23] = babl_menu( 0, locals[2] );
		yield return StartCoroutine( babl_menu( 0,locals,2 ));
		locals[23] = PlayerAnswer;

		switch ( locals[23] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0af0());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0b06());
			break;
			
		case 3:
			
			if ( locals[1] == 1) {
				
				yield return StartCoroutine(func_0c20());
			} else {
				
				yield return StartCoroutine(func_054c());
			} // end if
			
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0af0() {
		
		//int locals[1];
		int[] locals=new int[2];
		
		yield return StartCoroutine(say( "Well, we are glad that thou hast visited us.  Do say hello again when thou art in the vicinity.  Thy company is always welcome." ));
		locals[1] = 3;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );
		yield break;
	} // end func
	
	IEnumerator func_0b06() {
		
		if ( privateVariables[3] == 1 ) {
			
			yield return StartCoroutine(say( "Oh, pish.  Thou bearest the amulet of Coulnes, a testament to thy heroics.  As long as this clan lives, we shall remember thee." ));
		} else {
			
			yield return StartCoroutine(say( "Thou art humble as well as brave!  Surely thou deservest a reward." ));
			yield return StartCoroutine(func_0971());
		} // end if
		yield break;
	} // end func
	
	IEnumerator func_0b1d() {
		
		//int locals[24];
		int[] locals=new int[25];
		
		yield return StartCoroutine(say( "Hm.  Perhaps thou art not so great a warrior as I first suspected." ));
		locals[1] = 82;
		locals[2] = 83;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine( babl_menu( 0,locals,1 ));
		locals[22] = PlayerAnswer;

		switch ( locals[22] ) {
			
		case 1:
			
			locals[23] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			break;
			
		case 2:
			
			locals[24] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[24] );
			yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0b77() {
		
		//int locals[45];
		int[] locals=new int[46];
		
		//locals[2] = !privateVariables[2];
		if (privateVariables[2]==1)
		{
			locals[2]=0;
		}
		else
		{
			locals[2]=1;
		}
		if ( npc.npc_attitude < 2 ) {
			
			yield return StartCoroutine(say( "Oh, 'tis thee again.  Is there a reason for thy visit?" ));
		} else {
			
			yield return StartCoroutine(say( "Greetings, bold @GS8.  What brings thee back to our hall?" ));
		} // end if
		
		locals[24] = privateVariables[2];
		locals[3] = 86;
		locals[25] = locals[2];
		locals[4] = 87;
		locals[26] = 1;
		locals[5] = 88;
		locals[27] = 1;
		locals[6] = 89;
		locals[7] = 0;
		//locals[45] = babl_fmenu( 0, locals[3], locals[24] );
		yield return StartCoroutine(babl_fmenu (0,locals,3,24));
		locals[45] = PlayerAnswer;
		switch ( locals[45] ) {
			
		case 86:
			
			yield return StartCoroutine(func_054c());
			break;
			
		case 87:
			
			yield return StartCoroutine(func_0c20());
			break;
			
		case 88:
			
			yield return StartCoroutine(func_0779());
			break;
			
		case 89:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0c20() {
		
		//int locals[42];
		int[] locals=new int[43];
		
		locals[14] = 0;
	label_0c2a:;
		
		//locals[11] = show_inv( 2, locals[6], locals[1] );
		locals[11] = show_inv (2,locals,6,1);
		if ( locals[11] > 0 ) {
			
			locals[13] = 1;
			locals[12] = 0;
			while ( locals[13] <= locals[11] ) {
				
				if ( locals[0] == 175 ) {//A large gold nugget.
					
					locals[16] = locals[5];
					locals[18] = 1;
					//give_to_npc( 2, locals[16], locals[18] );
					give_to_npc(2,locals,16,locals[18]);
					yield return StartCoroutine( func_0d84());
				} // end if
				
				locals[12] = locals[12] + identify_inv( 4, locals[20], locals[15], locals[19], locals[5] );
				locals[19] = 0;
				locals[20] = 0;
				locals[13] = locals[13] + 1;
			} // while
			
			//give_to_npc( 2, locals[6], locals[11] );
			give_to_npc(2,locals,6,locals[11]);
			if ( locals[12] > 5 ) {
				
				yield return StartCoroutine(func_0d2a());
			} else {
				
				yield return StartCoroutine(func_068d());
			} // end if
			
		} else {
			
			if ( locals[14] > 2 ) {
				
				yield return StartCoroutine(say( "Thou canst not toy with me!" ));
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00d1();
				yield break;
			} else {
				
				yield return StartCoroutine(say( "But thou art empty handed! Dost thou really wish to give me a gift?" ));
				locals[21] = 92;
				locals[22] = 93;
				locals[23] = 0;
				//locals[42] = babl_menu( 0, locals[21] );
				yield return StartCoroutine( babl_menu( 0,locals,21 ));
				locals[42] = PlayerAnswer;

				switch ( locals[42] ) {
					
				case 1:
					
					locals[14] = locals[14] + 1;
					goto label_0c2a;
					
					break;
					
				case 2:
					
					func_04dc();
					break;
				} // end if
				
			} // end if
			
		
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0d2a() {
		
		//int locals[24];
		int[] locals=new int[25];
		
		yield return StartCoroutine(say( "'Tis a fine gift.  I thank thee kindly." ));
		locals[1] = 95;
		locals[2] = 96;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine( babl_menu( 0,locals,1 ));
		locals[22] = PlayerAnswer;

		switch ( locals[22] ) {
			
		case 1:
			
			locals[23] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			break;
			
		case 2:
			
			locals[24] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[24] );
			yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0d84() {
		
		//int locals[2];
		int[] locals=new int[3];
		
		yield return StartCoroutine(say( "Zounds!  A larger lump of gold I have never seen!  Surely thou art deserving of this axe, an honored weapon that has been passed down from the time of my ancestors.  Use it well, for there are few weapons better." ));
		locals[1] = 11;
		take_from_npc( 1, locals[1] );
		locals[2] = 3;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[2] );
		yield break;
	} // end func



}
