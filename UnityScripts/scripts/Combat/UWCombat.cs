using UnityEngine;
using System.Collections;

public class UWCombat : Combat {

	/// The melee weapon currently held by the player.
	public WeaponMelee currWeapon;
	/// The current ranged weapon held by the player
	public WeaponRanged currWeaponRanged; 
	/// The inventory object that is to be launched in the next ranged attack. 
	private ObjectInteraction currentAmmo; 
	
	///What animation to play for this weapon swing
	private string CurrentStrike;

	private short CurrentStrikeAnimation;

	public override void PlayerCombatIdle ()
	{
		base.PlayerCombatIdle ();

		if ((AttackCharging==false) && (AttackExecuting==false))
		{ ///If not charging an attack and not executing an attack it will check interaction mode.
			if ((UWCharacter.InteractionMode==UWCharacter.InteractionModeAttack))
			{///Sets the weapon, race and handedness of the weapon animation.
				//UWHUD.instance.wpa.SetAnimation= GetWeapon () +"_Ready_" + GetRace () + "_" + GetHand();
				if(IsMelee())
				{
					UWHUD.instance.wpa.SetAnimation=GetWeaponOffset()+GetHandOffset()+6;//For ready						
				}				
			}
			else
			{///Or Hides the weapon by animating the player putting it away.
				UWHUD.instance.wpa.SetAnimation=-1; //"WeaponPutAway";
			}
		}
	}

	/// <summary>
	/// Begins the combat state of the player. Sets AttackCharging.
	/// Animates the weapon becoming ready.
	/// For ranged weaponry it checks for the weapon ammo.
	/// </summary>
	public override void CombatBegin()
	{ 
		chargeRate= (33f) + (66f * ((float)UWCharacter.Instance.PlayerSkills.Attack/30f));
		if(IsMelee())
		{///If melee sets the proper weapon drawn back animation.
			CurrentStrike=GetStrikeType();
			CurrentStrikeAnimation=GetStrikeOffset();
			//UWHUD.instance.wpa.SetAnimation= GetWeapon () +"_" + CurrentStrike + "_" + GetRace () + "_" + GetHand() + "_Charge";
			UWHUD.instance.wpa.SetAnimation = GetWeaponOffset()+CurrentStrikeAnimation+GetHandOffset()+0; //charge
		}
		else
		{
			///If ranged check for ammo as defined by the Weapon
			/// If ammo if found give the player a targeting crosshair
			currentAmmo=GameWorldController.instance.playerUW.playerInventory.findObjInteractionByID(currWeaponRanged.AmmoType());
			if ((currentAmmo == null) && (ObjectInteraction.Alias(currWeaponRanged.AmmoType())!=currWeaponRanged.AmmoType()))
			{//Ammo type has an alias. try and find that instead.
				currentAmmo=GameWorldController.instance.playerUW.playerInventory.findObjInteractionByID(ObjectInteraction.Alias(currWeaponRanged.AmmoType()));
			}
			if (currentAmmo==null)
			{//No ammo.
				UWHUD.instance.MessageScroll.Add ("Sorry, you have no " + StringController.instance.GetObjectNounUW(currWeaponRanged.AmmoType()));
				return;
			}
			else
			{
				//Change the crosshair
				UWHUD.instance.CursorIcon=UWHUD.instance.CursorIconTarget;
			}
		}
		///Starts the counter
		AttackCharging=true;
		Charge=0;
	}	

	/// <summary>
	/// Increases the Charge by the charge rate * Time.deltaTime.
	/// </summary>
	public override void CombatCharging()	
	{//While still charging increase the charge by the charge rate.
		Charge=(Charge+(chargeRate*Time.deltaTime));
		//Debug.Log ("Charging up ");
		if (Charge>100)
		{
			Charge=100;
		}
	}


