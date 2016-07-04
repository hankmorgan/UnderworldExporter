using UnityEngine;
using System.Collections;

public class Conversation_67 : Conversation {
	
	
	//BRAGIT
	//String No 3651
	
	// Use this for initialization
	//void Start () {
	
	//}
	
	
	
	// Update is called once per frame
	//void Update () {
	
	//}
	
	
	public override IEnumerator main() {
		SetupConversation (3651);
		//StringNo = 3651;
		//tl.Clear();
		//ConversationOpen=true;
		//InConversation=true;
		//this.GetComponent<NPC>().state= NPC.AI_STATE_STANDING;
		//tl.textLabel.lineHeight=340;//TODO:Get rid of this!
		//tl.textLabel.lineWidth=480;
		privateVariables[1] = 0;
		yield return StartCoroutine(func_029d());
		func_0012();
		//this.GetComponent<NPC>().state= NPC.AI_STATE_IDLERANDOM;
		yield return 0;
	} // end func
	
	void func_0012() {
		EndConversation();
		privateVariables[0] = 1;
	} // end func
	/*
	void func_0020() {
		
		int[] locals=new int[1];
		
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
	
	void func_00b1(int[] paramArray, int Start) {
		
		npc.npc_attitude =paramArray[Start];//play_hunger;
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
	/*
	void func_0106() {
		
		int[] locals =new int[4];
		
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
	/*
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
	*/
	/*void func_0243() {
		
		param1[1] = game_days - param2[1];
		param1[2] = game_mins - param2[2];
		if ( param1[2] < 0 ) {
			
			param1[2] = param1[2] + 1440;
			param1[1] = param1[1] - 1;
		} // end if
		
	} // end func*/
	
