using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Conversation_UW2 : Conversation {


		public int x_clock(int unk, int unk1, int unk2 )
		{//Not documented.
				return 0;
		}


		public void x_exp(int unk, int xp)
		{//Adds exp?
			GameWorldController.instance.playerUW.EXP+=xp;
		}


		public void set_attitude(int unk, int attitude)
		{
				
		}
}




