using UnityEngine;
using System.Collections;

public class Eyes : MonoBehaviour {

	public int EyeIndex;
	private int PreviousEyeIndex=-1;

	// Use this for initialization
	void Start () {
		InvokeRepeating("Cycle",0.0f,1.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
		if (EyeIndex!=PreviousEyeIndex)
		{
			this.GetComponent<UITexture>().mainTexture=Resources.Load <Texture2D> ("HUD/Eyes/Eyes_"+ EyeIndex.ToString("0000"));
		}
	}

	void Cycle()
	{
		if (EyeIndex >10)
		{
			EyeIndex=0;
		}
		else
		{
			EyeIndex++;
		}

	}
}
