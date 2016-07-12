using UnityEditor;
using UnityEngine;
using System.Collections;
using RAINEditor.Core;
using RAIN.BehaviorTrees;
using RAIN.Core;
using RAIN.Minds;
using RAIN.Navigation;

public class MyTools
{
	private static string _RES = "UW1";
	private static Transform LevelParent= null;
	[MenuItem("MyTools/CreateGameObjects")]
	static void Create()
	{
		GameObject parentObj = GameObject.Find("_LevelObjects");
		if (parentObj!=null)
		{
			LevelParent=parentObj.gameObject.transform;				
		}
		else
		{
			Debug.Log("Transfrom not found");
		}
		

		GameObject myObj;
		Vector3 pos;
		//GameObject invMarker = GameObject.Find("_InventoryMarker");
		//Debug.Log(invMarker.name);
		Container ParentContainer;//For containers
		_RES= "UW1";//Set the game

				/*
				myObj= CreateGameObject("runebag",119.314285f,3.000000f,119.314285f);
				CreateObjectGraphics(myObj,"Sprites/OBJECTS_143",true);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_143", "Sprites/OBJECTS_143", "Sprites/OBJECTS_143", 70, 143, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
				SetObjectAsRuneBag(myObj);
				*/
			/*	myObj= CreateGameObject("a_torch_torches_26_12_00_0605",31.371428f,3.000000f,15.257142f);
				CreateObjectGraphics(myObj,"Sprites/OBJECTS_145",true);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_145", "Sprites/OBJECTS_145", "Sprites/OBJECTS_145", 22, 145, 1, 40, 0, 1, 1, 1, 1, 1, 0, 0, 1);
				CreateLight(myObj, 2, 3, 149, 145);
				*/
			/*	myObj= CreateGameObject("a_map",119.314285f,3.600000f,119.314285f);
				CreateObjectGraphics(myObj,"Sprites/OBJECTS_315",true);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_315", "Sprites/OBJECTS_315", "Sprites/OBJECTS_315", 28, 315, 512, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
				SetMap(myObj);
				*/


				myObj= CreateGameObject("a_breastplate_29_01_07_0586",35.314285f,0.600000f,1.714286f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_034",true);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_034", "UW1/Sprites/Objects/OBJECTS_034", "uw1/Sprites/armour/armor_f_0002", 2, 34, 714, 45, 0, 1, 1, 0, 1, 1, 1, 8, 1);
				CreateArmour(myObj, "uw1/Sprites/armour/armor_f_0002", "uw1/Sprites/armour/armor_m_0002", "uw1/Sprites/armour/armor_f_0017", "uw1/Sprites/armour/armor_m_0017", "uw1/Sprites/armour/armor_f_0032", "uw1/Sprites/armour/armor_m_0032", "uw1/Sprites/armour/armor_f_0047", "uw1/Sprites/armour/armor_m_0047", 6, 34);



				myObj = new GameObject("etherealvoidcreatures_04_03_08_0219");
				pos = new Vector3(5.314286f, 3.375000f, 4.114285f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"79","UW1/Sprites/Objects/OBJECTS_079", 0);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", 0, 79, 0, 4, 3, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 0, 4, 3, 0, 0, 19, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj = new GameObject("unknown_18_03_08_0222");
				pos = new Vector3(22.114285f, 3.300000f, 4.114285f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"126","UW1/Sprites/Objects/OBJECTS_126", 240);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_126", "UW1/Sprites/Objects/OBJECTS_126", "UW1/Sprites/Objects/OBJECTS_126", 0, 126, 0, 18, 3, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 240, 18, 3, 0, 0, 33, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj = new GameObject("etherealvoidcreatures_60_03_08_0199");
				pos = new Vector3(72.514290f, 2.400000f, 4.114285f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"79","UW1/Sprites/Objects/OBJECTS_079", 242);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", 0, 79, 0, 60, 3, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 242, 60, 3, 0, 0, 21, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj = new GameObject("etherealvoidcreatures_59_05_08_0198");
				pos = new Vector3(71.314285f, 2.100000f, 6.514286f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"79","UW1/Sprites/Objects/OBJECTS_079", 242);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", 0, 79, 0, 59, 5, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 242, 59, 5, 0, 0, 13, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj = new GameObject("unknown_13_06_08_0220");
				pos = new Vector3(16.114286f, 2.700000f, 7.714286f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"126","UW1/Sprites/Objects/OBJECTS_126", 246);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_126", "UW1/Sprites/Objects/OBJECTS_126", "UW1/Sprites/Objects/OBJECTS_126", 0, 126, 0, 13, 6, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 246, 13, 6, 0, 0, 36, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj = new GameObject("unknown_21_06_08_0221");
				pos = new Vector3(25.714285f, 3.000000f, 7.714286f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"126","UW1/Sprites/Objects/OBJECTS_126", 240);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_126", "UW1/Sprites/Objects/OBJECTS_126", "UW1/Sprites/Objects/OBJECTS_126", 0, 126, 0, 21, 6, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 240, 21, 6, 0, 0, 35, 0, 0, 8, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj = new GameObject("unknown_26_06_08_0235");
				pos = new Vector3(31.714285f, 2.700000f, 7.714286f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"125","UW1/Sprites/Objects/OBJECTS_125", 241);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", 0, 125, 0, 26, 6, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 241, 26, 6, 0, 0, 0, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj = new GameObject("unknown_43_06_08_0202");
				pos = new Vector3(52.114288f, 2.700000f, 7.714286f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"125","UW1/Sprites/Objects/OBJECTS_125", 243);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", 0, 125, 0, 43, 6, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 243, 43, 6, 0, 0, 17, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj = new GameObject("unknown_55_07_08_0200");
				pos = new Vector3(66.514290f, 2.100000f, 8.914286f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"126","UW1/Sprites/Objects/OBJECTS_126", 241);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_126", "UW1/Sprites/Objects/OBJECTS_126", "UW1/Sprites/Objects/OBJECTS_126", 0, 126, 0, 55, 7, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 241, 55, 7, 0, 0, 36, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj = new GameObject("etherealvoidcreatures_34_08_08_0234");
				pos = new Vector3(41.314285f, 3.600000f, 10.114285f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"79","UW1/Sprites/Objects/OBJECTS_079", 242);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", 0, 79, 0, 34, 8, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 242, 34, 8, 0, 0, 31, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj = new GameObject("etherealvoidcreatures_47_08_08_0201");
				pos = new Vector3(56.914288f, 2.700000f, 10.114285f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"79","UW1/Sprites/Objects/OBJECTS_079", 247);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", 0, 79, 0, 47, 8, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 247, 47, 8, 0, 0, 26, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,270,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj= CreateGameObject("force_field_53_08_08_0938",64.114288f,1.200000f,10.114285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_53_09_08_0939",64.114288f,1.200000f,11.314286f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj = new GameObject("unknown_19_10_08_0241");
				pos = new Vector3(23.314285f, 3.600000f, 12.514286f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"125","UW1/Sprites/Objects/OBJECTS_125", 0);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", 0, 125, 0, 19, 10, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 0, 19, 10, 0, 0, 0, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj= CreateGameObject("force_field_53_10_08_0940",64.114288f,1.200000f,12.514286f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj = new GameObject("unknown_05_11_08_0217");
				pos = new Vector3(7.028571f, 3.010000f, 13.714286f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"125","UW1/Sprites/Objects/OBJECTS_125", 243);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", 0, 125, 0, 5, 11, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 243, 5, 11, 0, 0, 26, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,225,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj= CreateGameObject("force_field_53_11_08_0941",64.114288f,1.200000f,13.714286f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj = new GameObject("unknown_02_12_08_0218");
				pos = new Vector3(2.914286f, 3.000000f, 14.914286f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"125","UW1/Sprites/Objects/OBJECTS_125", 243);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", 0, 125, 0, 2, 12, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 243, 2, 12, 0, 0, 21, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj = new GameObject("unknown_43_12_08_0203");
				pos = new Vector3(52.114288f, 2.400000f, 14.914286f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"125","UW1/Sprites/Objects/OBJECTS_125", 240);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", 0, 125, 0, 43, 12, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 240, 43, 12, 0, 0, 28, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj= CreateGameObject("force_field_53_12_08_0942",64.114288f,1.200000f,14.914286f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj = new GameObject("unknown_45_13_08_0205");
				pos = new Vector3(54.514286f, 2.700000f, 16.114286f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"125","UW1/Sprites/Objects/OBJECTS_125", 240);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", 0, 125, 0, 45, 13, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 240, 45, 13, 0, 0, 37, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj= CreateGameObject("force_field_53_13_08_0943",64.114288f,1.200000f,16.114286f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_48_14_08_0923",58.114288f,2.100000f,17.314285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_53_14_08_0944",64.114288f,1.200000f,17.314285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj = new GameObject("unknown_11_15_08_0215");
				pos = new Vector3(13.714286f, 0.900000f, 18.514286f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"126","UW1/Sprites/Objects/OBJECTS_126", 246);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_126", "UW1/Sprites/Objects/OBJECTS_126", "UW1/Sprites/Objects/OBJECTS_126", 0, 126, 0, 11, 15, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 246, 11, 15, 0, 0, 35, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,315,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj = new GameObject("unknown_28_15_08_0242");
				pos = new Vector3(34.114285f, 1.500000f, 18.514286f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"125","UW1/Sprites/Objects/OBJECTS_125", 243);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", 0, 125, 0, 28, 15, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 243, 28, 15, 0, 0, 29, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj = new GameObject("unknown_43_15_08_0204");
				pos = new Vector3(52.114288f, 2.700000f, 18.514286f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"125","UW1/Sprites/Objects/OBJECTS_125", 240);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", 0, 125, 0, 43, 15, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 240, 43, 15, 0, 0, 19, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj= CreateGameObject("force_field_48_15_08_0924",58.114288f,2.100000f,18.514286f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_53_15_08_0945",64.114288f,1.200000f,18.514286f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);



				myObj= CreateGameObject("a_moongate_13_16_08_1020",16.114286f,0.600000f,19.714287f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_346",true);

				myObj= CreateGameObject("force_field_48_16_08_0925",58.114288f,2.100000f,19.714287f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_53_16_08_0946",64.114288f,2.100000f,19.714287f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj = new GameObject("etherealvoidcreatures_58_16_08_0251");
				pos = new Vector3(70.114288f, 1.800000f, 19.714287f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"79","UW1/Sprites/Objects/OBJECTS_079", 247);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", 0, 79, 0, 58, 16, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 247, 58, 16, 0, 0, 14, 0, 0, 11, 2, 0, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj = new GameObject("unknown_04_17_08_0216");
				pos = new Vector3(5.485714f, 1.800000f, 20.914284f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"125","UW1/Sprites/Objects/OBJECTS_125", 241);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", 0, 125, 0, 4, 17, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 241, 4, 17, 0, 0, 26, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj = new GameObject("unknown_11_17_08_0214");
				pos = new Vector3(13.714286f, 0.900000f, 20.914284f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"126","UW1/Sprites/Objects/OBJECTS_126", 246);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_126", "UW1/Sprites/Objects/OBJECTS_126", "UW1/Sprites/Objects/OBJECTS_126", 0, 126, 0, 11, 17, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 246, 11, 17, 0, 0, 33, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj = new GameObject("etherealvoidcreatures_18_17_08_0249");
				pos = new Vector3(22.114285f, 3.900000f, 20.914284f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"79","UW1/Sprites/Objects/OBJECTS_079", 244);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", 0, 79, 0, 18, 17, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 244, 18, 17, 0, 0, 24, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,90,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj = new GameObject("etherealvoidcreatures_37_17_08_0247");
				pos = new Vector3(44.914288f, 4.200000f, 20.914284f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"79","UW1/Sprites/Objects/OBJECTS_079", 242);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", 0, 79, 0, 37, 17, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 242, 37, 17, 0, 0, 25, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj= CreateGameObject("force_field_48_17_08_0926",58.114288f,2.100000f,20.914284f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_53_17_08_0947",64.114288f,2.100000f,20.914284f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_38_18_08_0937",46.114288f,2.100000f,22.114285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj = new GameObject("etherealvoidcreatures_38_18_08_0246");
				pos = new Vector3(46.114288f, 2.400000f, 22.114285f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"79","UW1/Sprites/Objects/OBJECTS_079", 242);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", 0, 79, 0, 38, 18, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 242, 38, 18, 0, 0, 30, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj= CreateGameObject("force_field_39_18_08_0936",47.314285f,2.100000f,22.114285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_40_18_08_0935",48.514286f,2.100000f,22.114285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_41_18_08_0934",49.714287f,2.100000f,22.114285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_42_18_08_0933",50.914288f,2.100000f,22.114285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_43_18_08_0931",52.114288f,2.100000f,22.114285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_44_18_08_0932",53.314285f,2.100000f,22.114285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_45_18_08_0930",54.514286f,2.100000f,22.114285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_46_18_08_0929",55.714287f,2.100000f,22.114285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_47_18_08_0928",56.914288f,2.100000f,22.114285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_48_18_08_0927",58.114288f,2.100000f,22.114285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_53_18_08_0948",64.114288f,2.100000f,22.114285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_54_18_08_0949",65.314285f,2.100000f,22.114285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj = new GameObject("unknown_28_19_08_0185");
				pos = new Vector3(34.114285f, 1.500000f, 23.314285f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"125","UW1/Sprites/Objects/OBJECTS_125", 240);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", 0, 125, 0, 28, 19, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 240, 28, 19, 0, 0, 25, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj= CreateGameObject("force_field_47_19_08_0903",56.914288f,2.100000f,23.314285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj = new GameObject("unknown_54_19_08_0207");
				pos = new Vector3(65.314285f, 2.100000f, 23.314285f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"126","UW1/Sprites/Objects/OBJECTS_126", 246);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_126", "UW1/Sprites/Objects/OBJECTS_126", "UW1/Sprites/Objects/OBJECTS_126", 0, 126, 0, 54, 19, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 246, 54, 19, 0, 0, 36, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj= CreateGameObject("force_field_55_19_08_0950",66.514290f,2.100000f,23.314285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_56_19_08_0951",67.714287f,2.100000f,23.314285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj = new GameObject("unknown_23_20_08_0186");
				pos = new Vector3(28.114285f, 1.500000f, 24.514284f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"125","UW1/Sprites/Objects/OBJECTS_125", 240);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", 0, 125, 0, 23, 20, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 240, 23, 20, 0, 0, 20, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj = new GameObject("unknown_30_20_08_0191");
				pos = new Vector3(36.514286f, 1.500000f, 24.514284f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"125","UW1/Sprites/Objects/OBJECTS_125", 240);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", 0, 125, 0, 30, 20, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 240, 30, 20, 0, 0, 16, 0, 0, 11, 2, 0, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj = new GameObject("etherealvoidcreatures_45_20_08_0244");
				pos = new Vector3(54.514286f, 2.400000f, 24.514284f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"79","UW1/Sprites/Objects/OBJECTS_079", 244);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", 0, 79, 0, 45, 20, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 244, 45, 20, 0, 0, 14, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,270,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj= CreateGameObject("force_field_47_20_08_0904",56.914288f,2.100000f,24.514284f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj = new GameObject("etherealvoidcreatures_49_20_08_0206");
				pos = new Vector3(59.314285f, 2.400000f, 24.514284f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"79","UW1/Sprites/Objects/OBJECTS_079", 244);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", 0, 79, 0, 49, 20, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 244, 49, 20, 0, 0, 19, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj= CreateGameObject("force_field_56_20_08_0952",67.714287f,2.100000f,24.514284f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj = new GameObject("etherealvoidcreatures_19_21_08_0252");
				pos = new Vector3(23.314285f, 4.200000f, 25.714285f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"79","UW1/Sprites/Objects/OBJECTS_079", 242);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", 0, 79, 0, 19, 21, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 242, 19, 21, 0, 0, 22, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj= CreateGameObject("force_field_47_21_08_0905",56.914288f,2.100000f,25.714285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_56_21_08_0953",67.714287f,2.100000f,25.714285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_40_22_08_0919",48.514286f,2.100000f,26.914284f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_41_22_08_0918",49.714287f,2.100000f,26.914284f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_42_22_08_0917",50.914288f,2.100000f,26.914284f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_46_22_08_0907",55.714287f,2.100000f,26.914284f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_47_22_08_0906",56.914288f,2.100000f,26.914284f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_56_22_08_0954",67.714287f,2.100000f,26.914284f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj = new GameObject("unknown_16_23_08_0253");
				pos = new Vector3(19.714287f, 3.300000f, 28.114285f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"126","UW1/Sprites/Objects/OBJECTS_126", 246);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_126", "UW1/Sprites/Objects/OBJECTS_126", "UW1/Sprites/Objects/OBJECTS_126", 0, 126, 0, 16, 23, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 246, 16, 23, 0, 0, 17, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj = new GameObject("slasher_of_veils_28_23_08_0184");
				pos = new Vector3(34.114285f, 1.500000f, 28.114285f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"124","UW1/Sprites/Objects/OBJECTS_124", 248);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_124", "UW1/Sprites/Objects/OBJECTS_124", "UW1/Sprites/Objects/OBJECTS_124", 0, 124, 0, 28, 23, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 248, 28, 23, 0, 0, 164, 0, 0, 3, 2, 0, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj = new GameObject("unknown_31_23_08_0188");
				pos = new Vector3(37.714283f, 1.500000f, 28.114285f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"125","UW1/Sprites/Objects/OBJECTS_125", 240);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", 0, 125, 0, 31, 23, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 240, 31, 23, 0, 0, 31, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj= CreateGameObject("force_field_40_23_08_0920",48.514286f,2.100000f,28.114285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_46_23_08_0908",55.714287f,2.100000f,28.114285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj = new GameObject("etherealvoidcreatures_49_23_08_0208");
				pos = new Vector3(59.314285f, 2.100000f, 28.114285f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"79","UW1/Sprites/Objects/OBJECTS_079", 242);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", 0, 79, 0, 49, 23, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 242, 49, 23, 0, 0, 11, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj= CreateGameObject("force_field_56_23_08_0955",67.714287f,2.400000f,28.114285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj = new GameObject("etherealvoidcreatures_58_23_08_0197");
				pos = new Vector3(70.114288f, 2.796000f, 28.114285f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"79","UW1/Sprites/Objects/OBJECTS_079", 242);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", 0, 79, 0, 58, 23, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 242, 58, 23, 0, 0, 13, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,135,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj = new GameObject("unknown_23_24_08_0187");
				pos = new Vector3(28.114285f, 1.500000f, 29.485716f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"125","UW1/Sprites/Objects/OBJECTS_125", 240);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", 0, 125, 0, 23, 24, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 240, 23, 24, 0, 0, 33, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,90,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj = new GameObject("unknown_40_24_08_0254");
				pos = new Vector3(48.514286f, 3.000000f, 29.314285f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"126","UW1/Sprites/Objects/OBJECTS_126", 240);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_126", "UW1/Sprites/Objects/OBJECTS_126", "UW1/Sprites/Objects/OBJECTS_126", 0, 126, 0, 40, 24, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 240, 40, 24, 0, 0, 28, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj= CreateGameObject("force_field_40_24_08_0921",48.514286f,2.100000f,29.314285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_46_24_08_0909",55.714287f,2.100000f,29.314285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj = new GameObject("etherealvoidcreatures_48_24_08_0209");
				pos = new Vector3(58.114288f, 2.100000f, 29.314285f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"79","UW1/Sprites/Objects/OBJECTS_079", 242);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", 0, 79, 0, 48, 24, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 242, 48, 24, 0, 0, 20, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj= CreateGameObject("force_field_56_24_08_0956",67.714287f,2.400000f,29.314285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_40_25_08_0922",48.514286f,2.100000f,30.514284f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_46_25_08_0910",55.714287f,2.100000f,30.514284f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_56_25_08_0957",67.714287f,2.400000f,30.514284f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj = new GameObject("etherealvoidcreatures_60_25_08_0196");
				pos = new Vector3(72.514290f, 3.096000f, 30.514284f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"79","UW1/Sprites/Objects/OBJECTS_079", 242);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", 0, 79, 0, 60, 25, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 242, 60, 25, 0, 0, 14, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,225,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj = new GameObject("unknown_40_26_08_0243");
				pos = new Vector3(48.514286f, 3.600000f, 31.714285f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"126","UW1/Sprites/Objects/OBJECTS_126", 240);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_126", "UW1/Sprites/Objects/OBJECTS_126", "UW1/Sprites/Objects/OBJECTS_126", 0, 126, 0, 40, 26, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 240, 40, 26, 0, 0, 28, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj = new GameObject("unknown_44_26_08_0213");
				pos = new Vector3(53.314285f, 1.800000f, 31.714285f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"125","UW1/Sprites/Objects/OBJECTS_125", 243);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", 0, 125, 0, 44, 26, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 243, 44, 26, 0, 0, 25, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj= CreateGameObject("force_field_46_26_08_0911",55.714287f,2.100000f,31.714285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_51_26_08_0963",61.714287f,2.100000f,31.714285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_52_26_08_0962",62.914288f,2.100000f,31.714285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_53_26_08_0961",64.114288f,2.100000f,31.714285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_54_26_08_0960",65.314285f,2.400000f,31.714285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_55_26_08_0959",66.514290f,2.400000f,31.714285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_56_26_08_0958",67.714287f,2.400000f,31.714285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj = new GameObject("etherealvoidcreatures_10_27_08_0233");
				pos = new Vector3(12.514286f, 3.600000f, 32.914284f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"79","UW1/Sprites/Objects/OBJECTS_079", 242);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", 0, 79, 0, 10, 27, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 242, 10, 27, 0, 0, 30, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj = new GameObject("unknown_26_27_08_0189");
				pos = new Vector3(31.714285f, 1.500000f, 32.914284f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"125","UW1/Sprites/Objects/OBJECTS_125", 240);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", 0, 125, 0, 26, 27, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 240, 26, 27, 0, 0, 20, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj = new GameObject("etherealvoidcreatures_33_27_08_0255");
				pos = new Vector3(40.114285f, 2.700000f, 32.914284f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"79","UW1/Sprites/Objects/OBJECTS_079", 242);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", 0, 79, 0, 33, 27, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 242, 33, 27, 0, 0, 28, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj= CreateGameObject("force_field_45_27_08_0913",54.514286f,2.100000f,32.914284f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_46_27_08_0912",55.714287f,2.100000f,32.914284f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_51_27_08_0964",61.714287f,2.400000f,32.914284f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj = new GameObject("unknown_28_28_08_0190");
				pos = new Vector3(34.114285f, 1.500000f, 34.114285f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"125","UW1/Sprites/Objects/OBJECTS_125", 240);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", 0, 125, 0, 28, 28, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 240, 28, 28, 0, 0, 29, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,135,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj = new GameObject("etherealvoidcreatures_31_28_08_0250");
				pos = new Vector3(37.714283f, 2.100000f, 34.114285f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"79","UW1/Sprites/Objects/OBJECTS_079", 242);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", 0, 79, 0, 31, 28, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 242, 31, 28, 0, 0, 19, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj= CreateGameObject("force_field_45_28_08_0914",54.514286f,2.100000f,34.114285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_51_28_08_0965",61.714287f,2.400000f,34.114285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj = new GameObject("etherealvoidcreatures_10_29_08_0232");
				pos = new Vector3(12.514286f, 2.700000f, 35.314285f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"79","UW1/Sprites/Objects/OBJECTS_079", 242);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", 0, 79, 0, 10, 29, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 242, 10, 29, 0, 0, 36, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj= CreateGameObject("force_field_45_29_08_0915",54.514286f,2.100000f,35.314285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_51_29_08_0966",61.714287f,2.400000f,35.314285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj = new GameObject("etherealvoidcreatures_16_30_08_0248");
				pos = new Vector3(19.714287f, 2.700000f, 36.514286f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"79","UW1/Sprites/Objects/OBJECTS_079", 245);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", 0, 79, 0, 16, 30, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 245, 16, 30, 0, 0, 21, 0, 0, 11, 2, 0, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj= CreateGameObject("force_field_45_30_08_0916",54.514286f,2.100000f,36.514286f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_51_30_08_0967",61.714287f,2.400000f,36.514286f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj = new GameObject("unknown_55_30_08_0192");
				pos = new Vector3(66.514290f, 3.600000f, 36.514286f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"125","UW1/Sprites/Objects/OBJECTS_125", 243);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", 0, 125, 0, 55, 30, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 243, 55, 30, 0, 0, 37, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj= CreateGameObject("force_field_21_31_08_0889",25.714285f,2.400000f,37.714283f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_51_31_08_0876",61.714287f,2.400000f,37.714283f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_21_32_08_0890",25.714285f,2.400000f,38.914284f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_51_32_08_0877",61.714287f,2.400000f,38.914284f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_21_33_08_0891",25.714285f,2.400000f,40.114285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj = new GameObject("unknown_44_33_08_0211");
				pos = new Vector3(53.314285f, 3.600000f, 40.114285f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"126","UW1/Sprites/Objects/OBJECTS_126", 240);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_126", "UW1/Sprites/Objects/OBJECTS_126", "UW1/Sprites/Objects/OBJECTS_126", 0, 126, 0, 44, 33, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 240, 44, 33, 0, 0, 31, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj= CreateGameObject("force_field_51_33_08_0878",61.714287f,2.400000f,40.114285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj = new GameObject("unknown_12_34_08_0245");
				pos = new Vector3(14.914286f, 3.000000f, 41.314285f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"126","UW1/Sprites/Objects/OBJECTS_126", 241);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_126", "UW1/Sprites/Objects/OBJECTS_126", "UW1/Sprites/Objects/OBJECTS_126", 0, 126, 0, 12, 34, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 241, 12, 34, 0, 0, 0, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj= CreateGameObject("force_field_21_34_08_0892",25.714285f,1.200000f,41.314285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_21_34_08_0893",25.714285f,2.400000f,41.314285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj = new GameObject("etherealvoidcreatures_22_34_08_0230");
				pos = new Vector3(26.914284f, 2.560000f, 41.314285f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"79","UW1/Sprites/Objects/OBJECTS_079", 244);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", 0, 79, 0, 22, 34, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 244, 22, 34, 0, 0, 27, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj = new GameObject("etherealvoidcreatures_24_34_08_0231");
				pos = new Vector3(29.314285f, 2.560000f, 41.314285f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"79","UW1/Sprites/Objects/OBJECTS_079", 244);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", 0, 79, 0, 24, 34, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 244, 24, 34, 0, 0, 21, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj= CreateGameObject("force_field_51_34_08_0968",61.714287f,2.400000f,41.314285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_12_35_08_0902",14.914286f,2.700000f,42.514286f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_13_35_08_0901",16.114286f,2.400000f,42.514286f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_14_35_08_0900",17.314285f,2.400000f,42.514286f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_15_35_08_0899",18.514286f,2.400000f,42.514286f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_17_35_08_0898",20.914284f,2.400000f,42.514286f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_18_35_08_0897",22.114285f,2.400000f,42.514286f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_19_35_08_0896",23.314285f,2.400000f,42.514286f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_20_35_08_0895",24.514284f,2.400000f,42.514286f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_21_35_08_0894",25.714285f,2.400000f,42.514286f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_50_35_08_0974",60.514286f,2.400000f,42.514286f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_51_35_08_0973",61.714287f,2.400000f,42.514286f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_52_35_08_0972",62.914288f,2.400000f,42.514286f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_53_35_08_0971",64.114288f,2.400000f,42.514286f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_54_35_08_0970",65.314285f,2.400000f,42.514286f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_55_35_08_0969",66.514290f,2.400000f,42.514286f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_20_36_08_0888",24.514284f,2.400000f,43.714287f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj = new GameObject("unknown_41_36_08_0212");
				pos = new Vector3(49.714287f, 3.300000f, 43.714287f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"125","UW1/Sprites/Objects/OBJECTS_125", 241);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", 0, 125, 0, 41, 36, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 241, 41, 36, 0, 0, 35, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj= CreateGameObject("force_field_50_36_08_0975",60.514286f,2.400000f,43.714287f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj = new GameObject("unknown_20_37_08_0226");
				pos = new Vector3(24.514284f, 1.200000f, 44.914288f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"125","UW1/Sprites/Objects/OBJECTS_125", 241);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", 0, 125, 0, 20, 37, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 241, 20, 37, 0, 0, 34, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj= CreateGameObject("force_field_45_37_08_0981",54.514286f,2.400000f,44.914288f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_46_37_08_0980",55.714287f,2.400000f,44.914288f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_47_37_08_0979",56.914288f,2.400000f,44.914288f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_48_37_08_0978",58.114288f,2.400000f,44.914288f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_49_37_08_0977",59.314285f,2.400000f,44.914288f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_50_37_08_0976",60.514286f,2.400000f,44.914288f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj = new GameObject("unknown_50_37_08_0238");
				pos = new Vector3(60.514286f, 3.300000f, 44.914288f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"126","UW1/Sprites/Objects/OBJECTS_126", 240);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_126", "UW1/Sprites/Objects/OBJECTS_126", "UW1/Sprites/Objects/OBJECTS_126", 0, 126, 0, 50, 37, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 240, 50, 37, 0, 0, 20, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj = new GameObject("unknown_59_37_08_0236");
				pos = new Vector3(71.314285f, 3.600000f, 44.914288f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"126","UW1/Sprites/Objects/OBJECTS_126", 240);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_126", "UW1/Sprites/Objects/OBJECTS_126", "UW1/Sprites/Objects/OBJECTS_126", 0, 126, 0, 59, 37, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 240, 59, 37, 0, 0, 13, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj= CreateGameObject("force_field_20_38_08_0887",24.514284f,2.400000f,46.114288f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj = new GameObject("unknown_51_38_08_0237");
				pos = new Vector3(61.714287f, 2.860000f, 46.114288f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"126","UW1/Sprites/Objects/OBJECTS_126", 240);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_126", "UW1/Sprites/Objects/OBJECTS_126", "UW1/Sprites/Objects/OBJECTS_126", 0, 126, 0, 51, 38, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 240, 51, 38, 0, 0, 14, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj= CreateGameObject("force_field_13_39_08_0984",16.114286f,1.200000f,47.314285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_14_39_08_0983",17.314285f,1.200000f,47.314285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_15_39_08_0982",18.514286f,1.200000f,47.314285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_20_39_08_0886",24.514284f,2.400000f,47.314285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_13_40_08_0985",16.114286f,1.200000f,48.514286f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_20_40_08_0884",24.514284f,2.400000f,48.514286f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj = new GameObject("etherealvoidcreatures_57_40_08_0210");
				pos = new Vector3(68.914284f, 2.700000f, 48.514286f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"79","UW1/Sprites/Objects/OBJECTS_079", 245);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", 0, 79, 0, 57, 40, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 245, 57, 40, 0, 0, 13, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj = new GameObject("etherealvoidcreatures_03_41_08_0227");
				pos = new Vector3(4.114285f, 2.100000f, 49.714287f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"79","UW1/Sprites/Objects/OBJECTS_079", 244);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", 0, 79, 0, 3, 41, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 244, 3, 41, 0, 0, 14, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj= CreateGameObject("force_field_13_41_08_0986",16.114286f,1.200000f,49.714287f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_20_41_08_0885",24.514284f,2.400000f,49.714287f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_13_42_08_0987",16.114286f,1.200000f,50.914288f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj = new GameObject("etherealvoidcreatures_17_42_08_0225");
				pos = new Vector3(20.914284f, 2.400000f, 50.914288f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"79","UW1/Sprites/Objects/OBJECTS_079", 242);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", 0, 79, 0, 17, 42, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 242, 17, 42, 0, 0, 19, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj= CreateGameObject("force_field_20_42_08_0883",24.514284f,2.400000f,50.914288f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj = new GameObject("unknown_11_43_08_0228");
				pos = new Vector3(13.714286f, 3.300000f, 52.114288f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"126","UW1/Sprites/Objects/OBJECTS_126", 246);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_126", "UW1/Sprites/Objects/OBJECTS_126", "UW1/Sprites/Objects/OBJECTS_126", 0, 126, 0, 11, 43, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 246, 11, 43, 0, 0, 0, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj= CreateGameObject("force_field_20_43_08_0882",24.514284f,2.400000f,52.114288f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_19_44_08_0881",23.314285f,2.400000f,53.314285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj = new GameObject("etherealvoidcreatures_53_44_08_0193");
				pos = new Vector3(64.285713f, 2.496000f, 53.314285f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"79","UW1/Sprites/Objects/OBJECTS_079", 242);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", "UW1/Sprites/Objects/OBJECTS_079", 0, 79, 0, 53, 44, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 242, 53, 44, 0, 0, 13, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj= CreateGameObject("force_field_18_45_08_0880",22.114285f,2.400000f,54.514286f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj= CreateGameObject("force_field_18_46_08_0879",22.114285f,2.400000f,55.714287f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_365",true);

				myObj = new GameObject("unknown_26_49_08_0229");
				pos = new Vector3(31.714285f, 2.400000f, 59.314285f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"125","UW1/Sprites/Objects/OBJECTS_125", 243);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", 0, 125, 0, 26, 49, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 243, 26, 49, 0, 0, 30, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj = new GameObject("unknown_51_49_08_0194");
				pos = new Vector3(62.057144f, 3.508500f, 59.314285f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"125","UW1/Sprites/Objects/OBJECTS_125", 241);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", 0, 125, 0, 51, 49, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 241, 51, 49, 0, 0, 28, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj = new GameObject("unknown_53_49_08_0195");
				pos = new Vector3(64.114288f, 3.508500f, 59.314285f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"125","UW1/Sprites/Objects/OBJECTS_125", 241);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", 0, 125, 0, 53, 49, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 241, 53, 49, 0, 0, 16, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj = new GameObject("unknown_08_50_08_0224");
				pos = new Vector3(10.114285f, 3.300000f, 60.514286f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"125","UW1/Sprites/Objects/OBJECTS_125", 240);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", 0, 125, 0, 8, 50, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 240, 8, 50, 0, 0, 21, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj = new GameObject("unknown_51_50_08_0239");
				pos = new Vector3(61.714287f, 3.600000f, 60.514286f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"125","UW1/Sprites/Objects/OBJECTS_125", 241);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", 0, 125, 0, 51, 50, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 241, 51, 50, 0, 0, 24, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);

				myObj = new GameObject("unknown_53_50_08_0240");
				pos = new Vector3(64.457146f, 3.600000f, 60.514286f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"125","UW1/Sprites/Objects/OBJECTS_125", 241);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", 0, 125, 0, 53, 50, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 241, 53, 50, 0, 0, 17, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,225,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);


				myObj= CreateGameObject("a_moongate_10_51_08_1019",12.514286f,3.300000f,61.714287f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_346",true);



				myObj= CreateGameObject("a_moongate_52_51_08_1023",62.914288f,3.600000f,61.714287f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_346",true);

				myObj = new GameObject("unknown_08_52_08_0223");
				pos = new Vector3(10.114285f, 3.300000f, 62.914288f);
				myObj.transform.position = pos;
				myObj.transform.parent = LevelParent;
				CreateNPC(myObj,"125","UW1/Sprites/Objects/OBJECTS_125", 240);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", "UW1/Sprites/Objects/OBJECTS_125", 0, 125, 0, 8, 52, 0, 1, 0, 1, 0, 0, 0, 1);
				SetNPCProps(myObj, 240, 8, 52, 0, 0, 0, 0, 0, 11, 2, 1, 0, 0, 0, "_GroundMesh1");
				SetRotation(myObj,0,0,0);
				////Container contents
				ParentContainer = CreateContainer(myObj, 255, 255, 255);


				myObj= CreateGameObject("an_explosion_12_57_08_0988",14.914286f,3.600000f,68.914284f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_450",true);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_450", "UW1/Sprites/Objects/OBJECTS_450", "UW1/Sprites/Objects/OBJECTS_450", 80, 450, 1, 40, 23, 0, 1, 21, 5, 1, 0, 0, 1);
				AddAnimationOverlay(myObj,21,5);

				myObj= CreateGameObject("an_explosion_13_57_08_0994",16.457142f,1.537500f,69.257141f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_450",true);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_450", "UW1/Sprites/Objects/OBJECTS_450", "UW1/Sprites/Objects/OBJECTS_450", 80, 450, 1, 40, 24, 0, 1, 21, 5, 1, 0, 0, 1);
				AddAnimationOverlay(myObj,21,5);

				myObj= CreateGameObject("an_explosion_16_57_08_0992",19.714287f,2.700000f,69.257141f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_450",true);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_450", "UW1/Sprites/Objects/OBJECTS_450", "UW1/Sprites/Objects/OBJECTS_450", 80, 450, 1, 40, 25, 0, 1, 21, 5, 1, 0, 0, 1);
				AddAnimationOverlay(myObj,21,5);

				myObj= CreateGameObject("an_explosion_18_57_08_0995",22.114285f,3.900000f,68.914284f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_450",true);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_450", "UW1/Sprites/Objects/OBJECTS_450", "UW1/Sprites/Objects/OBJECTS_450", 80, 450, 1, 40, 23, 0, 1, 21, 5, 1, 0, 0, 1);
				AddAnimationOverlay(myObj,21,5);

				myObj= CreateGameObject("a_splash_splahes_23_57_08_1007",28.457144f,1.200000f,69.085716f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_454",true);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_454", "UW1/Sprites/Objects/OBJECTS_454", "UW1/Sprites/Objects/OBJECTS_454", 80, 454, 1, 40, 36, 0, 1, 36, 4, 1, 0, 0, 1);
				AddAnimationOverlay(myObj,36,4);

				myObj= CreateGameObject("a_splash_splahes_25_57_08_1005",30.514284f,1.200000f,68.914284f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_454",true);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_454", "UW1/Sprites/Objects/OBJECTS_454", "UW1/Sprites/Objects/OBJECTS_454", 80, 454, 1, 40, 39, 0, 1, 36, 4, 1, 0, 0, 1);
				AddAnimationOverlay(myObj,36,4);

				myObj= CreateGameObject("a_splash_splahes_27_57_08_0998",32.914284f,1.200000f,68.914284f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_454",true);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_454", "UW1/Sprites/Objects/OBJECTS_454", "UW1/Sprites/Objects/OBJECTS_454", 80, 454, 1, 40, 36, 0, 1, 36, 4, 1, 0, 0, 1);
				AddAnimationOverlay(myObj,36,4);

				myObj= CreateGameObject("a_splash_splahes_32_57_08_1001",38.742855f,1.200000f,69.257141f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_454",true);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_454", "UW1/Sprites/Objects/OBJECTS_454", "UW1/Sprites/Objects/OBJECTS_454", 80, 454, 1, 40, 37, 0, 1, 36, 4, 1, 0, 0, 1);
				AddAnimationOverlay(myObj,36,4);

				myObj= CreateGameObject("an_explosion_13_58_08_0997",16.114286f,2.700000f,70.114288f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_450",true);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_450", "UW1/Sprites/Objects/OBJECTS_450", "UW1/Sprites/Objects/OBJECTS_450", 80, 450, 1, 40, 22, 0, 1, 21, 5, 1, 0, 0, 1);
				AddAnimationOverlay(myObj,21,5);

				myObj= CreateGameObject("an_explosion_15_58_08_0990",18.514286f,3.600000f,70.114288f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_450",true);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_450", "UW1/Sprites/Objects/OBJECTS_450", "UW1/Sprites/Objects/OBJECTS_450", 80, 450, 1, 40, 24, 0, 1, 21, 5, 1, 0, 0, 1);
				AddAnimationOverlay(myObj,21,5);


				myObj= CreateGameObject("a_moongate_19_58_08_1018",23.314285f,1.200000f,70.114288f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_346",true);


				myObj= CreateGameObject("a_splash_splahes_24_58_08_1004",29.142857f,1.200000f,70.628571f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_454",true);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_454", "UW1/Sprites/Objects/OBJECTS_454", "UW1/Sprites/Objects/OBJECTS_454", 80, 454, 1, 40, 39, 0, 1, 36, 4, 1, 0, 0, 1);
				AddAnimationOverlay(myObj,36,4);

				myObj= CreateGameObject("a_splash_splahes_28_58_08_1002",34.457142f,1.200000f,69.771431f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_454",true);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_454", "UW1/Sprites/Objects/OBJECTS_454", "UW1/Sprites/Objects/OBJECTS_454", 80, 454, 1, 40, 39, 0, 1, 36, 4, 1, 0, 0, 1);
				AddAnimationOverlay(myObj,36,4);

				myObj= CreateGameObject("a_splash_splahes_30_58_08_1003",37.028572f,1.200000f,70.628571f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_454",true);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_454", "UW1/Sprites/Objects/OBJECTS_454", "UW1/Sprites/Objects/OBJECTS_454", 80, 454, 1, 40, 36, 0, 1, 36, 4, 1, 0, 0, 1);
				AddAnimationOverlay(myObj,36,4);


				myObj= CreateGameObject("a_moongate_32_58_08_1017",38.914284f,1.200000f,70.114288f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_346",true);


				myObj= CreateGameObject("an_explosion_11_59_08_0993",13.714286f,2.100000f,71.314285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_450",true);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_450", "UW1/Sprites/Objects/OBJECTS_450", "UW1/Sprites/Objects/OBJECTS_450", 80, 450, 1, 40, 22, 0, 1, 21, 5, 1, 0, 0, 1);
				AddAnimationOverlay(myObj,21,5);

				myObj= CreateGameObject("an_explosion_14_59_08_0989",16.971428f,3.337500f,70.971428f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_450",true);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_450", "UW1/Sprites/Objects/OBJECTS_450", "UW1/Sprites/Objects/OBJECTS_450", 80, 450, 1, 40, 25, 0, 1, 21, 5, 1, 0, 0, 1);
				AddAnimationOverlay(myObj,21,5);

				myObj= CreateGameObject("an_explosion_16_59_08_0996",20.057142f,2.100000f,70.971428f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_450",true);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_450", "UW1/Sprites/Objects/OBJECTS_450", "UW1/Sprites/Objects/OBJECTS_450", 80, 450, 1, 40, 24, 0, 1, 21, 5, 1, 0, 0, 1);
				AddAnimationOverlay(myObj,21,5);

				myObj= CreateGameObject("an_explosion_19_59_08_0991",23.314285f,3.000000f,71.314285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_450",true);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_450", "UW1/Sprites/Objects/OBJECTS_450", "UW1/Sprites/Objects/OBJECTS_450", 80, 450, 1, 40, 21, 0, 1, 21, 5, 1, 0, 0, 1);
				AddAnimationOverlay(myObj,21,5);

				myObj= CreateGameObject("a_splash_splahes_26_59_08_1008",31.714285f,1.200000f,71.314285f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_454",true);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_454", "UW1/Sprites/Objects/OBJECTS_454", "UW1/Sprites/Objects/OBJECTS_454", 80, 454, 1, 40, 38, 0, 1, 36, 4, 1, 0, 0, 1);
				AddAnimationOverlay(myObj,36,4);

				myObj= CreateGameObject("a_splash_splahes_29_59_08_0999",35.142857f,1.200000f,71.142853f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_454",true);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_454", "UW1/Sprites/Objects/OBJECTS_454", "UW1/Sprites/Objects/OBJECTS_454", 80, 454, 1, 40, 37, 0, 1, 36, 4, 1, 0, 0, 1);
				AddAnimationOverlay(myObj,36,4);

				myObj= CreateGameObject("a_splash_splahes_31_59_08_1006",38.057144f,1.200000f,70.971428f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_454",true);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_454", "UW1/Sprites/Objects/OBJECTS_454", "UW1/Sprites/Objects/OBJECTS_454", 80, 454, 1, 40, 38, 0, 1, 36, 4, 1, 0, 0, 1);
				AddAnimationOverlay(myObj,36,4);

				myObj= CreateGameObject("a_splash_splahes_32_59_08_1000",38.571426f,1.200000f,71.142853f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_454",true);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_454", "UW1/Sprites/Objects/OBJECTS_454", "UW1/Sprites/Objects/OBJECTS_454", 80, 454, 1, 40, 37, 0, 1, 36, 4, 1, 0, 0, 1);
				AddAnimationOverlay(myObj,36,4);

				//UW Triggers and Traps
				myObj= CreateGameObject("a_ward_trap_99_99_08_0009",119.485710f,2.512500f,119.142860f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_393",false);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_393", "UW1/Sprites/Objects/OBJECTS_393", "UW1/Sprites/Objects/OBJECTS_393", 46, 393, 275, 4, 54, 0, 0, 0, 1, 0, 0, 6, 1);
				SetRotation(myObj,0,315,0);
				Create_a_ward_trap(myObj);

				myObj= CreateGameObject("a_ward_trap_99_99_08_0016",119.314285f,1.237500f,119.485710f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_393",false);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_393", "UW1/Sprites/Objects/OBJECTS_393", "UW1/Sprites/Objects/OBJECTS_393", 46, 393, 1004, 16, 6, 0, 0, 0, 1, 1, 0, 6, 1);
				SetRotation(myObj,0,270,0);
				Create_a_ward_trap(myObj);

				myObj= CreateGameObject("a_look_trigger_99_99_08_0034",118.800003f,0.525000f,118.971428f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_419",false);
				CreateTrigger(myObj,48,15,"a_ward_trap_99_99_08_0016");
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_419", "UW1/Sprites/Objects/OBJECTS_419", "UW1/Sprites/Objects/OBJECTS_419", 57, 419, 16, 48, 15, 0, 0, 0, 1, 0, 0, 2, 1);

				myObj= CreateGameObject("a_pit_trap_99_99_08_0046",118.800003f,0.975000f,118.971428f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_388",false);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_388", "UW1/Sprites/Objects/OBJECTS_388", "UW1/Sprites/Objects/OBJECTS_388", 41, 388, 24, 61, 27, 0, 0, 0, 1, 0, 1, 10, 1);
				SetRotation(myObj,0,180,0);
				Create_a_pit_trap(myObj);

				myObj= CreateGameObject("a_do_trap_99_99_08_0757",119.828575f,3.525000f,118.800003f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_387",false);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_387", "UW1/Sprites/Objects/OBJECTS_387", "UW1/Sprites/Objects/OBJECTS_387", 40, 387, 4, 2, 0, 0, 0, 0, 1, 1, 0, 0, 1);
				SetRotation(myObj,0,270,0);
				Create_a_do_trap(myObj,2,0);

				myObj= CreateGameObject("a_teleport_trap_99_99_08_0761",118.800003f,2.437500f,120.000000f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_385",false);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_385", "UW1/Sprites/Objects/OBJECTS_385", "UW1/Sprites/Objects/OBJECTS_385", 38, 385, 0, 3, 0, 0, 0, 0, 1, 1, 0, 1, 1);
				SetRotation(myObj,0,135,0);
				Create_a_teleport_trap(myObj,(float)4.200000,(float)0.600000,(float)4.500000,65);

				myObj= CreateGameObject("a_pick_up_trigger_99_99_08_0775",118.971428f,0.037500f,118.800003f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_417",false);
				CreateTrigger(myObj,63,1,"a_silver_tree_99_99_08_0044");
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_417", "UW1/Sprites/Objects/OBJECTS_417", "UW1/Sprites/Objects/OBJECTS_417", 55, 417, 44, 63, 1, 0, 0, 0, 1, 0, 0, 2, 1);

				myObj= CreateGameObject("a_move_trigger_99_99_08_0848",119.400002f,1.237500f,119.400002f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_416",false);
				CreateMoveTrigger(myObj,0,52,"a_sceptre_99_99_08_0022");
				CreateCollider(myObj,1.20f,1.20f,1.20f);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_416", "UW1/Sprites/Objects/OBJECTS_416", "UW1/Sprites/Objects/OBJECTS_416", 54, 416, 22, 0, 52, 0, 0, 0, 1, 0, 0, 2, 1);

				myObj= CreateGameObject("a_arrow_trap_99_99_08_0870",118.800003f,0.000000f,118.800003f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_386",false);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_386", "UW1/Sprites/Objects/OBJECTS_386", "UW1/Sprites/Objects/OBJECTS_386", 39, 386, 201, 4, 27, 0, 0, 0, 1, 0, 0, 3, 1);
				SetRotation(myObj,0,0,0);
				Create_a_arrow_trap(myObj, 155, 12);

				myObj= CreateGameObject("a_move_trigger_32_58_08_1009",39.000000f,1.200000f,70.199997f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_416",false);
				CreateMoveTrigger(myObj,33,58,"a_teleport_trap_33_58_08_1011");
				CreateCollider(myObj,1.20f,1.20f,1.20f);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_416", "UW1/Sprites/Objects/OBJECTS_416", "UW1/Sprites/Objects/OBJECTS_416", 54, 416, 1011, 33, 58, 0, 0, 0, 1, 1, 0, 6, 1);

				myObj= CreateGameObject("a_move_trigger_19_58_08_1010",23.400000f,1.200000f,70.199997f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_416",false);
				CreateMoveTrigger(myObj,20,58,"a_teleport_trap_20_58_08_1012");
				CreateCollider(myObj,1.20f,1.20f,1.20f);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_416", "UW1/Sprites/Objects/OBJECTS_416", "UW1/Sprites/Objects/OBJECTS_416", 54, 416, 1012, 20, 58, 0, 0, 0, 1, 1, 0, 6, 1);

				myObj= CreateGameObject("a_teleport_trap_33_58_08_1011",39.599998f,0.000000f,69.599998f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_385",false);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_385", "UW1/Sprites/Objects/OBJECTS_385", "UW1/Sprites/Objects/OBJECTS_385", 38, 385, 0, 27, 23, 0, 0, 0, 1, 0, 0, 1, 1);
				SetRotation(myObj,0,0,0);
				Create_a_teleport_trap(myObj,(float)33.000000,(float)28.200000,(float)1.500000,0);

				myObj= CreateGameObject("a_teleport_trap_20_58_08_1012",24.000000f,0.000000f,69.599998f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_385",false);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_385", "UW1/Sprites/Objects/OBJECTS_385", "UW1/Sprites/Objects/OBJECTS_385", 38, 385, 0, 27, 23, 0, 0, 0, 1, 0, 0, 1, 1);
				SetRotation(myObj,0,0,0);
				Create_a_teleport_trap(myObj,(float)33.000000,(float)28.200000,(float)1.500000,0);

				myObj= CreateGameObject("a_teleport_trap_02_16_08_1013",2.400000f,0.000000f,19.200001f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_385",false);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_385", "UW1/Sprites/Objects/OBJECTS_385", "UW1/Sprites/Objects/OBJECTS_385", 38, 385, 0, 23, 58, 0, 0, 0, 1, 0, 0, 1, 1);
				SetRotation(myObj,0,0,0);
				Create_a_teleport_trap(myObj,(float)28.200000,(float)70.200000,(float)1.200000,0);

				myObj= CreateGameObject("a_move_trigger_13_16_08_1014",16.200001f,0.600000f,19.799999f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_416",false);
				CreateMoveTrigger(myObj,2,16,"a_teleport_trap_02_16_08_1013");
				CreateCollider(myObj,1.20f,1.20f,1.20f);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_416", "UW1/Sprites/Objects/OBJECTS_416", "UW1/Sprites/Objects/OBJECTS_416", 54, 416, 1013, 2, 16, 0, 0, 0, 1, 1, 0, 6, 1);

				myObj= CreateGameObject("a_move_trigger_10_51_08_1015",12.600000f,3.300000f,61.799999f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_416",false);
				CreateMoveTrigger(myObj,11,51,"a_teleport_trap_11_51_08_1016");
				CreateCollider(myObj,1.20f,1.20f,1.20f);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_416", "UW1/Sprites/Objects/OBJECTS_416", "UW1/Sprites/Objects/OBJECTS_416", 54, 416, 1016, 11, 51, 0, 0, 0, 1, 1, 0, 6, 1);

				myObj= CreateGameObject("a_teleport_trap_11_51_08_1016",13.200000f,0.000000f,61.200001f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_385",false);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_385", "UW1/Sprites/Objects/OBJECTS_385", "UW1/Sprites/Objects/OBJECTS_385", 38, 385, 0, 10, 58, 0, 0, 0, 1, 0, 0, 1, 1);
				SetRotation(myObj,0,0,0);
				Create_a_teleport_trap(myObj,(float)12.600000,(float)70.200000,(float)1.200000,0);

				myObj= CreateGameObject("a_do_trap_52_54_08_1021",62.400002f,1.200000f,64.800003f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_387",false);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_387", "UW1/Sprites/Objects/OBJECTS_387", "UW1/Sprites/Objects/OBJECTS_387", 40, 387, 0, 63, 0, 0, 0, 0, 1, 1, 0, 1, 1);
				SetRotation(myObj,0,0,0);
				Create_trap_base(myObj);

				myObj= CreateGameObject("a_move_trigger_52_51_08_1022",63.000000f,3.600000f,61.799999f);
				CreateObjectGraphics(myObj,"UW1/Sprites/Objects/OBJECTS_416",false);
				CreateMoveTrigger(myObj,52,54,"a_do_trap_52_54_08_1021");
				CreateCollider(myObj,1.20f,1.20f,1.20f);
				CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "UW1/Sprites/Objects/OBJECTS_416", "UW1/Sprites/Objects/OBJECTS_416", "UW1/Sprites/Objects/OBJECTS_416", 54, 416, 1021, 52, 54, 0, 0, 0, 1, 1, 0, 4, 1);


	}



	/*[MenuItem("MyTools/RenameBrushes")]
	static void BrushRenamer()
	{
		RenameBrushes("world.worldspawn.Brush_1","Tile_30_00");
			
	}*/

//	[MenuItem("MyTools/SetTilemapInfo")]
//	static void SetTileMapInfo()
//	{
//		GameObject tilemapObj = GameObject.Find ("TileMap");
//		TileMap tilemap= tilemapObj.GetComponent<TileMap>();
	
//		Debug.Log ("Tile properties set");


//	}




	[MenuItem("MyTools/CreateAnim-UW1Critters")]
	static void GenerateAnimationAssets_UW1Critters()
	{
		return;
		//TODO: Update export code to include basepath and time.
		//CreateAnimationUW("64_attack_slash", "CR26PAGE_N00_0_0004" , "CR26PAGE_N00_0_0005" , "CR26PAGE_N00_0_0006" , "CR26PAGE_N00_0_0005" , "" , "" , "" , "" ,4,"Sprites/critters",0.4f);
	//	CreateAnimationUW("64_attack_thrust", "CR26PAGE_N00_0_0004" , "CR26PAGE_N00_0_0005" , "CR26PAGE_N00_0_0006" , "CR26PAGE_N00_0_0005" , "" , "" , "" , "" ,4,"Sprites/critters",0.4f);
	//	return;
		//end system shock animations

//		return; //takes a long time to run..
		//Anim ID: 0 - which is a_rotworm
		//	File:c:\games\uw1\crit\CR26PAGE.N00, Palette = 0
/**		CreateAnimationUW("64_combat_idle", "CR26PAGE_N00_0_0000" , "CR26PAGE_N00_0_0001" , "CR26PAGE_N00_0_0002" , "CR26PAGE_N00_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("64_attack_bash", "CR26PAGE_N00_0_0004" , "CR26PAGE_N00_0_0005" , "CR26PAGE_N00_0_0006" , "CR26PAGE_N00_0_0005" , "" , "" , "" , "" ,4);
		CreateAnimationUW("64_walking_towards", "CR26PAGE_N00_0_0000" , "CR26PAGE_N00_0_0001" , "CR26PAGE_N00_0_0002" , "CR26PAGE_N00_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("64_death", "CR26PAGE_N00_0_0004" , "CR26PAGE_N00_0_0007" , "CR26PAGE_N00_0_0008" , "CR26PAGE_N00_0_0008" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR26PAGE.N01, Palette = 0
		CreateAnimationUW("64_idle_rear", "CR26PAGE_N01_0_0000" , "CR26PAGE_N01_0_0000" , "CR26PAGE_N01_0_0000" , "CR26PAGE_N01_0_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("64_idle_rear_right", "CR26PAGE_N01_0_0001" , "CR26PAGE_N01_0_0001" , "CR26PAGE_N01_0_0001" , "CR26PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("64_idle_right", "CR26PAGE_N01_0_0002" , "CR26PAGE_N01_0_0002" , "CR26PAGE_N01_0_0002" , "CR26PAGE_N01_0_0002" , "" , "" , "" , "" ,4);
		CreateAnimationUW("64_idle_front_right", "CR26PAGE_N01_0_0003" , "CR26PAGE_N01_0_0003" , "CR26PAGE_N01_0_0003" , "CR26PAGE_N01_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("64_idle_front", "CR26PAGE_N01_0_0004" , "CR26PAGE_N01_0_0004" , "CR26PAGE_N01_0_0004" , "CR26PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("64_idle_front_left", "CR26PAGE_N01_0_0005" , "CR26PAGE_N01_0_0005" , "CR26PAGE_N01_0_0005" , "CR26PAGE_N01_0_0005" , "" , "" , "" , "" ,4);
		CreateAnimationUW("64_idle_left", "CR26PAGE_N01_0_0006" , "CR26PAGE_N01_0_0006" , "CR26PAGE_N01_0_0006" , "CR26PAGE_N01_0_0006" , "" , "" , "" , "" ,4);
		CreateAnimationUW("64_idle_rear_left", "CR26PAGE_N01_0_0007" , "CR26PAGE_N01_0_0007" , "CR26PAGE_N01_0_0007" , "CR26PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("64_walking_rear", "CR26PAGE_N01_0_0008" , "CR26PAGE_N01_0_0009" , "CR26PAGE_N01_0_0000" , "CR26PAGE_N01_0_0010" , "CR26PAGE_N01_0_0000" , "CR26PAGE_N01_0_0009" , "" , "" ,6);
		CreateAnimationUW("64_walking_rear_right", "CR26PAGE_N01_0_0011" , "CR26PAGE_N01_0_0012" , "CR26PAGE_N01_0_0001" , "CR26PAGE_N01_0_0013" , "CR26PAGE_N01_0_0001" , "CR26PAGE_N01_0_0012" , "" , "" ,6);
		CreateAnimationUW("64_walking_right", "CR26PAGE_N01_0_0002" , "CR26PAGE_N01_0_0014" , "CR26PAGE_N01_0_0015" , "CR26PAGE_N01_0_0016" , "CR26PAGE_N01_0_0015" , "CR26PAGE_N01_0_0014" , "" , "" ,6);
		CreateAnimationUW("64_walking_front_right", "CR26PAGE_N01_0_0017" , "CR26PAGE_N01_0_0003" , "CR26PAGE_N01_0_0018" , "CR26PAGE_N01_0_0019" , "CR26PAGE_N01_0_0018" , "CR26PAGE_N01_0_0003" , "" , "" ,6);
		CreateAnimationUW("64_walking_front", "CR26PAGE_N01_0_0020" , "CR26PAGE_N01_0_0004" , "CR26PAGE_N01_0_0021" , "CR26PAGE_N01_0_0022" , "CR26PAGE_N01_0_0021" , "CR26PAGE_N01_0_0004" , "" , "" ,6);
		CreateAnimationUW("64_walking_front_left", "CR26PAGE_N01_0_0023" , "CR26PAGE_N01_0_0005" , "CR26PAGE_N01_0_0024" , "CR26PAGE_N01_0_0025" , "CR26PAGE_N01_0_0024" , "CR26PAGE_N01_0_0005" , "" , "" ,6);
		CreateAnimationUW("64_walking_left", "CR26PAGE_N01_0_0006" , "CR26PAGE_N01_0_0026" , "CR26PAGE_N01_0_0027" , "CR26PAGE_N01_0_0028" , "CR26PAGE_N01_0_0027" , "CR26PAGE_N01_0_0026" , "" , "" ,6);
		CreateAnimationUW("64_walking_rear_left", "CR26PAGE_N01_0_0007" , "CR26PAGE_N01_0_0029" , "CR26PAGE_N01_0_0030" , "CR26PAGE_N01_0_0031" , "CR26PAGE_N01_0_0030" , "CR26PAGE_N01_0_0029" , "" , "" ,6);
	
		//Anim ID: 1 - which is a_flesh_slug
		//	File:c:\games\uw1\crit\CR11PAGE.N00, Palette = 0
		CreateAnimationUW("65_combat_idle", "CR11PAGE_N00_0_0000" , "CR11PAGE_N00_0_0001" , "CR11PAGE_N00_0_0000" , "CR11PAGE_N00_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("65_attack_bash", "CR11PAGE_N00_0_0000" , "CR11PAGE_N00_0_0002" , "CR11PAGE_N00_0_0000" , "CR11PAGE_N00_0_0002" , "" , "" , "" , "" ,4);
		CreateAnimationUW("65_attack_slash", "CR11PAGE_N00_0_0000" , "CR11PAGE_N00_0_0002" , "CR11PAGE_N00_0_0000" , "CR11PAGE_N00_0_0002" , "" , "" , "" , "" ,4);
		CreateAnimationUW("65_attack_thrust", "CR11PAGE_N00_0_0000" , "CR11PAGE_N00_0_0003" , "CR11PAGE_N00_0_0000" , "CR11PAGE_N00_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("65_walking_towards", "CR11PAGE_N00_0_0001" , "CR11PAGE_N00_0_0005" , "CR11PAGE_N00_0_0002" , "CR11PAGE_N00_0_0005" , "" , "" , "" , "" ,4);
		CreateAnimationUW("65_death", "CR11PAGE_N00_0_0000" , "CR11PAGE_N00_0_0001" , "CR11PAGE_N00_0_0005" , "CR11PAGE_N00_0_0002" , "" , "" , "" , "" ,4);
		CreateAnimationUW("65_begin_combat", "CR11PAGE_N00_0_0001" , "CR11PAGE_N00_0_0005" , "CR11PAGE_N00_0_0002" , "CR11PAGE_N00_0_0005" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR11PAGE.N01, Palette = 0
		CreateAnimationUW("65_idle_rear", "CR11PAGE_N01_0_0000" , "CR11PAGE_N01_0_0000" , "CR11PAGE_N01_0_0000" , "CR11PAGE_N01_0_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("65_idle_rear_right", "CR11PAGE_N01_0_0001" , "CR11PAGE_N01_0_0001" , "CR11PAGE_N01_0_0001" , "CR11PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("65_idle_right", "CR11PAGE_N01_0_0002" , "CR11PAGE_N01_0_0002" , "CR11PAGE_N01_0_0002" , "CR11PAGE_N01_0_0002" , "" , "" , "" , "" ,4);
		CreateAnimationUW("65_idle_front_right", "CR11PAGE_N01_0_0003" , "CR11PAGE_N01_0_0003" , "CR11PAGE_N01_0_0003" , "CR11PAGE_N01_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("65_idle_front", "CR11PAGE_N01_0_0004" , "CR11PAGE_N01_0_0004" , "CR11PAGE_N01_0_0004" , "CR11PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("65_idle_front_left", "CR11PAGE_N01_0_0005" , "CR11PAGE_N01_0_0005" , "CR11PAGE_N01_0_0005" , "CR11PAGE_N01_0_0005" , "" , "" , "" , "" ,4);
		CreateAnimationUW("65_idle_left", "CR11PAGE_N01_0_0006" , "CR11PAGE_N01_0_0006" , "CR11PAGE_N01_0_0006" , "CR11PAGE_N01_0_0006" , "" , "" , "" , "" ,4);
		CreateAnimationUW("65_idle_rear_left", "CR11PAGE_N01_0_0007" , "CR11PAGE_N01_0_0007" , "CR11PAGE_N01_0_0007" , "CR11PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("65_walking_rear", "CR11PAGE_N01_0_0000" , "CR11PAGE_N01_0_0008" , "CR11PAGE_N01_0_0009" , "CR11PAGE_N01_0_0010" , "CR11PAGE_N01_0_0009" , "CR11PAGE_N01_0_0008" , "" , "" ,6);
		CreateAnimationUW("65_walking_rear_right", "CR11PAGE_N01_0_0001" , "CR11PAGE_N01_0_0011" , "CR11PAGE_N01_0_0012" , "CR11PAGE_N01_0_0013" , "CR11PAGE_N01_0_0012" , "CR11PAGE_N01_0_0011" , "" , "" ,6);
		CreateAnimationUW("65_walking_right", "CR11PAGE_N01_0_0002" , "CR11PAGE_N01_0_0014" , "CR11PAGE_N01_0_0015" , "CR11PAGE_N01_0_0016" , "CR11PAGE_N01_0_0015" , "CR11PAGE_N01_0_0014" , "" , "" ,6);
		CreateAnimationUW("65_walking_front_right", "CR11PAGE_N01_0_0003" , "CR11PAGE_N01_0_0017" , "CR11PAGE_N01_0_0018" , "CR11PAGE_N01_0_0019" , "CR11PAGE_N01_0_0018" , "CR11PAGE_N01_0_0017" , "" , "" ,6);
		CreateAnimationUW("65_walking_front", "CR11PAGE_N01_0_0004" , "CR11PAGE_N01_0_0020" , "CR11PAGE_N01_0_0021" , "CR11PAGE_N01_0_0022" , "CR11PAGE_N01_0_0021" , "CR11PAGE_N01_0_0020" , "" , "" ,6);
		CreateAnimationUW("65_walking_front_left", "CR11PAGE_N01_0_0005" , "CR11PAGE_N01_0_0023" , "CR11PAGE_N01_0_0024" , "CR11PAGE_N01_0_0025" , "CR11PAGE_N01_0_0024" , "CR11PAGE_N01_0_0023" , "" , "" ,6);
		CreateAnimationUW("65_walking_left", "CR11PAGE_N01_0_0006" , "CR11PAGE_N01_0_0026" , "CR11PAGE_N01_0_0027" , "CR11PAGE_N01_0_0028" , "CR11PAGE_N01_0_0027" , "CR11PAGE_N01_0_0026" , "" , "" ,6);
		CreateAnimationUW("65_walking_rear_left", "CR11PAGE_N01_0_0007" , "CR11PAGE_N01_0_0029" , "CR11PAGE_N01_0_0030" , "CR11PAGE_N01_0_0031" , "CR11PAGE_N01_0_0030" , "CR11PAGE_N01_0_0029" , "" , "" ,6);
		//Anim ID: 2 - which is a_cave_bat
		//	File:c:\games\uw1\crit\CR03PAGE.N00, Palette = 0
		CreateAnimationUW("66_combat_idle", "CR03PAGE_N00_0_0000" , "CR03PAGE_N00_0_0001" , "CR03PAGE_N00_0_0002" , "CR03PAGE_N00_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("66_attack_bash", "CR03PAGE_N00_0_0003" , "CR03PAGE_N00_0_0001" , "CR03PAGE_N00_0_0004" , "CR03PAGE_N00_0_0005" , "CR03PAGE_N00_0_0000" , "" , "" , "" ,5);
		CreateAnimationUW("66_attack_slash", "CR03PAGE_N00_0_0003" , "CR03PAGE_N00_0_0005" , "CR03PAGE_N00_0_0000" , "CR03PAGE_N00_0_0005" , "CR03PAGE_N00_0_0001" , "" , "" , "" ,5);
		CreateAnimationUW("66_attack_thrust", "CR03PAGE_N00_0_0002" , "CR03PAGE_N00_0_0001" , "CR03PAGE_N00_0_0004" , "CR03PAGE_N00_0_0005" , "CR03PAGE_N00_0_0004" , "" , "" , "" ,5);
		CreateAnimationUW("66_walking_towards", "CR03PAGE_N00_0_0000" , "CR03PAGE_N00_0_0002" , "CR03PAGE_N00_0_0001" , "CR03PAGE_N00_0_0002" , "" , "" , "" , "" ,4);
		CreateAnimationUW("66_death", "CR03PAGE_N00_0_0006" , "CR03PAGE_N00_0_0007" , "CR03PAGE_N00_0_0008" , "CR03PAGE_N00_0_0009" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR03PAGE.N01, Palette = 0
		CreateAnimationUW("66_idle_rear", "CR03PAGE_N01_0_0000" , "CR03PAGE_N01_0_0001" , "CR03PAGE_N01_0_0002" , "CR03PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("66_idle_rear_right", "CR03PAGE_N01_0_0003" , "CR03PAGE_N01_0_0004" , "CR03PAGE_N01_0_0005" , "CR03PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("66_idle_right", "CR03PAGE_N01_0_0006" , "CR03PAGE_N01_0_0007" , "CR03PAGE_N01_0_0008" , "CR03PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("66_idle_front_right", "CR03PAGE_N01_0_0009" , "CR03PAGE_N01_0_0010" , "CR03PAGE_N01_0_0011" , "CR03PAGE_N01_0_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("66_idle_front", "CR03PAGE_N01_0_0012" , "CR03PAGE_N01_0_0013" , "CR03PAGE_N01_0_0014" , "CR03PAGE_N01_0_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("66_idle_front_left", "CR03PAGE_N01_0_0015" , "CR03PAGE_N01_0_0016" , "CR03PAGE_N01_0_0017" , "CR03PAGE_N01_0_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("66_idle_left", "CR03PAGE_N01_0_0018" , "CR03PAGE_N01_0_0019" , "CR03PAGE_N01_0_0020" , "CR03PAGE_N01_0_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("66_idle_rear_left", "CR03PAGE_N01_0_0021" , "CR03PAGE_N01_0_0022" , "CR03PAGE_N01_0_0023" , "CR03PAGE_N01_0_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("66_walking_rear", "CR03PAGE_N01_0_0000" , "CR03PAGE_N01_0_0001" , "CR03PAGE_N01_0_0002" , "CR03PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("66_walking_rear_right", "CR03PAGE_N01_0_0003" , "CR03PAGE_N01_0_0004" , "CR03PAGE_N01_0_0005" , "CR03PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("66_walking_right", "CR03PAGE_N01_0_0006" , "CR03PAGE_N01_0_0007" , "CR03PAGE_N01_0_0008" , "CR03PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("66_walking_front_right", "CR03PAGE_N01_0_0009" , "CR03PAGE_N01_0_0010" , "CR03PAGE_N01_0_0011" , "CR03PAGE_N01_0_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("66_walking_front", "CR03PAGE_N01_0_0012" , "CR03PAGE_N01_0_0013" , "CR03PAGE_N01_0_0014" , "CR03PAGE_N01_0_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("66_walking_front_left", "CR03PAGE_N01_0_0015" , "CR03PAGE_N01_0_0016" , "CR03PAGE_N01_0_0017" , "CR03PAGE_N01_0_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("66_walking_left", "CR03PAGE_N01_0_0018" , "CR03PAGE_N01_0_0019" , "CR03PAGE_N01_0_0020" , "CR03PAGE_N01_0_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("66_walking_rear_left", "CR03PAGE_N01_0_0021" , "CR03PAGE_N01_0_0022" , "CR03PAGE_N01_0_0023" , "CR03PAGE_N01_0_0022" , "" , "" , "" , "" ,4);
		//Anim ID: 3 - which is a_giant_rat
		//	File:c:\games\uw1\crit\CR20PAGE.N00, Palette = 0
		CreateAnimationUW("67_combat_idle", "CR20PAGE_N00_0_0000" , "CR20PAGE_N00_0_0001" , "CR20PAGE_N00_0_0000" , "CR20PAGE_N00_0_0002" , "" , "" , "" , "" ,4);
		CreateAnimationUW("67_attack_bash", "CR20PAGE_N00_0_0003" , "CR20PAGE_N00_0_0004" , "CR20PAGE_N00_0_0005" , "CR20PAGE_N00_0_0006" , "CR20PAGE_N00_0_0007" , "" , "" , "" ,5);
		CreateAnimationUW("67_attack_slash", "CR20PAGE_N00_0_0000" , "CR20PAGE_N00_0_0008" , "CR20PAGE_N00_0_0009" , "CR20PAGE_N00_0_0001" , "CR20PAGE_N00_0_0010" , "" , "" , "" ,5);
		CreateAnimationUW("67_attack_thrust", "CR20PAGE_N00_0_0009" , "CR20PAGE_N00_0_0010" , "CR20PAGE_N00_0_0004" , "CR20PAGE_N00_0_0005" , "CR20PAGE_N00_0_0007" , "" , "" , "" ,5);
		CreateAnimationUW("67_walking_towards", "CR20PAGE_N00_0_0000" , "CR20PAGE_N00_0_0011" , "CR20PAGE_N00_0_0012" , "CR20PAGE_N00_0_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("67_death", "CR20PAGE_N00_0_0001" , "CR20PAGE_N00_0_0002" , "CR20PAGE_N00_0_0014" , "CR20PAGE_N00_0_0015" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR20PAGE.N01, Palette = 0
		CreateAnimationUW("67_idle_rear", "CR20PAGE_N01_0_0000" , "CR20PAGE_N01_0_0001" , "CR20PAGE_N01_0_0002" , "CR20PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("67_idle_rear_right", "CR20PAGE_N01_0_0003" , "CR20PAGE_N01_0_0004" , "CR20PAGE_N01_0_0005" , "CR20PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("67_idle_right", "CR20PAGE_N01_0_0006" , "CR20PAGE_N01_0_0007" , "CR20PAGE_N01_0_0008" , "CR20PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("67_idle_front_right", "CR20PAGE_N01_0_0009" , "CR20PAGE_N01_0_0010" , "CR20PAGE_N01_0_0011" , "CR20PAGE_N01_0_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("67_idle_front", "CR20PAGE_N01_0_0012" , "CR20PAGE_N01_0_0013" , "CR20PAGE_N01_0_0014" , "CR20PAGE_N01_0_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("67_idle_front_left", "CR20PAGE_N01_0_0015" , "CR20PAGE_N01_0_0016" , "CR20PAGE_N01_0_0017" , "CR20PAGE_N01_0_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("67_idle_left", "CR20PAGE_N01_0_0018" , "CR20PAGE_N01_0_0019" , "CR20PAGE_N01_0_0020" , "CR20PAGE_N01_0_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("67_idle_rear_left", "CR20PAGE_N01_0_0021" , "CR20PAGE_N01_0_0022" , "CR20PAGE_N01_0_0023" , "CR20PAGE_N01_0_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("67_walking_rear", "CR20PAGE_N01_0_0001" , "CR20PAGE_N01_0_0024" , "CR20PAGE_N01_0_0025" , "CR20PAGE_N01_0_0026" , "" , "" , "" , "" ,4);
		CreateAnimationUW("67_walking_rear_right", "CR20PAGE_N01_0_0004" , "CR20PAGE_N01_0_0027" , "CR20PAGE_N01_0_0028" , "CR20PAGE_N01_0_0029" , "" , "" , "" , "" ,4);
		CreateAnimationUW("67_walking_right", "CR20PAGE_N01_0_0030" , "CR20PAGE_N01_0_0007" , "CR20PAGE_N01_0_0031" , "CR20PAGE_N01_0_0032" , "" , "" , "" , "" ,4);
		CreateAnimationUW("67_walking_front_right", "CR20PAGE_N01_0_0033" , "CR20PAGE_N01_0_0010" , "CR20PAGE_N01_0_0034" , "CR20PAGE_N01_0_0035" , "" , "" , "" , "" ,4);
		CreateAnimationUW("67_walking_front", "CR20PAGE_N01_0_0013" , "CR20PAGE_N01_0_0036" , "CR20PAGE_N01_0_0037" , "CR20PAGE_N01_0_0038" , "" , "" , "" , "" ,4);
		CreateAnimationUW("67_walking_front_left", "CR20PAGE_N01_0_0039" , "CR20PAGE_N01_0_0016" , "CR20PAGE_N01_0_0040" , "CR20PAGE_N01_0_0041" , "" , "" , "" , "" ,4);
		CreateAnimationUW("67_walking_left", "CR20PAGE_N01_0_0042" , "CR20PAGE_N01_0_0019" , "CR20PAGE_N01_0_0043" , "CR20PAGE_N01_0_0044" , "" , "" , "" , "" ,4);
		CreateAnimationUW("67_walking_rear_left", "CR20PAGE_N01_0_0022" , "CR20PAGE_N01_0_0045" , "CR20PAGE_N01_0_0046" , "CR20PAGE_N01_0_0047" , "" , "" , "" , "" ,4);
		//Anim ID: 4 - which is a_giant_spider
		//	File:c:\games\uw1\crit\CR05PAGE.N00, Palette = 0
		CreateAnimationUW("68_combat_idle", "CR05PAGE_N00_0_0000" , "CR05PAGE_N00_0_0001" , "CR05PAGE_N00_0_0000" , "CR05PAGE_N00_0_0002" , "" , "" , "" , "" ,4);
		CreateAnimationUW("68_attack_bash", "CR05PAGE_N00_0_0003" , "CR05PAGE_N00_0_0004" , "CR05PAGE_N00_0_0005" , "CR05PAGE_N00_0_0006" , "CR05PAGE_N00_0_0004" , "" , "" , "" ,5);
		CreateAnimationUW("68_attack_slash", "CR05PAGE_N00_0_0000" , "CR05PAGE_N00_0_0007" , "CR05PAGE_N00_0_0008" , "CR05PAGE_N00_0_0009" , "CR05PAGE_N00_0_0010" , "" , "" , "" ,5);
		CreateAnimationUW("68_attack_thrust", "CR05PAGE_N00_0_0001" , "CR05PAGE_N00_0_0011" , "CR05PAGE_N00_0_0003" , "CR05PAGE_N00_0_0004" , "CR05PAGE_N00_0_0003" , "" , "" , "" ,5);
		CreateAnimationUW("68_walking_towards", "CR05PAGE_N00_0_0012" , "CR05PAGE_N00_0_0013" , "CR05PAGE_N00_0_0000" , "CR05PAGE_N00_0_0014" , "" , "" , "" , "" ,4);
		CreateAnimationUW("68_death", "CR05PAGE_N00_0_0000" , "CR05PAGE_N00_0_0011" , "CR05PAGE_N00_0_0015" , "CR05PAGE_N00_0_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("68_begin_combat", "CR05PAGE_N00_0_0003" , "CR05PAGE_N00_0_0004" , "CR05PAGE_N00_0_0005" , "CR05PAGE_N00_0_0006" , "CR05PAGE_N00_0_0003" , "" , "" , "" ,5);
		//	File:c:\games\uw1\crit\CR05PAGE.N01, Palette = 0
		CreateAnimationUW("68_idle_rear", "CR05PAGE_N01_0_0000" , "CR05PAGE_N01_0_0000" , "CR05PAGE_N01_0_0000" , "CR05PAGE_N01_0_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("68_idle_rear_right", "CR05PAGE_N01_0_0001" , "CR05PAGE_N01_0_0001" , "CR05PAGE_N01_0_0001" , "CR05PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("68_idle_right", "CR05PAGE_N01_0_0002" , "CR05PAGE_N01_0_0002" , "CR05PAGE_N01_0_0002" , "CR05PAGE_N01_0_0002" , "" , "" , "" , "" ,4);
		CreateAnimationUW("68_idle_front_right", "CR05PAGE_N01_0_0003" , "CR05PAGE_N01_0_0003" , "CR05PAGE_N01_0_0003" , "CR05PAGE_N01_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("68_idle_front", "CR05PAGE_N01_0_0004" , "CR05PAGE_N01_0_0004" , "CR05PAGE_N01_0_0004" , "CR05PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("68_idle_front_left", "CR05PAGE_N01_0_0005" , "CR05PAGE_N01_0_0005" , "CR05PAGE_N01_0_0005" , "CR05PAGE_N01_0_0005" , "" , "" , "" , "" ,4);
		CreateAnimationUW("68_idle_left", "CR05PAGE_N01_0_0006" , "CR05PAGE_N01_0_0006" , "CR05PAGE_N01_0_0006" , "CR05PAGE_N01_0_0006" , "" , "" , "" , "" ,4);
		CreateAnimationUW("68_idle_rear_left", "CR05PAGE_N01_0_0007" , "CR05PAGE_N01_0_0007" , "CR05PAGE_N01_0_0007" , "CR05PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("68_walking_rear", "CR05PAGE_N01_0_0000" , "CR05PAGE_N01_0_0008" , "CR05PAGE_N01_0_0009" , "CR05PAGE_N01_0_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("68_walking_rear_right", "CR05PAGE_N01_0_0011" , "CR05PAGE_N01_0_0012" , "CR05PAGE_N01_0_0001" , "CR05PAGE_N01_0_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("68_walking_right", "CR05PAGE_N01_0_0002" , "CR05PAGE_N01_0_0014" , "CR05PAGE_N01_0_0015" , "CR05PAGE_N01_0_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("68_walking_front_right", "CR05PAGE_N01_0_0003" , "CR05PAGE_N01_0_0017" , "CR05PAGE_N01_0_0018" , "CR05PAGE_N01_0_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("68_walking_front", "CR05PAGE_N01_0_0020" , "CR05PAGE_N01_0_0021" , "CR05PAGE_N01_0_0004" , "CR05PAGE_N01_0_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("68_walking_front_left", "CR05PAGE_N01_0_0005" , "CR05PAGE_N01_0_0023" , "CR05PAGE_N01_0_0024" , "CR05PAGE_N01_0_0025" , "" , "" , "" , "" ,4);
		CreateAnimationUW("68_walking_left", "CR05PAGE_N01_0_0006" , "CR05PAGE_N01_0_0026" , "CR05PAGE_N01_0_0027" , "CR05PAGE_N01_0_0028" , "" , "" , "" , "" ,4);
		CreateAnimationUW("68_walking_rear_left", "CR05PAGE_N01_0_0029" , "CR05PAGE_N01_0_0030" , "CR05PAGE_N01_0_0007" , "CR05PAGE_N01_0_0031" , "" , "" , "" , "" ,4);
		//Anim ID: 5 - which is a_acid_slug
		//	File:c:\games\uw1\crit\CR11PAGE.N00, Palette = 1
		CreateAnimationUW("69_combat_idle", "CR11PAGE_N00_1_0000" , "CR11PAGE_N00_1_0001" , "CR11PAGE_N00_1_0000" , "CR11PAGE_N00_1_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("69_attack_bash", "CR11PAGE_N00_1_0000" , "CR11PAGE_N00_1_0002" , "CR11PAGE_N00_1_0000" , "CR11PAGE_N00_1_0002" , "" , "" , "" , "" ,4);
		CreateAnimationUW("69_attack_slash", "CR11PAGE_N00_1_0000" , "CR11PAGE_N00_1_0002" , "CR11PAGE_N00_1_0000" , "CR11PAGE_N00_1_0002" , "" , "" , "" , "" ,4);
		CreateAnimationUW("69_attack_thrust", "CR11PAGE_N00_1_0000" , "CR11PAGE_N00_1_0003" , "CR11PAGE_N00_1_0000" , "CR11PAGE_N00_1_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("69_walking_towards", "CR11PAGE_N00_1_0001" , "CR11PAGE_N00_1_0005" , "CR11PAGE_N00_1_0002" , "CR11PAGE_N00_1_0005" , "" , "" , "" , "" ,4);
		CreateAnimationUW("69_death", "CR11PAGE_N00_1_0000" , "CR11PAGE_N00_1_0001" , "CR11PAGE_N00_1_0005" , "CR11PAGE_N00_1_0002" , "" , "" , "" , "" ,4);
		CreateAnimationUW("69_begin_combat", "CR11PAGE_N00_1_0001" , "CR11PAGE_N00_1_0005" , "CR11PAGE_N00_1_0002" , "CR11PAGE_N00_1_0005" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR11PAGE.N01, Palette = 1
		CreateAnimationUW("69_idle_rear", "CR11PAGE_N01_1_0000" , "CR11PAGE_N01_1_0000" , "CR11PAGE_N01_1_0000" , "CR11PAGE_N01_1_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("69_idle_rear_right", "CR11PAGE_N01_1_0001" , "CR11PAGE_N01_1_0001" , "CR11PAGE_N01_1_0001" , "CR11PAGE_N01_1_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("69_idle_right", "CR11PAGE_N01_1_0002" , "CR11PAGE_N01_1_0002" , "CR11PAGE_N01_1_0002" , "CR11PAGE_N01_1_0002" , "" , "" , "" , "" ,4);
		CreateAnimationUW("69_idle_front_right", "CR11PAGE_N01_1_0003" , "CR11PAGE_N01_1_0003" , "CR11PAGE_N01_1_0003" , "CR11PAGE_N01_1_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("69_idle_front", "CR11PAGE_N01_1_0004" , "CR11PAGE_N01_1_0004" , "CR11PAGE_N01_1_0004" , "CR11PAGE_N01_1_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("69_idle_front_left", "CR11PAGE_N01_1_0005" , "CR11PAGE_N01_1_0005" , "CR11PAGE_N01_1_0005" , "CR11PAGE_N01_1_0005" , "" , "" , "" , "" ,4);
		CreateAnimationUW("69_idle_left", "CR11PAGE_N01_1_0006" , "CR11PAGE_N01_1_0006" , "CR11PAGE_N01_1_0006" , "CR11PAGE_N01_1_0006" , "" , "" , "" , "" ,4);
		CreateAnimationUW("69_idle_rear_left", "CR11PAGE_N01_1_0007" , "CR11PAGE_N01_1_0007" , "CR11PAGE_N01_1_0007" , "CR11PAGE_N01_1_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("69_walking_rear", "CR11PAGE_N01_1_0000" , "CR11PAGE_N01_1_0008" , "CR11PAGE_N01_1_0009" , "CR11PAGE_N01_1_0010" , "CR11PAGE_N01_1_0009" , "CR11PAGE_N01_1_0008" , "" , "" ,6);
		CreateAnimationUW("69_walking_rear_right", "CR11PAGE_N01_1_0001" , "CR11PAGE_N01_1_0011" , "CR11PAGE_N01_1_0012" , "CR11PAGE_N01_1_0013" , "CR11PAGE_N01_1_0012" , "CR11PAGE_N01_1_0011" , "" , "" ,6);
		CreateAnimationUW("69_walking_right", "CR11PAGE_N01_1_0002" , "CR11PAGE_N01_1_0014" , "CR11PAGE_N01_1_0015" , "CR11PAGE_N01_1_0016" , "CR11PAGE_N01_1_0015" , "CR11PAGE_N01_1_0014" , "" , "" ,6);
		CreateAnimationUW("69_walking_front_right", "CR11PAGE_N01_1_0003" , "CR11PAGE_N01_1_0017" , "CR11PAGE_N01_1_0018" , "CR11PAGE_N01_1_0019" , "CR11PAGE_N01_1_0018" , "CR11PAGE_N01_1_0017" , "" , "" ,6);
		CreateAnimationUW("69_walking_front", "CR11PAGE_N01_1_0004" , "CR11PAGE_N01_1_0020" , "CR11PAGE_N01_1_0021" , "CR11PAGE_N01_1_0022" , "CR11PAGE_N01_1_0021" , "CR11PAGE_N01_1_0020" , "" , "" ,6);
		CreateAnimationUW("69_walking_front_left", "CR11PAGE_N01_1_0005" , "CR11PAGE_N01_1_0023" , "CR11PAGE_N01_1_0024" , "CR11PAGE_N01_1_0025" , "CR11PAGE_N01_1_0024" , "CR11PAGE_N01_1_0023" , "" , "" ,6);
		CreateAnimationUW("69_walking_left", "CR11PAGE_N01_1_0006" , "CR11PAGE_N01_1_0026" , "CR11PAGE_N01_1_0027" , "CR11PAGE_N01_1_0028" , "CR11PAGE_N01_1_0027" , "CR11PAGE_N01_1_0026" , "" , "" ,6);
		CreateAnimationUW("69_walking_rear_left", "CR11PAGE_N01_1_0007" , "CR11PAGE_N01_1_0029" , "CR11PAGE_N01_1_0030" , "CR11PAGE_N01_1_0031" , "CR11PAGE_N01_1_0030" , "CR11PAGE_N01_1_0029" , "" , "" ,6);
		//Anim ID: 6 - which is a_goblin
		//	File:c:\games\uw1\crit\CR00PAGE.N00, Palette = 0
		CreateAnimationUW("70_combat_idle", "CR00PAGE_N00_0_0000" , "CR00PAGE_N00_0_0001" , "CR00PAGE_N00_0_0000" , "CR00PAGE_N00_0_0002" , "" , "" , "" , "" ,4);
		CreateAnimationUW("70_attack_bash", "CR00PAGE_N00_0_0003" , "CR00PAGE_N00_0_0004" , "CR00PAGE_N00_0_0005" , "CR00PAGE_N00_0_0006" , "CR00PAGE_N00_0_0007" , "" , "" , "" ,5);
		CreateAnimationUW("70_attack_slash", "CR00PAGE_N00_0_0000" , "CR00PAGE_N00_0_0008" , "CR00PAGE_N00_0_0009" , "CR00PAGE_N00_0_0010" , "CR00PAGE_N00_0_0009" , "" , "" , "" ,5);
		CreateAnimationUW("70_attack_thrust", "CR00PAGE_N00_0_0000" , "CR00PAGE_N00_0_0011" , "CR00PAGE_N00_0_0012" , "CR00PAGE_N00_0_0013" , "CR00PAGE_N00_0_0014" , "" , "" , "" ,5);
		CreateAnimationUW("70_attack_secondary", "CR00PAGE_N00_0_0015" , "CR00PAGE_N00_0_0016" , "CR00PAGE_N00_0_0017" , "CR00PAGE_N00_0_0018" , "CR00PAGE_N00_0_0019" , "" , "" , "" ,5);
		CreateAnimationUW("70_walking_towards", "CR00PAGE_N00_0_0020" , "CR00PAGE_N00_0_0021" , "CR00PAGE_N00_0_0022" , "CR00PAGE_N00_0_0023" , "" , "" , "" , "" ,4);
		CreateAnimationUW("70_death", "CR00PAGE_N00_0_0024" , "CR00PAGE_N00_0_0025" , "CR00PAGE_N00_0_0026" , "CR00PAGE_N00_0_0027" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR00PAGE.N01, Palette = 0
		CreateAnimationUW("70_idle_rear", "CR00PAGE_N01_0_0000" , "CR00PAGE_N01_0_0001" , "CR00PAGE_N01_0_0002" , "CR00PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("70_idle_rear_right", "CR00PAGE_N01_0_0003" , "CR00PAGE_N01_0_0004" , "CR00PAGE_N01_0_0005" , "CR00PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("70_idle_right", "CR00PAGE_N01_0_0006" , "CR00PAGE_N01_0_0007" , "CR00PAGE_N01_0_0008" , "CR00PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("70_idle_front_right", "CR00PAGE_N01_0_0009" , "CR00PAGE_N01_0_0010" , "CR00PAGE_N01_0_0011" , "CR00PAGE_N01_0_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("70_idle_front", "CR00PAGE_N01_0_0012" , "CR00PAGE_N01_0_0013" , "CR00PAGE_N01_0_0014" , "CR00PAGE_N01_0_0015" , "" , "" , "" , "" ,4);
		CreateAnimationUW("70_idle_front_left", "CR00PAGE_N01_0_0016" , "CR00PAGE_N01_0_0017" , "CR00PAGE_N01_0_0018" , "CR00PAGE_N01_0_0017" , "" , "" , "" , "" ,4);
		CreateAnimationUW("70_idle_left", "CR00PAGE_N01_0_0019" , "CR00PAGE_N01_0_0020" , "CR00PAGE_N01_0_0021" , "CR00PAGE_N01_0_0020" , "" , "" , "" , "" ,4);
		CreateAnimationUW("70_idle_rear_left", "CR00PAGE_N01_0_0022" , "CR00PAGE_N01_0_0023" , "CR00PAGE_N01_0_0024" , "CR00PAGE_N01_0_0023" , "" , "" , "" , "" ,4);
		CreateAnimationUW("70_walking_rear", "CR00PAGE_N01_0_0025" , "CR00PAGE_N01_0_0026" , "CR00PAGE_N01_0_0027" , "CR00PAGE_N01_0_0028" , "" , "" , "" , "" ,4);
		CreateAnimationUW("70_walking_rear_right", "CR00PAGE_N01_0_0029" , "CR00PAGE_N01_0_0030" , "CR00PAGE_N01_0_0031" , "CR00PAGE_N01_0_0032" , "" , "" , "" , "" ,4);
		CreateAnimationUW("70_walking_right", "CR00PAGE_N01_0_0033" , "CR00PAGE_N01_0_0034" , "CR00PAGE_N01_0_0035" , "CR00PAGE_N01_0_0036" , "" , "" , "" , "" ,4);
		CreateAnimationUW("70_walking_front_right", "CR00PAGE_N01_0_0037" , "CR00PAGE_N01_0_0038" , "CR00PAGE_N01_0_0039" , "CR00PAGE_N01_0_0040" , "" , "" , "" , "" ,4);
		CreateAnimationUW("70_walking_front", "CR00PAGE_N01_0_0041" , "CR00PAGE_N01_0_0042" , "CR00PAGE_N01_0_0043" , "CR00PAGE_N01_0_0044" , "" , "" , "" , "" ,4);
		CreateAnimationUW("70_walking_front_left", "CR00PAGE_N01_0_0045" , "CR00PAGE_N01_0_0046" , "CR00PAGE_N01_0_0047" , "CR00PAGE_N01_0_0048" , "" , "" , "" , "" ,4);
		CreateAnimationUW("70_walking_left", "CR00PAGE_N01_0_0049" , "CR00PAGE_N01_0_0050" , "CR00PAGE_N01_0_0051" , "CR00PAGE_N01_0_0052" , "" , "" , "" , "" ,4);
		CreateAnimationUW("70_walking_rear_left", "CR00PAGE_N01_0_0053" , "CR00PAGE_N01_0_0053" , "CR00PAGE_N01_0_0054" , "CR00PAGE_N01_0_0054" , "" , "" , "" , "" ,4);
		//Anim ID: 7 - which is a_goblin
		//	File:c:\games\uw1\crit\CR16PAGE.N00, Palette = 0
		CreateAnimationUW("71_combat_idle", "CR16PAGE_N00_0_0000" , "CR16PAGE_N00_0_0001" , "CR16PAGE_N00_0_0000" , "CR16PAGE_N00_0_0002" , "" , "" , "" , "" ,4);
		CreateAnimationUW("71_attack_bash", "CR16PAGE_N00_0_0003" , "CR16PAGE_N00_0_0004" , "CR16PAGE_N00_0_0005" , "CR16PAGE_N00_0_0006" , "CR16PAGE_N00_0_0007" , "" , "" , "" ,5);
		CreateAnimationUW("71_attack_slash", "CR16PAGE_N00_0_0000" , "CR16PAGE_N00_0_0008" , "CR16PAGE_N00_0_0009" , "CR16PAGE_N00_0_0010" , "CR16PAGE_N00_0_0011" , "" , "" , "" ,5);
		CreateAnimationUW("71_attack_thrust", "CR16PAGE_N00_0_0000" , "CR16PAGE_N00_0_0012" , "CR16PAGE_N00_0_0013" , "CR16PAGE_N00_0_0014" , "CR16PAGE_N00_0_0015" , "" , "" , "" ,5);
		CreateAnimationUW("71_walking_towards", "CR16PAGE_N00_0_0016" , "CR16PAGE_N00_0_0017" , "CR16PAGE_N00_0_0018" , "CR16PAGE_N00_0_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("71_death", "CR16PAGE_N00_0_0020" , "CR16PAGE_N00_0_0021" , "CR16PAGE_N00_0_0022" , "CR16PAGE_N00_0_0023" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR16PAGE.N01, Palette = 0
		CreateAnimationUW("71_idle_rear", "CR16PAGE_N01_0_0000" , "CR16PAGE_N01_0_0001" , "CR16PAGE_N01_0_0002" , "CR16PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("71_idle_rear_right", "CR16PAGE_N01_0_0003" , "CR16PAGE_N01_0_0004" , "CR16PAGE_N01_0_0005" , "CR16PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("71_idle_right", "CR16PAGE_N01_0_0006" , "CR16PAGE_N01_0_0007" , "CR16PAGE_N01_0_0008" , "CR16PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("71_idle_front_right", "CR16PAGE_N01_0_0009" , "CR16PAGE_N01_0_0010" , "CR16PAGE_N01_0_0011" , "CR16PAGE_N01_0_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("71_idle_front", "CR16PAGE_N01_0_0012" , "CR16PAGE_N01_0_0013" , "CR16PAGE_N01_0_0014" , "CR16PAGE_N01_0_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("71_idle_front_left", "CR16PAGE_N01_0_0015" , "CR16PAGE_N01_0_0016" , "CR16PAGE_N01_0_0017" , "CR16PAGE_N01_0_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("71_idle_left", "CR16PAGE_N01_0_0018" , "CR16PAGE_N01_0_0019" , "CR16PAGE_N01_0_0020" , "CR16PAGE_N01_0_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("71_idle_rear_left", "CR16PAGE_N01_0_0021" , "CR16PAGE_N01_0_0022" , "CR16PAGE_N01_0_0023" , "CR16PAGE_N01_0_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("71_walking_rear", "CR16PAGE_N01_0_0024" , "CR16PAGE_N01_0_0025" , "CR16PAGE_N01_0_0026" , "CR16PAGE_N01_0_0027" , "" , "" , "" , "" ,4);
		CreateAnimationUW("71_walking_rear_right", "CR16PAGE_N01_0_0028" , "CR16PAGE_N01_0_0029" , "CR16PAGE_N01_0_0030" , "CR16PAGE_N01_0_0031" , "" , "" , "" , "" ,4);
		CreateAnimationUW("71_walking_right", "CR16PAGE_N01_0_0032" , "CR16PAGE_N01_0_0033" , "CR16PAGE_N01_0_0034" , "CR16PAGE_N01_0_0035" , "" , "" , "" , "" ,4);
		CreateAnimationUW("71_walking_front_right", "CR16PAGE_N01_0_0036" , "CR16PAGE_N01_0_0037" , "CR16PAGE_N01_0_0038" , "CR16PAGE_N01_0_0039" , "" , "" , "" , "" ,4);
		CreateAnimationUW("71_walking_front", "CR16PAGE_N01_0_0040" , "CR16PAGE_N01_0_0041" , "CR16PAGE_N01_0_0042" , "CR16PAGE_N01_0_0043" , "" , "" , "" , "" ,4);
		CreateAnimationUW("71_walking_front_left", "CR16PAGE_N01_0_0044" , "CR16PAGE_N01_0_0045" , "CR16PAGE_N01_0_0046" , "CR16PAGE_N01_0_0047" , "" , "" , "" , "" ,4);
		CreateAnimationUW("71_walking_left", "CR16PAGE_N01_0_0048" , "CR16PAGE_N01_0_0049" , "CR16PAGE_N01_0_0050" , "CR16PAGE_N01_0_0051" , "" , "" , "" , "" ,4);
		CreateAnimationUW("71_walking_rear_left", "CR16PAGE_N01_0_0052" , "CR16PAGE_N01_0_0053" , "CR16PAGE_N01_0_0054" , "CR16PAGE_N01_0_0055" , "" , "" , "" , "" ,4);
		//Anim ID: 8 - which is a_giant_rat
		//	File:c:\games\uw1\crit\CR20PAGE.N00, Palette = 1
		CreateAnimationUW("72_combat_idle", "CR20PAGE_N00_1_0000" , "CR20PAGE_N00_1_0001" , "CR20PAGE_N00_1_0000" , "CR20PAGE_N00_1_0002" , "" , "" , "" , "" ,4);
		CreateAnimationUW("72_attack_bash", "CR20PAGE_N00_1_0003" , "CR20PAGE_N00_1_0004" , "CR20PAGE_N00_1_0005" , "CR20PAGE_N00_1_0006" , "CR20PAGE_N00_1_0007" , "" , "" , "" ,5);
		CreateAnimationUW("72_attack_slash", "CR20PAGE_N00_1_0000" , "CR20PAGE_N00_1_0008" , "CR20PAGE_N00_1_0009" , "CR20PAGE_N00_1_0001" , "CR20PAGE_N00_1_0010" , "" , "" , "" ,5);
		CreateAnimationUW("72_attack_thrust", "CR20PAGE_N00_1_0009" , "CR20PAGE_N00_1_0010" , "CR20PAGE_N00_1_0004" , "CR20PAGE_N00_1_0005" , "CR20PAGE_N00_1_0007" , "" , "" , "" ,5);
		CreateAnimationUW("72_walking_towards", "CR20PAGE_N00_1_0000" , "CR20PAGE_N00_1_0011" , "CR20PAGE_N00_1_0012" , "CR20PAGE_N00_1_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("72_death", "CR20PAGE_N00_1_0001" , "CR20PAGE_N00_1_0002" , "CR20PAGE_N00_1_0014" , "CR20PAGE_N00_1_0015" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR20PAGE.N01, Palette = 1
		CreateAnimationUW("72_idle_rear", "CR20PAGE_N01_1_0000" , "CR20PAGE_N01_1_0001" , "CR20PAGE_N01_1_0002" , "CR20PAGE_N01_1_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("72_idle_rear_right", "CR20PAGE_N01_1_0003" , "CR20PAGE_N01_1_0004" , "CR20PAGE_N01_1_0005" , "CR20PAGE_N01_1_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("72_idle_right", "CR20PAGE_N01_1_0006" , "CR20PAGE_N01_1_0007" , "CR20PAGE_N01_1_0008" , "CR20PAGE_N01_1_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("72_idle_front_right", "CR20PAGE_N01_1_0009" , "CR20PAGE_N01_1_0010" , "CR20PAGE_N01_1_0011" , "CR20PAGE_N01_1_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("72_idle_front", "CR20PAGE_N01_1_0012" , "CR20PAGE_N01_1_0013" , "CR20PAGE_N01_1_0014" , "CR20PAGE_N01_1_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("72_idle_front_left", "CR20PAGE_N01_1_0015" , "CR20PAGE_N01_1_0016" , "CR20PAGE_N01_1_0017" , "CR20PAGE_N01_1_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("72_idle_left", "CR20PAGE_N01_1_0018" , "CR20PAGE_N01_1_0019" , "CR20PAGE_N01_1_0020" , "CR20PAGE_N01_1_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("72_idle_rear_left", "CR20PAGE_N01_1_0021" , "CR20PAGE_N01_1_0022" , "CR20PAGE_N01_1_0023" , "CR20PAGE_N01_1_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("72_walking_rear", "CR20PAGE_N01_1_0001" , "CR20PAGE_N01_1_0024" , "CR20PAGE_N01_1_0025" , "CR20PAGE_N01_1_0026" , "" , "" , "" , "" ,4);
		CreateAnimationUW("72_walking_rear_right", "CR20PAGE_N01_1_0004" , "CR20PAGE_N01_1_0027" , "CR20PAGE_N01_1_0028" , "CR20PAGE_N01_1_0029" , "" , "" , "" , "" ,4);
		CreateAnimationUW("72_walking_right", "CR20PAGE_N01_1_0030" , "CR20PAGE_N01_1_0007" , "CR20PAGE_N01_1_0031" , "CR20PAGE_N01_1_0032" , "" , "" , "" , "" ,4);
		CreateAnimationUW("72_walking_front_right", "CR20PAGE_N01_1_0033" , "CR20PAGE_N01_1_0010" , "CR20PAGE_N01_1_0034" , "CR20PAGE_N01_1_0035" , "" , "" , "" , "" ,4);
		CreateAnimationUW("72_walking_front", "CR20PAGE_N01_1_0013" , "CR20PAGE_N01_1_0036" , "CR20PAGE_N01_1_0037" , "CR20PAGE_N01_1_0038" , "" , "" , "" , "" ,4);
		CreateAnimationUW("72_walking_front_left", "CR20PAGE_N01_1_0039" , "CR20PAGE_N01_1_0016" , "CR20PAGE_N01_1_0040" , "CR20PAGE_N01_1_0041" , "" , "" , "" , "" ,4);
		CreateAnimationUW("72_walking_left", "CR20PAGE_N01_1_0042" , "CR20PAGE_N01_1_0019" , "CR20PAGE_N01_1_0043" , "CR20PAGE_N01_1_0044" , "" , "" , "" , "" ,4);
		CreateAnimationUW("72_walking_rear_left", "CR20PAGE_N01_1_0022" , "CR20PAGE_N01_1_0045" , "CR20PAGE_N01_1_0046" , "CR20PAGE_N01_1_0047" , "" , "" , "" , "" ,4);
		//Anim ID: 9 - which is a_vampire_bat
		//	File:c:\games\uw1\crit\CR03PAGE.N00, Palette = 1
		CreateAnimationUW("73_combat_idle", "CR03PAGE_N00_1_0000" , "CR03PAGE_N00_1_0001" , "CR03PAGE_N00_1_0002" , "CR03PAGE_N00_1_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("73_attack_bash", "CR03PAGE_N00_1_0003" , "CR03PAGE_N00_1_0001" , "CR03PAGE_N00_1_0004" , "CR03PAGE_N00_1_0005" , "CR03PAGE_N00_1_0000" , "" , "" , "" ,5);
		CreateAnimationUW("73_attack_slash", "CR03PAGE_N00_1_0003" , "CR03PAGE_N00_1_0005" , "CR03PAGE_N00_1_0000" , "CR03PAGE_N00_1_0005" , "CR03PAGE_N00_1_0001" , "" , "" , "" ,5);
		CreateAnimationUW("73_attack_thrust", "CR03PAGE_N00_1_0002" , "CR03PAGE_N00_1_0001" , "CR03PAGE_N00_1_0004" , "CR03PAGE_N00_1_0005" , "CR03PAGE_N00_1_0004" , "" , "" , "" ,5);
		CreateAnimationUW("73_walking_towards", "CR03PAGE_N00_1_0000" , "CR03PAGE_N00_1_0002" , "CR03PAGE_N00_1_0001" , "CR03PAGE_N00_1_0002" , "" , "" , "" , "" ,4);
		CreateAnimationUW("73_death", "CR03PAGE_N00_1_0006" , "CR03PAGE_N00_1_0007" , "CR03PAGE_N00_1_0008" , "CR03PAGE_N00_1_0009" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR03PAGE.N01, Palette = 1
		CreateAnimationUW("73_idle_rear", "CR03PAGE_N01_1_0000" , "CR03PAGE_N01_1_0001" , "CR03PAGE_N01_1_0002" , "CR03PAGE_N01_1_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("73_idle_rear_right", "CR03PAGE_N01_1_0003" , "CR03PAGE_N01_1_0004" , "CR03PAGE_N01_1_0005" , "CR03PAGE_N01_1_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("73_idle_right", "CR03PAGE_N01_1_0006" , "CR03PAGE_N01_1_0007" , "CR03PAGE_N01_1_0008" , "CR03PAGE_N01_1_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("73_idle_front_right", "CR03PAGE_N01_1_0009" , "CR03PAGE_N01_1_0010" , "CR03PAGE_N01_1_0011" , "CR03PAGE_N01_1_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("73_idle_front", "CR03PAGE_N01_1_0012" , "CR03PAGE_N01_1_0013" , "CR03PAGE_N01_1_0014" , "CR03PAGE_N01_1_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("73_idle_front_left", "CR03PAGE_N01_1_0015" , "CR03PAGE_N01_1_0016" , "CR03PAGE_N01_1_0017" , "CR03PAGE_N01_1_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("73_idle_left", "CR03PAGE_N01_1_0018" , "CR03PAGE_N01_1_0019" , "CR03PAGE_N01_1_0020" , "CR03PAGE_N01_1_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("73_idle_rear_left", "CR03PAGE_N01_1_0021" , "CR03PAGE_N01_1_0022" , "CR03PAGE_N01_1_0023" , "CR03PAGE_N01_1_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("73_walking_rear", "CR03PAGE_N01_1_0000" , "CR03PAGE_N01_1_0001" , "CR03PAGE_N01_1_0002" , "CR03PAGE_N01_1_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("73_walking_rear_right", "CR03PAGE_N01_1_0003" , "CR03PAGE_N01_1_0004" , "CR03PAGE_N01_1_0005" , "CR03PAGE_N01_1_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("73_walking_right", "CR03PAGE_N01_1_0006" , "CR03PAGE_N01_1_0007" , "CR03PAGE_N01_1_0008" , "CR03PAGE_N01_1_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("73_walking_front_right", "CR03PAGE_N01_1_0009" , "CR03PAGE_N01_1_0010" , "CR03PAGE_N01_1_0011" , "CR03PAGE_N01_1_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("73_walking_front", "CR03PAGE_N01_1_0012" , "CR03PAGE_N01_1_0013" , "CR03PAGE_N01_1_0014" , "CR03PAGE_N01_1_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("73_walking_front_left", "CR03PAGE_N01_1_0015" , "CR03PAGE_N01_1_0016" , "CR03PAGE_N01_1_0017" , "CR03PAGE_N01_1_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("73_walking_left", "CR03PAGE_N01_1_0018" , "CR03PAGE_N01_1_0019" , "CR03PAGE_N01_1_0020" , "CR03PAGE_N01_1_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("73_walking_rear_left", "CR03PAGE_N01_1_0021" , "CR03PAGE_N01_1_0022" , "CR03PAGE_N01_1_0023" , "CR03PAGE_N01_1_0022" , "" , "" , "" , "" ,4);
		//Anim ID: 10 - which is a_skeleton
		//	File:c:\games\uw1\crit\CR01PAGE.N00, Palette = 0
		CreateAnimationUW("74_combat_idle", "CR01PAGE_N00_0_0000" , "CR01PAGE_N00_0_0001" , "CR01PAGE_N00_0_0002" , "CR01PAGE_N00_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("74_attack_bash", "CR01PAGE_N00_0_0001" , "CR01PAGE_N00_0_0000" , "CR01PAGE_N00_0_0003" , "CR01PAGE_N00_0_0004" , "CR01PAGE_N00_0_0005" , "" , "" , "" ,5);
		CreateAnimationUW("74_attack_slash", "CR01PAGE_N00_0_0001" , "CR01PAGE_N00_0_0006" , "CR01PAGE_N00_0_0007" , "CR01PAGE_N00_0_0008" , "CR01PAGE_N00_0_0009" , "" , "" , "" ,5);
		CreateAnimationUW("74_attack_thrust", "CR01PAGE_N00_0_0001" , "CR01PAGE_N00_0_0002" , "CR01PAGE_N00_0_0003" , "CR01PAGE_N00_0_0004" , "CR01PAGE_N00_0_0005" , "" , "" , "" ,5);
		CreateAnimationUW("74_walking_towards", "CR01PAGE_N00_0_0010" , "CR01PAGE_N00_0_0011" , "CR01PAGE_N00_0_0012" , "CR01PAGE_N00_0_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("74_death", "CR01PAGE_N00_0_0001" , "CR01PAGE_N00_0_0014" , "CR01PAGE_N00_0_0015" , "CR01PAGE_N00_0_0016" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR01PAGE.N01, Palette = 0
		CreateAnimationUW("74_idle_rear", "CR01PAGE_N01_0_0000" , "CR01PAGE_N01_0_0001" , "CR01PAGE_N01_0_0002" , "CR01PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("74_idle_rear_right", "CR01PAGE_N01_0_0003" , "CR01PAGE_N01_0_0004" , "CR01PAGE_N01_0_0005" , "CR01PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("74_idle_right", "CR01PAGE_N01_0_0006" , "CR01PAGE_N01_0_0007" , "CR01PAGE_N01_0_0008" , "CR01PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("74_idle_front_right", "CR01PAGE_N01_0_0009" , "CR01PAGE_N01_0_0010" , "CR01PAGE_N01_0_0011" , "CR01PAGE_N01_0_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("74_idle_front", "CR01PAGE_N01_0_0012" , "CR01PAGE_N01_0_0013" , "CR01PAGE_N01_0_0014" , "CR01PAGE_N01_0_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("74_idle_front_left", "CR01PAGE_N01_0_0015" , "CR01PAGE_N01_0_0016" , "CR01PAGE_N01_0_0017" , "CR01PAGE_N01_0_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("74_idle_left", "CR01PAGE_N01_0_0018" , "CR01PAGE_N01_0_0019" , "CR01PAGE_N01_0_0020" , "CR01PAGE_N01_0_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("74_idle_rear_left", "CR01PAGE_N01_0_0021" , "CR01PAGE_N01_0_0022" , "CR01PAGE_N01_0_0023" , "CR01PAGE_N01_0_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("74_walking_rear", "CR01PAGE_N01_0_0001" , "CR01PAGE_N01_0_0024" , "CR01PAGE_N01_0_0025" , "CR01PAGE_N01_0_0026" , "" , "" , "" , "" ,4);
		CreateAnimationUW("74_walking_rear_right", "CR01PAGE_N01_0_0027" , "CR01PAGE_N01_0_0028" , "CR01PAGE_N01_0_0004" , "CR01PAGE_N01_0_0029" , "" , "" , "" , "" ,4);
		CreateAnimationUW("74_walking_right", "CR01PAGE_N01_0_0007" , "CR01PAGE_N01_0_0030" , "CR01PAGE_N01_0_0031" , "CR01PAGE_N01_0_0032" , "" , "" , "" , "" ,4);
		CreateAnimationUW("74_walking_front_right", "CR01PAGE_N01_0_0010" , "CR01PAGE_N01_0_0033" , "CR01PAGE_N01_0_0034" , "CR01PAGE_N01_0_0035" , "" , "" , "" , "" ,4);
		CreateAnimationUW("74_walking_front", "CR01PAGE_N01_0_0013" , "CR01PAGE_N01_0_0036" , "CR01PAGE_N01_0_0037" , "CR01PAGE_N01_0_0038" , "" , "" , "" , "" ,4);
		CreateAnimationUW("74_walking_front_left", "CR01PAGE_N01_0_0039" , "CR01PAGE_N01_0_0040" , "CR01PAGE_N01_0_0016" , "CR01PAGE_N01_0_0041" , "" , "" , "" , "" ,4);
		CreateAnimationUW("74_walking_left", "CR01PAGE_N01_0_0042" , "CR01PAGE_N01_0_0043" , "CR01PAGE_N01_0_0019" , "CR01PAGE_N01_0_0044" , "" , "" , "" , "" ,4);
		CreateAnimationUW("74_walking_rear_left", "CR01PAGE_N01_0_0022" , "CR01PAGE_N01_0_0045" , "CR01PAGE_N01_0_0046" , "CR01PAGE_N01_0_0047" , "" , "" , "" , "" ,4);
		//Anim ID: 11 - which is an_imp
		//	File:c:\games\uw1\crit\CR22PAGE.N00, Palette = 0
		CreateAnimationUW("75_combat_idle", "CR22PAGE_N00_0_0000" , "CR22PAGE_N00_0_0001" , "CR22PAGE_N00_0_0002" , "CR22PAGE_N00_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("75_attack_bash", "CR22PAGE_N00_0_0004" , "CR22PAGE_N00_0_0005" , "CR22PAGE_N00_0_0006" , "CR22PAGE_N00_0_0007" , "CR22PAGE_N00_0_0004" , "" , "" , "" ,5);
		CreateAnimationUW("75_attack_slash", "CR22PAGE_N00_0_0008" , "CR22PAGE_N00_0_0009" , "CR22PAGE_N00_0_0010" , "CR22PAGE_N00_0_0011" , "CR22PAGE_N00_0_0012" , "" , "" , "" ,5);
		CreateAnimationUW("75_attack_thrust", "CR22PAGE_N00_0_0004" , "CR22PAGE_N00_0_0005" , "CR22PAGE_N00_0_0006" , "CR22PAGE_N00_0_0007" , "CR22PAGE_N00_0_0004" , "" , "" , "" ,5);
		CreateAnimationUW("75_walking_towards", "CR22PAGE_N00_0_0000" , "CR22PAGE_N00_0_0001" , "CR22PAGE_N00_0_0002" , "CR22PAGE_N00_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("75_death", "CR22PAGE_N00_0_0013" , "CR22PAGE_N00_0_0014" , "CR22PAGE_N00_0_0015" , "CR22PAGE_N00_0_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("75_begin_combat", "CR22PAGE_N00_0_0004" , "CR22PAGE_N00_0_0005" , "CR22PAGE_N00_0_0006" , "CR22PAGE_N00_0_0007" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR22PAGE.N01, Palette = 0
		CreateAnimationUW("75_idle_rear", "CR22PAGE_N01_0_0000" , "CR22PAGE_N01_0_0001" , "CR22PAGE_N01_0_0002" , "CR22PAGE_N01_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("75_idle_rear_right", "CR22PAGE_N01_0_0004" , "CR22PAGE_N01_0_0005" , "CR22PAGE_N01_0_0006" , "CR22PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("75_idle_right", "CR22PAGE_N01_0_0008" , "CR22PAGE_N01_0_0009" , "CR22PAGE_N01_0_0010" , "CR22PAGE_N01_0_0011" , "" , "" , "" , "" ,4);
		CreateAnimationUW("75_idle_front_right", "CR22PAGE_N01_0_0012" , "CR22PAGE_N01_0_0013" , "CR22PAGE_N01_0_0014" , "CR22PAGE_N01_0_0015" , "" , "" , "" , "" ,4);
		CreateAnimationUW("75_idle_front", "CR22PAGE_N01_0_0016" , "CR22PAGE_N01_0_0017" , "CR22PAGE_N01_0_0018" , "CR22PAGE_N01_0_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("75_idle_front_left", "CR22PAGE_N01_0_0020" , "CR22PAGE_N01_0_0021" , "CR22PAGE_N01_0_0022" , "CR22PAGE_N01_0_0023" , "" , "" , "" , "" ,4);
		CreateAnimationUW("75_idle_left", "CR22PAGE_N01_0_0024" , "CR22PAGE_N01_0_0025" , "CR22PAGE_N01_0_0026" , "CR22PAGE_N01_0_0027" , "" , "" , "" , "" ,4);
		CreateAnimationUW("75_idle_rear_left", "CR22PAGE_N01_0_0028" , "CR22PAGE_N01_0_0029" , "CR22PAGE_N01_0_0030" , "CR22PAGE_N01_0_0031" , "" , "" , "" , "" ,4);
		CreateAnimationUW("75_walking_rear", "CR22PAGE_N01_0_0000" , "CR22PAGE_N01_0_0001" , "CR22PAGE_N01_0_0002" , "CR22PAGE_N01_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("75_walking_rear_right", "CR22PAGE_N01_0_0004" , "CR22PAGE_N01_0_0005" , "CR22PAGE_N01_0_0006" , "CR22PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("75_walking_right", "CR22PAGE_N01_0_0008" , "CR22PAGE_N01_0_0009" , "CR22PAGE_N01_0_0010" , "CR22PAGE_N01_0_0011" , "" , "" , "" , "" ,4);
		CreateAnimationUW("75_walking_front_right", "CR22PAGE_N01_0_0012" , "CR22PAGE_N01_0_0013" , "CR22PAGE_N01_0_0014" , "CR22PAGE_N01_0_0015" , "" , "" , "" , "" ,4);
		CreateAnimationUW("75_walking_front", "CR22PAGE_N01_0_0016" , "CR22PAGE_N01_0_0017" , "CR22PAGE_N01_0_0018" , "CR22PAGE_N01_0_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("75_walking_front_left", "CR22PAGE_N01_0_0020" , "CR22PAGE_N01_0_0021" , "CR22PAGE_N01_0_0022" , "CR22PAGE_N01_0_0023" , "" , "" , "" , "" ,4);
		CreateAnimationUW("75_walking_left", "CR22PAGE_N01_0_0024" , "CR22PAGE_N01_0_0025" , "CR22PAGE_N01_0_0026" , "CR22PAGE_N01_0_0027" , "" , "" , "" , "" ,4);
		CreateAnimationUW("75_walking_rear_left", "CR22PAGE_N01_0_0028" , "CR22PAGE_N01_0_0029" , "CR22PAGE_N01_0_0030" , "CR22PAGE_N01_0_0031" , "" , "" , "" , "" ,4);
		//Anim ID: 12 - which is a_goblin
		//	File:c:\games\uw1\crit\CR00PAGE.N00, Palette = 1
		CreateAnimationUW("76_combat_idle", "CR00PAGE_N00_1_0000" , "CR00PAGE_N00_1_0001" , "CR00PAGE_N00_1_0000" , "CR00PAGE_N00_1_0002" , "" , "" , "" , "" ,4);
		CreateAnimationUW("76_attack_bash", "CR00PAGE_N00_1_0003" , "CR00PAGE_N00_1_0004" , "CR00PAGE_N00_1_0005" , "CR00PAGE_N00_1_0006" , "CR00PAGE_N00_1_0007" , "" , "" , "" ,5);
		CreateAnimationUW("76_attack_slash", "CR00PAGE_N00_1_0000" , "CR00PAGE_N00_1_0008" , "CR00PAGE_N00_1_0009" , "CR00PAGE_N00_1_0010" , "CR00PAGE_N00_1_0009" , "" , "" , "" ,5);
		CreateAnimationUW("76_attack_thrust", "CR00PAGE_N00_1_0000" , "CR00PAGE_N00_1_0011" , "CR00PAGE_N00_1_0012" , "CR00PAGE_N00_1_0013" , "CR00PAGE_N00_1_0014" , "" , "" , "" ,5);
		CreateAnimationUW("76_attack_secondary", "CR00PAGE_N00_1_0015" , "CR00PAGE_N00_1_0016" , "CR00PAGE_N00_1_0017" , "CR00PAGE_N00_1_0018" , "CR00PAGE_N00_1_0019" , "" , "" , "" ,5);
		CreateAnimationUW("76_walking_towards", "CR00PAGE_N00_1_0020" , "CR00PAGE_N00_1_0021" , "CR00PAGE_N00_1_0022" , "CR00PAGE_N00_1_0023" , "" , "" , "" , "" ,4);
		CreateAnimationUW("76_death", "CR00PAGE_N00_1_0024" , "CR00PAGE_N00_1_0025" , "CR00PAGE_N00_1_0026" , "CR00PAGE_N00_1_0027" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR00PAGE.N01, Palette = 1
		CreateAnimationUW("76_idle_rear", "CR00PAGE_N01_1_0000" , "CR00PAGE_N01_1_0001" , "CR00PAGE_N01_1_0002" , "CR00PAGE_N01_1_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("76_idle_rear_right", "CR00PAGE_N01_1_0003" , "CR00PAGE_N01_1_0004" , "CR00PAGE_N01_1_0005" , "CR00PAGE_N01_1_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("76_idle_right", "CR00PAGE_N01_1_0006" , "CR00PAGE_N01_1_0007" , "CR00PAGE_N01_1_0008" , "CR00PAGE_N01_1_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("76_idle_front_right", "CR00PAGE_N01_1_0009" , "CR00PAGE_N01_1_0010" , "CR00PAGE_N01_1_0011" , "CR00PAGE_N01_1_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("76_idle_front", "CR00PAGE_N01_1_0012" , "CR00PAGE_N01_1_0013" , "CR00PAGE_N01_1_0014" , "CR00PAGE_N01_1_0015" , "" , "" , "" , "" ,4);
		CreateAnimationUW("76_idle_front_left", "CR00PAGE_N01_1_0016" , "CR00PAGE_N01_1_0017" , "CR00PAGE_N01_1_0018" , "CR00PAGE_N01_1_0017" , "" , "" , "" , "" ,4);
		CreateAnimationUW("76_idle_left", "CR00PAGE_N01_1_0019" , "CR00PAGE_N01_1_0020" , "CR00PAGE_N01_1_0021" , "CR00PAGE_N01_1_0020" , "" , "" , "" , "" ,4);
		CreateAnimationUW("76_idle_rear_left", "CR00PAGE_N01_1_0022" , "CR00PAGE_N01_1_0023" , "CR00PAGE_N01_1_0024" , "CR00PAGE_N01_1_0023" , "" , "" , "" , "" ,4);
		CreateAnimationUW("76_walking_rear", "CR00PAGE_N01_1_0025" , "CR00PAGE_N01_1_0026" , "CR00PAGE_N01_1_0027" , "CR00PAGE_N01_1_0028" , "" , "" , "" , "" ,4);
		CreateAnimationUW("76_walking_rear_right", "CR00PAGE_N01_1_0029" , "CR00PAGE_N01_1_0030" , "CR00PAGE_N01_1_0031" , "CR00PAGE_N01_1_0032" , "" , "" , "" , "" ,4);
		CreateAnimationUW("76_walking_right", "CR00PAGE_N01_1_0033" , "CR00PAGE_N01_1_0034" , "CR00PAGE_N01_1_0035" , "CR00PAGE_N01_1_0036" , "" , "" , "" , "" ,4);
		CreateAnimationUW("76_walking_front_right", "CR00PAGE_N01_1_0037" , "CR00PAGE_N01_1_0038" , "CR00PAGE_N01_1_0039" , "CR00PAGE_N01_1_0040" , "" , "" , "" , "" ,4);
		CreateAnimationUW("76_walking_front", "CR00PAGE_N01_1_0041" , "CR00PAGE_N01_1_0042" , "CR00PAGE_N01_1_0043" , "CR00PAGE_N01_1_0044" , "" , "" , "" , "" ,4);
		CreateAnimationUW("76_walking_front_left", "CR00PAGE_N01_1_0045" , "CR00PAGE_N01_1_0046" , "CR00PAGE_N01_1_0047" , "CR00PAGE_N01_1_0048" , "" , "" , "" , "" ,4);
		CreateAnimationUW("76_walking_left", "CR00PAGE_N01_1_0049" , "CR00PAGE_N01_1_0050" , "CR00PAGE_N01_1_0051" , "CR00PAGE_N01_1_0052" , "" , "" , "" , "" ,4);
		CreateAnimationUW("76_walking_rear_left", "CR00PAGE_N01_1_0053" , "CR00PAGE_N01_1_0053" , "CR00PAGE_N01_1_0054" , "CR00PAGE_N01_1_0054" , "" , "" , "" , "" ,4);
		//Anim ID: 13 - which is a_goblin
		//	File:c:\games\uw1\crit\CR00PAGE.N00, Palette = 2
		CreateAnimationUW("77_combat_idle", "CR00PAGE_N00_2_0000" , "CR00PAGE_N00_2_0001" , "CR00PAGE_N00_2_0000" , "CR00PAGE_N00_2_0002" , "" , "" , "" , "" ,4);
		CreateAnimationUW("77_attack_bash", "CR00PAGE_N00_2_0003" , "CR00PAGE_N00_2_0004" , "CR00PAGE_N00_2_0005" , "CR00PAGE_N00_2_0006" , "CR00PAGE_N00_2_0007" , "" , "" , "" ,5);
		CreateAnimationUW("77_attack_slash", "CR00PAGE_N00_2_0000" , "CR00PAGE_N00_2_0008" , "CR00PAGE_N00_2_0009" , "CR00PAGE_N00_2_0010" , "CR00PAGE_N00_2_0009" , "" , "" , "" ,5);
		CreateAnimationUW("77_attack_thrust", "CR00PAGE_N00_2_0000" , "CR00PAGE_N00_2_0011" , "CR00PAGE_N00_2_0012" , "CR00PAGE_N00_2_0013" , "CR00PAGE_N00_2_0014" , "" , "" , "" ,5);
		CreateAnimationUW("77_attack_secondary", "CR00PAGE_N00_2_0015" , "CR00PAGE_N00_2_0016" , "CR00PAGE_N00_2_0017" , "CR00PAGE_N00_2_0018" , "CR00PAGE_N00_2_0019" , "" , "" , "" ,5);
		CreateAnimationUW("77_walking_towards", "CR00PAGE_N00_2_0020" , "CR00PAGE_N00_2_0021" , "CR00PAGE_N00_2_0022" , "CR00PAGE_N00_2_0023" , "" , "" , "" , "" ,4);
		CreateAnimationUW("77_death", "CR00PAGE_N00_2_0024" , "CR00PAGE_N00_2_0025" , "CR00PAGE_N00_2_0026" , "CR00PAGE_N00_2_0027" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR00PAGE.N01, Palette = 2
		CreateAnimationUW("77_idle_rear", "CR00PAGE_N01_2_0000" , "CR00PAGE_N01_2_0001" , "CR00PAGE_N01_2_0002" , "CR00PAGE_N01_2_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("77_idle_rear_right", "CR00PAGE_N01_2_0003" , "CR00PAGE_N01_2_0004" , "CR00PAGE_N01_2_0005" , "CR00PAGE_N01_2_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("77_idle_right", "CR00PAGE_N01_2_0006" , "CR00PAGE_N01_2_0007" , "CR00PAGE_N01_2_0008" , "CR00PAGE_N01_2_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("77_idle_front_right", "CR00PAGE_N01_2_0009" , "CR00PAGE_N01_2_0010" , "CR00PAGE_N01_2_0011" , "CR00PAGE_N01_2_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("77_idle_front", "CR00PAGE_N01_2_0012" , "CR00PAGE_N01_2_0013" , "CR00PAGE_N01_2_0014" , "CR00PAGE_N01_2_0015" , "" , "" , "" , "" ,4);
		CreateAnimationUW("77_idle_front_left", "CR00PAGE_N01_2_0016" , "CR00PAGE_N01_2_0017" , "CR00PAGE_N01_2_0018" , "CR00PAGE_N01_2_0017" , "" , "" , "" , "" ,4);
		CreateAnimationUW("77_idle_left", "CR00PAGE_N01_2_0019" , "CR00PAGE_N01_2_0020" , "CR00PAGE_N01_2_0021" , "CR00PAGE_N01_2_0020" , "" , "" , "" , "" ,4);
		CreateAnimationUW("77_idle_rear_left", "CR00PAGE_N01_2_0022" , "CR00PAGE_N01_2_0023" , "CR00PAGE_N01_2_0024" , "CR00PAGE_N01_2_0023" , "" , "" , "" , "" ,4);
		CreateAnimationUW("77_walking_rear", "CR00PAGE_N01_2_0025" , "CR00PAGE_N01_2_0026" , "CR00PAGE_N01_2_0027" , "CR00PAGE_N01_2_0028" , "" , "" , "" , "" ,4);
		CreateAnimationUW("77_walking_rear_right", "CR00PAGE_N01_2_0029" , "CR00PAGE_N01_2_0030" , "CR00PAGE_N01_2_0031" , "CR00PAGE_N01_2_0032" , "" , "" , "" , "" ,4);
		CreateAnimationUW("77_walking_right", "CR00PAGE_N01_2_0033" , "CR00PAGE_N01_2_0034" , "CR00PAGE_N01_2_0035" , "CR00PAGE_N01_2_0036" , "" , "" , "" , "" ,4);
		CreateAnimationUW("77_walking_front_right", "CR00PAGE_N01_2_0037" , "CR00PAGE_N01_2_0038" , "CR00PAGE_N01_2_0039" , "CR00PAGE_N01_2_0040" , "" , "" , "" , "" ,4);
		CreateAnimationUW("77_walking_front", "CR00PAGE_N01_2_0041" , "CR00PAGE_N01_2_0042" , "CR00PAGE_N01_2_0043" , "CR00PAGE_N01_2_0044" , "" , "" , "" , "" ,4);
		CreateAnimationUW("77_walking_front_left", "CR00PAGE_N01_2_0045" , "CR00PAGE_N01_2_0046" , "CR00PAGE_N01_2_0047" , "CR00PAGE_N01_2_0048" , "" , "" , "" , "" ,4);
		CreateAnimationUW("77_walking_left", "CR00PAGE_N01_2_0049" , "CR00PAGE_N01_2_0050" , "CR00PAGE_N01_2_0051" , "CR00PAGE_N01_2_0052" , "" , "" , "" , "" ,4);
		CreateAnimationUW("77_walking_rear_left", "CR00PAGE_N01_2_0053" , "CR00PAGE_N01_2_0053" , "CR00PAGE_N01_2_0054" , "CR00PAGE_N01_2_0054" , "" , "" , "" , "" ,4);
		//Anim ID: 14 - which is a_goblin
		//	File:c:\games\uw1\crit\CR00PAGE.N00, Palette = 3
		CreateAnimationUW("78_combat_idle", "CR00PAGE_N00_3_0000" , "CR00PAGE_N00_3_0001" , "CR00PAGE_N00_3_0000" , "CR00PAGE_N00_3_0002" , "" , "" , "" , "" ,4);
		CreateAnimationUW("78_attack_bash", "CR00PAGE_N00_3_0003" , "CR00PAGE_N00_3_0004" , "CR00PAGE_N00_3_0005" , "CR00PAGE_N00_3_0006" , "CR00PAGE_N00_3_0007" , "" , "" , "" ,5);
		CreateAnimationUW("78_attack_slash", "CR00PAGE_N00_3_0000" , "CR00PAGE_N00_3_0008" , "CR00PAGE_N00_3_0009" , "CR00PAGE_N00_3_0010" , "CR00PAGE_N00_3_0009" , "" , "" , "" ,5);
		CreateAnimationUW("78_attack_thrust", "CR00PAGE_N00_3_0000" , "CR00PAGE_N00_3_0011" , "CR00PAGE_N00_3_0012" , "CR00PAGE_N00_3_0013" , "CR00PAGE_N00_3_0014" , "" , "" , "" ,5);
		CreateAnimationUW("78_attack_secondary", "CR00PAGE_N00_3_0015" , "CR00PAGE_N00_3_0016" , "CR00PAGE_N00_3_0017" , "CR00PAGE_N00_3_0018" , "CR00PAGE_N00_3_0019" , "" , "" , "" ,5);
		CreateAnimationUW("78_walking_towards", "CR00PAGE_N00_3_0020" , "CR00PAGE_N00_3_0021" , "CR00PAGE_N00_3_0022" , "CR00PAGE_N00_3_0023" , "" , "" , "" , "" ,4);
		CreateAnimationUW("78_death", "CR00PAGE_N00_3_0024" , "CR00PAGE_N00_3_0025" , "CR00PAGE_N00_3_0026" , "CR00PAGE_N00_3_0027" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR00PAGE.N01, Palette = 3
		CreateAnimationUW("78_idle_rear", "CR00PAGE_N01_3_0000" , "CR00PAGE_N01_3_0001" , "CR00PAGE_N01_3_0002" , "CR00PAGE_N01_3_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("78_idle_rear_right", "CR00PAGE_N01_3_0003" , "CR00PAGE_N01_3_0004" , "CR00PAGE_N01_3_0005" , "CR00PAGE_N01_3_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("78_idle_right", "CR00PAGE_N01_3_0006" , "CR00PAGE_N01_3_0007" , "CR00PAGE_N01_3_0008" , "CR00PAGE_N01_3_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("78_idle_front_right", "CR00PAGE_N01_3_0009" , "CR00PAGE_N01_3_0010" , "CR00PAGE_N01_3_0011" , "CR00PAGE_N01_3_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("78_idle_front", "CR00PAGE_N01_3_0012" , "CR00PAGE_N01_3_0013" , "CR00PAGE_N01_3_0014" , "CR00PAGE_N01_3_0015" , "" , "" , "" , "" ,4);
		CreateAnimationUW("78_idle_front_left", "CR00PAGE_N01_3_0016" , "CR00PAGE_N01_3_0017" , "CR00PAGE_N01_3_0018" , "CR00PAGE_N01_3_0017" , "" , "" , "" , "" ,4);
		CreateAnimationUW("78_idle_left", "CR00PAGE_N01_3_0019" , "CR00PAGE_N01_3_0020" , "CR00PAGE_N01_3_0021" , "CR00PAGE_N01_3_0020" , "" , "" , "" , "" ,4);
		CreateAnimationUW("78_idle_rear_left", "CR00PAGE_N01_3_0022" , "CR00PAGE_N01_3_0023" , "CR00PAGE_N01_3_0024" , "CR00PAGE_N01_3_0023" , "" , "" , "" , "" ,4);
		CreateAnimationUW("78_walking_rear", "CR00PAGE_N01_3_0025" , "CR00PAGE_N01_3_0026" , "CR00PAGE_N01_3_0027" , "CR00PAGE_N01_3_0028" , "" , "" , "" , "" ,4);
		CreateAnimationUW("78_walking_rear_right", "CR00PAGE_N01_3_0029" , "CR00PAGE_N01_3_0030" , "CR00PAGE_N01_3_0031" , "CR00PAGE_N01_3_0032" , "" , "" , "" , "" ,4);
		CreateAnimationUW("78_walking_right", "CR00PAGE_N01_3_0033" , "CR00PAGE_N01_3_0034" , "CR00PAGE_N01_3_0035" , "CR00PAGE_N01_3_0036" , "" , "" , "" , "" ,4);
		CreateAnimationUW("78_walking_front_right", "CR00PAGE_N01_3_0037" , "CR00PAGE_N01_3_0038" , "CR00PAGE_N01_3_0039" , "CR00PAGE_N01_3_0040" , "" , "" , "" , "" ,4);
		CreateAnimationUW("78_walking_front", "CR00PAGE_N01_3_0041" , "CR00PAGE_N01_3_0042" , "CR00PAGE_N01_3_0043" , "CR00PAGE_N01_3_0044" , "" , "" , "" , "" ,4);
		CreateAnimationUW("78_walking_front_left", "CR00PAGE_N01_3_0045" , "CR00PAGE_N01_3_0046" , "CR00PAGE_N01_3_0047" , "CR00PAGE_N01_3_0048" , "" , "" , "" , "" ,4);
		CreateAnimationUW("78_walking_left", "CR00PAGE_N01_3_0049" , "CR00PAGE_N01_3_0050" , "CR00PAGE_N01_3_0051" , "CR00PAGE_N01_3_0052" , "" , "" , "" , "" ,4);
		CreateAnimationUW("78_walking_rear_left", "CR00PAGE_N01_3_0053" , "CR00PAGE_N01_3_0053" , "CR00PAGE_N01_3_0054" , "CR00PAGE_N01_3_0054" , "" , "" , "" , "" ,4);
		//Anim ID: 15 - which is etherealvoidcreatures
		//	File:c:\games\uw1\crit\CR30PAGE.N00, Palette = 0
		CreateAnimationUW("79_combat_idle", "" , "" , "" , "" , "" , "" , "" , "" ,0);
		//	File:c:\games\uw1\crit\CR30PAGE.N01, Palette = 0
		CreateAnimationUW("79_idle_rear", "CR30PAGE_N01_0_0000" , "CR30PAGE_N01_0_0001" , "CR30PAGE_N01_0_0002" , "CR30PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("79_idle_rear_right", "CR30PAGE_N01_0_0000" , "CR30PAGE_N01_0_0001" , "CR30PAGE_N01_0_0002" , "CR30PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("79_idle_right", "CR30PAGE_N01_0_0000" , "CR30PAGE_N01_0_0001" , "CR30PAGE_N01_0_0002" , "CR30PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("79_idle_front_right", "CR30PAGE_N01_0_0000" , "CR30PAGE_N01_0_0001" , "CR30PAGE_N01_0_0002" , "CR30PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("79_idle_front", "CR30PAGE_N01_0_0000" , "CR30PAGE_N01_0_0001" , "CR30PAGE_N01_0_0002" , "CR30PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("79_idle_front_left", "CR30PAGE_N01_0_0000" , "CR30PAGE_N01_0_0001" , "CR30PAGE_N01_0_0002" , "CR30PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("79_idle_left", "CR30PAGE_N01_0_0000" , "CR30PAGE_N01_0_0001" , "CR30PAGE_N01_0_0002" , "CR30PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("79_idle_rear_left", "CR30PAGE_N01_0_0000" , "CR30PAGE_N01_0_0001" , "CR30PAGE_N01_0_0002" , "CR30PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("79_unknown_anim", "CR30PAGE_N01_0_0003" , "CR30PAGE_N01_0_0004" , "CR30PAGE_N01_0_0005" , "CR30PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("79_unknown_anim", "CR30PAGE_N01_0_0003" , "CR30PAGE_N01_0_0004" , "CR30PAGE_N01_0_0005" , "CR30PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("79_unknown_anim", "CR30PAGE_N01_0_0003" , "CR30PAGE_N01_0_0004" , "CR30PAGE_N01_0_0005" , "CR30PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("79_unknown_anim", "CR30PAGE_N01_0_0003" , "CR30PAGE_N01_0_0004" , "CR30PAGE_N01_0_0005" , "CR30PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("79_unknown_anim", "CR30PAGE_N01_0_0003" , "CR30PAGE_N01_0_0004" , "CR30PAGE_N01_0_0005" , "CR30PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("79_unknown_anim", "CR30PAGE_N01_0_0003" , "CR30PAGE_N01_0_0004" , "CR30PAGE_N01_0_0005" , "CR30PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("79_unknown_anim", "CR30PAGE_N01_0_0003" , "CR30PAGE_N01_0_0004" , "CR30PAGE_N01_0_0005" , "CR30PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("79_unknown_anim", "CR30PAGE_N01_0_0003" , "CR30PAGE_N01_0_0004" , "CR30PAGE_N01_0_0005" , "CR30PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("79_unknown_anim", "CR30PAGE_N01_0_0006" , "CR30PAGE_N01_0_0007" , "CR30PAGE_N01_0_0008" , "CR30PAGE_N01_0_0009" , "" , "" , "" , "" ,4);
		CreateAnimationUW("79_unknown_anim", "CR30PAGE_N01_0_0006" , "CR30PAGE_N01_0_0007" , "CR30PAGE_N01_0_0008" , "CR30PAGE_N01_0_0009" , "" , "" , "" , "" ,4);
		CreateAnimationUW("79_unknown_anim", "CR30PAGE_N01_0_0006" , "CR30PAGE_N01_0_0007" , "CR30PAGE_N01_0_0008" , "CR30PAGE_N01_0_0009" , "" , "" , "" , "" ,4);
		CreateAnimationUW("79_unknown_anim", "CR30PAGE_N01_0_0006" , "CR30PAGE_N01_0_0007" , "CR30PAGE_N01_0_0008" , "CR30PAGE_N01_0_0009" , "" , "" , "" , "" ,4);
		CreateAnimationUW("79_unknown_anim", "CR30PAGE_N01_0_0006" , "CR30PAGE_N01_0_0007" , "CR30PAGE_N01_0_0008" , "CR30PAGE_N01_0_0009" , "" , "" , "" , "" ,4);
		CreateAnimationUW("79_unknown_anim", "CR30PAGE_N01_0_0006" , "CR30PAGE_N01_0_0007" , "CR30PAGE_N01_0_0008" , "CR30PAGE_N01_0_0009" , "" , "" , "" , "" ,4);
		CreateAnimationUW("79_unknown_anim", "CR30PAGE_N01_0_0006" , "CR30PAGE_N01_0_0007" , "CR30PAGE_N01_0_0008" , "CR30PAGE_N01_0_0009" , "" , "" , "" , "" ,4);
		CreateAnimationUW("79_unknown_anim", "CR30PAGE_N01_0_0006" , "CR30PAGE_N01_0_0007" , "CR30PAGE_N01_0_0008" , "CR30PAGE_N01_0_0009" , "" , "" , "" , "" ,4);
		CreateAnimationUW("79_walking_rear", "CR30PAGE_N01_0_0010" , "CR30PAGE_N01_0_0011" , "CR30PAGE_N01_0_0012" , "CR30PAGE_N01_0_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("79_walking_rear_right", "CR30PAGE_N01_0_0010" , "CR30PAGE_N01_0_0011" , "CR30PAGE_N01_0_0012" , "CR30PAGE_N01_0_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("79_walking_right", "CR30PAGE_N01_0_0010" , "CR30PAGE_N01_0_0011" , "CR30PAGE_N01_0_0012" , "CR30PAGE_N01_0_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("79_walking_front_right", "CR30PAGE_N01_0_0010" , "CR30PAGE_N01_0_0011" , "CR30PAGE_N01_0_0012" , "CR30PAGE_N01_0_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("79_walking_front", "CR30PAGE_N01_0_0010" , "CR30PAGE_N01_0_0011" , "CR30PAGE_N01_0_0012" , "CR30PAGE_N01_0_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("79_walking_front_left", "CR30PAGE_N01_0_0010" , "CR30PAGE_N01_0_0011" , "CR30PAGE_N01_0_0012" , "CR30PAGE_N01_0_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("79_walking_left", "CR30PAGE_N01_0_0010" , "CR30PAGE_N01_0_0011" , "CR30PAGE_N01_0_0012" , "CR30PAGE_N01_0_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("79_walking_rear_left", "CR30PAGE_N01_0_0010" , "CR30PAGE_N01_0_0011" , "CR30PAGE_N01_0_0012" , "CR30PAGE_N01_0_0013" , "" , "" , "" , "" ,4);
		//Anim ID: 16 - which is a_goblin
		//	File:c:\games\uw1\crit\CR16PAGE.N00, Palette = 1
		CreateAnimationUW("80_combat_idle", "CR16PAGE_N00_1_0000" , "CR16PAGE_N00_1_0001" , "CR16PAGE_N00_1_0000" , "CR16PAGE_N00_1_0002" , "" , "" , "" , "" ,4);
		CreateAnimationUW("80_attack_bash", "CR16PAGE_N00_1_0003" , "CR16PAGE_N00_1_0004" , "CR16PAGE_N00_1_0005" , "CR16PAGE_N00_1_0006" , "CR16PAGE_N00_1_0007" , "" , "" , "" ,5);
		CreateAnimationUW("80_attack_slash", "CR16PAGE_N00_1_0000" , "CR16PAGE_N00_1_0008" , "CR16PAGE_N00_1_0009" , "CR16PAGE_N00_1_0010" , "CR16PAGE_N00_1_0011" , "" , "" , "" ,5);
		CreateAnimationUW("80_attack_thrust", "CR16PAGE_N00_1_0000" , "CR16PAGE_N00_1_0012" , "CR16PAGE_N00_1_0013" , "CR16PAGE_N00_1_0014" , "CR16PAGE_N00_1_0015" , "" , "" , "" ,5);
		CreateAnimationUW("80_walking_towards", "CR16PAGE_N00_1_0016" , "CR16PAGE_N00_1_0017" , "CR16PAGE_N00_1_0018" , "CR16PAGE_N00_1_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("80_death", "CR16PAGE_N00_1_0020" , "CR16PAGE_N00_1_0021" , "CR16PAGE_N00_1_0022" , "CR16PAGE_N00_1_0023" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR16PAGE.N01, Palette = 1
		CreateAnimationUW("80_idle_rear", "CR16PAGE_N01_1_0000" , "CR16PAGE_N01_1_0001" , "CR16PAGE_N01_1_0002" , "CR16PAGE_N01_1_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("80_idle_rear_right", "CR16PAGE_N01_1_0003" , "CR16PAGE_N01_1_0004" , "CR16PAGE_N01_1_0005" , "CR16PAGE_N01_1_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("80_idle_right", "CR16PAGE_N01_1_0006" , "CR16PAGE_N01_1_0007" , "CR16PAGE_N01_1_0008" , "CR16PAGE_N01_1_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("80_idle_front_right", "CR16PAGE_N01_1_0009" , "CR16PAGE_N01_1_0010" , "CR16PAGE_N01_1_0011" , "CR16PAGE_N01_1_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("80_idle_front", "CR16PAGE_N01_1_0012" , "CR16PAGE_N01_1_0013" , "CR16PAGE_N01_1_0014" , "CR16PAGE_N01_1_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("80_idle_front_left", "CR16PAGE_N01_1_0015" , "CR16PAGE_N01_1_0016" , "CR16PAGE_N01_1_0017" , "CR16PAGE_N01_1_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("80_idle_left", "CR16PAGE_N01_1_0018" , "CR16PAGE_N01_1_0019" , "CR16PAGE_N01_1_0020" , "CR16PAGE_N01_1_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("80_idle_rear_left", "CR16PAGE_N01_1_0021" , "CR16PAGE_N01_1_0022" , "CR16PAGE_N01_1_0023" , "CR16PAGE_N01_1_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("80_walking_rear", "CR16PAGE_N01_1_0024" , "CR16PAGE_N01_1_0025" , "CR16PAGE_N01_1_0026" , "CR16PAGE_N01_1_0027" , "" , "" , "" , "" ,4);
		CreateAnimationUW("80_walking_rear_right", "CR16PAGE_N01_1_0028" , "CR16PAGE_N01_1_0029" , "CR16PAGE_N01_1_0030" , "CR16PAGE_N01_1_0031" , "" , "" , "" , "" ,4);
		CreateAnimationUW("80_walking_right", "CR16PAGE_N01_1_0032" , "CR16PAGE_N01_1_0033" , "CR16PAGE_N01_1_0034" , "CR16PAGE_N01_1_0035" , "" , "" , "" , "" ,4);
		CreateAnimationUW("80_walking_front_right", "CR16PAGE_N01_1_0036" , "CR16PAGE_N01_1_0037" , "CR16PAGE_N01_1_0038" , "CR16PAGE_N01_1_0039" , "" , "" , "" , "" ,4);
		CreateAnimationUW("80_walking_front", "CR16PAGE_N01_1_0040" , "CR16PAGE_N01_1_0041" , "CR16PAGE_N01_1_0042" , "CR16PAGE_N01_1_0043" , "" , "" , "" , "" ,4);
		CreateAnimationUW("80_walking_front_left", "CR16PAGE_N01_1_0044" , "CR16PAGE_N01_1_0045" , "CR16PAGE_N01_1_0046" , "CR16PAGE_N01_1_0047" , "" , "" , "" , "" ,4);
		CreateAnimationUW("80_walking_left", "CR16PAGE_N01_1_0048" , "CR16PAGE_N01_1_0049" , "CR16PAGE_N01_1_0050" , "CR16PAGE_N01_1_0051" , "" , "" , "" , "" ,4);
		CreateAnimationUW("80_walking_rear_left", "CR16PAGE_N01_1_0052" , "CR16PAGE_N01_1_0053" , "CR16PAGE_N01_1_0054" , "CR16PAGE_N01_1_0055" , "" , "" , "" , "" ,4);
		//Anim ID: 17 - which is a_mongbat
		//	File:c:\games\uw1\crit\CR22PAGE.N00, Palette = 1
		CreateAnimationUW("81_combat_idle", "CR22PAGE_N00_1_0000" , "CR22PAGE_N00_1_0001" , "CR22PAGE_N00_1_0002" , "CR22PAGE_N00_1_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("81_attack_bash", "CR22PAGE_N00_1_0004" , "CR22PAGE_N00_1_0005" , "CR22PAGE_N00_1_0006" , "CR22PAGE_N00_1_0007" , "CR22PAGE_N00_1_0004" , "" , "" , "" ,5);
		CreateAnimationUW("81_attack_slash", "CR22PAGE_N00_1_0008" , "CR22PAGE_N00_1_0009" , "CR22PAGE_N00_1_0010" , "CR22PAGE_N00_1_0011" , "CR22PAGE_N00_1_0012" , "" , "" , "" ,5);
		CreateAnimationUW("81_attack_thrust", "CR22PAGE_N00_1_0004" , "CR22PAGE_N00_1_0005" , "CR22PAGE_N00_1_0006" , "CR22PAGE_N00_1_0007" , "CR22PAGE_N00_1_0004" , "" , "" , "" ,5);
		CreateAnimationUW("81_walking_towards", "CR22PAGE_N00_1_0000" , "CR22PAGE_N00_1_0001" , "CR22PAGE_N00_1_0002" , "CR22PAGE_N00_1_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("81_death", "CR22PAGE_N00_1_0013" , "CR22PAGE_N00_1_0014" , "CR22PAGE_N00_1_0015" , "CR22PAGE_N00_1_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("81_begin_combat", "CR22PAGE_N00_1_0004" , "CR22PAGE_N00_1_0005" , "CR22PAGE_N00_1_0006" , "CR22PAGE_N00_1_0007" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR22PAGE.N01, Palette = 1
		CreateAnimationUW("81_idle_rear", "CR22PAGE_N01_1_0000" , "CR22PAGE_N01_1_0001" , "CR22PAGE_N01_1_0002" , "CR22PAGE_N01_1_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("81_idle_rear_right", "CR22PAGE_N01_1_0004" , "CR22PAGE_N01_1_0005" , "CR22PAGE_N01_1_0006" , "CR22PAGE_N01_1_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("81_idle_right", "CR22PAGE_N01_1_0008" , "CR22PAGE_N01_1_0009" , "CR22PAGE_N01_1_0010" , "CR22PAGE_N01_1_0011" , "" , "" , "" , "" ,4);
		CreateAnimationUW("81_idle_front_right", "CR22PAGE_N01_1_0012" , "CR22PAGE_N01_1_0013" , "CR22PAGE_N01_1_0014" , "CR22PAGE_N01_1_0015" , "" , "" , "" , "" ,4);
		CreateAnimationUW("81_idle_front", "CR22PAGE_N01_1_0016" , "CR22PAGE_N01_1_0017" , "CR22PAGE_N01_1_0018" , "CR22PAGE_N01_1_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("81_idle_front_left", "CR22PAGE_N01_1_0020" , "CR22PAGE_N01_1_0021" , "CR22PAGE_N01_1_0022" , "CR22PAGE_N01_1_0023" , "" , "" , "" , "" ,4);
		CreateAnimationUW("81_idle_left", "CR22PAGE_N01_1_0024" , "CR22PAGE_N01_1_0025" , "CR22PAGE_N01_1_0026" , "CR22PAGE_N01_1_0027" , "" , "" , "" , "" ,4);
		CreateAnimationUW("81_idle_rear_left", "CR22PAGE_N01_1_0028" , "CR22PAGE_N01_1_0029" , "CR22PAGE_N01_1_0030" , "CR22PAGE_N01_1_0031" , "" , "" , "" , "" ,4);
		CreateAnimationUW("81_walking_rear", "CR22PAGE_N01_1_0000" , "CR22PAGE_N01_1_0001" , "CR22PAGE_N01_1_0002" , "CR22PAGE_N01_1_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("81_walking_rear_right", "CR22PAGE_N01_1_0004" , "CR22PAGE_N01_1_0005" , "CR22PAGE_N01_1_0006" , "CR22PAGE_N01_1_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("81_walking_right", "CR22PAGE_N01_1_0008" , "CR22PAGE_N01_1_0009" , "CR22PAGE_N01_1_0010" , "CR22PAGE_N01_1_0011" , "" , "" , "" , "" ,4);
		CreateAnimationUW("81_walking_front_right", "CR22PAGE_N01_1_0012" , "CR22PAGE_N01_1_0013" , "CR22PAGE_N01_1_0014" , "CR22PAGE_N01_1_0015" , "" , "" , "" , "" ,4);
		CreateAnimationUW("81_walking_front", "CR22PAGE_N01_1_0016" , "CR22PAGE_N01_1_0017" , "CR22PAGE_N01_1_0018" , "CR22PAGE_N01_1_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("81_walking_front_left", "CR22PAGE_N01_1_0020" , "CR22PAGE_N01_1_0021" , "CR22PAGE_N01_1_0022" , "CR22PAGE_N01_1_0023" , "" , "" , "" , "" ,4);
		CreateAnimationUW("81_walking_left", "CR22PAGE_N01_1_0024" , "CR22PAGE_N01_1_0025" , "CR22PAGE_N01_1_0026" , "CR22PAGE_N01_1_0027" , "" , "" , "" , "" ,4);
		CreateAnimationUW("81_walking_rear_left", "CR22PAGE_N01_1_0028" , "CR22PAGE_N01_1_0029" , "CR22PAGE_N01_1_0030" , "CR22PAGE_N01_1_0031" , "" , "" , "" , "" ,4);
		//Anim ID: 18 - which is a_bloodworm
		//	File:c:\games\uw1\crit\CR26PAGE.N00, Palette = 1
		CreateAnimationUW("82_combat_idle", "CR26PAGE_N00_1_0000" , "CR26PAGE_N00_1_0001" , "CR26PAGE_N00_1_0002" , "CR26PAGE_N00_1_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("82_attack_bash", "CR26PAGE_N00_1_0004" , "CR26PAGE_N00_1_0005" , "CR26PAGE_N00_1_0006" , "CR26PAGE_N00_1_0005" , "" , "" , "" , "" ,4);
		CreateAnimationUW("82_walking_towards", "CR26PAGE_N00_1_0000" , "CR26PAGE_N00_1_0001" , "CR26PAGE_N00_1_0002" , "CR26PAGE_N00_1_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("82_death", "CR26PAGE_N00_1_0004" , "CR26PAGE_N00_1_0007" , "CR26PAGE_N00_1_0008" , "CR26PAGE_N00_1_0008" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR26PAGE.N01, Palette = 1
		CreateAnimationUW("82_idle_rear", "CR26PAGE_N01_1_0000" , "CR26PAGE_N01_1_0000" , "CR26PAGE_N01_1_0000" , "CR26PAGE_N01_1_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("82_idle_rear_right", "CR26PAGE_N01_1_0001" , "CR26PAGE_N01_1_0001" , "CR26PAGE_N01_1_0001" , "CR26PAGE_N01_1_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("82_idle_right", "CR26PAGE_N01_1_0002" , "CR26PAGE_N01_1_0002" , "CR26PAGE_N01_1_0002" , "CR26PAGE_N01_1_0002" , "" , "" , "" , "" ,4);
		CreateAnimationUW("82_idle_front_right", "CR26PAGE_N01_1_0003" , "CR26PAGE_N01_1_0003" , "CR26PAGE_N01_1_0003" , "CR26PAGE_N01_1_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("82_idle_front", "CR26PAGE_N01_1_0004" , "CR26PAGE_N01_1_0004" , "CR26PAGE_N01_1_0004" , "CR26PAGE_N01_1_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("82_idle_front_left", "CR26PAGE_N01_1_0005" , "CR26PAGE_N01_1_0005" , "CR26PAGE_N01_1_0005" , "CR26PAGE_N01_1_0005" , "" , "" , "" , "" ,4);
		CreateAnimationUW("82_idle_left", "CR26PAGE_N01_1_0006" , "CR26PAGE_N01_1_0006" , "CR26PAGE_N01_1_0006" , "CR26PAGE_N01_1_0006" , "" , "" , "" , "" ,4);
		CreateAnimationUW("82_idle_rear_left", "CR26PAGE_N01_1_0007" , "CR26PAGE_N01_1_0007" , "CR26PAGE_N01_1_0007" , "CR26PAGE_N01_1_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("82_walking_rear", "CR26PAGE_N01_1_0008" , "CR26PAGE_N01_1_0009" , "CR26PAGE_N01_1_0000" , "CR26PAGE_N01_1_0010" , "CR26PAGE_N01_1_0000" , "CR26PAGE_N01_1_0009" , "" , "" ,6);
		CreateAnimationUW("82_walking_rear_right", "CR26PAGE_N01_1_0011" , "CR26PAGE_N01_1_0012" , "CR26PAGE_N01_1_0001" , "CR26PAGE_N01_1_0013" , "CR26PAGE_N01_1_0001" , "CR26PAGE_N01_1_0012" , "" , "" ,6);
		CreateAnimationUW("82_walking_right", "CR26PAGE_N01_1_0002" , "CR26PAGE_N01_1_0014" , "CR26PAGE_N01_1_0015" , "CR26PAGE_N01_1_0016" , "CR26PAGE_N01_1_0015" , "CR26PAGE_N01_1_0014" , "" , "" ,6);
		CreateAnimationUW("82_walking_front_right", "CR26PAGE_N01_1_0017" , "CR26PAGE_N01_1_0003" , "CR26PAGE_N01_1_0018" , "CR26PAGE_N01_1_0019" , "CR26PAGE_N01_1_0018" , "CR26PAGE_N01_1_0003" , "" , "" ,6);
		CreateAnimationUW("82_walking_front", "CR26PAGE_N01_1_0020" , "CR26PAGE_N01_1_0004" , "CR26PAGE_N01_1_0021" , "CR26PAGE_N01_1_0022" , "CR26PAGE_N01_1_0021" , "CR26PAGE_N01_1_0004" , "" , "" ,6);
		CreateAnimationUW("82_walking_front_left", "CR26PAGE_N01_1_0023" , "CR26PAGE_N01_1_0005" , "CR26PAGE_N01_1_0024" , "CR26PAGE_N01_1_0025" , "CR26PAGE_N01_1_0024" , "CR26PAGE_N01_1_0005" , "" , "" ,6);
		CreateAnimationUW("82_walking_left", "CR26PAGE_N01_1_0006" , "CR26PAGE_N01_1_0026" , "CR26PAGE_N01_1_0027" , "CR26PAGE_N01_1_0028" , "CR26PAGE_N01_1_0027" , "CR26PAGE_N01_1_0026" , "" , "" ,6);
		CreateAnimationUW("82_walking_rear_left", "CR26PAGE_N01_1_0007" , "CR26PAGE_N01_1_0029" , "CR26PAGE_N01_1_0030" , "CR26PAGE_N01_1_0031" , "CR26PAGE_N01_1_0030" , "CR26PAGE_N01_1_0029" , "" , "" ,6);
		//Anim ID: 19 - which is a_wolf_spider
		//	File:c:\games\uw1\crit\CR05PAGE.N00, Palette = 1
		CreateAnimationUW("83_combat_idle", "CR05PAGE_N00_1_0000" , "CR05PAGE_N00_1_0001" , "CR05PAGE_N00_1_0000" , "CR05PAGE_N00_1_0002" , "" , "" , "" , "" ,4);
		CreateAnimationUW("83_attack_bash", "CR05PAGE_N00_1_0003" , "CR05PAGE_N00_1_0004" , "CR05PAGE_N00_1_0005" , "CR05PAGE_N00_1_0006" , "CR05PAGE_N00_1_0004" , "" , "" , "" ,5);
		CreateAnimationUW("83_attack_slash", "CR05PAGE_N00_1_0000" , "CR05PAGE_N00_1_0007" , "CR05PAGE_N00_1_0008" , "CR05PAGE_N00_1_0009" , "CR05PAGE_N00_1_0010" , "" , "" , "" ,5);
		CreateAnimationUW("83_attack_thrust", "CR05PAGE_N00_1_0001" , "CR05PAGE_N00_1_0011" , "CR05PAGE_N00_1_0003" , "CR05PAGE_N00_1_0004" , "CR05PAGE_N00_1_0003" , "" , "" , "" ,5);
		CreateAnimationUW("83_walking_towards", "CR05PAGE_N00_1_0012" , "CR05PAGE_N00_1_0013" , "CR05PAGE_N00_1_0000" , "CR05PAGE_N00_1_0014" , "" , "" , "" , "" ,4);
		CreateAnimationUW("83_death", "CR05PAGE_N00_1_0000" , "CR05PAGE_N00_1_0011" , "CR05PAGE_N00_1_0015" , "CR05PAGE_N00_1_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("83_begin_combat", "CR05PAGE_N00_1_0003" , "CR05PAGE_N00_1_0004" , "CR05PAGE_N00_1_0005" , "CR05PAGE_N00_1_0006" , "CR05PAGE_N00_1_0003" , "" , "" , "" ,5);
		//	File:c:\games\uw1\crit\CR05PAGE.N01, Palette = 1
		CreateAnimationUW("83_idle_rear", "CR05PAGE_N01_1_0000" , "CR05PAGE_N01_1_0000" , "CR05PAGE_N01_1_0000" , "CR05PAGE_N01_1_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("83_idle_rear_right", "CR05PAGE_N01_1_0001" , "CR05PAGE_N01_1_0001" , "CR05PAGE_N01_1_0001" , "CR05PAGE_N01_1_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("83_idle_right", "CR05PAGE_N01_1_0002" , "CR05PAGE_N01_1_0002" , "CR05PAGE_N01_1_0002" , "CR05PAGE_N01_1_0002" , "" , "" , "" , "" ,4);
		CreateAnimationUW("83_idle_front_right", "CR05PAGE_N01_1_0003" , "CR05PAGE_N01_1_0003" , "CR05PAGE_N01_1_0003" , "CR05PAGE_N01_1_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("83_idle_front", "CR05PAGE_N01_1_0004" , "CR05PAGE_N01_1_0004" , "CR05PAGE_N01_1_0004" , "CR05PAGE_N01_1_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("83_idle_front_left", "CR05PAGE_N01_1_0005" , "CR05PAGE_N01_1_0005" , "CR05PAGE_N01_1_0005" , "CR05PAGE_N01_1_0005" , "" , "" , "" , "" ,4);
		CreateAnimationUW("83_idle_left", "CR05PAGE_N01_1_0006" , "CR05PAGE_N01_1_0006" , "CR05PAGE_N01_1_0006" , "CR05PAGE_N01_1_0006" , "" , "" , "" , "" ,4);
		CreateAnimationUW("83_idle_rear_left", "CR05PAGE_N01_1_0007" , "CR05PAGE_N01_1_0007" , "CR05PAGE_N01_1_0007" , "CR05PAGE_N01_1_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("83_walking_rear", "CR05PAGE_N01_1_0000" , "CR05PAGE_N01_1_0008" , "CR05PAGE_N01_1_0009" , "CR05PAGE_N01_1_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("83_walking_rear_right", "CR05PAGE_N01_1_0011" , "CR05PAGE_N01_1_0012" , "CR05PAGE_N01_1_0001" , "CR05PAGE_N01_1_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("83_walking_right", "CR05PAGE_N01_1_0002" , "CR05PAGE_N01_1_0014" , "CR05PAGE_N01_1_0015" , "CR05PAGE_N01_1_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("83_walking_front_right", "CR05PAGE_N01_1_0003" , "CR05PAGE_N01_1_0017" , "CR05PAGE_N01_1_0018" , "CR05PAGE_N01_1_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("83_walking_front", "CR05PAGE_N01_1_0020" , "CR05PAGE_N01_1_0021" , "CR05PAGE_N01_1_0004" , "CR05PAGE_N01_1_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("83_walking_front_left", "CR05PAGE_N01_1_0005" , "CR05PAGE_N01_1_0023" , "CR05PAGE_N01_1_0024" , "CR05PAGE_N01_1_0025" , "" , "" , "" , "" ,4);
		CreateAnimationUW("83_walking_left", "CR05PAGE_N01_1_0006" , "CR05PAGE_N01_1_0026" , "CR05PAGE_N01_1_0027" , "CR05PAGE_N01_1_0028" , "" , "" , "" , "" ,4);
		CreateAnimationUW("83_walking_rear_left", "CR05PAGE_N01_1_0029" , "CR05PAGE_N01_1_0030" , "CR05PAGE_N01_1_0007" , "CR05PAGE_N01_1_0031" , "" , "" , "" , "" ,4);
		//Anim ID: 20 - which is a_mountainman_mountainmen
		//	File:c:\games\uw1\crit\CR33PAGE.N00, Palette = 0
		CreateAnimationUW("84_combat_idle", "CR33PAGE_N00_0_0000" , "CR33PAGE_N00_0_0001" , "CR33PAGE_N00_0_0000" , "CR33PAGE_N00_0_0002" , "" , "" , "" , "" ,4);
		CreateAnimationUW("84_attack_bash", "CR33PAGE_N00_0_0003" , "CR33PAGE_N00_0_0004" , "CR33PAGE_N00_0_0005" , "CR33PAGE_N00_0_0006" , "CR33PAGE_N00_0_0007" , "" , "" , "" ,5);
		CreateAnimationUW("84_attack_slash", "CR33PAGE_N00_0_0003" , "CR33PAGE_N00_0_0008" , "CR33PAGE_N00_0_0009" , "CR33PAGE_N00_0_0010" , "CR33PAGE_N00_0_0011" , "" , "" , "" ,5);
		CreateAnimationUW("84_attack_thrust", "CR33PAGE_N00_0_0000" , "CR33PAGE_N00_0_0011" , "CR33PAGE_N00_0_0009" , "CR33PAGE_N00_0_0003" , "CR33PAGE_N00_0_0001" , "" , "" , "" ,5);
		CreateAnimationUW("84_walking_towards", "CR33PAGE_N00_0_0012" , "CR33PAGE_N00_0_0013" , "CR33PAGE_N00_0_0014" , "CR33PAGE_N00_0_0015" , "" , "" , "" , "" ,4);
		CreateAnimationUW("84_death", "CR33PAGE_N00_0_0000" , "CR33PAGE_N00_0_0003" , "CR33PAGE_N00_0_0016" , "CR33PAGE_N00_0_0017" , "" , "" , "" , "" ,4);
		CreateAnimationUW("84_begin_combat", "CR33PAGE_N00_0_0018" , "CR33PAGE_N00_0_0018" , "CR33PAGE_N00_0_0019" , "CR33PAGE_N00_0_0000" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR33PAGE.N01, Palette = 0
		CreateAnimationUW("84_idle_rear", "CR33PAGE_N01_0_0000" , "CR33PAGE_N01_0_0001" , "CR33PAGE_N01_0_0002" , "CR33PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("84_idle_rear_right", "CR33PAGE_N01_0_0003" , "CR33PAGE_N01_0_0004" , "CR33PAGE_N01_0_0005" , "CR33PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("84_idle_right", "CR33PAGE_N01_0_0006" , "CR33PAGE_N01_0_0007" , "CR33PAGE_N01_0_0008" , "CR33PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("84_idle_front_right", "CR33PAGE_N01_0_0009" , "CR33PAGE_N01_0_0010" , "CR33PAGE_N01_0_0011" , "CR33PAGE_N01_0_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("84_idle_front", "CR33PAGE_N01_0_0012" , "CR33PAGE_N01_0_0013" , "CR33PAGE_N01_0_0014" , "CR33PAGE_N01_0_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("84_idle_front_left", "CR33PAGE_N01_0_0015" , "CR33PAGE_N01_0_0016" , "CR33PAGE_N01_0_0017" , "CR33PAGE_N01_0_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("84_idle_left", "CR33PAGE_N01_0_0018" , "CR33PAGE_N01_0_0019" , "CR33PAGE_N01_0_0020" , "CR33PAGE_N01_0_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("84_idle_rear_left", "CR33PAGE_N01_0_0021" , "CR33PAGE_N01_0_0022" , "CR33PAGE_N01_0_0023" , "CR33PAGE_N01_0_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("84_walking_rear", "CR33PAGE_N01_0_0024" , "CR33PAGE_N01_0_0025" , "CR33PAGE_N01_0_0026" , "CR33PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("84_walking_rear_right", "CR33PAGE_N01_0_0027" , "CR33PAGE_N01_0_0004" , "CR33PAGE_N01_0_0028" , "CR33PAGE_N01_0_0029" , "" , "" , "" , "" ,4);
		CreateAnimationUW("84_walking_right", "CR33PAGE_N01_0_0030" , "CR33PAGE_N01_0_0031" , "CR33PAGE_N01_0_0007" , "CR33PAGE_N01_0_0032" , "" , "" , "" , "" ,4);
		CreateAnimationUW("84_walking_front_right", "CR33PAGE_N01_0_0033" , "CR33PAGE_N01_0_0034" , "CR33PAGE_N01_0_0035" , "CR33PAGE_N01_0_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("84_walking_front", "CR33PAGE_N01_0_0036" , "CR33PAGE_N01_0_0013" , "CR33PAGE_N01_0_0037" , "CR33PAGE_N01_0_0038" , "" , "" , "" , "" ,4);
		CreateAnimationUW("84_walking_front_left", "CR33PAGE_N01_0_0039" , "CR33PAGE_N01_0_0040" , "CR33PAGE_N01_0_0041" , "CR33PAGE_N01_0_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("84_walking_left", "CR33PAGE_N01_0_0042" , "CR33PAGE_N01_0_0043" , "CR33PAGE_N01_0_0019" , "CR33PAGE_N01_0_0044" , "" , "" , "" , "" ,4);
		CreateAnimationUW("84_walking_rear_left", "CR33PAGE_N01_0_0045" , "CR33PAGE_N01_0_0022" , "CR33PAGE_N01_0_0046" , "CR33PAGE_N01_0_0047" , "" , "" , "" , "" ,4);
		//Anim ID: 21 - which is a_green_lizardman_green_lizardmen
		//	File:c:\games\uw1\crit\CR02PAGE.N00, Palette = 0
		CreateAnimationUW("85_combat_idle", "CR02PAGE_N00_0_0000" , "CR02PAGE_N00_0_0001" , "CR02PAGE_N00_0_0002" , "CR02PAGE_N00_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("85_attack_bash", "CR02PAGE_N00_0_0003" , "CR02PAGE_N00_0_0004" , "CR02PAGE_N00_0_0005" , "CR02PAGE_N00_0_0006" , "CR02PAGE_N00_0_0003" , "" , "" , "" ,5);
		CreateAnimationUW("85_attack_slash", "CR02PAGE_N00_0_0007" , "CR02PAGE_N00_0_0008" , "CR02PAGE_N00_0_0009" , "CR02PAGE_N00_0_0010" , "CR02PAGE_N00_0_0007" , "" , "" , "" ,5);
		CreateAnimationUW("85_attack_thrust", "CR02PAGE_N00_0_0003" , "CR02PAGE_N00_0_0004" , "CR02PAGE_N00_0_0005" , "CR02PAGE_N00_0_0006" , "CR02PAGE_N00_0_0003" , "" , "" , "" ,5);
		CreateAnimationUW("85_walking_towards", "CR02PAGE_N00_0_0011" , "CR02PAGE_N00_0_0012" , "CR02PAGE_N00_0_0013" , "CR02PAGE_N00_0_0012" , "" , "" , "" , "" ,4);
		CreateAnimationUW("85_death", "CR02PAGE_N00_0_0000" , "CR02PAGE_N00_0_0014" , "CR02PAGE_N00_0_0015" , "CR02PAGE_N00_0_0016" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR02PAGE.N01, Palette = 0
		CreateAnimationUW("85_idle_rear", "CR02PAGE_N01_0_0000" , "CR02PAGE_N01_0_0001" , "CR02PAGE_N01_0_0002" , "CR02PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("85_idle_rear_right", "CR02PAGE_N01_0_0003" , "CR02PAGE_N01_0_0004" , "CR02PAGE_N01_0_0005" , "CR02PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("85_idle_right", "CR02PAGE_N01_0_0006" , "CR02PAGE_N01_0_0007" , "CR02PAGE_N01_0_0008" , "CR02PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("85_idle_front_right", "CR02PAGE_N01_0_0009" , "CR02PAGE_N01_0_0010" , "CR02PAGE_N01_0_0011" , "CR02PAGE_N01_0_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("85_idle_front", "CR02PAGE_N01_0_0012" , "CR02PAGE_N01_0_0013" , "CR02PAGE_N01_0_0014" , "CR02PAGE_N01_0_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("85_idle_front_left", "CR02PAGE_N01_0_0015" , "CR02PAGE_N01_0_0016" , "CR02PAGE_N01_0_0017" , "CR02PAGE_N01_0_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("85_idle_left", "CR02PAGE_N01_0_0018" , "CR02PAGE_N01_0_0019" , "CR02PAGE_N01_0_0020" , "CR02PAGE_N01_0_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("85_idle_rear_left", "CR02PAGE_N01_0_0021" , "CR02PAGE_N01_0_0022" , "CR02PAGE_N01_0_0023" , "CR02PAGE_N01_0_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("85_walking_rear", "CR02PAGE_N01_0_0001" , "CR02PAGE_N01_0_0024" , "CR02PAGE_N01_0_0025" , "CR02PAGE_N01_0_0026" , "" , "" , "" , "" ,4);
		CreateAnimationUW("85_walking_rear_right", "CR02PAGE_N01_0_0027" , "CR02PAGE_N01_0_0028" , "CR02PAGE_N01_0_0029" , "CR02PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("85_walking_right", "CR02PAGE_N01_0_0030" , "CR02PAGE_N01_0_0031" , "CR02PAGE_N01_0_0007" , "CR02PAGE_N01_0_0032" , "" , "" , "" , "" ,4);
		CreateAnimationUW("85_walking_front_right", "CR02PAGE_N01_0_0010" , "CR02PAGE_N01_0_0033" , "CR02PAGE_N01_0_0034" , "CR02PAGE_N01_0_0035" , "" , "" , "" , "" ,4);
		CreateAnimationUW("85_walking_front", "CR02PAGE_N01_0_0036" , "CR02PAGE_N01_0_0037" , "CR02PAGE_N01_0_0038" , "CR02PAGE_N01_0_0039" , "" , "" , "" , "" ,4);
		CreateAnimationUW("85_walking_front_left", "CR02PAGE_N01_0_0040" , "CR02PAGE_N01_0_0041" , "CR02PAGE_N01_0_0016" , "CR02PAGE_N01_0_0042" , "" , "" , "" , "" ,4);
		CreateAnimationUW("85_walking_left", "CR02PAGE_N01_0_0019" , "CR02PAGE_N01_0_0043" , "CR02PAGE_N01_0_0044" , "CR02PAGE_N01_0_0045" , "" , "" , "" , "" ,4);
		CreateAnimationUW("85_walking_rear_left", "CR02PAGE_N01_0_0046" , "CR02PAGE_N01_0_0022" , "CR02PAGE_N01_0_0047" , "CR02PAGE_N01_0_0048" , "" , "" , "" , "" ,4);
		//Anim ID: 22 - which is a_mountainman_mountainmen
		//	File:c:\games\uw1\crit\CR33PAGE.N00, Palette = 1
		CreateAnimationUW("86_combat_idle", "CR33PAGE_N00_1_0000" , "CR33PAGE_N00_1_0001" , "CR33PAGE_N00_1_0000" , "CR33PAGE_N00_1_0002" , "" , "" , "" , "" ,4);
		CreateAnimationUW("86_attack_bash", "CR33PAGE_N00_1_0003" , "CR33PAGE_N00_1_0004" , "CR33PAGE_N00_1_0005" , "CR33PAGE_N00_1_0006" , "CR33PAGE_N00_1_0007" , "" , "" , "" ,5);
		CreateAnimationUW("86_attack_slash", "CR33PAGE_N00_1_0003" , "CR33PAGE_N00_1_0008" , "CR33PAGE_N00_1_0009" , "CR33PAGE_N00_1_0010" , "CR33PAGE_N00_1_0011" , "" , "" , "" ,5);
		CreateAnimationUW("86_attack_thrust", "CR33PAGE_N00_1_0000" , "CR33PAGE_N00_1_0011" , "CR33PAGE_N00_1_0009" , "CR33PAGE_N00_1_0003" , "CR33PAGE_N00_1_0001" , "" , "" , "" ,5);
		CreateAnimationUW("86_walking_towards", "CR33PAGE_N00_1_0012" , "CR33PAGE_N00_1_0013" , "CR33PAGE_N00_1_0014" , "CR33PAGE_N00_1_0015" , "" , "" , "" , "" ,4);
		CreateAnimationUW("86_death", "CR33PAGE_N00_1_0000" , "CR33PAGE_N00_1_0003" , "CR33PAGE_N00_1_0016" , "CR33PAGE_N00_1_0017" , "" , "" , "" , "" ,4);
		CreateAnimationUW("86_begin_combat", "CR33PAGE_N00_1_0018" , "CR33PAGE_N00_1_0018" , "CR33PAGE_N00_1_0019" , "CR33PAGE_N00_1_0000" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR33PAGE.N01, Palette = 1
		CreateAnimationUW("86_idle_rear", "CR33PAGE_N01_1_0000" , "CR33PAGE_N01_1_0001" , "CR33PAGE_N01_1_0002" , "CR33PAGE_N01_1_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("86_idle_rear_right", "CR33PAGE_N01_1_0003" , "CR33PAGE_N01_1_0004" , "CR33PAGE_N01_1_0005" , "CR33PAGE_N01_1_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("86_idle_right", "CR33PAGE_N01_1_0006" , "CR33PAGE_N01_1_0007" , "CR33PAGE_N01_1_0008" , "CR33PAGE_N01_1_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("86_idle_front_right", "CR33PAGE_N01_1_0009" , "CR33PAGE_N01_1_0010" , "CR33PAGE_N01_1_0011" , "CR33PAGE_N01_1_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("86_idle_front", "CR33PAGE_N01_1_0012" , "CR33PAGE_N01_1_0013" , "CR33PAGE_N01_1_0014" , "CR33PAGE_N01_1_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("86_idle_front_left", "CR33PAGE_N01_1_0015" , "CR33PAGE_N01_1_0016" , "CR33PAGE_N01_1_0017" , "CR33PAGE_N01_1_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("86_idle_left", "CR33PAGE_N01_1_0018" , "CR33PAGE_N01_1_0019" , "CR33PAGE_N01_1_0020" , "CR33PAGE_N01_1_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("86_idle_rear_left", "CR33PAGE_N01_1_0021" , "CR33PAGE_N01_1_0022" , "CR33PAGE_N01_1_0023" , "CR33PAGE_N01_1_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("86_walking_rear", "CR33PAGE_N01_1_0024" , "CR33PAGE_N01_1_0025" , "CR33PAGE_N01_1_0026" , "CR33PAGE_N01_1_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("86_walking_rear_right", "CR33PAGE_N01_1_0027" , "CR33PAGE_N01_1_0004" , "CR33PAGE_N01_1_0028" , "CR33PAGE_N01_1_0029" , "" , "" , "" , "" ,4);
		CreateAnimationUW("86_walking_right", "CR33PAGE_N01_1_0030" , "CR33PAGE_N01_1_0031" , "CR33PAGE_N01_1_0007" , "CR33PAGE_N01_1_0032" , "" , "" , "" , "" ,4);
		CreateAnimationUW("86_walking_front_right", "CR33PAGE_N01_1_0033" , "CR33PAGE_N01_1_0034" , "CR33PAGE_N01_1_0035" , "CR33PAGE_N01_1_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("86_walking_front", "CR33PAGE_N01_1_0036" , "CR33PAGE_N01_1_0013" , "CR33PAGE_N01_1_0037" , "CR33PAGE_N01_1_0038" , "" , "" , "" , "" ,4);
		CreateAnimationUW("86_walking_front_left", "CR33PAGE_N01_1_0039" , "CR33PAGE_N01_1_0040" , "CR33PAGE_N01_1_0041" , "CR33PAGE_N01_1_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("86_walking_left", "CR33PAGE_N01_1_0042" , "CR33PAGE_N01_1_0043" , "CR33PAGE_N01_1_0019" , "CR33PAGE_N01_1_0044" , "" , "" , "" , "" ,4);
		CreateAnimationUW("86_walking_rear_left", "CR33PAGE_N01_1_0045" , "CR33PAGE_N01_1_0022" , "CR33PAGE_N01_1_0046" , "CR33PAGE_N01_1_0047" , "" , "" , "" , "" ,4);
		//Anim ID: 23 - which is a_lurker
		//	File:c:\games\uw1\crit\CR31PAGE.N00, Palette = 0
		CreateAnimationUW("87_combat_idle", "CR31PAGE_N00_0_0000" , "CR31PAGE_N00_0_0001" , "CR31PAGE_N00_0_0002" , "CR31PAGE_N00_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("87_attack_bash", "CR31PAGE_N00_0_0004" , "CR31PAGE_N00_0_0005" , "CR31PAGE_N00_0_0006" , "CR31PAGE_N00_0_0007" , "CR31PAGE_N00_0_0008" , "" , "" , "" ,5);
		CreateAnimationUW("87_attack_slash", "CR31PAGE_N00_0_0009" , "CR31PAGE_N00_0_0010" , "CR31PAGE_N00_0_0011" , "CR31PAGE_N00_0_0012" , "CR31PAGE_N00_0_0013" , "" , "" , "" ,5);
		CreateAnimationUW("87_attack_thrust", "CR31PAGE_N00_0_0014" , "CR31PAGE_N00_0_0015" , "CR31PAGE_N00_0_0016" , "CR31PAGE_N00_0_0017" , "CR31PAGE_N00_0_0018" , "" , "" , "" ,5);
		CreateAnimationUW("87_walking_towards", "CR31PAGE_N00_0_0003" , "CR31PAGE_N00_0_0002" , "CR31PAGE_N00_0_0001" , "CR31PAGE_N00_0_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("87_death", "CR31PAGE_N00_0_0019" , "CR31PAGE_N00_0_0020" , "CR31PAGE_N00_0_0021" , "CR31PAGE_N00_0_0022" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR31PAGE.N01, Palette = 0
		CreateAnimationUW("87_idle_rear", "CR31PAGE_N01_0_0000" , "CR31PAGE_N01_0_0001" , "CR31PAGE_N01_0_0001" , "CR31PAGE_N01_0_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("87_idle_rear_right", "CR31PAGE_N01_0_0002" , "CR31PAGE_N01_0_0003" , "CR31PAGE_N01_0_0003" , "CR31PAGE_N01_0_0002" , "" , "" , "" , "" ,4);
		CreateAnimationUW("87_idle_right", "CR31PAGE_N01_0_0004" , "CR31PAGE_N01_0_0005" , "CR31PAGE_N01_0_0006" , "CR31PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("87_idle_front_right", "CR31PAGE_N01_0_0008" , "CR31PAGE_N01_0_0009" , "CR31PAGE_N01_0_0010" , "CR31PAGE_N01_0_0011" , "" , "" , "" , "" ,4);
		CreateAnimationUW("87_idle_front", "CR31PAGE_N01_0_0012" , "CR31PAGE_N01_0_0013" , "CR31PAGE_N01_0_0014" , "CR31PAGE_N01_0_0015" , "" , "" , "" , "" ,4);
		CreateAnimationUW("87_idle_front_left", "CR31PAGE_N01_0_0016" , "CR31PAGE_N01_0_0017" , "CR31PAGE_N01_0_0018" , "CR31PAGE_N01_0_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("87_idle_left", "CR31PAGE_N01_0_0020" , "CR31PAGE_N01_0_0021" , "CR31PAGE_N01_0_0022" , "CR31PAGE_N01_0_0023" , "" , "" , "" , "" ,4);
		CreateAnimationUW("87_idle_rear_left", "CR31PAGE_N01_0_0024" , "CR31PAGE_N01_0_0025" , "CR31PAGE_N01_0_0025" , "CR31PAGE_N01_0_0024" , "" , "" , "" , "" ,4);
		CreateAnimationUW("87_walking_rear", "CR31PAGE_N01_0_0026" , "CR31PAGE_N01_0_0027" , "CR31PAGE_N01_0_0028" , "CR31PAGE_N01_0_0029" , "" , "" , "" , "" ,4);
		CreateAnimationUW("87_walking_rear_right", "CR31PAGE_N01_0_0030" , "CR31PAGE_N01_0_0031" , "CR31PAGE_N01_0_0032" , "CR31PAGE_N01_0_0033" , "" , "" , "" , "" ,4);
		CreateAnimationUW("87_walking_right", "CR31PAGE_N01_0_0034" , "CR31PAGE_N01_0_0035" , "CR31PAGE_N01_0_0036" , "CR31PAGE_N01_0_0037" , "" , "" , "" , "" ,4);
		CreateAnimationUW("87_walking_front_right", "CR31PAGE_N01_0_0038" , "CR31PAGE_N01_0_0039" , "CR31PAGE_N01_0_0040" , "CR31PAGE_N01_0_0041" , "" , "" , "" , "" ,4);
		CreateAnimationUW("87_walking_front", "CR31PAGE_N01_0_0042" , "CR31PAGE_N01_0_0043" , "CR31PAGE_N01_0_0044" , "CR31PAGE_N01_0_0045" , "" , "" , "" , "" ,4);
		CreateAnimationUW("87_walking_front_left", "CR31PAGE_N01_0_0046" , "CR31PAGE_N01_0_0047" , "CR31PAGE_N01_0_0048" , "CR31PAGE_N01_0_0049" , "" , "" , "" , "" ,4);
		CreateAnimationUW("87_walking_left", "CR31PAGE_N01_0_0050" , "CR31PAGE_N01_0_0051" , "CR31PAGE_N01_0_0052" , "CR31PAGE_N01_0_0053" , "" , "" , "" , "" ,4);
		CreateAnimationUW("87_walking_rear_left", "CR31PAGE_N01_0_0054" , "CR31PAGE_N01_0_0055" , "CR31PAGE_N01_0_0056" , "CR31PAGE_N01_0_0057" , "" , "" , "" , "" ,4);
		//Anim ID: 24 - which is a_red_lizardman_red_lizardmen
		//	File:c:\games\uw1\crit\CR02PAGE.N00, Palette = 1
		CreateAnimationUW("88_combat_idle", "CR02PAGE_N00_1_0000" , "CR02PAGE_N00_1_0001" , "CR02PAGE_N00_1_0002" , "CR02PAGE_N00_1_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("88_attack_bash", "CR02PAGE_N00_1_0003" , "CR02PAGE_N00_1_0004" , "CR02PAGE_N00_1_0005" , "CR02PAGE_N00_1_0006" , "CR02PAGE_N00_1_0003" , "" , "" , "" ,5);
		CreateAnimationUW("88_attack_slash", "CR02PAGE_N00_1_0007" , "CR02PAGE_N00_1_0008" , "CR02PAGE_N00_1_0009" , "CR02PAGE_N00_1_0010" , "CR02PAGE_N00_1_0007" , "" , "" , "" ,5);
		CreateAnimationUW("88_attack_thrust", "CR02PAGE_N00_1_0003" , "CR02PAGE_N00_1_0004" , "CR02PAGE_N00_1_0005" , "CR02PAGE_N00_1_0006" , "CR02PAGE_N00_1_0003" , "" , "" , "" ,5);
		CreateAnimationUW("88_walking_towards", "CR02PAGE_N00_1_0011" , "CR02PAGE_N00_1_0012" , "CR02PAGE_N00_1_0013" , "CR02PAGE_N00_1_0012" , "" , "" , "" , "" ,4);
		CreateAnimationUW("88_death", "CR02PAGE_N00_1_0000" , "CR02PAGE_N00_1_0014" , "CR02PAGE_N00_1_0015" , "CR02PAGE_N00_1_0016" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR02PAGE.N01, Palette = 1
		CreateAnimationUW("88_idle_rear", "CR02PAGE_N01_1_0000" , "CR02PAGE_N01_1_0001" , "CR02PAGE_N01_1_0002" , "CR02PAGE_N01_1_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("88_idle_rear_right", "CR02PAGE_N01_1_0003" , "CR02PAGE_N01_1_0004" , "CR02PAGE_N01_1_0005" , "CR02PAGE_N01_1_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("88_idle_right", "CR02PAGE_N01_1_0006" , "CR02PAGE_N01_1_0007" , "CR02PAGE_N01_1_0008" , "CR02PAGE_N01_1_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("88_idle_front_right", "CR02PAGE_N01_1_0009" , "CR02PAGE_N01_1_0010" , "CR02PAGE_N01_1_0011" , "CR02PAGE_N01_1_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("88_idle_front", "CR02PAGE_N01_1_0012" , "CR02PAGE_N01_1_0013" , "CR02PAGE_N01_1_0014" , "CR02PAGE_N01_1_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("88_idle_front_left", "CR02PAGE_N01_1_0015" , "CR02PAGE_N01_1_0016" , "CR02PAGE_N01_1_0017" , "CR02PAGE_N01_1_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("88_idle_left", "CR02PAGE_N01_1_0018" , "CR02PAGE_N01_1_0019" , "CR02PAGE_N01_1_0020" , "CR02PAGE_N01_1_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("88_idle_rear_left", "CR02PAGE_N01_1_0021" , "CR02PAGE_N01_1_0022" , "CR02PAGE_N01_1_0023" , "CR02PAGE_N01_1_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("88_walking_rear", "CR02PAGE_N01_1_0001" , "CR02PAGE_N01_1_0024" , "CR02PAGE_N01_1_0025" , "CR02PAGE_N01_1_0026" , "" , "" , "" , "" ,4);
		CreateAnimationUW("88_walking_rear_right", "CR02PAGE_N01_1_0027" , "CR02PAGE_N01_1_0028" , "CR02PAGE_N01_1_0029" , "CR02PAGE_N01_1_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("88_walking_right", "CR02PAGE_N01_1_0030" , "CR02PAGE_N01_1_0031" , "CR02PAGE_N01_1_0007" , "CR02PAGE_N01_1_0032" , "" , "" , "" , "" ,4);
		CreateAnimationUW("88_walking_front_right", "CR02PAGE_N01_1_0010" , "CR02PAGE_N01_1_0033" , "CR02PAGE_N01_1_0034" , "CR02PAGE_N01_1_0035" , "" , "" , "" , "" ,4);
		CreateAnimationUW("88_walking_front", "CR02PAGE_N01_1_0036" , "CR02PAGE_N01_1_0037" , "CR02PAGE_N01_1_0038" , "CR02PAGE_N01_1_0039" , "" , "" , "" , "" ,4);
		CreateAnimationUW("88_walking_front_left", "CR02PAGE_N01_1_0040" , "CR02PAGE_N01_1_0041" , "CR02PAGE_N01_1_0016" , "CR02PAGE_N01_1_0042" , "" , "" , "" , "" ,4);
		CreateAnimationUW("88_walking_left", "CR02PAGE_N01_1_0019" , "CR02PAGE_N01_1_0043" , "CR02PAGE_N01_1_0044" , "CR02PAGE_N01_1_0045" , "" , "" , "" , "" ,4);
		CreateAnimationUW("88_walking_rear_left", "CR02PAGE_N01_1_0046" , "CR02PAGE_N01_1_0022" , "CR02PAGE_N01_1_0047" , "CR02PAGE_N01_1_0048" , "" , "" , "" , "" ,4);
		//Anim ID: 25 - which is a_gray_lizardman_red_lizardmen
		//	File:c:\games\uw1\crit\CR02PAGE.N00, Palette = 2
		CreateAnimationUW("89_combat_idle", "CR02PAGE_N00_2_0000" , "CR02PAGE_N00_2_0001" , "CR02PAGE_N00_2_0002" , "CR02PAGE_N00_2_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("89_attack_bash", "CR02PAGE_N00_2_0003" , "CR02PAGE_N00_2_0004" , "CR02PAGE_N00_2_0005" , "CR02PAGE_N00_2_0006" , "CR02PAGE_N00_2_0003" , "" , "" , "" ,5);
		CreateAnimationUW("89_attack_slash", "CR02PAGE_N00_2_0007" , "CR02PAGE_N00_2_0008" , "CR02PAGE_N00_2_0009" , "CR02PAGE_N00_2_0010" , "CR02PAGE_N00_2_0007" , "" , "" , "" ,5);
		CreateAnimationUW("89_attack_thrust", "CR02PAGE_N00_2_0003" , "CR02PAGE_N00_2_0004" , "CR02PAGE_N00_2_0005" , "CR02PAGE_N00_2_0006" , "CR02PAGE_N00_2_0003" , "" , "" , "" ,5);
		CreateAnimationUW("89_walking_towards", "CR02PAGE_N00_2_0011" , "CR02PAGE_N00_2_0012" , "CR02PAGE_N00_2_0013" , "CR02PAGE_N00_2_0012" , "" , "" , "" , "" ,4);
		CreateAnimationUW("89_death", "CR02PAGE_N00_2_0000" , "CR02PAGE_N00_2_0014" , "CR02PAGE_N00_2_0015" , "CR02PAGE_N00_2_0016" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR02PAGE.N01, Palette = 2
		CreateAnimationUW("89_idle_rear", "CR02PAGE_N01_2_0000" , "CR02PAGE_N01_2_0001" , "CR02PAGE_N01_2_0002" , "CR02PAGE_N01_2_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("89_idle_rear_right", "CR02PAGE_N01_2_0003" , "CR02PAGE_N01_2_0004" , "CR02PAGE_N01_2_0005" , "CR02PAGE_N01_2_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("89_idle_right", "CR02PAGE_N01_2_0006" , "CR02PAGE_N01_2_0007" , "CR02PAGE_N01_2_0008" , "CR02PAGE_N01_2_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("89_idle_front_right", "CR02PAGE_N01_2_0009" , "CR02PAGE_N01_2_0010" , "CR02PAGE_N01_2_0011" , "CR02PAGE_N01_2_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("89_idle_front", "CR02PAGE_N01_2_0012" , "CR02PAGE_N01_2_0013" , "CR02PAGE_N01_2_0014" , "CR02PAGE_N01_2_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("89_idle_front_left", "CR02PAGE_N01_2_0015" , "CR02PAGE_N01_2_0016" , "CR02PAGE_N01_2_0017" , "CR02PAGE_N01_2_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("89_idle_left", "CR02PAGE_N01_2_0018" , "CR02PAGE_N01_2_0019" , "CR02PAGE_N01_2_0020" , "CR02PAGE_N01_2_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("89_idle_rear_left", "CR02PAGE_N01_2_0021" , "CR02PAGE_N01_2_0022" , "CR02PAGE_N01_2_0023" , "CR02PAGE_N01_2_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("89_walking_rear", "CR02PAGE_N01_2_0001" , "CR02PAGE_N01_2_0024" , "CR02PAGE_N01_2_0025" , "CR02PAGE_N01_2_0026" , "" , "" , "" , "" ,4);
		CreateAnimationUW("89_walking_rear_right", "CR02PAGE_N01_2_0027" , "CR02PAGE_N01_2_0028" , "CR02PAGE_N01_2_0029" , "CR02PAGE_N01_2_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("89_walking_right", "CR02PAGE_N01_2_0030" , "CR02PAGE_N01_2_0031" , "CR02PAGE_N01_2_0007" , "CR02PAGE_N01_2_0032" , "" , "" , "" , "" ,4);
		CreateAnimationUW("89_walking_front_right", "CR02PAGE_N01_2_0010" , "CR02PAGE_N01_2_0033" , "CR02PAGE_N01_2_0034" , "CR02PAGE_N01_2_0035" , "" , "" , "" , "" ,4);
		CreateAnimationUW("89_walking_front", "CR02PAGE_N01_2_0036" , "CR02PAGE_N01_2_0037" , "CR02PAGE_N01_2_0038" , "CR02PAGE_N01_2_0039" , "" , "" , "" , "" ,4);
		CreateAnimationUW("89_walking_front_left", "CR02PAGE_N01_2_0040" , "CR02PAGE_N01_2_0041" , "CR02PAGE_N01_2_0016" , "CR02PAGE_N01_2_0042" , "" , "" , "" , "" ,4);
		CreateAnimationUW("89_walking_left", "CR02PAGE_N01_2_0019" , "CR02PAGE_N01_2_0043" , "CR02PAGE_N01_2_0044" , "CR02PAGE_N01_2_0045" , "" , "" , "" , "" ,4);
		CreateAnimationUW("89_walking_rear_left", "CR02PAGE_N01_2_0046" , "CR02PAGE_N01_2_0022" , "CR02PAGE_N01_2_0047" , "CR02PAGE_N01_2_0048" , "" , "" , "" , "" ,4);
		//Anim ID: 26 - which is an_outcast
		//	File:c:\games\uw1\crit\CR32PAGE.N00, Palette = 0
		CreateAnimationUW("90_combat_idle", "CR32PAGE_N00_0_0000" , "CR32PAGE_N00_0_0001" , "CR32PAGE_N00_0_0000" , "CR32PAGE_N00_0_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("90_attack_bash", "CR32PAGE_N00_0_0000" , "CR32PAGE_N00_0_0001" , "CR32PAGE_N00_0_0002" , "CR32PAGE_N00_0_0001" , "CR32PAGE_N00_0_0000" , "" , "" , "" ,5);
		CreateAnimationUW("90_attack_slash", "CR32PAGE_N00_0_0000" , "CR32PAGE_N00_0_0003" , "CR32PAGE_N00_0_0004" , "CR32PAGE_N00_0_0005" , "CR32PAGE_N00_0_0000" , "" , "" , "" ,5);
		CreateAnimationUW("90_attack_thrust", "CR32PAGE_N00_0_0000" , "CR32PAGE_N00_0_0001" , "CR32PAGE_N00_0_0004" , "CR32PAGE_N00_0_0006" , "CR32PAGE_N00_0_0001" , "" , "" , "" ,5);
		CreateAnimationUW("90_walking_towards", "CR32PAGE_N00_0_0007" , "CR32PAGE_N00_0_0008" , "CR32PAGE_N00_0_0009" , "CR32PAGE_N00_0_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("90_death", "CR32PAGE_N00_0_0000" , "CR32PAGE_N00_0_0000" , "CR32PAGE_N00_0_0011" , "CR32PAGE_N00_0_0012" , "" , "" , "" , "" ,4);
		CreateAnimationUW("90_begin_combat", "CR32PAGE_N00_0_0013" , "CR32PAGE_N00_0_0014" , "CR32PAGE_N00_0_0000" , "CR32PAGE_N00_0_0000" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR32PAGE.N01, Palette = 0
		CreateAnimationUW("90_idle_rear", "CR32PAGE_N01_0_0000" , "CR32PAGE_N01_0_0001" , "CR32PAGE_N01_0_0002" , "CR32PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("90_idle_rear_right", "CR32PAGE_N01_0_0003" , "CR32PAGE_N01_0_0004" , "CR32PAGE_N01_0_0005" , "CR32PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("90_idle_right", "CR32PAGE_N01_0_0006" , "CR32PAGE_N01_0_0007" , "CR32PAGE_N01_0_0008" , "CR32PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("90_idle_front_right", "CR32PAGE_N01_0_0009" , "CR32PAGE_N01_0_0010" , "CR32PAGE_N01_0_0011" , "CR32PAGE_N01_0_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("90_idle_front", "CR32PAGE_N01_0_0012" , "CR32PAGE_N01_0_0013" , "CR32PAGE_N01_0_0014" , "CR32PAGE_N01_0_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("90_idle_front_left", "CR32PAGE_N01_0_0015" , "CR32PAGE_N01_0_0016" , "CR32PAGE_N01_0_0017" , "CR32PAGE_N01_0_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("90_idle_left", "CR32PAGE_N01_0_0018" , "CR32PAGE_N01_0_0019" , "CR32PAGE_N01_0_0020" , "CR32PAGE_N01_0_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("90_idle_rear_left", "CR32PAGE_N01_0_0021" , "CR32PAGE_N01_0_0022" , "CR32PAGE_N01_0_0023" , "CR32PAGE_N01_0_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("90_walking_rear", "CR32PAGE_N01_0_0001" , "CR32PAGE_N01_0_0024" , "CR32PAGE_N01_0_0025" , "CR32PAGE_N01_0_0026" , "" , "" , "" , "" ,4);
		CreateAnimationUW("90_walking_rear_right", "CR32PAGE_N01_0_0027" , "CR32PAGE_N01_0_0028" , "CR32PAGE_N01_0_0004" , "CR32PAGE_N01_0_0029" , "" , "" , "" , "" ,4);
		CreateAnimationUW("90_walking_right", "CR32PAGE_N01_0_0030" , "CR32PAGE_N01_0_0031" , "CR32PAGE_N01_0_0032" , "CR32PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("90_walking_front_right", "CR32PAGE_N01_0_0033" , "CR32PAGE_N01_0_0010" , "CR32PAGE_N01_0_0034" , "CR32PAGE_N01_0_0035" , "" , "" , "" , "" ,4);
		CreateAnimationUW("90_walking_front", "CR32PAGE_N01_0_0036" , "CR32PAGE_N01_0_0037" , "CR32PAGE_N01_0_0038" , "CR32PAGE_N01_0_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("90_walking_front_left", "CR32PAGE_N01_0_0039" , "CR32PAGE_N01_0_0016" , "CR32PAGE_N01_0_0040" , "CR32PAGE_N01_0_0041" , "" , "" , "" , "" ,4);
		CreateAnimationUW("90_walking_left", "CR32PAGE_N01_0_0042" , "CR32PAGE_N01_0_0043" , "CR32PAGE_N01_0_0044" , "CR32PAGE_N01_0_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("90_walking_rear_left", "CR32PAGE_N01_0_0045" , "CR32PAGE_N01_0_0046" , "CR32PAGE_N01_0_0022" , "CR32PAGE_N01_0_0047" , "" , "" , "" , "" ,4);
		//Anim ID: 27 - which is a_headless_headlesses
		//	File:c:\games\uw1\crit\CR24PAGE.N00, Palette = 0
		CreateAnimationUW("91_combat_idle", "CR24PAGE_N00_0_0000" , "CR24PAGE_N00_0_0000" , "CR24PAGE_N00_0_0001" , "CR24PAGE_N00_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("91_attack_bash", "CR24PAGE_N00_0_0002" , "CR24PAGE_N00_0_0003" , "CR24PAGE_N00_0_0004" , "CR24PAGE_N00_0_0005" , "CR24PAGE_N00_0_0006" , "" , "" , "" ,5);
		CreateAnimationUW("91_attack_slash", "CR24PAGE_N00_0_0007" , "CR24PAGE_N00_0_0008" , "CR24PAGE_N00_0_0009" , "CR24PAGE_N00_0_0010" , "CR24PAGE_N00_0_0011" , "" , "" , "" ,5);
		CreateAnimationUW("91_attack_thrust", "CR24PAGE_N00_0_0002" , "CR24PAGE_N00_0_0003" , "CR24PAGE_N00_0_0004" , "CR24PAGE_N00_0_0005" , "CR24PAGE_N00_0_0006" , "" , "" , "" ,5);
		CreateAnimationUW("91_walking_towards", "CR24PAGE_N00_0_0000" , "CR24PAGE_N00_0_0012" , "CR24PAGE_N00_0_0001" , "CR24PAGE_N00_0_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("91_death", "CR24PAGE_N00_0_0012" , "CR24PAGE_N00_0_0014" , "CR24PAGE_N00_0_0015" , "CR24PAGE_N00_0_0016" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR24PAGE.N01, Palette = 0
		CreateAnimationUW("91_idle_rear", "CR24PAGE_N01_0_0000" , "CR24PAGE_N01_0_0000" , "CR24PAGE_N01_0_0001" , "CR24PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("91_idle_rear_right", "CR24PAGE_N01_0_0002" , "CR24PAGE_N01_0_0002" , "CR24PAGE_N01_0_0003" , "CR24PAGE_N01_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("91_idle_right", "CR24PAGE_N01_0_0004" , "CR24PAGE_N01_0_0004" , "CR24PAGE_N01_0_0005" , "CR24PAGE_N01_0_0005" , "" , "" , "" , "" ,4);
		CreateAnimationUW("91_idle_front_right", "CR24PAGE_N01_0_0006" , "CR24PAGE_N01_0_0006" , "CR24PAGE_N01_0_0007" , "CR24PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("91_idle_front", "CR24PAGE_N01_0_0008" , "CR24PAGE_N01_0_0008" , "CR24PAGE_N01_0_0009" , "CR24PAGE_N01_0_0009" , "" , "" , "" , "" ,4);
		CreateAnimationUW("91_idle_front_left", "CR24PAGE_N01_0_0010" , "CR24PAGE_N01_0_0010" , "CR24PAGE_N01_0_0011" , "CR24PAGE_N01_0_0011" , "" , "" , "" , "" ,4);
		CreateAnimationUW("91_idle_left", "CR24PAGE_N01_0_0012" , "CR24PAGE_N01_0_0012" , "CR24PAGE_N01_0_0013" , "CR24PAGE_N01_0_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("91_idle_rear_left", "CR24PAGE_N01_0_0014" , "CR24PAGE_N01_0_0014" , "CR24PAGE_N01_0_0015" , "CR24PAGE_N01_0_0015" , "" , "" , "" , "" ,4);
		CreateAnimationUW("91_walking_rear", "CR24PAGE_N01_0_0016" , "CR24PAGE_N01_0_0000" , "CR24PAGE_N01_0_0017" , "CR24PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("91_walking_rear_right", "CR24PAGE_N01_0_0018" , "CR24PAGE_N01_0_0002" , "CR24PAGE_N01_0_0019" , "CR24PAGE_N01_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("91_walking_right", "CR24PAGE_N01_0_0020" , "CR24PAGE_N01_0_0004" , "CR24PAGE_N01_0_0021" , "CR24PAGE_N01_0_0005" , "" , "" , "" , "" ,4);
		CreateAnimationUW("91_walking_front_right", "CR24PAGE_N01_0_0022" , "CR24PAGE_N01_0_0006" , "CR24PAGE_N01_0_0023" , "CR24PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("91_walking_front", "CR24PAGE_N01_0_0009" , "CR24PAGE_N01_0_0024" , "CR24PAGE_N01_0_0008" , "CR24PAGE_N01_0_0025" , "" , "" , "" , "" ,4);
		CreateAnimationUW("91_walking_front_left", "CR24PAGE_N01_0_0026" , "CR24PAGE_N01_0_0011" , "CR24PAGE_N01_0_0027" , "CR24PAGE_N01_0_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("91_walking_left", "CR24PAGE_N01_0_0028" , "CR24PAGE_N01_0_0012" , "CR24PAGE_N01_0_0029" , "CR24PAGE_N01_0_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("91_walking_rear_left", "CR24PAGE_N01_0_0030" , "CR24PAGE_N01_0_0015" , "CR24PAGE_N01_0_0031" , "CR24PAGE_N01_0_0014" , "" , "" , "" , "" ,4);
		//Anim ID: 28 - which is a_dread_spider
		//	File:c:\games\uw1\crit\CR05PAGE.N00, Palette = 2
		CreateAnimationUW("92_combat_idle", "CR05PAGE_N00_2_0000" , "CR05PAGE_N00_2_0001" , "CR05PAGE_N00_2_0000" , "CR05PAGE_N00_2_0002" , "" , "" , "" , "" ,4);
		CreateAnimationUW("92_attack_bash", "CR05PAGE_N00_2_0003" , "CR05PAGE_N00_2_0004" , "CR05PAGE_N00_2_0005" , "CR05PAGE_N00_2_0006" , "CR05PAGE_N00_2_0004" , "" , "" , "" ,5);
		CreateAnimationUW("92_attack_slash", "CR05PAGE_N00_2_0000" , "CR05PAGE_N00_2_0007" , "CR05PAGE_N00_2_0008" , "CR05PAGE_N00_2_0009" , "CR05PAGE_N00_2_0010" , "" , "" , "" ,5);
		CreateAnimationUW("92_attack_thrust", "CR05PAGE_N00_2_0001" , "CR05PAGE_N00_2_0011" , "CR05PAGE_N00_2_0003" , "CR05PAGE_N00_2_0004" , "CR05PAGE_N00_2_0003" , "" , "" , "" ,5);
		CreateAnimationUW("92_walking_towards", "CR05PAGE_N00_2_0012" , "CR05PAGE_N00_2_0013" , "CR05PAGE_N00_2_0000" , "CR05PAGE_N00_2_0014" , "" , "" , "" , "" ,4);
		CreateAnimationUW("92_death", "CR05PAGE_N00_2_0000" , "CR05PAGE_N00_2_0011" , "CR05PAGE_N00_2_0015" , "CR05PAGE_N00_2_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("92_begin_combat", "CR05PAGE_N00_2_0003" , "CR05PAGE_N00_2_0004" , "CR05PAGE_N00_2_0005" , "CR05PAGE_N00_2_0006" , "CR05PAGE_N00_2_0003" , "" , "" , "" ,5);
		//	File:c:\games\uw1\crit\CR05PAGE.N01, Palette = 2
		CreateAnimationUW("92_idle_rear", "CR05PAGE_N01_2_0000" , "CR05PAGE_N01_2_0000" , "CR05PAGE_N01_2_0000" , "CR05PAGE_N01_2_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("92_idle_rear_right", "CR05PAGE_N01_2_0001" , "CR05PAGE_N01_2_0001" , "CR05PAGE_N01_2_0001" , "CR05PAGE_N01_2_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("92_idle_right", "CR05PAGE_N01_2_0002" , "CR05PAGE_N01_2_0002" , "CR05PAGE_N01_2_0002" , "CR05PAGE_N01_2_0002" , "" , "" , "" , "" ,4);
		CreateAnimationUW("92_idle_front_right", "CR05PAGE_N01_2_0003" , "CR05PAGE_N01_2_0003" , "CR05PAGE_N01_2_0003" , "CR05PAGE_N01_2_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("92_idle_front", "CR05PAGE_N01_2_0004" , "CR05PAGE_N01_2_0004" , "CR05PAGE_N01_2_0004" , "CR05PAGE_N01_2_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("92_idle_front_left", "CR05PAGE_N01_2_0005" , "CR05PAGE_N01_2_0005" , "CR05PAGE_N01_2_0005" , "CR05PAGE_N01_2_0005" , "" , "" , "" , "" ,4);
		CreateAnimationUW("92_idle_left", "CR05PAGE_N01_2_0006" , "CR05PAGE_N01_2_0006" , "CR05PAGE_N01_2_0006" , "CR05PAGE_N01_2_0006" , "" , "" , "" , "" ,4);
		CreateAnimationUW("92_idle_rear_left", "CR05PAGE_N01_2_0007" , "CR05PAGE_N01_2_0007" , "CR05PAGE_N01_2_0007" , "CR05PAGE_N01_2_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("92_walking_rear", "CR05PAGE_N01_2_0000" , "CR05PAGE_N01_2_0008" , "CR05PAGE_N01_2_0009" , "CR05PAGE_N01_2_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("92_walking_rear_right", "CR05PAGE_N01_2_0011" , "CR05PAGE_N01_2_0012" , "CR05PAGE_N01_2_0001" , "CR05PAGE_N01_2_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("92_walking_right", "CR05PAGE_N01_2_0002" , "CR05PAGE_N01_2_0014" , "CR05PAGE_N01_2_0015" , "CR05PAGE_N01_2_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("92_walking_front_right", "CR05PAGE_N01_2_0003" , "CR05PAGE_N01_2_0017" , "CR05PAGE_N01_2_0018" , "CR05PAGE_N01_2_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("92_walking_front", "CR05PAGE_N01_2_0020" , "CR05PAGE_N01_2_0021" , "CR05PAGE_N01_2_0004" , "CR05PAGE_N01_2_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("92_walking_front_left", "CR05PAGE_N01_2_0005" , "CR05PAGE_N01_2_0023" , "CR05PAGE_N01_2_0024" , "CR05PAGE_N01_2_0025" , "" , "" , "" , "" ,4);
		CreateAnimationUW("92_walking_left", "CR05PAGE_N01_2_0006" , "CR05PAGE_N01_2_0026" , "CR05PAGE_N01_2_0027" , "CR05PAGE_N01_2_0028" , "" , "" , "" , "" ,4);
		CreateAnimationUW("92_walking_rear_left", "CR05PAGE_N01_2_0029" , "CR05PAGE_N01_2_0030" , "CR05PAGE_N01_2_0007" , "CR05PAGE_N01_2_0031" , "" , "" , "" , "" ,4);
		//Anim ID: 29 - which is a_fighter
		//	File:c:\games\uw1\crit\CR21PAGE.N00, Palette = 0
		CreateAnimationUW("93_combat_idle", "CR21PAGE_N00_0_0000" , "CR21PAGE_N00_0_0001" , "CR21PAGE_N00_0_0000" , "CR21PAGE_N00_0_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("93_attack_bash", "CR21PAGE_N00_0_0000" , "CR21PAGE_N00_0_0001" , "CR21PAGE_N00_0_0002" , "CR21PAGE_N00_0_0001" , "CR21PAGE_N00_0_0000" , "" , "" , "" ,5);
		CreateAnimationUW("93_attack_slash", "CR21PAGE_N00_0_0000" , "CR21PAGE_N00_0_0003" , "CR21PAGE_N00_0_0004" , "CR21PAGE_N00_0_0005" , "CR21PAGE_N00_0_0000" , "" , "" , "" ,5);
		CreateAnimationUW("93_attack_thrust", "CR21PAGE_N00_0_0000" , "CR21PAGE_N00_0_0001" , "CR21PAGE_N00_0_0004" , "CR21PAGE_N00_0_0006" , "CR21PAGE_N00_0_0001" , "" , "" , "" ,5);
		CreateAnimationUW("93_walking_towards", "CR21PAGE_N00_0_0007" , "CR21PAGE_N00_0_0008" , "CR21PAGE_N00_0_0009" , "CR21PAGE_N00_0_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("93_death", "CR21PAGE_N00_0_0000" , "CR21PAGE_N00_0_0000" , "CR21PAGE_N00_0_0011" , "CR21PAGE_N00_0_0012" , "" , "" , "" , "" ,4);
		CreateAnimationUW("93_begin_combat", "CR21PAGE_N00_0_0013" , "CR21PAGE_N00_0_0014" , "CR21PAGE_N00_0_0000" , "CR21PAGE_N00_0_0000" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR21PAGE.N01, Palette = 0
		CreateAnimationUW("93_idle_rear", "CR21PAGE_N01_0_0000" , "CR21PAGE_N01_0_0001" , "CR21PAGE_N01_0_0002" , "CR21PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("93_idle_rear_right", "CR21PAGE_N01_0_0003" , "CR21PAGE_N01_0_0004" , "CR21PAGE_N01_0_0005" , "CR21PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("93_idle_right", "CR21PAGE_N01_0_0006" , "CR21PAGE_N01_0_0007" , "CR21PAGE_N01_0_0008" , "CR21PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("93_idle_front_right", "CR21PAGE_N01_0_0009" , "CR21PAGE_N01_0_0010" , "CR21PAGE_N01_0_0011" , "CR21PAGE_N01_0_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("93_idle_front", "CR21PAGE_N01_0_0012" , "CR21PAGE_N01_0_0013" , "CR21PAGE_N01_0_0014" , "CR21PAGE_N01_0_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("93_idle_front_left", "CR21PAGE_N01_0_0015" , "CR21PAGE_N01_0_0016" , "CR21PAGE_N01_0_0017" , "CR21PAGE_N01_0_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("93_idle_left", "CR21PAGE_N01_0_0018" , "CR21PAGE_N01_0_0019" , "CR21PAGE_N01_0_0020" , "CR21PAGE_N01_0_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("93_idle_rear_left", "CR21PAGE_N01_0_0021" , "CR21PAGE_N01_0_0022" , "CR21PAGE_N01_0_0023" , "CR21PAGE_N01_0_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("93_walking_rear", "CR21PAGE_N01_0_0001" , "CR21PAGE_N01_0_0024" , "CR21PAGE_N01_0_0025" , "CR21PAGE_N01_0_0026" , "" , "" , "" , "" ,4);
		CreateAnimationUW("93_walking_rear_right", "CR21PAGE_N01_0_0027" , "CR21PAGE_N01_0_0028" , "CR21PAGE_N01_0_0004" , "CR21PAGE_N01_0_0029" , "" , "" , "" , "" ,4);
		CreateAnimationUW("93_walking_right", "CR21PAGE_N01_0_0030" , "CR21PAGE_N01_0_0031" , "CR21PAGE_N01_0_0032" , "CR21PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("93_walking_front_right", "CR21PAGE_N01_0_0033" , "CR21PAGE_N01_0_0010" , "CR21PAGE_N01_0_0034" , "CR21PAGE_N01_0_0035" , "" , "" , "" , "" ,4);
		CreateAnimationUW("93_walking_front", "CR21PAGE_N01_0_0036" , "CR21PAGE_N01_0_0037" , "CR21PAGE_N01_0_0038" , "CR21PAGE_N01_0_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("93_walking_front_left", "CR21PAGE_N01_0_0039" , "CR21PAGE_N01_0_0016" , "CR21PAGE_N01_0_0040" , "CR21PAGE_N01_0_0041" , "" , "" , "" , "" ,4);
		CreateAnimationUW("93_walking_left", "CR21PAGE_N01_0_0042" , "CR21PAGE_N01_0_0043" , "CR21PAGE_N01_0_0044" , "CR21PAGE_N01_0_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("93_walking_rear_left", "CR21PAGE_N01_0_0045" , "CR21PAGE_N01_0_0046" , "CR21PAGE_N01_0_0022" , "CR21PAGE_N01_0_0047" , "" , "" , "" , "" ,4);
		//Anim ID: 30 - which is a_fighter
		//	File:c:\games\uw1\crit\CR21PAGE.N00, Palette = 1
		CreateAnimationUW("94_combat_idle", "CR21PAGE_N00_1_0000" , "CR21PAGE_N00_1_0001" , "CR21PAGE_N00_1_0000" , "CR21PAGE_N00_1_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("94_attack_bash", "CR21PAGE_N00_1_0000" , "CR21PAGE_N00_1_0001" , "CR21PAGE_N00_1_0002" , "CR21PAGE_N00_1_0001" , "CR21PAGE_N00_1_0000" , "" , "" , "" ,5);
		CreateAnimationUW("94_attack_slash", "CR21PAGE_N00_1_0000" , "CR21PAGE_N00_1_0003" , "CR21PAGE_N00_1_0004" , "CR21PAGE_N00_1_0005" , "CR21PAGE_N00_1_0000" , "" , "" , "" ,5);
		CreateAnimationUW("94_attack_thrust", "CR21PAGE_N00_1_0000" , "CR21PAGE_N00_1_0001" , "CR21PAGE_N00_1_0004" , "CR21PAGE_N00_1_0006" , "CR21PAGE_N00_1_0001" , "" , "" , "" ,5);
		CreateAnimationUW("94_walking_towards", "CR21PAGE_N00_1_0007" , "CR21PAGE_N00_1_0008" , "CR21PAGE_N00_1_0009" , "CR21PAGE_N00_1_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("94_death", "CR21PAGE_N00_1_0000" , "CR21PAGE_N00_1_0000" , "CR21PAGE_N00_1_0011" , "CR21PAGE_N00_1_0012" , "" , "" , "" , "" ,4);
		CreateAnimationUW("94_begin_combat", "CR21PAGE_N00_1_0013" , "CR21PAGE_N00_1_0014" , "CR21PAGE_N00_1_0000" , "CR21PAGE_N00_1_0000" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR21PAGE.N01, Palette = 1
		CreateAnimationUW("94_idle_rear", "CR21PAGE_N01_1_0000" , "CR21PAGE_N01_1_0001" , "CR21PAGE_N01_1_0002" , "CR21PAGE_N01_1_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("94_idle_rear_right", "CR21PAGE_N01_1_0003" , "CR21PAGE_N01_1_0004" , "CR21PAGE_N01_1_0005" , "CR21PAGE_N01_1_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("94_idle_right", "CR21PAGE_N01_1_0006" , "CR21PAGE_N01_1_0007" , "CR21PAGE_N01_1_0008" , "CR21PAGE_N01_1_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("94_idle_front_right", "CR21PAGE_N01_1_0009" , "CR21PAGE_N01_1_0010" , "CR21PAGE_N01_1_0011" , "CR21PAGE_N01_1_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("94_idle_front", "CR21PAGE_N01_1_0012" , "CR21PAGE_N01_1_0013" , "CR21PAGE_N01_1_0014" , "CR21PAGE_N01_1_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("94_idle_front_left", "CR21PAGE_N01_1_0015" , "CR21PAGE_N01_1_0016" , "CR21PAGE_N01_1_0017" , "CR21PAGE_N01_1_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("94_idle_left", "CR21PAGE_N01_1_0018" , "CR21PAGE_N01_1_0019" , "CR21PAGE_N01_1_0020" , "CR21PAGE_N01_1_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("94_idle_rear_left", "CR21PAGE_N01_1_0021" , "CR21PAGE_N01_1_0022" , "CR21PAGE_N01_1_0023" , "CR21PAGE_N01_1_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("94_walking_rear", "CR21PAGE_N01_1_0001" , "CR21PAGE_N01_1_0024" , "CR21PAGE_N01_1_0025" , "CR21PAGE_N01_1_0026" , "" , "" , "" , "" ,4);
		CreateAnimationUW("94_walking_rear_right", "CR21PAGE_N01_1_0027" , "CR21PAGE_N01_1_0028" , "CR21PAGE_N01_1_0004" , "CR21PAGE_N01_1_0029" , "" , "" , "" , "" ,4);
		CreateAnimationUW("94_walking_right", "CR21PAGE_N01_1_0030" , "CR21PAGE_N01_1_0031" , "CR21PAGE_N01_1_0032" , "CR21PAGE_N01_1_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("94_walking_front_right", "CR21PAGE_N01_1_0033" , "CR21PAGE_N01_1_0010" , "CR21PAGE_N01_1_0034" , "CR21PAGE_N01_1_0035" , "" , "" , "" , "" ,4);
		CreateAnimationUW("94_walking_front", "CR21PAGE_N01_1_0036" , "CR21PAGE_N01_1_0037" , "CR21PAGE_N01_1_0038" , "CR21PAGE_N01_1_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("94_walking_front_left", "CR21PAGE_N01_1_0039" , "CR21PAGE_N01_1_0016" , "CR21PAGE_N01_1_0040" , "CR21PAGE_N01_1_0041" , "" , "" , "" , "" ,4);
		CreateAnimationUW("94_walking_left", "CR21PAGE_N01_1_0042" , "CR21PAGE_N01_1_0043" , "CR21PAGE_N01_1_0044" , "CR21PAGE_N01_1_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("94_walking_rear_left", "CR21PAGE_N01_1_0045" , "CR21PAGE_N01_1_0046" , "CR21PAGE_N01_1_0022" , "CR21PAGE_N01_1_0047" , "" , "" , "" , "" ,4);
		//Anim ID: 31 - which is a_fighter
		//	File:c:\games\uw1\crit\CR32PAGE.N00, Palette = 3
		CreateAnimationUW("95_combat_idle", "CR32PAGE_N00_3_0000" , "CR32PAGE_N00_3_0001" , "CR32PAGE_N00_3_0000" , "CR32PAGE_N00_3_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("95_attack_bash", "CR32PAGE_N00_3_0000" , "CR32PAGE_N00_3_0001" , "CR32PAGE_N00_3_0002" , "CR32PAGE_N00_3_0001" , "CR32PAGE_N00_3_0000" , "" , "" , "" ,5);
		CreateAnimationUW("95_attack_slash", "CR32PAGE_N00_3_0000" , "CR32PAGE_N00_3_0003" , "CR32PAGE_N00_3_0004" , "CR32PAGE_N00_3_0005" , "CR32PAGE_N00_3_0000" , "" , "" , "" ,5);
		CreateAnimationUW("95_attack_thrust", "CR32PAGE_N00_3_0000" , "CR32PAGE_N00_3_0001" , "CR32PAGE_N00_3_0004" , "CR32PAGE_N00_3_0006" , "CR32PAGE_N00_3_0001" , "" , "" , "" ,5);
		CreateAnimationUW("95_walking_towards", "CR32PAGE_N00_3_0007" , "CR32PAGE_N00_3_0008" , "CR32PAGE_N00_3_0009" , "CR32PAGE_N00_3_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("95_death", "CR32PAGE_N00_3_0000" , "CR32PAGE_N00_3_0000" , "CR32PAGE_N00_3_0011" , "CR32PAGE_N00_3_0012" , "" , "" , "" , "" ,4);
		CreateAnimationUW("95_begin_combat", "CR32PAGE_N00_3_0013" , "CR32PAGE_N00_3_0014" , "CR32PAGE_N00_3_0000" , "CR32PAGE_N00_3_0000" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR32PAGE.N01, Palette = 3
		CreateAnimationUW("95_idle_rear", "CR32PAGE_N01_3_0000" , "CR32PAGE_N01_3_0001" , "CR32PAGE_N01_3_0002" , "CR32PAGE_N01_3_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("95_idle_rear_right", "CR32PAGE_N01_3_0003" , "CR32PAGE_N01_3_0004" , "CR32PAGE_N01_3_0005" , "CR32PAGE_N01_3_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("95_idle_right", "CR32PAGE_N01_3_0006" , "CR32PAGE_N01_3_0007" , "CR32PAGE_N01_3_0008" , "CR32PAGE_N01_3_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("95_idle_front_right", "CR32PAGE_N01_3_0009" , "CR32PAGE_N01_3_0010" , "CR32PAGE_N01_3_0011" , "CR32PAGE_N01_3_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("95_idle_front", "CR32PAGE_N01_3_0012" , "CR32PAGE_N01_3_0013" , "CR32PAGE_N01_3_0014" , "CR32PAGE_N01_3_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("95_idle_front_left", "CR32PAGE_N01_3_0015" , "CR32PAGE_N01_3_0016" , "CR32PAGE_N01_3_0017" , "CR32PAGE_N01_3_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("95_idle_left", "CR32PAGE_N01_3_0018" , "CR32PAGE_N01_3_0019" , "CR32PAGE_N01_3_0020" , "CR32PAGE_N01_3_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("95_idle_rear_left", "CR32PAGE_N01_3_0021" , "CR32PAGE_N01_3_0022" , "CR32PAGE_N01_3_0023" , "CR32PAGE_N01_3_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("95_walking_rear", "CR32PAGE_N01_3_0001" , "CR32PAGE_N01_3_0024" , "CR32PAGE_N01_3_0025" , "CR32PAGE_N01_3_0026" , "" , "" , "" , "" ,4);
		CreateAnimationUW("95_walking_rear_right", "CR32PAGE_N01_3_0027" , "CR32PAGE_N01_3_0028" , "CR32PAGE_N01_3_0004" , "CR32PAGE_N01_3_0029" , "" , "" , "" , "" ,4);
		CreateAnimationUW("95_walking_right", "CR32PAGE_N01_3_0030" , "CR32PAGE_N01_3_0031" , "CR32PAGE_N01_3_0032" , "CR32PAGE_N01_3_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("95_walking_front_right", "CR32PAGE_N01_3_0033" , "CR32PAGE_N01_3_0010" , "CR32PAGE_N01_3_0034" , "CR32PAGE_N01_3_0035" , "" , "" , "" , "" ,4);
		CreateAnimationUW("95_walking_front", "CR32PAGE_N01_3_0036" , "CR32PAGE_N01_3_0037" , "CR32PAGE_N01_3_0038" , "CR32PAGE_N01_3_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("95_walking_front_left", "CR32PAGE_N01_3_0039" , "CR32PAGE_N01_3_0016" , "CR32PAGE_N01_3_0040" , "CR32PAGE_N01_3_0041" , "" , "" , "" , "" ,4);
		CreateAnimationUW("95_walking_left", "CR32PAGE_N01_3_0042" , "CR32PAGE_N01_3_0043" , "CR32PAGE_N01_3_0044" , "CR32PAGE_N01_3_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("95_walking_rear_left", "CR32PAGE_N01_3_0045" , "CR32PAGE_N01_3_0046" , "CR32PAGE_N01_3_0022" , "CR32PAGE_N01_3_0047" , "" , "" , "" , "" ,4);
		//Anim ID: 32 - which is a_troll
		//	File:c:\games\uw1\crit\CR07PAGE.N00, Palette = 0
		CreateAnimationUW("96_combat_idle", "CR07PAGE_N00_0_0000" , "CR07PAGE_N00_0_0001" , "CR07PAGE_N00_0_0002" , "CR07PAGE_N00_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("96_attack_bash", "CR07PAGE_N00_0_0000" , "CR07PAGE_N00_0_0002" , "CR07PAGE_N00_0_0004" , "CR07PAGE_N00_0_0005" , "CR07PAGE_N00_0_0002" , "" , "" , "" ,5);
		CreateAnimationUW("96_attack_slash", "CR07PAGE_N00_0_0002" , "CR07PAGE_N00_0_0000" , "CR07PAGE_N00_0_0006" , "CR07PAGE_N00_0_0007" , "CR07PAGE_N00_0_0002" , "" , "" , "" ,5);
		CreateAnimationUW("96_attack_thrust", "CR07PAGE_N00_0_0000" , "CR07PAGE_N00_0_0002" , "CR07PAGE_N00_0_0004" , "CR07PAGE_N00_0_0005" , "CR07PAGE_N00_0_0002" , "" , "" , "" ,5);
		CreateAnimationUW("96_walking_towards", "CR07PAGE_N00_0_0008" , "CR07PAGE_N00_0_0009" , "CR07PAGE_N00_0_0010" , "CR07PAGE_N00_0_0011" , "" , "" , "" , "" ,4);
		CreateAnimationUW("96_death", "CR07PAGE_N00_0_0000" , "CR07PAGE_N00_0_0012" , "CR07PAGE_N00_0_0013" , "CR07PAGE_N00_0_0014" , "" , "" , "" , "" ,4);
		CreateAnimationUW("96_begin_combat", "CR07PAGE_N00_0_0000" , "CR07PAGE_N00_0_0002" , "CR07PAGE_N00_0_0002" , "CR07PAGE_N00_0_0000" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR07PAGE.N01, Palette = 0
		CreateAnimationUW("96_idle_rear", "CR07PAGE_N01_0_0000" , "CR07PAGE_N01_0_0001" , "CR07PAGE_N01_0_0002" , "CR07PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("96_idle_rear_right", "CR07PAGE_N01_0_0003" , "CR07PAGE_N01_0_0004" , "CR07PAGE_N01_0_0005" , "CR07PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("96_idle_right", "CR07PAGE_N01_0_0006" , "CR07PAGE_N01_0_0007" , "CR07PAGE_N01_0_0008" , "CR07PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("96_idle_front_right", "CR07PAGE_N01_0_0009" , "CR07PAGE_N01_0_0010" , "CR07PAGE_N01_0_0011" , "CR07PAGE_N01_0_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("96_idle_front", "CR07PAGE_N01_0_0012" , "CR07PAGE_N01_0_0013" , "CR07PAGE_N01_0_0014" , "CR07PAGE_N01_0_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("96_idle_front_left", "CR07PAGE_N01_0_0015" , "CR07PAGE_N01_0_0016" , "CR07PAGE_N01_0_0017" , "CR07PAGE_N01_0_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("96_idle_left", "CR07PAGE_N01_0_0018" , "CR07PAGE_N01_0_0019" , "CR07PAGE_N01_0_0020" , "CR07PAGE_N01_0_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("96_idle_rear_left", "CR07PAGE_N01_0_0021" , "CR07PAGE_N01_0_0022" , "CR07PAGE_N01_0_0023" , "CR07PAGE_N01_0_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("96_walking_rear", "CR07PAGE_N01_0_0024" , "CR07PAGE_N01_0_0025" , "CR07PAGE_N01_0_0001" , "CR07PAGE_N01_0_0026" , "" , "" , "" , "" ,4);
		CreateAnimationUW("96_walking_rear_right", "CR07PAGE_N01_0_0027" , "CR07PAGE_N01_0_0028" , "CR07PAGE_N01_0_0004" , "CR07PAGE_N01_0_0029" , "" , "" , "" , "" ,4);
		CreateAnimationUW("96_walking_right", "CR07PAGE_N01_0_0030" , "CR07PAGE_N01_0_0007" , "CR07PAGE_N01_0_0031" , "CR07PAGE_N01_0_0032" , "" , "" , "" , "" ,4);
		CreateAnimationUW("96_walking_front_right", "CR07PAGE_N01_0_0033" , "CR07PAGE_N01_0_0010" , "CR07PAGE_N01_0_0034" , "CR07PAGE_N01_0_0035" , "" , "" , "" , "" ,4);
		CreateAnimationUW("96_walking_front", "CR07PAGE_N01_0_0036" , "CR07PAGE_N01_0_0037" , "CR07PAGE_N01_0_0013" , "CR07PAGE_N01_0_0038" , "" , "" , "" , "" ,4);
		CreateAnimationUW("96_walking_front_left", "CR07PAGE_N01_0_0039" , "CR07PAGE_N01_0_0016" , "CR07PAGE_N01_0_0040" , "CR07PAGE_N01_0_0041" , "" , "" , "" , "" ,4);
		CreateAnimationUW("96_walking_left", "CR07PAGE_N01_0_0042" , "CR07PAGE_N01_0_0019" , "CR07PAGE_N01_0_0043" , "CR07PAGE_N01_0_0044" , "" , "" , "" , "" ,4);
		CreateAnimationUW("96_walking_rear_left", "CR07PAGE_N01_0_0045" , "CR07PAGE_N01_0_0046" , "CR07PAGE_N01_0_0022" , "CR07PAGE_N01_0_0047" , "" , "" , "" , "" ,4);
		//Anim ID: 33 - which is a_ghost
		//	File:c:\games\uw1\crit\CR15PAGE.N00, Palette = 0
		CreateAnimationUW("97_combat_idle", "CR15PAGE_N00_0_0000" , "CR15PAGE_N00_0_0001" , "CR15PAGE_N00_0_0002" , "CR15PAGE_N00_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("97_attack_bash", "CR15PAGE_N00_0_0004" , "CR15PAGE_N00_0_0005" , "CR15PAGE_N00_0_0006" , "CR15PAGE_N00_0_0007" , "CR15PAGE_N00_0_0002" , "" , "" , "" ,5);
		CreateAnimationUW("97_attack_slash", "CR15PAGE_N00_0_0004" , "CR15PAGE_N00_0_0005" , "CR15PAGE_N00_0_0006" , "CR15PAGE_N00_0_0007" , "CR15PAGE_N00_0_0002" , "" , "" , "" ,5);
		CreateAnimationUW("97_attack_thrust", "CR15PAGE_N00_0_0004" , "CR15PAGE_N00_0_0005" , "CR15PAGE_N00_0_0006" , "CR15PAGE_N00_0_0007" , "CR15PAGE_N00_0_0002" , "" , "" , "" ,5);
		CreateAnimationUW("97_walking_towards", "CR15PAGE_N00_0_0000" , "CR15PAGE_N00_0_0001" , "CR15PAGE_N00_0_0002" , "CR15PAGE_N00_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("97_death", "CR15PAGE_N00_0_0008" , "CR15PAGE_N00_0_0009" , "CR15PAGE_N00_0_0010" , "CR15PAGE_N00_0_0011" , "" , "" , "" , "" ,4);
		CreateAnimationUW("97_begin_combat", "CR15PAGE_N00_0_0004" , "CR15PAGE_N00_0_0005" , "CR15PAGE_N00_0_0006" , "CR15PAGE_N00_0_0007" , "CR15PAGE_N00_0_0004" , "" , "" , "" ,5);
		//	File:c:\games\uw1\crit\CR15PAGE.N01, Palette = 0
		CreateAnimationUW("97_idle_rear", "CR15PAGE_N01_0_0000" , "CR15PAGE_N01_0_0001" , "CR15PAGE_N01_0_0002" , "CR15PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("97_idle_rear_right", "CR15PAGE_N01_0_0003" , "CR15PAGE_N01_0_0004" , "CR15PAGE_N01_0_0005" , "CR15PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("97_idle_right", "CR15PAGE_N01_0_0006" , "CR15PAGE_N01_0_0007" , "CR15PAGE_N01_0_0008" , "CR15PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("97_idle_front_right", "CR15PAGE_N01_0_0009" , "CR15PAGE_N01_0_0010" , "CR15PAGE_N01_0_0011" , "CR15PAGE_N01_0_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("97_idle_front", "CR15PAGE_N01_0_0012" , "CR15PAGE_N01_0_0013" , "CR15PAGE_N01_0_0014" , "CR15PAGE_N01_0_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("97_idle_front_left", "CR15PAGE_N01_0_0015" , "CR15PAGE_N01_0_0016" , "CR15PAGE_N01_0_0017" , "CR15PAGE_N01_0_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("97_idle_left", "CR15PAGE_N01_0_0018" , "CR15PAGE_N01_0_0019" , "CR15PAGE_N01_0_0020" , "CR15PAGE_N01_0_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("97_idle_rear_left", "CR15PAGE_N01_0_0021" , "CR15PAGE_N01_0_0022" , "CR15PAGE_N01_0_0023" , "CR15PAGE_N01_0_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("97_walking_rear", "CR15PAGE_N01_0_0024" , "CR15PAGE_N01_0_0000" , "CR15PAGE_N01_0_0001" , "CR15PAGE_N01_0_0002" , "CR15PAGE_N01_0_0001" , "CR15PAGE_N01_0_0000" , "" , "" ,6);
		CreateAnimationUW("97_walking_rear_right", "CR15PAGE_N01_0_0003" , "CR15PAGE_N01_0_0004" , "CR15PAGE_N01_0_0005" , "CR15PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("97_walking_right", "CR15PAGE_N01_0_0006" , "CR15PAGE_N01_0_0007" , "CR15PAGE_N01_0_0008" , "CR15PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("97_walking_front_right", "CR15PAGE_N01_0_0009" , "CR15PAGE_N01_0_0010" , "CR15PAGE_N01_0_0011" , "CR15PAGE_N01_0_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("97_walking_front", "CR15PAGE_N01_0_0012" , "CR15PAGE_N01_0_0013" , "CR15PAGE_N01_0_0014" , "CR15PAGE_N01_0_0025" , "CR15PAGE_N01_0_0014" , "CR15PAGE_N01_0_0013" , "" , "" ,6);
		CreateAnimationUW("97_walking_front_left", "CR15PAGE_N01_0_0015" , "CR15PAGE_N01_0_0016" , "CR15PAGE_N01_0_0017" , "CR15PAGE_N01_0_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("97_walking_left", "CR15PAGE_N01_0_0018" , "CR15PAGE_N01_0_0019" , "CR15PAGE_N01_0_0020" , "CR15PAGE_N01_0_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("97_walking_rear_left", "CR15PAGE_N01_0_0021" , "CR15PAGE_N01_0_0022" , "CR15PAGE_N01_0_0023" , "CR15PAGE_N01_0_0022" , "" , "" , "" , "" ,4);
		//Anim ID: 34 - which is a_fighter
		//	File:c:\games\uw1\crit\CR32PAGE.N00, Palette = 1
		CreateAnimationUW("98_combat_idle", "CR32PAGE_N00_1_0000" , "CR32PAGE_N00_1_0001" , "CR32PAGE_N00_1_0000" , "CR32PAGE_N00_1_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("98_attack_bash", "CR32PAGE_N00_1_0000" , "CR32PAGE_N00_1_0001" , "CR32PAGE_N00_1_0002" , "CR32PAGE_N00_1_0001" , "CR32PAGE_N00_1_0000" , "" , "" , "" ,5);
		CreateAnimationUW("98_attack_slash", "CR32PAGE_N00_1_0000" , "CR32PAGE_N00_1_0003" , "CR32PAGE_N00_1_0004" , "CR32PAGE_N00_1_0005" , "CR32PAGE_N00_1_0000" , "" , "" , "" ,5);
		CreateAnimationUW("98_attack_thrust", "CR32PAGE_N00_1_0000" , "CR32PAGE_N00_1_0001" , "CR32PAGE_N00_1_0004" , "CR32PAGE_N00_1_0006" , "CR32PAGE_N00_1_0001" , "" , "" , "" ,5);
		CreateAnimationUW("98_walking_towards", "CR32PAGE_N00_1_0007" , "CR32PAGE_N00_1_0008" , "CR32PAGE_N00_1_0009" , "CR32PAGE_N00_1_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("98_death", "CR32PAGE_N00_1_0000" , "CR32PAGE_N00_1_0000" , "CR32PAGE_N00_1_0011" , "CR32PAGE_N00_1_0012" , "" , "" , "" , "" ,4);
		CreateAnimationUW("98_begin_combat", "CR32PAGE_N00_1_0013" , "CR32PAGE_N00_1_0014" , "CR32PAGE_N00_1_0000" , "CR32PAGE_N00_1_0000" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR32PAGE.N01, Palette = 1
		CreateAnimationUW("98_idle_rear", "CR32PAGE_N01_1_0000" , "CR32PAGE_N01_1_0001" , "CR32PAGE_N01_1_0002" , "CR32PAGE_N01_1_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("98_idle_rear_right", "CR32PAGE_N01_1_0003" , "CR32PAGE_N01_1_0004" , "CR32PAGE_N01_1_0005" , "CR32PAGE_N01_1_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("98_idle_right", "CR32PAGE_N01_1_0006" , "CR32PAGE_N01_1_0007" , "CR32PAGE_N01_1_0008" , "CR32PAGE_N01_1_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("98_idle_front_right", "CR32PAGE_N01_1_0009" , "CR32PAGE_N01_1_0010" , "CR32PAGE_N01_1_0011" , "CR32PAGE_N01_1_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("98_idle_front", "CR32PAGE_N01_1_0012" , "CR32PAGE_N01_1_0013" , "CR32PAGE_N01_1_0014" , "CR32PAGE_N01_1_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("98_idle_front_left", "CR32PAGE_N01_1_0015" , "CR32PAGE_N01_1_0016" , "CR32PAGE_N01_1_0017" , "CR32PAGE_N01_1_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("98_idle_left", "CR32PAGE_N01_1_0018" , "CR32PAGE_N01_1_0019" , "CR32PAGE_N01_1_0020" , "CR32PAGE_N01_1_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("98_idle_rear_left", "CR32PAGE_N01_1_0021" , "CR32PAGE_N01_1_0022" , "CR32PAGE_N01_1_0023" , "CR32PAGE_N01_1_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("98_walking_rear", "CR32PAGE_N01_1_0001" , "CR32PAGE_N01_1_0024" , "CR32PAGE_N01_1_0025" , "CR32PAGE_N01_1_0026" , "" , "" , "" , "" ,4);
		CreateAnimationUW("98_walking_rear_right", "CR32PAGE_N01_1_0027" , "CR32PAGE_N01_1_0028" , "CR32PAGE_N01_1_0004" , "CR32PAGE_N01_1_0029" , "" , "" , "" , "" ,4);
		CreateAnimationUW("98_walking_right", "CR32PAGE_N01_1_0030" , "CR32PAGE_N01_1_0031" , "CR32PAGE_N01_1_0032" , "CR32PAGE_N01_1_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("98_walking_front_right", "CR32PAGE_N01_1_0033" , "CR32PAGE_N01_1_0010" , "CR32PAGE_N01_1_0034" , "CR32PAGE_N01_1_0035" , "" , "" , "" , "" ,4);
		CreateAnimationUW("98_walking_front", "CR32PAGE_N01_1_0036" , "CR32PAGE_N01_1_0037" , "CR32PAGE_N01_1_0038" , "CR32PAGE_N01_1_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("98_walking_front_left", "CR32PAGE_N01_1_0039" , "CR32PAGE_N01_1_0016" , "CR32PAGE_N01_1_0040" , "CR32PAGE_N01_1_0041" , "" , "" , "" , "" ,4);
		CreateAnimationUW("98_walking_left", "CR32PAGE_N01_1_0042" , "CR32PAGE_N01_1_0043" , "CR32PAGE_N01_1_0044" , "CR32PAGE_N01_1_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("98_walking_rear_left", "CR32PAGE_N01_1_0045" , "CR32PAGE_N01_1_0046" , "CR32PAGE_N01_1_0022" , "CR32PAGE_N01_1_0047" , "" , "" , "" , "" ,4);
		//Anim ID: 35 - which is a_ghoul
		//	File:c:\games\uw1\crit\CR13PAGE.N00, Palette = 0
		CreateAnimationUW("99_combat_idle", "CR13PAGE_N00_0_0000" , "CR13PAGE_N00_0_0001" , "CR13PAGE_N00_0_0002" , "CR13PAGE_N00_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("99_attack_bash", "CR13PAGE_N00_0_0003" , "CR13PAGE_N00_0_0004" , "CR13PAGE_N00_0_0005" , "CR13PAGE_N00_0_0006" , "CR13PAGE_N00_0_0003" , "" , "" , "" ,5);
		CreateAnimationUW("99_attack_slash", "CR13PAGE_N00_0_0007" , "CR13PAGE_N00_0_0008" , "CR13PAGE_N00_0_0009" , "CR13PAGE_N00_0_0010" , "CR13PAGE_N00_0_0007" , "" , "" , "" ,5);
		CreateAnimationUW("99_attack_thrust", "CR13PAGE_N00_0_0011" , "CR13PAGE_N00_0_0012" , "CR13PAGE_N00_0_0013" , "CR13PAGE_N00_0_0014" , "CR13PAGE_N00_0_0011" , "" , "" , "" ,5);
		CreateAnimationUW("99_walking_towards", "CR13PAGE_N00_0_0015" , "CR13PAGE_N00_0_0000" , "CR13PAGE_N00_0_0016" , "CR13PAGE_N00_0_0017" , "" , "" , "" , "" ,4);
		CreateAnimationUW("99_death", "CR13PAGE_N00_0_0018" , "CR13PAGE_N00_0_0019" , "CR13PAGE_N00_0_0020" , "CR13PAGE_N00_0_0021" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR13PAGE.N01, Palette = 0
		CreateAnimationUW("99_idle_rear", "CR13PAGE_N01_0_0000" , "CR13PAGE_N01_0_0001" , "CR13PAGE_N01_0_0002" , "CR13PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("99_idle_rear_right", "CR13PAGE_N01_0_0003" , "CR13PAGE_N01_0_0004" , "CR13PAGE_N01_0_0005" , "CR13PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("99_idle_right", "CR13PAGE_N01_0_0006" , "CR13PAGE_N01_0_0007" , "CR13PAGE_N01_0_0008" , "CR13PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("99_idle_front_right", "CR13PAGE_N01_0_0009" , "CR13PAGE_N01_0_0010" , "CR13PAGE_N01_0_0011" , "CR13PAGE_N01_0_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("99_idle_front", "CR13PAGE_N01_0_0012" , "CR13PAGE_N01_0_0013" , "CR13PAGE_N01_0_0014" , "CR13PAGE_N01_0_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("99_idle_front_left", "CR13PAGE_N01_0_0015" , "CR13PAGE_N01_0_0016" , "CR13PAGE_N01_0_0017" , "CR13PAGE_N01_0_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("99_idle_left", "CR13PAGE_N01_0_0018" , "CR13PAGE_N01_0_0019" , "CR13PAGE_N01_0_0020" , "CR13PAGE_N01_0_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("99_idle_rear_left", "CR13PAGE_N01_0_0021" , "CR13PAGE_N01_0_0022" , "CR13PAGE_N01_0_0023" , "CR13PAGE_N01_0_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("99_walking_rear", "CR13PAGE_N01_0_0024" , "CR13PAGE_N01_0_0001" , "CR13PAGE_N01_0_0025" , "CR13PAGE_N01_0_0026" , "" , "" , "" , "" ,4);
		CreateAnimationUW("99_walking_rear_right", "CR13PAGE_N01_0_0027" , "CR13PAGE_N01_0_0004" , "CR13PAGE_N01_0_0028" , "CR13PAGE_N01_0_0029" , "" , "" , "" , "" ,4);
		CreateAnimationUW("99_walking_right", "CR13PAGE_N01_0_0030" , "CR13PAGE_N01_0_0007" , "CR13PAGE_N01_0_0031" , "CR13PAGE_N01_0_0032" , "" , "" , "" , "" ,4);
		CreateAnimationUW("99_walking_front_right", "CR13PAGE_N01_0_0033" , "CR13PAGE_N01_0_0010" , "CR13PAGE_N01_0_0034" , "CR13PAGE_N01_0_0035" , "" , "" , "" , "" ,4);
		CreateAnimationUW("99_walking_front", "CR13PAGE_N01_0_0036" , "CR13PAGE_N01_0_0013" , "CR13PAGE_N01_0_0037" , "CR13PAGE_N01_0_0038" , "" , "" , "" , "" ,4);
		CreateAnimationUW("99_walking_front_left", "CR13PAGE_N01_0_0039" , "CR13PAGE_N01_0_0016" , "CR13PAGE_N01_0_0040" , "CR13PAGE_N01_0_0041" , "" , "" , "" , "" ,4);
		CreateAnimationUW("99_walking_left", "CR13PAGE_N01_0_0042" , "CR13PAGE_N01_0_0019" , "CR13PAGE_N01_0_0043" , "CR13PAGE_N01_0_0044" , "" , "" , "" , "" ,4);
		CreateAnimationUW("99_walking_rear_left", "CR13PAGE_N01_0_0045" , "CR13PAGE_N01_0_0022" , "CR13PAGE_N01_0_0046" , "CR13PAGE_N01_0_0047" , "" , "" , "" , "" ,4);
		//Anim ID: 36 - which is a_ghost
		//	File:c:\games\uw1\crit\CR15PAGE.N00, Palette = 1
		CreateAnimationUW("100_combat_idle", "CR15PAGE_N00_1_0000" , "CR15PAGE_N00_1_0001" , "CR15PAGE_N00_1_0002" , "CR15PAGE_N00_1_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("100_attack_bash", "CR15PAGE_N00_1_0004" , "CR15PAGE_N00_1_0005" , "CR15PAGE_N00_1_0006" , "CR15PAGE_N00_1_0007" , "CR15PAGE_N00_1_0002" , "" , "" , "" ,5);
		CreateAnimationUW("100_attack_slash", "CR15PAGE_N00_1_0004" , "CR15PAGE_N00_1_0005" , "CR15PAGE_N00_1_0006" , "CR15PAGE_N00_1_0007" , "CR15PAGE_N00_1_0002" , "" , "" , "" ,5);
		CreateAnimationUW("100_attack_thrust", "CR15PAGE_N00_1_0004" , "CR15PAGE_N00_1_0005" , "CR15PAGE_N00_1_0006" , "CR15PAGE_N00_1_0007" , "CR15PAGE_N00_1_0002" , "" , "" , "" ,5);
		CreateAnimationUW("100_walking_towards", "CR15PAGE_N00_1_0000" , "CR15PAGE_N00_1_0001" , "CR15PAGE_N00_1_0002" , "CR15PAGE_N00_1_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("100_death", "CR15PAGE_N00_1_0008" , "CR15PAGE_N00_1_0009" , "CR15PAGE_N00_1_0010" , "CR15PAGE_N00_1_0011" , "" , "" , "" , "" ,4);
		CreateAnimationUW("100_begin_combat", "CR15PAGE_N00_1_0004" , "CR15PAGE_N00_1_0005" , "CR15PAGE_N00_1_0006" , "CR15PAGE_N00_1_0007" , "CR15PAGE_N00_1_0004" , "" , "" , "" ,5);
		//	File:c:\games\uw1\crit\CR15PAGE.N01, Palette = 1
		CreateAnimationUW("100_idle_rear", "CR15PAGE_N01_1_0000" , "CR15PAGE_N01_1_0001" , "CR15PAGE_N01_1_0002" , "CR15PAGE_N01_1_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("100_idle_rear_right", "CR15PAGE_N01_1_0003" , "CR15PAGE_N01_1_0004" , "CR15PAGE_N01_1_0005" , "CR15PAGE_N01_1_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("100_idle_right", "CR15PAGE_N01_1_0006" , "CR15PAGE_N01_1_0007" , "CR15PAGE_N01_1_0008" , "CR15PAGE_N01_1_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("100_idle_front_right", "CR15PAGE_N01_1_0009" , "CR15PAGE_N01_1_0010" , "CR15PAGE_N01_1_0011" , "CR15PAGE_N01_1_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("100_idle_front", "CR15PAGE_N01_1_0012" , "CR15PAGE_N01_1_0013" , "CR15PAGE_N01_1_0014" , "CR15PAGE_N01_1_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("100_idle_front_left", "CR15PAGE_N01_1_0015" , "CR15PAGE_N01_1_0016" , "CR15PAGE_N01_1_0017" , "CR15PAGE_N01_1_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("100_idle_left", "CR15PAGE_N01_1_0018" , "CR15PAGE_N01_1_0019" , "CR15PAGE_N01_1_0020" , "CR15PAGE_N01_1_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("100_idle_rear_left", "CR15PAGE_N01_1_0021" , "CR15PAGE_N01_1_0022" , "CR15PAGE_N01_1_0023" , "CR15PAGE_N01_1_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("100_walking_rear", "CR15PAGE_N01_1_0024" , "CR15PAGE_N01_1_0000" , "CR15PAGE_N01_1_0001" , "CR15PAGE_N01_1_0002" , "CR15PAGE_N01_1_0001" , "CR15PAGE_N01_1_0000" , "" , "" ,6);
		CreateAnimationUW("100_walking_rear_right", "CR15PAGE_N01_1_0003" , "CR15PAGE_N01_1_0004" , "CR15PAGE_N01_1_0005" , "CR15PAGE_N01_1_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("100_walking_right", "CR15PAGE_N01_1_0006" , "CR15PAGE_N01_1_0007" , "CR15PAGE_N01_1_0008" , "CR15PAGE_N01_1_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("100_walking_front_right", "CR15PAGE_N01_1_0009" , "CR15PAGE_N01_1_0010" , "CR15PAGE_N01_1_0011" , "CR15PAGE_N01_1_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("100_walking_front", "CR15PAGE_N01_1_0012" , "CR15PAGE_N01_1_0013" , "CR15PAGE_N01_1_0014" , "CR15PAGE_N01_1_0025" , "CR15PAGE_N01_1_0014" , "CR15PAGE_N01_1_0013" , "" , "" ,6);
		CreateAnimationUW("100_walking_front_left", "CR15PAGE_N01_1_0015" , "CR15PAGE_N01_1_0016" , "CR15PAGE_N01_1_0017" , "CR15PAGE_N01_1_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("100_walking_left", "CR15PAGE_N01_1_0018" , "CR15PAGE_N01_1_0019" , "CR15PAGE_N01_1_0020" , "CR15PAGE_N01_1_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("100_walking_rear_left", "CR15PAGE_N01_1_0021" , "CR15PAGE_N01_1_0022" , "CR15PAGE_N01_1_0023" , "CR15PAGE_N01_1_0022" , "" , "" , "" , "" ,4);
		//Anim ID: 37 - which is a_ghost
		//	File:c:\games\uw1\crit\CR15PAGE.N00, Palette = 2
		CreateAnimationUW("101_combat_idle", "CR15PAGE_N00_2_0000" , "CR15PAGE_N00_2_0001" , "CR15PAGE_N00_2_0002" , "CR15PAGE_N00_2_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("101_attack_bash", "CR15PAGE_N00_2_0004" , "CR15PAGE_N00_2_0005" , "CR15PAGE_N00_2_0006" , "CR15PAGE_N00_2_0007" , "CR15PAGE_N00_2_0002" , "" , "" , "" ,5);
		CreateAnimationUW("101_attack_slash", "CR15PAGE_N00_2_0004" , "CR15PAGE_N00_2_0005" , "CR15PAGE_N00_2_0006" , "CR15PAGE_N00_2_0007" , "CR15PAGE_N00_2_0002" , "" , "" , "" ,5);
		CreateAnimationUW("101_attack_thrust", "CR15PAGE_N00_2_0004" , "CR15PAGE_N00_2_0005" , "CR15PAGE_N00_2_0006" , "CR15PAGE_N00_2_0007" , "CR15PAGE_N00_2_0002" , "" , "" , "" ,5);
		CreateAnimationUW("101_walking_towards", "CR15PAGE_N00_2_0000" , "CR15PAGE_N00_2_0001" , "CR15PAGE_N00_2_0002" , "CR15PAGE_N00_2_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("101_death", "CR15PAGE_N00_2_0008" , "CR15PAGE_N00_2_0009" , "CR15PAGE_N00_2_0010" , "CR15PAGE_N00_2_0011" , "" , "" , "" , "" ,4);
		CreateAnimationUW("101_begin_combat", "CR15PAGE_N00_2_0004" , "CR15PAGE_N00_2_0005" , "CR15PAGE_N00_2_0006" , "CR15PAGE_N00_2_0007" , "CR15PAGE_N00_2_0004" , "" , "" , "" ,5);
		//	File:c:\games\uw1\crit\CR15PAGE.N01, Palette = 2
		CreateAnimationUW("101_idle_rear", "CR15PAGE_N01_2_0000" , "CR15PAGE_N01_2_0001" , "CR15PAGE_N01_2_0002" , "CR15PAGE_N01_2_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("101_idle_rear_right", "CR15PAGE_N01_2_0003" , "CR15PAGE_N01_2_0004" , "CR15PAGE_N01_2_0005" , "CR15PAGE_N01_2_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("101_idle_right", "CR15PAGE_N01_2_0006" , "CR15PAGE_N01_2_0007" , "CR15PAGE_N01_2_0008" , "CR15PAGE_N01_2_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("101_idle_front_right", "CR15PAGE_N01_2_0009" , "CR15PAGE_N01_2_0010" , "CR15PAGE_N01_2_0011" , "CR15PAGE_N01_2_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("101_idle_front", "CR15PAGE_N01_2_0012" , "CR15PAGE_N01_2_0013" , "CR15PAGE_N01_2_0014" , "CR15PAGE_N01_2_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("101_idle_front_left", "CR15PAGE_N01_2_0015" , "CR15PAGE_N01_2_0016" , "CR15PAGE_N01_2_0017" , "CR15PAGE_N01_2_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("101_idle_left", "CR15PAGE_N01_2_0018" , "CR15PAGE_N01_2_0019" , "CR15PAGE_N01_2_0020" , "CR15PAGE_N01_2_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("101_idle_rear_left", "CR15PAGE_N01_2_0021" , "CR15PAGE_N01_2_0022" , "CR15PAGE_N01_2_0023" , "CR15PAGE_N01_2_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("101_walking_rear", "CR15PAGE_N01_2_0024" , "CR15PAGE_N01_2_0000" , "CR15PAGE_N01_2_0001" , "CR15PAGE_N01_2_0002" , "CR15PAGE_N01_2_0001" , "CR15PAGE_N01_2_0000" , "" , "" ,6);
		CreateAnimationUW("101_walking_rear_right", "CR15PAGE_N01_2_0003" , "CR15PAGE_N01_2_0004" , "CR15PAGE_N01_2_0005" , "CR15PAGE_N01_2_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("101_walking_right", "CR15PAGE_N01_2_0006" , "CR15PAGE_N01_2_0007" , "CR15PAGE_N01_2_0008" , "CR15PAGE_N01_2_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("101_walking_front_right", "CR15PAGE_N01_2_0009" , "CR15PAGE_N01_2_0010" , "CR15PAGE_N01_2_0011" , "CR15PAGE_N01_2_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("101_walking_front", "CR15PAGE_N01_2_0012" , "CR15PAGE_N01_2_0013" , "CR15PAGE_N01_2_0014" , "CR15PAGE_N01_2_0025" , "CR15PAGE_N01_2_0014" , "CR15PAGE_N01_2_0013" , "" , "" ,6);
		CreateAnimationUW("101_walking_front_left", "CR15PAGE_N01_2_0015" , "CR15PAGE_N01_2_0016" , "CR15PAGE_N01_2_0017" , "CR15PAGE_N01_2_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("101_walking_left", "CR15PAGE_N01_2_0018" , "CR15PAGE_N01_2_0019" , "CR15PAGE_N01_2_0020" , "CR15PAGE_N01_2_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("101_walking_rear_left", "CR15PAGE_N01_2_0021" , "CR15PAGE_N01_2_0022" , "CR15PAGE_N01_2_0023" , "CR15PAGE_N01_2_0022" , "" , "" , "" , "" ,4);
		//Anim ID: 38 - which is a_gazer
		//	File:c:\games\uw1\crit\CR06PAGE.N00, Palette = 0
		CreateAnimationUW("102_combat_idle", "CR06PAGE_N00_0_0000" , "CR06PAGE_N00_0_0001" , "CR06PAGE_N00_0_0002" , "CR06PAGE_N00_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("102_attack_bash", "CR06PAGE_N00_0_0003" , "CR06PAGE_N00_0_0004" , "CR06PAGE_N00_0_0005" , "CR06PAGE_N00_0_0006" , "CR06PAGE_N00_0_0007" , "" , "" , "" ,5);
		CreateAnimationUW("102_attack_slash", "CR06PAGE_N00_0_0008" , "CR06PAGE_N00_0_0009" , "CR06PAGE_N00_0_0009" , "CR06PAGE_N00_0_0009" , "CR06PAGE_N00_0_0008" , "" , "" , "" ,5);
		CreateAnimationUW("102_attack_thrust", "CR06PAGE_N00_0_0010" , "CR06PAGE_N00_0_0011" , "CR06PAGE_N00_0_0012" , "CR06PAGE_N00_0_0013" , "CR06PAGE_N00_0_0014" , "" , "" , "" ,5);
		CreateAnimationUW("102_walking_towards", "CR06PAGE_N00_0_0015" , "CR06PAGE_N00_0_0000" , "CR06PAGE_N00_0_0016" , "CR06PAGE_N00_0_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("102_death", "CR06PAGE_N00_0_0017" , "CR06PAGE_N00_0_0018" , "CR06PAGE_N00_0_0019" , "CR06PAGE_N00_0_0020" , "" , "" , "" , "" ,4);
		CreateAnimationUW("102_begin_combat", "CR06PAGE_N00_0_0008" , "CR06PAGE_N00_0_0001" , "CR06PAGE_N00_0_0002" , "CR06PAGE_N00_0_0001" , "CR06PAGE_N00_0_0000" , "" , "" , "" ,5);
		//	File:c:\games\uw1\crit\CR06PAGE.N01, Palette = 0
		CreateAnimationUW("102_idle_rear", "CR06PAGE_N01_0_0000" , "CR06PAGE_N01_0_0001" , "CR06PAGE_N01_0_0002" , "CR06PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("102_idle_rear_right", "CR06PAGE_N01_0_0003" , "CR06PAGE_N01_0_0004" , "CR06PAGE_N01_0_0005" , "CR06PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("102_idle_right", "CR06PAGE_N01_0_0006" , "CR06PAGE_N01_0_0007" , "CR06PAGE_N01_0_0008" , "CR06PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("102_idle_front_right", "CR06PAGE_N01_0_0009" , "CR06PAGE_N01_0_0010" , "CR06PAGE_N01_0_0011" , "CR06PAGE_N01_0_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("102_idle_front", "CR06PAGE_N01_0_0012" , "CR06PAGE_N01_0_0013" , "CR06PAGE_N01_0_0014" , "CR06PAGE_N01_0_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("102_idle_front_left", "CR06PAGE_N01_0_0015" , "CR06PAGE_N01_0_0016" , "CR06PAGE_N01_0_0017" , "CR06PAGE_N01_0_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("102_idle_left", "CR06PAGE_N01_0_0018" , "CR06PAGE_N01_0_0019" , "CR06PAGE_N01_0_0020" , "CR06PAGE_N01_0_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("102_idle_rear_left", "CR06PAGE_N01_0_0021" , "CR06PAGE_N01_0_0022" , "CR06PAGE_N01_0_0023" , "CR06PAGE_N01_0_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("102_walking_rear", "CR06PAGE_N01_0_0000" , "CR06PAGE_N01_0_0001" , "CR06PAGE_N01_0_0002" , "CR06PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("102_walking_rear_right", "CR06PAGE_N01_0_0003" , "CR06PAGE_N01_0_0004" , "CR06PAGE_N01_0_0005" , "CR06PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("102_walking_right", "CR06PAGE_N01_0_0006" , "CR06PAGE_N01_0_0007" , "CR06PAGE_N01_0_0008" , "CR06PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("102_walking_front_right", "CR06PAGE_N01_0_0009" , "CR06PAGE_N01_0_0010" , "CR06PAGE_N01_0_0011" , "CR06PAGE_N01_0_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("102_walking_front", "CR06PAGE_N01_0_0012" , "CR06PAGE_N01_0_0013" , "CR06PAGE_N01_0_0014" , "CR06PAGE_N01_0_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("102_walking_front_left", "CR06PAGE_N01_0_0015" , "CR06PAGE_N01_0_0016" , "CR06PAGE_N01_0_0017" , "CR06PAGE_N01_0_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("102_walking_left", "CR06PAGE_N01_0_0018" , "CR06PAGE_N01_0_0019" , "CR06PAGE_N01_0_0020" , "CR06PAGE_N01_0_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("102_walking_rear_left", "CR06PAGE_N01_0_0021" , "CR06PAGE_N01_0_0022" , "CR06PAGE_N01_0_0023" , "CR06PAGE_N01_0_0022" , "" , "" , "" , "" ,4);
		//Anim ID: 39 - which is a_mage
		//	File:c:\games\uw1\crit\CR04PAGE.N00, Palette = 0
		CreateAnimationUW("103_combat_idle", "CR04PAGE_N00_0_0000" , "CR04PAGE_N00_0_0000" , "CR04PAGE_N00_0_0000" , "CR04PAGE_N00_0_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("103_attack_bash", "CR04PAGE_N00_0_0000" , "CR04PAGE_N00_0_0001" , "CR04PAGE_N00_0_0002" , "CR04PAGE_N00_0_0003" , "CR04PAGE_N00_0_0002" , "" , "" , "" ,5);
		CreateAnimationUW("103_attack_slash", "CR04PAGE_N00_0_0004" , "CR04PAGE_N00_0_0005" , "CR04PAGE_N00_0_0006" , "CR04PAGE_N00_0_0007" , "CR04PAGE_N00_0_0004" , "" , "" , "" ,5);
		CreateAnimationUW("103_attack_thrust", "CR04PAGE_N00_0_0008" , "CR04PAGE_N00_0_0009" , "CR04PAGE_N00_0_0010" , "CR04PAGE_N00_0_0011" , "CR04PAGE_N00_0_0008" , "" , "" , "" ,5);
		CreateAnimationUW("103_walking_towards", "CR04PAGE_N00_0_0012" , "CR04PAGE_N00_0_0013" , "CR04PAGE_N00_0_0014" , "CR04PAGE_N00_0_0015" , "" , "" , "" , "" ,4);
		CreateAnimationUW("103_death", "CR04PAGE_N00_0_0016" , "CR04PAGE_N00_0_0017" , "CR04PAGE_N00_0_0018" , "CR04PAGE_N00_0_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("103_begin_combat", "CR04PAGE_N00_0_0000" , "CR04PAGE_N00_0_0001" , "CR04PAGE_N00_0_0002" , "CR04PAGE_N00_0_0003" , "CR04PAGE_N00_0_0002" , "" , "" , "" ,5);
		//	File:c:\games\uw1\crit\CR04PAGE.N01, Palette = 0
		CreateAnimationUW("103_idle_rear", "CR04PAGE_N01_0_0000" , "CR04PAGE_N01_0_0001" , "CR04PAGE_N01_0_0002" , "CR04PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("103_idle_rear_right", "CR04PAGE_N01_0_0003" , "CR04PAGE_N01_0_0004" , "CR04PAGE_N01_0_0005" , "CR04PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("103_idle_right", "CR04PAGE_N01_0_0006" , "CR04PAGE_N01_0_0007" , "CR04PAGE_N01_0_0008" , "CR04PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("103_idle_front_right", "CR04PAGE_N01_0_0009" , "CR04PAGE_N01_0_0010" , "CR04PAGE_N01_0_0011" , "CR04PAGE_N01_0_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("103_idle_front", "CR04PAGE_N01_0_0012" , "CR04PAGE_N01_0_0013" , "CR04PAGE_N01_0_0014" , "CR04PAGE_N01_0_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("103_idle_front_left", "CR04PAGE_N01_0_0015" , "CR04PAGE_N01_0_0016" , "CR04PAGE_N01_0_0017" , "CR04PAGE_N01_0_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("103_idle_left", "CR04PAGE_N01_0_0018" , "CR04PAGE_N01_0_0019" , "CR04PAGE_N01_0_0020" , "CR04PAGE_N01_0_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("103_idle_rear_left", "CR04PAGE_N01_0_0021" , "CR04PAGE_N01_0_0022" , "CR04PAGE_N01_0_0023" , "CR04PAGE_N01_0_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("103_walking_rear", "CR04PAGE_N01_0_0024" , "CR04PAGE_N01_0_0025" , "CR04PAGE_N01_0_0026" , "CR04PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("103_walking_rear_right", "CR04PAGE_N01_0_0027" , "CR04PAGE_N01_0_0028" , "CR04PAGE_N01_0_0029" , "CR04PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("103_walking_right", "CR04PAGE_N01_0_0030" , "CR04PAGE_N01_0_0031" , "CR04PAGE_N01_0_0007" , "CR04PAGE_N01_0_0032" , "" , "" , "" , "" ,4);
		CreateAnimationUW("103_walking_front_right", "CR04PAGE_N01_0_0010" , "CR04PAGE_N01_0_0033" , "CR04PAGE_N01_0_0034" , "CR04PAGE_N01_0_0035" , "" , "" , "" , "" ,4);
		CreateAnimationUW("103_walking_front", "CR04PAGE_N01_0_0036" , "CR04PAGE_N01_0_0037" , "CR04PAGE_N01_0_0038" , "CR04PAGE_N01_0_0039" , "" , "" , "" , "" ,4);
		CreateAnimationUW("103_walking_front_left", "CR04PAGE_N01_0_0016" , "CR04PAGE_N01_0_0040" , "CR04PAGE_N01_0_0041" , "CR04PAGE_N01_0_0042" , "" , "" , "" , "" ,4);
		CreateAnimationUW("103_walking_left", "CR04PAGE_N01_0_0043" , "CR04PAGE_N01_0_0044" , "CR04PAGE_N01_0_0019" , "CR04PAGE_N01_0_0045" , "" , "" , "" , "" ,4);
		CreateAnimationUW("103_walking_rear_left", "CR04PAGE_N01_0_0046" , "CR04PAGE_N01_0_0047" , "CR04PAGE_N01_0_0048" , "CR04PAGE_N01_0_0022" , "" , "" , "" , "" ,4);
		//Anim ID: 40 - which is a_fighter
		//	File:c:\games\uw1\crit\CR32PAGE.N00, Palette = 2
		CreateAnimationUW("104_combat_idle", "CR32PAGE_N00_2_0000" , "CR32PAGE_N00_2_0001" , "CR32PAGE_N00_2_0000" , "CR32PAGE_N00_2_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("104_attack_bash", "CR32PAGE_N00_2_0000" , "CR32PAGE_N00_2_0001" , "CR32PAGE_N00_2_0002" , "CR32PAGE_N00_2_0001" , "CR32PAGE_N00_2_0000" , "" , "" , "" ,5);
		CreateAnimationUW("104_attack_slash", "CR32PAGE_N00_2_0000" , "CR32PAGE_N00_2_0003" , "CR32PAGE_N00_2_0004" , "CR32PAGE_N00_2_0005" , "CR32PAGE_N00_2_0000" , "" , "" , "" ,5);
		CreateAnimationUW("104_attack_thrust", "CR32PAGE_N00_2_0000" , "CR32PAGE_N00_2_0001" , "CR32PAGE_N00_2_0004" , "CR32PAGE_N00_2_0006" , "CR32PAGE_N00_2_0001" , "" , "" , "" ,5);
		CreateAnimationUW("104_walking_towards", "CR32PAGE_N00_2_0007" , "CR32PAGE_N00_2_0008" , "CR32PAGE_N00_2_0009" , "CR32PAGE_N00_2_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("104_death", "CR32PAGE_N00_2_0000" , "CR32PAGE_N00_2_0000" , "CR32PAGE_N00_2_0011" , "CR32PAGE_N00_2_0012" , "" , "" , "" , "" ,4);
		CreateAnimationUW("104_begin_combat", "CR32PAGE_N00_2_0013" , "CR32PAGE_N00_2_0014" , "CR32PAGE_N00_2_0000" , "CR32PAGE_N00_2_0000" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR32PAGE.N01, Palette = 2
		CreateAnimationUW("104_idle_rear", "CR32PAGE_N01_2_0000" , "CR32PAGE_N01_2_0001" , "CR32PAGE_N01_2_0002" , "CR32PAGE_N01_2_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("104_idle_rear_right", "CR32PAGE_N01_2_0003" , "CR32PAGE_N01_2_0004" , "CR32PAGE_N01_2_0005" , "CR32PAGE_N01_2_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("104_idle_right", "CR32PAGE_N01_2_0006" , "CR32PAGE_N01_2_0007" , "CR32PAGE_N01_2_0008" , "CR32PAGE_N01_2_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("104_idle_front_right", "CR32PAGE_N01_2_0009" , "CR32PAGE_N01_2_0010" , "CR32PAGE_N01_2_0011" , "CR32PAGE_N01_2_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("104_idle_front", "CR32PAGE_N01_2_0012" , "CR32PAGE_N01_2_0013" , "CR32PAGE_N01_2_0014" , "CR32PAGE_N01_2_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("104_idle_front_left", "CR32PAGE_N01_2_0015" , "CR32PAGE_N01_2_0016" , "CR32PAGE_N01_2_0017" , "CR32PAGE_N01_2_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("104_idle_left", "CR32PAGE_N01_2_0018" , "CR32PAGE_N01_2_0019" , "CR32PAGE_N01_2_0020" , "CR32PAGE_N01_2_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("104_idle_rear_left", "CR32PAGE_N01_2_0021" , "CR32PAGE_N01_2_0022" , "CR32PAGE_N01_2_0023" , "CR32PAGE_N01_2_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("104_walking_rear", "CR32PAGE_N01_2_0001" , "CR32PAGE_N01_2_0024" , "CR32PAGE_N01_2_0025" , "CR32PAGE_N01_2_0026" , "" , "" , "" , "" ,4);
		CreateAnimationUW("104_walking_rear_right", "CR32PAGE_N01_2_0027" , "CR32PAGE_N01_2_0028" , "CR32PAGE_N01_2_0004" , "CR32PAGE_N01_2_0029" , "" , "" , "" , "" ,4);
		CreateAnimationUW("104_walking_right", "CR32PAGE_N01_2_0030" , "CR32PAGE_N01_2_0031" , "CR32PAGE_N01_2_0032" , "CR32PAGE_N01_2_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("104_walking_front_right", "CR32PAGE_N01_2_0033" , "CR32PAGE_N01_2_0010" , "CR32PAGE_N01_2_0034" , "CR32PAGE_N01_2_0035" , "" , "" , "" , "" ,4);
		CreateAnimationUW("104_walking_front", "CR32PAGE_N01_2_0036" , "CR32PAGE_N01_2_0037" , "CR32PAGE_N01_2_0038" , "CR32PAGE_N01_2_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("104_walking_front_left", "CR32PAGE_N01_2_0039" , "CR32PAGE_N01_2_0016" , "CR32PAGE_N01_2_0040" , "CR32PAGE_N01_2_0041" , "" , "" , "" , "" ,4);
		CreateAnimationUW("104_walking_left", "CR32PAGE_N01_2_0042" , "CR32PAGE_N01_2_0043" , "CR32PAGE_N01_2_0044" , "CR32PAGE_N01_2_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("104_walking_rear_left", "CR32PAGE_N01_2_0045" , "CR32PAGE_N01_2_0046" , "CR32PAGE_N01_2_0022" , "CR32PAGE_N01_2_0047" , "" , "" , "" , "" ,4);
		//Anim ID: 41 - which is a_dark_ghoul
		//	File:c:\games\uw1\crit\CR13PAGE.N00, Palette = 1
		CreateAnimationUW("105_combat_idle", "CR13PAGE_N00_1_0000" , "CR13PAGE_N00_1_0001" , "CR13PAGE_N00_1_0002" , "CR13PAGE_N00_1_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("105_attack_bash", "CR13PAGE_N00_1_0003" , "CR13PAGE_N00_1_0004" , "CR13PAGE_N00_1_0005" , "CR13PAGE_N00_1_0006" , "CR13PAGE_N00_1_0003" , "" , "" , "" ,5);
		CreateAnimationUW("105_attack_slash", "CR13PAGE_N00_1_0007" , "CR13PAGE_N00_1_0008" , "CR13PAGE_N00_1_0009" , "CR13PAGE_N00_1_0010" , "CR13PAGE_N00_1_0007" , "" , "" , "" ,5);
		CreateAnimationUW("105_attack_thrust", "CR13PAGE_N00_1_0011" , "CR13PAGE_N00_1_0012" , "CR13PAGE_N00_1_0013" , "CR13PAGE_N00_1_0014" , "CR13PAGE_N00_1_0011" , "" , "" , "" ,5);
		CreateAnimationUW("105_walking_towards", "CR13PAGE_N00_1_0015" , "CR13PAGE_N00_1_0000" , "CR13PAGE_N00_1_0016" , "CR13PAGE_N00_1_0017" , "" , "" , "" , "" ,4);
		CreateAnimationUW("105_death", "CR13PAGE_N00_1_0018" , "CR13PAGE_N00_1_0019" , "CR13PAGE_N00_1_0020" , "CR13PAGE_N00_1_0021" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR13PAGE.N01, Palette = 1
		CreateAnimationUW("105_idle_rear", "CR13PAGE_N01_1_0000" , "CR13PAGE_N01_1_0001" , "CR13PAGE_N01_1_0002" , "CR13PAGE_N01_1_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("105_idle_rear_right", "CR13PAGE_N01_1_0003" , "CR13PAGE_N01_1_0004" , "CR13PAGE_N01_1_0005" , "CR13PAGE_N01_1_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("105_idle_right", "CR13PAGE_N01_1_0006" , "CR13PAGE_N01_1_0007" , "CR13PAGE_N01_1_0008" , "CR13PAGE_N01_1_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("105_idle_front_right", "CR13PAGE_N01_1_0009" , "CR13PAGE_N01_1_0010" , "CR13PAGE_N01_1_0011" , "CR13PAGE_N01_1_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("105_idle_front", "CR13PAGE_N01_1_0012" , "CR13PAGE_N01_1_0013" , "CR13PAGE_N01_1_0014" , "CR13PAGE_N01_1_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("105_idle_front_left", "CR13PAGE_N01_1_0015" , "CR13PAGE_N01_1_0016" , "CR13PAGE_N01_1_0017" , "CR13PAGE_N01_1_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("105_idle_left", "CR13PAGE_N01_1_0018" , "CR13PAGE_N01_1_0019" , "CR13PAGE_N01_1_0020" , "CR13PAGE_N01_1_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("105_idle_rear_left", "CR13PAGE_N01_1_0021" , "CR13PAGE_N01_1_0022" , "CR13PAGE_N01_1_0023" , "CR13PAGE_N01_1_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("105_walking_rear", "CR13PAGE_N01_1_0024" , "CR13PAGE_N01_1_0001" , "CR13PAGE_N01_1_0025" , "CR13PAGE_N01_1_0026" , "" , "" , "" , "" ,4);
		CreateAnimationUW("105_walking_rear_right", "CR13PAGE_N01_1_0027" , "CR13PAGE_N01_1_0004" , "CR13PAGE_N01_1_0028" , "CR13PAGE_N01_1_0029" , "" , "" , "" , "" ,4);
		CreateAnimationUW("105_walking_right", "CR13PAGE_N01_1_0030" , "CR13PAGE_N01_1_0007" , "CR13PAGE_N01_1_0031" , "CR13PAGE_N01_1_0032" , "" , "" , "" , "" ,4);
		CreateAnimationUW("105_walking_front_right", "CR13PAGE_N01_1_0033" , "CR13PAGE_N01_1_0010" , "CR13PAGE_N01_1_0034" , "CR13PAGE_N01_1_0035" , "" , "" , "" , "" ,4);
		CreateAnimationUW("105_walking_front", "CR13PAGE_N01_1_0036" , "CR13PAGE_N01_1_0013" , "CR13PAGE_N01_1_0037" , "CR13PAGE_N01_1_0038" , "" , "" , "" , "" ,4);
		CreateAnimationUW("105_walking_front_left", "CR13PAGE_N01_1_0039" , "CR13PAGE_N01_1_0016" , "CR13PAGE_N01_1_0040" , "CR13PAGE_N01_1_0041" , "" , "" , "" , "" ,4);
		CreateAnimationUW("105_walking_left", "CR13PAGE_N01_1_0042" , "CR13PAGE_N01_1_0019" , "CR13PAGE_N01_1_0043" , "CR13PAGE_N01_1_0044" , "" , "" , "" , "" ,4);
		CreateAnimationUW("105_walking_rear_left", "CR13PAGE_N01_1_0045" , "CR13PAGE_N01_1_0022" , "CR13PAGE_N01_1_0046" , "CR13PAGE_N01_1_0047" , "" , "" , "" , "" ,4);
		//Anim ID: 42 - which is a_mage
		//	File:c:\games\uw1\crit\CR25PAGE.N00, Palette = 0
		CreateAnimationUW("106_combat_idle", "CR25PAGE_N00_0_0000" , "CR25PAGE_N00_0_0000" , "CR25PAGE_N00_0_0000" , "CR25PAGE_N00_0_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("106_attack_bash", "CR25PAGE_N00_0_0001" , "CR25PAGE_N00_0_0000" , "CR25PAGE_N00_0_0002" , "CR25PAGE_N00_0_0003" , "CR25PAGE_N00_0_0002" , "" , "" , "" ,5);
		CreateAnimationUW("106_attack_slash", "CR25PAGE_N00_0_0004" , "CR25PAGE_N00_0_0000" , "CR25PAGE_N00_0_0002" , "CR25PAGE_N00_0_0003" , "CR25PAGE_N00_0_0002" , "" , "" , "" ,5);
		CreateAnimationUW("106_attack_thrust", "CR25PAGE_N00_0_0000" , "CR25PAGE_N00_0_0002" , "CR25PAGE_N00_0_0003" , "CR25PAGE_N00_0_0002" , "CR25PAGE_N00_0_0002" , "" , "" , "" ,5);
		CreateAnimationUW("106_walking_towards", "CR25PAGE_N00_0_0005" , "CR25PAGE_N00_0_0006" , "CR25PAGE_N00_0_0007" , "CR25PAGE_N00_0_0008" , "" , "" , "" , "" ,4);
		CreateAnimationUW("106_death", "CR25PAGE_N00_0_0009" , "CR25PAGE_N00_0_0010" , "CR25PAGE_N00_0_0011" , "CR25PAGE_N00_0_0012" , "" , "" , "" , "" ,4);
		CreateAnimationUW("106_begin_combat", "CR25PAGE_N00_0_0001" , "CR25PAGE_N00_0_0000" , "CR25PAGE_N00_0_0013" , "CR25PAGE_N00_0_0013" , "CR25PAGE_N00_0_0000" , "" , "" , "" ,5);
		//	File:c:\games\uw1\crit\CR25PAGE.N01, Palette = 0
		CreateAnimationUW("106_idle_rear", "CR25PAGE_N01_0_0000" , "CR25PAGE_N01_0_0001" , "CR25PAGE_N01_0_0002" , "CR25PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("106_idle_rear_right", "CR25PAGE_N01_0_0003" , "CR25PAGE_N01_0_0004" , "CR25PAGE_N01_0_0005" , "CR25PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("106_idle_right", "CR25PAGE_N01_0_0006" , "CR25PAGE_N01_0_0007" , "CR25PAGE_N01_0_0008" , "CR25PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("106_idle_front_right", "CR25PAGE_N01_0_0009" , "CR25PAGE_N01_0_0010" , "CR25PAGE_N01_0_0011" , "CR25PAGE_N01_0_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("106_idle_front", "CR25PAGE_N01_0_0012" , "CR25PAGE_N01_0_0013" , "CR25PAGE_N01_0_0014" , "CR25PAGE_N01_0_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("106_idle_front_left", "CR25PAGE_N01_0_0015" , "CR25PAGE_N01_0_0016" , "CR25PAGE_N01_0_0017" , "CR25PAGE_N01_0_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("106_idle_left", "CR25PAGE_N01_0_0018" , "CR25PAGE_N01_0_0019" , "CR25PAGE_N01_0_0020" , "CR25PAGE_N01_0_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("106_idle_rear_left", "CR25PAGE_N01_0_0021" , "CR25PAGE_N01_0_0022" , "CR25PAGE_N01_0_0023" , "CR25PAGE_N01_0_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("106_walking_rear", "CR25PAGE_N01_0_0024" , "CR25PAGE_N01_0_0025" , "CR25PAGE_N01_0_0026" , "CR25PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("106_walking_rear_right", "CR25PAGE_N01_0_0027" , "CR25PAGE_N01_0_0004" , "CR25PAGE_N01_0_0028" , "CR25PAGE_N01_0_0029" , "" , "" , "" , "" ,4);
		CreateAnimationUW("106_walking_right", "CR25PAGE_N01_0_0030" , "CR25PAGE_N01_0_0031" , "CR25PAGE_N01_0_0007" , "CR25PAGE_N01_0_0032" , "" , "" , "" , "" ,4);
		CreateAnimationUW("106_walking_front_right", "CR25PAGE_N01_0_0033" , "CR25PAGE_N01_0_0034" , "CR25PAGE_N01_0_0010" , "CR25PAGE_N01_0_0035" , "" , "" , "" , "" ,4);
		CreateAnimationUW("106_walking_front", "CR25PAGE_N01_0_0036" , "CR25PAGE_N01_0_0037" , "CR25PAGE_N01_0_0038" , "CR25PAGE_N01_0_0039" , "" , "" , "" , "" ,4);
		CreateAnimationUW("106_walking_front_left", "CR25PAGE_N01_0_0040" , "CR25PAGE_N01_0_0041" , "CR25PAGE_N01_0_0016" , "CR25PAGE_N01_0_0042" , "" , "" , "" , "" ,4);
		CreateAnimationUW("106_walking_left", "CR25PAGE_N01_0_0019" , "CR25PAGE_N01_0_0043" , "CR25PAGE_N01_0_0044" , "CR25PAGE_N01_0_0045" , "" , "" , "" , "" ,4);
		CreateAnimationUW("106_walking_rear_left", "CR25PAGE_N01_0_0046" , "CR25PAGE_N01_0_0047" , "CR25PAGE_N01_0_0048" , "CR25PAGE_N01_0_0022" , "" , "" , "" , "" ,4);
		//Anim ID: 43 - which is a_mage
		//	File:c:\games\uw1\crit\CR10PAGE.N00, Palette = 0
		CreateAnimationUW("107_combat_idle", "CR10PAGE_N00_0_0000" , "CR10PAGE_N00_0_0000" , "CR10PAGE_N00_0_0000" , "CR10PAGE_N00_0_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("107_attack_bash", "CR10PAGE_N00_0_0000" , "CR10PAGE_N00_0_0001" , "CR10PAGE_N00_0_0002" , "CR10PAGE_N00_0_0003" , "CR10PAGE_N00_0_0002" , "" , "" , "" ,5);
		CreateAnimationUW("107_attack_slash", "CR10PAGE_N00_0_0000" , "CR10PAGE_N00_0_0001" , "CR10PAGE_N00_0_0002" , "CR10PAGE_N00_0_0003" , "CR10PAGE_N00_0_0002" , "" , "" , "" ,5);
		CreateAnimationUW("107_attack_thrust", "CR10PAGE_N00_0_0000" , "CR10PAGE_N00_0_0001" , "CR10PAGE_N00_0_0002" , "CR10PAGE_N00_0_0003" , "CR10PAGE_N00_0_0002" , "" , "" , "" ,5);
		CreateAnimationUW("107_walking_towards", "CR10PAGE_N00_0_0004" , "CR10PAGE_N00_0_0005" , "CR10PAGE_N00_0_0006" , "CR10PAGE_N00_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("107_death", "CR10PAGE_N00_0_0008" , "CR10PAGE_N00_0_0009" , "CR10PAGE_N00_0_0010" , "CR10PAGE_N00_0_0011" , "" , "" , "" , "" ,4);
		CreateAnimationUW("107_begin_combat", "CR10PAGE_N00_0_0000" , "CR10PAGE_N00_0_0001" , "CR10PAGE_N00_0_0002" , "CR10PAGE_N00_0_0003" , "CR10PAGE_N00_0_0002" , "" , "" , "" ,5);
		//	File:c:\games\uw1\crit\CR10PAGE.N01, Palette = 0
		CreateAnimationUW("107_idle_rear", "CR10PAGE_N01_0_0000" , "CR10PAGE_N01_0_0001" , "CR10PAGE_N01_0_0002" , "CR10PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("107_idle_rear_right", "CR10PAGE_N01_0_0003" , "CR10PAGE_N01_0_0004" , "CR10PAGE_N01_0_0005" , "CR10PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("107_idle_right", "CR10PAGE_N01_0_0006" , "CR10PAGE_N01_0_0007" , "CR10PAGE_N01_0_0008" , "CR10PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("107_idle_front_right", "CR10PAGE_N01_0_0009" , "CR10PAGE_N01_0_0010" , "CR10PAGE_N01_0_0011" , "CR10PAGE_N01_0_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("107_idle_front", "CR10PAGE_N01_0_0012" , "CR10PAGE_N01_0_0013" , "CR10PAGE_N01_0_0014" , "CR10PAGE_N01_0_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("107_idle_front_left", "CR10PAGE_N01_0_0015" , "CR10PAGE_N01_0_0016" , "CR10PAGE_N01_0_0017" , "CR10PAGE_N01_0_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("107_idle_left", "CR10PAGE_N01_0_0018" , "CR10PAGE_N01_0_0019" , "CR10PAGE_N01_0_0020" , "CR10PAGE_N01_0_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("107_idle_rear_left", "CR10PAGE_N01_0_0021" , "CR10PAGE_N01_0_0022" , "CR10PAGE_N01_0_0023" , "CR10PAGE_N01_0_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("107_walking_rear", "CR10PAGE_N01_0_0024" , "CR10PAGE_N01_0_0025" , "CR10PAGE_N01_0_0026" , "CR10PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("107_walking_rear_right", "CR10PAGE_N01_0_0027" , "CR10PAGE_N01_0_0028" , "CR10PAGE_N01_0_0029" , "CR10PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("107_walking_right", "CR10PAGE_N01_0_0030" , "CR10PAGE_N01_0_0031" , "CR10PAGE_N01_0_0007" , "CR10PAGE_N01_0_0032" , "" , "" , "" , "" ,4);
		CreateAnimationUW("107_walking_front_right", "CR10PAGE_N01_0_0010" , "CR10PAGE_N01_0_0033" , "CR10PAGE_N01_0_0034" , "CR10PAGE_N01_0_0035" , "" , "" , "" , "" ,4);
		CreateAnimationUW("107_walking_front", "CR10PAGE_N01_0_0036" , "CR10PAGE_N01_0_0037" , "CR10PAGE_N01_0_0038" , "CR10PAGE_N01_0_0039" , "" , "" , "" , "" ,4);
		CreateAnimationUW("107_walking_front_left", "CR10PAGE_N01_0_0016" , "CR10PAGE_N01_0_0040" , "CR10PAGE_N01_0_0041" , "CR10PAGE_N01_0_0042" , "" , "" , "" , "" ,4);
		CreateAnimationUW("107_walking_left", "CR10PAGE_N01_0_0043" , "CR10PAGE_N01_0_0044" , "CR10PAGE_N01_0_0019" , "CR10PAGE_N01_0_0045" , "" , "" , "" , "" ,4);
		CreateAnimationUW("107_walking_rear_left", "CR10PAGE_N01_0_0046" , "CR10PAGE_N01_0_0047" , "CR10PAGE_N01_0_0048" , "CR10PAGE_N01_0_0022" , "" , "" , "" , "" ,4);
		//Anim ID: 44 - which is a_mage
		//	File:c:\games\uw1\crit\CR04PAGE.N00, Palette = 1
		CreateAnimationUW("108_combat_idle", "CR04PAGE_N00_1_0000" , "CR04PAGE_N00_1_0000" , "CR04PAGE_N00_1_0000" , "CR04PAGE_N00_1_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("108_attack_bash", "CR04PAGE_N00_1_0000" , "CR04PAGE_N00_1_0001" , "CR04PAGE_N00_1_0002" , "CR04PAGE_N00_1_0003" , "CR04PAGE_N00_1_0002" , "" , "" , "" ,5);
		CreateAnimationUW("108_attack_slash", "CR04PAGE_N00_1_0004" , "CR04PAGE_N00_1_0005" , "CR04PAGE_N00_1_0006" , "CR04PAGE_N00_1_0007" , "CR04PAGE_N00_1_0004" , "" , "" , "" ,5);
		CreateAnimationUW("108_attack_thrust", "CR04PAGE_N00_1_0008" , "CR04PAGE_N00_1_0009" , "CR04PAGE_N00_1_0010" , "CR04PAGE_N00_1_0011" , "CR04PAGE_N00_1_0008" , "" , "" , "" ,5);
		CreateAnimationUW("108_walking_towards", "CR04PAGE_N00_1_0012" , "CR04PAGE_N00_1_0013" , "CR04PAGE_N00_1_0014" , "CR04PAGE_N00_1_0015" , "" , "" , "" , "" ,4);
		CreateAnimationUW("108_death", "CR04PAGE_N00_1_0016" , "CR04PAGE_N00_1_0017" , "CR04PAGE_N00_1_0018" , "CR04PAGE_N00_1_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("108_begin_combat", "CR04PAGE_N00_1_0000" , "CR04PAGE_N00_1_0001" , "CR04PAGE_N00_1_0002" , "CR04PAGE_N00_1_0003" , "CR04PAGE_N00_1_0002" , "" , "" , "" ,5);
		//	File:c:\games\uw1\crit\CR04PAGE.N01, Palette = 1
		CreateAnimationUW("108_idle_rear", "CR04PAGE_N01_1_0000" , "CR04PAGE_N01_1_0001" , "CR04PAGE_N01_1_0002" , "CR04PAGE_N01_1_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("108_idle_rear_right", "CR04PAGE_N01_1_0003" , "CR04PAGE_N01_1_0004" , "CR04PAGE_N01_1_0005" , "CR04PAGE_N01_1_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("108_idle_right", "CR04PAGE_N01_1_0006" , "CR04PAGE_N01_1_0007" , "CR04PAGE_N01_1_0008" , "CR04PAGE_N01_1_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("108_idle_front_right", "CR04PAGE_N01_1_0009" , "CR04PAGE_N01_1_0010" , "CR04PAGE_N01_1_0011" , "CR04PAGE_N01_1_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("108_idle_front", "CR04PAGE_N01_1_0012" , "CR04PAGE_N01_1_0013" , "CR04PAGE_N01_1_0014" , "CR04PAGE_N01_1_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("108_idle_front_left", "CR04PAGE_N01_1_0015" , "CR04PAGE_N01_1_0016" , "CR04PAGE_N01_1_0017" , "CR04PAGE_N01_1_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("108_idle_left", "CR04PAGE_N01_1_0018" , "CR04PAGE_N01_1_0019" , "CR04PAGE_N01_1_0020" , "CR04PAGE_N01_1_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("108_idle_rear_left", "CR04PAGE_N01_1_0021" , "CR04PAGE_N01_1_0022" , "CR04PAGE_N01_1_0023" , "CR04PAGE_N01_1_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("108_walking_rear", "CR04PAGE_N01_1_0024" , "CR04PAGE_N01_1_0025" , "CR04PAGE_N01_1_0026" , "CR04PAGE_N01_1_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("108_walking_rear_right", "CR04PAGE_N01_1_0027" , "CR04PAGE_N01_1_0028" , "CR04PAGE_N01_1_0029" , "CR04PAGE_N01_1_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("108_walking_right", "CR04PAGE_N01_1_0030" , "CR04PAGE_N01_1_0031" , "CR04PAGE_N01_1_0007" , "CR04PAGE_N01_1_0032" , "" , "" , "" , "" ,4);
		CreateAnimationUW("108_walking_front_right", "CR04PAGE_N01_1_0010" , "CR04PAGE_N01_1_0033" , "CR04PAGE_N01_1_0034" , "CR04PAGE_N01_1_0035" , "" , "" , "" , "" ,4);
		CreateAnimationUW("108_walking_front", "CR04PAGE_N01_1_0036" , "CR04PAGE_N01_1_0037" , "CR04PAGE_N01_1_0038" , "CR04PAGE_N01_1_0039" , "" , "" , "" , "" ,4);
		CreateAnimationUW("108_walking_front_left", "CR04PAGE_N01_1_0016" , "CR04PAGE_N01_1_0040" , "CR04PAGE_N01_1_0041" , "CR04PAGE_N01_1_0042" , "" , "" , "" , "" ,4);
		CreateAnimationUW("108_walking_left", "CR04PAGE_N01_1_0043" , "CR04PAGE_N01_1_0044" , "CR04PAGE_N01_1_0019" , "CR04PAGE_N01_1_0045" , "" , "" , "" , "" ,4);
		CreateAnimationUW("108_walking_rear_left", "CR04PAGE_N01_1_0046" , "CR04PAGE_N01_1_0047" , "CR04PAGE_N01_1_0048" , "CR04PAGE_N01_1_0022" , "" , "" , "" , "" ,4);
		//Anim ID: 45 - which is a_mage
		//	File:c:\games\uw1\crit\CR04PAGE.N00, Palette = 2
		CreateAnimationUW("109_combat_idle", "CR04PAGE_N00_2_0000" , "CR04PAGE_N00_2_0000" , "CR04PAGE_N00_2_0000" , "CR04PAGE_N00_2_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("109_attack_bash", "CR04PAGE_N00_2_0000" , "CR04PAGE_N00_2_0001" , "CR04PAGE_N00_2_0002" , "CR04PAGE_N00_2_0003" , "CR04PAGE_N00_2_0002" , "" , "" , "" ,5);
		CreateAnimationUW("109_attack_slash", "CR04PAGE_N00_2_0004" , "CR04PAGE_N00_2_0005" , "CR04PAGE_N00_2_0006" , "CR04PAGE_N00_2_0007" , "CR04PAGE_N00_2_0004" , "" , "" , "" ,5);
		CreateAnimationUW("109_attack_thrust", "CR04PAGE_N00_2_0008" , "CR04PAGE_N00_2_0009" , "CR04PAGE_N00_2_0010" , "CR04PAGE_N00_2_0011" , "CR04PAGE_N00_2_0008" , "" , "" , "" ,5);
		CreateAnimationUW("109_walking_towards", "CR04PAGE_N00_2_0012" , "CR04PAGE_N00_2_0013" , "CR04PAGE_N00_2_0014" , "CR04PAGE_N00_2_0015" , "" , "" , "" , "" ,4);
		CreateAnimationUW("109_death", "CR04PAGE_N00_2_0016" , "CR04PAGE_N00_2_0017" , "CR04PAGE_N00_2_0018" , "CR04PAGE_N00_2_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("109_begin_combat", "CR04PAGE_N00_2_0000" , "CR04PAGE_N00_2_0001" , "CR04PAGE_N00_2_0002" , "CR04PAGE_N00_2_0003" , "CR04PAGE_N00_2_0002" , "" , "" , "" ,5);
		//	File:c:\games\uw1\crit\CR04PAGE.N01, Palette = 2
		CreateAnimationUW("109_idle_rear", "CR04PAGE_N01_2_0000" , "CR04PAGE_N01_2_0001" , "CR04PAGE_N01_2_0002" , "CR04PAGE_N01_2_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("109_idle_rear_right", "CR04PAGE_N01_2_0003" , "CR04PAGE_N01_2_0004" , "CR04PAGE_N01_2_0005" , "CR04PAGE_N01_2_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("109_idle_right", "CR04PAGE_N01_2_0006" , "CR04PAGE_N01_2_0007" , "CR04PAGE_N01_2_0008" , "CR04PAGE_N01_2_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("109_idle_front_right", "CR04PAGE_N01_2_0009" , "CR04PAGE_N01_2_0010" , "CR04PAGE_N01_2_0011" , "CR04PAGE_N01_2_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("109_idle_front", "CR04PAGE_N01_2_0012" , "CR04PAGE_N01_2_0013" , "CR04PAGE_N01_2_0014" , "CR04PAGE_N01_2_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("109_idle_front_left", "CR04PAGE_N01_2_0015" , "CR04PAGE_N01_2_0016" , "CR04PAGE_N01_2_0017" , "CR04PAGE_N01_2_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("109_idle_left", "CR04PAGE_N01_2_0018" , "CR04PAGE_N01_2_0019" , "CR04PAGE_N01_2_0020" , "CR04PAGE_N01_2_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("109_idle_rear_left", "CR04PAGE_N01_2_0021" , "CR04PAGE_N01_2_0022" , "CR04PAGE_N01_2_0023" , "CR04PAGE_N01_2_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("109_walking_rear", "CR04PAGE_N01_2_0024" , "CR04PAGE_N01_2_0025" , "CR04PAGE_N01_2_0026" , "CR04PAGE_N01_2_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("109_walking_rear_right", "CR04PAGE_N01_2_0027" , "CR04PAGE_N01_2_0028" , "CR04PAGE_N01_2_0029" , "CR04PAGE_N01_2_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("109_walking_right", "CR04PAGE_N01_2_0030" , "CR04PAGE_N01_2_0031" , "CR04PAGE_N01_2_0007" , "CR04PAGE_N01_2_0032" , "" , "" , "" , "" ,4);
		CreateAnimationUW("109_walking_front_right", "CR04PAGE_N01_2_0010" , "CR04PAGE_N01_2_0033" , "CR04PAGE_N01_2_0034" , "CR04PAGE_N01_2_0035" , "" , "" , "" , "" ,4);
		CreateAnimationUW("109_walking_front", "CR04PAGE_N01_2_0036" , "CR04PAGE_N01_2_0037" , "CR04PAGE_N01_2_0038" , "CR04PAGE_N01_2_0039" , "" , "" , "" , "" ,4);
		CreateAnimationUW("109_walking_front_left", "CR04PAGE_N01_2_0016" , "CR04PAGE_N01_2_0040" , "CR04PAGE_N01_2_0041" , "CR04PAGE_N01_2_0042" , "" , "" , "" , "" ,4);
		CreateAnimationUW("109_walking_left", "CR04PAGE_N01_2_0043" , "CR04PAGE_N01_2_0044" , "CR04PAGE_N01_2_0019" , "CR04PAGE_N01_2_0045" , "" , "" , "" , "" ,4);
		CreateAnimationUW("109_walking_rear_left", "CR04PAGE_N01_2_0046" , "CR04PAGE_N01_2_0047" , "CR04PAGE_N01_2_0048" , "CR04PAGE_N01_2_0022" , "" , "" , "" , "" ,4);
		//Anim ID: 46 - which is a_ghoul
		//	File:c:\games\uw1\crit\CR13PAGE.N00, Palette = 2
		CreateAnimationUW("110_combat_idle", "CR13PAGE_N00_2_0000" , "CR13PAGE_N00_2_0001" , "CR13PAGE_N00_2_0002" , "CR13PAGE_N00_2_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("110_attack_bash", "CR13PAGE_N00_2_0003" , "CR13PAGE_N00_2_0004" , "CR13PAGE_N00_2_0005" , "CR13PAGE_N00_2_0006" , "CR13PAGE_N00_2_0003" , "" , "" , "" ,5);
		CreateAnimationUW("110_attack_slash", "CR13PAGE_N00_2_0007" , "CR13PAGE_N00_2_0008" , "CR13PAGE_N00_2_0009" , "CR13PAGE_N00_2_0010" , "CR13PAGE_N00_2_0007" , "" , "" , "" ,5);
		CreateAnimationUW("110_attack_thrust", "CR13PAGE_N00_2_0011" , "CR13PAGE_N00_2_0012" , "CR13PAGE_N00_2_0013" , "CR13PAGE_N00_2_0014" , "CR13PAGE_N00_2_0011" , "" , "" , "" ,5);
		CreateAnimationUW("110_walking_towards", "CR13PAGE_N00_2_0015" , "CR13PAGE_N00_2_0000" , "CR13PAGE_N00_2_0016" , "CR13PAGE_N00_2_0017" , "" , "" , "" , "" ,4);
		CreateAnimationUW("110_death", "CR13PAGE_N00_2_0018" , "CR13PAGE_N00_2_0019" , "CR13PAGE_N00_2_0020" , "CR13PAGE_N00_2_0021" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR13PAGE.N01, Palette = 2
		CreateAnimationUW("110_idle_rear", "CR13PAGE_N01_2_0000" , "CR13PAGE_N01_2_0001" , "CR13PAGE_N01_2_0002" , "CR13PAGE_N01_2_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("110_idle_rear_right", "CR13PAGE_N01_2_0003" , "CR13PAGE_N01_2_0004" , "CR13PAGE_N01_2_0005" , "CR13PAGE_N01_2_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("110_idle_right", "CR13PAGE_N01_2_0006" , "CR13PAGE_N01_2_0007" , "CR13PAGE_N01_2_0008" , "CR13PAGE_N01_2_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("110_idle_front_right", "CR13PAGE_N01_2_0009" , "CR13PAGE_N01_2_0010" , "CR13PAGE_N01_2_0011" , "CR13PAGE_N01_2_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("110_idle_front", "CR13PAGE_N01_2_0012" , "CR13PAGE_N01_2_0013" , "CR13PAGE_N01_2_0014" , "CR13PAGE_N01_2_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("110_idle_front_left", "CR13PAGE_N01_2_0015" , "CR13PAGE_N01_2_0016" , "CR13PAGE_N01_2_0017" , "CR13PAGE_N01_2_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("110_idle_left", "CR13PAGE_N01_2_0018" , "CR13PAGE_N01_2_0019" , "CR13PAGE_N01_2_0020" , "CR13PAGE_N01_2_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("110_idle_rear_left", "CR13PAGE_N01_2_0021" , "CR13PAGE_N01_2_0022" , "CR13PAGE_N01_2_0023" , "CR13PAGE_N01_2_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("110_walking_rear", "CR13PAGE_N01_2_0024" , "CR13PAGE_N01_2_0001" , "CR13PAGE_N01_2_0025" , "CR13PAGE_N01_2_0026" , "" , "" , "" , "" ,4);
		CreateAnimationUW("110_walking_rear_right", "CR13PAGE_N01_2_0027" , "CR13PAGE_N01_2_0004" , "CR13PAGE_N01_2_0028" , "CR13PAGE_N01_2_0029" , "" , "" , "" , "" ,4);
		CreateAnimationUW("110_walking_right", "CR13PAGE_N01_2_0030" , "CR13PAGE_N01_2_0007" , "CR13PAGE_N01_2_0031" , "CR13PAGE_N01_2_0032" , "" , "" , "" , "" ,4);
		CreateAnimationUW("110_walking_front_right", "CR13PAGE_N01_2_0033" , "CR13PAGE_N01_2_0010" , "CR13PAGE_N01_2_0034" , "CR13PAGE_N01_2_0035" , "" , "" , "" , "" ,4);
		CreateAnimationUW("110_walking_front", "CR13PAGE_N01_2_0036" , "CR13PAGE_N01_2_0013" , "CR13PAGE_N01_2_0037" , "CR13PAGE_N01_2_0038" , "" , "" , "" , "" ,4);
		CreateAnimationUW("110_walking_front_left", "CR13PAGE_N01_2_0039" , "CR13PAGE_N01_2_0016" , "CR13PAGE_N01_2_0040" , "CR13PAGE_N01_2_0041" , "" , "" , "" , "" ,4);
		CreateAnimationUW("110_walking_left", "CR13PAGE_N01_2_0042" , "CR13PAGE_N01_2_0019" , "CR13PAGE_N01_2_0043" , "CR13PAGE_N01_2_0044" , "" , "" , "" , "" ,4);
		CreateAnimationUW("110_walking_rear_left", "CR13PAGE_N01_2_0045" , "CR13PAGE_N01_2_0022" , "CR13PAGE_N01_2_0046" , "CR13PAGE_N01_2_0047" , "" , "" , "" , "" ,4);
		//Anim ID: 47 - which is a_feral_troll
		//	File:c:\games\uw1\crit\CR07PAGE.N00, Palette = 2
		CreateAnimationUW("111_combat_idle", "CR07PAGE_N00_2_0000" , "CR07PAGE_N00_2_0001" , "CR07PAGE_N00_2_0002" , "CR07PAGE_N00_2_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("111_attack_bash", "CR07PAGE_N00_2_0000" , "CR07PAGE_N00_2_0002" , "CR07PAGE_N00_2_0004" , "CR07PAGE_N00_2_0005" , "CR07PAGE_N00_2_0002" , "" , "" , "" ,5);
		CreateAnimationUW("111_attack_slash", "CR07PAGE_N00_2_0002" , "CR07PAGE_N00_2_0000" , "CR07PAGE_N00_2_0006" , "CR07PAGE_N00_2_0007" , "CR07PAGE_N00_2_0002" , "" , "" , "" ,5);
		CreateAnimationUW("111_attack_thrust", "CR07PAGE_N00_2_0000" , "CR07PAGE_N00_2_0002" , "CR07PAGE_N00_2_0004" , "CR07PAGE_N00_2_0005" , "CR07PAGE_N00_2_0002" , "" , "" , "" ,5);
		CreateAnimationUW("111_walking_towards", "CR07PAGE_N00_2_0008" , "CR07PAGE_N00_2_0009" , "CR07PAGE_N00_2_0010" , "CR07PAGE_N00_2_0011" , "" , "" , "" , "" ,4);
		CreateAnimationUW("111_death", "CR07PAGE_N00_2_0000" , "CR07PAGE_N00_2_0012" , "CR07PAGE_N00_2_0013" , "CR07PAGE_N00_2_0014" , "" , "" , "" , "" ,4);
		CreateAnimationUW("111_begin_combat", "CR07PAGE_N00_2_0000" , "CR07PAGE_N00_2_0002" , "CR07PAGE_N00_2_0002" , "CR07PAGE_N00_2_0000" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR07PAGE.N01, Palette = 2
		CreateAnimationUW("111_idle_rear", "CR07PAGE_N01_2_0000" , "CR07PAGE_N01_2_0001" , "CR07PAGE_N01_2_0002" , "CR07PAGE_N01_2_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("111_idle_rear_right", "CR07PAGE_N01_2_0003" , "CR07PAGE_N01_2_0004" , "CR07PAGE_N01_2_0005" , "CR07PAGE_N01_2_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("111_idle_right", "CR07PAGE_N01_2_0006" , "CR07PAGE_N01_2_0007" , "CR07PAGE_N01_2_0008" , "CR07PAGE_N01_2_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("111_idle_front_right", "CR07PAGE_N01_2_0009" , "CR07PAGE_N01_2_0010" , "CR07PAGE_N01_2_0011" , "CR07PAGE_N01_2_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("111_idle_front", "CR07PAGE_N01_2_0012" , "CR07PAGE_N01_2_0013" , "CR07PAGE_N01_2_0014" , "CR07PAGE_N01_2_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("111_idle_front_left", "CR07PAGE_N01_2_0015" , "CR07PAGE_N01_2_0016" , "CR07PAGE_N01_2_0017" , "CR07PAGE_N01_2_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("111_idle_left", "CR07PAGE_N01_2_0018" , "CR07PAGE_N01_2_0019" , "CR07PAGE_N01_2_0020" , "CR07PAGE_N01_2_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("111_idle_rear_left", "CR07PAGE_N01_2_0021" , "CR07PAGE_N01_2_0022" , "CR07PAGE_N01_2_0023" , "CR07PAGE_N01_2_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("111_walking_rear", "CR07PAGE_N01_2_0024" , "CR07PAGE_N01_2_0025" , "CR07PAGE_N01_2_0001" , "CR07PAGE_N01_2_0026" , "" , "" , "" , "" ,4);
		CreateAnimationUW("111_walking_rear_right", "CR07PAGE_N01_2_0027" , "CR07PAGE_N01_2_0028" , "CR07PAGE_N01_2_0004" , "CR07PAGE_N01_2_0029" , "" , "" , "" , "" ,4);
		CreateAnimationUW("111_walking_right", "CR07PAGE_N01_2_0030" , "CR07PAGE_N01_2_0007" , "CR07PAGE_N01_2_0031" , "CR07PAGE_N01_2_0032" , "" , "" , "" , "" ,4);
		CreateAnimationUW("111_walking_front_right", "CR07PAGE_N01_2_0033" , "CR07PAGE_N01_2_0010" , "CR07PAGE_N01_2_0034" , "CR07PAGE_N01_2_0035" , "" , "" , "" , "" ,4);
		CreateAnimationUW("111_walking_front", "CR07PAGE_N01_2_0036" , "CR07PAGE_N01_2_0037" , "CR07PAGE_N01_2_0013" , "CR07PAGE_N01_2_0038" , "" , "" , "" , "" ,4);
		CreateAnimationUW("111_walking_front_left", "CR07PAGE_N01_2_0039" , "CR07PAGE_N01_2_0016" , "CR07PAGE_N01_2_0040" , "CR07PAGE_N01_2_0041" , "" , "" , "" , "" ,4);
		CreateAnimationUW("111_walking_left", "CR07PAGE_N01_2_0042" , "CR07PAGE_N01_2_0019" , "CR07PAGE_N01_2_0043" , "CR07PAGE_N01_2_0044" , "" , "" , "" , "" ,4);
		CreateAnimationUW("111_walking_rear_left", "CR07PAGE_N01_2_0045" , "CR07PAGE_N01_2_0046" , "CR07PAGE_N01_2_0022" , "CR07PAGE_N01_2_0047" , "" , "" , "" , "" ,4);
		//Anim ID: 48 - which is a_great_troll
		//	File:c:\games\uw1\crit\CR07PAGE.N00, Palette = 1
		CreateAnimationUW("112_combat_idle", "CR07PAGE_N00_1_0000" , "CR07PAGE_N00_1_0001" , "CR07PAGE_N00_1_0002" , "CR07PAGE_N00_1_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("112_attack_bash", "CR07PAGE_N00_1_0000" , "CR07PAGE_N00_1_0002" , "CR07PAGE_N00_1_0004" , "CR07PAGE_N00_1_0005" , "CR07PAGE_N00_1_0002" , "" , "" , "" ,5);
		CreateAnimationUW("112_attack_slash", "CR07PAGE_N00_1_0002" , "CR07PAGE_N00_1_0000" , "CR07PAGE_N00_1_0006" , "CR07PAGE_N00_1_0007" , "CR07PAGE_N00_1_0002" , "" , "" , "" ,5);
		CreateAnimationUW("112_attack_thrust", "CR07PAGE_N00_1_0000" , "CR07PAGE_N00_1_0002" , "CR07PAGE_N00_1_0004" , "CR07PAGE_N00_1_0005" , "CR07PAGE_N00_1_0002" , "" , "" , "" ,5);
		CreateAnimationUW("112_walking_towards", "CR07PAGE_N00_1_0008" , "CR07PAGE_N00_1_0009" , "CR07PAGE_N00_1_0010" , "CR07PAGE_N00_1_0011" , "" , "" , "" , "" ,4);
		CreateAnimationUW("112_death", "CR07PAGE_N00_1_0000" , "CR07PAGE_N00_1_0012" , "CR07PAGE_N00_1_0013" , "CR07PAGE_N00_1_0014" , "" , "" , "" , "" ,4);
		CreateAnimationUW("112_begin_combat", "CR07PAGE_N00_1_0000" , "CR07PAGE_N00_1_0002" , "CR07PAGE_N00_1_0002" , "CR07PAGE_N00_1_0000" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR07PAGE.N01, Palette = 1
		CreateAnimationUW("112_idle_rear", "CR07PAGE_N01_1_0000" , "CR07PAGE_N01_1_0001" , "CR07PAGE_N01_1_0002" , "CR07PAGE_N01_1_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("112_idle_rear_right", "CR07PAGE_N01_1_0003" , "CR07PAGE_N01_1_0004" , "CR07PAGE_N01_1_0005" , "CR07PAGE_N01_1_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("112_idle_right", "CR07PAGE_N01_1_0006" , "CR07PAGE_N01_1_0007" , "CR07PAGE_N01_1_0008" , "CR07PAGE_N01_1_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("112_idle_front_right", "CR07PAGE_N01_1_0009" , "CR07PAGE_N01_1_0010" , "CR07PAGE_N01_1_0011" , "CR07PAGE_N01_1_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("112_idle_front", "CR07PAGE_N01_1_0012" , "CR07PAGE_N01_1_0013" , "CR07PAGE_N01_1_0014" , "CR07PAGE_N01_1_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("112_idle_front_left", "CR07PAGE_N01_1_0015" , "CR07PAGE_N01_1_0016" , "CR07PAGE_N01_1_0017" , "CR07PAGE_N01_1_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("112_idle_left", "CR07PAGE_N01_1_0018" , "CR07PAGE_N01_1_0019" , "CR07PAGE_N01_1_0020" , "CR07PAGE_N01_1_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("112_idle_rear_left", "CR07PAGE_N01_1_0021" , "CR07PAGE_N01_1_0022" , "CR07PAGE_N01_1_0023" , "CR07PAGE_N01_1_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("112_walking_rear", "CR07PAGE_N01_1_0024" , "CR07PAGE_N01_1_0025" , "CR07PAGE_N01_1_0001" , "CR07PAGE_N01_1_0026" , "" , "" , "" , "" ,4);
		CreateAnimationUW("112_walking_rear_right", "CR07PAGE_N01_1_0027" , "CR07PAGE_N01_1_0028" , "CR07PAGE_N01_1_0004" , "CR07PAGE_N01_1_0029" , "" , "" , "" , "" ,4);
		CreateAnimationUW("112_walking_right", "CR07PAGE_N01_1_0030" , "CR07PAGE_N01_1_0007" , "CR07PAGE_N01_1_0031" , "CR07PAGE_N01_1_0032" , "" , "" , "" , "" ,4);
		CreateAnimationUW("112_walking_front_right", "CR07PAGE_N01_1_0033" , "CR07PAGE_N01_1_0010" , "CR07PAGE_N01_1_0034" , "CR07PAGE_N01_1_0035" , "" , "" , "" , "" ,4);
		CreateAnimationUW("112_walking_front", "CR07PAGE_N01_1_0036" , "CR07PAGE_N01_1_0037" , "CR07PAGE_N01_1_0013" , "CR07PAGE_N01_1_0038" , "" , "" , "" , "" ,4);
		CreateAnimationUW("112_walking_front_left", "CR07PAGE_N01_1_0039" , "CR07PAGE_N01_1_0016" , "CR07PAGE_N01_1_0040" , "CR07PAGE_N01_1_0041" , "" , "" , "" , "" ,4);
		CreateAnimationUW("112_walking_left", "CR07PAGE_N01_1_0042" , "CR07PAGE_N01_1_0019" , "CR07PAGE_N01_1_0043" , "CR07PAGE_N01_1_0044" , "" , "" , "" , "" ,4);
		CreateAnimationUW("112_walking_rear_left", "CR07PAGE_N01_1_0045" , "CR07PAGE_N01_1_0046" , "CR07PAGE_N01_1_0022" , "CR07PAGE_N01_1_0047" , "" , "" , "" , "" ,4);
		//Anim ID: 49 - which is a_dire_ghost
		//	File:c:\games\uw1\crit\CR15PAGE.N00, Palette = 3
		CreateAnimationUW("113_combat_idle", "CR15PAGE_N00_3_0000" , "CR15PAGE_N00_3_0001" , "CR15PAGE_N00_3_0002" , "CR15PAGE_N00_3_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("113_attack_bash", "CR15PAGE_N00_3_0004" , "CR15PAGE_N00_3_0005" , "CR15PAGE_N00_3_0006" , "CR15PAGE_N00_3_0007" , "CR15PAGE_N00_3_0002" , "" , "" , "" ,5);
		CreateAnimationUW("113_attack_slash", "CR15PAGE_N00_3_0004" , "CR15PAGE_N00_3_0005" , "CR15PAGE_N00_3_0006" , "CR15PAGE_N00_3_0007" , "CR15PAGE_N00_3_0002" , "" , "" , "" ,5);
		CreateAnimationUW("113_attack_thrust", "CR15PAGE_N00_3_0004" , "CR15PAGE_N00_3_0005" , "CR15PAGE_N00_3_0006" , "CR15PAGE_N00_3_0007" , "CR15PAGE_N00_3_0002" , "" , "" , "" ,5);
		CreateAnimationUW("113_walking_towards", "CR15PAGE_N00_3_0000" , "CR15PAGE_N00_3_0001" , "CR15PAGE_N00_3_0002" , "CR15PAGE_N00_3_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("113_death", "CR15PAGE_N00_3_0008" , "CR15PAGE_N00_3_0009" , "CR15PAGE_N00_3_0010" , "CR15PAGE_N00_3_0011" , "" , "" , "" , "" ,4);
		CreateAnimationUW("113_begin_combat", "CR15PAGE_N00_3_0004" , "CR15PAGE_N00_3_0005" , "CR15PAGE_N00_3_0006" , "CR15PAGE_N00_3_0007" , "CR15PAGE_N00_3_0004" , "" , "" , "" ,5);
		//	File:c:\games\uw1\crit\CR15PAGE.N01, Palette = 3
		CreateAnimationUW("113_idle_rear", "CR15PAGE_N01_3_0000" , "CR15PAGE_N01_3_0001" , "CR15PAGE_N01_3_0002" , "CR15PAGE_N01_3_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("113_idle_rear_right", "CR15PAGE_N01_3_0003" , "CR15PAGE_N01_3_0004" , "CR15PAGE_N01_3_0005" , "CR15PAGE_N01_3_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("113_idle_right", "CR15PAGE_N01_3_0006" , "CR15PAGE_N01_3_0007" , "CR15PAGE_N01_3_0008" , "CR15PAGE_N01_3_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("113_idle_front_right", "CR15PAGE_N01_3_0009" , "CR15PAGE_N01_3_0010" , "CR15PAGE_N01_3_0011" , "CR15PAGE_N01_3_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("113_idle_front", "CR15PAGE_N01_3_0012" , "CR15PAGE_N01_3_0013" , "CR15PAGE_N01_3_0014" , "CR15PAGE_N01_3_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("113_idle_front_left", "CR15PAGE_N01_3_0015" , "CR15PAGE_N01_3_0016" , "CR15PAGE_N01_3_0017" , "CR15PAGE_N01_3_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("113_idle_left", "CR15PAGE_N01_3_0018" , "CR15PAGE_N01_3_0019" , "CR15PAGE_N01_3_0020" , "CR15PAGE_N01_3_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("113_idle_rear_left", "CR15PAGE_N01_3_0021" , "CR15PAGE_N01_3_0022" , "CR15PAGE_N01_3_0023" , "CR15PAGE_N01_3_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("113_walking_rear", "CR15PAGE_N01_3_0024" , "CR15PAGE_N01_3_0000" , "CR15PAGE_N01_3_0001" , "CR15PAGE_N01_3_0002" , "CR15PAGE_N01_3_0001" , "CR15PAGE_N01_3_0000" , "" , "" ,6);
		CreateAnimationUW("113_walking_rear_right", "CR15PAGE_N01_3_0003" , "CR15PAGE_N01_3_0004" , "CR15PAGE_N01_3_0005" , "CR15PAGE_N01_3_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("113_walking_right", "CR15PAGE_N01_3_0006" , "CR15PAGE_N01_3_0007" , "CR15PAGE_N01_3_0008" , "CR15PAGE_N01_3_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("113_walking_front_right", "CR15PAGE_N01_3_0009" , "CR15PAGE_N01_3_0010" , "CR15PAGE_N01_3_0011" , "CR15PAGE_N01_3_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("113_walking_front", "CR15PAGE_N01_3_0012" , "CR15PAGE_N01_3_0013" , "CR15PAGE_N01_3_0014" , "CR15PAGE_N01_3_0025" , "CR15PAGE_N01_3_0014" , "CR15PAGE_N01_3_0013" , "" , "" ,6);
		CreateAnimationUW("113_walking_front_left", "CR15PAGE_N01_3_0015" , "CR15PAGE_N01_3_0016" , "CR15PAGE_N01_3_0017" , "CR15PAGE_N01_3_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("113_walking_left", "CR15PAGE_N01_3_0018" , "CR15PAGE_N01_3_0019" , "CR15PAGE_N01_3_0020" , "CR15PAGE_N01_3_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("113_walking_rear_left", "CR15PAGE_N01_3_0021" , "CR15PAGE_N01_3_0022" , "CR15PAGE_N01_3_0023" , "CR15PAGE_N01_3_0022" , "" , "" , "" , "" ,4);
		//Anim ID: 50 - which is an_earth_golem
		//	File:c:\games\uw1\crit\CR23PAGE.N00, Palette = 0
		CreateAnimationUW("114_combat_idle", "CR23PAGE_N00_0_0000" , "CR23PAGE_N00_0_0001" , "CR23PAGE_N00_0_0002" , "CR23PAGE_N00_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("114_attack_bash", "CR23PAGE_N00_0_0004" , "CR23PAGE_N00_0_0005" , "CR23PAGE_N00_0_0006" , "CR23PAGE_N00_0_0007" , "CR23PAGE_N00_0_0008" , "" , "" , "" ,5);
		CreateAnimationUW("114_attack_slash", "CR23PAGE_N00_0_0009" , "CR23PAGE_N00_0_0010" , "CR23PAGE_N00_0_0011" , "CR23PAGE_N00_0_0012" , "CR23PAGE_N00_0_0013" , "" , "" , "" ,5);
		CreateAnimationUW("114_attack_thrust", "CR23PAGE_N00_0_0004" , "CR23PAGE_N00_0_0005" , "CR23PAGE_N00_0_0006" , "CR23PAGE_N00_0_0007" , "CR23PAGE_N00_0_0008" , "" , "" , "" ,5);
		CreateAnimationUW("114_walking_towards", "CR23PAGE_N00_0_0014" , "CR23PAGE_N00_0_0002" , "CR23PAGE_N00_0_0015" , "CR23PAGE_N00_0_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("114_death", "CR23PAGE_N00_0_0016" , "CR23PAGE_N00_0_0017" , "CR23PAGE_N00_0_0018" , "CR23PAGE_N00_0_0019" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR23PAGE.N01, Palette = 0
		CreateAnimationUW("114_idle_rear", "CR23PAGE_N01_0_0000" , "CR23PAGE_N01_0_0000" , "CR23PAGE_N01_0_0000" , "CR23PAGE_N01_0_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("114_idle_rear_right", "CR23PAGE_N01_0_0001" , "CR23PAGE_N01_0_0001" , "CR23PAGE_N01_0_0001" , "CR23PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("114_idle_right", "CR23PAGE_N01_0_0002" , "CR23PAGE_N01_0_0002" , "CR23PAGE_N01_0_0002" , "CR23PAGE_N01_0_0002" , "" , "" , "" , "" ,4);
		CreateAnimationUW("114_idle_front_right", "CR23PAGE_N01_0_0003" , "CR23PAGE_N01_0_0003" , "CR23PAGE_N01_0_0003" , "CR23PAGE_N01_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("114_idle_front", "CR23PAGE_N01_0_0004" , "CR23PAGE_N01_0_0004" , "CR23PAGE_N01_0_0004" , "CR23PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("114_idle_front_left", "CR23PAGE_N01_0_0005" , "CR23PAGE_N01_0_0005" , "CR23PAGE_N01_0_0005" , "CR23PAGE_N01_0_0005" , "" , "" , "" , "" ,4);
		CreateAnimationUW("114_idle_left", "CR23PAGE_N01_0_0006" , "CR23PAGE_N01_0_0006" , "CR23PAGE_N01_0_0006" , "CR23PAGE_N01_0_0006" , "" , "" , "" , "" ,4);
		CreateAnimationUW("114_idle_rear_left", "CR23PAGE_N01_0_0007" , "CR23PAGE_N01_0_0007" , "CR23PAGE_N01_0_0007" , "CR23PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("114_walking_rear", "CR23PAGE_N01_0_0008" , "CR23PAGE_N01_0_0009" , "CR23PAGE_N01_0_0000" , "CR23PAGE_N01_0_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("114_walking_rear_right", "CR23PAGE_N01_0_0001" , "CR23PAGE_N01_0_0011" , "CR23PAGE_N01_0_0012" , "CR23PAGE_N01_0_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("114_walking_right", "CR23PAGE_N01_0_0014" , "CR23PAGE_N01_0_0015" , "CR23PAGE_N01_0_0016" , "CR23PAGE_N01_0_0002" , "" , "" , "" , "" ,4);
		CreateAnimationUW("114_walking_front_right", "CR23PAGE_N01_0_0003" , "CR23PAGE_N01_0_0017" , "CR23PAGE_N01_0_0018" , "CR23PAGE_N01_0_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("114_walking_front", "CR23PAGE_N01_0_0020" , "CR23PAGE_N01_0_0021" , "CR23PAGE_N01_0_0022" , "CR23PAGE_N01_0_0023" , "" , "" , "" , "" ,4);
		CreateAnimationUW("114_walking_front_left", "CR23PAGE_N01_0_0005" , "CR23PAGE_N01_0_0024" , "CR23PAGE_N01_0_0025" , "CR23PAGE_N01_0_0026" , "" , "" , "" , "" ,4);
		CreateAnimationUW("114_walking_left", "CR23PAGE_N01_0_0027" , "CR23PAGE_N01_0_0028" , "CR23PAGE_N01_0_0029" , "CR23PAGE_N01_0_0006" , "" , "" , "" , "" ,4);
		CreateAnimationUW("114_walking_rear_left", "CR23PAGE_N01_0_0007" , "CR23PAGE_N01_0_0030" , "CR23PAGE_N01_0_0031" , "CR23PAGE_N01_0_0032" , "" , "" , "" , "" ,4);
		//Anim ID: 51 - which is a_mage
		//	File:c:\games\uw1\crit\CR25PAGE.N00, Palette = 1
		CreateAnimationUW("115_combat_idle", "CR25PAGE_N00_1_0000" , "CR25PAGE_N00_1_0000" , "CR25PAGE_N00_1_0000" , "CR25PAGE_N00_1_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("115_attack_bash", "CR25PAGE_N00_1_0001" , "CR25PAGE_N00_1_0000" , "CR25PAGE_N00_1_0002" , "CR25PAGE_N00_1_0003" , "CR25PAGE_N00_1_0002" , "" , "" , "" ,5);
		CreateAnimationUW("115_attack_slash", "CR25PAGE_N00_1_0004" , "CR25PAGE_N00_1_0000" , "CR25PAGE_N00_1_0002" , "CR25PAGE_N00_1_0003" , "CR25PAGE_N00_1_0002" , "" , "" , "" ,5);
		CreateAnimationUW("115_attack_thrust", "CR25PAGE_N00_1_0000" , "CR25PAGE_N00_1_0002" , "CR25PAGE_N00_1_0003" , "CR25PAGE_N00_1_0002" , "CR25PAGE_N00_1_0002" , "" , "" , "" ,5);
		CreateAnimationUW("115_walking_towards", "CR25PAGE_N00_1_0005" , "CR25PAGE_N00_1_0006" , "CR25PAGE_N00_1_0007" , "CR25PAGE_N00_1_0008" , "" , "" , "" , "" ,4);
		CreateAnimationUW("115_death", "CR25PAGE_N00_1_0009" , "CR25PAGE_N00_1_0010" , "CR25PAGE_N00_1_0011" , "CR25PAGE_N00_1_0012" , "" , "" , "" , "" ,4);
		CreateAnimationUW("115_begin_combat", "CR25PAGE_N00_1_0001" , "CR25PAGE_N00_1_0000" , "CR25PAGE_N00_1_0013" , "CR25PAGE_N00_1_0013" , "CR25PAGE_N00_1_0000" , "" , "" , "" ,5);
		//	File:c:\games\uw1\crit\CR25PAGE.N01, Palette = 1
		CreateAnimationUW("115_idle_rear", "CR25PAGE_N01_1_0000" , "CR25PAGE_N01_1_0001" , "CR25PAGE_N01_1_0002" , "CR25PAGE_N01_1_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("115_idle_rear_right", "CR25PAGE_N01_1_0003" , "CR25PAGE_N01_1_0004" , "CR25PAGE_N01_1_0005" , "CR25PAGE_N01_1_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("115_idle_right", "CR25PAGE_N01_1_0006" , "CR25PAGE_N01_1_0007" , "CR25PAGE_N01_1_0008" , "CR25PAGE_N01_1_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("115_idle_front_right", "CR25PAGE_N01_1_0009" , "CR25PAGE_N01_1_0010" , "CR25PAGE_N01_1_0011" , "CR25PAGE_N01_1_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("115_idle_front", "CR25PAGE_N01_1_0012" , "CR25PAGE_N01_1_0013" , "CR25PAGE_N01_1_0014" , "CR25PAGE_N01_1_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("115_idle_front_left", "CR25PAGE_N01_1_0015" , "CR25PAGE_N01_1_0016" , "CR25PAGE_N01_1_0017" , "CR25PAGE_N01_1_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("115_idle_left", "CR25PAGE_N01_1_0018" , "CR25PAGE_N01_1_0019" , "CR25PAGE_N01_1_0020" , "CR25PAGE_N01_1_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("115_idle_rear_left", "CR25PAGE_N01_1_0021" , "CR25PAGE_N01_1_0022" , "CR25PAGE_N01_1_0023" , "CR25PAGE_N01_1_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("115_walking_rear", "CR25PAGE_N01_1_0024" , "CR25PAGE_N01_1_0025" , "CR25PAGE_N01_1_0026" , "CR25PAGE_N01_1_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("115_walking_rear_right", "CR25PAGE_N01_1_0027" , "CR25PAGE_N01_1_0004" , "CR25PAGE_N01_1_0028" , "CR25PAGE_N01_1_0029" , "" , "" , "" , "" ,4);
		CreateAnimationUW("115_walking_right", "CR25PAGE_N01_1_0030" , "CR25PAGE_N01_1_0031" , "CR25PAGE_N01_1_0007" , "CR25PAGE_N01_1_0032" , "" , "" , "" , "" ,4);
		CreateAnimationUW("115_walking_front_right", "CR25PAGE_N01_1_0033" , "CR25PAGE_N01_1_0034" , "CR25PAGE_N01_1_0010" , "CR25PAGE_N01_1_0035" , "" , "" , "" , "" ,4);
		CreateAnimationUW("115_walking_front", "CR25PAGE_N01_1_0036" , "CR25PAGE_N01_1_0037" , "CR25PAGE_N01_1_0038" , "CR25PAGE_N01_1_0039" , "" , "" , "" , "" ,4);
		CreateAnimationUW("115_walking_front_left", "CR25PAGE_N01_1_0040" , "CR25PAGE_N01_1_0041" , "CR25PAGE_N01_1_0016" , "CR25PAGE_N01_1_0042" , "" , "" , "" , "" ,4);
		CreateAnimationUW("115_walking_left", "CR25PAGE_N01_1_0019" , "CR25PAGE_N01_1_0043" , "CR25PAGE_N01_1_0044" , "CR25PAGE_N01_1_0045" , "" , "" , "" , "" ,4);
		CreateAnimationUW("115_walking_rear_left", "CR25PAGE_N01_1_0046" , "CR25PAGE_N01_1_0047" , "CR25PAGE_N01_1_0048" , "CR25PAGE_N01_1_0022" , "" , "" , "" , "" ,4);
		//Anim ID: 52 - which is a_deep_lurker
		//	File:c:\games\uw1\crit\CR31PAGE.N00, Palette = 1
		CreateAnimationUW("116_combat_idle", "CR31PAGE_N00_1_0000" , "CR31PAGE_N00_1_0001" , "CR31PAGE_N00_1_0002" , "CR31PAGE_N00_1_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("116_attack_bash", "CR31PAGE_N00_1_0004" , "CR31PAGE_N00_1_0005" , "CR31PAGE_N00_1_0006" , "CR31PAGE_N00_1_0007" , "CR31PAGE_N00_1_0008" , "" , "" , "" ,5);
		CreateAnimationUW("116_attack_slash", "CR31PAGE_N00_1_0009" , "CR31PAGE_N00_1_0010" , "CR31PAGE_N00_1_0011" , "CR31PAGE_N00_1_0012" , "CR31PAGE_N00_1_0013" , "" , "" , "" ,5);
		CreateAnimationUW("116_attack_thrust", "CR31PAGE_N00_1_0014" , "CR31PAGE_N00_1_0015" , "CR31PAGE_N00_1_0016" , "CR31PAGE_N00_1_0017" , "CR31PAGE_N00_1_0018" , "" , "" , "" ,5);
		CreateAnimationUW("116_walking_towards", "CR31PAGE_N00_1_0003" , "CR31PAGE_N00_1_0002" , "CR31PAGE_N00_1_0001" , "CR31PAGE_N00_1_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("116_death", "CR31PAGE_N00_1_0019" , "CR31PAGE_N00_1_0020" , "CR31PAGE_N00_1_0021" , "CR31PAGE_N00_1_0022" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR31PAGE.N01, Palette = 1
		CreateAnimationUW("116_idle_rear", "CR31PAGE_N01_1_0000" , "CR31PAGE_N01_1_0001" , "CR31PAGE_N01_1_0001" , "CR31PAGE_N01_1_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("116_idle_rear_right", "CR31PAGE_N01_1_0002" , "CR31PAGE_N01_1_0003" , "CR31PAGE_N01_1_0003" , "CR31PAGE_N01_1_0002" , "" , "" , "" , "" ,4);
		CreateAnimationUW("116_idle_right", "CR31PAGE_N01_1_0004" , "CR31PAGE_N01_1_0005" , "CR31PAGE_N01_1_0006" , "CR31PAGE_N01_1_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("116_idle_front_right", "CR31PAGE_N01_1_0008" , "CR31PAGE_N01_1_0009" , "CR31PAGE_N01_1_0010" , "CR31PAGE_N01_1_0011" , "" , "" , "" , "" ,4);
		CreateAnimationUW("116_idle_front", "CR31PAGE_N01_1_0012" , "CR31PAGE_N01_1_0013" , "CR31PAGE_N01_1_0014" , "CR31PAGE_N01_1_0015" , "" , "" , "" , "" ,4);
		CreateAnimationUW("116_idle_front_left", "CR31PAGE_N01_1_0016" , "CR31PAGE_N01_1_0017" , "CR31PAGE_N01_1_0018" , "CR31PAGE_N01_1_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("116_idle_left", "CR31PAGE_N01_1_0020" , "CR31PAGE_N01_1_0021" , "CR31PAGE_N01_1_0022" , "CR31PAGE_N01_1_0023" , "" , "" , "" , "" ,4);
		CreateAnimationUW("116_idle_rear_left", "CR31PAGE_N01_1_0024" , "CR31PAGE_N01_1_0025" , "CR31PAGE_N01_1_0025" , "CR31PAGE_N01_1_0024" , "" , "" , "" , "" ,4);
		CreateAnimationUW("116_walking_rear", "CR31PAGE_N01_1_0026" , "CR31PAGE_N01_1_0027" , "CR31PAGE_N01_1_0028" , "CR31PAGE_N01_1_0029" , "" , "" , "" , "" ,4);
		CreateAnimationUW("116_walking_rear_right", "CR31PAGE_N01_1_0030" , "CR31PAGE_N01_1_0031" , "CR31PAGE_N01_1_0032" , "CR31PAGE_N01_1_0033" , "" , "" , "" , "" ,4);
		CreateAnimationUW("116_walking_right", "CR31PAGE_N01_1_0034" , "CR31PAGE_N01_1_0035" , "CR31PAGE_N01_1_0036" , "CR31PAGE_N01_1_0037" , "" , "" , "" , "" ,4);
		CreateAnimationUW("116_walking_front_right", "CR31PAGE_N01_1_0038" , "CR31PAGE_N01_1_0039" , "CR31PAGE_N01_1_0040" , "CR31PAGE_N01_1_0041" , "" , "" , "" , "" ,4);
		CreateAnimationUW("116_walking_front", "CR31PAGE_N01_1_0042" , "CR31PAGE_N01_1_0043" , "CR31PAGE_N01_1_0044" , "CR31PAGE_N01_1_0045" , "" , "" , "" , "" ,4);
		CreateAnimationUW("116_walking_front_left", "CR31PAGE_N01_1_0046" , "CR31PAGE_N01_1_0047" , "CR31PAGE_N01_1_0048" , "CR31PAGE_N01_1_0049" , "" , "" , "" , "" ,4);
		CreateAnimationUW("116_walking_left", "CR31PAGE_N01_1_0050" , "CR31PAGE_N01_1_0051" , "CR31PAGE_N01_1_0052" , "CR31PAGE_N01_1_0053" , "" , "" , "" , "" ,4);
		CreateAnimationUW("116_walking_rear_left", "CR31PAGE_N01_1_0054" , "CR31PAGE_N01_1_0055" , "CR31PAGE_N01_1_0056" , "CR31PAGE_N01_1_0057" , "" , "" , "" , "" ,4);
		//Anim ID: 53 - which is a_shadow_beast
		//	File:c:\games\uw1\crit\CR34PAGE.N00, Palette = 0
		CreateAnimationUW("117_combat_idle", "CR34PAGE_N00_0_0000" , "CR34PAGE_N00_0_0000" , "CR34PAGE_N00_0_0000" , "CR34PAGE_N00_0_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("117_attack_bash", "CR34PAGE_N00_0_0000" , "CR34PAGE_N00_0_0001" , "CR34PAGE_N00_0_0002" , "CR34PAGE_N00_0_0003" , "CR34PAGE_N00_0_0004" , "" , "" , "" ,5);
		CreateAnimationUW("117_attack_slash", "CR34PAGE_N00_0_0000" , "CR34PAGE_N00_0_0005" , "CR34PAGE_N00_0_0006" , "CR34PAGE_N00_0_0007" , "CR34PAGE_N00_0_0008" , "" , "" , "" ,5);
		CreateAnimationUW("117_attack_thrust", "CR34PAGE_N00_0_0000" , "CR34PAGE_N00_0_0001" , "CR34PAGE_N00_0_0002" , "CR34PAGE_N00_0_0003" , "CR34PAGE_N00_0_0004" , "" , "" , "" ,5);
		CreateAnimationUW("117_death", "CR34PAGE_N00_0_0009" , "CR34PAGE_N00_0_0010" , "CR34PAGE_N00_0_0011" , "CR34PAGE_N00_0_0012" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR34PAGE.N01, Palette = 0
		CreateAnimationUW("117_idle_rear", "CR34PAGE_N01_0_0000" , "CR34PAGE_N01_0_0000" , "CR34PAGE_N01_0_0000" , "CR34PAGE_N01_0_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("117_idle_rear_right", "CR34PAGE_N01_0_0000" , "CR34PAGE_N01_0_0000" , "CR34PAGE_N01_0_0000" , "CR34PAGE_N01_0_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("117_idle_right", "CR34PAGE_N01_0_0000" , "CR34PAGE_N01_0_0000" , "CR34PAGE_N01_0_0000" , "CR34PAGE_N01_0_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("117_idle_front_right", "CR34PAGE_N01_0_0000" , "CR34PAGE_N01_0_0000" , "CR34PAGE_N01_0_0000" , "CR34PAGE_N01_0_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("117_idle_front", "CR34PAGE_N01_0_0000" , "CR34PAGE_N01_0_0000" , "CR34PAGE_N01_0_0000" , "CR34PAGE_N01_0_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("117_idle_front_left", "CR34PAGE_N01_0_0000" , "CR34PAGE_N01_0_0000" , "CR34PAGE_N01_0_0000" , "CR34PAGE_N01_0_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("117_idle_left", "CR34PAGE_N01_0_0000" , "CR34PAGE_N01_0_0000" , "CR34PAGE_N01_0_0000" , "CR34PAGE_N01_0_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("117_idle_rear_left", "CR34PAGE_N01_0_0000" , "CR34PAGE_N01_0_0000" , "CR34PAGE_N01_0_0000" , "CR34PAGE_N01_0_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("117_walking_rear", "CR34PAGE_N01_0_0001" , "CR34PAGE_N01_0_0002" , "CR34PAGE_N01_0_0003" , "CR34PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("117_walking_rear_right", "CR34PAGE_N01_0_0001" , "CR34PAGE_N01_0_0002" , "CR34PAGE_N01_0_0003" , "CR34PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("117_walking_right", "CR34PAGE_N01_0_0005" , "CR34PAGE_N01_0_0006" , "CR34PAGE_N01_0_0007" , "CR34PAGE_N01_0_0008" , "" , "" , "" , "" ,4);
		CreateAnimationUW("117_walking_front_right", "CR34PAGE_N01_0_0009" , "CR34PAGE_N01_0_0010" , "CR34PAGE_N01_0_0011" , "CR34PAGE_N01_0_0012" , "" , "" , "" , "" ,4);
		CreateAnimationUW("117_walking_front", "CR34PAGE_N01_0_0009" , "CR34PAGE_N01_0_0010" , "CR34PAGE_N01_0_0011" , "CR34PAGE_N01_0_0012" , "" , "" , "" , "" ,4);
		CreateAnimationUW("117_walking_front_left", "CR34PAGE_N01_0_0009" , "CR34PAGE_N01_0_0010" , "CR34PAGE_N01_0_0011" , "CR34PAGE_N01_0_0012" , "" , "" , "" , "" ,4);
		CreateAnimationUW("117_walking_left", "CR34PAGE_N01_0_0013" , "CR34PAGE_N01_0_0014" , "CR34PAGE_N01_0_0015" , "CR34PAGE_N01_0_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("117_walking_rear_left", "CR34PAGE_N01_0_0001" , "CR34PAGE_N01_0_0002" , "CR34PAGE_N01_0_0003" , "CR34PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		//Anim ID: 54 - which is a_reaper
		//	File:c:\games\uw1\crit\CR17PAGE.N00, Palette = 0
		CreateAnimationUW("118_combat_idle", "CR17PAGE_N00_0_0000" , "CR17PAGE_N00_0_0001" , "CR17PAGE_N00_0_0002" , "CR17PAGE_N00_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("118_attack_bash", "CR17PAGE_N00_0_0000" , "CR17PAGE_N00_0_0003" , "CR17PAGE_N00_0_0004" , "CR17PAGE_N00_0_0005" , "CR17PAGE_N00_0_0000" , "" , "" , "" ,5);
		CreateAnimationUW("118_attack_slash", "CR17PAGE_N00_0_0000" , "CR17PAGE_N00_0_0006" , "CR17PAGE_N00_0_0007" , "CR17PAGE_N00_0_0008" , "CR17PAGE_N00_0_0000" , "" , "" , "" ,5);
		CreateAnimationUW("118_attack_thrust", "CR17PAGE_N00_0_0000" , "CR17PAGE_N00_0_0003" , "CR17PAGE_N00_0_0004" , "CR17PAGE_N00_0_0005" , "CR17PAGE_N00_0_0000" , "" , "" , "" ,5);
		CreateAnimationUW("118_walking_towards", "CR17PAGE_N00_0_0009" , "CR17PAGE_N00_0_0010" , "CR17PAGE_N00_0_0000" , "CR17PAGE_N00_0_0011" , "" , "" , "" , "" ,4);
		CreateAnimationUW("118_death", "CR17PAGE_N00_0_0000" , "CR17PAGE_N00_0_0012" , "CR17PAGE_N00_0_0013" , "CR17PAGE_N00_0_0014" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR17PAGE.N01, Palette = 0
		CreateAnimationUW("118_idle_rear", "CR17PAGE_N01_0_0000" , "CR17PAGE_N01_0_0000" , "CR17PAGE_N01_0_0000" , "CR17PAGE_N01_0_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("118_idle_rear_right", "CR17PAGE_N01_0_0001" , "CR17PAGE_N01_0_0001" , "CR17PAGE_N01_0_0001" , "CR17PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("118_idle_right", "CR17PAGE_N01_0_0002" , "CR17PAGE_N01_0_0002" , "CR17PAGE_N01_0_0002" , "CR17PAGE_N01_0_0002" , "" , "" , "" , "" ,4);
		CreateAnimationUW("118_idle_front_right", "CR17PAGE_N01_0_0003" , "CR17PAGE_N01_0_0003" , "CR17PAGE_N01_0_0003" , "CR17PAGE_N01_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("118_idle_front", "CR17PAGE_N01_0_0004" , "CR17PAGE_N01_0_0004" , "CR17PAGE_N01_0_0004" , "CR17PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("118_idle_front_left", "CR17PAGE_N01_0_0005" , "CR17PAGE_N01_0_0005" , "CR17PAGE_N01_0_0005" , "CR17PAGE_N01_0_0005" , "" , "" , "" , "" ,4);
		CreateAnimationUW("118_idle_left", "CR17PAGE_N01_0_0006" , "CR17PAGE_N01_0_0006" , "CR17PAGE_N01_0_0006" , "CR17PAGE_N01_0_0006" , "" , "" , "" , "" ,4);
		CreateAnimationUW("118_idle_rear_left", "CR17PAGE_N01_0_0007" , "CR17PAGE_N01_0_0007" , "CR17PAGE_N01_0_0007" , "CR17PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("118_walking_rear", "CR17PAGE_N01_0_0008" , "CR17PAGE_N01_0_0000" , "CR17PAGE_N01_0_0009" , "CR17PAGE_N01_0_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("118_walking_rear_right", "CR17PAGE_N01_0_0011" , "CR17PAGE_N01_0_0001" , "CR17PAGE_N01_0_0012" , "CR17PAGE_N01_0_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("118_walking_right", "CR17PAGE_N01_0_0014" , "CR17PAGE_N01_0_0015" , "CR17PAGE_N01_0_0002" , "CR17PAGE_N01_0_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("118_walking_front_right", "CR17PAGE_N01_0_0017" , "CR17PAGE_N01_0_0018" , "CR17PAGE_N01_0_0003" , "CR17PAGE_N01_0_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("118_walking_front", "CR17PAGE_N01_0_0020" , "CR17PAGE_N01_0_0021" , "CR17PAGE_N01_0_0004" , "CR17PAGE_N01_0_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("118_walking_front_left", "CR17PAGE_N01_0_0023" , "CR17PAGE_N01_0_0024" , "CR17PAGE_N01_0_0005" , "CR17PAGE_N01_0_0025" , "" , "" , "" , "" ,4);
		CreateAnimationUW("118_walking_left", "CR17PAGE_N01_0_0026" , "CR17PAGE_N01_0_0027" , "CR17PAGE_N01_0_0006" , "CR17PAGE_N01_0_0028" , "" , "" , "" , "" ,4);
		CreateAnimationUW("118_walking_rear_left", "CR17PAGE_N01_0_0029" , "CR17PAGE_N01_0_0007" , "CR17PAGE_N01_0_0030" , "CR17PAGE_N01_0_0031" , "" , "" , "" , "" ,4);
		//Anim ID: 55 - which is a_stone_golem
		//	File:c:\games\uw1\crit\CR23PAGE.N00, Palette = 1
		CreateAnimationUW("119_combat_idle", "CR23PAGE_N00_1_0000" , "CR23PAGE_N00_1_0001" , "CR23PAGE_N00_1_0002" , "CR23PAGE_N00_1_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("119_attack_bash", "CR23PAGE_N00_1_0004" , "CR23PAGE_N00_1_0005" , "CR23PAGE_N00_1_0006" , "CR23PAGE_N00_1_0007" , "CR23PAGE_N00_1_0008" , "" , "" , "" ,5);
		CreateAnimationUW("119_attack_slash", "CR23PAGE_N00_1_0009" , "CR23PAGE_N00_1_0010" , "CR23PAGE_N00_1_0011" , "CR23PAGE_N00_1_0012" , "CR23PAGE_N00_1_0013" , "" , "" , "" ,5);
		CreateAnimationUW("119_attack_thrust", "CR23PAGE_N00_1_0004" , "CR23PAGE_N00_1_0005" , "CR23PAGE_N00_1_0006" , "CR23PAGE_N00_1_0007" , "CR23PAGE_N00_1_0008" , "" , "" , "" ,5);
		CreateAnimationUW("119_walking_towards", "CR23PAGE_N00_1_0014" , "CR23PAGE_N00_1_0002" , "CR23PAGE_N00_1_0015" , "CR23PAGE_N00_1_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("119_death", "CR23PAGE_N00_1_0016" , "CR23PAGE_N00_1_0017" , "CR23PAGE_N00_1_0018" , "CR23PAGE_N00_1_0019" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR23PAGE.N01, Palette = 1
		CreateAnimationUW("119_idle_rear", "CR23PAGE_N01_1_0000" , "CR23PAGE_N01_1_0000" , "CR23PAGE_N01_1_0000" , "CR23PAGE_N01_1_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("119_idle_rear_right", "CR23PAGE_N01_1_0001" , "CR23PAGE_N01_1_0001" , "CR23PAGE_N01_1_0001" , "CR23PAGE_N01_1_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("119_idle_right", "CR23PAGE_N01_1_0002" , "CR23PAGE_N01_1_0002" , "CR23PAGE_N01_1_0002" , "CR23PAGE_N01_1_0002" , "" , "" , "" , "" ,4);
		CreateAnimationUW("119_idle_front_right", "CR23PAGE_N01_1_0003" , "CR23PAGE_N01_1_0003" , "CR23PAGE_N01_1_0003" , "CR23PAGE_N01_1_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("119_idle_front", "CR23PAGE_N01_1_0004" , "CR23PAGE_N01_1_0004" , "CR23PAGE_N01_1_0004" , "CR23PAGE_N01_1_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("119_idle_front_left", "CR23PAGE_N01_1_0005" , "CR23PAGE_N01_1_0005" , "CR23PAGE_N01_1_0005" , "CR23PAGE_N01_1_0005" , "" , "" , "" , "" ,4);
		CreateAnimationUW("119_idle_left", "CR23PAGE_N01_1_0006" , "CR23PAGE_N01_1_0006" , "CR23PAGE_N01_1_0006" , "CR23PAGE_N01_1_0006" , "" , "" , "" , "" ,4);
		CreateAnimationUW("119_idle_rear_left", "CR23PAGE_N01_1_0007" , "CR23PAGE_N01_1_0007" , "CR23PAGE_N01_1_0007" , "CR23PAGE_N01_1_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("119_walking_rear", "CR23PAGE_N01_1_0008" , "CR23PAGE_N01_1_0009" , "CR23PAGE_N01_1_0000" , "CR23PAGE_N01_1_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("119_walking_rear_right", "CR23PAGE_N01_1_0001" , "CR23PAGE_N01_1_0011" , "CR23PAGE_N01_1_0012" , "CR23PAGE_N01_1_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("119_walking_right", "CR23PAGE_N01_1_0014" , "CR23PAGE_N01_1_0015" , "CR23PAGE_N01_1_0016" , "CR23PAGE_N01_1_0002" , "" , "" , "" , "" ,4);
		CreateAnimationUW("119_walking_front_right", "CR23PAGE_N01_1_0003" , "CR23PAGE_N01_1_0017" , "CR23PAGE_N01_1_0018" , "CR23PAGE_N01_1_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("119_walking_front", "CR23PAGE_N01_1_0020" , "CR23PAGE_N01_1_0021" , "CR23PAGE_N01_1_0022" , "CR23PAGE_N01_1_0023" , "" , "" , "" , "" ,4);
		CreateAnimationUW("119_walking_front_left", "CR23PAGE_N01_1_0005" , "CR23PAGE_N01_1_0024" , "CR23PAGE_N01_1_0025" , "CR23PAGE_N01_1_0026" , "" , "" , "" , "" ,4);
		CreateAnimationUW("119_walking_left", "CR23PAGE_N01_1_0027" , "CR23PAGE_N01_1_0028" , "CR23PAGE_N01_1_0029" , "CR23PAGE_N01_1_0006" , "" , "" , "" , "" ,4);
		CreateAnimationUW("119_walking_rear_left", "CR23PAGE_N01_1_0007" , "CR23PAGE_N01_1_0030" , "CR23PAGE_N01_1_0031" , "CR23PAGE_N01_1_0032" , "" , "" , "" , "" ,4);
		//Anim ID: 56 - which is a_fire_elemental
		//	File:c:\games\uw1\crit\CR12PAGE.N00, Palette = 0
		CreateAnimationUW("120_combat_idle", "CR12PAGE_N00_0_0000" , "CR12PAGE_N00_0_0001" , "CR12PAGE_N00_0_0002" , "CR12PAGE_N00_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("120_attack_bash", "CR12PAGE_N00_0_0001" , "CR12PAGE_N00_0_0003" , "CR12PAGE_N00_0_0004" , "CR12PAGE_N00_0_0005" , "CR12PAGE_N00_0_0006" , "" , "" , "" ,5);
		CreateAnimationUW("120_attack_slash", "CR12PAGE_N00_0_0001" , "CR12PAGE_N00_0_0003" , "CR12PAGE_N00_0_0004" , "CR12PAGE_N00_0_0005" , "CR12PAGE_N00_0_0006" , "" , "" , "" ,5);
		CreateAnimationUW("120_attack_thrust", "CR12PAGE_N00_0_0006" , "CR12PAGE_N00_0_0007" , "CR12PAGE_N00_0_0008" , "CR12PAGE_N00_0_0009" , "CR12PAGE_N00_0_0010" , "" , "" , "" ,5);
		CreateAnimationUW("120_walking_towards", "CR12PAGE_N00_0_0011" , "CR12PAGE_N00_0_0012" , "CR12PAGE_N00_0_0013" , "CR12PAGE_N00_0_0014" , "" , "" , "" , "" ,4);
		CreateAnimationUW("120_death", "CR12PAGE_N00_0_0015" , "CR12PAGE_N00_0_0016" , "CR12PAGE_N00_0_0017" , "CR12PAGE_N00_0_0018" , "" , "" , "" , "" ,4);
		CreateAnimationUW("120_begin_combat", "CR12PAGE_N00_0_0007" , "CR12PAGE_N00_0_0008" , "CR12PAGE_N00_0_0009" , "CR12PAGE_N00_0_0010" , "CR12PAGE_N00_0_0019" , "" , "" , "" ,5);
		//	File:c:\games\uw1\crit\CR12PAGE.N01, Palette = 0
		CreateAnimationUW("120_idle_rear", "CR12PAGE_N01_0_0000" , "CR12PAGE_N01_0_0001" , "CR12PAGE_N01_0_0002" , "CR12PAGE_N01_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("120_idle_rear_right", "CR12PAGE_N01_0_0004" , "CR12PAGE_N01_0_0005" , "CR12PAGE_N01_0_0006" , "CR12PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("120_idle_right", "CR12PAGE_N01_0_0008" , "CR12PAGE_N01_0_0009" , "CR12PAGE_N01_0_0010" , "CR12PAGE_N01_0_0011" , "" , "" , "" , "" ,4);
		CreateAnimationUW("120_idle_front_right", "CR12PAGE_N01_0_0012" , "CR12PAGE_N01_0_0013" , "CR12PAGE_N01_0_0014" , "CR12PAGE_N01_0_0015" , "" , "" , "" , "" ,4);
		CreateAnimationUW("120_idle_front", "CR12PAGE_N01_0_0016" , "CR12PAGE_N01_0_0017" , "CR12PAGE_N01_0_0018" , "CR12PAGE_N01_0_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("120_idle_front_left", "CR12PAGE_N01_0_0020" , "CR12PAGE_N01_0_0021" , "CR12PAGE_N01_0_0022" , "CR12PAGE_N01_0_0023" , "" , "" , "" , "" ,4);
		CreateAnimationUW("120_idle_left", "CR12PAGE_N01_0_0024" , "CR12PAGE_N01_0_0025" , "CR12PAGE_N01_0_0026" , "CR12PAGE_N01_0_0027" , "" , "" , "" , "" ,4);
		CreateAnimationUW("120_idle_rear_left", "CR12PAGE_N01_0_0004" , "CR12PAGE_N01_0_0005" , "CR12PAGE_N01_0_0006" , "CR12PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("120_walking_rear", "CR12PAGE_N01_0_0000" , "CR12PAGE_N01_0_0001" , "CR12PAGE_N01_0_0002" , "CR12PAGE_N01_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("120_walking_rear_right", "CR12PAGE_N01_0_0004" , "CR12PAGE_N01_0_0005" , "CR12PAGE_N01_0_0006" , "CR12PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("120_walking_right", "CR12PAGE_N01_0_0008" , "CR12PAGE_N01_0_0009" , "CR12PAGE_N01_0_0010" , "CR12PAGE_N01_0_0011" , "" , "" , "" , "" ,4);
		CreateAnimationUW("120_walking_front_right", "CR12PAGE_N01_0_0012" , "CR12PAGE_N01_0_0013" , "CR12PAGE_N01_0_0014" , "CR12PAGE_N01_0_0015" , "" , "" , "" , "" ,4);
		CreateAnimationUW("120_walking_front", "CR12PAGE_N01_0_0016" , "CR12PAGE_N01_0_0017" , "CR12PAGE_N01_0_0018" , "CR12PAGE_N01_0_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("120_walking_front_left", "CR12PAGE_N01_0_0020" , "CR12PAGE_N01_0_0021" , "CR12PAGE_N01_0_0022" , "CR12PAGE_N01_0_0023" , "" , "" , "" , "" ,4);
		CreateAnimationUW("120_walking_left", "CR12PAGE_N01_0_0024" , "CR12PAGE_N01_0_0025" , "CR12PAGE_N01_0_0026" , "CR12PAGE_N01_0_0027" , "" , "" , "" , "" ,4);
		CreateAnimationUW("120_walking_rear_left", "CR12PAGE_N01_0_0004" , "CR12PAGE_N01_0_0005" , "CR12PAGE_N01_0_0006" , "CR12PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		//Anim ID: 57 - which is a_metal_golem
		//	File:c:\games\uw1\crit\CR23PAGE.N00, Palette = 2
		CreateAnimationUW("121_combat_idle", "CR23PAGE_N00_2_0000" , "CR23PAGE_N00_2_0001" , "CR23PAGE_N00_2_0002" , "CR23PAGE_N00_2_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("121_attack_bash", "CR23PAGE_N00_2_0004" , "CR23PAGE_N00_2_0005" , "CR23PAGE_N00_2_0006" , "CR23PAGE_N00_2_0007" , "CR23PAGE_N00_2_0008" , "" , "" , "" ,5);
		CreateAnimationUW("121_attack_slash", "CR23PAGE_N00_2_0009" , "CR23PAGE_N00_2_0010" , "CR23PAGE_N00_2_0011" , "CR23PAGE_N00_2_0012" , "CR23PAGE_N00_2_0013" , "" , "" , "" ,5);
		CreateAnimationUW("121_attack_thrust", "CR23PAGE_N00_2_0004" , "CR23PAGE_N00_2_0005" , "CR23PAGE_N00_2_0006" , "CR23PAGE_N00_2_0007" , "CR23PAGE_N00_2_0008" , "" , "" , "" ,5);
		CreateAnimationUW("121_walking_towards", "CR23PAGE_N00_2_0014" , "CR23PAGE_N00_2_0002" , "CR23PAGE_N00_2_0015" , "CR23PAGE_N00_2_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("121_death", "CR23PAGE_N00_2_0016" , "CR23PAGE_N00_2_0017" , "CR23PAGE_N00_2_0018" , "CR23PAGE_N00_2_0019" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR23PAGE.N01, Palette = 2
		CreateAnimationUW("121_idle_rear", "CR23PAGE_N01_2_0000" , "CR23PAGE_N01_2_0000" , "CR23PAGE_N01_2_0000" , "CR23PAGE_N01_2_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("121_idle_rear_right", "CR23PAGE_N01_2_0001" , "CR23PAGE_N01_2_0001" , "CR23PAGE_N01_2_0001" , "CR23PAGE_N01_2_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("121_idle_right", "CR23PAGE_N01_2_0002" , "CR23PAGE_N01_2_0002" , "CR23PAGE_N01_2_0002" , "CR23PAGE_N01_2_0002" , "" , "" , "" , "" ,4);
		CreateAnimationUW("121_idle_front_right", "CR23PAGE_N01_2_0003" , "CR23PAGE_N01_2_0003" , "CR23PAGE_N01_2_0003" , "CR23PAGE_N01_2_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("121_idle_front", "CR23PAGE_N01_2_0004" , "CR23PAGE_N01_2_0004" , "CR23PAGE_N01_2_0004" , "CR23PAGE_N01_2_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("121_idle_front_left", "CR23PAGE_N01_2_0005" , "CR23PAGE_N01_2_0005" , "CR23PAGE_N01_2_0005" , "CR23PAGE_N01_2_0005" , "" , "" , "" , "" ,4);
		CreateAnimationUW("121_idle_left", "CR23PAGE_N01_2_0006" , "CR23PAGE_N01_2_0006" , "CR23PAGE_N01_2_0006" , "CR23PAGE_N01_2_0006" , "" , "" , "" , "" ,4);
		CreateAnimationUW("121_idle_rear_left", "CR23PAGE_N01_2_0007" , "CR23PAGE_N01_2_0007" , "CR23PAGE_N01_2_0007" , "CR23PAGE_N01_2_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("121_walking_rear", "CR23PAGE_N01_2_0008" , "CR23PAGE_N01_2_0009" , "CR23PAGE_N01_2_0000" , "CR23PAGE_N01_2_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("121_walking_rear_right", "CR23PAGE_N01_2_0001" , "CR23PAGE_N01_2_0011" , "CR23PAGE_N01_2_0012" , "CR23PAGE_N01_2_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("121_walking_right", "CR23PAGE_N01_2_0014" , "CR23PAGE_N01_2_0015" , "CR23PAGE_N01_2_0016" , "CR23PAGE_N01_2_0002" , "" , "" , "" , "" ,4);
		CreateAnimationUW("121_walking_front_right", "CR23PAGE_N01_2_0003" , "CR23PAGE_N01_2_0017" , "CR23PAGE_N01_2_0018" , "CR23PAGE_N01_2_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("121_walking_front", "CR23PAGE_N01_2_0020" , "CR23PAGE_N01_2_0021" , "CR23PAGE_N01_2_0022" , "CR23PAGE_N01_2_0023" , "" , "" , "" , "" ,4);
		CreateAnimationUW("121_walking_front_left", "CR23PAGE_N01_2_0005" , "CR23PAGE_N01_2_0024" , "CR23PAGE_N01_2_0025" , "CR23PAGE_N01_2_0026" , "" , "" , "" , "" ,4);
		CreateAnimationUW("121_walking_left", "CR23PAGE_N01_2_0027" , "CR23PAGE_N01_2_0028" , "CR23PAGE_N01_2_0029" , "CR23PAGE_N01_2_0006" , "" , "" , "" , "" ,4);
		CreateAnimationUW("121_walking_rear_left", "CR23PAGE_N01_2_0007" , "CR23PAGE_N01_2_0030" , "CR23PAGE_N01_2_0031" , "CR23PAGE_N01_2_0032" , "" , "" , "" , "" ,4);
		//Anim ID: 58 - which is a_wisp
		//	File:c:\games\uw1\crit\CR27PAGE.N00, Palette = 0
		CreateAnimationUW("122_combat_idle", "CR27PAGE_N00_0_0000" , "CR27PAGE_N00_0_0001" , "CR27PAGE_N00_0_0002" , "CR27PAGE_N00_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("122_attack_bash", "CR27PAGE_N00_0_0000" , "CR27PAGE_N00_0_0001" , "CR27PAGE_N00_0_0002" , "CR27PAGE_N00_0_0003" , "CR27PAGE_N00_0_0002" , "" , "" , "" ,5);
		CreateAnimationUW("122_attack_slash", "CR27PAGE_N00_0_0000" , "CR27PAGE_N00_0_0001" , "CR27PAGE_N00_0_0002" , "CR27PAGE_N00_0_0003" , "CR27PAGE_N00_0_0002" , "" , "" , "" ,5);
		CreateAnimationUW("122_attack_thrust", "CR27PAGE_N00_0_0000" , "CR27PAGE_N00_0_0001" , "CR27PAGE_N00_0_0002" , "CR27PAGE_N00_0_0003" , "CR27PAGE_N00_0_0002" , "" , "" , "" ,5);
		CreateAnimationUW("122_walking_towards", "CR27PAGE_N00_0_0000" , "CR27PAGE_N00_0_0001" , "CR27PAGE_N00_0_0002" , "CR27PAGE_N00_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("122_death", "CR27PAGE_N00_0_0000" , "CR27PAGE_N00_0_0001" , "CR27PAGE_N00_0_0002" , "CR27PAGE_N00_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("122_begin_combat", "CR27PAGE_N00_0_0000" , "CR27PAGE_N00_0_0001" , "CR27PAGE_N00_0_0002" , "CR27PAGE_N00_0_0003" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR27PAGE.N01, Palette = 0
		CreateAnimationUW("122_idle_rear", "CR27PAGE_N01_0_0000" , "CR27PAGE_N01_0_0001" , "CR27PAGE_N01_0_0002" , "CR27PAGE_N01_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("122_idle_rear_right", "CR27PAGE_N01_0_0000" , "CR27PAGE_N01_0_0001" , "CR27PAGE_N01_0_0002" , "CR27PAGE_N01_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("122_idle_right", "CR27PAGE_N01_0_0000" , "CR27PAGE_N01_0_0001" , "CR27PAGE_N01_0_0002" , "CR27PAGE_N01_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("122_idle_front_right", "CR27PAGE_N01_0_0000" , "CR27PAGE_N01_0_0001" , "CR27PAGE_N01_0_0002" , "CR27PAGE_N01_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("122_idle_front", "CR27PAGE_N01_0_0000" , "CR27PAGE_N01_0_0001" , "CR27PAGE_N01_0_0002" , "CR27PAGE_N01_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("122_idle_front_left", "CR27PAGE_N01_0_0000" , "CR27PAGE_N01_0_0001" , "CR27PAGE_N01_0_0002" , "CR27PAGE_N01_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("122_idle_left", "CR27PAGE_N01_0_0000" , "CR27PAGE_N01_0_0001" , "CR27PAGE_N01_0_0002" , "CR27PAGE_N01_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("122_idle_rear_left", "CR27PAGE_N01_0_0000" , "CR27PAGE_N01_0_0001" , "CR27PAGE_N01_0_0002" , "CR27PAGE_N01_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("122_walking_rear", "CR27PAGE_N01_0_0000" , "CR27PAGE_N01_0_0001" , "CR27PAGE_N01_0_0002" , "CR27PAGE_N01_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("122_walking_rear_right", "CR27PAGE_N01_0_0000" , "CR27PAGE_N01_0_0001" , "CR27PAGE_N01_0_0002" , "CR27PAGE_N01_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("122_walking_right", "CR27PAGE_N01_0_0000" , "CR27PAGE_N01_0_0001" , "CR27PAGE_N01_0_0002" , "CR27PAGE_N01_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("122_walking_front_right", "CR27PAGE_N01_0_0000" , "CR27PAGE_N01_0_0001" , "CR27PAGE_N01_0_0002" , "CR27PAGE_N01_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("122_walking_front", "CR27PAGE_N01_0_0000" , "CR27PAGE_N01_0_0001" , "CR27PAGE_N01_0_0002" , "CR27PAGE_N01_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("122_walking_front_left", "CR27PAGE_N01_0_0000" , "CR27PAGE_N01_0_0001" , "CR27PAGE_N01_0_0002" , "CR27PAGE_N01_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("122_walking_left", "CR27PAGE_N01_0_0000" , "CR27PAGE_N01_0_0001" , "CR27PAGE_N01_0_0002" , "CR27PAGE_N01_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("122_walking_rear_left", "CR27PAGE_N01_0_0000" , "CR27PAGE_N01_0_0001" , "CR27PAGE_N01_0_0002" , "CR27PAGE_N01_0_0003" , "" , "" , "" , "" ,4);
		//Anim ID: 59 - which is tybal
		//	File:c:\games\uw1\crit\CR35PAGE.N00, Palette = 0
		CreateAnimationUW("123_combat_idle", "CR35PAGE_N00_0_0000" , "CR35PAGE_N00_0_0000" , "CR35PAGE_N00_0_0000" , "CR35PAGE_N00_0_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("123_attack_bash", "CR35PAGE_N00_0_0000" , "CR35PAGE_N00_0_0001" , "CR35PAGE_N00_0_0002" , "CR35PAGE_N00_0_0003" , "CR35PAGE_N00_0_0002" , "" , "" , "" ,5);
		CreateAnimationUW("123_attack_slash", "CR35PAGE_N00_0_0004" , "CR35PAGE_N00_0_0005" , "CR35PAGE_N00_0_0006" , "CR35PAGE_N00_0_0007" , "CR35PAGE_N00_0_0004" , "" , "" , "" ,5);
		CreateAnimationUW("123_attack_thrust", "CR35PAGE_N00_0_0008" , "CR35PAGE_N00_0_0009" , "CR35PAGE_N00_0_0010" , "CR35PAGE_N00_0_0011" , "CR35PAGE_N00_0_0008" , "" , "" , "" ,5);
		CreateAnimationUW("123_walking_towards", "CR35PAGE_N00_0_0012" , "CR35PAGE_N00_0_0013" , "CR35PAGE_N00_0_0014" , "CR35PAGE_N00_0_0015" , "" , "" , "" , "" ,4);
		CreateAnimationUW("123_death", "CR35PAGE_N00_0_0016" , "CR35PAGE_N00_0_0017" , "CR35PAGE_N00_0_0018" , "CR35PAGE_N00_0_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("123_begin_combat", "CR35PAGE_N00_0_0000" , "CR35PAGE_N00_0_0001" , "CR35PAGE_N00_0_0002" , "CR35PAGE_N00_0_0003" , "CR35PAGE_N00_0_0002" , "" , "" , "" ,5);
		//	File:c:\games\uw1\crit\CR35PAGE.N01, Palette = 0
		CreateAnimationUW("123_idle_rear", "CR35PAGE_N01_0_0000" , "CR35PAGE_N01_0_0001" , "CR35PAGE_N01_0_0002" , "CR35PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("123_idle_rear_right", "CR35PAGE_N01_0_0003" , "CR35PAGE_N01_0_0004" , "CR35PAGE_N01_0_0005" , "CR35PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("123_idle_right", "CR35PAGE_N01_0_0006" , "CR35PAGE_N01_0_0007" , "CR35PAGE_N01_0_0008" , "CR35PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("123_idle_front_right", "CR35PAGE_N01_0_0009" , "CR35PAGE_N01_0_0010" , "CR35PAGE_N01_0_0011" , "CR35PAGE_N01_0_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("123_idle_front", "CR35PAGE_N01_0_0012" , "CR35PAGE_N01_0_0013" , "CR35PAGE_N01_0_0014" , "CR35PAGE_N01_0_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("123_idle_front_left", "CR35PAGE_N01_0_0015" , "CR35PAGE_N01_0_0016" , "CR35PAGE_N01_0_0017" , "CR35PAGE_N01_0_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("123_idle_left", "CR35PAGE_N01_0_0018" , "CR35PAGE_N01_0_0019" , "CR35PAGE_N01_0_0020" , "CR35PAGE_N01_0_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("123_idle_rear_left", "CR35PAGE_N01_0_0021" , "CR35PAGE_N01_0_0022" , "CR35PAGE_N01_0_0023" , "CR35PAGE_N01_0_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("123_walking_rear", "CR35PAGE_N01_0_0024" , "CR35PAGE_N01_0_0025" , "CR35PAGE_N01_0_0026" , "CR35PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("123_walking_rear_right", "CR35PAGE_N01_0_0027" , "CR35PAGE_N01_0_0028" , "CR35PAGE_N01_0_0029" , "CR35PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("123_walking_right", "CR35PAGE_N01_0_0030" , "CR35PAGE_N01_0_0031" , "CR35PAGE_N01_0_0007" , "CR35PAGE_N01_0_0032" , "" , "" , "" , "" ,4);
		CreateAnimationUW("123_walking_front_right", "CR35PAGE_N01_0_0010" , "CR35PAGE_N01_0_0033" , "CR35PAGE_N01_0_0034" , "CR35PAGE_N01_0_0035" , "" , "" , "" , "" ,4);
		CreateAnimationUW("123_walking_front", "CR35PAGE_N01_0_0036" , "CR35PAGE_N01_0_0037" , "CR35PAGE_N01_0_0038" , "CR35PAGE_N01_0_0039" , "" , "" , "" , "" ,4);
		CreateAnimationUW("123_walking_front_left", "CR35PAGE_N01_0_0016" , "CR35PAGE_N01_0_0040" , "CR35PAGE_N01_0_0041" , "CR35PAGE_N01_0_0042" , "" , "" , "" , "" ,4);
		CreateAnimationUW("123_walking_left", "CR35PAGE_N01_0_0043" , "CR35PAGE_N01_0_0044" , "CR35PAGE_N01_0_0019" , "CR35PAGE_N01_0_0045" , "" , "" , "" , "" ,4);
		CreateAnimationUW("123_walking_rear_left", "CR35PAGE_N01_0_0046" , "CR35PAGE_N01_0_0047" , "CR35PAGE_N01_0_0048" , "CR35PAGE_N01_0_0022" , "" , "" , "" , "" ,4);
		//Anim ID: 60 - which is slasher_of_veils
		//	File:c:\games\uw1\crit\CR14PAGE.N00, Palette = 0
		CreateAnimationUW("124_combat_idle", "CR14PAGE_N00_0_0000" , "CR14PAGE_N00_0_0000" , "CR14PAGE_N00_0_0000" , "CR14PAGE_N00_0_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("124_attack_bash", "CR14PAGE_N00_0_0001" , "CR14PAGE_N00_0_0002" , "CR14PAGE_N00_0_0003" , "CR14PAGE_N00_0_0004" , "CR14PAGE_N00_0_0005" , "" , "" , "" ,5);
		CreateAnimationUW("124_attack_slash", "CR14PAGE_N00_0_0006" , "CR14PAGE_N00_0_0007" , "CR14PAGE_N00_0_0008" , "CR14PAGE_N00_0_0007" , "CR14PAGE_N00_0_0009" , "" , "" , "" ,5);
		CreateAnimationUW("124_attack_thrust", "CR14PAGE_N00_0_0007" , "CR14PAGE_N00_0_0006" , "CR14PAGE_N00_0_0007" , "CR14PAGE_N00_0_0008" , "CR14PAGE_N00_0_0009" , "" , "" , "" ,5);
		CreateAnimationUW("124_walking_towards", "CR14PAGE_N00_0_0009" , "CR14PAGE_N00_0_0010" , "CR14PAGE_N00_0_0007" , "CR14PAGE_N00_0_0011" , "" , "" , "" , "" ,4);
		CreateAnimationUW("124_death", "CR14PAGE_N00_0_0011" , "CR14PAGE_N00_0_0011" , "CR14PAGE_N00_0_0011" , "CR14PAGE_N00_0_0011" , "" , "" , "" , "" ,4);
		CreateAnimationUW("124_begin_combat", "CR14PAGE_N00_0_0011" , "CR14PAGE_N00_0_0011" , "CR14PAGE_N00_0_0010" , "CR14PAGE_N00_0_0010" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR14PAGE.N01, Palette = 0
		CreateAnimationUW("124_idle_rear", "CR14PAGE_N01_0_0000" , "CR14PAGE_N01_0_0000" , "CR14PAGE_N01_0_0000" , "CR14PAGE_N01_0_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("124_idle_rear_right", "CR14PAGE_N01_0_0001" , "CR14PAGE_N01_0_0001" , "CR14PAGE_N01_0_0001" , "CR14PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("124_idle_right", "CR14PAGE_N01_0_0002" , "CR14PAGE_N01_0_0002" , "CR14PAGE_N01_0_0002" , "CR14PAGE_N01_0_0002" , "" , "" , "" , "" ,4);
		CreateAnimationUW("124_idle_front_right", "CR14PAGE_N01_0_0003" , "CR14PAGE_N01_0_0003" , "CR14PAGE_N01_0_0003" , "CR14PAGE_N01_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("124_idle_front", "CR14PAGE_N01_0_0004" , "CR14PAGE_N01_0_0004" , "CR14PAGE_N01_0_0004" , "CR14PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("124_idle_front_left", "CR14PAGE_N01_0_0005" , "CR14PAGE_N01_0_0005" , "CR14PAGE_N01_0_0005" , "CR14PAGE_N01_0_0005" , "" , "" , "" , "" ,4);
		CreateAnimationUW("124_idle_left", "CR14PAGE_N01_0_0006" , "CR14PAGE_N01_0_0006" , "CR14PAGE_N01_0_0006" , "CR14PAGE_N01_0_0006" , "" , "" , "" , "" ,4);
		CreateAnimationUW("124_idle_rear_left", "CR14PAGE_N01_0_0007" , "CR14PAGE_N01_0_0007" , "CR14PAGE_N01_0_0007" , "CR14PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("124_walking_rear", "CR14PAGE_N01_0_0008" , "CR14PAGE_N01_0_0009" , "CR14PAGE_N01_0_0000" , "CR14PAGE_N01_0_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("124_walking_rear_right", "CR14PAGE_N01_0_0011" , "CR14PAGE_N01_0_0011" , "CR14PAGE_N01_0_0001" , "CR14PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("124_walking_right", "CR14PAGE_N01_0_0002" , "CR14PAGE_N01_0_0012" , "CR14PAGE_N01_0_0013" , "CR14PAGE_N01_0_0014" , "" , "" , "" , "" ,4);
		CreateAnimationUW("124_walking_front_right", "CR14PAGE_N01_0_0003" , "CR14PAGE_N01_0_0003" , "CR14PAGE_N01_0_0015" , "CR14PAGE_N01_0_0015" , "" , "" , "" , "" ,4);
		CreateAnimationUW("124_walking_front", "CR14PAGE_N01_0_0016" , "CR14PAGE_N01_0_0017" , "CR14PAGE_N01_0_0018" , "CR14PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("124_walking_front_left", "CR14PAGE_N01_0_0019" , "CR14PAGE_N01_0_0019" , "CR14PAGE_N01_0_0005" , "CR14PAGE_N01_0_0005" , "" , "" , "" , "" ,4);
		CreateAnimationUW("124_walking_left", "CR14PAGE_N01_0_0006" , "CR14PAGE_N01_0_0020" , "CR14PAGE_N01_0_0021" , "CR14PAGE_N01_0_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("124_walking_rear_left", "CR14PAGE_N01_0_0023" , "CR14PAGE_N01_0_0023" , "CR14PAGE_N01_0_0007" , "CR14PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		//Anim ID: 61 - which is unknown
		//	File:c:\games\uw1\crit\CR37PAGE.N00, Palette = 0
		CreateAnimationUW("125_combat_idle", "" , "" , "" , "" , "" , "" , "" , "" ,0);
		//	File:c:\games\uw1\crit\CR37PAGE.N01, Palette = 0
		CreateAnimationUW("125_idle_rear", "CR37PAGE_N01_0_0000" , "CR37PAGE_N01_0_0001" , "CR37PAGE_N01_0_0002" , "CR37PAGE_N01_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("125_idle_rear_right", "CR37PAGE_N01_0_0000" , "CR37PAGE_N01_0_0001" , "CR37PAGE_N01_0_0002" , "CR37PAGE_N01_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("125_idle_right", "CR37PAGE_N01_0_0000" , "CR37PAGE_N01_0_0001" , "CR37PAGE_N01_0_0002" , "CR37PAGE_N01_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("125_idle_front_right", "CR37PAGE_N01_0_0000" , "CR37PAGE_N01_0_0001" , "CR37PAGE_N01_0_0002" , "CR37PAGE_N01_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("125_idle_front", "CR37PAGE_N01_0_0000" , "CR37PAGE_N01_0_0001" , "CR37PAGE_N01_0_0002" , "CR37PAGE_N01_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("125_idle_front_left", "CR37PAGE_N01_0_0000" , "CR37PAGE_N01_0_0001" , "CR37PAGE_N01_0_0002" , "CR37PAGE_N01_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("125_idle_left", "CR37PAGE_N01_0_0000" , "CR37PAGE_N01_0_0001" , "CR37PAGE_N01_0_0002" , "CR37PAGE_N01_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("125_idle_rear_left", "CR37PAGE_N01_0_0000" , "CR37PAGE_N01_0_0001" , "CR37PAGE_N01_0_0002" , "CR37PAGE_N01_0_0003" , "" , "" , "" , "" ,4);
		CreateAnimationUW("125_unknown_anim", "CR37PAGE_N01_0_0004" , "CR37PAGE_N01_0_0005" , "CR37PAGE_N01_0_0006" , "CR37PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("125_unknown_anim", "CR37PAGE_N01_0_0004" , "CR37PAGE_N01_0_0005" , "CR37PAGE_N01_0_0006" , "CR37PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("125_unknown_anim", "CR37PAGE_N01_0_0004" , "CR37PAGE_N01_0_0005" , "CR37PAGE_N01_0_0006" , "CR37PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("125_unknown_anim", "CR37PAGE_N01_0_0004" , "CR37PAGE_N01_0_0005" , "CR37PAGE_N01_0_0006" , "CR37PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("125_unknown_anim", "CR37PAGE_N01_0_0004" , "CR37PAGE_N01_0_0005" , "CR37PAGE_N01_0_0006" , "CR37PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("125_unknown_anim", "CR37PAGE_N01_0_0004" , "CR37PAGE_N01_0_0005" , "CR37PAGE_N01_0_0006" , "CR37PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("125_unknown_anim", "CR37PAGE_N01_0_0004" , "CR37PAGE_N01_0_0005" , "CR37PAGE_N01_0_0006" , "CR37PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("125_unknown_anim", "CR37PAGE_N01_0_0004" , "CR37PAGE_N01_0_0005" , "CR37PAGE_N01_0_0006" , "CR37PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		//Anim ID: 62 - which is unknown
		//	File:c:\games\uw1\crit\CR36PAGE.N00, Palette = 0
		CreateAnimationUW("126_combat_idle", "" , "" , "" , "" , "" , "" , "" , "" ,0);
		//	File:c:\games\uw1\crit\CR36PAGE.N01, Palette = 0
		CreateAnimationUW("126_idle_rear", "CR36PAGE_N01_0_0000" , "CR36PAGE_N01_0_0001" , "CR36PAGE_N01_0_0001" , "CR36PAGE_N01_0_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("126_idle_rear_right", "CR36PAGE_N01_0_0000" , "CR36PAGE_N01_0_0001" , "CR36PAGE_N01_0_0001" , "CR36PAGE_N01_0_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("126_idle_right", "CR36PAGE_N01_0_0000" , "CR36PAGE_N01_0_0001" , "CR36PAGE_N01_0_0001" , "CR36PAGE_N01_0_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("126_idle_front_right", "CR36PAGE_N01_0_0000" , "CR36PAGE_N01_0_0001" , "CR36PAGE_N01_0_0001" , "CR36PAGE_N01_0_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("126_idle_front", "CR36PAGE_N01_0_0000" , "CR36PAGE_N01_0_0001" , "CR36PAGE_N01_0_0001" , "CR36PAGE_N01_0_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("126_idle_front_left", "CR36PAGE_N01_0_0000" , "CR36PAGE_N01_0_0001" , "CR36PAGE_N01_0_0001" , "CR36PAGE_N01_0_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("126_idle_left", "CR36PAGE_N01_0_0000" , "CR36PAGE_N01_0_0001" , "CR36PAGE_N01_0_0001" , "CR36PAGE_N01_0_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("126_idle_rear_left", "CR36PAGE_N01_0_0000" , "CR36PAGE_N01_0_0001" , "CR36PAGE_N01_0_0001" , "CR36PAGE_N01_0_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("126_unknown_anim", "CR36PAGE_N01_0_0002" , "CR36PAGE_N01_0_0003" , "CR36PAGE_N01_0_0004" , "CR36PAGE_N01_0_0005" , "" , "" , "" , "" ,4);
		CreateAnimationUW("126_unknown_anim", "CR36PAGE_N01_0_0002" , "CR36PAGE_N01_0_0003" , "CR36PAGE_N01_0_0004" , "CR36PAGE_N01_0_0005" , "" , "" , "" , "" ,4);
		CreateAnimationUW("126_unknown_anim", "CR36PAGE_N01_0_0002" , "CR36PAGE_N01_0_0003" , "CR36PAGE_N01_0_0004" , "CR36PAGE_N01_0_0005" , "" , "" , "" , "" ,4);
		CreateAnimationUW("126_unknown_anim", "CR36PAGE_N01_0_0002" , "CR36PAGE_N01_0_0003" , "CR36PAGE_N01_0_0004" , "CR36PAGE_N01_0_0005" , "" , "" , "" , "" ,4);
		CreateAnimationUW("126_unknown_anim", "CR36PAGE_N01_0_0002" , "CR36PAGE_N01_0_0003" , "CR36PAGE_N01_0_0004" , "CR36PAGE_N01_0_0005" , "" , "" , "" , "" ,4);
		CreateAnimationUW("126_unknown_anim", "CR36PAGE_N01_0_0002" , "CR36PAGE_N01_0_0003" , "CR36PAGE_N01_0_0004" , "CR36PAGE_N01_0_0005" , "" , "" , "" , "" ,4);
		CreateAnimationUW("126_unknown_anim", "CR36PAGE_N01_0_0002" , "CR36PAGE_N01_0_0003" , "CR36PAGE_N01_0_0004" , "CR36PAGE_N01_0_0005" , "" , "" , "" , "" ,4);
		CreateAnimationUW("126_unknown_anim", "CR36PAGE_N01_0_0002" , "CR36PAGE_N01_0_0003" , "CR36PAGE_N01_0_0004" , "CR36PAGE_N01_0_0005" , "" , "" , "" , "" ,4);
		//Anim ID: 63 - which is an_adventurer
		//	File:c:\games\uw1\crit\CR32PAGE.N00, Palette = 0
		CreateAnimationUW("127_combat_idle", "CR32PAGE_N00_0_0000" , "CR32PAGE_N00_0_0001" , "CR32PAGE_N00_0_0000" , "CR32PAGE_N00_0_0000" , "" , "" , "" , "" ,4);
		CreateAnimationUW("127_attack_bash", "CR32PAGE_N00_0_0000" , "CR32PAGE_N00_0_0001" , "CR32PAGE_N00_0_0002" , "CR32PAGE_N00_0_0001" , "CR32PAGE_N00_0_0000" , "" , "" , "" ,5);
		CreateAnimationUW("127_attack_slash", "CR32PAGE_N00_0_0000" , "CR32PAGE_N00_0_0003" , "CR32PAGE_N00_0_0004" , "CR32PAGE_N00_0_0005" , "CR32PAGE_N00_0_0000" , "" , "" , "" ,5);
		CreateAnimationUW("127_attack_thrust", "CR32PAGE_N00_0_0000" , "CR32PAGE_N00_0_0001" , "CR32PAGE_N00_0_0004" , "CR32PAGE_N00_0_0006" , "CR32PAGE_N00_0_0001" , "" , "" , "" ,5);
		CreateAnimationUW("127_walking_towards", "CR32PAGE_N00_0_0007" , "CR32PAGE_N00_0_0008" , "CR32PAGE_N00_0_0009" , "CR32PAGE_N00_0_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("127_death", "CR32PAGE_N00_0_0000" , "CR32PAGE_N00_0_0000" , "CR32PAGE_N00_0_0011" , "CR32PAGE_N00_0_0012" , "" , "" , "" , "" ,4);
		CreateAnimationUW("127_begin_combat", "CR32PAGE_N00_0_0013" , "CR32PAGE_N00_0_0014" , "CR32PAGE_N00_0_0000" , "CR32PAGE_N00_0_0000" , "" , "" , "" , "" ,4);
		//	File:c:\games\uw1\crit\CR32PAGE.N01, Palette = 0
		CreateAnimationUW("127_idle_rear", "CR32PAGE_N01_0_0000" , "CR32PAGE_N01_0_0001" , "CR32PAGE_N01_0_0002" , "CR32PAGE_N01_0_0001" , "" , "" , "" , "" ,4);
		CreateAnimationUW("127_idle_rear_right", "CR32PAGE_N01_0_0003" , "CR32PAGE_N01_0_0004" , "CR32PAGE_N01_0_0005" , "CR32PAGE_N01_0_0004" , "" , "" , "" , "" ,4);
		CreateAnimationUW("127_idle_right", "CR32PAGE_N01_0_0006" , "CR32PAGE_N01_0_0007" , "CR32PAGE_N01_0_0008" , "CR32PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("127_idle_front_right", "CR32PAGE_N01_0_0009" , "CR32PAGE_N01_0_0010" , "CR32PAGE_N01_0_0011" , "CR32PAGE_N01_0_0010" , "" , "" , "" , "" ,4);
		CreateAnimationUW("127_idle_front", "CR32PAGE_N01_0_0012" , "CR32PAGE_N01_0_0013" , "CR32PAGE_N01_0_0014" , "CR32PAGE_N01_0_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("127_idle_front_left", "CR32PAGE_N01_0_0015" , "CR32PAGE_N01_0_0016" , "CR32PAGE_N01_0_0017" , "CR32PAGE_N01_0_0016" , "" , "" , "" , "" ,4);
		CreateAnimationUW("127_idle_left", "CR32PAGE_N01_0_0018" , "CR32PAGE_N01_0_0019" , "CR32PAGE_N01_0_0020" , "CR32PAGE_N01_0_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("127_idle_rear_left", "CR32PAGE_N01_0_0021" , "CR32PAGE_N01_0_0022" , "CR32PAGE_N01_0_0023" , "CR32PAGE_N01_0_0022" , "" , "" , "" , "" ,4);
		CreateAnimationUW("127_walking_rear", "CR32PAGE_N01_0_0001" , "CR32PAGE_N01_0_0024" , "CR32PAGE_N01_0_0025" , "CR32PAGE_N01_0_0026" , "" , "" , "" , "" ,4);
		CreateAnimationUW("127_walking_rear_right", "CR32PAGE_N01_0_0027" , "CR32PAGE_N01_0_0028" , "CR32PAGE_N01_0_0004" , "CR32PAGE_N01_0_0029" , "" , "" , "" , "" ,4);
		CreateAnimationUW("127_walking_right", "CR32PAGE_N01_0_0030" , "CR32PAGE_N01_0_0031" , "CR32PAGE_N01_0_0032" , "CR32PAGE_N01_0_0007" , "" , "" , "" , "" ,4);
		CreateAnimationUW("127_walking_front_right", "CR32PAGE_N01_0_0033" , "CR32PAGE_N01_0_0010" , "CR32PAGE_N01_0_0034" , "CR32PAGE_N01_0_0035" , "" , "" , "" , "" ,4);
		CreateAnimationUW("127_walking_front", "CR32PAGE_N01_0_0036" , "CR32PAGE_N01_0_0037" , "CR32PAGE_N01_0_0038" , "CR32PAGE_N01_0_0013" , "" , "" , "" , "" ,4);
		CreateAnimationUW("127_walking_front_left", "CR32PAGE_N01_0_0039" , "CR32PAGE_N01_0_0016" , "CR32PAGE_N01_0_0040" , "CR32PAGE_N01_0_0041" , "" , "" , "" , "" ,4);
		CreateAnimationUW("127_walking_left", "CR32PAGE_N01_0_0042" , "CR32PAGE_N01_0_0043" , "CR32PAGE_N01_0_0044" , "CR32PAGE_N01_0_0019" , "" , "" , "" , "" ,4);
		CreateAnimationUW("127_walking_rear_left", "CR32PAGE_N01_0_0045" , "CR32PAGE_N01_0_0046" , "CR32PAGE_N01_0_0022" , "CR32PAGE_N01_0_0047" , "" , "" , "" , "" ,4);
*/

		//string[] animArray= {"","",""};
		//CreateAnimationAsset ("Animname", animArray, 2);
//		return;
	}

		[MenuItem("MyTools/CreateAnim-UW2Critters")]
		static void GenerateAnimationAssets_UW2Critters()
		{

				_RES="UW2";

				//Anim ID: 0 - which is a_rotworm//Animation #0 idle
				CreateAnimationUW("64_idle_rear","CR00_00_0_0018","CR00_00_0_0018","CR00_00_0_0018","CR00_00_0_0018","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("64_idle_rear_right","CR00_00_0_0020","CR00_00_0_0020","CR00_00_0_0020","CR00_00_0_0020","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("64_idle_right","CR00_00_0_0024","CR00_00_0_0024","CR00_00_0_0024","CR00_00_0_0024","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("64_idle_front_right","CR00_00_0_0031","CR00_00_0_0031","CR00_00_0_0031","CR00_00_0_0031","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("64_idle_front","CR00_00_0_0000","CR00_00_0_0000","CR00_00_0_0000","CR00_00_0_0000","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("64_idle_front_left","CR00_00_0_0007","CR00_00_0_0007","CR00_00_0_0007","CR00_00_0_0007","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("64_idle_left","CR00_00_0_0008","CR00_00_0_0008","CR00_00_0_0008","CR00_00_0_0008","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("64_idle_rear_left","CR00_00_0_0014","CR00_00_0_0014","CR00_00_0_0014","CR00_00_0_0014","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("64_walking_rear","CR00_00_0_0016","CR00_00_0_0017","CR00_00_0_0018","CR00_00_0_0019","CR00_00_0_0018","CR00_00_0_0017", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("64_walking_rear_right","CR00_00_0_0020","CR00_00_0_0021","CR00_00_0_0022","CR00_00_0_0023","CR00_00_0_0022","CR00_00_0_0021", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("64_walking_right","CR00_00_0_0024","CR00_00_0_0025","CR00_00_0_0026","CR00_00_0_0027","CR00_00_0_0026","CR00_00_0_0025", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("64_walking_front_right","CR00_00_0_0028","CR00_00_0_0029","CR00_00_0_0030","CR00_00_0_0031","CR00_00_0_0030","CR00_00_0_0029", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("64_walking_front","CR00_00_0_0000","CR00_00_0_0001","CR00_00_0_0002","CR00_00_0_0003","CR00_00_0_0002","CR00_00_0_0001", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("64_walking_front_left","CR00_00_0_0004","CR00_00_0_0005","CR00_00_0_0006","CR00_00_0_0007","CR00_00_0_0006","CR00_00_0_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("64_walking_left","CR00_00_0_0008","CR00_00_0_0009","CR00_00_0_0010","CR00_00_0_0011","CR00_00_0_0010","CR00_00_0_0009", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("64_walking_rear_left","CR00_00_0_0012","CR00_00_0_0013","CR00_00_0_0014","CR00_00_0_0015","CR00_00_0_0014","CR00_00_0_0013", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("64_attack_bash","CR00_00_0_0000","CR00_00_0_0001","CR00_00_0_0002","CR00_00_0_0003","CR00_00_0_0002","CR00_00_0_0001", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("64_attack_slash","CR00_00_0_0032","CR00_00_0_0033","CR00_00_0_0034","CR00_00_0_0035","CR00_00_0_0034","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("64_attack_thrust","CR00_00_0_0032","CR00_00_0_0033","CR00_00_0_0034","CR00_00_0_0034","CR00_00_0_0035","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("64_attack_secondary","CR00_00_0_0032","CR00_00_0_0033","CR00_00_0_0034","CR00_00_0_0034","CR00_00_0_0035","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("64_attack_unk","CR00_00_0_0032","CR00_00_0_0033","CR00_00_0_0034","CR00_00_0_0034","CR00_00_0_0035","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("64_death","CR00_00_0_0036","CR00_00_0_0037","CR00_00_0_0038","","","", 3, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 1 - which is a_cave_bat//Animation #0 idle
				CreateAnimationUW("65_idle_rear","CR01_00_0_0024","CR01_00_0_0025","CR01_00_0_0026","CR01_00_0_0027","CR01_00_0_0028","CR01_00_0_0029", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("65_idle_rear_right","CR01_00_0_0030","CR01_00_0_0031","CR01_00_0_0032","CR01_00_0_0033","CR01_00_0_0034","CR01_00_0_0035", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("65_idle_right","CR01_00_0_0036","CR01_00_0_0037","CR01_00_0_0038","CR01_00_0_0039","CR01_00_0_0040","CR01_00_0_0041", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("65_idle_front_right","CR01_00_0_0042","CR01_00_0_0043","CR01_00_0_0044","CR01_00_0_0045","CR01_00_0_0046","CR01_00_0_0047", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("65_idle_front","CR01_00_0_0000","CR01_00_0_0001","CR01_00_0_0002","CR01_00_0_0003","CR01_00_0_0004","CR01_00_0_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("65_idle_front_left","CR01_00_0_0006","CR01_00_0_0007","CR01_00_0_0008","CR01_00_0_0009","CR01_00_0_0010","CR01_00_0_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("65_idle_left","CR01_00_0_0012","CR01_00_0_0013","CR01_00_0_0014","CR01_00_0_0015","CR01_00_0_0016","CR01_00_0_0017", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("65_idle_rear_left","CR01_00_0_0018","CR01_00_0_0019","CR01_00_0_0020","CR01_00_0_0021","CR01_00_0_0022","CR01_00_0_0023", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("65_walking_rear","CR01_00_0_0024","CR01_00_0_0025","CR01_00_0_0026","CR01_00_0_0027","CR01_00_0_0028","CR01_00_0_0029", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("65_walking_rear_right","CR01_00_0_0030","CR01_00_0_0031","CR01_00_0_0032","CR01_00_0_0033","CR01_00_0_0034","CR01_00_0_0035", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("65_walking_right","CR01_00_0_0036","CR01_00_0_0037","CR01_00_0_0038","CR01_00_0_0039","CR01_00_0_0040","CR01_00_0_0041", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("65_walking_front_right","CR01_00_0_0042","CR01_00_0_0043","CR01_00_0_0044","CR01_00_0_0045","CR01_00_0_0046","CR01_00_0_0047", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("65_walking_front","CR01_00_0_0000","CR01_00_0_0001","CR01_00_0_0002","CR01_00_0_0003","CR01_00_0_0004","CR01_00_0_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("65_walking_front_left","CR01_00_0_0006","CR01_00_0_0007","CR01_00_0_0008","CR01_00_0_0009","CR01_00_0_0010","CR01_00_0_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("65_walking_left","CR01_00_0_0012","CR01_00_0_0013","CR01_00_0_0014","CR01_00_0_0015","CR01_00_0_0016","CR01_00_0_0017", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("65_walking_rear_left","CR01_00_0_0018","CR01_00_0_0019","CR01_00_0_0020","CR01_00_0_0021","CR01_00_0_0022","CR01_00_0_0023", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("65_attack_bash","CR01_00_0_0048","CR01_00_0_0049","CR01_00_0_0050","CR01_00_0_0051","CR01_00_0_0052","CR01_00_0_0053", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("65_attack_slash","CR01_00_0_0054","CR01_00_0_0055","CR01_00_0_0056","CR01_01_0_0000","CR01_01_0_0001","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("65_attack_thrust","CR01_01_0_0002","CR01_01_0_0003","CR01_01_0_0004","CR01_01_0_0005","CR01_01_0_0006","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("65_attack_secondary","CR01_01_0_0002","CR01_01_0_0003","CR01_01_0_0004","CR01_01_0_0005","CR01_01_0_0006","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("65_attack_unk","CR01_01_0_0002","CR01_01_0_0003","CR01_01_0_0004","CR01_01_0_0005","CR01_01_0_0006","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("65_death","CR01_01_0_0007","CR01_01_0_0008","CR01_01_0_0009","CR01_01_0_0010","CR01_01_0_0011","", 5, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 2 - which is a_vampire_bat//Animation #0 idle
				CreateAnimationUW("66_idle_rear","CR01_00_1_0024","CR01_00_1_0025","CR01_00_1_0026","CR01_00_1_0027","CR01_00_1_0028","CR01_00_1_0029", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("66_idle_rear_right","CR01_00_1_0030","CR01_00_1_0031","CR01_00_1_0032","CR01_00_1_0033","CR01_00_1_0034","CR01_00_1_0035", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("66_idle_right","CR01_00_1_0036","CR01_00_1_0037","CR01_00_1_0038","CR01_00_1_0039","CR01_00_1_0040","CR01_00_1_0041", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("66_idle_front_right","CR01_00_1_0042","CR01_00_1_0043","CR01_00_1_0044","CR01_00_1_0045","CR01_00_1_0046","CR01_00_1_0047", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("66_idle_front","CR01_00_1_0000","CR01_00_1_0001","CR01_00_1_0002","CR01_00_1_0003","CR01_00_1_0004","CR01_00_1_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("66_idle_front_left","CR01_00_1_0006","CR01_00_1_0007","CR01_00_1_0008","CR01_00_1_0009","CR01_00_1_0010","CR01_00_1_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("66_idle_left","CR01_00_1_0012","CR01_00_1_0013","CR01_00_1_0014","CR01_00_1_0015","CR01_00_1_0016","CR01_00_1_0017", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("66_idle_rear_left","CR01_00_1_0018","CR01_00_1_0019","CR01_00_1_0020","CR01_00_1_0021","CR01_00_1_0022","CR01_00_1_0023", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("66_walking_rear","CR01_00_1_0024","CR01_00_1_0025","CR01_00_1_0026","CR01_00_1_0027","CR01_00_1_0028","CR01_00_1_0029", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("66_walking_rear_right","CR01_00_1_0030","CR01_00_1_0031","CR01_00_1_0032","CR01_00_1_0033","CR01_00_1_0034","CR01_00_1_0035", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("66_walking_right","CR01_00_1_0036","CR01_00_1_0037","CR01_00_1_0038","CR01_00_1_0039","CR01_00_1_0040","CR01_00_1_0041", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("66_walking_front_right","CR01_00_1_0042","CR01_00_1_0043","CR01_00_1_0044","CR01_00_1_0045","CR01_00_1_0046","CR01_00_1_0047", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("66_walking_front","CR01_00_1_0000","CR01_00_1_0001","CR01_00_1_0002","CR01_00_1_0003","CR01_00_1_0004","CR01_00_1_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("66_walking_front_left","CR01_00_1_0006","CR01_00_1_0007","CR01_00_1_0008","CR01_00_1_0009","CR01_00_1_0010","CR01_00_1_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("66_walking_left","CR01_00_1_0012","CR01_00_1_0013","CR01_00_1_0014","CR01_00_1_0015","CR01_00_1_0016","CR01_00_1_0017", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("66_walking_rear_left","CR01_00_1_0018","CR01_00_1_0019","CR01_00_1_0020","CR01_00_1_0021","CR01_00_1_0022","CR01_00_1_0023", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("66_attack_bash","CR01_00_1_0048","CR01_00_1_0049","CR01_00_1_0050","CR01_00_1_0051","CR01_00_1_0052","CR01_00_1_0053", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("66_attack_slash","CR01_00_1_0054","CR01_00_1_0055","CR01_00_1_0056","CR01_01_1_0000","CR01_01_1_0001","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("66_attack_thrust","CR01_01_1_0002","CR01_01_1_0003","CR01_01_1_0004","CR01_01_1_0005","CR01_01_1_0006","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("66_attack_secondary","CR01_01_1_0002","CR01_01_1_0003","CR01_01_1_0004","CR01_01_1_0005","CR01_01_1_0006","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("66_attack_unk","CR01_01_1_0002","CR01_01_1_0003","CR01_01_1_0004","CR01_01_1_0005","CR01_01_1_0006","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("66_death","CR01_01_1_0007","CR01_01_1_0008","CR01_01_1_0009","CR01_01_1_0010","CR01_01_1_0011","", 5, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 3 - which is a_giant_tan_rat//Animation #0 idle
				CreateAnimationUW("67_idle_rear","CR02_01_0_0007","CR02_01_0_0008","CR02_01_0_0009","CR02_01_0_0010","CR02_01_0_0011","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("67_idle_rear_right","CR02_01_0_0012","CR02_01_0_0013","CR02_01_0_0014","CR02_01_0_0015","CR02_01_0_0016","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("67_idle_right","CR02_01_0_0017","CR02_01_0_0018","CR02_01_0_0019","CR02_01_0_0020","CR02_01_0_0021","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("67_idle_front_right","CR02_01_0_0022","CR02_01_0_0023","CR02_01_0_0024","CR02_01_0_0025","CR02_01_0_0026","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("67_idle_front","CR02_00_0_0048","CR02_00_0_0049","CR02_00_0_0050","CR02_00_0_0051","CR02_00_0_0052","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("67_idle_front_left","CR02_00_0_0053","CR02_00_0_0054","CR02_00_0_0055","CR02_00_0_0056","CR02_00_0_0057","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("67_idle_left","CR02_00_0_0058","CR02_00_0_0059","CR02_00_0_0060","CR02_01_0_0000","CR02_01_0_0001","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("67_idle_rear_left","CR02_01_0_0002","CR02_01_0_0003","CR02_01_0_0004","CR02_01_0_0005","CR02_01_0_0006","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("67_walking_rear","CR02_00_0_0024","CR02_00_0_0025","CR02_00_0_0026","CR02_00_0_0027","CR02_00_0_0028","CR02_00_0_0029", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("67_walking_rear_right","CR02_00_0_0030","CR02_00_0_0031","CR02_00_0_0032","CR02_00_0_0033","CR02_00_0_0034","CR02_00_0_0035", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("67_walking_right","CR02_00_0_0036","CR02_00_0_0037","CR02_00_0_0038","CR02_00_0_0039","CR02_00_0_0040","CR02_00_0_0041", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("67_walking_front_right","CR02_00_0_0042","CR02_00_0_0043","CR02_00_0_0044","CR02_00_0_0045","CR02_00_0_0046","CR02_00_0_0047", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("67_walking_front","CR02_00_0_0000","CR02_00_0_0001","CR02_00_0_0002","CR02_00_0_0003","CR02_00_0_0004","CR02_00_0_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("67_walking_front_left","CR02_00_0_0006","CR02_00_0_0007","CR02_00_0_0008","CR02_00_0_0009","CR02_00_0_0010","CR02_00_0_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("67_walking_left","CR02_00_0_0012","CR02_00_0_0013","CR02_00_0_0014","CR02_00_0_0015","CR02_00_0_0016","CR02_00_0_0017", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("67_walking_rear_left","CR02_00_0_0018","CR02_00_0_0019","CR02_00_0_0020","CR02_00_0_0021","CR02_00_0_0022","CR02_00_0_0023", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("67_attack_bash","CR02_01_0_0027","CR02_01_0_0028","CR02_01_0_0029","CR02_01_0_0030","CR02_01_0_0029","CR02_01_0_0028", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("67_attack_slash","CR02_01_0_0051","CR02_01_0_0052","CR02_01_0_0053","CR02_01_0_0054","CR02_01_0_0055","CR02_01_0_0056", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("67_attack_thrust","CR02_01_0_0057","CR02_01_0_0058","CR02_02_0_0000","CR02_02_0_0001","CR02_02_0_0002","CR02_02_0_0003", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("67_attack_secondary","CR02_01_0_0057","CR02_01_0_0058","CR02_02_0_0000","CR02_02_0_0001","CR02_02_0_0002","CR02_02_0_0003", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("67_attack_unk","CR02_01_0_0057","CR02_01_0_0058","CR02_02_0_0000","CR02_02_0_0001","CR02_02_0_0002","CR02_02_0_0003", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("67_death","CR02_02_0_0004","CR02_02_0_0005","CR02_02_0_0006","CR02_02_0_0007","CR02_02_0_0008","", 5, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 4 - which is a_giant_grey_rat//Animation #0 idle
				CreateAnimationUW("68_idle_rear","CR02_01_1_0007","CR02_01_1_0008","CR02_01_1_0009","CR02_01_1_0010","CR02_01_1_0011","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("68_idle_rear_right","CR02_01_1_0012","CR02_01_1_0013","CR02_01_1_0014","CR02_01_1_0015","CR02_01_1_0016","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("68_idle_right","CR02_01_1_0017","CR02_01_1_0018","CR02_01_1_0019","CR02_01_1_0020","CR02_01_1_0021","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("68_idle_front_right","CR02_01_1_0022","CR02_01_1_0023","CR02_01_1_0024","CR02_01_1_0025","CR02_01_1_0026","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("68_idle_front","CR02_00_1_0048","CR02_00_1_0049","CR02_00_1_0050","CR02_00_1_0051","CR02_00_1_0052","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("68_idle_front_left","CR02_00_1_0053","CR02_00_1_0054","CR02_00_1_0055","CR02_00_1_0056","CR02_00_1_0057","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("68_idle_left","CR02_00_1_0058","CR02_00_1_0059","CR02_00_1_0060","CR02_01_1_0000","CR02_01_1_0001","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("68_idle_rear_left","CR02_01_1_0002","CR02_01_1_0003","CR02_01_1_0004","CR02_01_1_0005","CR02_01_1_0006","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("68_walking_rear","CR02_00_1_0024","CR02_00_1_0025","CR02_00_1_0026","CR02_00_1_0027","CR02_00_1_0028","CR02_00_1_0029", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("68_walking_rear_right","CR02_00_1_0030","CR02_00_1_0031","CR02_00_1_0032","CR02_00_1_0033","CR02_00_1_0034","CR02_00_1_0035", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("68_walking_right","CR02_00_1_0036","CR02_00_1_0037","CR02_00_1_0038","CR02_00_1_0039","CR02_00_1_0040","CR02_00_1_0041", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("68_walking_front_right","CR02_00_1_0042","CR02_00_1_0043","CR02_00_1_0044","CR02_00_1_0045","CR02_00_1_0046","CR02_00_1_0047", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("68_walking_front","CR02_00_1_0000","CR02_00_1_0001","CR02_00_1_0002","CR02_00_1_0003","CR02_00_1_0004","CR02_00_1_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("68_walking_front_left","CR02_00_1_0006","CR02_00_1_0007","CR02_00_1_0008","CR02_00_1_0009","CR02_00_1_0010","CR02_00_1_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("68_walking_left","CR02_00_1_0012","CR02_00_1_0013","CR02_00_1_0014","CR02_00_1_0015","CR02_00_1_0016","CR02_00_1_0017", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("68_walking_rear_left","CR02_00_1_0018","CR02_00_1_0019","CR02_00_1_0020","CR02_00_1_0021","CR02_00_1_0022","CR02_00_1_0023", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("68_attack_bash","CR02_01_1_0027","CR02_01_1_0028","CR02_01_1_0029","CR02_01_1_0030","CR02_01_1_0029","CR02_01_1_0028", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("68_attack_slash","CR02_01_1_0051","CR02_01_1_0052","CR02_01_1_0053","CR02_01_1_0054","CR02_01_1_0055","CR02_01_1_0056", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("68_attack_thrust","CR02_01_1_0057","CR02_01_1_0058","CR02_02_1_0000","CR02_02_1_0001","CR02_02_1_0002","CR02_02_1_0003", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("68_attack_secondary","CR02_01_1_0057","CR02_01_1_0058","CR02_02_1_0000","CR02_02_1_0001","CR02_02_1_0002","CR02_02_1_0003", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("68_attack_unk","CR02_01_1_0057","CR02_01_1_0058","CR02_02_1_0000","CR02_02_1_0001","CR02_02_1_0002","CR02_02_1_0003", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("68_death","CR02_02_1_0004","CR02_02_1_0005","CR02_02_1_0006","CR02_02_1_0007","CR02_02_1_0008","", 5, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 5 - which is a_flesh_slug//Animation #0 idle
				CreateAnimationUW("69_idle_rear","CR03_00_0_0016","CR03_00_0_0016","CR03_00_0_0016","CR03_00_0_0016","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("69_idle_rear_right","CR03_00_0_0020","CR03_00_0_0020","CR03_00_0_0020","CR03_00_0_0020","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("69_idle_right","CR03_00_0_0024","CR03_00_0_0024","CR03_00_0_0024","CR03_00_0_0024","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("69_idle_front_right","CR03_00_0_0028","CR03_00_0_0028","CR03_00_0_0028","CR03_00_0_0028","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("69_idle_front","CR03_00_0_0000","CR03_00_0_0000","CR03_00_0_0000","CR03_00_0_0000","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("69_idle_front_left","CR03_00_0_0004","CR03_00_0_0004","CR03_00_0_0004","CR03_00_0_0004","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("69_idle_left","CR03_00_0_0008","CR03_00_0_0008","CR03_00_0_0008","CR03_00_0_0008","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("69_idle_rear_left","CR03_00_0_0012","CR03_00_0_0012","CR03_00_0_0012","CR03_00_0_0012","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("69_walking_rear","CR03_00_0_0016","CR03_00_0_0017","CR03_00_0_0018","CR03_00_0_0019","CR03_00_0_0018","CR03_00_0_0017", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("69_walking_rear_right","CR03_00_0_0020","CR03_00_0_0021","CR03_00_0_0022","CR03_00_0_0023","CR03_00_0_0022","CR03_00_0_0021", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("69_walking_right","CR03_00_0_0024","CR03_00_0_0025","CR03_00_0_0026","CR03_00_0_0027","CR03_00_0_0026","CR03_00_0_0025", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("69_walking_front_right","CR03_00_0_0028","CR03_00_0_0029","CR03_00_0_0030","CR03_00_0_0031","CR03_00_0_0030","CR03_00_0_0029", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("69_walking_front","CR03_00_0_0000","CR03_00_0_0001","CR03_00_0_0002","CR03_00_0_0003","CR03_00_0_0002","CR03_00_0_0001", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("69_walking_front_left","CR03_00_0_0004","CR03_00_0_0005","CR03_00_0_0006","CR03_00_0_0007","CR03_00_0_0006","CR03_00_0_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("69_walking_left","CR03_00_0_0008","CR03_00_0_0009","CR03_00_0_0010","CR03_00_0_0011","CR03_00_0_0010","CR03_00_0_0009", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("69_walking_rear_left","CR03_00_0_0012","CR03_00_0_0013","CR03_00_0_0014","CR03_00_0_0015","CR03_00_0_0014","CR03_00_0_0013", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("69_attack_bash","CR03_00_0_0032","CR03_00_0_0035","CR03_00_0_0032","CR03_00_0_0035","CR03_00_0_0032","CR03_00_0_0035", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("69_attack_slash","CR03_00_0_0032","CR03_00_0_0033","CR03_00_0_0034","CR03_00_0_0035","CR03_00_0_0034","CR03_00_0_0033", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("69_attack_thrust","CR03_00_0_0032","CR03_00_0_0033","CR03_00_0_0034","CR03_00_0_0035","CR03_00_0_0034","CR03_00_0_0033", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("69_attack_secondary","CR03_00_0_0032","CR03_00_0_0033","CR03_00_0_0034","CR03_00_0_0035","CR03_00_0_0034","CR03_00_0_0033", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("69_attack_unk","CR03_00_0_0036","CR03_00_0_0037","CR03_00_0_0038","CR03_00_0_0039","CR03_00_0_0038","CR03_00_0_0037", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("69_death","CR03_00_0_0040","CR03_00_0_0041","CR03_00_0_0042","CR03_00_0_0043","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 6 - which is an_acid_slug//Animation #0 idle
				CreateAnimationUW("70_idle_rear","CR03_00_1_0016","CR03_00_1_0016","CR03_00_1_0016","CR03_00_1_0016","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("70_idle_rear_right","CR03_00_1_0020","CR03_00_1_0020","CR03_00_1_0020","CR03_00_1_0020","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("70_idle_right","CR03_00_1_0024","CR03_00_1_0024","CR03_00_1_0024","CR03_00_1_0024","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("70_idle_front_right","CR03_00_1_0028","CR03_00_1_0028","CR03_00_1_0028","CR03_00_1_0028","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("70_idle_front","CR03_00_1_0000","CR03_00_1_0000","CR03_00_1_0000","CR03_00_1_0000","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("70_idle_front_left","CR03_00_1_0004","CR03_00_1_0004","CR03_00_1_0004","CR03_00_1_0004","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("70_idle_left","CR03_00_1_0008","CR03_00_1_0008","CR03_00_1_0008","CR03_00_1_0008","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("70_idle_rear_left","CR03_00_1_0012","CR03_00_1_0012","CR03_00_1_0012","CR03_00_1_0012","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("70_walking_rear","CR03_00_1_0016","CR03_00_1_0017","CR03_00_1_0018","CR03_00_1_0019","CR03_00_1_0018","CR03_00_1_0017", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("70_walking_rear_right","CR03_00_1_0020","CR03_00_1_0021","CR03_00_1_0022","CR03_00_1_0023","CR03_00_1_0022","CR03_00_1_0021", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("70_walking_right","CR03_00_1_0024","CR03_00_1_0025","CR03_00_1_0026","CR03_00_1_0027","CR03_00_1_0026","CR03_00_1_0025", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("70_walking_front_right","CR03_00_1_0028","CR03_00_1_0029","CR03_00_1_0030","CR03_00_1_0031","CR03_00_1_0030","CR03_00_1_0029", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("70_walking_front","CR03_00_1_0000","CR03_00_1_0001","CR03_00_1_0002","CR03_00_1_0003","CR03_00_1_0002","CR03_00_1_0001", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("70_walking_front_left","CR03_00_1_0004","CR03_00_1_0005","CR03_00_1_0006","CR03_00_1_0007","CR03_00_1_0006","CR03_00_1_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("70_walking_left","CR03_00_1_0008","CR03_00_1_0009","CR03_00_1_0010","CR03_00_1_0011","CR03_00_1_0010","CR03_00_1_0009", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("70_walking_rear_left","CR03_00_1_0012","CR03_00_1_0013","CR03_00_1_0014","CR03_00_1_0015","CR03_00_1_0014","CR03_00_1_0013", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("70_attack_bash","CR03_00_1_0032","CR03_00_1_0035","CR03_00_1_0032","CR03_00_1_0035","CR03_00_1_0032","CR03_00_1_0035", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("70_attack_slash","CR03_00_1_0032","CR03_00_1_0033","CR03_00_1_0034","CR03_00_1_0035","CR03_00_1_0034","CR03_00_1_0033", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("70_attack_thrust","CR03_00_1_0032","CR03_00_1_0033","CR03_00_1_0034","CR03_00_1_0035","CR03_00_1_0034","CR03_00_1_0033", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("70_attack_secondary","CR03_00_1_0032","CR03_00_1_0033","CR03_00_1_0034","CR03_00_1_0035","CR03_00_1_0034","CR03_00_1_0033", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("70_attack_unk","CR03_00_1_0036","CR03_00_1_0037","CR03_00_1_0038","CR03_00_1_0039","CR03_00_1_0038","CR03_00_1_0037", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("70_death","CR03_00_1_0040","CR03_00_1_0041","CR03_00_1_0042","CR03_00_1_0043","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 7 - which is a_mongbat//Animation #0 idle
				CreateAnimationUW("71_idle_rear","CR04_00_1_0024","CR04_00_1_0025","CR04_00_1_0026","CR04_00_1_0027","CR04_00_1_0028","CR04_00_1_0029", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("71_idle_rear_right","CR04_00_1_0018","CR04_00_1_0019","CR04_00_1_0020","CR04_00_1_0021","CR04_00_1_0022","CR04_00_1_0023", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("71_idle_right","CR04_00_1_0012","CR04_00_1_0013","CR04_00_1_0014","CR04_00_1_0015","CR04_00_1_0016","CR04_00_1_0017", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("71_idle_front_right","CR04_00_1_0006","CR04_00_1_0007","CR04_00_1_0008","CR04_00_1_0009","CR04_00_1_0010","CR04_00_1_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("71_idle_front","CR04_00_1_0000","CR04_00_1_0001","CR04_00_1_0002","CR04_00_1_0003","CR04_00_1_0004","CR04_00_1_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("71_idle_front_left","CR04_00_1_0042","CR04_00_1_0043","CR04_00_1_0044","CR04_00_1_0045","CR04_00_1_0046","CR04_00_1_0047", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("71_idle_left","CR04_00_1_0036","CR04_00_1_0037","CR04_00_1_0038","CR04_00_1_0039","CR04_00_1_0040","CR04_00_1_0041", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("71_idle_rear_left","CR04_00_1_0030","CR04_00_1_0031","CR04_00_1_0032","CR04_00_1_0033","CR04_00_1_0034","CR04_00_1_0035", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("71_walking_rear","CR04_00_1_0024","CR04_00_1_0025","CR04_00_1_0026","CR04_00_1_0027","CR04_00_1_0028","CR04_00_1_0029", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("71_walking_rear_right","CR04_00_1_0018","CR04_00_1_0019","CR04_00_1_0020","CR04_00_1_0021","CR04_00_1_0022","CR04_00_1_0023", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("71_walking_right","CR04_00_1_0012","CR04_00_1_0013","CR04_00_1_0014","CR04_00_1_0015","CR04_00_1_0016","CR04_00_1_0017", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("71_walking_front_right","CR04_00_1_0006","CR04_00_1_0007","CR04_00_1_0008","CR04_00_1_0009","CR04_00_1_0010","CR04_00_1_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("71_walking_front","CR04_00_1_0000","CR04_00_1_0001","CR04_00_1_0002","CR04_00_1_0003","CR04_00_1_0004","CR04_00_1_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("71_walking_front_left","CR04_00_1_0042","CR04_00_1_0043","CR04_00_1_0044","CR04_00_1_0045","CR04_00_1_0046","CR04_00_1_0047", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("71_walking_left","CR04_00_1_0036","CR04_00_1_0037","CR04_00_1_0038","CR04_00_1_0039","CR04_00_1_0040","CR04_00_1_0041", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("71_walking_rear_left","CR04_00_1_0030","CR04_00_1_0031","CR04_00_1_0032","CR04_00_1_0033","CR04_00_1_0034","CR04_00_1_0035", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("71_attack_bash","CR04_00_1_0048","CR04_00_1_0049","CR04_00_1_0050","CR04_00_1_0051","CR04_00_1_0048","CR04_00_1_0052", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("71_attack_slash","CR04_00_1_0053","CR04_00_1_0054","CR04_00_1_0055","CR04_00_1_0056","CR04_00_1_0057","CR04_00_1_0058", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("71_attack_thrust","CR04_00_1_0059","CR04_00_1_0060","CR04_00_1_0061","CR04_00_1_0062","CR04_00_1_0063","CR04_00_1_0064", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("71_attack_secondary","CR04_01_1_0000","CR04_01_1_0001","CR04_01_1_0002","CR04_01_1_0003","CR04_01_1_0004","CR04_01_1_0005", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("71_attack_unk","CR04_01_1_0000","CR04_01_1_0001","CR04_01_1_0002","CR04_01_1_0003","CR04_01_1_0004","CR04_01_1_0005", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("71_death","CR04_01_1_0006","CR04_01_1_0007","CR04_01_1_0008","CR04_01_1_0009","CR04_01_1_0010","CR04_01_1_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 8 - which is a_skeleton//Animation #0 idle
				CreateAnimationUW("72_idle_rear","CR05_00_0_0029","CR05_00_0_0029","CR05_00_0_0029","CR05_00_0_0029","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("72_idle_rear_right","CR05_00_0_0031","CR05_00_0_0031","CR05_00_0_0031","CR05_00_0_0031","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("72_idle_right","CR05_00_0_0037","CR05_00_0_0037","CR05_00_0_0037","CR05_00_0_0037","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("72_idle_front_right","CR05_01_0_0001","CR05_01_0_0001","CR05_01_0_0001","CR05_01_0_0001","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("72_idle_front","CR05_01_0_0004","CR05_01_0_0005","CR05_01_0_0006","CR05_01_0_0007","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("72_idle_front_left","CR05_00_0_0010","CR05_00_0_0010","CR05_00_0_0010","CR05_00_0_0010","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("72_idle_left","CR05_00_0_0013","CR05_00_0_0013","CR05_00_0_0013","CR05_00_0_0013","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("72_idle_rear_left","CR05_00_0_0019","CR05_00_0_0019","CR05_00_0_0019","CR05_00_0_0019","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("72_walking_rear","CR05_00_0_0025","CR05_00_0_0026","CR05_00_0_0027","CR05_00_0_0028","CR05_00_0_0029","CR05_00_0_0030", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("72_walking_rear_right","CR05_00_0_0031","CR05_00_0_0032","CR05_00_0_0033","CR05_00_0_0034","CR05_00_0_0035","CR05_00_0_0036", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("72_walking_right","CR05_00_0_0037","CR05_00_0_0038","CR05_00_0_0039","CR05_00_0_0040","CR05_00_0_0041","CR05_00_0_0042", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("72_walking_front_right","CR05_00_0_0043","CR05_00_0_0044","CR05_01_0_0000","CR05_01_0_0001","CR05_01_0_0002","CR05_01_0_0003", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("72_walking_front","CR05_00_0_0001","CR05_00_0_0002","CR05_00_0_0003","CR05_00_0_0004","CR05_00_0_0005","CR05_00_0_0006", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("72_walking_front_left","CR05_00_0_0007","CR05_00_0_0008","CR05_00_0_0009","CR05_00_0_0010","CR05_00_0_0011","CR05_00_0_0012", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("72_walking_left","CR05_00_0_0013","CR05_00_0_0014","CR05_00_0_0015","CR05_00_0_0016","CR05_00_0_0017","CR05_00_0_0018", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("72_walking_rear_left","CR05_00_0_0019","CR05_00_0_0020","CR05_00_0_0021","CR05_00_0_0022","CR05_00_0_0023","CR05_00_0_0024", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("72_attack_bash","CR05_01_0_0010","CR05_01_0_0011","CR05_01_0_0012","CR05_01_0_0011","CR05_01_0_0012","CR05_01_0_0011", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("72_attack_slash","CR05_01_0_0015","CR05_01_0_0016","CR05_01_0_0017","CR05_01_0_0018","CR05_01_0_0019","CR05_01_0_0018", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("72_attack_thrust","CR05_01_0_0015","CR05_01_0_0016","CR05_01_0_0017","CR05_01_0_0018","CR05_01_0_0019","CR05_01_0_0018", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("72_attack_secondary","CR05_01_0_0015","CR05_01_0_0016","CR05_01_0_0017","CR05_01_0_0018","CR05_01_0_0019","CR05_01_0_0018", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("72_attack_unk","CR05_01_0_0014","CR05_01_0_0015","CR05_01_0_0016","CR05_01_0_0017","CR05_01_0_0018","CR05_01_0_0019", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("72_death","CR05_01_0_0020","CR05_01_0_0021","CR05_01_0_0022","CR05_01_0_0023","CR05_01_0_0024","CR05_01_0_0025", 6, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 9 - which is a_goblin//Animation #0 idle
				CreateAnimationUW("73_idle_rear","CR06_00_0_0029","CR06_00_0_0029","CR06_00_0_0029","CR06_00_0_0029","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("73_idle_rear_right","CR06_00_0_0033","CR06_00_0_0033","CR06_00_0_0033","CR06_00_0_0033","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("73_idle_right","CR06_01_0_0004","CR06_01_0_0004","CR06_01_0_0004","CR06_01_0_0004","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("73_idle_front_right","CR06_01_0_0012","CR06_01_0_0012","CR06_01_0_0012","CR06_01_0_0012","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("73_idle_front","CR06_01_0_0014","CR06_01_0_0015","CR06_01_0_0014","CR06_01_0_0016","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("73_idle_front_left","CR06_00_0_0008","CR06_00_0_0008","CR06_00_0_0008","CR06_00_0_0008","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("73_idle_left","CR06_00_0_0012","CR06_00_0_0012","CR06_00_0_0012","CR06_00_0_0012","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("73_idle_rear_left","CR06_00_0_0021","CR06_00_0_0021","CR06_00_0_0021","CR06_00_0_0021","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("73_walking_rear","CR06_00_0_0024","CR06_00_0_0025","CR06_00_0_0026","CR06_00_0_0027","CR06_00_0_0028","CR06_00_0_0029", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("73_walking_rear_right","CR06_00_0_0031","CR06_00_0_0032","CR06_00_0_0033","CR06_01_0_0000","CR06_01_0_0001","CR06_01_0_0001", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("73_walking_right","CR06_01_0_0002","CR06_01_0_0003","CR06_01_0_0004","CR06_01_0_0005","CR06_01_0_0006","CR06_01_0_0007", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("73_walking_front_right","CR06_01_0_0008","CR06_01_0_0009","CR06_01_0_0010","CR06_01_0_0011","CR06_01_0_0012","CR06_01_0_0013", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("73_walking_front","CR06_00_0_0000","CR06_00_0_0001","CR06_00_0_0002","CR06_00_0_0003","CR06_00_0_0004","CR06_00_0_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("73_walking_front_left","CR06_00_0_0006","CR06_00_0_0007","CR06_00_0_0008","CR06_00_0_0009","CR06_00_0_0010","CR06_00_0_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("73_walking_left","CR06_00_0_0012","CR06_00_0_0013","CR06_00_0_0014","CR06_00_0_0015","CR06_00_0_0016","CR06_00_0_0017", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("73_walking_rear_left","CR06_00_0_0018","CR06_00_0_0019","CR06_00_0_0020","CR06_00_0_0021","CR06_00_0_0022","CR06_00_0_0023", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("73_attack_bash","CR06_01_0_0017","CR06_01_0_0018","CR06_01_0_0019","CR06_01_0_0020","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("73_attack_slash","CR06_01_0_0022","CR06_01_0_0023","CR06_01_0_0024","CR06_01_0_0025","CR06_01_0_0026","CR06_01_0_0027", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("73_attack_thrust","CR06_01_0_0022","CR06_01_0_0023","CR06_01_0_0024","CR06_01_0_0025","CR06_01_0_0026","CR06_01_0_0027", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("73_attack_secondary","CR06_01_0_0022","CR06_01_0_0023","CR06_01_0_0024","CR06_01_0_0025","CR06_01_0_0026","CR06_01_0_0027", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("73_attack_unk","CR06_01_0_0022","CR06_01_0_0023","CR06_01_0_0024","CR06_01_0_0025","CR06_01_0_0026","CR06_01_0_0027", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("73_death","CR06_01_0_0028","CR06_01_0_0029","CR06_01_0_0030","CR06_01_0_0031","CR06_01_0_0032","CR06_02_0_0000", 6, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 10 - which is a_goblin//Animation #0 idle
				CreateAnimationUW("74_idle_rear","CR07_00_0_0027","CR07_00_0_0027","CR07_00_0_0027","CR07_00_0_0027","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("74_idle_rear_right","CR07_01_0_0001","CR07_01_0_0001","CR07_01_0_0001","CR07_01_0_0001","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("74_idle_right","CR07_01_0_0004","CR07_01_0_0004","CR07_01_0_0004","CR07_01_0_0004","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("74_idle_front_right","CR07_01_0_0010","CR07_01_0_0010","CR07_01_0_0010","CR07_01_0_0010","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("74_idle_front","CR07_01_0_0014","CR07_01_0_0015","CR07_01_0_0014","CR07_01_0_0016","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("74_idle_front_left","CR07_00_0_0008","CR07_00_0_0008","CR07_00_0_0008","CR07_00_0_0008","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("74_idle_left","CR07_00_0_0014","CR07_00_0_0014","CR07_00_0_0014","CR07_00_0_0014","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("74_idle_rear_left","CR07_00_0_0022","CR07_00_0_0022","CR07_00_0_0022","CR07_00_0_0022","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("74_walking_rear","CR07_00_0_0024","CR07_00_0_0025","CR07_00_0_0026","CR07_00_0_0027","CR07_00_0_0028","CR07_00_0_0029", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("74_walking_rear_right","CR07_00_0_0030","CR07_00_0_0031","CR07_00_0_0032","CR07_00_0_0033","CR07_01_0_0000","CR07_01_0_0001", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("74_walking_right","CR07_01_0_0002","CR07_01_0_0003","CR07_01_0_0004","CR07_01_0_0005","CR07_01_0_0006","CR07_01_0_0007", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("74_walking_front_right","CR07_01_0_0008","CR07_01_0_0009","CR07_01_0_0010","CR07_01_0_0011","CR07_01_0_0012","CR07_01_0_0013", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("74_walking_front","CR07_00_0_0000","CR07_00_0_0001","CR07_00_0_0002","CR07_00_0_0003","CR07_00_0_0004","CR07_00_0_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("74_walking_front_left","CR07_00_0_0006","CR07_00_0_0007","CR07_00_0_0008","CR07_00_0_0009","CR07_00_0_0010","CR07_00_0_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("74_walking_left","CR07_00_0_0012","CR07_00_0_0013","CR07_00_0_0014","CR07_00_0_0015","CR07_00_0_0016","CR07_00_0_0017", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("74_walking_rear_left","CR07_00_0_0018","CR07_00_0_0019","CR07_00_0_0020","CR07_00_0_0021","CR07_00_0_0022","CR07_00_0_0023", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("74_attack_bash","CR07_01_0_0017","CR07_01_0_0018","CR07_01_0_0019","CR07_01_0_0020","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("74_attack_slash","CR07_01_0_0022","CR07_01_0_0023","CR07_01_0_0024","CR07_01_0_0025","CR07_01_0_0026","CR07_01_0_0027", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("74_attack_thrust","CR07_01_0_0021","CR07_01_0_0022","CR07_01_0_0023","CR07_01_0_0024","CR07_01_0_0025","CR07_01_0_0027", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("74_attack_secondary","CR07_01_0_0021","CR07_01_0_0022","CR07_01_0_0023","CR07_01_0_0024","CR07_01_0_0025","CR07_01_0_0027", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("74_attack_unk","CR07_01_0_0021","CR07_01_0_0022","CR07_01_0_0023","CR07_01_0_0024","CR07_01_0_0025","CR07_01_0_0027", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("74_death","CR07_01_0_0028","CR07_01_0_0029","CR07_01_0_0030","CR07_01_0_0031","CR07_01_0_0032","CR07_02_0_0000", 6, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 11 - which is an_imp//Animation #0 idle
				CreateAnimationUW("75_idle_rear","CR04_00_0_0024","CR04_00_0_0025","CR04_00_0_0026","CR04_00_0_0027","CR04_00_0_0028","CR04_00_0_0029", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("75_idle_rear_right","CR04_00_0_0018","CR04_00_0_0019","CR04_00_0_0020","CR04_00_0_0021","CR04_00_0_0022","CR04_00_0_0023", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("75_idle_right","CR04_00_0_0012","CR04_00_0_0013","CR04_00_0_0014","CR04_00_0_0015","CR04_00_0_0016","CR04_00_0_0017", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("75_idle_front_right","CR04_00_0_0006","CR04_00_0_0007","CR04_00_0_0008","CR04_00_0_0009","CR04_00_0_0010","CR04_00_0_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("75_idle_front","CR04_00_0_0000","CR04_00_0_0001","CR04_00_0_0002","CR04_00_0_0003","CR04_00_0_0004","CR04_00_0_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("75_idle_front_left","CR04_00_0_0042","CR04_00_0_0043","CR04_00_0_0044","CR04_00_0_0045","CR04_00_0_0046","CR04_00_0_0047", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("75_idle_left","CR04_00_0_0036","CR04_00_0_0037","CR04_00_0_0038","CR04_00_0_0039","CR04_00_0_0040","CR04_00_0_0041", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("75_idle_rear_left","CR04_00_0_0030","CR04_00_0_0031","CR04_00_0_0032","CR04_00_0_0033","CR04_00_0_0034","CR04_00_0_0035", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("75_walking_rear","CR04_00_0_0024","CR04_00_0_0025","CR04_00_0_0026","CR04_00_0_0027","CR04_00_0_0028","CR04_00_0_0029", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("75_walking_rear_right","CR04_00_0_0018","CR04_00_0_0019","CR04_00_0_0020","CR04_00_0_0021","CR04_00_0_0022","CR04_00_0_0023", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("75_walking_right","CR04_00_0_0012","CR04_00_0_0013","CR04_00_0_0014","CR04_00_0_0015","CR04_00_0_0016","CR04_00_0_0017", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("75_walking_front_right","CR04_00_0_0006","CR04_00_0_0007","CR04_00_0_0008","CR04_00_0_0009","CR04_00_0_0010","CR04_00_0_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("75_walking_front","CR04_00_0_0000","CR04_00_0_0001","CR04_00_0_0002","CR04_00_0_0003","CR04_00_0_0004","CR04_00_0_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("75_walking_front_left","CR04_00_0_0042","CR04_00_0_0043","CR04_00_0_0044","CR04_00_0_0045","CR04_00_0_0046","CR04_00_0_0047", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("75_walking_left","CR04_00_0_0036","CR04_00_0_0037","CR04_00_0_0038","CR04_00_0_0039","CR04_00_0_0040","CR04_00_0_0041", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("75_walking_rear_left","CR04_00_0_0030","CR04_00_0_0031","CR04_00_0_0032","CR04_00_0_0033","CR04_00_0_0034","CR04_00_0_0035", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("75_attack_bash","CR04_00_0_0048","CR04_00_0_0049","CR04_00_0_0050","CR04_00_0_0051","CR04_00_0_0048","CR04_00_0_0052", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("75_attack_slash","CR04_00_0_0053","CR04_00_0_0054","CR04_00_0_0055","CR04_00_0_0056","CR04_00_0_0057","CR04_00_0_0058", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("75_attack_thrust","CR04_00_0_0059","CR04_00_0_0060","CR04_00_0_0061","CR04_00_0_0062","CR04_00_0_0063","CR04_00_0_0064", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("75_attack_secondary","CR04_01_0_0000","CR04_01_0_0001","CR04_01_0_0002","CR04_01_0_0003","CR04_01_0_0004","CR04_01_0_0005", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("75_attack_unk","CR04_01_0_0000","CR04_01_0_0001","CR04_01_0_0002","CR04_01_0_0003","CR04_01_0_0004","CR04_01_0_0005", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("75_death","CR04_01_0_0006","CR04_01_0_0007","CR04_01_0_0008","CR04_01_0_0009","CR04_01_0_0010","CR04_01_0_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 12 - which is a_giant_spider//Animation #0 idle
				CreateAnimationUW("76_idle_rear","CR10_00_0_0006","CR10_00_0_0006","CR10_00_0_0006","CR10_00_0_0006","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("76_idle_rear_right","CR10_01_0_0000","CR10_01_0_0000","CR10_01_0_0000","CR10_01_0_0000","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("76_idle_right","CR10_00_0_0014","CR10_00_0_0014","CR10_00_0_0014","CR10_00_0_0014","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("76_idle_front_right","CR10_00_0_0018","CR10_00_0_0018","CR10_00_0_0018","CR10_00_0_0018","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("76_idle_front","CR10_00_0_0002","CR10_00_0_0002","CR10_00_0_0002","CR10_00_0_0002","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("76_idle_front_left","CR10_00_0_0022","CR10_00_0_0022","CR10_00_0_0022","CR10_00_0_0022","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("76_idle_left","CR10_00_0_0010","CR10_00_0_0010","CR10_00_0_0010","CR10_00_0_0010","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("76_idle_rear_left","CR10_01_0_0004","CR10_01_0_0004","CR10_01_0_0004","CR10_01_0_0004","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("76_walking_rear","CR10_00_0_0004","CR10_00_0_0005","CR10_00_0_0006","CR10_00_0_0007","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("76_walking_rear_right","CR10_00_0_0024","CR10_00_0_0025","CR10_01_0_0000","CR10_01_0_0001","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("76_walking_right","CR10_00_0_0012","CR10_00_0_0013","CR10_00_0_0014","CR10_00_0_0015","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("76_walking_front_right","CR10_00_0_0016","CR10_00_0_0017","CR10_00_0_0018","CR10_00_0_0019","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("76_walking_front","CR10_00_0_0000","CR10_00_0_0001","CR10_00_0_0002","CR10_00_0_0003","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("76_walking_front_left","CR10_00_0_0020","CR10_00_0_0021","CR10_00_0_0022","CR10_00_0_0023","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("76_walking_left","CR10_00_0_0008","CR10_00_0_0009","CR10_00_0_0010","CR10_00_0_0011","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("76_walking_rear_left","CR10_01_0_0002","CR10_01_0_0003","CR10_01_0_0004","CR10_01_0_0005","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("76_attack_bash","CR10_01_0_0008","CR10_01_0_0009","CR10_01_0_0010","CR10_01_0_0011","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("76_attack_slash","CR10_01_0_0012","CR10_01_0_0013","CR10_01_0_0014","CR10_01_0_0015","CR10_01_0_0016","CR10_01_0_0014", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("76_attack_thrust","CR10_01_0_0012","CR10_01_0_0013","CR10_01_0_0014","CR10_01_0_0015","CR10_01_0_0016","CR10_01_0_0014", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("76_attack_secondary","CR10_01_0_0012","CR10_01_0_0013","CR10_01_0_0014","CR10_01_0_0015","CR10_01_0_0016","CR10_01_0_0014", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("76_attack_unk","CR10_01_0_0012","CR10_01_0_0013","CR10_01_0_0014","CR10_01_0_0015","CR10_01_0_0016","CR10_01_0_0014", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("76_death","CR10_01_0_0017","CR10_01_0_0018","CR10_01_0_0019","CR10_01_0_0020","CR10_01_0_0021","CR10_01_0_0022", 6, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 13 - which is a_lurker//Animation #0 idle
				CreateAnimationUW("77_idle_rear","CR11_00_0_0046","CR11_00_0_0047","CR11_00_0_0047","CR11_00_0_0046","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("77_idle_rear_right","CR11_00_0_0044","CR11_00_0_0045","CR11_00_0_0045","CR11_00_0_0044","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("77_idle_right","CR11_00_0_0040","CR11_00_0_0041","CR11_00_0_0042","CR11_00_0_0043","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("77_idle_front_right","CR11_00_0_0036","CR11_00_0_0037","CR11_00_0_0038","CR11_00_0_0039","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("77_idle_front","CR11_00_0_0032","CR11_00_0_0033","CR11_00_0_0034","CR11_00_0_0035","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("77_idle_front_left","CR11_00_0_0054","CR11_00_0_0055","CR11_00_0_0056","CR11_00_0_0057","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("77_idle_left","CR11_00_0_0050","CR11_00_0_0051","CR11_00_0_0052","CR11_00_0_0053","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("77_idle_rear_left","CR11_00_0_0048","CR11_00_0_0049","CR11_00_0_0049","CR11_00_0_0048","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("77_walking_rear","CR11_00_0_0016","CR11_00_0_0017","CR11_00_0_0018","CR11_00_0_0019","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("77_walking_rear_right","CR11_00_0_0012","CR11_00_0_0013","CR11_00_0_0014","CR11_00_0_0015","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("77_walking_right","CR11_00_0_0008","CR11_00_0_0009","CR11_00_0_0010","CR11_00_0_0011","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("77_walking_front_right","CR11_00_0_0004","CR11_00_0_0005","CR11_00_0_0006","CR11_00_0_0007","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("77_walking_front","CR11_00_0_0000","CR11_00_0_0001","CR11_00_0_0002","CR11_00_0_0003","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("77_walking_front_left","CR11_00_0_0028","CR11_00_0_0029","CR11_00_0_0030","CR11_00_0_0031","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("77_walking_left","CR11_00_0_0024","CR11_00_0_0025","CR11_00_0_0026","CR11_00_0_0027","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("77_walking_rear_left","CR11_00_0_0020","CR11_00_0_0021","CR11_00_0_0022","CR11_00_0_0023","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("77_attack_bash","CR11_00_0_0062","CR11_00_0_0063","CR11_00_0_0064","CR11_00_0_0065","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("77_attack_slash","CR11_00_0_0068","CR11_00_0_0066","CR11_00_0_0067","CR11_00_0_0069","CR11_00_0_0070","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("77_attack_thrust","CR11_00_0_0071","CR11_00_0_0072","CR11_00_0_0073","CR11_00_0_0074","CR11_00_0_0075","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("77_attack_secondary","CR11_00_0_0076","CR11_00_0_0077","CR11_00_0_0078","CR11_00_0_0079","CR11_00_0_0080","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("77_attack_unk","CR11_00_0_0076","CR11_00_0_0077","CR11_00_0_0078","CR11_00_0_0079","CR11_00_0_0080","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("77_death","CR11_00_0_0058","CR11_00_0_0059","CR11_00_0_0060","CR11_00_0_0061","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 14 - which is a_bloodworm//Animation #0 idle
				CreateAnimationUW("78_idle_rear","CR00_00_1_0018","CR00_00_1_0018","CR00_00_1_0018","CR00_00_1_0018","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("78_idle_rear_right","CR00_00_1_0020","CR00_00_1_0020","CR00_00_1_0020","CR00_00_1_0020","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("78_idle_right","CR00_00_1_0024","CR00_00_1_0024","CR00_00_1_0024","CR00_00_1_0024","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("78_idle_front_right","CR00_00_1_0031","CR00_00_1_0031","CR00_00_1_0031","CR00_00_1_0031","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("78_idle_front","CR00_00_1_0000","CR00_00_1_0000","CR00_00_1_0000","CR00_00_1_0000","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("78_idle_front_left","CR00_00_1_0007","CR00_00_1_0007","CR00_00_1_0007","CR00_00_1_0007","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("78_idle_left","CR00_00_1_0008","CR00_00_1_0008","CR00_00_1_0008","CR00_00_1_0008","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("78_idle_rear_left","CR00_00_1_0014","CR00_00_1_0014","CR00_00_1_0014","CR00_00_1_0014","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("78_walking_rear","CR00_00_1_0016","CR00_00_1_0017","CR00_00_1_0018","CR00_00_1_0019","CR00_00_1_0018","CR00_00_1_0017", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("78_walking_rear_right","CR00_00_1_0020","CR00_00_1_0021","CR00_00_1_0022","CR00_00_1_0023","CR00_00_1_0022","CR00_00_1_0021", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("78_walking_right","CR00_00_1_0024","CR00_00_1_0025","CR00_00_1_0026","CR00_00_1_0027","CR00_00_1_0026","CR00_00_1_0025", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("78_walking_front_right","CR00_00_1_0028","CR00_00_1_0029","CR00_00_1_0030","CR00_00_1_0031","CR00_00_1_0030","CR00_00_1_0029", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("78_walking_front","CR00_00_1_0000","CR00_00_1_0001","CR00_00_1_0002","CR00_00_1_0003","CR00_00_1_0002","CR00_00_1_0001", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("78_walking_front_left","CR00_00_1_0004","CR00_00_1_0005","CR00_00_1_0006","CR00_00_1_0007","CR00_00_1_0006","CR00_00_1_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("78_walking_left","CR00_00_1_0008","CR00_00_1_0009","CR00_00_1_0010","CR00_00_1_0011","CR00_00_1_0010","CR00_00_1_0009", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("78_walking_rear_left","CR00_00_1_0012","CR00_00_1_0013","CR00_00_1_0014","CR00_00_1_0015","CR00_00_1_0014","CR00_00_1_0013", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("78_attack_bash","CR00_00_1_0000","CR00_00_1_0001","CR00_00_1_0002","CR00_00_1_0003","CR00_00_1_0002","CR00_00_1_0001", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("78_attack_slash","CR00_00_1_0032","CR00_00_1_0033","CR00_00_1_0034","CR00_00_1_0035","CR00_00_1_0034","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("78_attack_thrust","CR00_00_1_0032","CR00_00_1_0033","CR00_00_1_0034","CR00_00_1_0034","CR00_00_1_0035","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("78_attack_secondary","CR00_00_1_0032","CR00_00_1_0033","CR00_00_1_0034","CR00_00_1_0034","CR00_00_1_0035","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("78_attack_unk","CR00_00_1_0032","CR00_00_1_0033","CR00_00_1_0034","CR00_00_1_0034","CR00_00_1_0035","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("78_death","CR00_00_1_0036","CR00_00_1_0037","CR00_00_1_0038","","","", 3, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 15 - which is a_stickman//Animation #0 idle
				CreateAnimationUW("79_idle_rear","CR34_00_0_0004","CR34_00_0_0005","CR34_00_0_0006","CR34_00_0_0007","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("79_idle_rear_right","CR34_00_0_0024","CR34_00_0_0025","CR34_00_0_0026","CR34_00_0_0027","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("79_idle_right","CR34_00_0_0012","CR34_00_0_0013","CR34_00_0_0014","CR34_00_0_0015","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("79_idle_front_right","CR34_00_0_0020","CR34_00_0_0021","CR34_00_0_0022","CR34_00_0_0023","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("79_idle_front","CR34_00_0_0000","CR34_00_0_0001","CR34_00_0_0002","CR34_00_0_0003","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("79_idle_front_left","CR34_00_0_0016","CR34_00_0_0017","CR34_00_0_0018","CR34_00_0_0019","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("79_idle_left","CR34_00_0_0008","CR34_00_0_0009","CR34_00_0_0010","CR34_00_0_0011","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("79_idle_rear_left","CR34_00_0_0028","CR34_00_0_0029","CR34_00_0_0030","CR34_00_0_0031","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("79_walking_rear","CR34_00_0_0004","CR34_00_0_0005","CR34_00_0_0006","CR34_00_0_0007","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("79_walking_rear_right","CR34_00_0_0024","CR34_00_0_0025","CR34_00_0_0026","CR34_00_0_0027","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("79_walking_right","CR34_00_0_0012","CR34_00_0_0013","CR34_00_0_0014","CR34_00_0_0015","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("79_walking_front_right","CR34_00_0_0020","CR34_00_0_0021","CR34_00_0_0022","CR34_00_0_0023","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("79_walking_front","CR34_00_0_0000","CR34_00_0_0001","CR34_00_0_0002","CR34_00_0_0003","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("79_walking_front_left","CR34_00_0_0016","CR34_00_0_0017","CR34_00_0_0018","CR34_00_0_0019","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("79_walking_left","CR34_00_0_0008","CR34_00_0_0009","CR34_00_0_0010","CR34_00_0_0011","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("79_walking_rear_left","CR34_00_0_0028","CR34_00_0_0029","CR34_00_0_0030","CR34_00_0_0031","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("79_attack_bash","CR34_00_0_0000","CR34_00_0_0001","CR34_00_0_0002","CR34_00_0_0003","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("79_attack_slash","CR34_00_0_0000","CR34_00_0_0001","CR34_00_0_0002","CR34_00_0_0003","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("79_attack_thrust","CR34_00_0_0000","CR34_00_0_0001","CR34_00_0_0002","CR34_00_0_0003","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("79_attack_secondary","CR34_00_0_0000","CR34_00_0_0001","CR34_00_0_0002","CR34_00_0_0003","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("79_attack_unk","CR34_00_0_0000","CR34_00_0_0001","CR34_00_0_0002","CR34_00_0_0003","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("79_death","CR34_00_0_0046","CR34_00_0_0047","CR34_00_0_0048","CR34_00_0_0049","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 16 - which is a_white_worm//Animation #0 idle
				CreateAnimationUW("80_idle_rear","CR00_00_2_0018","CR00_00_2_0018","CR00_00_2_0018","CR00_00_2_0018","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("80_idle_rear_right","CR00_00_2_0020","CR00_00_2_0020","CR00_00_2_0020","CR00_00_2_0020","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("80_idle_right","CR00_00_2_0024","CR00_00_2_0024","CR00_00_2_0024","CR00_00_2_0024","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("80_idle_front_right","CR00_00_2_0031","CR00_00_2_0031","CR00_00_2_0031","CR00_00_2_0031","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("80_idle_front","CR00_00_2_0000","CR00_00_2_0000","CR00_00_2_0000","CR00_00_2_0000","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("80_idle_front_left","CR00_00_2_0007","CR00_00_2_0007","CR00_00_2_0007","CR00_00_2_0007","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("80_idle_left","CR00_00_2_0008","CR00_00_2_0008","CR00_00_2_0008","CR00_00_2_0008","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("80_idle_rear_left","CR00_00_2_0014","CR00_00_2_0014","CR00_00_2_0014","CR00_00_2_0014","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("80_walking_rear","CR00_00_2_0016","CR00_00_2_0017","CR00_00_2_0018","CR00_00_2_0019","CR00_00_2_0018","CR00_00_2_0017", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("80_walking_rear_right","CR00_00_2_0020","CR00_00_2_0021","CR00_00_2_0022","CR00_00_2_0023","CR00_00_2_0022","CR00_00_2_0021", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("80_walking_right","CR00_00_2_0024","CR00_00_2_0025","CR00_00_2_0026","CR00_00_2_0027","CR00_00_2_0026","CR00_00_2_0025", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("80_walking_front_right","CR00_00_2_0028","CR00_00_2_0029","CR00_00_2_0030","CR00_00_2_0031","CR00_00_2_0030","CR00_00_2_0029", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("80_walking_front","CR00_00_2_0000","CR00_00_2_0001","CR00_00_2_0002","CR00_00_2_0003","CR00_00_2_0002","CR00_00_2_0001", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("80_walking_front_left","CR00_00_2_0004","CR00_00_2_0005","CR00_00_2_0006","CR00_00_2_0007","CR00_00_2_0006","CR00_00_2_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("80_walking_left","CR00_00_2_0008","CR00_00_2_0009","CR00_00_2_0010","CR00_00_2_0011","CR00_00_2_0010","CR00_00_2_0009", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("80_walking_rear_left","CR00_00_2_0012","CR00_00_2_0013","CR00_00_2_0014","CR00_00_2_0015","CR00_00_2_0014","CR00_00_2_0013", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("80_attack_bash","CR00_00_2_0000","CR00_00_2_0001","CR00_00_2_0002","CR00_00_2_0003","CR00_00_2_0002","CR00_00_2_0001", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("80_attack_slash","CR00_00_2_0032","CR00_00_2_0033","CR00_00_2_0034","CR00_00_2_0035","CR00_00_2_0034","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("80_attack_thrust","CR00_00_2_0032","CR00_00_2_0033","CR00_00_2_0034","CR00_00_2_0034","CR00_00_2_0035","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("80_attack_secondary","CR00_00_2_0032","CR00_00_2_0033","CR00_00_2_0034","CR00_00_2_0034","CR00_00_2_0035","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("80_attack_unk","CR00_00_2_0032","CR00_00_2_0033","CR00_00_2_0034","CR00_00_2_0034","CR00_00_2_0035","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("80_death","CR00_00_2_0036","CR00_00_2_0037","CR00_00_2_0038","","","", 3, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 17 - which is a_snow_cat//Animation #0 idle
				CreateAnimationUW("81_idle_rear","CR12_00_0_0012","CR12_00_0_0013","CR12_00_0_0014","CR12_00_0_0013","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("81_idle_rear_right","CR12_00_0_0015","CR12_00_0_0016","CR12_00_0_0017","CR12_00_0_0016","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("81_idle_right","CR12_00_0_0018","CR12_00_0_0019","CR12_00_0_0020","CR12_00_0_0019","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("81_idle_front_right","CR12_00_0_0021","CR12_00_0_0022","CR12_00_0_0023","CR12_00_0_0022","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("81_idle_front","CR12_00_0_0000","CR12_00_0_0001","CR12_00_0_0002","CR12_00_0_0001","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("81_idle_front_left","CR12_00_0_0003","CR12_00_0_0004","CR12_00_0_0005","CR12_00_0_0004","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("81_idle_left","CR12_00_0_0006","CR12_00_0_0007","CR12_00_0_0008","CR12_00_0_0007","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("81_idle_rear_left","CR12_00_0_0009","CR12_00_0_0010","CR12_00_0_0011","CR12_00_0_0010","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("81_walking_rear","CR12_01_0_0008","CR12_01_0_0009","CR12_01_0_0010","CR12_01_0_0011","CR12_01_0_0012","CR12_01_0_0013", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("81_walking_rear_right","CR12_01_0_0014","CR12_01_0_0015","CR12_01_0_0016","CR12_01_0_0017","CR12_01_0_0018","CR12_01_0_0019", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("81_walking_right","CR12_01_0_0020","CR12_01_0_0021","CR12_01_0_0022","CR12_01_0_0023","CR12_01_0_0024","CR12_01_0_0025", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("81_walking_front_right","CR12_01_0_0026","CR12_01_0_0027","CR12_01_0_0028","CR12_01_0_0029","CR12_01_0_0030","CR12_01_0_0031", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("81_walking_front","CR12_00_0_0024","CR12_00_0_0025","CR12_00_0_0026","CR12_00_0_0027","CR12_00_0_0028","CR12_00_0_0029", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("81_walking_front_left","CR12_00_0_0030","CR12_00_0_0031","CR12_00_0_0032","CR12_00_0_0033","CR12_00_0_0034","CR12_00_0_0035", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("81_walking_left","CR12_00_0_0036","CR12_00_0_0037","CR12_00_0_0038","CR12_00_0_0039","CR12_01_0_0000","CR12_01_0_0001", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("81_walking_rear_left","CR12_01_0_0002","CR12_01_0_0003","CR12_01_0_0004","CR12_01_0_0005","CR12_01_0_0006","CR12_01_0_0007", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("81_attack_bash","CR12_01_0_0032","CR12_01_0_0033","CR12_01_0_0034","CR12_01_0_0035","CR12_01_0_0036","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("81_attack_slash","CR12_01_0_0037","CR12_02_0_0000","CR12_02_0_0001","CR12_02_0_0002","CR12_02_0_0003","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("81_attack_thrust","CR12_02_0_0004","CR12_02_0_0005","CR12_02_0_0006","CR12_02_0_0007","CR12_02_0_0008","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("81_attack_secondary","CR12_02_0_0009","CR12_02_0_0010","CR12_02_0_0011","CR12_02_0_0012","CR12_02_0_0013","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("81_attack_unk","CR12_02_0_0009","CR12_02_0_0010","CR12_02_0_0011","CR12_02_0_0012","CR12_02_0_0013","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("81_death","CR12_02_0_0014","CR12_02_0_0015","CR12_02_0_0016","CR12_02_0_0017","CR12_02_0_0018","", 5, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 18 - which is a_yeti&yeti//Animation #0 idle
				CreateAnimationUW("82_idle_rear","CR20_02_1_0001","CR20_02_1_0001","CR20_02_1_0001","CR20_02_1_0001","CR20_02_1_0001","CR20_02_1_0001", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("82_idle_rear_right","CR20_02_1_0004","CR20_02_1_0004","CR20_02_1_0004","CR20_02_1_0004","CR20_02_1_0004","CR20_02_1_0004", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("82_idle_right","CR20_02_1_0010","CR20_02_1_0010","CR20_02_1_0010","CR20_02_1_0010","CR20_02_1_0010","CR20_02_1_0010", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("82_idle_front_right","CR20_03_1_0005","CR20_03_1_0006","CR20_03_1_0007","CR20_03_1_0008","CR20_03_1_0009","CR20_03_1_0010", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("82_idle_front","CR20_03_1_0005","CR20_03_1_0006","CR20_03_1_0007","CR20_03_1_0008","CR20_03_1_0009","CR20_03_1_0010", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("82_idle_front_left","CR20_03_1_0005","CR20_03_1_0006","CR20_03_1_0007","CR20_03_1_0008","CR20_03_1_0009","CR20_03_1_0010", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("82_idle_left","CR20_01_1_0002","CR20_01_1_0002","CR20_01_1_0002","CR20_01_1_0002","CR20_01_1_0002","CR20_01_1_0002", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("82_idle_rear_left","CR20_01_1_0006","CR20_01_1_0006","CR20_01_1_0006","CR20_01_1_0006","CR20_01_1_0006","CR20_01_1_0006", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("82_walking_rear","CR20_02_1_0001","CR20_02_1_0000","CR20_01_1_0013","CR20_01_1_0012","CR20_01_1_0011","CR20_01_1_0010", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("82_walking_rear_right","CR20_02_1_0002","CR20_02_1_0003","CR20_02_1_0004","CR20_02_1_0005","CR20_02_1_0006","CR20_02_1_0007", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("82_walking_right","CR20_02_1_0008","CR20_02_1_0009","CR20_02_1_0010","CR20_02_1_0011","CR20_02_1_0012","CR20_02_1_0013", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("82_walking_front_right","CR20_02_1_0014","CR20_03_1_0000","CR20_03_1_0001","CR20_03_1_0002","CR20_03_1_0003","CR20_03_1_0004", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("82_walking_front","CR20_00_1_0000","CR20_00_1_0001","CR20_00_1_0002","CR20_00_1_0003","CR20_00_1_0004","CR20_00_1_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("82_walking_front_left","CR20_00_1_0006","CR20_00_1_0007","CR20_00_1_0008","CR20_00_1_0009","CR20_00_1_0010","CR20_00_1_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("82_walking_left","CR20_00_1_0012","CR20_00_1_0013","CR20_01_1_0000","CR20_01_1_0001","CR20_01_1_0002","CR20_01_1_0003", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("82_walking_rear_left","CR20_01_1_0004","CR20_01_1_0005","CR20_01_1_0006","CR20_01_1_0007","CR20_01_1_0008","CR20_01_1_0009", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("82_attack_bash","CR20_03_1_0011","CR20_03_1_0012","CR20_04_1_0000","CR20_04_1_0001","CR20_04_1_0002","CR20_04_1_0003", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("82_attack_slash","CR20_04_1_0004","CR20_04_1_0005","CR20_04_1_0006","CR20_04_1_0005","CR20_04_1_0007","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("82_attack_thrust","CR20_04_1_0008","CR20_04_1_0009","CR20_04_1_0010","CR20_04_1_0009","CR20_04_1_0011","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("82_attack_secondary","CR20_04_1_0012","CR20_05_1_0000","CR20_05_1_0001","CR20_05_1_0002","CR20_05_1_0003","CR20_05_1_0004", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("82_attack_unk","CR20_04_1_0012","CR20_05_1_0000","CR20_05_1_0001","CR20_05_1_0002","CR20_05_1_0003","CR20_05_1_0004", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("82_death","CR20_05_1_0005","CR20_05_1_0006","CR20_05_1_0007","CR20_05_1_0008","CR20_05_1_0009","CR20_05_1_0010", 6, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 19 - which is a_headless&headlesses//Animation #0 idle
				CreateAnimationUW("83_idle_rear","CR14_00_0_0016","CR14_00_0_0016","CR14_00_0_0017","CR14_00_0_0017","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("83_idle_rear_right","CR14_00_0_0012","CR14_00_0_0012","CR14_00_0_0013","CR14_00_0_0013","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("83_idle_right","CR14_00_0_0008","CR14_00_0_0008","CR14_00_0_0009","CR14_00_0_0009","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("83_idle_front_right","CR14_00_0_0028","CR14_00_0_0028","CR14_00_0_0029","CR14_00_0_0029","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("83_idle_front","CR14_00_0_0002","CR14_00_0_0002","CR14_00_0_0000","CR14_00_0_0000","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("83_idle_front_left","CR14_00_0_0004","CR14_00_0_0004","CR14_00_0_0005","CR14_00_0_0005","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("83_idle_left","CR14_00_0_0024","CR14_00_0_0024","CR14_00_0_0025","CR14_00_0_0025","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("83_idle_rear_left","CR14_00_0_0022","CR14_00_0_0022","CR14_00_0_0023","CR14_00_0_0023","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("83_walking_rear","CR14_00_0_0018","CR14_00_0_0016","CR14_00_0_0019","CR14_00_0_0017","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("83_walking_rear_right","CR14_00_0_0015","CR14_00_0_0012","CR14_00_0_0014","CR14_00_0_0013","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("83_walking_right","CR14_00_0_0010","CR14_00_0_0008","CR14_00_0_0011","CR14_00_0_0009","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("83_walking_front_right","CR14_00_0_0030","CR14_00_0_0028","CR14_00_0_0031","CR14_00_0_0029","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("83_walking_front","CR14_00_0_0000","CR14_00_0_0001","CR14_00_0_0002","CR14_00_0_0003","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("83_walking_front_left","CR14_00_0_0006","CR14_00_0_0005","CR14_00_0_0007","CR14_00_0_0004","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("83_walking_left","CR14_00_0_0026","CR14_00_0_0024","CR14_00_0_0027","CR14_00_0_0025","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("83_walking_rear_left","CR14_00_0_0020","CR14_00_0_0023","CR14_00_0_0021","CR14_00_0_0022","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("83_attack_bash","CR14_00_0_0002","CR14_00_0_0002","CR14_00_0_0000","CR14_00_0_0000","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("83_attack_slash","CR14_01_0_0000","CR14_01_0_0001","CR14_01_0_0002","CR14_01_0_0003","CR14_01_0_0004","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("83_attack_thrust","CR14_01_0_0008","CR14_01_0_0009","CR14_01_0_0010","CR14_01_0_0011","CR14_01_0_0012","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("83_attack_secondary","CR14_01_0_0008","CR14_01_0_0009","CR14_01_0_0010","CR14_01_0_0011","CR14_01_0_0012","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("83_attack_unk","CR14_01_0_0008","CR14_01_0_0009","CR14_01_0_0010","CR14_01_0_0011","CR14_01_0_0012","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("83_death","CR14_00_0_0001","CR14_01_0_0005","CR14_01_0_0006","CR14_01_0_0007","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 20 - which is a_Talorid//Animation #0 idle
				CreateAnimationUW("84_idle_rear","CR15_00_0_0000","CR15_00_0_0001","CR15_00_0_0002","CR15_00_0_0003","CR15_00_0_0004","CR15_00_0_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("84_idle_rear_right","CR15_00_0_0000","CR15_00_0_0001","CR15_00_0_0002","CR15_00_0_0003","CR15_00_0_0004","CR15_00_0_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("84_idle_right","CR15_00_0_0000","CR15_00_0_0001","CR15_00_0_0002","CR15_00_0_0003","CR15_00_0_0004","CR15_00_0_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("84_idle_front_right","CR15_00_0_0000","CR15_00_0_0001","CR15_00_0_0002","CR15_00_0_0003","CR15_00_0_0004","CR15_00_0_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("84_idle_front","CR15_00_0_0000","CR15_00_0_0001","CR15_00_0_0002","CR15_00_0_0003","CR15_00_0_0004","CR15_00_0_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("84_idle_front_left","CR15_00_0_0000","CR15_00_0_0001","CR15_00_0_0002","CR15_00_0_0003","CR15_00_0_0004","CR15_00_0_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("84_idle_left","CR15_00_0_0000","CR15_00_0_0001","CR15_00_0_0002","CR15_00_0_0003","CR15_00_0_0004","CR15_00_0_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("84_idle_rear_left","CR15_00_0_0000","CR15_00_0_0001","CR15_00_0_0002","CR15_00_0_0003","CR15_00_0_0004","CR15_00_0_0005", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("84_walking_rear","CR15_00_0_0000","CR15_00_0_0003","CR15_00_0_0006","CR15_00_0_0009","CR15_00_0_0012","CR15_00_0_0015", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("84_walking_rear_right","CR15_00_0_0000","CR15_00_0_0003","CR15_00_0_0006","CR15_00_0_0009","CR15_00_0_0012","CR15_00_0_0015", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("84_walking_right","CR15_00_0_0000","CR15_00_0_0003","CR15_00_0_0006","CR15_00_0_0009","CR15_00_0_0012","CR15_00_0_0015", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("84_walking_front_right","CR15_00_0_0000","CR15_00_0_0003","CR15_00_0_0006","CR15_00_0_0009","CR15_00_0_0012","CR15_00_0_0015", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("84_walking_front","CR15_00_0_0000","CR15_00_0_0003","CR15_00_0_0006","CR15_00_0_0009","CR15_00_0_0012","CR15_00_0_0015", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("84_walking_front_left","CR15_00_0_0000","CR15_00_0_0003","CR15_00_0_0006","CR15_00_0_0009","CR15_00_0_0012","CR15_00_0_0015", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("84_walking_left","CR15_00_0_0000","CR15_00_0_0003","CR15_00_0_0006","CR15_00_0_0009","CR15_00_0_0012","CR15_00_0_0015", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("84_walking_rear_left","CR15_00_0_0000","CR15_00_0_0003","CR15_00_0_0006","CR15_00_0_0009","CR15_00_0_0012","CR15_00_0_0015", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("84_attack_bash","CR15_00_0_0012","CR15_01_0_0000","CR15_00_0_0012","CR15_01_0_0000","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("84_attack_slash","CR15_00_0_0003","CR15_01_0_0001","CR15_01_0_0002","CR15_01_0_0001","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("84_attack_thrust","CR15_00_0_0003","CR15_01_0_0001","CR15_01_0_0002","CR15_01_0_0001","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("84_attack_secondary","CR15_00_0_0003","CR15_01_0_0001","CR15_01_0_0002","CR15_01_0_0001","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("84_attack_unk","CR15_00_0_0003","CR15_01_0_0001","CR15_01_0_0002","CR15_01_0_0001","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("84_death","CR15_01_0_0003","CR15_01_0_0004","CR15_01_0_0005","CR15_01_0_0006","CR15_01_0_0007","CR15_01_0_0008", 6, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 21 - which is a_ghost//Animation #0 idle
				CreateAnimationUW("85_idle_rear","CR16_00_0_0004","CR16_00_0_0005","CR16_00_0_0006","CR16_00_0_0007","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("85_idle_rear_right","CR16_00_0_0008","CR16_00_0_0009","CR16_00_0_0010","CR16_00_0_0011","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("85_idle_right","CR16_00_0_0012","CR16_00_0_0013","CR16_00_0_0014","CR16_00_0_0015","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("85_idle_front_right","CR16_00_0_0016","CR16_00_0_0017","CR16_00_0_0018","CR16_00_0_0019","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("85_idle_front","CR16_00_0_0000","CR16_00_0_0001","CR16_00_0_0002","CR16_00_0_0001","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("85_idle_front_left","CR16_00_0_0028","CR16_00_0_0029","CR16_00_0_0030","CR16_00_0_0031","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("85_idle_left","CR16_00_0_0024","CR16_00_0_0025","CR16_00_0_0026","CR16_00_0_0027","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("85_idle_rear_left","CR16_00_0_0020","CR16_00_0_0021","CR16_00_0_0022","CR16_00_0_0023","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("85_walking_rear","CR16_00_0_0004","CR16_00_0_0005","CR16_00_0_0006","CR16_00_0_0007","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("85_walking_rear_right","CR16_00_0_0008","CR16_00_0_0009","CR16_00_0_0010","CR16_00_0_0011","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("85_walking_right","CR16_00_0_0012","CR16_00_0_0013","CR16_00_0_0014","CR16_00_0_0015","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("85_walking_front_right","CR16_00_0_0016","CR16_00_0_0017","CR16_00_0_0018","CR16_00_0_0019","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("85_walking_front","CR16_00_0_0000","CR16_00_0_0001","CR16_00_0_0002","CR16_00_0_0001","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("85_walking_front_left","CR16_00_0_0028","CR16_00_0_0029","CR16_00_0_0030","CR16_00_0_0031","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("85_walking_left","CR16_00_0_0024","CR16_00_0_0025","CR16_00_0_0026","CR16_00_0_0027","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("85_walking_rear_left","CR16_00_0_0020","CR16_00_0_0021","CR16_00_0_0022","CR16_00_0_0023","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("85_attack_bash","CR16_00_0_0036","CR16_00_0_0037","CR16_00_0_0038","CR16_00_0_0039","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("85_attack_slash","CR16_00_0_0040","CR16_00_0_0041","CR16_00_0_0042","CR16_00_0_0043","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("85_attack_thrust","CR16_00_0_0000","CR16_00_0_0001","CR16_00_0_0002","CR16_00_0_0001","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("85_attack_secondary","CR16_00_0_0000","CR16_00_0_0001","CR16_00_0_0002","CR16_00_0_0001","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("85_attack_unk","CR16_00_0_0000","CR16_00_0_0001","CR16_00_0_0002","CR16_00_0_0001","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("85_death","CR16_00_0_0032","CR16_00_0_0033","CR16_00_0_0034","CR16_00_0_0035","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 22 - which is a_wolf_spider//Animation #0 idle
				CreateAnimationUW("86_idle_rear","CR10_00_1_0006","CR10_00_1_0006","CR10_00_1_0006","CR10_00_1_0006","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("86_idle_rear_right","CR10_01_1_0000","CR10_01_1_0000","CR10_01_1_0000","CR10_01_1_0000","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("86_idle_right","CR10_00_1_0014","CR10_00_1_0014","CR10_00_1_0014","CR10_00_1_0014","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("86_idle_front_right","CR10_00_1_0018","CR10_00_1_0018","CR10_00_1_0018","CR10_00_1_0018","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("86_idle_front","CR10_00_1_0002","CR10_00_1_0002","CR10_00_1_0002","CR10_00_1_0002","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("86_idle_front_left","CR10_00_1_0022","CR10_00_1_0022","CR10_00_1_0022","CR10_00_1_0022","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("86_idle_left","CR10_00_1_0010","CR10_00_1_0010","CR10_00_1_0010","CR10_00_1_0010","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("86_idle_rear_left","CR10_01_1_0004","CR10_01_1_0004","CR10_01_1_0004","CR10_01_1_0004","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("86_walking_rear","CR10_00_1_0004","CR10_00_1_0005","CR10_00_1_0006","CR10_00_1_0007","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("86_walking_rear_right","CR10_00_1_0024","CR10_00_1_0025","CR10_01_1_0000","CR10_01_1_0001","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("86_walking_right","CR10_00_1_0012","CR10_00_1_0013","CR10_00_1_0014","CR10_00_1_0015","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("86_walking_front_right","CR10_00_1_0016","CR10_00_1_0017","CR10_00_1_0018","CR10_00_1_0019","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("86_walking_front","CR10_00_1_0000","CR10_00_1_0001","CR10_00_1_0002","CR10_00_1_0003","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("86_walking_front_left","CR10_00_1_0020","CR10_00_1_0021","CR10_00_1_0022","CR10_00_1_0023","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("86_walking_left","CR10_00_1_0008","CR10_00_1_0009","CR10_00_1_0010","CR10_00_1_0011","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("86_walking_rear_left","CR10_01_1_0002","CR10_01_1_0003","CR10_01_1_0004","CR10_01_1_0005","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("86_attack_bash","CR10_01_1_0008","CR10_01_1_0009","CR10_01_1_0010","CR10_01_1_0011","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("86_attack_slash","CR10_01_1_0012","CR10_01_1_0013","CR10_01_1_0014","CR10_01_1_0015","CR10_01_1_0016","CR10_01_1_0014", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("86_attack_thrust","CR10_01_1_0012","CR10_01_1_0013","CR10_01_1_0014","CR10_01_1_0015","CR10_01_1_0016","CR10_01_1_0014", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("86_attack_secondary","CR10_01_1_0012","CR10_01_1_0013","CR10_01_1_0014","CR10_01_1_0015","CR10_01_1_0016","CR10_01_1_0014", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("86_attack_unk","CR10_01_1_0012","CR10_01_1_0013","CR10_01_1_0014","CR10_01_1_0015","CR10_01_1_0016","CR10_01_1_0014", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("86_death","CR10_01_1_0017","CR10_01_1_0018","CR10_01_1_0019","CR10_01_1_0020","CR10_01_1_0021","CR10_01_1_0022", 6, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 23 - which is a_trilkhun&trilkhai//Animation #0 idle
				CreateAnimationUW("87_idle_rear","CR12_00_1_0012","CR12_00_1_0013","CR12_00_1_0014","CR12_00_1_0013","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("87_idle_rear_right","CR12_00_1_0015","CR12_00_1_0016","CR12_00_1_0017","CR12_00_1_0016","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("87_idle_right","CR12_00_1_0018","CR12_00_1_0019","CR12_00_1_0020","CR12_00_1_0019","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("87_idle_front_right","CR12_00_1_0021","CR12_00_1_0022","CR12_00_1_0023","CR12_00_1_0022","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("87_idle_front","CR12_00_1_0000","CR12_00_1_0001","CR12_00_1_0002","CR12_00_1_0001","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("87_idle_front_left","CR12_00_1_0003","CR12_00_1_0004","CR12_00_1_0005","CR12_00_1_0004","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("87_idle_left","CR12_00_1_0006","CR12_00_1_0007","CR12_00_1_0008","CR12_00_1_0007","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("87_idle_rear_left","CR12_00_1_0009","CR12_00_1_0010","CR12_00_1_0011","CR12_00_1_0010","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("87_walking_rear","CR12_01_1_0008","CR12_01_1_0009","CR12_01_1_0010","CR12_01_1_0011","CR12_01_1_0012","CR12_01_1_0013", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("87_walking_rear_right","CR12_01_1_0014","CR12_01_1_0015","CR12_01_1_0016","CR12_01_1_0017","CR12_01_1_0018","CR12_01_1_0019", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("87_walking_right","CR12_01_1_0020","CR12_01_1_0021","CR12_01_1_0022","CR12_01_1_0023","CR12_01_1_0024","CR12_01_1_0025", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("87_walking_front_right","CR12_01_1_0026","CR12_01_1_0027","CR12_01_1_0028","CR12_01_1_0029","CR12_01_1_0030","CR12_01_1_0031", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("87_walking_front","CR12_00_1_0024","CR12_00_1_0025","CR12_00_1_0026","CR12_00_1_0027","CR12_00_1_0028","CR12_00_1_0029", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("87_walking_front_left","CR12_00_1_0030","CR12_00_1_0031","CR12_00_1_0032","CR12_00_1_0033","CR12_00_1_0034","CR12_00_1_0035", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("87_walking_left","CR12_00_1_0036","CR12_00_1_0037","CR12_00_1_0038","CR12_00_1_0039","CR12_01_1_0000","CR12_01_1_0001", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("87_walking_rear_left","CR12_01_1_0002","CR12_01_1_0003","CR12_01_1_0004","CR12_01_1_0005","CR12_01_1_0006","CR12_01_1_0007", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("87_attack_bash","CR12_01_1_0032","CR12_01_1_0033","CR12_01_1_0034","CR12_01_1_0035","CR12_01_1_0036","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("87_attack_slash","CR12_01_1_0037","CR12_02_1_0000","CR12_02_1_0001","CR12_02_1_0002","CR12_02_1_0003","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("87_attack_thrust","CR12_02_1_0004","CR12_02_1_0005","CR12_02_1_0006","CR12_02_1_0007","CR12_02_1_0008","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("87_attack_secondary","CR12_02_1_0009","CR12_02_1_0010","CR12_02_1_0011","CR12_02_1_0012","CR12_02_1_0013","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("87_attack_unk","CR12_02_1_0009","CR12_02_1_0010","CR12_02_1_0011","CR12_02_1_0012","CR12_02_1_0013","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("87_death","CR12_02_1_0014","CR12_02_1_0015","CR12_02_1_0016","CR12_02_1_0017","CR12_02_1_0018","", 5, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 24 - which is a_brain_creature//Animation #0 idle
				CreateAnimationUW("88_idle_rear","CR17_01_0_0000","CR17_01_0_0001","CR17_01_0_0002","CR17_01_0_0003","CR17_01_0_0004","CR17_01_0_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("88_idle_rear_right","CR17_00_0_0018","CR17_00_0_0019","CR17_00_0_0020","CR17_00_0_0021","CR17_00_0_0022","CR17_00_0_0023", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("88_idle_right","CR17_00_0_0012","CR17_00_0_0013","CR17_00_0_0014","CR17_00_0_0015","CR17_00_0_0016","CR17_00_0_0017", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("88_idle_front_right","CR17_00_0_0006","CR17_00_0_0007","CR17_00_0_0008","CR17_00_0_0009","CR17_00_0_0010","CR17_00_0_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("88_idle_front","CR17_00_0_0000","CR17_00_0_0001","CR17_00_0_0002","CR17_00_0_0003","CR17_00_0_0004","CR17_00_0_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("88_idle_front_left","CR17_01_0_0018","CR17_01_0_0019","CR17_01_0_0020","CR17_01_0_0021","CR17_01_0_0022","CR17_01_0_0023", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("88_idle_left","CR17_01_0_0012","CR17_01_0_0013","CR17_01_0_0014","CR17_01_0_0015","CR17_01_0_0016","CR17_01_0_0017", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("88_idle_rear_left","CR17_01_0_0006","CR17_01_0_0007","CR17_01_0_0008","CR17_01_0_0009","CR17_01_0_0010","CR17_01_0_0011", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("88_walking_rear","CR17_01_0_0000","CR17_01_0_0001","CR17_01_0_0002","CR17_01_0_0003","CR17_01_0_0004","CR17_01_0_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("88_walking_rear_right","CR17_00_0_0018","CR17_00_0_0019","CR17_00_0_0020","CR17_00_0_0021","CR17_00_0_0022","CR17_00_0_0023", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("88_walking_right","CR17_00_0_0012","CR17_00_0_0013","CR17_00_0_0014","CR17_00_0_0015","CR17_00_0_0016","CR17_00_0_0017", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("88_walking_front_right","CR17_00_0_0006","CR17_00_0_0007","CR17_00_0_0008","CR17_00_0_0009","CR17_00_0_0010","CR17_00_0_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("88_walking_front","CR17_00_0_0000","CR17_00_0_0001","CR17_00_0_0002","CR17_00_0_0003","CR17_00_0_0004","CR17_00_0_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("88_walking_front_left","CR17_01_0_0018","CR17_01_0_0019","CR17_01_0_0020","CR17_01_0_0021","CR17_01_0_0022","CR17_01_0_0023", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("88_walking_left","CR17_01_0_0012","CR17_01_0_0013","CR17_01_0_0014","CR17_01_0_0015","CR17_01_0_0016","CR17_01_0_0017", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("88_walking_rear_left","CR17_01_0_0006","CR17_01_0_0007","CR17_01_0_0008","CR17_01_0_0009","CR17_01_0_0010","CR17_01_0_0011", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("88_attack_bash","CR17_01_0_0024","CR17_02_0_0000","CR17_02_0_0001","CR17_02_0_0002","CR17_02_0_0003","CR17_02_0_0004", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("88_attack_slash","CR17_02_0_0005","CR17_02_0_0006","CR17_02_0_0007","CR17_02_0_0008","CR17_02_0_0009","CR17_02_0_0010", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("88_attack_thrust","CR17_02_0_0005","CR17_02_0_0006","CR17_02_0_0007","CR17_02_0_0008","CR17_02_0_0009","CR17_02_0_0010", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("88_attack_secondary","CR17_02_0_0005","CR17_02_0_0006","CR17_02_0_0007","CR17_02_0_0008","CR17_02_0_0009","CR17_02_0_0010", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("88_attack_unk","CR17_02_0_0005","CR17_02_0_0006","CR17_02_0_0007","CR17_02_0_0008","CR17_02_0_0009","CR17_02_0_0010", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("88_death","CR17_02_0_0011","CR17_02_0_0012","CR17_02_0_0013","CR17_02_0_0014","CR17_02_0_0015","CR17_02_0_0016", 6, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 25 - which is a_deep_lurker//Animation #0 idle
				CreateAnimationUW("89_idle_rear","CR11_00_1_0046","CR11_00_1_0047","CR11_00_1_0047","CR11_00_1_0046","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("89_idle_rear_right","CR11_00_1_0044","CR11_00_1_0045","CR11_00_1_0045","CR11_00_1_0044","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("89_idle_right","CR11_00_1_0040","CR11_00_1_0041","CR11_00_1_0042","CR11_00_1_0043","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("89_idle_front_right","CR11_00_1_0036","CR11_00_1_0037","CR11_00_1_0038","CR11_00_1_0039","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("89_idle_front","CR11_00_1_0032","CR11_00_1_0033","CR11_00_1_0034","CR11_00_1_0035","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("89_idle_front_left","CR11_00_1_0054","CR11_00_1_0055","CR11_00_1_0056","CR11_00_1_0057","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("89_idle_left","CR11_00_1_0050","CR11_00_1_0051","CR11_00_1_0052","CR11_00_1_0053","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("89_idle_rear_left","CR11_00_1_0048","CR11_00_1_0049","CR11_00_1_0049","CR11_00_1_0048","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("89_walking_rear","CR11_00_1_0016","CR11_00_1_0017","CR11_00_1_0018","CR11_00_1_0019","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("89_walking_rear_right","CR11_00_1_0012","CR11_00_1_0013","CR11_00_1_0014","CR11_00_1_0015","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("89_walking_right","CR11_00_1_0008","CR11_00_1_0009","CR11_00_1_0010","CR11_00_1_0011","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("89_walking_front_right","CR11_00_1_0004","CR11_00_1_0005","CR11_00_1_0006","CR11_00_1_0007","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("89_walking_front","CR11_00_1_0000","CR11_00_1_0001","CR11_00_1_0002","CR11_00_1_0003","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("89_walking_front_left","CR11_00_1_0028","CR11_00_1_0029","CR11_00_1_0030","CR11_00_1_0031","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("89_walking_left","CR11_00_1_0024","CR11_00_1_0025","CR11_00_1_0026","CR11_00_1_0027","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("89_walking_rear_left","CR11_00_1_0020","CR11_00_1_0021","CR11_00_1_0022","CR11_00_1_0023","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("89_attack_bash","CR11_00_1_0062","CR11_00_1_0063","CR11_00_1_0064","CR11_00_1_0065","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("89_attack_slash","CR11_00_1_0068","CR11_00_1_0066","CR11_00_1_0067","CR11_00_1_0069","CR11_00_1_0070","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("89_attack_thrust","CR11_00_1_0071","CR11_00_1_0072","CR11_00_1_0073","CR11_00_1_0074","CR11_00_1_0075","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("89_attack_secondary","CR11_00_1_0076","CR11_00_1_0077","CR11_00_1_0078","CR11_00_1_0079","CR11_00_1_0080","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("89_attack_unk","CR11_00_1_0076","CR11_00_1_0077","CR11_00_1_0078","CR11_00_1_0079","CR11_00_1_0080","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("89_death","CR11_00_1_0058","CR11_00_1_0059","CR11_00_1_0060","CR11_00_1_0061","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 26 - which is a_dread_spider//Animation #0 idle
				CreateAnimationUW("90_idle_rear","CR10_00_2_0006","CR10_00_2_0006","CR10_00_2_0006","CR10_00_2_0006","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("90_idle_rear_right","CR10_01_2_0000","CR10_01_2_0000","CR10_01_2_0000","CR10_01_2_0000","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("90_idle_right","CR10_00_2_0014","CR10_00_2_0014","CR10_00_2_0014","CR10_00_2_0014","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("90_idle_front_right","CR10_00_2_0018","CR10_00_2_0018","CR10_00_2_0018","CR10_00_2_0018","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("90_idle_front","CR10_00_2_0002","CR10_00_2_0002","CR10_00_2_0002","CR10_00_2_0002","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("90_idle_front_left","CR10_00_2_0022","CR10_00_2_0022","CR10_00_2_0022","CR10_00_2_0022","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("90_idle_left","CR10_00_2_0010","CR10_00_2_0010","CR10_00_2_0010","CR10_00_2_0010","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("90_idle_rear_left","CR10_01_2_0004","CR10_01_2_0004","CR10_01_2_0004","CR10_01_2_0004","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("90_walking_rear","CR10_00_2_0004","CR10_00_2_0005","CR10_00_2_0006","CR10_00_2_0007","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("90_walking_rear_right","CR10_00_2_0024","CR10_00_2_0025","CR10_01_2_0000","CR10_01_2_0001","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("90_walking_right","CR10_00_2_0012","CR10_00_2_0013","CR10_00_2_0014","CR10_00_2_0015","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("90_walking_front_right","CR10_00_2_0016","CR10_00_2_0017","CR10_00_2_0018","CR10_00_2_0019","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("90_walking_front","CR10_00_2_0000","CR10_00_2_0001","CR10_00_2_0002","CR10_00_2_0003","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("90_walking_front_left","CR10_00_2_0020","CR10_00_2_0021","CR10_00_2_0022","CR10_00_2_0023","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("90_walking_left","CR10_00_2_0008","CR10_00_2_0009","CR10_00_2_0010","CR10_00_2_0011","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("90_walking_rear_left","CR10_01_2_0002","CR10_01_2_0003","CR10_01_2_0004","CR10_01_2_0005","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("90_attack_bash","CR10_01_2_0008","CR10_01_2_0009","CR10_01_2_0010","CR10_01_2_0011","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("90_attack_slash","CR10_01_2_0012","CR10_01_2_0013","CR10_01_2_0014","CR10_01_2_0015","CR10_01_2_0016","CR10_01_2_0014", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("90_attack_thrust","CR10_01_2_0012","CR10_01_2_0013","CR10_01_2_0014","CR10_01_2_0015","CR10_01_2_0016","CR10_01_2_0014", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("90_attack_secondary","CR10_01_2_0012","CR10_01_2_0013","CR10_01_2_0014","CR10_01_2_0015","CR10_01_2_0016","CR10_01_2_0014", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("90_attack_unk","CR10_01_2_0012","CR10_01_2_0013","CR10_01_2_0014","CR10_01_2_0015","CR10_01_2_0016","CR10_01_2_0014", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("90_death","CR10_01_2_0017","CR10_01_2_0018","CR10_01_2_0019","CR10_01_2_0020","CR10_01_2_0021","CR10_01_2_0022", 6, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 27 - which is a_human//Animation #0 idle
				CreateAnimationUW("91_idle_rear","CR32_00_2_0028","CR32_00_2_0028","CR32_00_2_0028","CR32_00_2_0028","CR32_00_2_0028","CR32_00_2_0028", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("91_idle_rear_right","CR32_00_2_0032","CR32_00_2_0032","CR32_00_2_0032","CR32_00_2_0032","CR32_00_2_0032","CR32_00_2_0032", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("91_idle_right","CR32_00_2_0038","CR32_00_2_0038","CR32_00_2_0038","CR32_00_2_0038","CR32_00_2_0038","CR32_00_2_0038", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("91_idle_front_right","CR32_01_2_0003","CR32_01_2_0003","CR32_01_2_0003","CR32_01_2_0003","CR32_01_2_0003","CR32_01_2_0003", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("91_idle_front","CR32_01_2_0020","CR32_01_2_0021","CR32_01_2_0022","CR32_01_2_0023","CR32_01_2_0024","CR32_01_2_0025", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("91_idle_front_left","CR32_00_2_0008","CR32_00_2_0008","CR32_00_2_0008","CR32_00_2_0008","CR32_00_2_0008","CR32_00_2_0008", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("91_idle_left","CR32_00_2_0014","CR32_00_2_0014","CR32_00_2_0014","CR32_00_2_0014","CR32_00_2_0014","CR32_00_2_0014", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("91_idle_rear_left","CR32_00_2_0020","CR32_00_2_0020","CR32_00_2_0020","CR32_00_2_0020","CR32_00_2_0020","CR32_00_2_0020", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("91_walking_rear","CR32_00_2_0024","CR32_00_2_0025","CR32_00_2_0026","CR32_00_2_0027","CR32_00_2_0028","CR32_00_2_0029", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("91_walking_rear_right","CR32_00_2_0030","CR32_00_2_0031","CR32_00_2_0032","CR32_00_2_0033","CR32_00_2_0034","CR32_00_2_0035", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("91_walking_right","CR32_00_2_0036","CR32_00_2_0037","CR32_00_2_0038","CR32_00_2_0039","CR32_01_2_0000","CR32_01_2_0001", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("91_walking_front_right","CR32_01_2_0002","CR32_01_2_0003","CR32_01_2_0004","CR32_01_2_0005","CR32_01_2_0006","CR32_01_2_0007", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("91_walking_front","CR32_00_2_0000","CR32_00_2_0001","CR32_00_2_0002","CR32_00_2_0003","CR32_00_2_0004","CR32_00_2_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("91_walking_front_left","CR32_00_2_0006","CR32_00_2_0007","CR32_00_2_0008","CR32_00_2_0009","CR32_00_2_0010","CR32_00_2_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("91_walking_left","CR32_00_2_0012","CR32_00_2_0013","CR32_00_2_0014","CR32_00_2_0015","CR32_00_2_0016","CR32_00_2_0017", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("91_walking_rear_left","CR32_00_2_0018","CR32_00_2_0019","CR32_00_2_0020","CR32_00_2_0021","CR32_00_2_0022","CR32_00_2_0023", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("91_attack_bash","CR32_01_2_0008","CR32_01_2_0009","CR32_01_2_0010","CR32_01_2_0011","CR32_01_2_0012","CR32_01_2_0013", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("91_attack_slash","CR32_01_2_0014","CR32_01_2_0015","CR32_01_2_0016","CR32_01_2_0017","CR32_01_2_0018","CR32_01_2_0019", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("91_attack_thrust","CR32_01_2_0014","CR32_01_2_0015","CR32_01_2_0016","CR32_01_2_0017","CR32_01_2_0018","CR32_01_2_0019", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("91_attack_secondary","CR32_01_2_0014","CR32_01_2_0015","CR32_01_2_0016","CR32_01_2_0017","CR32_01_2_0018","CR32_01_2_0019", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("91_attack_unk","CR32_01_2_0008","CR32_01_2_0009","CR32_01_2_0010","CR32_01_2_0011","CR32_01_2_0012","CR32_01_2_0013", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("91_death","CR32_01_2_0026","CR32_01_2_0027","CR32_01_2_0028","CR32_01_2_0029","CR32_01_2_0030","CR32_01_2_0031", 6, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 28 - which is a_great_troll//Animation #0 idle
				CreateAnimationUW("92_idle_rear","CR20_02_0_0001","CR20_02_0_0001","CR20_02_0_0001","CR20_02_0_0001","CR20_02_0_0001","CR20_02_0_0001", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("92_idle_rear_right","CR20_02_0_0004","CR20_02_0_0004","CR20_02_0_0004","CR20_02_0_0004","CR20_02_0_0004","CR20_02_0_0004", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("92_idle_right","CR20_02_0_0010","CR20_02_0_0010","CR20_02_0_0010","CR20_02_0_0010","CR20_02_0_0010","CR20_02_0_0010", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("92_idle_front_right","CR20_03_0_0005","CR20_03_0_0006","CR20_03_0_0007","CR20_03_0_0008","CR20_03_0_0009","CR20_03_0_0010", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("92_idle_front","CR20_03_0_0005","CR20_03_0_0006","CR20_03_0_0007","CR20_03_0_0008","CR20_03_0_0009","CR20_03_0_0010", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("92_idle_front_left","CR20_03_0_0005","CR20_03_0_0006","CR20_03_0_0007","CR20_03_0_0008","CR20_03_0_0009","CR20_03_0_0010", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("92_idle_left","CR20_01_0_0002","CR20_01_0_0002","CR20_01_0_0002","CR20_01_0_0002","CR20_01_0_0002","CR20_01_0_0002", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("92_idle_rear_left","CR20_01_0_0006","CR20_01_0_0006","CR20_01_0_0006","CR20_01_0_0006","CR20_01_0_0006","CR20_01_0_0006", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("92_walking_rear","CR20_02_0_0001","CR20_02_0_0000","CR20_01_0_0013","CR20_01_0_0012","CR20_01_0_0011","CR20_01_0_0010", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("92_walking_rear_right","CR20_02_0_0002","CR20_02_0_0003","CR20_02_0_0004","CR20_02_0_0005","CR20_02_0_0006","CR20_02_0_0007", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("92_walking_right","CR20_02_0_0008","CR20_02_0_0009","CR20_02_0_0010","CR20_02_0_0011","CR20_02_0_0012","CR20_02_0_0013", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("92_walking_front_right","CR20_02_0_0014","CR20_03_0_0000","CR20_03_0_0001","CR20_03_0_0002","CR20_03_0_0003","CR20_03_0_0004", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("92_walking_front","CR20_00_0_0000","CR20_00_0_0001","CR20_00_0_0002","CR20_00_0_0003","CR20_00_0_0004","CR20_00_0_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("92_walking_front_left","CR20_00_0_0006","CR20_00_0_0007","CR20_00_0_0008","CR20_00_0_0009","CR20_00_0_0010","CR20_00_0_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("92_walking_left","CR20_00_0_0012","CR20_00_0_0013","CR20_01_0_0000","CR20_01_0_0001","CR20_01_0_0002","CR20_01_0_0003", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("92_walking_rear_left","CR20_01_0_0004","CR20_01_0_0005","CR20_01_0_0006","CR20_01_0_0007","CR20_01_0_0008","CR20_01_0_0009", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("92_attack_bash","CR20_03_0_0011","CR20_03_0_0012","CR20_04_0_0000","CR20_04_0_0001","CR20_04_0_0002","CR20_04_0_0003", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("92_attack_slash","CR20_04_0_0004","CR20_04_0_0005","CR20_04_0_0006","CR20_04_0_0005","CR20_04_0_0007","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("92_attack_thrust","CR20_04_0_0008","CR20_04_0_0009","CR20_04_0_0010","CR20_04_0_0009","CR20_04_0_0011","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("92_attack_secondary","CR20_04_0_0012","CR20_05_0_0000","CR20_05_0_0001","CR20_05_0_0002","CR20_05_0_0003","CR20_05_0_0004", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("92_attack_unk","CR20_04_0_0012","CR20_05_0_0000","CR20_05_0_0001","CR20_05_0_0002","CR20_05_0_0003","CR20_05_0_0004", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("92_death","CR20_05_0_0005","CR20_05_0_0006","CR20_05_0_0007","CR20_05_0_0008","CR20_05_0_0009","CR20_05_0_0010", 6, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 29 - which is a_spectre//Animation #0 idle
				CreateAnimationUW("93_idle_rear","CR26_00_2_0020","CR26_00_2_0020","CR26_00_2_0020","CR26_00_2_0020","CR26_00_2_0020","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("93_idle_rear_right","CR26_00_2_0025","CR26_00_2_0025","CR26_00_2_0025","CR26_00_2_0025","CR26_00_2_0025","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("93_idle_right","CR26_00_2_0031","CR26_00_2_0031","CR26_00_2_0031","CR26_00_2_0031","CR26_00_2_0031","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("93_idle_front_right","CR26_01_2_0003","CR26_01_2_0003","CR26_01_2_0003","CR26_01_2_0003","CR26_01_2_0003","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("93_idle_front","CR26_01_2_0016","CR26_01_2_0017","CR26_01_2_0018","CR26_01_2_0019","CR26_01_2_0020","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("93_idle_front_left","CR26_00_2_0006","CR26_00_2_0006","CR26_00_2_0006","CR26_00_2_0006","CR26_00_2_0006","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("93_idle_left","CR26_00_2_0013","CR26_00_2_0013","CR26_00_2_0013","CR26_00_2_0013","CR26_00_2_0013","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("93_idle_rear_left","CR26_00_2_0016","CR26_00_2_0016","CR26_00_2_0016","CR26_00_2_0016","CR26_00_2_0016","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("93_walking_rear","CR26_00_2_0020","CR26_00_2_0021","CR26_00_2_0022","CR26_00_2_0023","CR26_00_2_0024","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("93_walking_rear_right","CR26_00_2_0025","CR26_00_2_0026","CR26_00_2_0027","CR26_00_2_0028","CR26_00_2_0029","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("93_walking_right","CR26_00_2_0030","CR26_00_2_0031","CR26_00_2_0032","CR26_00_2_0033","CR26_01_2_0000","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("93_walking_front_right","CR26_01_2_0001","CR26_01_2_0002","CR26_01_2_0003","CR26_01_2_0004","CR26_01_2_0005","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("93_walking_front","CR26_00_2_0000","CR26_00_2_0001","CR26_00_2_0002","CR26_00_2_0003","CR26_00_2_0004","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("93_walking_front_left","CR26_00_2_0005","CR26_00_2_0006","CR26_00_2_0007","CR26_00_2_0008","CR26_00_2_0009","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("93_walking_left","CR26_00_2_0010","CR26_00_2_0011","CR26_00_2_0012","CR26_00_2_0013","CR26_00_2_0014","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("93_walking_rear_left","CR26_00_2_0015","CR26_00_2_0016","CR26_00_2_0017","CR26_00_2_0018","CR26_00_2_0019","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("93_attack_bash","CR26_01_2_0007","CR26_01_2_0008","CR26_01_2_0009","CR26_01_2_0010","CR26_01_2_0010","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("93_attack_slash","CR26_01_2_0011","CR26_01_2_0012","CR26_01_2_0013","CR26_01_2_0014","CR26_01_2_0015","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("93_attack_thrust","CR26_01_2_0011","CR26_01_2_0012","CR26_01_2_0013","CR26_01_2_0014","CR26_01_2_0015","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("93_attack_secondary","CR26_01_2_0011","CR26_01_2_0012","CR26_01_2_0013","CR26_01_2_0014","CR26_01_2_0015","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("93_attack_unk","CR26_01_2_0011","CR26_01_2_0012","CR26_01_2_0013","CR26_01_2_0014","CR26_01_2_0015","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("93_death","CR26_01_2_0021","CR26_01_2_0022","CR26_01_2_0023","CR26_01_2_0024","CR26_01_2_0025","", 5, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 30 - which is a_hordling//Animation #0 idle
				CreateAnimationUW("94_idle_rear","CR21_01_0_0012","CR21_01_0_0012","CR21_01_0_0012","CR21_01_0_0012","CR21_01_0_0012","CR21_01_0_0012", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("94_idle_rear_right","CR21_02_0_0004","CR21_02_0_0004","CR21_02_0_0004","CR21_02_0_0004","CR21_02_0_0004","CR21_02_0_0004", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("94_idle_right","CR21_02_0_0008","CR21_02_0_0008","CR21_02_0_0008","CR21_02_0_0008","CR21_02_0_0008","CR21_02_0_0008", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("94_idle_front_right","CR21_02_0_0014","CR21_02_0_0014","CR21_02_0_0014","CR21_02_0_0014","CR21_02_0_0014","CR21_02_0_0014", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("94_idle_front","CR21_03_0_0003","CR21_03_0_0004","CR21_03_0_0005","CR21_03_0_0006","CR21_03_0_0007","CR21_03_0_0008", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("94_idle_front_left","CR21_00_0_0010","CR21_00_0_0010","CR21_00_0_0010","CR21_00_0_0010","CR21_00_0_0010","CR21_00_0_0010", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("94_idle_left","CR21_01_0_0002","CR21_01_0_0002","CR21_01_0_0002","CR21_01_0_0002","CR21_01_0_0002","CR21_01_0_0002", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("94_idle_rear_left","CR21_01_0_0007","CR21_01_0_0007","CR21_01_0_0007","CR21_01_0_0007","CR21_01_0_0007","CR21_01_0_0007", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("94_walking_rear","CR21_01_0_0010","CR21_01_0_0011","CR21_01_0_0012","CR21_01_0_0013","CR21_01_0_0014","CR21_02_0_0000", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("94_walking_rear_right","CR21_02_0_0001","CR21_02_0_0002","CR21_02_0_0003","CR21_02_0_0004","CR21_02_0_0005","CR21_02_0_0006", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("94_walking_right","CR21_02_0_0007","CR21_02_0_0008","CR21_02_0_0009","CR21_02_0_0010","CR21_02_0_0011","CR21_02_0_0012", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("94_walking_front_right","CR21_02_0_0013","CR21_02_0_0014","CR21_02_0_0015","CR21_03_0_0000","CR21_03_0_0001","CR21_03_0_0002", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("94_walking_front","CR21_00_0_0000","CR21_00_0_0001","CR21_00_0_0002","CR21_00_0_0003","CR21_00_0_0004","CR21_00_0_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("94_walking_front_left","CR21_00_0_0006","CR21_00_0_0007","CR21_00_0_0008","CR21_00_0_0009","CR21_00_0_0010","CR21_00_0_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("94_walking_left","CR21_00_0_0012","CR21_00_0_0013","CR21_01_0_0000","CR21_01_0_0001","CR21_01_0_0002","CR21_01_0_0003", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("94_walking_rear_left","CR21_01_0_0004","CR21_01_0_0005","CR21_01_0_0006","CR21_01_0_0007","CR21_01_0_0008","CR21_01_0_0009", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("94_attack_bash","CR21_03_0_0009","CR21_03_0_0010","CR21_03_0_0011","CR21_03_0_0012","CR21_04_0_0000","CR21_04_0_0001", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("94_attack_slash","CR21_04_0_0002","CR21_04_0_0003","CR21_04_0_0004","CR21_04_0_0005","CR21_04_0_0006","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("94_attack_thrust","CR21_04_0_0002","CR21_04_0_0003","CR21_04_0_0004","CR21_04_0_0005","CR21_04_0_0006","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("94_attack_secondary","CR21_04_0_0007","CR21_04_0_0008","CR21_04_0_0009","CR21_04_0_0010","CR21_04_0_0011","CR21_04_0_0012", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("94_attack_unk","CR21_04_0_0007","CR21_04_0_0008","CR21_04_0_0009","CR21_04_0_0010","CR21_04_0_0011","CR21_04_0_0012", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("94_death","CR21_05_0_0000","CR21_05_0_0001","CR21_05_0_0002","CR21_05_0_0003","CR21_05_0_0004","", 5, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 31 - which is an_earth_golem//Animation #0 idle
				CreateAnimationUW("95_idle_rear","CR22_01_0_0023","CR22_01_0_0023","CR22_01_0_0023","CR22_01_0_0023","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("95_idle_rear_right","CR22_01_0_0022","CR22_01_0_0022","CR22_01_0_0022","CR22_01_0_0022","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("95_idle_right","CR22_01_0_0021","CR22_01_0_0021","CR22_01_0_0021","CR22_01_0_0021","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("95_idle_front_right","CR22_01_0_0020","CR22_01_0_0020","CR22_01_0_0020","CR22_01_0_0020","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("95_idle_front","CR22_01_0_0019","CR22_01_0_0019","CR22_01_0_0019","CR22_01_0_0019","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("95_idle_front_left","CR22_02_0_0002","CR22_02_0_0002","CR22_02_0_0002","CR22_02_0_0002","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("95_idle_left","CR22_02_0_0001","CR22_02_0_0001","CR22_02_0_0001","CR22_02_0_0001","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("95_idle_rear_left","CR22_02_0_0000","CR22_02_0_0000","CR22_02_0_0000","CR22_02_0_0000","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("95_walking_rear","CR22_00_0_0016","CR22_00_0_0017","CR22_00_0_0018","CR22_00_0_0019","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("95_walking_rear_right","CR22_00_0_0020","CR22_00_0_0021","CR22_00_0_0022","CR22_01_0_0000","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("95_walking_right","CR22_01_0_0001","CR22_01_0_0002","CR22_01_0_0003","CR22_01_0_0004","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("95_walking_front_right","CR22_01_0_0005","CR22_01_0_0006","CR22_01_0_0007","CR22_01_0_0008","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("95_walking_front","CR22_00_0_0000","CR22_00_0_0001","CR22_00_0_0002","CR22_00_0_0003","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("95_walking_front_left","CR22_00_0_0004","CR22_00_0_0005","CR22_00_0_0006","CR22_00_0_0007","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("95_walking_left","CR22_00_0_0008","CR22_00_0_0009","CR22_00_0_0010","CR22_00_0_0011","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("95_walking_rear_left","CR22_00_0_0015","CR22_00_0_0014","CR22_00_0_0013","CR22_00_0_0012","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("95_attack_bash","CR22_02_0_0008","CR22_02_0_0009","CR22_02_0_0008","CR22_02_0_0009","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("95_attack_slash","CR22_02_0_0003","CR22_02_0_0004","CR22_02_0_0005","CR22_02_0_0006","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("95_attack_thrust","CR22_02_0_0003","CR22_02_0_0004","CR22_02_0_0005","CR22_02_0_0006","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("95_attack_secondary","CR22_02_0_0003","CR22_02_0_0004","CR22_02_0_0005","CR22_02_0_0006","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("95_attack_unk","CR22_02_0_0003","CR22_02_0_0004","CR22_02_0_0005","CR22_02_0_0006","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("95_death","CR22_01_0_0015","CR22_01_0_0016","CR22_01_0_0017","CR22_01_0_0018","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 32 - which is a_fire_elemental//Animation #0 idle
				CreateAnimationUW("96_idle_rear","CR23_00_0_0016","CR23_00_0_0017","CR23_00_0_0018","CR23_00_0_0019","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("96_idle_rear_right","CR23_00_0_0012","CR23_00_0_0013","CR23_00_0_0014","CR23_00_0_0015","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("96_idle_right","CR23_00_0_0008","CR23_00_0_0009","CR23_00_0_0010","CR23_00_0_0011","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("96_idle_front_right","CR23_00_0_0004","CR23_00_0_0005","CR23_00_0_0006","CR23_00_0_0007","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("96_idle_front","CR23_00_0_0000","CR23_00_0_0001","CR23_00_0_0002","CR23_00_0_0003","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("96_idle_front_left","CR23_00_0_0024","CR23_00_0_0025","CR23_00_0_0026","CR23_00_0_0027","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("96_idle_left","CR23_00_0_0020","CR23_00_0_0021","CR23_00_0_0022","CR23_00_0_0023","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("96_idle_rear_left","CR23_00_0_0012","CR23_00_0_0013","CR23_00_0_0014","CR23_00_0_0015","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("96_walking_rear","CR23_00_0_0016","CR23_00_0_0017","CR23_00_0_0018","CR23_00_0_0019","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("96_walking_rear_right","CR23_00_0_0012","CR23_00_0_0013","CR23_00_0_0014","CR23_00_0_0015","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("96_walking_right","CR23_00_0_0008","CR23_00_0_0009","CR23_00_0_0010","CR23_00_0_0011","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("96_walking_front_right","CR23_00_0_0004","CR23_00_0_0005","CR23_00_0_0006","CR23_00_0_0007","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("96_walking_front","CR23_00_0_0000","CR23_00_0_0001","CR23_00_0_0002","CR23_00_0_0003","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("96_walking_front_left","CR23_00_0_0024","CR23_00_0_0025","CR23_00_0_0026","CR23_00_0_0027","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("96_walking_left","CR23_00_0_0020","CR23_00_0_0021","CR23_00_0_0022","CR23_00_0_0023","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("96_walking_rear_left","CR23_00_0_0012","CR23_00_0_0013","CR23_00_0_0014","CR23_00_0_0015","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("96_attack_bash","CR23_00_0_0000","CR23_00_0_0001","CR23_00_0_0002","CR23_00_0_0003","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("96_attack_slash","CR23_00_0_0000","CR23_00_0_0001","CR23_00_0_0002","CR23_00_0_0003","CR23_00_0_0003","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("96_attack_thrust","CR23_00_0_0000","CR23_00_0_0001","CR23_00_0_0002","CR23_00_0_0003","CR23_00_0_0003","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("96_attack_secondary","CR23_00_0_0000","CR23_00_0_0001","CR23_00_0_0002","CR23_00_0_0003","CR23_00_0_0003","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("96_attack_unk","CR23_00_0_0000","CR23_00_0_0001","CR23_00_0_0002","CR23_00_0_0003","CR23_00_0_0003","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("96_death","CR23_01_0_0011","CR23_01_0_0012","CR23_01_0_0013","CR23_01_0_0014","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 33 - which is an_ice_golem//Animation #0 idle
				CreateAnimationUW("97_idle_rear","CR22_01_1_0023","CR22_01_1_0023","CR22_01_1_0023","CR22_01_1_0023","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("97_idle_rear_right","CR22_01_1_0022","CR22_01_1_0022","CR22_01_1_0022","CR22_01_1_0022","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("97_idle_right","CR22_01_1_0021","CR22_01_1_0021","CR22_01_1_0021","CR22_01_1_0021","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("97_idle_front_right","CR22_01_1_0020","CR22_01_1_0020","CR22_01_1_0020","CR22_01_1_0020","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("97_idle_front","CR22_01_1_0019","CR22_01_1_0019","CR22_01_1_0019","CR22_01_1_0019","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("97_idle_front_left","CR22_02_1_0002","CR22_02_1_0002","CR22_02_1_0002","CR22_02_1_0002","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("97_idle_left","CR22_02_1_0001","CR22_02_1_0001","CR22_02_1_0001","CR22_02_1_0001","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("97_idle_rear_left","CR22_02_1_0000","CR22_02_1_0000","CR22_02_1_0000","CR22_02_1_0000","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("97_walking_rear","CR22_00_1_0016","CR22_00_1_0017","CR22_00_1_0018","CR22_00_1_0019","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("97_walking_rear_right","CR22_00_1_0020","CR22_00_1_0021","CR22_00_1_0022","CR22_01_1_0000","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("97_walking_right","CR22_01_1_0001","CR22_01_1_0002","CR22_01_1_0003","CR22_01_1_0004","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("97_walking_front_right","CR22_01_1_0005","CR22_01_1_0006","CR22_01_1_0007","CR22_01_1_0008","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("97_walking_front","CR22_00_1_0000","CR22_00_1_0001","CR22_00_1_0002","CR22_00_1_0003","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("97_walking_front_left","CR22_00_1_0004","CR22_00_1_0005","CR22_00_1_0006","CR22_00_1_0007","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("97_walking_left","CR22_00_1_0008","CR22_00_1_0009","CR22_00_1_0010","CR22_00_1_0011","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("97_walking_rear_left","CR22_00_1_0015","CR22_00_1_0014","CR22_00_1_0013","CR22_00_1_0012","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("97_attack_bash","CR22_02_1_0008","CR22_02_1_0009","CR22_02_1_0008","CR22_02_1_0009","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("97_attack_slash","CR22_02_1_0003","CR22_02_1_0004","CR22_02_1_0005","CR22_02_1_0006","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("97_attack_thrust","CR22_02_1_0003","CR22_02_1_0004","CR22_02_1_0005","CR22_02_1_0006","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("97_attack_secondary","CR22_02_1_0003","CR22_02_1_0004","CR22_02_1_0005","CR22_02_1_0006","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("97_attack_unk","CR22_02_1_0003","CR22_02_1_0004","CR22_02_1_0005","CR22_02_1_0006","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("97_death","CR22_01_1_0015","CR22_01_1_0016","CR22_01_1_0017","CR22_01_1_0018","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 34 - which is a_dire_ghost//Animation #0 idle
				CreateAnimationUW("98_idle_rear","CR16_00_1_0004","CR16_00_1_0005","CR16_00_1_0006","CR16_00_1_0007","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("98_idle_rear_right","CR16_00_1_0008","CR16_00_1_0009","CR16_00_1_0010","CR16_00_1_0011","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("98_idle_right","CR16_00_1_0012","CR16_00_1_0013","CR16_00_1_0014","CR16_00_1_0015","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("98_idle_front_right","CR16_00_1_0016","CR16_00_1_0017","CR16_00_1_0018","CR16_00_1_0019","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("98_idle_front","CR16_00_1_0000","CR16_00_1_0001","CR16_00_1_0002","CR16_00_1_0001","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("98_idle_front_left","CR16_00_1_0028","CR16_00_1_0029","CR16_00_1_0030","CR16_00_1_0031","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("98_idle_left","CR16_00_1_0024","CR16_00_1_0025","CR16_00_1_0026","CR16_00_1_0027","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("98_idle_rear_left","CR16_00_1_0020","CR16_00_1_0021","CR16_00_1_0022","CR16_00_1_0023","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("98_walking_rear","CR16_00_1_0004","CR16_00_1_0005","CR16_00_1_0006","CR16_00_1_0007","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("98_walking_rear_right","CR16_00_1_0008","CR16_00_1_0009","CR16_00_1_0010","CR16_00_1_0011","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("98_walking_right","CR16_00_1_0012","CR16_00_1_0013","CR16_00_1_0014","CR16_00_1_0015","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("98_walking_front_right","CR16_00_1_0016","CR16_00_1_0017","CR16_00_1_0018","CR16_00_1_0019","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("98_walking_front","CR16_00_1_0000","CR16_00_1_0001","CR16_00_1_0002","CR16_00_1_0001","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("98_walking_front_left","CR16_00_1_0028","CR16_00_1_0029","CR16_00_1_0030","CR16_00_1_0031","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("98_walking_left","CR16_00_1_0024","CR16_00_1_0025","CR16_00_1_0026","CR16_00_1_0027","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("98_walking_rear_left","CR16_00_1_0020","CR16_00_1_0021","CR16_00_1_0022","CR16_00_1_0023","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("98_attack_bash","CR16_00_1_0036","CR16_00_1_0037","CR16_00_1_0038","CR16_00_1_0039","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("98_attack_slash","CR16_00_1_0040","CR16_00_1_0041","CR16_00_1_0042","CR16_00_1_0043","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("98_attack_thrust","CR16_00_1_0000","CR16_00_1_0001","CR16_00_1_0002","CR16_00_1_0001","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("98_attack_secondary","CR16_00_1_0000","CR16_00_1_0001","CR16_00_1_0002","CR16_00_1_0001","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("98_attack_unk","CR16_00_1_0000","CR16_00_1_0001","CR16_00_1_0002","CR16_00_1_0001","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("98_death","CR16_00_1_0032","CR16_00_1_0033","CR16_00_1_0034","CR16_00_1_0035","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 35 - which is a_reaper//Animation #0 idle
				CreateAnimationUW("99_idle_rear","CR24_00_0_0013","CR24_00_0_0013","CR24_00_0_0013","CR24_00_0_0013","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("99_idle_rear_right","CR24_01_0_0013","CR24_01_0_0013","CR24_01_0_0013","CR24_01_0_0013","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("99_idle_right","CR24_00_0_0010","CR24_00_0_0010","CR24_00_0_0010","CR24_00_0_0010","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("99_idle_front_right","CR24_01_0_0006","CR24_01_0_0006","CR24_01_0_0006","CR24_01_0_0006","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("99_idle_front","CR24_00_0_0002","CR24_00_0_0002","CR24_00_0_0002","CR24_00_0_0002","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("99_idle_front_left","CR24_01_0_0002","CR24_01_0_0002","CR24_01_0_0002","CR24_01_0_0002","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("99_idle_left","CR24_00_0_0006","CR24_00_0_0006","CR24_00_0_0006","CR24_00_0_0006","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("99_idle_rear_left","CR24_01_0_0009","CR24_01_0_0009","CR24_01_0_0009","CR24_01_0_0009","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("99_walking_rear","CR24_00_0_0012","CR24_00_0_0013","CR24_00_0_0014","CR24_00_0_0015","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("99_walking_rear_right","CR24_01_0_0012","CR24_01_0_0013","CR24_01_0_0014","CR24_02_0_0000","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("99_walking_right","CR24_00_0_0008","CR24_00_0_0009","CR24_00_0_0010","CR24_00_0_0011","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("99_walking_front_right","CR24_01_0_0004","CR24_01_0_0005","CR24_01_0_0006","CR24_01_0_0007","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("99_walking_front","CR24_00_0_0000","CR24_00_0_0001","CR24_00_0_0002","CR24_00_0_0003","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("99_walking_front_left","CR24_01_0_0000","CR24_01_0_0001","CR24_01_0_0002","CR24_01_0_0003","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("99_walking_left","CR24_00_0_0004","CR24_00_0_0005","CR24_00_0_0006","CR24_00_0_0007","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("99_walking_rear_left","CR24_01_0_0008","CR24_01_0_0009","CR24_01_0_0010","CR24_01_0_0011","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("99_attack_bash","CR24_02_0_0010","CR24_02_0_0010","CR24_02_0_0011","CR24_02_0_0011","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("99_attack_slash","CR24_02_0_0001","CR24_02_0_0002","CR24_02_0_0003","CR24_02_0_0001","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("99_attack_thrust","CR24_02_0_0004","CR24_02_0_0005","CR24_02_0_0006","CR24_02_0_0004","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("99_attack_secondary","CR24_02_0_0004","CR24_02_0_0005","CR24_02_0_0006","CR24_02_0_0004","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("99_attack_unk","CR24_02_0_0001","CR24_02_0_0002","CR24_02_0_0003","CR24_02_0_0001","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("99_death","CR24_00_0_0002","CR24_02_0_0007","CR24_02_0_0008","CR24_02_0_0009","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 36 - which is a_despoiler//Animation #0 idle
				CreateAnimationUW("100_idle_rear","CR21_01_1_0012","CR21_01_1_0012","CR21_01_1_0012","CR21_01_1_0012","CR21_01_1_0012","CR21_01_1_0012", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("100_idle_rear_right","CR21_02_1_0004","CR21_02_1_0004","CR21_02_1_0004","CR21_02_1_0004","CR21_02_1_0004","CR21_02_1_0004", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("100_idle_right","CR21_02_1_0008","CR21_02_1_0008","CR21_02_1_0008","CR21_02_1_0008","CR21_02_1_0008","CR21_02_1_0008", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("100_idle_front_right","CR21_02_1_0014","CR21_02_1_0014","CR21_02_1_0014","CR21_02_1_0014","CR21_02_1_0014","CR21_02_1_0014", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("100_idle_front","CR21_03_1_0003","CR21_03_1_0004","CR21_03_1_0005","CR21_03_1_0006","CR21_03_1_0007","CR21_03_1_0008", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("100_idle_front_left","CR21_00_1_0010","CR21_00_1_0010","CR21_00_1_0010","CR21_00_1_0010","CR21_00_1_0010","CR21_00_1_0010", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("100_idle_left","CR21_01_1_0002","CR21_01_1_0002","CR21_01_1_0002","CR21_01_1_0002","CR21_01_1_0002","CR21_01_1_0002", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("100_idle_rear_left","CR21_01_1_0007","CR21_01_1_0007","CR21_01_1_0007","CR21_01_1_0007","CR21_01_1_0007","CR21_01_1_0007", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("100_walking_rear","CR21_01_1_0010","CR21_01_1_0011","CR21_01_1_0012","CR21_01_1_0013","CR21_01_1_0014","CR21_02_1_0000", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("100_walking_rear_right","CR21_02_1_0001","CR21_02_1_0002","CR21_02_1_0003","CR21_02_1_0004","CR21_02_1_0005","CR21_02_1_0006", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("100_walking_right","CR21_02_1_0007","CR21_02_1_0008","CR21_02_1_0009","CR21_02_1_0010","CR21_02_1_0011","CR21_02_1_0012", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("100_walking_front_right","CR21_02_1_0013","CR21_02_1_0014","CR21_02_1_0015","CR21_03_1_0000","CR21_03_1_0001","CR21_03_1_0002", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("100_walking_front","CR21_00_1_0000","CR21_00_1_0001","CR21_00_1_0002","CR21_00_1_0003","CR21_00_1_0004","CR21_00_1_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("100_walking_front_left","CR21_00_1_0006","CR21_00_1_0007","CR21_00_1_0008","CR21_00_1_0009","CR21_00_1_0010","CR21_00_1_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("100_walking_left","CR21_00_1_0012","CR21_00_1_0013","CR21_01_1_0000","CR21_01_1_0001","CR21_01_1_0002","CR21_01_1_0003", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("100_walking_rear_left","CR21_01_1_0004","CR21_01_1_0005","CR21_01_1_0006","CR21_01_1_0007","CR21_01_1_0008","CR21_01_1_0009", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("100_attack_bash","CR21_03_1_0009","CR21_03_1_0010","CR21_03_1_0011","CR21_03_1_0012","CR21_04_1_0000","CR21_04_1_0001", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("100_attack_slash","CR21_04_1_0002","CR21_04_1_0003","CR21_04_1_0004","CR21_04_1_0005","CR21_04_1_0006","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("100_attack_thrust","CR21_04_1_0002","CR21_04_1_0003","CR21_04_1_0004","CR21_04_1_0005","CR21_04_1_0006","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("100_attack_secondary","CR21_04_1_0007","CR21_04_1_0008","CR21_04_1_0009","CR21_04_1_0010","CR21_04_1_0011","CR21_04_1_0012", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("100_attack_unk","CR21_04_1_0007","CR21_04_1_0008","CR21_04_1_0009","CR21_04_1_0010","CR21_04_1_0011","CR21_04_1_0012", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("100_death","CR21_05_1_0000","CR21_05_1_0001","CR21_05_1_0002","CR21_05_1_0003","CR21_05_1_0004","", 5, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 37 - which is a_metal_golem//Animation #0 idle
				CreateAnimationUW("101_idle_rear","CR22_01_2_0023","CR22_01_2_0023","CR22_01_2_0023","CR22_01_2_0023","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("101_idle_rear_right","CR22_01_2_0022","CR22_01_2_0022","CR22_01_2_0022","CR22_01_2_0022","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("101_idle_right","CR22_01_2_0021","CR22_01_2_0021","CR22_01_2_0021","CR22_01_2_0021","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("101_idle_front_right","CR22_01_2_0020","CR22_01_2_0020","CR22_01_2_0020","CR22_01_2_0020","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("101_idle_front","CR22_01_2_0019","CR22_01_2_0019","CR22_01_2_0019","CR22_01_2_0019","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("101_idle_front_left","CR22_02_2_0002","CR22_02_2_0002","CR22_02_2_0002","CR22_02_2_0002","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("101_idle_left","CR22_02_2_0001","CR22_02_2_0001","CR22_02_2_0001","CR22_02_2_0001","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("101_idle_rear_left","CR22_02_2_0000","CR22_02_2_0000","CR22_02_2_0000","CR22_02_2_0000","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("101_walking_rear","CR22_00_2_0016","CR22_00_2_0017","CR22_00_2_0018","CR22_00_2_0019","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("101_walking_rear_right","CR22_00_2_0020","CR22_00_2_0021","CR22_00_2_0022","CR22_01_2_0000","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("101_walking_right","CR22_01_2_0001","CR22_01_2_0002","CR22_01_2_0003","CR22_01_2_0004","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("101_walking_front_right","CR22_01_2_0005","CR22_01_2_0006","CR22_01_2_0007","CR22_01_2_0008","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("101_walking_front","CR22_00_2_0000","CR22_00_2_0001","CR22_00_2_0002","CR22_00_2_0003","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("101_walking_front_left","CR22_00_2_0004","CR22_00_2_0005","CR22_00_2_0006","CR22_00_2_0007","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("101_walking_left","CR22_00_2_0008","CR22_00_2_0009","CR22_00_2_0010","CR22_00_2_0011","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("101_walking_rear_left","CR22_00_2_0015","CR22_00_2_0014","CR22_00_2_0013","CR22_00_2_0012","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("101_attack_bash","CR22_02_2_0008","CR22_02_2_0009","CR22_02_2_0008","CR22_02_2_0009","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("101_attack_slash","CR22_02_2_0003","CR22_02_2_0004","CR22_02_2_0005","CR22_02_2_0006","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("101_attack_thrust","CR22_02_2_0003","CR22_02_2_0004","CR22_02_2_0005","CR22_02_2_0006","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("101_attack_secondary","CR22_02_2_0003","CR22_02_2_0004","CR22_02_2_0005","CR22_02_2_0006","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("101_attack_unk","CR22_02_2_0003","CR22_02_2_0004","CR22_02_2_0005","CR22_02_2_0006","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("101_death","CR22_01_2_0015","CR22_01_2_0016","CR22_01_2_0017","CR22_01_2_0018","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 38 - which is a_haunt//Animation #0 idle
				CreateAnimationUW("102_idle_rear","CR16_00_2_0004","CR16_00_2_0005","CR16_00_2_0006","CR16_00_2_0007","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("102_idle_rear_right","CR16_00_2_0008","CR16_00_2_0009","CR16_00_2_0010","CR16_00_2_0011","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("102_idle_right","CR16_00_2_0012","CR16_00_2_0013","CR16_00_2_0014","CR16_00_2_0015","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("102_idle_front_right","CR16_00_2_0016","CR16_00_2_0017","CR16_00_2_0018","CR16_00_2_0019","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("102_idle_front","CR16_00_2_0000","CR16_00_2_0001","CR16_00_2_0002","CR16_00_2_0001","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("102_idle_front_left","CR16_00_2_0028","CR16_00_2_0029","CR16_00_2_0030","CR16_00_2_0031","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("102_idle_left","CR16_00_2_0024","CR16_00_2_0025","CR16_00_2_0026","CR16_00_2_0027","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("102_idle_rear_left","CR16_00_2_0020","CR16_00_2_0021","CR16_00_2_0022","CR16_00_2_0023","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("102_walking_rear","CR16_00_2_0004","CR16_00_2_0005","CR16_00_2_0006","CR16_00_2_0007","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("102_walking_rear_right","CR16_00_2_0008","CR16_00_2_0009","CR16_00_2_0010","CR16_00_2_0011","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("102_walking_right","CR16_00_2_0012","CR16_00_2_0013","CR16_00_2_0014","CR16_00_2_0015","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("102_walking_front_right","CR16_00_2_0016","CR16_00_2_0017","CR16_00_2_0018","CR16_00_2_0019","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("102_walking_front","CR16_00_2_0000","CR16_00_2_0001","CR16_00_2_0002","CR16_00_2_0001","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("102_walking_front_left","CR16_00_2_0028","CR16_00_2_0029","CR16_00_2_0030","CR16_00_2_0031","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("102_walking_left","CR16_00_2_0024","CR16_00_2_0025","CR16_00_2_0026","CR16_00_2_0027","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("102_walking_rear_left","CR16_00_2_0020","CR16_00_2_0021","CR16_00_2_0022","CR16_00_2_0023","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("102_attack_bash","CR16_00_2_0036","CR16_00_2_0037","CR16_00_2_0038","CR16_00_2_0039","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("102_attack_slash","CR16_00_2_0040","CR16_00_2_0041","CR16_00_2_0042","CR16_00_2_0043","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("102_attack_thrust","CR16_00_2_0000","CR16_00_2_0001","CR16_00_2_0002","CR16_00_2_0001","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("102_attack_secondary","CR16_00_2_0000","CR16_00_2_0001","CR16_00_2_0002","CR16_00_2_0001","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("102_attack_unk","CR16_00_2_0000","CR16_00_2_0001","CR16_00_2_0002","CR16_00_2_0001","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("102_death","CR16_00_2_0032","CR16_00_2_0033","CR16_00_2_0034","CR16_00_2_0035","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 39 - which is a_dire_reaper//Animation #0 idle
				CreateAnimationUW("103_idle_rear","CR24_00_1_0013","CR24_00_1_0013","CR24_00_1_0013","CR24_00_1_0013","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("103_idle_rear_right","CR24_01_1_0013","CR24_01_1_0013","CR24_01_1_0013","CR24_01_1_0013","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("103_idle_right","CR24_00_1_0010","CR24_00_1_0010","CR24_00_1_0010","CR24_00_1_0010","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("103_idle_front_right","CR24_01_1_0006","CR24_01_1_0006","CR24_01_1_0006","CR24_01_1_0006","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("103_idle_front","CR24_00_1_0002","CR24_00_1_0002","CR24_00_1_0002","CR24_00_1_0002","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("103_idle_front_left","CR24_01_1_0002","CR24_01_1_0002","CR24_01_1_0002","CR24_01_1_0002","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("103_idle_left","CR24_00_1_0006","CR24_00_1_0006","CR24_00_1_0006","CR24_00_1_0006","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("103_idle_rear_left","CR24_01_1_0009","CR24_01_1_0009","CR24_01_1_0009","CR24_01_1_0009","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("103_walking_rear","CR24_00_1_0012","CR24_00_1_0013","CR24_00_1_0014","CR24_00_1_0015","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("103_walking_rear_right","CR24_01_1_0012","CR24_01_1_0013","CR24_01_1_0014","CR24_02_1_0000","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("103_walking_right","CR24_00_1_0008","CR24_00_1_0009","CR24_00_1_0010","CR24_00_1_0011","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("103_walking_front_right","CR24_01_1_0004","CR24_01_1_0005","CR24_01_1_0006","CR24_01_1_0007","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("103_walking_front","CR24_00_1_0000","CR24_00_1_0001","CR24_00_1_0002","CR24_00_1_0003","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("103_walking_front_left","CR24_01_1_0000","CR24_01_1_0001","CR24_01_1_0002","CR24_01_1_0003","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("103_walking_left","CR24_00_1_0004","CR24_00_1_0005","CR24_00_1_0006","CR24_00_1_0007","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("103_walking_rear_left","CR24_01_1_0008","CR24_01_1_0009","CR24_01_1_0010","CR24_01_1_0011","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("103_attack_bash","CR24_02_1_0010","CR24_02_1_0010","CR24_02_1_0011","CR24_02_1_0011","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("103_attack_slash","CR24_02_1_0001","CR24_02_1_0002","CR24_02_1_0003","CR24_02_1_0001","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("103_attack_thrust","CR24_02_1_0004","CR24_02_1_0005","CR24_02_1_0006","CR24_02_1_0004","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("103_attack_secondary","CR24_02_1_0004","CR24_02_1_0005","CR24_02_1_0006","CR24_02_1_0004","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("103_attack_unk","CR24_02_1_0001","CR24_02_1_0002","CR24_02_1_0003","CR24_02_1_0001","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("103_death","CR24_00_1_0002","CR24_02_1_0007","CR24_02_1_0008","CR24_02_1_0009","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 40 - which is a_destroyer//Animation #0 idle
				CreateAnimationUW("104_idle_rear","CR21_01_2_0012","CR21_01_2_0012","CR21_01_2_0012","CR21_01_2_0012","CR21_01_2_0012","CR21_01_2_0012", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("104_idle_rear_right","CR21_02_2_0004","CR21_02_2_0004","CR21_02_2_0004","CR21_02_2_0004","CR21_02_2_0004","CR21_02_2_0004", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("104_idle_right","CR21_02_2_0008","CR21_02_2_0008","CR21_02_2_0008","CR21_02_2_0008","CR21_02_2_0008","CR21_02_2_0008", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("104_idle_front_right","CR21_02_2_0014","CR21_02_2_0014","CR21_02_2_0014","CR21_02_2_0014","CR21_02_2_0014","CR21_02_2_0014", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("104_idle_front","CR21_03_2_0003","CR21_03_2_0004","CR21_03_2_0005","CR21_03_2_0006","CR21_03_2_0007","CR21_03_2_0008", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("104_idle_front_left","CR21_00_2_0010","CR21_00_2_0010","CR21_00_2_0010","CR21_00_2_0010","CR21_00_2_0010","CR21_00_2_0010", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("104_idle_left","CR21_01_2_0002","CR21_01_2_0002","CR21_01_2_0002","CR21_01_2_0002","CR21_01_2_0002","CR21_01_2_0002", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("104_idle_rear_left","CR21_01_2_0007","CR21_01_2_0007","CR21_01_2_0007","CR21_01_2_0007","CR21_01_2_0007","CR21_01_2_0007", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("104_walking_rear","CR21_01_2_0010","CR21_01_2_0011","CR21_01_2_0012","CR21_01_2_0013","CR21_01_2_0014","CR21_02_2_0000", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("104_walking_rear_right","CR21_02_2_0001","CR21_02_2_0002","CR21_02_2_0003","CR21_02_2_0004","CR21_02_2_0005","CR21_02_2_0006", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("104_walking_right","CR21_02_2_0007","CR21_02_2_0008","CR21_02_2_0009","CR21_02_2_0010","CR21_02_2_0011","CR21_02_2_0012", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("104_walking_front_right","CR21_02_2_0013","CR21_02_2_0014","CR21_02_2_0015","CR21_03_2_0000","CR21_03_2_0001","CR21_03_2_0002", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("104_walking_front","CR21_00_2_0000","CR21_00_2_0001","CR21_00_2_0002","CR21_00_2_0003","CR21_00_2_0004","CR21_00_2_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("104_walking_front_left","CR21_00_2_0006","CR21_00_2_0007","CR21_00_2_0008","CR21_00_2_0009","CR21_00_2_0010","CR21_00_2_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("104_walking_left","CR21_00_2_0012","CR21_00_2_0013","CR21_01_2_0000","CR21_01_2_0001","CR21_01_2_0002","CR21_01_2_0003", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("104_walking_rear_left","CR21_01_2_0004","CR21_01_2_0005","CR21_01_2_0006","CR21_01_2_0007","CR21_01_2_0008","CR21_01_2_0009", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("104_attack_bash","CR21_03_2_0009","CR21_03_2_0010","CR21_03_2_0011","CR21_03_2_0012","CR21_04_2_0000","CR21_04_2_0001", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("104_attack_slash","CR21_04_2_0002","CR21_04_2_0003","CR21_04_2_0004","CR21_04_2_0005","CR21_04_2_0006","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("104_attack_thrust","CR21_04_2_0002","CR21_04_2_0003","CR21_04_2_0004","CR21_04_2_0005","CR21_04_2_0006","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("104_attack_secondary","CR21_04_2_0007","CR21_04_2_0008","CR21_04_2_0009","CR21_04_2_0010","CR21_04_2_0011","CR21_04_2_0012", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("104_attack_unk","CR21_04_2_0007","CR21_04_2_0008","CR21_04_2_0009","CR21_04_2_0010","CR21_04_2_0011","CR21_04_2_0012", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("104_death","CR21_05_2_0000","CR21_05_2_0001","CR21_05_2_0002","CR21_05_2_0003","CR21_05_2_0004","", 5, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 41 - which is a_liche//Animation #0 idle
				CreateAnimationUW("105_idle_rear","CR25_00_1_0026","CR25_00_1_0026","CR25_00_1_0026","CR25_00_1_0026","CR25_00_1_0026","CR25_00_1_0026", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("105_idle_rear_right","CR25_00_1_0032","CR25_00_1_0032","CR25_00_1_0032","CR25_00_1_0032","CR25_00_1_0032","CR25_00_1_0032", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("105_idle_right","CR25_01_1_0000","CR25_01_1_0000","CR25_01_1_0000","CR25_01_1_0000","CR25_01_1_0000","CR25_01_1_0000", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("105_idle_front_right","CR25_01_1_0008","CR25_01_1_0008","CR25_01_1_0008","CR25_01_1_0008","CR25_01_1_0008","CR25_01_1_0008", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("105_idle_front","CR25_01_1_0010","CR25_01_1_0011","CR25_01_1_0012","CR25_01_1_0013","CR25_01_1_0014","CR25_01_1_0015", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("105_idle_front_left","CR25_00_1_0007","CR25_00_1_0007","CR25_00_1_0007","CR25_00_1_0007","CR25_00_1_0007","CR25_00_1_0007", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("105_idle_left","CR25_00_1_0014","CR25_00_1_0014","CR25_00_1_0014","CR25_00_1_0014","CR25_00_1_0014","CR25_00_1_0014", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("105_idle_rear_left","CR25_00_1_0023","CR25_00_1_0023","CR25_00_1_0023","CR25_00_1_0023","CR25_00_1_0023","CR25_00_1_0023", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("105_walking_rear","CR25_00_1_0024","CR25_00_1_0025","CR25_00_1_0026","CR25_00_1_0027","CR25_00_1_0028","CR25_00_1_0029", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("105_walking_rear_right","CR25_00_1_0030","CR25_00_1_0031","CR25_00_1_0032","CR25_00_1_0033","CR25_00_1_0034","CR25_00_1_0035", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("105_walking_right","CR25_00_1_0036","CR25_00_1_0037","CR25_01_1_0000","CR25_01_1_0001","CR25_01_1_0002","CR25_01_1_0003", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("105_walking_front_right","CR25_01_1_0004","CR25_01_1_0005","CR25_01_1_0006","CR25_01_1_0007","CR25_01_1_0008","CR25_01_1_0009", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("105_walking_front","CR25_00_1_0000","CR25_00_1_0001","CR25_00_1_0002","CR25_00_1_0003","CR25_00_1_0004","CR25_00_1_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("105_walking_front_left","CR25_00_1_0006","CR25_00_1_0007","CR25_00_1_0008","CR25_00_1_0009","CR25_00_1_0010","CR25_00_1_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("105_walking_left","CR25_00_1_0012","CR25_00_1_0013","CR25_00_1_0014","CR25_00_1_0015","CR25_00_1_0016","CR25_00_1_0017", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("105_walking_rear_left","CR25_00_1_0018","CR25_00_1_0019","CR25_00_1_0020","CR25_00_1_0021","CR25_00_1_0022","CR25_00_1_0023", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("105_attack_bash","CR25_01_1_0022","CR25_01_1_0022","CR25_01_1_0022","CR25_01_1_0022","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("105_attack_slash","CR25_01_1_0022","CR25_01_1_0023","CR25_01_1_0024","CR25_01_1_0025","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("105_attack_thrust","CR25_01_1_0022","CR25_01_1_0023","CR25_01_1_0024","CR25_01_1_0025","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("105_attack_secondary","CR25_01_1_0022","CR25_01_1_0023","CR25_01_1_0024","CR25_01_1_0025","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("105_attack_unk","CR25_01_1_0022","CR25_01_1_0023","CR25_01_1_0024","CR25_01_1_0025","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("105_death","CR25_01_1_0016","CR25_01_1_0017","CR25_01_1_0018","CR25_01_1_0019","CR25_01_1_0020","CR25_01_1_0021", 6, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 42 - which is a_liche//Animation #0 idle
				CreateAnimationUW("106_idle_rear","CR05_00_1_0029","CR05_00_1_0029","CR05_00_1_0029","CR05_00_1_0029","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("106_idle_rear_right","CR05_00_1_0031","CR05_00_1_0031","CR05_00_1_0031","CR05_00_1_0031","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("106_idle_right","CR05_00_1_0037","CR05_00_1_0037","CR05_00_1_0037","CR05_00_1_0037","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("106_idle_front_right","CR05_01_1_0001","CR05_01_1_0001","CR05_01_1_0001","CR05_01_1_0001","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("106_idle_front","CR05_01_1_0004","CR05_01_1_0005","CR05_01_1_0006","CR05_01_1_0007","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("106_idle_front_left","CR05_00_1_0010","CR05_00_1_0010","CR05_00_1_0010","CR05_00_1_0010","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("106_idle_left","CR05_00_1_0013","CR05_00_1_0013","CR05_00_1_0013","CR05_00_1_0013","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("106_idle_rear_left","CR05_00_1_0019","CR05_00_1_0019","CR05_00_1_0019","CR05_00_1_0019","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("106_walking_rear","CR05_00_1_0025","CR05_00_1_0026","CR05_00_1_0027","CR05_00_1_0028","CR05_00_1_0029","CR05_00_1_0030", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("106_walking_rear_right","CR05_00_1_0031","CR05_00_1_0032","CR05_00_1_0033","CR05_00_1_0034","CR05_00_1_0035","CR05_00_1_0036", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("106_walking_right","CR05_00_1_0037","CR05_00_1_0038","CR05_00_1_0039","CR05_00_1_0040","CR05_00_1_0041","CR05_00_1_0042", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("106_walking_front_right","CR05_00_1_0043","CR05_00_1_0044","CR05_01_1_0000","CR05_01_1_0001","CR05_01_1_0002","CR05_01_1_0003", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("106_walking_front","CR05_00_1_0001","CR05_00_1_0002","CR05_00_1_0003","CR05_00_1_0004","CR05_00_1_0005","CR05_00_1_0006", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("106_walking_front_left","CR05_00_1_0007","CR05_00_1_0008","CR05_00_1_0009","CR05_00_1_0010","CR05_00_1_0011","CR05_00_1_0012", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("106_walking_left","CR05_00_1_0013","CR05_00_1_0014","CR05_00_1_0015","CR05_00_1_0016","CR05_00_1_0017","CR05_00_1_0018", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("106_walking_rear_left","CR05_00_1_0019","CR05_00_1_0020","CR05_00_1_0021","CR05_00_1_0022","CR05_00_1_0023","CR05_00_1_0024", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("106_attack_bash","CR05_01_1_0010","CR05_01_1_0011","CR05_01_1_0012","CR05_01_1_0011","CR05_01_1_0012","CR05_01_1_0011", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("106_attack_slash","CR05_01_1_0015","CR05_01_1_0016","CR05_01_1_0017","CR05_01_1_0018","CR05_01_1_0019","CR05_01_1_0018", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("106_attack_thrust","CR05_01_1_0015","CR05_01_1_0016","CR05_01_1_0017","CR05_01_1_0018","CR05_01_1_0019","CR05_01_1_0018", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("106_attack_secondary","CR05_01_1_0015","CR05_01_1_0016","CR05_01_1_0017","CR05_01_1_0018","CR05_01_1_0019","CR05_01_1_0018", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("106_attack_unk","CR05_01_1_0014","CR05_01_1_0015","CR05_01_1_0016","CR05_01_1_0017","CR05_01_1_0018","CR05_01_1_0019", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("106_death","CR05_01_1_0020","CR05_01_1_0021","CR05_01_1_0022","CR05_01_1_0023","CR05_01_1_0024","CR05_01_1_0025", 6, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 43 - which is a_liche//Animation #0 idle
				CreateAnimationUW("107_idle_rear","CR36_00_0_0029","CR36_00_0_0029","CR36_00_0_0029","CR36_00_0_0029","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("107_idle_rear_right","CR36_00_0_0030","CR36_00_0_0030","CR36_00_0_0030","CR36_00_0_0030","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("107_idle_right","CR36_01_0_0000","CR36_01_0_0000","CR36_01_0_0000","CR36_01_0_0000","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("107_idle_front_right","CR36_01_0_0009","CR36_01_0_0009","CR36_01_0_0009","CR36_01_0_0009","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("107_idle_front","CR36_01_0_0012","CR36_01_0_0013","CR36_01_0_0014","CR36_01_0_0015","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("107_idle_front_left","CR36_00_0_0009","CR36_00_0_0009","CR36_00_0_0009","CR36_00_0_0009","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("107_idle_left","CR36_00_0_0012","CR36_00_0_0012","CR36_00_0_0012","CR36_00_0_0012","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("107_idle_rear_left","CR36_00_0_0018","CR36_00_0_0018","CR36_00_0_0018","CR36_00_0_0018","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("107_walking_rear","CR36_00_0_0024","CR36_00_0_0025","CR36_00_0_0026","CR36_00_0_0027","CR36_00_0_0028","CR36_00_0_0029", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("107_walking_rear_right","CR36_00_0_0030","CR36_00_0_0031","CR36_00_0_0032","CR36_00_0_0033","CR36_00_0_0034","CR36_00_0_0035", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("107_walking_right","CR36_01_0_0000","CR36_01_0_0001","CR36_01_0_0002","CR36_01_0_0003","CR36_01_0_0004","CR36_01_0_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("107_walking_front_right","CR36_01_0_0006","CR36_01_0_0007","CR36_01_0_0008","CR36_01_0_0009","CR36_01_0_0010","CR36_01_0_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("107_walking_front","CR36_00_0_0000","CR36_00_0_0001","CR36_00_0_0002","CR36_00_0_0003","CR36_00_0_0004","CR36_00_0_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("107_walking_front_left","CR36_00_0_0006","CR36_00_0_0007","CR36_00_0_0008","CR36_00_0_0009","CR36_00_0_0010","CR36_00_0_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("107_walking_left","CR36_00_0_0012","CR36_00_0_0013","CR36_00_0_0014","CR36_00_0_0015","CR36_00_0_0016","CR36_00_0_0017", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("107_walking_rear_left","CR36_00_0_0018","CR36_00_0_0019","CR36_00_0_0020","CR36_00_0_0021","CR36_00_0_0022","CR36_00_0_0023", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("107_attack_bash","CR36_01_0_0016","CR36_01_0_0017","CR36_01_0_0018","CR36_01_0_0019","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("107_attack_slash","CR36_01_0_0020","CR36_01_0_0021","CR36_01_0_0022","CR36_01_0_0023","CR36_01_0_0024","CR36_01_0_0025", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("107_attack_thrust","CR36_01_0_0026","CR36_01_0_0027","CR36_01_0_0028","CR36_01_0_0029","CR36_01_0_0030","CR36_01_0_0031", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("107_attack_secondary","CR36_01_0_0026","CR36_01_0_0027","CR36_01_0_0028","CR36_01_0_0029","CR36_01_0_0030","CR36_01_0_0031", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("107_attack_unk","CR36_01_0_0032","CR36_01_0_0033","CR36_02_0_0000","CR36_02_0_0001","CR36_02_0_0002","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("107_death","CR36_02_0_0003","CR36_02_0_0004","CR36_02_0_0005","CR36_02_0_0006","CR36_02_0_0007","CR36_02_0_0008", 6, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 44 - which is a_human//Animation #0 idle
				CreateAnimationUW("108_idle_rear","CR30_00_2_0026","CR30_00_2_0026","CR30_00_2_0026","CR30_00_2_0026","CR30_00_2_0026","CR30_00_2_0026", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("108_idle_rear_right","CR30_00_2_0034","CR30_00_2_0034","CR30_00_2_0034","CR30_00_2_0034","CR30_00_2_0034","CR30_00_2_0034", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("108_idle_right","CR30_00_2_0037","CR30_00_2_0037","CR30_00_2_0037","CR30_00_2_0037","CR30_00_2_0037","CR30_00_2_0037", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("108_idle_front_right","CR30_01_2_0008","CR30_01_2_0008","CR30_01_2_0008","CR30_01_2_0008","CR30_01_2_0008","CR30_01_2_0008", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("108_idle_front","CR30_01_2_0027","CR30_01_2_0028","CR30_01_2_0029","CR30_01_2_0030","CR30_01_2_0031","CR30_01_2_0032", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("108_idle_front_left","CR30_00_2_0010","CR30_00_2_0010","CR30_00_2_0010","CR30_00_2_0010","CR30_00_2_0010","CR30_00_2_0010", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("108_idle_left","CR30_00_2_0014","CR30_00_2_0014","CR30_00_2_0014","CR30_00_2_0014","CR30_00_2_0014","CR30_00_2_0014", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("108_idle_rear_left","CR30_00_2_0020","CR30_00_2_0020","CR30_00_2_0020","CR30_00_2_0020","CR30_00_2_0020","CR30_00_2_0020", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("108_walking_rear","CR30_00_2_0024","CR30_00_2_0025","CR30_00_2_0026","CR30_00_2_0027","CR30_00_2_0028","CR30_00_2_0029", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("108_walking_rear_right","CR30_00_2_0030","CR30_00_2_0031","CR30_00_2_0032","CR30_00_2_0033","CR30_00_2_0034","CR30_00_2_0035", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("108_walking_right","CR30_00_2_0036","CR30_00_2_0037","CR30_00_2_0038","CR30_01_2_0000","CR30_01_2_0001","CR30_01_2_0002", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("108_walking_front_right","CR30_01_2_0003","CR30_01_2_0004","CR30_01_2_0005","CR30_01_2_0006","CR30_01_2_0007","CR30_01_2_0008", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("108_walking_front","CR30_00_2_0000","CR30_00_2_0001","CR30_00_2_0002","CR30_00_2_0003","CR30_00_2_0004","CR30_00_2_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("108_walking_front_left","CR30_00_2_0006","CR30_00_2_0007","CR30_00_2_0008","CR30_00_2_0009","CR30_00_2_0010","CR30_00_2_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("108_walking_left","CR30_00_2_0012","CR30_00_2_0013","CR30_00_2_0014","CR30_00_2_0015","CR30_00_2_0016","CR30_00_2_0017", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("108_walking_rear_left","CR30_00_2_0018","CR30_00_2_0019","CR30_00_2_0020","CR30_00_2_0021","CR30_00_2_0022","CR30_00_2_0023", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("108_attack_bash","CR30_01_2_0009","CR30_01_2_0010","CR30_01_2_0011","CR30_01_2_0012","CR30_01_2_0013","CR30_01_2_0014", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("108_attack_slash","CR30_01_2_0015","CR30_01_2_0016","CR30_01_2_0017","CR30_01_2_0018","CR30_01_2_0019","CR30_01_2_0020", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("108_attack_thrust","CR30_01_2_0015","CR30_01_2_0016","CR30_01_2_0017","CR30_01_2_0018","CR30_01_2_0019","CR30_01_2_0020", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("108_attack_secondary","CR30_01_2_0021","CR30_01_2_0022","CR30_01_2_0023","CR30_01_2_0024","CR30_01_2_0025","CR30_01_2_0026", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("108_attack_unk","CR30_01_2_0021","CR30_01_2_0022","CR30_01_2_0023","CR30_01_2_0024","CR30_01_2_0025","CR30_01_2_0026", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("108_death","CR30_01_2_0032","CR30_01_2_0033","CR30_01_2_0034","CR30_01_2_0035","CR30_01_2_0036","", 5, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 45 - which is a_vorz//Animation #0 idle
				CreateAnimationUW("109_idle_rear","CR13_01_0_0002","CR13_01_0_0003","CR13_01_0_0004","CR13_01_0_0005","CR13_01_0_0006","CR13_01_0_0007", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("109_idle_rear_right","CR13_01_0_0008","CR13_01_0_0009","CR13_01_0_0010","CR13_01_0_0011","CR13_01_0_0012","CR13_01_0_0013", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("109_idle_right","CR13_01_0_0014","CR13_01_0_0015","CR13_01_0_0016","CR13_01_0_0017","CR13_01_0_0018","CR13_01_0_0019", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("109_idle_front_right","CR13_01_0_0020","CR13_01_0_0021","CR13_01_0_0022","CR13_02_0_0000","CR13_02_0_0001","CR13_02_0_0002", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("109_idle_front","CR13_02_0_0003","CR13_02_0_0004","CR13_02_0_0005","CR13_02_0_0006","CR13_02_0_0007","CR13_02_0_0008", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("109_idle_front_left","CR13_00_0_0006","CR13_00_0_0007","CR13_00_0_0008","CR13_00_0_0009","CR13_00_0_0010","CR13_00_0_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("109_idle_left","CR13_00_0_0012","CR13_00_0_0013","CR13_00_0_0014","CR13_00_0_0015","CR13_00_0_0016","CR13_00_0_0017", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("109_idle_rear_left","CR13_00_0_0018","CR13_00_0_0019","CR13_00_0_0020","CR13_00_0_0021","CR13_01_0_0000","CR13_01_0_0001", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("109_walking_rear","CR13_01_0_0002","CR13_01_0_0003","CR13_01_0_0004","CR13_01_0_0005","CR13_01_0_0006","CR13_01_0_0007", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("109_walking_rear_right","CR13_01_0_0008","CR13_01_0_0009","CR13_01_0_0010","CR13_01_0_0011","CR13_01_0_0012","CR13_01_0_0013", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("109_walking_right","CR13_01_0_0014","CR13_01_0_0015","CR13_01_0_0016","CR13_01_0_0017","CR13_01_0_0018","CR13_01_0_0019", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("109_walking_front_right","CR13_01_0_0020","CR13_01_0_0021","CR13_01_0_0022","CR13_02_0_0000","CR13_02_0_0001","CR13_02_0_0002", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("109_walking_front","CR13_00_0_0000","CR13_00_0_0001","CR13_00_0_0002","CR13_00_0_0003","CR13_00_0_0004","CR13_00_0_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("109_walking_front_left","CR13_00_0_0006","CR13_00_0_0007","CR13_00_0_0008","CR13_00_0_0009","CR13_00_0_0010","CR13_00_0_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("109_walking_left","CR13_00_0_0012","CR13_00_0_0013","CR13_00_0_0014","CR13_00_0_0015","CR13_00_0_0016","CR13_00_0_0017", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("109_walking_rear_left","CR13_00_0_0018","CR13_00_0_0019","CR13_00_0_0020","CR13_00_0_0021","CR13_01_0_0000","CR13_01_0_0001", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("109_attack_bash","CR13_02_0_0009","CR13_02_0_0010","CR13_02_0_0011","CR13_02_0_0012","CR13_02_0_0013","CR13_02_0_0014", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("109_attack_slash","CR13_02_0_0015","CR13_02_0_0016","CR13_02_0_0017","CR13_02_0_0018","CR13_03_0_0000","CR13_03_0_0001", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("109_attack_thrust","CR13_03_0_0002","CR13_03_0_0003","CR13_03_0_0004","CR13_03_0_0005","CR13_03_0_0006","CR13_03_0_0007", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("109_attack_secondary","CR13_03_0_0002","CR13_03_0_0003","CR13_03_0_0004","CR13_03_0_0005","CR13_03_0_0006","CR13_03_0_0007", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("109_attack_unk","CR13_03_0_0002","CR13_03_0_0003","CR13_03_0_0004","CR13_03_0_0005","CR13_03_0_0006","CR13_03_0_0007", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("109_death","CR13_03_0_0008","CR13_03_0_0009","CR13_03_0_0010","CR13_03_0_0011","CR13_03_0_0012","CR13_03_0_0013", 6, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 46 - which is a_fighter//Animation #0 idle
				CreateAnimationUW("110_idle_rear","CR30_00_1_0026","CR30_00_1_0026","CR30_00_1_0026","CR30_00_1_0026","CR30_00_1_0026","CR30_00_1_0026", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("110_idle_rear_right","CR30_00_1_0034","CR30_00_1_0034","CR30_00_1_0034","CR30_00_1_0034","CR30_00_1_0034","CR30_00_1_0034", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("110_idle_right","CR30_00_1_0037","CR30_00_1_0037","CR30_00_1_0037","CR30_00_1_0037","CR30_00_1_0037","CR30_00_1_0037", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("110_idle_front_right","CR30_01_1_0008","CR30_01_1_0008","CR30_01_1_0008","CR30_01_1_0008","CR30_01_1_0008","CR30_01_1_0008", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("110_idle_front","CR30_01_1_0027","CR30_01_1_0028","CR30_01_1_0029","CR30_01_1_0030","CR30_01_1_0031","CR30_01_1_0032", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("110_idle_front_left","CR30_00_1_0010","CR30_00_1_0010","CR30_00_1_0010","CR30_00_1_0010","CR30_00_1_0010","CR30_00_1_0010", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("110_idle_left","CR30_00_1_0014","CR30_00_1_0014","CR30_00_1_0014","CR30_00_1_0014","CR30_00_1_0014","CR30_00_1_0014", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("110_idle_rear_left","CR30_00_1_0020","CR30_00_1_0020","CR30_00_1_0020","CR30_00_1_0020","CR30_00_1_0020","CR30_00_1_0020", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("110_walking_rear","CR30_00_1_0024","CR30_00_1_0025","CR30_00_1_0026","CR30_00_1_0027","CR30_00_1_0028","CR30_00_1_0029", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("110_walking_rear_right","CR30_00_1_0030","CR30_00_1_0031","CR30_00_1_0032","CR30_00_1_0033","CR30_00_1_0034","CR30_00_1_0035", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("110_walking_right","CR30_00_1_0036","CR30_00_1_0037","CR30_00_1_0038","CR30_01_1_0000","CR30_01_1_0001","CR30_01_1_0002", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("110_walking_front_right","CR30_01_1_0003","CR30_01_1_0004","CR30_01_1_0005","CR30_01_1_0006","CR30_01_1_0007","CR30_01_1_0008", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("110_walking_front","CR30_00_1_0000","CR30_00_1_0001","CR30_00_1_0002","CR30_00_1_0003","CR30_00_1_0004","CR30_00_1_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("110_walking_front_left","CR30_00_1_0006","CR30_00_1_0007","CR30_00_1_0008","CR30_00_1_0009","CR30_00_1_0010","CR30_00_1_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("110_walking_left","CR30_00_1_0012","CR30_00_1_0013","CR30_00_1_0014","CR30_00_1_0015","CR30_00_1_0016","CR30_00_1_0017", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("110_walking_rear_left","CR30_00_1_0018","CR30_00_1_0019","CR30_00_1_0020","CR30_00_1_0021","CR30_00_1_0022","CR30_00_1_0023", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("110_attack_bash","CR30_01_1_0009","CR30_01_1_0010","CR30_01_1_0011","CR30_01_1_0012","CR30_01_1_0013","CR30_01_1_0014", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("110_attack_slash","CR30_01_1_0015","CR30_01_1_0016","CR30_01_1_0017","CR30_01_1_0018","CR30_01_1_0019","CR30_01_1_0020", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("110_attack_thrust","CR30_01_1_0015","CR30_01_1_0016","CR30_01_1_0017","CR30_01_1_0018","CR30_01_1_0019","CR30_01_1_0020", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("110_attack_secondary","CR30_01_1_0021","CR30_01_1_0022","CR30_01_1_0023","CR30_01_1_0024","CR30_01_1_0025","CR30_01_1_0026", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("110_attack_unk","CR30_01_1_0021","CR30_01_1_0022","CR30_01_1_0023","CR30_01_1_0024","CR30_01_1_0025","CR30_01_1_0026", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("110_death","CR30_01_1_0032","CR30_01_1_0033","CR30_01_1_0034","CR30_01_1_0035","CR30_01_1_0036","", 5, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 47 - which is a_gazer//Animation #0 idle
				CreateAnimationUW("111_idle_rear","CR35_00_0_0012","CR35_00_0_0013","CR35_00_0_0014","CR35_00_0_0013","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("111_idle_rear_right","CR35_00_0_0015","CR35_00_0_0016","CR35_00_0_0017","CR35_00_0_0016","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("111_idle_right","CR35_00_0_0018","CR35_00_0_0019","CR35_00_0_0020","CR35_00_0_0019","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("111_idle_front_right","CR35_00_0_0021","CR35_00_0_0022","CR35_00_0_0023","CR35_00_0_0022","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("111_idle_front","CR35_00_0_0000","CR35_00_0_0001","CR35_00_0_0002","CR35_00_0_0001","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("111_idle_front_left","CR35_00_0_0003","CR35_00_0_0004","CR35_00_0_0005","CR35_00_0_0004","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("111_idle_left","CR35_00_0_0006","CR35_00_0_0007","CR35_00_0_0008","CR35_00_0_0007","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("111_idle_rear_left","CR35_00_0_0009","CR35_00_0_0010","CR35_00_0_0011","CR35_00_0_0010","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("111_walking_rear","CR35_00_0_0012","CR35_00_0_0013","CR35_00_0_0014","CR35_00_0_0013","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("111_walking_rear_right","CR35_00_0_0015","CR35_00_0_0016","CR35_00_0_0017","CR35_00_0_0016","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("111_walking_right","CR35_00_0_0018","CR35_00_0_0019","CR35_00_0_0020","CR35_00_0_0019","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("111_walking_front_right","CR35_00_0_0021","CR35_00_0_0022","CR35_00_0_0023","CR35_00_0_0022","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("111_walking_front","CR35_00_0_0000","CR35_00_0_0001","CR35_00_0_0002","CR35_00_0_0001","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("111_walking_front_left","CR35_00_0_0003","CR35_00_0_0004","CR35_00_0_0005","CR35_00_0_0004","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("111_walking_left","CR35_00_0_0006","CR35_00_0_0007","CR35_00_0_0008","CR35_00_0_0007","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("111_walking_rear_left","CR35_00_0_0009","CR35_00_0_0010","CR35_00_0_0011","CR35_00_0_0010","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("111_attack_bash","CR35_00_0_0001","CR35_00_0_0035","CR35_00_0_0036","CR35_00_0_0035","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("111_attack_slash","CR35_00_0_0024","CR35_00_0_0025","CR35_00_0_0026","CR35_00_0_0027","CR35_00_0_0028","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("111_attack_thrust","CR35_00_0_0029","CR35_00_0_0030","CR35_00_0_0031","CR35_00_0_0032","CR35_00_0_0033","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("111_attack_secondary","CR35_00_0_0029","CR35_00_0_0030","CR35_00_0_0031","CR35_00_0_0032","CR35_00_0_0033","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("111_attack_unk","CR35_00_0_0034","CR35_00_0_0035","CR35_00_0_0036","CR35_00_0_0037","CR35_00_0_0038","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("111_death","CR35_01_0_0000","CR35_01_0_0001","CR35_01_0_0002","CR35_01_0_0003","CR35_01_0_0004","", 5, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 48 - which is a_human//Animation #0 idle
				CreateAnimationUW("112_idle_rear","CR32_00_0_0028","CR32_00_0_0028","CR32_00_0_0028","CR32_00_0_0028","CR32_00_0_0028","CR32_00_0_0028", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("112_idle_rear_right","CR32_00_0_0032","CR32_00_0_0032","CR32_00_0_0032","CR32_00_0_0032","CR32_00_0_0032","CR32_00_0_0032", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("112_idle_right","CR32_00_0_0038","CR32_00_0_0038","CR32_00_0_0038","CR32_00_0_0038","CR32_00_0_0038","CR32_00_0_0038", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("112_idle_front_right","CR32_01_0_0003","CR32_01_0_0003","CR32_01_0_0003","CR32_01_0_0003","CR32_01_0_0003","CR32_01_0_0003", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("112_idle_front","CR32_01_0_0020","CR32_01_0_0021","CR32_01_0_0022","CR32_01_0_0023","CR32_01_0_0024","CR32_01_0_0025", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("112_idle_front_left","CR32_00_0_0008","CR32_00_0_0008","CR32_00_0_0008","CR32_00_0_0008","CR32_00_0_0008","CR32_00_0_0008", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("112_idle_left","CR32_00_0_0014","CR32_00_0_0014","CR32_00_0_0014","CR32_00_0_0014","CR32_00_0_0014","CR32_00_0_0014", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("112_idle_rear_left","CR32_00_0_0020","CR32_00_0_0020","CR32_00_0_0020","CR32_00_0_0020","CR32_00_0_0020","CR32_00_0_0020", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("112_walking_rear","CR32_00_0_0024","CR32_00_0_0025","CR32_00_0_0026","CR32_00_0_0027","CR32_00_0_0028","CR32_00_0_0029", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("112_walking_rear_right","CR32_00_0_0030","CR32_00_0_0031","CR32_00_0_0032","CR32_00_0_0033","CR32_00_0_0034","CR32_00_0_0035", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("112_walking_right","CR32_00_0_0036","CR32_00_0_0037","CR32_00_0_0038","CR32_00_0_0039","CR32_01_0_0000","CR32_01_0_0001", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("112_walking_front_right","CR32_01_0_0002","CR32_01_0_0003","CR32_01_0_0004","CR32_01_0_0005","CR32_01_0_0006","CR32_01_0_0007", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("112_walking_front","CR32_00_0_0000","CR32_00_0_0001","CR32_00_0_0002","CR32_00_0_0003","CR32_00_0_0004","CR32_00_0_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("112_walking_front_left","CR32_00_0_0006","CR32_00_0_0007","CR32_00_0_0008","CR32_00_0_0009","CR32_00_0_0010","CR32_00_0_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("112_walking_left","CR32_00_0_0012","CR32_00_0_0013","CR32_00_0_0014","CR32_00_0_0015","CR32_00_0_0016","CR32_00_0_0017", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("112_walking_rear_left","CR32_00_0_0018","CR32_00_0_0019","CR32_00_0_0020","CR32_00_0_0021","CR32_00_0_0022","CR32_00_0_0023", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("112_attack_bash","CR32_01_0_0008","CR32_01_0_0009","CR32_01_0_0010","CR32_01_0_0011","CR32_01_0_0012","CR32_01_0_0013", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("112_attack_slash","CR32_01_0_0014","CR32_01_0_0015","CR32_01_0_0016","CR32_01_0_0017","CR32_01_0_0018","CR32_01_0_0019", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("112_attack_thrust","CR32_01_0_0014","CR32_01_0_0015","CR32_01_0_0016","CR32_01_0_0017","CR32_01_0_0018","CR32_01_0_0019", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("112_attack_secondary","CR32_01_0_0014","CR32_01_0_0015","CR32_01_0_0016","CR32_01_0_0017","CR32_01_0_0018","CR32_01_0_0019", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("112_attack_unk","CR32_01_0_0008","CR32_01_0_0009","CR32_01_0_0010","CR32_01_0_0011","CR32_01_0_0012","CR32_01_0_0013", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("112_death","CR32_01_0_0026","CR32_01_0_0027","CR32_01_0_0028","CR32_01_0_0029","CR32_01_0_0030","CR32_01_0_0031", 6, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 49 - which is a_human//Animation #0 idle
				CreateAnimationUW("113_idle_rear","CR33_00_0_0025","CR33_00_0_0025","CR33_00_0_0025","CR33_00_0_0025","CR33_00_0_0025","CR33_00_0_0025", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("113_idle_rear_right","CR33_00_0_0035","CR33_00_0_0035","CR33_00_0_0035","CR33_00_0_0035","CR33_00_0_0035","CR33_00_0_0035", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("113_idle_right","CR33_00_0_0038","CR33_00_0_0038","CR33_00_0_0038","CR33_00_0_0038","CR33_00_0_0038","CR33_00_0_0038", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("113_idle_front_right","CR33_01_0_0001","CR33_01_0_0001","CR33_01_0_0001","CR33_01_0_0001","CR33_01_0_0001","CR33_01_0_0001", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("113_idle_front","CR33_01_0_0017","CR33_01_0_0018","CR33_01_0_0019","CR33_01_0_0020","CR33_01_0_0021","CR33_01_0_0022", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("113_idle_front_left","CR33_00_0_0011","CR33_00_0_0011","CR33_00_0_0011","CR33_00_0_0011","CR33_00_0_0011","CR33_00_0_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("113_idle_left","CR33_00_0_0017","CR33_00_0_0017","CR33_00_0_0017","CR33_00_0_0017","CR33_00_0_0017","CR33_00_0_0017", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("113_idle_rear_left","CR33_00_0_0020","CR33_00_0_0020","CR33_00_0_0020","CR33_00_0_0020","CR33_00_0_0020","CR33_00_0_0020", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("113_walking_rear","CR33_00_0_0024","CR33_00_0_0025","CR33_00_0_0026","CR33_00_0_0027","CR33_00_0_0028","CR33_00_0_0029", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("113_walking_rear_right","CR33_00_0_0030","CR33_00_0_0031","CR33_00_0_0032","CR33_00_0_0033","CR33_00_0_0034","CR33_00_0_0035", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("113_walking_right","CR33_00_0_0036","CR33_00_0_0037","CR33_00_0_0038","CR33_00_0_0039","CR33_00_0_0040","CR33_00_0_0041", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("113_walking_front_right","CR33_00_0_0042","CR33_01_0_0000","CR33_01_0_0001","CR33_01_0_0002","CR33_01_0_0003","CR33_01_0_0004", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("113_walking_front","CR33_00_0_0000","CR33_00_0_0001","CR33_00_0_0002","CR33_00_0_0003","CR33_00_0_0004","CR33_00_0_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("113_walking_front_left","CR33_00_0_0006","CR33_00_0_0007","CR33_00_0_0008","CR33_00_0_0009","CR33_00_0_0010","CR33_00_0_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("113_walking_left","CR33_00_0_0012","CR33_00_0_0013","CR33_00_0_0014","CR33_00_0_0015","CR33_00_0_0016","CR33_00_0_0017", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("113_walking_rear_left","CR33_00_0_0018","CR33_00_0_0019","CR33_00_0_0020","CR33_00_0_0021","CR33_00_0_0022","CR33_00_0_0023", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("113_attack_bash","CR33_01_0_0005","CR33_01_0_0006","CR33_01_0_0007","CR33_01_0_0008","CR33_01_0_0009","CR33_01_0_0010", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("113_attack_slash","CR33_01_0_0011","CR33_01_0_0012","CR33_01_0_0013","CR33_01_0_0014","CR33_01_0_0015","CR33_01_0_0016", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("113_attack_thrust","CR33_01_0_0011","CR33_01_0_0012","CR33_01_0_0013","CR33_01_0_0014","CR33_01_0_0015","CR33_01_0_0016", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("113_attack_secondary","CR33_01_0_0011","CR33_01_0_0012","CR33_01_0_0013","CR33_01_0_0014","CR33_01_0_0015","CR33_01_0_0016", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("113_attack_unk","CR33_01_0_0011","CR33_01_0_0012","CR33_01_0_0013","CR33_01_0_0014","CR33_01_0_0015","CR33_01_0_0016", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("113_death","CR33_01_0_0023","CR33_01_0_0024","CR33_01_0_0025","CR33_01_0_0026","CR33_01_0_0027","CR33_01_0_0028", 6, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 50 - which is a_human//Animation #0 idle
				CreateAnimationUW("114_idle_rear","CR32_00_1_0028","CR32_00_1_0028","CR32_00_1_0028","CR32_00_1_0028","CR32_00_1_0028","CR32_00_1_0028", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("114_idle_rear_right","CR32_00_1_0032","CR32_00_1_0032","CR32_00_1_0032","CR32_00_1_0032","CR32_00_1_0032","CR32_00_1_0032", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("114_idle_right","CR32_00_1_0038","CR32_00_1_0038","CR32_00_1_0038","CR32_00_1_0038","CR32_00_1_0038","CR32_00_1_0038", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("114_idle_front_right","CR32_01_1_0003","CR32_01_1_0003","CR32_01_1_0003","CR32_01_1_0003","CR32_01_1_0003","CR32_01_1_0003", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("114_idle_front","CR32_01_1_0020","CR32_01_1_0021","CR32_01_1_0022","CR32_01_1_0023","CR32_01_1_0024","CR32_01_1_0025", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("114_idle_front_left","CR32_00_1_0008","CR32_00_1_0008","CR32_00_1_0008","CR32_00_1_0008","CR32_00_1_0008","CR32_00_1_0008", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("114_idle_left","CR32_00_1_0014","CR32_00_1_0014","CR32_00_1_0014","CR32_00_1_0014","CR32_00_1_0014","CR32_00_1_0014", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("114_idle_rear_left","CR32_00_1_0020","CR32_00_1_0020","CR32_00_1_0020","CR32_00_1_0020","CR32_00_1_0020","CR32_00_1_0020", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("114_walking_rear","CR32_00_1_0024","CR32_00_1_0025","CR32_00_1_0026","CR32_00_1_0027","CR32_00_1_0028","CR32_00_1_0029", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("114_walking_rear_right","CR32_00_1_0030","CR32_00_1_0031","CR32_00_1_0032","CR32_00_1_0033","CR32_00_1_0034","CR32_00_1_0035", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("114_walking_right","CR32_00_1_0036","CR32_00_1_0037","CR32_00_1_0038","CR32_00_1_0039","CR32_01_1_0000","CR32_01_1_0001", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("114_walking_front_right","CR32_01_1_0002","CR32_01_1_0003","CR32_01_1_0004","CR32_01_1_0005","CR32_01_1_0006","CR32_01_1_0007", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("114_walking_front","CR32_00_1_0000","CR32_00_1_0001","CR32_00_1_0002","CR32_00_1_0003","CR32_00_1_0004","CR32_00_1_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("114_walking_front_left","CR32_00_1_0006","CR32_00_1_0007","CR32_00_1_0008","CR32_00_1_0009","CR32_00_1_0010","CR32_00_1_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("114_walking_left","CR32_00_1_0012","CR32_00_1_0013","CR32_00_1_0014","CR32_00_1_0015","CR32_00_1_0016","CR32_00_1_0017", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("114_walking_rear_left","CR32_00_1_0018","CR32_00_1_0019","CR32_00_1_0020","CR32_00_1_0021","CR32_00_1_0022","CR32_00_1_0023", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("114_attack_bash","CR32_01_1_0008","CR32_01_1_0009","CR32_01_1_0010","CR32_01_1_0011","CR32_01_1_0012","CR32_01_1_0013", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("114_attack_slash","CR32_01_1_0014","CR32_01_1_0015","CR32_01_1_0016","CR32_01_1_0017","CR32_01_1_0018","CR32_01_1_0019", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("114_attack_thrust","CR32_01_1_0014","CR32_01_1_0015","CR32_01_1_0016","CR32_01_1_0017","CR32_01_1_0018","CR32_01_1_0019", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("114_attack_secondary","CR32_01_1_0014","CR32_01_1_0015","CR32_01_1_0016","CR32_01_1_0017","CR32_01_1_0018","CR32_01_1_0019", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("114_attack_unk","CR32_01_1_0008","CR32_01_1_0009","CR32_01_1_0010","CR32_01_1_0011","CR32_01_1_0012","CR32_01_1_0013", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("114_death","CR32_01_1_0026","CR32_01_1_0027","CR32_01_1_0028","CR32_01_1_0029","CR32_01_1_0030","CR32_01_1_0031", 6, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 51 - which is a_human//Animation #0 idle
				CreateAnimationUW("115_idle_rear","CR26_00_0_0020","CR26_00_0_0020","CR26_00_0_0020","CR26_00_0_0020","CR26_00_0_0020","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("115_idle_rear_right","CR26_00_0_0025","CR26_00_0_0025","CR26_00_0_0025","CR26_00_0_0025","CR26_00_0_0025","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("115_idle_right","CR26_00_0_0031","CR26_00_0_0031","CR26_00_0_0031","CR26_00_0_0031","CR26_00_0_0031","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("115_idle_front_right","CR26_01_0_0003","CR26_01_0_0003","CR26_01_0_0003","CR26_01_0_0003","CR26_01_0_0003","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("115_idle_front","CR26_01_0_0016","CR26_01_0_0017","CR26_01_0_0018","CR26_01_0_0019","CR26_01_0_0020","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("115_idle_front_left","CR26_00_0_0006","CR26_00_0_0006","CR26_00_0_0006","CR26_00_0_0006","CR26_00_0_0006","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("115_idle_left","CR26_00_0_0013","CR26_00_0_0013","CR26_00_0_0013","CR26_00_0_0013","CR26_00_0_0013","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("115_idle_rear_left","CR26_00_0_0016","CR26_00_0_0016","CR26_00_0_0016","CR26_00_0_0016","CR26_00_0_0016","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("115_walking_rear","CR26_00_0_0020","CR26_00_0_0021","CR26_00_0_0022","CR26_00_0_0023","CR26_00_0_0024","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("115_walking_rear_right","CR26_00_0_0025","CR26_00_0_0026","CR26_00_0_0027","CR26_00_0_0028","CR26_00_0_0029","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("115_walking_right","CR26_00_0_0030","CR26_00_0_0031","CR26_00_0_0032","CR26_00_0_0033","CR26_01_0_0000","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("115_walking_front_right","CR26_01_0_0001","CR26_01_0_0002","CR26_01_0_0003","CR26_01_0_0004","CR26_01_0_0005","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("115_walking_front","CR26_00_0_0000","CR26_00_0_0001","CR26_00_0_0002","CR26_00_0_0003","CR26_00_0_0004","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("115_walking_front_left","CR26_00_0_0005","CR26_00_0_0006","CR26_00_0_0007","CR26_00_0_0008","CR26_00_0_0009","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("115_walking_left","CR26_00_0_0010","CR26_00_0_0011","CR26_00_0_0012","CR26_00_0_0013","CR26_00_0_0014","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("115_walking_rear_left","CR26_00_0_0015","CR26_00_0_0016","CR26_00_0_0017","CR26_00_0_0018","CR26_00_0_0019","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("115_attack_bash","CR26_01_0_0007","CR26_01_0_0008","CR26_01_0_0009","CR26_01_0_0010","CR26_01_0_0010","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("115_attack_slash","CR26_01_0_0011","CR26_01_0_0012","CR26_01_0_0013","CR26_01_0_0014","CR26_01_0_0015","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("115_attack_thrust","CR26_01_0_0011","CR26_01_0_0012","CR26_01_0_0013","CR26_01_0_0014","CR26_01_0_0015","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("115_attack_secondary","CR26_01_0_0011","CR26_01_0_0012","CR26_01_0_0013","CR26_01_0_0014","CR26_01_0_0015","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("115_attack_unk","CR26_01_0_0011","CR26_01_0_0012","CR26_01_0_0013","CR26_01_0_0014","CR26_01_0_0015","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("115_death","CR26_01_0_0021","CR26_01_0_0022","CR26_01_0_0023","CR26_01_0_0024","CR26_01_0_0025","", 5, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 52 - which is a_human//Animation #0 idle
				CreateAnimationUW("116_idle_rear","CR27_00_1_0029","CR27_00_1_0029","CR27_00_1_0029","CR27_00_1_0029","CR27_00_1_0029","CR27_00_1_0029", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("116_idle_rear_right","CR27_00_1_0034","CR27_00_1_0034","CR27_00_1_0034","CR27_00_1_0034","CR27_00_1_0034","CR27_00_1_0034", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("116_idle_right","CR27_00_1_0039","CR27_00_1_0039","CR27_00_1_0039","CR27_00_1_0039","CR27_00_1_0039","CR27_00_1_0039", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("116_idle_front_right","CR27_01_1_0004","CR27_01_1_0004","CR27_01_1_0004","CR27_01_1_0004","CR27_01_1_0004","CR27_01_1_0004", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("116_idle_front","CR27_01_1_0007","CR27_01_1_0008","CR27_01_1_0009","CR27_01_1_0010","CR27_01_1_0011","CR27_01_1_0012", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("116_idle_front_left","CR27_00_1_0006","CR27_00_1_0006","CR27_00_1_0006","CR27_00_1_0006","CR27_00_1_0006","CR27_00_1_0006", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("116_idle_left","CR27_00_1_0015","CR27_00_1_0015","CR27_00_1_0015","CR27_00_1_0015","CR27_00_1_0015","CR27_00_1_0015", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("116_idle_rear_left","CR27_00_1_0021","CR27_00_1_0021","CR27_00_1_0021","CR27_00_1_0021","CR27_00_1_0021","CR27_00_1_0021", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("116_walking_rear","CR27_00_1_0024","CR27_00_1_0025","CR27_00_1_0026","CR27_00_1_0027","CR27_00_1_0028","CR27_00_1_0029", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("116_walking_rear_right","CR27_00_1_0030","CR27_00_1_0031","CR27_00_1_0032","CR27_00_1_0033","CR27_00_1_0034","CR27_00_1_0035", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("116_walking_right","CR27_00_1_0036","CR27_00_1_0037","CR27_00_1_0038","CR27_00_1_0039","CR27_00_1_0040","CR27_01_1_0000", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("116_walking_front_right","CR27_01_1_0001","CR27_01_1_0002","CR27_01_1_0003","CR27_01_1_0004","CR27_01_1_0005","CR27_01_1_0006", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("116_walking_front","CR27_00_1_0000","CR27_00_1_0001","CR27_00_1_0002","CR27_00_1_0003","CR27_00_1_0004","CR27_00_1_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("116_walking_front_left","CR27_00_1_0006","CR27_00_1_0007","CR27_00_1_0008","CR27_00_1_0009","CR27_00_1_0010","CR27_00_1_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("116_walking_left","CR27_00_1_0012","CR27_00_1_0013","CR27_00_1_0014","CR27_00_1_0015","CR27_00_1_0016","CR27_00_1_0017", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("116_walking_rear_left","CR27_00_1_0018","CR27_00_1_0019","CR27_00_1_0020","CR27_00_1_0021","CR27_00_1_0022","CR27_00_1_0023", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("116_attack_bash","CR27_01_1_0013","CR27_01_1_0014","CR27_01_1_0015","CR27_01_1_0016","CR27_01_1_0017","CR27_01_1_0018", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("116_attack_slash","CR27_01_1_0019","CR27_01_1_0020","CR27_01_1_0021","CR27_01_1_0022","CR27_01_1_0023","CR27_01_1_0024", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("116_attack_thrust","CR27_01_1_0019","CR27_01_1_0020","CR27_01_1_0021","CR27_01_1_0022","CR27_01_1_0023","CR27_01_1_0024", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("116_attack_secondary","CR27_01_1_0025","CR27_01_1_0026","CR27_01_1_0027","CR27_01_1_0028","CR27_01_1_0029","CR27_01_1_0030", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("116_attack_unk","CR27_01_1_0025","CR27_01_1_0026","CR27_01_1_0027","CR27_01_1_0028","CR27_01_1_0029","CR27_01_1_0030", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("116_death","CR27_01_1_0031","CR27_01_1_0032","CR27_01_1_0033","CR27_01_1_0034","CR27_01_1_0035","CR27_01_1_0036", 6, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 53 - which is a_human//Animation #0 idle
				CreateAnimationUW("117_idle_rear","CR26_00_1_0020","CR26_00_1_0020","CR26_00_1_0020","CR26_00_1_0020","CR26_00_1_0020","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("117_idle_rear_right","CR26_00_1_0025","CR26_00_1_0025","CR26_00_1_0025","CR26_00_1_0025","CR26_00_1_0025","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("117_idle_right","CR26_00_1_0031","CR26_00_1_0031","CR26_00_1_0031","CR26_00_1_0031","CR26_00_1_0031","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("117_idle_front_right","CR26_01_1_0003","CR26_01_1_0003","CR26_01_1_0003","CR26_01_1_0003","CR26_01_1_0003","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("117_idle_front","CR26_01_1_0016","CR26_01_1_0017","CR26_01_1_0018","CR26_01_1_0019","CR26_01_1_0020","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("117_idle_front_left","CR26_00_1_0006","CR26_00_1_0006","CR26_00_1_0006","CR26_00_1_0006","CR26_00_1_0006","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("117_idle_left","CR26_00_1_0013","CR26_00_1_0013","CR26_00_1_0013","CR26_00_1_0013","CR26_00_1_0013","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("117_idle_rear_left","CR26_00_1_0016","CR26_00_1_0016","CR26_00_1_0016","CR26_00_1_0016","CR26_00_1_0016","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("117_walking_rear","CR26_00_1_0020","CR26_00_1_0021","CR26_00_1_0022","CR26_00_1_0023","CR26_00_1_0024","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("117_walking_rear_right","CR26_00_1_0025","CR26_00_1_0026","CR26_00_1_0027","CR26_00_1_0028","CR26_00_1_0029","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("117_walking_right","CR26_00_1_0030","CR26_00_1_0031","CR26_00_1_0032","CR26_00_1_0033","CR26_01_1_0000","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("117_walking_front_right","CR26_01_1_0001","CR26_01_1_0002","CR26_01_1_0003","CR26_01_1_0004","CR26_01_1_0005","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("117_walking_front","CR26_00_1_0000","CR26_00_1_0001","CR26_00_1_0002","CR26_00_1_0003","CR26_00_1_0004","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("117_walking_front_left","CR26_00_1_0005","CR26_00_1_0006","CR26_00_1_0007","CR26_00_1_0008","CR26_00_1_0009","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("117_walking_left","CR26_00_1_0010","CR26_00_1_0011","CR26_00_1_0012","CR26_00_1_0013","CR26_00_1_0014","", 5, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("117_walking_rear_left","CR26_00_1_0015","CR26_00_1_0016","CR26_00_1_0017","CR26_00_1_0018","CR26_00_1_0019","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("117_attack_bash","CR26_01_1_0007","CR26_01_1_0008","CR26_01_1_0009","CR26_01_1_0010","CR26_01_1_0010","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("117_attack_slash","CR26_01_1_0011","CR26_01_1_0012","CR26_01_1_0013","CR26_01_1_0014","CR26_01_1_0015","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("117_attack_thrust","CR26_01_1_0011","CR26_01_1_0012","CR26_01_1_0013","CR26_01_1_0014","CR26_01_1_0015","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("117_attack_secondary","CR26_01_1_0011","CR26_01_1_0012","CR26_01_1_0013","CR26_01_1_0014","CR26_01_1_0015","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("117_attack_unk","CR26_01_1_0011","CR26_01_1_0012","CR26_01_1_0013","CR26_01_1_0014","CR26_01_1_0015","", 5, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("117_death","CR26_01_1_0021","CR26_01_1_0022","CR26_01_1_0023","CR26_01_1_0024","CR26_01_1_0025","", 5, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 54 - which is a_human//Animation #0 idle
				CreateAnimationUW("118_idle_rear","CR27_00_0_0029","CR27_00_0_0029","CR27_00_0_0029","CR27_00_0_0029","CR27_00_0_0029","CR27_00_0_0029", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("118_idle_rear_right","CR27_00_0_0034","CR27_00_0_0034","CR27_00_0_0034","CR27_00_0_0034","CR27_00_0_0034","CR27_00_0_0034", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("118_idle_right","CR27_00_0_0039","CR27_00_0_0039","CR27_00_0_0039","CR27_00_0_0039","CR27_00_0_0039","CR27_00_0_0039", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("118_idle_front_right","CR27_01_0_0004","CR27_01_0_0004","CR27_01_0_0004","CR27_01_0_0004","CR27_01_0_0004","CR27_01_0_0004", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("118_idle_front","CR27_01_0_0007","CR27_01_0_0008","CR27_01_0_0009","CR27_01_0_0010","CR27_01_0_0011","CR27_01_0_0012", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("118_idle_front_left","CR27_00_0_0006","CR27_00_0_0006","CR27_00_0_0006","CR27_00_0_0006","CR27_00_0_0006","CR27_00_0_0006", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("118_idle_left","CR27_00_0_0015","CR27_00_0_0015","CR27_00_0_0015","CR27_00_0_0015","CR27_00_0_0015","CR27_00_0_0015", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("118_idle_rear_left","CR27_00_0_0021","CR27_00_0_0021","CR27_00_0_0021","CR27_00_0_0021","CR27_00_0_0021","CR27_00_0_0021", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("118_walking_rear","CR27_00_0_0024","CR27_00_0_0025","CR27_00_0_0026","CR27_00_0_0027","CR27_00_0_0028","CR27_00_0_0029", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("118_walking_rear_right","CR27_00_0_0030","CR27_00_0_0031","CR27_00_0_0032","CR27_00_0_0033","CR27_00_0_0034","CR27_00_0_0035", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("118_walking_right","CR27_00_0_0036","CR27_00_0_0037","CR27_00_0_0038","CR27_00_0_0039","CR27_00_0_0040","CR27_01_0_0000", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("118_walking_front_right","CR27_01_0_0001","CR27_01_0_0002","CR27_01_0_0003","CR27_01_0_0004","CR27_01_0_0005","CR27_01_0_0006", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("118_walking_front","CR27_00_0_0000","CR27_00_0_0001","CR27_00_0_0002","CR27_00_0_0003","CR27_00_0_0004","CR27_00_0_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("118_walking_front_left","CR27_00_0_0006","CR27_00_0_0007","CR27_00_0_0008","CR27_00_0_0009","CR27_00_0_0010","CR27_00_0_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("118_walking_left","CR27_00_0_0012","CR27_00_0_0013","CR27_00_0_0014","CR27_00_0_0015","CR27_00_0_0016","CR27_00_0_0017", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("118_walking_rear_left","CR27_00_0_0018","CR27_00_0_0019","CR27_00_0_0020","CR27_00_0_0021","CR27_00_0_0022","CR27_00_0_0023", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("118_attack_bash","CR27_01_0_0013","CR27_01_0_0014","CR27_01_0_0015","CR27_01_0_0016","CR27_01_0_0017","CR27_01_0_0018", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("118_attack_slash","CR27_01_0_0019","CR27_01_0_0020","CR27_01_0_0021","CR27_01_0_0022","CR27_01_0_0023","CR27_01_0_0024", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("118_attack_thrust","CR27_01_0_0019","CR27_01_0_0020","CR27_01_0_0021","CR27_01_0_0022","CR27_01_0_0023","CR27_01_0_0024", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("118_attack_secondary","CR27_01_0_0025","CR27_01_0_0026","CR27_01_0_0027","CR27_01_0_0028","CR27_01_0_0029","CR27_01_0_0030", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("118_attack_unk","CR27_01_0_0025","CR27_01_0_0026","CR27_01_0_0027","CR27_01_0_0028","CR27_01_0_0029","CR27_01_0_0030", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("118_death","CR27_01_0_0031","CR27_01_0_0032","CR27_01_0_0033","CR27_01_0_0034","CR27_01_0_0035","CR27_01_0_0036", 6, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 55 - which is a_human//Animation #0 idle
				CreateAnimationUW("119_idle_rear","CR27_00_2_0029","CR27_00_2_0029","CR27_00_2_0029","CR27_00_2_0029","CR27_00_2_0029","CR27_00_2_0029", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("119_idle_rear_right","CR27_00_2_0034","CR27_00_2_0034","CR27_00_2_0034","CR27_00_2_0034","CR27_00_2_0034","CR27_00_2_0034", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("119_idle_right","CR27_00_2_0039","CR27_00_2_0039","CR27_00_2_0039","CR27_00_2_0039","CR27_00_2_0039","CR27_00_2_0039", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("119_idle_front_right","CR27_01_2_0004","CR27_01_2_0004","CR27_01_2_0004","CR27_01_2_0004","CR27_01_2_0004","CR27_01_2_0004", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("119_idle_front","CR27_01_2_0007","CR27_01_2_0008","CR27_01_2_0009","CR27_01_2_0010","CR27_01_2_0011","CR27_01_2_0012", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("119_idle_front_left","CR27_00_2_0006","CR27_00_2_0006","CR27_00_2_0006","CR27_00_2_0006","CR27_00_2_0006","CR27_00_2_0006", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("119_idle_left","CR27_00_2_0015","CR27_00_2_0015","CR27_00_2_0015","CR27_00_2_0015","CR27_00_2_0015","CR27_00_2_0015", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("119_idle_rear_left","CR27_00_2_0021","CR27_00_2_0021","CR27_00_2_0021","CR27_00_2_0021","CR27_00_2_0021","CR27_00_2_0021", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("119_walking_rear","CR27_00_2_0024","CR27_00_2_0025","CR27_00_2_0026","CR27_00_2_0027","CR27_00_2_0028","CR27_00_2_0029", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("119_walking_rear_right","CR27_00_2_0030","CR27_00_2_0031","CR27_00_2_0032","CR27_00_2_0033","CR27_00_2_0034","CR27_00_2_0035", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("119_walking_right","CR27_00_2_0036","CR27_00_2_0037","CR27_00_2_0038","CR27_00_2_0039","CR27_00_2_0040","CR27_01_2_0000", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("119_walking_front_right","CR27_01_2_0001","CR27_01_2_0002","CR27_01_2_0003","CR27_01_2_0004","CR27_01_2_0005","CR27_01_2_0006", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("119_walking_front","CR27_00_2_0000","CR27_00_2_0001","CR27_00_2_0002","CR27_00_2_0003","CR27_00_2_0004","CR27_00_2_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("119_walking_front_left","CR27_00_2_0006","CR27_00_2_0007","CR27_00_2_0008","CR27_00_2_0009","CR27_00_2_0010","CR27_00_2_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("119_walking_left","CR27_00_2_0012","CR27_00_2_0013","CR27_00_2_0014","CR27_00_2_0015","CR27_00_2_0016","CR27_00_2_0017", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("119_walking_rear_left","CR27_00_2_0018","CR27_00_2_0019","CR27_00_2_0020","CR27_00_2_0021","CR27_00_2_0022","CR27_00_2_0023", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("119_attack_bash","CR27_01_2_0013","CR27_01_2_0014","CR27_01_2_0015","CR27_01_2_0016","CR27_01_2_0017","CR27_01_2_0018", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("119_attack_slash","CR27_01_2_0019","CR27_01_2_0020","CR27_01_2_0021","CR27_01_2_0022","CR27_01_2_0023","CR27_01_2_0024", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("119_attack_thrust","CR27_01_2_0019","CR27_01_2_0020","CR27_01_2_0021","CR27_01_2_0022","CR27_01_2_0023","CR27_01_2_0024", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("119_attack_secondary","CR27_01_2_0025","CR27_01_2_0026","CR27_01_2_0027","CR27_01_2_0028","CR27_01_2_0029","CR27_01_2_0030", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("119_attack_unk","CR27_01_2_0025","CR27_01_2_0026","CR27_01_2_0027","CR27_01_2_0028","CR27_01_2_0029","CR27_01_2_0030", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("119_death","CR27_01_2_0031","CR27_01_2_0032","CR27_01_2_0033","CR27_01_2_0034","CR27_01_2_0035","CR27_01_2_0036", 6, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 56 - which is a_human//Animation #0 idle
				CreateAnimationUW("120_idle_rear","CR31_00_0_0025","CR31_00_0_0025","CR31_00_0_0025","CR31_00_0_0025","CR31_00_0_0025","CR31_00_0_0025", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("120_idle_rear_right","CR31_00_0_0035","CR31_00_0_0035","CR31_00_0_0035","CR31_00_0_0035","CR31_00_0_0035","CR31_00_0_0035", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("120_idle_right","CR31_00_0_0041","CR31_00_0_0041","CR31_00_0_0041","CR31_00_0_0041","CR31_00_0_0041","CR31_00_0_0041", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("120_idle_front_right","CR31_01_0_0003","CR31_01_0_0003","CR31_01_0_0003","CR31_01_0_0003","CR31_01_0_0003","CR31_01_0_0003", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("120_idle_front","CR31_01_0_0016","CR31_01_0_0017","CR31_01_0_0018","CR31_01_0_0019","CR31_01_0_0020","CR31_01_0_0021", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("120_idle_front_left","CR31_00_0_0011","CR31_00_0_0011","CR31_00_0_0011","CR31_00_0_0011","CR31_00_0_0011","CR31_00_0_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("120_idle_left","CR31_00_0_0014","CR31_00_0_0014","CR31_00_0_0014","CR31_00_0_0014","CR31_00_0_0014","CR31_00_0_0014", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("120_idle_rear_left","CR31_00_0_0020","CR31_00_0_0020","CR31_00_0_0020","CR31_00_0_0020","CR31_00_0_0020","CR31_00_0_0020", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("120_walking_rear","CR31_00_0_0024","CR31_00_0_0025","CR31_00_0_0026","CR31_00_0_0027","CR31_00_0_0028","CR31_00_0_0029", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("120_walking_rear_right","CR31_00_0_0030","CR31_00_0_0031","CR31_00_0_0032","CR31_00_0_0033","CR31_00_0_0034","CR31_00_0_0035", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("120_walking_right","CR31_00_0_0036","CR31_00_0_0037","CR31_00_0_0038","CR31_00_0_0039","CR31_00_0_0040","CR31_00_0_0041", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("120_walking_front_right","CR31_00_0_0042","CR31_00_0_0043","CR31_01_0_0000","CR31_01_0_0001","CR31_01_0_0002","CR31_01_0_0003", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("120_walking_front","CR31_00_0_0000","CR31_00_0_0001","CR31_00_0_0002","CR31_00_0_0003","CR31_00_0_0004","CR31_00_0_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("120_walking_front_left","CR31_00_0_0006","CR31_00_0_0007","CR31_00_0_0008","CR31_00_0_0009","CR31_00_0_0010","CR31_00_0_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("120_walking_left","CR31_00_0_0012","CR31_00_0_0013","CR31_00_0_0014","CR31_00_0_0015","CR31_00_0_0016","CR31_00_0_0017", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("120_walking_rear_left","CR31_00_0_0018","CR31_00_0_0019","CR31_00_0_0020","CR31_00_0_0021","CR31_00_0_0022","CR31_00_0_0023", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("120_attack_bash","CR31_01_0_0004","CR31_01_0_0005","CR31_01_0_0006","CR31_01_0_0007","CR31_01_0_0008","CR31_01_0_0009", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("120_attack_slash","CR31_01_0_0010","CR31_01_0_0011","CR31_01_0_0012","CR31_01_0_0013","CR31_01_0_0014","CR31_01_0_0015", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("120_attack_thrust","CR31_01_0_0010","CR31_01_0_0011","CR31_01_0_0012","CR31_01_0_0013","CR31_01_0_0014","CR31_01_0_0015", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("120_attack_secondary","CR31_01_0_0010","CR31_01_0_0011","CR31_01_0_0012","CR31_01_0_0013","CR31_01_0_0014","CR31_01_0_0015", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("120_attack_unk","CR31_01_0_0010","CR31_01_0_0011","CR31_01_0_0012","CR31_01_0_0013","CR31_01_0_0014","CR31_01_0_0015", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("120_death","CR31_01_0_0021","CR31_01_0_0022","CR31_01_0_0023","CR31_01_0_0024","CR31_01_0_0025","", 5, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 57 - which is a_human//Animation #0 idle
				CreateAnimationUW("121_idle_rear","CR30_00_0_0026","CR30_00_0_0026","CR30_00_0_0026","CR30_00_0_0026","CR30_00_0_0026","CR30_00_0_0026", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("121_idle_rear_right","CR30_00_0_0034","CR30_00_0_0034","CR30_00_0_0034","CR30_00_0_0034","CR30_00_0_0034","CR30_00_0_0034", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("121_idle_right","CR30_00_0_0037","CR30_00_0_0037","CR30_00_0_0037","CR30_00_0_0037","CR30_00_0_0037","CR30_00_0_0037", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("121_idle_front_right","CR30_01_0_0008","CR30_01_0_0008","CR30_01_0_0008","CR30_01_0_0008","CR30_01_0_0008","CR30_01_0_0008", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("121_idle_front","CR30_01_0_0027","CR30_01_0_0028","CR30_01_0_0029","CR30_01_0_0030","CR30_01_0_0031","CR30_01_0_0032", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("121_idle_front_left","CR30_00_0_0010","CR30_00_0_0010","CR30_00_0_0010","CR30_00_0_0010","CR30_00_0_0010","CR30_00_0_0010", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("121_idle_left","CR30_00_0_0014","CR30_00_0_0014","CR30_00_0_0014","CR30_00_0_0014","CR30_00_0_0014","CR30_00_0_0014", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("121_idle_rear_left","CR30_00_0_0020","CR30_00_0_0020","CR30_00_0_0020","CR30_00_0_0020","CR30_00_0_0020","CR30_00_0_0020", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("121_walking_rear","CR30_00_0_0024","CR30_00_0_0025","CR30_00_0_0026","CR30_00_0_0027","CR30_00_0_0028","CR30_00_0_0029", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("121_walking_rear_right","CR30_00_0_0030","CR30_00_0_0031","CR30_00_0_0032","CR30_00_0_0033","CR30_00_0_0034","CR30_00_0_0035", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("121_walking_right","CR30_00_0_0036","CR30_00_0_0037","CR30_00_0_0038","CR30_01_0_0000","CR30_01_0_0001","CR30_01_0_0002", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("121_walking_front_right","CR30_01_0_0003","CR30_01_0_0004","CR30_01_0_0005","CR30_01_0_0006","CR30_01_0_0007","CR30_01_0_0008", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("121_walking_front","CR30_00_0_0000","CR30_00_0_0001","CR30_00_0_0002","CR30_00_0_0003","CR30_00_0_0004","CR30_00_0_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("121_walking_front_left","CR30_00_0_0006","CR30_00_0_0007","CR30_00_0_0008","CR30_00_0_0009","CR30_00_0_0010","CR30_00_0_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("121_walking_left","CR30_00_0_0012","CR30_00_0_0013","CR30_00_0_0014","CR30_00_0_0015","CR30_00_0_0016","CR30_00_0_0017", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("121_walking_rear_left","CR30_00_0_0018","CR30_00_0_0019","CR30_00_0_0020","CR30_00_0_0021","CR30_00_0_0022","CR30_00_0_0023", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("121_attack_bash","CR30_01_0_0009","CR30_01_0_0010","CR30_01_0_0011","CR30_01_0_0012","CR30_01_0_0013","CR30_01_0_0014", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("121_attack_slash","CR30_01_0_0015","CR30_01_0_0016","CR30_01_0_0017","CR30_01_0_0018","CR30_01_0_0019","CR30_01_0_0020", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("121_attack_thrust","CR30_01_0_0015","CR30_01_0_0016","CR30_01_0_0017","CR30_01_0_0018","CR30_01_0_0019","CR30_01_0_0020", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("121_attack_secondary","CR30_01_0_0021","CR30_01_0_0022","CR30_01_0_0023","CR30_01_0_0024","CR30_01_0_0025","CR30_01_0_0026", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("121_attack_unk","CR30_01_0_0021","CR30_01_0_0022","CR30_01_0_0023","CR30_01_0_0024","CR30_01_0_0025","CR30_01_0_0026", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("121_death","CR30_01_0_0032","CR30_01_0_0033","CR30_01_0_0034","CR30_01_0_0035","CR30_01_0_0036","", 5, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 58 - which is a_human//Animation #0 idle
				CreateAnimationUW("122_idle_rear","CR25_00_0_0026","CR25_00_0_0026","CR25_00_0_0026","CR25_00_0_0026","CR25_00_0_0026","CR25_00_0_0026", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("122_idle_rear_right","CR25_00_0_0032","CR25_00_0_0032","CR25_00_0_0032","CR25_00_0_0032","CR25_00_0_0032","CR25_00_0_0032", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("122_idle_right","CR25_01_0_0000","CR25_01_0_0000","CR25_01_0_0000","CR25_01_0_0000","CR25_01_0_0000","CR25_01_0_0000", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("122_idle_front_right","CR25_01_0_0008","CR25_01_0_0008","CR25_01_0_0008","CR25_01_0_0008","CR25_01_0_0008","CR25_01_0_0008", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("122_idle_front","CR25_01_0_0010","CR25_01_0_0011","CR25_01_0_0012","CR25_01_0_0013","CR25_01_0_0014","CR25_01_0_0015", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("122_idle_front_left","CR25_00_0_0007","CR25_00_0_0007","CR25_00_0_0007","CR25_00_0_0007","CR25_00_0_0007","CR25_00_0_0007", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("122_idle_left","CR25_00_0_0014","CR25_00_0_0014","CR25_00_0_0014","CR25_00_0_0014","CR25_00_0_0014","CR25_00_0_0014", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("122_idle_rear_left","CR25_00_0_0023","CR25_00_0_0023","CR25_00_0_0023","CR25_00_0_0023","CR25_00_0_0023","CR25_00_0_0023", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("122_walking_rear","CR25_00_0_0024","CR25_00_0_0025","CR25_00_0_0026","CR25_00_0_0027","CR25_00_0_0028","CR25_00_0_0029", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("122_walking_rear_right","CR25_00_0_0030","CR25_00_0_0031","CR25_00_0_0032","CR25_00_0_0033","CR25_00_0_0034","CR25_00_0_0035", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("122_walking_right","CR25_00_0_0036","CR25_00_0_0037","CR25_01_0_0000","CR25_01_0_0001","CR25_01_0_0002","CR25_01_0_0003", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("122_walking_front_right","CR25_01_0_0004","CR25_01_0_0005","CR25_01_0_0006","CR25_01_0_0007","CR25_01_0_0008","CR25_01_0_0009", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("122_walking_front","CR25_00_0_0000","CR25_00_0_0001","CR25_00_0_0002","CR25_00_0_0003","CR25_00_0_0004","CR25_00_0_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("122_walking_front_left","CR25_00_0_0006","CR25_00_0_0007","CR25_00_0_0008","CR25_00_0_0009","CR25_00_0_0010","CR25_00_0_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("122_walking_left","CR25_00_0_0012","CR25_00_0_0013","CR25_00_0_0014","CR25_00_0_0015","CR25_00_0_0016","CR25_00_0_0017", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("122_walking_rear_left","CR25_00_0_0018","CR25_00_0_0019","CR25_00_0_0020","CR25_00_0_0021","CR25_00_0_0022","CR25_00_0_0023", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("122_attack_bash","CR25_01_0_0022","CR25_01_0_0022","CR25_01_0_0022","CR25_01_0_0022","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("122_attack_slash","CR25_01_0_0022","CR25_01_0_0023","CR25_01_0_0024","CR25_01_0_0025","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("122_attack_thrust","CR25_01_0_0022","CR25_01_0_0023","CR25_01_0_0024","CR25_01_0_0025","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("122_attack_secondary","CR25_01_0_0022","CR25_01_0_0023","CR25_01_0_0024","CR25_01_0_0025","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("122_attack_unk","CR25_01_0_0022","CR25_01_0_0023","CR25_01_0_0024","CR25_01_0_0025","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("122_death","CR25_01_0_0016","CR25_01_0_0017","CR25_01_0_0018","CR25_01_0_0019","CR25_01_0_0020","CR25_01_0_0021", 6, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 59 - which is a_human//Animation #0 idle
				CreateAnimationUW("123_idle_rear","CR31_00_1_0025","CR31_00_1_0025","CR31_00_1_0025","CR31_00_1_0025","CR31_00_1_0025","CR31_00_1_0025", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("123_idle_rear_right","CR31_00_1_0035","CR31_00_1_0035","CR31_00_1_0035","CR31_00_1_0035","CR31_00_1_0035","CR31_00_1_0035", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("123_idle_right","CR31_00_1_0041","CR31_00_1_0041","CR31_00_1_0041","CR31_00_1_0041","CR31_00_1_0041","CR31_00_1_0041", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("123_idle_front_right","CR31_01_1_0003","CR31_01_1_0003","CR31_01_1_0003","CR31_01_1_0003","CR31_01_1_0003","CR31_01_1_0003", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("123_idle_front","CR31_01_1_0016","CR31_01_1_0017","CR31_01_1_0018","CR31_01_1_0019","CR31_01_1_0020","CR31_01_1_0021", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("123_idle_front_left","CR31_00_1_0011","CR31_00_1_0011","CR31_00_1_0011","CR31_00_1_0011","CR31_00_1_0011","CR31_00_1_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("123_idle_left","CR31_00_1_0014","CR31_00_1_0014","CR31_00_1_0014","CR31_00_1_0014","CR31_00_1_0014","CR31_00_1_0014", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("123_idle_rear_left","CR31_00_1_0020","CR31_00_1_0020","CR31_00_1_0020","CR31_00_1_0020","CR31_00_1_0020","CR31_00_1_0020", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("123_walking_rear","CR31_00_1_0024","CR31_00_1_0025","CR31_00_1_0026","CR31_00_1_0027","CR31_00_1_0028","CR31_00_1_0029", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("123_walking_rear_right","CR31_00_1_0030","CR31_00_1_0031","CR31_00_1_0032","CR31_00_1_0033","CR31_00_1_0034","CR31_00_1_0035", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("123_walking_right","CR31_00_1_0036","CR31_00_1_0037","CR31_00_1_0038","CR31_00_1_0039","CR31_00_1_0040","CR31_00_1_0041", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("123_walking_front_right","CR31_00_1_0042","CR31_00_1_0043","CR31_01_1_0000","CR31_01_1_0001","CR31_01_1_0002","CR31_01_1_0003", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("123_walking_front","CR31_00_1_0000","CR31_00_1_0001","CR31_00_1_0002","CR31_00_1_0003","CR31_00_1_0004","CR31_00_1_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("123_walking_front_left","CR31_00_1_0006","CR31_00_1_0007","CR31_00_1_0008","CR31_00_1_0009","CR31_00_1_0010","CR31_00_1_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("123_walking_left","CR31_00_1_0012","CR31_00_1_0013","CR31_00_1_0014","CR31_00_1_0015","CR31_00_1_0016","CR31_00_1_0017", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("123_walking_rear_left","CR31_00_1_0018","CR31_00_1_0019","CR31_00_1_0020","CR31_00_1_0021","CR31_00_1_0022","CR31_00_1_0023", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("123_attack_bash","CR31_01_1_0004","CR31_01_1_0005","CR31_01_1_0006","CR31_01_1_0007","CR31_01_1_0008","CR31_01_1_0009", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("123_attack_slash","CR31_01_1_0010","CR31_01_1_0011","CR31_01_1_0012","CR31_01_1_0013","CR31_01_1_0014","CR31_01_1_0015", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("123_attack_thrust","CR31_01_1_0010","CR31_01_1_0011","CR31_01_1_0012","CR31_01_1_0013","CR31_01_1_0014","CR31_01_1_0015", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("123_attack_secondary","CR31_01_1_0010","CR31_01_1_0011","CR31_01_1_0012","CR31_01_1_0013","CR31_01_1_0014","CR31_01_1_0015", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("123_attack_unk","CR31_01_1_0010","CR31_01_1_0011","CR31_01_1_0012","CR31_01_1_0013","CR31_01_1_0014","CR31_01_1_0015", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("123_death","CR31_01_1_0021","CR31_01_1_0022","CR31_01_1_0023","CR31_01_1_0024","CR31_01_1_0025","", 5, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 60 - which is etherealvoidshit//Animation #0 idle
				CreateAnimationUW("124_idle_rear","CR37_00_0_0000","CR37_00_0_0001","CR37_00_0_0002","","","", 3, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("124_idle_rear_right","CR37_00_0_0000","CR37_00_0_0001","CR37_00_0_0002","","","", 3, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("124_idle_right","CR37_00_0_0000","CR37_00_0_0001","CR37_00_0_0002","","","", 3, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("124_idle_front_right","CR37_00_0_0000","CR37_00_0_0001","CR37_00_0_0002","","","", 3, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("124_idle_front","CR37_00_0_0000","CR37_00_0_0001","CR37_00_0_0002","","","", 3, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("124_idle_front_left","CR37_00_0_0000","CR37_00_0_0001","CR37_00_0_0002","","","", 3, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("124_idle_left","CR37_00_0_0000","CR37_00_0_0001","CR37_00_0_0002","","","", 3, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("124_idle_rear_left","CR37_00_0_0000","CR37_00_0_0001","CR37_00_0_0002","","","", 3, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("124_walking_rear","CR37_00_0_0003","CR37_00_0_0004","CR37_00_0_0005","CR37_00_0_0006","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("124_walking_rear_right","CR37_00_0_0003","CR37_00_0_0004","CR37_00_0_0005","CR37_00_0_0006","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("124_walking_right","CR37_00_0_0003","CR37_00_0_0004","CR37_00_0_0005","CR37_00_0_0006","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("124_walking_front_right","CR37_00_0_0003","CR37_00_0_0004","CR37_00_0_0005","CR37_00_0_0006","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("124_walking_front","CR37_00_0_0003","CR37_00_0_0004","CR37_00_0_0005","CR37_00_0_0006","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("124_walking_front_left","CR37_00_0_0003","CR37_00_0_0004","CR37_00_0_0005","CR37_00_0_0006","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("124_walking_left","CR37_00_0_0003","CR37_00_0_0004","CR37_00_0_0005","CR37_00_0_0006","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("124_walking_rear_left","CR37_00_0_0003","CR37_00_0_0004","CR37_00_0_0005","CR37_00_0_0006","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("124_attack_bash","CR37_00_0_0007","CR37_00_0_0008","CR37_00_0_0009","","","", 3, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("124_attack_slash","CR37_00_0_0010","CR37_00_0_0011","CR37_00_0_0012","CR37_00_0_0013","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("124_attack_thrust","CR37_01_0_0000","CR37_01_0_0001","CR37_01_0_0002","CR37_01_0_0003","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("124_attack_secondary","CR37_01_0_0004","CR37_01_0_0005","CR37_01_0_0006","CR37_01_0_0007","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("124_attack_unk","CR37_01_0_0008","CR37_01_0_0009","CR37_01_0_0010","CR37_01_0_0011","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("124_death","CR37_02_0_0000","CR37_02_0_0001","","","","", 2, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 61 - which is etherealvoidshit//Animation #0 idle
				CreateAnimationUW("125_idle_rear","CR37_00_1_0000","CR37_00_1_0001","CR37_00_1_0002","","","", 3, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("125_idle_rear_right","CR37_00_1_0000","CR37_00_1_0001","CR37_00_1_0002","","","", 3, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("125_idle_right","CR37_00_1_0000","CR37_00_1_0001","CR37_00_1_0002","","","", 3, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("125_idle_front_right","CR37_00_1_0000","CR37_00_1_0001","CR37_00_1_0002","","","", 3, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("125_idle_front","CR37_00_1_0000","CR37_00_1_0001","CR37_00_1_0002","","","", 3, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("125_idle_front_left","CR37_00_1_0000","CR37_00_1_0001","CR37_00_1_0002","","","", 3, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("125_idle_left","CR37_00_1_0000","CR37_00_1_0001","CR37_00_1_0002","","","", 3, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("125_idle_rear_left","CR37_00_1_0000","CR37_00_1_0001","CR37_00_1_0002","","","", 3, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("125_walking_rear","CR37_00_1_0003","CR37_00_1_0004","CR37_00_1_0005","CR37_00_1_0006","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("125_walking_rear_right","CR37_00_1_0003","CR37_00_1_0004","CR37_00_1_0005","CR37_00_1_0006","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("125_walking_right","CR37_00_1_0003","CR37_00_1_0004","CR37_00_1_0005","CR37_00_1_0006","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("125_walking_front_right","CR37_00_1_0003","CR37_00_1_0004","CR37_00_1_0005","CR37_00_1_0006","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("125_walking_front","CR37_00_1_0003","CR37_00_1_0004","CR37_00_1_0005","CR37_00_1_0006","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("125_walking_front_left","CR37_00_1_0003","CR37_00_1_0004","CR37_00_1_0005","CR37_00_1_0006","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("125_walking_left","CR37_00_1_0003","CR37_00_1_0004","CR37_00_1_0005","CR37_00_1_0006","","", 4, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("125_walking_rear_left","CR37_00_1_0003","CR37_00_1_0004","CR37_00_1_0005","CR37_00_1_0006","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("125_attack_bash","CR37_00_1_0007","CR37_00_1_0008","CR37_00_1_0009","","","", 3, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("125_attack_slash","CR37_00_1_0010","CR37_00_1_0011","CR37_00_1_0012","CR37_00_1_0013","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("125_attack_thrust","CR37_01_1_0000","CR37_01_1_0001","CR37_01_1_0002","CR37_01_1_0003","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("125_attack_secondary","CR37_01_1_0004","CR37_01_1_0005","CR37_01_1_0006","CR37_01_1_0007","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("125_attack_unk","CR37_01_1_0008","CR37_01_1_0009","CR37_01_1_0010","CR37_01_1_0011","","", 4, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("125_death","CR37_02_1_0000","CR37_02_1_0001","","","","", 2, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 62 - which is a_human//Animation #0 idle
				CreateAnimationUW("126_idle_rear","CR33_00_1_0025","CR33_00_1_0025","CR33_00_1_0025","CR33_00_1_0025","CR33_00_1_0025","CR33_00_1_0025", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("126_idle_rear_right","CR33_00_1_0035","CR33_00_1_0035","CR33_00_1_0035","CR33_00_1_0035","CR33_00_1_0035","CR33_00_1_0035", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("126_idle_right","CR33_00_1_0038","CR33_00_1_0038","CR33_00_1_0038","CR33_00_1_0038","CR33_00_1_0038","CR33_00_1_0038", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("126_idle_front_right","CR33_01_1_0001","CR33_01_1_0001","CR33_01_1_0001","CR33_01_1_0001","CR33_01_1_0001","CR33_01_1_0001", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("126_idle_front","CR33_01_1_0017","CR33_01_1_0018","CR33_01_1_0019","CR33_01_1_0020","CR33_01_1_0021","CR33_01_1_0022", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("126_idle_front_left","CR33_00_1_0011","CR33_00_1_0011","CR33_00_1_0011","CR33_00_1_0011","CR33_00_1_0011","CR33_00_1_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("126_idle_left","CR33_00_1_0017","CR33_00_1_0017","CR33_00_1_0017","CR33_00_1_0017","CR33_00_1_0017","CR33_00_1_0017", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("126_idle_rear_left","CR33_00_1_0020","CR33_00_1_0020","CR33_00_1_0020","CR33_00_1_0020","CR33_00_1_0020","CR33_00_1_0020", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #1 walking
				CreateAnimationUW("126_walking_rear","CR33_00_1_0024","CR33_00_1_0025","CR33_00_1_0026","CR33_00_1_0027","CR33_00_1_0028","CR33_00_1_0029", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("126_walking_rear_right","CR33_00_1_0030","CR33_00_1_0031","CR33_00_1_0032","CR33_00_1_0033","CR33_00_1_0034","CR33_00_1_0035", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("126_walking_right","CR33_00_1_0036","CR33_00_1_0037","CR33_00_1_0038","CR33_00_1_0039","CR33_00_1_0040","CR33_00_1_0041", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("126_walking_front_right","CR33_00_1_0042","CR33_01_1_0000","CR33_01_1_0001","CR33_01_1_0002","CR33_01_1_0003","CR33_01_1_0004", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("126_walking_front","CR33_00_1_0000","CR33_00_1_0001","CR33_00_1_0002","CR33_00_1_0003","CR33_00_1_0004","CR33_00_1_0005", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("126_walking_front_left","CR33_00_1_0006","CR33_00_1_0007","CR33_00_1_0008","CR33_00_1_0009","CR33_00_1_0010","CR33_00_1_0011", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("126_walking_left","CR33_00_1_0012","CR33_00_1_0013","CR33_00_1_0014","CR33_00_1_0015","CR33_00_1_0016","CR33_00_1_0017", 6, _RES + "/Sprites/Critters" , 0.2f);

				CreateAnimationUW("126_walking_rear_left","CR33_00_1_0018","CR33_00_1_0019","CR33_00_1_0020","CR33_00_1_0021","CR33_00_1_0022","CR33_00_1_0023", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #2 attack_bash
				CreateAnimationUW("126_attack_bash","CR33_01_1_0005","CR33_01_1_0006","CR33_01_1_0007","CR33_01_1_0008","CR33_01_1_0009","CR33_01_1_0010", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #3 attack_slash
				CreateAnimationUW("126_attack_slash","CR33_01_1_0011","CR33_01_1_0012","CR33_01_1_0013","CR33_01_1_0014","CR33_01_1_0015","CR33_01_1_0016", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #4 attack_thrust
				CreateAnimationUW("126_attack_thrust","CR33_01_1_0011","CR33_01_1_0012","CR33_01_1_0013","CR33_01_1_0014","CR33_01_1_0015","CR33_01_1_0016", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #5 attack_secondary
				CreateAnimationUW("126_attack_secondary","CR33_01_1_0011","CR33_01_1_0012","CR33_01_1_0013","CR33_01_1_0014","CR33_01_1_0015","CR33_01_1_0016", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #6 attack_unk
				CreateAnimationUW("126_attack_unk","CR33_01_1_0011","CR33_01_1_0012","CR33_01_1_0013","CR33_01_1_0014","CR33_01_1_0015","CR33_01_1_0016", 6, _RES + "/Sprites/Critters" , 0.2f);
				//Animation #7 death
				CreateAnimationUW("126_death","CR33_01_1_0023","CR33_01_1_0024","CR33_01_1_0025","CR33_01_1_0026","CR33_01_1_0027","CR33_01_1_0028", 6, _RES + "/Sprites/Critters" , 0.2f);

				//Anim ID: 63 - which is an_adventurer


		}



		[MenuItem("MyTools/CreateAnim-ShockCritters")]
		static void GenerateAnimationAssets_SHOCKCritters()
		{
				return;
				//System Shock animations
				/*		CreateAnimationUW("439_Attack1","objects_1400_0000","objects_1400_0001","objects_1400_0002","objects_1400_0003","objects_1400_0004","objects_1400_0005","objects_1400_0006","objects_1400_0007",8);
		CreateAnimationUW("439_Attack2","objects_2113_0000","objects_2113_0001","objects_2113_0002","objects_2113_0003","objects_2113_0004","objects_2113_0005","","",6);
		CreateAnimationUW("439_Combat_Idle","objects_1437_0000","objects_1437_0001","objects_1437_0002","","","","","",3);
		CreateAnimationUW("439_Death","objects_1474_0000","objects_1474_0001","objects_1474_0002","objects_1474_0003","objects_1474_0004","objects_1474_0005","","",6);
		CreateAnimationUW("439_idle_front","objects_1591_0000","objects_1591_0001","objects_1591_0002","objects_1591_0003","objects_1591_0004","","","",5);
		CreateAnimationUW("439_idle_front_left","objects_1592_0000","objects_1592_0001","objects_1592_0002","objects_1592_0003","objects_1592_0004","","","",5);
		CreateAnimationUW("439_idle_front_right","objects_1590_0000","objects_1590_0001","objects_1590_0002","objects_1590_0003","objects_1590_0004","","","",5);
		CreateAnimationUW("439_idle_left","objects_1585_0000","objects_1585_0001","","","","","","",2);
		CreateAnimationUW("439_idle_rear","objects_1587_0000","objects_1587_0001","","","","","","",2);
		CreateAnimationUW("439_idle_rear_left","objects_1586_0000","objects_1586_0001","","","","","","",2);
		CreateAnimationUW("439_idle_rear_right","objects_1588_0000","objects_1588_0001","","","","","","",2);
		CreateAnimationUW("439_idle_right","objects_1589_0000","objects_1589_0001","","","","","","",2);
		CreateAnimationUW("439_walking_front","objects_1884_0000","objects_1884_0001","objects_1884_0002","objects_1884_0003","objects_1884_0004","objects_1884_0005","objects_1884_0006","objects_1884_0007",8);
		CreateAnimationUW("439_walking_front","objects_1886_0000","objects_1886_0001","objects_1886_0002","objects_1886_0003","objects_1886_0004","objects_1886_0005","objects_1886_0006","objects_1886_0007",8);
		CreateAnimationUW("439_walking_front_left","objects_1887_0000","objects_1887_0001","objects_1887_0002","objects_1887_0003","objects_1887_0004","objects_1887_0005","objects_1887_0006","objects_1887_0007",8);
		CreateAnimationUW("439_walking_front_right","objects_1885_0000","objects_1885_0001","objects_1885_0002","objects_1885_0003","objects_1885_0004","objects_1885_0005","objects_1885_0006","",7);
		CreateAnimationUW("439_walking_left","objects_1880_0000","objects_1880_0001","objects_1880_0002","objects_1880_0003","objects_1880_0004","objects_1880_0005","objects_1880_0006","objects_1880_0007",8);
		CreateAnimationUW("439_walking_rear","objects_1882_0000","objects_1882_0001","objects_1882_0002","objects_1882_0003","objects_1882_0004","objects_1882_0005","objects_1882_0006","objects_1882_0007",8);
		CreateAnimationUW("439_walking_rear_left","objects_1881_0000","objects_1881_0001","objects_1881_0002","objects_1881_0003","objects_1881_0004","objects_1881_0005","objects_1881_0006","objects_1881_0007",8);
		CreateAnimationUW("439_walking_rear_right","objects_1883_0000","objects_1883_0001","objects_1883_0002","objects_1883_0003","objects_1883_0004","objects_1883_0005","objects_1883_0006","objects_1883_0007",8);
		CreateAnimationUW("440_Attack1","objects_1401_0000","objects_1401_0001","objects_1401_0002","objects_1401_0003","objects_1401_0004","","","",5);
		CreateAnimationUW("440_Attack2","objects_2114_0000","objects_2114_0001","objects_2114_0002","objects_2114_0003","objects_2114_0004","","","",5);
		CreateAnimationUW("440_Combat_Idle","objects_1438_0000","objects_1438_0001","objects_1438_0002","objects_1438_0003","objects_1438_0004","","","",5);
		CreateAnimationUW("440_Death","objects_1475_0000","objects_1475_0001","objects_1475_0002","objects_1475_0003","objects_1475_0004","","","",5);
		CreateAnimationUW("440_idle_front","objects_1599_0000","objects_1599_0001","objects_1599_0002","objects_1599_0003","objects_1599_0004","","","",5);
		CreateAnimationUW("440_idle_front_left","objects_1600_0000","objects_1600_0001","objects_1600_0002","objects_1600_0003","objects_1600_0004","","","",5);
		CreateAnimationUW("440_idle_left","objects_1593_0000","objects_1593_0001","objects_1593_0002","objects_1593_0003","objects_1593_0004","","","",5);
		CreateAnimationUW("440_idle_rear","objects_1595_0000","objects_1595_0001","objects_1595_0002","objects_1595_0003","objects_1595_0004","","","",5);
		CreateAnimationUW("440_idle_rear_left","objects_1594_0000","objects_1594_0001","objects_1594_0002","objects_1594_0003","objects_1594_0004","","","",5);
		CreateAnimationUW("440_idle_rear_right","objects_1596_0000","objects_1596_0001","objects_1596_0002","objects_1596_0003","objects_1596_0004","","","",5);
		CreateAnimationUW("440_idle_front_right","objects_1598_0000","objects_1598_0001","objects_1598_0002","objects_1598_0003","objects_1598_0004","","","",5);
		CreateAnimationUW("440_idle_right","objects_1597_0000","objects_1597_0001","objects_1597_0002","objects_1597_0003","objects_1597_0004","","","",5);
		CreateAnimationUW("440_walking_front","objects_1894_0000","objects_1894_0001","objects_1894_0002","objects_1894_0003","objects_1894_0004","objects_1894_0005","objects_1894_0006","objects_1894_0007",8);
		CreateAnimationUW("440_walking_front_left","objects_1895_0000","objects_1895_0001","objects_1895_0002","objects_1895_0003","objects_1895_0004","objects_1895_0005","objects_1895_0006","objects_1895_0007",8);
		CreateAnimationUW("440_walking_front_right","objects_1893_0000","objects_1893_0001","objects_1893_0002","objects_1893_0003","objects_1893_0004","objects_1893_0005","objects_1893_0006","objects_1893_0007",8);
		CreateAnimationUW("440_walking_left","objects_1888_0000","objects_1888_0001","objects_1888_0002","objects_1888_0003","objects_1888_0004","objects_1888_0005","objects_1888_0006","objects_1888_0007",8);
		CreateAnimationUW("440_walking_rear","objects_1890_0000","objects_1890_0001","objects_1890_0002","objects_1890_0003","objects_1890_0004","objects_1890_0005","objects_1890_0006","objects_1890_0007",8);
		CreateAnimationUW("440_walking_right","objects_1892_0000","objects_1892_0001","objects_1892_0002","objects_1892_0003","objects_1892_0004","objects_1892_0005","objects_1892_0006","objects_1892_0007",8);
		CreateAnimationUW("440_walking_rear_left","objects_1889_0000","objects_1889_0001","objects_1889_0002","objects_1889_0003","objects_1889_0004","objects_1889_0005","objects_1889_0006","objects_1889_0007",8);
		CreateAnimationUW("440_walking_rear_right","objects_1891_0000","objects_1891_0001","objects_1891_0002","objects_1891_0003","objects_1891_0004","objects_1891_0005","objects_1891_0006","objects_1891_0007",8);
		CreateAnimationUW("442_Attack1","objects_1403_0000","objects_1403_0001","objects_1403_0002","objects_1403_0003","","","","",4);
		CreateAnimationUW("442_Attack2","objects_2116_0000","objects_2116_0001","objects_2116_0002","objects_2116_0003","","","","",4);
		CreateAnimationUW("442_Combat_Idle","objects_1440_0000","objects_1440_0001","objects_1440_0002","objects_1440_0003","","","","",4);
		CreateAnimationUW("442_Death","objects_1477_0000","objects_1477_0001","objects_1477_0002","objects_1477_0003","","","","",4);
		CreateAnimationUW("442_idle_front","objects_1615_0000","objects_1615_0001","objects_1615_0002","objects_1615_0003","objects_1615_0004","objects_1615_0005","objects_1615_0006","objects_1615_0007",8);
		CreateAnimationUW("442_idle_front_left","objects_1616_0000","objects_1616_0001","objects_1616_0002","objects_1616_0003","objects_1616_0004","objects_1616_0005","objects_1616_0006","objects_1616_0007",8);
		CreateAnimationUW("442_idle_front_right","objects_1614_0000","objects_1614_0001","objects_1614_0002","objects_1614_0003","objects_1614_0004","objects_1614_0005","objects_1614_0006","objects_1614_0007",8);
		CreateAnimationUW("442_idle_left","objects_1609_0000","objects_1609_0001","objects_1609_0002","objects_1609_0003","objects_1609_0004","objects_1609_0005","objects_1609_0006","objects_1609_0007",8);
		CreateAnimationUW("442_idle_rear","objects_1611_0000","objects_1611_0001","objects_1611_0002","objects_1611_0003","objects_1611_0004","objects_1611_0005","objects_1611_0006","objects_1611_0007",8);
		CreateAnimationUW("442_idle_rear_left","objects_1610_0000","objects_1610_0001","objects_1610_0002","objects_1610_0003","objects_1610_0004","objects_1610_0005","objects_1610_0006","objects_1610_0007",8);
		CreateAnimationUW("442_idle_rear_right","objects_1612_0000","objects_1612_0001","objects_1612_0002","objects_1612_0003","objects_1612_0004","objects_1612_0005","objects_1612_0006","objects_1612_0007",8);
		CreateAnimationUW("442_idle_right","objects_1613_0000","objects_1613_0001","objects_1613_0002","objects_1613_0003","objects_1613_0004","objects_1613_0005","objects_1613_0006","objects_1613_0007",8);
		CreateAnimationUW("442_walking_front","objects_1910_0000","objects_1910_0001","objects_1910_0002","objects_1910_0003","objects_1910_0004","objects_1910_0005","objects_1910_0006","objects_1910_0007",8);
		CreateAnimationUW("442_walking_front_left","objects_1911_0000","objects_1911_0001","objects_1911_0002","objects_1911_0003","objects_1911_0004","objects_1911_0005","objects_1911_0006","objects_1911_0007",8);
		CreateAnimationUW("442_walking_front_right","objects_1909_0000","objects_1909_0001","objects_1909_0002","objects_1909_0003","objects_1909_0004","objects_1909_0005","objects_1909_0006","objects_1909_0007",8);
		CreateAnimationUW("442_walking_left","objects_1904_0000","objects_1904_0001","objects_1904_0002","objects_1904_0003","objects_1904_0004","objects_1904_0005","objects_1904_0006","objects_1904_0007",8);
		CreateAnimationUW("442_walking_rear","objects_1906_0000","objects_1906_0001","objects_1906_0002","objects_1906_0003","objects_1906_0004","objects_1906_0005","objects_1906_0006","objects_1906_0007",8);
		CreateAnimationUW("442_walking_rear_left","objects_1905_0000","objects_1905_0001","objects_1905_0002","objects_1905_0003","objects_1905_0004","objects_1905_0005","objects_1905_0006","objects_1905_0007",8);
		CreateAnimationUW("442_walking_rear_right","objects_1907_0000","objects_1907_0001","objects_1907_0002","objects_1907_0003","objects_1907_0004","objects_1907_0005","objects_1907_0006","objects_1907_0007",8);
		CreateAnimationUW("442_walking_right","objects_1908_0000","objects_1908_0001","objects_1908_0002","objects_1908_0003","objects_1908_0004","objects_1908_0005","objects_1908_0006","objects_1908_0007",8);
		CreateAnimationUW("443_Attack1","objects_1404_0000","objects_1404_0001","objects_1404_0002","objects_1404_0003","objects_1404_0004","","","",5);
		CreateAnimationUW("443_Attack2","objects_2117_0000","objects_2117_0001","objects_2117_0002","objects_2117_0003","objects_2117_0004","","","",5);
		CreateAnimationUW("443_Combat_Idle","objects_1441_0000","objects_1441_0001","objects_1441_0002","objects_1441_0003","objects_1441_0004","","","",5);
		CreateAnimationUW("443_Death","objects_1478_0000","objects_1478_0001","objects_1478_0002","objects_1478_0003","","","","",4);
		CreateAnimationUW("443_idle_front","objects_1623_0000","objects_1623_0001","objects_1623_0002","objects_1623_0003","objects_1623_0004","","","",5);
		CreateAnimationUW("443_idle_front_left","objects_1624_0000","objects_1624_0001","objects_1624_0002","objects_1624_0003","objects_1624_0004","","","",5);
		CreateAnimationUW("443_idle_front_right","objects_1622_0000","objects_1622_0001","objects_1622_0002","objects_1622_0003","objects_1622_0004","","","",5);
		CreateAnimationUW("443_idle_left","objects_1617_0000","objects_1617_0001","objects_1617_0002","objects_1617_0003","objects_1617_0004","","","",5);
		CreateAnimationUW("443_idle_rear","objects_1619_0000","objects_1619_0001","objects_1619_0002","objects_1619_0003","objects_1619_0004","","","",5);
		CreateAnimationUW("443_idle_rear_left","objects_1618_0000","objects_1618_0001","objects_1618_0002","objects_1618_0003","objects_1618_0004","","","",5);
		CreateAnimationUW("443_idle_rear_right","objects_1620_0000","objects_1620_0001","objects_1620_0002","objects_1620_0003","objects_1620_0004","","","",5);
		CreateAnimationUW("443_idle_right","objects_1621_0000","objects_1621_0001","objects_1621_0002","objects_1621_0003","objects_1621_0004","","","",5);
		CreateAnimationUW("443_walking_front","objects_1918_0000","objects_1918_0001","objects_1918_0002","objects_1918_0003","","","","",4);
		CreateAnimationUW("443_walking_front_left","objects_1919_0000","objects_1919_0001","objects_1919_0002","objects_1919_0003","","","","",4);
		CreateAnimationUW("443_walking_front_right","objects_1917_0000","objects_1917_0001","objects_1917_0002","objects_1917_0003","","","","",4);
		CreateAnimationUW("443_walking_left","objects_1912_0000","objects_1912_0001","objects_1912_0002","objects_1912_0003","","","","",4);
		CreateAnimationUW("443_walking_rear","objects_1914_0000","objects_1914_0001","objects_1914_0002","objects_1914_0003","","","","",4);
		CreateAnimationUW("443_walking_rear_left","objects_1913_0000","objects_1913_0001","objects_1913_0002","objects_1913_0003","","","","",4);
		CreateAnimationUW("443_walking_rear_right","objects_1915_0000","objects_1915_0001","objects_1915_0002","objects_1915_0003","","","","",4);
		CreateAnimationUW("443_walking_right","objects_1916_0000","objects_1916_0001","objects_1916_0002","objects_1916_0003","","","","",4);
		CreateAnimationUW("444_Attack1","objects_1405_0000","objects_1405_0001","objects_1405_0002","objects_1405_0003","objects_1405_0004","objects_1405_0005","","",6);
		CreateAnimationUW("444_Attack2","objects_2118_0000","objects_2118_0001","objects_2118_0002","objects_2118_0003","objects_2118_0004","objects_2118_0005","","",6);
		CreateAnimationUW("444_Combat_Idle","objects_1442_0000","objects_1442_0001","objects_1442_0002","objects_1442_0003","objects_1442_0004","objects_1442_0005","","",6);
		CreateAnimationUW("444_Death","objects_1479_0000","objects_1479_0001","objects_1479_0002","objects_1479_0003","objects_1479_0004","objects_1479_0005","objects_1479_0006","",7);
		CreateAnimationUW("444_idle_front","objects_1631_0000","objects_1631_0001","objects_1631_0002","","","","","",3);
		CreateAnimationUW("444_idle_front_left","objects_1632_0000","objects_1632_0001","objects_1632_0002","","","","","",3);
		CreateAnimationUW("444_idle_front_right","objects_1630_0000","objects_1630_0001","objects_1630_0002","","","","","",3);
		CreateAnimationUW("444_idle_left","objects_1625_0000","objects_1625_0001","objects_1625_0002","","","","","",3);
		CreateAnimationUW("444_idle_rear","objects_1627_0000","objects_1627_0001","objects_1627_0002","","","","","",3);
		CreateAnimationUW("444_idle_rear_left","objects_1626_0000","objects_1626_0001","objects_1626_0002","","","","","",3);
		CreateAnimationUW("444_idle_rear_right","objects_1628_0000","objects_1628_0001","objects_1628_0002","","","","","",3);
		CreateAnimationUW("444_idle_right","objects_1629_0000","objects_1629_0001","objects_1629_0002","","","","","",3);
		CreateAnimationUW("444_walking_front","objects_1926_0000","objects_1926_0001","objects_1926_0002","objects_1926_0003","objects_1926_0004","objects_1926_0005","","",6);
		CreateAnimationUW("444_walking_front_left","objects_1927_0000","objects_1927_0001","objects_1927_0002","objects_1927_0003","objects_1927_0004","objects_1927_0005","","",6);
		CreateAnimationUW("444_walking_front_right","objects_1925_0000","objects_1925_0001","objects_1925_0002","objects_1925_0003","objects_1925_0004","objects_1925_0005","","",6);
		CreateAnimationUW("444_walking_left","objects_1920_0000","objects_1920_0001","objects_1920_0002","objects_1920_0003","objects_1920_0004","objects_1920_0005","","",6);
		CreateAnimationUW("444_walking_rear","objects_1922_0000","objects_1922_0001","objects_1922_0002","objects_1922_0003","objects_1922_0004","objects_1922_0005","","",6);
		CreateAnimationUW("444_walking_rear_left","objects_1921_0000","objects_1921_0001","objects_1921_0002","objects_1921_0003","objects_1921_0004","objects_1921_0005","","",6);
		CreateAnimationUW("444_walking_rear_right","objects_1923_0000","objects_1923_0001","objects_1923_0002","objects_1923_0003","objects_1923_0004","objects_1923_0005","","",6);
		CreateAnimationUW("444_walking_right","objects_1924_0000","objects_1924_0001","objects_1924_0002","objects_1924_0003","objects_1924_0004","objects_1924_0005","","",6);
		CreateAnimationUW("446_Attack1","objects_1407_0000","objects_1407_0001","objects_1407_0002","objects_1407_0003","objects_1407_0004","objects_1407_0005","","",6);
		CreateAnimationUW("446_Attack2","objects_2120_0000","objects_2120_0001","objects_2120_0002","objects_2120_0003","objects_2120_0004","objects_2120_0005","","",6);
		CreateAnimationUW("446_Combat_Idle","objects_1444_0000","objects_1444_0001","objects_1444_0002","objects_1444_0003","objects_1444_0004","objects_1444_0005","","",6);
		CreateAnimationUW("446_Death","objects_1481_0000","objects_1481_0001","objects_1481_0002","objects_1481_0003","objects_1481_0004","","","",5);
		CreateAnimationUW("446_idle_front","objects_1647_0000","objects_1647_0001","objects_1647_0002","objects_1647_0003","objects_1647_0004","objects_1647_0005","","",6);
		CreateAnimationUW("446_idle_front_left","objects_1648_0000","objects_1648_0001","objects_1648_0002","objects_1648_0003","objects_1648_0004","objects_1648_0005","","",6);
		CreateAnimationUW("446_idle_front_right","objects_1646_0000","objects_1646_0001","objects_1646_0002","objects_1646_0003","objects_1646_0004","objects_1646_0005","","",6);
		CreateAnimationUW("446_idle_left","objects_1641_0000","objects_1641_0001","objects_1641_0002","objects_1641_0003","objects_1641_0004","objects_1641_0005","","",6);
		CreateAnimationUW("446_idle_rear","objects_1643_0000","objects_1643_0001","objects_1643_0002","objects_1643_0003","objects_1643_0004","objects_1643_0005","","",6);
		CreateAnimationUW("446_idle_rear_left","objects_1642_0000","objects_1642_0001","objects_1642_0002","objects_1642_0003","objects_1642_0004","objects_1642_0005","","",6);
		CreateAnimationUW("446_idle_rear_right","objects_1644_0000","objects_1644_0001","objects_1644_0002","objects_1644_0003","objects_1644_0004","objects_1644_0005","","",6);
		CreateAnimationUW("446_idle_right","objects_1645_0000","objects_1645_0001","objects_1645_0002","objects_1645_0003","objects_1645_0004","objects_1645_0005","","",6);
		CreateAnimationUW("446_walking_front","objects_1942_0000","objects_1942_0001","objects_1942_0002","objects_1942_0003","objects_1942_0004","objects_1942_0005","","",6);
		CreateAnimationUW("446_walking_front_left","objects_1943_0000","objects_1943_0001","objects_1943_0002","objects_1943_0003","objects_1943_0004","objects_1943_0005","","",6);
		CreateAnimationUW("446_walking_front_right","objects_1941_0000","objects_1941_0001","objects_1941_0002","objects_1941_0003","objects_1941_0004","objects_1941_0005","","",6);
		CreateAnimationUW("446_walking_left","objects_1936_0000","objects_1936_0001","objects_1936_0002","objects_1936_0003","objects_1936_0004","objects_1936_0005","","",6);
		CreateAnimationUW("446_walking_rear","objects_1938_0000","objects_1938_0001","objects_1938_0002","objects_1938_0003","objects_1938_0004","objects_1938_0005","","",6);
		CreateAnimationUW("446_walking_rear_left","objects_1937_0000","objects_1937_0001","objects_1937_0002","objects_1937_0003","objects_1937_0004","objects_1937_0005","","",6);
		CreateAnimationUW("446_walking_rear_right","objects_1939_0000","objects_1939_0001","objects_1939_0002","objects_1939_0003","objects_1939_0004","objects_1939_0005","","",6);
		CreateAnimationUW("446_walking_right","objects_1940_0000","objects_1940_0001","objects_1940_0002","objects_1940_0003","objects_1940_0004","objects_1940_0005","","",6);
		CreateAnimationUW("447_Attack1","objects_1408_0000","objects_1408_0001","objects_1408_0002","","","","","",3);
		CreateAnimationUW("447_Attack2","objects_2121_0000","objects_2121_0001","objects_2121_0002","objects_2121_0003","","","","",4);
		CreateAnimationUW("447_Combat_Idle","objects_1445_0000","objects_1445_0001","","","","","","",2);
		CreateAnimationUW("447_Death","objects_1482_0000","objects_1482_0001","objects_1482_0002","objects_1482_0003","objects_1482_0004","objects_1482_0005","objects_1482_0006","objects_1482_0007",8);
		CreateAnimationUW("447_idle_front","objects_1655_0000","objects_1655_0001","objects_1655_0002","objects_1655_0003","objects_1655_0004","","","",5);
		CreateAnimationUW("447_idle_front_left","objects_1656_0000","objects_1656_0001","objects_1656_0002","objects_1656_0003","objects_1656_0004","","","",5);
		CreateAnimationUW("447_idle_front_right","objects_1654_0000","objects_1654_0001","objects_1654_0002","objects_1654_0003","objects_1654_0004","","","",5);
		CreateAnimationUW("447_idle_left","objects_1649_0000","objects_1649_0001","objects_1649_0002","objects_1649_0003","objects_1649_0004","","","",5);
		CreateAnimationUW("447_idle_rear","objects_1651_0000","objects_1651_0001","objects_1651_0002","objects_1651_0003","objects_1651_0004","","","",5);
		CreateAnimationUW("447_idle_rear_left","objects_1650_0000","objects_1650_0001","objects_1650_0002","objects_1650_0003","objects_1650_0004","","","",5);
		CreateAnimationUW("447_idle_rear_right","objects_1652_0000","objects_1652_0001","objects_1652_0002","objects_1652_0003","objects_1652_0004","","","",5);
		CreateAnimationUW("447_idle_right","objects_1653_0000","objects_1653_0001","objects_1653_0002","objects_1653_0003","objects_1653_0004","","","",5);
		CreateAnimationUW("447_walking_front","objects_1950_0000","objects_1950_0001","objects_1950_0002","objects_1950_0003","objects_1950_0004","objects_1950_0005","objects_1950_0006","",7);
		CreateAnimationUW("447_walking_front_left","objects_1951_0000","objects_1951_0001","objects_1951_0002","objects_1951_0003","objects_1951_0004","objects_1951_0005","objects_1951_0006","",7);
		CreateAnimationUW("447_walking_front_right","objects_1949_0000","objects_1949_0001","objects_1949_0002","objects_1949_0003","objects_1949_0004","objects_1949_0005","objects_1949_0006","",7);
		CreateAnimationUW("447_walking_left","objects_1944_0000","objects_1944_0001","objects_1944_0002","objects_1944_0003","objects_1944_0004","objects_1944_0005","objects_1944_0006","",7);
		CreateAnimationUW("447_walking_rear","objects_1946_0000","objects_1946_0001","objects_1946_0002","objects_1946_0003","objects_1946_0004","objects_1946_0005","objects_1946_0006","",7);
		CreateAnimationUW("447_walking_rear_left","objects_1945_0000","objects_1945_0001","objects_1945_0002","objects_1945_0003","objects_1945_0004","objects_1945_0005","objects_1945_0006","",7);
		CreateAnimationUW("447_walking_rear_right","objects_1947_0000","objects_1947_0001","objects_1947_0002","objects_1947_0003","objects_1947_0004","objects_1947_0005","objects_1947_0006","",7);
		CreateAnimationUW("447_walking_right","objects_1948_0000","objects_1948_0001","objects_1948_0002","objects_1948_0003","objects_1948_0004","objects_1948_0005","objects_1948_0006","",7);
		CreateAnimationUW("449_Attack1","objects_1410_0000","objects_1410_0001","objects_1410_0002","objects_1410_0003","objects_1410_0004","objects_1410_0005","","",6);
		CreateAnimationUW("449_Attack2","objects_2123_0000","objects_2123_0001","objects_2123_0002","objects_2123_0003","objects_2123_0004","objects_2123_0005","","",6);
		CreateAnimationUW("449_Combat_Idle","objects_1447_0000","objects_1447_0001","objects_1447_0002","objects_1447_0003","objects_1447_0004","","","",5);
		CreateAnimationUW("449_Death","objects_1484_0000","objects_1484_0001","objects_1484_0002","objects_1484_0003","objects_1484_0004","objects_1484_0005","","",6);
		CreateAnimationUW("449_idle_front","objects_1671_0000","objects_1671_0001","objects_1671_0002","","","","","",3);
		CreateAnimationUW("449_idle_front_left","objects_1672_0000","objects_1672_0001","objects_1672_0002","","","","","",3);
		CreateAnimationUW("449_idle_front_right","objects_1670_0000","objects_1670_0001","objects_1670_0002","","","","","",3);
		CreateAnimationUW("449_idle_left","objects_1665_0000","objects_1665_0001","objects_1665_0002","","","","","",3);
		CreateAnimationUW("449_idle_rear","objects_1667_0000","objects_1667_0001","objects_1667_0002","","","","","",3);
		CreateAnimationUW("449_idle_rear_left","objects_1666_0000","objects_1666_0001","objects_1666_0002","","","","","",3);
		CreateAnimationUW("449_idle_rear_right","objects_1668_0000","objects_1668_0001","objects_1668_0002","","","","","",3);
		CreateAnimationUW("449_idle_right","objects_1669_0000","objects_1669_0001","objects_1669_0002","","","","","",3);
		CreateAnimationUW("449_walking_front","objects_1966_0000","objects_1966_0001","objects_1966_0002","objects_1966_0003","objects_1966_0004","objects_1966_0005","objects_1966_0006","objects_1966_0007",8);
		CreateAnimationUW("449_walking_front_left","objects_1967_0000","objects_1967_0001","objects_1967_0002","objects_1967_0003","objects_1967_0004","objects_1967_0005","objects_1967_0006","",7);
		CreateAnimationUW("449_walking_front_right","objects_1965_0000","objects_1965_0001","objects_1965_0002","objects_1965_0003","objects_1965_0004","objects_1965_0005","objects_1965_0006","objects_1965_0007",8);
		CreateAnimationUW("449_walking_left","objects_1960_0000","objects_1960_0001","objects_1960_0002","objects_1960_0003","objects_1960_0004","objects_1960_0005","objects_1960_0006","objects_1960_0007",8);
		CreateAnimationUW("449_walking_rear","objects_1962_0000","objects_1962_0001","objects_1962_0002","objects_1962_0003","objects_1962_0004","objects_1962_0005","objects_1962_0006","objects_1962_0007",8);
		CreateAnimationUW("449_walking_rear_left","objects_1961_0000","objects_1961_0001","objects_1961_0002","objects_1961_0003","objects_1961_0004","objects_1961_0005","objects_1961_0006","objects_1961_0007",8);
		CreateAnimationUW("449_walking_rear_right","objects_1963_0000","objects_1963_0001","objects_1963_0002","objects_1963_0003","objects_1963_0004","objects_1963_0005","objects_1963_0006","objects_1963_0007",8);
		CreateAnimationUW("449_walking_right","objects_1964_0000","objects_1964_0001","objects_1964_0002","objects_1964_0003","objects_1964_0004","objects_1964_0005","objects_1964_0006","objects_1964_0007",8);
		CreateAnimationUW("450_Attack1","objects_1411_0000","objects_1411_0001","objects_1411_0002","objects_1411_0003","objects_1411_0004","","","",5);
		CreateAnimationUW("450_Attack2","objects_2124_0000","objects_2124_0001","objects_2124_0002","objects_2124_0003","objects_2124_0004","","","",5);
		CreateAnimationUW("450_Combat_Idle","objects_1448_0000","objects_1448_0001","objects_1448_0002","objects_1448_0003","","","","",4);
		CreateAnimationUW("450_Death","objects_1485_0000","objects_1485_0001","objects_1485_0002","objects_1485_0003","objects_1485_0004","","","",5);
		CreateAnimationUW("450_idle_front","objects_1679_0000","objects_1679_0001","objects_1679_0002","objects_1679_0003","","","","",4);
		CreateAnimationUW("450_idle_front_left","objects_1680_0000","objects_1680_0001","objects_1680_0002","objects_1680_0003","","","","",4);
		CreateAnimationUW("450_idle_front_right","objects_1678_0000","objects_1678_0001","objects_1678_0002","objects_1678_0003","","","","",4);
		CreateAnimationUW("450_idle_left","objects_1673_0000","objects_1673_0001","objects_1673_0002","objects_1673_0003","","","","",4);
		CreateAnimationUW("450_idle_rear","objects_1675_0000","objects_1675_0001","objects_1675_0002","objects_1675_0003","","","","",4);
		CreateAnimationUW("450_idle_rear_left","objects_1674_0000","objects_1674_0001","objects_1674_0002","objects_1674_0003","","","","",4);
		CreateAnimationUW("450_idle_rear_right","objects_1676_0000","objects_1676_0001","objects_1676_0002","objects_1676_0003","","","","",4);
		CreateAnimationUW("450_idle_right","objects_1677_0000","objects_1677_0001","objects_1677_0002","objects_1677_0003","","","","",4);
		CreateAnimationUW("450_walking_front","objects_1974_0000","objects_1974_0001","objects_1974_0002","objects_1974_0003","","","","",4);
		CreateAnimationUW("450_walking_front_left","objects_1975_0000","objects_1975_0001","objects_1975_0002","objects_1975_0003","","","","",4);
		CreateAnimationUW("450_walking_front_right","objects_1973_0000","objects_1973_0001","objects_1973_0002","objects_1973_0003","","","","",4);
		CreateAnimationUW("450_walking_left","objects_1968_0000","objects_1968_0001","objects_1968_0002","objects_1968_0003","","","","",4);
		CreateAnimationUW("450_walking_rear","objects_1970_0000","objects_1970_0001","objects_1970_0002","objects_1970_0003","","","","",4);
		CreateAnimationUW("450_walking_rear_left","objects_1969_0000","objects_1969_0001","objects_1969_0002","objects_1969_0003","","","","",4);
		CreateAnimationUW("450_walking_rear_right","objects_1971_0000","objects_1971_0001","objects_1971_0002","objects_1971_0003","","","","",4);
		CreateAnimationUW("450_walking_right","objects_1972_0000","objects_1972_0001","objects_1972_0002","objects_1972_0003","","","","",4);
		CreateAnimationUW("451_Attack1","objects_1412_0000","objects_1412_0001","objects_1412_0002","","","","","",3);
		CreateAnimationUW("451_Attack2","objects_2125_0000","objects_2125_0001","objects_2125_0002","","","","","",3);
		CreateAnimationUW("451_Combat_Idle","objects_1449_0000","objects_1449_0001","objects_1449_0002","objects_1449_0003","objects_1449_0004","objects_1449_0005","objects_1449_0006","",7);
		CreateAnimationUW("451_Death","objects_1486_0000","objects_1486_0001","objects_1486_0002","objects_1486_0003","objects_1486_0004","","","",5);
		CreateAnimationUW("451_idle_front","objects_1687_0000","objects_1687_0001","objects_1687_0002","objects_1687_0003","objects_1687_0004","","","",5);
		CreateAnimationUW("451_idle_front_left","objects_1688_0000","objects_1688_0001","objects_1688_0002","objects_1688_0003","objects_1688_0004","","","",5);
		CreateAnimationUW("451_idle_front_right","objects_1686_0000","objects_1686_0001","objects_1686_0002","objects_1686_0003","objects_1686_0004","","","",5);
		CreateAnimationUW("451_idle_left","objects_1681_0000","objects_1681_0001","objects_1681_0002","objects_1681_0003","objects_1681_0004","","","",5);
		CreateAnimationUW("451_idle_rear","objects_1683_0000","objects_1683_0001","objects_1683_0002","objects_1683_0003","objects_1683_0004","","","",5);
		CreateAnimationUW("451_idle_rear_left","objects_1682_0000","objects_1682_0001","objects_1682_0002","objects_1682_0003","objects_1682_0004","","","",5);
		CreateAnimationUW("451_idle_rear_right","objects_1684_0000","objects_1684_0001","objects_1684_0002","objects_1684_0003","objects_1684_0004","","","",5);
		CreateAnimationUW("451_idle_right","objects_1685_0000","objects_1685_0001","objects_1685_0002","objects_1685_0003","objects_1685_0004","","","",5);
		CreateAnimationUW("451_walking_front","objects_1982_0000","objects_1982_0001","objects_1982_0002","objects_1982_0003","objects_1982_0004","objects_1982_0005","objects_1982_0006","objects_1982_0007",8);
		CreateAnimationUW("451_walking_front_left","objects_1983_0000","objects_1983_0001","objects_1983_0002","objects_1983_0003","objects_1983_0004","objects_1983_0005","objects_1983_0006","objects_1983_0007",8);
		CreateAnimationUW("451_walking_front_right","objects_1981_0000","objects_1981_0001","objects_1981_0002","objects_1981_0003","objects_1981_0004","objects_1981_0005","objects_1981_0006","objects_1981_0007",8);
		CreateAnimationUW("451_walking_left","objects_1976_0000","objects_1976_0001","objects_1976_0002","objects_1976_0003","objects_1976_0004","objects_1976_0005","objects_1976_0006","objects_1976_0007",8);
		CreateAnimationUW("451_walking_rear","objects_1978_0000","objects_1978_0001","objects_1978_0002","objects_1978_0003","objects_1978_0004","objects_1978_0005","objects_1978_0006","objects_1978_0007",8);
		CreateAnimationUW("451_walking_rear_left","objects_1977_0000","objects_1977_0001","objects_1977_0002","objects_1977_0003","objects_1977_0004","objects_1977_0005","objects_1977_0006","objects_1977_0007",8);
		CreateAnimationUW("451_walking_rear_right","objects_1979_0000","objects_1979_0001","objects_1979_0002","objects_1979_0003","objects_1979_0004","objects_1979_0005","objects_1979_0006","objects_1979_0007",8);
		CreateAnimationUW("451_walking_right","objects_1980_0000","objects_1980_0001","objects_1980_0002","objects_1980_0003","objects_1980_0004","objects_1980_0005","objects_1980_0006","objects_1980_0007",8);
		CreateAnimationUW("453_Attack1","objects_1414_0000","objects_1414_0001","objects_1414_0002","","","","","",3);
		CreateAnimationUW("453_Attack2","objects_2127_0000","objects_2127_0001","objects_2127_0002","","","","","",3);
		CreateAnimationUW("453_Combat_Idle","objects_1451_0000","objects_1451_0001","","","","","","",2);
		CreateAnimationUW("453_Death","objects_1488_0000","objects_1488_0001","objects_1488_0002","objects_1488_0003","objects_1488_0004","objects_1488_0005","objects_1488_0006","",7);
		CreateAnimationUW("453_idle_front","objects_1696_0000","objects_1696_0001","objects_1696_0002","objects_1696_0003","objects_1696_0004","","","",5);
		CreateAnimationUW("453_idle_front_left","objects_1697_0000","objects_1697_0001","","","","","","",2);
		CreateAnimationUW("453_idle_front_right","objects_1695_0000","objects_1695_0001","","","","","","",2);
		CreateAnimationUW("453_idle_left","objects_1690_0000","objects_1690_0001","","","","","","",2);
		CreateAnimationUW("453_idle_rear","objects_1692_0000","objects_1692_0001","","","","","","",2);
		CreateAnimationUW("453_idle_rear_left","objects_1691_0000","objects_1691_0001","","","","","","",2);
		CreateAnimationUW("453_idle_rear_right","objects_1693_0000","objects_1693_0001","","","","","","",2);
		CreateAnimationUW("453_idle_right","objects_1694_0000","objects_1694_0001","","","","","","",2);
		CreateAnimationUW("453_walking_front","objects_1991_0000","objects_1991_0001","objects_1991_0002","objects_1991_0003","objects_1991_0004","","","",5);
		CreateAnimationUW("453_walking_front_left","objects_1992_0000","objects_1992_0001","objects_1992_0002","objects_1992_0003","objects_1992_0004","","","",5);
		CreateAnimationUW("453_walking_front_right","objects_1990_0000","objects_1990_0001","objects_1990_0002","objects_1990_0003","objects_1990_0004","","","",5);
		CreateAnimationUW("453_walking_left","objects_1985_0000","objects_1985_0001","objects_1985_0002","objects_1985_0003","objects_1985_0004","","","",5);
		CreateAnimationUW("453_walking_rear","objects_1987_0000","objects_1987_0001","objects_1987_0002","objects_1987_0003","objects_1987_0004","","","",5);
		CreateAnimationUW("453_walking_rear_left","objects_1986_0000","objects_1986_0001","objects_1986_0002","objects_1986_0003","objects_1986_0004","","","",5);
		CreateAnimationUW("453_walking_rear_right","objects_1988_0000","objects_1988_0001","objects_1988_0002","objects_1988_0003","objects_1988_0004","","","",5);
		CreateAnimationUW("453_walking_right","objects_1989_0000","objects_1989_0001","objects_1989_0002","objects_1989_0003","objects_1989_0004","","","",5);
		CreateAnimationUW("454_Attack1","objects_1415_0000","objects_1415_0001","objects_1415_0002","","","","","",3);
		CreateAnimationUW("454_Attack2","objects_2128_0000","objects_2128_0001","objects_2128_0002","objects_2128_0003","objects_2128_0004","","","",5);
		CreateAnimationUW("454_Combat_Idle","objects_1452_0000","objects_1452_0001","objects_1452_0002","objects_1452_0003","objects_1452_0004","","","",5);
		CreateAnimationUW("454_Death","objects_1489_0000","objects_1489_0001","objects_1489_0002","objects_1489_0003","objects_1489_0004","","","",5);
		CreateAnimationUW("454_idle_front","objects_1704_0000","objects_1704_0001","objects_1704_0002","objects_1704_0003","objects_1704_0004","","","",5);
		CreateAnimationUW("454_idle_front_left","objects_1705_0000","objects_1705_0001","objects_1705_0002","objects_1705_0003","objects_1705_0004","","","",5);
		CreateAnimationUW("454_idle_front_right","objects_1703_0000","objects_1703_0001","objects_1703_0002","objects_1703_0003","objects_1703_0004","","","",5);
		CreateAnimationUW("454_idle_left","objects_1698_0000","objects_1698_0001","objects_1698_0002","objects_1698_0003","objects_1698_0004","","","",5);
		CreateAnimationUW("454_idle_rear","objects_1700_0000","objects_1700_0001","objects_1700_0002","objects_1700_0003","objects_1700_0004","","","",5);
		CreateAnimationUW("454_idle_rear_left","objects_1699_0000","objects_1699_0001","objects_1699_0002","objects_1699_0003","objects_1699_0004","","","",5);
		CreateAnimationUW("454_idle_rear_right","objects_1701_0000","objects_1701_0001","objects_1701_0002","objects_1701_0003","objects_1701_0004","","","",5);
		CreateAnimationUW("454_idle_right","objects_1702_0000","objects_1702_0001","objects_1702_0002","objects_1702_0003","objects_1702_0004","","","",5);
		CreateAnimationUW("454_walking_front","objects_1999_0000","objects_1999_0001","objects_1999_0002","objects_1999_0003","objects_1999_0004","","","",5);
		CreateAnimationUW("454_walking_front_left","objects_2000_0000","objects_2000_0001","objects_2000_0002","objects_2000_0003","objects_2000_0004","","","",5);
		CreateAnimationUW("454_walking_front_right","objects_1998_0000","objects_1998_0001","objects_1998_0002","objects_1998_0003","objects_1998_0004","","","",5);
		CreateAnimationUW("454_walking_left","objects_1993_0000","objects_1993_0001","objects_1993_0002","objects_1993_0003","objects_1993_0004","","","",5);
		CreateAnimationUW("454_walking_rear","objects_1995_0000","objects_1995_0001","objects_1995_0002","objects_1995_0003","objects_1995_0004","","","",5);
		CreateAnimationUW("454_walking_rear_left","objects_1994_0000","objects_1994_0001","objects_1994_0002","objects_1994_0003","objects_1994_0004","","","",5);
		CreateAnimationUW("454_walking_rear_right","objects_1996_0000","objects_1996_0001","objects_1996_0002","objects_1996_0003","objects_1996_0004","","","",5);
		CreateAnimationUW("454_walking_right","objects_1997_0000","objects_1997_0001","objects_1997_0002","objects_1997_0003","objects_1997_0004","","","",5);
		CreateAnimationUW("455_Attack1","objects_1416_0000","objects_1416_0001","objects_1416_0002","objects_1416_0003","","","","",4);
		CreateAnimationUW("455_Attack2","objects_2129_0000","objects_2129_0001","objects_2129_0002","objects_2129_0003","","","","",4);
		CreateAnimationUW("455_Combat_Idle","objects_1453_0000","objects_1453_0001","objects_1453_0002","objects_1453_0003","objects_1453_0004","","","",5);
		CreateAnimationUW("455_Death","objects_1490_0000","objects_1490_0001","objects_1490_0002","objects_1490_0003","objects_1490_0004","","","",5);
		CreateAnimationUW("455_idle_front","objects_1712_0000","objects_1712_0001","objects_1712_0002","objects_1712_0003","objects_1712_0004","","","",5);
		CreateAnimationUW("455_idle_front_left","objects_1713_0000","objects_1713_0001","objects_1713_0002","objects_1713_0003","objects_1713_0004","","","",5);
		CreateAnimationUW("455_idle_right","objects_1710_0000","objects_1710_0001","objects_1710_0002","objects_1710_0003","objects_1710_0004","","","",5);
		CreateAnimationUW("455_idle_front_right","objects_1711_0000","objects_1711_0001","objects_1711_0002","objects_1711_0003","objects_1711_0004","","","",5);
		CreateAnimationUW("455_idle_left","objects_1706_0000","objects_1706_0001","objects_1706_0002","objects_1706_0003","","","","",4);
		CreateAnimationUW("455_idle_rear","objects_1708_0000","objects_1708_0001","objects_1708_0002","objects_1708_0003","","","","",4);
		CreateAnimationUW("455_idle_rear_left","objects_1707_0000","objects_1707_0001","objects_1707_0002","objects_1707_0003","objects_1707_0004","","","",5);
		CreateAnimationUW("455_idle_rear_right","objects_1709_0000","objects_1709_0001","objects_1709_0002","objects_1709_0003","","","","",4);
		CreateAnimationUW("455_walking_front","objects_2007_0000","objects_2007_0001","objects_2007_0002","objects_2007_0003","objects_2007_0004","objects_2007_0005","objects_2007_0006","objects_2007_0007",8);
		CreateAnimationUW("455_walking_front_left","objects_2008_0000","objects_2008_0001","objects_2008_0002","objects_2008_0003","objects_2008_0004","objects_2008_0005","objects_2008_0006","objects_2008_0007",8);
		CreateAnimationUW("455_walking_front_right","objects_2006_0000","objects_2006_0001","objects_2006_0002","objects_2006_0003","objects_2006_0004","objects_2006_0005","objects_2006_0006","objects_2006_0007",8);
		CreateAnimationUW("455_walking_left","objects_2001_0000","objects_2001_0001","objects_2001_0002","objects_2001_0003","objects_2001_0004","objects_2001_0005","objects_2001_0006","objects_2001_0007",8);
		CreateAnimationUW("455_walking_rear","objects_2003_0000","objects_2003_0001","objects_2003_0002","objects_2003_0003","objects_2003_0004","objects_2003_0005","objects_2003_0006","objects_2003_0007",8);
		CreateAnimationUW("455_walking_rear_left","objects_2002_0000","objects_2002_0001","objects_2002_0002","objects_2002_0003","objects_2002_0004","objects_2002_0005","objects_2002_0006","objects_2002_0007",8);
		CreateAnimationUW("455_walking_rear_right","objects_2004_0000","objects_2004_0001","objects_2004_0002","objects_2004_0003","objects_2004_0004","objects_2004_0005","objects_2004_0006","objects_2004_0007",8);
		CreateAnimationUW("455_walking_right","objects_2005_0000","objects_2005_0001","objects_2005_0002","objects_2005_0003","objects_2005_0004","objects_2005_0005","objects_2005_0006","objects_2005_0007",8);
		CreateAnimationUW("456_Attack1","objects_1417_0000","objects_1417_0001","","","","","","",2);
		CreateAnimationUW("456_Attack2","objects_2130_0000","objects_2130_0001","","","","","","",2);
		CreateAnimationUW("456_Combat_Idle","objects_1454_0000","objects_1454_0001","","","","","","",2);
		CreateAnimationUW("456_Death","objects_1491_0000","objects_1491_0001","objects_1491_0002","objects_1491_0003","","","","",4);
		CreateAnimationUW("456_idle_front","objects_1720_0000","objects_1720_0001","","","","","","",2);
		CreateAnimationUW("456_idle_front_left","objects_1721_0000","objects_1721_0001","","","","","","",2);
		CreateAnimationUW("456_idle_front_right","objects_1719_0000","objects_1719_0001","","","","","","",2);
		CreateAnimationUW("456_idle_left","objects_1714_0000","objects_1714_0001","","","","","","",2);
		CreateAnimationUW("456_idle_rear","objects_1716_0000","objects_1716_0001","","","","","","",2);
		CreateAnimationUW("456_idle_rear_left","objects_1715_0000","objects_1715_0001","","","","","","",2);
		CreateAnimationUW("456_idle_rear_right","objects_1717_0000","objects_1717_0001","","","","","","",2);
		CreateAnimationUW("456_idle_right","objects_1718_0000","objects_1718_0001","","","","","","",2);
		CreateAnimationUW("456_walking_front","objects_2015_0000","objects_2015_0001","","","","","","",2);
		CreateAnimationUW("456_walking_front_left","objects_2014_0000","objects_2014_0001","","","","","","",2);
		CreateAnimationUW("456_walking_front_right","objects_2016_0000","objects_2016_0001","","","","","","",2);
		CreateAnimationUW("456_walking_left","objects_2009_0000","objects_2009_0001","","","","","","",2);
		CreateAnimationUW("456_walking_rear","objects_2011_0000","objects_2011_0001","","","","","","",2);
		CreateAnimationUW("456_walking_rear_left","objects_2010_0000","objects_2010_0001","","","","","","",2);
		CreateAnimationUW("456_walking_rear_right","objects_2012_0000","objects_2012_0001","","","","","","",2);
		CreateAnimationUW("456_walking_right","objects_2013_0000","objects_2013_0001","","","","","","",2);
		CreateAnimationUW("457_Attack1","objects_1418_0000","objects_1418_0001","objects_1418_0002","objects_1418_0003","objects_1418_0004","objects_1418_0005","","",6);
		CreateAnimationUW("457_Attack2","objects_2131_0000","objects_2131_0001","objects_2131_0002","objects_2131_0003","objects_2131_0004","objects_2131_0005","","",6);
		CreateAnimationUW("457_Combat_Idle","objects_1455_0000","objects_1455_0001","objects_1455_0002","objects_1455_0003","objects_1455_0004","objects_1455_0005","objects_1455_0006","",7);
		CreateAnimationUW("457_Death","objects_1492_0000","objects_1492_0001","objects_1492_0002","objects_1492_0003","","","","",4);
		CreateAnimationUW("457_idle_front","objects_1728_0000","objects_1728_0001","objects_1728_0002","objects_1728_0003","","","","",4);
		CreateAnimationUW("457_idle_front_left","objects_1729_0000","objects_1729_0001","objects_1729_0002","objects_1729_0003","","","","",4);
		CreateAnimationUW("457_idle_front_right","objects_1727_0000","objects_1727_0001","objects_1727_0002","objects_1727_0003","","","","",4);
		CreateAnimationUW("457_idle_left","objects_1722_0000","objects_1722_0001","objects_1722_0002","objects_1722_0003","","","","",4);
		CreateAnimationUW("457_idle_rear","objects_1724_0000","objects_1724_0001","objects_1724_0002","objects_1724_0003","","","","",4);
		CreateAnimationUW("457_idle_rear_left","objects_1723_0000","objects_1723_0001","objects_1723_0002","objects_1723_0003","","","","",4);
		CreateAnimationUW("457_idle_rear_right","objects_1725_0000","objects_1725_0001","objects_1725_0002","objects_1725_0003","","","","",4);
		CreateAnimationUW("457_idle_right","objects_1726_0000","objects_1726_0001","objects_1726_0002","objects_1726_0003","","","","",4);
		CreateAnimationUW("457_walking_front","objects_2023_0000","objects_2023_0001","objects_2023_0002","objects_2023_0003","","","","",4);
		CreateAnimationUW("457_walking_front_left","objects_2024_0000","objects_2024_0001","objects_2024_0002","objects_2024_0003","","","","",4);
		CreateAnimationUW("457_walking_front_right","objects_2022_0000","objects_2022_0001","objects_2022_0002","objects_2022_0003","","","","",4);
		CreateAnimationUW("457_walking_left","objects_2017_0000","objects_2017_0001","objects_2017_0002","objects_2017_0003","","","","",4);
		CreateAnimationUW("457_walking_rear","objects_2019_0000","objects_2019_0001","objects_2019_0002","objects_2019_0003","","","","",4);
		CreateAnimationUW("457_walking_rear_left","objects_2018_0000","objects_2018_0001","objects_2018_0002","objects_2018_0003","","","","",4);
		CreateAnimationUW("457_walking_rear_right","objects_2020_0000","objects_2020_0001","objects_2020_0002","objects_2020_0003","","","","",4);
		CreateAnimationUW("457_walking_right","objects_2021_0000","objects_2021_0001","objects_2021_0002","objects_2021_0003","","","","",4);
		CreateAnimationUW("458_Attack1","objects_1419_0000","objects_1419_0001","objects_1419_0002","objects_1419_0003","","","","",4);
		CreateAnimationUW("458_Attack2","objects_2132_0000","objects_2132_0001","objects_2132_0002","objects_2132_0003","","","","",4);
		CreateAnimationUW("458_Combat_Idle","objects_1456_0000","objects_1456_0001","objects_1456_0002","objects_1456_0003","objects_1456_0004","","","",5);
		CreateAnimationUW("458_Death","objects_1493_0000","objects_1493_0001","objects_1493_0002","objects_1493_0003","objects_1493_0004","objects_1493_0005","","",6);
		CreateAnimationUW("458_idle_front","objects_1736_0000","objects_1736_0001","objects_1736_0002","objects_1736_0003","objects_1736_0004","","","",5);
		CreateAnimationUW("458_idle_front_left","objects_1737_0000","objects_1737_0001","objects_1737_0002","objects_1737_0003","objects_1737_0004","","","",5);
		CreateAnimationUW("458_idle_front_right","objects_1735_0000","objects_1735_0001","objects_1735_0002","objects_1735_0003","objects_1735_0004","","","",5);
		CreateAnimationUW("458_idle_left","objects_1730_0000","objects_1730_0001","objects_1730_0002","objects_1730_0003","objects_1730_0004","","","",5);
		CreateAnimationUW("458_idle_rear","objects_1732_0000","objects_1732_0001","objects_1732_0002","objects_1732_0003","objects_1732_0004","","","",5);
		CreateAnimationUW("458_idle_rear_left","objects_1731_0000","objects_1731_0001","objects_1731_0002","objects_1731_0003","objects_1731_0004","","","",5);
		CreateAnimationUW("458_idle_rear_right","objects_1733_0000","objects_1733_0001","objects_1733_0002","objects_1733_0003","objects_1733_0004","","","",5);
		CreateAnimationUW("458_idle_right","objects_1734_0000","objects_1734_0001","objects_1734_0002","objects_1734_0003","objects_1734_0004","","","",5);
		CreateAnimationUW("458_walking_front","objects_2031_0000","objects_2031_0001","objects_2031_0002","objects_2031_0003","objects_2031_0004","","","",5);
		CreateAnimationUW("458_walking_front_left","objects_2032_0000","objects_2032_0001","objects_2032_0002","objects_2032_0003","objects_2032_0004","","","",5);
		CreateAnimationUW("458_walking_front_right","objects_2030_0000","objects_2030_0001","objects_2030_0002","objects_2030_0003","objects_2030_0004","","","",5);
		CreateAnimationUW("458_walking_left","objects_2025_0000","objects_2025_0001","objects_2025_0002","objects_2025_0003","objects_2025_0004","","","",5);
		CreateAnimationUW("458_walking_rear","objects_2027_0000","objects_2027_0001","objects_2027_0002","objects_2027_0003","objects_2027_0004","","","",5);
		CreateAnimationUW("458_walking_rear_left","objects_2026_0000","objects_2026_0001","objects_2026_0002","objects_2026_0003","objects_2026_0004","","","",5);
		CreateAnimationUW("458_walking_rear_right","objects_2028_0000","objects_2028_0001","objects_2028_0002","objects_2028_0003","objects_2028_0004","","","",5);
		CreateAnimationUW("458_walking_right","objects_2029_0000","objects_2029_0001","objects_2029_0002","objects_2029_0003","objects_2029_0004","","","",5);
		CreateAnimationUW("460_Attack1","objects_1421_0000","objects_1421_0001","objects_1421_0002","objects_1421_0003","objects_1421_0004","objects_1421_0005","","",6);
		CreateAnimationUW("460_Attack2","objects_2134_0000","objects_2134_0001","objects_2134_0002","objects_2134_0003","","","","",4);
		CreateAnimationUW("460_Combat_Idle","objects_1458_0000","objects_1458_0001","objects_1458_0002","objects_1458_0003","objects_1458_0004","objects_1458_0005","","",6);
		CreateAnimationUW("460_Death","objects_1495_0000","objects_1495_0001","objects_1495_0002","objects_1495_0003","","","","",4);
		CreateAnimationUW("460_idle_front","objects_1752_0000","objects_1752_0001","objects_1752_0002","objects_1752_0003","","","","",4);
		CreateAnimationUW("460_idle_front_left","objects_1753_0000","objects_1753_0001","objects_1753_0002","objects_1753_0003","","","","",4);
		CreateAnimationUW("460_idle_front_right","objects_1751_0000","objects_1751_0001","objects_1751_0002","objects_1751_0003","","","","",4);
		CreateAnimationUW("460_idle_left","objects_1746_0000","objects_1746_0001","objects_1746_0002","objects_1746_0003","","","","",4);
		CreateAnimationUW("460_idle_rear","objects_1748_0000","objects_1748_0001","objects_1748_0002","objects_1748_0003","","","","",4);
		CreateAnimationUW("460_idle_rear_left","objects_1747_0000","objects_1747_0001","","","","","","",2);
		CreateAnimationUW("460_idle_rear_right","objects_1749_0000","objects_1749_0001","objects_1749_0002","objects_1749_0003","","","","",4);
		CreateAnimationUW("460_idle_right","objects_1750_0000","objects_1750_0001","objects_1750_0002","objects_1750_0003","","","","",4);
		CreateAnimationUW("460_walking_front","objects_2047_0000","objects_2047_0001","objects_2047_0002","objects_2047_0003","objects_2047_0004","objects_2047_0005","objects_2047_0006","",7);
		CreateAnimationUW("460_walking_front_left","objects_2048_0000","objects_2048_0001","objects_2048_0002","objects_2048_0003","objects_2048_0004","objects_2048_0005","objects_2048_0006","",7);
		CreateAnimationUW("460_walking_front_right","objects_2046_0000","objects_2046_0001","objects_2046_0002","objects_2046_0003","objects_2046_0004","objects_2046_0005","objects_2046_0006","",7);
		CreateAnimationUW("460_walking_left","objects_2041_0000","objects_2041_0001","objects_2041_0002","objects_2041_0003","objects_2041_0004","objects_2041_0005","objects_2041_0006","",7);
		CreateAnimationUW("460_walking_rear","objects_2043_0000","objects_2043_0001","objects_2043_0002","objects_2043_0003","objects_2043_0004","objects_2043_0005","objects_2043_0006","",7);
		CreateAnimationUW("460_walking_rear_left","objects_2042_0000","objects_2042_0001","objects_2042_0002","objects_2042_0003","objects_2042_0004","objects_2042_0005","objects_2042_0006","",7);
		CreateAnimationUW("460_walking_rear_right","objects_2044_0000","objects_2044_0001","objects_2044_0002","objects_2044_0003","objects_2044_0004","objects_2044_0005","objects_2044_0006","",7);
		CreateAnimationUW("460_walking_right","objects_2045_0000","objects_2045_0001","objects_2045_0002","objects_2045_0003","objects_2045_0004","objects_2045_0005","objects_2045_0006","",7);
		CreateAnimationUW("461_Attack1","objects_1422_0000","objects_1422_0001","objects_1422_0002","objects_1422_0003","","","","",4);
		CreateAnimationUW("461_Attack2","objects_2135_0000","objects_2135_0001","objects_2135_0002","","","","","",3);
		CreateAnimationUW("461_Combat_Idle","objects_1459_0000","objects_1459_0001","objects_1459_0002","objects_1459_0003","objects_1459_0004","","","",5);
		CreateAnimationUW("461_Death","objects_1496_0000","objects_1496_0001","objects_1496_0002","objects_1496_0003","objects_1496_0004","","","",5);
		CreateAnimationUW("461_idle_front","objects_1760_0000","objects_1760_0001","objects_1760_0002","objects_1760_0003","","","","",4);
		CreateAnimationUW("461_idle_front_left","objects_1761_0000","objects_1761_0001","objects_1761_0002","objects_1761_0003","","","","",4);
		CreateAnimationUW("461_idle_front_right","objects_1759_0000","objects_1759_0001","objects_1759_0002","objects_1759_0003","","","","",4);
		CreateAnimationUW("461_idle_left","objects_1754_0000","objects_1754_0001","objects_1754_0002","objects_1754_0003","","","","",4);
		CreateAnimationUW("461_idle_rear","objects_1756_0000","objects_1756_0001","objects_1756_0002","objects_1756_0003","","","","",4);
		CreateAnimationUW("461_idle_rear_left","objects_1755_0000","objects_1755_0001","objects_1755_0002","objects_1755_0003","","","","",4);
		CreateAnimationUW("461_idle_rear_right","objects_1757_0000","objects_1757_0001","objects_1757_0002","objects_1757_0003","","","","",4);
		CreateAnimationUW("461_idle_right","objects_1758_0000","objects_1758_0001","objects_1758_0002","objects_1758_0003","","","","",4);
		CreateAnimationUW("461_walking_front","objects_2055_0000","objects_2055_0001","objects_2055_0002","objects_2055_0003","objects_2055_0004","objects_2055_0005","objects_2055_0006","objects_2055_0007",8);
		CreateAnimationUW("461_walking_front_left","objects_2056_0000","objects_2056_0001","objects_2056_0002","objects_2056_0003","objects_2056_0004","objects_2056_0005","objects_2056_0006","objects_2056_0007",8);
		CreateAnimationUW("461_walking_front_right","objects_2054_0000","objects_2054_0001","objects_2054_0002","objects_2054_0003","objects_2054_0004","objects_2054_0005","objects_2054_0006","objects_2054_0007",8);
		CreateAnimationUW("461_walking_left","objects_2049_0000","objects_2049_0001","objects_2049_0002","objects_2049_0003","objects_2049_0004","objects_2049_0005","objects_2049_0006","objects_2049_0007",8);
		CreateAnimationUW("461_walking_rear","objects_2051_0000","objects_2051_0001","objects_2051_0002","objects_2051_0003","objects_2051_0004","objects_2051_0005","objects_2051_0006","objects_2051_0007",8);
		CreateAnimationUW("461_walking_rear_left","objects_2050_0000","objects_2050_0001","objects_2050_0002","objects_2050_0003","objects_2050_0004","objects_2050_0005","objects_2050_0006","objects_2050_0007",8);
		CreateAnimationUW("461_walking_rear_right","objects_2052_0000","objects_2052_0001","objects_2052_0002","objects_2052_0003","objects_2052_0004","objects_2052_0005","objects_2052_0006","objects_2052_0007",8);
		CreateAnimationUW("461_walking_right","objects_2053_0000","objects_2053_0001","objects_2053_0002","objects_2053_0003","objects_2053_0004","objects_2053_0005","objects_2053_0006","objects_2053_0007",8);
		CreateAnimationUW("462_Attack1","objects_1423_0000","objects_1423_0001","objects_1423_0002","objects_1423_0003","objects_1423_0004","","","",5);
		CreateAnimationUW("462_Attack2","objects_2136_0000","objects_2136_0001","objects_2136_0002","objects_2136_0003","","","","",4);
		CreateAnimationUW("462_Combat_Idle","objects_1460_0000","objects_1460_0001","objects_1460_0002","objects_1460_0003","","","","",4);
		CreateAnimationUW("462_Death","objects_1497_0000","objects_1497_0001","objects_1497_0002","objects_1497_0003","","","","",4);
		CreateAnimationUW("462_idle_front","objects_1768_0000","objects_1768_0001","objects_1768_0002","objects_1768_0003","","","","",4);
		CreateAnimationUW("462_idle_front_left","objects_1769_0000","objects_1769_0001","objects_1769_0002","objects_1769_0003","","","","",4);
		CreateAnimationUW("462_idle_front_right","objects_1767_0000","objects_1767_0001","objects_1767_0002","objects_1767_0003","","","","",4);
		CreateAnimationUW("462_idle_left","objects_1762_0000","objects_1762_0001","objects_1762_0002","objects_1762_0003","","","","",4);
		CreateAnimationUW("462_idle_rear","objects_1764_0000","objects_1764_0001","objects_1764_0002","objects_1764_0003","","","","",4);
		CreateAnimationUW("462_idle_rear_left","objects_1763_0000","objects_1763_0001","objects_1763_0002","objects_1763_0003","","","","",4);
		CreateAnimationUW("462_idle_rear_right","objects_1765_0000","objects_1765_0001","objects_1765_0002","objects_1765_0003","","","","",4);
		CreateAnimationUW("462_idle_right","objects_1766_0000","objects_1766_0001","objects_1766_0002","objects_1766_0003","","","","",4);
		CreateAnimationUW("462_walking_front","objects_2063_0000","objects_2063_0001","objects_2063_0002","objects_2063_0003","objects_2063_0004","objects_2063_0005","objects_2063_0006","objects_2063_0007",8);
		CreateAnimationUW("462_walking_front_left","objects_2064_0000","objects_2064_0001","objects_2064_0002","objects_2064_0003","objects_2064_0004","objects_2064_0005","objects_2064_0006","objects_2064_0007",8);
		CreateAnimationUW("462_walking_front_right","objects_2062_0000","objects_2062_0001","objects_2062_0002","objects_2062_0003","objects_2062_0004","objects_2062_0005","objects_2062_0006","objects_2062_0007",8);
		CreateAnimationUW("462_walking_left","objects_2057_0000","objects_2057_0001","objects_2057_0002","objects_2057_0003","objects_2057_0004","objects_2057_0005","objects_2057_0006","objects_2057_0007",8);
		CreateAnimationUW("462_walking_rear","objects_2059_0000","objects_2059_0001","objects_2059_0002","objects_2059_0003","objects_2059_0004","objects_2059_0005","objects_2059_0006","objects_2059_0007",8);
		CreateAnimationUW("462_walking_rear_left","objects_2058_0000","objects_2058_0001","objects_2058_0002","objects_2058_0003","objects_2058_0004","objects_2058_0005","objects_2058_0006","objects_2058_0007",8);
		CreateAnimationUW("462_walking_rear_right","objects_2060_0000","objects_2060_0001","objects_2060_0002","objects_2060_0003","objects_2060_0004","objects_2060_0005","objects_2060_0006","objects_2060_0007",8);
		CreateAnimationUW("462_walking_right","objects_2061_0000","objects_2061_0001","objects_2061_0002","objects_2061_0003","objects_2061_0004","objects_2061_0005","objects_2061_0006","objects_2061_0007",8);
		CreateAnimationUW("463_Attack1","objects_1424_0000","objects_1424_0001","","","","","","",2);
		CreateAnimationUW("463_Attack2","objects_2137_0000","objects_2137_0001","objects_2137_0002","objects_2137_0003","objects_2137_0004","objects_2137_0005","","",6);
		CreateAnimationUW("463_Combat_Idle","objects_1461_0000","objects_1461_0001","objects_1461_0002","objects_1461_0003","","","","",4);
		CreateAnimationUW("463_Death","objects_1498_0000","objects_1498_0001","objects_1498_0002","objects_1498_0003","","","","",4);
		CreateAnimationUW("463_idle_front","objects_1776_0000","objects_1776_0001","objects_1776_0002","objects_1776_0003","","","","",4);
		CreateAnimationUW("463_idle_front_left","objects_1777_0000","objects_1777_0001","objects_1777_0002","objects_1777_0003","","","","",4);
		CreateAnimationUW("463_idle_front_right","objects_1775_0000","objects_1775_0001","objects_1775_0002","objects_1775_0003","","","","",4);
		CreateAnimationUW("463_idle_left","objects_1770_0000","objects_1770_0001","objects_1770_0002","objects_1770_0003","","","","",4);
		CreateAnimationUW("463_idle_rear","objects_1772_0000","objects_1772_0001","objects_1772_0002","objects_1772_0003","","","","",4);
		CreateAnimationUW("463_idle_rear_left","objects_1771_0000","objects_1771_0001","objects_1771_0002","objects_1771_0003","","","","",4);
		CreateAnimationUW("463_idle_rear_right","objects_1773_0000","objects_1773_0001","objects_1773_0002","objects_1773_0003","","","","",4);
		CreateAnimationUW("463_idle_right","objects_1774_0000","objects_1774_0001","objects_1774_0002","objects_1774_0003","","","","",4);
		CreateAnimationUW("463_walking_front","objects_2071_0000","objects_2071_0001","objects_2071_0002","objects_2071_0003","objects_2071_0004","objects_2071_0005","objects_2071_0006","objects_2071_0007",8);
		CreateAnimationUW("463_walking_front_left","objects_2072_0000","objects_2072_0001","objects_2072_0002","objects_2072_0003","objects_2072_0004","objects_2072_0005","objects_2072_0006","objects_2072_0007",8);
		CreateAnimationUW("463_walking_front_right","objects_2070_0000","objects_2070_0001","objects_2070_0002","objects_2070_0003","objects_2070_0004","objects_2070_0005","objects_2070_0006","objects_2070_0007",8);
		CreateAnimationUW("463_walking_left","objects_2065_0000","objects_2065_0001","objects_2065_0002","objects_2065_0003","objects_2065_0004","objects_2065_0005","objects_2065_0006","objects_2065_0007",8);
		CreateAnimationUW("463_walking_rear","objects_2067_0000","objects_2067_0001","objects_2067_0002","objects_2067_0003","objects_2067_0004","objects_2067_0005","objects_2067_0006","objects_2067_0007",8);
		CreateAnimationUW("463_walking_rear_left","objects_2066_0000","objects_2066_0001","objects_2066_0002","objects_2066_0003","objects_2066_0004","objects_2066_0005","objects_2066_0006","objects_2066_0007",8);
		CreateAnimationUW("463_walking_rear_right","objects_2068_0000","objects_2068_0001","objects_2068_0002","objects_2068_0003","objects_2068_0004","objects_2068_0005","objects_2068_0006","objects_2068_0007",8);
		CreateAnimationUW("463_walking_right","objects_2069_0000","objects_2069_0001","objects_2069_0002","objects_2069_0003","objects_2069_0004","objects_2069_0005","objects_2069_0006","objects_2069_0007",8);
		CreateAnimationUW("464_Attack1","objects_1425_0000","objects_1425_0001","objects_1425_0002","objects_1425_0003","objects_1425_0004","","","",5);
		CreateAnimationUW("464_Attack2","objects_2138_0000","objects_2138_0001","objects_2138_0002","","","","","",3);
		CreateAnimationUW("464_Combat_Idle","objects_1462_0000","objects_1462_0001","objects_1462_0002","objects_1462_0003","","","","",4);
		CreateAnimationUW("464_Death","objects_1499_0000","objects_1499_0001","objects_1499_0002","objects_1499_0003","objects_1499_0004","","","",5);
		CreateAnimationUW("464_idle_front","objects_1784_0000","objects_1784_0001","objects_1784_0002","objects_1784_0003","","","","",4);
		CreateAnimationUW("464_idle_front_left","objects_1785_0000","objects_1785_0001","objects_1785_0002","objects_1785_0003","","","","",4);
		CreateAnimationUW("464_idle_front_right","objects_1783_0000","objects_1783_0001","objects_1783_0002","objects_1783_0003","","","","",4);
		CreateAnimationUW("464_idle_left","objects_1778_0000","objects_1778_0001","objects_1778_0002","objects_1778_0003","","","","",4);
		CreateAnimationUW("464_idle_rear","objects_1780_0000","objects_1780_0001","objects_1780_0002","objects_1780_0003","","","","",4);
		CreateAnimationUW("464_idle_rear_left","objects_1779_0000","objects_1779_0001","objects_1779_0002","objects_1779_0003","","","","",4);
		CreateAnimationUW("464_idle_rear_right","objects_1781_0000","objects_1781_0001","objects_1781_0002","objects_1781_0003","","","","",4);
		CreateAnimationUW("464_idle_right","objects_1782_0000","objects_1782_0001","objects_1782_0002","objects_1782_0003","","","","",4);
		CreateAnimationUW("464_walking_front","objects_2079_0000","objects_2079_0001","objects_2079_0002","objects_2079_0003","objects_2079_0004","objects_2079_0005","objects_2079_0006","objects_2079_0007",8);
		CreateAnimationUW("464_walking_front_left","objects_2080_0000","objects_2080_0001","objects_2080_0002","objects_2080_0003","objects_2080_0004","objects_2080_0005","objects_2080_0006","objects_2080_0007",8);
		CreateAnimationUW("464_walking_front_right","objects_2078_0000","objects_2078_0001","objects_2078_0002","objects_2078_0003","objects_2078_0004","objects_2078_0005","objects_2078_0006","objects_2078_0007",8);
		CreateAnimationUW("464_walking_left","objects_2073_0000","objects_2073_0001","objects_2073_0002","objects_2073_0003","objects_2073_0004","objects_2073_0005","objects_2073_0006","objects_2073_0007",8);
		CreateAnimationUW("464_walking_rear","objects_2075_0000","objects_2075_0001","objects_2075_0002","objects_2075_0003","objects_2075_0004","objects_2075_0005","objects_2075_0006","objects_2075_0007",8);
		CreateAnimationUW("464_walking_rear_left","objects_2074_0000","objects_2074_0001","objects_2074_0002","objects_2074_0003","objects_2074_0004","objects_2074_0005","objects_2074_0006","objects_2074_0007",8);
		CreateAnimationUW("464_walking_rear_right","objects_2076_0000","objects_2076_0001","objects_2076_0002","objects_2076_0003","objects_2076_0004","objects_2076_0005","objects_2076_0006","objects_2076_0007",8);
		CreateAnimationUW("464_walking_right","objects_2077_0000","objects_2077_0001","objects_2077_0002","objects_2077_0003","objects_2077_0004","objects_2077_0005","objects_2077_0006","objects_2077_0007",8);
		CreateAnimationUW("465_Attack1","objects_1426_0000","objects_1426_0001","objects_1426_0002","","","","","",3);
		CreateAnimationUW("465_Attack2","objects_2139_0000","objects_2139_0001","objects_2139_0002","","","","","",3);
		CreateAnimationUW("465_Combat_Idle","objects_1463_0000","objects_1463_0001","objects_1463_0002","","","","","",3);
		CreateAnimationUW("465_Death","objects_1500_0000","objects_1500_0001","objects_1500_0002","objects_1500_0003","objects_1500_0004","","","",5);
		CreateAnimationUW("465_idle_front","objects_1792_0000","","","","","","","",1);
		CreateAnimationUW("465_idle_front_left","objects_1793_0000","","","","","","","",1);
		CreateAnimationUW("465_idle_front_right","objects_1791_0000","","","","","","","",1);
		CreateAnimationUW("465_idle_left","objects_1786_0000","","","","","","","",1);
		CreateAnimationUW("465_idle_rear","objects_1788_0000","","","","","","","",1);
		CreateAnimationUW("465_idle_rear_left","objects_1787_0000","","","","","","","",1);
		CreateAnimationUW("465_idle_rear_right","objects_1789_0000","","","","","","","",1);
		CreateAnimationUW("465_idle_right","objects_1790_0000","","","","","","","",1);
		CreateAnimationUW("465_walking_front","objects_2087_0000","objects_2087_0001","objects_2087_0002","objects_2087_0003","","","","",4);
		CreateAnimationUW("465_walking_front_left","objects_2088_0000","objects_2088_0001","objects_2088_0002","objects_2088_0003","","","","",4);
		CreateAnimationUW("465_walking_front_right","objects_2086_0000","objects_2086_0001","objects_2086_0002","objects_2086_0003","","","","",4);
		CreateAnimationUW("465_walking_left","objects_2081_0000","objects_2081_0001","objects_2081_0002","objects_2081_0003","","","","",4);
		CreateAnimationUW("465_walking_rear","objects_2083_0000","objects_2083_0001","objects_2083_0002","objects_2083_0003","","","","",4);
		CreateAnimationUW("465_walking_rear_left","objects_2082_0000","objects_2082_0001","objects_2082_0002","objects_2082_0003","","","","",4);
		CreateAnimationUW("465_walking_rear_right","objects_2084_0000","objects_2084_0001","objects_2084_0002","objects_2084_0003","","","","",4);
		CreateAnimationUW("465_walking_right","objects_2085_0000","objects_2085_0001","objects_2085_0002","objects_2085_0003","","","","",4);
		CreateAnimationUW("466_Attack1","objects_1427_0000","objects_1427_0001","objects_1427_0002","objects_1427_0003","","","","",4);
		CreateAnimationUW("466_Attack2","objects_2140_0000","objects_2140_0001","objects_2140_0002","","","","","",3);
		CreateAnimationUW("466_Combat_Idle","objects_1464_0000","objects_1464_0001","objects_1464_0002","objects_1464_0003","","","","",4);
		CreateAnimationUW("466_Death","objects_1501_0000","objects_1501_0001","objects_1501_0002","objects_1501_0003","","","","",4);
		CreateAnimationUW("466_idle_front","objects_1800_0000","objects_1800_0001","objects_1800_0002","objects_1800_0003","","","","",4);
		CreateAnimationUW("466_idle_front_left","objects_1801_0000","objects_1801_0001","objects_1801_0002","objects_1801_0003","","","","",4);
		CreateAnimationUW("466_idle_front_right","objects_1799_0000","objects_1799_0001","objects_1799_0002","objects_1799_0003","","","","",4);
		CreateAnimationUW("466_idle_left","objects_1794_0000","objects_1794_0001","objects_1794_0002","objects_1794_0003","","","","",4);
		CreateAnimationUW("466_idle_rear","objects_1796_0000","objects_1796_0001","objects_1796_0002","objects_1796_0003","","","","",4);
		CreateAnimationUW("466_idle_rear_left","objects_1795_0000","objects_1795_0001","objects_1795_0002","objects_1795_0003","","","","",4);
		CreateAnimationUW("466_idle_rear_right","objects_1797_0000","objects_1797_0001","objects_1797_0002","objects_1797_0003","","","","",4);
		CreateAnimationUW("466_idle_right","objects_1798_0000","objects_1798_0001","objects_1798_0002","objects_1798_0003","","","","",4);
		CreateAnimationUW("466_walking_front","objects_2095_0000","objects_2095_0001","objects_2095_0002","objects_2095_0003","objects_2095_0004","objects_2095_0005","objects_2095_0006","objects_2095_0007",8);
		CreateAnimationUW("466_walking_front_left","objects_2096_0000","objects_2096_0001","objects_2096_0002","objects_2096_0003","objects_2096_0004","objects_2096_0005","objects_2096_0006","objects_2096_0007",8);
		CreateAnimationUW("466_walking_front_right","objects_2094_0000","objects_2094_0001","objects_2094_0002","objects_2094_0003","objects_2094_0004","objects_2094_0005","objects_2094_0006","objects_2094_0007",8);
		CreateAnimationUW("466_walking_left","objects_2089_0000","objects_2089_0001","objects_2089_0002","objects_2089_0003","objects_2089_0004","objects_2089_0005","objects_2089_0006","objects_2089_0007",8);
		CreateAnimationUW("466_walking_rear","objects_2091_0000","objects_2091_0001","objects_2091_0002","objects_2091_0003","objects_2091_0004","objects_2091_0005","objects_2091_0006","objects_2091_0007",8);
		CreateAnimationUW("466_walking_rear_left","objects_2090_0000","objects_2090_0001","objects_2090_0002","objects_2090_0003","objects_2090_0004","objects_2090_0005","objects_2090_0006","objects_2090_0007",8);
		CreateAnimationUW("466_walking_rear_right","objects_2092_0000","objects_2092_0001","objects_2092_0002","objects_2092_0003","objects_2092_0004","objects_2092_0005","objects_2092_0006","objects_2092_0007",8);
		CreateAnimationUW("466_walking_right","objects_2093_0000","objects_2093_0001","objects_2093_0002","objects_2093_0003","objects_2093_0004","objects_2093_0005","objects_2093_0006","objects_2093_0007",8);
		CreateAnimationUW("475_Attack1","objects_1436_0000","objects_1436_0001","objects_1436_0002","objects_1436_0003","objects_1436_0004","objects_1436_0005","objects_1436_0006","",7);
		CreateAnimationUW("475_Attack2","objects_2149_0000","objects_2149_0001","objects_2149_0002","objects_2149_0003","objects_2149_0004","objects_2149_0005","objects_2149_0006","objects_2149_0007",8);
		CreateAnimationUW("475_Combat_Idle","objects_1473_0000","objects_1473_0001","objects_1473_0002","objects_1473_0003","objects_1473_0004","objects_1473_0005","objects_1473_0006","objects_1473_0007",8);
		CreateAnimationUW("475_Death","objects_1510_0000","objects_1510_0001","objects_1510_0002","objects_1510_0003","objects_1510_0004","objects_1510_0005","objects_1510_0006","objects_1510_0007",8);
		CreateAnimationUW("475_idle_front","objects_1816_0000","","","","","","","",1);
		CreateAnimationUW("475_idle_front_left","objects_1817_0000","","","","","","","",1);
		CreateAnimationUW("475_idle_front_right","objects_1815_0000","","","","","","","",1);
		CreateAnimationUW("475_idle_left","objects_1810_0000","","","","","","","",1);
		CreateAnimationUW("475_idle_rear","objects_1812_0000","","","","","","","",1);
		CreateAnimationUW("475_idle_rear_left","objects_1811_0000","","","","","","","",1);
		CreateAnimationUW("475_idle_rear_right","objects_1813_0000","","","","","","","",1);
		CreateAnimationUW("475_idle_right","objects_1814_0000","","","","","","","",1);
		CreateAnimationUW("475_walking_front","objects_2111_0000","objects_2111_0001","objects_2111_0002","objects_2111_0003","objects_2111_0004","objects_2111_0005","objects_2111_0006","objects_2111_0007",8);
		CreateAnimationUW("475_walking_front_left","objects_2112_0000","objects_2112_0001","objects_2112_0002","objects_2112_0003","objects_2112_0004","objects_2112_0005","objects_2112_0006","objects_2112_0007",8);
		CreateAnimationUW("475_walking_front_right","objects_2110_0000","objects_2110_0001","objects_2110_0002","objects_2110_0003","objects_2110_0004","objects_2110_0005","objects_2110_0006","objects_2110_0007",8);
		CreateAnimationUW("475_walking_left","objects_2105_0000","objects_2105_0001","objects_2105_0002","objects_2105_0003","objects_2105_0004","objects_2105_0005","objects_2105_0006","objects_2105_0007",8);
		CreateAnimationUW("475_walking_rear","objects_2107_0000","objects_2107_0001","objects_2107_0002","objects_2107_0003","objects_2107_0004","objects_2107_0005","objects_2107_0006","objects_2107_0007",8);
		CreateAnimationUW("475_walking_rear_left","objects_2106_0000","objects_2106_0001","objects_2106_0002","objects_2106_0003","objects_2106_0004","objects_2106_0005","objects_2106_0006","objects_2106_0007",8);
		CreateAnimationUW("475_walking_rear_right","objects_2108_0000","objects_2108_0001","objects_2108_0002","objects_2108_0003","objects_2108_0004","objects_2108_0005","objects_2108_0006","objects_2108_0007",8);
		CreateAnimationUW("475_walking_right","objects_2109_0000","objects_2109_0001","objects_2109_0002","objects_2109_0003","objects_2109_0004","objects_2109_0005","objects_2109_0006","objects_2109_0007",8);

*/



		}


	[MenuItem("MyTools/TagTilesByName")]
	static void TagTilesByRoom()
	{
				SetTileTag(10,60,"SOLIDWALL",1);SetTileTag(23,60,"SOLIDWALL",1);


				SetTileTag(9,57,"SOLIDWALL",1);SetTileTag(10,57,"LAVA_1", 1);SetTileTag(11,57,"LAVA_1", 1);SetTileTag(12,57,"LAVA_1", 1);SetTileTag(13,57,"LAVA_1", 1);SetTileTag(14,57,"LAVA_1", 1);SetTileTag(15,57,"LAVA_1", 1);SetTileTag(16,57,"LAVA_1", 1);SetTileTag(17,57,"LAVA_1", 1);SetTileTag(18,57,"LAVA_1", 1);SetTileTag(19,57,"LAVA_1", 1);SetTileTag(20,57,"SOLIDWALL",1);SetTileTag(22,57,"SOLIDWALL",1);SetTileTag(23,57,"WATER_1", 1);SetTileTag(24,57,"WATER_1", 1);SetTileTag(25,57,"WATER_1", 1);SetTileTag(26,57,"WATER_1", 1);SetTileTag(27,57,"WATER_1", 1);SetTileTag(28,57,"WATER_1", 1);SetTileTag(29,57,"WATER_1", 1);SetTileTag(30,57,"WATER_1", 1);SetTileTag(31,57,"WATER_1", 1);SetTileTag(32,57,"WATER_1", 1);SetTileTag(33,57,"SOLIDWALL",1);
				SetTileTag(10,56,"SOLIDWALL",1);SetTileTag(23,56,"SOLIDWALL",1);

				SetTileTag(3,54,"SOLIDWALL",1);SetTileTag(14,54,"SOLIDWALL",1);SetTileTag(50,54,"SOLIDWALL",1);
				SetTileTag(8,53,"LAND_1", 1);SetTileTag(15,53,"LAND_1", 1);SetTileTag(22,53,"SOLIDWALL",1);SetTileTag(51,53,"LAND_1", 1);SetTileTag(55,53,"SOLIDWALL",1);
				SetTileTag(4,52,"LAND_1", 1);SetTileTag(5,52,"LAND_1", 1);SetTileTag(6,52,"LAND_1", 1);SetTileTag(7,52,"LAND_1", 1);SetTileTag(14,52,"LAND_1", 1);SetTileTag(15,52,"LAND_1", 1);
				SetTileTag(5,51,"LAND_1", 1);SetTileTag(14,51,"LAND_1", 1);SetTileTag(15,51,"LAND_1", 1);SetTileTag(16,51,"LAND_1", 1);SetTileTag(17,51,"LAND_1", 1);SetTileTag(22,51,"LAND_1", 1);SetTileTag(23,51,"LAND_1", 1);
				SetTileTag(6,50,"LAND_1", 1);SetTileTag(8,50,"LAND_1", 1);SetTileTag(9,50,"LAND_1", 1);SetTileTag(10,50,"LAND_1", 1);SetTileTag(14,50,"LAND_1", 1);SetTileTag(15,50,"LAND_1", 1);SetTileTag(16,50,"LAND_1", 1);SetTileTag(21,50,"LAND_1", 1);SetTileTag(22,50,"LAND_1", 1);SetTileTag(50,50,"LAND_1", 1);SetTileTag(51,50,"LAND_1", 1);SetTileTag(52,50,"LAND_1", 1);SetTileTag(53,50,"LAND_1", 1);SetTileTag(54,50,"LAND_1", 1);
				SetTileTag(8,49,"LAND_1", 1);SetTileTag(11,49,"LAND_1", 1);SetTileTag(20,49,"LAND_1", 1);SetTileTag(21,49,"LAND_1", 1);SetTileTag(51,49,"LAND_1", 1);SetTileTag(52,49,"LAND_1", 1);SetTileTag(53,49,"LAND_1", 1);
				SetTileTag(3,48,"LAND_1", 1);SetTileTag(4,48,"LAND_1", 1);SetTileTag(5,48,"LAND_1", 1);SetTileTag(8,48,"SOLIDWALL",1);SetTileTag(12,48,"SOLIDWALL",1);SetTileTag(13,48,"SOLIDWALL",1);SetTileTag(19,48,"LAND_1", 1);SetTileTag(20,48,"LAND_1", 1);SetTileTag(51,48,"LAND_1", 1);SetTileTag(52,48,"LAND_1", 1);SetTileTag(53,48,"LAND_1", 1);
				SetTileTag(3,47,"LAND_1", 1);SetTileTag(4,47,"LAND_1", 1);SetTileTag(5,47,"LAND_1", 1);SetTileTag(14,47,"LAND_1", 1);SetTileTag(15,47,"LAND_1", 1);SetTileTag(16,47,"LAND_1", 1);SetTileTag(21,47,"LAND_1", 1);SetTileTag(22,47,"LAND_1", 1);SetTileTag(23,47,"LAND_1", 1);SetTileTag(51,47,"LAND_1", 1);SetTileTag(52,47,"LAND_1", 1);SetTileTag(53,47,"LAND_1", 1);
				SetTileTag(3,46,"LAND_1", 1);SetTileTag(4,46,"LAND_1", 1);SetTileTag(5,46,"LAND_1", 1);SetTileTag(14,46,"LAND_1", 1);SetTileTag(15,46,"LAND_1", 1);SetTileTag(16,46,"LAND_1", 1);SetTileTag(21,46,"LAND_1", 1);SetTileTag(22,46,"LAND_1", 1);SetTileTag(23,46,"LAND_1", 1);SetTileTag(51,46,"LAND_1", 1);SetTileTag(52,46,"LAND_1", 1);SetTileTag(53,46,"LAND_1", 1);
				SetTileTag(3,45,"LAND_1", 1);SetTileTag(4,45,"LAND_1", 1);SetTileTag(5,45,"LAND_1", 1);SetTileTag(14,45,"LAND_1", 1);SetTileTag(15,45,"LAND_1", 1);SetTileTag(16,45,"LAND_1", 1);SetTileTag(21,45,"LAND_1", 1);SetTileTag(22,45,"LAND_1", 1);SetTileTag(23,45,"LAND_1", 1);SetTileTag(51,45,"LAND_1", 1);SetTileTag(52,45,"LAND_1", 1);SetTileTag(53,45,"LAND_1", 1);
				SetTileTag(3,44,"LAND_1", 1);SetTileTag(4,44,"LAND_1", 1);SetTileTag(5,44,"LAND_1", 1);SetTileTag(14,44,"LAND_1", 1);SetTileTag(15,44,"LAND_1", 1);SetTileTag(16,44,"LAND_1", 1);SetTileTag(21,44,"LAND_1", 1);SetTileTag(22,44,"LAND_1", 1);SetTileTag(23,44,"LAND_1", 1);SetTileTag(24,44,"LAND_1", 1);SetTileTag(25,44,"LAND_1", 1);SetTileTag(26,44,"LAND_1", 1);SetTileTag(27,44,"LAND_1", 1);SetTileTag(51,44,"LAND_1", 1);SetTileTag(52,44,"LAND_1", 1);SetTileTag(53,44,"LAND_1", 1);
				SetTileTag(3,43,"LAND_1", 1);SetTileTag(4,43,"LAND_1", 1);SetTileTag(5,43,"LAND_1", 1);SetTileTag(6,43,"LAND_1", 1);SetTileTag(7,43,"LAND_1", 1);SetTileTag(8,43,"LAND_1", 1);SetTileTag(9,43,"LAND_1", 1);SetTileTag(10,43,"LAND_1", 1);SetTileTag(11,43,"LAND_1", 1);SetTileTag(12,43,"LAND_1", 1);SetTileTag(14,43,"LAND_1", 1);SetTileTag(15,43,"LAND_1", 1);SetTileTag(16,43,"LAND_1", 1);SetTileTag(17,43,"LAND_1", 1);SetTileTag(18,43,"LAND_1", 1);SetTileTag(21,43,"LAND_1", 1);SetTileTag(22,43,"LAND_1", 1);SetTileTag(23,43,"LAND_1", 1);SetTileTag(24,43,"LAND_1", 1);SetTileTag(51,43,"LAND_1", 1);SetTileTag(52,43,"LAND_1", 1);SetTileTag(53,43,"LAND_1", 1);
				SetTileTag(3,42,"LAND_1", 1);SetTileTag(4,42,"LAND_1", 1);SetTileTag(5,42,"LAND_1", 1);SetTileTag(6,42,"LAND_1", 1);SetTileTag(7,42,"LAND_1", 1);SetTileTag(8,42,"LAND_1", 1);SetTileTag(9,42,"LAND_1", 1);SetTileTag(16,42,"LAND_1", 1);SetTileTag(22,42,"LAND_1", 1);SetTileTag(51,42,"LAND_1", 1);SetTileTag(52,42,"LAND_1", 1);SetTileTag(53,42,"LAND_1", 1);
				SetTileTag(4,41,"LAND_1", 1);SetTileTag(6,41,"LAND_1", 1);SetTileTag(7,41,"LAND_1", 1);SetTileTag(8,41,"LAND_1", 1);SetTileTag(9,41,"LAND_1", 1);SetTileTag(15,41,"LAND_1", 1);SetTileTag(16,41,"LAND_1", 1);SetTileTag(21,41,"LAND_1", 1);SetTileTag(22,41,"LAND_1", 1);SetTileTag(51,41,"LAND_1", 1);SetTileTag(52,41,"LAND_1", 1);SetTileTag(53,41,"LAND_1", 1);SetTileTag(57,41,"LAND_1", 1);
				SetTileTag(3,40,"LAND_1", 1);SetTileTag(4,40,"LAND_1", 1);SetTileTag(6,40,"LAND_1", 1);SetTileTag(7,40,"LAND_1", 1);SetTileTag(8,40,"LAND_1", 1);SetTileTag(9,40,"LAND_1", 1);SetTileTag(14,40,"LAND_1", 1);SetTileTag(15,40,"LAND_1", 1);SetTileTag(25,40,"LAND_1", 1);SetTileTag(26,40,"LAND_1", 1);SetTileTag(27,40,"LAND_1", 1);SetTileTag(51,40,"LAND_1", 1);SetTileTag(52,40,"LAND_1", 1);SetTileTag(53,40,"LAND_1", 1);SetTileTag(57,40,"LAND_1", 1);
				SetTileTag(13,39,"LAND_1", 1);SetTileTag(14,39,"LAND_1", 1);SetTileTag(22,39,"LAND_1", 1);SetTileTag(23,39,"LAND_1", 1);SetTileTag(24,39,"LAND_1", 1);SetTileTag(25,39,"LAND_1", 1);SetTileTag(26,39,"LAND_1", 1);SetTileTag(27,39,"LAND_1", 1);SetTileTag(51,39,"LAND_1", 1);SetTileTag(52,39,"LAND_1", 1);SetTileTag(53,39,"LAND_1", 1);SetTileTag(54,39,"LAND_1", 1);SetTileTag(55,39,"LAND_1", 1);SetTileTag(56,39,"LAND_1", 1);SetTileTag(57,39,"LAND_1", 1);SetTileTag(58,39,"LAND_1", 1);
				SetTileTag(12,38,"LAND_1", 1);SetTileTag(13,38,"LAND_1", 1);SetTileTag(14,38,"LAND_1", 1);SetTileTag(15,38,"LAND_1", 1);SetTileTag(16,38,"LAND_1", 1);SetTileTag(23,38,"LAND_1", 1);SetTileTag(25,38,"LAND_1", 1);SetTileTag(26,38,"LAND_1", 1);SetTileTag(27,38,"LAND_1", 1);SetTileTag(51,38,"LAND_1", 1);SetTileTag(52,38,"LAND_1", 1);SetTileTag(53,38,"LAND_1", 1);SetTileTag(54,38,"LAND_1", 1);SetTileTag(55,38,"LAND_1", 1);
				SetTileTag(11,37,"LAND_1", 1);SetTileTag(12,37,"LAND_1", 1);SetTileTag(14,37,"LAND_1", 1);SetTileTag(15,37,"LAND_1", 1);SetTileTag(16,37,"LAND_1", 1);SetTileTag(17,37,"LAND_1", 1);SetTileTag(24,37,"LAND_1", 1);SetTileTag(41,37,"LAND_1", 1);SetTileTag(42,37,"LAND_1", 1);SetTileTag(43,37,"LAND_1", 1);SetTileTag(44,37,"LAND_1", 1);SetTileTag(45,37,"LAND_1", 1);SetTileTag(46,37,"LAND_1", 1);SetTileTag(47,37,"LAND_1", 1);SetTileTag(48,37,"LAND_1", 1);SetTileTag(52,37,"LAND_1", 1);SetTileTag(54,37,"LAND_1", 1);SetTileTag(55,37,"LAND_1", 1);
				SetTileTag(10,36,"LAND_1", 1);SetTileTag(11,36,"LAND_1", 1);SetTileTag(14,36,"LAND_1", 1);SetTileTag(15,36,"LAND_1", 1);SetTileTag(16,36,"LAND_1", 1);SetTileTag(17,36,"LAND_1", 1);SetTileTag(18,36,"LAND_1", 1);SetTileTag(25,36,"LAND_1", 1);SetTileTag(27,36,"LAND_1", 1);SetTileTag(42,36,"LAND_1", 1);SetTileTag(51,36,"LAND_1", 1);SetTileTag(52,36,"LAND_1", 1);SetTileTag(54,36,"LAND_1", 1);SetTileTag(55,36,"LAND_1", 1);
				SetTileTag(14,35,"LAND_1", 1);SetTileTag(19,35,"LAND_1", 1);SetTileTag(20,35,"LAND_1", 1);SetTileTag(22,35,"LAND_1", 1);SetTileTag(23,35,"LAND_1", 1);SetTileTag(24,35,"LAND_1", 1);SetTileTag(41,35,"LAND_1", 1);SetTileTag(42,35,"LAND_1", 1);SetTileTag(52,35,"LAND_1", 1);
				SetTileTag(15,34,"LAND_1", 1);SetTileTag(22,34,"LAND_1", 1);SetTileTag(23,34,"LAND_1", 1);SetTileTag(24,34,"LAND_1", 1);SetTileTag(41,34,"LAND_1", 1);SetTileTag(42,34,"LAND_1", 1);SetTileTag(43,34,"LAND_1", 1);SetTileTag(44,34,"LAND_1", 1);SetTileTag(49,34,"LAND_1", 1);SetTileTag(50,34,"LAND_1", 1);SetTileTag(53,34,"LAND_1", 1);SetTileTag(54,34,"LAND_1", 1);SetTileTag(55,34,"LAND_1", 1);SetTileTag(56,34,"LAND_1", 1);
				SetTileTag(12,33,"LAND_1", 1);SetTileTag(13,33,"LAND_1", 1);SetTileTag(14,33,"LAND_1", 1);SetTileTag(16,33,"LAND_1", 1);SetTileTag(22,33,"LAND_1", 1);SetTileTag(23,33,"LAND_1", 1);SetTileTag(24,33,"LAND_1", 1);SetTileTag(41,33,"LAND_1", 1);SetTileTag(42,33,"LAND_1", 1);SetTileTag(43,33,"LAND_1", 1);SetTileTag(48,33,"LAND_1", 1);SetTileTag(49,33,"LAND_1", 1);SetTileTag(51,33,"LAND_1", 1);SetTileTag(54,33,"LAND_1", 1);SetTileTag(55,33,"LAND_1", 1);SetTileTag(56,33,"LAND_1", 1);SetTileTag(57,33,"LAND_1", 1);
				SetTileTag(13,32,"LAND_1", 1);SetTileTag(15,32,"LAND_1", 1);SetTileTag(22,32,"LAND_1", 1);SetTileTag(23,32,"LAND_1", 1);SetTileTag(24,32,"LAND_1", 1);SetTileTag(46,32,"LAND_1", 1);SetTileTag(47,32,"LAND_1", 1);SetTileTag(48,32,"LAND_1", 1);SetTileTag(51,32,"LAND_1", 1);SetTileTag(54,32,"LAND_1", 1);SetTileTag(55,32,"LAND_1", 1);SetTileTag(56,32,"LAND_1", 1);SetTileTag(57,32,"LAND_1", 1);SetTileTag(58,32,"LAND_1", 1);SetTileTag(59,32,"LAND_1", 1);SetTileTag(60,32,"LAND_1", 1);
				SetTileTag(14,31,"LAND_1", 1);SetTileTag(16,31,"LAND_1", 1);SetTileTag(21,31,"LAND_1", 1);SetTileTag(22,31,"LAND_1", 1);SetTileTag(23,31,"LAND_1", 1);SetTileTag(24,31,"LAND_1", 1);SetTileTag(47,31,"LAND_1", 1);SetTileTag(57,31,"LAND_1", 1);
				SetTileTag(15,30,"LAND_1", 1);SetTileTag(16,30,"LAND_1", 1);SetTileTag(17,30,"LAND_1", 1);SetTileTag(20,30,"LAND_1", 1);SetTileTag(21,30,"LAND_1", 1);SetTileTag(27,30,"LAND_1", 1);SetTileTag(28,30,"LAND_1", 1);SetTileTag(29,30,"LAND_1", 1);SetTileTag(30,30,"LAND_1", 1);SetTileTag(31,30,"LAND_1", 1);SetTileTag(41,30,"LAND_1", 1);SetTileTag(42,30,"LAND_1", 1);SetTileTag(43,30,"LAND_1", 1);SetTileTag(48,30,"LAND_1", 1);SetTileTag(49,30,"LAND_1", 1);SetTileTag(50,30,"LAND_1", 1);SetTileTag(58,30,"LAND_1", 1);
				SetTileTag(14,29,"LAND_1", 1);SetTileTag(15,29,"LAND_1", 1);SetTileTag(16,29,"LAND_1", 1);SetTileTag(19,29,"LAND_1", 1);SetTileTag(20,29,"LAND_1", 1);SetTileTag(23,29,"LAND_1", 1);SetTileTag(25,29,"LAND_1", 1);SetTileTag(26,29,"LAND_1", 1);SetTileTag(41,29,"LAND_1", 1);SetTileTag(42,29,"LAND_1", 1);SetTileTag(43,29,"LAND_1", 1);SetTileTag(48,29,"LAND_1", 1);SetTileTag(49,29,"LAND_1", 1);SetTileTag(50,29,"LAND_1", 1);SetTileTag(54,29,"LAND_1", 1);SetTileTag(55,29,"LAND_1", 1);SetTileTag(56,29,"LAND_1", 1);SetTileTag(58,29,"LAND_1", 1);SetTileTag(59,29,"LAND_1", 1);SetTileTag(60,29,"LAND_1", 1);
				SetTileTag(13,28,"LAND_1", 1);SetTileTag(14,28,"LAND_1", 1);SetTileTag(15,28,"LAND_1", 1);SetTileTag(18,28,"LAND_1", 1);SetTileTag(19,28,"LAND_1", 1);SetTileTag(24,28,"LAND_1", 1);SetTileTag(27,28,"LAND_1", 1);SetTileTag(28,28,"LAND_1", 1);SetTileTag(29,28,"LAND_1", 1);SetTileTag(41,28,"LAND_1", 1);SetTileTag(42,28,"LAND_1", 1);SetTileTag(43,28,"LAND_1", 1);SetTileTag(48,28,"LAND_1", 1);SetTileTag(49,28,"LAND_1", 1);SetTileTag(50,28,"LAND_1", 1);SetTileTag(53,28,"LAND_1", 1);SetTileTag(54,28,"LAND_1", 1);SetTileTag(57,28,"LAND_1", 1);SetTileTag(58,28,"LAND_1", 1);SetTileTag(59,28,"LAND_1", 1);SetTileTag(60,28,"LAND_1", 1);
				SetTileTag(12,27,"LAND_1", 1);SetTileTag(13,27,"LAND_1", 1);SetTileTag(18,27,"LAND_1", 1);SetTileTag(24,27,"LAND_1", 1);SetTileTag(25,27,"LAND_1", 1);SetTileTag(26,27,"LAND_1", 1);SetTileTag(27,27,"LAND_1", 1);SetTileTag(28,27,"LAND_1", 1);SetTileTag(29,27,"LAND_1", 1);SetTileTag(30,27,"LAND_1", 1);SetTileTag(32,27,"LAND_1", 1);SetTileTag(41,27,"LAND_1", 1);SetTileTag(42,27,"LAND_1", 1);SetTileTag(43,27,"LAND_1", 1);SetTileTag(48,27,"LAND_1", 1);SetTileTag(49,27,"LAND_1", 1);SetTileTag(50,27,"LAND_1", 1);SetTileTag(51,27,"LAND_1", 1);SetTileTag(52,27,"LAND_1", 1);SetTileTag(53,27,"LAND_1", 1);SetTileTag(58,27,"LAND_1", 1);SetTileTag(59,27,"LAND_1", 1);SetTileTag(60,27,"LAND_1", 1);
				SetTileTag(17,26,"LAND_1", 1);SetTileTag(18,26,"LAND_1", 1);SetTileTag(24,26,"LAND_1", 1);SetTileTag(25,26,"LAND_1", 1);SetTileTag(26,26,"LAND_1", 1);SetTileTag(27,26,"LAND_1", 1);SetTileTag(28,26,"LAND_1", 1);SetTileTag(29,26,"LAND_1", 1);SetTileTag(30,26,"LAND_1", 1);SetTileTag(33,26,"LAND_1", 1);SetTileTag(34,26,"LAND_1", 1);SetTileTag(35,26,"LAND_1", 1);SetTileTag(36,26,"LAND_1", 1);SetTileTag(37,26,"LAND_1", 1);SetTileTag(38,26,"LAND_1", 1);SetTileTag(39,26,"LAND_1", 1);SetTileTag(41,26,"LAND_1", 1);SetTileTag(42,26,"LAND_1", 1);SetTileTag(43,26,"LAND_1", 1);SetTileTag(44,26,"LAND_1", 1);SetTileTag(45,26,"LAND_1", 1);SetTileTag(48,26,"LAND_1", 1);SetTileTag(49,26,"LAND_1", 1);SetTileTag(50,26,"LAND_1", 1);SetTileTag(51,26,"LAND_1", 1);SetTileTag(58,26,"LAND_1", 1);SetTileTag(59,26,"LAND_1", 1);SetTileTag(60,26,"LAND_1", 1);
				SetTileTag(16,25,"LAND_1", 1);SetTileTag(17,25,"LAND_1", 1);SetTileTag(20,25,"LAND_1", 1);SetTileTag(21,25,"LAND_1", 1);SetTileTag(22,25,"LAND_1", 1);SetTileTag(24,25,"LAND_1", 1);SetTileTag(25,25,"LAND_1", 1);SetTileTag(26,25,"LAND_1", 1);SetTileTag(27,25,"LAND_1", 1);SetTileTag(28,25,"LAND_1", 1);SetTileTag(30,25,"LAND_1", 1);SetTileTag(31,25,"LAND_1", 1);SetTileTag(32,25,"LAND_1", 1);SetTileTag(33,25,"LAND_1", 1);SetTileTag(34,25,"LAND_1", 1);SetTileTag(35,25,"LAND_1", 1);SetTileTag(36,25,"LAND_1", 1);SetTileTag(43,25,"LAND_1", 1);SetTileTag(49,25,"LAND_1", 1);SetTileTag(58,25,"LAND_1", 1);SetTileTag(59,25,"LAND_1", 1);SetTileTag(60,25,"LAND_1", 1);
				SetTileTag(2,24,"SOLIDWALL",1);SetTileTag(3,24,"LAND_1", 1);SetTileTag(4,24,"LAND_1", 1);SetTileTag(5,24,"LAND_1", 1);SetTileTag(6,24,"LAND_1", 1);SetTileTag(7,24,"LAND_1", 1);SetTileTag(15,24,"LAND_1", 1);SetTileTag(16,24,"LAND_1", 1);SetTileTag(19,24,"LAND_1", 1);SetTileTag(20,24,"LAND_1", 1);SetTileTag(21,24,"LAND_1", 1);SetTileTag(22,24,"LAND_1", 1);SetTileTag(23,24,"LAND_1", 1);SetTileTag(25,24,"LAND_1", 1);SetTileTag(26,24,"LAND_1", 1);SetTileTag(27,24,"LAND_1", 1);SetTileTag(30,24,"LAND_1", 1);SetTileTag(33,24,"LAND_1", 1);SetTileTag(34,24,"LAND_1", 1);SetTileTag(35,24,"LAND_1", 1);SetTileTag(36,24,"LAND_1", 1);SetTileTag(42,24,"LAND_1", 1);SetTileTag(43,24,"LAND_1", 1);SetTileTag(48,24,"LAND_1", 1);SetTileTag(49,24,"LAND_1", 1);SetTileTag(58,24,"LAND_1", 1);SetTileTag(59,24,"LAND_1", 1);SetTileTag(60,24,"LAND_1", 1);
				SetTileTag(3,23,"SOLIDWALL",1);SetTileTag(18,23,"LAND_1", 1);SetTileTag(19,23,"LAND_1", 1);SetTileTag(20,23,"LAND_1", 1);SetTileTag(21,23,"LAND_1", 1);SetTileTag(22,23,"LAND_1", 1);SetTileTag(23,23,"LAND_1", 1);SetTileTag(27,23,"LAND_1", 1);SetTileTag(29,23,"LAND_1", 1);SetTileTag(30,23,"LAND_1", 1);SetTileTag(33,23,"LAND_1", 1);SetTileTag(34,23,"LAND_1", 1);SetTileTag(35,23,"LAND_1", 1);SetTileTag(36,23,"LAND_1", 1);SetTileTag(41,23,"LAND_1", 1);SetTileTag(42,23,"LAND_1", 1);SetTileTag(52,23,"LAND_1", 1);SetTileTag(53,23,"LAND_1", 1);SetTileTag(54,23,"LAND_1", 1);SetTileTag(58,23,"LAND_1", 1);SetTileTag(59,23,"LAND_1", 1);SetTileTag(60,23,"LAND_1", 1);
				SetTileTag(8,22,"LAND_1", 1);SetTileTag(9,22,"LAND_1", 1);SetTileTag(10,22,"LAND_1", 1);SetTileTag(11,22,"LAND_1", 1);SetTileTag(12,22,"LAND_1", 1);SetTileTag(17,22,"LAND_1", 1);SetTileTag(18,22,"LAND_1", 1);SetTileTag(20,22,"LAND_1", 1);SetTileTag(21,22,"LAND_1", 1);SetTileTag(22,22,"LAND_1", 1);SetTileTag(23,22,"LAND_1", 1);SetTileTag(24,22,"LAND_1", 1);SetTileTag(25,22,"LAND_1", 1);SetTileTag(26,22,"LAND_1", 1);SetTileTag(28,22,"LAND_1", 1);SetTileTag(29,22,"LAND_1", 1);SetTileTag(30,22,"LAND_1", 1);SetTileTag(40,22,"LAND_1", 1);SetTileTag(41,22,"LAND_1", 1);SetTileTag(43,22,"LAND_1", 1);SetTileTag(49,22,"LAND_1", 1);SetTileTag(50,22,"LAND_1", 1);SetTileTag(51,22,"LAND_1", 1);SetTileTag(52,22,"LAND_1", 1);SetTileTag(53,22,"LAND_1", 1);SetTileTag(54,22,"LAND_1", 1);SetTileTag(58,22,"LAND_1", 1);SetTileTag(59,22,"LAND_1", 1);SetTileTag(60,22,"LAND_1", 1);
				SetTileTag(7,21,"SOLIDWALL",1);SetTileTag(8,21,"SOLIDWALL",1);SetTileTag(21,21,"LAND_1", 1);SetTileTag(23,21,"LAND_1", 1);SetTileTag(24,21,"LAND_1", 1);SetTileTag(25,21,"LAND_1", 1);SetTileTag(26,21,"LAND_1", 1);SetTileTag(28,21,"LAND_1", 1);SetTileTag(29,21,"LAND_1", 1);SetTileTag(30,21,"LAND_1", 1);SetTileTag(39,21,"LAND_1", 1);SetTileTag(40,21,"LAND_1", 1);SetTileTag(41,21,"LAND_1", 1);SetTileTag(42,21,"LAND_1", 1);SetTileTag(43,21,"LAND_1", 1);SetTileTag(50,21,"LAND_1", 1);SetTileTag(52,21,"LAND_1", 1);SetTileTag(53,21,"LAND_1", 1);SetTileTag(54,21,"LAND_1", 1);SetTileTag(58,21,"LAND_1", 1);SetTileTag(59,21,"LAND_1", 1);SetTileTag(60,21,"LAND_1", 1);
				SetTileTag(13,20,"LAND_1", 1);SetTileTag(14,20,"LAND_1", 1);SetTileTag(15,20,"LAND_1", 1);SetTileTag(16,20,"LAND_1", 1);SetTileTag(17,20,"LAND_1", 1);SetTileTag(21,20,"LAND_1", 1);SetTileTag(22,20,"LAND_1", 1);SetTileTag(23,20,"LAND_1", 1);SetTileTag(24,20,"LAND_1", 1);SetTileTag(25,20,"LAND_1", 1);SetTileTag(26,20,"LAND_1", 1);SetTileTag(28,20,"LAND_1", 1);SetTileTag(29,20,"LAND_1", 1);SetTileTag(38,20,"LAND_1", 1);SetTileTag(39,20,"LAND_1", 1);SetTileTag(41,20,"LAND_1", 1);SetTileTag(42,20,"LAND_1", 1);SetTileTag(43,20,"LAND_1", 1);SetTileTag(44,20,"LAND_1", 1);SetTileTag(51,20,"LAND_1", 1);SetTileTag(58,20,"LAND_1", 1);SetTileTag(59,20,"LAND_1", 1);SetTileTag(60,20,"LAND_1", 1);
				SetTileTag(2,19,"SOLIDWALL",1);SetTileTag(11,19,"LAND_1", 1);SetTileTag(12,19,"SOLIDWALL",1);SetTileTag(13,19,"SOLIDWALL",1);SetTileTag(16,19,"SOLIDWALL",1);SetTileTag(18,19,"LAND_1", 1);SetTileTag(19,19,"LAND_1", 1);SetTileTag(20,19,"LAND_1", 1);SetTileTag(21,19,"LAND_1", 1);SetTileTag(29,19,"LAND_1", 1);SetTileTag(37,19,"LAND_1", 1);SetTileTag(38,19,"LAND_1", 1);SetTileTag(41,19,"LAND_1", 1);SetTileTag(42,19,"LAND_1", 1);SetTileTag(43,19,"LAND_1", 1);SetTileTag(44,19,"LAND_1", 1);SetTileTag(45,19,"LAND_1", 1);SetTileTag(52,19,"LAND_1", 1);SetTileTag(54,19,"LAND_1", 1);SetTileTag(55,19,"LAND_1", 1);SetTileTag(56,19,"LAND_1", 1);SetTileTag(57,19,"LAND_1", 1);
				SetTileTag(3,18,"LAND_1", 1);SetTileTag(4,18,"LAND_1", 1);SetTileTag(5,18,"LAND_1", 1);SetTileTag(6,18,"LAND_1", 1);SetTileTag(7,18,"LAND_1", 1);SetTileTag(8,18,"LAND_1", 1);SetTileTag(9,18,"LAND_1", 1);SetTileTag(10,18,"LAND_1", 1);SetTileTag(11,18,"LAND_1", 1);SetTileTag(19,18,"LAND_1", 1);SetTileTag(21,18,"LAND_1", 1);SetTileTag(22,18,"LAND_1", 1);SetTileTag(23,18,"LAND_1", 1);SetTileTag(24,18,"LAND_1", 1);SetTileTag(25,18,"LAND_1", 1);SetTileTag(26,18,"LAND_1", 1);SetTileTag(32,18,"LAND_1", 1);SetTileTag(41,18,"LAND_1", 1);SetTileTag(46,18,"LAND_1", 1);SetTileTag(47,18,"LAND_1", 1);SetTileTag(49,18,"LAND_1", 1);SetTileTag(50,18,"LAND_1", 1);SetTileTag(51,18,"LAND_1", 1);SetTileTag(56,18,"LAND_1", 1);SetTileTag(58,18,"LAND_1", 1);
				SetTileTag(4,17,"LAND_1", 1);SetTileTag(6,17,"LAND_1", 1);SetTileTag(7,17,"LAND_1", 1);SetTileTag(8,17,"LAND_1", 1);SetTileTag(9,17,"LAND_1", 1);SetTileTag(10,17,"LAND_1", 1);SetTileTag(20,17,"LAND_1", 1);SetTileTag(21,17,"LAND_1", 1);SetTileTag(22,17,"LAND_1", 1);SetTileTag(23,17,"LAND_1", 1);SetTileTag(24,17,"LAND_1", 1);SetTileTag(25,17,"LAND_1", 1);SetTileTag(26,17,"LAND_1", 1);SetTileTag(27,17,"LAND_1", 1);SetTileTag(29,17,"LAND_1", 1);SetTileTag(30,17,"LAND_1", 1);SetTileTag(31,17,"LAND_1", 1);SetTileTag(42,17,"LAND_1", 1);SetTileTag(49,17,"LAND_1", 1);SetTileTag(50,17,"LAND_1", 1);SetTileTag(51,17,"LAND_1", 1);SetTileTag(57,17,"LAND_1", 1);SetTileTag(58,17,"LAND_1", 1);SetTileTag(59,17,"LAND_1", 1);
				SetTileTag(5,16,"LAND_1", 1);SetTileTag(6,16,"LAND_1", 1);SetTileTag(7,16,"LAND_1", 1);SetTileTag(8,16,"LAND_1", 1);SetTileTag(9,16,"LAND_1", 1);SetTileTag(10,16,"LAND_1", 1);SetTileTag(21,16,"LAND_1", 1);SetTileTag(22,16,"LAND_1", 1);SetTileTag(23,16,"LAND_1", 1);SetTileTag(24,16,"LAND_1", 1);SetTileTag(25,16,"LAND_1", 1);SetTileTag(26,16,"LAND_1", 1);SetTileTag(28,16,"LAND_1", 1);SetTileTag(39,16,"LAND_1", 1);SetTileTag(40,16,"LAND_1", 1);SetTileTag(43,16,"LAND_1", 1);SetTileTag(49,16,"LAND_1", 1);SetTileTag(50,16,"LAND_1", 1);SetTileTag(51,16,"LAND_1", 1);SetTileTag(57,16,"LAND_1", 1);SetTileTag(59,16,"LAND_1", 1);SetTileTag(60,16,"LAND_1", 1);
				SetTileTag(3,15,"LAND_1", 1);SetTileTag(4,15,"LAND_1", 1);SetTileTag(5,15,"LAND_1", 1);SetTileTag(6,15,"LAND_1", 1);SetTileTag(7,15,"LAND_1", 1);SetTileTag(8,15,"LAND_1", 1);SetTileTag(9,15,"LAND_1", 1);SetTileTag(10,15,"LAND_1", 1);SetTileTag(11,15,"LAND_1", 1);SetTileTag(12,15,"LAND_1", 1);SetTileTag(13,15,"LAND_1", 1);SetTileTag(40,15,"LAND_1", 1);SetTileTag(41,15,"LAND_1", 1);SetTileTag(49,15,"LAND_1", 1);SetTileTag(50,15,"LAND_1", 1);SetTileTag(51,15,"LAND_1", 1);SetTileTag(56,15,"LAND_1", 1);SetTileTag(57,15,"LAND_1", 1);
				SetTileTag(3,14,"LAND_1", 1);SetTileTag(4,14,"LAND_1", 1);SetTileTag(5,14,"LAND_1", 1);SetTileTag(11,14,"LAND_1", 1);SetTileTag(14,14,"LAND_1", 1);SetTileTag(21,14,"LAND_1", 1);SetTileTag(22,14,"LAND_1", 1);SetTileTag(23,14,"LAND_1", 1);SetTileTag(24,14,"LAND_1", 1);SetTileTag(25,14,"LAND_1", 1);SetTileTag(26,14,"LAND_1", 1);SetTileTag(27,14,"LAND_1", 1);SetTileTag(41,14,"LAND_1", 1);SetTileTag(42,14,"LAND_1", 1);SetTileTag(48,14,"LAND_1", 1);SetTileTag(49,14,"LAND_1", 1);SetTileTag(50,14,"LAND_1", 1);SetTileTag(51,14,"LAND_1", 1);SetTileTag(55,14,"LAND_1", 1);SetTileTag(56,14,"LAND_1", 1);SetTileTag(58,14,"LAND_1", 1);SetTileTag(59,14,"LAND_1", 1);
				SetTileTag(3,13,"LAND_1", 1);SetTileTag(4,13,"LAND_1", 1);SetTileTag(5,13,"LAND_1", 1);SetTileTag(20,13,"LAND_1", 1);SetTileTag(21,13,"LAND_1", 1);SetTileTag(22,13,"LAND_1", 1);SetTileTag(23,13,"LAND_1", 1);SetTileTag(24,13,"LAND_1", 1);SetTileTag(42,13,"LAND_1", 1);SetTileTag(43,13,"LAND_1", 1);SetTileTag(44,13,"LAND_1", 1);SetTileTag(47,13,"LAND_1", 1);SetTileTag(48,13,"LAND_1", 1);SetTileTag(57,13,"LAND_1", 1);SetTileTag(58,13,"LAND_1", 1);SetTileTag(59,13,"LAND_1", 1);
				SetTileTag(3,12,"LAND_1", 1);SetTileTag(4,12,"LAND_1", 1);SetTileTag(5,12,"LAND_1", 1);SetTileTag(19,12,"LAND_1", 1);SetTileTag(20,12,"LAND_1", 1);SetTileTag(22,12,"LAND_1", 1);SetTileTag(23,12,"LAND_1", 1);SetTileTag(24,12,"LAND_1", 1);SetTileTag(41,12,"LAND_1", 1);SetTileTag(42,12,"LAND_1", 1);SetTileTag(43,12,"LAND_1", 1);SetTileTag(46,12,"LAND_1", 1);SetTileTag(47,12,"LAND_1", 1);SetTileTag(50,12,"LAND_1", 1);SetTileTag(57,12,"LAND_1", 1);SetTileTag(58,12,"LAND_1", 1);SetTileTag(59,12,"LAND_1", 1);
				SetTileTag(3,11,"LAND_1", 1);SetTileTag(4,11,"LAND_1", 1);SetTileTag(5,11,"LAND_1", 1);SetTileTag(15,11,"SOLIDWALL",1);SetTileTag(18,11,"LAND_1", 1);SetTileTag(19,11,"LAND_1", 1);SetTileTag(22,11,"LAND_1", 1);SetTileTag(23,11,"LAND_1", 1);SetTileTag(24,11,"LAND_1", 1);SetTileTag(26,11,"LAND_1", 1);SetTileTag(27,11,"LAND_1", 1);SetTileTag(40,11,"LAND_1", 1);SetTileTag(41,11,"LAND_1", 1);SetTileTag(42,11,"LAND_1", 1);SetTileTag(45,11,"LAND_1", 1);SetTileTag(46,11,"LAND_1", 1);SetTileTag(51,11,"LAND_1", 1);SetTileTag(57,11,"LAND_1", 1);SetTileTag(58,11,"LAND_1", 1);SetTileTag(59,11,"LAND_1", 1);
				SetTileTag(3,10,"LAND_1", 1);SetTileTag(4,10,"LAND_1", 1);SetTileTag(5,10,"LAND_1", 1);SetTileTag(25,10,"LAND_1", 1);SetTileTag(26,10,"LAND_1", 1);SetTileTag(27,10,"LAND_1", 1);SetTileTag(28,10,"LAND_1", 1);SetTileTag(29,10,"LAND_1", 1);SetTileTag(30,10,"LAND_1", 1);SetTileTag(31,10,"LAND_1", 1);SetTileTag(32,10,"LAND_1", 1);SetTileTag(39,10,"LAND_1", 1);SetTileTag(40,10,"LAND_1", 1);SetTileTag(42,10,"LAND_1", 1);SetTileTag(45,10,"LAND_1", 1);SetTileTag(57,10,"LAND_1", 1);SetTileTag(58,10,"LAND_1", 1);SetTileTag(59,10,"LAND_1", 1);
				SetTileTag(3,9,"LAND_1", 1);SetTileTag(4,9,"LAND_1", 1);SetTileTag(5,9,"LAND_1", 1);SetTileTag(27,9,"LAND_1", 1);SetTileTag(29,9,"LAND_1", 1);SetTileTag(30,9,"LAND_1", 1);SetTileTag(44,9,"LAND_1", 1);SetTileTag(45,9,"LAND_1", 1);SetTileTag(57,9,"LAND_1", 1);SetTileTag(58,9,"LAND_1", 1);SetTileTag(59,9,"LAND_1", 1);
				SetTileTag(1,8,"SOLIDWALL",1);SetTileTag(2,8,"LAND_1", 1);SetTileTag(3,8,"LAND_1", 1);SetTileTag(4,8,"LAND_1", 1);SetTileTag(5,8,"LAND_1", 1);SetTileTag(26,8,"LAND_1", 1);SetTileTag(27,8,"LAND_1", 1);SetTileTag(29,8,"LAND_1", 1);SetTileTag(30,8,"LAND_1", 1);SetTileTag(43,8,"LAND_1", 1);SetTileTag(44,8,"LAND_1", 1);SetTileTag(48,8,"LAND_1", 1);SetTileTag(49,8,"LAND_1", 1);SetTileTag(50,8,"LAND_1", 1);SetTileTag(51,8,"LAND_1", 1);SetTileTag(52,8,"LAND_1", 1);SetTileTag(53,8,"LAND_1", 1);SetTileTag(54,8,"LAND_1", 1);SetTileTag(57,8,"LAND_1", 1);SetTileTag(58,8,"LAND_1", 1);SetTileTag(59,8,"LAND_1", 1);
				SetTileTag(3,7,"LAND_1", 1);SetTileTag(4,7,"LAND_1", 1);SetTileTag(5,7,"LAND_1", 1);SetTileTag(6,7,"LAND_1", 1);SetTileTag(7,7,"LAND_1", 1);SetTileTag(14,7,"LAND_1", 1);SetTileTag(15,7,"LAND_1", 1);SetTileTag(16,7,"LAND_1", 1);SetTileTag(17,7,"LAND_1", 1);SetTileTag(18,7,"LAND_1", 1);SetTileTag(19,7,"LAND_1", 1);SetTileTag(20,7,"LAND_1", 1);SetTileTag(21,7,"LAND_1", 1);SetTileTag(25,7,"LAND_1", 1);SetTileTag(26,7,"LAND_1", 1);SetTileTag(29,7,"LAND_1", 1);SetTileTag(30,7,"LAND_1", 1);SetTileTag(31,7,"LAND_1", 1);SetTileTag(32,7,"LAND_1", 1);SetTileTag(42,7,"LAND_1", 1);SetTileTag(43,7,"LAND_1", 1);SetTileTag(47,7,"LAND_1", 1);SetTileTag(48,7,"LAND_1", 1);SetTileTag(49,7,"LAND_1", 1);SetTileTag(50,7,"LAND_1", 1);SetTileTag(51,7,"LAND_1", 1);SetTileTag(52,7,"LAND_1", 1);
				SetTileTag(3,6,"LAND_1", 1);SetTileTag(4,6,"LAND_1", 1);SetTileTag(5,6,"LAND_1", 1);SetTileTag(6,6,"LAND_1", 1);SetTileTag(15,6,"LAND_1", 1);SetTileTag(17,6,"LAND_1", 1);SetTileTag(18,6,"LAND_1", 1);SetTileTag(19,6,"LAND_1", 1);SetTileTag(30,6,"LAND_1", 1);SetTileTag(31,6,"LAND_1", 1);SetTileTag(32,6,"LAND_1", 1);SetTileTag(46,6,"LAND_1", 1);SetTileTag(47,6,"LAND_1", 1);SetTileTag(49,6,"LAND_1", 1);SetTileTag(50,6,"LAND_1", 1);SetTileTag(51,6,"LAND_1", 1);SetTileTag(52,6,"LAND_1", 1);SetTileTag(55,6,"LAND_1", 1);SetTileTag(56,6,"LAND_1", 1);
				SetTileTag(4,5,"LAND_1", 1);SetTileTag(7,5,"LAND_1", 1);SetTileTag(8,5,"LAND_1", 1);SetTileTag(9,5,"LAND_1", 1);SetTileTag(10,5,"LAND_1", 1);SetTileTag(11,5,"LAND_1", 1);SetTileTag(12,5,"LAND_1", 1);SetTileTag(13,5,"LAND_1", 1);SetTileTag(14,5,"LAND_1", 1);SetTileTag(15,5,"LAND_1", 1);SetTileTag(17,5,"LAND_1", 1);SetTileTag(18,5,"LAND_1", 1);SetTileTag(19,5,"LAND_1", 1);SetTileTag(22,5,"LAND_1", 1);SetTileTag(23,5,"LAND_1", 1);SetTileTag(24,5,"LAND_1", 1);SetTileTag(25,5,"LAND_1", 1);SetTileTag(26,5,"LAND_1", 1);SetTileTag(27,5,"LAND_1", 1);SetTileTag(28,5,"LAND_1", 1);SetTileTag(29,5,"LAND_1", 1);SetTileTag(30,5,"LAND_1", 1);SetTileTag(31,5,"LAND_1", 1);SetTileTag(32,5,"LAND_1", 1);SetTileTag(45,5,"LAND_1", 1);SetTileTag(46,5,"LAND_1", 1);SetTileTag(49,5,"LAND_1", 1);SetTileTag(50,5,"LAND_1", 1);SetTileTag(51,5,"LAND_1", 1);SetTileTag(54,5,"LAND_1", 1);SetTileTag(55,5,"LAND_1", 1);SetTileTag(57,5,"LAND_1", 1);
				SetTileTag(5,4,"LAND_1", 1);SetTileTag(6,4,"LAND_1", 1);SetTileTag(7,4,"LAND_1", 1);SetTileTag(8,4,"LAND_1", 1);SetTileTag(9,4,"LAND_1", 1);SetTileTag(10,4,"LAND_1", 1);SetTileTag(11,4,"LAND_1", 1);SetTileTag(12,4,"LAND_1", 1);SetTileTag(13,4,"LAND_1", 1);SetTileTag(14,4,"LAND_1", 1);SetTileTag(15,4,"LAND_1", 1);SetTileTag(16,4,"LAND_1", 1);SetTileTag(17,4,"LAND_1", 1);SetTileTag(18,4,"LAND_1", 1);SetTileTag(21,4,"LAND_1", 1);SetTileTag(22,4,"LAND_1", 1);SetTileTag(23,4,"LAND_1", 1);SetTileTag(24,4,"LAND_1", 1);SetTileTag(25,4,"LAND_1", 1);SetTileTag(26,4,"LAND_1", 1);SetTileTag(27,4,"LAND_1", 1);SetTileTag(28,4,"LAND_1", 1);SetTileTag(29,4,"LAND_1", 1);SetTileTag(30,4,"LAND_1", 1);SetTileTag(53,4,"LAND_1", 1);SetTileTag(54,4,"LAND_1", 1);SetTileTag(58,4,"LAND_1", 1);
				SetTileTag(6,3,"LAND_1", 1);SetTileTag(8,3,"LAND_1", 1);SetTileTag(9,3,"LAND_1", 1);SetTileTag(10,3,"LAND_1", 1);SetTileTag(11,3,"LAND_1", 1);SetTileTag(12,3,"LAND_1", 1);SetTileTag(13,3,"LAND_1", 1);SetTileTag(14,3,"LAND_1", 1);SetTileTag(20,3,"LAND_1", 1);SetTileTag(21,3,"LAND_1", 1);SetTileTag(22,3,"LAND_1", 1);SetTileTag(23,3,"LAND_1", 1);SetTileTag(24,3,"LAND_1", 1);SetTileTag(25,3,"LAND_1", 1);SetTileTag(26,3,"LAND_1", 1);SetTileTag(27,3,"LAND_1", 1);SetTileTag(28,3,"LAND_1", 1);SetTileTag(29,3,"LAND_1", 1);SetTileTag(30,3,"LAND_1", 1);SetTileTag(31,3,"LAND_1", 1);SetTileTag(52,3,"LAND_1", 1);SetTileTag(53,3,"LAND_1", 1);SetTileTag(59,3,"LAND_1", 1);
				SetTileTag(2,2,"SOLIDWALL",1);SetTileTag(3,2,"LAND_1", 1);SetTileTag(4,2,"LAND_1", 1);SetTileTag(5,2,"LAND_1", 1);SetTileTag(6,2,"LAND_1", 1);SetTileTag(8,2,"LAND_1", 1);SetTileTag(9,2,"LAND_1", 1);SetTileTag(10,2,"LAND_1", 1);SetTileTag(11,2,"LAND_1", 1);SetTileTag(12,2,"LAND_1", 1);SetTileTag(13,2,"LAND_1", 1);SetTileTag(14,2,"LAND_1", 1);SetTileTag(16,2,"LAND_1", 1);SetTileTag(17,2,"LAND_1", 1);SetTileTag(18,2,"LAND_1", 1);SetTileTag(19,2,"LAND_1", 1);SetTileTag(20,2,"LAND_1", 1);SetTileTag(22,2,"LAND_1", 1);SetTileTag(23,2,"LAND_1", 1);SetTileTag(24,2,"LAND_1", 1);SetTileTag(25,2,"LAND_1", 1);SetTileTag(26,2,"LAND_1", 1);SetTileTag(27,2,"LAND_1", 1);SetTileTag(28,2,"LAND_1", 1);SetTileTag(29,2,"LAND_1", 1);SetTileTag(30,2,"LAND_1", 1);SetTileTag(32,2,"LAND_1", 1);SetTileTag(33,2,"LAND_1", 1);SetTileTag(34,2,"LAND_1", 1);SetTileTag(35,2,"LAND_1", 1);SetTileTag(36,2,"LAND_1", 1);SetTileTag(37,2,"LAND_1", 1);SetTileTag(38,2,"LAND_1", 1);SetTileTag(39,2,"LAND_1", 1);SetTileTag(40,2,"LAND_1", 1);SetTileTag(41,2,"LAND_1", 1);SetTileTag(42,2,"LAND_1", 1);SetTileTag(43,2,"LAND_1", 1);SetTileTag(44,2,"LAND_1", 1);SetTileTag(45,2,"LAND_1", 1);SetTileTag(46,2,"LAND_1", 1);SetTileTag(47,2,"LAND_1", 1);SetTileTag(48,2,"LAND_1", 1);SetTileTag(49,2,"LAND_1", 1);SetTileTag(50,2,"LAND_1", 1);SetTileTag(51,2,"LAND_1", 1);SetTileTag(52,2,"LAND_1", 1);SetTileTag(60,2,"LAND_1", 1);SetTileTag(61,2,"SOLIDWALL",1);
				SetTileTag(3,1,"SOLIDWALL",1);


	}

	[MenuItem("MyTools/CreateWeaponAnims")]
	static void CreateWeaponAnims()
	{
				return;

				_RES="UW2";//Set the game resource folder

				CreateAnimationUI("WeaponPutAway", "weapons_blank", "", "", "", "", "", "", "", 1, _RES+ "/hud/weapons", 0.1f, false);
				CreateAnimationUI("Sword_Slash_White_Right_Charge","Weapons_0_0000","Weapons_0_0001","Weapons_0_0002", "", "", "", "", "", 3,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Sword_Slash_White_Right_Execute","Weapons_0_0004","Weapons_0_0005","Weapons_0_0006","Weapons_0_0007", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Sword_Bash_White_Right_Charge","Weapons_0_0009","Weapons_0_0010","Weapons_0_0011", "", "", "", "", "", 3,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Sword_Bash_White_Right_Execute","Weapons_0_0013","Weapons_0_0014","Weapons_0_0015","Weapons_0_0016", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Sword_Stab_White_Right_Execute","Weapons_0_0022","Weapons_0_0023","Weapons_0_0024","Weapons_0_0023", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Sword_Ready_White_Right","Weapons_0_0029","Weapons_0_0028","Weapons_0_0027", "", "", "", "", "", 3,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Axe_Slash_White_Right_Charge","Weapons_0_0031","Weapons_0_0032","Weapons_0_0033", "", "", "", "", "", 3,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Axe_Slash_White_Right_Execute","Weapons_0_0035","Weapons_0_0036","Weapons_0_0037","Weapons_0_0038", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Axe_Bash_White_Right_Charge","Weapons_0_0040","Weapons_0_0041","Weapons_0_0042", "", "", "", "", "", 3,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Axe_Bash_White_Right_Execute","Weapons_0_0044","Weapons_0_0045","Weapons_0_0046","Weapons_0_0047", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Axe_Stab_White_Right_Execute","Weapons_0_0053","Weapons_0_0054","Weapons_0_0055","Weapons_0_0054", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Axe_Ready_White_Right","Weapons_0_0060","Weapons_0_0059","Weapons_0_0058", "", "", "", "", "", 3,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Mace_Slash_White_Right_Charge","Weapons_0_0062","Weapons_0_0063","Weapons_0_0064", "", "", "", "", "", 3,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Mace_Slash_White_Right_Execute","Weapons_0_0066","Weapons_0_0067","Weapons_0_0068","Weapons_0_0069", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Mace_Bash_White_Right_Charge","Weapons_0_0071","Weapons_0_0072","Weapons_0_0073", "", "", "", "", "", 3,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Mace_Bash_White_Right_Execute","Weapons_0_0075","Weapons_0_0076","Weapons_0_0077","Weapons_0_0078", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Mace_Stab_White_Right_Execute","Weapons_0_0084","Weapons_0_0085","Weapons_0_0086","Weapons_0_0085", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Mace_Ready_White_Right","Weapons_0_0091","Weapons_0_0090","Weapons_0_0089", "", "", "", "", "", 3,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Fist_Slash_White_Right_Execute","Weapons_0_0097","Weapons_0_0098","Weapons_0_0099","Weapons_0_0098", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Fist_Bash_White_Right_Execute","Weapons_0_0097","Weapons_0_0098","Weapons_0_0099","Weapons_0_0098", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Fist_Stab_White_Right_Execute","Weapons_0_0097","Weapons_0_0098","Weapons_0_0099","Weapons_0_0098", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Fist_Ready_White_Right","Weapons_0_0102", "" , "" , "", "", "", "", "", 1,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Fist_Slash_White_Right_Charge","Weapons_0_0104", "" , "" , "", "", "", "", "", 1,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Sword_Slash_White_Left_Charge","Weapons_0_0000","Weapons_0_0001","Weapons_0_0002", "", "", "", "", "", 3,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Sword_Slash_White_Left_Execute","Weapons_0_0128","Weapons_0_0129","Weapons_0_0130","Weapons_0_0131", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Sword_Bash_White_Left_Charge","Weapons_0_0133","Weapons_0_0134","Weapons_0_0135", "", "", "", "", "", 3,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Sword_Bash_White_Left_Execute","Weapons_0_0137","Weapons_0_0138","Weapons_0_0139","Weapons_0_0140", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Sword_Stab_White_Left_Execute","Weapons_0_0146","Weapons_0_0147","Weapons_0_0148","Weapons_0_0147", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Sword_Ready_White_Left","Weapons_0_0154","Weapons_0_0153","Weapons_0_0152", "", "", "", "", "", 3,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Axe_Slash_White_Left_Charge","Weapons_0_0155","Weapons_0_0156","Weapons_0_0157", "", "", "", "", "", 3,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Axe_Slash_White_Left_Execute","Weapons_0_0159","Weapons_0_0160","Weapons_0_0161","Weapons_0_0162", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Axe_Bash_White_Left_Charge","Weapons_0_0164","Weapons_0_0165","Weapons_0_0166", "", "", "", "", "", 3,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Axe_Bash_White_Left_Execute","Weapons_0_0168","Weapons_0_0169","Weapons_0_0170","Weapons_0_0171", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Axe_Stab_White_Left_Execute","Weapons_0_0177","Weapons_0_0178","Weapons_0_0179","Weapons_0_0178", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Axe_Ready_White_Left","Weapons_0_0184","Weapons_0_0183","Weapons_0_0182", "", "", "", "", "", 3,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Mace_Slash_White_Left_Charge","Weapons_0_0186","Weapons_0_0187","Weapons_0_0188", "", "", "", "", "", 3,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Mace_Slash_White_Left_Execute","Weapons_0_0190","Weapons_0_0191","Weapons_0_0192","Weapons_0_0193", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Mace_Bash_White_Left_Charge","Weapons_0_0195","Weapons_0_0196","Weapons_0_0197", "", "", "", "", "", 3,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Mace_Bash_White_Left_Execute","Weapons_0_0199","Weapons_0_0200","Weapons_0_0201","Weapons_0_0202", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Mace_Stab_White_Left_Execute","Weapons_0_0208","Weapons_0_0209","Weapons_0_0210","Weapons_0_0209", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Mace_Ready_White_Left","Weapons_0_0215","Weapons_0_0214","Weapons_0_0213", "", "", "", "", "", 3,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Fist_Slash_White_Left_Execute","Weapons_0_0221","Weapons_0_0222","Weapons_0_0223","Weapons_0_0222", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Fist_Bash_White_Left_Execute","Weapons_0_0221","Weapons_0_0222","Weapons_0_0223","Weapons_0_0222", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Fist_Stab_White_Left_Execute","Weapons_0_0221","Weapons_0_0222","Weapons_0_0223","Weapons_0_0222", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Fist_Ready_White_Left","Weapons_0_0225", "" , "" , "", "", "", "", "", 1,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Fist_Slash_White_Left_Charge","Weapons_0_0227", "" , "" , "", "", "", "", "", 1,_RES + "/hud/weapons", 0.25f, false);

				CreateAnimationUI("Sword_Slash_Black_Right_Charge","Weapons_1_0000","Weapons_1_0001","Weapons_1_0002", "", "", "", "", "", 3,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Sword_Slash_Black_Right_Execute","Weapons_1_0004","Weapons_1_0005","Weapons_1_0006","Weapons_1_0007", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Sword_Bash_Black_Right_Charge","Weapons_1_0009","Weapons_1_0010","Weapons_1_0011", "", "", "", "", "", 3,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Sword_Bash_Black_Right_Execute","Weapons_1_0013","Weapons_1_0014","Weapons_1_0015","Weapons_1_0016", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Sword_Stab_Black_Right_Execute","Weapons_1_0022","Weapons_1_0023","Weapons_1_0024","Weapons_1_0023", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Sword_Ready_Black_Right","Weapons_1_0029","Weapons_1_0028","Weapons_1_0027", "", "", "", "", "", 3,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Axe_Slash_Black_Right_Charge","Weapons_1_0031","Weapons_1_0032","Weapons_1_0033", "", "", "", "", "", 3,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Axe_Slash_Black_Right_Execute","Weapons_1_0035","Weapons_1_0036","Weapons_1_0037","Weapons_1_0038", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Axe_Bash_Black_Right_Charge","Weapons_1_0040","Weapons_1_0041","Weapons_1_0042", "", "", "", "", "", 3,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Axe_Bash_Black_Right_Execute","Weapons_1_0044","Weapons_1_0045","Weapons_1_0046","Weapons_1_0047", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Axe_Stab_Black_Right_Execute","Weapons_1_0053","Weapons_1_0054","Weapons_1_0055","Weapons_1_0054", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Axe_Ready_Black_Right","Weapons_1_0060","Weapons_1_0059","Weapons_1_0058", "", "", "", "", "", 3,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Mace_Slash_Black_Right_Charge","Weapons_1_0062","Weapons_1_0063","Weapons_1_0064", "", "", "", "", "", 3,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Mace_Slash_Black_Right_Execute","Weapons_1_0066","Weapons_1_0067","Weapons_1_0068","Weapons_1_0069", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Mace_Bash_Black_Right_Charge","Weapons_1_0071","Weapons_1_0072","Weapons_1_0073", "", "", "", "", "", 3,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Mace_Bash_Black_Right_Execute","Weapons_1_0075","Weapons_1_0076","Weapons_1_0077","Weapons_1_0078", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Mace_Stab_Black_Right_Execute","Weapons_1_0084","Weapons_1_0085","Weapons_1_0086","Weapons_1_0085", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Mace_Ready_Black_Right","Weapons_1_0091","Weapons_1_0090","Weapons_1_0089", "", "", "", "", "", 3,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Fist_Slash_Black_Right_Execute","Weapons_1_0097","Weapons_1_0098","Weapons_1_0099","Weapons_1_0098", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Fist_Bash_Black_Right_Execute","Weapons_1_0097","Weapons_1_0098","Weapons_1_0099","Weapons_1_0098", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Fist_Stab_Black_Right_Execute","Weapons_1_0097","Weapons_1_0098","Weapons_1_0099","Weapons_1_0098", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Fist_Ready_Black_Right","Weapons_1_0102", "" , "" , "", "", "", "", "", 1,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Fist_Slash_Black_Right_Charge","Weapons_1_0104", "" , "" , "", "", "", "", "", 1,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Sword_Slash_Black_Left_Charge","Weapons_1_0000","Weapons_1_0001","Weapons_1_0002", "", "", "", "", "", 3,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Sword_Slash_Black_Left_Execute","Weapons_1_0128","Weapons_1_0129","Weapons_1_0130","Weapons_1_0131", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Sword_Bash_Black_Left_Charge","Weapons_1_0133","Weapons_1_0134","Weapons_1_0135", "", "", "", "", "", 3,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Sword_Bash_Black_Left_Execute","Weapons_1_0137","Weapons_1_0138","Weapons_1_0139","Weapons_1_0140", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Sword_Stab_Black_Left_Execute","Weapons_1_0146","Weapons_1_0147","Weapons_1_0148","Weapons_1_0147", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Sword_Ready_Black_Left","Weapons_1_0154","Weapons_1_0153","Weapons_1_0152", "", "", "", "", "", 3,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Axe_Slash_Black_Left_Charge","Weapons_1_0155","Weapons_1_0156","Weapons_1_0157", "", "", "", "", "", 3,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Axe_Slash_Black_Left_Execute","Weapons_1_0159","Weapons_1_0160","Weapons_1_0161","Weapons_1_0162", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Axe_Bash_Black_Left_Charge","Weapons_1_0164","Weapons_1_0165","Weapons_1_0166", "", "", "", "", "", 3,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Axe_Bash_Black_Left_Execute","Weapons_1_0168","Weapons_1_0169","Weapons_1_0170","Weapons_1_0171", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Axe_Stab_Black_Left_Execute","Weapons_1_0177","Weapons_1_0178","Weapons_1_0179","Weapons_1_0178", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Axe_Ready_Black_Left","Weapons_1_0184","Weapons_1_0183","Weapons_1_0182", "", "", "", "", "", 3,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Mace_Slash_Black_Left_Charge","Weapons_1_0186","Weapons_1_0187","Weapons_1_0188", "", "", "", "", "", 3,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Mace_Slash_Black_Left_Execute","Weapons_1_0190","Weapons_1_0191","Weapons_1_0192","Weapons_1_0193", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Mace_Bash_Black_Left_Charge","Weapons_1_0195","Weapons_1_0196","Weapons_1_0197", "", "", "", "", "", 3,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Mace_Bash_Black_Left_Execute","Weapons_1_0199","Weapons_1_0200","Weapons_1_0201","Weapons_1_0202", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Mace_Stab_Black_Left_Execute","Weapons_1_0208","Weapons_1_0209","Weapons_1_0210","Weapons_1_0209", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Mace_Ready_Black_Left","Weapons_1_0215","Weapons_1_0214","Weapons_1_0213", "", "", "", "", "", 3,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Fist_Slash_Black_Left_Execute","Weapons_1_0221","Weapons_1_0222","Weapons_1_0223","Weapons_1_0222", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Fist_Bash_Black_Left_Execute","Weapons_1_0221","Weapons_1_0222","Weapons_1_0223","Weapons_1_0222", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Fist_Stab_Black_Left_Execute","Weapons_1_0221","Weapons_1_0222","Weapons_1_0223","Weapons_1_0222", "", "", "", "", 4,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Fist_Ready_Black_Left","Weapons_1_0225", "" , "" , "", "", "", "", "", 1,_RES + "/hud/weapons", 0.25f, false);
				CreateAnimationUI("Fist_Slash_Black_Left_Charge","Weapons_1_0227", "" , "" , "", "", "", "", "", 1,_RES + "/hud/weapons", 0.25f, false);
	

			return;

				/*
		CreateAnimationUI("WeaponPutAway", "weapons_blank", "", "", "", "", "", "", "", 1, "hud/weapons", 0.1f, false);



		//UW 1 Weapons

		CreateAnimationUI("Sword_Slash_White_Right_Charge", "weapons_0_0000", "weapons_0_0001", "weapons_0_0002", "weapons_0_0003", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Sword_Slash_White_Right_Execute", "weapons_0_0004", "weapons_0_0005", "weapons_0_0006", "weapons_0_0007", "weapons_0_0008", "weapons_0_0027", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Sword_Bash_White_Right_Charge", "weapons_0_0009", "weapons_0_0010", "weapons_0_0011", "weapons_0_0012", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Sword_Bash_White_Right_Execute", "weapons_0_0013", "weapons_0_0014", "weapons_0_0015", "weapons_0_0016", "weapons_0_0017", "weapons_0_0027", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Sword_Stab_White_Right_Charge", "weapons_0_0018", "weapons_0_0019", "weapons_0_0020", "weapons_0_0021", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Sword_Stab_White_Right_Execute", "weapons_0_0022", "weapons_0_0023", "weapons_0_0024", "weapons_0_0025", "weapons_0_0026", "weapons_0_0027", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Sword_Ready_White_Right", "weapons_0_0027", "", "", "", "", "", "", "", 1, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Axe_Slash_White_Right_Charge", "weapons_0_0028", "weapons_0_0029", "weapons_0_0030", "weapons_0_0031", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Axe_Slash_White_Right_Execute", "weapons_0_0032", "weapons_0_0033", "weapons_0_0034", "weapons_0_0035", "weapons_0_0036", "weapons_0_0055", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Axe_Bash_White_Right_Charge", "weapons_0_0037", "weapons_0_0038", "weapons_0_0039", "weapons_0_0040", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Axe_Bash_White_Right_Execute", "weapons_0_0041", "weapons_0_0042", "weapons_0_0043", "weapons_0_0044", "weapons_0_0045", "weapons_0_0055", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Axe_Stab_White_Right_Charge", "weapons_0_0046", "weapons_0_0047", "weapons_0_0048", "weapons_0_0049", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Axe_Stab_White_Right_Execute", "weapons_0_0050", "weapons_0_0051", "weapons_0_0052", "weapons_0_0053", "weapons_0_0054", "weapons_0_0055", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Axe_Ready_White_Right", "weapons_0_0055", "", "", "", "", "", "", "", 1, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Mace_Slash_White_Right_Charge", "weapons_0_0056", "weapons_0_0057", "weapons_0_0058", "weapons_0_0059", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Mace_Slash_White_Right_Execute", "weapons_0_0060", "weapons_0_0061", "weapons_0_0062", "weapons_0_0063", "weapons_0_0064", "weapons_0_0083", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Mace_Bash_White_Right_Charge", "weapons_0_0065", "weapons_0_0066", "weapons_0_0067", "weapons_0_0068", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Mace_Bash_White_Right_Execute", "weapons_0_0069", "weapons_0_0070", "weapons_0_0071", "weapons_0_0072", "weapons_0_0073", "weapons_0_0083", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Mace_Stab_White_Right_Charge", "weapons_0_0074", "weapons_0_0075", "weapons_0_0076", "weapons_0_0077", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Mace_Stab_White_Right_Execute", "weapons_0_0078", "weapons_0_0079", "weapons_0_0080", "weapons_0_0081", "weapons_0_0082", "weapons_0_0083", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Mace_Ready_White_Right", "weapons_0_0083", "", "", "", "", "", "", "", 1, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Fist_Slash_White_Right_Charge", "weapons_0_0084", "weapons_0_0085", "weapons_0_0086", "weapons_0_0087", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Fist_Slash_White_Right_Execute", "weapons_0_0088", "weapons_0_0089", "weapons_0_0090", "weapons_0_0091", "weapons_0_0092", "weapons_0_0111", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Fist_Bash_White_Right_Charge", "weapons_0_0093", "weapons_0_0094", "weapons_0_0095", "weapons_0_0096", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Fist_Bash_White_Right_Execute", "weapons_0_0097", "weapons_0_0098", "weapons_0_0099", "weapons_0_0100", "weapons_0_0101", "weapons_0_0111", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Fist_Stab_White_Right_Charge", "weapons_0_0102", "weapons_0_0103", "weapons_0_0104", "weapons_0_0105", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Fist_Stab_White_Right_Execute", "weapons_0_0106", "weapons_0_0107", "weapons_0_0108", "weapons_0_0109", "weapons_0_0110", "weapons_0_0111", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Fist_Ready_White_Right", "weapons_0_0111", "", "", "", "", "", "", "", 1, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Sword_Slash_White_Left_Charge", "weapons_0_0112", "weapons_0_0113", "weapons_0_0114", "weapons_0_0115", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Sword_Slash_White_Left_Execute", "weapons_0_0116", "weapons_0_0117", "weapons_0_0118", "weapons_0_0119", "weapons_0_0120", "weapons_0_0139", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Sword_Bash_White_Left_Charge", "weapons_0_0121", "weapons_0_0122", "weapons_0_0123", "weapons_0_0124", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Sword_Bash_White_Left_Execute", "weapons_0_0125", "weapons_0_0126", "weapons_0_0127", "weapons_0_0128", "weapons_0_0129", "weapons_0_0139", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Sword_Stab_White_Left_Charge", "weapons_0_0130", "weapons_0_0131", "weapons_0_0132", "weapons_0_0133", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Sword_Stab_White_Left_Execute", "weapons_0_0134", "weapons_0_0135", "weapons_0_0136", "weapons_0_0137", "weapons_0_0138", "weapons_0_0139", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Sword_Ready_White_Left", "weapons_0_0139", "", "", "", "", "", "", "", 1, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Axe_Slash_White_Left_Charge", "weapons_0_0140", "weapons_0_0141", "weapons_0_0142", "weapons_0_0143", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Axe_Slash_White_Left_Execute", "weapons_0_0144", "weapons_0_0145", "weapons_0_0146", "weapons_0_0147", "weapons_0_0148", "weapons_0_0167", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Axe_Bash_White_Left_Charge", "weapons_0_0149", "weapons_0_0150", "weapons_0_0151", "weapons_0_0152", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Axe_Bash_White_Left_Execute", "weapons_0_0153", "weapons_0_0154", "weapons_0_0155", "weapons_0_0156", "weapons_0_0157", "weapons_0_0167", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Axe_Stab_White_Left_Charge", "weapons_0_0158", "weapons_0_0159", "weapons_0_0160", "weapons_0_0161", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Axe_Stab_White_Left_Execute", "weapons_0_0162", "weapons_0_0163", "weapons_0_0164", "weapons_0_0165", "weapons_0_0166", "weapons_0_0167", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Axe_Ready_White_Left", "weapons_0_0167", "", "", "", "", "", "", "", 1, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Mace_Slash_White_Left_Charge", "weapons_0_0168", "weapons_0_0169", "weapons_0_0170", "weapons_0_0171", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Mace_Slash_White_Left_Execute", "weapons_0_0172", "weapons_0_0173", "weapons_0_0174", "weapons_0_0175", "weapons_0_0176", "weapons_0_0195", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Mace_Bash_White_Left_Charge", "weapons_0_0177", "weapons_0_0178", "weapons_0_0179", "weapons_0_0180", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Mace_Bash_White_Left_Execute", "weapons_0_0181", "weapons_0_0182", "weapons_0_0183", "weapons_0_0184", "weapons_0_0185", "weapons_0_0195", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Mace_Stab_White_Left_Charge", "weapons_0_0186", "weapons_0_0187", "weapons_0_0188", "weapons_0_0189", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Mace_Stab_White_Left_Execute", "weapons_0_0190", "weapons_0_0191", "weapons_0_0192", "weapons_0_0193", "weapons_0_0194", "weapons_0_0195", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Mace_Ready_White_Left", "weapons_0_0195", "", "", "", "", "", "", "", 1, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Fist_Slash_White_Left_Charge", "weapons_0_0196", "weapons_0_0197", "weapons_0_0198", "weapons_0_0199", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Fist_Slash_White_Left_Execute", "weapons_0_0200", "weapons_0_0201", "weapons_0_0202", "weapons_0_0203", "weapons_0_0204", "weapons_0_0223", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Fist_Bash_White_Left_Charge", "weapons_0_0205", "weapons_0_0206", "weapons_0_0207", "weapons_0_0208", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Fist_Bash_White_Left_Execute", "weapons_0_0209", "weapons_0_0210", "weapons_0_0211", "weapons_0_0212", "weapons_0_0213", "weapons_0_0223", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Fist_Stab_White_Left_Charge", "weapons_0_0214", "weapons_0_0215", "weapons_0_0216", "weapons_0_0217", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Fist_Stab_White_Left_Execute", "weapons_0_0218", "weapons_0_0219", "weapons_0_0220", "weapons_0_0221", "weapons_0_0222", "weapons_0_0223", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Fist_Ready_White_Left", "weapons_0_0223", "", "", "", "", "", "", "", 1, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Sword_Slash_Black_Right_Charge", "weapons_1_0000", "weapons_1_0001", "weapons_1_0002", "weapons_1_0003", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Sword_Slash_Black_Right_Execute", "weapons_1_0004", "weapons_1_0005", "weapons_1_0006", "weapons_1_0007", "weapons_1_0008", "weapons_1_0027", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Sword_Bash_Black_Right_Charge", "weapons_1_0009", "weapons_1_0010", "weapons_1_0011", "weapons_1_0012", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Sword_Bash_Black_Right_Execute", "weapons_1_0013", "weapons_1_0014", "weapons_1_0015", "weapons_1_0016", "weapons_1_0017", "weapons_1_0027", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Sword_Stab_Black_Right_Charge", "weapons_1_0018", "weapons_1_0019", "weapons_1_0020", "weapons_1_0021", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Sword_Stab_Black_Right_Execute", "weapons_1_0022", "weapons_1_0023", "weapons_1_0024", "weapons_1_0025", "weapons_1_0026", "weapons_1_0027", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Sword_Ready_Black_Right", "weapons_1_0027", "", "", "", "", "", "", "", 1, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Axe_Slash_Black_Right_Charge", "weapons_1_0028", "weapons_1_0029", "weapons_1_0030", "weapons_1_0031", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Axe_Slash_Black_Right_Execute", "weapons_1_0032", "weapons_1_0033", "weapons_1_0034", "weapons_1_0035", "weapons_1_0036", "weapons_1_0055", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Axe_Bash_Black_Right_Charge", "weapons_1_0037", "weapons_1_0038", "weapons_1_0039", "weapons_1_0040", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Axe_Bash_Black_Right_Execute", "weapons_1_0041", "weapons_1_0042", "weapons_1_0043", "weapons_1_0044", "weapons_1_0045", "weapons_1_0055", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Axe_Stab_Black_Right_Charge", "weapons_1_0046", "weapons_1_0047", "weapons_1_0048", "weapons_1_0049", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Axe_Stab_Black_Right_Execute", "weapons_1_0050", "weapons_1_0051", "weapons_1_0052", "weapons_1_0053", "weapons_1_0054", "weapons_1_0055", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Axe_Ready_Black_Right", "weapons_1_0055", "", "", "", "", "", "", "", 1, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Mace_Slash_Black_Right_Charge", "weapons_1_0056", "weapons_1_0057", "weapons_1_0058", "weapons_1_0059", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Mace_Slash_Black_Right_Execute", "weapons_1_0060", "weapons_1_0061", "weapons_1_0062", "weapons_1_0063", "weapons_1_0064", "weapons_1_0083", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Mace_Bash_Black_Right_Charge", "weapons_1_0065", "weapons_1_0066", "weapons_1_0067", "weapons_1_0068", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Mace_Bash_Black_Right_Execute", "weapons_1_0069", "weapons_1_0070", "weapons_1_0071", "weapons_1_0072", "weapons_1_0073", "weapons_1_0083", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Mace_Stab_Black_Right_Charge", "weapons_1_0074", "weapons_1_0075", "weapons_1_0076", "weapons_1_0077", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Mace_Stab_Black_Right_Execute", "weapons_1_0078", "weapons_1_0079", "weapons_1_0080", "weapons_1_0081", "weapons_1_0082", "weapons_1_0083", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Mace_Ready_Black_Right", "weapons_1_0083", "", "", "", "", "", "", "", 1, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Fist_Slash_Black_Right_Charge", "weapons_1_0084", "weapons_1_0085", "weapons_1_0086", "weapons_1_0087", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Fist_Slash_Black_Right_Execute", "weapons_1_0088", "weapons_1_0089", "weapons_1_0090", "weapons_1_0091", "weapons_1_0092", "weapons_1_0111", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Fist_Bash_Black_Right_Charge", "weapons_1_0093", "weapons_1_0094", "weapons_1_0095", "weapons_1_0096", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Fist_Bash_Black_Right_Execute", "weapons_1_0097", "weapons_1_0098", "weapons_1_0099", "weapons_1_0100", "weapons_1_0101", "weapons_1_0111", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Fist_Stab_Black_Right_Charge", "weapons_1_0102", "weapons_1_0103", "weapons_1_0104", "weapons_1_0105", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Fist_Stab_Black_Right_Execute", "weapons_1_0106", "weapons_1_0107", "weapons_1_0108", "weapons_1_0109", "weapons_1_0110", "weapons_1_0111", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Fist_Ready_Black_Right", "weapons_1_0111", "", "", "", "", "", "", "", 1, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Sword_Slash_Black_Left_Charge", "weapons_1_0112", "weapons_1_0113", "weapons_1_0114", "weapons_1_0115", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Sword_Slash_Black_Left_Execute", "weapons_1_0116", "weapons_1_0117", "weapons_1_0118", "weapons_1_0119", "weapons_1_0120", "weapons_1_0139", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Sword_Bash_Black_Left_Charge", "weapons_1_0121", "weapons_1_0122", "weapons_1_0123", "weapons_1_0124", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Sword_Bash_Black_Left_Execute", "weapons_1_0125", "weapons_1_0126", "weapons_1_0127", "weapons_1_0128", "weapons_1_0129", "weapons_1_0139", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Sword_Stab_Black_Left_Charge", "weapons_1_0130", "weapons_1_0131", "weapons_1_0132", "weapons_1_0133", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Sword_Stab_Black_Left_Execute", "weapons_1_0134", "weapons_1_0135", "weapons_1_0136", "weapons_1_0137", "weapons_1_0138", "weapons_1_0139", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Sword_Ready_Black_Left", "weapons_1_0139", "", "", "", "", "", "", "", 1, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Axe_Slash_Black_Left_Charge", "weapons_1_0140", "weapons_1_0141", "weapons_1_0142", "weapons_1_0143", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Axe_Slash_Black_Left_Execute", "weapons_1_0144", "weapons_1_0145", "weapons_1_0146", "weapons_1_0147", "weapons_1_0148", "weapons_1_0167", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Axe_Bash_Black_Left_Charge", "weapons_1_0149", "weapons_1_0150", "weapons_1_0151", "weapons_1_0152", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Axe_Bash_Black_Left_Execute", "weapons_1_0153", "weapons_1_0154", "weapons_1_0155", "weapons_1_0156", "weapons_1_0157", "weapons_1_0167", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Axe_Stab_Black_Left_Charge", "weapons_1_0158", "weapons_1_0159", "weapons_1_0160", "weapons_1_0161", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Axe_Stab_Black_Left_Execute", "weapons_1_0162", "weapons_1_0163", "weapons_1_0164", "weapons_1_0165", "weapons_1_0166", "weapons_1_0167", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Axe_Ready_Black_Left", "weapons_1_0167", "", "", "", "", "", "", "", 1, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Mace_Slash_Black_Left_Charge", "weapons_1_0168", "weapons_1_0169", "weapons_1_0170", "weapons_1_0171", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Mace_Slash_Black_Left_Execute", "weapons_1_0172", "weapons_1_0173", "weapons_1_0174", "weapons_1_0175", "weapons_1_0176", "weapons_1_0195", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Mace_Bash_Black_Left_Charge", "weapons_1_0177", "weapons_1_0178", "weapons_1_0179", "weapons_1_0180", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Mace_Bash_Black_Left_Execute", "weapons_1_0181", "weapons_1_0182", "weapons_1_0183", "weapons_1_0184", "weapons_1_0185", "weapons_1_0195", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Mace_Stab_Black_Left_Charge", "weapons_1_0186", "weapons_1_0187", "weapons_1_0188", "weapons_1_0189", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Mace_Stab_Black_Left_Execute", "weapons_1_0190", "weapons_1_0191", "weapons_1_0192", "weapons_1_0193", "weapons_1_0194", "weapons_1_0195", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Mace_Ready_Black_Left", "weapons_1_0195", "", "", "", "", "", "", "", 1, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Fist_Slash_Black_Left_Charge", "weapons_1_0196", "weapons_1_0197", "weapons_1_0198", "weapons_1_0199", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Fist_Slash_Black_Left_Execute", "weapons_1_0200", "weapons_1_0201", "weapons_1_0202", "weapons_1_0203", "weapons_1_0204", "weapons_1_0223", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Fist_Bash_Black_Left_Charge", "weapons_1_0205", "weapons_1_0206", "weapons_1_0207", "weapons_1_0208", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Fist_Bash_Black_Left_Execute", "weapons_1_0209", "weapons_1_0210", "weapons_1_0211", "weapons_1_0212", "weapons_1_0213", "weapons_1_0223", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Fist_Stab_Black_Left_Charge", "weapons_1_0214", "weapons_1_0215", "weapons_1_0216", "weapons_1_0217", "", "", "", "", 4, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Fist_Stab_Black_Left_Execute", "weapons_1_0218", "weapons_1_0219", "weapons_1_0220", "weapons_1_0221", "weapons_1_0222", "weapons_1_0223", "", "", 6, "hud/weapons", 0.25f, false);
		CreateAnimationUI("Fist_Ready_Black_Left", "weapons_1_0223", "", "", "", "", "", "", "", 1, "hud/weapons", 0.25f, false);



		return;
				*/
	}

	[MenuItem("MyTools/CreateGraveCuts")]
	static void CreateCutsGraves()
		{return;
		for (int i =0; i<34; i++)
		{
			string[] Frame={"cs401_n01_00" + i.ToString ("D2")};
			CreateAnimationAsset (Frame[0],"Cuts", Frame,1,5.0f,false,true);
		}
	}
	[MenuItem("MyTools/CreateBigCutscenes")]
	static void CreateCutsBig()
		{return;
		string[] strAnimArray_cs000_n01 = {	"cs000_n01_0000",
			"cs000_n01_0001",		
			"cs000_n01_0002",		
			"cs000_n01_0003",		
			"cs000_n01_0004",		
			"cs000_n01_0005"};		CreateAnimationAsset ("cs000_n01" ,"cuts", strAnimArray_cs000_n01,strAnimArray_cs000_n01.GetUpperBound(0),0.2f,false,true);
		
		string[] strAnimArray_cs000_n02 = {	"cs000_n02_0000",		
			"cs000_n02_0001",		
			"cs000_n02_0002",		
			"cs000_n02_0003",		
			"cs000_n02_0004",		
			"cs000_n02_0005",		
			"cs000_n02_0006",		
			"cs000_n02_0007",		
			"cs000_n02_0008",		
			"cs000_n02_0009",		
			"cs000_n02_0010",		
			"cs000_n02_0011",		
			"cs000_n02_0012",		
			"cs000_n02_0013",		
			"cs000_n02_0014",		
			"cs000_n02_0015",		
			"cs000_n02_0016",		
			"cs000_n02_0017",		
			"cs000_n02_0018",		
			"cs000_n02_0019",		
			"cs000_n02_0020"};		CreateAnimationAsset ("cs000_n02" ,"cuts", strAnimArray_cs000_n02,strAnimArray_cs000_n02.GetUpperBound(0),0.2f,false,true);
		
		string[] strAnimArray_cs000_n03 = {	"cs000_n03_0000",		
			"cs000_n03_0001",		
			"cs000_n03_0002",		
			"cs000_n03_0003",		
			"cs000_n03_0004",		
			"cs000_n03_0005",		
			"cs000_n03_0006",		
			"cs000_n03_0007",		
			"cs000_n03_0008",		
			"cs000_n03_0009",		
			"cs000_n03_0010",		
			"cs000_n03_0011",		
			"cs000_n03_0012",		
			"cs000_n03_0013"};		CreateAnimationAsset ("cs000_n03" ,"cuts", strAnimArray_cs000_n03,strAnimArray_cs000_n03.GetUpperBound(0),0.2f,false,true);
		
		string[] strAnimArray_cs000_n04 = {	"cs000_n04_0000",		
			"cs000_n04_0001",		
			"cs000_n04_0002",		
			"cs000_n04_0003",		
			"cs000_n04_0004",		
			"cs000_n04_0005",		
			"cs000_n04_0006",		
			"cs000_n04_0007",		
			"cs000_n04_0008",		
			"cs000_n04_0009",		
			"cs000_n04_0010",		
			"cs000_n04_0011",		
			"cs000_n04_0012",		
			"cs000_n04_0013",		
			"cs000_n04_0014",		
			"cs000_n04_0015",		
			"cs000_n04_0016",		
			"cs000_n04_0017",		
			"cs000_n04_0018",		
			"cs000_n04_0019",		
			"cs000_n04_0020",		
			"cs000_n04_0021"};		CreateAnimationAsset ("cs000_n04" ,"cuts", strAnimArray_cs000_n04,strAnimArray_cs000_n04.GetUpperBound(0),0.2f,false,true);
		
		string[] strAnimArray_cs000_n05 = {	"cs000_n05_0000",		
			"cs000_n05_0001",		
			"cs000_n05_0002",		
			"cs000_n05_0003",		
			"cs000_n05_0004",		
			"cs000_n05_0005",		
			"cs000_n05_0006",		
			"cs000_n05_0007",		
			"cs000_n05_0008",		
			"cs000_n05_0009",		
			"cs000_n05_0010",		
			"cs000_n05_0011",		
			"cs000_n05_0012",		
			"cs000_n05_0013",		
			"cs000_n05_0014",		
			"cs000_n05_0015",		
			"cs000_n05_0016",		
			"cs000_n05_0017",		
			"cs000_n05_0018",		
			"cs000_n05_0019",		
			"cs000_n05_0020",		
			"cs000_n05_0021",		
			"cs000_n05_0022",		
			"cs000_n05_0023",		
			"cs000_n05_0024",		
			"cs000_n05_0025",		
			"cs000_n05_0026",		
			"cs000_n05_0027",		
			"cs000_n05_0028",		
			"cs000_n05_0029"};		CreateAnimationAsset ("cs000_n05" ,"cuts", strAnimArray_cs000_n05,strAnimArray_cs000_n05.GetUpperBound(0),0.2f,false,true);
		
		string[] strAnimArray_cs000_n06 = {	"cs000_n06_0000",		
			"cs000_n06_0001",		
			"cs000_n06_0002",		
			"cs000_n06_0003",		
			"cs000_n06_0004"};		CreateAnimationAsset ("cs000_n06" ,"cuts", strAnimArray_cs000_n06,strAnimArray_cs000_n06.GetUpperBound(0),0.2f,false,true);
		
		string[] strAnimArray_cs000_n07 = {	"cs000_n07_0000",		
			"cs000_n07_0001",		
			"cs000_n07_0002",		
			"cs000_n07_0003",		
			"cs000_n07_0004",		
			"cs000_n07_0005",		
			"cs000_n07_0006",		
			"cs000_n07_0007",		
			"cs000_n07_0008",		
			"cs000_n07_0009",		
			"cs000_n07_0010",		
			"cs000_n07_0011",		
			"cs000_n07_0012",		
			"cs000_n07_0013",		
			"cs000_n07_0014",		
			"cs000_n07_0015",		
			"cs000_n07_0016",		
			"cs000_n07_0017",		
			"cs000_n07_0018",		
			"cs000_n07_0019",		
			"cs000_n07_0020",		
			"cs000_n07_0021",		
			"cs000_n07_0022",		
			"cs000_n07_0023"};		CreateAnimationAsset ("cs000_n07" ,"cuts", strAnimArray_cs000_n07,strAnimArray_cs000_n07.GetUpperBound(0),0.2f,false,true);
		
		string[] strAnimArray_cs000_n10 = {	"cs000_n10_0000",		
			"cs000_n10_0001",		
			"cs000_n10_0002",		
			"cs000_n10_0003",		
			"cs000_n10_0004",		
			"cs000_n10_0005",		
			"cs000_n10_0006",		
			"cs000_n10_0007",		
			"cs000_n10_0008",		
			"cs000_n10_0009",		
			"cs000_n10_0010",		
			"cs000_n10_0011",		
			"cs000_n10_0012",		
			"cs000_n10_0013",		
			"cs000_n10_0014",		
			"cs000_n10_0015",		
			"cs000_n10_0016",		
			"cs000_n10_0017",		
			"cs000_n10_0018",		
			"cs000_n10_0019",		
			"cs000_n10_0020",		
			"cs000_n10_0021",		
			"cs000_n10_0022",		
			"cs000_n10_0023",		
			"cs000_n10_0024",		
			"cs000_n10_0025",		
			"cs000_n10_0026",		
			"cs000_n10_0027",		
			"cs000_n10_0028",		
			"cs000_n10_0029",		
			"cs000_n10_0030",		
			"cs000_n10_0031",		
			"cs000_n10_0032",		
			"cs000_n10_0033",		
			"cs000_n10_0034",		
			"cs000_n10_0035",		
			"cs000_n10_0036",		
			"cs000_n10_0037",		
			"cs000_n10_0038",		
			"cs000_n10_0039",		
			"cs000_n10_0040",		
			"cs000_n10_0041",		
			"cs000_n10_0042",		
			"cs000_n10_0043",		
			"cs000_n10_0044",		
			"cs000_n10_0045",		
			"cs000_n10_0046",		
			"cs000_n10_0047",		
			"cs000_n10_0048",		
			"cs000_n10_0049",		
			"cs000_n10_0050",		
			"cs000_n10_0051",		
			"cs000_n10_0052",		
			"cs000_n10_0053",		
			"cs000_n10_0054",		
			"cs000_n10_0055",		
			"cs000_n10_0056",		
			"cs000_n10_0057",		
			"cs000_n10_0058",		
			"cs000_n10_0059",		
			"cs000_n10_0060",		
			"cs000_n10_0061",		
			"cs000_n10_0062",		
			"cs000_n10_0063",		
			"cs000_n10_0064",		
			"cs000_n10_0065",		
			"cs000_n10_0066",		
			"cs000_n10_0067",		
			"cs000_n10_0068",		
			"cs000_n10_0069",		
			"cs000_n10_0070",		
			"cs000_n10_0071",		
			"cs000_n10_0072",		
			"cs000_n10_0073",		
			"cs000_n10_0074",		
			"cs000_n10_0075",		
			"cs000_n10_0076",		
			"cs000_n10_0077",		
			"cs000_n10_0078",		
			"cs000_n10_0079",		
			"cs000_n10_0080",		
			"cs000_n10_0081",		
			"cs000_n10_0082",		
			"cs000_n10_0083",		
			"cs000_n10_0084",		
			"cs000_n10_0085",		
			"cs000_n10_0086",		
			"cs000_n10_0087",		
			"cs000_n10_0088",		
			"cs000_n10_0089",		
			"cs000_n10_0090",		
			"cs000_n10_0091",		
			"cs000_n10_0092",		
			"cs000_n10_0093",		
			"cs000_n10_0094",		
			"cs000_n10_0095",		
			"cs000_n10_0096",		
			"cs000_n10_0097",		
			"cs000_n10_0098",		
			"cs000_n10_0099",		
			"cs000_n10_0100",		
			"cs000_n10_0101",		
			"cs000_n10_0102",		
			"cs000_n10_0103",		
			"cs000_n10_0104",		
			"cs000_n10_0105",		
			"cs000_n10_0106",		
			"cs000_n10_0107",		
			"cs000_n10_0108",		
			"cs000_n10_0109",		
			"cs000_n10_0110",		
			"cs000_n10_0111",		
			"cs000_n10_0112",		
			"cs000_n10_0113",		
			"cs000_n10_0114",		
			"cs000_n10_0115",		
			"cs000_n10_0116",		
			"cs000_n10_0117",		
			"cs000_n10_0118",		
			"cs000_n10_0119",		
			"cs000_n10_0120",		
			"cs000_n10_0121",		
			"cs000_n10_0122",		
			"cs000_n10_0123",		
			"cs000_n10_0124",		
			"cs000_n10_0125",		
			"cs000_n10_0126",		
			"cs000_n10_0127",		
			"cs000_n10_0128",		
			"cs000_n10_0129",		
			"cs000_n10_0130",		
			"cs000_n10_0131",		
			"cs000_n10_0132",		
			"cs000_n10_0133",		
			"cs000_n10_0134"};		CreateAnimationAsset ("cs000_n10" ,"cuts", strAnimArray_cs000_n10,strAnimArray_cs000_n10.GetUpperBound(0),0.2f,false,true);
		
		string[] strAnimArray_cs000_n11 = {	"cs000_n11_0000",		
			"cs000_n11_0001",		
			"cs000_n11_0002",		
			"cs000_n11_0003",		
			"cs000_n11_0004",		
			"cs000_n11_0005",		
			"cs000_n11_0006",		
			"cs000_n11_0007",		
			"cs000_n11_0008",		
			"cs000_n11_0009",		
			"cs000_n11_0010",		
			"cs000_n11_0011",		
			"cs000_n11_0012",		
			"cs000_n11_0013"};		CreateAnimationAsset ("cs000_n11" ,"cuts", strAnimArray_cs000_n11,strAnimArray_cs000_n11.GetUpperBound(0),0.2f,false,true);
		
		string[] strAnimArray_cs000_n12 = {	"cs000_n12_0000",		
			"cs000_n12_0001",		
			"cs000_n12_0002",		
			"cs000_n12_0003",		
			"cs000_n12_0004",		
			"cs000_n12_0005",		
			"cs000_n12_0006",		
			"cs000_n12_0007",		
			"cs000_n12_0008",		
			"cs000_n12_0009",		
			"cs000_n12_0010",		
			"cs000_n12_0011",		
			"cs000_n12_0012",		
			"cs000_n12_0013"};		CreateAnimationAsset ("cs000_n12" ,"cuts", strAnimArray_cs000_n12,strAnimArray_cs000_n12.GetUpperBound(0),0.2f,false,true);
		
		string[] strAnimArray_cs000_n15 = {	"cs000_n15_0000",		
			"cs000_n15_0001",		
			"cs000_n15_0002",		
			"cs000_n15_0003",		
			"cs000_n15_0004",		
			"cs000_n15_0005",		
			"cs000_n15_0006",		
			"cs000_n15_0007",		
			"cs000_n15_0008",		
			"cs000_n15_0009",		
			"cs000_n15_0010",		
			"cs000_n15_0011",		
			"cs000_n15_0012",		
			"cs000_n15_0013"};		CreateAnimationAsset ("cs000_n15" ,"cuts", strAnimArray_cs000_n15,strAnimArray_cs000_n15.GetUpperBound(0),0.2f,false,true);
		
		string[] strAnimArray_cs000_n16 = {	"cs000_n16_0000",		
			"cs000_n16_0001",		
			"cs000_n16_0002",		
			"cs000_n16_0003",		
			"cs000_n16_0004",		
			"cs000_n16_0005",		
			"cs000_n16_0006",		
			"cs000_n16_0007",		
			"cs000_n16_0008",		
			"cs000_n16_0009",		
			"cs000_n16_0010",		
			"cs000_n16_0011",		
			"cs000_n16_0012",		
			"cs000_n16_0013",		
			"cs000_n16_0014",		
			"cs000_n16_0015",		
			"cs000_n16_0016",		
			"cs000_n16_0017",		
			"cs000_n16_0018",		
			"cs000_n16_0019",		
			"cs000_n16_0020",		
			"cs000_n16_0021"};		CreateAnimationAsset ("cs000_n16" ,"cuts", strAnimArray_cs000_n16,strAnimArray_cs000_n16.GetUpperBound(0),0.2f,false,true);
		
		string[] strAnimArray_cs000_n17 = {	"cs000_n17_0000",		
			"cs000_n17_0001",		
			"cs000_n17_0002",		
			"cs000_n17_0003",		
			"cs000_n17_0004",		
			"cs000_n17_0005",		
			"cs000_n17_0006",		
			"cs000_n17_0007",		
			"cs000_n17_0008",		
			"cs000_n17_0009",		
			"cs000_n17_0010",		
			"cs000_n17_0011",		
			"cs000_n17_0012",		
			"cs000_n17_0013",		
			"cs000_n17_0014",		
			"cs000_n17_0015",		
			"cs000_n17_0016",		
			"cs000_n17_0017",		
			"cs000_n17_0018",		
			"cs000_n17_0019",		
			"cs000_n17_0020",		
			"cs000_n17_0021",		
			"cs000_n17_0022",		
			"cs000_n17_0023",		
			"cs000_n17_0024",		
			"cs000_n17_0025",		
			"cs000_n17_0026",		
			"cs000_n17_0027",		
			"cs000_n17_0028",		
			"cs000_n17_0029"};		CreateAnimationAsset ("cs000_n17" ,"cuts", strAnimArray_cs000_n17,strAnimArray_cs000_n17.GetUpperBound(0),0.2f,false,true);
		
		string[] strAnimArray_cs000_n20 = {	"cs000_n20_0000",		
			"cs000_n20_0001",		
			"cs000_n20_0002",		
			"cs000_n20_0003",		
			"cs000_n20_0004",		
			"cs000_n20_0005",		
			"cs000_n20_0006",		
			"cs000_n20_0007",		
			"cs000_n20_0008",		
			"cs000_n20_0009",		
			"cs000_n20_0010",		
			"cs000_n20_0011",		
			"cs000_n20_0012",		
			"cs000_n20_0013",		
			"cs000_n20_0014",		
			"cs000_n20_0015",		
			"cs000_n20_0016",		
			"cs000_n20_0017",		
			"cs000_n20_0018",		
			"cs000_n20_0019",		
			"cs000_n20_0020",		
			"cs000_n20_0021",		
			"cs000_n20_0022",		
			"cs000_n20_0023",		
			"cs000_n20_0024",		
			"cs000_n20_0025",		
			"cs000_n20_0026",		
			"cs000_n20_0027",		
			"cs000_n20_0028",		
			"cs000_n20_0029",		
			"cs000_n20_0030",		
			"cs000_n20_0031",		
			"cs000_n20_0032",		
			"cs000_n20_0033",		
			"cs000_n20_0034",		
			"cs000_n20_0035",		
			"cs000_n20_0036",		
			"cs000_n20_0037",		
			"cs000_n20_0038",		
			"cs000_n20_0039",		
			"cs000_n20_0040",		
			"cs000_n20_0041"};		CreateAnimationAsset ("cs000_n20" ,"cuts", strAnimArray_cs000_n20,strAnimArray_cs000_n20.GetUpperBound(0),0.2f,false,true);
		
		string[] strAnimArray_cs000_n21 = {	"cs000_n21_0000",		
			"cs000_n21_0001",		
			"cs000_n21_0002",		
			"cs000_n21_0003",		
			"cs000_n21_0004",		
			"cs000_n21_0005",		
			"cs000_n21_0006",		
			"cs000_n21_0007",		
			"cs000_n21_0008",		
			"cs000_n21_0009",		
			"cs000_n21_0010",		
			"cs000_n21_0011",		
			"cs000_n21_0012",		
			"cs000_n21_0013",		
			"cs000_n21_0014",		
			"cs000_n21_0015",		
			"cs000_n21_0016",		
			"cs000_n21_0017",		
			"cs000_n21_0018",		
			"cs000_n21_0019",		
			"cs000_n21_0020",		
			"cs000_n21_0021",		
			"cs000_n21_0022",		
			"cs000_n21_0023",		
			"cs000_n21_0024",		
			"cs000_n21_0025",		
			"cs000_n21_0026",		
			"cs000_n21_0027",		
			"cs000_n21_0028",		
			"cs000_n21_0029",		
			"cs000_n21_0030",		
			"cs000_n21_0031",		
			"cs000_n21_0032",		
			"cs000_n21_0033",		
			"cs000_n21_0034",		
			"cs000_n21_0035",		
			"cs000_n21_0036",		
			"cs000_n21_0037",		
			"cs000_n21_0038",		
			"cs000_n21_0039",		
			"cs000_n21_0040",		
			"cs000_n21_0041"};		CreateAnimationAsset ("cs000_n21" ,"cuts", strAnimArray_cs000_n21,strAnimArray_cs000_n21.GetUpperBound(0),0.2f,false,true);
		
		string[] strAnimArray_cs000_n22 = {	"cs000_n22_0000",		
			"cs000_n22_0001",		
			"cs000_n22_0002",		
			"cs000_n22_0003",		
			"cs000_n22_0004",		
			"cs000_n22_0005",		
			"cs000_n22_0006",		
			"cs000_n22_0007",		
			"cs000_n22_0008",		
			"cs000_n22_0009",		
			"cs000_n22_0010"};		CreateAnimationAsset ("cs000_n22" ,"cuts", strAnimArray_cs000_n22,strAnimArray_cs000_n22.GetUpperBound(0),0.2f,false,true);
		
		string[] strAnimArray_cs000_n23 = {	"cs000_n23_0000",		
			"cs000_n23_0001",		
			"cs000_n23_0002",		
			"cs000_n23_0003",		
			"cs000_n23_0004",		
			"cs000_n23_0005",		
			"cs000_n23_0006",		
			"cs000_n23_0007",		
			"cs000_n23_0008",		
			"cs000_n23_0009",		
			"cs000_n23_0010",		
			"cs000_n23_0011"};		CreateAnimationAsset ("cs000_n23" ,"cuts", strAnimArray_cs000_n23,strAnimArray_cs000_n23.GetUpperBound(0),0.2f,false,true);
		
		string[] strAnimArray_cs000_n24 = {	"cs000_n24_0000",		
			"cs000_n24_0001",		
			"cs000_n24_0002",		
			"cs000_n24_0003",		
			"cs000_n24_0004",		
			"cs000_n24_0005",		
			"cs000_n24_0006",		
			"cs000_n24_0007",		
			"cs000_n24_0008",		
			"cs000_n24_0009",		
			"cs000_n24_0010",		
			"cs000_n24_0011",		
			"cs000_n24_0012",		
			"cs000_n24_0013",		
			"cs000_n24_0014",		
			"cs000_n24_0015",		
			"cs000_n24_0016",		
			"cs000_n24_0017",		
			"cs000_n24_0018",		
			"cs000_n24_0019",		
			"cs000_n24_0020",		
			"cs000_n24_0021"};		CreateAnimationAsset ("cs000_n24" ,"cuts", strAnimArray_cs000_n24,strAnimArray_cs000_n24.GetUpperBound(0),0.2f,false,true);
		
		string[] strAnimArray_cs000_n25 = {	"cs000_n25_0000",		
			"cs000_n25_0001",		
			"cs000_n25_0002",		
			"cs000_n25_0003",		
			"cs000_n25_0004",		
			"cs000_n25_0005",		
			"cs000_n25_0006",		
			"cs000_n25_0007",		
			"cs000_n25_0008",		
			"cs000_n25_0009",		
			"cs000_n25_0010",		
			"cs000_n25_0011",		
			"cs000_n25_0012",		
			"cs000_n25_0013",		
			"cs000_n25_0014",		
			"cs000_n25_0015",		
			"cs000_n25_0016",		
			"cs000_n25_0017",		
			"cs000_n25_0018",		
			"cs000_n25_0019",		
			"cs000_n25_0020",		
			"cs000_n25_0021",		
			"cs000_n25_0022",		
			"cs000_n25_0023",		
			"cs000_n25_0024",		
			"cs000_n25_0025",		
			"cs000_n25_0026",		
			"cs000_n25_0027",		
			"cs000_n25_0028",		
			"cs000_n25_0029"};		CreateAnimationAsset ("cs000_n25" ,"cuts", strAnimArray_cs000_n25,strAnimArray_cs000_n25.GetUpperBound(0),0.2f,false,true);
		
		string[] strAnimArray_cs001_n01 = {	"cs001_n01_0000",		
			"cs001_n01_0001",		
			"cs001_n01_0002",		
			"cs001_n01_0003",		
			"cs001_n01_0004",		
			"cs001_n01_0005",		
			"cs001_n01_0006",		
			"cs001_n01_0007",		
			"cs001_n01_0008",		
			"cs001_n01_0009",		
			"cs001_n01_0010",		
			"cs001_n01_0011",		
			"cs001_n01_0012",		
			"cs001_n01_0013",		
			"cs001_n01_0014",		
			"cs001_n01_0015",		
			"cs001_n01_0016",		
			"cs001_n01_0017",		
			"cs001_n01_0018",		
			"cs001_n01_0019",		
			"cs001_n01_0020",		
			"cs001_n01_0021",		
			"cs001_n01_0022",		
			"cs001_n01_0023",		
			"cs001_n01_0024",		
			"cs001_n01_0025",		
			"cs001_n01_0026",		
			"cs001_n01_0027",		
			"cs001_n01_0028",		
			"cs001_n01_0029",		
			"cs001_n01_0030"};		CreateAnimationAsset ("cs001_n01" ,"cuts", strAnimArray_cs001_n01,strAnimArray_cs001_n01.GetUpperBound(0),0.2f,false,true);
		
		string[] strAnimArray_cs001_n02 = {	"cs001_n02_0000",		
			"cs001_n02_0001",		
			"cs001_n02_0002",		
			"cs001_n02_0003",		
			"cs001_n02_0004",		
			"cs001_n02_0005",		
			"cs001_n02_0006",		
			"cs001_n02_0007",		
			"cs001_n02_0008",		
			"cs001_n02_0009",		
			"cs001_n02_0010",		
			"cs001_n02_0011",		
			"cs001_n02_0012",		
			"cs001_n02_0013",		
			"cs001_n02_0014",		
			"cs001_n02_0015",		
			"cs001_n02_0016",		
			"cs001_n02_0017",		
			"cs001_n02_0018",		
			"cs001_n02_0019",		
			"cs001_n02_0020",		
			"cs001_n02_0021",		
			"cs001_n02_0022",		
			"cs001_n02_0023",		
			"cs001_n02_0024",		
			"cs001_n02_0025",		
			"cs001_n02_0026",		
			"cs001_n02_0027",		
			"cs001_n02_0028",		
			"cs001_n02_0029",		
			"cs001_n02_0030",		
			"cs001_n02_0031",		
			"cs001_n02_0032",		
			"cs001_n02_0033",		
			"cs001_n02_0034",		
			"cs001_n02_0035",		
			"cs001_n02_0036",		
			"cs001_n02_0037",		
			"cs001_n02_0038",		
			"cs001_n02_0039"};		CreateAnimationAsset ("cs001_n02" ,"cuts", strAnimArray_cs001_n02,strAnimArray_cs001_n02.GetUpperBound(0),0.2f,false,true);
		
		string[] strAnimArray_cs001_n03 = {	"cs001_n03_0000",		
			"cs001_n03_0001",		
			"cs001_n03_0002",		
			"cs001_n03_0003",		
			"cs001_n03_0004",		
			"cs001_n03_0005",		
			"cs001_n03_0006",		
			"cs001_n03_0007",		
			"cs001_n03_0008",		
			"cs001_n03_0009",		
			"cs001_n03_0010",		
			"cs001_n03_0011",		
			"cs001_n03_0012",		
			"cs001_n03_0013",		
			"cs001_n03_0014",		
			"cs001_n03_0015",		
			"cs001_n03_0016",		
			"cs001_n03_0017",		
			"cs001_n03_0018",		
			"cs001_n03_0019",		
			"cs001_n03_0020",		
			"cs001_n03_0021"};		CreateAnimationAsset ("cs001_n03" ,"cuts", strAnimArray_cs001_n03,strAnimArray_cs001_n03.GetUpperBound(0),0.2f,false,true);
		
		string[] strAnimArray_cs001_n04 = {	"cs001_n04_0000",		
			"cs001_n04_0001",		
			"cs001_n04_0002",		
			"cs001_n04_0003",		
			"cs001_n04_0004",		
			"cs001_n04_0005",		
			"cs001_n04_0006",		
			"cs001_n04_0007",		
			"cs001_n04_0008",		
			"cs001_n04_0009",		
			"cs001_n04_0010",		
			"cs001_n04_0011",		
			"cs001_n04_0012",		
			"cs001_n04_0013",		
			"cs001_n04_0014",		
			"cs001_n04_0015",		
			"cs001_n04_0016",		
			"cs001_n04_0017",		
			"cs001_n04_0018",		
			"cs001_n04_0019",		
			"cs001_n04_0020",		
			"cs001_n04_0021",		
			"cs001_n04_0022",		
			"cs001_n04_0023",		
			"cs001_n04_0024",		
			"cs001_n04_0025",		
			"cs001_n04_0026",		
			"cs001_n04_0027",		
			"cs001_n04_0028",		
			"cs001_n04_0029"};		CreateAnimationAsset ("cs001_n04" ,"cuts", strAnimArray_cs001_n04,strAnimArray_cs001_n04.GetUpperBound(0),0.2f,false,true);
		
		string[] strAnimArray_cs001_n05 = {	"cs001_n05_0000",		
			"cs001_n05_0001",		
			"cs001_n05_0002",		
			"cs001_n05_0003",		
			"cs001_n05_0004",		
			"cs001_n05_0005",		
			"cs001_n05_0006",		
			"cs001_n05_0007",		
			"cs001_n05_0008",		
			"cs001_n05_0009",		
			"cs001_n05_0010",		
			"cs001_n05_0011",		
			"cs001_n05_0012",		
			"cs001_n05_0013",		
			"cs001_n05_0014",		
			"cs001_n05_0015",		
			"cs001_n05_0016",		
			"cs001_n05_0017",		
			"cs001_n05_0018",		
			"cs001_n05_0019",		
			"cs001_n05_0020",		
			"cs001_n05_0021",		
			"cs001_n05_0022",		
			"cs001_n05_0023",		
			"cs001_n05_0024",		
			"cs001_n05_0025",		
			"cs001_n05_0026",		
			"cs001_n05_0027",		
			"cs001_n05_0028",		
			"cs001_n05_0029",		
			"cs001_n05_0030",		
			"cs001_n05_0031",		
			"cs001_n05_0032",		
			"cs001_n05_0033",		
			"cs001_n05_0034",		
			"cs001_n05_0035",		
			"cs001_n05_0036",		
			"cs001_n05_0037",		
			"cs001_n05_0038",		
			"cs001_n05_0039",		
			"cs001_n05_0040",		
			"cs001_n05_0041",		
			"cs001_n05_0042",		
			"cs001_n05_0043",		
			"cs001_n05_0044",		
			"cs001_n05_0045",		
			"cs001_n05_0046",		
			"cs001_n05_0047",		
			"cs001_n05_0048",		
			"cs001_n05_0049",		
			"cs001_n05_0050"};		CreateAnimationAsset ("cs001_n05" ,"cuts", strAnimArray_cs001_n05,strAnimArray_cs001_n05.GetUpperBound(0),0.2f,false,true);
		
		string[] strAnimArray_cs001_n06 = {	"cs001_n06_0000",		
		"cs001_n06_0001",		
		"cs001_n06_0002",		
		"cs001_n06_0003",		
		"cs001_n06_0004",		
		"cs001_n06_0005",		
		"cs001_n06_0006",		
		"cs001_n06_0007",		
		"cs001_n06_0008",		
		"cs001_n06_0009",		
		"cs001_n06_0010",		
		"cs001_n06_0011",		
		"cs001_n06_0012",		
		"cs001_n06_0013",		
		"cs001_n06_0014",		
		"cs001_n06_0015",		
		"cs001_n06_0016",		
		"cs001_n06_0017",		
		"cs001_n06_0018",		
		"cs001_n06_0019",		
		"cs001_n06_0020",		
		"cs001_n06_0021"};		CreateAnimationAsset ("cs001_n06" ,"cuts", strAnimArray_cs001_n06,strAnimArray_cs001_n06.GetUpperBound(0),0.2f,false,true);
	
	string[] strAnimArray_cs001_n07 = {	"cs001_n07_0000",		
		"cs001_n07_0001",		
		"cs001_n07_0002",		
		"cs001_n07_0003",		
		"cs001_n07_0004",		
		"cs001_n07_0005",		
		"cs001_n07_0006",		
		"cs001_n07_0007",		
		"cs001_n07_0008",		
		"cs001_n07_0009",		
		"cs001_n07_0010",		
		"cs001_n07_0011",		
		"cs001_n07_0012",		
		"cs001_n07_0013",		
		"cs001_n07_0014",		
		"cs001_n07_0015",		
		"cs001_n07_0016",		
		"cs001_n07_0017",		
		"cs001_n07_0018",		
		"cs001_n07_0019",		
		"cs001_n07_0020",		
		"cs001_n07_0021",		
		"cs001_n07_0022",		
		"cs001_n07_0023",		
		"cs001_n07_0024",		
		"cs001_n07_0025",		
		"cs001_n07_0026",		
		"cs001_n07_0027",		
		"cs001_n07_0028",		
		"cs001_n07_0029"};		CreateAnimationAsset ("cs001_n07" ,"cuts", strAnimArray_cs001_n07,strAnimArray_cs001_n07.GetUpperBound(0),0.2f,false,true);
	
	string[] strAnimArray_cs001_n10 = {	"cs001_n10_0000",		
		"cs001_n10_0001",		
		"cs001_n10_0002",		
		"cs001_n10_0003",		
		"cs001_n10_0004",		
		"cs001_n10_0005",		
		"cs001_n10_0006",		
		"cs001_n10_0007",		
		"cs001_n10_0008",		
		"cs001_n10_0009",		
		"cs001_n10_0010",		
		"cs001_n10_0011",		
		"cs001_n10_0012",		
		"cs001_n10_0013",		
		"cs001_n10_0014",		
		"cs001_n10_0015",		
		"cs001_n10_0016",		
		"cs001_n10_0017",		
		"cs001_n10_0018",		
		"cs001_n10_0019",		
		"cs001_n10_0020",		
		"cs001_n10_0021",		
		"cs001_n10_0022",		
		"cs001_n10_0023",		
		"cs001_n10_0024",		
		"cs001_n10_0025",		
		"cs001_n10_0026",		
		"cs001_n10_0027",		
		"cs001_n10_0028",		
		"cs001_n10_0029",		
		"cs001_n10_0030",		
		"cs001_n10_0031",		
		"cs001_n10_0032",		
		"cs001_n10_0033",		
		"cs001_n10_0034",		
		"cs001_n10_0035",		
		"cs001_n10_0036",		
		"cs001_n10_0037",		
		"cs001_n10_0038",		
		"cs001_n10_0039",		
		"cs001_n10_0040",		
		"cs001_n10_0041",		
		"cs001_n10_0042",		
		"cs001_n10_0043",		
		"cs001_n10_0044",		
		"cs001_n10_0045",		
		"cs001_n10_0046",		
		"cs001_n10_0047",		
		"cs001_n10_0048",		
		"cs001_n10_0049",		
		"cs001_n10_0050",		
		"cs001_n10_0051",		
		"cs001_n10_0052",		
		"cs001_n10_0053",		
		"cs001_n10_0054",		
		"cs001_n10_0055",		
		"cs001_n10_0056"};		CreateAnimationAsset ("cs001_n10" ,"cuts", strAnimArray_cs001_n10,strAnimArray_cs001_n10.GetUpperBound(0),0.2f,false,true);
	
	string[] strAnimArray_cs002_n01 = {	"cs002_n01_0000",		
		"cs002_n01_0001",		
		"cs002_n01_0002",		
		"cs002_n01_0003",		
		"cs002_n01_0004",		
		"cs002_n01_0005",		
		"cs002_n01_0006",		
		"cs002_n01_0007",		
		"cs002_n01_0008",		
		"cs002_n01_0009",		
		"cs002_n01_0010",		
		"cs002_n01_0011",		
		"cs002_n01_0012",		
		"cs002_n01_0013"};		CreateAnimationAsset ("cs002_n01" ,"cuts", strAnimArray_cs002_n01,strAnimArray_cs002_n01.GetUpperBound(0),0.2f,false,true);
	
	string[] strAnimArray_cs002_n02 = {	"cs002_n02_0000",		
		"cs002_n02_0001",		
		"cs002_n02_0002",		
		"cs002_n02_0003",		
		"cs002_n02_0004",		
		"cs002_n02_0005",		
		"cs002_n02_0006",		
		"cs002_n02_0007",		
		"cs002_n02_0008",		
		"cs002_n02_0009",		
		"cs002_n02_0010",		
		"cs002_n02_0011",		
		"cs002_n02_0012",		
		"cs002_n02_0013",		
		"cs002_n02_0014",		
		"cs002_n02_0015",		
		"cs002_n02_0016",		
		"cs002_n02_0017",		
		"cs002_n02_0018",		
		"cs002_n02_0019",		
		"cs002_n02_0020",		
		"cs002_n02_0021"};		CreateAnimationAsset ("cs002_n02" ,"cuts", strAnimArray_cs002_n02,strAnimArray_cs002_n02.GetUpperBound(0),0.2f,false,true);
	
	string[] strAnimArray_cs002_n03 = {	"cs002_n03_0000",		
		"cs002_n03_0001",		
		"cs002_n03_0002",		
		"cs002_n03_0003",		
		"cs002_n03_0004",		
		"cs002_n03_0005",		
		"cs002_n03_0006",		
		"cs002_n03_0007",		
		"cs002_n03_0008",		
		"cs002_n03_0009",		
		"cs002_n03_0010",		
		"cs002_n03_0011",		
		"cs002_n03_0012",		
		"cs002_n03_0013",		
		"cs002_n03_0014",		
		"cs002_n03_0015",		
		"cs002_n03_0016",		
		"cs002_n03_0017",		
		"cs002_n03_0018",		
		"cs002_n03_0019",		
		"cs002_n03_0020",		
		"cs002_n03_0021",		
		"cs002_n03_0022",		
		"cs002_n03_0023",		
		"cs002_n03_0024",		
		"cs002_n03_0025",		
		"cs002_n03_0026",		
		"cs002_n03_0027",		
		"cs002_n03_0028",		
		"cs002_n03_0029"};		CreateAnimationAsset ("cs002_n03" ,"cuts", strAnimArray_cs002_n03,strAnimArray_cs002_n03.GetUpperBound(0),0.2f,false,true);
	
	string[] strAnimArray_cs002_n04 = {	"cs002_n04_0000",		
		"cs002_n04_0001",		
		"cs002_n04_0002",		
		"cs002_n04_0003",		
		"cs002_n04_0004",		
		"cs002_n04_0005",		
		"cs002_n04_0006",		
		"cs002_n04_0007",		
		"cs002_n04_0008",		
		"cs002_n04_0009",		
		"cs002_n04_0010",		
		"cs002_n04_0011",		
		"cs002_n04_0012",		
		"cs002_n04_0013",		
		"cs002_n04_0014",		
		"cs002_n04_0015"};		CreateAnimationAsset ("cs002_n04" ,"cuts", strAnimArray_cs002_n04,strAnimArray_cs002_n04.GetUpperBound(0),0.2f,false,true);
	
	string[] strAnimArray_cs003_n01 = {	"cs003_n01_0000",		
		"cs003_n01_0001",		
		"cs003_n01_0002",		
		"cs003_n01_0003",		
		"cs003_n01_0004",		
		"cs003_n01_0005",		
		"cs003_n01_0006",		
		"cs003_n01_0007",		
		"cs003_n01_0008",		
		"cs003_n01_0009",		
		"cs003_n01_0010",		
		"cs003_n01_0011",		
		"cs003_n01_0012",		
		"cs003_n01_0013",		
		"cs003_n01_0014",		
		"cs003_n01_0015",		
		"cs003_n01_0016",		
		"cs003_n01_0017",		
		"cs003_n01_0018",		
		"cs003_n01_0019",		
		"cs003_n01_0020",		
		"cs003_n01_0021"};		CreateAnimationAsset ("cs003_n01" ,"cuts", strAnimArray_cs003_n01,strAnimArray_cs003_n01.GetUpperBound(0),0.2f,false,true);
	
	string[] strAnimArray_cs003_n02 = {	"cs003_n02_0000",		
		"cs003_n02_0001",		
		"cs003_n02_0002",		
		"cs003_n02_0003",		
		"cs003_n02_0004",		
		"cs003_n02_0005",		
		"cs003_n02_0006",		
		"cs003_n02_0007",		
		"cs003_n02_0008",		
		"cs003_n02_0009",		
		"cs003_n02_0010",		
		"cs003_n02_0011",		
		"cs003_n02_0012",		
		"cs003_n02_0013",		
		"cs003_n02_0014",		
		"cs003_n02_0015",		
		"cs003_n02_0016",		
		"cs003_n02_0017",		
		"cs003_n02_0018",		
		"cs003_n02_0019",		
		"cs003_n02_0020",		
		"cs003_n02_0021",		
		"cs003_n02_0022",		
		"cs003_n02_0023",		
		"cs003_n02_0024",		
		"cs003_n02_0025",		
		"cs003_n02_0026",		
		"cs003_n02_0027",		
		"cs003_n02_0028",		
		"cs003_n02_0029"};		CreateAnimationAsset ("cs003_n02" ,"cuts", strAnimArray_cs003_n02,strAnimArray_cs003_n02.GetUpperBound(0),0.2f,false,true);
	
	string[] strAnimArray_cs011_n01 = {	"cs011_n01_0000",		
		"cs011_n01_0001",		
		"cs011_n01_0002",		
		"cs011_n01_0003",		
		"cs011_n01_0004",		
		"cs011_n01_0005",		
		"cs011_n01_0006",		
		"cs011_n01_0007",		
		"cs011_n01_0008",		
		"cs011_n01_0009"};		CreateAnimationAsset ("cs011_n01" ,"cuts", strAnimArray_cs011_n01,strAnimArray_cs011_n01.GetUpperBound(0),0.2f,false,true);
	
	string[] strAnimArray_cs012_n01 = {	"cs012_n01_0000",		
		"cs012_n01_0001",		
		"cs012_n01_0002",		
		"cs012_n01_0003",		
		"cs012_n01_0004",		
		"cs012_n01_0005",		
		"cs012_n01_0006",		
		"cs012_n01_0007",		
		"cs012_n01_0008",		
		"cs012_n01_0009",		
		"cs012_n01_0010",		
		"cs012_n01_0011",		
		"cs012_n01_0012",		
		"cs012_n01_0013",		
		"cs012_n01_0014"};		CreateAnimationAsset ("cs012_n01" ,"cuts", strAnimArray_cs012_n01,strAnimArray_cs012_n01.GetUpperBound(0),0.2f,false,true);
	
	string[] strAnimArray_cs013_n01 = {	"cs013_n01_0000",		
		"cs013_n01_0001",		
			"cs013_n01_0002"};		CreateAnimationAsset ("cs013_n01" ,"cuts", strAnimArray_cs013_n01,strAnimArray_cs013_n01.GetUpperBound(0),0.2f,false,true);
			
string[] strAnimArray_cs014_n01 = {	"cs014_n01_0000",		
	"cs014_n01_0001",		
	"cs014_n01_0002"};		CreateAnimationAsset ("cs014_n01" ,"cuts", strAnimArray_cs014_n01,strAnimArray_cs014_n01.GetUpperBound(0),0.2f,false,true);
			
string[] strAnimArray_cs015_n01 = {	"cs015_n01_0000",		
	"cs015_n01_0001",		
	"cs015_n01_0002"};		CreateAnimationAsset ("cs015_n01" ,"cuts", strAnimArray_cs015_n01,strAnimArray_cs015_n01.GetUpperBound(0),0.2f,false,true);
			
string[] strAnimArray_cs400_n01 = {	"cs400_n01_0000",		
	"cs400_n01_0001",		
	"cs400_n01_0002",		
	"cs400_n01_0003",		
	"cs400_n01_0004",		
	"cs400_n01_0005",		
	"cs400_n01_0006",		
	"cs400_n01_0007"};		CreateAnimationAsset ("cs400_n01" ,"cuts", strAnimArray_cs400_n01,strAnimArray_cs400_n01.GetUpperBound(0),0.2f,false,true);

	}


	[MenuItem("MyTools/CreateSmallCutscenes")]
	static void CreateCutsSmall()
		{return;
		//cs402.n01   death skulls w/ silver sapling
		//cs403.n01   death skulls animation
		//cs403.n02   death skull end anim

		string[] animArrayDeathWithSapling = 
		{
		"cs402_n01_0000","cs402_n01_0001","cs402_n01_0002","cs402_n01_0003",
		"cs402_n01_0004","cs402_n01_0005","cs402_n01_0006","cs402_n01_0007",
		"cs402_n01_0008","cs402_n01_0009","cs402_n01_0010","cs402_n01_0011",
		"cs402_n01_0012","cs402_n01_0013","cs402_n01_0014","cs402_n01_0015",
		"cs402_n01_0016","cs402_n01_0017","cs402_n01_0018","cs402_n01_0019",
		"cs402_n01_0020","cs402_n01_0021","cs402_n01_0022","cs402_n01_0023",
		"cs402_n01_0024","cs402_n01_0025","cs402_n01_0026","cs402_n01_0027",
		"cs402_n01_0028","cs402_n01_0029","cs402_n01_0030","cs402_n01_0031",
		"cs402_n01_0032","cs402_n01_0033","cs402_n01_0034","cs402_n01_0035",
		"cs402_n01_0036","cs402_n01_0037","cs402_n01_0038","cs402_n01_0039",
		"cs402_n01_0040","cs402_n01_0041","cs402_n01_0042","cs402_n01_0043",
		"cs402_n01_0044","cs402_n01_0045","cs402_n01_0046","cs402_n01_0047",
		"cs402_n01_0048","cs402_n01_0049","cs402_n01_0050","cs402_n01_0051",
		"cs402_n01_0052","cs402_n01_0053","cs402_n01_0054","cs402_n01_0055",
		"cs402_n01_0056","cs402_n01_0057","cs402_n01_0058","cs402_n01_0059",
		"cs402_n01_0060","cs402_n01_0061","cs402_n01_0062","cs402_n01_0063",
		"cs402_n01_0064","cs402_n01_0065","cs402_n01_0066"
		};

		CreateAnimationAsset ("Death_With_Sapling","Cuts", animArrayDeathWithSapling,animArrayDeathWithSapling.GetUpperBound(0),0.1f,false,true);

		string[] animArrayDeath =
		{
			"cs403_n01_0000",
			"cs403_n01_0001",
			"cs403_n01_0002",
			"cs403_n01_0003",
			"cs403_n01_0004",
			"cs403_n01_0005",
			"cs403_n01_0006",
			"cs403_n01_0007",
			"cs403_n01_0008",
			"cs403_n01_0009",
			"cs403_n01_0010",
			"cs403_n01_0011",
			"cs403_n01_0012",
			"cs403_n01_0013",
			"cs403_n01_0014",
			"cs403_n01_0015",
			"cs403_n01_0016",
			"cs403_n01_0017",
			"cs403_n01_0018",
			"cs403_n01_0019",
			"cs403_n01_0020",
			"cs403_n01_0021",
			"cs403_n01_0022",
			"cs403_n01_0023",
			"cs403_n01_0024",
			"cs403_n01_0025",
			"cs403_n01_0026",
			"cs403_n01_0027",
			"cs403_n01_0028",
			"cs403_n01_0029",
			"cs403_n01_0030",
			"cs403_n01_0031",
			"cs403_n01_0032",
			"cs403_n01_0033",
			"cs403_n01_0034",
			"cs403_n01_0035",
			"cs403_n01_0036"
			};


			CreateAnimationAsset ("Death","Cuts", animArrayDeath,animArrayDeath.GetUpperBound(0),0.1f,false,true);

		string[] animArrayFinalDeath =
		{
			"cs403_n02_0000",
			"cs403_n02_0001",
			"cs403_n02_0002",
			"cs403_n02_0003",
			"cs403_n02_0004",
			"cs403_n02_0005",
			"cs403_n02_0006",
			"cs403_n02_0007",
			"cs403_n02_0008",
			"cs403_n02_0009",
			"cs403_n02_0010"
		};


	CreateAnimationAsset ("Death_Final","Cuts", animArrayFinalDeath,animArrayFinalDeath.GetUpperBound(0),0.1f,true,false);

		string[] animArrayChasmMap =
		{
			"cs410_n01_0000",
			"cs410_n01_0001"
		};
		CreateAnimationAsset ("ChasmMap","Cuts", animArrayChasmMap,animArrayChasmMap.GetUpperBound(0),6.0f,false,true);

		string[] animArrayWindow =
		{
			"cs400_n01_0000",
			"cs400_n01_0000"
		};
		for (int i = 0; i<=7;i++)
		{
			animArrayWindow[0] = "cs400_n01_000"+i;
			animArrayWindow[1] = "cs400_n01_000"+i;
			CreateAnimationAsset ("VolcanoWindow_" +i,"Cuts", animArrayWindow,animArrayWindow.GetUpperBound(0),3.0f,false,true);
		}


		string[] animArrayAnvil = 
		{
			"cs404_n01_0000",
			"cs404_n01_0001",
			"cs404_n01_0002",
			"cs404_n01_0003",
			"cs404_n01_0004",
			"cs404_n01_0005",
			"cs404_n01_0006",
			"cs404_n01_0007",
			"cs404_n01_0008",
			"cs404_n01_0009",
			"cs404_n01_0010",
			"cs404_n01_0011",
			"cs404_n01_0012",
			"cs404_n01_0013",
			"cs404_n01_0014",
			"cs404_n01_0015",
			"cs404_n01_0016",
			"cs404_n01_0017",
			"cs404_n01_0018",
			"cs404_n01_0019",
			"cs404_n01_0020",
			"cs404_n01_0021",
			"cs404_n01_0022",
			"cs404_n01_0023",
			"cs404_n01_0024",
			"cs404_n01_0025",
			"cs404_n01_0026",
			"cs404_n01_0027",
			"cs404_n01_0028",
			"cs404_n01_0029",
			"cs404_n01_0030",
			"cs404_n01_0031",
			"cs404_n01_0032",
			"cs404_n01_0033",
			"cs404_n01_0034",
			"cs404_n01_0035",
			"cs404_n01_0036"
		};
		CreateAnimationAsset ("Anvil","Cuts", animArrayAnvil,animArrayAnvil.GetUpperBound(0),0.2f,false,true);

		string[] strAnimArray_sleep = {	"cs000_n01_0000",
			"cs000_n01_0001",		
			"cs000_n01_0002",		
			"cs000_n01_0003",		
			"cs000_n01_0004",		
			"cs000_n01_0005"};		
		CreateAnimationAsset ("FadeToBlackSleep" ,"cuts", strAnimArray_sleep,strAnimArray_sleep.GetUpperBound(0),0.2f,false,true);


	}

	static void CreateAnimationUW(string AnimationName, string Frame0, string Frame1, string Frame2, string Frame3, string Frame4, string Frame5, int NoOfValid, string BasePath, float AnimTime)
	{//For critter animations
		string[] animArray =  {Frame0,Frame1,Frame2,Frame3,Frame4,Frame5};
		CreateAnimationAsset (AnimationName,BasePath, animArray, NoOfValid,AnimTime,true,false);
		return;
	}



	static void CreateAnimationUW(string AnimationName, string Frame0, string Frame1, string Frame2, string Frame3, string Frame4, string Frame5,string Frame6,string Frame7, int NoOfValid, string BasePath, float AnimTime)
	{
		string[] animArray =  {Frame0,Frame1,Frame2,Frame3,Frame4,Frame5,Frame6,Frame7};
		CreateAnimationAsset (AnimationName,BasePath, animArray, NoOfValid,AnimTime,true,false);
		return;
	}

	static void CreateAnimationUI(string AnimationName, string Frame0, string Frame1, string Frame2, string Frame3, string Frame4, string Frame5,string Frame6,string Frame7, int NoOfValid, string BasePath, float AnimTime ,bool Looping)
	{
		string[] animArray =  {Frame0,Frame1,Frame2,Frame3,Frame4,Frame5,Frame6,Frame7};
		CreateAnimationAsset (AnimationName,BasePath, animArray, NoOfValid,AnimTime,Looping,false);
		return;
	}



	static void CreateAnimationAsset(string AnimationName, string BasePath, string[] Frames, int NoOfValid ,float AnimTime , bool Looping, bool IncludeEvents)
	{
		//CreateAnim();
		GameObject myAI = GameObject.Find ("_" + _RES + "_Base_Animator");
		if (myAI==null)
		{
			Debug.Log ("No Animation Base Found");
			return;
		}
			
		SpriteRenderer sprt = myAI.GetComponent<SpriteRenderer>();
		AnimationClip animClip = new AnimationClip();
#if UNITY_5
		//do nothing
#else
		AnimationUtility.SetAnimationType (animClip, ModelImporterAnimationType.Generic);
#endif
		EditorCurveBinding curveBinding = new EditorCurveBinding();



		if (Looping)
		{
			animClip.wrapMode = WrapMode.Loop;
		}
		else
		{
			animClip.wrapMode = WrapMode.Once;
		}

		animClip.name=AnimationName;
		
		curveBinding.type = typeof(SpriteRenderer);
		curveBinding.path = "";
		curveBinding.propertyName = "m_Sprite";

		ObjectReferenceKeyframe[] keyFrames = new ObjectReferenceKeyframe[NoOfValid+1];
		for(int i = 0; i<NoOfValid; i++)
		{
			if (Frames[i]!="")
			{
				keyFrames[i] = new ObjectReferenceKeyframe();
				keyFrames[i].time = AnimTime * i;

				//"Sprites/critters"
				Sprite currFrame = Resources.Load <Sprite> (BasePath +"/" + Frames[i]);
				//Debug.Log ("Sprites/Critters/" + Frames[i]);
				if (currFrame == null)
				{
						Debug.Log ("Resource not loaded! " +BasePath +"/" + Frames[i]);
				}
				sprt.sprite=currFrame;
				keyFrames[i].value=currFrame;	
			}

		}
		if (NoOfValid !=0)
		{
			keyFrames[NoOfValid] = new ObjectReferenceKeyframe();
			keyFrames[NoOfValid].time = AnimTime * NoOfValid;//0.2f
			Sprite currFrame = Resources.Load <Sprite> (BasePath +"/" + Frames[NoOfValid-1]);
			sprt.sprite=currFrame;
			keyFrames[NoOfValid].value=currFrame; //Hold on the last frame
		}


		AnimationUtility.SetObjectReferenceCurve(animClip, curveBinding, keyFrames);
		AssetDatabase.CreateAsset(animClip,"Assets/Resources/" + _RES + "/animation/"+  animClip.name + ".anim" );

		if (IncludeEvents)
		{

		//The following code when uncommented will append a Pre+PostAnimPlay Event to the end of the new animation  clip
		//The pre + post anim events must be declared on the class it is using.
		AnimationEvent[] animEvent = new AnimationEvent[2];
		animEvent[0]=new AnimationEvent();
		animEvent[0].time= 0.0f;
		animEvent[0].functionName= "PreAnimPlay";

		animEvent[1]=new AnimationEvent();
		animEvent[1].time= AnimTime * NoOfValid;
		animEvent[1].functionName= "PostAnimPlay";
		//animEvent[0].isFiredByLegacy=true;

		AnimationUtility.SetAnimationEvents(animClip,animEvent);
		}
	}

		/*
	static void CreateAnim()
	{//test
		return;
		GameObject myAI = GameObject.Find ("AI_Base_Animator");
//		Animator Anim = myAI.GetComponent<Animator>();
		SpriteRenderer sprt = myAI.GetComponent<SpriteRenderer>();
		AnimationClip animClip = new AnimationClip();
#if UNITY_5
		//do nothing
#else
		AnimationUtility.SetAnimationType (animClip, ModelImporterAnimationType.Generic);
#endif
		EditorCurveBinding curveBinding = new EditorCurveBinding();

		animClip.name="GreenGoblin_Facing_Towards";

		curveBinding.type = typeof(SpriteRenderer);
		curveBinding.path = "";
		curveBinding.propertyName = "m_Sprite";

		ObjectReferenceKeyframe[] keyFrames = new ObjectReferenceKeyframe[5];
		for(int i = 0; i<5; i++)
		{
			keyFrames[i] = new ObjectReferenceKeyframe();
			keyFrames[i].time = 0.2f * i;
			//Debug.Log (keyFrames[i].time);
			Sprite currFrame = Resources.Load <Sprite> ("Sprites/critters/cr00page_n00_" + i.ToString ("D4"));
			sprt.sprite=currFrame;
			keyFrames[i].value=currFrame;
			//Debug.Log("Sprites/AI/GreenGoblin/frames/cr00page_n00_" + i.ToString ("D4"));
		}
		AnimationUtility.SetObjectReferenceCurve(animClip, curveBinding, keyFrames);
		AssetDatabase.CreateAsset(animClip,"Assets/Resources/animation/"+  animClip.name + ".anim" );

		//Anim.animation.AddClip (animClip,animClip.name);
		//Anim.animation.clip = animClip;

		//AssetDatabase.CreateAsset(animClip,"Assets/Resources/animation/"+  animClip.name + ".anim" );
		//Anim.Play (animClip.name);
	}*/

	static GameObject CreateGameObject(string ObjectName, float x, float y, float z)
	{
		GameObject myObj = new GameObject(ObjectName);
		Vector3 pos = new Vector3(x, y, z);
		myObj.transform.position = pos;
		myObj.layer=LayerMask.NameToLayer("UWObjects");
		myObj.transform.parent=LevelParent;
		//StoreInformation si=myObj.AddComponent<StoreInformation>();
		//si.Id= myObj.name + "_ID";
		return myObj;
	}

	static void CreateObjectGraphics(GameObject myObj,string AssetPath, bool BillBoard)
	{	
		//Create a sprite.
		GameObject SpriteController = new GameObject(myObj.name + "_sprite");
		SpriteController.transform.position = myObj.transform.position;
		
		SpriteRenderer mysprite = SpriteController.AddComponent<SpriteRenderer>();//Adds the sprite gameobject
		//mysprite.transform.position = new Vector3 (0f, 0f, 0f);
		//Sprite image = Resources.LoadAssetAtPath <Sprite> (AssetPath);//Loads the sprite.
		Sprite image = Resources.Load <Sprite> (AssetPath);//Loads the sprite.
		mysprite.sprite = image;//Assigns the sprite to the object.
		SpriteController.transform.parent = myObj.transform;
		SpriteController.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
		mysprite.material= Resources.Load<Material>("Materials/SpriteShader");
		//Create a billboard script for display
		// Billboard ScriptController = 
		if (BillBoard)
		{
			SpriteController.AddComponent<Billboard> ();
		}
	}

/*
	static void CreateUWScriptObjects(GameObject myObj, int triggerX, int triggerY, string target,string ScriptType, int state)
	{

		ObjectVariables objVar = myObj.AddComponent<ObjectVariables>();
		switch (ScriptType)
			{
				case "a_do_trap_platform":
				{
			//a_do_trap_platform trap ;=  
				myObj.AddComponent<a_do_trap_platform>();
				//trap.state=state;
				//objVar.triggerX=triggerX;
				//objVar.triggerY=triggerY;
				objVar.trigger=target;
				break;
				}
			}	
	}*/

	static void CreateUWActivators(GameObject Button,string activatortype, string target, int triggerX, int triggerY, int state, int maxstate, int item_id)
	{
		//GameObject Button = new GameObject(myObj.name + "_activator");
		//Button.transform.parent= myObj.transform;
		switch (activatortype)
		{
			case "ButtonHandler":
				{
				ButtonHandler buttonScript = Button.AddComponent<ButtonHandler>();
				buttonScript.trigger=target;
				buttonScript.triggerX=triggerX;
				buttonScript.triggerY=triggerY;
				buttonScript.state=state;
				buttonScript.maxstate=maxstate;
				//buttonScript.item_id=item_id;
				//ObjectVariables objVars = Button.AddComponent<ObjectVariables>();
				//objVars.state=state;
				break;
				}
		}

		//add a mesh for interaction
		//BoxCollider box= Button.AddComponent<BoxCollider>();
		//box.transform.position = myObj.transform.position;
		//box.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
		//box.isTrigger=true;

	//	BoxCollider box= Button.AddComponent<BoxCollider>();
		//box.transform.position =B.transform.position;
	//	box.size = new Vector3(0.3f, 0.3f, 0.05f);
	//	box.isTrigger=true;
	}

	static void CreateSHOCKActivators(GameObject myObj, int TriggerAction)
	{
		GameObject Button = new GameObject(myObj.name + "_activator");
		Button.transform.parent= myObj.transform;
		ShockButtonHandler shockbuttonScript = Button.AddComponent<ShockButtonHandler>();
		shockbuttonScript.TriggerAction= TriggerAction;

		BoxCollider box= Button.AddComponent<BoxCollider>();
		box.transform.position = myObj.transform.position;
		box.size = new Vector3(0.3f, 0.3f, 0.05f);
		box.isTrigger=true;
	}


	static void CreateObjectInteraction(GameObject myObj,float DimX,float DimY,float DimZ, float CenterY, string WorldString, string InventoryString, string EquipString, int ItemType, int ItemId, int link, int Quality, int Owner, int isMoveable, int isUsable, int isAnimated, int useSprite,int isQuant, int isEnchanted, int flags, int inUseFlag ,string ChildName)
	{
		GameObject newObj = new GameObject(myObj.name+"_"+ChildName);

		newObj.transform.parent=myObj.transform;
		newObj.transform.localPosition=new Vector3(0.0f,0.0f,0.0f);
		CreateObjectInteraction (newObj,DimX,DimY,DimZ,CenterY , WorldString,InventoryString,EquipString,ItemType ,link, Quality, Owner,ItemId,isMoveable,isUsable, isAnimated, useSprite,isQuant,isEnchanted, flags,inUseFlag);

		ObjectInteraction.CreateObjectInteraction(newObj,DimX,DimY,DimZ,CenterY , WorldString,InventoryString,EquipString,ItemType ,link, Quality, Owner,ItemId,isMoveable,isUsable, isAnimated, useSprite,isQuant,isEnchanted, flags,inUseFlag);
	}

	static void CreateObjectInteraction(GameObject myObj,float DimX,float DimY,float DimZ, float CenterY, string WorldString, string InventoryString, string EquipString, int ItemType, int ItemId, int link, int Quality, int Owner, int isMoveable, int isUsable, int isAnimated, int useSprite,int isQuant, int isEnchanted, int flags, int inUseFlag)
	{
		//CreateObjectInteraction (myObj,myObj,DimX,DimY,DimZ,CenterY, WorldString,InventoryString,EquipString,ItemType,ItemId,link,Quality,Owner,isMoveable,isUsable, isAnimated, useSprite,isQuant,isEnchanted, flags,inUseFlag);

		ObjectInteraction.CreateObjectInteraction(myObj,myObj,DimX,DimY,DimZ,CenterY, WorldString,InventoryString,EquipString,ItemType,ItemId,link,Quality,Owner,isMoveable,isUsable, isAnimated, useSprite,isQuant,isEnchanted, flags,inUseFlag);
	}
	/*
	static void CreateObjectInteraction(GameObject myObj, GameObject parentObj,float DimX,float DimY,float DimZ, float CenterY, string WorldString, string InventoryString, string EquipString, int ItemType, int ItemId, int link, int Quality, int Owner, int isMoveable, int isUsable, int isAnimated, int useSprite, int isQuant, int isEnchanted, int flags, int inUseFlag)
	{
		//Debug.Log (myObj.name);
		//Add a script.
		ObjectInteraction objInteract = myObj.AddComponent<ObjectInteraction>();

		BoxCollider box =myObj.GetComponent<BoxCollider>();
		if ((box==null) && (myObj.GetComponent<NPC>()==null) && (isUsable==1))
		{
			//add a mesh for interaction
			box= myObj.AddComponent<BoxCollider>();
			box.size = new Vector3(0.2f,0.2f,0.2f);
			box.center= new Vector3(0.0f,0.1f,0.0f);
			if (isMoveable==1)
			{
				box.material= Resources.Load<PhysicMaterial>("Materials/objects_bounce");
			}
		}

		objInteract.WorldDisplayIndex = int.Parse(WorldString.Substring (WorldString.Length-3,3));
		objInteract.InvDisplayIndex= int.Parse (InventoryString.Substring (InventoryString.Length-3,3));

		if (isUsable==1)
		{
			objInteract.CanBeUsed=true;
		}

		//SpriteRenderer objSprite =  myObj.transform.FindChild(myObj.name + "_sprite").GetComponent<SpriteRenderer>();
//		SpriteRenderer objSprite =  parentObj.GetComponentInChildren<SpriteRenderer>();

//		objInteract.WorldString=WorldString;
//		objInteract.InventoryString=InventoryString;
		objInteract.EquipString=EquipString;
		//objInteract.InventoryDisplay=InventoryString;
		objInteract.ItemType=ItemType;//UWexporter id type
		objInteract.item_id=ItemId;//Internal ItemID
		objInteract.Link=link;
		objInteract.Quality=Quality;
		objInteract.Owner=Owner;
		objInteract.flags=flags;
		if (inUseFlag==1)
		{
			objInteract.InUse=true;
		}



		if (isMoveable==1)
		{
			objInteract.CanBePickedUp=true;
			Rigidbody rgd = parentObj.AddComponent<Rigidbody>();
			rgd.angularDrag=0.0f;
			FreezeMovement(myObj);
		}

		if (ItemType !=ObjectInteraction.ANIMATION)
		{
			if (isAnimated==1)
			{
				objInteract.isAnimated=true;
			}
			
			if (useSprite==1)
			{
				objInteract.ignoreSprite=false;
			}
			else
			{
				objInteract.ignoreSprite=true;
			}
		}
		else
		{
			objInteract.ignoreSprite=true;
		}
		if (isQuant==1)
		{
			objInteract.isQuant=true;
		}
		if (isEnchanted==1)
		{
			objInteract.isEnchanted=true;
			//Debug.Log (myObj.name + " is enchanted. Take a look at it please.");
		}
	}*/

	static void CreateTrigger(GameObject myObj,int triggerX, int triggerY, string target)
	{
		trigger_base trigobj = myObj.AddComponent<trigger_base>();
		trigobj.TrapObject=target;
		//Add some gamevars
		//ObjectVariables objVar = myObj.AddComponent<ObjectVariables>();
		///
		//objVar.trigger=target;
		//TriggerHandler trig = myObj.AddComponent<TriggerHandler>();
		//trig.triggerX=triggerX;
		//trig.triggerY=triggerY;
		//trig.trigger=target;
		//myObj.layer=LayerMask.NameToLayer("Default");
		myObj.layer=LayerMask.NameToLayer("Ignore Raycast");
	}

	static void CreateMoveTrigger(GameObject myObj,int triggerX, int triggerY, string target)
	{
		a_move_trigger trigobj = myObj.AddComponent<a_move_trigger>();
		trigobj.TrapObject=target;
		myObj.layer=LayerMask.NameToLayer("Ignore Raycast");
	}

	static void Create_A_PICK_UP_TRIGGER(GameObject myObj,int triggerX, int triggerY, string target)
	{
		a_pick_up_trigger trigobj = myObj.AddComponent<a_pick_up_trigger>();
		trigobj.TrapObject=target;
		myObj.layer=LayerMask.NameToLayer("Ignore Raycast");
	}


	/*static void CreateNPC(GameObject myObj, string NPC_ID, string EditorSprite)
	{
		//Add the AI.
		myObj.layer=LayerMask.NameToLayer("NPCs");


		GoblinAI gronk = myObj.AddComponent<GoblinAI>();
		//Since I have only one animation I change names

		gronk.NPC_ID=NPC_ID;

		GameObject myInstance = Resources.Load("AI_PREFABS/AI_LAND") as GameObject;
		GameObject newObj = (GameObject)GameObject.Instantiate(myInstance);
		newObj.name = myObj.name + "_AI";
		newObj.transform.parent=myObj.transform;
		AIRig ai = newObj.GetComponent<AIRig>();
		ai.AI.Body=myObj;
		myObj.AddComponent<NPC>();
		Rigidbody rgd = myObj.AddComponent<Rigidbody>();
		rgd.freezeRotation=true;

		myInstance = Resources.Load("animation/AI_Base_Animator") as GameObject;
		newObj = (GameObject)GameObject.Instantiate(myInstance);
		newObj.name=myObj.name + "_Sprite";
		newObj.transform.parent=myObj.transform;
		newObj.transform.position = myObj.transform.position;
		
		SpriteRenderer mysprite =  newObj.GetComponent<SpriteRenderer>();
		Sprite image = Resources.Load <Sprite> (EditorSprite);//Loads the sprite.
		//Debug.Log (EditorSprite);
		if (image ==  null)
		{
			Debug.Log ("No sprite renderer found.");
		}
		mysprite.material= Resources.Load<Material>("Materials/SpriteShader");
		mysprite.sprite = image;//Assigns the sprite to the object.
		//newObj.AddComponent<Billboard>();
		
		BoxCollider mybox = myObj.AddComponent<BoxCollider>();
		mybox.isTrigger=false;
		mybox.center = new Vector3(0.0f, 0.5f, 0.0f);
		mybox.size= new Vector3(0.5f, 1.0f, 0.3f);
	}*/


	static void CreateNPC(GameObject myObj, string NPC_ID, string EditorSprite ,int npc_whoami)
	{
		//GoblinAI gronk = myObj.AddComponent<GoblinAI>();
		//gronk.NPC_ID=NPC_ID;
		myObj.layer=LayerMask.NameToLayer("NPCs");
				myObj.tag="NPCs";
		GameObject myInstance = Resources.Load("AI_PREFABS/AI_LAND") as GameObject;
		GameObject newObj = (GameObject)GameObject.Instantiate(myInstance);
		newObj.name = myObj.name + "_AI";
		newObj.transform.position=Vector3.zero; //new Vector3(0,0,0);
		newObj.transform.parent=myObj.transform;
		newObj.transform.localPosition=Vector3.zero; //new Vector3(0,0,0);
		AIRig ai = newObj.GetComponent<AIRig>();
		ai.AI.Body=myObj;

		NPC npc = myObj.AddComponent<NPC>();
		npc.NPC_ID=NPC_ID;
		if (npc_whoami == 0)
		{
			npc.npc_whoami=256+(int.Parse (NPC_ID) -64);
		}


		//Probably only need to add this when an NPC supports ranged attacks?
		GameObject NpcLauncher = new GameObject("NPC_Launcher");
		NpcLauncher.transform.position=Vector3.zero; 
		//NpcLauncher.transform.rotation=Vector3.zero; 
		NpcLauncher.transform.parent=myObj.transform;
		NpcLauncher.transform.localPosition=new Vector3(0.0f,0.5f,0.1f);
		npc.NPC_Launcher=NpcLauncher;

		/*
		Rigidbody rgd = myObj.AddComponent<Rigidbody>();
		//rgd.freezeRotation=true;
		rgd.constraints = 
			RigidbodyConstraints.FreezeRotationX 
				| RigidbodyConstraints.FreezeRotationY 
				| RigidbodyConstraints.FreezeRotationZ 
				| RigidbodyConstraints.FreezePositionX 
				| RigidbodyConstraints.FreezePositionZ;
		rgd.collisionDetectionMode=CollisionDetectionMode.Continuous;
*/


		myInstance = Resources.Load(_RES + "/animation/" + _RES + "_Base_Animator") as GameObject;
		newObj = (GameObject)GameObject.Instantiate(myInstance);
		newObj.name=myObj.name + "_Sprite";
		newObj.transform.parent=myObj.transform;
		newObj.transform.position = myObj.transform.position;

		SpriteRenderer mysprite =  newObj.GetComponent<SpriteRenderer>();
		Sprite image = Resources.Load <Sprite> (EditorSprite);//Loads the sprite.

		mysprite.material= Resources.Load<Material>("Materials/SpriteShader");
		mysprite.sprite = image;//Assigns the sprite to the object.
		//CapsuleCollider cap = myObj.AddComponent<CapsuleCollider>();

		CharacterController cap  = myObj.AddComponent<CharacterController>();

		switch(int.Parse(NPC_ID))
				{
				case 97: //a_ghost
				case 99: //a_ghoul
				case 100: //a_ghost
				case 101: //a_ghost
				case 105: //a_dark_ghoul
				case 110: //a_ghoul	
				case 113: //a_dire_ghost
					npc.isUndead=true;
					break;
				}

		switch (int.Parse(NPC_ID))
		{

			//Big
		case 70: //a_goblin
		case 71: //a_goblin
		case 74: //a_skeleton
		case 76: //a_goblin
		case 77: //a_goblin
		case 78: //a_goblin
		case 79: //etherealvoidcreatures
		case 80: //a_goblin
		case 84: //a_mountainman_mountainmen
		case 85: //a_green_lizardman_green_lizardmen
		case 86: //a_mountainman_mountainmen
		case 88: //a_red_lizardman_red_lizardmen
		case 89: //a_gray_lizardman_red_lizardmen
		case 90: //an_outcast
		case 91: //a_headless_headlesses
		case 93: //a_fighter
		case 94: //a_fighter
		case 95: //a_fighter
		case 96: //a_troll
		case 97: //a_ghost
		case 98: //a_fighter
		case 99: //a_ghoul
		case 100: //a_ghost
		case 101: //a_ghost
		case 103: //a_mage
		case 104: //a_fighter
		case 105: //a_dark_ghoul
		case 106: //a_mage
		case 107: //a_mage
		case 108: //a_mage
		case 109: //a_mage
		case 110: //a_ghoul
		case 111: //a_feral_troll
		case 112: //a_great_troll
		case 113: //a_dire_ghost
		case 114: //an_earth_golem
		case 115: //a_mage
		case 116: //a_deep_lurker
		case 117: //a_shadow_beast
		case 118: //a_reaper
		case 119: //a_stone_golem
		case 120: //a_fire_elemental
		case 121: //a_metal_golem
		case 123: //tybal
		case 124: //slasher_of_veils
		case 125: //unknown
		case 126: //unknown
			cap.isTrigger=false;
			cap.center = new Vector3(0.0f, 0.4f, 0.0f);
			cap.radius=0.2f;
			cap.height=0.8f;
			break;

			//Medium
		case 68: //a_giant_spider
		case 67: //a_giant_rat
		case 72: //a_giant_rat
		case 75: //an_imp
		case 81: //a_mongbat
		case 83: //a_wolf_spider
		case 92: //a_dread_spider
		case 102: //a_gazer
			cap.isTrigger=false;
			cap.center = new Vector3(0.0f, 0.5f, 0.0f);
			cap.radius=0.5f;
			cap.height=0.5f;
			cap.skinWidth=0.05f;
			break;
			//Small
		case 64: //a_rotworm
		case 65: //a_flesh_slug
		case 66: //a_cave_bat
		case 69: //a_acid_slug
		case 73: //a_vampire_bat
		case 82: //a_bloodworm
		case 87: //a_lurker
		case 122: //a_wisp
			cap.isTrigger=false;
			cap.center = new Vector3(0.0f, 0.3f, 0.0f);
			cap.radius=0.3f;
			cap.height=0.3f;
			break;
		}

		//BoxCollider mybox = myObj.AddComponent<BoxCollider>();
		//mybox.isTrigger=false;
		//mybox.center = new Vector3(0.0f, 0.5f, 0.0f);
		//mybox.size= new Vector3(0.5f, 1.0f, 0.3f);
	}

	static void RenameBrushes(string BrushName, string TileName)
	{

		GameObject levelMesh= GameObject.Find ("uw1_level0");
		if (levelMesh != null) 
				{

				GameObject tile = levelMesh.transform.FindChild(BrushName).gameObject;
				if (tile != null)
					{
					tile.name=TileName;
					}
				}
		else 
				{
						Debug.LogWarning("No Mesh found!");
				}
	}

	static void Create_a_damage_trap(GameObject myObj)
	{
		//Add some gamevars
		//ObjectVariables objVar =
		//myObj.AddComponent<ObjectVariables>();
		myObj.AddComponent<a_damage_trap>();
	}

	static void Create_a_damage_trap(GameObject myObj, string Trigger)
	{
		//Add some gamevars
		//ObjectVariables objVar =
		//ObjectVariables myvars= myObj.AddComponent<ObjectVariables>();
		//myvars.trigger=Trigger;
		myObj.AddComponent<a_damage_trap>();
	}

	static void Create_a_teleport_trap(GameObject myObj, float x, float y, float z, int Levelno)
	{
		//Add some gamevars
		//ObjectVariables objVar =
		//myObj.AddComponent<ObjectVariables>();
		a_teleport_trap tp = myObj.AddComponent<a_teleport_trap>();
		//if (tp!=null)
		//{
			tp.targetX=x;
			tp.targetY=y;
			tp.targetZ=z;
			tp.levelNo=Levelno;
		//}
	}

	static void Create_a_arrow_trap(GameObject myObj, int item_index, int item_type)
	{
		//Add some gamevars
		//ObjectVariables objVar =
		//myObj.AddComponent<ObjectVariables>();
		a_arrow_trap arrow=	myObj.AddComponent<a_arrow_trap>();
		arrow.item_index=item_index;
		arrow.item_type=item_type;
	}

	static void Create_a_do_trap(GameObject myObj, int trapType, int flags)
	{
		//Add some gamevars
		//ObjectVariables objVar = 
		//myObj.AddComponent<ObjectVariables>();
		switch (trapType)
		{
		case 0x02://Camera
			{
			a_do_trap_camera adtc= myObj.AddComponent<a_do_trap_camera>();
			adtc.cam = myObj.AddComponent<Camera>();
			adtc.cam.tag="MainCamera";
			adtc.cam.rect=new Rect(0.163f,0.335f,0.54f,0.572f);
			adtc.cam.depth=100;
			adtc.cam.enabled=false;
			adtc.lt=myObj.AddComponent<Light>();
			adtc.lt.range=8;
			adtc.enabled=false;
			break;
		}
		case 0x03://Platform
			{
			//a_do_trap_platform scrpt = 	
			myObj.AddComponent<a_do_trap_platform>();
			//scrpt.state=flags;
			break;
			}
		case 0x18:	//bullfrog
			{myObj.AddComponent<a_do_trapBullfrog>();break;}
		case 0x2a://Gronk conversation
		{
			myObj.AddComponent<a_do_trap_conversation>();
			NPC_Door np =myObj.AddComponent<NPC_Door>();
			np.npc_whoami=25;
			myObj.AddComponent<Conversation_25>();
			break;
		}
		case 0x28:
			myObj.AddComponent<a_do_trap_emeraldpuzzle>();
			break;
		default:
			{myObj.AddComponent<trap_base>();break;}
		}
	}

	static void Create_a_pit_trap(GameObject myObj)
	{
		//Add some gamevars
		//ObjectVariables objVar = 
		//myObj.AddComponent<ObjectVariables>();
		myObj.AddComponent<a_pit_trap>();
	}

	static void Create_a_change_terrain_trap(GameObject myObj, int TileX, int TileY, int x, int y)
	{
		//Add some gamevars
		//ObjectVariables objVar =
		//myObj.AddComponent<ObjectVariables>();

		a_change_terrain_trap ctt= myObj.AddComponent<a_change_terrain_trap>();
		//ctt.TileX=TileX;
		//ctt.TileY=TileY;
		ctt.X=x;
		ctt.Y=y;
	}
	/*
	static void Create_a_change_terrain_trap(GameObject myObj, int TileX, int TileY, int x, int y,string Trigger)
	{
		//Add some gamevars
		//ObjectVariables objVar =
		//ObjectVariables myvars= myObj.AddComponent<ObjectVariables>();
		//myvars.trigger=Trigger;

		a_change_terrain_trap ctt= myObj.AddComponent<a_change_terrain_trap>();
		//ctt.TileX=TileX;
		//ctt.TileY=TileY;
		ctt.X=x;
		ctt.Y=y;
	}
	*/

	static void Create_a_spelltrap(GameObject myObj)
	{
		//Add some gamevars
		//ObjectVariables objVar =
		//myObj.AddComponent<ObjectVariables>();
		myObj.AddComponent<a_spelltrap>();
	}

	static void Create_a_create_object_trap(GameObject myObj,string navmeshregion)
	{
		//Add some gamevars
		//ObjectVariables objVar = 
		//myObj.AddComponent<ObjectVariables>();
		a_create_object_trap act= myObj.AddComponent<a_create_object_trap>();
		act.NavMeshRegion=navmeshregion;
	}

	static void Create_a_door_trap(GameObject myObj, int quality)
	{
		//Points to the tile where the door is located.
		//Add some gamevars
		//ObjectVariables objVar = 
		//myObj.AddComponent<ObjectVariables>();
		myObj.AddComponent<a_door_trap>();
		//scrpt.quality=quality;
	}

	static void Create_a_lock(GameObject myObj)
	{
		//Add some gamevars
		//ObjectVariables objVar = 
		//	myObj.AddComponent<ObjectVariables>();
		myObj.AddComponent<a_lock>();
	}

	static void Create_a_ward_trap(GameObject myObj)
	{
		//Add some gamevars
		//ObjectVariables objVar = 
		//	myObj.AddComponent<ObjectVariables>();
		myObj.AddComponent<a_ward_trap>();
	}

	static void Create_a_delete_object_trap(GameObject myObj)
	{
		//Add some gamevars
		//ObjectVariables objVar = 
		//	myObj.AddComponent<ObjectVariables>();
		myObj.AddComponent<a_delete_object_trap>();
	}

	static void Create_an_inventory_trap(GameObject myObj)
	{
		//Add some gamevars
		//ObjectVariables objVar =
		//	myObj.AddComponent<ObjectVariables>();
		myObj.AddComponent<an_inventory_trap>();
	}

	static void Create_a_set_variable_trap(GameObject myObj, int VariableIndex, int VariableValue, int Heading)
	{
		//Add some gamevars
		//ObjectVariables objVar = 
		//	myObj.AddComponent<ObjectVariables>();
		a_set_variable_trap svt=myObj.AddComponent<a_set_variable_trap>();
		svt.VariableIndex=VariableIndex;
		svt.VariableValue=VariableValue;
		svt.heading=Heading;
	}

	static void Create_a_check_variable_trap(GameObject myObj, int VariableIndex, int xpos, int VariableValue, int Heading)
	{
		//Add some gamevars
		//ObjectVariables objVar = 
		//	myObj.AddComponent<ObjectVariables>();
		a_check_variable_trap cvt =myObj.AddComponent<a_check_variable_trap>();
		cvt.VariableIndex=VariableIndex;
		cvt.VariableValue=VariableValue;
		cvt.heading=Heading;
		cvt.xpos=xpos;
	}

	static void Create_a_text_string_trap(GameObject myObj, int blockNo, int stringNo)
	{
		//Add some gamevars
		//ObjectVariables objVar =
		//myObj.AddComponent<ObjectVariables>();
		a_text_string_trap scrpt = myObj.AddComponent<a_text_string_trap>();
		scrpt.StringBlock = blockNo;
		scrpt.StringNo = stringNo;
	}

	static void Create_a_text_string_trap(GameObject myObj, int blockNo, int stringNo, string trigger)
	{
		//Add some gamevars
		//ObjectVariables objVar =
		//ObjectVariables vars = myObj.AddComponent<ObjectVariables>();
	//	vars.trigger=trigger;
		a_text_string_trap scrpt = myObj.AddComponent<a_text_string_trap>();
		scrpt.StringBlock = blockNo;
		scrpt.StringNo = stringNo;
	}

	static void Create_a_tell_trap(GameObject myObj)
	{
		//Add some gamevars
		//ObjectVariables objVar =
		//myObj.AddComponent<ObjectVariables>();
		myObj.AddComponent<a_tell_trap>();
	}

	static void Create_trap_base(GameObject myObj)
	{
		//Add some gamevars
		//ObjectVariables objVar =
		//myObj.AddComponent<ObjectVariables>();
		myObj.AddComponent<trap_base>();
	}

	static void AddObjectToContainer(GameObject myObj, Container ParentContainer, int index)
	{
		ParentContainer.AddItemToContainer(myObj.name,index);
		myObj.GetComponent<ObjectInteraction>().PickedUp=true;
	}

	static void AddObjectToContainer(string myObjName, Container ParentContainer, int index)
	{
		ParentContainer.AddItemToContainer(myObjName,index);
		//myObj.GetComponent<ObjectInteraction>().PickedUp=true;
	}

	static void SetObjectAsRuneStone(GameObject myObj)
	{//Sets an object as being a rune stone
		//ObjectInteraction objInt = myObj.GetComponent<ObjectInteraction>();
		myObj.AddComponent<RuneStone>();
		//objInt.isRuneStone=true;
		//objInt.isRuneBag=false;//Mutually exclusive
	}

	static void SetObjectAsRuneBag(GameObject myObj)
	{//Sets an object as being a rune bag
		//ObjectInteraction objInt = myObj.GetComponent<ObjectInteraction>();
		myObj.AddComponent<RuneBag>();
		//objInt.isRuneStone=false;
		//objInt.isRuneBag=true;//Mutually exclusive
	}

	static void SetRotation(GameObject myObj, float angle1, float angle2, float angle3)
	{
		myObj.transform.Rotate(angle1,angle2,angle3);
	}

	static void CreateDoor(GameObject myObj, string DoorTexturePath, int DoorKey, int Locked,int isOpen)
	{
		myObj.layer=LayerMask.NameToLayer("Doors");
		GameObject myInstance = Resources.Load("Models/uw1_door") as GameObject;
		GameObject newObj = (GameObject)GameObject.Instantiate(myInstance);
		ObjectInteraction doorInteract = myObj.GetComponent<ObjectInteraction>();
		doorInteract.Link = DoorKey;
		newObj.name=myObj.name + "_Model";
		newObj.transform.parent=myObj.transform;
		newObj.transform.position = myObj.transform.position;
		//newObj.GetComponent<Renderer>().material.mainTexture= Resources.Load <Texture2D> (DoorTexturePath);
		newObj.GetComponent<Renderer>().material=(Material)Resources.Load(DoorTexturePath);
			//mr.material= (Material)Resources.Load ("Materials/tmobj/tmobj_" + tmObj_index);
		newObj.GetComponent<MeshCollider>().enabled=false;
		MeshCollider mc = myObj.AddComponent<MeshCollider>();
	//	mc.convex=true;//unity 5
	//	mc.isTrigger=true;
	//	mc.sharedMesh=newObj.GetComponent<MeshFilter>().sharedMesh;
		mc = myObj.AddComponent<MeshCollider>();
		mc.isTrigger=false;
		mc.sharedMesh=newObj.GetComponent<MeshFilter>().sharedMesh;
		DoorControl dc = myObj.AddComponent<DoorControl>();
		dc.KeyIndex=DoorKey;
		dc.locked = (Locked==1);
		dc.state=(isOpen==1);	
		BoxCollider bx=myObj.GetComponent<BoxCollider>();
		bx.enabled=false;
		Component.DestroyImmediate (bx);
		switch (doorInteract.item_id)
		{
		case 320://0
		case 327:
			dc.DR=0;
			break;
		case 321://1
		case 328:
		case 322:
		case 329:
			dc.DR=1;
			break;
		case 323://2
		case 330:
		case 324://2
		case 331:
			dc.DR=2;
			break;
		case 325://3
		case 333:
			dc.DR=3;
			break;
		}
	}

	static void CreatePortcullis(GameObject myObj, int DoorKey, int Locked, int isOpen)
	{
		//GameObject myInstance = Resources.Load("Models/uw1_door") as GameObject;

		//GameObject myInstance = (GameObject)Instantiate(Resources.Load("Models/Portcullis")); ;
		GameObject newObj = (GameObject)GameObject.Instantiate((GameObject)Resources.Load("Models/Portcullis"));
		ObjectInteraction doorInteract = myObj.GetComponent<ObjectInteraction>();
		//doorInteract.isDoor=true;
		//doorInteract.ItemType=4;
		//doorInteract.item_id=-1;//ugh
		doorInteract.Link = DoorKey;
		newObj.name=myObj.name + "_Model";
		newObj.transform.parent=myObj.transform;
		newObj.transform.position = myObj.transform.position;
	
		BoxCollider box  =myObj.GetComponent<BoxCollider>();
		box.enabled=false;
		//newObj.GetComponent<Renderer>().material.mainTexture= Resources.Load <Texture2D> (DoorTexturePath);
		//newObj.GetComponent<MeshCollider>().enabled=false;
		//MeshCollider mc = myObj.AddComponent<MeshCollider>();
		//mc.convex=true;//unity 5
		//mc.isTrigger=true;
		//mc.sharedMesh=newObj.GetComponent<MeshFilter>().sharedMesh;
		//mc = myObj.AddComponent<MeshCollider>();
		//mc.isTrigger=false;
		//mc.sharedMesh=newObj.GetComponent<MeshFilter>().sharedMesh;
		DoorControl dc = myObj.AddComponent<DoorControl>();
		dc.KeyIndex=DoorKey;
		dc.locked = (Locked==1);
		dc.isPortcullis=true;
		dc.state=(isOpen==1);
	}



	static void CreateShockBridge(GameObject myObj, string TopTexturePath, string SideTexturePath, int Height, int xSize, int ySize)
	{
		GameObject myInstance = Resources.Load("Models/shock_bridge") as GameObject;
		GameObject newObj = (GameObject)GameObject.Instantiate(myInstance);
		newObj.name=myObj.name + "_Model";
		newObj.transform.parent=myObj.transform;
		newObj.transform.position = myObj.transform.position;
		Texture2D TopTexture= Resources.Load <Texture2D> (TopTexturePath);
		Texture2D SideTexture= Resources.Load <Texture2D> (SideTexturePath);
		//newObj.GetComponent<MeshCollider>().enabled=false;
		MeshCollider mc = newObj.AddComponent<MeshCollider>();//was myObj
		mc.sharedMesh=newObj.GetComponent<MeshFilter>().sharedMesh;

		Material[] myMat = newObj.GetComponent<Renderer>().materials;
		//Debug.Log ("Upperbound is " + myMat.GetUpperBound(0));
		for (int i = 0; i<=myMat.GetUpperBound(0);i++)
		{
			if(myMat[i].mainTexture.name=="citmat_2180_0000")
			{
				myMat[i].mainTexture=TopTexture;
			}
			else
			{
				myMat[i].mainTexture=SideTexture;
			}
		}
	}

	static void CreateElephantJorp(GameObject myObj)
	{
		loadGameObjectResourceAsModel(myObj,"Models/elephant");
		/*GameObject myInstance = Resources.Load("Models/elephant") as GameObject;
		GameObject newObj = (GameObject)GameObject.Instantiate(myInstance);
		newObj.name=myObj.name + "_Model";
		newObj.transform.parent=myObj.transform;
		newObj.transform.position = myObj.transform.position;*/
	}

	static void CreateForceBridge(GameObject myObj)
	{
		loadGameObjectResourceAsModel(myObj,"Models/force_bridge");
		/*GameObject myInstance = Resources.Load("Models/force_bridge") as GameObject;
		GameObject newObj = (GameObject)GameObject.Instantiate(myInstance);
		newObj.name=myObj.name + "_Model";
		newObj.transform.parent=myObj.transform;
		newObj.transform.position = myObj.transform.position;*/
	}

	static void CreateForceDoor(GameObject myObj)
	{
		loadGameObjectResourceAsModel(myObj,"Models/force_door");
		/*GameObject myInstance = Resources.Load("Models/force_door") as GameObject;
		GameObject newObj = (GameObject)GameObject.Instantiate(myInstance);
		newObj.name=myObj.name + "_Model";
		newObj.transform.parent=myObj.transform;
		newObj.transform.position = myObj.transform.position;*/
	}

	static void CreateGreatLord(GameObject myObj)
	{
		loadGameObjectResourceAsModel(myObj,"Models/GreatLordSnaq");
		/*GameObject myInstance = Resources.Load("Models/GreatLordSnaq") as GameObject;
		GameObject newObj = (GameObject)GameObject.Instantiate(myInstance);
		newObj.name=myObj.name + "_Model";
		newObj.transform.parent=myObj.transform;
		newObj.transform.position = myObj.transform.position;*/
	}

	static void loadGameObjectResourceAsModel(GameObject myObj, string path)
	{
		GameObject myInstance = Resources.Load(path) as GameObject;
		GameObject newObj = (GameObject)GameObject.Instantiate(myInstance);
		newObj.name=myObj.name + "_Model";
		newObj.transform.parent=myObj.transform;
		newObj.transform.position = myObj.transform.position;
	}

	static void CreateShockDoor(GameObject myObj, int DoorKey, int Locked, int DoorSpriteIndex)
	{
		/*GameObject myInstance = Resources.Load("Models/uw1_door") as GameObject;
		GameObject newObj = (GameObject)GameObject.Instantiate(myInstance);
		ObjectInteraction doorInteract = myObj.AddComponent<ObjectInteraction>();
		doorInteract.isDoor=true;
		doorInteract.ItemType=4;
		doorInteract.item_id=-1;//ugh
		doorInteract.Link = DoorKey;
		newObj.name=myObj.name + "_Model";
		newObj.transform.parent=myObj.transform;
		newObj.transform.position = myObj.transform.position;
		newObj.renderer.material.mainTexture= Resources.Load <Texture2D> (DoorTexturePath);
		newObj.GetComponent<MeshCollider>().enabled=false;*/
		/*MeshCollider mc = myObj.AddComponent<MeshCollider>();
		mc.isTrigger=true;
		mc.sharedMesh=newObj.GetComponent<MeshFilter>().sharedMesh;
		mc = myObj.AddComponent<MeshCollider>();
		mc.isTrigger=false;
		mc.sharedMesh=newObj.GetComponent<MeshFilter>().sharedMesh;*/
		DoorControlShock dc = myObj.AddComponent<DoorControlShock>();
		dc.KeyIndex=DoorKey;
		dc.locked = (Locked==1);
		dc.DoorSpriteIndex=DoorSpriteIndex;
		switch (DoorSpriteIndex)
		{
		case 2400: dc.NoOfFrames=7; break;
		case 2401: dc.NoOfFrames=8; break;
		case 2402: dc.NoOfFrames=8; break;
		case 2404: dc.NoOfFrames=8; break;
		case 2405: dc.NoOfFrames=6; break;
		case 2406: dc.NoOfFrames=6; break;
		case 2407: dc.NoOfFrames=8; break;
		case 2408: dc.NoOfFrames=6; break;
		case 2423: dc.NoOfFrames=8; break;
		case 2424: dc.NoOfFrames=6; break;
		case 2426: dc.NoOfFrames=7; break;
		case 2427: dc.NoOfFrames=7; break;
		case 2428: dc.NoOfFrames=8; break;
		case 2429: dc.NoOfFrames=8; break;
		case 2431: dc.NoOfFrames=8; break;
		case 2432: dc.NoOfFrames=8; break;
		case 2433: dc.NoOfFrames=7; break;
		case 2437: dc.NoOfFrames=5; break;
		case 2438: dc.NoOfFrames=6; break;
		case 2439: dc.NoOfFrames=6; break;
		default:
			Debug.Log("Unknown door: " +DoorSpriteIndex);
			dc.NoOfFrames=7; 
			break;
		}

		AddBoxCollider (myObj, 0.0f, 0.025f, 0.0f, 0.64f, 0.05f, 0.01f,true);
		AddBoxCollider (myObj, 0.0f, 0.615f, 0.0f, 0.64f, 0.05f, 0.01f,true);
		AddBoxCollider (myObj, -0.3f, 0.317f, 0.0f, 0.05f, 0.55f,0.01f,true);
		AddBoxCollider (myObj, 0.3f, 0.317f, 0.0f, 0.05f, 0.55f, 0.01f,true);

	}


	static void AddBoxCollider(GameObject myObj, float CentreX, float CentreY, float CentreZ, float DimX, float DimY, float DimZ, bool IsTrigger)
	{
		BoxCollider bc = myObj.AddComponent<BoxCollider>();
		bc.center=new Vector3(CentreX, CentreY, CentreZ);
		bc.size=new Vector3(DimX , DimY , DimZ);
		bc.isTrigger=IsTrigger;
	}
	static void CreateKey(GameObject myObj, int KeyId)
	{
		//ObjectInteraction objInt = myObj.GetComponent<ObjectInteraction>();
		//objInt.isKey=true;
		//objInt.Owner=KeyId;
		DoorKey dk = myObj.AddComponent<DoorKey>();
		dk.KeyId=KeyId;
	}

	static void SetLink(GameObject myObj, int link)
	{
		ObjectInteraction objInt = myObj.GetComponent<ObjectInteraction>();
		if (objInt==null)
		{
			//Try in the children
			objInt=myObj.GetComponentInChildren<ObjectInteraction>();
		}
		if (objInt!=null)
		{
			objInt.Link = link;
		}
		else
		{
			Debug.Log ("Unable to SetLink " + myObj.name);
		}
	}

	static void SetSprite(GameObject myObj, string AssetPath)
	{
		SpriteRenderer mysprite = myObj.GetComponentInChildren<SpriteRenderer>();//Adds the sprite gameobject
		Sprite image = Resources.Load <Sprite> (AssetPath);//Loads the sprite.
		mysprite.sprite = image;//Assigns the sprite to the object.
	}

	
	static void SetPortcullis(GameObject myObj, bool isPortcullis)
	{
		myObj.GetComponent<DoorControl>().isPortcullis= isPortcullis;
	}

	static void CreateCollider(GameObject myObj, float x, float y, float z)
	{
		BoxCollider box=myObj.AddComponent<BoxCollider>();
		box.transform.position = myObj.transform.position;
		box.transform.localScale = new Vector3(x, y, z);
		box.isTrigger=true;
	}

	static void CreateColliderChild(GameObject myObj, float x, float y, float z)
	{
		GameObject myObjChild = new GameObject(myObj.name + "_collider");
		myObjChild.transform.position = myObj.transform.position;
		myObjChild.transform.parent = myObj.transform;

		BoxCollider box=myObjChild.AddComponent<BoxCollider>();
		box.transform.position =myObjChild.transform.position;
		box.transform.localScale = new Vector3(x, y, z);
		box.isTrigger=true;
	}

	static void CreateCollider(GameObject myObj, float x, float y, float z, bool isTrigger)
	{
		BoxCollider box=myObj.AddComponent<BoxCollider>();
		box.transform.position = myObj.transform.position;
		box.transform.localScale = new Vector3(x, y, z);
		box.isTrigger=isTrigger;
	}


	static void CreateCollider(GameObject myObj, float posX, float posY, float posZ, float dimX, float dimY, float dimZ, bool isTrigger)
	{
		BoxCollider box=myObj.AddComponent<BoxCollider>();
		box.center = new Vector3 (posX,posY,posZ);
		box.size= new Vector3(dimX, dimY, dimZ);
		//box.transform.position = new Vector3 (posX,posY,posZ);
		//box.transform.localScale = new Vector3(dimX, dimY, dimZ);
		box.isTrigger=isTrigger;
	}

	static void CreateColliderChild(GameObject myObj, float x, float y, float z, bool isTrigger)
	{
		GameObject myObjChild = new GameObject(myObj.name + "_collider");
		myObjChild.transform.position = myObj.transform.position;
		myObjChild.transform.parent = myObj.transform;
		
		BoxCollider box=myObjChild.AddComponent<BoxCollider>();
		box.transform.position =myObjChild.transform.position;
		box.transform.localScale = new Vector3(x, y, z);
		box.isTrigger=isTrigger;
	}

	static void CreateTMAP(GameObject myObj, string AssetPath, string trigger, int TextureIndex, bool isAnimated)
	{
		GameObject SpriteController = GameObject.CreatePrimitive(PrimitiveType.Quad); // new GameObject(myObj.name + "_quad");
		SpriteController.name = myObj.name + "_quad";
		SpriteController.transform.position = myObj.transform.position;
		SpriteController.layer=LayerMask.NameToLayer("UWObjects");
		//SpriteController.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
		SpriteController.transform.parent = myObj.transform;
		//SpriteController.transform.localScale=new Vector3(0.9375f,0.9375f,1.0f);
		SpriteController.transform.localScale=new Vector3(1.2f,1.2f,1.0f);
		SpriteController.transform.localPosition=new Vector3(0.0f,0.6f,0.0f);
		MeshRenderer mr = SpriteController.GetComponent<MeshRenderer>();
		mr.material= (Material)Resources.Load ("UW1/Materials/tmap/" + AssetPath);
		//SpriteRenderer mysprite = SpriteController.AddComponent<SpriteRenderer>();//Adds the sprite gameobject
		//if (isAnimated)
		//{//Use the palette cycle shader
			
		//}
		//else
		//{
			
		//}

		///////Sprite image = Resources.Load <Sprite> (AssetPath);//Loads the sprite.
		///////mysprite.sprite = image;//Assigns the sprite to the object.
		////////mysprite.material= Resources.Load<Material>("Materials/tmap");
//		Material myMaterial = Resources.Load("Materials/tmap", typeof(Material)) as Material;
//		mysprite.material  = myMaterial;
		TMAP tm = myObj.AddComponent<TMAP>();
		tm.trigger=trigger;
		tm.TextureIndex=TextureIndex;
		//tm.isAnimated=isAnimated;
		BoxCollider bx = myObj.AddComponent<BoxCollider>();
		bx.size=new Vector3(1.25f,1.25f,0.1f);
		bx.center=new Vector3(0.0f,0.65f,0.0f);
		bx.isTrigger=true;
	}

	static void AddTrapLink(GameObject myObj, string Trigger)
	{
		//ObjectVariables myvars= myObj.GetComponent<ObjectVariables>();
		//myvars.trigger=Trigger;
		trap_base tb= myObj.GetComponent<trap_base>();

		tb.TriggerObject=Trigger;
	}

	static void SetButtonProperties(GameObject myObj, int on, string SpriteOn, string SpriteOff)
	{
		ButtonHandler BH = myObj.GetComponentInChildren<ButtonHandler>();
		if (BH != null)
		{
			BH.isOn= (on==1);
			BH.spriteOn=SpriteOn;
			BH.spriteOff=SpriteOff;
		}
	}

	static void SetButtonProperties(GameObject myObj, string Sprite0, string Sprite1, string Sprite2, string Sprite3, string Sprite4, string Sprite5, string Sprite6, string Sprite7)
	{
		ButtonHandler BH = myObj.GetComponentInChildren<ButtonHandler>();
		if (BH != null)
		{
			BH.isRotarySwitch=true;
			BH.RotarySprites[0]=Sprite0;
			BH.RotarySprites[1]=Sprite1;
			BH.RotarySprites[2]=Sprite2;
			BH.RotarySprites[3]=Sprite3;
			BH.RotarySprites[4]=Sprite4;
			BH.RotarySprites[5]=Sprite5;
			BH.RotarySprites[6]=Sprite6;
			BH.RotarySprites[7]=Sprite7;
		}
	}



	static void SetScale(GameObject myObj, float x, float y, float z)
	{
		myObj.transform.localScale=new Vector3(x,y,z);
	}


	static void CreateNull_Trigger(GameObject myObj, int TriggerAction, int TriggerOnce, int Condition0,int Condition1,int Condition2,int Condition3)
	{
		Null_Trigger nt =myObj.AddComponent<Null_Trigger>();
		nt.TriggerAction=TriggerAction;
		if (TriggerOnce ==0)
		{
			nt.TriggerOnce=false;
		}
		else
		{
			nt.TriggerOnce=true;
		}
		nt.conditions[0]=Condition0;
		nt.conditions[1]=Condition1;
		nt.conditions[2]=Condition2;
		nt.conditions[3]=Condition3;

	}


	static void CreateEntry_Trigger(GameObject myObj, int TriggerAction, int TriggerOnce, int Condition0,int Condition1,int Condition2,int Condition3)
	{
		Entry_Trigger nt =myObj.AddComponent<Entry_Trigger>();
		nt.TriggerAction=TriggerAction;
		if (TriggerOnce ==0)
		{
			nt.TriggerOnce=false;
		}
		else
		{
			nt.TriggerOnce=true;
		}
		nt.conditions[0]=Condition0;
		nt.conditions[1]=Condition1;
		nt.conditions[2]=Condition2;
		nt.conditions[3]=Condition3;
		
	}


	static void AddACTION_CHOICE(GameObject myObj, string ActivateTrue, string ActivateFalse)
	{
		Action_Choice ac= myObj.AddComponent<Action_Choice>();
		ac.ActivateTrue=ActivateTrue;
		ac.ActivateFalse=ActivateFalse;
	}

	static void AddACTION_LIGHTING(GameObject myObj)
	{
		myObj.AddComponent<Action_Lighting>();
	}

	static void AddACTION_ACTIVATE(GameObject myObj, string objAct0, int objWait0, string objAct1, int objWait1, string objAct2, int objWait2, string objAct3, int objWait3)
	{
		Action_Activate aa = myObj.AddComponent<Action_Activate>();
		aa.ObjectsToActivate[0]= objAct0;
		aa.ActivationDelay[0]=objWait0;
		aa.ObjectsToActivate[1]= objAct1;
		aa.ActivationDelay[1]=objWait1;
		aa.ObjectsToActivate[2]= objAct2;
		aa.ActivationDelay[2]=objWait2;
		aa.ObjectsToActivate[3]= objAct3;
		aa.ActivationDelay[3]=objWait3;
	}

	static void AddACTION_TIMER(GameObject myObj)
	{
		myObj.AddComponent<Action_Timer>();
	}

	static void AddACTION_DO_NOTHING(GameObject myObj)
	{
		myObj.AddComponent<Action_Do_Nothing>();
	}

	static void AddACTION_DO_NOTHING(GameObject myObj, string TriggerObj)
	{
		Action_Do_Nothing dn= myObj.AddComponent<Action_Do_Nothing>();
		dn.ObjectToActivate=TriggerObj;
	}
	
	static void AddACTION_MOVING_PLATFORM(GameObject myObj, int TileX, int TileY, int targetFloor, int targetCeiling, int flag)
	{
		Action_Moving_Platform mp = myObj.AddComponent<Action_Moving_Platform>();
		mp.TileX=TileX;
		mp.TileY=TileY;
		mp.TargetFloorHeight=targetFloor;
		mp.TargetCeilingHeight=targetCeiling;
		mp.Flag=flag;
	}

	static void AddACTION_SET_VARIABLE(GameObject myObj)
	{
		myObj.AddComponent<Action_Set_Variable>();
	}

	static void AddACTION_CHANGE_STATE(GameObject myObj,string ObjectToActivate, int NewState)
	{
		Action_Change_State ac = myObj.AddComponent<Action_Change_State>();
		ac.ObjectToActivate=ObjectToActivate;
		ac.NewState=NewState;
	}

	static void AddACTION_SPAWN(GameObject myObj)
	{
		myObj.AddComponent<Action_Spawn>();
	}

	static void AddACTION_MESSAGE(GameObject myObj, int SuccessMessage, int FailMessage)
	{
		Action_Message am = myObj.AddComponent<Action_Message>();
		am.SuccessMessage=SuccessMessage;
		am.FailMessage=FailMessage;
		AudioSource aus = myObj.AddComponent<AudioSource>();
		aus.playOnAwake=false;
	}

	static void AddACTION_CHANGE_TYPE(GameObject myObj, string ObjectToChange, int ObjectClass, int ObjectSubClass, int SubClassIndex)
	{
		Action_Change_Type act = myObj.AddComponent<Action_Change_Type>();
		act.ObjectClass=ObjectClass;
		act.ObjectToChange=ObjectToChange;
		act.SubClass=ObjectSubClass;
		act.SubClassIndex=SubClassIndex;
	}

	static void AddACTION_EMAIL(GameObject myObj)
	{
		myObj.AddComponent<Action_Email>();
	}

	static void AddACTION_RESURRECTION(GameObject myObj)
	{
		myObj.AddComponent<Action_Resurrection>();
	}

	static void AddACTION_UNKNOWN(GameObject myObj)
	{
		Debug.Log (myObj.name + " ACTION UNKNOWN!!");
		myObj.AddComponent<Action_Default>();
	}

	static void AddACTION_CLONE(GameObject myObj)
	{
		myObj.AddComponent<Action_Clone>();
	}

	static void AddACTION_TRANSPORT_LEVEL(GameObject myObj)
	{
		myObj.AddComponent<Action_Transport_Level>();
	}

	static void AddACTION_AWAKEN(GameObject myObj)
	{
		myObj.AddComponent<Action_Awaken>();
	}

	static void CreateComputerScreen(GameObject myObj, int ScreenStart, int NoOfFrames, int Looping)
	{
		GameObject myInstance = Resources.Load("quad") as GameObject;
		GameObject newObj = (GameObject)GameObject.Instantiate(myInstance);
		newObj.name=myObj.name + "_quad";
		newObj.transform.parent=myObj.transform;
		newObj.transform.position=myObj.transform.position;

		ComputerScreen cs = myObj.AddComponent<ComputerScreen>();
		cs.ScreenStart=ScreenStart;
		cs.NoOfFrames=NoOfFrames;
		cs.ScreenToDisplayOn=newObj;
		if (Looping != 0)
			{
			cs.LoopFrames = true;
			}
	}

	static void CreateSurveillanceScreen(GameObject myObj, string Target)
	{
		GameObject myInstance = Resources.Load("quad") as GameObject;
		GameObject newObj = (GameObject)GameObject.Instantiate(myInstance);
		newObj.name=myObj.name + "_quad";
		newObj.transform.parent=myObj.transform;
		newObj.transform.position=myObj.transform.position;

		RemoteCamera rc = myObj.AddComponent<RemoteCamera>();
		rc.Target=Target;
		rc.ScreenToDisplayOn=newObj;
	}

	static void SetTileProp(TileMap tilemap, int tileX, int tileY, int tileType, int render, int FloorHeight, int CeilingHeight)
	{
		tilemap.tileType[tileX,tileY]=tileType;
		tilemap.Render[tileX,tileY]=render;
		tilemap.FloorHeight[tileX,tileY]=FloorHeight;
		tilemap.CeilingHeight[tileX,tileY]=CeilingHeight;
		//, x, y, LevelInfo[x][y].tileType, LevelInfo[x][y].Render, LevelInfo[x][y].floorHeight, LevelInfo[x][y].ceilingHeight);
	}

	static void CreateWords(GameObject myObj, int stringNo, int font, int size, int colour)
		{
		Words wd = myObj.AddComponent<Words>();
		wd.StringNo=stringNo;
		wd.font=font;
		wd.size=size;
		wd.colour=colour;
		wd.BlockNo=2152;
		}

	static void CreateRepulsor(GameObject myObj,float displacement, bool isOn, float posX, float posY, float posZ, float dimX, float dimY, float dimZ)
	{
		//GameObject myObjChild = new GameObject(myObj.name + "_repulsor");
		//myObjChild.transform.position = myObj.transform.position;
		//myObjChild.transform.parent = myObj.transform;
		Repulsor rp = myObj.AddComponent<Repulsor>();
		rp.TargetHeight=displacement;
		rp.RepulsorOn=isOn;
		CreateCollider (myObj,posX,posY,posZ,dimX,dimY,dimZ,true);
	}

	static void SetReadable(GameObject myObj)
	{

		ObjectInteraction objINt = myObj.GetComponent<ObjectInteraction>();

		if (objINt.item_id==276)
		{
			myObj.AddComponent<ReadableTrap>();
		}
		else
		{
			myObj.AddComponent<Readable>();
		}

		objINt.isQuant=false;//?j
	}

	static void SetInventoryIcon(GameObject myObj, string SpriteName, string AssetPath)
	{
		ObjectInteraction objInt = myObj.GetComponent<ObjectInteraction>();
		if (objInt != null)
			{
			//Sprite image = Resources.Load <Sprite> (AssetPath);//Loads the sprite.
			//objInt.InventoryDisplay = image;//Assigns the sprite to the object.
//			objInt.InventoryString=SpriteName;
			}
	}

	static void SetFood(GameObject myObj)
	{
		Food fd = myObj.AddComponent<Food>();
		fd.Nutrition=5;//TODO:determine values to use here.
	}

	static void SetMap(GameObject myObj)
	{
		myObj.AddComponent<Map>();
	}


	static void FreezeMovement(GameObject myObj)
	{//Stop objects which can move in the 3d world from moving when they are in the inventory or containers.
		Rigidbody rg = myObj.GetComponent<Rigidbody>();
		if (rg!=null)
		{
			rg.useGravity=false;
			rg.constraints = 
				RigidbodyConstraints.FreezeRotationX 
					| RigidbodyConstraints.FreezeRotationY 
					| RigidbodyConstraints.FreezeRotationZ 
					| RigidbodyConstraints.FreezePositionX 
					| RigidbodyConstraints.FreezePositionY 
					| RigidbodyConstraints.FreezePositionZ;
		}
	}

	static void CreateHelm(GameObject myObj, string FemaleLowest, string MaleLowest, string FemaleLow, string MaleLow, string FemaleMedium, string MaleMedium, string FemaleBest,string MaleBest, int Protection, int Durability)
	{
		Helm newcomp =myObj.AddComponent<Helm>();
		/*newcomp.EquipFemaleLowest=FemaleLowest;
		newcomp.EquipFemaleLow=FemaleLow;
		newcomp.EquipFemaleMedium=FemaleMedium;
		newcomp.EquipFemaleBest=FemaleBest;
		newcomp.EquipMaleLowest=MaleLowest;
		newcomp.EquipMaleLow=MaleLow;
		newcomp.EquipMaleMedium=MaleMedium;
		newcomp.EquipMaleBest=MaleBest;*/
		newcomp.Durability =Durability;
		newcomp.Protection=Protection;
	}

	static void CreateGloves(GameObject myObj, string FemaleLowest, string MaleLowest, string FemaleLow, string MaleLow, string FemaleMedium, string MaleMedium, string FemaleBest,string MaleBest, int Protection, int Durability)
	{
		Gloves newcomp =myObj.AddComponent<Gloves>();
		/*newcomp.EquipFemaleLowest=FemaleLowest;
		newcomp.EquipFemaleLow=FemaleLow;
		newcomp.EquipFemaleMedium=FemaleMedium;
		newcomp.EquipFemaleBest=FemaleBest;
		newcomp.EquipMaleLowest=MaleLowest;
		newcomp.EquipMaleLow=MaleLow;
		newcomp.EquipMaleMedium=MaleMedium;
		newcomp.EquipMaleBest=MaleBest;*/
		newcomp.Durability =Durability;
		newcomp.Protection=Protection;

	}

	static void CreateArmour(GameObject myObj, string FemaleLowest, string MaleLowest, string FemaleLow, string MaleLow, string FemaleMedium, string MaleMedium, string FemaleBest,string MaleBest, int Protection, int Durability)
	{
		Armour newcomp =myObj.AddComponent<Armour>();
		/*newcomp.EquipFemaleLowest=FemaleLowest;
		newcomp.EquipFemaleLow=FemaleLow;
		newcomp.EquipFemaleMedium=FemaleMedium;
		newcomp.EquipFemaleBest=FemaleBest;
		newcomp.EquipMaleLowest=MaleLowest;
		newcomp.EquipMaleLow=MaleLow;
		newcomp.EquipMaleMedium=MaleMedium;
		newcomp.EquipMaleBest=MaleBest;*/
		newcomp.Durability =Durability;
		newcomp.Protection=Protection;

	}

	static void CreateLeggings(GameObject myObj, string FemaleLowest, string MaleLowest, string FemaleLow, string MaleLow, string FemaleMedium, string MaleMedium, string FemaleBest,string MaleBest, int Protection, int Durability)
	{
		Leggings newcomp =myObj.AddComponent<Leggings>();
	/*	newcomp.EquipFemaleLowest=FemaleLowest;
		newcomp.EquipFemaleLow=FemaleLow;
		newcomp.EquipFemaleMedium=FemaleMedium;
		newcomp.EquipFemaleBest=FemaleBest;
		newcomp.EquipMaleLowest=MaleLowest;
		newcomp.EquipMaleLow=MaleLow;
		newcomp.EquipMaleMedium=MaleMedium;
		newcomp.EquipMaleBest=MaleBest;*/
		newcomp.Durability =Durability;
		newcomp.Protection=Protection;

	}

	static void CreateBoots(GameObject myObj, string FemaleLowest, string MaleLowest, string FemaleLow, string MaleLow, string FemaleMedium, string MaleMedium, string FemaleBest,string MaleBest, int Protection, int Durability)
	{
		Boots newcomp =myObj.AddComponent<Boots>();
		/*newcomp.EquipFemaleLowest=FemaleLowest;
		newcomp.EquipFemaleLow=FemaleLow;
		newcomp.EquipFemaleMedium=FemaleMedium;
		newcomp.EquipFemaleBest=FemaleBest;
		newcomp.EquipMaleLowest=MaleLowest;
		newcomp.EquipMaleLow=MaleLow;
		newcomp.EquipMaleMedium=MaleMedium;
		newcomp.EquipMaleBest=MaleBest;*/
		newcomp.Durability =Durability;
		newcomp.Protection=Protection;

	}


	static Container CreateContainer(GameObject myObj, int Capacity, int NoOfSlots, int ObjectsAccepted)
	{
		Container cn = myObj.AddComponent<Container>();
		//cn.NoOfSlots = NoOfSlots;
		if (Capacity==0)
		{//Unlimited??
			Capacity=40;
		}
		else
		{
			cn.Capacity= Capacity;
		}

		cn.ObjectsAccepted=ObjectsAccepted;

		return cn;
	}

	static void CreateLight(GameObject myObj, int Brightness, int Duration , int ItemIDOn, int ItemIDOff)
	{
		LightSource ls = myObj.AddComponent<LightSource>();
		ls.Brightness=Brightness;
		//ls.Duration=Duration;
		ls.ItemIdOn=ItemIDOn;
		ls.ItemIdOff=ItemIDOff;
	}

	static void CreateLantern(GameObject myObj, int Brightness, int Duration , int ItemIDOn, int ItemIDOff)
	{
		LightSource ls = myObj.AddComponent<Lantern>();
		ls.Brightness=Brightness;
		//ls.Duration=Duration;
		ls.ItemIdOn=ItemIDOn;
		ls.ItemIdOff=ItemIDOff;
	}

	static void CreateWeaponMelee(GameObject myObj, int Slash, int Bash, int Stab, int Skill, int Durability)
	{
		WeaponMelee wp = myObj.AddComponent<WeaponMelee>();
		wp.Slash=Slash;
		wp.Bash=Bash;
		wp.Stab=Stab;
		wp.Skill=Skill;
		wp.Durability=Durability;
	}

	static void CreateWeaponRanged(GameObject myObj, int ammoType)
	{
		WeaponRanged wp = myObj.AddComponent<WeaponRanged>();
		wp.AmmoType=ammoType;

	}

	static void SetTileTag(int tileX, int tileY, string tag , int iRender)
	{
		if (iRender==1)
		{
			GameObject tile = GameObject.Find ("Tile_" + tileX.ToString ("00")+ "_" + tileY.ToString ("00"));
			if (tile != null)
			{
			tile.tag =tag;
				switch (tag.Substring(0,4))
				{
				case "WATE":
					tile.layer=LayerMask.NameToLayer ("Water");
					break;
				case "SOLI":
				case "LAND":
					tile.layer=LayerMask.NameToLayer ("MapMesh");
					break;
				case "LAVA":
					tile.layer=LayerMask.NameToLayer ("Lava");
					break;
				}

			}
		}
	}

	static void SetObjectTag(string ObjectName, string tag)
	{
		GameObject tile = GameObject.Find (ObjectName);
		if (tile != null)
		{
			tile.tag =tag;
		}
	}

	static void SetTileTag(int tileX, int tileY, int itileType, int iRender, int FloorHeight, int CeilingHeight, int iIsWater, int iIsDoor, int iIsBridge)
	{
		if (iRender==1)
		{
			GameObject tile = GameObject.Find ("Tile_" + tileX.ToString ("00")+ "_" + tileY.ToString ("00"));
			if (tile != null)
			{
				if (iIsWater==1)
				{
					tile.tag ="WATER";
				}
				else
				{
					tile.tag="TileType:"+itileType;
				}
			}
		}
	}

	static void SetNPCProps(GameObject myObj, 
	                        int npc_whoami, int npc_xhome, int npc_yhome,
	                        int npc_hunger, int npc_health,
	                        int npc_hp, int npc_arms, int npc_power ,
	                        int npc_goal, int npc_attitude, int npc_gtarg,
	                        int npc_talkedto, int npc_level,int npc_name,
	                        string NavMeshRegion
	                        )
	{
		NPC npc = myObj.GetComponent<NPC>();
		if (npc!=null)
		{

			if ((npc.npc_whoami==0) && (npc_whoami  != 0))
			{
				npc.npc_whoami= npc_whoami;
			}
			npc.npc_xhome=npc_xhome;        //  x coord of home tile
			npc.npc_yhome=npc_yhome;        //  y coord of home tile
			npc.npc_hunger=npc_hunger;
			npc.npc_health=npc_health;
			npc.npc_hp=npc_hp;
			npc.npc_arms=npc_arms;          // (not used in uw1)
			npc.npc_power=npc_power;
			npc.npc_goal=npc_goal;          // goal that NPC has; 5:kill player 6:? 9:?
			npc.npc_attitude=npc_attitude;       //attitude; 0:hostile, 1:upset, 2:mellow, 3:friendly
			npc.npc_gtarg=npc_gtarg;         //goal target; 1:player
			npc.npc_talkedto=npc_talkedto;      // is 1 when player already talked to npc
			npc.npc_level=npc_level;
			npc.npc_name=npc_name;       //    (not used in uw1)
			//npc.npc_deathvariable=npc_deathVariable;
			npc.NavMeshRegion=NavMeshRegion;

			//if (npc_attitude!=0)
			//{
			Conversation cnv ;//= myObj.AddComponent<Conversation>();
			cnv=null;
			//if (npc_whoami == 0)
			//{
			//	npc_whoami=256+(int.Parse (NPC_ID) -64);
			//}
			//TODO:Make sure all conversations are added here as implemented.
			switch (myObj.GetComponent<NPC>().npc_whoami)
			{
			case 0:
			case 207://A worried spectre named warren
			case 248://Slasher of veils
			case 255://No conversation/monsters
			case 256:
			case 257:
			case 258:
			case 259:
			case 261:
			case 264:
			case 265:
			case 266:
			case 267:
			case 270:
			case 273:
			case 274:
			case 275:
			case 279:
			case 284:
			case 283:
			case 289:
			case 292:
			case 293:
			case 294:
			case 297:
			case 298:
			case 302:
			case 303:
			case 304:
			case 305:
			case 306:
			case 308:
			case 309:
			case 310:
			case 311:
			case 312:
			case 313:
				break;
			case 1://Corby
				cnv=(Conversation)myObj.AddComponent<Conversation_1>();break;
			case 2://Shak
				cnv=(Conversation)myObj.AddComponent<Conversation_2>();break;
			case 3://Goldthirst
				cnv=(Conversation)myObj.AddComponent<Conversation_3>();break;
			case 4://Shanlick
				cnv=(Conversation)myObj.AddComponent<Conversation_4>();break;
			case 5://Eyesnack
				cnv=(Conversation)myObj.AddComponent<Conversation_5>();break;
			case 6://Marrowsuck
				cnv=(Conversation)myObj.AddComponent<Conversation_6>();break;
			case 7://Ketchaval
				cnv=(Conversation)myObj.AddComponent<Conversation_7>();break;
			case 8://Retichall
				cnv=(Conversation)myObj.AddComponent<Conversation_8>();break;
			case 9://Vernix
				cnv=(Conversation)myObj.AddComponent<Conversation_9>();break;
			case 10://Lanugo
				cnv=(Conversation)myObj.AddComponent<Conversation_10>();break;
			case 12:// Dorna Ironfist
				cnv=(Conversation)myObj.AddComponent<Conversation_12>();break;
			case 13:// Morlock
				cnv=(Conversation)myObj.AddComponent<Conversation_13>();break;
			case 14:// Dr Owl
				cnv=(Conversation)myObj.AddComponent<Conversation_14>();break;
			case 15://Sseetharee
				cnv=(Conversation)myObj.AddComponent<Conversation_15>();break;
			case 16://Ishtass
				cnv=(Conversation)myObj.AddComponent<Conversation_16>();break;
			case 17://Sethar Strongarm
				cnv=(Conversation)myObj.AddComponent<Conversation_17>();break;
			case 18://Lakshi Longtooth
				cnv=(Conversation)myObj.AddComponent<Conversation_18>();break;
			case 19://Hagbard
				cnv=(Conversation)myObj.AddComponent<Conversation_19>();break;
			case 20://Gulik
				cnv=(Conversation)myObj.AddComponent<Conversation_20>();break;
			case 21://Steeltoe
				cnv=(Conversation)myObj.AddComponent<Conversation_21>();break;
			case 22://Golem
				cnv=(Conversation)myObj.AddComponent<Conversation_22>();break;
			case 23://Judy
				cnv=(Conversation)myObj.AddComponent<Conversation_23>();break;
			case 24://prisoner
				cnv=(Conversation)myObj.AddComponent<Conversation_24>();break;
			case 25://Talking door
				cnv=(Conversation)myObj.AddComponent<Conversation_25>();break;
			case 27://Garamon
				cnv=(Conversation)myObj.AddComponent<Conversation_27>();break;
			case 28://Zak
				cnv=(Conversation)myObj.AddComponent<Conversation_28>();break;
			case 64://Jaacar
				cnv=(Conversation)myObj.AddComponent<Conversation_64>();break;
			case 65://Eb
				cnv=(Conversation)myObj.AddComponent<Conversation_65>();break;
			case 66://Drog
				cnv=(Conversation)myObj.AddComponent<Conversation_66>();break;
			case 67://Bragit
				cnv=(Conversation)myObj.AddComponent<Conversation_67>();break;
			case 88://Brawnclan
				cnv=(Conversation)myObj.AddComponent<Conversation_88>();break;
			case 89://Hewstone
				cnv=(Conversation)myObj.AddComponent<Conversation_89>();break;
			case 90://Ironwit
				cnv=(Conversation)myObj.AddComponent<Conversation_90>();break;
			case 112://bandit
				cnv=(Conversation)myObj.AddComponent<Conversation_112>();break;
			case 113://bandit
				cnv=(Conversation)myObj.AddComponent<Conversation_113>();break;
			case 114://Iss'leek
				cnv=(Conversation)myObj.AddComponent<Conversation_114>();break;
			case 136://Oradinar
				cnv=(Conversation)myObj.AddComponent<Conversation_136>();break;
			case 137://Linnet
				cnv=(Conversation)myObj.AddComponent<Conversation_137>();break;
			case 138://Derek
				cnv=(Conversation)myObj.AddComponent<Conversation_138>();break;
			case 139://Trisch
				cnv=(Conversation)myObj.AddComponent<Conversation_139>();break;
			case 140://Ree
				cnv=(Conversation)myObj.AddComponent<Conversation_140>();break;
			case 141://Feznor
				cnv=(Conversation)myObj.AddComponent<Conversation_141>();break;
			case 142://Rodrick
				cnv=(Conversation)myObj.AddComponent<Conversation_142>();break;
			case 143://Biden
				cnv=(Conversation)myObj.AddComponent<Conversation_143>();break;
			case 144://Rawstag
				cnv=(Conversation)myObj.AddComponent<Conversation_144>();break;
			case 146://Doris
				cnv=(Conversation)myObj.AddComponent<Conversation_146>();break;
			case 147://Kyle
				cnv=(Conversation)myObj.AddComponent<Conversation_147>();break;
			case 148://Cecil
				cnv=(Conversation)myObj.AddComponent<Conversation_148>();break;
			case 161://Anjor
				cnv=(Conversation)myObj.AddComponent<Conversation_162>();break;
			case 162://Kneeknibble
				cnv=(Conversation)myObj.AddComponent<Conversation_162>();break;
			case 149://Meredith
				cnv=(Conversation)myObj.AddComponent<Conversation_149>();break;
			case 184://Delanrey
				cnv=(Conversation)myObj.AddComponent<Conversation_184>();break;
			case 185://Nilpont
				cnv=(Conversation)myObj.AddComponent<Conversation_185>();break;
			case 187://Illomo
				cnv=(Conversation)myObj.AddComponent<Conversation_187>();break;
			case 188://Gralwart
				cnv=(Conversation)myObj.AddComponent<Conversation_188>();break;
			case 189://Shenilor
				cnv=(Conversation)myObj.AddComponent<Conversation_189>();break;
			case 190://Bronus
				cnv=(Conversation)myObj.AddComponent<Conversation_190>();break;
			case 191://Ranthru
				cnv=(Conversation)myObj.AddComponent<Conversation_191>();break;
			case 192://Fyrgen
				cnv=(Conversation)myObj.AddComponent<Conversation_192>();break;
			case 193://Louvon
				cnv=(Conversation)myObj.AddComponent<Conversation_193>();break;
			case 194://Dominus
				cnv=(Conversation)myObj.AddComponent<Conversation_194>();break;
			case 208://Cardon
				cnv=(Conversation)myObj.AddComponent<Conversation_208>();break;
			case 209://guard (tybals lair checkpoint)
				cnv=(Conversation)myObj.AddComponent<Conversation_209>();break;
			case 210://Narutu
				cnv=(Conversation)myObj.AddComponent<Conversation_210>();break;
			case 211://Dantes
				cnv=(Conversation)myObj.AddComponent<Conversation_211>();break;
			case 212://Kallistan
				cnv=(Conversation)myObj.AddComponent<Conversation_212>();break;
			case 213://Fintor
				cnv=(Conversation)myObj.AddComponent<Conversation_213>();break;
			case 214://Bolinard
				cnv=(Conversation)myObj.AddComponent<Conversation_214>();break;
			case 215://Smonden
				cnv=(Conversation)myObj.AddComponent<Conversation_215>();break;
			case 216://guard (tybals prison troll)
				cnv=(Conversation)myObj.AddComponent<Conversation_216>();break;
			case 217://Gurstang
				cnv=(Conversation)myObj.AddComponent<Conversation_217>();break;
			case 218://guard (tybals lair checkpoint)
				cnv=(Conversation)myObj.AddComponent<Conversation_218>();break;
			case 219://guard (tybals lair checkpoint)
				cnv=(Conversation)myObj.AddComponent<Conversation_219>();break;
			case 220://guard (tybals prison)
				cnv=(Conversation)myObj.AddComponent<Conversation_220>();break;
			case 221://Imp
				cnv=(Conversation)myObj.AddComponent<Conversation_221>();break;
			case 222://guard (tybals lair)
				cnv=(Conversation)myObj.AddComponent<Conversation_222>();break;
			case 231://Tybal
				cnv=(Conversation)myObj.AddComponent<Conversation_231>();break;
			case 232://Caroso
				cnv=(Conversation)myObj.AddComponent<Conversation_232>();break;
			case 262://Generic Green Goblin
				cnv=(Conversation)myObj.AddComponent<Conversation_262>();break;
			case 263://Generic Green Goblin
				cnv=(Conversation)myObj.AddComponent<Conversation_263>();break;
			case 268://Generic Gray Goblin
				cnv=(Conversation)myObj.AddComponent<Conversation_268>();break;
			case 272://Generic Gray Goblin
				cnv=(Conversation)myObj.AddComponent<Conversation_272>();break;
			case 276://Generic Mountainman
				cnv=(Conversation)myObj.AddComponent<Conversation_276>();break;
			case 277://Generic Lizardman
				cnv=(Conversation)myObj.AddComponent<Conversation_277>();break;
			case 280://Generic Lizardman
				cnv=(Conversation)myObj.AddComponent<Conversation_280>();break;
			case 281://Generic Gray Lizardman
				cnv=(Conversation)myObj.AddComponent<Conversation_281>();break;
			case 282://Generic Outcast
				cnv=(Conversation)myObj.AddComponent<Conversation_282>();break;
			case 288://Generic Troll
				cnv=(Conversation)myObj.AddComponent<Conversation_288>();break;
			case 314://Wisp
				cnv=(Conversation)myObj.AddComponent<Conversation_288>();break;
			default:
				cnv=myObj.AddComponent<Conversation>();
				Debug.Log ("Conversation "  + myObj.GetComponent<NPC>().npc_whoami + " is not implemented for " + myObj.name );
				break;
			}			
			if (cnv!=null)
			{
				cnv.npc= npc;
			}					


		//	}
		}
	}


	static void AddAnimationOverlay(GameObject myObj, int Start, int NoOfFrames)
		{
		AnimationOverlay anim =myObj.AddComponent<AnimationOverlay>();
		anim.StartFrame=Start;
		anim.FrameNo=Start;
		anim.NoOfFrames=NoOfFrames;
	}

	static void AddObj_base(GameObject myObj)
	{
		myObj.AddComponent<object_base>();
	}

	static void AddPotion(GameObject myObj)
	{
		myObj.AddComponent<Potion>();
		ObjectInteraction objInt =myObj.GetComponent<ObjectInteraction>();
		switch (objInt.item_id)
		{
		case 316://Scrolls
		case 317:
		case 318:
		case 319:
			objInt.isEnchanted=true;
			break;
		}

	}

	static void AddLockpick(GameObject myObj)
	{
		myObj.AddComponent<LockPick>();
	}

	static void AddSilverSeed(GameObject myObj)
	{
		myObj.AddComponent<SilverSeed>();
	}

	static void AddFountain(GameObject myObj)
	{
		myObj.AddComponent<Fountain>();
	}

	static void AddShrine(GameObject myObj)
	{
		myObj.AddComponent<Shrine>();
		ObjectInteraction objInt =myObj.GetComponent<ObjectInteraction>();
		objInt.isQuant=false;
	}

	static void AddAnvil(GameObject myObj)
	{
		myObj.AddComponent<Anvil>();
	}

	static void AddShield(GameObject myObj)
	{
		myObj.AddComponent<Shield>();
	}

	static void AddPole(GameObject myObj)
	{
		myObj.AddComponent<Pole>();
	}

	static void AddSpike(GameObject myObj)
	{
		myObj.AddComponent<Spike>();
	}

	static void AddOil(GameObject myObj)
	{
		myObj.AddComponent<Oil>();
	}

	/*static void AddRefillableLantern(GameObject myObj)
	{
		myObj.AddComponent<Lantern>();
	}*/

	static void AddMagicScroll(GameObject myObj)
	{
		myObj.AddComponent<MagicScroll>();
	}

	static void AddMoonstone(GameObject myObj)
	{
		myObj.AddComponent<MoonStone>();
	}

	static void AddLeech(GameObject myObj)
	{
		myObj.AddComponent<Leech>();
	}

	static void AddRing(GameObject myObj)
	{
		myObj.AddComponent<Ring>();
	}
	static void AddWand(GameObject myObj, int SpellObjectLink, int SpellObjectQuantity)
	{
		Wand w= myObj.AddComponent<Wand>();
		w.SpellObjectLink = SpellObjectLink;
		w.SpellObjectQuantity=SpellObjectQuantity;
	}

	static void AddGrave(GameObject myObj, int tmObj_index, int GraveID)
	{
		Grave gv = myObj.AddComponent<Grave>();
		gv.GraveID=GraveID;
		myObj.layer=LayerMask.NameToLayer("MapMesh");

		GameObject SpriteController = GameObject.CreatePrimitive(PrimitiveType.Cube); // new GameObject(myObj.name + "_quad");
		SpriteController.name = myObj.name + "_cube";
		SpriteController.transform.position = myObj.transform.position;
		SpriteController.transform.rotation=myObj.transform.rotation;
		SpriteController.transform.parent = myObj.transform;
		SpriteController.transform.localScale=new Vector3(0.5f,0.5f,0.1f);
		SpriteController.transform.localPosition=new Vector3(0.0f,0.25f,0.0f);

		MeshRenderer mr = SpriteController.GetComponent<MeshRenderer>();
		mr.material= (Material)Resources.Load ("Materials/tmobj/tmobj_" + tmObj_index);

		BoxCollider bx = myObj.GetComponent<BoxCollider>();
		bx.center= new Vector3(0.0f,0.25f,0.0f);
		bx.size=new Vector3(0.5f,0.5f,0.1f);
		bx.isTrigger=false;

		bx=SpriteController.GetComponent<BoxCollider>();
		bx.enabled=false;
		Component.DestroyImmediate (bx);
		

	}

	static void AddFishingPole(GameObject myObj)
	{
		myObj.AddComponent<FishingPole>();
	}

	static void AddZanium(GameObject myObj)
	{
		myObj.AddComponent<Zanium>();
		myObj.layer=LayerMask.NameToLayer("Zanium");//TO allow collision with the player.
		myObj.GetComponent<BoxCollider>().isTrigger=true;
		GameObject newObj = new GameObject(myObj.name+"_child");

		newObj.transform.parent=myObj.transform;
		newObj.transform.localPosition=Vector3.zero;
		BoxCollider bx = newObj.AddComponent<BoxCollider>();
		bx.center=new Vector3(0.0f,0.1f,0.0f);
		bx.size=new Vector3(0.15f,0.15f,0.15f);
		newObj.layer=LayerMask.NameToLayer("UWObjects");
	}

	static void AddBedroll(GameObject myObj)
	{
		myObj.AddComponent<Bedroll>();
	}

	static void AddCoin(GameObject myObj)
	{
		myObj.AddComponent<Coin>();
	}

	static void AddInstrument(GameObject myObj)
	{
		myObj.AddComponent<Instrument>();
		AudioSource audio = myObj.AddComponent<AudioSource>();
		audio.loop=false;
		audio.playOnAwake=false;
		audio.clip=Resources.Load <AudioClip>("SFX/instrument");
	}


	static void AddDoorLink(GameObject myObj, string uselink)
	{
		DoorControl dc = myObj.GetComponent<DoorControl>();
		dc.UseLink=uselink;
	}

	static void AddBridgeLink(GameObject myObj, string BridgeTexture, string uselink, int TextureIndex)
	{
		Bridge br = myObj.AddComponent<Bridge>();
		br.TextureIndex=TextureIndex;
		br.UseLink=uselink;
		myObj.layer=LayerMask.NameToLayer("MapMesh");
		
		GameObject SpriteController = GameObject.CreatePrimitive(PrimitiveType.Cube); // new GameObject(myObj.name + "_quad");
		SpriteController.name = myObj.name + "_cube";
		SpriteController.transform.position = myObj.transform.position;
		SpriteController.transform.rotation=myObj.transform.rotation;
		SpriteController.transform.parent = myObj.transform;
		SpriteController.transform.localScale=new Vector3(1.2f,0.15f,1.2f);
		SpriteController.transform.localPosition=Vector3.zero;//new Vector3(0.0f,0.25f,0.0f);
		
		MeshRenderer mr = SpriteController.GetComponent<MeshRenderer>();
		//mr.material= (Material)Resources.Load ("Materials/tmobj/tmobj_" + tmObj_index);
		mr.material= (Material)Resources.Load (BridgeTexture);
		BoxCollider bx = myObj.GetComponent<BoxCollider>();
		bx.center=Vector3.zero; //new Vector3(0.0f,0.25f,0.0f);
		bx.size=new Vector3(1.2f,0.15f,1.2f);
		bx.isTrigger=false;
		
		bx=SpriteController.GetComponent<BoxCollider>();
		bx.enabled=false;
		Component.DestroyImmediate (bx);
	}

	static void AddPickupLink(GameObject myObj, string uselink)
	{
		object_base ob = myObj.GetComponent<object_base>();
		ob.PickupLink=uselink;
	}

}

