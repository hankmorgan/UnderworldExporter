using UnityEngine;
using System.Collections;

public class Conversation : MonoBehaviour {

	public static UWCharacter playerUW;
	public static StringController SC;

	public static int CurrentConversation;
	public static bool InConversation = false;
	public static bool ConversationOpen=false;

	public int StringNo;

	public int[] privateVariables=new int[31] ;
	public int[] param1=new int[31];//TODO:is this correct
	public int[] param2=new int[31];//TODO:is this correct

	public int play_hunger;
	public int play_health;
	public int play_arms;
	public int play_power;
	public int play_hp;
	public int play_mana;
	public int play_level;
	public int new_player_exp;   //  (not used in uw1)
	public int play_name;       //   player name
	public int play_poison;      //  (not used in uw1)
	public int play_drawn;       //  is 1 when player has drawn his weapon (?)
	public int play_sex;         // (not used in uw1)
	public int npc_xhome;        //  x coord of home tile
	public int npc_yhome;        //  y coord of home tile
	public int npc_whoami;       //  npc conversation slot number
	public int npc_hunger;
	public int npc_health;
	public int npc_hp;
	public int npc_arms;          // (not used in uw1)
	public int npc_power;
	public int npc_goal;          // goal that NPC has; 5:kill player 6:? 9:?
	public int npc_attitude;       //attitude; 0:hostile, 1:upset, 2:mellow, 3:friendly
	public int npc_gtarg;         //goal target; 1:player
	public int npc_talkedto;      // is 1 when player already talked to npc
	public int npc_level;
	public int npc_name;       //    (not used in uw1)
	public int dungeon_level;    //  (not used in uw1)
	public int riddlecounter;     // (not used in uw1)
	public int game_time;
	public int game_days;
	public int game_mins;

	public int PlayerAnswer;
	private int MinAnswer=1;
	private int MaxAnswer=1;

	//bool Ready=false;

	private int WhoAmI;

	public bool inputRecieved;
	public bool WaitingForInput;
	public bool WaitingForMore;

	public UITextList tl;//Text output.
	public UITextList tl_input;//player choices
	public UITexture OutPutControl;

	public UWFonts FontController;
	public static Camera maincam;

	int LineWidth = 28 ;


	// Use this for initialization
	void Start () {
		WhoAmI = this.GetComponent<NPC>().WhoAmI;
		//tl.textLabel.lineHeight=340;//TODO:Get rid of this!
		//tl.textLabel.lineWidth=480;
	}
	
	// Update is called once per frame
	void Update () {
	if ((CurrentConversation==WhoAmI) && (InConversation==false) && (ConversationOpen==true))
		{
			ConversationOpen=false;
			tl.Clear ();
			tl_input.Clear ();
			tl_input.maxEntries=3;
			maincam.enabled=true;
			chains.ActiveControl=0;
		}
		else
		{
		if (WaitingForInput)
			{
				if (Input.GetKeyDown (KeyCode.Alpha1))
				{
					CheckAnswer(1);
				}
				else if (Input.GetKeyDown (KeyCode.Alpha2))
				{
					CheckAnswer(2);
				}
				else if (Input.GetKeyDown (KeyCode.Alpha3))
				{
					CheckAnswer(3);
				}
				else if (Input.GetKeyDown (KeyCode.Alpha4))
				{
					CheckAnswer(4);
				}
				else if (Input.GetKeyDown (KeyCode.Alpha5))
				{
					CheckAnswer(5);
				}
				else if (Input.GetKeyDown (KeyCode.Alpha6))
				{
					CheckAnswer(6);
				}
			}
			else if (WaitingForMore)
			{
				if (Input.GetKeyDown (KeyCode.Space))
				{
					WaitingForMore=false;
				}
			}
		}
	}

	private void CheckAnswer(int AnswerNo)
	{
		if (AnswerNo<=MaxAnswer)
		{
			WaitingForInput =true;
			PlayerAnswer=AnswerNo;
			WaitingForInput=false;
		}
	}


	public virtual IEnumerator main()
	{
		Debug.Log ("Start Conversation");
		return null;
	}

