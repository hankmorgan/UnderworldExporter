using UnityEngine;
using System.Collections;

public class Conversation_191 : Conversation {
	//conversation #191
	//	string block 0x0ebf, name Ranthru
			

	public override IEnumerator main() {
		SetupConversation (3775);
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
	*/
	void func_00b1(int param1) {
		
		npc.npc_attitude = param1;//param1[0]play_hunger;
		func_0012();
	} // end func
	/*
	void func_00c2() {
		
		npc.npc_attitude = 2;
		func_0012();
	} // end func
	
	void func_00d1() {
		
		npc.npc_attitude = 1;
		func_0012();
	} // end func
	*/
	void func_00e0() {
		
		func_0012();
	} // end func
	/*
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
		
		int[] locals = new int[23];
		
		if ( privateVariables[0] ==1) {//has met
			
			if ( privateVariables[2] ==1) {//On quest to find book
				
				if ( privateVariables[3]==1 ) {//returned book.
					
					yield return StartCoroutine(func_0809());
				} else {
					
					yield return StartCoroutine(func_05b7());
				} // end if
				
			} else {
				
				yield return StartCoroutine(func_031e());
			} // end if
			
		} else {
			
			privateVariables[2] = 0;
			privateVariables[3] = 0;
			yield return StartCoroutine(say( "I have not seen thee in these parts before.  Art thou in league with Vilus?" ));
			locals[1] = 2;
			locals[2] = 3;
			locals[3] = 4;
			locals[4] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_041e());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_037a());
				break;
				
			case 3:
				
				yield return StartCoroutine(func_0583());
				break;
			} // end if
			
			//break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_031e() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Not again!  Thou, who art a servant of Vilus surely!" ));
		locals[1] = 6;
		locals[2] = 7;
		locals[3] = 8;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_037a());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0583());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_041e());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_037a() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "I was sure of it.  Please, spare my life!" ));
		locals[1] = 10;
		locals[2] = 11;
		locals[3] = 12;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
			break;
			
		case 2:
			
			yield return StartCoroutine(func_03d6());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_03d6());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03d6() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Dost thou toy with me?  I thought thou wert in league with Vilus, a mage almost as evil as he is insane, and almost as insane as he is powerful!" ));
		locals[1] = 14;
		locals[2] = 15;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
			break;
			
		case 2:
			
			yield return StartCoroutine(func_041e());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_041e() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Vilus used to be a Seer like the rest of us.  A brilliant mage he was, but perhaps too much so for his own good.  While exploring a method of casting powerful magic without runestones, he was overtaken by insanity." ));
		locals[1] = 17;
		locals[2] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		if ( locals[22] == 1 ) {
			
			yield return StartCoroutine(func_0452());
		} // end if
		
	} // end func
	
	IEnumerator func_0452() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Whether he be alive or dead, I know not.  He took over the caves to the northeast, filling them with vicious creatures and devious traps.  No sane person ventures there any longer, least of all myself.  Wilt thou run an errand there for me?" ));
		locals[1] = 19;
		locals[2] = 20;
		locals[3] = 21;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_04f6());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_04ae());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_04f6());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_04ae() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Oh, it's not really as dangerous as all that.  A few creatures here and there... nothing that thou couldst not deal with easily." ));
		locals[1] = 23;
		locals[2] = 24;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_04f6());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_04f6());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_04f6() {
		
		int[] locals = new int[23];
		
		privateVariables[2] = 1;
		yield return StartCoroutine(say( "Vilus took a powerful book from the Library and failed to return it.  It is named \"On the Properties of Runestones.\"  Return it to me and I shall teach thee to use thy magical abilities to their fullest." ));
		locals[1] = 26;
		locals[2] = 27;
		locals[3] = 28;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0557());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_068f());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_056d());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0557() {
		
		int[] locals = new int[2];
		
		yield return StartCoroutine(say( "I thank thee greatly.  Good luck in thy travels." ));
		locals[1] = 2;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );
		yield break;
	} // end func
	
	IEnumerator func_056d() {
		
		int[] locals = new int[2];
		
		yield return StartCoroutine(say( "I am disappointed to hear that.  If thou dost happen to find the book anyway, please let me know." ));
		locals[1] = 1;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );
		yield break;
	} // end func
	
	IEnumerator func_0583() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "I am glad to hear it!  I am sure that if thou wert allied with Vilus, I would be dead already." ));
		locals[1] = 32;
		locals[2] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		if ( locals[22] == 1 ) {
			
			yield return StartCoroutine(func_041e());
		} // end if
		
	} // end func
	
	IEnumerator func_05b7() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Ah, 'tis thee again.  From a distance I mistook thee for one of Vilus' servants.  Hast thou found \"On the Properties of Runestones\" for me yet?" ));
		locals[1] = 34;
		locals[2] = 35;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_068f());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_05ff());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_05ff() {
		
		int[] locals = new int[2];
		
		yield return StartCoroutine(say( "I am sure that that fiend Vilus has hidden it most deviously.  I wish that I could aid thee in thy search!" ));
		locals[1] = 2;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );
		yield break;
	} // end func
	
	int func_0615(int param1, int param2) {
		
		int[] locals = new int[10];
		locals[2]=-1;//Added so x_obj does not change the link on me
		locals[3] = 0;
		locals[4] = -1;
		locals[5] = -1;
		locals[6] = -1;
		locals[7] = -1;
		locals[8] = -1;
		locals[9] = -1;
		//x_obj_stuff( 9, locals[9], locals[8], locals[7], locals[2], locals[6], locals[5], locals[4], locals[3], param2 );
		x_obj_stuff( 10,locals, 9, 8, 7, 2, 6, 5, 4, 3, param2 );
		//if ( locals[2] == param1[0]play_hunger ) {
		if ( locals[2] == param1 ) {
			locals[1] = 1;
		} else {
			
			locals[1] = 0;
		} // end if
		
		return locals[1];
	} // end func
	
	IEnumerator func_068f() {
		
		int[] locals = new int[69];
		
		locals[16] = 0;
		locals[15] = 0;
		//locals[13] = show_inv( 2, locals[6], locals[1] );
		locals[13] = show_inv( 2,locals, 6, 1 );
		int counter=0;
		while ( locals[13] > 0 ) {
			
			locals[14] = 1;
			if ( locals[14] <= locals[13] ) {
				
				if ( locals[1+counter] >= 304 && locals[1+counter] <= 311 ) {
					
					locals[16] = 1;
					locals[17] = 160 + 512; //added +512 for link number matching
					if ( func_0615( locals[17], locals[6+counter] ) ==1 ) {
						
						locals[15] = locals[14];//Set no of found items.
						locals[11] = locals[6+counter];//Get the object position.
					} // end if
					
				} // end if
				
				locals[14] = locals[14] + 1;
			} // while
			counter++;
			locals[13]--;
		} // end if
		
		if ( locals[15] > 0 ) {
			
			locals[18] = 1;
			//give_to_npc( 2, locals[6], locals[18] );
			give_to_npc( 2,locals, 11, locals[18] );
			privateVariables[3] = 1;
			yield return StartCoroutine(say( "Marvelous!  I hope that it was not too much trouble to retrieve it." ));
			locals[19] = 38;
			yield return StartCoroutine(print( 1, locals[19] ));
			yield return StartCoroutine(say( "There, thou shouldst find that thy spellcasting skill is greater now." ));
			locals[20] = 9;
			locals[21] = 10000;
			x_skills( 2, locals[21], locals[20] );
			locals[22] = 9;
			locals[23] = 10000;
			x_skills( 2, locals[23], locals[22] );
			locals[24] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[24] );
			yield break;
		} else {
			
			if ( locals[16]==1 ) {
				
				yield return StartCoroutine(say( "I'm afraid that this is not the book I requested." ));
				locals[25] = 41;
				locals[26] = 42;
				locals[27] = 0;
				//locals[46] = babl_menu( 0, locals[25] );
				yield return StartCoroutine(babl_menu (0,locals,25));
				locals[46] = PlayerAnswer;
				switch ( locals[46] ) {
					
				case 1:
					
					yield return StartCoroutine(func_068f());
					break;
					
				case 2:
					
					Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
					break;
				} // end if
				
			} // {
				
			//	break;
				
		//	} // end switch
			
			yield return StartCoroutine(say( "Yes?  Where is it?" ));
			locals[47] = 44;
			locals[48] = 45;
			locals[49] = 0;
			//locals[68] = babl_menu( 0, locals[47] );
			yield return StartCoroutine(babl_menu (0,locals,47));
			locals[68] = PlayerAnswer;
			switch ( locals[68] ) {
				
			case 1:
				
				yield return StartCoroutine(func_068f());
				break;
				
			case 2:
				
				Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
				break;
			} // end if
			

			
		} // end switch
		
	} // end func
	
	IEnumerator func_0809() {
		
		int[] locals = new int[2];
		
		yield return StartCoroutine(say( "Greetings, @GS8!  I am indebted to thee for bringing me that book.  Do stop in sometime when I am not so busy." ));
		locals[1] = 3;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );
		yield break;
	} // end func
	/*
	IEnumerator func_081f() {
		
		int[] locals = new int[45];
		
		setup_to_barter( 0 );
		while ( !privateVariables[1] ) {
			
			locals[1] = 47;
			locals[2] = 48;
			locals[3] = 49;
			locals[4] = 50;
			locals[5] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				func_08d0();
				break;
				
			case 2:
				
				func_092a();
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
		
		locals[23] = 51;
		locals[24] = 0;
		yield return StartCoroutine(babl_menu (0,locals,23));   locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_08d0() {
		
		int[] locals = new int[16];
		
		locals[0] = -1;
		locals[6] = -1;
		locals[11] = 52;
		locals[12] = 53;
		locals[13] = 54;
		locals[14] = 55;
		locals[15] = 56;
		if ( do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ) ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_092a() {
		
		int[] locals = new int[25];
		
		yield return StartCoroutine(say( "Dost thou intend to rob me?" ));
		locals[1] = 58;
		locals[2] = 59;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			return;
			
			break;
			
		} // end switch
		
		locals[23] = 60;
		locals[24] = 61;
		if ( do_demand( 2, locals[24], locals[23] ) ) {
			
			privateVariables[1] = 1;
		} else {
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
		} // end if
		
	} // end func

*/
}
