using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

//using Polenter.Serialization;

/// <summary>
/// Controls the ingame options menu
/// </summary>
public class OptionsMenuControl : GuiBase_Draggable {
		string[] saveNames= {"","","",""};
		public GameObject test;

		private const int SAVE = 0;
		private const int SAVE_SLOT_0=1;
		private const int SAVE_SLOT_1=2;
		private const int SAVE_SLOT_2=3;
		private const int SAVE_SLOT_3=4;
		private const int SAVE_SLOT_CANCEL=5;
		private const int RESTORE = 6;
		private const int RESTORE_SLOT_0=7;
		private const int RESTORE_SLOT_1=8;
		private const int RESTORE_SLOT_2=9;
		private const int RESTORE_SLOT_3=10;
		private const int RESTORE_SLOT_CANCEL=11;
		private const int MUSIC = 12;
		private const int MUSIC_ON = 13;
		private const int MUSIC_OFF = 14;
		private const int MUSIC_CANCEL = 15;
		private const int SOUND = 16;
		private const int SOUND_ON = 17;
		private const int SOUND_OFF = 18;
		private const int SOUND_CANCEL = 19;
		private const int DETAIL = 20;
		private const int DETAIL_LOW = 21;
		private const int DETAIL_MED = 22;
		private const int DETAIL_HI = 23;
		private const int DETAIL_BEST = 24;
		private const int DETAIL_DONE = 25;
		private const int RETURN = 26;
		private const int QUIT = 27;
		private const int QUIT_YES = 28;
		private const int QUIT_NO = 29;

		public InteractionModeControl InteractionMenu;

		public RawImage DisplayBG;

		public Texture2D MainBG;
		public Texture2D SaveBG;
		public Texture2D RestoreBG;
		public Texture2D MusicBG;
		public Texture2D SoundBG;
		public Texture2D DetailBG;
		public Texture2D QuitBG;
		public Texture2D MusicStateOn;
		public Texture2D MusicStateOff;
		public RawImage MusicState;
		public Texture2D SoundStateOn;
		public Texture2D SoundStateOff;
		public RawImage SoundState;
		public Texture2D DetailStateLow;
		public Texture2D DetailStateMed;
		public Texture2D DetailStateHi;
		public Texture2D DetailStateBest;
		public RawImage DetailState;

		public GameObject SaveMenu;
		public GameObject SaveSlot_0;
		public GameObject SaveSlot_1;
		public GameObject SaveSlot_2;
		public GameObject SaveSlot_3;
		public GameObject Save_Cancel;
		public GameObject RestoreMenu;
		public GameObject RestoreSlot_0;
		public GameObject RestoreSlot_1;
		public GameObject RestoreSlot_2;
		public GameObject RestoreSlot_3;
		public GameObject Restore_Cancel;
		public GameObject Restore_State;
		public GameObject MusicMenu;
		public GameObject MusicOn;
		public GameObject MusicOff;
		public GameObject Music_Cancel;
		public GameObject SoundMenu;
		public GameObject SoundOn;
		public GameObject SoundOff;
		public GameObject Sound_Cancel;
		public GameObject Sound_Label;
		public GameObject DetailMenu;
		public GameObject DetailLow;
		public GameObject DetailMed;
		public GameObject DetailHi;
		public GameObject DetailBest;
		public GameObject Detail_Cancel;
	
		public GameObject ReturnMenu;

		public GameObject QuitMenu;
		public GameObject QuitYes;
		public GameObject QuitNo;

		//private bool SaveNow;
		//private bool RestoreNow;
		//private int slot;
		//private bool isLoadingOrSaving;

