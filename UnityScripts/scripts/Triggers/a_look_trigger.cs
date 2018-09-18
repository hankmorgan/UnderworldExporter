using UnityEngine;
using System.Collections;

public class a_look_trigger : trigger_base {

    /*
    Special kind of trigger that fires when the player looks at object linked to it.
    Only a limited number of objects support this behaviour. Eg magic orbs, TMAPs
    */

    //TODO: this trigger sometimes uses the search skill (eg hidden switch on level 2 of brittania)
    //This is controlled by the zpos of the trap.  if Search + 13(?) >= zpos  then trigger trap
    //in vanilla this is a dice roll. Here it is not.
    public override bool Activate(GameObject src)
    {
        if (zpos>0)
        {
            if (UWCharacter.Instance.PlayerSkills.GetSkill(Skills.SkillSearch) + 13 < zpos)
            {
                Debug.Log("unable to activate look trigger due to skills");
                return false;
            }            
        }
        return base.Activate(src);
    }
}
