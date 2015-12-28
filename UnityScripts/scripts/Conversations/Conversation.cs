using UnityEngine;
using System.Collections;

/*
Basic rules for converting conversations.

Create Subclass of Conversation called Conversation_[whoami]
Set up the main() as in the _67.
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
}


//Things to do.

Fix the Param arrays being passed into local functions. Especially ones that set the npcs attitude.
Fix up gender strings and other @SSx text replacements.
Replace strings with string numbers from strings file.
*/

public class Conversation : GuiBase {

	//public static UWCharacter playerUW;
	//public static StringController SC;
	//To flag the differnent ways to colour text
	private const int NPC_SAY=0;
	private const int PC_SAY=1;
	private const int PRINT_SAY=2;


	public static int CurrentConversation;
	public static bool InConversation = false;
	public static bool ConversationOpen=false;
	public static bool EnteringQty;

	private int StringBlock;

	public int[] privateVariables=new int[31] ;
//	public int[] param1=new int[31];//TODO:is this correct. I think this only refers to params in functions calls. Eg void func_00b1. 
	//public int[] param2=new int[31];//TODO:is this correct


	protected static int play_hunger;
	protected static int play_health;
	protected static int play_arms;
	protected static int play_power;
	protected static int play_hp;
	protected static int play_mana;
	protected static int play_level;
	protected static int new_player_exp;   //  (not used in uw1)
	protected static int play_name;       //   player name
	protected static int play_poison;      //  (not used in uw1)
	protected static int play_drawn;       //  is 1 when player has drawn his weapon (?)
	protected static int play_sex;         // (not used in uw1)
/*
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
*/
	public static int dungeon_level;    //  (not used in uw1)
	public static int riddlecounter;     // (not used in uw1)
	public static int game_time;
	public static int game_days;
	public static int game_mins;

	public static int PlayerAnswer;
	public static string PlayerTypedAnswer;
	private int MinAnswer=1;
	private int MaxAnswer=1;

	public int WhoAmI;

	public static bool inputRecieved;

	//Conversation waiting modes
	public static bool WaitingForInput;
	public static bool WaitingForMore;
	public static bool WaitingForTyping;

	public static int[] bablf_array = new int[10];
	public static bool usingBablF;
	public static int bablf_ans=0;

	public static UITextList tl;//Text output.
	public static ScrollController tl_input;//player choices
	public static UITexture OutPutControl;//Where the conversation is printed out
	public static UWFonts FontController;

	public static Camera maincam;

	public const float WaitTime=0.3f;//Is affected by the slomotime!
	public const float SlomoTime=0.1f;//To keep corountines running when ending convos and waiting out the WaitTime

	static int LineWidth = 37 ;

	private string[] NPCTradeItems=new string[4];

	public NPC npc;

	public void SetupConversation(int stringno)
	{

		/*Setup UI Elements - code formerly in NPC*/
		chains.ActiveControl=3;//Enable UI Elements
		chains.Refresh();
		
		UITexture portrait = GameObject.Find ("Conversation_Portrait_Right").GetComponent<UITexture>();
		portrait.mainTexture=Resources.Load <Texture2D> ("HUD/PlayerHeads/heads_"+ (playerUW.Body).ToString("0000"));
		
		if ((npc.npc_whoami!=0) && (npc.npc_whoami<=28))
		{
			//head in charhead.gr
			portrait = GameObject.Find ("Conversation_Portrait_Left").GetComponent<UITexture>();
			portrait.mainTexture=Resources.Load <Texture2D> ("HUD/Charheads/charhead_"+ (npc.npc_whoami-1).ToString("0000"));
			
		}	
		else
		{
			//head in charhead.gr
			int HeadToUse = this.GetComponent<ObjectInteraction>().item_id-64;
			if (HeadToUse >59)
			{
				HeadToUse=0;
			}
			portrait = GameObject.Find ("Conversation_Portrait_Left").GetComponent<UITexture>();
			portrait.mainTexture=Resources.Load <Texture2D> ("HUD/genhead/genhead_"+ (HeadToUse).ToString("0000"));
		}
		playerUW.playerHud.MessageScroll.Clear ();
		/*End UI Setup*/




		playerUW.playerMotor.enabled=false;

		//Setup the UI elements
		tl=playerUW.playerHud.Conversation_tl;
		//tl_input=playerUW.playerHud.Conversation_tl_input;
		tl_input=playerUW.playerHud.MessageScroll;
		tl.Clear();

		//Clear the trade slots for the npcs
		for (int i=0; i<4;i++)
		{
			//TradeSlot ts =
				playerUW.playerHud.npcTrade[i++].clear ();// GameObject.Find ("Trade_NPC_Slot_" + i++).GetComponent<TradeSlot>();
			//ts.clear ();
		}

		GameObject mus = GameObject.Find ("MusicController");
		if  (mus!=null)
		{
			mus.GetComponent<MusicController>().InMap=true;
		}

		StringBlock =stringno;

		//slow the world
		Time.timeScale=0.00f;
		ConversationOpen=true;
		InConversation=true;
	}

