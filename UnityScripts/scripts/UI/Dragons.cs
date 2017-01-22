using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Dragons : GuiBase {

	public static Dragons Instance;
	public Animator animTailLeft;
	public Animator animTailRight;

	public Animator animMainLeft;
	public Animator animMainRight;

	public int AnimationCount;//How many actions has the dragon carried out.
	private int ChangeAfter=5;//Change dragons after this many actions.
	public bool CurrentSide=false;//False for left. True for Right.
	
	//public string CurrentAnimation;

	public override void Start ()
	{
		base.Start ();
		Instance=this;
	
		animTailLeft.Play("DragonLeftTailShake");
		animTailRight.Play("DragonRightTailShake");
		animMainLeft.Play("DragonLeftIdle");
		animMainRight.Play("DragonRightIdle");
	}


		public void IncrementAnimation()
		{
				AnimationCount++;
				if (AnimationCount>ChangeAfter)
				{
						AnimationCount=0;
						//CurrentSide=!CurrentSide;
						if (CurrentSide==true)
						{
								animTailRight.Play(GetAnimationName("SHAKE"));
								CurrentSide=false;
						}
						else
						{
								animTailLeft.Play(GetAnimationName("SHAKE"));
								CurrentSide=true;								
						}
				}
		}

		public static void MoveScroll()
		{
				//	Instance.PlayAnimation();
					if (Instance.CurrentSide)
					{
						Instance.animMainRight.Play(Instance.GetAnimationName("HANDS"));
					}
					else
					{
						Instance.animMainLeft.Play(Instance.GetAnimationName("HANDS"));
					}
				Instance.IncrementAnimation();
		}



		public string GetAnimationName(string animName)
		{
			switch (animName)
			{
				case "IDLE":
						if(CurrentSide)
						{
								return "DragonRightIdle";
						}
						else
						{
								return "DragonLeftIdle";
						}

			case "HANDS":
						if(CurrentSide)
						{
								return "DragonRightHands";
						}
						else
						{
								return "DragonLeftHands";
						}
	
			case "SHAKE":
						if(CurrentSide)
						{
								return "DragonRightTailShake";
						}
						else
						{
								return "DragonLeftTailShake";
						}

			case "DUCK":
						if(CurrentSide)
						{
								return "DragonRightDuck";
						}
						else
						{
								return "DragonLeftDuck";
						}
				default:
						if(CurrentSide)
						{
								return "DragonRightIdle";
						}
						else
						{
								return "DragonLeftIdle";
						}
			}
		}






}
