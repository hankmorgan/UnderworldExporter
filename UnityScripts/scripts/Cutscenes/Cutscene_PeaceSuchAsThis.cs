using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene_PeaceSuchAsThis : Cutscene_GuardianTaunts {

    public override void Awake()
    {//cs034
        base.Awake();
        InitGuardianTaunt("cs034_n01", 3077, "BSP06.VOC");
    }
}