	public void EndConversation()
	{
		playerUW.playerMotor.enabled=true;
		Container cn = GameObject.Find (playerUW.GetComponent<PlayerInventory>().currentContainer).GetComponent<Container>();
		//Return any items in the trade area.
		for (int i =0; i <=3; i++)
		{
			TradeSlot npcSlot = playerUW.playerHud.playerTrade[i];//GameObject.Find ("Trade_Player_Slot_" + i).GetComponent<TradeSlot>();
			if (npcSlot.objectInSlot!="")
			{//Move the object to the players container or to the ground
				if (Container.GetFreeSlot(cn)!=-1)//Is there space in the container.
				{
					npc.GetComponent<Container>().RemoveItemFromContainer(npcSlot.objectInSlot);
					cn.AddItemToContainer(npcSlot.objectInSlot);
					npcSlot.clear ();
					playerUW.GetComponent<PlayerInventory>().Refresh ();
				}
				else
				{
					GameObject demanded = GameObject.Find (npcSlot.objectInSlot);
					demanded.transform.parent=null;
					demanded.transform.position=npc.transform.position;
					npc.GetComponent<Container>().RemoveItemFromContainer(npcSlot.objectInSlot);
					npcSlot.clear();
				}
			}

		}

		//Debug.Log ("End convo");
		Time.timeScale=1.0f;
		InConversation=false;
		npc.npc_talkedto=1;
		UWCharacter.InteractionMode=UWCharacter.InteractionModeTalk;
		GameObject mus = GameObject.Find ("MusicController");
		if  (mus!=null)
		{
			mus.GetComponent<MusicController>().InMap=false;
		}
		if (playerUW.playerInventory.ObjectInHand!="")
		{
			UWCharacter.InteractionMode=UWCharacter.InteractionModePickup;
		}
		StopAllCoroutines();
	}

	public virtual bool OnDeath()
	{//Code to be called upon the death of this character.
		//Mainly used for cases where specific character deaths set quest flags.
		//return true to stop further death event processing. (ie spilling inventory)
		//
		return false;
	}

	// Use this for initialization
	void Start () {

		npc = this.GetComponent<NPC>();
		WhoAmI = npc.npc_whoami;
		//tl.textLabel.lineHeight=340;//TODO:Get rid of this!
		//tl.textLabel.lineWidth=480;
	}

