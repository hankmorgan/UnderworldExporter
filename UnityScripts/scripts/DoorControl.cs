using UnityEngine;
using System.Collections;

public class DoorControl : object_base {
	/*Class for manipulating doors*/

	public bool locked;
	public int KeyIndex;//What keys can open this
	public bool state;	//True for open, false for closed.
	public bool isPortcullis;//Special cases. Sets direction of opening
	public bool DoorBusy;//Is the door opening or closing. Used to keep if flying off it's hinges!
	public bool Pickable;//Sets if the lock can be picked.
	public bool Spiked;//Is the door spiked/
	private bool PlayerUse=false;//Is it the player using the object or a trigger/trap.
	public string UseLink;//A trigger to activate when opened.

	public override bool use ()
	{
		if (playerUW.playerInventory.ObjectInHand !="")
		{
			ActivateByObject(playerUW.playerInventory.GetGameObjectInHand());
			//Clear the object in hand
			playerUW.CursorIcon= playerUW.CursorIconDefault;
			playerUW.playerInventory.ObjectInHand="";
			return true;	
		}
		else
		{//Normal Usage
			PlayerUse=true;
			Activate();
			PlayerUse=false;
			return true;
		}
	}

	public override bool ActivateByObject(GameObject ObjectUsed)
	{//Code for handling otherobjects used on this object
	//Doors can be used by keys, picks and spikes.
		//ObjectInteraction objIntThis = this.GetComponent<ObjectInteraction>();
		ObjectInteraction objIntUsed = ObjectUsed.GetComponent<ObjectInteraction>();
		if (objIntUsed != null) 
		{
			switch (objIntUsed.ItemType)
				{
				case ObjectInteraction.KEY: //Key
				DoorKey dk = ObjectUsed.GetComponent<DoorKey>();
				if (dk !=null)
					{
					if (state==true)
					{
						//Door is already open
						ml.Add(playerUW.StringControl.GetString (1,6));
						return true;
					}
						
						if(KeyIndex==dk.KeyId)//This is a valid key for the door.
						{
							ToggleLock();
							if (locked==true)
								{//Locked message
								ml.Add(playerUW.StringControl.GetString (1,4));
								}
							else
								{//Unlockedmessage
								ml.Add (playerUW.StringControl.GetString (1,5));
								}
						}
					else
						{
						if (KeyIndex==53)
							{//There is no lock
							ml.Add (playerUW.StringControl.GetString (1,3));
							}
						else
							{//That is the wrong key.
							ml.Add(playerUW.StringControl.GetString (1,2));
							}
						}

					}					
					break;
				case ObjectInteraction.LOCKPICK:	//lockpick
					{
					if (Pickable==true)
						{
						if (playerUW.PlayerSkills.TrySkill(Skills.SkillPicklock, objIntUsed.Quality))
							{
							ml.Add (playerUW.StringControl.GetString (1,121));
							UnlockDoor();
							}
						else
							{
							//Debug.Log ("Picklock failed!");
							ml.Add (playerUW.StringControl.GetString (1,120));
							objIntUsed.consumeObject();
							}
						}
					else
						{
						ml.Add (playerUW.StringControl.GetString (1,120));
						}
					break;
					}
				case ObjectInteraction.SPIKE:
					{
					if (Spiked==false)
						{
					//000~001~128~You can only spike closed doors.
					//000~001~129~The door is now spiked closed.
					//000~001~130~Please select door to spike...
					//000~001~131~The door is spiked.
						if (state==false)
							{//Closed door
							ml.Add (playerUW.StringControl.GetString(1,129));
							Spiked=true;
							objIntUsed.consumeObject();							
							}
						else
							{
							ml.Add (playerUW.StringControl.GetString(1,128));
							}						
						}
					else
						{
						ml.Add (playerUW.StringControl.GetString(1,131));
						}
					return true;
					}
				default:
					return false;
				}
		}
		else
		{
			return false;
		}
		return true;
	}


	public override bool Activate()
	{
		//		Debug.Log (this.name + " touched");
		if (locked==false)
		{//Toggle Open and closed
			if (state==false)
				{//Door is closed
				OpenDoor ();
				}
			else
				{//Door is open
				CloseDoor ();
				}
		}
		else
		{
			if (PlayerUse==true)
			{
				ml.Add ("The " + playerUW.StringControl.GetObjectNounUW(objInt) + " is locked.");
			}
		}
		return true;
	}

