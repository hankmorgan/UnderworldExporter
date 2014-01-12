#ifndef gamestrings_h
	#define gamestrings_h
	
	
void unpackStrings(int game);
void unpackStringsShock(char filePath[255]);

typedef struct huffman_node
{
  int symbol; // symbol in node
  int parent; //
  int left;   // -1 when no node
  int right;  // 
} huffman_node;


typedef struct block_dir
{
int block_no;
int address;
int NoOfEntries;
int blockEnd;
} block_dir;



#endif /*gamestrings*/