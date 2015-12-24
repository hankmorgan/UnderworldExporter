using UnityEngine;
using System.Collections;

public class Conversation_6 : Conversation {
	
	
	//conversation #6
	//string block 0x0e06, name Marrowsuck
	
	int func_0807_result;
	public override IEnumerator main() {
		SetupConversation (3590);
		privateVariables[1] = 0;
		yield return StartCoroutine(func_029d());
		func_0012();
		yield return 0;
	} // end func
	
	void func_0012() {
		EndConversation();
		privateVariables[0] = 1;
	} // end func
	
	int func_0020() {
		
		int[] locals = new int[2];
		
		if ( (((npc.npc_goal == 5 || npc.npc_goal == 6) || npc.npc_goal == 9) && npc.npc_gtarg == 1 || npc.npc_attitude == 0) ) {
			
			locals[1] = 0;
		} else {
			
			locals[1] = 1;
		} // end if
		
		return locals[1];
	} // end func
	/*
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
	*/
	void func_00b1(int param1) {
		
		npc.npc_attitude =param1 ;//param1[0]play_hunger;
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
	
	void func_00ea(int param1, int param2) {
		/*TODO figure out
		param1[1] = game_days;
		param1[2] = game_mins;
		*/
	} // end func
	
	int func_0106( int param1, int param2) {
		return 1;//TODO:figure out
		/*int[] locals = new int[5];
		
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
		*/
	} // end func
	
	void func_018f(int param1, int param2, int param3) {
		/*

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
		*/
	} // end func
	
	/*
	 * void func_0243() {
		
		param1[1] = game_days - param2[1];
		param1[2] = game_mins - param2[2];
		if ( param1[2] < 0 ) {
			
			param1[2] = param1[2] + 1440;
			param1[1] = param1[1] - 1;
		} // end if
		
	} // end func
	*/
	IEnumerator func_029d() {
		
		int[] locals = new int[314];
		
		if ( privateVariables[0] == 1) {
			
			if ( privateVariables[4] == 1) {
				yield return StartCoroutine(say( "Hey, me already give you boots." ));
				locals[313] = 2;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[313] );
				yield break;
			} else {
				
				if ( privateVariables[2] == 1) {
					
					if ( privateVariables[5]  ==1) {
						if ( func_0106( 40, 37 ) == 0) {
							
							func_018f( locals[1], 40, 37 );
							if ( locals[2] == 1 ) {
								
								locals[6] = 47;
							} else {
								
								locals[6] = 48;
							} // end if
							
							yield return StartCoroutine(say( "Me said it would be half hour.  Come back in @SI1C2 @SS6." ));
							locals[283] = 2;
							Time.timeScale =SlomoTime;
							yield return new WaitForSeconds(WaitTime);
							func_00b1( locals[283] );
							yield break;
						} // end if
						
						if ( privateVariables[3]== 0 ) {
							
							privateVariables[3] = 1;
							locals[284] = 285;
							do_inv_delete( 1, locals[284] );
							locals[285] = 284;
							do_inv_delete( 1, locals[285] );
							locals[286] = 47;
							do_inv_create( 1, locals[286] );
						} // end if
						
						yield return StartCoroutine(say( "Okay, me make boots.  You got food to pay?" ));
						//	if ( yield return StartCoroutine(say( "" ) ) {
						yield return StartCoroutine(func_0807());
						if (func_0807_result==0)
						{
							locals[287] = 2;
							Time.timeScale =SlomoTime;
							yield return new WaitForSeconds(WaitTime);
							func_00b1( locals[287] );
							yield break;
						}
						//_asm ??? (0x0544)
						//	_asm ??? (0x0033)

						//	} // end if
						
						yield return StartCoroutine(say( "Okay, here your boots.  So long." ));
						privateVariables[4] = 1;
						locals[288] = 47;
						if ( take_from_npc( 1, locals[288] ) == 2 ) {
							
							yield return StartCoroutine(say( "You arms full, I leave on floor." ));
						} // end if
						
						locals[289] = 2;
						Time.timeScale =SlomoTime;
						yield return new WaitForSeconds(WaitTime);
						func_00b1( locals[289] );
						yield break;
					} else {
						//You got the material question.
						yield return StartCoroutine(label_05de(locals));


					} // end if
				
				} // end if
				else
				{
					locals[117] = npc.npc_attitude;
					if ( 1 == locals[117] ) {
						
						yield return StartCoroutine(say( "Get 'way from me. You not good customer!" ));
					} else {
						
						if ( 2 == locals[117] ) {
							
							yield return StartCoroutine(say( "Hello." ));
						} else {
							
							if ( 3 == locals[117] ) {
								
								yield return StartCoroutine(say( "Good see you again!  How you be?" ));
							} // end if
							
						} // end if
						
					} // end if
					
					locals[118] = 19;
					locals[119] = 20;
					locals[120] = 0;
					//locals[139] = babl_menu( 0, locals[118] );
					yield return StartCoroutine(babl_menu (0,locals,118));
					locals[139] = PlayerAnswer;
					switch ( locals[139] ) {
						
					case 1:
						
						Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
						break;
						
					case 2:
						
						yield return StartCoroutine( label_0483(locals));
						
						break;
						
					} // end switch
				}



				

				
			} // end if
		} else {
			
			privateVariables[2] = 0;
			privateVariables[3] = 0;
			privateVariables[4] = 0;
			privateVariables[5] = 0;
			yield return StartCoroutine(say( "Who be you?" ));
			locals[7] = 2;
			locals[8] = 3;
			locals[9] = 0;
			//locals[28] = babl_menu( 0, locals[7] );
			yield return StartCoroutine(babl_menu (0,locals,7));
			locals[28] = PlayerAnswer;
			switch ( locals[28] ) {
				
			case 1:
				
				yield return StartCoroutine( label_02ff(locals));
				
				break;
				
			case 2:
				
				yield return StartCoroutine( label_07a6(locals));
				
				break;
				
			} // end switch
			
			
		} // end if
			
		//yield break;	
			
			

			
			

			


		
		

	} // end func
	
