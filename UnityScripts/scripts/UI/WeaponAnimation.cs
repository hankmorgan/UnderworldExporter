using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeaponAnimation : Loader {
		
		public const int Sword_Stab_Right_Charge=0;
		public const int Sword_Stab_Right_Execute=1;
		public const int Sword_Bash_Right_Charge=2;
		public const int Sword_Bash_Right_Execute=3;
		public const int Sword_Slash_Right_Charge=4;
		public const int Sword_Slash_Right_Execute=5;
		public const int Sword_Ready_Right=6;


		public const int Axe_Stab_Right_Charge=7;
		public const int Axe_Stab_Right_Execute=8;
		public const int Axe_Bash_Right_Charge=9;
		public const int Axe_Bash_Right_Execute=10;
		public const int Axe_Slash_Right_Charge=11;
		public const int Axe_Slash_Right_Execute=12;
		public const int Axe_Ready_Right=13;

		public const int Mace_Stab_Right_Charge=14;
		public const int Mace_Stab_Right_Execute=15;
		public const int Mace_Bash_Right_Charge=16;
		public const int Mace_Bash_Right_Execute=17;
		public const int Mace_Slash_Right_Charge=18;
		public const int Mace_Slash_Right_Execute=19;
		public const int Mace_Ready_Right=20;

		public const int Fist_Stab_Right_Charge=21;
		public const int Fist_Stab_Right_Execute=22;
		public const int Fist_Bash_Right_Charge=23;
		public const int Fist_Bash_Right_Execute=24;
		public const int Fist_Slash_Right_Charge=25;
		public const int Fist_Slash_Right_Execute=26;
		public const int Fist_Ready_Right=27;


		public const int Sword_Stab_Left_Charge=28;
		public const int Sword_Stab_Left_Execute=29;
		public const int Sword_Bash_Left_Charge=30;
		public const int Sword_Bash_Left_Execute=31;
		public const int Sword_Slash_Left_Charge=32;
		public const int Sword_Slash_Left_Execute=33;
		public const int Sword_Ready_Left=34;


		public const int Axe_Stab_Left_Charge=35;
		public const int Axe_Stab_Left_Execute=36;
		public const int Axe_Bash_Left_Charge=37;
		public const int Axe_Bash_Left_Execute=38;
		public const int Axe_Slash_Left_Charge=39;
		public const int Axe_Slash_Left_Execute=40;
		public const int Axe_Ready_Left=41;

		public const int Mace_Stab_Left_Charge=42;
		public const int Mace_Stab_Left_Execute=43;
		public const int Mace_Bash_Left_Charge=44;
		public const int Mace_Bash_Left_Execute=45;
		public const int Mace_Slash_Left_Charge=46;
		public const int Mace_Slash_Left_Execute=47;
		public const int Mace_Ready_Left=48;

		public const int Fist_Stab_Left_Charge=49;
		public const int Fist_Stab_Left_Execute=50;
		public const int Fist_Bash_Left_Charge=51;
		public const int Fist_Bash_Left_Execute=52;
		public const int Fist_Slash_Left_Charge=53;
		public const int Fist_Slash_Left_Execute=54;
		public const int Fist_Ready_Left=55;


		public int[,] frames= new int[56,6];



		public RawImage TargetControl;
		public string SetAnimation;
		public string PreviousAnimation;
		private string PreviousSprite="";


		public WeaponAnimation()
		{
				frames[Sword_Stab_Right_Charge,0] =0;	frames[Sword_Stab_Right_Charge,1] =1;	frames[Sword_Stab_Right_Charge,2] =2;	frames[Sword_Stab_Right_Charge,3] =3;	frames[Sword_Stab_Right_Charge,4] =-1;	frames[Sword_Stab_Right_Charge,5] =-1;
				frames[Sword_Stab_Right_Execute,0] =4;	frames[Sword_Stab_Right_Execute,1] =5;	frames[Sword_Stab_Right_Execute,2] =6;	frames[Sword_Stab_Right_Execute,3] =7;	frames[Sword_Stab_Right_Execute,4] =8;	frames[Sword_Stab_Right_Execute,5] =27;
				frames[Sword_Bash_Right_Charge,0] =9;	frames[Sword_Bash_Right_Charge,1] =10;	frames[Sword_Bash_Right_Charge,2] =11;	frames[Sword_Bash_Right_Charge,3] =12;	frames[Sword_Bash_Right_Charge,4] =-1;	frames[Sword_Bash_Right_Charge,5] =-1;
				frames[Sword_Bash_Right_Execute,0] =13;	frames[Sword_Bash_Right_Execute,1] =14;	frames[Sword_Bash_Right_Execute,2] =15;	frames[Sword_Bash_Right_Execute,3] =16;	frames[Sword_Bash_Right_Execute,4] =17;	frames[Sword_Bash_Right_Execute,5] =27;
				frames[Sword_Slash_Right_Charge,0] =18;	frames[Sword_Slash_Right_Charge,1] =19;	frames[Sword_Slash_Right_Charge,2] =20;	frames[Sword_Slash_Right_Charge,3] =21;	frames[Sword_Slash_Right_Charge,4] =-1;	frames[Sword_Slash_Right_Charge,5] =-1;
				frames[Sword_Slash_Right_Execute,0] =22;	frames[Sword_Slash_Right_Execute,1] =23;	frames[Sword_Slash_Right_Execute,2] =24;	frames[Sword_Slash_Right_Execute,3] =25;	frames[Sword_Slash_Right_Execute,4] =26;	frames[Sword_Slash_Right_Execute,5] =27;
				frames[Sword_Ready_Right,0] =27;	frames[Sword_Ready_Right,1] =-1;	frames[Sword_Ready_Right,2] =-1;	frames[Sword_Ready_Right,3] =-1;	frames[Sword_Ready_Right,4] =-1;	frames[Sword_Ready_Right,5] =-1;
				frames[Axe_Stab_Right_Charge,0] =28;	frames[Axe_Stab_Right_Charge,1] =29;	frames[Axe_Stab_Right_Charge,2] =30;	frames[Axe_Stab_Right_Charge,3] =31;	frames[Axe_Stab_Right_Charge,4] =-1;	frames[Axe_Stab_Right_Charge,5] =-1;
				frames[Axe_Stab_Right_Execute,0] =32;	frames[Axe_Stab_Right_Execute,1] =33;	frames[Axe_Stab_Right_Execute,2] =34;	frames[Axe_Stab_Right_Execute,3] =35;	frames[Axe_Stab_Right_Execute,4] =36;	frames[Axe_Stab_Right_Execute,5] =55;
				frames[Axe_Bash_Right_Charge,0] =37;	frames[Axe_Bash_Right_Charge,1] =38;	frames[Axe_Bash_Right_Charge,2] =39;	frames[Axe_Bash_Right_Charge,3] =40;	frames[Axe_Bash_Right_Charge,4] =-1;	frames[Axe_Bash_Right_Charge,5] =-1;
				frames[Axe_Bash_Right_Execute,0] =41;	frames[Axe_Bash_Right_Execute,1] =42;	frames[Axe_Bash_Right_Execute,2] =43;	frames[Axe_Bash_Right_Execute,3] =44;	frames[Axe_Bash_Right_Execute,4] =45;	frames[Axe_Bash_Right_Execute,5] =55;
				frames[Axe_Slash_Right_Charge,0] =46;	frames[Axe_Slash_Right_Charge,1] =47;	frames[Axe_Slash_Right_Charge,2] =48;	frames[Axe_Slash_Right_Charge,3] =49;	frames[Axe_Slash_Right_Charge,4] =-1;	frames[Axe_Slash_Right_Charge,5] =-1;
				frames[Axe_Slash_Right_Execute,0] =50;	frames[Axe_Slash_Right_Execute,1] =51;	frames[Axe_Slash_Right_Execute,2] =52;	frames[Axe_Slash_Right_Execute,3] =53;	frames[Axe_Slash_Right_Execute,4] =54;	frames[Axe_Slash_Right_Execute,5] =55;
				frames[Axe_Ready_Right  ,0] =55;	frames[Axe_Ready_Right  ,1] =-1;	frames[Axe_Ready_Right  ,2] =-1;	frames[Axe_Ready_Right  ,3] =-1;	frames[Axe_Ready_Right  ,4] =-1;	frames[Axe_Ready_Right  ,5] =-1;
				frames[Mace_Stab_Right_Charge,0] =56;	frames[Mace_Stab_Right_Charge,1] =57;	frames[Mace_Stab_Right_Charge,2] =58;	frames[Mace_Stab_Right_Charge,3] =59;	frames[Mace_Stab_Right_Charge,4] =-1;	frames[Mace_Stab_Right_Charge,5] =-1;
				frames[Mace_Stab_Right_Execute,0] =60;	frames[Mace_Stab_Right_Execute,1] =61;	frames[Mace_Stab_Right_Execute,2] =62;	frames[Mace_Stab_Right_Execute,3] =63;	frames[Mace_Stab_Right_Execute,4] =64;	frames[Mace_Stab_Right_Execute,5] =83;
				frames[Mace_Bash_Right_Charge,0] =65;	frames[Mace_Bash_Right_Charge,1] =66;	frames[Mace_Bash_Right_Charge,2] =67;	frames[Mace_Bash_Right_Charge,3] =68;	frames[Mace_Bash_Right_Charge,4] =-1;	frames[Mace_Bash_Right_Charge,5] =-1;
				frames[Mace_Bash_Right_Execute,0] =69;	frames[Mace_Bash_Right_Execute,1] =70;	frames[Mace_Bash_Right_Execute,2] =71;	frames[Mace_Bash_Right_Execute,3] =72;	frames[Mace_Bash_Right_Execute,4] =73;	frames[Mace_Bash_Right_Execute,5] =83;
				frames[Mace_Slash_Right_Charge,0] =74;	frames[Mace_Slash_Right_Charge,1] =75;	frames[Mace_Slash_Right_Charge,2] =76;	frames[Mace_Slash_Right_Charge,3] =77;	frames[Mace_Slash_Right_Charge,4] =-1;	frames[Mace_Slash_Right_Charge,5] =-1;
				frames[Mace_Slash_Right_Execute,0] =78;	frames[Mace_Slash_Right_Execute,1] =79;	frames[Mace_Slash_Right_Execute,2] =80;	frames[Mace_Slash_Right_Execute,3] =81;	frames[Mace_Slash_Right_Execute,4] =82;	frames[Mace_Slash_Right_Execute,5] =83;
				frames[Mace_Ready_Right   ,0] =83;	frames[Mace_Ready_Right   ,1] =-1;	frames[Mace_Ready_Right   ,2] =-1;	frames[Mace_Ready_Right   ,3] =-1;	frames[Mace_Ready_Right   ,4] =-1;	frames[Mace_Ready_Right   ,5] =-1;
				frames[Fist_Stab_Right_Charge,0] =84;	frames[Fist_Stab_Right_Charge,1] =85;	frames[Fist_Stab_Right_Charge,2] =86;	frames[Fist_Stab_Right_Charge,3] =87;	frames[Fist_Stab_Right_Charge,4] =-1;	frames[Fist_Stab_Right_Charge,5] =-1;
				frames[Fist_Stab_Right_Execute,0] =88;	frames[Fist_Stab_Right_Execute,1] =89;	frames[Fist_Stab_Right_Execute,2] =90;	frames[Fist_Stab_Right_Execute,3] =91;	frames[Fist_Stab_Right_Execute,4] =92;	frames[Fist_Stab_Right_Execute,5] =111;
				frames[Fist_Bash_Right_Charge,0] =93;	frames[Fist_Bash_Right_Charge,1] =94;	frames[Fist_Bash_Right_Charge,2] =95;	frames[Fist_Bash_Right_Charge,3] =96;	frames[Fist_Bash_Right_Charge,4] =-1;	frames[Fist_Bash_Right_Charge,5] =1;
				frames[Fist_Bash_Right_Execute,0] =97;	frames[Fist_Bash_Right_Execute,1] =98;	frames[Fist_Bash_Right_Execute,2] =99;	frames[Fist_Bash_Right_Execute,3] =100;	frames[Fist_Bash_Right_Execute,4] =101;	frames[Fist_Bash_Right_Execute,5] =111;
				frames[Fist_Slash_Right_Charge,0] =102;	frames[Fist_Slash_Right_Charge,1] =103;	frames[Fist_Slash_Right_Charge,2] =104;	frames[Fist_Slash_Right_Charge,3] =105;	frames[Fist_Slash_Right_Charge,4] =-1;	frames[Fist_Slash_Right_Charge,5] =-1;
				frames[Fist_Slash_Right_Execute,0] =106;	frames[Fist_Slash_Right_Execute,1] =107;	frames[Fist_Slash_Right_Execute,2] =108;	frames[Fist_Slash_Right_Execute,3] =109;	frames[Fist_Slash_Right_Execute,4] =110;	frames[Fist_Slash_Right_Execute,5] =111;
				frames[Fist_Ready_Right,0] =111;	frames[Fist_Ready_Right,1] =-1;	frames[Fist_Ready_Right,2] =-1;	frames[Fist_Ready_Right,3] =-1;	frames[Fist_Ready_Right,4] =-1;	frames[Fist_Ready_Right,5] =-1;
				frames[Sword_Stab_Left_Charge,0] =112;	frames[Sword_Stab_Left_Charge,1] =113;	frames[Sword_Stab_Left_Charge,2] =114;	frames[Sword_Stab_Left_Charge,3] =115;	frames[Sword_Stab_Left_Charge,4] =-1;	frames[Sword_Stab_Left_Charge,5] =-1;
				frames[Sword_Stab_Left_Execute,0] =116;	frames[Sword_Stab_Left_Execute,1] =117;	frames[Sword_Stab_Left_Execute,2] =118;	frames[Sword_Stab_Left_Execute,3] =119;	frames[Sword_Stab_Left_Execute,4] =120;	frames[Sword_Stab_Left_Execute,5] =139;
				frames[Sword_Bash_Left_Charge,0] =121;	frames[Sword_Bash_Left_Charge,1] =122;	frames[Sword_Bash_Left_Charge,2] =123;	frames[Sword_Bash_Left_Charge,3] =124;	frames[Sword_Bash_Left_Charge,4] =-1;	frames[Sword_Bash_Left_Charge,5] =-1;
				frames[Sword_Bash_Left_Execute,0] =125;	frames[Sword_Bash_Left_Execute,1] =126;	frames[Sword_Bash_Left_Execute,2] =127;	frames[Sword_Bash_Left_Execute,3] =128;	frames[Sword_Bash_Left_Execute,4] =129;	frames[Sword_Bash_Left_Execute,5] =139;
				frames[Sword_Slash_Left_Charge,0] =130;	frames[Sword_Slash_Left_Charge,1] =131;	frames[Sword_Slash_Left_Charge,2] =132;	frames[Sword_Slash_Left_Charge,3] =133;	frames[Sword_Slash_Left_Charge,4] =-1;	frames[Sword_Slash_Left_Charge,5] =-1;
				frames[Sword_Slash_Left_Execute,0] =134;	frames[Sword_Slash_Left_Execute,1] =135;	frames[Sword_Slash_Left_Execute,2] =136;	frames[Sword_Slash_Left_Execute,3] =137;	frames[Sword_Slash_Left_Execute,4] =138;	frames[Sword_Slash_Left_Execute,5] =139;
				frames[Sword_Ready_Left,0] =139;	frames[Sword_Ready_Left,1] =-1;	frames[Sword_Ready_Left,2] =-1;	frames[Sword_Ready_Left,3] =-1;	frames[Sword_Ready_Left,4] =-1;	frames[Sword_Ready_Left,5] =-1;
				frames[Axe_Stab_Left_Charge,0] =140;	frames[Axe_Stab_Left_Charge,1] =141;	frames[Axe_Stab_Left_Charge,2] =142;	frames[Axe_Stab_Left_Charge,3] =143;	frames[Axe_Stab_Left_Charge,4] =-1;	frames[Axe_Stab_Left_Charge,5] =-1;
				frames[Axe_Stab_Left_Execute,0] =144;	frames[Axe_Stab_Left_Execute,1] =145;	frames[Axe_Stab_Left_Execute,2] =146;	frames[Axe_Stab_Left_Execute,3] =147;	frames[Axe_Stab_Left_Execute,4] =148;	frames[Axe_Stab_Left_Execute,5] =167;
				frames[Axe_Bash_Left_Charge,0] =149;	frames[Axe_Bash_Left_Charge,1] =150;	frames[Axe_Bash_Left_Charge,2] =151;	frames[Axe_Bash_Left_Charge,3] =152;	frames[Axe_Bash_Left_Charge,4] =-1;	frames[Axe_Bash_Left_Charge,5] =-1;
				frames[Axe_Bash_Left_Execute,0] =153;	frames[Axe_Bash_Left_Execute,1] =154;	frames[Axe_Bash_Left_Execute,2] =155;	frames[Axe_Bash_Left_Execute,3] =156;	frames[Axe_Bash_Left_Execute,4] =157;	frames[Axe_Bash_Left_Execute,5] =167;
				frames[Axe_Slash_Left_Charge,0] =158;	frames[Axe_Slash_Left_Charge,1] =159;	frames[Axe_Slash_Left_Charge,2] =160;	frames[Axe_Slash_Left_Charge,3] =161;	frames[Axe_Slash_Left_Charge,4] =-1;	frames[Axe_Slash_Left_Charge,5] =-1;
				frames[Axe_Slash_Left_Execute,0] =162;	frames[Axe_Slash_Left_Execute,1] =163;	frames[Axe_Slash_Left_Execute,2] =164;	frames[Axe_Slash_Left_Execute,3] =165;	frames[Axe_Slash_Left_Execute,4] =166;	frames[Axe_Slash_Left_Execute,5] =167;
				frames[Axe_Ready_Left,0] =167;	frames[Axe_Ready_Left,1] =-1;	frames[Axe_Ready_Left,2] =-1;	frames[Axe_Ready_Left,3] =-1;	frames[Axe_Ready_Left,4] =-1;	frames[Axe_Ready_Left,5] =-1;
				frames[Mace_Stab_Left_Charge,0] =168;	frames[Mace_Stab_Left_Charge,1] =169;	frames[Mace_Stab_Left_Charge,2] =170;	frames[Mace_Stab_Left_Charge,3] =171;	frames[Mace_Stab_Left_Charge,4] =-1;	frames[Mace_Stab_Left_Charge,5] =-1;
				frames[Mace_Stab_Left_Execute,0] =172;	frames[Mace_Stab_Left_Execute,1] =173;	frames[Mace_Stab_Left_Execute,2] =174;	frames[Mace_Stab_Left_Execute,3] =175;	frames[Mace_Stab_Left_Execute,4] =176;	frames[Mace_Stab_Left_Execute,5] =195;
				frames[Mace_Bash_Left_Charge,0] =177;	frames[Mace_Bash_Left_Charge,1] =178;	frames[Mace_Bash_Left_Charge,2] =179;	frames[Mace_Bash_Left_Charge,3] =180;	frames[Mace_Bash_Left_Charge,4] =-1;	frames[Mace_Bash_Left_Charge,5] =-1;
				frames[Mace_Bash_Left_Execute,0] =181;	frames[Mace_Bash_Left_Execute,1] =182;	frames[Mace_Bash_Left_Execute,2] =183;	frames[Mace_Bash_Left_Execute,3] =184;	frames[Mace_Bash_Left_Execute,4] =185;	frames[Mace_Bash_Left_Execute,5] =195;
				frames[Mace_Slash_Left_Charge,0] =186;	frames[Mace_Slash_Left_Charge,1] =187;	frames[Mace_Slash_Left_Charge,2] =188;	frames[Mace_Slash_Left_Charge,3] =189;	frames[Mace_Slash_Left_Charge,4] =-1;	frames[Mace_Slash_Left_Charge,5] =-1;
				frames[Mace_Slash_Left_Execute,0] =190;	frames[Mace_Slash_Left_Execute,1] =191;	frames[Mace_Slash_Left_Execute,2] =192;	frames[Mace_Slash_Left_Execute,3] =193;	frames[Mace_Slash_Left_Execute,4] =194;	frames[Mace_Slash_Left_Execute,5] =195;
				frames[Mace_Ready_Left,0] =195;	frames[Mace_Ready_Left,1] =-1;	frames[Mace_Ready_Left,2] =-1;	frames[Mace_Ready_Left,3] =-1;	frames[Mace_Ready_Left,4] =-1;	frames[Mace_Ready_Left,5] =-1;
				frames[Fist_Stab_Left_Charge,0] =196;	frames[Fist_Stab_Left_Charge,1] =197;	frames[Fist_Stab_Left_Charge,2] =198;	frames[Fist_Stab_Left_Charge,3] =199;	frames[Fist_Stab_Left_Charge,4] =-1;	frames[Fist_Stab_Left_Charge,5] =-1;
				frames[Fist_Stab_Left_Execute,0] =200;	frames[Fist_Stab_Left_Execute,1] =201;	frames[Fist_Stab_Left_Execute,2] =202;	frames[Fist_Stab_Left_Execute,3] =203;	frames[Fist_Stab_Left_Execute,4] =204;	frames[Fist_Stab_Left_Execute,5] =223;
				frames[Fist_Bash_Left_Charge,0] =205;	frames[Fist_Bash_Left_Charge,1] =206;	frames[Fist_Bash_Left_Charge,2] =207;	frames[Fist_Bash_Left_Charge,3] =208;	frames[Fist_Bash_Left_Charge,4] =-1;	frames[Fist_Bash_Left_Charge,5] =-1;
				frames[Fist_Bash_Left_Execute,0] =209;	frames[Fist_Bash_Left_Execute,1] =210;	frames[Fist_Bash_Left_Execute,2] =211;	frames[Fist_Bash_Left_Execute,3] =212;	frames[Fist_Bash_Left_Execute,4] =213;	frames[Fist_Bash_Left_Execute,5] =223;
				frames[Fist_Slash_Left_Charge,0] =214;	frames[Fist_Slash_Left_Charge,1] =215;	frames[Fist_Slash_Left_Charge,2] =216;	frames[Fist_Slash_Left_Charge,3] =217;	frames[Fist_Slash_Left_Charge,4] =-1;	frames[Fist_Slash_Left_Charge,5] =-1;
				frames[Fist_Slash_Left_Execute,0] =218;	frames[Fist_Slash_Left_Execute,1] =219;	frames[Fist_Slash_Left_Execute,2] =220;	frames[Fist_Slash_Left_Execute,3] =221;	frames[Fist_Slash_Left_Execute,4] =222;	frames[Fist_Slash_Left_Execute,5] =223;
				frames[Fist_Ready_Left,0] =223;	frames[Fist_Ready_Left,1] =-1;	frames[Fist_Ready_Left,2] =-1;	frames[Fist_Ready_Left,3] =-1;	frames[Fist_Ready_Left,4] =-1;	frames[Fist_Ready_Left,5] =-1;


		}

}
