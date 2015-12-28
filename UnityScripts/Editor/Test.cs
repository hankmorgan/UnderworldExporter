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

	[MenuItem("MyTools/CreateGameObjects")]
	static void Create()
	{
		
		GameObject myObj;
		Vector3 pos;
		GameObject invMarker = GameObject.Find("InventoryMarker");
		Container ParentContainer;//For containers
		myObj = new GameObject("a_deep_lurker_07_01_06_0240");
		pos = new Vector3(8.914286f, 0.300000f, 1.714286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"116","Sprites/OBJECTS_116", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_116", "Sprites/OBJECTS_116", "Sprites/OBJECTS_116", 0, 116, 0, 7, 1, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 7, 1, 0, 0, 85, 0, 0, 4, 0, 0, 0, 0, 0, "WaterMesh1");
		SetRotation(myObj,0,270,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("special_tmap_obj_08_01_06_1019",10.200000f,0.300000f,1.210000f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 26, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_132", "" , 132, false);
		SetRotation(myObj,0,180,0);
		
		myObj = new GameObject("a_deep_lurker_09_02_06_0238");
		pos = new Vector3(11.314286f, 0.300000f, 2.914286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"116","Sprites/OBJECTS_116", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_116", "Sprites/OBJECTS_116", "Sprites/OBJECTS_116", 0, 116, 0, 9, 2, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 9, 2, 0, 0, 42, 0, 0, 4, 0, 0, 0, 0, 0, "WaterMesh1");
		SetRotation(myObj,0,225,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("a_goblin_21_02_06_0223");
		pos = new Vector3(25.885715f, 3.000000f, 3.257143f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"78","Sprites/OBJECTS_078", 209);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_078", "Sprites/OBJECTS_078", "Sprites/OBJECTS_078", 0, 78, 0, 21, 2, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 209, 21, 2, 0, 0, 83, 0, 0, 7, 1, 0, 0, 0, 0, "GroundMesh6");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("a_feral_troll_24_02_06_0231");
		pos = new Vector3(29.485716f, 3.300000f, 2.914286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"111","Sprites/OBJECTS_111", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_111", "Sprites/OBJECTS_111", "Sprites/OBJECTS_111", 0, 111, 0, 24, 2, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 24, 2, 0, 0, 113, 0, 0, 8, 1, 0, 0, 0, 0, "GroundMesh6");
		SetRotation(myObj,0,270,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("a_gazer_39_02_06_0192");
		pos = new Vector3(47.314285f, 3.900000f, 2.914286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"102","Sprites/OBJECTS_102", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_102", "Sprites/OBJECTS_102", "Sprites/OBJECTS_102", 0, 102, 429, 39, 2, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 39, 2, 0, 0, 32, 0, 0, 4, 0, 0, 0, 0, 0, "GroundMesh6");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		////NPC container with items
		
		AddObjectToContainer("a_red_gem_99_99_06_0429", ParentContainer, 0);
		AddObjectToContainer("a_gold_coin_99_99_06_1017", ParentContainer, 1);
		AddObjectToContainer("a_gold_coin_99_99_06_1018", ParentContainer, 2);
		AddObjectToContainer("a_gold_coin_99_99_06_0864", ParentContainer, 3);
		////Container contents complete
		
		
		myObj= CreateGameObject("a_green_potion_46_02_06_0521",56.228569f,3.900000f,3.085714f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_188",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_188", "Sprites/OBJECTS_188", "Sprites/OBJECTS_188", 14, 188, 542, 40, 0, 1, 1, 0, 1, 1, 1, 12, 1);
		AddPotion(myObj);
		
		myObj= CreateGameObject("a_red_potion_46_02_06_0522",56.057144f,3.900000f,3.428571f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_187",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_187", "Sprites/OBJECTS_187", "Sprites/OBJECTS_187", 14, 187, 534, 40, 0, 1, 1, 0, 1, 1, 1, 12, 1);
		AddPotion(myObj);
		
		
		myObj = new GameObject("door_051_002");
		pos = new Vector3(61.714287f, 3.300000f, 2.600000f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_324", "Sprites/OBJECTS_324", "Sprites/OBJECTS_324", 4, 324, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_05_material", 53, 0, 0);
		SetRotation(myObj,-90,90,0);
		
		myObj = new GameObject("door_055_002");
		pos = new Vector3(66.514290f, 3.300000f, 3.400000f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_325", "Sprites/OBJECTS_325", "Sprites/OBJECTS_325", 4, 325, 682, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_11_material", 27, 1, 0);
		SetRotation(myObj,-90,-90,0);
		
		
		
		myObj= CreateGameObject("special_tmap_obj_60_02_06_0967",72.010002f,3.300000f,3.000000f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 44, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_137", "" , 137, false);
		SetRotation(myObj,0,270,0);
		
		myObj = new GameObject("a_feral_troll_23_03_06_0220");
		pos = new Vector3(28.285715f, 3.300000f, 4.285714f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"111","Sprites/OBJECTS_111", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_111", "Sprites/OBJECTS_111", "Sprites/OBJECTS_111", 0, 111, 0, 23, 3, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 23, 3, 0, 0, 83, 0, 0, 8, 1, 0, 0, 0, 0, "GroundMesh6");
		SetRotation(myObj,0,180,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("a_reaper_27_03_06_0196");
		pos = new Vector3(32.914284f, 3.300000f, 4.457143f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"118","Sprites/OBJECTS_118", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_118", "Sprites/OBJECTS_118", "Sprites/OBJECTS_118", 0, 118, 0, 27, 3, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 27, 3, 0, 0, 85, 0, 0, 4, 0, 1, 0, 0, 0, "GroundMesh6");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_campfire_46_03_06_0527",55.885712f,3.300000f,4.285714f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_298",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_298", "Sprites/OBJECTS_298", "Sprites/OBJECTS_298", 16, 298, 1, 40, 0, 0, 0, 1, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_cauldron_46_03_06_0528",55.885712f,3.412500f,4.285714f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_303",true);
		
		myObj = new GameObject("door_054_003");
		pos = new Vector3(65.800003f, 3.300000f, 4.114285f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_324", "Sprites/OBJECTS_324", "Sprites/OBJECTS_324", 4, 324, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_05_material", 53, 0, 0);
		SetRotation(myObj,-90,0,0);
		
		
		myObj = new GameObject("door_019_004");
		pos = new Vector3(23.657143f, 2.400000f, 5.800000f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_325", "Sprites/OBJECTS_325", "Sprites/OBJECTS_325", 4, 325, 436, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_11_material", 23, 1, 0);
		SetRotation(myObj,-90,-90,0);
		
		myObj= CreateGameObject("a_pull_chain_17_05_06_0673",21.257143f,3.900000f,6.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_382",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_382", "Sprites/OBJECTS_382", "Sprites/OBJECTS_382", 8, 382, 667, 40, 0, 0, 1, 0, 0, 0, 0, 0, 1);
		CreateUWActivators(myObj,"ButtonHandler","a_use_trigger_99_99_06_0667",40,0,0,7,382);
		SetRotation(myObj,0,180,0);
		SetButtonProperties(myObj, 1, "Sprites/tmflat/tmflat_0014", "Sprites/tmflat/tmflat_0006");
		
		myObj = new GameObject("a_feral_troll_20_05_06_0226");
		pos = new Vector3(24.514284f, 2.400000f, 6.171429f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"111","Sprites/OBJECTS_111", 255);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_111", "Sprites/OBJECTS_111", "Sprites/OBJECTS_111", 0, 111, 0, 20, 5, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 255, 20, 5, 0, 0, 79, 0, 0, 7, 1, 0, 0, 0, 0, "GroundMesh6");
		SetRotation(myObj,0,90,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("a_goblin_22_05_06_0200");
		pos = new Vector3(26.571428f, 2.700000f, 6.514286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"78","Sprites/OBJECTS_078", 209);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_078", "Sprites/OBJECTS_078", "Sprites/OBJECTS_078", 0, 78, 0, 22, 5, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 209, 22, 5, 0, 0, 84, 0, 0, 10, 1, 0, 0, 0, 0, "GroundMesh6");
		SetRotation(myObj,0,90,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("door_022_005");
		pos = new Vector3(27.600000f, 2.700000f, 6.200000f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_326", "Sprites/OBJECTS_326", "Sprites/OBJECTS_326", 30, 326, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreatePortcullis(myObj, 53, 0, 0);
		SetRotation(myObj,-90,90,0);
		
		myObj= CreateGameObject("a_book_46_05_06_0717",56.057144f,3.600000f,6.857143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_307",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_307", "Sprites/OBJECTS_307", "Sprites/OBJECTS_307", 11, 307, 714, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetReadable(myObj);
		SetLink(myObj,714);
		
		myObj= CreateGameObject("a_scroll_48_05_06_0499",57.771431f,3.487500f,7.028571f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_312",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_312", "Sprites/OBJECTS_312", "Sprites/OBJECTS_312", 13, 312, 707, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetReadable(myObj);
		SetLink(myObj,707);
		
		myObj = new GameObject("a_deep_lurker_02_06_06_0233");
		pos = new Vector3(2.914286f, 0.300000f, 7.714286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"116","Sprites/OBJECTS_116", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_116", "Sprites/OBJECTS_116", "Sprites/OBJECTS_116", 0, 116, 0, 2, 6, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 2, 6, 0, 0, 58, 0, 0, 4, 0, 0, 0, 0, 0, "WaterMesh1");
		SetRotation(myObj,0,90,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("special_tmap_obj_23_06_06_0655",27.610001f,2.700000f,7.800000f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 25, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_005", "" , 5, false);
		SetRotation(myObj,0,270,0);
		
		myObj= CreateGameObject("a_scroll_45_06_06_0510",55.028568f,3.787500f,7.371429f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_319",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_319", "Sprites/OBJECTS_319", "Sprites/OBJECTS_319", 11, 319, 708, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetReadable(myObj);
		SetLink(myObj,708);
		
		myObj= CreateGameObject("a_red_potion_45_06_06_0511",55.028568f,3.900000f,7.714286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_187",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_187", "Sprites/OBJECTS_187", "Sprites/OBJECTS_187", 14, 187, 551, 40, 0, 1, 1, 0, 1, 1, 1, 12, 1);
		AddPotion(myObj);
		
		myObj= CreateGameObject("a_bottle_of_ale_bottles_of_ale_45_06_06_0512",55.200001f,3.900000f,8.057143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_186",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_186", "Sprites/OBJECTS_186", "Sprites/OBJECTS_186", 14, 186, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddPotion(myObj);
		
		
		
		myObj= CreateGameObject("a_jeweled_shield_49_06_06_0503",59.828568f,3.900000f,7.714286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_063",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_063", "Sprites/OBJECTS_063", "Sprites/OBJECTS_063", 78, 63, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddShield(myObj);
		
		myObj= CreateGameObject("a_skull_49_06_06_0505",59.314285f,3.900000f,8.057143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_194",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_194", "Sprites/OBJECTS_194", "Sprites/OBJECTS_194", 23, 194, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		
		
		myObj= CreateGameObject("special_tmap_obj_54_06_06_0945",65.400002f,3.000000f,7.210000f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 47, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_143", "" , 143, false);
		SetRotation(myObj,0,180,0);
		
		myObj = new GameObject("door_054_006");
		pos = new Vector3(65.000000f, 3.000000f, 8.228571f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_326", "Sprites/OBJECTS_326", "Sprites/OBJECTS_326", 30, 326, 718, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreatePortcullis(myObj, 27, 1, 0);
		SetRotation(myObj,-90,-180,0);
		
		
		myObj = new GameObject("a_lurker_04_07_06_0235");
		pos = new Vector3(5.314286f, 0.300000f, 8.914286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"87","Sprites/OBJECTS_087", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_087", "Sprites/OBJECTS_087", "Sprites/OBJECTS_087", 0, 87, 0, 4, 7, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 4, 7, 0, 0, 45, 0, 0, 4, 0, 0, 0, 0, 0, "WaterMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("a_goblin_19_07_06_0221");
		pos = new Vector3(23.314285f, 3.300000f, 8.914286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"78","Sprites/OBJECTS_078", 255);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_078", "Sprites/OBJECTS_078", "Sprites/OBJECTS_078", 0, 78, 0, 19, 7, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 255, 19, 7, 0, 0, 31, 0, 0, 7, 1, 0, 0, 0, 0, "GroundMesh6");
		SetRotation(myObj,0,90,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("a_goblin_20_07_06_0222");
		pos = new Vector3(24.514284f, 3.000000f, 8.742857f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"78","Sprites/OBJECTS_078", 209);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_078", "Sprites/OBJECTS_078", "Sprites/OBJECTS_078", 0, 78, 0, 20, 7, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 209, 20, 7, 0, 0, 77, 0, 0, 7, 1, 0, 0, 0, 0, "GroundMesh6");
		SetRotation(myObj,0,180,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_scroll_45_07_06_0513",54.857143f,3.900000f,8.742857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_313",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_313", "Sprites/OBJECTS_313", "Sprites/OBJECTS_313", 13, 313, 706, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetReadable(myObj);
		SetLink(myObj,706);
		
		myObj= CreateGameObject("a_red_potion_45_07_06_0514",54.857143f,3.900000f,8.571429f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_187",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_187", "Sprites/OBJECTS_187", "Sprites/OBJECTS_187", 14, 187, 533, 40, 0, 1, 1, 0, 1, 1, 1, 12, 1);
		AddPotion(myObj);
		
		myObj= CreateGameObject("a_bottle_of_water_bottles_of_water_45_07_06_0515",55.028568f,3.900000f,9.085714f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_189",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_189", "Sprites/OBJECTS_189", "Sprites/OBJECTS_189", 24, 189, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetFood(myObj);
		
		myObj= CreateGameObject("a_flask_of_port_flasks_of_port_45_07_06_0516",55.028568f,3.900000f,9.428571f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_190",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_190", "Sprites/OBJECTS_190", "Sprites/OBJECTS_190", 24, 190, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetFood(myObj);
		
		
		
		myObj= CreateGameObject("a_bench_benches_48_07_06_0500",58.628571f,3.300000f,8.914286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_336",true);
		
		myObj= CreateGameObject("special_tmap_obj_53_07_06_0930",64.199997f,3.000000f,8.410000f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 15, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_133", "" , 133, false);
		SetRotation(myObj,0,180,0);
		
		myObj= CreateGameObject("special_tmap_obj_55_07_06_0921",66.599998f,3.000000f,8.410000f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 15, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_133", "" , 133, false);
		SetRotation(myObj,0,180,0);
		
		myObj = new GameObject("a_cave_bat_03_08_06_0163");
		pos = new Vector3(4.114285f, 2.100000f, 10.114285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"66","Sprites/OBJECTS_066", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_066", "Sprites/OBJECTS_066", "Sprites/OBJECTS_066", 0, 66, 0, 3, 8, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 3, 8, 0, 0, 7, 0, 0, 8, 2, 0, 0, 0, 0, "GroundMesh4");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("a_goblin_18_08_06_0219");
		pos = new Vector3(22.285715f, 3.300000f, 10.628572f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"78","Sprites/OBJECTS_078", 255);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_078", "Sprites/OBJECTS_078", "Sprites/OBJECTS_078", 0, 78, 0, 18, 8, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 255, 18, 8, 0, 0, 57, 0, 0, 7, 1, 0, 0, 0, 0, "GroundMesh6");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		
		myObj= CreateGameObject("a_breastplate_37_08_06_0800",45.599998f,3.300000f,10.285714f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_034",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_034", "Sprites/OBJECTS_034", "Sprites/armour/armor_f_0002", 2, 34, 0, 16, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		CreateArmour(myObj, "Sprites/armour/armor_f_0002", "Sprites/armour/armor_m_0002", "Sprites/armour/armor_f_0017", "Sprites/armour/armor_m_0017", "Sprites/armour/armor_f_0032", "Sprites/armour/armor_m_0032", "Sprites/armour/armor_f_0047", "Sprites/armour/armor_m_0047", 6, 34);
		
		myObj= CreateGameObject("a_book_46_08_06_0501",55.542858f,3.600000f,9.600000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_309",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_309", "Sprites/OBJECTS_309", "Sprites/OBJECTS_309", 11, 309, 712, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetReadable(myObj);
		SetLink(myObj,712);
		
		myObj= CreateGameObject("a_book_46_08_06_0502",56.057144f,3.600000f,10.114285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_304",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_304", "Sprites/OBJECTS_304", "Sprites/OBJECTS_304", 11, 304, 711, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetReadable(myObj);
		SetLink(myObj,711);
		
		
		myObj= CreateGameObject("a_book_48_08_06_0498",57.942856f,3.487500f,10.285714f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_307",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_307", "Sprites/OBJECTS_307", "Sprites/OBJECTS_307", 11, 307, 710, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetReadable(myObj);
		SetLink(myObj,710);
		
		myObj= CreateGameObject("a_gold_coffer_48_08_06_0435",58.285713f,3.525000f,9.771429f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_138",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_138", "Sprites/OBJECTS_138", "Sprites/OBJECTS_139", 19, 138, 666, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		////Container contents
		ParentContainer = CreateContainer(myObj, 125, 255, 255);
		AddObjectToContainer("a_scroll_99_99_06_0666", ParentContainer, 0);
		////Container contents complete
		
		
		
		myObj = new GameObject("a_deep_lurker_02_09_06_0234");
		pos = new Vector3(2.914286f, 0.300000f, 11.314286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"116","Sprites/OBJECTS_116", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_116", "Sprites/OBJECTS_116", "Sprites/OBJECTS_116", 0, 116, 0, 2, 9, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 2, 9, 0, 0, 49, 0, 0, 4, 0, 0, 0, 0, 0, "WaterMesh1");
		SetRotation(myObj,0,135,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("a_deep_lurker_15_09_06_0224");
		pos = new Vector3(18.342857f, 0.300000f, 11.314286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"116","Sprites/OBJECTS_116", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_116", "Sprites/OBJECTS_116", "Sprites/OBJECTS_116", 0, 116, 0, 15, 9, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 15, 9, 0, 0, 40, 0, 0, 4, 0, 1, 0, 0, 0, "WaterMesh1");
		SetRotation(myObj,0,270,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		
		myObj= CreateGameObject("a_skull_37_09_06_0809",44.742855f,3.300000f,11.314286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_195",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_195", "Sprites/OBJECTS_195", "Sprites/OBJECTS_195", 23, 195, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("mail_leggings_pairs_of_mail_leggings_38_09_06_0801",45.942856f,3.300000f,10.800000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_036",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_036", "Sprites/OBJECTS_036", "Sprites/armour/armor_f_0004", 77, 36, 0, 12, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		CreateLeggings(myObj, "Sprites/armour/armor_f_0004", "Sprites/armour/armor_m_0004", "Sprites/armour/armor_f_0019", "Sprites/armour/armor_m_0019", "Sprites/armour/armor_f_0034", "Sprites/armour/armor_m_0034", "Sprites/armour/armor_f_0049", "Sprites/armour/armor_m_0049", 4, 12);
		
		myObj= CreateGameObject("a_scroll_38_09_06_0802",46.285713f,3.300000f,11.657143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_313",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_313", "Sprites/OBJECTS_313", "Sprites/OBJECTS_313", 13, 313, 704, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetReadable(myObj);
		SetLink(myObj,704);
		
		
		myObj= CreateGameObject("an_orb_54_09_06_0820",65.314285f,2.700000f,11.314286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_279",true);
		CreateUWActivators(myObj,"ButtonHandler","a_jeweled_shield_99_99_06_0001",40,0,0,7,279);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_279", "Sprites/OBJECTS_279", "Sprites/OBJECTS_279", 17, 279, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		
		myObj = new GameObject("a_gazer_30_10_06_0225");
		pos = new Vector3(36.514286f, 3.900000f, 12.514286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"102","Sprites/OBJECTS_102", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_102", "Sprites/OBJECTS_102", "Sprites/OBJECTS_102", 0, 102, 0, 30, 10, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 30, 10, 0, 0, 40, 0, 0, 4, 2, 0, 0, 0, 0, "GroundMesh6");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_broken_shield_37_10_06_0804",44.914288f,3.300000f,12.857142f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_203",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_203", "Sprites/OBJECTS_203", "Sprites/OBJECTS_203", 23, 203, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj = new GameObject("door_042_010");
		pos = new Vector3(51.599998f, 3.600000f, 12.200000f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_327", "Sprites/OBJECTS_327", "Sprites/OBJECTS_327", 29, 327, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"materials/tmap/uw1_000", 53, 0, 0);
		SetRotation(myObj,-90,90,0);
		
		
		myObj= CreateGameObject("special_tmap_obj_43_10_06_0352",51.609997f,3.600000f,12.600000f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 351, 40, 0, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,"uw1_000", "a_look_trigger_99_99_06_0351", 0, false);
		SetRotation(myObj,0,270,0);
		
		
		myObj = new GameObject("tybal_54_10_06_0203");
		pos = new Vector3(65.314285f, 2.400000f, 12.514286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"123","Sprites/OBJECTS_123", 231);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_123", "Sprites/OBJECTS_123", "Sprites/OBJECTS_123", 0, 123, 877, 54, 10, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 231, 54, 10, 0, 0, 120, 0, 0, 4, 0, 0, 0, 0, 0, "GroundMesh20");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		////NPC container with items
		
		AddObjectToContainer("a_key_99_99_06_0877", ParentContainer, 0);
		AddObjectToContainer("a_key_99_99_06_0476", ParentContainer, 1);
		AddObjectToContainer("a_medallion_99_99_06_0382", ParentContainer, 2);
		AddObjectToContainer("a_block_of_incense_blocks_of_incense_99_99_06_0381", ParentContainer, 3);
		AddObjectToContainer("some_strong_thread_pieces_of_strong_thread_99_99_06_0341", ParentContainer, 4);
		////Container contents complete
		
		
		myObj= CreateGameObject("a_broken_mace_17_11_06_0789",20.742857f,1.800000f,14.228572f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_202",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_202", "Sprites/OBJECTS_202", "Sprites/OBJECTS_202", 23, 202, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		
		myObj= CreateGameObject("a_scroll_47_11_06_0725",56.571430f,3.600000f,13.885715f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_313",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_313", "Sprites/OBJECTS_313", "Sprites/OBJECTS_313", 13, 313, 558, 40, 0, 1, 1, 0, 1, 1, 1, 12, 1);
		AddMagicScroll(myObj);
		
		
		myObj= CreateGameObject("special_tmap_obj_48_11_06_0529",58.200001f,3.300000f,14.389999f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 26, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_132", "" , 132, false);
		SetRotation(myObj,0,0,0);
		
		myObj= CreateGameObject("a_fountain_48_11_06_0523",58.285713f,3.300000f,13.885715f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_302",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_302", "Sprites/OBJECTS_302", "Sprites/OBJECTS_302", 82, 302, 1, 40, 0, 0, 1, 0, 0, 1, 0, 0, 1);
		AddFountain(myObj);
		
		myObj= CreateGameObject("a_fountain_48_11_06_0524",58.285713f,3.337500f,13.885715f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_457",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_457", "Sprites/OBJECTS_457", "Sprites/OBJECTS_457", 80, 457, 1, 40, 5, 0, 0, 5, 4, 1, 0, 0, 1);
		AddAnimationOverlay(myObj,5,4);
		
		myObj= CreateGameObject("special_tmap_obj_19_12_06_1016",23.400000f,3.600000f,14.410000f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 42, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_139", "" , 139, false);
		SetRotation(myObj,0,180,0);
		
		
		
		
		myObj= CreateGameObject("a_medallion_43_13_06_0998",52.114288f,3.300000f,16.114286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_300",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_300", "Sprites/OBJECTS_300", "Sprites/OBJECTS_300", 16, 300, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj = new GameObject("a_fighter_19_14_06_0255");
		pos = new Vector3(23.314285f, 3.600000f, 17.657143f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"104","Sprites/OBJECTS_104", 208);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_104", "Sprites/OBJECTS_104", "Sprites/OBJECTS_104", 0, 104, 0, 19, 14, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 208, 19, 14, 0, 0, 47, 0, 0, 7, 2, 1, 0, 0, 0, "GroundMesh6");
		SetRotation(myObj,0,180,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		
		myObj= CreateGameObject("a_gold_coin_38_14_06_0791",46.628571f,3.900000f,18.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_161",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", 18, 161, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_gold_coin_38_14_06_0792",45.771431f,3.900000f,17.657143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_161",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", 18, 161, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_gold_coin_38_14_06_0793",46.457142f,3.900000f,17.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_161",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", 18, 161, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj = new GameObject("a_dire_ghost_36_15_06_0193");
		pos = new Vector3(43.714287f, 3.750000f, 18.514286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"113","Sprites/OBJECTS_113", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_113", "Sprites/OBJECTS_113", "Sprites/OBJECTS_113", 0, 113, 0, 36, 15, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 36, 15, 0, 0, 61, 0, 0, 4, 0, 0, 0, 0, 0, "GroundMesh6");
		SetRotation(myObj,0,180,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_broken_axe_12_16_06_0787",14.914286f,3.300000f,19.371428f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_200",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_200", "Sprites/OBJECTS_200", "Sprites/OBJECTS_200", 23, 200, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_piece_of_wood_pieces_of_wood_12_16_06_0723",14.914286f,3.300000f,19.885714f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_205",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_205", "Sprites/OBJECTS_205", "Sprites/OBJECTS_205", 23, 205, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_bone_13_16_06_0714",15.771428f,3.300000f,20.057142f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_197",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_197", "Sprites/OBJECTS_197", "Sprites/OBJECTS_197", 23, 197, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj = new GameObject("door_054_017");
		pos = new Vector3(65.800003f, 3.600000f, 21.428572f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_324", "Sprites/OBJECTS_324", "Sprites/OBJECTS_324", 4, 324, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_05_material", 53, 0, 0);
		SetRotation(myObj,-90,0,0);
		
		
		
		
		myObj = new GameObject("door_030_020");
		pos = new Vector3(36.685715f, 3.600000f, 24.200001f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_324", "Sprites/OBJECTS_324", "Sprites/OBJECTS_324", 4, 324, 860, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_05_material", 24, 1, 0);
		SetRotation(myObj,-90,90,0);
		
		myObj = new GameObject("a_cave_bat_35_20_06_0165");
		pos = new Vector3(42.514286f, 4.200000f, 24.514284f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"66","Sprites/OBJECTS_066", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_066", "Sprites/OBJECTS_066", "Sprites/OBJECTS_066", 0, 66, 0, 35, 20, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 35, 20, 0, 0, 8, 0, 0, 8, 2, 0, 0, 0, 0, "GroundMesh6");
		SetRotation(myObj,0,270,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		
		
		myObj = new GameObject("door_029_021");
		pos = new Vector3(35.000000f, 3.600000f, 25.714285f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_325", "Sprites/OBJECTS_325", "Sprites/OBJECTS_325", 4, 325, 410, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_11_material", 0, 1, 0);
		SetRotation(myObj,-90,-180,0);
		
		
		
		myObj = new GameObject("a_cave_bat_10_22_06_0164");
		pos = new Vector3(12.514286f, 2.700000f, 26.914284f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"66","Sprites/OBJECTS_066", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_066", "Sprites/OBJECTS_066", "Sprites/OBJECTS_066", 0, 66, 0, 10, 22, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 10, 22, 0, 0, 10, 0, 0, 8, 2, 0, 0, 0, 0, "GroundMesh6");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_campfire_26_22_06_0696",31.714285f,3.600000f,26.914284f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_298",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_298", "Sprites/OBJECTS_298", "Sprites/OBJECTS_298", 16, 298, 1, 40, 0, 0, 0, 1, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_bottle_of_water_bottles_of_water_26_22_06_0697",31.371428f,3.600000f,27.428572f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_189",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_189", "Sprites/OBJECTS_189", "Sprites/OBJECTS_189", 24, 189, 1, 40, 9, 1, 1, 0, 1, 1, 0, 0, 1);
		SetFood(myObj);
		
		myObj = new GameObject("a_goblin_27_22_06_0174");
		pos = new Vector3(32.914284f, 3.600000f, 26.914284f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"80","Sprites/OBJECTS_080", 222);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_080", "Sprites/OBJECTS_080", "Sprites/OBJECTS_080", 0, 80, 0, 27, 22, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 222, 27, 22, 0, 0, 78, 0, 0, 7, 1, 0, 0, 0, 0, "GroundMesh6");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_pull_chain_28_22_06_0710",34.457142f,4.200000f,26.400000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_374",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_374", "Sprites/OBJECTS_374", "Sprites/OBJECTS_374", 8, 374, 711, 40, 0, 0, 1, 0, 0, 0, 0, 0, 1);
		CreateUWActivators(myObj,"ButtonHandler","a_use_trigger_99_99_06_0711",40,0,0,7,374);
		SetRotation(myObj,0,180,0);
		SetButtonProperties(myObj, 0, "Sprites/tmflat/tmflat_0006", "Sprites/tmflat/tmflat_0014");
		
		
		myObj = new GameObject("a_cave_bat_37_22_06_0171");
		pos = new Vector3(44.914288f, 3.900000f, 26.914284f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"66","Sprites/OBJECTS_066", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_066", "Sprites/OBJECTS_066", "Sprites/OBJECTS_066", 0, 66, 0, 37, 22, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 37, 22, 0, 0, 8, 0, 0, 8, 2, 0, 0, 0, 0, "GroundMesh20");
		SetRotation(myObj,0,180,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		
		myObj = new GameObject("a_cave_bat_04_23_06_0161");
		pos = new Vector3(5.314286f, 3.600000f, 28.114285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"66","Sprites/OBJECTS_066", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_066", "Sprites/OBJECTS_066", "Sprites/OBJECTS_066", 0, 66, 0, 4, 23, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 4, 23, 0, 0, 11, 0, 0, 8, 2, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("a_deep_lurker_06_23_06_0232");
		pos = new Vector3(7.714286f, 0.300000f, 28.114285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"116","Sprites/OBJECTS_116", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_116", "Sprites/OBJECTS_116", "Sprites/OBJECTS_116", 0, 116, 0, 6, 23, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 6, 23, 0, 0, 40, 0, 0, 4, 0, 0, 0, 0, 0, "WaterMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		
		myObj = new GameObject("a_deep_lurker_23_23_06_0230");
		pos = new Vector3(28.114285f, 0.300000f, 28.114285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"116","Sprites/OBJECTS_116", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_116", "Sprites/OBJECTS_116", "Sprites/OBJECTS_116", 0, 116, 0, 23, 23, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 23, 23, 0, 0, 65, 0, 0, 4, 0, 1, 0, 0, 0, "WaterMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		
		
		myObj = new GameObject("a_goblin_27_24_06_0195");
		pos = new Vector3(32.742855f, 3.600000f, 29.657143f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"80","Sprites/OBJECTS_080", 222);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_080", "Sprites/OBJECTS_080", "Sprites/OBJECTS_080", 0, 80, 0, 27, 24, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 222, 27, 24, 0, 0, 40, 0, 0, 10, 1, 1, 0, 0, 0, "GroundMesh6");
		SetRotation(myObj,0,315,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("a_goblin_29_24_06_0176");
		pos = new Vector3(35.314285f, 3.600000f, 29.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"80","Sprites/OBJECTS_080", 222);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_080", "Sprites/OBJECTS_080", "Sprites/OBJECTS_080", 0, 80, 0, 29, 24, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 222, 29, 24, 0, 0, 48, 0, 0, 7, 1, 0, 0, 0, 0, "GroundMesh6");
		SetRotation(myObj,0,225,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("a_goblin_30_24_06_0187");
		pos = new Vector3(36.514286f, 3.600000f, 29.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"80","Sprites/OBJECTS_080", 222);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_080", "Sprites/OBJECTS_080", "Sprites/OBJECTS_080", 0, 80, 0, 30, 24, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 222, 30, 24, 0, 0, 60, 0, 0, 7, 1, 0, 0, 0, 0, "GroundMesh6");
		SetRotation(myObj,0,270,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("a_cave_bat_36_24_06_0166");
		pos = new Vector3(43.714287f, 3.300000f, 29.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"66","Sprites/OBJECTS_066", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_066", "Sprites/OBJECTS_066", "Sprites/OBJECTS_066", 0, 66, 0, 36, 24, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 36, 24, 0, 0, 6, 0, 0, 8, 2, 0, 0, 0, 0, "GroundMesh20");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		
		
		
		
		myObj= CreateGameObject("a_campfire_29_25_06_0706",35.657143f,3.600000f,30.514284f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_298",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_298", "Sprites/OBJECTS_298", "Sprites/OBJECTS_298", 16, 298, 1, 40, 0, 0, 0, 1, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_piece_of_meat_pieces_of_meat_29_25_06_0707",35.142857f,3.600000f,30.514284f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_176",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_176", "Sprites/OBJECTS_176", "Sprites/OBJECTS_176", 24, 176, 1, 40, 9, 1, 1, 0, 1, 1, 0, 0, 1);
		SetFood(myObj);
		
		
		
		
		myObj = new GameObject("a_ghost_16_26_06_0170");
		pos = new Vector3(19.714287f, 3.750000f, 31.714285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"97","Sprites/OBJECTS_097", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_097", "Sprites/OBJECTS_097", "Sprites/OBJECTS_097", 0, 97, 0, 16, 26, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 16, 26, 0, 0, 72, 0, 0, 4, 0, 0, 0, 0, 0, "GroundMesh7");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		
		
		myObj = new GameObject("a_cave_bat_38_26_06_0160");
		pos = new Vector3(46.114288f, 2.550000f, 31.714285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"66","Sprites/OBJECTS_066", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_066", "Sprites/OBJECTS_066", "Sprites/OBJECTS_066", 0, 66, 0, 38, 26, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 38, 26, 0, 0, 10, 0, 0, 8, 2, 0, 0, 0, 0, "GroundMesh20");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		
		
		
		
		
		myObj = new GameObject("a_goblin_09_28_06_0214");
		pos = new Vector3(11.314286f, 3.300000f, 34.114285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"78","Sprites/OBJECTS_078", 255);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_078", "Sprites/OBJECTS_078", "Sprites/OBJECTS_078", 0, 78, 0, 9, 28, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 255, 9, 28, 0, 0, 51, 0, 0, 8, 1, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("a_goblin_11_28_06_0215");
		pos = new Vector3(13.714286f, 3.300000f, 34.114285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"78","Sprites/OBJECTS_078", 255);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_078", "Sprites/OBJECTS_078", "Sprites/OBJECTS_078", 0, 78, 0, 11, 28, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 255, 11, 28, 0, 0, 56, 0, 0, 8, 1, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,315,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		
		
		
		
		myObj= CreateGameObject("special_tmap_obj_03_29_06_0420",4.200000f,2.700000f,35.990002f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 25, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_005", "" , 5, false);
		SetRotation(myObj,0,0,0);
		
		myObj = new GameObject("door_004_029");
		pos = new Vector3(5.314286f, 2.700000f, 35.000000f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_326", "Sprites/OBJECTS_326", "Sprites/OBJECTS_326", 30, 326, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreatePortcullis(myObj, 53, 0, 0);
		SetRotation(myObj,-90,90,0);
		
		myObj = new GameObject("a_goblin_05_29_06_0202");
		pos = new Vector3(6.000000f, 2.700000f, 35.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"78","Sprites/OBJECTS_078", 219);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_078", "Sprites/OBJECTS_078", "Sprites/OBJECTS_078", 0, 78, 0, 5, 29, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 219, 5, 29, 0, 0, 78, 0, 0, 10, 1, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,270,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("a_feral_troll_06_29_06_0218");
		pos = new Vector3(8.057143f, 2.700000f, 35.485714f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"111","Sprites/OBJECTS_111", 255);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_111", "Sprites/OBJECTS_111", "Sprites/OBJECTS_111", 0, 111, 0, 6, 29, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 255, 6, 29, 0, 0, 75, 0, 0, 7, 1, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,315,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("special_tmap_obj_17_29_06_0342",21.590000f,3.600000f,35.400002f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 343, 40, 30, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,"uw1_208", "a_look_trigger_99_99_06_0343", 208, false);
		SetRotation(myObj,0,90,0);
		
		myObj = new GameObject("door_018_029");
		pos = new Vector3(21.600000f, 3.600000f, 35.799999f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_327", "Sprites/OBJECTS_327", "Sprites/OBJECTS_327", 29, 327, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"materials/tmap/uw1_208", 53, 0, 0);
		SetRotation(myObj,-90,-90,0);
		
		
		myObj = new GameObject("a_goblin_08_30_06_0216");
		pos = new Vector3(9.942857f, 3.000000f, 36.514286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"78","Sprites/OBJECTS_078", 219);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_078", "Sprites/OBJECTS_078", "Sprites/OBJECTS_078", 0, 78, 0, 8, 30, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 219, 8, 30, 0, 0, 97, 0, 0, 7, 1, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,270,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		
		
		myObj = new GameObject("a_cave_bat_38_30_06_0162");
		pos = new Vector3(46.114288f, 3.900000f, 36.514286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"66","Sprites/OBJECTS_066", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_066", "Sprites/OBJECTS_066", "Sprites/OBJECTS_066", 0, 66, 0, 38, 30, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 38, 30, 0, 0, 5, 0, 0, 8, 2, 0, 0, 0, 0, "GroundMesh6");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		
		
		myObj = new GameObject("a_feral_troll_04_31_06_0217");
		pos = new Vector3(5.828571f, 2.700000f, 37.714283f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"111","Sprites/OBJECTS_111", 255);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_111", "Sprites/OBJECTS_111", "Sprites/OBJECTS_111", 0, 111, 0, 4, 31, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 255, 4, 31, 0, 0, 77, 0, 0, 7, 1, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,90,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_gravestone_17_31_06_0566",20.742857f,3.600000f,37.714283f);
		SetRotation(myObj,0,90,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_357", "Sprites/OBJECTS_357", "Sprites/OBJECTS_357", 84, 357, 799, 40, 0, 0, 1, 0, 1, 1, 0, 0, 1);
		AddGrave(myObj, 28,12);
		
		myObj= CreateGameObject("special_tmap_obj_17_31_06_0567",20.914284f,3.600000f,38.228573f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 27, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_158", "" , 158, false);
		SetRotation(myObj,0,0,0);
		
		
		
		myObj= CreateGameObject("special_tmap_obj_25_31_06_0564",30.514284f,3.600000f,38.228573f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 27, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_158", "" , 158, false);
		SetRotation(myObj,0,0,0);
		
		myObj = new GameObject("door_038_031");
		pos = new Vector3(45.799999f, 3.600000f, 37.714283f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_325", "Sprites/OBJECTS_325", "Sprites/OBJECTS_325", 4, 325, 859, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_11_material", 24, 1, 0);
		SetRotation(myObj,-90,-180,0);
		
		
		
		
		
		myObj= CreateGameObject("a_pull_chain_07_32_06_0423",8.571429f,4.200000f,38.400002f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_374",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_374", "Sprites/OBJECTS_374", "Sprites/OBJECTS_374", 8, 374, 846, 40, 0, 0, 1, 0, 0, 0, 0, 0, 1);
		CreateUWActivators(myObj,"ButtonHandler","a_use_trigger_99_99_06_0846",40,0,0,7,374);
		SetRotation(myObj,0,180,0);
		SetButtonProperties(myObj, 0, "Sprites/tmflat/tmflat_0006", "Sprites/tmflat/tmflat_0014");
		
		myObj= CreateGameObject("a_pack_07_32_06_0426",9.428571f,3.600000f,38.914284f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_130",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_130", "Sprites/OBJECTS_130", "Sprites/OBJECTS_131", 19, 130, 424, 40, 9, 1, 1, 0, 1, 0, 0, 0, 1);
		////Container contents
		ParentContainer = CreateContainer(myObj, 250, 255, 255);
		AddObjectToContainer("a_fish_fish_99_99_06_0424", ParentContainer, 0);
		AddObjectToContainer("a_piece_of_meat_pieces_of_meat_99_99_06_0422", ParentContainer, 1);
		AddObjectToContainer("an_apple_99_99_06_0421", ParentContainer, 2);
		////Container contents complete
		
		
		myObj= CreateGameObject("a_campfire_07_32_06_0427",8.914286f,3.600000f,38.914284f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_298",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_298", "Sprites/OBJECTS_298", "Sprites/OBJECTS_298", 16, 298, 1, 40, 0, 0, 0, 1, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj = new GameObject("door_016_032");
		pos = new Vector3(20.400000f, 3.600000f, 38.599998f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_327", "Sprites/OBJECTS_327", "Sprites/OBJECTS_327", 29, 327, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"materials/tmap/uw1_154", 53, 0, 0);
		SetRotation(myObj,-90,90,0);
		
		myObj= CreateGameObject("special_tmap_obj_17_32_06_0568",21.000000f,3.600000f,38.410000f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 27, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_158", "" , 158, false);
		SetRotation(myObj,0,180,0);
		
		myObj = new GameObject("door_020_032");
		pos = new Vector3(24.685715f, 3.600000f, 39.400002f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_321", "Sprites/OBJECTS_321", "Sprites/OBJECTS_321", 4, 321, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_12_material", 53, 0, 0);
		SetRotation(myObj,-90,-90,0);
		
		myObj = new GameObject("door_022_032");
		pos = new Vector3(26.914284f, 3.600000f, 38.599998f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_321", "Sprites/OBJECTS_321", "Sprites/OBJECTS_321", 4, 321, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_12_material", 53, 0, 0);
		SetRotation(myObj,-90,90,0);
		
		myObj= CreateGameObject("a_gravestone_25_32_06_0561",30.857143f,3.600000f,38.914284f);
		SetRotation(myObj,0,270,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_357", "Sprites/OBJECTS_357", "Sprites/OBJECTS_357", 84, 357, 803, 40, 0, 0, 1, 0, 1, 1, 0, 0, 1);
		AddGrave(myObj, 28,16);
		
		myObj= CreateGameObject("special_tmap_obj_25_32_06_0563",30.600000f,3.600000f,38.410000f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 27, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_158", "" , 158, false);
		SetRotation(myObj,0,180,0);
		
		myObj= CreateGameObject("special_tmap_obj_37_32_06_1020",44.410000f,3.600000f,39.000000f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 46, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_142", "" , 142, false);
		SetRotation(myObj,0,270,0);
		
		
		
		myObj= CreateGameObject("a_pile_of_bones_piles_of_bones_45_32_06_0770",54.857143f,3.600000f,39.257145f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_198",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_198", "Sprites/OBJECTS_198", "Sprites/OBJECTS_198", 23, 198, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		
		
		
		myObj = new GameObject("a_feral_troll_03_33_06_0182");
		pos = new Vector3(4.114285f, 3.300000f, 40.114285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"111","Sprites/OBJECTS_111", 255);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_111", "Sprites/OBJECTS_111", "Sprites/OBJECTS_111", 0, 111, 0, 3, 33, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 255, 3, 33, 0, 0, 52, 0, 0, 7, 1, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,315,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		
		myObj= CreateGameObject("special_tmap_obj_11_33_06_0462",14.389999f,2.400000f,40.200001f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 45, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_141", "" , 141, false);
		SetRotation(myObj,0,90,0);
		
		
		myObj= CreateGameObject("a_blood_stain_45_33_06_0855",54.857143f,3.600000f,39.771427f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_222",true);
		
		myObj= CreateGameObject("some_writing_45_33_06_0771",55.200001f,4.200000f,40.457142f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_358",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_358", "Sprites/OBJECTS_358", "Sprites/OBJECTS_358", 10, 358, 805, 0, 0, 0, 1, 0, 0, 1, 1, 15, 1);
		SetReadable(myObj);
		SetRotation(myObj,0,90,0);
		SetSprite(myObj, "Sprites/tmobj/tmobj_27");
		SetLink(myObj,805);
		
		myObj = new GameObject("a_goblin_02_34_06_0249");
		pos = new Vector3(2.914286f, 3.300000f, 41.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"78","Sprites/OBJECTS_078", 255);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_078", "Sprites/OBJECTS_078", "Sprites/OBJECTS_078", 0, 78, 0, 2, 34, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 255, 2, 34, 0, 0, 60, 0, 0, 8, 1, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,180,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_pull_chain_04_34_06_0665",6.000000f,3.900000f,41.657143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_382",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_382", "Sprites/OBJECTS_382", "Sprites/OBJECTS_382", 8, 382, 664, 40, 0, 0, 1, 0, 0, 0, 0, 0, 1);
		CreateUWActivators(myObj,"ButtonHandler","a_use_trigger_99_99_06_0664",40,0,0,7,382);
		SetRotation(myObj,0,90,0);
		SetButtonProperties(myObj, 1, "Sprites/tmflat/tmflat_0014", "Sprites/tmflat/tmflat_0006");
		
		myObj = new GameObject("a_feral_troll_07_34_06_0198");
		pos = new Vector3(9.085714f, 3.600000f, 40.971432f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"111","Sprites/OBJECTS_111", 255);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_111", "Sprites/OBJECTS_111", "Sprites/OBJECTS_111", 0, 111, 0, 7, 34, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 255, 7, 34, 0, 0, 77, 0, 0, 7, 1, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,225,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_gravestone_17_34_06_0571",20.742857f,3.600000f,41.485714f);
		SetRotation(myObj,0,90,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_357", "Sprites/OBJECTS_357", "Sprites/OBJECTS_357", 84, 357, 801, 40, 0, 0, 1, 0, 1, 1, 0, 0, 1);
		AddGrave(myObj, 28,14);
		
		myObj= CreateGameObject("a_ruby_rubies_17_34_06_0405",20.742857f,3.787500f,41.485714f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_162",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_162", "Sprites/OBJECTS_162", "Sprites/OBJECTS_162", 18, 162, 398, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		AddPickupLink(myObj, "a_pick_up_trigger_99_99_06_0398");
		
		myObj= CreateGameObject("special_tmap_obj_17_34_06_0918",21.000000f,3.600000f,41.990002f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 27, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_158", "" , 158, false);
		SetRotation(myObj,0,0,0);
		
		
		myObj = new GameObject("door_020_034");
		pos = new Vector3(24.514284f, 3.600000f, 41.799999f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_321", "Sprites/OBJECTS_321", "Sprites/OBJECTS_321", 4, 321, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_12_material", 53, 0, 0);
		SetRotation(myObj,-90,-90,0);
		
		myObj = new GameObject("door_022_034");
		pos = new Vector3(26.914284f, 3.600000f, 41.000000f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_321", "Sprites/OBJECTS_321", "Sprites/OBJECTS_321", 4, 321, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_12_material", 53, 0, 0);
		SetRotation(myObj,-90,90,0);
		
		
		myObj= CreateGameObject("a_gravestone_25_34_06_0558",30.857143f,3.600000f,41.314285f);
		SetRotation(myObj,0,270,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_357", "Sprites/OBJECTS_357", "Sprites/OBJECTS_357", 84, 357, 798, 40, 0, 0, 1, 0, 1, 1, 0, 0, 1);
		AddGrave(myObj, 28,9);
		
		myObj= CreateGameObject("special_tmap_obj_25_34_06_0559",30.514284f,3.600000f,41.828568f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 27, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_158", "" , 158, false);
		SetRotation(myObj,0,0,0);
		
		
		myObj = new GameObject("a_goblin_03_35_06_0250");
		pos = new Vector3(4.114285f, 3.300000f, 42.514286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"78","Sprites/OBJECTS_078", 255);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_078", "Sprites/OBJECTS_078", "Sprites/OBJECTS_078", 0, 78, 0, 3, 35, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 255, 3, 35, 0, 0, 60, 0, 0, 8, 1, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,225,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("door_007_035");
		pos = new Vector3(8.600000f, 4.500000f, 42.514286f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_334", "Sprites/OBJECTS_334", "Sprites/OBJECTS_334", 30, 334, 663, 40, 0, 0, 1, 0, 1, 0, 1, 12, 1);
		CreatePortcullis(myObj, 23, 1, 1);
		SetRotation(myObj,-90,-180,0);
		
		myObj= CreateGameObject("a_gravestone_17_35_06_0570",20.742857f,3.600000f,42.685715f);
		SetRotation(myObj,0,90,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_357", "Sprites/OBJECTS_357", "Sprites/OBJECTS_357", 84, 357, 800, 40, 0, 0, 1, 0, 1, 1, 0, 0, 1);
		AddGrave(myObj, 28,13);
		
		myObj= CreateGameObject("an_emerald_17_35_06_0401",20.742857f,3.787500f,42.685715f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_167",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_167", "Sprites/OBJECTS_167", "Sprites/OBJECTS_167", 18, 167, 400, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		AddPickupLink(myObj, "a_pick_up_trigger_99_99_06_0400");
		
		myObj= CreateGameObject("special_tmap_obj_17_35_06_0946",20.914284f,3.600000f,42.171432f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_367", "Sprites/OBJECTS_367", "Sprites/OBJECTS_367", 35, 367, 0, 40, 27, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_158", "" , 158, false);
		SetRotation(myObj,0,180,0);
		
		
		
		myObj = new GameObject("door_021_035");
		pos = new Vector3(26.200001f, 3.600000f, 42.514286f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_321", "Sprites/OBJECTS_321", "Sprites/OBJECTS_321", 4, 321, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_12_material", 53, 0, 0);
		SetRotation(myObj,-90,0,0);
		
		myObj= CreateGameObject("special_tmap_obj_25_35_06_0557",30.600000f,3.600000f,42.009998f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 27, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_158", "" , 158, false);
		SetRotation(myObj,0,180,0);
		
		myObj= CreateGameObject("special_tmap_obj_25_35_06_0942",31.190001f,3.600000f,42.599998f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 926, 40, 4, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,"uw1_154", "a_look_trigger_99_99_06_0926", 154, false);
		SetRotation(myObj,0,90,0);
		
		myObj = new GameObject("door_026_035");
		pos = new Vector3(31.200001f, 3.600000f, 43.000000f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_327", "Sprites/OBJECTS_327", "Sprites/OBJECTS_327", 29, 327, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"materials/tmap/uw1_154", 53, 0, 0);
		SetRotation(myObj,-90,-90,0);
		
		
		
		
		myObj = new GameObject("an_imp_34_35_06_0181");
		pos = new Vector3(41.314285f, 4.050000f, 43.200001f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"75","Sprites/OBJECTS_075", 255);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_075", "Sprites/OBJECTS_075", "Sprites/OBJECTS_075", 0, 75, 0, 34, 35, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 255, 34, 35, 0, 0, 14, 0, 0, 7, 2, 0, 0, 0, 0, "GroundMesh13");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		
		myObj = new GameObject("door_036_035");
		pos = new Vector3(44.200001f, 1.200000f, 43.200001f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_327", "Sprites/OBJECTS_327", "Sprites/OBJECTS_327", 29, 327, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"materials/tmap/uw1_192", 53, 0, 0);
		SetRotation(myObj,-90,0,0);
		
		
		
		
		myObj= CreateGameObject("a_pile_of_bones_piles_of_bones_18_36_06_0403",22.457144f,3.787500f,43.885712f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_198",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_198", "Sprites/OBJECTS_198", "Sprites/OBJECTS_198", 23, 198, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_skull_18_36_06_0404",22.114285f,3.900000f,43.542858f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_194",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_194", "Sprites/OBJECTS_194", "Sprites/OBJECTS_194", 23, 194, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		
		
		
		
		
		myObj = new GameObject("an_imp_33_36_06_0180");
		pos = new Vector3(40.628571f, 4.050000f, 43.885712f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"75","Sprites/OBJECTS_075", 255);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_075", "Sprites/OBJECTS_075", "Sprites/OBJECTS_075", 0, 75, 0, 33, 36, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 255, 33, 36, 0, 0, 10, 0, 0, 7, 2, 0, 0, 0, 0, "GroundMesh13");
		SetRotation(myObj,0,90,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("an_earth_golem_34_36_06_0208");
		pos = new Vector3(41.314285f, 1.200000f, 43.714287f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"114","Sprites/OBJECTS_114", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_114", "Sprites/OBJECTS_114", "Sprites/OBJECTS_114", 0, 114, 0, 34, 36, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 34, 36, 0, 0, 70, 0, 0, 7, 2, 0, 0, 0, 0, "GroundMesh13");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_blood_stain_36_36_06_0911",43.714287f,1.200000f,43.542858f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_222",true);
		
		myObj= CreateGameObject("a_blood_stain_36_36_06_0925",43.371429f,1.200000f,44.057144f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_223",true);
		
		myObj= CreateGameObject("special_tmap_obj_36_36_06_0869",43.799999f,1.200000f,43.209999f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 866, 40, 5, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,"uw1_192", "a_look_trigger_99_99_06_0866", 192, false);
		SetRotation(myObj,0,180,0);
		
		myObj= CreateGameObject("a_gold_coin_37_36_06_0445",44.742855f,1.200000f,43.371429f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_161",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", 18, 161, 1, 40, 20, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("an_emerald_37_36_06_0447",45.085712f,1.200000f,43.371429f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_167",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_167", "Sprites/OBJECTS_167", "Sprites/OBJECTS_167", 18, 167, 440, 40, 20, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		AddPickupLink(myObj, "a_pick_up_trigger_99_99_06_0440");
		
		myObj= CreateGameObject("a_sceptre_37_36_06_0449",44.914288f,1.200000f,43.714287f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_170",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_170", "Sprites/OBJECTS_170", "Sprites/OBJECTS_170", 18, 170, 448, 40, 20, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		AddPickupLink(myObj, "a_pick_up_trigger_99_99_06_0448");
		
		myObj= CreateGameObject("an_amulet_37_36_06_0483",45.428570f,1.200000f,43.542858f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_168",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_168", "Sprites/OBJECTS_168", "Sprites/OBJECTS_168", 18, 168, 1, 40, 20, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_ruby_rubies_38_36_06_0454",45.771431f,1.200000f,44.228569f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_162",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_162", "Sprites/OBJECTS_162", "Sprites/OBJECTS_162", 18, 162, 441, 40, 20, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		AddPickupLink(myObj, "a_pick_up_trigger_99_99_06_0441");
		
		myObj= CreateGameObject("a_crown_38_36_06_0654",46.628571f,1.200000f,44.228569f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_050",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_050", "Sprites/OBJECTS_050", "Sprites/armour/armor_f_0063", 73, 50, 724, 40, 0, 1, 1, 0, 1, 1, 1, 8, 1);
		CreateHelm(myObj, "Sprites/armour/armor_f_0063", "Sprites/armour/armor_m_0063", "Sprites/armour/armor_f_0063", "Sprites/armour/armor_m_0063", "Sprites/armour/armor_f_0063", "Sprites/armour/armor_m_0063", "Sprites/armour/armor_f_0063", "Sprites/armour/armor_m_0063", 6099796, 6257896);
		
		myObj= CreateGameObject("a_crown_38_36_06_0486",46.285713f,1.200000f,43.371429f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_048",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_048", "Sprites/OBJECTS_048", "Sprites/armour/armor_f_0061", 73, 48, 661, 40, 0, 1, 1, 0, 1, 1, 1, 8, 1);
		CreateHelm(myObj, "Sprites/armour/armor_f_0061", "Sprites/armour/armor_m_0061", "Sprites/armour/armor_f_0061", "Sprites/armour/armor_m_0061", "Sprites/armour/armor_f_0061", "Sprites/armour/armor_m_0061", "Sprites/armour/armor_f_0061", "Sprites/armour/armor_m_0061", 6099796, 6218248);
		
		myObj= CreateGameObject("a_crown_38_36_06_0907",46.114288f,1.200000f,43.714287f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_049",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_049", "Sprites/OBJECTS_049", "Sprites/armour/armor_f_0062", 73, 49, 661, 40, 0, 1, 1, 0, 1, 1, 1, 8, 1);
		CreateHelm(myObj, "Sprites/armour/armor_f_0062", "Sprites/armour/armor_m_0062", "Sprites/armour/armor_f_0062", "Sprites/armour/armor_m_0062", "Sprites/armour/armor_f_0062", "Sprites/armour/armor_m_0062", "Sprites/armour/armor_f_0062", "Sprites/armour/armor_m_0062", 6099796, 6317604);
		
		myObj= CreateGameObject("a_gold_chain_38_36_06_0487",45.942856f,1.200000f,43.371429f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_171",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_171", "Sprites/OBJECTS_171", "Sprites/OBJECTS_171", 18, 171, 464, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		AddPickupLink(myObj, "a_pick_up_trigger_99_99_06_0464");
		
		myObj= CreateGameObject("a_coin_38_36_06_0488",46.457142f,1.200000f,43.714287f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_160",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_160", "Sprites/OBJECTS_160", "Sprites/OBJECTS_160", 18, 160, 1, 40, 20, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		
		
		myObj = new GameObject("an_imp_39_36_06_0179");
		pos = new Vector3(46.799999f, 3.900000f, 43.885712f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"75","Sprites/OBJECTS_075", 255);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_075", "Sprites/OBJECTS_075", "Sprites/OBJECTS_075", 0, 75, 0, 39, 36, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 255, 39, 36, 0, 0, 15, 0, 0, 7, 2, 0, 0, 0, 0, "GroundMesh13");
		SetRotation(myObj,0,270,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_gravestone_30_37_06_0542",36.342857f,3.600000f,44.914288f);
		SetRotation(myObj,0,90,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_357", "Sprites/OBJECTS_357", "Sprites/OBJECTS_357", 84, 357, 804, 40, 0, 0, 1, 0, 1, 1, 0, 0, 1);
		AddGrave(myObj, 28,8);
		
		myObj= CreateGameObject("special_tmap_obj_30_37_06_0545",36.514286f,3.600000f,45.428570f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 27, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_158", "" , 158, false);
		SetRotation(myObj,0,0,0);
		
		
		myObj= CreateGameObject("special_tmap_obj_32_37_06_0549",39.085716f,3.600000f,45.428570f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 27, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_158", "" , 158, false);
		SetRotation(myObj,0,0,0);
		
		
		myObj= CreateGameObject("a_blood_stain_35_37_06_0489",43.200001f,1.200000f,44.400002f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_222",true);
		
		myObj = new GameObject("an_imp_35_37_06_0183");
		pos = new Vector3(42.514286f, 1.800000f, 44.914288f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"75","Sprites/OBJECTS_075", 221);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_075", "Sprites/OBJECTS_075", "Sprites/OBJECTS_075", 0, 75, 0, 35, 37, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 221, 35, 37, 0, 0, 11, 0, 0, 10, 2, 0, 0, 0, 0, "GroundMesh13");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_gold_coin_37_37_06_0480",45.257145f,1.200000f,45.085712f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_161",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", 18, 161, 1, 40, 20, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_gold_chain_37_37_06_0482",45.428570f,1.200000f,44.571430f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_171",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_171", "Sprites/OBJECTS_171", "Sprites/OBJECTS_171", 18, 171, 439, 40, 20, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		AddPickupLink(myObj, "a_pick_up_trigger_99_99_06_0439");
		
		myObj= CreateGameObject("a_coin_38_37_06_0450",46.628571f,1.200000f,45.428570f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_160",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_160", "Sprites/OBJECTS_160", "Sprites/OBJECTS_160", 18, 160, 1, 40, 20, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_jeweled_shield_38_37_06_0452",46.114288f,1.200000f,44.914288f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_063",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_063", "Sprites/OBJECTS_063", "Sprites/OBJECTS_063", 78, 63, 662, 40, 20, 1, 1, 0, 1, 1, 1, 8, 1);
		AddShield(myObj);
		
		myObj= CreateGameObject("a_red_gem_38_37_06_0453",46.114288f,1.200000f,44.571430f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_163",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_163", "Sprites/OBJECTS_163", "Sprites/OBJECTS_163", 18, 163, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_gold_coin_38_37_06_0460",46.285713f,1.200000f,45.428570f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_161",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", 18, 161, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_crown_38_37_06_0478",46.457142f,1.200000f,45.085712f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_048",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_048", "Sprites/OBJECTS_048", "Sprites/armour/armor_f_0061", 73, 48, 661, 40, 0, 1, 1, 0, 1, 1, 1, 8, 1);
		CreateHelm(myObj, "Sprites/armour/armor_f_0061", "Sprites/armour/armor_m_0061", "Sprites/armour/armor_f_0061", "Sprites/armour/armor_m_0061", "Sprites/armour/armor_f_0061", "Sprites/armour/armor_m_0061", "Sprites/armour/armor_f_0061", "Sprites/armour/armor_m_0061", 6099796, 6216360);
		
		myObj= CreateGameObject("a_crown_38_37_06_0481",45.771431f,1.200000f,44.571430f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_049",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_049", "Sprites/OBJECTS_049", "Sprites/armour/armor_f_0062", 73, 49, 661, 40, 0, 1, 1, 0, 1, 1, 1, 8, 1);
		CreateHelm(myObj, "Sprites/armour/armor_f_0062", "Sprites/armour/armor_m_0062", "Sprites/armour/armor_f_0062", "Sprites/armour/armor_m_0062", "Sprites/armour/armor_f_0062", "Sprites/armour/armor_m_0062", "Sprites/armour/armor_f_0062", "Sprites/armour/armor_m_0062", 6099796, 6217068);
		
		myObj= CreateGameObject("a_gold_coin_38_37_06_0485",46.628571f,1.200000f,44.571430f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_161",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", 18, 161, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		
		
		
		
		myObj= CreateGameObject("a_gravestone_30_38_06_0543",36.342857f,3.600000f,46.114288f);
		SetRotation(myObj,0,90,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_357", "Sprites/OBJECTS_357", "Sprites/OBJECTS_357", 84, 357, 796, 40, 0, 0, 1, 0, 1, 1, 0, 0, 1);
		AddGrave(myObj, 28,11);
		
		myObj= CreateGameObject("special_tmap_obj_30_38_06_0546",36.599998f,3.600000f,45.609997f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 27, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_158", "" , 158, false);
		SetRotation(myObj,0,180,0);
		
		myObj= CreateGameObject("special_tmap_obj_30_38_06_0547",36.514286f,3.600000f,46.628571f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 27, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_158", "" , 158, false);
		SetRotation(myObj,0,0,0);
		
		
		myObj= CreateGameObject("a_gravestone_32_38_06_0540",39.257145f,3.600000f,46.114288f);
		SetRotation(myObj,0,90,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_357", "Sprites/OBJECTS_357", "Sprites/OBJECTS_357", 84, 357, 802, 40, 0, 0, 1, 0, 1, 1, 0, 0, 1);
		AddGrave(myObj, 28,15);
		
		myObj= CreateGameObject("special_tmap_obj_32_38_06_0550",39.085716f,3.600000f,46.628571f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 27, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_158", "" , 158, false);
		SetRotation(myObj,0,0,0);
		
		myObj= CreateGameObject("special_tmap_obj_32_38_06_0551",39.000000f,3.600000f,45.609997f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 27, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_158", "" , 158, false);
		SetRotation(myObj,0,180,0);
		
		
		myObj = new GameObject("an_earth_golem_36_38_06_0206");
		pos = new Vector3(44.228569f, 1.200000f, 46.285713f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"114","Sprites/OBJECTS_114", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_114", "Sprites/OBJECTS_114", "Sprites/OBJECTS_114", 0, 114, 0, 36, 38, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 36, 38, 0, 0, 70, 0, 0, 7, 2, 0, 0, 0, 0, "GroundMesh13");
		SetRotation(myObj,0,180,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_gold_coin_37_38_06_0463",45.599998f,1.200000f,45.771431f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_161",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", 18, 161, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_crown_37_38_06_0438",45.085712f,1.200000f,46.285713f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_048",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_048", "Sprites/OBJECTS_048", "Sprites/armour/armor_f_0061", 73, 48, 661, 40, 0, 1, 1, 0, 1, 1, 1, 8, 1);
		CreateHelm(myObj, "Sprites/armour/armor_f_0061", "Sprites/armour/armor_m_0061", "Sprites/armour/armor_f_0061", "Sprites/armour/armor_m_0061", "Sprites/armour/armor_f_0061", "Sprites/armour/armor_m_0061", "Sprites/armour/armor_f_0061", "Sprites/armour/armor_m_0061", 6099796, 6206920);
		
		myObj= CreateGameObject("a_small_blue_gem_38_38_06_0455",45.771431f,1.200000f,46.114288f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_164",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_164", "Sprites/OBJECTS_164", "Sprites/OBJECTS_164", 18, 164, 444, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		AddPickupLink(myObj, "a_pick_up_trigger_99_99_06_0444");
		
		myObj= CreateGameObject("a_coin_38_38_06_0456",46.628571f,1.200000f,46.628571f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_160",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_160", "Sprites/OBJECTS_160", "Sprites/OBJECTS_160", 18, 160, 1, 40, 20, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_gold_plate_38_38_06_0458",46.628571f,1.200000f,45.942856f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_172",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_172", "Sprites/OBJECTS_172", "Sprites/OBJECTS_172", 18, 172, 443, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		AddPickupLink(myObj, "a_pick_up_trigger_99_99_06_0443");
		
		myObj= CreateGameObject("a_goblet_38_38_06_0459",46.114288f,1.200000f,46.114288f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_169",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_169", "Sprites/OBJECTS_169", "Sprites/OBJECTS_169", 18, 169, 442, 40, 20, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		AddPickupLink(myObj, "a_pick_up_trigger_99_99_06_0442");
		
		myObj= CreateGameObject("a_gold_coin_38_38_06_0461",46.114288f,1.200000f,46.457142f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_161",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", 18, 161, 1, 40, 20, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_pile_of_bones_piles_of_bones_04_39_06_0744",5.485714f,3.000000f,47.142857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_198",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_198", "Sprites/OBJECTS_198", "Sprites/OBJECTS_198", 23, 198, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_skull_04_39_06_0745",5.657143f,3.000000f,47.485714f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_194",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_194", "Sprites/OBJECTS_194", "Sprites/OBJECTS_194", 23, 194, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		
		myObj= CreateGameObject("a_gravestone_30_39_06_0544",36.342857f,3.600000f,47.485714f);
		SetRotation(myObj,0,270,0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_357", "Sprites/OBJECTS_357", "Sprites/OBJECTS_357", 84, 357, 797, 40, 0, 0, 1, 0, 1, 1, 0, 0, 1);
		AddGrave(myObj, 28,10);
		
		myObj= CreateGameObject("special_tmap_obj_30_39_06_0548",36.599998f,3.600000f,46.809998f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 27, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_158", "" , 158, false);
		SetRotation(myObj,0,180,0);
		
		myObj= CreateGameObject("special_tmap_obj_32_39_06_0552",39.000000f,3.600000f,46.809998f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 27, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_158", "" , 158, false);
		SetRotation(myObj,0,180,0);
		
		myObj = new GameObject("door_032_039");
		pos = new Vector3(39.599998f, 3.600000f, 47.000000f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_327", "Sprites/OBJECTS_327", "Sprites/OBJECTS_327", 29, 327, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"materials/tmap/uw1_154", 53, 0, 0);
		SetRotation(myObj,-90,90,0);
		
		
		
		
		
		
		
		myObj= CreateGameObject("special_tmap_obj_26_40_06_0920",31.799999f,3.600000f,49.190002f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 914, 40, 4, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,"uw1_154", "a_look_trigger_99_99_06_0914", 154, false);
		SetRotation(myObj,0,0,0);
		
		myObj = new GameObject("door_031_040");
		pos = new Vector3(38.200001f, 3.600000f, 48.685715f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_321", "Sprites/OBJECTS_321", "Sprites/OBJECTS_321", 4, 321, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_12_material", 53, 0, 0);
		SetRotation(myObj,-90,0,0);
		
		
		
		myObj= CreateGameObject("special_tmap_obj_35_40_06_0974",42.599998f,1.500000f,49.190002f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 45, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_141", "" , 141, false);
		SetRotation(myObj,0,0,0);
		
		
		myObj = new GameObject("a_fire_elemental_47_40_06_0212");
		pos = new Vector3(56.914288f, 0.000000f, 48.514286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"120","Sprites/OBJECTS_120", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_120", "Sprites/OBJECTS_120", "Sprites/OBJECTS_120", 0, 120, 0, 47, 40, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 47, 40, 0, 0, 59, 0, 0, 4, 0, 0, 0, 0, 0, "LavaMesh3");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("a_fire_elemental_51_40_06_0213");
		pos = new Vector3(61.714287f, 0.000000f, 48.514286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"120","Sprites/OBJECTS_120", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_120", "Sprites/OBJECTS_120", "Sprites/OBJECTS_120", 0, 120, 0, 51, 40, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 51, 40, 0, 0, 74, 0, 0, 4, 0, 0, 0, 0, 0, "LavaMesh3");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		
		
		
		
		myObj= CreateGameObject("an_apple_19_41_06_0843",23.314285f,3.600000f,49.714287f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_179",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_179", "Sprites/OBJECTS_179", "Sprites/OBJECTS_179", 24, 179, 829, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		SetFood(myObj);
		
		
		
		
		
		myObj = new GameObject("door_026_041");
		pos = new Vector3(31.400000f, 3.600000f, 49.200001f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_327", "Sprites/OBJECTS_327", "Sprites/OBJECTS_327", 29, 327, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"materials/tmap/uw1_154", 53, 0, 0);
		SetRotation(myObj,-90,-180,0);
		
		
		myObj = new GameObject("a_fire_elemental_42_41_06_0228");
		pos = new Vector3(50.914288f, 0.000000f, 49.714287f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"120","Sprites/OBJECTS_120", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_120", "Sprites/OBJECTS_120", "Sprites/OBJECTS_120", 0, 120, 0, 42, 41, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 42, 41, 0, 0, 50, 0, 0, 4, 0, 0, 0, 0, 0, "LavaMesh3");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("a_fire_elemental_56_41_06_0209");
		pos = new Vector3(67.714287f, 0.000000f, 49.714287f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"120","Sprites/OBJECTS_120", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_120", "Sprites/OBJECTS_120", "Sprites/OBJECTS_120", 0, 120, 0, 56, 41, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 56, 41, 0, 0, 64, 0, 0, 4, 0, 0, 0, 0, 0, "LavaMesh3");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		
		
		
		myObj= CreateGameObject("a_skull_32_42_06_0467",39.257145f,3.000000f,51.257145f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_194",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_194", "Sprites/OBJECTS_194", "Sprites/OBJECTS_194", 23, 194, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		
		myObj= CreateGameObject("a_black_sword_34_42_06_0477",41.828568f,3.000000f,50.571430f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_012",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_012", "Sprites/OBJECTS_012", "Sprites/OBJECTS_012", 1, 12, 708, 40, 0, 1, 1, 0, 1, 1, 1, 8, 1);
		CreateWeapon(myObj, 15, 7, 12, 3, 255);
		
		
		myObj = new GameObject("door_041_042");
		pos = new Vector3(49.400002f, 3.600000f, 50.742855f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_323", "Sprites/OBJECTS_323", "Sprites/OBJECTS_323", 4, 323, 861, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_06_material", 0, 1, 0);
		SetRotation(myObj,-90,-180,0);
		
		myObj= CreateGameObject("a_small_blue_gem_02_43_06_0756",2.742857f,3.000000f,52.285713f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_164",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_164", "Sprites/OBJECTS_164", "Sprites/OBJECTS_164", 18, 164, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		
		
		
		
		
		
		
		
		
		myObj= CreateGameObject("a_gold_coin_32_43_06_0370",38.571426f,3.000000f,52.628571f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_161",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", 18, 161, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_gold_coin_32_43_06_0371",38.914284f,3.000000f,52.114288f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_161",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", 18, 161, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_broken_axe_32_43_06_0468",39.257145f,3.000000f,52.628571f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_200",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_200", "Sprites/OBJECTS_200", "Sprites/OBJECTS_200", 23, 200, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_bone_34_43_06_0369",41.314285f,3.000000f,52.114288f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_197",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_197", "Sprites/OBJECTS_197", "Sprites/OBJECTS_197", 23, 197, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj = new GameObject("a_fire_elemental_38_43_06_0254");
		pos = new Vector3(46.114288f, 0.000000f, 52.114288f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"120","Sprites/OBJECTS_120", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_120", "Sprites/OBJECTS_120", "Sprites/OBJECTS_120", 0, 120, 0, 38, 43, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 38, 43, 0, 0, 54, 0, 0, 4, 0, 0, 0, 0, 0, "LavaMesh3");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		
		myObj = new GameObject("a_fire_elemental_60_43_06_0236");
		pos = new Vector3(72.514290f, 0.000000f, 52.114288f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"120","Sprites/OBJECTS_120", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_120", "Sprites/OBJECTS_120", "Sprites/OBJECTS_120", 0, 120, 0, 60, 43, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 60, 43, 0, 0, 67, 0, 0, 2, 0, 0, 0, 0, 0, "LavaMesh3");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_gold_chain_32_44_06_0372",39.428574f,3.000000f,53.657143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_171",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_171", "Sprites/OBJECTS_171", "Sprites/OBJECTS_171", 18, 171, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_tower_shield_32_44_06_0471",38.400002f,3.000000f,53.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_059",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_059", "Sprites/OBJECTS_059", "Sprites/OBJECTS_059", 78, 59, 565, 32, 0, 1, 1, 0, 1, 1, 1, 8, 1);
		AddShield(myObj);
		
		myObj= CreateGameObject("a_helmet_32_44_06_0474",38.914284f,3.000000f,53.828568f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_046",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_046", "Sprites/OBJECTS_046", "Sprites/armour/armor_f_0014", 73, 46, 516, 63, 0, 1, 1, 0, 1, 1, 1, 8, 1);
		CreateHelm(myObj, "Sprites/armour/armor_f_0014", "Sprites/armour/armor_m_0014", "Sprites/armour/armor_f_0029", "Sprites/armour/armor_m_0029", "Sprites/armour/armor_f_0044", "Sprites/armour/armor_m_0044", "Sprites/armour/armor_f_0059", "Sprites/armour/armor_m_0059", 6099796, 6215416);
		
		myObj= CreateGameObject("plate_leggings_pairs_of_plate_leggings_32_44_06_0475",38.571426f,3.000000f,53.828568f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_037",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_037", "Sprites/OBJECTS_037", "Sprites/armour/armor_f_0005", 77, 37, 0, 57, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		CreateLeggings(myObj, "Sprites/armour/armor_f_0005", "Sprites/armour/armor_m_0005", "Sprites/armour/armor_f_0020", "Sprites/armour/armor_m_0020", "Sprites/armour/armor_f_0035", "Sprites/armour/armor_m_0035", "Sprites/armour/armor_f_0050", "Sprites/armour/armor_m_0050", 6, 20);
		
		myObj= CreateGameObject("a_wand_33_44_06_0374",39.771427f,3.000000f,54.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_154",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_154", "Sprites/OBJECTS_154", "Sprites/OBJECTS_154", 12, 154, 373, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddWand(myObj, 536, 8);
		
		myObj= CreateGameObject("a_small_shield_33_44_06_0377",39.771427f,3.000000f,53.828568f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_061",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_061", "Sprites/OBJECTS_061", "Sprites/OBJECTS_061", 78, 61, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddShield(myObj);
		
		myObj= CreateGameObject("a_skull_33_44_06_0466",40.628571f,3.000000f,53.828568f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_195",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_195", "Sprites/OBJECTS_195", "Sprites/OBJECTS_195", 23, 195, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_broken_sword_33_44_06_0469",39.771427f,3.000000f,53.485714f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_201",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_201", "Sprites/OBJECTS_201", "Sprites/OBJECTS_201", 23, 201, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_quiver_34_44_06_0376",40.971432f,3.000000f,53.657143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_141",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_141", "Sprites/OBJECTS_141", "Sprites/OBJECTS_141", 19, 141, 375, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		////Container contents
		ParentContainer = CreateContainer(myObj, 0, 2, 1);
		AddObjectToContainer("an_arrow_99_99_06_0375", ParentContainer, 0);
		////Container contents complete
		
		
		myObj= CreateGameObject("a_silver_ring_44_44_06_0683",52.971432f,3.600000f,53.142857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_057",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_057", "Sprites/OBJECTS_057", "Sprites/OBJECTS_057", 74, 57, 531, 40, 0, 1, 1, 0, 1, 1, 1, 8, 1);
		AddRing(myObj);
		
		myObj = new GameObject("a_dire_ghost_50_44_06_0191");
		pos = new Vector3(60.514286f, 2.550000f, 53.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"113","Sprites/OBJECTS_113", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_113", "Sprites/OBJECTS_113", "Sprites/OBJECTS_113", 0, 113, 0, 50, 44, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 50, 44, 0, 0, 115, 0, 0, 4, 0, 0, 0, 0, 0, "GroundMesh6");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_key_19_45_06_0904",23.485716f,2.400000f,54.171432f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_266",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_266", "Sprites/OBJECTS_266", "Sprites/OBJECTS_266", 5, 266, 1, 40, 25, 1, 1, 0, 1, 1, 0, 0, 1);
		CreateKey(myObj, 25);
		
		myObj = new GameObject("a_fire_elemental_35_45_06_0205");
		pos = new Vector3(42.514286f, 0.000000f, 54.514286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"120","Sprites/OBJECTS_120", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_120", "Sprites/OBJECTS_120", "Sprites/OBJECTS_120", 0, 120, 0, 35, 45, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 35, 45, 0, 0, 42, 0, 0, 4, 0, 0, 0, 0, 0, "LavaMesh3");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_skull_18_46_06_0915",22.457144f,2.400000f,56.228569f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_195",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_195", "Sprites/OBJECTS_195", "Sprites/OBJECTS_195", 23, 195, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_pile_of_bones_piles_of_bones_20_46_06_0916",24.342857f,2.400000f,55.542858f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_198",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_198", "Sprites/OBJECTS_198", "Sprites/OBJECTS_198", 23, 198, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj = new GameObject("a_mage_13_47_06_0227");
		pos = new Vector3(16.285713f, 3.600000f, 56.914288f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"108","Sprites/OBJECTS_108", 210);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_108", "Sprites/OBJECTS_108", "Sprites/OBJECTS_108", 0, 108, 0, 13, 47, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 210, 13, 47, 0, 0, 56, 0, 0, 7, 2, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,270,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("a_dread_spider_18_48_06_0243");
		pos = new Vector3(21.942856f, 2.400000f, 58.114288f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"92","Sprites/OBJECTS_092", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_092", "Sprites/OBJECTS_092", "Sprites/OBJECTS_092", 0, 92, 0, 19, 45, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 18, 48, 0, 0, 44, 0, 0, 4, 0, 1, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,180,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		
		
		myObj = new GameObject("a_fire_elemental_33_49_06_0177");
		pos = new Vector3(40.114285f, 0.000000f, 59.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"120","Sprites/OBJECTS_120", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_120", "Sprites/OBJECTS_120", "Sprites/OBJECTS_120", 0, 120, 0, 33, 49, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 33, 49, 0, 0, 52, 0, 0, 4, 0, 0, 0, 0, 0, "LavaMesh3");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("door_036_049");
		pos = new Vector3(43.400002f, 3.000000f, 59.142857f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_324", "Sprites/OBJECTS_324", "Sprites/OBJECTS_324", 4, 324, 783, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_05_material", 25, 1, 0);
		SetRotation(myObj,-90,-180,0);
		
		myObj= CreateGameObject("special_tmap_obj_38_49_06_0963",46.200001f,0.000000f,58.809998f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 45, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_141", "" , 141, false);
		SetRotation(myObj,0,180,0);
		
		
		
		myObj = new GameObject("a_dire_ghost_40_50_06_0184");
		pos = new Vector3(48.514286f, 2.850000f, 60.514286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"113","Sprites/OBJECTS_113", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_113", "Sprites/OBJECTS_113", "Sprites/OBJECTS_113", 0, 113, 0, 40, 50, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 40, 50, 0, 0, 138, 0, 0, 4, 0, 0, 0, 0, 0, "GroundMesh6");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("a_mountainman_mountainmen_10_51_06_0244");
		pos = new Vector3(12.514286f, 3.300000f, 61.714287f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"86","Sprites/OBJECTS_086", 212);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_086", "Sprites/OBJECTS_086", "Sprites/OBJECTS_086", 0, 86, 903, 10, 51, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 212, 10, 51, 0, 0, 52, 0, 0, 7, 2, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,270,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		////NPC container with items
		
		AddObjectToContainer("a_crystal_splinter_99_99_06_0903", ParentContainer, 0);
		////Container contents complete
		
		
		myObj = new GameObject("door_027_051");
		pos = new Vector3(32.400002f, 3.300000f, 62.200001f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_327", "Sprites/OBJECTS_327", "Sprites/OBJECTS_327", 29, 327, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"materials/tmap/uw1_001", 53, 0, 0);
		SetRotation(myObj,-90,-90,0);
		
		myObj = new GameObject("a_mage_01_52_06_0173");
		pos = new Vector3(1.714286f, 3.300000f, 62.914288f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"109","Sprites/OBJECTS_109", 217);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_109", "Sprites/OBJECTS_109", "Sprites/OBJECTS_109", 0, 109, 0, 1, 52, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 217, 1, 52, 0, 0, 49, 0, 0, 7, 2, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("door_009_052");
		pos = new Vector3(11.000000f, 3.300000f, 62.914288f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_320", "Sprites/OBJECTS_320", "Sprites/OBJECTS_320", 4, 320, 600, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_03_material", 23, 1, 0);
		SetRotation(myObj,-90,-180,0);
		
		
		myObj = new GameObject("door_002_053");
		pos = new Vector3(2.914286f, 3.300000f, 64.599998f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_325", "Sprites/OBJECTS_325", "Sprites/OBJECTS_325", 4, 325, 786, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_11_material", 27, 1, 0);
		SetRotation(myObj,-90,-90,0);
		
		myObj= CreateGameObject("a_blood_stain_12_53_06_0617",14.914286f,3.300000f,63.771431f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_221",true);
		
		myObj = new GameObject("an_outcast_12_53_06_0246");
		pos = new Vector3(14.914286f, 3.300000f, 64.114288f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"90","Sprites/OBJECTS_090", 218);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_090", "Sprites/OBJECTS_090", "Sprites/OBJECTS_090", 0, 90, 0, 12, 53, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 218, 12, 53, 0, 0, 16, 0, 0, 7, 2, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,90,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_scroll_16_53_06_0833",19.542858f,3.300000f,63.942856f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_319",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_319", "Sprites/OBJECTS_319", "Sprites/OBJECTS_319", 11, 319, 713, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetReadable(myObj);
		SetLink(myObj,713);
		
		myObj= CreateGameObject("a_piece_of_wood_pieces_of_wood_16_53_06_0622",20.228571f,3.300000f,63.771431f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_205",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_205", "Sprites/OBJECTS_205", "Sprites/OBJECTS_205", 23, 205, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_skull_16_53_06_0625",20.057142f,3.300000f,64.457146f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_194",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_194", "Sprites/OBJECTS_194", "Sprites/OBJECTS_194", 23, 194, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("special_tmap_obj_26_53_06_0419",31.799999f,3.300000f,64.790001f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 25, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_005", "" , 5, false);
		SetRotation(myObj,0,0,0);
		
		myObj= CreateGameObject("special_tmap_obj_28_53_06_0647",34.790001f,3.300000f,64.199997f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 25, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_005", "" , 5, false);
		SetRotation(myObj,0,90,0);
		
		myObj = new GameObject("a_fire_elemental_34_53_06_0178");
		pos = new Vector3(41.314285f, 0.000000f, 64.114288f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"120","Sprites/OBJECTS_120", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_120", "Sprites/OBJECTS_120", "Sprites/OBJECTS_120", 0, 120, 0, 34, 53, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 34, 53, 0, 0, 56, 0, 0, 4, 0, 0, 0, 0, 0, "LavaMesh3");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("door_035_053");
		pos = new Vector3(42.514286f, 0.000000f, 63.799999f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_324", "Sprites/OBJECTS_324", "Sprites/OBJECTS_324", 4, 324, 784, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_05_material", 25, 1, 0);
		SetRotation(myObj,-90,90,0);
		
		myObj= CreateGameObject("special_tmap_obj_46_53_06_0984",55.799999f,3.000000f,63.609997f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 40, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_161", "" , 161, false);
		SetRotation(myObj,0,180,0);
		
		
		
		myObj= CreateGameObject("special_tmap_obj_58_53_06_0956",70.199997f,3.600000f,63.609997f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 45, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_141", "" , 141, false);
		SetRotation(myObj,0,180,0);
		
		myObj= CreateGameObject("a_skull_60_53_06_0681",72.171432f,3.300000f,63.942856f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_195",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_195", "Sprites/OBJECTS_195", "Sprites/OBJECTS_195", 23, 195, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj = new GameObject("door_003_054");
		pos = new Vector3(4.600000f, 3.300000f, 65.485710f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_325", "Sprites/OBJECTS_325", "Sprites/OBJECTS_325", 4, 325, 875, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_11_material", 27, 1, 0);
		SetRotation(myObj,-90,0,0);
		
		myObj = new GameObject("door_005_054");
		pos = new Vector3(7.000000f, 3.300000f, 65.485710f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_325", "Sprites/OBJECTS_325", "Sprites/OBJECTS_325", 4, 325, 874, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_11_material", 27, 1, 0);
		SetRotation(myObj,-90,0,0);
		
		myObj = new GameObject("door_013_054");
		pos = new Vector3(15.800000f, 3.300000f, 65.314285f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_320", "Sprites/OBJECTS_320", "Sprites/OBJECTS_320", 4, 320, 613, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_03_material", 23, 1, 0);
		SetRotation(myObj,-90,-180,0);
		
		myObj = new GameObject("door_015_054");
		pos = new Vector3(18.200001f, 3.300000f, 65.314285f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_320", "Sprites/OBJECTS_320", "Sprites/OBJECTS_320", 4, 320, 626, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_03_material", 23, 1, 0);
		SetRotation(myObj,-90,-180,0);
		
		myObj= CreateGameObject("a_blood_stain_20_54_06_0640",24.514284f,3.300000f,65.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_222",true);
		
		myObj= CreateGameObject("some_writing_20_54_06_0648",25.200001f,3.900000f,65.485710f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_358",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_358", "Sprites/OBJECTS_358", "Sprites/OBJECTS_358", 10, 358, 794, 40, 0, 0, 1, 0, 0, 1, 1, 12, 1);
		SetReadable(myObj);
		SetRotation(myObj,0,90,0);
		SetSprite(myObj, "Sprites/tmobj/tmobj_24");
		SetLink(myObj,794);
		
		myObj = new GameObject("door_027_054");
		pos = new Vector3(32.599998f, 3.300000f, 65.314285f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_326", "Sprites/OBJECTS_326", "Sprites/OBJECTS_326", 30, 326, 659, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreatePortcullis(myObj, 23, 1, 0);
		SetRotation(myObj,-90,-180,0);
		
		
		myObj= CreateGameObject("a_shrine_40_54_06_0906",48.514286f,3.300000f,65.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_343",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_343", "Sprites/OBJECTS_343", "Sprites/OBJECTS_343", 83, 343, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		AddShrine(myObj);
		
		
		
		myObj = new GameObject("door_052_054");
		pos = new Vector3(63.257145f, 3.000000f, 65.000000f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_323", "Sprites/OBJECTS_323", "Sprites/OBJECTS_323", 4, 323, 817, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_06_material", 0, 1, 0);
		SetRotation(myObj,-90,90,0);
		
		myObj= CreateGameObject("some_writing_52_54_06_1003",63.257145f,4.050000f,65.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_358",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_358", "Sprites/OBJECTS_358", "Sprites/OBJECTS_358", 10, 358, 792, 40, 0, 0, 1, 0, 0, 1, 0, 0, 1);
		SetReadable(myObj);
		SetRotation(myObj,0,270,0);
		SetSprite(myObj, "Sprites/tmobj/tmobj_20");
		SetLink(myObj,792);
		
		myObj= CreateGameObject("a_key_54_54_06_0765",65.828568f,3.000000f,64.971428f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_261",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_261", "Sprites/OBJECTS_261", "Sprites/OBJECTS_261", 5, 261, 1, 40, 24, 1, 1, 0, 1, 1, 0, 0, 1);
		CreateKey(myObj, 24);
		
		myObj= CreateGameObject("a_scroll_54_54_06_0814",65.485710f,3.000000f,64.971428f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_318",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_318", "Sprites/OBJECTS_318", "Sprites/OBJECTS_318", 11, 318, 705, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetReadable(myObj);
		SetLink(myObj,705);
		
		myObj= CreateGameObject("a_skull_54_54_06_0816",65.828568f,3.000000f,64.971428f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_194",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_194", "Sprites/OBJECTS_194", "Sprites/OBJECTS_194", 23, 194, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj = new GameObject("a_mountainman_mountainmen_02_55_06_0241");
		pos = new Vector3(2.914286f, 3.300000f, 66.514290f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"86","Sprites/OBJECTS_086", 215);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_086", "Sprites/OBJECTS_086", "Sprites/OBJECTS_086", 0, 86, 890, 2, 55, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 215, 2, 55, 0, 0, 49, 0, 0, 7, 2, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,90,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		////NPC container with items
		
		AddObjectToContainer("a_key_99_99_06_0890", ParentContainer, 0);
		////Container contents complete
		
		
		myObj= CreateGameObject("a_bone_06_55_06_0599",8.228571f,3.300000f,67.028572f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_197",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_197", "Sprites/OBJECTS_197", "Sprites/OBJECTS_197", 23, 197, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj = new GameObject("a_fighter_06_55_06_0245");
		pos = new Vector3(7.714286f, 3.300000f, 66.514290f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"104","Sprites/OBJECTS_104", 214);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_104", "Sprites/OBJECTS_104", "Sprites/OBJECTS_104", 0, 104, 892, 6, 55, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 214, 6, 55, 0, 0, 50, 0, 0, 7, 2, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,270,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		////NPC container with items
		
		AddObjectToContainer("a_picture_of_Tom_99_99_06_0892", ParentContainer, 0);
		////Container contents complete
		
		
		myObj = new GameObject("door_019_055");
		pos = new Vector3(23.000000f, 3.300000f, 66.514290f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_328", "Sprites/OBJECTS_328", "Sprites/OBJECTS_328", 4, 328, 0, 40, 0, 0, 1, 0, 1, 0, 1, 13, 1);
		CreateDoor(myObj,"textures/doors/doors_03_material", 53, 0, 1);
		SetRotation(myObj,-90,-90,0);
		
		
		
		myObj = new GameObject("a_goblin_25_55_06_0247");
		pos = new Vector3(30.857143f, 3.300000f, 66.685715f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"78","Sprites/OBJECTS_078", 220);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_078", "Sprites/OBJECTS_078", "Sprites/OBJECTS_078", 0, 78, 0, 25, 55, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 220, 25, 55, 0, 0, 88, 0, 0, 7, 1, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,45,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		
		myObj = new GameObject("a_goblin_27_55_06_0197");
		pos = new Vector3(33.085716f, 3.300000f, 66.857147f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"78","Sprites/OBJECTS_078", 220);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_078", "Sprites/OBJECTS_078", "Sprites/OBJECTS_078", 0, 78, 0, 27, 55, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 220, 27, 55, 0, 0, 80, 0, 0, 7, 1, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,180,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_loaf_of_bread_loaves_of_bread_28_55_06_0652",34.114285f,3.300000f,67.028572f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_181",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_181", "Sprites/OBJECTS_181", "Sprites/OBJECTS_181", 24, 181, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetFood(myObj);
		
		myObj= CreateGameObject("a_campfire_28_55_06_0757",34.285717f,3.300000f,66.514290f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_298",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_298", "Sprites/OBJECTS_298", "Sprites/OBJECTS_298", 16, 298, 1, 40, 0, 0, 0, 1, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		
		myObj = new GameObject("door_060_055");
		pos = new Vector3(72.199997f, 3.600000f, 67.199997f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_327", "Sprites/OBJECTS_327", "Sprites/OBJECTS_327", 29, 327, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"materials/tmap/uw1_168", 53, 0, 0);
		SetRotation(myObj,-90,-180,0);
		
		
		
		myObj = new GameObject("door_008_056");
		pos = new Vector3(10.600000f, 3.600000f, 67.885712f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_320", "Sprites/OBJECTS_320", "Sprites/OBJECTS_320", 4, 320, 605, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_03_material", 23, 1, 0);
		SetRotation(myObj,-90,0,0);
		
		myObj = new GameObject("door_013_056");
		pos = new Vector3(16.600000f, 3.300000f, 67.885712f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_328", "Sprites/OBJECTS_328", "Sprites/OBJECTS_328", 4, 328, 0, 40, 0, 0, 1, 0, 1, 0, 1, 13, 1);
		CreateDoor(myObj,"textures/doors/doors_03_material", 53, 0, 1);
		SetRotation(myObj,-90,90,0);
		
		myObj = new GameObject("door_015_056");
		pos = new Vector3(19.000000f, 3.300000f, 67.885712f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_328", "Sprites/OBJECTS_328", "Sprites/OBJECTS_328", 4, 328, 0, 40, 0, 0, 1, 0, 1, 0, 1, 13, 1);
		CreateDoor(myObj,"textures/doors/doors_03_material", 53, 0, 1);
		SetRotation(myObj,-90,90,0);
		
		myObj = new GameObject("door_021_056");
		pos = new Vector3(26.228571f, 3.300000f, 67.400002f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_326", "Sprites/OBJECTS_326", "Sprites/OBJECTS_326", 30, 326, 777, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreatePortcullis(myObj, 23, 1, 0);
		SetRotation(myObj,-90,90,0);
		
		
		
		myObj = new GameObject("door_024_056");
		pos = new Vector3(29.314285f, 4.200000f, 67.400002f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_334", "Sprites/OBJECTS_334", "Sprites/OBJECTS_334", 30, 334, 818, 40, 0, 0, 1, 0, 1, 0, 1, 12, 1);
		CreatePortcullis(myObj, 23, 1, 1);
		SetRotation(myObj,-90,90,0);
		
		myObj = new GameObject("a_feral_troll_26_56_06_0251");
		pos = new Vector3(31.885715f, 3.300000f, 67.885712f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"111","Sprites/OBJECTS_111", 216);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_111", "Sprites/OBJECTS_111", "Sprites/OBJECTS_111", 0, 111, 651, 26, 56, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 216, 26, 56, 0, 0, 94, 0, 0, 7, 1, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,270,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		////NPC container with items
		
		AddObjectToContainer("a_key_99_99_06_0651", ParentContainer, 0);
		////Container contents complete
		
		
		myObj = new GameObject("door_031_056");
		pos = new Vector3(38.200001f, 3.600000f, 68.400002f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_327", "Sprites/OBJECTS_327", "Sprites/OBJECTS_327", 29, 327, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"materials/tmap/uw1_001", 53, 0, 0);
		SetRotation(myObj,-90,0,0);
		
		
		myObj= CreateGameObject("special_tmap_obj_52_56_06_0975",63.000000f,2.400000f,67.209999f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 40, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_161", "" , 161, false);
		SetRotation(myObj,0,180,0);
		
		myObj= CreateGameObject("special_tmap_obj_60_56_06_0948",72.599998f,3.600000f,67.209999f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 873, 40, 11, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,"uw1_168", "a_look_trigger_99_99_06_0873", 168, false);
		SetRotation(myObj,0,180,0);
		
		myObj= CreateGameObject("a_bone_07_57_06_0609",8.742857f,3.600000f,68.742859f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_197",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_197", "Sprites/OBJECTS_197", "Sprites/OBJECTS_197", 23, 197, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj = new GameObject("a_fighter_07_57_06_0242");
		pos = new Vector3(8.914286f, 3.600000f, 68.914284f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"98","Sprites/OBJECTS_098", 211);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_098", "Sprites/OBJECTS_098", "Sprites/OBJECTS_098", 0, 98, 0, 7, 57, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 211, 7, 57, 0, 0, 28, 0, 0, 7, 2, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,90,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("special_tmap_obj_08_57_06_0935",10.200000f,3.600000f,69.589996f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 933, 40, 1, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,"uw1_126", "a_look_trigger_99_99_06_0933", 126, false);
		SetRotation(myObj,0,0,0);
		
		myObj= CreateGameObject("a_boulder_08_57_06_0606",10.457142f,3.600000f,69.085716f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_341",true);
		
		myObj= CreateGameObject("a_small_boulder_08_57_06_0607",9.771429f,3.600000f,69.257141f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_342",true);
		
		myObj= CreateGameObject("a_small_boulder_08_57_06_0608",10.114285f,3.600000f,69.085716f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_342",true);
		
		myObj= CreateGameObject("some_writing_12_57_06_0618",14.400000f,3.900000f,68.914284f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_358",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_358", "Sprites/OBJECTS_358", "Sprites/OBJECTS_358", 10, 358, 795, 40, 0, 0, 1, 0, 0, 1, 1, 13, 1);
		SetReadable(myObj);
		SetRotation(myObj,0,270,0);
		SetSprite(myObj, "Sprites/tmobj/tmobj_25");
		SetLink(myObj,795);
		
		myObj= CreateGameObject("a_blood_stain_13_57_06_0620",16.285713f,3.300000f,68.742859f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_222",true);
		
		myObj= CreateGameObject("a_blood_stain_16_57_06_0629",20.057142f,3.300000f,69.428566f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_222",true);
		
		myObj= CreateGameObject("some_writing_16_57_06_0632",20.400000f,3.900000f,69.085716f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_358",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_358", "Sprites/OBJECTS_358", "Sprites/OBJECTS_358", 10, 358, 793, 40, 0, 0, 1, 0, 0, 1, 1, 13, 1);
		SetReadable(myObj);
		SetRotation(myObj,0,90,0);
		SetSprite(myObj, "Sprites/tmobj/tmobj_25");
		SetLink(myObj,793);
		
		myObj = new GameObject("door_019_057");
		pos = new Vector3(23.799999f, 3.300000f, 69.085716f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_320", "Sprites/OBJECTS_320", "Sprites/OBJECTS_320", 4, 320, 780, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_03_material", 23, 1, 0);
		SetRotation(myObj,-90,0,0);
		
		
		myObj = new GameObject("a_feral_troll_25_57_06_0252");
		pos = new Vector3(30.514284f, 3.300000f, 69.085716f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"111","Sprites/OBJECTS_111", 255);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_111", "Sprites/OBJECTS_111", "Sprites/OBJECTS_111", 0, 111, 0, 25, 57, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 255, 25, 57, 0, 0, 85, 0, 0, 7, 2, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,135,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		
		myObj = new GameObject("a_goblin_28_57_06_0248");
		pos = new Vector3(33.942856f, 3.300000f, 68.914284f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"78","Sprites/OBJECTS_078", 220);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_078", "Sprites/OBJECTS_078", "Sprites/OBJECTS_078", 0, 78, 0, 28, 57, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 220, 28, 57, 0, 0, 80, 0, 0, 7, 1, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,270,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("door_029_057");
		pos = new Vector3(35.314285f, 3.600000f, 68.599998f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_325", "Sprites/OBJECTS_325", "Sprites/OBJECTS_325", 4, 325, 731, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_11_material", 23, 1, 0);
		SetRotation(myObj,-90,90,0);
		
		
		
		
		
		myObj = new GameObject("an_earth_golem_61_57_06_0201");
		pos = new Vector3(73.542854f, 3.600000f, 68.742859f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"114","Sprites/OBJECTS_114", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_114", "Sprites/OBJECTS_114", "Sprites/OBJECTS_114", 0, 114, 0, 61, 57, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 61, 57, 0, 0, 72, 0, 0, 8, 2, 0, 0, 0, 0, "GroundMesh6");
		SetRotation(myObj,0,270,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		
		myObj = new GameObject("a_mage_20_58_06_0175");
		pos = new Vector3(24.514284f, 3.300000f, 70.114288f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"108","Sprites/OBJECTS_108", 213);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_108", "Sprites/OBJECTS_108", "Sprites/OBJECTS_108", 0, 108, 0, 20, 58, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 213, 20, 58, 0, 0, 27, 0, 0, 7, 2, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,270,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		
		myObj = new GameObject("a_fire_elemental_35_59_06_0211");
		pos = new Vector3(42.514286f, 0.000000f, 71.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"120","Sprites/OBJECTS_120", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_120", "Sprites/OBJECTS_120", "Sprites/OBJECTS_120", 0, 120, 0, 35, 59, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 35, 59, 0, 0, 67, 0, 0, 4, 0, 0, 0, 0, 0, "LavaMesh3");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("special_tmap_obj_39_59_06_1022",47.400002f,3.824000f,71.989998f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 41, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_160", "" , 160, false);
		SetRotation(myObj,0,0,0);
		
		myObj= CreateGameObject("special_tmap_obj_41_59_06_1023",49.799999f,3.824000f,71.989998f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 41, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_160", "" , 160, false);
		SetRotation(myObj,0,0,0);
		
		
		
		myObj= CreateGameObject("special_tmap_obj_40_60_06_0976",48.514286f,3.900000f,72.171432f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_367", "Sprites/OBJECTS_367", "Sprites/OBJECTS_367", 35, 367, 0, 40, 40, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_161", "" , 161, false);
		SetRotation(myObj,0,0,0);
		
		
		
		myObj= CreateGameObject("a_sack_49_60_06_0582",59.828568f,2.400000f,72.857147f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_128",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_128", "Sprites/OBJECTS_128", "Sprites/OBJECTS_129", 19, 128, 580, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		////Container contents
		ParentContainer = CreateContainer(myObj, 125, 255, 255);
		AddObjectToContainer("a_pile_of_bones_piles_of_bones_99_99_06_0580", ParentContainer, 0);
		AddObjectToContainer("a_skull_99_99_06_0583", ParentContainer, 1);
		AddObjectToContainer("a_crown_99_99_06_0578", ParentContainer, 2);
		////Container contents complete
		
		
		
		myObj= CreateGameObject("special_tmap_obj_03_61_06_0970",4.790000f,3.600000f,73.800003f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 42, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_139", "" , 139, false);
		SetRotation(myObj,0,90,0);
		
		
		myObj = new GameObject("a_fire_elemental_32_61_06_0229");
		pos = new Vector3(39.010284f, 1.012500f, 73.714287f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"120","Sprites/OBJECTS_120", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_120", "Sprites/OBJECTS_120", "Sprites/OBJECTS_120", 0, 120, 0, 32, 61, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 32, 61, 0, 0, 41, 0, 0, 8, 0, 0, 0, 0, 0, "LavaMesh3");
		SetRotation(myObj,0,90,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("a_giant_rat_44_61_06_0189");
		pos = new Vector3(53.314285f, 2.100000f, 73.714287f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"72","Sprites/OBJECTS_072", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_072", "Sprites/OBJECTS_072", "Sprites/OBJECTS_072", 0, 72, 0, 44, 61, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 44, 61, 0, 0, 34, 0, 0, 4, 0, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("special_tmap_obj_48_61_06_0973",58.200001f,2.700000f,74.389999f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 40, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_161", "" , 161, false);
		SetRotation(myObj,0,0,0);
		
		
		
		myObj = new GameObject("door_006_062");
		pos = new Vector3(7.885714f, 3.600000f, 74.599998f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_325", "Sprites/OBJECTS_325", "Sprites/OBJECTS_325", 4, 325, 891, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_11_material", 26, 1, 0);
		SetRotation(myObj,-90,90,0);
		
		myObj= CreateGameObject("a_scroll_24_62_06_0762",28.971428f,0.000000f,75.257141f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_312",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_312", "Sprites/OBJECTS_312", "Sprites/OBJECTS_312", 13, 312, 520, 40, 0, 1, 1, 0, 1, 1, 0, 2, 1);
		SetReadable(myObj);
		SetLink(myObj,520);
		
		myObj= CreateGameObject("a_pile_of_bones_piles_of_bones_24_62_06_0763",28.971428f,0.000000f,74.742859f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_198",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_198", "Sprites/OBJECTS_198", "Sprites/OBJECTS_198", 23, 198, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_skull_24_62_06_0764",28.971428f,0.000000f,75.085716f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_194",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_194", "Sprites/OBJECTS_194", "Sprites/OBJECTS_194", 23, 194, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		
		myObj= CreateGameObject("special_tmap_obj_57_62_06_0959",69.589996f,2.400000f,75.000000f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 45, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_141", "" , 141, false);
		SetRotation(myObj,0,90,0);
		
		
		myObj= CreateGameObject("a_scroll_61_62_06_0760",73.885712f,3.825000f,74.742859f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_312",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_312", "Sprites/OBJECTS_312", "Sprites/OBJECTS_312", 13, 312, 544, 40, 0, 1, 1, 0, 1, 1, 1, 12, 1);
		AddMagicScroll(myObj);
		
		
		
		
		
		
		//UW Triggers and Traps
		myObj= CreateGameObject("a_set_variable_trap_99_99_06_0004",120.000000f,1.387500f,119.142860f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_397",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_397", "Sprites/OBJECTS_397", "Sprites/OBJECTS_397", 50, 397, 218, 1, 52, 0, 0, 0, 1, 1, 0, 2, 1);
		SetRotation(myObj,0,45,0);
		Create_a_set_variable_trap(myObj,37,418,1);
		
		myObj= CreateGameObject("a_check_variable_trap_99_99_06_0007",118.800003f,2.737500f,119.142860f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_398",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_398", "Sprites/OBJECTS_398", "Sprites/OBJECTS_398", 51, 398, 44, 9, 6, 0, 0, 0, 1, 0, 0, 4, 1);
		SetRotation(myObj,0,270,0);
		Create_a_check_variable_trap(myObj,73,0,2354,6);
		
		myObj= CreateGameObject("a_door_trap_99_99_06_0031",119.485710f,2.512500f,118.800003f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_392",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_392", "Sprites/OBJECTS_392", "Sprites/OBJECTS_392", 45, 392, 462, 59, 15, 0, 0, 0, 1, 0, 0, 7, 1);
		SetRotation(myObj,0,90,0);
		Create_a_door_trap(myObj,59);
		
		myObj= CreateGameObject("a_delete_object_trap_99_99_06_0032",119.657135f,0.075000f,120.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_395",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_395", "Sprites/OBJECTS_395", "Sprites/OBJECTS_395", 48, 395, 58, 37, 57, 0, 0, 0, 1, 0, 0, 3, 1);
		SetRotation(myObj,0,270,0);
		Create_a_delete_object_trap(myObj);
		AddTrapLink(myObj,"a_longsword_99_99_06_0058");
		
		myObj= CreateGameObject("a_set_variable_trap_99_99_06_0036",119.657135f,0.225000f,118.971428f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_397",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_397", "Sprites/OBJECTS_397", "Sprites/OBJECTS_397", 50, 397, 1020, 13, 4, 0, 0, 0, 1, 1, 1, 15, 1);
		SetRotation(myObj,0,270,0);
		Create_a_set_variable_trap(myObj,6,3361,6);
		
		myObj= CreateGameObject("a_arrow_trap_99_99_06_0061",118.800003f,4.462500f,118.971428f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_386",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_386", "Sprites/OBJECTS_386", "Sprites/OBJECTS_386", 39, 386, 573, 9, 37, 0, 0, 0, 1, 1, 0, 5, 1);
		SetRotation(myObj,0,0,0);
		Create_a_arrow_trap(myObj, 293, 16);
		AddTrapLink(myObj,"a_create_object_trap_60_43_06_0573");
		
		myObj= CreateGameObject("a_arrow_trap_99_99_06_0076",118.800003f,2.362500f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_386",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_386", "Sprites/OBJECTS_386", "Sprites/OBJECTS_386", 39, 386, 2, 3, 1, 0, 0, 0, 1, 1, 0, 4, 1);
		SetRotation(myObj,0,225,0);
		Create_a_arrow_trap(myObj, 97, 0);
		
		myObj= CreateGameObject("a_do_trap_99_99_06_0261",119.657135f,3.300000f,119.657135f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_387",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_387", "Sprites/OBJECTS_387", "Sprites/OBJECTS_387", 40, 387, 744, 62, 33, 0, 0, 0, 1, 1, 0, 5, 1);
		SetRotation(myObj,0,45,0);
		Create_trap_base(myObj);
		
		myObj= CreateGameObject("a_spelltrap_99_99_06_0283",119.657135f,0.900000f,118.800003f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_390",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_390", "Sprites/OBJECTS_390", "Sprites/OBJECTS_390", 43, 390, 90, 25, 7, 0, 0, 0, 1, 0, 0, 3, 1);
		SetRotation(myObj,0,180,0);
		Create_a_spelltrap(myObj);
		
		myObj= CreateGameObject("a_damage_trap_99_99_06_0294",119.828575f,0.225000f,119.657135f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_384",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_384", "Sprites/OBJECTS_384", "Sprites/OBJECTS_384", 37, 384, 928, 11, 13, 0, 0, 0, 1, 1, 0, 3, 1);
		SetRotation(myObj,0,270,0);
		Create_a_damage_trap(myObj);
		AddTrapLink(myObj,"a_change_terrain_trap_26_41_06_0928");
		
		myObj= CreateGameObject("a_spelltrap_99_99_06_0329",120.000000f,0.225000f,119.485710f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_390",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_390", "Sprites/OBJECTS_390", "Sprites/OBJECTS_390", 43, 390, 112, 46, 14, 0, 0, 0, 1, 1, 0, 4, 1);
		SetRotation(myObj,0,225,0);
		Create_a_spelltrap(myObj);
		AddTrapLink(myObj,"a_switch_99_99_06_0112");
		
		myObj= CreateGameObject("a_look_trigger_99_99_06_0343",119.314285f,0.000000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_419",false);
		CreateTrigger(myObj,18,29,"a_change_terrain_trap_18_29_06_0345");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_419", "Sprites/OBJECTS_419", "Sprites/OBJECTS_419", 57, 419, 345, 18, 29, 0, 0, 0, 1, 1, 0, 4, 1);
		
		myObj= CreateGameObject("a_change_terrain_trap_18_29_06_0345",21.600000f,3.600000f,34.799999f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_389",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_389", "Sprites/OBJECTS_389", "Sprites/OBJECTS_389", 42, 389, 348, 23, 63, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_change_terrain_trap(myObj,18,29,0,0);
		AddTrapLink(myObj,"a_move_trigger_99_99_06_0348");
		
		myObj= CreateGameObject("a_delete_object_trap_18_28_06_0346",21.600000f,0.000000f,33.599998f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_395",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_395", "Sprites/OBJECTS_395", "Sprites/OBJECTS_395", 48, 395, 342, 17, 29, 0, 0, 0, 1, 1, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_delete_object_trap(myObj);
		AddTrapLink(myObj,"special_tmap_obj_17_29_06_0342");
		
		myObj= CreateGameObject("a_move_trigger_99_99_06_0348",119.400002f,3.600000f,119.400002f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,18,28,"a_delete_object_trap_18_28_06_0346");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 346, 18, 28, 0, 0, 0, 1, 1, 0, 4, 1);
		
		myObj= CreateGameObject("a_move_trigger_99_99_06_0350",119.400002f,4.500000f,119.400002f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,42,9,"a_delete_object_trap_42_09_06_0353");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 353, 42, 9, 0, 0, 0, 1, 1, 0, 4, 1);
		
		myObj= CreateGameObject("a_look_trigger_99_99_06_0351",119.314285f,0.000000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_419",false);
		CreateTrigger(myObj,42,10,"a_change_terrain_trap_42_10_06_0354");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_419", "Sprites/OBJECTS_419", "Sprites/OBJECTS_419", 57, 419, 354, 42, 10, 0, 0, 0, 1, 1, 0, 4, 1);
		
		myObj= CreateGameObject("a_delete_object_trap_42_09_06_0353",50.400002f,0.000000f,10.800000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_395",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_395", "Sprites/OBJECTS_395", "Sprites/OBJECTS_395", 48, 395, 352, 43, 10, 0, 0, 0, 1, 1, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_delete_object_trap(myObj);
		AddTrapLink(myObj,"special_tmap_obj_43_10_06_0352");
		
		myObj= CreateGameObject("a_change_terrain_trap_42_10_06_0354",50.400002f,4.500000f,12.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_389",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_389", "Sprites/OBJECTS_389", "Sprites/OBJECTS_389", 42, 389, 350, 23, 63, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_change_terrain_trap(myObj,42,10,0,0);
		AddTrapLink(myObj,"a_move_trigger_99_99_06_0350");
		
		myObj= CreateGameObject("a_move_trigger_40_55_06_0355",48.599998f,3.300000f,66.599998f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,42,57,"a_create_object_trap_42_57_06_0356");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 356, 42, 57, 0, 0, 0, 1, 1, 0, 4, 1);
		
		myObj= CreateGameObject("a_create_object_trap_42_57_06_0356",51.085712f,3.300000f,69.085716f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_391",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", 44, 391, 190, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_create_object_trap(myObj, "GroundMesh1");
		AddTrapLink(myObj,"a_gazer_99_99_06_0190");
		
		myObj= CreateGameObject("a_move_trigger_51_61_06_0383",61.799999f,2.400000f,73.800003f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,52,59,"a_create_object_trap_52_59_06_0384");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 384, 52, 59, 0, 0, 0, 1, 1, 0, 4, 1);
		
		myObj= CreateGameObject("a_create_object_trap_52_59_06_0384",63.085712f,2.700000f,71.485710f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_391",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", 44, 391, 172, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_create_object_trap(myObj, "GroundMesh1");
		AddTrapLink(myObj,"a_great_troll_99_99_06_0172");
		
		myObj= CreateGameObject("a_pick_up_trigger_99_99_06_0398",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_417",false);
		CreateTrigger(myObj,19,34,"a_create_object_trap_19_34_06_0399");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_417", "Sprites/OBJECTS_417", "Sprites/OBJECTS_417", 55, 417, 399, 19, 34, 0, 0, 0, 1, 1, 0, 4, 1);
		
		myObj= CreateGameObject("a_create_object_trap_19_34_06_0399",23.485716f,3.300000f,41.485714f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_391",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", 44, 391, 186, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_create_object_trap(myObj, "GroundMesh7");
		AddTrapLink(myObj,"a_ghost_99_99_06_0186");
		
		myObj= CreateGameObject("a_pick_up_trigger_99_99_06_0400",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_417",false);
		CreateTrigger(myObj,19,35,"a_create_object_trap_19_35_06_0402");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_417", "Sprites/OBJECTS_417", "Sprites/OBJECTS_417", 55, 417, 402, 19, 35, 0, 0, 0, 1, 1, 0, 4, 1);
		
		myObj= CreateGameObject("a_create_object_trap_19_35_06_0402",23.485716f,3.300000f,42.685715f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_391",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", 44, 391, 185, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_create_object_trap(myObj, "GroundMesh7");
		AddTrapLink(myObj,"a_ghost_99_99_06_0185");
		
		myObj= CreateGameObject("a_move_trigger_11_33_06_0428",13.800000f,2.400000f,40.200001f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,12,33,"a_teleport_trap_12_33_06_0457");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 457, 12, 33, 0, 0, 0, 1, 1, 1, 14, 1);
		
		myObj= CreateGameObject("a_door_trap_99_99_06_0433",118.800003f,2.400000f,118.800003f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_392",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_392", "Sprites/OBJECTS_392", "Sprites/OBJECTS_392", 45, 392, 434, 3, 0, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_door_trap(myObj,3);
		
		myObj= CreateGameObject("a_door_trap_99_99_06_0437",118.800003f,2.400000f,118.800003f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_392",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_392", "Sprites/OBJECTS_392", "Sprites/OBJECTS_392", 45, 392, 669, 2, 0, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_door_trap(myObj,2);
		
		myObj= CreateGameObject("a_pick_up_trigger_99_99_06_0439",119.314285f,1.200000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_417",false);
		CreateTrigger(myObj,38,35,"a_damage_trap_38_35_06_0465");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_417", "Sprites/OBJECTS_417", "Sprites/OBJECTS_417", 55, 417, 465, 38, 35, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_pick_up_trigger_99_99_06_0440",119.314285f,1.200000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_417",false);
		CreateTrigger(myObj,39,37,"a_damage_trap_39_37_06_0451");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_417", "Sprites/OBJECTS_417", "Sprites/OBJECTS_417", 55, 417, 451, 39, 37, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_pick_up_trigger_99_99_06_0441",119.314285f,1.200000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_417",false);
		CreateTrigger(myObj,39,37,"a_damage_trap_39_37_06_0451");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_417", "Sprites/OBJECTS_417", "Sprites/OBJECTS_417", 55, 417, 451, 39, 37, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_pick_up_trigger_99_99_06_0442",119.314285f,1.200000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_417",false);
		CreateTrigger(myObj,39,37,"a_damage_trap_39_37_06_0451");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_417", "Sprites/OBJECTS_417", "Sprites/OBJECTS_417", 55, 417, 451, 39, 37, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_pick_up_trigger_99_99_06_0443",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_417",false);
		CreateTrigger(myObj,38,35,"a_damage_trap_38_35_06_0465");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_417", "Sprites/OBJECTS_417", "Sprites/OBJECTS_417", 55, 417, 465, 38, 35, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_pick_up_trigger_99_99_06_0444",119.314285f,1.200000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_417",false);
		CreateTrigger(myObj,38,35,"a_damage_trap_38_35_06_0465");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_417", "Sprites/OBJECTS_417", "Sprites/OBJECTS_417", 55, 417, 465, 38, 35, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_change_terrain_trap_20_41_06_0446",24.000000f,3.600000f,49.200001f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_389",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_389", "Sprites/OBJECTS_389", "Sprites/OBJECTS_389", 42, 389, 839, 23, 63, 0, 0, 0, 1, 0, 0, 2, 1);
		SetRotation(myObj,0,0,0);
		Create_a_change_terrain_trap(myObj,20,41,0,0);
		AddTrapLink(myObj,"a_delete_object_trap_99_99_06_0839");
		
		myObj= CreateGameObject("a_pick_up_trigger_99_99_06_0448",119.314285f,1.200000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_417",false);
		CreateTrigger(myObj,39,37,"a_damage_trap_39_37_06_0451");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_417", "Sprites/OBJECTS_417", "Sprites/OBJECTS_417", 55, 417, 451, 39, 37, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_damage_trap_39_37_06_0451",46.799999f,4.500000f,44.400002f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_384",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_384", "Sprites/OBJECTS_384", "Sprites/OBJECTS_384", 37, 384, 0, 20, 0, 0, 0, 0, 1, 0, 0, 4, 1);
		SetRotation(myObj,0,0,0);
		Create_a_damage_trap(myObj);
		
		myObj= CreateGameObject("a_teleport_trap_12_33_06_0457",14.400000f,0.300000f,39.599998f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_385",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_385", "Sprites/OBJECTS_385", "Sprites/OBJECTS_385", 38, 385, 0, 12, 33, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_teleport_trap(myObj,(float)15.000000,(float)40.200000,(float)4.500000,8);
		
		myObj= CreateGameObject("a_pick_up_trigger_99_99_06_0464",119.314285f,1.200000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_417",false);
		CreateTrigger(myObj,38,35,"a_damage_trap_38_35_06_0465");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_417", "Sprites/OBJECTS_417", "Sprites/OBJECTS_417", 55, 417, 465, 38, 35, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_damage_trap_38_35_06_0465",45.599998f,3.600000f,42.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_384",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_384", "Sprites/OBJECTS_384", "Sprites/OBJECTS_384", 37, 384, 0, 10, 0, 0, 0, 0, 1, 0, 0, 4, 1);
		SetRotation(myObj,0,0,0);
		Create_a_damage_trap(myObj);
		
		myObj= CreateGameObject("a_move_trigger_33_42_06_0472",40.200001f,3.000000f,51.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,33,40,"a_create_object_trap_33_40_06_0473");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 473, 33, 40, 0, 0, 0, 1, 1, 0, 4, 1);
		
		myObj= CreateGameObject("a_create_object_trap_33_40_06_0473",40.285717f,3.300000f,48.685715f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_391",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", 44, 391, 169, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_create_object_trap(myObj, "GroundMesh12");
		AddTrapLink(myObj,"a_shadow_beast_99_99_06_0169");
		
		myObj= CreateGameObject("a_door_trap_99_99_06_0484",118.800003f,3.600000f,118.800003f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_392",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_392", "Sprites/OBJECTS_392", "Sprites/OBJECTS_392", 45, 392, 845, 3, 0, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_door_trap(myObj,3);
		
		myObj= CreateGameObject("a_create_object_trap_60_43_06_0573",72.685715f,0.000000f,52.285713f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_391",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", 44, 391, 239, 30, 0, 0, 0, 0, 1, 0, 0, 0, 1);
		SetRotation(myObj,0,0,0);
		Create_a_create_object_trap(myObj, "GroundMesh0");
		AddTrapLink(myObj,"a_fire_elemental_99_99_06_0239");
		
		myObj= CreateGameObject("a_move_trigger_27_55_06_0643",33.000000f,3.300000f,66.599998f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,27,54,"a_door_trap_99_99_06_0782");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 782, 27, 54, 0, 0, 0, 1, 1, 0, 4, 1);
		
		myObj= CreateGameObject("a_set_variable_trap_99_99_06_0650",118.800003f,1.875000f,118.971428f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_397",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_397", "Sprites/OBJECTS_397", "Sprites/OBJECTS_397", 50, 397, 837, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1);
		SetRotation(myObj,0,90,0);
		Create_a_set_variable_trap(myObj,50,1,2);
		AddTrapLink(myObj,"a_do_trap_99_99_06_0837");
		
		myObj= CreateGameObject("a_move_trigger_04_38_06_0656",5.400000f,3.600000f,46.200001f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,7,35,"a_door_trap_99_99_06_0672");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 672, 7, 35, 0, 0, 0, 1, 1, 0, 4, 1);
		
		myObj= CreateGameObject("an_open_trigger_99_99_06_0660",119.314285f,3.300000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_421",false);
		CreateTrigger(myObj,21,55,"a_set_variable_trap_21_55_06_0772");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_421", "Sprites/OBJECTS_421", "Sprites/OBJECTS_421", 59, 421, 772, 21, 55, 0, 0, 0, 1, 1, 0, 4, 1);
		
		myObj= CreateGameObject("a_use_trigger_99_99_06_0664",119.314285f,3.300000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_418",false);
		CreateTrigger(myObj,7,35,"a_door_trap_99_99_06_0672");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_418", "Sprites/OBJECTS_418", "Sprites/OBJECTS_418", 56, 418, 672, 7, 35, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_use_trigger_99_99_06_0667",119.314285f,3.300000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_418",false);
		CreateTrigger(myObj,19,4,"a_door_trap_99_99_06_0433");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_418", "Sprites/OBJECTS_418", "Sprites/OBJECTS_418", 56, 418, 433, 19, 4, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_move_trigger_18_04_06_0668",22.200001f,2.400000f,5.400000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,19,4,"a_door_trap_99_99_06_0437");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 437, 19, 4, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_door_trap_99_99_06_0670",118.800003f,3.600000f,118.800003f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_392",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_392", "Sprites/OBJECTS_392", "Sprites/OBJECTS_392", 45, 392, 408, 2, 0, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_door_trap(myObj,2);
		
		myObj= CreateGameObject("a_door_trap_99_99_06_0671",118.800003f,3.600000f,118.800003f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_392",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_392", "Sprites/OBJECTS_392", "Sprites/OBJECTS_392", 45, 392, 409, 3, 0, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_door_trap(myObj,3);
		
		myObj= CreateGameObject("a_door_trap_99_99_06_0672",118.800003f,3.600000f,118.800003f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_392",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_392", "Sprites/OBJECTS_392", "Sprites/OBJECTS_392", 45, 392, 662, 2, 0, 0, 0, 0, 1, 0, 0, 2, 1);
		SetRotation(myObj,0,0,0);
		Create_a_door_trap(myObj,2);
		
		myObj= CreateGameObject("a_damage_trap_43_32_06_0674",51.599998f,3.600000f,38.400002f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_384",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_384", "Sprites/OBJECTS_384", "Sprites/OBJECTS_384", 37, 384, 0, 4, 0, 0, 0, 0, 1, 0, 1, 15, 1);
		SetRotation(myObj,0,0,0);
		Create_a_damage_trap(myObj);
		
		myObj= CreateGameObject("a_move_trigger_54_39_06_0677",65.400002f,3.600000f,47.400002f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,43,32,"a_damage_trap_43_32_06_0674");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 674, 43, 32, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_move_trigger_51_53_06_0688",61.799999f,3.000000f,64.199997f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,51,54,"a_create_object_trap_51_54_06_0689");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 689, 51, 54, 0, 0, 0, 1, 1, 0, 4, 1);
		
		myObj= CreateGameObject("a_create_object_trap_51_54_06_0689",61.885712f,3.000000f,65.485710f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_391",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", 44, 391, 188, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_create_object_trap(myObj, "GroundMesh6");
		AddTrapLink(myObj,"a_dire_ghost_99_99_06_0188");
		
		myObj= CreateGameObject("a_move_trigger_29_20_06_0709",35.400002f,3.600000f,24.600000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,29,21,"a_door_trap_99_99_06_0670");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 670, 29, 21, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_use_trigger_99_99_06_0711",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_418",false);
		CreateTrigger(myObj,29,21,"a_door_trap_99_99_06_0671");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_418", "Sprites/OBJECTS_418", "Sprites/OBJECTS_418", 56, 418, 671, 29, 21, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_move_trigger_38_26_06_0719",46.200001f,0.900000f,31.799999f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,42,25,"a_damage_trap_42_25_06_0831");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 831, 42, 25, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_move_trigger_39_21_06_0720",47.400002f,0.300000f,25.799999f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,42,25,"a_damage_trap_42_25_06_0831");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 831, 42, 25, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_move_trigger_31_27_06_0721",37.799999f,0.300000f,33.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,42,25,"a_damage_trap_42_25_06_0831");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 831, 42, 25, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_move_trigger_32_25_06_0724",39.000000f,0.300000f,30.600000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,42,25,"a_damage_trap_42_25_06_0831");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 831, 42, 25, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_move_trigger_39_24_06_0727",47.400002f,0.900000f,29.400000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,42,25,"a_damage_trap_42_25_06_0831");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 831, 42, 25, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_move_trigger_36_28_06_0728",43.799999f,2.100000f,34.200001f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,42,25,"a_damage_trap_42_25_06_0831");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 831, 42, 25, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_move_trigger_34_22_06_0729",41.400002f,2.100000f,27.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,42,25,"a_damage_trap_42_25_06_0831");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 831, 42, 25, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_move_trigger_21_36_06_0739",25.799999f,3.600000f,43.799999f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,19,38,"a_text_string_trap_19_38_06_0897");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 897, 19, 38, 0, 0, 0, 1, 1, 0, 4, 1);
		
		myObj= CreateGameObject("a_move_trigger_15_43_06_0746",18.600000f,3.300000f,52.200001f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,15,40,"a_create_object_trap_15_40_06_0749");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 749, 15, 40, 0, 0, 0, 1, 1, 0, 4, 1);
		
		myObj= CreateGameObject("a_move_trigger_15_43_06_0747",18.600000f,3.300000f,52.200001f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,13,43,"a_create_object_trap_13_43_06_0748");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 748, 13, 43, 0, 0, 0, 1, 1, 0, 4, 1);
		
		myObj= CreateGameObject("a_create_object_trap_13_43_06_0748",16.285713f,3.600000f,52.285713f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_391",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", 44, 391, 207, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_create_object_trap(myObj, "GroundMesh1");
		AddTrapLink(myObj,"a_dread_spider_99_99_06_0207");
		
		myObj= CreateGameObject("a_create_object_trap_15_40_06_0749",18.685715f,3.600000f,48.685715f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_391",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", 44, 391, 210, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_create_object_trap(myObj, "GroundMesh1");
		AddTrapLink(myObj,"a_dread_spider_99_99_06_0210");
		
		myObj= CreateGameObject("a_move_trigger_99_99_06_0752",119.400002f,3.600000f,119.400002f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,26,34,"a_delete_object_trap_26_34_06_0753");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 753, 26, 34, 0, 0, 0, 1, 1, 0, 4, 1);
		
		myObj= CreateGameObject("a_delete_object_trap_26_34_06_0753",31.200001f,0.000000f,40.799999f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_395",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_395", "Sprites/OBJECTS_395", "Sprites/OBJECTS_395", 48, 395, 942, 25, 35, 0, 0, 0, 1, 1, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_delete_object_trap(myObj);
		AddTrapLink(myObj,"special_tmap_obj_25_35_06_0942");
		
		myObj= CreateGameObject("a_move_trigger_15_43_06_0754",18.600000f,3.300000f,52.200001f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,15,43,"a_change_terrain_trap_15_43_06_0755");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 755, 15, 43, 0, 0, 0, 1, 1, 0, 4, 1);
		
		myObj= CreateGameObject("a_change_terrain_trap_15_43_06_0755",18.000000f,2.700000f,51.599998f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_389",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_389", "Sprites/OBJECTS_389", "Sprites/OBJECTS_389", 42, 389, 0, 11, 63, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_change_terrain_trap(myObj,15,43,0,0);
		
		myObj= CreateGameObject("an_open_trigger_99_99_06_0758",119.314285f,3.000000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_421",false);
		CreateTrigger(myObj,55,6,"a_spelltrap_55_06_06_0761");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_421", "Sprites/OBJECTS_421", "Sprites/OBJECTS_421", 59, 421, 761, 55, 6, 0, 0, 0, 1, 1, 0, 4, 1);
		
		myObj= CreateGameObject("a_delete_object_trap_99_99_06_0759",118.800003f,0.000000f,118.800003f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_395",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_395", "Sprites/OBJECTS_395", "Sprites/OBJECTS_395", 48, 395, 945, 54, 6, 0, 0, 0, 1, 1, 0, 0, 1);
		SetRotation(myObj,0,0,0);
		Create_a_delete_object_trap(myObj);
		AddTrapLink(myObj,"special_tmap_obj_54_06_06_0945");
		
		myObj= CreateGameObject("a_spelltrap_55_06_06_0761",66.000000f,3.300000f,7.200000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_390",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_390", "Sprites/OBJECTS_390", "Sprites/OBJECTS_390", 43, 390, 759, 14, 3, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_spelltrap(myObj);
		AddTrapLink(myObj,"a_delete_object_trap_99_99_06_0759");
		
		myObj= CreateGameObject("a_move_trigger_11_41_06_0766",13.800000f,2.700000f,49.799999f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,11,39,"a_create_object_trap_11_39_06_0767");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 767, 11, 39, 0, 0, 0, 1, 1, 1, 12, 1);
		
		myObj= CreateGameObject("a_create_object_trap_11_39_06_0767",13.885715f,3.000000f,47.485714f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_391",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", 44, 391, 253, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_create_object_trap(myObj, "GroundMesh1");
		AddTrapLink(myObj,"a_dread_spider_99_99_06_0253");
		
		myObj= CreateGameObject("a_move_trigger_11_41_06_0768",13.800000f,2.700000f,49.799999f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,11,41,"a_change_terrain_trap_11_41_06_0769");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 769, 11, 41, 0, 0, 0, 1, 1, 0, 4, 1);
		
		myObj= CreateGameObject("a_change_terrain_trap_11_41_06_0769",13.200000f,2.100000f,49.200001f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_389",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_389", "Sprites/OBJECTS_389", "Sprites/OBJECTS_389", 42, 389, 0, 11, 63, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_change_terrain_trap(myObj,11,41,0,0);
		
		myObj= CreateGameObject("a_set_variable_trap_21_55_06_0772",25.200001f,1.912500f,66.171432f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_397",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_397", "Sprites/OBJECTS_397", "Sprites/OBJECTS_397", 50, 397, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,90,0);
		Create_a_set_variable_trap(myObj,51,1,2);
		
		myObj= CreateGameObject("a_move_trigger_99_99_06_0773",119.400002f,2.700000f,119.400002f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,17,50,"outofrange_99_99_06_0000");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 0, 17, 50, 0, 0, 0, 1, 1, 0, 4, 1);
		
		myObj= CreateGameObject("a_text_string_trap_99_99_06_0774",118.800003f,3.600000f,118.800003f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_400",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_400", "Sprites/OBJECTS_400", "Sprites/OBJECTS_400", 53, 400, 0, 12, 1, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_text_string_trap(myObj,9,385);
		
		myObj= CreateGameObject("a_move_trigger_23_56_06_0775",28.200001f,3.300000f,67.800003f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,24,57,"a_text_string_trap_24_57_06_0776");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 776, 24, 57, 0, 0, 0, 1, 1, 0, 4, 1);
		
		myObj= CreateGameObject("a_text_string_trap_24_57_06_0776",28.799999f,3.300000f,68.400002f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_400",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_400", "Sprites/OBJECTS_400", "Sprites/OBJECTS_400", 53, 400, 650, 12, 0, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_text_string_trap(myObj,9,384);
		AddTrapLink(myObj,"a_set_variable_trap_99_99_06_0650");
		
		myObj= CreateGameObject("a_door_trap_99_99_06_0782",118.800003f,3.300000f,118.800003f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_392",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_392", "Sprites/OBJECTS_392", "Sprites/OBJECTS_392", 45, 392, 658, 2, 0, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_door_trap(myObj,2);
		
		myObj= CreateGameObject("a_move_trigger_36_09_06_0798",43.799999f,3.300000f,11.400000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,33,8,"a_create_object_trap_33_08_06_0799");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 799, 33, 8, 0, 0, 0, 1, 1, 0, 4, 1);
		
		myObj= CreateGameObject("a_create_object_trap_33_08_06_0799",40.285717f,3.600000f,10.285714f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_391",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", 44, 391, 194, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_create_object_trap(myObj, "GroundMesh6");
		AddTrapLink(myObj,"a_reaper_99_99_06_0194");
		
		myObj= CreateGameObject("a_move_trigger_56_32_06_0822",67.800003f,3.600000f,39.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,43,32,"a_damage_trap_43_32_06_0674");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 674, 43, 32, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_move_trigger_52_24_06_0824",63.000000f,3.600000f,29.400000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,43,32,"a_damage_trap_43_32_06_0674");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 674, 43, 32, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_move_trigger_53_35_06_0826",64.199997f,3.600000f,42.599998f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,43,32,"a_damage_trap_43_32_06_0674");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 674, 43, 32, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_move_trigger_46_21_06_0828",55.799999f,3.600000f,25.799999f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,54,23,"a_damage_trap_54_23_06_0836");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 836, 54, 23, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_look_trigger_99_99_06_0829",119.314285f,0.000000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_419",false);
		CreateTrigger(myObj,20,41,"a_change_terrain_trap_20_41_06_0446");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_419", "Sprites/OBJECTS_419", "Sprites/OBJECTS_419", 57, 419, 446, 20, 41, 0, 0, 0, 1, 1, 0, 4, 1);
		
		myObj= CreateGameObject("a_move_trigger_61_24_06_0830",73.800003f,3.600000f,29.400000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,54,23,"a_damage_trap_54_23_06_0836");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 836, 54, 23, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_damage_trap_42_25_06_0831",50.400002f,0.000000f,30.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_384",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_384", "Sprites/OBJECTS_384", "Sprites/OBJECTS_384", 37, 384, 0, 3, 0, 0, 0, 0, 1, 0, 0, 7, 1);
		SetRotation(myObj,0,0,0);
		Create_a_damage_trap(myObj);
		
		myObj= CreateGameObject("a_move_trigger_55_18_06_0832",66.599998f,3.600000f,22.200001f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,54,23,"a_damage_trap_54_23_06_0836");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 836, 54, 23, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_move_trigger_59_20_06_0834",71.400002f,3.600000f,24.600000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,54,23,"a_damage_trap_54_23_06_0836");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 836, 54, 23, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_create_object_trap_35_56_06_0835",42.685715f,0.000000f,67.885712f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_391",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", 44, 391, 237, 30, 0, 0, 0, 0, 1, 0, 0, 0, 1);
		SetRotation(myObj,0,0,0);
		Create_a_create_object_trap(myObj, "GroundMesh0");
		AddTrapLink(myObj,"a_fire_elemental_99_99_06_0237");
		
		myObj= CreateGameObject("a_damage_trap_54_23_06_0836",64.800003f,3.600000f,27.600000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_384",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_384", "Sprites/OBJECTS_384", "Sprites/OBJECTS_384", 37, 384, 0, 40, 0, 0, 0, 0, 1, 0, 0, 6, 1);
		SetRotation(myObj,0,0,0);
		Create_a_damage_trap(myObj);
		
		myObj= CreateGameObject("a_do_trap_99_99_06_0837",118.800003f,3.300000f,118.800003f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_387",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_387", "Sprites/OBJECTS_387", "Sprites/OBJECTS_387", 40, 387, 0, 50, 0, 0, 0, 0, 1, 1, 0, 0, 1);
		SetRotation(myObj,0,0,0);
		Create_trap_base(myObj);
		
		myObj= CreateGameObject("a_move_trigger_54_27_06_0838",65.400002f,3.600000f,33.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,43,32,"a_damage_trap_43_32_06_0674");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 674, 43, 32, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_delete_object_trap_99_99_06_0839",118.800003f,0.000000f,118.800003f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_395",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_395", "Sprites/OBJECTS_395", "Sprites/OBJECTS_395", 48, 395, 887, 20, 42, 0, 0, 0, 1, 1, 0, 0, 1);
		SetRotation(myObj,0,0,0);
		Create_a_delete_object_trap(myObj);
		AddTrapLink(myObj,"a_move_trigger_20_42_06_0887");
		AddTrapLink(myObj,"a_move_trigger_20_42_06_0887");
		
		myObj= CreateGameObject("a_move_trigger_51_30_06_0840",61.799999f,3.600000f,36.599998f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,43,32,"a_damage_trap_43_32_06_0674");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 674, 43, 32, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_move_trigger_43_30_06_0842",52.200001f,3.600000f,36.599998f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,43,32,"a_damage_trap_43_32_06_0674");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 674, 43, 32, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_move_trigger_52_22_06_0844",63.000000f,3.600000f,27.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,54,23,"a_damage_trap_54_23_06_0836");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 836, 54, 23, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_use_trigger_99_99_06_0846",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_418",false);
		CreateTrigger(myObj,7,35,"a_door_trap_99_99_06_0484");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_418", "Sprites/OBJECTS_418", "Sprites/OBJECTS_418", 56, 418, 484, 7, 35, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_move_trigger_50_26_06_0847",60.599998f,3.600000f,31.799999f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,54,23,"a_damage_trap_54_23_06_0836");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 836, 54, 23, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_move_trigger_49_26_06_0848",59.400002f,3.600000f,31.799999f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,43,32,"a_damage_trap_43_32_06_0674");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 674, 43, 32, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_pick_up_trigger_99_99_06_0849",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_417",false);
		CreateTrigger(myObj,21,40,"a_text_string_trap_21_40_06_0893");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_417", "Sprites/OBJECTS_417", "Sprites/OBJECTS_417", 55, 417, 893, 21, 40, 0, 0, 0, 1, 1, 1, 12, 1);
		
		myObj= CreateGameObject("a_move_trigger_51_31_06_0850",61.799999f,3.600000f,37.799999f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,43,32,"a_damage_trap_43_32_06_0674");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 674, 43, 32, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_move_trigger_53_32_06_0852",64.199997f,3.600000f,39.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,43,32,"a_damage_trap_43_32_06_0674");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 674, 43, 32, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_move_trigger_49_37_06_0854",59.400002f,3.600000f,45.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,43,32,"a_damage_trap_43_32_06_0674");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 674, 43, 32, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_move_trigger_50_28_06_0856",60.599998f,3.600000f,34.200001f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,43,32,"a_damage_trap_43_32_06_0674");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 674, 43, 32, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_move_trigger_49_28_06_0858",59.400002f,3.600000f,34.200001f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,43,32,"a_damage_trap_43_32_06_0674");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 674, 43, 32, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_look_trigger_99_99_06_0866",119.314285f,0.000000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_419",false);
		CreateTrigger(myObj,36,35,"a_change_terrain_trap_36_35_06_0870");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_419", "Sprites/OBJECTS_419", "Sprites/OBJECTS_419", 57, 419, 870, 36, 35, 0, 0, 0, 1, 1, 0, 4, 1);
		
		myObj= CreateGameObject("a_delete_object_trap_35_35_06_0867",42.000000f,0.000000f,42.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_395",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_395", "Sprites/OBJECTS_395", "Sprites/OBJECTS_395", 48, 395, 869, 36, 36, 0, 0, 0, 1, 1, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_delete_object_trap(myObj);
		AddTrapLink(myObj,"special_tmap_obj_36_36_06_0869");
		
		myObj= CreateGameObject("a_move_trigger_99_99_06_0868",119.400002f,1.500000f,119.400002f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,35,35,"a_delete_object_trap_35_35_06_0867");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 867, 35, 35, 0, 0, 0, 1, 1, 0, 4, 1);
		
		myObj= CreateGameObject("a_change_terrain_trap_36_35_06_0870",43.200001f,1.500000f,42.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_389",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_389", "Sprites/OBJECTS_389", "Sprites/OBJECTS_389", 42, 389, 868, 23, 63, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_change_terrain_trap(myObj,36,35,0,0);
		AddTrapLink(myObj,"a_move_trigger_99_99_06_0868");
		
		myObj= CreateGameObject("a_move_trigger_99_99_06_0871",119.400002f,3.600000f,119.400002f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,61,55,"a_delete_object_trap_61_55_06_0872");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 872, 61, 55, 0, 0, 0, 1, 1, 0, 4, 1);
		
		myObj= CreateGameObject("a_delete_object_trap_61_55_06_0872",73.199997f,0.000000f,66.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_395",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_395", "Sprites/OBJECTS_395", "Sprites/OBJECTS_395", 48, 395, 948, 60, 56, 0, 0, 0, 1, 1, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_delete_object_trap(myObj);
		AddTrapLink(myObj,"special_tmap_obj_60_56_06_0948");
		
		myObj= CreateGameObject("a_look_trigger_99_99_06_0873",119.314285f,0.000000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_419",false);
		CreateTrigger(myObj,60,55,"a_change_terrain_trap_60_55_06_0968");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_419", "Sprites/OBJECTS_419", "Sprites/OBJECTS_419", 57, 419, 968, 60, 55, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_move_trigger_20_42_06_0887",24.600000f,3.600000f,51.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,21,41,"an_inventory_trap_21_41_06_0896");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 896, 21, 41, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_move_trigger_23_56_06_0888",28.200001f,3.300000f,67.800003f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,24,56,"a_door_trap_99_99_06_0889");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 889, 24, 56, 0, 0, 0, 1, 1, 0, 4, 1);
		
		myObj= CreateGameObject("a_door_trap_99_99_06_0889",118.800003f,3.300000f,118.800003f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_392",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_392", "Sprites/OBJECTS_392", "Sprites/OBJECTS_392", 45, 392, 819, 2, 0, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_door_trap(myObj,2);
		
		myObj= CreateGameObject("a_text_string_trap_21_40_06_0893",25.200001f,3.600000f,48.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_400",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_400", "Sprites/OBJECTS_400", "Sprites/OBJECTS_400", 53, 400, 899, 12, 3, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_text_string_trap(myObj,9,387);
		AddTrapLink(myObj,"a_pick_up_trigger_99_99_06_0899");
		
		myObj= CreateGameObject("a_move_trigger_44_32_06_0894",53.400002f,3.600000f,39.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,43,32,"a_damage_trap_43_32_06_0674");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 674, 43, 32, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("an_inventory_trap_21_41_06_0896",25.200001f,0.037500f,49.200001f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_396",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_396", "Sprites/OBJECTS_396", "Sprites/OBJECTS_396", 49, 396, 849, 8, 17, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_an_inventory_trap(myObj);
		AddTrapLink(myObj,"a_pick_up_trigger_99_99_06_0849");
		
		myObj= CreateGameObject("a_text_string_trap_19_38_06_0897",22.799999f,3.600000f,45.599998f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_400",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_400", "Sprites/OBJECTS_400", "Sprites/OBJECTS_400", 53, 400, 900, 12, 2, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_text_string_trap(myObj,9,386);
		AddTrapLink(myObj,"a_create_object_trap_99_99_06_0900");
		
		myObj= CreateGameObject("a_move_trigger_99_99_06_0898",119.400002f,3.600000f,119.400002f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,20,41,"outofrange_99_99_06_0000");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 0, 20, 41, 0, 0, 0, 1, 1, 0, 4, 1);
		
		myObj= CreateGameObject("a_pick_up_trigger_99_99_06_0899",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_417",false);
		CreateTrigger(myObj,20,41,"a_change_terrain_trap_20_41_06_0446");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_417", "Sprites/OBJECTS_417", "Sprites/OBJECTS_417", 55, 417, 446, 20, 41, 0, 0, 0, 1, 1, 1, 12, 1);
		
		myObj= CreateGameObject("a_create_object_trap_99_99_06_0900",119.485710f,3.600000f,119.485710f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_391",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", 44, 391, 740, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1);
		SetRotation(myObj,0,0,0);
		Create_a_create_object_trap(myObj, "GroundMesh1");
		AddTrapLink(myObj,"a_large_boulder_99_99_06_0740");
		
		myObj= CreateGameObject("a_change_terrain_trap_99_99_06_0901",118.800003f,3.600000f,118.800003f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_389",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_389", "Sprites/OBJECTS_389", "Sprites/OBJECTS_389", 42, 389, 0, 22, 62, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_change_terrain_trap(myObj,99,99,0,0);
		
		myObj= CreateGameObject("a_move_trigger_45_32_06_0902",54.599998f,3.600000f,39.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,43,32,"a_damage_trap_43_32_06_0674");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 674, 43, 32, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_move_trigger_99_99_06_0908",119.400002f,2.700000f,119.400002f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,13,47,"outofrange_99_99_06_0000");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 0, 13, 47, 0, 0, 0, 1, 1, 0, 4, 1);
		
		myObj= CreateGameObject("a_create_object_trap_04_43_06_0909",5.485714f,3.600000f,52.285713f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_391",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", 44, 391, 204, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_create_object_trap(myObj, "GroundMesh1");
		AddTrapLink(myObj,"a_dread_spider_99_99_06_0204");
		
		myObj= CreateGameObject("a_move_trigger_99_99_06_0910",119.400002f,2.700000f,119.400002f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,13,46,"outofrange_99_99_06_0000");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 0, 13, 46, 0, 0, 0, 1, 1, 0, 4, 1);
		
		myObj= CreateGameObject("a_delete_object_trap_99_99_06_0912",118.800003f,0.000000f,118.800003f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_395",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_395", "Sprites/OBJECTS_395", "Sprites/OBJECTS_395", 48, 395, 227, 13, 47, 0, 0, 0, 1, 1, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_delete_object_trap(myObj);
		AddTrapLink(myObj,"a_mage_13_47_06_0227");
		
		myObj= CreateGameObject("a_move_trigger_99_99_06_0913",119.400002f,3.600000f,119.400002f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,25,41,"a_delete_object_trap_25_41_06_0923");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 923, 25, 41, 0, 0, 0, 1, 1, 0, 4, 1);
		
		myObj= CreateGameObject("a_look_trigger_99_99_06_0914",119.314285f,0.000000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_419",false);
		CreateTrigger(myObj,26,41,"a_change_terrain_trap_26_41_06_0928");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_419", "Sprites/OBJECTS_419", "Sprites/OBJECTS_419", 57, 419, 928, 26, 41, 0, 0, 0, 1, 1, 0, 4, 1);
		
		myObj= CreateGameObject("a_move_trigger_02_43_06_0917",3.000000f,3.000000f,52.200001f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,3,41,"a_create_object_trap_03_41_06_0922");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 922, 3, 41, 0, 0, 0, 1, 1, 0, 4, 1);
		
		myObj= CreateGameObject("a_create_object_trap_03_41_06_0922",4.285714f,3.600000f,49.885712f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_391",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", 44, 391, 199, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_create_object_trap(myObj, "GroundMesh1");
		AddTrapLink(myObj,"a_dread_spider_99_99_06_0199");
		
		myObj= CreateGameObject("a_delete_object_trap_25_41_06_0923",30.000000f,0.000000f,49.200001f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_395",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_395", "Sprites/OBJECTS_395", "Sprites/OBJECTS_395", 48, 395, 920, 26, 40, 0, 0, 0, 1, 1, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_delete_object_trap(myObj);
		AddTrapLink(myObj,"special_tmap_obj_26_40_06_0920");
		
		myObj= CreateGameObject("a_look_trigger_99_99_06_0926",119.314285f,0.000000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_419",false);
		CreateTrigger(myObj,26,35,"a_change_terrain_trap_26_35_06_0941");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_419", "Sprites/OBJECTS_419", "Sprites/OBJECTS_419", 57, 419, 941, 26, 35, 0, 0, 0, 1, 1, 0, 4, 1);
		
		myObj= CreateGameObject("a_move_trigger_02_43_06_0927",3.000000f,3.000000f,52.200001f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,4,43,"a_create_object_trap_04_43_06_0909");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 909, 4, 43, 0, 0, 0, 1, 1, 0, 4, 1);
		
		myObj= CreateGameObject("a_change_terrain_trap_26_41_06_0928",31.200001f,3.600000f,49.200001f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_389",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_389", "Sprites/OBJECTS_389", "Sprites/OBJECTS_389", 42, 389, 913, 11, 63, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_change_terrain_trap(myObj,26,41,0,0);
		AddTrapLink(myObj,"a_move_trigger_99_99_06_0913");
		
		myObj= CreateGameObject("a_create_object_trap_99_99_06_0929",119.485710f,3.600000f,119.485710f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_391",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", 44, 391, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_create_object_trap(myObj, "GroundMesh1");
		AddTrapLink(myObj,"outofrange_99_99_06_0000");
		
		myObj= CreateGameObject("a_move_trigger_03_42_06_0931",4.200000f,3.600000f,51.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,2,42,"a_change_terrain_trap_02_42_06_0943");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 943, 2, 42, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_look_trigger_99_99_06_0933",119.314285f,0.000000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_419",false);
		CreateTrigger(myObj,8,58,"a_change_terrain_trap_08_58_06_0934");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_419", "Sprites/OBJECTS_419", "Sprites/OBJECTS_419", 57, 419, 934, 8, 58, 0, 0, 0, 1, 1, 0, 4, 1);
		
		myObj= CreateGameObject("a_change_terrain_trap_08_58_06_0934",9.600000f,3.600000f,69.599998f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_389",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_389", "Sprites/OBJECTS_389", "Sprites/OBJECTS_389", 42, 389, 936, 11, 63, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_change_terrain_trap(myObj,8,58,0,0);
		AddTrapLink(myObj,"a_delete_object_trap_99_99_06_0936");
		
		myObj= CreateGameObject("a_delete_object_trap_99_99_06_0936",118.800003f,0.000000f,118.800003f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_395",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_395", "Sprites/OBJECTS_395", "Sprites/OBJECTS_395", 48, 395, 935, 8, 57, 0, 0, 0, 1, 1, 0, 0, 1);
		SetRotation(myObj,0,0,0);
		Create_a_delete_object_trap(myObj);
		AddTrapLink(myObj,"special_tmap_obj_08_57_06_0935");
		
		myObj= CreateGameObject("a_change_terrain_trap_26_35_06_0941",31.200001f,3.600000f,42.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_389",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_389", "Sprites/OBJECTS_389", "Sprites/OBJECTS_389", 42, 389, 752, 11, 63, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_change_terrain_trap(myObj,26,35,0,0);
		AddTrapLink(myObj,"a_move_trigger_99_99_06_0752");
		
		myObj= CreateGameObject("a_change_terrain_trap_02_42_06_0943",2.571429f,3.000000f,50.571430f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_389",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_389", "Sprites/OBJECTS_389", "Sprites/OBJECTS_389", 42, 389, 0, 11, 63, 0, 0, 0, 1, 0, 0, 2, 1);
		SetRotation(myObj,0,0,0);
		Create_a_change_terrain_trap(myObj,2,42,1,1);
		
		myObj= CreateGameObject("a_move_trigger_32_26_06_0949",39.000000f,0.000000f,31.799999f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,31,26,"a_teleport_trap_31_26_06_0951");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 951, 31, 26, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_teleport_trap_40_19_06_0950",48.000000f,0.000000f,22.799999f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_385",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_385", "Sprites/OBJECTS_385", "Sprites/OBJECTS_385", 38, 385, 0, 34, 20, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_teleport_trap(myObj,(float)41.400000,(float)24.600000,(float)3.300000,0);
		
		myObj= CreateGameObject("a_teleport_trap_31_26_06_0951",37.200001f,0.000000f,31.200001f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_385",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_385", "Sprites/OBJECTS_385", "Sprites/OBJECTS_385", 38, 385, 0, 38, 30, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_teleport_trap(myObj,(float)46.200000,(float)36.600000,(float)3.300000,0);
		
		myObj= CreateGameObject("a_move_trigger_40_20_06_0952",48.599998f,0.000000f,24.600000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,40,19,"a_teleport_trap_40_19_06_0950");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 950, 40, 19, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_move_trigger_58_53_06_0954",70.199997f,3.600000f,64.199997f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,58,52,"a_teleport_trap_58_52_06_0955");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 955, 58, 52, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_teleport_trap_58_52_06_0955",69.599998f,0.300000f,62.400002f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_385",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_385", "Sprites/OBJECTS_385", "Sprites/OBJECTS_385", 38, 385, 0, 58, 50, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_teleport_trap(myObj,(float)70.200000,(float)60.600000,(float)4.500000,8);
		
		myObj= CreateGameObject("a_move_trigger_57_62_06_0957",69.000000f,2.400000f,75.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,58,62,"a_teleport_trap_58_62_06_0958");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 958, 58, 62, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_teleport_trap_58_62_06_0958",69.599998f,0.300000f,74.400002f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_385",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_385", "Sprites/OBJECTS_385", "Sprites/OBJECTS_385", 38, 385, 0, 60, 62, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_teleport_trap(myObj,(float)72.600000,(float)75.000000,(float)3.900000,8);
		
		myObj= CreateGameObject("a_move_trigger_60_02_06_0960",72.599998f,3.300000f,3.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,59,2,"a_teleport_trap_59_02_06_0961");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 961, 59, 2, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_teleport_trap_59_02_06_0961",70.800003f,0.300000f,2.400000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_385",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_385", "Sprites/OBJECTS_385", "Sprites/OBJECTS_385", 38, 385, 0, 59, 2, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_teleport_trap(myObj,(float)71.400000,(float)3.000000,(float)3.300000,8);
		
		myObj= CreateGameObject("a_teleport_trap_38_48_06_0962",45.599998f,0.300000f,57.599998f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_385",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_385", "Sprites/OBJECTS_385", "Sprites/OBJECTS_385", 38, 385, 0, 38, 47, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_teleport_trap(myObj,(float)46.200000,(float)57.000000,(float)2.700000,8);
		
		myObj= CreateGameObject("a_move_trigger_38_49_06_0964",46.200001f,0.000000f,59.400002f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,38,48,"a_teleport_trap_38_48_06_0962");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 962, 38, 48, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_change_terrain_trap_60_55_06_0968",72.000000f,3.600000f,66.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_389",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_389", "Sprites/OBJECTS_389", "Sprites/OBJECTS_389", 42, 389, 871, 11, 63, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_change_terrain_trap(myObj,60,55,0,0);
		AddTrapLink(myObj,"a_move_trigger_99_99_06_0871");
		
		myObj= CreateGameObject("a_move_trigger_35_40_06_0978",42.599998f,1.500000f,48.599998f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,35,42,"a_teleport_trap_35_42_06_0979");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 979, 35, 42, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_teleport_trap_35_42_06_0979",42.000000f,0.300000f,50.400002f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_385",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_385", "Sprites/OBJECTS_385", "Sprites/OBJECTS_385", 38, 385, 0, 35, 44, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_teleport_trap(myObj,(float)42.600000,(float)53.400000,(float)0.000000,8);
		
		myObj= CreateGameObject("a_move_trigger_03_61_06_0980",4.200000f,3.600000f,73.800003f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,4,61,"a_teleport_trap_04_61_06_0981");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 981, 4, 61, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_teleport_trap_04_61_06_0981",4.800000f,0.225000f,73.199997f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_385",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_385", "Sprites/OBJECTS_385", "Sprites/OBJECTS_385", 38, 385, 0, 5, 61, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_teleport_trap(myObj,(float)6.600000,(float)73.800000,(float)3.600000,6);
		
		myObj= CreateGameObject("a_move_trigger_19_12_06_0982",23.400000f,3.600000f,15.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,19,11,"a_teleport_trap_19_11_06_0983");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 983, 19, 11, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_teleport_trap_19_11_06_0983",22.799999f,0.225000f,13.200000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_385",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_385", "Sprites/OBJECTS_385", "Sprites/OBJECTS_385", 38, 385, 0, 18, 10, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_teleport_trap(myObj,(float)22.200000,(float)12.600000,(float)0.300000,6);
		
		myObj= CreateGameObject("a_move_trigger_03_43_06_0999",4.200000f,3.600000f,52.200001f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,2,42,"a_change_terrain_trap_02_42_06_0943");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 943, 2, 42, 0, 0, 0, 1, 1, 0, 6, 1);
		
		//Supplementary object 0
		//Supplementary object 169
		myObj = new GameObject("a_shadow_beast_99_99_06_0169");
		pos = new Vector3(119.314285f, 3.300000f, 119.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"117","Sprites/OBJECTS_117", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_117", "Sprites/OBJECTS_117", "Sprites/OBJECTS_117", 0, 117, 0, 33, 40, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 33, 40, 0, 0, 140, 0, 0, 4, 0, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		//Supplementary object 172
		myObj = new GameObject("a_great_troll_99_99_06_0172");
		pos = new Vector3(119.314285f, 2.700000f, 119.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"112","Sprites/OBJECTS_112", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_112", "Sprites/OBJECTS_112", "Sprites/OBJECTS_112", 0, 112, 0, 52, 59, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 52, 59, 0, 0, 98, 0, 0, 4, 0, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		//Supplementary object 185
		myObj = new GameObject("a_ghost_99_99_06_0185");
		pos = new Vector3(119.314285f, 3.450000f, 119.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"97","Sprites/OBJECTS_097", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_097", "Sprites/OBJECTS_097", "Sprites/OBJECTS_097", 0, 97, 0, 19, 35, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 19, 35, 0, 0, 84, 0, 0, 4, 0, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		//Supplementary object 186
		myObj = new GameObject("a_ghost_99_99_06_0186");
		pos = new Vector3(119.314285f, 3.450000f, 119.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"97","Sprites/OBJECTS_097", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_097", "Sprites/OBJECTS_097", "Sprites/OBJECTS_097", 0, 97, 0, 19, 34, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 19, 34, 0, 0, 104, 0, 0, 4, 0, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		//Supplementary object 188
		myObj = new GameObject("a_dire_ghost_99_99_06_0188");
		pos = new Vector3(119.314285f, 3.150000f, 119.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"113","Sprites/OBJECTS_113", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_113", "Sprites/OBJECTS_113", "Sprites/OBJECTS_113", 0, 113, 0, 51, 54, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 51, 54, 0, 0, 70, 0, 0, 4, 0, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		//Supplementary object 190
		myObj = new GameObject("a_gazer_99_99_06_0190");
		pos = new Vector3(119.314285f, 3.900000f, 119.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"102","Sprites/OBJECTS_102", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_102", "Sprites/OBJECTS_102", "Sprites/OBJECTS_102", 0, 102, 0, 42, 57, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 42, 57, 0, 0, 73, 0, 0, 4, 0, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		//Supplementary object 194
		myObj = new GameObject("a_reaper_99_99_06_0194");
		pos = new Vector3(119.314285f, 3.600000f, 119.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"118","Sprites/OBJECTS_118", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_118", "Sprites/OBJECTS_118", "Sprites/OBJECTS_118", 0, 118, 0, 33, 8, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 33, 8, 0, 0, 40, 0, 0, 4, 0, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		//Supplementary object 199
		myObj = new GameObject("a_dread_spider_99_99_06_0199");
		pos = new Vector3(119.314285f, 3.600000f, 119.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"92","Sprites/OBJECTS_092", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_092", "Sprites/OBJECTS_092", "Sprites/OBJECTS_092", 0, 92, 0, 3, 41, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 3, 41, 0, 0, 32, 0, 0, 4, 0, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		//Supplementary object 204
		myObj = new GameObject("a_dread_spider_99_99_06_0204");
		pos = new Vector3(119.314285f, 3.600000f, 119.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"92","Sprites/OBJECTS_092", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_092", "Sprites/OBJECTS_092", "Sprites/OBJECTS_092", 0, 92, 0, 4, 43, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 4, 43, 0, 0, 28, 0, 0, 4, 0, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		//Supplementary object 207
		myObj = new GameObject("a_dread_spider_99_99_06_0207");
		pos = new Vector3(119.314285f, 3.600000f, 119.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"92","Sprites/OBJECTS_092", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_092", "Sprites/OBJECTS_092", "Sprites/OBJECTS_092", 0, 92, 0, 13, 43, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 13, 43, 0, 0, 37, 0, 0, 4, 0, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		//Supplementary object 210
		myObj = new GameObject("a_dread_spider_99_99_06_0210");
		pos = new Vector3(119.314285f, 3.600000f, 119.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"92","Sprites/OBJECTS_092", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_092", "Sprites/OBJECTS_092", "Sprites/OBJECTS_092", 0, 92, 0, 15, 40, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 15, 40, 0, 0, 33, 0, 0, 4, 0, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		//Supplementary object 237
		myObj = new GameObject("a_fire_elemental_99_99_06_0237");
		pos = new Vector3(119.314285f, 0.000000f, 119.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"120","Sprites/OBJECTS_120", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_120", "Sprites/OBJECTS_120", "Sprites/OBJECTS_120", 0, 120, 0, 35, 56, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 35, 56, 0, 0, 74, 0, 0, 2, 0, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		//Supplementary object 239
		myObj = new GameObject("a_fire_elemental_99_99_06_0239");
		pos = new Vector3(119.314285f, 0.000000f, 119.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"120","Sprites/OBJECTS_120", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_120", "Sprites/OBJECTS_120", "Sprites/OBJECTS_120", 0, 120, 0, 60, 43, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 60, 43, 0, 0, 67, 0, 0, 2, 0, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		//Supplementary object 253
		myObj = new GameObject("a_dread_spider_99_99_06_0253");
		pos = new Vector3(119.314285f, 3.000000f, 119.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"92","Sprites/OBJECTS_092", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_092", "Sprites/OBJECTS_092", "Sprites/OBJECTS_092", 0, 92, 0, 11, 39, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 11, 39, 0, 0, 43, 0, 0, 4, 0, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		//Supplementary object 341
		myObj= CreateGameObject("some_strong_thread_pieces_of_strong_thread_99_99_06_0341",119.314285f,2.400000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_284",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_284", "Sprites/OBJECTS_284", "Sprites/OBJECTS_284", 16, 284, 2, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		//Supplementary object 375
		myObj= CreateGameObject("an_arrow_99_99_06_0375",119.314285f,3.000000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_018",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_018", "Sprites/OBJECTS_018", "Sprites/OBJECTS_018", 1, 18, 19, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		CreateWeapon(myObj, -842150451, -842150451, -842150451, -842150451, -842150451);
		//Supplementary object 381
		myObj= CreateGameObject("a_block_of_incense_blocks_of_incense_99_99_06_0381",119.314285f,2.400000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_278",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_278", "Sprites/OBJECTS_278", "Sprites/OBJECTS_278", 16, 278, 5, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		//Supplementary object 382
		myObj= CreateGameObject("a_medallion_99_99_06_0382",119.314285f,2.400000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_300",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_300", "Sprites/OBJECTS_300", "Sprites/OBJECTS_300", 16, 300, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		//Supplementary object 408
		//Supplementary object 409
		//Supplementary object 421
		myObj= CreateGameObject("an_apple_99_99_06_0421",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_179",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_179", "Sprites/OBJECTS_179", "Sprites/OBJECTS_179", 24, 179, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetFood(myObj);
		//Supplementary object 422
		myObj= CreateGameObject("a_piece_of_meat_pieces_of_meat_99_99_06_0422",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_176",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_176", "Sprites/OBJECTS_176", "Sprites/OBJECTS_176", 24, 176, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetFood(myObj);
		//Supplementary object 424
		myObj= CreateGameObject("a_fish_fish_99_99_06_0424",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_182",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_182", "Sprites/OBJECTS_182", "Sprites/OBJECTS_182", 24, 182, 3, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetFood(myObj);
		//Supplementary object 429
		myObj= CreateGameObject("a_red_gem_99_99_06_0429",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_163",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_163", "Sprites/OBJECTS_163", "Sprites/OBJECTS_163", 18, 163, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		//Supplementary object 434
		//Supplementary object 476
		myObj= CreateGameObject("a_key_99_99_06_0476",119.314285f,2.400000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_269",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_269", "Sprites/OBJECTS_269", "Sprites/OBJECTS_269", 5, 269, 1, 40, 23, 1, 1, 0, 1, 1, 0, 0, 1);
		CreateKey(myObj, 23);
		//Supplementary object 578
		myObj= CreateGameObject("a_crown_99_99_06_0578",119.314285f,2.400000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_048",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_048", "Sprites/OBJECTS_048", "Sprites/armour/armor_f_0061", 73, 48, 0, 50, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		CreateHelm(myObj, "Sprites/armour/armor_f_0061", "Sprites/armour/armor_m_0061", "Sprites/armour/armor_f_0061", "Sprites/armour/armor_m_0061", "Sprites/armour/armor_f_0061", "Sprites/armour/armor_m_0061", "Sprites/armour/armor_f_0061", "Sprites/armour/armor_m_0061", 6099796, 6099832);
		//Supplementary object 580
		myObj= CreateGameObject("a_pile_of_bones_piles_of_bones_99_99_06_0580",118.971428f,2.400000f,119.657135f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_198",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_198", "Sprites/OBJECTS_198", "Sprites/OBJECTS_198", 23, 198, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		//Supplementary object 583
		myObj= CreateGameObject("a_skull_99_99_06_0583",119.828575f,2.400000f,118.971428f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_194",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_194", "Sprites/OBJECTS_194", "Sprites/OBJECTS_194", 23, 194, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		//Supplementary object 651
		myObj= CreateGameObject("a_key_99_99_06_0651",119.314285f,3.300000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_269",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_269", "Sprites/OBJECTS_269", "Sprites/OBJECTS_269", 5, 269, 1, 40, 23, 1, 1, 0, 1, 1, 0, 0, 1);
		CreateKey(myObj, 23);
		//Supplementary object 658
		//Supplementary object 662
		//Supplementary object 666
		myObj= CreateGameObject("a_scroll_99_99_06_0666",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_314",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_314", "Sprites/OBJECTS_314", "Sprites/OBJECTS_314", 13, 314, 709, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetReadable(myObj);
		SetLink(myObj,709);
		//Supplementary object 669
		//Supplementary object 740
		myObj= CreateGameObject("a_large_boulder_99_99_06_0740",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_340",true);
		//Supplementary object 819
		//Supplementary object 845
		//Supplementary object 864
		myObj= CreateGameObject("a_gold_coin_99_99_06_0864",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_161",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", 18, 161, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		//Supplementary object 877
		myObj= CreateGameObject("a_key_99_99_06_0877",119.314285f,2.400000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_260",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_260", "Sprites/OBJECTS_260", "Sprites/OBJECTS_260", 5, 260, 1, 40, 27, 1, 1, 0, 1, 1, 0, 0, 1);
		CreateKey(myObj, 27);
		//Supplementary object 890
		myObj= CreateGameObject("a_key_99_99_06_0890",119.314285f,3.300000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_264",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_264", "Sprites/OBJECTS_264", "Sprites/OBJECTS_264", 5, 264, 1, 40, 26, 1, 1, 0, 1, 1, 0, 0, 1);
		CreateKey(myObj, 26);
		//Supplementary object 892
		myObj= CreateGameObject("a_picture_of_Tom_99_99_06_0892",119.314285f,3.300000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_272",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_272", "Sprites/OBJECTS_272", "Sprites/OBJECTS_272", 16, 272, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		//Supplementary object 903
		myObj= CreateGameObject("a_crystal_splinter_99_99_06_0903",119.314285f,3.300000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_273",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_273", "Sprites/OBJECTS_273", "Sprites/OBJECTS_273", 16, 273, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		//Supplementary object 1017
		myObj= CreateGameObject("a_gold_coin_99_99_06_1017",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_161",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", 18, 161, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		//Supplementary object 1018
		myObj= CreateGameObject("a_gold_coin_99_99_06_1018",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_161",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", 18, 161, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);		
		


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


	[MenuItem("MyTools/CreateAnim")]
	static void GenerateAnimationAssets()
	{
		return;
		//TODO: Update export code to include basepath and time.
		CreateAnimationUW("64_attack_slash", "CR26PAGE_N00_0_0004" , "CR26PAGE_N00_0_0005" , "CR26PAGE_N00_0_0006" , "CR26PAGE_N00_0_0005" , "" , "" , "" , "" ,4,"Sprites/critters",0.4f);
		CreateAnimationUW("64_attack_thrust", "CR26PAGE_N00_0_0004" , "CR26PAGE_N00_0_0005" , "CR26PAGE_N00_0_0006" , "CR26PAGE_N00_0_0005" , "" , "" , "" , "" ,4,"Sprites/critters",0.4f);
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
	[MenuItem("MyTools/TagTilesByName")]
	static void TagTilesByRoom()
	{
		SetTileTag(5,63,"SOLIDWALL",1);SetTileTag(10,63,"SOLIDWALL",1);SetTileTag(17,63,"SOLIDWALL",1);SetTileTag(22,63,"SOLIDWALL",1);SetTileTag(35,63,"SOLIDWALL",1);SetTileTag(44,63,"SOLIDWALL",1);SetTileTag(45,63,"SOLIDWALL",1);SetTileTag(54,63,"SOLIDWALL",1);SetTileTag(56,63,"SOLIDWALL",1);SetTileTag(60,63,"SOLIDWALL",1);SetTileTag(61,63,"SOLIDWALL",1);
		SetTileTag(1,62,"SOLIDWALL",1);SetTileTag(4,62,"SOLIDWALL",1);SetTileTag(6,62,"LAND_2", 1);SetTileTag(7,62,"LAND_2", 1);SetTileTag(9,62,"SOLIDWALL",1);SetTileTag(10,62,"LAND_5", 1);SetTileTag(13,62,"LAND_5", 1);SetTileTag(14,62,"SOLIDWALL",1);SetTileTag(15,62,"SOLIDWALL",1);SetTileTag(16,62,"SOLIDWALL",1);SetTileTag(17,62,"LAND_5", 1);SetTileTag(20,62,"SOLIDWALL",1);SetTileTag(21,62,"SOLIDWALL",1);SetTileTag(22,62,"LAND_9", 1);SetTileTag(23,62,"LAND_9", 1);SetTileTag(24,62,"LAND_9", 1);SetTileTag(26,62,"LAVA_3", 1);SetTileTag(27,62,"LAVA_3", 1);SetTileTag(28,62,"LAVA_3", 1);SetTileTag(29,62,"LAVA_3", 1);SetTileTag(30,62,"LAVA_3", 1);SetTileTag(31,62,"LAVA_3", 1);SetTileTag(32,62,"LAVA_3", 1);SetTileTag(33,62,"SOLIDWALL",1);SetTileTag(34,62,"SOLIDWALL",1);SetTileTag(35,62,"LAVA_3", 1);SetTileTag(36,62,"LAVA_3", 1);SetTileTag(45,62,"LAND_1", 1);SetTileTag(46,62,"LAND_1", 1);SetTileTag(47,62,"SOLIDWALL",1);SetTileTag(48,62,"SOLIDWALL",1);SetTileTag(49,62,"SOLIDWALL",1);SetTileTag(53,62,"SOLIDWALL",1);SetTileTag(55,62,"LAND_1", 1);SetTileTag(56,62,"LAND_1", 1);SetTileTag(57,62,"LAND_1", 1);SetTileTag(58,62,"SOLIDWALL",1);SetTileTag(59,62,"SOLIDWALL",1);SetTileTag(60,62,"LAND_1", 1);SetTileTag(61,62,"LAND_1", 1);
		SetTileTag(2,61,"LAND_2", 1);SetTileTag(4,61,"SOLIDWALL",1);SetTileTag(6,61,"SOLIDWALL",1);SetTileTag(7,61,"LAND_2", 1);SetTileTag(9,61,"LAND_5", 1);SetTileTag(10,61,"LAND_5", 1);SetTileTag(11,61,"LAND_5", 1);SetTileTag(12,61,"LAND_5", 1);SetTileTag(13,61,"LAND_5", 1);SetTileTag(14,61,"LAND_5", 1);SetTileTag(15,61,"LAND_5", 1);SetTileTag(16,61,"LAND_5", 1);SetTileTag(17,61,"LAND_5", 1);SetTileTag(20,61,"LAND_9", 1);SetTileTag(21,61,"LAND_9", 1);SetTileTag(22,61,"LAND_9", 1);SetTileTag(23,61,"LAND_9", 1);SetTileTag(26,61,"LAND_1", 1);SetTileTag(27,61,"LAND_1", 1);SetTileTag(28,61,"LAND_1", 1);SetTileTag(29,61,"SOLIDWALL",1);SetTileTag(30,61,"LAVA_3", 1);SetTileTag(31,61,"LAVA_3", 1);SetTileTag(32,61,"LAVA_3", 1);SetTileTag(33,61,"LAVA_3", 1);SetTileTag(34,61,"LAVA_3", 1);SetTileTag(36,61,"LAVA_3", 1);SetTileTag(40,61,"SOLIDWALL",1);SetTileTag(43,61,"SOLIDWALL",1);SetTileTag(44,61,"LAND_1", 1);SetTileTag(45,61,"SOLIDWALL",1);SetTileTag(46,61,"LAND_1", 1);SetTileTag(47,61,"SOLIDWALL",1);SetTileTag(48,61,"LAND_1", 1);SetTileTag(49,61,"LAND_1", 1);SetTileTag(50,61,"LAND_1", 1);SetTileTag(51,61,"LAND_1", 1);SetTileTag(53,61,"SOLIDWALL",1);SetTileTag(55,61,"LAND_1", 1);SetTileTag(56,61,"SOLIDWALL",1);SetTileTag(58,61,"SOLIDWALL",1);SetTileTag(59,61,"LAND_1", 1);SetTileTag(60,61,"LAND_1", 1);SetTileTag(61,61,"SOLIDWALL",1);
		SetTileTag(2,60,"SOLIDWALL",1);SetTileTag(3,60,"SOLIDWALL",1);SetTileTag(4,60,"SOLIDWALL",1);SetTileTag(6,60,"SOLIDWALL",1);SetTileTag(7,60,"LAVA_1", 1);SetTileTag(8,60,"LAVA_1", 1);SetTileTag(9,60,"SOLIDWALL",1);SetTileTag(10,60,"LAND_5", 1);SetTileTag(11,60,"LAND_5", 1);SetTileTag(12,60,"LAND_5", 1);SetTileTag(14,60,"SOLIDWALL",1);SetTileTag(15,60,"SOLIDWALL",1);SetTileTag(16,60,"SOLIDWALL",1);SetTileTag(17,60,"LAND_5", 1);SetTileTag(18,60,"LAVA_2", 1);SetTileTag(19,60,"LAVA_2", 1);SetTileTag(20,60,"SOLIDWALL",1);SetTileTag(21,60,"LAVA_3", 1);SetTileTag(22,60,"LAVA_3", 1);SetTileTag(24,60,"LAVA_3", 1);SetTileTag(25,60,"LAVA_3", 1);SetTileTag(26,60,"LAVA_3", 1);SetTileTag(27,60,"LAND_1", 1);SetTileTag(28,60,"LAND_1", 1);SetTileTag(30,60,"SOLIDWALL",1);SetTileTag(31,60,"LAVA_3", 1);SetTileTag(32,60,"SOLIDWALL",1);SetTileTag(33,60,"SOLIDWALL",1);SetTileTag(34,60,"LAVA_3", 1);SetTileTag(36,60,"LAVA_3", 1);SetTileTag(37,60,"SOLIDWALL",1);SetTileTag(39,60,"SOLIDWALL",1);SetTileTag(40,60,"LAND_1", 1);SetTileTag(41,60,"SOLIDWALL",1);SetTileTag(44,60,"SOLIDWALL",1);SetTileTag(45,60,"SOLIDWALL",1);SetTileTag(46,60,"LAND_1", 1);SetTileTag(47,60,"LAND_1", 1);SetTileTag(49,60,"LAND_1", 1);SetTileTag(50,60,"LAND_1", 1);SetTileTag(51,60,"SOLIDWALL",1);SetTileTag(52,60,"LAND_1", 1);SetTileTag(53,60,"SOLIDWALL",1);SetTileTag(55,60,"SOLIDWALL",1);SetTileTag(56,60,"LAND_1", 1);SetTileTag(60,60,"LAND_1", 1);SetTileTag(61,60,"LAND_1", 1);
		SetTileTag(0,59,"SOLIDWALL",1);SetTileTag(1,59,"LAND_2", 1);SetTileTag(2,59,"LAND_2", 1);SetTileTag(5,59,"LAND_2", 1);SetTileTag(6,59,"SOLIDWALL",1);SetTileTag(7,59,"LAND_5", 1);SetTileTag(10,59,"LAND_5", 1);SetTileTag(11,59,"LAND_5", 1);SetTileTag(12,59,"LAND_5", 1);SetTileTag(13,59,"LAND_5", 1);SetTileTag(14,59,"LAND_5", 1);SetTileTag(15,59,"LAND_5", 1);SetTileTag(18,59,"LAND_5", 1);SetTileTag(19,59,"SOLIDWALL",1);SetTileTag(20,59,"SOLIDWALL",1);SetTileTag(21,59,"SOLIDWALL",1);SetTileTag(22,59,"SOLIDWALL",1);SetTileTag(23,59,"LAVA_3", 1);SetTileTag(24,59,"LAVA_3", 1);SetTileTag(25,59,"SOLIDWALL",1);SetTileTag(26,59,"SOLIDWALL",1);SetTileTag(27,59,"SOLIDWALL",1);SetTileTag(29,59,"LAND_1", 1);SetTileTag(30,59,"LAND_1", 1);SetTileTag(32,59,"SOLIDWALL",1);SetTileTag(33,59,"SOLIDWALL",1);SetTileTag(36,59,"SOLIDWALL",1);SetTileTag(38,59,"SOLIDWALL",1);SetTileTag(39,59,"LAND_1", 1);SetTileTag(40,59,"LAND_1", 1);SetTileTag(41,59,"LAND_1", 1);SetTileTag(42,59,"SOLIDWALL",1);SetTileTag(44,59,"SOLIDWALL",1);SetTileTag(47,59,"SOLIDWALL",1);SetTileTag(49,59,"LAND_1", 1);SetTileTag(50,59,"LAND_1", 1);SetTileTag(54,59,"LAND_1", 1);SetTileTag(55,59,"LAND_1", 1);SetTileTag(57,59,"LAND_1", 1);SetTileTag(58,59,"LAND_1", 1);SetTileTag(59,59,"LAND_1", 1);SetTileTag(60,59,"LAND_1", 1);SetTileTag(61,59,"SOLIDWALL",1);SetTileTag(62,59,"LAND_1", 1);SetTileTag(63,59,"SOLIDWALL",1);
		SetTileTag(1,58,"SOLIDWALL",1);SetTileTag(2,58,"SOLIDWALL",1);SetTileTag(3,58,"SOLIDWALL",1);SetTileTag(7,58,"SOLIDWALL",1);SetTileTag(8,58,"SOLIDWALL",1);SetTileTag(9,58,"SOLIDWALL",1);SetTileTag(10,58,"SOLIDWALL",1);SetTileTag(11,58,"SOLIDWALL",1);SetTileTag(12,58,"SOLIDWALL",1);SetTileTag(13,58,"SOLIDWALL",1);SetTileTag(14,58,"SOLIDWALL",1);SetTileTag(15,58,"SOLIDWALL",1);SetTileTag(16,58,"SOLIDWALL",1);SetTileTag(17,58,"SOLIDWALL",1);SetTileTag(18,58,"SOLIDWALL",1);SetTileTag(19,58,"LAND_1", 1);SetTileTag(21,58,"SOLIDWALL",1);SetTileTag(22,58,"SOLIDWALL",1);SetTileTag(23,58,"SOLIDWALL",1);SetTileTag(24,58,"SOLIDWALL",1);SetTileTag(25,58,"SOLIDWALL",1);SetTileTag(27,58,"SOLIDWALL",1);SetTileTag(28,58,"SOLIDWALL",1);SetTileTag(29,58,"SOLIDWALL",1);SetTileTag(30,58,"LAND_1", 1);SetTileTag(32,58,"SOLIDWALL",1);SetTileTag(37,58,"SOLIDWALL",1);SetTileTag(39,58,"LAND_1", 1);SetTileTag(41,58,"LAND_1", 1);SetTileTag(49,58,"SOLIDWALL",1);SetTileTag(50,58,"SOLIDWALL",1);SetTileTag(51,58,"SOLIDWALL",1);SetTileTag(52,58,"LAND_1", 1);SetTileTag(53,58,"SOLIDWALL",1);SetTileTag(54,58,"LAND_1", 1);SetTileTag(55,58,"SOLIDWALL",1);SetTileTag(56,58,"LAND_1", 1);SetTileTag(57,58,"LAND_1", 1);SetTileTag(58,58,"SOLIDWALL",1);SetTileTag(59,58,"SOLIDWALL",1);SetTileTag(60,58,"SOLIDWALL",1);SetTileTag(61,58,"SOLIDWALL",1);SetTileTag(62,58,"SOLIDWALL",1);
		SetTileTag(6,57,"SOLIDWALL",1);SetTileTag(7,57,"LAND_1", 1);SetTileTag(9,57,"SOLIDWALL",1);SetTileTag(11,57,"SOLIDWALL",1);SetTileTag(12,57,"LAND_1", 1);SetTileTag(14,57,"SOLIDWALL",1);SetTileTag(15,57,"LAND_1", 1);SetTileTag(17,57,"SOLIDWALL",1);SetTileTag(18,57,"SOLIDWALL",1);SetTileTag(19,57,"LAND_1", 1);SetTileTag(20,57,"SOLIDWALL",1);SetTileTag(21,57,"SOLIDWALL",1);SetTileTag(24,57,"SOLIDWALL",1);SetTileTag(28,57,"LAND_1", 1);SetTileTag(29,57,"LAND_1", 1);SetTileTag(30,57,"LAND_1", 1);SetTileTag(31,57,"LAND_1", 1);SetTileTag(32,57,"LAND_1", 1);SetTileTag(37,57,"LAND_1", 1);SetTileTag(38,57,"LAND_1", 1);SetTileTag(39,57,"LAND_1", 1);SetTileTag(40,57,"LAND_1", 1);SetTileTag(41,57,"LAND_1", 1);SetTileTag(42,57,"LAND_1", 1);SetTileTag(43,57,"LAND_1", 1);SetTileTag(44,57,"LAND_1", 1);SetTileTag(47,57,"LAND_1", 1);SetTileTag(49,57,"LAND_1", 1);SetTileTag(50,57,"LAND_1", 1);SetTileTag(53,57,"LAND_1", 1);SetTileTag(54,57,"SOLIDWALL",1);SetTileTag(55,57,"SOLIDWALL",1);SetTileTag(56,57,"SOLIDWALL",1);SetTileTag(57,57,"SOLIDWALL",1);SetTileTag(59,57,"LAND_6", 1);SetTileTag(60,57,"LAND_6", 1);
		SetTileTag(2,56,"SOLIDWALL",1);SetTileTag(3,56,"SOLIDWALL",1);SetTileTag(5,56,"SOLIDWALL",1);SetTileTag(7,56,"SOLIDWALL",1);SetTileTag(8,56,"LAND_1", 1);SetTileTag(9,56,"SOLIDWALL",1);SetTileTag(10,56,"SOLIDWALL",1);SetTileTag(12,56,"SOLIDWALL",1);SetTileTag(13,56,"LAND_1", 1);SetTileTag(14,56,"SOLIDWALL",1);SetTileTag(15,56,"LAND_1", 1);SetTileTag(16,56,"SOLIDWALL",1);SetTileTag(18,56,"LAND_1", 1);SetTileTag(21,56,"LAND_1", 1);SetTileTag(24,56,"LAND_1", 1);SetTileTag(28,56,"SOLIDWALL",1);SetTileTag(30,56,"SOLIDWALL",1);SetTileTag(31,56,"LAND_1", 1);SetTileTag(32,56,"SOLIDWALL",1);SetTileTag(33,56,"LAND_1", 1);SetTileTag(36,56,"LAND_1", 1);SetTileTag(37,56,"SOLIDWALL",1);SetTileTag(39,56,"SOLIDWALL",1);SetTileTag(40,56,"LAND_1", 1);SetTileTag(41,56,"SOLIDWALL",1);SetTileTag(42,56,"SOLIDWALL",1);SetTileTag(44,56,"SOLIDWALL",1);SetTileTag(45,56,"LAND_1", 1);SetTileTag(47,56,"SOLIDWALL",1);SetTileTag(49,56,"SOLIDWALL",1);SetTileTag(50,56,"SOLIDWALL",1);SetTileTag(51,56,"SOLIDWALL",1);SetTileTag(52,56,"LAND_1", 1);SetTileTag(53,56,"SOLIDWALL",1);SetTileTag(54,56,"LAND_6", 1);SetTileTag(56,56,"LAND_6", 1);SetTileTag(57,56,"LAND_6", 1);SetTileTag(58,56,"LAND_6", 1);SetTileTag(60,56,"LAND_6", 1);SetTileTag(61,56,"LAND_6", 1);SetTileTag(62,56,"SOLIDWALL",1);
		SetTileTag(1,55,"SOLIDWALL",1);SetTileTag(2,55,"LAND_1", 1);SetTileTag(4,55,"SOLIDWALL",1);SetTileTag(5,55,"LAND_1", 1);SetTileTag(7,55,"SOLIDWALL",1);SetTileTag(8,55,"LAND_1", 1);SetTileTag(9,55,"LAND_1", 1);SetTileTag(11,55,"LAND_1", 1);SetTileTag(17,55,"LAND_1", 1);SetTileTag(19,55,"LAND_1", 1);SetTileTag(20,55,"SOLIDWALL",1);SetTileTag(22,55,"LAND_1", 1);SetTileTag(23,55,"LAND_1", 1);SetTileTag(24,55,"SOLIDWALL",1);SetTileTag(25,55,"LAND_1", 1);SetTileTag(26,55,"LAND_1", 1);SetTileTag(27,55,"LAND_1", 1);SetTileTag(28,55,"LAND_1", 1);SetTileTag(29,55,"SOLIDWALL",1);SetTileTag(30,55,"SOLIDWALL",1);SetTileTag(32,55,"SOLIDWALL",1);SetTileTag(33,55,"SOLIDWALL",1);SetTileTag(35,55,"LAVA_3", 1);SetTileTag(36,55,"SOLIDWALL",1);SetTileTag(38,55,"SOLIDWALL",1);SetTileTag(39,55,"LAND_1", 1);SetTileTag(40,55,"LAND_1", 1);SetTileTag(41,55,"LAND_1", 1);SetTileTag(45,55,"SOLIDWALL",1);SetTileTag(46,55,"LAND_1", 1);SetTileTag(47,55,"LAND_1", 1);SetTileTag(48,55,"LAND_1", 1);SetTileTag(49,55,"LAND_1", 1);SetTileTag(50,55,"LAND_1", 1);SetTileTag(51,55,"SOLIDWALL",1);SetTileTag(52,55,"SOLIDWALL",1);SetTileTag(53,55,"LAND_6", 1);SetTileTag(55,55,"LAND_6", 1);SetTileTag(56,55,"SOLIDWALL",1);SetTileTag(58,55,"LAND_6", 1);SetTileTag(59,55,"SOLIDWALL",1);SetTileTag(60,55,"SOLIDWALL",1);SetTileTag(61,55,"SOLIDWALL",1);
		SetTileTag(1,54,"SOLIDWALL",1);SetTileTag(2,54,"SOLIDWALL",1);SetTileTag(3,54,"LAND_1", 1);SetTileTag(4,54,"SOLIDWALL",1);SetTileTag(5,54,"LAND_1", 1);SetTileTag(6,54,"SOLIDWALL",1);SetTileTag(7,54,"SOLIDWALL",1);SetTileTag(8,54,"SOLIDWALL",1);SetTileTag(9,54,"SOLIDWALL",1);SetTileTag(11,54,"SOLIDWALL",1);SetTileTag(12,54,"SOLIDWALL",1);SetTileTag(13,54,"LAND_1", 1);SetTileTag(14,54,"SOLIDWALL",1);SetTileTag(15,54,"LAND_1", 1);SetTileTag(16,54,"SOLIDWALL",1);SetTileTag(18,54,"SOLIDWALL",1);SetTileTag(19,54,"LAND_1", 1);SetTileTag(21,54,"SOLIDWALL",1);SetTileTag(22,54,"SOLIDWALL",1);SetTileTag(23,54,"SOLIDWALL",1);SetTileTag(24,54,"SOLIDWALL",1);SetTileTag(27,54,"LAND_1", 1);SetTileTag(28,54,"SOLIDWALL",1);SetTileTag(30,54,"SOLIDWALL",1);SetTileTag(32,54,"SOLIDWALL",1);SetTileTag(33,54,"LAVA_3", 1);SetTileTag(35,54,"SOLIDWALL",1);SetTileTag(36,54,"SOLIDWALL",1);SetTileTag(37,54,"SOLIDWALL",1);SetTileTag(38,54,"SOLIDWALL",1);SetTileTag(39,54,"LAND_1", 1);SetTileTag(40,54,"LAND_1", 1);SetTileTag(41,54,"LAND_1", 1);SetTileTag(42,54,"SOLIDWALL",1);SetTileTag(45,54,"SOLIDWALL",1);SetTileTag(47,54,"SOLIDWALL",1);SetTileTag(48,54,"SOLIDWALL",1);SetTileTag(49,54,"SOLIDWALL",1);SetTileTag(50,54,"SOLIDWALL",1);SetTileTag(52,54,"LAND_6", 1);SetTileTag(53,54,"LAND_6", 1);SetTileTag(54,54,"LAND_6", 1);SetTileTag(55,54,"SOLIDWALL",1);SetTileTag(59,54,"SOLIDWALL",1);SetTileTag(60,54,"LAND_6", 1);SetTileTag(61,54,"SOLIDWALL",1);SetTileTag(62,54,"SOLIDWALL",1);
		SetTileTag(2,53,"LAND_1", 1);SetTileTag(3,53,"LAND_1", 1);SetTileTag(10,53,"LAND_1", 1);SetTileTag(11,53,"SOLIDWALL",1);SetTileTag(12,53,"LAND_1", 1);SetTileTag(14,53,"SOLIDWALL",1);SetTileTag(15,53,"LAND_1", 1);SetTileTag(17,53,"SOLIDWALL",1);SetTileTag(19,53,"SOLIDWALL",1);SetTileTag(20,53,"SOLIDWALL",1);SetTileTag(21,53,"LAND_1", 1);SetTileTag(22,53,"LAND_1", 1);SetTileTag(23,53,"WATER_2", 1);SetTileTag(24,53,"LAND_1", 1);SetTileTag(27,53,"LAND_1", 1);SetTileTag(29,53,"SOLIDWALL",1);SetTileTag(31,53,"LAND_1", 1);SetTileTag(32,53,"SOLIDWALL",1);SetTileTag(35,53,"LAND_19", 1);SetTileTag(37,53,"LAND_19", 1);SetTileTag(39,53,"SOLIDWALL",1);SetTileTag(40,53,"SOLIDWALL",1);SetTileTag(43,53,"SOLIDWALL",1);SetTileTag(45,53,"SOLIDWALL",1);SetTileTag(46,53,"LAND_1", 1);SetTileTag(47,53,"SOLIDWALL",1);SetTileTag(48,53,"LAND_6", 1);SetTileTag(50,53,"LAND_6", 1);SetTileTag(53,53,"SOLIDWALL",1);SetTileTag(54,53,"LAND_6", 1);SetTileTag(57,53,"LAND_6", 1);SetTileTag(58,53,"LAND_6", 1);SetTileTag(59,53,"SOLIDWALL",1);SetTileTag(60,53,"LAND_6", 1);SetTileTag(61,53,"LAND_6", 1);SetTileTag(62,53,"LAND_6", 1);
		SetTileTag(0,52,"SOLIDWALL",1);SetTileTag(1,52,"LAND_1", 1);SetTileTag(2,52,"SOLIDWALL",1);SetTileTag(3,52,"SOLIDWALL",1);SetTileTag(4,52,"SOLIDWALL",1);SetTileTag(5,52,"SOLIDWALL",1);SetTileTag(6,52,"SOLIDWALL",1);SetTileTag(7,52,"SOLIDWALL",1);SetTileTag(8,52,"SOLIDWALL",1);SetTileTag(9,52,"LAND_1", 1);SetTileTag(10,52,"SOLIDWALL",1);SetTileTag(12,52,"SOLIDWALL",1);SetTileTag(14,52,"SOLIDWALL",1);SetTileTag(15,52,"SOLIDWALL",1);SetTileTag(16,52,"SOLIDWALL",1);SetTileTag(20,52,"SOLIDWALL",1);SetTileTag(21,52,"LAND_1", 1);SetTileTag(22,52,"SOLIDWALL",1);SetTileTag(23,52,"LAND_1", 1);SetTileTag(24,52,"LAND_1", 1);SetTileTag(25,52,"LAND_1", 1);SetTileTag(26,52,"LAND_1", 1);SetTileTag(27,52,"SOLIDWALL",1);SetTileTag(28,52,"SOLIDWALL",1);SetTileTag(29,52,"SOLIDWALL",1);SetTileTag(31,52,"SOLIDWALL",1);SetTileTag(32,52,"SOLIDWALL",1);SetTileTag(34,52,"LAVA_3", 1);SetTileTag(35,52,"SOLIDWALL",1);SetTileTag(36,52,"LAND_19", 1);SetTileTag(37,52,"SOLIDWALL",1);SetTileTag(39,52,"SOLIDWALL",1);SetTileTag(40,52,"SOLIDWALL",1);SetTileTag(41,52,"SOLIDWALL",1);SetTileTag(42,52,"SOLIDWALL",1);SetTileTag(43,52,"LAND_6", 1);SetTileTag(44,52,"LAND_6", 1);SetTileTag(45,52,"LAND_6", 1);SetTileTag(46,52,"SOLIDWALL",1);SetTileTag(47,52,"SOLIDWALL",1);SetTileTag(50,52,"LAND_6", 1);SetTileTag(52,52,"SOLIDWALL",1);SetTileTag(53,52,"SOLIDWALL",1);SetTileTag(54,52,"LAND_6", 1);SetTileTag(56,52,"LAND_6", 1);SetTileTag(57,52,"SOLIDWALL",1);SetTileTag(58,52,"SOLIDWALL",1);SetTileTag(59,52,"SOLIDWALL",1);SetTileTag(60,52,"SOLIDWALL",1);SetTileTag(61,52,"SOLIDWALL",1);SetTileTag(62,52,"LAND_6", 1);
		SetTileTag(1,51,"SOLIDWALL",1);SetTileTag(2,51,"SOLIDWALL",1);SetTileTag(3,51,"SOLIDWALL",1);SetTileTag(4,51,"SOLIDWALL",1);SetTileTag(5,51,"SOLIDWALL",1);SetTileTag(7,51,"SOLIDWALL",1);SetTileTag(8,51,"SOLIDWALL",1);SetTileTag(9,51,"LAND_1", 1);SetTileTag(11,51,"SOLIDWALL",1);SetTileTag(12,51,"SOLIDWALL",1);SetTileTag(13,51,"LAND_1", 1);SetTileTag(14,51,"LAND_1", 1);SetTileTag(15,51,"LAND_1", 1);SetTileTag(16,51,"LAND_1", 1);SetTileTag(18,51,"LAND_1", 1);SetTileTag(20,51,"LAND_1", 1);SetTileTag(21,51,"LAND_1", 1);SetTileTag(22,51,"SOLIDWALL",1);SetTileTag(23,51,"LAND_1", 1);SetTileTag(24,51,"LAND_1", 1);SetTileTag(25,51,"SOLIDWALL",1);SetTileTag(26,51,"LAND_1", 1);SetTileTag(27,51,"LAND_1", 1);SetTileTag(28,51,"LAND_1", 1);SetTileTag(30,51,"LAND_1", 1);SetTileTag(31,51,"SOLIDWALL",1);SetTileTag(32,51,"LAVA_3", 1);SetTileTag(34,51,"LAVA_3", 1);SetTileTag(36,51,"LAND_19", 1);SetTileTag(37,51,"LAND_19", 1);SetTileTag(39,51,"SOLIDWALL",1);SetTileTag(41,51,"LAND_6", 1);SetTileTag(42,51,"SOLIDWALL",1);SetTileTag(44,51,"LAND_6", 1);SetTileTag(46,51,"SOLIDWALL",1);SetTileTag(47,51,"LAND_6", 1);SetTileTag(50,51,"LAND_6", 1);SetTileTag(54,51,"LAND_6", 1);SetTileTag(55,51,"LAND_6", 1);SetTileTag(56,51,"LAND_6", 1);SetTileTag(57,51,"LAND_6", 1);SetTileTag(58,51,"LAND_6", 1);SetTileTag(59,51,"LAND_6", 1);SetTileTag(60,51,"LAND_6", 1);SetTileTag(61,51,"LAND_6", 1);SetTileTag(62,51,"LAND_6", 1);SetTileTag(63,51,"SOLIDWALL",1);
		SetTileTag(1,50,"SOLIDWALL",1);SetTileTag(2,50,"LAND_1", 1);SetTileTag(4,50,"LAND_1", 1);SetTileTag(5,50,"LAND_1", 1);SetTileTag(6,50,"LAND_1", 1);SetTileTag(8,50,"LAND_1", 1);SetTileTag(9,50,"SOLIDWALL",1);SetTileTag(10,50,"SOLIDWALL",1);SetTileTag(12,50,"SOLIDWALL",1);SetTileTag(13,50,"LAND_1", 1);SetTileTag(14,50,"SOLIDWALL",1);SetTileTag(15,50,"SOLIDWALL",1);SetTileTag(18,50,"SOLIDWALL",1);SetTileTag(20,50,"SOLIDWALL",1);SetTileTag(21,50,"SOLIDWALL",1);SetTileTag(22,50,"LAND_1", 1);SetTileTag(24,50,"SOLIDWALL",1);SetTileTag(26,50,"SOLIDWALL",1);SetTileTag(27,50,"SOLIDWALL",1);SetTileTag(28,50,"SOLIDWALL",1);SetTileTag(30,50,"SOLIDWALL",1);SetTileTag(34,50,"SOLIDWALL",1);SetTileTag(35,50,"SOLIDWALL",1);SetTileTag(36,50,"LAND_19", 1);SetTileTag(37,50,"SOLIDWALL",1);SetTileTag(42,50,"LAND_6", 1);SetTileTag(44,50,"LAND_6", 1);SetTileTag(46,50,"LAND_6", 1);SetTileTag(49,50,"LAND_6", 1);SetTileTag(50,50,"LAND_6", 1);SetTileTag(55,50,"SOLIDWALL",1);SetTileTag(56,50,"SOLIDWALL",1);SetTileTag(57,50,"SOLIDWALL",1);SetTileTag(58,50,"SOLIDWALL",1);SetTileTag(59,50,"LAND_6", 1);SetTileTag(60,50,"SOLIDWALL",1);SetTileTag(62,50,"SOLIDWALL",1);
		SetTileTag(1,49,"SOLIDWALL",1);SetTileTag(3,49,"LAND_1", 1);SetTileTag(5,49,"SOLIDWALL",1);SetTileTag(7,49,"LAND_1", 1);SetTileTag(8,49,"LAND_1", 1);SetTileTag(9,49,"LAND_1", 1);SetTileTag(11,49,"SOLIDWALL",1);SetTileTag(12,49,"LAND_1", 1);SetTileTag(14,49,"LAND_1", 1);SetTileTag(16,49,"LAND_1", 1);SetTileTag(17,49,"LAND_1", 1);SetTileTag(20,49,"SOLIDWALL",1);SetTileTag(21,49,"LAND_1", 1);SetTileTag(23,49,"LAND_1", 1);SetTileTag(24,49,"SOLIDWALL",1);SetTileTag(25,49,"SOLIDWALL",1);SetTileTag(26,49,"SOLIDWALL",1);SetTileTag(27,49,"LAND_11", 1);SetTileTag(30,49,"LAND_11", 1);SetTileTag(31,49,"LAND_11", 1);SetTileTag(34,49,"LAND_18", 1);SetTileTag(35,49,"SOLIDWALL",1);SetTileTag(36,49,"LAND_19", 1);SetTileTag(37,49,"SOLIDWALL",1);SetTileTag(38,49,"LAND_19", 1);SetTileTag(39,49,"SOLIDWALL",1);SetTileTag(43,49,"LAND_6", 1);SetTileTag(44,49,"LAND_6", 1);SetTileTag(46,49,"LAND_6", 1);SetTileTag(49,49,"LAND_6", 1);SetTileTag(51,49,"LAND_6", 1);SetTileTag(52,49,"LAND_6", 1);SetTileTag(53,49,"LAND_6", 1);SetTileTag(54,49,"LAND_6", 1);SetTileTag(55,49,"LAND_6", 1);SetTileTag(57,49,"LAND_6", 1);SetTileTag(59,49,"LAND_6", 1);SetTileTag(60,49,"LAND_6", 1);SetTileTag(61,49,"LAND_6", 1);SetTileTag(63,49,"SOLIDWALL",1);
		SetTileTag(1,48,"SOLIDWALL",1);SetTileTag(2,48,"LAND_1", 1);SetTileTag(3,48,"LAND_1", 1);SetTileTag(4,48,"SOLIDWALL",1);SetTileTag(6,48,"SOLIDWALL",1);SetTileTag(7,48,"SOLIDWALL",1);SetTileTag(10,48,"LAND_1", 1);SetTileTag(11,48,"LAND_1", 1);SetTileTag(16,48,"LAND_1", 1);SetTileTag(17,48,"LAND_1", 1);SetTileTag(22,48,"LAND_1", 1);SetTileTag(23,48,"SOLIDWALL",1);SetTileTag(24,48,"LAND_11", 1);SetTileTag(25,48,"LAND_11", 1);SetTileTag(27,48,"SOLIDWALL",1);SetTileTag(28,48,"LAND_11", 1);SetTileTag(30,48,"SOLIDWALL",1);SetTileTag(31,48,"SOLIDWALL",1);SetTileTag(32,48,"LAVA_3", 1);SetTileTag(35,48,"LAND_19", 1);SetTileTag(37,48,"SOLIDWALL",1);SetTileTag(38,48,"SOLIDWALL",1);SetTileTag(39,48,"LAND_6", 1);SetTileTag(42,48,"SOLIDWALL",1);SetTileTag(44,48,"SOLIDWALL",1);SetTileTag(45,48,"LAND_6", 1);SetTileTag(46,48,"LAND_6", 1);SetTileTag(48,48,"LAND_6", 1);SetTileTag(49,48,"SOLIDWALL",1);SetTileTag(50,48,"SOLIDWALL",1);SetTileTag(51,48,"LAND_6", 1);SetTileTag(52,48,"LAND_6", 1);SetTileTag(53,48,"LAND_6", 1);SetTileTag(54,48,"LAND_6", 1);SetTileTag(55,48,"LAND_6", 1);SetTileTag(56,48,"LAND_6", 1);SetTileTag(57,48,"LAND_6", 1);SetTileTag(59,48,"SOLIDWALL",1);SetTileTag(60,48,"SOLIDWALL",1);SetTileTag(61,48,"LAND_6", 1);
		SetTileTag(1,47,"SOLIDWALL",1);SetTileTag(2,47,"LAND_1", 1);SetTileTag(3,47,"SOLIDWALL",1);SetTileTag(5,47,"SOLIDWALL",1);SetTileTag(6,47,"LAND_1", 1);SetTileTag(7,47,"LAND_1", 1);SetTileTag(9,47,"LAND_1", 1);SetTileTag(10,47,"SOLIDWALL",1);SetTileTag(11,47,"LAND_1", 1);SetTileTag(12,47,"LAND_1", 1);SetTileTag(13,47,"LAND_1", 1);SetTileTag(14,47,"SOLIDWALL",1);SetTileTag(16,47,"LAND_1", 1);SetTileTag(17,47,"SOLIDWALL",1);SetTileTag(18,47,"LAND_1", 1);SetTileTag(20,47,"SOLIDWALL",1);SetTileTag(22,47,"SOLIDWALL",1);SetTileTag(24,47,"LAND_11", 1);SetTileTag(25,47,"SOLIDWALL",1);SetTileTag(26,47,"LAND_11", 1);SetTileTag(28,47,"SOLIDWALL",1);SetTileTag(29,47,"LAND_11", 1);SetTileTag(30,47,"LAND_11", 1);SetTileTag(31,47,"SOLIDWALL",1);SetTileTag(32,47,"LAVA_3", 1);SetTileTag(33,47,"LAVA_3", 1);SetTileTag(36,47,"SOLIDWALL",1);SetTileTag(38,47,"SOLIDWALL",1);SetTileTag(39,47,"LAND_6", 1);SetTileTag(40,47,"LAND_6", 1);SetTileTag(41,47,"LAND_6", 1);SetTileTag(42,47,"LAND_6", 1);SetTileTag(44,47,"SOLIDWALL",1);SetTileTag(45,47,"LAND_6", 1);SetTileTag(46,47,"LAND_6", 1);SetTileTag(47,47,"LAND_6", 1);SetTileTag(48,47,"LAND_6", 1);SetTileTag(49,47,"LAND_6", 1);SetTileTag(53,47,"LAND_6", 1);SetTileTag(55,47,"LAND_6", 1);SetTileTag(57,47,"LAND_6", 1);SetTileTag(60,47,"LAND_6", 1);SetTileTag(62,47,"SOLIDWALL",1);
		SetTileTag(2,46,"LAND_1", 1);SetTileTag(3,46,"LAND_1", 1);SetTileTag(4,46,"SOLIDWALL",1);SetTileTag(6,46,"LAND_1", 1);SetTileTag(8,46,"LAND_1", 1);SetTileTag(9,46,"LAND_1", 1);SetTileTag(10,46,"LAND_1", 1);SetTileTag(11,46,"LAND_1", 1);SetTileTag(14,46,"LAND_1", 1);SetTileTag(16,46,"SOLIDWALL",1);SetTileTag(17,46,"SOLIDWALL",1);SetTileTag(18,46,"LAND_1", 1);SetTileTag(20,46,"LAND_1", 1);SetTileTag(21,46,"LAND_1", 1);SetTileTag(23,46,"SOLIDWALL",1);SetTileTag(24,46,"LAND_11", 1);SetTileTag(26,46,"SOLIDWALL",1);SetTileTag(27,46,"LAND_11", 1);SetTileTag(28,46,"LAND_11", 1);SetTileTag(30,46,"LAND_11", 1);SetTileTag(32,46,"SOLIDWALL",1);SetTileTag(33,46,"SOLIDWALL",1);SetTileTag(34,46,"LAVA_3", 1);SetTileTag(36,46,"LAND_20", 1);SetTileTag(37,46,"SOLIDWALL",1);SetTileTag(38,46,"SOLIDWALL",1);SetTileTag(39,46,"LAND_6", 1);SetTileTag(40,46,"LAND_6", 1);SetTileTag(41,46,"LAND_6", 1);SetTileTag(42,46,"LAND_6", 1);SetTileTag(43,46,"SOLIDWALL",1);SetTileTag(44,46,"SOLIDWALL",1);SetTileTag(45,46,"SOLIDWALL",1);SetTileTag(46,46,"SOLIDWALL",1);SetTileTag(47,46,"SOLIDWALL",1);SetTileTag(48,46,"SOLIDWALL",1);SetTileTag(49,46,"LAND_6", 1);SetTileTag(50,46,"LAND_6", 1);SetTileTag(51,46,"LAND_6", 1);SetTileTag(52,46,"LAND_6", 1);SetTileTag(54,46,"SOLIDWALL",1);SetTileTag(55,46,"LAND_6", 1);SetTileTag(56,46,"LAND_6", 1);SetTileTag(57,46,"LAND_6", 1);SetTileTag(59,46,"LAND_6", 1);SetTileTag(60,46,"SOLIDWALL",1);SetTileTag(61,46,"LAND_6", 1);SetTileTag(62,46,"LAND_6", 1);SetTileTag(63,46,"SOLIDWALL",1);
		SetTileTag(1,45,"SOLIDWALL",1);SetTileTag(2,45,"LAND_1", 1);SetTileTag(3,45,"LAND_1", 1);SetTileTag(4,45,"LAND_1", 1);SetTileTag(5,45,"LAND_1", 1);SetTileTag(6,45,"LAND_1", 1);SetTileTag(7,45,"SOLIDWALL",1);SetTileTag(8,45,"SOLIDWALL",1);SetTileTag(9,45,"LAND_1", 1);SetTileTag(10,45,"LAND_1", 1);SetTileTag(11,45,"LAND_1", 1);SetTileTag(12,45,"SOLIDWALL",1);SetTileTag(13,45,"SOLIDWALL",1);SetTileTag(14,45,"LAND_1", 1);SetTileTag(15,45,"LAND_1", 1);SetTileTag(16,45,"LAND_1", 1);SetTileTag(18,45,"SOLIDWALL",1);SetTileTag(19,45,"LAND_1", 1);SetTileTag(20,45,"LAND_1", 1);SetTileTag(21,45,"SOLIDWALL",1);SetTileTag(23,45,"SOLIDWALL",1);SetTileTag(24,45,"SOLIDWALL",1);SetTileTag(25,45,"LAND_11", 1);SetTileTag(28,45,"LAND_11", 1);SetTileTag(30,45,"LAND_11", 1);SetTileTag(31,45,"SOLIDWALL",1);SetTileTag(32,45,"SOLIDWALL",1);SetTileTag(33,45,"SOLIDWALL",1);SetTileTag(34,45,"LAND_12", 1);SetTileTag(35,45,"LAVA_3", 1);SetTileTag(37,45,"LAND_20", 1);SetTileTag(38,45,"SOLIDWALL",1);SetTileTag(39,45,"LAND_6", 1);SetTileTag(40,45,"LAND_6", 1);SetTileTag(42,45,"LAND_6", 1);SetTileTag(43,45,"SOLIDWALL",1);SetTileTag(45,45,"LAND_20", 1);SetTileTag(47,45,"SOLIDWALL",1);SetTileTag(48,45,"SOLIDWALL",1);SetTileTag(49,45,"LAND_6", 1);SetTileTag(50,45,"LAND_6", 1);SetTileTag(51,45,"LAND_6", 1);SetTileTag(52,45,"LAND_6", 1);SetTileTag(53,45,"SOLIDWALL",1);SetTileTag(55,45,"SOLIDWALL",1);SetTileTag(57,45,"SOLIDWALL",1);SetTileTag(58,45,"SOLIDWALL",1);SetTileTag(59,45,"LAND_6", 1);SetTileTag(60,45,"SOLIDWALL",1);SetTileTag(61,45,"SOLIDWALL",1);SetTileTag(62,45,"SOLIDWALL",1);
		SetTileTag(2,44,"SOLIDWALL",1);SetTileTag(3,44,"SOLIDWALL",1);SetTileTag(7,44,"LAND_1", 1);SetTileTag(8,44,"LAND_1", 1);SetTileTag(9,44,"LAND_1", 1);SetTileTag(11,44,"LAND_1", 1);SetTileTag(13,44,"LAND_1", 1);SetTileTag(14,44,"SOLIDWALL",1);SetTileTag(16,44,"SOLIDWALL",1);SetTileTag(18,44,"LAND_1", 1);SetTileTag(19,44,"SOLIDWALL",1);SetTileTag(20,44,"LAND_1", 1);SetTileTag(22,44,"LAND_1", 1);SetTileTag(23,44,"LAND_1", 1);SetTileTag(24,44,"SOLIDWALL",1);SetTileTag(25,44,"SOLIDWALL",1);SetTileTag(27,44,"SOLIDWALL",1);SetTileTag(28,44,"LAND_11", 1);SetTileTag(29,44,"SOLIDWALL",1);SetTileTag(30,44,"LAND_11", 1);SetTileTag(31,44,"SOLIDWALL",1);SetTileTag(34,44,"LAND_12", 1);SetTileTag(35,44,"LAVA_3", 1);SetTileTag(39,44,"SOLIDWALL",1);SetTileTag(40,44,"SOLIDWALL",1);SetTileTag(41,44,"LAND_6", 1);SetTileTag(42,44,"SOLIDWALL",1);SetTileTag(43,44,"SOLIDWALL",1);SetTileTag(44,44,"LAND_20", 1);SetTileTag(45,44,"SOLIDWALL",1);SetTileTag(46,44,"LAND_20", 1);SetTileTag(47,44,"SOLIDWALL",1);SetTileTag(48,44,"SOLIDWALL",1);SetTileTag(49,44,"LAND_6", 1);SetTileTag(50,44,"LAND_6", 1);SetTileTag(52,44,"LAND_6", 1);SetTileTag(53,44,"SOLIDWALL",1);SetTileTag(54,44,"SOLIDWALL",1);SetTileTag(57,44,"SOLIDWALL",1);SetTileTag(58,44,"SOLIDWALL",1);SetTileTag(59,44,"LAND_6", 1);SetTileTag(62,44,"LAVA_3", 1);
		SetTileTag(2,43,"LAND_1", 1);SetTileTag(3,43,"LAND_1", 1);SetTileTag(4,43,"LAND_1", 1);SetTileTag(5,43,"LAND_1", 1);SetTileTag(7,43,"SOLIDWALL",1);SetTileTag(8,43,"LAND_1", 1);SetTileTag(10,43,"SOLIDWALL",1);SetTileTag(11,43,"LAND_1", 1);SetTileTag(12,43,"LAND_1", 1);SetTileTag(14,43,"LAND_1", 1);SetTileTag(15,43,"LAND_1", 1);SetTileTag(16,43,"SOLIDWALL",1);SetTileTag(17,43,"LAND_1", 1);SetTileTag(18,43,"LAND_1", 1);SetTileTag(19,43,"SOLIDWALL",1);SetTileTag(20,43,"LAND_1", 1);SetTileTag(21,43,"SOLIDWALL",1);SetTileTag(22,43,"SOLIDWALL",1);SetTileTag(23,43,"SOLIDWALL",1);SetTileTag(25,43,"SOLIDWALL",1);SetTileTag(27,43,"SOLIDWALL",1);SetTileTag(28,43,"LAND_11", 1);SetTileTag(31,43,"SOLIDWALL",1);SetTileTag(32,43,"LAND_12", 1);SetTileTag(36,43,"LAVA_3", 1);SetTileTag(39,43,"LAVA_3", 1);SetTileTag(40,43,"SOLIDWALL",1);SetTileTag(41,43,"LAND_6", 1);SetTileTag(42,43,"SOLIDWALL",1);SetTileTag(44,43,"SOLIDWALL",1);SetTileTag(45,43,"SOLIDWALL",1);SetTileTag(46,43,"LAND_20", 1);SetTileTag(47,43,"LAND_20", 1);SetTileTag(48,43,"SOLIDWALL",1);SetTileTag(49,43,"SOLIDWALL",1);SetTileTag(53,43,"SOLIDWALL",1);SetTileTag(54,43,"LAND_20", 1);SetTileTag(55,43,"LAND_20", 1);SetTileTag(58,43,"LAND_6", 1);SetTileTag(59,43,"LAND_6", 1);SetTileTag(61,43,"LAVA_3", 1);SetTileTag(62,43,"LAVA_3", 1);SetTileTag(63,43,"SOLIDWALL",1);
		SetTileTag(1,42,"SOLIDWALL",1);SetTileTag(2,42,"LAND_1", 1);SetTileTag(3,42,"LAND_1", 1);SetTileTag(4,42,"LAND_1", 1);SetTileTag(5,42,"SOLIDWALL",1);SetTileTag(8,42,"SOLIDWALL",1);SetTileTag(10,42,"SOLIDWALL",1);SetTileTag(11,42,"SOLIDWALL",1);SetTileTag(12,42,"LAND_1", 1);SetTileTag(14,42,"SOLIDWALL",1);SetTileTag(15,42,"LAND_1", 1);SetTileTag(16,42,"SOLIDWALL",1);SetTileTag(17,42,"LAND_1", 1);SetTileTag(18,42,"LAND_1", 1);SetTileTag(19,42,"LAND_1", 1);SetTileTag(20,42,"LAND_1", 1);SetTileTag(22,42,"SOLIDWALL",1);SetTileTag(25,42,"SOLIDWALL",1);SetTileTag(26,42,"LAND_11", 1);SetTileTag(27,42,"SOLIDWALL",1);SetTileTag(28,42,"SOLIDWALL",1);SetTileTag(31,42,"SOLIDWALL",1);SetTileTag(32,42,"LAND_12", 1);SetTileTag(34,42,"LAND_12", 1);SetTileTag(35,42,"SOLIDWALL",1);SetTileTag(36,42,"LAND_20", 1);SetTileTag(37,42,"LAVA_3", 1);SetTileTag(40,42,"SOLIDWALL",1);SetTileTag(41,42,"LAND_6", 1);SetTileTag(42,42,"SOLIDWALL",1);SetTileTag(43,42,"SOLIDWALL",1);SetTileTag(45,42,"SOLIDWALL",1);SetTileTag(46,42,"SOLIDWALL",1);SetTileTag(47,42,"LAND_20", 1);SetTileTag(51,42,"LAVA_3", 1);SetTileTag(52,42,"SOLIDWALL",1);SetTileTag(53,42,"LAND_20", 1);SetTileTag(59,42,"LAVA_3", 1);SetTileTag(60,42,"LAVA_3", 1);SetTileTag(61,42,"LAVA_3", 1);SetTileTag(62,42,"SOLIDWALL",1);
		SetTileTag(2,41,"SOLIDWALL",1);SetTileTag(3,41,"LAND_1", 1);SetTileTag(4,41,"SOLIDWALL",1);SetTileTag(5,41,"SOLIDWALL",1);SetTileTag(7,41,"LAND_1", 1);SetTileTag(8,41,"LAND_1", 1);SetTileTag(10,41,"LAND_1", 1);SetTileTag(11,41,"LAND_1", 1);SetTileTag(12,41,"SOLIDWALL",1);SetTileTag(14,41,"SOLIDWALL",1);SetTileTag(15,41,"LAND_1", 1);SetTileTag(16,41,"SOLIDWALL",1);SetTileTag(17,41,"SOLIDWALL",1);SetTileTag(19,41,"SOLIDWALL",1);SetTileTag(20,41,"SOLIDWALL",1);SetTileTag(21,41,"SOLIDWALL",1);SetTileTag(25,41,"SOLIDWALL",1);SetTileTag(26,41,"SOLIDWALL",1);SetTileTag(27,41,"SOLIDWALL",1);SetTileTag(29,41,"LAND_12", 1);SetTileTag(32,41,"SOLIDWALL",1);SetTileTag(33,41,"LAND_12", 1);SetTileTag(34,41,"SOLIDWALL",1);SetTileTag(35,41,"SOLIDWALL",1);SetTileTag(36,41,"LAND_20", 1);SetTileTag(37,41,"LAND_20", 1);SetTileTag(38,41,"LAVA_3", 1);SetTileTag(40,41,"LAND_6", 1);SetTileTag(41,41,"LAVA_3", 1);SetTileTag(43,41,"LAND_20", 1);SetTileTag(52,41,"LAVA_3", 1);SetTileTag(56,41,"LAVA_3", 1);SetTileTag(57,41,"LAVA_3", 1);SetTileTag(58,41,"LAVA_3", 1);SetTileTag(59,41,"LAVA_3", 1);SetTileTag(60,41,"SOLIDWALL",1);SetTileTag(61,41,"SOLIDWALL",1);
		SetTileTag(4,40,"LAND_1", 1);SetTileTag(5,40,"LAND_1", 1);SetTileTag(6,40,"LAND_1", 1);SetTileTag(7,40,"SOLIDWALL",1);SetTileTag(8,40,"SOLIDWALL",1);SetTileTag(10,40,"SOLIDWALL",1);SetTileTag(11,40,"LAND_1", 1);SetTileTag(12,40,"SOLIDWALL",1);SetTileTag(13,40,"LAND_1", 1);SetTileTag(14,40,"LAND_1", 1);SetTileTag(15,40,"LAND_1", 1);SetTileTag(16,40,"SOLIDWALL",1);SetTileTag(19,40,"SOLIDWALL",1);SetTileTag(21,40,"SOLIDWALL",1);SetTileTag(25,40,"SOLIDWALL",1);SetTileTag(26,40,"LAND_12", 1);SetTileTag(27,40,"LAND_12", 1);SetTileTag(28,40,"LAND_12", 1);SetTileTag(30,40,"SOLIDWALL",1);SetTileTag(31,40,"LAND_12", 1);SetTileTag(32,40,"SOLIDWALL",1);SetTileTag(33,40,"LAND_12", 1);SetTileTag(34,40,"SOLIDWALL",1);SetTileTag(36,40,"SOLIDWALL",1);SetTileTag(37,40,"SOLIDWALL",1);SetTileTag(38,40,"SOLIDWALL",1);SetTileTag(39,40,"LAVA_3", 1);SetTileTag(41,40,"LAND_6", 1);SetTileTag(45,40,"LAVA_3", 1);SetTileTag(46,40,"LAVA_3", 1);SetTileTag(47,40,"LAVA_3", 1);SetTileTag(48,40,"LAVA_3", 1);SetTileTag(49,40,"LAVA_3", 1);SetTileTag(52,40,"LAND_20", 1);SetTileTag(54,40,"LAVA_3", 1);SetTileTag(55,40,"LAVA_3", 1);SetTileTag(56,40,"LAVA_3", 1);SetTileTag(57,40,"SOLIDWALL",1);SetTileTag(58,40,"SOLIDWALL",1);SetTileTag(59,40,"SOLIDWALL",1);SetTileTag(60,40,"SOLIDWALL",1);
		SetTileTag(2,39,"SOLIDWALL",1);SetTileTag(3,39,"LAND_1", 1);SetTileTag(4,39,"LAND_1", 1);SetTileTag(5,39,"SOLIDWALL",1);SetTileTag(6,39,"SOLIDWALL",1);SetTileTag(7,39,"SOLIDWALL",1);SetTileTag(8,39,"LAND_1", 1);SetTileTag(9,39,"LAND_1", 1);SetTileTag(13,39,"SOLIDWALL",1);SetTileTag(14,39,"LAND_1", 1);SetTileTag(15,39,"SOLIDWALL",1);SetTileTag(20,39,"LAND_7", 1);SetTileTag(21,39,"SOLIDWALL",1);SetTileTag(27,39,"SOLIDWALL",1);SetTileTag(32,39,"LAND_12", 1);SetTileTag(33,39,"LAND_12", 1);SetTileTag(34,39,"SOLIDWALL",1);SetTileTag(35,39,"LAND_13", 1);SetTileTag(36,39,"SOLIDWALL",1);SetTileTag(37,39,"LAND_13", 1);SetTileTag(38,39,"SOLIDWALL",1);SetTileTag(39,39,"SOLIDWALL",1);SetTileTag(40,39,"LAVA_3", 1);SetTileTag(41,39,"LAVA_3", 1);SetTileTag(42,39,"LAVA_3", 1);SetTileTag(43,39,"LAVA_3", 1);SetTileTag(44,39,"LAVA_3", 1);SetTileTag(45,39,"LAND_20", 1);SetTileTag(46,39,"LAND_20", 1);SetTileTag(47,39,"LAND_20", 1);SetTileTag(48,39,"SOLIDWALL",1);SetTileTag(50,39,"LAVA_3", 1);SetTileTag(51,39,"LAVA_3", 1);SetTileTag(52,39,"LAVA_3", 1);SetTileTag(53,39,"LAVA_3", 1);SetTileTag(55,39,"SOLIDWALL",1);SetTileTag(59,39,"LAND_6", 1);SetTileTag(61,39,"SOLIDWALL",1);
		SetTileTag(2,38,"SOLIDWALL",1);SetTileTag(3,38,"LAND_1", 1);SetTileTag(5,38,"SOLIDWALL",1);SetTileTag(6,38,"LAND_1", 1);SetTileTag(7,38,"LAND_1", 1);SetTileTag(8,38,"SOLIDWALL",1);SetTileTag(9,38,"SOLIDWALL",1);SetTileTag(13,38,"LAND_1", 1);SetTileTag(18,38,"SOLIDWALL",1);SetTileTag(20,38,"SOLIDWALL",1);SetTileTag(21,38,"SOLIDWALL",1);SetTileTag(25,38,"SOLIDWALL",1);SetTileTag(26,38,"LAND_12", 1);SetTileTag(27,38,"LAND_12", 1);SetTileTag(29,38,"SOLIDWALL",1);SetTileTag(33,38,"SOLIDWALL",1);SetTileTag(39,38,"SOLIDWALL",1);SetTileTag(40,38,"LAND_6", 1);SetTileTag(42,38,"LAND_6", 1);SetTileTag(43,38,"SOLIDWALL",1);SetTileTag(45,38,"SOLIDWALL",1);SetTileTag(46,38,"SOLIDWALL",1);SetTileTag(47,38,"SOLIDWALL",1);SetTileTag(48,38,"SOLIDWALL",1);SetTileTag(53,38,"SOLIDWALL",1);SetTileTag(55,38,"SOLIDWALL",1);SetTileTag(61,38,"SOLIDWALL",1);
		SetTileTag(3,37,"SOLIDWALL",1);SetTileTag(4,37,"LAND_1", 1);SetTileTag(5,37,"LAND_1", 1);SetTileTag(6,37,"LAND_1", 1);SetTileTag(7,37,"LAND_1", 1);SetTileTag(8,37,"SOLIDWALL",1);SetTileTag(9,37,"LAND_1", 1);SetTileTag(12,37,"SOLIDWALL",1);SetTileTag(13,37,"LAND_1", 1);SetTileTag(14,37,"LAND_1", 1);SetTileTag(15,37,"SOLIDWALL",1);SetTileTag(18,37,"SOLIDWALL",1);SetTileTag(19,37,"LAND_7", 1);SetTileTag(20,37,"LAND_7", 1);SetTileTag(22,37,"SOLIDWALL",1);SetTileTag(27,37,"SOLIDWALL",1);SetTileTag(29,37,"SOLIDWALL",1);SetTileTag(30,37,"LAND_12", 1);SetTileTag(31,37,"LAND_12", 1);SetTileTag(32,37,"LAND_12", 1);SetTileTag(33,37,"SOLIDWALL",1);SetTileTag(39,37,"SOLIDWALL",1);SetTileTag(40,37,"SOLIDWALL",1);SetTileTag(44,37,"LAND_6", 1);SetTileTag(46,37,"SOLIDWALL",1);SetTileTag(49,37,"LAND_6", 1);SetTileTag(56,37,"SOLIDWALL",1);SetTileTag(58,37,"LAND_6", 1);SetTileTag(62,37,"SOLIDWALL",1);
		SetTileTag(2,36,"SOLIDWALL",1);SetTileTag(3,36,"SOLIDWALL",1);SetTileTag(4,36,"LAND_1", 1);SetTileTag(5,36,"LAND_1", 1);SetTileTag(6,36,"LAND_1", 1);SetTileTag(7,36,"LAND_1", 1);SetTileTag(8,36,"SOLIDWALL",1);SetTileTag(9,36,"LAND_1", 1);SetTileTag(10,36,"LAND_1", 1);SetTileTag(11,36,"LAND_1", 1);SetTileTag(13,36,"LAND_1", 1);SetTileTag(14,36,"LAND_1", 1);SetTileTag(15,36,"SOLIDWALL",1);SetTileTag(17,36,"SOLIDWALL",1);SetTileTag(18,36,"LAND_7", 1);SetTileTag(19,36,"SOLIDWALL",1);SetTileTag(20,36,"SOLIDWALL",1);SetTileTag(21,36,"LAND_7", 1);SetTileTag(22,36,"SOLIDWALL",1);SetTileTag(23,36,"SOLIDWALL",1);SetTileTag(24,36,"SOLIDWALL",1);SetTileTag(25,36,"SOLIDWALL",1);SetTileTag(26,36,"SOLIDWALL",1);SetTileTag(28,36,"LAND_12", 1);SetTileTag(29,36,"SOLIDWALL",1);SetTileTag(30,36,"SOLIDWALL",1);SetTileTag(32,36,"SOLIDWALL",1);SetTileTag(33,36,"LAND_13", 1);SetTileTag(34,36,"LAND_13", 1);SetTileTag(35,36,"LAND_13", 1);SetTileTag(36,36,"LAND_13", 1);SetTileTag(37,36,"LAND_13", 1);SetTileTag(38,36,"LAND_13", 1);SetTileTag(39,36,"LAND_13", 1);SetTileTag(44,36,"SOLIDWALL",1);SetTileTag(47,36,"LAND_6", 1);SetTileTag(49,36,"SOLIDWALL",1);SetTileTag(52,36,"SOLIDWALL",1);SetTileTag(55,36,"LAND_6", 1);SetTileTag(58,36,"SOLIDWALL",1);
		SetTileTag(4,35,"SOLIDWALL",1);SetTileTag(5,35,"SOLIDWALL",1);SetTileTag(6,35,"SOLIDWALL",1);SetTileTag(7,35,"LAND_1", 1);SetTileTag(8,35,"SOLIDWALL",1);SetTileTag(9,35,"LAND_1", 1);SetTileTag(10,35,"SOLIDWALL",1);SetTileTag(11,35,"LAND_1", 1);SetTileTag(12,35,"LAND_1", 1);SetTileTag(13,35,"LAND_1", 1);SetTileTag(14,35,"SOLIDWALL",1);SetTileTag(16,35,"SOLIDWALL",1);SetTileTag(20,35,"SOLIDWALL",1);SetTileTag(21,35,"LAND_7", 1);SetTileTag(22,35,"SOLIDWALL",1);SetTileTag(26,35,"SOLIDWALL",1);SetTileTag(27,35,"LAND_12", 1);SetTileTag(28,35,"SOLIDWALL",1);SetTileTag(29,35,"SOLIDWALL",1);SetTileTag(30,35,"LAND_13", 1);SetTileTag(33,35,"LAND_13", 1);SetTileTag(34,35,"LAND_13", 1);SetTileTag(35,35,"SOLIDWALL",1);SetTileTag(36,35,"SOLIDWALL",1);SetTileTag(37,35,"SOLIDWALL",1);SetTileTag(38,35,"SOLIDWALL",1);SetTileTag(39,35,"SOLIDWALL",1);SetTileTag(40,35,"SOLIDWALL",1);SetTileTag(42,35,"SOLIDWALL",1);SetTileTag(43,35,"LAND_6", 1);SetTileTag(46,35,"LAND_6", 1);SetTileTag(47,35,"SOLIDWALL",1);SetTileTag(49,35,"LAND_6", 1);SetTileTag(51,35,"SOLIDWALL",1);SetTileTag(53,35,"LAND_6", 1);SetTileTag(55,35,"SOLIDWALL",1);SetTileTag(56,35,"LAND_6", 1);SetTileTag(59,35,"SOLIDWALL",1);SetTileTag(60,35,"LAND_6", 1);SetTileTag(61,35,"LAND_6", 1);SetTileTag(62,35,"SOLIDWALL",1);
		SetTileTag(4,34,"LAND_1", 1);SetTileTag(6,34,"LAND_1", 1);SetTileTag(9,34,"LAND_1", 1);SetTileTag(10,34,"SOLIDWALL",1);SetTileTag(11,34,"SOLIDWALL",1);SetTileTag(12,34,"SOLIDWALL",1);SetTileTag(16,34,"SOLIDWALL",1);SetTileTag(17,34,"LAND_7", 1);SetTileTag(18,34,"LAND_7", 1);SetTileTag(19,34,"LAND_7", 1);SetTileTag(20,34,"LAND_7", 1);SetTileTag(22,34,"LAND_7", 1);SetTileTag(23,34,"LAND_7", 1);SetTileTag(24,34,"LAND_7", 1);SetTileTag(25,34,"LAND_7", 1);SetTileTag(26,34,"SOLIDWALL",1);SetTileTag(27,34,"SOLIDWALL",1);SetTileTag(29,34,"LAND_13", 1);SetTileTag(34,34,"LAND_13", 1);SetTileTag(35,34,"SOLIDWALL",1);SetTileTag(36,34,"LAND_6", 1);SetTileTag(37,34,"LAND_6", 1);SetTileTag(38,34,"LAND_6", 1);SetTileTag(39,34,"SOLIDWALL",1);SetTileTag(40,34,"SOLIDWALL",1);SetTileTag(42,34,"SOLIDWALL",1);SetTileTag(43,34,"SOLIDWALL",1);SetTileTag(48,34,"LAND_6", 1);SetTileTag(50,34,"LAND_6", 1);SetTileTag(58,34,"LAND_6", 1);SetTileTag(60,34,"SOLIDWALL",1);
		SetTileTag(2,33,"LAND_1", 1);SetTileTag(3,33,"LAND_1", 1);SetTileTag(5,33,"SOLIDWALL",1);SetTileTag(6,33,"LAND_1", 1);SetTileTag(9,33,"LAND_1", 1);SetTileTag(12,33,"SOLIDWALL",1);SetTileTag(13,33,"SOLIDWALL",1);SetTileTag(16,33,"SOLIDWALL",1);SetTileTag(17,33,"SOLIDWALL",1);SetTileTag(18,33,"SOLIDWALL",1);SetTileTag(22,33,"SOLIDWALL",1);SetTileTag(23,33,"SOLIDWALL",1);SetTileTag(28,33,"LAND_13", 1);SetTileTag(35,33,"LAND_13", 1);SetTileTag(36,33,"SOLIDWALL",1);SetTileTag(37,33,"SOLIDWALL",1);SetTileTag(38,33,"LAND_6", 1);SetTileTag(39,33,"SOLIDWALL",1);SetTileTag(40,33,"LAND_6", 1);SetTileTag(41,33,"LAND_6", 1);SetTileTag(42,33,"LAND_6", 1);SetTileTag(46,33,"SOLIDWALL",1);SetTileTag(48,33,"SOLIDWALL",1);SetTileTag(49,33,"SOLIDWALL",1);SetTileTag(50,33,"SOLIDWALL",1);SetTileTag(53,33,"SOLIDWALL",1);SetTileTag(56,33,"SOLIDWALL",1);SetTileTag(59,33,"LAND_6", 1);SetTileTag(60,33,"LAND_6", 1);
		SetTileTag(2,32,"LAND_1", 1);SetTileTag(3,32,"SOLIDWALL",1);SetTileTag(4,32,"SOLIDWALL",1);SetTileTag(5,32,"LAND_1", 1);SetTileTag(6,32,"LAND_1", 1);SetTileTag(7,32,"LAND_1", 1);SetTileTag(9,32,"SOLIDWALL",1);SetTileTag(10,32,"SOLIDWALL",1);SetTileTag(11,32,"SOLIDWALL",1);SetTileTag(14,32,"LAND_7", 1);SetTileTag(16,32,"LAND_7", 1);SetTileTag(20,32,"LAND_7", 1);SetTileTag(22,32,"LAND_7", 1);SetTileTag(28,32,"LAND_13", 1);SetTileTag(35,32,"LAND_13", 1);SetTileTag(36,32,"SOLIDWALL",1);SetTileTag(37,32,"LAND_6", 1);SetTileTag(41,32,"LAND_6", 1);SetTileTag(42,32,"SOLIDWALL",1);SetTileTag(43,32,"SOLIDWALL",1);SetTileTag(47,32,"LAND_6", 1);SetTileTag(50,32,"LAND_6", 1);SetTileTag(52,32,"LAND_6", 1);SetTileTag(53,32,"LAND_6", 1);SetTileTag(56,32,"LAND_6", 1);SetTileTag(58,32,"SOLIDWALL",1);SetTileTag(59,32,"SOLIDWALL",1);
		SetTileTag(1,31,"SOLIDWALL",1);SetTileTag(2,31,"LAND_1", 1);SetTileTag(6,31,"LAND_1", 1);SetTileTag(7,31,"SOLIDWALL",1);SetTileTag(8,31,"SOLIDWALL",1);SetTileTag(9,31,"SOLIDWALL",1);SetTileTag(12,31,"SOLIDWALL",1);SetTileTag(14,31,"SOLIDWALL",1);SetTileTag(15,31,"SOLIDWALL",1);SetTileTag(16,31,"SOLIDWALL",1);SetTileTag(17,31,"LAND_7", 1);SetTileTag(18,31,"LAND_7", 1);SetTileTag(19,31,"LAND_7", 1);SetTileTag(20,31,"SOLIDWALL",1);SetTileTag(21,31,"LAND_7", 1);SetTileTag(22,31,"SOLIDWALL",1);SetTileTag(23,31,"LAND_7", 1);SetTileTag(24,31,"LAND_7", 1);SetTileTag(25,31,"LAND_7", 1);SetTileTag(26,31,"SOLIDWALL",1);SetTileTag(27,31,"SOLIDWALL",1);SetTileTag(28,31,"LAND_13", 1);SetTileTag(29,31,"LAND_13", 1);SetTileTag(34,31,"LAND_13", 1);SetTileTag(35,31,"LAND_13", 1);SetTileTag(36,31,"SOLIDWALL",1);SetTileTag(37,31,"SOLIDWALL",1);SetTileTag(38,31,"LAND_6", 1);SetTileTag(39,31,"SOLIDWALL",1);SetTileTag(40,31,"SOLIDWALL",1);SetTileTag(41,31,"SOLIDWALL",1);SetTileTag(42,31,"SOLIDWALL",1);SetTileTag(44,31,"LAND_6", 1);SetTileTag(45,31,"LAND_6", 1);SetTileTag(47,31,"SOLIDWALL",1);SetTileTag(49,31,"LAND_6", 1);SetTileTag(50,31,"SOLIDWALL",1);SetTileTag(52,31,"SOLIDWALL",1);SetTileTag(56,31,"SOLIDWALL",1);SetTileTag(57,31,"LAND_6", 1);SetTileTag(59,31,"LAND_6", 1);
		SetTileTag(3,30,"SOLIDWALL",1);SetTileTag(7,30,"LAND_1", 1);SetTileTag(8,30,"LAND_1", 1);SetTileTag(10,30,"SOLIDWALL",1);SetTileTag(11,30,"SOLIDWALL",1);SetTileTag(12,30,"SOLIDWALL",1);SetTileTag(14,30,"SOLIDWALL",1);SetTileTag(15,30,"SOLIDWALL",1);SetTileTag(16,30,"SOLIDWALL",1);SetTileTag(17,30,"SOLIDWALL",1);SetTileTag(18,30,"SOLIDWALL",1);SetTileTag(19,30,"SOLIDWALL",1);SetTileTag(20,30,"SOLIDWALL",1);SetTileTag(21,30,"SOLIDWALL",1);SetTileTag(23,30,"SOLIDWALL",1);SetTileTag(24,30,"LAND_7", 1);SetTileTag(25,30,"SOLIDWALL",1);SetTileTag(28,30,"SOLIDWALL",1);SetTileTag(29,30,"LAND_13", 1);SetTileTag(30,30,"LAND_13", 1);SetTileTag(33,30,"LAND_13", 1);SetTileTag(34,30,"LAND_13", 1);SetTileTag(35,30,"SOLIDWALL",1);SetTileTag(36,30,"LAND_6", 1);SetTileTag(41,30,"SOLIDWALL",1);SetTileTag(42,30,"SOLIDWALL",1);SetTileTag(44,30,"SOLIDWALL",1);SetTileTag(46,30,"LAND_6", 1);SetTileTag(48,30,"LAND_6", 1);SetTileTag(51,30,"LAND_6", 1);SetTileTag(55,30,"LAND_6", 1);SetTileTag(56,30,"LAND_6", 1);SetTileTag(57,30,"SOLIDWALL",1);SetTileTag(60,30,"SOLIDWALL",1);
		SetTileTag(4,29,"LAND_1", 1);SetTileTag(5,29,"LAND_1", 1);SetTileTag(6,29,"LAND_1", 1);SetTileTag(7,29,"SOLIDWALL",1);SetTileTag(12,29,"SOLIDWALL",1);SetTileTag(14,29,"SOLIDWALL",1);SetTileTag(17,29,"LAND_7", 1);SetTileTag(18,29,"SOLIDWALL",1);SetTileTag(19,29,"LAND_6", 1);SetTileTag(20,29,"LAND_6", 1);SetTileTag(21,29,"SOLIDWALL",1);SetTileTag(22,29,"SOLIDWALL",1);SetTileTag(23,29,"SOLIDWALL",1);SetTileTag(24,29,"SOLIDWALL",1);SetTileTag(29,29,"SOLIDWALL",1);SetTileTag(30,29,"LAND_13", 1);SetTileTag(31,29,"LAND_13", 1);SetTileTag(32,29,"LAND_13", 1);SetTileTag(33,29,"LAND_13", 1);SetTileTag(34,29,"SOLIDWALL",1);SetTileTag(35,29,"LAVA_4", 1);SetTileTag(36,29,"LAVA_4", 1);SetTileTag(39,29,"LAVA_4", 1);SetTileTag(41,29,"SOLIDWALL",1);SetTileTag(43,29,"LAND_6", 1);SetTileTag(45,29,"SOLIDWALL",1);SetTileTag(46,29,"SOLIDWALL",1);SetTileTag(48,29,"SOLIDWALL",1);SetTileTag(49,29,"SOLIDWALL",1);SetTileTag(51,29,"SOLIDWALL",1);SetTileTag(53,29,"LAND_6", 1);SetTileTag(55,29,"SOLIDWALL",1);
		SetTileTag(2,28,"SOLIDWALL",1);SetTileTag(4,28,"SOLIDWALL",1);SetTileTag(5,28,"SOLIDWALL",1);SetTileTag(6,28,"SOLIDWALL",1);SetTileTag(8,28,"SOLIDWALL",1);SetTileTag(9,28,"LAND_1", 1);SetTileTag(10,28,"LAND_1", 1);SetTileTag(11,28,"LAND_1", 1);SetTileTag(12,28,"SOLIDWALL",1);SetTileTag(13,28,"LAND_7", 1);SetTileTag(14,28,"LAND_7", 1);SetTileTag(17,28,"SOLIDWALL",1);SetTileTag(18,28,"SOLIDWALL",1);SetTileTag(19,28,"LAND_6", 1);SetTileTag(20,28,"LAND_6", 1);SetTileTag(21,28,"LAND_6", 1);SetTileTag(22,28,"LAND_6", 1);SetTileTag(23,28,"LAND_6", 1);SetTileTag(24,28,"LAND_6", 1);SetTileTag(25,28,"SOLIDWALL",1);SetTileTag(30,28,"SOLIDWALL",1);SetTileTag(31,28,"SOLIDWALL",1);SetTileTag(32,28,"SOLIDWALL",1);SetTileTag(33,28,"LAVA_4", 1);SetTileTag(36,28,"LAND_20", 1);SetTileTag(39,28,"LAND_20", 1);SetTileTag(41,28,"LAVA_4", 1);SetTileTag(43,28,"SOLIDWALL",1);SetTileTag(47,28,"LAND_6", 1);SetTileTag(49,28,"LAND_6", 1);SetTileTag(50,28,"LAND_6", 1);SetTileTag(55,28,"LAND_6", 1);SetTileTag(60,28,"LAND_6", 1);SetTileTag(61,28,"LAND_6", 1);
		SetTileTag(1,27,"SOLIDWALL",1);SetTileTag(2,27,"LAND_1", 1);SetTileTag(4,27,"SOLIDWALL",1);SetTileTag(6,27,"SOLIDWALL",1);SetTileTag(13,27,"SOLIDWALL",1);SetTileTag(14,27,"LAND_7", 1);SetTileTag(17,27,"LAND_7", 1);SetTileTag(18,27,"SOLIDWALL",1);SetTileTag(19,27,"SOLIDWALL",1);SetTileTag(22,27,"SOLIDWALL",1);SetTileTag(23,27,"LAND_6", 1);SetTileTag(24,27,"LAND_6", 1);SetTileTag(25,27,"LAND_6", 1);SetTileTag(26,27,"SOLIDWALL",1);SetTileTag(30,27,"SOLIDWALL",1);SetTileTag(31,27,"LAND_14", 1);SetTileTag(34,27,"LAVA_4", 1);SetTileTag(38,27,"LAVA_4", 1);SetTileTag(41,27,"LAVA_4", 1);SetTileTag(42,27,"SOLIDWALL",1);SetTileTag(45,27,"LAND_6", 1);SetTileTag(47,27,"SOLIDWALL",1);SetTileTag(49,27,"SOLIDWALL",1);SetTileTag(52,27,"LAND_6", 1);SetTileTag(53,27,"SOLIDWALL",1);SetTileTag(55,27,"SOLIDWALL",1);SetTileTag(58,27,"LAND_6", 1);SetTileTag(60,27,"SOLIDWALL",1);SetTileTag(62,27,"SOLIDWALL",1);
		SetTileTag(3,26,"LAND_1", 1);SetTileTag(4,26,"SOLIDWALL",1);SetTileTag(5,26,"SOLIDWALL",1);SetTileTag(6,26,"WATER_1", 1);SetTileTag(14,26,"WATER_1", 1);SetTileTag(15,26,"LAND_7", 1);SetTileTag(16,26,"LAND_7", 1);SetTileTag(17,26,"LAND_7", 1);SetTileTag(18,26,"SOLIDWALL",1);SetTileTag(19,26,"SOLIDWALL",1);SetTileTag(21,26,"SOLIDWALL",1);SetTileTag(23,26,"SOLIDWALL",1);SetTileTag(24,26,"LAND_6", 1);SetTileTag(25,26,"LAND_6", 1);SetTileTag(26,26,"LAND_6", 1);SetTileTag(27,26,"SOLIDWALL",1);SetTileTag(29,26,"SOLIDWALL",1);SetTileTag(31,26,"SOLIDWALL",1);SetTileTag(32,26,"LAVA_4", 1);SetTileTag(34,26,"LAND_17", 1);SetTileTag(38,26,"LAND_20", 1);SetTileTag(41,26,"LAND_20", 1);SetTileTag(42,26,"SOLIDWALL",1);SetTileTag(45,26,"SOLIDWALL",1);SetTileTag(47,26,"LAND_6", 1);SetTileTag(50,26,"LAND_6", 1);SetTileTag(54,26,"LAND_6", 1);SetTileTag(58,26,"SOLIDWALL",1);SetTileTag(59,26,"SOLIDWALL",1);SetTileTag(61,26,"LAND_6", 1);
		SetTileTag(1,25,"SOLIDWALL",1);SetTileTag(2,25,"LAND_1", 1);SetTileTag(3,25,"LAND_1", 1);SetTileTag(4,25,"SOLIDWALL",1);SetTileTag(5,25,"SOLIDWALL",1);SetTileTag(8,25,"WATER_1", 1);SetTileTag(9,25,"WATER_1", 1);SetTileTag(10,25,"WATER_1", 1);SetTileTag(11,25,"WATER_1", 1);SetTileTag(12,25,"WATER_1", 1);SetTileTag(15,25,"SOLIDWALL",1);SetTileTag(16,25,"SOLIDWALL",1);SetTileTag(17,25,"SOLIDWALL",1);SetTileTag(18,25,"LAND_6", 1);SetTileTag(19,25,"LAND_6", 1);SetTileTag(20,25,"LAND_6", 1);SetTileTag(21,25,"LAND_6", 1);SetTileTag(22,25,"SOLIDWALL",1);SetTileTag(24,25,"SOLIDWALL",1);SetTileTag(25,25,"LAND_6", 1);SetTileTag(26,25,"LAND_6", 1);SetTileTag(27,25,"LAND_6", 1);SetTileTag(28,25,"SOLIDWALL",1);SetTileTag(30,25,"LAND_6", 1);SetTileTag(31,25,"SOLIDWALL",1);SetTileTag(32,25,"LAND_15", 1);SetTileTag(33,25,"LAVA_4", 1);SetTileTag(36,25,"LAVA_4", 1);SetTileTag(39,25,"LAVA_4", 1);SetTileTag(42,25,"SOLIDWALL",1);SetTileTag(44,25,"LAND_6", 1);SetTileTag(47,25,"SOLIDWALL",1);SetTileTag(52,25,"SOLIDWALL",1);SetTileTag(54,25,"SOLIDWALL",1);SetTileTag(56,25,"LAND_6", 1);SetTileTag(58,25,"LAND_6", 1);SetTileTag(61,25,"SOLIDWALL",1);
		SetTileTag(1,24,"SOLIDWALL",1);SetTileTag(2,24,"LAND_1", 1);SetTileTag(3,24,"SOLIDWALL",1);SetTileTag(4,24,"SOLIDWALL",1);SetTileTag(5,24,"WATER_1", 1);SetTileTag(8,24,"SOLIDWALL",1);SetTileTag(9,24,"SOLIDWALL",1);SetTileTag(10,24,"SOLIDWALL",1);SetTileTag(12,24,"SOLIDWALL",1);SetTileTag(15,24,"SOLIDWALL",1);SetTileTag(16,24,"SOLIDWALL",1);SetTileTag(17,24,"WATER_1", 1);SetTileTag(22,24,"WATER_1", 1);SetTileTag(23,24,"WATER_1", 1);SetTileTag(24,24,"SOLIDWALL",1);SetTileTag(25,24,"SOLIDWALL",1);SetTileTag(26,24,"LAND_6", 1);SetTileTag(27,24,"LAND_6", 1);SetTileTag(28,24,"LAND_6", 1);SetTileTag(29,24,"LAND_6", 1);SetTileTag(30,24,"LAND_6", 1);SetTileTag(31,24,"SOLIDWALL",1);SetTileTag(32,24,"SOLIDWALL",1);SetTileTag(33,24,"LAVA_4", 1);SetTileTag(36,24,"LAND_20", 1);SetTileTag(39,24,"LAND_20", 1);SetTileTag(41,24,"LAVA_4", 1);SetTileTag(42,24,"SOLIDWALL",1);SetTileTag(45,24,"LAND_6", 1);SetTileTag(48,24,"LAND_6", 1);SetTileTag(49,24,"LAND_6", 1);SetTileTag(50,24,"SOLIDWALL",1);SetTileTag(52,24,"LAND_6", 1);SetTileTag(54,24,"LAND_6", 1);SetTileTag(55,24,"LAND_6", 1);SetTileTag(56,24,"SOLIDWALL",1);SetTileTag(58,24,"SOLIDWALL",1);SetTileTag(59,24,"LAND_6", 1);SetTileTag(62,24,"LAND_6", 1);SetTileTag(63,24,"SOLIDWALL",1);
		SetTileTag(1,23,"SOLIDWALL",1);SetTileTag(2,23,"LAND_1", 1);SetTileTag(3,23,"LAND_1", 1);SetTileTag(7,23,"WATER_1", 1);SetTileTag(8,23,"LAND_6", 1);SetTileTag(11,23,"LAND_6", 1);SetTileTag(12,23,"LAND_6", 1);SetTileTag(18,23,"WATER_1", 1);SetTileTag(19,23,"WATER_1", 1);SetTileTag(20,23,"WATER_1", 1);SetTileTag(21,23,"WATER_1", 1);SetTileTag(22,23,"WATER_1", 1);SetTileTag(24,23,"WATER_1", 1);SetTileTag(26,23,"SOLIDWALL",1);SetTileTag(27,23,"LAND_6", 1);SetTileTag(28,23,"LAND_6", 1);SetTileTag(29,23,"LAND_6", 1);SetTileTag(30,23,"SOLIDWALL",1);SetTileTag(31,23,"SOLIDWALL",1);SetTileTag(32,23,"SOLIDWALL",1);SetTileTag(33,23,"SOLIDWALL",1);SetTileTag(34,23,"LAVA_4", 1);SetTileTag(37,23,"LAVA_4", 1);SetTileTag(41,23,"LAND_20", 1);SetTileTag(44,23,"SOLIDWALL",1);SetTileTag(45,23,"SOLIDWALL",1);SetTileTag(46,23,"LAND_6", 1);SetTileTag(48,23,"SOLIDWALL",1);SetTileTag(52,23,"SOLIDWALL",1);SetTileTag(54,23,"SOLIDWALL",1);SetTileTag(57,23,"LAND_6", 1);
		SetTileTag(2,22,"LAND_1", 1);SetTileTag(4,22,"SOLIDWALL",1);SetTileTag(7,22,"WATER_1", 1);SetTileTag(8,22,"SOLIDWALL",1);SetTileTag(9,22,"LAND_6", 1);SetTileTag(10,22,"LAND_6", 1);SetTileTag(11,22,"LAND_6", 1);SetTileTag(12,22,"LAND_6", 1);SetTileTag(13,22,"WATER_1", 1);SetTileTag(18,22,"SOLIDWALL",1);SetTileTag(19,22,"SOLIDWALL",1);SetTileTag(21,22,"SOLIDWALL",1);SetTileTag(22,22,"WATER_1", 1);SetTileTag(25,22,"SOLIDWALL",1);SetTileTag(26,22,"LAND_6", 1);SetTileTag(28,22,"LAND_6", 1);SetTileTag(29,22,"LAND_6", 1);SetTileTag(30,22,"SOLIDWALL",1);SetTileTag(31,22,"LAND_6", 1);SetTileTag(32,22,"LAND_6", 1);SetTileTag(33,22,"SOLIDWALL",1);SetTileTag(34,22,"LAND_16", 1);SetTileTag(37,22,"LAND_20", 1);SetTileTag(39,22,"LAVA_4", 1);SetTileTag(41,22,"LAVA_4", 1);SetTileTag(44,22,"LAND_6", 1);SetTileTag(46,22,"SOLIDWALL",1);SetTileTag(49,22,"SOLIDWALL",1);SetTileTag(51,22,"LAND_6", 1);SetTileTag(52,22,"LAND_6", 1);SetTileTag(53,22,"LAND_6", 1);SetTileTag(54,22,"LAND_6", 1);SetTileTag(57,22,"SOLIDWALL",1);
		SetTileTag(2,21,"LAND_1", 1);SetTileTag(4,21,"WATER_1", 1);SetTileTag(6,21,"WATER_1", 1);SetTileTag(7,21,"SOLIDWALL",1);SetTileTag(9,21,"LAND_6", 1);SetTileTag(10,21,"LAND_6", 1);SetTileTag(12,21,"SOLIDWALL",1);SetTileTag(13,21,"WATER_1", 1);SetTileTag(14,21,"WATER_1", 1);SetTileTag(15,21,"WATER_1", 1);SetTileTag(16,21,"WATER_1", 1);SetTileTag(17,21,"WATER_1", 1);SetTileTag(18,21,"SOLIDWALL",1);SetTileTag(19,21,"SOLIDWALL",1);SetTileTag(21,21,"SOLIDWALL",1);SetTileTag(22,21,"SOLIDWALL",1);SetTileTag(25,21,"SOLIDWALL",1);SetTileTag(26,21,"LAND_6", 1);SetTileTag(28,21,"SOLIDWALL",1);SetTileTag(29,21,"LAND_6", 1);SetTileTag(30,21,"SOLIDWALL",1);SetTileTag(31,21,"SOLIDWALL",1);SetTileTag(32,21,"LAND_6", 1);SetTileTag(33,21,"LAND_6", 1);SetTileTag(34,21,"LAVA_4", 1);SetTileTag(35,21,"LAVA_4", 1);SetTileTag(36,21,"LAVA_4", 1);SetTileTag(37,21,"LAVA_4", 1);SetTileTag(38,21,"LAVA_4", 1);SetTileTag(39,21,"LAND_20", 1);SetTileTag(41,21,"LAND_20", 1);SetTileTag(44,21,"SOLIDWALL",1);SetTileTag(46,21,"LAND_6", 1);SetTileTag(47,21,"LAND_6", 1);SetTileTag(48,21,"LAND_6", 1);SetTileTag(50,21,"LAND_6", 1);SetTileTag(51,21,"SOLIDWALL",1);SetTileTag(56,21,"LAND_6", 1);SetTileTag(57,21,"LAND_6", 1);SetTileTag(58,21,"LAND_6", 1);SetTileTag(59,21,"SOLIDWALL",1);
		SetTileTag(2,20,"LAND_1", 1);SetTileTag(6,20,"WATER_1", 1);SetTileTag(7,20,"SOLIDWALL",1);SetTileTag(9,20,"LAND_6", 1);SetTileTag(10,20,"LAND_6", 1);SetTileTag(13,20,"SOLIDWALL",1);SetTileTag(17,20,"SOLIDWALL",1);SetTileTag(18,20,"SOLIDWALL",1);SetTileTag(19,20,"LAND_6", 1);SetTileTag(21,20,"SOLIDWALL",1);SetTileTag(22,20,"LAND_10", 1);SetTileTag(25,20,"WATER_1", 1);SetTileTag(27,20,"SOLIDWALL",1);SetTileTag(30,20,"LAND_6", 1);SetTileTag(31,20,"LAND_6", 1);SetTileTag(32,20,"LAND_6", 1);SetTileTag(37,20,"SOLIDWALL",1);SetTileTag(38,20,"LAVA_4", 1);SetTileTag(39,20,"LAVA_4", 1);SetTileTag(40,20,"LAVA_4", 1);SetTileTag(41,20,"LAVA_4", 1);SetTileTag(42,20,"SOLIDWALL",1);SetTileTag(44,20,"LAND_6", 1);SetTileTag(45,20,"LAND_6", 1);SetTileTag(46,20,"SOLIDWALL",1);SetTileTag(50,20,"SOLIDWALL",1);SetTileTag(51,20,"LAND_6", 1);SetTileTag(54,20,"LAND_6", 1);SetTileTag(56,20,"SOLIDWALL",1);SetTileTag(60,20,"LAND_6", 1);
		SetTileTag(2,19,"LAND_1", 1);SetTileTag(10,19,"LAND_6", 1);SetTileTag(11,19,"SOLIDWALL",1);SetTileTag(12,19,"SOLIDWALL",1);SetTileTag(17,19,"LAND_6", 1);SetTileTag(21,19,"LAND_6", 1);SetTileTag(30,19,"SOLIDWALL",1);SetTileTag(31,19,"SOLIDWALL",1);SetTileTag(32,19,"SOLIDWALL",1);SetTileTag(36,19,"SOLIDWALL",1);SetTileTag(38,19,"SOLIDWALL",1);SetTileTag(42,19,"SOLIDWALL",1);SetTileTag(44,19,"SOLIDWALL",1);SetTileTag(54,19,"SOLIDWALL",1);SetTileTag(58,19,"LAND_6", 1);SetTileTag(60,19,"SOLIDWALL",1);SetTileTag(62,19,"SOLIDWALL",1);
		SetTileTag(2,18,"LAND_1", 1);SetTileTag(6,18,"SOLIDWALL",1);SetTileTag(10,18,"LAND_6", 1);SetTileTag(11,18,"LAND_6", 1);SetTileTag(12,18,"LAND_6", 1);SetTileTag(13,18,"LAND_6", 1);SetTileTag(14,18,"LAND_6", 1);SetTileTag(15,18,"LAND_6", 1);SetTileTag(16,18,"LAND_6", 1);SetTileTag(17,18,"LAND_6", 1);SetTileTag(18,18,"LAND_6", 1);SetTileTag(19,18,"LAND_6", 1);SetTileTag(20,18,"LAND_6", 1);SetTileTag(21,18,"LAND_6", 1);SetTileTag(25,18,"WATER_1", 1);SetTileTag(30,18,"LAND_6", 1);SetTileTag(31,18,"SOLIDWALL",1);SetTileTag(35,18,"SOLIDWALL",1);SetTileTag(37,18,"SOLIDWALL",1);SetTileTag(39,18,"LAND_6", 1);SetTileTag(42,18,"SOLIDWALL",1);SetTileTag(43,18,"LAND_6", 1);SetTileTag(44,18,"LAND_6", 1);SetTileTag(46,18,"LAND_6", 1);SetTileTag(47,18,"LAND_6", 1);SetTileTag(48,18,"SOLIDWALL",1);SetTileTag(49,18,"LAND_6", 1);SetTileTag(50,18,"LAND_6", 1);SetTileTag(51,18,"SOLIDWALL",1);SetTileTag(52,18,"LAND_6", 1);SetTileTag(53,18,"LAND_6", 1);SetTileTag(54,18,"LAND_6", 1);SetTileTag(55,18,"LAND_6", 1);SetTileTag(56,18,"LAND_6", 1);SetTileTag(57,18,"LAND_6", 1);SetTileTag(58,18,"SOLIDWALL",1);SetTileTag(59,18,"LAND_6", 1);SetTileTag(60,18,"LAND_6", 1);SetTileTag(61,18,"LAND_6", 1);SetTileTag(62,18,"SOLIDWALL",1);
		SetTileTag(2,17,"LAND_1", 1);SetTileTag(6,17,"WATER_1", 1);SetTileTag(8,17,"SOLIDWALL",1);SetTileTag(9,17,"LAND_6", 1);SetTileTag(10,17,"LAND_6", 1);SetTileTag(11,17,"SOLIDWALL",1);SetTileTag(12,17,"SOLIDWALL",1);SetTileTag(15,17,"SOLIDWALL",1);SetTileTag(17,17,"LAND_6", 1);SetTileTag(18,17,"LAND_6", 1);SetTileTag(19,17,"LAND_6", 1);SetTileTag(20,17,"LAND_6", 1);SetTileTag(21,17,"LAND_6", 1);SetTileTag(25,17,"WATER_1", 1);SetTileTag(26,17,"SOLIDWALL",1);SetTileTag(28,17,"SOLIDWALL",1);SetTileTag(29,17,"LAND_6", 1);SetTileTag(30,17,"LAND_6", 1);SetTileTag(33,17,"SOLIDWALL",1);SetTileTag(36,17,"LAND_6", 1);SetTileTag(37,17,"LAND_6", 1);SetTileTag(40,17,"SOLIDWALL",1);SetTileTag(41,17,"LAND_6", 1);SetTileTag(42,17,"SOLIDWALL",1);SetTileTag(43,17,"SOLIDWALL",1);SetTileTag(44,17,"SOLIDWALL",1);SetTileTag(49,17,"SOLIDWALL",1);SetTileTag(52,17,"SOLIDWALL",1);SetTileTag(53,17,"SOLIDWALL",1);SetTileTag(54,17,"LAND_6", 1);SetTileTag(55,17,"SOLIDWALL",1);SetTileTag(56,17,"SOLIDWALL",1);SetTileTag(59,17,"SOLIDWALL",1);SetTileTag(61,17,"SOLIDWALL",1);
		SetTileTag(2,16,"LAND_1", 1);SetTileTag(9,16,"SOLIDWALL",1);SetTileTag(10,16,"SOLIDWALL",1);SetTileTag(11,16,"SOLIDWALL",1);SetTileTag(12,16,"LAND_6", 1);SetTileTag(13,16,"LAND_6", 1);SetTileTag(14,16,"SOLIDWALL",1);SetTileTag(15,16,"SOLIDWALL",1);SetTileTag(16,16,"SOLIDWALL",1);SetTileTag(19,16,"LAND_6", 1);SetTileTag(25,16,"SOLIDWALL",1);SetTileTag(28,16,"SOLIDWALL",1);SetTileTag(29,16,"LAND_6", 1);SetTileTag(30,16,"LAND_6", 1);SetTileTag(32,16,"SOLIDWALL",1);SetTileTag(34,16,"LAND_6", 1);SetTileTag(35,16,"LAND_6", 1);SetTileTag(36,16,"SOLIDWALL",1);SetTileTag(38,16,"SOLIDWALL",1);SetTileTag(40,16,"SOLIDWALL",1);SetTileTag(41,16,"LAND_6", 1);SetTileTag(43,16,"SOLIDWALL",1);SetTileTag(52,16,"SOLIDWALL",1);SetTileTag(56,16,"SOLIDWALL",1);
		SetTileTag(7,15,"SOLIDWALL",1);SetTileTag(9,15,"SOLIDWALL",1);SetTileTag(11,15,"LAND_6", 1);SetTileTag(12,15,"LAND_6", 1);SetTileTag(13,15,"LAND_6", 1);SetTileTag(15,15,"LAND_6", 1);SetTileTag(16,15,"LAND_6", 1);SetTileTag(17,15,"LAND_6", 1);SetTileTag(19,15,"SOLIDWALL",1);SetTileTag(24,15,"WATER_1", 1);SetTileTag(25,15,"WATER_1", 1);SetTileTag(26,15,"SOLIDWALL",1);SetTileTag(27,15,"SOLIDWALL",1);SetTileTag(28,15,"SOLIDWALL",1);SetTileTag(30,15,"LAND_6", 1);SetTileTag(31,15,"SOLIDWALL",1);SetTileTag(32,15,"LAND_6", 1);SetTileTag(34,15,"SOLIDWALL",1);SetTileTag(35,15,"LAND_6", 1);SetTileTag(36,15,"LAND_6", 1);SetTileTag(39,15,"LAND_6", 1);SetTileTag(40,15,"SOLIDWALL",1);SetTileTag(41,15,"SOLIDWALL",1);SetTileTag(42,15,"LAND_6", 1);SetTileTag(43,15,"SOLIDWALL",1);SetTileTag(52,15,"SOLIDWALL",1);SetTileTag(53,15,"LAND_6", 1);SetTileTag(55,15,"LAND_6", 1);SetTileTag(56,15,"SOLIDWALL",1);
		SetTileTag(4,14,"WATER_1", 1);SetTileTag(7,14,"SOLIDWALL",1);SetTileTag(8,14,"SOLIDWALL",1);SetTileTag(9,14,"LAND_6", 1);SetTileTag(12,14,"LAND_6", 1);SetTileTag(13,14,"SOLIDWALL",1);SetTileTag(14,14,"SOLIDWALL",1);SetTileTag(16,14,"SOLIDWALL",1);SetTileTag(17,14,"LAND_6", 1);SetTileTag(18,14,"LAND_6", 1);SetTileTag(20,14,"LAND_6", 1);SetTileTag(21,14,"LAND_6", 1);SetTileTag(24,14,"LAND_6", 1);SetTileTag(26,14,"LAND_6", 1);SetTileTag(27,14,"LAND_6", 1);SetTileTag(28,14,"LAND_6", 1);SetTileTag(29,14,"LAND_6", 1);SetTileTag(30,14,"LAND_6", 1);SetTileTag(31,14,"SOLIDWALL",1);SetTileTag(32,14,"LAND_6", 1);SetTileTag(33,14,"LAND_6", 1);SetTileTag(34,14,"SOLIDWALL",1);SetTileTag(35,14,"SOLIDWALL",1);SetTileTag(37,14,"SOLIDWALL",1);SetTileTag(38,14,"LAND_6", 1);SetTileTag(39,14,"SOLIDWALL",1);SetTileTag(40,14,"SOLIDWALL",1);SetTileTag(41,14,"LAND_6", 1);SetTileTag(43,14,"LAND_6", 1);SetTileTag(44,14,"SOLIDWALL",1);SetTileTag(52,14,"SOLIDWALL",1);SetTileTag(53,14,"SOLIDWALL",1);SetTileTag(54,14,"LAND_6", 1);SetTileTag(55,14,"SOLIDWALL",1);SetTileTag(56,14,"SOLIDWALL",1);
		SetTileTag(2,13,"LAND_1", 1);SetTileTag(4,13,"WATER_1", 1);SetTileTag(7,13,"WATER_1", 1);SetTileTag(9,13,"LAND_6", 1);SetTileTag(12,13,"LAND_6", 1);SetTileTag(13,13,"LAND_6", 1);SetTileTag(14,13,"LAND_6", 1);SetTileTag(15,13,"LAND_6", 1);SetTileTag(16,13,"LAND_6", 1);SetTileTag(17,13,"LAND_6", 1);SetTileTag(18,13,"LAND_6", 1);SetTileTag(20,13,"LAND_6", 1);SetTileTag(21,13,"LAND_6", 1);SetTileTag(26,13,"SOLIDWALL",1);SetTileTag(27,13,"SOLIDWALL",1);SetTileTag(32,13,"SOLIDWALL",1);SetTileTag(33,13,"SOLIDWALL",1);SetTileTag(34,13,"SOLIDWALL",1);SetTileTag(35,13,"SOLIDWALL",1);SetTileTag(36,13,"LAND_6", 1);SetTileTag(37,13,"LAND_6", 1);SetTileTag(38,13,"SOLIDWALL",1);SetTileTag(39,13,"SOLIDWALL",1);SetTileTag(41,13,"LAND_6", 1);SetTileTag(43,13,"LAND_6", 1);SetTileTag(51,13,"SOLIDWALL",1);SetTileTag(52,13,"LAND_6", 1);SetTileTag(56,13,"LAND_6", 1);SetTileTag(57,13,"SOLIDWALL",1);
		SetTileTag(2,12,"LAND_1", 1);SetTileTag(4,12,"SOLIDWALL",1);SetTileTag(9,12,"LAND_6", 1);SetTileTag(13,12,"SOLIDWALL",1);SetTileTag(14,12,"SOLIDWALL",1);SetTileTag(15,12,"SOLIDWALL",1);SetTileTag(17,12,"SOLIDWALL",1);SetTileTag(18,12,"SOLIDWALL",1);SetTileTag(19,12,"LAND_6", 1);SetTileTag(20,12,"SOLIDWALL",1);SetTileTag(21,12,"SOLIDWALL",1);SetTileTag(23,12,"WATER_1", 1);SetTileTag(24,12,"WATER_1", 1);SetTileTag(25,12,"WATER_1", 1);SetTileTag(26,12,"SOLIDWALL",1);SetTileTag(30,12,"SOLIDWALL",1);SetTileTag(31,12,"SOLIDWALL",1);SetTileTag(32,12,"LAND_6", 1);SetTileTag(33,12,"SOLIDWALL",1);SetTileTag(35,12,"LAND_6", 1);SetTileTag(36,12,"LAND_6", 1);SetTileTag(37,12,"LAND_6", 1);SetTileTag(38,12,"LAND_6", 1);SetTileTag(40,12,"LAND_6", 1);SetTileTag(41,12,"LAND_6", 1);SetTileTag(42,12,"LAND_6", 1);SetTileTag(43,12,"LAND_6", 1);SetTileTag(44,12,"SOLIDWALL",1);SetTileTag(45,12,"SOLIDWALL",1);SetTileTag(47,12,"SOLIDWALL",1);SetTileTag(48,12,"SOLIDWALL",1);SetTileTag(50,12,"SOLIDWALL",1);SetTileTag(52,12,"LAND_6", 1);SetTileTag(53,12,"LAND_6", 1);SetTileTag(54,12,"LAND_6", 1);SetTileTag(55,12,"LAND_6", 1);SetTileTag(56,12,"LAND_6", 1);SetTileTag(58,12,"SOLIDWALL",1);
		SetTileTag(1,11,"SOLIDWALL",1);SetTileTag(3,11,"SOLIDWALL",1);SetTileTag(4,11,"WATER_1", 1);SetTileTag(7,11,"WATER_1", 1);SetTileTag(8,11,"SOLIDWALL",1);SetTileTag(9,11,"SOLIDWALL",1);SetTileTag(10,11,"LAND_6", 1);SetTileTag(11,11,"LAND_6", 1);SetTileTag(12,11,"LAND_6", 1);SetTileTag(13,11,"LAND_6", 1);SetTileTag(14,11,"SOLIDWALL",1);SetTileTag(15,11,"LAND_8", 1);SetTileTag(16,11,"LAND_8", 1);SetTileTag(18,11,"LAND_8", 1);SetTileTag(19,11,"SOLIDWALL",1);SetTileTag(20,11,"WATER_1", 1);SetTileTag(22,11,"WATER_1", 1);SetTileTag(23,11,"SOLIDWALL",1);SetTileTag(24,11,"LAND_6", 1);SetTileTag(25,11,"SOLIDWALL",1);SetTileTag(29,11,"SOLIDWALL",1);SetTileTag(30,11,"LAND_6", 1);SetTileTag(34,11,"LAND_6", 1);SetTileTag(35,11,"SOLIDWALL",1);SetTileTag(36,11,"SOLIDWALL",1);SetTileTag(37,11,"SOLIDWALL",1);SetTileTag(38,11,"SOLIDWALL",1);SetTileTag(39,11,"LAND_6", 1);SetTileTag(40,11,"LAND_6", 1);SetTileTag(41,11,"SOLIDWALL",1);SetTileTag(42,11,"SOLIDWALL",1);SetTileTag(43,11,"LAND_6", 1);SetTileTag(45,11,"LAND_6", 1);SetTileTag(46,11,"SOLIDWALL",1);SetTileTag(47,11,"LAND_6", 1);SetTileTag(48,11,"WATER_3", 1);SetTileTag(49,11,"SOLIDWALL",1);SetTileTag(50,11,"LAND_6", 1);SetTileTag(52,11,"LAND_6", 1);SetTileTag(53,11,"LAVA_6", 1);SetTileTag(56,11,"LAND_6", 1);SetTileTag(58,11,"LAND_6", 1);
		SetTileTag(1,10,"SOLIDWALL",1);SetTileTag(2,10,"LAND_1", 1);SetTileTag(3,10,"SOLIDWALL",1);SetTileTag(7,10,"WATER_1", 1);SetTileTag(8,10,"SOLIDWALL",1);SetTileTag(9,10,"SOLIDWALL",1);SetTileTag(10,10,"LAND_6", 1);SetTileTag(11,10,"LAND_6", 1);SetTileTag(12,10,"SOLIDWALL",1);SetTileTag(13,10,"LAND_6", 1);SetTileTag(14,10,"LAND_6", 1);SetTileTag(21,10,"WATER_1", 1);SetTileTag(22,10,"WATER_1", 1);SetTileTag(23,10,"SOLIDWALL",1);SetTileTag(25,10,"LAND_6", 1);SetTileTag(26,10,"SOLIDWALL",1);SetTileTag(29,10,"SOLIDWALL",1);SetTileTag(30,10,"LAND_6", 1);SetTileTag(31,10,"SOLIDWALL",1);SetTileTag(32,10,"SOLIDWALL",1);SetTileTag(33,10,"SOLIDWALL",1);SetTileTag(34,10,"SOLIDWALL",1);SetTileTag(35,10,"SOLIDWALL",1);SetTileTag(36,10,"LAND_6", 1);SetTileTag(37,10,"LAND_6", 1);SetTileTag(38,10,"LAND_6", 1);SetTileTag(39,10,"LAND_6", 1);SetTileTag(40,10,"LAND_6", 1);SetTileTag(41,10,"LAND_6", 1);SetTileTag(42,10,"SOLIDWALL",1);SetTileTag(43,10,"LAND_6", 1);SetTileTag(45,10,"LAND_6", 1);SetTileTag(46,10,"LAND_6", 1);SetTileTag(47,10,"LAND_6", 1);SetTileTag(48,10,"LAND_6", 1);SetTileTag(49,10,"SOLIDWALL",1);SetTileTag(53,10,"LAND_20", 1);SetTileTag(54,10,"LAND_20", 1);SetTileTag(55,10,"LAND_20", 1);
		SetTileTag(1,9,"SOLIDWALL",1);SetTileTag(3,9,"WATER_1", 1);SetTileTag(6,9,"WATER_1", 1);SetTileTag(7,9,"SOLIDWALL",1);SetTileTag(10,9,"SOLIDWALL",1);SetTileTag(11,9,"SOLIDWALL",1);SetTileTag(12,9,"WATER_1", 1);SetTileTag(16,9,"WATER_1", 1);SetTileTag(17,9,"WATER_1", 1);SetTileTag(18,9,"WATER_1", 1);SetTileTag(19,9,"WATER_1", 1);SetTileTag(20,9,"WATER_1", 1);SetTileTag(21,9,"SOLIDWALL",1);SetTileTag(22,9,"SOLIDWALL",1);SetTileTag(23,9,"LAND_6", 1);SetTileTag(26,9,"SOLIDWALL",1);SetTileTag(30,9,"SOLIDWALL",1);SetTileTag(31,9,"SOLIDWALL",1);SetTileTag(32,9,"LAND_6", 1);SetTileTag(33,9,"LAND_6", 1);SetTileTag(34,9,"LAND_6", 1);SetTileTag(35,9,"LAND_6", 1);SetTileTag(36,9,"LAND_6", 1);SetTileTag(38,9,"LAND_6", 1);SetTileTag(39,9,"SOLIDWALL",1);SetTileTag(40,9,"LAND_6", 1);SetTileTag(41,9,"SOLIDWALL",1);SetTileTag(42,9,"SOLIDWALL",1);SetTileTag(43,9,"LAND_6", 1);SetTileTag(44,9,"LAND_6", 1);SetTileTag(45,9,"LAND_6", 1);SetTileTag(46,9,"SOLIDWALL",1);SetTileTag(47,9,"LAND_6", 1);SetTileTag(48,9,"SOLIDWALL",1);SetTileTag(49,9,"SOLIDWALL",1);SetTileTag(53,9,"LAND_20", 1);SetTileTag(54,9,"LAND_20", 1);SetTileTag(55,9,"LAND_20", 1);
		SetTileTag(1,8,"SOLIDWALL",1);SetTileTag(2,8,"WATER_1", 1);SetTileTag(3,8,"LAND_4", 1);SetTileTag(5,8,"WATER_1", 1);SetTileTag(6,8,"WATER_1", 1);SetTileTag(7,8,"SOLIDWALL",1);SetTileTag(10,8,"SOLIDWALL",1);SetTileTag(11,8,"WATER_1", 1);SetTileTag(14,8,"WATER_1", 1);SetTileTag(15,8,"WATER_1", 1);SetTileTag(16,8,"WATER_1", 1);SetTileTag(17,8,"SOLIDWALL",1);SetTileTag(19,8,"SOLIDWALL",1);SetTileTag(20,8,"SOLIDWALL",1);SetTileTag(22,8,"SOLIDWALL",1);SetTileTag(23,8,"LAND_6", 1);SetTileTag(26,8,"LAND_6", 1);SetTileTag(31,8,"LAND_6", 1);SetTileTag(32,8,"LAND_6", 1);SetTileTag(34,8,"LAND_6", 1);SetTileTag(35,8,"SOLIDWALL",1);SetTileTag(36,8,"LAND_6", 1);SetTileTag(37,8,"LAND_6", 1);SetTileTag(38,8,"LAND_6", 1);SetTileTag(39,8,"SOLIDWALL",1);SetTileTag(41,8,"LAND_6", 1);SetTileTag(42,8,"SOLIDWALL",1);SetTileTag(43,8,"SOLIDWALL",1);SetTileTag(44,8,"SOLIDWALL",1);SetTileTag(45,8,"SOLIDWALL",1);SetTileTag(46,8,"LAND_6", 1);SetTileTag(47,8,"LAND_6", 1);SetTileTag(48,8,"LAND_6", 1);SetTileTag(49,8,"SOLIDWALL",1);SetTileTag(53,8,"LAND_20", 1);SetTileTag(54,8,"LAND_20", 1);SetTileTag(55,8,"LAND_20", 1);
		SetTileTag(0,7,"SOLIDWALL",1);SetTileTag(1,7,"WATER_1", 1);SetTileTag(2,7,"WATER_1", 1);SetTileTag(5,7,"WATER_1", 1);SetTileTag(6,7,"SOLIDWALL",1);SetTileTag(8,7,"SOLIDWALL",1);SetTileTag(9,7,"SOLIDWALL",1);SetTileTag(10,7,"WATER_1", 1);SetTileTag(13,7,"WATER_1", 1);SetTileTag(14,7,"SOLIDWALL",1);SetTileTag(15,7,"SOLIDWALL",1);SetTileTag(16,7,"SOLIDWALL",1);SetTileTag(19,7,"LAND_6", 1);SetTileTag(20,7,"LAND_6", 1);SetTileTag(21,7,"SOLIDWALL",1);SetTileTag(22,7,"SOLIDWALL",1);SetTileTag(26,7,"SOLIDWALL",1);SetTileTag(28,7,"SOLIDWALL",1);SetTileTag(29,7,"SOLIDWALL",1);SetTileTag(31,7,"SOLIDWALL",1);SetTileTag(32,7,"LAND_6", 1);SetTileTag(33,7,"LAND_6", 1);SetTileTag(34,7,"LAND_6", 1);SetTileTag(35,7,"SOLIDWALL",1);SetTileTag(36,7,"LAND_6", 1);SetTileTag(37,7,"SOLIDWALL",1);SetTileTag(38,7,"SOLIDWALL",1);SetTileTag(39,7,"SOLIDWALL",1);SetTileTag(40,7,"LAND_6", 1);SetTileTag(41,7,"LAND_6", 1);SetTileTag(42,7,"SOLIDWALL",1);SetTileTag(44,7,"SOLIDWALL",1);SetTileTag(46,7,"LAND_6", 1);SetTileTag(47,7,"LAND_6", 1);SetTileTag(48,7,"LAND_6", 1);SetTileTag(49,7,"SOLIDWALL",1);SetTileTag(50,7,"LAND_6", 1);SetTileTag(52,7,"LAVA_5", 1);SetTileTag(53,7,"LAND_20", 1);SetTileTag(54,7,"LAND_20", 1);SetTileTag(55,7,"LAND_20", 1);SetTileTag(56,7,"LAVA_7", 1);SetTileTag(58,7,"LAND_6", 1);
		SetTileTag(1,6,"SOLIDWALL",1);SetTileTag(2,6,"WATER_1", 1);SetTileTag(3,6,"WATER_1", 1);SetTileTag(4,6,"WATER_1", 1);SetTileTag(5,6,"SOLIDWALL",1);SetTileTag(7,6,"SOLIDWALL",1);SetTileTag(8,6,"WATER_1", 1);SetTileTag(13,6,"LAND_6", 1);SetTileTag(14,6,"LAND_6", 1);SetTileTag(18,6,"LAND_6", 1);SetTileTag(19,6,"SOLIDWALL",1);SetTileTag(20,6,"LAND_6", 1);SetTileTag(21,6,"SOLIDWALL",1);SetTileTag(22,6,"SOLIDWALL",1);SetTileTag(23,6,"LAND_6", 1);SetTileTag(24,6,"LAND_6", 1);SetTileTag(26,6,"SOLIDWALL",1);SetTileTag(27,6,"LAND_6", 1);SetTileTag(28,6,"LAND_6", 1);SetTileTag(30,6,"LAND_6", 1);SetTileTag(31,6,"LAND_6", 1);SetTileTag(32,6,"SOLIDWALL",1);SetTileTag(33,6,"LAND_6", 1);SetTileTag(37,6,"SOLIDWALL",1);SetTileTag(39,6,"LAND_6", 1);SetTileTag(40,6,"LAND_6", 1);SetTileTag(41,6,"LAND_6", 1);SetTileTag(42,6,"LAND_6", 1);SetTileTag(43,6,"SOLIDWALL",1);SetTileTag(44,6,"SOLIDWALL",1);SetTileTag(45,6,"LAND_6", 1);SetTileTag(46,6,"LAND_6", 1);SetTileTag(47,6,"LAND_6", 1);SetTileTag(48,6,"LAND_6", 1);SetTileTag(49,6,"LAND_6", 1);SetTileTag(50,6,"LAND_6", 1);SetTileTag(51,6,"LAND_6", 1);SetTileTag(52,6,"LAND_6", 1);SetTileTag(53,6,"SOLIDWALL",1);SetTileTag(54,6,"LAND_20", 1);SetTileTag(55,6,"SOLIDWALL",1);SetTileTag(56,6,"LAND_6", 1);SetTileTag(57,6,"LAND_6", 1);SetTileTag(58,6,"LAND_6", 1);
		SetTileTag(1,5,"SOLIDWALL",1);SetTileTag(2,5,"LAND_3", 1);SetTileTag(4,5,"SOLIDWALL",1);SetTileTag(7,5,"WATER_1", 1);SetTileTag(12,5,"WATER_1", 1);SetTileTag(13,5,"SOLIDWALL",1);SetTileTag(14,5,"SOLIDWALL",1);SetTileTag(16,5,"SOLIDWALL",1);SetTileTag(17,5,"LAND_6", 1);SetTileTag(18,5,"SOLIDWALL",1);SetTileTag(19,5,"SOLIDWALL",1);SetTileTag(22,5,"LAND_6", 1);SetTileTag(23,5,"LAND_6", 1);SetTileTag(24,5,"LAND_6", 1);SetTileTag(25,5,"LAND_6", 1);SetTileTag(26,5,"SOLIDWALL",1);SetTileTag(27,5,"LAND_6", 1);SetTileTag(28,5,"SOLIDWALL",1);SetTileTag(29,5,"LAND_6", 1);SetTileTag(31,5,"LAND_6", 1);SetTileTag(32,5,"SOLIDWALL",1);SetTileTag(33,5,"LAND_6", 1);SetTileTag(34,5,"SOLIDWALL",1);SetTileTag(35,5,"SOLIDWALL",1);SetTileTag(36,5,"LAND_6", 1);SetTileTag(37,5,"LAND_6", 1);SetTileTag(38,5,"LAND_6", 1);SetTileTag(39,5,"LAND_6", 1);SetTileTag(40,5,"SOLIDWALL",1);SetTileTag(41,5,"LAND_6", 1);SetTileTag(43,5,"SOLIDWALL",1);SetTileTag(45,5,"SOLIDWALL",1);SetTileTag(46,5,"LAND_6", 1);SetTileTag(47,5,"LAND_6", 1);SetTileTag(48,5,"LAND_6", 1);SetTileTag(49,5,"SOLIDWALL",1);SetTileTag(50,5,"SOLIDWALL",1);SetTileTag(51,5,"LAND_6", 1);SetTileTag(52,5,"LAND_6", 1);SetTileTag(53,5,"LAND_6", 1);SetTileTag(54,5,"SOLIDWALL",1);SetTileTag(55,5,"LAND_6", 1);SetTileTag(56,5,"LAND_6", 1);SetTileTag(57,5,"LAND_6", 1);SetTileTag(58,5,"SOLIDWALL",1);SetTileTag(59,5,"SOLIDWALL",1);SetTileTag(60,5,"SOLIDWALL",1);
		SetTileTag(3,4,"LAND_3", 1);SetTileTag(4,4,"SOLIDWALL",1);SetTileTag(6,4,"SOLIDWALL",1);SetTileTag(11,4,"WATER_1", 1);SetTileTag(12,4,"WATER_1", 1);SetTileTag(13,4,"SOLIDWALL",1);SetTileTag(14,4,"SOLIDWALL",1);SetTileTag(15,4,"LAND_6", 1);SetTileTag(16,4,"SOLIDWALL",1);SetTileTag(17,4,"SOLIDWALL",1);SetTileTag(18,4,"LAND_6", 1);SetTileTag(19,4,"LAND_6", 1);SetTileTag(20,4,"LAND_6", 1);SetTileTag(21,4,"LAND_6", 1);SetTileTag(22,4,"SOLIDWALL",1);SetTileTag(23,4,"SOLIDWALL",1);SetTileTag(24,4,"SOLIDWALL",1);SetTileTag(25,4,"SOLIDWALL",1);SetTileTag(26,4,"LAND_6", 1);SetTileTag(28,4,"SOLIDWALL",1);SetTileTag(29,4,"LAND_6", 1);SetTileTag(30,4,"LAND_6", 1);SetTileTag(31,4,"LAND_6", 1);SetTileTag(32,4,"LAND_6", 1);SetTileTag(33,4,"LAND_6", 1);SetTileTag(35,4,"LAND_6", 1);SetTileTag(37,4,"SOLIDWALL",1);SetTileTag(38,4,"LAND_6", 1);SetTileTag(39,4,"SOLIDWALL",1);SetTileTag(40,4,"SOLIDWALL",1);SetTileTag(41,4,"LAND_6", 1);SetTileTag(42,4,"LAND_6", 1);SetTileTag(43,4,"LAND_6", 1);SetTileTag(44,4,"SOLIDWALL",1);SetTileTag(46,4,"SOLIDWALL",1);SetTileTag(47,4,"LAND_6", 1);SetTileTag(48,4,"SOLIDWALL",1);SetTileTag(50,4,"SOLIDWALL",1);SetTileTag(51,4,"SOLIDWALL",1);SetTileTag(52,4,"LAND_6", 1);SetTileTag(53,4,"LAND_6", 1);SetTileTag(54,4,"LAND_6", 1);SetTileTag(55,4,"LAND_6", 1);SetTileTag(56,4,"LAND_6", 1);SetTileTag(59,4,"LAND_6", 1);
		SetTileTag(10,3,"WATER_1", 1);SetTileTag(11,3,"SOLIDWALL",1);SetTileTag(13,3,"SOLIDWALL",1);SetTileTag(14,3,"SOLIDWALL",1);SetTileTag(15,3,"LAND_6", 1);SetTileTag(16,3,"LAND_6", 1);SetTileTag(17,3,"LAND_6", 1);SetTileTag(18,3,"LAND_6", 1);SetTileTag(19,3,"SOLIDWALL",1);SetTileTag(20,3,"SOLIDWALL",1);SetTileTag(21,3,"LAND_6", 1);SetTileTag(22,3,"SOLIDWALL",1);SetTileTag(26,3,"LAND_6", 1);SetTileTag(27,3,"LAND_6", 1);SetTileTag(28,3,"LAND_6", 1);SetTileTag(29,3,"SOLIDWALL",1);SetTileTag(30,3,"LAND_6", 1);SetTileTag(31,3,"SOLIDWALL",1);SetTileTag(32,3,"SOLIDWALL",1);SetTileTag(35,3,"SOLIDWALL",1);SetTileTag(36,3,"LAND_6", 1);SetTileTag(37,3,"SOLIDWALL",1);SetTileTag(38,3,"LAND_6", 1);SetTileTag(39,3,"LAND_6", 1);SetTileTag(40,3,"LAND_6", 1);SetTileTag(41,3,"SOLIDWALL",1);SetTileTag(42,3,"LAND_6", 1);SetTileTag(43,3,"LAND_6", 1);SetTileTag(45,3,"SOLIDWALL",1);SetTileTag(46,3,"LAND_6", 1);SetTileTag(49,3,"SOLIDWALL",1);SetTileTag(50,3,"LAND_6", 1);SetTileTag(51,3,"SOLIDWALL",1);SetTileTag(52,3,"SOLIDWALL",1);SetTileTag(54,3,"LAND_6", 1);SetTileTag(55,3,"SOLIDWALL",1);SetTileTag(57,3,"SOLIDWALL",1);SetTileTag(59,3,"SOLIDWALL",1);SetTileTag(60,3,"SOLIDWALL",1);
		SetTileTag(2,2,"SOLIDWALL",1);SetTileTag(3,2,"LAND_3", 1);SetTileTag(4,2,"LAND_3", 1);SetTileTag(5,2,"LAND_3", 1);SetTileTag(6,2,"LAND_3", 1);SetTileTag(11,2,"LAND_6", 1);SetTileTag(16,2,"SOLIDWALL",1);SetTileTag(17,2,"SOLIDWALL",1);SetTileTag(18,2,"SOLIDWALL",1);SetTileTag(20,2,"SOLIDWALL",1);SetTileTag(21,2,"LAND_6", 1);SetTileTag(22,2,"LAND_6", 1);SetTileTag(23,2,"LAND_6", 1);SetTileTag(24,2,"LAND_6", 1);SetTileTag(25,2,"SOLIDWALL",1);SetTileTag(26,2,"LAND_6", 1);SetTileTag(27,2,"LAND_6", 1);SetTileTag(28,2,"LAND_6", 1);SetTileTag(31,2,"SOLIDWALL",1);SetTileTag(32,2,"LAND_6", 1);SetTileTag(33,2,"LAND_6", 1);SetTileTag(34,2,"LAND_6", 1);SetTileTag(36,2,"LAND_6", 1);SetTileTag(37,2,"SOLIDWALL",1);SetTileTag(38,2,"SOLIDWALL",1);SetTileTag(39,2,"LAND_6", 1);SetTileTag(40,2,"LAND_6", 1);SetTileTag(43,2,"LAND_6", 1);SetTileTag(44,2,"SOLIDWALL",1);SetTileTag(45,2,"SOLIDWALL",1);SetTileTag(46,2,"LAND_6", 1);SetTileTag(47,2,"LAND_6", 1);SetTileTag(48,2,"LAND_6", 1);SetTileTag(49,2,"LAND_6", 1);SetTileTag(50,2,"LAND_6", 1);SetTileTag(51,2,"LAND_6", 1);SetTileTag(52,2,"LAND_6", 1);SetTileTag(55,2,"LAND_6", 1);SetTileTag(56,2,"LAND_6", 1);SetTileTag(58,2,"LAND_6", 1);SetTileTag(59,2,"SOLIDWALL",1);SetTileTag(60,2,"LAND_6", 1);SetTileTag(62,2,"LAND_6", 1);SetTileTag(63,2,"SOLIDWALL",1);
		SetTileTag(3,1,"SOLIDWALL",1);SetTileTag(6,1,"SOLIDWALL",1);SetTileTag(7,1,"WATER_1", 1);SetTileTag(8,1,"WATER_1", 1);SetTileTag(9,1,"WATER_1", 1);SetTileTag(10,1,"LAND_6", 1);SetTileTag(11,1,"SOLIDWALL",1);SetTileTag(12,1,"SOLIDWALL",1);SetTileTag(21,1,"SOLIDWALL",1);SetTileTag(26,1,"SOLIDWALL",1);SetTileTag(27,1,"SOLIDWALL",1);SetTileTag(28,1,"SOLIDWALL",1);SetTileTag(32,1,"SOLIDWALL",1);SetTileTag(36,1,"SOLIDWALL",1);SetTileTag(39,1,"SOLIDWALL",1);SetTileTag(40,1,"SOLIDWALL",1);SetTileTag(46,1,"SOLIDWALL",1);SetTileTag(47,1,"SOLIDWALL",1);SetTileTag(49,1,"SOLIDWALL",1);SetTileTag(50,1,"LAND_6", 1);SetTileTag(51,1,"SOLIDWALL",1);SetTileTag(52,1,"SOLIDWALL",1);SetTileTag(60,1,"SOLIDWALL",1);SetTileTag(61,1,"SOLIDWALL",1);SetTileTag(62,1,"SOLIDWALL",1);
		SetTileTag(7,0,"SOLIDWALL",1);SetTileTag(50,0,"SOLIDWALL",1);SetObjectTag("a_bridge_41_40_06_1004", "LAND_6");
		SetObjectTag("a_bridge_41_39_06_1005", "LAND_6");
		SetObjectTag("a_bridge_41_41_06_1006", "LAND_6");
		SetObjectTag("a_bridge_34_57_06_1007", "LAND_1");
		SetObjectTag("a_bridge_35_57_06_1008", "LAND_1");
		SetObjectTag("a_bridge_20_24_06_1010", "LAND_6");
		SetObjectTag("a_bridge_20_23_06_1011", "LAND_6");
		SetObjectTag("a_bridge_24_12_06_1012", "LAND_6");
		SetObjectTag("a_bridge_24_13_06_1013", "LAND_6");
		SetObjectTag("a_bridge_25_14_06_1014", "LAND_6");



	}

	[MenuItem("MyTools/CreateWeaponAnims")]
	static void CreateWeaponAnims()
	{
			return;


		//CreateAnimationUI("AttackTest", "weapons_0_0000","weapons_1_0001","weapons_0_0002","weapons_1_0003","weapons_0_0004","","","",5,"hud/weapons",0.2f,false);
		CreateAnimationUI("WeaponPutAway", "weapons_blank", "", "", "", "", "", "", "", 1, "hud/weapons", 0.1f, false);



		//CreateAnimationUI("Sword_Slash_White_Right_Charge", "weapons_0_0000", "weapons_0_0001", "weapons_0_0002", "weapons_0_0003", "", "", "", "", 4, "hud/weapons", 0.4f, false);

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
	}

	[MenuItem("MyTools/CreateGraveCuts")]
	static void CreateCutsGraves()
	{
		for (int i =0; i<34; i++)
		{
			string[] Frame={"cs401_n01_00" + i.ToString ("D2")};
			CreateAnimationAsset (Frame[0],"Cuts", Frame,1,5.0f,false,true);
		}
	}

	[MenuItem("MyTools/CreateSmallCutscenes")]
	static void CreateCutsDeath()
	{
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
		GameObject myAI = GameObject.Find ("AI_Base_Animator");
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
		if (NoOfValid !=0)
		{
			keyFrames[NoOfValid] = new ObjectReferenceKeyframe();
			keyFrames[NoOfValid].time = AnimTime * NoOfValid;//0.2f
			Sprite currFrame = Resources.Load <Sprite> (BasePath +"/" + Frames[NoOfValid-1]);
			sprt.sprite=currFrame;
			keyFrames[NoOfValid].value=currFrame; //Hold on the last frame
		}


		AnimationUtility.SetObjectReferenceCurve(animClip, curveBinding, keyFrames);
		AssetDatabase.CreateAsset(animClip,"Assets/Resources/animation/"+  animClip.name + ".anim" );

		if (IncludeEvents)
		{

		//The following code when uncommented will append a Pre+PostAnimPlay Event to the end of the new animation  clip
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
	}

	static GameObject CreateGameObject(string ObjectName, float x, float y, float z)
	{
		GameObject myObj = new GameObject(ObjectName);
		Vector3 pos = new Vector3(x, y, z);
		myObj.transform.position = pos;
		myObj.layer=LayerMask.NameToLayer("UWObjects");
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
	}

	static void CreateObjectInteraction(GameObject myObj,float DimX,float DimY,float DimZ, float CenterY, string WorldString, string InventoryString, string EquipString, int ItemType, int ItemId, int link, int Quality, int Owner, int isMoveable, int isUsable, int isAnimated, int useSprite,int isQuant, int isEnchanted, int flags, int inUseFlag)
	{
		CreateObjectInteraction (myObj,myObj,DimX,DimY,DimZ,CenterY, WorldString,InventoryString,EquipString,ItemType,ItemId,link,Quality,Owner,isMoveable,isUsable, isAnimated, useSprite,isQuant,isEnchanted, flags,inUseFlag);
	}

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
	}

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
		GoblinAI gronk = myObj.AddComponent<GoblinAI>();
		gronk.NPC_ID=NPC_ID;
		myObj.layer=LayerMask.NameToLayer("NPCs");
		GameObject myInstance = Resources.Load("AI_PREFABS/AI_LAND") as GameObject;
		GameObject newObj = (GameObject)GameObject.Instantiate(myInstance);
		newObj.name = myObj.name + "_AI";
		newObj.transform.position=new Vector3(0,0,0);
		newObj.transform.parent=myObj.transform;
		newObj.transform.localPosition=new Vector3(0,0,0);
		AIRig ai = newObj.GetComponent<AIRig>();
		ai.AI.Body=myObj;

		NPC npc = myObj.AddComponent<NPC>();
		if (npc_whoami == 0)
		{
			npc.npc_whoami=256+(int.Parse (NPC_ID) -64);
		}

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


		myInstance = Resources.Load("animation/AI_Base_Animator") as GameObject;
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
		a_door_trap scrpt = myObj.AddComponent<a_door_trap>();
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
		mr.material= (Material)Resources.Load ("Materials/tmap/" + AssetPath);
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
		newcomp.EquipFemaleLowest=FemaleLowest;
		newcomp.EquipFemaleLow=FemaleLow;
		newcomp.EquipFemaleMedium=FemaleMedium;
		newcomp.EquipFemaleBest=FemaleBest;
		newcomp.EquipMaleLowest=MaleLowest;
		newcomp.EquipMaleLow=MaleLow;
		newcomp.EquipMaleMedium=MaleMedium;
		newcomp.EquipMaleBest=MaleBest;
		newcomp.Durability =Durability;
		newcomp.Protection=Protection;
	}

	static void CreateGloves(GameObject myObj, string FemaleLowest, string MaleLowest, string FemaleLow, string MaleLow, string FemaleMedium, string MaleMedium, string FemaleBest,string MaleBest, int Protection, int Durability)
	{
		Gloves newcomp =myObj.AddComponent<Gloves>();
		newcomp.EquipFemaleLowest=FemaleLowest;
		newcomp.EquipFemaleLow=FemaleLow;
		newcomp.EquipFemaleMedium=FemaleMedium;
		newcomp.EquipFemaleBest=FemaleBest;
		newcomp.EquipMaleLowest=MaleLowest;
		newcomp.EquipMaleLow=MaleLow;
		newcomp.EquipMaleMedium=MaleMedium;
		newcomp.EquipMaleBest=MaleBest;
		newcomp.Durability =Durability;
		newcomp.Protection=Protection;

	}

	static void CreateArmour(GameObject myObj, string FemaleLowest, string MaleLowest, string FemaleLow, string MaleLow, string FemaleMedium, string MaleMedium, string FemaleBest,string MaleBest, int Protection, int Durability)
	{
		Armour newcomp =myObj.AddComponent<Armour>();
		newcomp.EquipFemaleLowest=FemaleLowest;
		newcomp.EquipFemaleLow=FemaleLow;
		newcomp.EquipFemaleMedium=FemaleMedium;
		newcomp.EquipFemaleBest=FemaleBest;
		newcomp.EquipMaleLowest=MaleLowest;
		newcomp.EquipMaleLow=MaleLow;
		newcomp.EquipMaleMedium=MaleMedium;
		newcomp.EquipMaleBest=MaleBest;
		newcomp.Durability =Durability;
		newcomp.Protection=Protection;

	}

	static void CreateLeggings(GameObject myObj, string FemaleLowest, string MaleLowest, string FemaleLow, string MaleLow, string FemaleMedium, string MaleMedium, string FemaleBest,string MaleBest, int Protection, int Durability)
	{
		Leggings newcomp =myObj.AddComponent<Leggings>();
		newcomp.EquipFemaleLowest=FemaleLowest;
		newcomp.EquipFemaleLow=FemaleLow;
		newcomp.EquipFemaleMedium=FemaleMedium;
		newcomp.EquipFemaleBest=FemaleBest;
		newcomp.EquipMaleLowest=MaleLowest;
		newcomp.EquipMaleLow=MaleLow;
		newcomp.EquipMaleMedium=MaleMedium;
		newcomp.EquipMaleBest=MaleBest;
		newcomp.Durability =Durability;
		newcomp.Protection=Protection;

	}

	static void CreateBoots(GameObject myObj, string FemaleLowest, string MaleLowest, string FemaleLow, string MaleLow, string FemaleMedium, string MaleMedium, string FemaleBest,string MaleBest, int Protection, int Durability)
	{
		Boots newcomp =myObj.AddComponent<Boots>();
		newcomp.EquipFemaleLowest=FemaleLowest;
		newcomp.EquipFemaleLow=FemaleLow;
		newcomp.EquipFemaleMedium=FemaleMedium;
		newcomp.EquipFemaleBest=FemaleBest;
		newcomp.EquipMaleLowest=MaleLowest;
		newcomp.EquipMaleLow=MaleLow;
		newcomp.EquipMaleMedium=MaleMedium;
		newcomp.EquipMaleBest=MaleBest;
		newcomp.Durability =Durability;
		newcomp.Protection=Protection;

	}


	static Container CreateContainer(GameObject myObj, int Capacity, int NoOfSlots, int ObjectsAccepted)
	{
		Container cn = myObj.AddComponent<Container>();
		//cn.NoOfSlots = NoOfSlots;
		cn.Capacity= Capacity;
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

	static void CreateWeapon(GameObject myObj, int Slash, int Bash, int Stab, int Skill, int Durability)
	{
		Weapon wp = myObj.AddComponent<Weapon>();
		wp.Slash=Slash;
		wp.Bash=Bash;
		wp.Stab=Stab;
		wp.Skill=Skill;
		wp.Durability=Durability;
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
			case 310:
			case 312:
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
			case 209://guard (tybals lair)
				cnv=(Conversation)myObj.AddComponent<Conversation_209>();break;
			case 210://Narutu
				cnv=(Conversation)myObj.AddComponent<Conversation_210>();break;
			case 219://guard (tybals lair)
				cnv=(Conversation)myObj.AddComponent<Conversation_219>();break;
			case 221://Imp
				cnv=(Conversation)myObj.AddComponent<Conversation_221>();break;
			case 222://guard (tybals lair)
				cnv=(Conversation)myObj.AddComponent<Conversation_222>();break;
			case 231://Tybal
				cnv=(Conversation)myObj.AddComponent<Conversation_231>();break;
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

