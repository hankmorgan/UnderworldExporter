using UnityEngine;
using System.Collections;
/// <summary>
/// Class for things like blood splatters, spell explosion animations
/// </summary>
public class Impact : object_base {
		

	protected override void Start () {
		base.Start();
		//Make sure the impact is always facing the player.		
		if (this.gameObject.GetComponent<Billboard>()==null)
		{
			this.gameObject.AddComponent<Billboard>();
		}
	}

	/// <summary>
	/// Plays an animation between the specified frames.
	/// </summary>
	/// <param name="StartFrame">Start frame.</param>
	/// <param name="EndFrame">End frame.</param>
	public void go(int StartFrame, int EndFrame)
	{//Start the animation.
		StartCoroutine(Animate(StartFrame, EndFrame));
	}

		/// <summary>
		/// Loads the animo sprites
		/// </summary>
		/// <param name="index">Index.</param>
	void LoadAnimo(int index)
	{
		//Load the image into a sprite renderer
		//Make sure the sprite renderer exists
		SpriteRenderer image = this.gameObject.GetComponent<SpriteRenderer>();
		if (image==null)
		{
			image = this.gameObject.AddComponent<SpriteRenderer>();
		}
		//image.sprite=Resources.Load<Sprite>(_RES +"/Sprites/Animo/animo_" + index.ToString ("D4"));

		image.sprite = GameWorldController.instance.TmAnimo.RequestSprite(index);
	}


		/// <summary>
		/// Animate between the specified StartFrame and EndFrame.
		/// </summary>
		/// <param name="StartFrame">Start frame.</param>
		/// <param name="EndFrame">End frame.</param>
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

	public static GameObject SpawnHitImpact(int Item_ID, Vector3 ImpactPosition, int StartFrame, int EndFrame)
	{
		ObjectLoaderInfo newobjt= ObjectLoader.newObject(Item_ID,40,StartFrame,1,256);
		ObjectInteraction objInt = ObjectInteraction.CreateNewObject(GameWorldController.instance.currentTileMap(),newobjt, GameWorldController.instance.LevelMarker().gameObject,ImpactPosition);
		objInt.GetComponent<AnimationOverlay>().Looping=false;
		objInt.GetComponent<AnimationOverlay>().StartFrame=StartFrame;
		objInt.GetComponent<AnimationOverlay>().NoOfFrames=EndFrame-StartFrame;
		return objInt.gameObject;
	}


	public static int ImpactBlood()
	{
		return 448;
	}


	public static int ImpactDamage()
	{
		return 459;
	}

	public static int ImpactMagic()
	{
		return 459;
	}

}