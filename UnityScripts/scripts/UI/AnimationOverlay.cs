using UnityEngine;
using System.Collections;

public class AnimationOverlay : UWEBase {
    /*
    Animation overlay for special objects (eg water fountain sprays) that have animated frames.

        The animation overlay blocks in UW1 and the animation overlay data 
        at the end of the tilemap in UW2 controls the behaviour of these.
        The overlays point to the index of the animated item and sets the number of frames left to play

        Per UWformats.txt and my derived research
            4.5  Animation infos
               This block contains entries with length of 6 bytes with infos about
               objects with animation overlay images from "animo.gr".
               It always is 0x0180 bytes long which leads to 64 entries.   
               IN UW2 this is located right at the end of the tilemap block rather than a seperate block like uw1
               0000   Int16   link1 (bits 6-15) The remaining bits are unknown but are possibly related to enabling the effect?
               0002   Int16   No of remaining frames to play. FF FF = loop forever.
               0004   Int8    tile x coordinate
               0005   Int8    tile y coordinate
               link1's most significant 10 bits contain a link into the master object
               list, to the object that should get an animation overlay.
	 */
    public int StartFrame=0;
	public int FrameNo =0;
	public int NoOfFrames=5;
	public bool Active=true;
	SpriteRenderer image;
    public int OverlayIndex=0;
    public int StartingDuration = 65535;

    public int Duration
    {
        get
        {
            return CurrentTileMap().Overlays[OverlayIndex].duration;
        }
        set
        {
            CurrentTileMap().Overlays[OverlayIndex].duration = value;
        }
    }

	public bool Looping  //=true;//TODO: Make this refer to the animation overlay control
    {
        get
        {
           if (OverlayIndex!=0)
            {
                if (CurrentTileMap().Overlays[OverlayIndex].duration<65535)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
           else
            {
               // Debug.Log("No overlay found for this " + name);
                return true;
            }
        }
    }


    public static int CreateOverlayEntry(int link, int tileX, int tileY, int duration)
    {
        TileMap.Overlay[] overlays = CurrentTileMap().Overlays;
        for (int i = 0; i <= overlays.GetUpperBound(0); i++)
        {
        if ( overlays[i].link == 0)
            {
                overlays[i].link = link;
                overlays[i].tileX = tileX;
                overlays[i].tileY = tileY;
                overlays[i].duration = duration;
                return i;
            }
        }
        Debug.Log("Unable to create overlay control!");
        return 0;
    }

	// Use this for initialization
	void Start () {
        TileMap.Overlay[] overlays = CurrentTileMap().Overlays;
        int thislink = this.GetComponent<ObjectInteraction>().objectloaderinfo.index;
        for (int i=0; i<=overlays.GetUpperBound(0);i++)
        {
            if (overlays[i].link == thislink)
            {
                OverlayIndex = i;
                break;
            }
        }
        if (OverlayIndex==0)
        {
            OverlayIndex = CreateOverlayEntry(thislink, this.GetComponent<ObjectInteraction>().ObjectTileX, this.GetComponent<ObjectInteraction>().ObjectTileY, StartingDuration);
        }
		image = this.gameObject.GetComponentInChildren<SpriteRenderer>();
	
		Go ();
	}

	public void Go()
	{
		FrameNo=StartFrame;
        LoadAnimo(StartFrame);
        StartCoroutine (Animate());
	}

	public void Stop()
	{
		Active=false;
	}

	void LoadAnimo(int index)
	{
		if (image==null)
		{
			image = this.gameObject.GetComponentInChildren<SpriteRenderer>();
		}

        if (image!=null)
            {
                image.sprite = GameWorldController.instance.TmAnimo.RequestSprite(index);//sprites[index];
            }
		
	}
	
	public IEnumerator Animate()
	{//Note is it likely that the owner value in the object is the animation frame we are on.
        LoadAnimo (FrameNo);
		//the count down of the sad butterfly like existance of an impact.
		while (Active==true)
		{
			yield return new WaitForSeconds(0.2f);
			if (Active==false)
			{
				yield break;
			}
			FrameNo++;
            if (!Looping)
            {
                Duration--;
                if (Duration <= 0)
                {
                    EndAnimation();
                }
            }  
			if (FrameNo>=StartFrame+NoOfFrames)
			{
				if (Looping==true)
				{
					FrameNo=StartFrame;
					LoadAnimo (FrameNo);	
				}
				else
                {
                    EndAnimation();
                }
            }
			else
			{//Loads the next animation fram;
				LoadAnimo (FrameNo);
			}
		}
	}

    private void EndAnimation()
    {
        CurrentTileMap().Overlays[OverlayIndex] = new TileMap.Overlay();//Clear the overlay from the list.
        if (this.GetComponent<ObjectInteraction>() != null)
        {
            this.GetComponent<ObjectInteraction>().objectloaderinfo.InUseFlag = 0;//Free up the slot
            Destroy(this.gameObject);
        }
    }
}
