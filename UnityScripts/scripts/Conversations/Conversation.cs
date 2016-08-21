using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Conversation.
/// BaseClass for npc conversations.
/// </summary>

/**
Basic rules for converting conversations.
Create Subclass of Conversation called Conversation_[whoami]
Set up the main(zak as in the _67.
Add EndConversation(); to ending function func_0012 (typically)
Remove startup and void functions.
Comment out unreachable code.
rename the instances of array private to privateVariables.
Change the declaration of locals
Remove the & from usages of locals.
Change usages of say to a yield coroutine
Change usages of babl_menu to match function call babl_menu(unk,array, indexto first entry);
then set	locals[x] to playeranswer
Find all end of conversations and add yield for time and yield break
add npc. to all npc variables.
Comment out play_hunger syntax error
Make sure Random is correctly set up 
Implement intrinsic conversation functions in this class.
When using babl_ask replace usages of the local variable used with playertypedanswer.
Make sure you don't confuse babl_menu with babl_fmenu
Check any code involving items before running as infinite loops are possible.
usages of switch statements in if-else blocks are sometimes borked.

Things to do.
Fix the Param arrays being passed into local functions. Especially ones that set the npcs attitude.
Fix up gender strings and other @SSx text replacements.
Replace strings with string numbers from strings file.
*/

public class Conversation : GuiBase {


	///The NPC is talking
	public const int NPC_SAY=0;
	///The PC is talking
	public const int PC_SAY=1;
	///Printed text is displayed
	public const int PRINT_SAY=2;

	///Reference no to the current conversation
	public static int CurrentConversation;
	/// Flags if the player is in a conversation
	public static bool InConversation = false;
	/// Is the conversation UI element open
	public static bool ConversationOpen=false;
	/// Is the user entering a quantity
	public static bool EnteringQty;

	/// What string block is the conversation using
	private int StringBlock;

	/// The private variables for the NPC.
	/// Used to store data inbetween conversations
	public int[] privateVariables=new int[31] ;

		/// Player Hunger level
	protected static int play_hunger;
		/// Player Health
	protected static int play_health;
		/// Player arms?
	protected static int play_arms;
		/// PLayer Power?
	protected static int play_power;
		/// Player Hit points
	protected static int play_hp;
		/// Player Mana
	protected static int play_mana;
		/// PLayer Level
	protected static int play_level;
		/// PLayer EXP?
	protected static int new_player_exp;   //  (not used in uw1)
		/// Player Name. Ptr to it on the stack
	protected static int play_name;       //   player name
		/// Player is poisoned
	protected static int play_poison;      //  (not used in uw1)
		/// Player has drawn their weapon
	protected static int play_drawn;       //  is 1 when player has drawn his weapon (?)
		/// Player gender.
	protected static int play_sex;         // (not used in uw1)
	
		/// The dungeon level
	public static int dungeon_level;    //  (not used in uw1)
		/// Riddle counter?
	public static int riddlecounter;     // (not used in uw1)
		/// Game time. Should be loaded from GameClock
	public static int game_time;
		/// Game days. Should be loaded from GameClock
	public static int game_days;
		/// Game minutes. Should be loaded from GameClock
	public static int game_mins;

		///The number that the player has entered to pick an answer from the menu
	public static int PlayerAnswer;
		///The text the player has typed in response to a question
	public static string PlayerTypedAnswer;
		/// The maximum value the player can pick from
	private int MaxAnswer=1;
		///The npc whoami variable for the NPC
	//public int WhoAmI;


	//public static bool inputRecieved;

	///Conversation waiting mode. Player has to enter a menu option
	public static bool WaitingForInput;
	///Conversation waiting mode. Player has to press any key to continue
	public static bool WaitingForMore;
	///Conversation waiting mode. Player has to type an answer.
	public static bool WaitingForTyping;

	///The array that maps menu options in a bablf_menu to their answer numbers
	public static int[] bablf_array = new int[10];
	///Tells if we are using a bablf_menu
	public static bool usingBablF;
	/// The answer from the bablf_menu
	public static int bablf_ans=0;

	///The scroll controller for printing the conversation text
	public static ScrollController tl;//Text output.
	///The scroll controller for printing the player choices
	public static ScrollController tl_input;

	//public static Camera maincam;
	/// The time to wait at the end of the conversation before releasing control
	public const float WaitTime=0.3f;
	/// The rate the game timer is set to when waiting 
	/// To keep coroutines running when ending convos and waiting out the WaitTime
	public const float SlomoTime=0.1f;

	/// How many characters max in a line of conversation text
	//static int LineWidth = 37 ;


	//private string[] NPCTradeItems=new string[4];
	
	/// Reference to the NPC we are talking to
	public NPC npc;

		/// <summary>
		/// Setups the conversation.
		/// </summary>
		/// <param name="stringno">The String Block No to pull text strings from</param>

	public void SetupConversation(int StringBlockNo)
	{
		///Setup UI Elements - code formerly in NPC
		StringBlock =StringBlockNo;

		UWHUD.instance.RefreshPanels(UWHUD.HUD_MODE_CONV);
		tl=UWHUD.instance.Conversation_tl;
		tl_input=UWHUD.instance.MessageScroll;
		tl.Clear();
		///Clear the trade slots for the npcs
		for (int i=0; i<4;i++)
		{
			UWHUD.instance.npcTrade[i++].clear ();
		}

		///Identifies the NPC for future looking at
		npc.objInt().isIdentified=true;

		///Sets up the portraits for the player and the NPC
		RawImage portrait = UWHUD.instance.ConversationPortraits[0];
		RawImage npcPortrait = UWHUD.instance.ConversationPortraits[1];
		if (GameWorldController.instance.playerUW.isFemale)
		{
			portrait.texture=Resources.Load <Texture2D> (_RES +"/HUD/PlayerHeads/heads_"+ (GameWorldController.instance.playerUW.Body+5).ToString("0000"));//TODO:playerbody
		}
		else
		{
			portrait.texture=Resources.Load <Texture2D> (_RES +"/HUD/PlayerHeads/heads_"+ (GameWorldController.instance.playerUW.Body).ToString("0000"));//TODO:playerbody		
		}

		
		if ((npc.npc_whoami!=0) && (npc.npc_whoami<=28))
		{
			npcPortrait.texture=Resources.Load <Texture2D> (_RES +"/HUD/Charhead/charhead_"+ (npc.npc_whoami-1).ToString("0000"));			
		}	
		else
		{
			//head in charhead.gr
			int HeadToUse = this.GetComponent<ObjectInteraction>().item_id-64;
			if (HeadToUse >59)
			{
				HeadToUse=0;
			}			
			npcPortrait.texture=Resources.Load <Texture2D> (_RES +"/HUD/genhead/genhead_"+ (HeadToUse).ToString("0000"));
		}
		UWHUD.instance.MessageScroll.Clear ();
		/*End UI Setup*/



		///Cancels player movement
		GameWorldController.instance.playerUW.playerMotor.enabled=false;



		///Sets the music to the conversation theme
		if  (GameWorldController.instance.mus!=null)
		{
			GameWorldController.instance.mus.GetComponent<MusicController>().InMap=true;
		}

		///Slows the world down so no other npc will attack or interupt the conversation
		Time.timeScale=0.00f;
		ConversationOpen=true;
		InConversation=true;
	}


	/// <summary>
	/// Ends the conversation.
	/// </summary>
	public void EndConversation()
	{
				///Give movement back to the player			
		GameWorldController.instance.playerUW.playerMotor.enabled=true;
		Container cn = GameObject.Find (GameWorldController.instance.playerUW.GetComponent<PlayerInventory>().currentContainer).GetComponent<Container>();
		///Return any items in the trade area to their owner
		for (int i =0; i <=3; i++)
		{
			TradeSlot npcSlot = UWHUD.instance.playerTrade[i];//GameObject.Find ("Trade_Player_Slot_" + i).GetComponent<TradeSlot>();
			if (npcSlot.objectInSlot!="")
			{///Moves the object to the players container or to the ground
				if (Container.GetFreeSlot(cn)!=-1)//Is there space in the container.
				{
					npc.GetComponent<Container>().RemoveItemFromContainer(npcSlot.objectInSlot);
					cn.AddItemToContainer(npcSlot.objectInSlot);
					npcSlot.clear ();
					GameWorldController.instance.playerUW.GetComponent<PlayerInventory>().Refresh ();
				}
				else
				{
					GameObject demanded = GameObject.Find (npcSlot.objectInSlot);
					demanded.transform.parent=GameWorldController.instance.LevelMarker();
					demanded.transform.position=npc.transform.position;
					npc.GetComponent<Container>().RemoveItemFromContainer(npcSlot.objectInSlot);
					npcSlot.clear();
				}
			}

		}

		///Puts the time scales back to normal
		Time.timeScale=1.0f;
		InConversation=false;
		npc.npc_talkedto=1;
		tl.Clear ();
		tl_input.Clear ();

		UWCharacter.InteractionMode=UWCharacter.InteractionModeTalk;
		if  (GameWorldController.instance.mus!=null)
		{
			GameWorldController.instance.mus.GetComponent<MusicController>().InMap=false;
		}
		if (GameWorldController.instance.playerUW.playerInventory.ObjectInHand!="")
		{
			UWCharacter.InteractionMode=UWCharacter.InteractionModePickup;
		}
		StopAllCoroutines();
		
		///Resets the UI
		
		UWHUD.instance.RefreshPanels(UWHUD.HUD_MODE_INVENTORY);
	}

	/// <summary>
	/// Raises the death event for NPC
	/// </summary>
	public virtual bool OnDeath()
	{
	///Code to be called upon the death of this character.
	///Mainly used for cases where specific character deaths set quest flags.
	///return true to stop further death event processing. (ie spilling inventory)
		return false;
	}

