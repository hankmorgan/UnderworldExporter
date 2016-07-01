using UnityEngine;
using System.Collections;

public class Conversation_5 : Conversation {
	
	//conversation #5
	//string block 0x0e05, name Eyesnack
	//Converation heavily rejigged to work properly. File this one in the asshole category of conversations alongside 
	//Shak and Goldthirst.
	
	public override IEnumerator main() {
		SetupConversation (3589);
		privateVariables[1] = 0;
		yield return StartCoroutine(func_029d());
		func_0012();
		yield return 0;
	} // end func
	
	void func_0012() {
		EndConversation ();
		privateVariables[0] = 1;
	} // end func
	
	/*void func_0020() {
		
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
		
		npc.npc_attitude = param1;//param1[0]play_hunger;
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
		
		int[] locals = new int[383];
		
		if ( privateVariables[0]==1 ) {
			locals[3] = npc.npc_attitude;
			if ( 1 == locals[3] ) {
				
				yield return StartCoroutine(func_07ca());
			} else {
				
				if ( 2 == locals[3] ) {
					
					yield return StartCoroutine(say( locals, 001 ));
				} else {
					
					if ( 3 == locals[3] ) {
						
						yield return StartCoroutine(say( locals, 002 ));
					} // end if
					
				} // end if
				
			} // end if
		} else {
			
			privateVariables[2] = 0;
			privateVariables[3] = 0;
			privateVariables[4] = 0;
		} // end if
		
		
		
		if ( privateVariables[3] == 0) {
			privateVariables[3]=1;
			yield return StartCoroutine(say( locals, 011 ));
			locals[47] = 12;
			locals[48] = 13;
			locals[49] = 14;
			locals[50] = 0;
			//locals[68] = babl_menu( 0, locals[47] );
			yield return StartCoroutine(babl_menu (0,locals,47));
			locals[68] = PlayerAnswer;
			switch ( locals[68] ) {
				
			case 1:
				
				yield return StartCoroutine(label_03e4(locals));
				
				break;
				
			case 2:
				
				yield return StartCoroutine( label_0779(locals));
				
				break;
				
			case 3:
				
				yield return StartCoroutine( label_07b9(locals));
				
				break;
				
			} // end switch
			
			
			
		} else {
			
			locals[2] = 3;
			while ( true ) {
				
				yield return StartCoroutine(say( locals, 004 ));
				locals[2] = 5;
				locals[25] = 1;
				locals[4] = 6;
				locals[26] = 1;
				locals[5] = 7;
				locals[27] = privateVariables[4];
				locals[6] = 8;
				locals[28] = 1;
				locals[7] = 10;
				locals[8] = 0;
				//locals[46] = babl_fmenu( 0, locals[4], locals[25] );
				yield return StartCoroutine (babl_fmenu(0,locals,4,25));
				locals[46] = PlayerAnswer;
				switch ( locals[46] ) {
					
				case 6:
					
					yield return StartCoroutine( label_0668(locals));
					
					break;
					
				case 7:
					
					yield return StartCoroutine( label_0668(locals));
					
					break;
					
				case 8:
					
					yield return StartCoroutine(say( locals, 009 ));
					break;
					
				case 10:
					Time.timeScale =SlomoTime;
					yield return new WaitForSeconds(WaitTime);
					func_00b1( 21 );
					yield break;
					
				} // end switch
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
			} // while
			
			
			
			
		} // end if
		
		
		
		
	}	
	
	
	//} // end switch
	
	
	
	
	//}
	
	
	IEnumerator label_056e(int[] locals)
	{
		yield return StartCoroutine(say( locals, 033 ));
		//} // end if
		
		locals[201] = 34;
		locals[202] = 35;
		locals[203] = 0;
		//locals[222] = babl_menu( 0, locals[201] );
		yield return StartCoroutine(babl_menu (0,locals,201));
		locals[222] = PlayerAnswer;
		switch ( locals[222] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			yield return StartCoroutine( label_061a(locals));
			
			break;
			
		} // end switch
		locals[223] = 292;
		locals[1] = find_barter( 1, locals[223] );
		
		if ( locals[1]==0 ) {
			
			yield return StartCoroutine(say( locals, 036 ));
		} else {
			
			yield return StartCoroutine(say( locals, 037 ));
			privateVariables[4] = 1;
			//privateVariables[3] = 0;
			locals[224] = 38;
			locals[225] = 39;
			locals[226] = 0;
			//locals[245] = babl_menu( 0, locals[224] );
			yield return StartCoroutine(babl_menu (0,locals,224));
			locals[245] = PlayerAnswer;
			switch ( locals[245] ) {
				
			case 1:
				
				break;
				
			case 2:
				
				break;
				
			} // end switch
			
			locals[246] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[246] );
			yield break;
		}
	}
	
	
	IEnumerator label_0628(int[]locals)
	{
		yield return StartCoroutine(say( locals, 041 ));
		locals[248] = 42;
		locals[249] = 43;
		locals[250] = 0;
		//locals[269] = babl_menu( 0, locals[248] );
		yield return StartCoroutine(babl_menu (0,locals,248));
		locals[269] = PlayerAnswer;
		switch ( locals[269] ) {
			
		case 1:
			
			yield return StartCoroutine( label_0464(locals));
			
			break;
			
		case 2:
			
			yield return StartCoroutine( label_0668(locals));
			
			break;
			
		} // end switch
	}
	
	IEnumerator	label_0668(int[]locals)
	{
		yield return StartCoroutine(say( locals, 044 ));
		locals[270] = 45;
		locals[271] = 46;
		locals[272] = 0;
		//locals[291] = babl_menu( 0, locals[270] );
		yield return StartCoroutine(babl_menu (0,locals,270));
		locals[291] = PlayerAnswer;
		switch ( locals[291] ) {
			
		case 1:
			
			yield return StartCoroutine( label_0464(locals));
			
			break;
			
		case 2:
			
			yield return StartCoroutine( label_06a8(locals));
			
			break;
			
		} // end switch
		
	}
	
	
	IEnumerator	label_03e4(int[]locals)
	{
		yield return StartCoroutine(say( locals, 015 ));
		locals[69] = 16;
		locals[70] = 17;
		locals[71] = 0;
		//locals[90] = babl_menu( 0, locals[69] );
		yield return StartCoroutine(babl_menu (0,locals,69));
		locals[90] = PlayerAnswer;
		switch ( locals[90] ) {
			
		case 1:
			
			yield return StartCoroutine( label_0424(locals));
			
			break;
			
		case 2:
			
			yield return StartCoroutine( label_06f1(locals));
			
			break;
			
		} // end switch
	}	
	/*************/
	
