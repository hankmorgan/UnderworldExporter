using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CritterLoader : MonoBehaviour {
	public string pathToAssocFile;
	public string pathToAssocUW2File;
	public string pathToPGMPFile;
	public string pathToCRANFile;
	private char[] assoc;
	public CritterInfo[] critters =new CritterInfo[64];
	public PaletteLoader pal;
	public SpriteRenderer output;
	public SpriteRenderer output2;
	public Text debugInfo;
	//
	public string AnimToFind;

	public int testCritterId;
	public int testAnimNo;
	public int testFrameNo;
	public int indextofind=0;
	public int game;

	void Start()
		{
		if (game==0)
			{
			ReadAssocFile();
			}
		else
			{
			ReadUW2AssocFile();
			}		
		}

	void ReadAssocFile()
		{
		pal.LoadPalettes();
		//Load the assoc file
		long AssocAddressPtr=256;
		if (DataLoader.ReadStreamFile(pathToAssocFile, out assoc))
			{
			for (int ass = 0 ; ass <=63 ; ass++)
				{
				int FileID= (int)DataLoader.getValAtAddress(assoc,AssocAddressPtr++,8);
				int auxPal = (int)DataLoader.getValAtAddress(assoc,AssocAddressPtr++,8);
				if (ass==3)
					{
					critters[ass]= new CritterInfo(FileID, pal.Palettes[0], auxPal);
					}				
				}
			}
		}

	public void RetrieveCritter()
		{
		RetrieveCritter(testCritterId,testAnimNo,testFrameNo);
		}

	public void RetrieveCritter(int critterID, int animNo, int FrameNo)
		{
		int index= critters[critterID].AnimInfo.animIndices[animNo,FrameNo];
		if (index!=-1)
			{
			debugInfo.text=  critters[critterID].AnimInfo.animName[animNo];
			output.sprite = critters[critterID].AnimInfo.animSprites[index];
			AnimToFind=critters[critterID].AnimInfo.animSequence[animNo,FrameNo];
			testFrameNo++;
			if (testFrameNo>5)
				{
				testFrameNo=0;
				}
			}
		else
			{
			testFrameNo=0;
			}

		//RetrieveSpriteByName();
		}

	public void RetrieveSpriteByName()
		{
		int index=-1;
		//I will know my animation mode from the npcs so i just need to iterate through the animation
		for (int i=0; i<=critters[testCritterId].AnimInfo.animSequence.GetUpperBound(1);i++)
			{
			if (critters[testCritterId].AnimInfo.animSequence[testAnimNo,i]==AnimToFind )
				{
				index= critters[testCritterId].AnimInfo.animIndices[testAnimNo,i];
				break;
				}
			}
		if(index!=-1)
			{
			output2.sprite = critters[testCritterId].AnimInfo.animSprites[index];
		}

		}


	public void GetSpriteAt()
		{
		output2.sprite = critters[testCritterId].AnimInfo.animSprites[indextofind];
		}


	public void GetSpriteAtIndex()
		{//(testCritterId,testAnimNo,testFrameNo);
		output.sprite = critters[testCritterId].AnimInfo.animSprites[indextofind];
		debugInfo.text= critters[testCritterId].AnimInfo.animName[indextofind];
		indextofind++;
		if (indextofind>6)
			{
			indextofind=0;
			}
		}







	/**************************************/
	void ReadUW2AssocFile()
		{
		char[] pgmp;
		char[] cran;
		pal.LoadPalettes();
		//Load the assoc file
		long AssocAddressPtr=0;
		if  ( 
			( DataLoader.ReadStreamFile(pathToAssocUW2File, out assoc) ) 
			&& ( DataLoader.ReadStreamFile(pathToPGMPFile, out pgmp) ) 
			&& ( DataLoader.ReadStreamFile(pathToCRANFile, out cran) )  
		)
			{
			for (int ass = 0 ; ass <=63 ; ass++)
				{
					int FileID= (int)DataLoader.getValAtAddress(assoc,AssocAddressPtr++,8);
					int auxPal = (int)DataLoader.getValAtAddress(assoc,AssocAddressPtr++,8);
					if (FileID!=255)
						{
						critters[ass]= new CritterInfo(FileID, pal.Palettes[0], auxPal, assoc, pgmp, cran);			
						}
			
				}
			}
		}
	
}