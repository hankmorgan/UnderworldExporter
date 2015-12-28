using UnityEngine;
using System.Collections;

public class Conversation_221 : Conversation {
	//conversation #221
	//	string block 0x0edd, name imp

	public override IEnumerator main() {
		SetupConversation (3805);
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
		
		if ( privateVariables[0] == 0 ) {
			
			privateVariables[2] = 0;
			privateVariables[3] = 0;
			privateVariables[4] = 0;
			privateVariables[5] = 0;
			privateVariables[6] = 0;
			privateVariables[7] = 0;
			privateVariables[8] = 0;
			privateVariables[9] = 0;
			privateVariables[10] = 0;
			privateVariables[11] = 0;
			privateVariables[12] = 0;
			privateVariables[13] = 0;
		} // end if
		
		yield return StartCoroutine (func_02eb());
	} // end func
	
	IEnumerator func_02eb() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Searching for something are we?\n"
		                              +  " Need to find a path?\n"
		                              +  " Slip-up and you'll be wormfood. \n"
		                              +  " Victim of Tyball's wrath." ));
		locals[1] = 2;
		locals[2] = 3;
		locals[3] = 4;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine (func_0347());
			break;
			
		case 2:
			
			yield return StartCoroutine (func_0403());
			break;
			
		case 3:
			
			yield return StartCoroutine (func_0a17());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0347() {
		
		int[] locals = new int[45];
		
		yield return StartCoroutine(say( "A thief I am, a thief I'll be. \n"
		                               + " With a very great prize. \n"
		                                +" Have something you want, something you need. \n"
		                               + " It'll open up your eyes." ));
		privateVariables[2] = 1;
		if ( privateVariables[4] == 0 ) {
			
			locals[1] = 6;
			locals[2] = 7;
			locals[3] = 8;
			locals[4] = 9;
			locals[5] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine (func_04ab());
				break;
				
			case 2:
				
				yield return StartCoroutine (func_05c9());
				break;
				
			case 3:
				
				yield return StartCoroutine (func_0403());
				break;
				
			case 4:
				
				yield return StartCoroutine (func_0a17());
				break;
			} // end if
			
		} //else {
			
			//break;
			
		//} // end switch
		
		locals[23] = 10;
		locals[24] = 11;
		locals[25] = 0;
		yield return StartCoroutine(babl_menu (0,locals,23));   locals[44] = PlayerAnswer;
		switch ( locals[44] ) {
			
		case 1:
			
			yield return StartCoroutine (func_05c9());
			break;
			
		case 2:
			
			yield return StartCoroutine (func_0a17());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0403() {
		
		int[] locals = new int[45];
		
		yield return StartCoroutine(say( "The evil one, very bad. \n"
		                               + " Here to hurt us all. \n"
		                               + " We'll give you a gift if you're wise enough. \n"
		                               + " Just to see him fall." ));
		privateVariables[3] = 1;
		if ( privateVariables[2] == 0 ) {
			
			locals[1] = 13;
			locals[2] = 14;
			locals[3] = 15;
			locals[4] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine (func_04ab());
				break;
				
			case 2:
				
				yield return StartCoroutine (func_0347());
				break;
				
			case 3:
				
				yield return StartCoroutine (func_0a17());
				break;
			} // end if
			
		} //else {
			
			//break;
			
		//} // end switch
		
		locals[23] = 16;
		locals[24] = 17;
		locals[25] = 0;
		yield return StartCoroutine(babl_menu (0,locals,23));   locals[44] = PlayerAnswer;
		switch ( locals[44] ) {
			
		case 1:
			
			yield return StartCoroutine (func_04ab());
			break;
			
		case 2:
			
			yield return StartCoroutine (func_0a17());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_04ab() {
		
		int[] locals = new int[67];
		
		yield return StartCoroutine(say( "A crown it is, that's what we offer. \n"
		                               + " The only thing for you in this room. \n"
		                               + " The rest of the treasure is not yours to have. \n"
		                               + " To steal it will mean your doom." ));
		privateVariables[4] = 1;
		if ( (privateVariables[3] == 0) && (privateVariables[5] == 0) ) {
			
			locals[1] = 19;
			locals[2] = 20;
			locals[3] = 21;
			locals[4] = 22;
			locals[5] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine (func_06b8());
				break;
				
			case 2:
				
				yield return StartCoroutine (func_0719());
				break;
				
			case 3:
				
				yield return StartCoroutine (func_07d2());
				break;
				
			case 4:
				
				yield return StartCoroutine (func_0a17());
				break;
			} // end if
			
		} //else {
			
			//break;
			
		//} // end switch
		
		if ( privateVariables[3] == 0 ) {
			
			locals[23] = 23;
			locals[24] = 24;
			locals[25] = 25;
			locals[26] = 0;
			yield return StartCoroutine(babl_menu (0,locals,23));   locals[44] = PlayerAnswer;
			switch ( locals[44] ) {
				
			case 1:
				
				yield return StartCoroutine (func_06b8());
				break;
				
			case 2:
				
				yield return StartCoroutine (func_07d2());
				break;
				
			case 3:
				
				yield return StartCoroutine (func_0a17());
				break;
			} // end if
			
		}// else {
			
			//break;
			
		//} // end switch
		
		locals[45] = 26;
		locals[46] = 27;
		locals[47] = 0;
		//locals[66] = babl_menu( 0, locals[45] );
		yield return StartCoroutine (babl_menu (0,locals,45));
		locals[66] = PlayerAnswer;
		switch ( locals[66] ) {
			
		case 1:
			
			yield return StartCoroutine (func_06b8());
			break;
			
		case 2:
			
			yield return StartCoroutine (func_0a17());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_05c9() {
		
		int[] locals = new int[67];
		
		yield return StartCoroutine(say( "A maze it is, you'll want to get through. \n"
		                               + " Though many a fool it did swallow. \n"
		                              +  " What I have will enhance your eyes. \n"
		                              +  " And show you the yellow to follow." ));
		privateVariables[5] = 1;
		if ( privateVariables[4] == 0 ) {
			
			locals[1] = 29;
			locals[2] = 30;
			locals[3] = 31;
			locals[4] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine (func_04ab());
				break;
				
			case 2:
				
				yield return StartCoroutine (func_07d2());
				break;
				
			case 3:
				
				yield return StartCoroutine (func_0a17());
				break;
			} // end if
			
		} //else {
			
		//	break;
			
		//} // end switch
		
		if ( privateVariables[8] == 0 ) {
			
			locals[23] = 32;
			locals[24] = 33;
			locals[25] = 0;
			yield return StartCoroutine(babl_menu (0,locals,23));   locals[44] = PlayerAnswer;
			switch ( locals[44] ) {
				
			case 1:
				
				yield return StartCoroutine (func_07d2());
				break;
				
			case 2:
				
				yield return StartCoroutine (func_0a17());
				break;
			} // end if
			
		} //else {
			
			//break;
			
		//} // end switch
		
		locals[45] = 34;
		locals[46] = 35;
		locals[47] = 0;
		//locals[66] = babl_menu( 0, locals[45] );
		yield return StartCoroutine (babl_menu (0,locals,45));
		locals[66] = PlayerAnswer;
		switch ( locals[66] ) {
			
		case 1:
			
			yield return StartCoroutine (func_0752());
			break;
			
		case 2:
			
			yield return StartCoroutine (func_0a17());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_06b8() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Our possessions have a magic upon them. \n"
		                               + " To protect them from those who would take. \n"
		                               + " Touching the wrong thing could mean instant death. \n"
		                               + " Or at the least - a headache." ));
		privateVariables[6] = 1;
		locals[1] = 37;
		locals[2] = 38;
		locals[3] = 39;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine (func_0752());
			break;
			
		case 2:
			
			yield return StartCoroutine (func_08b3());
			break;
			
		case 3:
			
			yield return StartCoroutine (func_0a17());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0719() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "A maze it is, you'll want to get through. \n"
		                                +" Though many a fool it did swallow. \n"
		                                +" What I have will enhance your eyes. \n"
		                                +" And show you the yellow to follow." ));
		privateVariables[7] = 1;
		locals[1] = 41;
		locals[2] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		if ( locals[22] == 1 ) {
			
			yield return StartCoroutine (func_0752());
		} // end if
		
	} // end func
	
	IEnumerator func_0752() {
		
		int[] locals = new int[45];
		
		yield return StartCoroutine(say( "That's the question, is it not?\n"
		                               + " And one you'll have to figure. \n"
		                               + " Its one eye to help you is not bloodshot. \n"
		                               + " And its size is smaller, not bigger." ));
		privateVariables[9] = 1;
		if ( privateVariables[10] == 0 ) {
			
			locals[1] = 43;
			locals[2] = 44;
			locals[3] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine (func_0866());
				break;
				
			case 2:
				
				yield return StartCoroutine (func_08b3());
				break;
			} // end if
			
		} //else {
			
			//break;
			
		//} // end switch
		
		locals[23] = 45;
		locals[24] = 0;
		yield return StartCoroutine(babl_menu (0,locals,23));   locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			yield return StartCoroutine (func_0866());
		} // end if
		
	} // end func
	
	IEnumerator func_07d2() {
		
		int[] locals = new int[45];
		
		yield return StartCoroutine(say( "The evil one, very bad. \n"
		                               + " Here to hurt us all. \n"
		                               + " We'll give you a gift if you're wise enough. \n"
		                               + " Just to see him fall." ));
		privateVariables[8] = 1;
		if ( privateVariables[2] == 0 ) {
			
			locals[1] = 47;
			locals[2] = 48;
			locals[3] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine (func_0347());
				break;
				
			case 2:
				
				yield return StartCoroutine (func_0a17());
				break;
			} // end if
			
		} //else {
			
			//break;
			
		//} // end switch
		
		locals[23] = 49;
		locals[24] = 50;
		locals[25] = 0;
		yield return StartCoroutine(babl_menu (0,locals,23));   locals[44] = PlayerAnswer;
		switch ( locals[44] ) {
			
		case 1:
			
			yield return StartCoroutine (func_0752());
			break;
			
		case 2:
			
			yield return StartCoroutine (func_0a17());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0866() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "A thief I told you, is what I am. \n"
		                               + " And a grand theft it was, I suppose. \n"
		                               + " Heisted the crown, slick as can be. \n"
		                               + " Right from under the evil one's nose." ));
		privateVariables[11] = 1;
		locals[1] = 52;
		locals[2] = 53;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine (func_0966());
			break;
			
		case 2:
			
			yield return StartCoroutine (func_0a17());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_08b3() {
		
		int[] locals = new int[67];
		
		yield return StartCoroutine(say( "Take just what you need. \n"
		                               + " Some items are cursed. \n"
		                               + " The golems guard others. \n"
		                               + " So much the worse." ));
		privateVariables[10] = 1;
		if ( privateVariables[13] == 1 ) {
			
			locals[1] = 55;
			locals[2] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			if ( locals[22] == 1 ) {
				
				yield return StartCoroutine (func_09ab());
			} // end if
			
		} else {
			
		} // end if
		
		if ( privateVariables[9] == 0 ) {
			
			locals[23] = 56;
			locals[24] = 57;
			locals[25] = 0;
			yield return StartCoroutine(babl_menu (0,locals,23));   locals[44] = PlayerAnswer;
			switch ( locals[44] ) {
				
			case 1:
				
				yield return StartCoroutine (func_0752());
				break;
				
			case 2:
				
				yield return StartCoroutine (func_0866());
				break;
			} // end if
			
		} //else {
			
			//break;
			
		//} // end switch
		
		locals[45] = 58;
		locals[46] = 0;
		//locals[66] = babl_menu( 0, locals[45] );
		yield return StartCoroutine (babl_menu (0,locals,45));
		locals[66] = PlayerAnswer;
		if ( locals[66] == 1 ) {
			
			yield return StartCoroutine (func_0866());
		} // end if
		
	} // end func
	
	IEnumerator func_0966() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Can't just give it to anyone. \n"
		                               + " My clues you must heed. \n"
		                               + " Prove yourself worthy. \n"
		                               + " And control your greed." ));
		privateVariables[13] = 1;
		locals[1] = 60;
		locals[2] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		if ( locals[22] == 1 ) {
			
			if ( privateVariables[7] == 0 ) {
				
				yield return StartCoroutine (func_0719());
			} else {
				
				yield return StartCoroutine (func_09ab());
			} // end if
			
		} // end if
		
	} // end func
	
	IEnumerator func_09ab() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "That's all I can tell you. \n"
		                              +  " It should be enough. \n"
		                              +  " Its really quite simple. \n"
		                              +  " If you're too dumb? - That's tough!" ));
		locals[1] = 62;
		locals[2] = 63;
		locals[3] = 64;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine (func_0a07());
			break;
			
		case 2:
			
			yield return StartCoroutine (func_0a07());
			break;
			
		case 3:
			
			yield return StartCoroutine (func_0a07());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0a07() {
		
		yield return StartCoroutine(say( "Heh heh heh... We'll be watching." ));
		remove_talker( 0 );
		Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_0012(); yield break;

	} // end func
	
	IEnumerator func_0a17() {
		
		yield return StartCoroutine(say( "Heh heh heh... Suit thyself, fool." ));
		remove_talker( 0 );
		Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_0012(); yield break;

	} // end func
	/*
	void func_0a27() {
		
		int[] locals = new int[45];
		
		setup_to_barter( 0 );
		while ( !privateVariables[1] ) {
			
			locals[1] = 67;
			locals[2] = 68;
			locals[3] = 69;
			locals[4] = 70;
			locals[5] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				func_0ad8();
				break;
				
			case 2:
				
				func_0b32();
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
		
		locals[23] = 71;
		locals[24] = 0;
		yield return StartCoroutine(babl_menu (0,locals,23));   locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	void func_0ad8() {
		
		int[] locals = new int[16];
		
		locals[0] = -1;
		locals[6] = -1;
		locals[11] = 72;
		locals[12] = 73;
		locals[13] = 74;
		locals[14] = 75;
		locals[15] = 76;
		if ( do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ) ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	void func_0b32() {
		
		int[] locals = new int[25];
		
		yield return StartCoroutine(say( "Dost thou intend to rob me?" ));
		locals[1] = 78;
		locals[2] = 79;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			return;
			
			break;
			
		} // end switch
		
		locals[23] = 80;
		locals[24] = 81;
		if ( do_demand( 2, locals[24], locals[23] ) ) {
			
			privateVariables[1] = 1;
		} else {
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
		} // end if
		
	} // end func

*/
}
