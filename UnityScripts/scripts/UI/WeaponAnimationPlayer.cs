using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeaponAnimationPlayer : UWEBase {
		static float frameRate =0.2f;
		//public int AnimationIndex;//Animation to display
		public int AnimationPos;//Position in the animation.
		public float animationCounter;//TIming

		public RawImage TargetControl;
		public int PreviousAnimation;
		//public string SetAnimation;
		public int SetAnimation;
		public Texture2D blank;
		public int RetrievedImage;

		// Update is called once per frame
		void Update () {
			//TargetControl.enabled=(SetAnimation!=-1);
			if(SetAnimation!=PreviousAnimation)
			{
				PreviousAnimation=SetAnimation;
				AnimationPos=0;
				animationCounter=0;
				if (SetAnimation==-1)
				{
					TargetControl.texture=blank;
					return;
				}
			}
			if (GameWorldController.instance.weapongr==null)
			{
				return;
			}
			if (SetAnimation==-1)
			{
				return;
			}
			animationCounter+=Time.deltaTime;
			if ((animationCounter>=frameRate) && (_RES!=GAME_UWDEMO))
			{
				animationCounter=0f;
				if(AnimationPos<=GameWorldController.instance.weaps.frames.GetUpperBound(1))
				{
					if (GameWorldController.instance.weaps.frames[SetAnimation,AnimationPos]!=-1)
					{		
						RetrievedImage=GameWorldController.instance.weaps.frames[SetAnimation,AnimationPos];
						TargetControl.texture= GameWorldController.instance.weapongr.LoadImageAt(GameWorldController.instance.weaps.frames[SetAnimation,AnimationPos]);
					}
					AnimationPos++;	
				}
			}	
		}
}
