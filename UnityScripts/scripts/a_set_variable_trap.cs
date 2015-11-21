using UnityEngine;
using System.Collections;

public class a_set_variable_trap : trap_base {
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
}
