using UnityEngine;
using System.Collections;

public class CritterAnimInfo {

	public string[,] animSequence;
	public int[,] animIndices;
	public Sprite[] animSprites;
	public string[] animName;

	public CritterAnimInfo()
		{
		animSequence=new string[32,8];
		animIndices=new int[32,8];
		animSprites=new Sprite[128];//In order
		animName=new string[32];
		}
}
