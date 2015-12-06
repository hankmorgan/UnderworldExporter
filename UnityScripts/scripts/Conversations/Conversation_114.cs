using UnityEngine;
using System.Collections;

public class Conversation_114 : Conversation {
	
	//conversation #114
	//	string block 0x0e72, name Iss'leek
	
	public override IEnumerator main() {
		SetupConversation (3698);
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
		
		npc.npc_attitude =param1;// param1[0];//play_hunger;
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
		int[] locals =new int[5];

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
		int[] locals =new int[24];
		
		if ( privateVariables[0] == 0) {
			
			privateVariables[2] = 0;
		} // end if
		
		if ( privateVariables[0] == 1 ) {
			
			if ( privateVariables[2] == 0 ) {
				
				yield return StartCoroutine(func_0315());
			} else {
				
				yield return StartCoroutine(func_045b());
			} // end if
			
		} else {
			
			yield return StartCoroutine(say( "Bica. Tosa yeshor'click?" ));
			locals[1] = 2;
			locals[2] = 3;
			locals[3] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_03a7());
				break;
				
			case 2:
				
				locals[23] = npc.npc_attitude - 1;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[23] );
				yield break;
				break;
			} // end if
			

			
		} // end switch
		
	} // end func
	
	IEnumerator func_0315() {
		
		//int locals[45];
		int[] locals =new int[46];
		
		yield return StartCoroutine(say( "Bica.  Tosa sorr.  Isili yethe tosa?" ));
		locals[1] = 5;
		locals[2] = 6;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			locals[23] = 0;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			break;
			
		case 2:
			
			break;
			
		} // end switch
		
		yield return StartCoroutine(say( "Tosa sor'click.  Tosa sstresh isili?" ));
		locals[24] = 8;
		locals[25] = 9;
		locals[26] = 0;
		//locals[45] = babl_menu( 0, locals[24] );
		yield return StartCoroutine(babl_menu (0,locals,24));
		locals[45] = PlayerAnswer;
		switch ( locals[45] ) {
			
		case 1:
			
			yield return StartCoroutine(func_03a7());
			break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( 21 );
			yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03a7() {
		
		//int locals[24];
		int[] locals =new int[25];
		
		yield return StartCoroutine(say( "Isili sel'a tosa sstresh." ));
		locals[2] = 11;
		yield return StartCoroutine(print( 1, locals[2] ));
		privateVariables[2] = 1;
		locals[3] = 12;
		locals[4] = 13;
		locals[5] = 14;
		locals[6] = 0;
		//locals[24] = babl_menu( 0, locals[3] );
		yield return StartCoroutine(babl_menu (0,locals,3));
		locals[24] = PlayerAnswer;
		switch ( locals[24] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0419());
			break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( 21 );
			yield break;
			break;
			
		case 3:
			
			yield return StartCoroutine(func_04ba());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0419() {
		
		//int locals[23];
		int[] locals =new int[24];
		
		yield return StartCoroutine(say( "Tosa yeshor'click.  Isili thesh tosa!" ));
		privateVariables[2] = 2;
		locals[1] = 16;
		locals[2] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		if ( locals[22] == 1 ) {
			
		} // end if
		
		locals[23] = 3;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[23] );
		yield break ;
	} // end func
	
	IEnumerator func_045b() {
		
		//int locals[22];
		int[] locals =new int[23];
		
		if ( privateVariables[2] == 1 ) {
			
			yield return StartCoroutine(func_057e());
		} // end if
		
		if ( privateVariables[2] == 3 ) {
			
			yield return StartCoroutine(func_05c9());
		} // end if
		
		yield return StartCoroutine(say( "Bica, yeshor'click.  Tosa sel'a isila sstresh?" ));
		locals[1] = 18;
		locals[2] = 19;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( 21 );
			yield break;
			break;
			
		} // end switch
		
		//yield return StartCoroutine(func_04ba());
	} // end func
	
	IEnumerator func_04ba() {
		
		//int locals[58];
		int[] locals =new int[59];
		int counter=0;
		//int noOfRubies=0;
		//locals[11] = show_inv( 2, locals[1], locals[6] );
		locals[11] = show_inv (2,locals, 1, 6);
		locals[0]=-1;
		while ( locals[11] != 0 ) {
			
			if ( locals[6+counter] == 162 ) {
				locals[0]=locals[1+counter];//Copy the item position of the last found ruby to the locals.
			}// else {

			//} // while
			counter++;
			locals[11] = locals[11] - 1;
		} // end if
			
		if (locals[0] == -1)
		{
			yield return StartCoroutine(say( "Tosa 'click sel'a sstresh.  Bica." ));
			locals[12] = 21;
			locals[13] = 0;
			//locals[33] = babl_menu( 0, locals[12] );
			yield return StartCoroutine(babl_menu (0,locals,12));
			locals[33] = PlayerAnswer;
			if ( locals[33] == 1 ) {
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( 21 );
				yield break;
			} // end if
		}	
		
		
		privateVariables[2] = 3;
		locals[34] = 1;
		give_ptr_npc( 2, locals[34], locals[0] );
		locals[35] = 1019;
		take_from_npc( 1, locals[35] );
		yield return StartCoroutine(say( "Tosa yeshor'click!" ));
		locals[36] = 23;
		locals[37] = 0;
		//locals[57] = babl_menu( 0, locals[36] );
		yield return StartCoroutine(babl_menu (0,locals,36));
		locals[57] = PlayerAnswer;
		if ( locals[57] == 1 ) {
			
			locals[58] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[58] );
			yield break;
		} // end if
		
	} // end func
	
	IEnumerator func_057e() {
		
		//int locals[22];
		int[] locals =new int[23];
		
		yield return StartCoroutine(say( "Tosa sel'a sstresh?" ));
		locals[1] = 25;
		locals[2] = 26;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( 21 );
			yield break;
			break;
			
		} // end switch
		
		yield return StartCoroutine(func_0419());
	} // end func
	
	IEnumerator func_05c9() {
		
		//int locals[44];
		int[] locals =new int[45];
		
		yield return StartCoroutine(say( "Bica.  Tosa Iss'leek yeshor'click.  Isili thesh tosa." ));
		locals[1] = 28;
		locals[2] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		if ( locals[22] == 1 ) {
			
		} // end if
		
		yield return StartCoroutine(say( "'Click thit sstresh. Bica." ));
		locals[23] = 30;
		locals[24] = 0;
		//locals[44] = babl_menu( 0, locals[23] );
		yield return StartCoroutine(babl_menu (0,locals,23));
		locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( 21 );
			yield break;
		} // end if
		
	} // end func
	
	
}
