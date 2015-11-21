using UnityEngine;
using System.Collections;

public class ButtonHandler : object_base {
	/*Code for buttons and switches*/

	public string trigger;
	public int triggerX;
	public int triggerY;
	public int state;
	public int maxstate;

	public bool isOn;
	public string spriteOn;
	public string spriteOff;

	public bool isRotarySwitch;
	public string[] RotarySprites=new string[8];

	private GameObject triggerObj;

	private SpriteRenderer ButtonSprite;

	public bool SpriteSet;

	// Use this for initialization
	protected override void Start () {
		base.Start();

		//MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
		//
		//Var=GetComponent<ObjectVariables>();

		ButtonSprite=this.gameObject.GetComponentInChildren<SpriteRenderer>();
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
			setRotarySprite(state);
		}
	}


	public override bool use ()
	{
		if (playerUW.playerInventory.ObjectInHand=="")
		{
			return Activate ();
		}
		else
		{
			return ActivateByObject(playerUW.playerInventory.GetGameObjectInHand());
		}
	}


	// Update is called once per frame
	void Update () {
		return;
		if (SpriteSet==false)
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
				setRotarySprite(state);
			}
		}
	}

	public override bool LookAt ()
	{
	//public void LookAt()
		//Generally gives the object description but depending on the trigger target type it may activate (lookat trigger)
		if (triggerObj==null)
		{
			triggerObj=GameObject.Find (trigger);
		}
		ObjectInteraction TargetObjInt= triggerObj.GetComponent<ObjectInteraction>();
		ml.text =playerUW.StringControl.GetFormattedObjectNameUW(objInt);
		if (TargetObjInt.ItemType==ObjectInteraction.A_LOOK_TRIGGER)//A look trigger.
			{
			this.Activate();
			}
		return true;
	}

	public bool Activate()
	{
		if (triggerObj == null)
		{
			triggerObj=GameObject.Find (trigger);
		}

		triggerObj.GetComponent<trigger_base>().state=state;
		triggerObj.GetComponent<trigger_base>().Activate();

		if (state == maxstate)
		{
			state=0;
		}
		else
		{
			state++;
		}
		if (isRotarySwitch ==false)
		{
			if (isOn==false)
			{
				isOn=true;
				setSprite(spriteOn);
			}
			else
			{
				isOn=false;
				setSprite(spriteOff);
			}
		}
		else
		{
			setRotarySprite(state);
		}
		return true;
	}


	public void setSprite(string SpriteName)
	{

		if (SpriteName!="")
		{
			ButtonSprite.sprite = Resources.Load <Sprite> (SpriteName);//Loads the sprite.;//Assigns the sprite to the object.
		}

	}

	public void setRotarySprite(int index)
	{
		setSprite (RotarySprites[index]);
	}


	public override bool ActivateByObject (GameObject ObjectUsed)
	{
		ObjectInteraction objIntUsed = ObjectUsed.GetComponent<ObjectInteraction>();
		if (objIntUsed!=null)
		{
			switch (objIntUsed.ItemType)
			{
			case ObjectInteraction.POLE:
				playerUW.playerInventory.ObjectInHand="";
				playerUW.CursorIcon=playerUW.CursorIconDefault;
				playerUW.GetMessageLog ().text = playerUW.StringControl.GetString(1,157);
				return Activate();
				break;
			default:
				playerUW.playerInventory.ObjectInHand="";
				playerUW.CursorIcon=playerUW.CursorIconDefault;
				objIntUsed.FailMessage();
				return false;
				break;
			}
		}
		return false;
	}
}

