using UnityEngine;
using System.Collections;

public class a_do_trap_platform : MonoBehaviour {

	private GameObject triggerObj;
	private ObjectVariables Var;
	private UILabel MessageLog;
	//public int state;
	// Use this for initialization
	void Start () {
		MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
		Var=GetComponent<ObjectVariables>();
		triggerObj=GameObject.Find (Var.trigger);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Activate()
	{
		if ((triggerObj == null) && (Var.trigger != ""))
		{//For when objects are added at run time.
			triggerObj=GameObject.Find (Var.trigger);
		}
		GameObject platformTile= Var.FindTile (Var.triggerX,Var.triggerY,1);
		//Find the object that called me

		//MessageLog.text=MessageLog.text + name + "\n activated @ x=" + Var.triggerX + " y=" + Var.triggerY + "\n";
		if (Var.state==7)
		{
			//Move the tile to the bottom
			//MessageLog.text=MessageLog.text + platformTile.name + " reset " + Var.state;
			//platformTile.transform.Translate(Vector3.up())
			//Debug.Log("PreMoveTileStart");
			StartCoroutine(MoveTile (platformTile.transform, new Vector3(0f,-0.3f*7f,0f) ,0.5f));
			//Debug.Log("PostMoveTileStart");
			//platformTile.transform.position = new Vector3(0f,0f,1.0f);
			Var.state = 1;
		}
		else
		{
			//move the tile up one step.
			//MessageLog.text=MessageLog.text  + platformTile.name +  " up " + Var.state;
			//platformTile.transform.position = new Vector3(0f,0f,1.0f);
			//platformTile.transform.position.z += 1.22;
			//Debug.Log("PreMoveTileStart");
			StartCoroutine(MoveTile (platformTile.transform, new Vector3(0f,0.3f,0f) ,0.5f));
			//Debug.Log("PostMoveTileStart");
			//MoveTile (platformTile.transform, Vector3(0.0f,0.0f,1.2f), 1.0f);
			//triggeringObject.state++;
			Var.state++;
		}
		if (triggerObj !=null)
		{
			Debug.Log ("Triggering " + Var.trigger);
			triggerObj.SendMessage ("Activate");
		}
	}

	IEnumerator MoveTile(Transform platform, Vector3 dist, float traveltime)
		{
		//Debug.Log("MoveTileStart");
		float rate = 1.0f/traveltime;
		float index = 0.0f;
		Vector3 StartPos = platform.position;
		Vector3 EndPos = StartPos + dist;
		//Debug.Log(StartPos);
		//Debug.Log (EndPos);
		while (index <1.0f)
			{
			platform.position = Vector3.Lerp (StartPos,EndPos,index);
			index += rate * Time.deltaTime;
			//Debug.Log (index);
			//WaitForSeconds(0.1f);
			//yield return new WaitForSeconds (0.1f);
			yield return new WaitForSeconds(0.01f);
			}
		platform.position = EndPos;
		//Debug.Log("MoveTileEnd");
		}

}
