using UnityEngine;
using System.Collections;

public class RemoteCamera : MonoBehaviour {
	public GameObject ScreenToDisplayOn;
	public int X;
	public int Y;
	private Camera cam;
	// Use this for initialization
	void Start () {
		cam = this.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnPostRender()
	{
		if (ScreenToDisplayOn!=null)
		{
			SpriteRenderer SR = ScreenToDisplayOn.GetComponent<SpriteRenderer>();
			if (SR!=null)
			{
				Texture2D newTex=CaptureImage(cam,Screen.width,Screen.height);
				Sprite newSprite= Sprite.Create( newTex,new Rect(0,0,newTex.width,newTex.height), new Vector2(0.5f, 0.5f));
				SR.sprite= newSprite;
			}
		}
	}

	/*Source: http://raypendergraph.wikidot.com/codesnippet:capturing-a-camera-image-in-unity*/
	public Texture2D CaptureImage (Camera camera, int width, int height)
	{
		Texture2D captured = new Texture2D (width, height);
		camera.Render();
		RenderTexture.active = camera.targetTexture;
		captured.ReadPixels(new Rect(0,0,width,height),0,0);
		captured.Apply();
		RenderTexture.active = null;
		return captured;
	}
}
