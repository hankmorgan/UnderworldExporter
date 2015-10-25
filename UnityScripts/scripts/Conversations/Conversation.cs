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
Implement intrinsic conversations in this class.


//Things to do.

Fix the Param arrays being passed into local functions. Especially ones that set the npcs attitude.
*/

public class Conversation : MonoBehaviour {

	public static UWCharacter playerUW;
	public static StringController SC;

	public static int CurrentConversation;
	public static bool InConversation = false;
	public static bool ConversationOpen=false;

	public int StringNo;

	public int[] privateVariables=new int[31] ;
	public int[] param1=new int[31];//TODO:is this correct. I think this only refers to params in functions calls. Eg void func_00b1. 
	//public int[] param2=new int[31];//TODO:is this correct


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

	public int PlayerAnswer;
	private int MinAnswer=1;
	private int MaxAnswer=1;


	//bool Ready=false;

	public int WhoAmI;

	public bool inputRecieved;
	public bool WaitingForInput;
	public bool WaitingForMore;

	int[] bablf_array = new int[10];
	private bool usingBablF=false;
	private int bablf_ans=0;

	public UITextList tl;//Text output.
	public UITextList tl_input;//player choices
	public UITexture OutPutControl;

	public UWFonts FontController;
	public static Camera maincam;

	public const float WaitTime=0.3f;//Is affected by the slomotime!
	public const float SlomoTime=0.1f;//To keep corountines running when ending convos and waiting out the WaitTime

	int LineWidth = 40 ;

	private string[] NPCTradeItems=new string[4];

	public NPC npc;

	public void SetupConversation(int stringno)
	{

		//Clear the trade slots for the npcs
		for (int i=0; i<4;i++)
		{
			TradeSlot ts = GameObject.Find ("Trade_NPC_Slot_" + i++).GetComponent<TradeSlot>();
			ts.clear ();
		}

		GameObject mus = GameObject.Find ("MusicController");
		if  (mus!=null)
		{
			mus.GetComponent<MusicController>().InMap=true;
		}
		//pause the world
		StringNo =stringno;// 3650;
		tl.Clear();
		Time.timeScale=0.0f;
		ConversationOpen=true;
		InConversation=true;
	}

