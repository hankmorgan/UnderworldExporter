using UnityEngine;
using System.Collections;

public class Conversation_210 : Conversation {
	
	//conversation #210
	//string block 0x0ed2, name Naruto
	public int[] global =new int[3];
	public override IEnumerator main() {
		SetupConversation (3794);
		privateVariables[1] = 0;
		yield return StartCoroutine(func_029d());
		func_0012();
		yield return 0;
	} // end func
	
	
	void func_0012() {
		EndConversation();
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
		
		int[] locals = new int[23];
		
		if ( privateVariables[0] == 1 ) {
			
			yield return StartCoroutine(func_05f3());
		} else {
			
			global[1] = 1;
			global[2] = 1;
			global[0] = 0;
			yield return StartCoroutine(say( locals, 001 ));
			locals[1] = 2;
			locals[2] = 3;
			locals[3] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_0300());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_0300());
				break;
			} // end if
			
			
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0300() {
		
		int[] locals = new int[23];
		
		global[1] = 0;
		yield return StartCoroutine(say( locals, 004 ));
		locals[1] = 5;
		locals[2] = 6;
		locals[3] = 7;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0361());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0422());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_0422());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0361() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 008 ));
		locals[1] = 9;
		locals[2] = 10;
		locals[3] = 11;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_03bd());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0422());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_0422());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03bd() {
		
		int[] locals = new int[24];
		
		yield return StartCoroutine(say( locals, 012 ));
		locals[1] = 13;
		locals[2] = 14;
		locals[3] = 15;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0422());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0422());
			break;
			
		case 3:
			
			locals[23] = 1;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0422() {
		
		int[] locals = new int[23];
		
		global[2] = 0;
		yield return StartCoroutine(say( locals, 016 ));
		locals[1] = 17;
		locals[2] = 18;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_046f());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_04a3());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_046f() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 019 ));
		locals[1] = 20;
		locals[2] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		if ( locals[22] == 1 ) {
			
			yield return StartCoroutine(func_04b0());
		} // end if
		
	} // end func
	
	IEnumerator func_04a3() {
		int[] locals = new int[1];
		yield return StartCoroutine(say( locals, 021 ));
		Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
	} // end func
	
	IEnumerator func_04b0() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 022 ));
		locals[1] = 23;
		locals[2] = 24;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_04f8());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_04f8());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_04f8() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 025 ));
		locals[1] = 26;
		locals[2] = 27;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0540());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_04a3());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0540() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 028 ));
		locals[1] = 29;
		locals[2] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		if ( locals[22] == 1 ) {
			
			yield return StartCoroutine(func_0574());
		} // end if
		
	} // end func
	
	IEnumerator func_0574() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 030 ));
		locals[1] = 31;
		locals[2] = 32;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_05bf());
			break;
			
		case 2:
			
			yield return StartCoroutine(say( locals, 033 ));
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_05bf() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 034 ));
		locals[1] = 35;
		locals[2] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		if ( locals[22] == 1 ) {
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
		} // end if
		
	} // end func
	
	IEnumerator func_05f3() {
		
		int[] locals = new int[46];
		
		if ( global[2]==1 ) {
			
			yield return StartCoroutine(say( locals, 036 ));
			locals[1] = 37;
			locals[2] = 38;
			locals[3] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_0422());
				break;
				
			case 2:
				
				locals[23] = 1;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[23] );
				yield break;
			} // end if
			
		} //else {
		
		//break;
		
		//} // end switch
		
		yield return StartCoroutine(say( locals, 039 ));
		locals[24] = 40;
		locals[25] = 41;
		locals[26] = 0;
		//locals[45] = babl_menu( 0, locals[24] );
		yield return StartCoroutine (babl_menu(0,locals,24));
		locals[45]= PlayerAnswer;
		switch ( locals[45] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			break;
			
		} // end switch
		
		Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
	} // end func
	
}
