using UnityEngine;
using System.Collections;

public class a_check_variable_trap :a_variable_trap {
	//public int xpos;
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

*/

	public override void ExecuteTrap (int triggerX, int triggerY, int State)
	{
		Debug.Log (this.name);
		if (check_variable_trap())
		{
			TriggerNext(triggerX,triggerY,State);
		}
	}

	public override bool Activate (int triggerX, int triggerY, int State)
	{
		//CheckReferences();
		//Do what it needs to do.
		ExecuteTrap(triggerX,triggerY, State);//The next in the chaing for this trap is handle by the execute action.

		//Stuff to happen after the trap has fired.
		PostActivate();
		return true;
	}


	bool check_variable_trap()
	{//TODO: this is a guess

		if (objInt().heading!=0)
			{
				int cmp = 0;
				for(int i=objInt().zpos; i<=objInt().zpos+objInt().heading; i++)
				{								
					if (objInt().x != 0)
						cmp += GameWorldController.instance.variables[i];
					else
					{
						cmp <<= 3;
						cmp |= (GameWorldController.instance.variables[i]  & 0x7);
					}
				}
				Debug.Log ("cmp = " + cmp + " value=" + VariableValue());
				return cmp == VariableValue();
				
			}
		else
			{//Is this right?
				return VariableValue()==GameWorldController.instance.variables[objInt().zpos];
			}
		}
}
