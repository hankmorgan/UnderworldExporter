using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

/// <summary>
/// Used for storing levark file data
/// </summary>
public class LevArk : Loader {
    
    
    
    /// <summary>
    /// The lev ark file data.
    /// </summary>
    public static char[] lev_ark_file_data;

    /// <summary>
    /// Writes a lev ark file based on a rebuilding of the data.
    /// </summary>
    /// <param name="slotNo">Slot no.</param>
    /// 320 blocks
    /// 80 level maps - to be decompressed
    /// 80 texture maps - to copy
    /// 80 automaps - to copy for the moment
    /// 80 map notes - top copy for the moment
    public static void WriteBackLevArkUW2(int slotNo)
    {
            int NoOfBlocks = 320;
        DataLoader.UWBlock[] blockData = new DataLoader.UWBlock[NoOfBlocks];

        //First update the object list so as to match indices properly	
        ObjectLoader.UpdateObjectList(CurrentTileMap(), CurrentObjectList());

        //First block is always here.
        long AddressToCopyFrom = 0;
        long ReadDataLen = 0;

        //Read in the data for the 80 tile/object maps
        for (int l = 0; l <= GameWorldController.instance.Tilemaps.GetUpperBound(0); l++)
        {
            blockData[l].CompressionFlag = (int)DataLoader.getValAtAddress(lev_ark_file_data, 6 + (l * 4) + (NoOfBlocks * 4), 32);
            blockData[l].DataLen = DataLoader.getValAtAddress(lev_ark_file_data, 6 + (l * 4) + (NoOfBlocks * 8), 32);
            blockData[l].ReservedSpace = DataLoader.getValAtAddress(lev_ark_file_data, 6 + (l * 4) + (NoOfBlocks * 12), 32);
            if (GameWorldController.instance.Tilemaps[l] != null)
            {
                long UnPackDatalen = 0;
                blockData[l].CompressionFlag = DataLoader.UW2_NOCOMPRESSION;
                blockData[l].Data = GameWorldController.instance.Tilemaps[l].TileMapToBytes(lev_ark_file_data, out UnPackDatalen);
                //blockData[l].DataLen=blockData[l].Data.GetUpperBound(0)+1;//32279;//
                blockData[l].DataLen = UnPackDatalen;
                //if (blockData[l].ReservedSpace< blockData[l].DataLen)
                //{
                //Debug.Log("Changing reserved space for block " + l + " to datalen was " + blockData[l].ReservedSpace + " now "  + blockData[l].DataLen );
                //blockData[l].ReservedSpace= blockData[l].DataLen;			
                //}
            }///31752
            else
            {//Copy data from file.
                AddressToCopyFrom = DataLoader.getValAtAddress(lev_ark_file_data, (l * 4) + 6, 32);
                if (AddressToCopyFrom != 0)
                {//Only copy a block with data										
                    blockData[l].Data = CopyData(AddressToCopyFrom, blockData[l].ReservedSpace);//31752
                }
                else
                {
                    blockData[l].DataLen = 0;
                }
            }
        }

        //read in the texture maps
        //TODO: At the moment this is just a straight copy of this information
        for (int l = 0; l <= GameWorldController.instance.Tilemaps.GetUpperBound(0); l++)
        {
            AddressToCopyFrom = DataLoader.getValAtAddress(lev_ark_file_data, (l * 4) + 6 + (80 * 4), 32);
            blockData[l + 80].CompressionFlag = (int)DataLoader.getValAtAddress(lev_ark_file_data, (l * 4) + 6 + (80 * 4) + (NoOfBlocks * 4), 32);
            blockData[l + 80].ReservedSpace = DataLoader.getValAtAddress(lev_ark_file_data, (l * 4) + 6 + (80 * 4) + (NoOfBlocks * 12), 32);
            ReadDataLen = DataLoader.getValAtAddress(lev_ark_file_data, (l * 4) + 6 + (80 * 4) + (NoOfBlocks * 8), 32); //+ (NoOfBlocks*4)				

            if (AddressToCopyFrom != 0)
            {
                blockData[l + 80].Data = CopyData(AddressToCopyFrom, ReadDataLen);
                blockData[l + 80].DataLen = blockData[l + 80].Data.GetUpperBound(0) + 1;
            }
            else
            {
                blockData[l + 80].DataLen = 0;
            }
        }

        //read in the automaps
        for (int l = 0; l <= GameWorldController.instance.Tilemaps.GetUpperBound(0); l++)
        {
            if (GameWorldController.instance.AutoMaps[l] != null)
            {
                blockData[l + 160].CompressionFlag = DataLoader.UW2_NOCOMPRESSION;
                blockData[l + 160].Data = GameWorldController.instance.AutoMaps[l].AutoMapVisitedToBytes();
                blockData[l + 160].DataLen = blockData[l + 160].Data.GetUpperBound(0) + 1;
                blockData[l + 160].ReservedSpace = blockData[l + 160].DataLen;
            }
            else
            {//Just copy the data from the old ark to the new ark
                AddressToCopyFrom = DataLoader.getValAtAddress(lev_ark_file_data, (l * 4) + 6 + (160 * 4), 32);
                blockData[l + 160].CompressionFlag = (int)DataLoader.getValAtAddress(lev_ark_file_data, (l * 4) + 6 + (160 * 4) + (NoOfBlocks * 4), 32);
                ReadDataLen = DataLoader.getValAtAddress(lev_ark_file_data, (l * 4) + 6 + (160 * 4) + (NoOfBlocks * 8), 32); //+ (NoOfBlocks*4)
                blockData[l + 160].ReservedSpace = DataLoader.getValAtAddress(lev_ark_file_data, (l * 4) + 6 + (160 * 4) + (NoOfBlocks * 12), 32);

                if (AddressToCopyFrom != 0)
                {
                    blockData[l + 160].Data = CopyData(AddressToCopyFrom, ReadDataLen);
                    blockData[l + 160].DataLen = blockData[l + 160].Data.GetUpperBound(0) + 1;
                }
                else
                {
                    blockData[l + 160].DataLen = 0;
                }
            }
        }


        //read in the automap notes
        //TODO: At the moment this is just a straight copy of this information
        for (int l = 0; l <= GameWorldController.instance.Tilemaps.GetUpperBound(0); l++)
        {
            if (GameWorldController.instance.AutoMaps[l] != null)
            {
                blockData[l + 240].Data = GameWorldController.instance.AutoMaps[l].AutoMapNotesToBytes();
                if (blockData[l + 240].Data != null)
                {
                    blockData[l + 240].CompressionFlag = DataLoader.UW2_NOCOMPRESSION;
                    blockData[l + 240].DataLen = blockData[l + 240].Data.GetUpperBound(0) + 1;
                    blockData[l + 240].ReservedSpace = blockData[l + 240].DataLen;
                }
                else
                {//just copy
                    AddressToCopyFrom = DataLoader.getValAtAddress(lev_ark_file_data, (l * 4) + 6 + (240 * 4), 32);
                    blockData[l + 240].CompressionFlag = (int)DataLoader.getValAtAddress(lev_ark_file_data, (l * 4) + 6 + (240 * 4) + (NoOfBlocks * 4), 32);
                    ReadDataLen = DataLoader.getValAtAddress(lev_ark_file_data, (l * 4) + 6 + (240 * 4) + (NoOfBlocks * 8), 32); //+ (NoOfBlocks*4)
                    blockData[l + 240].ReservedSpace = DataLoader.getValAtAddress(lev_ark_file_data, (l * 4) + 6 + (240 * 4) + (NoOfBlocks * 12), 32);
                    if (AddressToCopyFrom != 0)
                    {
                        blockData[l + 240].Data = CopyData(AddressToCopyFrom, ReadDataLen);
                        blockData[l + 240].DataLen = blockData[l + 240].Data.GetUpperBound(0) + 1;
                    }
                    else
                    {
                        blockData[l + 240].DataLen = 0;
                    }
                }

            }
            else
            {//just copy.
                AddressToCopyFrom = DataLoader.getValAtAddress(lev_ark_file_data, (l * 4) + 6 + (240 * 4), 32);
                blockData[l + 240].CompressionFlag = (int)DataLoader.getValAtAddress(lev_ark_file_data, (l * 4) + 6 + (240 * 4) + (NoOfBlocks * 4), 32);
                ReadDataLen = DataLoader.getValAtAddress(lev_ark_file_data, (l * 4) + 6 + (240 * 4) + (NoOfBlocks * 8), 32); //+ (NoOfBlocks*4)
                blockData[l + 240].ReservedSpace = DataLoader.getValAtAddress(lev_ark_file_data, (l * 4) + 6 + (240 * 4) + (NoOfBlocks * 12), 32);
                if (AddressToCopyFrom != 0)
                {
                    blockData[l + 240].Data = CopyData(AddressToCopyFrom, ReadDataLen);
                    blockData[l + 240].DataLen = blockData[l + 240].Data.GetUpperBound(0) + 1;
                }
                else
                {
                    blockData[l + 240].DataLen = 0;
                }
            }

        }


        blockData[0].Address = 5126;//This will always be the same.
        long prevAddress = blockData[0].Address;
        long prevSize = Math.Max(blockData[0].ReservedSpace, blockData[0].DataLen);
        //Work out the block addresses.
        for (int i = 1; i < blockData.GetUpperBound(0); i++)
        {
            if (blockData[i].DataLen != 0)//This block has data and needs to be written.
            {
                blockData[i].Address = prevAddress + prevSize;
                prevAddress = blockData[i].Address;
                prevSize = Math.Max(blockData[i].ReservedSpace, blockData[i].DataLen);
            }
            else
            {
                blockData[i].Address = 0;
            }
        }



        //Data is copied. now begin writing the output file
        FileStream file = File.Open(Loader.BasePath + "SAVE" + slotNo + sep + "LEV.ARK", FileMode.Create);
        BinaryWriter writer = new BinaryWriter(file);
        long add_ptr = 0;

        add_ptr += DataLoader.WriteInt8(writer, 0x40);
        add_ptr += DataLoader.WriteInt8(writer, 0x01);
        add_ptr += DataLoader.WriteInt8(writer, 0x0);//1
        add_ptr += DataLoader.WriteInt8(writer, 0x0);//2
        add_ptr += DataLoader.WriteInt8(writer, 0x0);//3
        add_ptr += DataLoader.WriteInt8(writer, 0x0);//4

        //Now write block addresses
        for (int i = 0; i < 320; i++)
        {//write block addresses
            add_ptr += DataLoader.WriteInt32(writer, blockData[i].Address);
        }

        //Now write compression flags
        for (int i = 320; i < 640; i++)
        {//write block compression flags
            add_ptr += DataLoader.WriteInt32(writer, blockData[i - 320].CompressionFlag);
        }

        //Now write data lengths
        for (int i = 960; i < 1280; i++)
        {//write block data lengths
            add_ptr += DataLoader.WriteInt32(writer, blockData[i - 960].DataLen);
        }


        for (int i = 1280; i < 1600; i++)
        {//write block data reservations
            add_ptr += DataLoader.WriteInt32(writer, blockData[i - 1280].ReservedSpace);
        }

        for (long freespace = add_ptr; freespace < blockData[0].Address; freespace++)
        {//write freespace to fill up to the final block.
            add_ptr += DataLoader.WriteInt8(writer, 0);
        }


        //Now be brave and write all my blocks!!!
        for (int i = 0; i <= blockData.GetUpperBound(0); i++)
        {
            if (blockData[i].Data != null)//?
            {
                if (add_ptr < blockData[i].Address)
                {
                    while (add_ptr < blockData[i].Address)
                    {//Fill whitespace until next block address.
                        add_ptr += DataLoader.WriteInt8(writer, 0);
                    }
                }
                else
                {
                    if (add_ptr > blockData[i].Address)
                    {
                        Debug.Log("Writing block " + i + " at " + add_ptr + " should be " + blockData[i].Address);
                    }
                }
                Debug.Log("Writing block " + i + " datalen " + blockData[i].DataLen + " ubound=" + blockData[i].Data.GetUpperBound(0));
                //for (long a =0; a<=blockData[i].Data.GetUpperBound(0); a++)
                int blockUbound = blockData[i].Data.GetUpperBound(0);
                for (long a = 0; a < blockData[i].DataLen; a++)
                {
                    if (a <= blockUbound)
                    {
                        add_ptr += DataLoader.WriteInt8(writer, (long)blockData[i].Data[a]);
                    }
                    else
                    {
                        add_ptr += DataLoader.WriteInt8(writer, 0);
                    }
                }
            }
        }
        file.Close();
        return;
    }

