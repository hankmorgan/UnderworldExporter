using UnityEngine;
using System.Collections;

public class Conversation_13 : Conversation {

	//conversation #13
	//	string block 0x0e0d, name Morlock
			
	public override IEnumerator main() {
		SetupConversation (3597);
		privateVariables[1] = 0;
		yield return StartCoroutine(func_029d());
		func_0012();
		yield return 0;
	} // end func
	
	void func_0012() {
		EndConversation ();
		privateVariables[0] = 1;
	} // end func
	
/*	void func_0020() {
		
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

	void func_00ea(int param1) {
		
		//param1[1] = game_days;
		//param1[2] = game_mins;
	} // end func
/*	
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
		
		if ( privateVariables[0]==1 ) {
			
			yield return StartCoroutine(func_0860());
		} else {
			
			privateVariables[5] = 0;
			privateVariables[2] = 0;
			privateVariables[3] = 0;
			privateVariables[4] = 0;
			//privateVariables[6][1] = 0;
			//privateVariables[6][2] = 0;
			privateVariables[9] = 0;
			privateVariables[10] = 0;
			privateVariables[11] = 0;
			yield return StartCoroutine(say( "Hail to thee, bold traveller.  I am Morlock." ));
			locals[1] = 2;
			locals[2] = 3;
			locals[3] = 4;
			locals[4] = 5;
			locals[5] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				locals[23] = 2;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[23] );
				yield break;
				break;
				
			case 2:
				
				yield return StartCoroutine(func_0352());
				break;
				
			case 3:
				
				yield return StartCoroutine(func_0432());
				break;
				
			case 4:
				
				yield return StartCoroutine(func_03b7());
				break;
			} // end if
			

			
		} // end switch
		
	} // end func
	
	IEnumerator func_0352() {
		
		int[] locals = new int[24];
		
		yield return StartCoroutine(say( "Well, I can tell thee that one of my comrades, the mage Bronus, has need of thy services.  Deliver to me an object of his,  and thou shalt be rewarded." ));
		locals[1] = 7;
		locals[2] = 8;
		locals[3] = 9;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0432());
			break;
			
		case 2:
			
			locals[23] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			break;
			
		case 3:
			
			yield return StartCoroutine(func_041c());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03b7() {
		
		int[] locals = new int[24];
		
		yield return StartCoroutine(say( "Ah!  Well, I believe that my fellow mage Bronus has something for me.  If thou wouldst deliver it to me, perhaps I can help thee further." ));
		locals[1] = 11;
		locals[2] = 12;
		locals[3] = 13;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0432());
			break;
			
		case 2:
			
			locals[23] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			break;
			
		case 3:
			
			yield return StartCoroutine(func_041c());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_041c() {
		
		int[] locals = new int[2];
		
		yield return StartCoroutine(say( "That is too bad.  If thou changest thy mind, do not hesitate to talk to me again!" ));
		locals[1] = 2;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );
		yield break;
	} // end func
	
	IEnumerator func_0432() {
		
		int[] locals = new int[103];
		
		locals[15] = 0;
		//locals[13] = show_inv( 2, locals[6], locals[1] );
		locals[13]=show_inv (2,locals,6,1);
		int counter=0;
		while ( locals[13] > 0 ) {
			
			locals[14] = 1;
			if ( locals[14] <= locals[13] ) {
				
				//if ( locals[0] == 276 ) {
				if ( locals[1+counter] == 276 ) {
					locals[15] = locals[14];
					//locals[11] = locals[5];
					locals[11] = locals[6+counter];
				} // end if
				
				locals[14] = locals[14] + 1;
			} // while
			counter++;
			locals[13]--;
		} // end if
		
		if ( locals[15] > 0 ) {
			
			locals[16] = 1;
			give_to_npc( 2,locals, 11, locals[16] );
			//give_to_npc( 2, locals[11], locals[16] );
			privateVariables[5] = 1;
			yield return StartCoroutine(say( "Ah!  Thou hast brought my book!  Excellent!" ));
			yield return StartCoroutine(func_058b());
		} else {
			
			if ( locals[13] == 0 ) {
				
				yield return StartCoroutine(say( "Thou sayest thou hast something for me?" ));
				locals[38] = 1;
				locals[17] = 17;
				locals[39] = 1;
				locals[18] = 18;
				locals[19] = 0;
				//locals[59] = babl_fmenu( 0, locals[17], locals[38] );
				yield return StartCoroutine (babl_fmenu (0,locals,17,38));
				locals[59] = PlayerAnswer;
				switch ( locals[59] ) {
					
				case 17:
					
					yield return StartCoroutine(func_0432());
					break;
					
				case 18:
					
					yield return StartCoroutine(func_0575());
					break;
				} // end if
				
			} //else {
				

				
			//} // end switch
			
			yield return StartCoroutine(say( "None of this is mine.  Dost thou really have an item of mine?" ));
			locals[81] = 1;
			locals[60] = 20;
			locals[82] = 1;
			locals[61] = 21;
			locals[62] = 0;
			//locals[102] = babl_fmenu( 0, locals[60], locals[81] );
			yield return StartCoroutine (babl_fmenu (0,locals,60,81));
			locals[102] = PlayerAnswer;
			switch ( locals[102] ) {
				
			case 20:
				
				yield return StartCoroutine(func_0432());
				break;
				
			case 21:
				
				yield return StartCoroutine(func_0575());
				break;
			} // end if
			

			
		} // end switch
		
	} // end func
	
	IEnumerator func_0563() {
		
		privateVariables[5] = 1;
		yield return StartCoroutine(say( "Perhaps the errand was too difficult for thee.  But no matter." ));
		yield return StartCoroutine(func_058b());
	} // end func
	
	IEnumerator func_0575() {
		
		int[] locals = new int[2];
		
		yield return StartCoroutine(say( "Well, if thou dost acquire that object, please do not delay in bringing it to me." ));
		locals[1] = 2;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );
		yield break;
	} // end func
	
	IEnumerator func_058b() {
		
		int[] locals = new int[44];
		
		yield return StartCoroutine(say( "Thou art @GS8, art thou not?" ));
		locals[22] = 1;
		locals[1] = 25;
		locals[23] = 1;
		locals[2] = 26;
		locals[24] = privateVariables[4];
		locals[3] = 27;
		locals[4] = 0;
		//locals[43] = babl_fmenu( 0, locals[1], locals[22] );
		yield return StartCoroutine (babl_fmenu (0,locals,1,22));
		locals[43] = PlayerAnswer;
		switch ( locals[43] ) {
			
		case 25:
			
			yield return StartCoroutine(func_0603());
			break;
			
		case 26:
			
			yield return StartCoroutine(func_065d());
			break;
			
		case 27:
			
			yield return StartCoroutine(func_0603());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0603() {
		
		int[] locals = new int[23];
		
		privateVariables[4] = 1;
		if ( privateVariables[11] == 1) {
			
			yield return StartCoroutine(say( "Ah!  Why didst thou not say so?" ));
			privateVariables[11] = 0;
		} // end if
		
		yield return StartCoroutine(say( "I was simply going to reward thee for bringing me my book, but now I hear that thou hast met and slain the fearsome Fire Hydra. That eight-headed monster has long menaced our peaceable folk.  Well done!  Thou hast earned an even greater reward!" ));
		locals[1] = 30;
		locals[2] = 31;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0750());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_07ab());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_065d() {
		
		int[] locals = new int[26];
		locals[2] = 32;
		locals[3] = 33;		
		locals[1] = sex( 2, locals[3], locals[2] );

		yield return StartCoroutine(say( "A pity.  I have heard much good said of @SS1." ));
		locals[4] = 35;
		locals[5] = 36;
		locals[6] = 0;
		//locals[25] = babl_menu( 0, locals[4] );
		yield return StartCoroutine(babl_menu (0,locals,4));
		locals[25]= PlayerAnswer;
		switch ( locals[25] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0743());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_06c0());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_06c0() {
		
		int[] locals = new int[28];
		locals[2] = 37;
		locals[3] = 38;		
		locals[1] = sex( 2, locals[3], locals[2] );

		yield return StartCoroutine(say( "Only that @SS1 was a paragon of honesty." ));
		locals[4] = 40;
		locals[5] = 41;
		locals[1] = sex( 2, locals[5], locals[4] );

		locals[6] = 42;
		locals[7] = 43;
		locals[8] = 0;
		//locals[27] = babl_menu( 0, locals[6] );
		yield return StartCoroutine(babl_menu (0,locals,6));
		locals[27]= PlayerAnswer;
		switch ( locals[27] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0743());
			break;
			
		case 2:
			
			privateVariables[11] = 1;
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00c2();yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0743() {
		
		yield return StartCoroutine(say( "Ah, I had thought as much.  Thou didst fit the description." ));
		yield return StartCoroutine(func_0603());
	} // end func
	
	IEnumerator func_0750() {
		
		int[] locals = new int[24];
		
		privateVariables[2] = 1;
		func_00ea( 37 );
		yield return StartCoroutine(say( "Thy reward shall be a powerful book.  Thou shalt find it in a room behind a secret door in the Library." ));
		locals[1] = 46;
		locals[2] = 47;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			locals[23] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			break;
			
		case 2:
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_07ab() {
		
		int[] locals = new int[24];
		
		privateVariables[3] = 1;
		func_00ea( 37 );
		yield return StartCoroutine(say( "Thy honesty is commendable, and thy reward shall be the Book of Honesty.  As Honesty and Truth are beyond Time, thou shalt find it by the key behind the hourglass." ));
		locals[1] = 49;
		locals[2] = 50;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			locals[23] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0806());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0806() {
		
		int[] locals = new int[25];
		
		yield return StartCoroutine(say( "The book was one of Sir Cabirus' Talismans.  'Twas written by Ravenhurst of Moonglow, who collected great works of honesty and essays upon Truth.  It hath great power, both intrinsically and for the wisdom contained therein." ));
		locals[1] = 52;
		locals[2] = 53;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
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
	
	IEnumerator func_0860() {
		
		if ( privateVariables[9]==1 ) {
			
			yield return StartCoroutine(func_0b2e());
		} else {
			
			if ( privateVariables[3]==1 ) {
				
				yield return StartCoroutine(func_0ab7());
			} else {
				
				if ( privateVariables[2] ==1) {
					
					yield return StartCoroutine(func_0968());
				} else {
					
					if ( privateVariables[5]==1 ) {
						
						yield return StartCoroutine(func_0900());
					} else {
						
						yield return StartCoroutine(func_088e());
					} // end if
					
				} // end if
				
			} // end if
			
		} // end if
		
	} // end func
	
	IEnumerator func_088e() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Hello again.  Hast thou an object for me?" ));
		locals[1] = 55;
		locals[2] = 56;
		locals[3] = 57;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0432());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0575());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_08ea());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_08ea() {
		
		int[] locals = new int[2];
		
		yield return StartCoroutine(say( "My fellow mage Bronus wishes to deliver something to me.  Seek him out. If thou bringst the object to me, I may reward thee." ));
		locals[1] = 2;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );
		yield break;
	} // end func
	
	IEnumerator func_0900() {
		
		int[] locals = new int[23];
		
		if ( privateVariables[4]==1 ) {
			
			yield return StartCoroutine(say( "Ah, it is @GS8 again." ));
			yield return StartCoroutine(func_0603());
		} else {
			
			if ( privateVariables[11]==1 ) {
				
				yield return StartCoroutine(say( "Greetings once more.  Hast thou found @GS8 yet?" ));
				locals[1] = 61;
				locals[2] = 62;
				locals[3] = 0;
				yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
				switch ( locals[22] ) {
					
				case 1:
					
					yield return StartCoroutine(func_0603());
					break;
					
				case 2:
					
					yield return StartCoroutine(func_095d());
					break;
				} // end if
				
			} //else {
				
			//	break;
				
			//} // end switch
			
			yield return StartCoroutine(func_058b());
		} // end if
		
	} // end func
	
	IEnumerator func_095d() {
		
		yield return StartCoroutine(say( "Well, if thou findest @GS8, please let me know.  I am looking for him." ));
	} // end func
	
	IEnumerator func_0968() {
		
		int[] locals = new int[45];
		
		if ( privateVariables[10]==1 ) {
			
			yield return StartCoroutine(say( "Hello again.  What dost thou want from me now?" ));
			locals[1] = 65;
			locals[2] = 66;
			locals[3] = 67;
			locals[4] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_0a1f());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_0a1f());
				break;
				
			case 3:
				
				yield return StartCoroutine(func_0a73());
				break;
			} // end if
			
		} //else {
			
		//	break;
			
		//} // end switch
		
		yield return StartCoroutine(say( "Hello, @GS8!  Hast thou found thy reward?" ));
		locals[23] = 69;
		locals[24] = 70;
		locals[25] = 71;
		locals[26] = 0;
		yield return StartCoroutine(babl_menu (0,locals,23));   locals[44] = PlayerAnswer;
		switch ( locals[44] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0a35());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0a50());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_0a73());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0a1f() {
		
		int[] locals = new int[2];
		
		yield return StartCoroutine(say( "How kind of thee.  I wish thee continued luck with thy quests." ));
		locals[1] = 2;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );
		yield break;
	} // end func
	
	IEnumerator func_0a35() {
		
		int[] locals = new int[2];
		
		privateVariables[10] = 1;
		yield return StartCoroutine(say( "I hope thou useth it well, for thou richly deserveth it." ));
		locals[1] = 2;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );
		yield break;
	} // end func
	
	IEnumerator func_0a50() {
		
		int[] locals = new int[2];
		
		yield return StartCoroutine(say( "It should not be hard to find." ));
		if ( privateVariables[3]==1 ) {
			
			yield return StartCoroutine(say( "Remember, it lies with the key behind the hourglass." ));
		} else {
			
			yield return StartCoroutine(say( "Remember, it is behind a secret door in the Library." ));
		} // end if
		
		locals[1] = 2;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );
		yield break;
	} // end func
	
	IEnumerator func_0a73() {
		
		int[] locals = new int[24];
		
		yield return StartCoroutine(say( "Ah!  The truth is out!  Well, at least thou wert honest eventually.  I am not sure whether thou really deservest the Book of Honesty, but perhaps thou hast learned from thy mistakes.  As Honesty and Truth are beyond Time, thou shalt find it by the key behind the hourglass." ));
		privateVariables[3] = 1;
		locals[1] = 78;
		locals[2] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		if ( locals[22] == 1 ) {
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
		} // end if
		
		locals[23] = 2;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[23] );
		yield break;
	} // end func
	
	IEnumerator func_0ab7() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Hello, @GS8!  Hast thou found thy reward?" ));
		locals[1] = 80;
		locals[2] = 81;
		locals[3] = 82;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0b13());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0a50());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_0a50());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0b13() {
		
		int[] locals = new int[2];
		
		privateVariables[9] = 1;
		yield return StartCoroutine(say( "Congratulations!  I hope that it will prove useful to thee." ));
		locals[1] = 3;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );
		yield break;
	} // end func
	
	IEnumerator func_0b2e() {
		
		int[] locals = new int[2];
		
		yield return StartCoroutine(say( "Congratulations again on thy discovery.  I wish thee luck in thy continuing quest." ));
		locals[1] = 3;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );
		yield break;
	} // end func
	/*
	void func_0b44() {
		
		int[] locals = new int[45];
		
		setup_to_barter( 0 );
		while ( !privateVariables[1] ) {
			
			locals[1] = 85;
			locals[2] = 86;
			locals[3] = 87;
			locals[4] = 88;
			locals[5] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				func_0bf5();
				break;
				
			case 2:
				
				func_0c4f();
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
		
		locals[23] = 89;
		locals[24] = 0;
		yield return StartCoroutine(babl_menu (0,locals,23));   locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func

	void func_0bf5() {
		
		int[] locals = new int[16];
		
		locals[0] = -1;
		locals[6] = -1;
		locals[11] = 90;
		locals[12] = 91;
		locals[13] = 92;
		locals[14] = 93;
		locals[15] = 94;
		if ( do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ) ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	void func_0c4f() {
		
		int[] locals = new int[25];
		
		yield return StartCoroutine(say( "Dost thou intend to rob me?" ));
		locals[1] = 96;
		locals[2] = 97;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			return;
			
			break;
			
		} // end switch
		
		locals[23] = 98;
		locals[24] = 99;
		if ( do_demand( 2, locals[24], locals[23] ) ) {
			
			privateVariables[1] = 1;
		} else {
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
		} // end if
		
	} // end func
*/
}
