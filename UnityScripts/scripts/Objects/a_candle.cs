using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// lightsource variant for UW2 which can be eaten!
/// </summary>
public class a_candle : LightSource
{


    public override bool Eat()
    {
        if (IsOn())
        {
            //do nothinbg
            return true;
        }
        else
        {
            //000~001~245~You eat the candle, but doubt that it was good for you. \n
            UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, 245));
            objInt().consumeObject();
            return true;
        }
    }

}

