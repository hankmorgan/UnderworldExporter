using UnityEngine;
using System.Collections;

public class Conversation_66 : Conversation {
	
	/*conversation #66
		string block 0x0e42, name Drog*/
	
	public override IEnumerator main() {
		SetupConversation (3650);
		//StringNo = 3650;
		//tl.Clear();
		//ConversationOpen=true;
		//InConversation=true;
		//this.GetComponent<NPC>().state= NPC.AI_STATE_STANDING;
		privateVariables[1] = 0;
		yield return StartCoroutine(func_029d());
		func_0012();
		//this.GetComponent<NPC>().state=  NPC.AI_STATE_STANDING;
		yield return 0;
	} // end func
	
	
	void func_0012() {
		EndConversation();
		privateVariables[0] = 1;
	} // end func
	
	/*	void func_0020() {
		
		int locals[1];
		
		if ( (((npc_goal == 5 || npc_goal == 6) || npc_goal == 9) && npc_gtarg == 1 || npc_attitude == 0) ) {
			
			locals[1] = 0;
		} else {
			
			locals[1] = 1;
		} // end if
		
		return locals[1];
	} // end func
	*/
	
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
	
	void func_00b1(int param1) {
		
		npc.npc_attitude = param1;//[0];//play_hunger;
		func_0012();
	} // end func
	
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
	
	/*	void func_0106() {
		
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
	} // end func
	*/
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
		int[] locals=new int[53];
		//int locals[52];
		
		if ( privateVariables[0]==1 ) {
			
		} else {
			
			yield return StartCoroutine( say( locals, 001 ));
			locals[1] = 2;
			locals[2] = 3;
			locals[3] = 4;
			locals[4] = 0;
			//locals[22] = babl_menu( 0, &locals[1] );
			yield return StartCoroutine( babl_menu( 0,locals,1 ));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				goto label_02fd;
				
				break;
				
			case 2:
				
				goto label_030b;
				
				break;
				
			case 3:
				
				goto label_030b;
				
				break;
				
			} // end switch
			
		label_02fd:;
			
			yield return StartCoroutine( say( locals, 005 ));
			locals[23] = 1;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;//?
		label_030b:;
			
			//label_030b:;
			
			yield return StartCoroutine( say( locals, 006 ));
			if ( npc.npc_attitude < 2 ) {
				
				say( locals, 007 );
			} // end if
			
			locals[24] = 15;
			locals[25] = 34;
			locals[26] = 0;
			gronk_door( 3, locals[26], locals[25],locals[24] );
			locals[27] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[27] );
			yield break;
		} // end if
		
		yield return StartCoroutine( say( locals, 008 ));
		locals[28] = 9;
		locals[29] = 10;
		locals[30] = 0;
		//locals[49] = babl_menu( 0, &locals[28] );
		yield return StartCoroutine( babl_menu( 0,locals,28 ));
		locals[49] = PlayerAnswer;
		switch ( locals[49] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
			break;
			
		case 2:
			
			goto label_0384;
			
			break;
			
		} // end switch
		
	label_0384:;
		
		yield return StartCoroutine( say( locals, 011 ));
		locals[50] = 15;
		locals[51] = 34;
		locals[52] = 0;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		gronk_door( 3, locals[52], locals[51], locals[50] );
		func_00e0();
		yield break;
	} // end func
}
