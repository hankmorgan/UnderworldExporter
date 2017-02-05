using UnityEngine;
using System.Collections;
/// <summary>
/// Musical instruments
/// </summary>
/// Tracks the notes the player plays to detect the cup of wonder tune.
public class Instrument : object_base {
		/// Is the player currently playing an instrument		
	public static bool PlayingInstrument;
		/// What instrument is currently being played
	static string CurrentInstrument;
		/// Records the last few notes played for a puzzle.
	static string NoteRecord;

	public static bool CreatedCup;

	protected override void Start ()
	{
		base.Start ();
	}

	public override bool use ()
	{
		if (objInt().PickedUp==true)
		{
			if (GameWorldController.instance.playerUW.playerInventory.ObjectInHand=="")
			{
				if (PlayingInstrument==false)
				{
					PlayInstrument();
				}
				return true;
			}
			else
			{
				return ActivateByObject(GameWorldController.instance.playerUW.playerInventory.GetGameObjectInHand());
			}
		}
		else
		{
			return false;
		}

	}

		/// <summary>
		/// Sets the instrucment play UI and state.
		/// </summary>
	public void PlayInstrument()
	{
		WindowDetectUW.WaitingForInput=true;
		GameWorldController.instance.playerUW.playerMotor.enabled=false;
		PlayingInstrument=true;
		CurrentInstrument=this.name;
		GameWorldController.instance.getMus().Stop ();
		NoteRecord="";
		//000~001~250~You play the instrument.  (Use 0-9 to play, or ESC to return to game)
		UWHUD.instance.MessageScroll.Set (StringController.instance.GetString (1,250));
	}

	private void MusicInstrumentInteaction()
	{
		if (Input.GetKeyDown("1"))
		{PlayNote (1);}
		if (Input.GetKeyDown("2"))
		{PlayNote (2);}
		if (Input.GetKeyDown("3"))
		{PlayNote (3);}
		if (Input.GetKeyDown("4"))
		{PlayNote (4);}
		if (Input.GetKeyDown("5"))
		{PlayNote (5);}
		if (Input.GetKeyDown("6"))
		{PlayNote (6);}
		if (Input.GetKeyDown("7"))
		{PlayNote (7);}
		if (Input.GetKeyDown("8"))
		{PlayNote (8);}
		if (Input.GetKeyDown("9"))
		{PlayNote (9);}
		if (Input.GetKeyDown("0"))
		{PlayNote (10);}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			//000~001~251~You put the instrument down.
			PlayingInstrument=false;
			CurrentInstrument="";
			WindowDetectUW.WaitingForInput=false;
			GameWorldController.instance.playerUW.playerMotor.enabled=true;
			UWHUD.instance.MessageScroll.Add(StringController.instance.GetString (1,251));
			GameWorldController.instance.getMus().Resume();
			//354237875
			if ((NoteRecord=="354237875") && (objInt().item_id==292))//Flute only
			{
				//UWHUD.instance.MessageScroll.Add ("Eyesnack would be proud of your playing");
				if ((GameWorldController.instance.LevelNo==2) && (CreatedCup==false) && (objInt().item_id==292))
				{									
					int tileX=TileMap.visitTileX;
					int tileY=TileMap.visitTileY;
					if (((tileX >=23) || (tileX<=27)) && ((tileY >=43) || (tileY<=45)))
					{							
						//create the cup of wonder.
						ObjectInteraction myObjInt = ObjectInteraction.CreateNewObject(174);
						myObjInt.gameObject.transform.parent=GameWorldController.instance.InventoryMarker.transform;
						GameWorldController.MoveToInventory(myObjInt.gameObject);
						GameWorldController.instance.playerUW.playerInventory.ObjectInHand=myObjInt.name;
						UWHUD.instance.CursorIcon=myObjInt.GetInventoryDisplay().texture ;
						UWCharacter.InteractionMode=UWCharacter.InteractionModePickup;
						InteractionModeControl.UpdateNow=true;
						CreatedCup=true;
						//An object appears in the air and falls into your hands
						UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1,136));

					}
				}
			}
		}		
	}

		/// <summary>
		/// Plays the notes to match the keys pressed
		/// </summary>
	void Update()
	{
		if ((PlayingInstrument == true) && (CurrentInstrument==this.name))
		{
			MusicInstrumentInteaction();			
		}
	}

		/// <summary>
		/// Plays a musical note by adjusting the pitch of a note.
		/// </summary>
		/// <param name="note">Note to play</param>
	void PlayNote(int note)
	{
	//	Debug.Log (noteNo);
		if (note==10)
		{
			NoteRecord=NoteRecord+"0";
		}
		else
		{
			NoteRecord=NoteRecord+note.ToString();
		}

		if (NoteRecord.Length>9)
		{
			NoteRecord=NoteRecord.Remove(0,1);
		}
		//From
		//http://answers.unity3d.com/questions/141771/whats-a-good-way-to-do-dynamically-generated-music.html

				GameWorldController.instance.getMus().MusicalInstruments.pitch=Mathf.Pow(2.0f, ((float)note)/12.0f);
				GameWorldController.instance.getMus().MusicalInstruments.Play();
				//this.GetComponent<AudioSource>().pitch =  Mathf.Pow(2.0f, ((float)note)/12.0f);
		//this.GetComponent<AudioSource>().Play();
	}


		public  override string UseVerb()
		{
				return "play";
		}
}
