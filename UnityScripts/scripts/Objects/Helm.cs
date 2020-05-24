using UnityEngine;
using System.Collections;

public class Helm : Armour {

    public override int GetActualSpellIndex()
    {
        if (link - 512 >= 256) //?Is this right??
        {
            return link - 240;
        }
        else
        {
            return link - 512;
        }		
	}

}