	public void ButtonClickOptionsMenu(int index)
	{
		switch (index)
		{
		case SAVE:
			OptionSave();break;
		case SAVE_SLOT_0:
		case SAVE_SLOT_1:
		case SAVE_SLOT_2:
		case SAVE_SLOT_3:
			SaveToSlot(index-SAVE_SLOT_0);
			break;
		case SAVE_SLOT_CANCEL:
				initMenu();break;
		case RESTORE:
			OptionRestore();break;
		case RESTORE_SLOT_0:
		case RESTORE_SLOT_1:
		case RESTORE_SLOT_2:
		case RESTORE_SLOT_3:
			RestoreFromSlot(index- RESTORE_SLOT_0);
			break;
		case RESTORE_SLOT_CANCEL:
			initMenu();break;	
		case MUSIC:
			OptionMusic();break;
		case MUSIC_ON:
			ToggleMusic(true);break;
		case MUSIC_OFF:
			ToggleMusic(false);break;
		case MUSIC_CANCEL:
			initMenu();break;						
		case SOUND:
			OptionSound();break;
		case SOUND_ON:
			ToggleSound(true);break;
		case SOUND_OFF:
			ToggleSound(false);break;
		case SOUND_CANCEL:
			initMenu();break;	
		case DETAIL:
			OptionDetail();break;
		case DETAIL_LOW:
		case DETAIL_MED:
		case DETAIL_HI:
		case DETAIL_BEST:
			SetDetail(index);break;
		case DETAIL_DONE:
			initMenu();break;	
		case RETURN:
			//if(!isLoadingOrSaving)
			//{
				ReturnToGame();	
			//}	
			break;
		case QUIT:
			OptionQuit();break;
		case QUIT_YES:
			OptionQuitYes();break;
		case QUIT_NO:
			OptionQuitNo();break;
		}
	}

	public void initMenu()
	{
		Time.timeScale=0.0f;
		DisplayBG.texture= MainBG;
		SaveMenu.SetActive(true);
		RestoreMenu.SetActive(true);
		DetailMenu.SetActive(true);
		SoundMenu.SetActive(true);
		MusicMenu.SetActive(true);		
		ReturnMenu.SetActive(true);
		QuitMenu.SetActive(true);
		SaveSlot_0.SetActive(false);
		SaveSlot_1.SetActive(false);
		SaveSlot_2.SetActive(false);
		SaveSlot_3.SetActive(false);
		Save_Cancel.SetActive(false);
		RestoreSlot_0.SetActive(false);
		RestoreSlot_1.SetActive(false);
		RestoreSlot_2.SetActive(false);
		RestoreSlot_3.SetActive(false);
		Restore_Cancel.SetActive(false);
		Restore_State.SetActive(false);
		MusicState.gameObject.SetActive(false);
		MusicOff.SetActive(false);
		MusicOn.SetActive(false);
		Music_Cancel.SetActive(false);
		SoundState.gameObject.SetActive(false);
		SoundOff.SetActive(false);
		SoundOn.SetActive(false);
		Sound_Cancel.SetActive(false);
		Sound_Label.SetActive(false);
		DetailState.gameObject.SetActive(false);
		DetailLow.SetActive(false);
		DetailMed.SetActive(false);
		DetailHi.SetActive(false);
		DetailBest.SetActive(false);
		Detail_Cancel.SetActive(false);
		QuitYes.SetActive(false);
		QuitNo.SetActive(false);
	}


	private void ReturnToGame()
	{
		InteractionMenu.gameObject.SetActive(true);
		UWCharacter.InteractionMode=UWCharacter.InteractionModeUse;
		InteractionModeControl.UpdateNow=true;
		this.gameObject.SetActive(false);	
		Time.timeScale=1.0f;
	}

	private void OptionSave()
	{
		if (_RES==GAME_UW1)
		{
			DisplayBG.texture= SaveBG;
			SaveMenu.SetActive(false);
			RestoreMenu.SetActive(false);
			DetailMenu.SetActive(false);
			SoundMenu.SetActive(false);
			MusicMenu.SetActive(false);		
			ReturnMenu.SetActive(false);
			QuitMenu.SetActive(false);
			SaveSlot_0.SetActive(true);
			SaveSlot_1.SetActive(true);
			SaveSlot_2.SetActive(true);
			SaveSlot_3.SetActive(true);
			Save_Cancel.SetActive(true);

			DisplaySaves ();	
		}
		else
		{
			UWHUD.instance.MessageScroll.Add("Saving only supported in UW1");
		}

	}

	private void OptionRestore()
	{
		DisplayBG.texture= RestoreBG;
		SaveMenu.SetActive(false);
		RestoreMenu.SetActive(false);
		DetailMenu.SetActive(false);
		SoundMenu.SetActive(false);
		MusicMenu.SetActive(false);		
		ReturnMenu.SetActive(false);
		QuitMenu.SetActive(false);
		RestoreSlot_0.SetActive(true);
		RestoreSlot_1.SetActive(true);
		RestoreSlot_2.SetActive(true);
		RestoreSlot_3.SetActive(true);
		Restore_Cancel.SetActive(true);
		Restore_State.SetActive(true);

		DisplaySaves ();
	}

