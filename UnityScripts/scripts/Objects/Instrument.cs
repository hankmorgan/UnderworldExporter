using UnityEngine;
using System.Collections;

public class Instrument : object_base {
	/*Musical instruments*/
	public static bool PlayingInstrument;
	static string CurrentInstrument;
	static string NoteRecord;//Records the last few notes played for a puzzle.
	private AudioSource audio;
	protected override void Start ()
	{
		base.Start ();
		audio=this.GetComponent<AudioSource>();
	}

	public override bool use ()
	{
		if (objInt.PickedUp==true)
		{
			if (playerUW.playerInventory.ObjectInHand=="")
			{
				if (PlayingInstrument==false)
				{
					PlayInstrument();
				}
				return true;
			}
			else
			{
				return ActivateByObject(playerUW.playerInventory.GetGameObjectInHand());
			}
		}
		else
		{
			return false;
		}

	}

	public void PlayInstrument()
	{
		WindowDetectUW.WaitingForInput=true;
		playerUW.playerMotor.enabled=false;
		PlayingInstrument=true;
		CurrentInstrument=this.name;
		playerUW.mus.Stop ();
		NoteRecord="";
		//000~001~250~You play the instrument.  (Use 0-9 to play, or ESC to return to game)
		ml.Set (playerUW.StringControl.GetString (1,250));
	}


	void Update()
	{
		if ((PlayingInstrument == true) && (CurrentInstrument==this.name))
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
				playerUW.playerMotor.enabled=true;
				ml.Add(playerUW.StringControl.GetString (1,251));
				playerUW.mus.Resume();
				//354237875
				if (NoteRecord=="354237875")
				{
					ml.Add ("Eyesnack would be proud of your playing");
				}
				else
				{
					Debug.Log (NoteRecord);
				}
			}
		}
	}

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

		audio.pitch =  Mathf.Pow(2.0f, ((float)note)/12.0f);
		audio.Play();
		//Debug.Log (NoteRecord);
		//NoteRecord[]
	}


}