	public override void Start()
	{
	//	base.Start();
		npc = this.GetComponent<NPC>();
		//WhoAmI = npc.npc_whoami;
	}

	/// <summary>
	/// Processes key presses from the player when waiting for input.
	/// </summary>
	void OnGUI()
	{
		if (EnteringQty==true)
		{
			return;
		}
		if ( ! ((CurrentConversation==npc.npc_whoami) && (InConversation==false) && (ConversationOpen==true)) )
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
			else if (WaitingForTyping)
			{
				//tl_input.gameObject.GetComponent<UIInput>().selected=true;
				//UWHUD.instance.InputControl.selected=true;
				UWHUD.instance.InputControl.Select();
			}

		}
	}

	/*
	void Update () {
	if ((CurrentConversation==WhoAmI) && (InConversation==false) && (ConversationOpen==true))
		{
			Time.timeScale=1.0f;//start the clock 
			ConversationOpen=false;
			tl.Clear ();
			tl_input.Clear ();
			chains.ActiveControl=0;
		}
	}*/

	/// <summary>
	/// Checks the answer the player has entered to see if it in within the bounds of the valid options.
	/// Sets the PlayerAnswer variable for checking within the conversations
	/// </summary>
	/// <param name="AnswerNo">The answer number from the menu entered by the player</param>
	private void CheckAnswer(int AnswerNo)
	{
		if (usingBablF ==false)
		{		
			if ((AnswerNo>0) && (AnswerNo<=MaxAnswer))
			{
				PlayerAnswer=AnswerNo;
				WaitingForInput=false;
			}
		}
		else
		{
			if ((AnswerNo>0) && (AnswerNo<=MaxAnswer))
			{
				///For babl_fmenus convert the answer using the bablf_array
				bablf_ans=AnswerNo;
				PlayerAnswer=bablf_array[AnswerNo-1];
				WaitingForInput=false;
				usingBablF=false;
			}
		}
	}

	/// <summary>
	/// Conversation Setup. Implemented in inherited classes
	/// </summary>
	public virtual IEnumerator main()
	{
		UWHUD.instance.MessageScroll.Add (StringController.instance.GetString (7,1));
		yield break;
	}

		/// <summary>
		/// Say the specified string using replacements as set by the locals array. To implement.
		/// </summary>
		/// <param name="localsArray">Locals array.</param>
		/// <param name="StringNo">String no.</param>
	public IEnumerator say (int[] localsArray, int StringNo)
	{
		//Do some string replacement stuff here.
		string tmp = FieldReplacement(localsArray, StringController.instance.GetString (StringBlock,StringNo));

		yield return StartCoroutine(say (tmp,NPC_SAY));
		//Now say the line
		//yield return StartCoroutine (say (StringNo));
	}

		public IEnumerator say (int[] GlobalsArray, int[] localsArray, int StringNo)
		{
				//Do some string replacement stuff here.

				//Now say the line
				yield return StartCoroutine (say (StringNo));
		}

		public IEnumerator say (int[,] GlobalsArray, int[] localsArray, int StringNo)
		{
				//Do some string replacement stuff here.

				//Now say the line
				yield return StartCoroutine (say (StringNo));
		}


		/// <summary>
		/// Say the specified string.
		/// </summary>
		/// <param name="WhatToSay">The string to print out</param>
		/// <param name="PrintType">The style of printing. One of NPC_SAY, PC_SAY or PRINT_SAY</param>
	public IEnumerator say(string WhatToSay,int PrintType)
	{
		///Temporarily Replaces instances of @GS8 with player name
		///TODO:Move this out of here to say(locals[], stringNo)
		string Markup;
		//WhatToSay = WhatToSay.Replace("@GS8" , GameWorldController.instance.playerUW.CharName);

		///Sets the markup to colour the text based on print type.
		switch (PrintType)
		{
		case PC_SAY:
				Markup="<color=red>";break;//[FF0000]
		case PRINT_SAY:
				Markup="<color=black>";break;//[000000]
		default:
				Markup="<color=green>";break;//[00FF00]
		}		
				//Make sure the string does not begin with a newline as this can break the markup in some cases.
		WhatToSay= WhatToSay.Trim();
		if (WhatToSay.StartsWith("\\n"))
		{
			WhatToSay=WhatToSay.Remove(0,2);
		}
		///Splits the strings into paragraphs based on [more]
		string[] Paragraphs = WhatToSay.Split(new string [] {"\\m"}, System.StringSplitOptions.None);

		///For each paragraph
		/// Split each word
		/// add each word to output
		/// When newline is met add to the scroll controller.
		/// when linewidth is reached add to the scroll controller
		/// at end of each paragraph add to the scroll controller (with [more])
		/// Reset output and column counter after each add
		for (int i = 0; i<= Paragraphs.GetUpperBound(0);i++)
			{
			string[] StrWords = Paragraphs[i].Split(new char [] {' '});
			int colCounter=0;
			string Output="";
			for (int j =0; j<=StrWords.GetUpperBound(0);j++)
			{
				if (StrWords[j]=="\\n")
				{
					tl.Add (Markup + Output +"</color>");
					colCounter=0;
					Output="";
				}
				else
				{
					if (StrWords[j].Length+colCounter+1>=UWHUD.instance.Conversation_tl.LineWidth)
					{
						colCounter=0; 
						tl.Add (Markup + Output +"</color>");
						Output=StrWords[j] + " ";
						colCounter= StrWords[j].Length+1;
					}	
					else
					{
						Output = Output + StrWords[j] + " ";
						colCounter= colCounter+StrWords[j].Length + 1;
					}
				}
			}

			tl.Add (Markup + Output +"</color>");
			if (i < Paragraphs.GetUpperBound(0))
				{//Pause for more when not the last paragraph.
				tl.Add("<color=black>[MORE]</color>");
				yield return StartCoroutine(WaitForMore());
				}
			}
		yield return 0;
	}

		/// <summary>
		/// The NPC says something.
		/// </summary>
		/// <param name="WhatToSay">What to say as a string</param>
	public IEnumerator say(string WhatToSay)
	{
		yield return StartCoroutine (say(WhatToSay, NPC_SAY));
	}

		/// <summary>
		/// Say the specified locals and WhatToSay.
		/// </summary>
		/// <param name="locals">Locals.</param>
		/// <param name="WhatToSay">What to say.</param>
		public IEnumerator say(int[] locals, string WhatToSay)
		{
				WhatToSay=FieldReplacement(locals,WhatToSay);
				yield return StartCoroutine (say(WhatToSay, NPC_SAY));
		}

		/// <summary>
		/// The NPC says something
		/// </summary>
		/// <param name="WhatToSay">What to say as an integer (index into string block)</param>
	IEnumerator say(int WhatToSay)
	{
		string tmp = StringController.instance.GetString (StringBlock,WhatToSay);
		yield return StartCoroutine(say (tmp,NPC_SAY));
	}

		/// <summary>
		/// Say the specified WhatToSay and SayType.
		/// </summary>
		/// <param name="WhatToSay">What to say as an integer (index into string block)</param>
		/// <param name="SayType">Say type. One of PC_Say, NPC_Say or Print_Say</param>
	IEnumerator say(int WhatToSay,int SayType)
	{
		string tmp = StringController.instance.GetString (StringBlock,WhatToSay);
		yield return StartCoroutine(say (tmp,SayType));
	}

		/// <summary>
		/// Gets the string no that identifies this players gender.
		/// </summary>
		/// <param name="unknown">Unknown.</param>
		/// <param name="ParamFemale">female string</param>
		/// <param name="ParamMale">male string</param>
	public int sex(int unknown, int ParamFemale, int ParamMale)
	{
		if (GameWorldController.instance.playerUW.isFemale==true)
		{
			return ParamFemale;
		}
		else
		{
			return ParamMale;
		}
	}
	
	/// <summary>
	/// Gets the string. Shorthand for string controller.
	/// </summary>
	/// <returns>The string.</returns>
	/// <param name="index">Index into string block</param>
	public string GetString(int index)
	{
		return StringController.instance.GetString(StringBlock,index);
	}

	/// <summary>
	/// Prints a menu of dialog options.
	/// Takes values from localsarray from start until it finds a zero.
	/// </summary>
	/// <param name="unknown">Unknown.</param>
	/// <param name="localsArray">Array of local variables from the conversation</param>
	/// <param name="Start">Index to start taking values from the array</param>
	public IEnumerator babl_menu(int unknown, int[] localsArray,int Start)
	{
		tl_input.Clear();
		string tmp="";
		MaxAnswer=0;
		int j=1;
		for (int i = Start; i <=localsArray.GetUpperBound(0) ; i++)
		{
			if (localsArray[i]!=0)
			{
				//tl_input.Add(j++ + "." + StringController.instance.GetString(StringBlock,localsArray[i]).Replace("@GS8",GameWorldController.instance.playerUW.CharName));
				tl_input.Add(j++ + "." + StringController.instance.GetString(StringBlock,localsArray[i]));
				MaxAnswer++;
			}
			else
			{
				break;
			}
		}
		yield return StartCoroutine(WaitForInput());
		tmp= StringController.instance.GetString(StringBlock,localsArray[Start+PlayerAnswer-1]);
		yield return StartCoroutine(say (tmp,PC_SAY));
		yield return 0;
	}

	/// <summary>
	/// Dialog menu with choices that may or may not show based on the flags
	/// </summary>
	/// <param name="unknown">Unknown.</param>
	/// <param name="localsArray">Array of local variables from the conversation</param>
	/// <param name="Start">Index to start taking values from the array</param>
	/// <param name="flagIndex">Index to start flagging if a value is allowed from the array</param>
	public IEnumerator babl_fmenu(int unknown, int[] localsArray, int Start, int flagIndex)
	{
		tl_input.Clear();
		usingBablF=true;
		for (int i =0; i<=bablf_array.GetUpperBound (0);i++)
		{//Reset the answers array
			bablf_array[i]=0;
		}
		string tmp="";
		int j=1;
		MaxAnswer=0;
		for (int i = Start; i <=localsArray.GetUpperBound(0) ; i++)
		{
			if (localsArray[i]!=0)
			{
				if (localsArray[flagIndex++] !=0)
				{
					bablf_array[j-1] = localsArray[i];
					//tmp = tmp + j++ + "." + StringController.instance.GetString(StringBlock,localsArray[i]) + "\n";
					tl_input.Add (j++ + "." + StringController.instance.GetString(StringBlock,localsArray[i]));
					MaxAnswer++;
				}
			}
			else
			{
				break;
			}
		}
		yield return StartCoroutine(WaitForInput());
		tmp= StringController.instance.GetString (StringBlock,bablf_array[bablf_ans-1]);
		yield return StartCoroutine(say (tmp,PC_SAY));
		yield return 0;
	}

	/// <summary>
	/// Sets up for typed input
	/// </summary>
	/// <param name="unknown">Unknown.</param>
	public IEnumerator babl_ask(int unknown)
	{
		PlayerTypedAnswer="";
		tl_input.Set(">");
		InputField inputctrl=UWHUD.instance.InputControl;
		inputctrl.gameObject.SetActive(true);
		//inputctrl.GetComponent<GuiBase>().SetAnchorX(0.08f);
		inputctrl.gameObject.GetComponent<InputHandler>().target=this.gameObject;
		inputctrl.gameObject.GetComponent<InputHandler>().currentInputMode=InputHandler.InputConversationWords;
		inputctrl.contentType= InputField.ContentType.Alphanumeric;
		inputctrl.text="";
		inputctrl.Select();
		yield return StartCoroutine(WaitForTypedInput());
		yield return StartCoroutine(say (PlayerTypedAnswer,PC_SAY));
		inputctrl.text="";
		UWHUD.instance.MessageScroll.Clear ();
	}


	/// <summary>
	/// Responds to player typed input submission.
	/// </summary>
	/// <param name="PlayerTypedAnswerIN">The string the player has typed</param>
	public void OnSubmitPickup(string PlayerTypedAnswerIN)
	{
		InputField inputctrl=UWHUD.instance.InputControl;
		WaitingForTyping=false;
		inputctrl.gameObject.SetActive(false);
		PlayerTypedAnswer= PlayerTypedAnswerIN; 
	}



	/*public IEnumerator Wait(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
	}*/

