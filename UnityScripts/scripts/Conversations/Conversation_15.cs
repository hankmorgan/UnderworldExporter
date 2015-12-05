using UnityEngine;
using System.Collections;

public class Conversation_15 : Conversation {

	//conversation #15
		//string block 0x0e0f, name Sseetharee
			

	
	public override IEnumerator main() {
		SetupConversation (3599);
		privateVariables[1] = 0;
		yield return StartCoroutine(func_029d());
		func_0012();
		yield return 0;
	} // end func
	
	void func_0012() {
		EndConversation();
		privateVariables[0] = 1;
	} // end func
	
	int func_0020() {
		
		//int locals[1];
		int [] locals =new int[2];
		
		if ( (((npc.npc_goal == 5 || npc.npc_goal == 6) || npc.npc_goal == 9) && npc.npc_gtarg == 1 || npc.npc_attitude == 0) ) {
			
			locals[1] = 0;
		} else {
			
			locals[1] = 1;
		} // end if
		
		return locals[1];
	} // end func
	
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
		
		npc.npc_attitude = param1 ;//param1[0];//play_hunger;
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
	
	/*void func_00e0() {
		
		func_0012();
	} // end func*/
	
	/*void func_00ea() {
		
		param1[1] = game_days;
		param1[2] = game_mins;
	} // end func*/
	
