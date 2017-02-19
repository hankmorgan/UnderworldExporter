using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

/// <summary>
/// Class for holding game strings and returning formatted strings and text
/// </summary>
public class StringController  {

	/// <summary>
	/// The game strings are stored in this hashtable.
	/// </summary>
	/// Hash is in format [block number]_[string number]
	private Hashtable GameStrings;

	/// <summary>
	/// Huffman node structure for decoding strings.pak
	/// </summary>
	struct huffman_node
	{
		public char symbol; // symbol in node
		public int parent; //
		public int left;   // -1 when no node
		public int right;  // 
	};

	struct block_dir
	{
		public long block_no;
		public long address;
		public long NoOfEntries;
		//public long blockEnd;
	} ;

	//public string Path;


	/// <summary>
	/// The instance of this class
	/// </summary>
	public static StringController instance;

	//Temporary array until I'm wide awake
		private string[] UW1_TextureNames ={"a stone wall",
		"a mossy stone wall",
		"a cracked stone wall",
		"a drain",
		"a vine-covered stone wall",
		"a tapestry",
		"the Banner of Cabirus",
		"a stone wall",
		"a stone wall",
		"the Standard of the Mountainfolk",
		"the Standard of the Knights",
		"a grating",
		"an irregular stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"a mossy irregular stone wall",
		"the Standard of the Silver Serpent",
		"a cracked irregular stone wall",
		"a drain",
		"a vine-covered irregular stone wall",
		"a tapestry",
		"a grating",
		"an irregular stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"a natural stone wall",
		"a natural stone wall",
		"a mossy natural stone wall",
		"a mossy natural stone wall",
		"a waterfall",
		"a grating",
		"a natural stone wall",
		"a natural stone wall",
		"the locked doors of the Abyss",
		"the locked doors of the Abyss",
		"a drain",
		"a tapestry",
		"a vine-covered natural stone wall",
		"a massive stone door",
		"a massive stone door",
		"a massive stone door",
		"a massive stone door",
		"a stone slab with a three-pronged indentation",
		"a stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"a drain",
		"a cracked irregular stone wall",
		"a vine-covered irregular stone wall",
		"a grating",
		"a moss-covered irregular stone wall",
		"the Banner of Cabirus",
		"an irregular stone wall",
		"an irregular stone wall",
		"the Standard of the Silver Sapling",
		"an irregular stone wall",
		"nothing",
		"a massive stone door",
		"a natural stone wall",
		"a natural stone wall",
		"a moss-covered natural stone wall",
		"a moss-covered natural stone wall",
		"a pipe",
		"a drain",
		"a natural stone wall",
		"a natural stone wall",
		"nothing",
		"nothing",
		"a grating",
		"a tapestry",
		"a stucco wall",
		"a stucco wall",
		"a peeling stucco wall",
		"a tapestry",
		"a peeling stucco wall",
		"a small rusty pipe",
		"a brick wall",
		"a brick wall",
		"a stucco wall",
		"a stucco wall",
		"a stucco wall",
		"a brick wall",
		"a grating",
		"a Standard of the Silver Serpent",
		"a drain",
		"a peeling stucco wall",
		"a stucco wall",
		"nothing",
		"a brick wall",
		"a brick wall",
		"a brick wall",
		"a brick wall",
		"nothing",
		"nothing",
		"a grating",
		"a tapestry",
		"a pipe",
		"a mossy brick wall",
		"a cracked brick wall",
		"a drain",
		"a finished oak wall",
		"a finished oak wall",
		"a finished oak wall",
		"a finished oak wall",
		"a grating",
		"a pipe",
		"a marble wall",
		"a marble wall",
		"a marble wall",
		"a marble wall",
		"a marble wall",
		"a marble wall",
		"a tapestry",
		"a drain",
		"a pipe",
		"the Standard of the Silver Serpent",
		"the Standard of the Seers",
		"the Standard of the Seers",
		"a rough hewn wall",
		"a window",
		"a gold-veined rough hewn wall",
		"a rough hewn wall",
		"a rough hewn wall",
		"a mossy rough hewn wall",
		"a drain",
		"a tapestry",
		"a drain",
		"a brick wall",
		"a brick wall",
		"a stairway leading down",
		"a moss-covered wall",
		"a stairway leading up",
		"a stairway leading up",
		"a stairway leading down",
		"a window",
		"a princess chained to a brick wall",
		"a stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"a drain",
		"a cracked irregular stone wall",
		"a vine-covered irregular stone wall",
		"a grating",
		"a mossy irregular stone wall",
		"the Banner of Cabirus",
		"an irregular stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"the Standard of the Knights",
		"a caved-in stairway",
		"a caved-in passageway",
		"a stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"a mossy stone wall",
		"a cracked irregular stone wall",
		"a drain",
		"a vine-covered irregular stone wall",
		"a tapestry",
		"a grating",
		"a moss-covered irregular stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"an irregular stone wall",
		"a marble wall",
		"a marble wall",
		"a marble wall",
		"a marble wall",
		"a marble wall",
		"a marble wall",
		"a marble wall",
		"a marble wall",
		"a marble wall",
		"a marble wall",
		"a marble wall",
		"an ankh",
		"a marble wall",
		"a marble wall",
		"a stone wall",
		"a stone wall",
		"a stone wall",
		"a stone wall",
		"a massive stone door",
		"a marble wall",
		"a waterfall",
		"a marble wall",
		"a marble wall",
		"a marble wall",
		"a marble wall",
		"a marble wall",
		"a marble wall",
		"a marble wall",
		"a lavafall",
		"a rough hewn wall",
		"a rough hewn wall",
		"a pipe",
		"a stone floor",
		"a stone floor",
		"a puddle",
		"a puddle",
		"a stone floor",
		"a dirt floor",
		"a dirt floor",
		"a dirt floor",
		"a dirt floor",
		"a dirt floor",
		"a dirt floor",
		"a dirt floor",
		"a marble floor",
		"a marble floor",
		"a marble floor",
		"a marble floor",
		"water",
		"water",
		"a dirt floor",
		"a dirt floor",
		"a dirt floor",
		"a dirt floor",
		"a dirt floor",
		"rivulets of lava",
		"lava",
		"lava",
		"nothing",
		"a rough floor",
		"a rough floor",
		"a rough floor",
		"a rough floor",
		"a rough floor",
		"water",
		"water",
		"water",
		"a dirt floor",
		"a rough floor",
		"a dirt floor",
		"a dirt floor",
		"a dirt floor",
		"a dirt floor",
		"rivulets of lava",
		"a straw bed",
		"a glowing green pathway",
		"a glowing green pathway",
		"a glowing green pathway",
		"a glowing red pathway",
		"a glowing red pathway",
		"a glowing red pathway",
		"a glowing blue pathway",
		"a glowing blue pathway",
		"a glowing blue pathway"
		};