    /// <summary>
    /// Writes a lev ark file based on a rebuilding of the data.
    /// </summary>
    /// <param name="slotNo">Slot no.</param>
    ///<9 blocks level tilemap/master object list>
    ///<9 blocks object animation overlay info>
    ///<9 blocks texture mapping>
    ///<9 blocks automap infos>
    ///<9 blocks map notes>
    ///The remaining 9 x 10 blocks are unused.
    /// 
    public static void WriteBackLevArkUW1(int slotNo)
    {
        DataLoader.UWBlock[] blockData = new DataLoader.UWBlock[45];

        //First update the object list so as to match indices properly
        ObjectLoader.UpdateObjectList(CurrentTileMap(), CurrentObjectList());

        //First block is always here.
        long AddressToCopyFrom = 0;

        //Read in the data for the 9 tile/object maps
        for (int l = 0; l <= GameWorldController.instance.Tilemaps.GetUpperBound(0); l++)
        {
            if (GameWorldController.instance.Tilemaps[l] != null)
            {
                long UnPackDatalen = 0;
                blockData[l].Data = GameWorldController.instance.Tilemaps[l].TileMapToBytes(lev_ark_file_data, out UnPackDatalen);
                blockData[l].DataLen = blockData[l].Data.GetUpperBound(0) + 1;
            }///31752
            else
            {
                AddressToCopyFrom = DataLoader.getValAtAddress(lev_ark_file_data, (l * 4) + 2, 32);
                blockData[l].Data = CopyData(AddressToCopyFrom, 31752);//TileMap.TileMapSizeX*TileMap.TileMapSizeY*4  +  256*27 + 768*8);	
                blockData[l].DataLen = blockData[l].Data.GetUpperBound(0) + 1;
            }
        }

        //Read in the data for the animation overlays
        for (int l = 0; l <= GameWorldController.instance.Tilemaps.GetUpperBound(0); l++)
        {
            AddressToCopyFrom = DataLoader.getValAtAddress(lev_ark_file_data, ((l + 9) * 4) + 2, 32);
            blockData[l + 9].Data = CopyData(AddressToCopyFrom, 64 * 6);
            blockData[l + 9].DataLen = blockData[l + 9].Data.GetUpperBound(0) + 1;
        }

        //read in the texture maps
        for (int l = 0; l <= GameWorldController.instance.Tilemaps.GetUpperBound(0); l++)
        {
            if (GameWorldController.instance.Tilemaps[l] != null)
            {
                blockData[l + 18].Data = GameWorldController.instance.Tilemaps[l].TextureMapToBytes();
                blockData[l + 18].DataLen = blockData[l + 18].Data.GetUpperBound(0) + 1;
            }
            else
            {
                AddressToCopyFrom = DataLoader.getValAtAddress(lev_ark_file_data, ((l + 18) * 4) + 2, 32);
                blockData[l + 18].Data = CopyData(AddressToCopyFrom, 0x7a);
                blockData[l + 18].DataLen = blockData[l + 18].Data.GetUpperBound(0) + 1;
            }
        }

        //read in the auto maps
        for (int l = 0; l <= GameWorldController.instance.AutoMaps.GetUpperBound(0); l++)
        {
            blockData[l + 27].Data = GameWorldController.instance.AutoMaps[l].AutoMapVisitedToBytes();
            if (blockData[l + 27].Data != null)
            {
                blockData[l + 27].DataLen = blockData[l + 27].Data.GetUpperBound(0) + 1;
            }
            else
            {
                blockData[l + 27].DataLen = 0;
            }
        }


        //read in the auto maps notes
        for (int l = 0; l <= GameWorldController.instance.AutoMaps.GetUpperBound(0); l++)
        {
            blockData[l + 36].Data = GameWorldController.instance.AutoMaps[l].AutoMapNotesToBytes();
            if (blockData[l + 36].Data != null)
            {
                blockData[l + 36].DataLen = blockData[l + 36].Data.GetUpperBound(0) + 1;
            }
            else
            {
                blockData[l + 36].DataLen = 0;
            }
        }

        blockData[0].Address = 542;
        long prevAddress = blockData[0].Address;
        //Work out the block addresses.
        for (int i = 1; i < blockData.GetUpperBound(0); i++)
        {//This algorithm is probably wrong but only works because all blocks are in use!
            if (blockData[i - 1].DataLen != 0)
            {
                blockData[i].Address = prevAddress + blockData[i - 1].DataLen;
                prevAddress = blockData[i].Address;
            }
            else
            {
                blockData[i].Address = 0;
            }
        }


        FileStream file = File.Open(Loader.BasePath + "SAVE" + slotNo + sep + "LEV.ARK", FileMode.Create);
        BinaryWriter writer = new BinaryWriter(file);
        long add_ptr = 0;
        add_ptr += DataLoader.WriteInt8(writer, 0x87);
        add_ptr += DataLoader.WriteInt8(writer, 0);
        for (int i = 0; i <= blockData.GetUpperBound(0); i++)
        {//write block addresses
            add_ptr += DataLoader.WriteInt32(writer, blockData[i].Address);
        }

        for (long freespace = add_ptr; freespace < blockData[0].Address; freespace++)
        {//write freespace
            add_ptr += DataLoader.WriteInt8(writer, 0);
        }

        //Now be brave and write all my blocks!!!
        for (int i = 0; i <= blockData.GetUpperBound(0); i++)
        {
            if (blockData[i].Data != null)
            {
                for (long a = 0; a <= blockData[i].Data.GetUpperBound(0); a++)
                {
                    add_ptr += DataLoader.WriteInt8(writer, (long)blockData[i].Data[a]);
                }
            }
        }

        file.Close();
        return;
    }



    /// <summary>
    /// Copies the data from the cached lev ark file to a new array;
    /// </summary>
    /// <returns>The data.</returns>
    /// <param name="address">Address.</param>
    /// <param name="length">Length.</param>
    public static char[] CopyData(long address, long length)
    {
        char[] DataToCopy = new char[length];

        for (int i = 0; i <= DataToCopy.GetUpperBound(0); i++)
        {
            DataToCopy[i] = lev_ark_file_data[address + i];
        }
        return DataToCopy;
    }

}
