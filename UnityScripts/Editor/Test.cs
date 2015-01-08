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
		
		myObj = new GameObject("a_giant_rat_21_02_02_0228");
		pos = new Vector3(25.714285f, 3.628346f, 2.914286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"67","Sprites/objects_067");
		
		myObj = new GameObject("special_tmap_obj_42_02_02_1005");
		pos = new Vector3(51.579998f, 3.628346f, 3.000000f);
		myObj.transform.position = pos;
		CreateTMAP(myObj,"textures/tmap/uw1_141");
		SetRotation(myObj,0,-90,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_366",34,366, 0);
		
		
		myObj = new GameObject("special_tmap_obj_05_03_02_0904");
		pos = new Vector3(6.600000f, 3.628346f, 4.780000f);
		myObj.transform.position = pos;
		CreateTMAP(myObj,"textures/tmap/uw1_140");
		SetRotation(myObj,0,-180,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_366",34,366, 0);
		
		
		myObj = new GameObject("a_giant_rat_21_03_02_0220");
		pos = new Vector3(25.714285f, 3.628346f, 4.114285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"72","Sprites/objects_072");
		
		
		
		
		
		
		myObj = new GameObject("some_writing_45_04_02_0914");
		pos = new Vector3(54.514286f, 1.814173f, 4.800000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_358",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_358",10,358, 0);
		SetRotation(myObj,0,0,0);
		SetSprite(myObj, "Sprites/tmobj/tmobj_26");
		SetLink(myObj,655);
		
		myObj = new GameObject("a_wolf_spider_47_04_02_0203");
		pos = new Vector3(56.914288f, 1.209449f, 5.314286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"83","Sprites/objects_083");
		
		
		
		myObj = new GameObject("a_plant_01_06_02_0845");
		pos = new Vector3(2.400000f, 3.628346f, 8.400000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		
		
		myObj = new GameObject("a_book_22_06_02_0773");
		pos = new Vector3(26.914284f, 2.721260f, 7.714286f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_306",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_306",11,306, 1);
		
		myObj = new GameObject("a_scroll_22_06_02_0936");
		pos = new Vector3(26.571428f, 2.721260f, 8.057143f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_314",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_314",13,314, 1);
		
		myObj = new GameObject("a_skull_22_06_02_0935");
		pos = new Vector3(27.257143f, 2.721260f, 7.714286f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_195",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_195",23,195, 1);
		
		myObj = new GameObject("a_plant_22_06_02_0910");
		pos = new Vector3(26.914284f, 2.721260f, 7.714286f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_192",true);
		
		myObj = new GameObject("a_Sanct_stone_22_06_02_0670");
		pos = new Vector3(27.085716f, 2.721260f, 7.714286f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_250",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_250",6,250, 1);
		SetObjectAsRuneStone(myObj);
		
		
		myObj = new GameObject("a_Hur_stone_22_06_02_0674");
		pos = new Vector3(26.914284f, 2.721260f, 7.714286f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_239",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_239",6,239, 1);
		SetObjectAsRuneStone(myObj);
		
		
		myObj = new GameObject("a_pile_of_bones_piles_of_bones_22_06_02_0934");
		pos = new Vector3(26.571428f, 2.721260f, 7.885714f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_198",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_198",23,198, 1);
		
		myObj = new GameObject("a_dagger_22_06_02_0909");
		pos = new Vector3(26.571428f, 2.721260f, 7.371429f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_003",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_003",1,3, 1);
		
		myObj = new GameObject("special_tmap_obj_23_06_02_0911");
		pos = new Vector3(28.200001f, 2.721260f, 7.220000f);
		myObj.transform.position = pos;
		CreateTMAP(myObj,"textures/tmap/uw1_153");
		SetRotation(myObj,0,0,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_366",34,366, 0);
		
		myObj = new GameObject("some_writing_31_06_02_0609");
		pos = new Vector3(37.200001f, 4.233071f, 8.400000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_358",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_358",10,358, 0);
		SetRotation(myObj,0,90,0);
		SetSprite(myObj, "Sprites/tmobj/tmobj_21");
		SetLink(myObj,650);
		
		myObj = new GameObject("some_writing_33_06_02_0608");
		pos = new Vector3(40.799999f, 4.233071f, 8.400000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_358",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_358",10,358, 0);
		SetRotation(myObj,0,-90,0);
		SetSprite(myObj, "Sprites/tmobj/tmobj_21");
		SetLink(myObj,649);
		
		
		
		myObj = new GameObject("a_plant_01_07_02_0834");
		pos = new Vector3(2.057143f, 3.628346f, 9.257143f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_206",true);
		
		myObj = new GameObject("a_plant_01_07_02_0835");
		pos = new Vector3(2.400000f, 3.628346f, 9.257143f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_206",true);
		
		myObj = new GameObject("some_grass_bunches_of_grass_01_07_02_0838");
		pos = new Vector3(2.400000f, 3.628346f, 9.085714f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("some_leeches_bunches_of_leeches_01_07_02_0836");
		pos = new Vector3(2.400000f, 3.628346f, 8.914286f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_293",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_293",16,293, 1);
		
		myObj = new GameObject("some_grass_bunches_of_grass_01_07_02_0840");
		pos = new Vector3(1.542857f, 3.628346f, 9.257143f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("a_plant_01_07_02_0842");
		pos = new Vector3(2.057143f, 3.628346f, 9.428571f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("a_button_05_07_02_1021");
		pos = new Vector3(7.200000f, 4.233071f, 9.257143f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_369",true);
		CreateUWActivators(myObj,"ButtonHandler","a_use_trigger_99_99_02_0998",40,0,0,8);
		
		myObj = new GameObject("a_button_05_07_02_1022");
		pos = new Vector3(7.200000f, 4.233071f, 8.914286f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_369",true);
		CreateUWActivators(myObj,"ButtonHandler","a_use_trigger_99_99_02_0996",40,0,0,8);
		
		myObj = new GameObject("a_button_05_07_02_1002");
		pos = new Vector3(7.200000f, 4.233071f, 8.571429f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_369",true);
		CreateUWActivators(myObj,"ButtonHandler","a_use_trigger_99_99_02_1017",40,0,0,8);
		
		
		myObj = new GameObject("a_gray_lizardman_red_lizardmen_11_07_02_0239");
		pos = new Vector3(13.714286f, 3.325984f, 8.914286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"89","Sprites/objects_089");
		
		myObj = new GameObject("a_gray_lizardman_red_lizardmen_17_07_02_0226");
		pos = new Vector3(20.914284f, 3.628346f, 9.600000f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"89","Sprites/objects_089");
		myObj = new GameObject("a_pouch_pouches_17_07_02_0603");
		pos = new Vector3(20.914284f, 3.628346f, 9.600000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_134",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_134",19,134, 1);
		////Container contents
		ParentContainer = myObj.AddComponent<Container>();
		myObj.GetComponent<ObjectInteraction>().isContainer = true;
		myObj = new GameObject("a_wand_99_99_02_0599");
		pos = new Vector3(20.914284f, 3.628346f, 9.600000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_152",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_152",12,152, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 0);
		myObj = new GameObject("a_red_potion_99_99_02_0598");
		pos = new Vector3(20.914284f, 3.628346f, 9.600000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_187",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_187",14,187, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 1);
		myObj = new GameObject("a_Wis_stone_99_99_02_0932");
		pos = new Vector3(20.914284f, 3.628346f, 9.600000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_254",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_254",6,254, 1);
		SetObjectAsRuneStone(myObj);
		
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 2);
		////Container contents complete
		
		myObj = new GameObject("a_lurker_20_07_02_0201");
		pos = new Vector3(24.514284f, 2.418898f, 8.914286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"87","Sprites/objects_087");
		
		myObj = new GameObject("a_giant_rat_23_07_02_0244");
		pos = new Vector3(28.114285f, 2.721260f, 8.914286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"72","Sprites/objects_072");
		
		myObj = new GameObject("door_030_007");
		pos = new Vector3(37.200001f, 3.628346f, 8.600000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_324",true);
		CreateDoor(myObj,"textures/doors/doors_12", 8, 1);
		SetRotation(myObj,-90,90,0);
		
		myObj = new GameObject("door_034_007");
		pos = new Vector3(40.799999f, 3.628346f, 8.600000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_324",true);
		CreateDoor(myObj,"textures/doors/doors_12", 8, 1);
		SetRotation(myObj,-90,90,0);
		
		
		myObj = new GameObject("door_046_007");
		pos = new Vector3(55.400002f, 1.209449f, 9.257143f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_325",true);
		CreateDoor(myObj,"textures/doors/doors_03", 53, 0);
		SetRotation(myObj,-90,-180,0);
		
		myObj = new GameObject("a_fountain_61_07_02_0977");
		pos = new Vector3(73.714287f, 3.061417f, 8.914286f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_457",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_457",69,457, 1);
		
		myObj = new GameObject("a_fountain_61_07_02_0631");
		pos = new Vector3(73.714287f, 3.023622f, 8.914286f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_302",true);
		CreateUWActivators(myObj,"ButtonHandler","an_open_trigger_99_99_02_0582",40,0,8,8);
		
		
		myObj = new GameObject("door_006_008");
		pos = new Vector3(7.714286f, 3.628346f, 9.800000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_325",true);
		CreateDoor(myObj,"textures/doors/doors_03", 0, 1);
		SetRotation(myObj,-90,90,0);
		
		myObj = new GameObject("a_pull_chain_07_08_02_0892");
		pos = new Vector3(9.257143f, 4.233071f, 10.800000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_383",true);
		CreateUWActivators(myObj,"ButtonHandler","a_use_trigger_99_99_02_0891",40,0,0,8);
		
		myObj = new GameObject("door_011_008");
		pos = new Vector3(13.400000f, 3.325984f, 10.628572f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_322",true);
		CreateDoor(myObj,"textures/doors/doors_10", 53, 0);
		SetRotation(myObj,-90,-180,0);
		
		myObj = new GameObject("door_013_008");
		pos = new Vector3(15.800000f, 3.325984f, 10.628572f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_322",true);
		CreateDoor(myObj,"textures/doors/doors_10", 53, 0);
		SetRotation(myObj,-90,-180,0);
		
		myObj = new GameObject("some_writing_23_08_02_0933");
		pos = new Vector3(28.285715f, 3.930709f, 10.800000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_358",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_358",10,358, 0);
		SetRotation(myObj,0,-180,0);
		SetSprite(myObj, "Sprites/tmobj/tmobj_26");
		SetLink(myObj,653);
		
		myObj = new GameObject("a_light_mace_42_08_02_0616");
		pos = new Vector3(50.742855f, 3.628346f, 9.942857f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_008",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_008",1,8, 1);
		
		
		myObj = new GameObject("a_ghost_57_08_02_0191");
		pos = new Vector3(68.914284f, 3.817323f, 10.114285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"97","Sprites/objects_097");
		
		myObj = new GameObject("some_writing_60_08_02_0885");
		pos = new Vector3(72.171432f, 4.233071f, 10.800000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_358",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_358",10,358, 0);
		SetRotation(myObj,0,-180,0);
		SetSprite(myObj, "Sprites/tmobj/tmobj_26");
		SetLink(myObj,656);
		
		myObj = new GameObject("a_shrine_61_08_02_0633");
		pos = new Vector3(73.542854f, 3.628346f, 9.942857f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_343",true);
		
		
		myObj = new GameObject("a_plant_01_09_02_0830");
		pos = new Vector3(1.542857f, 3.628346f, 11.142858f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_206",true);
		
		myObj = new GameObject("a_plant_01_09_02_0831");
		pos = new Vector3(2.400000f, 3.628346f, 11.485714f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_206",true);
		
		myObj = new GameObject("a_pile_of_debris_piles_of_debris_01_09_02_0846");
		pos = new Vector3(1.542857f, 3.628346f, 11.657143f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_208",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_208",23,208, 1);
		
		myObj = new GameObject("a_plant_01_09_02_0847");
		pos = new Vector3(1.371428f, 3.628346f, 11.828571f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_192",true);
		
		myObj = new GameObject("a_plant_01_09_02_0854");
		pos = new Vector3(1.371428f, 3.628346f, 11.657143f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("some_grass_bunches_of_grass_01_09_02_0850");
		pos = new Vector3(2.057143f, 3.628346f, 10.971428f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("some_writing_01_09_02_0855");
		pos = new Vector3(1.200000f, 3.628346f, 12.000000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_358",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_358",10,358, 0);
		SetRotation(myObj,0,-180,0);
		SetSprite(myObj, "Sprites/tmobj/tmobj_20");
		SetLink(myObj,648);
		
		
		myObj = new GameObject("some_grass_bunches_of_grass_05_09_02_0643");
		pos = new Vector3(6.171429f, 3.628346f, 11.142858f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("a_pile_of_wood_chips_piles_of_wood_chips_05_09_02_0837");
		pos = new Vector3(7.028571f, 3.628346f, 11.485714f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_219",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_219",69,219, 0);
		
		myObj = new GameObject("some_leeches_bunches_of_leeches_05_09_02_0843");
		pos = new Vector3(6.514286f, 3.628346f, 11.314286f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_293",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_293",16,293, 1);
		
		myObj = new GameObject("door_015_009");
		pos = new Vector3(18.200001f, 3.628346f, 11.657143f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_322",true);
		CreateDoor(myObj,"textures/doors/doors_10", 53, 0);
		SetRotation(myObj,-90,-180,0);
		
		myObj = new GameObject("a_fighter_29_09_02_0188");
		pos = new Vector3(35.657143f, 3.628346f, 11.485714f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"93","Sprites/objects_093");
		myObj = new GameObject("a_shortsword_29_09_02_0574");
		pos = new Vector3(35.657143f, 3.628346f, 11.485714f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_004",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_004",1,4, 1);
		myObj = new GameObject("leather_gloves_pairs_of_leather_gloves_29_09_02_0573");
		pos = new Vector3(35.657143f, 3.628346f, 11.485714f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_038",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_038",2,38, 1);
		myObj = new GameObject("a_red_ring_29_09_02_0572");
		pos = new Vector3(35.657143f, 3.628346f, 11.485714f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_058",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_058",2,58, 1);
		myObj = new GameObject("a_green_potion_29_09_02_0965");
		pos = new Vector3(35.657143f, 3.628346f, 11.485714f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_188",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_188",14,188, 1);
		myObj = new GameObject("a_piece_of_cheese_pieces_of_cheese_29_09_02_0575");
		pos = new Vector3(35.657143f, 3.628346f, 11.485714f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_178",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_178",24,178, 1);
		
		myObj = new GameObject("a_fighter_36_09_02_0193");
		pos = new Vector3(43.714287f, 3.628346f, 11.314286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"94","Sprites/objects_094");
		myObj = new GameObject("a_mail_shirt_36_09_02_0704");
		pos = new Vector3(43.714287f, 3.628346f, 11.314286f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_033",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_033",2,33, 1);
		myObj = new GameObject("a_shortsword_36_09_02_0853");
		pos = new Vector3(43.714287f, 3.628346f, 11.314286f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_004",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_004",1,4, 1);
		
		myObj = new GameObject("special_tmap_obj_37_09_02_1010");
		pos = new Vector3(45.000000f, 3.628346f, 11.980000f);
		myObj.transform.position = pos;
		CreateTMAP(myObj,"textures/tmap/uw1_168");
		SetRotation(myObj,0,-180,0);
		CreateUWActivators(myObj,"ButtonHandler","a_look_trigger_99_99_02_1007",40,3,0,8);
		
		myObj = new GameObject("a_broken_blade_58_09_02_0882");
		pos = new Vector3(69.771431f, 3.930709f, 10.971428f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_280",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_280",16,280, 1);
		
		
		myObj = new GameObject("a_gray_lizardman_red_lizardmen_10_10_02_0238");
		pos = new Vector3(12.000000f, 3.325984f, 12.685714f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"89","Sprites/objects_089");
		
		
		myObj = new GameObject("special_tmap_obj_25_10_02_0558");
		pos = new Vector3(31.180000f, 2.418898f, 12.600000f);
		myObj.transform.position = pos;
		CreateTMAP(myObj,"textures/tmap/uw1_150");
		SetRotation(myObj,0,-90,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_366",34,366, 0);
		
		
		
		myObj = new GameObject("door_037_010");
		pos = new Vector3(45.400002f, 3.628346f, 12.000000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_327",true);
		CreateDoor(myObj,"textures/doors/doors_-12851", 53, 0);
		SetRotation(myObj,-90,0,0);
		
		myObj = new GameObject("a_broadsword_40_11_02_0650");
		pos = new Vector3(49.028568f, 3.628346f, 14.228572f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_006",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_006",1,6, 1);
		
		myObj = new GameObject("a_box_boxes_40_11_02_0656");
		pos = new Vector3(49.028568f, 3.628346f, 13.714286f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_132",true);
		
		myObj = new GameObject("door_017_012");
		pos = new Vector3(20.600000f, 3.628346f, 15.257142f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_322",true);
		CreateDoor(myObj,"textures/doors/doors_10", 53, 0);
		SetRotation(myObj,-90,-180,0);
		
		myObj = new GameObject("a_fighter_33_12_02_0221");
		pos = new Vector3(40.457142f, 3.628346f, 15.257142f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"93","Sprites/objects_093");
		myObj = new GameObject("a_green_potion_33_12_02_0876");
		pos = new Vector3(40.457142f, 3.628346f, 15.257142f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_188",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_188",14,188, 1);
		myObj = new GameObject("a_shortsword_33_12_02_0849");
		pos = new Vector3(40.457142f, 3.628346f, 15.257142f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_004",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_004",1,4, 1);
		myObj = new GameObject("a_leather_vest_33_12_02_0700");
		pos = new Vector3(40.457142f, 3.628346f, 15.257142f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_032",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_032",2,32, 1);
		myObj = new GameObject("a_cudgel_33_12_02_0768");
		pos = new Vector3(40.457142f, 3.628346f, 15.257142f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_007",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_007",1,7, 1);
		myObj = new GameObject("an_arrow_33_12_02_0767");
		pos = new Vector3(40.457142f, 3.628346f, 15.257142f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_018",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_018",1,18, 1);
		
		myObj = new GameObject("a_broken_axe_40_12_02_0648");
		pos = new Vector3(48.857143f, 3.628346f, 15.257142f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_200",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_200",23,200, 1);
		
		myObj = new GameObject("a_broken_mace_40_12_02_0649");
		pos = new Vector3(48.171432f, 3.628346f, 14.914286f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_202",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_202",23,202, 1);
		
		
		myObj = new GameObject("special_tmap_obj_52_12_02_0588");
		pos = new Vector3(63.000000f, 3.628346f, 15.580000f);
		myObj.transform.position = pos;
		CreateTMAP(myObj,"textures/tmap/uw1_152");
		SetRotation(myObj,0,-180,0);
		CreateUWActivators(myObj,"ButtonHandler","a_look_trigger_99_99_02_0586",40,2,0,8);
		
		
		myObj = new GameObject("a_bridge_17_13_02_0769");
		pos = new Vector3(20.914284f, 3.552756f, 16.114286f);
		myObj.transform.position = pos;
		
		myObj = new GameObject("a_bridge_44_13_02_0682");
		pos = new Vector3(53.314285f, 3.552756f, 16.285713f);
		myObj.transform.position = pos;
		
		myObj = new GameObject("a_bridge_45_13_02_0664");
		pos = new Vector3(54.514286f, 3.552756f, 16.285713f);
		myObj.transform.position = pos;
		
		myObj = new GameObject("a_bridge_46_13_02_0688");
		pos = new Vector3(55.714287f, 3.552756f, 16.285713f);
		myObj.transform.position = pos;
		
		myObj = new GameObject("a_bridge_47_13_02_0686");
		pos = new Vector3(56.914288f, 3.552756f, 16.285713f);
		myObj.transform.position = pos;
		
		myObj = new GameObject("a_bridge_48_13_02_0879");
		pos = new Vector3(58.114288f, 3.552756f, 16.285713f);
		myObj.transform.position = pos;
		
		
		myObj = new GameObject("door_052_013");
		pos = new Vector3(63.400002f, 3.628346f, 15.600000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_327",true);
		CreateDoor(myObj,"textures/doors/doors_-12851", 53, 0);
		SetRotation(myObj,-90,0,0);
		
		myObj = new GameObject("a_lever_52_13_02_0972");
		pos = new Vector3(62.914288f, 4.233071f, 16.799999f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_373",true);
		CreateUWActivators(myObj,"ButtonHandler","a_use_trigger_99_99_02_0971",40,0,0,8);
		
		myObj = new GameObject("a_bridge_17_14_02_0612");
		pos = new Vector3(20.914284f, 3.552756f, 17.314285f);
		myObj.transform.position = pos;
		
		
		myObj = new GameObject("a_bridge_17_15_02_0611");
		pos = new Vector3(20.914284f, 3.552756f, 18.514286f);
		myObj.transform.position = pos;
		
		myObj = new GameObject("a_splash_splahes_25_15_02_0989");
		pos = new Vector3(31.200001f, 2.418898f, 18.857141f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_454",true);
		
		myObj = new GameObject("a_bridge_39_15_02_0817");
		pos = new Vector3(47.314285f, 3.552756f, 18.514286f);
		myObj.transform.position = pos;
		
		
		myObj = new GameObject("a_bridge_17_16_02_0610");
		pos = new Vector3(20.914284f, 3.552756f, 19.714287f);
		myObj.transform.position = pos;
		
		myObj = new GameObject("a_splash_splahes_25_16_02_0986");
		pos = new Vector3(31.200001f, 2.418898f, 20.228571f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_454",true);
		
		myObj = new GameObject("a_splash_splahes_25_16_02_0980");
		pos = new Vector3(31.200001f, 2.418898f, 19.542858f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_454",true);
		
		myObj = new GameObject("a_bridge_32_16_02_0991");
		pos = new Vector3(38.914284f, 3.552756f, 19.714287f);
		myObj.transform.position = pos;
		
		myObj = new GameObject("a_bridge_39_16_02_0692");
		pos = new Vector3(47.314285f, 3.552756f, 19.714287f);
		myObj.transform.position = pos;
		
		myObj = new GameObject("a_lurker_07_17_02_0235");
		pos = new Vector3(8.914286f, 2.418898f, 20.914284f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"87","Sprites/objects_087");
		
		myObj = new GameObject("a_splash_splahes_25_17_02_0637");
		pos = new Vector3(31.200001f, 2.418898f, 21.428572f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_454",true);
		
		myObj = new GameObject("a_splash_splahes_25_17_02_0988");
		pos = new Vector3(31.200001f, 2.418898f, 20.742857f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_454",true);
		
		myObj = new GameObject("a_bridge_32_17_02_0963");
		pos = new Vector3(38.914284f, 3.552756f, 20.914284f);
		myObj.transform.position = pos;
		
		myObj = new GameObject("a_lurker_35_17_02_0233");
		pos = new Vector3(43.028568f, 3.325984f, 20.914284f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"87","Sprites/objects_087");
		
		myObj = new GameObject("a_bridge_39_17_02_0691");
		pos = new Vector3(47.314285f, 3.552756f, 20.914284f);
		myObj.transform.position = pos;
		
		myObj = new GameObject("a_splash_splahes_25_18_02_0978");
		pos = new Vector3(31.200001f, 2.418898f, 21.771429f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_454",true);
		
		myObj = new GameObject("door_003_019");
		pos = new Vector3(3.800000f, 2.721260f, 24.000000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_323",true);
		CreateDoor(myObj,"textures/doors/doors_04", 53, 0);
		SetRotation(myObj,-90,-180,0);
		
		myObj = new GameObject("a_pouch_pouches_26_19_02_0758");
		pos = new Vector3(31.714285f, 3.628346f, 22.971428f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_134",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_134",19,134, 1);
		////Container contents
		ParentContainer = myObj.AddComponent<Container>();
		myObj.GetComponent<ObjectInteraction>().isContainer = true;
		myObj = new GameObject("a_sapphire_26_19_02_0766");
		pos = new Vector3(31.714285f, 3.628346f, 22.971428f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_166",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_166",18,166, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 0);
		myObj = new GameObject("a_fish_fish_26_19_02_0765");
		pos = new Vector3(31.714285f, 3.628346f, 22.971428f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_182",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_182",24,182, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 1);
		////Container contents complete
		
		myObj = new GameObject("a_plant_26_19_02_0741");
		pos = new Vector3(31.371428f, 3.628346f, 22.971428f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("a_cave_bat_01_20_02_0217");
		pos = new Vector3(1.714286f, 3.628346f, 24.514284f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"66","Sprites/objects_066");
		
		
		myObj = new GameObject("some_writing_12_20_02_0990");
		pos = new Vector3(14.742858f, 4.233071f, 24.000000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_358",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_358",10,358, 0);
		SetRotation(myObj,0,0,0);
		SetSprite(myObj, "Sprites/tmobj/tmobj_26");
		SetLink(myObj,654);
		
		myObj = new GameObject("a_cave_bat_02_21_02_0218");
		pos = new Vector3(2.400000f, 3.628346f, 26.400000f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"66","Sprites/objects_066");
		
		myObj = new GameObject("door_014_021");
		pos = new Vector3(17.657143f, 3.628346f, 25.400000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_323",true);
		CreateDoor(myObj,"textures/doors/doors_04", 53, 0);
		SetRotation(myObj,-90,90,0);
		
		myObj = new GameObject("a_green_lizardman_green_lizardmen_25_21_02_0253");
		pos = new Vector3(30.514284f, 3.628346f, 25.714285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"85","Sprites/objects_085");
		
		
		myObj = new GameObject("a_green_lizardman_green_lizardmen_29_21_02_0183");
		pos = new Vector3(35.314285f, 3.628346f, 25.714285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"85","Sprites/objects_085");
		
		myObj = new GameObject("door_031_021");
		pos = new Vector3(38.057144f, 3.628346f, 25.400000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_321",true);
		CreateDoor(myObj,"textures/doors/doors_05", 11, 1);
		SetRotation(myObj,-90,90,0);
		
		myObj = new GameObject("door_033_021");
		pos = new Vector3(39.942856f, 3.628346f, 25.400000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_321",true);
		CreateDoor(myObj,"textures/doors/doors_05", 11, 1);
		SetRotation(myObj,-90,90,0);
		
		myObj = new GameObject("a_mage_27_22_02_0252");
		pos = new Vector3(33.257145f, 3.628346f, 27.085716f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"106","Sprites/objects_106");
		
		myObj = new GameObject("door_027_022");
		pos = new Vector3(32.400002f, 3.628346f, 26.600000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_326",true);
		CreateDoor(myObj,"textures/doors/doors_-12851", 0, 1);
		SetRotation(myObj,-90,90,0);
		SetPortcullis(myObj,true);
		
		myObj = new GameObject("a_shrine_41_22_02_0634");
		pos = new Vector3(49.714287f, 2.721260f, 27.257143f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_343",true);
		
		myObj = new GameObject("a_lurker_52_22_02_0232");
		pos = new Vector3(62.914288f, 3.325984f, 26.914284f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"87","Sprites/objects_087");
		
		myObj = new GameObject("a_giant_spider_13_23_02_0184");
		pos = new Vector3(16.114286f, 3.628346f, 28.114285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"68","Sprites/objects_068");
		
		myObj = new GameObject("door_032_023");
		pos = new Vector3(38.599998f, 3.628346f, 28.628572f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_324",true);
		CreateDoor(myObj,"textures/doors/doors_12", 53, 0);
		SetRotation(myObj,-90,-180,0);
		
		myObj = new GameObject("a_red_lizardman_red_lizardmen_41_23_02_0213");
		pos = new Vector3(49.714287f, 2.418898f, 28.114285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"88","Sprites/objects_088");
		
		myObj = new GameObject("a_light_mace_13_24_02_0563");
		pos = new Vector3(15.942858f, 3.628346f, 29.657143f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_008",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_008",1,8, 1);
		
		myObj = new GameObject("a_coin_13_24_02_0561");
		pos = new Vector3(16.114286f, 3.628346f, 29.314285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_160",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_160",18,160, 1);
		
		myObj = new GameObject("mail_leggings_pairs_of_mail_leggings_13_24_02_0562");
		pos = new Vector3(15.942858f, 3.628346f, 29.142857f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_036",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_036",2,36, 1);
		
		myObj = new GameObject("door_015_024");
		pos = new Vector3(18.857141f, 3.628346f, 29.000000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_323",true);
		CreateDoor(myObj,"textures/doors/doors_04", 53, 0);
		SetRotation(myObj,-90,90,0);
		
		myObj = new GameObject("a_red_lizardman_red_lizardmen_34_24_02_0248");
		pos = new Vector3(41.314285f, 3.628346f, 29.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"88","Sprites/objects_088");
		
		myObj = new GameObject("a_red_lizardman_red_lizardmen_57_24_02_0212");
		pos = new Vector3(68.914284f, 3.628346f, 29.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"88","Sprites/objects_088");
		
		myObj = new GameObject("some_grass_bunches_of_grass_01_25_02_0759");
		pos = new Vector3(1.371428f, 2.418898f, 30.685715f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("a_plant_01_25_02_0774");
		pos = new Vector3(1.542857f, 2.418898f, 31.028572f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("a_plant_01_25_02_0775");
		pos = new Vector3(2.057143f, 2.418898f, 30.685715f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("some_grass_bunches_of_grass_02_25_02_0754");
		pos = new Vector3(3.257143f, 2.418898f, 30.342857f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("some_grass_bunches_of_grass_02_25_02_0757");
		pos = new Vector3(2.742857f, 2.418898f, 30.685715f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("a_plant_02_25_02_0771");
		pos = new Vector3(3.085714f, 2.418898f, 30.685715f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("some_grass_bunches_of_grass_04_25_02_0749");
		pos = new Vector3(5.657143f, 2.418898f, 31.028572f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("some_grass_bunches_of_grass_04_25_02_0752");
		pos = new Vector3(4.800000f, 2.418898f, 30.514284f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("a_plant_04_25_02_0763");
		pos = new Vector3(5.828571f, 2.456693f, 30.514284f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("a_plant_04_25_02_0764");
		pos = new Vector3(5.142857f, 2.456693f, 30.857143f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("door_020_025");
		pos = new Vector3(24.171429f, 3.628346f, 30.200001f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_324",true);
		CreateDoor(myObj,"textures/doors/doors_12", 11, 1);
		SetRotation(myObj,-90,90,0);
		
		myObj = new GameObject("door_042_025");
		pos = new Vector3(50.599998f, 2.418898f, 31.028572f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_324",true);
		CreateDoor(myObj,"textures/doors/doors_12", 9, 1);
		SetRotation(myObj,-90,-180,0);
		
		myObj = new GameObject("door_045_025");
		pos = new Vector3(54.200001f, 2.418898f, 31.028572f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_324",true);
		CreateDoor(myObj,"textures/doors/doors_12", 9, 1);
		SetRotation(myObj,-90,-180,0);
		
		myObj = new GameObject("a_lurker_01_26_02_0240");
		pos = new Vector3(1.714286f, 2.418898f, 31.714285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"87","Sprites/objects_087");
		
		myObj = new GameObject("a_bridge_03_26_02_0878");
		pos = new Vector3(4.114285f, 2.645669f, 31.714285f);
		myObj.transform.position = pos;
		
		myObj = new GameObject("a_pouch_pouches_08_26_02_0568");
		pos = new Vector3(10.114285f, 3.628346f, 31.714285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_134",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_134",19,134, 1);
		////Container contents
		ParentContainer = myObj.AddComponent<Container>();
		myObj.GetComponent<ObjectInteraction>().isContainer = true;
		myObj = new GameObject("a_key_011_1");
		pos = new Vector3(10.114285f, 3.628346f, 31.714285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_263",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_263",5,263, 1);
		CreateKey(myObj, 11);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 0);
		myObj = new GameObject("a_ruby_rubies_08_26_02_0567");
		pos = new Vector3(10.114285f, 3.628346f, 31.714285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_162",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_162",18,162, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 1);
		myObj = new GameObject("a_green_potion_08_26_02_0566");
		pos = new Vector3(10.114285f, 3.628346f, 31.714285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_188",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_188",14,188, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 2);
		myObj = new GameObject("a_piece_of_meat_pieces_of_meat_08_26_02_0896");
		pos = new Vector3(10.114285f, 3.628346f, 31.714285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_176",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_176",24,176, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 3);
		////Container contents complete
		
		myObj = new GameObject("a_skeleton_10_26_02_0185");
		pos = new Vector3(12.514286f, 3.628346f, 31.714285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"74","Sprites/objects_074");
		
		myObj = new GameObject("a_skeleton_12_26_02_0186");
		pos = new Vector3(14.914286f, 3.628346f, 31.714285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"74","Sprites/objects_074");
		
		myObj = new GameObject("door_015_026");
		pos = new Vector3(19.028572f, 3.628346f, 31.400000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_321",true);
		CreateDoor(myObj,"textures/doors/doors_05", 0, 1);
		SetRotation(myObj,-90,90,0);
		
		myObj = new GameObject("door_025_026");
		pos = new Vector3(30.200001f, 3.628346f, 32.228573f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_324",true);
		CreateDoor(myObj,"textures/doors/doors_12", 11, 1);
		SetRotation(myObj,-90,-180,0);
		
		myObj = new GameObject("door_029_026");
		pos = new Vector3(35.000000f, 3.628346f, 32.228573f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_324",true);
		CreateDoor(myObj,"textures/doors/doors_12", 11, 1);
		SetRotation(myObj,-90,-180,0);
		
		myObj = new GameObject("door_033_026");
		pos = new Vector3(39.799999f, 3.628346f, 32.228573f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_324",true);
		CreateDoor(myObj,"textures/doors/doors_12", 11, 1);
		SetRotation(myObj,-90,-180,0);
		
		myObj = new GameObject("a_bridge_03_27_02_0877");
		pos = new Vector3(4.114285f, 2.645669f, 32.914284f);
		myObj.transform.position = pos;
		
		myObj = new GameObject("a_plant_23_27_02_0560");
		pos = new Vector3(28.114285f, 3.628346f, 33.428574f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_192",true);
		
		myObj = new GameObject("some_grass_bunches_of_grass_28_27_02_0559");
		pos = new Vector3(34.628571f, 3.628346f, 33.428574f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("some_grass_bunches_of_grass_30_27_02_0557");
		pos = new Vector3(36.171429f, 3.628346f, 33.428574f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("door_042_027");
		pos = new Vector3(50.599998f, 2.418898f, 32.571426f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_324",true);
		CreateDoor(myObj,"textures/doors/doors_12", 9, 1);
		SetRotation(myObj,-90,-180,0);
		
		myObj = new GameObject("some_grass_bunches_of_grass_03_28_02_0740");
		pos = new Vector3(4.457143f, 2.721260f, 33.771427f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("some_grass_bunches_of_grass_03_28_02_0743");
		pos = new Vector3(3.942857f, 2.721260f, 34.285717f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("some_grass_bunches_of_grass_04_28_02_0736");
		pos = new Vector3(5.485714f, 2.721260f, 34.285717f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("some_grass_bunches_of_grass_04_28_02_0739");
		pos = new Vector3(5.828571f, 2.721260f, 33.771427f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("a_plant_05_28_02_0804");
		pos = new Vector3(7.028571f, 2.418898f, 34.628571f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("a_plant_05_28_02_0805");
		pos = new Vector3(7.028571f, 2.418898f, 33.771427f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("a_green_lizardman_green_lizardmen_23_28_02_0251");
		pos = new Vector3(28.285715f, 3.628346f, 34.114285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"85","Sprites/objects_085");
		myObj = new GameObject("a_red_gem_23_28_02_0860");
		pos = new Vector3(28.285715f, 3.628346f, 34.114285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_163",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_163",18,163, 1);
		
		myObj = new GameObject("some_grass_bunches_of_grass_24_28_02_0761");
		pos = new Vector3(29.657143f, 3.628346f, 33.942856f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("some_grass_bunches_of_grass_25_28_02_0772");
		pos = new Vector3(30.342857f, 3.628346f, 34.457142f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("a_green_lizardman_green_lizardmen_29_28_02_0250");
		pos = new Vector3(35.485714f, 3.628346f, 34.114285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"85","Sprites/objects_085");
		
		myObj = new GameObject("a_green_lizardman_green_lizardmen_33_28_02_0249");
		pos = new Vector3(40.114285f, 3.628346f, 34.114285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"85","Sprites/objects_085");
		
		myObj = new GameObject("some_writing_44_28_02_0907");
		pos = new Vector3(52.799999f, 3.325984f, 34.285717f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_358",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_358",10,358, 0);
		SetRotation(myObj,0,90,0);
		SetSprite(myObj, "Sprites/tmobj/tmobj_20");
		SetLink(myObj,652);
		
		myObj = new GameObject("a_bridge_53_28_02_0959");
		pos = new Vector3(64.285713f, 3.552756f, 34.114285f);
		myObj.transform.position = pos;
		
		myObj = new GameObject("a_bridge_54_28_02_0958");
		pos = new Vector3(65.485710f, 3.552756f, 34.114285f);
		myObj.transform.position = pos;
		
		myObj = new GameObject("door_055_028");
		pos = new Vector3(66.171432f, 3.628346f, 33.799999f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_323",true);
		CreateDoor(myObj,"textures/doors/doors_04", 9, 1);
		SetRotation(myObj,-90,90,0);
		
		myObj = new GameObject("some_grass_bunches_of_grass_02_29_02_0746");
		pos = new Vector3(2.742857f, 2.418898f, 35.828571f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("some_grass_bunches_of_grass_02_29_02_0747");
		pos = new Vector3(3.428571f, 2.418898f, 35.314285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("a_plant_02_29_02_0825");
		pos = new Vector3(3.257143f, 2.418898f, 35.828571f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("a_plant_02_29_02_0826");
		pos = new Vector3(2.571429f, 2.418898f, 35.142857f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("some_grass_bunches_of_grass_03_29_02_0733");
		pos = new Vector3(4.628572f, 2.721260f, 35.657143f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("some_grass_bunches_of_grass_04_29_02_0728");
		pos = new Vector3(6.000000f, 2.721260f, 35.142857f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("some_grass_bunches_of_grass_05_29_02_0725");
		pos = new Vector3(6.171429f, 2.721260f, 35.828571f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("some_grass_bunches_of_grass_06_29_02_0721");
		pos = new Vector3(7.885714f, 2.721260f, 34.971428f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("some_grass_bunches_of_grass_07_29_02_0719");
		pos = new Vector3(9.428571f, 2.418898f, 35.314285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("a_plant_08_29_02_0715");
		pos = new Vector3(10.114285f, 2.418898f, 35.314285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("door_021_029");
		pos = new Vector3(25.400000f, 3.628346f, 35.314285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_324",true);
		CreateDoor(myObj,"textures/doors/doors_12", 53, 0);
		SetRotation(myObj,-90,-180,0);
		
		myObj = new GameObject("a_red_lizardman_red_lizardmen_41_29_02_0219");
		pos = new Vector3(49.714287f, 2.418898f, 35.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"88","Sprites/objects_088");
		myObj = new GameObject("a_scroll_41_29_02_0784");
		pos = new Vector3(49.714287f, 2.418898f, 35.314285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_318",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_318",13,318, 1);
		
		myObj = new GameObject("a_red_lizardman_red_lizardmen_44_29_02_0216");
		pos = new Vector3(53.314285f, 2.418898f, 35.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"88","Sprites/objects_088");
		
		myObj = new GameObject("door_046_029");
		pos = new Vector3(56.228569f, 2.418898f, 35.000000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_324",true);
		CreateDoor(myObj,"textures/doors/doors_12", 9, 1);
		SetRotation(myObj,-90,90,0);
		
		myObj = new GameObject("a_plant_02_30_02_0822");
		pos = new Vector3(2.571429f, 2.418898f, 36.514286f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("some_grass_bunches_of_grass_03_30_02_0707");
		pos = new Vector3(4.285714f, 2.721260f, 36.000000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("some_grass_bunches_of_grass_04_30_02_0710");
		pos = new Vector3(4.971428f, 2.721260f, 36.857143f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("some_grass_bunches_of_grass_05_30_02_0713");
		pos = new Vector3(6.514286f, 2.418898f, 36.514286f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("an_emerald_41_30_02_0570");
		pos = new Vector3(49.885712f, 2.721260f, 36.342857f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_167",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_167",18,167, 1);
		
		myObj = new GameObject("a_sapphire_42_30_02_0581");
		pos = new Vector3(51.085712f, 2.721260f, 36.342857f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_166",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_166",18,166, 1);
		
		myObj = new GameObject("some_grass_bunches_of_grass_02_31_02_0694");
		pos = new Vector3(3.600000f, 2.683464f, 38.228573f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("a_plant_02_31_02_0820");
		pos = new Vector3(2.742857f, 2.418898f, 37.371429f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("some_grass_bunches_of_grass_03_31_02_0697");
		pos = new Vector3(4.628572f, 2.721260f, 38.228573f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("some_grass_bunches_of_grass_03_31_02_0698");
		pos = new Vector3(4.114285f, 2.721260f, 38.228573f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("some_grass_bunches_of_grass_04_31_02_0701");
		pos = new Vector3(4.800000f, 2.721260f, 37.200001f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("some_grass_bunches_of_grass_04_31_02_0705");
		pos = new Vector3(6.000000f, 2.721260f, 37.885715f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("a_plant_05_31_02_0810");
		pos = new Vector3(7.200000f, 2.418898f, 37.371429f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("a_pile_of_debris_piles_of_debris_27_31_02_0623");
		pos = new Vector3(32.742855f, 3.628346f, 37.714283f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_209",23,209, 1);
		
		myObj = new GameObject("a_green_lizardman_green_lizardmen_36_31_02_0246");
		pos = new Vector3(43.714287f, 2.418898f, 37.714283f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"85","Sprites/objects_085");
		
		myObj = new GameObject("a_green_lizardman_green_lizardmen_38_31_02_0245");
		pos = new Vector3(46.114288f, 2.418898f, 37.714283f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"85","Sprites/objects_085");
		
		myObj = new GameObject("a_plant_02_32_02_0818");
		pos = new Vector3(2.400000f, 2.418898f, 38.914284f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("some_grass_bunches_of_grass_04_32_02_0683");
		pos = new Vector3(5.657143f, 2.721260f, 38.571426f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("a_torch_torches_23_32_02_0624");
		pos = new Vector3(28.457144f, 3.628346f, 38.914284f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_145",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_145",9,145, 1);
		
		myObj = new GameObject("a_quiver_23_32_02_0629");
		pos = new Vector3(28.457144f, 3.628346f, 38.571426f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_141",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_141",19,141, 1);
		////Container contents complete
		
		myObj = new GameObject("a_crossbow_23_32_02_0638");
		pos = new Vector3(27.942856f, 3.628346f, 38.742855f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_026",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_026",1,26, 1);
		
		myObj = new GameObject("a_red_lizardman_red_lizardmen_37_32_02_0247");
		pos = new Vector3(44.914288f, 3.628346f, 38.914284f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"88","Sprites/objects_088");
		
		myObj = new GameObject("door_040_032");
		pos = new Vector3(48.171432f, 2.418898f, 38.599998f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_325",true);
		CreateDoor(myObj,"textures/doors/doors_03", 9, 1);
		SetRotation(myObj,-90,90,0);
		
		myObj = new GameObject("some_grass_bunches_of_grass_02_33_02_0677");
		pos = new Vector3(3.257143f, 2.570079f, 39.771427f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("a_plant_02_33_02_0815");
		pos = new Vector3(2.571429f, 2.418898f, 40.628571f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("some_grass_bunches_of_grass_03_33_02_0672");
		pos = new Vector3(4.628572f, 2.721260f, 39.771427f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("some_grass_bunches_of_grass_04_33_02_0671");
		pos = new Vector3(5.142857f, 2.721260f, 39.942856f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("some_grass_bunches_of_grass_05_33_02_0663");
		pos = new Vector3(7.028571f, 2.418898f, 39.771427f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("a_plant_05_33_02_0813");
		pos = new Vector3(7.028571f, 2.418898f, 40.114285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("a_mist_cloud_06_33_02_0809");
		pos = new Vector3(8.228571f, 2.721260f, 40.799999f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_449",true);
		
		myObj = new GameObject("a_plant_06_33_02_0807");
		pos = new Vector3(8.228571f, 2.418898f, 40.114285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("a_green_lizardman_green_lizardmen_11_33_02_0222");
		pos = new Vector3(13.714286f, 3.628346f, 40.114285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"85","Sprites/objects_085");
		
		myObj = new GameObject("a_pouch_pouches_18_33_02_0642");
		pos = new Vector3(22.114285f, 3.628346f, 40.114285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_134",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_134",19,134, 1);
		////Container contents
		ParentContainer = myObj.AddComponent<Container>();
		myObj.GetComponent<ObjectInteraction>().isContainer = true;
		myObj = new GameObject("a_green_potion_18_33_02_0571");
		pos = new Vector3(22.114285f, 3.628346f, 40.114285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_188",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_188",14,188, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 0);
		myObj = new GameObject("a_Por_stone_18_33_02_0641");
		pos = new Vector3(22.114285f, 3.628346f, 40.114285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_247",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_247",6,247, 1);
		SetObjectAsRuneStone(myObj);
		
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 1);
		myObj = new GameObject("an_Ort_stone_18_33_02_0576");
		pos = new Vector3(22.114285f, 3.628346f, 40.114285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_246",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_246",6,246, 1);
		SetObjectAsRuneStone(myObj);
		
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 2);
		myObj = new GameObject("a_book_18_33_02_0867");
		pos = new Vector3(22.114285f, 3.628346f, 40.114285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_305",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_305",11,305, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 3);
		////Container contents complete
		
		myObj = new GameObject("some_grass_bunches_of_grass_04_34_02_0660");
		pos = new Vector3(5.828571f, 2.721260f, 40.799999f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("some_grass_bunches_of_grass_04_34_02_0662");
		pos = new Vector3(4.971428f, 2.721260f, 41.314285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("a_mist_cloud_06_34_02_0668");
		pos = new Vector3(8.057143f, 2.418898f, 42.000000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_449",true);
		
		myObj = new GameObject("a_lurker_07_34_02_0237");
		pos = new Vector3(8.914286f, 2.418898f, 41.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"87","Sprites/objects_087");
		
		myObj = new GameObject("a_leather_cap_18_34_02_0621");
		pos = new Vector3(21.942856f, 3.628346f, 41.657143f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_044",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_044",2,44, 1);
		
		myObj = new GameObject("a_wolf_spider_18_34_02_0215");
		pos = new Vector3(22.799999f, 3.628346f, 41.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"83","Sprites/objects_083");
		
		myObj = new GameObject("a_plant_02_35_02_0802");
		pos = new Vector3(2.571429f, 2.418898f, 42.342857f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("a_plant_03_35_02_0800");
		pos = new Vector3(3.942857f, 2.721260f, 43.028568f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("a_pile_of_debris_piles_of_debris_28_35_02_0622");
		pos = new Vector3(34.457142f, 3.628346f, 42.514286f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_209",23,209, 1);
		
		myObj = new GameObject("special_tmap_obj_32_35_02_0952");
		pos = new Vector3(39.000000f, 3.628346f, 42.020000f);
		myObj.transform.position = pos;
		CreateTMAP(myObj,"textures/tmap/uw1_127");
		SetRotation(myObj,0,0,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_366",34,366, 0);
		
		myObj = new GameObject("a_plant_02_36_02_0798");
		pos = new Vector3(2.400000f, 2.418898f, 43.542858f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("a_plant_03_36_02_0799");
		pos = new Vector3(3.771429f, 2.721260f, 43.371429f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("a_plant_05_36_02_0785");
		pos = new Vector3(7.028571f, 2.418898f, 44.057144f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("some_writing_18_36_02_0898");
		pos = new Vector3(22.114285f, 4.233071f, 44.400002f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_358",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_358",10,358, 0);
		SetRotation(myObj,0,-180,0);
		SetSprite(myObj, "Sprites/tmobj/tmobj_20");
		SetLink(myObj,657);
		
		
		
		myObj = new GameObject("special_tmap_obj_24_36_02_0983");
		pos = new Vector3(28.820000f, 3.628346f, 43.799999f);
		myObj.transform.position = pos;
		CreateTMAP(myObj,"textures/tmap/uw1_141");
		SetRotation(myObj,0,90,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_366",34,366, 0);
		
		myObj = new GameObject("a_pouch_pouches_37_36_02_0862");
		pos = new Vector3(44.914288f, 3.628346f, 43.714287f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_134",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_134",19,134, 1);
		////Container contents
		ParentContainer = myObj.AddComponent<Container>();
		myObj.GetComponent<ObjectInteraction>().isContainer = true;
		myObj = new GameObject("a_scroll_37_36_02_0695");
		pos = new Vector3(44.914288f, 3.628346f, 43.714287f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_316",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_316",13,316, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 0);
		myObj = new GameObject("a_key_008_1");
		pos = new Vector3(44.914288f, 3.628346f, 43.714287f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_256",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_256",5,256, 1);
		CreateKey(myObj, 8);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 1);
		////Container contents complete
		
		myObj = new GameObject("a_broken_shield_37_36_02_0819");
		pos = new Vector3(45.085712f, 3.628346f, 43.371429f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_203",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_203",23,203, 1);
		
		myObj = new GameObject("a_skull_37_36_02_0717");
		pos = new Vector3(45.257145f, 3.628346f, 43.371429f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_194",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_194",23,194, 1);
		
		myObj = new GameObject("a_pile_of_bones_piles_of_bones_37_36_02_0708");
		pos = new Vector3(45.599998f, 3.628346f, 43.371429f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_198",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_198",23,198, 1);
		
		myObj = new GameObject("a_broken_mace_37_36_02_0693");
		pos = new Vector3(45.257145f, 3.628346f, 43.542858f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_202",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_202",23,202, 1);
		
		myObj = new GameObject("a_plant_03_37_02_0795");
		pos = new Vector3(3.942857f, 2.418898f, 44.914288f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("a_plant_04_37_02_0790");
		pos = new Vector3(5.828571f, 2.721260f, 45.085712f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("a_plant_05_37_02_0791");
		pos = new Vector3(7.200000f, 2.418898f, 44.914288f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("a_plant_07_37_02_0792");
		pos = new Vector3(8.742857f, 2.418898f, 45.085712f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("a_lurker_51_37_02_0231");
		pos = new Vector3(61.714287f, 3.325984f, 44.914288f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"87","Sprites/objects_087");
		
		myObj = new GameObject("a_plant_02_38_02_0796");
		pos = new Vector3(2.571429f, 2.418898f, 46.457142f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("a_bridge_04_38_02_0943");
		pos = new Vector3(5.314286f, 2.645669f, 46.114288f);
		myObj.transform.position = pos;
		
		myObj = new GameObject("a_mist_cloud_08_38_02_0681");
		pos = new Vector3(9.942857f, 2.116535f, 46.799999f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_449",true);
		
		myObj = new GameObject("a_mushroom_11_38_02_0852");
		pos = new Vector3(13.714286f, 1.814173f, 46.114288f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_184",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_184",24,184, 1);
		
		myObj = new GameObject("a_plant_11_38_02_0712");
		pos = new Vector3(14.057142f, 1.814173f, 46.114288f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("a_green_potion_42_38_02_0908");
		pos = new Vector3(50.400002f, 3.628346f, 45.942856f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_188",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_188",14,188, 1);
		
		myObj = new GameObject("some_rubble_piles_of_rubble_42_38_02_0722");
		pos = new Vector3(50.742855f, 3.628346f, 45.771431f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_218",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_218",69,218, 0);
		
		myObj = new GameObject("some_writing_42_38_02_0578");
		pos = new Vector3(50.400002f, 4.535433f, 45.599998f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_358",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_358",10,358, 0);
		SetRotation(myObj,0,90,0);
		SetSprite(myObj, "Sprites/tmobj/tmobj_20");
		SetLink(myObj,658);
		
		myObj = new GameObject("a_headless_headlesses_43_38_02_0178");
		pos = new Vector3(52.114288f, 3.628346f, 46.114288f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"91","Sprites/objects_091");
		
		
		
		myObj = new GameObject("a_fighter_47_38_02_0254");
		pos = new Vector3(56.914288f, 3.628346f, 46.114288f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"104","Sprites/objects_104");
		myObj = new GameObject("a_longsword_47_38_02_0635");
		pos = new Vector3(56.914288f, 3.628346f, 46.114288f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_005",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_005",1,5, 1);
		myObj = new GameObject("a_taper_47_38_02_0880");
		pos = new Vector3(56.914288f, 3.628346f, 46.114288f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_147",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_147",9,147, 1);
		myObj = new GameObject("a_lantern_47_38_02_0755");
		pos = new Vector3(56.914288f, 3.628346f, 46.114288f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_144",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_144",9,144, 1);
		myObj = new GameObject("a_torch_torches_47_38_02_0640");
		pos = new Vector3(56.914288f, 3.628346f, 46.114288f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_145",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_145",9,145, 1);
		myObj = new GameObject("a_candle_47_38_02_0628");
		pos = new Vector3(56.914288f, 3.628346f, 46.114288f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_146",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_146",9,146, 1);
		
		myObj = new GameObject("special_tmap_obj_49_38_02_0742");
		pos = new Vector3(59.980000f, 3.628346f, 46.200001f);
		myObj.transform.position = pos;
		CreateTMAP(myObj,"textures/tmap/uw1_040");
		SetRotation(myObj,0,-90,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_366",34,366, 0);
		
		myObj = new GameObject("a_scroll_49_38_02_0966");
		pos = new Vector3(59.485714f, 3.628346f, 45.942856f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_314",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_314",13,314, 1);
		
		
		myObj = new GameObject("a_bridge_04_39_02_0942");
		pos = new Vector3(5.314286f, 2.645669f, 47.314285f);
		myObj.transform.position = pos;
		
		myObj = new GameObject("some_grass_bunches_of_grass_09_39_02_0685");
		pos = new Vector3(11.314286f, 1.814173f, 47.314285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("a_mist_cloud_09_39_02_0673");
		pos = new Vector3(11.314286f, 2.418898f, 47.314285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_449",true);
		
		myObj = new GameObject("a_plant_11_39_02_0744");
		pos = new Vector3(13.200000f, 1.814173f, 48.000000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_192",true);
		
		myObj = new GameObject("a_dread_spider_35_39_02_0243");
		pos = new Vector3(43.200001f, 3.628346f, 47.142857f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"92","Sprites/objects_092");
		
		myObj = new GameObject("a_bench_benches_46_39_02_0696");
		pos = new Vector3(55.371429f, 3.628346f, 47.314285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_336",true);
		
		myObj = new GameObject("a_boulder_49_39_02_0824");
		pos = new Vector3(59.485714f, 3.628346f, 47.485714f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_341",true);
		
		myObj = new GameObject("a_plant_03_40_02_0781");
		pos = new Vector3(3.771429f, 2.418898f, 48.685715f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("a_plant_03_40_02_0783");
		pos = new Vector3(3.771429f, 2.418898f, 48.000000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("a_plant_04_40_02_0780");
		pos = new Vector3(4.800000f, 2.721260f, 49.200001f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("a_wolf_spider_35_40_02_0242");
		pos = new Vector3(42.171432f, 3.628346f, 48.171432f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"83","Sprites/objects_083");
		
		myObj = new GameObject("a_torch_torches_35_40_02_0703");
		pos = new Vector3(42.000000f, 3.628346f, 48.342857f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_145",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_145",9,145, 1);
		
		myObj = new GameObject("a_sack_35_40_02_0666");
		pos = new Vector3(43.028568f, 3.628346f, 49.028568f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_128",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_128",19,128, 1);
		////Container contents
		ParentContainer = myObj.AddComponent<Container>();
		myObj.GetComponent<ObjectInteraction>().isContainer = true;
		myObj = new GameObject("a_dagger_35_40_02_0808");
		pos = new Vector3(43.028568f, 3.628346f, 49.028568f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_003",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_003",1,3, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 0);
		myObj = new GameObject("a_key_009_1");
		pos = new Vector3(43.028568f, 3.628346f, 49.028568f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_259",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_259",5,259, 1);
		CreateKey(myObj, 9);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 1);
		myObj = new GameObject("an_apple_35_40_02_0699");
		pos = new Vector3(43.028568f, 3.628346f, 49.028568f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_179",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_179",24,179, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 2);
		myObj = new GameObject("a_Des_stone_35_40_02_0816");
		pos = new Vector3(43.028568f, 3.628346f, 49.028568f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_235",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_235",6,235, 1);
		SetObjectAsRuneStone(myObj);
		
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 3);
		myObj = new GameObject("a_gold_coin_35_40_02_0684");
		pos = new Vector3(43.028568f, 3.628346f, 49.028568f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_161",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_161",18,161, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 4);
		myObj = new GameObject("a_candle_35_40_02_0687");
		pos = new Vector3(43.028568f, 3.628346f, 49.028568f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_146",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_146",9,146, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 5);
		////Container contents complete
		
		myObj = new GameObject("a_pile_of_bones_piles_of_bones_35_40_02_0667");
		pos = new Vector3(42.685715f, 3.628346f, 48.342857f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_198",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_198",23,198, 1);
		
		myObj = new GameObject("a_skull_35_40_02_0811");
		pos = new Vector3(42.514286f, 3.628346f, 48.514286f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_194",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_194",23,194, 1);
		
		myObj = new GameObject("a_pile_of_debris_piles_of_debris_35_40_02_0659");
		pos = new Vector3(42.171432f, 3.628346f, 48.857143f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_214",true);
		
		myObj = new GameObject("a_piece_of_cheese_pieces_of_cheese_39_40_02_0905");
		pos = new Vector3(47.314285f, 3.628346f, 48.514286f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_178",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_178",24,178, 1);
		
		myObj = new GameObject("a_giant_rat_40_40_02_0194");
		pos = new Vector3(48.514286f, 3.628346f, 48.514286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"72","Sprites/objects_072");
		
		myObj = new GameObject("some_rubble_piles_of_rubble_49_40_02_0806");
		pos = new Vector3(59.657143f, 3.628346f, 48.342857f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_218",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_218",69,218, 0);
		
		myObj = new GameObject("special_tmap_obj_01_41_02_0941");
		pos = new Vector3(1.800000f, 2.418898f, 50.380001f);
		myObj.transform.position = pos;
		CreateTMAP(myObj,"textures/tmap/uw1_150");
		SetRotation(myObj,0,-180,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_366",34,366, 0);
		
		myObj = new GameObject("special_tmap_obj_02_41_02_0940");
		pos = new Vector3(3.000000f, 2.418898f, 50.380001f);
		myObj.transform.position = pos;
		CreateTMAP(myObj,"textures/tmap/uw1_150");
		SetRotation(myObj,0,-180,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_366",34,366, 0);
		
		myObj = new GameObject("a_plant_03_41_02_0778");
		pos = new Vector3(3.942857f, 2.418898f, 49.714287f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("a_plant_03_41_02_0779");
		pos = new Vector3(3.771429f, 2.418898f, 49.371429f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("a_plant_04_41_02_0777");
		pos = new Vector3(4.800000f, 2.721260f, 50.400002f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("a_plant_05_41_02_0776");
		pos = new Vector3(6.171429f, 2.721260f, 50.228569f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("a_plant_09_41_02_0714");
		pos = new Vector3(11.314286f, 1.814173f, 49.714287f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_192",true);
		
		myObj = new GameObject("a_fighter_20_41_02_0190");
		pos = new Vector3(24.514284f, 3.628346f, 49.714287f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"93","Sprites/objects_093");
		
		
		
		
		myObj = new GameObject("door_048_042");
		pos = new Vector3(57.799999f, 3.628346f, 51.257145f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_320",true);
		CreateDoor(myObj,"textures/doors/doors_01", 53, 0);
		SetRotation(myObj,-90,-180,0);
		
		myObj = new GameObject("a_bridge_08_43_02_0872");
		pos = new Vector3(10.285714f, 2.040945f, 52.114288f);
		myObj.transform.position = pos;
		
		myObj = new GameObject("a_bridge_09_43_02_0871");
		pos = new Vector3(11.485714f, 2.040945f, 52.114288f);
		myObj.transform.position = pos;
		
		myObj = new GameObject("a_book_23_43_02_0866");
		pos = new Vector3(28.114285f, 3.628346f, 52.114288f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_309",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_309",11,309, 1);
		
		myObj = new GameObject("special_tmap_obj_08_44_02_0690");
		pos = new Vector3(10.200000f, 1.814173f, 53.980000f);
		myObj.transform.position = pos;
		CreateTMAP(myObj,"textures/tmap/uw1_150");
		SetRotation(myObj,0,-180,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_366",34,366, 0);
		
		myObj = new GameObject("special_tmap_obj_09_44_02_0873");
		pos = new Vector3(11.400000f, 1.814173f, 53.980000f);
		myObj.transform.position = pos;
		CreateTMAP(myObj,"textures/tmap/uw1_150");
		SetRotation(myObj,0,-180,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_366",34,366, 0);
		
		myObj = new GameObject("a_gazer_24_44_02_0187");
		pos = new Vector3(29.314285f, 3.930709f, 53.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"102","Sprites/objects_102");
		
		myObj = new GameObject("a_shrine_28_44_02_0756");
		pos = new Vector3(34.457142f, 3.855118f, 53.485714f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_343",true);
		
		myObj = new GameObject("some_writing_29_44_02_0861");
		pos = new Vector3(35.657143f, 4.233071f, 53.828568f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_358",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_358",10,358, 0);
		SetRotation(myObj,0,-180,0);
		SetSprite(myObj, "Sprites/tmobj/tmobj_25");
		SetLink(myObj,651);
		
		myObj = new GameObject("a_skull_38_44_02_0726");
		pos = new Vector3(46.799999f, 3.628346f, 53.314285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_194",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_194",23,194, 1);
		
		myObj = new GameObject("a_pile_of_bones_piles_of_bones_38_44_02_0724");
		pos = new Vector3(46.114288f, 3.628346f, 53.314285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_198",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_198",23,198, 1);
		
		myObj = new GameObject("a_map_case_38_44_02_0731");
		pos = new Vector3(46.457142f, 3.628346f, 52.799999f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_136",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_136",19,136, 1);
		////Container contents
		ParentContainer = myObj.AddComponent<Container>();
		myObj.GetComponent<ObjectInteraction>().isContainer = true;
		myObj = new GameObject("a_scroll_38_44_02_0720");
		pos = new Vector3(46.457142f, 3.628346f, 52.799999f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_318",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_318",13,318, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 0);
		////Container contents complete
		
		myObj = new GameObject("a_lantern_38_44_02_0730");
		pos = new Vector3(46.114288f, 3.628346f, 53.314285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_144",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_144",9,144, 1);
		
		myObj = new GameObject("a_wooden_shield_38_44_02_0732");
		pos = new Vector3(46.285713f, 3.628346f, 52.971432f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_060",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_060",2,60, 1);
		
		myObj = new GameObject("chain_boots_pairs_of_chain_boots_38_44_02_0734");
		pos = new Vector3(45.771431f, 3.628346f, 52.971432f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_042",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_042",2,42, 1);
		
		myObj = new GameObject("mail_leggings_pairs_of_mail_leggings_38_44_02_0748");
		pos = new Vector3(46.457142f, 3.628346f, 53.828568f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_036",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_036",2,36, 1);
		
		myObj = new GameObject("a_battle_axe_38_44_02_0823");
		pos = new Vector3(45.942856f, 3.628346f, 53.657143f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_001",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_001",1,1, 1);
		
		myObj = new GameObject("a_switch_38_44_02_0738");
		pos = new Vector3(45.599998f, 4.233071f, 53.314285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_371",true);
		CreateUWActivators(myObj,"ButtonHandler","a_use_trigger_99_99_02_0646",40,0,0,8);
		
		myObj = new GameObject("a_skull_39_44_02_0718");
		pos = new Vector3(47.314285f, 3.628346f, 53.314285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_195",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_195",23,195, 1);
		
		myObj = new GameObject("a_skull_39_44_02_0716");
		pos = new Vector3(48.000000f, 3.628346f, 52.971432f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_195",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_195",23,195, 1);
		
		myObj = new GameObject("a_green_potion_26_45_02_0551");
		pos = new Vector3(31.714285f, 3.628346f, 54.514286f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_188",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_188",14,188, 1);
		
		myObj = new GameObject("a_plant_19_46_02_0706");
		pos = new Vector3(23.142857f, 2.229921f, 55.371429f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("a_plant_21_46_02_1015");
		pos = new Vector3(25.714285f, 2.834646f, 56.057144f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_192",true);
		
		myObj = new GameObject("some_grass_bunches_of_grass_22_46_02_0555");
		pos = new Vector3(26.571428f, 3.137008f, 55.371429f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("special_tmap_obj_26_46_02_0960");
		pos = new Vector3(32.380001f, 3.023622f, 55.799999f);
		myObj.transform.position = pos;
		CreateTMAP(myObj,"textures/tmap/uw1_040");
		SetRotation(myObj,0,-90,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_366",34,366, 0);
		
		myObj = new GameObject("some_grass_bunches_of_grass_30_48_02_0727");
		pos = new Vector3(36.514286f, 1.965354f, 58.114288f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("a_plant_30_48_02_0723");
		pos = new Vector3(36.685715f, 2.116535f, 57.599998f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		
		myObj = new GameObject("a_lurker_19_49_02_0227");
		pos = new Vector3(23.314285f, 1.814173f, 59.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"87","Sprites/objects_087");
		
		
		
		myObj = new GameObject("a_splash_splahes_45_50_02_0979");
		pos = new Vector3(54.685715f, 1.776378f, 60.000000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_454",true);
		
		myObj = new GameObject("a_splash_splahes_46_50_02_0964");
		pos = new Vector3(55.714287f, 1.814173f, 60.000000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_454",true);
		
		myObj = new GameObject("a_lurker_52_50_02_0230");
		pos = new Vector3(62.914288f, 3.325984f, 60.514286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"87","Sprites/objects_087");
		
		myObj = new GameObject("a_helmet_54_50_02_0901");
		pos = new Vector3(65.142853f, 3.628346f, 61.028568f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_046",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_046",2,46, 1);
		
		myObj = new GameObject("a_skull_54_50_02_0930");
		pos = new Vector3(64.971428f, 3.628346f, 60.685715f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_194",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_194",23,194, 1);
		
		myObj = new GameObject("a_pile_of_bones_piles_of_bones_54_50_02_0931");
		pos = new Vector3(65.142853f, 3.628346f, 60.685715f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_198",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_198",23,198, 1);
		
		myObj = new GameObject("a_coin_54_50_02_0939");
		pos = new Vector3(64.971428f, 3.628346f, 60.342857f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_160",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_160",18,160, 1);
		
		myObj = new GameObject("a_lantern_54_50_02_0938");
		pos = new Vector3(65.314285f, 3.590551f, 60.514286f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_144",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_144",9,144, 1);
		
		
		myObj = new GameObject("special_tmap_obj_07_51_02_0920");
		pos = new Vector3(9.000000f, 0.604724f, 61.220001f);
		myObj.transform.position = pos;
		CreateTMAP(myObj,"textures/tmap/uw1_141");
		SetRotation(myObj,0,0,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_366",34,366, 0);
		
		myObj = new GameObject("a_lurker_35_51_02_0229");
		pos = new Vector3(42.514286f, 1.814173f, 61.714287f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"87","Sprites/objects_087");
		
		myObj = new GameObject("a_mist_cloud_36_51_02_0787");
		pos = new Vector3(44.228569f, 2.721260f, 61.371429f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_449",true);
		
		myObj = new GameObject("a_plant_37_51_02_0788");
		pos = new Vector3(45.428570f, 1.814173f, 62.057144f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("a_plant_38_51_02_0874");
		pos = new Vector3(46.114288f, 1.814173f, 61.714287f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("a_mist_cloud_38_51_02_0801");
		pos = new Vector3(46.285713f, 2.116535f, 61.714287f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_449",true);
		
		myObj = new GameObject("a_mist_cloud_39_51_02_0689");
		pos = new Vector3(48.000000f, 2.721260f, 61.885712f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_449",true);
		
		myObj = new GameObject("a_hand_axe_54_51_02_0895");
		pos = new Vector3(65.657143f, 3.628346f, 61.200001f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_000",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_000",1,0, 1);
		
		myObj = new GameObject("a_breastplate_54_51_02_0899");
		pos = new Vector3(65.314285f, 3.628346f, 61.371429f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_034",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_034",2,34, 1);
		
		myObj = new GameObject("a_green_potion_54_51_02_0900");
		pos = new Vector3(65.314285f, 3.628346f, 61.200001f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_188",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_188",14,188, 1);
		
		myObj = new GameObject("a_deep_lurker_03_52_02_0205");
		pos = new Vector3(4.114285f, 0.302362f, 62.914288f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"116","Sprites/objects_116");
		
		myObj = new GameObject("some_grass_bunches_of_grass_04_52_02_0619");
		pos = new Vector3(5.828571f, 0.302362f, 62.571430f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("some_grass_bunches_of_grass_10_52_02_0937");
		pos = new Vector3(12.171429f, 0.302362f, 63.085712f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("a_deep_lurker_11_52_02_0206");
		pos = new Vector3(13.714286f, 0.302362f, 62.914288f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"116","Sprites/objects_116");
		
		myObj = new GameObject("special_tmap_obj_33_52_02_0678");
		pos = new Vector3(40.200001f, 1.814173f, 62.420002f);
		myObj.transform.position = pos;
		CreateTMAP(myObj,"textures/tmap/uw1_144");
		SetRotation(myObj,0,0,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_366",34,366, 0);
		
		myObj = new GameObject("special_tmap_obj_33_52_02_0729");
		pos = new Vector3(40.200001f, 3.023622f, 62.420002f);
		myObj.transform.position = pos;
		CreateTMAP(myObj,"textures/tmap/uw1_144");
		SetRotation(myObj,0,0,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_366",34,366, 0);
		
		myObj = new GameObject("special_tmap_obj_33_52_02_0735");
		pos = new Vector3(40.200001f, 3.628346f, 62.420002f);
		myObj.transform.position = pos;
		CreateTMAP(myObj,"textures/tmap/uw1_144");
		SetRotation(myObj,0,0,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_366",34,366, 0);
		
		
		myObj = new GameObject("a_quiver_49_52_02_0669");
		pos = new Vector3(59.314285f, 1.511811f, 62.400002f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_141",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_141",19,141, 1);
		////Container contents
		ParentContainer = myObj.AddComponent<Container>();
		myObj.GetComponent<ObjectInteraction>().isContainer = true;
		myObj = new GameObject("an_arrow_49_52_02_0812");
		pos = new Vector3(59.314285f, 1.511811f, 62.400002f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_018",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_018",1,18, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 0);
		////Container contents complete
		
		myObj = new GameObject("a_red_potion_49_52_02_0832");
		pos = new Vector3(59.657143f, 1.511811f, 63.085712f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_187",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_187",14,187, 1);
		
		myObj = new GameObject("a_small_shield_49_52_02_0602");
		pos = new Vector3(59.828568f, 1.511811f, 63.428570f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_061",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_061",2,61, 1);
		
		myObj = new GameObject("a_broadsword_49_52_02_0601");
		pos = new Vector3(59.828568f, 1.511811f, 62.571430f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_006",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_006",1,6, 1);
		
		myObj = new GameObject("a_pouch_pouches_49_52_02_0675");
		pos = new Vector3(59.314285f, 1.511811f, 62.914288f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_134",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_134",19,134, 1);
		////Container contents
		ParentContainer = myObj.AddComponent<Container>();
		myObj.GetComponent<ObjectInteraction>().isContainer = true;
		myObj = new GameObject("a_pick_up_trigger_49_52_02_0600");
		pos = new Vector3(59.314285f, 1.511811f, 62.914288f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_417",true);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 0);
		myObj = new GameObject("a_red_potion_49_52_02_0665");
		pos = new Vector3(59.314285f, 1.511811f, 62.914288f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_187",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_187",14,187, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 1);
		myObj = new GameObject("a_Ylem_stone_49_52_02_0658");
		pos = new Vector3(59.314285f, 1.511811f, 62.914288f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_255",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_255",6,255, 1);
		SetObjectAsRuneStone(myObj);
		
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 2);
		myObj = new GameObject("a_Grav_stone_49_52_02_0925");
		pos = new Vector3(59.314285f, 1.511811f, 62.914288f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_238",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_238",6,238, 1);
		SetObjectAsRuneStone(myObj);
		
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 3);
		myObj = new GameObject("a_resilient_sphere_some_resilient_spheres_49_52_02_0544");
		pos = new Vector3(59.314285f, 1.511811f, 62.914288f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_286",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_286",16,286, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 4);
		////Container contents complete
		
		myObj = new GameObject("a_mist_cloud_06_53_02_0617");
		pos = new Vector3(8.057143f, 0.529134f, 64.457146f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_449",true);
		
		myObj = new GameObject("some_grass_bunches_of_grass_06_53_02_0613");
		pos = new Vector3(8.057143f, 0.302362f, 64.285713f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("some_grass_bunches_of_grass_09_53_02_0924");
		pos = new Vector3(11.314286f, 0.302362f, 64.114288f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		
		myObj = new GameObject("door_045_053");
		pos = new Vector3(54.171432f, 2.116535f, 63.799999f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_320",true);
		CreateDoor(myObj,"textures/doors/doors_01", 53, 0);
		SetRotation(myObj,-90,90,0);
		
		
		
		myObj = new GameObject("a_skeleton_49_53_02_0195");
		pos = new Vector3(59.314285f, 1.511811f, 64.114288f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"74","Sprites/objects_074");
		
		
		myObj = new GameObject("special_tmap_obj_56_53_02_0534");
		pos = new Vector3(68.380005f, 3.628346f, 64.199997f);
		myObj.transform.position = pos;
		CreateTMAP(myObj,"textures/tmap/uw1_198");
		SetRotation(myObj,0,-90,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_366",34,366, 0);
		
		myObj = new GameObject("special_tmap_obj_56_53_02_0926");
		pos = new Vector3(68.380005f, 3.325984f, 64.199997f);
		myObj.transform.position = pos;
		CreateTMAP(myObj,"textures/tmap/uw1_198");
		SetRotation(myObj,0,-90,0);
		CreateUWActivators(myObj,"ButtonHandler","a_look_trigger_99_99_02_0537",0,11,0,8);
		
		myObj = new GameObject("special_tmap_obj_57_53_02_0541");
		pos = new Vector3(68.419998f, 3.628346f, 64.199997f);
		myObj.transform.position = pos;
		CreateTMAP(myObj,"textures/tmap/uw1_198");
		SetRotation(myObj,0,90,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_366",34,366, 0);
		
		
		myObj = new GameObject("a_wand_58_53_02_0540");
		pos = new Vector3(70.457146f, 3.325984f, 64.114288f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_153",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_153",12,153, 1);
		
		myObj = new GameObject("a_skull_58_53_02_0532");
		pos = new Vector3(70.628571f, 3.325984f, 63.771431f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_195",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_195",23,195, 1);
		
		myObj = new GameObject("a_leather_cap_58_53_02_0542");
		pos = new Vector3(70.285713f, 3.325984f, 64.285713f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_044",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_044",2,44, 1);
		
		myObj = new GameObject("a_leather_vest_58_53_02_0552");
		pos = new Vector3(70.457146f, 3.325984f, 64.114288f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_032",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_032",2,32, 1);
		
		myObj = new GameObject("a_gold_coffer_02_54_02_0897");
		pos = new Vector3(3.428571f, 0.907087f, 65.828568f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_138",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_138",19,138, 1);
		////Container contents
		ParentContainer = myObj.AddComponent<Container>();
		myObj.GetComponent<ObjectInteraction>().isContainer = true;
		myObj = new GameObject("a_key_010_2");
		pos = new Vector3(3.428571f, 0.907087f, 65.828568f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_263",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_263",5,263, 1);
		CreateKey(myObj, 10);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 0);
		////Container contents complete
		
		myObj = new GameObject("some_grass_bunches_of_grass_05_54_02_0548");
		pos = new Vector3(6.342857f, 0.302362f, 64.971428f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("a_plant_08_54_02_0923");
		pos = new Vector3(10.457142f, 0.302362f, 64.971428f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_192",true);
		
		myObj = new GameObject("a_mist_cloud_09_54_02_0903");
		pos = new Vector3(10.971428f, 0.491339f, 65.485710f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_449",true);
		
		myObj = new GameObject("the_Key_of_Courage_12_54_02_0881");
		pos = new Vector3(14.400000f, 0.907087f, 66.000000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_227",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_227",69,227, 1);
		
		
		myObj = new GameObject("door_048_054");
		pos = new Vector3(57.799999f, 1.511811f, 66.000000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_327",true);
		CreateDoor(myObj,"textures/doors/doors_-12851", 53, 0);
		SetRotation(myObj,-90,-180,0);
		
		myObj = new GameObject("a_shadow_beast_02_55_02_0209");
		pos = new Vector3(2.914286f, 0.604724f, 66.514290f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"117","Sprites/objects_117");
		
		myObj = new GameObject("door_004_055");
		pos = new Vector3(5.314286f, 0.604724f, 66.199997f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_324",true);
		CreateDoor(myObj,"textures/doors/doors_12", 0, 1);
		SetRotation(myObj,-90,90,0);
		
		myObj = new GameObject("a_reaper_07_55_02_0211");
		pos = new Vector3(8.914286f, 0.302362f, 66.514290f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"118","Sprites/objects_118");
		
		myObj = new GameObject("door_010_055");
		pos = new Vector3(12.171429f, 0.604724f, 66.199997f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_325",true);
		CreateDoor(myObj,"textures/doors/doors_03", 10, 1);
		SetRotation(myObj,-90,90,0);
		
		myObj = new GameObject("a_metal_golem_12_55_02_0210");
		pos = new Vector3(14.914286f, 0.604724f, 66.514290f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"121","Sprites/objects_121");
		
		
		myObj = new GameObject("a_rotworm_47_55_02_0197");
		pos = new Vector3(56.914288f, 1.511811f, 66.514290f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"64","Sprites/objects_064");
		
		myObj = new GameObject("a_bone_48_55_02_0676");
		pos = new Vector3(58.457142f, 1.511811f, 67.028572f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_196",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_196",23,196, 1);
		
		myObj = new GameObject("an_axe_48_55_02_0679");
		pos = new Vector3(58.799999f, 1.511811f, 67.199997f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_002",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_002",1,2, 1);
		
		myObj = new GameObject("a_lever_48_55_02_0680");
		pos = new Vector3(58.799999f, 2.116535f, 66.857147f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_373",true);
		
		myObj = new GameObject("a_blood_stain_48_55_02_0814");
		pos = new Vector3(58.114288f, 1.511811f, 67.028572f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_222",true);
		
		myObj = new GameObject("special_tmap_obj_48_55_02_0794");
		pos = new Vector3(58.200001f, 1.511811f, 66.019997f);
		myObj.transform.position = pos;
		CreateTMAP(myObj,"textures/tmap/uw1_144");
		SetRotation(myObj,0,0,0);
		CreateUWActivators(myObj,"ButtonHandler","a_look_trigger_99_99_02_0661",40,0,0,8);
		
		
		myObj = new GameObject("a_shadow_beast_02_56_02_0204");
		pos = new Vector3(2.914286f, 0.604724f, 67.714287f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"117","Sprites/objects_117");
		
		myObj = new GameObject("a_dire_ghost_03_56_02_0202");
		pos = new Vector3(4.114285f, 0.642520f, 67.714287f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"113","Sprites/objects_113");
		
		myObj = new GameObject("some_grass_bunches_of_grass_08_56_02_0906");
		pos = new Vector3(10.457142f, 0.302362f, 68.228569f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("a_acid_slug_51_56_02_0198");
		pos = new Vector3(61.714287f, 3.628346f, 67.885712f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"69","Sprites/objects_069");
		
		myObj = new GameObject("a_plant_05_57_02_0553");
		pos = new Vector3(7.028571f, 0.302362f, 68.571434f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_192",true);
		
		myObj = new GameObject("a_mist_cloud_06_57_02_0546");
		pos = new Vector3(7.714286f, 0.604724f, 68.914284f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_449",true);
		
		myObj = new GameObject("a_mist_cloud_09_57_02_0556");
		pos = new Vector3(11.314286f, 0.491339f, 69.428566f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_449",true);
		
		myObj = new GameObject("a_mongbat_29_57_02_0236");
		pos = new Vector3(35.314285f, 2.721260f, 68.914284f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"81","Sprites/objects_081");
		
		myObj = new GameObject("door_049_057");
		pos = new Vector3(59.828568f, 3.628346f, 68.599998f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_321",true);
		CreateDoor(myObj,"textures/doors/doors_05", 53, 0);
		SetRotation(myObj,-90,90,0);
		
		myObj = new GameObject("some_grass_bunches_of_grass_10_58_02_0554");
		pos = new Vector3(12.171429f, 0.302362f, 70.114288f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("some_grass_bunches_of_grass_03_59_02_0618");
		pos = new Vector3(4.457143f, 0.302362f, 71.828568f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("a_deep_lurker_03_59_02_0208");
		pos = new Vector3(4.114285f, 0.302362f, 71.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"116","Sprites/objects_116");
		
		myObj = new GameObject("some_grass_bunches_of_grass_09_59_02_0614");
		pos = new Vector3(11.314286f, 0.302362f, 71.314285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_193",true);
		
		myObj = new GameObject("a_deep_lurker_11_59_02_0207");
		pos = new Vector3(13.714286f, 0.302362f, 71.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"116","Sprites/objects_116");
		
		
		
		myObj = new GameObject("special_tmap_obj_07_60_02_0922");
		pos = new Vector3(9.000000f, 0.604724f, 73.180000f);
		myObj.transform.position = pos;
		CreateTMAP(myObj,"textures/tmap/uw1_141");
		SetRotation(myObj,0,-180,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_366",34,366, 0);
		
		myObj = new GameObject("special_tmap_obj_38_60_02_0627");
		pos = new Vector3(46.200001f, 3.628346f, 72.019997f);
		myObj.transform.position = pos;
		CreateTMAP(myObj,"textures/tmap/uw1_161");
		SetRotation(myObj,0,0,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_366",34,366, 0);
		
		
		myObj = new GameObject("special_tmap_obj_42_60_02_0626");
		pos = new Vector3(51.000000f, 3.628346f, 72.019997f);
		myObj.transform.position = pos;
		CreateTMAP(myObj,"textures/tmap/uw1_140");
		SetRotation(myObj,0,0,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_366",34,366, 0);
		
		
		myObj = new GameObject("a_bloodworm_53_61_02_0199");
		pos = new Vector3(64.114288f, 3.628346f, 73.714287f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"82","Sprites/objects_082");
		
		myObj = new GameObject("a_plant_53_61_02_0851");
		pos = new Vector3(64.457146f, 3.628346f, 73.885712f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("a_skull_53_61_02_0644");
		pos = new Vector3(64.800003f, 3.628346f, 74.057144f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_194",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_194",23,194, 1);
		
		myObj = new GameObject("a_torch_torches_53_61_02_0927");
		pos = new Vector3(64.628571f, 3.628346f, 74.228569f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_145",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_145",9,145, 1);
		
		myObj = new GameObject("chain_gauntlets_pairs_of_chain_gauntlets_54_61_02_0844");
		pos = new Vector3(65.142853f, 3.325984f, 74.400002f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_039",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_039",2,39, 1);
		
		myObj = new GameObject("a_mace_54_61_02_0841");
		pos = new Vector3(66.000000f, 3.061417f, 74.057144f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_009",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_009",1,9, 1);
		
		myObj = new GameObject("a_plant_54_61_02_0848");
		pos = new Vector3(65.314285f, 3.325984f, 74.228569f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_207",true);
		
		myObj = new GameObject("a_sack_54_61_02_0928");
		pos = new Vector3(65.828568f, 3.250394f, 74.400002f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_128",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_128",19,128, 1);
		////Container contents
		ParentContainer = myObj.AddComponent<Container>();
		myObj.GetComponent<ObjectInteraction>().isContainer = true;
		myObj = new GameObject("an_ear_of_corn_ears_of_corn_54_61_02_0929");
		pos = new Vector3(65.828568f, 3.250394f, 74.400002f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_180",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_180",24,180, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 0);
		myObj = new GameObject("a_loaf_of_bread_loaves_of_bread_54_61_02_0645");
		pos = new Vector3(65.828568f, 3.250394f, 74.400002f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_181",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_181",24,181, 1);
		myObj.transform.position = invMarker.transform.position;
		myObj.transform.parent = invMarker.transform;
		AddObjectToContainer(myObj, ParentContainer, 1);
		////Container contents complete
		
		myObj = new GameObject("a_leather_vest_54_61_02_0653");
		pos = new Vector3(65.485710f, 3.325984f, 74.228569f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_032",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_032",2,32, 1);
		
		myObj = new GameObject("a_lurker_55_61_02_0200");
		pos = new Vector3(66.514290f, 3.325984f, 73.714287f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"87","Sprites/objects_087");
		
		
		myObj = new GameObject("a_scroll_34_62_02_0547");
		pos = new Vector3(41.142857f, 3.628346f, 75.257141f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_313",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_313",13,313, 1);
		
		
		
		myObj = new GameObject("a_set_variable_trap_99_99_02_0004");
		pos = new Vector3(120.000000f, 1.398425f, 119.142860f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_397",false);
		Create_a_set_variable_trap(myObj);
		
		myObj = new GameObject("a_check_variable_trap_99_99_02_0007");
		pos = new Vector3(118.800003f, 2.759055f, 119.142860f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_398",false);
		Create_a_check_variable_trap(myObj);
		
		myObj = new GameObject("a_door_trap_99_99_02_0031");
		pos = new Vector3(119.485710f, 2.532283f, 118.800003f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_392",false);
		Create_a_door_trap(myObj,59);
		
		myObj = new GameObject("a_delete_object_trap_99_99_02_0032");
		pos = new Vector3(119.657135f, 0.075591f, 120.000000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_395",false);
		Create_a_delete_object_trap(myObj);
		
		myObj = new GameObject("a_set_variable_trap_99_99_02_0036");
		pos = new Vector3(119.657135f, 0.226772f, 118.971428f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_397",false);
		Create_a_set_variable_trap(myObj);
		
		myObj = new GameObject("a_arrow_trap_99_99_02_0061");
		pos = new Vector3(118.800003f, 4.497638f, 118.971428f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_386",false);
		Create_a_arrow_trap(myObj);
		
		myObj = new GameObject("a_arrow_trap_99_99_02_0076");
		pos = new Vector3(118.800003f, 2.381102f, 119.314285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_386",false);
		Create_a_arrow_trap(myObj);
		
		myObj = new GameObject("a_do_trap_99_99_02_0261");
		pos = new Vector3(119.657135f, 3.325984f, 119.657135f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_387",false);
		Create_trap_base(myObj);
		
		myObj = new GameObject("a_spelltrap_99_99_02_0283");
		pos = new Vector3(119.657135f, 0.907087f, 118.800003f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_390",false);
		Create_a_spelltrap(myObj);
		
		myObj = new GameObject("a_damage_trap_99_99_02_0294");
		pos = new Vector3(119.828575f, 0.226772f, 119.657135f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_384",false);
		Create_a_damage_trap(myObj);
		
		myObj = new GameObject("a_spelltrap_99_99_02_0329");
		pos = new Vector3(120.000000f, 0.226772f, 119.485710f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_390",false);
		Create_a_spelltrap(myObj);
		
		myObj = new GameObject("a_create_object_trap_99_99_02_0342");
		pos = new Vector3(118.971428f, 2.759055f, 119.485710f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_391",false);
		Create_a_create_object_trap(myObj);
		
		myObj = new GameObject("a_delete_object_trap_99_99_02_0347");
		pos = new Vector3(119.485710f, 3.174803f, 118.971428f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_395",false);
		Create_a_delete_object_trap(myObj);
		
		myObj = new GameObject("a_step_on_trigger_99_99_02_0353");
		pos = new Vector3(118.800003f, 3.590551f, 120.000000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_420",false);
		CreateTrigger(myObj,6,11,"some_writing_12_20_02_0990");
		
		myObj = new GameObject("a_delete_object_trap_99_99_02_0380");
		pos = new Vector3(118.971428f, 0.415748f, 120.000000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_395",false);
		Create_a_delete_object_trap(myObj);
		
		myObj = new GameObject("a_teleport_trap_99_99_02_0381");
		pos = new Vector3(119.485710f, 2.721260f, 119.657135f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_385",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_385",38,385, 0);
		Create_a_teleport_trap(myObj,(float)73.800000,(float)52.200000,(float)4.500000,true);
		
		myObj = new GameObject("an_inventory_trap_99_99_02_0403");
		pos = new Vector3(118.800003f, 2.040945f, 118.971428f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_396",false);
		Create_an_inventory_trap(myObj);
		
		myObj = new GameObject("a_delete_object_trap_99_99_02_0406");
		pos = new Vector3(119.142860f, 0.151181f, 118.800003f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_395",false);
		Create_a_delete_object_trap(myObj);
		
		myObj = new GameObject("an_inventory_trap_99_99_02_0421");
		pos = new Vector3(120.000000f, 0.529134f, 120.000000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_396",false);
		Create_an_inventory_trap(myObj);
		
		myObj = new GameObject("a_tell_trap_99_99_02_0459");
		pos = new Vector3(120.000000f, 0.000000f, 118.800003f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_394",false);
		Create_a_tell_trap(myObj);
		
		myObj = new GameObject("a_text_string_trap_99_99_02_0469");
		pos = new Vector3(118.800003f, 4.384252f, 119.485710f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_400",false);
		Create_a_text_string_trap(myObj,9,144);
		
		myObj = new GameObject("a_teleport_trap_99_99_02_0497");
		pos = new Vector3(118.800003f, 3.137008f, 118.971428f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_385",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_385",38,385, 0);
		Create_a_teleport_trap(myObj,(float)59.400000,(float)23.400000,(float)3.300000,true);
		
		myObj = new GameObject("a_delete_object_trap_99_99_02_0504");
		pos = new Vector3(119.485710f, 0.302362f, 119.485710f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_395",false);
		Create_a_delete_object_trap(myObj);
		
		myObj = new GameObject("a_look_trigger_99_99_02_0537");
		pos = new Vector3(119.314285f, 0.377953f, 119.314285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_419",false);
		CreateTrigger(myObj,57,53,"a_change_terrain_trap_57_53_02_0539");
		
		myObj = new GameObject("a_move_trigger_56_53_02_0538");
		pos = new Vector3(67.800003f, 3.325984f, 64.199997f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_416",false);
		CreateTrigger(myObj,57,53,"a_change_terrain_trap_57_53_02_0539");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		
		myObj = new GameObject("a_change_terrain_trap_57_53_02_0539");
		pos = new Vector3(68.400002f, 3.325984f, 63.599998f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_389",false);
		Create_a_change_terrain_trap(myObj,57,53,0,0);
		
		myObj = new GameObject("a_move_trigger_51_61_02_0545");
		pos = new Vector3(61.799999f, 3.628346f, 73.800003f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_416",false);
		CreateTrigger(myObj,39,53,"a_text_string_trap_39_53_02_0782");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		
		myObj = new GameObject("a_move_trigger_99_99_02_0549");
		pos = new Vector3(119.400002f, 3.325984f, 119.400002f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_416",false);
		CreateTrigger(myObj,46,7,"a_change_terrain_trap_46_07_02_0550");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		
		myObj = new GameObject("a_change_terrain_trap_46_07_02_0550");
		pos = new Vector3(55.200001f, 1.209449f, 8.400000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_389",false);
		Create_a_change_terrain_trap(myObj,46,7,0,0);
		
		myObj = new GameObject("a_set_variable_trap_27_21_02_0577");
		pos = new Vector3(32.400002f, 0.000000f, 26.400000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_397",false);
		Create_a_set_variable_trap(myObj);
		
		myObj = new GameObject("an_open_trigger_99_99_02_0582");
		pos = new Vector3(119.314285f, 3.628346f, 119.314285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_421",false);
		CreateTrigger(myObj,27,21,"a_set_variable_trap_27_21_02_0577");
		
		myObj = new GameObject("a_pit_trap_06_04_02_0583");
		pos = new Vector3(7.200000f, 4.535433f, 4.800000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_388",false);
		Create_a_pit_trap(myObj);
		
		myObj = new GameObject("a_text_string_trap_99_99_02_0584");
		pos = new Vector3(118.800003f, 3.325984f, 118.800003f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_400",false);
		Create_a_text_string_trap(myObj,9,131,"a_move_trigger_99_99_02_0968");
		
		myObj = new GameObject("a_delete_object_trap_99_99_02_0585");
		pos = new Vector3(118.800003f, 0.000000f, 118.800003f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_395",false);
		Create_a_delete_object_trap(myObj);
		
		myObj = new GameObject("a_look_trigger_99_99_02_0586");
		pos = new Vector3(119.314285f, 0.113386f, 119.314285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_419",false);
		CreateTrigger(myObj,52,13,"a_change_terrain_trap_52_13_02_0587");
		
		myObj = new GameObject("a_change_terrain_trap_52_13_02_0587");
		pos = new Vector3(62.400002f, 3.628346f, 15.600000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_389",false);
		Create_a_change_terrain_trap(myObj,52,13,0,0,"a_text_string_trap_99_99_02_0620");
		
		myObj = new GameObject("a_pick_up_trigger_49_52_02_0600");
		pos = new Vector3(59.314285f, 1.511811f, 62.914288f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_417",false);
		CreateTrigger(myObj,44,55,"a_create_object_trap_44_55_02_0657");
		
		myObj = new GameObject("a_move_trigger_25_10_02_0615");
		pos = new Vector3(30.600000f, 2.418898f, 12.600000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_416",false);
		CreateTrigger(myObj,39,53,"a_text_string_trap_39_53_02_0782");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		
		myObj = new GameObject("a_text_string_trap_99_99_02_0620");
		pos = new Vector3(118.800003f, 3.628346f, 118.800003f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_400",false);
		Create_a_text_string_trap(myObj,9,130,"a_delete_object_trap_99_99_02_0585");
		
		myObj = new GameObject("a_move_trigger_42_60_02_0625");
		pos = new Vector3(51.000000f, 3.628346f, 72.599998f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_416",false);
		CreateTrigger(myObj,42,59,"a_teleport_trap_42_59_02_0639");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		
		myObj = new GameObject("a_create_object_trap_03_09_02_0630");
		pos = new Vector3(3.600000f, 3.628346f, 10.800000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_391",false);
		Create_a_create_object_trap(myObj);
		
		myObj = new GameObject("a_move_trigger_03_20_02_0636");
		pos = new Vector3(4.200000f, 2.721260f, 24.600000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_416",false);
		CreateTrigger(myObj,39,53,"a_text_string_trap_39_53_02_0782");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		
		myObj = new GameObject("a_teleport_trap_42_59_02_0639");
		pos = new Vector3(50.400002f, 0.075591f, 70.800003f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_385",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_385",38,385, 0);
		Create_a_teleport_trap(myObj,(float)51.000000,(float)71.400000,(float)3.600000,true);
		
		myObj = new GameObject("a_use_trigger_99_99_02_0646");
		pos = new Vector3(119.314285f, 3.628346f, 119.314285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_418",false);
		CreateTrigger(myObj,42,42,"a_create_object_trap_42_42_02_0803");
		
		myObj = new GameObject("a_create_object_trap_44_55_02_0657");
		pos = new Vector3(52.799999f, 1.511811f, 66.000000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_391",false);
		Create_a_create_object_trap(myObj);
		
		myObj = new GameObject("a_look_trigger_99_99_02_0661");
		pos = new Vector3(119.314285f, 0.377953f, 119.314285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_419",false);
		CreateTrigger(myObj,48,54,"a_change_terrain_trap_48_54_02_0793");
		
		myObj = new GameObject("a_create_object_trap_35_06_02_0702");
		pos = new Vector3(42.000000f, 3.628346f, 7.200000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_391",false);
		Create_a_create_object_trap(myObj);
		
		myObj = new GameObject("a_pick_up_trigger_99_99_02_0709");
		pos = new Vector3(119.314285f, 3.628346f, 119.314285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_417",false);
		CreateTrigger(myObj,35,6,"a_create_object_trap_35_06_02_0702");
		
		myObj = new GameObject("a_pick_up_trigger_99_99_02_0711");
		pos = new Vector3(119.314285f, 3.628346f, 119.314285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_417",false);
		CreateTrigger(myObj,35,6,"a_create_object_trap_35_06_02_0702");
		
		myObj = new GameObject("a_text_string_trap_99_99_02_0745");
		pos = new Vector3(118.800003f, 4.535433f, 118.800003f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_400",false);
		Create_a_text_string_trap(myObj,9,129);
		
		myObj = new GameObject("a_text_string_trap_39_53_02_0782");
		pos = new Vector3(46.799999f, 2.116535f, 63.599998f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_400",false);
		Create_a_text_string_trap(myObj,9,128);
		
		myObj = new GameObject("a_look_trigger_99_99_02_0786");
		pos = new Vector3(119.314285f, 0.000000f, 119.314285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_419",false);
		CreateTrigger(myObj,49,55,"a_delete_object_trap_49_55_02_0797");
		
		myObj = new GameObject("a_change_terrain_trap_48_54_02_0793");
		pos = new Vector3(57.599998f, 1.511811f, 64.800003f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_389",false);
		Create_a_change_terrain_trap(myObj,48,54,0,0,"a_look_trigger_99_99_02_0786");
		
		myObj = new GameObject("a_delete_object_trap_49_55_02_0797");
		pos = new Vector3(58.799999f, 0.000000f, 66.000000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_395",false);
		Create_a_delete_object_trap(myObj);
		
		myObj = new GameObject("a_create_object_trap_42_42_02_0803");
		pos = new Vector3(50.400002f, 3.628346f, 50.400002f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_391",false);
		Create_a_create_object_trap(myObj);
		
		myObj = new GameObject("a_pick_up_trigger_99_99_02_0821");
		pos = new Vector3(119.314285f, 3.628346f, 119.314285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_417",false);
		CreateTrigger(myObj,35,6,"a_create_object_trap_35_06_02_0702");
		
		myObj = new GameObject("a_move_trigger_01_07_02_0827");
		pos = new Vector3(1.800000f, 3.628346f, 9.000000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_416",false);
		CreateTrigger(myObj,1,10,"a_damage_trap_01_10_02_0828");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		
		myObj = new GameObject("a_damage_trap_01_10_02_0828");
		pos = new Vector3(1.200000f, 4.535433f, 12.000000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_384",false);
		Create_a_damage_trap(myObj,"a_text_string_trap_99_99_02_0745");
		
		myObj = new GameObject("a_move_trigger_01_09_02_0829");
		pos = new Vector3(1.800000f, 3.628346f, 11.400000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_416",false);
		CreateTrigger(myObj,1,10,"a_damage_trap_01_10_02_0828");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		
		myObj = new GameObject("a_move_trigger_32_14_02_0833");
		pos = new Vector3(39.000000f, 3.628346f, 17.400000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_416",false);
		CreateTrigger(myObj,39,53,"a_text_string_trap_39_53_02_0782");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		
		myObj = new GameObject("a_move_trigger_38_52_02_0839");
		pos = new Vector3(46.200001f, 2.116535f, 63.000000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_416",false);
		CreateTrigger(myObj,39,53,"a_text_string_trap_39_53_02_0782");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		
		myObj = new GameObject("a_move_trigger_99_99_02_0856");
		pos = new Vector3(119.400002f, 4.535433f, 119.400002f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_416",false);
		CreateTrigger(myObj,6,4,"a_check_variable_trap_06_04_02_0858");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		
		myObj = new GameObject("a_move_trigger_99_99_02_0857");
		pos = new Vector3(119.400002f, 3.628346f, 119.400002f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_416",false);
		CreateTrigger(myObj,1,8,"a_create_object_trap_01_08_02_0994");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		
		myObj = new GameObject("a_check_variable_trap_06_04_02_0858");
		pos = new Vector3(7.371429f, 0.604724f, 5.314286f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_398",false);
		Create_a_check_variable_trap(myObj);
		
		myObj = new GameObject("a_move_trigger_99_99_02_0859");
		pos = new Vector3(119.400002f, 4.535433f, 119.400002f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_416",false);
		CreateTrigger(myObj,6,8,"a_door_trap_99_99_02_1001");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		
		myObj = new GameObject("a_move_trigger_03_02_02_0886");
		pos = new Vector3(4.200000f, 3.628346f, 3.000000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_416",false);
		CreateTrigger(myObj,6,8,"a_door_trap_99_99_02_0890");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		
		myObj = new GameObject("a_move_trigger_07_06_02_0888");
		pos = new Vector3(9.000000f, 3.628346f, 7.800000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_416",false);
		CreateTrigger(myObj,6,8,"a_door_trap_99_99_02_0890");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		
		myObj = new GameObject("a_move_trigger_03_16_02_0889");
		pos = new Vector3(4.200000f, 3.628346f, 19.799999f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_416",false);
		CreateTrigger(myObj,6,8,"a_door_trap_99_99_02_1001");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		
		myObj = new GameObject("a_door_trap_99_99_02_0890");
		pos = new Vector3(118.800003f, 3.628346f, 118.800003f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_392",false);
		Create_a_door_trap(myObj,2);
		
		myObj = new GameObject("a_use_trigger_99_99_02_0891");
		pos = new Vector3(119.314285f, 3.628346f, 119.314285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_418",false);
		CreateTrigger(myObj,6,8,"a_door_trap_99_99_02_1001");
		
		myObj = new GameObject("a_move_trigger_07_60_02_0912");
		pos = new Vector3(9.000000f, 0.604724f, 72.599998f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_416",false);
		CreateTrigger(myObj,7,62,"a_teleport_trap_07_62_02_0916");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		
		myObj = new GameObject("a_move_trigger_07_51_02_0913");
		pos = new Vector3(9.000000f, 0.604724f, 61.799999f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_416",false);
		CreateTrigger(myObj,7,50,"a_teleport_trap_07_50_02_0917");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		
		myObj = new GameObject("a_create_object_trap_58_12_02_0915");
		pos = new Vector3(69.599998f, 3.628346f, 14.400000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_391",false);
		Create_a_create_object_trap(myObj);
		
		myObj = new GameObject("a_teleport_trap_07_62_02_0916");
		pos = new Vector3(8.400000f, 0.151181f, 74.400002f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_385",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_385",38,385, 0);
		Create_a_teleport_trap(myObj,(float)9.000000,(float)73.800000,(float)4.500000,true);
		
		myObj = new GameObject("a_teleport_trap_07_50_02_0917");
		pos = new Vector3(8.400000f, 0.151181f, 60.000000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_385",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_385",38,385, 0);
		Create_a_teleport_trap(myObj,(float)9.000000,(float)60.600000,(float)4.500000,true);
		
		myObj = new GameObject("a_create_object_trap_32_03_02_0919");
		pos = new Vector3(38.400002f, 3.628346f, 3.600000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_391",false);
		Create_a_create_object_trap(myObj);
		
		myObj = new GameObject("a_create_object_trap_35_62_02_0921");
		pos = new Vector3(42.000000f, 3.628346f, 74.400002f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_391",false);
		Create_a_create_object_trap(myObj);
		
		myObj = new GameObject("a_create_object_trap_44_38_02_0944");
		pos = new Vector3(52.799999f, 3.628346f, 45.599998f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_391",false);
		Create_a_create_object_trap(myObj);
		
		myObj = new GameObject("a_create_object_trap_45_62_02_0951");
		pos = new Vector3(54.000000f, 3.628346f, 74.400002f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_391",false);
		Create_a_create_object_trap(myObj);
		
		myObj = new GameObject("a_move_trigger_99_99_02_0968");
		pos = new Vector3(119.400002f, 3.325984f, 119.400002f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_416",false);
		CreateTrigger(myObj,44,8,"a_change_terrain_trap_44_08_02_0969");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		
		myObj = new GameObject("a_change_terrain_trap_44_08_02_0969");
		pos = new Vector3(53.657143f, 1.209449f, 10.114285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_389",false);
		Create_a_change_terrain_trap(myObj,44,8,5,3,"a_move_trigger_99_99_02_0549");
		
		myObj = new GameObject("a_change_terrain_trap_44_12_02_0970");
		pos = new Vector3(53.657143f, 3.628346f, 14.400000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_389",false);
		Create_a_change_terrain_trap(myObj,44,12,5,0,"a_text_string_trap_99_99_02_0584");
		
		myObj = new GameObject("a_use_trigger_99_99_02_0971");
		pos = new Vector3(119.314285f, 3.628346f, 120.000000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_418",false);
		CreateTrigger(myObj,44,12,"a_change_terrain_trap_44_12_02_0970");
		
		myObj = new GameObject("a_move_trigger_46_53_02_0973");
		pos = new Vector3(55.799999f, 2.116535f, 64.199997f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_416",false);
		CreateTrigger(myObj,47,53,"a_teleport_trap_47_53_02_0974");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		
		myObj = new GameObject("a_teleport_trap_47_53_02_0974");
		pos = new Vector3(56.400002f, 0.000000f, 63.599998f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_385",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_385",38,385, 0);
		Create_a_teleport_trap(myObj,(float)53.400000,(float)58.200000,(float)2.100000,false);
		
		myObj = new GameObject("a_move_trigger_45_48_02_0975");
		pos = new Vector3(54.599998f, 2.116535f, 58.200001f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_416",false);
		CreateTrigger(myObj,38,50,"a_teleport_trap_38_50_02_0976");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		
		myObj = new GameObject("a_teleport_trap_38_50_02_0976");
		pos = new Vector3(45.599998f, 0.000000f, 60.000000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_385",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_385",38,385, 0);
		Create_a_teleport_trap(myObj,(float)31.800000,(float)66.600000,(float)2.100000,false);
		
		myObj = new GameObject("a_move_trigger_24_36_02_0981");
		pos = new Vector3(29.400000f, 3.628346f, 43.799999f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_416",false);
		CreateTrigger(myObj,23,36,"a_teleport_trap_23_36_02_0982");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		
		myObj = new GameObject("a_teleport_trap_23_36_02_0982");
		pos = new Vector3(27.600000f, 0.151181f, 43.200001f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_385",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_385",38,385, 0);
		Create_a_teleport_trap(myObj,(float)28.200000,(float)43.800000,(float)1.800000,true);
		
		myObj = new GameObject("a_set_variable_trap_06_07_02_0992");
		pos = new Vector3(7.200000f, 0.604724f, 8.400000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_397",false);
		Create_a_set_variable_trap(myObj);
		
		myObj = new GameObject("a_use_trigger_99_99_02_0993");
		pos = new Vector3(119.314285f, 3.628346f, 119.314285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_418",false);
		CreateTrigger(myObj,1,8,"a_create_object_trap_01_08_02_0994");
		
		myObj = new GameObject("a_create_object_trap_01_08_02_0994");
		pos = new Vector3(1.200000f, 3.628346f, 9.600000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_391",false);
		Create_a_create_object_trap(myObj);
		
		myObj = new GameObject("a_use_trigger_99_99_02_0995");
		pos = new Vector3(119.314285f, 4.535433f, 119.314285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_418",false);
		CreateTrigger(myObj,6,4,"a_pit_trap_06_04_02_0583");
		
		myObj = new GameObject("a_use_trigger_99_99_02_0996");
		pos = new Vector3(119.314285f, 3.628346f, 119.314285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_418",false);
		CreateTrigger(myObj,6,6,"a_set_variable_trap_06_06_02_1016");
		
		myObj = new GameObject("a_use_trigger_99_99_02_0998");
		pos = new Vector3(119.314285f, 4.535433f, 119.314285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_418",false);
		CreateTrigger(myObj,6,7,"a_set_variable_trap_06_07_02_0992");
		
		myObj = new GameObject("a_use_trigger_99_99_02_0999");
		pos = new Vector3(119.314285f, 4.535433f, 119.314285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_418",false);
		CreateTrigger(myObj,5,5,"a_check_variable_trap_05_05_02_1000");
		
		myObj = new GameObject("a_check_variable_trap_05_05_02_1000");
		pos = new Vector3(6.171429f, 0.604724f, 6.000000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_398",false);
		Create_a_check_variable_trap(myObj);
		
		myObj = new GameObject("a_door_trap_99_99_02_1001");
		pos = new Vector3(118.800003f, 3.628346f, 118.800003f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_392",false);
		Create_a_door_trap(myObj,3);
		
		myObj = new GameObject("a_move_trigger_42_02_02_1003");
		pos = new Vector3(51.000000f, 3.628346f, 3.000000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_416",false);
		CreateTrigger(myObj,42,3,"a_teleport_trap_42_03_02_1004");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		
		myObj = new GameObject("a_teleport_trap_42_03_02_1004");
		pos = new Vector3(50.400002f, 0.151181f, 3.600000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_385",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_385",38,385, 0);
		Create_a_teleport_trap(myObj,(float)51.000000,(float)3.000000,(float)3.600000,true);
		
		myObj = new GameObject("a_delete_object_trap_36_10_02_1006");
		pos = new Vector3(43.200001f, 3.628346f, 12.000000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_395",false);
		Create_a_delete_object_trap(myObj);
		
		myObj = new GameObject("a_look_trigger_99_99_02_1007");
		pos = new Vector3(119.314285f, 0.264567f, 119.314285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_419",false);
		CreateTrigger(myObj,37,10,"a_change_terrain_trap_37_10_02_1009");
		
		myObj = new GameObject("a_look_trigger_99_99_02_1008");
		pos = new Vector3(119.314285f, 3.628346f, 119.314285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_419",false);
		CreateTrigger(myObj,36,10,"a_delete_object_trap_36_10_02_1006");
		
		myObj = new GameObject("a_change_terrain_trap_37_10_02_1009");
		pos = new Vector3(44.400002f, 3.628346f, 12.000000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_389",false);
		Create_a_change_terrain_trap(myObj,37,10,0,0,"a_look_trigger_99_99_02_1008");
		
		myObj = new GameObject("a_move_trigger_05_03_02_1013");
		pos = new Vector3(6.600000f, 3.628346f, 4.200000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_416",false);
		CreateTrigger(myObj,5,4,"a_teleport_trap_05_04_02_1014");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		
		myObj = new GameObject("a_teleport_trap_05_04_02_1014");
		pos = new Vector3(6.000000f, 0.075591f, 4.800000f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_385",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"OBJECTS_385",38,385, 0);
		Create_a_teleport_trap(myObj,(float)6.600000,(float)4.200000,(float)3.600000,true);
		
		myObj = new GameObject("a_set_variable_trap_06_06_02_1016");
		pos = new Vector3(7.200000f, 0.604724f, 7.714286f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_397",false);
		Create_a_set_variable_trap(myObj);
		
		myObj = new GameObject("a_use_trigger_99_99_02_1017");
		pos = new Vector3(119.314285f, 3.628346f, 119.314285f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_418",false);
		CreateTrigger(myObj,6,5,"a_set_variable_trap_06_05_02_1023");
		
		myObj = new GameObject("a_set_variable_trap_06_05_02_1023");
		pos = new Vector3(7.200000f, 0.604724f, 6.171429f);
		myObj.transform.position = pos;
		CreateObjectGraphics(myObj,"Sprites/objects_397",false);
		Create_a_set_variable_trap(myObj);



		}



	[MenuItem("MyTools/RenameBrushes")]
	static void BrushRenamer()
	{
		RenameBrushes("world.worldspawn.Brush_1","Tile_30_00");
			
	}

	[MenuItem("MyTools/CreateAnim")]
	static void GenerateAnimationAssets()
	{
		return; //takes a long time to run..
		//Anim ID: 0 - which is a_rotworm
		//	File:c:\games\uw1\crit\CR26PAGE.N00, Palette = 0
		CreateAnimationUW("64_combat_idle", "CR26PAGE_N00_0_0000" , "CR26PAGE_N00_0_0001" , "CR26PAGE_N00_0_0002" , "CR26PAGE_N00_0_0003" , "" , "" , "" , "" ,4);
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
		CreateAnim();
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

	static void CreateUWActivators(GameObject myObj,string activatortype, string target, int triggerX, int triggerY, int state, int maxstate)
	{
		GameObject Button = new GameObject(myObj.name + "_activator");
		Button.transform.parent= myObj.transform;
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
				ObjectVariables objVars = Button.AddComponent<ObjectVariables>();
				objVars.state=state;
				break;
				}
		}

		//add a mesh for interaction
		BoxCollider box= Button.AddComponent<BoxCollider>();
		box.transform.position = myObj.transform.position;
		box.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
		box.isTrigger=true;
	}

	static void CreateObjectInteraction(GameObject myObj,float DimX,float DimY,float DimZ, float CenterY, string InventoryString, int ItemType, int ItemId, int isMoveable)
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
		SpriteRenderer objSprite =  myObj.GetComponentInChildren<SpriteRenderer>();
		if (objSprite==null)
		{
			Debug.Log (myObj.name + " is null");
		}
		objInteract.InventoryIcon = objSprite.sprite;
		objInteract.InventoryString=InventoryString;
		objInteract.InventoryIconEquip=objSprite.sprite;
		objInteract.InventoryIconEquipString=InventoryString;
		objInteract.ItemType=ItemType;//UWexporter id type
		objInteract.item_id=ItemId;//Internal ItemID

		if (isMoveable==1)
		{
			Rigidbody rgd = myObj.AddComponent<Rigidbody>();
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
		objInt.isRuneStone=false;
		objInt.isRuneBag=true;//Mutually exclusive
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

	static void CreateKey(GameObject myObj, int KeyId)
	{
		ObjectInteraction objInt = myObj.GetComponent<ObjectInteraction>();
		objInt.isKey=true;
		objInt.Owner=KeyId;
	}

	static void SetLink(GameObject myObj, int link)
	{
		ObjectInteraction objInt = myObj.GetComponent<ObjectInteraction>();
		objInt.Link = link;
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

	static void CreateTMAP(GameObject myObj, string AssetPath)
	{
		SpriteRenderer mysprite = myObj.AddComponent<SpriteRenderer>();//Adds the sprite gameobject
		Sprite image = Resources.Load <Sprite> (AssetPath);//Loads the sprite.
		mysprite.sprite = image;//Assigns the sprite to the object.
	}

}
