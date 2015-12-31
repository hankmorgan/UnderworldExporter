using UnityEngine;
using System.Collections;

public class UWCombat : Combat {

	public UWCharacter playerUW;
	public Weapon currWeapon;

	public override void PlayerCombatUpdate ()
	{
		base.PlayerCombatUpdate ();

		if ((AttackCharging==false) && (AttackExecuting==false))
		{
			if ((UWCharacter.InteractionMode==UWCharacter.InteractionModeAttack))
			{
				//mus.WeaponDrawn=true;//Tell the music system I have my weapon drawn
				wpa.SetAnimation= GetWeapon () +"_Ready_" + GetRace () + "_" + GetHand();
			}
			else
			{
				wpa.SetAnimation= "WeaponPutAway";
			}
		}

	}


	/*******************/


	public override void MeleeBegin()
	{//Begins to charge and attack. 
		wpa.SetAnimation= GetWeapon () +"_" + GetStrikeType() + "_" + GetRace () + "_" + GetHand() + "_Charge";
		AttackCharging=true;
		Charge=0;
	}
	
	public override void MeleeCharging()	
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
	
	public override void MeleeExecute()
	{
		if (playerUW.playerHud.window.JustClicked==false)
		{
			wpa.SetAnimation= GetWeapon () + "_" + GetStrikeType () +"_" + GetRace () + "_" + GetHand() + "_Execute";
			AttackExecuting=true;
			StartCoroutine(ExecuteMelee());
			Charge=0.0f;
			AttackCharging=false;
		}
	}
	/*
	public override void AttackModeMelee()
	{//Code to handle melee Combat
		return;
		//Begins to charge and attack. 
		//As long as the cursor is in the main window the attack will continue to build up.
		if(Input.GetMouseButton(1) && (WindowDetect.CursorInMainWindow==true) && (AttackCharging==false))
		{//Begin the attack.
			MeleeBegin();
		}
		if ((AttackCharging==true) && (Charge<100))
		{//While still charging increase the charge by the charge rate.
			MeleeCharging ();
		}
		if (Input.GetMouseButtonUp (1) && (WindowDetect.CursorInMainWindow==true) && (AttackCharging==true))
		{//On right click find out what is at the mouse cursor and execute the attack along the raycast
			MeleeExecute ();
		}
		
	}*/
	

	public string GetWeapon()
	{
		string ObjInWeaponHand;
		if (playerUW.isLefty)
		{
			ObjInWeaponHand= playerUW.playerInventory.sLeftHand;
		}
		else
		{
			ObjInWeaponHand= playerUW.playerInventory.sRightHand;
		}
		
		
		if (ObjInWeaponHand=="")
		{
			return "Fist";
		}
		else
		{
			GameObject handobj = GameObject.Find (ObjInWeaponHand);
			Weapon weap = handobj.GetComponent<Weapon>();
			if(weap!=null)
			{
				switch (weap.Skill)
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


}