	/// <summary>
	/// Executes the melee attack after the attack has been released.
	/// Casts a ray from the centre of the screen in mouselook mode or from the cursor position
	/// Waits a period of time after the release before casting the ray.
	/// </summary>
	public override IEnumerator ExecuteMelee(string StrikeType, float StrikeCharge)
	{		
		yield return new WaitForSeconds(0.4f);
		
		Ray ray ;
		if (GameWorldController.instance.playerUW.MouseLookEnabled==true)
		{
			ray =Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
		}
		else
		{
			ray= Camera.main.ScreenPointToRay(Input.mousePosition);
		}
		
		RaycastHit hit = new RaycastHit(); 
		if (Physics.Raycast(ray,out hit,weaponRange))
		{
			if (!hit.transform.Equals(this.transform))
			{
				ObjectInteraction objInt = hit.transform.gameObject.GetComponent<ObjectInteraction>();
				if (objInt!=null)
				{
					switch (objInt.GetItemType())
					{
					case ObjectInteraction.NPC_TYPE:
						PC_Hits_NPC(GameWorldController.instance.playerUW,currWeapon,CurrentStrike,StrikeCharge,objInt.GetComponent<NPC>(), hit);
						break;
					default:
						Impact.SpawnHitImpact(Impact.ImpactDamage(), (ray.origin +  hit.point)/2f,46,50);
						objInt.Attack((short)GetPlayerBaseDamage(currWeapon,CurrentStrike),GameWorldController.instance.playerUW.gameObject);
						break;
					}
				}
				else
				{//Probably hit a wall or tile floor
					Impact.SpawnHitImpact(Impact.ImpactDamage(), (ray.origin +  hit.point)/2f,46,50);
					if(currWeapon!=null)
					{
						short durability = currWeapon.getDurability();
						currWeapon.SelfDamage((short)(Mathf.Max(0, Random.Range(1,durability+1)-durability)));
					}

					if (ObjectInteraction.PlaySoundEffects)
					{
						GameWorldController.instance.playerUW.aud.clip=GameWorldController.instance.getMus().SoundEffects[MusicController.SOUND_EFFECT_MELEE_MISS_1];
						GameWorldController.instance.playerUW.aud.Play();
					}
				}
			}
		}
		else
		{
			if (ObjectInteraction.PlaySoundEffects)
			{
				GameWorldController.instance.playerUW.aud.clip=GameWorldController.instance.getMus().SoundEffects[MusicController.SOUND_EFFECT_MELEE_MISS_1];
				GameWorldController.instance.playerUW.aud.Play();
			}
			if (currWeapon!=null)
			{
				currWeapon.onHit (null);
			}
		}

		///Ends the attack and wait for a period before allowing another action.
		AttackExecuting=false;
		UWHUD.instance.window.UWWindowWait(1.0f);
		
	}

	/// <summary>
	/// Execution of ranged attacks
	/// </summary>
		public override void ExecuteRanged (float charge)
	{
		base.ExecuteRanged (charge);

		///Removes the cursor
		UWHUD.instance.CursorIcon=UWHUD.instance.CursorIconDefault;
		///Launches the ammo using LaunchAmmo
		if (currentAmmo!=null)
		{
			//currentAmmo.consumeObject ();
			LaunchAmmo(charge);
		}
	}

	/// <summary>
	/// Releases the attack.
	/// </summary>
	public override void ReleaseAttack()
	{
		if (UWHUD.instance.window.JustClicked==false)
		{
			if (IsMelee())
			{///Sets the weapon, race and handedness animation.
				if (CurrentStrike=="")
				{
					CurrentStrike=GetStrikeType();		
				}
				//UWHUD.instance.wpa.SetAnimation= GetWeapon () + "_" + CurrentStrike + "_" + GetRace () + "_" + GetHand() + "_Execute";
				UWHUD.instance.wpa.SetAnimation = GetWeaponOffset()+CurrentStrikeAnimation+GetHandOffset()+1;//exeute
				AttackExecuting=true;
				StartCoroutine(ExecuteMelee(CurrentStrike,Charge));
			}
			else
			{//Ranged attack
				ExecuteRanged(Charge);
			}
			///Ends the attack.
			Charge=0.0f;
			AttackCharging=false;
		}
	}


