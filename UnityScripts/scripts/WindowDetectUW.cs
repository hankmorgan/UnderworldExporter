using UnityEngine;
using System.Collections;

public class WindowDetectUW : WindowDetect {

	public static UWCharacter playerUW;

	public override void Start ()
	{
		base.Start ();

		playerUW=GameObject.Find ("Gronk").GetComponent <UWCharacter>();
	}



	protected override void Update ()
	{
		base.Update ();

		switch (UWCharacter.InteractionMode)
		{
			case UWCharacter.InteractionModeAttack:
			{
				if (playerUW.PlayerCombat.AttackExecuting==true)
				{//No attacks can be started will executing the last one.
					return;
				}
				if  ((WindowDetectUW.CursorInMainWindow==false))
					{
					MouseHeldDown=false;
					playerUW.PlayerCombat.AttackCharging=false;
					}
				if ((MouseHeldDown==true)  )
				{
					if(playerUW.PlayerCombat.AttackCharging==false)
					{//Begin the attack
						playerUW.PlayerCombat.MeleeBegin();
					}
					if ((playerUW.PlayerCombat.AttackCharging==true) && (playerUW.PlayerCombat.Charge<100))
					{//While still charging increase the charge by the charge rate.
						playerUW.PlayerCombat.MeleeCharging ();
					}
					return;
				}
				else if (playerUW.PlayerCombat.AttackCharging==true)
				{
					//Player has been building an attack up and has released it.
					playerUW.PlayerCombat.MeleeExecute();
				}
				break;
			}
			default:
			{//TODO:Fix this drag object behaviour.
				/*if ((MouseHeldDown) && (pInv.ObjectInHand==""))
					{
					OnClick();
					}
				else if ((playerUW.CursorInMainWindow) && (pInv.ObjectInHand!="") && (MouseHeldDown==false) && (UWCharacter.InteractionMode==UWCharacter.InteractionModePickup))
					{//Drop the object in hand.
					ThrowObjectInHand();
					}*/
				break;
			}
		}
	}


	protected override void OnHover (bool isOver)
	{
		base.OnHover (isOver);

		if(! isOver )
		{
			playerUW.PlayerCombat.AttackCharging=false;
			playerUW.PlayerCombat.Charge=0;
			if (UWCharacter.InteractionMode==UWCharacter.InteractionModeAttack)
			{
				playerUW.PlayerCombat.wpa.SetAnimation= playerUW.PlayerCombat.GetWeapon () +"_Ready_" + playerUW.PlayerCombat.GetRace () + "_" + playerUW.PlayerCombat.GetHand();
			}
			else
			{
				playerUW.PlayerCombat.wpa.SetAnimation= "WeaponPutAway";
			}
		}
	}

	protected override void OnPress (bool isPressed)
	{
		if(CursorInMainWindow==false)
		{
			return;
		}
		base.OnPress(isPressed);
		//if (isPressed==false)
		//{
		//	Debug.Log ("HERE");
		//}
		//if(isPressed==true)
		//{
			switch (UWCharacter.InteractionMode)
			{
		case UWCharacter.InteractionModePickup:
				ClickEvent();
				break;
			default:
				break;
			}
		//}
	}


	void OnClick()
	{
		switch (UWCharacter.InteractionMode)
		{
		case UWCharacter.InteractionModePickup:
			break;
		default:
			ClickEvent();
			break;
		}

	}

	void ClickEvent()
	{
		if (playerUW.PlayerMagic.ReadiedSpell!="" )
		{
			Debug.Log("player has a spell to cast");
			return;
		}
		
		switch (UWCharacter.InteractionMode)
		{
		case UWCharacter.InteractionModeOptions://Options mode
			return;//do nothing
			break;
		case UWCharacter.InteractionModeTalk://Talk
			playerUW.TalkMode();
			break;
		case UWCharacter.InteractionModePickup://Pickup
			if (playerUW.gameObject.GetComponent<PlayerInventory>().ObjectInHand!="")
			{
				ThrowObjectInHand();
			}
			else
			{
				playerUW.PickupMode();
			}
			
			break;
		case UWCharacter.InteractionModeLook://look
			playerUW.LookMode();//do nothing
			break;
		case UWCharacter.InteractionModeAttack:	//attack
			playerUW.PlayerCombat.AttackModeMelee() ;//do nothing
			break;
		case UWCharacter.InteractionModeUse://Use
			if (playerUW.gameObject.GetComponent<PlayerInventory>().ObjectInHand!="")
			{
				UseObjectInHand ();
			}
			else
			{
				playerUW.UseMode();
			}
			break;
		}
	}


