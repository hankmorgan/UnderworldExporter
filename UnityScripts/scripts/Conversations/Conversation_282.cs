using UnityEngine;
using System.Collections;

public class Conversation_282 : Conversation {


	//conversation #282
	//	string block 0x0f1a, name Generic Outcast

	
	public override IEnumerator main() {
		SetupConversation (3866);
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
		
		//int locals[1];
		int[] locals =new int[2];
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
		
		npc.npc_attitude = param1;//[0];//;play_hunger;
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
	
	void func_00e0() {
		
		func_0012();
	} // end func
	
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
		
		//int locals[244];
		int[] locals =new int[245];
		
		if ( privateVariables[0] == 1) {
			
		} else {
			
			yield return StartCoroutine(say( "So, another comrade is caught by the Abyss!  What was thy crime, pray-tell?" ));
			locals[1] = 2;
			locals[2] = 3;
			locals[3] = 4;
			locals[4] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[2] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				goto label_045f;
				
				break;
				
			case 2:
				
				goto label_04b3;
				
				break;
				
			case 3:
				
				goto label_02fd;
				
				break;
				
			} // end switch
			
		//label_02fd:;
			
/*		label_02fd:;
			
			yield return StartCoroutine(say( "Hm, perhaps the same girl that I hear was carried through these upper caves by a Troll." ));
			locals[23] = 6;
			locals[24] = 7;
			locals[25] = 8;
			locals[26] = 0;
			locals[44] = babl_menu( 0, locals[23] );
			switch ( locals[44] ) {
				
			case 1:
				
				goto label_0351;
				
				break;
				
			case 2:
				
				goto label_0351;
				
				break;
				
			case 3:
				
				goto label_0351;
				
				break;
				
			} // end switch*/
			
	/*	label_0351:;
			
		//label_0351:;
			
		//label_0351:;
			
			yield return StartCoroutine(say( "Well, whoever she was, she's here no longer.  I don't know how far the Troll was planning on taking her, but given the strength of a Troll, he'll not likely run out of energy any time soon." ));
			locals[45] = 10;
			locals[46] = 11;
			locals[47] = 0;
			locals[66] = babl_menu( 0, locals[45] );
			switch ( locals[66] ) {
				
			case 1:
				
				goto label_0391;
				
				break;
				
			case 2:
				
				goto label_0391;
				
				break;
				
			} // end switch*/
			
		/*label_0391:;
			
	//	label_0391:;
			
			yield return StartCoroutine(say( "Hold on just a minute.  Surely that girl is in trouble, but if thou dost learn the ways of the Abyss first, thou wilt surely have a better chance of rescuing her." ));
			locals[67] = 13;
			locals[68] = 14;
			locals[69] = 0;
			locals[88] = babl_menu( 0, locals[67] );
			switch ( locals[88] ) {
				
			case 1:
				
				goto label_03d1;
				
				break;
				
			case 2:
				
				goto label_03d1;
				
				break;
				
			} // end switch*/
			
		//label_03d1:;
			
		//label_03d1:;
			
		//label_03d1:;
			
		//label_03d1:;
			
/*		label_03d1:;
			
			yield return StartCoroutine(say( "Well, thou shouldst know that most of the inhabitants of the Abyss are unfriendly.  It's not so much a question of what areas to avoid as of which areas are relatively safe. \n"
			    +" Look for the Banner of Cabirus -- a tapestry with an ankh, such as we have -- as a sign of civilization.  Any people or creatures thou dost find past the Banner are more likely to talk with thee than eat thee. \n"
			   + " Speaking of ankhs, thou wouldst do well to search out the other thing they represent: the shrines." ));
			locals[89] = 16;
			locals[90] = 17;
			locals[91] = 0;
			locals[110] = babl_menu( 0, locals[89] );
			switch ( locals[110] ) {
				
			case 1:
				
				goto label_0411;
				
				break;
				
			case 2:
				
				goto label_0411;
				
				break;
				
			} // end switch
			
		//label_0411:;*/
			
/*		label_0411:;
			
			yield return StartCoroutine(say( "When thou dost see a large, plain ankh standing on the ground, thou hast found a shrine to Virtue. \n"
			    +" It is said that if thou hast been virtuous, and dedicated to increasing thy abilities, praying at a shrine with the correct mantra will allow thee to enhance thy abilities. \n"
			    +" It is said that there is one in the southeast area of these upper caves, but I have not seen it myself." ));
			locals[111] = 19;
			locals[112] = 20;
			locals[113] = 0;
			locals[132] = babl_menu( 0, locals[111] );
			switch ( locals[132] ) {
				
			case 1:
				
				goto label_0451;
				
				break;
				
			case 2:
				
				goto label_0451;
				
				break;
				
			} // end switch*/
			
		//label_0451:;
			
		//label_0451:;
			
		/*label_0451:;
			
			yield return StartCoroutine(say( "Well, good luck in thy travels.  Thou art always welcome here." ));
			locals[133] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[133] );
			yield break;*/
		label_045f:;
			
			yield return StartCoroutine(say( "Oh, thou art an innocent passerby, eh?  Perhaps thou art here on a tour of the Abyss?  Or art thou a census taker? A tax collector?  Eh?" ));
			locals[134] = 23;
			locals[135] = 24;
			locals[136] = 25;
			locals[137] = 0;
			//locals[155] = babl_menu( 0, locals[134] );
			yield return StartCoroutine(babl_menu (0,locals,134));
			locals[155] = PlayerAnswer;
			switch ( locals[155] ) {
				
			case 1:
				
				goto label_04b8;
				
				break;
				
			case 2:
				
				goto label_04b3;
				
				break;
				
			case 3:
				
				goto label_04b3;
				
				break;
				
			} // end switch
			
		//label_04b3:;
			
		//label_04b3:;
			
		label_04b3:;
			
			yield return StartCoroutine(say( "Already been driven mad, I see.  'Tis a pity, truly, to see the mind go on one so young.  Ah, well, death is probably thy best hope. Good luck." ));
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
		label_04b8:;
			
			yield return StartCoroutine(say( "Thrown here against thy will I will believe, but wrongfully is a different matter.  No need to pretend amoungst us, though.  Not a one of us believes in Almric's petty justice. \n"
			    +"  Now that thou'rt here, thou shouldst stay with us.  The creatures beyond are far worse than anything Almric could do to thee.  Right here near the door is safest.  Trust me." ));
			locals[156] = 28;
			locals[157] = 29;
			locals[158] = 0;
			//locals[177] = babl_menu( 0, locals[156] );
			yield return StartCoroutine(babl_menu (0,locals,156));
			locals[177] = PlayerAnswer;
			switch ( locals[177] ) {
				
			case 1:
				
				goto label_04f8;
				
				break;
				
			case 2:
				
				goto label_04f8;
				
				break;
				
			} // end switch
			
		//label_04f8:;
			
		//label_04f8:;
			
/*		label_04f8:;
			
			yield return StartCoroutine(say( "'Tis unbelievable. Once, it is said, all the races here lived in harmony.  Not now, that's for certain.  The Gobs on this level are constantly at war, with each other as well as everyone else.  And below are things I dare not speak of. \n"
			    +" 'Tis rumored that some remnants of civilization remain in most colonized areas of the Abyss, but I have never had the courage or interest to find out." ));
			locals[178] = 31;
			locals[179] = 32;
			locals[180] = 0;
			locals[199] = babl_menu( 0, locals[178] );
			switch ( locals[199] ) {
				
			case 1:
				
				goto label_03d1;
				
				break;
				
			case 2:
				
				goto label_03d1;
				break;	
			} // end if*/


			
		} // end switch
		
