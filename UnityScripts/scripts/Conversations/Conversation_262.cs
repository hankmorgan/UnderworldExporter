using UnityEngine;
using System.Collections;

public class Conversation_262 : Conversation {


	//conversation #262
	//	string block 0x0f06, name Generic goblin item #70
			

	
	public override IEnumerator main() {
		SetupConversation (3846);
		privateVariables[1] = 0;
		yield return StartCoroutine(func_029d());	
		func_0012();
		yield return 0;
	} // end func
	
	protected void func_0012() {
		EndConversation();
		privateVariables[0] = 1;
	} // end func
	
	int func_0020() {
		
		//int locals[1];
		int[] locals=new int[2];
		if ( (((npc.npc_goal == 5 || npc.npc_goal == 6) || npc.npc_goal == 9) && npc.npc_gtarg == 1 || npc.npc_attitude == 0) ) {
			
			locals[1] = 0;
		} else {
			
			locals[1] = 1;
		} // end if
		
		return locals[1];
	} // end func
	
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
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_0012();
		yield break;
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
		
		//int locals[4];
		int[] locals=new int[5];
		
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
	
	protected IEnumerator func_029d() {
		
		//int locals[108];
		int[] locals=new int[109];
		
		if ( privateVariables[0] == 1 ) {
			
			yield return StartCoroutine( say( "You again.  You got nothing better to do?" ) );
		} else {
			
			yield return StartCoroutine(say( "Hey, you not goblin!  Why you here?" ));
		} // end if
		
		privateVariables[2] = 1;
		privateVariables[3] = 1;
		locals[1] = 3;
		locals[2] = 4;
		locals[3] = 5;
		locals[4] = 6;
		locals[5] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine( babl_menu( 0,locals,1 ));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			goto label_031e;
			
			break;
			
		case 2:
			
			goto label_0393;
			
			break;
			
		case 3:
			
			goto label_0408;
			
			break;
			
		case 4:
			
			yield return StartCoroutine ( func_00e0() );
			break;
			
		} // end switch
		
	label_031e:;
		
	//label_031e:;
		
		yield return StartCoroutine(say( "Green Goblins, yes, good.  We are strongest and bravest in Abyss. Gray Goblins, they nasty and weak.  You no want talk to them.  Also watch out for some mean Goblins, not like our settlement.  They wear red.  Good Goblins near banners with funny marks.  Like me." ));
		privateVariables[2] = 0;
		locals[44] = privateVariables[3];
		locals[23] = 8;
		locals[45] = 1;
		locals[24] = 9;
		locals[46] = 1;
		locals[25] = 10;
		locals[26] = 0;
		//locals[65] = babl_fmenu( 0, locals[23], locals[44] );
		yield return StartCoroutine(babl_fmenu (0,locals,23,44));
		locals[65] = PlayerAnswer;
		switch ( locals[65] ) {
			
		case 8:
			
			goto label_0393;
			
			break;
			
		case 9:
			
			goto label_0408;
			
			break;
			
		case 10:
			
			yield return StartCoroutine ( func_00e0() );
			yield break;
			break;
			
		} // end switch
		
	label_0393:;

	//label_0393:;
		
		yield return StartCoroutine(say( "Yah, Vernix, he king.  Maybe you want talk to bodyguard Lanugo first.  They in northwest, at end of high overhang path." ));
		privateVariables[3] = 0;
		locals[87] = privateVariables[2];
		locals[66] = 12;
		locals[88] = 1;
		locals[67] = 13;
		locals[89] = 1;
		locals[68] = 14;
		locals[69] = 0;
		//locals[108] = babl_fmenu( 0, locals[66], locals[87] );
		yield return StartCoroutine(babl_fmenu (0,locals,66,87));
		locals[108] = PlayerAnswer;
		switch ( locals[108] ) {
			
		case 12:
			
			goto label_031e;
			
			break;
			
		case 13:
			
			goto label_0408;
			
			break;
			
		case 14:
			
			yield return StartCoroutine ( func_00e0() );
			yield break;
			break;
			
		} // end switch
		
	label_0408:;
		
	//label_0408:;
		
	//label_0408:;
		
		if ( func_0020() != 1) {
			
			yield return StartCoroutine(say( "No, not now.  Some other Goblin maybe." ));
			yield return StartCoroutine ( func_00e0() );
		} else {
			
			yield return StartCoroutine(say( "Maybe.  What you got?" ));
		} // end if
		
		yield return StartCoroutine(func_0422());
		yield return StartCoroutine(say( "Okay, goodbye." ));
		yield return StartCoroutine ( func_00e0() );
		yield break;
	} // end func
	
	IEnumerator func_0422() {
		
		//int locals[44];
		int[] locals=new int[45];

		setup_to_barter( 0 );
		while ( privateVariables[1] != 1 ) {
			
			locals[1] = 18;
			locals[2] = 19;
			locals[3] = 20;
			locals[4] = 21;
			locals[5] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine( babl_menu( 0,locals,1 ));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_04d3());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_052d());
				break;
				
			case 3:
				
				yield return  StartCoroutine (do_judgement( 0 ));
				break;
				
			case 4:
				
				do_decline( 0 );
				privateVariables[1] = 1;
				break;
				
			} // end switch
			
		} // while
		
		locals[23] = 22;
		locals[24] = 0;
		//locals[44] = babl_menu( 0, locals[23] );
		yield return StartCoroutine( babl_menu( 0,locals,23 ));
		locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_04d3() {
		
		//int locals[15];
		int[] locals=new int[16];

		locals[0] = -1;
		locals[6] = -1;
		locals[11] = 23;
		locals[12] = 24;
		locals[13] = 25;
		locals[14] = 26;
		locals[15] = 27;
		yield return StartCoroutine (do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ));
		//if ( do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] )  == 1) {
		if (PlayerAnswer==1)	{
			privateVariables[1] = 1;
		} // end if
		yield break;	
	} // end func
	
	IEnumerator func_052d() {
		
		//int locals[24];
		int[] locals=new int[25];
		
		yield return StartCoroutine(say( "You think you just take this from me?" ));
		locals[1] = 29;
		locals[2] = 30;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine( babl_menu( 0,locals,1 ));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			yield return null;
			//return;
			
			break;
			
		} // end switch
		
		locals[23] = 31;
		locals[24] = 32;
		yield return StartCoroutine (do_demand( 2, locals[24], locals[23] ));
		//if ( do_demand( 2, locals[24], locals[23] ) == 1 ) {
		if (PlayerAnswer==1){
			privateVariables[1] = 1;
		} else {
			
			func_008b();
		} // end if
		
	} // end func


}
