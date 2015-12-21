using UnityEngine;
using System.Collections;

public class Conversation_141 : Conversation {

	//conversation #141
	//	string block 0x0e8d, name Feznor
			
	public override IEnumerator main() {
		SetupConversation (3725);
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
*/	
	void func_00d1() {
		
		npc.npc_attitude = 1;
		func_0012();
	} // end func

	void func_00e0() {
		
		func_0012();
	} // end func
/*	
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
		
		if ( privateVariables[0] == 0 ) {
			
			privateVariables[2] = 0;
		} // end if
		
		privateVariables[3] = 0;
		yield return StartCoroutine( func_02b9());
	} // end func
	
	IEnumerator func_02b9() {
		
		while ( privateVariables[2] < 5 ) {
			
			if ( privateVariables[3] == 0 ) {
				
				yield return StartCoroutine(say( "Welcome, traveller.  How can I help thee?" ));
				privateVariables[3] = 1;
			} else {
				
				yield return StartCoroutine(say( "/mThat is all I can tell thee of that particular matter.  What else art thou interested in?" ));
			} // end if
			
			yield return StartCoroutine(func_02ef());
		} // while
		
		if ( privateVariables[3] == 0 ) {
			
			yield return StartCoroutine(say( "I am sorry but I have no more knowledge to impart to thee.  I wish thee good luck in thy quests, whatever they may be and wherever they may take thee." ));
		} // end if
		
		yield return StartCoroutine(func_05b3());
	} // end func
	
	IEnumerator func_02ef() {
		
		//int locals[22];
		int[] locals = new int[23];
		
		locals[1] = 4;
		locals[2] = 6;
		locals[3] = 7;
		locals[4] = 8;
		locals[5] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			if ( privateVariables[9] == 1) {
				
				yield return StartCoroutine(say( "What wouldst thou know?" ));
				yield return StartCoroutine(func_03d9());
			} else {
				
				yield return StartCoroutine(func_036b());
			} // end if
			
			break;
			
		case 2:
			
			yield return StartCoroutine(func_04b1());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_053a());
			break;
			
		case 4:
			
			yield return StartCoroutine(say( "My pleasure." ));
			yield return StartCoroutine(func_05b3());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_036b() {
		
		//int locals[22];
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Ah, yes, this area is wonderfully designed.  We created much of it ourselves, with some help from the artisans of Minoc and the Mountainfolk.  There are many regions of interest.  Although the Abyssal colony has only existed a short time, it is filled with wonders to match any found in Britannia." ));
		locals[1] = 11;
		locals[2] = 12;
		locals[3] = 13;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_03c7());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_05a6());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_03c7());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03c7() {
		
		privateVariables[9] = 1;
		yield return StartCoroutine(say( "In the northeast corner of the level is the Puzzle of the Bullfrog, made by a Mountainfolk craftswoman who had a love of frogs. \n"
		   + " To the northwest is the Maze of Silas, a stoneworker and lover of deceptive walls. \n"
		   + " Beyond the maze is the door of precious levers, which opens the gateway to the resting place of one of our order. \n"
		   + " There is a water-filled area to the west of the Abyss' volcanic core. The waterfall is something to see." ));
		yield return StartCoroutine(func_03d9());
	} // end func
	
	IEnumerator func_03d9() {
		
		//int locals[22];
		int[] locals = new int[23];
		
		locals[1] = 15;
		locals[2] = 16;
		locals[3] = 17;
		locals[4] = 18;
		locals[5] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0446());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0460());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_0494());
			break;
			
		case 4:
			
			yield return StartCoroutine(func_047a());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0446() {
		
		if ( privateVariables[4] == 1) {
			
			yield return StartCoroutine(say( "I thought I had already told thee of that./m" ));
		} // end if
		
		yield return StartCoroutine(say( "Past the puzzle in the northeast there is an entrance to the tombs below.  To reach the entrance, one must traverse an area surrounded by water.  It is said that by using the levers and buttons in the area, one may create a safe path to the other side.  It has been years since the puzzle was created, though, and its solution is now lost.  The only clue I know of is that the wand found there will restore the puzzle to its pristine state." ));
		privateVariables[4] = 1;
		yield return StartCoroutine(func_02ef());
	} // end func
	
	IEnumerator func_0460() {
		
		if ( privateVariables[5] == 1) {
			
			yield return StartCoroutine(say( "I thought I had already told thee of that./m" ));
		} // end if
		
		yield return StartCoroutine(say( "The Maze of Silas is now infested with pests and littered with debris and bones, but there are said to be other things in the maze as well -- hidden chambers and items of some value. The locations of these chambers and items are unknown now, however, so what they contain I cannot reveal to thee." ));
		privateVariables[5] = 1;
		yield return StartCoroutine(func_02ef());
	} // end func
	
	IEnumerator func_047a() {
		
		if ( privateVariables[7] == 1) {
			
			yield return StartCoroutine(say( "I thought I had already told thee of that./m" ));
		} // end if
		
		yield return StartCoroutine(say( "Near the volcano's shaft is a set of falls leading to two pools. \n"
		    + " One pool is very hard to reach, at least from our domain. But 'tis said it is simple to get there from the Lair of the Lizard-Folk. Would that one among us could speak their tongue and learn the easier route. \n"
		    + " The second pool is in a secluded spot near a fishing run south of the Abyss' central shaft." ));
		privateVariables[7] = 1;
		yield return StartCoroutine(func_02ef());
	} // end func
	
	IEnumerator func_0494() {
		
		if ( privateVariables[6]== 1 ) {
			
			yield return StartCoroutine(say( "I thought I had already told thee of that./m" ));
		} // end if
		
		yield return StartCoroutine(say( "The puzzle of precious levers is beyond the maze.  Although the members of our knighthood will not be specific, it is believed to be in a concealed area. \n"
		   + " The puzzle itself was built to guard the stores of the old government of the Abyss.  Now, however, not one of us could tell thee what lies beyond the closed door./m" ));
		yield return StartCoroutine(say( "The workings of the levers are not understood, but 'tis said that their secrets can be gleaned through careful examination of the artifacts of our order. \n"
		   + " I have not the patience for such research, but perhaps one who does will solve the mystery." ));
		privateVariables[6] = 1;
		yield return StartCoroutine(func_02ef());
	} // end func
	
	IEnumerator func_04b1() {
		
		//int locals[22];
		int []locals= new int[23];
		
		if ( privateVariables[8] == 1) {
			
			yield return StartCoroutine(say( "I thought I had already told thee of that./m" ));
		} // end if
		
		yield return StartCoroutine(say( "They are indeed a vicious and dangerous race.  I would call them indecent, but that was not Cabirus' way, and I strive not to make it mine. \n"
		    + " They are, truth be told, honorable in their own way.  Only a few of them still cling to any shreds of the Abyss' purpose, though.  Some have reverted to their natural, combative state.  They are monsters, and powerful ones, at that." ));
		privateVariables[8] = 1;
		locals[1] = 30;
		locals[2] = 31;
		locals[3] = 33;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_052a());
			break;
			
		case 2:
			
			yield return StartCoroutine(say( "Ready, yes, but not eager." ));
			func_052a();
			break;
			
		case 3:
			
			yield return StartCoroutine(func_051d());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_051d() {
		
		yield return StartCoroutine(say( "Part of a knight's goal is to be a good fighter, it is true.  But a good fighter does not rejoice in a battle for its own sake. \n"
		   + " Thy blade is an ally only when it is used with honor and justice. When it is used for needless bloodshed, it stains thy honor and the honor of thy order. \n"
		   + " Do not fight for the sake of killing.  Fight for thy life, the life of those thou art sworn to defend, and to eliminate those that threaten our realm.  Fighting for the sake of blood is a short road to death." ));
		yield return StartCoroutine(func_02ef());
	} // end func
	
	IEnumerator func_052a() {
		
		yield return StartCoroutine(say( "Thou needst not fight continually to survive their realm. In the south, where the main meeting hall of the Trolls used to be, there are still Trolls who respect Cabirus' purpose.  They can tell thee more of the realm.  Beware the Dark Trolls - they are more powerful even than the normal ones./m" ));
		yield return StartCoroutine(say( "Also beware the northern parts of their realm, for they have been invaded by spiders, headlesses, and worse.  These monsters will provide enough trouble, so don't attack Trolls unless they attack thee first.  Thou wilt have enough trouble staying alive without picking fights." ));
		yield return StartCoroutine(func_02ef());
	} // end func
	
	IEnumerator func_053a() {
		
		//int locals[22];
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "We came here from Jhelom.  The fairest town in Britannia, that I can say with certainty.  Been to them all I have, and none compare." ));
		locals[1] = 38;
		locals[2] = 39;
		locals[3] = 40;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0596());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0596());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_05a6());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0596() {
		
		yield return StartCoroutine(say( "The colony of the Abyss was an achievement unparalleled in recent times.  Eight cultures mixing in one environment, and getting along splendidly./m  We had some banquets that were spectacular, I tell thee.  They rivaled the best of parties that even Jhelom could offer. We would all gather just to the northeast of here in the banquet hall.  We would stay up all night -- though of course it is hard to tell down here -- and recount tales of our homelands, our rituals, and our friends./m" ));
		yield return StartCoroutine(say( "Now all we do is fight for food and space.  Truly the death of Cabirus was the death of the Colony of the Stygian Abyss.  Still, we try, for it is all we can do to honor his legacy and dream." ));
		yield return StartCoroutine(func_02ef());
	} // end func
	
	IEnumerator func_05a6() {
		
		yield return StartCoroutine(say( "Perhaps the inhabitants of Jhelom were not perfect, but they were certainly more courteous than thee." ));
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00d1();
		yield break;
	} // end func
	
	IEnumerator func_05b3() {
		
		//int locals[22];
		int[] locals = new int[23];
		
		locals[1] = 44;
		locals[2] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		if ( locals[22] == 1 ) {
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
		} // end if
		
	} // end func
	
	IEnumerator func_05e4() {
		
		//int locals[44];
		int[] locals =new int[45];
		setup_to_barter( 0 );
		while ( privateVariables[1] == 0 ) {
			
			locals[1] = 45;
			locals[2] = 46;
			locals[3] = 47;
			locals[4] = 48;
			locals[5] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_0695());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_06ef());
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
		
		locals[23] = 49;
		locals[24] = 0;
		//locals[44] = babl_menu( 0, locals[23] );
		yield return StartCoroutine(babl_menu (0,locals,23));
		locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_0695() {

		//int locals[15];
		int[] locals = new int[16];
		
		locals[0] = -1;
		locals[6] = -1;
		locals[11] = 50;
		locals[12] = 51;
		locals[13] = 52;
		locals[14] = 53;
		locals[15] = 54;
		//if ( do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ) ) {
		yield return StartCoroutine (do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6],locals[1]) );
		if (PlayerAnswer==1)	{
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_06ef() {
		
		//int locals[24];
		int[] locals =  new int[25];
		
		yield return StartCoroutine(say( "Dost thou intend to rob me?" ));
		locals[1] = 56;
		locals[2] = 57;
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
		
		locals[23] = 58;
		locals[24] = 59;
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
