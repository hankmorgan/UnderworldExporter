using UnityEngine;

/// <summary>
/// Billboard sprites so they always face the player.
/// </summary>
public class Billboard : MonoBehaviour
{

	void Update()
	{
	if (Vector3.Distance(this.transform.position, GameWorldController.instance.playerUW.CameraPos)<=8)
		{//Only rotate nearby objects.
				
			if (GameWorldController.instance.playerUW.dir!=Vector3.zero)
				{
				transform.rotation = Quaternion.LookRotation(GameWorldController.instance.playerUW.dir);						
				}
			
		//based on http://answers.unity3d.com/questions/524087/tweaking-sprite-billboard.html

		}
	}
}