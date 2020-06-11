using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene_ThisWorldIsMine : Cutscene_GuardianTaunts
{

    public override void Awake()
    {
        base.Awake();
        InitGuardianTaunt("cs034_n01", 3079, "BSP12.VOC");
    }
}
