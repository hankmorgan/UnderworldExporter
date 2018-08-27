using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DjinnBottle : object_base {


    public override bool use()
    {
        //000~001~141~You are unable to remove the stopper. \n
        if (objInt().PickedUp)
        {
            UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, 141));
            return true;
        }
        else
        {
            return base.use();
        }        
    }

    public override bool ApplyAttack(short damage)
    {
        //release the djinn.
        /// xclock 3=Djinn Capture
        ///     2 = balisk oil is in the mud
        ///     3 = bathed in oil
        ///     4 = baked in lava
        ///     5 = iron flesh cast (does not need to be still on when you break the bottle)
        ///     6 = djinn captured in body
        switch (Quest.instance.x_clocks[3])
        {
            case 0:
            case 1:
            case 2:
            case 3:
            case 4://Before ironflesh
                DjinnKillsPlayer();break;
            case 5://after iron flesh.               
                if (IsAtSigil())
                { //If at sigil bind to player.
                    BindDjinn();
                }
                else
                {//anywhere else break jar.
                    Debug.Log("Not at sigil");
                }
                break;
            default:
                Debug.Log("You broke another bottle!. I've yet to test this!");
                break; 
        }
        objInt().consumeObject();//Destroy bottle.
        return true;
    }

    void BindDjinn()
    {
        //000~001~336~The air-daemon is absorbed into your body, and remains there, a faint but detectable presence awaiting release. \n
        UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, 336));
        Quest.instance.x_clocks[3] = 6;
    }

    private void DjinnKillsPlayer()
    {
        //You do this in the wrong location or without protection
        //000~001~369~The air daemon is released, and then rends you. \n
        UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, 369));
        UWCharacter.Instance.ApplyDamage(UWCharacter.Instance.MaxVIT + 1);        
    }

    /// <summary>
    /// Checks if the player is at the sigil of binding.
    /// </summary>
    /// <returns></returns>
    bool IsAtSigil()
    {
        if (GameWorldController.instance.LevelNo==68)
        {
            int tileX = TileMap.visitTileX; int tileY = TileMap.visitTileY;
            if ((tileX>=18) && (tileX<=25) && (tileY >= 49) && (tileY <= 56))
            {
                return true;
            }
        }
        return false;
    }
}