	/*void func_0106() {
		
		//int locals[4];
		int [] locals =new int[5];
		
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
		
		//int locals[23];
		int [] locals =new int[24];
		
		if ( privateVariables[0] == 0 ) {
			
			privateVariables[2] = -1;
			privateVariables[3] = -1;
		} // end if
		
		if ( privateVariables[0] == 1 ) {
			
			locals[1] = 0;
			if ( get_quest( 1, locals[1] ) == 1 ) {
				
				yield return StartCoroutine(func_0b03());
			} // end if
			
			yield return StartCoroutine(func_0429());
		} else {
			
			yield return StartCoroutine(say( "Bica, sor'click." ));
			locals[2] = 2;
			locals[3] = 3;
			locals[4] = 4;
			locals[5] = 0;
			//locals[23] = babl_menu( 0, locals[2] );
			yield return StartCoroutine(babl_menu (0,locals,2));
			locals[23] = PlayerAnswer;
			switch ( locals[23] ) {
				
			case 1:
				
				yield return StartCoroutine(func_032f());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_032f());
				break;
				
			case 3:
				
				yield return StartCoroutine(func_049e());
				break;
			} // end if
			

			
		} // end switch
		
	} // end func
	
	IEnumerator func_032f() {
		
		//int locals[23];
		int [] locals =new int[24];
		
		yield return StartCoroutine(say( "Tosa yeshor'click?  Tosa sorr?" ));
		locals[1] = 6;
		locals[2] = 7;
		locals[3] = 8;
		locals[4] = 9;
		locals[5] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_049e());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_03ac());
			break;
			
		case 3:
			
			locals[23] = npc.npc_attitude - 1;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			break;
			
		case 4:
			
			yield return StartCoroutine(func_051a());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03ac() {
		
		//int locals[23];
		int [] locals =new int[24];
		
		yield return StartCoroutine(say( "'click." ));
		locals[1] = 11;
		locals[2] = 12;
		locals[3] = 13;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0413());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_041e());
			break;
			
		case 3:
			
			locals[23] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			break;
			
		} // end switch
		//Possible fall through here.
		yield return StartCoroutine(func_032f());
	} // end func
	
	IEnumerator func_0413() {
		
		yield return StartCoroutine(say( "'click." ));
	} // end func
	
	IEnumerator func_041e() {
		
		yield return StartCoroutine(say( "Sseth." ));
	} // end func
	
	IEnumerator func_0429() {
		
		//int locals[22];
		int [] locals =new int[23];
		
		if ( privateVariables[3] == 1 ) {
			
			yield return StartCoroutine(func_0911());
		} // end if
		
		if ( privateVariables[2] == 1 ) {
			
			yield return StartCoroutine(func_0871());
		} else {
			
			yield return StartCoroutine(say( "Bica." ));
			locals[1] = 17;
			locals[2] = 18;
			locals[3] = 19;
			locals[4] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_049e());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_032f());
				break;
				
			case 3:
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( 21 );
				yield break;
				break;
			} // end if
			

			
		} // end switch
		
	} // end func
	
	IEnumerator func_049e() {
		
		//int locals[25];
		int [] locals =new int[26];
		
		yield return StartCoroutine(say( "Tosa thit sstresh.  Tosa eppa Urgo.\n"
		    +"" ));
		locals[1] = 21;
		yield return StartCoroutine(print( 1, locals[1] ));
		locals[2] = 22;
		locals[3] = 23;
		locals[4] = 24;
		locals[5] = 0;
		//locals[23] = babl_menu( 0, locals[2] );
		yield return StartCoroutine(babl_menu (0,locals,2));
		locals[23] = PlayerAnswer;
		switch ( locals[23] ) {
			
		case 1:
			
			locals[24] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[24] );
			yield break;
			break;
			
		case 2:
			
			locals[25] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[25] );
			yield break;
			break;
			
		case 3:
			
			yield return StartCoroutine(func_051a());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_051a() {
		
		//int locals[22];
		int [] locals =new int[23];
		
		yield return StartCoroutine(say( "Tosa eppa Urgo?  Urgo sstresh tosa?  Urgo sorr.  Tosa sorr?" ));
		locals[1] = 26;
		locals[2] = 27;
		locals[3] = 28;
		locals[4] = 29;
		locals[5] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_058a());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_060c());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_0666());
			break;
			
		case 4:
			//TODO what is this!
			//func_ffff();
			Debug.Log ("ffff");
			func_0012();
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_058a() {
		
		//int locals[24];
		int [] locals =new int[25];
		
		yield return StartCoroutine(say( "Tosa yeshor'click!  Isili Sseetharee.  Sseetharee yeshor'click.  Isili sstresh tosa, sseth?" ));
		locals[1] = 31;
		locals[2] = 32;
		locals[3] = 33;
		locals[4] = 34;
		locals[5] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0666());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_060c());
			break;
			
		case 3:
			
			locals[23] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			break;
			
		case 4:
			
			locals[24] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[24] );
			yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_060c() {
		
		//int locals[24];
		int [] locals =new int[25];
		
		yield return StartCoroutine(say( "Tosa sorr!  Tosa 'click eppa! Tosa eppa, isili yethe tosa!" ));
		locals[1] = 36;
		locals[2] = 37;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			locals[23] = 1;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			break;
			
		case 2:
			
			locals[24] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[24] );
			yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0666() {
		
		//int locals[23];
		int [] locals =new int[24];
		
		yield return StartCoroutine(say( "Urgo sorr. Urgo sorra zekka, thes'click Thepa.  Thepa yethe Urgo." ));
		locals[1] = 39;
		locals[2] = 40;
		locals[3] = 41;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_06cb());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0730());
			break;
			
		case 3:
			
			locals[23] = 1;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_06cb() {
		
		//int locals[23];
		int [] locals =new int[24];
		
		yield return StartCoroutine(say( "Tosa sel'a zekka isili - isili sel'a Urgo tosa." ));
		locals[1] = 43;
		locals[2] = 44;
		locals[3] = 45;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_080d());
			break;
			
		case 2:
			
			locals[23] = 1;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			break;
			
		case 3:
			
			yield return StartCoroutine(func_0959());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0730() {
		
		//int locals[22];
		int [] locals =new int[23];
		
		yield return StartCoroutine(say( "Isili thesh tosa.  Tosa thesh yethe Urgo?" ));
		locals[1] = 47;
		locals[2] = 48;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0778());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_06cb());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0778() {
		
		//int locals[25];
		int [] locals =new int[26];
		
		yield return StartCoroutine(say( "Tosa yethe sorr Urgo, tosa eppa Isili." ));
		privateVariables[3] = 1;
		locals[1] = 50;
		locals[2] = 51;
		locals[3] = 52;
		locals[4] = 53;
		locals[5] = 0;
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
			break;
			
		case 2:
			
			locals[24] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[24] );
			yield break;
			break;
			
		case 3:
			
			locals[25] = 1;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[25] );
			yield break;
			break;
			
		case 4:
			
			yield return StartCoroutine(func_080d());
			privateVariables[3] = 0;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_080d() {
		
		//int locals[24];
		int [] locals =new int[25];
		
		yield return StartCoroutine(say( "Tosa yeshor'click.  Tosa eppa isili, sel'a isili zekka, isili sstresh Urgo." ));
		privateVariables[2] = 1;
		privateVariables[3] = 0;
		locals[1] = 55;
		locals[2] = 56;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			locals[23] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			break;
			
		case 2:
			
			locals[24] = 1;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[24] );
			yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0871() {
		
		//int locals[47];
		int [] locals =new int[48];
		
		yield return StartCoroutine(say( "Tosa sel'a zekka?" ));
		locals[1] = 58;
		locals[2] = 59;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0959());
			break;
			
		case 2:
			
			locals[23] = 1;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			break;
			
		} // end switch
		
		locals[24] = 60;
		locals[25] = 61;
		locals[26] = 0;
		//locals[45] = babl_menu( 0, locals[24] );
		yield return StartCoroutine(babl_menu (0,locals,24));
		locals[45] = PlayerAnswer;
		switch ( locals[45] ) {
			
		case 1:
			
			locals[46] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[46] );
			yield break;
			break;
			
		case 2:
			
			locals[47] = 1;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[47] );
			yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0911() {
		
		//int locals[22];
		int [] locals =new int[23];
		
		yield return StartCoroutine(say( "Tosa yethe Urgo?" ));
		locals[1] = 63;
		locals[2] = 64;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_080d());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0ab8());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0959() {
		
		//int locals[69];
		int [] locals =new int[70];
		
	label_095e:;
		
		//locals[16] = show_inv( 2, locals[6], locals[1] );
		locals[16] = show_inv (2,locals, 6, 1);
		locals[18] = 0;
		locals[19] = 0;
		int counter =0;
		while ( locals[16] != 0 ) {
			
			//locals[17] = locals[0];
			locals[17] = locals[1+counter]; //Get the next item id in the list of found items
			if ( ((((((locals[17] == 176 || locals[17] == 177) || locals[17] == 178) || locals[17] == 179) || locals[17] == 180) || locals[17] == 181) || locals[17] == 182) ) {
				
				locals[18] = locals[18] + count_inv( 1, locals[6+counter] );
				locals[19] = locals[19] + 1;
				//locals[10] = locals[5];
				locals[10+counter] = locals[6+counter];//Copy the item positions.
			} // end if
			
			locals[16] = locals[16] - 1;
			counter++;
		} // while
		
		if ( locals[18] > 4 ) {
			
			//give_to_npc( 2, locals[11], locals[19] );
			give_to_npc(2,locals,10,locals[19]);
			locals[20] = 27;
			locals[21] = 22;
			locals[22] = 0;
			gronk_door( 3, locals[22], locals[21], locals[20] );
			locals[23] = 0;
			locals[24] = 1;
			set_quest( 2, locals[24], locals[23] );
			yield return StartCoroutine(say( "Isili thesh tosa! Tosa yeshor'click! Tosa eppa isili!" ));
			locals[25] = 66;
			locals[26] = 0;
			//locals[46] = babl_menu( 0, locals[25] );
			yield return StartCoroutine(babl_menu (0,locals,25));
			locals[46] = PlayerAnswer;
			if ( locals[46] == 1 ) {
				
			} // end if
			
			locals[47] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[47] );
			yield break;
		} else {
			
			yield return StartCoroutine(say( "Tosa 'click sel'a ossli. Isili 'click sstresh Urgo." ));
			locals[48] = 68;
			locals[49] = 69;
			locals[50] = 0;
			//locals[69] = babl_menu( 0, locals[48] );
			yield return StartCoroutine(babl_menu (0,locals,48));
			locals[69] = PlayerAnswer;
			switch ( locals[69] ) {
				
			case 1:
				
				break;
				
			case 2:
				
				goto label_095e;
				
				break;
				
			} // end switch
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( 21 );
			yield break;
		} // end if
		
	} // end func
	
	IEnumerator func_0ab8() {
		
		//int locals[5];
		int [] locals =new int[6];
		
		locals[1] = get_quest( 1, locals[2] );
		locals[2] = 6;
		if ( locals[1] == 1 ) {
			
			locals[3] = 3;
			set_race_attitude( 1, locals[3] );
			yield return StartCoroutine(say( "Tosa yeshor'click! Tosa thes'click sorr! Tosa eppa isili!" ));
			locals[4] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[4] );
			yield break;
		} else {
			
			yield return StartCoroutine(say( "Tosa sorr.  Isili 'click sstresh tosa." ));
			locals[5] = 1;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[5] );
			yield break;
		} // end if
		
	} // end func
	
	IEnumerator func_0b03() {
		
		//int locals[26];
		int [] locals =new int[27];
		
		yield return StartCoroutine(say( "Tosa yeshor'click.  Eppa Ishtass sstresh." ));
		locals[2] = 73;
		locals[3] = 74;
		locals[4] = 0;
		//locals[23] = babl_menu( 0, locals[2] );
		yield return StartCoroutine(babl_menu (0,locals,2));
		locals[23] = PlayerAnswer;
		switch ( locals[23] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( 21 );
			yield break;
			break;
			
		case 2:
			
			break;
			
		} // end switch
		
		//locals[1] = babl_ask( 0 );
		yield return StartCoroutine( babl_ask( 0 ));
		locals[24] = 75;
		//if ( contains( 2, locals[1], locals[24] ) ) {
		if ( contains( 2, PlayerTypedAnswer, locals[24] ) == 1 ) {
			
			yield return StartCoroutine(say( "Sel'a tosa sstresh.  Yisa Toosa." ));
			locals[25] = 77;
			yield return StartCoroutine(print( 1, locals[25] ));
		} else {
			
			locals[26] = 78;
			//if ( contains( 2, locals[1], locals[26] ) ) {
			if ( contains( 2, PlayerTypedAnswer, locals[26] ) == 1 ) {
				yield return StartCoroutine(say( "Tosa sstresh Urgo." ));
			} else {
				
				yield return StartCoroutine(say( "Isili 'click sstresh." ));
			} // end if
			
		} // end if
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( 21 );
		yield break;
	} // end func
	
	IEnumerator func_0b9d() {
		
		//int locals[22];
		int [] locals =new int[23];
		
		if ( func_0020() == 0) {
			
		} else {
			
			yield return StartCoroutine(say( "Sel'a?" ));
			locals[1] = 82;
			locals[2] = 83;
			locals[3] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_0bed());
				break;
				
			case 2:
				yield break;
				//return;
				break;
			} // end if
			

			
		} // end switch
		
	} // end func
	
	IEnumerator func_0bed() {
		
		//int locals[44];
		int [] locals =new int[45];
		
		setup_to_barter( 0 );
		while ( privateVariables[1] == 0 ) {
			
			locals[1] = 84;
			locals[2] = 85;
			locals[3] = 86;
			locals[4] = 87;
			locals[5] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_0c9e());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_0ce0());
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
		
		locals[23] = 88;
		locals[24] = 0;
		//locals[44] = babl_menu( 0, locals[23] );
		yield return StartCoroutine(babl_menu (0,locals,23));
		locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_0c9e() {
		
		//int locals[5];
		int [] locals =new int[6];
		
		locals[1] = 89;
		locals[2] = 90;
		locals[3] = 91;
		locals[4] = 92;
		locals[5] = 93;
		//if ( do_offer( 5, locals[5], locals[4], locals[3], locals[2], locals[1] ) ) {
		yield return StartCoroutine (do_offer( 5, locals[5], locals[4], locals[3], locals[2], locals[1], 0,0) );
		if (PlayerAnswer==1)	{

			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_0ce0() {
		
		//int locals[24];
		int [] locals =new int[25];
		
		yield return StartCoroutine(say( "sorr?" ));
		locals[1] = 95;
		locals[2] = 96;
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
			break;
			
		} // end switch
		
		locals[23] = 97;
		locals[24] = 98;
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
