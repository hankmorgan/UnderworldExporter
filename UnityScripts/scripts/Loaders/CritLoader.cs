using UnityEngine;
using System.Collections;

public class CritLoader : ArtLoader {

	public CritterInfo critter;// =new CritterInfo[64];

	public CritLoader(int CritterToLoad)
	{				
		//pal.LoadPalettes();
		//Load the assoc file
		char[] assoc;
		long AssocAddressPtr=256;
		if (DataLoader.ReadStreamFile(BasePath + "crit\\ASSOC.ANM", out assoc))
		{
			for (int ass = 0 ; ass <=63 ; ass++)
			{
				int FileID= (int)DataLoader.getValAtAddress(assoc,AssocAddressPtr++,8);
				int auxPal = (int)DataLoader.getValAtAddress(assoc,AssocAddressPtr++,8);
				if (ass==CritterToLoad)
					{
						critter= new CritterInfo(FileID,  GameWorldController.instance.palLoader.Palettes[0], auxPal);						
					}				
			}
		}
	}



		public Sprite RetrieveSpriteByName(string AnimToFind, int currentAnimNo)
		{
				int index=-1;
				//I will know my animation mode from the npcs so i just need to iterate through the animation

				for (int j=0; j<=critter.AnimInfo.animSequence.GetUpperBound(0);j++)
				{
						if (critter.AnimInfo.animSequence[j,0]!=null)
						{
								for (int i=0; i<=critter.AnimInfo.animSequence.GetUpperBound(1);i++)
								{
										if (critter.AnimInfo.animSequence[j,i]==AnimToFind )
										{
												index= critter.AnimInfo.animIndices[j,i];
												break;
										}
								}		
						}
				}


				if(index!=-1)
				{
						return critter.AnimInfo.animSprites[index];
				}
				else
				{
					Debug.Log("Unable to find animation frame " + AnimToFind);
					return null;
				}

		}





}