		yield return StartCoroutine(say( "A hearty welcome to thee.  Hast thou decided to stay with us?" ));
		locals[200] = 34;
		locals[201] = 35;
		locals[202] = 37;
		locals[203] = 0;
		//locals[221] = babl_menu( 0, locals[200] );
		yield return StartCoroutine(babl_menu (0,locals,200));
		locals[221] = PlayerAnswer;
		switch ( locals[221] ) {
			
		case 1:
			
			goto label_0451;
			
			break;
			
		case 2:
			
			yield return StartCoroutine(say( "I am glad to hear it.  This is by far the safest place in the Abyss." ));
			locals[222] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[222] );
			yield break;
			break;
			
		case 3:
			
			goto label_0598;
			
			break;
			
		} // end switch
		
	label_0598:;
		
		yield return StartCoroutine(say( "What wouldst thou know of?" ));
		locals[223] = 39;
		locals[224] = 40;
		locals[225] = 41;
		locals[226] = 0;
		//locals[244] = babl_menu( 0, locals[223] );
		yield return StartCoroutine(babl_menu (0,locals,223));
		locals[244] = PlayerAnswer;
		switch ( locals[244] ) {
			
		case 1:
			
			goto label_02fd;
			
			break;
			
		case 2:
			
			goto label_04f8;
			
			break;
			
		case 3:
			
			goto label_03d1;
			
			break;
			
		} // end switch



		//Moved labels
	label_0451:;
		
		yield return StartCoroutine(say( "Well, good luck in thy travels.  Thou art always welcome here." ));
		locals[133] = 2;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[133] );
		yield break;


	label_02fd:;
		
		yield return StartCoroutine(say( "Hm, perhaps the same girl that I hear was carried through these upper caves by a Troll." ));
		locals[23] = 6;
		locals[24] = 7;
		locals[25] = 8;
		locals[26] = 0;
		//locals[44] = babl_menu( 0, locals[23] );
		yield return StartCoroutine(babl_menu (0,locals,23));
		locals[44] = PlayerAnswer;
		switch ( locals[44] ) {
			
		case 1:
			
			goto label_0351;
			
			break;
			
		case 2:
			
			goto label_0351;
			
			break;
			
		case 3:
			
			goto label_0351;
			
			break;
			
		} // end switch



	label_04f8:;
		
		yield return StartCoroutine(say( "'Tis unbelievable. Once, it is said, all the races here lived in harmony.  Not now, that's for certain.  The Gobs on this level are constantly at war, with each other as well as everyone else.  And below are things I dare not speak of. \n"
		                                +" 'Tis rumored that some remnants of civilization remain in most colonized areas of the Abyss, but I have never had the courage or interest to find out." ));
		locals[178] = 31;
		locals[179] = 32;
		locals[180] = 0;
		//locals[199] = babl_menu( 0, locals[178] );
		yield return StartCoroutine(babl_menu (0,locals,178));
		locals[199] = PlayerAnswer;
		switch ( locals[199] ) {
			
		case 1:
			
			goto label_03d1;
			
			break;
			
		case 2:
			
			goto label_03d1;
			break;	
		} // end if



	label_0351:;
		
		//label_0351:;
		
		//label_0351:;
		
		yield return StartCoroutine(say( "Well, whoever she was, she's here no longer.  I don't know how far the Troll was planning on taking her, but given the strength of a Troll, he'll not likely run out of energy any time soon." ));
		locals[45] = 10;
		locals[46] = 11;
		locals[47] = 0;
		//locals[66] = babl_menu( 0, locals[45] );
		yield return StartCoroutine(babl_menu (0,locals,45));
		locals[66] = PlayerAnswer;
		switch ( locals[66] ) {
			
		case 1:
			
			goto label_0391;
			
			break;
			
		case 2:
			
			goto label_0391;
			
			break;
			
		} // end switch


	label_03d1:;
		
		yield return StartCoroutine(say( "Well, thou shouldst know that most of the inhabitants of the Abyss are unfriendly.  It's not so much a question of what areas to avoid as of which areas are relatively safe. \n"
		                                +" Look for the Banner of Cabirus -- a tapestry with an ankh, such as we have -- as a sign of civilization.  Any people or creatures thou dost find past the Banner are more likely to talk with thee than eat thee. \n"
		                                + " Speaking of ankhs, thou wouldst do well to search out the other thing they represent: the shrines." ));
		locals[89] = 16;
		locals[90] = 17;
		locals[91] = 0;
		//locals[110] = babl_menu( 0, locals[89] );
		yield return StartCoroutine(babl_menu (0,locals,89));
		locals[110] = PlayerAnswer;
		switch ( locals[110] ) {
			
		case 1:
			
			goto label_0411;
			
			break;
			
		case 2:
			
			goto label_0411;
			
			break;
			
		} // end switch

	label_0391:;
		
		//	label_0391:;
		
		yield return StartCoroutine(say( "Hold on just a minute.  Surely that girl is in trouble, but if thou dost learn the ways of the Abyss first, thou wilt surely have a better chance of rescuing her." ));
		locals[67] = 13;
		locals[68] = 14;
		locals[69] = 0;
		//locals[88] = babl_menu( 0, locals[67] );
		yield return StartCoroutine(babl_menu (0,locals,67));
		locals[88] = PlayerAnswer;
		switch ( locals[88] ) {
			
		case 1:
			
			goto label_03d1;
			
			break;
			
		case 2:
			
			goto label_03d1;
			
			break;
			
		} // end switch


	label_0411:;
		
		yield return StartCoroutine(say( "When thou dost see a large, plain ankh standing on the ground, thou hast found a shrine to Virtue. \n"
		                                +" It is said that if thou hast been virtuous, and dedicated to increasing thy abilities, praying at a shrine with the correct mantra will allow thee to enhance thy abilities. \n"
		                                +" It is said that there is one in the southeast area of these upper caves, but I have not seen it myself." ));
		locals[111] = 19;
		locals[112] = 20;
		locals[113] = 0;
		//locals[132] = babl_menu( 0, locals[111] );
		yield return StartCoroutine(babl_menu (0,locals,111));
		locals[132] = PlayerAnswer;
		switch ( locals[132] ) {
			
		case 1:
			
			goto label_0451;
			
			break;
			
		case 2:
			
			goto label_0451;
			
			break;
			
		} // end switch



	} // end func





}