	public IEnumerator say(string WhatToSay)
	{
		tl.textLabel.lineHeight=340;//TODO:Get rid of this!
		tl.textLabel.lineWidth=480;

		string[] Paragraphs = WhatToSay.Split(new string [] {"/m"}, System.StringSplitOptions.None);

		for (int i = 0; i<= Paragraphs.GetUpperBound(0);i++)
			{
			string[] StrWords = Paragraphs[i].Split(new char [] {' '});
			int colCounter=1;
			string Output="";
			for (int j =0; j<=StrWords.GetUpperBound(0);j++)
			{
				char[] strChars =  StrWords[j].ToCharArray();
				if (StrWords[j].Length+colCounter>=LineWidth)
				{
					colCounter=2; 
					//Debug.Log ("Adding newline " + Output);
					tl.Add (Output + " @@@ ");
					Output=StrWords[j] + " ";
					colCounter= StrWords[j].Length+1;
				}	
				else
				{
					Output = Output + StrWords[j] + " ";
					colCounter= colCounter+StrWords[j].Length + 1;
				}
			}

			//Debug.Log ("Adding op " + Output);
			tl.Add(Output);
			if (i < Paragraphs.GetUpperBound(0))
				{//Pause for more when not the last paragraph.
				tl.Add("@@@ [MORE] " + " @@@ ");
				FontController.ConvertString(1,tl.textLabel.text,OutPutControl);
				yield return StartCoroutine(WaitForMore());
				}
			}

		//tl.Add(WhatToSay);
		FontController.ConvertString(1,tl.textLabel.text,OutPutControl);

		yield return 0;
		//Debug.Log(WhatToSay);
	}

	public void say(int WhatToSay)
	{

	}

	public int sex(int unknown, int ParamFemale, int ParamMale)
	{
		if (playerUW.isFemale==true)
		{
			return ParamFemale;
		}
		else
		{
			return ParamMale;
		}
	}

	public IEnumerator babl_menu(int unknown, int[] localsArray,int Start)
	{

		//If an offset is 0, the conversation slot is empty and no conversation is
		//	available. The name of the conversation partner is stored in string block
		//		0007, string number = (conversation slot number - 0x0e00 + 16).

		string tmp="";
		MaxAnswer=0;
		int j=1;
		for (int i = Start; i <=localsArray.GetUpperBound(0) ; i++)
		{
			if (localsArray[i]!=0)
			{
				tmp = tmp + j++ + "." + SC.GetString(StringNo,localsArray[i]) + "\n";
				MaxAnswer++;
			}
			else
			{
				break;
			}
		}

		//Debug.Log(tmp);

		//StartCoroutine (PrintBablMenu(tmp));
		//tl.Add(tmp);
		tl_input.maxEntries=1;
		tl_input.Add (tmp);
		//Ready=false;
		//PlayerAnswer=1;
		//PlayerAnswer= Random.Range (1,NoOfAnswers+1);
		//StartCoroutine(Wait(1.0f));

		yield return StartCoroutine(WaitForInput());

	//	while(!Ready){
	//		yield return null;
	//	}

		tmp= SC.GetString(StringNo,localsArray[Start+PlayerAnswer-1]);
		//Debug.Log (tmp);
		//Debug.Log (PlayerAnswer + " out of " + NoOfAnswers + " " + tmp);
		if (tmp.Length>=LineWidth)
		{
			tl.Add("@@@ " + tmp.Substring(0,LineWidth) + " @@@ ");
			tl.Add (tmp.Substring(LineWidth,tmp.Length-LineWidth) + " @@@ ");
		}
		else 
		{
			tl.Add ("@@@ " + tmp + " @@@ ");	
		}

		FontController.ConvertString(1,tl.textLabel.text,OutPutControl);
		//return null;
		//return playerAnswer;
		yield return 0;
	}


	public IEnumerator Wait(float waitTime)
	{
		//print( " s " + Time.time);
		yield return new WaitForSeconds(waitTime);
		//Ready=true;
		//print(" f " + Time.time);
	}

	IEnumerator WaitForInput()
	{
		WaitingForInput=true;
		while (WaitingForInput)
			{yield return null;}
		//Ready=true;
	}

	IEnumerator WaitForMore()
	{
		Debug.Log ("waitformore");
		WaitingForMore=true;
		while (WaitingForMore)
		{yield return null;}
		//Ready=true;
	}
}
