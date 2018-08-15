using UnityEngine;
using System.Collections;

public class AnimationOverlay : UWEBase {
	/*
Animation overlay for special objects (eg water fountain sprays) that have animated frames.
	 */
	public int StartFrame=0;
	public int FrameNo =0;
	public int NoOfFrames=5;
	public bool Active=true;
	SpriteRenderer image;

	public bool Looping=true;
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
