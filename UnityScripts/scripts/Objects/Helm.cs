using UnityEngine;
using System.Collections;

public class Helm : Armour {

	public override int GetActualSpellIndex ()
	{
		return objInt().Link-512;
	}

}
