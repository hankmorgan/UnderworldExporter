using UnityEngine;
using System.Collections;

public class Action_Activate : MonoBehaviour {

	public string[] ObjectsToActivate=new string[4];
	public int[] ActivationDelay=new int[4];
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PerformAction()
	{
		Debug.Log (this.name + " Action Activate");
		for (int i = 0; i<4; i++)
		{
			if (ObjectsToActivate[i]!="")
			{
				GameObject objToActivate = GameObject.Find (ObjectsToActivate[i]);
				if (objToActivate!=null)
				{
					if (ActivationDelay[i]!=0)
					{
						StartCoroutine(ActivationWait (objToActivate,ActivationDelay[i]));
					}
					else
					{
						objToActivate.SendMessage("Activate");
					}
				}
			}
		}
	}

	IEnumerator ActivationWait(GameObject objToActivate, float waittime)
	{
		//Debug.Log("MoveTileStart");
		float index = 0.0f;
		while (index <waittime)
		{
			index += Time.deltaTime;
			yield return new WaitForSeconds(0.01f);
		}
		objToActivate.SendMessage("Activate");
	}
}
