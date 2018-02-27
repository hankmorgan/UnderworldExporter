using UnityEngine;
using System.Collections;

public class Feet : UWEBase {
	//For a game object attached to the player. Detects if the player is in contact with the ground.

		//BoxCollider bx;
		//public Collider[] colliders;
	//public TileMap tm;
	public float currY;
	public float fallSpeed;
		/*int waterLayer;
	int landLayer;
	int lavaLayer;
	int iceLayer;


	void Start()
	{
		bx=this.GetComponent<BoxCollider>();
		waterLayer=LayerMask.NameToLayer("Water");
		landLayer=LayerMask.NameToLayer("MapMesh");
		lavaLayer=LayerMask.NameToLayer("Lava");
		iceLayer=LayerMask.NameToLayer("Ice");
	}

		/*void OnTriggerEnter(Collider other)
		{
				if (
						(other.gameObject.layer== landLayer)
						||
						(other.gameObject.layer==waterLayer)
						||
						(other.gameObject.layer==lavaLayer)
						||
						(other.gameObject.layer==iceLayer)
				)
				{
						//TileMap.OnGround=true;
						UWCharacter.Instance.Grounded=true;
				}	
		}


	void OnTriggerStay(Collider other) {

				if (
						(other.gameObject.layer== landLayer)
						||
						(other.gameObject.layer==waterLayer)
						||
						(other.gameObject.layer==lavaLayer)
						||
						(other.gameObject.layer==iceLayer)
				)
				{
						//TileMap.OnGround=true;
						UWCharacter.Instance.Grounded=true;
				}

				/*
		//UWCharacter.Instance.currRegion=other.gameObject.tag;
		if (other.gameObject.layer==landLayer)
		{
			TileMap.OnGround=true; 
		}
		else
		{
			if (other.gameObject.layer==waterLayer)
			{
				if (TileMap.OnWater==false)
				{
					UWCharacter.Instance.aud.clip=GameWorldController.instance.getMus().SoundEffects[MusicController.SOUND_EFFECT_WATER_LAND_1];
					UWCharacter.Instance.aud.Play();
				}
				TileMap.OnWater=true;
				TileMap.OnIce=false;
			}
			else 
			{
				if (other.gameObject.layer==lavaLayer)
				{
					TileMap.OnGround=true;  
					TileMap.OnLava=true;
				}
				if (other.gameObject.layer==iceLayer)
				{
					TileMap.OnGround=true;  
					TileMap.OnIce=true;
				}
			}
		}*/
	//}

	/*void OnTriggerExit(Collider other) {
				if (
						(other.gameObject.layer== landLayer)
						||
						(other.gameObject.layer==waterLayer)
						||
						(other.gameObject.layer==lavaLayer)
						||
						(other.gameObject.layer==iceLayer)
				)
				{
						//TileMap.OnGround=false;

					/*	colliders= Physics.OverlapBox(this.transform.position, bx.size);
						for (int i=0; i<=colliders.GetUpperBound(0);i++)
						{								
								Collider col = colliders[i];
								if (
										(col.gameObject.layer== landLayer)
										||
										(col.gameObject.layer==waterLayer)
										||
										(col.gameObject.layer==lavaLayer)
										||
										(col.gameObject.layer==iceLayer)
								)
								{
									UWCharacter.Instance.Grounded=true;
										return;
								}
						}*/

						//UWCharacter.Instance.Grounded=false;
				//}


	/*  if (other.gameObject.layer==landLayer)
		{
			TileMap.OnGround=false;  
		}
		else
		{
			if (other.gameObject.layer==waterLayer)
			{
				TileMap.OnWater=false;
			}
			else 
			{
				if (other.gameObject.layer==lavaLayer)
				{
					TileMap.OnGround=false;
					TileMap.OnLava=false;					
				}
				if (other.gameObject.layer==iceLayer)
				{
						TileMap.OnGround=false;
						TileMap.OnIce=false;					
				}
			}
		}*/
	//}

	void Update()
	{//http://forum.unity3d.com/threads/fall-damage-question.46101/
		//onGround = TileMap.OnGround;
		//veloY = UWCharacter.Instance.playerMotor.movement.velocity.y;
	//	if (TileMap.OnGround==false)
		//UWCharacter.Instance.Grounded=CheckIsGrounded();
		if (UWCharacter.Instance.Grounded==false)
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
				//GameWorldController.instance.PositionDetect();//check where I am.
				UWCharacter.Instance.onLanding(fallSpeed);
				fallSpeed=0.0f;
			}
		}
		currY =UWCharacter.Instance.playerMotor.movement.velocity.y;
	}
		/*
		public bool CheckIsGrounded()
		{
			colliders= Physics.OverlapBox(this.transform.position, bx.size);
			for (int i=0; i<=colliders.GetUpperBound(0);i++)
			{								
					Collider col = colliders[i];
					if (
							(col.gameObject.layer== landLayer)
							||
							(col.gameObject.layer==waterLayer)
							||
							(col.gameObject.layer==lavaLayer)
							||
							(col.gameObject.layer==iceLayer)
					)
					{
						return true;
					}
			}
			return false;
		}
		*/
}
