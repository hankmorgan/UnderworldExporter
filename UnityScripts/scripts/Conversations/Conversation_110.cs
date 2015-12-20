using UnityEngine;
using System.Collections;

public class Conversation_110 : Conversation {
	//a_gazer_48_23_01_0251
	//the gazer on level 2
public override void OnDeath ()
	{
		base.OnDeath ();
		set_quest(0,1,4);
	}
}