	/// <summary>
	/// Loads and decodes the strings.pak file as specificed by the Path.
	/// </summary>
	/// <param name="path">Path.</param>
	public void LoadStringsPak(string path)
		{
		string Result="";
		long address_pointer=0;
		huffman_node[] hman;
		block_dir[] blocks;
		char[] Buffer;
		string Key="";
		GameStrings=new Hashtable();


		if (DataLoader.ReadStreamFile(path,out Buffer))
			{
			long NoOfNodes=DataLoader.getValAtAddress(Buffer,address_pointer,16);
			int i=0;
			hman = new huffman_node [NoOfNodes];
			address_pointer=address_pointer+2;
			while (i<NoOfNodes)
				{
				hman[i].symbol= System.Convert.ToChar(Buffer[address_pointer+0]);
				hman[i].parent=Buffer[address_pointer+1];
				hman[i].left= Buffer[address_pointer+2];
				hman[i].right= Buffer[address_pointer+3];
				i++;
				address_pointer=address_pointer+4;
				}

			long NoOfStringBlocks=DataLoader.getValAtAddress(Buffer,address_pointer,16);
			blocks=new block_dir[NoOfStringBlocks];
			address_pointer=address_pointer+2;
			i=0;
			while (i<NoOfStringBlocks)
				{
				blocks[i].block_no = DataLoader.getValAtAddress(Buffer,address_pointer,16);
				address_pointer=address_pointer+2;
				blocks[i].address = DataLoader.getValAtAddress(Buffer,address_pointer,32);	
				address_pointer=address_pointer+4;
				blocks[i].NoOfEntries = DataLoader.getValAtAddress(Buffer,blocks[i].address,16);	//look ahead and get no of entries.
				i++;
				}
			i=0;
			//
			int Iteration=0;
			while (i<NoOfStringBlocks)
				{
				address_pointer=2 + blocks[i].address + blocks[i].NoOfEntries *2;
				int blnFnd;
				for (int j=0;j< blocks[i].NoOfEntries;j++)
					{
					//Based on abysmal /uwadv implementations.
					blnFnd=0;
					//char c;

					int bit = 0;
					int raw = 0;
					long node=0;

						do {
						node = NoOfNodes - 1; // starting node

						// huffman tree decode loop
						//This was -1 in the original code!
						while (hman[node].left != 255
							&& hman[node].right != 255)
							{

								if (bit == 0) {
								bit = 8;
								raw = Buffer[address_pointer++];	//stream.get<uint8_t>();
								}
							Iteration++;
							//Debug.Log("raw=" + raw + "=" + (raw & 0x80));
							// decide which node is next
							//node = raw & 0x80 ? hman[node].right
							//	: hman[node].left;
							if ((raw & 0x80) ==128)
								{
								node=hman[node].right;
								}
							else
								{
								node=hman[node].left;
								}

							raw <<= 1;
							bit--;
							}

						// have a new symbol
							if ((hman[node].symbol !='|')){
							if (blnFnd==0)
								{
								Key= blocks[i].block_no.ToString("000")+"_"+j.ToString("000") ;
								}						
							Result+=hman[node].symbol;	
							blnFnd = 1;
							}
						else
							{
							if ((Result.Length>0) && (Key.Length>0))
								{
								GameStrings[Key]=Result;
								Result="";
								Key="";
								}
							}
						} while (hman[node].symbol != '|');		
					}
				i++;
				}
			if ((Result.Length>0) && (Key.Length>0))
				{//I still have the very last value to keep.
				GameStrings[Key]=Result;
				Result="";
				}
			}	

		}



	/// <summary>
	/// Gets the string at the specified numbers
	/// </summary>
	/// <returns>The string.</returns>
	/// <param name="BlockNo">Block no.</param>
	/// <param name="StringNo">String no.</param>
	public string GetString(int BlockNo, int StringNo)
		{//output a string at the specified block and string no.
		return (string)GameStrings[BlockNo.ToString("000") + "_" + StringNo.ToString("000")];
		}
	
}