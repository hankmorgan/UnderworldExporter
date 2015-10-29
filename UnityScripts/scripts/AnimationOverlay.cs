using UnityEngine;
using System.Collections;

public class AnimationOverlay : MonoBehaviour {

	//private SpriteRenderer image;
	public int StartFrame=0;
	public int FrameNo =0;
	public int NoOfFrames=5;
	public bool Active=true;
	SpriteRenderer image;
	// Use this for initialization
	void Start () {
		image = this.gameObject.GetComponentInChildren<SpriteRenderer>();
		//LoadAnimo(FrameNo);
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
		image.sprite=Resources.Load<Sprite>("Sprites/Animo/animo_" + index.ToString ("D4"));
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
