using UnityEngine;

public class MagicLookupTable : Loader
{
    //A table of data found in the UW1 and UW2 executables used track some spell properties.

    //In UW2.exe found at offset  0x66490 seg68 0x144/2 entries
    //IN UW1.exe found at offset 0x5B590 seg64   0xD4/2 entries
    //TODO : find out size for UWdemo

    public int[] LookupValues;

    public MagicLookupTable()
    {
        char[] uw_exe;
        int FileOffset = 0;
        int NoOfEntries = 0;
        string Exe = "";
        switch (_RES)
        {
            case GAME_UWDEMO:
                {
                    LookupValues = new int[106];
                    FileOffset = 0x5BE90;
                    Exe = "uwdemo.exe";
                    NoOfEntries = 105;
                    break;
                }
            case GAME_UW1:
                {
                    LookupValues = new int[106];
                    FileOffset = 0x5B590;
                    Exe = "uw.exe";
                    NoOfEntries = 105;
                    break;
                }
            case GAME_UW2:
                {
                    LookupValues = new int[138];
                    FileOffset = 0x66490;
                    Exe = "uw2.exe";
                    NoOfEntries =137;
                    break;
                }
            default:
                {
                    Debug.Log("unimplmented exe");
                    break;
                }
        }

        if (DataLoader.ReadStreamFile(BasePath + sep + Exe, out uw_exe))
        {
            for (int i = 0; i <= NoOfEntries; i++)
            {
                LookupValues[i] = (int)getValAtAddress(uw_exe, FileOffset, 16);
                FileOffset += 2;
                //Debug.Log(i + "=" + LookupValues[i]);
            }
        }
    }
}