	IEnumerator	label_0424(int[]locals)
	{
		yield return StartCoroutine(say( locals, 018 ));
		locals[91] = 19;
		locals[92] = 20;
		locals[93] = 0;
		//locals[112] = babl_menu( 0, locals[91] );
		yield return StartCoroutine(babl_menu (0,locals,91));
		locals[112] = PlayerAnswer;
		switch ( locals[112] ) {
			
		case 1:
			
			yield return StartCoroutine( label_0464(locals));
			
			break;
			
		case 2:
			
			yield return StartCoroutine( label_0628(locals));
			
			break;
			
		} // end switch
	}	
	/*************/
	IEnumerator label_0464(int[] locals)
	{
		yield return StartCoroutine(say( locals, 021 ));
		locals[113] = 22;
		locals[114] = 23;
		locals[115] = 0;
		//locals[134] = babl_menu( 0, locals[113] );
		yield return StartCoroutine(babl_menu (0,locals,113));
		locals[134] = PlayerAnswer;
		switch ( locals[134] ) {
			
		case 1:
			
			yield return StartCoroutine( label_04a4(locals));
			
			break;
			
		case 2:
			
			yield return StartCoroutine( label_04a4(locals));
			
			break;
			
		} // end switch
	}
	/**************/
	
	IEnumerator label_04a4(int[]locals)
	{
		yield return StartCoroutine(say( locals, 024 ));
		locals[135] = 25;
		locals[136] = 26;
		locals[137] = 0;
		//locals[156] = babl_menu( 0, locals[135] );
		yield return StartCoroutine(babl_menu (0,locals,135));
		locals[156] = PlayerAnswer;
		switch ( locals[156] ) {
			
		case 1:
			
			yield return StartCoroutine( label_04e4(locals));
			
			break;
			
		case 2:
			
			yield return StartCoroutine( label_04e4(locals));
			
			break;
			
		} // end switch
	}	
	
