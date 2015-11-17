using UnityEngine;
using System.Collections;

public class TMAP : object_base {


	public static TextureController tc;
	public string trigger;
	public int TextureIndex;
	private SpriteRenderer sr;
	//public bool isAnimated;
	//private bool HasUpdated;

	// Use this for initialization
	void Start () {
		base.Start ();
		//isAnimated=true;
		//InitAnimation();
	}
	/*
	void InitAnimation()
	{
		sr=this.GetComponentInChildren<SpriteRenderer>();
		if (sr!=null)
		{
			sr.gameObject.transform.localScale=new Vector3(1.875f,1.875f,1.0f);
			if (isAnimated)
			{
				//InvokeRepeating ("UpdateAnimation",0.0f,0.2f);
			}
			else
			{
				//UpdateAnimation();
			}
		}
	}*/

	/*
	void UpdateAnimation()
	{

		HasUpdated=true;
		if (sr==null)
		{
			sr=this.GetComponentInChildren<SpriteRenderer>();
			sr.gameObject.transform.localScale=new Vector3(1.875f,1.875f,1.0f);
		}
		if (tc==null)
		{
			tc = GameObject.Find ("TextureController").GetComponent<TextureController>();
		}
		Texture2D tx = tc.RequestTexture(TextureIndex,isAnimated);
		//tx.wrapMode=TextureWrapMode.Clamp;

		sr.sprite = Sprite.Create(tx,new Rect(0.0f,0.0f,tx.width ,tx.height), new Vector2(0.5f, 0.0f));

	}*/



	// Update is called once per frame
	/*void Update () {
		if ((HasUpdated==false) && (IsInvoking("UpdateAnimation")==false))
		{
			if (isAnimated==true)
			{
				//InvokeRepeating ("UpdateAnimation",0.0f,0.2f);
			}
			else
			{
				//UpdateAnimation();
			}

		}
	}*/

	public override bool LookAt()
	{
		if (trigger != "")
		{
			ObjectInteraction objIntTrigger = GameObject.Find (trigger).GetComponent<ObjectInteraction>();
			if ( (objIntTrigger.ItemType==ObjectInteraction.A_LOOK_TRIGGER)
			    || 
			    (objIntTrigger.ItemType==ObjectInteraction.A_USE_TRIGGER)
			    )
				{
				objIntTrigger.Use ();
				return true;
				}

		}
		ml.text= playerUW.StringControl.TextureDescription(TextureIndex);
		return true;

	}

	public override bool use()
	{
		if (playerUW.playerInventory.ObjectInHand=="")
		{
			if (trigger != "")
			{
				ObjectInteraction triggerInt = GameObject.Find (trigger).GetComponent<ObjectInteraction>();
				triggerInt.Use();
			}
			return true;
		}
		else
		{
			return ActivateByObject(playerUW.playerInventory.GetGameObjectInHand());
		}
	}
}
