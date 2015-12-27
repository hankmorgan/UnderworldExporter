using UnityEngine;
using System.Collections;

public class Conversation_14 : Conversation {

	//conversation #14
	//	string block 0x0e0e, name Dr. Owl
	public int[] global = new int[4];	
	public override IEnumerator main() {
		SetupConversation (3598);
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
	
	void func_008b() {
		
		npc.npc_gtarg = 1;
		npc.npc_goal = 5;
		npc.npc_attitude = 1;
		func_0012();
	} // end func
	
	void func_00a4() {
		
		npc.npc_attitude = 6;
	} // end func
	*/
	void func_00b1(int param1) {
		
		npc.npc_attitude = param1;//param1[0]global[0];
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
		
		int[] locals = new int[24];
		
		if ( privateVariables[0] == 0 ) {
			
			global[0] = 0;
			global[1] = 0;
			global[2] = 0;
		} // end if
		
		locals[1] = 0;
		if ( get_quest( 1, locals[1] )==1 ) {
			
			if ( global[1]==1 ) {
				
				if ( global[0]==1 ) {
					
					yield return StartCoroutine(func_0a8f());
				} else {
					
					yield return StartCoroutine(func_0a27());
				} // end if
				
			} else {
				
				yield return StartCoroutine(func_0a1a());
			} // end if
			
		} else {
			
			if ( privateVariables[0]==1 ) {
				
				if ( global[2]==1 ) {
					
					yield return StartCoroutine(func_0920());
				} else {
					
					yield return StartCoroutine(func_0992());
				} // end if
				
			} else {
				
				yield return StartCoroutine(say( "Bah!  Another steals the precious time of Dr. Owl!  What dost THOU want?" ));
				locals[2] = 2;
				locals[3] = 3;
				locals[4] = 4;
				locals[5] = 5;
				locals[6] = 0;
				yield return StartCoroutine(babl_menu (0,locals,2));   locals[23] = PlayerAnswer;
				switch ( locals[23] ) {
					
				case 1:
					
					yield return StartCoroutine(func_07cc());
					break;
					
				case 2:
					
					yield return StartCoroutine(func_07b6());
					break;
					
				case 3:
					
					yield return StartCoroutine(func_07cc());
					break;
					
				case 4:
					
					yield return StartCoroutine(func_035d());
					break;
					
				} // end if
				
			} // end if
			
			
		} // end switch
		
	} // end func
	
	IEnumerator func_035d() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Ah!  Sarcasm!  Very well, thou hast made thy point!  Now, quickly, what dost thou need?" ));
		locals[1] = 7;
		locals[2] = 8;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0689());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_03a5());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03a5() {
		
		int[] locals = new int[24];
		
		if ( global[0]==1 ) {
			
			yield return StartCoroutine(say( "I have no more runestones for thee!  Perhaps thou shouldst learn to use the ones thou hast." ));
			locals[1] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[1] );
			yield break;
		} else {
			
			yield return StartCoroutine(say( "Perhaps I can help thee after all, but first I will need to see thy runebag." ));
			locals[2] = 11;
			locals[3] = 12;
			locals[4] = 0;
			yield return StartCoroutine(babl_menu (0,locals,2));   locals[23] = PlayerAnswer;
			switch ( locals[23] ) {
				
			case 1:
				
				yield return StartCoroutine(func_0402());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_0751());
				break;
			} // end if
			

			
		} // end switch
		
	} // end func
	
	IEnumerator func_0402() {
		
		int[] locals = new int[60];
		
		locals[15] = 0;
		int counter=0;
		//locals[13] = show_inv( 2, locals[6], locals[1] );
		locals[13]= show_inv(2,locals,6,1);
		while ( locals[13] > 0 ) {
			
			locals[14] = 1;
			if ( locals[14] <= locals[13] ) {
				
				if ( locals[1+counter] == 143 ) {
					
					locals[15] = locals[14];
					locals[11] = locals[5];
				} // end if
				
				locals[14] = locals[14] + 1;
			} // while
			counter++;
			locals[13]--;
		} // end if
		
		if ( locals[15] > 0 ) {
			
			yield return StartCoroutine(say( "Ah, yes.  A budding mage indeed.  I suppose thou wouldst like to have a Flam runestone?" ));
			locals[16] = 14;
			locals[17] = 15;
			locals[18] = 0;
			//locals[37] = babl_menu( 0, locals[16] );
			yield return StartCoroutine (babl_menu (0,locals,16));
			locals[37] = PlayerAnswer;
			switch ( locals[37] ) {
				
			case 1:
				
				yield return StartCoroutine(func_04e8());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_0751());
				break;
			} // end if
			
		} //else {
			

			
		//} // end switch
		
		yield return StartCoroutine(say( "Yes?" ));
		locals[38] = 17;
		locals[39] = 18;
		locals[40] = 0;
		//locals[59] = babl_menu( 0, locals[38] );
		yield return StartCoroutine (babl_menu (0,locals,38));
		locals[59] = PlayerAnswer;
		switch ( locals[59] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0402());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0751());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_04e8() {
		
		int[] locals = new int[26];
		locals[1] = 237;
		global[0] = take_from_npc( 1, locals[1] );

		if ( (global[0] == 1) || (global[0] == 2) ) {
			
			if ( global[1]==1 ) {
				
				yield return StartCoroutine(say( "Here thou art.  I wish thee luck in using it." ));
				yield return StartCoroutine(func_0588());
			} // end if
			
			yield return StartCoroutine(say( "Here thou art.  Now, do not expect me to teach thee to use it.  That is not my job!  Was there anything else, or may I return to my work in peace?" ));
			locals[2] = 21;
			locals[3] = 22;
			locals[4] = 23;
			locals[5] = 0;
			yield return StartCoroutine(babl_menu (0,locals,2));   locals[23] = PlayerAnswer;
			switch ( locals[23] ) {
				
			case 1:
				
				locals[24] = 2;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[24] );
				yield break;
				break;
				
			case 2:
				
				yield return StartCoroutine(func_0689());
				break;
				
			case 3:
				
				yield return StartCoroutine(func_05d7());
				break;
			} // end if
			
		} //else {
			
			//break;
			
		//} // end switch
		
		yield return StartCoroutine(say( "Where is that accursed stone?  I must have lost it." ));
		locals[25] = 2;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[25] );
		yield break;
	} // end func
	
	IEnumerator func_0588() {
		
		int[] locals = new int[24];
		
		locals[1] = 25;
		locals[2] = 26;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			break;
			
		} // end switch
		
		yield return StartCoroutine(say( "Very well, very well.  Now get on with thee!" ));
		locals[23] = 3;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[23] );
		yield break;
	} // end func
	
	IEnumerator func_05d7() {
		
		int[] locals = new int[23];
		
		global[2] = 1;
		yield return StartCoroutine(say( "I am divining.  I seek my mute servant, Murgo, who is missing." ));
		locals[1] = 29;
		locals[2] = 30;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_06da());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_06da());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0624() {
		
		int[] locals = new int[24];
		
		yield return StartCoroutine(say( "Bah!  What is it THIS time?" ));
		locals[1] = 32;
		locals[2] = 33;
		locals[3] = 34;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0689());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_03a5());
			break;
			
		case 3:
			
			locals[23] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0689() {
		
		int[] locals = new int[24];
		
		yield return StartCoroutine(say( "I know where there is a bottle of the so-called Wine of Compassion!  Bah!  Such foolishness.  Only babes and fools believe in such fairy-stories." ));
		locals[1] = 36;
		locals[2] = 37;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_06da());
			break;
			
		case 2:
			
			locals[23] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_06da() {
		
		int[] locals = new int[26];
		
		yield return StartCoroutine(say( "If thou canst locate and return my missing servant Murgo, I shall tell thee where to find the Wine of Compassion." ));
		locals[1] = 39;
		locals[2] = 40;
		locals[3] = 41;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			locals[23] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			break;
			
		case 2:
			
			locals[24] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[24] );
			yield break;
			break;
			
		case 3:
			
			locals[25] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[25] );
			yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0751() {
		
		int[] locals = new int[24];
		
		yield return StartCoroutine(say( "Very well, have it thy way!  Was there anything else, or may I return to my work in peace?" ));
		locals[1] = 43;
		locals[2] = 44;
		locals[3] = 45;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			locals[23] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0689());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_05d7());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_07b6() {
		
		int[] locals = new int[2];
		
		yield return StartCoroutine(say( "I have no time for idle chit-chat!  Be off with thee!" ));
		locals[1] = 2;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );
		yield break;
	} // end func
	
	IEnumerator func_07cc() {
		
		int[] locals = new int[24];
		
		yield return StartCoroutine(say( "Bah!  Nonsense!  Get thyself gone from here, or I shall make thee wish thou had!" ));
		locals[1] = 48;
		locals[2] = 49;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			locals[23] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			break;
			
		case 2:
			
			yield return StartCoroutine(func_081d());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_081d() {
		
		int[] locals = new int[24];
		
		yield return StartCoroutine(say( "A pity, then, that thou art not more civil to thy betters.  What will it take to get thee to leave me in peace?" ));
		locals[1] = 51;
		locals[2] = 52;
		locals[3] = 53;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0689());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_03a5());
			break;
			
		case 3:
			
			locals[23] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0882() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Well?  Hast thou news of my servant?" ));
		locals[1] = 55;
		locals[2] = 56;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_08ca());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_07cc());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_08ca() {
		
		int[] locals = new int[24];
		
		global[1] = 1;
		yield return StartCoroutine(say( "Thou canst find the Wine of Compassion in the checkerboard room to the east of the meeting hall of the Academy.  Lift the southeastern floor tile and the Wine shall be revealed." ));
		locals[1] = 58;
		locals[2] = 59;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			locals[23] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			break;
			
		case 2:
			
			yield return StartCoroutine(func_03a5());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0920() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "'Tis thee again.  I note that Murgo has not been returned to me.  Wert thou not going to find him in return for directions to the Wine of Compassion?" ));
		locals[1] = 61;
		locals[2] = 62;
		locals[3] = 63;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_097c());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_097c());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_097c());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_097c() {
		
		int[] locals = new int[2];
		
		yield return StartCoroutine(say( "Obviously thou'rt not a great adventurer. A great adventurer would surely have succeeded in thy quest by now!" ));
		locals[1] = 1;
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[1] );
		yield break;
	} // end func
	
	IEnumerator func_0992() {
		
		int[] locals = new int[46];
		
		//locals[1] = !global[0];
		if (global[0]==1)
		{
			locals[1]=0;
		}
		else
		{
			locals[1]=1;
		}
		yield return StartCoroutine(say( "'Tis thee again.  What dost thou want?" ));
		locals[23] = 1;
		locals[2] = 66;
		locals[24] = 1;
		locals[3] = 67;
		locals[25] = locals[1];
		locals[4] = 68;
		locals[5] = 0;
		//locals[44] = babl_fmenu( 0, locals[2], locals[23] );
		yield return StartCoroutine (babl_fmenu(0,locals,2,23));
		locals[44]=PlayerAnswer;
		switch ( locals[44] ) {
			
		case 66:
			
			locals[45] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[45] );
			yield break;
			break;
			
		case 67:
			
			yield return StartCoroutine(func_05d7());
			break;
			
		case 68:
			
			yield return StartCoroutine(func_03a5());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0a1a() {
		
		yield return StartCoroutine(say( "Ah, it is the one who hast freed my servant Murgo!  Thou'rt more compassionate towards thy fellows than I might expect.  Thy reward shall be fitting." ));
		yield return StartCoroutine(func_08ca());
	} // end func
	
	IEnumerator func_0a27() {
		
		int[] locals = new int[24];
		
		yield return StartCoroutine(say( "Greetings, @GS11.  What dost thou want?  I warn thee, I am quite busy." ));
		locals[1] = 71;
		locals[2] = 73;
		locals[3] = 74;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(say( "It's quite simple." ));
			yield return StartCoroutine(func_08ca());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_03a5());
			break;
			
		case 3:
			
			locals[23] = 2;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[23] );
			yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0a8f() {
		
		yield return StartCoroutine(func_0a27());
	} // end func

}
