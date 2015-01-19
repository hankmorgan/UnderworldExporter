using UnityEngine;
using System.Collections;

public class ComputerScreen : MonoBehaviour {

	public int ScreenStart;
	public int NoOfFrames;
	public bool LoopFrames;
	private SpriteRenderer sc;
	private float AnimationTime;
	public float animationFrameTime= 0.5f;
	private float NextFrame;
	public int CurrFrame=0;
	private short Direction = +1;
	// Use this for initialization
	void Start () {
		sc=this.GetComponentInChildren<SpriteRenderer>();
		NextFrame=animationFrameTime;
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
		Sprite Image=new Sprite();
		Image=Resources.Load <Sprite> ("Screen/" + (ScreenStart+index).ToString ("D4"));
		//Debug.Log ("Screen/" + (ScreenStart+index).ToString ("D4"));
		sc.sprite=Image;
	}


}
