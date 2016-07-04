using UnityEngine;
using System.Collections;

public class Conversation_194 : Conversation {
	
	//conversation #194
	//string block 0x0ec2, name Dominus
	int func_071c_result;
	int func_0623_result;
	public override IEnumerator main() {
		SetupConversation (3778);
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
		
		npc.npc_attitude = param1; //param1[0]play_hunger;
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
		
		int[] locals = new int[217];
		
		locals[19] = 15;
		locals[20] = 10001;	//Barter related skill?	
		privateVariables[2] = x_skills( 2, locals[20], locals[19] );
		
		if ( privateVariables[0]==1 ) {
			
			yield return StartCoroutine(say( locals, 001 ));
			locals[21] = 2;
			locals[22] = 3;
			locals[23] = 0;
			//locals[42] = babl_menu( 0, locals[21] );
			yield return StartCoroutine(babl_menu (0,locals,21));   locals[42] = PlayerAnswer;
			switch ( locals[42] ) {
				
			case 1:
				
				goto label_041a;
				
			case 2:
				
				yield return StartCoroutine(say( locals, 004 ));
				locals[43] = 2;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[43] );
				yield break;
			} // end if
			
			//break;
			
		} // end switch
		
		yield return StartCoroutine(say( locals, 005 ));
		locals[44] = 6;
		locals[45] = 7;
		locals[46] = 0;
		//locals[65] = babl_menu( 0, locals[44] );
		yield return StartCoroutine(babl_menu (0,locals,44));   locals[65] = PlayerAnswer;
		switch ( locals[65] ) {
			
		case 1:
			
			goto label_034e;

		case 2:
			
			goto label_03b4;

		} // end switch
		
	label_034e:;
		
		yield return StartCoroutine(say( locals, 008 ));
		locals[66] = 9;
		locals[67] = 10;
		locals[68] = 11;
		locals[69] = 0;
		//locals[87] = babl_menu( 0, locals[66] );
		yield return StartCoroutine(babl_menu (0,locals,66));   locals[87] = PlayerAnswer;
		switch ( locals[87] ) {
			
		case 1:
			
			locals[88] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[88] );
			yield break;

		case 2:
			
			goto label_041a;

		case 3:
			
