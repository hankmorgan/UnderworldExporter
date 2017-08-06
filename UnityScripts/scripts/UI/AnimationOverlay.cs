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
	static Sprite[] sprites=new Sprite[53];
	static bool spriteSet = false;
	public bool Looping=true;
	// Use this for initialization
	void Start () {
		image = this.gameObject.GetComponentInChildren<SpriteRenderer>();
		if (spriteSet==false)
		{
			spriteSet=true;
			for (int i = 0; i<=sprites.GetUpperBound(0);i++)
			{
				//sprites[i]=Resources.Load<Sprite>(_RES +"/Sprites/Animo/animo_" + i.ToString ("D4"));
				sprites[i] = GameWorldController.instance.TmAnimo.RequestSprite(i);
			}
		}
		
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
	//	image.sprite=Resources.Load<Sprite>(_RES +"/Sprites/Animo/animo_" + index.ToString ("D4"));
		image.sprite=sprites[index];
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
