using UnityEngine;
using System.Collections;

public class starttest : MonoBehaviour {


	void Awake () {
		GameObject player =GameObject.Find ("Gronk");

		return;
		//Debug.Log ("Moving " + player.name);
		player.transform.position=new Vector3(38.72f,4.152f,3.244f);

		GameObject skul = GameObject.Find ("a_skull_30_03_00_1016");
		//if (skul!=null)
		//{
		string filePath ="c:\\objects_0000.tga";
		//Debug.Log (filePath);
		SpriteRenderer sprt = skul.GetComponentInChildren<SpriteRenderer>();
		//Sprite newimage= new Sprite();
		//Texture2D newtex= new Texture2D(22,11);
		Texture2D newTex = TGALoader.LoadTGA (filePath);
		//newTex.height=newTex.height*2;
		//newTex.width=newTex.width*2;
		Sprite newSprite= Sprite.Create( newTex,new Rect(0,0,newTex.width,newTex.height), new Vector2(0.5f, 0.0f));
		//Sprite newSprite = TGALoader.LoadTGASprite(filePath);e
		sprt.sprite= newSprite;


		GameObject theWallBrotha = GameObject.Find ("Wall_30_03");
		Material[] myMat = theWallBrotha.GetComponent<Renderer>().materials;
		for (int i = 0; i<myMat.GetUpperBound(0);i++)
		{
			//Debug.Log (myMat[i].name);
			myMat[i].mainTexture=newTex;
		}

		Mesh mesh =theWallBrotha.GetComponent<MeshFilter>().mesh;
		Vector3[] vertices = mesh.vertices;
		Vector2[] uvs = new Vector2[vertices.Length];
		int j = 0;
		while (j < uvs.Length) {
			uvs[j] = new Vector2(vertices[j].x, vertices[j].z);
			j++;
		}
		//mesh.uv = uvs;

			//if (newimage!=null)
			//{
				//Debug.Log("New image loaded");
			//}
		//else
			//{
				//Debug.Log("fuck");
			//}
		//}
		//CreateObj();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
