using UnityEngine;
using System.Collections;

public class Conversation_143 : Conversation {

	//conversation #143
	//string block 0x0e8f, name Biden
			
	int func_04db_result;
	int func_074a_result;
	int func_06c9_result;
	int func_082f_result;
	int func_07d6_result;
	int func_078b_result;

	public override IEnumerator main() {
		SetupConversation (3727);
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
		
		npc.npc_attitude = param1;//param1[0]play_hunger;
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
		
		//int locals[2];
		int [] locals = new int[3];
		
		if ( npc.npc_goal == 11 ) {
			
			npc.npc_goal = 7;
		} // end if

		locals[1] = 32;
		privateVariables[3] = get_quest( 1, locals[1] );

		if ( privateVariables[2] == 1) {
			
			if ( npc.npc_goal == 1 ) {
				
				yield return StartCoroutine (func_0692());
			} else {
				
				yield return StartCoroutine (func_05f7());
			} // end if
			
		} else {
			
			locals[2] = 11;
			if ( get_quest( 1, locals[2] ) == 1 ) {
				
				yield return StartCoroutine (func_069f());
			} else {
				
				yield return StartCoroutine (func_02f0());
			} // end if
			
		} // end if
		
	} // end func
	
	IEnumerator func_02f0() {
		
		//int locals[2];
		int[] locals =new int[3];		               
		
		if ( privateVariables[0] == 0 ) {
			
			locals[1] = 1;
			yield return StartCoroutine (func_06c9( locals[1] ) );
			if ( func_06c9_result == 0 ) {
				
				locals[2] = 1;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[2] );//endconvo
				yield break;
			} // end if
			
		} // end if
		