	void DisplaySaves ()
	{

		//List the save names
		UWHUD.instance.MessageScroll.Clear ();
	
			for (int i=1; i<=4;i++)
			{
				char[] fileDesc;
				if (DataLoader.ReadStreamFile(Loader.BasePath + "save" + i + "\\desc", out fileDesc))
				{
					saveNames[i-1]= new string(fileDesc);
				}
				else
				{
					saveNames[i-1]="";
				}
			}
		for (int i=0; i<=saveNames.GetUpperBound(0);i++)
		{
			if (saveNames[i]!="")
			{
				UWHUD.instance.MessageScroll.Add ((i+1) + " " + saveNames[i]);
			}
			else
			{
				UWHUD.instance.MessageScroll.Add ((i+1) + " No Save Data");	
			}
		}
	}

	private void OptionMusic()
	{
		DisplayBG.texture= MusicBG;
		SaveMenu.SetActive(false);
		RestoreMenu.SetActive(false);
		DetailMenu.SetActive(false);
		SoundMenu.SetActive(false);
		MusicMenu.SetActive(false);		
		ReturnMenu.SetActive(false);
		QuitMenu.SetActive(false);	
		MusicState.gameObject.SetActive(true);
		MusicOff.SetActive(true);
		MusicOn.SetActive(true);
		Music_Cancel.SetActive(true);
	}

	private void OptionSound()
	{
		DisplayBG.texture= SoundBG;
		SaveMenu.SetActive(false);
		RestoreMenu.SetActive(false);
		DetailMenu.SetActive(false);
		SoundMenu.SetActive(false);
		MusicMenu.SetActive(false);		
		ReturnMenu.SetActive(false);
		QuitMenu.SetActive(false);	
		SoundState.gameObject.SetActive(true);
		SoundOff.SetActive(true);
		SoundOn.SetActive(true);
		Sound_Cancel.SetActive(true);
		Sound_Label.SetActive(true);
	}

	private void OptionDetail()
	{
		DisplayBG.texture= DetailBG;
		SaveMenu.SetActive(false);
		RestoreMenu.SetActive(false);
		DetailMenu.SetActive(false);
		SoundMenu.SetActive(false);
		MusicMenu.SetActive(false);		
		ReturnMenu.SetActive(false);
		QuitMenu.SetActive(false);
		DetailState.gameObject.SetActive(true);
		DetailLow.SetActive(true);
		DetailMed.SetActive(true);
		DetailHi.SetActive(true);
		DetailBest.SetActive(true);
		Detail_Cancel.SetActive(true);
	}


	private void OptionQuit()
	{
		DisplayBG.texture=QuitBG;
		SaveMenu.SetActive(false);
		RestoreMenu.SetActive(false);
		DetailMenu.SetActive(false);
		SoundMenu.SetActive(false);
		MusicMenu.SetActive(false);		
		ReturnMenu.SetActive(false);
		QuitMenu.SetActive(false);
		QuitYes.SetActive(true);
		QuitNo.SetActive(true);
	}

	/// <summary>
	/// Confirms quitting.
	/// </summary>
	private void OptionQuitYes()
	{
		Application.Quit();
	}

	/// <summary>
	/// Cancels Quit
	/// </summary>
	private void OptionQuitNo()
	{
		ReturnToGame();
	}

