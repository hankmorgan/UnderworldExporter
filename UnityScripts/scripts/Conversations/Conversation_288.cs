using UnityEngine;
using System.Collections;

public class Conversation_288 : Conversation {

	//conversation #288
	//	string block 0x0f20, name  Generic troll
			

	public override IEnumerator main() {
		SetupConversation (3872);
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
		
		//int locals[1];
		int[] locals =new int[2];
		
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
		
		npc.npc_attitude = param1;//param1[0]play_hunger;
		func_0012();
	} // end func
	
	/*void func_00c2() {
		
		npc.npc_attitude = 2;
		func_0012();
	} // end func*/
	
	/*void func_00d1() {
		
		npc.npc_attitude = 1;
		func_0012();
	} // end func*/
	
	/*void func_00e0() {
		
		func_0012();
	} // end func*/
	
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
		
		//int locals[22];
		int [] locals = new int[23];
		
		if ( privateVariables[0] == 1) {
			
			yield return StartCoroutine(say( "You come back?  Why?" ));
		} else {
			
			yield return StartCoroutine(say( "What you doing here?" ));
		} // end if
		
		locals[1] = 3;
		locals[2] = 4;
		locals[3] = 5;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0359());
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0436());
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			break;
			
		case 3:
			
			yield return StartCoroutine(func_0303());
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0303() {
		
		//int locals[23];
		int [] locals = new int[24];
		
		if ( func_0020() == 1 ) {
			
			yield return StartCoroutine(say( "We trade?" ));
			locals[1] = 7;
			locals[2] = 8;
			locals[3] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_04d5());
				break;
				
			case 2:
				
				locals[23] = 2;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[23] );
				yield break;
				break;
			} // end if
			

			
		} // end switch
		
	} // end func
	
	IEnumerator func_0359() {
		
		//int locals[10];
		int [] locals = new int[11];
		
		locals[8] = 1;
		locals[9] = 1;
		while ( locals[8] <= 6 ) {
			
			//if ( privateVariables[2][0] == 0 ) {
			if ( privateVariables[2] == 0 ) {
				locals[0] = locals[8];
				locals[9] = locals[9] + 1;
			} // end if
			
			locals[8] = locals[8] + 1;
		} // while
		
		if ( locals[9] == 0 ) {
			
			yield return StartCoroutine(say( "I have no new news for you." ));
			locals[8] = 1;
		} // end if
		
		if ( locals[8] <= 6 ) {
			privateVariables[2] = 0;
		//	privateVariables[2][0] = 0;
		} else {
			
		} // end if
		locals[9] = locals[0];
		//locals[8] = random( 1, locals[9] );
		locals[10]= random (1,6);
		privateVariables[2] = 1;
		//privateVariables[2][0] = 1;
		//locals[10] = locals[9];
		if ( 1 == locals[10] ) {
			
			yield return StartCoroutine(say( "Me hear one Troll got caught by Wizard, made slave." ));
		} else {
			
			if ( 2 == locals[10] ) {
				
				yield return StartCoroutine(say( "Me hear somebody killing Trolls!  Me catch, me eat!" ));
			} else {
				
				if ( 3 == locals[10] ) {
					
					yield return StartCoroutine(say( "Sethar and his friend live near the big pit." ));
				} else {
					
					if ( 4 == locals[10] ) {
						
						yield return StartCoroutine(say( "Sneak snuck on Sethar, but he tossed him in pit." ));
					} else {
						
						if ( 5 == locals[10] ) {
							
							yield return StartCoroutine(say( "One Knight real mean, he live up north." ));
						} else {
							
							if ( 6 == locals[10] ) {
								
								yield return StartCoroutine(say( "Ghouls live below us.  They disgusting." ));
							} // end if
							
						} // end if
						
					} // end if
					
				} // end if
				
			} // end if
			
		} // end if
		
	} // end func
	
	IEnumerator func_0436() {
		
		//int locals[23];
		int [] locals = new int[24];
		
		yield return StartCoroutine(say( "You food, puny human?" ));
		locals[1] = 17;
		locals[2] = 18;
		locals[3] = 19;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_008b();
			yield break;
			break;
			
		case 2:
			
			break;
			
		case 3:

			yield return StartCoroutine(func_049e());
			break;
			
		} // end switch
		
		yield return StartCoroutine(say( "You confuse me, first want fight and then not want fight." ));
		locals[23] = 1;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[23] );
		yield break;
	} // end func
	
	IEnumerator func_049e() {
		
		//int locals[1];
		int[] locals = new int[2];
		
		if ( play_level + play_drawn > npc.npc_level + 5 ) {
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_0063();
			yield break;
		} // end if
		
		if ( play_level + play_drawn < npc.npc_level - 1 ) {
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_008b();
			yield break;
		} // end if
		
		locals[1] = 1;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );
		yield break;
	} // end func
	
	IEnumerator func_04d5() {
		
	//	int locals[44];
		int[] locals = new int[45];
		
		setup_to_barter( 0 );
		while ( privateVariables[1] == 0) {
			
			locals[1] = 21;
			locals[2] = 22;
			locals[3] = 23;
			locals[4] = 24;
			locals[5] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_0586());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_05e0());
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
		
		locals[23] = 25;
		locals[24] = 0;
		//locals[44] = babl_menu( 0, locals[23] );
		yield return StartCoroutine(babl_menu (0,locals,23));
		locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_0586() {
		
		//int locals[15];
		int[] locals=new int[16];
		
		locals[0] = -1;
		locals[6] = -1;
		locals[11] = 26;
		locals[12] = 27;
		locals[13] = 28;
		locals[14] = 29;
		locals[15] = 30;
		//if ( do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ) ) {
		yield return StartCoroutine (do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6],locals[1]) );
		if (PlayerAnswer==1)	{
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_05e0() {
		
		//int locals[24];
		int[] locals= new int[25];
		
		yield return StartCoroutine(say( "Dost thou intend to rob me?" ));
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
			
			yield break;//return;
			
			break;
			
		} // end switch
		
		locals[23] = 34;
		locals[24] = 35;
		//if ( do_demand( 2, locals[24], locals[23] ) ) {
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
