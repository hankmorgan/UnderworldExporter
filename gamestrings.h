#ifndef gamestrings_h
	#define gamestrings_h
	
	
void unpackStrings(int game);
void unpackStringsShock(char filePath[255]);

struct huffman_node
{
  int symbol; // symbol in node
  int parent; //
  int left;   // -1 when no node
  int right;  // 
};


struct block_dir
{
int block_no;
int address;
int NoOfEntries;
int blockEnd;
} ;


void unpackStrings(int game);
void unpackStringsShock(char filePath[255]);

#endif /*gamestrings*/