/// <summary>
/// Waits for input in babl_menu and bablf_menu
/// </summary>
	IEnumerator WaitForInput()
	{
		WaitingForInput=true;
		while (WaitingForInput)
			{yield return null;}
	}

	/// <summary>
	/// Waits for the player to press any key when printing text
	/// </summary>
	IEnumerator WaitForMore()
	{
		WaitingForMore=true;
		while (WaitingForMore)
		{yield return null;}
	}

	/// <summary>
	/// Waits for typed input from the player when in babl_ask
	/// </summary>
	IEnumerator WaitForTypedInput()
	{
		WaitingForTyping=true;
		while (WaitingForTyping)
		{yield return null;}
	}


	/// <summary>
	/// Gronks the door open
	/// </summary>
	/// <returns> appears to have something to do with if the door is broken or not.</returns>
	/// <param name="unk">Unk.</param>
	/// <param name="Action">close/open flag (0 means open)</param>
	/// <param name="tileY">y tile coordinate with door to open</param>
	/// <param name="tileX">x tile coordinate</param>
	public int gronk_door(int unk, int Action, int tileY, int tileX)
	{
		/*
		id=0025 name="gronk_door" ret_type=int
		parameters:   arg1: x tile coordinate with door to open
		arg2: y tile coordinate
		arg3: close/open flag (0 means open)
		description:  opens/closes door or portcullis
		return value: unknown
		return value appears to have something to do with if the door is broken or not.
		*/

		///Finds the door than needs to be opened
		///Based on the action used the door control functions as appropiate.
		GameObject dr = GameObject.Find ("door_" +tileX .ToString ("D3") + "_" + tileY.ToString ("D3"));
		if (dr!=null)
		{
			DoorControl DC = dr.GetComponent<DoorControl>();
			if (DC!=null)
			{
				if (Action==0)
				{
					DC.UnlockDoor();
					DC.OpenDoor();
				}
				else
				{
					DC.CloseDoor();
					DC.LockDoor ();
				}
				if (DC.objInt ().Quality == 0)
				{
					return 0;
				}
				else
				{
					return 1;
				}
			}
			else
			{
				Debug.Log ("Unable to find doorcontrol to gronk " + " at " + tileX + " " + tileY);
				return 0;
			}

		}
		else
		{
			Debug.Log ("Unable to find door to gronk " + " at " + tileX + " " + tileY);
			return 0;
		}

		//GameObject door = Var.findDoor(Var.triggerX,Var.triggerY);
	}


//	public int show_inv(int unk, int arg1, int arg2)
//	{
	/*
   id=0012 name="show_inv" ret_type=int
   parameters:   arg1: list with inventory item positions
                 arg2: list with object id's shown in player's barter area
   description:  the function copies the item positions and object id's of
                 all visible items in the barter area to the array in arg1
                 and arg2 (which needs at most 4 array values each)
   return value: returns number of items stored in the arrays		 * 
	*/
//		return 1;
//	}


/// <summary>
/// Copies inventory item ids and slot positions into the array indices specified.
/// </summary>
/// <returns>The number of items found</returns>
/// <param name="unk">Unk.</param>
/// <param name="locals">Locals.</param>
/// <param name="startObjectPos">Start index of object position.</param>
/// <param name="startObjectIDs">Start index of object Ids.</param>
	public int show_inv(int unk, int[] locals , int startObjectPos, int startObjectIDs)
	{
		int j=0;
		for (int i=0; i<4;i++)
		{
			TradeSlot pcSlot = UWHUD.instance.playerTrade[i]; 
			if (pcSlot.isSelected())
			{
				locals[startObjectPos+j]= i;
				locals[startObjectIDs+j]= pcSlot.GetObjectID();
				j++;
			}
		}
		return j;
	}

//	public int give_to_npc(int unk, int arg1, int arg2)
//	{
//		Debug.Log ("Give to NPC");
		/*
   id=0013 name="give_to_npc" ret_type=int
   parameters:   arg1: list of item inventory positions to give to npc
                 arg2: number of items in list in arg1
   description:  transfers a number of items from the player inventory to the npc's inventory
   return value: returns 0 if there were no items to give, and 1 if there were some items
		 */
