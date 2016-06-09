using UnityEngine;
using System.Collections;

public class SpellEffectImmunityPoison : SpellEffectImmunity {

	//Won't cure existing poisoning. Just prevents it from being applied.
	//TODO:Move Poisoning to an api to enforce this behaviour.
}
