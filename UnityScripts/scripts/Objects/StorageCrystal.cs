using UnityEngine;
using System.Collections;

public class StorageCrystal : object_base
{
    public string DisplayName;

    //	static string[] CrystalNames = {
    //				"Q6Y6","O5Y7","M4Y8","K3Y9","I2Y0","G1Y1","E0Y2","C9Y3","A8Y4","Y7Y5","W6Y6","U5Y7","S4Y8","Q3Y9","02Y0","M1Y1",
    //				"K0Y2","I9Y3","G8Y4","E7Y5","C6Y6","A5Y7","Y4Y8","W3Y9","U2Y0","S1Y1","Q0Y2","09Y3","M8Y4","K7Y5","I6Y6","G5Y7",
    //				"E4Y8","C3Y9","A2Y0","Y1Y1","W0Y2","U9Y3"		
    //	};



    protected override void Start()
    {
        base.Start();
        DisplayName = BuildCrystalName(quality);
    }

    /// <summary>
    /// Builds the name of the crystal.
    /// </summary>
    /// <returns>The crystal name.</returns>
    /// <param name="quality">Quality.</param>
    /// 		//Crystal names pattern
    ///Starts at Q,6,Y,6
    ///Char 1 - letters goes down by 2 each time
    ///Char 2 - decrement by 1
    ///Char 3 - always Y
    ///Char 4 - increment by 1
    public string BuildCrystalName(int quality)
    {
        int[] initial = { 16, 6, 24, 6 };
        //First char
        int Offset = quality * 2;
        Offset = -(Offset % 26);
        if (initial[0] + Offset < 0)
        {
            initial[0] = initial[0] + Offset + 26;
        }
        else
        {
            initial[0] = initial[0] + Offset;
        }

        //Second Char
        Offset = quality;
        Offset = -(Offset % 10);
        if (initial[1] + Offset < 0)
        {
            initial[1] = initial[1] + Offset + 10;
        }
        else
        {
            initial[1] = initial[1] + Offset;
        }

        //fourth char
        Offset = quality;
        Offset = +(Offset % 10);
        if (initial[3] + Offset > 10)
        {
            initial[3] = initial[3] + Offset - 10;
        }
        else
        {
            initial[3] = initial[3] + Offset;
        }


        return
            ((char)(initial[0] + 65)).ToString()
            +
            initial[1]
            +
            ((char)(initial[2] + 65)).ToString()
            +
            initial[3]
            ;
    }


    public override bool use()
    {
        if (objInt().PickedUp)
        {
            if (CurrentObjectInHand == null)
            {
                UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, 352) + DisplayName);
                return true;
            }
        }
        return base.use();
    }

    public override string ContextMenuDesc(int item_id)
    {
        return StringController.instance.GetString(1, 352) + DisplayName;
    }
}
