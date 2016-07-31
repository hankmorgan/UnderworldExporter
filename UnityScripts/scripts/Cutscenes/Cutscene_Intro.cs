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


		noOfImages=8;
		ImageTimes[0]=0.0f;
		ImageTimes[1]=5.0f;
		ImageTimes[2]=10.0f;
		ImageTimes[3]=15.0f;
		ImageTimes[4]=20.0f;
		ImageTimes[5]=25.0f;
		ImageTimes[6]=30.0f;
		ImageTimes[7]=80.0f;

		ImageFrames[0]="cs000_n01";
		ImageFrames[1]="cs000_n02";
		ImageFrames[2]="cs000_n03";
		ImageFrames[3]="cs000_n04";
		ImageFrames[4]="cs000_n05";
		ImageFrames[5]="cs000_n06";
		ImageFrames[6]="cs000_n10";
		ImageFrames[7]="Anim_Base";//To finish.

		ImageLoops[0]=1;
		ImageLoops[1]=-1;
		ImageLoops[2]=-1;
		ImageLoops[3]=-1;
		ImageLoops[4]=-1;
		ImageLoops[5]=-1;
		ImageLoops[6]=1;
		ImageLoops[7]=-1;

		StringBlockNo=3072;
		noOfSubs=2;

		SubsTimes[0]=0.2f;
		SubsTimes[1]=30.0f;

		SubsDuration[0]=10.0f;
		SubsDuration[1]=10.0f;

		SubsStringIndices[0]=0;
		SubsStringIndices[1]=8;

		noOfAudioClips=41;

				//At last you are asleep=26
		AudioTimes[0]=2.0f;
		AudioClipName[0]=_RES +"/sfx/voice/26";

				//for 3 nights each attem=27
				AudioTimes[1]=6.0f;
				AudioClipName[1]=_RES +"/sfx/voice/27";

				//deja vu.=28
				AudioTimes[2]=14.0f;
				AudioClipName[2]=_RES +"/sfx/voice/28";

				//Treachery & doom=23
				AudioTimes[3]=18.0f;
				AudioClipName[3]=_RES +"/sfx/voice/23";

				//My brother=24
				AudioTimes[4]=21.0f;
				AudioClipName[4]=_RES +"/sfx/voice/24";

				//Brit in peril=25
				AudioTimes[5]=27.0f;
				AudioClipName[5]=_RES +"/sfx/voice/25";

				//sure that the ghost=30
				AudioTimes[6]=30.0f;
				AudioClipName[6]=_RES +"/sfx/voice/30";

				//scream=31
				AudioTimes[7]=36.0f;
				AudioClipName[7]=_RES +"/sfx/voice/31";

				//a visitor=37
				AudioTimes[8]=42.0f;
				AudioClipName[8]=_RES +"/sfx/voice/37";

				//were he not dead=38
				AudioTimes[9]=48.0f;
				AudioClipName[9]=_RES +"/sfx/voice/38";

				//no matter hounds from the scent=39
				AudioTimes[10]=54.0f;
				AudioClipName[10]=_RES +"/sfx/voice/39";

				//below a creature=32
				AudioTimes[11]=60.0f;
				AudioClipName[11]=_RES +"/sfx/voice/32";

				//what has thou done=12
				AudioTimes[12]=66.0f;
				AudioClipName[12]=_RES +"/sfx/voice/12";

				//dropped to below=13
				AudioTimes[13]=72.0f;
				AudioClipName[13]=_RES +"/sfx/voice/13";

				//he'll nay escape=14
				AudioTimes[14]=78.0f;
				AudioClipName[14]=_RES +"/sfx/voice/14";

				//several tense hours=33
				AudioTimes[15]=84.0f;
				AudioClipName[15]=_RES +"/sfx/voice/33";

				//ignoring you=34
				AudioTimes[16]=90.0f;
				AudioClipName[16]=_RES +"/sfx/voice/34";

				//what news colwyn	=00
				AudioTimes[17]=96.0f;
				AudioClipName[17]=_RES +"/sfx/voice/00";

				//forgive us=15
				AudioTimes[18]=102.0f;
				AudioClipName[18]=_RES +"/sfx/voice/15";

				//the foul creature escaped=65
				AudioTimes[19]=108.0f;
				AudioClipName[19]=_RES +"/sfx/voice/65";

				//a score gave chase=16
				AudioTimes[20]=114.0f;
				AudioClipName[20]=_RES +"/sfx/voice/16";

				//we were attacked=17
				AudioTimes[21]=120.0f;
				AudioClipName[21]=_RES +"/sfx/voice/17";

				//only 3 survied=18
				AudioTimes[22]=126.0f;
				AudioClipName[22]=_RES +"/sfx/voice/18";

				//I see=50
				AudioTimes[23]=132.0f;
				AudioClipName[23]=_RES +"/sfx/voice/50";

				//baron throws his eyes upon=35
				AudioTimes[24]=138.0f;
				AudioClipName[24]=_RES +"/sfx/voice/35";

				//i was warned.=01
				AudioTimes[25]=144.0f;
				AudioClipName[25]=_RES +"/sfx/voice/01";

				//last fortnight=02
				AudioTimes[26]=150.0f;
				AudioClipName[26]=_RES +"/sfx/voice/02";

				//guard thy daughter=03
				AudioTimes[27]=156.0f;
				AudioClipName[27]=_RES +"/sfx/voice/03";

				//I posted guards=04
				AudioTimes[28]=162.0f;
				AudioClipName[28]=_RES +"/sfx/voice/04";		

				//they say=05
				AudioTimes[29]=168.0f;
				AudioClipName[29]=_RES +"/sfx/voice/05";

				//you explain=36
				AudioTimes[30]=174.0f;
				AudioClipName[30]=_RES +"/sfx/voice/36";

				//whether you speak truth or falsehood=06
				AudioTimes[31]=180.0f;
				AudioClipName[31]=_RES +"/sfx/voice/06";

				//stories tell=07
				AudioTimes[32]=186.0f;
				AudioClipName[32]=_RES +"/sfx/voice/07";

				//if thou art truely the avatar=08
				AudioTimes[33]=192.0f;
				AudioClipName[33]=_RES +"/sfx/voice/08";

				//none here can survive=58
				AudioTimes[34]=198.0f;
				AudioClipName[34]=_RES +"/sfx/voice/58";

				//my mind is set=09
				AudioTimes[35]=204.0f;
				AudioClipName[35]=_RES +"/sfx/voice/09";

				//return here with my daughter=10
				AudioTimes[36]=210.0f;
				AudioClipName[36]=_RES +"/sfx/voice/10";

				//if thou dost not return=11
				AudioTimes[37]=216.0f;
				AudioClipName[37]=_RES +"/sfx/voice/11";

				//this be the foul pits=19
				AudioTimes[38]=222.0f;
				AudioClipName[38]=_RES +"/sfx/voice/19";

				//i will shut they in.=20
				AudioTimes[39]=228.0f;
				AudioClipName[39]=_RES +"/sfx/voice/20";

				//other wise shut forever=22
				AudioTimes[40]=234.0f;
				AudioClipName[40]=_RES +"/sfx/voice/22";
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
