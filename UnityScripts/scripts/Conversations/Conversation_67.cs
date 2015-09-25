using UnityEngine;
using System.Collections;

public class Conversation_67 : Conversation {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public override void  main() {
		
		privateVariables[1] = 0;
		func_029d();
		func_0012();
	} // end func
	
	void func_0012() {
		
		privateVariables[0] = 1;
	} // end func
	/*
	void func_0020() {
		
		int[] locals=new int[1];
		
		if ( (((npc_goal == 5 || npc_goal == 6) || npc_goal == 9) && npc_gtarg == 1 || npc_attitude == 0) ) {
			
			locals[1] = 0;
		} else {
			
			locals[1] = 1;
		} // end if
		
		return locals[1];
	} // end func
	*/
	void func_0063() {
		
		npc_gtarg = 1;
		npc_attitude = 1;
		npc_goal = 6;
		func_0012();
	} // end func
	
	void func_007c() {
		
		npc_goal = 1;
		func_0012();
	} // end func
	
	void func_008b() {
		
		npc_gtarg = 1;
		npc_goal = 5;
		npc_attitude = 1;
		func_0012();
	} // end func
	
	void func_00a4() {
		
		npc_attitude = 6;
	} // end func
	
	void func_00b1(int[] paramArray, int Start) {
		
		npc_attitude = param1[0];//play_hunger;
		func_0012();
	} // end func
	
	void func_00c2() {
		
		npc_attitude = 2;
		func_0012();
	} // end func
	
	void func_00d1() {
		
		npc_attitude = 1;
		func_0012();
	} // end func
	
	void func_00e0() {
		
		func_0012();
	} // end func
	
	void func_00ea() {
		
		param1[1] = game_days;
		param1[2] = game_mins;
	} // end func
	/*
	void func_0106() {
		
		int[] locals =new int[4];
		
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
*/
	/*
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
	*/
	void func_0243() {
		
		param1[1] = game_days - param2[1];
		param1[2] = game_mins - param2[2];
		if ( param1[2] < 0 ) {
			
			param1[2] = param1[2] + 1440;
			param1[1] = param1[1] - 1;
		} // end if
		
	} // end func
	