			locals[89] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[89] );
			yield break;

		} // end switch
		
	label_03b4:;
		
		yield return StartCoroutine(say( locals, 012 ));
		locals[90] = 13;
		locals[91] = 14;
		locals[92] = 15;
		locals[93] = 0;
		//locals[111] = babl_menu( 0, locals[90] );
		yield return StartCoroutine(babl_menu (0,locals,90));   locals[111] = PlayerAnswer;
		switch ( locals[111] ) {
			
		case 1:
			
			locals[112] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[112] );
			yield break;
			
		case 2:
			
			goto label_041a;

		case 3:
			
			locals[113] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[113] );
			yield break;

		} // end switch
		
	label_041a:;
		
		//locals[3] = show_inv( 2, locals[10], locals[5] );
		locals[3] = show_inv( 2, locals, 10, 5 );
		switch ( locals[3] ) {
			
		case 1:
			
			locals[17] = locals[5];
			locals[18] = locals[10];
			locals[4] = 10 - privateVariables[2] / 6;
			yield return StartCoroutine(say( locals, 016 ));
		label_0452:;
			yield return StartCoroutine(func_0623 (locals[4]));
			if ( func_0623_result==1 ) {
				//if ( func_0623( locals[4] )==1 ) {
				
				locals[2] = identify_inv( 4, locals[115], locals[15], locals[114], locals[18] );
				locals[114] = 1;
				locals[115] = 3;
				yield return StartCoroutine(func_071c(locals[18], locals[17]));
				if ( func_071c_result == 0 ) {
					//if ( func_071c( locals[18], locals[17] ) == 0 ) {
					
					locals[116] = 1;
					locals[117] = 7;
					locals[118] = -1;
					locals[119] = -1;
					locals[120] = -1;
					locals[121] = -1;
					locals[122] = -1;
					locals[123] = -1;
					//x_obj_stuff( 9, locals[123], locals[122], locals[121], locals[120], locals[119], locals[118], locals[117], locals[116], locals[18] );
					x_obj_stuff( 9, locals, 123, 122, 121, 120,119, 118, 117, 116, 18 );
					yield return StartCoroutine(say( locals, 017 ));
				} // end if
				
				locals[124] = 18;
				locals[125] = 19;
				locals[126] = 0;
				//locals[145] = babl_menu( 0, locals[124] );
				yield return StartCoroutine(babl_menu (0,locals,124));   locals[145] = PlayerAnswer;
				switch ( locals[145] ) {
					
				case 1:
					
					goto label_041a;
					
				case 2:
					
					locals[146] = 2;
					Time.timeScale =SlomoTime;
					yield return new WaitForSeconds(WaitTime);
					func_00b1( locals[146] );
					yield break;
				} // end if
				
			} //else {
			
			//break;
			
			//} // end switch
			
			yield return StartCoroutine(say( locals, 020 ));
			locals[147] = 21;
			locals[148] = 22;
			locals[149] = 0;
			//locals[168] = babl_menu( 0, locals[147] );
			yield return StartCoroutine(babl_menu (0,locals,147));   locals[168] = PlayerAnswer;
			switch ( locals[168] ) {
				
			case 1:
				
				locals[169] = 2;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[169] );
				yield break;

			case 2:
				
				yield return StartCoroutine(say( locals, 023 ));
				goto label_0452;

			} // end switch
			
			break;
			
		case 0:
			
			yield return StartCoroutine(say( locals, 024 ));
			locals[170] = 25;
			locals[171] = 26;
			locals[172] = 0;
			//locals[191] = babl_menu( 0, locals[170] );
			yield return StartCoroutine(babl_menu (0,locals,170));   locals[191] = PlayerAnswer;
			switch ( locals[191] ) {
				
			case 1:
				
				goto label_041a;

			case 2:
				
				yield return StartCoroutine(say( locals, 027 ));
				locals[192] = 2;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[192] );
				yield break;

			} // end switch
			break;
			
		default:	
			yield return StartCoroutine(say( locals, 028 ));
			locals[193] = 29;
			locals[194] = 30;
			locals[195] = 0;
			//locals[214] = babl_menu( 0, locals[193] );
			yield return StartCoroutine(babl_menu (0,locals,193));   locals[214] = PlayerAnswer;
			//locals[214] == 1;  // expr. has value on stack!
			goto label_041a;
			
		} // end switch
		
		if ( locals[214] == 2 ) {
			
			locals[215] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[215] );
			yield break;
		} // end if
		
		locals[216] = 3;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[216] );
		yield break;
	} // end func
	
	IEnumerator func_0623(int param1) {
		
		int[] locals = new int[43];
		
		locals[21] = 31;
		locals[22] = 32;
		locals[23] = 0;
		//locals[42] = babl_menu( 0, locals[21] );
		yield return StartCoroutine(babl_menu (0,locals,21));   locals[42] = PlayerAnswer;
		switch ( locals[42] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			locals[1] = 0;
			goto label_0714;
			
		} // end switch
		
		//		locals[3] = show_inv( 2, locals[6], locals[11] );
		locals[3] = show_inv( 2,locals, 6, 11);
		if ( locals[3] == 0 ) {
			
			locals[1] = 0;
		} else {
			
			locals[4] = 0;
			locals[5] = 0;
			locals[2] = 1;
			int counter=0;
			int ItemPosToGive=16;
			while ( locals[2] <= locals[3] ) {
				
				if ( (locals[11+counter] == 160 || locals[11+counter] == 161) ) {
					
					locals[4] = locals[4] + count_inv( 1, locals[6+counter] );
					locals[5] = locals[5] + 1;
					locals[ItemPosToGive++] = locals[6+counter];
				} // end if
				counter++;
				locals[2] = locals[2] + 1;
			} // while
			
			//if ( locals[4] >= param1[0]play_hunger ) {
			if ( locals[4] >= param1 ) {
				//give_to_npc( 2, locals[16], locals[5] );
				give_to_npc(2,locals,16,locals[5]);
				locals[1] = 1;
			} else {
				
				locals[1] = 0;
			} // end if
			
		} // end if
		
	label_0714:;
		func_0623_result = locals[1];
		//return locals[1];
	} // end func
	
	IEnumerator func_071c(int param1, int param2) {
		
		int[] locals = new int[11];
		
		locals[2] = param2;//[0]play_hunger;
		if ( 10 == locals[2] ) {
			
			yield return StartCoroutine(say( locals, 033 ));
		} else {
			
			if ( 54 == locals[2] ) {
				
				yield return StartCoroutine(say( locals, 034 ));
			} else {
				
				if ( 55 == locals[2] ) {
					
					yield return StartCoroutine(say( locals, 035 ));
				} else {
					
					if ( 151 == locals[2] ) {
						
						yield return StartCoroutine(say( locals, 036 ));
					} else {
						
						if ( 147 == locals[2] ) {
							
							yield return StartCoroutine(say( locals, 036 ));
						} else {
							
							if ( 174 == locals[2] ) {
								
								yield return StartCoroutine(say( locals, 038 ));
							} else {
								
								if ( 191 == locals[2] ) {
									
									yield return StartCoroutine(say( locals, 039 ));
								} else {
									
									if ( 310 == locals[2] ) {
										
										yield return StartCoroutine(say( locals, 040 ));
									} else {
										
										if ( 287 == locals[2] ) {
											
											yield return StartCoroutine(say( locals, 041 ));
										} else {
											
											locals[1] = 0;
										} // end if
										
									} // end if
									
								} // end if
								
							} // end if
							
						} // end if
						
					} // end if
					
				} // end if
				
			} // end if
			
		} // end if
		
		locals[3] = 1;
		locals[4] = 7;
		locals[5] = -1;
		locals[6] = -1;
		locals[7] = -1;
		locals[8] = -1;
		locals[9] = -1;
		locals[10] = -1;
		//x_obj_stuff( 9, locals[10], locals[9], locals[8], locals[7], locals[6], locals[5], locals[4], locals[3], param1 );
		x_obj_stuff( 9,locals, 10, 9, 8,7,6, 5, 4, 3, param1 );
		yield return StartCoroutine(say( locals, 042 ));
		locals[1] = 1;
		goto label_081a;
		
	label_081a:;
		func_071c_result=locals[1];
		//return locals[1];
	} // end func
	
	IEnumerator func_0822() {
		
		int[] locals = new int[45];
		
		setup_to_barter( 0 );
		while ( privateVariables[1]==0 ) {
			
			locals[1] = 43;
			locals[2] = 44;
			locals[3] = 45;
			locals[4] = 46;
			locals[5] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				func_08d3();
				break;
				
			case 2:
				
				func_092d();
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
		
		locals[23] = 47;
		locals[24] = 0;
		yield return StartCoroutine(babl_menu (0,locals,23));   locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_08d3() {
		
		int[] locals = new int[16];
		
		locals[0] = -1;
		locals[6] = -1;
		locals[11] = 48;
		locals[12] = 49;
		locals[13] = 50;
		locals[14] = 51;
		locals[15] = 52;
		//if ( do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ) ) {
		yield return StartCoroutine (do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6],locals[1]) );
		if (PlayerAnswer==1)	{
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_092d() {
		
		int[] locals = new int[25];
		
		yield return StartCoroutine(say( locals, 053 ));
		locals[1] = 54;
		locals[2] = 55;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			yield break;
			
		} // end switch
		
		locals[23] = 56;
		locals[24] = 57;
		//if ( do_demand( 2, locals[24], locals[23] ) ) {
		yield return StartCoroutine (do_demand( 2, locals[24], locals[23] ));
		if (PlayerAnswer==1){	
			privateVariables[1] = 1;
		} else {
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
		} // end if
		
	} // end func
	
	
	
}
