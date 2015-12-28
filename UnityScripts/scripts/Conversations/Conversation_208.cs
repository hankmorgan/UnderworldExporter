using UnityEngine;
using System.Collections;

public class Conversation_208 : Conversation {

	//conversation #208
	//	string block 0x0ed0, name Cardon
	public int[] global= new int[1];	
	public override IEnumerator main() {
		SetupConversation (3792);
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
		
		npc.npc_attitude = param1[0]global[0];
		func_0012();
	} // end func
	*/
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
		
		int[] locals = new int[23];
		
		if ( privateVariables[0] == 1 ) {
			
			yield return StartCoroutine(func_0566());
		} // end if
		
		yield return StartCoroutine(say( "Who art thou?  What >cough< what dost thou want?" ));
		locals[1] = 2;
		locals[2] = 3;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_02ef());
			break;
			
		case 2:
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00c2();yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_02ef() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Canst heal my wounds?  Or >cough< hast thou any port?" ));
		locals[1] = 5;
		locals[2] = 6;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0337());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_03b8());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0337() {
		
		int[] locals = new int[17];
		
		locals[15] = 0;
		//locals[13] = show_inv( 2, locals[6], locals[1] );
		locals[13]= show_inv (2,locals,6,1);
		int counter=0;
		while ( locals[13] > 0 ) {
			
			locals[14] = 1;
			if ( locals[14] <= locals[13] ) {
				
				if ( locals[1+counter] == 190 ) {
					
					locals[15] = locals[14];
					locals[11] = locals[6+counter];
				} // end if
				
				locals[14] = locals[14] + 1;
			} // while
			locals[13]--;
			counter++;
		} // end if
		
		if ( locals[15] > 0 ) {
			
			locals[16] = 1;
			//give_to_npc( 2, locals[11], locals[16] );
			give_to_npc(2,locals,11,1);
			yield return StartCoroutine(say( "I thank thee greatly!" ));
			yield return StartCoroutine(func_03c5());
		} else {
			
			yield return StartCoroutine(say( "What, dost thou mock me?  Begone with ye!" ));
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);
			func_00d1();
			yield break;
		} // end if
		
	} // end func
	
	IEnumerator func_03b8() {
		
		yield return StartCoroutine(say( "At least thou seemest in better condition than I." ));
		yield return StartCoroutine(func_03c5());
	} // end func
	
	IEnumerator func_03c5() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Here is some advice for thee: Beware, for death is everywhere!" ));
		locals[1] = 11;
		locals[2] = 12;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_040d());
			break;
			
		case 2:
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_040d() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "I'm here to rescue my brother. He's in the prisons." ));
		locals[1] = 14;
		locals[2] = 15;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0455());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_057e());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0455() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Several cells lie to the north and west of here.  He rots in one of those." ));
		locals[1] = 17;
		locals[2] = 18;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_049d());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_057e());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_049d() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "He is in the clutches of the evil wizard who dominates this area.  My brother came to explore this place months ago and I have not heard from him since.  I believe he has run afoul of this vile and violent mage." ));
		locals[1] = 20;
		locals[2] = 21;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_04e5());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_057e());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_04e5() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Rumor has it that he is the reason no one can cast spells on this level. Also, he uses monsters as henchmen to guard the way to his lair.  But I have figured out how to get by these guards!" ));
		locals[1] = 23;
		locals[2] = 24;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_052d());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_057e());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_052d() {
		
		int[] locals = new int[23];
		
		global[0] = 1;
		yield return StartCoroutine(say( "A medallion of passage!  I had one but I lost it while in battle in the haunted mines to the southeast. Now I am too weak to recover it, and just wish to return home. But perhaps thou..." ));
		locals[1] = 26;
		locals[2] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		if ( locals[22] == 1 ) {
			
			yield return StartCoroutine(func_057e());
		} // end if
		
	} // end func
	
	IEnumerator func_0566() {
		
		if ( global[0] == 0) {
			
			yield return StartCoroutine(say( "Thou dost not wish to hear all I would tell thee?  Well, hear this, for it may prevent thee from ending up like I have.  A medallion of passage is needed to pass by the guards. It lies in the haunted mines in the southeast.  Now go, if thou art determined to brave the perils of these caves! /m" ));
			remove_talker( 0 );
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
		} // end if
		
	} // end func
	
	IEnumerator func_057e() {
		
		int[] locals = new int[23];
		
		remove_talker( 0 );
		yield return StartCoroutine(say( "Is that so?  Well, farewell, then.  I will rejoin my comrades up above." ));
		locals[1] = 29;
		locals[2] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		if ( locals[22] == 1 ) {
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
		} // end if
		
	} // end func
	/*
	void func_05b7() {
		
		int[] locals = new int[45];
		
		setup_to_barter( 0 );
		while ( !privateVariables[1] ) {
			
			locals[1] = 30;
			locals[2] = 31;
			locals[3] = 32;
			locals[4] = 33;
			locals[5] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				func_0668();
				break;
				
			case 2:
				
				func_06c2();
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
		
		locals[23] = 34;
		locals[24] = 0;
		yield return StartCoroutine(babl_menu (0,locals,23));   locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	void func_0668() {
		
		int[] locals = new int[16];
		
		locals[0] = -1;
		locals[6] = -1;
		locals[11] = 35;
		locals[12] = 36;
		locals[13] = 37;
		locals[14] = 38;
		locals[15] = 39;
		if ( do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ) ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	void func_06c2() {
		
		int[] locals = new int[25];
		
		yield return StartCoroutine(say( "Dost thou intend to rob me?" ));
		locals[1] = 41;
		locals[2] = 42;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			return;
			
			break;
			
		} // end switch
		
		locals[23] = 43;
		locals[24] = 44;
		if ( do_demand( 2, locals[24], locals[23] ) ) {
			
			privateVariables[1] = 1;
		} else {
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
		} // end if
		
	} // end func

*/

}
