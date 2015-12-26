using UnityEngine;
using System.Collections;

public class Conversation_25 : Conversation {


	//conversation #25
	//	string block 0x0e19, name Door
			
	
	public override IEnumerator main() {
		SetupConversation (3609);
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
	*/
	void func_008b() {
		
		npc.npc_gtarg = 1;
		npc.npc_goal = 5;
		npc.npc_attitude = 1;
		func_0012();
	} // end func
	/*
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
		
		int[] locals = new int[27];

		locals[2] = 4;
		locals[3] = 2;
		locals[4] = 1;
		//I'm not gronking the door because I've already opened it as part of the function call.
		//locals[1] = gronk_door( 3, locals[4], locals[3], locals[2] );

		if ( privateVariables[0] ==1) {
			
			yield return StartCoroutine(func_033a());
		} else {
			
			privateVariables[2] = 0;
			privateVariables[3] = 0;
			privateVariables[4] = 0;
			privateVariables[5] = 0;
			yield return StartCoroutine(say( "So!  Another young fool opens a door thoughtlessly.  Open, close, open, close, that's all that anyone ever has the time for.  Things were not like this when I was thy age, I can assure thee of that!  Well?  Hast thou anything to say for thyself?" ));
			locals[5] = 2;
			locals[6] = 3;
			locals[7] = 4;
			locals[8] = 0;
			//locals[26] = babl_menu( 0, locals[5] );
			yield return StartCoroutine(babl_menu (0,locals,5));
			locals[26] = PlayerAnswer;
			switch ( locals[26] ) {
				
			case 1:
				
				yield return StartCoroutine(func_036a());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_0389());
				break;
				
			case 3:
				
				yield return StartCoroutine(func_0377());
				break;
			} // end if
			

			
		} // end switch
		
	} // end func
	
	IEnumerator func_033a() {
		
		if ( privateVariables[2]==1 ) {
			
			yield return StartCoroutine(say( "Perhaps if thou wert more civil, thou couldst open more doors!" ));
			privateVariables[2] = 0;
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
		} else {
			
			yield return StartCoroutine(say( "Thou again!  What dost thou want this time!" ));
			if ( privateVariables[4] ==1) {
				
				yield return StartCoroutine(func_056c());
			} else {
				
				if ( privateVariables[3] ==1) {
					
					yield return StartCoroutine(func_061e());
				} else {
					
					yield return StartCoroutine(func_05c5());
				} // end if
				
			} // end if
			
		} // end if
		
	} // end func
	
	IEnumerator func_036a() {
		
		yield return StartCoroutine(say( "Hmmph!  Perhaps the next time thou wilt show greater civilty to thy elders!" ));
		Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
	} // end func
	
	IEnumerator func_0377() {
		
		privateVariables[2] = 1;
		yield return StartCoroutine(say( "Bah!  Such disrepect!  I will open when I wish to open!" ));
		Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
	} // end func
	
	IEnumerator func_0389() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "What do I look like, a drawbridge?" ));
		locals[1] = 10;
		locals[2] = 11;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_036a());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_03d1());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03d1() {
		
		int[] locals = new int[23];
		
		privateVariables[3] = 1;
		yield return StartCoroutine(say( "I once was a young human like thyself.  But I grew weary of the regular folk and their immense stupidity.  I was a brilliant mage, and was constantly pestered with silly questions, such as \"How does one cast Sheet Lightning?\" \n "
		                                +" Tiring of being hounded thus, I turned myself into a door in order to finally enjoy some peace and quiet.  Obviously, it didn't work." ));
		locals[1] = 13;
		locals[2] = 14;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_041e());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0470());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_041e() {
		
		int[] locals = new int[23];
		
		privateVariables[4] = 1;
		privateVariables[3] = 0;
		yield return StartCoroutine(say( "Gaaah!  I cannot believe thou wouldst ask that, of all questions!  I should have known better than to mention that accursed spell. \n"
		                                +" If thou must know, it is cast by using the Vas, Ort and Grav runestones.  There.  I hope that thou blowest thyself up with it." ));
		locals[1] = 16;
		locals[2] = 17;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
			break;
			
		case 2:
			
			yield return StartCoroutine(func_036a());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0470() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Art thou implying that my power is not great enough to turn myself into whatever I want?  If I wanted to, I could turn myself into a nutcracker and thee into a walnut!  Wouldst thou like that?" ));
		locals[1] = 19;
		locals[2] = 20;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_04b8());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_036a());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_04b8() {
		
		int[] locals = new int[44];
		
		yield return StartCoroutine(say( "Well then, didst thou attempt to open me for a reason, or simply because my doorknob was a bright shiny object?" ));
		locals[22] = privateVariables[3];
		locals[1] = 22;
		locals[23] = 1;
		locals[2] = 23;
		locals[24] = 1;
		locals[3] = 24;
		locals[4] = 0;
		//locals[43] = babl_fmenu( 0, locals[1], locals[22] );
		yield return StartCoroutine(babl_fmenu (0,locals,1,22));
		locals[43] = PlayerAnswer;
		switch ( locals[43] ) {
			
		case 22:
			
			yield return StartCoroutine(func_041e());
			break;
			
		case 23:
			
			yield return StartCoroutine(func_0530());
			break;
			
		case 24:
			
			yield return StartCoroutine(func_036a());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0530() {
		
		int[] locals = new int[5];
		
		yield return StartCoroutine(say( "Very well, if it means that thou wilt not bother me again." ));
		locals[1] = gronk_door( 3, locals[4], locals[3], locals[2] );
		locals[2] = 4;
		locals[3] = 2;
		locals[4] = 0;
		if ( locals[1] == 0 ) {
			
			yield return StartCoroutine(say( "Unfortunately, my hinges seem to be somewhat rusty." ));
		} // end if
		
		Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
	} // end func
	
	IEnumerator func_056c() {
		
		int[] locals = new int[23];
		
		locals[1] = 27;
		locals[2] = 28;
		locals[3] = 29;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0530());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0677());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_036a());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_05c5() {
		
		int[] locals = new int[23];
		
		locals[1] = 30;
		locals[2] = 31;
		locals[3] = 32;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_03d1());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0530());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_036a());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_061e() {
		
		int[] locals = new int[23];
		
		locals[1] = 33;
		locals[2] = 34;
		locals[3] = 35;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_041e());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0530());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_036a());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0677() {
		
		if ( privateVariables[5]==1 ) {
			
			yield return StartCoroutine(say( "I refuse to help thee with that any more!" ));
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
		} else {
			
			privateVariables[5] = 1;
			yield return StartCoroutine(say( "Again!?  For the last time, the spell is cast by using the Vas, Ort, and Grav runestones.  I don't know why I'm bothering to tell thee. Thou obviously hast not the intelligence necessary to cast it." ));
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
		} // end if
		
	} // end func
	
	IEnumerator func_0695() {
		
		int[] locals = new int[45];
		
		setup_to_barter( 0 );
		while ( privateVariables[1]==0 ) {
			
			locals[1] = 38;
			locals[2] = 39;
			locals[3] = 40;
			locals[4] = 41;
			locals[5] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_0746());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_07a0());
				break;
				
			case 3:
				
				yield return StartCoroutine(do_judgement( 0 ));
				break;
				
			case 4:
				
				do_decline( 0 );
				privateVariables[1] = 1;
				break;
				
			} // end switch
			
		} // while
		
		locals[23] = 42;
		locals[24] = 0;
		yield return StartCoroutine(babl_menu (0,locals,23));   locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_0746() {
		
		int[] locals = new int[16];
		
		locals[0] = -1;
		locals[6] = -1;
		locals[11] = 43;
		locals[12] = 44;
		locals[13] = 45;
		locals[14] = 46;
		locals[15] = 47;
		//if ( do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ) ) {
		yield return StartCoroutine (do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6],locals[1]) );
		if (PlayerAnswer==1)	{
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_07a0() {
		
		int[] locals = new int[25];
		
		yield return StartCoroutine(say( "Dost thou intend to rob me?" ));
		locals[1] = 49;
		locals[2] = 50;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			yield break;
			//return;
			
			break;
			
		} // end switch
		
		locals[23] = 51;
		locals[24] = 52;
		//if ( do_demand( 2, locals[24], locals[23] ) ) {
		yield return StartCoroutine (do_demand( 2, locals[24], locals[23] ));
		if (PlayerAnswer==1){	
			privateVariables[1] = 1;
		} else {
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
		} // end if
		
	} // end func
}
