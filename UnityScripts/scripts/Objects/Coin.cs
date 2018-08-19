using UnityEngine;
using System.Collections;
/// <summary>
/// Money, moolah, ka-ching.
/// </summary>
public class Coin : object_base {

	protected override void Start ()
	{
		base.Start ();
		//ChangeCoinType();
	}

	public override void MergeEvent ()
	{
		base.MergeEvent ();
		//ChangeCoinType();

	}

	public override void Split ()
	{
		base.Split ();
		//ChangeCoinType();
	}

		/// <summary>
		/// Another item Id this object could potentially have. Eg coin/gold coin. 
		/// By default it's normal item_id is returned
		/// </summary>
		/// <returns>The item identifier.</returns>
		/// Coins are in multiple variants coin, gold coin.
	public override int AliasItemId ()
	{
				
		if (item_id==160)
		{
			return 161;
		}
		else if (item_id==161)
		{
			return 160;
		}
		else
		{
			return base.AliasItemId ();
		}
	}

		/// <summary>
		/// Turns coins into different types when they stack or split
		/// </summary>
	private void ChangeCoinType()
	{//THis is not vanilla behaviour!
		//CheckReferences ();
	switch (item_id)
		{
		case 161://a Coin
			if (objInt().GetQty ()>1)
			{
				ChangeType(160);
			}
			break;
		case 160://A stack of coins.
			if (objInt().GetQty ()==1)
			{
				ChangeType(161);
			}
			break;
		}
	}
}
