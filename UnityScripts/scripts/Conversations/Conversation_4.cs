using UnityEngine;
using System.Collections;

public class Conversation_4 : Conversation {
	//conversation #4
	//	string block 0x0e04, name Shanklick  The worst conversation...
	
	int func_0fef_result;
	int func_0f6f_result;
	int func_1060_result;
	public override IEnumerator main() {
		SetupConversation (3588);
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
		
		int[] locals = new int[779];
		
		if ( privateVariables[0] == 0) {
			privateVariables[2] = 0;
			privateVariables[4] = 0;
			privateVariables[5] = 0;
			privateVariables[8] = 0;
			privateVariables[6] = 0;
			privateVariables[9] = 0;
			privateVariables[10] = 0;
			privateVariables[11] = 0;
			privateVariables[12] = 1;
			privateVariables[13] = 1;
			locals[3] = 1;
			locals[4] = 2;
			privateVariables[15] = sex( 2, locals[4], locals[3] );
		} else {
			
			
			/*******start block to move***********/
			
			
			
			locals[621] = npc.npc_attitude;
			if ( 3 == locals[621] ) {
				
				yield return StartCoroutine(say( locals, 101 ));
			} else {
				
				if ( 2 == locals[621] ) {
					
					yield return StartCoroutine(say( locals, 102 ));
				} else {
					
					if ( 1 == locals[621] ) {
						
						yield return StartCoroutine(say( locals, 103 ));
						yield return StartCoroutine(func_10b6());
						//After apology
						//goto label_04c2;
					} else {
						
						if ( 0 == locals[621] ) {
							
							yield return StartCoroutine(say( locals, 104 ));
							Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
						} // end if
						
					} // end if
					
				} // end if
				
			} // end if
			
			//} // end if
			
			locals[622] = privateVariables[2];
			//The stage in the conversation shanlick got mad.
			if ( 0 == locals[622] ) {
				goto label_whyyouhere;
			} else {
				
				if ( 1 == locals[622] ) {
					goto label_0374;
				} else {
					
					if ( 2 == locals[622] ) {
						goto label_041c;
					} else {
						
						if ( 3 == locals[622] ) {
							
						} else {
							
							if ( 4 == locals[622] ) {
								
							} else {
								
								if ( 5 == locals[622] ) {
									
								} else {
									
									if ( 6 == locals[622] ) {
										
									} else {
										
										if ( 7 == locals[622] ) {
											
										} else {
											
											if ( 8 == locals[622] ) {
												yield return StartCoroutine (ResumeTopic(locals));
											} else {
												
												yield return StartCoroutine(say( locals, 105 ));
												Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
												
												yield return StartCoroutine(label_0d72(locals));
												
												//break;
												
											} // end switch
											
										}
									}
								}
							}
						}
					}
				}
			}
			
			
			
			locals[511] = privateVariables[9];
			locals[490] = 92;
			locals[512] = privateVariables[10];
			locals[491] = 93;
			locals[513] = 1;
			locals[492] = 94;
			locals[493] = 0;
			//locals[532] = babl_fmenu( 0, locals[490], locals[511] );
			yield return StartCoroutine(babl_fmenu (0,locals,490,511));
			locals[532] = PlayerAnswer;
			switch ( locals[532] ) {
				
			case 92:
				
				//goto label_0c01;
				yield return StartCoroutine (label_0c01(locals));
				
				break;
				
			case 93:
				
				//goto label_0c5e;
				yield return StartCoroutine (label_0c5e(locals));
				break;
				
			case 94:
				
				Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
				break;
				
			} // end switch
			
			yield return StartCoroutine (label_0c01(locals));
			
			yield return StartCoroutine (label_0c5e(locals));
			
			
			
			
			
			/*******end block block to move***********/
			
			
			
			
			
			
			
			
			
			
		} // end if
		
	label_whyyouhere:;
		
		if ( privateVariables[0] == 0 ) {
			
			yield return StartCoroutine(say( locals, 003 ));
		} else {
			
			yield return StartCoroutine(say( locals, 004 ));
		} // end if
		
		locals[5] = 5;
		locals[6] = 6;
		locals[7] = 7;
		locals[8] = 8;
		locals[9] = 0;
		//locals[26] = babl_menu( 0, locals[5] );
		yield return StartCoroutine(babl_menu (0,locals,5));
		locals[26] = PlayerAnswer;
		switch ( locals[26] ) {
			
		case 1:
			
			goto label_0374;
			
			break;
			
		case 2:
			
			goto label_041c;
			
			break;
			
		case 3:
			
			goto label_0996;
			
			break;
			
		case 4:
			
			locals[27] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[27] );
			yield break;
			break;
			
		} // end switch
		
