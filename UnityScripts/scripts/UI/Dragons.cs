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
				{2, 3, 4, 5, 4, 3 },	//left head scroll	
				{10,11,12,13,12,11},	//left head cower
				{1, 1, 1, 1, 1, 1 },	//left head idle
				{32,33,34,35,34,33},	//right tail shake
				{20,21,22,23,22,21},	//right head scroll
				{28,29,30,31,30,29},	//right head cower
				{19,19,19,19,19,19}		//right head idle
		};

		float frameRate = 0.5f;

		float[] counters = new float[4];
		bool[] loops = new bool[4];
		int[] currentFrames = new int[4];
		int[] targetFrames = new int[4];
		int[] AnimSequencePlaying = new int[4];
		int[] AnimSequenceTransition = new int[4]; //sequence to move to when complete

		public RawImage[] targetControls = new RawImage[6];//First four are controlled by the anim sequence


		/// <summary>
		/// The processed dragon images
		/// </summary>
		public Texture2D[] Output;

		public override void Start ()
		{				
				base.Start ();
				Instance=this;
				PrepareDragonImages ();
				targetControls[0].texture=Output[1];//head
				targetControls[1].texture=Output[14];//tail
				targetControls[2].texture=Output[19];//head
				targetControls[3].texture=Output[32];//tail
				targetControls[4].texture=Output[0];
				targetControls[5].texture=Output[18];
				PlaySequence("LeftTailShake");
				PlaySequence("RightTailShake");
				PlaySequence("LeftHeadIdle");
				PlaySequence("RightHeadIdle");
				InvokeRepeating("IdleTail",10f, 10f);
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
				targetControls[CounterIndex].texture = (Texture)Output[AnimFrames[AnimSequencePlaying[CounterIndex] , currentFrames[CounterIndex] ] ];
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
										targetControls[i].texture = (Texture)Output[AnimFrames[AnimSequencePlaying[i] , currentFrames[i] ] ];		
										currentFrames[i] = targetFrames[i];
								}
						}
				}
		}


		public static void PlaySequence(string SequenceName)
		{
				switch (SequenceName)
				{
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


	void PrepareDragonImages ()
	{
		GRLoader dragonsGr = new GRLoader (GRLoader.DRAGONS_GR);
		Output = new Texture2D[dragonsGr.NoOfFileImages ()];
		for (int i = 0; i <= Output.GetUpperBound (0); i++) {
			switch (i) {
			case 2:
			case 3:
			case 4:
				Output [i] = ArtLoader.InsertImage (dragonsGr.LoadImageAt (i), dragonsGr.LoadImageAt (1), 4, 0);
				break;
			case 5:
				Output [i] = ArtLoader.InsertImage (dragonsGr.LoadImageAt (i), dragonsGr.LoadImageAt (1), 4, -1);
				break;
			case 6:
			case 7:
			case 8:
			case 9:
				Output [i] = ArtLoader.InsertImage (dragonsGr.LoadImageAt (i), dragonsGr.LoadImageAt (1), 12, 10);
				break;
			case 11:
			case 12:
			case 13:
				Output [i] = ArtLoader.InsertImage (dragonsGr.LoadImageAt (i), ArtLoader.CreateBlankImage (37, 23), 0, 5);
				break;
			case 20:
				Output [i] = ArtLoader.InsertImage (dragonsGr.LoadImageAt (i), dragonsGr.LoadImageAt (19), -1, -3);
				break;
			case 21:
			case 22:
				Output [i] = ArtLoader.InsertImage (dragonsGr.LoadImageAt (i), dragonsGr.LoadImageAt (19), 0, 0);
				break;
			case 23:
				Output [i] = ArtLoader.InsertImage (dragonsGr.LoadImageAt (i), dragonsGr.LoadImageAt (19), 0, -1);
				break;
			case 24:
			case 25:
			case 26:
				Output [i] = ArtLoader.InsertImage (dragonsGr.LoadImageAt (i), dragonsGr.LoadImageAt (28), 3, 10);
				break;
			case 27:
				Output [i] = ArtLoader.InsertImage (dragonsGr.LoadImageAt (i), dragonsGr.LoadImageAt (28), 4, 10);
				break;
			case 29:
				Output [i] = ArtLoader.InsertImage (dragonsGr.LoadImageAt (i), ArtLoader.CreateBlankImage (34, 23), -4, 5);
				break;
			case 30:
				Output [i] = ArtLoader.InsertImage (dragonsGr.LoadImageAt (i), ArtLoader.CreateBlankImage (34, 23), -6, 9);
				break;
			case 31:
				Output [i] = ArtLoader.InsertImage (dragonsGr.LoadImageAt (i), ArtLoader.CreateBlankImage (34, 23), -4, 9);
				break;
			default:
				Output [i] = dragonsGr.LoadImageAt (i);
				break;
			}
		}
	}

}
