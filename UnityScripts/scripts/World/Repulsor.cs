using UnityEngine;
using System.Collections;

public class Repulsor : MonoBehaviour {

	public bool RepulsorOn;
	public bool PlayerInside;
	public float TargetHeight;
	public Vector3 TargetPos;
	public bool PlayerStillInside;
	public Collider play;
	public float TravelSpeed=1.0f;
	public Vector3 StartPos;
	public Vector3 EndPos ;
	public float index;
	// Use this for initialization
	void Start () {
		TargetPos = this.transform.position;
		CalcTargetZ();
		play = GameObject.Find ("Gronk").GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
	if (PlayerStillInside==true)
		{
			PlayerStillInside=false;
			StartMove ();
		}
	}


	void Activate()
	{//Switches repulsor on/off 
		RepulsorOn= !RepulsorOn;
		if(PlayerInside==true)
			{
			//do something here to restart?
			Debug.Log("Cancelling");
			StopCoroutine("MovePlayer");
			StartMove ();
			}
	}

	private void CalcTargetZ()
	{
		if (RepulsorOn==true)
		{//move up
			Vector3 displacement = new Vector3(0.0f,TargetHeight*1.2f,0.0f);
			TargetPos = this.transform.position + displacement;
		}
		else
		{
			TargetPos = this.transform.position;
		}
	}

	//void MovePlayer(GameObject player)
	IEnumerator MovePlayer(GameObject player, Vector3 dist, float traveltime)
	{
		//Debug.Log ("Travel time is " + traveltime);

		float rate = 1.0f/traveltime;
		index = 0.0f;
		StartPos = player.transform.position;
		EndPos = StartPos + dist;
		while (StartPos.y != EndPos.y)
		{
			if ((PlayerInside==true))
			{
				Vector3 nextPosition =  new Vector3(player.transform.position.x,Mathf.Lerp (StartPos.y,EndPos.y,index),player.transform.position.z);
				player.transform.position=nextPosition;
				//player.transform.position=Vector3.MoveTowards(player.transform.position,EndPos,step);
				index += rate * Time.deltaTime;
				//Debug.Log (index);
				//WaitForSeconds(0.1f);
				//yield return new WaitForSeconds (0.1f);
				yield return new WaitForSeconds(0.01f);
			}
			else
			{
				return true;
			}
		}
		if (PlayerInside==true)
		{//Player is still in the collider so start again.
			PlayerStillInside=true;
		}
	}

	void StartMove()
	{
		CalcTargetZ();
		float traveltime =Mathf.Abs(play.transform.position.y - TargetPos.y) *  TravelSpeed;
		if(RepulsorOn==false)
		{
			traveltime=traveltime*4;
		}
		StartCoroutine(MovePlayer (play.gameObject, TargetPos-play.transform.position, traveltime));
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.name=="Gronk")
		{
			PlayerInside=true;
			//play=other;
			StartMove ();
		}
	}

	void OnTriggerExit(Collider other)
	{
			if (other.name=="Gronk")
			{
				play=other;
				PlayerInside=false;
				PlayerStillInside=false;
			}
	}
}
