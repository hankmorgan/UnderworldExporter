using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuHud : MonoBehaviour {
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
		public Text CharGenQuestion;
		public RawImage CharGenBody;



		protected  int cursorSizeX =64;
		protected  int cursorSizeY =64;

		void Start()
		{
				CursorPosition = new Rect(
						0.0f,
						0.0f,
						cursorSizeX,
						cursorSizeY);
		}

		void OnGUI()
		{
				CursorPosition.center = Event.current.mousePosition;
				GUI.DrawTexture (CursorPosition,CursorIcon);
		}


		public void ButtonClickMainMenu(int option)
		{//Button clicks on front menu.
				switch (option)	
				{
				case 0: //PLay introduction
						//GameWorldController.instance.playerUW.playerHud.CutScenesFull.SetAnimation="cs013_n01";
						Cutscene_Intro ci = GameWorldController.instance.playerUW.playerHud.gameObject.AddComponent<Cutscene_Intro>();
						GameWorldController.instance.playerUW.playerHud.CutScenesFull.cs=ci;
						GameWorldController.instance.playerUW.playerHud.CutScenesFull.Begin();
						break;

				case 1: // Create Character
						CharGen.SetActive(true);
						break;
				case 2:// Acknowledgements

						break;
				case 3:// Journey onwards. In the future will be a link to load menu
						GameWorldController.instance.SwitchLevel(0);
						GameWorldController.instance.playerUW.transform.position= new Vector3(38f, 4f, 2.7f);
						GameWorldController.instance.playerUW.playerHud.gameObject.SetActive(true);
						GameWorldController.instance.playerUW.playerController.enabled=true;
						GameWorldController.instance.AtMainMenu=false;
						GameWorldController.instance.playerUW.playerInventory.Refresh();
						Destroy (this.gameObject);
						break;
				}
		}

}
