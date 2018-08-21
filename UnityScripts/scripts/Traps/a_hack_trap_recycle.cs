using UnityEngine;
using System.Collections;

public class a_hack_trap_recycle : a_hack_trap
{
    //Recycles empty bottles into gold coins.
    public override void ExecuteTrap(object_base src, int triggerX, int triggerY, int State)
    {
        Vector3 ContactArea = new Vector3(0.59f, 0.15f, 0.59f);
        Collider[] colliders = Physics.OverlapBox(CurrentTileMap().getTileVector(ObjectTileX, ObjectTileY), ContactArea);
        for (int i = 0; i <= colliders.GetUpperBound(0); i++)
        {
            if (colliders[i].gameObject.GetComponent<ObjectInteraction>() != null)
            {
                if (
                    (colliders[i].gameObject.GetComponent<ObjectInteraction>().item_id == 317) //a bottle
                )
                {
                    object_base bottle = colliders[i].gameObject.GetComponent<object_base>();
                    Destroy(bottle);
                    colliders[i].gameObject.AddComponent<Coin>();
                    colliders[i].gameObject.GetComponent<ObjectInteraction>().ChangeType(160);
                }
            }
        }
    }

    public override void PostActivate(object_base src)
    {
        Debug.Log("Overridden PostActivate to test " + this.name);
        base.PostActivate(src);
    }
}
