using UnityEngine;
using System.Collections;

public class object_base : MonoBehaviour {
//Base class for objects.
	//Will probably put some code here eventually for common things like piping messages to the message log.
	public static UWCharacter playerUW;
	public static UILabel ml;
	protected ObjectInteraction objInt;


	protected virtual void Start()
	{
		if (playerUW==null)
		{
			playerUW=GameObject.Find ("Gronk").GetComponent<UWCharacter>();
		}

		CheckReferences();

	}

	public virtual bool Activate()
	{//Unimplemented items 
		//Debug.Log ("default activate for " + this.gameObject.name);
		CheckReferences();
		return false;
	}


	public virtual bool ApplyAttack(int damage)
	{
	//	Debug.Log ("default apply attack for " + this.gameObject.name);
		return false;
	}


	public virtual bool LookAt()
	{
		//Debug.Log ("default lookat for " + this.gameObject.name);
		CheckReferences();
		ml.text=playerUW.StringControl.GetFormattedObjectNameUW(objInt);
		return true;
	}


	public virtual bool ActivateByObject(GameObject ObjectUsed)
	{
		//Debug.Log ("default activatebyobj for " + this.gameObject.name);
		CheckReferences();
		if (UWCharacter.InteractionMode== UWCharacter.InteractionModeUse)
		{
			FailMessage();
			playerUW.CursorIcon= playerUW.CursorIconDefault;
			playerUW.playerInventory.ObjectInHand="";
			return true;
		}
		else
		{
			return false;
		}
	}

	public virtual bool use()
	{

		//Debug.Log ("default use for " + this.gameObject.name);
		CheckReferences();
		if (playerUW.playerInventory.ObjectInHand!="")
		{
			return false;
		}
		else
		{
			return ActivateByObject(playerUW.playerInventory.GetGameObjectInHand());
		}

	}

	protected void CheckReferences()
	{
		if (objInt==null)
		{
			objInt = this.gameObject.GetComponent<ObjectInteraction>();
		}
		if ((objInt!=null) && (ml==null))
		{
			ml=objInt.getMessageLog ();
		}
	}

	public void BecomeObjectInHand()
	{//In order to use it.
		playerUW.CursorIcon= objInt.InventoryDisplay.texture;
		playerUW.playerInventory.ObjectInHand=this.name;
		UWCharacter.InteractionMode=UWCharacter.InteractionModeUse;
		InteractionModeControl.UpdateNow=true;
	}

	public virtual bool TalkTo()
	{
		//000~001~156~You cannot talk to that.
		playerUW.GetMessageLog ().text=playerUW.StringControl.GetString (1,156);
		return true;
	}

	public virtual bool Eat()
	{
		//For when the player tries to eat certain objects by dragging them on top of the paper doll face. For future use?
		return false;
	}

	public virtual bool PickupEvent()
	{//For special events when an object is picked up. Eg silver seed.
		return false;
	}

	public virtual bool EquipEvent(int slotNo)
	{
		return false;
	}

	public virtual bool UnEquipEvent(int slotNo)
	{
		return false;
	}

	public virtual bool FailMessage()
	{
		//Message to display when this object is used on a another object that has no use for it. Eg a key on a sign.
		ml.text="You cannot use this. (Failmessage default)";
		return false;
	}
}