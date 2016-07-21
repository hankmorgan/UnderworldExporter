using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuHud : GuiBase {
		public Texture2D CursorIcon;
		public Rect CursorPosition;


		//References to hud elements
		public GameObject CharGen;//panel
		public Text CharName;
		public Text CharGender;
		public Text CharClass;
		public Text CharStr;
		public Text CharDex;
		public Text CharInt;
		public Text CharVit;
		public Text[] CharSkillName;
		public Text[] CharSkillVal;
		public int MenuMode =0; //0=main, 1 = chargen
		public int chargenStage=0; 
		//0 = Gender
		//1 = Handeness
		//2 = Class
		//3,4,5,6,7 = Skills. Some are skipped over.
		//8 is portrait/race
		//9 is difficulty.
		//10 is name
		//11 is confirm.

		public Text CharGenQuestion;
		public RawImage CharGenBody;



		protected  int cursorSizeX =64;
		protected  int cursorSizeY =64;

		void Start()
		{
			if (GameWorldController.instance.AtMainMenu)
			{
					CursorPosition = new Rect(
							0.0f,
							0.0f,
							cursorSizeX,
							cursorSizeY);
					//Play the splash screens.
					GameWorldController.instance.playerUW.playerHud.CutScenesFull.SetAnimation="FadeToBlackSleep";
					Cutscene_Splash ci = GameWorldController.instance.playerUW.playerHud.gameObject.AddComponent<Cutscene_Splash>();
					GameWorldController.instance.playerUW.playerHud.CutScenesFull.cs=ci;
					GameWorldController.instance.playerUW.playerHud.CutScenesFull.Begin();
			}
		}

		void OnGUI()
		{
				CursorPosition.center = Event.current.mousePosition;
				GUI.DrawTexture (CursorPosition,CursorIcon);
		}


		public void ButtonClickMainMenu(int option)
		{//Button clicks on front menu.

				if (MenuMode==0)
				{
					switch (option)	
					{
					case 0: //PLay introduction
							//GameWorldController.instance.playerUW.playerHud.CutScenesFull.SetAnimation="cs013_n01";
							Cutscene_Intro ci = GameWorldController.instance.playerUW.playerHud.gameObject.AddComponent<Cutscene_Intro>();
							GameWorldController.instance.playerUW.playerHud.CutScenesFull.cs=ci;
							GameWorldController.instance.playerUW.playerHud.CutScenesFull.Begin();
							break;

					case 1: // Create Character
							MenuMode=1;
							CharGen.SetActive(true);
							CharGenQuestion.text=getQuestion(0);
							PlaceButtons(8,false);
							break;

					case 2:// Acknowledgements
							Cutscene_Credits cc = GameWorldController.instance.playerUW.playerHud.gameObject.AddComponent<Cutscene_Credits>();
							GameWorldController.instance.playerUW.playerHud.CutScenesFull.cs=cc;
							GameWorldController.instance.playerUW.playerHud.CutScenesFull.Begin();
							break;
					case 3:// Journey onwards. In the future will be a link to load menu
							GameWorldController.instance.SwitchLevel(0);
							GameWorldController.instance.playerUW.transform.position= new Vector3(38f, 4f, 2.7f);
							GameWorldController.instance.playerUW.playerHud.gameObject.SetActive(true);
							GameWorldController.instance.playerUW.playerController.enabled=true;
							GameWorldController.instance.playerUW.playerMotor.enabled=false;
							GameWorldController.instance.AtMainMenu=false;
							GameWorldController.instance.playerUW.playerInventory.Refresh();
							Destroy (this.gameObject);
							break;
					}		
				}
				else
				{//Chargen
						ChargenClick(option);	
				}

		}


		public void ChargenClick(int option)
		{

				//0 = Gender
				//1 = Handeness
				//2 = Class
				//3,4,5,6,7 = Skills. Some are skipped over.
				//8 is portrait/race
				//9 is difficulty.
				//10 is name
				//11 is confirm.


				switch (chargenStage)
				{
				case 0:
					//Gender
						if (option == 0)
						{
							GameWorldController.instance.playerUW.isFemale=false;
						}
						else
						{
							GameWorldController.instance.playerUW.isFemale=true;
						}
						chargenStage++;
					break;
				case 1:
					//Handedness
						if (option == 0)
						{
								GameWorldController.instance.playerUW.isLefty=false;
						}
						else
						{
								GameWorldController.instance.playerUW.isLefty=true;
						}
						chargenStage++;
					break;
				case 2:
						GameWorldController.instance.playerUW.CharClass=getClass(option);
						break;

				}

				//Set next question.
				CharGenQuestion.text=getQuestion(chargenStage);

		}


		public string getClass(int option)
		{
				return GameWorldController.instance.playerUW.StringControl.GetString(2,23+option);
		}

		public string getQuestion(int option)
		{
				//0 = Gender
				//1 = Handeness
				//2 = Class
				//3,4,5,6,7 = Skills. Some are skipped over.
				//8 is portrait/race
				//9 is difficulty.
				//10 is name
				//11 is confirm.

				switch (option)
				{
				case 0:
				case 1:
				case 2:
						return GameWorldController.instance.playerUW.StringControl.GetString(2,1+option);
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
						return GameWorldController.instance.playerUW.StringControl.GetString(2,4);
				case 8:
						return "";//no question about portait.
				case 9:
				case 10:
				case 11:
						return GameWorldController.instance.playerUW.StringControl.GetString(2,option-3);
				default:
						return "UNKNOWN Option!";
				}
		}


		public string GetOptionText(int Option)
		{
				//Eventually depending on the stage and available options this will return what choice values is available to select 
				return Option.ToString();
		}


		public void PlaceButtons(int NoOfButtons, bool isImageButton)
		{
			//Destroy existing buttons.
			foreach(Transform child in CharGen.transform)
			{
					//Debug.Log(child.name.Substring(0,4) );
					if (child.name.Substring(0,5) == "_Char")
					{
							Destroy(child.transform.gameObject);
					}
			}		
	

			if (isImageButton)
			{//JUST A VERTICAL LIST OF PORTRAITS
				int GenderPortraitIndex=7;
				if (GameWorldController.instance.playerUW.isFemale)
				{
					GenderPortraitIndex=12;
				}
				for (int i=0; i<NoOfButtons;i++)	
				{
					GameObject myObj = (GameObject)Instantiate(Resources.Load("Prefabs/_CharGenImageButton"));
					myObj.transform.SetParent(CharGen.transform);
					myObj.GetComponent<ChargenButton>().SubmitTarget=this;
					myObj.GetComponent<ChargenButton>().Value=i;
					myObj.GetComponent<RectTransform>().anchoredPosition=new Vector3(200f, 230 - i *110f);
					//Load the protraits					
					myObj.GetComponent<ChargenButton>().ButtonImage.texture = (Texture2D)Resources.Load(_RES +"/Hud/Chargen/chrbtns_" + (GenderPortraitIndex+i).ToString("0000"));
				}
			}	
			else
				{
				//Pick a configuration to use.
						if (NoOfButtons<=5)
						{//One Column
							for (int i=0; i<NoOfButtons;i++)
							{
								GameObject myObj = (GameObject)Instantiate(Resources.Load("Prefabs/_CharGenTextButton"));
								myObj.transform.SetParent(CharGen.transform);
								myObj.GetComponent<ChargenButton>().SubmitTarget=this;
								myObj.GetComponent<ChargenButton>().Value=i;
								myObj.GetComponent<RectTransform>().anchoredPosition=new Vector3(200f, 90 - i *45f);
								myObj.GetComponent<ChargenButton>().ButtonText.text=GetOptionText(i);
							}

						}
						else
						{
						//Two Columns
								for (int i=0; i<NoOfButtons;i++)
								{//First 5 buttons
									GameObject myObj = (GameObject)Instantiate(Resources.Load("Prefabs/_CharGenTextButton"));
									myObj.transform.SetParent(CharGen.transform);
									myObj.GetComponent<ChargenButton>().SubmitTarget=this;
									myObj.GetComponent<ChargenButton>().Value=i;
									if (i<5)
									{//First 5 buttons
										myObj.GetComponent<RectTransform>().anchoredPosition=new Vector3(90f, 90- i *45f);			
									}
									else
									{
										myObj.GetComponent<RectTransform>().anchoredPosition=new Vector3(300f, 90- (i-5) *45f);			
									}	
									myObj.GetComponent<ChargenButton>().ButtonText.text=GetOptionText(i);
								}
						}
				}		
		}
}
