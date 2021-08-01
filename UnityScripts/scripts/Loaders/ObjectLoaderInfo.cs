using UnityEngine;
using System.Collections;

/// <summary>
/// Object loader info.
/// </summary>
/// Basically what gets written and read to and from lev.ark files.
/// Used to create instances of objectinteractions.
public class ObjectLoaderInfo : UWClass
{
    /// <summary>
    /// it's own index for look ups into the data to extract it's properties
    /// </summary>
    public int index;

    //Inventory Data. inventory data is not stored in a block of memory until write back so temp data is used here.
    public char[] InventoryData;

    public bool IsInventory
    {//= false;
        get { return parentList == GameWorldController.instance.inventoryLoader; }
    }

    public TileMap map;

    /// <summary>
    /// Referernce to the raw data for this item.
    /// </summary>
    public char[] DataBuffer
    {
        get
        {
            if (IsInventory)
            {
                if (InventoryData==null)
                {
                    InventoryData = new char[8]; //8 bytes of static data.
                }
                //return a ref to the players inventory buffer
                return InventoryData;
                //SaveGame.InventoryData;
            }
            else
            {
                return map.lev_ark_block.Data;
            }
        }
    }

    /// <summary>
    /// Indentifier of what the object is.
    /// </summary>
    public int item_id
    {//0-8
        get
        {
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR, 16);
            return (int)DataLoader.ExtractBits(val, 0, 0x1FF);
        }
        set
        {
            int origItemID = item_id;
            value &= 0x1FF; //Keep value in range;
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR, 16) & 0xFE00;
            val = val | (value & 0x1ff);
            DataBuffer[PTR] = (char)(val & 0xFF);
            DataBuffer[PTR + 1] = (char)((val >> 8) & 0xFF);
            if (origItemID != item_id)
            {
                Debug.Log("ItemID has changed");
            }
        }
    }

    /// <summary>
    /// Various Object Flags
    /// </summary>
    public short flags
    {//; //9-11
        get
        {// (short)(ExtractBits(Vals[0], 9, 0x7));
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR, 16);
            return (short)DataLoader.ExtractBits(val, 9, 0x7);
        }
        set
        {
            int origItemID = item_id;
            value &= 0x7; //Keep value in range;
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR, 16) & 0xF1FF;
            val = val | ((value & 0x7) << 9);
            DataBuffer[PTR] = (char)(val & 0xFF);
            DataBuffer[PTR + 1] = (char)((val >> 8) & 0xFF);
            if (origItemID != item_id)
            {
                Debug.Log("ItemID has changed");
            }
        }
    }

    /// <summary>
    /// The enchantment flag for the object.
    /// </summary>
    public short enchantment
    {//;   //12  (short)(ExtractBits(Vals[0], 12, 1));
        get
        {
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR, 16);
            return (short)DataLoader.ExtractBits(val, 12, 1);
        }
        set
        {
            int origItemID = item_id;
            value &= 0x1; //Keep value in range;
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR, 16) & 0xEFFF;
            val = val | ((value & 0x1) << 12);
            DataBuffer[PTR] = (char)(val & 0xFF);
            DataBuffer[PTR + 1] = (char)((val >> 8) & 0xFF);
            if (origItemID != item_id)
            {
                Debug.Log("ItemID has changed");
            }
        }
    }


    public short doordir
    {//;   //13 // (short)(ExtractBits(Vals[0], 13, 1))
        get
        {
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR, 16);
            return (short)DataLoader.ExtractBits(val, 13, 1);
        }
        set
        {
            int origItemID = item_id;
            value &= 0x1; //Keep value in range;
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR, 16) & 0xDFFF;
            val = val | ((value & 0x1) << 13);
            DataBuffer[PTR] = (char)(val & 0xFF);
            DataBuffer[PTR + 1] = (char)((val >> 8) & 0xFF);
            if (origItemID != item_id)
            {
                Debug.Log("ItemID has changed");
            }
        }
    }

    public short invis     //14
    {//(short)(ExtractBits(Vals[0], 14, 1));
        get
        {           
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR, 16);
            return (short)DataLoader.ExtractBits(val, 14, 1);
        }
        set
        {
            int origItemID = item_id;
            value &= 0x1; //Keep value in range;
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR, 16) & 0xBFFF;
            val = val | ((value & 0x1) << 14);
            DataBuffer[PTR] = (char)(val & 0xFF);
            DataBuffer[PTR + 1] = (char)((val >> 8) & 0xFF);
            if (origItemID != item_id)
            {
                Debug.Log("ItemID has changed");
            }
        }
    }

    public short is_quant  //15
    {
        get
        {
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR, 16);
            return (short)DataLoader.ExtractBits(val, 15, 1);
        }
        set
        {
            int origItemID = item_id;
            value &= 0x1; //Keep value in range;
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR, 16) & 0x7FFF;
            val = val | ((value & 0x1) << 15);
            DataBuffer[PTR] = (char)(val & 0xFF);
            DataBuffer[PTR + 1] = (char)((val >> 8) & 0xFF);
            if (origItemID!=item_id)
            {
                Debug.Log("ItemID has changed");
            }
        }
    }


    public int texture; // Note: some objects don't have flags and use the whole lower byte as a texture number
                        //(gravestone, picture, lever, switch, shelf, bridge, ..)
                        //This variable is uses for shorthand usage of this property
                        //Not used ??

    public short zpos
    {//; (short)(ExtractBits(Vals[1], 0, 0x7f)); 
        get
        {
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR + 2, 16);
            return (short)DataLoader.ExtractBits(val, 0, 0x7f);
        }
        set
        {
            value &= 0x7F; //Keep value in range;
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR + 2, 16) & 0xFF80;
            val = val | ((value & 0x7f));
            DataBuffer[PTR + 2] = (char)(val & 0xFF);
            DataBuffer[PTR + 3] = (char)((val >> 8) & 0xFF);
            if (zpos != value)
            {
                Debug.Log("zpos!=newValue");
            }
        }
    }

    public short heading
    {//;(short)(ExtractBits(Vals[1], 7, 0x7)); //bits 7-9
        get
        {
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR + 2, 16);
            return (short)DataLoader.ExtractBits(val, 7, 0x7);
        }
        set
        {
            value &= 0x7; //Keep value in range;
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR + 2, 16) & 0xFC7F;
            val = val | ((value & 0x7) << 7);
            DataBuffer[PTR + 2] = (char)(val & 0xFF);
            DataBuffer[PTR + 3] = (char)((val >> 8) & 0xFF);
            if (heading != value)
            {
                Debug.Log("heading!=newValue");
            }
        }
    }


    public short ypos
    {//(short)(ExtractBits(Vals[1], 10, 0x7));
        get
        {
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR + 2, 16);
            return (short)DataLoader.ExtractBits(val, 10, 0x7);
        }
        set
        {
            value &= 0x7; //Keep value in range;
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR + 2, 16) & 0xE3FF;
            val = val | ((value & 0x7) << 10);
            DataBuffer[PTR + 2] = (char)(val & 0xFF);
            DataBuffer[PTR + 3] = (char)((val >> 8) & 0xFF);
            if (ypos != value)
            {
                Debug.Log("ypos!=newValue");
            }
        }
    }


    public short xpos
    {// (short)(ExtractBits(Vals[1], 13, 0x7));
        get
        {
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR + 2, 16);
            return (short)DataLoader.ExtractBits(val, 13, 0x7);
        }
        set
        {
            value &= 0x7; //Keep value in range;
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR + 2, 16) & 0x1FFF;
            val = val | ((value & 0x7) << 13);
            DataBuffer[PTR + 2] = (char)(val & 0xFF);
            DataBuffer[PTR + 3] = (char)((val >> 8) & 0xFF);
            if (xpos != value)
            {
                Debug.Log("xpos!=newValue");
            }
        }
    }


    public short quality
    { // (short)(ExtractBits(Vals[2], 0, 0x3f))
        get
        {
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR + 4, 16);
            return (short)DataLoader.ExtractBits(val, 0, 0x3f);
        }
        set
        {
            value &= 0x3F; //Keep value in range;
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR + 4, 16) & 0xFFC0;
            val = val | ((value & 0x3f));
            DataBuffer[PTR + 4] = (char)(val & 0xFF);
            DataBuffer[PTR + 5] = (char)((val >> 8) & 0xFF);
            if (quality != value)
            {
                Debug.Log("quality!=newValue");
            }
        }
    }

    public int next
    {//(short)(ExtractBits(Vals[2], 6, 0x3ff));
        get
        {
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR + 4, 16);
            return (short)DataLoader.ExtractBits(val, 6, 0x3ff);
        }
        set
        {
            value &= 0x3FF; //Keep value in range;
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR + 4, 16) & 0x003F;
            val = val | ((value & 0x3ff) << 6);
            DataBuffer[PTR + 4] = (char)(val & 0xFF);
            DataBuffer[PTR + 5] = (char)((val >> 8) & 0xFF);
            if (next != value)
            {
                Debug.Log("next!=newValue");
            }
        }
    }


    public short owner
    { // (short)(ExtractBits(Vals[2], 0, 0x3f))
        get
        {
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR + 6, 16);
            return (short)DataLoader.ExtractBits(val, 0, 0x3f);
        }
        set
        {
            value &= 0x3F; //Keep value in range;
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR + 6, 16) & 0xFFC0;
            val = val | ((value & 0x3f));
            DataBuffer[PTR + 6] = (char)(val & 0xFF);
            DataBuffer[PTR + 7] = (char)((val >> 8) & 0xFF);
            if (owner != value)
            {
                Debug.Log("owner!=newValue");
            }
        }
    }

    public int link
    {//(short)(ExtractBits(Vals[2], 6, 0x3ff));
        get
        {
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR + 6, 16);
            return (short)DataLoader.ExtractBits(val, 6, 0x3ff);
        }
        set
        {
            value &= 0x3FF; //Keep value in range;
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR + 6, 16) & 0x003F;
            val = val | ((value & 0x3ff) << 6);
            DataBuffer[PTR + 6] = (char)(val & 0xFF);
            DataBuffer[PTR + 7] = (char)((val >> 8) & 0xFF);
            if (link != value)
            {
                Debug.Log("link!=newValue");
            }
        }
    }

    /// <summary>
    /// Check if the object should only have the base 4 bytes of static info.
    /// </summary>
    public bool IsStatic
    {
        get
        {
            if (IsInventory) { return true; }
            else { return index >= 256; }
        }
    }

    //Mobile Properties. Only available on objects with indices <256

    public short npc_hp
    {//
        get
        {
            if (IsStatic) { return 0; }
            return (short)(DataLoader.getValAtAddress(DataBuffer, PTR + 0x8, 8));
        }
        set
        {
            if (!IsStatic)
            {
                value &= 0xFF; //Keep value in range;
                DataBuffer[PTR + 0x8] = (char)(value);
                if (npc_hp != value)
                {
                    Debug.Log("npc_hp!=newvalue");
                }
            }
        }
    }

    public short ProjectileHeading
    {
        get
        {
            if (IsStatic) { return 0; }
            return (short)DataLoader.getValAtAddress(DataBuffer, PTR + 0x9, 8);
         }
        set
        {
            if (!IsStatic)
            {
                value &= 0xFF; //Keep value in range;
                DataBuffer[PTR + 0x9] = (char)value;
            }
        }
    }


    //public short ProjectileHeadingMinor//defection to the right of the missile from the major heading.
    //{
    //    get
    //    {
    //        if (IsStatic) { return 0; }
    //        int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR + 0x9, 8);
    //        return (short)(DataLoader.ExtractBits(val, 0, 0x1F));
    //    }
    //    set
    //    {//E0
    //        if (!IsStatic)
    //        {
    //            value &= 0x1F; //Keep value in range;
    //            int val = (char)(ProjectileHeadingMajor << 5) | (value & 0x1F);
    //            DataBuffer[PTR + 0x9] = (char)val;
    //        }
    //    }

    //}

    //public short ProjectileHeadingMajor //Cardinal direction 0 to 7 of the missile. North = 0 turning clockwise to North west = 7
    //{
    //    get
    //    {
    //        if (IsStatic) { return 0; }
    //        int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR + 0x9, 8);
    //        return (short)(DataLoader.ExtractBits(val, 5, 0x7));
    //    }
    //    set
    //    {
    //        if (!IsStatic)
    //        {
    //            value &= 0x7; //Keep value in range;
    //            int val = (char)((value & 0x7) << 5) | (ProjectileHeadingMinor & 0x1F);
    //            DataBuffer[PTR + 0x9] = (char)val;
    //        }
    //    }
    //}

    public short MobileUnk_0xA
    {
        get
        {
            if (IsStatic) { return 0; }
            return (short)(DataLoader.getValAtAddress(DataBuffer, PTR + 0xa, 8));
        }
        set
        {
            if (!IsStatic)
            {
                value &= 0xFF; //Keep value in range;
                DataBuffer[PTR + 0xa] = (char)(value);
            }
        }
    }

    public short npc_goal
    {
        get
        {
            if (IsStatic) { return 0; }
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR + 0xb, 16);
            return (short)(DataLoader.ExtractBits(val, 0, 0xF));
        }
        set
        {
            if (!IsStatic)
            {
                value &= 0xF; //Keep value in range;
                //unk << 12 | gtarg << 4 | goal
                int val = (MobileUnk_0xB_12_F << 12) | (npc_gtarg << 4) | (value & 0xF);
                DataBuffer[PTR + 0xB] = (char)(val & 0xFF);
                DataBuffer[PTR + 0xC] = (char)((val >> 8) & 0xFF);
            }
        }
    }

    public short npc_gtarg
    {
        get
        {
            if (IsStatic) { return 0; }
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR + 0xb, 16);
            return (short)(DataLoader.ExtractBits(val, 4, 0xFF));
        }
        set
        {
            if (!IsStatic)
            {
                Debug.Log("Changing Gtarg for " + instance.gameObject.name + " to " + value);
                value &= 0xFF; //Keep value in range;
                //unk << 12 | gtarg << 4 | goal
                int val = (MobileUnk_0xB_12_F << 12) | (value << 4) | (npc_goal & 0xF);
                DataBuffer[PTR + 0xB] = (char)(val & 0xFF);
                DataBuffer[PTR + 0xC] = (char)((val >> 8) & 0xFF);
                if (npc_gtarg !=value)
                {
                    Debug.Log("Npc_Gtarg!=value");
                }
            }
        }
    }

    public short MobileUnk_0xB_12_F
    {
        get
        {
            if (IsStatic) { return 0; }
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR + 0xb, 16);
            return (short)(DataLoader.ExtractBits(val, 12, 0xF));
        }
        set
        {
            if (!IsStatic)
            {
                value &= 0xF; //Keep value in range;
                //unk << 12 | gtarg << 4 | goal
                int val = (value << 12) | (npc_gtarg << 4) | (npc_goal & 0xF);
                DataBuffer[PTR + 0xB] = (char)(val & 0xFF);
                DataBuffer[PTR + 0xC] = (char)((val >> 8) & 0xFF);
            }
        }
    }

    public short npc_level
    {
        get
        {
            if (IsStatic) { return 0; }
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR + 0xd, 16);
            return (short)(DataLoader.ExtractBits(val, 0, 0xF));
        }
        set
        {
            if (!IsStatic)
            {
                value &= 0xF; //Keep value in range;
                //attitude << 13  | talkedto << 12 | d12_1 << 11 | 4FF << 4 | npc_level
                int val = (npc_attitude << 13) | (npc_talkedto << 12) | (MobileUnk_0xD_12_1 << 11) | (MobileUnk_0xD_4_FF << 4) | (value & 0xF);
                DataBuffer[PTR + 0xB] = (char)(val & 0xFF);
                DataBuffer[PTR + 0xC] = (char)((val >> 8) & 0xFF);
            }

        }
    }

    public short MobileUnk_0xD_4_FF
    {
        get
        {
            if (IsStatic) { return 0; }
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR + 0xd, 16);
            return (short)(DataLoader.ExtractBits(val, 4, 0xff));
        }
        set
        {
            if (!IsStatic)
            {
                value &= 0xFF; //Keep value in range;
                //attitude << 13  | talkedto << 12 | d12_1 << 11 | 4FF << 4 | npc_level
                int val = (npc_attitude << 13) | (npc_talkedto << 12) | (MobileUnk_0xD_12_1 << 11) | (value << 4) | (npc_level & 0xF);
                DataBuffer[PTR + 0xB] = (char)(val & 0xFF);
                DataBuffer[PTR + 0xC] = (char)((val >> 8) & 0xFF);
            }
        }
    }

    public short NPC_PowerFlag
    {
        get
        {
            if (IsStatic) { return 0; }
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR + 0xd, 16);
            return (short)(DataLoader.ExtractBits(val, 0xA, 1));
        }
    }

    public short MobileUnk_0xD_12_1
    {
        get
        {
            if (IsStatic) { return 0; }
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR + 0xd, 16);
            return (short)(DataLoader.ExtractBits(val, 12, 1));
        }
        set
        {
            if (!IsStatic)
            {
                value &= 0x1; //Keep value in range;
                //attitude << 13  | talkedto << 12 | d12_1 << 11 | 4FF << 4 | npc_level
                int val = (npc_attitude << 13) | (npc_talkedto << 12) | (value << 11) | (MobileUnk_0xD_4_FF << 4) | (npc_level & 0xF);
                DataBuffer[PTR + 0xB] = (char)(val & 0xFF);
                DataBuffer[PTR + 0xC] = (char)((val >> 8) & 0xFF);
            }
        }
    }

    public short npc_talkedto
    {
        get
        {
            if (IsStatic) { return 0; }
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR + 0xd, 16);
            return (short)(DataLoader.ExtractBits(val, 13, 1));
        }
        set
        {
            if (!IsStatic)
            {
                value &= 0x1; //Keep value in range;
                //attitude << 13  | talkedto << 12 | d12_1 << 11 | 4FF << 4 | npc_level
                int val = (npc_attitude << 13) | ((value & 0x1) << 12) | (MobileUnk_0xD_12_1 << 11) | (MobileUnk_0xD_4_FF << 4) | (npc_level & 0xF);
                DataBuffer[PTR + 0xB] = (char)(val & 0xFF);
                DataBuffer[PTR + 0xC] = (char)((val >> 8) & 0xFF);
            }
        }
    }

    public short npc_attitude
    {
        get
        {
            if (IsStatic) { return 0; }
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR + 0xd, 16);
            return (short)(DataLoader.ExtractBits(val, 14, 0x3));
        }
        set
        {
            if (!IsStatic)
            {
                value &= 0x3; //Keep value in range;
                //attitude << 13  | talkedto << 12 | d12_1 << 11 | 4FF << 4 | npc_level
                int val = (value << 13) | (npc_talkedto << 12) | (MobileUnk_0xD_12_1 << 11) | (MobileUnk_0xD_4_FF << 4) | (npc_level & 0xF);
                DataBuffer[PTR + 0xB] = (char)(val & 0xFF);
                DataBuffer[PTR + 0xC] = (char)((val >> 8) & 0xFF);
            }
        }
    }
    


    public short MobileUnk_0xF_0_3F
    {
        get
        {
            if (IsStatic) { return 0; }
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR + 0xf, 16);
            return (short)(DataLoader.ExtractBits(val, 0, 0x3F));
        }
        set
        {
            if (!IsStatic)
            {
                value &= 0x3F; //Keep value in range;
                //unkFCF<<12 | npc_height <<6 | unkf03f
                int val = (MobileUnk_0xF_C_F << 12) | (npc_height << 6) | (value & 0x3F);
                DataBuffer[PTR + 0xf] = (char)(val & 0xFF);
                DataBuffer[PTR + 0x10] = (char)((val >> 8) & 0xFF);
            }
        }
    }

    public short npc_height
    {
        get
        {
            if (IsStatic) { return 0; }
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR + 0xf, 16);
            return (short)(DataLoader.ExtractBits(val, 6, 0x3F));
        }
        set
        {
            if (!IsStatic)
            {
                value &= 0x3f; //Keep value in range;
                //unkFCF<<12 | npc_height <<6 | unkf03f
                int val = (value << 12) | (npc_height << 6) | (MobileUnk_0xF_0_3F & 0x3f);
                DataBuffer[PTR + 0xf] = (char)(val & 0xFF);
                DataBuffer[PTR + 0x10] = (char)((val >> 8) & 0xFF);
            }
        }
    }

    public short MobileUnk_0xF_C_F
    {///Possibly used as a look up in to NPC charge modifiers?
        get
        {
            if (IsStatic) { return 0; }
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR + 0xf, 16);
            return (short)(DataLoader.ExtractBits(val, 0xC, 0xF));
        }
        set
        {
            if (!IsStatic)
            {
                value &= 0x3f; //Keep value in range;
                //unkFCF<<12 | npc_height <<6 | unkf03f
                int val = (MobileUnk_0xF_C_F << 12) | (value << 6) | (MobileUnk_0xF_0_3F & 0x3f);
                DataBuffer[PTR + 0xf] = (char)(val & 0xFF);
                DataBuffer[PTR + 0x10] = (char)((val >> 8) & 0xFF);
            }
        }
    }


    public short MobileUnk_0x11
    {
        get
        {
            if (IsStatic) { return 0; }
            return (short)(DataLoader.getValAtAddress(DataBuffer, PTR + 0x11, 8));
        }
        set
        {
            if (!IsStatic)
            {
                value &= 0xFF; //Keep value in range;
                DataBuffer[PTR + 0x11] = (char)(value);
            }
        }
    }

    public short ProjectileSourceID
    {
        get
        {
            if (IsStatic) { return 0; }
            return (short)(DataLoader.getValAtAddress(DataBuffer, PTR + 0x12, 8));
        }
        set
        {
            if (!IsStatic)
            {
                value &= 0xFF; //Keep value in range;
                DataBuffer[PTR + 0x12] = (char)(value);
            }
        }
    }

    public short MobileUnk_0x13
    {
        get
        {
            if (IsStatic) { return 0; }
            return (short)(DataLoader.getValAtAddress(DataBuffer, PTR + 0x13, 8));
        }
        set
        {
            if (!IsStatic)
            {
                value &= 0xFF; //Keep value in range;
                DataBuffer[PTR + 0x13] = (char)(value);
            }
        }
    }

    public short Projectile_Speed
    {
        get
        {
            if (IsStatic) { return 0; }
            int val = (int)DataLoader.getValAtAddress(map.lev_ark_block.Data, PTR + 0x14, 8);
            return (short)(DataLoader.ExtractBits(val, 0, 0xF));
        }
        set
        {
            value &= 0xF; //Keep value in range;
            //pitch<<4 | speed
            int val = (Projectile_Pitch << 4) | (value & 0xF);
            DataBuffer[PTR + 0x14] = (char)(val);
        }
    }

    public short Projectile_Pitch
    {
        get
        {
            if (IsStatic) { return 0; }
            int val = (int)DataLoader.getValAtAddress(map.lev_ark_block.Data, PTR + 0x14, 8);
            return (short)(DataLoader.ExtractBits(val, 4, 0xF));           
        }
        set
        {
            value &= 0xF; //Keep value in range;
            //pitch<<4 | speed
            int val = (value << 4) | (Projectile_Speed & 0xF);
            DataBuffer[PTR + 0x14] = (char)(val);
        }
    }


    //public short Projectile_Sign; //sign bit for pitch = 1 is up. 0 = down?
    public short npc_voidanim
    {
        get
        {
            if (IsStatic) { return 0; }
            int val = (int)DataLoader.getValAtAddress(map.lev_ark_block.Data, PTR + 0x15, 8);
            return (short)(DataLoader.ExtractBits(val, 0, 0x7));
        }
        set
        {
            value &= 0x7;//Keep in range
            int val = (MobileUnk_0x15_4_1F << 3) | (value & 0x7);
            DataBuffer[PTR + 0x15] = (char)(val);
        }
    }

    public short MobileUnk_0x15_4_1F
    {
        get
        {
            if (IsStatic) { return 0; }
            int val = (int)DataLoader.getValAtAddress(map.lev_ark_block.Data, PTR + 0x15, 8);
            return (short)(DataLoader.ExtractBits(val, 4, 0x1F));
        }
        set
        {
            value &= 0x1F;//Keep in range
            int val = (value << 3) | (npc_voidanim & 0x7);
            DataBuffer[PTR + 0x15] = (char)(val);
        }
    }

    public short MobileUnk_0x16_0_F
    {
        get
        {
            if (IsStatic) { return 0; }
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR + 0x16, 16);
            return (short)(DataLoader.ExtractBits(val, 0, 0xF));
        }
        set
        {
            if (!IsStatic)
            {
                value &= 0xf; //Keep value in range;
                              //xhome<<9 | yhome << 4 | MobileUnk_0xF_0_3F
                int val = (npc_xhome << 9) | (npc_yhome << 4) | (value & 0xF);
                DataBuffer[PTR + 0x16] = (char)(val & 0xFF);
                DataBuffer[PTR + 0x17] = (char)((val >> 8) & 0xFF);
            }
        }
    }

    public short npc_yhome
    {
        get
        {
            if (IsStatic) { return 0; }
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR + 0x16, 16);
            return (short)(DataLoader.ExtractBits(val, 4, 0x3F));
        }
        set
        {
            if (!IsStatic)
            {
                value &= 0x3f; //Keep value in range;
                              //xhome<<9 | yhome << 4 | MobileUnk_0xF_0_3F
                int val = (npc_xhome << 9) | (value << 4) | (MobileUnk_0xF_0_3F & 0xF);
                DataBuffer[PTR + 0x16] = (char)(val & 0xFF);
                DataBuffer[PTR + 0x17] = (char)((val >> 8) & 0xFF);
            }
        }
    }

    public short npc_xhome
    {
        get
        {
            if (IsStatic) { return 0; }
            int val = (int)DataLoader.getValAtAddress(DataBuffer, PTR + 0x16, 16);
            return (short)(DataLoader.ExtractBits(val, 10, 0x3F));
        }
        set
        {
            if (!IsStatic)
            {
                value &= 0x3f; //Keep value in range;
                              //xhome<<9 | yhome << 4 | MobileUnk_0xF_0_3F
                int val = (value << 9) | (npc_yhome << 4) | (MobileUnk_0xF_0_3F & 0xF);
                DataBuffer[PTR + 0x16] = (char)(val & 0xFF);
                DataBuffer[PTR + 0x17] = (char)((val >> 8) & 0xFF);
            }
        }
    }
    public short npc_heading
    {
        get
        {
            if (IsStatic) { return 0; }
            int val = (int)DataLoader.getValAtAddress(map.lev_ark_block.Data, PTR + 0x18, 8);
            return (short)(DataLoader.ExtractBits(val, 0, 0x1F));
        }
        set
        {
            value &= 0x1F;//Keep in range
            //MobileUnk_0x18_5_7<<5 | npc_heading
            int val = (MobileUnk_0x18_5_7 << 5) | (value & 0x1F);
            DataBuffer[PTR + 0x18] = (char)(val);
        }
    }

    public short MobileUnk_0x18_5_7
    {
        get
        {
            if (IsStatic) { return 0; }
            int val = (int)DataLoader.getValAtAddress(map.lev_ark_block.Data, PTR + 0x18, 8);
            return (short)(DataLoader.ExtractBits(val, 5, 0x7));
        }
        set
        {
            value &= 0x7;//Keep in range
            //MobileUnk_0x18_5_7<<5 | npc_heading
            int val = (value << 5) | (npc_heading & 0x1F);
            DataBuffer[PTR + 0x18] = (char)(val);
        }
    }

    public short npc_hunger
    {
        get
        {
            if (IsStatic) { return 0; }
            int val = (int)DataLoader.getValAtAddress(map.lev_ark_block.Data, PTR + 0x19, 8);
            return (short)(DataLoader.ExtractBits(val, 0, 0x3F));
        }
        set
        {
            value &= 0x3F;//Keep in range
            //MobileUnk_0x19_6_3<<6 | npc_hunger
            int val = (MobileUnk_0x19_6_3 << 6) | (value & 0x1F);
            DataBuffer[PTR + 0x19] = (char)(val);
        }
    }

    public short MobileUnk_0x19_6_3
    {
        get
        {
            if (IsStatic) { return 0; }
            int val = (int)DataLoader.getValAtAddress(map.lev_ark_block.Data, PTR + 0x19, 8);
            return (short)(DataLoader.ExtractBits(val, 6, 0x3));
        }
        set
        {
            value &= 0x3;//Keep in range
            //MobileUnk_0x19_6_3<<6 | npc_hunger
            int val = (value << 6) | (npc_hunger & 0x1F);
            DataBuffer[PTR + 0x19] = (char)(val);
        }
    }


    public short npc_whoami
    {
        get
        {
            if (IsStatic) { return 0; }
            return (short)DataLoader.getValAtAddress(map.lev_ark_block.Data, PTR + 0x1a, 8);            
        }
        set
        {
            value &= 0xFF;//Keep in range
            //MobileUnk_0x19_6_3<<6 | npc_hunger
            DataBuffer[PTR + 0x1a] = (char)value;
        }
    }


    /// <summary>
    /// The X position of the projecile object in the world space (when not an NPC)
    /// </summary>
    /// Value is equal to the current (xhome<< 8) + (xpos <<5) +0xFh
    public int CoordinateX
    {
        get
        {
            return (short)DataLoader.getValAtAddress(map.lev_ark_block.Data, PTR + 0xb, 16);
        }
        //Set using function SetCoordinateX as value is made up of multiple parameters
    }


    /// <summary>
    /// The Y position of the projecile object in the world space (when not an NPC)
    /// </summary>
    ///(yhome<<8) + (ypos<<5) +0xFh
    public int CoordinateY
    {
        get
        {
            return (short)DataLoader.getValAtAddress(map.lev_ark_block.Data, PTR + 0xc, 16);
        }
    }


    public int CoordinateZ
    {//(zpos<<3) + 0xFh is stored here
        get
        {
            return (short)DataLoader.getValAtAddress(map.lev_ark_block.Data, PTR + 0xf, 16);
        }
    }

    //Where are these values set???
    public short npc_health = 0;//Is this poisoning?
    public short npc_arms = 0;
    public short npc_power = 0;
    public short npc_name = 0;


    //My additions
    public short InUseFlag//Based on values and no of values in the mobile and static free lists.
    {
    get{return 1;}
    set{}
    }


    public short levelno
    {//Use for unique naming of the object
        get
        {
            if (IsInventory)
            {
                return -1;
            }
            else
            {
                return map.thisLevelNo;
            }
        }
    }


    public short ObjectTileX = TileMap.ObjectStorageTile; //Position of the object on the tilemap
    public short ObjectTileY = TileMap.ObjectStorageTile;
    public long address;


    public ObjectInteraction instance;
    public ObjectLoader parentList;

    //SShock specific stuff
    public int ObjectClass;
    public int ObjectSubClass;
    public int ObjectSubClassIndex;

    public int Angle1;
    public int Angle2;
    public int Angle3;

    public int sprite;
    public int State;
    public int unk1;//Probably a texture index.

    public int[] shockProperties = new int[10]; //Shared properties memory
    public int[] conditions = new int[4];
    public int TriggerAction;//Needs to be split into a property.
    public int TriggerOnce;

    //public short[] NPC_DATA=new short[19];


    /// <summary>
    /// The GUID of this object instance. To guarantee unique object names.
    /// </summary>
    public System.Guid guid;



    /// <summary>
    /// Offset to object in file data
    /// </summary>
    public int PTR
    {
        get
        {
            if (IsInventory)
            {
                return 0;//Always
                //return (index-1) * 8;
            }
            else
            {
                if (index < 256)
                {//Mobile, 27 bytes per object
                    return 0x4000 + (index * 27);
                }
                else
                {//static, 8 bytes per object
                    return 0x5b00 + ((index - 256) * 8);
                }
            }
        }
    }

    /// <summary>
    /// Initialise the object class
    /// </summary>
    /// <param name="index"></param>
    /// <param name="map"></param>
    public ObjectLoaderInfo(int _index, TileMap _map, bool isWorldObject)
    {
        index = _index;
        map = _map;
        guid=System.Guid.NewGuid();
        if (isWorldObject)
        {
            parentList = GameWorldController.CurrentObjectList();
        }
        else
        {
            parentList = GameWorldController.instance.inventoryLoader;
        }
    }

    //public ObjectLoaderInfo(int _index)
    //{//for shock to compile but possible crash
    //    index = _index;
    //    guid = System.Guid.NewGuid();
    //}

    /// <summary>
    /// Gets the type of the item from object masters. UWE object type codes.
    /// </summary>
    /// <returns>The item type.</returns>
    public int GetItemType()
    {
        return GameWorldController.instance.objectMaster.objProp[item_id].type;
    }

    /// <summary>
    /// resets all properties to zero to maintain compatability with UW2
    /// </summary>
    public static void CleanUp(ObjectLoaderInfo obj)
    {
        //TODO:test if this is needed for mobile objects as well.

        obj.item_id = 0;
        obj.flags = 0;
        obj.enchantment = 0;
        obj.doordir = 0;
        obj.invis = 0;
        obj.is_quant = 0;
        obj.zpos = 0;
        obj.xpos = 0;
        obj.ypos = 0;
        obj.heading = 0;
        obj.quality = 0;
        obj.next = 0;
        obj.owner = 0;
        obj.link = 0;
    }



    public void Set()
    {
        InUseFlag = 1;
    }

    public void Unset()
    {
        InUseFlag = 0;
    }

    public bool isInUse()
    {
        return (InUseFlag == 1);
    }

    public string getDesc()
    {
        return GameWorldController.instance.objectMaster.objProp[item_id].desc;
    }

    public int useSpriteValue()
    {
        return GameWorldController.instance.objectMaster.objProp[item_id].useSprite;
    }

    public int StartFrameValue()
    {
        return GameWorldController.instance.objectMaster.objProp[item_id].startFrame;
    }
     
}

