using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

/// <summary>
/// Special move trigger to handle throwing objects into the lava in the Shrine.
/// </summary>
public class ShrineLava : UWEBase {

		void OnTriggerEnter(Collider other)
		{
				if (other.gameObject.GetComponent<ObjectInteraction>()!=null)
				{
						ObjectInteraction objInt = other.gameObject.GetComponent<ObjectInteraction>();
						switch (objInt.item_id)
						{
						case Quest.TalismanBanner:
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

						GameObject hitimpact = new GameObject(objInt.transform.name + "_impact");
						hitimpact.transform.position=objInt.transform.position;
						hitimpact.transform.parent = GameWorldController.instance.LevelMarker();
						Impact imp= hitimpact.AddComponent<Impact>();
						imp.go(40,4);	
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

		/// <summary>
		/// Sends the avatar into the ethereal void.
		/// </summary>
		/// <returns>The it avatar.</returns>
		IEnumerator SuckItAvatar()
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
		}
}
