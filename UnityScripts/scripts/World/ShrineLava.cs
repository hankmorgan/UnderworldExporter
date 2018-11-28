using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

/// <summary>
/// Special move trigger to handle throwing objects into the lava in the Shrine.
/// </summary>
public class ShrineLava : UWEBase
{

    /// <summary>
    /// Detects if a talisman has been thrown into the abyss lava trigger.
    /// </summary>
    /// <param name="other">Other.</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ObjectInteraction>() != null)
        {
            if (Quest.instance.isGaramonBuried == false)
            {
                return;
            }
            ObjectInteraction objInt = other.gameObject.GetComponent<ObjectInteraction>();
            switch (objInt.item_id)
            {
                case Quest.TalismanHonour:
                case Quest.TalismanBook:
                case Quest.TalismanCup:
                case Quest.TalismanRing:
                case Quest.TalismanShield:
                case Quest.TalismanSword:
                case Quest.TalismanTaper:
                case Quest.TalismanTaperLit:
                case Quest.TalismanWine:
                    Quest.instance.TalismansRemaining--;
                    break;
                default:
                    return;
            }

            Impact.SpawnHitImpact(Impact.ImpactMagic(), objInt.GetImpactPoint(), 40, 44);


            objInt.consumeObject();

            //Suck the avatar into the ethereal void.
            if (Quest.instance.TalismansRemaining <= 0)
            {
                StartCoroutine(SuckItAvatar());
            }
        }
    }

    /// <summary>
    /// Sends the avatar into the ethereal void.
    /// </summary>
    /// Spins the avatar and the slasher (specific object name) towards a newly spawned moongate.
    IEnumerator SuckItAvatar()
    {

        ObjectInteraction slasher = CurrentObjectList().objInfo[129].instance;//Assumes slasher will be at this index.
        Vector3 slasherPos = Vector3.zero;
        if (slasher != null)
        {
            slasherPos = slasher.transform.position;
        }

        //Spawn a moon gate at the center of the lava
        ObjectLoaderInfo newobjt = ObjectLoader.newObject(346, 0, 0, 0, 256);
        GameObject myObj = ObjectInteraction.CreateNewObject(CurrentTileMap(),
            newobjt,
            CurrentObjectList().objInfo,
            GameWorldController.instance.DynamicObjectMarker().gameObject,
            GameWorldController.instance.InventoryMarker.transform.position).gameObject;
        GameWorldController.MoveToWorld(myObj.GetComponent<ObjectInteraction>());
        myObj.transform.localPosition = this.transform.position + new Vector3(0.0f, 0.5f, 0.0f);

        //Suck the player and the slasher into the moon gate.
        Quaternion playerRot = UWCharacter.Instance.transform.rotation;
        Quaternion EndRot = new Quaternion(playerRot.x, playerRot.y, playerRot.z + 1.2f, playerRot.w);
        Vector3 StartPos = UWCharacter.Instance.transform.position;
        Vector3 EndPos = myObj.transform.localPosition;
        float rate = 1.0f / 2.0f;
        float index = 0.0f;
        while (index < 1.0f)
        {
            UWCharacter.Instance.transform.position = Vector3.Lerp(StartPos, EndPos, index);
            UWCharacter.Instance.transform.rotation = Quaternion.Lerp(playerRot, EndRot, index);
            if (slasher != null)
            {
                slasher.transform.position = Vector3.Lerp(slasherPos, EndPos, index);
            }
            index += rate * Time.deltaTime;
            yield return new WaitForSeconds(0.01f);
        }
        UWCharacter.Instance.transform.rotation = playerRot;
        GameWorldController.instance.SwitchLevel(8, 26, 24);//One way trip.
    }
}
