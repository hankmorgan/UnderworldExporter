using UnityEngine;
using System.Collections;

public class Conversation_89 : Conversation {

//	conversation #89
//	string block 0x0e59, name Hewstone

	public override IEnumerator main() {
		SetupConversation (3673);
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
	
	void func_008b() {
		
		npc.npc_gtarg = 1;
		npc.npc_goal = 5;
		npc.npc_attitude = 1;
		func_0012();
	} // end func
	
	/*void func_00a4() {
		
		npc.npc_attitude = 6;
	} // end func*/
	
	void func_00b1(int param1) {
		
		npc.npc_attitude = param1;//[0]play_hunger;
		func_0012();
	} // end func
	
	/*void func_00c2() {
		
		npc.npc_attitude = 2;
		func_0012();
	} // end func*/
	
	/*void func_00d1() {
		
		npc.npc_attitude = 1;
		func_0012();
	} // end func*/
	
	void func_00e0() {
		
		func_0012();
	} // end func
	
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
		
		//int locals[134];
		int[] locals = new int[135];
		
		if ( privateVariables[0] == 1 ) {
			
			if ( privateVariables[5] == 1 ) {
				yield return StartCoroutine(say( "Decided to be a bit more friendly, eh?" ));
				locals[112] = 23;
				locals[113] = 24;
				locals[114] = 0;
				//locals[133] = babl_menu( 0, locals[112] );
				yield return StartCoroutine( babl_menu( 0,locals,112 ));
				locals[133] = PlayerAnswer;
				switch ( locals[133] ) {
					
				case 1:
					
					break;
					
				case 2:
					
					yield return StartCoroutine(say( "Good riddance!" ));
					locals[134] = 1;
					Time.timeScale =SlomoTime;
					yield return new WaitForSeconds(WaitTime);
					func_00b1( locals[134] );
					yield break;
					break;
					
				} // end switch
				
				privateVariables[5] = 0;
				yield return StartCoroutine(say( "That's a bit better.  I be Hewstone.  What are ye doing in these parts?" ));
				goto label_0316;
			} else {
				
				yield return StartCoroutine(say( "Ach, @GS8, the aspiring miner!  What can I do for ye?" ));
			}
		}
		else {
				
				privateVariables[2] = 1;
				privateVariables[3] = 1;
				privateVariables[4] = 1;
				yield return StartCoroutine(say( "Ach, ye don't look like a miner to me.  Who be ye?" ));
				locals[2] = 3;
				locals[3] = 4;
				locals[4] = 0;
				//locals[23] = babl_menu( 0, locals[2] );
				yield return StartCoroutine( babl_menu( 0,locals,2 ));
				locals[23] = PlayerAnswer;
				switch ( locals[23] ) {
					
				case 1:
					
					break;
					
				case 2:
					
					yield return StartCoroutine(say( "Well then, off with thee!" ));
					privateVariables[5] = 1;
					locals[24] = 1;
					Time.timeScale =SlomoTime;
					yield return new WaitForSeconds(WaitTime);
					func_00b1( locals[24] );
					yield break;
					break;
					
				} // end switch
				
				yield return StartCoroutine(say( "Well met, @GS8.  I be Hewstone.  What are ye doing in these parts?" ));
		}	
			label_0316:;
				
				locals[25] = 7;
				locals[26] = 8;
				locals[27] = 9;
				locals[28] = 0;
				//locals[46] = babl_menu( 0, locals[25] );
				yield return StartCoroutine( babl_menu( 0,locals,25 ));
				locals[46] = PlayerAnswer;
				switch ( locals[46] ) {
					
				case 1:
					
					goto label_0367;
					
					break;
					
				case 2:
					
					goto label_03b0;
					
					break;
					
				case 3:
					
					goto label_03ba;
					
					break;
					
				} // end switch
	
			label_0367:;
				

				privateVariables[2] = 0;
				yield return StartCoroutine(say( "Aye, ye would be a miner, eh?  It's a tough job, ye should know that. Don't take it up if ye have not the strength.  Hard it work it is, picking up a rock hammer and smashing boulders to pieces, scraping the rock over and over again, one inch of wall at a time." ));
				locals[47] = 11;
				locals[48] = 12;
				locals[49] = 0;
				//locals[68] = babl_menu( 0, locals[47] );
				yield return StartCoroutine( babl_menu( 0,locals,47 ));
				locals[68] = PlayerAnswer;
				switch ( locals[68] ) {
					
				case 1:
					
					break;
					
				case 2:
					
					break;
					
				} // end switch
				
				yield return StartCoroutine(say( "Well, it is backbreaking work but the rewards are great.  Gold there is for the hard worker, and I know of no substance better.  Ah, the thrill of feeling one's hammer thud solid rock and suddenly discovering a new vein!\n"
				   + " Go ye to the northern part of these mines and see for yourself the beauty of a gold mine.  But watch yourself - a fearsome monster has been seen in that area, and perhaps even an adventurer such as ye could not handle it./m" ));
				yield return StartCoroutine(say( "Is there anything else I can help ye with?" ));
				goto label_03c4;
				
			label_03b0:;

				privateVariables[3] = 0;
				yield return StartCoroutine(say( "Ach, ye've come to the right place.  There is no treasure better than gold, and gold there is in abundance in these mines.  In the north parts of these mines especially, ye shall find a beautiful sight. Be careful of the monster that's been seen around those parts, though.\n"
				    +" Now, what else might ye want to know?" ));
				goto label_03c4;
				
			label_03ba:;

				privateVariables[4] = 0;
				yield return StartCoroutine(say( "The monster of the mines?  A great boon it would be if ye did defeat it, but I don't know that it can be done.  A fearsome thing it is.  Caught it once out of the corner of me eye, and I don't care to see it again.  It lurks in the north part of these mines.  Ye be careful, if ye truly mean to destroy it.\n"
				   + " We caused a cave-in to block its area from ours, so ye'll have to break your way through it.  Is there anything I can help ye with before ye go off after it?" ));
			//} // end if
			
		label_03c4:;

			//locals[1] = (((privateVariables[2]!=1) || (privateVariables[3]!=1)) || (privateVariables[4]!=1));
		if (((privateVariables[2]!=1) || (privateVariables[3]!=1)) || (privateVariables[4]!=1)==true)
		    {
			locals[1]=1;
			}
			else
			{
			locals[1]=0;
			}
			locals[90] = privateVariables[2];
			locals[69] = 17;
			locals[91] = privateVariables[3];
			locals[70] = 18;
			locals[92] = privateVariables[4];
			locals[71] = 19;
			locals[93] = locals[1];
			locals[72] = 20;
			locals[94] = 1;
			locals[73] = 21;
			locals[74] = 0;
			//locals[111] = babl_fmenu( 0, locals[69], locals[90] );
			yield return StartCoroutine(babl_fmenu (0,locals,69,90));
			locals[111] = PlayerAnswer;
			switch ( locals[111] ) {
				
			case 17:
				
				goto label_0367;
				
				break;
				
			case 18:
				
				goto label_03b0;
				
				break;
				
			case 19:
				
				goto label_03ba;
				
				break;
				
			case 20:
				
				goto label_04d1;
				
				break;
				
			case 21:
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00e0();
				yield break;
				break;
			} // end switch
		

		
	label_04d1:;
		
		yield return StartCoroutine(say( "'Twould be a pleasure." ));
		yield return StartCoroutine (func_04de());
		yield return StartCoroutine(say( "Farewell." ));
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00e0();
		yield break;
	} // end func

	
	IEnumerator func_04de() {
		
		//int locals[44];
		int[] locals = new int[45];
		
		setup_to_barter( 0 );
		while ( privateVariables[1] ==0 ) {
			
			locals[1] = 29;
			locals[2] = 30;
			locals[3] = 31;
			locals[4] = 32;
			locals[5] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine( babl_menu( 0,locals,1 ));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine (func_058f());
				break;
				
			case 2:
				
				yield return StartCoroutine (func_05e9());
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
		
		locals[23] = 33;
		locals[24] = 0;
		//locals[44] = babl_menu( 0, locals[23] );
		yield return StartCoroutine( babl_menu( 0,locals,23));
		locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_058f() {
		
		//int locals[15];
		int[] locals = new int[16];
		
		locals[0] = -1;
		locals[6] = -1;
		locals[11] = 34;
		locals[12] = 35;
		locals[13] = 36;
		locals[14] = 37;
		locals[15] = 38;
		//if ( do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ) ) {
		yield return StartCoroutine (do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ));
		if (PlayerAnswer==1){
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_05e9() {
		
		//int locals[24];
		int[] locals = new int[25];
		
		yield return StartCoroutine(say( "Dost thou intend to rob me?" ));
		locals[1] = 40;
		locals[2] = 41;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine( babl_menu( 0,locals,1 ));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:

			yield break;
			//return;
			
			break;
			
		} // end switch
		
		locals[23] = 42;
		locals[24] = 43;
		//if ( do_demand( 2, locals[24], locals[23] ) ) {
		yield return StartCoroutine (do_demand( 2, locals[24], locals[23] ));
		if (PlayerAnswer==1){
			
			privateVariables[1] = 1;
		} else {
			
			func_008b();
		} // end if
		
	} // end func



}
