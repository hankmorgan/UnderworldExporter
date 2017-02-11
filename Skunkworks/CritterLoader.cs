using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CritterLoader : MonoBehaviour {
	public string pathToAssocFile;
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

	void Start()
		{
		ReadAssocFile();
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
				critters[ass]= new CritterInfo(FileID, pal.Palettes[0], auxPal);
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
		debugInfo.text=  critters[critterID].AnimInfo.animName[animNo];
		output.sprite = critters[critterID].AnimInfo.animSprites[index];
		AnimToFind=critters[critterID].AnimInfo.animSequence[animNo,FrameNo];
		RetrieveSpriteByName();
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
	
}