	void func_029d() {
		
		int[] locals=new int[277];
		
		locals[1] = sex( 2, locals[3], locals[2] );
		locals[2] = 1;
		locals[3] = 2;
		if ( privateVariables[0] == 1) {
			
		} else {
			
			privateVariables[2] = 0;
			privateVariables[3] = 0;
			say( "Hail, stranger!  What be thy business?  I have not seen thee in this place before." );
			locals[4] = 4;
			locals[5] = 5;
			locals[6] = 6;
			locals[7] = 0;
			locals[25] = babl_menu( 0,locals,4 );
			switch ( locals[25] ) {
				
			case 1:
				
				goto label_0322;
				
				break;
				
			case 2:
				
				goto label_0327;
				
				break;
				
			case 3:
				
				goto label_032c;
				
				break;
				
			} // end switch
			
		label_0322:;
			
			say( "Exploring, eh?  Ha, that's a good one.  But if thou dost not wish to speak of thy crime, 'tis not my business to ask./m" );
			goto label_0331;
			
		label_0327:;
			
			say( "Ah, a rescue mission, is it?  Should the Baron's guards not be with thee, to aid thee in thy search?  More likely one of them threw thee in here, eh?/m" );
			goto label_0331;
			
		label_032c:;
			
			say( "Ah, unjustly imprisoned, art thou?  'Tis the usual story, my @SS1, but that is not to say it may not be true in thy case, I suppose./m" );
			goto label_0331;
			
		label_0331:;

			say( "Thou needst not be ashamed of thy misfortune, @SS1; thou art in the same pot with all of us now.  If thou art to have a chance of surviving in the Abyss for long, thou must learn the lay of the land." );
			locals[26] = 11;
			locals[27] = 12;
			locals[28] = 0;
			locals[47] = babl_menu( 0, locals,26 );
			switch ( locals[47] ) {
				
			case 1:
				
				goto label_03ba;
				
				break;
				
			case 2:
				
				goto label_0371;
				
				break;
				
			} // end switch
			
		label_0371:;
			
			say( "Perhaps thou wilt.  I have heard many say the same as thee, and a few are still alive today." );
			locals[48] = 14;
			locals[49] = 15;
			locals[50] = 0;
			locals[69] = babl_menu( 0, locals, 48 );
			switch ( locals[69] ) {
				
			case 1:
				
				goto label_03ba;
				
				break;
				
			case 2:
				
				locals[70] = 2;
				func_00b1( locals,70 );
				break;
				
			} // end switch
			

		label_03ba:;
			
			privateVariables[2] = 1;
			say( "First off, I would suggest picking up anything thou dost find that seems of use.  Items here are scarce enough - thou wouldst be well advised to take what thou can.\n Scavenge all you want, but stealing is ill-advised. Most of the Abyss' inhabitants guard jealously the few possessions that they have.\n Battlesites are the best for scavenging. That's why I'm here - A battle took place here not long ago - a battle between the Goblins and the above-worlders." );
			locals[71] = 17;
			locals[72] = 18;
			locals[73] = 0;
			locals[92] = babl_menu( 0, locals,71 );
			switch ( locals[92] ) {
				
			case 1:
				
				goto label_0404;
				
				break;
				
			case 2:
				
				goto label_03ff;
				
				break;
				
			} // end switch
			
		label_03ff:;
			
			say( "I do not know.  It is rare that the Baron sends his men into the Abyss.  It must have been important.  Though, by the looks of it, the Goblins defeated them handily./m" );
			goto label_0404;
			
		label_0404:;

			say( "The Goblins control most of these upper caves.  Two races there are, the Green and the Gray.  If they do not destroy each other, it is not for lack of trying.\n Be thou especially careful of the Gray Goblins.  I was recently imprisoned by them for trespassing." );
			locals[93] = 21;
			locals[94] = 22;
			locals[95] = 0;
			locals[114] = babl_menu( 0, locals,93 );
			switch ( locals[114] ) {
				
			case 1:
				
				break;
				
			case 2:
				
				break;
				
			} // end switch
			
			say( "My prison cell was evidently a converted storeroom, for it had a stock of useful items, including a long pole.  Using the pole, I was able to reach a button which opened the door to my cell.  I sneaked away and returned to my people.  I do not think I will venture there again." );
			locals[115] = 24;
			locals[116] = 25;
			locals[117] = 0;
			locals[136] = babl_menu( 0, locals,115 );
			switch ( locals[136] ) {
				
			case 1:
				
				break;
				
			case 2:
				
				break;
				
			} // end switch
			
			say( "The humans, like thee and myself, have staked out a small area in which we live in relative peace.  Below us are the Mountainmen, and after that I do not know." );
			locals[137] = 27;
			locals[138] = 28;
			locals[139] = 0;
			locals[158] = babl_menu( 0, locals,137 );
			switch ( locals[158] ) {
				
			case 1:
				
				goto label_04c1;
				
				break;
				
			case 2:
				
				goto label_04bc;
				
				break;
				
			} // end switch
			
		label_04bc:;
			
			say( "A nasty place this is, thou canst be certain of that.  In the parts of the upper caves, uninhabited by Goblins, there are giant spiders and worms.  Our small group is one of the few devoted to peace./m" );
			goto label_04c1;
			
		label_04c1:;

			say( "Thou canst find my people by going west from the entrance to the Abyss, and then north. There is a small chasm to jump over, but thou dost seem to be a dextrous @SS1.  Past the chasm is the sign of civilization everywhere throughout the Abyss: the Banner of Cabirus, marked with an ankh, the sign of the Avatar.\n Outside of areas marked with the Banner, thou shouldst watch thyself most carefully.  Most creatures who do not respect Cabirus' legacy are not particularly friendly." );
			locals[159] = 31;
			locals[160] = 32;
			locals[161] = 0;
			locals[180] = babl_menu( 0, locals,159 );
			switch ( locals[180] ) {
				
			case 1:
				
				break;
				
			case 2:
				
				break;
				
			} // end switch
			
			say( "Good luck in thy travels." );
			locals[181] = 3;
			func_00b1( locals,181 );
		} // end if
		
		if ( privateVariables[2]==1 ) {
			
		} else {
			
			goto label_0516;
			
		label_0516:;
			
			say( "Greetings again!  I am glad to see that thou hast lived this long. It is not easy for one to survive in the Abyss without the help of others." );
			locals[182] = 35;
			locals[183] = 36;
			locals[184] = 0;
			locals[203] = babl_menu( 0, locals,182 );
			switch ( locals[203] ) {
				
			case 1:
				
				locals[204] = 1;
				func_00b1( locals,204 );
				break;
				
			case 2:
				
				goto label_03ba;
				break;

			
			
			} // end if
			
			//Test 
			//break;
		label_03ba:;
			
			privateVariables[2] = 1;
			say( "First off, I would suggest picking up anything thou dost find that seems of use.  Items here are scarce enough - thou wouldst be well advised to take what thou can.\n Scavenge all you want, but stealing is ill-advised. Most of the Abyss' inhabitants guard jealously the few possessions that they have.\n Battlesites are the best for scavenging. That's why I'm here - A battle took place here not long ago - a battle between the Goblins and the above-worlders." );
			locals[71] = 17;
			locals[72] = 18;
			locals[73] = 0;
			locals[92] = babl_menu( 0, locals,71 );
			switch ( locals[92] ) {
				
			case 1:
				
				goto label_0404;
				
				break;
				
			case 2:
				
				goto label_03ff;
				
				break;
				
			} // end switch
			//end test

		label_03ff:;
			
			say( "I do not know.  It is rare that the Baron sends his men into the Abyss.  It must have been important.  Though, by the looks of it, the Goblins defeated them handily./m" );
			goto label_0404;
			
		label_0404:;
			
			say( "The Goblins control most of these upper caves.  Two races there are, the Green and the Gray.  If they do not destroy each other, it is not for lack of trying.\n Be thou especially careful of the Gray Goblins.  I was recently imprisoned by them for trespassing." );
			locals[93] = 21;
			locals[94] = 22;
			locals[95] = 0;
			locals[114] = babl_menu( 0, locals,93 );
			switch ( locals[114] ) {
				
			case 1:
				
				break;
				
			case 2:
				
				break;
				
			} // end switch




		} // end switch
		
		if ( privateVariables[3] ==1) {
			
		} else {
			
			say( "Greetings!  Hast thou visited our group?" );
			locals[205] = 38;
			locals[206] = 39;
			locals[207] = 40;
			locals[208] = 0;
			locals[226] = babl_menu( 0, locals,205 );
			switch ( locals[226] ) {
				
			case 1:
				
				goto label_05ba;
				
				break;
				
			case 2:
				
				goto label_05c8;
				
				break;
				
			case 3:
				
				goto label_05d6;
				
				break;
				
			} // end switch
			
		label_05ba:;
			
			say( "Well, 'tis thy decision.  I am sure they would welcome thee." );
			locals[227] = 2;
			func_00b1( locals,227 );
		label_05c8:;
			
			say( "Go west from the entrance chamber, past a door, and then north over a chasm. Remember, the Banner of Cabirus -- with the mark of the ankh on it -- is the mark of civilization in the Abyss." );
			locals[228] = 2;
			func_00b1( locals,228 );
		label_05d6:;
			
			privateVariables[3] = 1;
			say( "I am glad to hear it.  If thou growest weary of thy travels, thou art welcome to stay with us." );
			locals[229] = 44;
			locals[230] = 45;
			locals[231] = 0;
			locals[250] = babl_menu( 0, locals,229 );
			switch ( locals[250] ) {
				
			case 1:
				
				locals[251] = 3;
				func_00b1( locals,251 );
				break;
				
			case 2:
				
				locals[252] = 2;
				func_00b1( locals,252 );
				break;
			} // end if
			
			//break;
			
		} // end switch
		
		say( "Ah, 'tis thee again.  Hast thou decided to stay with us?" );
		locals[253] = 47;
		locals[254] = 48;
		locals[255] = 49;
		locals[256] = 0;
		locals[274] = babl_menu( 0, locals,253 );
		switch ( locals[274] ) {
			
		case 1:
			
			locals[275] = 2;
			func_00b1( locals,275 );
			break;
			
		case 2:
			
			locals[276] = 2;
			func_00b1( locals,276 );
			break;
			
		case 3:
			
			locals[277] = 3;
			func_00b1( locals,277 );
			break;
			
		} // end switch
		
	} // end func




}
