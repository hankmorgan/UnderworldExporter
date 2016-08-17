using UnityEngine;
using System.Collections;

public class Conversation_UW2_2 :Conversation_UW2 {
		//UW2 Conversation #2
		//Block 0x0e01 goblin

		public override IEnumerator main() {
				SetupConversation (3585);
				privateVariables[1] = 0;
				yield return StartCoroutine(func_074a());
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

				locals[2] = 4;
				locals[1] = babl_hack( 1, locals[2] );
				goto label_003a;

				label_003a:;

				return locals[1];
		} // end func

		void func_0042() {

				int[] locals = new int[1];

				locals[1] = 0;
				babl_hack( 1, locals[1] );
		} // end func

		void func_0058() {

				int[] locals = new int[2];

				locals[2] = 1;
				locals[1] = babl_hack( 1, locals[2] );
				goto label_0072;

				label_0072:;

				return locals[1];
		} // end func

		void func_007a() {

				int[] locals = new int[1];

				if ( (((npc.npc_goal == 5 || npc.npc_goal == 6) || npc.npc_goal == 9) && npc.npc_gtarg == 1 || npc.npc_attitude == 0) ) {

						locals[1] = 0;
				} else {

						locals[1] = 1;
				} // end if

				return locals[1];
		} // end func

		void func_00bd() {

				int[] locals = new int[2];

				locals[1] = 1;
				locals[2] = 2;
				x_obj_pos( 5, param1, param2, param3, locals[2], locals[1] );
		} // end func

		void func_00e8() {

				npc.npc_gtarg = 1;
				npc.npc_attitude = 1;
				npc.npc_goal = 6;
				func_0012();
		} // end func

		void func_0101() {

				npc.npc_goal = 1;
				func_0012();
		} // end func
*/
		void func_0110() {

				npc.npc_gtarg = 1;
				npc.npc_goal = 5;
				npc.npc_attitude = 1;
				func_0012();
		} // end func
		/*
		void func_0129() {

				npc.npc_attitude = 6;
		} // end func
*/
		void func_0136(int param1) {

				npc.npc_attitude = param1;
				func_0012();
		} // end func

		void func_0147() {

				npc.npc_attitude = 2;
				func_0012();
		} // end func

		void func_0156() {

				npc.npc_attitude = 1;
				func_0012();
		} // end func

		void func_0165() {
				
				func_0012();
		} // end func
		/*
		void func_016f() {

				param1[1] = game_days;
				param1[2] = game_mins;
		} // end func

		void func_018b() {

				int[] locals = new int[4];

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

		void func_0214() {

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

		void func_02c8() {

				param1[1] = game_days - param2[1];
				param1[2] = game_mins - param2[2];
				if ( param1[2] < 0 ) {

						param1[2] = param1[2] + 1440;
						param1[1] = param1[1] - 1;
				} // end if

		} // end func

		void func_0322() {

				int[] locals = new int[4];

				locals[1] = 15;
				locals[2] = 15;
				locals[3] = 10001;
				locals[4] = x_clock( 2, locals[3], locals[2] ) + 1;
				x_clock( 2, locals[4], locals[1] );
		} // end func
*/
		IEnumerator func_035a() {

				int[] locals = new int[6];

				locals[1] = 1;
				yield return StartCoroutine(print( 1, locals[1] ));
				yield return StartCoroutine(say( locals, "Help us! Oh, by the Titan, human, thou must help us! That thing is loose in the tower, it is killing us!" ));
				locals[2] = 15;
				locals[3] = 15;
				locals[4] = 10001;
				locals[5] = x_clock( 2, locals[4], locals[3] ) + 1;
				x_clock( 2, locals[5], locals[2] );
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_0156();
				yield break;
		} // end func

