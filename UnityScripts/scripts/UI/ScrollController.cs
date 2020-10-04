using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class ScrollController : GuiBase {
/*
 * API for controlling how text is displayed on the ui scroll
 * Controls splitting of strings, new lines, [more] 
 */

	public int LineWidth = 65;//No of characters in a line

	public string[]txtToDisplay = new string[5];

	//public UITextList uiIn;
	public Text NewUIOUt;
    public TextMeshProUGUI TextOutput;
	public int ptr;
	public int MaxEntries;
    
    /// <summary>
    /// The input ctrl to include with this text box
    /// </summary>
    public InputField InputCtrl;

	public bool useDragon;

    /// <summary>
    /// Add a string to the list in a specified colour.
    /// </summary>
    /// <param name="WhatToSay"></param>
    /// <param name="ColourToUse"></param>
    public void Add(string WhatToSay, string ColourToUse)
    {
        string[] Paragraphs = ParseParagraphs(ref WhatToSay);

        for (int i = 0; i <= Paragraphs.GetUpperBound(0); i++)
        {
            ListAdd(ColourToUse+ Paragraphs[i] + "</color>");
        }
        PrintList();
    }

    /// <summary>
    /// Add a string to the output.
    /// </summary>
    /// <param name="WhatToSay"></param>
    public void Add(string WhatToSay)
    {
        string[] Paragraphs = ParseParagraphs(ref WhatToSay);

        for (int i = 0; i <= Paragraphs.GetUpperBound(0); i++)
        {
            ListAdd(Paragraphs[i]);
        }
        PrintList();
    }

    private string[] ParseParagraphs(ref string WhatToSay)
    {
        if (WhatToSay == null)
        {
            WhatToSay = "";
        }
        WhatToSay = SplitText(WhatToSay);
        WhatToSay = WhatToSay.Replace("\\n", "\n");
        WhatToSay = WhatToSay.TrimEnd();
        string[] Paragraphs = WhatToSay.Split(new string[] { "\n" }, System.StringSplitOptions.None);
        return Paragraphs;
    }

    public void Set(string text)
	{//Clears all text and sets the only text on the control
		Clear();
		Add(text);
		PrintList();
	}

	public void DirectSet(string text)
	{
        if (NewUIOUt !=null)
        {
            NewUIOUt.text = text;
        }
		if (TextOutput!=null)
        {
            TextOutput.text = text;
        }
	}

	public void Clear()
	{
		for (int i=0;i<=txtToDisplay.GetUpperBound(0);i++)
		{
			txtToDisplay[i] ="";
		}
		ptr=0;
        DirectSet("");			
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
        string input = "";
        if ((InputCtrl !=null))
        {
            input = InputCtrl.text;
            if (InputCtrl.gameObject.GetComponent<InputHandler>() != null)
            {
                if (InputCtrl.gameObject.GetComponent<InputHandler>().currentInputMode == InputHandler.InputAnvil)//limit value to Y/N
                {
                    if (input.Length>=1)
                    {
                        string lastChar = input.Substring(input.Length - 1);
                        if (lastChar.ToUpper() == "Y")
                        {
                            input = "Yes";
                            InputCtrl.text = "Y";
                        }
                        else
                        {
                            input = "No";
                            InputCtrl.text = "N";
                        }
                    }
                    else
                    {
                        input = "No";
                        InputCtrl.text = "N";
                    }
                }                  
            }
        }

        for (int i=0;i<ptr;i++)
		{
            if (i==ptr-1)
            {
                result = result + txtToDisplay[i] + " " + input + "\n";
            }
            else
            {
                result = result + txtToDisplay[i] + "\n";
            }
			
		}
        DirectSet(result);
		if (useDragon)
		{
			Dragons.MoveScroll();
		}
	}

    /// <summary>
    /// Split text up into additional lines if they go over the line width of the controller
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    string SplitText(string text)
    {
        if (text.Length<=LineWidth)
        {
            return text;
        }
        else
        {
            //Find the last whitespace in the string before linewidth
            int index = text.Substring(0, LineWidth).LastIndexOf(" ");
            char[] chars = text.ToCharArray();
            chars[index] =  '\n';
            text = new string(chars);
            if (text.Length - LineWidth > LineWidth)
            {
                //there is still more characters. Split them up and append to end of current line
                return text.Substring(0, LineWidth) + SplitText(text.Substring(LineWidth));
            }
            else
            {
                return text;
            }
        }
    }

    /// <summary>
    /// Refreshes the text displayed when the input control value changes
    /// </summary>
    public void InputCtrlChange()
    {
        //if(InputCtrl!=null)
        //{
        //    if (InputCtrl.gameObject.GetComponent<InputHandler>()!=null)
        //    {
        //        if (InputCtrl.gameObject.GetComponent<InputHandler>().currentInputMode == InputHandler.InputAnvil)//limit value to Y/N
        //        {
        //            string LastChar = InputCtrl.text.Substring()
        //        }
        //    }
        //}
        PrintList();
    }

}
