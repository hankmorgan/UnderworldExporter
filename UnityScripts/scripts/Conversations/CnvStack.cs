using UnityEngine;
using System.Collections;

/// <summary>
/// Stack memory for the conversation VM
/// </summary>
public class CnvStack {

		/// <summary>
		/// The stack values.
		/// </summary>
		public int[] StackValues;

		/// <summary>
		/// The stack pointer 
		/// </summary>
		public int stackptr=0;

		/// <summary>
		/// The base pointer
		/// </summary>
		public int basep=0;

		public CnvStack(int stackSize)
		{
			StackValues=new int[stackSize];
			stackptr=0;
		}

		/// <summary>
		/// Pop a value from the stack
		/// </summary>
		public int Pop()
		{
				stackptr--;
				int popvalue = StackValues[stackptr];
				StackValues[stackptr]=0;
				return popvalue;
		}


		/// <summary>
		/// Push a value to the stack
		/// </summary>
		/// <param name="newValue">New value.</param>
		public void Push(int newValue)
		{
			StackValues[stackptr++]=newValue;
		}

		/// <summary>
		/// Set the specified value on the stack
		/// </summary>
		/// <param name="index">Index to change</param>
		/// <param name="val">value to set</param>
		public void Set(int index, int val)
		{
				StackValues[index]=val;//I hope!
		}

		public int get_stackp()
		{
				return stackptr;
		}

		public void set_stackp(int ptr)
		{
				stackptr=ptr;
		}

		public int at(int index)
		{
				if (index>StackValues.GetUpperBound(0))
				{
						Debug.Log ("Stack out of bounds- At (" + index + ")");
						return 0;
				}
				return StackValues[index];
		}

		public int Upperbound()
		{
				return StackValues.GetUpperBound(0);
		}

}