using UnityEngine;
using System.Collections;

public class ComputerScreen : MonoBehaviour {

	public int ScreenStart;
	public int NoOfFrames;
	public bool LoopFrames;
	//private SpriteRenderer sc;
	private float AnimationTime;
	public float animationFrameTime= 0.5f;
	private float NextFrame;
	public int CurrFrame=0;
	private short Direction = +1;
	public GameObject ScreenToDisplayOn;
	//public string CurrentArt;

	Material[] myMat;

	// Use this for initialization
	void Start () {
		//sc=this.GetComponentInChildren<SpriteRenderer>();
		NextFrame=animationFrameTime;
		//ScreenToDisplayOn= GameObject.Find (this.name+"_quad");
		myMat = ScreenToDisplayOn.renderer.materials;
		setSprite(0);
	}
	
	// Update is called once per frame
	void Update () {
		AnimationTime = AnimationTime+Time.deltaTime;
		if (AnimationTime>=NextFrame)
			{
			AnimationTime =0;
			setSprite(CurrFrame + Direction);
			CurrFrame +=Direction;
			if ((Direction == + 1 ) && (CurrFrame>= NoOfFrames))
				{
					Direction = -1;
				}
			if ((Direction == -1 ) && (CurrFrame<= 0))
				{
					Direction= 1;
				}

			}

	}

	void setSprite(int index)
	{
		Texture2D Image=new Texture2D(64,64);
		Image=Resources.Load <Texture2D> ("Screen/" + (ScreenStart+index+321).ToString ("D4"));
		//CurrentArt="Screen/" + (ScreenStart+index+321).ToString ("D4");
		//Debug.Log ("Screen/" + (ScreenStart+index).ToString ("D4"));
		//sc.sprite=Image;
		for (int i = 0; i<=myMat.GetUpperBound(0);i++)
		{
			//Debug.Log (myMat[i].name);
			myMat[i].mainTexture=Image;
		}
	}


}
