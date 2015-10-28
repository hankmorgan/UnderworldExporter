using UnityEngine;
using System.Collections;

public class ButtonHandler : object_base {
	public string trigger;
	public int triggerX;
	public int triggerY;
	public int state;
	public int maxstate;
	//public static GameObject player;

	public bool isOn;
	public string spriteOn;
	public string spriteOff;

	public bool isRotarySwitch;
	public string[] RotarySprites=new string[8];

	private GameObject triggerObj;
	//private UILabel MessageLog;
	private ObjectVariables Var;
	//private UWCharacter playerUW;
	private SpriteRenderer ButtonSprite;

	public bool SpriteSet;
	//public int item_id;

	//public static StringController SC;	//String controller reference

	// Use this for initialization
	protected override void Start () {
		base.Start();

		//MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
		triggerObj=GameObject.Find (trigger);
		Var=GetComponent<ObjectVariables>();

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
		return Activate ();
	}


	// Update is called once per frame
	void Update () {

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

	void OnGui(){
		//MessageLog.text=name;
	}

	void OnTriggerEnter()
	{
		//counter++;
		//MessageLog.text=name +"triggered";// + counter;
	}

	void OnMouseEnter()
	{
		//MessageLog.text=name +"entered";
	}

	void OnMouseExit()
	{
		//MessageLog.text=name +"exited";
	}

	public override bool LookAt ()
	{
	//public void LookAt()
		//Generally gives the object description but depending on the trigger target type it may activate (lookat trigger)
		ObjectInteraction TargetObjInt= triggerObj.GetComponent<ObjectInteraction>();
		ObjectInteraction objInt = this.gameObject.GetComponent<ObjectInteraction>();
		UILabel ml =objInt.getMessageLog();
		StringController Sc = objInt.getStringController();
		ml.text = Sc.GetString(1,260) + " " + Sc.GetFormattedObjectNameUW(objInt);
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
		ObjectVariables targetvars = triggerObj.GetComponent<ObjectVariables>();
		targetvars.triggerX=triggerX;
		targetvars.triggerY=triggerY;
		targetvars.state=Var.state;
		triggerObj.SendMessage ("Activate");//TODO:Test using a direct call to objectinteracion here?
		if (Var.state == maxstate)
		{
			Var.state=0;
		}
		else
		{
			Var.state++;
		}
		state=Var.state;
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
			Sprite image = Resources.Load <Sprite> (SpriteName);//Loads the sprite.
			ButtonSprite.sprite = image;//Assigns the sprite to the object.
		}

	}

	public void setRotarySprite(int index)
	{
		setSprite (RotarySprites[index]);
	}

}