		if ( privateVariables[5] == 1) {
			
			yield return StartCoroutine (func_0327());
		} else {
			
			yield return StartCoroutine (func_0388());
		} // end if
		
	} // end func
	
	IEnumerator func_0327() {
		
		//int locals[22];
		int[] locals = new int[23];
		
		yield return StartCoroutine (say( "Hast thou managed to defeat the villain Rodrick?" ));
		locals[1] = 2;
		locals[2] = 4;
		locals[3] = 6;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine (say( "He lives in the north part of the banquet hall, in the area with the dark marbled walls  and the sloped halls.  Thou shalt find him there!/m" ));
			break;
			
		case 2:
			
			yield return StartCoroutine (say( "He is a tough opponent, and quite strong. Find advantageous terrain and move often to keep him from simply overpowering thee.  Watch out for his slash.  Good luck to thee./m" ));
			break;
			
		case 3:
			
			yield return StartCoroutine (say( "I thought I heard him in the distance just a moment ago.  Perhaps thou didst mistake someone else for him./m" ));
			break;
			
		} // end switch
		
		yield return StartCoroutine (func_054f());
	} // end func
	
	IEnumerator func_0388() {
		
		//int locals[69];
		int[] locals = new int[70];
		locals[2] = 8;
		locals[3] = 9;		
		locals[1] = sex( 2, locals[3], locals[2] );

		if ( privateVariables[3] > 1 ) {
			
			yield return StartCoroutine (say( "@SS1, Thou art a member of my order.  Thou too dost strive to uphold the ideals of honor espoused by our order.  Thou dost understand the virtues, and understand the ways of knighthood.  Please listen to my tale." ));
		} else {
			
			yield return StartCoroutine (say( "Good @SS1, thou dost seem valorous and just, well equipped for the grave peril of the Abyss, and ready to brave the dangers of this area.  Please listen to my tale." ));
		} // end if
		
		locals[4] = 12;
		locals[5] = 14;
		locals[6] = 15;
		locals[7] = 0;
		//locals[25] = babl_menu( 0, locals[4] );
		yield return StartCoroutine(babl_menu (0,locals,4));
		locals[25] = PlayerAnswer;
		switch ( locals[25] ) {
			
		case 1:
			
			yield return StartCoroutine (say( "'Tis not a happy story, @SS1, but I shall tell it all the same./m" ));
			break;
			
		case 2:
			
			break;
			
		case 3:
			
			yield return StartCoroutine (func_04a8());
			break;
			
		} // end switch
		
		privateVariables[5] = 1;
		yield return StartCoroutine (say( "Sir Rodrick was once a member of our order, but abandoned the principles of our order and now calls himself the Chaos Knight, terrorizing the entire northern area.  Since to attack one with many would be dishonorable, our leader Dorna picked me to defeat him in single combat./m" ));
		yield return StartCoroutine (say( "When I reached the old banquet hall to the north, I was suddenly attacked by Rodrick, who leaped from a ledge above me and took me off guard.  He attacked relentlessly, and although I hit him several times, my own blows did little to slow him or curb his apparent anger.  He taunted me continuously as we fought, and would not listen as I attempted to reason with him./m" ));
		locals[26] = 18;
		locals[27] = 19;
		locals[28] = 0;
		//locals[47] = babl_menu( 0, locals[26] );
		yield return StartCoroutine(babl_menu (0,locals,26));
		locals[47] = PlayerAnswer;
		switch ( locals[47] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			break;
			
		} // end switch
		
		yield return StartCoroutine (say( "After several minutes I was bleeding from several wounds and thinking my time was up.  In desperation, I flung my sword at him.  He blocked it easily, but the distraction allowed me to run from him./m" ));
		yield return StartCoroutine (say( "So that is my story.  I can not return to my home until I have eliminated Rodrick and restored our order's honor, but it will be some time now before I am capable of fighting.  So I wait here, far from the Trolls and other pests, gathering my strength before I head off again." ));
		locals[48] = 22;
		locals[49] = 23;
		locals[50] = 25;
		locals[51] = 0;
		//locals[69] = babl_menu( 0, locals[48] );
		yield return StartCoroutine(babl_menu (0,locals,48));
		locals[69] = PlayerAnswer;
		switch ( locals[69] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			yield return StartCoroutine (say( "My honor is my life, and he has stolen it by defaming our order and defeating me./m" ));
			break;
			
		case 3:
			
			yield return StartCoroutine (say( "I must defeat him to restore my honor and that of my order, it is true, but a true knight approaches battles with strength and wits, and even with my wits it is clear that I am not now ready to fight him./m" ));
			break;
			
		} // end switch
		
		yield return StartCoroutine (func_054f());
	} // end func
	
	IEnumerator func_04a8() {
		yield return StartCoroutine(func_04db());
		if ( func_04db_result == 0 ) {
			
			if ( npc.npc_attitude > 1 ) {
				
				yield return StartCoroutine (say( "Please return, and help me." ));
			} else {
				
				yield return StartCoroutine (say( "I am quite disappointed with thy lack of compassion." ));
			} // end if
			
			if ( npc.npc_attitude > 0 ) {
				
				npc.npc_attitude = npc.npc_attitude - 1;
			} // end if
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();//endconvo
			yield break;
		} // end if
		
	} // end func
	
	IEnumerator func_04db() {
		
		//int locals[26];
		int [] locals= new int[27];
		locals[3] = 29;
		locals[4] = 30;		
		locals[2] = sex( 2, locals[4], locals[3] );

		yield return StartCoroutine (say( "Noble @SS2, I implore thee to hear it, for it is of great import, and dire consequences arise from it." ));
		locals[5] = 32;
		locals[6] = 33;
		locals[7] = 0;
		//locals[26] = babl_menu( 0, locals[5] );
		yield return StartCoroutine(babl_menu (0,locals,5));
		locals[26] = PlayerAnswer;
		switch ( locals[26] ) {
			
		case 1:
			
			locals[1] = 0;
			goto label_0547;
			
			break;
			
		case 2:
			
			locals[1] = 1;
			goto label_0547;
			
			break;
			
		} // end switch
		
	label_0547:;
		
	
		
		//return locals[1];
		func_04db_result=locals[1];
	} // end func
	
	IEnumerator func_054f() {
		
		//int locals[45];
		int[] locals=new int[46];
		
		yield return StartCoroutine (say( "I'd give the rest of my right arm for a chance to take that rogue on again.  He'd find out what sort of Knight I am." ));
		locals[1] = 35;
		locals[2] = 37;
		locals[3] = 39;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine (say( "Thou art certainly right." ));
			break;
			
		case 2:
			
			yield return StartCoroutine (say( "That would be quite honorable of thee." ));
			break;
			
		case 3:
			
			yield return StartCoroutine (say( "I should get well first, for I would not wish to be a burden on thee." ));
			break;
			
		} // end switch
		
		yield return StartCoroutine (say( "If thou dost meet the rogue and defeat him, it would not only bring great honor to thee but also perhaps save my life." ));
		locals[23] = 42;
		locals[24] = 43;
		locals[25] = 0;
		//locals[44] = babl_menu( 0, locals[23] );
		yield return StartCoroutine(babl_menu (0,locals,23));
		locals[44] = PlayerAnswer;
		switch ( locals[44] ) {
			
		case 1:
			
			locals[45] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[45] );//endconvo
			yield break;
			break;
			
		case 2:
			
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();//endconvo
			yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_05f7() {
		
		//int locals[11];
		int[] locals = new int[12];
		
		if ( privateVariables[6] == 0 ) {
			
			yield return StartCoroutine (say( "@GS8!  I am pleased beyond measure to see thee again.  I have told all here of thy exploits and they are as thankful as I am. \n"
			   + " Ah, by the way, as I made my way home, I happened across this scroll, and thought it might be useful to thee in thy travels.  Please take it as a token of my thanks." ));
			locals[2] = 314;
			locals[1] = do_inv_create( 1, locals[2] )+4 ; //Plus 4 for for x_obj

			locals[3] = 1;
			locals[4] = -1;
			locals[5] = -1;
			locals[6] = -1;
			locals[7] = 115;
			locals[8] = 0;
			locals[9] = -1;
			locals[10] = -1;
			//x_obj_stuff( 9, locals[10], locals[9], locals[8], locals[7], locals[6], locals[5], locals[4], locals[3], locals[1] );
			x_obj_stuff( 10,locals, 10, 9, 8, 7, 6, 5, 4, 3, locals[1] );
			locals[11] = 314;
			if ( take_from_npc( 1, locals[11] ) == 2 ) {
				
				yield return StartCoroutine (say( "/mI will leave it here for thee." ));
			} // end if
			
			privateVariables[6] = 1;
		} else {
			
			yield return StartCoroutine (say( "A hearty greeting to thee, @GS8.  It is good to see that thou dost allow precious time to converse with thy old friends.  Still, perhaps it is time for thee to travel on and find new challenges to overcome." ));
		} // end if
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		yield break;
	} // end func
	
	IEnumerator func_0692() {
		
		yield return StartCoroutine (say( "A pleasure to meet thee again, @GS8.  I've no time to talk at the moment, as I must return home to rejoin my companions. I would be most pleased to talk with thee once I am there." ));
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00e0();//endconvo
		yield break;
	} // end func
	
	IEnumerator func_069f() {
		
		//int locals[1];
		int[] locals = new int[2];
		
		yield return StartCoroutine (say( "Thou hast redeemed my honor by defeating Rodrick!  I thank thee from the depths of my soul.  Thou art surely as valorous as any of our order.  I can now return home to my companions without regret." ));
		privateVariables[2] = 1;
		npc.npc_xhome = 3;
		npc.npc_yhome = 16;
		npc.npc_goal = 1;
		locals[1] = 3;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );//endconvo
		yield break;
	} // end func
	
	IEnumerator func_06c9(int param1) {
		
		//int locals[3];
		int[] locals = new int[4];
		
		locals[3] = privateVariables[3];
		if ( 0 == locals[3] ) {
			yield return StartCoroutine (func_074a( param1 ));
			locals[2] = func_074a_result;
		} else {
			
			if ( 1 == locals[3] ) {
				yield return StartCoroutine (func_074a( param1 ));
				locals[2] = func_074a_result;
			} else {
				
				if ( 2 == locals[3] ) {
					yield return StartCoroutine (func_078b( param1 ));
					locals[2] = func_078b_result;
				} else {
					
					if ( 3 == locals[3] ) {
						yield return StartCoroutine (func_078b( param1 ));
						locals[2] = func_078b_result;
					} else {
						
						if ( 4 == locals[3] ) {
							yield return StartCoroutine (func_07d6( param1 ));
							locals[2] = func_07d6_result;
						} // end if
						
					} // end if
					
				} // end if
				
			} // end if
			
		} // end if
		
		locals[1] = locals[2];
		goto label_0742;
		
	label_0742:;
		
		//return locals[1];
		func_06c9_result = locals[1];
	} // end func
	
	IEnumerator func_074a(int param1) {
		
		//int locals[2];
		int[]locals = new int[3];
		
		yield return StartCoroutine (say( "Who art thou?" ));
		locals[2] = 1;
		yield return StartCoroutine(func_082f( locals[2] ));
		if ( func_082f_result==1 ) {
			
			//if ( param1[0]play_hunger ) {
			if ( param1==1 ) {
				yield return StartCoroutine (say( "I am @GS25, a member of the Order of the Knights of the Crux Ansata." ));
			} else {
				
				yield return StartCoroutine (say( "I belong to the Order of the Crux Ansata." ));
			} // end if
			
			locals[1] = 1;
		} else {
			
			yield return StartCoroutine (say( "My name is mine own as well, but I am proud to share it with others who honor it.  Those who are not willing, well, I prefer that they depart." ));
			locals[1] = 0;
		} // end if
		
		//return locals[1];
		func_074a_result=locals[1];
	} // end func
	
	IEnumerator func_078b(int param1) {
		
		//int locals[5];
		int [] locals = new int[6];
		locals[3] = 53;
		locals[4] = 54;
		locals[2] = sex( 2, locals[4], locals[3] );

		yield return StartCoroutine (say( "Greetings, @SS2.  What is thy name?" ));
		locals[5] = 0;
		func_082f( locals[5] );
		//if ( privateVariables[4] && param1[0]play_hunger ) {
		if ( (privateVariables[4] == 1) && (param1 == 1)) {
			yield return StartCoroutine (say( "I am @GS25, and pleased to make thy acquaintance." ));
		} // end if
		
		locals[1] = 1;
		goto label_07ce;
		
	label_07ce:;
		
		//return locals[1];
		func_078b_result=locals[1];
	} // end func
	
	IEnumerator func_07d6(int param1) {
		
		//int locals[1];
		int[] locals = new int[2];
		
		yield return StartCoroutine (say( "It is a great honor to speak with thee, @GS8." ));
		privateVariables[4] = 1;
		//if ( privateVariables[4] && param1[0]play_hunger ) {
		if ( (privateVariables[4] == 1 )&& (param1==1)) {
			yield return StartCoroutine (say( "I am @GS25, and pleased to make the acquaintance of one who brings such honor to our order." ));
		} // end if
		
		locals[1] = 1;
		goto label_07f8;
		
	label_07f8:;
		
		//return locals[1];
		func_07d6_result=locals[1];
	} // end func
	
	IEnumerator func_0800(int param1) {
		
		//int locals[1];
		int[] locals = new int[2];
		
		//locals[1] = privateVariables[3] < 2;
		if (privateVariables[3]<2)
		{
			locals[1]=1;
		}
		else
		{
			locals[1]=0;
		}
		yield return StartCoroutine (say( "Excuse me, what was thy name again?" ));
		yield return StartCoroutine( func_082f( locals[1] ));
		if ( func_082f_result == 1 ) {
			
			//if ( param1[0]play_hunger ) {
			if ( param1==1 ) {
				yield return StartCoroutine (say( "Ah.  I am @GS25." ));
			} else {
				
				yield return StartCoroutine (say( "I am of the Order of the Crux Ansata." ));
			} // end if
			
		} else {
			
			yield return StartCoroutine (say( "Ah, I must not have missed thy name - thou must have witheld it.  Well, privacy must be respected, I suppose,  but it is difficult to bring honor to a name that is secret." ));
		} // end if
		
	} // end func
	
	IEnumerator func_082f(int param1) {
		
		//int locals[44];
		int[] locals = new int[45];
		
		locals[23] = 1;
		locals[2] = 63;
		locals[24] =param1;// param1[0]play_hunger;
		locals[3] = 64;
		locals[25] = 1;
		locals[4] = 65;
		locals[5] = 0;
		//locals[44] = babl_fmenu( 0, locals[2], locals[23] );
		yield return StartCoroutine(babl_fmenu (0,locals,2,23));
		locals[44]=PlayerAnswer;
		switch ( locals[44] ) {
			
		case 63:
			
			privateVariables[4] = 1;
			break;
			
		case 64:
			
			locals[1] = 0;
			goto label_08b1;
			
			break;
			
		case 65:
			
			break;
			
		} // end switch
		
		locals[1] = 1;
		goto label_08b1;
		
	label_08b1:;
		

		
		//return locals[1];
		func_082f_result=locals[1];
	} // end func
	
	IEnumerator func_08b9() {
		
		//int locals[48];
		int[] locals= new int[49];
		locals[2] = 66;
		locals[3] = 67;
		locals[1] = sex( 2, locals[3], locals[2] );

		if ( privateVariables[4]==1 ) {
			
			yield return StartCoroutine (say( "Can I help thee, @GS8?" ));
		} else {
			
			yield return StartCoroutine (say( "Can I help thee, @SS1?" ));
		} // end if
		
		locals[4] = 70;
		locals[5] = 72;
		locals[6] = 0;
		//locals[25] = babl_menu( 0, locals[4] );
		yield return StartCoroutine(babl_menu (0,locals,4));
		locals[25] = PlayerAnswer;
		switch ( locals[25] ) {
			
		case 1:
			
			yield return StartCoroutine (say( "He lives in the south of our domain." ));
			break;
			
		case 2:
			
			yield return StartCoroutine (say( "Most have reverted to feral behavior, but some few still adhere to the virtues." ));
			break;
			
		} // end switch
		
		locals[26] = 74;
		locals[27] = 75;
		locals[28] = 0;
		//locals[47] = babl_menu( 0, locals[26] );
		yield return StartCoroutine(babl_menu (0,locals,26));
		locals[47] = PlayerAnswer;
		switch ( locals[47] ) {
			
		case 1:
			
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();//endconvo
			yield break;
			break;
			
		case 2:
			
			break;
			
		} // end switch
		
		if ( npc.npc_attitude < 3 ) {
			
			locals[48] = 5;
			if ( random( 1, locals[48] ) < 3 ) {
				
				npc.npc_attitude = npc.npc_attitude + 1;
			} // end if
			
		} // end if
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( 21 );//endconvo
		yield break;
	} // end func

}