		IEnumerator func_03a5() {

				int[] locals = new int[23];

				yield return StartCoroutine(say( locals, "Yes?" ));
				locals[1] = 4;
				locals[2] = 5;
				locals[3] = 0;
				//locals[22] = babl_menu( 0, locals[1] );
				yield return StartCoroutine(babl_menu (0,locals,1));
				locals[22] = PlayerAnswer;
				switch ( locals[22] ) {

				case 1:

						yield return StartCoroutine(func_03ed());
						break;

				case 2:

						yield return StartCoroutine(func_0469());
						break;

				} // end switch

		} // end func

		IEnumerator func_03ed() {

				int[] locals = new int[23];

				yield return StartCoroutine(say( locals, "What duty hast thou here? The tower is empty now!" ));
				locals[1] = 7;
				locals[2] = 8;
				locals[3] = 0;
				//locals[22] = babl_menu( 0, locals[1] );
				yield return StartCoroutine(babl_menu (0,locals,1));
				locals[22] = PlayerAnswer;
				switch ( locals[22] ) {

				case 1:

						yield return StartCoroutine(func_0435());
						break;

				case 2:
						Time.timeScale =SlomoTime;
						yield return new WaitForSeconds(WaitTime);
						func_0110();
						yield break;

				} // end switch

		} // end func

		IEnumerator func_0435() {

				int[] locals = new int[23];

				yield return StartCoroutine(say( locals, "Go where thou wilt! Since Bishop took his own life, there is nothing to guard, and no reason to stop thee." ));
				locals[1] = 10;
				locals[2] = 0;
				//locals[22] = babl_menu( 0, locals[1] );
				yield return StartCoroutine(babl_menu (0,locals,1));
				locals[22] = PlayerAnswer;
				if ( locals[22] == 1 ) {
						Time.timeScale =SlomoTime;
						yield return new WaitForSeconds(WaitTime);
						func_0147();
						yield break;
				} // end if

		} // end func

		IEnumerator func_0469() {

				int[] locals = new int[23];

				yield return StartCoroutine(say( locals, "Surely. Be on thy way." ));
				locals[1] = 12;
				locals[2] = 13;
				locals[3] = 0;
				//locals[22] = babl_menu( 0, locals[1] );
				yield return StartCoroutine(babl_menu (0,locals,1));
				locals[22] = PlayerAnswer;
				switch ( locals[22] ) {

				case 1:

						Time.timeScale =SlomoTime;
						yield return new WaitForSeconds(WaitTime);
						func_0147();
						yield break;
						//break;

				case 2:

						yield return StartCoroutine(func_0435());
						break;

				} // end switch

		} // end func

		IEnumerator func_04b1() {

				int[] locals = new int[23];

				yield return StartCoroutine(say( locals, "Listen, I don't want any trouble here, but thou had best mind thy manners." ));
				locals[1] = 15;
				locals[2] = 16;
				locals[3] = 17;
				locals[4] = 0;
				//locals[22] = babl_menu( 0, locals[1] );
				yield return StartCoroutine(babl_menu (0,locals,1));
				locals[22] = PlayerAnswer;
				switch ( locals[22] ) {

				case 1:

						yield return StartCoroutine(func_050d());
						break;

				case 2:

						yield return StartCoroutine(func_051a());
						break;

				case 3:

						yield return StartCoroutine(func_056e());
						break;

				} // end switch

		} // end func

		IEnumerator func_050d() {

				yield return StartCoroutine(say( "No offense taken." ));
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_0147();
				yield break;
		} // end func

		IEnumerator func_051a() {

				int[] locals = new int[7];

				yield return StartCoroutine(say( locals, "So be it, fool!" ));
				locals[1] = 60;
				locals[2] = 1;
				set_quest( 2, locals[2], locals[1] );
				locals[3] = 15;
				locals[4] = 15;
				locals[5] = 10001;
				locals[6] = x_clock( 2, locals[5], locals[4] ) + 1;
				x_clock( 2, locals[6], locals[3] );
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_0110();
				yield break;
		} // end func

