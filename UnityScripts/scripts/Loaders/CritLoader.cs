using UnityEngine;
using System.Collections;


/// <summary>
/// Crit loader.
/// </summary>
/// Loads the basic animation frames for npcs
public class CritLoader : ArtLoader {

	public CritterInfo critter;// =new CritterInfo[64];


	public CritLoader(int CritterToLoad)
    {
        //if (xfer==null)
        //{
        //    xfer = new XFerLoader();
        //}
          //Load the assoc file
        switch (_RES)
        {
            case GAME_UW2:
                ReadUW2AssocFile(CritterToLoad);
                return;
            case GAME_UWDEMO:
                ReadUw1AssocFile(CritterToLoad, "CRIT" + sep + "DASSOC.ANM");
                return;
            default:
                ReadUw1AssocFile(CritterToLoad, "CRIT" + sep + "ASSOC.ANM");
                return;
        }        
    }

    private void ReadUw1AssocFile(int CritterToLoad, string assocpath)
    {
        char[] assoc;
        long AssocAddressPtr = 256;
        if (DataLoader.ReadStreamFile(BasePath + assocpath, out assoc))
        {
            for (int ass = 0; ass <= 63; ass++)
            {
                int FileID = (int)DataLoader.getValAtAddress(assoc, AssocAddressPtr++, 8);
                int auxPal = (int)DataLoader.getValAtAddress(assoc, AssocAddressPtr++, 8);
                if (ass == CritterToLoad)
                {
                    critter = new CritterInfo(FileID, GameWorldController.instance.palLoader.Palettes[0], auxPal);
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
						//Debug.Log("Unable to find animation frame " + AnimToFind);
						return null;
				}

		}


		void ReadUW2AssocFile(int CritterToLoad)
		{
				char[] assoc;
				char[] pgmp;
				char[] cran;
				//Load the assoc file
				long AssocAddressPtr=0;
				if  ( 
						( DataLoader.ReadStreamFile(BasePath + "CRIT" + sep + "AS.AN", out assoc) ) 
						&& ( DataLoader.ReadStreamFile(BasePath + "CRIT" + sep + "PG.MP", out pgmp) ) 
						&& ( DataLoader.ReadStreamFile(BasePath + "CRIT" + sep + "CR.AN", out cran) )  
				)
				{
						for (int ass = 0 ; ass <=63 ; ass++)
						{
								int FileID= (int)DataLoader.getValAtAddress(assoc,AssocAddressPtr++,8);
								int auxPal = (int)DataLoader.getValAtAddress(assoc,AssocAddressPtr++,8);
								if (FileID!=255)
								{
										if (ass==CritterToLoad)
										{
												critter= new CritterInfo(FileID, GameWorldController.instance.palLoader.Palettes[0], auxPal, assoc, pgmp, cran);			
										}
								}
						}
				}
		}
}
