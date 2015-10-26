using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;
using System.Collections.Generic;

public class GameWorldController : MonoBehaviour {
	List<Material> AnimMaterials=new List<Material>();
	List<int>AnimMaterialsIndex=new List<int>();
	List<string>AnimatedTextures=new List<string>();
	public bool EnableTextureAnimation;
	public GameObject WorldModel;
	public static TextureController tc;

	public Texture2D[] paletteArray= new Texture2D[8];
	public int paletteIndex=0;
	//private Material mattToChange;
	private bool Test;
	// Use this for initialization

	public MeshRenderer ceil;

	void Start () {
		ceil.enabled=true;
		if (EnableTextureAnimation==true)
		{
			//#if UNITY_EDITOR
			//Undo.RegisterUndo(AnimMaterials.ToArray(), "Fix Shared Material");
			//#endif
			InvokeRepeating("UpdateAnimation",0.2f,0.2f);
		}


		return;
		//TODO:Figure out how to import animated textures!
		AnimatedTextures.Add ("uw1_226");
		//Texture2D test = Resources.Load<Texture2D> ("Textures/Palette/UW1_BASE_0226");

		foreach(Transform child in WorldModel.gameObject.transform)
		{
			foreach(Material matt in child.gameObject.GetComponent<Renderer>().sharedMaterials)
			{
				string mattName= matt.name.Substring(0,7);
				if (AnimatedTextures.Contains(mattName ))
				{

					 //matt.SetTexture("_MainTex",test);
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
#if UNITY_EDITOR
			Undo.RegisterUndo(AnimMaterials.ToArray(), "Fix Shared Material");
#endif
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
		Shader.SetGlobalTexture ("_ColorPaletteIn",paletteArray[paletteIndex]);

		if (paletteIndex<paletteArray.GetUpperBound(0))
		{
			paletteIndex++;
		}
		else
		{
			paletteIndex=0;
		}


		return;
		for (int i = 0; i<AnimMaterials.Count;i++)
			{
			//matt.SetTexture("_MainTex",test);
			AnimMaterials[i].SetTexture("_ColorPalette",paletteArray[paletteIndex]);
			//AnimMaterials[i].mainTexture=tc.RequestTexture(AnimMaterialsIndex[i],true);
			}

		if (paletteIndex<7)
		{
			paletteIndex++;
		}
		else
		{
			paletteIndex=0;
		}

	}
}
