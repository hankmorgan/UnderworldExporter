using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

/// <summary>
/// Special move trigger to handle throwing objects into the lava in the Shrine.
/// </summary>
public class ShrineLava : UWEBase {

		/// <summary>
		/// Detects if a talisman has been thrown into the abyss lava trigger.
		/// </summary>
		/// <param name="other">Other.</param>
		void OnTriggerEnter(Collider other)
		{
				if (other.gameObject.GetComponent<ObjectInteraction>()!=null)
				{
						ObjectInteraction objInt = other.gameObject.GetComponent<ObjectInteraction>();
						switch (objInt.item_id)
						{
						case Quest.TalismanHonour:
								GameWorldController.instance.playerUW.quest().TalismansCastIntoAbyss[0]=true;break;
						case Quest.TalismanBook:								
								GameWorldController.instance.playerUW.quest().TalismansCastIntoAbyss[1]=true;break;
						case Quest.TalismanCup:
								GameWorldController.instance.playerUW.quest().TalismansCastIntoAbyss[2]=true;break;
						case Quest.TalismanRing:
								GameWorldController.instance.playerUW.quest().TalismansCastIntoAbyss[3]=true;break;
						case Quest.TalismanShield:
								GameWorldController.instance.playerUW.quest().TalismansCastIntoAbyss[4]=true;break;
						case Quest.TalismanSword:
								GameWorldController.instance.playerUW.quest().TalismansCastIntoAbyss[5]=true;break;
						case Quest.TalismanTaper:
								GameWorldController.instance.playerUW.quest().TalismansCastIntoAbyss[6]=true;break;
						case Quest.TalismanWine:								
								GameWorldController.instance.playerUW.quest().TalismansCastIntoAbyss[7]=true;break;
						default:
								return;								
						}

						Impact.SpawnHitImpact(objInt.transform.name + "_impact",objInt.GetImpactPoint(),40,44);		


						objInt.consumeObject();

						for (int i=0;i<7;i++)
						{
								if (GameWorldController.instance.playerUW.quest().TalismansCastIntoAbyss[i]==false)
								{
										return;
								}
						}

						//Suck the avatar into the ethereal void.
						StartCoroutine(SuckItAvatar());

				}
		}


		/*IEnumerator SuckItAvatar()
		{
				Vortex vrtx = GameWorldController.instance.playerUW.playerCam.gameObject.AddComponent<Vortex>();
				vrtx.shader=GameWorldController.instance.vortex;
				vrtx.radius = new Vector2(1.0f,1.0f);
				vrtx.angle=0.0f;
				float rate = 1.0f/2.0f;
				float index = 0.0f;
				while (index <1.0f)
				{
						vrtx.angle= 1440.0f * index;
						index += rate * Time.deltaTime;
						yield return new WaitForSeconds(0.01f);
				}
				Destroy(vrtx);
				GameWorldController.instance.SwitchLevel(8);//One way trip.
		}*/

		/// <summary>
		/// Sends the avatar into the ethereal void.
		/// </summary>
		/// Spins the avatar and the slasher (specific object name) towards a newly spawned moongate.
		IEnumerator SuckItAvatar()
		{
				//Spawn a moon gate at the center of the lava
				GameObject slasher = GameObject.Find("slasher_of_veils_32_33_07_0129");
				Vector3 slasherPos=Vector3.zero;
				if (slasher!=null)
				{
						slasherPos=slasher.transform.position;
				}
				GameObject myInstance = Resources.Load("Models/MoonGate") as GameObject;
				GameObject newObj = (GameObject)GameObject.Instantiate(myInstance);		
				newObj.transform.parent=GameWorldController.instance.LevelMarker();
				GameWorldController.MoveToWorld(newObj);
				newObj.transform.localPosition=this.transform.position+new Vector3(0.0f,0.5f,0.0f);
				Quaternion playerRot = GameWorldController.instance.playerUW.transform.rotation;
				Quaternion EndRot = new Quaternion(playerRot.x,playerRot.y, playerRot.z+1.2f,playerRot.w);
				Vector3 StartPos = GameWorldController.instance.playerUW.transform.position;
				Vector3 EndPos = newObj.transform.localPosition;
				float rate = 1.0f/2.0f;
				float index = 0.0f;
				while (index <1.0f)
				{
						
						GameWorldController.instance.playerUW.transform.position=Vector3.Lerp(StartPos,EndPos,index);
						GameWorldController.instance.playerUW.transform.rotation=Quaternion.Lerp(playerRot,EndRot,index);
						if (slasher!=null)
						{
							slasher.transform.position=Vector3.Lerp(slasherPos,EndPos,index);	
						}
						index += rate * Time.deltaTime;
						yield return new WaitForSeconds(0.01f);

				}
				GameWorldController.instance.playerUW.transform.rotation = playerRot;
				GameWorldController.instance.SwitchLevel(8);//One way trip.
		}
}
