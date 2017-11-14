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

	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
		//Debug.Log (this.name);
		if (check_variable_trap())
		{
			TriggerNext(triggerX,triggerY,State);
		}
	}

	public override bool Activate (object_base src,int triggerX, int triggerY, int State)
	{
		//CheckReferences();
		//Do what it needs to do.
		ExecuteTrap(this, triggerX,triggerY, State);//The next in the chaing for this trap is handle by the execute action.

		//Stuff to happen after the trap has fired.
		PostActivate(src);
		return true;
	}


	bool check_variable_trap()
	{//Based on what uw-formats says. Seems to work okay.
			if (_RES==GAME_UW2)
			{//Some variables in UW2 seem to map to x_clock values
				switch (objInt().zpos)
				{
					case 17://castle events
					case 18://This is tested					
					case 19://Djinn capture
					case 20://The following are untested
					case 21:
					case 22:
					case 23:
					case 24:
					case 25:
					case 26:
					case 27:
					case 28:
					case 29:
					case 30:
					case 31:								
						//return VariableValue()==Quest.instance.DjinnCapture;	
						return VariableValue()==Quest.instance.x_clocks[objInt().zpos-16];	
				}
			}
		if (objInt().heading!=0)
			{
				int cmp = 0;
				for(int i=objInt().zpos; i<=objInt().zpos+objInt().heading; i++)
				{								
					if (objInt().x != 0)
						cmp += Quest.instance.variables[i];
					else
					{
						cmp <<= 3;
						cmp |= (Quest.instance.variables[i]  & 0x7);
					}
				}
				Debug.Log (this.name + " cmp = " + cmp + " value=" + VariableValue());
				return cmp == VariableValue();
				
			}
		else
			{//Is this right?
				Debug.Log(this.name + " comparing " + VariableValue() + " to variable " + objInt().zpos + " (" + Quest.instance.variables[objInt().zpos] + ")" );
				return VariableValue()==Quest.instance.variables[objInt().zpos];
			}
		}





}
