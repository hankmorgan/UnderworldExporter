using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellEffectLucky : SpellEffect
{
    public UWCharacter.LuckState NewState;

    public override void ApplyEffect()
    {
        if (UWCharacter.Instance == null)
        {
            UWCharacter.Instance = this.GetComponent<UWCharacter>();
        }
        UWCharacter.Instance.isLucky = NewState;
        base.ApplyEffect();
    }


    //void Update()
    //{
    //    if (Active)
    //    {//Maintain the effect
    //        UWCharacter.Instance.isLucky = true;
    //    }
    //}

    public override void CancelEffect()
    {
        UWCharacter.Instance.isLucky = UWCharacter.LuckState.Neutral;
        base.CancelEffect();
    }

}
