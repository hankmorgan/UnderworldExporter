using UnityEngine;
using System.Collections;

/// <summary>
/// Controls what world the gem will send the player to.
/// </summary>
public class a_hack_trap_gemrotate : a_hack_trap
{
    //Linked from a timer trigger at index 1000

    //This has a quality of 54d

    //Changes variable no 6 to set what is reachable. 
    int prevWorld = -1;
    public static LargeBlackrockGem gem;

    protected override void Start()
    {
        base.Start();
        if (gem == null)
        {
            gem = FindObjectOfType<LargeBlackrockGem>();
        }
        UpdateGemFace();
    }

    /// <summary>
    /// Executes the trap.
    /// </summary>
    /// <param name="src">Source.</param>
    /// <param name="triggerX">Trigger x.</param>
    /// <param name="triggerY">Trigger y.</param>
    /// <param name="State">State.</param>
    /// Toggles the variable controlling which world is available from this facet of the gem.
    /// In the future change the lighting on the gem.
    public override void ExecuteTrap(object_base src, int triggerX, int triggerY, int State)
    {
        Quest.instance.variables[6]++;
        if (Quest.instance.variables[6] > a_hack_trap_teleport.NoOfWorlds)
        {
            Quest.instance.variables[6] = 0;
        }

        if (prevWorld != Quest.instance.variables[6])
        {
            Debug.Log("Now serving world " + Quest.instance.variables[6]);
        }
        UpdateGemFace();

        prevWorld = Quest.instance.variables[6];
    }

    /// <summary>
    /// Change the face colour
    /// </summary>
    void UpdateGemFace()
    {
        if (gem != null)
        {
            if (gem.GetComponent<MeshRenderer>() != null)
            {
                for (int i = 0; i <= 7; i++)
                {
                    if (i == Quest.instance.variables[6])
                    {
                        gem.GetComponent<MeshRenderer>().materials[i].SetColor("_Color", Color.white);
                    }
                    else
                    {
                        gem.GetComponent<MeshRenderer>().materials[i].SetColor("_Color", Color.blue);
                    }
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
