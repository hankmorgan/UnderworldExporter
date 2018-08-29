using UnityEngine;
using System.Collections;

public class a_check_variable_trap :a_variable_trap {
    /*
	 * Per uw-formats.txt
  018e  a_check variable trap
         the "value" from the set variable trap (018d) is also used here.
         the trap checks a range of variables, starting from "zpos" and of
         length "heading". if "xpos" is not 0, the variable values in range
         are added; if it is 0, the lower 3 bits of every variable value are
         shifted into the resulting value. here's some meta-C code to show
         how the check works:

         bool check_variable_trap(zpos,heading,value)
         {
            Int16 cmp = 0;
            for(Int16 i=zpos; i<zpos+heading; i++)
            {
               if (xpos != 0)
                  cmp += game_vars[i];
               else
               {
                  cmp <<= 3;
                  cmp |= game_vars[i] & 7;
               }
            }

            return di != value
         }

         The trigger associated with the trap is set off when the resulting
         value is not equal the "value".

Examples of usage
the left, right, center button combination on Level3.

        Theory
        in uw2 the xpos value appears to control how the variables are tested.
        bits = ?  look at game variables?
        bits = ?  look at quest variables?
        bit = ? look at xclock?

*/

    //protected override void Start()
    //{
    //    base.Start();
    //    Debug.Log(this.name + " will check " + zpos);
    //}

    public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{

        bool result = false;

        switch(_RES)
        {
            case GAME_UW2:
                {
                    switch (xpos)
                    {//In UW2 xpos controls what set of variables is looked at/
                        case 3: //An xclock list
                            {
                                if (zpos - 16 >= 0)
                                {
                                    result= Check_Variables(Quest.instance.x_clocks, zpos - 16, heading, this, "xclocks");
                                }
                                else
                                {
                                    Debug.Log("Ignored Xclock:" + zpos + " at " + objInt().objectloaderinfo.index);
                                }
                                break;
                            }
                        case 4://A game var list
                            result = Check_Variables(Quest.instance.variables, zpos, heading, this, "gamevars");
                            break;
                        case 5://A bit field list
                            result = Check_Variables(Quest.instance.BitVariables, zpos, heading, this, "bitvars");
                            break;
                        case 6://A quest flag list
                              result = Check_Variables(Quest.instance.QuestVariables, zpos, heading, this, "questvars");
                            break;
                        default:
                            Debug.Log("unknown usage of check trap " + xpos + " " + this.name);
                            break;
                    }
                    break;
                }
            default:
                {
                    result = Check_Variables(Quest.instance.variables, zpos, heading, this, "gamevars");
                    break;
                }
        }
		//Debug.Log (this.name);
		if (result)
		{
			TriggerNext(triggerX,triggerY,State);
			PostActivate(src);
		}
		else
		{
			if (_RES==GAME_UW2)	
			{//If linked to a null trap in UW2 the next of the null trap will act as a "false" action.
				ObjectInteraction nullObj= ObjectLoader.getObjectIntAt(link);
                if (nullObj!=null)
                {
                    if (nullObj.GetItemType() == ObjectInteraction.A_NULL_TRAP)
                    {
                        ObjectInteraction triggerObj = ObjectLoader.getObjectIntAt(nullObj.next);
                        if (triggerObj != null)
                        {
                            if (triggerObj.GetComponent<trap_base>() != null)
                            {
                                triggerObj.GetComponent<trap_base>().Activate(this, triggerX, triggerY, State);
                                PostActivate(src);
                            }
                        }
                    }
                }
			}
		}
	}

		/// <summary>
		/// The Comparison value the trap checks against
		/// </summary>
		/// <returns>The value.</returns>
	int ComparisonValue ()
	{
		int cmp = 0;
		for (int i = zpos; i <= zpos + heading; i++) {
			if (xpos != 0)
            {
                cmp += Quest.instance.variables[i];
            }				
			else
            {
				cmp <<= 3;
				cmp |= (Quest.instance.variables [i] & 0x7);
			}
		}
		return cmp;
	}

    /// <summary>
    /// Resumption of the execution chain is handled by the execution of the trap.
    /// </summary>
    /// <param name="src"></param>
    /// <param name="triggerX"></param>
    /// <param name="triggerY"></param>
    /// <param name="State"></param>
    /// <returns></returns>
	public override bool Activate (object_base src,int triggerX, int triggerY, int State)
	{
		ExecuteTrap(this, triggerX,triggerY, State);//The next in the chain for this trap is handled by the execute action.
		return true;
	}


    static bool Check_Variables(int[] vars, int index, int operation, a_check_variable_trap trap, string debugname)
    {//Based on what uw-formats says. Seems to work okay.
		if (operation!=0)
			{
			    int cmp = trap.ComparisonValue ();
			    if (cmp == trap.VariableValue())
			    {
				    Debug.Log (debugname + " cmp = " + cmp + " value=" + trap.VariableValue());	
			    }				
			    return cmp == trap.VariableValue();				
			}
		else
			{//Is this right?
                Debug.Log(debugname + ": Comparing " + trap.VariableValue() + " to variable " + index + " which is currently =" + vars[index]);
                return trap.VariableValue() == vars[index];
			}
		}

    public override bool WillFireRepeatedly()
    {
        return true;//test this?
    }
}
