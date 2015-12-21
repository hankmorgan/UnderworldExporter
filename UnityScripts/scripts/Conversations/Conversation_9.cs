using UnityEngine;
using System.Collections;

public class Conversation_9 : Conversation {
	
	//conversation #9
	//string block 0x0e09, name Vernix
	//3593
	
	
	public override IEnumerator main() {
		SetupConversation (3593);
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
	
	/*void func_00b1() {
		
		npc.npc_attitude = param1[0];//play_hunger;
		func_0012();
	} // end func*/
	
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
	
	/*void func_0106() {
		
		//int locals[4];
		int[] locals=new int[5];
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
		
		//int locals[22];
		int[] locals=new int[23];
		if ( npc.npc_talkedto == 1 ) {
			
			yield return StartCoroutine(func_04fd());
		} else {
			
			yield return StartCoroutine(say( "Yes?" ));
			locals[1] = 2;
			locals[2] = 3;
			locals[3] = 4;
			locals[4] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_0305());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_034d());
				break;
				
			case 3:
				
				yield return StartCoroutine(func_0305());
				break;
			} // end if
			
			//break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0305() {
		
		//int locals[22];
		int[] locals=new int[23];
		yield return StartCoroutine(say( "Clearly, thou art a boor, unfit for the gentle company present here.  Away with thee until thou hast learned to ape the manners of thy betters." ));
		locals[1] = 6;
		locals[2] = 7;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00d1();
			yield break;
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0405());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_034d() {
		
		//int locals[22];
		int[] locals=new int[23];
		yield return StartCoroutine(say( "Fair greetings to thee.  For what reason hast thou intruded on our court?" ));
		locals[1] = 9;
		locals[2] = 10;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_04b6());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0395());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0395() {
		
		//int locals[22];
		int[] locals=new int[23];
		yield return StartCoroutine(say( "True!  I AM rather wise, come to think of it.  What dost thou wish to know?" ));
		locals[1] = 12;
		locals[2] = 13;
		locals[3] = 14;
		locals[4] = 15;
		locals[5] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_04b6());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_04b6());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_04b6());
			break;
			
		case 4:
			
			yield return StartCoroutine(func_0507());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0405() {
		
		//int locals[22];
		int[] locals=new int[23];
		yield return StartCoroutine(say( "Well... Perhaps thou canst be forgiven.  This place IS full of the most frightfully rude people.  Thou mayst remain.  What is thy need?" ));
		locals[1] = 17;
		locals[2] = 18;
		locals[3] = 19;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0395());
			break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00c2();
			yield break;
			break;
			
		case 3:
			
			yield return StartCoroutine(func_04b6());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0461() {
		
		//int locals[3];
		int[] locals=new int[4];
		locals[2] = 4;
		locals[1] = random( 1, locals[2] );

		locals[3] = locals[1];
		if ( 1 == locals[3] ) {
			
		yield return StartCoroutine(say( "I've changed my mind about thee!  Thou art indeed a ruffian!  Get thee hence!" ));
		} else {
			
			if ( 2 == locals[3] ) {
				
			yield return StartCoroutine(say( "Thou hast the manners of an acid slug!  Get out of here!" ));
			} else {
				
				if ( 3 == locals[3] ) {
					
				yield return StartCoroutine(say( "Thou art entirely too generous with thy time!" ));
				} else {
					
					if ( 4 == locals[3] ) {
						
					yield return StartCoroutine(say( "Perhaps thou couldst stand a little further downwind?" ));
					} // end if
					
				} // end if
				
			} // end if
			
		} // end if
		yield break;
	} // end func
	
	IEnumerator func_04b6() {
		
		//int locals[22];
		int[] locals=new int[23];
		yield return StartCoroutine(func_0461());
		locals[1] = 24;
		locals[2] = 25;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0405());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_06c9());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_04fd() {
		
		yield return StartCoroutine(func_034d());
	} // end func
	
	IEnumerator func_0507() {
		
		//int locals[22];
		int[] locals=new int[23];
				yield return StartCoroutine(say( "It does suit me, doesn't it?  I had it made especially for me.  One simply doesn't find work like this underground. \n"
		    +" Well, perhaps the Mountain-folk do make a few nice things, but they tend toward metals rather than clothes. \n"
		    +" And of course the Seers -- the Ancient Illuminated Seers of the Moonstone, they call themselves -- they do nice work, too.  But they generally tend more toward the literary than the sartorial arts." ));
		locals[1] = 27;
		locals[2] = 28;
		locals[3] = 29;
		locals[4] = 30;
		locals[5] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_04b6());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_04b6());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_04b6());
			break;
			
		case 4:
			
			yield return StartCoroutine(func_0577());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0577() {
		
		//int locals[22];
		int[] locals=new int[23];
		yield return StartCoroutine(say( "Well, one does what one can.  Of course those awful Gray Goblins took all the really nice things with them when they stole away in the night -- this was just after Sir Cabirus died, you know, when things were falling apart -- and we've had to make do since then. \n"
		    +" One of these days I'm going to get some poison into Ketchaval or his ugly wife (which amounts to the same thing -- he's terribly henpecked, you know), and then we'll see what's what.  King of the Gray Goblins, indeed./m" ));
		yield return StartCoroutine(say( "Why he's an upstart!  His father was a horse-thief! But enough of this ... You wanted to know something?  How can I help you?" ));
		locals[1] = 33;
		locals[2] = 34;
		locals[3] = 35;
		locals[4] = 36;
		locals[5] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_04b6());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_04b6());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_04b6());
			break;
			
		case 4:
			
			yield return StartCoroutine(func_05ea());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_05ea() {
		
		//int locals[22];
		int[] locals=new int[23];
		yield return StartCoroutine(say( "Oh, mention it not!  It is so seldom that I get a chance to speak to a really intelligent person!\n"
		    +" I mean, our allies the Lizardmen are nice enough, but the poor fellows can't speak a word of the common tongue. They understand it well enough, but the poor things don't have the mouth to speak it.  And their language is so difficult! I know \"Sseth\" and \"'click\" mean \"yes\" and \"no,\" but I don't know which is which!/m" ));
		yield return StartCoroutine(say( "Then there are the Knights of the Crux Ansata -- they can talk well enough, but all they ever say is how many Trolls they've killed.  Frightful bore, even if it does help keep the pest population down -- both kinds of pests, Knights AND Trolls, you know." ));
		locals[1] = 39;
		locals[2] = 40;
		locals[3] = 41;
		locals[4] = 42;
		locals[5] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_065d());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_04b6());
			break;
			
		case 3:
			
			yield return StartCoroutine( func_04b6());
			break;
			
		case 4:
			
			yield return StartCoroutine(func_04b6());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_065d() {
		
		// int locals[22];
		int[] locals=new int[23];
		yield return StartCoroutine(say( "Oh, indeed it is!  Sometimes I wonder how I even manage.  It wasn't always like this, you know. \n"
		    +" When Sir Cabirus was alive, things were ever so much better.  He had all of us working together so well.  A born leader was that man. \n"
		    +" When he founded this colony you could have made a wager anywhere in Britannia that it wouldn't work, but he made it so. \n"
		    +" I still think one of those bastard Grays must have done him in. There were certain items, too.../m" ));
		yield return StartCoroutine(say( "Well, I suppose it will do no harm to tell thee.  Sir Cabirus collected eight great Talismans, each embodying a certain Virtue -- he was a great one for Virtue, was our Cabirus -- and it was well known that he intended them to come to the leaders of the various groups here in the Abyss.  Well, WE never saw them.  If they still exist, they must be lost. \n"
		    +" But I must be boring thee." ));
		locals[1] = 45;
		locals[2] = 46;
		locals[3] = 47;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_06c9());
			break;
			
		case 2:
			
			yield return StartCoroutine( func_0711());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_06bc());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_06bc() {
		
		yield return StartCoroutine(say( "Well, bless you, you're such a charming conversationalist.  Please do visit again." ));
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00e0();
		yield break;
	} // end func
	
	IEnumerator func_06c9() {
		
		// int locals[22];
		int[] locals=new int[23];
		yield return StartCoroutine(say( "Well!  I never!" ));
		locals[1] = 50;
		locals[2] = 51;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00d1();
			yield break;
			break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00c2();
			yield break;
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0711() {
		
		// int locals[22];
		int[] locals=new int[23];
		yield return StartCoroutine(say( "Oh, thou'rt just saying that.  I'm sure there's much more for thee to do than listen me me natter on. \n"
		    +" And if you should happen to meet \"King\" Ketchaval or \"Queen\" Retichall of the Gray Goblins, be a dear and stick a knife in them, would you?" ));
		locals[1] = 53;
		locals[2] = 54;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
		//	break;
			
		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;
		//	break;
			
		} // end switch
		
	} // end func
	
	
}
