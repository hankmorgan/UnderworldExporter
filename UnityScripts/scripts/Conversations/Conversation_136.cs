using UnityEngine;
using System.Collections;

public class Conversation_136 : Conversation {
	
	//conversation #136
	//string block 0x0e88, name Oradinar
	
	int func_0920_result;
	public override IEnumerator main() {
		SetupConversation (3720);
		play_hunger=65;
		privateVariables[1] = 0;
		yield return StartCoroutine(func_029d());
		func_0012();
		yield return 0;
	} // end func func
	
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
	
	void func_0063() {
		
		npc.npc_gtarg = 1;
		npc.npc_attitude = 1;
		npc.npc_goal = 6;
		func_0012();
	} // end func
	
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
	
	/*void func_00b1() {
		
		npc.npc_attitude = param1[0]play_hunger;
		func_0012();
	} // end func*/
	
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
		
		if ( privateVariables[0] == 0 ) {
			
			func_08cb();
			privateVariables[2] = 0;
			privateVariables[3] = 0;
		} // end if
		
		if ( privateVariables[0] == 1) {
			
			yield return StartCoroutine(func_0801());
		} else {
			
			yield return StartCoroutine(func_02c4());
		} // end if
		
	} // end func
	
	IEnumerator func_02c4() {
		
		//int locals[22];
		int[]locals=new int[23];
		
		yield return StartCoroutine(say( locals, 001 ));
		locals[1] = 2;
		locals[2] = 3;
		locals[3] = 4;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0325());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0325());
			break;
			
		case 3:
			
			privateVariables[2] = 1;
			yield return StartCoroutine(func_0920());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0325() {
		int[] locals = new int[1];
		yield return StartCoroutine(say( locals, 005 ));
		yield return StartCoroutine(func_0332());
	} // end func
	
	IEnumerator func_0332() {
		
		//int locals[66];
		int []locals = new int[67];
		
		if ( play_hunger == 0 ) {
			
			locals[1] = 6;
			locals[2] = 7;
			locals[3] = 8;
			locals[4] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_0469());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_04d9());
				break;
				
			case 3:
				
				yield return StartCoroutine(func_0521());
				break;
			} // end if
			
		} else {
			
			if ( play_hunger < 64 ) {
				
				locals[23] = 9;
				locals[24] = 10;
				locals[25] = 11;
				locals[26] = 12;
				locals[27] = 0;
				//locals[44] = babl_menu( 0, locals[23] );
				yield return StartCoroutine(babl_menu (0,locals,23));
				locals[44] = PlayerAnswer;
				switch ( locals[44] ) {
					
				case 1:
					
					yield return StartCoroutine(func_0569());
					break;
					
				case 2:
					
					yield return StartCoroutine(func_0611());
					break;
					
				case 3:
					
					yield return StartCoroutine(func_04d9());
					break;
					
				case 4:
					
					yield return StartCoroutine(func_0521());
					break;
				} // end if
				
			} else {
				
				locals[45] = 13;
				locals[46] = 14;
				locals[47] = 15;
				locals[48] = 16;
				locals[49] = 0;
				//locals[66] = babl_menu( 0, locals[45] );
				yield return StartCoroutine(babl_menu (0,locals,45));
				locals[66] = PlayerAnswer;
				switch ( locals[66] ) {
					
				case 1:
					
					yield return StartCoroutine(func_066d());
					break;
					
				case 2:
					
					yield return StartCoroutine(func_0611());
					break;
					
				case 3:
					
					yield return StartCoroutine(func_04d9());
					break;
					
				case 4:
					
					yield return StartCoroutine(func_0521());
					break;
					
				} // end switch
				
			} // end switch
			
		} // end switch
		
		
		
		
		
	} // end func
	
	IEnumerator func_0469() {
		
		//int locals[23];
		int[] locals = new int[24];
		
		yield return StartCoroutine(say( locals, 017 ));
		yield return StartCoroutine(say( locals, 018 ));
		if ( privateVariables[3] == 1 ) {
			
			yield return StartCoroutine(say( locals, 019 ));
			yield return StartCoroutine(func_0920());
		} else {
			
			yield return StartCoroutine(say( locals, 020 ));
			locals[1] = 21;
			locals[2] = 22;
			locals[3] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				locals[23] = 299;
				take_from_npc( 1, locals[23] );
				privateVariables[3] = 1;
				yield return StartCoroutine(func_07cd());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_0920());
				break;
			} // end if
			
			
			
		} // end switch
		
	} // end func
	
	IEnumerator func_04d9() {
		
		//int locals[22];
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 023 ));
		locals[1] = 24;
		locals[2] = 25;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00c2();//Endconvo
			yield break;
			break;
			
		case 2:
			
			func_00e0();//End convo
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0521() {
		
		//int locals[22];
		int [] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 026 ));
		locals[1] = 27;
		locals[2] = 28;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_06c9());
			break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00d1();//EndConvo
			yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0569() {
		
		//int locals[45];
		int [] locals = new int[46];
		
		yield return StartCoroutine(say( locals, 029 ));
		if ( privateVariables[3] == 1 ) {
			
			yield return StartCoroutine(say( locals, 030 ));
			locals[1] = 31;
			locals[2] = 32;
			locals[3] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				func_00e0();
				break;
				
			case 2:
				
				func_00c2();
				break;
			} // end if
			
		} else {
			
			yield return StartCoroutine(say( locals, 033 ));
			locals[23] = 34;
			locals[24] = 35;
			locals[25] = 0;
			//locals[44] = babl_menu( 0, locals[23] );
			yield return StartCoroutine(babl_menu (0,locals,23));
			locals[44] = PlayerAnswer;
			switch ( locals[44] ) {
				
			case 1:
				
				locals[45] = 299;
				take_from_npc( 1, locals[45] );
				privateVariables[3] = 1;
				yield return StartCoroutine(func_07cd());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_0920());
				break;
				
			} // end switch
			
		} // end switch
		
		
		
	} // end func
	
	IEnumerator func_0611() {
		
		//int locals[22];
		int [] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 036 ));
		locals[1] = 37;
		locals[2] = 38;
		locals[3] = 39;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_066d());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_06c9());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_0771());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_066d() {
		
		//int locals[22];
		int[] locals =new int[23];
		
		yield return StartCoroutine(say( locals, 040 ));
		locals[1] = 41;
		locals[2] = 42;
		locals[3] = 43;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_06c9());
			break;
			
		case 2:
			
			func_00c2();
			break;
			
		case 3:
			
			yield return StartCoroutine(func_0771());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_06c9() {
		
		//int locals[45];
		int[] locals = new int[46];
		
		yield return StartCoroutine(say( locals, 044 ));
		if ( privateVariables[3] == 1 ) {
			
			yield return StartCoroutine(say( locals, 045 ));
			locals[1] = 46;
			locals[2] = 47;
			locals[3] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00e0();//EndConvo
				yield break;
				break;
				
			case 2:
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00c2();//EndConvo
				yield break;
				break;
			} // end if
			
		} else {
			
			yield return StartCoroutine(say( locals, 048 ));
			locals[23] = 49;
			locals[24] = 50;
			locals[25] = 0;
			//locals[44] = babl_menu( 0, locals[23] );
			yield return StartCoroutine(babl_menu (0,locals,23));
			locals[44] = PlayerAnswer;
			switch ( locals[44] ) {
				
			case 1:
				
				locals[45] = 299;
				take_from_npc( 1, locals[45] );
				privateVariables[3] = 1;
				yield return StartCoroutine(func_07cd());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_0920());
				break;
				
			} // end switch
			
		} // end switch
		
		
		
	} // end func
	
	IEnumerator func_0771() {
		
		//int locals[22];
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 051 ));
		locals[1] = 52;
		locals[2] = 53;
		locals[3] = 54;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00c2();//EndConvo
			yield break;
			break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00d1();//EndConvo
			yield break;
			break;
			
		case 3:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_0063();//EndConvo
			yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_07cd() {
		
		//int locals[22];
		int [] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 055 ));
		locals[1] = 56;
		locals[2] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		if ( locals[22] == 1 ) {
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();//EndConvo
			yield break;
		} // end if
		
	} // end func
	
	IEnumerator func_0801() {
		
		//int locals[44];
		int [] locals = new int[45];
		
		if ( privateVariables[2] == 1 ) {
			
			yield return StartCoroutine(say( locals, 057 ));
			locals[1] = 58;
			locals[2] = 59;
			locals[3] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00d1();//EndConvo
				yield break;
				break;
				
			case 2:
				
				privateVariables[2] = 0;
				yield return StartCoroutine(func_08be());
				break;
			} // end if
			
		} else {
			
			if ( privateVariables[3] == 1 ) {
				
				yield return StartCoroutine(say( locals, 060 ));
				locals[23] = 61;
				locals[24] = 63;
				locals[25] = 64;
				locals[26] = 0;
				//locals[44] = babl_menu( 0, locals[23] );
				yield return StartCoroutine(babl_menu (0,locals,23));
				locals[44] = PlayerAnswer;
				switch ( locals[44] ) {
					
				case 1:
					
					yield return StartCoroutine(say( locals, 062 ));
					yield return StartCoroutine(func_0920());
					break;
					
				case 2:
					
					yield return StartCoroutine(func_0920());
					break;
					
				case 3:
					
					yield return StartCoroutine(func_0771());
					break;
				} // end if
				
			} else {
				
				yield return StartCoroutine(say( locals, 065 ));
				yield return StartCoroutine(func_0332());
				
			} // end switch
			
		} // end switch
		
		
		
		
	} // end func
	
	IEnumerator func_08be() {
		int[] locals = new int[1];
		yield return StartCoroutine(say( locals, 066 ));
		yield return StartCoroutine(func_0332());
	} // end func
	
	void func_08cb() {
		//TODO:Figure this out.
		/*privateVariables[4][1] = 1011;
		privateVariables[4][2] = 1002;
		privateVariables[4][3] = 1003;
		privateVariables[4][4] = 1000;
		privateVariables[4][5] = -1;
		privateVariables[25][1] = 161;
		privateVariables[25][2] = 160;
		privateVariables[25][3] = -1;*/
		set_likes_dislikes( 2, 56, 35 );
	} // end func
	
	IEnumerator func_0920() {
		
		//int locals[22];
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( locals, 067 ));
		locals[1] = 68;
		locals[2] = 69;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_096d());
			break;
			
		case 2:
			
			goto label_0965;
			
			break;
			
		} // end switch
		
	label_0965:;
		func_0920_result=locals[1];
		//return locals[1];
	} // end func
	
	IEnumerator func_096d() {
		
		//int locals[44];
		int [] locals=new int[45];
		
		setup_to_barter( 0 );
		while ( privateVariables[1] == 0 ) {
			
			locals[1] = 70;
			locals[2] = 71;
			locals[3] = 72;
			locals[4] = 73;
			locals[5] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_0a1e());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_0a60());
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
		
		locals[23] = 74;
		locals[24] = 0;
		//locals[44] = babl_menu( 0, locals[23] );
		yield return StartCoroutine(babl_menu (0,locals,23));
		locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_0a1e() {
		
		//int locals[5];
		int[] locals=new int[6];
		
		locals[1] = 75;
		locals[2] = 76;
		locals[3] = 77;
		locals[4] = 78;
		locals[5] = 79;
		//if ( do_offer( 5, locals[5], locals[4], locals[3], locals[2], locals[1] ) ) {
		yield return StartCoroutine (do_offer( 5, locals[5], locals[4], locals[3], locals[2], locals[1], 0,0) );
		if (PlayerAnswer==1)	{
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_0a60() {
		
		//int locals[24];
		int[] locals = new int[25];
		
		yield return StartCoroutine(say( locals, 080 ));
		locals[1] = 81;
		locals[2] = 82;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			yield break;
			
			break;
			
		} // end switch
		
		locals[23] = 83;
		locals[24] = 84;
		//if ( do_demand( 2, locals[24], locals[23] ) ) {
		yield return StartCoroutine (do_demand( 2, locals[24], locals[23] ));
		if (PlayerAnswer==1){
			
			privateVariables[1] = 1;
		} else {
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_008b();
			yield break;
		} // end if
		
	} // end func
	
}
