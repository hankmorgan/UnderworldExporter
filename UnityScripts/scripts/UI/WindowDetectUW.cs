using UnityEngine;
using System.Collections;

public class WindowDetectUW : WindowDetect {
	public	bool JustClicked;
	public static bool UsingRoomManager =false;
	public int WindowWaitCount=0;
	public static UWCharacter playerUW;
	public override void Start ()
	{
		base.Start ();
		JustClicked=false;
		WindowWaitCount=0;
		playerUW=GameWorldController.instance.playerUW;
	}

	public void UWWindowWait(float waitTime)
	{
		//Cancel all click input for a few seconds.
		JustClicked=true;//Prevent catching something I have just thrown.
		Invoke("ResetClick",waitTime);
		WindowWaitCount++;
	}

	void ResetClick()
	{//All click input again.
		WindowWaitCount--;
		JustClicked=(WindowWaitCount>0);
	}


	protected override void Update ()
	{
		if (playerUW.isRoaming==true)
		{//No inventory use while using wizard eye.
				return;
		}
		base.Update ();
		if (JustClicked==true)
		{
			return;
		}
		switch (UWCharacter.InteractionMode)
		{
			case UWCharacter.InteractionModeAttack:
			{
				if (playerUW.PlayerMagic.ReadiedSpell!="")								
				{//Player has spell to fire off first
						return;
				}
				if (playerUW.PlayerCombat.AttackExecuting==true)
				{//No attacks can be started while executing the last one.
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
						playerUW.PlayerCombat.CombatBegin();
					}
					if ((playerUW.PlayerCombat.AttackCharging==true) && (playerUW.PlayerCombat.Charge<100))
					{//While still charging increase the charge by the charge rate.
						playerUW.PlayerCombat.CombatCharging ();
					}
					return;
				}
				else if (playerUW.PlayerCombat.AttackCharging==true)
				{
					//Player has been building an attack up and has released it.
					playerUW.PlayerCombat.ExecuteAttack();
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
		if (playerUW.isRoaming==true)
		{//No inventory use while using wizard eye.
				return;
		}
		base.OnPress(isPressed);
		if(CursorInMainWindow==false)
		{
			return;
		}
		if (JustClicked==true)
		{
			return;
		}
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
		//Invoke("ResetClick",0.5f);
		//}
	}


	void OnClick()
	{
		if (playerUW.isRoaming==true)
		{//No inventory use while using wizard eye.
				return;
		}				
		if (JustClicked==true)
		{
			return;
		}
		switch (UWCharacter.InteractionMode)
		{
		case UWCharacter.InteractionModePickup:
			break;
		default:
			ClickEvent();
			break;
		}

		//JustClicked=true;
		//Invoke("ResetClick",0.5f);
	}


	void ClickEvent()
	{
		if ((playerUW.PlayerMagic.ReadiedSpell!="" ) ||(JustClicked==true))
		{
			//Debug.Log("player has a spell to cast");
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
				UWWindowWait(1.0f);

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
				//UseObjectInHand ();
				playerUW.UseMode();
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
					//Clone the object in hand and give it a new uid
					if (UsingRoomManager==true)
					{
							GameObject objClone = new GameObject();  //Instantiate(droppedItem);
							objClone.name=droppedItem.name;
							droppedItem.GetComponent<ObjectInteraction>().CopyGameObjectInteraction(objClone);
							droppedItem.GetComponent<object_base>().CopyObject_base(objClone);
							//Copy the sprite
							GameObject objCloneChild=new GameObject(objClone.name + "_sprite");
							objCloneChild.transform.parent=objClone.transform;
							objCloneChild.AddComponent<Billboard>();
							objCloneChild.AddComponent<SpriteRenderer>();
							objCloneChild.GetComponent<SpriteRenderer>().material=Resources.Load<Material>("Materials/SpriteShader");//=droppedItem.GetComponentInChildren<SpriteRenderer>().material;
							objCloneChild.transform.localScale=new Vector3(2.0f,2.0f,2.0f);
							objCloneChild.transform.localPosition=Vector3.zero;
							//objClone.AddComponent<StoreInformation>();
							//objCloneChild.AddComponent<StoreInformation>();
							droppedItem.name=droppedItem.name+ "_destroyed";
							//droppedItem.transform.DestroyChildren();
							DestroyImmediate(droppedItem.gameObject);
							droppedItem=objClone;		
					}

					droppedItem.transform.parent=null;
					droppedItem.GetComponent<ObjectInteraction>().PickedUp=false;	//Back in the real world
					droppedItem.GetComponent<ObjectInteraction>().UpdateAnimation();
					//GameObject InvMarker = GameObject.Find ("InventoryMarker");
					if (droppedItem.GetComponent<Container>()!=null)
					{
						Container.SetPickedUpFlag(droppedItem.GetComponent<Container>(),false);
						Container.SetItemsParent(droppedItem.GetComponent<Container>(),null);
						Container.SetItemsPosition (droppedItem.GetComponent<Container>(),playerUW.playerInventory.InventoryMarker.transform.position);
					}
					droppedItem.transform.position=ray.GetPoint(dropRange-0.1f);//playerUW.transform.position;
					WindowDetect.UnFreezeMovement(droppedItem);
					if (Camera.main.ScreenToViewportPoint (Input.mousePosition).y>0.4f)
					{//throw if above a certain point in the view port.
						//Vector3 ThrowDir = ray.GetPoint(dropRange) - playerUW.playerInventory.transform.position;
						Vector3 ThrowDir = ray.GetPoint(dropRange) - ray.origin;
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



	public void SetFullScreen()
	{
		FullScreen=true;
		//chains.EnableDisableControl("main_window",false);
		if (anchor==null)
		{
			anchor =this.GetComponent<UIAnchor>();
		}
		if (stretch==null)
		{
			stretch=this.GetComponent<UIStretch>();
		}
		anchor.side= UIAnchor.Side.Center;
		anchor.relativeOffset=new Vector2(0.0f,0.0f);
		stretch.relativeSize=new Vector2 (1.0f,1.0f);
		if (playerUW==null)
		{
			playerUW=GameWorldController.instance.playerUW;//GameObject.Find ("Gronk").GetComponent<UWCharacter>();
		}
		playerUW.playerCam.rect= new Rect(0.0f,0.0f,1.0f,1.0f);
		
		playerUW.playerHud.main_window.enabled=false;
		/*
		playerUW.playerHud.compass.MoveControlOffset(-0.1f,0.0f);
		for (int i = 0; i<=playerUW.playerHud.compass.NorthIndicators.GetUpperBound(0);i++)
		{
			GuiBase cn=  playerUW.playerHud.compass.NorthIndicators[i].GetComponent<GuiBase>();
			if (cn!=null)
			{
				cn.MoveControlOffset(-0.1f,0.0f);
			}
		}*/
	}

	public void UnSetFullScreen()
	{
		FullScreen=false;
		//chains.EnableDisableControl("main_window",true);
	
		anchor.side= UIAnchor.Side.Left;
		anchor.relativeOffset=new Vector2(0.43f,0.13f);
		stretch.relativeSize=new Vector2 (0.55f,0.57f);
		playerUW.playerCam.rect= new Rect(0.163f,0.335f,0.54f,0.572f);
		playerUW.playerHud.main_window.enabled=true;
		/*
		playerUW.playerHud.compass.MoveControlOffset(+0.1f,0.0f);
		for (int i = 0; i<=playerUW.playerHud.compass.NorthIndicators.GetUpperBound(0);i++)
		{
			GuiBase cn=  playerUW.playerHud.compass.NorthIndicators[i].GetComponent<GuiBase>();
			if (cn!=null)
			{
				cn.MoveControlOffset(+0.1f,0.0f);
			}
		}
		*/
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

			if (Event.current.Equals(Event.KeyboardEvent("f")))
			{//Toggle full screen.
				if (FullScreen==true)
				{
					UnSetFullScreen();
				}
				else
				{
					SetFullScreen();
				}
			}

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
