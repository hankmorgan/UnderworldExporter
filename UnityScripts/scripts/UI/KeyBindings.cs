using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class KeyBindings : GuiBase {
		

		//Dictionary Sourced from https://gist.github.com/b-cancel/c516990b8b304d47188a7fa8be9a1ad9
		//Change to use strings and added function keys.

		//NOTE: This is only a dictionary with MOST characters to keycode bindings (NOT A WORKING CS FILE)
		//ITS USEFUL: when you are reading in your control scheme from a file

		//NOTE: some keys create the same characters
		//since this is a dictionary, only 1 character is bound to 1 keycode
		//EX: * from the keyboard will be read the same as * from the keypad 
		//Because they produce the same character in a text file

		//NOTE: not ALL characters are bound to a keycode due to Unity"s Limitations


		public Dictionary<string, KeyCode> chartoKeycode = new Dictionary<string, KeyCode>()
		{	
				
				  {".", KeyCode.KeypadPeriod},
					  {"/", KeyCode.KeypadDivide},
				{"*", KeyCode.KeypadMultiply},
				 // {"-", KeyCode.KeypadMinus},
				    {"+", KeyCode.KeypadPlus},
				 // {"=", KeyCode.KeypadEquals},


				//other REGULAR
				{"`", KeyCode.BackQuote},
				{"-", KeyCode.Minus},
				{"=", KeyCode.Equals},
				{"[", KeyCode.LeftBracket},
				{"]", KeyCode.RightBracket},
				{"\\'", KeyCode.Backslash}, //remember the special forward slash rule... this isnt wrong
				{";", KeyCode.Semicolon},
				{"\'", KeyCode.Quote}, //neither is this
				{",", KeyCode.Comma},
				//{".", KeyCode.Period},
				//{"/", KeyCode.Slash},




				/*
				//other with SHIFT
				//{"~", KeyCode.tilde}, //inaccesible for some reason...
				{"_", KeyCode.Underscore},
				{"+", KeyCode.Plus},
				//{"{", KeyCode.LeftCurlyBrace}, //inaccesible for some reason...
				//{"}", KeyCode.RightCurlyBrace}, //inaccesible for some reason...
				//{"|", KeyCode.Line}, //inaccesible for some reason...
				{":", KeyCode.Colon},
				{"\"", KeyCode.DoubleQuote},
				{"<", KeyCode.Less},
				{">", KeyCode.Greater},
				{"?", KeyCode.Question},

				//KeyBoard Top Numbers - will not register as numbers but rather as (shift + number) = symbol
				{"!", KeyCode.Exclaim}, //1
				{"@", KeyCode.At},
				{"#", KeyCode.Hash},
				{"$", KeyCode.Dollar},
				//{"%", KeyCode.percent}, //inaccesible for some reason...
				{"^", KeyCode.Caret},
				{"&", KeyCode.Ampersand},
				{"*", KeyCode.Asterisk},
				{"(", KeyCode.LeftParen}, //9
				{")", KeyCode.RightParen}, //0
				*/


				//KeyPad Numbers
				{"1", KeyCode.Keypad1},
				{"2", KeyCode.Keypad2},
				{"3", KeyCode.Keypad3},
				{"4", KeyCode.Keypad4},
				{"5", KeyCode.Keypad5},
				{"6", KeyCode.Keypad6},
				{"7", KeyCode.Keypad7},
				{"8", KeyCode.Keypad8},
				{"9", KeyCode.Keypad9},
				{"0", KeyCode.Keypad0},

				//regular letters
				{"a", KeyCode.A},
				{"b", KeyCode.B},
				{"c", KeyCode.C},
				{"d", KeyCode.D},
				{"e", KeyCode.E},
				{"f", KeyCode.F},
				{"g", KeyCode.G},
				{"h", KeyCode.H},
				{"i", KeyCode.I},
				{"j", KeyCode.J},
				{"k", KeyCode.K},
				{"l", KeyCode.L},
				{"m", KeyCode.M},
				{"n", KeyCode.N},
				{"o", KeyCode.O},
				{"p", KeyCode.P},
				{"q", KeyCode.Q},
				{"r", KeyCode.R},
				{"s", KeyCode.S},
				{"t", KeyCode.T},
				{"u", KeyCode.U},
				{"v", KeyCode.V},
				{"w", KeyCode.W},
				{"x", KeyCode.X},
				{"y", KeyCode.Y},
				{"z", KeyCode.Z},

				//Added function keys
				{"f1", KeyCode.F1},
				{"f2", KeyCode.F2},
				{"f3", KeyCode.F3},
				{"f4", KeyCode.F4},
				{"f5", KeyCode.F5},
				{"f6", KeyCode.F6},
				{"f7", KeyCode.F7},
				{"f8", KeyCode.F8},
				{"f9", KeyCode.F9},
				{"f10", KeyCode.F10},
				{"f11", KeyCode.F11},
				{"f12", KeyCode.F12}
		};









	public static KeyBindings instance;

		//Keycodes and their defaults
	public KeyCode FlyUp = KeyCode.R;
	public KeyCode FlyDown = KeyCode.V;
	public KeyCode ToggleMouseLook = KeyCode.E;
	public KeyCode ToggleFullScreen = KeyCode.F;
	public KeyCode InteractionOptions = KeyCode.F1;
	public KeyCode InteractionTalk = KeyCode.F2;
	public KeyCode InteractionPickup = KeyCode.F3;
	public KeyCode InteractionLook = KeyCode.F4;
	public KeyCode InteractionAttack = KeyCode.F5;
	public KeyCode InteractionUse = KeyCode.F6;
	public KeyCode CastSpell = KeyCode.Q;
	public KeyCode TrackSkill = KeyCode.T;

	/*public override void Start ()
	{
		base.Start ();
		
	}*/

	void Awake()
	{//Should execute before game world controller
		instance=this;
	}


	public void ApplyBindings()
	{
		string fileName = Application.dataPath + "//..//bindings.txt";
		if (File.Exists(fileName))
		{
			string line;
			StreamReader fileReader = new StreamReader(fileName, Encoding.Default);
			do
			{
					line = fileReader.ReadLine();
					if (line != null)
					{
						string[] entries = line.Split('=');
						if(entries.GetUpperBound(0)==1)
						{
								KeyCode keyCodeToUse;
								if (chartoKeycode.TryGetValue(entries[1].ToLower(), out keyCodeToUse))
								{
										switch(entries[0].ToLower())
										{
										case "flyup": FlyUp=keyCodeToUse;break;
										case "flydown": FlyDown=keyCodeToUse;break;
										case "togglemouselook": ToggleMouseLook=keyCodeToUse;break;
										case "togglefullscreen": ToggleFullScreen=keyCodeToUse;break;
										case "interactionoptions": InteractionOptions=keyCodeToUse;break;
										case "interactiontalk": InteractionTalk=keyCodeToUse;break;
										case "interactionpickup": InteractionPickup=keyCodeToUse;break;
										case "interactionlook": InteractionLook=keyCodeToUse;break;
										case "interactionattack": InteractionAttack=keyCodeToUse;break;
										case "interactionuse": InteractionUse=keyCodeToUse;break;
										case "castspell": CastSpell=keyCodeToUse;break;
										case "trackskill": TrackSkill=keyCodeToUse;break;
										}	
								}	
						}

					}
			}while (line != null);
			fileReader.Close();		
		}




		UWHUD.instance.InteractionControlUW1.ControlItems[0].ShortCutKey=InteractionOptions;
		UWHUD.instance.InteractionControlUW1.ControlItems[1].ShortCutKey=InteractionTalk;
		UWHUD.instance.InteractionControlUW1.ControlItems[2].ShortCutKey=InteractionPickup;
		UWHUD.instance.InteractionControlUW1.ControlItems[3].ShortCutKey=InteractionLook;
		UWHUD.instance.InteractionControlUW1.ControlItems[4].ShortCutKey=InteractionAttack;
		UWHUD.instance.InteractionControlUW1.ControlItems[5].ShortCutKey=InteractionUse;

		UWHUD.instance.InteractionControlUW2.ControlItems[0].ShortCutKey=InteractionOptions;
		UWHUD.instance.InteractionControlUW2.ControlItems[1].ShortCutKey=InteractionTalk;
		UWHUD.instance.InteractionControlUW2.ControlItems[2].ShortCutKey=InteractionPickup;
		UWHUD.instance.InteractionControlUW2.ControlItems[3].ShortCutKey=InteractionLook;
		UWHUD.instance.InteractionControlUW2.ControlItems[4].ShortCutKey=InteractionAttack;
		UWHUD.instance.InteractionControlUW2.ControlItems[5].ShortCutKey=InteractionUse;
	}
}
