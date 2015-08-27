using UnityEditor;
using UnityEngine;
using System.Collections;

public class MyTools
{
	[MenuItem("MyTools/CreateGameObjects")]
	static void Create()
	{
	//	Vector3 pos = new Vector3 (58*1.2f,12*0.3f, 13*1.2f);
		//var pos = Vector3(0,0,0);
		//GameObject prefab = (GameObject)AssetDatabase.LoadAssetAtPath ("Assets/Resources/uw1_object_base.prefab", typeof(GameObject));

		////GameObject prefab = (GameObject)Resources.LoadAssetAtPath ("Assets/Resources/uw1_object_base.prefab",typeof(GameObject));
		//GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab (prefab);
		//GameObject prefab = (GameObject) Resources.Load("uw1_object_base", typeof(GameObject));
		//GameObject prefab = (GameObject)Resources.Load ("uw1_object_base.prefab", typeof(GameObject));
		///GameObject instance= GameObject.Instantiate (prefab, pos, Quaternion.identity);
		///instance.name = "Test";
		//GameObject.Instantiate ((GameObject) Resources.Load("uw1_object_base", typeof(GameObject)), pos, Quaternion.identity);
		//var prefab=Resources.LoadAssetAtPath.<GameObject>("Assets/Resources/uw1_object_base");

		//var prefab=Resources.Load("Assets/Resources/uw1_object_base.prefab",GameObject);
		
		//var prefab= Resources.LoadAssetAtPath("Assets/Resources/uw1_object_base",typeof(GameObject));
		
		//var prefab= AssetDatabase.LoadAssetAtPath("Assets/Resources/uw1_object_base.prefab",GameObject);
		//var myobj= EditorUtility.InstantiatePrefab(prefab);
		//GameObject.Instantiate( prefab,pos,Quaternion.identity);
//		GameObject test = new GameObject ("uw1_object_base");
//		test.transform.position = pos;
//		SpriteRenderer mysprite = test.AddComponent<SpriteRenderer>();
//		Sprite image = Resources.LoadAssetAtPath <Sprite> ("Sprites/objects_000.tga");
//		mysprite.sprite = image;
		//test.AddComponent (typeof(UnityEngine.Sprite));
		//var prefab=PrefabUtility.CreateEmptyPrefab("Assets/Resources/test.prefab");
		//GameObject.Instantiate( prefab,pos,Quaternion.identity);
		
		//GameObject e;
		//Vector3 pos;
		////myObj = new GameObject("special_tmap_obj_31_01_00_0535");
		////pos = new Vector3(37.885715f, 3.853347f, 1.200000f);
		///myObj.transform.position = pos;
		////CreateObjectGraphics(myObj,"Sprites/objects_366.tga",true);
		
		
		GameObject myObj;
		Vector3 pos;
		GameObject invMarker = GameObject.Find("InventoryMarker");
		Container ParentContainer;
		myObj= CreateGameObject("special_tmap_obj_31_01_00_0535",37.799999f,3.600000f,1.220000f);
		SetScale(myObj,(float)0.937500,(float)0.937500,(float)0.937500);
		CreateTMAP(myObj,"textures/tmap/uw1_039");
		SetRotation(myObj,0,180,0);
		CreateUWActivators(myObj,"ButtonHandler","a_use_trigger_99_99_00_0559",0,37,0,7,366);
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_31_01_00_0982",38.057144f,3.600000f,2.380000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_31_01_00_0983",38.228573f,3.600000f,2.057143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj= CreateGameObject("special_tmap_obj_32_01_00_0545",39.000000f,3.600000f,1.220000f);
		SetScale(myObj,(float)0.937500,(float)0.937500,(float)0.937500);
		CreateTMAP(myObj,"textures/tmap/uw1_038");
		SetRotation(myObj,0,180,0);
		CreateUWActivators(myObj,"ButtonHandler","a_use_trigger_99_99_00_0574",0,46,0,7,366);
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_33_01_00_0961",40.285717f,3.600000f,2.228571f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj= CreateGameObject("a_plant_33_01_00_0962",39.942856f,3.600000f,2.057143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_192",true);
		
		
		myObj= CreateGameObject("a_large_boulder_09_02_00_0576",11.485714f,0.300000f,2.914286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_340",true);
		
		myObj= CreateGameObject("a_blood_stain_14_02_00_0579",17.657143f,2.700000f,2.914286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_222",true);
		
		myObj= CreateGameObject("some_writing_30_02_00_0963",36.020000f,4.200000f,3.257143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_358",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_358",10,358, 0);
		SetReadable(myObj);
		SetRotation(myObj,0,270,0);
		SetSprite(myObj, "Sprites/tmobj/tmobj_20");
		SetLink(myObj,576);
		
		myObj= CreateGameObject("a_plant_30_02_00_1017",36.514286f,3.600000f,2.914286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_192",true);
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_31_02_00_0981",37.371429f,3.600000f,2.742857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_32_02_00_0988",38.742855f,3.600000f,2.571429f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_32_02_00_0989",38.571426f,3.600000f,3.428571f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_32_02_00_0990",38.914284f,3.600000f,2.914286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_33_02_00_1019",40.114285f,3.600000f,2.914286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj= CreateGameObject("a_silver_tree_36_02_00_0967",43.714287f,3.600000f,3.257143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_458",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_458",69,458, 1);
		
		myObj= CreateGameObject("a_button_49_02_00_0817",59.314285f,3.300000f,2.420000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_377",false);
		CreateUWActivators(myObj,"ButtonHandler","a_use_trigger_99_99_00_0816",40,0,0,7,377);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_377",8,377, 1);
		SetRotation(myObj,0,180,0);
		SetButtonProperties(myObj, 1, "Sprites/tmflat/tmflat_0009", "Sprites/tmflat/tmflat_0001");
		
		myObj = new GameObject("a_rotworm_58_02_00_0222");
		pos = new Vector3(70.114288f, 1.500000f, 2.914286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"64","Sprites/OBJECTS_064");
		SetRotation(myObj,0,0,0);
		
		myObj= CreateGameObject("a_bone_07_03_00_0812",8.914286f,0.300000f,4.114285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_196",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_196",23,196, 1);
		
		myObj= CreateGameObject("a_bedroll_18_03_00_0823",22.114285f,3.600000f,4.114285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_289",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_289",16,289, 1);
		
		myObj= CreateGameObject("a_bone_23_03_00_0609",27.771429f,3.000000f,3.942857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_196",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_196",23,196, 1);
		
		myObj= CreateGameObject("a_piece_of_wood_pieces_of_wood_23_03_00_0608",28.114285f,3.000000f,4.114285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_204",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_204",23,204, 1);
		
		myObj= CreateGameObject("a_blood_stain_23_03_00_0607",27.942856f,3.000000f,4.457143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_222",true);
		
		myObj= CreateGameObject("a_skull_30_03_00_1016",36.857143f,3.600000f,3.942857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_194",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_194",23,194, 1);
		
		myObj= CreateGameObject("a_sack_33_03_00_0942",39.771427f,3.600000f,3.942857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_128",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_128",19,128, 1);
		////Container contents
		ParentContainer = myObj.AddComponent<Container>();
		myObj.GetComponent<ObjectInteraction>().isContainer = true;
		myObj= CreateGameObject("a_dagger_33_03_00_0940",39.771427f,3.600000f,3.942857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_003",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_003",1,3, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 0);
		myObj= CreateGameObject("a_torch_torches_33_03_00_0936",39.771427f,3.600000f,3.942857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_145",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_145",9,145, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 1);
		myObj= CreateGameObject("a_map_33_03_00_0941",39.771427f,3.600000f,3.942857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_315",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_315",16,315, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 2);
		myObj= CreateGameObject("a_fish_fish_33_03_00_0935",39.771427f,3.600000f,3.942857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_182",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_182",24,182, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 3);
		myObj= CreateGameObject("a_loaf_of_bread_loaves_of_bread_33_03_00_0934",39.771427f,3.600000f,3.942857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_177",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_177",24,177, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 4);
		myObj= CreateGameObject("an_apple_33_03_00_0959",39.771427f,3.600000f,3.942857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_179",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_179",24,179, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 5);
		////Container contents complete
		
		myObj= CreateGameObject("some_writing_35_03_00_0929",42.020000f,3.900000f,4.114285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_358",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_358",10,358, 0);
		SetReadable(myObj);
		SetRotation(myObj,0,270,0);
		SetSprite(myObj, "Sprites/tmobj/tmobj_20");
		SetLink(myObj,580);
		
		myObj= CreateGameObject("special_tmap_obj_04_04_00_1021",4.820000f,0.000000f,5.400000f);
		SetScale(myObj,(float)0.937500,(float)0.937500,(float)0.937500);
		CreateTMAP(myObj,"textures/tmap/uw1_170");
		SetRotation(myObj,0,270,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_366",34,366, 0);
		
		myObj= CreateGameObject("a_toadstool_16_04_00_0582",19.714287f,3.600000f,5.314286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_185",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_185",24,185, 1);
		
		myObj= CreateGameObject("a_toadstool_16_04_00_0581",20.057142f,3.600000f,4.971428f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_185",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_185",24,185, 1);
		
		myObj= CreateGameObject("a_Jux_stone_28_04_00_0587",34.457142f,3.000000f,5.142857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_224",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_241",6,241, 1);
		SetObjectAsRuneStone(myObj);
		SetInventoryIcon(myObj,"OBJECTS_241","Sprites/OBJECTS_241");
		
		
		
		myObj= CreateGameObject("a_key_002_3",65.828568f,3.000000f,5.314286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_258",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_258",5,258, 1);
		CreateKey(myObj, 2);
		
		myObj = new GameObject("a_acid_slug_55_04_00_0227");
		pos = new Vector3(66.514290f, 2.400000f, 5.314286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"69","Sprites/OBJECTS_069");
		SetRotation(myObj,0,0,0);
		
		myObj = new GameObject("door_022_005");
		pos = new Vector3(26.914284f, 3.000000f, 6.200000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_321",true);
		CreateDoor(myObj,"textures/doors/doors_03", 1, 1);
		SetRotation(myObj,-90,90,0);
		
		myObj= CreateGameObject("an_Ort_stone_28_05_00_0586",34.285717f,3.000000f,6.171429f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_224",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_246",6,246, 1);
		SetObjectAsRuneStone(myObj);
		SetInventoryIcon(myObj,"OBJECTS_246","Sprites/OBJECTS_246");
		
		
		myObj= CreateGameObject("a_blood_stain_28_05_00_0585",34.628571f,3.000000f,6.514286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_222",true);
		
		myObj= CreateGameObject("a_skull_28_05_00_0592",34.457142f,3.000000f,6.857143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_194",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_194",23,194, 1);
		
		myObj = new GameObject("door_038_005");
		pos = new Vector3(45.799999f, 3.000000f, 6.514286f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_327",true);
		CreateDoor(myObj,"textures/doors/doors_-12851", 53, 0);
		SetRotation(myObj,-90,-180,0);
		
		myObj = new GameObject("a_rotworm_05_06_00_0252");
		pos = new Vector3(6.514286f, 0.300000f, 7.714286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"64","Sprites/OBJECTS_064");
		SetRotation(myObj,0,180,0);
		
		myObj= CreateGameObject("a_pack_23_06_00_0993",27.771429f,3.000000f,7.542857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_130",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_130",19,130, 1);
		////Container contents
		ParentContainer = myObj.AddComponent<Container>();
		myObj.GetComponent<ObjectInteraction>().isContainer = true;
		myObj= CreateGameObject("a_key_001_3",27.771429f,3.000000f,7.542857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_262",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_262",5,262, 1);
		CreateKey(myObj, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 0);
		myObj= CreateGameObject("a_scroll_23_06_00_0956",27.771429f,3.000000f,7.542857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_312",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_312",13,312, 1);
		SetReadable(myObj);
		SetLink(myObj,514);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 1);
		myObj= CreateGameObject("a_rune_bag_23_06_00_0960",27.771429f,3.000000f,7.542857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_143",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_143",70,143, 1);
		SetObjectAsRuneBag(myObj);
		
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 2);
		myObj= CreateGameObject("a_Bet_stone_23_06_00_0950",27.771429f,3.000000f,7.542857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_224",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_233",6,233, 1);
		SetObjectAsRuneStone(myObj);
		SetInventoryIcon(myObj,"OBJECTS_233","Sprites/OBJECTS_233");
		
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 3);
		myObj= CreateGameObject("an_In_stone_23_06_00_0949",27.771429f,3.000000f,7.542857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_224",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_240",6,240, 1);
		SetObjectAsRuneStone(myObj);
		SetInventoryIcon(myObj,"OBJECTS_240","Sprites/OBJECTS_240");
		
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 4);
		myObj= CreateGameObject("a_Lor_stone_23_06_00_0951",27.771429f,3.000000f,7.542857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_224",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_243",6,243, 1);
		SetObjectAsRuneStone(myObj);
		SetInventoryIcon(myObj,"OBJECTS_243","Sprites/OBJECTS_243");
		
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 5);
		myObj= CreateGameObject("a_Sanct_stone_23_06_00_0947",27.771429f,3.000000f,7.542857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_224",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_250",6,250, 1);
		SetObjectAsRuneStone(myObj);
		SetInventoryIcon(myObj,"OBJECTS_250","Sprites/OBJECTS_250");
		
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 6);
		////Container contents complete
		
		myObj= CreateGameObject("a_blood_stain_23_06_00_0955",28.285715f,3.000000f,7.542857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_222",true);
		
		myObj= CreateGameObject("a_pile_of_bones_piles_of_bones_23_06_00_0702",27.942856f,3.000000f,8.057143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_198",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_198",23,198, 1);
		
		myObj= CreateGameObject("a_pile_of_bones_piles_of_bones_28_06_00_0591",34.628571f,3.000000f,7.542857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_198",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_198",23,198, 1);
		
		myObj= CreateGameObject("a_bone_28_06_00_0590",34.457142f,3.000000f,7.220000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_197",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_197",23,197, 1);
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_28_06_00_0589",34.114285f,3.000000f,7.714286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj= CreateGameObject("a_blood_stain_28_06_00_0593",34.457142f,3.000000f,8.228571f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_223",true);
		
		myObj= CreateGameObject("a_broken_axe_32_06_00_0977",38.914284f,3.000000f,7.714286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_200",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_200",23,200, 1);
		
		myObj = new GameObject("a_cave_bat_45_06_00_0229");
		pos = new Vector3(54.514286f, 2.100000f, 7.714286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"66","Sprites/OBJECTS_066");
		SetRotation(myObj,0,0,0);
		
		myObj = new GameObject("a_cave_bat_50_06_00_0228");
		pos = new Vector3(60.514286f, 1.800000f, 7.714286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"66","Sprites/OBJECTS_066");
		SetRotation(myObj,0,0,0);
		
		myObj = new GameObject("door_057_006");
		pos = new Vector3(69.085716f, 2.400000f, 7.400000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_323",true);
		CreateDoor(myObj,"textures/doors/doors_06", 2, 1);
		SetRotation(myObj,-90,90,0);
		
		myObj= CreateGameObject("a_switch_04_07_00_0864",4.820000f,1.200000f,9.085714f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_372",false);
		CreateUWActivators(myObj,"ButtonHandler","a_use_trigger_99_99_00_0691",40,0,0,7,372);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_372",8,372, 1);
		SetRotation(myObj,0,270,0);
		SetButtonProperties(myObj, 0, "Sprites/tmflat/tmflat_0004", "Sprites/tmflat/tmflat_0012");
		
		
		myObj = new GameObject("an_outcast_17_07_00_0240");
		pos = new Vector3(20.914284f, 3.600000f, 8.914286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"90","Sprites/OBJECTS_090");
		SetRotation(myObj,0,0,0);
		
		myObj = new GameObject("door_024_007");
		pos = new Vector3(29.000000f, 3.000000f, 8.914286f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_320",true);
		CreateDoor(myObj,"textures/doors/doors_00", 53, 0);
		SetRotation(myObj,-90,-180,0);
		
		myObj= CreateGameObject("a_blood_stain_28_07_00_0594",34.457142f,3.000000f,8.742857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_222",true);
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_28_07_00_0588",34.285717f,3.000000f,8.571429f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj= CreateGameObject("a_pull_chain_32_07_00_0994",39.580002f,3.600000f,9.085714f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_375",false);
		CreateUWActivators(myObj,"ButtonHandler","a_use_trigger_99_99_00_0992",40,0,0,7,375);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_375",8,375, 1);
		SetRotation(myObj,0,90,0);
		SetButtonProperties(myObj, 0, "Sprites/tmflat/tmflat_0007", "Sprites/tmflat/tmflat_0015");
		
		myObj= CreateGameObject("a_wooden_shield_04_08_00_0808",5.828571f,0.300000f,10.457142f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_060",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_060",2,60, 1);
		
		myObj= CreateGameObject("special_tmap_obj_06_08_00_1022",7.800000f,0.000000f,10.780000f);
		SetScale(myObj,(float)0.937500,(float)0.937500,(float)0.937500);
		CreateTMAP(myObj,"textures/tmap/uw1_170");
		SetRotation(myObj,0,0,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_366",34,366, 0);
		
		myObj= CreateGameObject("a_candle_16_08_00_0580",19.371428f,3.600000f,10.628572f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_146",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_146",9,146, 1);
		
		myObj = new GameObject("a_giant_rat_22_08_00_0254");
		pos = new Vector3(27.428572f, 3.000000f, 10.457142f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"67","Sprites/OBJECTS_067");
		SetRotation(myObj,0,225,0);
		
		myObj= CreateGameObject("a_piece_of_cheese_pieces_of_cheese_22_08_00_0945",26.914284f,3.000000f,10.628572f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_178",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_178",24,178, 1);
		
		myObj= CreateGameObject("a_piece_of_meat_pieces_of_meat_22_08_00_0946",26.914284f,3.000000f,10.114285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_176",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_176",24,176, 1);
		
		myObj= CreateGameObject("a_plant_30_08_00_0954",36.857143f,3.600000f,10.457142f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_207",true);
		
		myObj = new GameObject("door_033_008");
		pos = new Vector3(40.457142f, 3.000000f, 9.800000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_320",true);
		CreateDoor(myObj,"textures/doors/doors_00", 0, 1);
		SetRotation(myObj,-90,90,0);
		
		myObj = new GameObject("door_036_008");
		pos = new Vector3(43.400002f, 3.000000f, 10.114285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_321",true);
		CreateDoor(myObj,"textures/doors/doors_03", 1, 1);
		SetRotation(myObj,-90,-180,0);
		
		myObj= CreateGameObject("a_broken_mace_37_08_00_0968",45.428570f,3.000000f,10.457142f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_202",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_202",23,202, 1);
		
		myObj= CreateGameObject("a_piece_of_wood_pieces_of_wood_38_08_00_0969",46.114288f,3.000000f,10.780000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_205",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_205",23,205, 1);
		
		myObj= CreateGameObject("a_pile_of_bones_piles_of_bones_38_08_00_0970",46.457142f,3.000000f,9.942857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_198",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_198",23,198, 1);
		
		myObj= CreateGameObject("a_bone_38_08_00_0973",45.942856f,3.000000f,10.457142f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_196",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_196",23,196, 1);
		
		myObj= CreateGameObject("a_skull_38_08_00_0974",46.114288f,3.000000f,10.114285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_194",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_194",23,194, 1);
		
		myObj = new GameObject("door_046_008");
		pos = new Vector3(55.400002f, 2.700000f, 10.285714f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_325",true);
		CreateDoor(myObj,"textures/doors/doors_09", 0, 1);
		SetRotation(myObj,-90,-180,0);
		
		myObj= CreateGameObject("a_pile_of_debris_piles_of_debris_32_09_00_0975",39.257145f,3.000000f,11.657143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_213",true);
		
		myObj= CreateGameObject("a_skull_38_09_00_0971",46.457142f,3.000000f,10.971428f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_195",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_195",23,195, 1);
		
		myObj= CreateGameObject("a_pile_of_bones_piles_of_bones_38_09_00_0972",46.114288f,3.000000f,11.314286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_198",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_198",23,198, 1);
		
		myObj= CreateGameObject("special_tmap_obj_02_10_00_0884",2.420000f,0.000000f,12.600000f);
		SetScale(myObj,(float)0.937500,(float)0.937500,(float)0.937500);
		CreateTMAP(myObj,"textures/tmap/uw1_071");
		SetRotation(myObj,0,270,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_366",34,366, 0);
		
		myObj = new GameObject("door_009_010");
		pos = new Vector3(11.800000f, 0.300000f, 13.180000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_320",true);
		CreateDoor(myObj,"textures/doors/doors_00", 0, 1);
		SetRotation(myObj,-90,0,0);
		
		myObj= CreateGameObject("a_shortsword_18_10_00_0603",21.771429f,3.600000f,12.171429f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_004",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_004",1,4, 1);
		
		myObj= CreateGameObject("special_tmap_obj_23_10_00_0952",28.114285f,3.000000f,12.342857f);
		SetScale(myObj,(float)0.937500,(float)0.937500,(float)0.937500);
		CreateTMAP(myObj,"textures/tmap/uw1_173");
		SetRotation(myObj,0,315,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_366",34,366, 0);
		
		myObj= CreateGameObject("leather_leggings_pairs_of_leather_leggings_24_10_00_0939",29.314285f,3.000000f,12.020000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_035",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_035",2,35, 1);
		
		myObj= CreateGameObject("a_piece_of_wood_pieces_of_wood_28_10_00_0976",34.114285f,3.000000f,12.857142f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_204",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_204",23,204, 1);
		
		myObj= CreateGameObject("special_tmap_obj_29_10_00_0999",35.400002f,3.000000f,13.180000f);
		SetScale(myObj,(float)0.937500,(float)0.937500,(float)0.937500);
		CreateTMAP(myObj,"textures/tmap/uw1_023");
		SetRotation(myObj,0,0,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_366",34,366, 0);
		
		myObj= CreateGameObject("a_pile_of_bones_piles_of_bones_31_10_00_0978",37.714283f,3.000000f,12.514286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_198",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_198",23,198, 1);
		
		myObj= CreateGameObject("a_skull_31_10_00_0980",38.057144f,3.000000f,12.857142f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_194",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_194",23,194, 1);
		
		myObj= CreateGameObject("a_sack_38_10_00_0847",46.285713f,3.000000f,12.685714f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_128",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_128",19,128, 1);
		////Container contents
		ParentContainer = myObj.AddComponent<Container>();
		myObj.GetComponent<ObjectInteraction>().isContainer = true;
		myObj= CreateGameObject("a_candle_38_10_00_0845",46.285713f,3.000000f,12.685714f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_146",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_146",9,146, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 0);
		myObj= CreateGameObject("a_mushroom_38_10_00_0614",46.285713f,3.000000f,12.685714f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_184",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_184",24,184, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 1);
		myObj= CreateGameObject("a_cudgel_38_10_00_0613",46.285713f,3.000000f,12.685714f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_007",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_007",1,7, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 2);
		////Container contents complete
		
		myObj= CreateGameObject("special_tmap_obj_02_11_00_0883",2.420000f,0.000000f,13.800000f);
		SetScale(myObj,(float)0.937500,(float)0.937500,(float)0.937500);
		CreateTMAP(myObj,"textures/tmap/uw1_071");
		SetRotation(myObj,0,270,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_366",34,366, 0);
		
		myObj= CreateGameObject("special_tmap_obj_02_12_00_0882",2.420000f,0.000000f,15.000000f);
		SetScale(myObj,(float)0.937500,(float)0.937500,(float)0.937500);
		CreateTMAP(myObj,"textures/tmap/uw1_071");
		SetRotation(myObj,0,270,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_366",34,366, 0);
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_09_12_00_0868",11.657143f,0.300000f,15.257142f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_09_12_00_0867",11.314286f,0.300000f,14.914286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_10_12_00_0866",12.342857f,0.300000f,15.257142f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj = new GameObject("a_giant_rat_18_12_00_0214");
		pos = new Vector3(22.457144f, 3.600000f, 14.914286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"67","Sprites/OBJECTS_067");
		SetRotation(myObj,0,0,0);
		
		myObj= CreateGameObject("a_box_boxes_20_12_00_0728",24.342857f,3.000000f,15.428572f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_132",true);
		
		myObj= CreateGameObject("a_cauldron_20_12_00_0733",24.514284f,3.000000f,14.914286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_303",true);
		
		myObj= CreateGameObject("a_bowl_26_12_00_0606",31.371428f,3.000000f,14.571428f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_142",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_142",19,142, 1);
		////Container contents complete
		
		myObj= CreateGameObject("a_hand_axe_26_12_00_0604",31.371428f,3.000000f,14.914286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_000",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_000",1,0, 1);
		
		myObj= CreateGameObject("a_torch_torches_26_12_00_0605",31.371428f,3.000000f,15.257142f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_145",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_145",9,145, 1);
		
		myObj= CreateGameObject("a_pile_of_debris_piles_of_debris_28_12_00_0583",34.114285f,2.850000f,14.914286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_209",23,209, 1);
		
		myObj= CreateGameObject("a_pile_of_debris_piles_of_debris_28_12_00_0584",34.114285f,2.850000f,14.914286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_209",23,209, 1);
		
		myObj= CreateGameObject("a_flask_of_port_flasks_of_port_30_12_00_0739",36.171429f,1.800000f,15.257142f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_190",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_190",14,190, 1);
		
		myObj= CreateGameObject("a_piece_of_meat_pieces_of_meat_30_12_00_0740",36.857143f,1.800000f,14.742858f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_176",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_176",24,176, 1);
		
		myObj= CreateGameObject("a_campfire_30_12_00_0741",36.514286f,1.800000f,14.914286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_298",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_298",16,298, 0);
		
		myObj = new GameObject("an_outcast_33_12_00_0241");
		pos = new Vector3(40.457142f, 2.100000f, 14.914286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"90","Sprites/OBJECTS_090");
		SetRotation(myObj,0,0,0);
		
		myObj= CreateGameObject("a_bedroll_33_12_00_0736",40.114285f,2.100000f,15.580000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_289",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_289",16,289, 1);
		
		myObj= CreateGameObject("a_bedroll_33_12_00_0737",40.114285f,2.100000f,14.914286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_289",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_289",16,289, 1);
		
		myObj = new GameObject("door_037_012");
		pos = new Vector3(44.599998f, 3.000000f, 14.914286f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_321",true);
		CreateDoor(myObj,"textures/doors/doors_03", 1, 1);
		SetRotation(myObj,-90,-180,0);
		
		myObj= CreateGameObject("a_bench_benches_15_13_00_0880",18.514286f,3.600000f,15.942858f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_336",true);
		
		myObj= CreateGameObject("an_oil_flask_16_13_00_0602",20.228571f,3.600000f,16.457142f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_301",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_301",16,301, 1);
		
		myObj= CreateGameObject("an_oil_flask_16_13_00_0601",20.057142f,3.600000f,15.942858f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_301",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_301",16,301, 1);
		
		myObj= CreateGameObject("a_cauldron_20_13_00_0734",24.514284f,3.000000f,16.114286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_303",true);
		
		myObj= CreateGameObject("a_pole_23_13_00_0612",28.114285f,3.000000f,16.114286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_216",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_216",16,216, 1);
		
		myObj= CreateGameObject("a_pole_24_13_00_0611",28.820000f,3.000000f,16.457142f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_216",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_216",16,216, 1);
		
		myObj= CreateGameObject("a_pile_of_bones_piles_of_bones_28_13_00_0904",34.285717f,2.700000f,16.628572f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_198",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_198",23,198, 1);
		
		myObj= CreateGameObject("a_skull_28_13_00_0905",34.457142f,2.700000f,16.114286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_195",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_195",23,195, 1);
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_28_13_00_0906",34.114285f,2.700000f,16.457142f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj= CreateGameObject("a_broken_sword_28_13_00_0907",34.457142f,2.700000f,15.771428f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_201",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_201",23,201, 1);
		
		myObj= CreateGameObject("a_pile_of_bones_piles_of_bones_28_13_00_0908",34.628571f,2.700000f,16.457142f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_198",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_198",23,198, 1);
		
		myObj= CreateGameObject("a_bone_28_13_00_0909",33.942856f,2.700000f,16.457142f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_196",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_196",23,196, 1);
		
		myObj= CreateGameObject("a_skull_28_13_00_0912",34.114285f,2.700000f,16.114286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_194",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_194",23,194, 1);
		
		myObj= CreateGameObject("a_bedroll_33_13_00_0735",40.114285f,2.100000f,16.114286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_289",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_289",16,289, 1);
		
		
		myObj= CreateGameObject("an_orb_58_13_00_0913",70.114288f,3.900000f,16.114286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_279",true);
		CreateUWActivators(myObj,"ButtonHandler","a_look_trigger_99_99_00_0910",40,0,0,7,279);
		
		myObj = new GameObject("a_acid_slug_59_14_00_0226");
		pos = new Vector3(71.314285f, 3.300000f, 17.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"69","Sprites/OBJECTS_069");
		SetRotation(myObj,0,0,0);
		
		myObj = new GameObject("a_vampire_bat_02_15_00_0209");
		pos = new Vector3(2.914286f, 1.500000f, 18.514286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"73","Sprites/OBJECTS_073");
		SetRotation(myObj,0,0,0);
		
		myObj= CreateGameObject("a_leather_cap_02_15_00_0721",3.428571f,0.300000f,18.685715f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_044",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_044",2,44, 1);
		
		myObj= CreateGameObject("leather_boots_pairs_of_leather_boots_02_15_00_0722",2.914286f,0.300000f,18.514286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_041",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_041",2,41, 1);
		
		myObj = new GameObject("door_021_015");
		pos = new Vector3(25.219999f, 3.600000f, 19.000000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_320",true);
		CreateDoor(myObj,"textures/doors/doors_00", 1, 1);
		SetRotation(myObj,-90,-90,0);
		
		myObj = new GameObject("an_outcast_33_15_00_0239");
		pos = new Vector3(40.457142f, 2.100000f, 18.857141f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"90","Sprites/OBJECTS_090");
		SetRotation(myObj,0,90,0);
		
		myObj = new GameObject("a_cave_bat_12_16_00_0211");
		pos = new Vector3(14.914286f, 0.600000f, 19.714287f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"66","Sprites/OBJECTS_066");
		SetRotation(myObj,0,0,0);
		
		myObj= CreateGameObject("a_pile_of_bones_piles_of_bones_37_16_00_0811",44.571430f,3.000000f,20.057142f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_198",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_198",23,198, 1);
		
		myObj= CreateGameObject("some_writing_51_16_00_0700",62.380001f,4.200000f,20.379999f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_358",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_358",10,358, 0);
		SetReadable(myObj);
		SetRotation(myObj,0,90,0);
		SetSprite(myObj, "Sprites/tmobj/tmobj_21");
		SetLink(myObj,582);
		
		myObj= CreateGameObject("a_green_potion_59_16_00_0562",71.657143f,2.100000f,19.885714f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_188",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_188",14,188, 1);
		
		myObj= CreateGameObject("a_skull_59_16_00_0676",71.828568f,2.100000f,19.371428f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_194",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_194",23,194, 1);
		
		myObj= CreateGameObject("a_plant_59_16_00_0677",71.657143f,2.100000f,20.228571f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_206",true);
		
		myObj= CreateGameObject("a_plant_59_16_00_0678",70.971428f,2.100000f,19.542858f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_206",true);
		
		myObj= CreateGameObject("a_plant_59_16_00_0679",71.314285f,2.100000f,19.714287f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_206",true);
		
		myObj = new GameObject("a_giant_rat_02_17_00_0215");
		pos = new Vector3(2.914286f, 2.700000f, 20.914284f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"72","Sprites/OBJECTS_072");
		SetRotation(myObj,0,0,0);
		
		
		myObj = new GameObject("door_022_017");
		pos = new Vector3(27.400000f, 3.600000f, 21.428572f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_320",true);
		CreateDoor(myObj,"textures/doors/doors_00", 53, 0);
		SetRotation(myObj,-90,0,0);
		
		
		
		myObj= CreateGameObject("some_writing_41_17_00_0699",49.220001f,4.200000f,20.420000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_358",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_358",10,358, 0);
		SetReadable(myObj);
		SetRotation(myObj,0,270,0);
		SetSprite(myObj, "Sprites/tmobj/tmobj_21");
		SetLink(myObj,583);
		
		myObj= CreateGameObject("a_pile_of_debris_piles_of_debris_57_17_00_0675",68.742859f,2.100000f,21.257143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_210",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_210",23,210, 1);
		
		myObj= CreateGameObject("a_candle_02_18_00_0658",2.420000f,2.700000f,22.114285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_146",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_146",9,146, 1);
		
		myObj= CreateGameObject("a_bone_37_18_00_0809",45.428570f,3.000000f,21.942856f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_196",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_196",23,196, 1);
		
		myObj= CreateGameObject("a_shrine_46_18_00_0879",55.714287f,3.600000f,22.114285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_343",true);
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_58_18_00_0672",70.628571f,1.800000f,21.942856f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_58_18_00_0673",70.628571f,1.800000f,22.457144f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_58_18_00_0674",70.114288f,1.800000f,22.114285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj = new GameObject("a_giant_rat_02_19_00_0217");
		pos = new Vector3(2.914286f, 2.700000f, 23.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"67","Sprites/OBJECTS_067");
		SetRotation(myObj,0,0,0);
		
		myObj = new GameObject("door_009_019");
		pos = new Vector3(11.314286f, 3.600000f, 23.000000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_323",true);
		CreateDoor(myObj,"textures/doors/doors_06", 2, 1);
		SetRotation(myObj,-90,90,0);
		
		myObj = new GameObject("an_outcast_22_19_00_0242");
		pos = new Vector3(26.914284f, 3.600000f, 23.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"90","Sprites/OBJECTS_090");
		SetRotation(myObj,0,0,0);
		
		myObj= CreateGameObject("a_pouch_pouches_10_20_00_0723",12.685714f,3.600000f,25.028572f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_134",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_134",19,134, 1);
		////Container contents
		ParentContainer = myObj.AddComponent<Container>();
		myObj.GetComponent<ObjectInteraction>().isContainer = true;
		myObj= CreateGameObject("a_ruby_rubies_10_20_00_0814",12.685714f,3.600000f,25.028572f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_162",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_162",18,162, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 0);
		////Container contents complete
		
		myObj= CreateGameObject("a_bottle_of_water_bottles_of_water_10_20_00_0815",12.514286f,3.600000f,24.514284f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_189",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_189",14,189, 1);
		
		myObj= CreateGameObject("a_scroll_12_20_00_0642",15.428572f,3.600000f,24.857143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_318",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_318",13,318, 1);
		SetReadable(myObj);
		SetLink(myObj,516);
		
		myObj = new GameObject("an_imp_12_20_00_0213");
		pos = new Vector3(14.914286f, 3.900000f, 24.514284f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"75","Sprites/OBJECTS_075");
		SetRotation(myObj,0,270,0);
		
		myObj= CreateGameObject("special_tmap_obj_27_20_00_0987",33.580002f,3.000000f,24.600000f);
		SetScale(myObj,(float)0.937500,(float)0.937500,(float)0.937500);
		CreateTMAP(myObj,"textures/tmap/uw1_137");
		SetRotation(myObj,0,90,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_366",34,366, 0);
		
		
		
		
		myObj = new GameObject("an_outcast_33_20_00_0243");
		pos = new Vector3(40.114285f, 3.600000f, 24.685715f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"90","Sprites/OBJECTS_090");
		SetRotation(myObj,0,270,0);
		
		
		myObj= CreateGameObject("special_tmap_obj_61_20_00_0885",74.379997f,2.100000f,24.600000f);
		SetScale(myObj,(float)0.937500,(float)0.937500,(float)0.937500);
		CreateTMAP(myObj,"textures/tmap/uw1_071");
		SetRotation(myObj,0,90,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_366",34,366, 0);
		
		myObj = new GameObject("door_026_021");
		pos = new Vector3(32.200001f, 3.000000f, 26.228571f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_323",true);
		CreateDoor(myObj,"textures/doors/doors_06", 2, 1);
		SetRotation(myObj,-90,0,0);
		
		myObj= CreateGameObject("a_piece_of_wood_pieces_of_wood_37_21_00_0862",45.428570f,3.600000f,25.714285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_205",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_205",23,205, 1);
		
		myObj = new GameObject("a_giant_rat_02_22_00_0216");
		pos = new Vector3(2.914286f, 2.700000f, 26.914284f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"67","Sprites/OBJECTS_067");
		SetRotation(myObj,0,0,0);
		
		myObj= CreateGameObject("a_bottle_of_ale_bottles_of_ale_02_23_00_0616",2.571429f,2.700000f,28.457144f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_186",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_186",24,186, 1);
		
		myObj = new GameObject("a_lurker_14_23_00_0250");
		pos = new Vector3(17.314285f, 0.300000f, 28.114285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"87","Sprites/OBJECTS_087");
		SetRotation(myObj,0,0,0);
		
		myObj = new GameObject("a_cave_bat_31_23_00_0212");
		pos = new Vector3(37.714283f, 1.200000f, 28.114285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"66","Sprites/OBJECTS_066");
		SetRotation(myObj,0,0,0);
		
		myObj= CreateGameObject("some_leeches_bunches_of_leeches_10_24_00_0701",12.514286f,0.600000f,29.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_293",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_293",16,293, 1);
		
		myObj= CreateGameObject("a_bridge_36_24_00_1004",43.714287f,3.525000f,29.314285f);
		
		myObj= CreateGameObject("a_bridge_37_24_00_1007",44.914288f,3.525000f,29.314285f);
		
		myObj= CreateGameObject("a_bridge_38_24_00_1008",46.114288f,3.525000f,29.314285f);
		
		myObj= CreateGameObject("some_writing_46_24_00_0668",55.885712f,4.200000f,29.980000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_358",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_358",10,358, 0);
		SetReadable(myObj);
		SetRotation(myObj,0,0,0);
		SetSprite(myObj, "Sprites/tmobj/tmobj_21");
		SetLink(myObj,584);
		
		myObj= CreateGameObject("a_torch_torches_02_25_00_0540",2.571429f,2.700000f,30.857143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_145",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_145",9,145, 1);
		
		myObj= CreateGameObject("a_bridge_36_25_00_1003",43.714287f,3.525000f,30.514284f);
		
		myObj= CreateGameObject("a_bridge_37_25_00_1005",44.914288f,3.525000f,30.514284f);
		
		myObj= CreateGameObject("a_bridge_38_25_00_1006",46.114288f,3.525000f,30.514284f);
		
		myObj = new GameObject("door_022_026");
		pos = new Vector3(26.600000f, 3.600000f, 31.542856f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_324",true);
		CreateDoor(myObj,"textures/doors/doors_07", 53, 0);
		SetRotation(myObj,-90,-180,0);
		
		myObj = new GameObject("a_giant_spider_29_26_00_0253");
		pos = new Vector3(35.314285f, 3.600000f, 31.714285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"68","Sprites/OBJECTS_068");
		SetRotation(myObj,0,180,0);
		
		myObj= CreateGameObject("an_ear_of_corn_ears_of_corn_30_26_00_0641",36.342857f,3.600000f,31.371428f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_180",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_180",24,180, 1);
		
		myObj= CreateGameObject("a_blood_stain_38_27_00_0863",46.114288f,3.600000f,32.914284f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_222",true);
		
		myObj= CreateGameObject("a_sling_stone_39_27_00_0860",47.142857f,3.000000f,33.257145f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_016",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_016",1,16, 1);
		
		myObj= CreateGameObject("some_rubble_piles_of_rubble_28_28_00_0853",34.114285f,3.600000f,33.942856f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_218",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_218",69,218, 0);
		
		myObj = new GameObject("a_goblin_36_28_00_0225");
		pos = new Vector3(43.714287f, 3.600000f, 34.114285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"77","Sprites/OBJECTS_077");
		SetRotation(myObj,0,0,0);
		
		myObj= CreateGameObject("a_bone_36_30_00_0859",43.371429f,3.000000f,36.857143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_196",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_196",23,196, 1);
		
		
		
		myObj = new GameObject("door_005_032");
		pos = new Vector3(6.200000f, 2.700000f, 38.914284f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_320",true);
		CreateDoor(myObj,"textures/doors/doors_00", 53, 0);
		SetRotation(myObj,-90,-180,0);
		
		myObj= CreateGameObject("a_ruby_rubies_10_32_00_0653",12.857142f,0.300000f,38.742855f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_162",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_162",18,162, 1);
		
		myObj= CreateGameObject("special_tmap_obj_35_32_00_0881",42.020000f,3.600000f,39.000000f);
		SetScale(myObj,(float)0.937500,(float)0.937500,(float)0.937500);
		CreateTMAP(myObj,"textures/tmap/uw1_142");
		SetRotation(myObj,0,270,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_366",34,366, 0);
		
		
		
		myObj= CreateGameObject("a_torch_torches_03_33_00_0541",4.457143f,3.600000f,40.285717f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_145",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_145",9,145, 1);
		
		myObj= CreateGameObject("a_buckler_03_33_00_0696",3.942857f,3.600000f,39.771427f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_062",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_062",2,62, 1);
		
		
		myObj= CreateGameObject("a_key_002_2",12.857142f,0.300000f,40.457142f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_258",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_258",5,258, 1);
		CreateKey(myObj, 2);
		
		
		myObj= CreateGameObject("special_tmap_obj_16_33_00_0806",19.799999f,2.100000f,40.779999f);
		SetScale(myObj,(float)0.937500,(float)0.937500,(float)0.937500);
		CreateTMAP(myObj,"textures/tmap/uw1_006");
		SetRotation(myObj,0,0,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_366",34,366, 0);
		
		myObj = new GameObject("a_flesh_slug_26_33_00_0207");
		pos = new Vector3(31.714285f, 2.100000f, 40.114285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"65","Sprites/OBJECTS_065");
		SetRotation(myObj,0,270,0);
		
		myObj= CreateGameObject("a_piece_of_wood_pieces_of_wood_27_33_00_0861",33.257145f,2.100000f,39.942856f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_205",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_205",23,205, 1);
		
		myObj= CreateGameObject("a_skull_27_33_00_0865",32.914284f,2.100000f,40.114285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_194",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_194",23,194, 1);
		
		myObj= CreateGameObject("a_pile_of_debris_piles_of_debris_27_33_00_0869",33.257145f,2.100000f,40.457142f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_210",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_210",23,210, 1);
		
		
		myObj= CreateGameObject("a_cudgel_53_33_00_0998",64.114288f,3.600000f,40.114285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_007",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_007",1,7, 1);
		
		myObj= CreateGameObject("a_chain_cowl_55_33_00_0804",66.514290f,3.600000f,40.114285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_045",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_045",2,45, 1);
		
		
		myObj= CreateGameObject("a_loaf_of_bread_loaves_of_bread_03_34_00_0839",4.285714f,3.600000f,41.657143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_177",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_177",24,177, 1);
		
		myObj= CreateGameObject("a_sling_stone_03_34_00_0957",4.628572f,3.600000f,41.485714f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_016",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_016",1,16, 1);
		
		
		
		myObj= CreateGameObject("special_tmap_obj_07_34_00_0916",8.420000f,0.000000f,41.400002f);
		SetScale(myObj,(float)0.937500,(float)0.937500,(float)0.937500);
		CreateTMAP(myObj,"textures/tmap/uw1_137");
		SetRotation(myObj,0,270,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_366",34,366, 0);
		
		myObj = new GameObject("door_015_034");
		pos = new Vector3(18.200001f, 2.100000f, 41.657143f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_326",true);
		CreateDoor(myObj,"textures/doors/doors_-12851", 4, 1);
		SetRotation(myObj,-90,-180,0);
		SetPortcullis(myObj,true);
		
		
		myObj= CreateGameObject("a_pile_of_debris_piles_of_debris_34_34_00_0857",41.657143f,3.600000f,41.657143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_210",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_210",23,210, 1);
		
		myObj = new GameObject("door_009_035");
		pos = new Vector3(11.000000f, 3.600000f, 42.171432f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_326",true);
		CreateDoor(myObj,"textures/doors/doors_-12851", 0, 1);
		SetRotation(myObj,-90,-180,0);
		SetPortcullis(myObj,true);
		
		myObj = new GameObject("a_goblin_15_35_00_0220");
		pos = new Vector3(18.514286f, 2.100000f, 42.514286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"71","Sprites/OBJECTS_071");
		SetRotation(myObj,0,180,0);
		myObj= CreateGameObject("a_key_004_2",18.514286f,2.100000f,42.514286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_266",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_266",5,266, 1);
		CreateKey(myObj, 4);
		
		myObj= CreateGameObject("a_button_16_35_00_0807",19.714287f,2.700000f,42.020000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_377",false);
		CreateUWActivators(myObj,"ButtonHandler","a_use_trigger_99_99_00_0637",40,0,0,7,377);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_377",8,377, 1);
		SetRotation(myObj,0,180,0);
		SetButtonProperties(myObj, 1, "Sprites/tmflat/tmflat_0009", "Sprites/tmflat/tmflat_0001");
		
		myObj = new GameObject("a_skeleton_54_35_00_0204");
		pos = new Vector3(65.314285f, 2.400000f, 42.514286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"74","Sprites/OBJECTS_074");
		SetRotation(myObj,0,180,0);
		
		
		myObj= CreateGameObject("a_lever_09_36_00_0744",11.980000f,4.200000f,44.057144f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_373",false);
		CreateUWActivators(myObj,"ButtonHandler","a_use_trigger_99_99_00_0742",40,0,0,7,373);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_373",8,373, 1);
		SetRotation(myObj,0,90,0);
		SetButtonProperties(myObj, 0, "Sprites/tmflat/tmflat_0005", "Sprites/tmflat/tmflat_0013");
		
		myObj= CreateGameObject("a_piece_of_wood_pieces_of_wood_20_36_00_0649",24.342857f,1.200000f,44.057144f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_205",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_205",23,205, 1);
		
		myObj= CreateGameObject("a_bridge_21_36_00_0659",25.885715f,0.975000f,43.714287f);
		
		myObj= CreateGameObject("a_box_boxes_22_36_00_0652",26.914284f,1.200000f,43.714287f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_132",true);
		
		myObj= CreateGameObject("a_pile_of_bones_piles_of_bones_38_36_00_0556",45.771431f,3.600000f,44.228569f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_198",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_198",23,198, 1);
		
		myObj = new GameObject("door_052_036");
		pos = new Vector3(62.599998f, 2.400000f, 43.714287f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_323",true);
		CreateDoor(myObj,"textures/doors/doors_06", 2, 1);
		SetRotation(myObj,-90,-180,0);
		
		myObj = new GameObject("door_056_036");
		pos = new Vector3(68.199997f, 2.400000f, 43.714287f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_323",true);
		CreateDoor(myObj,"textures/doors/doors_06", 2, 1);
		SetRotation(myObj,-90,0,0);
		
		myObj= CreateGameObject("a_bench_benches_18_37_00_0781",22.114285f,2.100000f,44.914288f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_336",true);
		
		myObj= CreateGameObject("a_piece_of_wood_pieces_of_wood_35_37_00_0557",42.171432f,3.600000f,44.571430f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_205",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_205",23,205, 1);
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_40_37_00_0573",48.857143f,3.600000f,44.742855f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj= CreateGameObject("a_plant_40_37_00_0560",48.342857f,3.600000f,44.571430f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_192",true);
		
		myObj= CreateGameObject("a_broken_sword_41_37_00_0564",49.371429f,3.600000f,45.257145f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_201",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_201",23,201, 1);
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_41_37_00_0565",49.371429f,3.600000f,44.571430f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj= CreateGameObject("a_bridge_42_37_00_0900",51.085712f,3.525000f,44.914288f);
		
		myObj= CreateGameObject("a_bridge_43_37_00_0898",52.285713f,3.525000f,44.914288f);
		
		myObj= CreateGameObject("a_bridge_44_37_00_0897",53.485714f,3.525000f,44.914288f);
		
		myObj= CreateGameObject("a_pile_of_bones_piles_of_bones_45_37_00_0553",54.857143f,3.600000f,44.742855f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_198",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_198",23,198, 1);
		
		myObj= CreateGameObject("a_bridge_45_37_00_0894",54.685715f,3.525000f,44.914288f);
		
		myObj= CreateGameObject("a_blood_stain_52_37_00_0858",63.257145f,2.400000f,45.257145f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_221",true);
		
		myObj = new GameObject("a_goblin_03_38_00_0219");
		pos = new Vector3(4.114285f, 3.600000f, 46.114288f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"77","Sprites/OBJECTS_077");
		SetRotation(myObj,0,45,0);
		
		myObj = new GameObject("a_goblin_11_38_00_0218");
		pos = new Vector3(13.714286f, 3.600000f, 46.114288f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"77","Sprites/OBJECTS_077");
		SetRotation(myObj,0,270,0);
		
		myObj= CreateGameObject("a_candle_11_38_00_0655",14.228572f,3.600000f,45.771431f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_146",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_146",9,146, 1);
		
		myObj = new GameObject("a_lurker_26_38_00_0223");
		pos = new Vector3(31.714285f, 0.900000f, 46.114288f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"87","Sprites/OBJECTS_087");
		SetRotation(myObj,0,0,0);
		
		myObj= CreateGameObject("a_pile_of_wood_chips_piles_of_wood_chips_36_38_00_0855",43.714287f,3.600000f,46.114288f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_219",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_219",69,219, 0);
		
		myObj= CreateGameObject("a_blood_stain_40_38_00_0552",48.171432f,3.600000f,46.628571f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_221",true);
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_41_38_00_0554",50.228569f,3.600000f,46.628571f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj= CreateGameObject("a_bridge_42_38_00_0901",51.085712f,3.525000f,46.114288f);
		
		myObj= CreateGameObject("a_bridge_43_38_00_0899",52.285713f,3.525000f,46.114288f);
		
		myObj= CreateGameObject("a_bridge_44_38_00_0896",53.485714f,3.525000f,46.114288f);
		
		myObj= CreateGameObject("a_bridge_45_38_00_0895",54.685715f,3.525000f,46.114288f);
		
		myObj = new GameObject("a_goblin_54_38_00_0224");
		pos = new Vector3(65.314285f, 3.600000f, 46.114288f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"78","Sprites/OBJECTS_078");
		SetRotation(myObj,0,0,0);
		
		myObj= CreateGameObject("a_pile_of_debris_piles_of_debris_61_38_00_0856",73.714287f,3.600000f,46.457142f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_210",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_210",23,210, 1);
		
		myObj= CreateGameObject("a_fish_fish_03_39_00_0671",4.457143f,3.300000f,46.971432f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_182",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_182",24,182, 1);
		
		myObj= CreateGameObject("a_piece_of_meat_pieces_of_meat_03_39_00_0774",4.628572f,3.300000f,47.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_176",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_176",24,176, 1);
		
		myObj= CreateGameObject("a_pile_of_bones_piles_of_bones_03_39_00_0775",4.457143f,3.300000f,47.828568f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_198",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_198",23,198, 1);
		
		myObj= CreateGameObject("a_skull_03_39_00_0782",3.771429f,3.300000f,47.657143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_194",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_194",23,194, 1);
		
		myObj= CreateGameObject("a_campfire_03_39_00_0778",4.114285f,3.300000f,47.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_298",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_298",16,298, 0);
		
		myObj= CreateGameObject("a_rock_hammer_09_39_00_0598",11.828571f,3.600000f,47.657143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_296",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_296",16,296, 1);
		
		myObj= CreateGameObject("a_coin_09_39_00_0654",11.142858f,3.600000f,47.657143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_160",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_160",18,160, 1);
		
		myObj= CreateGameObject("a_plant_38_39_00_0555",45.771431f,3.600000f,46.971432f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_206",true);
		
		myObj= CreateGameObject("a_bridge_38_39_00_0891",46.114288f,3.525000f,47.314285f);
		
		myObj= CreateGameObject("a_bridge_39_39_00_0888",47.314285f,3.525000f,47.314285f);
		
		myObj= CreateGameObject("a_bridge_38_40_00_0892",46.114288f,3.525000f,48.514286f);
		
		myObj= CreateGameObject("a_bridge_39_40_00_0889",47.314285f,3.525000f,48.514286f);
		
		myObj= CreateGameObject("a_gold_coffer_49_40_00_0685",59.314285f,3.000000f,48.514286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_138",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_138",19,138, 1);
		////Container contents
		ParentContainer = myObj.AddComponent<Container>();
		myObj.GetComponent<ObjectInteraction>().isContainer = true;
		myObj= CreateGameObject("a_sceptre_49_40_00_0684",59.314285f,3.000000f,48.514286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_170",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_170",18,170, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 0);
		myObj= CreateGameObject("a_leather_vest_49_40_00_0682",59.314285f,3.000000f,48.514286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_032",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_032",2,32, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 1);
		myObj= CreateGameObject("an_axe_49_40_00_0683",59.314285f,3.000000f,48.514286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_002",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_002",1,2, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 2);
		myObj= CreateGameObject("leather_leggings_pairs_of_leather_leggings_49_40_00_0681",59.314285f,3.000000f,48.514286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_035",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_035",2,35, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 3);
		myObj= CreateGameObject("a_leather_cap_49_40_00_0680",59.314285f,3.000000f,48.514286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_044",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_044",2,44, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 4);
		myObj= CreateGameObject("a_resilient_sphere_some_resilient_spheres_49_40_00_0544",59.314285f,3.000000f,48.514286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_286",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_286",16,286, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 5);
		////Container contents complete
		
		myObj = new GameObject("door_054_040");
		pos = new Vector3(65.000000f, 3.600000f, 48.020000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_320",true);
		CreateDoor(myObj,"textures/doors/doors_00", 53, 0);
		SetRotation(myObj,-90,-180,0);
		
		myObj= CreateGameObject("a_bridge_38_41_00_0893",46.114288f,3.525000f,49.714287f);
		
		myObj= CreateGameObject("a_bridge_39_41_00_0890",47.314285f,3.525000f,49.714287f);
		
		myObj= CreateGameObject("a_gravestone_50_41_00_0686",60.857143f,3.000000f,49.371429f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_357",true);
		
		myObj= CreateGameObject("a_piece_of_meat_pieces_of_meat_08_42_00_0670",10.114285f,3.300000f,51.428570f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_176",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_176",24,176, 1);
		
		myObj= CreateGameObject("a_piece_of_wood_pieces_of_wood_08_42_00_0785",10.628572f,3.300000f,51.085712f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_205",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_205",23,205, 1);
		
		myObj= CreateGameObject("a_skull_08_42_00_0915",10.457142f,3.300000f,50.571430f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_195",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_195",23,195, 1);
		
		myObj= CreateGameObject("a_pile_of_bones_piles_of_bones_08_42_00_1002",9.771429f,3.300000f,50.742855f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_198",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_198",23,198, 1);
		
		myObj= CreateGameObject("a_campfire_08_42_00_0767",10.114285f,3.300000f,50.914288f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_298",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_298",16,298, 0);
		
		myObj= CreateGameObject("a_cauldron_11_42_00_0763",13.714286f,3.600000f,50.914288f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_303",true);
		
		myObj = new GameObject("a_goblin_08_43_00_0244");
		pos = new Vector3(10.114285f, 3.600000f, 52.114288f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"70","Sprites/OBJECTS_070");
		SetRotation(myObj,0,0,0);
		
		myObj = new GameObject("a_goblin_10_43_00_0245");
		pos = new Vector3(12.514286f, 3.600000f, 52.114288f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"70","Sprites/OBJECTS_070");
		SetRotation(myObj,0,0,0);
		
		myObj = new GameObject("a_cave_bat_23_43_00_0210");
		pos = new Vector3(28.114285f, 2.100000f, 52.114288f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"66","Sprites/OBJECTS_066");
		SetRotation(myObj,0,0,0);
		
		myObj = new GameObject("a_cave_bat_24_43_00_0208");
		pos = new Vector3(29.314285f, 2.400000f, 52.114288f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"66","Sprites/OBJECTS_066");
		SetRotation(myObj,0,0,0);
		
		myObj= CreateGameObject("a_blood_stain_39_43_00_0551",46.971432f,3.600000f,52.457142f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_222",true);
		
		myObj = new GameObject("door_012_044");
		pos = new Vector3(14.914286f, 3.600000f, 53.000000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_324",true);
		CreateDoor(myObj,"textures/doors/doors_07", 53, 0);
		SetRotation(myObj,-90,90,0);
		
		myObj= CreateGameObject("some_leeches_bunches_of_leeches_26_44_00_0597",32.380001f,2.400000f,53.485714f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_293",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_293",16,293, 1);
		
		myObj= CreateGameObject("a_red_gem_26_44_00_0799",32.057144f,2.400000f,53.828568f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_163",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_163",18,163, 1);
		
		
		
		
		
		myObj= CreateGameObject("a_bedroll_07_45_00_0640",8.914286f,3.900000f,55.028568f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_289",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_289",16,289, 1);
		
		myObj= CreateGameObject("a_bedroll_09_45_00_0979",11.314286f,3.900000f,55.028568f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_289",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_289",16,289, 1);
		
		myObj= CreateGameObject("a_bedroll_11_45_00_0768",13.714286f,3.900000f,55.028568f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_289",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_289",16,289, 1);
		
		myObj= CreateGameObject("a_bone_26_45_00_0797",32.057144f,2.400000f,54.857143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_197",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_197",23,197, 1);
		
		myObj= CreateGameObject("a_broken_sword_26_45_00_0798",31.714285f,2.400000f,54.514286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_201",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_201",23,201, 1);
		
		myObj= CreateGameObject("a_skull_27_45_00_0796",32.914284f,2.400000f,54.514286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_194",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_194",23,194, 1);
		
		myObj= CreateGameObject("a_lever_56_45_00_0872",67.885712f,4.200000f,54.020000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_353",false);
		CreateUWActivators(myObj,"ButtonHandler","a_use_trigger_99_99_00_0626",63,0,1,7,353);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_353",8,353, 1);
		SetRotation(myObj,0,180,0);
		SetButtonProperties(myObj,"Sprites/tmobj/tmobj_04","Sprites/tmobj/tmobj_05","Sprites/tmobj/tmobj_06","Sprites/tmobj/tmobj_07","Sprites/tmobj/tmobj_08","Sprites/tmobj/tmobj_09","Sprites/tmobj/tmobj_10","Sprites/tmobj/tmobj_11");
		
		myObj= CreateGameObject("a_lever_57_45_00_0871",68.914284f,4.200000f,54.020000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_353",false);
		CreateUWActivators(myObj,"ButtonHandler","a_use_trigger_99_99_00_0629",63,0,2,7,353);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_353",8,353, 1);
		SetRotation(myObj,0,180,0);
		SetButtonProperties(myObj,"Sprites/tmobj/tmobj_04","Sprites/tmobj/tmobj_05","Sprites/tmobj/tmobj_06","Sprites/tmobj/tmobj_07","Sprites/tmobj/tmobj_08","Sprites/tmobj/tmobj_09","Sprites/tmobj/tmobj_10","Sprites/tmobj/tmobj_11");
		
		myObj= CreateGameObject("a_lever_58_45_00_0870",70.114288f,4.200000f,54.020000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_353",false);
		CreateUWActivators(myObj,"ButtonHandler","a_use_trigger_99_99_00_0625",63,0,3,7,353);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_353",8,353, 1);
		SetRotation(myObj,0,180,0);
		SetButtonProperties(myObj,"Sprites/tmobj/tmobj_04","Sprites/tmobj/tmobj_05","Sprites/tmobj/tmobj_06","Sprites/tmobj/tmobj_07","Sprites/tmobj/tmobj_08","Sprites/tmobj/tmobj_09","Sprites/tmobj/tmobj_10","Sprites/tmobj/tmobj_11");
		
		myObj= CreateGameObject("a_lever_59_45_00_0623",71.314285f,4.200000f,54.020000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_353",false);
		CreateUWActivators(myObj,"ButtonHandler","a_use_trigger_99_99_00_0621",63,0,4,7,353);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_353",8,353, 1);
		SetRotation(myObj,0,180,0);
		SetButtonProperties(myObj,"Sprites/tmobj/tmobj_04","Sprites/tmobj/tmobj_05","Sprites/tmobj/tmobj_06","Sprites/tmobj/tmobj_07","Sprites/tmobj/tmobj_08","Sprites/tmobj/tmobj_09","Sprites/tmobj/tmobj_10","Sprites/tmobj/tmobj_11");
		
		myObj = new GameObject("a_giant_spider_27_46_00_0247");
		pos = new Vector3(32.914284f, 2.400000f, 55.714287f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"68","Sprites/OBJECTS_068");
		SetRotation(myObj,0,0,0);
		
		myObj= CreateGameObject("a_stalactite_28_46_00_0787",34.114285f,4.500000f,55.714287f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_211",true);
		
		myObj= CreateGameObject("a_blood_stain_41_46_00_0550",49.885712f,3.600000f,55.542858f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_221",true);
		
		myObj= CreateGameObject("a_bone_46_46_00_0687",55.714287f,0.000000f,55.714287f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_196",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_196",23,196, 1);
		
		myObj = new GameObject("door_055_046");
		pos = new Vector3(66.514290f, 3.600000f, 55.400002f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_323",true);
		CreateDoor(myObj,"textures/doors/doors_06", 2, 1);
		SetRotation(myObj,-90,90,0);
		
		myObj = new GameObject("a_goblin_04_47_00_0200");
		pos = new Vector3(5.314286f, 3.600000f, 57.257145f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"71","Sprites/OBJECTS_071");
		SetRotation(myObj,0,0,0);
		
		myObj= CreateGameObject("a_skull_28_47_00_0820",34.457142f,2.400000f,56.914288f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_195",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_195",23,195, 1);
		
		myObj= CreateGameObject("a_torch_torches_36_47_00_0618",44.228569f,2.700000f,57.428570f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_145",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_145",9,145, 1);
		
		myObj= CreateGameObject("a_buckler_37_47_00_1020",44.914288f,2.700000f,57.580002f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_062",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_062",2,62, 1);
		
		myObj= CreateGameObject("a_stalactite_37_47_00_0789",45.257145f,4.500000f,57.428570f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_211",true);
		
		myObj= CreateGameObject("a_loaf_of_bread_loaves_of_bread_51_47_00_0657",61.714287f,0.000000f,56.914288f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_181",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_181",24,181, 1);
		
		myObj = new GameObject("door_054_047");
		pos = new Vector3(65.000000f, 3.600000f, 56.914288f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_327",true);
		CreateDoor(myObj,"textures/doors/doors_-12851", 3, 1);
		SetRotation(myObj,-90,-180,0);
		
		myObj= CreateGameObject("some_writing_03_48_00_0617",4.628572f,4.200000f,58.779999f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_358",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_358",10,358, 0);
		SetReadable(myObj);
		SetRotation(myObj,0,0,0);
		SetSprite(myObj, "Sprites/tmobj/tmobj_27");
		SetLink(myObj,581);
		
		myObj = new GameObject("door_005_048");
		pos = new Vector3(6.514286f, 3.600000f, 57.799999f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_320",true);
		CreateDoor(myObj,"textures/doors/doors_00", 53, 0);
		SetRotation(myObj,-90,90,0);
		
		
		
		
		
		myObj= CreateGameObject("a_bedroll_09_48_00_0756",11.314286f,3.900000f,57.771431f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_289",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_289",16,289, 1);
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_23_48_00_0822",28.457144f,2.400000f,58.457142f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj= CreateGameObject("a_stalactite_29_48_00_0788",35.657143f,4.500000f,58.114288f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_211",true);
		
		myObj= CreateGameObject("a_stalactite_34_48_00_0793",41.142857f,4.500000f,58.285713f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_211",true);
		
		myObj= CreateGameObject("a_stalactite_36_48_00_0790",43.714287f,4.500000f,58.114288f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_211",true);
		
		myObj= CreateGameObject("a_pole_57_48_00_0610",69.428566f,3.600000f,57.942856f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_216",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_216",16,216, 1);
		
		myObj= CreateGameObject("a_scroll_57_48_00_0631",68.914284f,3.600000f,58.114288f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_318",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_318",13,318, 1);
		SetReadable(myObj);
		SetLink(myObj,515);
		
		myObj= CreateGameObject("a_pile_of_debris_piles_of_debris_58_48_00_0714",70.114288f,3.600000f,58.114288f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_210",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_210",23,210, 1);
		
		
		myObj = new GameObject("door_004_049");
		pos = new Vector3(5.000000f, 3.600000f, 59.314285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_321",true);
		CreateDoor(myObj,"textures/doors/doors_03", 4, 1);
		SetRotation(myObj,-90,-180,0);
		
		myObj= CreateGameObject("a_bench_benches_11_49_00_0769",13.714286f,3.600000f,59.142857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_336",true);
		
		myObj= CreateGameObject("a_bridge_23_49_00_0878",28.114285f,2.325000f,59.314285f);
		
		myObj= CreateGameObject("a_stalactite_32_49_00_0795",38.914284f,4.500000f,59.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_211",true);
		
		myObj= CreateGameObject("a_stalactite_34_49_00_0794",41.314285f,4.500000f,59.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_211",true);
		
		myObj= CreateGameObject("a_stalactite_36_49_00_0791",43.714287f,4.500000f,59.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_211",true);
		
		myObj= CreateGameObject("a_button_55_49_00_0646",66.514290f,3.900000f,59.980000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_369",false);
		CreateUWActivators(myObj,"ButtonHandler","a_use_trigger_99_99_00_0643",40,0,0,7,369);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_369",8,369, 1);
		SetRotation(myObj,0,0,0);
		SetButtonProperties(myObj, 0, "Sprites/tmflat/tmflat_0001", "Sprites/tmflat/tmflat_0009");
		
		myObj = new GameObject("door_056_049");
		pos = new Vector3(67.714287f, 3.600000f, 59.000000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_326",true);
		CreateDoor(myObj,"textures/doors/doors_-12851", 3, 1);
		SetRotation(myObj,-90,90,0);
		SetPortcullis(myObj,true);
		
		myObj= CreateGameObject("a_chest_03_50_00_0758",3.942857f,3.600000f,60.342857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_349",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_349",19,349, 1);
		////Container contents
		ParentContainer = myObj.AddComponent<Container>();
		myObj.GetComponent<ObjectInteraction>().isContainer = true;
		myObj= CreateGameObject("an_amulet_03_50_00_0745",3.942857f,3.600000f,60.342857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_168",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_168",18,168, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 0);
		////Container contents complete
		
		myObj= CreateGameObject("a_bridge_23_50_00_0877",28.114285f,2.325000f,60.514286f);
		
		myObj= CreateGameObject("a_stalactite_35_50_00_0792",42.857143f,4.500000f,60.857143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_211",true);
		
		myObj= CreateGameObject("a_barrel_03_51_00_0762",3.942857f,3.600000f,61.220001f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_347",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_347",19,347, 1);
		////Container contents
		ParentContainer = myObj.AddComponent<Container>();
		myObj.GetComponent<ObjectInteraction>().isContainer = true;
		myObj= CreateGameObject("a_loaf_of_bread_loaves_of_bread_03_51_00_0749",3.942857f,3.600000f,61.220001f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_181",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_181",24,181, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 0);
		////Container contents complete
		
		myObj= CreateGameObject("a_barrel_03_51_00_0759",4.628572f,3.600000f,62.057144f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_347",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_347",19,347, 1);
		////Container contents
		ParentContainer = myObj.AddComponent<Container>();
		myObj.GetComponent<ObjectInteraction>().isContainer = true;
		myObj= CreateGameObject("a_piece_of_meat_pieces_of_meat_03_51_00_0748",4.628572f,3.600000f,62.057144f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_176",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_176",24,176, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 0);
		////Container contents complete
		
		myObj= CreateGameObject("a_barrel_04_51_00_0761",5.485714f,3.600000f,62.057144f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_347",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_347",19,347, 1);
		////Container contents
		ParentContainer = myObj.AddComponent<Container>();
		myObj.GetComponent<ObjectInteraction>().isContainer = true;
		myObj= CreateGameObject("a_fish_fish_04_51_00_0757",5.485714f,3.600000f,62.057144f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_182",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_182",24,182, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 0);
		////Container contents complete
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_23_51_00_0821",27.942856f,2.400000f,61.885712f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj = new GameObject("door_042_051");
		pos = new Vector3(50.914288f, 3.600000f, 61.400002f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_320",true);
		CreateDoor(myObj,"textures/doors/doors_00", 53, 0);
		SetRotation(myObj,-90,90,0);
		
		
		myObj = new GameObject("door_047_051");
		pos = new Vector3(56.914288f, 3.600000f, 61.400002f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_326",true);
		CreateDoor(myObj,"textures/doors/doors_-12851", 3, 1);
		SetRotation(myObj,-90,90,0);
		SetPortcullis(myObj,true);
		
		myObj= CreateGameObject("a_button_48_51_00_0840",58.114288f,4.200000f,61.220001f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_377",false);
		CreateUWActivators(myObj,"ButtonHandler","a_use_trigger_99_99_00_0639",40,0,0,7,377);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_377",8,377, 1);
		SetRotation(myObj,0,180,0);
		SetButtonProperties(myObj, 1, "Sprites/tmflat/tmflat_0009", "Sprites/tmflat/tmflat_0001");
		
		myObj= CreateGameObject("a_bedroll_56_51_00_0846",68.228569f,3.900000f,62.057144f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_289",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_289",16,289, 1);
		
		myObj = new GameObject("a_goblin_60_51_00_0238");
		pos = new Vector3(72.514290f, 3.600000f, 61.714287f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"80","Sprites/OBJECTS_080");
		SetRotation(myObj,0,0,0);
		
		myObj = new GameObject("door_008_052");
		pos = new Vector3(9.800000f, 3.600000f, 62.914288f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_324",true);
		CreateDoor(myObj,"textures/doors/doors_07", 53, 0);
		SetRotation(myObj,-90,-180,0);
		
		myObj= CreateGameObject("a_blood_stain_21_52_00_0829",25.885715f,2.700000f,63.428570f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_221",true);
		
		myObj= CreateGameObject("a_stalactite_23_52_00_0828",28.457144f,4.500000f,62.914288f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_211",true);
		
		myObj = new GameObject("a_goblin_45_52_00_0233");
		pos = new Vector3(54.857143f, 3.600000f, 62.742855f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"76","Sprites/OBJECTS_076");
		SetRotation(myObj,0,270,0);
		
		
		myObj = new GameObject("a_goblin_52_52_00_0234");
		pos = new Vector3(62.914288f, 3.000000f, 62.914288f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"76","Sprites/OBJECTS_076");
		SetRotation(myObj,0,0,0);
		
		myObj= CreateGameObject("a_blood_stain_19_53_00_0831",23.314285f,2.700000f,64.114288f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_221",true);
		
		myObj= CreateGameObject("a_stalactite_22_53_00_0827",26.914284f,4.500000f,64.114288f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_211",true);
		
		myObj= CreateGameObject("a_stalactite_23_53_00_0826",28.285715f,4.500000f,64.285713f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_211",true);
		
		myObj= CreateGameObject("a_piece_of_meat_pieces_of_meat_30_53_00_0620",37.028572f,3.600000f,64.114288f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_176",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_176",24,176, 1);
		
		myObj= CreateGameObject("leather_gloves_pairs_of_leather_gloves_37_53_00_0800",44.571430f,3.300000f,63.942856f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_038",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_038",2,38, 1);
		
		myObj= CreateGameObject("a_pile_of_bones_piles_of_bones_37_53_00_0802",44.914288f,3.300000f,64.114288f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_198",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_198",23,198, 1);
		
		myObj= CreateGameObject("an_ear_of_corn_ears_of_corn_38_53_00_0619",45.942856f,3.300000f,64.628571f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_180",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_180",24,180, 1);
		
		
		myObj = new GameObject("door_057_053");
		pos = new Vector3(68.599998f, 3.600000f, 64.114288f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_321",true);
		CreateDoor(myObj,"textures/doors/doors_03", 53, 0);
		SetRotation(myObj,-90,-180,0);
		
		myObj= CreateGameObject("a_broken_sword_18_54_00_0832",21.942856f,2.700000f,65.657143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_201",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_201",23,201, 1);
		
		myObj= CreateGameObject("a_skull_18_54_00_0922",22.114285f,2.700000f,65.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_194",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_194",23,194, 1);
		
		myObj= CreateGameObject("a_stalactite_19_54_00_0786",23.314285f,4.500000f,65.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_211",true);
		
		myObj = new GameObject("a_wolf_spider_19_54_00_0246");
		pos = new Vector3(23.314285f, 2.700000f, 65.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"83","Sprites/OBJECTS_083");
		SetRotation(myObj,0,135,0);
		
		myObj= CreateGameObject("a_blood_stain_20_54_00_0830",24.514284f,2.700000f,65.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_221",true);
		
		myObj= CreateGameObject("a_blood_stain_36_54_00_0801",43.714287f,3.300000f,65.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_221",true);
		
		myObj = new GameObject("a_giant_spider_37_54_00_0248");
		pos = new Vector3(45.085712f, 3.300000f, 65.142853f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"68","Sprites/OBJECTS_068");
		SetRotation(myObj,0,180,0);
		
		myObj= CreateGameObject("a_skull_38_54_00_0803",45.771431f,3.300000f,65.142853f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_195",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_195",23,195, 1);
		
		myObj= CreateGameObject("a_spike_38_54_00_0596",45.771431f,3.300000f,64.971428f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_295",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_295",16,295, 1);
		
		myObj= CreateGameObject("a_fountain_08_55_00_0836",10.114285f,1.800000f,66.514290f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_302",true);
		CreateUWActivators(myObj,"ButtonHandler","a_jeweled_shield_99_99_00_0001",40,0,0,7,302);
		
		myObj= CreateGameObject("a_fountain_08_55_00_0764",10.114285f,1.837500f,66.514290f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_457",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_457",69,457, 1);
		
		myObj= CreateGameObject("a_fountain_13_55_00_0835",16.114286f,1.800000f,66.514290f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_302",true);
		CreateUWActivators(myObj,"ButtonHandler","a_jeweled_shield_99_99_00_0001",40,0,0,7,302);
		
		myObj= CreateGameObject("a_fountain_13_55_00_0765",16.114286f,1.837500f,66.514290f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_457",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_457",69,457, 1);
		
		myObj= CreateGameObject("a_pile_of_bones_piles_of_bones_18_55_00_0833",22.457144f,2.700000f,66.171432f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_198",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_198",23,198, 1);
		
		myObj= CreateGameObject("a_leather_vest_19_55_00_0819",23.142857f,2.700000f,66.857147f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_032",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_032",2,32, 1);
		
		myObj = new GameObject("door_031_055");
		pos = new Vector3(37.400002f, 3.600000f, 66.342857f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_320",true);
		CreateDoor(myObj,"textures/doors/doors_00", 53, 0);
		SetRotation(myObj,-90,-180,0);
		
		myObj = new GameObject("a_goblin_46_55_00_0236");
		pos = new Vector3(55.714287f, 3.600000f, 66.514290f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"76","Sprites/OBJECTS_076");
		SetRotation(myObj,0,0,0);
		
		myObj = new GameObject("a_lurker_51_55_00_0206");
		pos = new Vector3(61.714287f, 2.700000f, 66.514290f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"87","Sprites/OBJECTS_087");
		SetRotation(myObj,0,0,0);
		
		myObj = new GameObject("a_goblin_57_55_00_0249");
		pos = new Vector3(68.914284f, 3.600000f, 66.514290f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"80","Sprites/OBJECTS_080");
		SetRotation(myObj,0,270,0);
		myObj= CreateGameObject("a_key_003_1",68.914284f,3.600000f,66.514290f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_269",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_269",5,269, 1);
		CreateKey(myObj, 3);
		
		myObj= CreateGameObject("a_bench_benches_02_56_00_0772",2.914286f,3.600000f,67.714287f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_336",true);
		
		myObj = new GameObject("a_goblin_04_56_00_0230");
		pos = new Vector3(5.314286f, 3.600000f, 67.714287f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"70","Sprites/OBJECTS_070");
		SetRotation(myObj,0,90,0);
		myObj= CreateGameObject("a_scroll_04_56_00_0810",5.314286f,3.600000f,67.714287f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_318",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_318",13,318, 1);
		SetReadable(myObj);
		SetLink(myObj,769);
		
		
		
		myObj= CreateGameObject("some_strong_thread_pieces_of_strong_thread_20_56_00_0920",24.020000f,2.700000f,67.885712f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_284",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_284",16,284, 1);
		
		myObj= CreateGameObject("some_strong_thread_pieces_of_strong_thread_20_56_00_0923",24.514284f,2.700000f,68.057144f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_284",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_284",16,284, 1);
		
		myObj= CreateGameObject("a_pile_of_debris_piles_of_debris_38_56_00_0852",46.114288f,3.600000f,67.714287f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_208",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_208",23,208, 1);
		
		myObj = new GameObject("a_goblin_45_56_00_0237");
		pos = new Vector3(54.514286f, 3.600000f, 67.714287f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"76","Sprites/OBJECTS_076");
		SetRotation(myObj,0,0,0);
		
		myObj = new GameObject("a_goblin_47_56_00_0235");
		pos = new Vector3(56.914288f, 3.600000f, 67.714287f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"76","Sprites/OBJECTS_076");
		SetRotation(myObj,0,0,0);
		
		myObj = new GameObject("a_goblin_02_57_00_0231");
		pos = new Vector3(3.580000f, 3.600000f, 68.742859f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"71","Sprites/OBJECTS_071");
		SetRotation(myObj,0,90,0);
		myObj= CreateGameObject("a_key_004_1",3.580000f,3.600000f,68.742859f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_266",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_266",5,266, 1);
		CreateKey(myObj, 4);
		
		myObj= CreateGameObject("some_strong_thread_pieces_of_strong_thread_20_57_00_0919",24.685715f,2.700000f,68.742859f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_284",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_284",16,284, 1);
		
		myObj= CreateGameObject("a_pile_of_bones_piles_of_bones_29_57_00_0647",35.142857f,3.600000f,69.257141f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_198",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_198",23,198, 1);
		
		myObj= CreateGameObject("some_rubble_piles_of_rubble_41_57_00_0854",49.714287f,3.600000f,68.914284f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_218",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_218",69,218, 0);
		
		myObj= CreateGameObject("a_fish_fish_47_57_00_0669",56.571430f,3.300000f,68.571434f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_182",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_182",24,182, 1);
		
		myObj= CreateGameObject("a_blood_stain_47_57_00_0717",57.257145f,3.300000f,68.742859f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_221",true);
		
		myObj= CreateGameObject("a_pile_of_bones_piles_of_bones_47_57_00_0718",57.257145f,3.300000f,69.257141f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_198",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_198",23,198, 1);
		
		myObj= CreateGameObject("a_skull_47_57_00_0719",56.914288f,3.300000f,69.428566f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_194",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_194",23,194, 1);
		
		myObj= CreateGameObject("a_campfire_47_57_00_0720",56.914288f,3.300000f,68.914284f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_298",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_298",16,298, 0);
		
		myObj= CreateGameObject("a_bench_benches_02_58_00_0771",2.914286f,3.600000f,70.285713f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_336",true);
		
		myObj= CreateGameObject("a_campfire_03_58_00_0543",4.457143f,3.600000f,70.457146f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_298",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_298",16,298, 0);
		
		myObj= CreateGameObject("a_mandolin_03_58_00_0542",3.942857f,3.600000f,70.285713f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_291",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_291",16,291, 1);
		
		
		
		myObj = new GameObject("door_035_058");
		pos = new Vector3(42.200001f, 3.600000f, 69.620003f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_327",true);
		CreateDoor(myObj,"textures/doors/doors_-12851", 53, 0);
		SetRotation(myObj,-90,-180,0);
		
		myObj = new GameObject("a_goblin_51_58_00_0203");
		pos = new Vector3(62.228569f, 3.000000f, 69.942856f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"76","Sprites/OBJECTS_076");
		SetRotation(myObj,0,180,0);
		
		myObj= CreateGameObject("some_writing_54_58_00_0713",65.980003f,4.200000f,70.457146f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_358",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_358",10,358, 0);
		SetReadable(myObj);
		SetRotation(myObj,0,90,0);
		SetSprite(myObj, "Sprites/tmobj/tmobj_21");
		SetLink(myObj,581);
		
		myObj= CreateGameObject("a_sack_56_58_00_0693",67.542854f,3.600000f,69.942856f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_128",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_128",19,128, 1);
		////Container contents
		ParentContainer = myObj.AddComponent<Container>();
		myObj.GetComponent<ObjectInteraction>().isContainer = true;
		myObj= CreateGameObject("a_sling_stone_56_58_00_0694",67.542854f,3.600000f,69.942856f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_016",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_016",1,16, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 0);
		myObj= CreateGameObject("a_sling_stone_56_58_00_0958",67.542854f,3.600000f,69.942856f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_016",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_016",1,16, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 1);
		////Container contents complete
		
		myObj= CreateGameObject("a_lantern_57_58_00_0703",69.085716f,3.600000f,70.457146f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_144",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_144",9,144, 1);
		
		myObj= CreateGameObject("a_gold_coffer_57_58_00_0709",68.914284f,3.600000f,70.114288f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_138",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_138",19,138, 1);
		////Container contents
		ParentContainer = myObj.AddComponent<Container>();
		myObj.GetComponent<ObjectInteraction>().isContainer = true;
		myObj= CreateGameObject("a_coin_57_58_00_0708",68.914284f,3.600000f,70.114288f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_160",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_160",18,160, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 0);
		myObj= CreateGameObject("a_ruby_rubies_57_58_00_0707",68.914284f,3.600000f,70.114288f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_162",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_162",18,162, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 1);
		myObj= CreateGameObject("a_sapphire_57_58_00_0706",68.914284f,3.600000f,70.114288f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_166",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_166",18,166, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 2);
		////Container contents complete
		
		myObj= CreateGameObject("a_fountain_08_59_00_0924",10.114285f,1.800000f,71.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_302",true);
		CreateUWActivators(myObj,"ButtonHandler","a_jeweled_shield_99_99_00_0001",40,0,0,7,302);
		
		myObj= CreateGameObject("a_fountain_08_59_00_0766",10.114285f,1.837500f,71.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_457",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_457",69,457, 1);
		
		myObj= CreateGameObject("a_fountain_13_59_00_0925",16.114286f,1.800000f,71.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_302",true);
		CreateUWActivators(myObj,"ButtonHandler","a_jeweled_shield_99_99_00_0001",40,0,0,7,302);
		
		myObj= CreateGameObject("a_fountain_13_59_00_0834",16.114286f,1.837500f,71.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_457",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_457",69,457, 1);
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_26_59_00_0660",32.228573f,1.200000f,71.657143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj= CreateGameObject("a_plant_27_59_00_0662",33.257145f,1.500000f,70.971428f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_206",true);
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_27_59_00_0663",33.428574f,1.500000f,71.828568f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_27_59_00_0664",32.914284f,1.500000f,71.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj= CreateGameObject("a_plant_28_59_00_0661",33.942856f,1.500000f,71.485710f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_206",true);
		
		myObj = new GameObject("a_goblin_52_59_00_0202");
		pos = new Vector3(63.257145f, 3.600000f, 71.657143f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"80","Sprites/OBJECTS_080");
		SetRotation(myObj,0,90,0);
		
		myObj = new GameObject("door_055_059");
		pos = new Vector3(66.514290f, 3.600000f, 71.000000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_322",true);
		CreateDoor(myObj,"textures/doors/doors_05", 3, 1);
		SetRotation(myObj,-90,90,0);
		
		myObj = new GameObject("a_flesh_slug_37_60_00_0221");
		pos = new Vector3(44.914288f, 2.700000f, 72.514290f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"65","Sprites/OBJECTS_065");
		SetRotation(myObj,0,0,0);
		
		
		myObj= CreateGameObject("a_barrel_56_60_00_0710",68.057144f,3.600000f,72.685715f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_347",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_347",19,347, 1);
		////Container contents
		ParentContainer = myObj.AddComponent<Container>();
		myObj.GetComponent<ObjectInteraction>().isContainer = true;
		myObj= CreateGameObject("a_fish_fish_56_60_00_0705",68.057144f,3.600000f,72.685715f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_182",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_182",24,182, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 0);
		////Container contents complete
		
		myObj= CreateGameObject("a_barrel_57_60_00_0711",69.085716f,3.600000f,72.019997f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_347",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_347",19,347, 1);
		////Container contents
		ParentContainer = myObj.AddComponent<Container>();
		myObj.GetComponent<ObjectInteraction>().isContainer = true;
		myObj= CreateGameObject("a_loaf_of_bread_loaves_of_bread_57_60_00_0704",69.085716f,3.600000f,72.019997f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_177",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_177",24,177, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 0);
		////Container contents complete
		
		myObj= CreateGameObject("a_barrel_57_60_00_0712",68.742859f,3.600000f,72.685715f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_347",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_347",19,347, 1);
		////Container contents complete
		
		myObj= CreateGameObject("special_tmap_obj_24_61_00_0886",29.400000f,1.200000f,74.379997f);
		SetScale(myObj,(float)0.937500,(float)0.937500,(float)0.937500);
		CreateTMAP(myObj,"textures/tmap/uw1_071");
		SetRotation(myObj,0,0,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_366",34,366, 0);
		
		myObj= CreateGameObject("special_tmap_obj_25_61_00_0887",30.600000f,1.200000f,74.379997f);
		SetScale(myObj,(float)0.937500,(float)0.937500,(float)0.937500);
		CreateTMAP(myObj,"textures/tmap/uw1_071");
		SetRotation(myObj,0,0,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_366",34,366, 0);
		
		myObj= CreateGameObject("some_writing_30_61_00_0665",36.514286f,2.400000f,74.379997f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_358",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_358",10,358, 0);
		SetReadable(myObj);
		SetRotation(myObj,0,0,0);
		SetSprite(myObj, "Sprites/tmobj/tmobj_20");
		SetLink(myObj,577);
		
		myObj= CreateGameObject("a_fountain_30_61_00_0666",36.685715f,1.537500f,73.885712f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_457",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_457",69,457, 1);
		
		myObj= CreateGameObject("a_fountain_30_61_00_0667",36.685715f,1.500000f,73.885712f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_302",true);
		CreateUWActivators(myObj,"ButtonHandler","a_toadstool_16_04_00_0582",40,0,8,7,302);
		
		myObj= CreateGameObject("a_lockpick_000_3",42.857143f,3.000000f,74.057144f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_257",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_257",5,257, 1);
		CreateKey(myObj, 0);
		
		myObj= CreateGameObject("some_writing_38_61_00_0902",46.114288f,3.900000f,74.379997f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_358",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_358",10,358, 0);
		SetReadable(myObj);
		SetRotation(myObj,0,0,0);
		SetSprite(myObj, "Sprites/tmobj/tmobj_20");
		SetLink(myObj,579);
		
		myObj= CreateGameObject("special_tmap_obj_38_61_00_0903",46.200001f,2.400000f,74.379997f);
		SetScale(myObj,(float)0.937500,(float)0.937500,(float)0.937500);
		CreateTMAP(myObj,"textures/tmap/uw1_160");
		SetRotation(myObj,0,0,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_366",34,366, 0);
		
		myObj= CreateGameObject("a_set_variable_trap_99_99_00_0004",120.000000f,1.387500f,119.142860f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_397",false);
		Create_a_set_variable_trap(myObj);
		
		myObj= CreateGameObject("a_check_variable_trap_99_99_00_0007",118.800003f,2.737500f,119.142860f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_398",false);
		Create_a_check_variable_trap(myObj);
		
		myObj= CreateGameObject("BUGGEDOBJECT_00_0010",120.000000f,4.425000f,119.142860f);
		CreateObjectGraphics(myObj,"Á",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"",38,510, 15728684);
		Create_a_teleport_trap(myObj,(float)60.600000,(float)22.200000,(float)3.600000,true);
		
		myObj= CreateGameObject("a_door_trap_99_99_00_0031",119.485710f,2.512500f,118.800003f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_392",false);
		Create_a_door_trap(myObj,59);
		AddTrapLink(myObj,"a_button_99_99_00_0462");
		
		myObj= CreateGameObject("a_delete_object_trap_99_99_00_0032",119.657135f,0.075000f,120.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_395",false);
		Create_a_delete_object_trap(myObj);
		
		myObj= CreateGameObject("BUGGEDOBJECT_00_0035",119.657135f,4.275000f,119.314285f);
		CreateObjectGraphics(myObj,"Á",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"",38,511, 15728640);
		Create_a_teleport_trap(myObj,(float)66.600000,(float)37.800000,(float)3.600000,true);
		
		myObj= CreateGameObject("a_set_variable_trap_99_99_00_0036",119.657135f,0.225000f,118.971428f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_397",false);
		Create_a_set_variable_trap(myObj);
		
		myObj= CreateGameObject("BUGGEDOBJECT_00_0039",120.000000f,4.650000f,119.485710f);
		CreateObjectGraphics(myObj,"Á",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"",38,511, 15728640);
		Create_a_teleport_trap(myObj,(float)55.800000,(float)46.200000,(float)3.600000,true);
		
		myObj= CreateGameObject("a_arrow_trap_99_99_00_0061",118.800003f,4.462500f,118.971428f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_386",false);
		Create_a_arrow_trap(myObj);
		
		myObj= CreateGameObject("a_arrow_trap_99_99_00_0076",118.800003f,2.362500f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_386",false);
		Create_a_arrow_trap(myObj);
		
		myObj= CreateGameObject("BUGGEDOBJECT_00_0129",119.314285f,4.350000f,118.800003f);
		CreateObjectGraphics(myObj,"Á",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"",38,511, 15728640);
		Create_a_teleport_trap(myObj,(float)73.800000,(float)0.600000,(float)4.500000,true);
		
		myObj= CreateGameObject("a_do_trap_99_99_00_0261",119.657135f,3.300000f,119.657135f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_387",false);
		Create_trap_base(myObj);
		AddTrapLink(myObj,"a_lever_09_36_00_0744");
		
		myObj= CreateGameObject("BUGGEDOBJECT_00_0279",118.971428f,2.737500f,118.971428f);
		CreateObjectGraphics(myObj,"Á",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"",38,511, 15728640);
		Create_a_teleport_trap(myObj,(float)10.200000,(float)28.200000,(float)0.300000,true);
		AddTrapLink(myObj,"a_use_trigger_99_99_00_0559");
		
		myObj= CreateGameObject("a_spelltrap_99_99_00_0283",119.657135f,0.900000f,118.800003f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_390",false);
		Create_a_spelltrap(myObj);
		
		myObj= CreateGameObject("a_damage_trap_99_99_00_0294",119.828575f,0.225000f,119.657135f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_384",false);
		Create_a_damage_trap(myObj);
		
		myObj= CreateGameObject("BUGGEDOBJECT_00_0302",118.971428f,4.350000f,119.142860f);
		CreateObjectGraphics(myObj,"Á",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"",38,511, 15728640);
		Create_a_teleport_trap(myObj,(float)73.800000,(float)0.600000,(float)4.500000,true);
		
		myObj= CreateGameObject("a_spelltrap_99_99_00_0329",120.000000f,0.225000f,119.485710f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_390",false);
		Create_a_spelltrap(myObj);
		AddTrapLink(myObj,"a_switch_99_99_00_0112");
		
		myObj= CreateGameObject("BUGGEDOBJECT_00_0340",118.971428f,1.237500f,119.485710f);
		CreateObjectGraphics(myObj,"Á",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"",38,511, 15728640);
		Create_a_teleport_trap(myObj,(float)11.400000,(float)59.400000,(float)3.600000,true);
		
		myObj= CreateGameObject("a_create_object_trap_99_99_00_0342",118.971428f,2.737500f,119.485710f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_391",false);
		Create_a_create_object_trap(myObj);
		
		myObj= CreateGameObject("a_delete_object_trap_99_99_00_0347",119.485710f,3.150000f,118.971428f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_395",false);
		Create_a_delete_object_trap(myObj);
		AddTrapLink(myObj,"a_button_48_51_00_0840");
		
		myObj= CreateGameObject("a_step_on_trigger_99_99_00_0353",118.800003f,3.562500f,120.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_420",false);
		CreateTrigger(myObj,6,11,"some_grass_bunches_of_grass_32_02_00_0990");
		
		myObj= CreateGameObject("BUGGEDOBJECT_00_0357",119.657135f,2.400000f,119.828575f);
		CreateObjectGraphics(myObj,"Á",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"",38,511, 15728640);
		Create_a_teleport_trap(myObj,(float)5.400000,(float)76.200000,(float)4.500000,true);
		
		myObj= CreateGameObject("a_delete_object_trap_99_99_00_0380",118.971428f,0.412500f,120.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_395",false);
		Create_a_delete_object_trap(myObj);
		
		myObj= CreateGameObject("a_teleport_trap_99_99_00_0381",119.485710f,2.700000f,119.657135f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_385",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_385",38,385, 0);
		Create_a_teleport_trap(myObj,(float)73.800000,(float)52.200000,(float)4.500000,true);
		
		myObj= CreateGameObject("an_inventory_trap_99_99_00_0403",118.800003f,2.025000f,118.971428f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_396",false);
		Create_an_inventory_trap(myObj);
		
		myObj= CreateGameObject("a_delete_object_trap_99_99_00_0406",119.142860f,0.150000f,118.800003f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_395",false);
		Create_a_delete_object_trap(myObj);
		
		myObj= CreateGameObject("an_inventory_trap_99_99_00_0421",120.000000f,0.525000f,120.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_396",false);
		Create_an_inventory_trap(myObj);
		
		myObj= CreateGameObject("BUGGEDOBJECT_00_0443",119.485710f,2.812500f,119.657135f);
		CreateObjectGraphics(myObj,"Á",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"",38,511, 15728640);
		Create_a_teleport_trap(myObj,(float)13.800000,(float)75.000000,(float)4.500000,true);
		
		myObj= CreateGameObject("a_tell_trap_99_99_00_0459",120.000000f,0.000000f,118.800003f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_394",false);
		Create_a_tell_trap(myObj);
		
		myObj= CreateGameObject("a_text_string_trap_99_99_00_0469",118.800003f,4.350000f,119.485710f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_400",false);
		Create_a_text_string_trap(myObj,9,16);
		
		myObj= CreateGameObject("a_teleport_trap_99_99_00_0497",118.800003f,3.112500f,118.971428f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_385",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_385",38,385, 0);
		Create_a_teleport_trap(myObj,(float)59.400000,(float)23.400000,(float)3.600000,true);
		AddTrapLink(myObj,"a_move_trigger_47_53_00_0943");
		
		myObj= CreateGameObject("a_delete_object_trap_99_99_00_0504",119.485710f,0.300000f,119.485710f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_395",false);
		Create_a_delete_object_trap(myObj);
		
		myObj= CreateGameObject("a_text_string_trap_34_01_00_0547",40.799999f,4.500000f,1.200000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_400",false);
		Create_a_text_string_trap(myObj,9,3);
		
		myObj= CreateGameObject("a_use_trigger_99_99_00_0559",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_418",false);
		CreateTrigger(myObj,34,1,"a_text_string_trap_34_01_00_0547");
		
		myObj= CreateGameObject("a_do_trap_03_49_00_0567",3.600000f,4.500000f,58.799999f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_387",false);
		Create_trap_base(myObj);
		
		myObj= CreateGameObject("a_do_trap_55_60_00_0571",66.000000f,2.700000f,72.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_387",false);
		Create_trap_base(myObj);
		
		myObj= CreateGameObject("an_open_trigger_99_99_00_0572",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_421",false);
		CreateTrigger(myObj,55,60,"a_do_trap_55_60_00_0571");
		
		myObj= CreateGameObject("a_use_trigger_99_99_00_0574",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_418",false);
		CreateTrigger(myObj,34,1,"a_text_string_trap_34_01_00_0547");
		
		myObj= CreateGameObject("an_open_trigger_99_99_00_0575",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_421",false);
		CreateTrigger(myObj,3,49,"a_do_trap_03_49_00_0567");
		
		myObj= CreateGameObject("a_create_object_trap_47_04_00_0595",56.400002f,0.900000f,4.800000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_391",false);
		Create_a_create_object_trap(myObj);
		
		myObj= CreateGameObject("a_create_object_trap_03_17_00_0599",3.600000f,2.700000f,20.400000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_391",false);
		Create_a_create_object_trap(myObj);
		
		myObj= CreateGameObject("a_create_object_trap_14_07_00_0600",16.799999f,0.300000f,8.400000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_391",false);
		Create_a_create_object_trap(myObj);
		
		myObj= CreateGameObject("a_use_trigger_99_99_00_0621",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_418",false);
		CreateTrigger(myObj,49,44,"a_do_trap_49_44_00_0622");
		
		myObj= CreateGameObject("a_do_trap_49_44_00_0622",58.799999f,0.600000f,52.799999f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_387",false);
		Create_a_do_trap(myObj,3,1003764);
		
		myObj= CreateGameObject("a_do_trap_45_44_00_0624",54.000000f,0.600000f,52.799999f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_387",false);
		Create_a_do_trap(myObj,3,1003764);
		
		myObj= CreateGameObject("a_use_trigger_99_99_00_0625",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_418",false);
		CreateTrigger(myObj,47,44,"a_do_trap_47_44_00_0628");
		
		myObj= CreateGameObject("a_use_trigger_99_99_00_0626",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_418",false);
		CreateTrigger(myObj,43,44,"a_do_trap_43_44_00_0627");
		
		myObj= CreateGameObject("a_do_trap_43_44_00_0627",51.599998f,0.600000f,52.799999f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_387",false);
		Create_a_do_trap(myObj,3,1003764);
		
		myObj= CreateGameObject("a_do_trap_47_44_00_0628",56.400002f,0.600000f,52.799999f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_387",false);
		Create_a_do_trap(myObj,3,1003764);
		
		myObj= CreateGameObject("a_use_trigger_99_99_00_0629",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_418",false);
		CreateTrigger(myObj,45,44,"a_do_trap_45_44_00_0624");
		
		myObj= CreateGameObject("a_create_object_trap_03_33_00_0630",3.600000f,3.600000f,39.599998f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_391",false);
		Create_a_create_object_trap(myObj);
		
		myObj= CreateGameObject("a_move_trigger_42_51_00_0634",51.000000f,3.600000f,61.799999f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateTrigger(myObj,47,51,"a_door_trap_99_99_00_0914");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		
		myObj= CreateGameObject("a_move_trigger_15_33_00_0635",18.600000f,2.100000f,40.200001f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateTrigger(myObj,15,34,"a_door_trap_99_99_00_0636");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		
		myObj= CreateGameObject("a_door_trap_99_99_00_0636",118.800003f,2.100000f,118.800003f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_392",false);
		Create_a_door_trap(myObj,2);
		
		myObj= CreateGameObject("a_use_trigger_99_99_00_0637",119.314285f,2.100000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_418",false);
		CreateTrigger(myObj,15,34,"a_door_trap_99_99_00_0770");
		
		myObj= CreateGameObject("a_use_trigger_99_99_00_0639",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_418",false);
		CreateTrigger(myObj,47,51,"a_door_trap_99_99_00_0848");
		
		myObj= CreateGameObject("a_use_trigger_99_99_00_0643",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_418",false);
		CreateTrigger(myObj,56,49,"a_door_trap_99_99_00_0645");
		
		myObj= CreateGameObject("a_door_trap_99_99_00_0645",118.800003f,3.600000f,118.800003f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_392",false);
		Create_a_door_trap(myObj,3);
		
		myObj= CreateGameObject("a_door_trap_99_99_00_0690",118.800003f,0.300000f,118.800003f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_392",false);
		Create_a_door_trap(myObj,3);
		
		myObj= CreateGameObject("a_use_trigger_99_99_00_0691",119.314285f,0.300000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_418",false);
		CreateTrigger(myObj,9,10,"a_door_trap_99_99_00_0690");
		
		myObj= CreateGameObject("a_move_trigger_03_36_00_0715",4.200000f,3.600000f,43.799999f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateTrigger(myObj,3,33,"a_create_object_trap_03_33_00_0630");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		
		myObj= CreateGameObject("a_use_trigger_99_99_00_0742",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_418",false);
		CreateTrigger(myObj,9,35,"a_door_trap_99_99_00_0743");
		
		myObj= CreateGameObject("a_door_trap_99_99_00_0743",118.800003f,3.600000f,118.800003f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_392",false);
		Create_a_door_trap(myObj,3);
		
		myObj= CreateGameObject("a_door_trap_99_99_00_0770",118.800003f,2.100000f,118.800003f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_392",false);
		Create_a_door_trap(myObj,3);
		
		myObj= CreateGameObject("a_create_object_trap_27_34_00_0813",32.400002f,2.100000f,40.799999f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_391",false);
		Create_a_create_object_trap(myObj);
		
		myObj= CreateGameObject("a_use_trigger_99_99_00_0816",119.314285f,2.700000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_418",false);
		CreateTrigger(myObj,46,8,"a_door_trap_99_99_00_0818");
		
		myObj= CreateGameObject("a_door_trap_99_99_00_0818",118.800003f,2.700000f,118.800003f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_392",false);
		Create_a_door_trap(myObj,3);
		
		myObj= CreateGameObject("a_move_trigger_07_34_00_0825",9.000000f,0.000000f,41.400002f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateTrigger(myObj,8,35,"a_teleport_trap_06_34_00_1023");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		
		myObj= CreateGameObject("a_door_trap_99_99_00_0837",118.800003f,3.000000f,118.800003f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_392",false);
		Create_a_door_trap(myObj,3);
		
		myObj= CreateGameObject("a_door_trap_99_99_00_0848",118.800003f,3.600000f,118.800003f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_392",false);
		Create_a_door_trap(myObj,3);
		
		myObj= CreateGameObject("a_look_trigger_99_99_00_0910",119.314285f,0.000000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_419",false);
		CreateTrigger(myObj,58,13,"a_text_string_trap_58_13_00_0911");
		
		myObj= CreateGameObject("a_text_string_trap_58_13_00_0911",69.599998f,3.900000f,15.600000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_400",false);
		Create_a_text_string_trap(myObj,9,1);
		
		myObj= CreateGameObject("a_door_trap_99_99_00_0914",118.800003f,3.600000f,118.800003f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_392",false);
		Create_a_door_trap(myObj,2);
		
		myObj= CreateGameObject("a_move_trigger_47_53_00_0943",57.000000f,0.000000f,64.199997f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateTrigger(myObj,47,52,"a_teleport_trap_47_52_00_0944");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		
		myObj= CreateGameObject("a_teleport_trap_47_52_00_0944",56.400002f,0.075000f,62.400002f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_385",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_385",38,385, 0);
		Create_a_teleport_trap(myObj,(float)57.000000,(float)64.200000,(float)0.000000,true);
		
		myObj= CreateGameObject("a_teleport_trap_28_20_00_0985",33.599998f,0.075000f,24.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_385",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_385",38,385, 0);
		Create_a_teleport_trap(myObj,(float)42.600000,(float)24.600000,(float)3.000000,true);
		
		myObj= CreateGameObject("a_move_trigger_27_20_00_0991",33.000000f,3.000000f,24.600000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateTrigger(myObj,27,20,"a_teleport_trap_28_20_00_0985");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		
		myObj= CreateGameObject("a_use_trigger_99_99_00_0992",119.314285f,3.000000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_418",false);
		CreateTrigger(myObj,33,8,"a_door_trap_99_99_00_0837");
		
		myObj= CreateGameObject("a_teleport_trap_06_34_00_1023",7.200000f,0.075000f,40.799999f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_385",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_385",38,385, 0);
		Create_a_teleport_trap(myObj,(float)9.000000,(float)46.200000,(float)3.600000,true);

	







	



		



		}



	[MenuItem("MyTools/RenameBrushes")]
	static void BrushRenamer()
	{
		RenameBrushes("world.worldspawn.Brush_1","Tile_30_00");
			
	}

	[MenuItem("MyTools/SetTilemapInfo")]
	static void SetTileMapInfo()
	{
		GameObject tilemapObj = GameObject.Find ("TileMap");
		TileMap tilemap= tilemapObj.GetComponent<TileMap>();
		
		SetTileProp(tilemap, 0,0,0,1,0,0);
		SetTileProp(tilemap, 0,1,0,1,0,0);
		SetTileProp(tilemap, 0,2,0,1,4,0);
		SetTileProp(tilemap, 0,3,0,1,4,0);
		SetTileProp(tilemap, 0,4,0,1,4,0);
		SetTileProp(tilemap, 0,5,0,1,4,0);
		SetTileProp(tilemap, 0,6,0,1,4,0);
		SetTileProp(tilemap, 0,7,0,1,4,0);
		SetTileProp(tilemap, 0,8,0,1,4,0);
		SetTileProp(tilemap, 0,9,0,1,4,0);
		SetTileProp(tilemap, 0,10,0,1,4,0);
		SetTileProp(tilemap, 0,11,0,1,4,6);
		SetTileProp(tilemap, 0,12,0,1,4,0);
		SetTileProp(tilemap, 0,13,0,1,4,0);
		SetTileProp(tilemap, 0,14,0,1,4,0);
		SetTileProp(tilemap, 0,15,0,1,4,0);
		SetTileProp(tilemap, 0,16,0,1,4,0);
		SetTileProp(tilemap, 0,17,0,1,4,0);
		SetTileProp(tilemap, 0,18,0,1,4,0);
		SetTileProp(tilemap, 0,19,0,1,4,0);
		SetTileProp(tilemap, 0,20,0,1,4,0);
		SetTileProp(tilemap, 0,21,0,1,4,0);
		SetTileProp(tilemap, 0,22,0,1,4,0);
		SetTileProp(tilemap, 0,23,0,1,4,0);
		SetTileProp(tilemap, 0,24,0,1,4,0);
		SetTileProp(tilemap, 0,25,0,1,4,0);
		SetTileProp(tilemap, 0,26,0,1,4,0);
		SetTileProp(tilemap, 0,27,0,1,4,0);
		SetTileProp(tilemap, 0,28,0,1,4,0);
		SetTileProp(tilemap, 0,29,0,1,4,0);
		SetTileProp(tilemap, 0,30,0,1,0,0);
		SetTileProp(tilemap, 0,31,0,1,0,0);
		SetTileProp(tilemap, 0,32,0,1,0,0);
		SetTileProp(tilemap, 0,33,0,1,0,0);
		SetTileProp(tilemap, 0,34,0,1,0,0);
		SetTileProp(tilemap, 0,35,0,1,0,0);
		SetTileProp(tilemap, 0,36,0,1,0,0);
		SetTileProp(tilemap, 0,37,0,1,0,0);
		SetTileProp(tilemap, 0,38,0,1,0,0);
		SetTileProp(tilemap, 0,39,0,1,0,0);
		SetTileProp(tilemap, 0,40,0,1,4,0);
		SetTileProp(tilemap, 0,41,0,1,4,0);
		SetTileProp(tilemap, 0,42,0,1,4,0);
		SetTileProp(tilemap, 0,43,0,1,4,0);
		SetTileProp(tilemap, 0,44,0,1,4,0);
		SetTileProp(tilemap, 0,45,0,1,4,0);
		SetTileProp(tilemap, 0,46,0,1,4,0);
		SetTileProp(tilemap, 0,47,0,1,4,0);
		SetTileProp(tilemap, 0,48,0,1,4,0);
		SetTileProp(tilemap, 0,49,0,1,4,0);
		SetTileProp(tilemap, 0,50,0,1,4,0);
		SetTileProp(tilemap, 0,51,0,1,4,0);
		SetTileProp(tilemap, 0,52,0,1,4,0);
		SetTileProp(tilemap, 0,53,0,1,0,0);
		SetTileProp(tilemap, 0,54,0,1,0,0);
		SetTileProp(tilemap, 0,55,0,1,0,0);
		SetTileProp(tilemap, 0,56,0,1,0,0);
		SetTileProp(tilemap, 0,57,0,1,0,0);
		SetTileProp(tilemap, 0,58,0,1,0,0);
		SetTileProp(tilemap, 0,59,0,1,0,0);
		SetTileProp(tilemap, 0,60,0,1,0,0);
		SetTileProp(tilemap, 0,61,0,1,0,0);
		SetTileProp(tilemap, 0,62,0,1,0,0);
		SetTileProp(tilemap, 1,0,0,1,0,0);
		SetTileProp(tilemap, 1,1,0,1,0,0);
		SetTileProp(tilemap, 1,2,0,1,4,0);
		SetTileProp(tilemap, 1,3,0,1,4,0);
		SetTileProp(tilemap, 1,4,0,1,4,0);
		SetTileProp(tilemap, 1,5,0,1,4,0);
		SetTileProp(tilemap, 1,6,0,1,4,0);
		SetTileProp(tilemap, 1,7,0,1,4,0);
		SetTileProp(tilemap, 1,8,0,1,4,0);
		SetTileProp(tilemap, 1,9,0,1,4,0);
		SetTileProp(tilemap, 1,10,0,1,4,0);
		SetTileProp(tilemap, 1,11,0,1,4,0);
		SetTileProp(tilemap, 1,12,0,1,4,0);
		SetTileProp(tilemap, 1,13,0,1,4,0);
		SetTileProp(tilemap, 1,14,0,1,4,0);
		SetTileProp(tilemap, 1,15,0,1,4,0);
		SetTileProp(tilemap, 1,16,0,1,4,0);
		SetTileProp(tilemap, 1,17,0,1,4,0);
		SetTileProp(tilemap, 1,18,0,1,4,0);
		SetTileProp(tilemap, 1,19,0,1,4,0);
		SetTileProp(tilemap, 1,20,0,1,4,0);
		SetTileProp(tilemap, 1,21,0,1,4,0);
		SetTileProp(tilemap, 1,22,0,1,4,0);
		SetTileProp(tilemap, 1,23,0,1,4,0);
		SetTileProp(tilemap, 1,24,0,1,4,0);
		SetTileProp(tilemap, 1,25,0,1,4,0);
		SetTileProp(tilemap, 1,26,0,1,4,0);
		SetTileProp(tilemap, 1,27,0,1,4,0);
		SetTileProp(tilemap, 1,28,0,1,4,0);
		SetTileProp(tilemap, 1,29,0,1,4,0);
		SetTileProp(tilemap, 1,30,0,1,0,0);
		SetTileProp(tilemap, 1,31,0,1,0,0);
		SetTileProp(tilemap, 1,32,0,1,0,0);
		SetTileProp(tilemap, 1,33,0,1,0,0);
		SetTileProp(tilemap, 1,34,0,1,0,0);
		SetTileProp(tilemap, 1,35,0,1,0,0);
		SetTileProp(tilemap, 1,36,0,1,0,0);
		SetTileProp(tilemap, 1,37,0,1,0,0);
		SetTileProp(tilemap, 1,38,0,1,0,0);
		SetTileProp(tilemap, 1,39,0,1,0,0);
		SetTileProp(tilemap, 1,40,0,1,4,0);
		SetTileProp(tilemap, 1,41,0,1,4,0);
		SetTileProp(tilemap, 1,42,0,1,4,0);
		SetTileProp(tilemap, 1,43,0,1,4,0);
		SetTileProp(tilemap, 1,44,0,1,4,0);
		SetTileProp(tilemap, 1,45,0,1,4,0);
		SetTileProp(tilemap, 1,46,0,1,4,0);
		SetTileProp(tilemap, 1,47,0,1,4,0);
		SetTileProp(tilemap, 1,48,0,1,4,0);
		SetTileProp(tilemap, 1,49,0,1,4,0);
		SetTileProp(tilemap, 1,50,0,1,4,0);
		SetTileProp(tilemap, 1,51,0,1,4,0);
		SetTileProp(tilemap, 1,52,0,1,4,0);
		SetTileProp(tilemap, 1,53,0,1,0,0);
		SetTileProp(tilemap, 1,54,0,1,0,0);
		SetTileProp(tilemap, 1,55,0,1,0,0);
		SetTileProp(tilemap, 1,56,0,1,0,0);
		SetTileProp(tilemap, 1,57,0,1,0,0);
		SetTileProp(tilemap, 1,58,0,1,0,0);
		SetTileProp(tilemap, 1,59,0,1,0,0);
		SetTileProp(tilemap, 1,60,0,1,0,0);
		SetTileProp(tilemap, 1,61,0,1,0,0);
		SetTileProp(tilemap, 1,62,0,1,0,0);
		SetTileProp(tilemap, 2,0,0,1,0,0);
		SetTileProp(tilemap, 2,1,0,1,0,0);
		SetTileProp(tilemap, 2,2,0,1,4,0);
		SetTileProp(tilemap, 2,3,0,1,4,0);
		SetTileProp(tilemap, 2,4,0,1,4,0);
		SetTileProp(tilemap, 2,5,0,1,4,0);
		SetTileProp(tilemap, 2,6,0,1,4,0);
		SetTileProp(tilemap, 2,7,0,1,4,0);
		SetTileProp(tilemap, 2,8,0,1,4,0);
		SetTileProp(tilemap, 2,9,0,1,4,0);
		SetTileProp(tilemap, 2,10,0,1,4,0);
		SetTileProp(tilemap, 2,11,0,1,4,0);
		SetTileProp(tilemap, 2,12,0,1,4,0);
		SetTileProp(tilemap, 2,13,0,1,4,0);
		SetTileProp(tilemap, 2,14,0,1,4,0);
		SetTileProp(tilemap, 2,15,0,1,4,0);
		SetTileProp(tilemap, 2,16,0,1,4,0);
		SetTileProp(tilemap, 2,17,0,1,4,0);
		SetTileProp(tilemap, 2,18,0,1,4,0);
		SetTileProp(tilemap, 2,19,0,1,4,0);
		SetTileProp(tilemap, 2,20,0,1,4,0);
		SetTileProp(tilemap, 2,21,0,1,4,0);
		SetTileProp(tilemap, 2,22,0,1,4,0);
		SetTileProp(tilemap, 2,23,0,1,4,0);
		SetTileProp(tilemap, 2,24,0,1,4,0);
		SetTileProp(tilemap, 2,25,0,1,4,0);
		SetTileProp(tilemap, 2,26,0,1,4,0);
		SetTileProp(tilemap, 2,27,0,1,4,0);
		SetTileProp(tilemap, 2,28,0,1,4,0);
		SetTileProp(tilemap, 2,29,0,1,4,0);
		SetTileProp(tilemap, 2,30,0,1,0,0);
		SetTileProp(tilemap, 2,31,0,1,0,0);
		SetTileProp(tilemap, 2,32,0,1,0,0);
		SetTileProp(tilemap, 2,33,0,1,0,0);
		SetTileProp(tilemap, 2,34,0,1,0,0);
		SetTileProp(tilemap, 2,35,0,1,0,0);
		SetTileProp(tilemap, 2,36,0,1,0,0);
		SetTileProp(tilemap, 2,37,0,1,0,0);
		SetTileProp(tilemap, 2,38,0,1,0,0);
		SetTileProp(tilemap, 2,39,0,1,4,0);
		SetTileProp(tilemap, 2,40,0,1,4,0);
		SetTileProp(tilemap, 2,41,0,1,4,0);
		SetTileProp(tilemap, 2,42,0,1,4,0);
		SetTileProp(tilemap, 2,43,0,1,4,0);
		SetTileProp(tilemap, 2,44,0,1,4,0);
		SetTileProp(tilemap, 2,45,0,1,4,0);
		SetTileProp(tilemap, 2,46,0,1,4,0);
		SetTileProp(tilemap, 2,47,0,1,4,0);
		SetTileProp(tilemap, 2,48,0,1,4,0);
		SetTileProp(tilemap, 2,49,0,1,4,0);
		SetTileProp(tilemap, 2,50,0,1,4,0);
		SetTileProp(tilemap, 2,51,0,1,4,0);
		SetTileProp(tilemap, 2,52,0,1,4,0);
		SetTileProp(tilemap, 2,53,0,1,4,0);
		SetTileProp(tilemap, 2,54,0,1,4,0);
		SetTileProp(tilemap, 2,55,0,1,0,0);
		SetTileProp(tilemap, 2,56,0,1,0,0);
		SetTileProp(tilemap, 2,57,0,1,0,0);
		SetTileProp(tilemap, 2,58,0,1,0,0);
		SetTileProp(tilemap, 2,59,0,1,0,0);
		SetTileProp(tilemap, 2,60,0,1,0,0);
		SetTileProp(tilemap, 2,61,0,1,0,0);
		SetTileProp(tilemap, 2,62,0,1,0,0);
		SetTileProp(tilemap, 3,0,0,1,0,0);
		SetTileProp(tilemap, 3,1,0,1,0,0);
		SetTileProp(tilemap, 3,2,0,1,4,0);
		SetTileProp(tilemap, 3,3,0,1,4,0);
		SetTileProp(tilemap, 3,4,0,1,4,0);
		SetTileProp(tilemap, 3,5,0,1,4,0);
		SetTileProp(tilemap, 3,6,0,1,4,0);
		SetTileProp(tilemap, 3,7,0,1,4,0);
		SetTileProp(tilemap, 3,8,0,1,4,0);
		SetTileProp(tilemap, 3,9,0,1,4,0);
		SetTileProp(tilemap, 3,10,0,1,4,0);
		SetTileProp(tilemap, 3,11,0,1,4,0);
		SetTileProp(tilemap, 3,12,0,1,4,0);
		SetTileProp(tilemap, 3,13,0,1,4,0);
		SetTileProp(tilemap, 3,14,0,1,4,0);
		SetTileProp(tilemap, 3,15,0,1,4,0);
		SetTileProp(tilemap, 3,16,0,1,4,0);
		SetTileProp(tilemap, 3,17,0,1,4,0);
		SetTileProp(tilemap, 3,18,0,1,4,3);
		SetTileProp(tilemap, 3,19,0,1,4,0);
		SetTileProp(tilemap, 3,20,0,1,4,0);
		SetTileProp(tilemap, 3,21,0,1,4,0);
		SetTileProp(tilemap, 3,22,0,1,4,0);
		SetTileProp(tilemap, 3,23,0,1,4,0);
		SetTileProp(tilemap, 3,24,0,1,4,0);
		SetTileProp(tilemap, 3,25,0,1,4,0);
		SetTileProp(tilemap, 3,26,0,1,4,0);
		SetTileProp(tilemap, 3,27,0,1,4,0);
		SetTileProp(tilemap, 3,28,0,1,4,0);
		SetTileProp(tilemap, 3,29,0,1,4,0);
		SetTileProp(tilemap, 3,30,0,1,0,0);
		SetTileProp(tilemap, 3,31,0,1,0,0);
		SetTileProp(tilemap, 3,32,0,1,0,0);
		SetTileProp(tilemap, 3,33,0,1,0,0);
		SetTileProp(tilemap, 3,34,0,1,0,0);
		SetTileProp(tilemap, 3,35,0,1,0,0);
		SetTileProp(tilemap, 3,36,0,1,0,0);
		SetTileProp(tilemap, 3,37,0,1,0,0);
		SetTileProp(tilemap, 3,38,0,1,0,0);
		SetTileProp(tilemap, 3,39,0,1,4,0);
		SetTileProp(tilemap, 3,40,0,1,4,0);
		SetTileProp(tilemap, 3,41,0,1,4,0);
		SetTileProp(tilemap, 3,42,0,1,4,0);
		SetTileProp(tilemap, 3,43,0,1,4,0);
		SetTileProp(tilemap, 3,44,0,1,4,0);
		SetTileProp(tilemap, 3,45,0,1,4,0);
		SetTileProp(tilemap, 3,46,0,1,4,0);
		SetTileProp(tilemap, 3,47,0,1,4,0);
		SetTileProp(tilemap, 3,48,0,1,4,0);
		SetTileProp(tilemap, 3,49,0,1,4,0);
		SetTileProp(tilemap, 3,50,0,1,4,0);
		SetTileProp(tilemap, 3,51,0,1,4,0);
		SetTileProp(tilemap, 3,52,0,1,4,0);
		SetTileProp(tilemap, 3,53,0,1,4,0);
		SetTileProp(tilemap, 3,54,0,1,4,0);
		SetTileProp(tilemap, 3,55,0,1,0,0);
		SetTileProp(tilemap, 3,56,0,1,0,0);
		SetTileProp(tilemap, 3,57,0,1,0,0);
		SetTileProp(tilemap, 3,58,0,1,0,0);
		SetTileProp(tilemap, 3,59,0,1,0,0);
		SetTileProp(tilemap, 3,60,0,1,0,0);
		SetTileProp(tilemap, 3,61,0,1,0,0);
		SetTileProp(tilemap, 3,62,0,1,0,0);
		SetTileProp(tilemap, 4,0,0,1,0,0);
		SetTileProp(tilemap, 4,1,0,1,0,0);
		SetTileProp(tilemap, 4,2,0,1,4,0);
		SetTileProp(tilemap, 4,3,0,1,4,0);
		SetTileProp(tilemap, 4,4,1,1,0,0);
		SetTileProp(tilemap, 4,5,0,1,4,0);
		SetTileProp(tilemap, 4,6,0,1,4,0);
		SetTileProp(tilemap, 4,7,0,1,4,0);
		SetTileProp(tilemap, 4,8,0,1,4,0);
		SetTileProp(tilemap, 4,9,0,1,4,0);
		SetTileProp(tilemap, 4,10,0,1,4,0);
		SetTileProp(tilemap, 4,11,0,1,4,0);
		SetTileProp(tilemap, 4,12,0,1,4,0);
		SetTileProp(tilemap, 4,13,0,1,4,0);
		SetTileProp(tilemap, 4,14,0,1,4,0);
		SetTileProp(tilemap, 4,15,0,1,4,0);
		SetTileProp(tilemap, 4,16,0,1,4,0);
		SetTileProp(tilemap, 4,17,0,1,4,0);
		SetTileProp(tilemap, 4,18,0,1,4,0);
		SetTileProp(tilemap, 4,19,0,1,4,0);
		SetTileProp(tilemap, 4,20,0,1,4,0);
		SetTileProp(tilemap, 4,21,0,1,0,8);
		SetTileProp(tilemap, 4,22,0,1,0,8);
		SetTileProp(tilemap, 4,23,0,1,4,0);
		SetTileProp(tilemap, 4,24,0,1,4,8);
		SetTileProp(tilemap, 4,25,0,1,4,0);
		SetTileProp(tilemap, 4,26,0,1,4,0);
		SetTileProp(tilemap, 4,27,0,1,4,0);
		SetTileProp(tilemap, 4,28,0,1,4,0);
		SetTileProp(tilemap, 4,29,0,1,4,8);
		SetTileProp(tilemap, 4,30,0,1,0,0);
		SetTileProp(tilemap, 4,31,0,1,0,0);
		SetTileProp(tilemap, 4,32,0,1,0,0);
		SetTileProp(tilemap, 4,33,0,1,0,0);
		SetTileProp(tilemap, 4,34,0,1,0,0);
		SetTileProp(tilemap, 4,35,0,1,0,0);
		SetTileProp(tilemap, 4,36,0,1,0,0);
		SetTileProp(tilemap, 4,37,0,1,0,0);
		SetTileProp(tilemap, 4,38,0,1,0,0);
		SetTileProp(tilemap, 4,39,0,1,4,0);
		SetTileProp(tilemap, 4,40,0,1,4,0);
		SetTileProp(tilemap, 4,41,0,1,4,0);
		SetTileProp(tilemap, 4,42,0,1,4,0);
		SetTileProp(tilemap, 4,43,0,1,4,0);
		SetTileProp(tilemap, 4,44,0,1,4,0);
		SetTileProp(tilemap, 4,45,0,1,4,0);
		SetTileProp(tilemap, 4,46,0,1,4,0);
		SetTileProp(tilemap, 4,47,0,1,4,0);
		SetTileProp(tilemap, 4,48,0,1,4,0);
		SetTileProp(tilemap, 4,49,0,1,4,0);
		SetTileProp(tilemap, 4,50,0,1,4,0);
		SetTileProp(tilemap, 4,51,0,1,4,0);
		SetTileProp(tilemap, 4,52,0,1,4,0);
		SetTileProp(tilemap, 4,53,0,1,4,0);
		SetTileProp(tilemap, 4,54,0,1,4,0);
		SetTileProp(tilemap, 4,55,0,1,0,0);
		SetTileProp(tilemap, 4,56,0,1,0,0);
		SetTileProp(tilemap, 4,57,0,1,0,0);
		SetTileProp(tilemap, 4,58,0,1,0,0);
		SetTileProp(tilemap, 4,59,0,1,0,0);
		SetTileProp(tilemap, 4,60,0,1,0,0);
		SetTileProp(tilemap, 4,61,0,1,0,0);
		SetTileProp(tilemap, 4,62,0,1,0,0);
		SetTileProp(tilemap, 5,0,0,1,0,0);
		SetTileProp(tilemap, 5,1,0,1,0,0);
		SetTileProp(tilemap, 5,2,0,1,4,0);
		SetTileProp(tilemap, 5,3,0,1,4,0);
		SetTileProp(tilemap, 5,4,0,1,4,0);
		SetTileProp(tilemap, 5,5,0,1,4,0);
		SetTileProp(tilemap, 5,6,0,1,4,0);
		SetTileProp(tilemap, 5,7,0,1,4,0);
		SetTileProp(tilemap, 5,8,0,1,4,0);
		SetTileProp(tilemap, 5,9,0,1,4,0);
		SetTileProp(tilemap, 5,10,0,1,4,0);
		SetTileProp(tilemap, 5,11,0,1,4,0);
		SetTileProp(tilemap, 5,12,0,1,4,0);
		SetTileProp(tilemap, 5,13,0,1,4,0);
		SetTileProp(tilemap, 5,14,0,1,4,0);
		SetTileProp(tilemap, 5,15,0,1,4,0);
		SetTileProp(tilemap, 5,16,0,1,4,0);
		SetTileProp(tilemap, 5,17,0,1,4,0);
		SetTileProp(tilemap, 5,18,0,1,4,0);
		SetTileProp(tilemap, 5,19,0,1,4,0);
		SetTileProp(tilemap, 5,20,0,1,4,0);
		SetTileProp(tilemap, 5,21,0,1,4,0);
		SetTileProp(tilemap, 5,22,0,1,0,8);
		SetTileProp(tilemap, 5,23,0,1,4,8);
		SetTileProp(tilemap, 5,24,0,1,4,8);
		SetTileProp(tilemap, 5,25,0,1,4,8);
		SetTileProp(tilemap, 5,26,0,1,0,8);
		SetTileProp(tilemap, 5,27,0,1,4,0);
		SetTileProp(tilemap, 5,28,0,1,4,0);
		SetTileProp(tilemap, 5,29,0,1,4,8);
		SetTileProp(tilemap, 5,30,0,1,0,0);
		SetTileProp(tilemap, 5,31,0,1,0,0);
		SetTileProp(tilemap, 5,32,0,1,0,0);
		SetTileProp(tilemap, 5,33,0,1,0,0);
		SetTileProp(tilemap, 5,34,0,1,0,0);
		SetTileProp(tilemap, 5,35,0,1,0,0);
		SetTileProp(tilemap, 5,36,0,1,0,0);
		SetTileProp(tilemap, 5,37,0,1,0,0);
		SetTileProp(tilemap, 5,38,0,1,4,0);
		SetTileProp(tilemap, 5,39,0,1,4,0);
		SetTileProp(tilemap, 5,40,0,1,4,0);
		SetTileProp(tilemap, 5,41,0,1,4,0);
		SetTileProp(tilemap, 5,42,0,1,4,0);
		SetTileProp(tilemap, 5,43,0,1,4,0);
		SetTileProp(tilemap, 5,44,0,1,4,0);
		SetTileProp(tilemap, 5,45,0,1,4,0);
		SetTileProp(tilemap, 5,46,0,1,4,0);
		SetTileProp(tilemap, 5,47,0,1,4,0);
		SetTileProp(tilemap, 5,48,0,1,4,0);
		SetTileProp(tilemap, 5,49,0,1,4,0);
		SetTileProp(tilemap, 5,50,0,1,4,0);
		SetTileProp(tilemap, 5,51,0,1,4,0);
		SetTileProp(tilemap, 5,52,0,1,4,0);
		SetTileProp(tilemap, 5,53,0,1,4,0);
		SetTileProp(tilemap, 5,54,0,1,4,0);
		SetTileProp(tilemap, 5,55,0,1,0,0);
		SetTileProp(tilemap, 5,56,0,1,0,0);
		SetTileProp(tilemap, 5,57,0,1,0,0);
		SetTileProp(tilemap, 5,58,0,1,0,0);
		SetTileProp(tilemap, 5,59,0,1,0,0);
		SetTileProp(tilemap, 5,60,0,1,0,0);
		SetTileProp(tilemap, 5,61,0,1,0,0);
		SetTileProp(tilemap, 5,62,0,1,0,0);
		SetTileProp(tilemap, 6,0,0,1,0,0);
		SetTileProp(tilemap, 6,1,0,1,0,0);
		SetTileProp(tilemap, 6,2,0,1,4,0);
		SetTileProp(tilemap, 6,3,0,1,4,0);
		SetTileProp(tilemap, 6,4,0,1,4,0);
		SetTileProp(tilemap, 6,5,0,1,4,0);
		SetTileProp(tilemap, 6,6,0,1,4,0);
		SetTileProp(tilemap, 6,7,0,1,4,0);
		SetTileProp(tilemap, 6,8,0,1,4,0);
		SetTileProp(tilemap, 6,9,0,1,4,0);
		SetTileProp(tilemap, 6,10,0,1,4,0);
		SetTileProp(tilemap, 6,11,0,1,4,0);
		SetTileProp(tilemap, 6,12,0,1,4,0);
		SetTileProp(tilemap, 6,13,0,1,4,0);
		SetTileProp(tilemap, 6,14,0,1,4,0);
		SetTileProp(tilemap, 6,15,0,1,4,0);
		SetTileProp(tilemap, 6,16,0,1,4,0);
		SetTileProp(tilemap, 6,17,0,1,4,0);
		SetTileProp(tilemap, 6,18,0,1,4,0);
		SetTileProp(tilemap, 6,19,0,1,4,0);
		SetTileProp(tilemap, 6,20,0,1,4,0);
		SetTileProp(tilemap, 6,21,0,1,4,0);
		SetTileProp(tilemap, 6,22,0,1,8,8);
		SetTileProp(tilemap, 6,23,0,1,8,8);
		SetTileProp(tilemap, 6,24,9,1,0,24);
		SetTileProp(tilemap, 6,25,0,1,8,8);
		SetTileProp(tilemap, 6,26,0,1,8,8);
		SetTileProp(tilemap, 6,27,0,1,4,0);
		SetTileProp(tilemap, 6,28,0,1,4,0);
		SetTileProp(tilemap, 6,29,9,1,4,20);
		SetTileProp(tilemap, 6,30,0,1,0,0);
		SetTileProp(tilemap, 6,31,0,1,0,0);
		SetTileProp(tilemap, 6,32,0,1,0,0);
		SetTileProp(tilemap, 6,33,0,1,0,0);
		SetTileProp(tilemap, 6,34,0,1,0,0);
		SetTileProp(tilemap, 6,35,0,1,0,0);
		SetTileProp(tilemap, 6,36,0,1,0,0);
		SetTileProp(tilemap, 6,37,0,1,0,0);
		SetTileProp(tilemap, 6,38,0,1,4,0);
		SetTileProp(tilemap, 6,39,0,1,4,0);
		SetTileProp(tilemap, 6,40,0,1,4,0);
		SetTileProp(tilemap, 6,41,0,1,4,0);
		SetTileProp(tilemap, 6,42,0,1,4,0);
		SetTileProp(tilemap, 6,43,0,1,4,0);
		SetTileProp(tilemap, 6,44,0,1,4,0);
		SetTileProp(tilemap, 6,45,0,1,4,0);
		SetTileProp(tilemap, 6,46,0,1,4,0);
		SetTileProp(tilemap, 6,47,0,1,4,0);
		SetTileProp(tilemap, 6,48,0,1,4,0);
		SetTileProp(tilemap, 6,49,0,1,4,0);
		SetTileProp(tilemap, 6,50,0,1,4,0);
		SetTileProp(tilemap, 6,51,0,1,4,0);
		SetTileProp(tilemap, 6,52,0,1,4,0);
		SetTileProp(tilemap, 6,53,0,1,4,0);
		SetTileProp(tilemap, 6,54,0,1,4,0);
		SetTileProp(tilemap, 6,55,0,1,0,0);
		SetTileProp(tilemap, 6,56,0,1,0,0);
		SetTileProp(tilemap, 6,57,0,1,0,0);
		SetTileProp(tilemap, 6,58,0,1,0,0);
		SetTileProp(tilemap, 6,59,0,1,0,0);
		SetTileProp(tilemap, 6,60,0,1,0,0);
		SetTileProp(tilemap, 6,61,0,1,0,0);
		SetTileProp(tilemap, 6,62,0,1,0,0);
		SetTileProp(tilemap, 7,0,0,1,0,0);
		SetTileProp(tilemap, 7,1,0,1,0,0);
		SetTileProp(tilemap, 7,2,0,1,4,0);
		SetTileProp(tilemap, 7,3,0,1,4,0);
		SetTileProp(tilemap, 7,4,0,1,4,0);
		SetTileProp(tilemap, 7,5,0,1,4,0);
		SetTileProp(tilemap, 7,6,0,1,4,0);
		SetTileProp(tilemap, 7,7,0,1,4,0);
		SetTileProp(tilemap, 7,8,0,1,4,0);
		SetTileProp(tilemap, 7,9,0,1,4,0);
		SetTileProp(tilemap, 7,10,0,1,4,0);
		SetTileProp(tilemap, 7,11,0,1,4,0);
		SetTileProp(tilemap, 7,12,0,1,4,0);
		SetTileProp(tilemap, 7,13,0,1,4,0);
		SetTileProp(tilemap, 7,14,0,1,4,0);
		SetTileProp(tilemap, 7,15,0,1,4,0);
		SetTileProp(tilemap, 7,16,0,1,4,0);
		SetTileProp(tilemap, 7,17,0,1,4,0);
		SetTileProp(tilemap, 7,18,0,1,4,0);
		SetTileProp(tilemap, 7,19,0,1,4,0);
		SetTileProp(tilemap, 7,20,0,1,4,0);
		SetTileProp(tilemap, 7,21,0,1,4,0);
		SetTileProp(tilemap, 7,22,4,1,0,24);
		SetTileProp(tilemap, 7,23,1,1,0,24);
		SetTileProp(tilemap, 7,24,1,1,0,24);
		SetTileProp(tilemap, 7,25,1,1,0,24);
		SetTileProp(tilemap, 7,26,2,1,0,24);
		SetTileProp(tilemap, 7,27,0,1,4,0);
		SetTileProp(tilemap, 7,28,0,1,1,20);
		SetTileProp(tilemap, 7,29,1,1,3,20);
		SetTileProp(tilemap, 7,30,2,1,5,16);
		SetTileProp(tilemap, 7,31,0,1,0,16);
		SetTileProp(tilemap, 7,32,0,1,0,16);
		SetTileProp(tilemap, 7,33,0,1,0,16);
		SetTileProp(tilemap, 7,34,0,1,0,16);
		SetTileProp(tilemap, 7,35,0,1,0,0);
		SetTileProp(tilemap, 7,36,0,1,0,0);
		SetTileProp(tilemap, 7,37,0,1,0,0);
		SetTileProp(tilemap, 7,38,0,1,4,0);
		SetTileProp(tilemap, 7,39,0,1,10,0);
		SetTileProp(tilemap, 7,40,0,1,4,0);
		SetTileProp(tilemap, 7,41,0,1,4,0);
		SetTileProp(tilemap, 7,42,0,1,4,0);
		SetTileProp(tilemap, 7,43,0,1,4,0);
		SetTileProp(tilemap, 7,44,0,1,4,0);
		SetTileProp(tilemap, 7,45,0,1,4,0);
		SetTileProp(tilemap, 7,46,0,1,4,0);
		SetTileProp(tilemap, 7,47,0,1,4,0);
		SetTileProp(tilemap, 7,48,0,1,4,0);
		SetTileProp(tilemap, 7,49,0,1,4,0);
		SetTileProp(tilemap, 7,50,0,1,4,0);
		SetTileProp(tilemap, 7,51,0,1,4,0);
		SetTileProp(tilemap, 7,52,0,1,4,0);
		SetTileProp(tilemap, 7,53,0,1,4,0);
		SetTileProp(tilemap, 7,54,0,1,4,0);
		SetTileProp(tilemap, 7,55,0,1,0,0);
		SetTileProp(tilemap, 7,56,0,1,0,0);
		SetTileProp(tilemap, 7,57,0,1,0,0);
		SetTileProp(tilemap, 7,58,0,1,0,0);
		SetTileProp(tilemap, 7,59,0,1,0,0);
		SetTileProp(tilemap, 7,60,0,1,0,0);
		SetTileProp(tilemap, 7,61,0,1,0,0);
		SetTileProp(tilemap, 7,62,0,1,0,0);
		SetTileProp(tilemap, 8,0,0,1,0,0);
		SetTileProp(tilemap, 8,1,0,1,0,0);
		SetTileProp(tilemap, 8,2,0,1,4,0);
		SetTileProp(tilemap, 8,3,0,1,4,0);
		SetTileProp(tilemap, 8,4,0,1,4,0);
		SetTileProp(tilemap, 8,5,0,1,4,0);
		SetTileProp(tilemap, 8,6,0,1,4,0);
		SetTileProp(tilemap, 8,7,0,1,4,16);
		SetTileProp(tilemap, 8,8,0,1,4,16);
		SetTileProp(tilemap, 8,9,0,1,4,16);
		SetTileProp(tilemap, 8,10,0,1,4,16);
		SetTileProp(tilemap, 8,11,0,1,4,16);
		SetTileProp(tilemap, 8,12,0,1,4,16);
		SetTileProp(tilemap, 8,13,0,1,4,16);
		SetTileProp(tilemap, 8,14,0,1,4,16);
		SetTileProp(tilemap, 8,15,0,1,4,16);
		SetTileProp(tilemap, 8,16,0,1,4,16);
		SetTileProp(tilemap, 8,17,0,1,4,16);
		SetTileProp(tilemap, 8,18,0,1,4,16);
		SetTileProp(tilemap, 8,19,0,1,4,16);
		SetTileProp(tilemap, 8,20,0,1,4,16);
		SetTileProp(tilemap, 8,21,4,1,0,24);
		SetTileProp(tilemap, 8,22,1,1,0,24);
		SetTileProp(tilemap, 8,23,3,1,0,24);
		SetTileProp(tilemap, 8,24,0,1,4,16);
		SetTileProp(tilemap, 8,25,5,1,0,24);
		SetTileProp(tilemap, 8,26,1,1,0,24);
		SetTileProp(tilemap, 8,27,0,1,1,20);
		SetTileProp(tilemap, 8,28,4,1,0,20);
		SetTileProp(tilemap, 8,29,6,1,0,20);
		SetTileProp(tilemap, 8,30,6,1,2,16);
		SetTileProp(tilemap, 8,31,6,1,3,16);
		SetTileProp(tilemap, 8,32,6,1,4,16);
		SetTileProp(tilemap, 8,33,6,1,5,16);
		SetTileProp(tilemap, 8,34,6,1,6,16);
		SetTileProp(tilemap, 8,35,6,1,7,16);
		SetTileProp(tilemap, 8,36,1,1,8,16);
		SetTileProp(tilemap, 8,37,1,1,8,16);
		SetTileProp(tilemap, 8,38,2,1,8,16);
		SetTileProp(tilemap, 8,39,0,1,8,16);
		SetTileProp(tilemap, 8,40,0,1,10,16);
		SetTileProp(tilemap, 8,41,0,1,10,16);
		SetTileProp(tilemap, 8,42,0,1,10,16);
		SetTileProp(tilemap, 8,43,0,1,10,16);
		SetTileProp(tilemap, 8,44,0,1,10,16);
		SetTileProp(tilemap, 8,45,0,1,4,16);
		SetTileProp(tilemap, 8,46,0,1,4,0);
		SetTileProp(tilemap, 8,47,0,1,4,0);
		SetTileProp(tilemap, 8,48,0,1,4,0);
		SetTileProp(tilemap, 8,49,0,1,4,0);
		SetTileProp(tilemap, 8,50,0,1,4,0);
		SetTileProp(tilemap, 8,51,0,1,4,0);
		SetTileProp(tilemap, 8,52,0,1,4,0);
		SetTileProp(tilemap, 8,53,0,1,4,0);
		SetTileProp(tilemap, 8,54,0,1,4,16);
		SetTileProp(tilemap, 8,55,0,1,8,16);
		SetTileProp(tilemap, 8,56,0,1,8,16);
		SetTileProp(tilemap, 8,57,0,1,0,0);
		SetTileProp(tilemap, 8,58,0,1,0,0);
		SetTileProp(tilemap, 8,59,0,1,0,0);
		SetTileProp(tilemap, 8,60,0,1,0,0);
		SetTileProp(tilemap, 8,61,0,1,0,0);
		SetTileProp(tilemap, 8,62,0,1,0,0);
		SetTileProp(tilemap, 9,0,0,1,0,0);
		SetTileProp(tilemap, 9,1,0,1,0,0);
		SetTileProp(tilemap, 9,2,0,1,4,0);
		SetTileProp(tilemap, 9,3,0,1,4,0);
		SetTileProp(tilemap, 9,4,0,1,4,0);
		SetTileProp(tilemap, 9,5,0,1,4,0);
		SetTileProp(tilemap, 9,6,0,1,4,0);
		SetTileProp(tilemap, 9,7,0,1,4,16);
		SetTileProp(tilemap, 9,8,0,1,2,16);
		SetTileProp(tilemap, 9,9,0,1,4,16);
		SetTileProp(tilemap, 9,10,0,1,4,16);
		SetTileProp(tilemap, 9,11,0,1,4,16);
		SetTileProp(tilemap, 9,12,0,1,4,16);
		SetTileProp(tilemap, 9,13,0,1,4,16);
		SetTileProp(tilemap, 9,14,0,1,4,16);
		SetTileProp(tilemap, 9,15,0,1,4,16);
		SetTileProp(tilemap, 9,16,0,1,4,16);
		SetTileProp(tilemap, 9,17,0,1,4,16);
		SetTileProp(tilemap, 9,18,0,1,0,24);
		SetTileProp(tilemap, 9,19,4,1,0,24);
		SetTileProp(tilemap, 9,20,1,1,0,24);
		SetTileProp(tilemap, 9,21,1,1,0,24);
		SetTileProp(tilemap, 9,22,1,1,0,24);
		SetTileProp(tilemap, 9,23,1,1,0,24);
		SetTileProp(tilemap, 9,24,1,1,0,24);
		SetTileProp(tilemap, 9,25,1,1,0,24);
		SetTileProp(tilemap, 9,26,1,1,0,24);
		SetTileProp(tilemap, 9,27,1,1,0,24);
		SetTileProp(tilemap, 9,28,3,1,0,20);
		SetTileProp(tilemap, 9,29,0,1,4,20);
		SetTileProp(tilemap, 9,30,0,1,4,16);
		SetTileProp(tilemap, 9,31,0,1,4,16);
		SetTileProp(tilemap, 9,32,0,1,4,16);
		SetTileProp(tilemap, 9,33,0,1,4,16);
		SetTileProp(tilemap, 9,34,0,1,4,16);
		SetTileProp(tilemap, 9,35,0,1,4,24);
		SetTileProp(tilemap, 9,36,0,1,4,24);
		SetTileProp(tilemap, 9,37,1,1,8,16);
		SetTileProp(tilemap, 9,38,1,1,8,16);
		SetTileProp(tilemap, 9,39,2,1,8,16);
		SetTileProp(tilemap, 9,40,0,1,8,16);
		SetTileProp(tilemap, 9,41,0,1,8,16);
		SetTileProp(tilemap, 9,42,0,1,8,16);
		SetTileProp(tilemap, 9,43,0,1,8,16);
		SetTileProp(tilemap, 9,44,0,1,8,16);
		SetTileProp(tilemap, 9,45,0,1,4,16);
		SetTileProp(tilemap, 9,46,0,1,4,0);
		SetTileProp(tilemap, 9,47,0,1,4,0);
		SetTileProp(tilemap, 9,48,0,1,4,0);
		SetTileProp(tilemap, 9,49,0,1,4,0);
		SetTileProp(tilemap, 9,50,0,1,4,0);
		SetTileProp(tilemap, 9,51,0,1,4,0);
		SetTileProp(tilemap, 9,52,0,1,4,0);
		SetTileProp(tilemap, 9,53,0,1,4,0);
		SetTileProp(tilemap, 9,54,0,1,4,16);
		SetTileProp(tilemap, 9,55,0,1,8,16);
		SetTileProp(tilemap, 9,56,0,1,8,16);
		SetTileProp(tilemap, 9,57,0,1,0,0);
		SetTileProp(tilemap, 9,58,0,1,0,0);
		SetTileProp(tilemap, 9,59,0,1,0,0);
		SetTileProp(tilemap, 9,60,0,1,0,0);
		SetTileProp(tilemap, 9,61,0,1,0,0);
		SetTileProp(tilemap, 9,62,0,1,0,0);
		SetTileProp(tilemap, 10,0,0,1,0,0);
		SetTileProp(tilemap, 10,1,0,1,0,0);
		SetTileProp(tilemap, 10,2,0,1,4,16);
		SetTileProp(tilemap, 10,3,0,1,4,16);
		SetTileProp(tilemap, 10,4,0,1,4,16);
		SetTileProp(tilemap, 10,5,0,1,4,16);
		SetTileProp(tilemap, 10,6,0,1,4,16);
		SetTileProp(tilemap, 10,7,0,1,4,16);
		SetTileProp(tilemap, 10,8,0,1,4,16);
		SetTileProp(tilemap, 10,9,0,1,4,16);
		SetTileProp(tilemap, 10,10,0,1,4,16);
		SetTileProp(tilemap, 10,11,0,1,4,16);
		SetTileProp(tilemap, 10,12,0,1,4,16);
		SetTileProp(tilemap, 10,13,0,1,4,16);
		SetTileProp(tilemap, 10,14,0,1,4,16);
		SetTileProp(tilemap, 10,15,0,1,4,16);
		SetTileProp(tilemap, 10,16,0,1,4,16);
		SetTileProp(tilemap, 10,17,0,1,0,24);
		SetTileProp(tilemap, 10,18,4,1,0,24);
		SetTileProp(tilemap, 10,19,3,1,0,24);
		SetTileProp(tilemap, 10,20,0,1,12,8);
		SetTileProp(tilemap, 10,21,1,1,8,16);
		SetTileProp(tilemap, 10,22,1,1,8,8);
		SetTileProp(tilemap, 10,23,1,1,8,16);
		SetTileProp(tilemap, 10,24,0,1,12,8);
		SetTileProp(tilemap, 10,25,9,1,15,12);
		SetTileProp(tilemap, 10,26,1,1,15,12);
		SetTileProp(tilemap, 10,27,9,1,15,12);
		SetTileProp(tilemap, 10,28,0,1,8,16);
		SetTileProp(tilemap, 10,29,1,1,8,16);
		SetTileProp(tilemap, 10,30,1,1,8,16);
		SetTileProp(tilemap, 10,31,1,1,8,16);
		SetTileProp(tilemap, 10,32,1,1,8,16);
		SetTileProp(tilemap, 10,33,0,1,12,8);
		SetTileProp(tilemap, 10,34,8,1,0,24);
		SetTileProp(tilemap, 10,35,8,1,0,24);
		SetTileProp(tilemap, 10,36,0,1,8,24);
		SetTileProp(tilemap, 10,37,8,1,0,24);
		SetTileProp(tilemap, 10,38,8,1,0,24);
		SetTileProp(tilemap, 10,39,5,1,8,16);
		SetTileProp(tilemap, 10,40,2,1,8,16);
		SetTileProp(tilemap, 10,41,0,1,8,16);
		SetTileProp(tilemap, 10,42,0,1,8,16);
		SetTileProp(tilemap, 10,43,0,1,8,16);
		SetTileProp(tilemap, 10,44,0,1,8,16);
		SetTileProp(tilemap, 10,45,0,1,4,16);
		SetTileProp(tilemap, 10,46,0,1,4,0);
		SetTileProp(tilemap, 10,47,0,1,4,0);
		SetTileProp(tilemap, 10,48,0,1,4,0);
		SetTileProp(tilemap, 10,49,0,1,4,0);
		SetTileProp(tilemap, 10,50,0,1,4,0);
		SetTileProp(tilemap, 10,51,0,1,4,0);
		SetTileProp(tilemap, 10,52,0,1,4,0);
		SetTileProp(tilemap, 10,53,0,1,4,0);
		SetTileProp(tilemap, 10,54,0,1,4,16);
		SetTileProp(tilemap, 10,55,0,1,8,16);
		SetTileProp(tilemap, 10,56,0,1,8,16);
		SetTileProp(tilemap, 10,57,0,1,0,0);
		SetTileProp(tilemap, 10,58,0,1,0,0);
		SetTileProp(tilemap, 10,59,0,1,0,0);
		SetTileProp(tilemap, 10,60,0,1,0,0);
		SetTileProp(tilemap, 10,61,0,1,0,0);
		SetTileProp(tilemap, 10,62,0,1,0,0);
		SetTileProp(tilemap, 11,0,0,1,0,0);
		SetTileProp(tilemap, 11,1,0,1,0,0);
		SetTileProp(tilemap, 11,2,0,1,4,16);
		SetTileProp(tilemap, 11,3,0,1,4,16);
		SetTileProp(tilemap, 11,4,0,1,4,16);
		SetTileProp(tilemap, 11,5,0,1,4,16);
		SetTileProp(tilemap, 11,6,0,1,4,16);
		SetTileProp(tilemap, 11,7,0,1,4,16);
		SetTileProp(tilemap, 11,8,0,1,4,16);
		SetTileProp(tilemap, 11,9,0,1,4,16);
		SetTileProp(tilemap, 11,10,0,1,4,16);
		SetTileProp(tilemap, 11,11,0,1,4,16);
		SetTileProp(tilemap, 11,12,0,1,4,16);
		SetTileProp(tilemap, 11,13,0,1,4,16);
		SetTileProp(tilemap, 11,14,0,1,4,16);
		SetTileProp(tilemap, 11,15,0,1,4,16);
		SetTileProp(tilemap, 11,16,0,1,0,24);
		SetTileProp(tilemap, 11,17,4,1,0,24);
		SetTileProp(tilemap, 11,18,3,1,0,24);
		SetTileProp(tilemap, 11,19,0,1,0,24);
		SetTileProp(tilemap, 11,20,0,1,12,8);
		SetTileProp(tilemap, 11,21,1,1,8,16);
		SetTileProp(tilemap, 11,22,1,1,8,8);
		SetTileProp(tilemap, 11,23,1,1,8,16);
		SetTileProp(tilemap, 11,24,0,1,12,8);
		SetTileProp(tilemap, 11,25,1,1,12,12);
		SetTileProp(tilemap, 11,26,1,1,15,12);
		SetTileProp(tilemap, 11,27,1,1,12,12);
		SetTileProp(tilemap, 11,28,0,1,8,16);
		SetTileProp(tilemap, 11,29,1,1,8,16);
		SetTileProp(tilemap, 11,30,0,1,8,16);
		SetTileProp(tilemap, 11,31,0,1,8,16);
		SetTileProp(tilemap, 11,32,1,1,8,16);
		SetTileProp(tilemap, 11,33,0,1,12,8);
		SetTileProp(tilemap, 11,34,8,1,8,16);
		SetTileProp(tilemap, 11,35,8,1,0,16);
		SetTileProp(tilemap, 11,36,8,1,0,16);
		SetTileProp(tilemap, 11,37,8,1,0,16);
		SetTileProp(tilemap, 11,38,8,1,0,16);
		SetTileProp(tilemap, 11,39,0,1,8,16);
		SetTileProp(tilemap, 11,40,1,1,8,16);
		SetTileProp(tilemap, 11,41,0,1,8,16);
		SetTileProp(tilemap, 11,42,0,1,8,16);
		SetTileProp(tilemap, 11,43,0,1,8,16);
		SetTileProp(tilemap, 11,44,0,1,8,16);
		SetTileProp(tilemap, 11,45,0,1,4,16);
		SetTileProp(tilemap, 11,46,0,1,4,0);
		SetTileProp(tilemap, 11,47,0,1,4,0);
		SetTileProp(tilemap, 11,48,0,1,4,0);
		SetTileProp(tilemap, 11,49,0,1,4,0);
		SetTileProp(tilemap, 11,50,0,1,4,0);
		SetTileProp(tilemap, 11,51,0,1,4,0);
		SetTileProp(tilemap, 11,52,0,1,4,0);
		SetTileProp(tilemap, 11,53,0,1,4,0);
		SetTileProp(tilemap, 11,54,0,1,4,16);
		SetTileProp(tilemap, 11,55,0,1,8,16);
		SetTileProp(tilemap, 11,56,0,1,8,16);
		SetTileProp(tilemap, 11,57,0,1,0,0);
		SetTileProp(tilemap, 11,58,0,1,0,0);
		SetTileProp(tilemap, 11,59,0,1,0,0);
		SetTileProp(tilemap, 11,60,0,1,0,0);
		SetTileProp(tilemap, 11,61,0,1,0,0);
		SetTileProp(tilemap, 11,62,0,1,0,0);
		SetTileProp(tilemap, 12,0,0,1,0,0);
		SetTileProp(tilemap, 12,1,0,1,0,0);
		SetTileProp(tilemap, 12,2,0,1,4,16);
		SetTileProp(tilemap, 12,3,0,1,4,16);
		SetTileProp(tilemap, 12,4,0,1,4,16);
		SetTileProp(tilemap, 12,5,0,1,4,16);
		SetTileProp(tilemap, 12,6,0,1,4,16);
		SetTileProp(tilemap, 12,7,0,1,4,16);
		SetTileProp(tilemap, 12,8,0,1,4,16);
		SetTileProp(tilemap, 12,9,0,1,4,16);
		SetTileProp(tilemap, 12,10,0,1,4,16);
		SetTileProp(tilemap, 12,11,0,1,4,16);
		SetTileProp(tilemap, 12,12,0,1,4,16);
		SetTileProp(tilemap, 12,13,0,1,4,16);
		SetTileProp(tilemap, 12,14,0,1,4,16);
		SetTileProp(tilemap, 12,15,0,1,4,16);
		SetTileProp(tilemap, 12,16,4,1,0,24);
		SetTileProp(tilemap, 12,17,3,1,0,24);
		SetTileProp(tilemap, 12,18,4,1,12,8);
		SetTileProp(tilemap, 12,19,1,1,12,8);
		SetTileProp(tilemap, 12,20,0,1,12,8);
		SetTileProp(tilemap, 12,21,1,1,8,16);
		SetTileProp(tilemap, 12,22,1,1,8,8);
		SetTileProp(tilemap, 12,23,1,1,8,16);
		SetTileProp(tilemap, 12,24,0,1,12,8);
		SetTileProp(tilemap, 12,25,1,1,12,12);
		SetTileProp(tilemap, 12,26,1,1,12,12);
		SetTileProp(tilemap, 12,27,1,1,12,12);
		SetTileProp(tilemap, 12,28,0,1,8,16);
		SetTileProp(tilemap, 12,29,1,1,8,16);
		SetTileProp(tilemap, 12,30,1,1,8,16);
		SetTileProp(tilemap, 12,31,1,1,8,16);
		SetTileProp(tilemap, 12,32,1,1,8,16);
		SetTileProp(tilemap, 12,33,1,1,8,16);
		SetTileProp(tilemap, 12,34,7,1,0,16);
		SetTileProp(tilemap, 12,35,1,1,0,8);
		SetTileProp(tilemap, 12,36,1,1,0,8);
		SetTileProp(tilemap, 12,37,1,1,0,16);
		SetTileProp(tilemap, 12,38,0,1,8,16);
		SetTileProp(tilemap, 12,39,0,1,8,16);
		SetTileProp(tilemap, 12,40,5,1,8,16);
		SetTileProp(tilemap, 12,41,1,1,8,16);
		SetTileProp(tilemap, 12,42,6,1,8,12);
		SetTileProp(tilemap, 12,43,2,1,12,12);
		SetTileProp(tilemap, 12,44,0,1,8,16);
		SetTileProp(tilemap, 12,45,0,1,4,16);
		SetTileProp(tilemap, 12,46,0,1,4,16);
		SetTileProp(tilemap, 12,47,0,1,4,16);
		SetTileProp(tilemap, 12,48,0,1,4,16);
		SetTileProp(tilemap, 12,49,0,1,4,16);
		SetTileProp(tilemap, 12,50,0,1,4,16);
		SetTileProp(tilemap, 12,51,0,1,4,16);
		SetTileProp(tilemap, 12,52,0,1,4,16);
		SetTileProp(tilemap, 12,53,0,1,4,16);
		SetTileProp(tilemap, 12,54,0,1,4,16);
		SetTileProp(tilemap, 12,55,0,1,8,16);
		SetTileProp(tilemap, 12,56,0,1,8,16);
		SetTileProp(tilemap, 12,57,0,1,0,0);
		SetTileProp(tilemap, 12,58,0,1,0,0);
		SetTileProp(tilemap, 12,59,0,1,0,0);
		SetTileProp(tilemap, 12,60,0,1,0,0);
		SetTileProp(tilemap, 12,61,0,1,0,0);
		SetTileProp(tilemap, 12,62,0,1,0,0);
		SetTileProp(tilemap, 13,0,0,1,0,0);
		SetTileProp(tilemap, 13,1,0,1,0,0);
		SetTileProp(tilemap, 13,2,0,1,4,16);
		SetTileProp(tilemap, 13,3,0,1,4,16);
		SetTileProp(tilemap, 13,4,0,1,4,16);
		SetTileProp(tilemap, 13,5,0,1,4,16);
		SetTileProp(tilemap, 13,6,0,1,4,16);
		SetTileProp(tilemap, 13,7,0,1,4,16);
		SetTileProp(tilemap, 13,8,0,1,4,16);
		SetTileProp(tilemap, 13,9,0,1,4,16);
		SetTileProp(tilemap, 13,10,0,1,4,16);
		SetTileProp(tilemap, 13,11,0,1,4,16);
		SetTileProp(tilemap, 13,12,0,1,4,16);
		SetTileProp(tilemap, 13,13,0,1,4,16);
		SetTileProp(tilemap, 13,14,0,1,4,16);
		SetTileProp(tilemap, 13,15,0,1,4,16);
		SetTileProp(tilemap, 13,16,1,1,0,24);
		SetTileProp(tilemap, 13,17,4,1,12,8);
		SetTileProp(tilemap, 13,18,1,1,12,8);
		SetTileProp(tilemap, 13,19,1,1,12,8);
		SetTileProp(tilemap, 13,20,0,1,12,8);
		SetTileProp(tilemap, 13,21,1,1,8,16);
		SetTileProp(tilemap, 13,22,1,1,8,8);
		SetTileProp(tilemap, 13,23,1,1,8,16);
		SetTileProp(tilemap, 13,24,0,1,12,8);
		SetTileProp(tilemap, 13,25,1,1,15,12);
		SetTileProp(tilemap, 13,26,9,1,10,12);
		SetTileProp(tilemap, 13,27,6,1,13,12);
		SetTileProp(tilemap, 13,28,0,1,8,8);
		SetTileProp(tilemap, 13,29,1,1,8,16);
		SetTileProp(tilemap, 13,30,0,1,8,16);
		SetTileProp(tilemap, 13,31,0,1,8,16);
		SetTileProp(tilemap, 13,32,1,1,8,16);
		SetTileProp(tilemap, 13,33,0,1,12,8);
		SetTileProp(tilemap, 13,34,9,1,8,16);
		SetTileProp(tilemap, 13,35,9,1,0,16);
		SetTileProp(tilemap, 13,36,9,1,0,16);
		SetTileProp(tilemap, 13,37,9,1,0,16);
		SetTileProp(tilemap, 13,38,9,1,0,16);
		SetTileProp(tilemap, 13,39,0,1,8,16);
		SetTileProp(tilemap, 13,40,1,1,8,18);
		SetTileProp(tilemap, 13,41,1,1,8,18);
		SetTileProp(tilemap, 13,42,0,1,10,14);
		SetTileProp(tilemap, 13,43,5,1,12,10);
		SetTileProp(tilemap, 13,44,2,1,13,10);
		SetTileProp(tilemap, 13,45,0,1,8,16);
		SetTileProp(tilemap, 13,46,0,1,8,16);
		SetTileProp(tilemap, 13,47,0,1,8,16);
		SetTileProp(tilemap, 13,48,0,1,8,16);
		SetTileProp(tilemap, 13,49,0,1,16,8);
		SetTileProp(tilemap, 13,50,0,1,4,16);
		SetTileProp(tilemap, 13,51,0,1,4,16);
		SetTileProp(tilemap, 13,52,0,1,4,16);
		SetTileProp(tilemap, 13,53,0,1,4,16);
		SetTileProp(tilemap, 13,54,0,1,8,16);
		SetTileProp(tilemap, 13,55,0,1,8,16);
		SetTileProp(tilemap, 13,56,0,1,8,16);
		SetTileProp(tilemap, 13,57,0,1,0,0);
		SetTileProp(tilemap, 13,58,0,1,0,0);
		SetTileProp(tilemap, 13,59,0,1,0,0);
		SetTileProp(tilemap, 13,60,0,1,0,0);
		SetTileProp(tilemap, 13,61,0,1,0,0);
		SetTileProp(tilemap, 13,62,0,1,0,0);
		SetTileProp(tilemap, 14,0,0,1,0,0);
		SetTileProp(tilemap, 14,1,0,1,0,0);
		SetTileProp(tilemap, 14,2,0,1,4,16);
		SetTileProp(tilemap, 14,3,0,1,4,16);
		SetTileProp(tilemap, 14,4,0,1,4,16);
		SetTileProp(tilemap, 14,5,0,1,4,16);
		SetTileProp(tilemap, 14,6,0,1,4,16);
		SetTileProp(tilemap, 14,7,0,1,4,16);
		SetTileProp(tilemap, 14,8,0,1,4,16);
		SetTileProp(tilemap, 14,9,0,1,4,16);
		SetTileProp(tilemap, 14,10,0,1,4,16);
		SetTileProp(tilemap, 14,11,0,1,4,16);
		SetTileProp(tilemap, 14,12,0,1,4,16);
		SetTileProp(tilemap, 14,13,0,1,4,16);
		SetTileProp(tilemap, 14,14,0,1,4,16);
		SetTileProp(tilemap, 14,15,0,1,4,16);
		SetTileProp(tilemap, 14,16,1,1,0,24);
		SetTileProp(tilemap, 14,17,1,1,12,8);
		SetTileProp(tilemap, 14,18,1,1,12,8);
		SetTileProp(tilemap, 14,19,1,1,12,8);
		SetTileProp(tilemap, 14,20,0,1,12,8);
		SetTileProp(tilemap, 14,21,1,1,8,16);
		SetTileProp(tilemap, 14,22,1,1,8,8);
		SetTileProp(tilemap, 14,23,1,1,8,16);
		SetTileProp(tilemap, 14,24,0,1,12,8);
		SetTileProp(tilemap, 14,25,1,1,15,12);
		SetTileProp(tilemap, 14,26,9,1,8,12);
		SetTileProp(tilemap, 14,27,6,1,13,12);
		SetTileProp(tilemap, 14,28,0,1,8,8);
		SetTileProp(tilemap, 14,29,1,1,8,16);
		SetTileProp(tilemap, 14,30,1,1,8,16);
		SetTileProp(tilemap, 14,31,1,1,8,16);
		SetTileProp(tilemap, 14,32,1,1,8,16);
		SetTileProp(tilemap, 14,33,0,1,12,8);
		SetTileProp(tilemap, 14,34,9,1,0,24);
		SetTileProp(tilemap, 14,35,9,1,0,24);
		SetTileProp(tilemap, 14,36,0,1,8,24);
		SetTileProp(tilemap, 14,37,9,1,0,24);
		SetTileProp(tilemap, 14,38,9,1,0,24);
		SetTileProp(tilemap, 14,39,0,1,8,14);
		SetTileProp(tilemap, 14,40,1,1,8,16);
		SetTileProp(tilemap, 14,41,0,1,8,16);
		SetTileProp(tilemap, 14,42,0,1,8,16);
		SetTileProp(tilemap, 14,43,0,1,12,12);
		SetTileProp(tilemap, 14,44,5,1,14,10);
		SetTileProp(tilemap, 14,45,2,1,14,10);
		SetTileProp(tilemap, 14,46,0,1,8,16);
		SetTileProp(tilemap, 14,47,0,1,8,16);
		SetTileProp(tilemap, 14,48,0,1,8,16);
		SetTileProp(tilemap, 14,49,0,1,16,8);
		SetTileProp(tilemap, 14,50,0,1,4,16);
		SetTileProp(tilemap, 14,51,0,1,4,16);
		SetTileProp(tilemap, 14,52,0,1,4,16);
		SetTileProp(tilemap, 14,53,0,1,4,16);
		SetTileProp(tilemap, 14,54,0,1,8,16);
		SetTileProp(tilemap, 14,55,0,1,8,16);
		SetTileProp(tilemap, 14,56,0,1,8,16);
		SetTileProp(tilemap, 14,57,0,1,0,0);
		SetTileProp(tilemap, 14,58,0,1,0,0);
		SetTileProp(tilemap, 14,59,0,1,0,0);
		SetTileProp(tilemap, 14,60,0,1,0,0);
		SetTileProp(tilemap, 14,61,0,1,0,0);
		SetTileProp(tilemap, 14,62,0,1,0,0);
		SetTileProp(tilemap, 15,0,0,1,0,0);
		SetTileProp(tilemap, 15,1,0,1,0,0);
		SetTileProp(tilemap, 15,2,0,1,4,16);
		SetTileProp(tilemap, 15,3,0,1,4,16);
		SetTileProp(tilemap, 15,4,0,1,4,16);
		SetTileProp(tilemap, 15,5,0,1,4,16);
		SetTileProp(tilemap, 15,6,0,1,4,16);
		SetTileProp(tilemap, 15,7,0,1,4,16);
		SetTileProp(tilemap, 15,8,0,1,4,16);
		SetTileProp(tilemap, 15,9,0,1,4,16);
		SetTileProp(tilemap, 15,10,0,1,8,16);
		SetTileProp(tilemap, 15,11,0,1,8,16);
		SetTileProp(tilemap, 15,12,0,1,8,16);
		SetTileProp(tilemap, 15,13,0,1,8,16);
		SetTileProp(tilemap, 15,14,1,1,0,0);
		SetTileProp(tilemap, 15,15,0,1,0,0);
		SetTileProp(tilemap, 15,16,1,1,0,0);
		SetTileProp(tilemap, 15,17,0,1,12,8);
		SetTileProp(tilemap, 15,18,1,1,12,10);
		SetTileProp(tilemap, 15,19,0,1,12,8);
		SetTileProp(tilemap, 15,20,0,1,12,8);
		SetTileProp(tilemap, 15,21,1,1,8,16);
		SetTileProp(tilemap, 15,22,1,1,20,8);
		SetTileProp(tilemap, 15,23,0,1,12,8);
		SetTileProp(tilemap, 15,24,0,1,12,16);
		SetTileProp(tilemap, 15,25,0,1,12,16);
		SetTileProp(tilemap, 15,26,1,1,8,16);
		SetTileProp(tilemap, 15,27,0,1,12,16);
		SetTileProp(tilemap, 15,28,1,1,12,12);
		SetTileProp(tilemap, 15,29,0,1,8,8);
		SetTileProp(tilemap, 15,30,1,1,8,16);
		SetTileProp(tilemap, 15,31,0,1,8,8);
		SetTileProp(tilemap, 15,32,0,1,8,8);
		SetTileProp(tilemap, 15,33,1,1,8,16);
		SetTileProp(tilemap, 15,34,0,1,8,8);
		SetTileProp(tilemap, 15,35,4,1,8,16);
		SetTileProp(tilemap, 15,36,1,1,8,16);
		SetTileProp(tilemap, 15,37,1,1,8,16);
		SetTileProp(tilemap, 15,38,0,1,4,8);
		SetTileProp(tilemap, 15,39,7,1,8,14);
		SetTileProp(tilemap, 15,40,1,1,8,14);
		SetTileProp(tilemap, 15,41,6,1,8,14);
		SetTileProp(tilemap, 15,42,0,1,8,16);
		SetTileProp(tilemap, 15,43,0,1,8,16);
		SetTileProp(tilemap, 15,44,0,1,14,10);
		SetTileProp(tilemap, 15,45,5,1,14,9);
		SetTileProp(tilemap, 15,46,2,1,15,9);
		SetTileProp(tilemap, 15,47,0,1,8,16);
		SetTileProp(tilemap, 15,48,0,1,16,8);
		SetTileProp(tilemap, 15,49,0,1,16,8);
		SetTileProp(tilemap, 15,50,0,1,4,16);
		SetTileProp(tilemap, 15,51,0,1,4,16);
		SetTileProp(tilemap, 15,52,0,1,4,16);
		SetTileProp(tilemap, 15,53,0,1,4,16);
		SetTileProp(tilemap, 15,54,0,1,8,16);
		SetTileProp(tilemap, 15,55,0,1,8,16);
		SetTileProp(tilemap, 15,56,0,1,8,16);
		SetTileProp(tilemap, 15,57,0,1,0,0);
		SetTileProp(tilemap, 15,58,0,1,0,0);
		SetTileProp(tilemap, 15,59,0,1,0,0);
		SetTileProp(tilemap, 15,60,0,1,0,0);
		SetTileProp(tilemap, 15,61,0,1,0,0);
		SetTileProp(tilemap, 15,62,0,1,0,0);
		SetTileProp(tilemap, 16,0,0,1,0,0);
		SetTileProp(tilemap, 16,1,0,1,0,0);
		SetTileProp(tilemap, 16,2,0,1,4,16);
		SetTileProp(tilemap, 16,3,0,1,4,16);
		SetTileProp(tilemap, 16,4,0,1,4,16);
		SetTileProp(tilemap, 16,5,0,1,4,16);
		SetTileProp(tilemap, 16,6,0,1,4,16);
		SetTileProp(tilemap, 16,7,0,1,4,16);
		SetTileProp(tilemap, 16,8,0,1,4,16);
		SetTileProp(tilemap, 16,9,0,1,4,16);
		SetTileProp(tilemap, 16,10,0,1,8,16);
		SetTileProp(tilemap, 16,11,0,1,8,16);
		SetTileProp(tilemap, 16,12,0,1,8,16);
		SetTileProp(tilemap, 16,13,0,1,8,16);
		SetTileProp(tilemap, 16,14,1,1,0,0);
		SetTileProp(tilemap, 16,15,1,1,0,0);
		SetTileProp(tilemap, 16,16,3,1,0,0);
		SetTileProp(tilemap, 16,17,9,1,8,8);
		SetTileProp(tilemap, 16,18,9,1,8,8);
		SetTileProp(tilemap, 16,19,9,1,8,8);
		SetTileProp(tilemap, 16,20,9,1,8,8);
		SetTileProp(tilemap, 16,21,1,1,8,8);
		SetTileProp(tilemap, 16,22,9,1,8,8);
		SetTileProp(tilemap, 16,23,0,1,8,8);
		SetTileProp(tilemap, 16,24,9,1,8,8);
		SetTileProp(tilemap, 16,25,9,1,8,8);
		SetTileProp(tilemap, 16,26,1,1,8,8);
		SetTileProp(tilemap, 16,27,9,1,8,8);
		SetTileProp(tilemap, 16,28,9,1,8,8);
		SetTileProp(tilemap, 16,29,9,1,8,8);
		SetTileProp(tilemap, 16,30,8,1,8,8);
		SetTileProp(tilemap, 16,31,1,1,8,8);
		SetTileProp(tilemap, 16,32,1,1,8,8);
		SetTileProp(tilemap, 16,33,1,1,8,8);
		SetTileProp(tilemap, 16,34,8,1,8,8);
		SetTileProp(tilemap, 16,35,1,1,8,16);
		SetTileProp(tilemap, 16,36,1,1,8,16);
		SetTileProp(tilemap, 16,37,0,1,8,8);
		SetTileProp(tilemap, 16,38,1,1,16,12);
		SetTileProp(tilemap, 16,39,7,1,8,14);
		SetTileProp(tilemap, 16,40,1,1,8,14);
		SetTileProp(tilemap, 16,41,6,1,8,14);
		SetTileProp(tilemap, 16,42,1,1,16,8);
		SetTileProp(tilemap, 16,43,1,1,16,8);
		SetTileProp(tilemap, 16,44,1,1,16,8);
		SetTileProp(tilemap, 16,45,0,1,16,8);
		SetTileProp(tilemap, 16,46,1,1,16,8);
		SetTileProp(tilemap, 16,47,2,1,16,8);
		SetTileProp(tilemap, 16,48,0,1,16,8);
		SetTileProp(tilemap, 16,49,0,1,16,8);
		SetTileProp(tilemap, 16,50,0,1,4,24);
		SetTileProp(tilemap, 16,51,0,1,4,16);
		SetTileProp(tilemap, 16,52,0,1,4,16);
		SetTileProp(tilemap, 16,53,0,1,4,16);
		SetTileProp(tilemap, 16,54,0,1,8,16);
		SetTileProp(tilemap, 16,55,0,1,8,16);
		SetTileProp(tilemap, 16,56,0,1,8,16);
		SetTileProp(tilemap, 16,57,0,1,0,0);
		SetTileProp(tilemap, 16,58,0,1,0,0);
		SetTileProp(tilemap, 16,59,0,1,0,0);
		SetTileProp(tilemap, 16,60,0,1,0,0);
		SetTileProp(tilemap, 16,61,0,1,0,0);
		SetTileProp(tilemap, 16,62,0,1,0,0);
		SetTileProp(tilemap, 17,0,0,1,0,0);
		SetTileProp(tilemap, 17,1,0,1,0,0);
		SetTileProp(tilemap, 17,2,0,1,4,16);
		SetTileProp(tilemap, 17,3,0,1,4,16);
		SetTileProp(tilemap, 17,4,0,1,4,16);
		SetTileProp(tilemap, 17,5,0,1,4,16);
		SetTileProp(tilemap, 17,6,0,1,4,16);
		SetTileProp(tilemap, 17,7,0,1,4,16);
		SetTileProp(tilemap, 17,8,0,1,4,16);
		SetTileProp(tilemap, 17,9,0,1,4,16);
		SetTileProp(tilemap, 17,10,0,1,8,16);
		SetTileProp(tilemap, 17,11,0,1,8,16);
		SetTileProp(tilemap, 17,12,0,1,8,16);
		SetTileProp(tilemap, 17,13,0,1,8,16);
		SetTileProp(tilemap, 17,14,1,1,0,0);
		SetTileProp(tilemap, 17,15,9,1,8,0);
		SetTileProp(tilemap, 17,16,0,1,8,16);
		SetTileProp(tilemap, 17,17,1,1,8,8);
		SetTileProp(tilemap, 17,18,1,1,8,8);
		SetTileProp(tilemap, 17,19,1,1,8,8);
		SetTileProp(tilemap, 17,20,1,1,8,8);
		SetTileProp(tilemap, 17,21,1,1,8,8);
		SetTileProp(tilemap, 17,22,1,1,8,8);
		SetTileProp(tilemap, 17,23,1,1,8,16);
		SetTileProp(tilemap, 17,24,1,1,8,8);
		SetTileProp(tilemap, 17,25,1,1,8,8);
		SetTileProp(tilemap, 17,26,1,1,8,8);
		SetTileProp(tilemap, 17,27,1,1,8,8);
		SetTileProp(tilemap, 17,28,1,1,8,8);
		SetTileProp(tilemap, 17,29,1,1,8,8);
		SetTileProp(tilemap, 17,30,1,1,8,8);
		SetTileProp(tilemap, 17,31,7,1,8,8);
		SetTileProp(tilemap, 17,32,0,1,8,8);
		SetTileProp(tilemap, 17,33,6,1,8,8);
		SetTileProp(tilemap, 17,34,1,1,8,8);
		SetTileProp(tilemap, 17,35,1,1,8,16);
		SetTileProp(tilemap, 17,36,1,1,8,16);
		SetTileProp(tilemap, 17,37,1,1,8,16);
		SetTileProp(tilemap, 17,38,1,1,16,12);
		SetTileProp(tilemap, 17,39,7,1,8,14);
		SetTileProp(tilemap, 17,40,1,1,8,14);
		SetTileProp(tilemap, 17,41,6,1,8,14);
		SetTileProp(tilemap, 17,42,1,1,16,8);
		SetTileProp(tilemap, 17,43,1,1,16,3);
		SetTileProp(tilemap, 17,44,1,1,16,8);
		SetTileProp(tilemap, 17,45,0,1,16,8);
		SetTileProp(tilemap, 17,46,1,1,16,8);
		SetTileProp(tilemap, 17,47,1,1,16,8);
		SetTileProp(tilemap, 17,48,0,1,16,8);
		SetTileProp(tilemap, 17,49,0,1,16,8);
		SetTileProp(tilemap, 17,50,0,1,4,24);
		SetTileProp(tilemap, 17,51,0,1,4,24);
		SetTileProp(tilemap, 17,52,0,1,4,16);
		SetTileProp(tilemap, 17,53,0,1,4,16);
		SetTileProp(tilemap, 17,54,0,1,8,16);
		SetTileProp(tilemap, 17,55,0,1,8,16);
		SetTileProp(tilemap, 17,56,0,1,8,16);
		SetTileProp(tilemap, 17,57,0,1,0,0);
		SetTileProp(tilemap, 17,58,0,1,0,0);
		SetTileProp(tilemap, 17,59,0,1,0,0);
		SetTileProp(tilemap, 17,60,0,1,0,0);
		SetTileProp(tilemap, 17,61,0,1,0,0);
		SetTileProp(tilemap, 17,62,0,1,0,0);
		SetTileProp(tilemap, 18,0,0,1,0,0);
		SetTileProp(tilemap, 18,1,0,1,0,0);
		SetTileProp(tilemap, 18,2,0,1,4,16);
		SetTileProp(tilemap, 18,3,0,1,4,16);
		SetTileProp(tilemap, 18,4,0,1,4,16);
		SetTileProp(tilemap, 18,5,0,1,4,16);
		SetTileProp(tilemap, 18,6,0,1,4,16);
		SetTileProp(tilemap, 18,7,0,1,4,16);
		SetTileProp(tilemap, 18,8,0,1,4,16);
		SetTileProp(tilemap, 18,9,0,1,4,16);
		SetTileProp(tilemap, 18,10,0,1,8,16);
		SetTileProp(tilemap, 18,11,0,1,8,16);
		SetTileProp(tilemap, 18,12,4,1,8,16);
		SetTileProp(tilemap, 18,13,1,1,8,16);
		SetTileProp(tilemap, 18,14,0,1,8,16);
		SetTileProp(tilemap, 18,15,1,1,8,16);
		SetTileProp(tilemap, 18,16,0,1,8,16);
		SetTileProp(tilemap, 18,17,8,1,8,8);
		SetTileProp(tilemap, 18,18,1,1,8,12);
		SetTileProp(tilemap, 18,19,8,1,8,8);
		SetTileProp(tilemap, 18,20,9,1,7,7);
		SetTileProp(tilemap, 18,21,8,1,8,8);
		SetTileProp(tilemap, 18,22,8,1,8,4);
		SetTileProp(tilemap, 18,23,1,1,8,16);
		SetTileProp(tilemap, 18,24,8,1,8,4);
		SetTileProp(tilemap, 18,25,9,1,8,8);
		SetTileProp(tilemap, 18,26,8,1,8,8);
		SetTileProp(tilemap, 18,27,8,1,8,8);
		SetTileProp(tilemap, 18,28,8,1,8,8);
		SetTileProp(tilemap, 18,29,1,1,8,8);
		SetTileProp(tilemap, 18,30,1,1,8,8);
		SetTileProp(tilemap, 18,31,1,1,8,8);
		SetTileProp(tilemap, 18,32,8,1,8,8);
		SetTileProp(tilemap, 18,33,1,1,8,8);
		SetTileProp(tilemap, 18,34,1,1,8,8);
		SetTileProp(tilemap, 18,35,0,1,8,16);
		SetTileProp(tilemap, 18,36,1,1,8,16);
		SetTileProp(tilemap, 18,37,1,1,8,16);
		SetTileProp(tilemap, 18,38,1,1,16,12);
		SetTileProp(tilemap, 18,39,7,1,8,14);
		SetTileProp(tilemap, 18,40,1,1,8,14);
		SetTileProp(tilemap, 18,41,6,1,8,14);
		SetTileProp(tilemap, 18,42,1,1,16,8);
		SetTileProp(tilemap, 18,43,1,1,16,8);
		SetTileProp(tilemap, 18,44,1,1,16,8);
		SetTileProp(tilemap, 18,45,0,1,16,8);
		SetTileProp(tilemap, 18,46,1,1,16,8);
		SetTileProp(tilemap, 18,47,1,1,16,8);
		SetTileProp(tilemap, 18,48,0,1,16,4);
		SetTileProp(tilemap, 18,49,0,1,16,6);
		SetTileProp(tilemap, 18,50,0,1,11,8);
		SetTileProp(tilemap, 18,51,0,1,9,13);
		SetTileProp(tilemap, 18,52,0,1,7,18);
		SetTileProp(tilemap, 18,53,0,1,6,19);
		SetTileProp(tilemap, 18,54,0,1,5,20);
		SetTileProp(tilemap, 18,55,0,1,4,21);
		SetTileProp(tilemap, 18,56,0,1,4,21);
		SetTileProp(tilemap, 18,57,0,1,0,0);
		SetTileProp(tilemap, 18,58,0,1,0,0);
		SetTileProp(tilemap, 18,59,0,1,0,0);
		SetTileProp(tilemap, 18,60,0,1,0,0);
		SetTileProp(tilemap, 18,61,0,1,0,0);
		SetTileProp(tilemap, 18,62,0,1,0,0);
		SetTileProp(tilemap, 19,0,0,1,0,0);
		SetTileProp(tilemap, 19,1,0,1,0,0);
		SetTileProp(tilemap, 19,2,0,1,4,16);
		SetTileProp(tilemap, 19,3,0,1,4,16);
		SetTileProp(tilemap, 19,4,0,1,4,16);
		SetTileProp(tilemap, 19,5,0,1,4,16);
		SetTileProp(tilemap, 19,6,0,1,4,16);
		SetTileProp(tilemap, 19,7,0,1,4,16);
		SetTileProp(tilemap, 19,8,0,1,4,16);
		SetTileProp(tilemap, 19,9,0,1,4,16);
		SetTileProp(tilemap, 19,10,0,1,8,16);
		SetTileProp(tilemap, 19,11,4,1,8,16);
		SetTileProp(tilemap, 19,12,1,1,8,16);
		SetTileProp(tilemap, 19,13,1,1,8,16);
		SetTileProp(tilemap, 19,14,0,1,8,16);
		SetTileProp(tilemap, 19,15,1,1,8,16);
		SetTileProp(tilemap, 19,16,7,1,0,0);
		SetTileProp(tilemap, 19,17,7,1,0,20);
		SetTileProp(tilemap, 19,18,1,1,0,24);
		SetTileProp(tilemap, 19,19,0,1,4,16);
		SetTileProp(tilemap, 19,20,9,1,4,8);
		SetTileProp(tilemap, 19,21,0,1,8,8);
		SetTileProp(tilemap, 19,22,0,1,8,16);
		SetTileProp(tilemap, 19,23,0,1,8,16);
		SetTileProp(tilemap, 19,24,0,1,8,16);
		SetTileProp(tilemap, 19,25,0,1,8,16);
		SetTileProp(tilemap, 19,26,0,1,8,16);
		SetTileProp(tilemap, 19,27,0,1,8,16);
		SetTileProp(tilemap, 19,28,0,1,8,16);
		SetTileProp(tilemap, 19,29,7,1,8,8);
		SetTileProp(tilemap, 19,30,1,1,8,8);
		SetTileProp(tilemap, 19,31,1,1,8,8);
		SetTileProp(tilemap, 19,32,1,1,8,8);
		SetTileProp(tilemap, 19,33,1,1,8,8);
		SetTileProp(tilemap, 19,34,0,1,8,24);
		SetTileProp(tilemap, 19,35,0,1,8,8);
		SetTileProp(tilemap, 19,36,0,1,8,8);
		SetTileProp(tilemap, 19,37,1,1,16,8);
		SetTileProp(tilemap, 19,38,1,1,16,8);
		SetTileProp(tilemap, 19,39,7,1,8,14);
		SetTileProp(tilemap, 19,40,1,1,8,14);
		SetTileProp(tilemap, 19,41,6,1,8,14);
		SetTileProp(tilemap, 19,42,0,1,16,8);
		SetTileProp(tilemap, 19,43,0,1,16,8);
		SetTileProp(tilemap, 19,44,1,1,16,8);
		SetTileProp(tilemap, 19,45,0,1,16,8);
		SetTileProp(tilemap, 19,46,1,1,16,8);
		SetTileProp(tilemap, 19,47,0,1,16,12);
		SetTileProp(tilemap, 19,48,0,1,16,12);
		SetTileProp(tilemap, 19,49,0,1,16,8);
		SetTileProp(tilemap, 19,50,0,1,4,24);
		SetTileProp(tilemap, 19,51,0,1,4,24);
		SetTileProp(tilemap, 19,52,0,1,4,16);
		SetTileProp(tilemap, 19,53,0,1,4,16);
		SetTileProp(tilemap, 19,54,0,1,8,16);
		SetTileProp(tilemap, 19,55,0,1,8,16);
		SetTileProp(tilemap, 19,56,0,1,4,21);
		SetTileProp(tilemap, 19,57,0,1,0,0);
		SetTileProp(tilemap, 19,58,0,1,0,0);
		SetTileProp(tilemap, 19,59,0,1,0,0);
		SetTileProp(tilemap, 19,60,0,1,0,0);
		SetTileProp(tilemap, 19,61,0,1,0,0);
		SetTileProp(tilemap, 19,62,0,1,0,0);
		SetTileProp(tilemap, 20,0,0,1,0,0);
		SetTileProp(tilemap, 20,1,0,1,0,0);
		SetTileProp(tilemap, 20,2,0,1,4,16);
		SetTileProp(tilemap, 20,3,0,1,4,16);
		SetTileProp(tilemap, 20,4,0,1,4,16);
		SetTileProp(tilemap, 20,5,0,1,4,16);
		SetTileProp(tilemap, 20,6,0,1,4,16);
		SetTileProp(tilemap, 20,7,0,1,8,16);
		SetTileProp(tilemap, 20,8,0,1,8,13);
		SetTileProp(tilemap, 20,9,0,1,8,16);
		SetTileProp(tilemap, 20,10,0,1,8,16);
		SetTileProp(tilemap, 20,11,5,1,8,16);
		SetTileProp(tilemap, 20,12,3,1,8,16);
		SetTileProp(tilemap, 20,13,1,1,8,16);
		SetTileProp(tilemap, 20,14,0,1,8,16);
		SetTileProp(tilemap, 20,15,1,1,8,16);
		SetTileProp(tilemap, 20,16,1,1,8,16);
		SetTileProp(tilemap, 20,17,1,1,8,16);
		SetTileProp(tilemap, 20,18,0,1,8,8);
		SetTileProp(tilemap, 20,19,8,1,4,18);
		SetTileProp(tilemap, 20,20,8,1,4,18);
		SetTileProp(tilemap, 20,21,8,1,4,18);
		SetTileProp(tilemap, 20,22,8,1,4,18);
		SetTileProp(tilemap, 20,23,8,1,4,18);
		SetTileProp(tilemap, 20,24,1,1,4,13);
		SetTileProp(tilemap, 20,25,1,1,4,20);
		SetTileProp(tilemap, 20,26,6,1,4,13);
		SetTileProp(tilemap, 20,27,6,1,4,13);
		SetTileProp(tilemap, 20,28,0,1,8,8);
		SetTileProp(tilemap, 20,29,7,1,8,8);
		SetTileProp(tilemap, 20,30,1,1,8,8);
		SetTileProp(tilemap, 20,31,6,1,8,8);
		SetTileProp(tilemap, 20,32,0,1,8,8);
		SetTileProp(tilemap, 20,33,9,1,0,16);
		SetTileProp(tilemap, 20,34,1,1,16,8);
		SetTileProp(tilemap, 20,35,1,1,16,8);
		SetTileProp(tilemap, 20,36,0,1,4,8);
		SetTileProp(tilemap, 20,37,1,1,16,8);
		SetTileProp(tilemap, 20,38,1,1,16,8);
		SetTileProp(tilemap, 20,39,7,1,8,14);
		SetTileProp(tilemap, 20,40,1,1,8,14);
		SetTileProp(tilemap, 20,41,6,1,8,14);
		SetTileProp(tilemap, 20,42,1,1,16,8);
		SetTileProp(tilemap, 20,43,1,1,16,8);
		SetTileProp(tilemap, 20,44,1,1,16,8);
		SetTileProp(tilemap, 20,45,1,1,16,8);
		SetTileProp(tilemap, 20,46,1,1,16,8);
		SetTileProp(tilemap, 20,47,1,1,16,8);
		SetTileProp(tilemap, 20,48,5,1,12,12);
		SetTileProp(tilemap, 20,49,1,1,12,12);
		SetTileProp(tilemap, 20,50,0,1,4,16);
		SetTileProp(tilemap, 20,51,0,1,4,16);
		SetTileProp(tilemap, 20,52,1,1,8,16);
		SetTileProp(tilemap, 20,53,1,1,8,16);
		SetTileProp(tilemap, 20,54,0,1,4,12);
		SetTileProp(tilemap, 20,55,0,1,8,16);
		SetTileProp(tilemap, 20,56,0,1,4,21);
		SetTileProp(tilemap, 20,57,0,1,0,0);
		SetTileProp(tilemap, 20,58,0,1,0,0);
		SetTileProp(tilemap, 20,59,0,1,0,0);
		SetTileProp(tilemap, 20,60,0,1,0,0);
		SetTileProp(tilemap, 20,61,0,1,0,0);
		SetTileProp(tilemap, 20,62,0,1,0,0);
		SetTileProp(tilemap, 21,0,0,1,0,0);
		SetTileProp(tilemap, 21,1,0,1,0,0);
		SetTileProp(tilemap, 21,2,0,1,4,16);
		SetTileProp(tilemap, 21,3,0,1,4,16);
		SetTileProp(tilemap, 21,4,0,1,4,16);
		SetTileProp(tilemap, 21,5,0,1,4,16);
		SetTileProp(tilemap, 21,6,0,1,4,16);
		SetTileProp(tilemap, 21,7,0,1,8,16);
		SetTileProp(tilemap, 21,8,0,1,4,0);
		SetTileProp(tilemap, 21,9,7,1,8,16);
		SetTileProp(tilemap, 21,10,1,1,8,16);
		SetTileProp(tilemap, 21,11,1,1,8,16);
		SetTileProp(tilemap, 21,12,0,1,8,16);
		SetTileProp(tilemap, 21,13,1,1,8,16);
		SetTileProp(tilemap, 21,14,1,1,8,16);
		SetTileProp(tilemap, 21,15,1,1,8,16);
		SetTileProp(tilemap, 21,16,1,1,0,0);
		SetTileProp(tilemap, 21,17,0,1,8,16);
		SetTileProp(tilemap, 21,18,0,1,4,13);
		SetTileProp(tilemap, 21,19,9,1,4,18);
		SetTileProp(tilemap, 21,20,9,1,4,18);
		SetTileProp(tilemap, 21,21,1,1,4,18);
		SetTileProp(tilemap, 21,22,1,1,4,18);
		SetTileProp(tilemap, 21,23,3,1,4,8);
		SetTileProp(tilemap, 21,24,4,1,6,20);
		SetTileProp(tilemap, 21,25,1,1,4,13);
		SetTileProp(tilemap, 21,26,1,1,4,13);
		SetTileProp(tilemap, 21,27,6,1,4,13);
		SetTileProp(tilemap, 21,28,0,1,8,8);
		SetTileProp(tilemap, 21,29,7,1,8,8);
		SetTileProp(tilemap, 21,30,1,1,8,8);
		SetTileProp(tilemap, 21,31,6,1,8,8);
		SetTileProp(tilemap, 21,32,1,1,0,24);
		SetTileProp(tilemap, 21,33,9,1,0,16);
		SetTileProp(tilemap, 21,34,1,1,16,8);
		SetTileProp(tilemap, 21,35,1,1,16,8);
		SetTileProp(tilemap, 21,36,0,1,4,16);
		SetTileProp(tilemap, 21,37,1,1,16,8);
		SetTileProp(tilemap, 21,38,1,1,16,8);
		SetTileProp(tilemap, 21,39,7,1,8,14);
		SetTileProp(tilemap, 21,40,1,1,8,14);
		SetTileProp(tilemap, 21,41,1,1,0,24);
		SetTileProp(tilemap, 21,42,0,1,8,14);
		SetTileProp(tilemap, 21,43,1,1,16,8);
		SetTileProp(tilemap, 21,44,0,1,16,8);
		SetTileProp(tilemap, 21,45,0,1,19,5);
		SetTileProp(tilemap, 21,46,0,1,15,8);
		SetTileProp(tilemap, 21,47,1,1,16,8);
		SetTileProp(tilemap, 21,48,3,1,15,8);
		SetTileProp(tilemap, 21,49,1,1,12,12);
		SetTileProp(tilemap, 21,50,3,1,12,12);
		SetTileProp(tilemap, 21,51,0,1,4,16);
		SetTileProp(tilemap, 21,52,1,1,8,16);
		SetTileProp(tilemap, 21,53,1,1,8,16);
		SetTileProp(tilemap, 21,54,0,1,4,12);
		SetTileProp(tilemap, 21,55,0,1,8,16);
		SetTileProp(tilemap, 21,56,0,1,4,21);
		SetTileProp(tilemap, 21,57,0,1,0,0);
		SetTileProp(tilemap, 21,58,0,1,0,0);
		SetTileProp(tilemap, 21,59,0,1,0,0);
		SetTileProp(tilemap, 21,60,0,1,0,0);
		SetTileProp(tilemap, 21,61,0,1,0,0);
		SetTileProp(tilemap, 21,62,0,1,0,0);
		SetTileProp(tilemap, 22,0,0,1,0,0);
		SetTileProp(tilemap, 22,1,0,1,0,0);
		SetTileProp(tilemap, 22,2,0,1,4,16);
		SetTileProp(tilemap, 22,3,0,1,4,16);
		SetTileProp(tilemap, 22,4,0,1,4,16);
		SetTileProp(tilemap, 22,5,0,1,4,16);
		SetTileProp(tilemap, 22,6,0,1,4,16);
		SetTileProp(tilemap, 22,7,0,1,8,16);
		SetTileProp(tilemap, 22,8,0,1,4,0);
		SetTileProp(tilemap, 22,9,7,1,8,16);
		SetTileProp(tilemap, 22,10,1,1,8,16);
		SetTileProp(tilemap, 22,11,1,1,8,16);
		SetTileProp(tilemap, 22,12,0,1,8,16);
		SetTileProp(tilemap, 22,13,0,1,8,8);
		SetTileProp(tilemap, 22,14,0,1,8,8);
		SetTileProp(tilemap, 22,15,1,1,8,16);
		SetTileProp(tilemap, 22,16,1,1,0,0);
		SetTileProp(tilemap, 22,17,1,1,23,0);
		SetTileProp(tilemap, 22,18,1,1,12,10);
		SetTileProp(tilemap, 22,19,0,1,4,13);
		SetTileProp(tilemap, 22,20,0,1,4,13);
		SetTileProp(tilemap, 22,21,1,1,4,20);
		SetTileProp(tilemap, 22,22,0,1,4,13);
		SetTileProp(tilemap, 22,23,0,1,4,13);
		SetTileProp(tilemap, 22,24,1,1,6,20);
		SetTileProp(tilemap, 22,25,1,1,4,13);
		SetTileProp(tilemap, 22,26,1,1,4,13);
		SetTileProp(tilemap, 22,27,0,1,4,13);
		SetTileProp(tilemap, 22,28,0,1,8,16);
		SetTileProp(tilemap, 22,29,6,1,12,8);
		SetTileProp(tilemap, 22,30,1,1,8,8);
		SetTileProp(tilemap, 22,31,6,1,8,8);
		SetTileProp(tilemap, 22,32,1,1,0,24);
		SetTileProp(tilemap, 22,33,7,1,0,24);
		SetTileProp(tilemap, 22,34,1,1,16,8);
		SetTileProp(tilemap, 22,35,1,1,16,8);
		SetTileProp(tilemap, 22,36,0,1,4,8);
		SetTileProp(tilemap, 22,37,1,1,16,8);
		SetTileProp(tilemap, 22,38,7,1,16,8);
		SetTileProp(tilemap, 22,39,0,1,4,8);
		SetTileProp(tilemap, 22,40,2,1,15,8);
		SetTileProp(tilemap, 22,41,0,1,8,14);
		SetTileProp(tilemap, 22,42,0,1,4,24);
		SetTileProp(tilemap, 22,43,1,1,16,8);
		SetTileProp(tilemap, 22,44,5,1,0,24);
		SetTileProp(tilemap, 22,45,1,1,0,24);
		SetTileProp(tilemap, 22,46,4,1,15,8);
		SetTileProp(tilemap, 22,47,1,1,16,8);
		SetTileProp(tilemap, 22,48,5,1,12,12);
		SetTileProp(tilemap, 22,49,1,1,12,12);
		SetTileProp(tilemap, 22,50,0,1,19,5);
		SetTileProp(tilemap, 22,51,0,1,4,16);
		SetTileProp(tilemap, 22,52,1,1,8,16);
		SetTileProp(tilemap, 22,53,1,1,8,16);
		SetTileProp(tilemap, 22,54,0,1,4,16);
		SetTileProp(tilemap, 22,55,0,1,8,16);
		SetTileProp(tilemap, 22,56,0,1,4,21);
		SetTileProp(tilemap, 22,57,0,1,0,0);
		SetTileProp(tilemap, 22,58,0,1,0,0);
		SetTileProp(tilemap, 22,59,0,1,0,0);
		SetTileProp(tilemap, 22,60,0,1,0,0);
		SetTileProp(tilemap, 22,61,0,1,0,0);
		SetTileProp(tilemap, 22,62,0,1,0,0);
		SetTileProp(tilemap, 23,0,0,1,0,0);
		SetTileProp(tilemap, 23,1,0,1,0,0);
		SetTileProp(tilemap, 23,2,0,1,4,16);
		SetTileProp(tilemap, 23,3,0,1,4,16);
		SetTileProp(tilemap, 23,4,0,1,4,16);
		SetTileProp(tilemap, 23,5,0,1,4,16);
		SetTileProp(tilemap, 23,6,0,1,4,16);
		SetTileProp(tilemap, 23,7,0,1,8,16);
		SetTileProp(tilemap, 23,8,0,1,4,0);
		SetTileProp(tilemap, 23,9,7,1,8,16);
		SetTileProp(tilemap, 23,10,1,1,8,16);
		SetTileProp(tilemap, 23,11,1,1,8,16);
		SetTileProp(tilemap, 23,12,1,1,8,16);
		SetTileProp(tilemap, 23,13,6,1,8,12);
		SetTileProp(tilemap, 23,14,0,1,8,8);
		SetTileProp(tilemap, 23,15,1,1,8,16);
		SetTileProp(tilemap, 23,16,1,1,0,0);
		SetTileProp(tilemap, 23,17,0,1,8,8);
		SetTileProp(tilemap, 23,18,1,1,12,10);
		SetTileProp(tilemap, 23,19,1,1,4,10);
		SetTileProp(tilemap, 23,20,1,1,4,10);
		SetTileProp(tilemap, 23,21,1,1,4,10);
		SetTileProp(tilemap, 23,22,1,1,4,13);
		SetTileProp(tilemap, 23,23,2,1,4,8);
		SetTileProp(tilemap, 23,24,5,1,6,20);
		SetTileProp(tilemap, 23,25,1,1,4,13);
		SetTileProp(tilemap, 23,26,1,1,4,13);
		SetTileProp(tilemap, 23,27,6,1,4,13);
		SetTileProp(tilemap, 23,28,0,1,8,8);
		SetTileProp(tilemap, 23,29,0,1,8,8);
		SetTileProp(tilemap, 23,30,1,1,8,8);
		SetTileProp(tilemap, 23,31,7,1,0,8);
		SetTileProp(tilemap, 23,32,1,1,0,24);
		SetTileProp(tilemap, 23,33,7,1,0,24);
		SetTileProp(tilemap, 23,34,1,1,16,8);
		SetTileProp(tilemap, 23,35,1,1,16,8);
		SetTileProp(tilemap, 23,36,1,1,16,8);
		SetTileProp(tilemap, 23,37,1,1,16,8);
		SetTileProp(tilemap, 23,38,1,1,16,8);
		SetTileProp(tilemap, 23,39,1,1,16,8);
		SetTileProp(tilemap, 23,40,1,1,16,8);
		SetTileProp(tilemap, 23,41,1,1,16,8);
		SetTileProp(tilemap, 23,42,1,1,16,8);
		SetTileProp(tilemap, 23,43,1,1,16,8);
		SetTileProp(tilemap, 23,44,1,1,16,8);
		SetTileProp(tilemap, 23,45,1,1,0,24);
		SetTileProp(tilemap, 23,46,2,1,0,24);
		SetTileProp(tilemap, 23,47,1,1,16,8);
		SetTileProp(tilemap, 23,48,3,1,15,8);
		SetTileProp(tilemap, 23,49,1,1,12,12);
		SetTileProp(tilemap, 23,50,3,1,12,12);
		SetTileProp(tilemap, 23,51,0,1,4,16);
		SetTileProp(tilemap, 23,52,1,1,8,16);
		SetTileProp(tilemap, 23,53,1,1,8,16);
		SetTileProp(tilemap, 23,54,0,1,4,12);
		SetTileProp(tilemap, 23,55,0,1,8,16);
		SetTileProp(tilemap, 23,56,0,1,4,21);
		SetTileProp(tilemap, 23,57,0,1,0,0);
		SetTileProp(tilemap, 23,58,0,1,0,0);
		SetTileProp(tilemap, 23,59,0,1,0,0);
		SetTileProp(tilemap, 23,60,0,1,0,0);
		SetTileProp(tilemap, 23,61,0,1,0,0);
		SetTileProp(tilemap, 23,62,0,1,0,0);
		SetTileProp(tilemap, 24,0,0,1,0,0);
		SetTileProp(tilemap, 24,1,0,1,0,0);
		SetTileProp(tilemap, 24,2,0,1,4,16);
		SetTileProp(tilemap, 24,3,0,1,4,16);
		SetTileProp(tilemap, 24,4,0,1,4,16);
		SetTileProp(tilemap, 24,5,0,1,4,16);
		SetTileProp(tilemap, 24,6,0,1,4,16);
		SetTileProp(tilemap, 24,7,0,1,8,16);
		SetTileProp(tilemap, 24,8,0,1,4,0);
		SetTileProp(tilemap, 24,9,0,1,8,16);
		SetTileProp(tilemap, 24,10,1,1,8,16);
		SetTileProp(tilemap, 24,11,1,1,8,16);
		SetTileProp(tilemap, 24,12,6,1,8,16);
		SetTileProp(tilemap, 24,13,6,1,8,12);
		SetTileProp(tilemap, 24,14,1,1,8,16);
		SetTileProp(tilemap, 24,15,1,1,8,16);
		SetTileProp(tilemap, 24,16,1,1,8,16);
		SetTileProp(tilemap, 24,17,0,1,8,8);
		SetTileProp(tilemap, 24,18,1,1,4,10);
		SetTileProp(tilemap, 24,19,1,1,4,10);
		SetTileProp(tilemap, 24,20,7,1,10,10);
		SetTileProp(tilemap, 24,21,7,1,7,10);
		SetTileProp(tilemap, 24,22,7,1,4,13);
		SetTileProp(tilemap, 24,23,1,1,4,20);
		SetTileProp(tilemap, 24,24,1,1,4,20);
		SetTileProp(tilemap, 24,25,1,1,4,20);
		SetTileProp(tilemap, 24,26,1,1,4,13);
		SetTileProp(tilemap, 24,27,6,1,4,13);
		SetTileProp(tilemap, 24,28,0,1,8,8);
		SetTileProp(tilemap, 24,29,7,1,8,8);
		SetTileProp(tilemap, 24,30,1,1,8,8);
		SetTileProp(tilemap, 24,31,6,1,8,8);
		SetTileProp(tilemap, 24,32,1,1,0,24);
		SetTileProp(tilemap, 24,33,7,1,0,24);
		SetTileProp(tilemap, 24,34,1,1,16,8);
		SetTileProp(tilemap, 24,35,1,1,16,8);
		SetTileProp(tilemap, 24,36,0,1,4,8);
		SetTileProp(tilemap, 24,37,1,1,16,8);
		SetTileProp(tilemap, 24,38,7,1,16,8);
		SetTileProp(tilemap, 24,39,0,1,4,8);
		SetTileProp(tilemap, 24,40,0,1,4,8);
		SetTileProp(tilemap, 24,41,0,1,4,8);
		SetTileProp(tilemap, 24,42,3,1,15,8);
		SetTileProp(tilemap, 24,43,1,1,16,8);
		SetTileProp(tilemap, 24,44,4,1,0,24);
		SetTileProp(tilemap, 24,45,1,1,0,24);
		SetTileProp(tilemap, 24,46,4,1,15,8);
		SetTileProp(tilemap, 24,47,1,1,16,8);
		SetTileProp(tilemap, 24,48,5,1,12,12);
		SetTileProp(tilemap, 24,49,1,1,12,12);
		SetTileProp(tilemap, 24,50,0,1,19,5);
		SetTileProp(tilemap, 24,51,1,1,8,8);
		SetTileProp(tilemap, 24,52,1,1,8,16);
		SetTileProp(tilemap, 24,53,1,1,8,16);
		SetTileProp(tilemap, 24,54,0,1,4,12);
		SetTileProp(tilemap, 24,55,0,1,8,16);
		SetTileProp(tilemap, 24,56,0,1,4,21);
		SetTileProp(tilemap, 24,57,0,1,0,0);
		SetTileProp(tilemap, 24,58,0,1,0,0);
		SetTileProp(tilemap, 24,59,0,1,0,0);
		SetTileProp(tilemap, 24,60,0,1,0,0);
		SetTileProp(tilemap, 24,61,0,1,0,0);
		SetTileProp(tilemap, 24,62,0,1,0,0);
		SetTileProp(tilemap, 25,0,0,1,0,0);
		SetTileProp(tilemap, 25,1,0,1,0,0);
		SetTileProp(tilemap, 25,2,0,1,8,16);
		SetTileProp(tilemap, 25,3,0,1,8,16);
		SetTileProp(tilemap, 25,4,0,1,8,16);
		SetTileProp(tilemap, 25,5,0,1,8,16);
		SetTileProp(tilemap, 25,6,0,1,8,16);
		SetTileProp(tilemap, 25,7,0,1,8,16);
		SetTileProp(tilemap, 25,8,0,1,4,0);
		SetTileProp(tilemap, 25,9,0,1,8,16);
		SetTileProp(tilemap, 25,10,0,1,8,16);
		SetTileProp(tilemap, 25,11,0,1,8,16);
		SetTileProp(tilemap, 25,12,6,1,8,16);
		SetTileProp(tilemap, 25,13,6,1,8,12);
		SetTileProp(tilemap, 25,14,0,1,8,8);
		SetTileProp(tilemap, 25,15,1,1,8,16);
		SetTileProp(tilemap, 25,16,1,1,8,16);
		SetTileProp(tilemap, 25,17,16,1,4,21);
		SetTileProp(tilemap, 25,18,9,1,4,21);
		SetTileProp(tilemap, 25,19,9,1,4,21);
		SetTileProp(tilemap, 25,20,0,1,4,13);
		SetTileProp(tilemap, 25,21,0,1,4,13);
		SetTileProp(tilemap, 25,22,0,1,4,13);
		SetTileProp(tilemap, 25,23,0,1,4,13);
		SetTileProp(tilemap, 25,24,4,1,4,20);
		SetTileProp(tilemap, 25,25,1,1,4,20);
		SetTileProp(tilemap, 25,26,1,1,4,13);
		SetTileProp(tilemap, 25,27,6,1,4,13);
		SetTileProp(tilemap, 25,28,0,1,8,8);
		SetTileProp(tilemap, 25,29,7,1,8,8);
		SetTileProp(tilemap, 25,30,1,1,8,8);
		SetTileProp(tilemap, 25,31,6,1,8,8);
		SetTileProp(tilemap, 25,32,1,1,0,24);
		SetTileProp(tilemap, 25,33,7,1,0,24);
		SetTileProp(tilemap, 25,34,0,1,16,8);
		SetTileProp(tilemap, 25,35,0,1,16,8);
		SetTileProp(tilemap, 25,36,0,1,4,8);
		SetTileProp(tilemap, 25,37,1,1,16,8);
		SetTileProp(tilemap, 25,38,7,1,16,8);
		SetTileProp(tilemap, 25,39,0,1,4,8);
		SetTileProp(tilemap, 25,40,4,1,16,8);
		SetTileProp(tilemap, 25,41,1,1,16,8);
		SetTileProp(tilemap, 25,42,1,1,16,8);
		SetTileProp(tilemap, 25,43,1,1,16,8);
		SetTileProp(tilemap, 25,44,0,1,0,24);
		SetTileProp(tilemap, 25,45,1,1,0,24);
		SetTileProp(tilemap, 25,46,2,1,0,24);
		SetTileProp(tilemap, 25,47,1,1,16,8);
		SetTileProp(tilemap, 25,48,3,1,15,8);
		SetTileProp(tilemap, 25,49,1,1,12,12);
		SetTileProp(tilemap, 25,50,3,1,12,12);
		SetTileProp(tilemap, 25,51,1,1,8,24);
		SetTileProp(tilemap, 25,52,0,1,8,8);
		SetTileProp(tilemap, 25,53,0,1,8,8);
		SetTileProp(tilemap, 25,54,0,1,4,12);
		SetTileProp(tilemap, 25,55,0,1,8,16);
		SetTileProp(tilemap, 25,56,0,1,4,21);
		SetTileProp(tilemap, 25,57,0,1,0,0);
		SetTileProp(tilemap, 25,58,0,1,0,0);
		SetTileProp(tilemap, 25,59,0,1,0,0);
		SetTileProp(tilemap, 25,60,0,1,0,0);
		SetTileProp(tilemap, 25,61,0,1,0,0);
		SetTileProp(tilemap, 25,62,0,1,0,0);
		SetTileProp(tilemap, 26,0,0,1,0,0);
		SetTileProp(tilemap, 26,1,0,1,0,0);
		SetTileProp(tilemap, 26,2,0,1,0,0);
		SetTileProp(tilemap, 26,3,0,1,0,0);
		SetTileProp(tilemap, 26,4,0,1,0,0);
		SetTileProp(tilemap, 26,5,0,1,0,0);
		SetTileProp(tilemap, 26,6,0,1,0,0);
		SetTileProp(tilemap, 26,7,0,1,8,16);
		SetTileProp(tilemap, 26,8,1,1,0,0);
		SetTileProp(tilemap, 26,9,0,1,8,16);
		SetTileProp(tilemap, 26,10,1,1,8,16);
		SetTileProp(tilemap, 26,11,1,1,8,16);
		SetTileProp(tilemap, 26,12,6,1,8,16);
		SetTileProp(tilemap, 26,13,6,1,8,12);
		SetTileProp(tilemap, 26,14,0,1,8,8);
		SetTileProp(tilemap, 26,15,0,1,0,0);
		SetTileProp(tilemap, 26,16,0,1,8,12);
		SetTileProp(tilemap, 26,17,2,1,8,8);
		SetTileProp(tilemap, 26,18,0,1,8,8);
		SetTileProp(tilemap, 26,19,0,1,8,8);
		SetTileProp(tilemap, 26,20,6,1,4,20);
		SetTileProp(tilemap, 26,21,1,1,4,20);
		SetTileProp(tilemap, 26,22,8,1,4,13);
		SetTileProp(tilemap, 26,23,8,1,4,13);
		SetTileProp(tilemap, 26,24,1,1,4,20);
		SetTileProp(tilemap, 26,25,1,1,4,20);
		SetTileProp(tilemap, 26,26,1,1,4,20);
		SetTileProp(tilemap, 26,27,6,1,4,20);
		SetTileProp(tilemap, 26,28,0,1,8,8);
		SetTileProp(tilemap, 26,29,7,1,8,8);
		SetTileProp(tilemap, 26,30,1,1,8,8);
		SetTileProp(tilemap, 26,31,6,1,8,8);
		SetTileProp(tilemap, 26,32,0,1,8,8);
		SetTileProp(tilemap, 26,33,0,1,8,8);
		SetTileProp(tilemap, 26,34,0,1,16,8);
		SetTileProp(tilemap, 26,35,1,1,16,8);
		SetTileProp(tilemap, 26,36,1,1,16,8);
		SetTileProp(tilemap, 26,37,1,1,16,8);
		SetTileProp(tilemap, 26,38,7,1,16,8);
		SetTileProp(tilemap, 26,39,0,1,4,8);
		SetTileProp(tilemap, 26,40,1,1,16,8);
		SetTileProp(tilemap, 26,41,1,1,0,8);
		SetTileProp(tilemap, 26,42,1,1,0,8);
		SetTileProp(tilemap, 26,43,1,1,16,8);
		SetTileProp(tilemap, 26,44,4,1,0,24);
		SetTileProp(tilemap, 26,45,1,1,0,24);
		SetTileProp(tilemap, 26,46,4,1,15,8);
		SetTileProp(tilemap, 26,47,1,1,16,8);
		SetTileProp(tilemap, 26,48,5,1,12,12);
		SetTileProp(tilemap, 26,49,1,1,12,12);
		SetTileProp(tilemap, 26,50,0,1,19,5);
		SetTileProp(tilemap, 26,51,1,1,8,8);
		SetTileProp(tilemap, 26,52,1,1,8,8);
		SetTileProp(tilemap, 26,53,6,1,8,8);
		SetTileProp(tilemap, 26,54,0,1,4,12);
		SetTileProp(tilemap, 26,55,0,1,8,16);
		SetTileProp(tilemap, 26,56,0,1,4,21);
		SetTileProp(tilemap, 26,57,0,1,0,0);
		SetTileProp(tilemap, 26,58,0,1,0,0);
		SetTileProp(tilemap, 26,59,0,1,0,0);
		SetTileProp(tilemap, 26,60,0,1,0,0);
		SetTileProp(tilemap, 26,61,0,1,0,0);
		SetTileProp(tilemap, 26,62,0,1,0,0);
		SetTileProp(tilemap, 27,0,0,1,0,0);
		SetTileProp(tilemap, 27,1,0,1,0,0);
		SetTileProp(tilemap, 27,2,0,1,0,0);
		SetTileProp(tilemap, 27,3,0,1,0,0);
		SetTileProp(tilemap, 27,4,0,1,0,0);
		SetTileProp(tilemap, 27,5,0,1,0,0);
		SetTileProp(tilemap, 27,6,0,1,0,0);
		SetTileProp(tilemap, 27,7,0,1,8,16);
		SetTileProp(tilemap, 27,8,1,1,0,0);
		SetTileProp(tilemap, 27,9,7,1,8,16);
		SetTileProp(tilemap, 27,10,1,1,8,16);
		SetTileProp(tilemap, 27,11,1,1,8,16);
		SetTileProp(tilemap, 27,12,6,1,8,16);
		SetTileProp(tilemap, 27,13,6,1,8,12);
		SetTileProp(tilemap, 27,14,0,1,8,8);
		SetTileProp(tilemap, 27,15,4,1,8,8);
		SetTileProp(tilemap, 27,16,1,1,8,8);
		SetTileProp(tilemap, 27,17,1,1,8,8);
		SetTileProp(tilemap, 27,18,1,1,8,8);
		SetTileProp(tilemap, 27,19,1,1,8,8);
		SetTileProp(tilemap, 27,20,0,1,24,0);
		SetTileProp(tilemap, 27,21,9,1,11,13);
		SetTileProp(tilemap, 27,22,8,1,4,13);
		SetTileProp(tilemap, 27,23,8,1,4,13);
		SetTileProp(tilemap, 27,24,9,1,11,13);
		SetTileProp(tilemap, 27,25,0,1,4,13);
		SetTileProp(tilemap, 27,26,0,1,4,13);
		SetTileProp(tilemap, 27,27,4,1,8,8);
		SetTileProp(tilemap, 27,28,9,1,8,8);
		SetTileProp(tilemap, 27,29,1,1,8,8);
		SetTileProp(tilemap, 27,30,1,1,8,8);
		SetTileProp(tilemap, 27,31,0,1,8,8);
		SetTileProp(tilemap, 27,32,9,1,8,8);
		SetTileProp(tilemap, 27,33,9,1,8,8);
		SetTileProp(tilemap, 27,34,9,1,8,8);
		SetTileProp(tilemap, 27,35,0,1,10,10);
		SetTileProp(tilemap, 27,36,0,1,4,16);
		SetTileProp(tilemap, 27,37,1,1,16,8);
		SetTileProp(tilemap, 27,38,7,1,16,8);
		SetTileProp(tilemap, 27,39,0,1,4,8);
		SetTileProp(tilemap, 27,40,1,1,0,24);
		SetTileProp(tilemap, 27,41,1,1,0,8);
		SetTileProp(tilemap, 27,42,1,1,0,8);
		SetTileProp(tilemap, 27,43,1,1,0,24);
		SetTileProp(tilemap, 27,44,2,1,0,24);
		SetTileProp(tilemap, 27,45,1,1,0,24);
		SetTileProp(tilemap, 27,46,2,1,0,24);
		SetTileProp(tilemap, 27,47,1,1,16,8);
		SetTileProp(tilemap, 27,48,7,1,12,8);
		SetTileProp(tilemap, 27,49,1,1,12,8);
		SetTileProp(tilemap, 27,50,7,1,10,8);
		SetTileProp(tilemap, 27,51,7,1,8,8);
		SetTileProp(tilemap, 27,52,1,1,8,8);
		SetTileProp(tilemap, 27,53,6,1,8,8);
		SetTileProp(tilemap, 27,54,0,1,4,12);
		SetTileProp(tilemap, 27,55,0,1,8,16);
		SetTileProp(tilemap, 27,56,0,1,4,21);
		SetTileProp(tilemap, 27,57,0,1,0,0);
		SetTileProp(tilemap, 27,58,0,1,0,0);
		SetTileProp(tilemap, 27,59,0,1,0,0);
		SetTileProp(tilemap, 27,60,0,1,0,0);
		SetTileProp(tilemap, 27,61,0,1,0,0);
		SetTileProp(tilemap, 27,62,0,1,0,0);
		SetTileProp(tilemap, 28,0,0,1,0,0);
		SetTileProp(tilemap, 28,1,0,1,0,0);
		SetTileProp(tilemap, 28,2,0,1,0,0);
		SetTileProp(tilemap, 28,3,0,1,0,0);
		SetTileProp(tilemap, 28,4,0,1,0,0);
		SetTileProp(tilemap, 28,5,0,1,0,0);
		SetTileProp(tilemap, 28,6,0,1,0,0);
		SetTileProp(tilemap, 28,7,0,1,8,16);
		SetTileProp(tilemap, 28,8,1,1,0,0);
		SetTileProp(tilemap, 28,9,7,1,8,16);
		SetTileProp(tilemap, 28,10,1,1,8,16);
		SetTileProp(tilemap, 28,11,1,1,8,16);
		SetTileProp(tilemap, 28,12,1,1,8,16);
		SetTileProp(tilemap, 28,13,6,1,8,12);
		SetTileProp(tilemap, 28,14,4,1,8,8);
		SetTileProp(tilemap, 28,15,1,1,8,8);
		SetTileProp(tilemap, 28,16,1,1,8,8);
		SetTileProp(tilemap, 28,17,1,1,8,8);
		SetTileProp(tilemap, 28,18,1,1,8,8);
		SetTileProp(tilemap, 28,19,1,1,8,8);
		SetTileProp(tilemap, 28,20,0,1,24,0);
		SetTileProp(tilemap, 28,21,1,1,11,13);
		SetTileProp(tilemap, 28,22,8,1,8,13);
		SetTileProp(tilemap, 28,23,8,1,8,13);
		SetTileProp(tilemap, 28,24,1,1,11,13);
		SetTileProp(tilemap, 28,25,0,1,4,13);
		SetTileProp(tilemap, 28,26,1,1,8,16);
		SetTileProp(tilemap, 28,27,1,1,8,8);
		SetTileProp(tilemap, 28,28,1,1,8,8);
		SetTileProp(tilemap, 28,29,1,1,8,8);
		SetTileProp(tilemap, 28,30,1,1,8,13);
		SetTileProp(tilemap, 28,31,1,1,8,8);
		SetTileProp(tilemap, 28,32,1,1,8,8);
		SetTileProp(tilemap, 28,33,1,1,8,8);
		SetTileProp(tilemap, 28,34,1,1,8,8);
		SetTileProp(tilemap, 28,35,6,1,8,8);
		SetTileProp(tilemap, 28,36,0,1,4,16);
		SetTileProp(tilemap, 28,37,1,1,16,8);
		SetTileProp(tilemap, 28,38,7,1,16,8);
		SetTileProp(tilemap, 28,39,1,1,0,24);
		SetTileProp(tilemap, 28,40,2,1,0,24);
		SetTileProp(tilemap, 28,41,1,1,16,8);
		SetTileProp(tilemap, 28,42,1,1,16,8);
		SetTileProp(tilemap, 28,43,1,1,0,24);
		SetTileProp(tilemap, 28,44,1,1,0,24);
		SetTileProp(tilemap, 28,45,1,1,0,24);
		SetTileProp(tilemap, 28,46,4,1,16,8);
		SetTileProp(tilemap, 28,47,1,1,16,8);
		SetTileProp(tilemap, 28,48,2,1,16,8);
		SetTileProp(tilemap, 28,49,0,1,4,16);
		SetTileProp(tilemap, 28,50,0,1,4,16);
		SetTileProp(tilemap, 28,51,0,1,4,16);
		SetTileProp(tilemap, 28,52,1,1,8,8);
		SetTileProp(tilemap, 28,53,6,1,8,8);
		SetTileProp(tilemap, 28,54,0,1,4,16);
		SetTileProp(tilemap, 28,55,0,1,8,16);
		SetTileProp(tilemap, 28,56,0,1,4,21);
		SetTileProp(tilemap, 28,57,0,1,0,0);
		SetTileProp(tilemap, 28,58,0,1,0,0);
		SetTileProp(tilemap, 28,59,0,1,0,0);
		SetTileProp(tilemap, 28,60,0,1,0,0);
		SetTileProp(tilemap, 28,61,0,1,0,0);
		SetTileProp(tilemap, 28,62,0,1,0,0);
		SetTileProp(tilemap, 29,0,0,1,0,0);
		SetTileProp(tilemap, 29,1,0,1,0,0);
		SetTileProp(tilemap, 29,2,0,1,0,0);
		SetTileProp(tilemap, 29,3,0,1,0,0);
		SetTileProp(tilemap, 29,4,0,1,0,0);
		SetTileProp(tilemap, 29,5,0,1,0,0);
		SetTileProp(tilemap, 29,6,0,1,0,0);
		SetTileProp(tilemap, 29,7,0,1,8,16);
		SetTileProp(tilemap, 29,8,1,1,0,0);
		SetTileProp(tilemap, 29,9,0,1,8,16);
		SetTileProp(tilemap, 29,10,1,1,8,16);
		SetTileProp(tilemap, 29,11,1,1,8,16);
		SetTileProp(tilemap, 29,12,6,1,8,16);
		SetTileProp(tilemap, 29,13,6,1,8,12);
		SetTileProp(tilemap, 29,14,0,1,8,8);
		SetTileProp(tilemap, 29,15,0,1,8,8);
		SetTileProp(tilemap, 29,16,1,1,8,8);
		SetTileProp(tilemap, 29,17,1,1,8,8);
		SetTileProp(tilemap, 29,18,1,1,8,8);
		SetTileProp(tilemap, 29,19,1,1,8,8);
		SetTileProp(tilemap, 29,20,0,1,24,0);
		SetTileProp(tilemap, 29,21,0,1,11,13);
		SetTileProp(tilemap, 29,22,1,1,11,13);
		SetTileProp(tilemap, 29,23,1,1,11,13);
		SetTileProp(tilemap, 29,24,0,1,11,13);
		SetTileProp(tilemap, 29,25,0,1,4,13);
		SetTileProp(tilemap, 29,26,0,1,8,8);
		SetTileProp(tilemap, 29,27,1,1,8,8);
		SetTileProp(tilemap, 29,28,0,1,8,8);
		SetTileProp(tilemap, 29,29,8,1,8,8);
		SetTileProp(tilemap, 29,30,8,1,8,8);
		SetTileProp(tilemap, 29,31,8,1,8,8);
		SetTileProp(tilemap, 29,32,1,1,12,12);
		SetTileProp(tilemap, 29,33,0,1,8,8);
		SetTileProp(tilemap, 29,34,1,1,8,8);
		SetTileProp(tilemap, 29,35,6,1,8,8);
		SetTileProp(tilemap, 29,36,0,1,4,16);
		SetTileProp(tilemap, 29,37,1,1,0,24);
		SetTileProp(tilemap, 29,38,1,1,0,24);
		SetTileProp(tilemap, 29,39,1,1,0,24);
		SetTileProp(tilemap, 29,40,1,1,0,24);
		SetTileProp(tilemap, 29,41,1,1,16,8);
		SetTileProp(tilemap, 29,42,0,1,4,8);
		SetTileProp(tilemap, 29,43,4,1,16,8);
		SetTileProp(tilemap, 29,44,1,1,16,8);
		SetTileProp(tilemap, 29,45,2,1,16,8);
		SetTileProp(tilemap, 29,46,0,1,4,24);
		SetTileProp(tilemap, 29,47,1,1,16,16);
		SetTileProp(tilemap, 29,48,0,1,4,24);
		SetTileProp(tilemap, 29,49,4,1,4,16);
		SetTileProp(tilemap, 29,50,1,1,0,16);
		SetTileProp(tilemap, 29,51,0,1,4,16);
		SetTileProp(tilemap, 29,52,1,1,8,8);
		SetTileProp(tilemap, 29,53,6,1,8,8);
		SetTileProp(tilemap, 29,54,0,1,4,12);
		SetTileProp(tilemap, 29,55,0,1,8,16);
		SetTileProp(tilemap, 29,56,0,1,4,21);
		SetTileProp(tilemap, 29,57,0,1,0,0);
		SetTileProp(tilemap, 29,58,0,1,0,0);
		SetTileProp(tilemap, 29,59,0,1,0,0);
		SetTileProp(tilemap, 29,60,0,1,0,0);
		SetTileProp(tilemap, 29,61,0,1,0,0);
		SetTileProp(tilemap, 29,62,0,1,0,0);
		SetTileProp(tilemap, 30,0,0,1,0,0);
		SetTileProp(tilemap, 30,1,0,1,0,0);
		SetTileProp(tilemap, 30,2,0,1,0,0);
		SetTileProp(tilemap, 30,3,0,1,0,0);
		SetTileProp(tilemap, 30,4,0,1,0,0);
		SetTileProp(tilemap, 30,5,0,1,0,0);
		SetTileProp(tilemap, 30,6,0,1,0,0);
		SetTileProp(tilemap, 30,7,0,1,8,16);
		SetTileProp(tilemap, 30,8,1,1,0,0);
		SetTileProp(tilemap, 30,9,7,1,8,16);
		SetTileProp(tilemap, 30,10,1,1,8,16);
		SetTileProp(tilemap, 30,11,1,1,8,16);
		SetTileProp(tilemap, 30,12,6,1,8,16);
		SetTileProp(tilemap, 30,13,6,1,8,12);
		SetTileProp(tilemap, 30,14,1,1,8,8);
		SetTileProp(tilemap, 30,15,1,1,8,8);
		SetTileProp(tilemap, 30,16,1,1,8,8);
		SetTileProp(tilemap, 30,17,1,1,8,8);
		SetTileProp(tilemap, 30,18,1,1,8,8);
		SetTileProp(tilemap, 30,19,1,1,8,8);
		SetTileProp(tilemap, 30,20,0,1,24,0);
		SetTileProp(tilemap, 30,21,0,1,11,13);
		SetTileProp(tilemap, 30,22,1,1,11,13);
		SetTileProp(tilemap, 30,23,1,1,11,13);
		SetTileProp(tilemap, 30,24,0,1,11,13);
		SetTileProp(tilemap, 30,25,0,1,4,20);
		SetTileProp(tilemap, 30,26,7,1,8,8);
		SetTileProp(tilemap, 30,27,1,1,8,8);
		SetTileProp(tilemap, 30,28,7,1,8,4);
		SetTileProp(tilemap, 30,29,1,1,0,24);
		SetTileProp(tilemap, 30,30,1,1,0,24);
		SetTileProp(tilemap, 30,31,1,1,0,24);
		SetTileProp(tilemap, 30,32,1,1,0,24);
		SetTileProp(tilemap, 30,33,0,1,4,8);
		SetTileProp(tilemap, 30,34,1,1,8,8);
		SetTileProp(tilemap, 30,35,1,1,0,8);
		SetTileProp(tilemap, 30,36,9,1,8,8);
		SetTileProp(tilemap, 30,37,1,1,0,24);
		SetTileProp(tilemap, 30,38,4,1,8,16);
		SetTileProp(tilemap, 30,39,2,1,8,16);
		SetTileProp(tilemap, 30,40,1,1,8,8);
		SetTileProp(tilemap, 30,41,1,1,8,8);
		SetTileProp(tilemap, 30,42,8,1,6,13);
		SetTileProp(tilemap, 30,43,1,1,16,8);
		SetTileProp(tilemap, 30,44,0,1,16,8);
		SetTileProp(tilemap, 30,45,1,1,16,8);
		SetTileProp(tilemap, 30,46,5,1,16,8);
		SetTileProp(tilemap, 30,47,1,1,16,8);
		SetTileProp(tilemap, 30,48,3,1,16,8);
		SetTileProp(tilemap, 30,49,1,1,0,16);
		SetTileProp(tilemap, 30,50,1,1,0,16);
		SetTileProp(tilemap, 30,51,0,1,4,16);
		SetTileProp(tilemap, 30,52,1,1,8,8);
		SetTileProp(tilemap, 30,53,6,1,8,8);
		SetTileProp(tilemap, 30,54,0,1,4,12);
		SetTileProp(tilemap, 30,55,0,1,8,16);
		SetTileProp(tilemap, 30,56,0,1,4,21);
		SetTileProp(tilemap, 30,57,0,1,0,0);
		SetTileProp(tilemap, 30,58,0,1,0,0);
		SetTileProp(tilemap, 30,59,0,1,0,0);
		SetTileProp(tilemap, 30,60,0,1,0,0);
		SetTileProp(tilemap, 30,61,0,1,0,0);
		SetTileProp(tilemap, 30,62,0,1,0,0);
		SetTileProp(tilemap, 31,0,0,1,0,0);
		SetTileProp(tilemap, 31,1,0,1,0,0);
		SetTileProp(tilemap, 31,2,0,1,0,0);
		SetTileProp(tilemap, 31,3,0,1,0,0);
		SetTileProp(tilemap, 31,4,0,1,0,0);
		SetTileProp(tilemap, 31,5,0,1,0,0);
		SetTileProp(tilemap, 31,6,0,1,0,0);
		SetTileProp(tilemap, 31,7,0,1,8,16);
		SetTileProp(tilemap, 31,8,1,1,0,0);
		SetTileProp(tilemap, 31,9,7,1,8,16);
		SetTileProp(tilemap, 31,10,1,1,8,16);
		SetTileProp(tilemap, 31,11,1,1,8,16);
		SetTileProp(tilemap, 31,12,6,1,8,16);
		SetTileProp(tilemap, 31,13,6,1,8,12);
		SetTileProp(tilemap, 31,14,0,1,8,8);
		SetTileProp(tilemap, 31,15,0,1,8,8);
		SetTileProp(tilemap, 31,16,0,1,8,8);
		SetTileProp(tilemap, 31,17,0,1,8,8);
		SetTileProp(tilemap, 31,18,0,1,8,8);
		SetTileProp(tilemap, 31,19,1,1,8,8);
		SetTileProp(tilemap, 31,20,0,1,8,8);
		SetTileProp(tilemap, 31,21,0,1,8,8);
		SetTileProp(tilemap, 31,22,0,1,8,8);
		SetTileProp(tilemap, 31,23,0,1,8,8);
		SetTileProp(tilemap, 31,24,0,1,4,20);
		SetTileProp(tilemap, 31,25,0,1,8,8);
		SetTileProp(tilemap, 31,26,7,1,8,8);
		SetTileProp(tilemap, 31,27,1,1,8,8);
		SetTileProp(tilemap, 31,28,6,1,8,8);
		SetTileProp(tilemap, 31,29,1,1,0,24);
		SetTileProp(tilemap, 31,30,1,1,0,0);
		SetTileProp(tilemap, 31,31,1,1,0,0);
		SetTileProp(tilemap, 31,32,1,1,0,24);
		SetTileProp(tilemap, 31,33,7,1,8,8);
		SetTileProp(tilemap, 31,34,1,1,8,8);
		SetTileProp(tilemap, 31,35,1,1,0,8);
		SetTileProp(tilemap, 31,36,1,1,0,8);
		SetTileProp(tilemap, 31,37,1,1,0,14);
		SetTileProp(tilemap, 31,38,6,1,8,10);
		SetTileProp(tilemap, 31,39,1,1,8,8);
		SetTileProp(tilemap, 31,40,1,1,8,8);
		SetTileProp(tilemap, 31,41,1,1,7,8);
		SetTileProp(tilemap, 31,42,1,1,6,8);
		SetTileProp(tilemap, 31,43,1,1,16,8);
		SetTileProp(tilemap, 31,44,0,1,4,13);
		SetTileProp(tilemap, 31,45,1,1,16,8);
		SetTileProp(tilemap, 31,46,1,1,16,8);
		SetTileProp(tilemap, 31,47,1,1,16,8);
		SetTileProp(tilemap, 31,48,0,1,4,8);
		SetTileProp(tilemap, 31,49,0,1,4,8);
		SetTileProp(tilemap, 31,50,1,1,0,24);
		SetTileProp(tilemap, 31,51,1,1,0,24);
		SetTileProp(tilemap, 31,52,1,1,0,24);
		SetTileProp(tilemap, 31,53,1,1,0,24);
		SetTileProp(tilemap, 31,54,1,1,0,24);
		SetTileProp(tilemap, 31,55,0,1,8,16);
		SetTileProp(tilemap, 31,56,0,1,4,21);
		SetTileProp(tilemap, 31,57,0,1,0,0);
		SetTileProp(tilemap, 31,58,0,1,0,0);
		SetTileProp(tilemap, 31,59,0,1,0,0);
		SetTileProp(tilemap, 31,60,0,1,0,0);
		SetTileProp(tilemap, 31,61,0,1,0,0);
		SetTileProp(tilemap, 31,62,0,1,0,0);
		SetTileProp(tilemap, 32,0,0,1,0,0);
		SetTileProp(tilemap, 32,1,0,1,4,0);
		SetTileProp(tilemap, 32,2,0,1,4,0);
		SetTileProp(tilemap, 32,3,0,1,4,0);
		SetTileProp(tilemap, 32,4,0,1,4,0);
		SetTileProp(tilemap, 32,5,0,1,4,0);
		SetTileProp(tilemap, 32,6,0,1,4,0);
		SetTileProp(tilemap, 32,7,0,1,8,16);
		SetTileProp(tilemap, 32,8,1,1,0,0);
		SetTileProp(tilemap, 32,9,0,1,4,16);
		SetTileProp(tilemap, 32,10,1,1,8,16);
		SetTileProp(tilemap, 32,11,0,1,4,16);
		SetTileProp(tilemap, 32,12,0,1,4,24);
		SetTileProp(tilemap, 32,13,0,1,8,16);
		SetTileProp(tilemap, 32,14,0,1,4,8);
		SetTileProp(tilemap, 32,15,1,1,24,0);
		SetTileProp(tilemap, 32,16,1,1,24,0);
		SetTileProp(tilemap, 32,17,1,1,7,0);
		SetTileProp(tilemap, 32,18,1,1,7,0);
		SetTileProp(tilemap, 32,19,1,1,8,8);
		SetTileProp(tilemap, 32,20,9,1,8,8);
		SetTileProp(tilemap, 32,21,9,1,8,8);
		SetTileProp(tilemap, 32,22,9,1,8,8);
		SetTileProp(tilemap, 32,23,9,1,8,8);
		SetTileProp(tilemap, 32,24,9,1,8,8);
		SetTileProp(tilemap, 32,25,7,1,8,12);
		SetTileProp(tilemap, 32,26,1,1,8,8);
		SetTileProp(tilemap, 32,27,1,1,8,8);
		SetTileProp(tilemap, 32,28,6,1,8,8);
		SetTileProp(tilemap, 32,29,1,1,0,24);
		SetTileProp(tilemap, 32,30,1,1,0,0);
		SetTileProp(tilemap, 32,31,1,1,0,0);
		SetTileProp(tilemap, 32,32,1,1,0,24);
		SetTileProp(tilemap, 32,33,7,1,8,8);
		SetTileProp(tilemap, 32,34,1,1,8,8);
		SetTileProp(tilemap, 32,35,1,1,8,8);
		SetTileProp(tilemap, 32,36,8,1,8,8);
		SetTileProp(tilemap, 32,37,3,1,8,8);
		SetTileProp(tilemap, 32,38,5,1,8,16);
		SetTileProp(tilemap, 32,39,1,1,8,8);
		SetTileProp(tilemap, 32,40,0,1,8,16);
		SetTileProp(tilemap, 32,41,1,1,8,8);
		SetTileProp(tilemap, 32,42,8,1,8,10);
		SetTileProp(tilemap, 32,43,0,1,0,16);
		SetTileProp(tilemap, 32,44,6,1,16,9);
		SetTileProp(tilemap, 32,45,1,1,16,8);
		SetTileProp(tilemap, 32,46,1,1,0,24);
		SetTileProp(tilemap, 32,47,1,1,0,24);
		SetTileProp(tilemap, 32,48,1,1,0,24);
		SetTileProp(tilemap, 32,49,1,1,0,24);
		SetTileProp(tilemap, 32,50,1,1,0,24);
		SetTileProp(tilemap, 32,51,0,1,4,16);
		SetTileProp(tilemap, 32,52,1,1,0,24);
		SetTileProp(tilemap, 32,53,1,1,0,24);
		SetTileProp(tilemap, 32,54,1,1,0,24);
		SetTileProp(tilemap, 32,55,0,1,8,16);
		SetTileProp(tilemap, 32,56,0,1,4,21);
		SetTileProp(tilemap, 32,57,0,1,0,0);
		SetTileProp(tilemap, 32,58,0,1,4,0);
		SetTileProp(tilemap, 32,59,0,1,0,0);
		SetTileProp(tilemap, 32,60,0,1,0,0);
		SetTileProp(tilemap, 32,61,0,1,0,0);
		SetTileProp(tilemap, 32,62,0,1,0,0);
		SetTileProp(tilemap, 33,0,0,1,0,0);
		SetTileProp(tilemap, 33,1,0,1,4,0);
		SetTileProp(tilemap, 33,2,0,1,4,0);
		SetTileProp(tilemap, 33,3,0,1,4,0);
		SetTileProp(tilemap, 33,4,0,1,4,0);
		SetTileProp(tilemap, 33,5,0,1,4,0);
		SetTileProp(tilemap, 33,6,0,1,4,0);
		SetTileProp(tilemap, 33,7,0,1,8,16);
		SetTileProp(tilemap, 33,8,1,1,0,0);
		SetTileProp(tilemap, 33,9,7,1,8,16);
		SetTileProp(tilemap, 33,10,1,1,8,16);
		SetTileProp(tilemap, 33,11,1,1,8,16);
		SetTileProp(tilemap, 33,12,1,1,8,16);
		SetTileProp(tilemap, 33,13,1,1,8,16);
		SetTileProp(tilemap, 33,14,0,1,4,8);
		SetTileProp(tilemap, 33,15,1,1,24,0);
		SetTileProp(tilemap, 33,16,1,1,24,0);
		SetTileProp(tilemap, 33,17,0,1,4,8);
		SetTileProp(tilemap, 33,18,1,1,7,16);
		SetTileProp(tilemap, 33,19,1,1,8,8);
		SetTileProp(tilemap, 33,20,1,1,8,8);
		SetTileProp(tilemap, 33,21,1,1,8,8);
		SetTileProp(tilemap, 33,22,1,1,8,8);
		SetTileProp(tilemap, 33,23,1,1,8,8);
		SetTileProp(tilemap, 33,24,1,1,8,8);
		SetTileProp(tilemap, 33,25,7,1,8,12);
		SetTileProp(tilemap, 33,26,1,1,8,8);
		SetTileProp(tilemap, 33,27,1,1,8,8);
		SetTileProp(tilemap, 33,28,6,1,8,8);
		SetTileProp(tilemap, 33,29,1,1,2,24);
		SetTileProp(tilemap, 33,30,1,1,0,24);
		SetTileProp(tilemap, 33,31,1,1,0,24);
		SetTileProp(tilemap, 33,32,1,1,0,24);
		SetTileProp(tilemap, 33,33,7,1,8,8);
		SetTileProp(tilemap, 33,34,1,1,8,8);
		SetTileProp(tilemap, 33,35,6,1,8,8);
		SetTileProp(tilemap, 33,36,0,1,8,8);
		SetTileProp(tilemap, 33,37,0,1,8,8);
		SetTileProp(tilemap, 33,38,0,1,4,16);
		SetTileProp(tilemap, 33,39,1,1,0,24);
		SetTileProp(tilemap, 33,40,1,1,8,16);
		SetTileProp(tilemap, 33,41,1,1,8,16);
		SetTileProp(tilemap, 33,42,0,1,8,16);
		SetTileProp(tilemap, 33,43,0,1,8,16);
		SetTileProp(tilemap, 33,44,0,1,4,12);
		SetTileProp(tilemap, 33,45,1,1,16,8);
		SetTileProp(tilemap, 33,46,1,1,0,24);
		SetTileProp(tilemap, 33,47,0,1,4,8);
		SetTileProp(tilemap, 33,48,9,1,0,0);
		SetTileProp(tilemap, 33,49,9,1,0,0);
		SetTileProp(tilemap, 33,50,0,1,4,8);
		SetTileProp(tilemap, 33,51,0,1,4,16);
		SetTileProp(tilemap, 33,52,8,1,0,24);
		SetTileProp(tilemap, 33,53,1,1,0,24);
		SetTileProp(tilemap, 33,54,8,1,0,24);
		SetTileProp(tilemap, 33,55,0,1,8,16);
		SetTileProp(tilemap, 33,56,0,1,4,21);
		SetTileProp(tilemap, 33,57,0,1,4,0);
		SetTileProp(tilemap, 33,58,0,1,0,0);
		SetTileProp(tilemap, 33,59,0,1,4,0);
		SetTileProp(tilemap, 33,60,0,1,0,0);
		SetTileProp(tilemap, 33,61,0,1,0,0);
		SetTileProp(tilemap, 33,62,0,1,0,0);
		SetTileProp(tilemap, 34,0,0,1,0,0);
		SetTileProp(tilemap, 34,1,0,1,0,0);
		SetTileProp(tilemap, 34,2,0,1,0,0);
		SetTileProp(tilemap, 34,3,0,1,0,0);
		SetTileProp(tilemap, 34,4,0,1,0,0);
		SetTileProp(tilemap, 34,5,0,1,0,0);
		SetTileProp(tilemap, 34,6,0,1,0,0);
		SetTileProp(tilemap, 34,7,0,1,8,16);
		SetTileProp(tilemap, 34,8,1,1,0,0);
		SetTileProp(tilemap, 34,9,7,1,8,16);
		SetTileProp(tilemap, 34,10,1,1,8,16);
		SetTileProp(tilemap, 34,11,1,1,8,16);
		SetTileProp(tilemap, 34,12,1,1,8,16);
		SetTileProp(tilemap, 34,13,1,1,8,16);
		SetTileProp(tilemap, 34,14,1,1,8,16);
		SetTileProp(tilemap, 34,15,1,1,8,16);
		SetTileProp(tilemap, 34,16,0,1,4,13);
		SetTileProp(tilemap, 34,17,0,1,4,8);
		SetTileProp(tilemap, 34,18,1,1,7,16);
		SetTileProp(tilemap, 34,19,1,1,8,8);
		SetTileProp(tilemap, 34,20,8,1,8,8);
		SetTileProp(tilemap, 34,21,8,1,8,8);
		SetTileProp(tilemap, 34,22,8,1,8,8);
		SetTileProp(tilemap, 34,23,9,1,8,8);
		SetTileProp(tilemap, 34,24,8,1,8,8);
		SetTileProp(tilemap, 34,25,7,1,8,12);
		SetTileProp(tilemap, 34,26,1,1,8,8);
		SetTileProp(tilemap, 34,27,1,1,8,8);
		SetTileProp(tilemap, 34,28,1,1,8,8);
		SetTileProp(tilemap, 34,29,0,1,0,24);
		SetTileProp(tilemap, 34,30,9,1,8,8);
		SetTileProp(tilemap, 34,31,1,1,12,12);
		SetTileProp(tilemap, 34,32,9,1,8,8);
		SetTileProp(tilemap, 34,33,0,1,8,8);
		SetTileProp(tilemap, 34,34,1,1,8,0);
		SetTileProp(tilemap, 34,35,6,1,8,0);
		SetTileProp(tilemap, 34,36,1,1,24,0);
		SetTileProp(tilemap, 34,37,0,1,24,0);
		SetTileProp(tilemap, 34,38,1,1,24,0);
		SetTileProp(tilemap, 34,39,1,1,24,0);
		SetTileProp(tilemap, 34,40,0,1,8,16);
		SetTileProp(tilemap, 34,41,1,1,8,16);
		SetTileProp(tilemap, 34,42,0,1,8,16);
		SetTileProp(tilemap, 34,43,0,1,8,16);
		SetTileProp(tilemap, 34,44,6,1,16,9);
		SetTileProp(tilemap, 34,45,1,1,16,8);
		SetTileProp(tilemap, 34,46,1,1,0,24);
		SetTileProp(tilemap, 34,47,1,1,0,0);
		SetTileProp(tilemap, 34,48,1,1,0,0);
		SetTileProp(tilemap, 34,49,1,1,0,0);
		SetTileProp(tilemap, 34,50,6,1,0,0);
		SetTileProp(tilemap, 34,51,0,1,4,16);
		SetTileProp(tilemap, 34,52,0,1,4,16);
		SetTileProp(tilemap, 34,53,0,1,4,16);
		SetTileProp(tilemap, 34,54,0,1,8,16);
		SetTileProp(tilemap, 34,55,0,1,8,16);
		SetTileProp(tilemap, 34,56,0,1,4,21);
		SetTileProp(tilemap, 34,57,0,1,4,0);
		SetTileProp(tilemap, 34,58,0,1,0,0);
		SetTileProp(tilemap, 34,59,0,1,4,0);
		SetTileProp(tilemap, 34,60,0,1,0,0);
		SetTileProp(tilemap, 34,61,0,1,0,0);
		SetTileProp(tilemap, 34,62,0,1,0,0);
		SetTileProp(tilemap, 35,0,0,1,0,0);
		SetTileProp(tilemap, 35,1,0,1,0,0);
		SetTileProp(tilemap, 35,2,0,1,0,0);
		SetTileProp(tilemap, 35,3,0,1,0,0);
		SetTileProp(tilemap, 35,4,0,1,0,0);
		SetTileProp(tilemap, 35,5,0,1,0,0);
		SetTileProp(tilemap, 35,6,0,1,0,0);
		SetTileProp(tilemap, 35,7,0,1,8,16);
		SetTileProp(tilemap, 35,8,1,1,0,0);
		SetTileProp(tilemap, 35,9,0,1,8,16);
		SetTileProp(tilemap, 35,10,1,1,8,16);
		SetTileProp(tilemap, 35,11,1,1,8,16);
		SetTileProp(tilemap, 35,12,1,1,8,16);
		SetTileProp(tilemap, 35,13,0,1,4,16);
		SetTileProp(tilemap, 35,14,1,1,8,16);
		SetTileProp(tilemap, 35,15,1,1,8,16);
		SetTileProp(tilemap, 35,16,0,1,4,13);
		SetTileProp(tilemap, 35,17,0,1,4,8);
		SetTileProp(tilemap, 35,18,0,1,8,16);
		SetTileProp(tilemap, 35,19,1,1,8,16);
		SetTileProp(tilemap, 35,20,0,1,8,8);
		SetTileProp(tilemap, 35,21,0,1,8,8);
		SetTileProp(tilemap, 35,22,0,1,8,8);
		SetTileProp(tilemap, 35,23,9,1,8,12);
		SetTileProp(tilemap, 35,24,0,1,8,8);
		SetTileProp(tilemap, 35,25,0,1,8,8);
		SetTileProp(tilemap, 35,26,0,1,8,8);
		SetTileProp(tilemap, 35,27,1,1,8,8);
		SetTileProp(tilemap, 35,28,1,1,8,8);
		SetTileProp(tilemap, 35,29,0,1,0,24);
		SetTileProp(tilemap, 35,30,1,1,8,8);
		SetTileProp(tilemap, 35,31,1,1,8,8);
		SetTileProp(tilemap, 35,32,1,1,8,8);
		SetTileProp(tilemap, 35,33,1,1,8,8);
		SetTileProp(tilemap, 35,34,1,1,8,0);
		SetTileProp(tilemap, 35,35,6,1,8,0);
		SetTileProp(tilemap, 35,36,1,1,24,0);
		SetTileProp(tilemap, 35,37,1,1,24,0);
		SetTileProp(tilemap, 35,38,1,1,24,0);
		SetTileProp(tilemap, 35,39,8,1,27,0);
		SetTileProp(tilemap, 35,40,0,1,8,16);
		SetTileProp(tilemap, 35,41,1,1,7,16);
		SetTileProp(tilemap, 35,42,1,1,8,16);
		SetTileProp(tilemap, 35,43,0,1,8,16);
		SetTileProp(tilemap, 35,44,0,1,4,12);
		SetTileProp(tilemap, 35,45,1,1,16,8);
		SetTileProp(tilemap, 35,46,1,1,16,8);
		SetTileProp(tilemap, 35,47,1,1,0,7);
		SetTileProp(tilemap, 35,48,1,1,0,0);
		SetTileProp(tilemap, 35,49,1,1,16,0);
		SetTileProp(tilemap, 35,50,1,1,0,0);
		SetTileProp(tilemap, 35,51,0,1,4,16);
		SetTileProp(tilemap, 35,52,0,1,4,21);
		SetTileProp(tilemap, 35,53,0,1,4,21);
		SetTileProp(tilemap, 35,54,0,1,4,21);
		SetTileProp(tilemap, 35,55,0,1,4,21);
		SetTileProp(tilemap, 35,56,0,1,4,21);
		SetTileProp(tilemap, 35,57,0,1,0,0);
		SetTileProp(tilemap, 35,58,0,1,0,0);
		SetTileProp(tilemap, 35,59,0,1,0,0);
		SetTileProp(tilemap, 35,60,0,1,0,0);
		SetTileProp(tilemap, 35,61,0,1,0,0);
		SetTileProp(tilemap, 35,62,0,1,0,0);
		SetTileProp(tilemap, 36,0,0,1,0,0);
		SetTileProp(tilemap, 36,1,0,1,0,0);
		SetTileProp(tilemap, 36,2,0,1,0,0);
		SetTileProp(tilemap, 36,3,0,1,0,0);
		SetTileProp(tilemap, 36,4,0,1,0,0);
		SetTileProp(tilemap, 36,5,0,1,0,0);
		SetTileProp(tilemap, 36,6,0,1,0,0);
		SetTileProp(tilemap, 36,7,0,1,8,16);
		SetTileProp(tilemap, 36,8,1,1,0,0);
		SetTileProp(tilemap, 36,9,7,1,8,16);
		SetTileProp(tilemap, 36,10,1,1,8,16);
		SetTileProp(tilemap, 36,11,1,1,8,16);
		SetTileProp(tilemap, 36,12,1,1,8,16);
		SetTileProp(tilemap, 36,13,1,1,8,16);
		SetTileProp(tilemap, 36,14,2,1,8,16);
		SetTileProp(tilemap, 36,15,0,1,4,13);
		SetTileProp(tilemap, 36,16,2,1,8,13);
		SetTileProp(tilemap, 36,17,0,1,4,8);
		SetTileProp(tilemap, 36,18,0,1,8,8);
		SetTileProp(tilemap, 36,19,1,1,8,8);
		SetTileProp(tilemap, 36,20,1,1,8,8);
		SetTileProp(tilemap, 36,21,0,1,8,8);
		SetTileProp(tilemap, 36,22,1,1,8,14);
		SetTileProp(tilemap, 36,23,1,1,8,14);
		SetTileProp(tilemap, 36,24,1,1,8,14);
		SetTileProp(tilemap, 36,25,1,1,8,14);
		SetTileProp(tilemap, 36,26,0,1,10,10);
		SetTileProp(tilemap, 36,27,1,1,8,8);
		SetTileProp(tilemap, 36,28,1,1,8,8);
		SetTileProp(tilemap, 36,29,1,1,8,8);
		SetTileProp(tilemap, 36,30,1,1,8,8);
		SetTileProp(tilemap, 36,31,1,1,8,8);
		SetTileProp(tilemap, 36,32,1,1,8,8);
		SetTileProp(tilemap, 36,33,8,1,8,8);
		SetTileProp(tilemap, 36,34,8,1,8,0);
		SetTileProp(tilemap, 36,35,0,1,10,0);
		SetTileProp(tilemap, 36,36,1,1,24,0);
		SetTileProp(tilemap, 36,37,0,1,4,8);
		SetTileProp(tilemap, 36,38,1,1,24,0);
		SetTileProp(tilemap, 36,39,1,1,28,0);
		SetTileProp(tilemap, 36,40,1,1,8,16);
		SetTileProp(tilemap, 36,41,1,1,8,16);
		SetTileProp(tilemap, 36,42,1,1,7,16);
		SetTileProp(tilemap, 36,43,0,1,8,16);
		SetTileProp(tilemap, 36,44,0,1,8,17);
		SetTileProp(tilemap, 36,45,5,1,16,8);
		SetTileProp(tilemap, 36,46,1,1,16,8);
		SetTileProp(tilemap, 36,47,0,1,4,16);
		SetTileProp(tilemap, 36,48,1,1,0,0);
		SetTileProp(tilemap, 36,49,1,1,0,0);
		SetTileProp(tilemap, 36,50,1,1,0,24);
		SetTileProp(tilemap, 36,51,0,1,4,21);
		SetTileProp(tilemap, 36,52,0,1,4,21);
		SetTileProp(tilemap, 36,53,0,1,4,21);
		SetTileProp(tilemap, 36,54,0,1,8,16);
		SetTileProp(tilemap, 36,55,0,1,8,16);
		SetTileProp(tilemap, 36,56,0,1,8,16);
		SetTileProp(tilemap, 36,57,0,1,0,0);
		SetTileProp(tilemap, 36,58,0,1,0,0);
		SetTileProp(tilemap, 36,59,0,1,0,0);
		SetTileProp(tilemap, 36,60,0,1,0,0);
		SetTileProp(tilemap, 36,61,0,1,0,0);
		SetTileProp(tilemap, 36,62,0,1,0,0);
		SetTileProp(tilemap, 37,0,0,1,4,0);
		SetTileProp(tilemap, 37,1,0,1,4,0);
		SetTileProp(tilemap, 37,2,0,1,4,0);
		SetTileProp(tilemap, 37,3,0,1,4,0);
		SetTileProp(tilemap, 37,4,0,1,4,0);
		SetTileProp(tilemap, 37,5,0,1,4,0);
		SetTileProp(tilemap, 37,6,0,1,4,0);
		SetTileProp(tilemap, 37,7,0,1,8,16);
		SetTileProp(tilemap, 37,8,1,1,0,0);
		SetTileProp(tilemap, 37,9,7,1,8,16);
		SetTileProp(tilemap, 37,10,1,1,8,16);
		SetTileProp(tilemap, 37,11,1,1,8,16);
		SetTileProp(tilemap, 37,12,0,1,8,16);
		SetTileProp(tilemap, 37,13,5,1,7,16);
		SetTileProp(tilemap, 37,14,1,1,8,16);
		SetTileProp(tilemap, 37,15,1,1,8,16);
		SetTileProp(tilemap, 37,16,1,1,8,16);
		SetTileProp(tilemap, 37,17,2,1,8,8);
		SetTileProp(tilemap, 37,18,1,1,8,8);
		SetTileProp(tilemap, 37,19,1,1,8,8);
		SetTileProp(tilemap, 37,20,1,1,16,8);
		SetTileProp(tilemap, 37,21,0,1,8,8);
		SetTileProp(tilemap, 37,22,1,1,8,14);
		SetTileProp(tilemap, 37,23,1,1,8,14);
		SetTileProp(tilemap, 37,24,1,1,8,14);
		SetTileProp(tilemap, 37,25,1,1,8,14);
		SetTileProp(tilemap, 37,26,0,1,8,8);
		SetTileProp(tilemap, 37,27,1,1,8,8);
		SetTileProp(tilemap, 37,28,1,1,8,8);
		SetTileProp(tilemap, 37,29,9,1,8,8);
		SetTileProp(tilemap, 37,30,1,1,8,8);
		SetTileProp(tilemap, 37,31,1,1,8,8);
		SetTileProp(tilemap, 37,32,6,1,8,8);
		SetTileProp(tilemap, 37,33,0,1,8,8);
		SetTileProp(tilemap, 37,34,0,1,24,0);
		SetTileProp(tilemap, 37,35,1,1,24,0);
		SetTileProp(tilemap, 37,36,1,1,24,0);
		SetTileProp(tilemap, 37,37,0,1,24,0);
		SetTileProp(tilemap, 37,38,1,1,24,0);
		SetTileProp(tilemap, 37,39,1,1,28,0);
		SetTileProp(tilemap, 37,40,1,1,8,16);
		SetTileProp(tilemap, 37,41,8,1,8,12);
		SetTileProp(tilemap, 37,42,0,1,8,16);
		SetTileProp(tilemap, 37,43,1,1,16,8);
		SetTileProp(tilemap, 37,44,1,1,16,8);
		SetTileProp(tilemap, 37,45,0,1,4,16);
		SetTileProp(tilemap, 37,46,1,1,16,8);
		SetTileProp(tilemap, 37,47,0,1,4,8);
		SetTileProp(tilemap, 37,48,0,1,4,16);
		SetTileProp(tilemap, 37,49,1,1,0,24);
		SetTileProp(tilemap, 37,50,0,1,4,16);
		SetTileProp(tilemap, 37,51,0,1,4,21);
		SetTileProp(tilemap, 37,52,0,1,4,21);
		SetTileProp(tilemap, 37,53,0,1,4,16);
		SetTileProp(tilemap, 37,54,0,1,8,16);
		SetTileProp(tilemap, 37,55,0,1,8,16);
		SetTileProp(tilemap, 37,56,0,1,8,16);
		SetTileProp(tilemap, 37,57,0,1,0,0);
		SetTileProp(tilemap, 37,58,0,1,0,0);
		SetTileProp(tilemap, 37,59,0,1,0,0);
		SetTileProp(tilemap, 37,60,0,1,0,0);
		SetTileProp(tilemap, 37,61,0,1,0,0);
		SetTileProp(tilemap, 37,62,0,1,0,0);
		SetTileProp(tilemap, 38,0,0,1,4,0);
		SetTileProp(tilemap, 38,1,0,1,4,0);
		SetTileProp(tilemap, 38,2,0,1,4,0);
		SetTileProp(tilemap, 38,3,0,1,4,0);
		SetTileProp(tilemap, 38,4,0,1,4,0);
		SetTileProp(tilemap, 38,5,0,1,4,0);
		SetTileProp(tilemap, 38,6,0,1,4,0);
		SetTileProp(tilemap, 38,7,0,1,8,16);
		SetTileProp(tilemap, 38,8,1,1,0,0);
		SetTileProp(tilemap, 38,9,0,1,8,16);
		SetTileProp(tilemap, 38,10,1,1,8,16);
		SetTileProp(tilemap, 38,11,1,1,8,16);
		SetTileProp(tilemap, 38,12,0,1,8,16);
		SetTileProp(tilemap, 38,13,0,1,4,16);
		SetTileProp(tilemap, 38,14,1,1,8,0);
		SetTileProp(tilemap, 38,15,1,1,7,16);
		SetTileProp(tilemap, 38,16,1,1,8,13);
		SetTileProp(tilemap, 38,17,3,1,8,8);
		SetTileProp(tilemap, 38,18,1,1,8,8);
		SetTileProp(tilemap, 38,19,1,1,8,8);
		SetTileProp(tilemap, 38,20,1,1,8,8);
		SetTileProp(tilemap, 38,21,0,1,8,8);
		SetTileProp(tilemap, 38,22,1,1,8,14);
		SetTileProp(tilemap, 38,23,1,1,8,14);
		SetTileProp(tilemap, 38,24,1,1,8,14);
		SetTileProp(tilemap, 38,25,1,1,8,14);
		SetTileProp(tilemap, 38,26,0,1,8,15);
		SetTileProp(tilemap, 38,27,0,1,8,14);
		SetTileProp(tilemap, 38,28,1,1,8,16);
		SetTileProp(tilemap, 38,29,0,1,8,24);
		SetTileProp(tilemap, 38,30,7,1,8,8);
		SetTileProp(tilemap, 38,31,1,1,8,8);
		SetTileProp(tilemap, 38,32,6,1,8,8);
		SetTileProp(tilemap, 38,33,0,1,8,8);
		SetTileProp(tilemap, 38,34,1,1,24,0);
		SetTileProp(tilemap, 38,35,0,1,19,0);
		SetTileProp(tilemap, 38,36,1,1,24,0);
		SetTileProp(tilemap, 38,37,0,1,4,8);
		SetTileProp(tilemap, 38,38,0,1,8,16);
		SetTileProp(tilemap, 38,39,0,1,8,16);
		SetTileProp(tilemap, 38,40,0,1,8,16);
		SetTileProp(tilemap, 38,41,8,1,8,8);
		SetTileProp(tilemap, 38,42,0,1,8,16);
		SetTileProp(tilemap, 38,43,1,1,16,8);
		SetTileProp(tilemap, 38,44,1,1,16,8);
		SetTileProp(tilemap, 38,45,1,1,16,8);
		SetTileProp(tilemap, 38,46,1,1,16,8);
		SetTileProp(tilemap, 38,47,0,1,4,8);
		SetTileProp(tilemap, 38,48,0,1,4,8);
		SetTileProp(tilemap, 38,49,1,1,0,24);
		SetTileProp(tilemap, 38,50,0,1,4,16);
		SetTileProp(tilemap, 38,51,0,1,4,21);
		SetTileProp(tilemap, 38,52,0,1,4,16);
		SetTileProp(tilemap, 38,53,0,1,4,16);
		SetTileProp(tilemap, 38,54,0,1,8,16);
		SetTileProp(tilemap, 38,55,0,1,8,16);
		SetTileProp(tilemap, 38,56,0,1,8,16);
		SetTileProp(tilemap, 38,57,0,1,0,0);
		SetTileProp(tilemap, 38,58,0,1,0,0);
		SetTileProp(tilemap, 38,59,0,1,0,0);
		SetTileProp(tilemap, 38,60,0,1,0,0);
		SetTileProp(tilemap, 38,61,0,1,0,0);
		SetTileProp(tilemap, 38,62,0,1,0,0);
		SetTileProp(tilemap, 39,0,0,1,4,0);
		SetTileProp(tilemap, 39,1,0,1,4,0);
		SetTileProp(tilemap, 39,2,0,1,4,0);
		SetTileProp(tilemap, 39,3,0,1,4,0);
		SetTileProp(tilemap, 39,4,0,1,4,0);
		SetTileProp(tilemap, 39,5,0,1,4,0);
		SetTileProp(tilemap, 39,6,0,1,4,0);
		SetTileProp(tilemap, 39,7,0,1,8,16);
		SetTileProp(tilemap, 39,8,0,1,4,16);
		SetTileProp(tilemap, 39,9,0,1,4,16);
		SetTileProp(tilemap, 39,10,0,1,4,16);
		SetTileProp(tilemap, 39,11,0,1,4,16);
		SetTileProp(tilemap, 39,12,0,1,4,16);
		SetTileProp(tilemap, 39,13,0,1,4,16);
		SetTileProp(tilemap, 39,14,1,1,8,16);
		SetTileProp(tilemap, 39,15,1,1,7,16);
		SetTileProp(tilemap, 39,16,0,1,4,13);
		SetTileProp(tilemap, 39,17,0,1,4,8);
		SetTileProp(tilemap, 39,18,8,1,8,8);
		SetTileProp(tilemap, 39,19,8,1,8,8);
		SetTileProp(tilemap, 39,20,0,1,8,8);
		SetTileProp(tilemap, 39,21,4,1,7,8);
		SetTileProp(tilemap, 39,22,2,1,7,8);
		SetTileProp(tilemap, 39,23,0,1,8,8);
		SetTileProp(tilemap, 39,24,0,1,8,8);
		SetTileProp(tilemap, 39,25,0,1,8,15);
		SetTileProp(tilemap, 39,26,1,1,8,16);
		SetTileProp(tilemap, 39,27,2,1,8,8);
		SetTileProp(tilemap, 39,28,1,1,8,16);
		SetTileProp(tilemap, 39,29,1,1,8,16);
		SetTileProp(tilemap, 39,30,0,1,12,0);
		SetTileProp(tilemap, 39,31,1,1,22,0);
		SetTileProp(tilemap, 39,32,0,1,19,0);
		SetTileProp(tilemap, 39,33,0,1,24,0);
		SetTileProp(tilemap, 39,34,1,1,24,0);
		SetTileProp(tilemap, 39,35,0,1,19,0);
		SetTileProp(tilemap, 39,36,1,1,24,0);
		SetTileProp(tilemap, 39,37,1,1,24,0);
		SetTileProp(tilemap, 39,38,1,1,24,0);
		SetTileProp(tilemap, 39,39,1,1,24,0);
		SetTileProp(tilemap, 39,40,0,1,8,16);
		SetTileProp(tilemap, 39,41,8,1,12,8);
		SetTileProp(tilemap, 39,42,0,1,8,16);
		SetTileProp(tilemap, 39,43,1,1,16,8);
		SetTileProp(tilemap, 39,44,1,1,16,8);
		SetTileProp(tilemap, 39,45,0,1,4,13);
		SetTileProp(tilemap, 39,46,0,1,4,13);
		SetTileProp(tilemap, 39,47,0,1,4,16);
		SetTileProp(tilemap, 39,48,0,1,4,13);
		SetTileProp(tilemap, 39,49,8,1,0,23);
		SetTileProp(tilemap, 39,50,0,1,4,13);
		SetTileProp(tilemap, 39,51,0,1,4,21);
		SetTileProp(tilemap, 39,52,0,1,4,16);
		SetTileProp(tilemap, 39,53,0,1,4,16);
		SetTileProp(tilemap, 39,54,0,1,8,16);
		SetTileProp(tilemap, 39,55,0,1,8,16);
		SetTileProp(tilemap, 39,56,0,1,8,16);
		SetTileProp(tilemap, 39,57,0,1,0,0);
		SetTileProp(tilemap, 39,58,0,1,0,0);
		SetTileProp(tilemap, 39,59,0,1,0,0);
		SetTileProp(tilemap, 39,60,0,1,0,0);
		SetTileProp(tilemap, 39,61,0,1,0,0);
		SetTileProp(tilemap, 39,62,0,1,0,0);
		SetTileProp(tilemap, 40,0,0,1,4,0);
		SetTileProp(tilemap, 40,1,0,1,4,0);
		SetTileProp(tilemap, 40,2,0,1,4,0);
		SetTileProp(tilemap, 40,3,0,1,4,0);
		SetTileProp(tilemap, 40,4,0,1,4,0);
		SetTileProp(tilemap, 40,5,0,1,4,0);
		SetTileProp(tilemap, 40,6,0,1,4,0);
		SetTileProp(tilemap, 40,7,0,1,8,16);
		SetTileProp(tilemap, 40,8,0,1,4,16);
		SetTileProp(tilemap, 40,9,0,1,4,16);
		SetTileProp(tilemap, 40,10,0,1,4,16);
		SetTileProp(tilemap, 40,11,0,1,4,16);
		SetTileProp(tilemap, 40,12,0,1,4,16);
		SetTileProp(tilemap, 40,13,4,1,7,16);
		SetTileProp(tilemap, 40,14,1,1,8,16);
		SetTileProp(tilemap, 40,15,1,1,7,16);
		SetTileProp(tilemap, 40,16,1,1,8,16);
		SetTileProp(tilemap, 40,17,2,1,8,16);
		SetTileProp(tilemap, 40,18,0,1,8,8);
		SetTileProp(tilemap, 40,19,0,1,8,8);
		SetTileProp(tilemap, 40,20,0,1,7,8);
		SetTileProp(tilemap, 40,21,1,1,7,14);
		SetTileProp(tilemap, 40,22,1,1,7,16);
		SetTileProp(tilemap, 40,23,1,1,7,16);
		SetTileProp(tilemap, 40,24,1,1,7,8);
		SetTileProp(tilemap, 40,25,1,1,7,23);
		SetTileProp(tilemap, 40,26,1,1,8,16);
		SetTileProp(tilemap, 40,27,1,1,8,8);
		SetTileProp(tilemap, 40,28,0,1,8,16);
		SetTileProp(tilemap, 40,29,0,1,24,0);
		SetTileProp(tilemap, 40,30,0,1,24,0);
		SetTileProp(tilemap, 40,31,1,1,24,0);
		SetTileProp(tilemap, 40,32,1,1,24,0);
		SetTileProp(tilemap, 40,33,1,1,24,0);
		SetTileProp(tilemap, 40,34,1,1,24,0);
		SetTileProp(tilemap, 40,35,1,1,24,0);
		SetTileProp(tilemap, 40,36,1,1,24,0);
		SetTileProp(tilemap, 40,37,0,1,4,8);
		SetTileProp(tilemap, 40,38,1,1,24,0);
		SetTileProp(tilemap, 40,39,1,1,27,0);
		SetTileProp(tilemap, 40,40,0,1,8,16);
		SetTileProp(tilemap, 40,41,1,1,16,8);
		SetTileProp(tilemap, 40,42,0,1,8,16);
		SetTileProp(tilemap, 40,43,1,1,16,8);
		SetTileProp(tilemap, 40,44,1,1,16,8);
		SetTileProp(tilemap, 40,45,0,1,4,13);
		SetTileProp(tilemap, 40,46,8,1,1,16);
		SetTileProp(tilemap, 40,47,8,1,1,16);
		SetTileProp(tilemap, 40,48,8,1,1,16);
		SetTileProp(tilemap, 40,49,8,1,1,16);
		SetTileProp(tilemap, 40,50,0,1,4,13);
		SetTileProp(tilemap, 40,51,0,1,4,21);
		SetTileProp(tilemap, 40,52,0,1,4,16);
		SetTileProp(tilemap, 40,53,0,1,4,16);
		SetTileProp(tilemap, 40,54,0,1,8,16);
		SetTileProp(tilemap, 40,55,0,1,8,16);
		SetTileProp(tilemap, 40,56,0,1,8,16);
		SetTileProp(tilemap, 40,57,0,1,0,0);
		SetTileProp(tilemap, 40,58,0,1,0,0);
		SetTileProp(tilemap, 40,59,0,1,0,0);
		SetTileProp(tilemap, 40,60,0,1,0,0);
		SetTileProp(tilemap, 40,61,0,1,0,0);
		SetTileProp(tilemap, 40,62,0,1,0,0);
		SetTileProp(tilemap, 41,0,0,1,4,0);
		SetTileProp(tilemap, 41,1,0,1,4,0);
		SetTileProp(tilemap, 41,2,0,1,4,0);
		SetTileProp(tilemap, 41,3,0,1,4,0);
		SetTileProp(tilemap, 41,4,0,1,4,0);
		SetTileProp(tilemap, 41,5,0,1,4,0);
		SetTileProp(tilemap, 41,6,0,1,4,0);
		SetTileProp(tilemap, 41,7,0,1,8,16);
		SetTileProp(tilemap, 41,8,0,1,4,16);
		SetTileProp(tilemap, 41,9,0,1,4,16);
		SetTileProp(tilemap, 41,10,0,1,4,16);
		SetTileProp(tilemap, 41,11,0,1,4,15);
		SetTileProp(tilemap, 41,12,0,1,4,8);
		SetTileProp(tilemap, 41,13,5,1,7,16);
		SetTileProp(tilemap, 41,14,1,1,8,16);
		SetTileProp(tilemap, 41,15,1,1,8,0);
		SetTileProp(tilemap, 41,16,0,1,8,16);
		SetTileProp(tilemap, 41,17,5,1,8,8);
		SetTileProp(tilemap, 41,18,1,1,8,16);
		SetTileProp(tilemap, 41,19,2,1,8,16);
		SetTileProp(tilemap, 41,20,0,1,8,8);
		SetTileProp(tilemap, 41,21,1,1,7,14);
		SetTileProp(tilemap, 41,22,1,1,7,16);
		SetTileProp(tilemap, 41,23,1,1,7,16);
		SetTileProp(tilemap, 41,24,1,1,7,11);
		SetTileProp(tilemap, 41,25,1,1,7,16);
		SetTileProp(tilemap, 41,26,1,1,8,16);
		SetTileProp(tilemap, 41,27,1,1,8,16);
		SetTileProp(tilemap, 41,28,0,1,8,16);
		SetTileProp(tilemap, 41,29,0,1,24,0);
		SetTileProp(tilemap, 41,30,0,1,24,0);
		SetTileProp(tilemap, 41,31,1,1,24,0);
		SetTileProp(tilemap, 41,32,0,1,16,16);
		SetTileProp(tilemap, 41,33,8,1,16,8);
		SetTileProp(tilemap, 41,34,0,1,16,16);
		SetTileProp(tilemap, 41,35,8,1,16,8);
		SetTileProp(tilemap, 41,36,0,1,16,16);
		SetTileProp(tilemap, 41,37,0,1,8,17);
		SetTileProp(tilemap, 41,38,1,1,24,0);
		SetTileProp(tilemap, 41,39,1,1,27,0);
		SetTileProp(tilemap, 41,40,0,1,8,16);
		SetTileProp(tilemap, 41,41,1,1,16,8);
		SetTileProp(tilemap, 41,42,1,1,16,8);
		SetTileProp(tilemap, 41,43,0,1,8,16);
		SetTileProp(tilemap, 41,44,0,1,8,16);
		SetTileProp(tilemap, 41,45,0,1,4,16);
		SetTileProp(tilemap, 41,46,1,1,1,0);
		SetTileProp(tilemap, 41,47,1,1,1,0);
		SetTileProp(tilemap, 41,48,1,1,1,0);
		SetTileProp(tilemap, 41,49,1,1,1,0);
		SetTileProp(tilemap, 41,50,0,1,4,13);
		SetTileProp(tilemap, 41,51,0,1,4,21);
		SetTileProp(tilemap, 41,52,0,1,4,24);
		SetTileProp(tilemap, 41,53,0,1,4,24);
		SetTileProp(tilemap, 41,54,0,1,4,24);
		SetTileProp(tilemap, 41,55,0,1,4,24);
		SetTileProp(tilemap, 41,56,0,1,8,16);
		SetTileProp(tilemap, 41,57,0,1,0,0);
		SetTileProp(tilemap, 41,58,0,1,0,0);
		SetTileProp(tilemap, 41,59,0,1,0,0);
		SetTileProp(tilemap, 41,60,0,1,0,0);
		SetTileProp(tilemap, 41,61,0,1,0,0);
		SetTileProp(tilemap, 41,62,0,1,0,0);
		SetTileProp(tilemap, 42,0,0,1,4,0);
		SetTileProp(tilemap, 42,1,0,1,4,0);
		SetTileProp(tilemap, 42,2,0,1,4,0);
		SetTileProp(tilemap, 42,3,0,1,4,0);
		SetTileProp(tilemap, 42,4,0,1,4,0);
		SetTileProp(tilemap, 42,5,0,1,4,0);
		SetTileProp(tilemap, 42,6,0,1,4,0);
		SetTileProp(tilemap, 42,7,0,1,8,16);
		SetTileProp(tilemap, 42,8,0,1,4,16);
		SetTileProp(tilemap, 42,9,0,1,4,16);
		SetTileProp(tilemap, 42,10,0,1,4,16);
		SetTileProp(tilemap, 42,11,0,1,4,16);
		SetTileProp(tilemap, 42,12,0,1,4,16);
		SetTileProp(tilemap, 42,13,0,1,7,16);
		SetTileProp(tilemap, 42,14,5,1,8,16);
		SetTileProp(tilemap, 42,15,1,1,8,16);
		SetTileProp(tilemap, 42,16,1,1,8,16);
		SetTileProp(tilemap, 42,17,1,1,8,16);
		SetTileProp(tilemap, 42,18,0,1,8,16);
		SetTileProp(tilemap, 42,19,1,1,8,16);
		SetTileProp(tilemap, 42,20,1,1,7,8);
		SetTileProp(tilemap, 42,21,1,1,7,16);
		SetTileProp(tilemap, 42,22,1,1,7,14);
		SetTileProp(tilemap, 42,23,1,1,7,14);
		SetTileProp(tilemap, 42,24,1,1,7,14);
		SetTileProp(tilemap, 42,25,1,1,7,14);
		SetTileProp(tilemap, 42,26,1,1,9,14);
		SetTileProp(tilemap, 42,27,0,1,9,14);
		SetTileProp(tilemap, 42,28,0,1,9,14);
		SetTileProp(tilemap, 42,29,0,1,9,14);
		SetTileProp(tilemap, 42,30,0,1,8,16);
		SetTileProp(tilemap, 42,31,0,1,8,16);
		SetTileProp(tilemap, 42,32,1,1,16,8);
		SetTileProp(tilemap, 42,33,1,1,16,8);
		SetTileProp(tilemap, 42,34,1,1,16,8);
		SetTileProp(tilemap, 42,35,1,1,16,8);
		SetTileProp(tilemap, 42,36,1,1,16,8);
		SetTileProp(tilemap, 42,37,0,1,8,16);
		SetTileProp(tilemap, 42,38,1,1,27,0);
		SetTileProp(tilemap, 42,39,1,1,27,0);
		SetTileProp(tilemap, 42,40,0,1,8,16);
		SetTileProp(tilemap, 42,41,5,1,16,8);
		SetTileProp(tilemap, 42,42,1,1,16,8);
		SetTileProp(tilemap, 42,43,0,1,8,16);
		SetTileProp(tilemap, 42,44,0,1,8,16);
		SetTileProp(tilemap, 42,45,0,1,4,24);
		SetTileProp(tilemap, 42,46,1,1,1,0);
		SetTileProp(tilemap, 42,47,1,1,1,0);
		SetTileProp(tilemap, 42,48,1,1,1,0);
		SetTileProp(tilemap, 42,49,1,1,1,0);
		SetTileProp(tilemap, 42,50,0,1,4,16);
		SetTileProp(tilemap, 42,51,0,1,4,21);
		SetTileProp(tilemap, 42,52,0,1,4,24);
		SetTileProp(tilemap, 42,53,0,1,4,24);
		SetTileProp(tilemap, 42,54,0,1,4,24);
		SetTileProp(tilemap, 42,55,0,1,4,24);
		SetTileProp(tilemap, 42,56,0,1,8,16);
		SetTileProp(tilemap, 42,57,0,1,0,0);
		SetTileProp(tilemap, 42,58,0,1,0,0);
		SetTileProp(tilemap, 42,59,0,1,0,0);
		SetTileProp(tilemap, 42,60,0,1,0,0);
		SetTileProp(tilemap, 42,61,0,1,0,0);
		SetTileProp(tilemap, 42,62,0,1,0,0);
		SetTileProp(tilemap, 43,0,0,1,4,0);
		SetTileProp(tilemap, 43,1,0,1,4,0);
		SetTileProp(tilemap, 43,2,0,1,4,0);
		SetTileProp(tilemap, 43,3,0,1,4,0);
		SetTileProp(tilemap, 43,4,0,1,4,0);
		SetTileProp(tilemap, 43,5,0,1,4,0);
		SetTileProp(tilemap, 43,6,0,1,4,0);
		SetTileProp(tilemap, 43,7,0,1,8,16);
		SetTileProp(tilemap, 43,8,0,1,4,16);
		SetTileProp(tilemap, 43,9,0,1,4,16);
		SetTileProp(tilemap, 43,10,0,1,4,16);
		SetTileProp(tilemap, 43,11,0,1,4,16);
		SetTileProp(tilemap, 43,12,0,1,4,16);
		SetTileProp(tilemap, 43,13,0,1,8,16);
		SetTileProp(tilemap, 43,14,0,1,8,16);
		SetTileProp(tilemap, 43,15,1,1,7,16);
		SetTileProp(tilemap, 43,16,5,1,8,16);
		SetTileProp(tilemap, 43,17,1,1,8,16);
		SetTileProp(tilemap, 43,18,1,1,8,16);
		SetTileProp(tilemap, 43,19,1,1,8,12);
		SetTileProp(tilemap, 43,20,1,1,7,12);
		SetTileProp(tilemap, 43,21,1,1,8,14);
		SetTileProp(tilemap, 43,22,1,1,7,14);
		SetTileProp(tilemap, 43,23,1,1,7,14);
		SetTileProp(tilemap, 43,24,1,1,7,14);
		SetTileProp(tilemap, 43,25,1,1,7,14);
		SetTileProp(tilemap, 43,26,0,1,9,14);
		SetTileProp(tilemap, 43,27,1,1,3,0);
		SetTileProp(tilemap, 43,28,1,1,3,20);
		SetTileProp(tilemap, 43,29,1,1,2,21);
		SetTileProp(tilemap, 43,30,1,1,1,22);
		SetTileProp(tilemap, 43,31,0,1,4,0);
		SetTileProp(tilemap, 43,32,1,1,16,7);
		SetTileProp(tilemap, 43,33,1,1,1,23);
		SetTileProp(tilemap, 43,34,0,1,1,23);
		SetTileProp(tilemap, 43,35,0,1,4,0);
		SetTileProp(tilemap, 43,36,1,1,16,8);
		SetTileProp(tilemap, 43,37,0,1,4,0);
		SetTileProp(tilemap, 43,38,0,1,8,0);
		SetTileProp(tilemap, 43,39,0,1,8,16);
		SetTileProp(tilemap, 43,40,1,1,16,8);
		SetTileProp(tilemap, 43,41,1,1,16,8);
		SetTileProp(tilemap, 43,42,1,1,16,8);
		SetTileProp(tilemap, 43,43,0,1,8,16);
		SetTileProp(tilemap, 43,44,0,1,8,16);
		SetTileProp(tilemap, 43,45,0,1,4,8);
		SetTileProp(tilemap, 43,46,9,1,1,16);
		SetTileProp(tilemap, 43,47,9,1,1,16);
		SetTileProp(tilemap, 43,48,9,1,1,16);
		SetTileProp(tilemap, 43,49,9,1,1,16);
		SetTileProp(tilemap, 43,50,0,1,4,20);
		SetTileProp(tilemap, 43,51,0,1,4,21);
		SetTileProp(tilemap, 43,52,0,1,4,24);
		SetTileProp(tilemap, 43,53,0,1,4,24);
		SetTileProp(tilemap, 43,54,0,1,4,24);
		SetTileProp(tilemap, 43,55,0,1,4,24);
		SetTileProp(tilemap, 43,56,0,1,8,16);
		SetTileProp(tilemap, 43,57,0,1,0,0);
		SetTileProp(tilemap, 43,58,0,1,0,0);
		SetTileProp(tilemap, 43,59,0,1,0,0);
		SetTileProp(tilemap, 43,60,0,1,0,0);
		SetTileProp(tilemap, 43,61,0,1,0,0);
		SetTileProp(tilemap, 43,62,0,1,0,0);
		SetTileProp(tilemap, 44,0,0,1,4,0);
		SetTileProp(tilemap, 44,1,0,1,4,0);
		SetTileProp(tilemap, 44,2,0,1,4,0);
		SetTileProp(tilemap, 44,3,0,1,4,0);
		SetTileProp(tilemap, 44,4,0,1,4,0);
		SetTileProp(tilemap, 44,5,0,1,4,0);
		SetTileProp(tilemap, 44,6,0,1,4,0);
		SetTileProp(tilemap, 44,7,0,1,8,16);
		SetTileProp(tilemap, 44,8,0,1,4,16);
		SetTileProp(tilemap, 44,9,0,1,4,16);
		SetTileProp(tilemap, 44,10,0,1,4,16);
		SetTileProp(tilemap, 44,11,0,1,4,16);
		SetTileProp(tilemap, 44,12,0,1,4,16);
		SetTileProp(tilemap, 44,13,0,1,4,16);
		SetTileProp(tilemap, 44,14,0,1,4,16);
		SetTileProp(tilemap, 44,15,0,1,8,0);
		SetTileProp(tilemap, 44,16,0,1,8,0);
		SetTileProp(tilemap, 44,17,5,1,8,16);
		SetTileProp(tilemap, 44,18,2,1,8,16);
		SetTileProp(tilemap, 44,19,1,1,8,16);
		SetTileProp(tilemap, 44,20,1,1,8,16);
		SetTileProp(tilemap, 44,21,1,1,8,15);
		SetTileProp(tilemap, 44,22,1,1,8,8);
		SetTileProp(tilemap, 44,23,0,1,8,16);
		SetTileProp(tilemap, 44,24,0,1,9,12);
		SetTileProp(tilemap, 44,25,0,1,8,16);
		SetTileProp(tilemap, 44,26,4,1,14,0);
		SetTileProp(tilemap, 44,27,1,1,14,0);
		SetTileProp(tilemap, 44,28,2,1,14,0);
		SetTileProp(tilemap, 44,29,0,1,4,0);
		SetTileProp(tilemap, 44,30,1,1,0,0);
		SetTileProp(tilemap, 44,31,1,1,0,0);
		SetTileProp(tilemap, 44,32,1,1,0,2);
		SetTileProp(tilemap, 44,33,1,1,0,0);
		SetTileProp(tilemap, 44,34,1,1,0,0);
		SetTileProp(tilemap, 44,35,0,1,0,0);
		SetTileProp(tilemap, 44,36,1,1,16,8);
		SetTileProp(tilemap, 44,37,1,1,0,0);
		SetTileProp(tilemap, 44,38,0,1,8,0);
		SetTileProp(tilemap, 44,39,0,1,8,16);
		SetTileProp(tilemap, 44,40,1,1,16,8);
		SetTileProp(tilemap, 44,41,1,1,8,16);
		SetTileProp(tilemap, 44,42,1,1,8,16);
		SetTileProp(tilemap, 44,43,0,1,4,16);
		SetTileProp(tilemap, 44,44,0,1,4,8);
		SetTileProp(tilemap, 44,45,0,1,4,24);
		SetTileProp(tilemap, 44,46,0,1,31,8);
		SetTileProp(tilemap, 44,47,0,1,4,16);
		SetTileProp(tilemap, 44,48,0,1,4,16);
		SetTileProp(tilemap, 44,49,0,1,4,20);
		SetTileProp(tilemap, 44,50,0,1,4,21);
		SetTileProp(tilemap, 44,51,0,1,4,21);
		SetTileProp(tilemap, 44,52,0,1,4,24);
		SetTileProp(tilemap, 44,53,0,1,4,24);
		SetTileProp(tilemap, 44,54,0,1,4,24);
		SetTileProp(tilemap, 44,55,0,1,4,24);
		SetTileProp(tilemap, 44,56,0,1,8,16);
		SetTileProp(tilemap, 44,57,0,1,0,0);
		SetTileProp(tilemap, 44,58,0,1,0,0);
		SetTileProp(tilemap, 44,59,0,1,0,0);
		SetTileProp(tilemap, 44,60,0,1,0,0);
		SetTileProp(tilemap, 44,61,0,1,0,0);
		SetTileProp(tilemap, 44,62,0,1,0,0);
		SetTileProp(tilemap, 45,0,0,1,4,0);
		SetTileProp(tilemap, 45,1,0,1,4,0);
		SetTileProp(tilemap, 45,2,0,1,4,0);
		SetTileProp(tilemap, 45,3,0,1,4,0);
		SetTileProp(tilemap, 45,4,0,1,4,0);
		SetTileProp(tilemap, 45,5,0,1,4,0);
		SetTileProp(tilemap, 45,6,0,1,4,0);
		SetTileProp(tilemap, 45,7,0,1,8,16);
		SetTileProp(tilemap, 45,8,0,1,4,16);
		SetTileProp(tilemap, 45,9,0,1,4,16);
		SetTileProp(tilemap, 45,10,0,1,4,16);
		SetTileProp(tilemap, 45,11,0,1,4,16);
		SetTileProp(tilemap, 45,12,0,1,4,16);
		SetTileProp(tilemap, 45,13,0,1,4,16);
		SetTileProp(tilemap, 45,14,0,1,4,16);
		SetTileProp(tilemap, 45,15,0,1,8,0);
		SetTileProp(tilemap, 45,16,0,1,8,0);
		SetTileProp(tilemap, 45,17,1,1,8,16);
		SetTileProp(tilemap, 45,18,1,1,7,16);
		SetTileProp(tilemap, 45,19,1,1,8,16);
		SetTileProp(tilemap, 45,20,0,1,8,16);
		SetTileProp(tilemap, 45,21,1,1,9,14);
		SetTileProp(tilemap, 45,22,1,1,10,13);
		SetTileProp(tilemap, 45,23,1,1,11,11);
		SetTileProp(tilemap, 45,24,1,1,12,11);
		SetTileProp(tilemap, 45,25,0,1,8,16);
		SetTileProp(tilemap, 45,26,1,1,14,0);
		SetTileProp(tilemap, 45,27,1,1,14,0);
		SetTileProp(tilemap, 45,28,1,1,14,0);
		SetTileProp(tilemap, 45,29,1,1,0,0);
		SetTileProp(tilemap, 45,30,1,1,0,0);
		SetTileProp(tilemap, 45,31,1,1,16,0);
		SetTileProp(tilemap, 45,32,1,1,16,2);
		SetTileProp(tilemap, 45,33,1,1,16,0);
		SetTileProp(tilemap, 45,34,1,1,0,0);
		SetTileProp(tilemap, 45,35,0,1,0,0);
		SetTileProp(tilemap, 45,36,1,1,16,8);
		SetTileProp(tilemap, 45,37,1,1,0,0);
		SetTileProp(tilemap, 45,38,1,1,1,8);
		SetTileProp(tilemap, 45,39,1,1,16,8);
		SetTileProp(tilemap, 45,40,1,1,16,8);
		SetTileProp(tilemap, 45,41,0,1,8,16);
		SetTileProp(tilemap, 45,42,0,1,8,16);
		SetTileProp(tilemap, 45,43,0,1,4,16);
		SetTileProp(tilemap, 45,44,0,1,4,23);
		SetTileProp(tilemap, 45,45,0,1,4,23);
		SetTileProp(tilemap, 45,46,0,1,4,16);
		SetTileProp(tilemap, 45,47,0,1,4,16);
		SetTileProp(tilemap, 45,48,0,1,4,21);
		SetTileProp(tilemap, 45,49,0,1,4,21);
		SetTileProp(tilemap, 45,50,0,1,4,21);
		SetTileProp(tilemap, 45,51,0,1,4,21);
		SetTileProp(tilemap, 45,52,0,1,4,24);
		SetTileProp(tilemap, 45,53,0,1,4,24);
		SetTileProp(tilemap, 45,54,0,1,4,24);
		SetTileProp(tilemap, 45,55,0,1,4,24);
		SetTileProp(tilemap, 45,56,0,1,8,16);
		SetTileProp(tilemap, 45,57,0,1,0,0);
		SetTileProp(tilemap, 45,58,0,1,0,0);
		SetTileProp(tilemap, 45,59,0,1,0,0);
		SetTileProp(tilemap, 45,60,0,1,0,0);
		SetTileProp(tilemap, 45,61,0,1,0,0);
		SetTileProp(tilemap, 45,62,0,1,0,0);
		SetTileProp(tilemap, 46,0,0,1,4,0);
		SetTileProp(tilemap, 46,1,0,1,4,0);
		SetTileProp(tilemap, 46,2,0,1,4,0);
		SetTileProp(tilemap, 46,3,0,1,4,0);
		SetTileProp(tilemap, 46,4,0,1,4,0);
		SetTileProp(tilemap, 46,5,0,1,4,0);
		SetTileProp(tilemap, 46,6,0,1,4,0);
		SetTileProp(tilemap, 46,7,0,1,8,16);
		SetTileProp(tilemap, 46,8,0,1,4,16);
		SetTileProp(tilemap, 46,9,0,1,4,16);
		SetTileProp(tilemap, 46,10,0,1,4,16);
		SetTileProp(tilemap, 46,11,0,1,4,16);
		SetTileProp(tilemap, 46,12,0,1,4,16);
		SetTileProp(tilemap, 46,13,0,1,4,16);
		SetTileProp(tilemap, 46,14,0,1,4,16);
		SetTileProp(tilemap, 46,15,0,1,4,16);
		SetTileProp(tilemap, 46,16,0,1,8,16);
		SetTileProp(tilemap, 46,17,1,1,8,16);
		SetTileProp(tilemap, 46,18,0,1,4,16);
		SetTileProp(tilemap, 46,19,0,1,4,16);
		SetTileProp(tilemap, 46,20,0,1,8,16);
		SetTileProp(tilemap, 46,21,1,1,8,16);
		SetTileProp(tilemap, 46,22,0,1,4,8);
		SetTileProp(tilemap, 46,23,0,1,4,8);
		SetTileProp(tilemap, 46,24,1,1,13,9);
		SetTileProp(tilemap, 46,25,1,1,14,10);
		SetTileProp(tilemap, 46,26,1,1,14,0);
		SetTileProp(tilemap, 46,27,1,1,14,0);
		SetTileProp(tilemap, 46,28,1,1,14,0);
		SetTileProp(tilemap, 46,29,1,1,0,0);
		SetTileProp(tilemap, 46,30,1,1,0,0);
		SetTileProp(tilemap, 46,31,1,1,15,0);
		SetTileProp(tilemap, 46,32,0,1,15,1);
		SetTileProp(tilemap, 46,33,1,1,16,0);
		SetTileProp(tilemap, 46,34,1,1,0,0);
		SetTileProp(tilemap, 46,35,1,1,1,23);
		SetTileProp(tilemap, 46,36,1,1,1,0);
		SetTileProp(tilemap, 46,37,1,1,0,0);
		SetTileProp(tilemap, 46,38,1,1,0,0);
		SetTileProp(tilemap, 46,39,1,1,0,0);
		SetTileProp(tilemap, 46,40,1,1,0,0);
		SetTileProp(tilemap, 46,41,0,1,4,8);
		SetTileProp(tilemap, 46,42,0,1,8,16);
		SetTileProp(tilemap, 46,43,0,1,4,22);
		SetTileProp(tilemap, 46,44,0,1,4,22);
		SetTileProp(tilemap, 46,45,0,1,4,20);
		SetTileProp(tilemap, 46,46,0,1,4,16);
		SetTileProp(tilemap, 46,47,0,1,4,16);
		SetTileProp(tilemap, 46,48,0,1,4,21);
		SetTileProp(tilemap, 46,49,0,1,4,21);
		SetTileProp(tilemap, 46,50,0,1,4,24);
		SetTileProp(tilemap, 46,51,0,1,4,24);
		SetTileProp(tilemap, 46,52,0,1,4,24);
		SetTileProp(tilemap, 46,53,0,1,4,24);
		SetTileProp(tilemap, 46,54,0,1,4,24);
		SetTileProp(tilemap, 46,55,0,1,4,24);
		SetTileProp(tilemap, 46,56,0,1,8,16);
		SetTileProp(tilemap, 46,57,0,1,0,0);
		SetTileProp(tilemap, 46,58,0,1,0,0);
		SetTileProp(tilemap, 46,59,0,1,0,0);
		SetTileProp(tilemap, 46,60,0,1,0,0);
		SetTileProp(tilemap, 46,61,0,1,0,0);
		SetTileProp(tilemap, 46,62,0,1,0,0);
		SetTileProp(tilemap, 47,0,0,1,4,0);
		SetTileProp(tilemap, 47,1,0,1,4,0);
		SetTileProp(tilemap, 47,2,0,1,4,0);
		SetTileProp(tilemap, 47,3,0,1,4,0);
		SetTileProp(tilemap, 47,4,0,1,4,0);
		SetTileProp(tilemap, 47,5,0,1,4,0);
		SetTileProp(tilemap, 47,6,0,1,4,0);
		SetTileProp(tilemap, 47,7,0,1,8,16);
		SetTileProp(tilemap, 47,8,0,1,8,16);
		SetTileProp(tilemap, 47,9,0,1,8,16);
		SetTileProp(tilemap, 47,10,0,1,8,16);
		SetTileProp(tilemap, 47,11,0,1,8,16);
		SetTileProp(tilemap, 47,12,0,1,8,16);
		SetTileProp(tilemap, 47,13,0,1,8,16);
		SetTileProp(tilemap, 47,14,0,1,8,16);
		SetTileProp(tilemap, 47,15,0,1,4,16);
		SetTileProp(tilemap, 47,16,0,1,8,16);
		SetTileProp(tilemap, 47,17,1,1,8,16);
		SetTileProp(tilemap, 47,18,0,1,4,0);
		SetTileProp(tilemap, 47,19,0,1,8,0);
		SetTileProp(tilemap, 47,20,4,1,8,8);
		SetTileProp(tilemap, 47,21,1,1,8,8);
		SetTileProp(tilemap, 47,22,2,1,8,8);
		SetTileProp(tilemap, 47,23,0,1,8,16);
		SetTileProp(tilemap, 47,24,0,1,8,16);
		SetTileProp(tilemap, 47,25,0,1,8,16);
		SetTileProp(tilemap, 47,26,1,1,14,0);
		SetTileProp(tilemap, 47,27,1,1,14,0);
		SetTileProp(tilemap, 47,28,6,1,14,0);
		SetTileProp(tilemap, 47,29,1,1,0,0);
		SetTileProp(tilemap, 47,30,1,1,0,0);
		SetTileProp(tilemap, 47,31,1,1,16,0);
		SetTileProp(tilemap, 47,32,0,1,16,1);
		SetTileProp(tilemap, 47,33,1,1,16,0);
		SetTileProp(tilemap, 47,34,1,1,0,0);
		SetTileProp(tilemap, 47,35,0,1,24,0);
		SetTileProp(tilemap, 47,36,1,1,16,8);
		SetTileProp(tilemap, 47,37,1,1,0,0);
		SetTileProp(tilemap, 47,38,1,1,1,0);
		SetTileProp(tilemap, 47,39,1,1,1,0);
		SetTileProp(tilemap, 47,40,1,1,1,0);
		SetTileProp(tilemap, 47,41,1,1,1,23);
		SetTileProp(tilemap, 47,42,0,1,4,0);
		SetTileProp(tilemap, 47,43,0,1,4,0);
		SetTileProp(tilemap, 47,44,0,1,4,20);
		SetTileProp(tilemap, 47,45,0,1,4,20);
		SetTileProp(tilemap, 47,46,0,1,4,16);
		SetTileProp(tilemap, 47,47,0,1,4,16);
		SetTileProp(tilemap, 47,48,0,1,4,21);
		SetTileProp(tilemap, 47,49,0,1,4,21);
		SetTileProp(tilemap, 47,50,0,1,4,24);
		SetTileProp(tilemap, 47,51,0,1,4,24);
		SetTileProp(tilemap, 47,52,0,1,4,24);
		SetTileProp(tilemap, 47,53,0,1,4,24);
		SetTileProp(tilemap, 47,54,0,1,4,24);
		SetTileProp(tilemap, 47,55,0,1,4,24);
		SetTileProp(tilemap, 47,56,0,1,8,16);
		SetTileProp(tilemap, 47,57,0,1,0,0);
		SetTileProp(tilemap, 47,58,0,1,0,0);
		SetTileProp(tilemap, 47,59,0,1,0,0);
		SetTileProp(tilemap, 47,60,0,1,0,0);
		SetTileProp(tilemap, 47,61,0,1,0,0);
		SetTileProp(tilemap, 47,62,0,1,0,0);
		SetTileProp(tilemap, 48,0,0,1,4,0);
		SetTileProp(tilemap, 48,1,0,1,4,0);
		SetTileProp(tilemap, 48,2,0,1,4,0);
		SetTileProp(tilemap, 48,3,0,1,4,0);
		SetTileProp(tilemap, 48,4,0,1,4,0);
		SetTileProp(tilemap, 48,5,0,1,4,0);
		SetTileProp(tilemap, 48,6,0,1,4,0);
		SetTileProp(tilemap, 48,7,0,1,8,16);
		SetTileProp(tilemap, 48,8,0,1,8,16);
		SetTileProp(tilemap, 48,9,0,1,8,16);
		SetTileProp(tilemap, 48,10,0,1,8,16);
		SetTileProp(tilemap, 48,11,0,1,8,16);
		SetTileProp(tilemap, 48,12,0,1,8,16);
		SetTileProp(tilemap, 48,13,0,1,8,16);
		SetTileProp(tilemap, 48,14,0,1,8,16);
		SetTileProp(tilemap, 48,15,0,1,4,16);
		SetTileProp(tilemap, 48,16,0,1,8,16);
		SetTileProp(tilemap, 48,17,0,1,8,0);
		SetTileProp(tilemap, 48,18,0,1,8,0);
		SetTileProp(tilemap, 48,19,0,1,8,0);
		SetTileProp(tilemap, 48,20,12,1,8,8);
		SetTileProp(tilemap, 48,21,9,1,8,8);
		SetTileProp(tilemap, 48,22,11,1,8,8);
		SetTileProp(tilemap, 48,23,0,1,4,8);
		SetTileProp(tilemap, 48,24,0,1,4,16);
		SetTileProp(tilemap, 48,25,0,1,4,8);
		SetTileProp(tilemap, 48,26,0,1,4,0);
		SetTileProp(tilemap, 48,27,0,1,4,0);
		SetTileProp(tilemap, 48,28,0,1,4,0);
		SetTileProp(tilemap, 48,29,0,1,4,0);
		SetTileProp(tilemap, 48,30,1,1,0,4);
		SetTileProp(tilemap, 48,31,1,1,1,0);
		SetTileProp(tilemap, 48,32,1,1,1,0);
		SetTileProp(tilemap, 48,33,1,1,1,4);
		SetTileProp(tilemap, 48,34,1,1,0,0);
		SetTileProp(tilemap, 48,35,0,1,0,0);
		SetTileProp(tilemap, 48,36,1,1,16,8);
		SetTileProp(tilemap, 48,37,1,1,0,0);
		SetTileProp(tilemap, 48,38,1,1,1,0);
		SetTileProp(tilemap, 48,39,1,1,1,0);
		SetTileProp(tilemap, 48,40,1,1,1,0);
		SetTileProp(tilemap, 48,41,0,1,4,0);
		SetTileProp(tilemap, 48,42,0,1,4,0);
		SetTileProp(tilemap, 48,43,0,1,4,0);
		SetTileProp(tilemap, 48,44,0,1,4,20);
		SetTileProp(tilemap, 48,45,0,1,4,20);
		SetTileProp(tilemap, 48,46,0,1,4,16);
		SetTileProp(tilemap, 48,47,0,1,4,21);
		SetTileProp(tilemap, 48,48,0,1,4,21);
		SetTileProp(tilemap, 48,49,0,1,4,21);
		SetTileProp(tilemap, 48,50,0,1,4,16);
		SetTileProp(tilemap, 48,51,0,1,4,16);
		SetTileProp(tilemap, 48,52,0,1,4,24);
		SetTileProp(tilemap, 48,53,0,1,4,16);
		SetTileProp(tilemap, 48,54,0,1,8,16);
		SetTileProp(tilemap, 48,55,0,1,8,16);
		SetTileProp(tilemap, 48,56,0,1,8,16);
		SetTileProp(tilemap, 48,57,0,1,0,0);
		SetTileProp(tilemap, 48,58,0,1,0,0);
		SetTileProp(tilemap, 48,59,0,1,0,0);
		SetTileProp(tilemap, 48,60,0,1,0,0);
		SetTileProp(tilemap, 48,61,0,1,0,0);
		SetTileProp(tilemap, 48,62,0,1,0,0);
		SetTileProp(tilemap, 49,0,0,1,4,0);
		SetTileProp(tilemap, 49,1,0,1,4,0);
		SetTileProp(tilemap, 49,2,0,1,4,0);
		SetTileProp(tilemap, 49,3,0,1,4,0);
		SetTileProp(tilemap, 49,4,0,1,4,0);
		SetTileProp(tilemap, 49,5,0,1,4,0);
		SetTileProp(tilemap, 49,6,0,1,4,0);
		SetTileProp(tilemap, 49,7,0,1,8,16);
		SetTileProp(tilemap, 49,8,0,1,8,16);
		SetTileProp(tilemap, 49,9,0,1,8,16);
		SetTileProp(tilemap, 49,10,0,1,8,16);
		SetTileProp(tilemap, 49,11,0,1,8,16);
		SetTileProp(tilemap, 49,12,0,1,8,16);
		SetTileProp(tilemap, 49,13,0,1,8,16);
		SetTileProp(tilemap, 49,14,0,1,8,16);
		SetTileProp(tilemap, 49,15,0,1,4,16);
		SetTileProp(tilemap, 49,16,0,1,8,16);
		SetTileProp(tilemap, 49,17,0,1,4,16);
		SetTileProp(tilemap, 49,18,0,1,4,16);
		SetTileProp(tilemap, 49,19,0,1,4,16);
		SetTileProp(tilemap, 49,20,0,1,8,16);
		SetTileProp(tilemap, 49,21,0,1,8,16);
		SetTileProp(tilemap, 49,22,0,1,4,8);
		SetTileProp(tilemap, 49,23,0,1,4,8);
		SetTileProp(tilemap, 49,24,0,1,4,8);
		SetTileProp(tilemap, 49,25,0,1,4,8);
		SetTileProp(tilemap, 49,26,0,1,4,0);
		SetTileProp(tilemap, 49,27,1,1,24,0);
		SetTileProp(tilemap, 49,28,1,1,24,0);
		SetTileProp(tilemap, 49,29,1,1,1,23);
		SetTileProp(tilemap, 49,30,1,1,0,4);
		SetTileProp(tilemap, 49,31,1,1,1,0);
		SetTileProp(tilemap, 49,32,1,1,1,1);
		SetTileProp(tilemap, 49,33,1,1,1,0);
		SetTileProp(tilemap, 49,34,1,1,0,0);
		SetTileProp(tilemap, 49,35,0,1,0,0);
		SetTileProp(tilemap, 49,36,1,1,16,8);
		SetTileProp(tilemap, 49,37,1,1,0,0);
		SetTileProp(tilemap, 49,38,1,1,24,0);
		SetTileProp(tilemap, 49,39,1,1,24,0);
		SetTileProp(tilemap, 49,40,0,1,4,0);
		SetTileProp(tilemap, 49,41,0,1,4,0);
		SetTileProp(tilemap, 49,42,0,1,4,0);
		SetTileProp(tilemap, 49,43,0,1,4,0);
		SetTileProp(tilemap, 49,44,0,1,4,20);
		SetTileProp(tilemap, 49,45,0,1,8,20);
		SetTileProp(tilemap, 49,46,0,1,4,21);
		SetTileProp(tilemap, 49,47,0,1,4,21);
		SetTileProp(tilemap, 49,48,0,1,4,21);
		SetTileProp(tilemap, 49,49,0,1,8,16);
		SetTileProp(tilemap, 49,50,0,1,8,16);
		SetTileProp(tilemap, 49,51,0,1,8,16);
		SetTileProp(tilemap, 49,52,0,1,4,24);
		SetTileProp(tilemap, 49,53,0,1,8,16);
		SetTileProp(tilemap, 49,54,0,1,8,16);
		SetTileProp(tilemap, 49,55,0,1,8,16);
		SetTileProp(tilemap, 49,56,0,1,8,16);
		SetTileProp(tilemap, 49,57,0,1,0,0);
		SetTileProp(tilemap, 49,58,0,1,0,0);
		SetTileProp(tilemap, 49,59,0,1,0,0);
		SetTileProp(tilemap, 49,60,0,1,0,0);
		SetTileProp(tilemap, 49,61,0,1,0,0);
		SetTileProp(tilemap, 49,62,0,1,0,0);
		SetTileProp(tilemap, 50,0,0,1,4,0);
		SetTileProp(tilemap, 50,1,0,1,4,0);
		SetTileProp(tilemap, 50,2,0,1,4,0);
		SetTileProp(tilemap, 50,3,0,1,4,0);
		SetTileProp(tilemap, 50,4,0,1,4,0);
		SetTileProp(tilemap, 50,5,0,1,4,0);
		SetTileProp(tilemap, 50,6,0,1,4,0);
		SetTileProp(tilemap, 50,7,0,1,8,16);
		SetTileProp(tilemap, 50,8,0,1,8,16);
		SetTileProp(tilemap, 50,9,0,1,8,16);
		SetTileProp(tilemap, 50,10,0,1,8,16);
		SetTileProp(tilemap, 50,11,0,1,8,16);
		SetTileProp(tilemap, 50,12,0,1,8,16);
		SetTileProp(tilemap, 50,13,0,1,8,16);
		SetTileProp(tilemap, 50,14,0,1,8,16);
		SetTileProp(tilemap, 50,15,0,1,4,16);
		SetTileProp(tilemap, 50,16,0,1,4,16);
		SetTileProp(tilemap, 50,17,0,1,4,16);
		SetTileProp(tilemap, 50,18,0,1,4,16);
		SetTileProp(tilemap, 50,19,0,1,4,16);
		SetTileProp(tilemap, 50,20,0,1,8,16);
		SetTileProp(tilemap, 50,21,0,1,8,16);
		SetTileProp(tilemap, 50,22,0,1,8,16);
		SetTileProp(tilemap, 50,23,0,1,8,16);
		SetTileProp(tilemap, 50,24,0,1,8,16);
		SetTileProp(tilemap, 50,25,0,1,8,16);
		SetTileProp(tilemap, 50,26,0,1,4,0);
		SetTileProp(tilemap, 50,27,1,1,24,0);
		SetTileProp(tilemap, 50,28,1,1,24,0);
		SetTileProp(tilemap, 50,29,0,1,4,0);
		SetTileProp(tilemap, 50,30,1,1,11,7);
		SetTileProp(tilemap, 50,31,1,1,6,0);
		SetTileProp(tilemap, 50,32,1,1,0,0);
		SetTileProp(tilemap, 50,33,1,1,0,0);
		SetTileProp(tilemap, 50,34,1,1,0,0);
		SetTileProp(tilemap, 50,35,0,1,0,0);
		SetTileProp(tilemap, 50,36,1,1,16,8);
		SetTileProp(tilemap, 50,37,1,1,0,20);
		SetTileProp(tilemap, 50,38,1,1,24,0);
		SetTileProp(tilemap, 50,39,1,1,24,0);
		SetTileProp(tilemap, 50,40,0,1,4,21);
		SetTileProp(tilemap, 50,41,0,1,4,21);
		SetTileProp(tilemap, 50,42,0,1,4,21);
		SetTileProp(tilemap, 50,43,0,1,4,21);
		SetTileProp(tilemap, 50,44,0,1,4,24);
		SetTileProp(tilemap, 50,45,0,1,4,21);
		SetTileProp(tilemap, 50,46,0,1,4,21);
		SetTileProp(tilemap, 50,47,0,1,4,21);
		SetTileProp(tilemap, 50,48,0,1,8,16);
		SetTileProp(tilemap, 50,49,0,1,8,16);
		SetTileProp(tilemap, 50,50,0,1,8,16);
		SetTileProp(tilemap, 50,51,0,1,8,16);
		SetTileProp(tilemap, 50,52,0,1,4,24);
		SetTileProp(tilemap, 50,53,0,1,8,16);
		SetTileProp(tilemap, 50,54,0,1,8,16);
		SetTileProp(tilemap, 50,55,0,1,8,16);
		SetTileProp(tilemap, 50,56,0,1,8,16);
		SetTileProp(tilemap, 50,57,0,1,0,0);
		SetTileProp(tilemap, 50,58,0,1,0,0);
		SetTileProp(tilemap, 50,59,0,1,0,0);
		SetTileProp(tilemap, 50,60,0,1,0,0);
		SetTileProp(tilemap, 50,61,0,1,0,0);
		SetTileProp(tilemap, 50,62,0,1,0,0);
		SetTileProp(tilemap, 51,0,0,1,4,0);
		SetTileProp(tilemap, 51,1,0,1,4,0);
		SetTileProp(tilemap, 51,2,0,1,4,0);
		SetTileProp(tilemap, 51,3,0,1,4,0);
		SetTileProp(tilemap, 51,4,0,1,4,0);
		SetTileProp(tilemap, 51,5,0,1,4,0);
		SetTileProp(tilemap, 51,6,0,1,4,0);
		SetTileProp(tilemap, 51,7,0,1,8,16);
		SetTileProp(tilemap, 51,8,0,1,8,16);
		SetTileProp(tilemap, 51,9,0,1,8,16);
		SetTileProp(tilemap, 51,10,0,1,8,16);
		SetTileProp(tilemap, 51,11,0,1,8,16);
		SetTileProp(tilemap, 51,12,0,1,8,16);
		SetTileProp(tilemap, 51,13,0,1,8,16);
		SetTileProp(tilemap, 51,14,0,1,8,16);
		SetTileProp(tilemap, 51,15,0,1,4,16);
		SetTileProp(tilemap, 51,16,0,1,4,16);
		SetTileProp(tilemap, 51,17,0,1,4,16);
		SetTileProp(tilemap, 51,18,0,1,4,16);
		SetTileProp(tilemap, 51,19,0,1,4,16);
		SetTileProp(tilemap, 51,20,0,1,4,25);
		SetTileProp(tilemap, 51,21,0,1,4,8);
		SetTileProp(tilemap, 51,22,0,1,8,16);
		SetTileProp(tilemap, 51,23,0,1,8,16);
		SetTileProp(tilemap, 51,24,0,1,8,16);
		SetTileProp(tilemap, 51,25,0,1,8,16);
		SetTileProp(tilemap, 51,26,0,1,0,4);
		SetTileProp(tilemap, 51,27,0,1,24,0);
		SetTileProp(tilemap, 51,28,1,1,24,0);
		SetTileProp(tilemap, 51,29,1,1,24,0);
		SetTileProp(tilemap, 51,30,0,1,0,4);
		SetTileProp(tilemap, 51,31,1,1,24,0);
		SetTileProp(tilemap, 51,32,1,1,24,0);
		SetTileProp(tilemap, 51,33,0,1,0,4);
		SetTileProp(tilemap, 51,34,0,1,0,4);
		SetTileProp(tilemap, 51,35,0,1,4,0);
		SetTileProp(tilemap, 51,36,1,1,16,8);
		SetTileProp(tilemap, 51,37,1,1,0,16);
		SetTileProp(tilemap, 51,38,0,1,4,4);
		SetTileProp(tilemap, 51,39,1,1,24,0);
		SetTileProp(tilemap, 51,40,0,1,4,21);
		SetTileProp(tilemap, 51,41,0,1,4,21);
		SetTileProp(tilemap, 51,42,0,1,4,21);
		SetTileProp(tilemap, 51,43,0,1,4,21);
		SetTileProp(tilemap, 51,44,0,1,4,21);
		SetTileProp(tilemap, 51,45,0,1,4,21);
		SetTileProp(tilemap, 51,46,0,1,4,21);
		SetTileProp(tilemap, 51,47,0,1,8,16);
		SetTileProp(tilemap, 51,48,0,1,8,16);
		SetTileProp(tilemap, 51,49,0,1,8,16);
		SetTileProp(tilemap, 51,50,0,1,8,16);
		SetTileProp(tilemap, 51,51,0,1,8,16);
		SetTileProp(tilemap, 51,52,0,1,8,16);
		SetTileProp(tilemap, 51,53,0,1,8,16);
		SetTileProp(tilemap, 51,54,0,1,8,16);
		SetTileProp(tilemap, 51,55,0,1,8,16);
		SetTileProp(tilemap, 51,56,0,1,8,16);
		SetTileProp(tilemap, 51,57,0,1,0,0);
		SetTileProp(tilemap, 51,58,0,1,0,0);
		SetTileProp(tilemap, 51,59,0,1,0,0);
		SetTileProp(tilemap, 51,60,0,1,0,0);
		SetTileProp(tilemap, 51,61,0,1,0,0);
		SetTileProp(tilemap, 51,62,0,1,0,0);
		SetTileProp(tilemap, 52,0,0,1,4,0);
		SetTileProp(tilemap, 52,1,0,1,4,0);
		SetTileProp(tilemap, 52,2,0,1,4,0);
		SetTileProp(tilemap, 52,3,0,1,4,0);
		SetTileProp(tilemap, 52,4,0,1,4,0);
		SetTileProp(tilemap, 52,5,0,1,4,0);
		SetTileProp(tilemap, 52,6,0,1,4,0);
		SetTileProp(tilemap, 52,7,0,1,8,16);
		SetTileProp(tilemap, 52,8,0,1,8,16);
		SetTileProp(tilemap, 52,9,0,1,8,20);
		SetTileProp(tilemap, 52,10,0,1,8,20);
		SetTileProp(tilemap, 52,11,0,1,8,20);
		SetTileProp(tilemap, 52,12,0,1,8,20);
		SetTileProp(tilemap, 52,13,0,1,8,20);
		SetTileProp(tilemap, 52,14,0,1,8,16);
		SetTileProp(tilemap, 52,15,0,1,4,16);
		SetTileProp(tilemap, 52,16,0,1,4,16);
		SetTileProp(tilemap, 52,17,0,1,4,16);
		SetTileProp(tilemap, 52,18,0,1,4,16);
		SetTileProp(tilemap, 52,19,0,1,4,16);
		SetTileProp(tilemap, 52,20,0,1,4,24);
		SetTileProp(tilemap, 52,21,0,1,4,8);
		SetTileProp(tilemap, 52,22,0,1,8,16);
		SetTileProp(tilemap, 52,23,0,1,4,8);
		SetTileProp(tilemap, 52,24,0,1,8,16);
		SetTileProp(tilemap, 52,25,0,1,4,8);
		SetTileProp(tilemap, 52,26,0,1,4,0);
		SetTileProp(tilemap, 52,27,0,1,24,0);
		SetTileProp(tilemap, 52,28,1,1,24,0);
		SetTileProp(tilemap, 52,29,1,1,24,0);
		SetTileProp(tilemap, 52,30,0,1,24,0);
		SetTileProp(tilemap, 52,31,1,1,24,0);
		SetTileProp(tilemap, 52,32,1,1,24,0);
		SetTileProp(tilemap, 52,33,7,1,20,0);
		SetTileProp(tilemap, 52,34,7,1,16,0);
		SetTileProp(tilemap, 52,35,7,1,16,4);
		SetTileProp(tilemap, 52,36,1,1,16,8);
		SetTileProp(tilemap, 52,37,0,1,0,27);
		SetTileProp(tilemap, 52,38,0,1,4,0);
		SetTileProp(tilemap, 52,39,1,1,24,0);
		SetTileProp(tilemap, 52,40,0,1,4,21);
		SetTileProp(tilemap, 52,41,0,1,4,21);
		SetTileProp(tilemap, 52,42,0,1,4,21);
		SetTileProp(tilemap, 52,43,0,1,4,21);
		SetTileProp(tilemap, 52,44,0,1,4,24);
		SetTileProp(tilemap, 52,45,0,1,4,24);
		SetTileProp(tilemap, 52,46,0,1,8,16);
		SetTileProp(tilemap, 52,47,0,1,8,16);
		SetTileProp(tilemap, 52,48,0,1,8,16);
		SetTileProp(tilemap, 52,49,0,1,8,16);
		SetTileProp(tilemap, 52,50,0,1,8,16);
		SetTileProp(tilemap, 52,51,0,1,8,16);
		SetTileProp(tilemap, 52,52,0,1,8,16);
		SetTileProp(tilemap, 52,53,0,1,8,16);
		SetTileProp(tilemap, 52,54,0,1,8,16);
		SetTileProp(tilemap, 52,55,0,1,8,16);
		SetTileProp(tilemap, 52,56,0,1,8,16);
		SetTileProp(tilemap, 52,57,0,1,0,0);
		SetTileProp(tilemap, 52,58,0,1,0,0);
		SetTileProp(tilemap, 52,59,0,1,0,0);
		SetTileProp(tilemap, 52,60,0,1,0,0);
		SetTileProp(tilemap, 52,61,0,1,0,0);
		SetTileProp(tilemap, 52,62,0,1,0,0);
		SetTileProp(tilemap, 53,0,0,1,4,0);
		SetTileProp(tilemap, 53,1,0,1,4,0);
		SetTileProp(tilemap, 53,2,0,1,4,0);
		SetTileProp(tilemap, 53,3,0,1,4,0);
		SetTileProp(tilemap, 53,4,0,1,4,0);
		SetTileProp(tilemap, 53,5,0,1,4,0);
		SetTileProp(tilemap, 53,6,0,1,4,0);
		SetTileProp(tilemap, 53,7,0,1,8,16);
		SetTileProp(tilemap, 53,8,0,1,8,16);
		SetTileProp(tilemap, 53,9,0,1,8,20);
		SetTileProp(tilemap, 53,10,0,1,4,20);
		SetTileProp(tilemap, 53,11,0,1,4,20);
		SetTileProp(tilemap, 53,12,0,1,4,20);
		SetTileProp(tilemap, 53,13,0,1,8,20);
		SetTileProp(tilemap, 53,14,0,1,8,16);
		SetTileProp(tilemap, 53,15,0,1,4,16);
		SetTileProp(tilemap, 53,16,0,1,4,16);
		SetTileProp(tilemap, 53,17,0,1,4,16);
		SetTileProp(tilemap, 53,18,0,1,4,16);
		SetTileProp(tilemap, 53,19,0,1,4,16);
		SetTileProp(tilemap, 53,20,0,1,4,24);
		SetTileProp(tilemap, 53,21,0,1,4,8);
		SetTileProp(tilemap, 53,22,0,1,8,16);
		SetTileProp(tilemap, 53,23,0,1,4,8);
		SetTileProp(tilemap, 53,24,0,1,8,16);
		SetTileProp(tilemap, 53,25,0,1,4,8);
		SetTileProp(tilemap, 53,26,0,1,14,0);
		SetTileProp(tilemap, 53,27,0,1,4,0);
		SetTileProp(tilemap, 53,28,0,1,4,0);
		SetTileProp(tilemap, 53,29,1,1,24,0);
		SetTileProp(tilemap, 53,30,1,1,24,0);
		SetTileProp(tilemap, 53,31,1,1,24,0);
		SetTileProp(tilemap, 53,32,2,1,24,0);
		SetTileProp(tilemap, 53,33,0,1,4,0);
		SetTileProp(tilemap, 53,34,0,1,0,6);
		SetTileProp(tilemap, 53,35,4,1,24,0);
		SetTileProp(tilemap, 53,36,1,1,24,0);
		SetTileProp(tilemap, 53,37,1,1,24,0);
		SetTileProp(tilemap, 53,38,1,1,24,0);
		SetTileProp(tilemap, 53,39,1,1,24,0);
		SetTileProp(tilemap, 53,40,0,1,8,16);
		SetTileProp(tilemap, 53,41,0,1,4,16);
		SetTileProp(tilemap, 53,42,0,1,4,16);
		SetTileProp(tilemap, 53,43,0,1,4,16);
		SetTileProp(tilemap, 53,44,0,1,4,16);
		SetTileProp(tilemap, 53,45,0,1,8,16);
		SetTileProp(tilemap, 53,46,0,1,8,16);
		SetTileProp(tilemap, 53,47,0,1,8,16);
		SetTileProp(tilemap, 53,48,0,1,8,16);
		SetTileProp(tilemap, 53,49,0,1,8,16);
		SetTileProp(tilemap, 53,50,0,1,8,16);
		SetTileProp(tilemap, 53,51,0,1,8,16);
		SetTileProp(tilemap, 53,52,0,1,8,16);
		SetTileProp(tilemap, 53,53,0,1,8,16);
		SetTileProp(tilemap, 53,54,0,1,8,16);
		SetTileProp(tilemap, 53,55,0,1,8,16);
		SetTileProp(tilemap, 53,56,0,1,8,16);
		SetTileProp(tilemap, 53,57,0,1,0,0);
		SetTileProp(tilemap, 53,58,0,1,0,0);
		SetTileProp(tilemap, 53,59,0,1,0,0);
		SetTileProp(tilemap, 53,60,0,1,0,0);
		SetTileProp(tilemap, 53,61,0,1,0,0);
		SetTileProp(tilemap, 53,62,0,1,0,0);
		SetTileProp(tilemap, 54,0,0,1,4,0);
		SetTileProp(tilemap, 54,1,0,1,4,0);
		SetTileProp(tilemap, 54,2,0,1,4,0);
		SetTileProp(tilemap, 54,3,0,1,4,0);
		SetTileProp(tilemap, 54,4,0,1,4,0);
		SetTileProp(tilemap, 54,5,0,1,4,0);
		SetTileProp(tilemap, 54,6,0,1,4,0);
		SetTileProp(tilemap, 54,7,0,1,8,16);
		SetTileProp(tilemap, 54,8,0,1,8,16);
		SetTileProp(tilemap, 54,9,0,1,8,20);
		SetTileProp(tilemap, 54,10,0,1,4,20);
		SetTileProp(tilemap, 54,11,0,1,8,20);
		SetTileProp(tilemap, 54,12,0,1,4,20);
		SetTileProp(tilemap, 54,13,0,1,8,20);
		SetTileProp(tilemap, 54,14,0,1,8,16);
		SetTileProp(tilemap, 54,15,0,1,4,16);
		SetTileProp(tilemap, 54,16,0,1,4,16);
		SetTileProp(tilemap, 54,17,0,1,4,16);
		SetTileProp(tilemap, 54,18,0,1,4,16);
		SetTileProp(tilemap, 54,19,0,1,4,16);
		SetTileProp(tilemap, 54,20,0,1,4,16);
		SetTileProp(tilemap, 54,21,0,1,4,16);
		SetTileProp(tilemap, 54,22,0,1,8,16);
		SetTileProp(tilemap, 54,23,0,1,4,16);
		SetTileProp(tilemap, 54,24,0,1,8,16);
		SetTileProp(tilemap, 54,25,0,1,8,16);
		SetTileProp(tilemap, 54,26,0,1,8,0);
		SetTileProp(tilemap, 54,27,0,1,8,0);
		SetTileProp(tilemap, 54,28,0,1,8,0);
		SetTileProp(tilemap, 54,29,0,1,8,0);
		SetTileProp(tilemap, 54,30,0,1,8,0);
		SetTileProp(tilemap, 54,31,5,1,24,0);
		SetTileProp(tilemap, 54,32,1,1,24,0);
		SetTileProp(tilemap, 54,33,1,1,24,0);
		SetTileProp(tilemap, 54,34,1,1,24,0);
		SetTileProp(tilemap, 54,35,1,1,24,0);
		SetTileProp(tilemap, 54,36,3,1,24,0);
		SetTileProp(tilemap, 54,37,0,1,8,0);
		SetTileProp(tilemap, 54,38,0,1,8,0);
		SetTileProp(tilemap, 54,39,0,1,8,16);
		SetTileProp(tilemap, 54,40,0,1,8,16);
		SetTileProp(tilemap, 54,41,0,1,4,16);
		SetTileProp(tilemap, 54,42,0,1,4,16);
		SetTileProp(tilemap, 54,43,0,1,4,16);
		SetTileProp(tilemap, 54,44,0,1,4,16);
		SetTileProp(tilemap, 54,45,0,1,8,16);
		SetTileProp(tilemap, 54,46,0,1,8,16);
		SetTileProp(tilemap, 54,47,0,1,8,16);
		SetTileProp(tilemap, 54,48,0,1,8,16);
		SetTileProp(tilemap, 54,49,0,1,8,16);
		SetTileProp(tilemap, 54,50,0,1,8,16);
		SetTileProp(tilemap, 54,51,0,1,8,16);
		SetTileProp(tilemap, 54,52,0,1,8,16);
		SetTileProp(tilemap, 54,53,0,1,8,16);
		SetTileProp(tilemap, 54,54,0,1,8,16);
		SetTileProp(tilemap, 54,55,0,1,8,16);
		SetTileProp(tilemap, 54,56,0,1,8,16);
		SetTileProp(tilemap, 54,57,0,1,0,0);
		SetTileProp(tilemap, 54,58,0,1,0,0);
		SetTileProp(tilemap, 54,59,0,1,0,0);
		SetTileProp(tilemap, 54,60,0,1,0,0);
		SetTileProp(tilemap, 54,61,0,1,0,0);
		SetTileProp(tilemap, 54,62,0,1,0,0);
		SetTileProp(tilemap, 55,0,0,1,4,0);
		SetTileProp(tilemap, 55,1,0,1,4,0);
		SetTileProp(tilemap, 55,2,0,1,4,0);
		SetTileProp(tilemap, 55,3,0,1,4,0);
		SetTileProp(tilemap, 55,4,0,1,4,0);
		SetTileProp(tilemap, 55,5,0,1,4,0);
		SetTileProp(tilemap, 55,6,0,1,4,0);
		SetTileProp(tilemap, 55,7,0,1,4,0);
		SetTileProp(tilemap, 55,8,0,1,4,0);
		SetTileProp(tilemap, 55,9,0,1,4,20);
		SetTileProp(tilemap, 55,10,0,1,4,20);
		SetTileProp(tilemap, 55,11,0,1,4,20);
		SetTileProp(tilemap, 55,12,0,1,4,20);
		SetTileProp(tilemap, 55,13,0,1,4,20);
		SetTileProp(tilemap, 55,14,0,1,4,0);
		SetTileProp(tilemap, 55,15,0,1,4,0);
		SetTileProp(tilemap, 55,16,0,1,4,0);
		SetTileProp(tilemap, 55,17,0,1,4,0);
		SetTileProp(tilemap, 55,18,0,1,4,0);
		SetTileProp(tilemap, 55,19,0,1,4,0);
		SetTileProp(tilemap, 55,20,0,1,8,16);
		SetTileProp(tilemap, 55,21,0,1,8,16);
		SetTileProp(tilemap, 55,22,0,1,8,16);
		SetTileProp(tilemap, 55,23,0,1,8,16);
		SetTileProp(tilemap, 55,24,0,1,8,16);
		SetTileProp(tilemap, 55,25,0,1,8,16);
		SetTileProp(tilemap, 55,26,0,1,8,16);
		SetTileProp(tilemap, 55,27,0,1,8,16);
		SetTileProp(tilemap, 55,28,0,1,8,16);
		SetTileProp(tilemap, 55,29,0,1,8,16);
		SetTileProp(tilemap, 55,30,0,1,8,16);
		SetTileProp(tilemap, 55,31,0,1,8,16);
		SetTileProp(tilemap, 55,32,0,1,8,16);
		SetTileProp(tilemap, 55,33,0,1,8,24);
		SetTileProp(tilemap, 55,34,0,1,8,16);
		SetTileProp(tilemap, 55,35,0,1,8,24);
		SetTileProp(tilemap, 55,36,0,1,8,16);
		SetTileProp(tilemap, 55,37,0,1,8,24);
		SetTileProp(tilemap, 55,38,0,1,8,16);
		SetTileProp(tilemap, 55,39,0,1,8,16);
		SetTileProp(tilemap, 55,40,0,1,8,16);
		SetTileProp(tilemap, 55,41,0,1,4,0);
		SetTileProp(tilemap, 55,42,0,1,4,0);
		SetTileProp(tilemap, 55,43,0,1,4,0);
		SetTileProp(tilemap, 55,44,0,1,4,0);
		SetTileProp(tilemap, 55,45,0,1,4,0);
		SetTileProp(tilemap, 55,46,0,1,4,0);
		SetTileProp(tilemap, 55,47,0,1,4,0);
		SetTileProp(tilemap, 55,48,0,1,4,0);
		SetTileProp(tilemap, 55,49,0,1,4,0);
		SetTileProp(tilemap, 55,50,0,1,4,0);
		SetTileProp(tilemap, 55,51,0,1,4,0);
		SetTileProp(tilemap, 55,52,0,1,4,0);
		SetTileProp(tilemap, 55,53,0,1,4,0);
		SetTileProp(tilemap, 55,54,0,1,0,0);
		SetTileProp(tilemap, 55,55,0,1,0,0);
		SetTileProp(tilemap, 55,56,0,1,0,0);
		SetTileProp(tilemap, 55,57,0,1,0,0);
		SetTileProp(tilemap, 55,58,0,1,0,0);
		SetTileProp(tilemap, 55,59,0,1,0,0);
		SetTileProp(tilemap, 55,60,0,1,0,0);
		SetTileProp(tilemap, 55,61,0,1,0,0);
		SetTileProp(tilemap, 55,62,0,1,0,0);
		SetTileProp(tilemap, 56,0,0,1,4,0);
		SetTileProp(tilemap, 56,1,0,1,4,0);
		SetTileProp(tilemap, 56,2,0,1,4,0);
		SetTileProp(tilemap, 56,3,0,1,4,0);
		SetTileProp(tilemap, 56,4,0,1,4,0);
		SetTileProp(tilemap, 56,5,0,1,4,0);
		SetTileProp(tilemap, 56,6,0,1,4,0);
		SetTileProp(tilemap, 56,7,0,1,4,0);
		SetTileProp(tilemap, 56,8,0,1,4,0);
		SetTileProp(tilemap, 56,9,0,1,4,0);
		SetTileProp(tilemap, 56,10,0,1,4,0);
		SetTileProp(tilemap, 56,11,0,1,4,0);
		SetTileProp(tilemap, 56,12,0,1,4,0);
		SetTileProp(tilemap, 56,13,0,1,4,0);
		SetTileProp(tilemap, 56,14,0,1,4,0);
		SetTileProp(tilemap, 56,15,0,1,4,0);
		SetTileProp(tilemap, 56,16,0,1,4,0);
		SetTileProp(tilemap, 56,17,0,1,4,0);
		SetTileProp(tilemap, 56,18,0,1,4,0);
		SetTileProp(tilemap, 56,19,0,1,4,0);
		SetTileProp(tilemap, 56,20,0,1,4,0);
		SetTileProp(tilemap, 56,21,0,1,4,0);
		SetTileProp(tilemap, 56,22,0,1,4,0);
		SetTileProp(tilemap, 56,23,0,1,4,0);
		SetTileProp(tilemap, 56,24,0,1,4,0);
		SetTileProp(tilemap, 56,25,0,1,4,0);
		SetTileProp(tilemap, 56,26,0,1,4,0);
		SetTileProp(tilemap, 56,27,0,1,4,0);
		SetTileProp(tilemap, 56,28,0,1,4,0);
		SetTileProp(tilemap, 56,29,0,1,4,0);
		SetTileProp(tilemap, 56,30,0,1,4,0);
		SetTileProp(tilemap, 56,31,0,1,4,0);
		SetTileProp(tilemap, 56,32,0,1,4,0);
		SetTileProp(tilemap, 56,33,0,1,4,0);
		SetTileProp(tilemap, 56,34,0,1,4,0);
		SetTileProp(tilemap, 56,35,0,1,4,0);
		SetTileProp(tilemap, 56,36,0,1,4,0);
		SetTileProp(tilemap, 56,37,0,1,4,0);
		SetTileProp(tilemap, 56,38,0,1,4,0);
		SetTileProp(tilemap, 56,39,0,1,4,0);
		SetTileProp(tilemap, 56,40,0,1,4,0);
		SetTileProp(tilemap, 56,41,0,1,4,0);
		SetTileProp(tilemap, 56,42,0,1,4,0);
		SetTileProp(tilemap, 56,43,0,1,4,0);
		SetTileProp(tilemap, 56,44,0,1,4,0);
		SetTileProp(tilemap, 56,45,0,1,4,0);
		SetTileProp(tilemap, 56,46,0,1,4,0);
		SetTileProp(tilemap, 56,47,0,1,4,0);
		SetTileProp(tilemap, 56,48,0,1,4,0);
		SetTileProp(tilemap, 56,49,0,1,4,0);
		SetTileProp(tilemap, 56,50,0,1,4,0);
		SetTileProp(tilemap, 56,51,0,1,4,0);
		SetTileProp(tilemap, 56,52,0,1,4,0);
		SetTileProp(tilemap, 56,53,0,1,4,0);
		SetTileProp(tilemap, 56,54,0,1,0,0);
		SetTileProp(tilemap, 56,55,0,1,0,0);
		SetTileProp(tilemap, 56,56,0,1,0,0);
		SetTileProp(tilemap, 56,57,0,1,0,0);
		SetTileProp(tilemap, 56,58,0,1,0,0);
		SetTileProp(tilemap, 56,59,0,1,0,0);
		SetTileProp(tilemap, 56,60,0,1,0,0);
		SetTileProp(tilemap, 56,61,0,1,0,0);
		SetTileProp(tilemap, 56,62,0,1,0,0);
		SetTileProp(tilemap, 57,0,0,1,4,0);
		SetTileProp(tilemap, 57,1,0,1,4,0);
		SetTileProp(tilemap, 57,2,0,1,4,0);
		SetTileProp(tilemap, 57,3,0,1,4,0);
		SetTileProp(tilemap, 57,4,0,1,4,0);
		SetTileProp(tilemap, 57,5,0,1,4,0);
		SetTileProp(tilemap, 57,6,0,1,4,0);
		SetTileProp(tilemap, 57,7,0,1,4,0);
		SetTileProp(tilemap, 57,8,0,1,4,0);
		SetTileProp(tilemap, 57,9,0,1,4,0);
		SetTileProp(tilemap, 57,10,0,1,4,0);
		SetTileProp(tilemap, 57,11,0,1,4,0);
		SetTileProp(tilemap, 57,12,0,1,4,0);
		SetTileProp(tilemap, 57,13,0,1,4,0);
		SetTileProp(tilemap, 57,14,0,1,4,0);
		SetTileProp(tilemap, 57,15,0,1,4,0);
		SetTileProp(tilemap, 57,16,0,1,4,0);
		SetTileProp(tilemap, 57,17,0,1,4,0);
		SetTileProp(tilemap, 57,18,0,1,4,0);
		SetTileProp(tilemap, 57,19,0,1,4,0);
		SetTileProp(tilemap, 57,20,0,1,4,0);
		SetTileProp(tilemap, 57,21,0,1,4,0);
		SetTileProp(tilemap, 57,22,0,1,4,0);
		SetTileProp(tilemap, 57,23,0,1,4,0);
		SetTileProp(tilemap, 57,24,0,1,4,0);
		SetTileProp(tilemap, 57,25,0,1,4,0);
		SetTileProp(tilemap, 57,26,0,1,4,0);
		SetTileProp(tilemap, 57,27,0,1,4,0);
		SetTileProp(tilemap, 57,28,0,1,4,0);
		SetTileProp(tilemap, 57,29,0,1,4,0);
		SetTileProp(tilemap, 57,30,0,1,4,0);
		SetTileProp(tilemap, 57,31,0,1,4,0);
		SetTileProp(tilemap, 57,32,0,1,4,0);
		SetTileProp(tilemap, 57,33,0,1,4,0);
		SetTileProp(tilemap, 57,34,0,1,4,0);
		SetTileProp(tilemap, 57,35,0,1,4,0);
		SetTileProp(tilemap, 57,36,0,1,4,0);
		SetTileProp(tilemap, 57,37,0,1,4,0);
		SetTileProp(tilemap, 57,38,0,1,4,0);
		SetTileProp(tilemap, 57,39,0,1,4,0);
		SetTileProp(tilemap, 57,40,0,1,4,0);
		SetTileProp(tilemap, 57,41,0,1,4,0);
		SetTileProp(tilemap, 57,42,0,1,4,0);
		SetTileProp(tilemap, 57,43,0,1,4,0);
		SetTileProp(tilemap, 57,44,0,1,4,0);
		SetTileProp(tilemap, 57,45,0,1,4,0);
		SetTileProp(tilemap, 57,46,0,1,4,0);
		SetTileProp(tilemap, 57,47,0,1,4,0);
		SetTileProp(tilemap, 57,48,0,1,4,0);
		SetTileProp(tilemap, 57,49,0,1,4,0);
		SetTileProp(tilemap, 57,50,0,1,4,0);
		SetTileProp(tilemap, 57,51,0,1,4,0);
		SetTileProp(tilemap, 57,52,0,1,4,0);
		SetTileProp(tilemap, 57,53,0,1,4,0);
		SetTileProp(tilemap, 57,54,0,1,0,0);
		SetTileProp(tilemap, 57,55,0,1,0,0);
		SetTileProp(tilemap, 57,56,0,1,0,0);
		SetTileProp(tilemap, 57,57,0,1,0,0);
		SetTileProp(tilemap, 57,58,0,1,0,0);
		SetTileProp(tilemap, 57,59,0,1,0,0);
		SetTileProp(tilemap, 57,60,0,1,0,0);
		SetTileProp(tilemap, 57,61,0,1,0,0);
		SetTileProp(tilemap, 57,62,0,1,0,0);
		SetTileProp(tilemap, 58,0,0,1,4,0);
		SetTileProp(tilemap, 58,1,0,1,4,0);
		SetTileProp(tilemap, 58,2,0,1,4,0);
		SetTileProp(tilemap, 58,3,0,1,4,0);
		SetTileProp(tilemap, 58,4,0,1,4,0);
		SetTileProp(tilemap, 58,5,0,1,4,0);
		SetTileProp(tilemap, 58,6,0,1,4,0);
		SetTileProp(tilemap, 58,7,0,1,4,0);
		SetTileProp(tilemap, 58,8,0,1,4,0);
		SetTileProp(tilemap, 58,9,0,1,4,0);
		SetTileProp(tilemap, 58,10,0,1,4,0);
		SetTileProp(tilemap, 58,11,0,1,4,0);
		SetTileProp(tilemap, 58,12,0,1,4,0);
		SetTileProp(tilemap, 58,13,0,1,4,0);
		SetTileProp(tilemap, 58,14,0,1,4,0);
		SetTileProp(tilemap, 58,15,0,1,4,0);
		SetTileProp(tilemap, 58,16,0,1,4,0);
		SetTileProp(tilemap, 58,17,0,1,4,0);
		SetTileProp(tilemap, 58,18,0,1,4,0);
		SetTileProp(tilemap, 58,19,0,1,4,0);
		SetTileProp(tilemap, 58,20,0,1,4,0);
		SetTileProp(tilemap, 58,21,0,1,4,0);
		SetTileProp(tilemap, 58,22,0,1,4,0);
		SetTileProp(tilemap, 58,23,0,1,4,0);
		SetTileProp(tilemap, 58,24,0,1,4,0);
		SetTileProp(tilemap, 58,25,0,1,4,0);
		SetTileProp(tilemap, 58,26,0,1,4,0);
		SetTileProp(tilemap, 58,27,0,1,4,0);
		SetTileProp(tilemap, 58,28,0,1,4,0);
		SetTileProp(tilemap, 58,29,0,1,4,0);
		SetTileProp(tilemap, 58,30,0,1,4,0);
		SetTileProp(tilemap, 58,31,0,1,4,0);
		SetTileProp(tilemap, 58,32,0,1,4,0);
		SetTileProp(tilemap, 58,33,0,1,4,0);
		SetTileProp(tilemap, 58,34,0,1,4,0);
		SetTileProp(tilemap, 58,35,0,1,4,0);
		SetTileProp(tilemap, 58,36,0,1,4,0);
		SetTileProp(tilemap, 58,37,0,1,4,0);
		SetTileProp(tilemap, 58,38,0,1,4,0);
		SetTileProp(tilemap, 58,39,0,1,4,0);
		SetTileProp(tilemap, 58,40,0,1,4,0);
		SetTileProp(tilemap, 58,41,0,1,4,0);
		SetTileProp(tilemap, 58,42,0,1,4,0);
		SetTileProp(tilemap, 58,43,0,1,4,0);
		SetTileProp(tilemap, 58,44,0,1,4,0);
		SetTileProp(tilemap, 58,45,0,1,4,0);
		SetTileProp(tilemap, 58,46,0,1,4,0);
		SetTileProp(tilemap, 58,47,0,1,4,0);
		SetTileProp(tilemap, 58,48,0,1,4,0);
		SetTileProp(tilemap, 58,49,0,1,4,0);
		SetTileProp(tilemap, 58,50,0,1,4,0);
		SetTileProp(tilemap, 58,51,0,1,4,0);
		SetTileProp(tilemap, 58,52,0,1,4,0);
		SetTileProp(tilemap, 58,53,0,1,4,0);
		SetTileProp(tilemap, 58,54,0,1,0,0);
		SetTileProp(tilemap, 58,55,0,1,0,0);
		SetTileProp(tilemap, 58,56,0,1,0,0);
		SetTileProp(tilemap, 58,57,0,1,0,0);
		SetTileProp(tilemap, 58,58,0,1,0,0);
		SetTileProp(tilemap, 58,59,0,1,0,0);
		SetTileProp(tilemap, 58,60,0,1,0,0);
		SetTileProp(tilemap, 58,61,0,1,0,0);
		SetTileProp(tilemap, 58,62,0,1,0,0);
		SetTileProp(tilemap, 59,0,0,1,4,0);
		SetTileProp(tilemap, 59,1,0,1,4,0);
		SetTileProp(tilemap, 59,2,0,1,4,0);
		SetTileProp(tilemap, 59,3,0,1,4,0);
		SetTileProp(tilemap, 59,4,0,1,4,0);
		SetTileProp(tilemap, 59,5,0,1,4,0);
		SetTileProp(tilemap, 59,6,0,1,4,0);
		SetTileProp(tilemap, 59,7,0,1,4,0);
		SetTileProp(tilemap, 59,8,0,1,4,0);
		SetTileProp(tilemap, 59,9,0,1,4,0);
		SetTileProp(tilemap, 59,10,0,1,4,0);
		SetTileProp(tilemap, 59,11,0,1,4,0);
		SetTileProp(tilemap, 59,12,0,1,4,0);
		SetTileProp(tilemap, 59,13,0,1,4,0);
		SetTileProp(tilemap, 59,14,0,1,4,0);
		SetTileProp(tilemap, 59,15,0,1,4,0);
		SetTileProp(tilemap, 59,16,0,1,4,0);
		SetTileProp(tilemap, 59,17,0,1,4,0);
		SetTileProp(tilemap, 59,18,0,1,4,0);
		SetTileProp(tilemap, 59,19,0,1,4,0);
		SetTileProp(tilemap, 59,20,0,1,4,0);
		SetTileProp(tilemap, 59,21,0,1,4,0);
		SetTileProp(tilemap, 59,22,0,1,4,0);
		SetTileProp(tilemap, 59,23,0,1,4,0);
		SetTileProp(tilemap, 59,24,0,1,4,0);
		SetTileProp(tilemap, 59,25,0,1,4,0);
		SetTileProp(tilemap, 59,26,0,1,4,0);
		SetTileProp(tilemap, 59,27,0,1,4,0);
		SetTileProp(tilemap, 59,28,0,1,4,0);
		SetTileProp(tilemap, 59,29,0,1,4,0);
		SetTileProp(tilemap, 59,30,0,1,4,0);
		SetTileProp(tilemap, 59,31,0,1,4,0);
		SetTileProp(tilemap, 59,32,0,1,4,0);
		SetTileProp(tilemap, 59,33,0,1,4,0);
		SetTileProp(tilemap, 59,34,0,1,4,0);
		SetTileProp(tilemap, 59,35,0,1,4,0);
		SetTileProp(tilemap, 59,36,0,1,4,0);
		SetTileProp(tilemap, 59,37,0,1,4,0);
		SetTileProp(tilemap, 59,38,0,1,4,0);
		SetTileProp(tilemap, 59,39,0,1,4,0);
		SetTileProp(tilemap, 59,40,0,1,4,0);
		SetTileProp(tilemap, 59,41,0,1,4,0);
		SetTileProp(tilemap, 59,42,0,1,4,0);
		SetTileProp(tilemap, 59,43,0,1,4,0);
		SetTileProp(tilemap, 59,44,0,1,4,0);
		SetTileProp(tilemap, 59,45,0,1,4,0);
		SetTileProp(tilemap, 59,46,0,1,4,0);
		SetTileProp(tilemap, 59,47,0,1,4,0);
		SetTileProp(tilemap, 59,48,0,1,4,0);
		SetTileProp(tilemap, 59,49,0,1,4,0);
		SetTileProp(tilemap, 59,50,0,1,4,0);
		SetTileProp(tilemap, 59,51,0,1,4,0);
		SetTileProp(tilemap, 59,52,0,1,4,0);
		SetTileProp(tilemap, 59,53,0,1,4,0);
		SetTileProp(tilemap, 59,54,0,1,0,0);
		SetTileProp(tilemap, 59,55,0,1,0,0);
		SetTileProp(tilemap, 59,56,0,1,0,0);
		SetTileProp(tilemap, 59,57,0,1,0,0);
		SetTileProp(tilemap, 59,58,0,1,0,0);
		SetTileProp(tilemap, 59,59,0,1,0,0);
		SetTileProp(tilemap, 59,60,0,1,0,0);
		SetTileProp(tilemap, 59,61,0,1,0,0);
		SetTileProp(tilemap, 59,62,0,1,0,0);
		SetTileProp(tilemap, 60,0,0,1,4,0);
		SetTileProp(tilemap, 60,1,0,1,4,0);
		SetTileProp(tilemap, 60,2,0,1,4,0);
		SetTileProp(tilemap, 60,3,0,1,4,0);
		SetTileProp(tilemap, 60,4,0,1,4,0);
		SetTileProp(tilemap, 60,5,0,1,4,0);
		SetTileProp(tilemap, 60,6,0,1,4,0);
		SetTileProp(tilemap, 60,7,0,1,4,0);
		SetTileProp(tilemap, 60,8,0,1,4,0);
		SetTileProp(tilemap, 60,9,0,1,4,0);
		SetTileProp(tilemap, 60,10,0,1,4,0);
		SetTileProp(tilemap, 60,11,0,1,4,0);
		SetTileProp(tilemap, 60,12,0,1,4,0);
		SetTileProp(tilemap, 60,13,0,1,4,0);
		SetTileProp(tilemap, 60,14,0,1,4,0);
		SetTileProp(tilemap, 60,15,0,1,4,0);
		SetTileProp(tilemap, 60,16,0,1,4,0);
		SetTileProp(tilemap, 60,17,0,1,4,0);
		SetTileProp(tilemap, 60,18,0,1,4,0);
		SetTileProp(tilemap, 60,19,0,1,4,0);
		SetTileProp(tilemap, 60,20,0,1,4,0);
		SetTileProp(tilemap, 60,21,0,1,4,0);
		SetTileProp(tilemap, 60,22,0,1,4,0);
		SetTileProp(tilemap, 60,23,0,1,4,0);
		SetTileProp(tilemap, 60,24,0,1,4,0);
		SetTileProp(tilemap, 60,25,0,1,4,0);
		SetTileProp(tilemap, 60,26,0,1,4,0);
		SetTileProp(tilemap, 60,27,0,1,4,0);
		SetTileProp(tilemap, 60,28,0,1,4,0);
		SetTileProp(tilemap, 60,29,0,1,4,0);
		SetTileProp(tilemap, 60,30,0,1,4,0);
		SetTileProp(tilemap, 60,31,0,1,4,0);
		SetTileProp(tilemap, 60,32,0,1,4,0);
		SetTileProp(tilemap, 60,33,0,1,4,0);
		SetTileProp(tilemap, 60,34,0,1,4,0);
		SetTileProp(tilemap, 60,35,0,1,4,0);
		SetTileProp(tilemap, 60,36,0,1,4,0);
		SetTileProp(tilemap, 60,37,0,1,4,0);
		SetTileProp(tilemap, 60,38,0,1,4,0);
		SetTileProp(tilemap, 60,39,0,1,4,0);
		SetTileProp(tilemap, 60,40,0,1,4,0);
		SetTileProp(tilemap, 60,41,0,1,4,0);
		SetTileProp(tilemap, 60,42,0,1,4,0);
		SetTileProp(tilemap, 60,43,0,1,4,0);
		SetTileProp(tilemap, 60,44,0,1,4,0);
		SetTileProp(tilemap, 60,45,0,1,4,0);
		SetTileProp(tilemap, 60,46,0,1,4,0);
		SetTileProp(tilemap, 60,47,0,1,4,0);
		SetTileProp(tilemap, 60,48,0,1,4,0);
		SetTileProp(tilemap, 60,49,0,1,4,0);
		SetTileProp(tilemap, 60,50,0,1,4,0);
		SetTileProp(tilemap, 60,51,0,1,4,0);
		SetTileProp(tilemap, 60,52,0,1,4,0);
		SetTileProp(tilemap, 60,53,0,1,4,0);
		SetTileProp(tilemap, 60,54,0,1,0,0);
		SetTileProp(tilemap, 60,55,0,1,0,0);
		SetTileProp(tilemap, 60,56,0,1,0,0);
		SetTileProp(tilemap, 60,57,0,1,0,0);
		SetTileProp(tilemap, 60,58,0,1,0,0);
		SetTileProp(tilemap, 60,59,0,1,0,0);
		SetTileProp(tilemap, 60,60,0,1,0,0);
		SetTileProp(tilemap, 60,61,0,1,0,0);
		SetTileProp(tilemap, 60,62,0,1,0,0);
		SetTileProp(tilemap, 61,0,0,1,4,0);
		SetTileProp(tilemap, 61,1,0,1,4,0);
		SetTileProp(tilemap, 61,2,0,1,4,0);
		SetTileProp(tilemap, 61,3,0,1,4,0);
		SetTileProp(tilemap, 61,4,0,1,4,0);
		SetTileProp(tilemap, 61,5,0,1,4,0);
		SetTileProp(tilemap, 61,6,0,1,4,0);
		SetTileProp(tilemap, 61,7,0,1,4,0);
		SetTileProp(tilemap, 61,8,0,1,4,0);
		SetTileProp(tilemap, 61,9,0,1,4,0);
		SetTileProp(tilemap, 61,10,0,1,4,0);
		SetTileProp(tilemap, 61,11,0,1,4,0);
		SetTileProp(tilemap, 61,12,0,1,4,0);
		SetTileProp(tilemap, 61,13,0,1,4,0);
		SetTileProp(tilemap, 61,14,0,1,4,0);
		SetTileProp(tilemap, 61,15,0,1,4,0);
		SetTileProp(tilemap, 61,16,0,1,4,0);
		SetTileProp(tilemap, 61,17,0,1,4,0);
		SetTileProp(tilemap, 61,18,0,1,4,0);
		SetTileProp(tilemap, 61,19,0,1,4,0);
		SetTileProp(tilemap, 61,20,0,1,4,0);
		SetTileProp(tilemap, 61,21,0,1,4,0);
		SetTileProp(tilemap, 61,22,0,1,4,0);
		SetTileProp(tilemap, 61,23,0,1,4,0);
		SetTileProp(tilemap, 61,24,0,1,4,0);
		SetTileProp(tilemap, 61,25,0,1,4,0);
		SetTileProp(tilemap, 61,26,0,1,4,0);
		SetTileProp(tilemap, 61,27,0,1,4,0);
		SetTileProp(tilemap, 61,28,0,1,4,0);
		SetTileProp(tilemap, 61,29,0,1,4,0);
		SetTileProp(tilemap, 61,30,0,1,4,0);
		SetTileProp(tilemap, 61,31,0,1,4,0);
		SetTileProp(tilemap, 61,32,0,1,4,0);
		SetTileProp(tilemap, 61,33,0,1,4,0);
		SetTileProp(tilemap, 61,34,0,1,4,0);
		SetTileProp(tilemap, 61,35,0,1,4,0);
		SetTileProp(tilemap, 61,36,0,1,4,0);
		SetTileProp(tilemap, 61,37,0,1,4,0);
		SetTileProp(tilemap, 61,38,0,1,4,0);
		SetTileProp(tilemap, 61,39,0,1,4,0);
		SetTileProp(tilemap, 61,40,0,1,4,0);
		SetTileProp(tilemap, 61,41,0,1,4,0);
		SetTileProp(tilemap, 61,42,0,1,4,0);
		SetTileProp(tilemap, 61,43,0,1,4,0);
		SetTileProp(tilemap, 61,44,0,1,4,0);
		SetTileProp(tilemap, 61,45,0,1,4,0);
		SetTileProp(tilemap, 61,46,0,1,4,0);
		SetTileProp(tilemap, 61,47,0,1,4,0);
		SetTileProp(tilemap, 61,48,0,1,4,0);
		SetTileProp(tilemap, 61,49,0,1,4,0);
		SetTileProp(tilemap, 61,50,0,1,4,0);
		SetTileProp(tilemap, 61,51,0,1,4,0);
		SetTileProp(tilemap, 61,52,0,1,4,0);
		SetTileProp(tilemap, 61,53,0,1,4,0);
		SetTileProp(tilemap, 61,54,0,1,0,0);
		SetTileProp(tilemap, 61,55,0,1,0,0);
		SetTileProp(tilemap, 61,56,0,1,0,0);
		SetTileProp(tilemap, 61,57,0,1,0,0);
		SetTileProp(tilemap, 61,58,0,1,0,0);
		SetTileProp(tilemap, 61,59,0,1,0,0);
		SetTileProp(tilemap, 61,60,0,1,0,0);
		SetTileProp(tilemap, 61,61,0,1,0,0);
		SetTileProp(tilemap, 61,62,0,1,0,0);
		SetTileProp(tilemap, 62,0,0,1,4,0);
		SetTileProp(tilemap, 62,1,0,1,4,0);
		SetTileProp(tilemap, 62,2,0,1,4,0);
		SetTileProp(tilemap, 62,3,0,1,4,0);
		SetTileProp(tilemap, 62,4,0,1,4,0);
		SetTileProp(tilemap, 62,5,0,1,4,0);
		SetTileProp(tilemap, 62,6,0,1,4,0);
		SetTileProp(tilemap, 62,7,0,1,4,0);
		SetTileProp(tilemap, 62,8,0,1,4,0);
		SetTileProp(tilemap, 62,9,0,1,4,0);
		SetTileProp(tilemap, 62,10,0,1,4,0);
		SetTileProp(tilemap, 62,11,0,1,4,0);
		SetTileProp(tilemap, 62,12,0,1,4,0);
		SetTileProp(tilemap, 62,13,0,1,4,0);
		SetTileProp(tilemap, 62,14,0,1,4,0);
		SetTileProp(tilemap, 62,15,0,1,4,0);
		SetTileProp(tilemap, 62,16,0,1,4,0);
		SetTileProp(tilemap, 62,17,0,1,4,0);
		SetTileProp(tilemap, 62,18,0,1,4,0);
		SetTileProp(tilemap, 62,19,0,1,4,0);
		SetTileProp(tilemap, 62,20,0,1,4,0);
		SetTileProp(tilemap, 62,21,0,1,4,0);
		SetTileProp(tilemap, 62,22,0,1,4,0);
		SetTileProp(tilemap, 62,23,0,1,4,0);
		SetTileProp(tilemap, 62,24,0,1,4,0);
		SetTileProp(tilemap, 62,25,0,1,4,0);
		SetTileProp(tilemap, 62,26,0,1,4,0);
		SetTileProp(tilemap, 62,27,0,1,4,0);
		SetTileProp(tilemap, 62,28,0,1,4,0);
		SetTileProp(tilemap, 62,29,0,1,4,0);
		SetTileProp(tilemap, 62,30,0,1,4,0);
		SetTileProp(tilemap, 62,31,0,1,4,0);
		SetTileProp(tilemap, 62,32,0,1,4,0);
		SetTileProp(tilemap, 62,33,0,1,4,0);
		SetTileProp(tilemap, 62,34,0,1,4,0);
		SetTileProp(tilemap, 62,35,0,1,4,0);
		SetTileProp(tilemap, 62,36,0,1,4,0);
		SetTileProp(tilemap, 62,37,0,1,4,0);
		SetTileProp(tilemap, 62,38,0,1,4,0);
		SetTileProp(tilemap, 62,39,0,1,4,0);
		SetTileProp(tilemap, 62,40,0,1,4,0);
		SetTileProp(tilemap, 62,41,0,1,4,0);
		SetTileProp(tilemap, 62,42,0,1,4,0);
		SetTileProp(tilemap, 62,43,0,1,4,0);
		SetTileProp(tilemap, 62,44,0,1,4,0);
		SetTileProp(tilemap, 62,45,0,1,4,0);
		SetTileProp(tilemap, 62,46,0,1,4,0);
		SetTileProp(tilemap, 62,47,0,1,4,0);
		SetTileProp(tilemap, 62,48,0,1,4,0);
		SetTileProp(tilemap, 62,49,0,1,4,0);
		SetTileProp(tilemap, 62,50,0,1,4,0);
		SetTileProp(tilemap, 62,51,0,1,4,0);
		SetTileProp(tilemap, 62,52,0,1,4,0);
		SetTileProp(tilemap, 62,53,0,1,4,0);
		SetTileProp(tilemap, 62,54,0,1,0,0);
		SetTileProp(tilemap, 62,55,0,1,0,0);
		SetTileProp(tilemap, 62,56,0,1,0,0);
		SetTileProp(tilemap, 62,57,0,1,0,0);
		SetTileProp(tilemap, 62,58,0,1,0,0);
		SetTileProp(tilemap, 62,59,0,1,0,0);
		SetTileProp(tilemap, 62,60,0,1,0,0);
		SetTileProp(tilemap, 62,61,0,1,0,0);
		SetTileProp(tilemap, 62,62,0,1,0,0);
		Debug.Log ("Tile properties set");


	}


	[MenuItem("MyTools/CreateAnim")]
	static void GenerateAnimationAssets()
	{
		return;
		//System Shock animations
		CreateAnimationUW("439_Attack1","objects_1400_0000","objects_1400_0001","objects_1400_0002","objects_1400_0003","objects_1400_0004","objects_1400_0005","objects_1400_0006","objects_1400_0007",8);
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


		//end system shock animations

		return; //takes a long time to run..
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
		return;
	}


	static void CreateAnimationUW(string AnimationName, string Frame0, string Frame1, string Frame2, string Frame3, string Frame4, string Frame5,string Frame6,string Frame7, int NoOfValid)
	{
		string[] animArray =  {Frame0,Frame1,Frame2,Frame3,Frame4,Frame5,Frame6,Frame7};
		CreateAnimationAsset (AnimationName, animArray, NoOfValid);
		return;
	}

	static void CreateAnimationAsset(string AnimationName, string[] Frames, int NoOfValid)
	{
		//CreateAnim();
		GameObject myAI = GameObject.Find ("AI_Base_Animator");
		if (myAI==null)
		{
			Debug.Log ("No Animation Base Found");
			return;
		}

		SpriteRenderer sprt = myAI.GetComponent<SpriteRenderer>();
		AnimationClip animClip = new AnimationClip();
		AnimationUtility.SetAnimationType (animClip, ModelImporterAnimationType.Generic);
		EditorCurveBinding curveBinding = new EditorCurveBinding();
		animClip.wrapMode = WrapMode.Loop;
		animClip.name=AnimationName;
		
		curveBinding.type = typeof(SpriteRenderer);
		curveBinding.path = "";
		curveBinding.propertyName = "m_Sprite";

		ObjectReferenceKeyframe[] keyFrames = new ObjectReferenceKeyframe[NoOfValid+1];

		for(int i = 0; i<NoOfValid; i++)
		{
			keyFrames[i] = new ObjectReferenceKeyframe();
			keyFrames[i].time = 0.2f * i;
			Sprite currFrame = Resources.Load <Sprite> ("Sprites/critters/" + Frames[i]);
			//Debug.Log ("Sprites/Critters/" + Frames[i]);
			if (currFrame == null)
			{
				Debug.Log ("Resource not loaded!");
			}
			sprt.sprite=currFrame;
			keyFrames[i].value=currFrame;
		}
		if (NoOfValid !=0)
		{
			keyFrames[NoOfValid] = new ObjectReferenceKeyframe();
			keyFrames[NoOfValid].time = 0.2f * NoOfValid;
			Sprite currFrame = Resources.Load <Sprite> ("Sprites/critters/" + Frames[NoOfValid-1]);
			sprt.sprite=currFrame;
			keyFrames[NoOfValid].value=currFrame; //Hold on the last frame
		}

		AnimationUtility.SetObjectReferenceCurve(animClip, curveBinding, keyFrames);
		AssetDatabase.CreateAsset(animClip,"Assets/Resources/animation/"+  animClip.name + ".anim" );
	}


	static void CreateAnim()
	{//test
		GameObject myAI = GameObject.Find ("AI_Base_Animator");
//		Animator Anim = myAI.GetComponent<Animator>();
		SpriteRenderer sprt = myAI.GetComponent<SpriteRenderer>();
		AnimationClip animClip = new AnimationClip();
		AnimationUtility.SetAnimationType (animClip, ModelImporterAnimationType.Generic);
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
			Debug.Log("Sprites/AI/GreenGoblin/frames/cr00page_n00_" + i.ToString ("D4"));
		}
		AnimationUtility.SetObjectReferenceCurve(animClip, curveBinding, keyFrames);
		AssetDatabase.CreateAsset(animClip,"Assets/Resources/animation/"+  animClip.name + ".anim" );

		//Anim.animation.AddClip (animClip,animClip.name);
		//Anim.animation.clip = animClip;

		//AssetDatabase.CreateAsset(animClip,"Assets/Resources/animation/"+  animClip.name + ".anim" );
		//Anim.Play (animClip.name);
	}

	static GameObject CreateGameObject(string ObjectName, float x, float y, float z)
	{
		GameObject myObj = new GameObject(ObjectName);
		Vector3 pos = new Vector3(x, y, z);
		myObj.transform.position = pos;
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
		//SpriteController.transform.localScale = new Vector3(30.0f, 30.0f, 30.0f);
		//Create a billboard script for display
		// Billboard ScriptController = 
		if (BillBoard)
		{
			SpriteController.AddComponent<Billboard> ();
		}

	}

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
	}

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
				buttonScript.item_id=item_id;
				ObjectVariables objVars = Button.AddComponent<ObjectVariables>();
				objVars.state=state;
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


	static void CreateObjectInteraction(GameObject myObj,float DimX,float DimY,float DimZ, float CenterY, string InventoryString, int ItemType, int ItemId, int isMoveable,string ChildName)
	{
		GameObject newObj = new GameObject(myObj.name+"_"+ChildName);

		newObj.transform.parent=myObj.transform;
		newObj.transform.localPosition=new Vector3(0.0f,0.0f,0.0f);
		CreateObjectInteraction (newObj,DimX,DimY,DimZ,CenterY,InventoryString,ItemType,ItemId,isMoveable);
	}

	static void CreateObjectInteraction(GameObject myObj,float DimX,float DimY,float DimZ, float CenterY, string InventoryString, int ItemType, int ItemId, int isMoveable)
	{
		CreateObjectInteraction (myObj,myObj,DimX,DimY,DimZ,CenterY,InventoryString,ItemType,ItemId,isMoveable);
	}

	static void CreateObjectInteraction(GameObject myObj, GameObject parentObj,float DimX,float DimY,float DimZ, float CenterY, string InventoryString, int ItemType, int ItemId, int isMoveable)
	{
		//Debug.Log (myObj.name);
		//Add a script.
		ObjectInteraction objInteract = myObj.AddComponent<ObjectInteraction>();

		//add a mesh for interaction
		BoxCollider box= myObj.AddComponent<BoxCollider>();
		box.size = new Vector3(0.2f,0.2f,0.2f);
		//box.transform.position = myObj.transform.position;
		//box.transform.localScale = new Vector3(DimX, DimZ, DimY);
		box.center= new Vector3(0.0f,0.1f,0.0f);
		//box.isTrigger=true;

		//SpriteRenderer objSprite =  myObj.transform.FindChild(myObj.name + "_sprite").GetComponent<SpriteRenderer>();
		SpriteRenderer objSprite =  parentObj.GetComponentInChildren<SpriteRenderer>();
		if (objSprite==null)
		{
			Debug.Log (parentObj.name + ": can't find spriterenderer");
		}
		else
		{
			objInteract.InventoryIcon = objSprite.sprite;
			objInteract.InventoryIconEquip=objSprite.sprite;
		}

		objInteract.InventoryString=InventoryString;
		objInteract.InventoryIconEquipString=InventoryString;
		objInteract.ItemType=ItemType;//UWexporter id type
		objInteract.item_id=ItemId;//Internal ItemID

		if (isMoveable==1)
		{
			Rigidbody rgd = parentObj.AddComponent<Rigidbody>();
			rgd.freezeRotation =true;
		}

	}

	static void CreateTrigger(GameObject myObj,int triggerX, int triggerY, string target)
	{
		//Add some gamevars
		ObjectVariables objVar = myObj.AddComponent<ObjectVariables>();
		//
		objVar.trigger=target;
		TriggerHandler trig = myObj.AddComponent<TriggerHandler>();
		trig.triggerX=triggerX;
		trig.triggerY=triggerY;
		trig.trigger=target;
	}

	static void CreateNPC(GameObject myObj, string NPC_ID, string EditorSprite)
	{
		//Add the AI.
		//My anims are backwards!!!!!
		GoblinAI gronk = myObj.AddComponent<GoblinAI>();
		//Since I have only one animation I change names
		//NPC_Name="GreenGoblin";
		//NPC_Name="127";
		gronk.NPC_ID=NPC_ID;
		//gronk.Idle_Front=NPC_Name + "_idle_front";
		//gronk.Idle_Rear=NPC_Name+"_idle_rear";
		//gronk.Idle_Right=NPC_Name+"_idle_right";
		//gronk.Idle_Left=NPC_Name+"_idle_left";
		//gronk.Idle_Front_Right=NPC_Name+"_idle_front_right";
		//gronk.Idle_Front_Left=NPC_Name+"_idle_front_left";
		//gronk.Idle_Rear_Right=NPC_Name+"_idle_rear_right";
		//gronk.Idle_Rear_Left=NPC_Name+"_idle_rear_left";

		//gronk.Walking_Front=NPC_Name + "_walking_front";
		//gronk.Walking_Rear=NPC_Name+"_walking_rear";
		//gronk.Walking_Right=NPC_Name+"_walking_right";
		//gronk.Walking_Left=NPC_Name+"_walking_left";
		//gronk.Walking_Front_Right=NPC_Name+"_walking_front_right";
		//gronk.Walking_Front_Left=NPC_Name+"_walking_front_left";
		//gronk.Walking_Rear_Right=NPC_Name+"_walking_rear_right";
		//gronk.Walking_Rear_Left=NPC_Name+"_walking_rear_left";


		//gronk.idle_combat=NPC_Name+"_idle_combat";
		//gronk.attack_bash=NPC_Name+"_attack_bash";
		//gronk.attack_slash=NPC_Name+"_attack_slash";
		//gronk.attack_thrust=NPC_Name+"_attack_thrust";
		//gronk.attack_secondary=NPC_Name+"_attack_secondary";
		//gronk.death=NPC_Name+"_death";
		//gronk.begin_combat=NPC_Name+"_begin_combat";
		//Add the Nav mesh
		NavMeshAgent nav = myObj.AddComponent<NavMeshAgent>();
		nav.height=0.8f;
		//nav.baseOffset=0.0f;
		nav.radius=0.3f;

		//add the animator to the sprite
		//GameObject spritecontroller=myObj.transform.FindChild (myObj.name +"_sprite").gameObject;
		//Animator anim =spritecontroller.AddComponent<Animator>();
		//spritecontroller.GetComponent<Billboard>().enabled=false;
		//Animator anim =myObj.transform.FindChild (name+"_sprite").gameObject.AddComponent<Animator>();
		//myObj.transform.FindChild (name+"_sprite").GetComponent<Billboard>().enabled=false ;//turn off billboarding.
		//Object test = (RuntimeAnimatorController)Resources.Load("animation/AnimatorControl");



		GameObject myInstance = Resources.Load("animation/AI_Base_Animator") as GameObject;
		GameObject newObj = (GameObject)GameObject.Instantiate(myInstance);
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
		mysprite.sprite = image;//Assigns the sprite to the object.
		//newObj.AddComponent<Billboard>();

		BoxCollider mybox = myObj.AddComponent<BoxCollider>();
		mybox.isTrigger=true;
		//mybox.size=new Vector3(0.3f,0.8f,0.3f);

		//myInstance.transform.parent=myObj.transform;
		//RuntimeAnimatorController contr = RuntimeAnimatorController.Instantiate(test);
		//anim.runtimeAnimatorController=contr;
		//GameObject myInstance = Resources.Load("animation/AnimatorControl") as GameObject;
		//spritecontroller.

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
		myObj.AddComponent<ObjectVariables>();
		myObj.AddComponent<a_damage_trap>();
	}

	static void Create_a_damage_trap(GameObject myObj, string Trigger)
	{
		//Add some gamevars
		//ObjectVariables objVar =
		ObjectVariables myvars= myObj.AddComponent<ObjectVariables>();
		myvars.trigger=Trigger;
		myObj.AddComponent<a_damage_trap>();
	}

	static void Create_a_teleport_trap(GameObject myObj, float x, float y, float z, bool LevelExit)
	{
		//Add some gamevars
		//ObjectVariables objVar =
		myObj.AddComponent<ObjectVariables>();
		a_teleport_trap tp = myObj.AddComponent<a_teleport_trap>();
		if (tp!=null)
		{
			tp.targetX=x;
			tp.targetY=y;
			tp.targetZ=z;
			tp.LevelTeleport=LevelExit;
		}
	}

	static void Create_a_arrow_trap(GameObject myObj)
	{
		//Add some gamevars
		//ObjectVariables objVar =
		myObj.AddComponent<ObjectVariables>();
		myObj.AddComponent<a_arrow_trap>();
	}

	static void Create_a_do_trap(GameObject myObj, int trapType, int flags)
	{
		//Add some gamevars
		//ObjectVariables objVar = 
		myObj.AddComponent<ObjectVariables>();
		switch (trapType)
		{
		case 0x02://Camera
			{myObj.AddComponent<a_do_trap_camera>();break;}
		case 0x03://Platform
			{
			//a_do_trap_platform scrpt = 	
			myObj.AddComponent<a_do_trap_platform>();
			//scrpt.state=flags;
			break;
			}
		case 0x18:	//bullfrog
			{myObj.AddComponent<a_do_trapBullfrog>();break;}
		default:
			{myObj.AddComponent<trap_base>();break;}
		}
	}

	static void Create_a_pit_trap(GameObject myObj)
	{
		//Add some gamevars
		//ObjectVariables objVar = 
		myObj.AddComponent<ObjectVariables>();
		myObj.AddComponent<a_pit_trap>();
	}

	static void Create_a_change_terrain_trap(GameObject myObj, int TileX, int TileY, int x, int y)
	{
		//Add some gamevars
		//ObjectVariables objVar =
		ObjectVariables myvars= myObj.AddComponent<ObjectVariables>();

		a_change_terrain_trap ctt= myObj.AddComponent<a_change_terrain_trap>();
		ctt.TileX=TileX;
		ctt.TileY=TileY;
		ctt.X=x;
		ctt.Y=y;
	}

	static void Create_a_change_terrain_trap(GameObject myObj, int TileX, int TileY, int x, int y,string Trigger)
	{
		//Add some gamevars
		//ObjectVariables objVar =
		ObjectVariables myvars= myObj.AddComponent<ObjectVariables>();
		myvars.trigger=Trigger;

		a_change_terrain_trap ctt= myObj.AddComponent<a_change_terrain_trap>();
		ctt.TileX=TileX;
		ctt.TileY=TileY;
		ctt.X=x;
		ctt.Y=y;
	}

	static void Create_a_spelltrap(GameObject myObj)
	{
		//Add some gamevars
		//ObjectVariables objVar =
		myObj.AddComponent<ObjectVariables>();
		myObj.AddComponent<a_spelltrap>();
	}

	static void Create_a_create_object_trap(GameObject myObj)
	{
		//Add some gamevars
		//ObjectVariables objVar = 
		myObj.AddComponent<ObjectVariables>();
		myObj.AddComponent<a_create_object_trap>();
	}

	static void Create_a_door_trap(GameObject myObj, int quality)
	{
		//Points to the tile where the door is located.
		//Add some gamevars
		//ObjectVariables objVar = 
		myObj.AddComponent<ObjectVariables>();
		a_door_trap scrpt = myObj.AddComponent<a_door_trap>();
		scrpt.quality=quality;
	}

	static void Create_a_lock(GameObject myObj)
	{
		//Add some gamevars
		//ObjectVariables objVar = 
			myObj.AddComponent<ObjectVariables>();
		myObj.AddComponent<a_lock>();
	}

	static void Create_a_ward_trap(GameObject myObj)
	{
		//Add some gamevars
		//ObjectVariables objVar = 
			myObj.AddComponent<ObjectVariables>();
		myObj.AddComponent<a_ward_trap>();
	}

	static void Create_a_delete_object_trap(GameObject myObj)
	{
		//Add some gamevars
		//ObjectVariables objVar = 
			myObj.AddComponent<ObjectVariables>();
		myObj.AddComponent<a_delete_object_trap>();
	}

	static void Create_an_inventory_trap(GameObject myObj)
	{
		//Add some gamevars
		//ObjectVariables objVar =
			myObj.AddComponent<ObjectVariables>();
		myObj.AddComponent<an_inventory_trap>();
	}

	static void Create_a_set_variable_trap(GameObject myObj)
	{
		//Add some gamevars
		//ObjectVariables objVar = 
			myObj.AddComponent<ObjectVariables>();
		myObj.AddComponent<a_set_variable_trap>();
	}

	static void Create_a_check_variable_trap(GameObject myObj)
	{
		//Add some gamevars
		//ObjectVariables objVar = 
			myObj.AddComponent<ObjectVariables>();
		myObj.AddComponent<a_check_variable_trap>();
	}

	static void Create_a_text_string_trap(GameObject myObj, int blockNo, int stringNo)
	{
		//Add some gamevars
		//ObjectVariables objVar =
		myObj.AddComponent<ObjectVariables>();
		a_text_string_trap scrpt = myObj.AddComponent<a_text_string_trap>();
		scrpt.StringBlock = blockNo;
		scrpt.StringNo = stringNo;
	}

	static void Create_a_text_string_trap(GameObject myObj, int blockNo, int stringNo, string trigger)
	{
		//Add some gamevars
		//ObjectVariables objVar =
		ObjectVariables vars = myObj.AddComponent<ObjectVariables>();
		vars.trigger=trigger;
		a_text_string_trap scrpt = myObj.AddComponent<a_text_string_trap>();
		scrpt.StringBlock = blockNo;
		scrpt.StringNo = stringNo;
	}

	static void Create_a_tell_trap(GameObject myObj)
	{
		//Add some gamevars
		//ObjectVariables objVar =
			myObj.AddComponent<ObjectVariables>();
		myObj.AddComponent<a_tell_trap>();
	}

	static void Create_trap_base(GameObject myObj)
	{
		//Add some gamevars
		//ObjectVariables objVar =
		myObj.AddComponent<ObjectVariables>();
		myObj.AddComponent<trap_base>();
	}

	static void AddObjectToContainer(GameObject myObj, Container ParentContainer, int index)
	{
		ParentContainer.AddItemToContainer(myObj.name,index);
	}

	static void SetObjectAsRuneStone(GameObject myObj)
	{//Sets an object as being a rune stone
		ObjectInteraction objInt = myObj.GetComponent<ObjectInteraction>();
		objInt.isRuneStone=true;
		objInt.isRuneBag=false;//Mutually exclusive
	}

	static void SetObjectAsRuneBag(GameObject myObj)
	{//Sets an object as being a rune bag
		ObjectInteraction objInt = myObj.GetComponent<ObjectInteraction>();
		RuneBag rb = myObj.AddComponent<RuneBag>();
		//objInt.isRuneStone=false;
		//objInt.isRuneBag=true;//Mutually exclusive
	}

	static void SetRotation(GameObject myObj, float angle1, float angle2, float angle3)
	{
		myObj.transform.Rotate(angle1,angle2,angle3);
	}

	static void CreateDoor(GameObject myObj, string DoorTexturePath, int DoorKey, int Locked)
	{
		GameObject myInstance = Resources.Load("Models/uw1_door") as GameObject;
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
		newObj.GetComponent<MeshCollider>().enabled=false;
		MeshCollider mc = myObj.AddComponent<MeshCollider>();
		mc.isTrigger=true;
		mc.sharedMesh=newObj.GetComponent<MeshFilter>().sharedMesh;
		mc = myObj.AddComponent<MeshCollider>();
		mc.isTrigger=false;
		mc.sharedMesh=newObj.GetComponent<MeshFilter>().sharedMesh;
		DoorControl dc = myObj.AddComponent<DoorControl>();
		dc.KeyIndex=DoorKey;
		dc.locked = (Locked==1);
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
		MeshCollider mc = newObj.AddComponent<MeshCollider>();//was myobj
		mc.sharedMesh=newObj.GetComponent<MeshFilter>().sharedMesh;

		Material[] myMat = newObj.renderer.materials;
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
		ObjectInteraction objInt = myObj.GetComponent<ObjectInteraction>();
		objInt.isKey=true;
		objInt.Owner=KeyId;
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
		GameObject MyObjChild = new GameObject(myObj.name + "_collider");
		MyObjChild.transform.position = myObj.transform.position;
		MyObjChild.transform.parent = myObj.transform;

		BoxCollider box=MyObjChild.AddComponent<BoxCollider>();
		box.transform.position =MyObjChild.transform.position;
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
		GameObject MyObjChild = new GameObject(myObj.name + "_collider");
		MyObjChild.transform.position = myObj.transform.position;
		MyObjChild.transform.parent = myObj.transform;
		
		BoxCollider box=MyObjChild.AddComponent<BoxCollider>();
		box.transform.position =MyObjChild.transform.position;
		box.transform.localScale = new Vector3(x, y, z);
		box.isTrigger=isTrigger;
	}

	static void CreateTMAP(GameObject myObj, string AssetPath)
	{
		SpriteRenderer mysprite = myObj.AddComponent<SpriteRenderer>();//Adds the sprite gameobject
		Sprite image = Resources.Load <Sprite> (AssetPath);//Loads the sprite.
		mysprite.sprite = image;//Assigns the sprite to the object.
		Material myMaterial = Resources.Load("Materials/tmap", typeof(Material)) as Material;
		mysprite.material  = myMaterial;
	}

	static void AddTrapLink(GameObject myObj, string Trigger)
	{
		ObjectVariables myvars= myObj.GetComponent<ObjectVariables>();
		myvars.trigger=Trigger;
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
		Action_Lighting al = myObj.AddComponent<Action_Lighting>();
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
		Action_Timer at= myObj.AddComponent<Action_Timer>();
	}

	static void AddACTION_DO_NOTHING(GameObject myObj)
	{
		Action_Do_Nothing dn= myObj.AddComponent<Action_Do_Nothing>();
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
		Action_Set_Variable SV = myObj.AddComponent<Action_Set_Variable>();
	}

	static void AddACTION_CHANGE_STATE(GameObject myObj,string ObjectToActivate, int NewState)
	{
		Action_Change_State ac = myObj.AddComponent<Action_Change_State>();
		ac.ObjectToActivate=ObjectToActivate;
		ac.NewState=NewState;
	}

	static void AddACTION_SPAWN(GameObject myObj)
	{
		Action_Spawn acp = myObj.AddComponent<Action_Spawn>();
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
		Action_Email AE= myObj.AddComponent<Action_Email>();
	}

	static void AddACTION_RESURRECTION(GameObject myObj)
	{
		Action_Resurrection AR= myObj.AddComponent<Action_Resurrection>();
	}

	static void AddACTION_UNKNOWN(GameObject myObj)
	{
		Debug.Log (myObj.name + " ACTION UNKNOWN!!");
		Action_Default ad = myObj.AddComponent<Action_Default>();
	}

	static void AddACTION_CLONE(GameObject myObj)
	{
		Action_Clone ac = myObj.AddComponent<Action_Clone>();
	}

	static void AddACTION_TRANSPORT_LEVEL(GameObject myObj)
	{
		Action_Transport_Level al = myObj.AddComponent<Action_Transport_Level>();
	}

	static void AddACTION_AWAKEN(GameObject myObj)
	{
		Action_Awaken aa = myObj.AddComponent<Action_Awaken>();
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
		//GameObject MyObjChild = new GameObject(myObj.name + "_repulsor");
		//MyObjChild.transform.position = myObj.transform.position;
		//MyObjChild.transform.parent = myObj.transform;
		Repulsor rp = myObj.AddComponent<Repulsor>();
		rp.TargetHeight=displacement;
		rp.RepulsorOn=isOn;
		CreateCollider (myObj,posX,posY,posZ,dimX,dimY,dimZ,true);
	}

	static void SetReadable(GameObject myObj)
	{
		Readable rd = myObj.AddComponent<Readable>();
	}

	static void SetInventoryIcon(GameObject myObj, string SpriteName, string AssetPath)
	{
		ObjectInteraction objInt = myObj.GetComponent<ObjectInteraction>();
		if (objInt != null)
			{
			Sprite image = Resources.Load <Sprite> (AssetPath);//Loads the sprite.
			objInt.InventoryIcon = image;//Assigns the sprite to the object.
			objInt.InventoryString=SpriteName;
			}
	}
}