		/// <summary>
		/// Saves to slot.
		/// </summary>
		/// <param name="SlotNo">Slot no.</param>
		private void SaveToSlot(int SlotNo)
		{
			//000~001~159~Impossible, you are between worlds. \n
			if ((_RES==GAME_UW1) && (GameWorldController.instance.LevelNo==8))
			{
				UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1,159));
				return;
			}
			//Write lev.ark file and object lists
			GameWorldController.instance.WriteBackLevArk(SlotNo+1);

			//Write bglobals.dat
			GameWorldController.instance.WriteBGlobals(SlotNo+1);

			//Write a desc file
			//File.WriteAllText(Loader.BasePath +  "save" + (SlotNo+1) + "\\desc" , "save"+SlotNo);
			File.WriteAllText(Loader.BasePath +  "save" + (SlotNo+1) + "\\desc" , SaveGame.SaveGameName(SlotNo+1));
			//Write a player.dat file
			SaveGame.WritePlayerDat(SlotNo+1);


			UWHUD.instance.RefreshPanels(UWHUD.HUD_MODE_INVENTORY);
			ReturnToGame();

		}


		/// <summary>
		/// Restores save game from slot.
		/// </summary>
		/// <param name="SlotNo">Slot no.</param>
	private void RestoreFromSlot(int SlotNo)
	{
		if (saveNames[SlotNo]!="")
		{
			//Load a save file
			//Set the level file
			GameWorldController.instance.LevelNo=-1;
			GameWorldController.instance.AtMainMenu=true;
			GameWorldController.instance.Lev_Ark_File_Selected="Save"+(SlotNo+1) + "\\Lev.Ark";
			//Read in the character data
			//SaveGame.LoadPlayerDat(SlotNo+1);

			if (_RES!=GAME_UW2)
			{
				//Read in the character data
				SaveGame.LoadPlayerDat(SlotNo+1);
			}
			else
			{
					SaveGame.LoadPlayerDatUW2(SlotNo+1);	
			}
			//Load up the map
			GameWorldController.instance.SwitchLevel(GameWorldController.instance.startLevel);
			GameWorldController.instance.InitBGlobals(SlotNo+1);
			GameWorldController.instance.playerUW.transform.position= GameWorldController.instance.StartPos;
			UWHUD.instance.gameObject.SetActive(true);
			GameWorldController.instance.playerUW.playerController.enabled=true;
			GameWorldController.instance.playerUW.playerMotor.enabled=true;
			GameWorldController.instance.AtMainMenu=false;
			GameWorldController.instance.playerUW.playerInventory.Refresh();
			GameWorldController.instance.playerUW.playerInventory.UpdateLightSources();
			UWHUD.instance.RefreshPanels(UWHUD.HUD_MODE_INVENTORY);
			//000~001~162~Restore Game Complete. \n
			UWHUD.instance.MessageScroll.Set(StringController.instance.GetString(1,162));
			ReturnToGame();
		}
	}

	/// <summary>
	/// Toggles the music.
	/// </summary>
	/// <param name="state">If set to <c>true</c> state.</param>
	private void ToggleMusic(bool state)
	{
		if (state==true)
		{
			MusicState.texture=MusicStateOn;
			GameWorldController.instance.getMus().ResumeAll();
		}
		else
		{
			MusicState.texture=MusicStateOff;	
			GameWorldController.instance.getMus().StopAll();
		}
	}

	/// <summary>
	/// Toggles the sound.
	/// </summary>
	/// <param name="state">If set to <c>true</c> state.</param>
	private void ToggleSound(bool state)
	{
		if (state==true)
		{
			ObjectInteraction.PlaySoundEffects=true;
			SoundState.texture=SoundStateOn;
		}
		else
		{
			ObjectInteraction.PlaySoundEffects=false;
			SoundState.texture=SoundStateOff;	
		}
	}

	/// <summary>
	/// Sets the detail level
	/// </summary>
	/// <param name="DetailLevel">Detail level.</param>
	public void SetDetail(int DetailLevel)
	{
		switch (DetailLevel)
		{
		case DETAIL_LOW:
			QualitySettings.SetQualityLevel(0,true);break;
		case DETAIL_MED:
			QualitySettings.SetQualityLevel(1,true);break;
		case DETAIL_HI:
			QualitySettings.SetQualityLevel(2,true);break;
		case DETAIL_BEST:
			QualitySettings.SetQualityLevel(3,true);break;
		}
	}

		/*
		static void HandleLevelSerializerProgress (string section, float complete)
		{
				Debug.Log(string.Format("Progress on {0} = {1:0.00%}", section, complete));
		}

		private void OnEnable() {
				LevelSerializer.Progress += HandleLevelSerializerProgress;
		}

		private void OnDisable() {
				LevelSerializer.Progress -= HandleLevelSerializerProgress;
		}
*/
		/*
		IEnumerator LoadScreen (bool mode)
		{
				
			//while (isLoadingOrSaving)
			//{
				if (mode==true)//Loading
				{
					UWHUD.instance.LoadingProgress.text="LOADING";
				}
				else
				{
					UWHUD.instance.LoadingProgress.text="SAVING" ;
				}
				yield return new WaitForSeconds(1);
			//}
		}*/
	
}

