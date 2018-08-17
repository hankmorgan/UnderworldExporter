using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapWorldSelect : GuiBase {
    public GameWorldController.Worlds world;

    public Texture2D ButtonOff;
    public Texture2D ButtonOn;
    public int teleportWorldIndex = 0;

    public void OnClick()
    {
        MapInteraction.instance.CurrentWorld = world;
        MapInteraction.UpdateMap((int)world);
    }

    public void SetOn()
    {
       this.GetComponent<RawImage>().texture = ButtonOn;
    }

    public void SetOff()
    {
        this.GetComponent<RawImage>().texture = ButtonOff;
    }

    public void TravelToWorld()
    {
        a_hack_trap_teleport.instance.TravelDirect(teleportWorldIndex);
    }

}
