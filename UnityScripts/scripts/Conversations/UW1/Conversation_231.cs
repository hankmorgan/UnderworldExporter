using UnityEngine;
using System.Collections;

public class Conversation_231 : Conversation {
	
	//conversation #231
	//	string block 0x0ee7, name Tyball
	
	public override bool OnDeath ()
	{
		//Play the tybal death cutscene.
		GameWorldController.instance.playerUW.quest().isTybalDead=true;
		GameWorldController.instance.playerUW.quest().GaramonDream=8;//Advance to Tybal is dead range of dreams
		GameWorldController.instance.playerUW.quest().DayGaramonDream=GameClock.day;//Ensure dream triggers on next sleep
		GameWorldController.instance.playerUW.PlayerMagic.CastEnchantment(this.gameObject,null,226,Magic.SpellRule_TargetSelf);

		return false;
	}
	
	public override IEnumerator main() {
		SetupConversation (3815);
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
	
	void func_00b1() {
		
		npc.npc_attitude = param1[0]play_hunger;
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
		
		int[] locals = new int[48];
		
		locals[2] = 1;
		locals[3] = 2;
		locals[1] = sex( 2, locals[3], locals[2] );
		
		if ( privateVariables[0]==1 ) {
			yield return StartCoroutine(say( locals, 012 ));
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
		} else {
			
			yield return StartCoroutine(say( locals, 003 ));
			locals[4] = 4;
			locals[5] = 5;
			locals[6] = 0;
			//locals[25] = babl_menu( 0, locals[4] );
			yield return StartCoroutine (babl_menu(0,locals,4));
			locals[25]=PlayerAnswer;
			switch ( locals[25] ) {
				
			case 1:
				
				goto label_0304;

			case 2:
				
				goto label_0309;

			} // end switch
			
		label_0304:;
			
			yield return StartCoroutine(say( locals, 006 ));
			goto label_030e;
			
		label_0309:;
			
			yield return StartCoroutine(say( locals, 007 ));
			goto label_030e;
			
		label_030e:;
			
			locals[26] = 8;
			locals[27] = 10;
			locals[28] = 0;
			//locals[47] = babl_menu( 0, locals[26] );
			yield return StartCoroutine (babl_menu(0,locals,26));
			locals[47]=PlayerAnswer;
			switch ( locals[47] ) {
				
			case 1:
				
				yield return StartCoroutine(say( locals, 009 ));
				break;
				
			case 2:
				
				yield return StartCoroutine(say( locals, 011 ));
				break;
				
			} // end switch
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
		} // end if
		
		
	} // end func
	
	
	
}