	/// <summary>
	/// Determines whether this current weapn is melee or ranged
	/// </summary>
	/// <returns><c>true</c> if this instance is melee; otherwise, <c>false</c>.</returns>
	public bool IsMelee()
	{//Is the player using a melee weapon.
		if (GetWeapon()=="Ranged")
		{
			return false;
		}
		else
		{
			return true;
		}
	}

	/// <summary>
	/// Gets the weapon type
	/// One of sword, axe, mace or fist for melee
	/// or Ranged for ranged weapons
	/// </summary>
	/// <returns>The weapon.</returns>
	public string GetWeapon()
	{
		if (currWeapon!=null)
		{
			switch (currWeapon.GetSkill())
			{
			case 3:
				return "Sword";
			case 4:
				return "Axe";
			case 5:
				return "Mace";
			default:
				return "Fist";
			}
		}
		else
		{
			if (currWeaponRanged!=null)
			{
				return "Ranged";
			}
			else
			{
				return "Fist";
			}
		}
	}

		public short GetWeaponOffset()
		{
			if (currWeapon!=null)
			{
				switch (currWeapon.GetSkill())
				{
				case 3:
						return 0;
				case 4:
						return 7;
				case 5:
						return 14;
				default:
						return 21;
				}
			}
			else
			{
				if (currWeaponRanged!=null)
				{
						return -1;
				}
				else
				{
						return 21;
				}
			}
		}

	/// <summary>
	/// Gets the race of the charcter for displaying their skin colour based on the Body variable of UWCharacter
	/// </summary>
	/// <returns>The race.</returns>
	public string GetRace()
	{
		switch (GameWorldController.instance.playerUW.Body)
		{
		case 0:
		case 2 :
		case 3:
		case 4:
			return "White";
		default:
			return "Black";
		}
	}
	
	/// <summary>
	/// Gets the handedness of the character
	/// </summary>
	/// <returns>The hand.</returns>
	public string GetHand()
	{
		if (GameWorldController.instance.playerUW.isLefty)
		{
			return "Left";
		}
		else
		{
			return "Right";
		}
	}

		public short GetHandOffset()
		{
				if (GameWorldController.instance.playerUW.isLefty)
				{
						return 28;
				}
				else
				{
						return 0;
				}
		}

	/// <summary>
	/// Gets the type of the strike based on where the mouse cursor is located on the Y axis of the viewport.
	/// Returns one of Bash, Slash or Stab
	/// </summary>
	/// <returns>The strike type.</returns>
	public string GetStrikeType()
	{
		if (!GameWorldController.instance.playerUW.MouseLookEnabled)
		{
				if (Camera.main.ScreenToViewportPoint (Input.mousePosition).y>0.666f)
				{
						return "Bash";
				}
				else if(Camera.main.ScreenToViewportPoint (Input.mousePosition).y>0.333f)
				{
						return "Slash";
				}
				else
				{
						return "Stab";
				}	
		}
		else
		{
				switch (Random.Range(1,4))
				{
				case 1:
						return "Bash";
				case 2:
						return "Slash";
				case 3:
				default:
						return "Stab";
				}
		}

	}

		public short GetStrikeOffset()
		{
				if (!GameWorldController.instance.playerUW.MouseLookEnabled)
				{
						if (Camera.main.ScreenToViewportPoint (Input.mousePosition).y>0.666f)
						{
								return 2;//bash
						}
						else if(Camera.main.ScreenToViewportPoint (Input.mousePosition).y>0.333f)
						{
								return 4;//Slash
						}
						else
						{
								return 0;//stab
						}	
				}
				else
				{
						switch (Random.Range(1,4))
						{
						case 1:
								return 2;
						case 2:
								return 4;
						case 3:
						default:
								return 0;
						}
				}

		}


