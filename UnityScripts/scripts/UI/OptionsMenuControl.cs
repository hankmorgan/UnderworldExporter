using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

//using Polenter.Serialization;

/// <summary>
/// Controls the ingame options menu
/// </summary>
public class OptionsMenuControl : GuiBase_Draggable
{
    string[] saveNames = { "", "", "", "" };
    public GameObject test;

    private const int SAVE = 0;
    private const int SAVE_SLOT_0 = 1;
    private const int SAVE_SLOT_1 = 2;
    private const int SAVE_SLOT_2 = 3;
    private const int SAVE_SLOT_3 = 4;
    private const int SAVE_SLOT_CANCEL = 5;
    private const int RESTORE = 6;
    private const int RESTORE_SLOT_0 = 7;
    private const int RESTORE_SLOT_1 = 8;
    private const int RESTORE_SLOT_2 = 9;
    private const int RESTORE_SLOT_3 = 10;
    private const int RESTORE_SLOT_CANCEL = 11;
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


    public Texture2D[] UW2Imgs;

    public override void Start()
    {
        base.Start();
        InitOptionButtonsArt();
    }

    void InitOptionButtonsArt()
    {
        if (_RES == GAME_UW2)
        {//Setup and crop the UW2 images into a useable format and order
         //Texture2D buttonbgart_80x65 = ArtLoader.CreateBlankImage(80,65);
            Texture2D buttonbgart_80x16 = ArtLoader.CreateBlankImage(80, 16);
            UW2Imgs = new Texture2D[63];
            this.GetComponent<RawImage>().texture = GameWorldController.instance.grOptbtns.LoadImageAt(3);
            UW2Imgs[1] = GameWorldController.instance.grOptbtns.LoadImageAt(3);//main
            UW2Imgs[2] = GameWorldController.instance.grOptbtns.LoadImageAt(6);//save/restore bg
            UW2Imgs[3] = GameWorldController.instance.grOptbtns.LoadImageAt(5);//save
            UW2Imgs[4] = GameWorldController.instance.grOptbtns.LoadImageAt(7);//music/sound bg
            UW2Imgs[5] = GameWorldController.instance.grOptbtns.LoadImageAt(4);//details


            UW2Imgs[6] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(3), buttonbgart_80x16, 0, -98);//save button off
            UW2Imgs[7] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(8), buttonbgart_80x16, 0, -98);//save button on				

