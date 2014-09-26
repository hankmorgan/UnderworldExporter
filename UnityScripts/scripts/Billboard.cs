using UnityEngine;

public class Billboard : MonoBehaviour
{
	void Update()
	{
		transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
		//transform.LookAt(Camera.main.transform.position, Vector3.up);
	}
}