	/************/
	IEnumerator	label_04e4(int[] locals)
	{
		yield return StartCoroutine(say( locals, 027 ));
		privateVariables[2] = 1;
		locals[157] = 28;
		locals[158] = 29;
		locals[159] = 0;
		//locals[178] = babl_menu( 0, locals[157] );
		yield return StartCoroutine(babl_menu (0,locals,157));
		locals[178] = PlayerAnswer;
		switch ( locals[178] ) {
			
		case 1:
			
			yield return StartCoroutine( label_0529(locals));
			
			break;
			
		case 2:
			
			yield return StartCoroutine( label_0529(locals));
			break;
		} // end if
		
	}
	/****************/
	IEnumerator label_0529(int[] locals)
	{
		privateVariables[3] = 1;
		yield return StartCoroutine(say( locals, 030 ));
		locals[179] = 31;
		locals[180] = 32;
		locals[181] = 0;
		//locals[200] = babl_menu( 0, locals[179] );
		yield return StartCoroutine(babl_menu (0,locals,179));
		locals[200] = PlayerAnswer;
		switch ( locals[200] ) {
			
		case 1:
			
			yield return StartCoroutine( label_056e(locals));
			
			break;
			
		case 2:
			
			yield return StartCoroutine( label_061a(locals));
			
			break;
			
		} // end switch
	}	
	/***************/
	IEnumerator	label_061a(int[] locals)
	{
		yield return StartCoroutine(say( locals, 040 ));
		locals[247] = 2;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[247] );
		yield break;
	}	
	/***************/
	IEnumerator label_07b9(int[] locals)
	{
		yield return StartCoroutine(say( locals, 061 ));
		locals[382] = 1;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[382] );
		yield break;
	}	
	
	/***************/
	IEnumerator label_06a8(int[] locals)
	{
		yield return StartCoroutine(say( locals, 047 ));
		locals[292] = 48;
		locals[293] = 49;
		locals[294] = 0;
		//locals[313] = babl_menu( 0, locals[292] );
		yield return StartCoroutine(babl_menu (0,locals,292));
		locals[313] = PlayerAnswer;
		switch ( locals[313] ) {
			
		case 1:
			
			yield return StartCoroutine( label_0464(locals));
			
			break;
			
		case 2:
			
			locals[314] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[314] );
			yield break;

		} // end switch
	}
	/**************/
	IEnumerator label_06f1(int[] locals)
	{
		locals[315] = 50;
		string ans =GetString(locals[315]);
		//if ( compare( 2, locals[315], 8 ) ) {
		if ( ans.ToUpper()==playerUW.CharName.ToUpper()) {
			yield return StartCoroutine(say( locals, 051 ));
		} else {
			
			yield return StartCoroutine(say( locals, 052 ));
		} // end if
		
		yield return StartCoroutine(say( locals, 053 ));
		locals[316] = 54;
		locals[317] = 55;
		locals[318] = 0;
		//locals[337] = babl_menu( 0, locals[316] );
		yield return StartCoroutine(babl_menu (0,locals,316));
		locals[337] = PlayerAnswer;
		switch ( locals[337] ) {
			
		case 1:
			
			yield return StartCoroutine( label_0779(locals));
			
			break;
			
		case 2:
			
			yield return StartCoroutine( label_074d(locals));
			
			break;
			
		} // end switch
	}	
	/*********************/
	IEnumerator label_074d(int[] locals)
	{
		yield return StartCoroutine(say( locals, 056 ));
		locals[338] = 57;
		locals[339] = 0;
		//locals[359] = babl_menu( 0, locals[338] );
		yield return StartCoroutine(babl_menu (0,locals,338));
		locals[359] = PlayerAnswer;
		//if ( locals[359] == 1 ) {
		
		//} else {
		yield return StartCoroutine( label_0779(locals));
		
		//} // end func
	}	
	
	IEnumerator label_0779(int[] locals)
	{
		yield return StartCoroutine(say( locals, 058 ));
		locals[360] = 59;
		locals[361] = 60;
		locals[362] = 0;
		//locals[381] = babl_menu( 0, locals[360] );
		yield return StartCoroutine(babl_menu (0,locals,360));
		locals[381] = PlayerAnswer;
		switch ( locals[381] ) {
			
		case 1:
			
			yield return StartCoroutine( label_0464(locals));
			
			break;
			
		case 2:
			
			yield return StartCoroutine( label_0668(locals));;
			
			break;
			
		} // end switch
		
	}
	
	IEnumerator func_07ca() {
		
		int[] locals = new int[24];
		
		yield return StartCoroutine(say( locals, 062 ));
		locals[1] = 63;
		locals[2] = 64;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			npc.npc_attitude = npc.npc_attitude + 1;
			//return;
			yield break;
			
		case 2:
			
			yield return StartCoroutine(say( locals, 065 ));
			locals[23] = 1;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
		
		} // end switch
		
	} // end func
	
}
