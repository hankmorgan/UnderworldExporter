using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Placeholding object_base to allow interacting with containers in the world
/// </summary>
public class container_obj : object_base {

    public override bool use()
    {
        return this.GetComponent<Container>().use();
    }


    public override float GetWeight()
    {
        return this.GetComponent<Container>().GetWeight(base.GetWeight());
    }


    public override string UseVerb()
    {
        return "open";
    }

    public override string UseObjectOnVerb_Inv()
    {
        return "place object in container";
    }


    public override bool DropEvent()
    {
        base.DropEvent();
        return this.GetComponent<Container>().DropEvent();
    }


    public override bool PickupEvent()
    {
        base.PickupEvent();
        return this.GetComponent<Container>().PickupEvent();
    }
}
