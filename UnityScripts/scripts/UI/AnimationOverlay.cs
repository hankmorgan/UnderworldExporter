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
	static Sprite[] sprites=new Sprite[64];
	static bool spriteSet = false;
	// Use this for initialization
	void Start () {
		image = this.gameObject.GetComponentInChildren<SpriteRenderer>();
		if (spriteSet==false)
		{
			spriteSet=true;
			for (int i = 0; i<=63;i++)
			{
				sprites[i]=Resources.Load<Sprite>(_RES +"/Sprites/Animo/animo_" + i.ToString ("D4"));
			}
		}

		Go ();
	}

	public void Go()
	{
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
	{

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
				FrameNo=StartFrame;
				LoadAnimo (FrameNo);
			}
			else
			{//Loads the next animation fram;
				LoadAnimo (FrameNo);
			}
		}
	}
}
