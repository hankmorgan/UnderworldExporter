using UnityEngine;
using System.Collections;

public class Conversation_27 : Conversation {

	//conversation #27
	//string block 0x0e1b, name Garamon
			

	
	public override IEnumerator main() {
		SetupConversation (3611);
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
		
		npc.npc_attitude = param1;//param1[0]play_hunger;
		func_0012();
	} // end func

	void func_00c2() {
		
		npc.npc_attitude = 2;
		func_0012();
	} // end func
	/*
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
		
		if ( privateVariables[0]==1 ) {
			
			yield return StartCoroutine(func_0755());
		} // end if
		
		privateVariables[2] = 1;
		privateVariables[3] = 1;
		yield return StartCoroutine(say( "Thou hast done well.  And now that my bones are at last at rest I can speak freely to thee.  But my spirit cannot rest while yet this peril remains. \n /m"
		                               + " We must open a gate, near where the foul creature my brother summoned lies bound. We must return it to the plane from whence it came." ));
		locals[1] = 2;
		locals[2] = 3;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_02f6());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_032a());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_02f6() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "No other power can defeat it.  Even banishing it to another place will do it no harm -- may in fact restore to it its full power, if that place be like to its own -- but it will at least remove the threat to Britannia!" ));
		locals[1] = 5;
		locals[2] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		if ( locals[22] == 1 ) {
			
			yield return StartCoroutine(func_032a());
		} // end if
		
	} // end func
	
	IEnumerator func_032a() {
		
		int[] locals = new int[46];
		
		locals[1] = get_quest( 1, locals[2] );
		locals[2] = 5;
		yield return StartCoroutine(say( "For this I will need a great deal of magical energy. This will be no gentle luring such as brought thee here, but an unimaginable vortex of interplanar energy." ));
		locals[24] = locals[1];
		locals[3] = 7;
		locals[25] = 1;
		locals[4] = 8;
		locals[5] = 0;
		//locals[45] = babl_fmenu( 0, locals[3], locals[24] );
		yield return StartCoroutine( babl_fmenu( 0,locals,3,24 ));
		locals[45] = PlayerAnswer;
		switch ( locals[45] ) {
			
		case 7:
			
			yield return StartCoroutine(func_0398());
			break;
			
		case 8:
			
			yield return StartCoroutine(func_0398());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0398() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Tyball's Orb would be perilous to use, even if it were intact.  The power we tap must be carefully chosen...  As thou may have guessed, I am a little out of touch with thy world.  I had hoped thou might provide an answer." ));
		locals[1] = 10;
		locals[2] = 11;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_03e0());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_03e0());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03e0() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "It would be best if the source were absolutely pure -- my brother found the danger in tapping powers whose source thou knowest not -- and 'twould be best if Britannia herself were somehow involved." ));
		locals[1] = 13;
		locals[2] = 14;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0428());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_04c5());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0428() {
		
		int[] locals = new int[44];
		
		yield return StartCoroutine(say( "'Twould help to invoke one of the Elements.  We work for Britannia's succor, and we must hope she would lend what aid she could." ));
		locals[22] = privateVariables[2];
		locals[1] = 16;
		locals[23] = privateVariables[3];
		locals[2] = 17;
		locals[24] = 1;
		locals[3] = 18;
		locals[4] = 0;
		//locals[43] = babl_fmenu( 0, locals[1], locals[22] );
		yield return StartCoroutine( babl_fmenu( 0,locals,1,22 ));
		locals[43] = PlayerAnswer;
		switch ( locals[43] ) {
			
		case 16:
			
			yield return StartCoroutine(func_04a1());
			break;
			
		case 17:
			
			yield return StartCoroutine(func_04b3());
			break;
			
		case 18:
			
			break;
			
		} // end switch
		
		yield return StartCoroutine(func_04c5());
	} // end func
	
	IEnumerator func_04a1() {
		
		privateVariables[2] = 0;
		yield return StartCoroutine(say( "The classical four: earth, air, fire, and water." ));
		//return;
		yield break;
		
	} // end func
	
	IEnumerator func_04b3() {
		
		privateVariables[3] = 0;
		yield return StartCoroutine(say( "Indeed she is, a green and living entity.  Not conscious as we know it, but perhaps aware that we work to her ends." ));
		//return;
		yield break;
		
	} // end func
	
	IEnumerator func_04c5() {
		
		yield return StartCoroutine(say( "Yes, the source, which, if we are fortunate, may even wake Britannia to our aid, should be as pure as possible.  Else we risk ending like my brother." ));
		yield return StartCoroutine(func_04d2());
	} // end func
	
	IEnumerator func_04d2() {
		
		int[] locals = new int[26];
		
		while ( true ) {
			
			locals[2] = 22;
			locals[3] = 23;
			locals[4] = 0;
			//locals[23] = babl_menu( 0, locals[2] );
			yield return StartCoroutine( babl_menu( 0,locals,2 ));
			locals[23] = PlayerAnswer;
			switch ( locals[23] ) {
				
			case 1:
				
				yield return StartCoroutine(func_055b());
				break;
				
			case 2:
				
				//locals[1] = babl_ask( 0 );
				yield return StartCoroutine( babl_ask((0)));

				locals[24] = 24;
				locals[25] = 25;
				//(contains( 2, locals[1], locals[24] ) || contains( 2, locals[1], locals[25] ));  // expr. has value on stack!
				if ( (contains( 2, PlayerTypedAnswer, locals[24] )==1) || (contains( 2, PlayerTypedAnswer, locals[25] )==1) ) {
					
					yield return StartCoroutine(func_057c());
				} else {
					
					yield return StartCoroutine(say( "No, that will not do.  Perhaps something else..." ));
					privateVariables[5] = privateVariables[5] + 1;
				} // end if
				
				break;
				
			} // end switch
			
		} // while
		
	} // end func
	
	IEnumerator func_055b() {
		
		if ( privateVariables[5] < 3 ) {
			
			yield return StartCoroutine(say( "Perhaps thou shouldst ponder the problem for a bit longer.  But think carefully and quickly, for the fate of Britannia is at stake!" ));
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
		} else {
			
			privateVariables[5] = 0;
			yield return StartCoroutine(say( "Perhaps some item or items imbued with Virtue might be of use, if any exist.  Dost thou know of any such items?" ));
			yield return StartCoroutine(func_04d2());
		} // end if
		
	} // end func
	
	IEnumerator func_057c() {
		
		privateVariables[4] = 1;
		yield return StartCoroutine(say( "Yes, of course!  Those would do admirably.  Now, we must find a means to unleash their stored Virtue.  We must find some latent source of power that can be released by applying the energy of the Talismans." ));
		yield return StartCoroutine(func_058e());
	} // end func
	
	IEnumerator func_058e() {
		
		int[] locals = new int[26];
		
		while ( true ) {
			
			locals[2] = 30;
			locals[3] = 31;
			locals[4] = 0;
			//locals[23] = babl_menu( 0, locals[2] );
			yield return StartCoroutine(babl_menu (0,locals,2));   locals[23] = PlayerAnswer;
			switch ( locals[23] ) {
				
			case 1:
				
				yield return StartCoroutine(func_0617());
				break;
				
			case 2:
				
				//locals[1] = babl_ask( 0 );
				yield return StartCoroutine( babl_ask((0)));
				locals[24] = 32;
				locals[25] = 33;
				//(contains( 2, locals[1], locals[24] ) || contains( 2, locals[1], locals[25] ));  // expr. has value on stack!
				if (  (contains( 2, PlayerTypedAnswer, locals[24] )==1 ) || (contains( 2, PlayerTypedAnswer, locals[25] )==1) ) {
					
					yield return StartCoroutine(func_0638());
				} else {
					
					yield return StartCoroutine(say( "No, we need a great source of power that might easily be released." ));
					privateVariables[7] = privateVariables[7] + 1;
				} // end if
				
				break;
				
			} // end switch
			
		} // while
		
	} // end func
	
	IEnumerator func_0617() {
		
		if ( privateVariables[7] < 3 ) {
			
			yield return StartCoroutine(say( "Well, I hope that thou art able to solve the problem quickly, for the fate of Britannia itself hangs in the balance!" ));
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
		} else {
			
			privateVariables[7] = 0;
			yield return StartCoroutine(say( "Perhaps some natural landmark that contains the ability to release great power will do the trick." ));
			yield return StartCoroutine(func_058e());
		} // end if
		
	} // end func
	
	IEnumerator func_0638() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Yes, of course!  If all eight Talismans be thrust into the volcano's maw, one at a time, I could ride the wave of such power to open the vortex. Ah, thou art wise as well as valorous!  Wilt thou make such a sacrifice?" ));
		privateVariables[6] = 1;
		locals[1] = 38;
		locals[2] = 39;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0685());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_06cd());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0685() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "But thou must!  Thy sacrifice shall save all of this world!  Surely thou cannot place thine own travails and successes against such a stake as that!" ));
		locals[1] = 41;
		locals[2] = 42;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
			break;
			
		case 2:
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00c2();yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_06cd() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Excellent!  Make haste to the lowest place, where thou must cast all eight into the Abyss -- hold back not one, upon thy peril!  When they are consumed by earth's own fire, I shall leash the torrent to gape wide my gate.  With Fortune's smile, we shall send our foe screeching back to its Hell!" ));
		locals[1] = 44;
		locals[2] = 45;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0715());
			break;
			
		case 2:
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0715() {
		
		int[] locals = new int[24];
		
		yield return StartCoroutine(say( "The Chamber of Virtue is located on the lowest level of the Abyss.  It lies at the very center of the volcano, where the energy fields of the Stygian are their strongest.  'Tis said that a special three-part key is needed to enter, but I know not the veracity of this legend." ));
		locals[1] = 47;
		locals[2] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		if ( locals[22] == 1 ) {
			
		} // end if
		
		yield return StartCoroutine(say( "Hurry!  There is little time to lose!" ));
		locals[23] = 3;
		Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);
		func_00b1( locals[23] );
		yield break;
	} // end func
	
	IEnumerator func_0755() {
		
		if ( privateVariables[6]==1 ) {
			
			yield return StartCoroutine(say( "Hurry, @GS8, there is no time to lose!  Thou must cast all eight of Cabirus' Talismans into the volcano on the lowest level of the Abyss.  Do not fail in thy quest!" ));
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
		} // end if
		
		if ( privateVariables[4]==1 ) {
			
			yield return StartCoroutine(say( "Yes?  Hast thou discovered a source of energy with which the power of Cabirus' Talismans can be released?" ));
			yield return StartCoroutine(func_058e());
		} // end if
		
		yield return StartCoroutine(say( "Yes?  Hast thou thought of a pure source of power and virtue which may provide me with the requisite amount of magical energy?" ));
		yield return StartCoroutine(func_04d2());
	} // end func
}