		IEnumerator func_056e() {

				int[] locals = new int[2];

				locals[1] = 20;
				yield return StartCoroutine(print( 1, locals[1] ));
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_0156();
				yield break;
		} // end func

		IEnumerator func_0586() {

				yield return StartCoroutine(say( "You had better talk to the captain about that." ));
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_0165();
				yield break;
		} // end func

		int func_0593(int param1) {

				int[] locals = new int[8];

				locals[2] = 1;
				locals[4] = 0;
				if ( param1 > 1000 ) {

						play_hunger = param1 - 1000;
						locals[4] = 1;
				} // end if

		//} // end if

		if ( param1 != 1 ) {

				locals[2] = locals[2] * 2;
				play_hunger = param1 - 1;
		} else {

				locals[3] = get_quest( 1, locals[5] );
				locals[5] = 131;
				if ( locals[4] == 1) {

						if ( locals[3] / locals[2] % 2 == 1 ) {

								locals[1] = 1;
						} else {

								locals[1] = 0;
						} 
					}//added
							else {

								if ( locals[3] / locals[2] % 2 != 1 ) {

										locals[6] = 131;
										locals[7] = locals[3] + locals[2];
										set_quest( 2, locals[7], locals[6] );
										locals[1] = 1;
								} // end if

						} // end if

				} // end if
			
				return locals[1];
		} // end func

		int func_064d() {

				int[] locals = new int[7];

				locals[2] = get_quest( 1, locals[3] );
				locals[3] = 134;
				if ( locals[2] == 0 ) {

						locals[2] = 1 + random( 1, locals[4] ) + game_mins % 9;
						locals[4] = 900;
						locals[5] = 134;
						set_quest( 2, locals[2], locals[5] );
				} // end if

				locals[6] = locals[2];
				if ( 1 == locals[6] ) {

						locals[1] = 22;
				} else {

						if ( 2 == locals[6] ) {

								locals[1] = 23;
						} else {

								if ( 3 == locals[6] ) {

										locals[1] = 24;
								} else {

										if ( 4 == locals[6] ) {

												locals[1] = 25;
										} else {

												if ( 5 == locals[6] ) {

														locals[1] = 26;
												} else {

														if ( 6 == locals[6] ) {

																locals[1] = 27;
														} else {

																if ( 7 == locals[6] ) {

																		locals[1] = 28;
																} else {

																		if ( 8 == locals[6] ) {

																				locals[1] = 29;
																		} else {

																				if ( 9 == locals[6] ) {

																						locals[1] = 30;
																						goto label_0742;

																				} // end if

																		} // end if

																} // end if

														} // end if

												} // end if

										} // end if

								} // end if

						} // end if

				} // end if

				label_0742:;

				return locals[1];
		} // end func

