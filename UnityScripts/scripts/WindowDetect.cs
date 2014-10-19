using UnityEngine;
using System.Collections;

public class WindowDetect : MonoBehaviour {
	//private UILabel MessageLog;
	//public int InteractionMode;
	UWCharacter playerUW;
	PlayerInventory pInv;
	public bool ThrowArea;
	// Use this for initialization
	void Start () {
		//MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
		playerUW=GameObject.Find ("Gronk").GetComponent <UWCharacter>();
		pInv=GameObject.Find ("Gronk").GetComponent <PlayerInventory>();
	}

	
	// Update is called once per frame
	void Update () {
	
	}

	void OnHover( bool isOver )
	{
		if( isOver )
		{
			playerUW.CursorInMainWindow=true;
			//MessageLog.text=name + "over window";
		}
		else
		{
			playerUW.AttackCharging=0;
			playerUW.Charge=0;
			playerUW.CursorInMainWindow=false;
			//MessageLog.text="unHover window";
		}
	}

	void OnClick()
	{
		if (pInv.ObjectInHand!="")
			{
			if (pInv.JustPickedup==false)
				{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit = new RaycastHit(); 
				float dropRange=0.5f;
				if (!Physics.Raycast(ray,out hit,dropRange))
				{//No object interferes with the drop
						//Debug.Log ("heave ho " + pInv.ObjectInHand);
					float force = Input.mousePosition.x/Camera.main.pixelHeight *200;
						Debug.Log ("throw force is " + force);
						GameObject droppedItem = GameObject.Find(pInv.ObjectInHand);
						droppedItem.transform.parent=null;
						droppedItem.transform.position=ray.GetPoint(dropRange);//playerUW.transform.position;
						Vector3 ThrowDir = ray.GetPoint(dropRange) - pInv.transform.position;
						droppedItem.rigidbody.AddForce(ThrowDir*force);
						playerUW.CursorIcon= playerUW.CursorIconDefault;
						playerUW.CurrObjectSprite = "";
						pInv.ObjectInHand="";
				}

				else
					{
					Debug.Log ("not enough room to drop");
					}
				}
			else
			{
				//Debug.Log ("wait a mo before droppiing" + pInv.ObjectInHand);
				pInv.JustPickedup=false;
			}
				//try and drop the item in the world

			}
	}
}
