using UnityEngine;
using System.Collections;

public class Conversation_139 : Conversation {
	
	//conversation #139
	//string block 0x0e8b, name Trisch
	
	
	public override IEnumerator main() {
		SetupConversation (3723);
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
		
		npc.npc_attitude = param1 ;//param1[0]play_hunger;
		func_0012();
	} // end func
	/*
	void func_00c2() {
		
		npc.npc_attitude = 2;
		func_0012();
	} // end func*/
	
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
		
	} // end func*/
	
	IEnumerator func_029d() {
		
		int[] locals = new int[88];
		
		if ( privateVariables[0] == 0 ) {
			
			privateVariables[2] = 0;
			yield return StartCoroutine(say( locals, 001 ));
			locals[1] = 2;
			locals[2] = 3;
			locals[3] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_075f());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_0711());
				break;
			} // end if
			
		}
		
		if ( npc.npc_attitude < 2 ) {
			
			yield return StartCoroutine(say( locals, 004 ));
			locals[23] = 5;
			locals[24] = 6;
			locals[25] = 0;
			//locals[44] = babl_menu( 0, locals[23] );
			yield return StartCoroutine(babl_menu (0,locals,23));   locals[44] = PlayerAnswer;
			switch ( locals[44] ) {
				
			case 1:
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00d1();
				yield break;

			case 2:
				
				yield return StartCoroutine(func_06c7());
				break;
			} // end if
			
		} 
		
		if ( privateVariables[3]==1 ) {
			
			yield return StartCoroutine(func_03b7());
		} else {
			
			yield return StartCoroutine(say( locals, 007 ));
			locals[66] = 1;
			locals[45] = 8;
			locals[67] = 1;
			locals[46] = 9;
			locals[68] = privateVariables[2];
			locals[47] = 10;
			locals[48] = 0;
			//locals[87] = babl_fmenu( 0, locals[45], locals[66] );
			yield return StartCoroutine (babl_fmenu (0,locals,45,66));
			locals[87]=PlayerAnswer;
			switch ( locals[87] ) {
				
			case 8:
				
				Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;

			case 9:
				
				yield return StartCoroutine(func_03c4());
				break;
				
			case 10:
				
				yield return StartCoroutine(func_0491());
				break;
			} // end if
			
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03b7() {
		int[] locals = new int[1];
		yield return StartCoroutine(say( locals, 011 ));
		Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
	} // end func
	
	IEnumerator func_03c4() {
		
		int[] locals = new int[70];
		locals[3] = 32;
		locals[1] = get_quest( 1, locals[3] );
		
		//locals[2] = !privateVariables[2];
		if (privateVariables[2]==1)
		{
			locals[2]=0;
		}
		else
		{
			locals[2]=1;
		}
		if ( locals[1] >= 2 ) {
			
			yield return StartCoroutine(say( locals, 012 ));
			locals[25] = locals[2];
			locals[4] = 13;
			locals[26] = 1;
			locals[5] = 15;
			locals[6] = 0;
			//locals[46] = babl_fmenu( 0, locals[4], locals[25] );
			yield return StartCoroutine (babl_fmenu (0,locals,4,25));
			locals[46]=PlayerAnswer;
			switch ( locals[46] ) {
				
			case 13:
				
				yield return StartCoroutine(say( locals, 014 ));
				func_07f3();
				break;
				
			case 15:
				
				yield return StartCoroutine(say( locals, 016 ));
				break;
			} // end if
			
		} 
		
		yield return StartCoroutine(say( locals, 017 ));
		locals[47] = 18;
		locals[48] = 19;
		locals[49] = 0;
		//locals[68] = babl_menu( 0, locals[47] );
		yield return StartCoroutine (babl_menu (0,locals,47));
		locals[68]=PlayerAnswer;
		switch ( locals[68] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			yield return StartCoroutine(say( locals, 020 ));
			break;
			
		} // end switch
		
		locals[69] = 2;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[69] );
		yield break;
	} // end func
	
	IEnumerator func_0491() {
		
		int[] locals = new int[45];
		
		yield return StartCoroutine(say( locals, 021 ));
		locals[1] = 22;
		locals[2] = 24;
		locals[3] = 25;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(say( locals, 023 ));
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0518());
			break;
			
		case 3:
			
			yield return StartCoroutine(say( locals, 026 ));
			break;
			
		} // end switch
		
		locals[23] = 27;
		locals[24] = 0;
		//locals[44] = babl_menu( 0, locals[23] );
		yield return StartCoroutine(babl_menu (0,locals,23));   locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
		} // end if
		
	} // end func
	
	IEnumerator func_0518() {
		
		int[] locals = new int[63];
		bool flag=false;
		yield return StartCoroutine(say( locals, 028 ));
		locals[3] = 0;
		//} // end if
		while(flag==false)
		{
			
			
			locals[4] = 29;
			locals[5] = 30;
			locals[6] = 0;
			//locals[25] = babl_menu( 0, locals[4] );
			yield return StartCoroutine(babl_menu (0,locals,4));   locals[25] = PlayerAnswer;
			switch ( locals[25] ) {
				
			case 1:
				flag=true;
				break;
				
			case 2:
				
				if ( locals[3] < 3 ) {
					
					locals[26] = locals[3];
					if ( 0 == locals[26] ) {
						
						yield return StartCoroutine(say( locals, 031 ));
					} else {
						
						if ( 1 == locals[26] ) {
							
							yield return StartCoroutine(say( locals, 032 ));
						} else {
							
							if ( 2 == locals[26] ) {
								yield return StartCoroutine(say( locals, 033 ));
							} // end if
							
							
						} // end if
						
					} // end if
					
					
				}// else {
				else
				{
					yield return StartCoroutine(say( locals, 034 ));
					locals[27] = 1;
					Time.timeScale =SlomoTime;
					yield return new WaitForSeconds(WaitTime);
					func_00b1( locals[27] );
					yield break;
				}
				locals[3] = locals[3] + 1;
				//} //else {
				//yield break;
				break;
				
				
			} // end switch
		}
		locals[2] = 0;//Is the taper lit?
		locals[28] = 147;
		locals[1] = find_barter( 1, locals[28] );
		
		if (locals[1]==0)
		{//unlit version not found found
			locals[2] = 1;
			locals[29] = 151;
			locals[1] = find_barter( 1, locals[29] );//Lit version
			if(locals[1]==0)
			{//lit version not found.
				yield return StartCoroutine(say( locals, 035 ));
				locals[30] = 1;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[30] );
				yield break;
			}
		}
		/*switch ( locals[1] ) {
				
			case 1:
			case 2:
			case 3:
			case 4:

				
				break;
				
			case 0:
				
				yield return StartCoroutine(say( locals, 035 ));
				locals[30] = 1;
				func_00b1( locals[30] );
				break;
				
			} // end switch*/
		
		locals[31] = 1;
		locals[32] = 7;
		locals[33] = -1;
		locals[34] = -1;
		locals[35] = -1;
		locals[36] = -1;
		locals[37] = -1;
		locals[38] = -1;
		//x_obj_stuff( 9, locals[38], locals[37], locals[36], locals[35], locals[34], locals[33], locals[32], locals[31], locals[1] );
		x_obj_stuff(10,locals,38,37,36,35,34,33,32,31,locals[1]-1);
		locals[39] = locals[2];
		if ( 0 == locals[39] ) {
			
			yield return StartCoroutine(say( locals, 036 ));
		} else {
			
			if ( 1 == locals[39] ) {
				
				yield return StartCoroutine(say( locals, 037 ));
			} // end if
			
		} // end if
		
		privateVariables[3] = 1;
		yield return StartCoroutine(say( locals, 038 ));
		locals[40] = 39;
		locals[41] = 41;
		locals[42] = 0;
		//locals[61] = babl_menu( 0, locals[40] );
		yield return StartCoroutine(babl_menu (0,locals,40));   locals[61] = PlayerAnswer;
		switch ( locals[61] ) {
			
		case 1:
			
			yield return StartCoroutine(say( locals, 040 ));
			break;
			
		case 2:
			
			yield return StartCoroutine(say( locals, 042 ));
			break;
			
		} // end switch
		
		locals[62] = 3;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[62] );
		yield break;
	} // end func
	
	IEnumerator func_06c7() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 043 ));
		locals[1] = 44;
		locals[2] = 45;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
			
		case 2:
			
			yield return StartCoroutine(func_07a7());
			break;
			
		} // end switch
		
			yield return StartCoroutine(func_085b());
	} // end func
	
	IEnumerator func_0711() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 046 ));
		locals[1] = 47;
		locals[2] = 49;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(say( locals, 048 ));
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;

		case 2:
			
			yield return StartCoroutine(say( locals, 050 ));
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00d1();
			yield break;

		} // end switch
		
	} // end func
	
	IEnumerator func_075f() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 051 ));
		locals[1] = 52;
		locals[2] = 53;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_07a7());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0711());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_07a7() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 054 ));
		yield return StartCoroutine(say( locals, 055 ));
		locals[1] = 56;
		locals[2] = 58;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(say( locals, 057 ));
			break;
			
		case 2:
			
			break;
			
		} // end switch
		
		yield return StartCoroutine(func_07f3());
	} // end func
	
	IEnumerator func_07f3() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 059 ));
		yield return StartCoroutine(say( locals, 060 ));
		privateVariables[2] = 1;
		locals[1] = 61;
		locals[2] = 63;
		locals[3] = 64;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(say( locals, 062 ));
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0518());
			break;
			
		case 3:
			
			yield return StartCoroutine(say( locals, 065 ));
			break;
			
		} // end switch
		
		yield return StartCoroutine(func_085b());
	} // end func
	
	IEnumerator func_085b() {
		
		int[] locals = new int[23];
		
		locals[1] = 66;
		locals[2] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		if ( locals[22] == 1 ) {
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
		} // end if
		
	} // end func
	
	IEnumerator func_088c() {
		
		int[] locals = new int[45];
		
		setup_to_barter( 0 );
		while ( privateVariables[1] == 0) {
			
			locals[1] = 67;
			locals[2] = 68;
			locals[3] = 69;
			locals[4] = 70;
			locals[5] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_093d());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_0997());
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
		
		locals[23] = 71;
		locals[24] = 0;
		//locals[44] = babl_menu( 0, locals[23] );
		yield return StartCoroutine(babl_menu (0,locals,23));   locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_093d() {
		
		int[] locals = new int[16];
		
		locals[0] = -1;
		locals[6] = -1;
		locals[11] = 72;
		locals[12] = 73;
		locals[13] = 74;
		locals[14] = 75;
		locals[15] = 76;
		//if ( do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ) ) {
		yield return StartCoroutine (do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6],locals[1]) );
		if (PlayerAnswer==1)	{
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_0997() {
		
		int[] locals = new int[25];
		
		yield return StartCoroutine(say( locals, 077 ));
		locals[1] = 78;
		locals[2] = 79;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			//return;
			yield break;
	
		} // end switch
		
		locals[23] = 80;
		locals[24] = 81;
		//if ( do_demand( 2, locals[24], locals[23] ) ) {
		yield return StartCoroutine (do_demand( 2, locals[24], locals[23] ));
		if (PlayerAnswer==1){
			
			privateVariables[1] = 1;
		} else {
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
		} // end if
		
	} // end func
	
}
