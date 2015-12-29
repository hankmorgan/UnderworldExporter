using UnityEngine;
using System.Collections;

public class Conversation_212 : Conversation {

	//conversation #212
	//string block 0x0ed4, name Kallistan
	public int[] global =new int[3];	
	public override IEnumerator main() {
		SetupConversation (3796);
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
	
	void func_00b1() {
		
		npc.npc_attitude = param1[0]global[0];
		func_0012();
	} // end func
*/	
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
		
		if ( privateVariables[0] == 1 ) {
			
			yield return StartCoroutine(func_0506());
		} else {
			
			yield return StartCoroutine(func_02b3());
		} // end if
		
	} // end func
	
	IEnumerator func_02b3() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Who be ye?" ));
		locals[1] = 2;
		locals[2] = 3;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_02fb());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_05be());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_02fb() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "I be Kallistan.  What do ye here, @GS12?" ));
		global[2] = 1;
		locals[1] = 5;
		locals[2] = 6;
		locals[3] = 7;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_035c());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_03a4());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_03ec());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_035c() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Go back the way ye came, then, ye craven!" ));
		locals[1] = 9;
		locals[2] = 10;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_03ec());
			break;
			
		case 2:
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00c2();yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03a4() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Any friend o' that whoreson be no friend o' mine!" ));
		locals[1] = 12;
		locals[2] = 13;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_03ec());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_05be());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03ec() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "An' what proof have ye that ye're nae from the very wizard himself?" ));
		locals[1] = 15;
		locals[2] = 16;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0434());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0606());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0434() {
		
		int[] locals = new int[25];
		
		yield return StartCoroutine(say( "Well, ye'll be knowin' the password t' his hoard, then, won't ye?" ));
		locals[2] = 18;
		locals[3] = 20;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,2));   locals[23] = PlayerAnswer;
		switch ( locals[23] ) {
			
		case 1:
			yield return StartCoroutine (babl_ask (0));
			//locals[1] = babl_ask( 0 );
			locals[24] = 19;
			if ( contains( 2, PlayerTypedAnswer, locals[24] )==1 ) {
				
				yield return StartCoroutine(func_0576());
			} else {
				
				yield return StartCoroutine(func_05be());
			} // end if
			
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0606());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_049d() {
		
		int[] locals = new int[23];
		
		if ( global[2] == 1 ) {
			
			yield return StartCoroutine(say( "What ye want now, @GS12?" ));
		} else {
			
			yield return StartCoroutine(say( "What ye want now?" ));
		} // end if
		
		locals[1] = 23;
		locals[2] = 24;
		locals[3] = 25;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_035c());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_03a4());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_03ec());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0506() {
		
		int[] locals = new int[24];
		
		if ( global[0] == 0 ) {
			
			yield return StartCoroutine(func_049d());
		} else {
			
			if ( global[1] == 1 ) {
				
				yield return StartCoroutine(say( "I've nothing more to say to ye, ungrateful lout. Begone!" ));
				Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);
				func_00d1();
				yield break;
			} else {
				
				if ( global[2] == 1 ) {
					
					yield return StartCoroutine(say( "What can I do for thee now, @GS12?" ));
				} else {
					
					yield return StartCoroutine(say( "And what want ye now?" ));
				} // end if
				
				locals[2] = 29;
				locals[3] = 30;
				locals[4] = 0;
				yield return StartCoroutine(babl_menu (0,locals,2));   locals[23] = PlayerAnswer;
				switch ( locals[23] ) {
					
				case 1:
					
					Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
					break;
					
				case 2:
					
					yield return StartCoroutine(func_0815());
					break;
				} // end if
				
			} // end if
			
			//break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0576() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Well, then, ye be a hero to th' Clan, an' most welcome here!  What can I do for ye?" ));
		locals[1] = 32;
		locals[2] = 33;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_06f2());
			break;
			
		case 2:
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_05be() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Get ye gone from here, ye mangy dog!" ));
		locals[1] = 35;
		locals[2] = 36;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00c2();yield break;
			break;
			
		case 2:
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00c2();yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0606() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Trust ye?  Well, If I must, I must.  But first, ye shall swear to me an oath, that ye mean no weal t' Tyball an' his lackeys." ));
		locals[1] = 38;
		locals[2] = 39;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_064e());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_05be());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_064e() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Swear, then!" ));
		locals[1] = 41;
		locals[2] = 42;
		locals[3] = 43;
		locals[4] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_06aa());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_06aa());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_06aa());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_06aa() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "Very well.  Know then, that if ye be forsworn, all that ye hast sworn upon will turn against ye!" ));
		locals[1] = 45;
		locals[2] = 46;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_06f2());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_05be());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_06f2() {
		
		int[] locals = new int[24];
		
		yield return StartCoroutine(say( "Here.  Take ye this splinter of crystal." ));
		locals[1] = 273;
		if ( take_from_npc( 1, locals[1] ) == 2 ) {
			
			yield return StartCoroutine(say( "Ye seem heavily laden, so I'll leave it here for ye." ));
		} // end if
		
		locals[2] = 49;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,2));   locals[23] = PlayerAnswer;
		if ( locals[23] == 1 ) {
			
			yield return StartCoroutine(func_073d());
		} // end if
		
	} // end func
	
	IEnumerator func_073d() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "I found it three days ago while at my labors in the mines. At night it makes a faint, eerie keening. I've heard rumors of others who've found its like, and before long they're off searching for the tombs from which it came." ));
		locals[1] = 51;
		locals[2] = 52;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_07cd());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0785());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0785() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "It will do thee no harm, and may even help thee.  I believe  it may give thee access to the tombs." ));
		locals[1] = 54;
		locals[2] = 55;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0815());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0815());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_07cd() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "I believe the tombs to be of my ancient ancestors, built here long before the colony of the Abyss was formed. I've dreamt of them since finding the crystal." ));
		locals[1] = 57;
		locals[2] = 58;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0815());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0815());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0815() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "The way I figure it, the tombs have been defiled by an evil presence. This entity places the crystal where it'll be found, in order  to draw unwary souls to its lair. I ask ye - find these tombs and cleanse them of this evil, so that others do not fall into this trap." ));
		locals[1] = 60;
		locals[2] = 61;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_085d());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_085d());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_085d() {
		
		int[] locals = new int[23];
		
		yield return StartCoroutine(say( "If ye can do this, I'm sure the beast responsible will have collected a sizable hoard from his victims. Ye may find the items useful in your quest against Tyball. But beware - disturb not the tombs  themselves. Search for the entrance to the south of these prisons, where the pit trap spiders prowl.  Carry the crystal with ye in your search - it may prove to be helpful." ));
		global[0] = 1;
		locals[1] = 63;
		locals[2] = 64;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_00e0();yield break;
			break;
			
		case 2:
			
			global[1] = 1;
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);
			func_00d1();
			yield break;
			break;
			
		} // end switch
		
	} // end func
	/*
	void func_08af() {
		
		int[] locals = new int[45];
		
		setup_to_barter( 0 );
		while ( !privateVariables[1] ) {
			
			locals[1] = 65;
			locals[2] = 66;
			locals[3] = 67;
			locals[4] = 68;
			locals[5] = 0;
			yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				func_0960();
				break;
				
			case 2:
				
				func_09ba();
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
		
		locals[23] = 69;
		locals[24] = 0;
		yield return StartCoroutine(babl_menu (0,locals,23));   locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	void func_0960() {
		
		int[] locals = new int[16];
		
		locals[0] = -1;
		locals[6] = -1;
		locals[11] = 70;
		locals[12] = 71;
		locals[13] = 72;
		locals[14] = 73;
		locals[15] = 74;
		if ( do_offer( 7, locals[15], locals[14], locals[13], locals[12], locals[11], locals[6], locals[1] ) ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	void func_09ba() {
		
		int[] locals = new int[25];
		
		yield return StartCoroutine(say( "Dost thou intend to rob me?" ));
		locals[1] = 76;
		locals[2] = 77;
		locals[3] = 0;
		yield return StartCoroutine(babl_menu (0,locals,1));   locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			return;
			
			break;
			
		} // end switch
		
		locals[23] = 78;
		locals[24] = 79;
		if ( do_demand( 2, locals[24], locals[23] ) ) {
			
			privateVariables[1] = 1;
		} else {
			
			Time.timeScale =SlomoTime; yield return new WaitForSeconds(WaitTime);func_008b();yield break;
		} // end if
		
	} // end func
*/
}
