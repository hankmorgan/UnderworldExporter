using UnityEngine;
using System.Collections;

public class Conversation_232 : Conversation {
	
	
	//conversation #232
	//	string block 0x0ee8, name Carasso
	
	public override IEnumerator main() {
		SetupConversation (3816);
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
		
		npc.npc_attitude =param1; ;//param1[0]play_hunger;
		func_0012();
	} // end func
	
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
		
		if ( privateVariables[0]==1 ) {
			
			yield return StartCoroutine(func_076c());
		} else {
			
			yield return StartCoroutine(say( locals, 001 ));
			locals[1] = 2;
			locals[2] = 3;
			locals[3] = 4;
			locals[4] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_0302());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_034a());
				break;
				
			case 3:
				
				yield return StartCoroutine(func_0392());
				break;
			} // end if
			
			
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0302() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 005 ));
		locals[1] = 6;
		locals[2] = 7;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_03da());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_046a());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_034a() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 008 ));
		locals[1] = 9;
		locals[2] = 10;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_046a());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0563());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0392() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 011 ));
		locals[1] = 12;
		locals[2] = 13;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_046a());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_05bf());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03da() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 014 ));
		locals[1] = 15;
		locals[2] = 16;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0422());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_046a());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0422() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 017 ));
		locals[1] = 18;
		locals[2] = 19;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_04b7());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_051b());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_046a() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 020));
		privateVariables[5] = 1;
		locals[1] = 21;
		locals[2] = 22;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);
			func_00d1();
			yield break;
			break;
			
		case 2:
			
			yield return StartCoroutine(func_061b());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_04b7() {
		
		int[] locals = new int[24];
		
		yield return StartCoroutine(say( locals, 023 ));
		locals[1] = 1016;
		if ( take_from_npc( 1, locals[1] ) == 2 ) {
			
			yield return StartCoroutine(say( locals, 024 ));
		} // end if
		
		privateVariables[4] = 1;
		locals[2] = 25;
		locals[3] = 26;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,2));   locals[23] = PlayerAnswer;
		switch ( locals[23] ) {
			
		case 1:
			
			yield return StartCoroutine(func_046a());
			break;
			
		case 2:
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_051b() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 027 ));
		locals[1] = 28;
		locals[2] = 29;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_046a());
			break;
			
		case 2:
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0563() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 030 ));
		locals[1] = 31;
		locals[2] = 32;
		locals[3] = 33;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_046a());
			break;
			
		case 2:
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
			break;
			
		case 3:
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);
			func_00d1();
			yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_05bf() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 034 ));
		locals[1] = 35;
		locals[2] = 36;
		locals[3] = 37;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_046a());
			break;
			
		case 2:
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00c2();yield break;
			break;
			
		case 3:
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00c2();yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_061b() {
		
		int[] locals = new int[37];
		
		locals[13] = 0;
	label_0625:;
		
		//locals[11] = show_inv( 2, locals[6], locals[1] );
		locals[11] = show_inv (2,locals,6,1);
		if ( locals[11] > 0 ) {
			int counter=0;
			locals[12] = 1;
			while ( locals[12] <= locals[11] ) {
				
				//if ( locals[1+counter] == 1011 ) {
				if (( locals[1+counter]>= 176 ) && (locals[1+counter]<= 183)) {
					locals[14] = 1;
					//	give_to_npc( 2, locals[5], locals[14] );
					give_to_npc(2,locals,6+counter,1);
				} // end if
				counter++;
				locals[12] = locals[12] + 1;
			} // while
			
			//give_to_npc( 2, locals[6], locals[11] );
			if (locals[14]==1)
			{
				yield return StartCoroutine(func_06de());
			}
			
		} //else {
		
		if ( locals[13] > 2 ) {
			
			yield return StartCoroutine(say( locals, 038 ));
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);
			func_00d1();
			yield break;
		} // end if
		
		yield return StartCoroutine(say( locals, 039 ));
		locals[15] = 40;
		locals[16] = 41;
		locals[17] = 0;
		//locals[36] = babl_menu( 0, locals[15] );
		yield return StartCoroutine(babl_menu (0,locals,15));   locals[36] = PlayerAnswer;
		switch ( locals[36] ) {
			
		case 1:
			
			locals[13] = locals[13] + 1;
			goto label_0625;
			
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0738());
			break;
		} // end if
		
		//break;
		
		//} // end switch
		
	} // end func
	
	IEnumerator func_06de() {
		
		int[] locals = new int[25];
		
		if ( privateVariables[3] ==1) {
			
			yield return StartCoroutine(say( locals, 042 ));
			locals[1] = 3;
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[1] );
			yield break;
		} // end if
		
		yield return StartCoroutine(say( locals, 043 ));
		locals[2] = 152;
		take_from_npc( 1, locals[2] );
		privateVariables[3] = 1;
		locals[3] = 44;
		locals[4] = 0;
		//locals[24] = babl_menu( 0, locals[3] );
		yield return StartCoroutine(babl_menu (0,locals,3));   locals[24] = PlayerAnswer;
		if ( locals[24] == 1 ) {
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00c2();yield break;
		} // end if
		
	} // end func
	
	IEnumerator func_0738() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 045 ));
		locals[1] = 46;
		locals[2] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		if ( locals[22] == 1 ) {
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00c2();yield break;
		} // end if
		
	} // end func
	
	IEnumerator func_076c() {
		
		
		int[] locals = new int[47];
		
		yield return StartCoroutine(say( locals, 047 ));
		//locals[1] = !privateVariables[5];
		if (privateVariables[5]==0)
		{
			locals[1]=1;
		}
		else
		{
			locals[1]=0;
		}
		//locals[2] = !privateVariables[4];
		if (privateVariables[4]==0)
		{
			locals[2]=1;
		}
		else
		{
			locals[2]=0;
		}
		//locals[3] = !privateVariables[3];
		if (privateVariables[3]==0)
		{
			locals[3]=1;
		}
		else
		{
			locals[3]=0;
		}
		locals[25] = locals[1];
		locals[4] = 48;
		locals[26] = locals[2];
		locals[5] = 49;
		locals[27] = locals[3];
		locals[6] = 50;
		locals[28] = 1;
		locals[7] = 51;
		locals[8] = 0;
		//locals[46] = babl_fmenu( 0, locals[4], locals[25] );
		yield return StartCoroutine (babl_fmenu(0,locals,4,25));
		locals[46]=PlayerAnswer;
		switch ( locals[46] ) {
			
		case 48:
			
			yield return StartCoroutine(func_046a());
			break;
			
		case 49:
			
			yield return StartCoroutine(func_0422());
			break;
			
		case 50:
			
			yield return StartCoroutine(func_061b());
			break;
			
		case 51:
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
			break;
			
		} // end switch
		
	} // end func
	
	
}