		/// <summary>
		/// Launchs the ammo.
		/// </summary>
		/// <returns><c>true</c>, if ammo was launched, <c>false</c> otherwise.</returns>
	bool LaunchAmmo (float charge)
	{
		if (currentAmmo!=null)
		{
			Ray ray ;
			if (GameWorldController.instance.playerUW.MouseLookEnabled==true)
			{
				ray =Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
			}
			else
			{
				ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			}

			RaycastHit hit = new RaycastHit(); 
			float dropRange=0.5f;
			if (!Physics.Raycast(ray,out hit,dropRange))
			{///Checks No object interferes with the launch
				float force = 1000.0f*(charge/100.0f);
				GameObject launchedItem ;
				if(currentAmmo.GetQty()==1)
				{
					launchedItem = currentAmmo.gameObject;
					GameWorldController.instance.playerUW.playerInventory.RemoveItem(currentAmmo.name);	
					launchedItem.transform.parent=GameWorldController.instance.LevelMarker();
					GameWorldController.MoveToWorld(launchedItem);
					launchedItem.transform.position=ray.GetPoint(dropRange-0.1f);
					launchedItem.GetComponent<ObjectInteraction>().PickedUp=false;	//Back in the real world	
				}
				else
				{//reduce this quantity by one and create a copy in the world
					ObjectLoaderInfo newobjt= ObjectLoader.newObject( currWeaponRanged.AmmoType(),40,0,1,256);
					launchedItem = ObjectInteraction.CreateNewObject(GameWorldController.instance.currentTileMap(),newobjt, GameWorldController.instance.LevelMarker().gameObject, ray.GetPoint(dropRange-0.1f)).gameObject;
					currentAmmo.consumeObject();
				}
				GameWorldController.UnFreezeMovement(launchedItem);				
				Vector3 ThrowDir = ray.GetPoint(dropRange) - ray.origin;

				///Apply the force along the direction of the ray that the player has targetted along.
				launchedItem.GetComponent<Rigidbody>().AddForce(ThrowDir*force);
				GameObject myObjChild = new GameObject(launchedItem.name + "_damage");
				myObjChild.transform.position =launchedItem.transform.position;
				myObjChild.transform.parent =launchedItem.transform;
				///Appends ProjectileDamage to the projectile to act as the damage delivery method.
				ProjectileDamage pd= myObjChild.AddComponent<ProjectileDamage>();
				pd.Source=GameWorldController.instance.playerUW.gameObject;
				pd.Damage= (short)currWeaponRanged.Damage(); //   (short)(10.0f*(Charge/100.0f));
				return true;
			}
			else
			{
				return false;
			}

		}
		else
		{//No ammo?? Should not happen
			return false;
		}
	}

		//Combat calcs