		IEnumerator func_074a() {

				int[] locals = new int[122];

				privateVariables[6] = 0;
				privateVariables[3] = sex( 2, locals[2], locals[1] );
				locals[1] = 31;
				locals[2] = 32;
				privateVariables[4] = sex( 2, locals[4], locals[3] );
				locals[3] = 33;
				locals[4] = 34;
				locals[5] = 0;
				if ( get_quest( 1, locals[5] ) == 1 ) {

						yield return StartCoroutine(func_035a());
				} // end if

				locals[6] = 35;
				yield return StartCoroutine(print( 1, locals[6] ));
				locals[7] = 1;
				if ( get_quest( 1, locals[7] ) == 0 ) {

						locals[8] = 3;
						if ( get_quest( 1, locals[8] ) == 1 ) {

								yield return StartCoroutine(func_03a5());
						} // end if

				} // end if

				if ( privateVariables[0] == 0 ) {

						privateVariables[2] = 0;
						privateVariables[5] = 1;
						if ( play_drawn == 1 ) {

								npc.npc_attitude = 1;
								npc.npc_goal = 8;
								yield return StartCoroutine(say( locals, "Halt, intruder! Thou comest here with weapon drawn -- seekest thou to die?!" ));
								locals[9] = 37;
								locals[10] = 38;
								locals[11] = 0;
								//locals[30] = babl_menu( 0, locals[9] );
								yield return StartCoroutine(babl_menu (0,locals,9));
								locals[30] = PlayerAnswer;
								switch ( locals[30] ) {

								case 1:

										func_1031();
										break;

								case 2:
										break;
								} // end if

								//break;

						} // end switch

						yield return StartCoroutine(say( locals, "Halt, stranger! I hope thou knowest the password, for we know the rebels are all through these hills." ));
						locals[31] = 40;
						locals[32] = 41;
						locals[33] = 0;
						//locals[52] = babl_menu( 0, locals[31] );
						yield return StartCoroutine(babl_menu (0,locals,31));
						locals[52] = PlayerAnswer;
						switch ( locals[52] ) {

						case 1:

								yield return StartCoroutine(func_1093());
								break;

						case 2:

								yield return StartCoroutine(func_10ac());
								break;

						} // end switch

						locals[53] = 42;
						locals[54] = 43;
						locals[55] = 44;
						locals[56] = 0;
						//locals[74] = babl_menu( 0, locals[53] );
						yield return StartCoroutine(babl_menu (0,locals,53));
						locals[74] = PlayerAnswer;
						switch ( locals[74] ) {

						case 1:

								yield return StartCoroutine(func_09b7());
								break;

						case 2:

								yield return StartCoroutine(func_0a24(1));
								break;

						case 3:

								yield return StartCoroutine(func_1031());
								break;
						} // end if

				}// else {

						//break;

				//} // end switch

				if ( privateVariables[2] == 1 ) {

						yield return StartCoroutine(say( locals, "Why dost thou linger here? Be on thy way." ));
						locals[75] = 46;
						locals[76] = 47;
						locals[77] = 48;
						locals[78] = 0;
						//locals[96] = babl_menu( 0, locals[75] );
						yield return StartCoroutine(babl_menu (0,locals,75));
						locals[96] = PlayerAnswer;
						switch ( locals[96] ) {

						case 1:

								break;

						case 2:

								Time.timeScale =SlomoTime;
								yield return new WaitForSeconds(WaitTime);
								func_0165();
								yield break;
								//break;

						case 3:

								yield return StartCoroutine(func_10c4());
								break;

						} // end switch

						yield return StartCoroutine(say( locals, "Very well." ));
						locals[97] = 30;
						locals[98] = 34;
						locals[99] = 0;
						gronk_door( 3, locals[99], locals[98], locals[97] );
				} else {

						yield return StartCoroutine(say( locals, "Why dost thou remain here, intruder?" ));
						locals[100] = 51;
						locals[101] = 52;
						locals[102] = 53;
						locals[103] = 54;
						locals[104] = 0;
						//locals[121] = babl_menu( 0, locals[100] );
						yield return StartCoroutine(babl_menu (0,locals,100));
						locals[121] = PlayerAnswer;
						switch ( locals[121] ) {

						case 1:

								yield return StartCoroutine(func_0d74());
								break;

						case 2:

								yield return StartCoroutine(func_09b7());
								break;

						case 3:

								yield return StartCoroutine(func_0ab1());
								break;

						case 4:

								yield return StartCoroutine(func_0a24(0));
								break;
						} // end if



				} // end switch

		} // end func

		IEnumerator func_09b7() {

				int[] locals = new int[25];

				yield return StartCoroutine(say( locals, "Tell us then, what is it?" ));
				locals[2] = 56;
				locals[3] = 57;
				locals[4] = 0;
				//locals[23] = babl_menu( 0, locals[2] );
				yield return StartCoroutine(babl_menu (0,locals,2));
				locals[23] = PlayerAnswer;
				switch ( locals[23] ) {

				case 1:

						break;

				case 2:

						yield return StartCoroutine(func_10b7());
						break;

				} // end switch

				//locals[1] = babl_ask( 0 );
				yield return  StartCoroutine(babl_ask(0));
				yield return StartCoroutine(say( locals, "\\1@SS1\\0" ));
				locals[24] = func_064d();
				if ( contains( 2, PlayerTypedAnswer, locals[24] ) ==1 ) {

						yield return StartCoroutine(func_0cf1());
				} else {

						yield return StartCoroutine(func_0a24(1));
				} // end if

		} // end func

