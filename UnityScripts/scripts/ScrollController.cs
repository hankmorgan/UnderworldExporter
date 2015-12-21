using UnityEngine;
using System.Collections;

public class ScrollController : GuiBase {
/*
 * API for controlling how text is displayed on the ui scroll
 * Controls splitting of strings, new lines, [more] 
 */

	public int LineWidth = 65;//No of characters in a line

	public UITextList uiIn;
	
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
					uiIn.Add (Output);
					Output=StrWords[j] + " ";
					colCounter= StrWords[j].Length+1;
				}	
				else
				{
					Output = Output + StrWords[j] + " ";
					colCounter= colCounter+StrWords[j].Length + 1;
				}
			}
			
			uiIn.Add(Output );
			if (i < Paragraphs.GetUpperBound(0))
			{//TODO:Pause for more when not the last paragraph. 
				uiIn.Add("[MORE]");
				//yield return StartCoroutine(WaitForMore());
			}
		}
	}

	public void Set(string text)
	{//Clears all text and sets the only text on the control
		Clear();
		Add(text);
	}

	public void Clear()
	{
		uiIn.Clear();//Clear the input list control
		uiIn.textLabel.text="";
	}
}
