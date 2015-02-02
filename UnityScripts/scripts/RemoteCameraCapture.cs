using UnityEngine;
using System.Collections;

public class RemoteCameraCapture : MonoBehaviour {

	public Texture2D RenderedImage;
	public int FrameInterval=100;
	private int FrameIntervalCounter=100;
	public Camera cam;
	public bool camEnabled=true;
	Texture2D captured;

	// Use this for initialization
	void Start () {
		captured = new Texture2D (Screen.width, Screen.height);
		cam = this.GetComponent<Camera>();
		if (cam==null)
		{
			cam=this.gameObject.AddComponent<Camera>();
		}
		cam.depth=-10;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnPostRender()
	{
		//Debug.Log ("Onpostrender");
		//if (ScreenToDisplayOn!=null)
		//{
		//SpriteRenderer SR = ScreenToDisplayOn.GetComponent<SpriteRenderer>();
		//if (SR!=null)
		//{
		if (camEnabled==true)
			{
				//camEnabled=false;//Limit capture to one time only for memory reasons.
			
				FrameIntervalCounter++;
				if (FrameIntervalCounter>=FrameInterval)
				{
					FrameIntervalCounter=0;
					#pragma warning disable
					RenderedImage=CaptureImage(cam,Screen.width,Screen.height);
					#pragma warning restore
				}
			}
		
		//Sprite newSprite= Sprite.Create( RenderedImage,new Rect(0,0,RenderedImage.width,RenderedImage.height), new Vector2(0.5f, 0.5f));
		//SR.sprite= newSprite;
		//}
		//	}
	}




	/*Source: http://raypendergraph.wikidot.com/codesnippet:capturing-a-camera-image-in-unity*/
	public Texture2D CaptureImage (Camera camera, int width, int height)
	{
		//Debug.Log ("Capturing");
		//captured = new Texture2D (width, height);
		camera.Render();
		RenderTexture.active = camera.targetTexture;
		captured.ReadPixels(new Rect(0,0,width,height),0,0);
		captured.Apply();
		RenderTexture.active = null;
		return captured;
	}

}