		/// <summary>
		/// Combat calculations for PC hitting an NPC
		/// </summary>
		/// <param name="playerUW">Player Character</param>
		/// <param name="npc">Npc.</param>
		/// <param name="hit">Hit.</param>
		public static void PC_Hits_NPC(UWCharacter playerUW, WeaponMelee currentWeapon, string StrikeName, float StrikeCharge,  NPC npc, RaycastHit hit)
		{

			int attackScore = 0;
			int BaseDamage= GetPlayerBaseDamage(currentWeapon,StrikeName);
			if (currentWeapon!=null)
			{
				attackScore =playerUW.PlayerSkills.GetSkill(Skills.SkillAttack)/2 + playerUW.PlayerSkills.GetSkill(currentWeapon.GetSkill()+1);		
				attackScore+=currentWeapon.AccuracyBonus();
			}
			else
			{
				attackScore =playerUW.PlayerSkills.GetSkill(Skills.SkillAttack)/2 + playerUW.PlayerSkills.GetSkill(Skills.SkillUnarmed);	
			}


			int toHit = Mathf.Max(npc.GetDefence() - attackScore,0);
			//Difficulty is either 1 for standard or 0 for easy.
			int roll = Mathf.Max(30,Random.Range(-1,31) + ( 5 * (1- GameWorldController.instance.difficulty) )  );//-1 is critical miss. 30 is always hit
			int HitRollResult=0;
			if (((roll >= toHit) || (roll>=30)) && (roll>-1))
			{
				short Damage= (short)(Mathf.Max(((float)(BaseDamage))*(StrikeCharge/100f),1));
				npc.ApplyAttack(Damage,playerUW.gameObject);
				HitRollResult=1;
				if (roll==30)
				{
					HitRollResult=2;//crit. apply double damage
					npc.ApplyAttack(Damage,playerUW.gameObject);
				}
				if (roll >=27)
				{
					HitRollResult=2;//critical
				}
			}
			else
			{
				HitRollResult=0;
				npc.ApplyAttack(0,playerUW.gameObject);//A zero damage attack to update ai if needed
				if (currentWeapon!=null)
				{
					//Apply equipment damage to weapon if NPC Defence is 1.5 times attackscore	
					if ((float)npc.GetDefence() > (float)attackScore*1.5f)
					{
						short durability = currentWeapon.getDurability();
						//currentWeapon.WeaponSelfDamage();
						currentWeapon.SelfDamage((short)Mathf.Max(0, Random.Range(0, npc.GetArmourDamage()+1) - durability));
					}
				}
			}


			///Creates a blood splatter at the point of impact
			switch (HitRollResult)
			{
			case 0: //Miss
				//Impact.SpawnHitImpact(hit.transform.name + "_impact", npc.objInt().GetImpactPoint(),46,50);
				if (ObjectInteraction.PlaySoundEffects)
				{
					npc.objInt().aud.clip=GameWorldController.instance.getMus().SoundEffects[MusicController.SOUND_EFFECT_MELEE_MISS_2];
					npc.objInt().aud.Play();
				}
				break;
			case 1://Hit
				Impact.SpawnHitImpact(Impact.ImpactBlood(),  npc.objInt().GetImpactPoint(), npc.objInt().GetHitFrameStart(), npc.objInt().GetHitFrameEnd());		
				if (ObjectInteraction.PlaySoundEffects)
				{
					npc.objInt().aud.clip=GameWorldController.instance.getMus().SoundEffects[MusicController.SOUND_EFFECT_MELEE_HIT_1];
					npc.objInt().aud.Play();
				}
				break;
			case 2://Crit
				Impact.SpawnHitImpact(Impact.ImpactBlood(), npc.objInt().GetImpactPoint(), npc.objInt().GetHitFrameStart(), npc.objInt().GetHitFrameEnd());		
				Impact.SpawnHitImpact(Impact.ImpactBlood(), npc.objInt().GetImpactPoint()+Vector3.up*0.1f, npc.objInt().GetHitFrameStart(), npc.objInt().GetHitFrameEnd());		
				if (ObjectInteraction.PlaySoundEffects)
				{
					npc.objInt().aud.clip=GameWorldController.instance.getMus().SoundEffects[MusicController.SOUND_EFFECT_MELEE_HIT_2];
					npc.objInt().aud.Play();
				}
				break;
			}

		if (currentWeapon!=null)
			{///Performs the onHit action of the melee weapon.
				currentWeapon.onHit (hit.transform.gameObject);
			}
		}