	//} // end if
	
	//}		
	IEnumerator func_0807() {
		
		int[] locals = new int[27];
		
		
		
		locals[3] = 59;
		locals[4] = 61;
		locals[5] = 0;
		//locals[24] = babl_menu( 0, locals[3] );
		yield return StartCoroutine(babl_menu (0,locals,3));
		locals[24] = PlayerAnswer;
		switch ( locals[24] ) {
			
		case 1:
			locals[25] = 1011;
			locals[2] = find_barter( 1, locals[25] );

			if ( locals[2] == 0 ) {
				
				yield return StartCoroutine(say( "Hey, me no see any food!" ));
				locals[1] = 0;
				goto label_0886;
			}// else {
			
			break;
			
		case 2:
			
			locals[1] = 0;
			goto label_0886;
			
			break;
			
		} // end switch
		//
		locals[26] = -1;
		give_ptr_npc( 2, locals[26], locals[2]-1 );//Minus 1 for slot.
		locals[1] = 1;
		goto label_0886;
		
	label_0886:;
		
		//return locals[1];
		func_0807_result=locals[1];
	} // end func
	
	void func_088e() {
		/*TODO Figure this out
				privateVariables[12][1] = 1011;
				privateVariables[12][2] = 1012;
				privateVariables[12][3] = 1013;
				privateVariables[12][4] = -1;
				privateVariables[33][1] = 1019;
				privateVariables[33][2] = 1002;
				privateVariables[33][3] = 1000;
				privateVariables[33][4] = 1001;
				privateVariables[33][5] = 1003;
				privateVariables[33][6] = 1019;
				privateVariables[33][7] = -1;
				*/
		set_likes_dislikes( 2, 64, 43 );
	} // end func
	
