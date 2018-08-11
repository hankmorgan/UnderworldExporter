using UnityEngine;
using System.Collections;

/// <summary>
/// Sample Cutscene
/// </summary>
public class Cutscene_Intro : Cuts {

	public override void Awake()
    {
        base.Awake();
        //Sample script (of sorts) Plays some clips from the intro.
        //Prints a couple of subtitles and plays an audio clip.
        //Define the array values here.

        noOfImages = 24;

        ImageFrames[0] = "cs000_n01";//Fade to black
        ImageTimes[0] = 0.0f;
        ImageLoops[0] = -1;

        ImageFrames[1] = "cs000_n06";//Fade in Garamon
        ImageTimes[1] = 14f;
        ImageLoops[1] = -1;

        ImageFrames[2] = "cs000_n03";//Garamon speaks
        ImageTimes[2] = 18.0f;
        ImageLoops[2] = -1;

        ImageFrames[3] = "cs000_n03";//Garamon speaks
        ImageTimes[3] = 21.0f;
        ImageLoops[3] = -1;

        ImageFrames[4] = "cs000_n04";//More Garamon speaks
        ImageTimes[4] = 24.0f;
        ImageLoops[4] = -1;


        ImageFrames[5] = "cs000_n05";//Even More Garamon speaks
        ImageTimes[5] = 27.0f;
        ImageLoops[5] = -1;

        ImageFrames[6] = "cs000_n07";//Garamon spirals away
        ImageTimes[6] = 32.0f;
        ImageLoops[6] = 0;

        ImageFrames[7] = "cs000_n10";//Bedroom sequence
        ImageTimes[7] = 38.0f;
        ImageLoops[7] = 0;

        ImageFrames[8] = "cs000_n15";//Colwyn speaks
        ImageTimes[8] = 65.0f;
        ImageLoops[8] = -1;

        ImageFrames[9] = "cs000_n01";//Fade to black
        ImageTimes[9] = 75.0f;
        ImageLoops[9] = -1;

        ImageFrames[10] = "AlmricSitting";//Almric on Throne
        ImageTimes[10] = 80.0f;
        ImageLoops[10] = -1;

        ImageFrames[11] = "cs000_n11";//Almric speaks
        ImageTimes[11] = 85.0f;
        ImageLoops[11] = -1;

        ImageFrames[12] = "cs000_n15";//Colwyn speaks
        ImageTimes[12] = 87.0f;
        ImageLoops[12] = -1;

        ImageFrames[13] = "cs000_n11";//Almric on Throne //i see
        ImageTimes[13] = 100.0f;
        ImageLoops[13] = -1;

        ImageFrames[14] = "AlmricSitting";//Almric on Throne //turning his eyes
        ImageTimes[14] = 103.0f;
        ImageLoops[14] = -1;

        ImageFrames[15] = "cs000_n12";//Close on Almric //i was warned
        ImageTimes[15] = 109.0f;
        ImageLoops[15] = -1;

        ImageFrames[16] = "AlmricSitting";//Almric on Throne //You explain you are the avatar
        ImageTimes[16] = 133.0f;
        ImageLoops[16] = -1;

        ImageFrames[17] = "cs000_n12";//Almric close up //stories tell.
        ImageTimes[17] = 138.0f;
        ImageLoops[17] = -1;

        ImageFrames[18] = "cs000_n21";//Mountain intro
        ImageTimes[18] = 176.0f;
        ImageLoops[18] = 0;

        ImageFrames[19] = "cs000_n20";//Mountain walk
        ImageTimes[19] = 179.8f;
        ImageLoops[19] = 0;

        ImageFrames[20] = "cs000_n22";//Abyss door opens
        ImageTimes[20] = 182.3f;
        ImageLoops[20] = 0;

        ImageFrames[21] = "cs000_n24";//Colwyn outside
        ImageTimes[21] = 185.8f;
        ImageLoops[21] = -1;

        ImageFrames[22] = "cs000_n23";//Door closes
        ImageTimes[22] = 199.0f;
        ImageLoops[22] = 0;

        ImageFrames[23] = "Anim_Base";//To finish.
        ImageTimes[23] = 203.0f;
        ImageLoops[23] = -1;


        StringBlockNo = 3072;
        noOfSubs = 41;

        //Narrator begins
        //at last you are asleep
        SubsStringIndices[0] = 0;
        //SubsDuration[0]=1.8f;

        //For 3 nights
        SubsStringIndices[1] = 1;
        //SubsDuration[1]=7.3f;

        //Sickening sense of deja vu
        SubsStringIndices[2] = 2;
        //SubsDuration[2]=3.5f;

        //Garamon begins, treachery & doom
        SubsStringIndices[3] = 4;
        //SubsDuration[3]=2.6f;

        //My brother will
        SubsStringIndices[4] = 5;
        //SubsDuration[4]=3.6f;

        //With a sickening sense
        SubsStringIndices[5] = 6;
        //SubsDuration[5]=2.7f;

        //Narrator
        //Sure that the ghost will
        SubsStringIndices[6] = 7;
        //SubsDuration[6]=4.4f;

        //Ariel screams
        SubsStringIndices[7] = 8;
        SubsDuration[7] = 1.2f;

        //A visitor
        SubsStringIndices[8] = 9;
        //SubsDuration[8]=2.9f;

        //I'd suspect my brother
        SubsStringIndices[9] = 10;
        //SubsDuration[9]=3.2f;

        //Shall draw the hounds
        SubsStringIndices[10] = 11;
        //SubsDuration[10]=3.5f;

        //Below a creature
        SubsStringIndices[11] = 12;
        //SubsDuration[11]=5.3f;

        //what have you done.
        SubsStringIndices[12] = 13;
        //SubsDuration[12]=2.5f;

        //Dropped to below
        SubsStringIndices[13] = 14;
        //SubsDuration[13]=2.2f;

        //he'll nay escape me
        SubsStringIndices[14] = 15;
        //SubsDuration[14]=3.5f;

        //Several tense hours later
        SubsStringIndices[15] = 16;
        //SubsDuration[15]=3.1f;

        //Ignoring you
        SubsStringIndices[16] = 17;
        SubsDuration[16] = 2.4f;

        //What news
        SubsStringIndices[17] = 18;
        //SubsDuration[17]=1.7f;

        //Forgive us
        SubsStringIndices[18] = 19;
        //SubsDuration[18]=1.1f;

        //Foul creature escaped
        SubsStringIndices[19] = 20;
        SubsDuration[19] = 4.0f;

        //A score gave chase
        SubsStringIndices[20] = 21;
        //SubsDuration[20]=4.0f;

        //We were attacked
        SubsStringIndices[21] = 22;
        //SubsDuration[21]=2.4f;

        //Only 3 survived
        SubsStringIndices[22] = 23;
        SubsDuration[22] = 1.4f;

        //I see
        SubsStringIndices[23] = 24;
        //SubsDuration[23]=1.0f;

        //Turning his eyes
        SubsStringIndices[24] = 25;
        //SubsDuration[24]=2.3f;

        //I was warned
        SubsStringIndices[25] = 26;
        //SubsDuration[25]=2.1f;

        //Last fortnight
        SubsStringIndices[26] = 27;
        //SubsDuration[26]=5.3f;

        //Guard thy daughter
        SubsStringIndices[27] = 28;
        //SubsDuration[27]=6.2f;

        //I posted guards
        SubsStringIndices[28] = 29;
        //SubsDuration[28]=4.2f;

        //They say thou did drop
        SubsStringIndices[29] = 30;
        //SubsDuration[29]=4.5f;

        //You explain you are the avatar
        SubsStringIndices[30] = 31;
        //SubsDuration[30]=2.9f;

        //Whether you speak truth
        SubsStringIndices[31] = 32;
        //SubsDuration[31]=3.9f;

        //Stories tell of the coming
        SubsStringIndices[32] = 33;
        //SubsDuration[32]=5.4f;

        //If you art truly
        SubsStringIndices[33] = 34;
        //SubsDuration[33]=4.3f;

        //None here can survive the abyss.
        SubsStringIndices[34] = 35;
        //SubsDuration[34]=3.8f;

        //My mind is set
        SubsStringIndices[35] = 36;
        //SubsDuration[35]=3.9f;

        //Return here with my daughter
        SubsStringIndices[36] = 37;
        //SubsDuration[36]=3.9f;

        //If you do not return
        SubsStringIndices[37] = 38;
        //SubsDuration[37]=5.6f;

        //This be the foul pits 
        SubsStringIndices[38] = 39;
        //SubsDuration[38]=4.9f;

        //I will shut thee in and 
        SubsStringIndices[39] = 40;
        //SubsDuration[39]=4.6f;

        //Otherwise will remain shut forever
        SubsStringIndices[40] = 41;
        //SubsDuration[40]=2.7f;


        noOfAudioClips = 41;

        //At last you are asleep=26
        AudioTimes[0] = 0.0f;
        AudioClipName[0] = _RES + "/sfx/voice/26";//1.8s

        //for 3 nights each attem=27
        AudioTimes[1] = AudioTimes[0] + 1.8f;
        AudioClipName[1] = _RES + "/sfx/voice/27"; //7.3s

        //deja vu.=28
        AudioTimes[2] = AudioTimes[1] + 7.4f;//9.1f;
        AudioClipName[2] = _RES + "/sfx/voice/28";//3.5s

        //Treachery & doom=23
        //AudioTimes[3]=18.0f;
        AudioTimes[3] = ImageTimes[2];
        AudioClipName[3] = _RES + "/sfx/voice/23";//2.6s

        //My brother=24
        //AudioTimes[4]=21.0f;
        AudioTimes[4] = ImageTimes[3] + 1f;
        AudioClipName[4] = _RES + "/sfx/voice/24";//3.6s

        //Brit in peril=25
        //AudioTimes[5]=27.0f;
        AudioTimes[5] = ImageTimes[5];
        AudioClipName[5] = _RES + "/sfx/voice/25";//2.7s

        //sure that the ghost=30
        //AudioTimes[6]=30.0f;
        AudioTimes[6] = ImageTimes[6];
        AudioClipName[6] = _RES + "/sfx/voice/30";//4.4s

        //scream=31
        AudioTimes[7] = ImageTimes[6] + 4.5f;
        AudioClipName[7] = _RES + "/sfx/voice/31";//1.2s

        //a visitor=37
        AudioTimes[8] = ImageTimes[7];//42.0f;
        AudioClipName[8] = _RES + "/sfx/voice/37";//2.9

        //were he not dead=38
        AudioTimes[9] = AudioTimes[8] + 2.9f;
        AudioClipName[9] = _RES + "/sfx/voice/38";//3.2s

        //no matter hounds from the scent=39
        AudioTimes[10] = AudioTimes[9] + 3.2f;//48.1f;
        AudioClipName[10] = _RES + "/sfx/voice/39";//3.5s

        //below a creature=32
        AudioTimes[11] = AudioTimes[10] + 4.0f;
        AudioClipName[11] = _RES + "/sfx/voice/32";//5.3s

        //what has thou done=12
        AudioTimes[12] = ImageTimes[8];//66.0f;
        AudioClipName[12] = _RES + "/sfx/voice/12";//2.5s

        //dropped to below=13
        AudioTimes[13] = AudioTimes[12] + 2.5f;//72.0f;
        AudioClipName[13] = _RES + "/sfx/voice/13";//2.2s

        //he'll nay escape=14
        AudioTimes[14] = AudioTimes[13] + 2.2f;//78.0f;
        AudioClipName[14] = _RES + "/sfx/voice/14";//3.5s

        //several tense hours=33
        AudioTimes[15] = ImageTimes[9];//84.0f;
        AudioClipName[15] = _RES + "/sfx/voice/33";//3.135

        //ignoring you=34
        AudioTimes[16] = ImageTimes[10];//AudioTimes[15] + 3.2f;//AudioTimes[15]90.0f;
        AudioClipName[16] = _RES + "/sfx/voice/34";//2.4s

        //what news colwyn	=00
        AudioTimes[17] = ImageTimes[11];// AudioTimes[16] + 2.5f;//96.0f;
        AudioClipName[17] = _RES + "/sfx/voice/00";//1.7s

        //forgive us=15
        AudioTimes[18] = ImageTimes[12];//102.0f;
        AudioClipName[18] = _RES + "/sfx/voice/15";//1.1s

        //the foul creature escaped=65
        AudioTimes[19] = AudioTimes[18] + 1.3f;//108.0f;
        AudioClipName[19] = _RES + "/sfx/voice/65";//1.4s

        //a score gave chase=16
        AudioTimes[20] = AudioTimes[19] + 1.4f;//114.0f;
        AudioClipName[20] = _RES + "/sfx/voice/16";//4s

        //we were attacked=17
        AudioTimes[21] = AudioTimes[20] + 4f; ;//120.0f;
        AudioClipName[21] = _RES + "/sfx/voice/17";//2.4s

        //only 3 survied=18
        AudioTimes[22] = AudioTimes[21] + 2.4f; ;//126.0f;
        AudioClipName[22] = _RES + "/sfx/voice/18";//1.4s

        //I see=50
        AudioTimes[23] = ImageTimes[13] + 1.0f;//132.0f;
        AudioClipName[23] = _RES + "/sfx/voice/50";//1s

        //baron throws his eyes upon=35
        AudioTimes[24] = ImageTimes[14];//138.0f;
        AudioClipName[24] = _RES + "/sfx/voice/35";//2.3s

        //i was warned.=01
        AudioTimes[25] = ImageTimes[15];//144.0f;
        AudioClipName[25] = _RES + "/sfx/voice/01";//2.1s

        //last fortnight=02
        AudioTimes[26] = AudioTimes[25] + 2.1f;//150.0f;
        AudioClipName[26] = _RES + "/sfx/voice/02";//5.3s

        //guard thy daughter=03
        AudioTimes[27] = AudioTimes[26] + 5.3f;//156.0f;
        AudioClipName[27] = _RES + "/sfx/voice/03";//6.2s

        //I posted guards=04
        AudioTimes[28] = AudioTimes[27] + 6.4f;//162.0f;
        AudioClipName[28] = _RES + "/sfx/voice/04";//4.2s		

        //they say=05
        AudioTimes[29] = AudioTimes[28] + 4.3f;//168.0f;
        AudioClipName[29] = _RES + "/sfx/voice/05";//4.5s

        //you explain=36
        AudioTimes[30] = ImageTimes[16];//174.0f;
        AudioClipName[30] = _RES + "/sfx/voice/36";//2.9s

        //whether you speak truth or falsehood=06
        AudioTimes[31] = ImageTimes[17];//180.0f;
        AudioClipName[31] = _RES + "/sfx/voice/06";//3.9s

        //stories tell=07
        AudioTimes[32] = AudioTimes[31] + 4f;//186.0f;
        AudioClipName[32] = _RES + "/sfx/voice/07";//5.4s

        //if thou art truely the avatar=08
        AudioTimes[33] = AudioTimes[32] + 5.5f; ;//192.0f;
        AudioClipName[33] = _RES + "/sfx/voice/08";//4.3s

        //none here can survive=58
        AudioTimes[34] = AudioTimes[33] + 4.3f;//198.0f;
        AudioClipName[34] = _RES + "/sfx/voice/58";//3.8s

        //my mind is set=09
        AudioTimes[35] = AudioTimes[34] + 4f;//204.0f;
        AudioClipName[35] = _RES + "/sfx/voice/09";//3.9s

        //return here with my daughter=10
        AudioTimes[36] = AudioTimes[35] + 4f;//210.0f;
        AudioClipName[36] = _RES + "/sfx/voice/10";//3.9s

        //if thou dost not return=11
        AudioTimes[37] = AudioTimes[36] + 5.8f;//216.0f;
        AudioClipName[37] = _RES + "/sfx/voice/11";//5.6s

        //this be the foul pits=19
        AudioTimes[38] = ImageTimes[21];
        AudioClipName[38] = _RES + "/sfx/voice/19";//4.9s

        //i will shut they in.=20
        AudioTimes[39] = AudioTimes[38] + 4.8f;//228.0f;
        AudioClipName[39] = _RES + "/sfx/voice/20";//4.6s

        //other wise shut forever=22
        AudioTimes[40] = AudioTimes[39] + 3f;//234.0f;
        AudioClipName[40] = _RES + "/sfx/voice/22";//2.7s

        SyncSubtitles();
    }