	void OnGUI()
	{
		if (EnteringQty==true)
		{
			return;
		}
		if ( ! ((CurrentConversation==WhoAmI) && (InConversation==false) && (ConversationOpen==true)) )
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
				playerUW.playerHud.InputControl.selected=true;
			}

		}
	}

	// Update is called once per frame
	void Update () {
	if ((CurrentConversation==WhoAmI) && (InConversation==false) && (ConversationOpen==true))
		{
			Time.timeScale=1.0f;//start the clock 
			ConversationOpen=false;
			tl.Clear ();
			tl_input.Clear ();
			//tl_input.maxEntries=5;
			maincam.enabled=true;
			chains.ActiveControl=0;
		}
	}

	private void CheckAnswer(int AnswerNo)
	{
		if (usingBablF ==false)
		{
		
			if ((AnswerNo>0) && (AnswerNo<=MaxAnswer))
			{
				//WaitingForInput =true;
				PlayerAnswer=AnswerNo;
				WaitingForInput=false;
			}
		}
		else
		{
			if ((AnswerNo>0) && (AnswerNo<=MaxAnswer))
			{
				bablf_ans=AnswerNo;
				PlayerAnswer=bablf_array[AnswerNo-1];
				WaitingForInput=false;
				usingBablF=false;
			}
		}
	}


	public virtual IEnumerator main()
	{
		//Debug.Log ("Start Conversation");
		//yield return StartCoroutine("I have yet to implement this conversation");
		//Time.timeScale =SlomoTime;
		//yield return new WaitForSeconds(WaitTime);
		playerUW.playerHud.MessageScroll.Add (playerUW.StringControl.GetString (7,1));
		//EndConversation();
		//yield break;
		//return null;
		yield break;
	}

	public IEnumerator say(string WhatToSay,int PrintType)
	{
		//Replace instances of @GS8 with player name
		WhatToSay = WhatToSay.Replace("@GS8" , playerUW.CharName);
		string[] Paragraphs = WhatToSay.Split(new string [] {"/m"}, System.StringSplitOptions.None);
		string Markup;
		switch (PrintType)
		{
		case PC_SAY:
			Markup="[FF0000]";break;
		case PRINT_SAY:
			Markup="[000000]";break;
		default:
			Markup="[00FF00]";break;
		}
		for (int i = 0; i<= Paragraphs.GetUpperBound(0);i++)
			{
			string[] StrWords = Paragraphs[i].Split(new char [] {' '});
			int colCounter=0;
			string Output="";
			for (int j =0; j<=StrWords.GetUpperBound(0);j++)
			{
				if (StrWords[j]=="\n")
				{
					tl.Add (Markup + Output +"[-]");
					colCounter=0;
					Output="";
				}
				else
				{
					if (StrWords[j].Length+colCounter+1>=LineWidth)
					{
						colCounter=0; 
						tl.Add (Markup + Output +"[-]");
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

			tl.Add (Markup + Output +"[-]");
			if (i < Paragraphs.GetUpperBound(0))
				{//Pause for more when not the last paragraph.
				tl.Add("[0000FF][MORE][-]");
				yield return StartCoroutine(WaitForMore());
				}
			}
		yield return 0;
	}

	public IEnumerator say(string WhatToSay)
	{
		yield return StartCoroutine (say(WhatToSay, NPC_SAY));
	}

	IEnumerator say(int WhatToSay)
	{
		string tmp = playerUW.StringControl.GetString (StringBlock,WhatToSay);
		yield return StartCoroutine(say (tmp,NPC_SAY));
	}

	IEnumerator say(int WhatToSay,int SayType)
	{
		string tmp = playerUW.StringControl.GetString (StringBlock,WhatToSay);
		yield return StartCoroutine(say (tmp,SayType));
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

	public string GetString(int index)
	{
		return playerUW.StringControl.GetString(StringBlock,index);
	}

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
				//tmp = tmp + j++ + "." + playerUW.StringControl.GetString(StringBlock,localsArray[i]) + "\n";
				tl_input.Add(j++ + "." + playerUW.StringControl.GetString(StringBlock,localsArray[i]).Replace("@GS8",playerUW.CharName));
				MaxAnswer++;
			}
			else
			{
				break;
			}
		}
		//tmp= tmp.Replace("@GS8" , playerUW.CharName);
		//tl_input.maxEntries=1;
		//tl_input.Add (tmp);

		yield return StartCoroutine(WaitForInput());

		tmp= playerUW.StringControl.GetString(StringBlock,localsArray[Start+PlayerAnswer-1]);
		yield return StartCoroutine(say (tmp,PC_SAY));
		yield return 0;
	}

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
					//tmp = tmp + j++ + "." + playerUW.StringControl.GetString(StringBlock,localsArray[i]) + "\n";
					tl_input.Add (j++ + "." + playerUW.StringControl.GetString(StringBlock,localsArray[i]));
					MaxAnswer++;
				}
			}
			else
			{
				break;
			}
		}
		
		//tl_input.maxEntries=1;
		//tl_input.Add (tmp);
		yield return StartCoroutine(WaitForInput());
		tmp= playerUW.StringControl.GetString (StringBlock,bablf_array[bablf_ans-1]);
		yield return StartCoroutine(say (tmp,PC_SAY));
		yield return 0;
	}


	public IEnumerator babl_ask(int unknown)
	{
		PlayerTypedAnswer="";
		//WaitingForTyping=true;
		tl_input.Set(">");

		UIInput inputctrl = playerUW.playerHud.InputControl; //tl_input.gameObject.GetComponent<UIInput>();
		inputctrl.GetComponent<GuiBase>().SetAnchorX(0.08f);
		inputctrl.eventReceiver=this.gameObject;
		inputctrl.type=UIInput.KeyboardType.Default;
		inputctrl.text="";
		inputctrl.label.text="";
		inputctrl.selected=true;
		yield return StartCoroutine(WaitForTypedInput());
		yield return StartCoroutine(say (PlayerTypedAnswer,PC_SAY));
		inputctrl.text="";
		inputctrl.label.text="";
		playerUW.playerHud.MessageScroll.Clear ();
	}

	public void OnSubmitPickup()
	{//Event receiver for input ctrl.
		WaitingForTyping=false;
		PlayerTypedAnswer= playerUW.playerHud.InputControl.text;//playerUW.playerHud.MessageScroll.gameObject.GetComponent<UIInput>().text;

		//Debug.Log (inputctrl.text);

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
	}

	IEnumerator WaitForMore()
	{
		WaitingForMore=true;
		while (WaitingForMore)
		{yield return null;}
	}

	IEnumerator WaitForTypedInput()
	{
		WaitingForTyping=true;
		while (WaitingForTyping)
		{yield return null;}
	}

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
				if (DC.getObjectInteraction ().Quality == 0)
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


	//Rewritten version of show_inv
	public int show_inv(int unk, int[] locals , int startObjectPos, int startObjectIDs)
	{
		int j=0;
		for (int i=0; i<4;i++)
		{
			TradeSlot pcSlot = GameObject.Find ("Trade_Player_Slot_" + i).GetComponent<TradeSlot>();
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

	public int give_to_npc(int unk, int[] locals, int start, int NoOfItems)
	{
		Container cn =npc.gameObject.GetComponent<Container>();
		bool SomethingGiven=false;
		for (int i=0; i<NoOfItems; i++)
		{
			int slotNo = locals[start+i] ;
			if (slotNo<=3)
			{
				TradeSlot pcSlot = playerUW.playerHud.playerTrade[slotNo];//GameObject.Find ("Trade_Player_Slot_" + slotNo).GetComponent<TradeSlot>();
				//Give the item to the npc
				if (Container.GetFreeSlot(cn)!=-1)//Is there space in the container.
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
						demanded.transform.parent=null;
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
	
	public int take_from_npc(int unk, int arg1)
	{
		///Debug.Log ("Take from NPC");
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
		Container cnpc = playerUW.gameObject.GetComponent<Container>();

			int rangeS = (arg1-1000)*16;
			int rangeE = rangeS+16;
			
			for (int i = 0; i< cn.MaxCapacity ();i++)
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
							demanded.transform.parent= playerUW.playerInventory.InventoryMarker.transform;
							npc.GetComponent<Container>().RemoveItemFromContainer(itemName);
							cnpc.AddItemToContainer(itemName);
							playerUW.GetComponent<PlayerInventory>().Refresh ();
						}
						else
						{
							playerHasSpace=0;
							demanded.transform.parent=null;
							demanded.transform.position=npc.transform.position;
							npc.GetComponent<Container>().RemoveItemFromContainer(itemName);
						}
					}
				}
			}
		return playerHasSpace;
	}

	public void setup_to_barter(int unk)
	{
		/*
   id=001f name="setup_to_barter" ret_type=void
   parameters:   none
   description:  starts bartering; shows npc items in npc bartering area
		 */
		//TODO: Figure out where generic NPCs get their inventory for trading from???? Is there a loot list somewhere?
		Container cn = npc.gameObject.GetComponent<Container>();
		int itemCount=0;
		for (int i= 0;i<4;i++)
		{NPCTradeItems[i]="";}

		Debug.Log ("Setup to barter. Based on characters inventory at the moment.");
		for (int i =0 ; i< 40; i++)
		{
			if (cn.GetItemAt(i)!="")
			{
				if (itemCount <=3)
				{//Just take the first four items
					ObjectInteraction itemToTrade = GameObject.Find (cn.GetItemAt(i)).GetComponent<ObjectInteraction>();
					NPCTradeItems[itemCount]=itemToTrade.gameObject.name;
					TradeSlot ts = playerUW.playerHud.npcTrade[itemCount++];//GameObject.Find ("Trade_NPC_Slot_" + itemCount++).GetComponent<TradeSlot>();
					ts.objectInSlot=itemToTrade.gameObject.name;
					ts.SlotImage.mainTexture=itemToTrade.GetInventoryDisplay().texture;
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

	public IEnumerator do_judgement(int unk)
	{
		/*
	id=0021 name="do_judgement" ret_type=void
   parameters:   none
   description:  judges current trade (using the "appraise" skill) and prints result
		 */
		//Debug.Log ("Do Judgment");
		//TODO: figure out how this works. for the moment just base it out quantity of objects selected
		int playerObjectCount=0; int npcObjectCount=0;
		for (int i = 0; i<4; i++)
		{
			TradeSlot npcSlot = playerUW.playerHud.npcTrade[i];//GameObject.Find ("Trade_NPC_Slot_" + i).GetComponent<TradeSlot>();
			TradeSlot pcSlot =  playerUW.playerHud.playerTrade[i];// GameObject.Find ("Trade_Player_Slot_" + i).GetComponent<TradeSlot>();
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

	public void do_decline(int unk)
	{
		/*
   id=0022 name="do_decline" ret_type=void
   parameters:   none
   description:  declines trade offer (?)
		*/

		//returns all items back to the players inventory or onto the ground


		Container cn = GameObject.Find (playerUW.GetComponent<PlayerInventory>().currentContainer).GetComponent<Container>();
		for (int i =0; i <=3; i++)
		{
			TradeSlot pcSlot =  playerUW.playerHud.playerTrade[i] ;//GameObject.Find ("Trade_Player_Slot_" + i).GetComponent<TradeSlot>();
			if (pcSlot.objectInSlot!="")
			{//Move the object to the players container or to the ground
				if (Container.GetFreeSlot(cn)!=-1)//Is there space in the container.
				{
					//playerUW.GetComponent<Container>().RemoveItemFromContainer(pcSlot.objectInSlot);
					cn.AddItemToContainer(pcSlot.objectInSlot);
					pcSlot.clear ();
					playerUW.GetComponent<PlayerInventory>().Refresh ();
				}
				else
				{
					GameObject demanded = GameObject.Find (pcSlot.objectInSlot);
					demanded.transform.parent=null;
					demanded.transform.position=npc.transform.position;
					//npc.GetComponent<Container>().RemoveItemFromContainer(pcSlot.objectInSlot);
					pcSlot.clear();
				}
			}
		}

		for (int i=0; i<=3; i++)
		{//Clear out the trade slots.
			playerUW.playerHud.npcTrade[i].clear();
		}


		//Debug.Log ("Do Decline");
		return;
	}

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

/*I think the values passed are actually the strings for how the npc reacts to the offer. The value judgment is done elsewhere*/

		//In the prototype I randomise the decision. And then randomise a response based on that decision.
		//Arg5 is the yes answer
		PlayerAnswer = Random.Range (0,2);

		if (PlayerAnswer==1)
		{
			//Debug.Log ("offer accepted");
			yield return StartCoroutine (say (arg5));
			//for the moment move to the player's backpack or if no room there drop them on the ground
			Container cn = GameObject.Find (playerUW.GetComponent<PlayerInventory>().currentContainer).GetComponent<Container>();
			for (int i =0; i <=3; i++)
			{
				TradeSlot npcSlot = playerUW.playerHud.npcTrade[i];//GameObject.Find ("Trade_NPC_Slot_" + i).GetComponent<TradeSlot>();
				if (npcSlot.isSelected())
				{//Move the object to the container or to the ground
					if (Container.GetFreeSlot(cn)!=-1)//Is there space in the container.
					{
						npc.GetComponent<Container>().RemoveItemFromContainer(npcSlot.objectInSlot);
						cn.AddItemToContainer(npcSlot.objectInSlot);
						npcSlot.clear ();
						playerUW.GetComponent<PlayerInventory>().Refresh ();
					}
					else
					{
						GameObject demanded = GameObject.Find (npcSlot.objectInSlot);
						demanded.transform.parent=null;
						demanded.transform.position=npc.transform.position;
						npc.GetComponent<Container>().RemoveItemFromContainer(npcSlot.objectInSlot);
						npcSlot.clear();
					}
				}
			}


			//Now give the item to the NPC.
			cn =npc.gameObject.GetComponent<Container>();
			for (int i =0; i <=3; i++)
			{
				TradeSlot pcSlot =playerUW.playerHud.playerTrade[i] ;//GameObject.Find ("Trade_Player_Slot_" + i).GetComponent<TradeSlot>();
				if (pcSlot.isSelected())
				{//Move the object to the container or to the ground
					if (Container.GetFreeSlot(cn)!=-1)//Is there space in the container.
					{
						cn.AddItemToContainer(pcSlot.objectInSlot);
						pcSlot.clear ();
					}
					else
					{
						GameObject demanded = GameObject.Find (pcSlot.objectInSlot);
						demanded.transform.parent=null;
						demanded.transform.position=npc.transform.position;
						pcSlot.clear();
					}
				}
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
	
		//Debug.Log ("Do Offer");
		//return Random.Range (0,2);
	}

	public IEnumerator do_offer(int unk, int arg1, int arg2, int arg3, int arg4, int arg5, int arg6)
	{
		yield return StartCoroutine( do_offer (unk,arg1,arg2,arg3,arg4,arg5,arg6,-1) );
	}

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
		Container cn = GameObject.Find (playerUW.GetComponent<PlayerInventory>().currentContainer).GetComponent<Container>();
		int DemandResult = Random.Range (0,2);
		if (DemandResult==1)
		{		
			//Debug.Log ("Demand sucessfull");
			for (int i =0; i <=3; i++)
			{
				TradeSlot npcSlot =playerUW.playerHud.npcTrade[i] ;//GameObject.Find ("Trade_NPC_Slot_" + i).GetComponent<TradeSlot>();
				if (npcSlot.isSelected())
				{//Move the object to the container or to the ground
					if (Container.GetFreeSlot(cn)!=-1)//Is there space in the container.
					{
						npc.GetComponent<Container>().RemoveItemFromContainer(npcSlot.objectInSlot);
						cn.AddItemToContainer(npcSlot.objectInSlot);
						npcSlot.clear ();
						playerUW.GetComponent<PlayerInventory>().Refresh ();
					}
					else
					{
						GameObject demanded = GameObject.Find (npcSlot.objectInSlot);
						demanded.transform.parent=null;
						demanded.transform.position=npc.transform.position;
						npc.GetComponent<Container>().RemoveItemFromContainer(npcSlot.objectInSlot);
						npcSlot.clear();
					}
				}
			}
			yield return StartCoroutine ( say (arg2) );

		}
		else
		{
			//Debug.Log ("Demand unsucessfull");
			yield return StartCoroutine ( say (arg1) );
		}
		//Move the players items back to his inventory;

		//cn = GameObject.Find (playerUW.GetComponent<PlayerInventory>().currentContainer).GetComponent<Container>();
		for (int i =0; i <=3; i++)
		{
			TradeSlot npcSlot = playerUW.playerHud.playerTrade[i];//GameObject.Find ("Trade_Player_Slot_" + i).GetComponent<TradeSlot>();
			if (npcSlot.objectInSlot!="")
			{//Move the object to the players container or to the ground
				if (Container.GetFreeSlot(cn)!=-1)//Is there space in the container.
				{
					npc.GetComponent<Container>().RemoveItemFromContainer(npcSlot.objectInSlot);
					cn.AddItemToContainer(npcSlot.objectInSlot);
					npcSlot.clear ();
					playerUW.GetComponent<PlayerInventory>().Refresh ();
				}
				else
				{
					GameObject demanded = GameObject.Find (npcSlot.objectInSlot);
					demanded.transform.parent=null;
					demanded.transform.position=npc.transform.position;
					npc.GetComponent<Container>().RemoveItemFromContainer(npcSlot.objectInSlot);
					npcSlot.clear();
				}
			}
		}

	


		PlayerAnswer=DemandResult;
	}

	public int random(int unk, int High)
	{
		return Random.Range(1,High+1);
	}

	public int get_quest(int unk, int QuestNo)
	{
		return playerUW.quest ().QuestVariables[QuestNo];
	}

	public void set_quest(int unk,int value, int QuestNo)
	{
		playerUW.quest ().QuestVariables[QuestNo]=value;
	}

	public IEnumerator print(int unk1, int StringBlock)
	{
		yield return StartCoroutine(say (StringBlock,PRINT_SAY));
	}

	public int identify_inv(int unk1, int unk2, int unk3, int unk4, int unk5)
	{
		//id=0017 name="identify_inv" ret_type=int
		//	parameters:   arg1:
		//arg2:
		//arg3:
		//arg4: inventory item position
		//description:  unknown TODO
		//return value: unknown

		//My guess that it is identifying the gold value of the items given.
		Debug.Log ("Identify_inv");
		return 1;
	}

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
			obj= playerUW.playerHud.playerTrade[pos].GetGameObjectInteraction();
		}
		else if (pos <=7)
		{//item in npc trade area
			obj= playerUW.playerHud.npcTrade[pos-4].GetGameObjectInteraction();
		}
		else
		{
			return;
		}
		if (obj==null)
		{
			return;
		}

		if (locals[link]==-1)
			{
			locals[link]=obj.Link; 
			}
		else
			{
			obj.Link=locals[link]+512;
			}

		if (locals[quality]==-1)
		{
			locals[quality]=obj.Quality; 
		}
		else
		{
			obj.Quality=locals[quality];
		}
	}

	public int find_inv( int unk1, int arg1, int arg2 )
	{
		//id=0030 name="find_inv" ret_type=int
		//	parameters:   arg1: 0: npc inventory; 1: player inventory
		//	arg2: item id
		//		description:  searches item in npc or player inventory
		//		return value: position in master object list, or 0 if not found
		//Debug.Log("find_inv");
		switch (arg1)
		{
		case 0://NPC inventory
			Container npcCont = npc.gameObject.GetComponent<Container>();

			for ( int i=0; i<npcCont.Capacity; i++)
			{
				GameObject obj = npcCont.GetGameObjectAt(i);
				if (obj!=null)
				{
					if (obj.GetComponent<ObjectInteraction>().item_id==arg2)
					{
						return 1;//Found object
					}
				}
			}
			break;
		case 1://PC Search
			//Debug.Log ("find_Inv player");
			if (playerUW.GetComponent<Container>().findItemOfType(arg2) !="")
			{
				return 1;
			}
			else
			{
				return 0;
			}
			break;

		}

		return 0;
	}


	public int GetItemAtSlotProperty_Quality(int SlotNo)
	{
		TradeSlot pcSlot = playerUW.playerHud.playerTrade[SlotNo];//GameObject.Find ("Trade_Player_Slot_" + SlotNo).GetComponent<TradeSlot>();
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

	public int GetItemAtSlotProperty_Link(int SlotNo)
	{
		TradeSlot pcSlot = playerUW.playerHud.playerTrade[SlotNo];//GameObject.Find ("Trade_Player_Slot_" + SlotNo).GetComponent<TradeSlot>();
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


	public int x_skills(int unk1, int unk2, int unk3)
	{
		//id=002c name="x_skills" ret_type=int
		//parameters:   unknown
		//description:  unknown
		//return value: unknown
		Debug.Log ("X_skill");
		return 1;
	}

	public int check_inv_quality(int unk1, int itemPos)
	{
		//id=001c name="check_inv_quality" ret_type=int
		//parameters:   arg1: inventory item position
		//description:  returns "quality" field of npc? inventory item
		//return value: "quality" field
		GameObject objInslot = GameObject.Find(playerUW.playerHud.playerTrade[itemPos].objectInSlot);
		if (objInslot!=null)
		{
			return objInslot.GetComponent<ObjectInteraction>().Quality;
		}
		else
		{
			return 0;
		}

	}


	public void set_inv_quality(int unk1, int NewQuality, int itemPos)
	{
		//id=001d name="set_inv_quality" ret_type=int
		//parameters:   arg1: quality value
		//arg2: inventory object list position
		//description:  sets quality for an item in inventory
		//return value: none
		GameObject objInslot = GameObject.Find(playerUW.playerHud.npcTrade[itemPos].objectInSlot);
		if (objInslot!=null)
		{
			objInslot.GetComponent<ObjectInteraction>().Quality= NewQuality;
		}
	}


	public int take_id_from_npc(int unk1, int ItemPos)
	{
		//id=0016 name="take_id_from_npc" ret_type=int
		//parameters:   arg1: inventory object list pos (from take_from_npc_inv)
		//description:  transfers item to player, per id (?)
		//return value: 1: ok, 2: player has no space left
		int playerHasSpace=1;
		Container cn = npc.gameObject.GetComponent<Container>();
		Container cnpc = playerUW.gameObject.GetComponent<Container>();

		GameObject objInslot = GameObject.Find(playerUW.playerHud.npcTrade[ItemPos].objectInSlot);
		if (objInslot!=null)
		{
			//Give to PC
			if (Container.GetFreeSlot(cnpc)!=-1)//Is there space in the container.
			{
				npc.GetComponent<Container>().RemoveItemFromContainer(objInslot.name);
				cnpc.AddItemToContainer(objInslot.name);
				playerUW.GetComponent<PlayerInventory>().Refresh ();
			}
			else
			{
				playerHasSpace=0;
			//	GameObject demanded = GameObject.Find (objInslot.anem);
				objInslot.transform.parent=null;
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

	public void do_inv_delete(int unk1, int item_id)
	{
		//id=001b name="do_inv_delete" ret_type=int
		//	parameters:   arg1: item id
		//		description:  deletes item from npc inventory
		//		return value: none

		Debug.Log ("do_inv_delete(" + item_id + ")");
	}


	public int do_inv_create(int unk1, int item_id)
	{
		//id=001a name="do_inv_create" ret_type=int
		//parameters:   arg1: item id
		//description:  creates item in npc inventory
		//return value: inventory object list position
		//Debug.Log ("do_inv_create(" + item_id + ")");

		GameObject myObj=new GameObject("SummonedObject_" + GameWorldController.instance.playerUW.PlayerMagic.SummonCount++);
		myObj.layer=LayerMask.NameToLayer("UWObjects");
		myObj.transform.position = playerUW.playerInventory.InventoryMarker.transform.position;
		ObjectInteraction.CreateObjectGraphics(myObj,"Sprites/OBJECTS_" + item_id,true);

		switch (item_id)
		{//Some known cases
		case 276://Exploding book
			ObjectInteraction.CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_" +item_id.ToString ("000"), "Sprites/OBJECTS_" +item_id.ToString ("000"), "Sprites/OBJECTS_" +item_id.ToString ("000"), ObjectInteraction.BOOK, item_id, 0, 40, 0, 1, 1, 0, 1, 0, 1, 0, 1);
			myObj.AddComponent<ReadableTrap>();
			break;
		case 47://Dragonskin boots
			ObjectInteraction.CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_" +item_id.ToString ("000"), "Sprites/OBJECTS_" +item_id.ToString ("000"), "Sprites/OBJECTS_" +item_id.ToString ("000"), ObjectInteraction.BOOT, item_id, SpellEffect.UW1_Spell_Effect_Flameproof_alt01+256-16, 40, 0, 1, 1, 0, 1, 0, 1, 0, 1);
			//myObj.AddComponent<Boots>();
			Boots.CreateBoots(myObj, "Sprites/armour/armor_f_0060", "Sprites/armour/armor_m_0060", "Sprites/armour/armor_f_0060", "Sprites/armour/armor_m_0060", "Sprites/armour/armor_f_0060", "Sprites/armour/armor_m_0060", "Sprites/armour/armor_f_0060", "Sprites/armour/armor_m_0060", 5, 17);
			break;
		case 314:
			ObjectInteraction.CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_" +item_id.ToString ("000"), "Sprites/OBJECTS_" +item_id.ToString ("000"), "Sprites/OBJECTS_"+item_id.ToString ("000"), ObjectInteraction.SCROLL, item_id, 1, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
			myObj.AddComponent<Readable>();//Scroll given by Biden
			break;
		default:
			ObjectInteraction.CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_" +item_id.ToString ("000"), "Sprites/OBJECTS_" +item_id.ToString ("000"), "Sprites/OBJECTS_" +item_id.ToString ("000"), ObjectInteraction.SCENERY, item_id, 1, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
			myObj.AddComponent<object_base>();
			break;
		}

		Container npccont = npc.GetComponent<Container>();
		if(npccont!=null)
			{
				npccont.AddItemToContainer (myObj.name);
			for (int i =0; i<4;i++)
				{
				if (playerUW.playerHud.npcTrade[i].objectInSlot=="")
					{
						//NPCTradeItems[i]=myObj.name;
						TradeSlot ts = playerUW.playerHud.npcTrade[i];//GameObject.Find ("Trade_NPC_Slot_" + itemCount++).GetComponent<TradeSlot>();
						ts.objectInSlot=myObj.name;
						ts.SlotImage.mainTexture=myObj.GetComponent<ObjectInteraction>().GetInventoryDisplay().texture;
						return i;
					}
					//ObjectInteraction itemToTrade = GameObject.Find (cn.GetItemAt(i)).GetComponent<ObjectInteraction>();
				}
			}
		return -1;
	}

	public int count_inv(int unk1, int ItemPos)
	{
		
		//id=001e name="count_inv" ret_type=int
		//parameters:   unknown
		//description:  counts number of items in inventory
		//return value: item number
		int total =0;
		GameObject objInslot = GameObject.Find(playerUW.playerHud.playerTrade[ItemPos].objectInSlot);
		if (objInslot!=null)
		{
			ObjectInteraction objInt = objInslot.GetComponent<ObjectInteraction>();
			//if ((objInt.isQuant) && (objInt.isEnchanted==false))
			//    {
			//	total= objInt.Link;
			//	}
			//else
			//	{
			//	total= 1;
			//	}
			if (objInt!=null)
			{
				return objInt.GetQty();
			}
		}

		return total;
	}


	public void set_likes_dislikes(int unk1, int unk2, int unk3)
	{
		//id=0024 name="set_likes_dislikes" ret_type=void
		//parameters:   arg1: pointer to list of things the npc likes to trade
		//arg2: pointer to list of things the npc dislikes to trade
		//description:  sets list of items that a npc likes or dislikes to trade;
		//the list is terminated with a -1 (0xffff) entry
		Debug.Log ("Set_Likes_Dislikes(" + unk2 + "," + unk3 +")");
	}

	public void set_attitude(int unk1, int Attitude, int NPC_WHO_AM_I)
	{

		//Occurs in Murgo's conversation but I need to see more examples since that will make characters hostile?
		//Occurs in bandit and head bandit conversation as well.
		//Seems to update all npcs of that item type.
		Debug.Log ("Setting attitude for whoami " + NPC_WHO_AM_I + " to " + Attitude);
	}

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

	public int compare(int unk1, string StringIn,  int  StringIndex)
	{
		//id=0004 name="compare" ret_type=int
		//	parameters:   arg1: string id
		//	arg2: string id
		//	description:  compares strings for equality, case independent
		//	return value: returns 1 when strings are equal, 0 when not
		return compare(unk1, StringIndex,StringIn);		
	}


	public void remove_talker(int unk1)
	{
		//   id=002a name="remove_talker" ret_type=void
	//parameters:   none
	//		description:  removes npc the player is talking to (?)
		this.gameObject.transform.position = new Vector3(99f*1.2f, 3.0f, 99*1.2f);//Move them to the inventory box
	}


	public void set_race_attitude(int unk1, int attitude)
	{//Used in Setharee Conversation Level 3
		//id=0026 name="set_race_attitude" ret_type=void
		//parameters:   unknown
		//description:  sets attitude for a whole race (?)
		Debug.Log ("set_race_attitude " + attitude);
	}


	public void set_race_attitude(int unk1, int attitude, int unk2, int unk3)
	{
		//Used in Bandit chief conversation Level3
		//id=0026 name="set_race_attitude" ret_type=void
		//parameters:   unknown
		//description:  sets attitude for a whole race (?)
		//Seems to set attitude for all npcs with the whoami of the same value.
		Debug.Log ("set_race_attitude " + attitude);
	}


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
		if (playerUW.playerHud.playerTrade[slotNo].objectInSlot !="")
		{
			if ((Quantity==-1))
			{
				cn.AddItemToContainer(playerUW.playerHud.playerTrade[slotNo].objectInSlot);
				playerUW.playerHud.playerTrade[slotNo].clear ();
				playerUW.playerInventory.Refresh();
			}
			else
			{//Clone the object and give the clone to the npc
				GameObject objGiven = GameObject.Find (playerUW.playerHud.playerTrade[slotNo].objectInSlot);
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
						Split.name = Split.name+"_"+playerUW.summonCount++;
						objGiven.GetComponent<ObjectInteraction>().Link=objGiven.GetComponent<ObjectInteraction>().Link-Quantity;
						cn.AddItemToContainer(objGiven.name);
					}
					else
					{//Object is not a quantity or is the full amount.
						cn.AddItemToContainer(playerUW.playerHud.playerTrade[slotNo].objectInSlot);
						playerUW.playerHud.playerTrade[slotNo].clear ();
						playerUW.playerInventory.Refresh();
					}
				}
			}
		}
	}

	public int length(int unk1, string str)
	{
		//id=000b name="length" ret_type=int
		//	parameters:   arg1: string id
		//	description:  calculates length of string
		//	return value: length of string
		return str.Length;
	}


	public int find_barter(int unk1, int arg1)
	{//This returns slot number + 1. Take this into account when retrieving the items in later functions
		//id=0031 name="find_barter" ret_type=int
		//	parameters:   arg1: item id to find
		//	description:  searches for item in barter area
		//	return value: returns pos in inventory object list, or 0 if not found
		// if arg1 > 1000 return Item Category is = + (arg1-1000)*16);
		for (int i = 0; i<4; i++)
		{
			if (playerUW.playerHud.playerTrade[i].isSelected())
			    {
				ObjectInteraction objInt = playerUW.playerHud.playerTrade[i].GetGameObjectInteraction();
				if (objInt!=null)
				{
					
					if (arg1<1000)
					{
						if (objInt.item_id== arg1)
						{
							return i+1;
						}
					}
					else
					{
						if ((objInt.item_id>= (arg1-1000)*16) && (objInt.item_id< ((arg1+1)-1000)*16))
						{
							return i+1;
						}
					}
				}
			}

		}

		return 0;
	}

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
		Debug.Log ("placeobject");
		string objName = playerUW.playerHud.npcTrade[invSlot].objectInSlot;
		GameObject obj = GameObject.Find (objName);
		if (obj!=null)
		{
			obj.transform.position = new Vector3( 
			                                     (((float)tileX) *1.2f), 
			                                     (float)GameWorldController.instance.Tilemap.GetFloorHeight(tileX,tileY),
			                                     (((float)tileY) *1.2f) 
			                                     );
			npc.GetComponent<Container>().RemoveItemFromContainer(objName);
			playerUW.playerHud.npcTrade[invSlot].clear();
		}


		return;
	}


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
			if (playerUW.playerHud.playerTrade[i].isSelected())
			{
				ObjectInteraction objInt = playerUW.playerHud.playerTrade[i].GetGameObjectInteraction();
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
}


