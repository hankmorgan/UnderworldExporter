using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorClasses : UWClass {

    public int index;
    public int Style;//Unimplemented. What type of room is created. Eg cave, throne room, treasure room, pit, monster lair,
    public int BaseHeight;//Starting height for this area.

    public virtual void StyleArea()
    {

    }


    protected virtual void SetBaseHeight()
    {
        BaseHeight = Random.Range(0, 9) * 2;//Only multiple of two allowed. Range from 0 to 16
    }
}
