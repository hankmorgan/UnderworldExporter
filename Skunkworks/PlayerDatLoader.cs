using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerDatLoader : MonoBehaviour {

	public ObjectMasters objectMaster;

	//Theory on inventory
	//Uses same structure as object lists. -> Stored as linked lists (using next) same as regular game objects
	//Indices are something to something bits at these following offsets
	//Various offsets in the file point to the start object index of the inventory-> just like in tile maps.
	// offset 258d is the top left shoulder.
	// offset 260d is the top right shoulder.
	// offset 262d is the left hand.
	// offset 264d is the right hand.
	// offset 266d is the left ring (assumption.
	// offset 268d is the right ring (assumption.
	// offset 270d is the backpack slots 1.
	// offset 284d is the backpack slots 8.

	public Text Output;
	public string Path;


	public string character_name;

	public int Strength;
	public int Dexterity;
	public int Intelligence;
	public int Attack;
	public int Defense;
	public int Unarmed;
	public int  Sword;
	public int  Axe;
	public int Mace;
	public int Missile;
	public int Mana;
	public int Lore;
	public int Casting;
	public int  Traps;
	public int Search;
	public int Track;
	public int Sneak;
	public int Repair;
	public int Charm;
	public int Picklock;
	public int Acrobat;
	public int Appraise;
	public int Swimming;

	public int  max_vitality;
	public int current_mana;//, (play_mana)
	public int max_mana;
	public int hunger;//, play_hunger

	public int character_level ;//(play_level)

		//0044   3*8bits rune flags (*)
		
	public int  weight; // in 0.1 stones
	public int  experience; //in 0.1 points
		
	public int x_position;// in level
	public int  y_position;
	public int  z_position;
	public int  heading;
	public int  dungeon_level;
		
	public int  play_poison;
		
	public int game_time;

	public int current_vitality;

	public bool[] runes= new bool[24];

	public void Start()
		{
		objectMaster=new ObjectMasters();
		objectMaster.Load(Application.dataPath + "//..//uw1_object_config.txt");
		}

	public void LoadPlayerData()
		{
		Output.text="";
		character_name="";
		char[] buffer;
		if (DataLoader.ReadStreamFile(Path, out buffer))
			{
			int xOrValue= (int)buffer[0];
			int incrnum = 3;

			for(int i=1; i<220; i++)
				{
				if (i==81) 
					{
					incrnum = 3;
					}
				buffer[i] ^= (char)((xOrValue+incrnum) & 0xFF);
				incrnum += 3;
				}
			string Result="";
			int runeOffset=0;
			for (int i=1; i<=221;i++)
				{
				if (i<14)
					{
					character_name +=buffer[i];
					}
				else
					{
					switch(i)//UWformats doesn't take the first byte into account when describing offsets! I have incremented plus one
						{
						case 0x1E+1 ://Strength
							Strength=(int)buffer[i];break;
						case 0x1F+1 ://Dex
							Dexterity=(int)buffer[i];break;
						case 0x20   + 1 : ///    Intelligence
							Intelligence=(int)buffer[i];break;
						case 0x21   + 1 : ///    Attack
							Attack=(int)buffer[i];break;
						case 0x22   + 1 : ///    Defense
							Defense=(int)buffer[i];break;
						case 0x23   + 1 : ///    Unarmed
							Unarmed=(int)buffer[i];break;
						case 0x24   + 1 : ///    Sword
							Sword=(int)buffer[i];break;
						case 0x25   + 1 : ///    Axe
							Axe=(int)buffer[i];break;
						case 0x26   + 1 : ///    Mace
							Mace=(int)buffer[i];break;
						case 0x27   + 1 : ///    Missile
							Missile=(int)buffer[i];break;
						case 0x28   + 1 : ///    Mana
							Mana=(int)buffer[i];break;
						case 0x29   + 1 : ///    Lore
							Lore=(int)buffer[i];break;
						case 0x2A   + 1 : ///    Casting
							Casting=(int)buffer[i];break;
						case 0x2B   + 1 : ///    Traps
							Traps=(int)buffer[i];break;
						case 0x2C   + 1 : ///    Search
							Search=(int)buffer[i];break;
						case 0x2D   + 1 : ///    Track
							Track=(int)buffer[i];break;
						case 0x2E   + 1 : ///    Sneak
							Sneak=(int)buffer[i];break;
						case 0x2F   + 1 : ///    Repair
							Repair=(int)buffer[i];break;
						case 0x30   + 1 : ///    Charm
							Charm=(int)buffer[i];break;
						case 0x31   + 1 : ///    Picklock
							Picklock=(int)buffer[i];break;
						case 0x32   + 1 : ///    Acrobat
							Acrobat=(int)buffer[i];break;
						case 0x33   + 1 : ///    Appraise
							Appraise=(int)buffer[i];break;
						case 0x34   + 1 : ///    Swimming
							Swimming=(int)buffer[i];break;
						case 0x36   + 1 : ///    max. vitality
							max_vitality=(int)buffer[i];break;
						case 0x37   + 1 : ///    current mana, (play_mana)
							current_mana=(int)buffer[i];break;
						case 0x38   + 1 : ///    max. mana
							max_mana=(int)buffer[i];break;
						case 0x39   + 1 : ///    hunger, play_hunger
							hunger=(int)buffer[i];break;						
						case 0x3D   + 1 : ///    character level (play_level)
							character_level=(int)buffer[i];break;
						case 0x44 + 1://Runebits
						case 0x45 + 1://Runebits
						case 0x46 + 1://Runebits
							for (int r =7; r>=0; r--)
								{
								if (((buffer[i]>>r) & 0x1 )== 1)
									{
									runes[7-r+runeOffset]=true;
									}
								else
									{
									runes[7-r+runeOffset]=false;
									}
								}
							runeOffset+=8;
							break;

						case 0x4C   + 1 : ///   weight in 0.1 stones
							weight =(int)DataLoader.getValAtAddress(buffer,i,16);break;
						case 0x4E   + 1 : ///   experience in 0.1 points
							experience=(int)DataLoader.getValAtAddress(buffer,i,32);break;
						case 0x54   + 1 : ///   x-position in level
							x_position= (int)DataLoader.getValAtAddress(buffer,i,16);break;
						case 0x56   + 1 : ///   y-position
							y_position=(int)DataLoader.getValAtAddress(buffer,i,16);break;
						case 0x58   + 1 : ///   z-position
							z_position=(int)DataLoader.getValAtAddress(buffer,i,16);break;
						case 0x5A   + 1 : ///   heading
							heading=(int)DataLoader.getValAtAddress(buffer,i,16);break;
						case 0x5C   + 1 : ///   dungeon level
							dungeon_level=(int)DataLoader.getValAtAddress(buffer,i,16);break;
						case 0x5F   + 1 : ///    bits 2..5: play_poison
							play_poison=(int)((buffer[i]>>2) & 0x7 );break;
						case 0xCE   + 1 : ///   game time
							game_time=(int)DataLoader.getValAtAddress(buffer,i,32);break;
						case 0xDC   + 1 : ///    current vitality
							current_vitality=(int)buffer[i];break;
						}
					}
				}



			//Inventory list
			int NoOfItems = (buffer.GetUpperBound(0)-312)/8;
			ObjectInfo[] objList = new ObjectInfo[NoOfItems+2];
			int x=1;
			//Debug.Log ("remaining space " + ((int)buffer.GetUpperBound(0)-222));
			if (buffer.GetUpperBound(0)>=312)
				{
				int i = 312;
				while (i < buffer.GetUpperBound(0))
					{
					objList[x] = new ObjectInfo();
					objList[x].item_id = (int)(DataLoader.getValAtAddress(buffer,i+0,16)) & 0x1FF;
					//printf("Item ID %d %d\n",x, objList[x].item_id);
					objList[x].flags  = (int)((DataLoader.getValAtAddress(buffer,i+0,16))>> 9) & 0x0F;
					objList[x].enchantment = (short)(((DataLoader.getValAtAddress(buffer,i+0,16)) >> 12) & 0x01);
					objList[x].doordir  = (short)(((DataLoader.getValAtAddress(buffer,i+0,16)) >> 13) & 0x01);
					objList[x].invis  = (short)(((DataLoader.getValAtAddress(buffer,i+0,16)) >> 14 )& 0x01);
					objList[x].is_quant = (short)(((DataLoader.getValAtAddress(buffer,i+0,16)) >> 15) & 0x01);

					//position at +2
					objList[x].zpos = (int)(DataLoader.getValAtAddress(buffer,i+2,16)) & 0x7F;	//bits 0-6 
					//objList[x].heading =  45 * (int)(((DataLoader.getValAtAddress(buffer,i+2,16)) >> 7) & 0x07); //bits 7-9
					objList[x].heading = (int)(((DataLoader.getValAtAddress(buffer,i+2,16)) >> 7) & 0x07); //bits 7-9

					objList[x].y = (int)((DataLoader.getValAtAddress(buffer,i+2,16)) >> 10) & 0x07;	//bits 10-12
					objList[x].x = (int)((DataLoader.getValAtAddress(buffer,i+2,16)) >> 13) & 0x07;	//bits 13-15

					//+4
					objList[x].quality =(int)((DataLoader.getValAtAddress(buffer,i+4,16)) & 0x3F);
					objList[x].next = ((DataLoader.getValAtAddress(buffer,i+4,16)>>6) & 0x3FF);

					//+6

					objList[x].owner = (int)(DataLoader.getValAtAddress(buffer,i+6,16) & 0x3F) ;//bits 0-5

					objList[x].link = (int)(DataLoader.getValAtAddress(buffer, i + 6, 16) >> 6 & 0x3FF); //bits 6-15



				/*	int item_Id = (int)DataLoader.getValAtAddress(buffer,i,16) & 0x1ff;
					Debug.Log(i  + " = " +  objectMaster.desc[item_Id] + " (" + item_Id + ")" );
					Debug.Log(i+1  + " = " + (int)buffer[i+1]);
					Debug.Log(i+2  + " = " + (int)buffer[i+2] + " zpos?");
					Debug.Log(i+3  + " = " + (int)buffer[i+3]);
					Debug.Log(i+4  + " = " + ((int)buffer[i+4]));
					Debug.Log(i+4  + " = " + ((int)buffer[i+4] & 0x3f) + " quality?");
					Debug.Log(i+5  + " = " + (int)buffer[i+5]);
					int owner = (int)(DataLoader.getValAtAddress(buffer,i+6,16) & 0x3F) ;//bits 0-5
					Debug.Log(i+6  + " = " + (owner)+ " owner?");
					int link = (int)(DataLoader.getValAtAddress(buffer, i + 6, 16) >> 6 & 0x3FF); //bits 6-15
					Debug.Log(i+6  + " = " + (link)+ " link?");
					//Debug.Log(i+6  + " = " + ((int)buffer[i+6]  & 0x3f)+ " owner?");
					//Debug.Log(i+7  + " = " + (int)buffer[i+7]);*/


					i=i+8;
					if(objList[x].next!=0)
						{
						Output.text += ( x + " " + objectMaster.desc[objList[x].item_id] + "n = "+ objList[x].next + " l = " + objList[x].link + "\n");
						}
					else
						{
						Output.text += ( x + " " + objectMaster.desc[objList[x].item_id] + " l = " + objList[x].link +  "\n");
						}					
					x++;
					}
				//for (int i=312;i <=buffer.GetUpperBound(0);i++)
				//	{
				//	Debug.Log(i  + " = " + (int)buffer[i]);
				//	}

				//Inventory slots
				// offset 258d is the top left shoulder.
				// offset 260d is the top right shoulder.
				// offset 262d is the left hand.
				// offset 264d is the right hand.
				// offset 266d is the left ring (assumption.
				// offset 268d is the right ring (assumption.
				// offset 270d is the backpack slots 1.
				// offset 284d is the backpack slots 8.
				for (int j=258; j<286; j=j+2)
					{
					string slotName="";
					switch(j)
					{
					case 258:// is the top left shoulder.
						slotName="TopleftShoulder";break;
					case 260://  is the top right shoulder.
						slotName="TopRightShoulder";break;
					case 262://  is the left hand.
						slotName="LeftHand";break;
					case 264://  is the right hand.
						slotName="RightHand";break;
					case 266://  is the left ring (assumption.
						slotName="LeftRing";break;
					case 268://  is the right ring (assumption.
						slotName="RightRing";break;
					case 270://  is the backpack slots 1.
						slotName="Backpack1";break;
					case 272://  is the backpack slots 2.
						slotName="Backpack2";break;
					case 274://  is the backpack slots 3.
						slotName="Backpack3";break;
					case 276://  is the backpack slots 4.
						slotName="Backpack4";break;
					case 278://  is the backpack slots 5.
						slotName="Backpack5";break;
					case 280://  is the backpack slots 6.
						slotName="Backpack6";break;
					case 282://  is the backpack slots 7.
						slotName="Backpack7";break;	
					case 284://  is the backpack slots 8.
						slotName="Backpack8";break;
					}

					int index = ((int)DataLoader.getValAtAddress(buffer,j,16) >>6);
					if (index!=0)
						{
						Output.text += slotName + " contains " +  objectMaster.desc[objList[index].item_id] +"\n"; 
						}

					}







				}
			}				
		}
}
