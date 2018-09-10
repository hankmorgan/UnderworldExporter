using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderworldEditor
{
    class playerdat
    {
        /// <summary>
        /// Size of encrypted area in UW1 player.dat
        /// </summary>
        private const int NoOfEncryptedBytes = 0xD2;

        public static char[] LoadPlayerDatUW1(string FilePath)
        {
            char[] buffer;
            if (Util.ReadStreamFile(FilePath, out buffer))
            {
                int xOrValue = (int)buffer[0];
                EncryptDecryptUW1(buffer, xOrValue);
            }//end readstreamfile
            return buffer;

        }//end loadplayerdatuw1

        /// <summary>
        /// Encrypts or decrypts a UW1 player dat file.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="xOrValue"></param>
        public static void EncryptDecryptUW1(char[] buffer, int xOrValue)
        {
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
        }


        /// <summary>
        /// Returns the player.dat field name for UW1
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string UW1FieldName(int index)
        {
            switch (index)
            {
                case 0x0: return "XOR Key";
                case 0x1: return "NAME";
                case 0x2: return "NAME";
                case 0x3: return "NAME";
                case 0x4: return "NAME";
                case 0x5: return "NAME";
                case 0x6: return "NAME";
                case 0x7: return "NAME";
                case 0x8: return "NAME";
                case 0x9: return "NAME";
                case 0xA: return "NAME";
                case 0xB: return "NAME";
                case 0xC: return "NAME";
                case 0xD: return "NAME";
                case 0xE: return "unused";
                case 0xF: return "unused";
                case 0x10: return "unused";
                case 0x11: return "unused";
                case 0x12: return "unused";
                case 0x13: return "unused";
                case 0x14: return "unused";
                case 0x15: return "unused";
                case 0x16: return "unused";
                case 0x17: return "unused";
                case 0x18: return "unused";
                case 0x19: return "unused";
                case 0x1A: return "unused";
                case 0x1B: return "unused";
                case 0x1C: return "unused";
                case 0x1D: return "unused";
                case 0x1E: return "unused";
                case 0x1F: return "Strength";
                case 0x20: return "Dexterity";
                case 0x21: return "Intelligence";
                case 0x22: return "Attack";
                case 0x23: return "Defense";
                case 0x24: return "Unarmed";
                case 0x25: return "Sword";
                case 0x26: return "Axe";
                case 0x27: return "Mace";
                case 0x28: return "Missile";
                case 0x29: return "Mana";
                case 0x2A: return "Lore";
                case 0x2B: return "Casting";
                case 0x2C: return "Traps";
                case 0x2D: return "Search";
                case 0x2E: return "Track";
                case 0x2F: return "Sneak";
                case 0x30: return "Repair";
                case 0x31: return "Charm";
                case 0x32: return "Picklock";
                case 0x33: return "Acrobat";
                case 0x34: return "Appraise";
                case 0x35: return "Swimming";
                case 0x36: return "Current vit";
                case 0x37: return "max.vit";
                case 0x38: return "play mana";
                case 0x39: return "max. Mana";
                case 0x3A: return "play_hunger";
                case 0x3B: return "fatigue";
                case 0x3C: return "unknown";
                case 0x3D: return "unknown";
                case 0x3E: return "character_Level";
                case 0x3F: return "ActiveSpell1";
                case 0x40: return "ActiveSpell1";
                case 0x41: return "ActiveSpell2";
                case 0x42: return "ActiveSpell2";
                case 0x43: return "ActiveSpell3";
                case 0x44: return "ActiveSpell3";
                case 0x45: return "RuneBits";
                case 0x46: return "RuneBits";
                case 0x47: return "RuneBits";
                case 0x48: return "Selected Rune (0x24 is none)";
                case 0x49: return "Selected Rune";
                case 0x4A: return "Selected Rune";
                case 0x4B: return "No of items in inventory? Shifted left?";
                case 0x4C: return "unknown";
                case 0x4D: return "Weight";
                case 0x4E: return "Weight";
                case 0x4F: return "experience in 0.1 points";
                case 0x50: return "experience in 0.1 points";
                case 0x51: return "experience in 0.1 points";
                case 0x52: return "experience in 0.1 points";
                case 0x53: return "Skillpoints available to spend";
                case 0x54: return "ditto?";
                case 0x55: return "xpos";
                case 0x56: return "xpos";
                case 0x57: return "ypos";
                case 0x58: return "ypos";
                case 0x59: return "zpos";
                case 0x5A: return "zpos";
                case 0x5B: return "unknown";
                case 0x5C: return "heading";
                case 0x5D: return "Dungeon level";
                case 0x5E: return "unknown";
                case 0x5F: return "High nibble is level of silver tree. Low nibble is the level of the moon stone";
                case 0x60: return "Incense dream bits (0-1)   , play_poison (bits 2-5) , No of Active spells bits (6-7)";
                case 0x61: return "Various plot flags";
                case 0x62: return "unknown";
                case 0x63: return "MiscQuestVars";
                case 0x64: return "Light level. (bits 5 to 8)";
                case 0x65: return "Handedness/Gender/Body/charclass";
                case 0x66: return "QuestFlags(0-31)";
                case 0x67: return "QuestFlags(0-31)";
                case 0x68: return "QuestFlags(0-31)";
                case 0x69: return "QuestFlags(0-31)";
                case 0x6A: return "QuestFlag 32";
                case 0x6B: return "QuestFlag 33";
                case 0x6C: return "QuestFlag 34";
                case 0x6D: return "QuestFlag 35";
                case 0x6E: return "TalismansRemaining";
                case 0x6F: return "GaramonDreamRelatd";
                case 0x70: return "unknown";
                case 0x71: return "variable0";
                case 0x72: return "variable1";
                case 0x73: return "variable2";
                case 0x74: return "variable3";
                case 0x75: return "variable4";
                case 0x76: return "variable5";
                case 0x77: return "variable6";
                case 0x78: return "variable7";
                case 0x79: return "variable8";
                case 0x7A: return "variable9";
                case 0x7B: return "variable10";
                case 0x7C: return "variable11";
                case 0x7D: return "variable12";
                case 0x7E: return "variable13";
                case 0x7F: return "variable14";
                case 0x80: return "variable15";
                case 0x81: return "variable16";
                case 0x82: return "variable17";
                case 0x83: return "variable18";
                case 0x84: return "variable19";
                case 0x85: return "variable20";
                case 0x86: return "variable21";
                case 0x87: return "variable22";
                case 0x88: return "variable23";
                case 0x89: return "variable24";
                case 0x8A: return "variable25";
                case 0x8B: return "variable26";
                case 0x8C: return "variable27";
                case 0x8D: return "variable28";
                case 0x8E: return "variable29";
                case 0x8F: return "variable30";
                case 0x90: return "variable31";
                case 0x91: return "variable32";
                case 0x92: return "variable33";
                case 0x93: return "variable34";
                case 0x94: return "variable35";
                case 0x95: return "variable36";
                case 0x96: return "variable37";
                case 0x97: return "variable38";
                case 0x98: return "variable39";
                case 0x99: return "variable40";
                case 0x9A: return "variable41";
                case 0x9B: return "variable42";
                case 0x9C: return "variable43";
                case 0x9D: return "variable44";
                case 0x9E: return "variable45";
                case 0x9F: return "variable46";
                case 0xA0: return "variable47";
                case 0xA1: return "variable48";
                case 0xA2: return "variable49";
                case 0xA3: return "variable50";
                case 0xA4: return "variable51";
                case 0xA5: return "52";
                case 0xA6: return "unknown";
                case 0xA7: return "unknown";
                case 0xA8: return "unknown";
                case 0xA9: return "unknown";
                case 0xAA: return "unknown";
                case 0xAB: return "unknown";
                case 0xAC: return "unknown";
                case 0xAD: return "unknown";
                case 0xAE: return "unknown";
                case 0xAF: return "unknown";
                case 0xB0: return "unknown";
                case 0xB1: return "True Max Mana for the orb rock";
                case 0xB2: return "unknown";
                case 0xB3: return "unknown";
                case 0xB4: return "unknown";
                case 0xB5: return "Difficulty (?)";
                case 0xB6: return "Game options";
                case 0xB7: return "unknown";
                case 0xB8: return "unknown";
                case 0xB9: return "unknown";
                case 0xBA: return "unknown";
                case 0xBB: return "unknown";
                case 0xBC: return "unknown";
                case 0xBD: return "unknown";
                case 0xBE: return "unknown";
                case 0xBF: return "unknown";
                case 0xC0: return "unknown";
                case 0xC1: return "unknown";
                case 0xC2: return "unknown";
                case 0xC3: return "unknown";
                case 0xC4: return "unknown";
                case 0xC5: return "unknown";
                case 0xC6: return "unknown";
                case 0xC7: return "unknown";
                case 0xC8: return "unknown";
                case 0xC9: return "unknown";
                case 0xCA: return "unknown";
                case 0xCB: return "unknown";
                case 0xCC: return "unknown";
                case 0xCD: return "unknown";
                case 0xCE: return "unknown";
                case 0xCF: return "Gametime related (frame ticks?)";
                case 0xD0: return "Gametime related";
                case 0xD1: return "Hour of day (sort of)";
                case 0xD2: return "Game Day (sort of)";
                case 0xD3: return "No of inventory items held plus 1";
                case 0xD4: return "No of inventory items held plus 1";
                case 0xD5: return "Blocks interaction with the world?";
                case 0xD6: return "Clip through bridges when jumping a second time when this is not set";
                case 0xD7: return "unknown";
                case 0xD8: return "unknown";
                case 0xD9: return "unknown";
                case 0xDA: return "unknown";
                case 0xDB: return "Inventory only works when this is set.";
                case 0xDC: return "unknown";
                case 0xDD: return "Curvit as well?";
                case 0xDE: return "unknown";
                case 0xDF: return "unknown";
                case 0xE0: return "unknown";
                case 0xE1: return "?";
                case 0xE2: return "unknown";
                case 0xE3: return "unknown";
                case 0xE4: return "unknown";
                case 0xE5: return "unknown";
                case 0xE6: return "unknown";
                case 0xE7: return "unknown";
                case 0xE8: return "unknown";
                case 0xE9: return "unknown";
                case 0xEA: return "unknown";
                case 0xEB: return "unknown";
                case 0xEC: return "unknown";
                case 0xED: return "unknown";
                case 0xEE: return "unknown";
                case 0xEF: return "unknown";
                case 0xF0: return "unknown";
                case 0xF1: return "unknown";
                case 0xF2: return "unknown";
                case 0xF3: return "unknown";
                case 0xF4: return "unknown";
                case 0xF5: return "unknown";
                case 0xF6: return "unknown";
                case 0xF7: return "unknown";
                case 0xF8: return "Helm (all of these subsequent values are indices into the object list at offset 312";
                case 0xF9: return "Helm (enchantments are reapply on reload)";
                case 0xFA: return "Chest";
                case 0xFB: return "Chest";
                case 0xFC: return "Gloves";
                case 0xFD: return "Gloves";
                case 0xFE: return "Leggings";
                case 0xFF: return "Leggings";
                case 0x100: return "Boots";
                case 0x101: return "Boots";
                case 0x102: return "TopRightShoulder";
                case 0x103: return "TopRightShoulder";
                case 0x104: return "TopLeftShoulder";
                case 0x105: return "TopLeftShoulder";
                case 0x106: return "Righthand";
                case 0x107: return "Righthand";
                case 0x108: return "LeftHand";
                case 0x109: return "LeftHand";
                case 0x10A: return "RightRing";
                case 0x10B: return "RightRing";
                case 0x10C: return "LeftRing";
                case 0x10D: return "LeftRing";
                case 0x10E: return "Backpack0";
                case 0x10F: return "Backpack0";
                case 0x110: return "Backpack1";
                case 0x111: return "Backpack1";
                case 0x112: return "Backpack2";
                case 0x113: return "Backpack2";
                case 0x114: return "Backpack3";
                case 0x115: return "Backpack3";
                case 0x116: return "Backpack4";
                case 0x117: return "Backpack4";
                case 0x118: return "Backpack5";
                case 0x119: return "Backpack5";
                case 0x11A: return "Backpack6";
                case 0x11B: return "Backpack6";
                case 0x11C: return "Backpack7";
                case 0x11D: return "Backpack7";
                case 0x11E: return "unknown";
                case 0x11F: return "unknown";
                case 0x120: return "unknown";
                case 0x121: return "unknown";
                case 0x122: return "unknown";
                case 0x123: return "unknown";
                case 0x124: return "unknown";
                case 0x125: return "unknown";
                case 0x126: return "unknown";
                case 0x127: return "unknown";
                case 0x128: return "unknown";
                case 0x129: return "unknown";
                case 0x12A: return "unknown";
                case 0x12B: return "unknown";
                case 0x12C: return "unknown";
                case 0x12D: return "unknown";
                case 0x12E: return "unknown";
                case 0x12F: return "unknown";
                case 0x130: return "unknown";
                case 0x131: return "unknown";
                case 0x132: return "unknown";
                case 0x133: return "unknown";
                case 0x134: return "unknown";
                case 0x135: return "unknown";
                case 0x136: return "unknown";
                case 0x137: return "unknown";
                default:
                    {
                        if (index > 0x137)
                        {
                            return "inventory";
                        }
                        break;
                    }
            }
            return "UNKNOWN";
        }



    }//End class
}
