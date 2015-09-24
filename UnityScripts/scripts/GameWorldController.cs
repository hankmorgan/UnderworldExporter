using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class GameWorldController : MonoBehaviour {
	List<Material> AnimMaterials=new List<Material>();
	List<int>AnimMaterialsIndex=new List<int>();
	List<string>AnimatedTextures=new List<string>();
	public bool EnableTextureAnimation;
	public static TextureController tc;
	//private Material mattToChange;
	private bool Test;
	// Use this for initialization
	void Start () {

		//TODO:Figure out how to import animated textures!
		AnimatedTextures.Add ("uw1_226");


		foreach(Transform child in transform)
		{
			foreach(Material matt in child.gameObject.renderer.sharedMaterials)
			{
				string mattName= matt.name.Substring(0,7);
				if (AnimatedTextures.Contains(mattName ))
				{
					if (!AnimMaterials.Contains(matt))
					{
						AnimMaterials.Add(matt);
						int index = int.Parse(matt.name.Substring (matt.name.Length-3,3));
						AnimMaterialsIndex.Add (index);
					}
					//mattToChange=matt;
					//Debug.Log (matt.name + " on " + child.name );

					//matt.mainTexture = tc.RequestTexture(5);
					//break;
				}

				//do something
			}
		}
		//Debug.Log ("no of materials " + AnimMaterials.Count);
		if (EnableTextureAnimation==true)
		{
			Undo.RegisterUndo(AnimMaterials.ToArray(), "Fix Shared Material");
			InvokeRepeating("UpdateAnimation",0.2f,0.2f);
		}
	}
	
	// Update is called once per frame
	void Update () {
	/*	if (Test==false)
		{
			Test=true;
			mattToChange.mainTexture=tc.RequestTexture(5);
		}
*/
	}

	void UpdateAnimation()
	{
		for (int i = 0; i<AnimMaterials.Count;i++)
			{
			AnimMaterials[i].mainTexture=tc.RequestTexture(AnimMaterialsIndex[i],true);
			}
		//if (Test==false)
		//{
		//	Test=true;
			
		//}
	}
}
