using UnityEngine;
using System.Collections;
/// <summary>
/// Class for things like blood splatters, spell explosion animations
/// </summary>
public class Impact : object_base {

	void Start () {
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

	public static void SpawnHitImpact(int Item_ID, Vector3 ImpactPosition, int StartFrame, int EndFrame)
	{
		ObjectLoaderInfo newobjt= ObjectLoader.newObject(Item_ID,40,StartFrame,1,256);
		ObjectInteraction objInt = ObjectInteraction.CreateNewObject(GameWorldController.instance.currentTileMap(),newobjt, GameWorldController.instance.LevelMarker().gameObject,ImpactPosition);
		objInt.GetComponent<AnimationOverlay>().Looping=false;

		///GameObject hitimpact = new GameObject(ImpactName);
		///hitimpact.transform.position=ImpactPosition;//ray.GetPoint(weaponRange/0.7f);
		///hitimpact.transform.parent = GameWorldController.instance.LevelMarker();
		//GameWorldController.MoveToWorld(hitimpact);
		//Impact imp= hitimpact.AddComponent<Impact>();
		//imp.go(StartFrame,EndFrame);
		//StartCoroutine( imp.Animate(StartFrame,EndFrame));		
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