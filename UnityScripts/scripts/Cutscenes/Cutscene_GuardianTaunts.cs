using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene_GuardianTaunts : Cuts {

    protected void InitGuardianTaunt(string csFile, int BlockNo, string sfx)
    {
        noOfImages = 2;
        ImageFrames[0] = csFile;
        ImageTimes[0] = 0f;
        ImageLoops[0] = -1;

        ImageFrames[1] = "Anim_Base";//To finish.
        ImageTimes[1] = 5f;
        ImageLoops[1] = -1;

        StringBlockNo = BlockNo;
        noOfSubs = 1;
        SubsStringIndices[0] = 0;

        noOfAudioClips = 1;
        AudioTimes[0] = 0.5f;
        // AudioClipName[0] = _RES + sfx;
        AudioClipName[0] = Loader.BasePath + "SOUND" + sep + sfx;

        SyncSubtitles();
    }

}
