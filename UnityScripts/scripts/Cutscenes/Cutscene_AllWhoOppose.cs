using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene_AllWhoOppose : Cutscene_GuardianTaunts {


    public override void Awake()
    {
        base.Awake();
        InitGuardianTaunt("cs037_n01", 3078, "/sfx/voice/BSP07");
    }


}
