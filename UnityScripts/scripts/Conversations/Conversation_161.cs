using UnityEngine;
using System.Collections;

public class Conversation_161 : Conversation {
	
	
	//conversation #161
	//	string block 0x0ea1, name Anjor
	//Conversation script heavily rewritted due to complex quest stages.
	public override IEnumerator main() {
		SetupConversation (3745);
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
		
		npc.npc_attitude = param1 ;//param1[0]play_hunger;
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
	*/
	void func_00ea(int param1	) {
		//Set Timer for something.
		//param1[1] = game_days;
		//param1[2] = game_mins;
	} // end func
	
	int func_0106(int param1, int param2) {
		return 1;
		/*
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
		*/
	} // end func
	
	void func_018f(int param1, int param2, int param3) {
		//time counter of some sort
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
		
		int[] locals = new int[598];
		
		if ( privateVariables[0]==1 ) {
			if ( privateVariables[10] ==1) {//Finished all business.
				yield return StartCoroutine(FinishedAllBusiness(locals));
			} else {
				
				if ( privateVariables[9] ==1 ) {//Gave the zanium - waiting for and getting reward.
					
					yield return  StartCoroutine(GaveZanium(locals));
					
				} else {
					
					if ( privateVariables[3] ==1 ) {
						
						yield return StartCoroutine (GoneToGetZanium(locals));
					} else {
						
						if ( privateVariables[11] ==1 ) {
							//?
						} else {
							
							if ( privateVariables[8] ==1 ) {//Gave the code
								yield return StartCoroutine ( GaveTheCode(locals));
								
							} else {
								
								if ( privateVariables[3] ==1) {//Gone to get the zanium after the code section
									
									yield return StartCoroutine (GoneToGetZanium(locals));
									
								} else {
									
									if ( privateVariables[12] ==1 ) {//Have you reconsidered.
										yield return StartCoroutine (Reconsidered(locals));
									} else {
										
										if ( privateVariables[2] ==1 ) {//Offered to get Code
											yield return StartCoroutine (GoneToGetCode(locals));
											
										} else {//Offered to get Zanium
											yield return StartCoroutine(GoneToGetZanium(locals));
										} // end if
									} // end switch
								} // end switch
							} // end if
						} // end if
					}	
				} // end func
			}
		} else {
			
			goto label_02ad;
			
		label_02ad:;
			
			yield return StartCoroutine(say( locals, 001 ));
			locals[9] = 2;
			locals[10] = 3;
			locals[11] = 0;
			//locals[30] = babl_menu( 0, locals[9] );
			yield return StartCoroutine(babl_menu (0,locals,9));
			locals[30] = PlayerAnswer;
			switch ( locals[30] ) {
				
			case 1:
				
				//goto label_02ed;
				yield return StartCoroutine (label_02ed(locals));
				
				break;
				
			case 2:
				
				goto label_06ae;
				
				break;
				
			} // end switch
			
			
		label_06ae:;
			
			yield return StartCoroutine(say( locals, 040 ));
			locals[339] = 41;
			locals[340] = 42;
			locals[341] = 0;
			//locals[360] = babl_menu( 0, locals[339] );
			yield return StartCoroutine(babl_menu (0,locals,339));
			locals[360] = PlayerAnswer;
			switch ( locals[360] ) {
				
			case 1:
				
				//goto label_02ed;
				yield return StartCoroutine (label_02ed(locals));
				
				break;
				
			case 2:
				
				yield return StartCoroutine(say( locals, 033 ));
				locals[361] = 2;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[361] );
				yield break;
				break;
			} // end if
			
			
			
		} // end switch
		
		
	}
	
