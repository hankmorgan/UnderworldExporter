using UnityEngine;
using System.Collections;

public class Conversation_142 : Conversation {
	
	//conversation #142
	//string block 0x0e8e, name Rodrick
	
	public override bool OnDeath ()
	{//When rodrick dies he will set a quest flag for dorna ironfist
		base.OnDeath ();
		set_quest(0,1,11);
		return false;
	}
	
	public override IEnumerator main() {
		SetupConversation (3726);
		privateVariables[1] = 0;
		yield return StartCoroutine(func_029d());
		func_0012();
		yield return 0;
	} // end func
	
	void func_0012() {
		EndConversation();
		privateVariables[0] = 1;
	} // end func
	/*	
	void func_0020() {
		
		int locals[1];
		
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
	} // end func*/
	
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
		
		//int locals[1];
		int [] locals = new int[2];
		
		if ( npc.npc_goal == 11 ) {
			
			npc.npc_goal = 5;
		} // end if
		
		if ( privateVariables[2] > 8 ) {
			
			func_0352();
		} else {
			
			locals[1] = privateVariables[2];
			if ( 0 == locals[1] ) {
				
				yield return StartCoroutine(say( locals, 001 ));
			} else {
				
				if ( 1 == locals[1] ) {
					
					yield return StartCoroutine(say( locals, 002 ));
				} else {
					
					if ( 2 == locals[1] ) {
						
						yield return StartCoroutine(say( locals, 003 ));
					} else {
						
						if ( 3 == locals[1] ) {
							
							yield return StartCoroutine(say( locals, 004 ));
						} else {
							
							if ( 4 == locals[1] ) {
								
								yield return StartCoroutine(say( locals, 005 ));
							} else {
								
								if ( 5 == locals[1] ) {
									
									yield return StartCoroutine(say( locals, 006 ));
								} else {
									
									if ( 6 == locals[1] ) {
										
										yield return StartCoroutine(say( locals, 007 ));
									} else {
										
										if ( 7 == locals[1] ) {
											
											yield return StartCoroutine(say( locals, 008 ));
										} else {
											
											if ( 8 == locals[1] ) {
												
												yield return StartCoroutine(say( locals, 009 ));
											} else {
												
												if ( 9 == locals[1] ) {
													
													yield return StartCoroutine(say( locals, 010 ));
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
			
			privateVariables[2] = privateVariables[2] + 1;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_008b();
			yield break;
		} // end if
		
	} // end func
	
	IEnumerator func_0352() {
		int[] locals = new int[1];
		say( locals, 011 );
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_008b();
		yield break;
	} // end func
	
}
