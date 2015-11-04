using UnityEngine;
using System.Collections;

public class ButtonHandler : object_base {
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
			return playerUW.playerInventory.GetGameObjectInHand().GetComponent<ObjectInteraction>().FailMessage();
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
		//ObjectInteraction objInt = this.gameObject.GetComponent<ObjectInteraction>();
	//	UILabel ml =objInt.getMessageLog();
		//StringController Sc = objInt.getStringController();
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
		//if ((player!=null) && (playerUW==null))
		//{
		//	playerUW=player.GetComponent<UWCharacter>();
		//}

		//float distance;
		//distance =Vector3.Distance(transform.position,player.transform.position);
		//if (distance<=playerUW.useRange)
		//{
		//MessageLog.text = "You use a " + name;
		//ObjectVariables targetvars = triggerObj.GetComponent<ObjectVariables>();
		//targetvars.triggerX=triggerX;
		//targetvars.triggerY=triggerY;
		//targetvars.state=Var.state;

		//triggerObj.SendMessage ("Activate");//TODO:Test using a direct call to objectinteracion here?


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

		//state=Var.state;
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
			//Debug.Log (this.name+ ":setting sprite " + SpriteName);
			//Sprite image = 
			ButtonSprite.sprite = Resources.Load <Sprite> (SpriteName);//Loads the sprite.;//Assigns the sprite to the object.
		}

	}

	public void setRotarySprite(int index)
	{
		setSprite (RotarySprites[index]);
	}

}

