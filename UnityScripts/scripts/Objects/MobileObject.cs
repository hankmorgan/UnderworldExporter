using UnityEngine;
using System.Collections;

public class MobileObject : object_base {
		
		//NPC Properties from Underworld
		[Header("UW Properties")]
		public short npc_whoami;
		public short npc_voidanim;
		public short npc_xhome;        //  x coord of home tile
		public short npc_yhome;        //  y coord of home tile
		public short npc_hunger;
		public short npc_health;
		public short npc_hp;
		public short npc_arms;          // (not used in uw1)
		public short npc_power;
		public short npc_goal;          // goal that NPC has; 5:kill player 6:? 9:?
		public short npc_attitude;       //attitude; 0:hostile, 1:upset, 2:mellow, 3:friendly
		public short npc_gtarg;         //goal target; 1:player
		public short npc_heading;
		public short npc_talkedto;      // is 1 when player already talked to npc
		public short npc_level;
		public short npc_name;       //    (not used in uw1)
		public short npc_height;
		//Unknown/research

		public short MobileUnk01;
		public short MobileUnk02;
		public short MobileUnk03;
		public short MobileUnk04;
		public short MobileUnk05;
		public short MobileUnk06;
		public short MobileUnk07;
		public short MobileUnk08;
		public short MobileUnk09;
		public short MobileUnk10;
		public short MobileUnk11;
		public short MobileUnk12;
		public short MobileUnk13;
		public short MobileUnk14;


		[Header("AI Target")]
		public GameObject gtarg;
		public string gtargName;



		//Projectiles are stored in the mobile object area.
		//The following properties are currently known
		[Header("Projectile")]
		public short MissileHeadingMajor;
		public short MissileHeadingMinor;
		public short Projectile_Pitch;

		[Header("RawData")]
		public short[] NPC_DATA=new short[19];

}
