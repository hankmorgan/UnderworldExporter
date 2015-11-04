using UnityEngine;
using System.Collections;

public class a_do_trap_platform : trap_base {

	public override void ExecuteTrap (int triggerX, int triggerY, int State)
	{
		GameObject platformTile= GameWorldController.FindTile (triggerX,triggerY,1);//Var.FindTile (Var.triggerX,Var.triggerY,1);
		
		if (State==7)
		{
			//Move the tile to the bottom
			StartCoroutine(MoveTile (platformTile.transform, new Vector3(0f,-0.3f*7f,0f) ,0.1f));
			//state = 1;
		}
		else
		{
			//Go up a step.
			StartCoroutine(MoveTile (platformTile.transform, new Vector3(0f,0.3f,0f) ,0.1f));
			//state++;
		}
	}


	IEnumerator MoveTile(Transform platform, Vector3 dist, float traveltime)
		{
		float rate = 1.0f/traveltime;
		float index = 0.0f;
		Vector3 StartPos = platform.position;
		Vector3 EndPos = StartPos + dist;
		while (index <1.0f)
			{
			platform.position = Vector3.Lerp (StartPos,EndPos,index);
			index += rate * Time.deltaTime;
			yield return new WaitForSeconds(0.01f);
			}
		platform.position = EndPos;
		}
}