	protected override void UseObjectInHand ()
	{
		base.UseObjectInHand ();
		if (playerUW.playerInventory.ObjectInHand!="")
		{//The player is holding something
			//Determine what is directly in front of the player via a raycast
			//If something is in the way then cancel the drop
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
			
			if (Physics.Raycast(ray,out hit,playerUW.GetUseRange()))
			{
				if (hit.transform.gameObject.GetComponent<ObjectInteraction>()!=null)
				{
					hit.transform.gameObject.GetComponent<ObjectInteraction>().Use();
				}
				else
				{
					playerUW.CursorIcon= playerUW.CursorIconDefault;
					playerUW.playerInventory.ObjectInHand="";
				}
			}
			else
			{
				playerUW.CursorIcon= playerUW.CursorIconDefault;
				playerUW.playerInventory.ObjectInHand="";
			}
		}
	}

	protected override void ThrowObjectInHand ()
	{
		base.ThrowObjectInHand ();
		if (playerUW.playerInventory.GetObjectInHand()!="")
		{//The player is holding something
			if (playerUW.playerInventory.JustPickedup==false)//To prevent the click event dropping an object immediately after pickup
			{
				//Determine what is directly in front of the player via a raycast
				//If something is in the way then cancel the drop
				//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				
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
					//Calculate the force based on how high the mouse is
					float force = Input.mousePosition.y/Camera.main.pixelHeight *200;
					//float force = Camera.main.ViewportToWorldPoint(Input.mousePosition).y/Camera.main.pixelHeight *200;
					
					//Get the object being dropped and moved towards the end of the ray
					GameObject droppedItem = playerUW.playerInventory.GetGameObjectInHand(); //GameObject.Find(playerUW.playerInventory.ObjectInHand);
					droppedItem.transform.parent=null;
					droppedItem.GetComponent<ObjectInteraction>().PickedUp=false;	//Back in the real world
					GameObject InvMarker = GameObject.Find ("InventoryMarker");
					if (droppedItem.GetComponent<Container>()!=null)
					{
						Container.SetPickedUpFlag(droppedItem.GetComponent<Container>(),false);
						Container.SetItemsParent(droppedItem.GetComponent<Container>(),null);
						Container.SetItemsPosition (droppedItem.GetComponent<Container>(),InvMarker.transform.position);
					}
					droppedItem.transform.position=ray.GetPoint(dropRange-0.1f);//playerUW.transform.position;
					WindowDetect.UnFreezeMovement(droppedItem);
					if (Camera.main.ScreenToViewportPoint (Input.mousePosition).y>0.4f)
					{//throw if above a certain point in the view port.
						Vector3 ThrowDir = ray.GetPoint(dropRange) - playerUW.playerInventory.transform.position;
						//Apply the force along the direction.
						droppedItem.GetComponent<Rigidbody>().AddForce(ThrowDir*force);
					}
					
					//Clear the object and reset the cursor
					playerUW.CursorIcon= playerUW.CursorIconDefault;
					playerUW.playerInventory.SetObjectInHand("");
				}
				
			}
			else
			{
				
				playerUW.playerInventory.JustPickedup=false;//The next click event will allow dropping.
			}
			//try and drop the item in the world
		}

	}


	void OnGUI()
	{//Controls switching between Mouselook and interaction and sets the cursor icon
		if (Conversation.InConversation==true)
		{
			playerUW.XAxis.enabled=false;
			playerUW.YAxis.enabled=false;
			playerUW.MouseLookEnabled=false;
			Cursor.lockState = CursorLockMode.None;
			CursorPosition.center = Event.current.mousePosition;
			GUI.DrawTexture (CursorPosition,playerUW.CursorIcon);
			playerUW.MouseLookCursor.mainTexture= playerUW.CursorIconBlank;
		}
		else
		{
			if (Event.current.Equals(Event.KeyboardEvent("e")))
			{			
				if (playerUW.MouseLookEnabled==false)
				{
					playerUW.YAxis.enabled=true;
					playerUW.XAxis.enabled=true;
					playerUW.MouseLookEnabled=true;
					Cursor.lockState = CursorLockMode.Locked;
				}
				else
				{
					playerUW.XAxis.enabled=false;
					playerUW.YAxis.enabled=false;
					playerUW.MouseLookEnabled=false;
					Cursor.lockState = CursorLockMode.None;
				}
			}
			
			if (playerUW.MouseLookEnabled == true)
			{
				playerUW.MouseLookCursor.mainTexture=playerUW.CursorIcon;	
			}
			else
			{
				CursorPosition.center = Event.current.mousePosition;
				GUI.DrawTexture (CursorPosition,playerUW.CursorIcon);
				playerUW.MouseLookCursor.mainTexture= playerUW.CursorIconBlank;
			}		
		}
	}



}
