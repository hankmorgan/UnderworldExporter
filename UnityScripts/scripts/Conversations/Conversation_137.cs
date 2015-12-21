using UnityEngine;
using System.Collections;

public class Conversation_137 : Conversation {

	//conversation #137
	//string block 0x0e89, name Linnet
			
	int func_0657_result;

	public override IEnumerator main() {
		SetupConversation (3721);
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
	
	/*void func_00b1() {
		
		npc.npc_attitude = param1[0]play_hunger;
		func_0012();
	} // end func*/
	
	/*void func_00c2() {
		
		npc.npc_attitude = 2;
		func_0012();
	} // end func*/
	
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
			
			func_0602();
			privateVariables[2] = 0;
			privateVariables[3] = 0;
		} // end if
		
		if ( privateVariables[0] == 1 ) {
			
			yield return StartCoroutine(func_0559());
		} else {
			
			yield return StartCoroutine(func_02c4());
		} // end if
		
	} // end func
	
	IEnumerator func_02c4() {
		
		//int locals[22];
		int [] locals=new int[23];
		
		yield return StartCoroutine(say( "Hail, stranger.  `Tis indeed a rare pleasure to encounter a new face amongst the denizens of the Abyss.  What hast brought thee hither?" ));
		locals[1] = 2;
		locals[2] = 3;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0319());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_030c());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_030c() {
		
		yield return StartCoroutine(say( "Suit thyself, friend.  `Tis thy business, not mine." ));
		yield return StartCoroutine(func_0657());
	} // end func
	
	IEnumerator func_0319() {
		
		//int locals[22];
		int[] locals=new int[23];
		
		yield return StartCoroutine(say( "A terrible crime, indeed.  I would fain believe thou art innocent of such, for thy face has honor in it. Thou dost wear it like few I have beheld in my many years in the Abyss.  May I help thee in any way?" ));
		locals[1] = 6;
		locals[2] = 7;
		locals[3] = 8;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0375());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_03bd());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_04ad());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0375() {
		
		//int locals[22];
		int[] locals =new int[23];
		
		yield return StartCoroutine(say( "Like thee, I was unjustly accused of killing a man.  I swear to thee I never struck him.  I merely held him down whilst my brother kicked him.  He should not have treated our sister as he did.  And only a weak man could perish from such slight injuries." ));
		locals[1] = 10;
		locals[2] = 11;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_04ff());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_050c());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03bd() {
		
		//int locals[26];
		int[] locals=new int[27];
		
		if ( privateVariables[3] == 3 ) {
			
			yield return StartCoroutine(say( "I fear I canst tell thee nothing new." ));
			locals[1] = 1;
			while ( locals[1] <= 3 ) {
				
				//privateVariables[4][0] = 0;
				privateVariables[4] = 0;
				locals[1] = locals[1] + 1;
			} // while
			
		} else {
			locals[2] = 3;
			locals[1] = random( 1, locals[2] );

			//while ( privateVariables[4][0] == 1 ) {
			//while ( privateVariables[4] == 1 ) {
				locals[3] = 3;
				locals[1] = random( 1, locals[3] );
				
			//} // while this loop is infinite!
			
			privateVariables[3] = privateVariables[3] + 1;
			locals[4] = locals[1];
			if ( 1 == locals[4] ) {
				
				yield return StartCoroutine(say( "It is said the trolls have captured a new dweller in the Abyss./m" ));
			} else {
				
				if ( 2 == locals[4] ) {
					
					yield return StartCoroutine(say( "I have heard there is to be a human sacrifice in Cabirus' old quarters on the lowest level./m" ));
				} else {
					
					if ( 3 == locals[4] ) {
						
						yield return StartCoroutine(say( "A Knight told me that a maiden's body had been found in the lower levels./m" ));
					} // end if
					
				} // end if
				
			} // end if
			
			if ( privateVariables[2] == 1 ) {
				
				yield return StartCoroutine(say( "In their search for some new advantage over the trolls, the  Knights explore more widely than I.  Mayhap they can tell thee more. \n"
				    +" Still, be careful, lest thou become the next casualty in their senseless battle with the trolls." ));
				yield return StartCoroutine(func_0657());
			} else {
				
				yield return StartCoroutine(say( "It may be the Knights can tell thee something, for they travel more of the Abyss than I." ));
				locals[5] = 18;
				locals[6] = 19;
				locals[7] = 0;
				//locals[26] = babl_menu( 0, locals[5] );
				yield return StartCoroutine(babl_menu (0,locals,5));
				locals[26] = PlayerAnswer;
				switch ( locals[26] ) {
					
				case 1:
					
					yield return StartCoroutine(func_04ad());
					break;
					
				case 2:
					
					yield return StartCoroutine(func_0657());
					break;
				} // end if
				
			} // end if
			

			
		} // end switch
		
	} // end func
	
	IEnumerator func_04ad() {
		
		//int locals[22];
		int[] locals=new int[23];
		
		yield return StartCoroutine(say( "There is much tension on this level of the Abyss.  The Knights inhabit the western area, and a pack of Trolls live in the eastern reaches. \n"
		   + " Even while Sir Cabirus was alive, there was an uneasy peace between them.  After Cabirus' death, there was some strife, as each group attempted to gain power over the other, but these days there is relative peace./m" ));
		yield return StartCoroutine(say( "Perhaps the greatest danger in this area now is Rodrick, known as the Chaos Knight.  He lives by the old banquet hall to the north.  He is the foe of both the Knights and the Trolls, but neither has been able to defeat him yet. I hear that Dorna Ironfist has put a price upon his head." ));
		privateVariables[2] = 1;
		locals[1] = 22;
		locals[2] = 23;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0657());
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();//endconvo
			yield break;
			break;
			
		case 2:
			
			yield return StartCoroutine(func_03bd());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_04ff() {
		
		yield return StartCoroutine(say( "And methinks thou art a self-righteous ass, who wouldst be  well-suited in the company of the pompous Knights with their overweening morals.  Thy inflated ego wouldst find much company there." ));
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		//func_00d1();//Endconvo
		yield break;
	} // end func
	
	IEnumerator func_050c() {
		
		//int locals[22];
		int[]locals=new int[23];
		
		yield return StartCoroutine(say( "In sooth, thou speakest with a wisdom beyond thy years,  friend.  What I wouldst not give to teach that tyrant Almric a lesson about justice and honor!  I would deal him a buffeting that would leave his heirs dizzy for generations to come./m" ));
		yield return StartCoroutine(say( "Would I could aid thee more, friend, but I know little.  I have heard tell that a maiden is held captive near Cabirus's  quarters far below.  Perhaps the Knights could tell thee more." ));
		locals[1] = 27;
		locals[2] = 28;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_04ad());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0657());
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();//endconvo
			yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0559() {
		
		//int locals[44];
		int[] locals=new int[45];
		
		yield return StartCoroutine(say( "Well met, friend.  How dost thou in thy quest?" ));
		if ( privateVariables[2] == 0 ) {
			
			locals[1] = 30;
			locals[2] = 31;
			locals[3] = 33;
			locals[4] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_03bd());
				break;
				
			case 2:
				
				yield return StartCoroutine(say( "In sooth, I am sorry to hear thee  pronounce thy own death sentence.  Good luck, for thou wilt need it if you are  to have any hope of surviving below." ));
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00e0();//endconvo
				yield break;
				break;
				
			case 3:
				
				yield return StartCoroutine(func_04ad());
				break;
			} // end if
			
		} else {
			//Moved this block here.
			locals[23] = 34;
			locals[24] = 35;
			locals[25] = 0;
			//locals[44] = babl_menu( 0, locals[23] );
			yield return StartCoroutine(babl_menu (0,locals,23));
			locals[44] = PlayerAnswer;
			
			switch ( locals[44] ) {
				
			case 1:
				
				yield return StartCoroutine(func_03bd());
				break;
				
			case 2:
				
				yield return StartCoroutine(say( "In sooth, I am sorry to hear thee  pronounce thy own death sentence.  Good luck, for thou wilt need it  to have any hope of surviving below." ));
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				//func_00e0();//endconvo
				yield break;
				break;
				
			} // end switch
			
		} // end switch
		

		
	} // end func
	
	void func_0602() {
	/*	Figure this out!
		privateVariables[9][1] = 1011;
		privateVariables[9][2] = 1002;
		privateVariables[9][3] = 1003;
		privateVariables[9][4] = 1000;
		privateVariables[9][5] = -1;
		privateVariables[30][1] = 161;
		privateVariables[30][2] = 160;
		privateVariables[30][3] = -1;
		*/
		set_likes_dislikes( 2, 61, 40 );
	} // end func
	
	IEnumerator func_0657() {
		
		//int locals[22];
		int []locals=new int[23];
		
		yield return StartCoroutine(say( "Wouldst thou be interested in a trade?" ));
		locals[1] = 38;
		locals[2] = 39;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_06a4());
			break;
			
		case 2:
			
			goto label_069c;
			
			break;
			
		} // end switch
		
	label_069c:;
		func_0657_result= locals[1];
		yield break;
		//return locals[1];
	} // end func
	
	IEnumerator func_06a4() {
		
		//int locals[44];
		int[] locals=new int[45];
		
		setup_to_barter( 0 );
		while ( privateVariables[1] == 0 ) {
			
			locals[1] = 40;
			locals[2] = 41;
			locals[3] = 42;
			locals[4] = 43;
			locals[5] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_0755());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_0797());
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
		
		locals[23] = 44;
		locals[24] = 0;
		//locals[44] = babl_menu( 0, locals[23] );
		yield return StartCoroutine(babl_menu (0,locals,23));
		locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_0755() {
		
		//int locals[5];
		int [] locals=new int[6];
		
		locals[1] = 45;
		locals[2] = 46;
		locals[3] = 47;
		locals[4] = 48;
		locals[5] = 49;
		//if ( do_offer( 5, locals[5], locals[4], locals[3], locals[2], locals[1] ) ) {
		yield return StartCoroutine (do_offer( 5, locals[5], locals[4], locals[3], locals[2], locals[1], 0,0) );
		if (PlayerAnswer==1)	{	
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_0797() {
		
		//int locals[24];
		int[] locals=new int[25];
		
		yield return StartCoroutine(say( "Art thou attempting to intimidate me into surrendering my possessions?" ));
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
			yield break;
			//return;
			
			break;
			
		} // end switch
		
		locals[23] = 53;
		locals[24] = 54;
		//if ( do_demand( 2, locals[24], locals[23] ) ) {
		yield return StartCoroutine (do_demand( 2, locals[24], locals[23] ));
		if (PlayerAnswer==1){
			
			privateVariables[1] = 1;
		} else {
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_008b();//ENDCONVO
			yield break;
		} // end if
		
	} // end func

}
