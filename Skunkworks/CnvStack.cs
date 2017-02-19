using UnityEngine;
using System.Collections;

public class CnvStack {

	public int[] StackValues;
	public int stackptr;


	public CnvStack(int stackSize)
		{
		StackValues=new int[stackSize];
		stackptr=0;
		/*for (int i=0; i<=StackValues.GetUpperBound(0);i++)
			{
			StackValues[i]=i;
			}*/
		}

	public int Pop()
		{
		stackptr--;
		int popvalue = StackValues[stackptr];
		StackValues[stackptr]=0;
		return popvalue;
		}

	public void Push(int newValue)
		{
		StackValues[stackptr++]=newValue;
		}

	public void Set(int arg1, int arg2)
		{
		StackValues[arg1]=arg2;//I hope!
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
		return StackValues[index];
		}
}