	public void EndConversation()
	{
		Container cn = GameObject.Find (playerUW.GetComponent<PlayerInventory>().currentContainer).GetComponent<Container>();
		//Return any items in the trade area.
		for (int i =0; i <=3; i++)
		{
			TradeSlot npcSlot = GameObject.Find ("Trade_Player_Slot_" + i).GetComponent<TradeSlot>();
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
	}

	// Use this for initialization
	void Start () {

		npc = this.GetComponent<NPC>();
		WhoAmI = npc.npc_whoami;
		//tl.textLabel.lineHeight=340;//TODO:Get rid of this!
		//tl.textLabel.lineWidth=480;
	}
	
	// Update is called once per frame
	void Update () {
	if ((CurrentConversation==WhoAmI) && (InConversation==false) && (ConversationOpen==true))
		{
			Time.timeScale=1.0f;//start the clock 
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
		if (usingBablF ==false)
		{
			if ((AnswerNo>0) && (AnswerNo<=MaxAnswer))
			{
				WaitingForInput =true;
				PlayerAnswer=AnswerNo;
				WaitingForInput=false;
			}
		}
		else
		{
			if ((AnswerNo>0) && (AnswerNo<=MaxAnswer))
			{
				WaitingForInput =true;
				bablf_ans=AnswerNo;
				PlayerAnswer=bablf_array[AnswerNo-1];
				//Debug.Log ("Player answers is " + AnswerNo + " = " + bablf_array[AnswerNo]);
				WaitingForInput=false;
			}
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
			int colCounter=0;
			string Output="";
			for (int j =0; j<=StrWords.GetUpperBound(0);j++)
			{
				//char[] strChars =  StrWords[j].ToCharArray();
				if (StrWords[j].Length+colCounter>=LineWidth)
				{
					colCounter=0; 
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
			tl.Add(Output );
			if (i < Paragraphs.GetUpperBound(0))
				{//Pause for more when not the last paragraph.
				tl.Add("@@@ [MORE] " + " @@@ ");
				FontController.ConvertString(1,tl.textLabel.text,OutPutControl);
				yield return StartCoroutine(WaitForMore());
				}
			}
		tl.Add ( " @@@ ");
		//tl.Add(WhatToSay);
		FontController.ConvertString(1,tl.textLabel.text,OutPutControl);

		yield return 0;
		//Debug.Log(WhatToSay);
	}

	IEnumerator say(int WhatToSay)
	{
		string tmp = SC.GetString (StringNo,WhatToSay);
		yield return StartCoroutine(say (tmp));
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
		usingBablF=false;
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

		tl_input.maxEntries=1;
		tl_input.Add (tmp);
		yield return StartCoroutine(WaitForInput());

		tmp= SC.GetString(StringNo,localsArray[Start+PlayerAnswer-1]);
		yield return StartCoroutine(say (tmp + " @@@ "));
		yield return 0;
	}

	public IEnumerator babl_fmenu(int unknown, int[] localsArray, int Start, int flagIndex)
	{
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
					//Debug.Log ("Valid answer " + localsArray[i]);
					tmp = tmp + j++ + "." + SC.GetString(StringNo,localsArray[i]) + "\n";
					MaxAnswer++;
				}
			}
			else
			{
				break;
			}
		}
		
		tl_input.maxEntries=1;
		tl_input.Add (tmp);
		yield return StartCoroutine(WaitForInput());
		//Debug.Log ("bablfanswer=" +bablf_ans);
		//tmp= SC.GetString(StringNo,localsArray[Start+PlayerAnswer-1]);
		tmp= SC.GetString (StringNo,bablf_array[bablf_ans-1]);
		yield return StartCoroutine(say (" @@@ " + tmp + " @@@ "));
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
		//Debug.Log ("waitformore");
		WaitingForMore=true;
		while (WaitingForMore)
		{yield return null;}
		//Ready=true;
	}

	public void gronk_door(int unk, int Action, int tileY, int tileX)
	{
		/*
		id=0025 name="gronk_door" ret_type=int
		parameters:   arg1: x tile coordinate with door to open
		arg2: y tile coordinate
		arg3: close/open flag (0 means open)
		description:  opens/closes door or portcullis
		return value: unknown
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
			}
			else
			{
				Debug.Log ("Unable to find doorcontrol to gronk " + " at " + tileX + " " + tileY);
			}

		}
		else
		{
			Debug.Log ("Unable to find door to gronk " + " at " + tileX + " " + tileY);
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
	public int show_inv(int unk, int[] locals , int startObjectIDs,  int startObjectPos )
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

	public void give_to_npc(int unk, int[] locals, int NoOfItems, int start)
	{
		Container cn =npc.gameObject.GetComponent<Container>();
		for (int i=0; i<NoOfItems; i++)
		{
			int slotNo = locals[start+i] ;
			TradeSlot pcSlot = GameObject.Find ("Trade_Player_Slot_" + slotNo).GetComponent<TradeSlot>();
			//Give the item to the npc
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
		int playerHasSpace=1;
		int rangeS = (arg1-1000)*16;
		int rangeE = rangeS+16;
		Container cn = npc.gameObject.GetComponent<Container>();
		Container cnpc = playerUW.gameObject.GetComponent<Container>();
		for (int i = 0; i< cn.MaxCapacity ();i++)
		{
			string itemName=cn.GetItemAt (i);
			if (itemName!="")
			{
				ObjectInteraction objInt = GameObject.Find (itemName).GetComponent<ObjectInteraction>();
				if ((objInt.item_id >= rangeS ) && (objInt.item_id<=rangeE))
				{
					//Give to PC

					if (Container.GetFreeSlot(cnpc)!=-1)//Is there space in the container.
					{
						npc.GetComponent<Container>().RemoveItemFromContainer(itemName);
						cnpc.AddItemToContainer(itemName);
						playerUW.GetComponent<PlayerInventory>().Refresh ();
					}
					else
					{
						GameObject demanded = GameObject.Find (itemName);
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
					TradeSlot ts = GameObject.Find ("Trade_NPC_Slot_" + itemCount++).GetComponent<TradeSlot>();
					ts.objectInSlot=itemToTrade.gameObject.name;
					ts.SlotImage.mainTexture=itemToTrade.GetInventoryDisplay().texture;
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
			TradeSlot npcSlot = GameObject.Find ("Trade_NPC_Slot_" + i).GetComponent<TradeSlot>();
			TradeSlot pcSlot = GameObject.Find ("Trade_Player_Slot_" + i).GetComponent<TradeSlot>();
			if (npcSlot.isSelected()){npcObjectCount++;}
			if (pcSlot.isSelected()){playerObjectCount++;}
		}
		if (playerObjectCount<npcObjectCount)
		{
			yield return  StartCoroutine ( say ("Player has the better deal"));
		}
		else if (playerObjectCount==npcObjectCount)
		{
			yield return  StartCoroutine (say("It is an even deal"));
		}
		else
		{
			yield return  StartCoroutine (say ("NPC has the better deal"));
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
			TradeSlot npcSlot = GameObject.Find ("Trade_Player_Slot_" + i).GetComponent<TradeSlot>();
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



		Debug.Log ("Do Decline");
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
			Debug.Log ("offer accepted");
			yield return StartCoroutine (say (arg5));
			//for the moment move to the player's backpack or if no room there drop them on the ground
			Container cn = GameObject.Find (playerUW.GetComponent<PlayerInventory>().currentContainer).GetComponent<Container>();
			for (int i =0; i <=3; i++)
			{
				TradeSlot npcSlot = GameObject.Find ("Trade_NPC_Slot_" + i).GetComponent<TradeSlot>();
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
				TradeSlot pcSlot = GameObject.Find ("Trade_Player_Slot_" + i).GetComponent<TradeSlot>();
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
			Debug.Log ("offer declined");
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
			Debug.Log ("Demand sucessfull");
			for (int i =0; i <=3; i++)
			{
				TradeSlot npcSlot = GameObject.Find ("Trade_NPC_Slot_" + i).GetComponent<TradeSlot>();
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
			Debug.Log ("Demand unsucessfull");
			yield return StartCoroutine ( say (arg1) );
		}
		//Move the players items back to his inventory;

		//cn = GameObject.Find (playerUW.GetComponent<PlayerInventory>().currentContainer).GetComponent<Container>();
		for (int i =0; i <=3; i++)
		{
			TradeSlot npcSlot = GameObject.Find ("Trade_Player_Slot_" + i).GetComponent<TradeSlot>();
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
}