		IEnumerator func_0a24(int param1) {
				//Param1 is whether or not the player tried the password or nto
				int[] locals = new int[46];

				if ( param1 == 1 ) {

						yield return StartCoroutine(say( locals, "So thou hast entered the prison tower without knowing the password? Thou art a fool!" ));
						locals[2] = 1;
						func_0593( locals[2] );
				} else {

						yield return StartCoroutine(say( locals, "Well, then, why should I not kill thee for trespassing?" ));
				} // end if

				locals[24] = 1;
				locals[3] = 61;
				locals[25] = privateVariables[5];
				locals[4] = 62;
				locals[26] = 1;
				locals[5] = 63;
				locals[6] = 0;
				//locals[45] = babl_fmenu( 0, locals[3], locals[24] );
				yield return StartCoroutine (babl_fmenu(0,locals,3,24));
				locals[45]=PlayerAnswer;
				switch ( locals[45] ) {

				case 61:

						yield return StartCoroutine(func_0dc8());
						break;

				case 62:

						yield return StartCoroutine(func_0ab1());
						break;

				case 63:

						yield return StartCoroutine(func_0c52());
						break;

				} // end switch

		} // end func

		IEnumerator func_0ab1() {

				//int[] locals = new int[2];

				yield return StartCoroutine(say( "Where is thy delivery voucher?" ));
				yield return StartCoroutine(func_0abe());
		} // end func

		IEnumerator func_0abe() {

				int[] locals = new int[23];

				locals[1] = 65;
				locals[2] = 66;
				locals[3] = 0;
				//locals[22] = babl_menu( 0, locals[1] );
				yield return StartCoroutine(babl_menu (0,locals,1));
				locals[22] = PlayerAnswer;
				switch ( locals[22] ) {

				case 1:

						yield return StartCoroutine(func_0b08());
						break;

				case 2:

						break;

				} // end switch

				privateVariables[5] = 0;
				Debug.Log("check this one");
				yield return StartCoroutine(func_0a24(0));
		} // end func

		IEnumerator func_0b08() {

				int[] locals = new int[47];

				locals[10] = 310;
				locals[11] = -1;
				Debug.Log("I'm too tired to fix this code");
				//find_barter_total( 4, locals[2], locals[3], locals[11], locals[10] );

				switch ( locals[2] ) {

				case 0:

						yield return StartCoroutine(say( locals, "Do not try any jokes with me, humie -- come back when thou hast found it." ));
						locals[12] = 68;
						locals[13] = 69;
						locals[14] = 0;
						//locals[33] = babl_menu( 0, locals[12] );
						yield return StartCoroutine(babl_menu (0,locals,12));
						locals[33] = PlayerAnswer;
						switch ( locals[33] ) {

						case 1:

								Time.timeScale =SlomoTime;
								yield return new WaitForSeconds(WaitTime);
								func_0156();
								yield break;
								//break;

						case 2:

								yield return StartCoroutine(func_0b08());
								break;

						} // end switch

						break;

				} // end switch

				switch ( locals[2] ) {

				case 1:

						locals[34] = 0;
						locals[35] = -1;
						locals[36] = -1;
						locals[37] = -1;
						locals[38] = -1;
						locals[39] = -1;
						locals[40] = -1;
						//x_obj_stuff( 9, locals[40], locals[39], locals[38], locals[1], locals[37], locals[36], locals[35], locals[34], locals[3] );
						x_obj_stuff(9,locals,40,39,38,1,37,36,35,34,3);
						if ( locals[1] == 33 + 512 ) {

								yield return StartCoroutine(say( locals, "'Tis a poor likeness, but I find no fault in it." ));
								yield return StartCoroutine(func_0cf1());
						} else {

								yield return StartCoroutine(say( locals, "This? This is no voucher!" ));
								yield return StartCoroutine(func_0a24(0));


						} // end if
						break;
				case 2: // was 1

						if ( privateVariables[6] == 3 ) {

								yield return StartCoroutine(say( locals, "This will put a stop to thy hijinks!" ));
								locals[41] = 60;
								locals[42] = 1;
								set_quest( 2, locals[42], locals[41] );
								locals[43] = 15;
								locals[44] = 15;
								locals[45] = 10001;
								locals[46] = x_clock( 2, locals[45], locals[44] ) + 1;
								x_clock( 2, locals[46], locals[43] );
								Time.timeScale =SlomoTime;
								yield return new WaitForSeconds(WaitTime);
								func_0110();
								yield break;
						} // end if

						yield return StartCoroutine(say( locals, "Well? Which one is it?" ));
						privateVariables[6] = privateVariables[6] + 1;
						yield return StartCoroutine(func_0abe());
						break;

				} // end switch

		} // end func

