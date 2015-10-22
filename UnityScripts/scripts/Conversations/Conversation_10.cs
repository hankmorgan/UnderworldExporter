using UnityEngine;
using System.Collections;

public class Conversation_10 : Conversation {

	//conversation #10
	//	string block 0x0e0a, name Lanugo
			

	public override IEnumerator main() {
		SetupConversation (3594);
		privateVariables[1] = 0;
		yield return StartCoroutine(func_029d());
		func_0012();
		//this.GetComponent<NPC>().state= NPC.AI_STATE_IDLERANDOM;
		yield return 0;
	} // end func
	
	void func_0012() {
		EndConversation();
		privateVariables[0] = 1;
	} // end func
	
/*	void func_0020() {
		
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
	
	IEnumerator func_008b() {
		
		npc.npc_gtarg = 1;
		npc.npc_goal = 5;
		npc.npc_attitude = 1;
		func_0012();
		yield break;
	} // end func
	
	/*void func_00a4() {
		
		npc.npc_attitude = 6;
	} // end func*/
	
	IEnumerator func_00b1(int unk) {
		
		npc.npc_attitude = param1[0];//play_hunger;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_0012();
		yield break;
	} // end func
	
	IEnumerator func_00c2() {
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		npc.npc_attitude = 2;
		func_0012();
		yield break;
	} // end func
	
	/*void func_00d1() {
		
		npc.npc_attitude = 1;
		func_0012();
	} // end func*/
	
	IEnumerator func_00e0() {
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_0012();
		yield break;
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
	} // end func
	*/
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
	
	IEnumerator  func_029d() {
		
	//	int locals[22];
		int[] locals=new int[23];	
		if ( privateVariables[0] == 1 ) {
			
			yield return StartCoroutine(func_0562());
		} else {
			
			privateVariables[2] = 0;
			yield return StartCoroutine(say( "Tha be not bodderin' da boss, aye?" ));
			locals[1] = 2;
			locals[2] = 3;
			locals[3] = 4;
			locals[4] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine( babl_menu( 0,locals,1 ));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_030a());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_035e());
				break;
				
			case 3:
				