	public void OpenDoor()
	{
		if (state==false)
			{
			if(!DoorBusy)
			{
				if (isPortcullis==false)
				{
					StartCoroutine(RotateDoor (this.transform,Vector3.up * 90,1.0f));
				}
				else
				{
					StartCoroutine(RaiseDoor (this.transform,new Vector3(0f,1.1f,0f),1.0f));
				}
				objInt.item_id+=8;
				state=true;
				if (UseLink!="")
				{
					GameObject trigObj = GameObject.Find (UseLink);
					if (trigObj!=null)
					{
						trigger_base tb = trigObj.GetComponent<trigger_base>();
						tb.Activate();
					}
				}
			}
		}
	}

	public void CloseDoor()
	{
		if (state==true)
		{
			if(!DoorBusy)
			{
				if (isPortcullis==false)
				{
					StartCoroutine(RotateDoor (this.transform,Vector3.up * -90,1.0f));
				}
				else
				{
					StartCoroutine(RaiseDoor (this.transform,new Vector3(0f,-1.1f,0f),1.0f));
				}
				objInt.item_id-=8;
				state=false;
			}
		}
	}

	public void LockDoor()
	{
		locked=true;
	}

	public void UnlockDoor()
	{
		locked=false;
	}

	public void ToggleLock()
	{
		if (locked==false)
		{
			locked=true;	
		}
		else
		{
			locked=false;	
		}
	}

	public void ToggleDoor()
	{
		if (state==false)//Closed
		{
			UnlockDoor();
			OpenDoor();	
		}
		else
		{
			CloseDoor ();
			LockDoor();
		}
	}


	IEnumerator RotateDoor(Transform door, Vector3 turningAngle, float traveltime)
	{
		Quaternion StartAngle = door.rotation;
		Quaternion EndAngle = Quaternion.Euler (door.eulerAngles+turningAngle);
		DoorBusy=true;
		for (float t = 0.0f; t<traveltime; t+=Time.deltaTime/traveltime)
		{
			door.rotation=Quaternion.Lerp (StartAngle,EndAngle,t);
			yield return null;
		}
		DoorBusy=false;
	}
	
	IEnumerator RaiseDoor(Transform door, Vector3 TransformDir, float traveltime)
	{
		float rate = 1.0f/traveltime;
		float index = 0.0f;
		Vector3 StartPos = door.position;
		Vector3 EndPos = StartPos + TransformDir;
		DoorBusy=true;
		while (index <traveltime)
		{
			door.position = Vector3.Lerp (StartPos,EndPos,index);
			index += rate * Time.deltaTime;
			yield return new WaitForSeconds(0.01f);
		}
		DoorBusy=false;
		door.position = EndPos;
	}

	public override bool ApplyAttack(int damage)
	{//TODO:Find out how massive doors resist damage
		objInt.Quality=objInt.Quality-damage;
		if ((objInt.Quality<=0))
		{
			locked=false;
			OpenDoor();
		}
		return true;
	}



	public override bool LookAt()
	{
		if (isPortcullis==false)
		{
			ml.Add(playerUW.StringControl.GetFormattedObjectNameUW(objInt,DoorQuality()));
		}
		else
		{
			ml.Add (playerUW.StringControl.GetFormattedObjectNameUW(objInt));
		}

		return true;
	}



	private string DoorQuality()
	{//TODO:The figures here are based on food quality levels!
		
		if (objInt.Quality == 0)
		{
			return playerUW.StringControl.GetString (5,0);//brken
		}
		if ((objInt.Quality >=1) && (objInt.Quality <15))
		{
			return playerUW.StringControl.GetString (5,1);//badly damaged
		}
		if ((objInt.Quality >=15) && (objInt.Quality <32))
		{
			return playerUW.StringControl.GetString (5,2);//damaged
		}
		if ((objInt.Quality >=32) && (objInt.Quality <=40))
		{
			return playerUW.StringControl.GetString (5,3);//sturdy
		}
		
		if ((objInt.Quality >40) && (objInt.Quality <48))
		{
			return playerUW.StringControl.GetString (5,4);//massive?
		}
		else
		{
			return playerUW.StringControl.GetString (5,5);//massive?
		}
	} 


}
