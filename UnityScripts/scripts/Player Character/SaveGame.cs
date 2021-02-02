using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class SaveGame : Loader
{     
    public enum InventorySlotsOffsets
    {
        UW1Helm = 248,
        UW1Chest = 250,
        UW1Gloves = 252,
        UW1Leggings = 254,
        UW1Boots = 256,
        UW1RightShoulder = 258,
        UW1LeftShoulder = 260,
        UW1RightHand = 262,
        UW1LeftHand = 264,
        UW1RightRing = 266,
        UW1LeftRing = 268,
        UW1Backpack0 = 270,
        UW1Backpack1 = 272,
        UW1Backpack2 = 274,
        UW1Backpack3 = 276,
        UW1Backpack4 = 278,
        UW1Backpack5 = 280,
        UW1Backpack6 = 282,
        UW1Backpack7 = 284,

        UW2Helm = 931,
        UW2Chest = 933,
        UW2Gloves = 935,
        UW2Leggings = 937,
        UW2Boots = 939,
        UW2RightShoulder = 941,
        UW2LeftShoulder = 943,
        UW2RightHand = 945,
        UW2LeftHand = 947,
        UW2RightRing = 949,
        UW2LeftRing = 951,
        UW2Backpack0 = 953,
        UW2Backpack1 = 955,
        UW2Backpack2 = 957,
        UW2Backpack3 = 959,
        UW2Backpack4 = 961,
        UW2Backpack5 = 963,
        UW2Backpack6 = 965,
        UW2Backpack7 = 967

    };

    /// <summary>
    /// Array for storing inventory data.
    /// </summary>
   // public static char[] InventoryData = new char[768 * 8];  //Not sure if this is valid but is the same as the world object static list length

    
    /// <summary>
    /// Ratio of UNITY co-ordinates to Tile co-ordinates
    /// </summary>
    private const float Ratio = 213f;

    //Adjustment of players vertial postion in Unity to UW co-ordinates
    private const float VertAdjust = 0.3543672f;

    private const int NoOfEncryptedBytes = 0xD2;//218;		//219

    /// <summary>
    /// Loads the player dat file into the current character
    /// </summary>
    /// <param name="slotNo">Slot no.</param>
    public static void LoadPlayerDatUW1(int slotNo)
    {
        char[] buffer;//File data

        int[] ActiveEffectIds = new int[3]; //array of spell effects currently applied to the player.
        short[] ActiveEffectStability = new short[3];
        int effectCounter = 0;

        ResetUI();

        if (DataLoader.ReadStreamFile(Loader.BasePath + "SAVE" + slotNo + sep + "PLAYER.DAT", out buffer))
        {
            int xOrValue = (int)buffer[0];
            UWCharacter.Instance.XorKey = xOrValue;
            int incrnum = 3;

            for (int i = 1; i <= NoOfEncryptedBytes; i++)
            {
                if ((i == 81) | (i == 161))
                {
                    incrnum = 3;
                }
                buffer[i] ^= (char)((xOrValue + incrnum) & 0xFF);

                incrnum += 3;
            }

            //Load some common items for uw1/2
            LoadName(buffer);
            LoadStats(buffer);
            effectCounter = LoadSpellEffects(buffer, ref ActiveEffectIds, ref ActiveEffectStability);
            LoadRunes(buffer);
            LoadPlayerClass(buffer, 0x65);
            LoadGameOptions(buffer, 0xB6);

            for (int i = 0x4B; i <= 221; i++)
            {
                switch (i)//UWformats doesn't take the first byte into account when describing offsets! I have incremented plus one
                {
                    case 0x4B://No of items. used here just to initialise a value.
                              //UWCharacter.Instance.playerInventory.ItemCounter= (int)buffer[i]>>2;
                        break;
                    case 0x4D: ///   weight in 0.1 stones
                        //Or STR * 2; safe to ignore?
                        break;
                    case 0x4F: ///   experience in 0.1 points
                        UWCharacter.Instance.EXP = (int)DataLoader.getValAtAddress(buffer, i, 32); break;
                    case 0x53: // skillpoints available to spend
                        UWCharacter.Instance.TrainingPoints = (int)buffer[i]; break;
                    case 0x55:
                        LoadPosition(buffer); break;
                    case 0x5F:///High nibble is dungeon level+1 with the silver tree if planted
                        //Low nibble is moongate level + 1
                        UWCharacter.Instance.ResurrectLevel = (short)((buffer[i] >> 4) & 0xf);
                        UWCharacter.Instance.MoonGateLevel = (short)((buffer[i]) & 0xf);
                        break;
                    case 0x60: ///    bits 2..5: play_poison and no of active effects
                        Quest.instance.IncenseDream = (int)(buffer[i] & 0x3);
                        UWCharacter.Instance.play_poison = (short)((buffer[i] >> 2) & 0xf);
                        UWCharacter.Instance.poison_timer = 30f;
                        effectCounter = ((int)buffer[i] >> 6) & 0x3;
                        break;
                    case 0x61:
                        {
                            Quest.instance.isOrbDestroyed = ((((int)DataLoader.getValAtAddress(buffer, i, 8) >> 5) & 0x1) == 1);
                            Quest.instance.isCupFound = ((((int)DataLoader.getValAtAddress(buffer, i, 8) >> 6) & 0x1) == 1);
                            break;
                        }
                    case 0x62://intoxication and is garamon buried.
                        {
                            int val = ((int)DataLoader.getValAtAddress(buffer, i, 16));
                            UWCharacter.Instance.Intoxication = (val >> 4) & 0x3f;
                            Quest.instance.isGaramonBuried = ((val >> 10) & 0x3) == 3;
                            break;
                        }
                    //case 0x63:
                    //    {
                    //      //  Quest.instance.isGaramonBuried = ((buffer[i] >> 2) & 0x3) == 3 ; break;
                    //    }

                    case 0x65: // hand, Gender & body, and class
                        break;
                    case 0x66://Quest flags
                        {
                            int val = (int)DataLoader.getValAtAddress(buffer, i, 32);
                            for (int b = 0; b <= 31; b++)
                            {//Check order here
                                if (((val >> (b)) & 0x1) == 1)
                                {
                                    Quest.instance.QuestVariables[b] = 1;
                                }
                                else
                                {
                                    Quest.instance.QuestVariables[b] = 0;
                                }
                            }
                            break;
                        }
                    case 0x6A:
                        Quest.instance.QuestVariables[32] = (int)DataLoader.getValAtAddress(buffer, i, 8); break;
                    case 0x6B:
                        Quest.instance.QuestVariables[33] = (int)DataLoader.getValAtAddress(buffer, i, 8); break;
                    case 0x6C:
                        Quest.instance.QuestVariables[34] = (int)DataLoader.getValAtAddress(buffer, i, 8); break;
                    case 0x6D:
                        Quest.instance.QuestVariables[35] = (int)DataLoader.getValAtAddress(buffer, i, 8); break;

                    case 0x6E://No of talismans still to destory
                        Quest.instance.TalismansRemaining = (int)DataLoader.getValAtAddress(buffer, i, 8); break;

                    case 0x6F://Garamon dream related?
                        Quest.instance.GaramonDream = (int)DataLoader.getValAtAddress(buffer, i, 8); break;
                    case 0x71://Game variables
                    case 0x72:
                    case 0x73:
                    case 0x74:
                    case 0x75:
                    case 0x76:
                    case 0x77:
                    case 0x78:
                    case 0x79:
                    case 0x7A:
                    case 0x7B:
                    case 0x7C:
                    case 0x7D:
                    case 0x7E:
                    case 0x7F:
                    case 0x80:
                    case 0x81:
                    case 0x82:
                    case 0x83:
                    case 0x84:
                    case 0x85:
                    case 0x86:
                    case 0x87:
                    case 0x88:
                    case 0x89:
                    case 0x8A:
                    case 0x8B:
                    case 0x8C:
                    case 0x8D:
                    case 0x8E:
                    case 0x8F:
                    case 0x90:
                    case 0x91:
                    case 0x92:
                    case 0x93:
                    case 0x94:
                    case 0x95:
                    case 0x96:
                    case 0x97:
                    case 0x98:
                    case 0x99:
                    case 0x9A:
                    case 0x9B:
                    case 0x9C:
                    case 0x9D:
                    case 0x9E:
                    case 0x9F:
                    case 0xA0:
                    case 0xA1:
                    case 0xA2:
                    case 0xA3:
                    case 0xA4:
                    case 0xA5:
                    case 0xA6:
                    case 0xA7:
                    case 0xA8:
                    case 0xA9:
                    case 0xAA:
                    case 0xAB:
                    case 0xAC:
                    case 0xAD:
                    case 0xAE:
                    case 0xAF:
                    case 0xB0:  //quest vars											
                        {
                            Quest.instance.variables[i - 0x71] = (int)DataLoader.getValAtAddress(buffer, i, 8); break;
                        }
                    case 0xB1:  //The true max mana of the character. Used with the orb on level 7
                        UWCharacter.Instance.PlayerMagic.TrueMaxMana = (int)DataLoader.getValAtAddress(buffer, i, 8);
                        break;
                    case 0xB6: //Game options. High nibble is detail which is ignored Bit 0 is sound. Bit 3 is music													
                        break;
                    case 0xCF: ///   game time
                        GameClock.instance.game_time = (int)DataLoader.getValAtAddress(buffer, i, 32); break;
                    case 0xD0:
                        GameClock.instance.gametimevals[0] = (int)DataLoader.getValAtAddress(buffer, i, 8); break;
                    case 0xD1:
                        GameClock.instance.gametimevals[1] = (int)DataLoader.getValAtAddress(buffer, i, 8); break;
                    case 0xD2:
                        GameClock.instance.gametimevals[2] = (int)DataLoader.getValAtAddress(buffer, i, 8); break;

                    case 0xDD: ///    current vitality
                        UWCharacter.Instance.CurVIT = (int)buffer[i]; break;
                }
            }
            ApplySpellEffects(ActiveEffectIds, ActiveEffectStability, effectCounter);

            GameClock.setUWTime(GameClock.instance.gametimevals[0] + (GameClock.instance.gametimevals[1] * 255) + (GameClock.instance.gametimevals[2] * 255 * 255));

            //InitPlayerPosition (x_position, y_position, z_position);

            ResetInventory();

            LoadInventory(buffer, 312, 248, 286);

            if (UWCharacter.Instance.decode)
            {
                StreamWriter output = new StreamWriter(Loader.BasePath + "SAVE" + slotNo + sep + "decode_" + slotNo + ".csv");

                //write out decrypted file for analysis
                byte[] dataToWrite = new byte[buffer.GetUpperBound(0) + 1];
                for (long i = 0; i <= buffer.GetUpperBound(0); i++)
                {
                    dataToWrite[i] = (byte)buffer[i];
                    output.WriteLine((byte)buffer[i]);
                }
                output.Close();
                File.WriteAllBytes(Loader.BasePath + "SAVE" + slotNo + sep + "decode_" + slotNo + ".dat", dataToWrite);
            }

            /*	if (recode)//Rewrite the file with test value changes.
            {
                    xOrValue= (int)buffer[0];
                    incrnum = 3;
                    if (indextochange!=0)
                    {
                            buffer[indextochange]=(char)newvalue;										
                    }

                    for(int i=1; i<220; i++)
                    {
                            if ((i==81) | (i==161))
                            {
                                    incrnum = 3;
                            }
                            buffer[i] ^= (char)((xOrValue+incrnum) & 0xFF);
                            incrnum += 3;
                    }
                    //write back reencrypted file to test c
                    byte[] dataToWrite = new byte[buffer.GetUpperBound(0)+1];
                    for (long i=0; i<=buffer.GetUpperBound(0);i++)
                    {
                            dataToWrite[i] = (byte)buffer[i];
                    }
                    File.WriteAllBytes(Loader.BasePath + "save" + slotNo + "\\recoded.dat", dataToWrite);
            }*/
        }
    }


    /// <summary>
    /// Calcs the active spell effect id in a player.dat file and returns the correct value for the spell.
    /// </summary>
    /// <param name="val">Value.</param>
    public static int GetActiveSpellID(int val)
    {
        int effectID = ((val & 0xf) << 4) | ((val & 0xf0) >> 4);
        //Debug.Log (StringController.instance.GetString(6,effectID));

        switch (effectID)
        {
            case 178:
                return SpellEffect.UW1_Spell_Effect_Speed;
            case 179:
                return SpellEffect.UW1_Spell_Effect_Telekinesis;
            case 176:
                return SpellEffect.UW1_Spell_Effect_FreezeTime;
            case 183:
                return SpellEffect.UW1_Spell_Effect_RoamingSight;//Should not appear in a save game									
            default:
                return effectID;
        }
    }

    /// <summary>
    /// Sets the active rune slots.
    /// </summary>
    /// <param name="slotNo">Slot no.</param>
    /// <param name="rune">Rune.</param>
    static void SetActiveRuneSlots(int slotNo, int rune)
    {
        if (rune < 24)
        {
            UWCharacter.Instance.PlayerMagic.ActiveRunes[slotNo] = rune;
        }
        else
        {
            UWCharacter.Instance.PlayerMagic.ActiveRunes[slotNo] = -1;
        }
        ActiveRuneSlot.UpdateRuneSlots();
    }

    /// <summary>
    /// Writes the player dat file based on the current character
    /// </summary>
    /// <param name="slotNo">Slot no.</param>
    public static void WritePlayerDatUW1(int slotNo)
    {
        //float Ratio=213f;
        //float VertAdjust = 0.3543672f;

        //I'm lazy. I'm going to write a temp file and then re-encode using the key.
        FileStream file = File.Open(Loader.BasePath + "SAVE" + slotNo + sep + "playertmp.dat", FileMode.Create);
        BinaryWriter writer = new BinaryWriter(file);
        int NoOfActiveEffects = 0;
        //int runeOffset=0;

        //update inventory linking
        int NoOfInventoryItems = 0;
        string[] inventoryObjects = ObjectLoader.UpdateInventoryObjectList(out NoOfInventoryItems);

        //Write the XOR Key
        DataLoader.WriteInt8(writer, UWCharacter.Instance.XorKey);

        //Common uw1/uw2 save game data
        WriteName(writer);//1 to 14
        WriteSpace(writer, 17);
        WriteSkills(writer);
        WriteSpellEffects(writer);
        WriteRunes(writer);

        for (int i = 0x4B; i < 312; i++)
        {//non inventory data 
            switch (i)
            {
                case 0x4B:
                    {//No of inventory items?
                        DataLoader.WriteInt8(writer, (inventoryObjects.GetUpperBound(0) + 1) << 2);
                        break;
                    }
                case 0x4D: ///   weight in 0.1 stones
                    //Or STR * 2; 
                    DataLoader.WriteInt16(writer, UWCharacter.Instance.PlayerSkills.STR * 2 * 10);
                    break;
                case 0x4D + 1://2nd Byte of weight. Ignore
                    break;
                case 0x4F: ///   experience in 0.1 points
                    DataLoader.WriteInt32(writer, UWCharacter.Instance.EXP); break;
                case 0x4F + 1:
                case 0x4F + 2:
                case 0x4F + 3:
                    break;
                case 0x53: // skillpoints available to spend
                    DataLoader.WriteInt8(writer, UWCharacter.Instance.TrainingPoints); break;
                case 0x55: ///  position in level										
                    WritePosition(writer);
                    break;
                case 0x57: ///   y-position										
                case 0x59: ///   z-position
                case 0x55 + 1: ///   x-position in level
                case 0x57 + 1: ///   y-position
                case 0x59 + 1: ///   z-position	
                case 0x5B:
                case 0x5C: ///   heading								
                case 0x5D: ///   dungeon level										
                    break;//Skip over int 16s for position
                case 0x5F:///High nibble is dungeon level+1 with the silver tree if planted
                    {
                        int val = (UWCharacter.Instance.ResurrectLevel & 0xf) << 4 | (UWCharacter.Instance.MoonGateLevel & 0xf);
                        DataLoader.WriteInt8(writer, val);
                        break;
                    }
                case 0x60: ///    bits 2..5: play_poison.  no of active spell effects
                    DataLoader.WriteInt8(writer, (((NoOfActiveEffects & 0x3) << 6)) | (UWCharacter.Instance.play_poison << 2) | (Quest.instance.IncenseDream & 0x3));
                    break;
                case 0x61:
                    {
                        int val = 0;
                        if (Quest.instance.isOrbDestroyed)
                        {
                            val = 32;//bit 5
                        }
                        if (Quest.instance.isCupFound)
                        {
                            val = val | 64;     // bit 6 is the cup found.
                        }
                        DataLoader.WriteInt8(writer, val);
                        break;
                    }
                case 0x64://intoxication and is garamon buried.
                    {
                        int val = 0;
                        //player intoxication
                        val |= (UWCharacter.Instance.Intoxication << 4);
                        DataLoader.WriteInt16(writer, val);
                        if (Quest.instance.isGaramonBuried)
                        {
                            val |= 0xC00;
                        }
                        break;
                    }
                case 0x63: //Is garamon buried
                    {
                        if (Quest.instance.isGaramonBuried)
                        {
                            DataLoader.WriteInt8(writer, 28);
                        }
                        else
                        {//Default value Unknown meaning.
                            DataLoader.WriteInt8(writer, 16);
                        }
                        break;
                    }
                case 0x65: // hand, Gender & body, and class
                    {
                        WritePlayerClass(writer);
                        break;
                    }
                case 0x66://Quest flags
                    {
                        WriteUW1QuestFlags(writer);
                        break;
                    }

                case 0x66 + 1://Quest flags ignore
                case 0x66 + 2://Quest flags ignore
                case 0x66 + 3://Quest flags ignore
                    break;
                case 0x6A:
                    DataLoader.WriteInt8(writer, Quest.instance.QuestVariables[32]); break;
                case 0x6B:
                    DataLoader.WriteInt8(writer, Quest.instance.QuestVariables[33]); break;
                case 0x6C:
                    DataLoader.WriteInt8(writer, Quest.instance.QuestVariables[34]); break;
                case 0x6D:
                    DataLoader.WriteInt8(writer, Quest.instance.QuestVariables[35]); break;
                case 0x6E://No of talismans still to destory
                    DataLoader.WriteInt8(writer, Quest.instance.TalismansRemaining); break;
                case 0x6F://Garamon dream related?
                    DataLoader.WriteInt8(writer, Quest.instance.GaramonDream); break;
                case 0x71://Game variables
                case 0x72:
                case 0x73:
                case 0x74:
                case 0x75:
                case 0x76:
                case 0x77:
                case 0x78:
                case 0x79:
                case 0x7A:
                case 0x7B:
                case 0x7C:
                case 0x7D:
                case 0x7E:
                case 0x7F:
                case 0x80:
                case 0x81:
                case 0x82:
                case 0x83:
                case 0x84:
                case 0x85:
                case 0x86:
                case 0x87:
                case 0x88:
                case 0x89:
                case 0x8A:
                case 0x8B:
                case 0x8C:
                case 0x8D:
                case 0x8E:
                case 0x8F:
                case 0x90:
                case 0x91:
                case 0x92:
                case 0x93:
                case 0x94:
                case 0x95:
                case 0x96:
                case 0x97:
                case 0x98:
                case 0x99:
                case 0x9A:
                case 0x9B:
                case 0x9C:
                case 0x9D:
                case 0x9E:
                case 0x9F:
                case 0xA0:
                case 0xA1:
                case 0xA2:
                case 0xA3:
                case 0xA4:
                case 0xA5:
                case 0xA6:
                case 0xA7:
                case 0xA8:
                case 0xA9:
                case 0xAA:
                case 0xAB:
                case 0xAC:
                case 0xAD:
                case 0xAE:
                case 0xAF:
                case 0xB0:
                    {
                        DataLoader.WriteInt8(writer, Quest.instance.variables[i - 0x71]);
                        break;
                    }
                case 0xB1://The max mana the player has when their mana is drained by the magic orb.
                    {
                        DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerMagic.TrueMaxMana);
                        break;
                    }
                case 0xBC:
                    //Unknown
                    DataLoader.WriteInt8(writer, 0xFF);
                    break;
                case 0xb5://difficulty
                    DataLoader.WriteInt8(writer, GameWorldController.instance.difficulty); break;

                case 0xB6: //UW Game options TODO: Implement these
                           //high nibble is detail level.
                           //bit 0 of low nibble is sound
                           //bit 3 of low nibble is music
                    {
                        WriteGameOptions(writer);
                    }
                    break;
                case 0xB7://Unknown. Always 8
                    DataLoader.WriteInt8(writer, 0x8);
                    break;
                case 0xCF: ///   game time
                    DataLoader.WriteInt8(writer, 0); break;//Write zero since I don't track milliseconds
                                                           //break;
                case 0xD0:
                    DataLoader.WriteInt8(writer, GameClock.instance.gametimevals[0]); break;
                case 0xD1:
                    DataLoader.WriteInt8(writer, GameClock.instance.gametimevals[1]); break;
                case 0xD2:
                    DataLoader.WriteInt8(writer, GameClock.instance.gametimevals[2]); break;
                case 0xD3://No of inventory items + 1.
                    DataLoader.WriteInt16(writer, inventoryObjects.GetUpperBound(0) + 1 + 1);
                    break;
                case 0xD4://Skip prev
                    break;
                case 0xD5:
                    {//7F 20
                        DataLoader.WriteInt8(writer, 0x7F); break;
                    }
                case 0xD6:
                    {//The mysterious clip through bridges on a second jump byte.
                        DataLoader.WriteInt8(writer, 0x20); break;
                    }
                case 0xDB:
                    if (GameWorldController.instance.InventoryMarker.transform.childCount > 0)
                    {//player has inventory. Not sure where these values come from
                        DataLoader.WriteInt8(writer, 0x40);//Possibly no of inventory items+1  if this behaves like uw2?
                    }
                    else
                    {
                        DataLoader.WriteInt8(writer, 0x0);
                    }
                    break;
                case 0xDD://Duplicate curvit
                    DataLoader.WriteInt8(writer, UWCharacter.Instance.CurVIT); break;
                case 0xF8: // Helm (all of these subsequent values are indices into the object list at offset 312
                    WriteInventoryIndex(writer, inventoryObjects, 0); break;
                case 0xF9: // Helm ignore
                    break;
                case 0xFA: // Chest
                    WriteInventoryIndex(writer, inventoryObjects, 1); break;
                case 0xFB: // Chest ignore
                    break;
                case 0xFC: // Gloves
                    WriteInventoryIndex(writer, inventoryObjects, 4); break;
                case 0xFD: // Gloves ignore
                    break;
                case 0xFE: // Leggings
                    WriteInventoryIndex(writer, inventoryObjects, 2); break;
                case 0xFF: // Leggings ignore
                    break;
                case 0x100: // Boots
                    WriteInventoryIndex(writer, inventoryObjects, 3); break;
                case 0x101: // Boots ignore
                    break;
                case 0x102: // TopRightShoulder
                    WriteInventoryIndex(writer, inventoryObjects, 5); break;
                case 0x103: // TopRightShoulder ignore
                    break;
                case 0x104: // TopLeftShoulder
                    WriteInventoryIndex(writer, inventoryObjects, 6); break;
                case 0x105: // TopLeftShoulder ignore
                    break;
                case 0x106: // Righthand
                    WriteInventoryIndex(writer, inventoryObjects, 7); break;
                case 0x107: // Righthand ignore
                    break;
                case 0x108: // LeftHand
                    WriteInventoryIndex(writer, inventoryObjects, 8); break;
                case 0x109: // LeftHand ignore
                    break;
                case 0x10A: // leftRing
                    WriteInventoryIndex(writer, inventoryObjects, 9); break;
                case 0x10B: // leftRing ignore
                    break;
                case 0x10C: // rightRing
                    WriteInventoryIndex(writer, inventoryObjects, 10); break;
                case 0x10D: // rightRing ignore
                    break;
                case 0x10E: // Backpack0
                    WriteInventoryIndex(writer, inventoryObjects, 11); break;
                case 0x10F: // Backpack0 ignore
                    break;
                case 0x110: // Backpack1
                    WriteInventoryIndex(writer, inventoryObjects, 12); break;
                case 0x111: // Backpack1 ignore
                    break;
                case 0x112: // Backpack2
                    WriteInventoryIndex(writer, inventoryObjects, 13); break;
                case 0x113: // Backpack2 ignore
                    break;
                case 0x114: // Backpack3
                    WriteInventoryIndex(writer, inventoryObjects, 14); break;
                case 0x115: // Backpack3 ignore
                    break;
                case 0x116: // Backpack4
                    WriteInventoryIndex(writer, inventoryObjects, 15); break;
                case 0x117: // Backpack4 ignore
                    break;
                case 0x118: // Backpack5
                    WriteInventoryIndex(writer, inventoryObjects, 16); break;
                case 0x119: // Backpack5 ignore
                    break;
                case 0x11A: // Backpack6
                    WriteInventoryIndex(writer, inventoryObjects, 17); break;
                case 0x11B: // Backpack6 ignore
                    break;
                case 0x11C: // Backpack7
                    WriteInventoryIndex(writer, inventoryObjects, 18); break;
                case 0x11D: // Backpack7 ignore
                    break;
                default://No value. Write 0	
                    DataLoader.WriteInt8(writer, 0); break;

            }   //endswitch

        }

        //ALl things going well I should be at byte no 312 where I can write the inventory info.
        WriteInventory(writer, inventoryObjects);

        writer.Close();//The file now saved is un-encrypted

        char[] buffer;
        //Reopen and encrypt the file
        if (DataLoader.ReadStreamFile(Loader.BasePath + "SAVE" + slotNo + sep + "playertmp.dat", out buffer))
        {
            int xOrValue = (int)buffer[0];
            int incrnum = 3;
            for (int i = 1; i <= NoOfEncryptedBytes; i++)
            {
                if ((i == 81) | (i == 161))
                {
                    incrnum = 3;
                }
                buffer[i] ^= (char)((xOrValue + incrnum) & 0xFF);
                incrnum += 3;
            }

            byte[] dataToWrite = new byte[buffer.GetUpperBound(0) + 1];
            for (long i = 0; i <= buffer.GetUpperBound(0); i++)
            {
                dataToWrite[i] = (byte)buffer[i];
            }
            File.WriteAllBytes(Loader.BasePath + "SAVE" + slotNo + sep + "PLAYER.DAT", dataToWrite);
        }

    }

    /// <summary>
    /// Writes the player dat file based on the current character
    /// </summary>
    /// <param name="slotNo">Slot no.</param>
    public static void WritePlayerDatUW2(int slotNo)
    {
        //I'm lazy. I'm going to write a temp file and then re-encode using the key.
        FileStream file = File.Open(Loader.BasePath + "SAVE" + slotNo + sep + "playertmp.dat", FileMode.Create);
        BinaryWriter writer = new BinaryWriter(file);
        int NoOfActiveEffects = 0;
        //int runeOffset=0;
        int QuestCounter = 0;
        int variableCounter = 0;
        int bitVariableCounter = 0;
        //update inventory linking
        int NoOfInventoryItems = 0;
        string[] inventoryObjects = ObjectLoader.UpdateInventoryObjectList(out NoOfInventoryItems);
        Vector3 dreamReturn = CurrentTileMap().getTileVector(UWCharacter.Instance.DreamReturnTileX, UWCharacter.Instance.DreamReturnTileY);

        //Write the MS Key
        DataLoader.WriteInt8(writer, UWCharacter.Instance.XorKey);

        //Common uw1/uw2 save game data
        WriteName(writer);//1 to 14
        WriteSpace(writer, 17);
        WriteSkills(writer);
        WriteSpellEffects(writer);
        WriteRunes(writer);


        for (int i = 0x4B; i < 0x3E3; i++)
        {//non inventory data 
            switch (i)
            {
                case 0x4B:
                    {//No of inventory items?
                        if (NoOfInventoryItems > 0)
                        {
                            DataLoader.WriteInt8(writer, (inventoryObjects.GetUpperBound(0) + 3) << 2);
                        }
                        else
                        {
                            DataLoader.WriteInt8(writer, 0);
                        }
                        break;
                    }
                case 0x4D: ///   weight in 0.1 stones
                    //Or STR * 2; 
                    DataLoader.WriteInt16(writer, UWCharacter.Instance.PlayerSkills.STR * 2 * 10);
                    break;
                case 0x4D + 1:
                    break;
                case 0x4F: ///   experience in 0.1 points
                    DataLoader.WriteInt32(writer, UWCharacter.Instance.EXP*10); break;
                case 0x4F + 1:
                case 0x4F + 2:
                case 0x4F + 3:
                    break;
                case 0x53: // skillpoints available to spend
                    DataLoader.WriteInt8(writer, UWCharacter.Instance.TrainingPoints); break;
                case 0x55: ///  position in level										
                    WritePosition(writer);
                    break;
                case 0x56: ///   x-position in level
                case 0x57: ///   y-position	
                case 0x58: ///   y-position
                case 0x59: ///   z-position
                case 0x5A: ///   z-position	
                case 0x5B:
                case 0x5C: ///   heading								
                case 0x5D: ///   dungeon level										
                    break;//Skip over int 16s for position
                case 0x5F:///
                    {
                        //Low nibble is moongate level + 1
                        int val = (UWCharacter.Instance.MoonGateLevel & 0xf);
                        DataLoader.WriteInt8(writer, val);
                        break;
                    }
                case 0x61: ///    bits 1..4 play_poison and no of active effects (unchecked)//This differs from uw1 so it needs to be tested properly
                    DataLoader.WriteInt8(writer, (((NoOfActiveEffects & 0x3) << 5)) | (UWCharacter.Instance.play_poison << 1));
                    break;
                case 0x62:                   
                    DataLoader.WriteInt8(writer, UWCharacter.Instance.Intoxication<<6);
                    break;
                case 0x64:
                    {
                        int val = 0;
                        if (Quest.instance.DreamPlantEaten)
                        {
                            val |= 1;
                        }
                        if (Quest.instance.InDreamWorld)
                        {
                            val |= 2;
                        }
                        if (Quest.instance.FightingInArena)
                        {
                            val |= 4;
                        }
                        DataLoader.WriteInt8(writer, val);
                        break;
                    }
                case 0x66: // hand, Gender & body, and class
                    {
                        WritePlayerClass(writer);
                        break;
                    }

                case 0x67:  //Quests 0 to 3
                case 0x6B:  //Quests 4 to 7
                case 0x6F:  //Quests 8 to 11
                case 0x73:  //Quests 12 to 15
                case 0x77:  //Quests 16 to 19
                case 0x7B:  //Quests 20 to 23
                case 0x7F:  //Quests 24 to 27
                case 0x83:  //Quests 28 to 31
                case 0x87:  //Quests 32 to 35
                case 0x8B:  //Quests 36 to 39
                case 0x8F:  //Quests 40 to 43
                case 0x93:  //Quests 44 to 47
                case 0x97:  //Quests 48 to 51
                case 0x9B:  //Quests 52 to 55
                case 0x9F:  //Quests 56 to 59
                case 0xA3:  //Quests 60 to 63
                case 0xA7:  //Quests 64 to 67
                case 0xAB:  //Quests 68 to 71
                case 0xAF:  //Quests 72 to 75
                case 0xB3:  //Quests 76 to 79
                case 0xB7:  //Quests 80 to 83
                case 0xBB:  //Quests 84 to 87
                case 0xBF:  //Quests 88 to 91
                case 0xC3:  //Quests 92 to 95
                case 0xC7:  //Quests 96 to 99
                case 0xCB:  //Quests 100 to 103
                case 0xCF:  //Quests 104 to 107
                case 0xD3:  //Quests 108 to 111
                case 0xD7:  //Quests 112 to 115
                case 0xDB:  //Quests 116 to 119
                case 0xDF:  //Quests 120 to 123
                case 0xE3:  //Quests 124 to 127
                    {//The first 4 bits of each of these is the quest flags.
                        int val = 0;
                        for (int q = 0; q < 4; q++)
                        {
                            val |= (Quest.instance.QuestVariables[QuestCounter + q] & 0x1) << q;
                        }
                        QuestCounter += 4;
                        DataLoader.WriteInt8(writer, val);
                        break;
                    }
                case 0xE7:  //Quest 128 - Where the lines of power have been cut
                case 0xE8:  //Quest 129
                case 0xE9:  //Quest 130
                case 0xEA:  //Quest 131
                case 0xEB:  //Quest 132
                case 0xEC:  //Quest 133
                case 0xED:  //Quest 134
                case 0xEE:  //Quest 135
                case 0xEF:  //Quest 136
                case 0xF0:  //Quest 137
                case 0xF1:  //Quest 138
                            //Additional quests
                case 0xF2:  //Quest 139
                case 0xF3:  //Quest 140
                case 0xF4:  //Quest 141
                case 0xF5:  //Quest 142
                case 0xF6:  //Quest 143
                case 0xF7:  //Quest 144
                case 0xF8:  //Quest 145
                case 0xF9:  //Quest 146

                    {//TODO:These quests are not tested.
                        DataLoader.WriteInt8(writer, Quest.instance.QuestVariables[128 + (i - 0xE7)]);
                        break;
                    }
                case 0xFA:  //Variable0
                case 0xFC:  //Variable1
                case 0xFE:  //Variable2
                case 0x100:  //Variable3
                case 0x102:  //Variable4
                case 0x104:  //Variable5
                case 0x106:  //Treated gems used/ Variable6
                case 0x108:  //Variable7
                case 0x10A:  //Variable8
                case 0x10C:  //Variable9
                case 0x10E:  //Variable10
                case 0x110:  //Variable11
                case 0x112:  //Variable12
                case 0x114:  //Variable13
                case 0x116:  //Variable14
                case 0x118:  //Variable15
                case 0x11A:  //Variable16
                case 0x11C:  //Variable17
                case 0x11E:  //Variable18
                case 0x120:  //Variable19
                case 0x122:  //Variable20
                case 0x124:  //Variable21
                case 0x126:  //Variable22
                case 0x128:  //Variable23
                case 0x12A:  //Variable24
                case 0x12C:  //Variable25
                case 0x12E:  //Variable26
                case 0x130:  //Variable27
                case 0x132:  //Variable28
                case 0x134:  //Variable29
                case 0x136:  //Variable30
                case 0x138:  //Variable31
                case 0x13A:  //Variable32
                case 0x13C:  //Variable33
                case 0x13E:  //Variable34
                case 0x140:  //Variable35
                case 0x142:  //Variable36
                case 0x144:  //Variable37
                case 0x146:  //Variable38
                case 0x148:  //Variable39
                case 0x14A:  //Variable40
                case 0x14C:  //Variable41
                case 0x14E:  //Variable42
                case 0x150:  //Variable43
                case 0x152:  //Variable44
                case 0x154:  //Variable45
                case 0x156:  //Variable46
                case 0x158:  //Variable47
                case 0x15A:  //Variable48
                case 0x15C:  //Variable49
                case 0x15E:  //Variable50
                case 0x160:  //Variable 51
                case 0x162:  //Variable 52
                case 0x164:  //Variable 53 
                case 0x166:  //54
                case 0x168:  //55
                case 0x16A:  //56
                case 0x16C:  //57
                case 0x16E:  //58
                case 0x170:  //59
                case 0x172:  //60
                case 0x174:  //61
                case 0x176:  //62
                case 0x178:  //63
                case 0x17A:  //64
                case 0x17C:  //65
                case 0x17E:  //66
                case 0x180:  //67
                case 0x182:  //68
                case 0x184:  //69
                case 0x186:  //70
                case 0x188:  //71
                case 0x18A:  //72
                case 0x18C:  //73
                case 0x18E:  //74
                case 0x190:  //75
                case 0x192:  //76
                case 0x194:  //77
                case 0x196:  //78
                case 0x198:  //79
                case 0x19A:  //80
                case 0x19C:  //81
                case 0x19E:  //82
                case 0x1A0:  //83
                case 0x1A2:  //84
                case 0x1A4:  //85
                case 0x1A6:  //86
                case 0x1A8:  //87
                case 0x1AA:  //88
                case 0x1AC:  //89
                case 0x1AE:  //90
                case 0x1B0:  //91
                case 0x1B2:  //92
                case 0x1B4:  //93
                case 0x1B6:  //94
                case 0x1B8:  //95
                case 0x1BA:  //96
                case 0x1BC:  //97
                case 0x1BE:  //98
                case 0x1C0:  //99
                case 0x1C2:  //100
                case 0x1C4:  //Variable 101
                case 0x1C6:  //102
                case 0x1C8:  //103
                case 0x1CA:  //104
                case 0x1CC:  //105
                case 0x1CE:  //106
                case 0x1D0:  //107
                    {//Split here due to qbert variable
                        DataLoader.WriteInt8(writer, Quest.instance.variables[variableCounter++]);
                        break;
                    }
                case 0x1D4:  //109
                case 0x1D6:  //110
                case 0x1D8:  //111
                case 0x1DA:  //112
                case 0x1DC:  //Variable 113
                case 0x1DE:  //Variable 114 (duplicate with below!!!)
                case 0x1E0:  //Variable 115
                case 0x1E2:  //116
                case 0x1E4:  //117
                case 0x1E6:  //118
                case 0x1E8:  //119
                case 0x1EA:  //120
                case 0x1EC:  //121
                case 0x1EE:  //122
                case 0x1F0:  //123
                case 0x1F2:  //124
                case 0x1F4:  //125
                case 0x1F6:  //126
                case 0x1F8:  //Variable 127
                    {
                        DataLoader.WriteInt8(writer, Quest.instance.variables[variableCounter++]);
                        break;
                    }
                case 0x1D2:  //Variable 108 //Int 16 used in qbert
                    {
                        DataLoader.WriteInt16(writer, Quest.instance.variables[variableCounter++]);
                        break;
                    }
                case 0x1D2 + 1:
                    break;
                //Bit variables 0 to 127
                case 0x1FA:
                case 0x1FC:
                case 0x1FE:
                case 0x200:
                case 0x202:
                case 0x204:
                case 0x206:
                case 0x208:
                case 0x20A:
                case 0x20C:
                case 0x20E:
                case 0x210:
                case 0x212:
                case 0x214:
                case 0x216:
                case 0x218:
                case 0x21A:
                case 0x21C:
                case 0x21E:
                case 0x220:
                case 0x222:
                case 0x224:
                case 0x226:
                case 0x228:
                case 0x22A:
                case 0x22C:
                case 0x22E:
                case 0x230:
                case 0x232:
                case 0x234:
                case 0x236:
                case 0x238:
                case 0x23A:
                case 0x23C:
                case 0x23E:
                case 0x240:
                case 0x242:
                case 0x244:
                case 0x246:
                case 0x248:
                case 0x24A:
                case 0x24C:
                case 0x24E:
                case 0x250:
                case 0x252:
                case 0x254:
                case 0x256:
                case 0x258:
                case 0x25A:
                case 0x25C:
                case 0x25E:
                case 0x260:
                case 0x262:
                case 0x264:
                case 0x266:
                case 0x268:
                case 0x26A:
                case 0x26C:
                case 0x26E:
                case 0x270:
                case 0x272:
                case 0x274:
                case 0x276:
                case 0x278:
                case 0x27A:
                case 0x27C:
                case 0x27E:
                case 0x280:
                case 0x282:
                case 0x284:
                case 0x286:
                case 0x288:
                case 0x28A:
                case 0x28C:
                case 0x28E:
                case 0x290:
                case 0x292:
                case 0x294:
                case 0x296:
                case 0x298:
                case 0x29A:
                case 0x29C:
                case 0x29E:
                case 0x2A0:
                case 0x2A2:
                case 0x2A4:
                case 0x2A6:
                case 0x2A8:
                case 0x2AA:
                case 0x2AC:
                case 0x2AE:
                case 0x2B0:
                case 0x2B2:
                case 0x2B4:
                case 0x2B6:
                case 0x2B8:
                case 0x2BA:
                case 0x2BC:
                case 0x2BE:
                case 0x2C0:
                case 0x2C2:
                case 0x2C4:
                case 0x2C6:
                case 0x2C8:
                case 0x2CA:
                case 0x2CC:
                case 0x2CE:
                case 0x2D0:
                case 0x2D2:
                case 0x2D4:
                case 0x2D6:
                case 0x2D8:
                case 0x2DA:
                case 0x2DC:
                case 0x2DE:
                case 0x2E0:
                case 0x2E2:
                case 0x2E4:
                case 0x2E6:
                case 0x2E8:
                case 0x2EA:
                case 0x2EC:
                case 0x2EE:
                case 0x2F0:
                case 0x2F2:
                case 0x2F4:
                case 0x2F6:
                case 0x2F8://end bit variables

                    DataLoader.WriteInt8(writer, Quest.instance.BitVariables[bitVariableCounter++]);
                    break;
                //Skip over for bit vars
                case 0x1FA + 1:
                case 0x1FC + 1:
                case 0x1FE + 1:
                case 0x200 + 1:
                case 0x202 + 1:
                case 0x204 + 1:
                case 0x206 + 1:
                case 0x208 + 1:
                case 0x20A + 1:
                case 0x20C + 1:
                case 0x20E + 1:
                case 0x210 + 1:
                case 0x212 + 1:
                case 0x214 + 1:
                case 0x216 + 1:
                case 0x218 + 1:
                case 0x21A + 1:
                case 0x21C + 1:
                case 0x21E + 1:
                case 0x220 + 1:
                case 0x222 + 1:
                case 0x224 + 1:
                case 0x226 + 1:
                case 0x228 + 1:
                case 0x22A + 1:
                case 0x22C + 1:
                case 0x22E + 1:
                case 0x230 + 1:
                case 0x232 + 1:
                case 0x234 + 1:
                case 0x236 + 1:
                case 0x238 + 1:
                case 0x23A + 1:
                case 0x23C + 1:
                case 0x23E + 1:
                case 0x240 + 1:
                case 0x242 + 1:
                case 0x244 + 1:
                case 0x246 + 1:
                case 0x248 + 1:
                case 0x24A + 1:
                case 0x24C + 1:
                case 0x24E + 1:
                case 0x250 + 1:
                case 0x252 + 1:
                case 0x254 + 1:
                case 0x256 + 1:
                case 0x258 + 1:
                case 0x25A + 1:
                case 0x25C + 1:
                case 0x25E + 1:
                case 0x260 + 1:
                case 0x262 + 1:
                case 0x264 + 1:
                case 0x266 + 1:
                case 0x268 + 1:
                case 0x26A + 1:
                case 0x26C + 1:
                case 0x26E + 1:
                case 0x270 + 1:
                case 0x272 + 1:
                case 0x274 + 1:
                case 0x276 + 1:
                case 0x278 + 1:
                case 0x27A + 1:
                case 0x27C + 1:
                case 0x27E + 1:
                case 0x280 + 1:
                case 0x282 + 1:
                case 0x284 + 1:
                case 0x286 + 1:
                case 0x288 + 1:
                case 0x28A + 1:
                case 0x28C + 1:
                case 0x28E + 1:
                case 0x290 + 1:
                case 0x292 + 1:
                case 0x294 + 1:
                case 0x296 + 1:
                case 0x298 + 1:
                case 0x29A + 1:
                case 0x29C + 1:
                case 0x29E + 1:
                case 0x2A0 + 1:
                case 0x2A2 + 1:
                case 0x2A4 + 1:
                case 0x2A6 + 1:
                case 0x2A8 + 1:
                case 0x2AA + 1:
                case 0x2AC + 1:
                case 0x2AE + 1:
                case 0x2B0 + 1:
                case 0x2B2 + 1:
                case 0x2B4 + 1:
                case 0x2B6 + 1:
                case 0x2B8 + 1:
                case 0x2BA + 1:
                case 0x2BC + 1:
                case 0x2BE + 1:
                case 0x2C0 + 1:
                case 0x2C2 + 1:
                case 0x2C4 + 1:
                case 0x2C6 + 1:
                case 0x2C8 + 1:
                case 0x2CA + 1:
                case 0x2CC + 1:
                case 0x2CE + 1:
                case 0x2D0 + 1:
                case 0x2D2 + 1:
                case 0x2D4 + 1:
                case 0x2D6 + 1:
                case 0x2D8 + 1:
                case 0x2DA + 1:
                case 0x2DC + 1:
                case 0x2DE + 1:
                case 0x2E0 + 1:
                case 0x2E2 + 1:
                case 0x2E4 + 1:
                case 0x2E6 + 1:
                case 0x2E8 + 1:
                case 0x2EA + 1:
                case 0x2EC + 1:
                case 0x2EE + 1:
                case 0x2F0 + 1:
                case 0x2F2 + 1:
                case 0x2F4 + 1:
                case 0x2F6 + 1:
                case 0x2F8 + 1:
                    {
                        //End skip over for bit vars
                        break;

                    }
                case 0x2fb: //dream return position x
                    DataLoader.WriteInt16(writer, (int)(dreamReturn.x * Ratio));
                    break;
                case 0x2fb + 1: break;
                case 0x2fd: /// dream return  y-position
                    DataLoader.WriteInt16(writer, (int)(dreamReturn.z * Ratio));
                    break;
                case 0x2fd + 1: break;
                case 0x301:
                    DataLoader.WriteInt8(writer, UWCharacter.Instance.DreamReturnLevel);
                    break;
                case 0x303:
                    //{//Game options high nibble is graphic detail
                    WriteGameOptions(writer);
                    break;
                //}
                case 0x306://paralyze timer
                    DataLoader.WriteInt8(writer, (int)UWCharacter.Instance.ParalyzeTimer);
                    break;
                case 0x361://Item Ids of arena warriors.
                case 0x362:
                case 0x363:
                case 0x364:
                case 0x365:
                    {
                        DataLoader.WriteInt8(writer, Quest.instance.ArenaOpponents[i - 0x361]);
                        break;
                    }
                case 0x36a: ///   game time
                    DataLoader.WriteInt8(writer, 0); break;
                case 0x36b:
                    DataLoader.WriteInt8(writer, GameClock.instance.gametimevals[0]); break;
                case 0x36c:
                    DataLoader.WriteInt8(writer, GameClock.instance.gametimevals[1]); break;
                case 0x36d:
                    DataLoader.WriteInt8(writer, GameClock.instance.gametimevals[2]); break;
                case 0x36f://1 Castle events
                case 0x370://2
                case 0x371://3 DjinnCapture
                case 0x372://4
                case 0x373://5
                case 0x374://6
                case 0x375://7
                case 0x376://8
                case 0x377://9
                case 0x378://10
                case 0x379://11
                case 0x37a://12
                case 0x37b://13
                case 0x37c://14
                           //case 0x37d://15 -- This could be wrong.
                    {//The mysterious x_clocks
                        DataLoader.WriteInt8(writer, Quest.instance.x_clocks[1 + i - 0x36f]); break;
                    }
                case 0x3A3: // Helm (all of these subsequent values are indices into the object list 
                    WriteInventoryIndex(writer, inventoryObjects, 0); break;
                case 0x3A4: // Helm ignore
                    break;
                case 0x3A5: // Chest
                    WriteInventoryIndex(writer, inventoryObjects, 1); break;
                case 0x3A6: // Chest ignore
                    break;
                case 0x3A7: // Gloves
                    WriteInventoryIndex(writer, inventoryObjects, 4); break;
                case 0x3A8: // Gloves ignore
                    break;
                case 0x3A9: // Leggings
                    WriteInventoryIndex(writer, inventoryObjects, 2); break;
                case 0x3AA: // Leggings ignore
                    break;
                case 0x3AB: // Boots
                    WriteInventoryIndex(writer, inventoryObjects, 3); break;
                case 0x3AC: // Boots ignore
                    break;
                case 0x3AD: // TopRightShoulder
                    WriteInventoryIndex(writer, inventoryObjects, 5); break;
                case 0x3AE: // TopRightShoulder ignore
                    break;
                case 0x3AF: // TopLeftShoulder
                    WriteInventoryIndex(writer, inventoryObjects, 6); break;
                case 0x3B0: // TopLeftShoulder ignore
                    break;
                case 0x3B1: // Righthand
                    WriteInventoryIndex(writer, inventoryObjects, 7); break;
                case 0x3B2: // Righthand ignore
                    break;
                case 0x3B3: // LeftHand
                    WriteInventoryIndex(writer, inventoryObjects, 8); break;
                case 0x3B4: // LeftHand ignore
                    break;
                case 0x3B5: // Ring
                    WriteInventoryIndex(writer, inventoryObjects, 9); break;
                case 0x3B6: // Ring ignore
                    break;
                case 0x3B7: // Ring
                    WriteInventoryIndex(writer, inventoryObjects, 10); break;
                case 0x3B8: // Ring ignore
                    break;
                case 0x3B9: // Backpack0
                    WriteInventoryIndex(writer, inventoryObjects, 11); break;
                case 0x3BA: // Backpack0 ignore
                    break;
                case 0x3BB: // Backpack1
                    WriteInventoryIndex(writer, inventoryObjects, 12); break;
                case 0x3BC: // Backpack1 ignore
                    break;
                case 0x3BD: // Backpack2
                    WriteInventoryIndex(writer, inventoryObjects, 13); break;
                case 0x3BE: // Backpack2 ignore
                    break;
                case 0x3BF: // Backpack3
                    WriteInventoryIndex(writer, inventoryObjects, 14); break;
                case 0x3C0: // Backpack3 ignore
                    break;
                case 0x3C1: // Backpack4
                    WriteInventoryIndex(writer, inventoryObjects, 15); break;
                case 0x3C2: // Backpack4 ignore
                    break;
                case 0x3C3: // Backpack5
                    WriteInventoryIndex(writer, inventoryObjects, 16); break;
                case 0x3C4: // Backpack5 ignore
                    break;
                case 0x3C5: // Backpack6
                    WriteInventoryIndex(writer, inventoryObjects, 17); break;
                case 0x3C6: // Backpack6 ignore
                    break;
                case 0x3C7: // Backpack7
                    WriteInventoryIndex(writer, inventoryObjects, 18); break;
                case 0x3C8: // Backpack7 ignore
                    break;
                case 0x388://Curvit as well?Kills HE player if not properly set
                    DataLoader.WriteInt8(writer, UWCharacter.Instance.CurVIT); break;
                //Weird hard coded values that the inventory won't work without
                //F3 02 00 7F 20 60 F3 00 00 40
                case 0x37d: DataLoader.WriteInt8(writer, 0xF3); break;
                case 0x37e: //No of inventory items+1
                    DataLoader.WriteInt8(writer, NoOfInventoryItems + 1);
                    break;
                //DataLoader.WriteInt8(writer,0x02);break;
                //case 0x37f:	DataLoader.WriteInt8(writer,0x00);break;
                case 0x380: DataLoader.WriteInt8(writer, 0x7f); break;
                case 0x381: DataLoader.WriteInt8(writer, 0x20); break;
                case 0x382: DataLoader.WriteInt8(writer, 0x60); break;
                case 0x383: DataLoader.WriteInt8(writer, 0xF3); break;
                //case 0x384:	DataLoader.WriteInt8(writer,0x00);break;
                //case 0x385:	DataLoader.WriteInt8(writer,0x00);break;
                case 0x386: DataLoader.WriteInt8(writer, 0x40); break;



                default://No value. Write 0	
                    DataLoader.WriteInt8(writer, 0); break;
            }
        }

        //ALl things going well I should be at byte no 0x3e3 where I can write the inventory info.
        WriteInventory(writer, inventoryObjects);

        writer.Close();//The file now saved is un-encrypted


        char[] buffer;
        //Reopen and encrypt the file
        if (DataLoader.ReadStreamFile(Loader.BasePath + "SAVE" + slotNo + sep + "playertmp.dat", out buffer))
        {
            char[] recodetest = DecodeEncodeUW2PlayerDat(buffer, (byte)UWCharacter.Instance.XorKey);

            byte[] dataToWrite = new byte[recodetest.GetUpperBound(0) + 1];
            for (long i = 0; i <= recodetest.GetUpperBound(0); i++)
            {
                dataToWrite[i] = (byte)recodetest[i];
            }
            File.WriteAllBytes(Loader.BasePath + "SAVE" + slotNo + sep + "PLAYER.DAT", dataToWrite);
        }
    }


    static char[] DecodeEncodeUW2PlayerDat(char[] pDat, byte MS)
    {
        int[] MA = new int[80];
        MS += 7;
        for (int i = 0; i < 80; ++i)
        {
            MS += 6;
            MA[i] = MS;
        }
        for (int i = 0; i < 16; ++i)
        {
            MS += 7;
            MA[i * 5] = MS;
        }
        for (int i = 0; i < 4; ++i)
        {
            MS += 0x29;
            MA[i * 12] = MS;
        }
        for (int i = 0; i < 11; ++i)
        {
            MS += 0x49;
            MA[i * 7] = MS;
        }
        char[] buffer = new char[pDat.GetUpperBound(0) + 1];
        int offset = 1;
        int byteCounter = 0;
        for (int l = 0; l <= 11; l++)
        {
            buffer[0 + offset] = (char)(pDat[0 + offset] ^ MA[0]);
            byteCounter++;
            for (int i = 1; i < 0x50; ++i)
            {
                if (byteCounter < 0x37D)
                {
                    buffer[i + offset] = (char)(((pDat[i + offset] & 0xff) ^ ((buffer[i - 1 + offset] & 0xff) + (pDat[i - 1 + offset] & 0xff) + (MA[i] & 0xff))) & 0xff);
                    byteCounter++;
                }
            }
            offset += 80;
        }
        //Copy the remainder of the plaintext data
        while (byteCounter <= pDat.GetUpperBound(0))
        {
            buffer[byteCounter] = pDat[byteCounter];
            byteCounter++;
        }
        buffer[0] = pDat[0];
        return buffer;
    }

    static void WriteInventoryIndex(BinaryWriter writer, string[] InventoryObjects, short slotIndex)
    {
        ObjectInteraction itemAtSlot = null;
        if (slotIndex <= 10)
        {
            itemAtSlot = UWCharacter.Instance.playerInventory.GetObjectIntAtSlot(slotIndex);
        }
        else
        {
            itemAtSlot = UWCharacter.Instance.playerInventory.playerContainer.GetItemAt((short)(slotIndex - 11));
        }
        if (itemAtSlot != null)
        {
            int index = ((System.Array.IndexOf(InventoryObjects, itemAtSlot.name) + 1) << 6);//64
            DataLoader.WriteInt16(writer, index);
        }
        else
        {
            DataLoader.WriteInt16(writer, 0);
        }
    }



    /// <summary>
    /// Loads the player dat file for uw2.
    /// </summary>
    /// <param name="slotNo">Slot no.</param>
    public static void LoadPlayerDatUW2(int slotNo)
    {
        UWCharacter.Instance.CharName = "";
        char[] pDat;
        //int x_position=0;
        //int y_position=0;

        int x_position_dream = 0;
        int y_position_dream = 0;

        //int z_position=0;
        int x_clock = 1;


        //int[] gametimevals=new int[3];
        int[] ActiveEffectIds = new int[3];
        short[] ActiveEffectStability = new short[3];
        int effectCounter = 0;
        int QuestCounter = 0;
        int VariableCounter = 0;
        int BitVariableCounter = 0;
        int arena = 0;

        ResetUI();

        UWCharacter.Instance.JustTeleported = true;
        UWCharacter.Instance.teleportedTimer = 0f;

        if (DataLoader.ReadStreamFile(Loader.BasePath + "SAVE" + slotNo + sep + "PLAYER.DAT", out pDat))
        {
            byte MS = (byte)DataLoader.getValAtAddress(pDat, 0, 8);
            UWCharacter.Instance.XorKey = (int)MS;
            char[] buffer = DecodeEncodeUW2PlayerDat(pDat, MS);
            if (UWCharacter.Instance.decode)
            {
                //write out decrypted file for analysis
                StreamWriter output = new StreamWriter(Loader.BasePath + "SAVE" + slotNo + sep + "decode_" + slotNo + ".csv");
                byte[] dataToWrite = new byte[buffer.GetUpperBound(0) + 1];
                for (long i = 0; i <= buffer.GetUpperBound(0); i++)
                {
                    dataToWrite[i] = (byte)buffer[i];
                    output.WriteLine((byte)buffer[i]);
                }
                output.Close();
                File.WriteAllBytes(Loader.BasePath + "SAVE" + slotNo + sep + "decode_" + slotNo + ".dat", dataToWrite);
            }
            /*for (int c=0; c<=pDat.GetUpperBound(0);c++)
            {
                    if (recodetest[c]!=pDat[c])
                    {
                            Debug.Log("File difference at " + c);
                            break;
                    }
            }*/

            //File.WriteAllBytes(Loader.BasePath + "save4\\player.dat", (byte)recodetest);
            if (UWCharacter.Instance.recode)
            {
                    if (UWCharacter.Instance.recode_cheat)
                    {
                            for (int r=31; r<=53;r++)
                            {
                                    buffer[r]=(char)0;
                            }
                    }
                    else
                    {
                            buffer[UWCharacter.Instance.IndexToRecode]=(char)UWCharacter.Instance.ValueToRecode;		
                    }

                    char[] recodetest = DecodeEncodeUW2PlayerDat(buffer,MS);

                    byte[] dataToWrite = new byte[recodetest.GetUpperBound(0)+1];
                    for (long i=0; i<=recodetest.GetUpperBound(0);i++)
                    {
                            dataToWrite[i] = (byte)recodetest[i];
                    }
                    File.WriteAllBytes(Loader.BasePath + "SAVE" + slotNo + sep + "playerrecoded.dat", dataToWrite);
            }


            //Load some common items for uw1/2
            LoadName(buffer);
            LoadStats(buffer);
            effectCounter = LoadSpellEffects(buffer, ref ActiveEffectIds, ref ActiveEffectStability);
            LoadRunes(buffer);
            LoadPlayerClass(buffer, 0x66);
            LoadGameOptions(buffer, 0x303);

            for (int i = 0x4D; i <= 930; i++)
            {
                switch (i)//UWformats doesn't take the first byte into account when describing offsets! I have incremented plus one
                {
                    case 0x4D: ///   weight in 0.1 stones
                        //Or STR * 2; safe to ignore?
                        //testvalue=(int)DataLoader.getValAtAddress(buffer,i,16);break;
                        Debug.Log("Weight value is " + (int)DataLoader.getValAtAddress(buffer, i, 16) + " str = " + UWCharacter.Instance.PlayerSkills.STR);
                        break;
                    case 0x4F: ///   experience in 0.1 points
                        UWCharacter.Instance.EXP = (int)(DataLoader.getValAtAddress(buffer, i, 32) *0.1f); break;
                    case 0x53: // skillpoints available to spend
                        UWCharacter.Instance.TrainingPoints = (int)buffer[i]; break;
                    case 0x55: ///   x-position in level
                        LoadPosition(buffer); break;
                    case 0x5F:///High nibble is dungeon level+1 with the silver tree if planted
                        //Low nibble is moongate level + 1
                        UWCharacter.Instance.ResurrectLevel = (short)((buffer[i] >> 4) & 0xf);
                        UWCharacter.Instance.MoonGateLevel = (short)(buffer[i] & 0xf);
                        break;
                    case 0x61: ///    bits 1..4 play_poison and no of active effects (unchecked)
                        UWCharacter.Instance.play_poison = (short)((buffer[i] >> 1) & 0xF);
                        UWCharacter.Instance.poison_timer = 30f;
                        effectCounter = ((int)buffer[i] >> 6) & 0x3;
                        break;
                    case 0x62://alco
                        UWCharacter.Instance.Intoxication = ((int)DataLoader.getValAtAddress(buffer, i, 16) >> 6) & 0x3f;
                        break;
                    case 0x64:
                        Quest.instance.DreamPlantEaten = (1 == (((int)buffer[i]) & 0x1));
                        Quest.instance.InDreamWorld = (1 == (((int)buffer[i] >> 1) & 0x1));
                        Quest.instance.FightingInArena = (1 == (((int)buffer[i] >> 2) & 0x1));
                        UWCharacter.Instance.DreamWorldTimer = 30f;
                        break;
                    case 0x66: // hand, Gender & body, and class
                        {
                            break;
                        }

                    case 0x67:  //Quests 0 to 3
                    case 0x6B:  //Quests 4 to 7
                    case 0x6F:  //Quests 8 to 11
                    case 0x73:  //Quests 12 to 15
                    case 0x77:  //Quests 16 to 19
                    case 0x7B:  //Quests 20 to 23
                    case 0x7F:  //Quests 24 to 27
                    case 0x83:  //Quests 28 to 31
                    case 0x87:  //Quests 32 to 35
                    case 0x8B:  //Quests 36 to 39
                    case 0x8F:  //Quests 40 to 43
                    case 0x93:  //Quests 44 to 47
                    case 0x97:  //Quests 48 to 51
                    case 0x9B:  //Quests 52 to 55
                    case 0x9F:  //Quests 56 to 59
                    case 0xA3:  //Quests 60 to 63
                    case 0xA7:  //Quests 64 to 67
                    case 0xAB:  //Quests 68 to 71
                    case 0xAF:  //Quests 72 to 75
                    case 0xB3:  //Quests 76 to 79
                    case 0xB7:  //Quests 80 to 83
                    case 0xBB:  //Quests 84 to 87
                    case 0xBF:  //Quests 88 to 91
                    case 0xC3:  //Quests 92 to 95
                    case 0xC7:  //Quests 96 to 99
                    case 0xCB:  //Quests 100 to 103
                    case 0xCF:  //Quests 104 to 107
                    case 0xD3:  //Quests 108 to 111
                    case 0xD7:  //Quests 112 to 115
                    case 0xDB:  //Quests 116 to 119
                    case 0xDF:  //Quests 120 to 123
                    case 0xE3:  //Quests 124 to 127
                        {//The first 4 bits of each of these is the quest flags.
                            int val = (int)DataLoader.getValAtAddress(buffer, i, 8);
                            for (int q = 0; q < 4; q++)
                            {
                                Quest.instance.QuestVariables[QuestCounter++] = (val >> q) & 0x1;
                            }
                            break;
                        }
                    case 0xE7:  //Quest 128 - Where the lines of power have been cut
                    case 0xE8:  //Quest 129
                    case 0xE9:  //Quest 130
                    case 0xEA:  //Quest 131
                    case 0xEB:  //Quest 132
                    case 0xEC:  //Quest 133
                    case 0xED:  //Quest 134
                    case 0xEE:  //Quest 135
                    case 0xEF:  //Quest 136
                    case 0xF0:  //Quest 137
                    case 0xF1:  //Quest 138
                                //Additional quests
                    case 0xF2:  //Quest 139
                    case 0xF3:  //Quest 140
                    case 0xF4:  //Quest 141
                    case 0xF5:  //Quest 142
                    case 0xF6:  //Quest 143
                    case 0xF7:  //Quest 144
                    case 0xF8:  //Quest 145
                    case 0xF9:  //Quest 146
                        {//TODO:These quests are not tested.
                            Quest.instance.QuestVariables[i - 103] = (int)DataLoader.getValAtAddress(buffer, i, 8);
                            break;
                        }
                    case 0xFA:  //Variable0
                    case 0xFC:  //Variable1
                    case 0xFE:  //Variable2
                    case 0x100:  //Variable3
                    case 0x102:  //Variable4
                    case 0x104:  //Variable5
                    case 0x106:  //Treated gems used/ Variable6
                    case 0x108:  //Variable7
                    case 0x10A:  //Variable8
                    case 0x10C:  //Variable9
                    case 0x10E:  //Variable10
                    case 0x110:  //Variable11
                    case 0x112:  //Variable12
                    case 0x114:  //Variable13
                    case 0x116:  //Variable14
                    case 0x118:  //Variable15
                    case 0x11A:  //Variable16
                    case 0x11C:  //Variable17
                    case 0x11E:  //Variable18
                    case 0x120:  //Variable19
                    case 0x122:  //Variable20
                    case 0x124:  //Variable21
                    case 0x126:  //Variable22
                    case 0x128:  //Variable23
                    case 0x12A:  //Variable24
                    case 0x12C:  //Variable25
                    case 0x12E:  //Variable26
                    case 0x130:  //Variable27
                    case 0x132:  //Variable28
                    case 0x134:  //Variable29
                    case 0x136:  //Variable30
                    case 0x138:  //Variable31
                    case 0x13A:  //Variable32
                    case 0x13C:  //Variable33
                    case 0x13E:  //Variable34
                    case 0x140:  //Variable35
                    case 0x142:  //Variable36
                    case 0x144:  //Variable37
                    case 0x146:  //Variable38
                    case 0x148:  //Variable39
                    case 0x14A:  //Variable40
                    case 0x14C:  //Variable41
                    case 0x14E:  //Variable42
                    case 0x150:  //Variable43
                    case 0x152:  //Variable44
                    case 0x154:  //Variable45
                    case 0x156:  //Variable46
                    case 0x158:  //Variable47
                    case 0x15A:  //Variable48
                    case 0x15C:  //Variable49
                    case 0x15E:  //Variable50
                    case 0x160:  //Variable 51
                    case 0x162:  //Variable 52
                    case 0x164:  //Variable 53 
                    case 0x166:  //54
                    case 0x168:  //55
                    case 0x16A:  //56
                    case 0x16C:  //57
                    case 0x16E:  //58
                    case 0x170:  //59
                    case 0x172:  //60
                    case 0x174:  //61
                    case 0x176:  //62
                    case 0x178:  //63
                    case 0x17A:  //64
                    case 0x17C:  //65
                    case 0x17E:  //66
                    case 0x180:  //67
                    case 0x182:  //68
                    case 0x184:  //69
                    case 0x186:  //70
                    case 0x188:  //71
                    case 0x18A:  //72
                    case 0x18C:  //73
                    case 0x18E:  //74
                    case 0x190:  //75
                    case 0x192:  //76
                    case 0x194:  //77
                    case 0x196:  //78
                    case 0x198:  //79
                    case 0x19A:  //80
                    case 0x19C:  //81
                    case 0x19E:  //82
                    case 0x1A0:  //83
                    case 0x1A2:  //84
                    case 0x1A4:  //85
                    case 0x1A6:  //86
                    case 0x1A8:  //87
                    case 0x1AA:  //88
                    case 0x1AC:  //89
                    case 0x1AE:  //90
                    case 0x1B0:  //91
                    case 0x1B2:  //92
                    case 0x1B4:  //93
                    case 0x1B6:  //94
                    case 0x1B8:  //95
                    case 0x1BA:  //96
                    case 0x1BC:  //97
                    case 0x1BE:  //98
                    case 0x1C0:  //99
                    case 0x1C2:  //100
                    case 0x1C4:  //Variable 101
                    case 0x1C6:  //102
                    case 0x1C8:  //103
                    case 0x1CA:  //104
                    case 0x1CC:  //105
                    case 0x1CE:  //106
                    case 0x1D0:  //107

                    case 0x1D4:  //109
                    case 0x1D6:  //110
                    case 0x1D8:  //111
                    case 0x1DA:  //112
                    case 0x1DC:  //Variable 113
                    case 0x1DE:  //Variable 114 (duplicate with below!!!)
                    case 0x1E0:  //Variable 115
                    case 0x1E2:  //116
                    case 0x1E4:  //117
                    case 0x1E6:  //118
                    case 0x1E8:  //119
                    case 0x1EA:  //120
                    case 0x1EC:  //121
                    case 0x1EE:  //122
                    case 0x1F0:  //123
                    case 0x1F2:  //124
                    case 0x1F4:  //125
                    case 0x1F6:  //126
                    case 0x1F8:  //Variable 127
                        {
                            Quest.instance.variables[VariableCounter++] = (int)DataLoader.getValAtAddress(buffer, i, 8);
                            break;
                        }
                    case 0x1D2:  //Variable 108 //Int 16 used in qbert
                        {
                            Quest.instance.variables[VariableCounter++] = (int)DataLoader.getValAtAddress(buffer, i, 16);
                            break;
                        }


                    //Bit Variables
                    case 0x1FA:
                    case 0x1FC:
                    case 0x1FE:
                    case 0x200:
                    case 0x202:
                    case 0x204:
                    case 0x206:
                    case 0x208:
                    case 0x20A:
                    case 0x20C:
                    case 0x20E:
                    case 0x210:
                    case 0x212:
                    case 0x214:
                    case 0x216:
                    case 0x218:
                    case 0x21A:
                    case 0x21C:
                    case 0x21E:
                    case 0x220:
                    case 0x222:
                    case 0x224:
                    case 0x226:
                    case 0x228:
                    case 0x22A:
                    case 0x22C:
                    case 0x22E:
                    case 0x230:
                    case 0x232:
                    case 0x234:
                    case 0x236:
                    case 0x238:
                    case 0x23A:
                    case 0x23C:
                    case 0x23E:
                    case 0x240:
                    case 0x242:
                    case 0x244:
                    case 0x246:
                    case 0x248:
                    case 0x24A:
                    case 0x24C:
                    case 0x24E:
                    case 0x250:
                    case 0x252:
                    case 0x254:
                    case 0x256:
                    case 0x258:
                    case 0x25A:
                    case 0x25C:
                    case 0x25E:
                    case 0x260:
                    case 0x262:
                    case 0x264:
                    case 0x266:
                    case 0x268:
                    case 0x26A:
                    case 0x26C:
                    case 0x26E:
                    case 0x270:
                    case 0x272:
                    case 0x274:
                    case 0x276:
                    case 0x278:
                    case 0x27A:
                    case 0x27C:
                    case 0x27E:
                    case 0x280:
                    case 0x282:
                    case 0x284:
                    case 0x286:
                    case 0x288:
                    case 0x28A:
                    case 0x28C:
                    case 0x28E:
                    case 0x290:
                    case 0x292:
                    case 0x294:
                    case 0x296:
                    case 0x298:
                    case 0x29A:
                    case 0x29C:
                    case 0x29E:
                    case 0x2A0:
                    case 0x2A2:
                    case 0x2A4:
                    case 0x2A6:
                    case 0x2A8:
                    case 0x2AA:
                    case 0x2AC:
                    case 0x2AE:
                    case 0x2B0:
                    case 0x2B2:
                    case 0x2B4:
                    case 0x2B6:
                    case 0x2B8:
                    case 0x2BA:
                    case 0x2BC:
                    case 0x2BE:
                    case 0x2C0:
                    case 0x2C2:
                    case 0x2C4:
                    case 0x2C6:
                    case 0x2C8:
                    case 0x2CA:
                    case 0x2CC:
                    case 0x2CE:
                    case 0x2D0:
                    case 0x2D2:
                    case 0x2D4:
                    case 0x2D6:
                    case 0x2D8:
                    case 0x2DA:
                    case 0x2DC:
                    case 0x2DE:
                    case 0x2E0:
                    case 0x2E2:
                    case 0x2E4:
                    case 0x2E6:
                    case 0x2E8:
                    case 0x2EA:
                    case 0x2EC:
                    case 0x2EE:
                    case 0x2F0:
                    case 0x2F2:
                    case 0x2F4:
                    case 0x2F6:
                    case 0x2F8://end bit variables
                        {
                            Quest.instance.BitVariables[BitVariableCounter++] = (int)DataLoader.getValAtAddress(buffer, i, 16);
                            break;
                        }
                    //Skip for bit variables
                    case 0x1FA + 1:
                    case 0x1FC + 1:
                    case 0x1FE + 1:
                    case 0x200 + 1:
                    case 0x202 + 1:
                    case 0x204 + 1:
                    case 0x206 + 1:
                    case 0x208 + 1:
                    case 0x20A + 1:
                    case 0x20C + 1:
                    case 0x20E + 1:
                    case 0x210 + 1:
                    case 0x212 + 1:
                    case 0x214 + 1:
                    case 0x216 + 1:
                    case 0x218 + 1:
                    case 0x21A + 1:
                    case 0x21C + 1:
                    case 0x21E + 1:
                    case 0x220 + 1:
                    case 0x222 + 1:
                    case 0x224 + 1:
                    case 0x226 + 1:
                    case 0x228 + 1:
                    case 0x22A + 1:
                    case 0x22C + 1:
                    case 0x22E + 1:
                    case 0x230 + 1:
                    case 0x232 + 1:
                    case 0x234 + 1:
                    case 0x236 + 1:
                    case 0x238 + 1:
                    case 0x23A + 1:
                    case 0x23C + 1:
                    case 0x23E + 1:
                    case 0x240 + 1:
                    case 0x242 + 1:
                    case 0x244 + 1:
                    case 0x246 + 1:
                    case 0x248 + 1:
                    case 0x24A + 1:
                    case 0x24C + 1:
                    case 0x24E + 1:
                    case 0x250 + 1:
                    case 0x252 + 1:
                    case 0x254 + 1:
                    case 0x256 + 1:
                    case 0x258 + 1:
                    case 0x25A + 1:
                    case 0x25C + 1:
                    case 0x25E + 1:
                    case 0x260 + 1:
                    case 0x262 + 1:
                    case 0x264 + 1:
                    case 0x266 + 1:
                    case 0x268 + 1:
                    case 0x26A + 1:
                    case 0x26C + 1:
                    case 0x26E + 1:
                    case 0x270 + 1:
                    case 0x272 + 1:
                    case 0x274 + 1:
                    case 0x276 + 1:
                    case 0x278 + 1:
                    case 0x27A + 1:
                    case 0x27C + 1:
                    case 0x27E + 1:
                    case 0x280 + 1:
                    case 0x282 + 1:
                    case 0x284 + 1:
                    case 0x286 + 1:
                    case 0x288 + 1:
                    case 0x28A + 1:
                    case 0x28C + 1:
                    case 0x28E + 1:
                    case 0x290 + 1:
                    case 0x292 + 1:
                    case 0x294 + 1:
                    case 0x296 + 1:
                    case 0x298 + 1:
                    case 0x29A + 1:
                    case 0x29C + 1:
                    case 0x29E + 1:
                    case 0x2A0 + 1:
                    case 0x2A2 + 1:
                    case 0x2A4 + 1:
                    case 0x2A6 + 1:
                    case 0x2A8 + 1:
                    case 0x2AA + 1:
                    case 0x2AC + 1:
                    case 0x2AE + 1:
                    case 0x2B0 + 1:
                    case 0x2B2 + 1:
                    case 0x2B4 + 1:
                    case 0x2B6 + 1:
                    case 0x2B8 + 1:
                    case 0x2BA + 1:
                    case 0x2BC + 1:
                    case 0x2BE + 1:
                    case 0x2C0 + 1:
                    case 0x2C2 + 1:
                    case 0x2C4 + 1:
                    case 0x2C6 + 1:
                    case 0x2C8 + 1:
                    case 0x2CA + 1:
                    case 0x2CC + 1:
                    case 0x2CE + 1:
                    case 0x2D0 + 1:
                    case 0x2D2 + 1:
                    case 0x2D4 + 1:
                    case 0x2D6 + 1:
                    case 0x2D8 + 1:
                    case 0x2DA + 1:
                    case 0x2DC + 1:
                    case 0x2DE + 1:
                    case 0x2E0 + 1:
                    case 0x2E2 + 1:
                    case 0x2E4 + 1:
                    case 0x2E6 + 1:
                    case 0x2E8 + 1:
                    case 0x2EA + 1:
                    case 0x2EC + 1:
                    case 0x2EE + 1:
                    case 0x2F0 + 1:
                    case 0x2F2 + 1:
                    case 0x2F4 + 1:
                    case 0x2F6 + 1:
                    case 0x2F8 + 1:
                        {//end skip for bit variables
                            break;
                        }   
                    case 0x2fb: ///   x-position in level
                        x_position_dream = (int)DataLoader.getValAtAddress(buffer, i, 16); break;
                    case 0x2fd: ///   y-position
                        y_position_dream = (int)DataLoader.getValAtAddress(buffer, i, 16); break;
                    case 0x301:
                        UWCharacter.Instance.DreamReturnLevel = (short)(DataLoader.getValAtAddress(buffer, i, 8) - 1); break;
                    case 0x303:
                        //{//Game options high nibble is graphic detail
                        //		int val =	(int)DataLoader.getValAtAddress(buffer,i,8);
                        //		ObjectInteraction.PlaySoundEffects= ((val & 0x1) == 1);
                        //		MusicController.PlayMusic=( ( ( val>>2 ) & 0x1 ) == 1 );
                        break;
                    //}
                    case 0x306:
                        {//Timer for paralyzed effect
                            UWCharacter.Instance.ParalyzeTimer = (short)(DataLoader.getValAtAddress(buffer, i, 8));
                            break;
                        }
                    case 0x361://Item Ids of arena warriors.
                    case 0x362:
                    case 0x363:
                    case 0x364:
                    case 0x365:
                        {
                            Quest.instance.ArenaOpponents[arena++] = (int)DataLoader.getValAtAddress(buffer, i, 8);
                            break;
                        }
                    //x_clocks
                    case 0x36a: ///   game time
                        GameClock.instance.game_time = (int)DataLoader.getValAtAddress(buffer, i, 32); break;
                    case 0x36b:
                        GameClock.instance.gametimevals[0] = (int)DataLoader.getValAtAddress(buffer, i, 8); break;
                    case 0x36c:
                        GameClock.instance.gametimevals[1] = (int)DataLoader.getValAtAddress(buffer, i, 8); break;
                    case 0x36d:
                        GameClock.instance.gametimevals[2] = (int)DataLoader.getValAtAddress(buffer, i, 8); break;
                    case 0x36f://1 Castle events
                    case 0x370://2
                    case 0x371://3 DjinnCapture
                    case 0x372://4
                    case 0x373://5
                    case 0x374://6
                    case 0x375://7
                    case 0x376://8
                    case 0x377://9
                    case 0x378://10
                    case 0x379://11
                    case 0x37a://12
                    case 0x37b://13
                    case 0x37c://14
                               //case 0x37d://15 -- This could be wrong.
                        {//The mysterious x_clocks
                            Quest.instance.x_clocks[x_clock++] = (int)DataLoader.getValAtAddress(buffer, i, 8);
                            break;
                        }
                }
            }

            ApplySpellEffects(ActiveEffectIds, ActiveEffectStability, effectCounter);

            GameClock.setUWTime(GameClock.instance.gametimevals[0] + (GameClock.instance.gametimevals[1] * 255) + (GameClock.instance.gametimevals[2] * 255 * 255));

            //InitPlayerPosition (x_position, y_position, z_position);

            ResetInventory();

            LoadInventory(buffer, 995, 931, 969);

            Vector3 DreamReturn = new Vector3((float)x_position_dream / Ratio, 0f, (float)y_position_dream / Ratio);
            UWCharacter.Instance.DreamReturnTileX = (short)(DreamReturn.x / 1.2f);
            UWCharacter.Instance.DreamReturnTileY = (short)(DreamReturn.z / 1.2f);
            UWCharacter.Instance.TeleportPosition = GameWorldController.instance.StartPos;

            return;
        }
    }



    /// <summary>
    /// Returns a save game name to use when saving.
    /// </summary>
    /// <returns>The game name.</returns>
    public static string SaveGameName(int slotNo)
    {
        if (_RES == GAME_UW2)
        {
            return "Level " + GameWorldController.instance.LevelNo + " " + System.DateTime.Now;
        }
        else
        {
            return UW1LevelName(GameWorldController.instance.LevelNo) + " " + System.DateTime.Now;
        }
    }


    static string UW1LevelName(int levelNo)
    {
        return GameWorldController.UW1_LevelNames[levelNo];
    }

    /// <summary>
    /// Loads the player name
    /// </summary>
    static void LoadName(char[] buffer)
    {
        UWCharacter.Instance.CharName = "";
        for (int i = 1; i < 14; i++)
        {
            if (buffer[i].ToString() != "\0")
            {
                UWCharacter.Instance.CharName += buffer[i];
            }
        }
    }



    /// <summary>
    /// Loads the skills from a save file for UW1 & 2
    /// </summary>
    /// <param name="buffer">Buffer.</param>
    static void LoadStats(char[] buffer)
    {
        for (int i = 1; i <= 0x3E; i++)
        {
            switch (i)
            {
                case 0x1F://Strength
                    UWCharacter.Instance.PlayerSkills.STR = (int)buffer[i];
                    GameWorldController.instance.objDat.critterStats[63].Strength = UWCharacter.Instance.PlayerSkills.STR;
                    break;
                case 0x20://Dex
                    UWCharacter.Instance.PlayerSkills.DEX = (int)buffer[i]; break;
                case 0x21: ///    Intelligence
                    UWCharacter.Instance.PlayerSkills.INT = (int)buffer[i]; break;
                case 0x22: ///    Attack
                    UWCharacter.Instance.PlayerSkills.Attack = (int)buffer[i]; break;
                case 0x23: ///    Defense
                    UWCharacter.Instance.PlayerSkills.Defense = (int)buffer[i]; break;
                case 0x24: ///    Unarmed
                    UWCharacter.Instance.PlayerSkills.Unarmed = (int)buffer[i]; break;
                case 0x25: ///    Sword
                    UWCharacter.Instance.PlayerSkills.Sword = (int)buffer[i]; break;
                case 0x26: ///    Axe
                    UWCharacter.Instance.PlayerSkills.Axe = (int)buffer[i]; break;
                case 0x27: ///    Mace
                    UWCharacter.Instance.PlayerSkills.Mace = (int)buffer[i]; break;
                case 0x28: ///    Missile
                    UWCharacter.Instance.PlayerSkills.Missile = (int)buffer[i]; break;
                case 0x29: ///    Mana
                    UWCharacter.Instance.PlayerSkills.ManaSkill = (int)buffer[i]; break;
                case 0x2A: ///    Lore
                    UWCharacter.Instance.PlayerSkills.Lore = (int)buffer[i]; break;
                case 0x2B: ///    Casting
                    UWCharacter.Instance.PlayerSkills.Casting = (int)buffer[i]; break;
                case 0x2C: ///    Traps
                    UWCharacter.Instance.PlayerSkills.Traps = (int)buffer[i]; break;
                case 0x2D: ///    Search
                    UWCharacter.Instance.PlayerSkills.Search = (int)buffer[i]; break;
                case 0x2E: ///    Track
                    UWCharacter.Instance.PlayerSkills.Track = (int)buffer[i]; break;
                case 0x2F: ///    Sneak
                    UWCharacter.Instance.PlayerSkills.Sneak = (int)buffer[i]; break;
                case 0x30: ///    Repair
                    UWCharacter.Instance.PlayerSkills.Repair = (int)buffer[i]; break;
                case 0x31: ///    Charm
                    UWCharacter.Instance.PlayerSkills.Charm = (int)buffer[i]; break;
                case 0x32: ///    Picklock
                    UWCharacter.Instance.PlayerSkills.PickLock = (int)buffer[i]; break;
                case 0x33: ///    Acrobat
                    UWCharacter.Instance.PlayerSkills.Acrobat = (int)buffer[i]; break;
                case 0x34: ///    Appraise
                    UWCharacter.Instance.PlayerSkills.Appraise = (int)buffer[i]; break;
                case 0x35: ///    Swimming
                    UWCharacter.Instance.PlayerSkills.Swimming = (int)buffer[i]; break;
                case 0x36://Curvit
                    UWCharacter.Instance.CurVIT = (int)buffer[i]; break;
                case 0x37: ///    max. vitality
                    UWCharacter.Instance.MaxVIT = (int)buffer[i]; break;
                case 0x38: ///    current mana, (play_mana)
                    UWCharacter.Instance.PlayerMagic.CurMana = (int)buffer[i]; break;
                case 0x39: ///    max. mana  (see also true max mana)
                    UWCharacter.Instance.PlayerMagic.MaxMana = (int)buffer[i]; break;
                case 0x3A: ///    hunger, play_hunger
                    UWCharacter.Instance.FoodLevel = (int)buffer[i]; break;
                case 0x3B:
                    //Unknown. Observed values 0 and 64?//Fatigue???
                    break;
                case 0x3E: ///    character level (play_level)
                    UWCharacter.Instance.CharLevel = (int)buffer[i]; break;
            }
        }
    }

    /// <summary>
    /// Inits the player position.
    /// </summary>
    /// <param name="x_position">X position.</param>
    /// <param name="y_position">Y position.</param>
    /// <param name="z_position">Z position.</param>
    static void InitPlayerPosition(int x_position, int y_position, int z_position)
    {
        GameWorldController.instance.StartPos = new Vector3((float)x_position / Ratio, (float)z_position / Ratio + VertAdjust, (float)y_position / Ratio);
    }


    static int LoadSpellEffects(char[] buffer, ref int[] ActiveEffectIds, ref short[] ActiveEffectStability)
    {
        int effectCounter = 0;
        for (int i = 0x3f; i <= 0x44; i++)
        {
            switch (i)
            {
                case 0x3F:
                case 0x41:
                case 0x43://Active spell effect
                    {
                        ActiveEffectIds[effectCounter] = SaveGame.GetActiveSpellID((int)buffer[i]); break;
                    }
                case 0x3F + 1:
                case 0x41 + 1:
                case 0x43 + 1://Active spell effect stability
                    {
                        ActiveEffectStability[effectCounter++] = (short)buffer[i]; break;
                    }
            }
        }
        return effectCounter;
    }

    /// <summary>
    /// Loads the runes that the player has in their rune bag
    /// </summary>
    /// <param name="buffer">Buffer.</param>
    /// <param name="StartOffset">Start offset.</param>
    static void LoadRunes(char[] buffer)
    {
        int StartOffset = 0x45;
        int runeOffset = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int r = 7; r >= 0; r--)
            {
                if (((buffer[StartOffset + i] >> r) & 0x1) == 1)
                {
                    UWCharacter.Instance.PlayerMagic.PlayerRunes[7 - r + runeOffset] = true;
                }
                else
                {
                    UWCharacter.Instance.PlayerMagic.PlayerRunes[7 - r + runeOffset] = false;
                }
            }
            runeOffset += 8;
        }

        SetActiveRuneSlots(0, (int)buffer[0x48]);
        SetActiveRuneSlots(1, (int)buffer[0x49]);
        SetActiveRuneSlots(2, (int)buffer[0x4A]);
    }

    /// <summary>
    /// Loads the player class.
    /// </summary>
    /// <param name="buffer">Buffer.</param>
    /// <param name="i">The index.</param>
    static void LoadPlayerClass(char[] buffer, int i)
    {
        //bit 1 = hand left/right
        //bit 2-5 = gender & body
        //bit 6-8 = class
        GRLoader chrBdy = new GRLoader(GRLoader.BODIES_GR);
        UWCharacter.Instance.isLefty = (((int)buffer[i] & 0x1) == 0);
        int bodyval = ((int)buffer[i] >> 1) & 0xf;
        if (bodyval % 2 == 0)
        {
            //male 0,2,4,6,8
            UWCharacter.Instance.isFemale = false;
            //Body
            UWCharacter.Instance.Body = bodyval / 2;
            UWHUD.instance.playerBody.texture = chrBdy.LoadImageAt(0 + (bodyval / 2));
        }
        else
        {
            //female=1,3,5,7,9
            UWCharacter.Instance.isFemale = true;
            UWCharacter.Instance.Body = (bodyval - 1) / 2;
            UWHUD.instance.playerBody.texture = chrBdy.LoadImageAt(5 + ((bodyval - 1) / 2));
        }
        //class
        UWCharacter.Instance.CharClass = buffer[i] >> 5;
    }

    /// <summary>
    /// Loads the game options.
    /// </summary>
    /// <param name="buffer">Buffer.</param>
    /// <param name="i">The index.</param>
    static void LoadGameOptions(char[] buffer, int i)
    {
        int val = (int)DataLoader.getValAtAddress(buffer, i, 8);
        ObjectInteraction.PlaySoundEffects = ((val & 0x1) == 1);
        MusicController.PlayMusic = (((val >> 2) & 0x1) == 1);
        GameWorldController.instance.difficulty = (int)DataLoader.getValAtAddress(buffer, i-1, 8) & 0x1;
    }

    /// <summary>
    /// Applies the spell effects.
    /// </summary>
    /// <param name="ActiveEffectIds">Active effect identifiers.</param>
    /// <param name="ActiveEffectStability">Active effect stability.</param>
    /// <param name="effectCounter">Effect counter.</param>
    static void ApplySpellEffects(int[] ActiveEffectIds, short[] ActiveEffectStability, int effectCounter)
    {
        for (int a = 0; a <= UWCharacter.Instance.ActiveSpell.GetUpperBound(0); a++)
        {
            //Clear out the old effects.
            if (UWCharacter.Instance.ActiveSpell[a] != null)
            {
                UWCharacter.Instance.ActiveSpell[a].CancelEffect();
                if (UWCharacter.Instance.ActiveSpell[a] != null)
                {
                    //The prevous effect had cancelled into anew effect. Eg fly->slowfall. Cancel again.
                    UWCharacter.Instance.ActiveSpell[a].CancelEffect();
                }
            }
        }
        //Clearout the passive spell effects
        for (int a = 0; a <= UWCharacter.Instance.PassiveSpell.GetUpperBound(0); a++)
        {
            //Clear out the old passive effects.
            if (UWCharacter.Instance.PassiveSpell[a] != null)
            {
                UWCharacter.Instance.PassiveSpell[a].CancelEffect();
                if (UWCharacter.Instance.PassiveSpell[a] != null)
                {
                    //The prevous effect had cancelled into anew effect. Eg fly->slowfall. Cancel again.
                    UWCharacter.Instance.PassiveSpell[a].CancelEffect();
                }
            }
        }
        for (int a = 0; a < effectCounter; a++)
        {
            //Recast the new ones.
            UWCharacter.Instance.ActiveSpell[a] = UWCharacter.Instance.PlayerMagic.CastEnchantment(UWCharacter.Instance.gameObject, null, ActiveEffectIds[a], Magic.SpellRule_TargetSelf, Magic.SpellRule_Consumable);
            if (UWCharacter.Instance.ActiveSpell[a] != null)
            {
                UWCharacter.Instance.ActiveSpell[a].counter = ActiveEffectStability[a];
            }
        }
    }

    /// <summary>
    /// Resets the inventory.
    /// </summary>
    static void ResetInventory()
    {
        UWCharacter.Instance.playerInventory.sHelm = null;
        UWCharacter.Instance.playerInventory.sChest = null;
        UWCharacter.Instance.playerInventory.sGloves = null;
        UWCharacter.Instance.playerInventory.sLegs = null;
        UWCharacter.Instance.playerInventory.sBoots = null;
        UWCharacter.Instance.playerInventory.sRightShoulder = null;
        UWCharacter.Instance.playerInventory.sLeftShoulder = null;
        UWCharacter.Instance.playerInventory.sRightHand = null;
        UWCharacter.Instance.playerInventory.sLeftHand = null;
        UWCharacter.Instance.playerInventory.sRightRing = null;
        UWCharacter.Instance.playerInventory.sLeftRing = null;
        for (int c = 0; c <= UWCharacter.Instance.playerInventory.playerContainer.items.GetUpperBound(0); c++)
        {
            UWCharacter.Instance.playerInventory.playerContainer.items[c] = null;
        }
        foreach (Transform child in GameWorldController.instance.InventoryMarker.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    /// <summary>
    /// Loads the inventory.
    /// </summary>
    /// <param name="buffer">Buffer.</param>
    /// <param name="StartOffset">Start offset.</param>
    /// <param name="lBoundSlots">L bound slots.</param>
    /// <param name="uBoundSlots">U bound slots.</param>
    static void LoadInventory(char[] buffer, int StartOffset, int lBoundSlots, int uBoundSlots)
    {
        //Start offset  is 312 for uw1
        //lBoundSlots=248; uBoundSlots < 286
        //Read in the inventory
        //Stored in much the same way as an linked object list is.
        //Inventory list
        int NoOfItems = (buffer.GetUpperBound(0) - StartOffset) / 8;

        GameWorldController.instance.inventoryLoader.objInfo = new ObjectLoaderInfo[NoOfItems+2];   //+ 2];
        int x = 1;

        //InventoryData = new char[768 * 8];
        //if (buffer.GetUpperBound(0) >= StartOffset)
        //{//Copy the inventory data buffer into memory. Inventory object data will be manipulated here.
        //    int i = StartOffset;            
        //    while (i < buffer.GetUpperBound(0))
        //    {
        //        InventoryData[i - StartOffset] = buffer[i];
        //        i++;
        //    }
        //}
        int Add_ptr = StartOffset;
        ///Initialise as many inventory objects as needed
        if (buffer.GetUpperBound(0) >= StartOffset)
        {
            for (x = 1; x <= GameWorldController.instance.inventoryLoader.objInfo.GetUpperBound(0);x++)
            {
                GameWorldController.instance.inventoryLoader.objInfo[x] = new ObjectLoaderInfo(x, GameWorldController.CurrentTileMap(),false);//Inventory indices start at 1
                GameWorldController.instance.inventoryLoader.objInfo[x].parentList = GameWorldController.instance.inventoryLoader;
                GameWorldController.instance.inventoryLoader.objInfo[x].ObjectTileX = TileMap.ObjectStorageTile;
                GameWorldController.instance.inventoryLoader.objInfo[x].ObjectTileY = TileMap.ObjectStorageTile;
                GameWorldController.instance.inventoryLoader.objInfo[x].InUseFlag = 1;

                GameWorldController.instance.inventoryLoader.objInfo[x].InventoryData = new char[8];
                for (int i = 0; i<8;i++)
                {//Copy data into the local objectloader buffer for the inventory object.
                    GameWorldController.instance.inventoryLoader.objInfo[x].InventoryData[i] = buffer[Add_ptr + i];
                }
                Add_ptr += 8;
            }

            //Create the inventory objects
            ObjectLoader.RenderObjectList(GameWorldController.instance.inventoryLoader, CurrentTileMap(), GameWorldController.instance.InventoryMarker);
            ObjectLoader.LinkObjectListWands(GameWorldController.instance.inventoryLoader);
            ObjectLoader.LinkObjectListPotions(GameWorldController.instance.inventoryLoader);
            for (int j = lBoundSlots; j < uBoundSlots; j = j + 2)
            {
                //Apply objects to slots
                int index = ((int)DataLoader.getValAtAddress(buffer, j, 16) >> 6);
                ObjectInteraction item; 
                if (index != 0)
                {
                    item = GameWorldController.instance.inventoryLoader.objInfo[index].instance;
                }
                else
                {
                    item = null;
                }

                switch ((InventorySlotsOffsets)(j))
                {
                    case InventorySlotsOffsets.UW1Helm:
                    case InventorySlotsOffsets.UW2Helm:
                        //Helm
                        UWCharacter.Instance.playerInventory.sHelm = item;
                        break;
                    //case 250:
                    case InventorySlotsOffsets.UW1Chest:
                    case InventorySlotsOffsets.UW2Chest:
                        //Chest
                        UWCharacter.Instance.playerInventory.sChest = item;
                        break;
                    //case 252:
                    case InventorySlotsOffsets.UW1Gloves:
                    case InventorySlotsOffsets.UW2Gloves:
                        //gloves
                        UWCharacter.Instance.playerInventory.sGloves = item;
                        break;
                    //case 254:
                    case InventorySlotsOffsets.UW1Leggings:
                    case InventorySlotsOffsets.UW2Leggings:
                        //Leggings
                        UWCharacter.Instance.playerInventory.sLegs = item;
                        break;
                    //case 256:
                    case InventorySlotsOffsets.UW1Boots:
                    case InventorySlotsOffsets.UW2Boots:
                        //boots
                        UWCharacter.Instance.playerInventory.sBoots = item;
                        break;
                    //case 258:
                    case InventorySlotsOffsets.UW1RightShoulder:
                    case InventorySlotsOffsets.UW2RightShoulder:
                        //  is the top right shoulder.
                        UWCharacter.Instance.playerInventory.sRightShoulder = item;
                        break;
                    //case 260:
                    case InventorySlotsOffsets.UW1LeftShoulder:
                    case InventorySlotsOffsets.UW2LeftShoulder:
                        // is the top left shoulder.
                        UWCharacter.Instance.playerInventory.sLeftShoulder = item;
                        break;
                    //case 262:
                    case InventorySlotsOffsets.UW1RightHand:
                    case InventorySlotsOffsets.UW2RightHand:
                        //  is the right hand.
                        UWCharacter.Instance.playerInventory.sRightHand = item;
                        break;
                    //case 264:
                    case InventorySlotsOffsets.UW1LeftHand:
                    case InventorySlotsOffsets.UW2LeftHand:
                        //  is the left hand.
                        UWCharacter.Instance.playerInventory.sLeftHand = item;
                        break;
                    //case 266:
                    case InventorySlotsOffsets.UW1RightRing:
                    case InventorySlotsOffsets.UW2RightRing:
                        //  is the right ring.
                        UWCharacter.Instance.playerInventory.sRightRing = item;
                        break;
                    //case 268:
                    case InventorySlotsOffsets.UW1LeftRing:
                    case InventorySlotsOffsets.UW2LeftRing:
                        //  is the left ring .
                        UWCharacter.Instance.playerInventory.sLeftRing = item;
                        break;
                    //case 270:
                    case InventorySlotsOffsets.UW1Backpack0:
                    case InventorySlotsOffsets.UW2Backpack0:
                        //  is the backpack slots 1.
                        UWCharacter.Instance.playerInventory.playerContainer.items[0] = item;
                        break;
                    case InventorySlotsOffsets.UW1Backpack1:
                    case InventorySlotsOffsets.UW2Backpack1:
                        //  is the backpack slots 2.
                        UWCharacter.Instance.playerInventory.playerContainer.items[1] = item;
                        break;
                    case InventorySlotsOffsets.UW1Backpack2:
                    case InventorySlotsOffsets.UW2Backpack2:
                        //  is the backpack slots 3.
                        UWCharacter.Instance.playerInventory.playerContainer.items[2] = item;
                        break;
                    case InventorySlotsOffsets.UW1Backpack3:
                    case InventorySlotsOffsets.UW2Backpack3:
                        //  is the backpack slots 4.
                        UWCharacter.Instance.playerInventory.playerContainer.items[3] = item;
                        break;
                    case InventorySlotsOffsets.UW1Backpack4:
                    case InventorySlotsOffsets.UW2Backpack4:
                        //  is the backpack slots 5.
                        UWCharacter.Instance.playerInventory.playerContainer.items[4] = item;
                        break;
                    case InventorySlotsOffsets.UW1Backpack5:
                    case InventorySlotsOffsets.UW2Backpack5:
                        //  is the backpack slots 6.
                        UWCharacter.Instance.playerInventory.playerContainer.items[5] = item;
                        break;
                    case InventorySlotsOffsets.UW1Backpack6:
                    case InventorySlotsOffsets.UW2Backpack6:
                        //  is the backpack slots 7.
                        UWCharacter.Instance.playerInventory.playerContainer.items[6] = item;
                        break;
                    case InventorySlotsOffsets.UW1Backpack7:
                    case InventorySlotsOffsets.UW2Backpack7:
                        //  is the backpack slots 8.
                        UWCharacter.Instance.playerInventory.playerContainer.items[7] = item;
                        break;
                }
            }
            UWCharacter.Instance.playerInventory.Refresh();
            //Reapply effects from enchanted items by recalling the equip event.
            for (short s = 0; s <= 10; s++)
            {
                ObjectInteraction obj = UWCharacter.Instance.playerInventory.GetObjectIntAtSlot(s);
                if (obj != null)
                {
                    obj.Equip(s);
                }
            }
        }
    }


    /// <summary>
    /// Re-initialise the UI when loading a new game.
    /// </summary>
    static void ResetUI()
    {
        UWCharacter.Instance.playerInventory.currentContainer = UWCharacter.Instance.playerInventory.playerContainer; // "_Gronk";
        UWHUD.instance.ContainerOpened.GetComponent<RawImage>().texture = UWCharacter.Instance.playerInventory.Blank;
        UWHUD.instance.ContainerOpened.GetComponent<ContainerOpened>().BackpackBg.SetActive(false);
        UWHUD.instance.ContainerOpened.GetComponent<ContainerOpened>().InvUp.SetActive(false);
        UWHUD.instance.ContainerOpened.GetComponent<ContainerOpened>().InvDown.SetActive(false);
        UWCharacter.Instance.playerInventory.ContainerOffset = 0;
    }


    /// <summary>
    /// Writes the inventory to a save file
    /// </summary>
    /// <param name="writer">Writer.</param>
    /// <param name="inventoryObjects">Inventory objects.</param>
    static void WriteInventory(BinaryWriter writer, string[] inventoryObjects)
    {
        for (int o = 0; o <= inventoryObjects.GetUpperBound(0); o++)
        {
            GameObject obj = GameObject.Find(inventoryObjects[o]);
            if (obj != null)
            {
                ObjectInteraction currobj = obj.GetComponent<ObjectInteraction>();
                if (currobj.GetItemType() == ObjectInteraction.WAND)
                {
                    if (currobj.GetComponent<Wand>() != null)
                    {
                        if (currobj.GetComponent<Wand>().linkedspell != null)
                        {
                            //This is a wand with a linked spell object.
                            string link = currobj.GetComponent<Wand>().linkedspell.name;
                            //For the index of the linked object in the list
                            for (int z = 0; z <= inventoryObjects.GetUpperBound(0); z++)
                            {
                                if (link == inventoryObjects[z])
                                {
                                    currobj.link = z + 1;
                                    break;
                                }
                            }
                        }
                    }
                    if (currobj.GetComponent<Potion>() != null)
                    {
                        if (currobj.GetComponent<Potion>().linked != null)
                        {
                            //This is a potion with a linked spell object.
                            string link = currobj.GetComponent<Potion>().linked.name;
                            //For the index of the linked object in the list
                            for (int z = 0; z <= inventoryObjects.GetUpperBound(0); z++)
                            {
                                if (link == inventoryObjects[z])
                                {
                                    currobj.link = z + 1;
                                    break;
                                }
                            }
                        }
                    }
                }
                int ByteToWrite = (currobj.isquant << 15) | (currobj.invis << 14) | (currobj.doordir << 13) | (currobj.enchantment << 12) | ((currobj.flags & 0x07) << 9) | (currobj.item_id & 0x1FF);
                DataLoader.WriteInt8(writer, (ByteToWrite & 0xFF));
                DataLoader.WriteInt8(writer, ((ByteToWrite >> 8) & 0xFF));
                ByteToWrite = ((currobj.xpos & 0x7) << 13) | ((currobj.ypos & 0x7) << 10) | ((currobj.heading & 0x7) << 7) | ((currobj.zpos & 0x7F));
                DataLoader.WriteInt8(writer, (ByteToWrite & 0xFF));
                DataLoader.WriteInt8(writer, ((ByteToWrite >> 8) & 0xFF));
                ByteToWrite = (((int)currobj.next & 0x3FF) << 6) | (currobj.quality & 0x3F);
                DataLoader.WriteInt8(writer, (ByteToWrite & 0xFF));
                DataLoader.WriteInt8(writer, ((ByteToWrite >> 8) & 0xFF));
                ByteToWrite = ((currobj.link & 0x3FF) << 6) | (currobj.owner & 0x3F);
                DataLoader.WriteInt8(writer, (ByteToWrite & 0xFF));
                DataLoader.WriteInt8(writer, ((ByteToWrite >> 8) & 0xFF));
            }
        }
    }

    /// <summary>
    /// Writes the player name to a save file
    /// </summary>
    /// <param name="writer">Writer.</param>
    static void WriteName(BinaryWriter writer)
    {
        for (int i = 1; i < 14; i++)
        {
            if (i - 1 < UWCharacter.Instance.CharName.Length)
            {
                char alpha = UWCharacter.Instance.CharName.ToCharArray()[i - 1];
                DataLoader.WriteInt8(writer, (int)alpha);
            }
            else
            {
                DataLoader.WriteInt8(writer, 0);
            }
        }
    }


    static void WriteSkills(BinaryWriter writer)
    {
        for (int i = 0x1F; i <= 0x3E; i++)
        {
            switch (i)
            {
                case 0x1F://Strength
                    DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.STR); break;
                case 0x20://Dex
                    DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.DEX); break;
                case 0x21: ///    Intelligence
                    DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.INT); break;
                case 0x22: ///    Attack
                    DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.Attack); break;
                case 0x23: ///    Defense
                    DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.Defense); break;
                case 0x24: ///    Unarmed
                    DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.Unarmed); break;
                case 0x25: ///    Sword
                    DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.Sword); break;
                case 0x26: ///    Axe
                    DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.Axe); break;
                case 0x27: ///    Mace
                    DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.Mace); break;
                case 0x28: ///    Missile
                    DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.Missile); break;
                case 0x29: ///    Mana
                    DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.ManaSkill); break;
                case 0x2A: ///    Lore
                    DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.Lore); break;
                case 0x2B: ///    Casting
                    DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.Casting); break;
                case 0x2C: ///    Traps
                    DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.Traps); break;
                case 0x2D: ///    Search
                    DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.Search); break;
                case 0x2E: ///    Track
                    DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.Track); break;
                case 0x2F: ///    Sneak
                    DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.Sneak); break;
                case 0x30: ///    Repair
                    DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.Repair); break;
                case 0x31: ///    Charm
                    DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.Charm); break;
                case 0x32: ///    Picklock
                    DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.PickLock); break;
                case 0x33: ///    Acrobat
                    DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.Acrobat); break;
                case 0x34: ///    Appraise
                    DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.Appraise); break;
                case 0x35: ///    Swimming
                    DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.Swimming); break;
                case 0x36://Curvit
                    DataLoader.WriteInt8(writer, UWCharacter.Instance.CurVIT); break;
                case 0x37: ///    max. vitality
                    DataLoader.WriteInt8(writer, UWCharacter.Instance.MaxVIT); break;
                case 0x38: ///    current mana, (play_mana)
                    DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerMagic.CurMana); break;
                case 0x39: ///    max. mana
                    DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerMagic.MaxMana); break;
                case 0x3A: ///    hunger, play_hunger
                    DataLoader.WriteInt8(writer, UWCharacter.Instance.FoodLevel); break;
                case 0x3B://Unknown s
                case 0x3C:
                    DataLoader.WriteInt8(writer, 64); break;
                case 0x3D:  //unknown?
                    DataLoader.WriteInt8(writer, 0); break;
                case 0x3E: ///    character level (play_level)
                    DataLoader.WriteInt8(writer, UWCharacter.Instance.CharLevel); break;
                default:
                    DataLoader.WriteInt8(writer, 0);
                    Debug.Log("THis should not happen. Writeskills  " + i);
                    break;
            }
        }
    }


    static void WriteSpace(BinaryWriter writer, int noOfSpaces)
    {
        for (int i = 0; i < noOfSpaces; i++)
        {
            DataLoader.WriteInt8(writer, 0);
        }
    }


    /// <summary>
    /// Writes the runes back to the player.dat
    /// </summary>
    /// <param name="writer">Writer.</param>
    static void WriteRunes(BinaryWriter writer)
    {

        int runeOffset = 0;
        for (int i = 0; i < 3; i++)
        {
            int RuneByte = 0;
            for (int r = 7; r >= 0; r--)
            {
                if (UWCharacter.Instance.PlayerMagic.PlayerRunes[7 - r + runeOffset] == true)
                {
                    RuneByte |= (1 << r);
                }
            }

            DataLoader.WriteInt8(writer, RuneByte);
            runeOffset += 8;
        }


        for (int i = 0; i < 3; i++)
        {
            if (UWCharacter.Instance.PlayerMagic.ActiveRunes[i] == -1)
            {
                DataLoader.WriteInt8(writer, 24);   //no rune.
            }
            else
            {
                DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerMagic.ActiveRunes[i]);
            }
        }
    }

    /// <summary>
    /// Writes the spell effects back to player.dat
    /// </summary>
    /// <returns>The spell effects.</returns>
    /// <param name="writer">Writer.</param>
    static int WriteSpellEffects(BinaryWriter writer)
    {
        int NoOfActiveEffects = 0;
        for (int e = 0; e < 3; e++)
        {
            if (UWCharacter.Instance.ActiveSpell[e] != null)
            {
                int effectId = 0;
                int byteToWrite = 0;

                switch (UWCharacter.Instance.ActiveSpell[e].EffectID)
                {//Fix spell effects that do not work with the nibble swap //TODO:check if the right effect ids are in use
                    case SpellEffect.UW1_Spell_Effect_Speed:
                        effectId = 178; break;
                    case SpellEffect.UW1_Spell_Effect_Telekinesis:
                        effectId = 179; break;
                    case SpellEffect.UW1_Spell_Effect_FreezeTime:
                        effectId = 176; break;
                    case SpellEffect.UW1_Spell_Effect_RoamingSight://Should not appear in a save game
                        effectId = 183; break;
                    default:
                        effectId = UWCharacter.Instance.ActiveSpell[e].EffectID;
                        break;
                }
                int stability = UWCharacter.Instance.ActiveSpell[e].counter;
                byteToWrite = (stability << 8) | ((effectId & 0xf0) >> 4) | ((effectId & 0xf) << 4);
                DataLoader.WriteInt16(writer, byteToWrite);
                NoOfActiveEffects++;
            }
            else
            {//No effect leave empty
                DataLoader.WriteInt16(writer, 0);
            }

        }
        return NoOfActiveEffects;
    }

    /// <summary>
    /// Writes the player class to file
    /// </summary>
    /// <param name="writer">Writer.</param>
    static void WritePlayerClass(BinaryWriter writer)
    {
        //bit 1 = hand left/right
        //bit 2-5 = gender & body
        //bit 6-8 = class
        int val = 0;
        if (!UWCharacter.Instance.isLefty)
        {
            val |= 1;
        }
        if (UWCharacter.Instance.isFemale)
        {
            val |= ((UWCharacter.Instance.Body * 2) + 1) << 1;
        }
        else
        {
            val |= ((UWCharacter.Instance.Body * 2)) << 1;
        }
        val |= UWCharacter.Instance.CharClass << 5;
        DataLoader.WriteInt8(writer, val);
    }

    /// <summary>
    /// Writes the Uw1 quest flags to file
    /// </summary>
    /// <param name="writer">Writer.</param>
    static void WriteUW1QuestFlags(BinaryWriter writer)
    {
        int val = 0;
        for (int b = 0; b < 32; b++)
        {
            val |= (Quest.instance.QuestVariables[b] & 0x1) << b;
        }
        DataLoader.WriteInt32(writer, val);
    }

    /// <summary>
    /// Writes the game options to file
    /// </summary>
    /// <param name="writer">Writer.</param>
    static void WriteGameOptions(BinaryWriter writer)
    {
        int valToWrite = 0x30;
        //High detail	
        if (ObjectInteraction.PlaySoundEffects)
        {
            valToWrite = valToWrite | 0x1;
        }
        if (MusicController.PlayMusic)
        {
            valToWrite = valToWrite | 0x4;
        }
        DataLoader.WriteInt8(writer, valToWrite);
    }


    /// <summary>
    /// Loads the position from player.dat
    /// </summary>
    /// <param name="buffer">Buffer.</param>
    static void LoadPosition(char[] buffer)
    {
        //   x-position in level
        int x_position = (int)DataLoader.getValAtAddress(buffer, 0x55, 16);
        //   y-position
        int y_position = (int)DataLoader.getValAtAddress(buffer, 0x57, 16);
        //   z-position
        int z_position = (int)DataLoader.getValAtAddress(buffer, 0x59, 16);
        float heading = (float)DataLoader.getValAtAddress(buffer, 0x5c, 8);
        Debug.Log("Player heading is " + heading);
        UWCharacter.Instance.transform.eulerAngles = new Vector3(0f, heading * (360f / 255f), 0f);
        UWCharacter.Instance.playerCam.transform.localRotation = Quaternion.identity;
        GameWorldController.instance.startLevel = (short)(DataLoader.getValAtAddress(buffer, 0x5d, 16) - 1);
        InitPlayerPosition(x_position, y_position, z_position);
    }


    /// <summary>
    /// Writes the players position to player.dat
    /// </summary>
    /// <param name="writer">Writer.</param>
    static void WritePosition(BinaryWriter writer)
    {
        DataLoader.WriteInt16(writer, (int)(UWCharacter.Instance.transform.position.x * Ratio));
        DataLoader.WriteInt16(writer, (int)(UWCharacter.Instance.transform.position.z * Ratio));
        DataLoader.WriteInt16(writer, (int)((UWCharacter.Instance.transform.position.y - VertAdjust) * (Ratio)));
        DataLoader.WriteInt8(writer, 0);
        // DataLoader.WriteInt8(writer, (int)(UWCharacter.Instance.transform.eulerAngles.y * (255f / 360f)));
        DataLoader.WriteInt8(writer, (int)(UWCharacter.Instance.HeadingFull));
        DataLoader.WriteInt8(writer, GameWorldController.instance.LevelNo + 1);
    }









    /***************/
    /// <summary>
    /// Writes the player dat file based on the current character
    /// </summary>
    /// <param name="slotNo">Slot no.</param>
    public static void WritePlayerDatOriginal(int slotNo)
    {
        //float Ratio=213f;
        //float VertAdjust = 0.3543672f;

        //****Hardcoded values
        //	int[] hardcoded = {
        //		16,	16,	16,	16,	16,	240,	240,	240,	240,	240,	240,	16,	16,	16,	16,	16,	48,	48,	48,	48,	48,	37,	24,	16,	16,	16,	16,	143,	112,	112,	112,	112,	16,	16,	16,	16,	16,	48,	48,	48,	48,	48,	48,	16,	16,	16,	50,	33,	251,	241,	118,	122,	2,	160,	227,	22,	137,	140,	143,	0,	34,	0,	0,	0,	48,	0,	0,	0,	0,	0,	0,	0,	0,	44,	32,	128,	0,	0,	253,	0,	0,	0,	0,	0,	0,	0,	0
        //};


        FileStream file = File.Open(Loader.BasePath + "SAVE" + slotNo + sep + "playertmp.dat", FileMode.Create);
        BinaryWriter writer = new BinaryWriter(file);
        int NoOfActiveEffects = 0;
        int runeOffset = 0;

        //update inventory linking
        int NoOfInventoryItems = 0;
        string[] inventoryObjects = ObjectLoader.UpdateInventoryObjectList(out NoOfInventoryItems);

        //Write the XOR Key
        DataLoader.WriteInt8(writer, UWCharacter.Instance.XorKey);
        //I'm lazy. I'm going to write a temp file and then re-encode using the key.
        for (int i = 1; i < 312; i++)
        {//non inventory data 

            if (i < 14)
            {
                if (i - 1 < UWCharacter.Instance.CharName.Length)
                {
                    char alpha = UWCharacter.Instance.CharName.ToCharArray()[i - 1];
                    DataLoader.WriteInt8(writer, (int)alpha);
                }
                else
                {
                    DataLoader.WriteInt8(writer, 0);
                }
            }
            else
            {

                switch (i)
                {
                    case 0x1F://Strength
                        DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.STR); break;
                    case 0x20://Dex
                        DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.DEX); break;
                    case 0x21: ///    Intelligence
                        DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.INT); break;
                    case 0x22: ///    Attack
                        DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.Attack); break;
                    case 0x23: ///    Defense
                        DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.Defense); break;
                    case 0x24: ///    Unarmed
                        DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.Unarmed); break;
                    case 0x25: ///    Sword
                        DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.Sword); break;
                    case 0x26: ///    Axe
                        DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.Axe); break;
                    case 0x27: ///    Mace
                        DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.Mace); break;
                    case 0x28: ///    Missile
                        DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.Missile); break;
                    case 0x29: ///    Mana
                        DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.ManaSkill); break;
                    case 0x2A: ///    Lore
                        DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.Lore); break;
                    case 0x2B: ///    Casting
                        DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.Casting); break;
                    case 0x2C: ///    Traps
                        DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.Traps); break;
                    case 0x2D: ///    Search
                        DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.Search); break;
                    case 0x2E: ///    Track
                        DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.Track); break;
                    case 0x2F: ///    Sneak
                        DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.Sneak); break;
                    case 0x30: ///    Repair
                        DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.Repair); break;
                    case 0x31: ///    Charm
                        DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.Charm); break;
                    case 0x32: ///    Picklock
                        DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.PickLock); break;
                    case 0x33: ///    Acrobat
                        DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.Acrobat); break;
                    case 0x34: ///    Appraise
                        DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.Appraise); break;
                    case 0x35: ///    Swimming
                        DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerSkills.Swimming); break;
                    case 0x36://Curvit
                        DataLoader.WriteInt8(writer, UWCharacter.Instance.CurVIT); break;
                    case 0x37: ///    max. vitality
                        DataLoader.WriteInt8(writer, UWCharacter.Instance.MaxVIT); break;
                    case 0x38: ///    current mana, (play_mana)
                        DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerMagic.CurMana); break;
                    case 0x39: ///    max. mana
                        DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerMagic.MaxMana); break;
                    case 0x3A: ///    hunger, play_hunger
                        DataLoader.WriteInt8(writer, UWCharacter.Instance.FoodLevel); break;

                    case 0x3B://Unknown s
                    case 0x3C:
                        DataLoader.WriteInt8(writer, 64); break;
                    case 0x3E: ///    character level (play_level)
                        DataLoader.WriteInt8(writer, UWCharacter.Instance.CharLevel); break;
                    case 0x3F:
                        //Active spell effect
                        {
                            for (int e = 0; e < 3; e++)
                            {
                                if (UWCharacter.Instance.ActiveSpell[e] != null)
                                {
                                    int effectId = 0;
                                    int byteToWrite = 0;

                                    switch (UWCharacter.Instance.ActiveSpell[e].EffectID)
                                    {//Fix spell effects that do not work with the nibble swap 
                                        case SpellEffect.UW1_Spell_Effect_Speed:
                                            effectId = 178; break;
                                        case SpellEffect.UW1_Spell_Effect_Telekinesis:
                                            effectId = 179; break;
                                        case SpellEffect.UW1_Spell_Effect_FreezeTime:
                                            effectId = 176; break;
                                        case SpellEffect.UW1_Spell_Effect_RoamingSight://Should not appear in a save game
                                            effectId = 183; break;
                                        default:
                                            effectId = UWCharacter.Instance.ActiveSpell[e].EffectID;
                                            break;
                                    }
                                    int stability = UWCharacter.Instance.ActiveSpell[e].counter;
                                    byteToWrite = (stability << 8) | ((effectId & 0xf0) >> 4) | ((effectId & 0xf) << 4);

                                    //int effectID= ((val & 0xf)<<4) | ((val & 0xf0) >> 4*/

                                    DataLoader.WriteInt16(writer, byteToWrite);
                                    NoOfActiveEffects++;
                                }
                                else
                                {//No effect leave empty
                                    DataLoader.WriteInt16(writer, 0);
                                }

                            }
                            break;
                        }

                    case 0x41:
                    case 0x43:
                    case 0x3F + 1:
                    case 0x41 + 1:
                    case 0x43 + 1://Active spell effect. Addl. byte do nothing here.
                        break;
                    case 0x45://Runebits
                    case 0x46://Runebits
                    case 0x47://Runebits
                        {
                            int RuneByte = 0;
                            for (int r = 7; r >= 0; r--)
                            {
                                if (UWCharacter.Instance.PlayerMagic.PlayerRunes[7 - r + runeOffset] == true)
                                {
                                    RuneByte |= (1 << r);
                                }
                            }
                            DataLoader.WriteInt8(writer, RuneByte);
                            runeOffset += 8;
                            break;
                        }
                    case 0x48:
                        if (UWCharacter.Instance.PlayerMagic.ActiveRunes[0] == -1)
                        {
                            DataLoader.WriteInt8(writer, 24);
                        }
                        else
                        {
                            DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerMagic.ActiveRunes[0]);
                        }
                        break;
                    case 0x49:
                        if (UWCharacter.Instance.PlayerMagic.ActiveRunes[1] == -1)
                        {
                            DataLoader.WriteInt8(writer, 24);
                        }
                        else
                        {
                            DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerMagic.ActiveRunes[1]);
                        }
                        break;
                    case 0x4A:
                        if (UWCharacter.Instance.PlayerMagic.ActiveRunes[2] == -1)
                        {
                            DataLoader.WriteInt8(writer, 24);
                        }
                        else
                        {
                            DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerMagic.ActiveRunes[2]);
                        }
                        break;
                    case 0x4B:
                        {//No of inventory items?
                            DataLoader.WriteInt8(writer, (inventoryObjects.GetUpperBound(0) + 1) << 2);
                            break;
                        }

                    case 0x4D: ///   weight in 0.1 stones
                        //Or STR * 2; 
                        DataLoader.WriteInt16(writer, UWCharacter.Instance.PlayerSkills.STR * 2 * 10);
                        break;
                    case 0x4D + 1://2nd Byte of weight. Ignore
                        break;
                    case 0x4F: ///   experience in 0.1 points
                        DataLoader.WriteInt32(writer, UWCharacter.Instance.EXP); break;
                    case 0x4F + 1:
                    case 0x4F + 2:
                    case 0x4F + 3:
                        break;
                    case 0x53: // skillpoints available to spend
                        DataLoader.WriteInt8(writer, UWCharacter.Instance.TrainingPoints); break;
                    case 0x55: ///   x-position in level
                        int x_position = (int)(UWCharacter.Instance.transform.position.x * Ratio);
                        DataLoader.WriteInt16(writer, x_position);
                        break;
                    case 0x57: ///   y-position
                        int y_position = (int)(UWCharacter.Instance.transform.position.z * Ratio);
                        DataLoader.WriteInt16(writer, y_position);
                        break;
                    case 0x59: ///   z-position
                        int z_position = (int)((UWCharacter.Instance.transform.position.y - VertAdjust) * (Ratio));
                        DataLoader.WriteInt16(writer, z_position);
                        break;
                    case 0x55 + 1: ///   x-position in level
                    case 0x57 + 1: ///   y-position
                    case 0x59 + 1: ///   z-position
                        //Skip over int 16
                        break;
                    case 0x5C: ///   heading
                        {
                            //float heading = UWCharacter.Instance.transform.eulerAngles.y * (255f / 360f);
                            DataLoader.WriteInt8(writer, UWCharacter.Instance.HeadingFull); break;
                            //break;
                        }
                    case 0x5D: ///   dungeon level										
                        DataLoader.WriteInt8(writer, GameWorldController.instance.LevelNo + 1); break;
                    case 0x5F:///High nibble is dungeon level+1 with the silver tree if planted
                        {
                            int val = (UWCharacter.Instance.ResurrectLevel & 0xf) << 4 | (UWCharacter.Instance.MoonGateLevel & 0xf);
                            DataLoader.WriteInt8(writer, val);
                            break;
                        }
                    case 0x60: ///    bits 2..5: play_poison.  no of active spell effects
                        DataLoader.WriteInt8(writer, (((NoOfActiveEffects & 0x3) << 6)) | (UWCharacter.Instance.play_poison << 2) | (Quest.instance.IncenseDream & 0x3));

                        break;
                    case 0x61:
                        {
                            int val = 0;
                            if (Quest.instance.isOrbDestroyed)
                            {
                                val = 32;//bit 5
                            }
                            if (Quest.instance.isCupFound)
                            {
                                val = val | 64;     // bit 6 is the cup found.
                            }

                            DataLoader.WriteInt8(writer, val);
                            break;
                        }
                    case 0x63: //Is garamon buried
                        {
                            if (Quest.instance.isGaramonBuried)
                            {
                                DataLoader.WriteInt8(writer, 28);
                            }
                            else
                            {//Default value Unknown meaning.
                                DataLoader.WriteInt8(writer, 16);
                            }
                            break;
                        }
                    case 0x65: // hand, Gender & body, and class
                        {
                            //bit 1 = hand left/right
                            //bit 2-5 = gender & body
                            //bit 6-8 = class
                            int val = 0;
                            if (!UWCharacter.Instance.isLefty)
                            {
                                val |= 1;
                            }
                            if (UWCharacter.Instance.isFemale)
                            {
                                val |= ((UWCharacter.Instance.Body * 2) + 1) << 1;
                            }
                            else
                            {
                                val |= ((UWCharacter.Instance.Body * 2)) << 1;
                            }
                            val |= UWCharacter.Instance.CharClass << 5;
                            DataLoader.WriteInt8(writer, val); break;
                            //break;
                        }
                    case 0x66://Quest flags
                        {
                            int val = 0;
                            for (int b = 0; b < 32; b++)
                            {
                                val |= (Quest.instance.QuestVariables[b] & 0x1) << b;
                            }
                            DataLoader.WriteInt32(writer, val);
                            break;
                        }

                    case 0x66 + 1://Quest flags ignore
                    case 0x66 + 2://Quest flags ignore
                    case 0x66 + 3://Quest flags ignore
                        break;

                    case 0x6A:
                        DataLoader.WriteInt8(writer, Quest.instance.QuestVariables[32]); break;
                    case 0x6B:
                        DataLoader.WriteInt8(writer, Quest.instance.QuestVariables[33]); break;
                    case 0x6C:
                        DataLoader.WriteInt8(writer, Quest.instance.QuestVariables[34]); break;
                    case 0x6D:
                        DataLoader.WriteInt8(writer, Quest.instance.QuestVariables[35]); break;
                    case 0x6E://No of talismans still to destory
                        DataLoader.WriteInt8(writer, Quest.instance.TalismansRemaining); break;
                    case 0x6F://Garamon dream related?
                        DataLoader.WriteInt8(writer, Quest.instance.GaramonDream); break;
                    case 0x71://Game variables
                    case 0x72:
                    case 0x73:
                    case 0x74:
                    case 0x75:
                    case 0x76:
                    case 0x77:
                    case 0x78:
                    case 0x79:
                    case 0x7A:
                    case 0x7B:
                    case 0x7C:
                    case 0x7D:
                    case 0x7E:
                    case 0x7F:
                    case 0x80:
                    case 0x81:
                    case 0x82:
                    case 0x83:
                    case 0x84:
                    case 0x85:
                    case 0x86:
                    case 0x87:
                    case 0x88:
                    case 0x89:
                    case 0x8A:
                    case 0x8B:
                    case 0x8C:
                    case 0x8D:
                    case 0x8E:
                    case 0x8F:
                    case 0x90:

                    case 0x91:
                    case 0x92:
                    case 0x93:
                    case 0x94:
                    case 0x95:
                    case 0x96:
                    case 0x97:
                    case 0x98:
                    case 0x99:
                    case 0x9A:
                    case 0x9B:
                    case 0x9C:
                    case 0x9D:
                    case 0x9E:
                    case 0x9F:
                    case 0xA0:
                    case 0xA1:
                    case 0xA2:
                    case 0xA3:
                    case 0xA4:
                    case 0xA5:
                    case 0xA6:
                    case 0xA7:
                    case 0xA8:
                    case 0xA9:
                    case 0xAA:
                    case 0xAB:
                    case 0xAC:
                    case 0xAD:
                    case 0xAE:
                    case 0xAF:
                    case 0xB0:


                        {
                            DataLoader.WriteInt8(writer, Quest.instance.variables[i - 0x71]);
                            break;
                        }
                    case 0xB1://The max mana the player has when their mana is drained by the magic orb.
                        {
                            DataLoader.WriteInt8(writer, UWCharacter.Instance.PlayerMagic.TrueMaxMana);
                            break;
                        }
                    case 0xBC:
                        //Unknown
                        DataLoader.WriteInt8(writer, 0xFF);
                        break;
                    case 0xb5://difficulty
                        DataLoader.WriteInt8(writer, GameWorldController.instance.difficulty); break;

                    case 0xB6: //UW Game options TODO: Implement these
                               //high nibble is detail level.
                               //bit 0 of low nibble is sound
                               //bit 3 of low nibble is music
                        {
                            int valToWrite = 0x30;//High detail	
                            if (ObjectInteraction.PlaySoundEffects)
                            {
                                valToWrite = valToWrite | 0x1;
                            }
                            if (MusicController.PlayMusic)
                            {
                                valToWrite = valToWrite | 0x4;
                            }
                            DataLoader.WriteInt8(writer, valToWrite);
                        }
                        break;
                    case 0xB7://Unknown. Always 8
                        DataLoader.WriteInt8(writer, 0x8);
                        break;
                    case 0xCF: ///   game time
                        //DataLoader.WriteInt32(writer,UWCharacter.Instance.game_time);break;
                        DataLoader.WriteInt8(writer, 0); break;//Write zero since I don't track milliseconds
                                                               //break;
                    case 0xD0:
                        DataLoader.WriteInt8(writer, GameClock.instance.gametimevals[0]); break;
                    case 0xD1:
                        DataLoader.WriteInt8(writer, GameClock.instance.gametimevals[1]); break;
                    case 0xD2:
                        DataLoader.WriteInt8(writer, GameClock.instance.gametimevals[2]); break;
                    case 0xD3://No of inventory items + 1.
                        DataLoader.WriteInt16(writer, inventoryObjects.GetUpperBound(0) + 1 + 1);
                        //Debug.Log("No of inventory " + inventoryObjects.GetUpperBound(0));
                        break;
                    case 0xD4://Skip prev
                        break;
                    case 0xD5:
                        {//7F 20
                            DataLoader.WriteInt8(writer, 0x7F); break;
                            //break;	
                        }
                    case 0xD6:
                        {//The mysterious clip through bridges on a second jump byte.
                            DataLoader.WriteInt8(writer, 0x20); break;
                            //break;
                        }
                    case 0xDB:
                        if (GameWorldController.instance.InventoryMarker.transform.childCount > 0)
                        {//player has inventory. Not sure where these values come from
                            DataLoader.WriteInt8(writer, 0x40); break;
                        }
                        else
                        {
                            DataLoader.WriteInt8(writer, 0x0); break;
                        }
                    //break;
                    case 0xDD://Duplicate curvit
                        DataLoader.WriteInt8(writer, UWCharacter.Instance.CurVIT); break;
                    //break;

                    case 0xF8: // Helm (all of these subsequent values are indices into the object list at offset 312
                        WriteInventoryIndex(writer, inventoryObjects, 0); break;
                    case 0xF9: // Helm ignore
                        break;
                    case 0xFA: // Chest
                        WriteInventoryIndex(writer, inventoryObjects, 1); break;
                    case 0xFB: // Chest ignore
                        break;
                    case 0xFC: // Gloves
                        WriteInventoryIndex(writer, inventoryObjects, 4); break;
                    case 0xFD: // Gloves ignore
                        break;
                    case 0xFE: // Leggings
                        WriteInventoryIndex(writer, inventoryObjects, 2); break;
                    case 0xFF: // Leggings ignore
                        break;
                    case 0x100: // Boots
                        WriteInventoryIndex(writer, inventoryObjects, 3); break;
                    case 0x101: // Boots ignore
                        break;
                    case 0x102: // TopRightShoulder
                        WriteInventoryIndex(writer, inventoryObjects, 5); break;
                    case 0x103: // TopRightShoulder ignore
                        break;
                    case 0x104: // TopLeftShoulder
                        WriteInventoryIndex(writer, inventoryObjects, 6); break;
                    case 0x105: // TopLeftShoulder ignore
                        break;
                    case 0x106: // Righthand
                        WriteInventoryIndex(writer, inventoryObjects, 7); break;
                    case 0x107: // Righthand ignore
                        break;
                    case 0x108: // LeftHand
                        WriteInventoryIndex(writer, inventoryObjects, 8); break;
                    case 0x109: // LeftHand ignore
                        break;
                    case 0x10A: // leftRing
                        WriteInventoryIndex(writer, inventoryObjects, 9); break;
                    case 0x10B: // leftRing ignore
                        break;
                    case 0x10C: // rightRing
                        WriteInventoryIndex(writer, inventoryObjects, 10); break;
                    case 0x10D: // rightRing ignore
                        break;
                    case 0x10E: // Backpack0
                        WriteInventoryIndex(writer, inventoryObjects, 11); break;
                    case 0x10F: // Backpack0 ignore
                        break;
                    case 0x110: // Backpack1
                        WriteInventoryIndex(writer, inventoryObjects, 12); break;
                    case 0x111: // Backpack1 ignore
                        break;
                    case 0x112: // Backpack2
                        WriteInventoryIndex(writer, inventoryObjects, 13); break;
                    case 0x113: // Backpack2 ignore
                        break;
                    case 0x114: // Backpack3
                        WriteInventoryIndex(writer, inventoryObjects, 14); break;
                    case 0x115: // Backpack3 ignore
                        break;
                    case 0x116: // Backpack4
                        WriteInventoryIndex(writer, inventoryObjects, 15); break;
                    case 0x117: // Backpack4 ignore
                        break;
                    case 0x118: // Backpack5
                        WriteInventoryIndex(writer, inventoryObjects, 16); break;
                    case 0x119: // Backpack5 ignore
                        break;
                    case 0x11A: // Backpack6
                        WriteInventoryIndex(writer, inventoryObjects, 17); break;
                    case 0x11B: // Backpack6 ignore
                        break;
                    case 0x11C: // Backpack7
                        WriteInventoryIndex(writer, inventoryObjects, 18); break;
                    case 0x11D: // Backpack7 ignore
                        break;

                    default://No value. Write 0	or hardcoded values
                            //if ((i>=0xA1) || (i<=0xF7))
                            //{//Unknown Hardcoded values
                            //		DataLoader.WriteInt8(writer,hardcoded[i-161])	;
                            //}
                            //else
                            //{
                        DataLoader.WriteInt8(writer, 0); break;
                        //}


                        //break;

                }   //endswitch


            }

        }

        //ALl things going well I should be at byte no 312 where I can write the inventory info.


        for (int o = 0; o <= inventoryObjects.GetUpperBound(0); o++)
        {
            GameObject obj = GameObject.Find(inventoryObjects[o]);
            if (obj != null)
            {
                ObjectInteraction currobj = obj.GetComponent<ObjectInteraction>();
                if (currobj.GetItemType() == ObjectInteraction.WAND)
                {
                    if (currobj.GetComponent<Wand>() != null)
                    {
                        if (currobj.GetComponent<Wand>().linkedspell != null)
                        {//This is a wand with a linked spell object.
                            string link = currobj.GetComponent<Wand>().linkedspell.name;
                            //For the index of the linked object in the list
                            for (int z = 0; z <= inventoryObjects.GetUpperBound(0); z++)
                            {
                                if (link == inventoryObjects[z])
                                {
                                    currobj.link = z + 1;
                                    break;
                                }
                            }
                        }
                    }
                }
                int ByteToWrite = (currobj.isquant << 15) |
                        (currobj.invis << 14) |
                        (currobj.doordir << 13) |
                        (currobj.enchantment << 12) |
                        ((currobj.flags & 0x07) << 9) |
                        (currobj.item_id & 0x1FF);

                DataLoader.WriteInt8(writer, (ByteToWrite & 0xFF));
                DataLoader.WriteInt8(writer, ((ByteToWrite >> 8) & 0xFF));

                ByteToWrite = ((currobj.xpos & 0x7) << 13) |
                        ((currobj.ypos & 0x7) << 10) |
                        ((currobj.heading & 0x7) << 7) |
                        ((currobj.zpos & 0x7F));
                DataLoader.WriteInt8(writer, (ByteToWrite & 0xFF));
                DataLoader.WriteInt8(writer, ((ByteToWrite >> 8) & 0xFF));

                ByteToWrite = (((int)currobj.next & 0x3FF) << 6) |
                        (currobj.quality & 0x3F);
                DataLoader.WriteInt8(writer, (ByteToWrite & 0xFF));
                DataLoader.WriteInt8(writer, ((ByteToWrite >> 8) & 0xFF));

                ByteToWrite = ((currobj.link & 0x3FF) << 6) |
                        (currobj.owner & 0x3F);
                DataLoader.WriteInt8(writer, (ByteToWrite & 0xFF));
                DataLoader.WriteInt8(writer, ((ByteToWrite >> 8) & 0xFF));
            }
        }


        writer.Close();//The file now saved is un-encrypted

        char[] buffer;
        //Reopen and encrypt the file
        if (DataLoader.ReadStreamFile(Loader.BasePath + "SAVE" + slotNo + sep + "playertmp.dat", out buffer))
        {
            int xOrValue = (int)buffer[0];
            int incrnum = 3;
            for (int i = 1; i <= NoOfEncryptedBytes; i++)
            {
                if ((i == 81) | (i == 161))
                {
                    incrnum = 3;
                }
                buffer[i] ^= (char)((xOrValue + incrnum) & 0xFF);
                incrnum += 3;
            }

            byte[] dataToWrite = new byte[buffer.GetUpperBound(0) + 1];
            for (long i = 0; i <= buffer.GetUpperBound(0); i++)
            {
                dataToWrite[i] = (byte)buffer[i];
            }
            File.WriteAllBytes(Loader.BasePath + "SAVE" + slotNo + sep + "PLAYER.DAT", dataToWrite);

        }
    }
}