		IEnumerator func_0c52() {

				int[] locals = new int[30];

				yield return StartCoroutine(say( locals, "Hee hee hee! No, thou shalt not pass." ));
				locals[1] = 75;
				locals[2] = 76;
				locals[3] = 0;
				//locals[22] = babl_menu( 0, locals[1] );
				yield return StartCoroutine(babl_menu (0,locals,1));
				locals[22] = PlayerAnswer;
				switch ( locals[22] ) {

				case 1:

						break;

				case 2:

						goto label_0ca2;

						//break;

				} // end switch

				locals[23] = 10;
				yield return StartCoroutine(func_0e1c( locals[23] ));
				yield return StartCoroutine(func_0cf1());
		label_0ca2:;

				yield return StartCoroutine(say( locals, "We shall see who is in peril! Kill @GS34, comrades!" ));
				locals[24] = 60;
				locals[25] = 1;
				set_quest( 2, locals[25], locals[24] );
				locals[26] = 15;
				locals[27] = 15;
				locals[28] = 10001;
				locals[29] = x_clock( 2, locals[28], locals[27] ) + 1;
				x_clock( 2, locals[29], locals[26] );
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_0110();
				yield break;
		} // end func

		IEnumerator func_0cf1() {

				int[] locals = new int[29];

				locals[1] = 45;
				x_exp( 1, locals[1] );
				yield return StartCoroutine(say( locals, "You may pass, then, stranger.\\p" ));
				locals[2] = 30;
				locals[3] = 34;
				locals[4] = 0;
				gronk_door( 3, locals[4], locals[3], locals[2] );
				locals[5] = 40;
				locals[6] = 1;
				x_traps( 2, locals[6], locals[5] );
				privateVariables[2] = 1;
				npc.npc_goal = 7;
				locals[7] = 79;
				locals[8] = 0;
				//locals[28] = babl_menu( 0, locals[7] );
				yield return StartCoroutine(babl_menu (0,locals,7));
				locals[28] = PlayerAnswer;
				if ( locals[28] == 1 ) {

						Time.timeScale =SlomoTime;
						yield return new WaitForSeconds(WaitTime);
						func_0165();
						yield break;
				} // end if

		} // end func

		IEnumerator func_0d74() {

				int[] locals = new int[7];

				yield return StartCoroutine(say( locals, "Thou dost play with us?  Thou shalt die!" ));
				locals[1] = 60;
				locals[2] = 1;
				set_quest( 2, locals[2], locals[1] );
				locals[3] = 15;
				locals[4] = 15;
				locals[5] = 10001;
				locals[6] = x_clock( 2, locals[5], locals[4] ) + 1;
				x_clock( 2, locals[6], locals[3] );
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_0110();
				yield break;
		} // end func

