using UnityEngine;
using System.Collections;

public class Conversation_314 : Conversation {

	//conversation #314
	//string block 0x0f3a, wisp
			
	public override IEnumerator main() {
		SetupConversation (3898);
		privateVariables[1] = 0;
		yield return StartCoroutine(func_029d());
		func_0012();
		yield return 0;
	} // end func
	
	void func_0012() {
		EndConversation();
		privateVariables[0] = 1;
	} // end func
	
	/*void func_0020() {
		
		int locals[1];
		
		if ( (((npc_goal == 5 || npc_goal == 6) || npc_goal == 9) && npc_gtarg == 1 || npc_attitude == 0) ) {
			
			locals[1] = 0;
		} else {
			
			locals[1] = 1;
		} // end if
		
		return locals[1];
	} // end func
	
	void func_0063() {
		
		npc_gtarg = 1;
		npc_attitude = 1;
		npc_goal = 6;
		func_0012();
	} // end func
	
	void func_007c() {
		
		npc_goal = 1;
		func_0012();
	} // end func
	
	void func_008b() {
		
		npc_gtarg = 1;
		npc_goal = 5;
		npc_attitude = 1;
		func_0012();
	} // end func
	
	void func_00a4() {
		
		npc_attitude = 6;
	} // end func
	
	void func_00b1() {
		
		npc_attitude = param1[0]play_hunger;
		func_0012();
	} // end func
	
	void func_00c2() {
		
		npc_attitude = 2;
		func_0012();
	} // end func
	
	void func_00d1() {
		
		npc_attitude = 1;
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
		
		//int locals[110];
		int[] locals = new int[111];
		
		if ( privateVariables[0] ==1) {
			
		} else {
			
			yield return StartCoroutine(say( "A human it is.  We have been watching you.  A fine race you are, but somewhat unknowledgable.  To divide all your intelligence amongst yourselves as you do - it does not seem correct.  And your bodies must be so hard to maintain.  Still, we are impressed that you do as well as you do." ));
			locals[1] = 2;
			locals[2] = 3;
			locals[3] = 0;
			//locals[22] = babl_menu( 0, locasl[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				goto label_02e9;
				
				break;
				
			case 2:
				
				goto label_02e9;
				
				break;
				
			} // end switch
			
		label_02e9:;
			
	
			
			yield return StartCoroutine(say( "Surely it is not so.  Having no bodies to hamper us, we have no worries or cares.  We can devote our whole being to our sole quest - the gathering of information." ));
			locals[23] = 5;
			locals[24] = 6;
			locals[25] = 0;
			//locals[44] = babl_menu( 0, locasl[23] );
			yield return StartCoroutine(babl_menu (0,locals,23));
			locals[44] = PlayerAnswer;
			switch ( locals[44] ) {
				
			case 1:
				
				goto label_0329;
				
				break;
				
			case 2:
				
				goto label_0329;
				
				break;
				
			} // end switch
			
		label_0329:;
			
		
			
			yield return StartCoroutine(say( "Indeed, most of the things we know are on such a high plane that it is doubtful a human would be able to understand them." ));
			locals[45] = 8;
			locals[46] = 9;
			locals[47] = 0;
			//locals[66] = babl_menu( 0, locasl[45] );
			yield return StartCoroutine(babl_menu (0,locals,45));
			locals[66] = PlayerAnswer;
			switch ( locals[66] ) {
				
			case 1:
				
				goto label_0369;
				
				break;
				
			case 2:
				
				goto label_0369;
				
				break;
				
			} // end switch
			
		label_0369:;
			
					
			yield return StartCoroutine(say( "Ah, so you would know information so advanced it is more dangerous than you can imagine?  Very well, here is a piece for you: the spell Vas Kal Corp will bring an end to life as you know it, although higher beings such as we will continue to exist in our own way.  There.  We are eager to see to what use you will put this information." ));
			locals[67] = 11;
			locals[68] = 13;
			locals[69] = 0;
			//locals[88] = babl_menu( 0, locasl[67] );
			yield return StartCoroutine(babl_menu (0,locals,67));
			locals[88] = PlayerAnswer;
			switch ( locals[88] ) {
				
			case 1:
				
				yield return StartCoroutine(say( "Perhaps you are not as intelligent as we first thought." ));
				break;
				
			case 2:
				
				yield return StartCoroutine(say( "And that itself is something it is good you should know." ));
				break;
				
			} // end switch
			
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
		} // end if
		
		yield return StartCoroutine(say( "So you have decided not to use the information we have given you?" ));
		locals[89] = 16;
		locals[90] = 18;
		locals[91] = 0;
		//locals[110] = babl_menu( 0, locasl[89] );
		yield return StartCoroutine(babl_menu (0,locals,89));
		locals[110] = PlayerAnswer;
		switch ( locals[110] ) {
			
		case 1:
			
			yield return StartCoroutine(say( "If you have learned that not all information is beneficial, you have indeed learned some beneficial information." ));
			break;
			
		case 2:
			
			yield return StartCoroutine(say( "Indeed!  That will be an interesting sight." ));
			break;
			
		} // end switch
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00e0();
		yield break;
	} // end func
}