	IEnumerator func_08fb() {
		
		int[] locals = new int[23];
		
		if ( func_0020() == 0 ) {
			
		} else {
			
			yield return StartCoroutine(say( "You want trade some things?" ));
			locals[1] = 63;
			locals[2] = 64;
			locals[3] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_094b());
				break;
				
			case 2:
				yield break;
				//return;
				break;
			} // end if		
			
			
		} // end switch
		
	} // end func
	
	IEnumerator func_094b() {
		
		int[] locals = new int[45];
		
		setup_to_barter( 0 );
		while ( privateVariables[1] == 0) {
			
			locals[1] = 65;
			locals[2] = 66;
			locals[3] = 67;
			locals[4] = 68;
			locals[5] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(	func_09fc());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_0a3e());
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
		
		locals[23] = 69;
		locals[24] = 0;
		yield return StartCoroutine(babl_menu (0,locals,23));   locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_09fc() {
		
		int[] locals = new int[6];
		
		locals[1] = 70;
		locals[2] = 71;
		locals[3] = 72;
		locals[4] = 73;
		locals[5] = 74;
		//if ( do_offer( 5, locals[5], locals[4], locals[3], locals[2], locals[1] ) ) {
		yield return StartCoroutine (do_offer( 5, locals[5], locals[4], locals[3], locals[2], locals[1], 0,0) );
		if (PlayerAnswer==1)	{
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_0a3e() {
		
		int[] locals = new int[25];
		
		yield return StartCoroutine(say( "Hey!  You try and rob me?" ));
		locals[1] = 76;
		locals[2] = 77;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			//return;
			yield break;
			
			break;
			
		} // end switch
		
		locals[23] = 78;
		locals[24] = 79;
		//if ( do_demand( 2, locals[24], locals[23] ) ) {
		yield return StartCoroutine (do_demand( 2, locals[24], locals[23] ));
		if (PlayerAnswer==1){	
			privateVariables[1] = 1;
		} else {
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
		} // end if
		
	} // end func
	
	
	
	
	
	IEnumerator label_02ff(int[] locals)
	{
		yield return StartCoroutine(say( "Huh.  Me Marrowsuck, the tailor." ));
		locals[29] = 5;
		locals[30] = 6;
		locals[31] = 0;
		//locals[50] = babl_menu( 0, locals[29] );
		yield return StartCoroutine(babl_menu (0,locals,29));
		locals[50] = PlayerAnswer;
		switch ( locals[50] ) {
			
		case 1:
			
			yield return StartCoroutine( label_033f(locals));
			
			break;
			
		case 2:
			
			yield return StartCoroutine( label_037f(locals));
			
			break;
			
		} // end switch
	}
	
	
	IEnumerator label_033f(int[] locals)
	{
		yield return StartCoroutine(say( "You think ghoul no make good tailor?" ));
		locals[51] = 8;
		locals[52] = 9;
		locals[53] = 0;
		//locals[72] = babl_menu( 0, locals[51] );
		yield return StartCoroutine(babl_menu (0,locals,51));
		locals[72] = PlayerAnswer;
		switch ( locals[72] ) {
			
		case 1:
			
			yield return StartCoroutine( label_03bf(locals));
			
			break;
			
		case 2:
			
			yield return StartCoroutine( label_037f(locals));
			
			break;
			
		} // end switch
	}
	
	
	
	IEnumerator label_037f(int[] locals)
	{
		yield return StartCoroutine(say( "Me very good tailor.  What you need?" ));
		locals[73] = 11;
		locals[74] = 12;
		locals[75] = 0;
		//locals[94] = babl_menu( 0, locals[73] );
		yield return StartCoroutine(babl_menu (0,locals,73));
		locals[94] = PlayerAnswer;
		switch ( locals[94] ) {
			
		case 1:
			
			yield return StartCoroutine( label_0483(locals));
			
			break;
			
		case 2:
			
			yield return StartCoroutine( label_07ef(locals));
			
			break;
			
		} // end switch
		
	}
	
	
	IEnumerator  label_03bf(int[] locals)
	{
		yield return StartCoroutine(say( "Very funny!  Me good tailor before, me good tailor now!  What you  need with me?" ));
		locals[95] = 14;
		locals[96] = 15;
		locals[97] = 0;
		//locals[116] = babl_menu( 0, locals[95] );
		yield return StartCoroutine(babl_menu (0,locals,95));
		locals[116] = PlayerAnswer;
		switch ( locals[116] ) {
			
		case 1:
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00c2();yield break;
			break;
			
		case 2:
			
			yield return StartCoroutine( label_037f(locals));
			break;	
		} // end if
		
		
		
	} // end switch
	
	
	
	
	

		

	IEnumerator	label_0544(int[] locals)
	{
		yield return StartCoroutine(say( "No have material, eh?  Me no can make anything without material.  So long." ));
		locals[186] = 2;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[186] );
		yield break;
	}
	
	
	IEnumerator	label_0483(int[] locals)
	{
		yield return StartCoroutine(say( "Let me see what you got to work with." ));
	label_0483:;
		locals[140] = 22;
		locals[141] = 23;
		locals[142] = 0;
		//locals[161] = babl_menu( 0, locals[140] );
		yield return StartCoroutine(babl_menu (0,locals,140));
		locals[161] = PlayerAnswer;
		switch ( locals[161] ) {
			
		case 1:
			
			goto label_04c3;
			
			break;
			
		case 2:
			
			yield return StartCoroutine( label_0544(locals));
			
			break;
			
		} // end switch


	label_04c3:;
		
		locals[162] = 285;
		if ( find_barter( 1, locals[162] ) == 0 ) {
			
			yield return StartCoroutine(say( "Me no see any good material there.  You got any cloth or animal skin or something like that?" ));
			goto label_0483;
		} else {
			
			locals[163] = 284;
			if ( find_barter( 1, locals[163] ) != 0 ) {
				
				yield return StartCoroutine(say( "Me can make dragonskin and ironsilk thread into boots for you.  Why me do that for you?" ));
			} else {
				
				yield return StartCoroutine(say( "Me can make dragon skin into boots for you.  But me also need ironsilk thread - only thread good for stitching dragon skin.  Why me do that for you?" ));
			} // end if
			
			locals[164] = 27;
			locals[165] = 28;
			locals[166] = 29;
			locals[167] = 0;
			//locals[185] = babl_menu( 0, locals[164] );
			yield return StartCoroutine(babl_menu (0,locals,164));
			locals[185] = PlayerAnswer;
			switch ( locals[185] ) {
				
			case 1:
				
				yield return StartCoroutine( label_0552(locals));
				
				break;
				
			case 2:
				
				yield return StartCoroutine( label_0552(locals));
				
				break;
				
			case 3:
				
				yield return StartCoroutine( label_0592(locals));
				
				break;
				
			} // end switch
		}


	}
	
	
	IEnumerator	label_0552(int[] locals)
	{
		yield return StartCoroutine(say( "Me no Avatar, do tough things for free!  Me want good pay for good work!" ));
		locals[187] = 32;
		locals[188] = 33;
		locals[189] = 0;
		//locals[208] = babl_menu( 0, locals[187] );
		yield return StartCoroutine(babl_menu (0,locals,187));
		locals[208] = PlayerAnswer;
		switch ( locals[208] ) {
			
		case 1:
			
			yield return StartCoroutine( label_0592(locals));
			
			break;
			
		case 2:
			
			yield return StartCoroutine( label_0592(locals));
			
			break;
			
		} // end switch
	}
	
	IEnumerator	label_0592(int[] locals)
	{
		yield return StartCoroutine(say( "Me want food for my work.  Just about anybody will do.  Maybe a Goblin.  Green ones be tender." ));
		locals[209] = 35;
		locals[210] = 36;
		locals[211] = 0;
		//locals[230] = babl_menu( 0, locals[209] );
		yield return StartCoroutine(babl_menu (0,locals,209));
		locals[230] = PlayerAnswer;
		switch ( locals[230] ) {
			
		case 1:
			
			yield return StartCoroutine( label_05de(locals));
			
			break;
			
		case 2:
			
			yield return StartCoroutine(say( "Okay, no pay, no boots." ));
			locals[231] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[231] );
			yield break;
			break;
			
		} // end switch
	}
	
	
	IEnumerator	label_05de(int[] locals)
	{
		privateVariables[2] = 1;
		yield return StartCoroutine(say( "Okay.  Give me dragon scales and thread and then me make boots." ));

		locals[232] = 39;
		locals[233] = 40;
		locals[234] = 0;
		//locals[253] = babl_menu( 0, locals[232] );
		yield return StartCoroutine(babl_menu (0,locals,232));
		locals[253] = PlayerAnswer;
		switch ( locals[253] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			yield return StartCoroutine(say( "Me need them to make boots.  Come back when you have them." ));
			locals[254] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[254] );
			yield break;
			break;
			
		} // end switch
		locals[255] = 285;
		locals[4] = find_barter( 1, locals[255] );
		locals[256] = 284;
		locals[5] = find_barter( 1, locals[256] );
		
		if ( (locals[4]== 0)|| (locals[5] == 0) ) {
			
			yield return StartCoroutine(say( "Me no see scales and thread!" ));
		} else {
			
			privateVariables[5] = 1;
			locals[257] = -1;
			give_ptr_npc( 2, locals[257], locals[4] -1);//Minus 1 to adjust for find_barter
			locals[258] = -1;
			give_ptr_npc( 2, locals[258], locals[5] -1);//Minus 1 to adjust for find_barter
			//func_00ea( 37 );
			func_00ea( 0,30 );
			/*TODO: half an hour
				privateVariables[9][1] = 0;
				privateVariables[9][2] = 30;
				*/
			yield return StartCoroutine(say( "Okay.  Come back in half hour with food and me give you boots." ));
			locals[259] = 44;
			locals[260] = 45;
			locals[261] = 0;
			//locals[280] = babl_menu( 0, locals[259] );
			yield return StartCoroutine(babl_menu (0,locals,259));
			locals[280] = PlayerAnswer;
			switch ( locals[280] ) {
				
			case 1:
				
				locals[281] = 2;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[281] );
				yield break;
				break;
				
			case 2:
				
				yield return StartCoroutine(say( "No.  Me have to make special.  Half hour." ));
				locals[282] = 2;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[282] );
				yield break;
				break;
			} // end if
			
			
			
		} // end switch











	}
	
	IEnumerator	label_07ef(int[] locals)
	{
		yield return StartCoroutine(say( "Me got some little stuff, look like your size.  Here!" ));
		yield return StartCoroutine(func_094b());
		Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
	}
	
	
	IEnumerator		label_07a6(int[] locals)
	{
		yield return StartCoroutine(say( "Fine!  Me no talk to you, neither!" ));
		locals[290] = 55;
		locals[291] = 56;
		locals[292] = 0;
		//locals[311] = babl_menu( 0, locals[290] );
		yield return StartCoroutine(babl_menu (0,locals,290));
		locals[311] = PlayerAnswer;
		switch ( locals[311] ) {
			
		case 1:
			
			yield return StartCoroutine( label_02ff(locals));
			
			break;
			
		case 2:
			
			locals[312] = 1;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[312] );
			yield break;
			break;
			
		} // end switch
	}
	
	
}
