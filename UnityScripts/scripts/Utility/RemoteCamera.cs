using UnityEngine;
using System.Collections;

public class RemoteCamera : MonoBehaviour {
	public GameObject ScreenToDisplayOn;
	//public int X;
	//public int Y;
	public RemoteCameraCapture cam;
	private int FrameInterval=30;
	private int FrameIntervalCounter=30;
	//public Texture2D RenderedImage;
	public string Target;
	private GameObject player;
	Material[] myMat;

	// Use this for initialization
	void Start () {
		GameObject TargetCamera= GameObject.Find (Target);
		if (TargetCamera!=null)
		{
			cam = TargetCamera.GetComponent<RemoteCameraCapture>();
			if (cam==null)
			{
				cam=TargetCamera.AddComponent<RemoteCameraCapture>();
			}
		}

		myMat = ScreenToDisplayOn.GetComponent<Renderer>().materials;
		player=UWCharacter.Instance.gameObject;//GameObject.Find ("Gronk");
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(player.transform.position,this.transform.position)<=3)
		    {
			cam.camEnabled=true;
			}
		else
			{
			cam.camEnabled=false;
			}
	
		//Material[] myMat = ScreenToDisplayOn.renderer.materials;
		//for (int i = 0; i<myMat.GetUpperBound(0);i++)
		//{
			//Debug.Log (myMat[i].name);
		//	myMat[i].mainTexture=RenderedImage;
		//}
		//RenderedImage=CaptureImage(cam,Screen.width,Screen.height);

		FrameIntervalCounter++;
		if (FrameIntervalCounter>=FrameInterval)
		{
			FrameIntervalCounter=0;
			for (int i = 0; i<=myMat.GetUpperBound(0);i++)
			{
				//Debug.Log (myMat[i].name);
				myMat[i].mainTexture=cam.RenderedImage;
			}
		}
	}


	//void OnPostRender()
	//{
	//	Debug.Log ("Onpostrender");
		//if (ScreenToDisplayOn!=null)
		//{
			//SpriteRenderer SR = ScreenToDisplayOn.GetComponent<SpriteRenderer>();
			//if (SR!=null)
		//{
		//#pragma warning disable
	//	RenderedImage=CaptureImage(cam,Screen.width,Screen.height);
		//#pragma warning restore


				//Sprite newSprite= Sprite.Create( RenderedImage,new Rect(0,0,RenderedImage.width,RenderedImage.height), new Vector2(0.5f, 0.5f));
				//SR.sprite= newSprite;
			//}
	//	}
	//}

	///*Source: http://raypendergraph.wikidot.com/codesnippet:capturing-a-camera-image-in-unity*/
	//public Texture2D CaptureImage (Camera camera, int width, int height)
	//{
	//	Debug.Log ("Capturing");
	//	Texture2D captured = new Texture2D (width, height);
	//	camera.Render();
	//	RenderTexture.active = camera.targetTexture;
	//	captured.ReadPixels(new Rect(0,0,width,height),0,0);
	//	captured.Apply();
	//	RenderTexture.active = null;
	//	return captured;
	//}
}