	IEnumerator FinishedAllBusiness(int[] locals)
	{
		yield return StartCoroutine(say( locals, 087 ));
		locals[574] = 3;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[574] );
		yield break;
	}
	
	IEnumerator GaveZanium(int[] locals)
	{
		if ( func_0106( 48, 45 ) == 0 ) {
			
			func_018f( locals[6], 48, 45 );
			if ( locals[7] == 1 ) {
				
				locals[3] = 74;
			} else {
				
				locals[3] = 75;
			} // end if
			
			yield return StartCoroutine(say( locals, 076 ));
			locals[502] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[502] );
			yield break;
		} // end if
		
		yield return StartCoroutine(say( locals, 077 ));
		privateVariables[10] = 1;
		locals[503] = 175;
		do_inv_create( 1, locals[503] );
		locals[504] = 175;
		take_from_npc( 1, locals[504] );
		locals[505] = 3;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[505] );
		yield break;
		yield return StartCoroutine(say( locals, 078 ));
		locals[506] = 79;
		locals[507] = 80;
		locals[508] = 0;
		//locals[527] = babl_menu( 0, locals[506] );
		yield return StartCoroutine(babl_menu (0,locals,506));
		locals[527] = PlayerAnswer;
		switch ( locals[527] ) {
			
		case 1:
			
			//goto label_02ed;
			yield return StartCoroutine (label_02ed(locals));
			
			break;
			
		case 2:
			
			locals[528] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[528] );
			yield break;
			break;
		} // end if
	}
	
	
	IEnumerator GaveTheCode(int[] locals)
	{
		/**********Gave the code private var 8*****/
		if ( privateVariables[20] ==1) {
			
			yield return StartCoroutine(say( locals, 054 ));
			locals[409] = 55;
			locals[410] = 56;
			locals[411] = 0;
			//locals[430] = babl_menu( 0, locals[409] );
			yield return StartCoroutine(babl_menu (0,locals,409));
			locals[430] = PlayerAnswer;
			switch ( locals[430] ) {
				
			case 1:
				
				yield return StartCoroutine( label_0605(locals));
				
				break;
				
			case 2:
				
				privateVariables[11] = 1;
				yield return StartCoroutine(say( locals, 057 ));
				locals[431] = 2;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[431] );
				yield break;
				break;
			} // end if
			
		} else {
			yield return StartCoroutine(say( locals, 058 ));
			locals[432] = 59;
			locals[433] = 60;
			locals[434] = 61;
			locals[435] = 0;
			//locals[453] = babl_menu( 0, locals[432] );
			yield return StartCoroutine(babl_menu (0,locals,432));
			locals[453] = PlayerAnswer;
			switch ( locals[453] ) {
				
			case 1:
				
				//goto label_0798;
				yield return StartCoroutine (label_0798 (locals));
				
				break;
				
			case 2:
				
				locals[454] = 2;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[454] );
				yield break;
				break;
				
			case 3:
				
				//goto label_0605;
				yield return StartCoroutine( label_0605(locals));
				break;
			} // end if
			
		} // end if
	}
	
	
	IEnumerator label_0605(int[] locals)
	{
		privateVariables[2] = 0;
		privateVariables[3] = 1;
		yield return StartCoroutine(say( locals, 034 ));
		locals[292] = 297;
		if ( take_from_npc( 1, locals[292] ) == 2 ) {
			
			yield return StartCoroutine(say( locals, 035 ));
		} // end if
		
		locals[293] = 36;
		locals[294] = 0;
		//locals[314] = babl_menu( 0, locals[293] );
		yield return StartCoroutine(babl_menu (0,locals,293));
		locals[314] = PlayerAnswer;
		if ( locals[314] == 1 ) {
			
			locals[315] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[315] );
			yield break;
		} // end if
	}
	
	
	
	
	IEnumerator GoneToGetCode(int[] locals)
	{
		yield return StartCoroutine(say( locals, 044 ));
		locals[362] = 45;
		locals[363] = 46;
		locals[364] = 47;
		locals[365] = 0;
		//locals[383] = babl_menu( 0, locals[362] );
		yield return StartCoroutine(babl_menu (0,locals,362));
		locals[383] = PlayerAnswer;
		switch ( locals[383] ) {
			
		case 1:
			
			//goto label_0798;
			yield return StartCoroutine (label_0798 (locals));
			break;
			
		case 2:
			
			//goto label_07d8;
			yield return StartCoroutine (label_07d8 (locals));
			
			break;
			
		case 3:
			
			//goto label_0605;
			yield return StartCoroutine( label_0605(locals));
			
			break;
			
		} // end switch
		
		
		
		
		
		
		
	} // end if
	
	
	
	
	//}
	
	IEnumerator GoneToGetZanium(int[] locals)
	{
		yield return StartCoroutine(say( locals, 062 ));
		locals[455] = 63;
		locals[456] = 64;
		locals[457] = 0;
		//locals[476] = babl_menu( 0, locals[455] );
		yield return StartCoroutine(babl_menu (0,locals,455));
		locals[476] = PlayerAnswer;
		switch ( locals[476] ) {
			
		case 1:
			
			goto label_0917;
			
			break;
			
		case 2:
			
			goto label_0957;
			
			break;
			
		} // end switch
		
	label_0917:;
		
		yield return StartCoroutine(say( locals, 065 ));
		locals[477] = 66;
		locals[478] = 67;
		locals[479] = 0;
		//locals[498] = babl_menu( 0, locals[477] );
		yield return StartCoroutine(babl_menu (0,locals,477));
		locals[498] = PlayerAnswer;
		switch ( locals[498] ) {
			
		case 1:
			
			//goto label_0965;
			yield return StartCoroutine(label_0965(locals));
			
			break;
			
		case 2:
			
			goto label_0957;
			
			break;
			
		} // end switch
		
	label_0957:;
		
		yield return StartCoroutine(say( locals, 068 ));
		locals[499] = 3;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[499] );
		yield break;
		
		
		
	}
	
	IEnumerator Reconsidered(int[] locals)
	{
		yield return StartCoroutine(say( locals, 081 ));
		locals[529] = 82;
		locals[530] = 83;
		locals[531] = 0;
		//locals[550] = babl_menu( 0, locals[529] );
		yield return StartCoroutine(babl_menu (0,locals,529));
		locals[550] = PlayerAnswer;
		switch ( locals[550] ) {
			
		case 1:
			
			//goto label_0572;
			yield return StartCoroutine (label_0572(locals));
			
			break;
			
		case 2:
			
			//goto label_05b7;
			yield return StartCoroutine (label_05b7(locals));
			break;	
		} // end if
	}
	
	IEnumerator label_0965(int[] locals)
	{
		locals[500] = 297;
		int[] fishfinder = new int[6];
		//0,1,2,3 = slots with fish
		//4 = no of fish found.
		//5 = no of slots found
		find_barter_total(5,4,0,5,locals[500],fishfinder);
		privateVariables[22]=fishfinder[4];
		//find_barter_total( 4, 53, 54, 52, locals[500] );
		if ( privateVariables[22] == 0 ) {
			
			yield return StartCoroutine(say( locals, 069 ));
		} else {
			
			if ( privateVariables[22] < 80 ) {
				
				if ( privateVariables[22] == 1 ) {
					
					locals[2] = 70;
				} else {
					
					locals[2] = 71;
				} // end if
				
				yield return StartCoroutine(say( locals, 072 ));
			} else {
				
				//give_to_npc( 2, 54, 52 );
				give_to_npc(2,fishfinder,0,fishfinder[5]);
				privateVariables[9] = 1;
				yield return StartCoroutine(say( locals, 073 ));
				func_00ea( 45 );
				/*
								privateVariables[17][1] = 0;
								privateVariables[17][2] = 60;
								*/
				locals[501] = 3;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[501] );
				yield break;
			} // end if
			
		} // end switch
		
		
		
		locals[575] = 88;
		locals[576] = 89;
		locals[577] = 0;
		//locals[596] = babl_menu( 0, locals[575] );
		yield return StartCoroutine(babl_menu (0,locals,575));
		locals[596] = PlayerAnswer;
		switch ( locals[596] ) {
			
		case 1:
			
			//goto label_0965;
			yield return StartCoroutine(label_0965(locals));
			
			break;
			
		case 2:
			
			yield return StartCoroutine(say( locals, 090 ));
			locals[597] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[597] );
			yield break;
			break;
			
		} // end switch
		
		
	}
	
	
	IEnumerator label_02ed(int[] locals)
	{
		yield return StartCoroutine(say( locals, 004 ));
		locals[31] = 5;
		locals[32] = 6;
		locals[33] = 0;
		//locals[52] = babl_menu( 0, locals[31] );
		yield return StartCoroutine(babl_menu (0,locals,31));
		locals[52] = PlayerAnswer;
		switch ( locals[52] ) {
			
		case 1:
			
			//goto label_032d;
			yield return StartCoroutine (label_032d(locals));
			
			break;
			
		case 2:
			
			//goto label_03d9;
			yield return StartCoroutine (label_03d9(locals));
			
			break;
			
		} // end switch
	}
	
	
	IEnumerator label_032d(int[] locals)
	{
		privateVariables[4] = 1;
		if ( privateVariables[5]==1 ) {
			
			locals[1] = 7;
		} else {
			
			locals[1] = 8;
		} // end if
		
		yield return StartCoroutine(say( locals, 009 ));
		//locals[5] = !privateVariables[5];
		if (privateVariables[5]==1)
		{
			locals[5]=0;
		}
		else
		{
			locals[5]=1;
		}
		locals[74] = locals[5];
		locals[53] = 10;
		locals[75] = privateVariables[5];
		locals[54] = 11;
		locals[76] = privateVariables[5];
		locals[55] = 12;
		locals[77] = locals[5];
		locals[56] = 13;
		locals[57] = 0;
		//locals[95] = babl_fmenu( 0, locals[53], locals[74] );
		yield return StartCoroutine(babl_fmenu (0,locals,53,74));
		locals[95] = PlayerAnswer;
		switch ( locals[95] ) {
			
		case 10:
			
			//goto label_03d9;
			yield return StartCoroutine (label_03d9(locals));
			
			break;
			
		case 11:
			
			//goto label_0455;
			yield return StartCoroutine (label_0455(locals));
			
			break;
			
		case 12:
			
			//goto label_04d2;
			yield return StartCoroutine (label_04d2 (locals));
			
			break;
			
		case 13:
			
			//goto label_03d9;
			yield return StartCoroutine (label_03d9(locals));
			
			break;
			
		} // end switch
	}
	
	
	IEnumerator label_0798(int[] locals)
	{
		yield return StartCoroutine(say( locals, 048 ));
		locals[384] = 49;
		locals[385] = 50;
		locals[386] = 0;
		//locals[405] = babl_menu( 0, locals[384] );
		yield return StartCoroutine(babl_menu (0,locals,384));
		locals[405] = PlayerAnswer;
		switch ( locals[405] ) {
			
		case 1:
			
			//goto label_07e6;
			yield return StartCoroutine (label_07e6 (locals));
			
			break;
			
		case 2:
			
			//goto label_07d8;
			yield return StartCoroutine (label_07d8 (locals));
			break;
			
		} // end switch
	}
	
	IEnumerator label_0572(int[] locals)
	{
		privateVariables[12] = 0;
		yield return StartCoroutine(say( locals, 028 ));
		locals[247] = 29;
		locals[248] = 30;
		locals[249] = 0;
		//locals[268] = babl_menu( 0, locals[247] );
		yield return StartCoroutine(babl_menu (0,locals,247));
		locals[268] = PlayerAnswer;
		switch ( locals[268] ) {
			
		case 1:
			
			//goto label_065b;
			
			yield return StartCoroutine (label_065b(locals));
			break;
			
		case 2:
			
			//goto label_0605;
			yield return StartCoroutine( label_0605(locals));
			
			break;
			
		} // end switch
	}
	
	
	IEnumerator label_05b7(int [] locals)
	{
		privateVariables[12] = 1;
		yield return StartCoroutine(say( locals, 031 ));
		locals[269] = 32;
		locals[270] = 33;
		locals[271] = 0;
		//locals[290] = babl_menu( 0, locals[269] );
		yield return StartCoroutine(babl_menu (0,locals,269));
		locals[290] = PlayerAnswer;
		switch ( locals[290] ) {
			
		case 1:
			
			//goto label_0572;
			yield return StartCoroutine (label_0572(locals));
			
			break;
			
		case 2:
			
			locals[291] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[291] );
			yield break;
			break;
			
		} // end switch
	}
	
	
	IEnumerator label_03d9(int[] locals)
	{
		privateVariables[5] = 1;
		yield return StartCoroutine(say( locals, 014 ));
		//locals[5] = !privateVariables[4];
		if (privateVariables[4]==1)
		{
			locals[5]=0;
		}
		else
		{
			locals[5]=1;
		}
		
		locals[117] = locals[5];
		locals[96] = 15;
		locals[118] = 1;
		locals[97] = 16;
		locals[119] = 1;
		locals[98] = 17;
		locals[99] = 0;
		//locals[138] = babl_fmenu( 0, locals[96], locals[117] );
		yield return StartCoroutine(babl_fmenu (0,locals,96,117));
		locals[138] = PlayerAnswer;
		switch ( locals[138] ) {
			
		case 15:
			
			//goto label_032d;
			yield return StartCoroutine (label_032d(locals));
			
			break;
			
		case 16:
			
			//goto label_0455;
			yield return StartCoroutine (label_0455(locals));
			
			break;
			
		case 17:
			
			//goto label_04d2;
			yield return StartCoroutine (label_04d2 (locals));
			
			break;
			
		} // end switch
	}
	
	IEnumerator label_0455(int[] locals)
	{
		privateVariables[6] = 1;
		yield return StartCoroutine(say( locals, 018 ));
		//locals[5] = !privateVariables[7];
		if (privateVariables[7]==1)
		{
			locals[5]=0;
		}
		else
		{
			locals[5]=1;
		}
		locals[160] = locals[5];
		locals[139] = 19;
		locals[161] = privateVariables[7];
		locals[140] = 20;
		locals[162] = 1;
		locals[141] = 21;
		locals[142] = 0;
		//locals[181] = babl_fmenu( 0, locals[139], locals[160] );
		yield return StartCoroutine(babl_fmenu (0,locals,139,160));
		locals[181] = PlayerAnswer;
		switch ( locals[181] ) {
			
		case 19:
			
			//goto label_04d2;
			yield return StartCoroutine (label_04d2 (locals));
			
			break;
			
		case 20:
			
			//goto label_0532;
			yield return StartCoroutine (label_0532(locals));
			
			break;
			
		case 21:
			
			//goto label_0572;
			yield return StartCoroutine (label_0572(locals));
			
			break;
			
		} // end switch
	}
	
	IEnumerator label_04d2(int[] locals)
	{
		privateVariables[7] = 1;
		yield return StartCoroutine(say( locals, 022 ));
		//locals[5] = !privateVariables[6];
		if (privateVariables[6]==1)
		{
			locals[5]=0;
		}
		else
		{
			locals[5]=1;
		}
		locals[203] = 1;
		locals[182] = 23;
		locals[204] = locals[5];
		locals[183] = 24;
		locals[184] = 0;
		//locals[224] = babl_fmenu( 0, locals[182], locals[203] );
		yield return StartCoroutine(babl_fmenu (0,locals,182,203));
		locals[224] = PlayerAnswer;
		switch ( locals[224] ) {
			
		case 23:
			
			//goto label_0532;
			yield return StartCoroutine (label_0532(locals));
			
			break;
			
		case 24:
			
			//goto label_0455;
			yield return StartCoroutine (label_0455(locals));
			
			break;
			
		} // end switch
	}
	
	
	IEnumerator label_0532(int[] locals)
	{
		yield return StartCoroutine(say( locals, 025 ));
		locals[225] = 26;
		locals[226] = 27;
		locals[227] = 0;
		//locals[246] = babl_menu( 0, locals[225] );
		yield return StartCoroutine(babl_menu (0,locals,225));
		locals[246] = PlayerAnswer;
		switch ( locals[246] ) {
			
		case 1:
			
			//goto label_0572;
			yield return StartCoroutine (label_0572(locals));
			
			break;
			
		case 2:
			
			//goto label_05b7;
			yield return StartCoroutine (label_05b7(locals));
			
			break;
			
		} // end switch
	}
	
	IEnumerator label_07e6(int[] locals)
	{
		privateVariables[8] = 1;
		//locals[4] = babl_ask( 0 );
		yield return StartCoroutine (babl_ask (0));
		//locals[4]=PlayerTypedAnswer;
		locals[407] = 52;
		if ( contains( 2, PlayerTypedAnswer, locals[407] )==1 ) {
			
			privateVariables[20] = 1;
		} else {
			
			privateVariables[20] = 0;
		} // end if
		
		yield return StartCoroutine(say( locals, 053 ));
		locals[408] = 2;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[408] );
		yield break;
	}
	
	IEnumerator 	label_07d8(int[] locals)
	{
		yield return StartCoroutine(say( locals, 051 ));
		locals[406] = 2;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[406] );
		yield break;
	}
	
	IEnumerator label_065b(int[] locals)
	{
		privateVariables[2] = 1;
		privateVariables[3] = 0;
		yield return StartCoroutine(say( locals, 037 ));
		locals[316] = 38;
		locals[317] = 39;
		locals[318] = 0;
		//locals[337] = babl_menu( 0, locals[316] );
		yield return StartCoroutine(babl_menu (0,locals,316));
		locals[337] = PlayerAnswer;
		switch ( locals[337] ) {
			
		case 1:
			
			//goto label_0605;
			yield return StartCoroutine( label_0605(locals));
			
			break;
			
		case 2:
			
			locals[338] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[338] );
			yield break;
			break;
			
		} // end switch
	}
	
	IEnumerator ReconsiderZanium(int[] locals)
	{
		yield return StartCoroutine(say( locals, 084 ));
		locals[551] = 85;
		locals[552] = 86;
		locals[553] = 0;
		//locals[572] = babl_menu( 0, locals[551] );
		yield return StartCoroutine(babl_menu (0,locals,551));
		locals[572] = PlayerAnswer;
		switch ( locals[572] ) {
			
		case 1:
			
			//goto label_0605;
			yield return StartCoroutine( label_0605(locals));
			
			break;
			
		case 2:
			
			locals[573] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[573] );
			yield break;
			break;
		} // end if
		
	}
	
}
