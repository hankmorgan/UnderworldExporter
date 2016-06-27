using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ScrollController : GuiBase {
/*
 * API for controlling how text is displayed on the ui scroll
 * Controls splitting of strings, new lines, [more] 
 */

	public int LineWidth = 65;//No of characters in a line

	public string[]txtToDisplay = new string[5];

	//public UITextList uiIn;
	public Text NewUIOUt;
	public int ptr;
	public int MaxEntries;

	public void Add(string WhatToSay)
	{
		if (WhatToSay==null)
		{
			WhatToSay="";
		}
		string[] Paragraphs = WhatToSay.Split(new string [] {"/m"}, System.StringSplitOptions.None);
		
		for (int i = 0; i<= Paragraphs.GetUpperBound(0);i++)
		{
			string[] StrWords = Paragraphs[i].Split(new char [] {' '});
			int colCounter=0;
			string Output="";
			for (int j =0; j<=StrWords.GetUpperBound(0);j++)
			{
				if (StrWords[j].Length+colCounter+1>LineWidth)
				{
					colCounter=0; 
					ListAdd(Output);
					Output=StrWords[j] + " ";
					colCounter= StrWords[j].Length+1;
				}	
				else
				{
					Output = Output + StrWords[j] + " ";
					colCounter= colCounter+StrWords[j].Length + 1;
				}
			}
			
			ListAdd(Output );
			if (i < Paragraphs.GetUpperBound(0))
			{//TODO:Pause for more when not the last paragraph. 
				ListAdd("[MORE]");
				//yield return StartCoroutine(WaitForMore());
			}
		}
	//NewUIOUt.text=uiIn.textLabel.text;
				PrintList();
	}

	public void Set(string text)
	{//Clears all text and sets the only text on the control
		Clear();
		Add(text);
		PrintList();
	}

	public void Clear()
	{
		//uiIn.Clear();//Clear the input list control
		//uiIn.textLabel.text="";
		for (int i=0;i<=txtToDisplay.GetUpperBound(0);i++)
		{
			txtToDisplay[i] ="";
		}
		ptr=0;
		PrintList();
			
	}




	public void ListAdd(string text)
	{
		if (ptr==MaxEntries)
		{			
			for (int i=0;i<txtToDisplay.GetUpperBound(0);i++)
			{//push the items up the list.
					txtToDisplay[i] = txtToDisplay[i+1];
			}	
			txtToDisplay[ptr-1] = text;
		}
		else
		{
			txtToDisplay[ptr++] = text;		
		}
		
	}

	public void PrintList()
	{
		string result="";
		for (int i=0;i<ptr;i++)
		{
			result = result+ txtToDisplay[i] + "\n";
		}
		NewUIOUt.text=result;
	}
}
