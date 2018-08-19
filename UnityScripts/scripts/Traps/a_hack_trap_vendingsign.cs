using UnityEngine;
using System.Collections;

/// <summary>
/// Used to control what is displayed on the sign at vending machines
/// </summary>
public class a_hack_trap_vendingsign : a_hack_trap
{
    public override void ExecuteTrap(object_base src, int triggerX, int triggerY, int State)
    {
        int ItemStringIndex = 0;
        int Price = 0;
        string ObjectName;

        switch (Quest.instance.variables[owner])
        {
            case 0://fish
                ItemStringIndex = 182;
                Price = 3;
                break;
            case 1://meat
                ItemStringIndex = 176;
                Price = 3;
                break;
            case 2://ale
                ItemStringIndex = 187;
                Price = 4;
                break;
            case 3://leeches
                ItemStringIndex = 293;
                Price = 4;
                break;
            case 4://water
                ItemStringIndex = 188;
                Price = 3;
                break;
            case 5://dagger
                ItemStringIndex = 3;
                Price = 11;
                break;
            case 6://lockpick
                ItemStringIndex = 257;
                Price = 6;
                break;
            case 7://torch
                ItemStringIndex = 145;
                Price = 4;
                break;
            default:
                return;
        }
        ObjectName = StringController.instance.GetSimpleObjectNameUW(ItemStringIndex);

        UWHUD.instance.MessageScroll.Add(
                StringController.instance.GetString(8, 369)
                +
                ObjectName
                +
                StringController.instance.GetString(1, 349)
                +
                "(" + Price + " gp)"
        );

    }

    public override void PostActivate(object_base src)
    {
        Debug.Log("Overridden PostActivate to test " + this.name);
        base.PostActivate(src);
    }
}
