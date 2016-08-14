using UnityEngine;
using System.Collections;

public class Chargen : Props {
		//0 = Gender
		//1 = Handeness
		//2 = Class
		//3,4,5,6,7 = Skills. Some are skipped over.
		//8 is portrait/race
		//9 is difficulty.
		//10 is name
		//11 is confirm.

		public const int STAGE_GENDER=0;
		public const int STAGE_HANDENESS=1;
		public const int STAGE_CLASS =2;
		public const int STAGE_SKILLS_1 = 3;
		public const int STAGE_SKILLS_2 = 4;
		public const int STAGE_SKILLS_3 = 5;
		public const int STAGE_SKILLS_4 = 6;
		public const int STAGE_SKILLS_5 = 7;
		public const int STAGE_PORTRAIT = 8;
		public const int STAGE_DIFFICULTY=9;
		public const int STAGE_NAME=10;
		public const int STAGE_CONFIRM=11;


	//String nos of gender choice
		private static  int[] GenderChoice={9,10};

		private static  int[] PortraitsChoice={0,1,2,3,4};

	//String nos of handedness choice
		private static  int[] HandednessChoice={11,12};

	//String nos of char classes choice
		private static  int[] ClassesChoice={23,24,25,26,27,28,29,30};

	//Class specific base attributes numbers
		private static  int[] BaseStr={20,12,14,18,18,12,16,12};
		private static  int[] BaseDex={16,16,20,18,12,18,16,12};
		private static  int[] BaseInt={12,20,14,12,18,18,16,12};

	//Skill points random range
		private static  int[] SkillSeed={12,12,12,12,12,12,12,20};

	//Skills specific skill choices. points to the string no.
		private static  int[][] FighterSkills={  
				new int[]{31} , 
				new int[]{32} , 
				new int[]{31,32}, 
				new int[]{33,34,35,36,37} ,
				new int[]{50,41,42,46,48,49}
	};

		private static  int[][] MageSkills={
				new int[]{31},
				new int[]{32},
				new int[]{38},
				new int[]{40},
				new int[]{38,40}
	};

		private static  int [][] BardSkills={
				new int[]{31},
				new int[]{32},
				new int[]{39,46},
				new int[]{49,48,44,47,42,50},
				new int[]{38,40,34,35,36,33,37}
	};

		private static  int[][] TinkerSkills = {
				new int[]{31},
				new int[]{32},
				new int[]{45},
				new int[]{33,34,35,36,37},
				new int[]{47,41,42,49,45}
	};

		private static  int[][] DruidSkills = {
				new int[]{31},
				new int[]{32},
				new int[]{40},
				new int[]{38},
				new int[]{43,39,42}
	};

		private static  int[][]  PaladinSkills = {
				new int[]{31},
				new int[]{32},
				new int[]{46},
				new int[]{49,46,48,45},
				new int[]{33,34,35,36,37}
	};

		private static  int[][] RangerSkills = {
				new int[]{31},
				new int[]{32},
				new int[]{43},
				new int[]{41,48,44,42,50,45},
				new int[]{33,34,35,36,37,31,32,43}
	};

		private static  int[][] ShepherdSkills={
				new int[]{31},
				new int[]{32},
				new int[]{33,34,35,36,37,32},
				new int[]{41,42,44,48,49,50,43,40,39,38},
				new int[]{41,42,44,48,49,50,43,40,39,38}
	};

		private static  int[] YesNoChoice = {15,16};

		private static int[] DifficultyChoice = {14,13};




		public static int[] GetChoices (int stage, int charclass)
		{
				switch(stage)
				{
				case STAGE_GENDER:
						return GenderChoice;
				case STAGE_HANDENESS:
						return HandednessChoice;
				case STAGE_CLASS:
						return ClassesChoice;
				case STAGE_SKILLS_1:
				case STAGE_SKILLS_2:
				case STAGE_SKILLS_3:
				case STAGE_SKILLS_4:
				case STAGE_SKILLS_5:
						return GetClassChoices(stage,charclass);
				case STAGE_PORTRAIT:
						return PortraitsChoice;
				case STAGE_DIFFICULTY:
						return DifficultyChoice;
				case Chargen.STAGE_NAME:
						return YesNoChoice;
				case STAGE_CONFIRM:
						return YesNoChoice;
				default:
					int[] ans ={1};
					return ans;
				}
		}

		private static int[] GetClassChoices(int stage, int charclass)
		{
				switch (charclass)
				{
				case 0://fighter
						return FighterSkills[stage-3];
						//return getArrayDimension(FighterSkills, stage-3);
				case 1://mage
						return MageSkills[stage-3];
				case 2://bard
						return BardSkills[stage-3];
				case 3://tinker
						return TinkerSkills[stage-3];
				case 4://Druid
						return DruidSkills[stage-3];
				case 5://paladin
						return PaladinSkills[stage-3];
				case 6://ranger
						return RangerSkills[stage-3];
				case 7://shepherd
						return ShepherdSkills[stage-3];
				default:
						int[] ans ={1};
						return ans;	
				}
		}

		public static int getSeed(int charClass)
		{
				return SkillSeed[charClass];
		}

		public static int getBaseSTR(int charClass)
		{
				return BaseStr[charClass];
		}

		public static int getBaseINT(int charClass)
		{
				return BaseInt[charClass];
		}

		public static int getBaseDEX(int charClass)
		{
				return BaseDex[charClass];
		}

		//static int [] getArrayDimension(int[,] array, int dimension)
		//{
			//	int[] newArray =  new int[array.GetUpperBound(dimension)];
			//	for (int i=0; i<a;i++)
			//	{
			//			newArray[i] = array[dimension].;	
			//	}
			//	return newArray;	
		//}
}