				yield return StartCoroutine(func_03aa());
				break;
			} // end if
			
			//break;
			
		} // end switch
		
	} // end func
	
	IEnumerator  func_030a() {
		
		//int locals[23];
		int[] locals=new int[24];
		yield return StartCoroutine(say( "Good. It be not healty ta bodder a guy like da boss." ));
		locals[1] = 6;
		locals[2] = 8;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine( babl_menu( 0,locals,1 ));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(say( "Dat's okay den.  Hey, I better tend to my stew.  You come back if you want some." ));
			locals[23] = 2;
			yield return StartCoroutine(func_00b1( locals[23] ));
			break;
			
		case 2:
			
			func_03aa();
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator  func_035e() {
		
		//int locals[7];
		int[] locals=new int[8];
		locals[1] = sex( 2, locals[4], locals[3] );
		locals[3] = 9;
		locals[4] = 10;
		locals[2] = sex( 2, locals[6], locals[5] );
		locals[5] = 11;
		locals[6] = 12;
		yield return StartCoroutine(say( "Oh, a smart one, eh?  One a' dem Sages.  Thinks @SS1 too smart for me, eh?  Maybe too smart for @SS2, more like.  Fine - I'm busy making dinner.  This stew takes work, you know." ));
		locals[7] = 1;
		yield return StartCoroutine(func_00b1( locals[7] ));
		yield break;
	} // end func
	
	IEnumerator  func_03aa() {
		
		//int locals[22];
		int[] locals=new int[23];
		yield return StartCoroutine(say( "Yeah, well, I could do dat.  But da boss don' like to be boddered wid, like, practical stuff.   His mind is on, uh higher tings." ));
		locals[1] = 15;
		locals[2] = 16;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine( babl_menu( 0,locals,1 ));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_051a());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_03f2());
			break;
			
		} // end switch

		yield break;
	} // end func
	
	IEnumerator  func_03f2() {
		
		//int locals[62];
		int[] locals=new int[63];
		//Rewrite this
		//What I think should be happening is show_inv is getting the list of objects and their slots.
		//I then search that list for the matching objects In this case a gold coin or gold coins.
		//I flag locals[18] if they are there.
		//I will need to change the call for show inv as well.
		//locals[16] = show_inv( 2, locals[6], locals[1] );
		locals[16] = show_inv (2,locals, 6, 1);
		locals[18] = 0;
		int j=0;
		for (int i = 0; i<locals[16];i++)
		{
			if ((locals[6+i] == 160) || (locals[6+i]==161))
			{//If the object is gold
				locals[18]++;//number of matches
				locals[11+j]= locals[1+i];
				j++;
			}
		}
		/*
		while ( locals[16] > 0 ) {
			
			locals[17] = 1;
			if ( locals[17] <= locals[16] ) {
				
				if ( (locals[0] == 160 || locals[0] == 161) ) {
					
					locals[18] = locals[18] + 1;
					locals[10] = locals[5];
				} // end if
				
				locals[17] = locals[17] + 1;
			} // while

		} // end if
		*/
		if ( locals[18] > 0 ) {
			
			//give_to_npc( 2, locals[11], locals[18] );
			give_to_npc(2,locals,locals[18],11);
			privateVariables[2] = 0;
			yield return StartCoroutine(say( "Tanks!  Th'art right enough, fer a yuman.  Tell tha what -- if tha talks to da boss, be real, like complimennary.  He likes dat." ));
			locals[19] = 18;
			locals[20] = 19;
			locals[21] = 0;
			//locals[40] = babl_menu( 0, locals[19] );
			yield return StartCoroutine( babl_menu( 0,locals,19 ));
			locals[40] = PlayerAnswer;
			switch ( locals[40] ) {
				
			case 1:
				
				yield return StartCoroutine(func_051a());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_051a());
				break;
			} // end if
			
		} 
		else {
			
			//break;
			
		//} // end switch
		
		if ( locals[16] == 0 ) {
			
			yield return StartCoroutine(say( "I don' see no gift!" ));
		} else {
			
			yield return StartCoroutine(say( "Dontcha have any gold or something?" ));
		} // end if
		
		locals[41] = 22;
		locals[42] = 23;
		locals[43] = 0;
		//locals[62] = babl_menu( 0, locals[41] );
		yield return StartCoroutine( babl_menu( 0,locals,41 ));
		locals[62] = PlayerAnswer;
		switch ( locals[62] ) {
			
		case 1:
			
			yield return StartCoroutine(func_03f2());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0504());
			break;
			
		} // end switch
		}//Added end bracket for else
	} // end func
	
	IEnumerator  func_0504() {
		
		//int locals[1];
		int[] locals=new int[2];
		yield return StartCoroutine(say( "Y'got plenny t'learn in da ways of courtly manners, I'd say.  Okay by me - I got my stew to tend to." ));
		locals[1] = 1;
		yield return StartCoroutine(func_00b1( locals[1] ));
		yield break;
	} // end func
	
	IEnumerator  func_051a() {
		
		//int locals[22];
		int[] locals=new int[23];
		yield return StartCoroutine(say( "Sure ting.  Hey, gotta go.  Time fer me ta start dinner.  Y'wanna stay?  S'worm stew, tonight. Me speciality." ));
		locals[1] = 26;
		locals[2] = 27;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine( babl_menu( 0,locals,1 ));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_05c6());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_00e0());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator  func_0562() {
		
		//int locals[22];
		int[] locals=new int[23];
		if ( privateVariables[2] == 1) {
			
			yield return StartCoroutine(say( "Oh, this guy again.  What it be now?" ));
		} // end if
		
		yield return StartCoroutine(say( "Come back for me stew, have tha?  Smell brought tha?  Don't blame tha, 'tis a good stew." ));
		locals[1] = 30;
		locals[2] = 31;
		locals[3] = 32;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine( babl_menu( 0,locals,1 ));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_05c6());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_00e0());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_03aa());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator  func_05c6() {
		
		//int locals[25];
		int[] locals=new int[26];
		yield return StartCoroutine(say( "Aye, me modder used ta make it.  Tha takes a rotworm, chops it up fine, and marinates it in port wiv mushrooms." ));
		locals[2] = 1019;
		locals[1] = take_from_npc( 1, locals[2] );
		locals[3] = locals[1];
		if ( 2 == locals[3] ) {
			
			yield return StartCoroutine(say( "I'll leave this recipe on the floor for tha." ));
		} else {
			
			if ( 1 == locals[3] ) {
				
				yield return StartCoroutine(say( "Here.  'Tis all writ down on this." ));
			} else {
				
				if ( 0 == locals[3] ) {
					
					yield return StartCoroutine(say( "Tha knowest, just like the recipe I gave tha." ));
				} // end if
				
			} // end if
			
		} // end if
		
		locals[4] = 37;
		locals[5] = 38;
		locals[6] = 0;
		//locals[25] = babl_menu( 0, locals[4] );
		yield return StartCoroutine( babl_menu( 0,locals,4 ));
		locals[25] = PlayerAnswer;
		switch ( locals[25] ) {
			
		case 1:
			
			yield return StartCoroutine(func_00e0());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_00c2());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_064e() {
		
		//int locals[44];
		int[] locals=new int[45];
		setup_to_barter( 0 );
		while ( privateVariables[1] !=1 ) {
			
			locals[1] = 39;
			locals[2] = 40;
			locals[3] = 41;
			locals[4] = 42;
			locals[5] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine( babl_menu( 0,locals,1 ));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_06ff());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_0759());
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
		
		locals[23] = 43;
		locals[24] = 0;
		//locals[44] = babl_menu( 0, locals[23] );
		yield return StartCoroutine( babl_menu( 0,locals,23 ));
		locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_06ff() {
		
		//int locals[15];
		int[] locals=new int[16];
		locals[0] = -1;
		locals[6] = -1;
		locals[11] = 44;
		locals[12] = 45;
		locals[13] = 46;
		locals[14] = 47;
		locals[15] = 48;
		yield return StartCoroutine (do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ));
		//if ( do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ) == 1) {
		if (PlayerAnswer==1){
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_0759() {
		
		//int locals[24];
		int[] locals=new int[25];
		yield return StartCoroutine(say( "Dost thou intend to rob me?" ));
		locals[1] = 50;
		locals[2] = 51;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine( babl_menu( 0,locals,1 ));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			yield break;
			
			break;
			
		} // end switch
		
		locals[23] = 52;
		locals[24] = 53;
		yield return StartCoroutine (do_demand( 2, locals[24], locals[23] ));
	//	if ( do_demand( 2, locals[24], locals[23] )==1 ) {
		if (PlayerAnswer==1){
			privateVariables[1] = 1;
		} else {

			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
		    yield return StartCoroutine ( func_008b());
			yield break;
		} // end if
		
	} // end func
}
