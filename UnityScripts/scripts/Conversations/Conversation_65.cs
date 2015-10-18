using UnityEngine;
using System.Collections;

public class Conversation_65 : Conversation {
	

	//conversation #65
	//	string block 0x0e41, name Eb
			

	public override IEnumerator main() {
		SetupConversation (3649);
		privateVariables[1] = 0;
		yield return StartCoroutine(func_029d());
		func_0012();
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
	
/*	void func_007c() {
		
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
	
  	IEnumerator func_00b1( int unk) {
		
		npc.npc_attitude = param1[0];//play_hunger;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_0012();
		yield break;
	} // end func
	
	/*void func_00c2() {
		
		npc.npc_attitude = 2;
		func_0012();
	} // end func*/
	
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
		
		//int locals[212];
		int[] locals=new int[213];
		if ( privateVariables[0] == 1) {
			
		} else {
			
			privateVariables[2] = 0;
			privateVariables[3] = 0;
			privateVariables[4] = 0;
			yield return StartCoroutine(say( "So!  Who go there?" ));
			locals[3] = 2;
			locals[4] = 3;
			locals[5] = 4;
			locals[6] = 0;
			//locals[24] = babl_menu( 0, locals[3] );
			yield return StartCoroutine(babl_menu (0,locals,3));
			locals[24] = PlayerAnswer;
			switch ( locals[24] ) {
				
			case 1:
				
				goto label_030c;
				
				break;
				
			case 2:
				
				goto label_031f;
				
				break;
				
			case 3:
				
				goto label_0377;//?
				
				break;
				
			} // end switch
			
		label_030c:;
			
			privateVariables[3] = 1;
			yield return StartCoroutine(say( "Ha!  I thought so!  You get gone from here!" ));
			locals[25] = 1;
			yield return StartCoroutine ( func_00b1( locals[25] ));
			yield break;

/*		label_031f:;
			if ( privateVariables[2]==1 ) {
				
				say( "Speak with King Ketchaval, hm?" );
			} else {
				
				say( "And who you, who wants talk with King Ketchaval?" );
				locals[26] = 8;
				locals[27] = 9;
				locals[28] = 0;
				//locals[47] = babl_menu( 0, locals[26] );
				yield return StartCoroutine(babl_menu (0,locals,26));
				locals[47] = PlayerAnswer;
				switch ( locals[47] ) {
					
				case 1:
					
					goto label_0377;
					
					break;
					
				case 2:
					
					goto label_0369;
					
					break;
					
				} // end switch
			} // end if	//Moved this bracket to here!*/

		


			

			
			//break;
			
		} // end switch(if)
		
		if ( privateVariables[3] == 1) {
			
		} else {
			
			if ( privateVariables[2] == 1 ) {
				
				yield return StartCoroutine(say( "Ho, @GS8!  Why you here again?" ));
			} else {
				
				yield return StartCoroutine(say( "Hey, it you again!  What you want?" ));
			} // end if
			if (privateVariables[4]==1)
			{
				locals[2]=0;
			}
			else
			{
				locals[2]=1;
			}
			//locals[2] = !privateVariables[4];
			locals[121] = 1;
			locals[100] = 20;
			locals[122] = 1;
			locals[101] = 22;
			locals[123] = locals[2];
			locals[102] = 24;
			locals[124] = 1;
			locals[103] = 25;
			locals[104] = 0;
			//locals[142] = babl_fmenu( 0, locals[100], locals[121] );
			yield return StartCoroutine(babl_fmenu (0,locals,100,121));
			locals[142] = PlayerAnswer;
			switch ( locals[142] ) {
				
			case 20:
				
				yield return StartCoroutine(say( "You be careful then.  Not everywhere safe to wander." ));
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00e0();
				yield break;
				break;
				
			case 22:
				yield return StartCoroutine(say( "You have nice journey then." ));
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00e0();
				yield break;
				break;
				
			case 24:
				
				goto label_031f;
				
				break;
				
			case 25:
				
				goto label_05d9;
				break;
			} // end if
			
//			break;
			
		} // end switch
		
		yield return StartCoroutine(say( "Aha!  Green Goblin friend!  You still like them?" ));
		locals[143] = 27;
		locals[144] = 28;
		locals[145] = 29;
		locals[146] = 0;
		//locals[164] = babl_menu( 0, locals[143] );
		yield return StartCoroutine(babl_menu (0,locals,143));
		locals[164] = PlayerAnswer;
		switch ( locals[164] ) {
			
		case 1:
			
			goto label_0594;
			
			break;
			
		case 2:
			
			goto label_0594;
			
			break;
			
		case 3:
			
			goto label_0586;
			
			break;
			
		} // end switch
		
	label_0586:;
		
		yield return StartCoroutine(say( "Ha, I think as much!  You not welcome here then!" ));
		locals[165] = 1;
		yield return StartCoroutine ( func_00b1( locals[165] ));
		yield break;
	label_0594:;
		
	//label_0594:;
		
		privateVariables[3] = 0;
		yield return StartCoroutine(say( "Yeah?  What you want here then?" ));
		locals[166] = 32;
		locals[167] = 33;
		locals[168] = 0;
		//locals[187] = babl_menu( 0, locals[166] );
		yield return StartCoroutine(babl_menu (0,locals,166));
		locals[187] = PlayerAnswer;
		switch ( locals[187] ) {
			
		case 1:
			
			goto label_031f;
			
			break;
			
		case 2:
			
			goto label_0369;
			
			break;
			
		} // end switch

	label_0423:;
		
		privateVariables[4] = 1;
		yield return StartCoroutine(say( "Good idea speak with King Ketchaval. He very wise and strong.  Maybe you best talk to Queen Retichall first, though.  On you go, now." ));
		locals[75] = 47;
		locals[76] = 51;
		locals[77] = 0;
		gronk_door( 3, locals[77], locals[76], locals[75] );
		locals[78] = 16;
		locals[79] = 17;
		locals[80] = 0;
		//locals[99] = babl_menu( 0, locals[78] );
		yield return StartCoroutine(babl_menu (0,locals,78));
		locals[99] = PlayerAnswer;
		switch ( locals[99] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			break;
		} // end if



	label_0377:;
		
		//label_0377:;
		
		privateVariables[2] = 1;
		yield return StartCoroutine(say( "@GS8, eh?  I think I heard of you.  You new here, eh?  You come to right place.  Gray Goblins the most powerful group here." ));
		
		
		locals[1] = npc.npc_attitude;
		locals[49] = locals[1];
		if ( 0 == locals[49] ) {
			
		} else {
			
			if ( 1 == locals[49] ) {
				
			} else {
				
				if ( 2 == locals[49] ) {
					
				} else {
					
					if ( 3 == locals[49] ) {
						
						goto label_0423;
						
					} // end if
					
				} // end if
				
			} // end if
			
			privateVariables[4] = 1;
			yield return StartCoroutine(say( "You be careful, though, you mind your manners.  Not all of us like strange people like you.  You act nice." ));
			locals[50] = 47;
			locals[51] = 51;
			locals[52] = 0;
			gronk_door( 3, locals[52], locals[51], locals[50] );
			locals[53] = 13;
			locals[54] = 14;
			locals[55] = 0;
			//locals[74] = babl_menu( 0, locals[53] );
			yield return StartCoroutine(babl_menu (0,locals,53));
			locals[74] = PlayerAnswer;
			switch ( locals[74] ) {
				
			case 1:
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00e0();
				yield break;
				break;
				
			case 2:
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00e0();
				yield break;
				break;
			} // end if
			
			//break;
			
		} // end switch


	label_0369:;
		
		//label_0369:;
		
		yield return StartCoroutine(say( "Well then!  You not our business neither!" ));
		locals[48] = 1;
		func_00b1( locals[48] );
		yield break;


	label_031f:;//keep
		if ( privateVariables[2]==1 ) {
			
			yield return StartCoroutine(say( "Speak with King Ketchaval, hm?" ));
		} else {
			
			yield return StartCoroutine(say( "And who you, who wants talk with King Ketchaval?" ));
			locals[26] = 8;
			locals[27] = 9;
			locals[28] = 0;
			//locals[47] = babl_menu( 0, locals[26] );
			yield return StartCoroutine(babl_menu (0,locals,26));
			locals[47] = PlayerAnswer;
			switch ( locals[47] ) {
				
			case 1:
				
				goto label_0377;
				
				break;
				
			case 2:
				
				goto label_0369;
				
				break;
				
			} // end switch
		} // end if	//Moved this bracket to here!




	label_05d9:;
		
		yield return StartCoroutine(say( "Well, you be careful, mind your manners.  On you go." ));
		locals[188] = 47;
		locals[189] = 51;
		locals[190] = 0;
		gronk_door( 3, locals[190], locals[189], locals[188] );
		locals[191] = 35;
		locals[192] = 36;
		locals[193] = 0;
		//locals[212] = babl_menu( 0, locals[191] );
		yield return StartCoroutine(babl_menu (0,locals,191));
		locals[212] = PlayerAnswer;
		switch ( locals[212] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
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











}
