using UnityEngine;
using System.Collections;

public class Impact : UWEBase {
	/*
	 * Impact.cs
	 * 
	 *  Class for things like blood splatters, spell explosion animations
	 * 
	 * 
	 */

	void Start () {
		//Make sure the impact is always facing the player.		
		if (this.gameObject.GetComponent<Billboard>()==null)
		{
			this.gameObject.AddComponent<Billboard>();
		}
	}

	public void go(int StartFrame, int EndFrame)
	{//Start the animation.
		StartCoroutine(Animate(StartFrame, EndFrame));
	}

	void LoadAnimo(int index)
	{
		//Load the image into a sprite renderer
		//Make sure the sprite renderer exists
		SpriteRenderer image = this.gameObject.GetComponent<SpriteRenderer>();
		if (image==null)
		{
			image = this.gameObject.AddComponent<SpriteRenderer>();
		}
		image.sprite=Resources.Load<Sprite>(_RES +"/Sprites/Animo/animo_" + index.ToString ("D4"));
	}

	public IEnumerator Animate(int StartFrame, int EndFrame)
	{//Loop throught the animation frames from StartFrame to EndFrame in order one time.
		bool Active=true;
		LoadAnimo (StartFrame);
		while (Active==true)
		{
			yield return new WaitForSeconds(0.2f);
			StartFrame++;
			if (StartFrame>=EndFrame)
			{
				Active=false;
				Destroy (this.gameObject);
			}
			else
			{//Loads the next animation frame
				LoadAnimo (StartFrame);
			}
		}		
	}
}