	IEnumerator func_029d() {
		
		int[] locals=new int[278];
		locals[2] = 1;
		locals[3] = 2;		
		locals[1] = sex( 2, locals[3], locals[2] );
		
		if ( privateVariables[0] == 1) {
			
		} else {
			
			privateVariables[2] = 0;
			privateVariables[3] = 0;
			yield return StartCoroutine( say( locals, 003 ));
			locals[4] = 4;
			locals[5] = 5;
			locals[6] = 6;
			locals[7] = 0;
			yield return StartCoroutine( babl_menu( 0,locals,4 ));
			locals[25] = PlayerAnswer;
			switch ( locals[25] ) {
				
			case 1:
				
				goto label_0322;
	
			case 2:
				
				goto label_0327;
	
			case 3:
				
				goto label_032c;

			} // end switch
			
		label_0322:;
			
			yield return StartCoroutine(say( locals, 007 ));
			goto label_0331;
			
		label_0327:;
			
			yield return StartCoroutine(say( locals, 008 ));
			goto label_0331;
			
		label_032c:;
			
			yield return StartCoroutine(say( locals, 009 ));
			goto label_0331;
			
		label_0331:;
			
			yield return StartCoroutine(say( locals, 010 ));
			locals[26] = 11;
			locals[27] = 12;
			locals[28] = 0;
			yield return StartCoroutine(babl_menu( 0, locals,26 ));
			locals[47] = PlayerAnswer;
			switch ( locals[47] ) {
				
			case 1:
				
				goto label_03ba;
				
			case 2:
				
				goto label_0371;

			} // end switch
			
		label_0371:;
			
			yield return StartCoroutine(say( locals, 013 ));
			locals[48] = 14;
			locals[49] = 15;
			locals[50] = 0;
			yield return StartCoroutine(babl_menu( 0, locals, 48 ));
			locals[69] = PlayerAnswer;
			switch ( locals[69] ) {
				
			case 1:
				
				goto label_03ba;

			case 2:
				
				locals[70] = 2;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals,70 );
				yield break;
				
			} // end switch
			
			
		label_03ba:;
			
			privateVariables[2] = 1;
			yield return StartCoroutine(say( locals, 016 ));
			locals[71] = 17;
			locals[72] = 18;
			locals[73] = 0;
			yield return StartCoroutine(babl_menu( 0, locals,71 ));
			locals[92] = PlayerAnswer;
			switch ( locals[92] ) {
				
			case 1:
				
				goto label_0404;
	
				
			case 2:
				
				goto label_03ff;
	
			} // end switch
			
		label_03ff:;
			
			yield return StartCoroutine(say( locals, 019 ));
			goto label_0404;
			
		label_0404:;
			
			yield return StartCoroutine(say( locals, 020 ));
			locals[93] = 21;
			locals[94] = 22;
			locals[95] = 0;
			yield return StartCoroutine( babl_menu( 0, locals,93 ));
			locals[114] = PlayerAnswer;
			switch ( locals[114] ) {
				
			case 1:
				
				break;
				
			case 2:
				
				break;
				
			} // end switch
			
			yield return StartCoroutine(say( locals, 023 ));
			locals[115] = 24;
			locals[116] = 25;
			locals[117] = 0;
			yield return StartCoroutine( babl_menu( 0, locals,115 ) );
			locals[136] = PlayerAnswer;
			switch ( locals[136] ) {
				
			case 1:
				
				break;
				
			case 2:
				
				break;
				
			} // end switch
			
			yield return StartCoroutine(say( locals, 026 ));
			locals[137] = 27;
			locals[138] = 28;
			locals[139] = 0;
			yield return StartCoroutine( babl_menu( 0, locals,137 ) );
			locals[158] = PlayerAnswer;
			switch ( locals[158] ) {
				
			case 1:
				
				goto label_04c1;

			case 2:
				
				goto label_04bc;

			} // end switch
			
		label_04bc:;
			
			yield return StartCoroutine(say( locals, 029 ));
			goto label_04c1;
			
		label_04c1:;
			
			yield return StartCoroutine(say( locals, 030 ));
			locals[159] = 31;
			locals[160] = 32;
			locals[161] = 0;
			yield return StartCoroutine( babl_menu( 0, locals,159 ));
			locals[180] = PlayerAnswer;
			switch ( locals[180] ) {
				
			case 1:
				
				break;
				
			case 2:
				
				break;
				
			} // end switch
			
			yield return StartCoroutine(say( locals, 033 ));
			locals[181] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals,181 );
			yield break;
		} // end if
		
		if ( privateVariables[2]==1 ) {
			
		} else {
			
			goto label_0516;
			
		label_0516:;
			
			yield return StartCoroutine(say( locals, 034 ));
			locals[182] = 35;
			locals[183] = 36;
			locals[184] = 0;
			yield return StartCoroutine( babl_menu( 0, locals,182 ));
			locals[203] = PlayerAnswer;
			switch ( locals[203] ) {
				
			case 1:
				
				locals[204] = 1;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals,204 );
				yield break;

			case 2:
				
				goto label_03ba;
		
				
			} // end if
			
			//Test 
			//break;
		label_03ba:;
			
			privateVariables[2] = 1;
			yield return StartCoroutine(say( locals, 016 ));
			locals[71] = 17;
			locals[72] = 18;
			locals[73] = 0;
			yield return StartCoroutine( babl_menu( 0, locals,71 ) );
			locals[92] = PlayerAnswer;
			switch ( locals[92] ) {
				
			case 1:
				
				goto label_0404;

			case 2:
				
				goto label_03ff;

			} // end switch
			//end test
			
		label_03ff:;
			
			yield return StartCoroutine(say( locals, 019 ));
			goto label_0404;
			
		label_0404:;
			
			yield return StartCoroutine(say( locals, 020 ));
			locals[93] = 21;
			locals[94] = 22;
			locals[95] = 0;
			yield return StartCoroutine ( babl_menu( 0, locals,93 ));
			locals[114] = PlayerAnswer;
			switch ( locals[114] ) {
				
			case 1:
				
				break;
				
			case 2:
				
				break;
				
			} // end switch
			
			
			
			
		} // end switch
		
		if ( privateVariables[3] ==1) {
			
		} else {
			
			yield return StartCoroutine(say( locals, 037 ));
			locals[205] = 38;
			locals[206] = 39;
			locals[207] = 40;
			locals[208] = 0;
			yield return StartCoroutine( babl_menu( 0, locals,205 ));
			locals[226]=PlayerAnswer;
			switch ( locals[226] ) {
				
			case 1:
				
				goto label_05ba;

			case 2:
				
				goto label_05c8;

			case 3:
				
				goto label_05d6;

				
			} // end switch
			
		label_05ba:;
			
			yield return StartCoroutine(say( locals, 041 ));
			locals[227] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals,227 );
			yield break;
		label_05c8:;
			
			yield return StartCoroutine(say( locals, 042 ));
			locals[228] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals,228 );
			yield break;
		label_05d6:;
			
			privateVariables[3] = 1;
			yield return StartCoroutine(say( locals, 043 ));
			locals[229] = 44;
			locals[230] = 45;
			locals[231] = 0;
			yield return StartCoroutine( babl_menu( 0, locals,229 ) );
			locals[250] = PlayerAnswer;
			switch ( locals[250] ) {
				
			case 1:
				
				locals[251] = 3;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals,251 );
				yield break;
				
			case 2:
				
				locals[252] = 2;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals,252 );
				yield break;
			} // end if
			
			//break;
			
		} // end switch
		
		yield return StartCoroutine(say( locals, 046 ));
		locals[253] = 47;
		locals[254] = 48;
		locals[255] = 49;
		locals[256] = 0;
		yield return StartCoroutine (babl_menu( 0, locals,253 ));
		locals[274] = PlayerAnswer;
		switch ( locals[274] ) {
			
		case 1:
			
			locals[275] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals,275 );
			yield break;
			
		case 2:
			
			locals[276] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals,276 );
			yield break;
			
		case 3:
			
			locals[277] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals,277 );
			yield break;
			
		} // end switch
		
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		yield break;	
		
	} // end func
	
	
	
	
}



/*using UnityEngine;
using System.Collections;

public class Conversation_67 : Conversation {

	// Use this for initialization
	//void Start () {
	
	//}



	// Update is called once per frame
	void Update () {
	
	}


	public override IEnumerator  main() {
		tl.Clear();
		Debug.Log ("main");
		tl.textLabel.lineHeight=340;
		tl.textLabel.lineWidth=480;
		privateVariables[1] = 0;
		yield return StartCoroutine(func_029d());
		//func_0012();
		Debug.Log ("finised 029d");
		yield return 0;
	} // end func
	

	IEnumerator func_029d() {
		Debug.Log ("Func_029d");
		int[] locals=new int[277];

		privateVariables[2] = 0;
		privateVariables[3] = 0;
		say( locals, 003 );
		locals[4] = 4;
		locals[5] = 5;
		locals[6] = 6;
		locals[7] = 0;

		yield return StartCoroutine(babl_menu (0,locals,4));
		Debug.Log ("back from coroutine");
		locals[25] = PlayerAnswer; //babl_menu( 0,locals,4 );
		switch ( locals[25] ) {
		
		case 0:
			say ("answer 1");break;
		case 1:
			say ("answer 2");break;
		case 2:
			say ("answer 3");break;
		default:
			say ("no anwser!");break;
		}
	}



}
*/