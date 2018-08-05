using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorClasses : UWClass {

    public int index;
    public int Style;//Unimplemented. What type of room is created. Eg cave, throne room, treasure room, pit, monster lair,
 

    public static bool RandomPercent(int percent)
    {
        return (percent >= Random.Range(1, 101));
    }

}
