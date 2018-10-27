using UnityEngine;
using System.Collections;

public class NPC_Animation : MonoBehaviour {
	const float frameRate =0.2f;
	public bool FreezeAnimFrame;
	public int AnimationIndex;//Animation to display
	public int AnimationPos;//Position in the animation.
	public float animationCounter;

	public CritterAnimInfo critAnim;
	public SpriteRenderer output;
	public bool ConstantAnim; //Is this anim continuouse or periodic. (ie hold on final frame.

	// Update is called once per frame
	void Update () {
		animationCounter+=Time.deltaTime;
		if (animationCounter>=frameRate)
		{
			animationCounter=0f;
			if (AnimationPos<=critAnim.animIndices.GetUpperBound(1))
			{
				if (critAnim.animIndices[AnimationIndex,AnimationPos]!=-1)
				{
					output.sprite= critAnim.animSprites[critAnim.animIndices[AnimationIndex,AnimationPos]];	
                }
				else
				{
					if (ConstantAnim==false)
					{
						AnimationPos=0;
					}					
				}
			}
			if ((FreezeAnimFrame) || (UWCharacter.Instance.isTimeFrozen))
			{
				AnimationPos=0;
			}
			else
			{
				AnimationPos++;					
			}			
			if ((AnimationPos>=critAnim.animIndices.GetUpperBound(1)) && (ConstantAnim==false))
			{
				AnimationPos=0;
			}
            
            //if ((critAnim.animIndices[AnimationIndex,AnimationPos] == -1) && (ConstantAnim==true))
            //{
            //	AnimationPos=0;	
            //}
        }	

	}

	public void Play(int anim, bool isConstant)
	{			
		if (anim!=AnimationIndex)
			{//A new animation
				ConstantAnim=isConstant;
				AnimationPos=0;
				animationCounter=0f;
				if (critAnim.animIndices[AnimationIndex,AnimationPos++]!=-1)
				{
					output.sprite= critAnim.animSprites[critAnim.animIndices[AnimationIndex,AnimationPos++]];//Start the animation.					
				}				
			}
			if ((FreezeAnimFrame) || (UWCharacter.Instance.isTimeFrozen))
			{
				AnimationPos=0;
			}
		AnimationIndex=anim;
	}
}