		IEnumerator func_0dc8() {

				int[] locals = new int[7];

				yield return StartCoroutine(say( locals, "Avatar? Whate'er thou art, thou art an arrogant fool. Dispose of @GS34!" ));
				locals[1] = 60;
				locals[2] = 1;
				set_quest( 2, locals[2], locals[1] );
				locals[3] = 15;
				locals[4] = 15;
				locals[5] = 10001;
				locals[6] = x_clock( 2, locals[5], locals[4] ) + 1;
				x_clock( 2, locals[6], locals[3] );
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_0110();
				yield break;
		} // end func

		IEnumerator func_0e1c(int param1) {

				int[] locals = new int[101];

				locals[18] = 0;
				locals[16] = 0;
				locals[20] = 3 * param1 - x_skills( 2, locals[30], locals[29] ) / 2;
				locals[29] = 15;
				locals[30] = 9999;

			label_0e51:;

				//locals[15] = show_inv( 2, locals[8], locals[1] );
				locals[15] = show_inv(2,locals,8,1);
				if ( locals[15] > 0 ) {

						locals[17] = 1;
						locals[19] = 0;
						while ( locals[17] <= locals[15] ) {

								if ( (locals[0] == 160 || locals[0] == 160) ) {

										locals[16] = locals[16] + identify_inv( 4,locals, 32, 28, 31, locals[7] );
										locals[31] = 0;
										locals[32] = 0;
										locals[19] = locals[19] + 1;
										locals[20] = locals[7];
								} // end if

								locals[17] = locals[17] + 1;
						} // while

						if ( locals[16] >= locals[20] ) {

								//give_to_npc( 2, locals[21], locals[19] );
								give_to_npc(2,locals,21,19);
								yield return StartCoroutine(say( locals, "All right, this is enough. It ain't right, but on a guard's pay I ain't got no choice. If anyone finds out about this, thou shalt die like a dog. Is that clear?" ));
								locals[33] = 83;
								locals[34] = 84;
								locals[35] = 0;
								//locals[54] = babl_menu( 0, locals[33] );
								yield return StartCoroutine(babl_menu (0,locals,33));
								locals[54] = PlayerAnswer;
								switch ( locals[54] ) {

								case 1:

										locals[55] = 1;
										set_attitude( 1, locals[55] );
										break;

								case 2:

										locals[56] = 2;
										set_attitude( 1, locals[56] );
										break;

								} // end switch

						} else {

								if ( locals[19] == 0 ) {

										yield return StartCoroutine(say( locals, "Look, I just need gold -- can't take these other goods!" ));
								} else {

										yield return StartCoroutine(say( locals, "Thou must pay me more -- I shall be killed if this is discovered." ));
								} // end if

								locals[57] = 87;
								locals[58] = 88;
								locals[59] = 89;
								locals[60] = 0;
								//locals[78] = babl_menu( 0, locals[57] );
								yield return StartCoroutine(babl_menu (0,locals,57));
								locals[78] = PlayerAnswer;
								switch ( locals[78] ) {

								case 1:

										goto label_0e51;

										//break;

								case 2:

										yield return StartCoroutine(func_101b());
										break;

								case 3:

										yield return StartCoroutine(func_0d74());
										break;
								} // end if

						} //else {

						//		break;

						//} // end switch

						if ( locals[18] > 2 ) {

								yield return StartCoroutine(say( locals, "I am tired of this foolishness." ));
								yield return StartCoroutine(func_0d74());
						} else {

								yield return StartCoroutine(say( locals, "Well? Show me what you have, quickly!" ));
								locals[79] = 92;
								locals[80] = 93;
								locals[81] = 0;
								//locals[100] = babl_menu( 0, locals[79] );
								yield return StartCoroutine(babl_menu (0,locals,79));
								locals[10] = PlayerAnswer;
								switch ( locals[100] ) {

								case 1:

										locals[18] = locals[18] + 1;
										goto label_0e51;

										//break;

								case 2:
										break;
								} // end if

								//break;

						} // end switch

						if ( param1 == 10 ) {

								yield return StartCoroutine(func_0a24(0));
						} else {

								yield return StartCoroutine(say( locals, "Good luck to thee, then!" ));
								Time.timeScale =SlomoTime;
								yield return new WaitForSeconds(WaitTime);
								func_0165();
								yield break;
						} // end if

				} // end if

		} // end func

