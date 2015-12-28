using UnityEngine;
using System.Collections;

public class Conversation_22 : Conversation {

	//conversation #22
	//string block 0x0e16, name golem
	public int[] global = new int[1];

	public override bool OnDeath ()
	{//The golem is essentially immortal. When "killed" it just talks to the player again.
		base.OnDeath ();
		npc.NPC_DEAD=false;
		//npc.npc_hp=9;
		npc.TalkTo ();
		return true;
	}
	
	public override IEnumerator main() {
		SetupConversation (3606);
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
	*/
	void func_00b1(int param1) {
		
		npc.npc_attitude = param1;//[0]global[0];
		func_0012();
	} // end func
	/*
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
		
		if ( (privateVariables[0]==1) && (global[0]==1) ) {
			
			yield return StartCoroutine(say( "Thou hast bested me and earned the Shield of Valor; thou hast nothing more to prove here." ));
			yield return StartCoroutine(func_0535());
		} else {
			
			if ( npc.npc_hp < 10 ) {
				
				yield return StartCoroutine(func_040b());
			} else {
				
				if ( (privateVariables[0]==1) && (play_hp < 20) ) {
					
					yield return StartCoroutine(func_03c3());
				} else {
					
					if ( privateVariables[0]==1 ) {
						
						yield return StartCoroutine(func_04ed());
					} else {
						
						global[0] = 0;
						yield return StartCoroutine(say( "Hold, puny mortal!  I am thy doom!" ));
						locals[1] = 3;
						locals[2] = 4;
						locals[3] = 5;
						locals[4] = 0;
						yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
						switch ( locals[22] ) {
							
						case 1:
							
							yield return StartCoroutine(func_0333());
							break;
							
						case 2:
							
							yield return StartCoroutine(func_0333());
							break;
							
						case 3:
							
							yield return StartCoroutine(func_0535());
							break;
						} // end if
						
					} // end if
					
				} // end if
				
			} // end if
			

			
		} // end switch
		
	} // end func
	
	IEnumerator func_0333() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "I am what I was made to be - the greatest warrior in Britannia.  If thou be not of mighty valor, turn back now and no shame will come of it. Else, prepare to meet thy doom." ));
		locals[1] = 7;
		locals[2] = 8;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_037b());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0535());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_037b() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Thou wagerest thy life against a mighty talisman - the Shield of Valor.  Defeat me and it shall be thine.  Fail and thou shalt surely die." ));
		locals[1] = 10;
		locals[2] = 11;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0535());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03c3() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Hold!  Thou hast fought well, mortal.  Better than any in many a year.  I would give thee a chance to live, that valor such as yours should not die.  Flee now and I grant thee thy life. " ));
		locals[1] = 13;
		locals[2] = 14;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0535());
			break;
			
		case 2:
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_040b() {
		
		int[] locals = new int[35];
		
		yield return StartCoroutine(say( "Hold, mortal!  Thou hast bested me!  Never have any shown such Valor! Surely thou shouldst be the master of the Shield!" ));
		locals[2] = 55;
		locals[3] = 0;
		locals[1] = find_inv( 2, locals[3], locals[2] );
		if ( locals[1] > 0 ) {
			
			locals[4] = 1;
			locals[5] = 7;
			locals[6] = -1;
			locals[7] = -1;
			locals[8] = -1;
			locals[9] = -1;
			locals[10] = -1;
			locals[11] = -1;
			//x_obj_stuff( 9, locals[11], locals[10], locals[9], locals[8], locals[7], locals[6], locals[5], locals[4], locals[1] );
			x_obj_stuff( 10,locals, 11, 10, 9, 8, 7, 6, 5, 4, 1 );
		} // end if
		
		locals[12] = 55;
		if ( take_from_npc( 1, locals[12] ) == 2 ) {
			yield return StartCoroutine(say( "I will leave it here for thee.  Use it well!" ));
		} // end if
		
		global[0] = 1;
		npc.npc_hp = 125;
		locals[13] = 17;
		locals[14] = 18;
		locals[15] = 0;
		//locals[34] = babl_menu( 0, locals[13] );
		yield return StartCoroutine(babl_menu (0,locals,13));
		locals[34]=PlayerAnswer;
		switch ( locals[34] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0535());
			break;
			
		case 2:
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_04ed() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Why dost thou continue to talk to me?  Art thou not eager to continue our battle?" ));
		locals[1] = 20;
		locals[2] = 21;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0535());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0535() {
		
		int[] locals = new int[2];
		
		npc.npc_goal = 8;
		locals[1] = 2;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );
		yield break;
	} // end func


}
