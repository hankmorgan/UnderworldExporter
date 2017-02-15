using UnityEngine;
using System.Collections;

public class ButtonHandler : object_base {
	/*Code for buttons and switches*/

//	public string trigger;
	//public int triggerX;
	//public int triggerY;
	//public int state;//Should be flags.
	//public int maxstate

	public bool isOn;
	public int itemdIDOn;
	public int itemdIDOff;

	//public bool isRotarySwitch;
	public int[] RotaryImageIDs=new int[8];

	//private GameObject triggerObj;

	//private SpriteRenderer ButtonSprite;

	public bool SpriteSet;
		private int currentItemID; //for tracking id changes

	// Use this for initialization
	protected override void Start () {
		base.Start();
		objInt().flags=objInt().flags;
		//MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
		//
		//Var=GetComponent<ObjectVariables>();


		//ButtonSprite=this.gameObject.GetComponentInChildren<SpriteRenderer>();
		if (isRotarySwitch()==false)
		{
			//set sprites ids
			if ((objInt().item_id >= 368) && (objInt().item_id <= 375))
			{//is an off version 
				itemdIDOff=objInt().item_id-368;
				itemdIDOn=objInt().item_id-368+8;					
			}
			else
			{
				itemdIDOff=objInt().item_id-368-8;
				itemdIDOn=objInt().item_id-368;	
			}
			if (isOn==true)
			{
				setSprite(itemdIDOn);
			}
			else
			{
				setSprite(itemdIDOff);
			}
		}
		else
		{
			//Populate the array of item ids
						int StartImageId;
						if (objInt().item_id==353)
						{
								StartImageId=4;	
						}
						else
						{
								StartImageId=12;	
						}
						for (int i = 0; i<8;i++)
						{
								RotaryImageIDs[i] =StartImageId+i;	
						}
			setRotarySprite(objInt().flags);
		}
	}

		void Update()
		{
				if (isRotarySwitch()==false)
				{
						if ((isOn) && (currentItemID!=itemdIDOn))
						{
								setSprite(itemdIDOn);	
						}
						if ((!isOn) && (currentItemID!=itemdIDOff) )
						{
								setSprite(itemdIDOff);	
						}
				}
				else
				{
						if(currentItemID!= objInt().flags)
						{
							setRotarySprite(objInt().flags);
						}
				}
		}


		bool isRotarySwitch()
		{
				//353
				//354
				switch(objInt().item_id)
				{
				case 353:
				case 354:
					return true;
				default:
					return false;
				}
		}

	public override bool use ()
	{
		if (GameWorldController.instance.playerUW.playerInventory.ObjectInHand=="")
		{
			//Debug.Log("USE!");
			return Activate ();
		}
		else
		{
			return ActivateByObject(GameWorldController.instance.playerUW.playerInventory.GetGameObjectInHand());
		}
	}

		/*
	// Update is called once per frame
	void Update () {
		return;
		/*if (SpriteSet==false)
		{
			SpriteSet=true;
			if (isRotarySwitch==false)
			{
				if (isOn==true)
				{
					setSprite(spriteOn);
				}
				else
				{
					setSprite(spriteOff);
				}
			}
			else
			{
				setRotarySprite(objInt().flags);
			}
		}*/
	//}

	public override bool LookAt ()
	{
	//public void LookAt()
		//Generally gives the object description but depending on the trigger target type it may activate (lookat trigger)
						//GameObject triggerObj= ObjectLoader.getObjectIntAt(objInt().link).gameObject;
		GameObject triggerObj= ObjectLoader.getGameObjectAt(objInt().link);
		if (triggerObj!=null)
		{
			ObjectInteraction TargetObjInt= triggerObj.GetComponent<ObjectInteraction>();
			UWHUD.instance.MessageScroll.Add(StringController.instance.GetFormattedObjectNameUW(objInt()));
			if (TargetObjInt.GetItemType()==ObjectInteraction.A_LOOK_TRIGGER)//A look trigger.
			{
				base.LookAt();
				this.Activate();
			}
			else
			{
				base.LookAt();
			}
		}
		else
		{
			base.LookAt();
		}
		return true;
	}


	public override bool Activate()
	{
						if (objInt().link==0)
						{
								return false;
						}
		//if (trigger=="")
		//{
			//return false;
		//}
		//if (triggerObj == null)
		//{
		//	triggerObj=GameObject.Find (trigger);
		//}
		if (ObjectLoader.getGameObjectAt(objInt().link)==null)
				{return false;}
		GameObject triggerObj= ObjectLoader.getObjectIntAt(objInt().link).gameObject;
		if (triggerObj==null)
		{
			return true;//Cannot activate.
		}
		if (triggerObj.GetComponent<trigger_base>()==null)
		{
			return false;
		}
		//triggerObj.GetComponent<trigger_base>().objInt().flags=objInt().flags;//Not sure this needs to be done?
		triggerObj.GetComponent<trigger_base>().Activate();

		if (isRotarySwitch())
		{
			if (objInt().flags == 7)
			{
				objInt().flags=0;
			}
			else
			{
				objInt().flags++;
			}	
		}

		if (isRotarySwitch() ==false)
		{
			if (isOn==false)
			{
				isOn=true;
				setSprite(itemdIDOn);
			}
			else
			{
				isOn=false;
				setSprite(itemdIDOff);
			}
		}
		else
		{
			setRotarySprite(objInt().flags);
		}
		return true;
	}

				/*
	public void setSprite(string SpriteName)
	{
		ButtonSprite.sprite = Resources.Load <Sprite> (SpriteName);//Loads the sprite.;//Assigns the sprite to the object.
		objInt().animationStarted=true;
	}*/

	public void setSprite(int SpriteID)
	{
			//UW1/Sprites/tmflat/tmflat_00%02d
		setSpriteTMFLAT ( this.GetComponentInChildren<SpriteRenderer>(), SpriteID);//Loads the sprite.;//Assigns the sprite to the object.			
		currentItemID=SpriteID;
	}


	public void setRotarySprite(int spriteId)
	{
		setSpriteTMOBJ (this.GetComponentInChildren<SpriteRenderer>(), RotaryImageIDs[spriteId] );
		currentItemID=spriteId;
	}


	public override bool ActivateByObject (GameObject ObjectUsed)
	{
		ObjectInteraction objIntUsed = ObjectUsed.GetComponent<ObjectInteraction>();
		if (objIntUsed!=null)
		{
			switch (objIntUsed.GetItemType())
			{
			case ObjectInteraction.POLE:
				GameWorldController.instance.playerUW.playerInventory.ObjectInHand="";
				UWHUD.instance.CursorIcon=UWHUD.instance.CursorIconDefault;
				UWHUD.instance.MessageScroll.Set (StringController.instance.GetString(1,157));
				return Activate();
			default:
				GameWorldController.instance.playerUW.playerInventory.ObjectInHand="";
				UWHUD.instance.CursorIcon=UWHUD.instance.CursorIconDefault;
				objIntUsed.FailMessage();
				return false;
			}
		}
		return false;
	}


		public override string UseObjectOnVerb_World ()
		{
			ObjectInteraction ObjIntInHand=GameWorldController.instance.playerUW.playerInventory.GetObjIntInHand();
			if (ObjIntInHand!=null)
			{
				switch (ObjIntInHand.GetItemType())	
					{
						case ObjectInteraction.POLE:
							return "trigger with pole";
					}
			}

			return base.UseObjectOnVerb_Inv();
		}


}

