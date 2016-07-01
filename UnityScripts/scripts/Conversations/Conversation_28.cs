using UnityEngine;
using System.Collections;

public class Conversation_28 : Conversation {
	//conversation #28
	//string block 0x0e1c, name Zak
	
	public int[] global = new int[1];
	int func_0836_result;
	public int PrivateVariable_37;
	public override IEnumerator main() {
		SetupConversation (3612);
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
		
		npc.npc_attitude = param1;//param1[0];//global[0];
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
	
	void func_00e0() {
		
		func_0012();
	} // end func
	
	void func_00ea(int param1) {
		//TODO:Figure this one out
		//param1[1] = game_days;
		//param1[2] = game_mins;
	} // end func
	
	int func_0106(int param1, int param2) {
		
		//int locals[4];
		int[]locals =new int[5];
		
		//locals[2] = game_days - param2[1];
		locals[2] = game_days - param1;//[1];
		locals[3] = game_mins - param2;//[2];
		if ( locals[3] < 0 ) {
			
			locals[3] = locals[3] + 1440;
			locals[2] = locals[2] - 1;
		} // end if
		
		//if ( locals[2] >= param1[1] && locals[3] >= param1[2] ) {
		if ( locals[2] >= param1 && locals[3] >= param1 ) {			
			locals[1] = 1;
		} else {
			
			locals[1] = 0;
		} // end if
		
		return locals[1];
		
	} // end func
	
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
		
		//int locals[24];
		int[] locals = new int[25];
		
		if ( privateVariables[0] !=1) {
			
			global[0] = 0;
		} // end if
		//TODO:Privatevariables 38 is out of bounds! Uncommented since the varialb is unused elsewhere.
		if ( global[0] ==1) {
			
			//privateVariables[38] = play_name;
		} else {
			
			//privateVariables[38] = 1;
		} // end if
		
		if ( privateVariables[0] == 1 ) {
			
			func_0405();
		} // end if
		
		yield return StartCoroutine( say( locals, 002 ));
		locals[1] = 10;
		locals[2] = 1;
		set_quest( 2, locals[2], locals[1] );
		locals[3] = 3;
		locals[4] = 4;
		locals[5] = 0;
		//locals[24] = babl_menu( 0, locals[3] );
		yield return StartCoroutine(babl_menu (0,locals,3));
		locals[24] = PlayerAnswer;
		switch ( locals[24] ) {
			
		case 1:
			
			global[0] = 1;
			yield return StartCoroutine( func_03b8());
			break;
			
		case 2:
			
			yield return StartCoroutine( func_0328());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0328() {
		
		//int locals[22];
		int[] locals=new int[23];
		
		yield return StartCoroutine( say( locals, 005 ));
		locals[1] = 6;
		locals[2] = 7;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine( func_05ba());
			break;
			
		case 2:
			
			yield return StartCoroutine( func_0370());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0370() {
		
		//int locals[22];
		int[] locals=new int[23];
		yield return StartCoroutine( say( locals, 008 ));
		locals[1] = 9;
		locals[2] = 10;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine( func_05ba());
			break;
			
		case 2:
			
			yield return StartCoroutine( func_0778());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03b8() {
		
		//int locals[22];
		int[] locals=new int[23];
		
		yield return StartCoroutine( say( locals, 011 ));
		locals[1] = 12;
		locals[2] = 13;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			global[0] = 1;
			yield return StartCoroutine( func_0405());
			break;
			
		case 2:
			
			yield return StartCoroutine( func_0610());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0405() {
		
		//int locals[71];
		int[] locals=new int[72];
		
		locals[2] = 0;
		locals[1] = random( 1, locals[4] );
		locals[4] = 3;
		locals[5] = locals[1];
		if ( 1 == locals[5] ) {
			
			func_0328();
		} else {
			
			if ( 2 == locals[5] ) {
				
				yield return StartCoroutine( say( locals, 014 ));
			} else {
				
				if ( 3 == locals[5] ) {
					
					if ( global[0] ==1) {
						
						yield return StartCoroutine( say( locals, 015 ));
					} else {
						
						yield return StartCoroutine( say( locals, 016 ));
					} // end if
					
					locals[2] = 1;
				} // end if
				
			} // end if
			
		} // end if
		//locals[3] = !locals[2];
		if (locals[2]==0)
		{
			locals[3]=1;
		}
		else
		{
			locals[3]=0;
		}
		locals[27] = 1;
		locals[6] = 17;
		locals[28] = locals[3];
		locals[7] = 18;
		locals[29] = locals[2];
		locals[8] = 19;
		locals[9] = 0;
		//locals[48] = babl_fmenu( 0, locals[6], locals[27] );
		yield return StartCoroutine(babl_fmenu (0,locals,6,27));
		locals[48] = PlayerAnswer;
		switch ( locals[48] ) {
			
		case 17:
			
			locals[49] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[49] );
			yield break;

		case 18:
			
			break;
			
		case 19:
			
			global[0] = 1;
			yield return StartCoroutine( func_0569());
			break;
			
		} // end switch
		
		yield return StartCoroutine( say( locals, 020 ));
		locals[50] = 21;
		locals[51] = 22;
		locals[52] = 0;
		//locals[71] = babl_menu( 0, locals[50] );
		yield return StartCoroutine(babl_menu (0,locals,50));
		locals[71] = PlayerAnswer;
		switch ( locals[71] ) {
			
		case 1:
			
			yield return StartCoroutine( func_0730());
			break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();//END CONVO
			yield break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0521() {
		
		//int locals[22];
		int[] locals=new int[23];
		
		yield return StartCoroutine( say( locals, 023 ));
		locals[1] = 24;
		locals[2] = 25;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine( func_0730());
			break;
			
		case 2:
			
			yield return StartCoroutine( func_0778());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0569() {
		
		//int locals[23];
		int [] locals= new int[24];
		
		yield return StartCoroutine( say( locals, 026 ));
		locals[1] = 27;
		locals[2] = 28;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			func_0730();
			break;
			
		case 2:
			
			locals[23] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_05ba() {
		
		//int locals[23];
		int[] locals=new int[24];
		
		yield return StartCoroutine( say( locals, 029 ));
		locals[1] = 30;
		locals[2] = 31;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			global[0] = 1;
			yield return StartCoroutine( func_0569());
			break;
			
		case 2:
			
			locals[23] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );//Endconvo?
			yield break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0610() {
		
		//int locals[22];
		int[]locals= new int[23];
		
		yield return StartCoroutine( say( locals, 032 ));
		locals[1] = 33;
		locals[2] = 34;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine( func_06a0());
			break;
			
		case 2:
			
			yield return StartCoroutine( func_0658());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0658() {
		
		//	int locals[22];
		int[] locals= new int[23];
		
		yield return StartCoroutine( say( locals, 035 ));
		locals[1] = 36;
		locals[2] = 37;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine( func_06e8());
			break;
			
		case 2:
			
			yield return StartCoroutine( func_0778());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_06a0() {
		
		//int locals[22];
		int[] locals=new int[23];
		
		yield return StartCoroutine( say( locals, 038 ));
		locals[1] = 39;
		locals[2] = 40;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine( func_06e8());
			break;
			
		case 2:
			
			yield return StartCoroutine( func_0778());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_06e8() {
		
		//int locals[22];
		int[] locals = new int[23];
		
		yield return StartCoroutine( say( locals, 041 ));
		locals[1] = 42;
		locals[2] = 43;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0521());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0730());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0730() {
		
		//int locals[22];
		int [] locals = new int[23];
		
		yield return StartCoroutine( say( locals, 044 ));
		locals[1] = 45;
		locals[2] = 46;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine( func_07c9());
			break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00c2();//Endconvo
			yield break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0778() {
		
		//int locals[23];
		int[] locals = new int[24];
		
		yield return StartCoroutine( say( locals, 047 ));
		locals[1] = 48;
		locals[2] = 49;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			locals[23] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			
		case 2:
			
			yield return StartCoroutine( func_05ba());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_07c9() {
		
		//int locals[23];
		int[] locals = new int[24];
		
		yield return StartCoroutine(func_0836());
		if (func_0836_result == 0){
			//	if ( !func_0836() ) {
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
		} // end if
		
		setup_to_barter( 0 );
		yield return StartCoroutine( say( locals, 050 ));
		locals[1] = 51;
		locals[2] = 52;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			do_decline( 0 );
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00c2();//ENDCONVO
			yield break;
			
		} // end switch
		
		yield return StartCoroutine( say( locals, 053 ));
		yield return StartCoroutine( func_091b());
		PrivateVariable_37 = 0;
		locals[23] = 3;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[23] );
		yield break;
	} // end func
	
	IEnumerator func_0836() {
		
		//int locals[4];
		int[] locals = new int[5];
		
		if ( privateVariables[0] == 0 ) {
			//TODO:FIgure this out
			/*privateVariables[2][1] = 1011;
			privateVariables[2][2] = 1009;
			privateVariables[2][3] = -1;
			privateVariables[18][1] = 1000;
			privateVariables[18][2] = 1010;
			privateVariables[18][3] = 1002;
			privateVariables[18][4] = 1003;
			privateVariables[18][5] = 1001;
			privateVariables[18][6] = 1018;
			privateVariables[18][7] = 1012;
			privateVariables[18][8] = 1013;
			privateVariables[18][9] = 1017;
			privateVariables[18][10] = 1016;
			privateVariables[18][11] = 1019;
			privateVariables[18][12] = 147;
			privateVariables[18][13] = -1;*/
			set_likes_dislikes( 2, 50, 34 );
			PrivateVariable_37 = 1;
		} // end if
		
		locals[2] = 0;
		locals[3] = 60 * 6;
		//if ( !PrivateVariable_37 && !func_0106( locals[2], 66 ) ) {
		if ( (PrivateVariable_37==0) && (func_0106( locals[2], 66 )  == 0)) {
			yield return StartCoroutine( say( locals, 054 ));
			locals[1] = 0;
		} else {
			
			func_00ea( 66 );//End convo
			locals[1] = 1;
		} // end if
		
		//return locals[1];
		func_0836_result=locals[1];
	} // end func
	
	IEnumerator func_091b() {
		
		//int locals[44];
		int[] locals = new int[45];
		
		setup_to_barter( 0 );
		while ( privateVariables[1]!=1 ) {
			
			locals[1] = 55;
			locals[2] = 56;
			locals[3] = 57;
			locals[4] = 58;
			locals[5] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine( func_09cc());
				break;
				
			case 2:
				
				yield return StartCoroutine( func_0a26());
				break;
				
			case 3:
				
				yield return StartCoroutine( do_judgement( 0 ));
				break;
				
			case 4:
				
				do_decline( 0 );
				privateVariables[1] = 1;
				break;
				
			} // end switch
			
		} // while
		
		locals[23] = 59;
		locals[24] = 0;
		//locals[44] = babl_menu( 0, locals[23] );
		yield return StartCoroutine(babl_menu (0,locals,23));
		locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_09cc() {
		
		//int locals[15];
		int[] locals = new int[16];
		
		locals[0] = -1;
		locals[6] = -1;
		locals[11] = 60;
		locals[12] = 61;
		locals[13] = 62;
		locals[14] = 63;
		locals[15] = 64;
		//if ( do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ) ) {
		yield return StartCoroutine (do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6],locals[1]) );
		if (PlayerAnswer==1)	{
			
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_0a26() {
		
		//int locals[24];
		int[] locals =new int[25];
		
		yield return StartCoroutine( say( locals, 065 ));
		locals[1] = 66;
		locals[2] = 67;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			//return;
			yield break;
			
		} // end switch
		
		locals[23] = 68;
		locals[24] = 69;
		//if ( do_demand( 2, locals[24], locals[23] ) ) {
		yield return StartCoroutine (do_demand( 2, locals[24], locals[23] ));
		if (PlayerAnswer==1){
			
			privateVariables[1] = 1;
		} else {
			
			yield return StartCoroutine( func_0521());
		} // end if
		
	} // end func
}
