using UnityEngine;
using System.Collections;

public class ScrollButtonInventory : Scrollbutton
{
    public short stepSize;
    public static short ScrollValue = 0;
    public short MaxScrollValue;
    public short MinScrollValue;

    private int previousScrollValue = -1;

    public void OnClick()
    {
        ScrollValue = (short)(ScrollValue + stepSize);
        int noOfItems = UWCharacter.Instance.playerInventory.currentContainer.CountItems();
        MaxScrollValue = (short)(Mathf.Max((((noOfItems)/ 4)-1) * 4,8));
        if (ScrollValue > MaxScrollValue)
        {
            ScrollValue = MaxScrollValue;
        }

        if (ScrollValue < MinScrollValue)
        {
            ScrollValue = MinScrollValue;
        }
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (ScrollValue != previousScrollValue)
        {
            previousScrollValue = ScrollValue;
            UWCharacter.Instance.playerInventory.ContainerOffset = ScrollValue;
            UWCharacter.Instance.playerInventory.Refresh();
        }
    }
}
