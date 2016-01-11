using UnityEngine;
using System.Collections;

public class UWCombat : Combat {

	public UWCharacter playerUW;
	public WeaponMelee currWeapon;
	public WeaponRanged currWeaponRanged;
	public ObjectInteraction currentAmmo;

	public override void PlayerCombatUpdate ()
	{
		base.PlayerCombatUpdate ();

		if ((AttackCharging==false) && (AttackExecuting==false))
		{
			if ((UWCharacter.InteractionMode==UWCharacter.InteractionModeAttack))
			{
				wpa.SetAnimation= GetWeapon () +"_Ready_" + GetRace () + "_" + GetHand();
			}
			else
			{
				wpa.SetAnimation= "WeaponPutAway";
			}
		}
	}


	public override void CombatBegin()
	{//Begins to charge and attack. 
		if(IsMelee())
		{
			wpa.SetAnimation= GetWeapon () +"_" + GetStrikeType() + "_" + GetRace () + "_" + GetHand() + "_Charge";
		}
		else
		{
			//Check for ammo
			currentAmmo=playerUW.playerInventory.findObjInteractionByID(currWeaponRanged.AmmoType);
			if ((currentAmmo == null) && (ObjectInteraction.Alias(currWeaponRanged.AmmoType)!=currWeaponRanged.AmmoType))
			{//Ammo type has an alias. try and find that instead.
				currentAmmo=playerUW.playerInventory.findObjInteractionByID(ObjectInteraction.Alias(currWeaponRanged.AmmoType));
			}
			if (currentAmmo==null)
			{
				playerUW.playerHud.MessageScroll.Add ("Sorry, you have no " + playerUW.StringControl.GetObjectNounUW(currWeaponRanged.AmmoType));
				return;
			}
			else
			{
				//Change the crosshair
				playerUW.CursorIcon=playerUW.CursorIconTarget;
			}
		}

		AttackCharging=true;
		Charge=0;
	}
	
	public override void CombatCharging()	
	{//While still charging increase the charge by the charge rate.
		Charge=(Charge+(chargeRate*Time.deltaTime));
		//Debug.Log ("Charging up ");
		if (Charge>100)
		{
			Charge=100;
		}
	}

	public override IEnumerator ExecuteMelee()
	{		
		yield return new WaitForSeconds(0.6f);
		
		Ray ray ;
		if (playerUW.MouseLookEnabled==true)
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
					hit.transform.gameObject.GetComponent<ObjectInteraction>().Attack(10);
					//Create a blood splatter at this point
					GameObject hitimpact = new GameObject(hit.transform.name + "_impact");
					hitimpact.transform.position=hit.point;//ray.GetPoint(weaponRange/0.7f);
					Impact imp= hitimpact.AddComponent<Impact>();
					imp.FrameNo=objInt.GetHitFrameStart();
					imp.EndFrame=objInt.GetHitFrameEnd();
					StartCoroutine(imp.Animate());	
					if (currWeapon!=null)
					{
						currWeapon.onHit (hit.transform.gameObject);
					}
				}
				else
				{
					//do a miss impact 
					GameObject hitimpact = new GameObject(hit.transform.name + "_impact");
					hitimpact.transform.position=hit.point;//ray.GetPoint(weaponRange/0.7f);
					Impact imp= hitimpact.AddComponent<Impact>();
					imp.FrameNo=46;
					imp.EndFrame=50;
					StartCoroutine( imp.Animate());
					if (currWeapon!=null)
					{
						currWeapon.onHit (null);
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

		AttackExecuting=false;
		playerUW.playerHud.window.UWWindowWait(1.0f);
		
	}

	public override void ExecuteRanged ()
	{
		base.ExecuteRanged ();

		//Remove the cursor
		playerUW.CursorIcon=playerUW.CursorIconDefault;
		//Use up the ammo.
		if (currentAmmo!=null)
		{
			//currentAmmo.consumeObject ();
			LaunchAmmo();
		}
	}

	
	public override void ExecuteAttack()
	{
		if (playerUW.playerHud.window.JustClicked==false)
		{
			if (IsMelee())
			{
				wpa.SetAnimation= GetWeapon () + "_" + GetStrikeType () +"_" + GetRace () + "_" + GetHand() + "_Execute";
				AttackExecuting=true;
				StartCoroutine(ExecuteMelee());
			}
			else
			{//Ranged attack
				ExecuteRanged();
			}
			Charge=0.0f;
			AttackCharging=false;
		}
	}

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


	public string GetWeapon()
	{
		if (currWeapon!=null)
		{
			switch (currWeapon.Skill)
			{
			case 3:
				return "Sword";break;
			case 4:
				return "Axe";break;
			case 5:
				return "Mace";break;
			default:
				return "Fist";break;
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


	public string GetRace()
	{
		//It does'nt matter if you're black or white.
		
		//Except here where I need to the right skin tone for weapon animations
		switch (playerUW.Body)
		{
		case 1:
		case 3:
		case 4:
		case 5:
			return "White";break;
		default:
			return "Black";break;
		}
	}
	
	public string GetHand()
	{
		if (playerUW.isLefty)
		{
			return "Left";
		}
		else
		{
			return "Right";
		}
	}


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



	bool LaunchAmmo ()
	{
		if (currentAmmo!=null)
		{
			Ray ray ;
			if (playerUW.MouseLookEnabled==true)
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
			{//No object interferes with the drop
				float force = 500.0f;
				//Get the object being dropped and moved towards the end of the ray
				GameObject launchedItem ;//= playerUW.playerInventory.GetGameObjectInHand(); //GameObject.Find(playerUW.playerInventory.ObjectInHand);

				if (currentAmmo.GetQty()==1)
				{//launch the ammo itself.
					launchedItem = currentAmmo.gameObject;
					playerUW.playerInventory.RemoveItem(currentAmmo.name);
				}
				else
				{//copy a single instance as the ammo.
					launchedItem = Instantiate(currentAmmo.gameObject);
					launchedItem.name="launched_missile_" +playerUW.PlayerMagic.SummonCount++;
					launchedItem.GetComponent<ObjectInteraction>().Link=1;//Only 1
					ObjectInteraction.Split(launchedItem.GetComponent<ObjectInteraction>());
					currentAmmo.consumeObject();//Reduce by one.
				}
				launchedItem.transform.parent=null;
				launchedItem.GetComponent<ObjectInteraction>().PickedUp=false;	//Back in the real world
				//GameObject InvMarker = GameObject.Find ("InventoryMarker");

				launchedItem.transform.position=ray.GetPoint(dropRange-0.1f);//playerUW.transform.position;
				WindowDetect.UnFreezeMovement(launchedItem);
				//Vector3 ThrowDir = ray.GetPoint(dropRange) - playerUW.playerInventory.transform.position;
				Vector3 ThrowDir = ray.GetPoint(dropRange) - ray.origin;
				//Apply the force along the direction.
				launchedItem.GetComponent<Rigidbody>().AddForce(ThrowDir*force);
				GameObject myObjChild = new GameObject(launchedItem.name + "_damage");
				myObjChild.transform.position =launchedItem.transform.position;
				myObjChild.transform.parent =launchedItem.transform;
				ProjectileDamage pd= myObjChild.AddComponent<ProjectileDamage>();
				pd.Damage=10;
				return true;
			}
			else
			{
				return false;//unable to launch.
			}

		}
		else
		{//No ammo?? Should not happen
			return false;
		}
	}



}
