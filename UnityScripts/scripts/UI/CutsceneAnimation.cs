using UnityEngine;
using System.Collections;

public class CutsceneAnimation : HudAnimation {
		public string CurrentSpriteName;
		Sprite CurrentSpriteLoaded;
		public string currentCutsFile;
		public string previousCutsFile;
		//public Sprite filler;

	/*Gui element for the small window animations*/

	/*Is also responsible for calling the resurrection sequence in UW1*/

//	public Camera maincam;

	public void PreAnimPlay()
	{//Called by events in certain animations when starting playing
		GameWorldController.instance.playerUW.playerCam.cullingMask=0;//Stops the camera from rendering.
		return;
	} 
	
	public void PostAnimPlay()
	{//Called by events in certain animations when finished playing

		switch (SetAnimation)
		{
		case "FadeToBlackSleep":
			GameWorldController.instance.playerUW.playerCam.cullingMask=HudAnimation.NormalCullingMask;
			SetAnimation= "Anim_Base";//Clears out the animation.
			Bedroll.WakeUp (GameWorldController.instance.playerUW);
			break;
		case "ChasmMap":
			//maincam.enabled=true;
			GameWorldController.instance.playerUW.playerCam.cullingMask=HudAnimation.NormalCullingMask;
			SetAnimation= "Anim_Base";//Clears out the animation.
			break;
		case "Death_With_Sapling"://Resurrection
		//	MusicController mus = GameObject.Find("MusicController").GetComponent<MusicController>();
			if (GameWorldController.instance.getMus()!=null)
			{
				GameWorldController.instance.playerUW.CurVIT=GameWorldController.instance.playerUW.MaxVIT;
				GameWorldController.instance.getMus().Death=false;
				GameWorldController.instance.getMus().Combat=false;
				GameWorldController.instance.getMus().Fleeing=false;
				MusicController.LastAttackCounter=0.0f;
			}
			//maincam.enabled=true;
			GameWorldController.instance.playerUW.playerCam.cullingMask=HudAnimation.NormalCullingMask;
			SetAnimation= "Anim_Base";//Clears out the animation.
			
			GameWorldController.instance.playerUW.gameObject.transform.position=GameWorldController.instance.playerUW.ResurrectPosition;
			if (GameWorldController.instance.LevelNo!=GameWorldController.instance.playerUW.ResurrectLevel)
			{
				GameWorldController.instance.SwitchLevel(GameWorldController.instance.playerUW.ResurrectLevel);
			}
			
			break;

		case "Death"://Forever
			SetAnimation= "Death_Final";
			break;
		case "Death_Final"://Forever
			break;
		default:
			//maincam.enabled=true;
			GameWorldController.instance.playerUW.playerCam.cullingMask=HudAnimation.NormalCullingMask;
			SetAnimation= "Anim_Base";//Clears out the animation.
			break;
		}
	}




		/// <summary>
		/// Deactivates the fullscreen animation if clicked on during anim_base
		/// </summary>
		public void LateUpdate()
		{
				if (sprt==null)
				{
						sprt=this.GetComponentInChildren<SpriteRenderer>();	
				}

				if(CurrentSpriteName != sprt.sprite.name)
				{
						CurrentSpriteName= sprt.sprite.name;
						switch (sprt.sprite.name)
						{
						case "cuts_blank":
								CurrentSpriteLoaded= Cuts.filler.RequestSprite(0);	
								break;
						case "SplashOrigin":
						case "pres1_0000":
								Texture2D img= GameWorldController.instance.bytloader.LoadImageAt(BytLoader.PRES1_BYT);
								CurrentSpriteLoaded=Sprite.Create(img,new Rect(0,0,img.width,img.height), new Vector2(0.5f, 0.0f));							
								break;
						case "SplashBlueSky":
						case "pres2_0000":
								Texture2D img1= GameWorldController.instance.bytloader.LoadImageAt(BytLoader.PRES2_BYT);
								CurrentSpriteLoaded=Sprite.Create(img1,new Rect(0,0,img1.width,img1.height), new Vector2(0.5f, 0.0f));
								break;

						default:
								currentCutsFile = CurrentSpriteName.Substring(0,9);
								if (currentCutsFile!=previousCutsFile)
								{
										GameWorldController.instance.cutsLoader= new CutsLoader(currentCutsFile.Replace("_","."));
								}
								previousCutsFile=currentCutsFile;
								int SpriteNo;
								if (int.TryParse(CurrentSpriteName.Substring(CurrentSpriteName.Length-4,4),out SpriteNo))
								{
										CurrentSpriteLoaded= GameWorldController.instance.cutsLoader.RequestSprite(SpriteNo);	
								}
								else
								{
										Debug.Log("Unable to find sprite index for " + CurrentSpriteName + " in animation " + SetAnimation);
								}	
								break;
						}
				}
				if (sprt!=null)
				{
						sprt.sprite=CurrentSpriteLoaded;
						if (sprt.sprite!=null)
						{
								TargetControl.texture =sprt.sprite.texture;		
						}	
				}

		}


}
