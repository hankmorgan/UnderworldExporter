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

	public int ProtectionBonus;
	public int ToughnessBonus;
	
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

		if ((slotNo >=0) && (slotNo <=4))//Gloves, chest,legging,boots and helm
		{
			UpdateQuality();
			if (objInt.isEnchanted==true)
			{
				int EffectId=GetActualSpellIndex ();
				switch (EffectId)
				{
				case SpellEffect.UW1_Spell_Effect_MinorProtection:
				case SpellEffect.UW1_Spell_Effect_Protection:
				case SpellEffect.UW1_Spell_Effect_AdditionalProtection:
				case SpellEffect.UW1_Spell_Effect_MajorProtection:
				case SpellEffect.UW1_Spell_Effect_GreatProtection:
				case SpellEffect.UW1_Spell_Effect_VeryGreatProtection:
				case SpellEffect.UW1_Spell_Effect_TremendousProtection:
				case SpellEffect.UW1_Spell_Effect_UnsurpassedProtection:
					ProtectionBonus=EffectId-463;
					break;
				case SpellEffect.UW1_Spell_Effect_MinorToughness:
				case SpellEffect.UW1_Spell_Effect_Toughness:
				case SpellEffect.UW1_Spell_Effect_AdditionalToughness:
				case SpellEffect.UW1_Spell_Effect_MajorToughness:
				case SpellEffect.UW1_Spell_Effect_GreatToughness:
				case SpellEffect.UW1_Spell_Effect_VeryGreatToughness:
				case SpellEffect.UW1_Spell_Effect_TremendousToughness:
				case SpellEffect.UW1_Spell_Effect_UnsurpassedToughness:
					ToughnessBonus=EffectId-471;
					break;

				default:
					//cast enchantment.
					SpellEffectApplied = playerUW.PlayerMagic.CastEnchantment(playerUW.gameObject,null,GetActualSpellIndex(),Magic.SpellRule_TargetSelf);
					if (SpellEffectApplied!=null)
					{
						SpellEffectApplied.SetPermanent(true);
					}
					break;
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