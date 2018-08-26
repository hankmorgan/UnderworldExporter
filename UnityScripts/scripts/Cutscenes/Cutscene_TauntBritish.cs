using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene_TauntBritish : Cuts {

    //CS040.N01
    public override void Awake()
    {
        base.Awake();
        noOfImages = 2;
        ImageFrames[0] = "CS040_N01";
        ImageTimes[0] = 0f;
        ImageLoops[0] = -1;

        ImageFrames[1] = "Anim_Base";//To finish.
        ImageTimes[1] = 12f;
        ImageLoops[1] = -1;

        StringBlockNo = 3104;
        noOfSubs = 4;
        SubsStringIndices[0] = 0;
        SubsStringIndices[1] = 1;
        SubsStringIndices[2] = 2;
        SubsStringIndices[3] = 3;

        SubsTimes[0] = 0.2f;
        SubsTimes[1] = 3f;
        SubsTimes[2] = 6f;
        SubsTimes[3] = 9f;

        SubsDuration[0] = 2.6f;
        SubsDuration[1] = 2.6f;
        SubsDuration[2] = 2.6f;
        SubsDuration[3] = 2.6f;

    }
}