    /*
     At last you are asleep=26
for 3 nights each attem=27
deja vu.=28
-Fade in garamon
-Garamon talk
Treachery & doom=23
My brother=24
Brit in peril=25
-spiral fade away.
sure that the ghost=30
scream=31
-bedroom
a visitor=37
were he not dead=38
no matter hounds from the scent=39
-zoom to windo
-troll escaping
below a creature=32
-guards enter
what has thou don=12
-zoom on colwyn
dropped to below=13
he'll nay escape=14
-baron on throne
several tense hours=33
ignoring you=34
-baron speaks wide
what news colwyn	=00
-zoom on colyn
forgive us=15
the foul creature escaped=65
a score gave chase=16
we were attacked=17
only 3 survied=18
-baron on throne
I see=50
baron throws his eyes upon=35
-close on baron
i was warned.=01
last fortnight.=02
guard thy daughter=03
i posted guards=04
they say=05
-wide on baron listening
you explain=36
-zoom on baron talking
whether you speak truth or falsehood=06
stories tell=07
if thou art truely the avatar=08
none here can survive=58
my mind is set=09
return here with my daughter=10
if thou dost not return=11
-mountains
-door open
-colwyn outside
this be the foul pits=19
i will shut they in.=20
other wise shut forever=22
-door close


*/

}
