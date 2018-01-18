using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Dragons : GuiBase {

	public static Dragons Instance;

	const int LeftTailShakeIndex = 0;
	const int LeftHeadScrollIndex = 1;
	const int LeftHeadCowerIndex = 2;
	const int LeftHeadIdleIndex = 3;
	const int RightTailShakeIndex = 4;
	const int RightHeadScrollIndex = 5;
	const int RightHeadCowerIndex = 6;
	const int RightHeadIdleIndex = 7;

	int[,] AnimFrames=
	{
			{14,15,16,17,16,15},	//left tail shake
			{2, 3, 4, 5, 4, 3 },			//left head scroll	
			{10,11,12,13,12,11},	//left head cower
			{1, 2, 1, 2, 1, 2 },					//left head idle
			{32,33,34,35,34,33},	//right tail shake
			{20,21,22,23,22,21},	//right head scroll
			{28,29,30,31,30,29},	//right head cower
			{19,20,19,20,19,20}					//right head idle
	};
				/*
	int[] LeftTailShake = {14,15,16,17,16,15};
	int[] LeftHeadScroll = {2,3,4,5,4,3};
	int[] LeftHeadCower = {10,11,12,13,12,11};
	int[] LeftHeadIdle = {1,2};

	int[] RightTailShake = {32,33,34,35,34,33};
	int[] RightHeadScroll = {20,21,22,23,22,21};
	int[] RightHeadCower = {28,29,30,31,30,29};
	int[] RightHeadIdle = {19,20};
	*/
	float frameRate = 0.5f;

	float[] counters = new float[4];
	bool[] loops = new bool[4];
	int[] currentFrames = new int[4];
	int[] targetFrames = new int[4];
	int[] AnimSequencePlaying = new int[4];
	int[] AnimSequenceTransition = new int[4]; //sequence to move to when complete

	public RawImage[] targetControls = new RawImage[6];//First four are controlled by the anim sequence
	//public string CurrentAnimation;

	int targetAnim=0;
		GRLoader dragonsgr;

	public override void Start ()
	{
		base.Start ();
		Instance=this;
		dragonsgr = new GRLoader(GRLoader.DRAGONS_GR);
		PlaySequence("LeftTailShake");
		PlaySequence("RightTailShake");
		PlaySequence("LeftIdle");
		PlaySequence("RightIdle");
		/*animTailLeft.Play("DragonLeftTailShake");
		animTailRight.Play("DragonRightTailShake");
		animMainLeft.Play("DragonLeftIdle");
		animMainRight.Play("DragonRightIdle");*/
		InvokeRepeating("IdleTail", 10f, 10f);
	}

	void IdleTail()
	{
		PlaySequence("LeftTailShake");
		PlaySequence("RightTailShake");	
	}

	public void PlayAnimSequence(int AnimSequence, int CounterIndex, bool looping)
	{
			AnimSequencePlaying[CounterIndex] = AnimSequence;//Set index to index of animframes array
			loops[CounterIndex] = looping;
			currentFrames[CounterIndex] = 0;
			targetFrames[CounterIndex] = 0;
			targetControls[CounterIndex].texture = (Texture)dragonsgr.LoadImageAt(AnimFrames[AnimSequencePlaying[CounterIndex] , currentFrames[CounterIndex] ]);
			counters[CounterIndex] = 0f;
	}


	void Update()
	{
		for (int i=0; i<=counters.GetUpperBound(0);i++)
		{
			counters[i]+=Time.deltaTime;
			if (counters[i]>=frameRate)
			{
				counters[i]=0f;				
				if (targetFrames[i] <AnimFrames.GetUpperBound(1))
				{
					targetFrames[i]++;	
				}
				else
				{
					if (loops[i])
					{
						targetFrames[i]=0;		
					}
				}
				if (targetFrames[i]!=currentFrames[i])
				{										
					targetControls[i].texture = (Texture)dragonsgr.LoadImageAt(AnimFrames[AnimSequencePlaying[i] , currentFrames[i] ]);		
					currentFrames[i] = targetFrames[i];
				}
			}
		}
	}

		public static void PlaySequence(string SequenceName)
		{

				switch (SequenceName)
				{
				/*
	int[] LeftTailShake = {14,15,16,17,16,15};
	int[] LeftHeadScroll = {2,3,4,5,4,3};
	int[] LeftHeadCower = {10,11,12,13,12,11};
	int[] LeftHeadIdle = {1,2};

	int[] RightTailShake = {32,33,34,35,34,33};
	int[] RightHeadScroll = {20,21,22,23,22,21};
	int[] RightHeadCower = {28,29,30,31,30,29};
	int[] RightHeadIdle = {19,20};
	*/
				//control indices
				//left tail
				//left head
				//right tail
				//right head

				case "LeftTailShake":
						Instance.PlayAnimSequence(LeftTailShakeIndex,0,false);
						break;
				case "LeftHeadScroll":
						Instance.PlayAnimSequence(LeftHeadScrollIndex,1,false);
						break;
				case "LeftHeadCower":
						Instance.PlayAnimSequence(LeftHeadCowerIndex,1,false);
						break;
				case "LeftHeadIdle":
						Instance.PlayAnimSequence(LeftHeadIdleIndex,1,true);
						break;
				case  "RightTailShake" :
						Instance.PlayAnimSequence(RightTailShakeIndex,2,false);
						break;
				case  "RightHeadScroll" :
						Instance.PlayAnimSequence(RightHeadScrollIndex,3,false);
						break;
				case "RightHeadCower" :
						Instance.PlayAnimSequence(RightHeadCowerIndex,3,false);
						break;
				case "RightHeadIdle" :
						Instance.PlayAnimSequence(RightHeadIdleIndex,3,true);
						break;
				}
		}


		public static void MoveScroll()
		{
			switch (Random.Range(1,8))
			{
			case 0:
			case 1:
			case 2://Move the left scroll
					PlaySequence("LeftHeadScroll");
					break;
			case 3:
			case 4:
			case 5://Move the right scroll
					PlaySequence("RightHeadScroll");
					break;	
			}
		}

	/*	public void IncrementAnimation()
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
		}*/






}
