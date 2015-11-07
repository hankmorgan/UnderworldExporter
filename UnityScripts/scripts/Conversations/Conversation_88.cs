using UnityEngine;
using System.Collections;

public class Conversation_88 : Conversation {

	//conversation #88
	//	string block 0x0e58, name Brawnclan

	
	public override IEnumerator main() {
		SetupConversation (3672);
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
	
	/*void func_00b1() {
		
		npc.npc_attitude = param1[0]play_hunger;
		func_0012();
	} // end func*/
	
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
		
		//int locals[68];
		int[] locals = new int[69];
		
		privateVariables[3] = 1;
		if ( privateVariables[0] == 1) {
			yield return StartCoroutine(say( "A hearty greetings to ye - it is good to meet again.  What can I do for ye now?" ));
			goto label_0319;
		} else {
			
			privateVariables[2] = 1;
			yield return StartCoroutine(say( "It's been a long time since we of the Folk have seen one such as ye.  Be ye an outcast from above, or an outsider?" ));
			locals[1] = 2;
			locals[2] = 3;
			locals[3] = 4;
			locals[4] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[23] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				goto label_0307;
				
				break;
				
			case 2:
				
				goto label_030c;
				
				break;
				
			case 3:
				
				goto label_0316;
				
				break;
				
			} // end switch

		} // end if///moved this here

		label_0307:;
			
		yield return StartCoroutine(say( "Aye, so all of ye say.  Well, it's not me place to cast judgment upon ye.  Behave yourself properly when dealing with the Mountainfolk, that's all we ask.  What else ye do is your own business.  Now, what is it that ye be wanting?" ));
			goto label_0319;
			
		label_030c:;
			
			privateVariables[2] = 0;
		yield return StartCoroutine(say( "Aye, I heard of such a thing.  The Abyss isn't a safe place these days, I tell ye.  Perhaps some other of the Folk might know more about that.  Is there anything else I can help ye with?" ));
			goto label_0319;
			
		label_0316:;
			
		yield return StartCoroutine(say( "Is that so?  Well, the Abyss is nae a place to be searching for fortune. Just a shadow of itself, it is nowadays.  Yet of all the Abyss, we be the ones who still know what fortune is and what to do with it.  Goldthirst, our king, has a hoard to rival any in all of Britannia.\n"
			    + " Now, is there anything I can do for ye?" ));

		label_0319:;
			
			locals[44] = privateVariables[2];
			locals[23] = 8;
			locals[45] = 1;
			locals[24] = 9;
			locals[46] = privateVariables[3];
			locals[25] = 10;
			locals[47] = 1;
			locals[26] = 11;
			locals[27] = 0;
			//locals[65] = babl_fmenu( 0, locals[23], locals[44] );
			yield return StartCoroutine(babl_fmenu (0,locals,23,44));
			locals[65] = PlayerAnswer;

			switch ( locals[65] ) {
				
			case 8:
				
				goto label_030c;
				
				break;
				
			case 9:
				
				goto label_03cd;
				
				break;
				
			case 10:
				
				goto label_03a3;
				
				break;
				
			case 11:
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00e0();
				yield break;
				break;
				
			} // end switch
			
		label_03a3:;
			
			privateVariables[3] = 0;
			locals[66] = 13;
			locals[67] = 30;
			locals[68] = 0;
			gronk_door( 3, locals[68], locals[67], locals[66] );
		yield return StartCoroutine(say( "Very well, ye seem a reasonable sort.  Just mind your manners and ye'll nae have trouble with the Folk.  Now, before ye meet the rest of the clan, is there anything else ye'll be wanting?" ));
			goto label_0319;
			
		label_03cd:;
			
			yield return StartCoroutine(say( "Very well, let's see what ye've found in your adventures." ));
			yield return StartCoroutine(func_03df());
			yield return StartCoroutine(say( "Farewell." ));
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
		//} // end if
		
		//say( "A hearty greetings to ye - it is good to meet again.  What can I do for ye now?" );
		//goto label_0319;
		
	} // end func
	
	IEnumerator func_03df() {
		
		//int locals[44];
		int[] locals=new int[45];
		
		setup_to_barter( 0 );
		while ( privateVariables[1] == 0 ) {
			
			locals[1] = 16;
			locals[2] = 17;
			locals[3] = 18;
			locals[4] = 19;
			locals[5] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_0490());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_04ea());
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
		
		locals[23] = 20;
		locals[24] = 0;
		//locals[44] = babl_menu( 0, locals[23] );
		yield return StartCoroutine(babl_menu (0,locals,23));
		locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_0490() {
		
		//int locals[15];
		int[] locals = new int[16];
		locals[0] = -1;
		locals[6] = -1;
		locals[11] = 21;
		locals[12] = 22;
		locals[13] = 23;
		locals[14] = 24;
		locals[15] = 25;

		yield return StartCoroutine (do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ));
		if (PlayerAnswer==1){
		//if ( do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ) ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_04ea() {
		
		//int locals[24];
		int[] locals=new int[25];
		
		yield return StartCoroutine(say( "Dost thou intend to rob me?" ));
		locals[1] = 27;
		locals[2] = 28;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			yield break;
			//return;
			
			break;
			
		} // end switch
		
		locals[23] = 29;
		locals[24] = 30;
//		if ( do_demand( 2, locals[24], locals[23] ) ) {
		yield return StartCoroutine (do_demand( 2, locals[24], locals[23] ));
		if (PlayerAnswer==1){
			
			privateVariables[1] = 1;
		} else {
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_008b();
			yield break;
		} // end if
		
	} // end func


}
