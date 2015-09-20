using UnityEngine;
using System.Collections;

public class ButtonHandler : MonoBehaviour {
	public string trigger;
	public int triggerX;
	public int triggerY;
	public int state;
	public int maxstate;
	public static GameObject player;

	public bool isOn;
	public string spriteOn;
	public string spriteOff;

	public bool isRotarySwitch;
	public string[] RotarySprites=new string[8];

	private GameObject triggerObj;
	private UILabel MessageLog;
	private ObjectVariables Var;
	private UWCharacter playerUW;
	private SpriteRenderer ButtonSprite;

	public bool SpriteSet;
	public int item_id;

	public static StringController SC;	//String controller reference

	// Use this for initialization
	void Start () {
		MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
		triggerObj=GameObject.Find (trigger);
		Var=GetComponent<ObjectVariables>();
		if (player!=null)
		{
			playerUW=player.GetComponent<UWCharacter>();
		}

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
	
	// Update is called once per frame
	void Update () {
	if (triggerObj == null)
		{
			triggerObj=GameObject.Find (trigger);
		}
		if ((player!=null) && (playerUW==null))
		{
			playerUW=player.GetComponent<UWCharacter>();
		}

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

	//public string LookDescription()
	//{//Returns the description of this object.
	//	return SC.GetString("004",item_id.ToString ("000"));
	//}

	public void LookAt()
	{
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
	}

	public void Activate()
	{
		//float distance;
		//distance =Vector3.Distance(transform.position,player.transform.position);
		//if (distance<=playerUW.useRange)
		//{
		//MessageLog.text = "You use a " + name;
		ObjectVariables targetvars = triggerObj.GetComponent<ObjectVariables>();
		targetvars.triggerX=triggerX;
		targetvars.triggerY=triggerY;
		targetvars.state=Var.state;
		triggerObj.SendMessage ("Activate");
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




		//}
		//else
		//{
		//	MessageLog.text = "That is too far away to use";
		//}
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

/*	void OnMouseDown()
		{
		//THIS IS NOT IN USE!!!!!!!!!
		return;
		float distance;
		switch (UWCharacter.InteractionMode)
			{
			case 0://Options
				MessageLog.text = "Nothing will happen in options mode " + name;
				break;
			case 1://Talk
				MessageLog.text = "You can't talk to " + name;
				break;
			case 2://Pickup
				MessageLog.text = "You pick up a " + name;
				break;
			case 4://Look
				MessageLog.text = "You see a " + name;
				break;
			case 8://Attack
				MessageLog.text = "You attack a " + name;
				break;
			case 16://Use
			//distance =Vector3.Distance(transform.position,player.transform.position);
			//if (distance<=playerUW.InteractionDistance)
				//{
				MessageLog.text = "You use a " + name;
				ObjectVariables targetvars = triggerObj.GetComponent<ObjectVariables>();
				targetvars.triggerX=triggerX;
				targetvars.triggerY=triggerY;
				targetvars.state=Var.state;
				MessageLog.text=name +"_clicked";
				triggerObj.SendMessage ("Activate");
				if (Var.state == 8)
					{
						Var.state=0;
					}
				else
					{
						Var.state++;
					}
				
				//}
			//else
			//{
			//	MessageLog.text = "That is too far away to use";
			//}
			break;
		}
	}*/	
}

