using UnityEngine;
using System.Collections;

public class Armour : Equipment {
	//public int Durability;
	public int Protection;
	public string EquipFemaleLowest; 
	public string EquipFemaleLow;
	public string EquipFemaleMedium;
	public string EquipFemaleBest;
	
	public string EquipMaleLowest; 
	public string EquipMaleLow;
	public string EquipMaleMedium;
	public string EquipMaleBest;
	
	public Texture2D EquipDisplay;

	public SpellEffect SpellEffectApplied;

	public override int GetActualSpellIndex ()
	{
		return objInt.Link-256+16;
	}

	protected override void Start () {
		base.Start ();
		UpdateQuality();
	}


	public override void UpdateQuality()
	{//Refreshes the quality of armour when damage is taken
		//Needs to be called when damaged.
		if ((objInt.Quality>0) && (objInt.Quality<=15))
		{
			//Return lowest quality 
			//setEquipTexture(0)
			if (playerUW.isFemale)
			{
				SetEquipTexture(EquipFemaleLowest);
			}
			else
			{
				SetEquipTexture(EquipMaleLowest);
			}
		}
		else if ((objInt.Quality>15) && (objInt.Quality<=30))
		{
			//Low quality
			if (playerUW.isFemale)
			{
			SetEquipTexture(EquipFemaleLow);
			}
			else
			{
			SetEquipTexture(EquipMaleLow);
			}
		}
		else if ((objInt.Quality>30) && (objInt.Quality<=45))
		{
			//Medium
			if (playerUW.isFemale)
			{
			SetEquipTexture(EquipFemaleMedium);
			}
			else
			{
				SetEquipTexture(EquipMaleMedium);
			}
		}
		else if ((objInt.Quality>45) && (objInt.Quality<=63))
		{
			//Best
			if (playerUW.isFemale)
			{
			SetEquipTexture(EquipFemaleBest);
			}
			else
			{
				SetEquipTexture(EquipMaleBest);
			}
		}
		objInt.SetEquipDisplay(Sprite.Create(EquipDisplay,new Rect(0,0,EquipDisplay.width,EquipDisplay.height), new Vector2(0.5f, 0.5f)));
	}
	
	void SetEquipTexture(string EquipTexture)
	{
		EquipDisplay = Resources.Load <Texture2D> (EquipTexture);
	}


	public override bool EquipEvent (int slotNo)
	{

		if ((slotNo >=0) && (slotNo <=4))
		{
			UpdateQuality();
			if (objInt.isEnchanted==true)
			{
				//cast enchantment.
				SpellEffectApplied = playerUW.PlayerMagic.CastEnchantment(playerUW.gameObject,GetActualSpellIndex());
				if (SpellEffectApplied!=null)
				{
					SpellEffectApplied.SetPermanent(true);
				}
			}
		}
		return true;
	}
	
	public override bool UnEquipEvent (int slotNo)
	{
		if ((slotNo >=0) && (slotNo <=4))
		{
			if (SpellEffectApplied!=null)
			{
				SpellEffectApplied.CancelEffect();
				return true;
			}
		}
		return false;
	}




}