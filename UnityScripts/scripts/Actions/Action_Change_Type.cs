using UnityEngine;
using System.Collections;

public class Action_Change_Type : MonoBehaviour {

	public string ObjectToChange;
	public int ObjectClass;
	public int SubClass;
	public int SubClassIndex;


	public void PerformAction()
	{
		//Debug.Log ("Action Change Type");
		ChangeType ();
	}

	private void ChangeType()
	{
		switch(ObjectClass)
		{
		case 7:
			{
			ChangeTypeClass7();
			break;
			}
		case 10://Force doors
		{
			ChangeTypeClass10();
			break;
		}
		default:
			{
			Debug.Log ("Action Change Type: New Class to be implemented " + ObjectClass + "_" + SubClass );
			break;
			}
		}
	}

	private void ChangeTypeClass7()
	{//Fixtures
		switch(SubClass)
		{

		case 7://Bridges
			{
			ChangeType_7_7();
			break;
			}

		default:
			{
				Debug.Log ("Action Change Type: New Class to be implemented " + SubClass );
				break;
			}
		}
	}

	private void ChangeTypeClass10()
	{//Force doors
		switch(SubClass)
		{
		case 2://Force doors
			ChangeType_10_2();
			break;
		}
	}

	private void ChangeType_10_2()
	{//force doors
		switch (SubClassIndex)
		{
		case 2://force door
			DeleteModel ();
			CreateForceDoor();
			break;
		case 6://Great lord snaq
			DeleteModel ();
			CreateGreatLord();
			break;
		}
	}

	private void ChangeType_7_7()
	{//Fixtures/Bridges
		switch (SubClassIndex)
		{
			case 7:	//Switch to a force bridge
				{
				//find out
				DeleteModel ();
				CreateForceBridge();
				break;
				}
			case 8:	//Switch to an elephant jorp
				{
				DeleteModel ();
				CreateElephantJorp();
				break;
				}
		}
	}

	private void DeleteModel()
	{
		GameObject myObj = GameObject.Find (ObjectToChange);
		if (myObj ==null)
		{
			return;
		}
		GameObject model = myObj.transform.Find(myObj.name+"_Model").gameObject;
		if (model !=null)
		{
			Destroy(model);
		}
	}

	private void CreateElephantJorp()
	{
		Debug.Log("Creating elephant");
		GameObject myObj = GameObject.Find (ObjectToChange);
		if (myObj ==null)
		{
			return;
		}
		loadGameObjectResourceAsModel(myObj,"Models/elephant");
		/*GameObject myInstance = Resources.Load("Models/elephant") as GameObject;
		GameObject newObj = (GameObject)GameObject.Instantiate(myInstance);
		newObj.name=myObj.name + "_Model";
		newObj.transform.parent=myObj.transform;
		newObj.transform.position = myObj.transform.position;*/
	}
	
	private void CreateForceBridge()
	{
		Debug.Log("Creating ForceBridge");
		GameObject myObj = GameObject.Find (ObjectToChange);
		if (myObj ==null)
		{
			return;
		}
		loadGameObjectResourceAsModel(myObj,"Models/force_bridge");
		/*GameObject myInstance = Resources.Load("Models/force_bridge") as GameObject;
		GameObject newObj = (GameObject)GameObject.Instantiate(myInstance);
		newObj.name=myObj.name + "_Model";
		newObj.transform.parent=myObj.transform;
		newObj.transform.position = myObj.transform.position;*/
	}

	private void CreateForceDoor()
	{
		Debug.Log("Creating ForceDoor");
		GameObject myObj = GameObject.Find (ObjectToChange);
		if (myObj ==null)
		{
			return;
		}
		loadGameObjectResourceAsModel(myObj,"Models/force_door");
	}

	private void CreateGreatLord()
	{
		Debug.Log("Creating GreatLord");
		GameObject myObj = GameObject.Find (ObjectToChange);
		if (myObj ==null)
		{
			return;
		}
		loadGameObjectResourceAsModel(myObj,"Models/GreatLordSnaq");
	}

	private void loadGameObjectResourceAsModel(GameObject myObj, string path)
	{
		GameObject myInstance = Resources.Load(path) as GameObject;
		GameObject newObj = (GameObject)GameObject.Instantiate(myInstance);
		newObj.name=myObj.name + "_Model";
		newObj.transform.parent=myObj.transform;
		newObj.transform.position = myObj.transform.position;
		newObj.transform.localRotation=new Quaternion(0,0,0,0);
	}
}
