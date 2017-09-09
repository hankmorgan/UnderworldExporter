using UnityEngine;
using System.Collections;

public class a_set_variable_trap : a_variable_trap {
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
*/



	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
		string operation="";
		int OrigValue=0;
		if (objInt().zpos!=0)
		{//Variable Operations
			OrigValue=GameWorldController.instance.variables[objInt().zpos];
			//Debug.Log ("Variable " + VariableIndex + " op(" + heading + ") = " + GameWorldController.instance.variables[VariableIndex] );
			switch(objInt().heading)
			{
			case 0://Add
				GameWorldController.instance.variables[objInt().zpos] += VariableValue();
				operation = "add";
				break;
			case 1://Sub
				GameWorldController.instance.variables[objInt().zpos] -= VariableValue();
				operation = "Sub";
				break;
			case 2://Set
				GameWorldController.instance.variables[objInt().zpos] = VariableValue();
				operation = "Set";
				break;
			case 3://AND
				GameWorldController.instance.variables[objInt().zpos] &= VariableValue();
				operation = "And";
				break;
			case 4://OR
				GameWorldController.instance.variables[objInt().zpos] |= VariableValue();
				operation = "or";
				break;
			case 5://XOR
				GameWorldController.instance.variables[objInt().zpos] ^= VariableValue();
				operation = "xor";
				break;
			case 6://Shift left
				//	fprintf(fBODY,"\tglobal_var_%d = (global_var_%d * %d ) & 63 ;\n",variable,variable,2*value);
				//GameWorldController.instance.variables[VariableIndex] = GameWorldController.instance.variables[VariableIndex]<<VariableValue);
				GameWorldController.instance.variables[objInt().zpos] =	GameWorldController.instance.variables[objInt().zpos] * (2*VariableValue()) & 63;
				operation = "shl";
				break;

			}
			Debug.Log (this.name  + "Operation + " + operation + "Variable " + objInt().zpos + " was " + OrigValue + " now =" + GameWorldController.instance.variables[objInt().zpos] );
		}
		else
		{//Bitwise operations on bitfield
			Debug.Log("Bitwise set variable. Not implemented yet");
			switch(objInt().heading)
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
}
