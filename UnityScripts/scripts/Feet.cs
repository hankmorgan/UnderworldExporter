using UnityEngine;
using System.Collections;

public class Feet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Physics.IgnoreCollision(this.collider, this.transform.parent.collider);
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit = new RaycastHit(); 
		//Physics.Raycast(this.transform, Vector3.down,out hit,1.0f)
		if(Physics.Raycast(this.transform.position, Vector3.down,out hit,1.0f))
		{
			//Debug.Log ("Hit="+ hit.transform.name);
			TileInfo ti = hit.transform.gameObject.GetComponent<TileInfo>();
			if (ti!=null)
			{
				ti.TileVisited=true;
				Debug.Log (ti.east);
			}
		}
	}

}
