using UnityEngine;
using System.Collections;

public class Shield : Equipment {
	public override int GetActualSpellIndex ()
	{
		return objInt.Link-512;
	}
}
