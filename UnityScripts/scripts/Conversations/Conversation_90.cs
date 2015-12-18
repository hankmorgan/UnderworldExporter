using UnityEngine;
using System.Collections;

public class Conversation_90 : Conversation {
	
	//	conversation #90
	//		string block 0x0e5a, name Ironwit
	
	
	public override IEnumerator main() {
		SetupConversation (3674);
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
		
		npc.npc_attitude = param1;//[0]play_hunger;
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
		
		//int locals[257];
		int [] locals =new int[258];
		
		if ( privateVariables[0] ==1 ) {
			
			if ( privateVariables[2] == 1) {//has met and recovered blueprints
				yield return StartCoroutine(say( "Ach, 'tis my blueprints again!  'Tis right good too see ye again.  Ach, but I've no time for chitchat.  I'm afraid I misplaced my helmet and I must look for it.  This sort of thing didn't happen back when that young boy Cabirus ruled the Abyss, I tell ye.  He had a head on his shoulders.  But he's here no longer, pity.  Now where'd I put my helmet?" ));
				locals[234] = 38;
				locals[235] = 39;
				locals[236] = 40;
				locals[237] = 0;
				//locals[255] = babl_menu( 0, locals[234] );
				yield return StartCoroutine(babl_menu (0,locals,234));
				locals[255] = PlayerAnswer;
				switch ( locals[255] ) {
					
				case 1:
					
					break;
					
				case 2:
					
					break;
					
				case 3:
					
					yield return StartCoroutine(say( "Ach, so it is, so it is!  A right helpful set of blueprints ye are.  Thank ye kindly, son." ));
					locals[256] = 3;
					Time.timeScale =SlomoTime;
					yield return new WaitForSeconds(WaitTime);
					func_00b1( locals[256] );
					yield break;
					break;
					
				} // end switch
				
				locals[257] = 3;
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00b1( locals[257] );
				yield break;

			} else {//has met not yet recovered blue prints
				yield return StartCoroutine(say( "Ach, I recognize ye!  Ye're my blueprints!  No... maybe ye're my tools? My potion?  I know I've seen ye somewhere!" ));
				locals[153] = 25;
				locals[154] = 26;
				locals[155] = 0;
				//locals[174] = babl_menu( 0, locals[153] );
				yield return StartCoroutine(babl_menu (0,locals,153));
				locals[174] = PlayerAnswer;
				switch ( locals[174] ) {
					
				case 1:
					
					goto label_04a8;
					
					break;
					
				case 2:
					
					goto label_0346;
					
					break;
					
				} // end switch
			} // end if
		} // end if
		else
		{
			yield return StartCoroutine(say( "Ach, me blueprints, come back to me after all these years!.../p  No, that's not me blueprints, it's a human!  What's this? Have ye me blueprints?  Ach, me blueprints, where can they have gone?" ));
			locals[19] = 2;
			locals[20] = 3;
			locals[21] = 4;
			locals[22] = 0;
			//locals[40] = babl_menu( 0, locals[19] );
			yield return StartCoroutine(babl_menu (0,locals,19));
			locals[40] = PlayerAnswer;
			switch ( locals[40] ) {
				
			case 1:
				
				goto label_04a8;
				
				break;
				
			case 2:
				
				goto label_0306;
				
				break;
				
			case 3:
				
				goto label_0346;
				
				break;
				
			} // end switch
		}
		label_0306:;
			
			yield return StartCoroutine(say( "For sure ye're not me blueprints, then!  Never uttered a word, did they, and yet ye've a tongue for sure.  Dumb they were, mute as the rock I hewed with their aid, but still I miss them sorely.  Perhaps ye can find them for me?" ));
			locals[41] = 6;
			locals[42] = 7;
			locals[43] = 0;
			//locals[62] = babl_menu( 0, locals[41] );
			yield return StartCoroutine(babl_menu (0,locals,41));
			locals[62] = PlayerAnswer;
			switch ( locals[62] ) {
				
			case 1:
				
				goto label_0346;
				
				break;
				
			case 2:
				
				goto label_0346;
				
				break;
				
			} // end switch
			
			
		label_0346:;
			
			locals[18] = sex( 2, locals[64], locals[63] );
			locals[63] = 8;
			locals[64] = 9;
			yield return StartCoroutine(say( "Find me blueprints?  Ach, that would be a good deed indeed!  Somewhere about they are - in the storeroom most likely.  The southeast of my complex, methinks - or is that where the storeroom is?  Here, I'll give ye a set of blueprints of the area so that ye can find your way about.../p Ach!  My blueprints!  Where'd they go?  Ye seem to be a fine @SS18 - perhaps ye can find them for me?" ));
			locals[65] = 11;
			locals[66] = 12;
			locals[67] = 0;
			//locals[86] = babl_menu( 0, locals[65] );
			yield return StartCoroutine(babl_menu (0,locals,65));
			locals[86] = PlayerAnswer;
			switch ( locals[86] ) {
				
			case 1:
				
				break;
				
			case 2:
				
				break;
				
			} // end switch
			
			yield return StartCoroutine(say( "A right good @SS18 ye are.  In the storeroom I think the blueprints are. But ye cannot fly, can ye?  Ach, that's a problem, the storeroom is high up. There's a flying potion somewhere... in the spiral room?  Ach, but that's locked...  The trouble ye put me through, I don't know why I'm helping ye." ));
			locals[87] = 14;
			locals[88] = 15;
			locals[89] = 0;
			//locals[108] = babl_menu( 0, locals[87] );
			yield return StartCoroutine(babl_menu (0,locals,87));
			locals[108] = PlayerAnswer;
			switch ( locals[108] ) {
				
			case 1:
				
				break;
				
			case 2:
				
				break;
				
			} // end switch
			
			yield return StartCoroutine(say( "Ach, speaking of help, ye could help an old man greatly by finding me blueprints, if ye could.  Now where was the key to the door to the spiral room? In the golden maze room, methinks.  Ach, yes, it's the golden path ye must follow, or else ye may be poisoned... no, that's the poison potion in the spiral room.  Or was it a flying potion?  Maybe both potions - ach, that's it!" ));
			locals[109] = 17;
			locals[110] = 18;
			locals[111] = 0;
			//locals[130] = babl_menu( 0, locals[109] );
			yield return StartCoroutine(babl_menu (0,locals,109));
			locals[130] = PlayerAnswer;
			switch ( locals[130] ) {
				
			case 1:
				
				break;
				
			case 2:
				
				break;
				
			} // end switch
			
			yield return StartCoroutine(say( "Wait, don't rush me... one potion is green, and the other red.  Or is one red and the other green?  Yes, that's it.  One red and one green, no doubt of it. One of the two is a flying potion and one is poison... or is it the other way around?  Ach, now I've forgotten again.  Oh, that's it - green is good.  Or was it red is rotten?/m" ));
			yield return StartCoroutine(say( "Well, do your best, won't ye?  And while ye're in the area, if ye happen by me blueprints, bring them back here.  I think I may have left them in the storeroom.  Feel free to help yourself to anything else ye find, though." ));
			locals[131] = 21;
			locals[132] = 22;
			locals[133] = 23;
			locals[134] = 0;
			//locals[152] = babl_menu( 0, locals[131] );
			yield return StartCoroutine(babl_menu (0,locals,131));
			locals[152] = PlayerAnswer;
			switch ( locals[152] ) {
				
			case 1:
				
				break;
				
			case 2:
				
				break;
				
			case 3:
				
				break;
				
			} // end switch
			
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();//Move up to 3???
			yield break;
			

			
		label_04a8:;
			//Items list gets copied to locals[6]+. 
			//I compare with the item_id
			//I call a function to see if it is the right quality
			
			//Rewrite.
			//do show inv.
			//for each object returned
			
			locals[15] = 0;
			//locals[13] = show_inv( 2, locals[6], locals[1] );
			locals[13]=show_inv (2,locals,6,1);
			//	while ( locals[13] > 0 ) {
			for (int i = 0; i<locals[13];i++)
			{
				locals[14] = 1;
				if ( locals[14] <= locals[13] ) {
					
					if ( locals[6+i] >= 312 && locals[6+i] <= 319 ) {
						
						locals[175] = 32;
						//if ( func_06f7( locals[175], locals[5] ) == 1 ) {
						if (GetItemAtSlotProperty_Link(locals[1+i]) -512 == locals[175]){
							locals[15] = locals[14];
							locals[11] = 1;//locals[5];
							locals[176] = locals[1+i];//Set the slot index here.
						} // end if
						
					} // end if
					
					locals[14] = locals[14] + 1;
				} // while
				
			} // end if
			
			if ( locals[15] > 0 ) {
				
				//locals[176] = 1;
				//give_to_npc( 2, locals[11], locals[176] );
				give_to_npc(2,locals,11,locals[176]);//Just give 1 item at 1 specific slot set above
				privateVariables[2] = 1;
			} else {
				
				yield return StartCoroutine(say( "Maybe these are your blueprints, but they are not mine!" ));
				locals[177] = 28;
				locals[178] = 29;
				locals[179] = 31;
				locals[180] = 0;
				//locals[198] = babl_menu( 0, locals[177] );
				yield return StartCoroutine(babl_menu (0,locals,177));
				locals[198] = PlayerAnswer;
				switch ( locals[198] ) {
					
				case 1:
					
					goto label_04a8;
					
					break;
					
				case 2:
					
					yield return StartCoroutine(say( "Cruel ye are, to toy with an old man thus!" ));
					locals[199] = 1;
					Time.timeScale =SlomoTime;
					yield return new WaitForSeconds(WaitTime);
					func_00b1( locals[199] );
					yield break;
					break;
					
				case 3:
					
					goto label_0346;
					break;
				} // end if
				
				
				
			} // end switch
			
			yield return StartCoroutine(say( "My blueprints!  At last we are reunited!" ));
			locals[17] = find_inv( 2, locals[201], locals[200] );
			locals[200] = 188;
			locals[201] = 0;
			if ( locals[17] > 0 ) {
				
				locals[202] = 1;
				locals[203] = 7;
				locals[204] = -1;
				locals[205] = -1;
				locals[206] = -1;
				locals[207] = -1;
				locals[208] = -1;
				locals[209] = -1;
				x_obj_stuff( 9, locals[209], locals[208], locals[207], locals[206], locals[205], locals[204], locals[203], locals[202], locals[17] );
			} // end if
			locals[210] = 188;
			locals[16] = take_from_npc( 1, locals[210] );
			
			if ( (locals[16] == 1 || locals[16] == 2) ) {
				
				yield return StartCoroutine(say( "Here, take another flying potion as a measure of my gratitude. Or perhaps it's a green potion... never ye mind, I'm sure it will do something useful.  I bet ye've never seen a flying potion before, so ye be careful with it." ));
				if ( locals[16] == 2 ) {
					
					yield return StartCoroutine(say( "/mWhat, no arms ye have?  I'll leave it here for ye." ));
				} // end if
				
				locals[211] = 35;
				locals[212] = 36;
				locals[213] = 0;
				//locals[232] = babl_menu( 0, locals[211] );
				yield return StartCoroutine(babl_menu (0,locals,211));
				locals[232] = PlayerAnswer;
				switch ( locals[232] ) {
					
				case 1:
					
					break;
					
				case 2:
					break;
				} // end if
				
				
				
			} // end switch
			
			locals[233] = 3;
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00b1( locals[233] );
			yield break;

		

	} // end func
	
	int func_06f7(int param1,int param2) {
		
		//int locals[9];
		int [] locals =new int[10];
		
		locals[3] = 0;
		locals[4] = -1;
		locals[5] = -1;
		locals[6] = -1;
		locals[7] = -1;
		locals[8] = -1;
		locals[9] = -1;
		x_obj_stuff( 9,locals[9], locals[8], locals[7], locals[2], locals[6], locals[5], locals[4], locals[3], param2 );
		if ( locals[2] == param1){//[0]){ //play_hunger ) {
			
			locals[1] = 1;
		} else {
			
			locals[1] = 0;
		} // end if
		
		return locals[1];
	} // end func
	
	
	
}