		/// <summary>
		/// NPC hits player
		/// </summary>
		/// <param name="playerUW">Player U.</param>
		/// <param name="npc">Npc.</param>
	public static void NPC_Hits_PC(UWCharacter playerUW, NPC npc)
	{
		int PlayerDefence =0; 
		if( playerUW.PlayerCombat.currWeapon!=null)
		{
			PlayerDefence =	playerUW.PlayerSkills.GetSkill(Skills.SkillDefense) + (playerUW.PlayerSkills.GetSkill(playerUW.PlayerCombat.currWeapon.GetSkill()+1)/2);
		}
		else
		{
			PlayerDefence =	playerUW.PlayerSkills.GetSkill(Skills.SkillDefense) + (playerUW.PlayerSkills.GetSkill(Skills.SkillUnarmed)/2);
		}
		int toHit = Mathf.Max(PlayerDefence - npc.GetAttack() , 0);
		int roll = Random.Range(-1,31);
		if ((_RES==GAME_UW1)&& (npc.objInt().item_id==124))
		{
			roll=30;//Slasher will always hit.
		}
		int BaseDamage=npc.GetDamage();//get the damage of the current attack
		if (((roll >= toHit) || (roll>=30)) && (roll>-1))
			{
				int PlayerArmourScore=playerUW.playerInventory.getArmourScore();
				int ReducedDamage= Mathf.Max(1, BaseDamage - PlayerArmourScore);
				//Hit
				playerUW.ApplyDamage(Random.Range(1, ReducedDamage+1),npc.gameObject );
				//reduce damage by protection
				if (BaseDamage>PlayerArmourScore)
				{
					//apply equipment damage to a random piece of armour
					playerUW.playerInventory.ApplyArmourDamage((short)Random.Range(0, npc.GetArmourDamage()+1));
				}
				MusicController.LastAttackCounter=10.0f; //Ten more seconds of combat music
				if (ObjectInteraction.PlaySoundEffects)
				{
					GameWorldController.instance.playerUW.aud.clip=GameWorldController.instance.getMus().SoundEffects[MusicController.SOUND_EFFECT_MELEE_HIT_1];
					GameWorldController.instance.playerUW.aud.Play();
				}
			}		
		}

		/// <summary>
		/// NPC hits another NPC
		/// </summary>
		/// <param name="targetNPC">Target NP.</param>
		/// <param name="originNPC">Origin NP.</param>
		public static void NPC_Hits_NPC(NPC targetNPC, NPC originNPC)
		{
			int Defence = targetNPC.GetDefence();
			int Attack = originNPC.GetAttack();
			int toHit = Mathf.Max(Defence-Attack,1);
			int roll = Random.Range(-1,31);
			int BaseDamage= Random.Range(1, originNPC.GetDamage()+1);
			if (((roll >= toHit) || (roll>=30)) && (roll>-1))
			{
				targetNPC.ApplyAttack((short)BaseDamage,originNPC.gameObject);
				Impact.SpawnHitImpact(Impact.ImpactBlood(), targetNPC.GetImpactPoint(), targetNPC.objInt().GetHitFrameStart(), targetNPC.objInt().GetHitFrameEnd());		
				if (ObjectInteraction.PlaySoundEffects)
				{
					originNPC.objInt().aud.clip=GameWorldController.instance.getMus().SoundEffects[MusicController.SOUND_EFFECT_MELEE_HIT_1];
					originNPC.objInt().aud.Play();
				}
			}						
		}


		public static int GetPlayerBaseDamage(WeaponMelee currentWeapon, string StrikeName)
		{
			int BaseDamage=1;
			if (currentWeapon!=null)
			{
				switch(StrikeName)			
				{
				case "SLASH":
						BaseDamage=currentWeapon.GetSlash();break;
				case "BASH":
						BaseDamage=currentWeapon.GetBash();break;
				case "STAB":
				default:	
						BaseDamage=currentWeapon.GetStab();break;
				}
			}
			else
			{
				switch(StrikeName)
				{
				case "SLASH":
						BaseDamage= WeaponMelee.getMeleeSlash() ;break;
				case "BASH":
						BaseDamage= WeaponMelee.getMeleeBash();break;
				case "STAB":
				default:	
						BaseDamage= WeaponMelee.getMeleeStab() ;break;
				}
			}
			return BaseDamage;					
		}
}