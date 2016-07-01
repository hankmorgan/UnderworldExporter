using UnityEngine;
using System.Collections;

public class Conversation_24 : Conversation {
	
	
	//conversation #24
	//	string block 0x0e18, name prisoner
	
	
	public override IEnumerator main() {
		SetupConversation (3608);
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
		
		if ( (((npc.npc_goal == 5 || npc.npc_goal == 6) || npc.npc_goal == 9) && npc.npc_gtarg == 1 || npc.npc_attitude == 0) ) {
			
			locals[1] = 0;
		} else {
			
			locals[1] = 1;
		} // end if
		
		return locals[1];
	} // end func*/
	
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
	
	/*void func_008b() {
		
		npc.npc_gtarg = 1;
		npc.npc_goal = 5;
		npc.npc_attitude = 1;
		func_0012();
	} // end func*/
	
	/*void func_00a4() {
		
		npc.npc_attitude = 6;
	} // end func*/
	
	void func_00b1(int param1) {
		
		npc.npc_attitude = param1;//[0];//play_hunger;
		func_0012();
	} // end func
	
	void func_00c2() {
		
		npc.npc_attitude = 2;
		func_0012();
	} // end func
	
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
		
		//int locals[27];
		int[] locals=new int[28];
		
		if ( privateVariables[0] == 0 ) {
			
			privateVariables[4] = 0;
		} // end if
		
