using UnityEngine;
using System.Collections;

/// <summary>
/// NPC void creature.
/// </summary>
/// In uw2 a value in the NPC mobile data at offset +16 controls which creature appears
/// The anims are shared for these creatures so the animation index selected is how the creature is displayed properly
public class NPC_VoidCreature : NPC {

	protected override void Start ()
	{

		//int animToUse=0;
		base.Start ();
		playAnimation (GetAnimIndex() ,true);
	}
	
	// Override update so NPC will do nothing
	protected override void Update ()
	{

	}

	public override bool LookAt ()
	{
		string yousee=StringController.instance.GetString(1,StringController.str_you_see_);
		string creaturename;
		if (_RES==GAME_UW2)
		{					
			creaturename = StringController.instance.GetString(1,277+npc_voidanim).Replace("_"," ");			
			UWHUD.instance.MessageScroll.Add(yousee+ creaturename);	
		}
		else
		{
			return base.LookAt();  //TODO:this is wrong but I don't care about it now!
			//creaturename = StringController.instance.GetString(7,npc_whoami+15).Replace("_"," ");
		}
		

		return true;
	}


		int GetAnimIndex()
		{
				int index=0;
				if (_RES==GAME_UW2)
				{
					switch ( npc_voidanim)
					{
					case 0://a batskull
							index=10;break;
					case 1://a hellhound
							index=18;break;
					case 2://a mr jaws
							index=1;break;
					case 3://a spiral
							index=0;break;
					case 4://a fish
							index=3;break;
					case 5://a lightning bolt
							index=5;break;
					case 6://a skull face
							index=6;break;
					case 7://an eyeball
							index=8;break;
					}	
				}
				else
				{
						switch (npc_whoami)
						{
						case 240://bolt
						case 241://eyeball
						case 242://bat
								index=10;break;
						case 243://fish
						case 244://spiral
								index=0;break;
						case 245://hellhound
								index=20;break;
						case 246://skull
								index=32;break;
						case 247:
								index=34;break;
						}
						/*return index;
						switch (objInt().item_id)
						{
						case 79: //spiral, bat and
								{
										switch(npc_voidanim)
										{
										case 0://batskul
												index=10;break;
										case 1://mouth
												index=34;break;
										case 2://spiral
												index=0;break;
										}
										break;
								}
						case 125://fish, lightning
								{
										switch(npc_voidanim)
										{
										case 0://lightning
												index=10;break;
										case 2://fish
												index=0;break;
										}
										break;
								}

						case 126://skull & eyeball
								{
										switch (npc_voidanim)
										{
										case 0://eyeball
												index=10;break;
										case 2://skull
												index=0;break;
										}
										break;
								}
						}*/
				}

				return index;
		}


		/*int getUW1CreatureName()
		{
						/*006~007~256~a_bolt of lightning
						006~007~257~an_eyeball
						006~007~258~a_gruesome bat
						006~007~259~a_bizarre fish
						006~007~260~a_spiral
						006~007~261~a_hellhound
						006~007~262~a_skull
						006~007~263~a_mouth*/

				//return npc_whoami + 16;

				/*
				int index=256;
				switch (objInt().item_id)
				{
				case 79: //spiral, bat and hellhound
						{
								switch(npc_voidanim)
								{
								case 0://batskul
										index=258;break;
								case 1://hellhound
										index=261;break;
								case 2://spiral
										index=260;break;
								}
								break;
						}
				case 125://fish, lightning
						{
								switch(npc_voidanim)
								{
								case 0://lightning
										index=256;break;
								case 2://fish
										index=259;break;
								}
								break;
						}

				case 126://skull & eyeball
						{
								switch (npc_voidanim)
								{
								case 0://eyeball
										index=257;break;
								case 2://skull
										index=262;break;
								}
								break;
						}
				}	
		}*/

}
