using UnityEngine;
using System.Collections;

public class a_set_variable_trap : a_variable_trap
{
    /*
018d  a_set variable trap
	sets a game variable; fields "quality", "owner" and "ypos" are
	combined to form a "value" that is used as variable index later:
		
		field   bits in value
		ypos    0..2
		owner   3..7     (bit 5 of "owner" seems not to be used)
		quality 8..13
		
		the "zpos" field determines which variable to set. if zpos is 0, a
		bit-field is modified and the index value indicates which bit to
		modify. the "heading" field determines the operation to perform:
		
		heading  operation    bit-field operation
		0        add          set bit
		1        sub          clear bit
		2        set          set bit
		3        and          set bit
		4        or           set bit
		5        xor          flip bit
		6        shl          set bit

	values are modified and kept in range 0..63 (0x3f).
	
	largest variable index in uw1 is 0x33, the only bit modified in uw1
	is bit 7 of the bit field

    In UW2 the traps can change quest vars,  game vars and xclocks. 
    This is controlled by the xpos variable.
    The owner is now the sole index into the traps. (need confirm this with the scintlvl5 switches as owner does not give index there)

        So far only examples of checking the gamevars has been found on check traps
*/

    //protected override void Start()
    //{
    //    base.Start();
    //    //Debug.Log(this.name + " will set " + zpos);
    //}


    public override void ExecuteTrap(object_base src, int triggerX, int triggerY, int State)
    {
        int[] vars;
        vars = Quest.instance.variables;
        if (_RES == GAME_UW2)
        {
            switch (xpos)
            {
                case 1://Bit Variables
                    Set_Variables(Quest.instance.BitVariables, zpos, heading, this, "bitvars");
                    break;
                case 0://game variables 
                    Set_Variables(Quest.instance.variables, zpos, heading, this, "gamevars");
                    break;
                case 2://quest vars
                    Set_Variables(Quest.instance.QuestVariables, zpos, heading, this, "questvars");
                    break;
                case 3://xclock  
                    if (zpos-16 >=0)
                    {
                        Set_Variables(Quest.instance.x_clocks, zpos - 16, heading, this, "xclocks");
                    }
                    else
                    {
                        Debug.Log("Ignored Xclock:" + zpos + " at " + objInt().objectloaderinfo.index);
                    }                    
                    break;
                default:
                    Debug.Log("unknown usage of set trap " + xpos + " " + this.name);
                    break;
            }
        }
        else
        {
            Set_Variables(Quest.instance.variables, zpos, heading, this, "gamevars");
        }



    }

    static void Set_Variables(int[] vars, int index, int operation, a_set_variable_trap trap, string debugname)
    {
        string op = "";
        int OrigValue = 0;
        if (index != 0)
        {//Variable Operations
            OrigValue = vars[index];
            switch (operation)
            {
                case 0://Add
                    vars[index] += trap.VariableValue();
                    op = "add";
                    break;
                case 1://Sub
                    vars[index] -= trap.VariableValue();
                    op = "Sub";
                    break;
                case 2://Set
                    vars[index] = trap.VariableValue();
                    op = "Set";
                    break;
                case 3://AND
                    vars[index] &= trap.VariableValue();
                    op = "And";
                    break;
                case 4://OR
                    vars[index] |= trap.VariableValue();
                    op = "or";
                    break;
                case 5://XOR
                    vars[index] ^= trap.VariableValue();
                    op = "xor";
                    break;
                case 6://Shift left
                    vars[index] = vars[index] * (2 * trap.VariableValue()) & 63;
                    op = "shl";
                    break;
            }

            Debug.Log(debugname + ": Operation + " + op + " Variable " + index + " was " + OrigValue + " now =" + vars[index] + " using varvalue" + trap.VariableValue() + " trap " + trap.objInt().objectloaderinfo.index);
        }
        else
        {//Bitwise operations on bitfield
            Debug.Log("Bitwise set variable. Not implemented yet");
            switch (operation)
            {
                case 0://Set

                    break;
                case 1://Clear

                    break;
                case 2://Set

                    break;
                case 3://Set

                    break;
                case 4://Set

                    break;
                case 5://Flip

                    break;
                case 6://Set

                    break;
            }
        }
    }

    public override int VariableValue()
    {//UW2 does this differently.
     //See the puzzle on loth 1. (solution left to right is is 1,4,2,3,5) which xors to 31 when using the owner only.
     //The check variable seems to work as normal in uw1 and uw2.
        switch (_RES)
        {
            case GAME_UW2:
                return owner;
            default:
                return ((quality & 0x3f) << 8) | (((owner & 0x1f) << 3) | (ypos & 0x7));
        }
    }
}