//		return Random.Range (0,2);
//	}

	/// <summary>
	/// Gives the items at the specified positions in the array to the NPC
	/// </summary>
	/// <returns>1 if something given</returns>
	/// <param name="unk">Unk.</param>
	/// <param name="locals">Locals array</param>
	/// <param name="start">Start index of slots to transfer from</param>
	/// <param name="NoOfItems">No of items to transfer</param>
	public int give_to_npc(int unk, int[] locals, int start, int NoOfItems)
	{
		Container cn =npc.gameObject.GetComponent<Container>();
		bool SomethingGiven=false;
		for (int i=0; i<NoOfItems; i++)
		{
			int slotNo = locals[start+i] ;
			if (slotNo<=3)
			{
				TradeSlot pcSlot = UWHUD.instance.playerTrade[slotNo];//GameObject.Find ("Trade_Player_Slot_" + slotNo).GetComponent<TradeSlot>();
				//Give the item to the npc
				if (Container.GetFreeSlot(cn)!=-1)
				{
					cn.AddItemToContainer(pcSlot.objectInSlot);
					pcSlot.clear ();
					SomethingGiven=true;
				}
				else
				{
					GameObject demanded = GameObject.Find (pcSlot.objectInSlot);
					if (demanded!=null)
					{
						demanded.transform.parent=GameWorldController.instance.LevelMarker();
						demanded.transform.position=npc.transform.position;
						SomethingGiven=true;
					}
					pcSlot.clear();
				}
			}
		}
		if (SomethingGiven==true)
		{
			return 1;
		}
		else
		{
			return 0;
		}
	}
	
	/// <summary>
	/// transfers an item from npc inventory to player inventory,based on an item id. 
	/// </summary>
	/// when the value is > 1000, all items of		
	/// a category are copied. category item start = (arg1-1000)*16
	/// My currenty example is lanugo (10) who is passing a value greater than 1000*/
	/// Until It get more examples I'm doing the following*/
	/// Get the items in the npcs container. If their ITEM id is between the calculated category value and +16 of that I take that item*/
	/// Another example goldthirst who specifically has an item id to pass.
	/// 
	/// <returns>1: ok, 2: player has no space left</returns>
	/// <param name="unk">Unk.</param>
	/// <param name="arg1">Arg1.</param>
	public int take_from_npc(int unk, int arg1)
	{
		/*
   id=0015 name="take_from_npc" ret_type=int
   parameters:   arg1: item id (can also be an item category value, > 1000)
   description:  transfers an item from npc inventory to player inventory,
                 based on an item id. when the value is > 1000, all items of
                 a category are copied. category item start = (arg1-1000)*16
   return value: 1: ok, 2: player has no space left
	*/
		/*My currenty example is lanugo (10) who is passing a value greater than 1000*/
		/*Until It get more examples I'm doing the following*/
		/*Get the items in the npcs container. If their ITEM id is between the calculated category value and +16 of that I take that item*/
		//Debug.Log ("Item Category is " + (arg1-1000)*16);
		//Another example goldthirst who specifically has an item id to pass.
		int playerHasSpace=1;
		Container cn = npc.gameObject.GetComponent<Container>();
		Container cnpc = GameWorldController.instance.playerUW.gameObject.GetComponent<Container>();

			int rangeS = (arg1-1000)*16;
			int rangeE = rangeS+16;
			
			for (int i = 0; i<= cn.MaxCapacity ();i++)
			{
				string itemName=cn.GetItemAt (i);
				if (itemName!="")
				{
					ObjectInteraction objInt = GameObject.Find (itemName).GetComponent<ObjectInteraction>();
					if (
						((arg1>=1000) && (objInt.item_id >= rangeS ) && (objInt.item_id<=rangeE))
					||
					((arg1<1000) && (objInt.item_id == arg1 ))
					)
					{
						//Give to PC
					GameObject demanded = GameObject.Find (itemName);
						if (Container.GetFreeSlot(cnpc)!=-1)//Is there space in the container.
						{
							demanded.transform.parent= GameWorldController.instance.playerUW.playerInventory.InventoryMarker.transform;
							npc.GetComponent<Container>().RemoveItemFromContainer(itemName);
							cnpc.AddItemToContainer(itemName);
							demanded.GetComponent<ObjectInteraction>().PickedUp=true;
							GameWorldController.instance.playerUW.GetComponent<PlayerInventory>().Refresh ();
						}
						else
						{
							playerHasSpace=0;
							demanded.transform.parent=GameWorldController.instance.LevelMarker();
							demanded.transform.position=npc.transform.position;
							npc.GetComponent<Container>().RemoveItemFromContainer(itemName);
						}
					}
				}
			}
		return playerHasSpace;
	}
	
		/// <summary>
		/// Setups the barter windows
		/// </summary>
		/// <param name="unk">Unk.</param>
		/// TODO: Figure out where generic NPCs get their inventory for trading from???? Is there a loot list somewhere?
	public void setup_to_barter(int unk)
	{
		/*
		   id=001f name="setup_to_barter" ret_type=void
		   parameters:   none
		   description:  starts bartering; shows npc items in npc bartering area
		 */
		
		Container cn = npc.gameObject.GetComponent<Container>();
		int itemCount=0;

		Debug.Log ("Setup to barter. Based on characters inventory at the moment.");
		for (int i =0 ; i<= cn.MaxCapacity(); i++)
		{
			if (cn.GetItemAt(i)!="")
			{
				if (itemCount <=3)
				{//Just take the first four items
					ObjectInteraction itemToTrade = GameObject.Find (cn.GetItemAt(i)).GetComponent<ObjectInteraction>();
					TradeSlot ts = UWHUD.instance.npcTrade[itemCount++];//GameObject.Find ("Trade_NPC_Slot_" + itemCount++).GetComponent<TradeSlot>();
					ts.objectInSlot=itemToTrade.gameObject.name;
					ts.SlotImage.texture=itemToTrade.GetInventoryDisplay().texture;
					int qty= itemToTrade.GetQty();
					if (qty<=1)
					{
						ts.Quantity.text="";
					}
					else
					{
						ts.Quantity.text=qty.ToString();
					}
				}
			}
		}

		return;
	}


	/// <summary>
	/// Does the appraisal of the worth of the items in the trade area
	/// TODO: figure out how this works. for the moment just base it out quantity of objects selected
	/// Current implemenation is based on qty of objects in the trade area.
	/// </summary>
	/// <returns>The judgement.</returns>
	/// <param name="unk">Unk.</param>

	public IEnumerator do_judgement(int unk)
	{
		/*
	id=0021 name="do_judgement" ret_type=void
   parameters:   none
   description:  judges current trade (using the "appraise" skill) and prints result
		 */
		//Debug.Log ("Do Judgment");
		
		int playerObjectCount=0; int npcObjectCount=0;
		for (int i = 0; i<4; i++)
		{
			TradeSlot npcSlot = UWHUD.instance.npcTrade[i];//GameObject.Find ("Trade_NPC_Slot_" + i).GetComponent<TradeSlot>();
			TradeSlot pcSlot =  UWHUD.instance.playerTrade[i];// GameObject.Find ("Trade_Player_Slot_" + i).GetComponent<TradeSlot>();
			if (npcSlot.isSelected()){npcObjectCount++;}
			if (pcSlot.isSelected()){playerObjectCount++;}
		}
		if (playerObjectCount<npcObjectCount)
		{
			yield return  StartCoroutine ( say("Player has the better deal",PRINT_SAY));
		}
		else if (playerObjectCount==npcObjectCount)
		{
			yield return  StartCoroutine (say("It is an even deal",PRINT_SAY));
		}
		else
		{
			yield return  StartCoroutine (say ("NPC has the better deal",PRINT_SAY));
		}
		//return;
	}

	/// <summary>
	/// Declines the trade offer
	/// Moves items back into respective inventories
	/// </summary>
	/// <param name="unk">Unk.</param>
	public void do_decline(int unk)
	{
		/*
   id=0022 name="do_decline" ret_type=void
   parameters:   none
   description:  declines trade offer (?)
		*/

		Container cn = GameObject.Find (GameWorldController.instance.playerUW.GetComponent<PlayerInventory>().currentContainer).GetComponent<Container>();
		for (int i =0; i <=3; i++)
		{
			TradeSlot pcSlot =  UWHUD.instance.playerTrade[i] ;//GameObject.Find ("Trade_Player_Slot_" + i).GetComponent<TradeSlot>();
			if (pcSlot.objectInSlot!="")
			{//Move the object to the players container or to the ground
				if (Container.GetFreeSlot(cn)!=-1)//Is there space in the container.
				{
					//GameWorldController.instance.playerUW.GetComponent<Container>().RemoveItemFromContainer(pcSlot.objectInSlot);
					cn.AddItemToContainer(pcSlot.objectInSlot);
					pcSlot.clear ();
					GameWorldController.instance.playerUW.GetComponent<PlayerInventory>().Refresh ();
				}
				else
				{
					GameObject demanded = GameObject.Find (pcSlot.objectInSlot);
					demanded.transform.parent=GameWorldController.instance.LevelMarker();
					demanded.transform.position=npc.transform.position;
					pcSlot.clear();
				}
			}
		}

		for (int i=0; i<=3; i++)
		{//Clear out the trade slots.
			UWHUD.instance.npcTrade[i].clear();
		}
		return;
	}

		/// <summary>
		/// Gives the selected items to the NPC
		/// </summary>
		/// <param name="SlotNo">Slot no.</param>
	private void TakeFromNPC (int SlotNo)
	{
		Container cn = GameObject.Find (GameWorldController.instance.playerUW.GetComponent<PlayerInventory>().currentContainer).GetComponent<Container>();
		TradeSlot npcSlot = UWHUD.instance.npcTrade [SlotNo];
		//GameObject.Find ("Trade_NPC_Slot_" + i).GetComponent<TradeSlot>();
		if (npcSlot.isSelected ()) {
			//Move the object to the container or to the ground
			if (Container.GetFreeSlot (cn) != -1)//Is there space in the container.
			 {
				npc.GetComponent<Container> ().RemoveItemFromContainer (npcSlot.objectInSlot);
				cn.AddItemToContainer (npcSlot.objectInSlot);
				GameObject demanded = GameObject.Find (npcSlot.objectInSlot);
				demanded.transform.parent = GameWorldController.instance.InventoryMarker.transform;
				demanded.transform.position = Vector3.zero;
				npcSlot.clear ();
				GameWorldController.instance.playerUW.GetComponent<PlayerInventory> ().Refresh ();
				demanded.GetComponent<ObjectInteraction>().PickedUp=true;
			}
			else {
				GameObject demanded = GameObject.Find (npcSlot.objectInSlot);
				demanded.transform.parent = GameWorldController.instance.LevelMarker ();
				demanded.transform.position = npc.transform.position;
				npc.GetComponent<Container> ().RemoveItemFromContainer (npcSlot.objectInSlot);
				npcSlot.clear ();
			}
		}
	return;
	}
		/// <summary>
		/// Takes from PCs selected items  ang gives them to the NPC.
		/// </summary>
		/// <param name="slotNo">Slot no.</param>
	void TakeFromPC (int slotNo)
		{
		Container cn = npc.GetComponent<Container> ();//GameObject.Find (GameWorldController.instance.playerUW.GetComponent<PlayerInventory>().currentContainer).GetComponent<Container>();
		TradeSlot pcSlot = UWHUD.instance.playerTrade [slotNo];
		if (pcSlot.isSelected ()) {
			//Move the object to the container or to the ground
			if (Container.GetFreeSlot (cn) != -1)//Is there space in the container.
			 {
				cn.AddItemToContainer (pcSlot.objectInSlot);
				//Move to the inventory room
				GameObject demanded = GameObject.Find (pcSlot.objectInSlot);
				demanded.transform.parent = GameWorldController.instance.LevelMarker ();
				demanded.transform.position = new Vector3 (119f, 2.1f, 119f);
				pcSlot.clear ();
			}
			else {
				GameObject demanded = GameObject.Find (pcSlot.objectInSlot);
				demanded.transform.parent = GameWorldController.instance.LevelMarker ();
				demanded.transform.position = npc.transform.position;
				pcSlot.clear ();
			}
		}
	}
		/// <summary>
		/// Restores the Pcs inventory out of the trade area and back into the current container.
		/// </summary>

	void RestorePCsInventory ()
	{
		Container cn = GameObject.Find (GameWorldController.instance.playerUW.GetComponent<PlayerInventory>().currentContainer).GetComponent<Container>();
		for (int i = 0; i <= 3; i++) {
			TradeSlot npcSlot = UWHUD.instance.playerTrade [i];
			if (npcSlot.objectInSlot != "") {
				//Move the object to the players container or to the ground
				if (Container.GetFreeSlot (cn) != -1)//Is there space in the container.
				 {
					npc.GetComponent<Container> ().RemoveItemFromContainer (npcSlot.objectInSlot);
					cn.AddItemToContainer (npcSlot.objectInSlot);
					npcSlot.clear ();
					GameWorldController.instance.playerUW.GetComponent<PlayerInventory> ().Refresh ();
				}
				else {
					GameObject demanded = GameObject.Find (npcSlot.objectInSlot);
					demanded.transform.parent = GameWorldController.instance.LevelMarker ();
					demanded.transform.position = npc.transform.position;
					npc.GetComponent<Container> ().RemoveItemFromContainer (npcSlot.objectInSlot);
					npcSlot.clear ();
				}
			}
		}
	}