		locals[1] = 0;
		if ( get_quest( 1, locals[1] ) == 1 ) {
			
			yield return StartCoroutine(func_0bcb());
		} else {
			
			locals[2] = 7;
			if ( get_quest( 1, locals[2] ) == 1 ) {
				
				locals[3] = 15;
				locals[4] = 0;
				set_attitude( 2, locals[4], locals[3] );
				yield return StartCoroutine(func_0bcb());
			} else {
				
				if ( privateVariables[4] == 1 ) {
					
					yield return StartCoroutine(func_0646());
				} else {
					
					locals[5] = 1;
					yield return StartCoroutine( print( 1, locals[5] ));
					locals[6] = 2;
					locals[7] = 3;
					locals[8] = 0;
					//locals[27] = babl_menu( 0, locals[6] );
					yield return StartCoroutine(babl_menu (0,locals,6));
					locals[27] = PlayerAnswer;
					
					switch ( locals[27] ) {
						
					case 1:
						
						yield return StartCoroutine(func_0350());
						break;
						
					case 2:
						
						yield return StartCoroutine( func_03a3());
						break;
					} // end if
					
				} // end if
				
			} // end if
			
			//break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0350() {
		
		//int locals[23];
		int[] locals=new int[24];
		
		locals[1] = 4;
		yield return StartCoroutine( print( 1, locals[1] ));
		locals[2] = 5;
		locals[3] = 6;
		locals[4] = 0;
		//locals[23] = babl_menu( 0, locals[2] );
		yield return StartCoroutine(babl_menu (0,locals,2));
		locals[23] = PlayerAnswer;
		switch ( locals[23] ) {
			
		case 1:
			
			yield return StartCoroutine(func_03a3());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_03f6());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03a3() {
		
		//int locals[23];
		int[] locals=new int[24];
		
		locals[1] = 7;
		yield return StartCoroutine( print( 1, locals[1] ));
		locals[2] = 8;
		locals[3] = 9;
		locals[4] = 0;
		//locals[23] = babl_menu( 0, locals[2] );
		yield return StartCoroutine(babl_menu (0,locals,2));
		locals[23] = PlayerAnswer;
		switch ( locals[23] ) {
			
		case 1:
			
			yield return StartCoroutine( func_03f6());
			break;
			
		case 2:
			
			yield return StartCoroutine( func_04a5());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03f6() {
		
		//int locals[23];
		int[] locals=new int[24];
		
		locals[1] = 10;
		yield return StartCoroutine( print( 1, locals[1] ));
		locals[2] = 11;
		locals[3] = 12;
		locals[4] = 0;
		//locals[23] = babl_menu( 0, locals[2] );
		yield return StartCoroutine(babl_menu (0,locals,2));
		locals[23] = PlayerAnswer;
		switch ( locals[23] ) {
			
		case 1:
			
			//privateVariables[3] = babl_ask( 0 );
			yield return StartCoroutine( babl_ask( 0 ));
			//cHANGE
			//PlayerTypedAnswer=locals, 022;
			yield return StartCoroutine( func_05d2());
			break;
			
		case 2:
			
			yield return StartCoroutine( func_0452());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0452() {
		
		//int locals[23];
		int[] locals=new int[24];
		
		locals[1] = 13;
		yield return StartCoroutine( print( 1, locals[1] ));
		locals[2] = 14;
		locals[3] = 15;
		locals[4] = 0;
		//locals[23] = babl_menu( 0, locals[2] );
		yield return StartCoroutine(babl_menu (0,locals,2));
		locals[23] = PlayerAnswer;
		switch ( locals[23] ) {
			
		case 1:
			
			yield return StartCoroutine( func_0769());
			break;
			
		case 2:
			
			yield return StartCoroutine( func_04a5());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_04a5() {
		
		//int locals[64];
		int[] locals=new int[65];
		int counter =0;
		//locals[16] = show_inv( 2, locals[6], locals[1] );
		locals[16] = show_inv (2,locals, 6, 1);
		locals[18] = 0;
		while ( locals[16] != 0 ) {
			
			//locals[17] = locals[0];
			locals[17] = locals[1+counter]; //Get the next item id in the list of found items
			if ( ((((((locals[17] == 176 || locals[17] == 177) || locals[17] == 178) || locals[17] == 179) || locals[17] == 180) || locals[17] == 181) || locals[17] == 182) ) {
				
				locals[18] = locals[18] + 1;
				locals[10+counter] = locals[6+counter];//Copy the item positions.
				//locals[10] = locals[5];
			} // end if
			
			locals[16] = locals[16] - 1;
			counter++;
		} // while
		
		if ( locals[18] > 0 ) {
			
			//give_to_npc( 2, locals[11], locals[18] );
			//give_to_npc(2,locals,11,locals[18]);
			give_to_npc(2,locals,10,locals[18]);
			locals[19] = 16;
			yield return StartCoroutine( print( 1, locals[19] ));
			locals[20] = 17;
			locals[21] = 18;
			locals[22] = 0;
			//locals[41] = babl_menu( 0, locals[20] );
			yield return StartCoroutine(babl_menu (0,locals,20));
			locals[41] = PlayerAnswer;
			switch ( locals[41] ) {
				
			case 1:
				
				yield return StartCoroutine( func_0769());
				break;
				
			case 2:
				
				yield return StartCoroutine( func_03f6());
				break;
			} // end if
			
		} else {
			
			//break;
			
		} // end switch
		
		locals[42] = 19;
		yield return StartCoroutine( print( 1, locals[42] ));
		locals[43] = 20;
		locals[44] = 21;
		locals[45] = 0;
		//locals[64] = babl_menu( 0, locals[43] );
		yield return StartCoroutine(babl_menu (0,locals,43));
		locals[64] = PlayerAnswer;
		switch ( locals[64] ) {
			
		case 1:
			
			yield return StartCoroutine( func_04a5());
			break;
			
		case 2:
			
			yield return StartCoroutine( func_0769());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_05d2() {
		
		//int locals[25];
		int[] locals=new int[26];
		
		locals[1] = 22;
		if ( compare( 2, locals[1], PlayerTypedAnswer ) == 1 ) {
			
			yield return StartCoroutine( func_065e());
		} else {
			
			locals[2] = 23;
			yield return StartCoroutine( print( 1, locals[2] ));
			locals[3] = 24;
			locals[4] = 25;
			locals[5] = 0;
			//locals[24] = babl_menu( 0, locals[3] );
			yield return StartCoroutine(babl_menu (0,locals,3));
			locals[24] = PlayerAnswer;
			switch ( locals[24] ) {
				
			case 1:
				
				yield return StartCoroutine( func_0769());
				break;
				
			case 2:
				
				locals[25] = 3;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[25] );//ENDCONVO
				yield break;
			} // end if
			
			//break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0646() {
		
		//int locals[1];
		int[] locals=new int[2];
		
		locals[1] = 26;
		yield return StartCoroutine( print( 1, locals[1] ));
		yield return StartCoroutine( func_080f());
	} // end func
	
	IEnumerator func_065e() {
		
		//int locals[48];
		int[] locals=new int[49];
		
		locals[2] = 27;
		yield return StartCoroutine( print( 1, locals[2] ));
		locals[3] = 2;
		locals[1] = get_quest( 1, locals[3] );
		
		if ( locals[1] == 1) {
			
			locals[4] = 28;
			yield return StartCoroutine( print( 1, locals[4] ));
		} else {
			
			locals[5] = 29;
			yield return StartCoroutine( print( 1, locals[5] ));
		} // end if
		
		locals[27] = locals[1];
		locals[6] = 30;
		locals[28] = 1;
		locals[7] = 31;
		locals[29] = 1;
		locals[8] = 32;
		locals[9] = 0;
		//locals[48] = babl_fmenu( 0, locals[6], locals[27] );
		yield return StartCoroutine(babl_fmenu (0,locals,6,27));
		locals[48] = PlayerAnswer;
		switch ( locals[48] ) {
			
		case 30:
			
			yield return StartCoroutine( func_0716());
			break;
			
		case 31:
			
			yield return StartCoroutine( func_0716());
			break;
			
		case 32:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00c2();//ENDCONVO
			yield break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0716() {
		
		//int locals[23];
		int[] locals=new int[24];
		
		locals[1] = 33;
		yield return StartCoroutine( print( 1, locals[1] ));
		locals[2] = 34;
		locals[3] = 35;
		locals[4] = 0;
		//locals[23] = babl_menu( 0, locals[2] );
		yield return StartCoroutine(babl_menu (0,locals,2));
		locals[23] = PlayerAnswer;
		switch ( locals[23] ) {
			
		case 1:
			
			yield return StartCoroutine( func_0769());
			break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00c2();//ENDCONVO
			yield break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0769() {
		
		//int locals[23];
		int[] locals=new int[24];
		
		locals[1] = 36;
		yield return StartCoroutine( print( 1, locals[1] ));
		locals[2] = 37;
		locals[3] = 38;
		locals[4] = 0;
		//locals[23] = babl_menu( 0, locals[2] );
		yield return StartCoroutine(babl_menu (0,locals,2));
		locals[23] = PlayerAnswer;
		switch ( locals[23] ) {
			
		case 1:
			
			yield return StartCoroutine( func_07bc());
			break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00c2();//ENDCONVO
			yield break;
		
		} // end switch
		
	} // end func
	
	IEnumerator func_07bc() {
		
		//int locals[23];
		int[] locals=new int[24];
		
		locals[1] = 39;
		yield return StartCoroutine( print( 1, locals[1] ));
		locals[2] = 40;
		locals[3] = 41;
		locals[4] = 0;
		//locals[23] = babl_menu( 0, locals[2] );
		yield return StartCoroutine(babl_menu (0,locals,2));
		locals[23] = PlayerAnswer;
		switch ( locals[23] ) {
			
		case 1:
			
			yield return StartCoroutine( func_080f());
			break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00c2();//ENDCONVO
			yield break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_080f() {
		
		//int locals[25];
		int[] locals=new int[26];
		
		privateVariables[4] = 1;
		locals[1] = 42;
		yield return StartCoroutine( print( 1, locals[1] ));
		while ( true ) {
			
			locals[2] = 43;
			locals[3] = 44;
			locals[4] = 46;
			locals[5] = 48;
			locals[6] = 0;
			//locals[23] = babl_menu( 0, locals[2] );
			yield return StartCoroutine(babl_menu (0,locals,2));
			locals[23] = PlayerAnswer;
			switch ( locals[23] ) {
				
			case 1:
				
				locals[24] = 3;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[24] );//ENDCONVO
				yield break;
				
			case 2:
				
				privateVariables[2] = 45;
				PlayerTypedAnswer= GetString (privateVariables[2]);
				yield return StartCoroutine( func_08bf());
				break;
				
			case 3:
				
				privateVariables[2] = 47;
				PlayerTypedAnswer= GetString (privateVariables[2]);
				yield return StartCoroutine( func_08bf());
				break;
				
			case 4:
				
				//privateVariables[2] = babl_ask( 0 );
				yield return StartCoroutine( babl_ask( 0 ));
				yield return StartCoroutine( func_08bf());
				break;
				
			} // end switch
			
			locals[25] = 49;
			yield return StartCoroutine( print( 1, locals[25] ));
		} // while
		
	} // end func
	
	IEnumerator func_08bf() {
		//This should be checking agains playeranswer
		//int locals[43];
		int[] locals=new int[44];
		
		locals[1] = 50;
		if ( compare( 2, locals[1], PlayerTypedAnswer ) == 1 ) {
			
			locals[2] = 51;
			yield return StartCoroutine( print( 1, locals[2] ));
		} else {
			
			locals[3] = 52;
			if ( compare( 2, locals[3], PlayerTypedAnswer )  == 1) {
				
				locals[4] = 53;
				yield return StartCoroutine( print( 1, locals[4] ));
			} else {
				
				locals[5] = 54;
				if ( compare( 2, locals[5], PlayerTypedAnswer ) == 1 ) {
					
					locals[6] = 55;
					yield return StartCoroutine( print( 1, locals[6] ));
				} else {
					
					locals[7] = 56;
					if ( compare( 2, locals[7], PlayerTypedAnswer ) == 1 ) {
						
						locals[8] = 57;
						yield return StartCoroutine( print( 1, locals[8] ));
					} else {
						
						locals[9] = 58;
						if ( compare( 2, locals[9], PlayerTypedAnswer ) == 1 ) {
							
							locals[10] = 59;
							yield return StartCoroutine( print( 1, locals[10] ));
						} else {
							
							locals[11] = 60;
							if ( compare( 2, locals[11], PlayerTypedAnswer )  == 1) {
								
								locals[12] = 61;
								yield return StartCoroutine( print( 1, locals[12] ));
							} else {
								
								locals[13] = 62;
								if ( compare( 2, locals[13], PlayerTypedAnswer ) == 1 ) {
									
									locals[14] = 63;
									yield return StartCoroutine( print( 1, locals[14] ));
								} else {
									
									locals[15] = 64;
									if ( compare( 2, locals[15], PlayerTypedAnswer ) == 1 ) {
										
										locals[16] = 65;
										yield return StartCoroutine( print( 1, locals[16] ));
									} else {
										
										locals[17] = 66;
										if ( compare( 2, locals[17], PlayerTypedAnswer ) == 1 ) {
											
											locals[18] = 67;
											yield return StartCoroutine( print( 1, locals[18] ));
										} else {
											
											locals[19] = 68;
											if ( compare( 2, locals[19], PlayerTypedAnswer ) == 1 ) {
												
												locals[20] = 69;
												yield return StartCoroutine( print( 1, locals[20] ));
											} else {
												
												locals[21] = 70;
												if ( compare( 2, locals[21], PlayerTypedAnswer ) == 1 ) {
													
													locals[22] = 71;
													yield return StartCoroutine( print( 1, locals[22] ));
												} else {
													
													locals[23] = 72;
													if ( compare( 2, locals[23], PlayerTypedAnswer ) == 1 ) {
														
														locals[24] = 73;
														yield return StartCoroutine( print( 1, locals[24] ));
													} else {
														
														locals[25] = 74;
														if ( compare( 2, locals[25], PlayerTypedAnswer ) == 1 ) {
															
															locals[26] = 75;
															yield return StartCoroutine( print( 1, locals[26] ));
														} else {
															
															locals[27] = 76;
															if ( compare( 2, locals[27], PlayerTypedAnswer ) == 1 ) {
																
																locals[28] = 77;
																yield return StartCoroutine( print( 1, locals[28] ));
															} else {
																
																locals[29] = 78;
																if ( compare( 2, locals[29], PlayerTypedAnswer ) == 1 ) {
																	
																	locals[30] = 79;
																	yield return StartCoroutine( print( 1, locals[30] ));
																} else {
																	
																	locals[31] = 80;
																	if ( compare( 2, locals[31], PlayerTypedAnswer ) == 1 ) {
																		
																		locals[32] = 81;
																		yield return StartCoroutine( print( 1, locals[32] ));
																	} else {
																		
																		locals[33] = 82;
																		if ( compare( 2, locals[33], PlayerTypedAnswer ) == 1 ) {
																			
																			locals[34] = 83;
																			yield return StartCoroutine( print( 1, locals[34] ));
																		} else {
																			
																			locals[35] = 84;
																			if ( compare( 2, locals[35], PlayerTypedAnswer ) == 1 ) {
																				
																				locals[36] = 85;
																				yield return StartCoroutine( print( 1, locals[36] ));
																			} else {
																				
																				locals[37] = 86;
																				if ( compare( 2, locals[37], PlayerTypedAnswer ) == 1 ) {
																					
																					locals[38] = 87;
																					yield return StartCoroutine( print( 1, locals[38] ));
																				} else {
																					
																					locals[39] = 88;
																					if ( compare( 2, locals[39], PlayerTypedAnswer ) == 1 ) {
																						
																						locals[40] = 89;
																						yield return StartCoroutine( print( 1, locals[40] ));
																					} else {
																						
																						locals[41] = 90;
																						if ( compare( 2, locals[41], PlayerTypedAnswer ) == 1 ) {
																							
																							locals[42] = 91;
																							yield return StartCoroutine( print( 1, locals[42] ));
																						} else {
																							
																							locals[43] = 92;
																							yield return StartCoroutine( print( 1, locals[43] ));
																						} // end if
																						
																					} // end if
																					
																				} // end if
																				
																			} // end if
																			
																		} // end if
																		
																	} // end if
																	
																} // end if
																
															} // end if
															
														} // end if
														
													} // end if
													
												} // end if
												
											} // end if
											
										} // end if
										
									} // end if
									
								} // end if
								
							} // end if
							
						} // end if
						
					} // end if
					
				} // end if
				
			} // end if
			
		} // end if
		
	} // end func
	
	IEnumerator func_0bcb() {
		
		//int locals[50];
		int[] locals=new int[51];
		locals[2] = 2;
		locals[1] = get_quest( 1, locals[2] );
		
		locals[3] = 93;
		yield return StartCoroutine( print( 1, locals[3] ));
		locals[25] = locals[1];
		locals[4] = 94;
		locals[26] = 1;
		locals[5] = 95;
		locals[27] = 1;
		locals[6] = 96;
		locals[7] = 0;
		//locals[46] = babl_fmenu( 0, locals[4], locals[25] );
		yield return StartCoroutine(babl_fmenu (0,locals,4,25));
		locals[46] = PlayerAnswer;
		switch ( locals[46] ) {
			
		case 94:
			
			break;
			
		case 95:
			
			break;
			
		case 96:
			
			break;
			
		} // end switch
		
		remove_talker( 0 );
		locals[47] = 97;
		yield return StartCoroutine( print( 1, locals[47] ));
		locals[48] = 0;
		locals[49] = 1;
		set_quest( 2, locals[49], locals[48] );
		locals[50] = 3;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[50] );//ENDCONVO
		yield break;
	} // end func
	
	
	
	
}