            UW2Imgs[8] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(3), buttonbgart_80x16, 0, -82);//restore button off
            UW2Imgs[9] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(8), buttonbgart_80x16, 0, -82);//restore button on

            UW2Imgs[10] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(3), buttonbgart_80x16, 0, -66);//music button off
            UW2Imgs[11] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(8), buttonbgart_80x16, 0, -66);//music button on

            UW2Imgs[12] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(3), buttonbgart_80x16, 0, -50);//sound button off
            UW2Imgs[13] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(8), buttonbgart_80x16, 0, -50);//sound button on

            UW2Imgs[14] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(3), buttonbgart_80x16, 0, -34);//detail button off
            UW2Imgs[15] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(8), buttonbgart_80x16, 0, -34);//detail button on

            UW2Imgs[16] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(3), buttonbgart_80x16, 0, -3);//return button off
            UW2Imgs[17] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(8), buttonbgart_80x16, 0, -3);//return button on

            UW2Imgs[18] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(3), buttonbgart_80x16, 0, -18);//quit button off
            UW2Imgs[19] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(8), buttonbgart_80x16, 0, -18);//quit button on

            UW2Imgs[20] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(7), buttonbgart_80x16, 0, -66);//music on / off
            UW2Imgs[21] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(12), buttonbgart_80x16, 0, -66);//music on / on

            UW2Imgs[22] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(7), buttonbgart_80x16, 0, -50);//music off / off
            UW2Imgs[23] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(12), buttonbgart_80x16, 0, -50);//music off / on

            UW2Imgs[24] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(6), buttonbgart_80x16, 0, -18);//save cancel off
            UW2Imgs[25] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(11), buttonbgart_80x16, 0, -18);//save cancel on

            UW2Imgs[26] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(4), buttonbgart_80x16, 0, -3);//detail cancel off
            UW2Imgs[27] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(9), buttonbgart_80x16, 0, -3);//detail cancel on

            UW2Imgs[28] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(7), buttonbgart_80x16, 0, -34);//music/sound cancel off
            UW2Imgs[29] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(12), buttonbgart_80x16, 0, -34);//music/sound cancel on

            UW2Imgs[30] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(6), buttonbgart_80x16, 0, -82);//save 1 off
            UW2Imgs[31] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(11), buttonbgart_80x16, 0, -82);//save 1 on
            UW2Imgs[32] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(6), buttonbgart_80x16, 0, -66);//save 2 off
            UW2Imgs[33] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(11), buttonbgart_80x16, 0, -66);//save 2 on
            UW2Imgs[34] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(6), buttonbgart_80x16, 0, -50);//save 3 off
            UW2Imgs[35] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(11), buttonbgart_80x16, 0, -50);//save 3 on
            UW2Imgs[36] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(6), buttonbgart_80x16, 0, -34);//save 4 off
            UW2Imgs[37] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(11), buttonbgart_80x16, 0, -34);//save 4 on

            UW2Imgs[38] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(4), buttonbgart_80x16, 0, -66);//detail low off
            UW2Imgs[39] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(9), buttonbgart_80x16, 0, -66);//detail low on

            UW2Imgs[40] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(4), buttonbgart_80x16, 0, -50);//detail med off
            UW2Imgs[41] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(9), buttonbgart_80x16, 0, -50);//detail med on

            UW2Imgs[42] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(4), buttonbgart_80x16, 0, -34);//detail hi off
            UW2Imgs[43] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(9), buttonbgart_80x16, 0, -34);//detail hi on

            UW2Imgs[44] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(4), buttonbgart_80x16, 0, -18);//detail best off
            UW2Imgs[45] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(9), buttonbgart_80x16, 0, -18);//detail best on

            UW2Imgs[46] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(14), buttonbgart_80x16, 0, -33); //Restore state

            UW2Imgs[47] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(15), buttonbgart_80x16, 0, -33);//musicstate on
            UW2Imgs[48] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(15), buttonbgart_80x16, 0, -49);//musicstate off
            UW2Imgs[49] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(15), buttonbgart_80x16, 0, -17);//soundstate off
            UW2Imgs[50] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(15), buttonbgart_80x16, 0, -1);//soundstate on

            UW2Imgs[52] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(14), buttonbgart_80x16, 0, -17);//sound label

            UW2Imgs[53] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(13), buttonbgart_80x16, 0, -49);//detail low
            UW2Imgs[54] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(13), buttonbgart_80x16, 0, -33);//detail med
            UW2Imgs[55] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(13), buttonbgart_80x16, 0, -17);//detail hi
            UW2Imgs[56] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(13), buttonbgart_80x16, 0, -1);//detail best


            UW2Imgs[57] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(5), buttonbgart_80x16, 0, -66);//quit yes off
            UW2Imgs[58] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(10), buttonbgart_80x16, 0, -66);//quit yes on

            UW2Imgs[59] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(5), buttonbgart_80x16, 0, -50);//quit no off 
            UW2Imgs[60] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(10), buttonbgart_80x16, 0, -50);//quit no on


            UW2Imgs[61] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(4), buttonbgart_80x16, 0, -2);//detail cancel off
            UW2Imgs[62] = ArtLoader.InsertImage(GameWorldController.instance.grOptbtns.LoadImageAt(9), buttonbgart_80x16, 0, -2);//detail cancel on

        }
        else
        {
            this.GetComponent<RawImage>().texture = GameWorldController.instance.grOptbtns.LoadImageAt(1);
        }



        SetArt(ref MainBG, 1);
        SetArt(ref SaveBG, 2);
        SetArt(ref RestoreBG, 2);
        SetArt(ref MusicBG, 4);
        SetArt(ref SoundBG, 4);
        SetArt(ref DetailBG, 5);
        SetArt(ref QuitBG, 3);
        SetArt(ref MusicStateOn, 47);
        SetArt(ref MusicStateOff, 48);
        SetArt(ref SoundStateOff, 49);
        SetArt(ref SoundStateOn, 50);
        SetArt(ref DetailStateLow, 53);
        SetArt(ref DetailStateMed, 54);
        SetArt(ref DetailStateHi, 55);
        SetArt(ref DetailStateBest, 56);

        SetArt(Restore_State, 46);
        SetArt(MusicState, 47);//TODO:load the initial value.
        SetArt(SoundState, 49);//TODO:load the initial value.
        SetArt(Sound_Label, 52);
        SetArt(DetailState, 56);//TODO:load the initial value.


    }

    void SetArt(ref Texture2D tex, int artIndex)
    {
        if (_RES != GAME_UW2)
        {
            tex = GameWorldController.instance.grOptbtns.LoadImageAt(artIndex);
        }
        else
        {
            tex = UW2Imgs[artIndex];
        }
    }

    void SetArt(RawImage image, int artIndex)
    {
        if (_RES != GAME_UW2)
        {
            image.texture = GameWorldController.instance.grOptbtns.LoadImageAt(artIndex);
        }
        else
        {
            image.texture = UW2Imgs[artIndex];
        }
    }

    void SetArt(GameObject obj, int artIndex)
    {
        if (_RES != GAME_UW2)
        {
            if (obj.GetComponent<RawImage>() != null)
            {
                obj.GetComponent<RawImage>().texture = GameWorldController.instance.grOptbtns.LoadImageAt(artIndex);
            }
        }
        else
        {
            if (obj.GetComponent<RawImage>() != null)
            {
                obj.GetComponent<RawImage>().texture = UW2Imgs[artIndex];  // GameWorldController.instance.grOptbtns.LoadImageAt(artIndex);
            }
        }
    }

    /// <summary>
    /// Clears the highlighted buttons when the menu is moved on.
    /// </summary>
    void ClearHighlights()
    {
        foreach (Transform child in this.gameObject.transform)
        {
            if (child.GetComponent<OptionsMenuButton>() != null)
            {
                child.GetComponent<OptionsMenuButton>().OnHoverExit();
            }
        }
    }

    public void ButtonClickOptionsMenu(int index)
    {
        ClearHighlights();
        switch (index)
        {
            case SAVE:
                OptionSave(); break;
            case SAVE_SLOT_0:
            case SAVE_SLOT_1:
            case SAVE_SLOT_2:
            case SAVE_SLOT_3:
                SaveToSlot(index - SAVE_SLOT_0);
                break;
            case SAVE_SLOT_CANCEL:
                initMenu(); break;
            case RESTORE:
                OptionRestore(); break;
            case RESTORE_SLOT_0:
            case RESTORE_SLOT_1:
            case RESTORE_SLOT_2:
            case RESTORE_SLOT_3:
                RestoreFromSlot(index - RESTORE_SLOT_0);
                break;
            case RESTORE_SLOT_CANCEL:
                initMenu(); break;
            case MUSIC:
                OptionMusic(); break;
            case MUSIC_ON:
                ToggleMusic(true); break;
            case MUSIC_OFF:
                ToggleMusic(false); break;
            case MUSIC_CANCEL:
                initMenu(); break;
            case SOUND:
                OptionSound(); break;
            case SOUND_ON:
                ToggleSound(true); break;
            case SOUND_OFF:
                ToggleSound(false); break;
            case SOUND_CANCEL:
                initMenu(); break;
            case DETAIL:
                OptionDetail(); break;
            case DETAIL_LOW:
            case DETAIL_MED:
            case DETAIL_HI:
            case DETAIL_BEST:
                SetDetail(index); break;
            case DETAIL_DONE:
                initMenu(); break;
            case RETURN:
                //if(!isLoadingOrSaving)
                //{
                ReturnToGame();
                //}	
                break;
            case QUIT:
                OptionQuit(); break;
            case QUIT_YES:
                OptionQuitYes(); break;
            case QUIT_NO:
                OptionQuitNo(); break;
        }
    }

    public void initMenu()
    {
        Time.timeScale = 0.0f;
        DisplayBG.texture = MainBG;
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
        UWCharacter.InteractionMode = UWCharacter.InteractionModeUse;
        InteractionModeControl.UpdateNow = true;
        UWHUD.instance.EnableDisableControl(UWHUD.instance.InteractionControlUW2BG.gameObject,false);
        this.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    private void OptionSave()
    {
        DisplayBG.texture = SaveBG;
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

        DisplaySaves();
    }

    private void OptionRestore()
    {
        DisplayBG.texture = RestoreBG;
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

        DisplaySaves();
    }

    void DisplaySaves()
    {

        //List the save names
        UWHUD.instance.MessageScroll.Clear();

        for (int i = 1; i <= 4; i++)
        {
            char[] fileDesc;
            if (DataLoader.ReadStreamFile(Loader.BasePath + "SAVE" + i + sep + "DESC", out fileDesc))
            {
                saveNames[i - 1] = new string(fileDesc);
            }
            else
            {
                saveNames[i - 1] = "";
            }
        }
        for (int i = 0; i <= saveNames.GetUpperBound(0); i++)
        {
            if (saveNames[i] != "")
            {
                UWHUD.instance.MessageScroll.Add((i + 1) + " " + saveNames[i]);
            }
            else
            {
                UWHUD.instance.MessageScroll.Add((i + 1) + " No Save Data");
            }
        }
    }

    private void OptionMusic()
    {
        DisplayBG.texture = MusicBG;
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
        DisplayBG.texture = SoundBG;
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
        DisplayBG.texture = DetailBG;
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
        DisplayBG.texture = QuitBG;
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
        //if (_RES==GAME_UW2)
        //{
        //		UWHUD.instance.MessageScroll.Add("Saving only supported in UW1");
        //		return;
        //}

        //000~001~159~Impossible, you are between worlds. \n
        if ((_RES == GAME_UW1) && (GameWorldController.instance.LevelNo == 8))
        {
            UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, StringController.str_impossible_you_are_between_worlds_));
            return;
        }
        if (!Directory.Exists(Loader.BasePath + "SAVE" + (SlotNo + 1)))
        {
            Directory.CreateDirectory(Loader.BasePath + "SAVE" + (SlotNo + 1));
        }


        //Write a player.dat file
        if (_RES == GAME_UW2)
        {
            //Write lev.ark file and object lists
            LevArk.WriteBackLevArkUW2(SlotNo + 1);
            //Write bglobals.dat
            GameWorldController.instance.WriteBGlobals(SlotNo + 1);
            //Write a desc file
            File.WriteAllText(Loader.BasePath + "SAVE" + (SlotNo + 1) + sep + "DESC", SaveGame.SaveGameName(SlotNo + 1));
            //Write player.dat
            SaveGame.WritePlayerDatUW2(SlotNo + 1);
            //TODO:Write scd.ark
        }
        else
        {
            //Write lev.ark file and object lists
            LevArk.WriteBackLevArkUW1(SlotNo + 1);
            //Write bglobals.dat
            GameWorldController.instance.WriteBGlobals(SlotNo + 1);
            //Write a desc file
            File.WriteAllText(Loader.BasePath + "SAVE" + (SlotNo + 1) + sep + "DESC", SaveGame.SaveGameName(SlotNo + 1));
            //Write player.dat
            SaveGame.WritePlayerDatUW1(SlotNo + 1);
            //	SaveGame.WritePlayerDatOriginal(SlotNo+1);	
        }

        UWHUD.instance.MessageScroll.Set(StringController.instance.GetString(1, StringController.str_save_game_succeeded_));
        UWHUD.instance.RefreshPanels(UWHUD.HUD_MODE_INVENTORY);
        ReturnToGame();

    }


    /// <summary>
    /// Restores save game from slot.
    /// </summary>
    /// <param name="SlotNo">Slot no.</param>
    private void RestoreFromSlot(int SlotNo)
    {
        if (saveNames[SlotNo] != "")
        {
            //Load a save file
            //Set the level file
            GameWorldController.LoadingGame = true;
            GameWorldController.instance.LevelNo = -1;
            GameWorldController.instance.AtMainMenu = true;
            GameWorldController.instance.Lev_Ark_File_Selected = "SAVE" + (SlotNo + 1) + sep + "LEV.ARK";
            GameWorldController.instance.SCD_Ark_File_Selected = "SAVE" + (SlotNo + 1) + sep + "SCD.ARK";
            //Read in the character data
            //SaveGame.LoadPlayerDat(SlotNo+1);

            if (_RES != GAME_UW2)
            {
                //Read in the character data
                SaveGame.LoadPlayerDatUW1(SlotNo + 1);
            }
            else
            {
                SaveGame.LoadPlayerDatUW2(SlotNo + 1);
            }
            //Load up the map
            GameWorldController.instance.SwitchLevel(GameWorldController.instance.startLevel);
            GameWorldController.instance.InitBGlobals(SlotNo + 1);
            UWCharacter.Instance.transform.position = GameWorldController.instance.StartPos;
            UWHUD.instance.gameObject.SetActive(true);
            UWCharacter.Instance.playerController.enabled = true;
            UWCharacter.Instance.playerMotor.enabled = true;
            UWCharacter.Instance.playerMotor.movement.velocity = Vector3.zero;
            GameWorldController.instance.AtMainMenu = false;
            UWCharacter.Instance.playerInventory.Refresh();
            UWCharacter.Instance.playerInventory.UpdateLightSources();
            UWHUD.instance.RefreshPanels(UWHUD.HUD_MODE_INVENTORY);
            //000~001~162~Restore Game Complete. \n
            UWHUD.instance.MessageScroll.Set(StringController.instance.GetString(1, StringController.str_restore_game_complete_));
            GameWorldController.LoadingGame = false;
            ReturnToGame();

        }
    }

    /// <summary>
    /// Toggles the music.
    /// </summary>
    /// <param name="state">If set to <c>true</c> state.</param>
    private void ToggleMusic(bool state)
    {
        if (state == true)
        {
            MusicState.texture = MusicStateOn;
            MusicController.instance.ResumeAll();
        }
        else
        {
            MusicState.texture = MusicStateOff;
            MusicController.instance.StopAll();
        }
        MusicController.PlayMusic = state;
    }

    /// <summary>
    /// Toggles the sound.
    /// </summary>
    /// <param name="state">If set to <c>true</c> state.</param>
    private void ToggleSound(bool state)
    {
        if (state == true)
        {
            SoundState.texture = SoundStateOn;
        }
        else
        {
            SoundState.texture = SoundStateOff;
        }
        ObjectInteraction.PlaySoundEffects = state;
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
                DetailState.texture = DetailStateLow;
                QualitySettings.SetQualityLevel(0, true); break;
            case DETAIL_MED:
                DetailState.texture = DetailStateMed;
                QualitySettings.SetQualityLevel(1, true); break;
            case DETAIL_HI:
                DetailState.texture = DetailStateHi;
                QualitySettings.SetQualityLevel(2, true); break;
            case DETAIL_BEST:
                DetailState.texture = DetailStateBest;
                QualitySettings.SetQualityLevel(3, true); break;
        }
    }
}