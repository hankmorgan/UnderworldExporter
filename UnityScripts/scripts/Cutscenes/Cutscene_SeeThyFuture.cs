using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene_SeeThyFuture : Cutscene_GuardianTaunts {

    public override void Awake()
    {
        base.Awake();
        InitGuardianTaunt("cs037_n01", 3076, "BSP05.VOC");
    }
}
