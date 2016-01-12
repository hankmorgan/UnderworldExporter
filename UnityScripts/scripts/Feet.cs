using UnityEngine;
using System.Collections;

public class Feet : MonoBehaviour {
	//For a game object attached to the player. Detects if the player is in contact with the ground.

	public TileMap tm;
	public float currY;
	public float fallSpeed;
	//Rigidbody playerBody;
	//public bool onGround;
	//public float veloY;
	//void Start()
	//{
	//	playerBody=this.GetComponent<Rigidbody>();
	//}

	void OnTriggerStay(Collider other) {
		TileMap.OnGround=true;  
	}

	void OnTriggerExit(Collider other) {
		//Debug.Log ("Exit");
		TileMap.OnGround=false;
		tm.PositionDetect();
	}

	void Update()
	{//http://forum.unity3d.com/threads/fall-damage-question.46101/
		//onGround = TileMap.OnGround;
		//veloY = UWCharacter.Instance.playerMotor.movement.velocity.y;
		if (TileMap.OnGround==false)
		{
			if (UWCharacter.Instance.playerMotor.movement.velocity.y < currY)
			{
				fallSpeed= Mathf.Max(-UWCharacter.Instance.playerMotor.movement.velocity.y, fallSpeed);
				//UWCharacter.Instance.playerMotor.movement.velocity.y;
			}
			else
			{
				fallSpeed=0.0f;
			}
		}
		else
		{
			if (fallSpeed>0.0f)
			{
				//Check fall damage.
				tm.PositionDetect();//check where I am.
				//Debug.Log ("Fall @" + fallSpeed);
				UWCharacter.Instance.onLanding(fallSpeed);
				fallSpeed=0.0f;
			}
		}
		currY =UWCharacter.Instance.playerMotor.movement.velocity.y;
	}
}
