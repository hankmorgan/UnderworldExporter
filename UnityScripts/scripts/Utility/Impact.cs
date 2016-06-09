using UnityEngine;
using System.Collections;

public class Impact : MonoBehaviour {
	//Class for things like blood splatters

	public int FrameNo =0;//How long the image lasts for.
	public int EndFrame=5;
	// Use this for initialization
	void Start () {
	if (this.gameObject.GetComponent<Billboard>()==null)
		{
			this.gameObject.AddComponent<Billboard>();
		}
	}

	void LoadAnimo(int index)
	{
		SpriteRenderer image = this.gameObject.GetComponent<SpriteRenderer>();
		if (image==null)
		{
			image = this.gameObject.AddComponent<SpriteRenderer>();
		}
		image.sprite=Resources.Load<Sprite>("Sprites/Animo/animo_" + index.ToString ("D4"));
	}

	public IEnumerator Animate()
	{
		bool Active=true;
		LoadAnimo (FrameNo);
		//the count down of the sad butterfly like existance of an impact.
		while (Active==true)
		{
			yield return new WaitForSeconds(0.2f);
			FrameNo++;
			if (FrameNo>=EndFrame)
			{
				Active=false;
			}
			else
			{//Loads the next animation fram;
				LoadAnimo (FrameNo);
			}
		}
		Destroy (this.gameObject);
	}
}