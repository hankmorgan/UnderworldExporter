using UnityEngine;
using System.Collections;

public class a_ward_trap : trap_base
{
    //?
    /*
	 * Magic ward traps.
	 * NPC collides with one it will set off a spell property object.
	 */

    public SpellProp spellprop;//The spell properties of the ward.

    protected override void Start()
    {
        base.Start();
        this.gameObject.layer = LayerMask.NameToLayer("Ward");
        BoxCollider bx = this.gameObject.GetComponent<BoxCollider>();
        if (bx == null)
        {
            bx = this.gameObject.AddComponent<BoxCollider>();
        }
        bx.size = new Vector3(0.35f, 0.35f, 0.35f);
        bx.center = new Vector3(0.0f, 0.1f, 0.0f);
        bx.isTrigger = true;
        switch (_RES)
        {
            case GAME_UW2:
                {
                    switch (item_id)
                    {
                        case 414: //flam trap
                            {
                                SpellProp_Fireball sppf = new SpellProp_Fireball();
                                sppf.init(SpellEffect.UW2_Spell_Effect_Fireball, UWCharacter.Instance.gameObject);
                                spellprop = sppf;
                                break;
                            }
                        case 415://tym trap
                            {
                                SpellProp_Tym spty = new SpellProp_Tym();
                                spty.init(SpellEffect.UW2_Spell_Effect_Paralyze, UWCharacter.Instance.gameObject);
                                spellprop = spty;
                                break;
                            }
                        default:
                            Debug.Log("unimplemented ward trap type " + item_id);
                            break;
                    }
                    break;
                }
            default://UW1 rune of warding
                {
                    SpellProp_RuneOfWarding spIJ = new SpellProp_RuneOfWarding();//myObj.AddComponent<SpellProp_RuneOfWarding>();
                    spIJ.init(SpellEffect.UW1_Spell_Effect_RuneofWarding, UWCharacter.Instance.gameObject);
                    spellprop = spIJ;
                    break;
                }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        //Get the NPC that hit the ward
        NPC npc = other.gameObject.GetComponent<NPC>();

        if (npc != null)//Has the collision hit an npc
        {
            if (spellprop.BaseDamage != 0)
            {
                npc.ApplyAttack(spellprop.BaseDamage);
            }
            spellprop.onImpact(npc.transform);
            spellprop.onHit(npc.gameObject.GetComponent<ObjectInteraction>());
            objInt().consumeObject();
        }
        else
        {
            if (other.gameObject.GetComponent<UWCharacter>())
            {
                if (spellprop.BaseDamage != 0)
                {
                    UWCharacter.Instance.ApplyDamage(spellprop.BaseDamage);
                }
                spellprop.onHitPlayer();
                objInt().consumeObject();
            }
            else
            {
                if (_RES == GAME_UW2)
                {
                    objInt().consumeObject();
                }
            }
        }

    }
}