/// <summary>
/// Checks the offer.
/// checks if the deal is acceptable for the npc, based on the
/// selected items in both bartering areas. the values in arg1
/// to arg5 are probably values of the items that are
/// acceptable for the npc.
/// the function is sometimes called with 7 args, but arg6 and
/// arg7 are always set to -1.
/// </summary>
/// <returns>1 if the deal is acceptable, 0 if not</returns>
/// <param name="unk">Unk.</param>
/// <param name="arg1">Arg1.</param>
/// <param name="arg2">Arg2.</param>
/// <param name="arg3">Arg3.</param>
/// <param name="arg4">Arg4.</param>
/// <param name="arg5">Arg5.</param>
/// <param name="arg6">Arg6.</param>
/// <param name="arg7">Arg7.</param>
/// I think the values passed are actually the strings for how the npc reacts to the offer. The value judgment is done elsewhere
/// In the prototype I randomise the decision. And then randomise a response based on that decision.
/// Arg5 is the yes answer
	public IEnumerator  do_offer(int unk, int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7)
	{
		/*
   id=0018 name="do_offer" ret_type=int
   parameters:   arg1 ... arg5: unknown
                 [arg6, arg7]: unknown
   description:  checks if the deal is acceptable for the npc, based on the
                 selected items in both bartering areas. the values in arg1
                 to arg5 are probably values of the items that are
                 acceptable for the npc.
                 the function is sometimes called with 7 args, but arg6 and
                 arg7 are always set to -1.
   return value: 1 if the deal is acceptable, 0 if not*/


		PlayerAnswer = Random.Range (0,2);

		if (PlayerAnswer==1)
		{
			yield return StartCoroutine (say (arg5));
			//for the moment move to the player's backpack or if no room there drop them on the ground
			//Container cn = GameObject.Find (GameWorldController.instance.playerUW.GetComponent<PlayerInventory>().currentContainer).GetComponent<Container>();
			for (int i =0; i <=3; i++)
			{
				 TakeFromNPC (i);//Takes from the NPC slot if selected
			}


			//Now give the item to the NPC.
			//cn =npc.gameObject.GetComponent<Container>();
			for (int i =0; i <=3; i++)
			{
				TakeFromPC (i);
			}
		}
		else
		{
			//Debug.Log ("offer declined");
			switch ( Random.Range(1,5))
			{
			case 1:
				yield return StartCoroutine (say (arg1));break;
			case 2:
				yield return StartCoroutine (say (arg2));break;
			case 3:
				yield return StartCoroutine (say (arg3));break;
			case 4:
				yield return StartCoroutine (say (arg4));break;
			}
		}
	}

	/// <summary>
	/// Does the offer.
	/// </summary>
	public IEnumerator do_offer(int unk, int arg1, int arg2, int arg3, int arg4, int arg5, int arg6)
	{
		yield return StartCoroutine( do_offer (unk,arg1,arg2,arg3,arg4,arg5,arg6,-1) );
	}

	/// <summary>
	/// Player demands the items from the npc
	/// </summary>
	/// <returns>returns 1 when player persuaded the NPC, 0 else</returns>
	/// <param name="unk">Unk.</param>
	/// <param name="arg1">string id with text to print if NPC is not willing to give the item</param>
	/// <param name="arg2">string id with text if NPC gives the player the item</param>
	public IEnumerator do_demand(int unk, int arg1, int arg2)
	{
		/*
   id=0019 name="do_demand" ret_type=int
   parameters:   arg1: string id with text to print if NPC is not willing
                       to give the item
                 arg2: string id with text if NPC gives the player the item
   description:  decides if the player can "persuade" the NPC to give away
                 the items in barter area, e.g. using karma.
   return value: returns 1 when player persuaded the NPC, 0 else
		 */
		int DemandResult = Random.Range (0,2);
		if (DemandResult==1)
		{		
			//Demand sucessfull
			for (int i =0; i <=3; i++)
			{
				TakeFromNPC (i);//Takes from the NPC slot if selected
			}
			yield return StartCoroutine ( say (arg2) );
		}
		else
		{
			//Unsucessful
			yield return StartCoroutine ( say (arg1) );
		}

		//Move the players items back to his inventory;
		RestorePCsInventory ();
		PlayerAnswer=DemandResult;
	}

	/// <summary>
	/// Random value between 1 and High
	/// </summary>
	/// <param name="unk">Unk.</param>
	/// <param name="High">High value</param>
	public int random(int unk, int High)
	{
		return Random.Range(1,High+1);
	}

	/// <summary>
	/// Gets the quest variable.
	/// </summary>
	/// <returns>The quest.</returns>
	/// <param name="unk">Unk.</param>
	/// <param name="QuestNo">Quest no to lookup</param>
	public int get_quest(int unk, int QuestNo)
	{
		return GameWorldController.instance.playerUW.quest ().QuestVariables[QuestNo];
	}

		/// <summary>
		/// Sets the quest variable
		/// </summary>
		/// <param name="unk">Unk.</param>
		/// <param name="value">Value to change to</param>
		/// <param name="QuestNo">Quest no to change</param>
	public void set_quest(int unk,int value, int QuestNo)
	{
		GameWorldController.instance.playerUW.quest ().QuestVariables[QuestNo]=value;
	}

		/// <summary>
		/// Print the specified StringNo.
		/// </summary>
		/// <param name="unk1">Unk1.</param>
		/// <param name="StringNo">String no to print</param>
	public IEnumerator print(int unk1, int StringNo)
	{
		yield return StartCoroutine(say (StringNo,PRINT_SAY));
	}


		/// <summary>
		/// Identifies the item at the specified trade slot
		/// </summary>
		/// <param name="unk1">Unk1.</param>
		/// <param name="unk2">Unk2.</param>
		/// <param name="unk3">ItemId Sets the item id of the item into the locals array</param>
		/// <param name="unk4">Unk4.</param>
		/// <param name="inventorySlotIndex">Trade slot index.</param>
		public int identify_inv(int unk1, int[] locals, int unk2, int ItemId, int unk4, int tradeSlotIndex)
	{
		//id=0017 name="identify_inv" ret_type=int
		//	parameters:   arg1:
		//arg2:
		//arg3:
		//arg4: inventory item position
		//description:  unknown TODO
		//return value: unknown
		if (UWHUD.instance.playerTrade[tradeSlotIndex].GetGameObjectInteraction() != null)
		{
			UWHUD.instance.playerTrade[tradeSlotIndex].GetGameObjectInteraction().isIdentified=true;	
			locals[ItemId]=-UWHUD.instance.playerTrade[tradeSlotIndex].GetGameObjectInteraction().item_id;//Set as minus to flag this a an item id for string replacement
			return GameWorldController.instance.commobj.Value[UWHUD.instance.playerTrade[tradeSlotIndex].GetGameObjectInteraction().item_id];//Should this be the value of the item.
		}
		else
		{
			return 0;
		}
	}


		/*
	private void x_obj_stuff( int unk1, int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9)
	{
		Debug.Log("x_obj_stuff");		
		//id=002f name="x_obj_stuff" ret_type=void
		//	parameters:   arg1: not used in uw1
		//		arg2: not used in uw1
		//		arg3: 0, (upper bit of quality field?)
		//		arg4: quantity/special field, 115
		//		arg5: not used in uw1
		//		arg6: not used in uw1
		//		arg7: quality?
		//		arg8: identified flag?
		//		arg9: position in inventory object list
		//		description:  sets object properties for object in inventory object list.
		//			if a property shouldn't be set, -1 is passed for the
        //         property value.
		//If -1 then it sets the value in the array?

	}
*/

		/// <summary>
		/// X object stuff. Does various changes to objects.
		/// </summary>
		/// <param name="unk1">Unk1.</param>
		/// <param name="locals">Locals.</param>
		/// <param name="arg1">Arg1.</param>
		/// <param name="arg2">Arg2.</param>
		/// <param name="arg3">Arg3.</param>
		/// <param name="link">Link.</param>
		/// <param name="arg5">Arg5.</param>
		/// <param name="arg6">Arg6.</param>
		/// <param name="quality">Quality.</param>
		/// <param name="id">Identifier.</param>
		/// <param name="pos">Position.</param>

	public void x_obj_stuff( int unk1, int[] locals, int arg1, int arg2, int arg3, int link, int arg5, int arg6, int quality, int id, int pos)
	{
		//Debug.Log("x_obj_stuff");		
		//id=002f name="x_obj_stuff" ret_type=void
		//	parameters:   arg1: not used in uw1
		//		arg2: not used in uw1
		//		arg3: 0, (upper bit of quality field?)
		//		arg4: quantity/special field, 115
		//		arg5: not used in uw1
		//		arg6: not used in uw1
		//		arg7: quality?
		//		arg8: identified flag?
		//		arg9: position in inventory object list
		//		description:  sets object properties for object in inventory object list.
		//			if a property shouldn't be set, -1 is passed for the
		//         property value.
		//If -1 then it returns the value in the array?

		/*This may be implemented wrongly*/
		ObjectInteraction obj;
		if (pos<4)
		{//Item is in players trade area.
			obj= UWHUD.instance.playerTrade[pos].GetGameObjectInteraction();
		}
		else if (pos <=7)
		{//item in npc trade area
			obj= UWHUD.instance.npcTrade[pos-4].GetGameObjectInteraction();
		}
		else
		{
			return;
		}
		if (obj==null)
		{
			return;
		}

		if (locals[link]<=0)
			{
			locals[link]=obj.Link-512; 
			}
		else
			{
			obj.Link=locals[link]+512;
			}

		if (locals[quality]<=0)	
		{
			locals[quality]=obj.Quality; 
		}
		else
		{
			obj.Quality=locals[quality];
		}
		if (locals[id]<=0)
		{
			locals[id]=obj.item_id; 
		}
		else
		{
			obj.item_id=locals[id];
		}
	}

	/// <summary>
	/// Finds item in PC or NPC inventory
	/// </summary>
	/// <returns>position in master object list, or 0 if not found</returns>
	/// <param name="unk1">Unk1.</param>
	/// <param name="arg1">0: npc inventory; 1: player inventory</param>
	/// <param name="item_id">Item type ID of the object to find.</param>
	public int find_inv( int unk1, int arg1, int item_id )
	{
		//id=0030 name="find_inv" ret_type=int
		//	parameters:   arg1: 0: npc inventory; 1: player inventory
		//	arg2: item id
		//		description:  searches item in npc or player inventory
		//		return value: position in master object list, or 0 if not found
		switch (arg1)
		{
		case 0://NPC inventory
			Container npcCont = npc.gameObject.GetComponent<Container>();

			for ( int i=0; i<npcCont.Capacity; i++)
			{
				GameObject obj = npcCont.GetGameObjectAt(i);
				if (obj!=null)
				{
					if (obj.GetComponent<ObjectInteraction>().item_id==item_id)
					{
						return 1;//Found object
					}
				}
			}
			break;
		case 1://PC Search
			if (GameWorldController.instance.playerUW.GetComponent<Container>().findItemOfType(item_id) !="")
			{
				return 1;
			}
			else
			{
				return 0;
			}
		}
		return 0;
	}

	/// <summary>
	/// Gets the item at slot property quality.
	/// </summary>
	/// <returns>The item at slot property quality.</returns>
	/// <param name="SlotNo">Slot no to look at</param>
	public int GetItemAtSlotProperty_Quality(int SlotNo)
	{
		TradeSlot pcSlot = UWHUD.instance.playerTrade[SlotNo];//GameObject.Find ("Trade_Player_Slot_" + SlotNo).GetComponent<TradeSlot>();
		if(pcSlot!=null)
		{
			if (pcSlot.objectInSlot!="")
			{
				GameObject objectAtSlot=GameObject.Find (pcSlot.objectInSlot);
				if (objectAtSlot!=null)
				{
					ObjectInteraction objInt = objectAtSlot.GetComponent<ObjectInteraction>();
					if (objInt!=null)
					{
						return objInt.Quality;
					}
				}
			}
		}
		return 0;
	}

		/*
	/// <summary>
	/// Gets the item at slot property link.
	/// </summary>
	/// <returns>The item at slot property link.</returns>
	/// <param name="SlotNo">Slot no to look at</param>
	public int GetItemAtSlotProperty_Link(int SlotNo)
	{
		TradeSlot pcSlot = UWHUD.instance.playerTrade[SlotNo];//GameObject.Find ("Trade_Player_Slot_" + SlotNo).GetComponent<TradeSlot>();
		if(pcSlot!=null)
		{
			if (pcSlot.objectInSlot!="")
			{
				GameObject objectAtSlot=GameObject.Find (pcSlot.objectInSlot);
				if (objectAtSlot!=null)
				{
					ObjectInteraction objInt = objectAtSlot.GetComponent<ObjectInteraction>();
					if (objInt!=null)
					{
						return objInt.Link;
					}
				}
			}
		}
		return 0;
	}
		*/

		/// <summary>
		/// checks if the first string contains the second string,
		/// </summary>
		/// <returns>returns 1 when the string was found, 0 when not</returns>
		/// <param name="unk1">Unk1.</param>
		/// <param name="String1">String1.</param>
		/// <param name="String2">String2.</param>
	public int contains(int unk1, string String1, string String2)
	{
		//id=0007 name="contains" ret_type=int
		//parameters:   arg1: pointer to first string id
		//arg2: pointer to second string id
		//description:  checks if the first string contains the second string,
		//case-independent.
		//return value: returns 1 when the string was found, 0 when not
		if (String1.ToUpper().Contains(String2.ToUpper()))
		{
			return 1;
		}
		else
		{
			return 0;
		}
	}

		/// <summary>
		/// Checks if the string specified by StringBlock is the in the other string
		/// </summary>
		/// <param name="unk1">Unk1.</param>
		/// <param name="String1">String1.</param>
		/// <param name="StringBlock">String block.</param>
	public int contains(int unk1, string String1, int StringBlock)
	{
		//id=0007 name="contains" ret_type=int
		//parameters:   arg1: pointer to first string id
		//arg2: pointer to second string id
		//description:  checks if the first string contains the second string,
		//case-independent.
		//return value: returns 1 when the string was found, 0 when not
		return contains (unk1,String1, GetString (StringBlock));
	}

		/// <summary>
		/// X_skills.
		/// </summary>
		/// <returns>The skills.</returns>
		/// <param name="unk1">Unk1.</param>
		/// <param name="unk2">Unk2.</param>
		/// <param name="unk3">Unk3.</param>
	public int x_skills(int unk1, int unk2, int unk3)
	{
		//id=002c name="x_skills" ret_type=int
		//parameters:   unknown
		//description:  unknown
		//return value: unknown
		Debug.Log ("X_skill");
		return 1;
	}

		/// <summary>
		/// Checks the inv quality.
		/// </summary>
		/// <returns> returns "quality" field of npc? inventory item</returns>
		/// <param name="unk1">Unk1.</param>
		/// <param name="itemPos">Item position.</param>
	public int check_inv_quality(int unk1, int itemPos)
	{
		//id=001c name="check_inv_quality" ret_type=int
		//parameters:   arg1: inventory item position
		//description:  returns "quality" field of npc? inventory item
		//return value: "quality" field
		GameObject objInslot = GameObject.Find(UWHUD.instance.playerTrade[itemPos].objectInSlot);
		if (objInslot!=null)
		{
			return objInslot.GetComponent<ObjectInteraction>().Quality;
		}
		else
		{
			return 0;
		}
	}

		/// <summary>
		/// Sets the inv quality.
		/// </summary>
		/// <param name="unk1">Unk1.</param>
		/// <param name="NewQuality">New quality.</param>
		/// <param name="itemPos">Item position.</param>
	public void set_inv_quality(int unk1, int NewQuality, int itemPos)
	{
		//id=001d name="set_inv_quality" ret_type=int
		//parameters:   arg1: quality value
		//arg2: inventory object list position
		//description:  sets quality for an item in inventory
		//return value: none
		GameObject objInslot = GameObject.Find(UWHUD.instance.npcTrade[itemPos].objectInSlot);
		if (objInslot!=null)
		{
			objInslot.GetComponent<ObjectInteraction>().Quality= NewQuality;
		}
	}

		/// <summary>
		/// transfers item to player, per id (?)
		/// </summary>
		/// <returns>1: ok, 2: player has no space left</returns>
		/// <param name="unk1">Unk1.</param>
		/// <param name="ItemPos">Item position.</param>
	public int take_id_from_npc(int unk1, int ItemPos)
	{
		//id=0016 name="take_id_from_npc" ret_type=int
		//parameters:   arg1: inventory object list pos (from take_from_npc_inv)
		//description:  transfers item to player, per id (?)
		//return value: 1: ok, 2: player has no space left
		int playerHasSpace=1;
		Container cnpc = GameWorldController.instance.playerUW.gameObject.GetComponent<Container>();

		GameObject objInslot = GameObject.Find(UWHUD.instance.npcTrade[ItemPos].objectInSlot);
		if (objInslot!=null)
		{
			//Give to PC
			if (Container.GetFreeSlot(cnpc)!=-1)//Is there space in the container.
			{
				npc.GetComponent<Container>().RemoveItemFromContainer(objInslot.name);
				cnpc.AddItemToContainer(objInslot.name);
				GameWorldController.instance.playerUW.GetComponent<PlayerInventory>().Refresh ();
			}
			else
			{
				playerHasSpace=0;
				objInslot.transform.parent=GameWorldController.instance.LevelMarker();
				objInslot.transform.position=npc.transform.position;
				npc.GetComponent<Container>().RemoveItemFromContainer(objInslot.name);
			}
		}
		else
		{
			playerHasSpace=0;
		}

		return playerHasSpace;
	}

		/// <summary>
		// description:  Deletes item from npc inventory
		/// </summary>
		/// <param name="unk1">Unk1.</param>
		/// <param name="item_id">Item identifier.</param>
	public void do_inv_delete(int unk1, int item_id)
	{
		//id=001b name="do_inv_delete" ret_type=int
		//	parameters:   arg1: item id
		//		description:  deletes item from npc inventory
		//		return value: none

		Debug.Log ("do_inv_delete(" + item_id + ")");
	}


		/// <summary>
		/// creates item in npc inventory
		/// </summary>
		/// <returns>inventory object list position</returns>
		/// <param name="unk1">Unk1.</param>
		/// <param name="item_id">Item identifier.</param>
	public int do_inv_create(int unk1, int item_id)
	{
		//id=001a name="do_inv_create" ret_type=int
		//parameters:   arg1: item id
		//description:  creates item in npc inventory
		//return value: inventory object list position

		//GameObject myObj=new GameObject("SummonedObject_" + GameWorldController.instance.playerUW.PlayerMagic.SummonCount++);
		//myObj.layer=LayerMask.NameToLayer("UWObjects");
		//myObj.transform.position = GameWorldController.instance.playerUW.playerInventory.InventoryMarker.transform.position;
		//ObjectInteraction.CreateObjectGraphics(myObj,_RES +"/Sprites/Objects/Objects_" + item_id,true);
		
		ObjectInteraction objint = ObjectInteraction.CreateNewObject(item_id);
		GameObject myObj = objint.gameObject;
		/*
		switch (item_id)
		{//Some known cases
				case 0:
		case 10://A sword
			//ObjectInteraction.CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, _RES +"/Sprites/Objects/Objects_" +item_id.ToString ("000"), _RES +"/Sprites/Objects/Objects_" +item_id.ToString ("000"), _RES +"/Sprites/Objects/Objects_" +item_id.ToString ("000"), ObjectInteraction.SCENERY, item_id, 1, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
			WeaponMelee weap= myObj.AddComponent<WeaponMelee>();
			//weap.Skill=3;
			//TODO: add damage values
			
			break;
		case 276://Exploding book
			//ObjectInteraction.CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, _RES +"/Sprites/Objects/Objects_" +item_id.ToString ("000"), _RES +"/Sprites/Objects/Objects_" +item_id.ToString ("000"), _RES +"/Sprites/Objects/Objects_" +item_id.ToString ("000"), ObjectInteraction.BOOK, item_id, 0, 40, 0, 1, 1, 0, 1, 0, 1, 0, 1);
			myObj.AddComponent<ReadableTrap>();
			break;
		case 47://Dragonskin boots
			//ObjectInteraction.CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, _RES +"/Sprites/Objects/Objects_" +item_id.ToString ("000"), _RES +"/Sprites/Objects/Objects_" +item_id.ToString ("000"), _RES +"/Sprites/Objects/Objects_" +item_id.ToString ("000"), ObjectInteraction.BOOT, item_id, SpellEffect.UW1_Spell_Effect_Flameproof_alt01+256-16, 40, 0, 1, 1, 0, 1, 0, 1, 0, 1);
			//myObj.AddComponent<Boots>();
			//Boots.CreateBoots(myObj, _RES +"/Sprites/armour/armor_f_0060", _RES +"/Sprites/armour/armor_m_0060", _RES +"/Sprites/armour/armor_f_0060", _RES +"/Sprites/armour/armor_m_0060", _RES +"/Sprites/armour/armor_f_0060", _RES +"/Sprites/armour/armor_m_0060", _RES +"/Sprites/armour/armor_f_0060", _RES +"/Sprites/armour/armor_m_0060", 5, 17);
			m
			break;
		case 314:
			//ObjectInteraction.CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, _RES +"/Sprites/Objects/Objects_" +item_id.ToString ("000"), _RES +"/Sprites/Objects/Objects_" +item_id.ToString ("000"), _RES +"/Sprites/Objects/Objects_"+item_id.ToString ("000"), ObjectInteraction.SCROLL, item_id, 1, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
			myObj.AddComponent<Readable>();//Scroll given by Biden
			break;
		default:
			//ObjectInteraction.CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, _RES +"/Sprites/Objects/Objects_" +item_id.ToString ("000"), _RES +"/Sprites/Objects/Objects_" +item_id.ToString ("000"), _RES +"/Sprites/Objects/Objects_" +item_id.ToString ("000"), ObjectInteraction.SCENERY, item_id, 1, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
			myObj.AddComponent<object_base>();
			break;
		}
*/
		Container npccont = npc.GetComponent<Container>();
		if(npccont!=null)
			{
				npccont.AddItemToContainer (myObj.name);
			for (int i =0; i<4;i++)
				{
				if (UWHUD.instance.npcTrade[i].objectInSlot=="")
					{
						//NPCTradeItems[i]=myObj.name;
						TradeSlot ts = UWHUD.instance.npcTrade[i];
						ts.objectInSlot=myObj.name;
						ts.SlotImage.texture=myObj.GetComponent<ObjectInteraction>().GetInventoryDisplay().texture;
						return i;
					}
				}
			}
		return -1;
	}

		/// <summary>
		/// counts number of items in inventory
		/// </summary>
		/// <returns>item number</returns>
		/// <param name="unk1">Unk1.</param>
		/// <param name="ItemPos">Item position.</param>
	public int count_inv(int unk1, int ItemPos)
	{
		
		//id=001e name="count_inv" ret_type=int
		//parameters:   unknown
		//description:  counts number of items in inventory
		//return value: item number
		int total =0;
		GameObject objInslot = GameObject.Find(UWHUD.instance.playerTrade[ItemPos].objectInSlot);
		if (objInslot!=null)
		{
			ObjectInteraction objInt = objInslot.GetComponent<ObjectInteraction>();
			if (objInt!=null)
			{
				return objInt.GetQty();
			}
		}
		return total;
	}

	/// <summary>
	/// Sets list of items that a npc likes or dislikes to trade;
	/// </summary>
	/// <param name="unk1">Unk1.</param>
	/// <param name="unk2">Unk2.</param>
	/// <param name="unk3">Unk3.</param>
	public void set_likes_dislikes(int unk1, int unk2, int unk3)
	{
		//id=0024 name="set_likes_dislikes" ret_type=void
		//parameters:   arg1: pointer to list of things the npc likes to trade
		//arg2: pointer to list of things the npc dislikes to trade
		//description:  sets list of items that a npc likes or dislikes to trade;
		//the list is terminated with a -1 (0xffff) entry
		Debug.Log ("Set_Likes_Dislikes(" + unk2 + "," + unk3 +")");
	}



	/// <summary>
	/// compares strings for equality, case independent
	/// </summary>
	/// <returns>returns 1 when strings are equal, 0 when not</returns>
	/// <param name="unk1">Unk1.</param>
	/// <param name="StringIndex">String index.</param>
	/// <param name="StringIn">String in.</param>
	public int compare(int unk1, int StringIndex,  string StringIn)
	{
		//id=0004 name="compare" ret_type=int
		//	parameters:   arg1: string id
		//	arg2: string id
		//	description:  compares strings for equality, case independent
		//	return value: returns 1 when strings are equal, 0 when not

		//In this implemention I get the string at stringindex and compaire with  StringIn
		if (GetString(StringIndex).ToUpper() == StringIn.ToUpper())
		{
			return 1;
		}
		else
		{
			return 0;
		}
	}

		/// <summary>
		/// compares strings for equality, case independent.
		/// </summary>
		/// <returns>returns 1 when strings are equal, 0 when not</returns>
		/// <param name="unk1">Unk1.</param>
		/// <param name="StringIn">String in.</param>
		/// <param name="StringIndex">String index.</param>
	public int compare(int unk1, string StringIn,  int  StringIndex)
	{
		//id=0004 name="compare" ret_type=int
		//	parameters:   arg1: string id
		//	arg2: string id
		//	description:  compares strings for equality, case independent
		//	return value: returns 1 when strings are equal, 0 when not
		return compare(unk1, StringIndex,StringIn);		
	}

	/// <summary>
		///  removes npc the player is talking to (?)
	/// </summary>
	/// <param name="unk1">Unk1.</param>
	public void remove_talker(int unk1)
	{
		//   id=002a name="remove_talker" ret_type=void
	//parameters:   none
	//		description:  removes npc the player is talking to (?)
		this.gameObject.transform.position = GameWorldController.instance.playerUW.playerInventory.InventoryMarker.transform.position;//new Vector3(99f*1.2f, 3.0f, 99*1.2f);//Move them to the inventory box
	}

		/// <summary>
		///  sets attitude for a whole race (?)
		/// </summary>
		/// <param name="unk1">Unk1.</param>
		/// <param name="attitude">Attitude.</param>
	public void set_race_attitude(int unk1, int attitude)
	{//Used in Setharee Conversation Level 3
		//id=0026 name="set_race_attitude" ret_type=void
		//parameters:   unknown
		//description:  sets attitude for a whole race (?)
		//Debug.Log ("set_race_attitude " + attitude);
		NPC[] foundNPCs=GameWorldController.instance.LevelMarker().GetComponentsInChildren<NPC>();
		int myItemId=npc.objInt().item_id;
		for (int i=0; i<foundNPCs.GetUpperBound(0);i++)
		{
			if (foundNPCs[i].objInt().item_id== myItemId)
			{
				foundNPCs[i].npc_attitude=attitude;
			}
		}
	}



		/// <summary>
		/// Sets the race attitude.
		/// </summary>
		/// <param name="unk1">Unk1.</param>
		/// <param name="gtarg">Gtarg.</param>
		/// <param name="attitude">Attitude.</param>
		/// <param name="unk2">Unk2.</param>
		/// Seems to set attitude for all npcs with the whoami of the same value.
	public void set_race_attitude(int unk1, int gtarg, int attitude, int unk2)
	{
		//Used in Bandit chief conversation Level3
		//id=0026 name="set_race_attitude" ret_type=void
		//parameters:   unknown
		//description:  sets attitude for a whole race (?)
		//Seems to set attitude for all npcs with the whoami of the same value.
		//Debug.Log ("set_race_attitude " + attitude);
		NPC[] foundNPCs=GameWorldController.instance.LevelMarker().GetComponentsInChildren<NPC>();
		for (int i=0; i<foundNPCs.GetUpperBound(0);i++)
		{
			if (foundNPCs[i].npc_whoami== npc.npc_whoami)
			{
								Debug.Log("Setting attitude= " + attitude + " for " + foundNPCs[i].name);
				foundNPCs[i].npc_attitude=attitude;
				foundNPCs[i].npc_gtarg=gtarg;
			}
		}
	}

	/// <summary>
	/// Sets the attitude.
	/// Seems to update all npcs of that item type.
	/// </summary>
	/// <param name="unk1">Unk1.</param>
	/// <param name="Attitude">Attitude.</param>
	/// <param name="item_id">Seems to update all npcs of that item type.</param>
	public void set_attitude(int unk1, int attitude, int item_id)
	{
			//Occurs in Murgo's conversation but I need to see more examples since that will make characters hostile?
			//Occurs in bandit and head bandit conversation as well.
			//Seems to update all npcs of that item type.
			//Murgo's usage may be bugged as it does not refer to a item id?
			NPC[] foundNPCs=GameWorldController.instance.LevelMarker().GetComponentsInChildren<NPC>();
			for (int i=0; i<foundNPCs.GetUpperBound(0);i++)
			{
				if (foundNPCs[i].objInt().item_id== item_id)
				{
					foundNPCs[i].npc_attitude=attitude;
				}
			}
	}


	/// <summary>
	/// Copies item from player inventory to npc inventory
	/// </summary>
	/// <param name="unk1">Unk1.</param>
	/// <param name="Quantity">Quantity.</param>
	/// <param name="slotNo">Slot no.</param>
	public void give_ptr_npc(int unk1, int Quantity, int slotNo)
	{
		/*
		id=0014 name="give_ptr_npc" ret_type=int
		parameters:   arg1: quantity (?), or -1 for ignore
		arg2: inventory object list pos
		description:  copies item from player inventory to npc inventory
		return value: none
   		*/
		//Debug.Log ("give_ptr_npc");
		if  ( (slotNo<0) || (slotNo >3))
		{
			return;
		}
		Container cn =npc.gameObject.GetComponent<Container>();
		if (UWHUD.instance.playerTrade[slotNo].objectInSlot !="")
		{
			if ((Quantity==-1))
			{
				cn.AddItemToContainer(UWHUD.instance.playerTrade[slotNo].objectInSlot);
				UWHUD.instance.playerTrade[slotNo].clear ();
				GameWorldController.instance.playerUW.playerInventory.Refresh();
			}
			else
			{//Clone the object and give the clone to the npc
				GameObject objGiven = GameObject.Find (UWHUD.instance.playerTrade[slotNo].objectInSlot);
				if (objGiven!=null)
				{
					if  ((objGiven.GetComponent<ObjectInteraction>().isQuant==true)
					     && 
					     (objGiven.GetComponent<ObjectInteraction>().Link>1)
					     &&
					     (objGiven.GetComponent<ObjectInteraction>().isEnchanted==false)
					     &&
					     (objGiven.GetComponent<ObjectInteraction>().Link!=Quantity)
					     )
					{//Object is a quantity or is a quantity less than the number already there.
						GameObject Split = Instantiate(objGiven.gameObject);//What we are picking up.
						Split.GetComponent<ObjectInteraction>().Link =Quantity;
						Split.name = Split.name+"_"+GameWorldController.instance.playerUW.summonCount++;
						objGiven.GetComponent<ObjectInteraction>().Link=objGiven.GetComponent<ObjectInteraction>().Link-Quantity;
						cn.AddItemToContainer(objGiven.name);
					}
					else
					{//Object is not a quantity or is the full amount.
						cn.AddItemToContainer(UWHUD.instance.playerTrade[slotNo].objectInSlot);
						UWHUD.instance.playerTrade[slotNo].clear ();
						GameWorldController.instance.playerUW.playerInventory.Refresh();
					}
				}
			}
		}
	}

	/// <summary>
	/// Length of the specified string.
	/// </summary>
	/// <param name="unk1">Unk1.</param>
	/// <param name="str">String.</param>
	public int length(int unk1, string str)
	{
		//id=000b name="length" ret_type=int
		//	parameters:   arg1: string id
		//	description:  calculates length of string
		//	return value: length of string
		return str.Length;
	}


	/// <summary>
	/// searches for item in barter area
	/// </summary>
	/// <returns>This returns slot number + 1. Take this into account when retrieving the items in later functions</returns>
	/// <param name="unk1">Unk1.</param>
	/// <param name="itemID">item id to find</param>
	public int find_barter(int unk1, int itemID)
	{//This returns slot number + 1. Take this into account when retrieving the items in later functions
		//id=0031 name="find_barter" ret_type=int
		//	parameters:   arg1: item id to find
		//	description:  searches for item in barter area
		//	return value: returns pos in inventory object list, or 0 if not found
		// if arg1 > 1000 return Item Category is = + (arg1-1000)*16);
		for (int i = 0; i<4; i++)
		{
			if (UWHUD.instance.playerTrade[i].isSelected())
			    {
				ObjectInteraction objInt = UWHUD.instance.playerTrade[i].GetGameObjectInteraction();
				if (objInt!=null)
				{					
					if (itemID<1000)
					{
						if (objInt.item_id== itemID)
						{
							return i+1;
						}
					}
					else
					{
						if ((objInt.item_id>= (itemID-1000)*16) && (objInt.item_id< ((itemID+1)-1000)*16))
						{
							return i+1;
						}
					}
				}
			}

		}

		return 0;
	}

		/// <summary>
		///  places a generated object in underworld
		/// </summary>
		/// <param name="unk1">Unk1.</param>
		/// <param name="tileY">Tile y.</param>
		/// <param name="tileX">Tile x.</param>
		/// <param name="invSlot">inventory item slot number (from do_inv_create)</param>
	public void place_object( int unk1, int tileY, int tileX, int invSlot )
	{
	/*
   id=0027 name="place_object" ret_type=void
   parameters:   arg1: x tile pos
                 arg2: y tile pos
                 arg3: inventory item slot number (from do_inv_create)
   description:  places a generated object in underworld
                 used in Judy's conversation, #23

*/
		string objName = UWHUD.instance.npcTrade[invSlot].objectInSlot;
		GameObject obj = GameObject.Find (objName);
		if (obj!=null)
		{
			//obj.transform.position = new Vector3( 
			//                                     (((float)tileX) *1.2f)+0.6f, 
			//									(float)GameWorldController.instance.Tilemap.GetFloorHeight(GameWorldController.instance.LevelNo,tileX,tileY)  * 0.15f,
			//									(((float)tileY) *1.2f) +0.6f
			//                                     );
			obj.transform.position=GameWorldController.instance.Tilemap.getTileVector(tileX,tileY);
			obj.transform.parent=GameWorldController.instance.LevelMarker();
			npc.GetComponent<Container>().RemoveItemFromContainer(objName);
			UWHUD.instance.npcTrade[invSlot].clear();
		}
		return;
	}

		/// <summary>
		/// Finds the barter total.
		/// </summary>
		/// <returns>The barter total.</returns>
		/// <param name="unk1">Unk1.</param>
		/// <param name="ptrCount">Ptr count.</param>
		/// <param name="ptrSlot">Ptr slot.</param>
		/// <param name="ptrNoOfSlots">Ptr no of slots.</param>
		/// <param name="item_id">Item identifier.</param>
		/// <param name="variables">Variables.</param>
		/// My implementation 
		/// find the total number of matching items
		/// keep a list of slots where they are found
		/// keep a number of found slots.
	public int find_barter_total( int unk1, int ptrCount, int ptrSlot, int ptrNoOfSlots, int item_id, int[] variables )
	{
	/*
   id=0032 name="find_barter_total" ret_type=int
   parameters:   s[0]: ???
                 s[1]: pointer to number of found items
                 s[2]: pointer to
                 s[3]: pointer to
                 s[4]: pointer to item ID to find
   description:  searches for item in barter area
   return value: 1 when found (?)
	*/
/*
My implementation 
find the total number of matching items
keep a list of slots where they are found
keep a number of found slots.
		 */
		variables[ptrCount]=0;
		int counter=0;
		for (int i = 0; i<4; i++)
		{
			if (UWHUD.instance.playerTrade[i].isSelected())
			{
				ObjectInteraction objInt = UWHUD.instance.playerTrade[i].GetGameObjectInteraction();
				if (objInt!=null)
				{
					
					if (item_id<1000)
					{
						if (objInt.item_id== item_id)
						{
							variables[ptrCount] += objInt.GetQty();
							variables[ptrSlot+counter++]+= i;
							//return 1;
						}
					}
					else
					{
						if ((objInt.item_id>= (item_id-1000)*16) && (objInt.item_id< ((item_id+1)-1000)*16))
						{
							variables[ptrCount] += objInt.GetQty();
							//variables[ptrSlot]+= 1;
							variables[ptrSlot+counter++]+= i;
							//return 1;
						}
					}
				}
			}
			
		}
		variables[ptrNoOfSlots]= counter;
		if (counter>0)
		{
			return 1;
		}
		else
		{
			return 0;
		}
	}


		/// <summary>
		/// UWformats has no info on this. Based on usage in conversation 220 I think it means it looks at the same variables as the check variable traps
		/// </summary>
		/// <returns>The traps.</returns>
		/// <param name="unk1">Unk1.</param>
		/// <param name="unk2">Unk2.</param>
		/// <param name="VariableIndex">Variable index.</param>

	public int x_traps( int unk1, int unk2, int VariableIndex)
	{//UWformats has no info on this.
		//Based on usage in conversation 220 I think it means it looks at the same variables as the check variable traps
		return GameWorldController.instance.variables[VariableIndex];
	}


		/// <summary>
		/// Replaces the fields in the string with specific known examples for the conversation
		/// </summary>
		/// <returns>The replacement.</returns>
		/// <param name="src">Source.</param>
		public virtual string FieldReplacement(int[] locals, string src)
		{
			//Do my replacesments of Local variables first
			for (int i=locals.GetUpperBound(0); i>=0;i--)
			{
				if (src.Contains("@SS"+i))
				{//Replaces with a string.
					if (locals[i]<0)		
					{//minus means item id
						src=src.Replace("@SS"+i,StringController.instance.GetString(4, -locals[i]));		
					}
					else
					{
						src=src.Replace("@SS"+i,StringController.instance.GetString(StringBlock, locals[i]));	
					}
							
				}
				if (src.Contains("@SI"+i))
				{//REplaces with a value.
					src=src.Replace("@SI"+i, locals[i].ToString());		
				}
			}
			return src;	
		}
}