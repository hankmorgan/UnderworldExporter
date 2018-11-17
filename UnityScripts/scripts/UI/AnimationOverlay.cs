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
               0000   Int16   link1 (first 10 bits) The remaining bits are unknown but are possibly related to enabling the effect?
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

	public bool Looping=true;//TODO: Make this refer to the animation overlay control
	// Use this for initialization
	void Start () {
		image = this.gameObject.GetComponentInChildren<SpriteRenderer>();
	
		Go ();
	}

	public void Go()
	{
		FrameNo=StartFrame;
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
			if (FrameNo>=StartFrame+NoOfFrames)
			{
				if (Looping==true)
				{
					FrameNo=StartFrame;
					LoadAnimo (FrameNo);	
				}
				else
				{
					if (this.GetComponent<ObjectInteraction>()!=null)	
					{
						this.GetComponent<ObjectInteraction>().objectloaderinfo.InUseFlag=0;//Free up the slot
						Destroy (this.gameObject);
					}
				}
			}
			else
			{//Loads the next animation fram;
				LoadAnimo (FrameNo);
			}
		}
	}
}
