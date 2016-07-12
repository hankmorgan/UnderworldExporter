using UnityEngine;
using System.Collections;

public class UWCombat : Combat {

	/// The melee weapon currently held by the player.
	public WeaponMelee currWeapon;
	/// The current ranged weapon held by the player
	public WeaponRanged currWeaponRanged; 
	/// The inventory object that is to be launched in the next ranged attack. 
	public ObjectInteraction currentAmmo; 

	public override void PlayerCombatIdle ()
	{
		base.PlayerCombatIdle ();

		if ((AttackCharging==false) && (AttackExecuting==false))
		{ ///If not charging an attack and not executing an attack it will check interaction mode.
			if ((UWCharacter.InteractionMode==UWCharacter.InteractionModeAttack))
			{///Sets the weapon, race and handedness of the weapon animation.
				GameWorldController.instance.playerUW.playerHud.wpa.SetAnimation= GetWeapon () +"_Ready_" + GetRace () + "_" + GetHand();
			}
			else
			{///Or Hides the weapon by animating the player putting it away.
				GameWorldController.instance.playerUW.playerHud.wpa.SetAnimation= "WeaponPutAway";
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
		if(IsMelee())
		{///If melee sets the proper weapon drawn back animation.
			GameWorldController.instance.playerUW.playerHud.wpa.SetAnimation= GetWeapon () +"_" + GetStrikeType() + "_" + GetRace () + "_" + GetHand() + "_Charge";
		}
		else
		{
			///If ranged check for ammo as defined by the Weapon
			/// If ammo if found give the player a targeting crosshair
			currentAmmo=GameWorldController.instance.playerUW.playerInventory.findObjInteractionByID(currWeaponRanged.AmmoType);
			if ((currentAmmo == null) && (ObjectInteraction.Alias(currWeaponRanged.AmmoType)!=currWeaponRanged.AmmoType))
			{//Ammo type has an alias. try and find that instead.
				currentAmmo=GameWorldController.instance.playerUW.playerInventory.findObjInteractionByID(ObjectInteraction.Alias(currWeaponRanged.AmmoType));
			}
			if (currentAmmo==null)
			{//No ammo.
				GameWorldController.instance.playerUW.playerHud.MessageScroll.Add ("Sorry, you have no " + GameWorldController.instance.playerUW.StringControl.GetObjectNounUW(currWeaponRanged.AmmoType));
				return;
			}
			else
			{
				//Change the crosshair
				GameWorldController.instance.playerUW.playerHud.CursorIcon=GameWorldController.instance.playerUW.playerHud.CursorIconTarget;
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
	public override IEnumerator ExecuteMelee()
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
			if (hit.transform.Equals(this.transform))
			{
				//Debug.Log ("you've hit yourself ? " + hit.transform.name);
			}
			else
			{
				ObjectInteraction objInt = hit.transform.gameObject.GetComponent<ObjectInteraction>();
				if (objInt!=null)
				{
					hit.transform.gameObject.GetComponent<ObjectInteraction>().Attack(100);
					///Creates a blood splatter at the point of impact
					GameObject hitimpact = new GameObject(hit.transform.name + "_impact");
					hitimpact.transform.position=hit.point;
					hitimpact.transform.parent = GameWorldController.instance.LevelMarker;
					Impact imp= hitimpact.AddComponent<Impact>();
					imp.go(objInt.GetHitFrameStart(),objInt.GetHitFrameEnd());	
					if (currWeapon!=null)
					{///Performs the onHit action of the melee weapon.
						currWeapon.onHit (hit.transform.gameObject);
					}
				}
				else
				{
					///If a miss does a miss impact and potentially damages the weapon.
					GameObject hitimpact = new GameObject(hit.transform.name + "_impact");
					hitimpact.transform.position=hit.point;//ray.GetPoint(weaponRange/0.7f);
					hitimpact.transform.parent = GameWorldController.instance.LevelMarker;
					Impact imp= hitimpact.AddComponent<Impact>();
					StartCoroutine( imp.Animate(46,50));
					if (currWeapon!=null)
					{
						currWeapon.onHit (null);
						currWeapon.WeaponSelfDamage();
					}
				}
			}
		}
		else
		{
			if (currWeapon!=null)
			{
				currWeapon.onHit (null);
			}
		}
		///Ends the attack and wait for a period before allowing another action.
		AttackExecuting=false;
		GameWorldController.instance.playerUW.playerHud.window.UWWindowWait(1.0f);
		
	}

	/// <summary>
	/// Execution of ranged attacks
	/// </summary>
	public override void ExecuteRanged ()
	{
		base.ExecuteRanged ();

		///Removes the cursor
		GameWorldController.instance.playerUW.playerHud.CursorIcon=GameWorldController.instance.playerUW.playerHud.CursorIconDefault;
		///Launches the ammo using LaunchAmmo
		if (currentAmmo!=null)
		{
			//currentAmmo.consumeObject ();
			LaunchAmmo();
		}
	}

	/// <summary>
	/// Releases the attack.
	/// </summary>
	public override void ReleaseAttack()
	{
		if (GameWorldController.instance.playerUW.playerHud.window.JustClicked==false)
		{
			if (IsMelee())
			{///Sets the weapon, race and handedness animation.
				GameWorldController.instance.playerUW.playerHud.wpa.SetAnimation= GetWeapon () + "_" + GetStrikeType () +"_" + GetRace () + "_" + GetHand() + "_Execute";
				AttackExecuting=true;
				StartCoroutine(ExecuteMelee());
			}
			else
			{//Ranged attack
				ExecuteRanged();
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
			switch (currWeapon.Skill)
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

	/// <summary>
	/// Gets the race of the charcter for displaying their skin colour based on the Body variable of UWCharacter
	/// </summary>
	/// <returns>The race.</returns>
	public string GetRace()
	{
		switch (GameWorldController.instance.playerUW.Body)
		{
		case 1:
		case 3:
		case 4:
		case 5:
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

	/// <summary>
	/// Gets the type of the strike based on where the mouse cursor is located on the Y axis of the viewport.
	/// Returns one of Bash, Slash or Stab
	/// </summary>
	/// <returns>The strike type.</returns>
	public string GetStrikeType()
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

		/// <summary>
		/// Launchs the ammo.
		/// </summary>
		/// <returns><c>true</c>, if ammo was launched, <c>false</c> otherwise.</returns>
	bool LaunchAmmo ()
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
				float force = 500.0f;
				GameObject launchedItem ;

				if (currentAmmo.GetQty()==1)
				{///Removes the instance of the object 
					launchedItem = currentAmmo.gameObject;
					GameWorldController.instance.playerUW.playerInventory.RemoveItem(currentAmmo.name);
				}
				else
				{//If in a stack instantiate a single copy and update the stack as needed.
					launchedItem = Instantiate(currentAmmo.gameObject);
					launchedItem.name="launched_missile_" +GameWorldController.instance.playerUW.PlayerMagic.SummonCount++;
					launchedItem.GetComponent<ObjectInteraction>().Link=1;//Only 1
					ObjectInteraction.Split(launchedItem.GetComponent<ObjectInteraction>());
					currentAmmo.consumeObject();//Reduce by one.
				}
				launchedItem.transform.parent=null;
				launchedItem.GetComponent<ObjectInteraction>().PickedUp=false;	//Back in the real world

				launchedItem.transform.position=ray.GetPoint(dropRange-0.1f);//GameWorldController.instance.playerUW.transform.position;
				WindowDetect.UnFreezeMovement(launchedItem);
				Vector3 ThrowDir = ray.GetPoint(dropRange) - ray.origin;
				///Apply the force along the direction of the ray that the player has targetted along.
				launchedItem.GetComponent<Rigidbody>().AddForce(ThrowDir*force);
				GameObject myObjChild = new GameObject(launchedItem.name + "_damage");
				myObjChild.transform.position =launchedItem.transform.position;
				myObjChild.transform.parent =launchedItem.transform;
				///Appends ProjectileDamage to the projectile to act as the damage delivery method.
				ProjectileDamage pd= myObjChild.AddComponent<ProjectileDamage>();
				pd.Damage=10;
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
}