		IEnumerator func_101b() {

				int[] locals = new int[2];

				yield return StartCoroutine(say( locals, "Then thou shalt leave here or die." ));
				locals[1] = 1;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_0136( locals[1] );
				yield break;
		} // end func

		IEnumerator func_1031() {

				int[] locals = new int[8];

				locals[1] = 96;
				yield return StartCoroutine(print( 1, locals[1] ));
				yield return StartCoroutine(say( locals, "Hey! This one's a rebel! Kill @GS34!" ));
				locals[2] = 60;
				locals[3] = 1;
				set_quest( 2, locals[3], locals[2] );
				locals[4] = 15;
				locals[5] = 15;
				locals[6] = 10001;
				locals[7] = x_clock( 2, locals[6], locals[5] ) + 1;
				x_clock( 2, locals[7], locals[4] );
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_0110();
				yield break;
		} // end func

		IEnumerator func_1093() {

				int[] locals = new int[2];

				locals[1] = 98;
				yield return StartCoroutine(print( 1, locals[1] ));
				yield return StartCoroutine(say( locals, "Please remain calm, @GS35. I meant only to warn thee of the danger involved in coming here, and asked if thou didst know the password." ));
		} // end func

		IEnumerator func_10ac() {

				yield return StartCoroutine(say( "What art thou playing at? No one comes to the prison tower by accident, stranger, so I bid thee, give us the password at once, or face the consequences." ));
		} // end func

		IEnumerator func_10b7() {

				yield return StartCoroutine(say( "That is not it." ));
				yield return StartCoroutine(func_0a24(1));
		} // end func

		IEnumerator func_10c4() {

				int[] locals = new int[46];

				yield return StartCoroutine(say( locals, "There is no special key -- just follow standard security procedure!" ));
				yield return StartCoroutine(say( locals, "O'course, if you've got the cash, I suppose I could...update thee on just what that procedure is." ));
				locals[1] = 104;
				locals[2] = 105;
				locals[3] = 0;
				//locals[22] = babl_menu( 0, locals[1] );
				yield return StartCoroutine(babl_menu (0,locals,1));
				locals[22] = PlayerAnswer;
				switch ( locals[22] ) {

				case 1:

						break;

				case 2:

						goto label_110f;

						//break;

				} // end switch

				yield return StartCoroutine(say( locals, "Good luck to thee, then!" ));
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_0165();
				yield break;
		label_110f:;

				yield return StartCoroutine(say( locals, "Let's see what y'got!" ));
				locals[23] = 15;
				func_0e1c( locals[23] );
				yield return StartCoroutine(say( locals, "I'm only explainin' this once -- the inner door ain't gonna open while you got the outer open. Only one door gets open at a time. Got it?" ));
				locals[24] = 109;
				locals[25] = 110;
				locals[26] = 0;
				//locals[45] = babl_menu( 0, locals[24] );
				yield return StartCoroutine(babl_menu (0,locals,24));
				locals[45] = PlayerAnswer;
				switch ( locals[45] ) {

				case 1:

						goto label_115e;

						//break;

				case 2:

						break;

				} // end switch

				yield return StartCoroutine(say( locals, "Just remember, only one door opens at a time." ));
		label_115e:;

				yield return StartCoroutine(say( locals, "Now, thou had best be on thy way!" ));
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_0156();
				yield break;
		} // end func
}