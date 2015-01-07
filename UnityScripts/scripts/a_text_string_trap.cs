using UnityEngine;
using System.Collections;

public class a_text_string_trap : MonoBehaviour {
	
	private GameObject triggerObj;
	private ObjectVariables Var;
	private UILabel MessageLog;
	public static StringController SC;
	public int StringNo;	//What string we are spitting out. (num is based on level no)
	public int StringBlock; //From what block the string is from.
	
	// Use this for initialization
	void Start () {
		MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
		Var=GetComponent<ObjectVariables>();
		triggerObj=GameObject.Find (Var.trigger);
	}
	
	// Update is called once per frame
	void Update () {
		if ((triggerObj == null) && (Var.trigger != "") && (Var.trigger != null))
			{//For when objects are added at run time.
				triggerObj=GameObject.Find (Var.trigger);
			}
	}

	public void Activate()
	{
		
		//Do what it needs to do.
		//MessageLog.text=MessageLog.text + name + " activated";
		MessageLog.text= SC.GetString(StringBlock,StringNo);
		//MessageLog.text=MessageLog.text + name + " string returned is " + ObjectVariables.LookupString(StringBlock,StringNo);
		if (triggerObj !=null )
		{
			triggerObj.SendMessage ("Activate");
		}
	}
}