		//} // end if
		
		
	label_0374:;
		
		if ( privateVariables[2] < 1 ) {
			
			privateVariables[2] = 1;
			yield return StartCoroutine(say( locals, 009 ));
		} else {
			
			yield return StartCoroutine(say( locals, 010 ));
		} // end if
		
		locals[49] = 1;
		locals[28] = 11;
		locals[50] = privateVariables[12];
		locals[29] = 12;
		locals[51] = privateVariables[13];
		locals[30] = 13;
		locals[52] = 1;
		locals[31] = 14;
		locals[32] = 0;
		//locals[70] = babl_fmenu( 0, locals[28], locals[49] );
		yield return StartCoroutine(babl_fmenu (0,locals,28,49));
		locals[70] = PlayerAnswer;
		switch ( locals[70] ) {
			
		case 11:
			
			goto label_04c2;
			
			break;
			
		case 12:
			
			goto label_06da;
			
			break;
			
		case 13:
			
			goto label_0880;
			
			break;
			
		case 14:
			
			locals[71] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[71] );
			yield break;
			break;
			
		} // end switch
		
		//} // end if
		
		//} // end if
		
	label_041c:;
		
		if ( privateVariables[2] < 2 ) {
			
			privateVariables[2] = 2;
			yield return StartCoroutine(say( locals, 015 ));
		} else {
			
			yield return StartCoroutine(say( locals, 016 ));
		} // end if
		
		locals[72] = 17;
		locals[73] = 18;
		locals[74] = 19;
		locals[75] = 20;
		locals[76] = 0;
		//locals[93] = babl_menu( 0, locals[72] );
		yield return StartCoroutine(babl_menu (0,locals,72));
		locals[93] = PlayerAnswer;
		switch ( locals[93] ) {
			
		case 1:
			
			goto label_04c2;
			
			break;
			
		case 2:
			
			goto label_0622;
			
			break;
			
		case 3:
			
			goto label_068e;
			
			break;
			
		case 4:
			yield return StartCoroutine(func_0fef());
			locals[1] = func_0fef_result;
			locals[94] = locals[1];
			if ( 0 == locals[94] ) {
				
			} else {
				
				if ( 1 == locals[94] ) {
					
					locals[95] = 1;
				} // end if
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[95] );
				yield break;
			} //else {
			
			break;
			
			//} // end switch
			
		} // end if
		
	label_04c2:;
		
		if ( privateVariables[2] < 3 ) {
			
			privateVariables[2] = 3;
			yield return StartCoroutine(say( locals, 021 ));
		} else {
			
			yield return StartCoroutine(say( locals, 022 ));
		} // end if
		
		locals[96] = 23;
		locals[97] = 24;
		locals[98] = 0;
		//locals[117] = babl_menu( 0, locals[96] );
		yield return StartCoroutine(babl_menu (0,locals,96));
		locals[117] = PlayerAnswer;
		switch ( locals[117] ) {
			
		case 1:
			
			//goto label_0514;
			yield return StartCoroutine (label_0514 (locals));
			break;
			
		case 2:
			
			goto label_056b;
			
			break;
			
		} // end switch
		
		//} // end if
		
		
		yield return StartCoroutine (label_0514 (locals));
		
		
		//} // end if
		
	label_056b:;
		
		if ( privateVariables[5] == 0) {
			
			yield return StartCoroutine(say( locals, 029 ));
		} else {
			
			yield return StartCoroutine(say( locals, 030 ));
		} // end if
		
		locals[140] = 31;
		locals[141] = 32;
		locals[142] = 0;
		//locals[161] = babl_menu( 0, locals[140] );
		yield return StartCoroutine(babl_menu (0,locals,140));
		locals[161] = PlayerAnswer;
		switch ( locals[161] ) {
			
		case 1:
			
			//goto label_0514;
			yield return StartCoroutine(label_0514 (locals));
			break;
			
		case 2:
			yield return StartCoroutine(func_0fef());
			locals[1] = func_0fef_result;
			locals[162] = locals[1];
			if ( 0 == locals[162] ) {
				
			} else {
				
				if ( 1 == locals[162] ) {
					
					locals[163] = 1;
				} // end if
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[163] );
				yield break;
			} //else {
			
			break;
			
		} // end switch
		
		
		
	label_0622:;
		
		yield return StartCoroutine(say( locals, 036 ));
		locals[186] = 37;
		locals[187] = 38;
		locals[188] = 40;
		locals[189] = 0;
		//locals[207] = babl_menu( 0, locals[186] );
		yield return StartCoroutine(babl_menu (0,locals,186));
		locals[207] = PlayerAnswer;
		switch ( locals[207] ) {
			
		case 1:
			
			goto label_04c2;
			
			break;
			
		case 2:
			
			yield return StartCoroutine(say( locals, 039 ));
			locals[208] = 1;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[208] );
			yield break;
			break;
			
		case 3:
			
			yield return StartCoroutine(say( locals, 041 ));
			locals[209] = 1;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[209] );
			yield break;
			break;
			
		} // end switch
		
	label_068e:;
		
		yield return StartCoroutine(say( locals, 042 ));
		locals[210] = 43;
		locals[211] = 44;
		locals[212] = 0;
		//locals[231] = babl_menu( 0, locals[210] );
		yield return StartCoroutine(babl_menu (0,locals,210));
		locals[231] = PlayerAnswer;
		switch ( locals[231] ) {
			
		case 1:
			
			//goto label_0a86;
			yield return StartCoroutine(label_0a86(locals));
			
			break;
			
		case 2:
			
			yield return StartCoroutine(say( locals, 045 ));
			locals[232] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[232] );
			yield break;
			break;
			
		} // end switch
		
		//} // end if
		
	label_06da:;
		
		locals[233] = 32;
		if ( get_quest( 1, locals[233] ) >= 3 ) {
			
		} else {
			
			if ( privateVariables[13]==1 ) {
				
				yield return StartCoroutine(say( locals, 046 ));
			} else {
				
				yield return StartCoroutine(say( locals, 047 ));
			} // end if
			
			locals[234] = 48;
			locals[235] = 49;
			locals[236] = 50;
			locals[237] = 0;
			//locals[255] = babl_menu( 0, locals[234] );
			yield return StartCoroutine(babl_menu (0,locals,234));
			locals[255] = PlayerAnswer;
			switch ( locals[255] ) {
				
			case 1:
				
				goto label_077a;
				
				break;
				
			case 2:
				
				goto label_0876;
				
				break;
				
			case 3:
				yield return StartCoroutine(func_0fef());
				locals[1] = func_0fef_result;
				locals[256] = locals[1];
				if ( 0 == locals[256] ) {
					
				} else {
					
					if ( 1 == locals[256] ) {
						
						locals[257] = 1;
					} // end if
					Time.timeScale =SlomoTime;
					yield return new WaitForSeconds(WaitTime);
					func_00b1( locals[257] );
					yield break;
				} //else {
				
				//} // end if
				
				break;
				
			} // end switch
			
		} // end if
		
	label_077a:;
		
		if ( privateVariables[2] < 6 ) {
			
			privateVariables[2] = 6;
			yield return StartCoroutine(say( locals, 051 ));
		} else {
			
			yield return StartCoroutine(say( locals, 052 ));
		} // end if
		
		locals[258] = 53;
		locals[259] = 54;
		locals[260] = 55;
		locals[261] = 0;
		//locals[279] = babl_menu( 0, locals[258] );
		yield return StartCoroutine(babl_menu (0,locals,258));
		locals[279] = PlayerAnswer;
		switch ( locals[279] ) {
			
		case 1:
			
			privateVariables[7] = 1;
			//goto label_0514;
			yield return StartCoroutine(label_0514 (locals));
			break;
			
		case 2:
			
			privateVariables[7] = 1;
			goto label_07f6;
			
			break;
			
		case 3:
			
			yield return StartCoroutine(say( locals, 056 ));
			locals[280] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[280] );
			yield break;
			break;
			
		} // end switch
		
	label_07f6:;
		
		yield return StartCoroutine(say( locals, 057 ));
		locals[281] = 58;
		locals[282] = 59;
		locals[283] = 0;
		//locals[302] = babl_menu( 0, locals[281] );
		yield return StartCoroutine(babl_menu (0,locals,281));
		locals[302] = PlayerAnswer;
		switch ( locals[302] ) {
			
		case 1:
			
			//goto label_0e48;
			yield return StartCoroutine (label_0e48(locals));
			
			break;
			
		case 2:
			
			goto label_0836;
			
			break;
			
		} // end switch
		
	label_0836:;
		
		yield return StartCoroutine(say( locals, 060 ));
		locals[303] = 61;
		locals[304] = 62;
		locals[305] = 0;
		//locals[324] = babl_menu( 0, locals[303] );
		yield return StartCoroutine(babl_menu (0,locals,303));
		locals[324] = PlayerAnswer;
		switch ( locals[324] ) {
			
		case 1:
			
			//goto label_0e48;
			yield return StartCoroutine (label_0e48(locals));
			
			break;
			
		case 2:
			
			goto label_0996;
			
			break;
			
		} // end switch
		
	label_0876:;
		
		privateVariables[12] = 0;
		yield return StartCoroutine(say( locals, 063 ));
		goto label_0374;
		
		//} // end if
		
	label_0880:;
		
		yield return StartCoroutine(say( locals, 064 ));
		locals[325] = 65;
		locals[326] = 66;
		locals[327] = 67;
		locals[328] = 0;
		//locals[346] = babl_menu( 0, locals[325] );
		yield return StartCoroutine(babl_menu (0,locals,325));
		locals[346] = PlayerAnswer;
		switch ( locals[346] ) {
			
		case 1:
			
			goto label_0900;
			
			break;
			
		case 2:
			
			goto label_098c;
			
			break;
			
		case 3:
			yield return StartCoroutine(func_0fef());
			locals[1] = func_0fef_result;
			locals[347] = locals[1];
			if ( 0 == locals[347] ) {
				
			} else {
				
				if ( 1 == locals[347] ) {
					
					locals[348] = 1;
				} // end if
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[348] );
				yield break;
			} //else {
			
			break;
			
		} // end switch
		
		//} // end if
		
	label_0900:;
		
		yield return StartCoroutine(say( locals, 068 ));
		locals[349] = 69;
		locals[350] = 70;
		locals[351] = 72;
		locals[352] = 0;
		//locals[370] = babl_menu( 0, locals[349] );
		yield return StartCoroutine(babl_menu (0,locals,349));
		locals[370] = PlayerAnswer;
		switch ( locals[370] ) {
			
		case 1:
			
			goto label_098c;
			
			break;
			
		case 2:
			
			yield return StartCoroutine(say( locals, 071 ));
			locals[371] = 1;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[371] );
			yield break;
			break;
			
		case 3:
			yield return StartCoroutine(func_0fef());
			locals[1] = func_0fef_result;
			locals[372] = locals[1];
			if ( 0 == locals[372] ) {
				
			} else {
				
				if ( 1 == locals[372] ) {
					
					locals[373] = 1;
				} // end if
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[373] );
				yield break;
			} //else {
			
			break;
			
		} // end switch
		
	label_098c:;
		
		privateVariables[13] = 0;
		yield return StartCoroutine(say( locals, 073 ));
		goto label_0374;
		
	label_0996:;
		
		yield return StartCoroutine(say( locals, 074 ));
		yield return StartCoroutine(func_0f6f());
		locals[1] = func_0f6f_result;
		locals[374] = locals[1];
		if ( 0 == locals[374] ) {
			
			func_0fe4();
		} else {
			
			if ( 1 == locals[374] ) {
				
			} else {
				
				if ( 2 == locals[374] ) {
					
					locals[375] = 1;
					Time.timeScale =SlomoTime;
					yield return new WaitForSeconds(WaitTime);
					func_00b1( locals[375] );
					yield break;
				} // end if
				
			} // end if
			
			yield return StartCoroutine(say( locals, 075 ));
			locals[376] = 1;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[376] );
			yield break;
			//goto label_09e3;
			yield return StartCoroutine (label_09e3 (locals));
			
			//goto label_0a86;
			yield return StartCoroutine (label_0a86 (locals));
			
			//goto label_0adb;
			yield return StartCoroutine(label_0adb(locals));
			
		} // end if
		
		
		
		//Start of moved block
		
		
		
		
		
		
		//} // end switch
		
		//end Block moved from here.
		
		
		yield return StartCoroutine (label_0e48(locals));	
		
		yield return StartCoroutine (label_0e9e(locals));
		
		
	} // end func
	
	
	IEnumerator func_0f6f() {
		
		int[] locals = new int[24];
		
		privateVariables[14] = 1;
		locals[2] = 123;
		locals[3] = 124;
		locals[4] = 125;
		locals[5] = 0;
		yield return StartCoroutine(babl_menu (0,locals,2));   locals[23] = PlayerAnswer;
		switch ( locals[23] ) {
			
		case 1:
			
			locals[1] = 0;
			goto label_0fdc;
			
			break;
			
		case 2:
			
			locals[1] = 1;
			goto label_0fdc;
			
			break;
			
		case 3:
			
			locals[1] = 2;
			goto label_0fdc;
			
			break;
			
		} // end switch
		
		
	label_0fdc:;
		
		//return locals[1];
		func_0f6f_result=locals[1];
	} // end func
	
	IEnumerator func_0fe4() {
		int[] locals = new int[1];
		yield return StartCoroutine(say( locals, 126 ));
	} // end func
	
	IEnumerator func_0fef() {
		
		int[] locals = new int[24];
		
		if ( privateVariables[5] == 0) {
			
			privateVariables[5] = 1;
			yield return StartCoroutine(say( locals, 127 ));
			locals[2] = 128;
			locals[3] = 129;
			locals[4] = 0;
			yield return StartCoroutine(babl_menu (0,locals,2));   locals[23] = PlayerAnswer;
			switch ( locals[23] ) {
				
			case 1:
				
				locals[1] = 0;
				goto label_1058;
				
				break;
				
			case 2:
				
				locals[1] = 1;
				goto label_1058;
				break;
			} // end if
			
		} 
		
		yield return StartCoroutine(say( locals, 130 ));
		locals[1] = 1;
		goto label_1058;
		
	label_1058:;
		func_0fef_result=locals[1];
		//return locals[1];
	} // end func
	
	
	
	
	IEnumerator func_1060() {
		
		int[] locals = new int[24];
		
		locals[2] = 131;
		locals[3] = 132;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,2));   locals[23] = PlayerAnswer;
		switch ( locals[23] ) {
			
		case 1:
			
			locals[1] = 0;//was 0
			goto label_10ae;
			
			break;
			
		case 2:
			
			locals[1] = 1;
			goto label_10ae;
			
			break;
			
		} // end switch
		
	label_10ae:;
		
		//return locals[1];
		func_1060_result = locals[1];
	} // end func
	
	
	
	
	
	IEnumerator func_10b6() {
		
		int[] locals = new int[24];
		
		yield return StartCoroutine(say( locals, 133 ));
		locals[1] = 134;
		locals[2] = 135;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			npc.npc_attitude = npc.npc_attitude + 1;
			//return;
			yield break;
			
			break;
			
		case 2:
			
			yield return StartCoroutine(say( locals, 136 ));
			locals[23] = 1;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			break;
			
		} // end switch
		
	} // end func
	
	/**** Moved labels *******/
	
	
	IEnumerator label_0a10(int[] locals)
	{
		yield return StartCoroutine(say( locals, 077 ));
		privateVariables[9] = 1;
		yield return StartCoroutine(func_1060());
		locals[1] = func_1060_result;
		locals[378] = locals[1];
		if ( 0 == locals[378] ) {
			//Should be going to leader of ghouls question.
			yield return StartCoroutine (label_0a86(locals));
		} else {
			
			//if ( 1 == locals[378] ) {
			
			//goto label_0a3d;
			yield return StartCoroutine (label_0a3d(locals));
			
			//} // end if
			
		} // end if
		
	}
	
	
	IEnumerator	label_09e3(int[] locals)
	{
		yield return StartCoroutine(say( locals, 076 ));
		privateVariables[10] = 1;
		yield return StartCoroutine(func_1060());
		locals[1] = func_1060_result;
		locals[377] = locals[1];
		if ( 0 == locals[377] ) {
			yield return StartCoroutine (label_0a86(locals));
		} else {
			
			//if ( 1 == locals[377] ) {
			
			//} else {
			//goto label_0a10;
			//yield return StartCoroutine(label_0a10(locals));
			//goto label_0a3d;
			yield return StartCoroutine (label_0a3d(locals));
			
			//} // end if
			
			
			
		} // end switch
	}
	
	
	IEnumerator label_0a86(int[]locals)
	{
		if ( privateVariables[6] == 0) {
			
			privateVariables[2] = 5;
			yield return StartCoroutine(say( locals, 081 ));
		} else {
			
			yield return StartCoroutine(say( locals, 082 ));
		} // end if
		
		privateVariables[6] = 1;
		locals[402] = 83;
		locals[403] = 84;
		locals[404] = 0;
		//locals[423] = babl_menu( 0, locals[402] );
		yield return StartCoroutine(babl_menu (0,locals,402));
		locals[423] = PlayerAnswer;
		switch ( locals[423] ) {
			
		case 1:
			
			//goto label_0adb;
			yield return StartCoroutine (label_0adb(locals));
			
			break;
			
		case 2:
			
			//goto label_0d72;
			yield return StartCoroutine(label_0d72(locals));
			
			break;
			
		} // end switch
		
		
	}
	
	
	IEnumerator label_0a3d(int[] locals)
	{
		yield return StartCoroutine(say( locals, 078 ));
		locals[379] = 79;
		locals[380] = 80;
		locals[381] = 0;
		//locals[400] = babl_menu( 0, locals[379] );
		yield return StartCoroutine(babl_menu (0,locals,379));
		locals[400] = PlayerAnswer;
		switch ( locals[400] ) {
			
		case 1:
			
			locals[401] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[401] );
			yield break;
			
		case 2:
			
			//goto label_0a86;
			yield return StartCoroutine (label_0a86(locals));
			break;
		} // end if
	}
	
	
	
	IEnumerator label_0adb(int[] locals)
	{
		locals[424] = 85;
		locals[425] = 86;
		locals[426] = 0;
		//locals[445] = babl_menu( 0, locals[424] );
		yield return StartCoroutine(babl_menu (0,locals,424));
		locals[445] = PlayerAnswer;
		switch ( locals[445] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			//goto label_0a86;
			yield return StartCoroutine (label_0a86 (locals));
			
			break;
			
		} // end switch
		
		yield return StartCoroutine(say( locals, 087 ));
		locals[467] = privateVariables[9];
		locals[446] = 88;
		locals[468] = privateVariables[10];
		locals[447] = 89;
		locals[469] = 1;
		locals[448] = 90;
		locals[449] = 0;
		//locals[488] = babl_fmenu( 0, locals[446], locals[467] );
		yield return StartCoroutine(babl_fmenu (0,locals,446,467));
		locals[488] = PlayerAnswer;
		switch ( locals[488] ) {
			
		case 88:
			
			//goto label_0c01;
			yield return StartCoroutine (label_0c01(locals));
			break;
			
		case 89:
			
			//goto label_0c5e;
			yield return StartCoroutine (label_0c5e(locals));
			break;
			
		case 90:
			
			yield return StartCoroutine(say( locals, 091 ));
			locals[489] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[489] );
			yield break;
			break;
			
		} // end switch
	}
	
	IEnumerator label_0d72(int[] locals)
	{
		locals[623] = 106;
		locals[624] = 107;
		locals[625] = 0;
		//locals[644] = babl_menu( 0, locals[623] );
		yield return StartCoroutine(babl_menu (0,locals,623));
		locals[644] = PlayerAnswer;
		switch ( locals[644] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			//goto label_0a86;
			yield return StartCoroutine (label_0a86 (locals));
			
			break;
			
		} // end switch
		
		yield return StartCoroutine(say( locals, 108 ));
		privateVariables[11] = 1;
		locals[666] = privateVariables[9];
		locals[645] = 109;
		locals[667] = privateVariables[10];
		locals[646] = 110;
		locals[668] = 1;
		locals[647] = 111;
		locals[669] = 1;
		locals[648] = 112;
		locals[649] = 0;
		//locals[687] = babl_fmenu( 0, locals[645], locals[666] );
		yield return StartCoroutine(babl_fmenu (0,locals,645,666));
		locals[687] = PlayerAnswer;
		switch ( locals[687] ) {
			
		case 109:
			
			//goto label_0c01;
			yield return StartCoroutine(label_0c01(locals));
			
			break;
			
		case 110:
			
			//goto label_0c5e;
			yield return StartCoroutine (label_0c5e(locals));
			break;
			
		case 111:
			
			//goto label_0e48;
			yield return StartCoroutine (label_0e48(locals));
			break;
			
		case 112:
			
			locals[688] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[688] );
			yield break;
			break;
		} // end if
		
		
	}
	
	IEnumerator label_0c01(int[] locals)
	{
		yield return StartCoroutine(say( locals, 095 ));
		locals[554] = privateVariables[11];
		locals[533] = 96;
		locals[555] = 1;
		locals[534] = 97;
		locals[535] = 0;
		//locals[575] = babl_fmenu( 0, locals[533], locals[554] );
		yield return StartCoroutine(babl_fmenu (0,locals,533,554));
		locals[575] = PlayerAnswer;
		switch ( locals[575] ) {
			
		case 96:
			
			//goto label_0e48;
			yield return StartCoroutine(label_0e48(locals));
			
			break;
			
		case 97:
			
			locals[576] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[576] );
			yield break;
			break;
			
		} // end switch
		
	}
	
	IEnumerator label_0c5e(int[] locals)
	{
		yield return StartCoroutine(say( locals, 098 ));
		locals[598] = privateVariables[11];
		locals[577] = 99;
		locals[599] = 1;
		locals[578] = 100;
		locals[579] = 0;
		//locals[619] = babl_fmenu( 0, locals[577], locals[598] );
		yield return StartCoroutine(babl_fmenu (0,locals,577,598));
		locals[619] = PlayerAnswer;
		switch ( locals[619] ) {
			
		case 99:
			
			//goto label_0e48;
			yield return StartCoroutine (label_0e48(locals));
			
			break;
			
		case 100:
			
			locals[620] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[620] );
			yield break;
			break;
		} // end if
	}
	
	
	IEnumerator label_0e48(int[] locals)
	{
		privateVariables[4] = 1;
		privateVariables[2] = 7;
		yield return StartCoroutine(say( locals, 113 ));
		locals[689] = 114;
		locals[690] = 115;
		locals[691] = 0;
		//locals[710] = babl_menu( 0, locals[689] );
		yield return StartCoroutine(babl_menu (0,locals,689));
		locals[710] = PlayerAnswer;
		switch ( locals[710] ) {
			
		case 1:
			
			//goto label_0e9e;
			yield return StartCoroutine (label_0e9e(locals));
			
			break;
			
		case 2:
			
			yield return StartCoroutine(say( locals, 116 ));
			locals[711] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[711] );
			yield break;
			break;
			
		} // end switch
	}
	
	
	IEnumerator label_0e9e(int[]locals)
	{
		privateVariables[2] = 8;
		yield return StartCoroutine(say( locals, 117 ));
		locals[712] = 118;
		locals[713] = 0;
		//locals[733] = babl_menu( 0, locals[712] );
		yield return StartCoroutine(babl_menu (0,locals,712));
		locals[733] = PlayerAnswer;
		if ( locals[733] == 1 ) {
			
			locals[734] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[734] );
			yield break;
		} // end if
		
		//} // end if
		
		
	}
	
	IEnumerator label_0514(int[] locals)
	{
		if ( privateVariables[2] < 4 ) {
			
			privateVariables[2] = 4;
			yield return StartCoroutine(say( locals, 025 ));
		} else {
			
			yield return StartCoroutine(say( locals, 026 ));
		} // end if
		
		privateVariables[8] = 1;
		locals[118] = 27;
		locals[119] = 28;
		locals[120] = 0;
		//locals[139] = babl_menu( 0, locals[118] );
		yield return StartCoroutine(babl_menu (0,locals,118));
		locals[139] = PlayerAnswer;
		switch ( locals[139] ) {
			
		case 1:
			
			//goto label_0a10;
			yield return StartCoroutine (label_0a10(locals));
			
			break;
			
		case 2:
			
			//goto label_05e2;
			yield return StartCoroutine(label_05e2 (locals));
			
			break;
			
		} // end switch
	}
	
	
	IEnumerator label_05e2(int[] locals)
	{
		yield return StartCoroutine(say( locals, 033 ));
		locals[164] = 34;
		locals[165] = 35;
		locals[166] = 0;
		//locals[185] = babl_menu( 0, locals[164] );
		yield return StartCoroutine(babl_menu (0,locals,164));
		locals[185] = PlayerAnswer;
		switch ( locals[185] ) {
			
		case 1:
			
			//goto label_09e3;
			yield return StartCoroutine(label_09e3 (locals));
			
			break;
			
		case 2:
			
			//goto label_0a10;
			yield return StartCoroutine(label_0a10 (locals));
			break;
			
		} // end switch
	}
	
	IEnumerator ResumeTopic(int[] locals)
	{
		locals[756] = privateVariables[6];
		locals[735] = 119;
		locals[757] = privateVariables[8];
		locals[736] = 120;
		locals[758] = privateVariables[4];
		locals[737] = 121;
		locals[759] = 1;
		locals[738] = 122;
		locals[739] = 0;
		//locals[777] = babl_fmenu( 0, locals[735], locals[756] );
		yield return StartCoroutine(babl_fmenu (0,locals,735,756));
		locals[777] = PlayerAnswer;
		switch ( locals[777] ) {
			
		case 119:
			
			//goto label_0a86;
			yield return StartCoroutine (label_0a86 (locals));
			
			break;
			
		case 120:
			
			//goto label_0514;
			yield return StartCoroutine (label_0514 (locals));
			break;
			
		case 121:
			
			//goto label_0e48;
			yield return StartCoroutine (label_0e48(locals));
			
			break;
			
		case 122:
			
			locals[778] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[778] );
			yield break;
			break;
			
		} // end switch
	}
	
}
