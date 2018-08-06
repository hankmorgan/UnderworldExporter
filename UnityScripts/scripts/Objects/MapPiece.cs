using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Copies a map chunk to another level map
/// </summary>
public class MapPiece : object_base {

    public override bool use()
    {
        UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, 9));
        Debug.Log("Copying map chunck " + objInt().link);
        objInt().consumeObject();
        return true;
    }
}
