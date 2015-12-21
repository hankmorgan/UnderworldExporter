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
		myObj = new GameObject("a_fighter_05_02_03_0233");
		pos = new Vector3(6.514286f, 3.600000f, 2.914286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"93","Sprites/OBJECTS_093", 149);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_093", "Sprites/OBJECTS_093", "Sprites/OBJECTS_093", 0, 93, 0, 5, 2, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 149, 5, 2, 0, 0, 47, 0, 0, 8, 2, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_boulder_06_02_03_0450",8.380000f,3.600000f,3.257143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_341",true);
		
		myObj= CreateGameObject("special_tmap_obj_07_02_03_0622",9.000000f,3.600000f,2.420000f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 0, 41, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_150", "" , 150, false);
		SetRotation(myObj,0,180,0);
		
		myObj= CreateGameObject("a_bridge_07_02_03_0640",8.914286f,3.525000f,2.914286f);
		
		myObj= CreateGameObject("a_boulder_07_02_03_0457",9.580000f,3.600000f,2.571429f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_341",true);
		
		myObj = new GameObject("a_skeleton_38_02_03_0197");
		pos = new Vector3(46.114288f, 2.400000f, 2.914286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"74","Sprites/OBJECTS_074", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_074", "Sprites/OBJECTS_074", "Sprites/OBJECTS_074", 0, 74, 0, 38, 2, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 38, 2, 0, 0, 19, 0, 0, 4, 2, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_red_gem_39_02_03_0524",47.828568f,2.400000f,2.571429f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_163",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_163", "Sprites/OBJECTS_163", "Sprites/OBJECTS_163", 18, 163, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj = new GameObject("a_skeleton_39_02_03_0198");
		pos = new Vector3(47.314285f, 2.400000f, 2.914286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"74","Sprites/OBJECTS_074", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_074", "Sprites/OBJECTS_074", "Sprites/OBJECTS_074", 0, 74, 0, 39, 2, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 39, 2, 0, 0, 17, 0, 0, 4, 0, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_sling_stone_39_02_03_0944",47.657143f,2.400000f,3.085714f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_016",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_016", "Sprites/OBJECTS_016", "Sprites/OBJECTS_016", 1, 16, 8, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		CreateWeapon(myObj, -842150451, -842150451, -842150451, -842150451, -842150451);
		
		myObj= CreateGameObject("a_sling_stone_39_02_03_0943",47.314285f,2.400000f,2.914286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_016",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_016", "Sprites/OBJECTS_016", "Sprites/OBJECTS_016", 1, 16, 16, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		CreateWeapon(myObj, -842150451, -842150451, -842150451, -842150451, -842150451);
		
		
		myObj= CreateGameObject("special_tmap_obj_41_02_03_1015",49.220001f,2.400000f,3.000000f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 21, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_139", "" , 139, false);
		SetRotation(myObj,0,270,0);
		
		
		myObj= CreateGameObject("a_skull_44_02_03_0954",53.980000f,2.400000f,2.420000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_195",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_195", "Sprites/OBJECTS_195", "Sprites/OBJECTS_195", 23, 195, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_scroll_59_02_03_0552",71.142853f,3.600000f,2.742857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_314",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_314", "Sprites/OBJECTS_314", "Sprites/OBJECTS_314", 13, 314, 613, 63, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetReadable(myObj);
		SetLink(myObj,613);
		
		myObj= CreateGameObject("a_shrine_60_02_03_0518",72.514290f,3.600000f,2.914286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_343",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_343", "Sprites/OBJECTS_343", "Sprites/OBJECTS_343", 83, 343, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddShrine(myObj);
		
		myObj= CreateGameObject("special_tmap_obj_60_02_03_0875",72.599998f,3.600000f,2.420000f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 47, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_189", "" , 189, false);
		SetRotation(myObj,0,180,0);
		
		
		myObj= CreateGameObject("a_small_boulder_07_03_03_0462",9.085714f,3.600000f,3.620000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_342",true);
		
		
		myObj= CreateGameObject("a_campfire_13_03_03_0476",16.457142f,3.600000f,4.457143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_298",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_298", "Sprites/OBJECTS_298", "Sprites/OBJECTS_298", 16, 298, 1, 40, 0, 0, 0, 1, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("an_anvil_13_03_03_0554",15.942858f,3.600000f,3.942857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_215",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_215", "Sprites/OBJECTS_215", "Sprites/OBJECTS_215", 85, 215, 1, 40, 0, 0, 1, 0, 1, 1, 0, 0, 1);
		AddAnvil(myObj);
		
		myObj= CreateGameObject("a_broken_sword_14_03_03_0477",16.971428f,3.600000f,3.771429f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_201",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_201", "Sprites/OBJECTS_201", "Sprites/OBJECTS_201", 23, 201, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_broken_mace_14_03_03_0496",17.314285f,3.600000f,3.771429f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_202",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_202", "Sprites/OBJECTS_202", "Sprites/OBJECTS_202", 23, 202, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_cauldron_24_03_03_0835",29.657143f,3.600000f,4.457143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_303",true);
		
		myObj = new GameObject("door_044_003");
		pos = new Vector3(53.000000f, 2.400000f, 3.942857f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_322", "Sprites/OBJECTS_322", "Sprites/OBJECTS_322", 4, 322, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_10", 53, 0);
		SetRotation(myObj,-90,-180,0);
		
		myObj= CreateGameObject("a_plant_44_03_03_0948",52.971432f,2.400000f,3.620000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_192",true);
		
		myObj = new GameObject("a_fighter_08_04_03_0235");
		pos = new Vector3(10.114285f, 3.600000f, 5.657143f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"104","Sprites/OBJECTS_104", 12);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_104", "Sprites/OBJECTS_104", "Sprites/OBJECTS_104", 0, 104, 745, 8, 4, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 12, 8, 4, 0, 0, 230, 0, 0, 8, 3, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,270,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		////NPC container with items
		
		AddObjectToContainer("a_standard_99_99_03_0745", ParentContainer, 0);
		AddObjectToContainer("a_helmet_99_99_03_0545", ParentContainer, 1);
		AddObjectToContainer("an_ankh_pendant_99_99_03_0551", ParentContainer, 2);
		////Container contents complete
		
		
		myObj= CreateGameObject("a_pile_of_debris_piles_of_debris_39_04_03_0945",46.971432f,2.400000f,5.657143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_210",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_210", "Sprites/OBJECTS_210", "Sprites/OBJECTS_210", 23, 210, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj = new GameObject("a_fighter_05_05_03_0234");
		pos = new Vector3(6.514286f, 3.600000f, 6.514286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"95","Sprites/OBJECTS_095", 148);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_095", "Sprites/OBJECTS_095", "Sprites/OBJECTS_095", 0, 95, 0, 5, 5, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 148, 5, 5, 0, 0, 26, 0, 0, 8, 2, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("some_writing_09_05_03_0995",11.980000f,4.200000f,6.171429f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_358",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_358", "Sprites/OBJECTS_358", "Sprites/OBJECTS_358", 10, 358, 698, 40, 0, 0, 1, 0, 0, 1, 0, 6, 1);
		SetReadable(myObj);
		SetRotation(myObj,0,90,0);
		SetSprite(myObj, "Sprites/tmobj/tmobj_26");
		SetLink(myObj,698);
		
		myObj = new GameObject("a_fighter_14_05_03_0219");
		pos = new Vector3(17.314285f, 3.600000f, 6.514286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"94","Sprites/OBJECTS_094", 146);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_094", "Sprites/OBJECTS_094", "Sprites/OBJECTS_094", 0, 94, 0, 14, 5, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 146, 14, 5, 0, 0, 38, 0, 0, 8, 2, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_cauldron_24_05_03_0836",29.657143f,3.600000f,6.342857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_303",true);
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_29_05_03_0930",35.828571f,2.400000f,7.028571f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj= CreateGameObject("a_skull_29_05_03_0934",35.314285f,2.400000f,6.514286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_194",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_194", "Sprites/OBJECTS_194", "Sprites/OBJECTS_194", 23, 194, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_30_05_03_0932",36.514286f,2.400000f,7.028571f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_30_05_03_0931",36.171429f,2.400000f,6.514286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj= CreateGameObject("a_bone_30_05_03_0933",36.171429f,2.400000f,6.857143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_196",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_196", "Sprites/OBJECTS_196", "Sprites/OBJECTS_196", 23, 196, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_blood_stain_31_05_03_0924",37.371429f,2.400000f,6.342857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_222",true);
		
		myObj= CreateGameObject("a_piece_of_wood_pieces_of_wood_32_05_03_0927",38.914284f,2.400000f,6.514286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_205",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_205", "Sprites/OBJECTS_205", "Sprites/OBJECTS_205", 23, 205, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_blood_stain_34_05_03_0898",41.657143f,2.700000f,7.028571f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_221",true);
		
		myObj= CreateGameObject("a_boulder_34_05_03_0902",41.980000f,2.700000f,6.342857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_341",true);
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_35_05_03_0895",42.342857f,2.700000f,6.685714f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_35_05_03_0894",42.020000f,2.700000f,6.514286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj= CreateGameObject("a_silver_ring_35_05_03_0914",42.342857f,2.700000f,6.514286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_057",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_057", "Sprites/OBJECTS_057", "Sprites/OBJECTS_057", 74, 57, 529, 40, 0, 1, 1, 0, 1, 1, 1, 8, 1);
		AddRing(myObj);
		
		myObj= CreateGameObject("a_pile_of_bones_piles_of_bones_35_05_03_0896",42.020000f,2.700000f,6.857143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_198",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_198", "Sprites/OBJECTS_198", "Sprites/OBJECTS_198", 23, 198, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_blood_stain_35_05_03_0897",42.514286f,2.700000f,6.685714f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_222",true);
		
		myObj= CreateGameObject("a_skull_35_05_03_0901",42.171432f,2.700000f,6.342857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_195",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_195", "Sprites/OBJECTS_195", "Sprites/OBJECTS_195", 23, 195, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_large_boulder_35_05_03_0903",42.857143f,2.700000f,6.514286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_340",true);
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_35_05_03_0893",42.514286f,2.700000f,6.514286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj= CreateGameObject("a_blood_stain_38_05_03_0946",46.457142f,2.400000f,6.171429f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_222",true);
		
		myObj= CreateGameObject("a_pile_of_bones_piles_of_bones_38_05_03_0947",46.457142f,2.400000f,6.171429f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_198",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_198", "Sprites/OBJECTS_198", "Sprites/OBJECTS_198", 23, 198, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj = new GameObject("door_061_005");
		pos = new Vector3(74.199997f, 3.600000f, 6.020000f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_325", "Sprites/OBJECTS_325", "Sprites/OBJECTS_325", 4, 325, 525, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_06", 0, 1);
		SetRotation(myObj,-90,0,0);
		myObj= CreateGameObject("a_lock_99_99_03_0525",74.199997f,3.600000f,6.020000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_271",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_271", "Sprites/OBJECTS_271", "Sprites/OBJECTS_271", 21, 271, 512, 40, 0, 1, 1, 0, 1, 1, 0, 3, 0);
		AddObj_base(myObj);
		
		
		myObj= CreateGameObject("a_small_boulder_07_06_03_0969",8.914286f,3.600000f,8.380000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_342",true);
		
		
		myObj= CreateGameObject("some_writing_17_06_03_0997",21.580000f,3.900000f,8.057143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_358",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_358", "Sprites/OBJECTS_358", "Sprites/OBJECTS_358", 10, 358, 699, 40, 0, 0, 1, 0, 0, 1, 0, 0, 1);
		SetReadable(myObj);
		SetRotation(myObj,0,90,0);
		SetSprite(myObj, "Sprites/tmobj/tmobj_20");
		SetLink(myObj,699);
		
		myObj= CreateGameObject("a_pull_chain_21_06_03_0834",25.219999f,4.200000f,7.220000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_374",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_374", "Sprites/OBJECTS_374", "Sprites/OBJECTS_374", 8, 374, 0, 40, 0, 0, 1, 0, 0, 0, 0, 0, 1);
		CreateUWActivators(myObj,"ButtonHandler","",40,0,0,7,374);
		SetRotation(myObj,0,270,0);
		SetButtonProperties(myObj, 0, "Sprites/tmflat/tmflat_0006", "Sprites/tmflat/tmflat_0014");
		
		myObj= CreateGameObject("a_broken_mace_30_06_03_0929",36.342857f,2.400000f,7.371429f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_202",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_202", "Sprites/OBJECTS_202", "Sprites/OBJECTS_202", 23, 202, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_blood_stain_34_06_03_0899",41.980000f,2.700000f,7.371429f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_221",true);
		
		myObj= CreateGameObject("a_blood_stain_35_06_03_0900",42.685715f,2.700000f,7.542857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_221",true);
		
		myObj= CreateGameObject("a_pile_of_debris_piles_of_debris_43_06_03_0941",51.771431f,2.400000f,7.885714f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_209", "Sprites/OBJECTS_209", "Sprites/OBJECTS_209", 23, 209, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj = new GameObject("door_047_006");
		pos = new Vector3(57.580002f, 2.400000f, 8.200000f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_322", "Sprites/OBJECTS_322", "Sprites/OBJECTS_322", 4, 322, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_10", 53, 0);
		SetRotation(myObj,-90,-90,0);
		
		myObj= CreateGameObject("a_dead_rotworm_51_06_03_0942",61.885712f,2.400000f,7.371429f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_217",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_217", "Sprites/OBJECTS_217", "Sprites/OBJECTS_217", 16, 217, 0, 1, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj = new GameObject("door_053_006");
		pos = new Vector3(64.285713f, 2.400000f, 8.200000f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_322", "Sprites/OBJECTS_322", "Sprites/OBJECTS_322", 4, 322, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_10", 53, 0);
		SetRotation(myObj,-90,-90,0);
		
		myObj= CreateGameObject("special_tmap_obj_53_06_03_0497",64.285713f,3.600000f,7.885714f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 44, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_059", "" , 59, false);
		SetRotation(myObj,0,90,0);
		
		
		
		myObj= CreateGameObject("a_bench_benches_05_07_03_0822",6.685714f,3.600000f,8.914286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_336",true);
		
		myObj= CreateGameObject("a_boulder_06_07_03_0806",8.380000f,3.600000f,8.742857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_341",true);
		
		myObj= CreateGameObject("special_tmap_obj_07_07_03_0846",9.000000f,3.600000f,9.580000f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 0, 41, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_150", "" , 150, false);
		SetRotation(myObj,0,0,0);
		
		myObj= CreateGameObject("a_bridge_07_07_03_0851",8.914286f,3.525000f,8.914286f);
		
		myObj= CreateGameObject("a_boulder_07_07_03_0968",9.580000f,3.600000f,9.085714f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_341",true);
		
		myObj= CreateGameObject("a_small_boulder_07_07_03_0967",9.580000f,3.600000f,8.571429f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_342",true);
		
		myObj = new GameObject("a_fighter_13_07_03_0192");
		pos = new Vector3(16.114286f, 3.600000f, 8.914286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"98","Sprites/OBJECTS_098", 147);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_098", "Sprites/OBJECTS_098", "Sprites/OBJECTS_098", 0, 98, 0, 13, 7, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 147, 13, 7, 0, 0, 56, 0, 0, 8, 2, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("special_tmap_obj_29_07_03_0502",34.820000f,3.000000f,9.000000f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 44, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_059", "" , 59, false);
		SetRotation(myObj,0,270,0);
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_30_07_03_0908",36.514286f,2.400000f,8.914286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj= CreateGameObject("a_broken_shield_30_07_03_0928",36.020000f,2.400000f,8.914286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_203",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_203", "Sprites/OBJECTS_203", "Sprites/OBJECTS_203", 23, 203, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_33_07_03_0906",40.114285f,2.400000f,8.914286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj= CreateGameObject("a_pile_of_debris_piles_of_debris_34_07_03_0926",41.314285f,2.400000f,8.914286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_214",true);
		
		myObj= CreateGameObject("a_broken_mace_45_07_03_0940",54.857143f,2.400000f,9.257143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_202",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_202", "Sprites/OBJECTS_202", "Sprites/OBJECTS_202", 23, 202, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_29_08_03_0917",35.314285f,2.400000f,10.114285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_29_08_03_0916",35.142857f,2.400000f,10.628572f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj= CreateGameObject("a_broken_sword_29_08_03_0918",34.971428f,2.400000f,10.285714f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_201",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_201", "Sprites/OBJECTS_201", "Sprites/OBJECTS_201", 23, 201, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_32_08_03_0905",38.914284f,2.400000f,10.114285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_33_08_03_0907",40.114285f,2.400000f,10.114285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj= CreateGameObject("a_skull_35_08_03_0889",43.028568f,2.400000f,10.457142f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_195",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_195", "Sprites/OBJECTS_195", "Sprites/OBJECTS_195", 23, 195, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_skull_35_08_03_0890",43.028568f,2.400000f,9.771429f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_195",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_195", "Sprites/OBJECTS_195", "Sprites/OBJECTS_195", 23, 195, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_skull_35_08_03_0891",42.857143f,2.400000f,10.285714f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_195",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_195", "Sprites/OBJECTS_195", "Sprites/OBJECTS_195", 23, 195, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_skull_35_08_03_0892",43.028568f,2.400000f,10.114285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_195",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_195", "Sprites/OBJECTS_195", "Sprites/OBJECTS_195", 23, 195, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_skull_35_08_03_0888",43.028568f,2.512500f,10.285714f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_195",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_195", "Sprites/OBJECTS_195", "Sprites/OBJECTS_195", 23, 195, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("some_writing_03_09_03_0534",3.620000f,4.200000f,11.828571f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_358",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_358", "Sprites/OBJECTS_358", "Sprites/OBJECTS_358", 10, 358, 701, 40, 0, 0, 1, 0, 0, 1, 0, 0, 1);
		SetReadable(myObj);
		SetRotation(myObj,0,270,0);
		SetSprite(myObj, "Sprites/tmobj/tmobj_20");
		SetLink(myObj,701);
		
		myObj = new GameObject("door_005_009");
		pos = new Vector3(6.514286f, 3.600000f, 11.000000f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_324", "Sprites/OBJECTS_324", "Sprites/OBJECTS_324", 4, 324, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_08", 53, 0);
		SetRotation(myObj,-90,90,0);
		
		myObj= CreateGameObject("some_writing_08_09_03_1003",9.771429f,4.200000f,10.820000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_358",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_358", "Sprites/OBJECTS_358", "Sprites/OBJECTS_358", 10, 358, 692, 40, 0, 0, 1, 0, 0, 1, 0, 0, 1);
		SetReadable(myObj);
		SetRotation(myObj,0,180,0);
		SetSprite(myObj, "Sprites/tmobj/tmobj_20");
		SetLink(myObj,692);
		
		myObj = new GameObject("door_012_009");
		pos = new Vector3(15.257142f, 3.600000f, 11.800000f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_320", "Sprites/OBJECTS_320", "Sprites/OBJECTS_320", 4, 320, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_01", 53, 0);
		SetRotation(myObj,-90,-90,0);
		
		myObj= CreateGameObject("a_barrel_16_09_03_0577",20.057142f,3.600000f,11.828571f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_347",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_347", "Sprites/OBJECTS_347", "Sprites/OBJECTS_347", 19, 347, 578, 40, 13, 1, 1, 0, 1, 0, 0, 0, 1);
		////Container contents
		ParentContainer = CreateContainer(myObj, -842150451, -842150451, -842150451);
		AddObjectToContainer("a_red_potion_99_99_03_0578", ParentContainer, 0);
		AddObjectToContainer("a_torch_torches_99_99_03_0576", ParentContainer, 1);
		AddObjectToContainer("some_leeches_bunches_of_leeches_99_99_03_0575", ParentContainer, 2);
		AddObjectToContainer("an_oil_flask_99_99_03_0573", ParentContainer, 3);
		////Container contents complete
		
		
		myObj= CreateGameObject("some_writing_17_09_03_0825",21.580000f,4.200000f,10.971428f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_358",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_358", "Sprites/OBJECTS_358", "Sprites/OBJECTS_358", 10, 358, 700, 40, 0, 0, 1, 0, 0, 1, 0, 0, 1);
		SetReadable(myObj);
		SetRotation(myObj,0,90,0);
		SetSprite(myObj, "Sprites/tmobj/tmobj_20");
		SetLink(myObj,700);
		
		myObj= CreateGameObject("a_longsword_17_09_03_0833",20.571428f,3.600000f,11.657143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_005",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_005", "Sprites/OBJECTS_005", "Sprites/OBJECTS_005", 1, 5, 0, 40, 13, 1, 1, 0, 1, 0, 0, 0, 1);
		CreateWeapon(myObj, 10, 4, 8, 3, 28);
		
		myObj= CreateGameObject("a_pack_22_09_03_0848",26.742857f,2.400000f,11.657143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_130",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_130", "Sprites/OBJECTS_130", "Sprites/OBJECTS_131", 19, 130, 847, 40, 27, 1, 1, 0, 1, 0, 0, 0, 1);
		////Container contents
		ParentContainer = CreateContainer(myObj, 250, 255, 255);
		AddObjectToContainer("a_torch_torches_99_99_03_0847", ParentContainer, 0);
		AddObjectToContainer("a_flask_of_port_flasks_of_port_99_99_03_0845", ParentContainer, 1);
		////Container contents complete
		
		
		myObj= CreateGameObject("a_book_22_09_03_0849",26.571428f,2.400000f,10.971428f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_307",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_307", "Sprites/OBJECTS_307", "Sprites/OBJECTS_307", 11, 307, 611, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetReadable(myObj);
		SetLink(myObj,611);
		
		myObj= CreateGameObject("chain_boots_pairs_of_chain_boots_23_09_03_0841",28.114285f,2.700000f,11.142858f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_042",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_042", "Sprites/OBJECTS_042", "Sprites/armour/armor_f_0010", 75, 42, 0, 27, 27, 1, 1, 0, 1, 0, 0, 0, 1);
		CreateBoots(myObj, "Sprites/armour/armor_f_0010", "Sprites/armour/armor_m_0010", "Sprites/armour/armor_f_0025", "Sprites/armour/armor_m_0025", "Sprites/armour/armor_f_0040", "Sprites/armour/armor_m_0040", "Sprites/armour/armor_f_0055", "Sprites/armour/armor_m_0055", 3, 10);
		
		myObj= CreateGameObject("leather_gloves_pairs_of_leather_gloves_23_09_03_0839",27.771429f,2.700000f,11.142858f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_038",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_038", "Sprites/OBJECTS_038", "Sprites/armour/armor_f_0006", 76, 38, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		CreateGloves(myObj, "Sprites/armour/armor_f_0006", "Sprites/armour/armor_m_0006", "Sprites/armour/armor_f_0021", "Sprites/armour/armor_m_0021", "Sprites/armour/armor_f_0036", "Sprites/armour/armor_m_0036", "Sprites/armour/armor_f_0051", "Sprites/armour/armor_m_0051", 1, 2);
		
		myObj= CreateGameObject("a_pile_of_debris_piles_of_debris_52_09_03_0637",63.085712f,2.400000f,11.657143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_209", "Sprites/OBJECTS_209", "Sprites/OBJECTS_209", 23, 209, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj = new GameObject("a_troll_52_09_03_0252");
		pos = new Vector3(62.914288f, 2.400000f, 11.314286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"96","Sprites/OBJECTS_096", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_096", "Sprites/OBJECTS_096", "Sprites/OBJECTS_096", 0, 96, 0, 52, 9, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 52, 9, 0, 0, 29, 0, 0, 8, 2, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_blood_stain_53_09_03_0628",64.285713f,2.400000f,11.828571f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_222",true);
		
		myObj= CreateGameObject("a_pile_of_debris_piles_of_debris_53_09_03_0639",63.942856f,2.400000f,11.142858f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_210",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_210", "Sprites/OBJECTS_210", "Sprites/OBJECTS_210", 23, 210, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj = new GameObject("a_troll_54_09_03_0196");
		pos = new Vector3(65.314285f, 2.400000f, 11.314286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"96","Sprites/OBJECTS_096", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_096", "Sprites/OBJECTS_096", "Sprites/OBJECTS_096", 0, 96, 0, 54, 9, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 54, 9, 0, 0, 42, 0, 0, 8, 2, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_pile_of_debris_piles_of_debris_54_09_03_0629",64.971428f,2.400000f,11.828571f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_210",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_210", "Sprites/OBJECTS_210", "Sprites/OBJECTS_210", 23, 210, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj = new GameObject("a_troll_58_09_03_0191");
		pos = new Vector3(70.114288f, 3.000000f, 11.314286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"96","Sprites/OBJECTS_096", 144);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_096", "Sprites/OBJECTS_096", "Sprites/OBJECTS_096", 0, 96, 626, 58, 9, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 144, 58, 9, 0, 0, 51, 0, 0, 7, 1, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		////NPC container with items
		
		AddObjectToContainer("a_ruby_rubies_99_99_03_0626", ParentContainer, 0);
		AddObjectToContainer("a_red_gem_99_99_03_0623", ParentContainer, 1);
		////Container contents complete
		
		
		myObj = new GameObject("door_003_010");
		pos = new Vector3(4.600000f, 3.600000f, 12.020000f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_325", "Sprites/OBJECTS_325", "Sprites/OBJECTS_325", 4, 325, 535, 63, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_06", 0, 1);
		SetRotation(myObj,-90,0,0);
		myObj= CreateGameObject("a_lock_99_99_03_0535",4.600000f,3.600000f,12.020000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_271",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_271", "Sprites/OBJECTS_271", "Sprites/OBJECTS_271", 21, 271, 512, 40, 0, 1, 1, 0, 1, 1, 0, 3, 0);
		AddObj_base(myObj);
		
		myObj = new GameObject("an_outcast_22_10_03_0255");
		pos = new Vector3(27.257143f, 2.700000f, 12.020000f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"90","Sprites/OBJECTS_090", 136);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_090", "Sprites/OBJECTS_090", "Sprites/OBJECTS_090", 0, 90, 726, 22, 10, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 136, 22, 10, 0, 0, 35, 0, 0, 8, 3, 0, 1, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		////NPC container with items
		
		AddObjectToContainer("a_fishing_pole_99_99_03_0726", ParentContainer, 0);
		////Container contents complete
		
		
		myObj= CreateGameObject("a_campfire_23_10_03_0852",28.114285f,2.700000f,12.514286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_298",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_298", "Sprites/OBJECTS_298", "Sprites/OBJECTS_298", 16, 298, 0, 40, 0, 0, 0, 1, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_plant_29_10_03_0919",35.657143f,2.700000f,12.342857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_192",true);
		
		myObj= CreateGameObject("a_pile_of_debris_piles_of_debris_29_10_03_0923",35.314285f,2.700000f,12.514286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_209", "Sprites/OBJECTS_209", "Sprites/OBJECTS_209", 23, 209, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_blood_stain_30_10_03_0920",36.514286f,2.700000f,12.514286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_223",true);
		
		myObj= CreateGameObject("a_longsword_30_10_03_0915",36.514286f,2.700000f,12.514286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_005",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_005", "Sprites/OBJECTS_005", "Sprites/OBJECTS_005", 1, 5, 0, 22, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		CreateWeapon(myObj, 10, 4, 8, 3, 28);
		
		myObj= CreateGameObject("a_skull_30_10_03_0921",36.857143f,2.700000f,12.685714f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_195",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_195", "Sprites/OBJECTS_195", "Sprites/OBJECTS_195", 23, 195, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_pile_of_bones_piles_of_bones_30_10_03_0922",36.514286f,2.700000f,12.514286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_198",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_198", "Sprites/OBJECTS_198", "Sprites/OBJECTS_198", 23, 198, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_green_potion_33_10_03_0590",39.942856f,2.400000f,13.028572f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_188",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_188", "Sprites/OBJECTS_188", "Sprites/OBJECTS_188", 14, 188, 564, 40, 0, 1, 1, 0, 1, 1, 1, 12, 1);
		AddPotion(myObj);
		
		myObj= CreateGameObject("a_Jux_stone_33_10_03_0904",40.779999f,2.400000f,13.028572f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_224",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_224", "Sprites/OBJECTS_241", "Sprites/OBJECTS_241", 6, 241, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		SetObjectAsRuneStone(myObj);
		
		myObj= CreateGameObject("an_An_stone_33_10_03_0654",40.114285f,2.400000f,12.514286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_224",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_224", "Sprites/OBJECTS_232", "Sprites/OBJECTS_232", 6, 232, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		SetObjectAsRuneStone(myObj);
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_33_10_03_0910",40.779999f,2.400000f,12.685714f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj= CreateGameObject("a_bone_33_10_03_0911",40.285717f,2.400000f,13.028572f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_196",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_196", "Sprites/OBJECTS_196", "Sprites/OBJECTS_196", 23, 196, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_broken_wand_33_10_03_0913",40.628571f,2.400000f,12.857142f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_157",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_157", "Sprites/OBJECTS_157", "Sprites/OBJECTS_157", 12, 157, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddWand(myObj, 373, 42);
		
		myObj= CreateGameObject("a_blood_stain_34_10_03_0912",40.971432f,2.400000f,13.028572f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_223",true);
		
		myObj= CreateGameObject("a_plant_34_10_03_0909",41.142857f,2.400000f,13.028572f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_206",true);
		
		myObj= CreateGameObject("a_pile_of_wood_chips_piles_of_wood_chips_35_10_03_0925",42.685715f,2.400000f,13.028572f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_219",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_219", "Sprites/OBJECTS_219", "Sprites/OBJECTS_219", 69, 219, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_45_10_03_0936",54.685715f,2.400000f,12.857142f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj= CreateGameObject("a_pouch_pouches_45_10_03_0939",54.857143f,2.400000f,13.028572f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_134",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_134", "Sprites/OBJECTS_134", "Sprites/OBJECTS_135", 19, 134, 938, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		////Container contents
		ParentContainer = CreateContainer(myObj, 20, 255, 255);
		AddObjectToContainer("a_candle_99_99_03_0938", ParentContainer, 0);
		AddObjectToContainer("a_piece_of_cheese_pieces_of_cheese_99_99_03_0937", ParentContainer, 1);
		////Container contents complete
		
		
		myObj= CreateGameObject("a_pile_of_debris_piles_of_debris_52_10_03_0638",63.428570f,2.400000f,12.171429f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_210",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_210", "Sprites/OBJECTS_210", "Sprites/OBJECTS_210", 23, 210, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_pull_chain_02_11_03_0830",2.571429f,4.200000f,13.220000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_375",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_375", "Sprites/OBJECTS_375", "Sprites/OBJECTS_375", 8, 375, 574, 40, 0, 0, 1, 0, 0, 0, 0, 0, 1);
		CreateUWActivators(myObj,"ButtonHandler","a_use_trigger_99_99_03_0574",40,0,0,7,375);
		SetRotation(myObj,0,180,0);
		SetButtonProperties(myObj, 0, "Sprites/tmflat/tmflat_0007", "Sprites/tmflat/tmflat_0015");
		
		myObj= CreateGameObject("plate_leggings_pairs_of_plate_leggings_02_11_03_0547",2.914286f,3.600000f,13.714286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_037",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_037", "Sprites/OBJECTS_037", "Sprites/armour/armor_f_0005", 77, 37, 0, 54, 13, 1, 1, 0, 1, 0, 0, 0, 1);
		CreateLeggings(myObj, "Sprites/armour/armor_f_0005", "Sprites/armour/armor_m_0005", "Sprites/armour/armor_f_0020", "Sprites/armour/armor_m_0020", "Sprites/armour/armor_f_0035", "Sprites/armour/armor_m_0035", "Sprites/armour/armor_f_0050", "Sprites/armour/armor_m_0050", 6, 20);
		
		myObj= CreateGameObject("plate_gauntlets_pairs_of_plate_gauntlets_04_11_03_0540",5.314286f,3.600000f,13.714286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_040",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_040", "Sprites/OBJECTS_040", "Sprites/armour/armor_f_0008", 76, 40, 0, 63, 13, 1, 1, 0, 1, 0, 0, 0, 1);
		CreateGloves(myObj, "Sprites/armour/armor_f_0008", "Sprites/armour/armor_m_0008", "Sprites/armour/armor_f_0023", "Sprites/armour/armor_m_0023", "Sprites/armour/armor_f_0038", "Sprites/armour/armor_m_0038", "Sprites/armour/armor_f_0053", "Sprites/armour/armor_m_0053", 5, 15);
		
		myObj= CreateGameObject("some_writing_38_11_03_1014",45.942856f,3.000000f,13.220000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_358",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_358", "Sprites/OBJECTS_358", "Sprites/OBJECTS_358", 10, 358, 685, 40, 0, 0, 1, 0, 0, 1, 1, 9, 1);
		SetReadable(myObj);
		SetRotation(myObj,0,180,0);
		SetSprite(myObj, "Sprites/tmobj/tmobj_21");
		SetLink(myObj,685);
		
		myObj= CreateGameObject("a_breastplate_02_12_03_0829",2.914286f,3.600000f,15.085714f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_034",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_034", "Sprites/OBJECTS_034", "Sprites/armour/armor_f_0002", 2, 34, 0, 56, 13, 1, 1, 0, 1, 0, 0, 0, 1);
		CreateArmour(myObj, "Sprites/armour/armor_f_0002", "Sprites/armour/armor_m_0002", "Sprites/armour/armor_f_0017", "Sprites/armour/armor_m_0017", "Sprites/armour/armor_f_0032", "Sprites/armour/armor_m_0032", "Sprites/armour/armor_f_0047", "Sprites/armour/armor_m_0047", 6, 34);
		
		myObj= CreateGameObject("a_tower_shield_03_12_03_0539",4.285714f,3.600000f,15.428572f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_059",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_059", "Sprites/OBJECTS_059", "Sprites/OBJECTS_059", 78, 59, 0, 40, 13, 1, 1, 0, 1, 0, 0, 0, 1);
		AddShield(myObj);
		
		myObj= CreateGameObject("a_broadsword_04_12_03_0538",4.971428f,3.600000f,15.428572f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_006",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_006", "Sprites/OBJECTS_006", "Sprites/OBJECTS_006", 1, 6, 0, 60, 13, 1, 1, 0, 1, 0, 0, 0, 1);
		CreateWeapon(myObj, 13, 6, 10, 3, 34);
		
		myObj= CreateGameObject("plate_boots_pairs_of_plate_boots_04_12_03_0546",5.657143f,3.600000f,15.257142f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_043",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_043", "Sprites/OBJECTS_043", "Sprites/armour/armor_f_0011", 75, 43, 0, 63, 13, 1, 1, 0, 1, 0, 0, 0, 1);
		CreateBoots(myObj, "Sprites/armour/armor_f_0011", "Sprites/armour/armor_m_0011", "Sprites/armour/armor_f_0026", "Sprites/armour/armor_m_0026", "Sprites/armour/armor_f_0041", "Sprites/armour/armor_m_0041", "Sprites/armour/armor_f_0056", "Sprites/armour/armor_m_0056", 5, 17);
		
		myObj= CreateGameObject("special_tmap_obj_49_12_03_0500",59.980000f,3.000000f,15.000000f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 44, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_059", "" , 59, false);
		SetRotation(myObj,0,90,0);
		
		myObj= CreateGameObject("a_buckler_23_13_03_0838",28.457144f,2.400000f,15.942858f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_062",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_062", "Sprites/OBJECTS_062", "Sprites/OBJECTS_062", 78, 62, 0, 7, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddShield(myObj);
		
		myObj= CreateGameObject("a_piece_of_wood_pieces_of_wood_35_13_03_0872",42.514286f,2.400000f,16.114286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_204",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_204", "Sprites/OBJECTS_204", "Sprites/OBJECTS_204", 23, 204, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_sack_43_13_03_0879",51.771431f,2.400000f,16.628572f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_128",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_128", "Sprites/OBJECTS_128", "Sprites/OBJECTS_129", 19, 128, 877, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		////Container contents
		ParentContainer = CreateContainer(myObj, 125, 255, 255);
		AddObjectToContainer("a_lockpick_99_99_03_0877", ParentContainer, 0);
		AddObjectToContainer("a_scroll_99_99_03_0876", ParentContainer, 1);
		////Container contents complete
		
		
		myObj = new GameObject("door_050_013");
		pos = new Vector3(60.514286f, 2.400000f, 16.600000f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_322", "Sprites/OBJECTS_322", "Sprites/OBJECTS_322", 4, 322, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_10", 53, 0);
		SetRotation(myObj,-90,-90,0);
		
		myObj= CreateGameObject("a_pile_of_debris_piles_of_debris_59_13_03_0633",71.314285f,2.400000f,16.114286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_209", "Sprites/OBJECTS_209", "Sprites/OBJECTS_209", 23, 209, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_pile_of_debris_piles_of_debris_59_13_03_0632",71.485710f,2.400000f,16.628572f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_209", "Sprites/OBJECTS_209", "Sprites/OBJECTS_209", 23, 209, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_pile_of_debris_piles_of_debris_59_13_03_0631",70.820000f,2.400000f,16.114286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_209", "Sprites/OBJECTS_209", "Sprites/OBJECTS_209", 23, 209, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_box_boxes_04_14_03_0801",5.828571f,3.600000f,17.142859f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_132",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_132", "Sprites/OBJECTS_132", "Sprites/OBJECTS_133", 19, 132, 797, 40, 13, 1, 1, 0, 1, 0, 0, 0, 1);
		////Container contents
		ParentContainer = CreateContainer(myObj, 125, 255, 255);
		AddObjectToContainer("a_rock_hammer_99_99_03_0797", ParentContainer, 0);
		AddObjectToContainer("some_leeches_bunches_of_leeches_99_99_03_0796", ParentContainer, 1);
		////Container contents complete
		
		
		myObj= CreateGameObject("a_campfire_04_14_03_0814",5.314286f,3.600000f,17.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_298",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_298", "Sprites/OBJECTS_298", "Sprites/OBJECTS_298", 16, 298, 0, 40, 0, 0, 0, 1, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_bedroll_05_14_03_0821",6.514286f,3.600000f,17.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_289",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_289", "Sprites/OBJECTS_289", "Sprites/OBJECTS_289", 16, 289, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_bedroll_12_14_03_0820",15.257142f,3.600000f,17.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_289",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_289", "Sprites/OBJECTS_289", "Sprites/OBJECTS_289", 16, 289, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_box_boxes_13_14_03_0813",15.771428f,3.600000f,17.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_132",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_132", "Sprites/OBJECTS_132", "Sprites/OBJECTS_133", 19, 132, 812, 40, 13, 1, 1, 0, 1, 0, 0, 0, 1);
		////Container contents
		ParentContainer = CreateContainer(myObj, 125, 255, 255);
		AddObjectToContainer("a_mushroom_99_99_03_0812", ParentContainer, 0);
		////Container contents complete
		
		
		myObj= CreateGameObject("a_campfire_13_14_03_0815",16.457142f,3.600000f,17.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_298",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_298", "Sprites/OBJECTS_298", "Sprites/OBJECTS_298", 16, 298, 0, 40, 0, 0, 0, 1, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_broken_mace_26_14_03_0871",32.057144f,2.400000f,16.971428f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_202",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_202", "Sprites/OBJECTS_202", "Sprites/OBJECTS_202", 23, 202, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_skull_32_14_03_0776",38.914284f,3.000000f,17.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_194",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_194", "Sprites/OBJECTS_194", "Sprites/OBJECTS_194", 23, 194, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("special_tmap_obj_49_14_03_0501",59.980000f,3.000000f,17.400000f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 44, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_059", "" , 59, false);
		SetRotation(myObj,0,90,0);
		
		myObj = new GameObject("a_troll_53_14_03_0251");
		pos = new Vector3(64.114288f, 2.400000f, 17.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"96","Sprites/OBJECTS_096", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_096", "Sprites/OBJECTS_096", "Sprites/OBJECTS_096", 0, 96, 0, 53, 14, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 53, 14, 0, 0, 48, 0, 0, 8, 1, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("some_writing_09_15_03_1002",11.980000f,4.200000f,19.180000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_358",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_358", "Sprites/OBJECTS_358", "Sprites/OBJECTS_358", 10, 358, 694, 40, 0, 0, 1, 0, 0, 1, 1, 8, 1);
		SetReadable(myObj);
		SetRotation(myObj,0,90,0);
		SetSprite(myObj, "Sprites/tmobj/tmobj_20");
		SetLink(myObj,694);
		
		
		myObj= CreateGameObject("a_lantern_45_15_03_0880",54.171432f,2.400000f,19.028572f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_144",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_144", "Sprites/OBJECTS_144", "Sprites/OBJECTS_144", 88, 144, 0, 40, 0, 1, 1, 1, 1, 0, 0, 0, 1);
		CreateLantern(myObj, 4, 10, 148, 144);
		
		myObj= CreateGameObject("a_pile_of_debris_piles_of_debris_52_15_03_0634",62.914288f,2.400000f,18.171429f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_209", "Sprites/OBJECTS_209", "Sprites/OBJECTS_209", 23, 209, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_pile_of_debris_piles_of_debris_52_15_03_0636",63.257145f,2.400000f,18.685715f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_209", "Sprites/OBJECTS_209", "Sprites/OBJECTS_209", 23, 209, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj = new GameObject("a_troll_58_15_03_0253");
		pos = new Vector3(70.114288f, 2.400000f, 18.514286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"96","Sprites/OBJECTS_096", 18);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_096", "Sprites/OBJECTS_096", "Sprites/OBJECTS_096", 0, 96, 0, 58, 15, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 18, 58, 15, 0, 0, 43, 0, 0, 8, 1, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,225,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_loaf_of_bread_loaves_of_bread_59_15_03_0881",70.971428f,2.700000f,19.028572f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_177",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_177", "Sprites/OBJECTS_177", "Sprites/OBJECTS_177", 24, 177, 10, 40, 15, 1, 1, 0, 1, 1, 0, 0, 1);
		SetFood(myObj);
		
		myObj= CreateGameObject("a_piece_of_meat_pieces_of_meat_59_15_03_0882",71.828568f,2.700000f,18.685715f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_176",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_176", "Sprites/OBJECTS_176", "Sprites/OBJECTS_176", 24, 176, 6, 40, 15, 1, 1, 0, 1, 1, 0, 0, 1);
		SetFood(myObj);
		
		myObj= CreateGameObject("a_campfire_59_15_03_0884",71.142853f,2.700000f,18.342857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_298",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_298", "Sprites/OBJECTS_298", "Sprites/OBJECTS_298", 16, 298, 0, 40, 0, 0, 0, 1, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj = new GameObject("door_007_016");
		pos = new Vector3(8.914286f, 3.600000f, 19.400000f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_320", "Sprites/OBJECTS_320", "Sprites/OBJECTS_320", 4, 320, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_01", 53, 0);
		SetRotation(myObj,-90,90,0);
		
		myObj = new GameObject("door_010_016");
		pos = new Vector3(12.857142f, 3.600000f, 20.200001f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_320", "Sprites/OBJECTS_320", "Sprites/OBJECTS_320", 4, 320, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_01", 53, 0);
		SetRotation(myObj,-90,-90,0);
		
		myObj = new GameObject("a_fighter_13_16_03_0229");
		pos = new Vector3(16.114286f, 3.600000f, 19.714287f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"98","Sprites/OBJECTS_098", 138);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_098", "Sprites/OBJECTS_098", "Sprites/OBJECTS_098", 0, 98, 0, 13, 16, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 138, 13, 16, 0, 0, 46, 0, 0, 8, 2, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_pile_of_bones_piles_of_bones_35_16_03_0874",42.342857f,2.400000f,19.885714f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_198",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_198", "Sprites/OBJECTS_198", "Sprites/OBJECTS_198", 23, 198, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_plant_37_16_03_0873",45.257145f,2.700000f,19.885714f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_207",true);
		
		myObj = new GameObject("door_054_016");
		pos = new Vector3(65.800003f, 2.400000f, 19.714287f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_322", "Sprites/OBJECTS_322", "Sprites/OBJECTS_322", 4, 322, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_10", 53, 0);
		SetRotation(myObj,-90,0,0);
		
		myObj= CreateGameObject("a_bench_benches_02_17_03_0788",3.257143f,3.600000f,21.257143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_336",true);
		
		myObj= CreateGameObject("some_writing_08_17_03_1001",9.620000f,4.200000f,20.420000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_358",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_358", "Sprites/OBJECTS_358", "Sprites/OBJECTS_358", 10, 358, 693, 40, 0, 0, 1, 0, 0, 1, 0, 0, 1);
		SetReadable(myObj);
		SetRotation(myObj,0,270,0);
		SetSprite(myObj, "Sprites/tmobj/tmobj_20");
		SetLink(myObj,693);
		
		myObj= CreateGameObject("special_tmap_obj_54_17_03_0499",65.980003f,3.000000f,21.000000f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 44, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_059", "" , 59, false);
		SetRotation(myObj,0,90,0);
		
		myObj= CreateGameObject("special_tmap_obj_54_17_03_0498",64.820000f,3.000000f,21.000000f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 44, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_059", "" , 59, false);
		SetRotation(myObj,0,270,0);
		
		myObj= CreateGameObject("some_writing_05_18_03_0996",7.180000f,4.200000f,21.942856f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_358",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_358", "Sprites/OBJECTS_358", "Sprites/OBJECTS_358", 10, 358, 697, 40, 0, 0, 1, 0, 0, 1, 0, 0, 1);
		SetReadable(myObj);
		SetRotation(myObj,0,90,0);
		SetSprite(myObj, "Sprites/tmobj/tmobj_20");
		SetLink(myObj,697);
		
		myObj= CreateGameObject("a_bench_benches_13_18_03_0780",16.114286f,3.600000f,22.457144f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_336",true);
		
		myObj= CreateGameObject("a_scroll_19_18_03_0579",23.657143f,3.000000f,22.457144f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_313",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_313", "Sprites/OBJECTS_313", "Sprites/OBJECTS_313", 13, 313, 536, 40, 0, 1, 1, 0, 1, 1, 1, 12, 1);
		AddMagicScroll(myObj);
		
		myObj= CreateGameObject("a_flute_19_18_03_0580",23.314285f,3.000000f,22.114285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_292",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_292", "Sprites/OBJECTS_292", "Sprites/OBJECTS_292", 26, 292, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddInstrument(myObj);
		
		myObj= CreateGameObject("a_longsword_19_18_03_0581",23.314285f,3.000000f,22.114285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_005",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_005", "Sprites/OBJECTS_005", "Sprites/OBJECTS_005", 1, 5, 713, 40, 0, 1, 1, 0, 1, 1, 1, 8, 1);
		CreateWeapon(myObj, 10, 4, 8, 3, 28);
		
		myObj= CreateGameObject("a_campfire_39_18_03_0858",47.314285f,2.400000f,22.780001f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_298",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_298", "Sprites/OBJECTS_298", "Sprites/OBJECTS_298", 16, 298, 0, 40, 0, 0, 0, 1, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_scroll_39_18_03_0861",47.485714f,2.400000f,22.285715f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_313",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_313", "Sprites/OBJECTS_313", "Sprites/OBJECTS_313", 13, 313, 617, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetReadable(myObj);
		SetLink(myObj,617);
		
		myObj= CreateGameObject("a_rock_hammer_39_18_03_0862",47.657143f,2.400000f,21.771429f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_296",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_296", "Sprites/OBJECTS_296", "Sprites/OBJECTS_296", 16, 296, 0, 40, 27, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_sack_40_18_03_0857",48.857143f,2.400000f,21.771429f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_128",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_128", "Sprites/OBJECTS_128", "Sprites/OBJECTS_129", 19, 128, 855, 40, 27, 1, 1, 0, 1, 0, 0, 0, 1);
		////Container contents
		ParentContainer = CreateContainer(myObj, 125, 255, 255);
		AddObjectToContainer("an_ear_of_corn_ears_of_corn_99_99_03_0855", ParentContainer, 0);
		AddObjectToContainer("some_leeches_bunches_of_leeches_99_99_03_0850", ParentContainer, 1);
		////Container contents complete
		
		
		myObj= CreateGameObject("a_bedroll_40_18_03_0863",48.020000f,2.400000f,21.942856f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_289",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_289", "Sprites/OBJECTS_289", "Sprites/OBJECTS_289", 16, 289, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_bowl_42_18_03_0519",51.257145f,2.400000f,21.942856f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_142",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_142", "Sprites/OBJECTS_142", "Sprites/OBJECTS_142", 19, 142, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		////Container contents
		ParentContainer = CreateContainer(myObj, 50, 2, 3);
		////Container contents complete
		
		
		
		myObj = new GameObject("door_021_019");
		pos = new Vector3(25.400000f, 3.000000f, 23.980000f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_327", "Sprites/OBJECTS_327", "Sprites/OBJECTS_327", 29, 327, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/world/uw1_058", 53, 0);
		SetRotation(myObj,-90,-180,0);
		
		myObj= CreateGameObject("chain_gauntlets_pairs_of_chain_gauntlets_29_19_03_0779",35.314285f,3.000000f,23.828571f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_039",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_039", "Sprites/OBJECTS_039", "Sprites/armour/armor_f_0007", 76, 39, 0, 36, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		CreateGloves(myObj, "Sprites/armour/armor_f_0007", "Sprites/armour/armor_m_0007", "Sprites/armour/armor_f_0022", "Sprites/armour/armor_m_0022", "Sprites/armour/armor_f_0037", "Sprites/armour/armor_m_0037", "Sprites/armour/armor_f_0052", "Sprites/armour/armor_m_0052", 3, 9);
		
		myObj= CreateGameObject("a_broken_shield_33_19_03_0775",40.457142f,2.700000f,23.142857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_203",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_203", "Sprites/OBJECTS_203", "Sprites/OBJECTS_203", 23, 203, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_blood_stain_39_19_03_0860",47.314285f,2.400000f,23.828571f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_221",true);
		
		myObj = new GameObject("an_outcast_40_19_03_0254");
		pos = new Vector3(48.171432f, 2.400000f, 22.971428f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"90","Sprites/OBJECTS_090", 137);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_090", "Sprites/OBJECTS_090", "Sprites/OBJECTS_090", 0, 90, 0, 40, 19, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 137, 40, 19, 0, 0, 18, 0, 0, 8, 2, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("door_047_019");
		pos = new Vector3(57.400002f, 0.000000f, 23.980000f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_327", "Sprites/OBJECTS_327", "Sprites/OBJECTS_327", 29, 327, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/world/uw1_203", 53, 0);
		SetRotation(myObj,-90,0,0);
		
		myObj= CreateGameObject("a_small_boulder_57_19_03_0774",69.428566f,3.000000f,23.828571f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_342",true);
		
		myObj= CreateGameObject("a_boulder_58_19_03_0773",69.771431f,3.300000f,23.828571f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_341",true);
		
		myObj= CreateGameObject("a_chest_19_20_03_0867",23.828571f,3.000000f,24.857143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_349",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_349", "Sprites/OBJECTS_349", "Sprites/OBJECTS_349", 19, 349, 832, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		////Container contents
		ParentContainer = CreateContainer(myObj, -842150451, -842150451, -842150451);
		AddObjectToContainer("a_wand_99_99_03_0866", ParentContainer, 0);
		AddObjectToContainer("a_coin_99_99_03_0865", ParentContainer, 1);
		AddObjectToContainer("a_Corp_stone_99_99_03_0656", ParentContainer, 2);
		AddObjectToContainer("a_Grav_stone_99_99_03_0655", ParentContainer, 3);
		////Container contents complete
		
		
		myObj= CreateGameObject("special_tmap_obj_21_20_03_0570",25.799999f,3.000000f,24.020000f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 568, 40, 1, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,"uw1_058", "a_look_trigger_99_99_03_0568", 58, false);
		SetRotation(myObj,0,180,0);
		
		myObj= CreateGameObject("a_mushroom_24_20_03_0868",29.657143f,3.000000f,25.028572f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_184",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_184", "Sprites/OBJECTS_184", "Sprites/OBJECTS_184", 14, 184, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddPotion(myObj);
		
		myObj= CreateGameObject("a_mushroom_24_20_03_0869",29.142857f,3.000000f,24.857143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_184",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_184", "Sprites/OBJECTS_184", "Sprites/OBJECTS_184", 14, 184, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddPotion(myObj);
		
		myObj= CreateGameObject("a_scroll_46_20_03_0513",55.885712f,0.000000f,24.685715f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_312",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_312", "Sprites/OBJECTS_312", "Sprites/OBJECTS_312", 13, 312, 623, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetReadable(myObj);
		SetLink(myObj,623);
		
		myObj= CreateGameObject("a_blood_stain_46_20_03_0512",55.714287f,0.000000f,24.514284f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_223",true);
		
		myObj= CreateGameObject("a_pile_of_bones_piles_of_bones_46_20_03_0515",55.371429f,0.000000f,24.857143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_198",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_198", "Sprites/OBJECTS_198", "Sprites/OBJECTS_198", 23, 198, 1, 63, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_skull_46_20_03_0517",56.057144f,0.000000f,24.342857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_194",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_194", "Sprites/OBJECTS_194", "Sprites/OBJECTS_194", 23, 194, 1, 63, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_skull_48_20_03_0514",58.457142f,0.000000f,24.171429f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_195",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_195", "Sprites/OBJECTS_195", "Sprites/OBJECTS_195", 23, 195, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_pile_of_debris_piles_of_debris_57_20_03_0768",69.257141f,3.000000f,24.857143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_209", "Sprites/OBJECTS_209", "Sprites/OBJECTS_209", 23, 209, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_pile_of_debris_piles_of_debris_57_20_03_0769",68.742859f,3.000000f,24.857143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_209", "Sprites/OBJECTS_209", "Sprites/OBJECTS_209", 23, 209, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_pile_of_debris_piles_of_debris_57_20_03_0770",68.914284f,3.000000f,24.514284f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_209", "Sprites/OBJECTS_209", "Sprites/OBJECTS_209", 23, 209, 644, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		
		myObj= CreateGameObject("a_box_boxes_04_21_03_0795",5.828571f,3.600000f,25.714285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_132",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_132", "Sprites/OBJECTS_132", "Sprites/OBJECTS_133", 19, 132, 794, 40, 13, 1, 1, 0, 1, 0, 0, 0, 1);
		////Container contents
		ParentContainer = CreateContainer(myObj, 125, 255, 255);
		AddObjectToContainer("a_gold_coin_99_99_03_0794", ParentContainer, 0);
		AddObjectToContainer("a_bottle_of_water_bottles_of_water_99_99_03_0791", ParentContainer, 1);
		////Container contents complete
		
		
		myObj= CreateGameObject("a_book_04_21_03_0790",4.820000f,3.600000f,25.542856f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_309",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_309", "Sprites/OBJECTS_309", "Sprites/OBJECTS_309", 11, 309, 609, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetReadable(myObj);
		SetLink(myObj,609);
		
		myObj= CreateGameObject("a_campfire_04_21_03_0817",5.314286f,3.600000f,25.714285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_298",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_298", "Sprites/OBJECTS_298", "Sprites/OBJECTS_298", 16, 298, 0, 40, 0, 0, 0, 1, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_bedroll_05_21_03_0818",6.514286f,3.600000f,25.714285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_289",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_289", "Sprites/OBJECTS_289", "Sprites/OBJECTS_289", 16, 289, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_box_boxes_12_21_03_0781",15.428572f,3.600000f,25.714285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_132",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_132", "Sprites/OBJECTS_132", "Sprites/OBJECTS_133", 19, 132, 782, 40, 13, 1, 1, 0, 1, 0, 0, 0, 1);
		////Container contents
		ParentContainer = CreateContainer(myObj, 125, 255, 255);
		AddObjectToContainer("a_bottle_of_ale_bottles_of_ale_99_99_03_0782", ParentContainer, 0);
		AddObjectToContainer("a_mandolin_99_99_03_0784", ParentContainer, 1);
		////Container contents complete
		
		
		myObj= CreateGameObject("a_scroll_12_21_03_0785",14.914286f,3.600000f,25.714285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_316",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_316", "Sprites/OBJECTS_316", "Sprites/OBJECTS_316", 11, 316, 622, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetReadable(myObj);
		SetLink(myObj,622);
		
		myObj= CreateGameObject("a_campfire_13_21_03_0816",16.114286f,3.600000f,25.714285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_298",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_298", "Sprites/OBJECTS_298", "Sprites/OBJECTS_298", 16, 298, 0, 40, 0, 0, 0, 1, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_plant_30_21_03_0778",36.857143f,2.700000f,26.057144f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_207",true);
		
		myObj= CreateGameObject("a_plant_30_21_03_0777",37.028572f,2.700000f,25.885715f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_207",true);
		
		myObj= CreateGameObject("a_pouch_pouches_46_21_03_0505",56.057144f,0.000000f,25.542856f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_134",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_134", "Sprites/OBJECTS_134", "Sprites/OBJECTS_135", 19, 134, 504, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		////Container contents
		ParentContainer = CreateContainer(myObj, 20, 255, 255);
		AddObjectToContainer("an_An_stone_99_99_03_0504", ParentContainer, 0);
		AddObjectToContainer("a_Sanct_stone_99_99_03_0503", ParentContainer, 1);
		////Container contents complete
		
		
		myObj= CreateGameObject("a_bone_47_21_03_0511",56.914288f,0.000000f,25.714285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_196",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_196", "Sprites/OBJECTS_196", "Sprites/OBJECTS_196", 23, 196, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("some_writing_09_22_03_1000",11.980000f,4.200000f,27.580000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_358",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_358", "Sprites/OBJECTS_358", "Sprites/OBJECTS_358", 10, 358, 695, 40, 0, 0, 1, 0, 0, 1, 0, 0, 1);
		SetReadable(myObj);
		SetRotation(myObj,0,90,0);
		SetSprite(myObj, "Sprites/tmobj/tmobj_20");
		SetLink(myObj,695);
		
		myObj= CreateGameObject("a_boulder_47_22_03_0708",57.428570f,3.300000f,26.571428f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_341",true);
		
		myObj = new GameObject("a_great_troll_49_22_03_0247");
		pos = new Vector3(59.314285f, 3.300000f, 26.914284f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"112","Sprites/OBJECTS_112", 17);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_112", "Sprites/OBJECTS_112", "Sprites/OBJECTS_112", 0, 112, 653, 49, 22, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 17, 49, 22, 0, 0, 150, 0, 0, 8, 2, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,90,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		////NPC container with items
		
		AddObjectToContainer("dragon_scales_bunches_of_dragon_scales_99_99_03_0653", ParentContainer, 0);
		////Container contents complete
		
		
		myObj = new GameObject("a_dread_spider_60_22_03_0248");
		pos = new Vector3(72.514290f, 2.400000f, 26.914284f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"92","Sprites/OBJECTS_092", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_092", "Sprites/OBJECTS_092", "Sprites/OBJECTS_092", 0, 92, 0, 60, 22, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 60, 22, 0, 0, 26, 0, 0, 4, 0, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("a_fighter_03_23_03_0231");
		pos = new Vector3(4.114285f, 3.600000f, 28.114285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"98","Sprites/OBJECTS_098", 141);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_098", "Sprites/OBJECTS_098", "Sprites/OBJECTS_098", 0, 98, 0, 3, 23, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 141, 3, 23, 0, 0, 39, 0, 0, 8, 2, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("door_007_023");
		pos = new Vector3(8.914286f, 3.600000f, 27.799999f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_320", "Sprites/OBJECTS_320", "Sprites/OBJECTS_320", 4, 320, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_01", 53, 0);
		SetRotation(myObj,-90,90,0);
		
		myObj = new GameObject("door_010_023");
		pos = new Vector3(12.685714f, 3.600000f, 28.600000f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_320", "Sprites/OBJECTS_320", "Sprites/OBJECTS_320", 4, 320, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_01", 53, 0);
		SetRotation(myObj,-90,-90,0);
		
		myObj = new GameObject("a_fighter_13_23_03_0230");
		pos = new Vector3(16.114286f, 3.600000f, 28.114285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"93","Sprites/OBJECTS_093", 139);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_093", "Sprites/OBJECTS_093", "Sprites/OBJECTS_093", 0, 93, 0, 13, 23, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 139, 13, 23, 0, 0, 35, 0, 0, 8, 2, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("a_lurker_20_23_03_0228");
		pos = new Vector3(24.857143f, 2.700000f, 27.771429f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"87","Sprites/OBJECTS_087", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_087", "Sprites/OBJECTS_087", "Sprites/OBJECTS_087", 0, 87, 0, 20, 23, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 20, 23, 0, 0, 15, 0, 0, 8, 2, 1, 0, 0, 0, "WaterMesh1");
		SetRotation(myObj,0,315,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("a_troll_47_23_03_0250");
		pos = new Vector3(56.914288f, 3.300000f, 28.114285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"96","Sprites/OBJECTS_096", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_096", "Sprites/OBJECTS_096", "Sprites/OBJECTS_096", 0, 96, 0, 47, 23, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 47, 23, 0, 0, 44, 0, 0, 8, 1, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,90,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_small_boulder_49_23_03_0706",59.485714f,3.300000f,28.780001f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_342",true);
		
		myObj= CreateGameObject("some_writing_08_24_03_0999",9.620000f,4.200000f,28.820000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_358",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_358", "Sprites/OBJECTS_358", "Sprites/OBJECTS_358", 10, 358, 696, 40, 0, 0, 1, 0, 0, 1, 0, 0, 1);
		SetReadable(myObj);
		SetRotation(myObj,0,270,0);
		SetSprite(myObj, "Sprites/tmobj/tmobj_20");
		SetLink(myObj,696);
		
		myObj= CreateGameObject("a_pile_of_debris_piles_of_debris_39_24_03_0859",47.142857f,2.400000f,29.657143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_209", "Sprites/OBJECTS_209", "Sprites/OBJECTS_209", 23, 209, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_map_case_48_24_03_0700",58.779999f,3.300000f,29.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_136",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_136", "Sprites/OBJECTS_136", "Sprites/OBJECTS_137", 19, 136, 699, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		////Container contents
		ParentContainer = CreateContainer(myObj, 30, 2, 2);
		AddObjectToContainer("a_scroll_99_99_03_0699", ParentContainer, 0);
		////Container contents complete
		
		
		myObj= CreateGameObject("a_pile_of_debris_piles_of_debris_48_24_03_0709",58.628571f,3.300000f,28.971428f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_210",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_210", "Sprites/OBJECTS_210", "Sprites/OBJECTS_210", 23, 210, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_pile_of_debris_piles_of_debris_48_24_03_0711",58.114288f,3.300000f,29.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_209", "Sprites/OBJECTS_209", "Sprites/OBJECTS_209", 23, 209, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_coin_50_24_03_0705",60.514286f,3.300000f,29.485716f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_160",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_160", "Sprites/OBJECTS_160", "Sprites/OBJECTS_160", 18, 160, 31, 40, 15, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_pile_of_debris_piles_of_debris_50_24_03_0710",60.514286f,3.300000f,29.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_209", "Sprites/OBJECTS_209", "Sprites/OBJECTS_209", 23, 209, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj = new GameObject("a_dread_spider_59_24_03_0249");
		pos = new Vector3(71.314285f, 2.400000f, 29.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"92","Sprites/OBJECTS_092", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_092", "Sprites/OBJECTS_092", "Sprites/OBJECTS_092", 0, 92, 0, 59, 24, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 59, 24, 0, 0, 37, 0, 0, 4, 0, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,90,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		
		myObj= CreateGameObject("a_mandolin_61_24_03_0713",74.228569f,2.400000f,29.657143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_291",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_291", "Sprites/OBJECTS_291", "Sprites/OBJECTS_291", 26, 291, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddInstrument(myObj);
		
		myObj= CreateGameObject("a_bench_benches_02_25_03_0787",2.914286f,3.600000f,30.685715f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_336",true);
		
		myObj= CreateGameObject("a_bench_benches_12_25_03_0786",15.085714f,3.600000f,30.514284f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_336",true);
		
		myObj= CreateGameObject("a_mail_shirt_29_25_03_0582",35.142857f,3.600000f,30.857143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_033",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_033", "Sprites/OBJECTS_033", "Sprites/armour/armor_f_0001", 2, 33, 565, 63, 0, 1, 1, 0, 1, 1, 1, 8, 1);
		CreateArmour(myObj, "Sprites/armour/armor_f_0001", "Sprites/armour/armor_m_0001", "Sprites/armour/armor_f_0016", "Sprites/armour/armor_m_0016", "Sprites/armour/armor_f_0031", "Sprites/armour/armor_m_0031", "Sprites/armour/armor_f_0046", "Sprites/armour/armor_m_0046", 4, 22);
		
		myObj = new GameObject("door_056_025");
		pos = new Vector3(67.885712f, 2.400000f, 31.000000f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_321", "Sprites/OBJECTS_321", "Sprites/OBJECTS_321", 4, 321, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_03", 53, 0);
		SetRotation(myObj,-90,-90,0);
		
		myObj= CreateGameObject("a_cauldron_60_25_03_0714",72.857147f,2.400000f,30.857143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_303",true);
		
		myObj= CreateGameObject("a_cauldron_61_25_03_0715",73.714287f,2.400000f,30.514284f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_303",true);
		
		myObj= CreateGameObject("a_bowl_61_25_03_0520",73.371429f,2.400000f,31.028572f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_142",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_142", "Sprites/OBJECTS_142", "Sprites/OBJECTS_142", 19, 142, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		////Container contents
		ParentContainer = CreateContainer(myObj, 50, 2, 3);
		////Container contents complete
		
		
		
		myObj= CreateGameObject("special_tmap_obj_40_26_03_0755",48.020000f,2.400000f,31.799999f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 22, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_137", "" , 137, false);
		SetRotation(myObj,0,270,0);
		
		
		myObj= CreateGameObject("a_scroll_60_26_03_0712",72.514290f,2.400000f,31.714285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_318",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_318", "Sprites/OBJECTS_318", "Sprites/OBJECTS_318", 11, 318, 620, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetReadable(myObj);
		SetLink(myObj,620);
		
		myObj= CreateGameObject("a_cauldron_60_26_03_0716",72.857147f,2.400000f,31.714285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_303",true);
		
		myObj= CreateGameObject("a_sling_stone_20_27_03_0805",24.514284f,3.600000f,32.914284f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_016",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_016", "Sprites/OBJECTS_016", "Sprites/OBJECTS_016", 1, 16, 2, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		CreateWeapon(myObj, -842150451, -842150451, -842150451, -842150451, -842150451);
		
		myObj= CreateGameObject("a_sling_stone_20_27_03_0807",24.857143f,3.600000f,32.571426f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_016",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_016", "Sprites/OBJECTS_016", "Sprites/OBJECTS_016", 1, 16, 5, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		CreateWeapon(myObj, -842150451, -842150451, -842150451, -842150451, -842150451);
		
		myObj= CreateGameObject("a_gold_chain_57_27_03_0856",69.257141f,2.400000f,32.742855f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_171",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_171", "Sprites/OBJECTS_171", "Sprites/OBJECTS_171", 18, 171, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_wand_57_27_03_0870",68.742859f,2.400000f,32.742855f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_153",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_153", "Sprites/OBJECTS_153", "Sprites/OBJECTS_153", 12, 153, 935, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddWand(myObj, 543, 2);
		
		myObj= CreateGameObject("a_gravestone_04_28_03_0823",5.485714f,3.600000f,34.628571f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_357", "Sprites/OBJECTS_357", "Sprites/OBJECTS_357", 84, 357, 702, 40, 0, 0, 1, 0, 1, 1, 0, 1, 1);
		AddGrave(myObj, 29,3);
		
		myObj= CreateGameObject("a_flask_of_port_flasks_of_port_13_28_03_0523",16.628572f,3.600000f,33.771427f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_190",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_190", "Sprites/OBJECTS_190", "Sprites/OBJECTS_190", 24, 190, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetFood(myObj);
		
		myObj= CreateGameObject("a_flask_of_port_flasks_of_port_13_28_03_0522",16.628572f,3.600000f,34.114285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_190",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_190", "Sprites/OBJECTS_190", "Sprites/OBJECTS_190", 24, 190, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetFood(myObj);
		
		myObj= CreateGameObject("a_bottle_of_ale_bottles_of_ale_13_28_03_0521",16.114286f,3.600000f,33.771427f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_186",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_186", "Sprites/OBJECTS_186", "Sprites/OBJECTS_186", 14, 186, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddPotion(myObj);
		
		myObj= CreateGameObject("a_bench_benches_28_28_03_0621",34.285717f,3.600000f,34.457142f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_336",true);
		
		myObj= CreateGameObject("a_bench_benches_36_28_03_0620",43.885712f,3.600000f,34.457142f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_336",true);
		
		myObj = new GameObject("door_051_028");
		pos = new Vector3(62.200001f, 2.400000f, 33.771427f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_322", "Sprites/OBJECTS_322", "Sprites/OBJECTS_322", 4, 322, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_10", 53, 0);
		SetRotation(myObj,-90,0,0);
		
		
		myObj= CreateGameObject("a_helmet_04_29_03_0593",5.314286f,3.600000f,35.828571f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_046",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_046", "Sprites/OBJECTS_046", "Sprites/armour/armor_f_0014", 73, 46, 0, 40, 13, 1, 1, 0, 1, 0, 0, 0, 1);
		CreateHelm(myObj, "Sprites/armour/armor_f_0014", "Sprites/armour/armor_m_0014", "Sprites/armour/armor_f_0029", "Sprites/armour/armor_m_0029", "Sprites/armour/armor_f_0044", "Sprites/armour/armor_m_0044", "Sprites/armour/armor_f_0059", "Sprites/armour/armor_m_0059", 2954796, 2954796);
		
		myObj= CreateGameObject("a_helmet_04_29_03_0594",5.314286f,3.600000f,34.820000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_046",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_046", "Sprites/OBJECTS_046", "Sprites/armour/armor_f_0014", 73, 46, 0, 40, 13, 1, 1, 0, 1, 0, 0, 0, 1);
		CreateHelm(myObj, "Sprites/armour/armor_f_0014", "Sprites/armour/armor_m_0014", "Sprites/armour/armor_f_0029", "Sprites/armour/armor_m_0029", "Sprites/armour/armor_f_0044", "Sprites/armour/armor_m_0044", "Sprites/armour/armor_f_0059", "Sprites/armour/armor_m_0059", 2954796, 2954796);
		
		myObj = new GameObject("a_fighter_12_29_03_0193");
		pos = new Vector3(14.914286f, 3.600000f, 35.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"94","Sprites/OBJECTS_094", 140);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_094", "Sprites/OBJECTS_094", "Sprites/OBJECTS_094", 0, 94, 0, 12, 29, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 140, 12, 29, 0, 0, 54, 0, 0, 8, 2, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("some_writing_13_29_03_0998",16.780001f,4.500000f,35.657143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_358",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_358", "Sprites/OBJECTS_358", "Sprites/OBJECTS_358", 10, 358, 699, 40, 0, 0, 1, 0, 0, 1, 0, 0, 1);
		SetReadable(myObj);
		SetRotation(myObj,0,90,0);
		SetSprite(myObj, "Sprites/tmobj/tmobj_20");
		SetLink(myObj,699);
		
		myObj= CreateGameObject("a_gravestone_04_30_03_0824",5.485714f,3.600000f,36.171429f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_357", "Sprites/OBJECTS_357", "Sprites/OBJECTS_357", 84, 357, 703, 40, 0, 0, 1, 0, 1, 1, 0, 0, 1);
		AddGrave(myObj, 28,4);
		
		myObj = new GameObject("door_014_030");
		pos = new Vector3(17.980000f, 3.600000f, 37.000000f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_320", "Sprites/OBJECTS_320", "Sprites/OBJECTS_320", 4, 320, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_01", 53, 0);
		SetRotation(myObj,-90,-90,0);
		
		myObj= CreateGameObject("a_lever_60_30_03_0811",72.514290f,3.300000f,36.171429f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_381",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_381", "Sprites/OBJECTS_381", "Sprites/OBJECTS_381", 8, 381, 789, 40, 0, 0, 1, 0, 0, 0, 0, 0, 1);
		CreateUWActivators(myObj,"ButtonHandler","a_use_trigger_99_99_03_0789",40,0,0,7,381);
		SetRotation(myObj,0,180,0);
		SetButtonProperties(myObj, 1, "Sprites/tmflat/tmflat_0013", "Sprites/tmflat/tmflat_0005");
		
		myObj = new GameObject("a_skeleton_61_30_03_0220");
		pos = new Vector3(73.714287f, 0.600000f, 36.514286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"74","Sprites/OBJECTS_074", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_074", "Sprites/OBJECTS_074", "Sprites/OBJECTS_074", 0, 74, 0, 61, 30, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 61, 30, 0, 0, 25, 0, 0, 8, 0, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_lever_57_31_03_0526",68.419998f,2.700000f,37.714283f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_381",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_381", "Sprites/OBJECTS_381", "Sprites/OBJECTS_381", 8, 381, 702, 40, 0, 0, 1, 0, 0, 0, 0, 0, 1);
		CreateUWActivators(myObj,"ButtonHandler","a_use_trigger_99_99_03_0702",40,0,0,7,381);
		SetRotation(myObj,0,270,0);
		SetButtonProperties(myObj, 1, "Sprites/tmflat/tmflat_0013", "Sprites/tmflat/tmflat_0005");
		
		
		myObj= CreateGameObject("a_bench_benches_27_32_03_0618",33.257145f,2.400000f,38.914284f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_336",true);
		
		myObj= CreateGameObject("special_tmap_obj_27_32_03_1013",33.580002f,3.000000f,39.000000f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 34, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_142", "" , 142, false);
		SetRotation(myObj,0,90,0);
		
		myObj= CreateGameObject("a_bench_benches_37_32_03_0619",44.742855f,2.400000f,38.914284f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_336",true);
		
		myObj= CreateGameObject("special_tmap_obj_37_32_03_1011",44.419998f,3.000000f,39.000000f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 34, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_142", "" , 142, false);
		SetRotation(myObj,0,270,0);
		
		myObj = new GameObject("a_skeleton_59_32_03_0190");
		pos = new Vector3(71.314285f, 0.600000f, 38.914284f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"74","Sprites/OBJECTS_074", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_074", "Sprites/OBJECTS_074", "Sprites/OBJECTS_074", 0, 74, 0, 59, 32, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 59, 32, 0, 0, 22, 0, 0, 8, 0, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_scroll_04_33_03_0493",4.971428f,3.600000f,40.628571f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_319",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_319", "Sprites/OBJECTS_319", "Sprites/OBJECTS_319", 11, 319, 626, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetReadable(myObj);
		SetLink(myObj,626);
		
		myObj= CreateGameObject("a_scroll_04_33_03_0753",5.142857f,3.600000f,39.771427f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_319",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_319", "Sprites/OBJECTS_319", "Sprites/OBJECTS_319", 11, 319, 614, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetReadable(myObj);
		SetLink(myObj,614);
		
		myObj= CreateGameObject("a_scroll_04_33_03_0559",5.142857f,3.600000f,40.457142f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_312",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_312", "Sprites/OBJECTS_312", "Sprites/OBJECTS_312", 13, 312, 615, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetReadable(myObj);
		SetLink(myObj,615);
		
		myObj = new GameObject("a_deep_lurker_23_33_03_0227");
		pos = new Vector3(28.114285f, 1.200000f, 40.114285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"116","Sprites/OBJECTS_116", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_116", "Sprites/OBJECTS_116", "Sprites/OBJECTS_116", 0, 116, 0, 23, 33, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 23, 33, 0, 0, 83, 0, 0, 8, 2, 0, 0, 0, 0, "WaterMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("a_feral_troll_43_33_03_0246");
		pos = new Vector3(52.114288f, 2.400000f, 40.114285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"111","Sprites/OBJECTS_111", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_111", "Sprites/OBJECTS_111", "Sprites/OBJECTS_111", 0, 111, 0, 43, 33, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 43, 33, 0, 0, 82, 0, 0, 8, 1, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("door_047_033");
		pos = new Vector3(56.742855f, 2.700000f, 40.599998f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_323", "Sprites/OBJECTS_323", "Sprites/OBJECTS_323", 4, 323, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_12", 53, 0);
		SetRotation(myObj,-90,-90,0);
		
		myObj = new GameObject("door_056_033");
		pos = new Vector3(67.714287f, 2.400000f, 39.799999f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_323", "Sprites/OBJECTS_323", "Sprites/OBJECTS_323", 4, 323, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_12", 53, 0);
		SetRotation(myObj,-90,90,0);
		
		
		
		myObj= CreateGameObject("a_lever_61_33_03_0853",74.379997f,3.900000f,40.114285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_381",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_381", "Sprites/OBJECTS_381", "Sprites/OBJECTS_381", 8, 381, 809, 40, 0, 0, 1, 0, 0, 0, 0, 0, 1);
		CreateUWActivators(myObj,"ButtonHandler","a_use_trigger_99_99_03_0809",40,0,0,7,381);
		SetRotation(myObj,0,90,0);
		SetButtonProperties(myObj, 1, "Sprites/tmflat/tmflat_0013", "Sprites/tmflat/tmflat_0005");
		
		myObj= CreateGameObject("a_book_04_34_03_0495",5.142857f,3.600000f,41.657143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_307",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_307", "Sprites/OBJECTS_307", "Sprites/OBJECTS_307", 11, 307, 624, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetReadable(myObj);
		SetLink(myObj,624);
		
		myObj= CreateGameObject("a_scroll_04_34_03_0494",5.142857f,3.600000f,41.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_313",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_313", "Sprites/OBJECTS_313", "Sprites/OBJECTS_313", 13, 313, 625, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetReadable(myObj);
		SetLink(myObj,625);
		
		myObj= CreateGameObject("a_scroll_04_34_03_0558",5.314286f,3.600000f,40.971432f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_313",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_313", "Sprites/OBJECTS_313", "Sprites/OBJECTS_313", 13, 313, 616, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetReadable(myObj);
		SetLink(myObj,616);
		
		myObj= CreateGameObject("a_shrine_09_34_03_0663",11.314286f,3.600000f,41.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_343",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_343", "Sprites/OBJECTS_343", "Sprites/OBJECTS_343", 83, 343, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddShrine(myObj);
		
		myObj= CreateGameObject("a_lever_58_34_03_0799",70.114288f,4.500000f,41.980000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_381",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_381", "Sprites/OBJECTS_381", "Sprites/OBJECTS_381", 8, 381, 550, 40, 0, 0, 1, 0, 0, 0, 0, 0, 1);
		CreateUWActivators(myObj,"ButtonHandler","a_use_trigger_99_99_03_0550",40,0,0,7,381);
		SetRotation(myObj,0,0,0);
		SetButtonProperties(myObj, 1, "Sprites/tmflat/tmflat_0013", "Sprites/tmflat/tmflat_0005");
		
		myObj = new GameObject("a_skeleton_60_34_03_0244");
		pos = new Vector3(72.514290f, 0.600000f, 41.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"74","Sprites/OBJECTS_074", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_074", "Sprites/OBJECTS_074", "Sprites/OBJECTS_074", 0, 74, 0, 60, 34, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 60, 34, 0, 0, 42, 0, 0, 8, 0, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,225,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("special_tmap_obj_32_35_03_1012",39.000000f,3.000000f,42.020000f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 34, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_142", "" , 142, false);
		SetRotation(myObj,0,180,0);
		
		myObj = new GameObject("door_061_035");
		pos = new Vector3(73.400002f, 0.600000f, 42.020000f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_327", "Sprites/OBJECTS_327", "Sprites/OBJECTS_327", 29, 327, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/world/uw1_204", 53, 0);
		SetRotation(myObj,-90,-180,0);
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_14_36_03_0802",17.314285f,3.600000f,43.714287f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj= CreateGameObject("a_broken_mace_16_36_03_0803",19.714287f,3.600000f,43.714287f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_202",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_202", "Sprites/OBJECTS_202", "Sprites/OBJECTS_202", 23, 202, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		
		myObj= CreateGameObject("special_tmap_obj_24_36_03_0990",29.980000f,3.600000f,43.799999f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 33, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_140", "" , 140, false);
		SetRotation(myObj,0,90,0);
		
		
		myObj= CreateGameObject("an_axe_43_36_03_0449",51.942856f,2.400000f,43.542858f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_002",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_002", "Sprites/OBJECTS_002", "Sprites/OBJECTS_002", 1, 2, 712, 40, 0, 1, 1, 0, 1, 1, 1, 8, 1);
		CreateWeapon(myObj, 10, 6, 8, 4, 25);
		
		
		
		myObj= CreateGameObject("a_piece_of_wood_pieces_of_wood_13_38_03_0767",16.114286f,3.600000f,46.114288f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_205",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_205", "Sprites/OBJECTS_205", "Sprites/OBJECTS_205", 23, 205, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_16_38_03_0804",19.714287f,3.600000f,46.114288f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj= CreateGameObject("an_urn_23_38_03_0624",28.285715f,3.600000f,46.114288f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_140",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_140", "Sprites/OBJECTS_140", "Sprites/OBJECTS_140", 19, 140, 828, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		////Container contents
		ParentContainer = CreateContainer(myObj, 200, 255, 255);
		AddObjectToContainer("a_green_potion_99_99_03_0828", ParentContainer, 0);
		AddObjectToContainer("an_oil_flask_99_99_03_0506", ParentContainer, 1);
		AddObjectToContainer("a_mushroom_99_99_03_0507", ParentContainer, 2);
		////Container contents complete
		
		
		myObj= CreateGameObject("a_bench_benches_27_38_03_0664",32.914284f,1.800000f,46.114288f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_336",true);
		
		myObj= CreateGameObject("a_bench_benches_37_38_03_0665",44.914288f,1.800000f,46.114288f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_336",true);
		
		myObj = new GameObject("a_feral_troll_47_38_03_0245");
		pos = new Vector3(56.914288f, 2.400000f, 46.114288f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"111","Sprites/OBJECTS_111", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_111", "Sprites/OBJECTS_111", "Sprites/OBJECTS_111", 0, 111, 0, 47, 38, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 47, 38, 0, 0, 81, 0, 0, 8, 0, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_blood_stain_58_38_03_0660",70.114288f,2.400000f,46.114288f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_223",true);
		
		myObj = new GameObject("a_headless_headlesses_60_38_03_0205");
		pos = new Vector3(72.514290f, 2.400000f, 46.114288f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"91","Sprites/OBJECTS_091", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_091", "Sprites/OBJECTS_091", "Sprites/OBJECTS_091", 0, 91, 0, 60, 38, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 60, 38, 0, 0, 42, 0, 0, 8, 2, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_pile_of_bones_piles_of_bones_61_38_03_0662",73.542854f,2.400000f,46.114288f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_198",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_198", "Sprites/OBJECTS_198", "Sprites/OBJECTS_198", 23, 198, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_blood_stain_61_38_03_0659",73.714287f,2.400000f,46.114288f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_223",true);
		
		myObj= CreateGameObject("a_leather_cap_61_38_03_0591",74.057144f,2.400000f,46.285713f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_044",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_044", "Sprites/OBJECTS_044", "Sprites/armour/armor_f_0012", 73, 44, 546, 40, 0, 1, 1, 0, 1, 1, 1, 8, 1);
		CreateHelm(myObj, "Sprites/armour/armor_f_0012", "Sprites/armour/armor_m_0012", "Sprites/armour/armor_f_0027", "Sprites/armour/armor_m_0027", "Sprites/armour/armor_f_0042", "Sprites/armour/armor_m_0042", "Sprites/armour/armor_f_0057", "Sprites/armour/armor_m_0057", 2954796, 2954796);
		
		myObj= CreateGameObject("a_blood_stain_61_38_03_0657",73.371429f,2.400000f,45.942856f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_223",true);
		
		myObj= CreateGameObject("a_skull_59_39_03_0658",71.314285f,2.400000f,47.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_194",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_194", "Sprites/OBJECTS_194", "Sprites/OBJECTS_194", 23, 194, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj = new GameObject("a_headless_headlesses_60_39_03_0204");
		pos = new Vector3(72.514290f, 2.400000f, 47.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"91","Sprites/OBJECTS_091", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_091", "Sprites/OBJECTS_091", "Sprites/OBJECTS_091", 0, 91, 0, 60, 39, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 60, 39, 0, 0, 40, 0, 0, 8, 2, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_blood_stain_61_39_03_0592",74.057144f,2.400000f,46.971432f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_223",true);
		
		myObj = new GameObject("a_reaper_04_40_03_0215");
		pos = new Vector3(5.314286f, 3.600000f, 48.514286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"118","Sprites/OBJECTS_118", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_118", "Sprites/OBJECTS_118", "Sprites/OBJECTS_118", 0, 118, 0, 4, 40, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 4, 40, 0, 0, 71, 0, 0, 8, 0, 0, 0, 0, 0, "GroundMesh2");
		SetRotation(myObj,0,45,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_broken_shield_15_40_03_0762",18.171429f,3.600000f,49.028568f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_203",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_203", "Sprites/OBJECTS_203", "Sprites/OBJECTS_203", 23, 203, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj = new GameObject("door_021_040");
		pos = new Vector3(25.714285f, 3.600000f, 48.200001f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_321", "Sprites/OBJECTS_321", "Sprites/OBJECTS_321", 4, 321, 754, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_03", 8, 1);
		SetRotation(myObj,-90,90,0);
		myObj= CreateGameObject("a_lock_99_99_03_0754",25.714285f,3.600000f,48.200001f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_271",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_271", "Sprites/OBJECTS_271", "Sprites/OBJECTS_271", 21, 271, 520, 40, 0, 1, 1, 0, 1, 1, 0, 3, 0);
		AddObj_base(myObj);
		
		myObj = new GameObject("a_acid_slug_26_40_03_0222");
		pos = new Vector3(31.714285f, 1.800000f, 48.514286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"69","Sprites/OBJECTS_069", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_069", "Sprites/OBJECTS_069", "Sprites/OBJECTS_069", 0, 69, 0, 26, 40, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 26, 40, 0, 0, 6, 0, 0, 8, 2, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_bench_benches_27_40_03_0667",32.914284f,1.800000f,48.857143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_336",true);
		
		myObj= CreateGameObject("a_bench_benches_37_40_03_0666",44.914288f,1.800000f,48.857143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_336",true);
		
		myObj= CreateGameObject("a_red_potion_42_40_03_0601",50.742855f,2.400000f,49.180000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_187",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_187", "Sprites/OBJECTS_187", "Sprites/OBJECTS_187", 14, 187, 531, 40, 0, 1, 1, 0, 1, 1, 1, 12, 1);
		AddPotion(myObj);
		
		myObj= CreateGameObject("a_broken_sword_42_40_03_0604",51.428570f,2.400000f,49.180000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_201",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_201", "Sprites/OBJECTS_201", "Sprites/OBJECTS_201", 23, 201, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_blood_stain_42_40_03_0613",51.257145f,2.400000f,49.028568f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_222",true);
		
		myObj= CreateGameObject("a_blood_stain_42_40_03_0615",51.257145f,2.400000f,48.342857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_222",true);
		
		myObj= CreateGameObject("a_blood_stain_42_40_03_0614",50.914288f,2.400000f,48.685715f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_222",true);
		
		myObj= CreateGameObject("a_mace_42_40_03_0617",51.257145f,2.400000f,48.342857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_009",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_009", "Sprites/OBJECTS_009", "Sprites/OBJECTS_009", 1, 9, 0, 63, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		CreateWeapon(myObj, 8, 16, 5, 5, 25);
		
		myObj= CreateGameObject("a_skull_42_40_03_0610",50.914288f,2.400000f,48.514286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_194",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_194", "Sprites/OBJECTS_194", "Sprites/OBJECTS_194", 23, 194, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_pile_of_bones_piles_of_bones_42_40_03_0609",51.257145f,2.400000f,48.857143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_198",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_198", "Sprites/OBJECTS_198", "Sprites/OBJECTS_198", 23, 198, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj = new GameObject("door_056_040");
		pos = new Vector3(68.228569f, 2.400000f, 49.000000f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_323", "Sprites/OBJECTS_323", "Sprites/OBJECTS_323", 4, 323, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_12", 53, 0);
		SetRotation(myObj,-90,-90,0);
		
		myObj= CreateGameObject("a_wooden_shield_30_41_03_0528",36.857143f,0.000000f,49.542858f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_060",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_060", "Sprites/OBJECTS_060", "Sprites/OBJECTS_060", 78, 60, 0, 31, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddShield(myObj);
		
		myObj= CreateGameObject("a_broken_shield_42_41_03_0603",50.571430f,2.400000f,49.371429f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_203",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_203", "Sprites/OBJECTS_203", "Sprites/OBJECTS_203", 23, 203, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_blood_stain_42_41_03_0612",50.571430f,2.400000f,49.885712f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_221",true);
		
		myObj = new GameObject("door_043_041");
		pos = new Vector3(52.114288f, 2.400000f, 50.200001f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_323", "Sprites/OBJECTS_323", "Sprites/OBJECTS_323", 4, 323, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_12", 53, 0);
		SetRotation(myObj,-90,-90,0);
		
		myObj = new GameObject("a_headless_headlesses_59_41_03_0202");
		pos = new Vector3(71.314285f, 2.400000f, 49.714287f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"91","Sprites/OBJECTS_091", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_091", "Sprites/OBJECTS_091", "Sprites/OBJECTS_091", 0, 91, 0, 59, 41, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 59, 41, 0, 0, 26, 0, 0, 4, 0, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("a_headless_headlesses_60_41_03_0203");
		pos = new Vector3(72.514290f, 2.400000f, 49.714287f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"91","Sprites/OBJECTS_091", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_091", "Sprites/OBJECTS_091", "Sprites/OBJECTS_091", 0, 91, 0, 60, 41, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 60, 41, 0, 0, 42, 0, 0, 8, 2, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		
		myObj= CreateGameObject("a_broken_mace_42_42_03_0605",51.428570f,2.400000f,50.571430f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_202",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_202", "Sprites/OBJECTS_202", "Sprites/OBJECTS_202", 23, 202, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_wand_42_42_03_0600",51.257145f,2.400000f,51.085712f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_154",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_154", "Sprites/OBJECTS_154", "Sprites/OBJECTS_154", 12, 154, 599, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddWand(myObj, 538, 11);
		
		myObj= CreateGameObject("a_blood_stain_42_42_03_0611",50.914288f,2.400000f,50.914288f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_223",true);
		
		myObj= CreateGameObject("a_skull_42_42_03_0607",50.571430f,2.400000f,51.428570f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_195",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_195", "Sprites/OBJECTS_195", "Sprites/OBJECTS_195", 23, 195, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_pile_of_bones_piles_of_bones_42_42_03_0606",50.742855f,2.400000f,50.742855f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_198",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_198", "Sprites/OBJECTS_198", "Sprites/OBJECTS_198", 23, 198, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_Jux_stone_51_42_03_0598",61.542858f,2.400000f,50.571430f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_224",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_224", "Sprites/OBJECTS_241", "Sprites/OBJECTS_241", 6, 241, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetObjectAsRuneStone(myObj);
		
		myObj= CreateGameObject("a_Mani_stone_51_42_03_0597",62.228569f,2.400000f,50.571430f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_224",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_224", "Sprites/OBJECTS_244", "Sprites/OBJECTS_244", 6, 244, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetObjectAsRuneStone(myObj);
		
		
		myObj= CreateGameObject("a_broken_sword_19_43_03_0761",23.828571f,3.600000f,51.942856f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_201",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_201", "Sprites/OBJECTS_201", "Sprites/OBJECTS_201", 23, 201, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj = new GameObject("a_fighter_20_43_03_0181");
		pos = new Vector3(24.514284f, 3.600000f, 52.114288f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"95","Sprites/OBJECTS_095", 143);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_095", "Sprites/OBJECTS_095", "Sprites/OBJECTS_095", 0, 95, 0, 20, 43, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 143, 20, 43, 0, 0, 43, 0, 0, 7, 2, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("a_wolf_spider_03_44_03_0209");
		pos = new Vector3(4.114285f, 3.600000f, 53.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"83","Sprites/OBJECTS_083", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_083", "Sprites/OBJECTS_083", "Sprites/OBJECTS_083", 0, 83, 0, 3, 44, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 3, 44, 0, 0, 14, 0, 0, 4, 0, 0, 0, 0, 0, "GroundMesh2");
		SetRotation(myObj,0,270,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("a_wolf_spider_04_44_03_0208");
		pos = new Vector3(5.314286f, 3.600000f, 53.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"83","Sprites/OBJECTS_083", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_083", "Sprites/OBJECTS_083", "Sprites/OBJECTS_083", 0, 83, 0, 4, 44, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 4, 44, 0, 0, 12, 0, 0, 4, 0, 0, 0, 0, 0, "GroundMesh2");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_scroll_06_44_03_0719",7.714286f,3.600000f,53.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_313",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_313", "Sprites/OBJECTS_313", "Sprites/OBJECTS_313", 13, 313, 557, 40, 0, 1, 1, 0, 1, 1, 1, 12, 1);
		AddMagicScroll(myObj);
		
		myObj= CreateGameObject("special_tmap_obj_08_44_03_0742",10.200000f,3.600000f,53.980000f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 22, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_137", "" , 137, false);
		SetRotation(myObj,0,0,0);
		
		
		myObj= CreateGameObject("a_gold_plate_10_44_03_0541",12.171429f,3.600000f,53.828568f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_172",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_172", "Sprites/OBJECTS_172", "Sprites/OBJECTS_172", 18, 172, 1, 63, 31, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_gravestone_10_44_03_0542",13.028572f,3.600000f,53.485714f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_357", "Sprites/OBJECTS_357", "Sprites/OBJECTS_357", 84, 357, 704, 40, 0, 0, 1, 0, 1, 1, 0, 0, 1);
		AddGrave(myObj, 28,2);
		
		myObj= CreateGameObject("a_scroll_10_44_03_0744",12.342857f,3.600000f,53.142857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_314",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_314", "Sprites/OBJECTS_314", "Sprites/OBJECTS_314", 13, 314, 621, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetReadable(myObj);
		SetLink(myObj,621);
		
		myObj = new GameObject("door_013_044");
		pos = new Vector3(16.114286f, 3.600000f, 53.000000f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_325", "Sprites/OBJECTS_325", "Sprites/OBJECTS_325", 4, 325, 562, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_06", 0, 1);
		SetRotation(myObj,-90,90,0);
		myObj= CreateGameObject("a_lock_99_99_03_0562",16.114286f,3.600000f,53.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_271",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_271", "Sprites/OBJECTS_271", "Sprites/OBJECTS_271", 21, 271, 512, 40, 0, 1, 1, 0, 1, 1, 0, 3, 0);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_switch_13_44_03_0747",16.628572f,4.200000f,53.980000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_372",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_372", "Sprites/OBJECTS_372", "Sprites/OBJECTS_372", 8, 372, 564, 40, 0, 0, 1, 0, 0, 0, 0, 0, 1);
		CreateUWActivators(myObj,"ButtonHandler","a_use_trigger_99_99_03_0564",40,0,0,7,372);
		SetRotation(myObj,0,0,0);
		SetButtonProperties(myObj, 0, "Sprites/tmflat/tmflat_0004", "Sprites/tmflat/tmflat_0012");
		
		myObj= CreateGameObject("a_switch_13_44_03_0746",16.780001f,4.200000f,52.820000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_371",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_371", "Sprites/OBJECTS_371", "Sprites/OBJECTS_371", 8, 371, 563, 40, 0, 0, 1, 0, 0, 0, 0, 0, 1);
		CreateUWActivators(myObj,"ButtonHandler","a_use_trigger_99_99_03_0563",40,0,0,7,371);
		SetRotation(myObj,0,180,0);
		SetButtonProperties(myObj, 0, "Sprites/tmflat/tmflat_0003", "Sprites/tmflat/tmflat_0011");
		
		myObj= CreateGameObject("a_blood_stain_19_44_03_0548",23.485716f,3.600000f,53.980000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_222",true);
		
		myObj = new GameObject("a_gray_lizardman_red_lizardmen_31_44_03_0221");
		pos = new Vector3(37.714283f, 0.000000f, 53.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"89","Sprites/OBJECTS_089", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_089", "Sprites/OBJECTS_089", "Sprites/OBJECTS_089", 0, 89, 0, 31, 44, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 31, 44, 0, 0, 37, 0, 0, 8, 2, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("a_vampire_bat_33_44_03_0243");
		pos = new Vector3(40.114285f, 1.800000f, 53.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"73","Sprites/OBJECTS_073", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_073", "Sprites/OBJECTS_073", "Sprites/OBJECTS_073", 0, 73, 0, 33, 44, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 33, 44, 0, 0, 17, 0, 0, 8, 2, 0, 0, 0, 0, "SkyMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_wand_54_44_03_0649",65.314285f,3.600000f,53.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_153",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_153", "Sprites/OBJECTS_153", "Sprites/OBJECTS_153", 12, 153, 652, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddWand(myObj, 536, 8);
		
		myObj= CreateGameObject("a_green_potion_57_44_03_0844",69.257141f,3.600000f,53.142857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_188",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_188", "Sprites/OBJECTS_188", "Sprites/OBJECTS_188", 14, 188, 564, 40, 0, 1, 1, 0, 1, 1, 1, 12, 1);
		AddPotion(myObj);
		
		myObj = new GameObject("a_wolf_spider_02_45_03_0212");
		pos = new Vector3(3.257143f, 3.600000f, 54.514286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"83","Sprites/OBJECTS_083", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_083", "Sprites/OBJECTS_083", "Sprites/OBJECTS_083", 0, 83, 0, 2, 45, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 2, 45, 0, 0, 25, 0, 0, 4, 0, 0, 0, 0, 0, "GroundMesh2");
		SetRotation(myObj,0,180,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("a_wolf_spider_04_45_03_0210");
		pos = new Vector3(5.314286f, 3.600000f, 54.857143f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"83","Sprites/OBJECTS_083", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_083", "Sprites/OBJECTS_083", "Sprites/OBJECTS_083", 0, 83, 0, 4, 45, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 4, 45, 0, 0, 21, 0, 0, 4, 0, 0, 0, 0, 0, "GroundMesh2");
		SetRotation(myObj,0,225,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("a_wolf_spider_05_45_03_0213");
		pos = new Vector3(6.685714f, 3.600000f, 54.514286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"83","Sprites/OBJECTS_083", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_083", "Sprites/OBJECTS_083", "Sprites/OBJECTS_083", 0, 83, 0, 5, 45, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 5, 45, 0, 0, 21, 0, 0, 4, 2, 0, 0, 0, 0, "GroundMesh2");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		
		myObj= CreateGameObject("a_mace_10_45_03_0749",12.171429f,3.600000f,55.028568f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_009",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_009", "Sprites/OBJECTS_009", "Sprites/OBJECTS_009", 1, 9, 705, 32, 0, 1, 1, 0, 1, 1, 1, 8, 1);
		CreateWeapon(myObj, 8, 16, 5, 5, 25);
		
		
		myObj= CreateGameObject("a_blood_stain_20_45_03_0536",24.514284f,3.600000f,54.514286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_222",true);
		
		myObj = new GameObject("a_cave_bat_32_45_03_0242");
		pos = new Vector3(38.914284f, 1.200000f, 54.514286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"66","Sprites/OBJECTS_066", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_066", "Sprites/OBJECTS_066", "Sprites/OBJECTS_066", 0, 66, 0, 32, 45, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 32, 45, 0, 0, 7, 0, 0, 8, 2, 0, 0, 0, 0, "SkyMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("leather_leggings_pairs_of_leather_leggings_35_45_03_0792",42.857143f,0.000000f,54.857143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_035",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_035", "Sprites/OBJECTS_035", "Sprites/armour/armor_f_0003", 77, 35, 706, 24, 0, 1, 1, 0, 1, 1, 1, 8, 1);
		CreateLeggings(myObj, "Sprites/armour/armor_f_0003", "Sprites/armour/armor_m_0003", "Sprites/armour/armor_f_0018", "Sprites/armour/armor_m_0018", "Sprites/armour/armor_f_0033", "Sprites/armour/armor_m_0033", "Sprites/armour/armor_f_0048", "Sprites/armour/armor_m_0048", 2, 4);
		
		myObj= CreateGameObject("some_grass_bunches_of_grass_37_45_03_0669",44.571430f,0.787500f,54.685715f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_193",true);
		
		myObj= CreateGameObject("a_blood_stain_37_45_03_0670",44.914288f,0.750000f,54.514286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_221",true);
		
		myObj= CreateGameObject("a_book_38_45_03_0668",46.628571f,1.500000f,54.171432f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_307",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_307", "Sprites/OBJECTS_307", "Sprites/OBJECTS_307", 11, 307, 612, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetReadable(myObj);
		SetLink(myObj,612);
		
		myObj= CreateGameObject("a_pouch_pouches_39_45_03_0677",46.820000f,1.500000f,54.685715f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_134",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_134", "Sprites/OBJECTS_134", "Sprites/OBJECTS_135", 19, 134, 676, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		////Container contents
		ParentContainer = CreateContainer(myObj, 20, 255, 255);
		AddObjectToContainer("a_Quas_stone_99_99_03_0676", ParentContainer, 0);
		AddObjectToContainer("an_In_stone_99_99_03_0674", ParentContainer, 1);
		AddObjectToContainer("an_An_stone_99_99_03_0673", ParentContainer, 2);
		AddObjectToContainer("a_lockpick_99_99_03_0675", ParentContainer, 3);
		////Container contents complete
		
		
		myObj= CreateGameObject("a_red_gem_39_45_03_0671",46.820000f,1.500000f,55.180000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_163",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_163", "Sprites/OBJECTS_163", "Sprites/OBJECTS_163", 18, 163, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_mushroom_39_45_03_0678",47.828568f,1.500000f,54.514286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_184",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_184", "Sprites/OBJECTS_184", "Sprites/OBJECTS_184", 14, 184, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddPotion(myObj);
		
		myObj= CreateGameObject("a_mushroom_39_45_03_0679",47.314285f,1.500000f,54.171432f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_184",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_184", "Sprites/OBJECTS_184", "Sprites/OBJECTS_184", 14, 184, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddPotion(myObj);
		
		myObj= CreateGameObject("a_toadstool_39_45_03_0680",47.314285f,1.500000f,54.685715f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_185",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_185", "Sprites/OBJECTS_185", "Sprites/OBJECTS_185", 14, 185, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddPotion(myObj);
		
		myObj= CreateGameObject("a_lantern_39_45_03_0681",47.657143f,1.500000f,54.342857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_144",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_144", "Sprites/OBJECTS_144", "Sprites/OBJECTS_144", 88, 144, 0, 40, 0, 1, 1, 1, 1, 0, 0, 0, 1);
		CreateLantern(myObj, 4, 10, 148, 144);
		
		
		
		myObj= CreateGameObject("an_orb_54_45_03_0650",65.314285f,3.600000f,54.514286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_279",true);
		CreateUWActivators(myObj,"ButtonHandler","a_look_trigger_99_99_03_0651",40,0,0,7,279);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_279", "Sprites/OBJECTS_279", "Sprites/OBJECTS_279", 17, 279, 651, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		
		myObj = new GameObject("a_wolf_spider_03_46_03_0211");
		pos = new Vector3(4.114285f, 3.600000f, 55.714287f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"83","Sprites/OBJECTS_083", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_083", "Sprites/OBJECTS_083", "Sprites/OBJECTS_083", 0, 83, 0, 3, 46, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 3, 46, 0, 0, 22, 0, 0, 4, 0, 0, 0, 0, 0, "GroundMesh2");
		SetRotation(myObj,0,315,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("door_006_046");
		pos = new Vector3(7.714286f, 3.600000f, 56.200001f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_323", "Sprites/OBJECTS_323", "Sprites/OBJECTS_323", 4, 323, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_12", 53, 0);
		SetRotation(myObj,-90,-90,0);
		
		myObj= CreateGameObject("a_coin_15_46_03_0683",18.342857f,3.600000f,56.057144f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_160",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_160", "Sprites/OBJECTS_160", "Sprites/OBJECTS_160", 18, 160, 23, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		
		
		myObj = new GameObject("a_wisp_08_47_03_0214");
		pos = new Vector3(10.114285f, 4.200000f, 56.914288f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"122","Sprites/OBJECTS_122", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_122", "Sprites/OBJECTS_122", "Sprites/OBJECTS_122", 0, 122, 0, 8, 47, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 8, 47, 0, 0, 175, 0, 0, 8, 2, 0, 0, 0, 0, "GroundMesh2");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		
		myObj = new GameObject("door_018_047");
		pos = new Vector3(21.799999f, 3.600000f, 57.580002f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_327", "Sprites/OBJECTS_327", "Sprites/OBJECTS_327", 29, 327, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/world/uw1_154", 53, 0);
		SetRotation(myObj,-90,-180,0);
		
		myObj= CreateGameObject("a_blood_stain_21_47_03_0537",26.228571f,3.600000f,56.571430f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_222",true);
		
		
		myObj= CreateGameObject("special_tmap_obj_29_47_03_1022",34.820000f,0.000000f,57.000000f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 22, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_137", "" , 137, false);
		SetRotation(myObj,0,270,0);
		
		
		myObj= CreateGameObject("special_tmap_obj_35_47_03_1023",43.180000f,0.000000f,57.000000f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 22, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_137", "" , 137, false);
		SetRotation(myObj,0,90,0);
		
		
		
		myObj= CreateGameObject("a_wand_46_47_03_0555",55.542858f,3.600000f,56.742855f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_154",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_154", "Sprites/OBJECTS_154", "Sprites/OBJECTS_154", 12, 154, 579, 40, 0, 1, 1, 0, 1, 1, 1, 12, 1);
		AddWand(myObj, 536, 40);
		
		myObj= CreateGameObject("a_button_46_47_03_1004",55.220001f,4.500000f,57.428570f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_376",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_376", "Sprites/OBJECTS_376", "Sprites/OBJECTS_376", 8, 376, 983, 40, 0, 0, 1, 0, 0, 0, 0, 0, 1);
		CreateUWActivators(myObj,"ButtonHandler","a_use_trigger_99_99_03_0983",40,0,0,7,376);
		SetRotation(myObj,0,270,0);
		SetButtonProperties(myObj, 1, "Sprites/tmflat/tmflat_0008", "Sprites/tmflat/tmflat_0000");
		
		myObj= CreateGameObject("a_button_46_47_03_1007",55.220001f,3.900000f,57.428570f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_376",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_376", "Sprites/OBJECTS_376", "Sprites/OBJECTS_376", 8, 376, 982, 40, 0, 0, 1, 0, 0, 0, 0, 0, 1);
		CreateUWActivators(myObj,"ButtonHandler","a_use_trigger_99_99_03_0982",40,0,0,7,376);
		SetRotation(myObj,0,270,0);
		SetButtonProperties(myObj, 1, "Sprites/tmflat/tmflat_0008", "Sprites/tmflat/tmflat_0000");
		
		myObj= CreateGameObject("a_lever_46_47_03_1005",55.220001f,4.200000f,56.742855f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_353",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_353", "Sprites/OBJECTS_353", "Sprites/OBJECTS_353", 8, 353, 981, 40, 0, 0, 1, 0, 0, 0, 0, 0, 1);
		CreateUWActivators(myObj,"ButtonHandler","a_use_trigger_99_99_03_0981",40,0,0,7,353);
		SetRotation(myObj,0,270,0);
		SetButtonProperties(myObj,"Sprites/tmobj/tmobj_04","Sprites/tmobj/tmobj_05","Sprites/tmobj/tmobj_06","Sprites/tmobj/tmobj_07","Sprites/tmobj/tmobj_08","Sprites/tmobj/tmobj_09","Sprites/tmobj/tmobj_10","Sprites/tmobj/tmobj_11");
		
		myObj= CreateGameObject("a_lever_46_47_03_1006",55.714287f,4.200000f,56.419998f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_353",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_353", "Sprites/OBJECTS_353", "Sprites/OBJECTS_353", 8, 353, 980, 40, 0, 0, 1, 0, 0, 0, 0, 0, 1);
		CreateUWActivators(myObj,"ButtonHandler","a_use_trigger_99_99_03_0980",40,0,0,7,353);
		SetRotation(myObj,0,180,0);
		SetButtonProperties(myObj,"Sprites/tmobj/tmobj_04","Sprites/tmobj/tmobj_05","Sprites/tmobj/tmobj_06","Sprites/tmobj/tmobj_07","Sprites/tmobj/tmobj_08","Sprites/tmobj/tmobj_09","Sprites/tmobj/tmobj_10","Sprites/tmobj/tmobj_11");
		
		myObj= CreateGameObject("a_pile_of_debris_piles_of_debris_13_48_03_0585",15.620000f,3.600000f,58.457142f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_210",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_210", "Sprites/OBJECTS_210", "Sprites/OBJECTS_210", 23, 210, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_pile_of_debris_piles_of_debris_13_48_03_0587",16.285713f,3.600000f,57.619999f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_209", "Sprites/OBJECTS_209", "Sprites/OBJECTS_209", 23, 209, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_gold_chain_13_48_03_0685",16.114286f,3.600000f,58.114288f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_171",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_171", "Sprites/OBJECTS_171", "Sprites/OBJECTS_171", 18, 171, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_pile_of_debris_piles_of_debris_13_48_03_0584",16.114286f,3.600000f,58.114288f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_209", "Sprites/OBJECTS_209", "Sprites/OBJECTS_209", 23, 209, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("special_tmap_obj_18_48_03_0731",22.200001f,3.600000f,57.619999f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 694, 40, 4, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,"uw1_145", "a_look_trigger_99_99_03_0694", 145, false);
		SetRotation(myObj,0,180,0);
		
		myObj= CreateGameObject("a_blood_stain_24_48_03_0549",28.971428f,3.600000f,58.628571f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_222",true);
		
		myObj = new GameObject("a_wolf_spider_32_48_03_0206");
		pos = new Vector3(38.914284f, 0.000000f, 58.114288f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"83","Sprites/OBJECTS_083", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_083", "Sprites/OBJECTS_083", "Sprites/OBJECTS_083", 0, 83, 0, 32, 48, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 32, 48, 0, 0, 15, 0, 0, 8, 2, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("special_tmap_obj_57_48_03_0765",69.580002f,3.600000f,58.200001f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 18, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_067", "" , 67, false);
		SetRotation(myObj,0,90,0);
		
		myObj = new GameObject("a_giant_rat_18_49_03_0224");
		pos = new Vector3(22.114285f, 3.300000f, 59.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"67","Sprites/OBJECTS_067", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_067", "Sprites/OBJECTS_067", "Sprites/OBJECTS_067", 0, 67, 0, 18, 49, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 18, 49, 0, 0, 6, 0, 0, 8, 2, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("some_writing_39_49_03_1010",47.314285f,4.200000f,58.820000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_358",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_358", "Sprites/OBJECTS_358", "Sprites/OBJECTS_358", 10, 358, 686, 40, 0, 0, 1, 0, 0, 1, 0, 0, 1);
		SetReadable(myObj);
		SetRotation(myObj,0,180,0);
		SetSprite(myObj, "Sprites/tmobj/tmobj_20");
		SetLink(myObj,686);
		
		myObj = new GameObject("a_gazer_03_50_03_0218");
		pos = new Vector3(4.285714f, 4.200000f, 61.028568f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"102","Sprites/OBJECTS_102", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_102", "Sprites/OBJECTS_102", "Sprites/OBJECTS_102", 0, 102, 508, 3, 50, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 3, 50, 0, 0, 75, 0, 0, 7, 0, 0, 0, 0, 0, "GroundMesh2");
		SetRotation(myObj,0,180,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		////NPC container with items
		
		AddObjectToContainer("a_red_potion_99_99_03_0508", ParentContainer, 0);
		////Container contents complete
		
		
		myObj= CreateGameObject("a_gold_coin_15_50_03_0692",18.514286f,3.000000f,60.514286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_161",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", 18, 161, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("some_writing_24_50_03_1009",28.820000f,4.200000f,60.685715f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_358",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_358", "Sprites/OBJECTS_358", "Sprites/OBJECTS_358", 10, 358, 687, 40, 0, 0, 1, 0, 0, 1, 0, 0, 1);
		SetReadable(myObj);
		SetRotation(myObj,0,270,0);
		SetSprite(myObj, "Sprites/tmobj/tmobj_20");
		SetLink(myObj,687);
		
		myObj= CreateGameObject("a_scroll_27_50_03_0831",33.257145f,2.400000f,60.342857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_319",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_319", "Sprites/OBJECTS_319", "Sprites/OBJECTS_319", 11, 319, 526, 40, 0, 1, 1, 0, 1, 1, 1, 12, 1);
		AddMagicScroll(myObj);
		
		myObj = new GameObject("a_mongbat_32_50_03_0239");
		pos = new Vector3(38.914284f, 3.300000f, 60.514286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"81","Sprites/OBJECTS_081", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_081", "Sprites/OBJECTS_081", "Sprites/OBJECTS_081", 0, 81, 0, 32, 50, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 32, 50, 0, 0, 24, 0, 0, 8, 2, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_coin_33_50_03_0727",40.114285f,2.400000f,60.514286f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_160",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_160", "Sprites/OBJECTS_160", "Sprites/OBJECTS_160", 18, 160, 11, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj = new GameObject("a_giant_rat_36_50_03_0199");
		pos = new Vector3(43.714287f, 2.400000f, 60.514286f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"72","Sprites/OBJECTS_072", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_072", "Sprites/OBJECTS_072", "Sprites/OBJECTS_072", 0, 72, 0, 36, 50, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 36, 50, 0, 0, 8, 0, 0, 8, 2, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("door_003_051");
		pos = new Vector3(3.800000f, 3.600000f, 61.714287f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_323", "Sprites/OBJECTS_323", "Sprites/OBJECTS_323", 4, 323, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_12", 53, 0);
		SetRotation(myObj,-90,-180,0);
		
		
		myObj= CreateGameObject("special_tmap_obj_07_51_03_0740",9.000000f,3.600000f,62.380001f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 21, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_139", "" , 139, false);
		SetRotation(myObj,0,0,0);
		
		myObj = new GameObject("door_012_051");
		pos = new Vector3(15.400000f, 3.600000f, 61.220001f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_327", "Sprites/OBJECTS_327", "Sprites/OBJECTS_327", 29, 327, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/world/uw1_154", 53, 0);
		SetRotation(myObj,-90,0,0);
		
		myObj= CreateGameObject("a_gold_coin_28_51_03_0728",34.114285f,2.400000f,61.714287f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_161",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", 18, 161, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj = new GameObject("a_bloodworm_28_51_03_0238");
		pos = new Vector3(34.114285f, 2.400000f, 61.714287f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"82","Sprites/OBJECTS_082", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_082", "Sprites/OBJECTS_082", "Sprites/OBJECTS_082", 0, 82, 0, 28, 51, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 28, 51, 0, 0, 20, 0, 0, 4, 0, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		
		
		myObj= CreateGameObject("a_battle_axe_35_51_03_0646",42.514286f,2.400000f,61.714287f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_001",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_001", "Sprites/OBJECTS_001", "Sprites/OBJECTS_001", 1, 1, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		CreateWeapon(myObj, 14, 7, 2, 4, 34);
		
		myObj= CreateGameObject("a_gold_coin_35_51_03_0718",42.514286f,2.400000f,61.714287f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_161",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", 18, 161, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj = new GameObject("a_bloodworm_36_51_03_0236");
		pos = new Vector3(43.714287f, 2.400000f, 61.714287f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"82","Sprites/OBJECTS_082", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_082", "Sprites/OBJECTS_082", "Sprites/OBJECTS_082", 0, 82, 0, 36, 51, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 36, 51, 0, 0, 10, 0, 0, 4, 0, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		
		myObj = new GameObject("door_009_052");
		pos = new Vector3(11.800000f, 3.600000f, 62.914288f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_323", "Sprites/OBJECTS_323", "Sprites/OBJECTS_323", 4, 323, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_12", 53, 0);
		SetRotation(myObj,-90,0,0);
		
		
		myObj = new GameObject("a_giant_rat_31_52_03_0201");
		pos = new Vector3(37.714283f, 2.400000f, 62.914288f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"72","Sprites/OBJECTS_072", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_072", "Sprites/OBJECTS_072", "Sprites/OBJECTS_072", 0, 72, 0, 31, 52, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 31, 52, 0, 0, 9, 0, 0, 8, 2, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_coin_36_52_03_0697",43.714287f,2.400000f,62.914288f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_160",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_160", "Sprites/OBJECTS_160", "Sprites/OBJECTS_160", 18, 160, 9, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_gold_coin_11_53_03_0686",13.714286f,3.300000f,64.114288f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_161",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", 18, 161, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj = new GameObject("a_giant_rat_12_53_03_0225");
		pos = new Vector3(14.914286f, 3.300000f, 64.114288f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"67","Sprites/OBJECTS_067", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_067", "Sprites/OBJECTS_067", "Sprites/OBJECTS_067", 0, 67, 0, 12, 53, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 12, 53, 0, 0, 5, 0, 0, 4, 0, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_torch_torches_15_53_03_0682",18.171429f,3.000000f,63.771431f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_145",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_145", "Sprites/OBJECTS_145", "Sprites/OBJECTS_145", 22, 145, 2, 40, 0, 1, 1, 1, 1, 1, 0, 0, 1);
		CreateLight(myObj, 2, 3, 149, 145);
		
		myObj= CreateGameObject("a_gold_coin_17_53_03_0720",20.914284f,3.300000f,64.114288f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_161",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", 18, 161, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj = new GameObject("a_mongbat_28_53_03_0241");
		pos = new Vector3(34.114285f, 3.300000f, 64.114288f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"81","Sprites/OBJECTS_081", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_081", "Sprites/OBJECTS_081", "Sprites/OBJECTS_081", 0, 81, 0, 28, 53, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 28, 53, 0, 0, 15, 0, 0, 8, 2, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		
		
		myObj = new GameObject("a_mongbat_35_53_03_0240");
		pos = new Vector3(42.514286f, 3.300000f, 64.114288f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"81","Sprites/OBJECTS_081", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_081", "Sprites/OBJECTS_081", "Sprites/OBJECTS_081", 0, 81, 0, 35, 53, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 35, 53, 0, 0, 15, 0, 0, 8, 2, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_gold_coin_11_54_03_0687",13.714286f,3.300000f,65.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_161",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", 18, 161, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_gold_coin_29_54_03_0729",35.314285f,2.400000f,65.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_161",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", 18, 161, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj = new GameObject("a_giant_rat_29_54_03_0200");
		pos = new Vector3(35.314285f, 2.400000f, 65.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"72","Sprites/OBJECTS_072", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_072", "Sprites/OBJECTS_072", "Sprites/OBJECTS_072", 0, 72, 0, 29, 54, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 29, 54, 0, 0, 7, 0, 0, 8, 2, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_gold_coin_37_54_03_0717",44.914288f,2.400000f,65.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_161",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", 18, 161, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		
		myObj = new GameObject("a_mage_08_55_03_0216");
		pos = new Vector3(10.114285f, 3.600000f, 66.171432f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"106","Sprites/OBJECTS_106", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_106", "Sprites/OBJECTS_106", "Sprites/OBJECTS_106", 0, 106, 0, 8, 55, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 8, 55, 0, 0, 89, 0, 0, 8, 0, 0, 0, 0, 0, "GroundMesh2");
		SetRotation(myObj,0,270,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("a_giant_rat_20_55_03_0223");
		pos = new Vector3(24.514284f, 3.300000f, 66.514290f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"72","Sprites/OBJECTS_072", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_072", "Sprites/OBJECTS_072", "Sprites/OBJECTS_072", 0, 72, 0, 20, 55, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 20, 55, 0, 0, 9, 0, 0, 4, 0, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_gold_coin_21_55_03_0696",25.714285f,3.300000f,66.514290f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_161",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", 18, 161, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_coin_26_55_03_0698",31.714285f,2.400000f,66.514290f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_160",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_160", "Sprites/OBJECTS_160", "Sprites/OBJECTS_160", 18, 160, 7, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_gold_coin_33_55_03_0730",40.114285f,2.400000f,66.514290f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_161",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", 18, 161, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj = new GameObject("a_bloodworm_33_55_03_0237");
		pos = new Vector3(40.114285f, 2.400000f, 66.514290f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"82","Sprites/OBJECTS_082", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_082", "Sprites/OBJECTS_082", "Sprites/OBJECTS_082", 0, 82, 0, 33, 55, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 33, 55, 0, 0, 19, 0, 0, 4, 0, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		
		myObj = new GameObject("a_mage_08_56_03_0217");
		pos = new Vector3(10.114285f, 3.600000f, 68.057144f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"106","Sprites/OBJECTS_106", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_106", "Sprites/OBJECTS_106", "Sprites/OBJECTS_106", 0, 106, 0, 8, 56, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 8, 56, 0, 0, 96, 0, 0, 8, 0, 0, 0, 0, 0, "GroundMesh2");
		SetRotation(myObj,0,270,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_gold_coin_16_56_03_0688",19.714287f,3.300000f,67.714287f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_161",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", 18, 161, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_bridge_27_56_03_0955",32.914284f,3.525000f,67.885712f);
		
		myObj= CreateGameObject("a_bridge_28_56_03_0956",34.114285f,3.525000f,67.885712f);
		
		myObj= CreateGameObject("a_bridge_31_56_03_0961",37.714283f,3.825000f,67.885712f);
		
		myObj= CreateGameObject("a_bridge_32_56_03_0960",38.914284f,3.825000f,67.885712f);
		
		myObj= CreateGameObject("a_bridge_33_56_03_0959",40.114285f,3.825000f,67.885712f);
		
		myObj= CreateGameObject("a_bridge_36_56_03_0958",43.714287f,3.525000f,67.885712f);
		
		myObj= CreateGameObject("a_bridge_37_56_03_0957",44.914288f,3.525000f,67.885712f);
		
		myObj= CreateGameObject("a_gold_coin_20_58_03_0695",24.514284f,3.300000f,70.114288f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_161",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", 18, 161, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj = new GameObject("a_wolf_spider_29_58_03_0207");
		pos = new Vector3(35.314285f, 3.000000f, 70.114288f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"83","Sprites/OBJECTS_083", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_083", "Sprites/OBJECTS_083", "Sprites/OBJECTS_083", 0, 83, 0, 29, 58, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 29, 58, 0, 0, 23, 0, 0, 8, 2, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj = new GameObject("a_headless_headlesses_05_59_03_0182");
		pos = new Vector3(6.514286f, 3.600000f, 71.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"91","Sprites/OBJECTS_091", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_091", "Sprites/OBJECTS_091", "Sprites/OBJECTS_091", 0, 91, 0, 5, 59, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 5, 59, 0, 0, 57, 0, 0, 4, 1, 0, 0, 0, 0, "GroundMesh2");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		
		myObj= CreateGameObject("a_battle_axe_05_59_03_0527",7.028571f,3.600000f,71.142853f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_001",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_001", "Sprites/OBJECTS_001", "Sprites/OBJECTS_001", 1, 1, 707, 63, 0, 1, 1, 0, 1, 1, 1, 8, 1);
		CreateWeapon(myObj, 14, 7, 2, 4, 34);
		
		
		myObj = new GameObject("door_009_059");
		pos = new Vector3(11.000000f, 3.600000f, 71.314285f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_323", "Sprites/OBJECTS_323", "Sprites/OBJECTS_323", 4, 323, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_12", 53, 0);
		SetRotation(myObj,-90,-180,0);
		
		myObj = new GameObject("door_015_059");
		pos = new Vector3(19.180000f, 3.300000f, 71.800003f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_327", "Sprites/OBJECTS_327", "Sprites/OBJECTS_327", 29, 327, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/world/uw1_154", 53, 0);
		SetRotation(myObj,-90,-90,0);
		
		myObj= CreateGameObject("a_gold_coin_16_59_03_0689",19.714287f,3.300000f,71.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_161",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", 18, 161, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		
		
		myObj= CreateGameObject("special_tmap_obj_55_59_03_0764",66.019997f,3.600000f,71.400002f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 22, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_137", "" , 137, false);
		SetRotation(myObj,0,270,0);
		
		
		myObj= CreateGameObject("special_tmap_obj_07_60_03_0741",9.000000f,3.600000f,72.019997f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", "Sprites/OBJECTS_366", 34, 366, 0, 40, 21, 0, 0, 0, 0, 0, 0, 0, 1);
		CreateTMAP(myObj,	"uw1_139", "" , 139, false);
		SetRotation(myObj,0,180,0);
		
		myObj= CreateGameObject("leather_boots_pairs_of_leather_boots_13_60_03_0595",16.285713f,3.600000f,72.342857f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_041",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_041", "Sprites/OBJECTS_041", "Sprites/armour/armor_f_0009", 75, 41, 530, 40, 0, 1, 1, 0, 1, 1, 1, 8, 1);
		CreateBoots(myObj, "Sprites/armour/armor_f_0009", "Sprites/armour/armor_m_0009", "Sprites/armour/armor_f_0024", "Sprites/armour/armor_m_0024", "Sprites/armour/armor_f_0039", "Sprites/armour/armor_m_0039", "Sprites/armour/armor_f_0054", "Sprites/armour/armor_m_0054", 1, 3);
		
		myObj= CreateGameObject("a_goblet_13_60_03_0684",15.771428f,3.600000f,72.171432f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_169",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_169", "Sprites/OBJECTS_169", "Sprites/OBJECTS_169", 18, 169, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("a_gold_coin_21_60_03_0690",25.714285f,3.000000f,72.514290f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_161",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", 18, 161, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		
		myObj= CreateGameObject("some_writing_46_60_03_1008",56.380001f,4.200000f,72.514290f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_358",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_358", "Sprites/OBJECTS_358", "Sprites/OBJECTS_358", 10, 358, 688, 40, 0, 0, 1, 0, 0, 1, 0, 0, 1);
		SetReadable(myObj);
		SetRotation(myObj,0,90,0);
		SetSprite(myObj, "Sprites/tmobj/tmobj_20");
		SetLink(myObj,688);
		
		myObj= CreateGameObject("a_red_potion_13_61_03_0819",15.771428f,3.600000f,74.228569f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_187",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_187", "Sprites/OBJECTS_187", "Sprites/OBJECTS_187", 14, 187, 542, 40, 0, 1, 1, 0, 1, 1, 1, 12, 1);
		AddPotion(myObj);
		
		myObj = new GameObject("door_027_061");
		pos = new Vector3(32.419998f, 3.600000f, 73.400002f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_325", "Sprites/OBJECTS_325", "Sprites/OBJECTS_325", 4, 325, 543, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/doors/doors_06", 13, 1);
		SetRotation(myObj,-90,90,0);
		myObj= CreateGameObject("a_lock_99_99_03_0543",32.419998f,3.600000f,73.400002f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_271",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_271", "Sprites/OBJECTS_271", "Sprites/OBJECTS_271", 21, 271, 525, 40, 0, 1, 1, 0, 1, 1, 0, 3, 0);
		AddObj_base(myObj);
		
		myObj = new GameObject("door_029_061");
		pos = new Vector3(35.980000f, 3.600000f, 74.199997f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_327", "Sprites/OBJECTS_327", "Sprites/OBJECTS_327", 29, 327, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/world/uw1_199", 53, 0);
		SetRotation(myObj,-90,-90,0);
		
		myObj = new GameObject("a_fighter_32_61_03_0194");
		pos = new Vector3(38.914284f, 3.600000f, 73.714287f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"98","Sprites/OBJECTS_098", 142);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_098", "Sprites/OBJECTS_098", "Sprites/OBJECTS_098", 0, 98, 544, 32, 61, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 142, 32, 61, 0, 0, 95, 0, 0, 10, 0, 0, 0, 0, 0, "GroundMesh1");
		SetRotation(myObj,0,180,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		////NPC container with items
		
		AddObjectToContainer("a_key_013_1", ParentContainer, 0);
		AddObjectToContainer("a_jeweled_sword_99_99_03_0553", ParentContainer, 1);
		AddObjectToContainer("a_coin_99_99_03_0703", ParentContainer, 2);
		AddObjectToContainer("a_mail_shirt_99_99_03_0854", ParentContainer, 3);
		////Container contents complete
		
		
		myObj = new GameObject("door_035_061");
		pos = new Vector3(42.020000f, 3.600000f, 73.400002f);
		myObj.transform.position = pos;
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_327", "Sprites/OBJECTS_327", "Sprites/OBJECTS_327", 29, 327, 0, 40, 0, 0, 1, 0, 1, 0, 0, 0, 1);
		CreateDoor(myObj,"textures/world/uw1_199", 53, 0);
		SetRotation(myObj,-90,90,0);
		
		myObj= CreateGameObject("leather_boots_pairs_of_leather_boots_50_61_03_0672",60.171432f,2.700000f,73.371429f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_041",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_041", "Sprites/OBJECTS_041", "Sprites/armour/armor_f_0009", 75, 41, 713, 40, 0, 1, 1, 0, 1, 1, 1, 8, 1);
		CreateBoots(myObj, "Sprites/armour/armor_f_0009", "Sprites/armour/armor_m_0009", "Sprites/armour/armor_f_0024", "Sprites/armour/armor_m_0024", "Sprites/armour/armor_f_0039", "Sprites/armour/armor_m_0039", "Sprites/armour/armor_f_0054", "Sprites/armour/armor_m_0054", 1, 3);
		
		//UW Triggers and Traps
		myObj= CreateGameObject("a_set_variable_trap_99_99_03_0004",120.000000f,1.387500f,119.142860f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_397",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_397", "Sprites/OBJECTS_397", "Sprites/OBJECTS_397", 50, 397, 218, 1, 52, 0, 0, 0, 1, 1, 0, 2, 0);
		SetRotation(myObj,0,45,0);
		Create_a_set_variable_trap(myObj,37,34,1);
		
		myObj= CreateGameObject("a_check_variable_trap_99_99_03_0007",118.800003f,2.737500f,119.142860f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_398",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_398", "Sprites/OBJECTS_398", "Sprites/OBJECTS_398", 51, 398, 44, 9, 6, 0, 0, 0, 1, 0, 0, 4, 0);
		SetRotation(myObj,0,270,0);
		Create_a_check_variable_trap(myObj,73,0,50,6);
		
		myObj= CreateGameObject("a_door_trap_99_99_03_0031",119.485710f,2.512500f,118.800003f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_392",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_392", "Sprites/OBJECTS_392", "Sprites/OBJECTS_392", 45, 392, 462, 59, 15, 0, 0, 0, 1, 0, 0, 7, 0);
		SetRotation(myObj,0,90,0);
		Create_a_door_trap(myObj,59);
		
		myObj= CreateGameObject("a_delete_object_trap_99_99_03_0032",119.657135f,0.075000f,120.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_395",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_395", "Sprites/OBJECTS_395", "Sprites/OBJECTS_395", 48, 395, 58, 37, 57, 0, 0, 0, 1, 0, 0, 3, 0);
		SetRotation(myObj,0,270,0);
		Create_a_delete_object_trap(myObj);
		
		myObj= CreateGameObject("a_set_variable_trap_99_99_03_0036",119.657135f,0.225000f,118.971428f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_397",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_397", "Sprites/OBJECTS_397", "Sprites/OBJECTS_397", 50, 397, 1020, 13, 4, 0, 0, 0, 1, 1, 1, 15, 0);
		SetRotation(myObj,0,270,0);
		Create_a_set_variable_trap(myObj,6,33,6);
		AddTrapLink(myObj,"a_teleport_trap_28_47_03_1020");
		
		myObj= CreateGameObject("a_arrow_trap_99_99_03_0061",118.800003f,4.462500f,118.971428f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_386",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_386", "Sprites/OBJECTS_386", "Sprites/OBJECTS_386", 39, 386, 573, 9, 37, 0, 0, 0, 1, 1, 0, 5, 0);
		SetRotation(myObj,0,0,0);
		Create_a_arrow_trap(myObj, 293, 16);
		
		myObj= CreateGameObject("a_arrow_trap_99_99_03_0076",118.800003f,2.362500f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_386",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_386", "Sprites/OBJECTS_386", "Sprites/OBJECTS_386", 39, 386, 2, 3, 1, 0, 0, 0, 1, 1, 0, 4, 0);
		SetRotation(myObj,0,225,0);
		Create_a_arrow_trap(myObj, 97, 0);
		
		myObj= CreateGameObject("a_do_trap_99_99_03_0261",119.657135f,3.300000f,119.657135f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_387",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_387", "Sprites/OBJECTS_387", "Sprites/OBJECTS_387", 40, 387, 744, 62, 33, 0, 0, 0, 1, 1, 0, 5, 0);
		SetRotation(myObj,0,45,0);
		Create_trap_base(myObj);
		
		myObj= CreateGameObject("a_spelltrap_99_99_03_0283",119.657135f,0.900000f,118.800003f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_390",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_390", "Sprites/OBJECTS_390", "Sprites/OBJECTS_390", 43, 390, 90, 25, 7, 0, 0, 0, 1, 0, 0, 3, 0);
		SetRotation(myObj,0,180,0);
		Create_a_spelltrap(myObj);
		
		myObj= CreateGameObject("a_damage_trap_99_99_03_0294",119.828575f,0.225000f,119.657135f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_384",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_384", "Sprites/OBJECTS_384", "Sprites/OBJECTS_384", 37, 384, 928, 11, 13, 0, 0, 0, 1, 1, 0, 3, 0);
		SetRotation(myObj,0,270,0);
		Create_a_damage_trap(myObj);
		
		myObj= CreateGameObject("a_spelltrap_99_99_03_0329",120.000000f,0.225000f,119.485710f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_390",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_390", "Sprites/OBJECTS_390", "Sprites/OBJECTS_390", 43, 390, 112, 46, 14, 0, 0, 0, 1, 1, 0, 4, 0);
		SetRotation(myObj,0,225,0);
		Create_a_spelltrap(myObj);
		AddTrapLink(myObj,"a_switch_99_99_03_0112");
		
		myObj= CreateGameObject("a_create_object_trap_99_99_03_0342",118.971428f,2.737500f,119.485710f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_391",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", 44, 391, 122, 18, 59, 0, 0, 0, 1, 0, 1, 9, 0);
		SetRotation(myObj,0,315,0);
		Create_a_create_object_trap(myObj);
		AddTrapLink(myObj,"a_broadsword_99_99_03_0122");
		
		myObj= CreateGameObject("a_delete_object_trap_99_99_03_0347",119.485710f,3.150000f,118.971428f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_395",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_395", "Sprites/OBJECTS_395", "Sprites/OBJECTS_395", 48, 395, 840, 51, 51, 0, 0, 0, 1, 1, 1, 15, 0);
		SetRotation(myObj,0,315,0);
		Create_a_delete_object_trap(myObj);
		
		myObj= CreateGameObject("a_step_on_trigger_99_99_03_0353",118.800003f,3.562500f,120.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_420",false);
		CreateTrigger(myObj,6,11,"special_tmap_obj_24_36_03_0990");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_420", "Sprites/OBJECTS_420", "Sprites/OBJECTS_420", 58, 420, 990, 6, 11, 0, 0, 0, 1, 0, 1, 12, 0);
		
		myObj= CreateGameObject("a_delete_object_trap_99_99_03_0380",118.971428f,0.412500f,120.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_395",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_395", "Sprites/OBJECTS_395", "Sprites/OBJECTS_395", 48, 395, 996, 9, 3, 0, 0, 0, 1, 1, 1, 11, 0);
		SetRotation(myObj,0,225,0);
		Create_a_delete_object_trap(myObj);
		
		myObj= CreateGameObject("a_teleport_trap_99_99_03_0381",119.485710f,2.700000f,119.657135f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_385",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_385", "Sprites/OBJECTS_385", "Sprites/OBJECTS_385", 38, 385, 996, 61, 43, 0, 0, 0, 1, 1, 1, 15, 0);
		SetRotation(myObj,0,45,0);
		Create_a_teleport_trap(myObj,(float)73.800000,(float)52.200000,(float)4.500000,72);
		
		myObj= CreateGameObject("an_inventory_trap_99_99_03_0403",118.800003f,2.025000f,118.971428f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_396",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_396", "Sprites/OBJECTS_396", "Sprites/OBJECTS_396", 49, 396, 32, 17, 14, 0, 0, 0, 1, 1, 0, 5, 0);
		SetRotation(myObj,0,90,0);
		Create_an_inventory_trap(myObj);
		AddTrapLink(myObj,"a_delete_object_trap_99_99_03_0032");
		
		myObj= CreateGameObject("a_delete_object_trap_99_99_03_0406",119.142860f,0.150000f,118.800003f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_395",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_395", "Sprites/OBJECTS_395", "Sprites/OBJECTS_395", 48, 395, 692, 43, 5, 0, 0, 0, 1, 1, 0, 6, 0);
		SetRotation(myObj,0,90,0);
		Create_a_delete_object_trap(myObj);
		
		myObj= CreateGameObject("an_inventory_trap_99_99_03_0421",120.000000f,0.525000f,120.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_396",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_396", "Sprites/OBJECTS_396", "Sprites/OBJECTS_396", 49, 396, 1008, 22, 54, 0, 0, 0, 1, 1, 0, 5, 0);
		SetRotation(myObj,0,180,0);
		Create_an_inventory_trap(myObj);
		
		myObj= CreateGameObject("a_do_trap_05_55_03_0510",6.857143f,4.200000f,67.028572f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_387",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_387", "Sprites/OBJECTS_387", "Sprites/OBJECTS_387", 40, 387, 0, 2, 0, 0, 0, 0, 1, 1, 0, 1, 1);
		SetRotation(myObj,0,90,0);
		Create_a_do_trap(myObj,2,1);
		
		myObj= CreateGameObject("a_create_object_trap_35_15_03_0529",42.000000f,2.400000f,18.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_391",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", 44, 391, 183, 49, 0, 0, 0, 0, 1, 0, 0, 0, 1);
		SetRotation(myObj,0,0,0);
		Create_a_create_object_trap(myObj);
		AddTrapLink(myObj,"a_giant_rat_35_35_03_0183");
		
		myObj= CreateGameObject("a_create_object_trap_35_55_03_0530",42.000000f,2.400000f,66.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_391",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", 44, 391, 184, 40, 0, 0, 0, 0, 1, 0, 0, 0, 1);
		SetRotation(myObj,0,0,0);
		Create_a_create_object_trap(myObj);
		AddTrapLink(myObj,"a_mongbat_35_35_03_0184");
		
		myObj= CreateGameObject("a_create_object_trap_30_52_03_0531",36.000000f,2.400000f,62.400002f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_391",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", 44, 391, 185, 40, 0, 0, 0, 0, 1, 0, 0, 0, 1);
		SetRotation(myObj,0,0,0);
		Create_a_create_object_trap(myObj);
		AddTrapLink(myObj,"a_bloodworm_30_30_03_0185");
		
		myObj= CreateGameObject("a_create_object_trap_60_24_03_0532",72.000000f,2.400000f,28.799999f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_391",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", 44, 391, 186, 42, 0, 0, 0, 0, 1, 0, 0, 0, 1);
		SetRotation(myObj,0,0,0);
		Create_a_create_object_trap(myObj);
		AddTrapLink(myObj,"a_dread_spider_60_60_03_0186");
		
		myObj= CreateGameObject("a_create_object_trap_61_41_03_0533",73.199997f,2.400000f,49.200001f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_391",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", 44, 391, 187, 43, 0, 0, 0, 0, 1, 0, 0, 0, 1);
		SetRotation(myObj,0,0,0);
		Create_a_create_object_trap(myObj);
		AddTrapLink(myObj,"a_headless_headlesses_61_61_03_0187");
		
		myObj= CreateGameObject("a_use_trigger_99_99_03_0550",119.314285f,0.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_418",false);
		CreateTrigger(myObj,57,28,"a_change_terrain_trap_57_28_03_0771");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_418", "Sprites/OBJECTS_418", "Sprites/OBJECTS_418", 56, 418, 771, 57, 28, 0, 0, 0, 1, 1, 0, 4, 0);
		
		myObj= CreateGameObject("a_move_trigger_99_99_03_0556",119.400002f,4.500000f,119.400002f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,13,44,"a_door_trap_99_99_03_0561");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 561, 13, 44, 0, 0, 0, 1, 1, 1, 14, 0);
		
		myObj= CreateGameObject("a_check_variable_trap_13_45_03_0557",15.771428f,1.012500f,55.028568f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_398",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_398", "Sprites/OBJECTS_398", "Sprites/OBJECTS_398", 51, 398, 556, 0, 4, 0, 0, 0, 1, 0, 0, 0, 1);
		SetRotation(myObj,0,0,0);
		Create_a_check_variable_trap(myObj,27,1,38,0);
		AddTrapLink(myObj,"a_move_trigger_99_99_03_0556");
		
		myObj= CreateGameObject("a_door_trap_99_99_03_0561",118.800003f,3.600000f,118.800003f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_392",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_392", "Sprites/OBJECTS_392", "Sprites/OBJECTS_392", 45, 392, 560, 3, 0, 0, 0, 0, 1, 0, 0, 1, 0);
		SetRotation(myObj,0,0,0);
		Create_a_door_trap(myObj,3);
		AddTrapLink(myObj,"a_lock_99_99_03_0560");
		
		myObj= CreateGameObject("a_use_trigger_99_99_03_0563",119.314285f,4.500000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_418",false);
		CreateTrigger(myObj,13,43,"a_set_variable_trap_13_43_03_0565");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_418", "Sprites/OBJECTS_418", "Sprites/OBJECTS_418", 56, 418, 565, 13, 43, 0, 0, 0, 1, 1, 0, 6, 0);
		
		myObj= CreateGameObject("a_use_trigger_99_99_03_0564",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_418",false);
		CreateTrigger(myObj,13,45,"a_set_variable_trap_13_45_03_0567");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_418", "Sprites/OBJECTS_418", "Sprites/OBJECTS_418", 56, 418, 567, 13, 45, 0, 0, 0, 1, 1, 0, 6, 0);
		
		myObj= CreateGameObject("a_set_variable_trap_13_43_03_0565",15.600000f,1.012500f,51.771431f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_397",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_397", "Sprites/OBJECTS_397", "Sprites/OBJECTS_397", 50, 397, 566, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,270,0);
		Create_a_set_variable_trap(myObj,27,1,6);
		AddTrapLink(myObj,"a_set_variable_trap_13_43_03_0566");
		
		myObj= CreateGameObject("a_set_variable_trap_13_43_03_0566",15.600000f,1.012500f,51.771431f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_397",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_397", "Sprites/OBJECTS_397", "Sprites/OBJECTS_397", 50, 397, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1);
		SetRotation(myObj,0,180,0);
		Create_a_set_variable_trap(myObj,27,1,4);
		
		myObj= CreateGameObject("a_set_variable_trap_13_45_03_0567",15.600000f,1.012500f,54.171432f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_397",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_397", "Sprites/OBJECTS_397", "Sprites/OBJECTS_397", 50, 397, 557, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,270,0);
		Create_a_set_variable_trap(myObj,27,1,6);
		AddTrapLink(myObj,"a_check_variable_trap_13_45_03_0557");
		
		myObj= CreateGameObject("a_look_trigger_99_99_03_0568",119.314285f,0.375000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_419",false);
		CreateTrigger(myObj,21,19,"a_change_terrain_trap_21_19_03_0569");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_419", "Sprites/OBJECTS_419", "Sprites/OBJECTS_419", 57, 419, 569, 21, 19, 0, 0, 0, 1, 1, 0, 4, 0);
		
		myObj= CreateGameObject("a_change_terrain_trap_21_19_03_0569",25.200001f,3.000000f,22.799999f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_389",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_389", "Sprites/OBJECTS_389", "Sprites/OBJECTS_389", 42, 389, 724, 23, 63, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_change_terrain_trap(myObj,21,19,0,0);
		AddTrapLink(myObj,"a_delete_object_trap_21_19_03_0724");
		
		myObj= CreateGameObject("a_use_trigger_99_99_03_0574",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_418",false);
		CreateTrigger(myObj,3,10,"a_door_trap_99_99_03_0826");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_418", "Sprites/OBJECTS_418", "Sprites/OBJECTS_418", 56, 418, 826, 3, 10, 0, 0, 0, 1, 1, 0, 6, 0);
		
		myObj= CreateGameObject("a_change_terrain_trap_56_36_03_0627",67.199997f,1.800000f,43.200001f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_389",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_389", "Sprites/OBJECTS_389", "Sprites/OBJECTS_389", 42, 389, 0, 23, 63, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_change_terrain_trap(myObj,56,36,0,0);
		
		myObj= CreateGameObject("a_look_trigger_99_99_03_0644",119.314285f,0.375000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_419",false);
		CreateTrigger(myObj,57,20,"a_create_object_trap_57_20_03_0645");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_419", "Sprites/OBJECTS_419", "Sprites/OBJECTS_419", 57, 419, 645, 57, 20, 0, 0, 0, 1, 1, 0, 4, 0);
		
		myObj= CreateGameObject("a_create_object_trap_57_20_03_0645",68.400002f,3.000000f,24.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_391",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", "Sprites/OBJECTS_391", 44, 391, 643, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_create_object_trap(myObj);
		AddTrapLink(myObj,"a_coin_57_57_03_0643");
		
		myObj= CreateGameObject("a_arrow_trap_56_06_03_0647",67.714287f,3.000000f,8.057143f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_386",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_386", "Sprites/OBJECTS_386", "Sprites/OBJECTS_386", 39, 386, 0, 6, 3, 0, 0, 0, 1, 0, 0, 0, 1);
		SetRotation(myObj,0,270,0);
		Create_a_arrow_trap(myObj, 195, 23);
		
		myObj= CreateGameObject("a_arrow_trap_56_06_03_0648",68.228569f,3.300000f,8.400000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_386",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_386", "Sprites/OBJECTS_386", "Sprites/OBJECTS_386", 39, 386, 647, 6, 4, 0, 0, 0, 1, 0, 0, 0, 1);
		SetRotation(myObj,0,225,0);
		Create_a_arrow_trap(myObj, 196, 23);
		AddTrapLink(myObj,"a_arrow_trap_56_06_03_0647");
		
		myObj= CreateGameObject("a_look_trigger_99_99_03_0651",119.314285f,0.000000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_419",false);
		CreateTrigger(myObj,5,55,"a_do_trap_05_55_03_0510");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_419", "Sprites/OBJECTS_419", "Sprites/OBJECTS_419", 57, 419, 510, 5, 55, 0, 0, 0, 1, 1, 0, 6, 0);
		
		myObj= CreateGameObject("a_change_terrain_trap_18_47_03_0693",21.600000f,3.600000f,56.400002f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_389",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_389", "Sprites/OBJECTS_389", "Sprites/OBJECTS_389", 42, 389, 725, 11, 63, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_change_terrain_trap(myObj,18,47,0,0);
		AddTrapLink(myObj,"a_delete_object_trap_18_47_03_0725");
		
		myObj= CreateGameObject("a_look_trigger_99_99_03_0694",119.314285f,0.000000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_419",false);
		CreateTrigger(myObj,18,47,"a_change_terrain_trap_18_47_03_0693");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_419", "Sprites/OBJECTS_419", "Sprites/OBJECTS_419", 57, 419, 693, 18, 47, 0, 0, 0, 1, 1, 0, 4, 0);
		
		myObj= CreateGameObject("a_move_trigger_61_36_03_0701",73.800003f,0.600000f,43.799999f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,56,36,"a_change_terrain_trap_56_36_03_0627");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 627, 56, 36, 0, 0, 0, 1, 1, 0, 4, 1);
		
		myObj= CreateGameObject("a_use_trigger_99_99_03_0702",119.314285f,0.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_418",false);
		CreateTrigger(myObj,60,31,"a_change_terrain_trap_60_31_03_0837");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_418", "Sprites/OBJECTS_418", "Sprites/OBJECTS_418", 56, 418, 837, 60, 31, 0, 0, 0, 1, 1, 0, 4, 0);
		
		myObj= CreateGameObject("a_change_terrain_trap_60_33_03_0704",72.000000f,2.100000f,39.599998f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_389",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_389", "Sprites/OBJECTS_389", "Sprites/OBJECTS_389", 42, 389, 0, 23, 63, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,315,0);
		Create_a_change_terrain_trap(myObj,60,33,0,0);
		
		myObj= CreateGameObject("a_delete_object_trap_21_19_03_0724",25.200001f,0.000000f,22.799999f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_395",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_395", "Sprites/OBJECTS_395", "Sprites/OBJECTS_395", 48, 395, 570, 21, 20, 0, 0, 0, 1, 1, 0, 0, 1);
		SetRotation(myObj,0,0,0);
		Create_a_delete_object_trap(myObj);
		
		myObj= CreateGameObject("a_delete_object_trap_18_47_03_0725",21.600000f,0.000000f,56.400002f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_395",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_395", "Sprites/OBJECTS_395", "Sprites/OBJECTS_395", 48, 395, 731, 18, 48, 0, 0, 0, 1, 1, 0, 0, 1);
		SetRotation(myObj,0,0,0);
		Create_a_delete_object_trap(myObj);
		
		myObj= CreateGameObject("a_move_trigger_07_60_03_0736",9.000000f,3.600000f,72.599998f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,7,59,"a_teleport_trap_07_59_03_0738");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 738, 7, 59, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_move_trigger_07_51_03_0737",9.000000f,3.600000f,61.799999f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,7,52,"a_teleport_trap_07_52_03_0739");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 739, 7, 52, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_teleport_trap_07_59_03_0738",8.400000f,0.112500f,70.800003f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_385",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_385", "Sprites/OBJECTS_385", "Sprites/OBJECTS_385", 38, 385, 0, 7, 59, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_teleport_trap(myObj,(float)9.000000,(float)71.400000,(float)3.600000,3);
		
		myObj= CreateGameObject("a_teleport_trap_07_52_03_0739",8.400000f,0.112500f,62.400002f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_385",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_385", "Sprites/OBJECTS_385", "Sprites/OBJECTS_385", 38, 385, 0, 7, 52, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_teleport_trap(myObj,(float)9.000000,(float)63.000000,(float)4.500000,3);
		
		myObj= CreateGameObject("a_move_trigger_08_44_03_0743",10.200000f,3.600000f,53.400002f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,8,45,"a_teleport_trap_08_45_03_0752");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 752, 8, 45, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_teleport_trap_08_45_03_0752",9.600000f,0.187500f,54.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_385",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_385", "Sprites/OBJECTS_385", "Sprites/OBJECTS_385", 38, 385, 0, 8, 45, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_teleport_trap(myObj,(float)10.200000,(float)54.600000,(float)3.600000,5);
		
		myObj= CreateGameObject("a_move_trigger_40_26_03_0756",48.599998f,2.400000f,31.799999f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,39,26,"a_teleport_trap_39_26_03_0757");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 757, 39, 26, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_teleport_trap_39_26_03_0757",46.799999f,0.187500f,31.200001f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_385",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_385", "Sprites/OBJECTS_385", "Sprites/OBJECTS_385", 38, 385, 0, 39, 26, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_teleport_trap(myObj,(float)47.400000,(float)31.800000,(float)4.500000,5);
		
		myObj= CreateGameObject("a_teleport_trap_54_59_03_0758",64.800003f,0.187500f,70.800003f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_385",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_385", "Sprites/OBJECTS_385", "Sprites/OBJECTS_385", 38, 385, 0, 54, 59, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_teleport_trap(myObj,(float)65.400000,(float)71.400000,(float)4.500000,5);
		
		myObj= CreateGameObject("a_move_trigger_55_59_03_0763",66.599998f,3.600000f,71.400002f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,54,59,"a_teleport_trap_54_59_03_0758");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 758, 54, 59, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_change_terrain_trap_57_28_03_0771",68.571434f,2.400000f,34.114285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_389",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_389", "Sprites/OBJECTS_389", "Sprites/OBJECTS_389", 42, 389, 0, 23, 63, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_change_terrain_trap(myObj,57,28,1,3);
		
		myObj= CreateGameObject("a_change_terrain_trap_58_33_03_0772",69.599998f,2.700000f,39.599998f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_389",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_389", "Sprites/OBJECTS_389", "Sprites/OBJECTS_389", 42, 389, 0, 23, 63, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,315,0);
		Create_a_change_terrain_trap(myObj,58,33,0,0);
		
		myObj= CreateGameObject("a_use_trigger_99_99_03_0789",119.314285f,0.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_418",false);
		CreateTrigger(myObj,60,33,"a_change_terrain_trap_60_33_03_0704");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_418", "Sprites/OBJECTS_418", "Sprites/OBJECTS_418", 56, 418, 704, 60, 33, 0, 0, 0, 1, 1, 0, 4, 0);
		
		myObj= CreateGameObject("a_use_trigger_99_99_03_0809",119.314285f,0.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_418",false);
		CreateTrigger(myObj,58,33,"a_change_terrain_trap_58_33_03_0772");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_418", "Sprites/OBJECTS_418", "Sprites/OBJECTS_418", 56, 418, 772, 58, 33, 0, 0, 0, 1, 1, 0, 4, 0);
		
		myObj= CreateGameObject("a_door_trap_99_99_03_0826",118.800003f,3.600000f,118.800003f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_392",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_392", "Sprites/OBJECTS_392", "Sprites/OBJECTS_392", 45, 392, 572, 3, 0, 0, 0, 0, 1, 0, 0, 1, 0);
		SetRotation(myObj,0,0,0);
		Create_a_door_trap(myObj,3);
		AddTrapLink(myObj,"a_lock_99_99_03_0572");
		
		myObj= CreateGameObject("a_change_terrain_trap_60_31_03_0837",72.000000f,1.500000f,37.200001f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_389",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_389", "Sprites/OBJECTS_389", "Sprites/OBJECTS_389", 42, 389, 0, 23, 63, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,315,0);
		Create_a_change_terrain_trap(myObj,60,31,0,0);
		
		myObj= CreateGameObject("a_arrow_trap_56_06_03_0886",68.400002f,3.562500f,7.885714f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_386",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_386", "Sprites/OBJECTS_386", "Sprites/OBJECTS_386", 39, 386, 648, 6, 3, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,270,0);
		Create_a_arrow_trap(myObj, 195, 23);
		AddTrapLink(myObj,"a_arrow_trap_56_06_03_0648");
		
		myObj= CreateGameObject("a_move_trigger_54_06_03_0887",65.400002f,2.400000f,7.800000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,56,6,"a_arrow_trap_56_06_03_0886");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 886, 56, 6, 0, 0, 0, 1, 1, 0, 4, 1);
		
		myObj= CreateGameObject("a_use_trigger_99_99_03_0980",119.314285f,4.500000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_418",false);
		CreateTrigger(myObj,48,45,"a_do_trap_48_45_03_0984");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_418", "Sprites/OBJECTS_418", "Sprites/OBJECTS_418", 56, 418, 984, 48, 45, 0, 0, 0, 1, 1, 0, 6, 0);
		
		myObj= CreateGameObject("a_use_trigger_99_99_03_0981",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_418",false);
		CreateTrigger(myObj,47,45,"a_do_trap_47_45_03_0985");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_418", "Sprites/OBJECTS_418", "Sprites/OBJECTS_418", 56, 418, 985, 47, 45, 0, 0, 0, 1, 1, 0, 6, 0);
		
		myObj= CreateGameObject("a_use_trigger_99_99_03_0982",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_418",false);
		CreateTrigger(myObj,47,46,"a_do_trap_47_46_03_0986");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_418", "Sprites/OBJECTS_418", "Sprites/OBJECTS_418", 56, 418, 986, 47, 46, 0, 0, 0, 1, 1, 0, 6, 0);
		
		myObj= CreateGameObject("a_use_trigger_99_99_03_0983",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_418",false);
		CreateTrigger(myObj,46,46,"a_do_trap_46_46_03_0987");
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_418", "Sprites/OBJECTS_418", "Sprites/OBJECTS_418", 56, 418, 987, 46, 46, 0, 0, 0, 1, 1, 0, 6, 0);
		
		myObj= CreateGameObject("a_do_trap_48_45_03_0984",57.599998f,4.500000f,54.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_387",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_387", "Sprites/OBJECTS_387", "Sprites/OBJECTS_387", 40, 387, 0, 24, 3, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,45,0);
		Create_a_do_trap(myObj,24,1);
		
		myObj= CreateGameObject("a_do_trap_47_45_03_0985",56.400002f,4.500000f,54.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_387",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_387", "Sprites/OBJECTS_387", "Sprites/OBJECTS_387", 40, 387, 0, 24, 2, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,45,0);
		Create_a_do_trap(myObj,24,1);
		
		myObj= CreateGameObject("a_do_trap_47_46_03_0986",56.400002f,3.600000f,55.200001f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_387",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_387", "Sprites/OBJECTS_387", "Sprites/OBJECTS_387", 40, 387, 0, 24, 1, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,45,0);
		Create_a_do_trap(myObj,24,1);
		
		myObj= CreateGameObject("a_do_trap_46_46_03_0987",55.200001f,3.600000f,55.200001f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_387",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_387", "Sprites/OBJECTS_387", "Sprites/OBJECTS_387", 40, 387, 0, 24, 0, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,45,0);
		Create_a_do_trap(myObj,24,1);
		
		myObj= CreateGameObject("a_move_trigger_24_36_03_0988",29.400000f,3.600000f,43.799999f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,25,36,"a_teleport_trap_25_36_03_0989");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 989, 25, 36, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_teleport_trap_25_36_03_0989",30.000000f,0.112500f,43.200001f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_385",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_385", "Sprites/OBJECTS_385", "Sprites/OBJECTS_385", 38, 385, 0, 25, 36, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,45,0);
		Create_a_teleport_trap(myObj,(float)30.600000,(float)43.800000,(float)1.800000,3);
		
		myObj= CreateGameObject("a_teleport_trap_40_02_03_1016",48.000000f,0.112500f,2.400000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_385",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_385", "Sprites/OBJECTS_385", "Sprites/OBJECTS_385", 38, 385, 0, 41, 2, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,45,0);
		Create_a_teleport_trap(myObj,(float)49.800000,(float)3.000000,(float)2.400000,3);
		
		myObj= CreateGameObject("a_move_trigger_41_02_03_1017",49.799999f,2.400000f,3.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,40,2,"a_teleport_trap_40_02_03_1016");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 1016, 40, 2, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_move_trigger_35_47_03_1018",42.599998f,0.000000f,57.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,36,47,"a_teleport_trap_36_47_03_1019");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 1019, 36, 47, 0, 0, 0, 1, 1, 0, 6, 1);
		
		myObj= CreateGameObject("a_teleport_trap_36_47_03_1019",43.200001f,0.187500f,56.400002f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_385",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_385", "Sprites/OBJECTS_385", "Sprites/OBJECTS_385", 38, 385, 0, 35, 47, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_teleport_trap(myObj,(float)42.600000,(float)57.000000,(float)0.000000,5);
		
		myObj= CreateGameObject("a_teleport_trap_28_47_03_1020",33.599998f,0.187500f,56.400002f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_385",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_385", "Sprites/OBJECTS_385", "Sprites/OBJECTS_385", 38, 385, 0, 28, 47, 0, 0, 0, 1, 0, 0, 1, 1);
		SetRotation(myObj,0,0,0);
		Create_a_teleport_trap(myObj,(float)34.200000,(float)57.000000,(float)4.500000,5);
		
		myObj= CreateGameObject("a_move_trigger_29_47_03_1021",35.400002f,0.000000f,57.000000f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_416",false);
		CreateMoveTrigger(myObj,28,47,"a_teleport_trap_28_47_03_1020");
		CreateCollider(myObj,1.20f,1.20f,1.20f);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", "Sprites/OBJECTS_416", 54, 416, 1020, 28, 47, 0, 0, 0, 1, 1, 0, 6, 1);
		
		//Supplementary object 122
		myObj= CreateGameObject("a_broadsword_99_99_03_0122",119.828575f,0.375000f,119.485710f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_006",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_006", "Sprites/OBJECTS_006", "Sprites/OBJECTS_006", 1, 6, 999, 13, 34, 1, 1, 0, 1, 1, 0, 6, 1);
		CreateWeapon(myObj, 13, 6, 10, 3, 34);
		//Supplementary object 183
		myObj = new GameObject("a_giant_rat_35_35_03_0183");
		pos = new Vector3(119.314285f, 2.400000f, 119.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"67","Sprites/OBJECTS_067", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_067", "Sprites/OBJECTS_067", "Sprites/OBJECTS_067", 0, 67, 0, 35, 15, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 35, 15, 0, 0, 15, 0, 0, 8, 1, 0, 0, 0, 0, "GroundMesh0");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		//Supplementary object 184
		myObj = new GameObject("a_mongbat_35_35_03_0184");
		pos = new Vector3(119.314285f, 3.300000f, 119.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"81","Sprites/OBJECTS_081", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_081", "Sprites/OBJECTS_081", "Sprites/OBJECTS_081", 0, 81, 0, 35, 55, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 35, 55, 0, 0, 22, 0, 0, 8, 1, 0, 0, 0, 0, "GroundMesh0");
		SetRotation(myObj,0,225,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		//Supplementary object 185
		myObj = new GameObject("a_bloodworm_30_30_03_0185");
		pos = new Vector3(119.314285f, 2.400000f, 119.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"82","Sprites/OBJECTS_082", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_082", "Sprites/OBJECTS_082", "Sprites/OBJECTS_082", 0, 82, 0, 30, 52, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 30, 52, 0, 0, 31, 0, 0, 8, 0, 0, 0, 0, 0, "GroundMesh0");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		//Supplementary object 186
		myObj = new GameObject("a_dread_spider_60_60_03_0186");
		pos = new Vector3(119.314285f, 2.400000f, 119.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"92","Sprites/OBJECTS_092", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_092", "Sprites/OBJECTS_092", "Sprites/OBJECTS_092", 0, 92, 0, 60, 24, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 60, 24, 0, 0, 42, 0, 0, 8, 0, 0, 0, 0, 0, "GroundMesh0");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		//Supplementary object 187
		myObj = new GameObject("a_headless_headlesses_61_61_03_0187");
		pos = new Vector3(119.314285f, 2.400000f, 119.314285f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"91","Sprites/OBJECTS_091", 0);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_091", "Sprites/OBJECTS_091", "Sprites/OBJECTS_091", 0, 91, 0, 61, 41, 0, 1, 0, 1, 0, 0, 0, 1);
		SetNPCProps(myObj, 0, 61, 41, 0, 0, 58, 0, 0, 8, 0, 0, 0, 0, 0, "GroundMesh11");
		SetRotation(myObj,0,0,0);
		////Container contents
		ParentContainer = CreateContainer(myObj, 255, 255, 255);
		//Supplementary object 503
		myObj= CreateGameObject("a_Sanct_stone_99_99_03_0503",119.314285f,0.000000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_224",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_224", "Sprites/OBJECTS_250", "Sprites/OBJECTS_250", 6, 250, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetObjectAsRuneStone(myObj);
		//Supplementary object 504
		myObj= CreateGameObject("an_An_stone_99_99_03_0504",119.314285f,0.000000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_224",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_224", "Sprites/OBJECTS_232", "Sprites/OBJECTS_232", 6, 232, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetObjectAsRuneStone(myObj);
		//Supplementary object 506
		myObj= CreateGameObject("an_oil_flask_99_99_03_0506",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_301",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_301", "Sprites/OBJECTS_301", "Sprites/OBJECTS_301", 89, 301, 3, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddOil(myObj);
		//Supplementary object 507
		myObj= CreateGameObject("a_mushroom_99_99_03_0507",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_184",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_184", "Sprites/OBJECTS_184", "Sprites/OBJECTS_184", 14, 184, 4, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddPotion(myObj);
		//Supplementary object 508
		myObj= CreateGameObject("a_red_potion_99_99_03_0508",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_187",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_187", "Sprites/OBJECTS_187", "Sprites/OBJECTS_187", 14, 187, 564, 40, 0, 1, 1, 0, 1, 1, 1, 12, 1);
		AddPotion(myObj);
		//Supplementary object 544
		myObj= CreateGameObject("a_key_013_1",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_268",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_268", "Sprites/OBJECTS_268", "Sprites/OBJECTS_268", 5, 268, 1, 40, 13, 1, 1, 0, 1, 1, 0, 0, 1);
		CreateKey(myObj, 13);
		//Supplementary object 545
		myObj= CreateGameObject("a_helmet_99_99_03_0545",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_046",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_046", "Sprites/OBJECTS_046", "Sprites/armour/armor_f_0014", 73, 46, 0, 63, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		CreateHelm(myObj, "Sprites/armour/armor_f_0014", "Sprites/armour/armor_m_0014", "Sprites/armour/armor_f_0029", "Sprites/armour/armor_m_0029", "Sprites/armour/armor_f_0044", "Sprites/armour/armor_m_0044", "Sprites/armour/armor_f_0059", "Sprites/armour/armor_m_0059", 2954796, 2954796);
		//Supplementary object 551
		myObj= CreateGameObject("an_ankh_pendant_99_99_03_0551",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_173",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_173", "Sprites/OBJECTS_173", "Sprites/OBJECTS_173", 18, 173, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		//Supplementary object 553
		myObj= CreateGameObject("a_jeweled_sword_99_99_03_0553",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_013",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_013", "Sprites/OBJECTS_013", "Sprites/OBJECTS_013", 1, 13, 714, 40, 0, 1, 1, 0, 1, 1, 1, 8, 1);
		CreateWeapon(myObj, 14, 7, 11, 3, 255);
		//Supplementary object 560
		myObj= CreateGameObject("a_lock_99_99_03_0560",119.314285f,0.562500f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_271",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_271", "Sprites/OBJECTS_271", "Sprites/OBJECTS_271", 21, 271, 512, 40, 0, 1, 1, 0, 1, 1, 0, 3, 1);
		AddObj_base(myObj);
		//Supplementary object 572
		myObj= CreateGameObject("a_lock_99_99_03_0572",119.314285f,0.525000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_271",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_271", "Sprites/OBJECTS_271", "Sprites/OBJECTS_271", 21, 271, 512, 40, 0, 1, 1, 0, 1, 1, 0, 3, 1);
		AddObj_base(myObj);
		//Supplementary object 573
		myObj= CreateGameObject("an_oil_flask_99_99_03_0573",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_301",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_301", "Sprites/OBJECTS_301", "Sprites/OBJECTS_301", 89, 301, 4, 40, 13, 1, 1, 0, 1, 1, 0, 0, 1);
		AddOil(myObj);
		//Supplementary object 575
		myObj= CreateGameObject("some_leeches_bunches_of_leeches_99_99_03_0575",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_293",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_293", "Sprites/OBJECTS_293", "Sprites/OBJECTS_293", 16, 293, 6, 40, 13, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		//Supplementary object 576
		myObj= CreateGameObject("a_torch_torches_99_99_03_0576",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_145",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_145", "Sprites/OBJECTS_145", "Sprites/OBJECTS_145", 22, 145, 8, 40, 13, 1, 1, 1, 1, 1, 0, 0, 1);
		CreateLight(myObj, 2, 3, 149, 145);
		//Supplementary object 578
		myObj= CreateGameObject("a_red_potion_99_99_03_0578",120.000000f,3.600000f,119.828575f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_187",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_187", "Sprites/OBJECTS_187", "Sprites/OBJECTS_187", 14, 187, 531, 40, 13, 1, 1, 0, 1, 1, 1, 12, 1);
		AddPotion(myObj);
		//Supplementary object 623
		myObj= CreateGameObject("a_red_gem_99_99_03_0623",119.314285f,3.000000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_163",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_163", "Sprites/OBJECTS_163", "Sprites/OBJECTS_163", 18, 163, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		//Supplementary object 626
		myObj= CreateGameObject("a_ruby_rubies_99_99_03_0626",119.314285f,3.000000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_162",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_162", "Sprites/OBJECTS_162", "Sprites/OBJECTS_162", 18, 162, 3, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		//Supplementary object 643
		myObj= CreateGameObject("a_coin_57_57_03_0643",119.314285f,3.000000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_160",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_160", "Sprites/OBJECTS_160", "Sprites/OBJECTS_160", 18, 160, 40, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		//Supplementary object 653
		myObj= CreateGameObject("dragon_scales_bunches_of_dragon_scales_99_99_03_0653",119.314285f,3.300000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_285",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_285", "Sprites/OBJECTS_285", "Sprites/OBJECTS_285", 16, 285, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		//Supplementary object 655
		myObj= CreateGameObject("a_Grav_stone_99_99_03_0655",119.314285f,3.000000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_224",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_224", "Sprites/OBJECTS_238", "Sprites/OBJECTS_238", 6, 238, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetObjectAsRuneStone(myObj);
		//Supplementary object 656
		myObj= CreateGameObject("a_Corp_stone_99_99_03_0656",119.314285f,3.000000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_224",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_224", "Sprites/OBJECTS_234", "Sprites/OBJECTS_234", 6, 234, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		SetObjectAsRuneStone(myObj);
		//Supplementary object 673
		myObj= CreateGameObject("an_An_stone_99_99_03_0673",119.314285f,1.500000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_224",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_224", "Sprites/OBJECTS_232", "Sprites/OBJECTS_232", 6, 232, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetObjectAsRuneStone(myObj);
		//Supplementary object 674
		myObj= CreateGameObject("an_In_stone_99_99_03_0674",119.314285f,1.500000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_224",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_224", "Sprites/OBJECTS_240", "Sprites/OBJECTS_240", 6, 240, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		SetObjectAsRuneStone(myObj);
		//Supplementary object 675
		myObj= CreateGameObject("a_lockpick_99_99_03_0675",119.314285f,1.500000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_257",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_257", "Sprites/OBJECTS_257", "Sprites/OBJECTS_257", 79, 257, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddLockpick(myObj);
		//Supplementary object 676
		myObj= CreateGameObject("a_Quas_stone_99_99_03_0676",119.314285f,1.500000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_224",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_224", "Sprites/OBJECTS_248", "Sprites/OBJECTS_248", 6, 248, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		SetObjectAsRuneStone(myObj);
		//Supplementary object 699
		myObj= CreateGameObject("a_scroll_99_99_03_0699",119.314285f,3.300000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_314",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_314", "Sprites/OBJECTS_314", "Sprites/OBJECTS_314", 13, 314, 619, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetReadable(myObj);
		SetLink(myObj,619);
		//Supplementary object 703
		myObj= CreateGameObject("a_coin_99_99_03_0703",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_160",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_160", "Sprites/OBJECTS_160", "Sprites/OBJECTS_160", 18, 160, 37, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		//Supplementary object 726
		myObj= CreateGameObject("a_fishing_pole_99_99_03_0726",119.314285f,2.700000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_299",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_299", "Sprites/OBJECTS_299", "Sprites/OBJECTS_299", 92, 299, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddFishingPole(myObj);
		//Supplementary object 745
		myObj= CreateGameObject("a_standard_99_99_03_0745",118.971428f,3.600000f,119.485710f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_287",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_287", "Sprites/OBJECTS_287", "Sprites/OBJECTS_287", 16, 287, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		//Supplementary object 782
		myObj= CreateGameObject("a_bottle_of_ale_bottles_of_ale_99_99_03_0782",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_186",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_186", "Sprites/OBJECTS_186", "Sprites/OBJECTS_186", 14, 186, 3, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddPotion(myObj);
		//Supplementary object 784
		myObj= CreateGameObject("a_mandolin_99_99_03_0784",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_291",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_291", "Sprites/OBJECTS_291", "Sprites/OBJECTS_291", 26, 291, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddInstrument(myObj);
		//Supplementary object 791
		myObj= CreateGameObject("a_bottle_of_water_bottles_of_water_99_99_03_0791",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_189",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_189", "Sprites/OBJECTS_189", "Sprites/OBJECTS_189", 24, 189, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		SetFood(myObj);
		//Supplementary object 794
		myObj= CreateGameObject("a_gold_coin_99_99_03_0794",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_161",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", "Sprites/OBJECTS_161", 18, 161, 2, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		//Supplementary object 796
		myObj= CreateGameObject("some_leeches_bunches_of_leeches_99_99_03_0796",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_293",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_293", "Sprites/OBJECTS_293", "Sprites/OBJECTS_293", 16, 293, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		//Supplementary object 797
		myObj= CreateGameObject("a_rock_hammer_99_99_03_0797",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_296",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_296", "Sprites/OBJECTS_296", "Sprites/OBJECTS_296", 16, 296, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddObj_base(myObj);
		//Supplementary object 812
		myObj= CreateGameObject("a_mushroom_99_99_03_0812",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_184",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_184", "Sprites/OBJECTS_184", "Sprites/OBJECTS_184", 14, 184, 2, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddPotion(myObj);
		//Supplementary object 828
		myObj= CreateGameObject("a_green_potion_99_99_03_0828",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_188",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_188", "Sprites/OBJECTS_188", "Sprites/OBJECTS_188", 14, 188, 541, 40, 0, 1, 1, 0, 1, 1, 1, 12, 1);
		AddPotion(myObj);
		//Supplementary object 832
		myObj= CreateGameObject("a_lock_99_99_03_0832",119.314285f,0.337500f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_271",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_271", "Sprites/OBJECTS_271", "Sprites/OBJECTS_271", 21, 271, 512, 40, 0, 1, 1, 0, 1, 1, 0, 1, 1);
		AddObj_base(myObj);
		//Supplementary object 845
		myObj= CreateGameObject("a_flask_of_port_flasks_of_port_99_99_03_0845",119.314285f,2.400000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_190",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_190", "Sprites/OBJECTS_190", "Sprites/OBJECTS_190", 24, 190, 1, 40, 27, 1, 1, 0, 1, 1, 0, 0, 1);
		SetFood(myObj);
		//Supplementary object 847
		myObj= CreateGameObject("a_torch_torches_99_99_03_0847",119.314285f,2.400000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_145",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_145", "Sprites/OBJECTS_145", "Sprites/OBJECTS_145", 22, 145, 2, 40, 27, 1, 1, 1, 1, 1, 0, 0, 1);
		CreateLight(myObj, 2, 3, 149, 145);
		//Supplementary object 850
		myObj= CreateGameObject("some_leeches_bunches_of_leeches_99_99_03_0850",119.314285f,2.400000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_293",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_293", "Sprites/OBJECTS_293", "Sprites/OBJECTS_293", 16, 293, 2, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		//Supplementary object 854
		myObj= CreateGameObject("a_mail_shirt_99_99_03_0854",119.314285f,3.600000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_033",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_033", "Sprites/OBJECTS_033", "Sprites/armour/armor_f_0001", 2, 33, 705, 40, 0, 1, 1, 0, 1, 1, 1, 8, 1);
		CreateArmour(myObj, "Sprites/armour/armor_f_0001", "Sprites/armour/armor_m_0001", "Sprites/armour/armor_f_0016", "Sprites/armour/armor_m_0016", "Sprites/armour/armor_f_0031", "Sprites/armour/armor_m_0031", "Sprites/armour/armor_f_0046", "Sprites/armour/armor_m_0046", 4, 22);
		//Supplementary object 855
		myObj= CreateGameObject("an_ear_of_corn_ears_of_corn_99_99_03_0855",119.314285f,2.400000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_180",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_180", "Sprites/OBJECTS_180", "Sprites/OBJECTS_180", 24, 180, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		SetFood(myObj);
		//Supplementary object 865
		myObj= CreateGameObject("a_coin_99_99_03_0865",119.314285f,3.000000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_160",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_160", "Sprites/OBJECTS_160", "Sprites/OBJECTS_160", 18, 160, 42, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		AddObj_base(myObj);
		//Supplementary object 866
		myObj= CreateGameObject("a_wand_99_99_03_0866",119.314285f,3.000000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_153",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_153", "Sprites/OBJECTS_153", "Sprites/OBJECTS_153", 12, 153, 864, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddWand(myObj, 514, 12);
		//Supplementary object 876
		myObj= CreateGameObject("a_scroll_99_99_03_0876",119.314285f,2.400000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_314",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_314", "Sprites/OBJECTS_314", "Sprites/OBJECTS_314", 13, 314, 618, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		SetReadable(myObj);
		SetLink(myObj,618);
		//Supplementary object 877
		myObj= CreateGameObject("a_lockpick_99_99_03_0877",119.314285f,2.400000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_257",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_257", "Sprites/OBJECTS_257", "Sprites/OBJECTS_257", 79, 257, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		AddLockpick(myObj);
		//Supplementary object 937
		myObj= CreateGameObject("a_piece_of_cheese_pieces_of_cheese_99_99_03_0937",119.314285f,2.400000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_178",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_178", "Sprites/OBJECTS_178", "Sprites/OBJECTS_178", 24, 178, 0, 40, 0, 1, 1, 0, 1, 0, 0, 0, 1);
		SetFood(myObj);
		//Supplementary object 938
		myObj= CreateGameObject("a_candle_99_99_03_0938",119.314285f,2.400000f,119.314285f);
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_146",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_146", "Sprites/OBJECTS_146", "Sprites/OBJECTS_146", 22, 146, 0, 40, 0, 1, 1, 1, 1, 0, 0, 0, 1);
		CreateLight(myObj, 1, 12, 150, 146);		



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
		SetTileTag(3,62,"SOLIDWALL",1);SetTileTag(7,62,"SOLIDWALL",1);SetTileTag(13,62,"SOLIDWALL",1);SetTileTag(17,62,"SOLIDWALL",1);SetTileTag(22,62,"SOLIDWALL",1);SetTileTag(27,62,"SOLIDWALL",1);SetTileTag(28,62,"SOLIDWALL",1);SetTileTag(29,62,"SOLIDWALL",1);SetTileTag(30,62,"SOLIDWALL",1);SetTileTag(31,62,"SOLIDWALL",1);SetTileTag(32,62,"SOLIDWALL",1);SetTileTag(37,62,"SOLIDWALL",1);SetTileTag(38,62,"SOLIDWALL",1);SetTileTag(46,62,"SOLIDWALL",1);SetTileTag(59,62,"SOLIDWALL",1);
		SetTileTag(4,61,"LAND_2", 1);SetTileTag(8,61,"LAND_2", 1);SetTileTag(15,61,"SOLIDWALL",1);SetTileTag(16,61,"SOLIDWALL",1);SetTileTag(17,61,"LAND_1", 1);SetTileTag(18,61,"SOLIDWALL",1);SetTileTag(19,61,"SOLIDWALL",1);SetTileTag(20,61,"SOLIDWALL",1);SetTileTag(22,61,"LAND_1", 1);SetTileTag(23,61,"LAND_1", 1);SetTileTag(24,61,"LAND_1", 1);SetTileTag(25,61,"LAND_1", 1);SetTileTag(27,61,"LAND_1", 1);SetTileTag(28,61,"LAND_1", 1);SetTileTag(29,61,"LAND_1", 1);SetTileTag(30,61,"LAND_1", 1);SetTileTag(35,61,"LAND_1", 1);SetTileTag(36,61,"LAND_1", 1);SetTileTag(37,61,"LAND_1", 1);SetTileTag(38,61,"LAND_1", 1);SetTileTag(45,61,"SOLIDWALL",1);SetTileTag(46,61,"LAND_1", 1);SetTileTag(47,61,"LAND_1", 1);SetTileTag(48,61,"LAND_1", 1);SetTileTag(49,61,"LAND_1", 1);SetTileTag(50,61,"LAND_1", 1);SetTileTag(51,61,"SOLIDWALL",1);SetTileTag(60,61,"LAND_11", 1);
		SetTileTag(7,60,"LAND_2", 1);SetTileTag(9,60,"LAND_2", 1);SetTileTag(12,60,"SOLIDWALL",1);SetTileTag(13,60,"LAND_1", 1);SetTileTag(14,60,"LAND_1", 1);SetTileTag(15,60,"SOLIDWALL",1);SetTileTag(16,60,"LAND_1", 1);SetTileTag(17,60,"LAND_1", 1);SetTileTag(18,60,"LAND_1", 1);SetTileTag(19,60,"LAND_1", 1);SetTileTag(20,60,"LAND_1", 1);SetTileTag(21,60,"LAND_1", 1);SetTileTag(22,60,"LAND_1", 1);SetTileTag(23,60,"LAND_1", 1);SetTileTag(25,60,"LAND_1", 1);SetTileTag(26,60,"SOLIDWALL",1);SetTileTag(27,60,"SOLIDWALL",1);SetTileTag(28,60,"SOLIDWALL",1);SetTileTag(29,60,"SOLIDWALL",1);SetTileTag(30,60,"SOLIDWALL",1);SetTileTag(31,60,"LAND_1", 1);SetTileTag(32,60,"LAND_1", 1);SetTileTag(33,60,"LAND_1", 1);SetTileTag(34,60,"SOLIDWALL",1);SetTileTag(35,60,"SOLIDWALL",1);SetTileTag(36,60,"SOLIDWALL",1);SetTileTag(37,60,"SOLIDWALL",1);SetTileTag(38,60,"SOLIDWALL",1);SetTileTag(42,60,"SOLIDWALL",1);SetTileTag(45,60,"SOLIDWALL",1);SetTileTag(46,60,"LAND_1", 1);SetTileTag(47,60,"SOLIDWALL",1);SetTileTag(48,60,"LAND_1", 1);SetTileTag(49,60,"LAND_1", 1);SetTileTag(51,60,"SOLIDWALL",1);SetTileTag(55,60,"SOLIDWALL",1);SetTileTag(56,60,"SOLIDWALL",1);SetTileTag(58,60,"SOLIDWALL",1);
		SetTileTag(5,59,"LAND_2", 1);SetTileTag(8,59,"SOLIDWALL",1);SetTileTag(9,59,"LAND_2", 1);SetTileTag(13,59,"SOLIDWALL",1);SetTileTag(14,59,"LAND_1", 1);SetTileTag(15,59,"LAND_1", 1);SetTileTag(17,59,"LAND_1", 1);SetTileTag(18,59,"LAND_1", 1);SetTileTag(20,59,"LAND_1", 1);SetTileTag(21,59,"LAND_1", 1);SetTileTag(22,59,"SOLIDWALL",1);SetTileTag(23,59,"LAND_1", 1);SetTileTag(24,59,"LAND_1", 1);SetTileTag(25,59,"SOLIDWALL",1);SetTileTag(27,59,"SOLIDWALL",1);SetTileTag(28,59,"SOLIDWALL",1);SetTileTag(29,59,"SOLIDWALL",1);SetTileTag(30,59,"SOLIDWALL",1);SetTileTag(31,59,"LAND_1", 1);SetTileTag(32,59,"LAND_1", 1);SetTileTag(33,59,"LAND_1", 1);SetTileTag(34,59,"SOLIDWALL",1);SetTileTag(35,59,"SOLIDWALL",1);SetTileTag(36,59,"SOLIDWALL",1);SetTileTag(37,59,"SOLIDWALL",1);SetTileTag(45,59,"LAND_1", 1);SetTileTag(46,59,"LAND_1", 1);SetTileTag(47,59,"SOLIDWALL",1);SetTileTag(48,59,"LAND_1", 1);SetTileTag(49,59,"LAND_1", 1);SetTileTag(50,59,"SOLIDWALL",1);SetTileTag(54,59,"SOLIDWALL",1);SetTileTag(55,59,"LAND_11", 1);
		SetTileTag(4,58,"SOLIDWALL",1);SetTileTag(5,58,"SOLIDWALL",1);SetTileTag(6,58,"SOLIDWALL",1);SetTileTag(7,58,"SOLIDWALL",1);SetTileTag(8,58,"SOLIDWALL",1);SetTileTag(14,58,"SOLIDWALL",1);SetTileTag(15,58,"LAND_1", 1);SetTileTag(16,58,"LAND_1", 1);SetTileTag(17,58,"LAND_1", 1);SetTileTag(18,58,"SOLIDWALL",1);SetTileTag(19,58,"LAND_1", 1);SetTileTag(20,58,"LAND_1", 1);SetTileTag(21,58,"LAND_1", 1);SetTileTag(22,58,"SOLIDWALL",1);SetTileTag(23,58,"SOLIDWALL",1);SetTileTag(24,58,"SOLIDWALL",1);SetTileTag(26,58,"SOLIDWALL",1);SetTileTag(27,58,"LAND_1", 1);SetTileTag(28,58,"LAND_1", 1);SetTileTag(37,58,"LAND_1", 1);SetTileTag(38,58,"SOLIDWALL",1);SetTileTag(45,58,"LAND_1", 1);SetTileTag(47,58,"SOLIDWALL",1);SetTileTag(48,58,"SOLIDWALL",1);SetTileTag(55,58,"SOLIDWALL",1);SetTileTag(56,58,"SOLIDWALL",1);SetTileTag(58,58,"SOLIDWALL",1);SetTileTag(59,58,"LAND_11", 1);SetTileTag(62,58,"SOLIDWALL",1);
		SetTileTag(4,57,"SOLIDWALL",1);SetTileTag(5,57,"SOLIDWALL",1);SetTileTag(8,57,"LAND_2", 1);SetTileTag(9,57,"LAND_2", 1);SetTileTag(10,57,"SOLIDWALL",1);SetTileTag(13,57,"SOLIDWALL",1);SetTileTag(14,57,"LAND_1", 1);SetTileTag(16,57,"LAND_1", 1);SetTileTag(19,57,"SOLIDWALL",1);SetTileTag(20,57,"LAND_1", 1);SetTileTag(21,57,"LAND_1", 1);SetTileTag(22,57,"LAND_1", 1);SetTileTag(23,57,"SOLIDWALL",1);SetTileTag(24,57,"SOLIDWALL",1);SetTileTag(25,57,"SOLIDWALL",1);SetTileTag(26,57,"SOLIDWALL",1);SetTileTag(27,57,"LAND_1", 1);SetTileTag(29,57,"SOLIDWALL",1);SetTileTag(30,57,"SOLIDWALL",1);SetTileTag(31,57,"LAND_1", 1);SetTileTag(32,57,"LAND_1", 1);SetTileTag(33,57,"LAND_1", 1);SetTileTag(34,57,"SOLIDWALL",1);SetTileTag(35,57,"SOLIDWALL",1);SetTileTag(36,57,"LAND_1", 1);SetTileTag(38,57,"SOLIDWALL",1);SetTileTag(39,57,"SOLIDWALL",1);SetTileTag(45,57,"SOLIDWALL",1);SetTileTag(46,57,"SOLIDWALL",1);SetTileTag(47,57,"SOLIDWALL",1);SetTileTag(54,57,"SOLIDWALL",1);SetTileTag(55,57,"SOLIDWALL",1);SetTileTag(56,57,"SOLIDWALL",1);SetTileTag(57,57,"SOLIDWALL",1);SetTileTag(59,57,"SOLIDWALL",1);SetTileTag(60,57,"SOLIDWALL",1);SetTileTag(62,57,"SOLIDWALL",1);
		SetTileTag(4,56,"LAND_2", 1);SetTileTag(5,56,"LAND_2", 1);SetTileTag(8,56,"LAND_2", 1);SetTileTag(9,56,"SOLIDWALL",1);SetTileTag(12,56,"SOLIDWALL",1);SetTileTag(13,56,"LAND_1", 1);SetTileTag(14,56,"LAND_1", 1);SetTileTag(15,56,"LAND_1", 1);SetTileTag(16,56,"LAND_1", 1);SetTileTag(19,56,"SOLIDWALL",1);SetTileTag(20,56,"LAND_1", 1);SetTileTag(21,56,"LAND_1", 1);SetTileTag(22,56,"LAND_1", 1);SetTileTag(23,56,"SOLIDWALL",1);SetTileTag(25,56,"LAND_1", 1);SetTileTag(26,56,"LAND_1", 1);SetTileTag(27,56,"LAND_1", 1);SetTileTag(28,56,"LAND_1", 1);SetTileTag(29,56,"LAND_1", 1);SetTileTag(30,56,"LAND_1", 1);SetTileTag(31,56,"LAND_1", 1);SetTileTag(32,56,"LAND_1", 1);SetTileTag(33,56,"LAND_1", 1);SetTileTag(34,56,"LAND_1", 1);SetTileTag(35,56,"LAND_1", 1);SetTileTag(36,56,"LAND_1", 1);SetTileTag(37,56,"LAND_1", 1);SetTileTag(38,56,"LAND_1", 1);SetTileTag(39,56,"LAND_1", 1);SetTileTag(41,56,"SOLIDWALL",1);SetTileTag(44,56,"LAND_1", 1);SetTileTag(46,56,"LAND_1", 1);SetTileTag(48,56,"WATER_3", 1);SetTileTag(58,56,"SOLIDWALL",1);SetTileTag(59,56,"SOLIDWALL",1);SetTileTag(60,56,"SOLIDWALL",1);SetTileTag(62,56,"SOLIDWALL",1);
		SetTileTag(4,55,"LAND_2", 1);SetTileTag(5,55,"LAND_2", 1);SetTileTag(8,55,"LAND_2", 1);SetTileTag(9,55,"SOLIDWALL",1);SetTileTag(11,55,"SOLIDWALL",1);SetTileTag(12,55,"LAND_1", 1);SetTileTag(13,55,"LAND_1", 1);SetTileTag(14,55,"LAND_1", 1);SetTileTag(16,55,"SOLIDWALL",1);SetTileTag(17,55,"SOLIDWALL",1);SetTileTag(18,55,"SOLIDWALL",1);SetTileTag(19,55,"LAND_1", 1);SetTileTag(20,55,"LAND_1", 1);SetTileTag(22,55,"LAND_1", 1);SetTileTag(25,55,"LAND_1", 1);SetTileTag(26,55,"LAND_1", 1);SetTileTag(29,55,"LAND_1", 1);SetTileTag(30,55,"LAND_1", 1);SetTileTag(32,55,"LAND_1", 1);SetTileTag(34,55,"LAND_1", 1);SetTileTag(35,55,"LAND_1", 1);SetTileTag(38,55,"LAND_1", 1);SetTileTag(39,55,"LAND_1", 1);SetTileTag(41,55,"SOLIDWALL",1);SetTileTag(43,55,"SOLIDWALL",1);SetTileTag(44,55,"LAND_1", 1);SetTileTag(46,55,"LAND_1", 1);SetTileTag(48,55,"LAND_9", 1);SetTileTag(49,55,"LAND_9", 1);SetTileTag(50,55,"LAND_9", 1);SetTileTag(51,55,"LAND_9", 1);SetTileTag(52,55,"LAND_9", 1);SetTileTag(53,55,"LAND_9", 1);SetTileTag(54,55,"LAND_9", 1);SetTileTag(55,55,"LAND_9", 1);SetTileTag(57,55,"LAND_11", 1);SetTileTag(58,55,"LAND_11", 1);SetTileTag(61,55,"LAND_11", 1);SetTileTag(62,55,"SOLIDWALL",1);
		SetTileTag(4,54,"SOLIDWALL",1);SetTileTag(5,54,"SOLIDWALL",1);SetTileTag(6,54,"LAND_2", 1);SetTileTag(7,54,"LAND_2", 1);SetTileTag(8,54,"LAND_2", 1);SetTileTag(10,54,"SOLIDWALL",1);SetTileTag(11,54,"LAND_1", 1);SetTileTag(13,54,"LAND_1", 1);SetTileTag(15,54,"SOLIDWALL",1);SetTileTag(16,54,"SOLIDWALL",1);SetTileTag(17,54,"LAND_1", 1);SetTileTag(18,54,"LAND_1", 1);SetTileTag(19,54,"LAND_1", 1);SetTileTag(20,54,"LAND_1", 1);SetTileTag(21,54,"LAND_1", 1);SetTileTag(22,54,"SOLIDWALL",1);SetTileTag(23,54,"SOLIDWALL",1);SetTileTag(25,54,"LAND_1", 1);SetTileTag(26,54,"LAND_1", 1);SetTileTag(38,54,"LAND_1", 1);SetTileTag(39,54,"LAND_1", 1);SetTileTag(41,54,"SOLIDWALL",1);SetTileTag(44,54,"LAND_1", 1);SetTileTag(45,54,"SOLIDWALL",1);SetTileTag(46,54,"LAND_1", 1);SetTileTag(48,54,"LAND_9", 1);SetTileTag(49,54,"LAND_9", 1);SetTileTag(50,54,"LAND_9", 1);SetTileTag(51,54,"LAND_9", 1);SetTileTag(52,54,"LAND_9", 1);SetTileTag(53,54,"LAND_9", 1);SetTileTag(54,54,"LAND_9", 1);SetTileTag(55,54,"LAND_9", 1);SetTileTag(58,54,"SOLIDWALL",1);SetTileTag(59,54,"SOLIDWALL",1);SetTileTag(60,54,"SOLIDWALL",1);SetTileTag(61,54,"SOLIDWALL",1);
		SetTileTag(6,53,"SOLIDWALL",1);SetTileTag(8,53,"SOLIDWALL",1);SetTileTag(9,53,"LAND_2", 1);SetTileTag(10,53,"SOLIDWALL",1);SetTileTag(11,53,"LAND_1", 1);SetTileTag(13,53,"LAND_1", 1);SetTileTag(14,53,"SOLIDWALL",1);SetTileTag(15,53,"LAND_1", 1);SetTileTag(16,53,"LAND_1", 1);SetTileTag(17,53,"LAND_1", 1);SetTileTag(18,53,"LAND_1", 1);SetTileTag(19,53,"LAND_1", 1);SetTileTag(20,53,"LAND_1", 1);SetTileTag(21,53,"LAND_1", 1);SetTileTag(22,53,"LAND_1", 1);SetTileTag(23,53,"SOLIDWALL",1);SetTileTag(25,53,"LAND_1", 1);SetTileTag(26,53,"LAND_1", 1);SetTileTag(27,53,"LAND_1", 1);SetTileTag(28,53,"LAND_1", 1);SetTileTag(31,53,"LAND_1", 1);SetTileTag(33,53,"LAND_1", 1);SetTileTag(34,53,"LAND_1", 1);SetTileTag(38,53,"LAND_1", 1);SetTileTag(39,53,"LAND_1", 1);SetTileTag(41,53,"SOLIDWALL",1);SetTileTag(43,53,"SOLIDWALL",1);SetTileTag(44,53,"LAND_1", 1);SetTileTag(45,53,"SOLIDWALL",1);SetTileTag(46,53,"LAND_1", 1);SetTileTag(48,53,"LAND_9", 1);SetTileTag(49,53,"LAND_9", 1);SetTileTag(50,53,"LAND_9", 1);SetTileTag(51,53,"LAND_9", 1);SetTileTag(52,53,"LAND_9", 1);SetTileTag(53,53,"LAND_9", 1);SetTileTag(54,53,"LAND_9", 1);SetTileTag(55,53,"LAND_9", 1);
		SetTileTag(3,52,"LAND_2", 1);SetTileTag(7,52,"SOLIDWALL",1);SetTileTag(9,52,"LAND_2", 1);SetTileTag(11,52,"LAND_1", 1);SetTileTag(12,52,"LAND_1", 1);SetTileTag(13,52,"LAND_1", 1);SetTileTag(16,52,"LAND_1", 1);SetTileTag(17,52,"LAND_1", 1);SetTileTag(18,52,"SOLIDWALL",1);SetTileTag(19,52,"SOLIDWALL",1);SetTileTag(20,52,"LAND_1", 1);SetTileTag(21,52,"LAND_1", 1);SetTileTag(22,52,"LAND_1", 1);SetTileTag(23,52,"SOLIDWALL",1);SetTileTag(25,52,"LAND_1", 1);SetTileTag(26,52,"LAND_1", 1);SetTileTag(31,52,"LAND_1", 1);SetTileTag(33,52,"LAND_1", 1);SetTileTag(37,52,"LAND_1", 1);SetTileTag(38,52,"LAND_1", 1);SetTileTag(39,52,"LAND_1", 1);SetTileTag(41,52,"SOLIDWALL",1);SetTileTag(45,52,"LAND_1", 1);SetTileTag(48,52,"LAND_9", 1);SetTileTag(49,52,"LAND_9", 1);SetTileTag(50,52,"LAND_9", 1);SetTileTag(51,52,"LAND_9", 1);SetTileTag(52,52,"LAND_9", 1);SetTileTag(53,52,"LAND_9", 1);SetTileTag(54,52,"LAND_9", 1);SetTileTag(55,52,"LAND_9", 1);
		SetTileTag(2,51,"SOLIDWALL",1);SetTileTag(3,51,"LAND_2", 1);SetTileTag(4,51,"SOLIDWALL",1);SetTileTag(5,51,"SOLIDWALL",1);SetTileTag(8,51,"SOLIDWALL",1);SetTileTag(10,51,"SOLIDWALL",1);SetTileTag(11,51,"LAND_1", 1);SetTileTag(12,51,"LAND_1", 1);SetTileTag(13,51,"LAND_1", 1);SetTileTag(14,51,"LAND_1", 1);SetTileTag(15,51,"LAND_1", 1);SetTileTag(16,51,"SOLIDWALL",1);SetTileTag(18,51,"SOLIDWALL",1);SetTileTag(19,51,"SOLIDWALL",1);SetTileTag(20,51,"SOLIDWALL",1);SetTileTag(21,51,"LAND_1", 1);SetTileTag(22,51,"LAND_1", 1);SetTileTag(23,51,"SOLIDWALL",1);SetTileTag(24,51,"LAND_1", 1);SetTileTag(25,51,"LAND_1", 1);SetTileTag(26,51,"LAND_1", 1);SetTileTag(32,51,"LAND_1", 1);SetTileTag(38,51,"LAND_1", 1);SetTileTag(39,51,"LAND_1", 1);SetTileTag(40,51,"LAND_1", 1);SetTileTag(41,51,"SOLIDWALL",1);SetTileTag(43,51,"SOLIDWALL",1);SetTileTag(44,51,"LAND_1", 1);SetTileTag(45,51,"LAND_1", 1);SetTileTag(46,51,"LAND_1", 1);SetTileTag(48,51,"LAND_9", 1);SetTileTag(49,51,"LAND_9", 1);SetTileTag(50,51,"LAND_9", 1);SetTileTag(51,51,"LAND_9", 1);SetTileTag(52,51,"LAND_9", 1);SetTileTag(53,51,"LAND_9", 1);SetTileTag(54,51,"LAND_9", 1);SetTileTag(55,51,"LAND_9", 1);
		SetTileTag(7,50,"LAND_2", 1);SetTileTag(8,50,"LAND_2", 1);SetTileTag(9,50,"LAND_2", 1);SetTileTag(10,50,"SOLIDWALL",1);SetTileTag(11,50,"SOLIDWALL",1);SetTileTag(13,50,"SOLIDWALL",1);SetTileTag(14,50,"LAND_1", 1);SetTileTag(15,50,"LAND_1", 1);SetTileTag(16,50,"LAND_1", 1);SetTileTag(17,50,"LAND_1", 1);SetTileTag(18,50,"LAND_1", 1);SetTileTag(19,50,"LAND_1", 1);SetTileTag(20,50,"LAND_1", 1);SetTileTag(21,50,"LAND_1", 1);SetTileTag(22,50,"SOLIDWALL",1);SetTileTag(23,50,"SOLIDWALL",1);SetTileTag(24,50,"LAND_1", 1);SetTileTag(25,50,"LAND_1", 1);SetTileTag(26,50,"LAND_1", 1);SetTileTag(27,50,"LAND_1", 1);SetTileTag(28,50,"LAND_1", 1);SetTileTag(29,50,"LAND_1", 1);SetTileTag(30,50,"LAND_1", 1);SetTileTag(31,50,"LAND_1", 1);SetTileTag(32,50,"LAND_1", 1);SetTileTag(33,50,"LAND_1", 1);SetTileTag(34,50,"LAND_1", 1);SetTileTag(35,50,"LAND_1", 1);SetTileTag(36,50,"LAND_1", 1);SetTileTag(37,50,"LAND_1", 1);SetTileTag(38,50,"LAND_1", 1);SetTileTag(39,50,"LAND_1", 1);SetTileTag(40,50,"LAND_1", 1);SetTileTag(41,50,"SOLIDWALL",1);SetTileTag(44,50,"SOLIDWALL",1);SetTileTag(45,50,"SOLIDWALL",1);SetTileTag(46,50,"LAND_1", 1);SetTileTag(48,50,"LAND_9", 1);SetTileTag(49,50,"LAND_9", 1);SetTileTag(50,50,"LAND_9", 1);SetTileTag(51,50,"LAND_9", 1);SetTileTag(52,50,"LAND_9", 1);SetTileTag(53,50,"LAND_9", 1);SetTileTag(54,50,"LAND_9", 1);SetTileTag(55,50,"LAND_9", 1);
		SetTileTag(9,49,"SOLIDWALL",1);SetTileTag(13,49,"SOLIDWALL",1);SetTileTag(14,49,"SOLIDWALL",1);SetTileTag(15,49,"LAND_1", 1);SetTileTag(16,49,"LAND_1", 1);SetTileTag(17,49,"LAND_1", 1);SetTileTag(19,49,"LAND_1", 1);SetTileTag(20,49,"LAND_1", 1);SetTileTag(21,49,"LAND_1", 1);SetTileTag(22,49,"SOLIDWALL",1);SetTileTag(23,49,"LAND_1", 1);SetTileTag(24,49,"LAND_1", 1);SetTileTag(25,49,"LAND_1", 1);SetTileTag(26,49,"LAND_1", 1);SetTileTag(27,49,"LAND_1", 1);SetTileTag(28,49,"LAND_1", 1);SetTileTag(29,49,"LAND_1", 1);SetTileTag(30,49,"LAND_1", 1);SetTileTag(31,49,"LAND_1", 1);SetTileTag(33,49,"LAND_1", 1);SetTileTag(34,49,"LAND_1", 1);SetTileTag(35,49,"LAND_1", 1);SetTileTag(36,49,"LAND_1", 1);SetTileTag(37,49,"LAND_1", 1);SetTileTag(38,49,"LAND_1", 1);SetTileTag(39,49,"LAND_1", 1);SetTileTag(40,49,"LAND_1", 1);SetTileTag(41,49,"LAND_1", 1);SetTileTag(42,49,"SOLIDWALL",1);SetTileTag(45,49,"SOLIDWALL",1);SetTileTag(46,49,"LAND_1", 1);SetTileTag(48,49,"LAND_9", 1);SetTileTag(49,49,"LAND_9", 1);SetTileTag(50,49,"LAND_9", 1);SetTileTag(51,49,"LAND_9", 1);SetTileTag(52,49,"LAND_9", 1);SetTileTag(53,49,"LAND_9", 1);SetTileTag(54,49,"LAND_9", 1);SetTileTag(55,49,"LAND_9", 1);SetTileTag(58,49,"SOLIDWALL",1);SetTileTag(59,49,"SOLIDWALL",1);SetTileTag(60,49,"SOLIDWALL",1);SetTileTag(61,49,"SOLIDWALL",1);
		SetTileTag(1,48,"SOLIDWALL",1);SetTileTag(2,48,"LAND_2", 1);SetTileTag(4,48,"LAND_2", 1);SetTileTag(5,48,"LAND_2", 1);SetTileTag(7,48,"SOLIDWALL",1);SetTileTag(8,48,"SOLIDWALL",1);SetTileTag(14,48,"SOLIDWALL",1);SetTileTag(16,48,"SOLIDWALL",1);SetTileTag(17,48,"LAND_1", 1);SetTileTag(18,48,"LAND_1", 1);SetTileTag(19,48,"SOLIDWALL",1);SetTileTag(20,48,"LAND_1", 1);SetTileTag(21,48,"SOLIDWALL",1);SetTileTag(22,48,"LAND_1", 1);SetTileTag(23,48,"LAND_1", 1);SetTileTag(24,48,"LAND_1", 1);SetTileTag(25,48,"SOLIDWALL",1);SetTileTag(26,48,"SOLIDWALL",1);SetTileTag(27,48,"SOLIDWALL",1);SetTileTag(28,48,"SOLIDWALL",1);SetTileTag(29,48,"SOLIDWALL",1);SetTileTag(30,48,"SOLIDWALL",1);SetTileTag(31,48,"SOLIDWALL",1);SetTileTag(33,48,"SOLIDWALL",1);SetTileTag(34,48,"SOLIDWALL",1);SetTileTag(36,48,"SOLIDWALL",1);SetTileTag(37,48,"SOLIDWALL",1);SetTileTag(39,48,"SOLIDWALL",1);SetTileTag(40,48,"LAND_1", 1);SetTileTag(41,48,"LAND_1", 1);SetTileTag(42,48,"LAND_1", 1);SetTileTag(43,48,"SOLIDWALL",1);SetTileTag(45,48,"SOLIDWALL",1);SetTileTag(46,48,"LAND_1", 1);SetTileTag(48,48,"LAND_9", 1);SetTileTag(49,48,"LAND_9", 1);SetTileTag(50,48,"LAND_9", 1);SetTileTag(51,48,"LAND_9", 1);SetTileTag(52,48,"LAND_9", 1);SetTileTag(53,48,"LAND_9", 1);SetTileTag(54,48,"LAND_9", 1);SetTileTag(55,48,"LAND_9", 1);SetTileTag(58,48,"LAND_10", 1);
		SetTileTag(2,47,"SOLIDWALL",1);SetTileTag(4,47,"SOLIDWALL",1);SetTileTag(6,47,"SOLIDWALL",1);SetTileTag(11,47,"SOLIDWALL",1);SetTileTag(12,47,"LAND_1", 1);SetTileTag(13,47,"LAND_1", 1);SetTileTag(14,47,"SOLIDWALL",1);SetTileTag(15,47,"SOLIDWALL",1);SetTileTag(16,47,"SOLIDWALL",1);SetTileTag(17,47,"SOLIDWALL",1);SetTileTag(18,47,"SOLIDWALL",1);SetTileTag(19,47,"SOLIDWALL",1);SetTileTag(20,47,"SOLIDWALL",1);SetTileTag(21,47,"LAND_1", 1);SetTileTag(22,47,"LAND_1", 1);SetTileTag(23,47,"LAND_1", 1);SetTileTag(25,47,"SOLIDWALL",1);SetTileTag(28,47,"SOLIDWALL",1);SetTileTag(29,47,"LAND_1", 1);SetTileTag(31,47,"LAND_1", 1);SetTileTag(32,47,"LAND_1", 1);SetTileTag(33,47,"LAND_1", 1);SetTileTag(34,47,"LAND_1", 1);SetTileTag(36,47,"SOLIDWALL",1);SetTileTag(37,47,"LAND_1", 1);SetTileTag(40,47,"SOLIDWALL",1);SetTileTag(41,47,"LAND_1", 1);SetTileTag(42,47,"LAND_1", 1);SetTileTag(43,47,"LAND_1", 1);SetTileTag(44,47,"SOLIDWALL",1);SetTileTag(45,47,"SOLIDWALL",1);SetTileTag(46,47,"LAND_1", 1);SetTileTag(47,47,"WATER_3", 1);SetTileTag(48,47,"WATER_3", 1);SetTileTag(56,47,"WATER_3", 1);SetTileTag(57,47,"WATER_3", 1);SetTileTag(58,47,"SOLIDWALL",1);
		SetTileTag(6,46,"LAND_2", 1);SetTileTag(7,46,"LAND_2", 1);SetTileTag(8,46,"LAND_2", 1);SetTileTag(10,46,"SOLIDWALL",1);SetTileTag(12,46,"SOLIDWALL",1);SetTileTag(14,46,"SOLIDWALL",1);SetTileTag(15,46,"LAND_3", 1);SetTileTag(16,46,"LAND_3", 1);SetTileTag(18,46,"LAND_3", 1);SetTileTag(19,46,"SOLIDWALL",1);SetTileTag(20,46,"LAND_1", 1);SetTileTag(21,46,"LAND_1", 1);SetTileTag(22,46,"LAND_1", 1);SetTileTag(23,46,"SOLIDWALL",1);SetTileTag(25,46,"LAND_1", 1);SetTileTag(26,46,"LAND_1", 1);SetTileTag(27,46,"LAND_1", 1);SetTileTag(28,46,"SOLIDWALL",1);SetTileTag(29,46,"SOLIDWALL",1);SetTileTag(30,46,"SOLIDWALL",1);SetTileTag(31,46,"SOLIDWALL",1);SetTileTag(32,46,"SOLIDWALL",1);SetTileTag(33,46,"SOLIDWALL",1);SetTileTag(34,46,"SOLIDWALL",1);SetTileTag(36,46,"SOLIDWALL",1);SetTileTag(37,46,"LAND_1", 1);SetTileTag(41,46,"SOLIDWALL",1);SetTileTag(42,46,"LAND_1", 1);SetTileTag(43,46,"LAND_1", 1);SetTileTag(44,46,"LAND_1", 1);SetTileTag(45,46,"SOLIDWALL",1);SetTileTag(46,46,"SOLIDWALL",1);SetTileTag(47,46,"SOLIDWALL",1);SetTileTag(54,46,"SOLIDWALL",1);SetTileTag(56,46,"SOLIDWALL",1);SetTileTag(57,46,"SOLIDWALL",1);SetTileTag(58,46,"SOLIDWALL",1);SetTileTag(60,46,"SOLIDWALL",1);SetTileTag(62,46,"SOLIDWALL",1);
		SetTileTag(6,45,"SOLIDWALL",1);SetTileTag(8,45,"SOLIDWALL",1);SetTileTag(11,45,"LAND_3", 1);SetTileTag(13,45,"SOLIDWALL",1);SetTileTag(14,45,"SOLIDWALL",1);SetTileTag(15,45,"LAND_3", 1);SetTileTag(17,45,"LAND_3", 1);SetTileTag(18,45,"SOLIDWALL",1);SetTileTag(19,45,"LAND_1", 1);SetTileTag(21,45,"LAND_1", 1);SetTileTag(22,45,"SOLIDWALL",1);SetTileTag(25,45,"LAND_1", 1);SetTileTag(26,45,"LAND_1", 1);SetTileTag(27,45,"LAND_1", 1);SetTileTag(28,45,"SOLIDWALL",1);SetTileTag(29,45,"LAND_1", 1);SetTileTag(31,45,"LAND_1", 1);SetTileTag(32,45,"LAND_1", 1);SetTileTag(33,45,"LAND_1", 1);SetTileTag(35,45,"LAND_1", 1);SetTileTag(36,45,"SOLIDWALL",1);SetTileTag(37,45,"LAND_1", 1);SetTileTag(38,45,"LAND_1", 1);SetTileTag(39,45,"LAND_1", 1);SetTileTag(40,45,"SOLIDWALL",1);SetTileTag(42,45,"SOLIDWALL",1);SetTileTag(43,45,"LAND_1", 1);SetTileTag(44,45,"LAND_1", 1);SetTileTag(45,45,"LAND_1", 1);SetTileTag(46,45,"SOLIDWALL",1);SetTileTag(47,45,"SOLIDWALL",1);SetTileTag(53,45,"SOLIDWALL",1);SetTileTag(58,45,"LAND_10", 1);SetTileTag(61,45,"LAND_10", 1);SetTileTag(62,45,"SOLIDWALL",1);
		SetTileTag(3,44,"LAND_2", 1);SetTileTag(4,44,"LAND_2", 1);SetTileTag(5,44,"LAND_2", 1);SetTileTag(6,44,"LAND_2", 1);SetTileTag(11,44,"SOLIDWALL",1);SetTileTag(13,44,"LAND_3", 1);SetTileTag(14,44,"LAND_3", 1);SetTileTag(16,44,"LAND_3", 1);SetTileTag(17,44,"SOLIDWALL",1);SetTileTag(18,44,"LAND_1", 1);SetTileTag(23,44,"SOLIDWALL",1);SetTileTag(24,44,"SOLIDWALL",1);SetTileTag(25,44,"LAND_1", 1);SetTileTag(26,44,"LAND_1", 1);SetTileTag(27,44,"LAND_1", 1);SetTileTag(28,44,"SOLIDWALL",1);SetTileTag(30,44,"LAND_1", 1);SetTileTag(31,44,"LAND_1", 1);SetTileTag(32,44,"LAND_1", 1);SetTileTag(33,44,"LAND_1", 1);SetTileTag(34,44,"LAND_1", 1);SetTileTag(35,44,"LAND_1", 1);SetTileTag(36,44,"SOLIDWALL",1);SetTileTag(37,44,"LAND_1", 1);SetTileTag(38,44,"SOLIDWALL",1);SetTileTag(39,44,"SOLIDWALL",1);SetTileTag(43,44,"SOLIDWALL",1);SetTileTag(44,44,"LAND_1", 1);SetTileTag(45,44,"LAND_1", 1);SetTileTag(46,44,"LAND_1", 1);SetTileTag(47,44,"SOLIDWALL",1);SetTileTag(53,44,"SOLIDWALL",1);SetTileTag(54,44,"LAND_10", 1);SetTileTag(55,44,"LAND_10", 1);SetTileTag(56,44,"LAND_10", 1);SetTileTag(57,44,"LAND_10", 1);SetTileTag(58,44,"SOLIDWALL",1);
		SetTileTag(4,43,"SOLIDWALL",1);SetTileTag(10,43,"LAND_3", 1);SetTileTag(11,43,"LAND_3", 1);SetTileTag(12,43,"LAND_3", 1);SetTileTag(13,43,"SOLIDWALL",1);SetTileTag(17,43,"LAND_1", 1);SetTileTag(18,43,"LAND_1", 1);SetTileTag(19,43,"LAND_1", 1);SetTileTag(20,43,"LAND_1", 1);SetTileTag(21,43,"SOLIDWALL",1);SetTileTag(23,43,"LAND_1", 1);SetTileTag(24,43,"LAND_1", 1);SetTileTag(25,43,"LAND_1", 1);SetTileTag(26,43,"LAND_1", 1);SetTileTag(27,43,"LAND_1", 1);SetTileTag(28,43,"SOLIDWALL",1);SetTileTag(29,43,"LAND_1", 1);SetTileTag(30,43,"LAND_1", 1);SetTileTag(31,43,"SOLIDWALL",1);SetTileTag(32,43,"LAND_1", 1);SetTileTag(33,43,"SOLIDWALL",1);SetTileTag(34,43,"LAND_1", 1);SetTileTag(36,43,"SOLIDWALL",1);SetTileTag(37,43,"LAND_1", 1);SetTileTag(42,43,"SOLIDWALL",1);SetTileTag(44,43,"SOLIDWALL",1);SetTileTag(45,43,"LAND_1", 1);SetTileTag(46,43,"LAND_1", 1);SetTileTag(47,43,"LAND_1", 1);SetTileTag(48,43,"SOLIDWALL",1);SetTileTag(51,43,"SOLIDWALL",1);SetTileTag(54,43,"SOLIDWALL",1);SetTileTag(55,43,"SOLIDWALL",1);SetTileTag(56,43,"SOLIDWALL",1);SetTileTag(57,43,"SOLIDWALL",1);SetTileTag(61,43,"SOLIDWALL",1);
		SetTileTag(3,42,"SOLIDWALL",1);SetTileTag(7,42,"SOLIDWALL",1);SetTileTag(10,42,"SOLIDWALL",1);SetTileTag(12,42,"SOLIDWALL",1);SetTileTag(15,42,"SOLIDWALL",1);SetTileTag(16,42,"LAND_1", 1);SetTileTag(17,42,"LAND_1", 1);SetTileTag(18,42,"LAND_1", 1);SetTileTag(19,42,"SOLIDWALL",1);SetTileTag(20,42,"SOLIDWALL",1);SetTileTag(22,42,"SOLIDWALL",1);SetTileTag(23,42,"LAND_1", 1);SetTileTag(25,42,"SOLIDWALL",1);SetTileTag(26,42,"SOLIDWALL",1);SetTileTag(27,42,"LAND_1", 1);SetTileTag(28,42,"LAND_1", 1);SetTileTag(29,42,"LAND_1", 1);SetTileTag(31,42,"LAND_1", 1);SetTileTag(32,42,"LAND_1", 1);SetTileTag(33,42,"LAND_1", 1);SetTileTag(34,42,"LAND_1", 1);SetTileTag(35,42,"LAND_1", 1);SetTileTag(36,42,"LAND_1", 1);SetTileTag(37,42,"LAND_1", 1);SetTileTag(38,42,"SOLIDWALL",1);SetTileTag(41,42,"SOLIDWALL",1);SetTileTag(43,42,"SOLIDWALL",1);SetTileTag(44,42,"SOLIDWALL",1);SetTileTag(46,42,"LAND_1", 1);SetTileTag(47,42,"LAND_1", 1);SetTileTag(48,42,"LAND_1", 1);SetTileTag(49,42,"SOLIDWALL",1);SetTileTag(50,42,"SOLIDWALL",1);SetTileTag(51,42,"LAND_1", 1);
		SetTileTag(1,41,"SOLIDWALL",1);SetTileTag(2,41,"LAND_2", 1);SetTileTag(3,41,"LAND_2", 1);SetTileTag(7,41,"LAND_2", 1);SetTileTag(8,41,"LAND_2", 1);SetTileTag(9,41,"SOLIDWALL",1);SetTileTag(14,41,"SOLIDWALL",1);SetTileTag(15,41,"LAND_1", 1);SetTileTag(16,41,"LAND_1", 1);SetTileTag(17,41,"LAND_1", 1);SetTileTag(18,41,"SOLIDWALL",1);SetTileTag(19,41,"SOLIDWALL",1);SetTileTag(20,41,"SOLIDWALL",1);SetTileTag(21,41,"SOLIDWALL",1);SetTileTag(22,41,"SOLIDWALL",1);SetTileTag(23,41,"LAND_1", 1);SetTileTag(26,41,"SOLIDWALL",1);SetTileTag(27,41,"SOLIDWALL",1);SetTileTag(28,41,"SOLIDWALL",1);SetTileTag(29,41,"SOLIDWALL",1);SetTileTag(30,41,"LAND_1", 1);SetTileTag(31,41,"LAND_1", 1);SetTileTag(32,41,"LAND_1", 1);SetTileTag(33,41,"LAND_1", 1);SetTileTag(34,41,"LAND_1", 1);SetTileTag(35,41,"SOLIDWALL",1);SetTileTag(36,41,"SOLIDWALL",1);SetTileTag(37,41,"SOLIDWALL",1);SetTileTag(38,41,"SOLIDWALL",1);SetTileTag(43,41,"LAND_1", 1);SetTileTag(46,41,"SOLIDWALL",1);SetTileTag(47,41,"LAND_1", 1);SetTileTag(48,41,"LAND_1", 1);SetTileTag(49,41,"LAND_1", 1);SetTileTag(50,41,"SOLIDWALL",1);SetTileTag(51,41,"LAND_1", 1);SetTileTag(56,41,"SOLIDWALL",1);SetTileTag(57,41,"SOLIDWALL",1);
		SetTileTag(2,40,"SOLIDWALL",1);SetTileTag(4,40,"LAND_2", 1);SetTileTag(5,40,"LAND_2", 1);SetTileTag(6,40,"LAND_2", 1);SetTileTag(7,40,"SOLIDWALL",1);SetTileTag(14,40,"SOLIDWALL",1);SetTileTag(16,40,"LAND_1", 1);SetTileTag(17,40,"SOLIDWALL",1);SetTileTag(20,40,"LAND_1", 1);SetTileTag(21,40,"LAND_1", 1);SetTileTag(25,40,"SOLIDWALL",1);SetTileTag(26,40,"LAND_1", 1);SetTileTag(28,40,"LAND_1", 1);SetTileTag(29,40,"SOLIDWALL",1);SetTileTag(31,40,"SOLIDWALL",1);SetTileTag(32,40,"LAND_1", 1);SetTileTag(33,40,"SOLIDWALL",1);SetTileTag(34,40,"SOLIDWALL",1);SetTileTag(35,40,"SOLIDWALL",1);SetTileTag(36,40,"LAND_1", 1);SetTileTag(38,40,"LAND_1", 1);SetTileTag(39,40,"SOLIDWALL",1);SetTileTag(42,40,"LAND_1", 1);SetTileTag(45,40,"SOLIDWALL",1);SetTileTag(47,40,"SOLIDWALL",1);SetTileTag(48,40,"LAND_1", 1);SetTileTag(49,40,"LAND_1", 1);SetTileTag(50,40,"LAND_1", 1);SetTileTag(51,40,"LAND_1", 1);SetTileTag(56,40,"LAND_1", 1);SetTileTag(57,40,"LAND_1", 1);
		SetTileTag(4,39,"SOLIDWALL",1);SetTileTag(13,39,"SOLIDWALL",1);SetTileTag(14,39,"SOLIDWALL",1);SetTileTag(15,39,"LAND_1", 1);SetTileTag(16,39,"SOLIDWALL",1);SetTileTag(17,39,"SOLIDWALL",1);SetTileTag(18,39,"SOLIDWALL",1);SetTileTag(20,39,"SOLIDWALL",1);SetTileTag(21,39,"SOLIDWALL",1);SetTileTag(25,39,"SOLIDWALL",1);SetTileTag(26,39,"LAND_1", 1);SetTileTag(27,39,"LAND_1", 1);SetTileTag(30,39,"SOLIDWALL",1);SetTileTag(31,39,"LAND_1", 1);SetTileTag(38,39,"LAND_1", 1);SetTileTag(39,39,"SOLIDWALL",1);SetTileTag(41,39,"SOLIDWALL",1);SetTileTag(42,39,"SOLIDWALL",1);SetTileTag(43,39,"SOLIDWALL",1);SetTileTag(45,39,"SOLIDWALL",1);SetTileTag(46,39,"SOLIDWALL",1);SetTileTag(48,39,"SOLIDWALL",1);SetTileTag(49,39,"LAND_1", 1);SetTileTag(52,39,"LAND_1", 1);
		SetTileTag(12,38,"SOLIDWALL",1);SetTileTag(13,38,"LAND_1", 1);SetTileTag(14,38,"LAND_1", 1);SetTileTag(16,38,"LAND_1", 1);SetTileTag(22,38,"LAND_1", 1);SetTileTag(23,38,"LAND_1", 1);SetTileTag(25,38,"SOLIDWALL",1);SetTileTag(26,38,"LAND_1", 1);SetTileTag(29,38,"SOLIDWALL",1);SetTileTag(30,38,"SOLIDWALL",1);SetTileTag(31,38,"LAND_1", 1);SetTileTag(34,38,"SOLIDWALL",1);SetTileTag(35,38,"SOLIDWALL",1);SetTileTag(38,38,"LAND_1", 1);SetTileTag(39,38,"SOLIDWALL",1);SetTileTag(40,38,"SOLIDWALL",1);SetTileTag(42,38,"LAND_1", 1);SetTileTag(48,38,"SOLIDWALL",1);SetTileTag(49,38,"SOLIDWALL",1);SetTileTag(53,38,"LAND_1", 1);SetTileTag(57,38,"SOLIDWALL",1);SetTileTag(58,38,"LAND_1", 1);SetTileTag(59,38,"LAND_1", 1);SetTileTag(60,38,"LAND_1", 1);SetTileTag(61,38,"LAND_1", 1);SetTileTag(62,38,"SOLIDWALL",1);
		SetTileTag(17,37,"LAND_1", 1);SetTileTag(18,37,"SOLIDWALL",1);SetTileTag(19,37,"LAND_1", 1);SetTileTag(22,37,"SOLIDWALL",1);SetTileTag(24,37,"SOLIDWALL",1);SetTileTag(25,37,"SOLIDWALL",1);SetTileTag(26,37,"LAND_1", 1);SetTileTag(29,37,"LAND_1", 1);SetTileTag(30,37,"LAND_1", 1);SetTileTag(31,37,"LAND_1", 1);SetTileTag(33,37,"LAND_1", 1);SetTileTag(34,37,"LAND_1", 1);SetTileTag(35,37,"LAND_1", 1);SetTileTag(39,37,"SOLIDWALL",1);SetTileTag(41,37,"LAND_1", 1);SetTileTag(43,37,"SOLIDWALL",1);SetTileTag(48,37,"SOLIDWALL",1);SetTileTag(54,37,"LAND_1", 1);SetTileTag(56,37,"SOLIDWALL",1);SetTileTag(57,37,"SOLIDWALL",1);SetTileTag(58,37,"SOLIDWALL",1);SetTileTag(59,37,"SOLIDWALL",1);SetTileTag(61,37,"SOLIDWALL",1);
		SetTileTag(8,36,"SOLIDWALL",1);SetTileTag(12,36,"SOLIDWALL",1);SetTileTag(13,36,"LAND_1", 1);SetTileTag(14,36,"LAND_1", 1);SetTileTag(16,36,"LAND_1", 1);SetTileTag(17,36,"LAND_1", 1);SetTileTag(18,36,"SOLIDWALL",1);SetTileTag(19,36,"LAND_1", 1);SetTileTag(20,36,"SOLIDWALL",1);SetTileTag(21,36,"LAND_1", 1);SetTileTag(22,36,"LAND_1", 1);SetTileTag(25,36,"SOLIDWALL",1);SetTileTag(26,36,"LAND_1", 1);SetTileTag(27,36,"LAND_1", 1);SetTileTag(28,36,"LAND_1", 1);SetTileTag(29,36,"SOLIDWALL",1);SetTileTag(34,36,"SOLIDWALL",1);SetTileTag(36,36,"LAND_1", 1);SetTileTag(37,36,"LAND_1", 1);SetTileTag(41,36,"LAND_1", 1);SetTileTag(43,36,"LAND_1", 1);SetTileTag(44,36,"LAND_1", 1);SetTileTag(46,36,"LAND_1", 1);SetTileTag(47,36,"LAND_1", 1);SetTileTag(48,36,"LAND_1", 1);SetTileTag(56,36,"SOLIDWALL",1);SetTileTag(57,36,"LAND_1", 1);SetTileTag(58,36,"LAND_1", 1);SetTileTag(59,36,"LAND_1", 1);SetTileTag(60,36,"LAND_1", 1);SetTileTag(61,36,"LAND_1", 1);
		SetTileTag(4,35,"SOLIDWALL",1);SetTileTag(5,35,"SOLIDWALL",1);SetTileTag(6,35,"SOLIDWALL",1);SetTileTag(7,35,"SOLIDWALL",1);SetTileTag(8,35,"LAND_1", 1);SetTileTag(10,35,"LAND_1", 1);SetTileTag(12,35,"SOLIDWALL",1);SetTileTag(13,35,"LAND_1", 1);SetTileTag(14,35,"LAND_1", 1);SetTileTag(16,35,"LAND_1", 1);SetTileTag(17,35,"LAND_1", 1);SetTileTag(18,35,"SOLIDWALL",1);SetTileTag(19,35,"LAND_1", 1);SetTileTag(20,35,"SOLIDWALL",1);SetTileTag(21,35,"SOLIDWALL",1);SetTileTag(22,35,"SOLIDWALL",1);SetTileTag(23,35,"SOLIDWALL",1);SetTileTag(24,35,"SOLIDWALL",1);SetTileTag(25,35,"SOLIDWALL",1);SetTileTag(26,35,"LAND_1", 1);SetTileTag(27,35,"SOLIDWALL",1);SetTileTag(32,35,"LAND_1", 1);SetTileTag(36,35,"SOLIDWALL",1);SetTileTag(38,35,"LAND_1", 1);SetTileTag(41,35,"LAND_1", 1);SetTileTag(45,35,"LAND_1", 1);SetTileTag(48,35,"LAND_1", 1);SetTileTag(54,35,"LAND_1", 1);SetTileTag(56,35,"SOLIDWALL",1);SetTileTag(57,35,"SOLIDWALL",1);SetTileTag(61,35,"LAND_1", 1);
		SetTileTag(5,34,"LAND_1", 1);SetTileTag(6,34,"LAND_1", 1);SetTileTag(7,34,"LAND_1", 1);SetTileTag(8,34,"LAND_1", 1);SetTileTag(10,34,"LAND_1", 1);SetTileTag(13,34,"SOLIDWALL",1);SetTileTag(14,34,"SOLIDWALL",1);SetTileTag(16,34,"SOLIDWALL",1);SetTileTag(17,34,"SOLIDWALL",1);SetTileTag(19,34,"LAND_1", 1);SetTileTag(20,34,"SOLIDWALL",1);SetTileTag(25,34,"SOLIDWALL",1);SetTileTag(26,34,"LAND_1", 1);SetTileTag(27,34,"SOLIDWALL",1);SetTileTag(31,34,"SOLIDWALL",1);SetTileTag(32,34,"SOLIDWALL",1);SetTileTag(33,34,"SOLIDWALL",1);SetTileTag(37,34,"SOLIDWALL",1);SetTileTag(38,34,"LAND_1", 1);SetTileTag(41,34,"LAND_1", 1);SetTileTag(43,34,"SOLIDWALL",1);SetTileTag(44,34,"SOLIDWALL",1);SetTileTag(45,34,"SOLIDWALL",1);SetTileTag(46,34,"SOLIDWALL",1);SetTileTag(47,34,"SOLIDWALL",1);SetTileTag(53,34,"LAND_1", 1);SetTileTag(56,34,"SOLIDWALL",1);SetTileTag(58,34,"LAND_1", 1);SetTileTag(60,34,"LAND_1", 1);
		SetTileTag(3,33,"SOLIDWALL",1);SetTileTag(4,33,"LAND_1", 1);SetTileTag(6,33,"LAND_1", 1);SetTileTag(7,33,"SOLIDWALL",1);SetTileTag(8,33,"LAND_1", 1);SetTileTag(9,33,"LAND_1", 1);SetTileTag(10,33,"LAND_1", 1);SetTileTag(11,33,"SOLIDWALL",1);SetTileTag(14,33,"SOLIDWALL",1);SetTileTag(15,33,"LAND_1", 1);SetTileTag(16,33,"LAND_1", 1);SetTileTag(17,33,"SOLIDWALL",1);SetTileTag(18,33,"SOLIDWALL",1);SetTileTag(19,33,"LAND_1", 1);SetTileTag(20,33,"SOLIDWALL",1);SetTileTag(25,33,"SOLIDWALL",1);SetTileTag(26,33,"LAND_1", 1);SetTileTag(27,33,"LAND_1", 1);SetTileTag(36,33,"SOLIDWALL",1);SetTileTag(37,33,"LAND_1", 1);SetTileTag(38,33,"LAND_1", 1);SetTileTag(41,33,"LAND_1", 1);SetTileTag(46,33,"LAND_1", 1);SetTileTag(47,33,"LAND_1", 1);SetTileTag(48,33,"LAND_1", 1);SetTileTag(52,33,"LAND_1", 1);SetTileTag(56,33,"LAND_1", 1);SetTileTag(58,33,"LAND_1", 1);SetTileTag(60,33,"LAND_1", 1);
		SetTileTag(4,32,"SOLIDWALL",1);SetTileTag(5,32,"LAND_1", 1);SetTileTag(6,32,"LAND_1", 1);SetTileTag(7,32,"SOLIDWALL",1);SetTileTag(8,32,"SOLIDWALL",1);SetTileTag(9,32,"SOLIDWALL",1);SetTileTag(10,32,"SOLIDWALL",1);SetTileTag(14,32,"SOLIDWALL",1);SetTileTag(15,32,"LAND_1", 1);SetTileTag(16,32,"LAND_1", 1);SetTileTag(17,32,"LAND_1", 1);SetTileTag(18,32,"SOLIDWALL",1);SetTileTag(19,32,"LAND_1", 1);SetTileTag(20,32,"LAND_1", 1);SetTileTag(21,32,"WATER_1", 1);SetTileTag(22,32,"WATER_1", 1);SetTileTag(23,32,"WATER_1", 1);SetTileTag(24,32,"WATER_1", 1);SetTileTag(25,32,"SOLIDWALL",1);SetTileTag(26,32,"LAND_1", 1);SetTileTag(27,32,"LAND_1", 1);SetTileTag(28,32,"SOLIDWALL",1);SetTileTag(37,32,"LAND_1", 1);SetTileTag(42,32,"SOLIDWALL",1);SetTileTag(45,32,"LAND_1", 1);SetTileTag(47,32,"SOLIDWALL",1);SetTileTag(50,32,"LAND_1", 1);SetTileTag(51,32,"LAND_1", 1);SetTileTag(56,32,"SOLIDWALL",1);SetTileTag(57,32,"LAND_1", 1);SetTileTag(58,32,"LAND_1", 1);SetTileTag(60,32,"LAND_1", 1);
		SetTileTag(4,31,"SOLIDWALL",1);SetTileTag(6,31,"SOLIDWALL",1);SetTileTag(7,31,"SOLIDWALL",1);SetTileTag(9,31,"SOLIDWALL",1);SetTileTag(10,31,"SOLIDWALL",1);SetTileTag(12,31,"SOLIDWALL",1);SetTileTag(14,31,"SOLIDWALL",1);SetTileTag(15,31,"SOLIDWALL",1);SetTileTag(16,31,"LAND_1", 1);SetTileTag(17,31,"LAND_1", 1);SetTileTag(18,31,"LAND_1", 1);SetTileTag(19,31,"SOLIDWALL",1);SetTileTag(20,31,"LAND_1", 1);SetTileTag(21,31,"LAND_1", 1);SetTileTag(22,31,"WATER_1", 1);SetTileTag(23,31,"WATER_1", 1);SetTileTag(24,31,"WATER_1", 1);SetTileTag(26,31,"LAND_1", 1);SetTileTag(27,31,"LAND_1", 1);SetTileTag(28,31,"SOLIDWALL",1);SetTileTag(30,31,"SOLIDWALL",1);SetTileTag(31,31,"LAND_8", 1);SetTileTag(32,31,"LAND_8", 1);SetTileTag(33,31,"LAND_8", 1);SetTileTag(34,31,"SOLIDWALL",1);SetTileTag(36,31,"SOLIDWALL",1);SetTileTag(37,31,"LAND_1", 1);SetTileTag(38,31,"LAND_1", 1);SetTileTag(41,31,"LAND_1", 1);SetTileTag(45,31,"SOLIDWALL",1);SetTileTag(46,31,"SOLIDWALL",1);SetTileTag(50,31,"LAND_1", 1);SetTileTag(52,31,"LAND_1", 1);SetTileTag(57,31,"LAND_1", 1);SetTileTag(58,31,"LAND_1", 1);SetTileTag(60,31,"LAND_1", 1);
		SetTileTag(3,30,"SOLIDWALL",1);SetTileTag(4,30,"LAND_1", 1);SetTileTag(13,30,"LAND_1", 1);SetTileTag(14,30,"LAND_1", 1);SetTileTag(15,30,"LAND_1", 1);SetTileTag(16,30,"LAND_1", 1);SetTileTag(18,30,"LAND_1", 1);SetTileTag(19,30,"LAND_1", 1);SetTileTag(20,30,"SOLIDWALL",1);SetTileTag(21,30,"SOLIDWALL",1);SetTileTag(22,30,"WATER_1", 1);SetTileTag(23,30,"WATER_1", 1);SetTileTag(24,30,"WATER_1", 1);SetTileTag(26,30,"LAND_1", 1);SetTileTag(27,30,"SOLIDWALL",1);SetTileTag(37,30,"SOLIDWALL",1);SetTileTag(38,30,"LAND_1", 1);SetTileTag(39,30,"SOLIDWALL",1);SetTileTag(40,30,"SOLIDWALL",1);SetTileTag(41,30,"LAND_1", 1);SetTileTag(42,30,"LAND_1", 1);SetTileTag(43,30,"LAND_1", 1);SetTileTag(44,30,"LAND_1", 1);SetTileTag(45,30,"LAND_1", 1);SetTileTag(50,30,"LAND_1", 1);SetTileTag(53,30,"LAND_1", 1);SetTileTag(57,30,"LAND_1", 1);SetTileTag(58,30,"LAND_1", 1);SetTileTag(59,30,"LAND_1", 1);SetTileTag(60,30,"LAND_1", 1);SetTileTag(61,30,"LAND_1", 1);SetTileTag(62,30,"SOLIDWALL",1);
		SetTileTag(3,29,"SOLIDWALL",1);SetTileTag(4,29,"LAND_1", 1);SetTileTag(13,29,"LAND_1", 1);SetTileTag(14,29,"SOLIDWALL",1);SetTileTag(15,29,"SOLIDWALL",1);SetTileTag(16,29,"LAND_1", 1);SetTileTag(17,29,"LAND_1", 1);SetTileTag(20,29,"LAND_1", 1);SetTileTag(21,29,"SOLIDWALL",1);SetTileTag(22,29,"WATER_1", 1);SetTileTag(23,29,"WATER_1", 1);SetTileTag(24,29,"WATER_1", 1);SetTileTag(25,29,"SOLIDWALL",1);SetTileTag(26,29,"LAND_1", 1);SetTileTag(27,29,"SOLIDWALL",1);SetTileTag(30,29,"SOLIDWALL",1);SetTileTag(31,29,"SOLIDWALL",1);SetTileTag(32,29,"SOLIDWALL",1);SetTileTag(33,29,"SOLIDWALL",1);SetTileTag(34,29,"SOLIDWALL",1);SetTileTag(35,29,"SOLIDWALL",1);SetTileTag(37,29,"SOLIDWALL",1);SetTileTag(38,29,"LAND_1", 1);SetTileTag(39,29,"SOLIDWALL",1);SetTileTag(41,29,"SOLIDWALL",1);SetTileTag(42,29,"SOLIDWALL",1);SetTileTag(49,29,"SOLIDWALL",1);SetTileTag(50,29,"LAND_1", 1);SetTileTag(54,29,"LAND_1", 1);SetTileTag(55,29,"LAND_1", 1);SetTileTag(56,29,"SOLIDWALL",1);SetTileTag(57,29,"SOLIDWALL",1);SetTileTag(58,29,"SOLIDWALL",1);SetTileTag(59,29,"SOLIDWALL",1);SetTileTag(61,29,"SOLIDWALL",1);
		SetTileTag(3,28,"SOLIDWALL",1);SetTileTag(4,28,"LAND_1", 1);SetTileTag(5,28,"LAND_1", 1);SetTileTag(6,28,"LAND_1", 1);SetTileTag(7,28,"LAND_1", 1);SetTileTag(8,28,"LAND_1", 1);SetTileTag(10,28,"LAND_1", 1);SetTileTag(11,28,"LAND_1", 1);SetTileTag(12,28,"LAND_1", 1);SetTileTag(13,28,"LAND_1", 1);SetTileTag(14,28,"SOLIDWALL",1);SetTileTag(16,28,"SOLIDWALL",1);SetTileTag(17,28,"LAND_1", 1);SetTileTag(18,28,"LAND_1", 1);SetTileTag(21,28,"SOLIDWALL",1);SetTileTag(22,28,"WATER_1", 1);SetTileTag(23,28,"WATER_1", 1);SetTileTag(24,28,"WATER_1", 1);SetTileTag(25,28,"SOLIDWALL",1);SetTileTag(26,28,"LAND_1", 1);SetTileTag(27,28,"LAND_1", 1);SetTileTag(30,28,"LAND_1", 1);SetTileTag(34,28,"LAND_1", 1);SetTileTag(36,28,"LAND_1", 1);SetTileTag(38,28,"LAND_1", 1);SetTileTag(39,28,"SOLIDWALL",1);SetTileTag(50,28,"SOLIDWALL",1);SetTileTag(51,28,"LAND_1", 1);SetTileTag(52,28,"SOLIDWALL",1);SetTileTag(55,28,"SOLIDWALL",1);SetTileTag(56,28,"SOLIDWALL",1);SetTileTag(57,28,"SOLIDWALL",1);SetTileTag(58,28,"SOLIDWALL",1);SetTileTag(59,28,"SOLIDWALL",1);
		SetTileTag(4,27,"SOLIDWALL",1);SetTileTag(5,27,"SOLIDWALL",1);SetTileTag(6,27,"SOLIDWALL",1);SetTileTag(7,27,"SOLIDWALL",1);SetTileTag(8,27,"LAND_1", 1);SetTileTag(11,27,"SOLIDWALL",1);SetTileTag(12,27,"SOLIDWALL",1);SetTileTag(13,27,"SOLIDWALL",1);SetTileTag(17,27,"SOLIDWALL",1);SetTileTag(18,27,"LAND_1", 1);SetTileTag(19,27,"LAND_1", 1);SetTileTag(20,27,"LAND_1", 1);SetTileTag(21,27,"SOLIDWALL",1);SetTileTag(22,27,"WATER_1", 1);SetTileTag(23,27,"WATER_1", 1);SetTileTag(24,27,"SOLIDWALL",1);SetTileTag(25,27,"SOLIDWALL",1);SetTileTag(26,27,"LAND_1", 1);SetTileTag(27,27,"LAND_1", 1);SetTileTag(28,27,"LAND_1", 1);SetTileTag(29,27,"LAND_1", 1);SetTileTag(30,27,"LAND_1", 1);SetTileTag(31,27,"LAND_1", 1);SetTileTag(32,27,"LAND_1", 1);SetTileTag(33,27,"LAND_1", 1);SetTileTag(34,27,"LAND_1", 1);SetTileTag(35,27,"LAND_1", 1);SetTileTag(36,27,"LAND_1", 1);SetTileTag(37,27,"LAND_1", 1);SetTileTag(38,27,"LAND_1", 1);SetTileTag(39,27,"SOLIDWALL",1);SetTileTag(40,27,"SOLIDWALL",1);SetTileTag(41,27,"SOLIDWALL",1);SetTileTag(45,27,"SOLIDWALL",1);SetTileTag(47,27,"SOLIDWALL",1);SetTileTag(48,27,"SOLIDWALL",1);SetTileTag(52,27,"SOLIDWALL",1);SetTileTag(55,27,"SOLIDWALL",1);SetTileTag(56,27,"SOLIDWALL",1);SetTileTag(57,27,"LAND_12", 1);SetTileTag(59,27,"SOLIDWALL",1);SetTileTag(60,27,"SOLIDWALL",1);
		SetTileTag(2,26,"SOLIDWALL",1);SetTileTag(3,26,"SOLIDWALL",1);SetTileTag(4,26,"SOLIDWALL",1);SetTileTag(5,26,"SOLIDWALL",1);SetTileTag(9,26,"LAND_1", 1);SetTileTag(10,26,"SOLIDWALL",1);SetTileTag(12,26,"SOLIDWALL",1);SetTileTag(13,26,"SOLIDWALL",1);SetTileTag(14,26,"SOLIDWALL",1);SetTileTag(15,26,"SOLIDWALL",1);SetTileTag(18,26,"SOLIDWALL",1);SetTileTag(22,26,"WATER_1", 1);SetTileTag(23,26,"WATER_1", 1);SetTileTag(24,26,"SOLIDWALL",1);SetTileTag(25,26,"SOLIDWALL",1);SetTileTag(26,26,"SOLIDWALL",1);SetTileTag(27,26,"SOLIDWALL",1);SetTileTag(28,26,"SOLIDWALL",1);SetTileTag(30,26,"SOLIDWALL",1);SetTileTag(31,26,"LAND_1", 1);SetTileTag(33,26,"LAND_1", 1);SetTileTag(34,26,"SOLIDWALL",1);SetTileTag(35,26,"SOLIDWALL",1);SetTileTag(36,26,"SOLIDWALL",1);SetTileTag(37,26,"SOLIDWALL",1);SetTileTag(38,26,"SOLIDWALL",1);SetTileTag(40,26,"LAND_1", 1);SetTileTag(43,26,"SOLIDWALL",1);SetTileTag(45,26,"SOLIDWALL",1);SetTileTag(46,26,"LAND_1", 1);SetTileTag(47,26,"LAND_1", 1);SetTileTag(51,26,"LAND_1", 1);SetTileTag(52,26,"SOLIDWALL",1);SetTileTag(54,26,"LAND_1", 1);SetTileTag(55,26,"SOLIDWALL",1);SetTileTag(57,26,"SOLIDWALL",1);SetTileTag(58,26,"SOLIDWALL",1);SetTileTag(59,26,"LAND_1", 1);SetTileTag(61,26,"LAND_1", 1);SetTileTag(62,26,"SOLIDWALL",1);
		SetTileTag(1,25,"SOLIDWALL",1);SetTileTag(2,25,"LAND_1", 1);SetTileTag(4,25,"LAND_1", 1);SetTileTag(6,25,"SOLIDWALL",1);SetTileTag(9,25,"LAND_1", 1);SetTileTag(10,25,"SOLIDWALL",1);SetTileTag(14,25,"LAND_1", 1);SetTileTag(15,25,"LAND_1", 1);SetTileTag(16,25,"SOLIDWALL",1);SetTileTag(21,25,"SOLIDWALL",1);SetTileTag(22,25,"WATER_1", 1);SetTileTag(23,25,"WATER_1", 1);SetTileTag(28,25,"WATER_1", 1);SetTileTag(29,25,"LAND_6", 1);SetTileTag(30,25,"LAND_6", 1);SetTileTag(31,25,"SOLIDWALL",1);SetTileTag(33,25,"SOLIDWALL",1);SetTileTag(39,25,"SOLIDWALL",1);SetTileTag(42,25,"LAND_1", 1);SetTileTag(43,25,"SOLIDWALL",1);SetTileTag(44,25,"SOLIDWALL",1);SetTileTag(46,25,"SOLIDWALL",1);SetTileTag(53,25,"SOLIDWALL",1);SetTileTag(55,25,"LAND_1", 1);SetTileTag(56,25,"LAND_1", 1);SetTileTag(57,25,"LAND_1", 1);
		SetTileTag(1,24,"SOLIDWALL",1);SetTileTag(2,24,"LAND_1", 1);SetTileTag(6,24,"SOLIDWALL",1);SetTileTag(7,24,"SOLIDWALL",1);SetTileTag(10,24,"SOLIDWALL",1);SetTileTag(11,24,"SOLIDWALL",1);SetTileTag(15,24,"LAND_1", 1);SetTileTag(16,24,"SOLIDWALL",1);SetTileTag(19,24,"SOLIDWALL",1);SetTileTag(21,24,"SOLIDWALL",1);SetTileTag(22,24,"SOLIDWALL",1);SetTileTag(23,24,"WATER_1", 1);SetTileTag(24,24,"WATER_1", 1);SetTileTag(25,24,"SOLIDWALL",1);SetTileTag(26,24,"SOLIDWALL",1);SetTileTag(27,24,"WATER_1", 1);SetTileTag(28,24,"WATER_1", 1);SetTileTag(29,24,"WATER_1", 1);SetTileTag(30,24,"WATER_1", 1);SetTileTag(31,24,"SOLIDWALL",1);SetTileTag(32,24,"LAND_1", 1);SetTileTag(33,24,"SOLIDWALL",1);SetTileTag(40,24,"LAND_1", 1);SetTileTag(42,24,"LAND_1", 1);SetTileTag(43,24,"LAND_1", 1);SetTileTag(44,24,"LAND_1", 1);SetTileTag(47,24,"SOLIDWALL",1);SetTileTag(51,24,"SOLIDWALL",1);SetTileTag(53,24,"SOLIDWALL",1);SetTileTag(56,24,"SOLIDWALL",1);SetTileTag(57,24,"LAND_1", 1);
		SetTileTag(1,23,"SOLIDWALL",1);SetTileTag(2,23,"LAND_1", 1);SetTileTag(3,23,"LAND_1", 1);SetTileTag(6,23,"LAND_1", 1);SetTileTag(7,23,"LAND_1", 1);SetTileTag(8,23,"LAND_1", 1);SetTileTag(10,23,"LAND_1", 1);SetTileTag(11,23,"LAND_1", 1);SetTileTag(12,23,"LAND_1", 1);SetTileTag(15,23,"LAND_1", 1);SetTileTag(16,23,"SOLIDWALL",1);SetTileTag(19,23,"WATER_1", 1);SetTileTag(22,23,"WATER_1", 1);SetTileTag(23,23,"WATER_1", 1);SetTileTag(25,23,"WATER_1", 1);SetTileTag(27,23,"SOLIDWALL",1);SetTileTag(28,23,"WATER_1", 1);SetTileTag(29,23,"WATER_1", 1);SetTileTag(30,23,"LAND_7", 1);SetTileTag(31,23,"SOLIDWALL",1);SetTileTag(32,23,"LAND_1", 1);SetTileTag(33,23,"SOLIDWALL",1);SetTileTag(38,23,"SOLIDWALL",1);SetTileTag(40,23,"LAND_1", 1);SetTileTag(42,23,"LAND_1", 1);SetTileTag(43,23,"SOLIDWALL",1);SetTileTag(44,23,"LAND_1", 1);SetTileTag(46,23,"SOLIDWALL",1);SetTileTag(51,23,"LAND_1", 1);SetTileTag(52,23,"SOLIDWALL",1);SetTileTag(53,23,"LAND_1", 1);SetTileTag(58,23,"LAND_1", 1);SetTileTag(61,23,"LAND_1", 1);
		SetTileTag(5,22,"LAND_1", 1);SetTileTag(6,22,"SOLIDWALL",1);SetTileTag(7,22,"SOLIDWALL",1);SetTileTag(8,22,"LAND_1", 1);SetTileTag(11,22,"SOLIDWALL",1);SetTileTag(12,22,"LAND_1", 1);SetTileTag(19,22,"WATER_1", 1);SetTileTag(20,22,"WATER_1", 1);SetTileTag(21,22,"WATER_1", 1);SetTileTag(22,22,"LAND_5", 1);SetTileTag(23,22,"WATER_1", 1);SetTileTag(24,22,"WATER_1", 1);SetTileTag(25,22,"WATER_1", 1);SetTileTag(27,22,"SOLIDWALL",1);SetTileTag(28,22,"SOLIDWALL",1);SetTileTag(29,22,"SOLIDWALL",1);SetTileTag(30,22,"SOLIDWALL",1);SetTileTag(31,22,"LAND_1", 1);SetTileTag(33,22,"LAND_1", 1);SetTileTag(34,22,"SOLIDWALL",1);SetTileTag(35,22,"SOLIDWALL",1);SetTileTag(36,22,"SOLIDWALL",1);SetTileTag(38,22,"SOLIDWALL",1);SetTileTag(42,22,"LAND_1", 1);SetTileTag(43,22,"SOLIDWALL",1);SetTileTag(44,22,"LAND_1", 1);SetTileTag(45,22,"SOLIDWALL",1);SetTileTag(46,22,"SOLIDWALL",1);SetTileTag(47,22,"LAND_1", 1);SetTileTag(51,22,"LAND_1", 1);SetTileTag(52,22,"LAND_1", 1);SetTileTag(53,22,"LAND_1", 1);SetTileTag(58,22,"LAND_1", 1);SetTileTag(59,22,"LAND_1", 1);SetTileTag(60,22,"LAND_1", 1);SetTileTag(61,22,"LAND_1", 1);SetTileTag(62,22,"SOLIDWALL",1);
		SetTileTag(1,21,"SOLIDWALL",1);SetTileTag(2,21,"LAND_1", 1);SetTileTag(3,21,"LAND_1", 1);SetTileTag(4,21,"LAND_1", 1);SetTileTag(5,21,"LAND_1", 1);SetTileTag(6,21,"SOLIDWALL",1);SetTileTag(9,21,"LAND_1", 1);SetTileTag(10,21,"SOLIDWALL",1);SetTileTag(11,21,"SOLIDWALL",1);SetTileTag(12,21,"LAND_1", 1);SetTileTag(13,21,"LAND_1", 1);SetTileTag(14,21,"LAND_1", 1);SetTileTag(15,21,"LAND_1", 1);SetTileTag(16,21,"SOLIDWALL",1);SetTileTag(19,21,"LAND_5", 1);SetTileTag(22,21,"LAND_5", 1);SetTileTag(23,21,"SOLIDWALL",1);SetTileTag(24,21,"SOLIDWALL",1);SetTileTag(25,21,"WATER_1", 1);SetTileTag(27,21,"WATER_1", 1);SetTileTag(28,21,"SOLIDWALL",1);SetTileTag(29,21,"WATER_2", 1);SetTileTag(33,21,"LAND_1", 1);SetTileTag(35,21,"LAND_1", 1);SetTileTag(36,21,"LAND_1", 1);SetTileTag(38,21,"LAND_1", 1);SetTileTag(40,21,"LAND_1", 1);SetTileTag(44,21,"LAND_1", 1);SetTileTag(46,21,"LAND_1", 1);SetTileTag(48,21,"LAND_1", 1);SetTileTag(51,21,"LAND_1", 1);SetTileTag(52,21,"SOLIDWALL",1);SetTileTag(53,21,"LAND_1", 1);SetTileTag(57,21,"SOLIDWALL",1);SetTileTag(58,21,"SOLIDWALL",1);SetTileTag(61,21,"SOLIDWALL",1);
		SetTileTag(2,20,"SOLIDWALL",1);SetTileTag(3,20,"SOLIDWALL",1);SetTileTag(4,20,"SOLIDWALL",1);SetTileTag(5,20,"SOLIDWALL",1);SetTileTag(9,20,"LAND_1", 1);SetTileTag(10,20,"SOLIDWALL",1);SetTileTag(12,20,"SOLIDWALL",1);SetTileTag(13,20,"SOLIDWALL",1);SetTileTag(18,20,"SOLIDWALL",1);SetTileTag(19,20,"LAND_5", 1);SetTileTag(20,20,"LAND_5", 1);SetTileTag(21,20,"LAND_5", 1);SetTileTag(22,20,"LAND_5", 1);SetTileTag(23,20,"SOLIDWALL",1);SetTileTag(25,20,"WATER_1", 1);SetTileTag(26,20,"WATER_1", 1);SetTileTag(27,20,"WATER_1", 1);SetTileTag(28,20,"SOLIDWALL",1);SetTileTag(29,20,"WATER_2", 1);SetTileTag(30,20,"WATER_2", 1);SetTileTag(31,20,"LAND_1", 1);SetTileTag(33,20,"LAND_1", 1);SetTileTag(35,20,"LAND_1", 1);SetTileTag(36,20,"LAND_1", 1);SetTileTag(37,20,"SOLIDWALL",1);SetTileTag(38,20,"SOLIDWALL",1);SetTileTag(40,20,"LAND_1", 1);SetTileTag(42,20,"LAND_1", 1);SetTileTag(43,20,"SOLIDWALL",1);SetTileTag(44,20,"LAND_1", 1);SetTileTag(46,20,"LAND_1", 1);SetTileTag(47,20,"LAND_1", 1);SetTileTag(48,20,"LAND_1", 1);SetTileTag(49,20,"LAND_1", 1);SetTileTag(50,20,"LAND_1", 1);SetTileTag(51,20,"SOLIDWALL",1);SetTileTag(59,20,"LAND_1", 1);
		SetTileTag(2,19,"SOLIDWALL",1);SetTileTag(3,19,"SOLIDWALL",1);SetTileTag(4,19,"SOLIDWALL",1);SetTileTag(5,19,"SOLIDWALL",1);SetTileTag(12,19,"SOLIDWALL",1);SetTileTag(13,19,"SOLIDWALL",1);SetTileTag(14,19,"SOLIDWALL",1);SetTileTag(15,19,"SOLIDWALL",1);SetTileTag(19,19,"SOLIDWALL",1);SetTileTag(20,19,"SOLIDWALL",1);SetTileTag(21,19,"SOLIDWALL",1);SetTileTag(22,19,"SOLIDWALL",1);SetTileTag(23,19,"LAND_1", 1);SetTileTag(26,19,"LAND_1", 1);SetTileTag(27,19,"SOLIDWALL",1);SetTileTag(28,19,"LAND_1", 1);SetTileTag(29,19,"LAND_1", 1);SetTileTag(31,19,"LAND_1", 1);SetTileTag(33,19,"LAND_1", 1);SetTileTag(34,19,"LAND_1", 1);SetTileTag(35,19,"LAND_1", 1);SetTileTag(36,19,"LAND_1", 1);SetTileTag(41,19,"LAND_1", 1);SetTileTag(42,19,"LAND_1", 1);SetTileTag(43,19,"SOLIDWALL",1);SetTileTag(44,19,"LAND_1", 1);SetTileTag(45,19,"SOLIDWALL",1);SetTileTag(46,19,"SOLIDWALL",1);SetTileTag(47,19,"LAND_1", 1);SetTileTag(48,19,"SOLIDWALL",1);SetTileTag(49,19,"SOLIDWALL",1);SetTileTag(50,19,"SOLIDWALL",1);SetTileTag(55,19,"SOLIDWALL",1);SetTileTag(56,19,"SOLIDWALL",1);SetTileTag(58,19,"LAND_1", 1);SetTileTag(59,19,"LAND_1", 1);
		SetTileTag(1,18,"SOLIDWALL",1);SetTileTag(3,18,"LAND_1", 1);SetTileTag(4,18,"LAND_1", 1);SetTileTag(5,18,"LAND_1", 1);SetTileTag(6,18,"SOLIDWALL",1);SetTileTag(7,18,"SOLIDWALL",1);SetTileTag(11,18,"SOLIDWALL",1);SetTileTag(12,18,"LAND_1", 1);SetTileTag(14,18,"LAND_1", 1);SetTileTag(21,18,"LAND_4", 1);SetTileTag(22,18,"SOLIDWALL",1);SetTileTag(23,18,"LAND_1", 1);SetTileTag(24,18,"LAND_1", 1);SetTileTag(25,18,"LAND_1", 1);SetTileTag(26,18,"SOLIDWALL",1);SetTileTag(27,18,"SOLIDWALL",1);SetTileTag(28,18,"LAND_1", 1);SetTileTag(29,18,"LAND_1", 1);SetTileTag(30,18,"SOLIDWALL",1);SetTileTag(31,18,"SOLIDWALL",1);SetTileTag(32,18,"LAND_1", 1);SetTileTag(33,18,"SOLIDWALL",1);SetTileTag(35,18,"LAND_1", 1);SetTileTag(36,18,"LAND_1", 1);SetTileTag(38,18,"SOLIDWALL",1);SetTileTag(39,18,"LAND_1", 1);SetTileTag(40,18,"LAND_1", 1);SetTileTag(41,18,"LAND_1", 1);SetTileTag(42,18,"LAND_1", 1);SetTileTag(44,18,"LAND_1", 1);SetTileTag(45,18,"SOLIDWALL",1);SetTileTag(46,18,"SOLIDWALL",1);SetTileTag(47,18,"LAND_1", 1);SetTileTag(48,18,"SOLIDWALL",1);SetTileTag(55,18,"LAND_1", 1);SetTileTag(56,18,"LAND_1", 1);
		SetTileTag(1,17,"SOLIDWALL",1);SetTileTag(2,17,"LAND_1", 1);SetTileTag(5,17,"LAND_1", 1);SetTileTag(6,17,"SOLIDWALL",1);SetTileTag(7,17,"SOLIDWALL",1);SetTileTag(10,17,"SOLIDWALL",1);SetTileTag(11,17,"SOLIDWALL",1);SetTileTag(15,17,"LAND_1", 1);SetTileTag(16,17,"SOLIDWALL",1);SetTileTag(18,17,"SOLIDWALL",1);SetTileTag(19,17,"LAND_4", 1);SetTileTag(20,17,"LAND_4", 1);SetTileTag(21,17,"SOLIDWALL",1);SetTileTag(22,17,"SOLIDWALL",1);SetTileTag(23,17,"LAND_1", 1);SetTileTag(24,17,"LAND_1", 1);SetTileTag(26,17,"SOLIDWALL",1);SetTileTag(27,17,"LAND_1", 1);SetTileTag(28,17,"LAND_1", 1);SetTileTag(29,17,"SOLIDWALL",1);SetTileTag(31,17,"SOLIDWALL",1);SetTileTag(32,17,"LAND_1", 1);SetTileTag(33,17,"SOLIDWALL",1);SetTileTag(35,17,"SOLIDWALL",1);SetTileTag(37,17,"SOLIDWALL",1);SetTileTag(39,17,"SOLIDWALL",1);SetTileTag(41,17,"SOLIDWALL",1);SetTileTag(42,17,"SOLIDWALL",1);SetTileTag(43,17,"SOLIDWALL",1);SetTileTag(44,17,"LAND_1", 1);SetTileTag(45,17,"LAND_1", 1);SetTileTag(46,17,"LAND_1", 1);SetTileTag(47,17,"LAND_1", 1);SetTileTag(48,17,"SOLIDWALL",1);SetTileTag(54,17,"LAND_1", 1);SetTileTag(57,17,"LAND_1", 1);SetTileTag(58,17,"LAND_1", 1);SetTileTag(59,17,"LAND_1", 1);SetTileTag(60,17,"SOLIDWALL",1);
		SetTileTag(1,16,"SOLIDWALL",1);SetTileTag(2,16,"LAND_1", 1);SetTileTag(6,16,"LAND_1", 1);SetTileTag(7,16,"LAND_1", 1);SetTileTag(10,16,"LAND_1", 1);SetTileTag(11,16,"LAND_1", 1);SetTileTag(15,16,"LAND_1", 1);SetTileTag(16,16,"SOLIDWALL",1);SetTileTag(19,16,"SOLIDWALL",1);SetTileTag(21,16,"SOLIDWALL",1);SetTileTag(22,16,"LAND_1", 1);SetTileTag(24,16,"LAND_1", 1);SetTileTag(25,16,"LAND_1", 1);SetTileTag(26,16,"LAND_1", 1);SetTileTag(30,16,"SOLIDWALL",1);SetTileTag(31,16,"SOLIDWALL",1);SetTileTag(32,16,"LAND_1", 1);SetTileTag(33,16,"SOLIDWALL",1);SetTileTag(34,16,"SOLIDWALL",1);SetTileTag(35,16,"LAND_1", 1);SetTileTag(36,16,"LAND_1", 1);SetTileTag(37,16,"LAND_1", 1);SetTileTag(38,16,"SOLIDWALL",1);SetTileTag(44,16,"SOLIDWALL",1);SetTileTag(45,16,"SOLIDWALL",1);SetTileTag(46,16,"SOLIDWALL",1);SetTileTag(47,16,"SOLIDWALL",1);SetTileTag(52,16,"SOLIDWALL",1);SetTileTag(53,16,"SOLIDWALL",1);SetTileTag(54,16,"LAND_1", 1);SetTileTag(55,16,"SOLIDWALL",1);SetTileTag(56,16,"SOLIDWALL",1);SetTileTag(57,16,"SOLIDWALL",1);
		SetTileTag(1,15,"SOLIDWALL",1);SetTileTag(4,15,"LAND_1", 1);SetTileTag(7,15,"SOLIDWALL",1);SetTileTag(9,15,"LAND_1", 1);SetTileTag(10,15,"SOLIDWALL",1);SetTileTag(11,15,"SOLIDWALL",1);SetTileTag(14,15,"LAND_1", 1);SetTileTag(21,15,"SOLIDWALL",1);SetTileTag(22,15,"LAND_1", 1);SetTileTag(25,15,"SOLIDWALL",1);SetTileTag(26,15,"SOLIDWALL",1);SetTileTag(27,15,"LAND_1", 1);SetTileTag(29,15,"LAND_1", 1);SetTileTag(30,15,"SOLIDWALL",1);SetTileTag(31,15,"SOLIDWALL",1);SetTileTag(32,15,"LAND_1", 1);SetTileTag(33,15,"SOLIDWALL",1);SetTileTag(34,15,"SOLIDWALL",1);SetTileTag(37,15,"LAND_1", 1);SetTileTag(38,15,"SOLIDWALL",1);SetTileTag(43,15,"SOLIDWALL",1);SetTileTag(44,15,"LAND_1", 1);SetTileTag(47,15,"LAND_1", 1);SetTileTag(48,15,"SOLIDWALL",1);SetTileTag(51,15,"SOLIDWALL",1);SetTileTag(59,15,"LAND_1", 1);
		SetTileTag(1,14,"SOLIDWALL",1);SetTileTag(2,14,"LAND_1", 1);SetTileTag(3,14,"LAND_1", 1);SetTileTag(4,14,"LAND_1", 1);SetTileTag(5,14,"LAND_1", 1);SetTileTag(6,14,"SOLIDWALL",1);SetTileTag(7,14,"SOLIDWALL",1);SetTileTag(8,14,"LAND_1", 1);SetTileTag(9,14,"LAND_1", 1);SetTileTag(10,14,"SOLIDWALL",1);SetTileTag(11,14,"SOLIDWALL",1);SetTileTag(12,14,"LAND_1", 1);SetTileTag(13,14,"LAND_1", 1);SetTileTag(14,14,"LAND_1", 1);SetTileTag(15,14,"LAND_1", 1);SetTileTag(16,14,"SOLIDWALL",1);SetTileTag(21,14,"SOLIDWALL",1);SetTileTag(22,14,"LAND_1", 1);SetTileTag(23,14,"LAND_1", 1);SetTileTag(24,14,"SOLIDWALL",1);SetTileTag(26,14,"LAND_1", 1);SetTileTag(27,14,"LAND_1", 1);SetTileTag(29,14,"LAND_1", 1);SetTileTag(30,14,"LAND_1", 1);SetTileTag(31,14,"LAND_1", 1);SetTileTag(33,14,"LAND_1", 1);SetTileTag(34,14,"LAND_1", 1);SetTileTag(37,14,"LAND_1", 1);SetTileTag(38,14,"SOLIDWALL",1);SetTileTag(42,14,"SOLIDWALL",1);SetTileTag(43,14,"LAND_1", 1);SetTileTag(50,14,"SOLIDWALL",1);
		SetTileTag(2,13,"SOLIDWALL",1);SetTileTag(4,13,"SOLIDWALL",1);SetTileTag(5,13,"SOLIDWALL",1);SetTileTag(7,13,"SOLIDWALL",1);SetTileTag(8,13,"LAND_1", 1);SetTileTag(12,13,"SOLIDWALL",1);SetTileTag(13,13,"SOLIDWALL",1);SetTileTag(14,13,"SOLIDWALL",1);SetTileTag(15,13,"SOLIDWALL",1);SetTileTag(23,13,"LAND_1", 1);SetTileTag(24,13,"SOLIDWALL",1);SetTileTag(25,13,"SOLIDWALL",1);SetTileTag(26,13,"LAND_1", 1);SetTileTag(27,13,"LAND_1", 1);SetTileTag(28,13,"LAND_1", 1);SetTileTag(29,13,"LAND_1", 1);SetTileTag(30,13,"SOLIDWALL",1);SetTileTag(32,13,"LAND_1", 1);SetTileTag(34,13,"SOLIDWALL",1);SetTileTag(35,13,"LAND_1", 1);SetTileTag(36,13,"LAND_1", 1);SetTileTag(37,13,"LAND_1", 1);SetTileTag(38,13,"SOLIDWALL",1);SetTileTag(41,13,"SOLIDWALL",1);SetTileTag(42,13,"LAND_1", 1);SetTileTag(45,13,"LAND_1", 1);SetTileTag(46,13,"LAND_1", 1);SetTileTag(47,13,"LAND_1", 1);SetTileTag(50,13,"LAND_1", 1);SetTileTag(57,13,"LAND_1", 1);SetTileTag(58,13,"LAND_1", 1);SetTileTag(59,13,"LAND_1", 1);
		SetTileTag(9,12,"LAND_1", 1);SetTileTag(10,12,"SOLIDWALL",1);SetTileTag(21,12,"SOLIDWALL",1);SetTileTag(22,12,"LAND_1", 1);SetTileTag(23,12,"SOLIDWALL",1);SetTileTag(24,12,"SOLIDWALL",1);SetTileTag(26,12,"SOLIDWALL",1);SetTileTag(27,12,"LAND_1", 1);SetTileTag(28,12,"LAND_1", 1);SetTileTag(32,12,"LAND_1", 1);SetTileTag(33,12,"SOLIDWALL",1);SetTileTag(35,12,"SOLIDWALL",1);SetTileTag(37,12,"LAND_1", 1);SetTileTag(38,12,"SOLIDWALL",1);SetTileTag(41,12,"LAND_1", 1);SetTileTag(46,12,"SOLIDWALL",1);SetTileTag(47,12,"LAND_1", 1);SetTileTag(48,12,"LAND_1", 1);SetTileTag(49,12,"LAND_1", 1);SetTileTag(50,12,"SOLIDWALL",1);SetTileTag(51,12,"LAND_1", 1);SetTileTag(58,12,"LAND_1", 1);
		SetTileTag(1,11,"SOLIDWALL",1);SetTileTag(2,11,"LAND_1", 1);SetTileTag(3,11,"LAND_1", 1);SetTileTag(4,11,"LAND_1", 1);SetTileTag(5,11,"SOLIDWALL",1);SetTileTag(7,11,"SOLIDWALL",1);SetTileTag(9,11,"LAND_1", 1);SetTileTag(10,11,"SOLIDWALL",1);SetTileTag(21,11,"SOLIDWALL",1);SetTileTag(22,11,"LAND_1", 1);SetTileTag(23,11,"LAND_1", 1);SetTileTag(24,11,"LAND_1", 1);SetTileTag(25,11,"SOLIDWALL",1);SetTileTag(27,11,"SOLIDWALL",1);SetTileTag(29,11,"SOLIDWALL",1);SetTileTag(30,11,"SOLIDWALL",1);SetTileTag(31,11,"SOLIDWALL",1);SetTileTag(33,11,"SOLIDWALL",1);SetTileTag(36,11,"SOLIDWALL",1);SetTileTag(37,11,"LAND_1", 1);SetTileTag(38,11,"LAND_1", 1);SetTileTag(42,11,"LAND_1", 1);SetTileTag(45,11,"SOLIDWALL",1);SetTileTag(47,11,"SOLIDWALL",1);SetTileTag(59,11,"LAND_1", 1);
		SetTileTag(2,10,"SOLIDWALL",1);SetTileTag(3,10,"LAND_1", 1);SetTileTag(4,10,"SOLIDWALL",1);SetTileTag(5,10,"SOLIDWALL",1);SetTileTag(6,10,"SOLIDWALL",1);SetTileTag(7,10,"SOLIDWALL",1);SetTileTag(8,10,"LAND_1", 1);SetTileTag(9,10,"LAND_1", 1);SetTileTag(10,10,"SOLIDWALL",1);SetTileTag(11,10,"SOLIDWALL",1);SetTileTag(12,10,"SOLIDWALL",1);SetTileTag(13,10,"SOLIDWALL",1);SetTileTag(15,10,"SOLIDWALL",1);SetTileTag(16,10,"SOLIDWALL",1);SetTileTag(22,10,"LAND_1", 1);SetTileTag(25,10,"SOLIDWALL",1);SetTileTag(26,10,"SOLIDWALL",1);SetTileTag(27,10,"SOLIDWALL",1);SetTileTag(28,10,"SOLIDWALL",1);SetTileTag(29,10,"LAND_1", 1);SetTileTag(30,10,"LAND_1", 1);SetTileTag(33,10,"LAND_1", 1);SetTileTag(36,10,"SOLIDWALL",1);SetTileTag(37,10,"LAND_1", 1);SetTileTag(38,10,"SOLIDWALL",1);SetTileTag(41,10,"LAND_1", 1);SetTileTag(42,10,"LAND_1", 1);SetTileTag(43,10,"LAND_1", 1);SetTileTag(45,10,"LAND_1", 1);SetTileTag(46,10,"SOLIDWALL",1);
		SetTileTag(2,9,"SOLIDWALL",1);SetTileTag(3,9,"LAND_1", 1);SetTileTag(4,9,"LAND_1", 1);SetTileTag(5,9,"LAND_1", 1);SetTileTag(6,9,"LAND_1", 1);SetTileTag(7,9,"LAND_1", 1);SetTileTag(12,9,"LAND_1", 1);SetTileTag(15,9,"LAND_1", 1);SetTileTag(17,9,"LAND_1", 1);SetTileTag(18,9,"SOLIDWALL",1);SetTileTag(21,9,"SOLIDWALL",1);SetTileTag(22,9,"LAND_1", 1);SetTileTag(23,9,"LAND_1", 1);SetTileTag(24,9,"LAND_1", 1);SetTileTag(25,9,"LAND_1", 1);SetTileTag(26,9,"LAND_1", 1);SetTileTag(27,9,"LAND_1", 1);SetTileTag(28,9,"LAND_1", 1);SetTileTag(29,9,"LAND_1", 1);SetTileTag(30,9,"LAND_1", 1);SetTileTag(34,9,"LAND_1", 1);SetTileTag(37,9,"LAND_1", 1);SetTileTag(38,9,"SOLIDWALL",1);SetTileTag(41,9,"SOLIDWALL",1);SetTileTag(43,9,"LAND_1", 1);SetTileTag(51,9,"SOLIDWALL",1);SetTileTag(52,9,"LAND_1", 1);SetTileTag(53,9,"LAND_1", 1);SetTileTag(54,9,"LAND_1", 1);SetTileTag(57,9,"LAND_1", 1);SetTileTag(58,9,"LAND_1", 1);SetTileTag(60,9,"SOLIDWALL",1);
		SetTileTag(1,8,"SOLIDWALL",1);SetTileTag(2,8,"LAND_1", 1);SetTileTag(3,8,"LAND_1", 1);SetTileTag(4,8,"SOLIDWALL",1);SetTileTag(5,8,"SOLIDWALL",1);SetTileTag(7,8,"SOLIDWALL",1);SetTileTag(9,8,"SOLIDWALL",1);SetTileTag(10,8,"SOLIDWALL",1);SetTileTag(11,8,"SOLIDWALL",1);SetTileTag(12,8,"SOLIDWALL",1);SetTileTag(17,8,"LAND_1", 1);SetTileTag(18,8,"SOLIDWALL",1);SetTileTag(22,8,"SOLIDWALL",1);SetTileTag(23,8,"SOLIDWALL",1);SetTileTag(25,8,"SOLIDWALL",1);SetTileTag(26,8,"SOLIDWALL",1);SetTileTag(27,8,"SOLIDWALL",1);SetTileTag(30,8,"LAND_1", 1);SetTileTag(34,8,"LAND_1", 1);SetTileTag(36,8,"SOLIDWALL",1);SetTileTag(37,8,"SOLIDWALL",1);SetTileTag(43,8,"SOLIDWALL",1);SetTileTag(45,8,"SOLIDWALL",1);SetTileTag(58,8,"SOLIDWALL",1);SetTileTag(59,8,"LAND_1", 1);SetTileTag(60,8,"SOLIDWALL",1);
		SetTileTag(1,7,"SOLIDWALL",1);SetTileTag(2,7,"LAND_1", 1);SetTileTag(3,7,"LAND_1", 1);SetTileTag(4,7,"SOLIDWALL",1);SetTileTag(5,7,"LAND_1", 1);SetTileTag(7,7,"LAND_1", 1);SetTileTag(9,7,"LAND_1", 1);SetTileTag(10,7,"SOLIDWALL",1);SetTileTag(12,7,"SOLIDWALL",1);SetTileTag(13,7,"LAND_1", 1);SetTileTag(17,7,"LAND_1", 1);SetTileTag(18,7,"SOLIDWALL",1);SetTileTag(21,7,"SOLIDWALL",1);SetTileTag(22,7,"SOLIDWALL",1);SetTileTag(23,7,"SOLIDWALL",1);SetTileTag(24,7,"SOLIDWALL",1);SetTileTag(26,7,"SOLIDWALL",1);SetTileTag(27,7,"SOLIDWALL",1);SetTileTag(28,7,"SOLIDWALL",1);SetTileTag(30,7,"LAND_1", 1);SetTileTag(33,7,"LAND_1", 1);SetTileTag(34,7,"LAND_1", 1);SetTileTag(35,7,"LAND_1", 1);SetTileTag(36,7,"SOLIDWALL",1);SetTileTag(46,7,"SOLIDWALL",1);SetTileTag(52,7,"SOLIDWALL",1);SetTileTag(53,7,"SOLIDWALL",1);SetTileTag(54,7,"SOLIDWALL",1);
		SetTileTag(1,6,"SOLIDWALL",1);SetTileTag(2,6,"LAND_1", 1);SetTileTag(3,6,"LAND_1", 1);SetTileTag(4,6,"SOLIDWALL",1);SetTileTag(5,6,"LAND_1", 1);SetTileTag(9,6,"LAND_1", 1);SetTileTag(10,6,"SOLIDWALL",1);SetTileTag(12,6,"SOLIDWALL",1);SetTileTag(13,6,"LAND_1", 1);SetTileTag(17,6,"LAND_1", 1);SetTileTag(18,6,"SOLIDWALL",1);SetTileTag(19,6,"SOLIDWALL",1);SetTileTag(22,6,"LAND_1", 1);SetTileTag(27,6,"LAND_1", 1);SetTileTag(28,6,"LAND_1", 1);SetTileTag(30,6,"LAND_1", 1);SetTileTag(31,6,"LAND_1", 1);SetTileTag(33,6,"LAND_1", 1);SetTileTag(34,6,"LAND_1", 1);SetTileTag(36,6,"SOLIDWALL",1);SetTileTag(38,6,"SOLIDWALL",1);SetTileTag(42,6,"SOLIDWALL",1);SetTileTag(46,6,"LAND_1", 1);SetTileTag(47,6,"LAND_1", 1);SetTileTag(48,6,"LAND_1", 1);SetTileTag(53,6,"LAND_1", 1);SetTileTag(54,6,"LAND_1", 1);SetTileTag(55,6,"LAND_1", 1);SetTileTag(56,6,"LAND_1", 1);SetTileTag(57,6,"SOLIDWALL",1);SetTileTag(58,6,"SOLIDWALL",1);SetTileTag(59,6,"LAND_1", 1);SetTileTag(60,6,"LAND_1", 1);SetTileTag(61,6,"LAND_1", 1);
		SetTileTag(1,5,"SOLIDWALL",1);SetTileTag(2,5,"LAND_1", 1);SetTileTag(3,5,"LAND_1", 1);SetTileTag(4,5,"LAND_1", 1);SetTileTag(17,5,"LAND_1", 1);SetTileTag(18,5,"LAND_1", 1);SetTileTag(21,5,"LAND_1", 1);SetTileTag(24,5,"LAND_1", 1);SetTileTag(25,5,"SOLIDWALL",1);SetTileTag(26,5,"LAND_1", 1);SetTileTag(27,5,"SOLIDWALL",1);SetTileTag(28,5,"SOLIDWALL",1);SetTileTag(29,5,"LAND_1", 1);SetTileTag(30,5,"LAND_1", 1);SetTileTag(31,5,"LAND_1", 1);SetTileTag(32,5,"LAND_1", 1);SetTileTag(33,5,"LAND_1", 1);SetTileTag(34,5,"LAND_1", 1);SetTileTag(35,5,"LAND_1", 1);SetTileTag(36,5,"SOLIDWALL",1);SetTileTag(45,5,"LAND_1", 1);SetTileTag(46,5,"SOLIDWALL",1);SetTileTag(59,5,"SOLIDWALL",1);SetTileTag(60,5,"SOLIDWALL",1);SetTileTag(61,5,"LAND_1", 1);SetTileTag(62,5,"SOLIDWALL",1);
		SetTileTag(1,4,"SOLIDWALL",1);SetTileTag(2,4,"LAND_1", 1);SetTileTag(3,4,"LAND_1", 1);SetTileTag(9,4,"LAND_1", 1);SetTileTag(10,4,"SOLIDWALL",1);SetTileTag(14,4,"LAND_1", 1);SetTileTag(16,4,"LAND_1", 1);SetTileTag(17,4,"LAND_1", 1);SetTileTag(18,4,"SOLIDWALL",1);SetTileTag(19,4,"SOLIDWALL",1);SetTileTag(20,4,"SOLIDWALL",1);SetTileTag(21,4,"LAND_1", 1);SetTileTag(23,4,"LAND_1", 1);SetTileTag(24,4,"LAND_1", 1);SetTileTag(25,4,"LAND_1", 1);SetTileTag(26,4,"LAND_1", 1);SetTileTag(27,4,"SOLIDWALL",1);SetTileTag(29,4,"SOLIDWALL",1);SetTileTag(31,4,"SOLIDWALL",1);SetTileTag(32,4,"SOLIDWALL",1);SetTileTag(34,4,"SOLIDWALL",1);SetTileTag(35,4,"SOLIDWALL",1);SetTileTag(40,4,"LAND_1", 1);SetTileTag(41,4,"LAND_1", 1);SetTileTag(42,4,"LAND_1", 1);SetTileTag(43,4,"LAND_1", 1);SetTileTag(44,4,"LAND_1", 1);SetTileTag(59,4,"SOLIDWALL",1);SetTileTag(60,4,"SOLIDWALL",1);
		SetTileTag(2,3,"SOLIDWALL",1);SetTileTag(3,3,"LAND_1", 1);SetTileTag(4,3,"LAND_1", 1);SetTileTag(5,3,"LAND_1", 1);SetTileTag(7,3,"LAND_1", 1);SetTileTag(9,3,"LAND_1", 1);SetTileTag(10,3,"SOLIDWALL",1);SetTileTag(12,3,"SOLIDWALL",1);SetTileTag(13,3,"LAND_1", 1);SetTileTag(14,3,"LAND_1", 1);SetTileTag(15,3,"LAND_1", 1);SetTileTag(16,3,"LAND_1", 1);SetTileTag(17,3,"LAND_1", 1);SetTileTag(18,3,"SOLIDWALL",1);SetTileTag(20,3,"SOLIDWALL",1);SetTileTag(21,3,"LAND_1", 1);SetTileTag(22,3,"LAND_1", 1);SetTileTag(23,3,"LAND_1", 1);SetTileTag(25,3,"SOLIDWALL",1);SetTileTag(26,3,"SOLIDWALL",1);SetTileTag(40,3,"SOLIDWALL",1);SetTileTag(41,3,"SOLIDWALL",1);SetTileTag(44,3,"LAND_1", 1);SetTileTag(45,3,"SOLIDWALL",1);
		SetTileTag(3,2,"SOLIDWALL",1);SetTileTag(4,2,"LAND_1", 1);SetTileTag(5,2,"LAND_1", 1);SetTileTag(6,2,"LAND_1", 1);SetTileTag(7,2,"LAND_1", 1);SetTileTag(8,2,"LAND_1", 1);SetTileTag(9,2,"LAND_1", 1);SetTileTag(10,2,"SOLIDWALL",1);SetTileTag(13,2,"SOLIDWALL",1);SetTileTag(14,2,"SOLIDWALL",1);SetTileTag(15,2,"SOLIDWALL",1);SetTileTag(16,2,"SOLIDWALL",1);SetTileTag(17,2,"SOLIDWALL",1);SetTileTag(21,2,"SOLIDWALL",1);SetTileTag(23,2,"SOLIDWALL",1);SetTileTag(37,2,"SOLIDWALL",1);SetTileTag(38,2,"LAND_1", 1);SetTileTag(39,2,"LAND_1", 1);SetTileTag(40,2,"SOLIDWALL",1);SetTileTag(41,2,"LAND_1", 1);SetTileTag(45,2,"SOLIDWALL",1);SetTileTag(58,2,"SOLIDWALL",1);SetTileTag(59,2,"LAND_1", 1);SetTileTag(60,2,"LAND_1", 1);SetTileTag(61,2,"LAND_1", 1);SetTileTag(62,2,"SOLIDWALL",1);
		SetTileTag(4,1,"SOLIDWALL",1);SetTileTag(5,1,"SOLIDWALL",1);SetTileTag(6,1,"SOLIDWALL",1);SetTileTag(38,1,"SOLIDWALL",1);SetTileTag(41,1,"SOLIDWALL",1);SetTileTag(59,1,"SOLIDWALL",1);
		SetObjectTag("BRIDGE_07_02", "LAND_1");
		SetObjectTag("BRIDGE_07_07", "LAND_1");
		SetObjectTag("BRIDGE_27_56", "LAND_1");
		SetObjectTag("BRIDGE_28_56", "LAND_1");
		SetObjectTag("BRIDGE_37_56", "LAND_1");
		SetObjectTag("BRIDGE_36_56", "LAND_1");
		SetObjectTag("BRIDGE_33_56", "LAND_1");
		SetObjectTag("BRIDGE_32_56", "LAND_1");
		SetObjectTag("BRIDGE_31_56", "LAND_1");


	}



	[MenuItem("MyTools/TagTiles(Invalid)")]
	static void TagTiles()
	{
		/*
		SetTileTag(0,0,0,1,30,0,0,0,0);
		SetTileTag(0,1,0,1,30,0,0,0,0);
		SetTileTag(0,2,0,1,30,0,0,0,0);
		SetTileTag(0,3,0,1,30,0,0,0,0);
		SetTileTag(0,4,0,1,30,0,0,0,0);
		SetTileTag(0,5,0,1,30,0,0,0,0);
		SetTileTag(0,6,0,1,30,0,0,0,0);
		SetTileTag(0,7,0,1,30,0,0,0,0);
		SetTileTag(0,8,0,1,30,0,0,0,0);
		SetTileTag(0,9,0,1,30,0,0,0,0);
		SetTileTag(0,10,0,1,30,0,0,0,0);
		SetTileTag(0,11,0,1,30,0,0,0,0);
		SetTileTag(0,12,0,1,30,0,0,0,0);
		SetTileTag(0,13,0,1,30,0,0,0,0);
		SetTileTag(0,14,0,1,30,0,0,0,0);
		SetTileTag(0,15,0,1,30,0,0,0,0);
		SetTileTag(0,16,0,1,30,0,0,0,0);
		SetTileTag(0,17,0,1,30,0,0,0,0);
		SetTileTag(0,18,0,1,30,0,0,0,0);
		SetTileTag(0,19,0,1,30,0,0,0,0);
		SetTileTag(0,20,0,1,30,0,0,0,0);
		SetTileTag(0,21,0,1,30,0,0,0,0);
		SetTileTag(0,22,0,1,30,0,0,0,0);
		SetTileTag(0,23,0,1,30,0,0,0,0);
		SetTileTag(0,24,0,1,30,0,0,0,0);
		SetTileTag(0,25,0,1,30,0,0,0,0);
		SetTileTag(0,26,0,1,30,0,0,0,0);
		SetTileTag(0,27,0,1,30,0,0,0,0);
		SetTileTag(0,28,0,1,30,0,0,0,0);
		SetTileTag(0,29,0,1,30,0,0,0,0);
		SetTileTag(0,30,0,1,30,0,0,0,0);
		SetTileTag(0,31,0,1,30,0,0,0,0);
		SetTileTag(0,32,0,1,30,0,0,0,0);
		SetTileTag(0,33,0,1,30,0,0,0,0);
		SetTileTag(0,34,0,1,30,0,0,0,0);
		SetTileTag(0,35,0,1,30,0,0,0,0);
		SetTileTag(0,36,0,1,30,0,0,0,0);
		SetTileTag(0,37,0,1,30,0,0,0,0);
		SetTileTag(0,38,0,1,30,0,0,0,0);
		SetTileTag(0,39,0,1,30,0,0,0,0);
		SetTileTag(0,40,0,1,30,0,0,0,0);
		SetTileTag(0,41,0,1,30,0,0,0,0);
		SetTileTag(0,42,0,1,30,0,0,0,0);
		SetTileTag(0,43,0,1,30,0,0,0,0);
		SetTileTag(0,44,0,1,30,0,0,0,0);
		SetTileTag(0,45,0,1,30,0,0,0,0);
		SetTileTag(0,46,0,1,30,0,0,0,0);
		SetTileTag(0,47,0,1,30,0,0,0,0);
		SetTileTag(0,48,0,1,30,0,0,0,0);
		SetTileTag(0,49,0,1,30,0,0,0,0);
		SetTileTag(0,50,0,1,30,0,0,0,0);
		SetTileTag(0,51,0,1,30,0,0,0,0);
		SetTileTag(0,52,0,1,30,0,0,0,0);
		SetTileTag(0,53,0,1,30,0,0,0,0);
		SetTileTag(0,54,0,1,30,0,0,0,0);
		SetTileTag(0,55,0,1,30,0,0,0,0);
		SetTileTag(0,56,0,1,30,0,0,0,0);
		SetTileTag(0,57,0,1,30,0,0,0,0);
		SetTileTag(0,58,0,1,30,0,0,0,0);
		SetTileTag(0,59,0,1,30,0,0,0,0);
		SetTileTag(0,60,0,1,30,0,0,0,0);
		SetTileTag(0,61,0,1,30,0,0,0,0);
		SetTileTag(0,62,0,1,30,0,0,0,0);
		SetTileTag(0,63,0,1,30,0,0,0,0);
		SetTileTag(1,0,0,1,30,0,0,0,0);
		SetTileTag(1,1,0,1,30,0,0,0,0);
		SetTileTag(1,2,0,1,30,0,0,0,0);
		SetTileTag(1,3,0,1,30,0,0,0,0);
		SetTileTag(1,4,0,1,30,0,0,0,0);
		SetTileTag(1,5,0,1,8,0,0,0,0);
		SetTileTag(1,6,0,1,8,0,0,0,0);
		SetTileTag(1,7,0,1,8,0,0,0,0);
		SetTileTag(1,8,0,1,8,0,0,0,0);
		SetTileTag(1,9,0,1,8,0,0,0,0);
		SetTileTag(1,10,0,1,30,0,0,0,0);
		SetTileTag(1,11,0,1,30,0,0,0,0);
		SetTileTag(1,12,0,1,30,0,0,0,0);
		SetTileTag(1,13,0,1,30,0,0,0,0);
		SetTileTag(1,14,0,1,30,0,0,0,0);
		SetTileTag(1,15,0,1,30,0,0,0,0);
		SetTileTag(1,16,0,1,30,0,0,0,0);
		SetTileTag(1,17,0,1,30,0,0,0,0);
		SetTileTag(1,18,0,1,30,0,0,0,0);
		SetTileTag(1,19,0,1,30,0,0,0,0);
		SetTileTag(1,20,0,1,30,0,0,0,0);
		SetTileTag(1,21,0,1,30,0,0,0,0);
		SetTileTag(1,22,0,1,30,0,0,0,0);
		SetTileTag(1,23,0,1,30,0,0,0,0);
		SetTileTag(1,24,0,1,30,0,0,0,0);
		SetTileTag(1,25,0,1,30,0,0,0,0);
		SetTileTag(1,26,0,1,30,0,0,0,0);
		SetTileTag(1,27,0,1,30,0,0,0,0);
		SetTileTag(1,28,0,1,30,0,0,0,0);
		SetTileTag(1,29,0,1,30,0,0,0,0);
		SetTileTag(1,30,0,1,30,0,0,0,0);
		SetTileTag(1,31,0,1,30,0,0,0,0);
		SetTileTag(1,32,0,1,30,0,0,0,0);
		SetTileTag(1,33,0,1,30,0,0,0,0);
		SetTileTag(1,34,0,1,30,0,0,0,0);
		SetTileTag(1,35,0,1,30,0,0,0,0);
		SetTileTag(1,36,0,1,24,0,0,0,0);
		SetTileTag(1,37,0,1,30,0,0,0,0);
		SetTileTag(1,38,0,1,30,0,0,0,0);
		SetTileTag(1,39,0,1,30,0,0,0,0);
		SetTileTag(1,40,0,1,30,0,0,0,0);
		SetTileTag(1,41,0,1,30,0,0,0,0);
		SetTileTag(1,42,0,1,30,0,0,0,0);
		SetTileTag(1,43,0,1,30,0,0,0,0);
		SetTileTag(1,44,0,1,30,0,0,0,0);
		SetTileTag(1,45,0,1,30,0,0,0,0);
		SetTileTag(1,46,0,1,30,0,0,0,0);
		SetTileTag(1,47,0,1,30,0,0,0,0);
		SetTileTag(1,48,0,1,30,0,0,0,0);
		SetTileTag(1,49,0,1,30,0,0,0,0);
		SetTileTag(1,50,0,1,30,0,0,0,0);
		SetTileTag(1,51,0,1,30,0,0,0,0);
		SetTileTag(1,52,0,1,30,0,0,0,0);
		SetTileTag(1,53,0,1,30,0,0,0,0);
		SetTileTag(1,54,0,1,30,0,0,0,0);
		SetTileTag(1,55,0,1,30,0,0,0,0);
		SetTileTag(1,56,0,1,30,0,0,0,0);
		SetTileTag(1,57,0,1,30,0,0,0,0);
		SetTileTag(1,58,0,1,30,0,0,0,0);
		SetTileTag(1,59,0,1,30,0,0,0,0);
		SetTileTag(1,60,0,1,30,0,0,0,0);
		SetTileTag(1,61,0,1,30,0,0,0,0);
		SetTileTag(1,62,0,1,30,0,0,0,0);
		SetTileTag(1,63,0,1,30,0,0,0,0);
		SetTileTag(2,0,0,1,30,0,0,0,0);
		SetTileTag(2,1,0,1,30,0,0,0,0);
		SetTileTag(2,2,0,1,30,0,0,0,0);
		SetTileTag(2,3,0,1,30,0,0,0,0);
		SetTileTag(2,4,0,1,30,0,0,0,0);
		SetTileTag(2,5,0,1,8,0,0,0,0);
		SetTileTag(2,6,0,1,8,0,0,0,0);
		SetTileTag(2,7,0,1,8,0,0,0,0);
		SetTileTag(2,8,0,1,8,0,0,0,0);
		SetTileTag(2,9,0,1,0,0,0,0,0);
		SetTileTag(2,10,1,1,0,0,1,0,0);
		SetTileTag(2,11,1,1,0,0,1,0,0);
		SetTileTag(2,12,1,1,0,0,1,0,0);
		SetTileTag(2,13,0,1,0,0,0,0,0);
		SetTileTag(2,14,1,1,2,0,0,0,0);
		SetTileTag(2,15,1,1,2,0,0,0,0);
		SetTileTag(2,16,0,1,0,0,0,0,0);
		SetTileTag(2,17,1,1,18,0,0,0,0);
		SetTileTag(2,18,1,1,18,0,0,0,0);
		SetTileTag(2,19,1,1,18,0,0,0,0);
		SetTileTag(2,20,1,1,18,0,0,0,0);
		SetTileTag(2,21,1,1,18,0,0,0,0);
		SetTileTag(2,22,1,1,18,0,0,0,0);
		SetTileTag(2,23,1,1,18,0,0,0,0);
		SetTileTag(2,24,1,1,18,0,0,0,0);
		SetTileTag(2,25,1,1,18,0,0,0,0);
		SetTileTag(2,26,0,1,30,0,0,0,0);
		SetTileTag(2,27,0,1,30,0,0,0,0);
		SetTileTag(2,28,0,1,30,0,0,0,0);
		SetTileTag(2,29,0,1,30,0,0,0,0);
		SetTileTag(2,30,0,1,30,0,0,0,0);
		SetTileTag(2,31,0,1,30,0,0,0,0);
		SetTileTag(2,32,0,1,30,0,0,0,0);
		SetTileTag(2,33,1,1,24,0,0,0,0);
		SetTileTag(2,34,1,1,24,0,0,0,0);
		SetTileTag(2,35,1,1,24,0,0,0,0);
		SetTileTag(2,36,1,1,24,0,0,0,0);
		SetTileTag(2,37,0,1,18,0,0,0,0);
		SetTileTag(2,38,0,1,18,0,0,0,0);
		SetTileTag(2,39,0,1,18,0,0,0,0);
		SetTileTag(2,40,0,1,18,0,0,0,0);
		SetTileTag(2,41,0,1,30,0,0,0,0);
		SetTileTag(2,42,0,1,30,0,0,0,0);
		SetTileTag(2,43,0,1,30,0,0,0,0);
		SetTileTag(2,44,0,1,30,0,0,0,0);
		SetTileTag(2,45,0,1,30,0,0,0,0);
		SetTileTag(2,46,0,1,30,0,0,0,0);
		SetTileTag(2,47,0,1,30,0,0,0,0);
		SetTileTag(2,48,0,1,30,0,0,0,0);
		SetTileTag(2,49,0,1,30,0,0,0,0);
		SetTileTag(2,50,0,1,30,0,0,0,0);
		SetTileTag(2,51,0,1,30,0,0,0,0);
		SetTileTag(2,52,0,1,24,0,0,0,0);
		SetTileTag(2,53,0,1,24,0,0,0,0);
		SetTileTag(2,54,0,1,24,0,0,0,0);
		SetTileTag(2,55,0,1,30,0,0,0,0);
		SetTileTag(2,56,1,1,24,0,0,0,0);
		SetTileTag(2,57,1,1,24,0,0,0,0);
		SetTileTag(2,58,1,1,24,0,0,0,0);
		SetTileTag(2,59,0,1,30,0,0,0,0);
		SetTileTag(2,60,0,1,30,0,0,0,0);
		SetTileTag(2,61,0,1,30,0,0,0,0);
		SetTileTag(2,62,0,1,30,0,0,0,0);
		SetTileTag(2,63,0,1,30,0,0,0,0);
		SetTileTag(3,0,0,1,30,0,0,0,0);
		SetTileTag(3,1,0,1,30,0,0,0,0);
		SetTileTag(3,2,0,1,30,0,0,0,0);
		SetTileTag(3,3,0,1,2,0,0,0,0);
		SetTileTag(3,4,0,1,2,0,0,0,0);
		SetTileTag(3,5,0,1,2,0,0,0,0);
		SetTileTag(3,6,0,1,2,0,0,0,0);
		SetTileTag(3,7,0,1,2,0,0,0,0);
		SetTileTag(3,8,0,1,2,0,0,0,0);
		SetTileTag(3,9,0,1,2,0,0,0,0);
		SetTileTag(3,10,1,1,0,0,1,0,0);
		SetTileTag(3,11,1,1,0,0,1,0,0);
		SetTileTag(3,12,1,1,0,0,1,0,0);
		SetTileTag(3,13,6,1,0,0,0,0,0);
		SetTileTag(3,14,1,1,2,0,0,0,0);
		SetTileTag(3,15,1,1,2,0,0,0,0);
		SetTileTag(3,16,0,1,0,0,0,0,0);
		SetTileTag(3,17,1,1,18,0,0,0,0);
		SetTileTag(3,18,0,1,18,0,0,0,0);
		SetTileTag(3,19,1,1,18,0,0,0,0);
		SetTileTag(3,20,0,1,18,0,0,0,0);
		SetTileTag(3,21,1,1,18,0,0,0,0);
		SetTileTag(3,22,0,1,18,0,0,0,0);
		SetTileTag(3,23,1,1,18,0,0,0,0);
		SetTileTag(3,24,0,1,18,0,0,0,0);
		SetTileTag(3,25,1,1,18,0,0,0,0);
		SetTileTag(3,26,0,1,30,0,0,0,0);
		SetTileTag(3,27,0,1,30,0,0,0,0);
		SetTileTag(3,28,0,1,30,0,0,0,0);
		SetTileTag(3,29,0,1,30,0,0,0,0);
		SetTileTag(3,30,0,1,30,0,0,0,0);
		SetTileTag(3,31,0,1,30,0,0,0,0);
		SetTileTag(3,32,0,1,24,0,0,0,0);
		SetTileTag(3,33,1,1,24,0,0,0,0);
		SetTileTag(3,34,1,1,24,0,0,0,0);
		SetTileTag(3,35,0,1,0,0,0,0,0);
		SetTileTag(3,36,1,1,24,0,0,0,0);
		SetTileTag(3,37,0,1,24,0,0,0,0);
		SetTileTag(3,38,1,1,24,0,0,0,0);
		SetTileTag(3,39,1,1,22,0,0,0,0);
		SetTileTag(3,40,0,1,18,0,0,0,0);
		SetTileTag(3,41,0,1,30,0,0,0,0);
		SetTileTag(3,42,1,1,24,0,0,0,0);
		SetTileTag(3,43,1,1,24,0,0,0,0);
		SetTileTag(3,44,1,1,24,0,0,0,0);
		SetTileTag(3,45,1,1,24,0,0,0,0);
		SetTileTag(3,46,1,1,24,0,0,0,0);
		SetTileTag(3,47,1,1,24,0,0,0,0);
		SetTileTag(3,48,1,1,24,0,0,0,0);
		SetTileTag(3,49,0,1,30,0,0,0,0);
		SetTileTag(3,50,1,1,24,0,0,0,0);
		SetTileTag(3,51,1,1,24,0,0,0,0);
		SetTileTag(3,52,0,1,24,0,0,0,0);
		SetTileTag(3,53,0,1,24,0,0,0,0);
		SetTileTag(3,54,0,1,24,0,0,0,0);
		SetTileTag(3,55,0,1,30,0,0,0,0);
		SetTileTag(3,56,1,1,24,0,0,0,0);
		SetTileTag(3,57,1,1,24,0,0,0,0);
		SetTileTag(3,58,1,1,24,0,0,0,0);
		SetTileTag(3,59,0,1,30,0,0,0,0);
		SetTileTag(3,60,0,1,30,0,0,0,0);
		SetTileTag(3,61,0,1,30,0,0,0,0);
		SetTileTag(3,62,0,1,30,0,0,0,0);
		SetTileTag(3,63,0,1,30,0,0,0,0);
		SetTileTag(4,0,0,1,30,0,0,0,0);
		SetTileTag(4,1,0,1,30,0,0,0,0);
		SetTileTag(4,2,1,1,2,0,0,0,0);
		SetTileTag(4,3,1,1,2,0,0,0,0);
		SetTileTag(4,4,1,1,0,0,1,0,0);
		SetTileTag(4,5,1,1,2,0,0,0,0);
		SetTileTag(4,6,1,1,2,0,0,0,0);
		SetTileTag(4,7,1,1,2,0,0,0,0);
		SetTileTag(4,8,1,1,2,0,0,0,0);
		SetTileTag(4,9,0,1,2,0,0,0,0);
		SetTileTag(4,10,1,1,0,0,1,0,0);
		SetTileTag(4,11,1,1,0,0,1,0,0);
		SetTileTag(4,12,1,1,0,0,1,0,0);
		SetTileTag(4,13,2,1,0,0,1,0,0);
		SetTileTag(4,14,0,1,0,0,0,0,0);
		SetTileTag(4,15,0,1,0,0,0,0,0);
		SetTileTag(4,16,0,1,0,0,0,0,0);
		SetTileTag(4,17,1,1,18,0,0,0,0);
		SetTileTag(4,18,1,1,18,0,0,0,0);
		SetTileTag(4,19,1,1,18,0,0,0,0);
		SetTileTag(4,20,1,1,18,0,0,0,0);
		SetTileTag(4,21,1,1,18,0,0,0,0);
		SetTileTag(4,22,1,1,18,0,0,0,0);
		SetTileTag(4,23,1,1,18,0,0,0,0);
		SetTileTag(4,24,1,1,18,0,0,0,0);
		SetTileTag(4,25,1,1,18,0,0,0,0);
		SetTileTag(4,26,0,1,30,0,0,0,0);
		SetTileTag(4,27,0,1,30,0,0,0,0);
		SetTileTag(4,28,0,1,30,0,0,0,0);
		SetTileTag(4,29,8,1,16,0,0,0,0);
		SetTileTag(4,30,8,1,16,0,0,0,0);
		SetTileTag(4,31,8,1,16,0,0,0,0);
		SetTileTag(4,32,0,1,30,0,0,0,0);
		SetTileTag(4,33,0,1,30,0,0,0,0);
		SetTileTag(4,34,0,1,30,0,0,0,0);
		SetTileTag(4,35,0,1,0,0,0,0,0);
		SetTileTag(4,36,1,1,24,0,0,0,0);
		SetTileTag(4,37,0,1,8,0,0,0,0);
		SetTileTag(4,38,1,1,24,0,0,0,0);
		SetTileTag(4,39,1,1,24,0,0,0,0);
		SetTileTag(4,40,0,1,18,0,0,0,0);
		SetTileTag(4,41,0,1,18,0,0,0,0);
		SetTileTag(4,42,1,1,24,0,0,0,0);
		SetTileTag(4,43,1,1,24,0,0,0,0);
		SetTileTag(4,44,1,1,24,0,0,0,0);
		SetTileTag(4,45,1,1,24,0,0,0,0);
		SetTileTag(4,46,1,1,24,0,0,0,0);
		SetTileTag(4,47,1,1,24,0,0,0,0);
		SetTileTag(4,48,1,1,24,0,0,0,0);
		SetTileTag(4,49,1,1,24,0,0,1,0);
		SetTileTag(4,50,1,1,24,0,0,0,0);
		SetTileTag(4,51,1,1,24,0,0,0,0);
		SetTileTag(4,52,0,1,24,0,0,0,0);
		SetTileTag(4,53,0,1,24,0,0,0,0);
		SetTileTag(4,54,0,1,30,0,0,0,0);
		SetTileTag(4,55,4,1,24,0,0,0,0);
		SetTileTag(4,56,1,1,24,0,0,0,0);
		SetTileTag(4,57,1,1,24,0,0,0,0);
		SetTileTag(4,58,1,1,24,0,0,0,0);
		SetTileTag(4,59,2,1,24,0,0,0,0);
		SetTileTag(4,60,0,1,30,0,0,0,0);
		SetTileTag(4,61,0,1,30,0,0,0,0);
		SetTileTag(4,62,0,1,30,0,0,0,0);
		SetTileTag(4,63,0,1,30,0,0,0,0);
		SetTileTag(5,0,0,1,30,0,0,0,0);
		SetTileTag(5,1,0,1,30,0,0,0,0);
		SetTileTag(5,2,1,1,2,0,0,0,0);
		SetTileTag(5,3,1,1,2,0,0,0,0);
		SetTileTag(5,4,1,1,0,0,1,0,0);
		SetTileTag(5,5,1,1,2,0,0,0,0);
		SetTileTag(5,6,1,1,2,0,0,0,0);
		SetTileTag(5,7,1,1,2,0,0,0,0);
		SetTileTag(5,8,1,1,2,0,0,0,0);
		SetTileTag(5,9,0,1,2,0,0,0,0);
		SetTileTag(5,10,5,1,0,0,1,0,0);
		SetTileTag(5,11,1,1,0,0,1,0,0);
		SetTileTag(5,12,1,1,0,0,1,0,0);
		SetTileTag(5,13,1,1,0,0,1,0,0);
		SetTileTag(5,14,0,1,0,0,0,0,0);
		SetTileTag(5,15,0,1,0,0,0,0,0);
		SetTileTag(5,16,0,1,0,0,0,0,0);
		SetTileTag(5,17,1,1,18,0,0,0,0);
		SetTileTag(5,18,1,1,18,0,0,0,0);
		SetTileTag(5,19,8,1,18,0,0,0,0);
		SetTileTag(5,20,1,1,18,0,0,0,0);
		SetTileTag(5,21,1,1,18,0,0,0,0);
		SetTileTag(5,22,1,1,18,0,0,0,0);
		SetTileTag(5,23,1,1,18,0,0,0,0);
		SetTileTag(5,24,1,1,18,0,0,0,0);
		SetTileTag(5,25,1,1,18,0,0,0,0);
		SetTileTag(5,26,1,1,18,0,0,0,0);
		SetTileTag(5,27,1,1,18,0,0,0,0);
		SetTileTag(5,28,1,1,18,0,0,0,0);
		SetTileTag(5,29,1,1,18,0,0,0,0);
		SetTileTag(5,30,1,1,18,0,0,0,0);
		SetTileTag(5,31,1,1,18,0,0,0,0);
		SetTileTag(5,32,1,1,18,0,0,1,0);
		SetTileTag(5,33,1,1,18,0,0,0,0);
		SetTileTag(5,34,1,1,20,0,0,0,0);
		SetTileTag(5,35,1,1,22,0,0,0,0);
		SetTileTag(5,36,1,1,24,0,0,0,0);
		SetTileTag(5,37,1,1,24,0,0,0,0);
		SetTileTag(5,38,1,1,24,0,0,0,0);
		SetTileTag(5,39,1,1,24,0,0,0,0);
		SetTileTag(5,40,0,1,18,0,0,0,0);
		SetTileTag(5,41,0,1,30,0,0,0,0);
		SetTileTag(5,42,1,1,24,0,0,0,0);
		SetTileTag(5,43,0,1,30,0,0,0,0);
		SetTileTag(5,44,0,1,30,0,0,0,0);
		SetTileTag(5,45,0,1,30,0,0,0,0);
		SetTileTag(5,46,0,1,30,0,0,0,0);
		SetTileTag(5,47,0,1,30,0,0,0,0);
		SetTileTag(5,48,1,1,24,0,0,1,0);
		SetTileTag(5,49,0,1,24,0,0,0,0);
		SetTileTag(5,50,0,1,24,0,0,0,0);
		SetTileTag(5,51,0,1,24,0,0,0,0);
		SetTileTag(5,52,0,1,24,0,0,0,0);
		SetTileTag(5,53,1,1,24,0,0,0,0);
		SetTileTag(5,54,1,1,24,0,0,0,0);
		SetTileTag(5,55,1,1,24,0,0,0,0);
		SetTileTag(5,56,1,1,24,0,0,0,0);
		SetTileTag(5,57,1,1,24,0,0,0,0);
		SetTileTag(5,58,1,1,24,0,0,0,0);
		SetTileTag(5,59,1,1,24,0,0,0,0);
		SetTileTag(5,60,1,1,24,0,0,0,0);
		SetTileTag(5,61,0,1,24,0,0,0,0);
		SetTileTag(5,62,0,1,30,0,0,0,0);
		SetTileTag(5,63,0,1,30,0,0,0,0);
		SetTileTag(6,0,0,1,30,0,0,0,0);
		SetTileTag(6,1,0,1,30,0,0,0,0);
		SetTileTag(6,2,8,1,2,0,0,0,0);
		SetTileTag(6,3,1,1,2,0,0,0,0);
		SetTileTag(6,4,1,1,0,0,1,0,0);
		SetTileTag(6,5,1,1,0,0,1,0,0);
		SetTileTag(6,6,1,1,0,0,1,0,0);
		SetTileTag(6,7,1,1,0,0,1,0,0);
		SetTileTag(6,8,1,1,0,0,1,0,0);
		SetTileTag(6,9,0,1,2,0,0,0,0);
		SetTileTag(6,10,0,1,0,0,0,0,0);
		SetTileTag(6,11,1,1,0,0,1,0,0);
		SetTileTag(6,12,1,1,0,0,1,0,0);
		SetTileTag(6,13,1,1,0,0,1,0,0);
		SetTileTag(6,14,0,1,0,0,0,0,0);
		SetTileTag(6,15,0,1,0,0,0,0,0);
		SetTileTag(6,16,0,1,0,0,0,0,0);
		SetTileTag(6,17,0,1,0,0,0,0,0);
		SetTileTag(6,18,0,1,0,0,0,0,0);
		SetTileTag(6,19,8,1,20,0,0,0,0);
		SetTileTag(6,20,0,1,30,0,0,0,0);
		SetTileTag(6,21,0,1,30,0,0,0,0);
		SetTileTag(6,22,0,1,30,0,0,0,0);
		SetTileTag(6,23,0,1,30,0,0,0,0);
		SetTileTag(6,24,0,1,30,0,0,0,0);
		SetTileTag(6,25,0,1,30,0,0,0,0);
		SetTileTag(6,26,0,1,30,0,0,0,0);
		SetTileTag(6,27,0,1,30,0,0,0,0);
		SetTileTag(6,28,0,1,30,0,0,0,0);
		SetTileTag(6,29,1,1,18,0,0,0,0);
		SetTileTag(6,30,1,1,18,0,0,0,0);
		SetTileTag(6,31,1,1,18,0,0,0,0);
		SetTileTag(6,32,0,1,30,0,0,0,0);
		SetTileTag(6,33,0,1,0,0,0,0,0);
		SetTileTag(6,34,0,1,0,0,0,0,0);
		SetTileTag(6,35,0,1,0,0,0,0,0);
		SetTileTag(6,36,1,1,24,0,0,0,0);
		SetTileTag(6,37,0,1,8,0,0,0,0);
		SetTileTag(6,38,1,1,24,0,0,0,0);
		SetTileTag(6,39,1,1,24,0,0,0,0);
		SetTileTag(6,40,0,1,18,0,0,0,0);
		SetTileTag(6,41,0,1,30,0,0,0,0);
		SetTileTag(6,42,1,1,24,0,0,0,0);
		SetTileTag(6,43,1,1,24,0,0,0,0);
		SetTileTag(6,44,1,1,24,0,0,0,0);
		SetTileTag(6,45,1,1,24,0,0,0,0);
		SetTileTag(6,46,1,1,22,0,1,0,0);
		SetTileTag(6,47,0,1,30,0,0,0,0);
		SetTileTag(6,48,1,1,24,0,0,0,0);
		SetTileTag(6,49,1,1,24,0,0,0,0);
		SetTileTag(6,50,1,1,24,0,0,0,0);
		SetTileTag(6,51,1,1,24,0,0,0,0);
		SetTileTag(6,52,0,1,30,0,0,0,0);
		SetTileTag(6,53,1,1,24,0,0,0,0);
		SetTileTag(6,54,1,1,14,0,0,0,0);
		SetTileTag(6,55,1,1,14,0,0,0,0);
		SetTileTag(6,56,1,1,14,0,0,0,0);
		SetTileTag(6,57,1,1,14,0,0,0,0);
		SetTileTag(6,58,1,1,14,0,0,0,0);
		SetTileTag(6,59,1,1,14,0,0,0,0);
		SetTileTag(6,60,1,1,14,0,0,0,0);
		SetTileTag(6,61,0,1,24,0,0,0,0);
		SetTileTag(6,62,0,1,30,0,0,0,0);
		SetTileTag(6,63,0,1,30,0,0,0,0);
		SetTileTag(7,0,0,1,30,0,0,0,0);
		SetTileTag(7,1,0,1,30,0,0,0,0);
		SetTileTag(7,2,8,1,4,0,0,0,0);
		SetTileTag(7,3,1,1,2,0,0,0,0);
		SetTileTag(7,4,1,1,2,0,0,0,0);
		SetTileTag(7,5,1,1,2,0,0,0,0);
		SetTileTag(7,6,1,1,2,0,0,0,0);
		SetTileTag(7,7,1,1,2,0,0,0,0);
		SetTileTag(7,8,1,1,2,0,0,0,0);
		SetTileTag(7,9,0,1,2,0,0,0,0);
		SetTileTag(7,10,0,1,0,0,0,0,0);
		SetTileTag(7,11,5,1,0,0,1,0,0);
		SetTileTag(7,12,1,1,0,0,1,0,0);
		SetTileTag(7,13,1,1,0,0,1,0,0);
		SetTileTag(7,14,0,1,0,0,0,0,0);
		SetTileTag(7,15,0,1,0,0,0,0,0);
		SetTileTag(7,16,0,1,0,0,0,0,0);
		SetTileTag(7,17,0,1,0,0,0,0,0);
		SetTileTag(7,18,0,1,0,0,0,0,0);
		SetTileTag(7,19,8,1,22,0,0,0,0);
		SetTileTag(7,20,0,1,30,0,0,0,0);
		SetTileTag(7,21,0,1,30,0,0,0,0);
		SetTileTag(7,22,0,1,30,0,0,0,0);
		SetTileTag(7,23,0,1,30,0,0,0,0);
		SetTileTag(7,24,0,1,30,0,0,0,0);
		SetTileTag(7,25,0,1,30,0,0,0,0);
		SetTileTag(7,26,0,1,30,0,0,0,0);
		SetTileTag(7,27,0,1,30,0,0,0,0);
		SetTileTag(7,28,0,1,30,0,0,0,0);
		SetTileTag(7,29,1,1,18,0,0,0,0);
		SetTileTag(7,30,0,1,30,0,0,0,0);
		SetTileTag(7,31,0,1,30,0,0,0,0);
		SetTileTag(7,32,0,1,0,0,0,0,0);
		SetTileTag(7,33,0,1,0,0,0,0,0);
		SetTileTag(7,34,1,1,0,0,0,0,0);
		SetTileTag(7,35,0,1,0,0,0,0,0);
		SetTileTag(7,36,1,1,24,0,0,0,0);
		SetTileTag(7,37,0,1,8,0,0,0,0);
		SetTileTag(7,38,1,1,24,0,0,0,0);
		SetTileTag(7,39,1,1,24,0,0,0,0);
		SetTileTag(7,40,0,1,18,0,0,0,0);
		SetTileTag(7,41,0,1,30,0,0,0,0);
		SetTileTag(7,42,1,1,24,0,0,0,0);
		SetTileTag(7,43,1,1,24,0,0,0,0);
		SetTileTag(7,44,1,1,24,0,0,0,0);
		SetTileTag(7,45,1,1,26,0,0,0,0);
		SetTileTag(7,46,0,1,24,0,0,0,0);
		SetTileTag(7,47,0,1,30,0,0,0,0);
		SetTileTag(7,48,1,1,24,0,0,0,0);
		SetTileTag(7,49,1,1,24,0,0,0,0);
		SetTileTag(7,50,1,1,24,0,0,0,0);
		SetTileTag(7,51,1,1,24,0,0,0,0);
		SetTileTag(7,52,0,1,30,0,0,0,0);
		SetTileTag(7,53,1,1,24,0,0,0,0);
		SetTileTag(7,54,1,1,14,0,0,0,0);
		SetTileTag(7,55,1,1,14,0,0,0,0);
		SetTileTag(7,56,1,1,14,0,0,0,0);
		SetTileTag(7,57,1,1,14,0,0,0,0);
		SetTileTag(7,58,1,1,14,0,0,0,0);
		SetTileTag(7,59,1,1,14,0,0,0,0);
		SetTileTag(7,60,1,1,14,0,0,0,0);
		SetTileTag(7,61,0,1,24,0,0,0,0);
		SetTileTag(7,62,0,1,30,0,0,0,0);
		SetTileTag(7,63,0,1,30,0,0,0,0);
		SetTileTag(8,0,0,1,30,0,0,0,0);
		SetTileTag(8,1,0,1,30,0,0,0,0);
		SetTileTag(8,2,8,1,6,0,0,0,0);
		SetTileTag(8,3,1,1,2,0,0,0,0);
		SetTileTag(8,4,1,1,2,0,0,0,0);
		SetTileTag(8,5,1,1,2,0,0,0,0);
		SetTileTag(8,6,1,1,2,0,0,0,0);
		SetTileTag(8,7,1,1,2,0,0,0,0);
		SetTileTag(8,8,1,1,2,0,0,0,0);
		SetTileTag(8,9,0,1,2,0,0,0,0);
		SetTileTag(8,10,0,1,2,0,0,0,0);
		SetTileTag(8,11,0,1,0,0,0,0,0);
		SetTileTag(8,12,1,1,0,0,1,0,0);
		SetTileTag(8,13,1,1,0,0,1,0,0);
		SetTileTag(8,14,2,1,0,0,1,0,0);
		SetTileTag(8,15,0,1,0,0,0,0,0);
		SetTileTag(8,16,0,1,0,0,0,0,0);
		SetTileTag(8,17,0,1,0,0,0,0,0);
		SetTileTag(8,18,0,1,0,0,0,0,0);
		SetTileTag(8,19,1,1,24,0,0,0,0);
		SetTileTag(8,20,0,1,30,0,0,0,0);
		SetTileTag(8,21,0,1,2,0,0,0,0);
		SetTileTag(8,22,0,1,2,0,0,0,0);
		SetTileTag(8,23,4,1,2,0,1,0,0);
		SetTileTag(8,24,1,1,2,0,1,0,0);
		SetTileTag(8,25,1,1,2,0,1,0,0);
		SetTileTag(8,26,1,1,2,0,1,0,0);
		SetTileTag(8,27,0,1,2,0,0,0,0);
		SetTileTag(8,28,0,1,2,0,0,0,0);
		SetTileTag(8,29,9,1,16,0,0,0,0);
		SetTileTag(8,30,0,1,30,0,0,0,0);
		SetTileTag(8,31,1,1,8,0,0,0,0);
		SetTileTag(8,32,1,1,6,0,0,0,0);
		SetTileTag(8,33,1,1,4,0,0,0,0);
		SetTileTag(8,34,1,1,2,0,0,0,0);
		SetTileTag(8,35,0,1,24,0,0,0,0);
		SetTileTag(8,36,1,1,24,0,0,0,0);
		SetTileTag(8,37,0,1,24,0,0,0,0);
		SetTileTag(8,38,1,1,24,0,0,0,0);
		SetTileTag(8,39,0,1,30,0,0,0,0);
		SetTileTag(8,40,0,1,18,0,0,0,0);
		SetTileTag(8,41,0,1,30,0,0,0,0);
		SetTileTag(8,42,1,1,22,0,0,0,0);
		SetTileTag(8,43,1,1,24,0,0,0,0);
		SetTileTag(8,44,1,1,24,0,0,0,0);
		SetTileTag(8,45,1,1,24,0,0,0,0);
		SetTileTag(8,46,0,1,24,0,0,0,0);
		SetTileTag(8,47,0,1,30,0,0,0,0);
		SetTileTag(8,48,1,1,24,0,0,0,0);
		SetTileTag(8,49,1,1,24,0,0,0,0);
		SetTileTag(8,50,1,1,24,0,0,0,0);
		SetTileTag(8,51,1,1,24,0,0,0,0);
		SetTileTag(8,52,1,1,24,0,0,1,0);
		SetTileTag(8,53,1,1,24,0,0,0,0);
		SetTileTag(8,54,1,1,14,0,0,0,0);
		SetTileTag(8,55,1,1,12,0,1,0,0);
		SetTileTag(8,56,1,1,12,0,1,0,0);
		SetTileTag(8,57,1,1,14,0,0,0,0);
		SetTileTag(8,58,1,1,12,0,1,0,0);
		SetTileTag(8,59,1,1,12,0,1,0,0);
		SetTileTag(8,60,1,1,14,0,0,0,0);
		SetTileTag(8,61,0,1,24,0,0,0,0);
		SetTileTag(8,62,0,1,30,0,0,0,0);
		SetTileTag(8,63,0,1,30,0,0,0,0);
		SetTileTag(9,0,0,1,30,0,0,0,0);
		SetTileTag(9,1,0,1,30,0,0,0,0);
		SetTileTag(9,2,1,1,2,0,0,0,0);
		SetTileTag(9,3,1,1,2,0,0,0,0);
		SetTileTag(9,4,1,1,2,0,0,0,0);
		SetTileTag(9,5,1,1,22,0,0,0,0);
		SetTileTag(9,6,1,1,22,0,0,0,0);
		SetTileTag(9,7,1,1,2,0,0,0,0);
		SetTileTag(9,8,1,1,2,0,0,0,0);
		SetTileTag(9,9,1,1,2,0,0,0,0);
		SetTileTag(9,10,1,1,2,0,0,1,0);
		SetTileTag(9,11,1,1,2,0,0,0,0);
		SetTileTag(9,12,1,1,2,0,0,0,0);
		SetTileTag(9,13,1,1,0,0,1,0,0);
		SetTileTag(9,14,1,1,0,0,1,0,0);
		SetTileTag(9,15,0,1,0,0,0,0,0);
		SetTileTag(9,16,0,1,0,0,0,0,0);
		SetTileTag(9,17,0,1,0,0,0,0,0);
		SetTileTag(9,18,0,1,0,0,0,0,0);
		SetTileTag(9,19,1,1,24,0,0,1,0);
		SetTileTag(9,20,0,1,30,0,0,0,0);
		SetTileTag(9,21,0,1,2,0,0,0,0);
		SetTileTag(9,22,4,1,2,0,1,0,0);
		SetTileTag(9,23,1,1,2,0,1,0,0);
		SetTileTag(9,24,1,1,2,0,1,0,0);
		SetTileTag(9,25,1,1,2,0,1,0,0);
		SetTileTag(9,26,1,1,2,0,1,0,0);
		SetTileTag(9,27,2,1,2,0,1,0,0);
		SetTileTag(9,28,0,1,2,0,0,0,0);
		SetTileTag(9,29,9,1,14,0,0,0,0);
		SetTileTag(9,30,0,1,30,0,0,0,0);
		SetTileTag(9,31,1,1,10,0,0,0,0);
		SetTileTag(9,32,1,1,2,0,0,0,0);
		SetTileTag(9,33,1,1,2,0,0,0,0);
		SetTileTag(9,34,1,1,24,0,0,0,0);
		SetTileTag(9,35,1,1,24,0,0,1,0);
		SetTileTag(9,36,1,1,24,0,0,0,0);
		SetTileTag(9,37,0,1,8,0,0,0,0);
		SetTileTag(9,38,1,1,24,0,0,0,0);
		SetTileTag(9,39,1,1,24,0,0,0,0);
		SetTileTag(9,40,0,1,18,0,0,0,0);
		SetTileTag(9,41,0,1,30,0,0,0,0);
		SetTileTag(9,42,1,1,24,0,0,0,0);
		SetTileTag(9,43,1,1,24,0,0,0,0);
		SetTileTag(9,44,1,1,24,0,0,0,0);
		SetTileTag(9,45,1,1,26,0,0,0,0);
		SetTileTag(9,46,0,1,24,0,0,0,0);
		SetTileTag(9,47,0,1,30,0,0,0,0);
		SetTileTag(9,48,1,1,26,0,0,0,0);
		SetTileTag(9,49,1,1,24,0,0,0,0);
		SetTileTag(9,50,1,1,24,0,0,0,0);
		SetTileTag(9,51,1,1,24,0,0,0,0);
		SetTileTag(9,52,0,1,30,0,0,0,0);
		SetTileTag(9,53,1,1,24,0,0,0,0);
		SetTileTag(9,54,1,1,14,0,0,0,0);
		SetTileTag(9,55,1,1,12,0,1,0,0);
		SetTileTag(9,56,1,1,14,0,0,0,0);
		SetTileTag(9,57,1,1,14,0,0,0,0);
		SetTileTag(9,58,1,1,14,0,0,0,0);
		SetTileTag(9,59,1,1,12,0,1,0,0);
		SetTileTag(9,60,1,1,14,0,0,0,0);
		SetTileTag(9,61,0,1,24,0,0,0,0);
		SetTileTag(9,62,0,1,30,0,0,0,0);
		SetTileTag(9,63,0,1,30,0,0,0,0);
		SetTileTag(10,0,0,1,30,0,0,0,0);
		SetTileTag(10,1,0,1,30,0,0,0,0);
		SetTileTag(10,2,8,1,10,0,0,0,0);
		SetTileTag(10,3,1,1,2,0,0,0,0);
		SetTileTag(10,4,1,1,2,0,0,0,0);
		SetTileTag(10,5,1,1,22,0,0,0,0);
		SetTileTag(10,6,8,1,22,0,0,0,0);
		SetTileTag(10,7,1,1,2,0,0,0,0);
		SetTileTag(10,8,1,1,2,0,0,0,0);
		SetTileTag(10,9,0,1,0,0,0,0,0);
		SetTileTag(10,10,0,1,0,0,0,0,0);
		SetTileTag(10,11,0,1,0,0,0,0,0);
		SetTileTag(10,12,1,1,2,0,0,0,0);
		SetTileTag(10,13,1,1,0,0,1,0,0);
		SetTileTag(10,14,1,1,0,0,1,0,0);
		SetTileTag(10,15,2,1,0,0,1,0,0);
		SetTileTag(10,16,0,1,0,0,0,0,0);
		SetTileTag(10,17,0,1,0,0,0,0,0);
		SetTileTag(10,18,0,1,18,0,0,0,0);
		SetTileTag(10,19,1,1,24,0,0,0,0);
		SetTileTag(10,20,1,1,24,0,0,0,0);
		SetTileTag(10,21,0,1,2,0,0,0,0);
		SetTileTag(10,22,1,1,2,0,1,0,0);
		SetTileTag(10,23,1,1,2,0,1,0,0);
		SetTileTag(10,24,1,1,4,0,0,0,0);
		SetTileTag(10,25,1,1,4,0,0,0,0);
		SetTileTag(10,26,1,1,2,0,1,0,0);
		SetTileTag(10,27,1,1,2,0,1,0,0);
		SetTileTag(10,28,0,1,2,0,0,0,0);
		SetTileTag(10,29,1,1,14,0,0,0,0);
		SetTileTag(10,30,0,1,30,0,0,0,0);
		SetTileTag(10,31,1,1,12,0,0,0,0);
		SetTileTag(10,32,1,1,2,0,0,0,0);
		SetTileTag(10,33,1,1,2,0,0,0,0);
		SetTileTag(10,34,1,1,22,0,0,0,0);
		SetTileTag(10,35,0,1,30,0,0,0,0);
		SetTileTag(10,36,0,1,30,0,0,0,0);
		SetTileTag(10,37,0,1,30,0,0,0,0);
		SetTileTag(10,38,1,1,24,0,0,0,0);
		SetTileTag(10,39,1,1,24,0,0,0,0);
		SetTileTag(10,40,0,1,18,0,0,0,0);
		SetTileTag(10,41,0,1,30,0,0,0,0);
		SetTileTag(10,42,1,1,24,0,0,0,0);
		SetTileTag(10,43,1,1,24,0,0,0,0);
		SetTileTag(10,44,1,1,24,0,0,0,0);
		SetTileTag(10,45,1,1,24,0,0,0,0);
		SetTileTag(10,46,0,1,24,0,0,0,0);
		SetTileTag(10,47,0,1,30,0,0,0,0);
		SetTileTag(10,48,0,1,24,0,0,0,0);
		SetTileTag(10,49,0,1,24,0,0,0,0);
		SetTileTag(10,50,1,1,24,0,0,0,0);
		SetTileTag(10,51,1,1,24,0,0,0,0);
		SetTileTag(10,52,0,1,30,0,0,0,0);
		SetTileTag(10,53,1,1,24,0,0,0,0);
		SetTileTag(10,54,1,1,14,0,0,0,0);
		SetTileTag(10,55,1,1,14,0,0,0,0);
		SetTileTag(10,56,1,1,14,0,0,0,0);
		SetTileTag(10,57,1,1,14,0,0,0,0);
		SetTileTag(10,58,1,1,14,0,0,0,0);
		SetTileTag(10,59,1,1,14,0,0,0,0);
		SetTileTag(10,60,1,1,14,0,0,0,0);
		SetTileTag(10,61,0,1,24,0,0,0,0);
		SetTileTag(10,62,0,1,30,0,0,0,0);
		SetTileTag(10,63,0,1,30,0,0,0,0);
		SetTileTag(11,0,0,1,30,0,0,0,0);
		SetTileTag(11,1,0,1,30,0,0,0,0);
		SetTileTag(11,2,8,1,12,0,0,0,0);
		SetTileTag(11,3,1,1,2,0,0,0,0);
		SetTileTag(11,4,1,1,2,0,0,0,0);
		SetTileTag(11,5,1,1,2,0,0,0,0);
		SetTileTag(11,6,1,1,24,0,0,0,0);
		SetTileTag(11,7,1,1,2,0,0,0,0);
		SetTileTag(11,8,1,1,2,0,0,0,0);
		SetTileTag(11,9,0,1,0,0,0,0,0);
		SetTileTag(11,10,0,1,0,0,0,0,0);
		SetTileTag(11,11,0,1,0,0,0,0,0);
		SetTileTag(11,12,5,1,2,0,0,0,0);
		SetTileTag(11,13,1,1,0,0,1,0,0);
		SetTileTag(11,14,1,1,0,0,1,0,0);
		SetTileTag(11,15,1,1,0,0,1,0,0);
		SetTileTag(11,16,1,1,0,0,1,0,0);
		SetTileTag(11,17,2,1,0,0,1,0,0);
		SetTileTag(11,18,0,1,18,0,0,0,0);
		SetTileTag(11,19,1,1,24,0,0,0,0);
		SetTileTag(11,20,1,1,24,0,0,0,0);
		SetTileTag(11,21,0,1,2,0,0,0,0);
		SetTileTag(11,22,1,1,2,0,1,0,0);
		SetTileTag(11,23,1,1,2,0,1,0,0);
		SetTileTag(11,24,1,1,4,0,0,0,0);
		SetTileTag(11,25,1,1,4,0,0,0,0);
		SetTileTag(11,26,1,1,2,0,1,0,0);
		SetTileTag(11,27,1,1,2,0,1,0,0);
		SetTileTag(11,28,1,1,10,0,0,0,0);
		SetTileTag(11,29,1,1,14,0,0,0,0);
		SetTileTag(11,30,0,1,30,0,0,0,0);
		SetTileTag(11,31,1,1,14,0,0,0,0);
		SetTileTag(11,32,1,1,16,0,0,0,0);
		SetTileTag(11,33,1,1,18,0,0,0,0);
		SetTileTag(11,34,1,1,20,0,0,0,0);
		SetTileTag(11,35,0,1,30,0,0,0,0);
		SetTileTag(11,36,0,1,30,0,0,0,0);
		SetTileTag(11,37,0,1,30,0,0,0,0);
		SetTileTag(11,38,1,1,24,0,0,0,0);
		SetTileTag(11,39,1,1,24,0,0,0,0);
		SetTileTag(11,40,0,1,18,0,0,0,0);
		SetTileTag(11,41,0,1,30,0,0,0,0);
		SetTileTag(11,42,1,1,24,0,0,0,0);
		SetTileTag(11,43,1,1,24,0,0,0,0);
		SetTileTag(11,44,1,1,24,0,0,0,0);
		SetTileTag(11,45,1,1,26,0,0,0,0);
		SetTileTag(11,46,0,1,24,0,0,0,0);
		SetTileTag(11,47,0,1,30,0,0,0,0);
		SetTileTag(11,48,1,1,24,0,1,0,0);
		SetTileTag(11,49,1,1,24,0,0,0,0);
		SetTileTag(11,50,1,1,24,0,0,0,0);
		SetTileTag(11,51,1,1,24,0,0,0,0);
		SetTileTag(11,52,0,1,30,0,0,0,0);
		SetTileTag(11,53,1,1,24,0,0,0,0);
		SetTileTag(11,54,1,1,14,0,0,0,0);
		SetTileTag(11,55,1,1,14,0,0,0,0);
		SetTileTag(11,56,1,1,14,0,0,0,0);
		SetTileTag(11,57,1,1,14,0,0,0,0);
		SetTileTag(11,58,1,1,14,0,0,0,0);
		SetTileTag(11,59,1,1,14,0,0,0,0);
		SetTileTag(11,60,1,1,14,0,0,0,0);
		SetTileTag(11,61,0,1,24,0,0,0,0);
		SetTileTag(11,62,0,1,30,0,0,0,0);
		SetTileTag(11,63,0,1,30,0,0,0,0);
		SetTileTag(12,0,0,1,30,0,0,0,0);
		SetTileTag(12,1,0,1,30,0,0,0,0);
		SetTileTag(12,2,8,1,14,0,0,0,0);
		SetTileTag(12,3,1,1,2,0,0,0,0);
		SetTileTag(12,4,1,1,2,0,0,0,0);
		SetTileTag(12,5,1,1,2,0,0,0,0);
		SetTileTag(12,6,1,1,24,0,0,0,0);
		SetTileTag(12,7,1,1,2,0,0,0,0);
		SetTileTag(12,8,8,1,10,0,0,0,0);
		SetTileTag(12,9,0,1,0,0,0,0,0);
		SetTileTag(12,10,1,1,18,0,0,0,0);
		SetTileTag(12,11,1,1,18,0,0,0,0);
		SetTileTag(12,12,0,1,0,0,0,0,0);
		SetTileTag(12,13,5,1,0,0,1,0,0);
		SetTileTag(12,14,1,1,0,0,1,0,0);
		SetTileTag(12,15,1,1,0,0,1,0,0);
		SetTileTag(12,16,1,1,0,0,1,0,0);
		SetTileTag(12,17,1,1,0,0,1,0,0);
		SetTileTag(12,18,0,1,18,0,0,0,0);
		SetTileTag(12,19,1,1,24,0,0,0,0);
		SetTileTag(12,20,1,1,24,0,0,0,0);
		SetTileTag(12,21,0,1,2,0,0,0,0);
		SetTileTag(12,22,1,1,2,0,1,0,0);
		SetTileTag(12,23,1,1,2,0,1,0,0);
		SetTileTag(12,24,1,1,4,0,0,0,0);
		SetTileTag(12,25,1,1,4,0,0,0,0);
		SetTileTag(12,26,1,1,2,0,1,0,0);
		SetTileTag(12,27,1,1,2,0,1,0,0);
		SetTileTag(12,28,8,1,10,0,0,0,0);
		SetTileTag(12,29,1,1,14,0,0,0,0);
		SetTileTag(12,30,0,1,30,0,0,0,0);
		SetTileTag(12,31,0,1,30,0,0,0,0);
		SetTileTag(12,32,0,1,30,0,0,0,0);
		SetTileTag(12,33,0,1,30,0,0,0,0);
		SetTileTag(12,34,0,1,30,0,0,0,0);
		SetTileTag(12,35,0,1,30,0,0,0,0);
		SetTileTag(12,36,0,1,30,0,0,0,0);
		SetTileTag(12,37,0,1,30,0,0,0,0);
		SetTileTag(12,38,0,1,30,0,0,0,0);
		SetTileTag(12,39,0,1,30,0,0,0,0);
		SetTileTag(12,40,0,1,18,0,0,0,0);
		SetTileTag(12,41,0,1,30,0,0,0,0);
		SetTileTag(12,42,0,1,24,0,0,0,0);
		SetTileTag(12,43,0,1,24,0,0,0,0);
		SetTileTag(12,44,1,1,24,0,0,1,0);
		SetTileTag(12,45,0,1,30,0,0,0,0);
		SetTileTag(12,46,0,1,24,0,0,0,0);
		SetTileTag(12,47,0,1,30,0,0,0,0);
		SetTileTag(12,48,0,1,30,0,0,0,0);
		SetTileTag(12,49,0,1,30,0,0,0,0);
		SetTileTag(12,50,0,1,30,0,0,0,0);
		SetTileTag(12,51,0,1,30,0,0,0,0);
		SetTileTag(12,52,0,1,30,0,0,0,0);
		SetTileTag(12,53,1,1,24,0,0,0,0);
		SetTileTag(12,54,1,1,14,0,0,0,0);
		SetTileTag(12,55,1,1,12,0,1,0,0);
		SetTileTag(12,56,1,1,14,0,0,0,0);
		SetTileTag(12,57,1,1,14,0,0,0,0);
		SetTileTag(12,58,1,1,14,0,0,0,0);
		SetTileTag(12,59,1,1,12,0,1,0,0);
		SetTileTag(12,60,1,1,14,0,0,0,0);
		SetTileTag(12,61,0,1,24,0,0,0,0);
		SetTileTag(12,62,0,1,30,0,0,0,0);
		SetTileTag(12,63,0,1,30,0,0,0,0);
		SetTileTag(13,0,0,1,30,0,0,0,0);
		SetTileTag(13,1,0,1,30,0,0,0,0);
		SetTileTag(13,2,8,1,16,0,0,0,0);
		SetTileTag(13,3,0,1,24,0,0,0,0);
		SetTileTag(13,4,0,1,24,0,0,0,0);
		SetTileTag(13,5,0,1,2,0,0,0,0);
		SetTileTag(13,6,1,1,24,0,0,0,0);
		SetTileTag(13,7,1,1,2,0,0,0,0);
		SetTileTag(13,8,8,1,12,0,0,0,0);
		SetTileTag(13,9,0,1,30,0,0,0,0);
		SetTileTag(13,10,9,1,16,0,0,0,0);
		SetTileTag(13,11,8,1,18,0,0,0,0);
		SetTileTag(13,12,0,1,30,0,0,0,0);
		SetTileTag(13,13,0,1,30,0,0,0,0);
		SetTileTag(13,14,0,1,2,0,0,0,0);
		SetTileTag(13,15,8,1,0,0,1,0,0);
		SetTileTag(13,16,8,1,0,0,1,0,0);
		SetTileTag(13,17,8,1,0,0,1,0,0);
		SetTileTag(13,18,0,1,18,0,0,0,0);
		SetTileTag(13,19,0,1,2,0,0,0,0);
		SetTileTag(13,20,0,1,2,0,0,0,0);
		SetTileTag(13,21,0,1,2,0,0,0,0);
		SetTileTag(13,22,1,1,2,0,1,0,0);
		SetTileTag(13,23,1,1,2,0,1,0,0);
		SetTileTag(13,24,1,1,4,0,0,0,0);
		SetTileTag(13,25,1,1,4,0,0,0,0);
		SetTileTag(13,26,1,1,2,0,1,0,0);
		SetTileTag(13,27,1,1,2,0,1,0,0);
		SetTileTag(13,28,8,1,12,0,0,0,0);
		SetTileTag(13,29,1,1,14,0,0,0,0);
		SetTileTag(13,30,1,1,14,0,0,0,0);
		SetTileTag(13,31,1,1,14,0,0,0,0);
		SetTileTag(13,32,1,1,14,0,0,0,0);
		SetTileTag(13,33,1,1,14,0,0,0,0);
		SetTileTag(13,34,0,1,14,0,0,0,0);
		SetTileTag(13,35,1,1,14,0,0,0,0);
		SetTileTag(13,36,6,1,14,0,0,0,0);
		SetTileTag(13,37,6,1,16,0,0,0,0);
		SetTileTag(13,38,6,1,18,0,0,0,0);
		SetTileTag(13,39,6,1,20,0,0,0,0);
		SetTileTag(13,40,6,1,22,0,0,0,0);
		SetTileTag(13,41,1,1,24,0,0,0,0);
		SetTileTag(13,42,1,1,24,0,0,0,0);
		SetTileTag(13,43,1,1,24,0,0,0,0);
		SetTileTag(13,44,1,1,24,0,0,0,0);
		SetTileTag(13,45,1,1,24,0,0,0,0);
		SetTileTag(13,46,1,1,24,0,0,0,0);
		SetTileTag(13,47,1,1,24,0,0,0,0);
		SetTileTag(13,48,1,1,24,0,0,0,0);
		SetTileTag(13,49,1,1,24,0,0,0,0);
		SetTileTag(13,50,1,1,24,0,0,0,0);
		SetTileTag(13,51,1,1,24,0,0,0,0);
		SetTileTag(13,52,1,1,24,0,0,0,0);
		SetTileTag(13,53,1,1,24,0,0,0,0);
		SetTileTag(13,54,1,1,14,0,0,0,0);
		SetTileTag(13,55,1,1,12,0,1,0,0);
		SetTileTag(13,56,1,1,12,0,1,0,0);
		SetTileTag(13,57,1,1,14,0,0,0,0);
		SetTileTag(13,58,1,1,12,0,1,0,0);
		SetTileTag(13,59,1,1,12,0,1,0,0);
		SetTileTag(13,60,1,1,14,0,0,0,0);
		SetTileTag(13,61,0,1,24,0,0,0,0);
		SetTileTag(13,62,0,1,30,0,0,0,0);
		SetTileTag(13,63,0,1,30,0,0,0,0);
		SetTileTag(14,0,0,1,30,0,0,0,0);
		SetTileTag(14,1,0,1,30,0,0,0,0);
		SetTileTag(14,2,1,1,18,0,0,0,0);
		SetTileTag(14,3,6,1,18,0,0,0,0);
		SetTileTag(14,4,6,1,20,0,0,0,0);
		SetTileTag(14,5,6,1,22,0,0,0,0);
		SetTileTag(14,6,1,1,24,0,0,0,0);
		SetTileTag(14,7,1,1,2,0,0,0,0);
		SetTileTag(14,8,1,1,14,0,0,0,0);
		SetTileTag(14,9,6,1,14,0,0,0,0);
		SetTileTag(14,10,1,1,16,0,0,0,0);
		SetTileTag(14,11,8,1,20,0,0,0,0);
		SetTileTag(14,12,0,1,30,0,0,0,0);
		SetTileTag(14,13,1,1,24,0,0,0,0);
		SetTileTag(14,14,2,1,24,0,0,0,0);
		SetTileTag(14,15,5,1,2,0,1,0,0);
		SetTileTag(14,16,1,1,2,0,1,0,0);
		SetTileTag(14,17,1,1,2,0,1,0,0);
		SetTileTag(14,18,2,1,2,0,1,0,0);
		SetTileTag(14,19,0,1,2,0,0,0,0);
		SetTileTag(14,20,0,1,2,0,0,0,0);
		SetTileTag(14,21,0,1,2,0,0,0,0);
		SetTileTag(14,22,1,1,2,0,1,0,0);
		SetTileTag(14,23,1,1,2,0,1,0,0);
		SetTileTag(14,24,1,1,2,0,1,0,0);
		SetTileTag(14,25,1,1,2,0,1,0,0);
		SetTileTag(14,26,1,1,2,0,1,0,0);
		SetTileTag(14,27,1,1,2,0,1,0,0);
		SetTileTag(14,28,1,1,14,0,0,0,0);
		SetTileTag(14,29,1,1,14,0,0,0,0);
		SetTileTag(14,30,1,1,14,0,0,0,0);
		SetTileTag(14,31,1,1,14,0,0,0,0);
		SetTileTag(14,32,1,1,14,0,0,0,0);
		SetTileTag(14,33,1,1,14,0,0,0,0);
		SetTileTag(14,34,0,1,14,0,0,0,0);
		SetTileTag(14,35,1,1,14,0,0,0,0);
		SetTileTag(14,36,1,1,14,0,0,0,0);
		SetTileTag(14,37,1,1,14,0,0,0,0);
		SetTileTag(14,38,1,1,14,0,0,0,0);
		SetTileTag(14,39,1,1,14,0,0,0,0);
		SetTileTag(14,40,1,1,14,0,0,0,0);
		SetTileTag(14,41,1,1,14,0,0,0,0);
		SetTileTag(14,42,1,1,14,0,0,0,0);
		SetTileTag(14,43,1,1,14,0,0,0,0);
		SetTileTag(14,44,1,1,14,0,0,0,0);
		SetTileTag(14,45,1,1,14,0,0,0,0);
		SetTileTag(14,46,1,1,14,0,0,0,0);
		SetTileTag(14,47,1,1,14,0,0,0,0);
		SetTileTag(14,48,1,1,14,0,0,0,0);
		SetTileTag(14,49,1,1,14,0,0,0,0);
		SetTileTag(14,50,1,1,14,0,0,0,0);
		SetTileTag(14,51,1,1,14,0,0,0,0);
		SetTileTag(14,52,1,1,14,0,0,0,0);
		SetTileTag(14,53,1,1,14,0,0,0,0);
		SetTileTag(14,54,1,1,14,0,0,0,0);
		SetTileTag(14,55,1,1,14,0,0,0,0);
		SetTileTag(14,56,1,1,14,0,0,0,0);
		SetTileTag(14,57,1,1,14,0,0,0,0);
		SetTileTag(14,58,1,1,14,0,0,0,0);
		SetTileTag(14,59,1,1,14,0,0,0,0);
		SetTileTag(14,60,1,1,14,0,0,0,0);
		SetTileTag(14,61,0,1,24,0,0,0,0);
		SetTileTag(14,62,0,1,30,0,0,0,0);
		SetTileTag(14,63,0,1,30,0,0,0,0);
		SetTileTag(15,0,0,1,30,0,0,0,0);
		SetTileTag(15,1,0,1,30,0,0,0,0);
		SetTileTag(15,2,0,1,30,0,0,0,0);
		SetTileTag(15,3,0,1,30,0,0,0,0);
		SetTileTag(15,4,0,1,30,0,0,0,0);
		SetTileTag(15,5,0,1,24,0,0,0,0);
		SetTileTag(15,6,1,1,24,0,0,0,0);
		SetTileTag(15,7,0,1,30,0,0,0,0);
		SetTileTag(15,8,0,1,30,0,0,0,0);
		SetTileTag(15,9,0,1,30,0,0,0,0);
		SetTileTag(15,10,0,1,30,0,0,0,0);
		SetTileTag(15,11,8,1,22,0,0,0,0);
		SetTileTag(15,12,0,1,30,0,0,0,0);
		SetTileTag(15,13,1,1,24,0,0,0,0);
		SetTileTag(15,14,1,1,24,0,0,0,0);
		SetTileTag(15,15,2,1,24,0,0,0,0);
		SetTileTag(15,16,5,1,2,0,1,0,0);
		SetTileTag(15,17,1,1,2,0,1,0,0);
		SetTileTag(15,18,1,1,2,0,1,0,0);
		SetTileTag(15,19,2,1,2,0,1,0,0);
		SetTileTag(15,20,0,1,2,0,0,0,0);
		SetTileTag(15,21,0,1,2,0,0,0,0);
		SetTileTag(15,22,5,1,2,0,1,0,0);
		SetTileTag(15,23,1,1,2,0,1,0,0);
		SetTileTag(15,24,1,1,2,0,1,0,0);
		SetTileTag(15,25,1,1,2,0,1,0,0);
		SetTileTag(15,26,1,1,2,0,1,0,0);
		SetTileTag(15,27,1,1,2,0,1,0,0);
		SetTileTag(15,28,1,1,14,0,0,0,0);
		SetTileTag(15,29,1,1,14,0,0,0,0);
		SetTileTag(15,30,0,1,2,0,0,0,0);
		SetTileTag(15,31,1,1,14,0,0,0,0);
		SetTileTag(15,32,1,1,14,0,0,0,0);
		SetTileTag(15,33,1,1,14,0,0,0,0);
		SetTileTag(15,34,1,1,14,0,0,1,0);
		SetTileTag(15,35,1,1,14,0,0,0,0);
		SetTileTag(15,36,1,1,14,0,0,0,0);
		SetTileTag(15,37,1,1,14,0,0,0,0);
		SetTileTag(15,38,1,1,14,0,0,0,0);
		SetTileTag(15,39,1,1,14,0,0,0,0);
		SetTileTag(15,40,1,1,14,0,0,0,0);
		SetTileTag(15,41,1,1,14,0,0,0,0);
		SetTileTag(15,42,1,1,14,0,0,0,0);
		SetTileTag(15,43,1,1,14,0,0,0,0);
		SetTileTag(15,44,1,1,14,0,0,0,0);
		SetTileTag(15,45,1,1,14,0,0,0,0);
		SetTileTag(15,46,1,1,14,0,0,0,0);
		SetTileTag(15,47,1,1,14,0,0,0,0);
		SetTileTag(15,48,1,1,14,0,0,0,0);
		SetTileTag(15,49,1,1,14,0,0,0,0);
		SetTileTag(15,50,1,1,14,0,0,0,0);
		SetTileTag(15,51,1,1,14,0,0,0,0);
		SetTileTag(15,52,1,1,14,0,0,0,0);
		SetTileTag(15,53,1,1,14,0,0,0,0);
		SetTileTag(15,54,1,1,14,0,0,0,0);
		SetTileTag(15,55,1,1,14,0,0,0,0);
		SetTileTag(15,56,1,1,14,0,0,0,0);
		SetTileTag(15,57,1,1,14,0,0,0,0);
		SetTileTag(15,58,1,1,14,0,0,0,0);
		SetTileTag(15,59,1,1,14,0,0,0,0);
		SetTileTag(15,60,1,1,14,0,0,0,0);
		SetTileTag(15,61,0,1,24,0,0,0,0);
		SetTileTag(15,62,0,1,30,0,0,0,0);
		SetTileTag(15,63,0,1,30,0,0,0,0);
		SetTileTag(16,0,0,1,30,0,0,0,0);
		SetTileTag(16,1,0,1,30,0,0,0,0);
		SetTileTag(16,2,0,1,30,0,0,0,0);
		SetTileTag(16,3,0,1,30,0,0,0,0);
		SetTileTag(16,4,1,1,24,0,0,0,0);
		SetTileTag(16,5,1,1,24,0,0,0,0);
		SetTileTag(16,6,1,1,24,0,0,0,0);
		SetTileTag(16,7,1,1,24,0,0,0,0);
		SetTileTag(16,8,1,1,24,0,0,0,0);
		SetTileTag(16,9,0,1,30,0,0,0,0);
		SetTileTag(16,10,0,1,30,0,0,0,0);
		SetTileTag(16,11,1,1,24,0,0,0,0);
		SetTileTag(16,12,0,1,30,0,0,0,0);
		SetTileTag(16,13,1,1,24,0,0,0,0);
		SetTileTag(16,14,1,1,24,0,0,0,0);
		SetTileTag(16,15,1,1,24,0,0,0,0);
		SetTileTag(16,16,2,1,24,0,0,0,0);
		SetTileTag(16,17,1,1,2,0,1,0,0);
		SetTileTag(16,18,1,1,2,0,1,0,0);
		SetTileTag(16,19,1,1,2,0,1,0,0);
		SetTileTag(16,20,1,1,2,0,1,0,0);
		SetTileTag(16,21,2,1,2,0,1,0,0);
		SetTileTag(16,22,0,1,2,0,0,0,0);
		SetTileTag(16,23,1,1,2,0,1,0,0);
		SetTileTag(16,24,1,1,2,0,1,0,0);
		SetTileTag(16,25,1,1,2,0,1,0,0);
		SetTileTag(16,26,1,1,2,0,1,0,0);
		SetTileTag(16,27,3,1,2,0,1,0,0);
		SetTileTag(16,28,0,1,2,0,0,0,0);
		SetTileTag(16,29,8,1,14,0,0,0,0);
		SetTileTag(16,30,0,1,2,0,0,0,0);
		SetTileTag(16,31,1,1,14,0,0,0,0);
		SetTileTag(16,32,1,1,14,0,0,0,0);
		SetTileTag(16,33,1,1,14,0,0,0,0);
		SetTileTag(16,34,0,1,14,0,0,0,0);
		SetTileTag(16,35,1,1,14,0,0,0,0);
		SetTileTag(16,36,1,1,14,0,0,0,0);
		SetTileTag(16,37,0,1,24,0,0,0,0);
		SetTileTag(16,38,0,1,30,0,0,0,0);
		SetTileTag(16,39,0,1,30,0,0,0,0);
		SetTileTag(16,40,0,1,30,0,0,0,0);
		SetTileTag(16,41,0,1,30,0,0,0,0);
		SetTileTag(16,42,0,1,30,0,0,0,0);
		SetTileTag(16,43,0,1,30,0,0,0,0);
		SetTileTag(16,44,0,1,30,0,0,0,0);
		SetTileTag(16,45,0,1,30,0,0,0,0);
		SetTileTag(16,46,0,1,30,0,0,0,0);
		SetTileTag(16,47,0,1,30,0,0,0,0);
		SetTileTag(16,48,0,1,30,0,0,0,0);
		SetTileTag(16,49,0,1,30,0,0,0,0);
		SetTileTag(16,50,0,1,30,0,0,0,0);
		SetTileTag(16,51,0,1,30,0,0,0,0);
		SetTileTag(16,52,0,1,30,0,0,0,0);
		SetTileTag(16,53,0,1,30,0,0,0,0);
		SetTileTag(16,54,0,1,30,0,0,0,0);
		SetTileTag(16,55,0,1,30,0,0,0,0);
		SetTileTag(16,56,0,1,30,0,0,0,0);
		SetTileTag(16,57,0,1,30,0,0,0,0);
		SetTileTag(16,58,0,1,30,0,0,0,0);
		SetTileTag(16,59,0,1,30,0,0,0,0);
		SetTileTag(16,60,0,1,30,0,0,0,0);
		SetTileTag(16,61,0,1,24,0,0,0,0);
		SetTileTag(16,62,0,1,30,0,0,0,0);
		SetTileTag(16,63,0,1,30,0,0,0,0);
		SetTileTag(17,0,0,1,30,0,0,0,0);
		SetTileTag(17,1,0,1,30,0,0,0,0);
		SetTileTag(17,2,0,1,30,0,0,0,0);
		SetTileTag(17,3,0,1,30,0,0,0,0);
		SetTileTag(17,4,1,1,24,0,0,0,0);
		SetTileTag(17,5,1,1,24,0,0,0,0);
		SetTileTag(17,6,1,1,24,0,0,0,0);
		SetTileTag(17,7,1,1,24,0,0,0,0);
		SetTileTag(17,8,1,1,24,0,0,0,0);
		SetTileTag(17,9,0,1,30,0,0,0,0);
		SetTileTag(17,10,1,1,24,0,0,0,0);
		SetTileTag(17,11,1,1,24,0,0,0,0);
		SetTileTag(17,12,0,1,30,0,0,0,0);
		SetTileTag(17,13,0,1,30,0,0,0,0);
		SetTileTag(17,14,0,1,24,0,0,0,0);
		SetTileTag(17,15,1,1,24,0,0,0,0);
		SetTileTag(17,16,1,1,24,0,0,0,0);
		SetTileTag(17,17,1,1,2,0,1,0,0);
		SetTileTag(17,18,1,1,2,0,1,0,0);
		SetTileTag(17,19,1,1,2,0,1,0,0);
		SetTileTag(17,20,1,1,2,0,1,0,0);
		SetTileTag(17,21,1,1,2,0,1,0,0);
		SetTileTag(17,22,1,1,2,0,1,0,0);
		SetTileTag(17,23,1,1,2,0,1,0,0);
		SetTileTag(17,24,1,1,2,0,1,0,0);
		SetTileTag(17,25,1,1,2,0,1,0,0);
		SetTileTag(17,26,1,1,2,0,1,0,0);
		SetTileTag(17,27,0,1,2,0,0,0,0);
		SetTileTag(17,28,0,1,2,0,0,0,0);
		SetTileTag(17,29,8,1,16,0,0,0,0);
		SetTileTag(17,30,0,1,30,0,0,0,0);
		SetTileTag(17,31,1,1,14,0,0,0,0);
		SetTileTag(17,32,1,1,14,0,0,0,0);
		SetTileTag(17,33,1,1,14,0,0,0,0);
		SetTileTag(17,34,0,1,14,0,0,0,0);
		SetTileTag(17,35,5,1,14,0,0,0,0);
		SetTileTag(17,36,1,1,14,0,0,0,0);
		SetTileTag(17,37,1,1,14,0,0,0,0);
		SetTileTag(17,38,0,1,30,0,0,0,0);
		SetTileTag(17,39,0,1,30,0,0,0,0);
		SetTileTag(17,40,0,1,30,0,0,0,0);
		SetTileTag(17,41,0,1,30,0,0,0,0);
		SetTileTag(17,42,0,1,30,0,0,0,0);
		SetTileTag(17,43,0,1,30,0,0,0,0);
		SetTileTag(17,44,0,1,30,0,0,0,0);
		SetTileTag(17,45,0,1,30,0,0,0,0);
		SetTileTag(17,46,0,1,30,0,0,0,0);
		SetTileTag(17,47,0,1,30,0,0,0,0);
		SetTileTag(17,48,0,1,30,0,0,0,0);
		SetTileTag(17,49,0,1,30,0,0,0,0);
		SetTileTag(17,50,0,1,30,0,0,0,0);
		SetTileTag(17,51,0,1,30,0,0,0,0);
		SetTileTag(17,52,0,1,30,0,0,0,0);
		SetTileTag(17,53,0,1,30,0,0,0,0);
		SetTileTag(17,54,0,1,30,0,0,0,0);
		SetTileTag(17,55,0,1,30,0,0,0,0);
		SetTileTag(17,56,0,1,30,0,0,0,0);
		SetTileTag(17,57,0,1,30,0,0,0,0);
		SetTileTag(17,58,0,1,30,0,0,0,0);
		SetTileTag(17,59,0,1,30,0,0,0,0);
		SetTileTag(17,60,0,1,24,0,0,0,0);
		SetTileTag(17,61,0,1,24,0,0,0,0);
		SetTileTag(17,62,0,1,24,0,0,0,0);
		SetTileTag(17,63,0,1,30,0,0,0,0);
		SetTileTag(18,0,0,1,30,0,0,0,0);
		SetTileTag(18,1,0,1,30,0,0,0,0);
		SetTileTag(18,2,0,1,22,0,0,0,0);
		SetTileTag(18,3,1,1,24,0,0,0,0);
		SetTileTag(18,4,1,1,24,0,0,0,0);
		SetTileTag(18,5,1,1,24,0,0,0,0);
		SetTileTag(18,6,1,1,24,0,0,0,0);
		SetTileTag(18,7,1,1,24,0,0,0,0);
		SetTileTag(18,8,1,1,24,0,0,0,0);
		SetTileTag(18,9,0,1,30,0,0,0,0);
		SetTileTag(18,10,1,1,24,0,0,0,0);
		SetTileTag(18,11,1,1,24,0,0,0,0);
		SetTileTag(18,12,1,1,24,0,0,0,0);
		SetTileTag(18,13,1,1,24,0,0,0,0);
		SetTileTag(18,14,1,1,24,0,0,0,0);
		SetTileTag(18,15,1,1,24,0,0,0,0);
		SetTileTag(18,16,0,1,2,0,0,0,0);
		SetTileTag(18,17,0,1,2,0,0,0,0);
		SetTileTag(18,18,5,1,2,0,1,0,0);
		SetTileTag(18,19,1,1,2,0,1,0,0);
		SetTileTag(18,20,1,1,2,0,1,0,0);
		SetTileTag(18,21,1,1,2,0,1,0,0);
		SetTileTag(18,22,1,1,2,0,1,0,0);
		SetTileTag(18,23,1,1,2,0,1,0,0);
		SetTileTag(18,24,1,1,2,0,1,0,0);
		SetTileTag(18,25,1,1,2,0,1,0,0);
		SetTileTag(18,26,3,1,2,0,1,0,0);
		SetTileTag(18,27,0,1,2,0,0,0,0);
		SetTileTag(18,28,0,1,2,0,0,0,0);
		SetTileTag(18,29,8,1,18,0,0,0,0);
		SetTileTag(18,30,0,1,30,0,0,0,0);
		SetTileTag(18,31,1,1,14,0,0,0,0);
		SetTileTag(18,32,1,1,14,0,0,0,0);
		SetTileTag(18,33,1,1,14,0,0,0,0);
		SetTileTag(18,34,0,1,30,0,0,0,0);
		SetTileTag(18,35,0,1,30,0,0,0,0);
		SetTileTag(18,36,1,1,14,0,0,0,0);
		SetTileTag(18,37,1,1,14,0,0,0,0);
		SetTileTag(18,38,0,1,24,0,0,0,0);
		SetTileTag(18,39,0,1,24,0,0,0,0);
		SetTileTag(18,40,0,1,24,0,0,0,0);
		SetTileTag(18,41,0,1,24,0,0,0,0);
		SetTileTag(18,42,0,1,24,0,0,0,0);
		SetTileTag(18,43,0,1,24,0,0,0,0);
		SetTileTag(18,44,0,1,24,0,0,0,0);
		SetTileTag(18,45,0,1,24,0,0,0,0);
		SetTileTag(18,46,0,1,30,0,0,0,0);
		SetTileTag(18,47,0,1,30,0,0,0,0);
		SetTileTag(18,48,0,1,30,0,0,0,0);
		SetTileTag(18,49,0,1,30,0,0,0,0);
		SetTileTag(18,50,0,1,30,0,0,0,0);
		SetTileTag(18,51,0,1,30,0,0,0,0);
		SetTileTag(18,52,0,1,30,0,0,0,0);
		SetTileTag(18,53,4,1,18,0,0,0,0);
		SetTileTag(18,54,1,1,18,0,0,0,0);
		SetTileTag(18,55,2,1,18,0,0,0,0);
		SetTileTag(18,56,0,1,30,0,0,0,0);
		SetTileTag(18,57,0,1,30,0,0,0,0);
		SetTileTag(18,58,0,1,30,0,0,0,0);
		SetTileTag(18,59,0,1,24,0,0,0,0);
		SetTileTag(18,60,0,1,24,0,0,0,0);
		SetTileTag(18,61,0,1,24,0,0,0,0);
		SetTileTag(18,62,0,1,24,0,0,0,0);
		SetTileTag(18,63,0,1,30,0,0,0,0);
		SetTileTag(19,0,0,1,30,0,0,0,0);
		SetTileTag(19,1,0,1,30,0,0,0,0);
		SetTileTag(19,2,0,1,22,0,0,0,0);
		SetTileTag(19,3,0,1,30,0,0,0,0);
		SetTileTag(19,4,0,1,30,0,0,0,0);
		SetTileTag(19,5,9,1,22,0,0,0,0);
		SetTileTag(19,6,0,1,30,0,0,0,0);
		SetTileTag(19,7,0,1,30,0,0,0,0);
		SetTileTag(19,8,0,1,30,0,0,0,0);
		SetTileTag(19,9,0,1,30,0,0,0,0);
		SetTileTag(19,10,0,1,30,0,0,0,0);
		SetTileTag(19,11,0,1,30,0,0,0,0);
		SetTileTag(19,12,0,1,30,0,0,0,0);
		SetTileTag(19,13,0,1,30,0,0,0,0);
		SetTileTag(19,14,0,1,2,0,0,0,0);
		SetTileTag(19,15,1,1,24,0,0,0,0);
		SetTileTag(19,16,0,1,2,0,0,0,0);
		SetTileTag(19,17,0,1,2,0,0,0,0);
		SetTileTag(19,18,0,1,2,0,0,0,0);
		SetTileTag(19,19,0,1,2,0,0,0,0);
		SetTileTag(19,20,5,1,2,0,1,0,0);
		SetTileTag(19,21,1,1,2,0,1,0,0);
		SetTileTag(19,22,1,1,2,0,1,0,0);
		SetTileTag(19,23,1,1,2,0,1,0,0);
		SetTileTag(19,24,3,1,2,0,1,0,0);
		SetTileTag(19,25,0,1,2,0,0,0,0);
		SetTileTag(19,26,0,1,2,0,0,0,0);
		SetTileTag(19,27,1,1,24,0,0,0,0);
		SetTileTag(19,28,1,1,24,0,0,0,0);
		SetTileTag(19,29,8,1,20,0,0,0,0);
		SetTileTag(19,30,0,1,30,0,0,0,0);
		SetTileTag(19,31,1,1,14,0,0,0,0);
		SetTileTag(19,32,1,1,14,0,0,0,0);
		SetTileTag(19,33,1,1,14,0,0,0,0);
		SetTileTag(19,34,0,1,30,0,0,0,0);
		SetTileTag(19,35,0,1,30,0,0,0,0);
		SetTileTag(19,36,0,1,24,0,0,0,0);
		SetTileTag(19,37,0,1,24,0,0,0,0);
		SetTileTag(19,38,0,1,24,0,0,0,0);
		SetTileTag(19,39,0,1,24,0,0,0,0);
		SetTileTag(19,40,0,1,24,0,0,0,0);
		SetTileTag(19,41,0,1,24,0,0,0,0);
		SetTileTag(19,42,0,1,24,0,0,0,0);
		SetTileTag(19,43,0,1,24,0,0,0,0);
		SetTileTag(19,44,0,1,24,0,0,0,0);
		SetTileTag(19,45,0,1,24,0,0,0,0);
		SetTileTag(19,46,0,1,8,0,0,0,0);
		SetTileTag(19,47,0,1,8,0,0,0,0);
		SetTileTag(19,48,0,1,8,0,0,0,0);
		SetTileTag(19,49,0,1,8,0,0,0,0);
		SetTileTag(19,50,0,1,8,0,0,0,0);
		SetTileTag(19,51,0,1,8,0,0,0,0);
		SetTileTag(19,52,4,1,18,0,0,0,0);
		SetTileTag(19,53,1,1,18,0,0,0,0);
		SetTileTag(19,54,1,1,18,0,0,0,0);
		SetTileTag(19,55,1,1,18,0,0,0,0);
		SetTileTag(19,56,1,1,18,0,0,0,0);
		SetTileTag(19,57,0,1,24,0,0,0,0);
		SetTileTag(19,58,0,1,24,0,0,0,0);
		SetTileTag(19,59,0,1,24,0,0,0,0);
		SetTileTag(19,60,0,1,24,0,0,0,0);
		SetTileTag(19,61,0,1,30,0,0,0,0);
		SetTileTag(19,62,0,1,30,0,0,0,0);
		SetTileTag(19,63,0,1,30,0,0,0,0);
		SetTileTag(20,0,0,1,30,0,0,0,0);
		SetTileTag(20,1,0,1,30,0,0,0,0);
		SetTileTag(20,2,0,1,22,0,0,0,0);
		SetTileTag(20,3,0,1,22,0,0,0,0);
		SetTileTag(20,4,0,1,24,0,0,0,0);
		SetTileTag(20,5,9,1,20,0,0,0,0);
		SetTileTag(20,6,0,1,24,0,0,0,0);
		SetTileTag(20,7,0,1,24,0,0,0,0);
		SetTileTag(20,8,0,1,24,0,0,0,0);
		SetTileTag(20,9,5,1,18,0,1,0,0);
		SetTileTag(20,10,1,1,18,0,1,0,0);
		SetTileTag(20,11,1,1,20,0,0,0,0);
		SetTileTag(20,12,1,1,20,0,0,0,0);
		SetTileTag(20,13,1,1,20,0,0,0,0);
		SetTileTag(20,14,0,1,2,0,0,0,0);
		SetTileTag(20,15,1,1,24,0,0,0,0);
		SetTileTag(20,16,0,1,2,0,0,0,0);
		SetTileTag(20,17,0,1,2,0,0,0,0);
		SetTileTag(20,18,0,1,2,0,0,0,0);
		SetTileTag(20,19,0,1,2,0,0,0,0);
		SetTileTag(20,20,0,1,2,0,0,0,0);
		SetTileTag(20,21,1,1,2,0,1,0,0);
		SetTileTag(20,22,1,1,2,0,1,0,0);
		SetTileTag(20,23,1,1,2,0,1,0,0);
		SetTileTag(20,24,0,1,2,0,0,0,0);
		SetTileTag(20,25,0,1,24,0,0,0,0);
		SetTileTag(20,26,0,1,2,0,0,0,0);
		SetTileTag(20,27,1,1,24,0,0,0,0);
		SetTileTag(20,28,1,1,24,0,0,0,0);
		SetTileTag(20,29,8,1,22,0,0,0,0);
		SetTileTag(20,30,0,1,30,0,0,0,0);
		SetTileTag(20,31,1,1,14,0,0,0,0);
		SetTileTag(20,32,1,1,14,0,0,0,0);
		SetTileTag(20,33,1,1,14,0,0,0,0);
		SetTileTag(20,34,1,1,8,0,0,0,0);
		SetTileTag(20,35,1,1,8,0,0,0,0);
		SetTileTag(20,36,1,1,8,0,0,0,0);
		SetTileTag(20,37,0,1,24,0,0,0,0);
		SetTileTag(20,38,4,1,6,0,1,0,0);
		SetTileTag(20,39,2,1,6,0,1,0,0);
		SetTileTag(20,40,0,1,24,0,0,0,0);
		SetTileTag(20,41,0,1,24,0,0,0,0);
		SetTileTag(20,42,0,1,24,0,0,0,0);
		SetTileTag(20,43,0,1,24,0,0,0,0);
		SetTileTag(20,44,0,1,24,0,0,0,0);
		SetTileTag(20,45,4,1,8,0,1,0,0);
		SetTileTag(20,46,1,1,8,0,1,0,0);
		SetTileTag(20,47,1,1,8,0,1,0,0);
		SetTileTag(20,48,1,1,8,0,1,0,0);
		SetTileTag(20,49,2,1,8,0,1,0,0);
		SetTileTag(20,50,0,1,8,0,0,0,0);
		SetTileTag(20,51,0,1,8,0,0,0,0);
		SetTileTag(20,52,1,1,18,0,0,0,0);
		SetTileTag(20,53,1,1,18,0,0,0,0);
		SetTileTag(20,54,1,1,18,0,0,0,0);
		SetTileTag(20,55,3,1,18,0,0,0,0);
		SetTileTag(20,56,5,1,18,0,0,0,0);
		SetTileTag(20,57,2,1,18,0,0,0,0);
		SetTileTag(20,58,0,1,24,0,0,0,0);
		SetTileTag(20,59,0,1,24,0,0,0,0);
		SetTileTag(20,60,0,1,30,0,0,0,0);
		SetTileTag(20,61,0,1,30,0,0,0,0);
		SetTileTag(20,62,0,1,30,0,0,0,0);
		SetTileTag(20,63,0,1,30,0,0,0,0);
		SetTileTag(21,0,0,1,30,0,0,0,0);
		SetTileTag(21,1,0,1,30,0,0,0,0);
		SetTileTag(21,2,0,1,22,0,0,0,0);
		SetTileTag(21,3,0,1,22,0,0,0,0);
		SetTileTag(21,4,0,1,20,0,0,0,0);
		SetTileTag(21,5,1,1,20,0,0,0,0);
		SetTileTag(21,6,0,1,30,0,0,0,0);
		SetTileTag(21,7,0,1,24,0,0,0,0);
		SetTileTag(21,8,0,1,30,0,0,0,0);
		SetTileTag(21,9,0,1,24,0,0,0,0);
		SetTileTag(21,10,5,1,18,0,1,0,0);
		SetTileTag(21,11,1,1,20,0,0,0,0);
		SetTileTag(21,12,1,1,20,0,0,0,0);
		SetTileTag(21,13,8,1,20,0,0,0,0);
		SetTileTag(21,14,0,1,2,0,0,0,0);
		SetTileTag(21,15,1,1,24,0,0,1,0);
		SetTileTag(21,16,0,1,2,0,0,0,0);
		SetTileTag(21,17,0,1,2,0,0,0,0);
		SetTileTag(21,18,4,1,26,0,0,0,0);
		SetTileTag(21,19,0,1,26,0,0,0,0);
		SetTileTag(21,20,2,1,26,0,0,0,0);
		SetTileTag(21,21,5,1,2,0,1,0,0);
		SetTileTag(21,22,1,1,2,0,1,0,0);
		SetTileTag(21,23,1,1,2,0,1,0,0);
		SetTileTag(21,24,0,1,2,0,0,0,0);
		SetTileTag(21,25,0,1,24,0,0,0,0);
		SetTileTag(21,26,0,1,2,0,0,0,0);
		SetTileTag(21,27,1,1,24,0,0,0,0);
		SetTileTag(21,28,1,1,24,0,0,0,0);
		SetTileTag(21,29,1,1,24,0,0,0,0);
		SetTileTag(21,30,0,1,30,0,0,0,0);
		SetTileTag(21,31,1,1,14,0,0,0,0);
		SetTileTag(21,32,1,1,14,0,0,0,0);
		SetTileTag(21,33,1,1,14,0,0,0,0);
		SetTileTag(21,34,1,1,8,0,0,0,0);
		SetTileTag(21,35,0,1,30,0,0,0,0);
		SetTileTag(21,36,1,1,6,0,1,0,0);
		SetTileTag(21,37,1,1,6,0,1,0,0);
		SetTileTag(21,38,1,1,6,0,1,0,0);
		SetTileTag(21,39,1,1,6,0,1,0,0);
		SetTileTag(21,40,6,1,6,0,1,0,0);
		SetTileTag(21,41,1,1,8,0,1,0,0);
		SetTileTag(21,42,2,1,8,0,1,0,0);
		SetTileTag(21,43,0,1,24,0,0,0,0);
		SetTileTag(21,44,0,1,8,0,0,0,0);
		SetTileTag(21,45,1,1,8,0,1,0,0);
		SetTileTag(21,46,1,1,8,0,1,0,0);
		SetTileTag(21,47,1,1,8,0,1,0,0);
		SetTileTag(21,48,1,1,8,0,1,0,0);
		SetTileTag(21,49,1,1,8,0,1,0,0);
		SetTileTag(21,50,0,1,8,0,0,0,0);
		SetTileTag(21,51,0,1,8,0,0,0,0);
		SetTileTag(21,52,5,1,18,0,0,0,0);
		SetTileTag(21,53,1,1,18,0,0,0,0);
		SetTileTag(21,54,2,1,18,0,0,0,0);
		SetTileTag(21,55,0,1,30,0,0,0,0);
		SetTileTag(21,56,0,1,30,0,0,0,0);
		SetTileTag(21,57,0,1,24,0,0,0,0);
		SetTileTag(21,58,0,1,30,0,0,0,0);
		SetTileTag(21,59,0,1,30,0,0,0,0);
		SetTileTag(21,60,0,1,30,0,0,0,0);
		SetTileTag(21,61,0,1,30,0,0,0,0);
		SetTileTag(21,62,0,1,30,0,0,0,0);
		SetTileTag(21,63,0,1,30,0,0,0,0);
		SetTileTag(22,0,0,1,30,0,0,0,0);
		SetTileTag(22,1,0,1,24,0,0,0,0);
		SetTileTag(22,2,0,1,22,0,0,0,0);
		SetTileTag(22,3,0,1,30,0,0,0,0);
		SetTileTag(22,4,0,1,30,0,0,0,0);
		SetTileTag(22,5,1,1,20,0,0,1,0);
		SetTileTag(22,6,0,1,30,0,0,0,0);
		SetTileTag(22,7,0,1,30,0,0,0,0);
		SetTileTag(22,8,1,1,20,0,0,0,0);
		SetTileTag(22,9,2,1,20,0,0,0,0);
		SetTileTag(22,10,0,1,30,0,0,0,0);
		SetTileTag(22,11,5,1,20,0,0,0,0);
		SetTileTag(22,12,1,1,20,0,0,0,0);
		SetTileTag(22,13,1,1,22,0,0,0,0);
		SetTileTag(22,14,6,1,22,0,0,0,0);
		SetTileTag(22,15,1,1,24,0,0,0,0);
		SetTileTag(22,16,1,1,24,0,0,0,0);
		SetTileTag(22,17,1,1,24,0,0,1,0);
		SetTileTag(22,18,1,1,24,0,0,0,0);
		SetTileTag(22,19,1,1,24,0,0,0,0);
		SetTileTag(22,20,1,1,24,0,0,0,0);
		SetTileTag(22,21,0,1,4,0,0,0,0);
		SetTileTag(22,22,8,1,2,0,1,0,0);
		SetTileTag(22,23,8,1,2,0,1,0,0);
		SetTileTag(22,24,0,1,4,0,0,0,0);
		SetTileTag(22,25,1,1,24,0,0,0,0);
		SetTileTag(22,26,1,1,24,0,0,1,0);
		SetTileTag(22,27,1,1,24,0,0,0,0);
		SetTileTag(22,28,1,1,24,0,0,0,0);
		SetTileTag(22,29,1,1,24,0,0,0,0);
		SetTileTag(22,30,0,1,30,0,0,0,0);
		SetTileTag(22,31,1,1,14,0,0,0,0);
		SetTileTag(22,32,1,1,14,0,0,0,0);
		SetTileTag(22,33,1,1,14,0,0,0,0);
		SetTileTag(22,34,1,1,8,0,0,0,0);
		SetTileTag(22,35,0,1,30,0,0,0,0);
		SetTileTag(22,36,1,1,8,0,0,0,0);
		SetTileTag(22,37,1,1,6,0,1,0,0);
		SetTileTag(22,38,1,1,6,0,1,0,0);
		SetTileTag(22,39,1,1,6,0,1,0,0);
		SetTileTag(22,40,6,1,6,0,1,0,0);
		SetTileTag(22,41,1,1,8,0,1,0,0);
		SetTileTag(22,42,1,1,8,0,1,0,0);
		SetTileTag(22,43,2,1,8,0,1,0,0);
		SetTileTag(22,44,4,1,8,0,1,0,0);
		SetTileTag(22,45,1,1,8,0,1,0,0);
		SetTileTag(22,46,3,1,8,0,1,0,0);
		SetTileTag(22,47,0,1,8,0,0,0,0);
		SetTileTag(22,48,5,1,8,0,1,0,0);
		SetTileTag(22,49,1,1,8,0,1,0,0);
		SetTileTag(22,50,2,1,8,0,1,0,0);
		SetTileTag(22,51,0,1,8,0,0,0,0);
		SetTileTag(22,52,4,1,18,0,0,0,0);
		SetTileTag(22,53,1,1,18,0,0,0,0);
		SetTileTag(22,54,3,1,18,0,0,0,0);
		SetTileTag(22,55,0,1,30,0,0,0,0);
		SetTileTag(22,56,4,1,8,0,1,0,0);
		SetTileTag(22,57,1,1,8,0,1,0,0);
		SetTileTag(22,58,2,1,8,0,1,0,0);
		SetTileTag(22,59,0,1,30,0,0,0,0);
		SetTileTag(22,60,0,1,30,0,0,0,0);
		SetTileTag(22,61,0,1,30,0,0,0,0);
		SetTileTag(22,62,0,1,30,0,0,0,0);
		SetTileTag(22,63,0,1,30,0,0,0,0);
		SetTileTag(23,0,0,1,30,0,0,0,0);
		SetTileTag(23,1,0,1,30,0,0,0,0);
		SetTileTag(23,2,0,1,24,0,0,0,0);
		SetTileTag(23,3,1,1,20,0,0,0,0);
		SetTileTag(23,4,1,1,20,0,0,0,0);
		SetTileTag(23,5,1,1,20,0,0,0,0);
		SetTileTag(23,6,1,1,20,0,0,0,0);
		SetTileTag(23,7,0,1,30,0,0,0,0);
		SetTileTag(23,8,1,1,20,0,0,0,0);
		SetTileTag(23,9,1,1,20,0,0,0,0);
		SetTileTag(23,10,2,1,20,0,0,0,0);
		SetTileTag(23,11,0,1,20,0,0,0,0);
		SetTileTag(23,12,5,1,20,0,0,0,0);
		SetTileTag(23,13,1,1,20,0,0,0,0);
		SetTileTag(23,14,0,1,30,0,0,0,0);
		SetTileTag(23,15,1,1,24,0,0,0,0);
		SetTileTag(23,16,0,1,30,0,0,0,0);
		SetTileTag(23,17,0,1,30,0,0,0,0);
		SetTileTag(23,18,1,1,24,0,0,0,0);
		SetTileTag(23,19,1,1,24,0,0,0,0);
		SetTileTag(23,20,1,1,24,0,0,0,0);
		SetTileTag(23,21,0,1,4,0,0,0,0);
		SetTileTag(23,22,1,1,4,0,1,0,0);
		SetTileTag(23,23,1,1,4,0,1,0,0);
		SetTileTag(23,24,2,1,4,0,1,0,0);
		SetTileTag(23,25,1,1,24,0,0,0,0);
		SetTileTag(23,26,0,1,24,0,0,0,0);
		SetTileTag(23,27,1,1,24,0,0,0,0);
		SetTileTag(23,28,1,1,24,0,0,0,0);
		SetTileTag(23,29,1,1,24,0,0,0,0);
		SetTileTag(23,30,0,1,0,0,0,0,0);
		SetTileTag(23,31,8,1,14,0,0,0,0);
		SetTileTag(23,32,8,1,14,0,0,0,0);
		SetTileTag(23,33,1,1,14,0,0,0,0);
		SetTileTag(23,34,1,1,8,0,0,0,0);
		SetTileTag(23,35,0,1,8,0,0,0,0);
		SetTileTag(23,36,1,1,6,0,1,0,0);
		SetTileTag(23,37,1,1,6,0,1,0,0);
		SetTileTag(23,38,1,1,6,0,1,0,0);
		SetTileTag(23,39,3,1,6,0,1,0,0);
		SetTileTag(23,40,0,1,8,0,0,0,0);
		SetTileTag(23,41,5,1,8,0,1,0,0);
		SetTileTag(23,42,1,1,8,0,1,0,0);
		SetTileTag(23,43,1,1,8,0,1,0,0);
		SetTileTag(23,44,1,1,8,0,1,0,0);
		SetTileTag(23,45,1,1,8,0,1,0,0);
		SetTileTag(23,46,0,1,8,0,0,0,0);
		SetTileTag(23,47,4,1,16,0,0,0,0);
		SetTileTag(23,48,1,1,16,0,0,0,0);
		SetTileTag(23,49,1,1,8,0,1,0,0);
		SetTileTag(23,50,1,1,8,0,1,0,0);
		SetTileTag(23,51,1,1,16,0,0,0,0);
		SetTileTag(23,52,6,1,16,0,0,0,0);
		SetTileTag(23,53,7,1,16,0,0,0,0);
		SetTileTag(23,54,0,1,30,0,0,0,0);
		SetTileTag(23,55,0,1,30,0,0,0,0);
		SetTileTag(23,56,1,1,8,0,1,0,0);
		SetTileTag(23,57,1,1,8,0,1,0,0);
		SetTileTag(23,58,1,1,8,0,1,0,0);
		SetTileTag(23,59,2,1,8,0,1,0,0);
		SetTileTag(23,60,0,1,30,0,0,0,0);
		SetTileTag(23,61,0,1,30,0,0,0,0);
		SetTileTag(23,62,0,1,30,0,0,0,0);
		SetTileTag(23,63,0,1,30,0,0,0,0);
		SetTileTag(24,0,0,1,30,0,0,0,0);
		SetTileTag(24,1,0,1,30,0,0,0,0);
		SetTileTag(24,2,0,1,24,0,0,0,0);
		SetTileTag(24,3,1,1,20,0,0,0,0);
		SetTileTag(24,4,0,1,20,0,0,0,0);
		SetTileTag(24,5,1,1,20,0,0,0,0);
		SetTileTag(24,6,1,1,20,0,0,0,0);
		SetTileTag(24,7,1,1,20,0,0,1,0);
		SetTileTag(24,8,1,1,20,0,0,0,0);
		SetTileTag(24,9,1,1,20,0,0,0,0);
		SetTileTag(24,10,3,1,20,0,0,0,0);
		SetTileTag(24,11,0,1,20,0,0,0,0);
		SetTileTag(24,12,0,1,20,0,0,0,0);
		SetTileTag(24,13,5,1,20,0,0,0,0);
		SetTileTag(24,14,0,1,24,0,0,0,0);
		SetTileTag(24,15,1,1,24,0,0,0,0);
		SetTileTag(24,16,0,1,24,0,0,0,0);
		SetTileTag(24,17,4,1,24,0,0,0,0);
		SetTileTag(24,18,1,1,24,0,0,0,0);
		SetTileTag(24,19,3,1,24,0,0,0,0);
		SetTileTag(24,20,0,1,24,0,0,0,0);
		SetTileTag(24,21,0,1,4,0,0,0,0);
		SetTileTag(24,22,1,1,4,0,1,0,0);
		SetTileTag(24,23,1,1,4,0,1,0,0);
		SetTileTag(24,24,1,1,4,0,1,0,0);
		SetTileTag(24,25,9,1,22,0,0,0,0);
		SetTileTag(24,26,0,1,30,0,0,0,0);
		SetTileTag(24,27,1,1,24,0,0,0,0);
		SetTileTag(24,28,1,1,24,0,0,0,0);
		SetTileTag(24,29,1,1,24,0,0,0,0);
		SetTileTag(24,30,0,1,30,0,0,0,0);
		SetTileTag(24,31,8,1,16,0,0,0,0);
		SetTileTag(24,32,8,1,16,0,0,0,0);
		SetTileTag(24,33,1,1,14,0,0,0,0);
		SetTileTag(24,34,8,1,8,0,0,0,0);
		SetTileTag(24,35,0,1,30,0,0,0,0);
		SetTileTag(24,36,1,1,6,0,1,0,0);
		SetTileTag(24,37,1,1,6,0,1,0,0);
		SetTileTag(24,38,3,1,6,0,1,0,0);
		SetTileTag(24,39,0,1,30,0,0,0,0);
		SetTileTag(24,40,0,1,8,0,0,0,0);
		SetTileTag(24,41,4,1,8,0,1,0,0);
		SetTileTag(24,42,1,1,8,0,1,0,0);
		SetTileTag(24,43,1,1,8,0,1,0,0);
		SetTileTag(24,44,1,1,8,0,1,0,0);
		SetTileTag(24,45,3,1,8,0,1,0,0);
		SetTileTag(24,46,0,1,18,0,0,0,0);
		SetTileTag(24,47,1,1,16,0,0,0,0);
		SetTileTag(24,48,3,1,16,0,0,0,0);
		SetTileTag(24,49,1,1,8,0,1,0,0);
		SetTileTag(24,50,1,1,8,0,1,0,0);
		SetTileTag(24,51,2,1,10,0,0,0,0);
		SetTileTag(24,52,0,1,30,0,0,0,0);
		SetTileTag(24,53,0,1,30,0,0,0,0);
		SetTileTag(24,54,0,1,30,0,0,0,0);
		SetTileTag(24,55,4,1,8,0,1,0,0);
		SetTileTag(24,56,1,1,8,0,1,0,0);
		SetTileTag(24,57,1,1,8,0,1,0,0);
		SetTileTag(24,58,1,1,8,0,1,0,0);
		SetTileTag(24,59,1,1,8,0,1,0,0);
		SetTileTag(24,60,1,1,8,0,1,0,0);
		SetTileTag(24,61,1,1,8,0,1,0,0);
		SetTileTag(24,62,0,1,30,0,0,0,0);
		SetTileTag(24,63,0,1,30,0,0,0,0);
		SetTileTag(25,0,0,1,30,0,0,0,0);
		SetTileTag(25,1,0,1,30,0,0,0,0);
		SetTileTag(25,2,0,1,24,0,0,0,0);
		SetTileTag(25,3,1,1,20,0,0,0,0);
		SetTileTag(25,4,1,1,20,0,0,0,0);
		SetTileTag(25,5,1,1,20,0,0,0,0);
		SetTileTag(25,6,1,1,20,0,0,0,0);
		SetTileTag(25,7,0,1,24,0,0,0,0);
		SetTileTag(25,8,1,1,20,0,0,0,0);
		SetTileTag(25,9,3,1,20,0,0,0,0);
		SetTileTag(25,10,0,1,20,0,0,0,0);
		SetTileTag(25,11,0,1,10,0,0,0,0);
		SetTileTag(25,12,0,1,24,0,0,0,0);
		SetTileTag(25,13,0,1,20,0,0,0,0);
		SetTileTag(25,14,0,1,24,0,0,0,0);
		SetTileTag(25,15,9,1,22,0,0,0,0);
		SetTileTag(25,16,0,1,24,0,0,0,0);
		SetTileTag(25,17,1,1,24,0,0,0,0);
		SetTileTag(25,18,1,1,24,0,0,0,0);
		SetTileTag(25,19,0,1,24,0,0,0,0);
		SetTileTag(25,20,0,1,26,0,0,0,0);
		SetTileTag(25,21,0,1,4,0,0,0,0);
		SetTileTag(25,22,5,1,4,0,1,0,0);
		SetTileTag(25,23,1,1,4,0,1,0,0);
		SetTileTag(25,24,1,1,4,0,1,0,0);
		SetTileTag(25,25,9,1,20,0,0,0,0);
		SetTileTag(25,26,0,1,30,0,0,0,0);
		SetTileTag(25,27,0,1,30,0,0,0,0);
		SetTileTag(25,28,0,1,30,0,0,0,0);
		SetTileTag(25,29,0,1,30,0,0,0,0);
		SetTileTag(25,30,0,1,30,0,0,0,0);
		SetTileTag(25,31,8,1,18,0,0,0,0);
		SetTileTag(25,32,8,1,18,0,0,0,0);
		SetTileTag(25,33,1,1,14,0,0,0,0);
		SetTileTag(25,34,8,1,10,0,0,0,0);
		SetTileTag(25,35,0,1,30,0,0,0,0);
		SetTileTag(25,36,5,1,6,0,1,0,0);
		SetTileTag(25,37,1,1,6,0,1,0,0);
		SetTileTag(25,38,2,1,6,0,1,0,0);
		SetTileTag(25,39,0,1,30,0,0,0,0);
		SetTileTag(25,40,0,1,8,0,0,0,0);
		SetTileTag(25,41,1,1,8,0,1,0,0);
		SetTileTag(25,42,1,1,8,0,1,0,0);
		SetTileTag(25,43,3,1,8,0,1,0,0);
		SetTileTag(25,44,0,1,8,0,0,0,0);
		SetTileTag(25,45,0,1,8,0,0,0,0);
		SetTileTag(25,46,0,1,8,0,0,0,0);
		SetTileTag(25,47,8,1,16,0,0,0,0);
		SetTileTag(25,48,0,1,10,0,0,0,0);
		SetTileTag(25,49,1,1,8,0,1,0,0);
		SetTileTag(25,50,1,1,8,0,1,0,0);
		SetTileTag(25,51,3,1,10,0,0,0,0);
		SetTileTag(25,52,0,1,30,0,0,0,0);
		SetTileTag(25,53,0,1,30,0,0,0,0);
		SetTileTag(25,54,4,1,8,0,1,0,0);
		SetTileTag(25,55,1,1,8,0,1,0,0);
		SetTileTag(25,56,1,1,8,0,1,0,0);
		SetTileTag(25,57,0,1,22,0,0,0,0);
		SetTileTag(25,58,5,1,8,0,1,0,0);
		SetTileTag(25,59,1,1,8,0,1,0,0);
		SetTileTag(25,60,1,1,8,0,1,0,0);
		SetTileTag(25,61,1,1,8,0,1,0,0);
		SetTileTag(25,62,0,1,30,0,0,0,0);
		SetTileTag(25,63,0,1,30,0,0,0,0);
		SetTileTag(26,0,0,1,30,0,0,0,0);
		SetTileTag(26,1,0,1,30,0,0,0,0);
		SetTileTag(26,2,0,1,24,0,0,0,0);
		SetTileTag(26,3,5,1,20,0,0,0,0);
		SetTileTag(26,4,1,1,20,0,0,0,0);
		SetTileTag(26,5,3,1,20,0,0,0,0);
		SetTileTag(26,6,0,1,24,0,0,0,0);
		SetTileTag(26,7,0,1,24,0,0,0,0);
		SetTileTag(26,8,0,1,24,0,0,0,0);
		SetTileTag(26,9,0,1,24,0,0,0,0);
		SetTileTag(26,10,0,1,24,0,0,0,0);
		SetTileTag(26,11,0,1,10,0,0,0,0);
		SetTileTag(26,12,1,1,20,0,0,0,0);
		SetTileTag(26,13,2,1,20,0,0,0,0);
		SetTileTag(26,14,0,1,24,0,0,0,0);
		SetTileTag(26,15,9,1,20,0,0,0,0);
		SetTileTag(26,16,0,1,24,0,0,0,0);
		SetTileTag(26,17,1,1,24,0,0,0,0);
		SetTileTag(26,18,1,1,24,0,0,0,0);
		SetTileTag(26,19,0,1,24,0,0,0,0);
		SetTileTag(26,20,1,1,20,0,0,0,0);
		SetTileTag(26,21,1,1,20,0,0,1,0);
		SetTileTag(26,22,1,1,20,0,0,0,0);
		SetTileTag(26,23,1,1,4,0,1,0,0);
		SetTileTag(26,24,1,1,4,0,1,0,0);
		SetTileTag(26,25,8,1,20,0,0,0,0);
		SetTileTag(26,26,0,1,30,0,0,0,0);
		SetTileTag(26,27,0,1,30,0,0,0,0);
		SetTileTag(26,28,0,1,30,0,0,0,0);
		SetTileTag(26,29,0,1,30,0,0,0,0);
		SetTileTag(26,30,0,1,30,0,0,0,0);
		SetTileTag(26,31,8,1,20,0,0,0,0);
		SetTileTag(26,32,8,1,20,0,0,0,0);
		SetTileTag(26,33,1,1,14,0,0,0,0);
		SetTileTag(26,34,8,1,12,0,0,0,0);
		SetTileTag(26,35,0,1,30,0,0,0,0);
		SetTileTag(26,36,0,1,30,0,0,0,0);
		SetTileTag(26,37,1,1,6,0,1,0,0);
		SetTileTag(26,38,1,1,6,0,1,0,0);
		SetTileTag(26,39,0,1,30,0,0,0,0);
		SetTileTag(26,40,0,1,8,0,0,0,0);
		SetTileTag(26,41,9,1,6,0,1,0,0);
		SetTileTag(26,42,9,1,6,0,1,0,0);
		SetTileTag(26,43,0,1,8,0,0,0,0);
		SetTileTag(26,44,4,1,16,0,0,0,0);
		SetTileTag(26,45,1,1,16,0,0,0,0);
		SetTileTag(26,46,2,1,16,0,0,0,0);
		SetTileTag(26,47,9,1,16,0,0,0,0);
		SetTileTag(26,48,0,1,8,0,0,0,0);
		SetTileTag(26,49,1,1,8,0,1,0,0);
		SetTileTag(26,50,1,1,8,0,1,0,0);
		SetTileTag(26,51,2,1,8,0,1,0,0);
		SetTileTag(26,52,0,1,30,0,0,0,0);
		SetTileTag(26,53,4,1,8,0,1,0,0);
		SetTileTag(26,54,1,1,8,0,1,0,0);
		SetTileTag(26,55,1,1,8,0,1,0,0);
		SetTileTag(26,56,3,1,8,0,1,0,0);
		SetTileTag(26,57,0,1,22,0,0,0,0);
		SetTileTag(26,58,0,1,30,0,0,0,0);
		SetTileTag(26,59,8,1,8,0,0,0,0);
		SetTileTag(26,60,5,1,8,0,1,0,0);
		SetTileTag(26,61,3,1,8,0,1,0,0);
		SetTileTag(26,62,0,1,30,0,0,0,0);
		SetTileTag(26,63,0,1,30,0,0,0,0);
		SetTileTag(27,0,0,1,30,0,0,0,0);
		SetTileTag(27,1,0,1,30,0,0,0,0);
		SetTileTag(27,2,0,1,24,0,0,0,0);
		SetTileTag(27,3,0,1,24,0,0,0,0);
		SetTileTag(27,4,1,1,20,0,0,0,0);
		SetTileTag(27,5,1,1,20,0,0,0,0);
		SetTileTag(27,6,1,1,20,0,0,0,0);
		SetTileTag(27,7,1,1,20,0,0,0,0);
		SetTileTag(27,8,1,1,20,0,0,0,0);
		SetTileTag(27,9,1,1,20,0,0,0,0);
		SetTileTag(27,10,1,1,20,0,0,0,0);
		SetTileTag(27,11,1,1,20,0,0,0,0);
		SetTileTag(27,12,1,1,20,0,0,0,0);
		SetTileTag(27,13,9,1,18,0,0,0,0);
		SetTileTag(27,14,0,1,24,0,0,0,0);
		SetTileTag(27,15,9,1,18,0,0,0,0);
		SetTileTag(27,16,0,1,24,0,0,0,0);
		SetTileTag(27,17,1,1,24,0,0,0,0);
		SetTileTag(27,18,1,1,24,0,0,0,0);
		SetTileTag(27,19,0,1,26,0,0,0,0);
		SetTileTag(27,20,1,1,20,0,0,0,0);
		SetTileTag(27,21,0,1,4,0,0,0,0);
		SetTileTag(27,22,5,1,20,0,0,0,0);
		SetTileTag(27,23,1,1,4,0,1,0,0);
		SetTileTag(27,24,1,1,4,0,1,0,0);
		SetTileTag(27,25,8,1,22,0,0,0,0);
		SetTileTag(27,26,0,1,30,0,0,0,0);
		SetTileTag(27,27,0,1,30,0,0,0,0);
		SetTileTag(27,28,0,1,30,0,0,0,0);
		SetTileTag(27,29,0,1,30,0,0,0,0);
		SetTileTag(27,30,0,1,30,0,0,0,0);
		SetTileTag(27,31,8,1,22,0,0,0,0);
		SetTileTag(27,32,8,1,22,0,0,0,0);
		SetTileTag(27,33,1,1,14,0,0,0,0);
		SetTileTag(27,34,1,1,14,0,0,0,0);
		SetTileTag(27,35,0,1,30,0,0,0,0);
		SetTileTag(27,36,0,1,30,0,0,0,0);
		SetTileTag(27,37,1,1,6,0,1,0,0);
		SetTileTag(27,38,1,1,6,0,1,0,0);
		SetTileTag(27,39,0,1,6,0,0,0,0);
		SetTileTag(27,40,0,1,6,0,0,0,0);
		SetTileTag(27,41,5,1,6,0,1,0,0);
		SetTileTag(27,42,1,1,6,0,1,0,0);
		SetTileTag(27,43,2,1,6,0,1,0,0);
		SetTileTag(27,44,5,1,16,0,0,0,0);
		SetTileTag(27,45,1,1,16,0,0,0,0);
		SetTileTag(27,46,1,1,16,0,0,0,0);
		SetTileTag(27,47,1,1,16,0,0,0,0);
		SetTileTag(27,48,2,1,16,0,0,0,0);
		SetTileTag(27,49,5,1,8,0,1,0,0);
		SetTileTag(27,50,1,1,8,0,1,0,0);
		SetTileTag(27,51,1,1,8,0,1,0,0);
		SetTileTag(27,52,1,1,8,0,1,0,0);
		SetTileTag(27,53,1,1,8,0,1,0,0);
		SetTileTag(27,54,1,1,8,0,1,0,0);
		SetTileTag(27,55,3,1,8,0,1,0,0);
		SetTileTag(27,56,0,1,22,0,0,0,0);
		SetTileTag(27,57,0,1,22,0,0,0,0);
		SetTileTag(27,58,0,1,30,0,0,0,0);
		SetTileTag(27,59,1,1,10,0,0,0,0);
		SetTileTag(27,60,0,1,30,0,0,0,0);
		SetTileTag(27,61,0,1,30,0,0,0,0);
		SetTileTag(27,62,0,1,30,0,0,0,0);
		SetTileTag(27,63,0,1,30,0,0,0,0);
		SetTileTag(28,0,0,1,30,0,0,0,0);
		SetTileTag(28,1,0,1,30,0,0,0,0);
		SetTileTag(28,2,0,1,24,0,0,0,0);
		SetTileTag(28,3,0,1,24,0,0,0,0);
		SetTileTag(28,4,1,1,20,0,0,0,0);
		SetTileTag(28,5,1,1,20,0,0,0,0);
		SetTileTag(28,6,1,1,20,0,0,0,0);
		SetTileTag(28,7,1,1,20,0,0,0,0);
		SetTileTag(28,8,1,1,20,0,0,0,0);
		SetTileTag(28,9,1,1,20,0,0,0,0);
		SetTileTag(28,10,1,1,20,0,0,0,0);
		SetTileTag(28,11,0,1,24,0,0,0,0);
		SetTileTag(28,12,7,1,18,0,0,0,0);
		SetTileTag(28,13,1,1,18,0,0,0,0);
		SetTileTag(28,14,0,1,24,0,0,0,0);
		SetTileTag(28,15,9,1,16,0,0,0,0);
		SetTileTag(28,16,0,1,24,0,0,0,0);
		SetTileTag(28,17,1,1,24,0,0,0,0);
		SetTileTag(28,18,1,1,24,0,0,0,0);
		SetTileTag(28,19,2,1,24,0,0,0,0);
		SetTileTag(28,20,0,1,24,0,0,0,0);
		SetTileTag(28,21,0,1,4,0,0,0,0);
		SetTileTag(28,22,4,1,4,0,1,0,0);
		SetTileTag(28,23,1,1,4,0,1,0,0);
		SetTileTag(28,24,1,1,4,0,1,0,0);
		SetTileTag(28,25,1,1,24,0,0,0,0);
		SetTileTag(28,26,2,1,24,0,0,0,0);
		SetTileTag(28,27,0,1,30,0,0,0,0);
		SetTileTag(28,28,1,1,24,0,0,0,0);
		SetTileTag(28,29,1,1,24,0,0,0,0);
		SetTileTag(28,30,1,1,24,0,0,0,0);
		SetTileTag(28,31,1,1,24,0,0,0,0);
		SetTileTag(28,32,1,1,24,0,0,0,0);
		SetTileTag(28,33,1,1,24,0,0,0,0);
		SetTileTag(28,34,1,1,24,0,0,0,0);
		SetTileTag(28,35,1,1,24,0,0,0,0);
		SetTileTag(28,36,0,1,30,0,0,0,0);
		SetTileTag(28,37,1,1,6,0,1,0,0);
		SetTileTag(28,38,1,1,6,0,1,0,0);
		SetTileTag(28,39,0,1,6,0,0,0,0);
		SetTileTag(28,40,0,1,6,0,0,0,0);
		SetTileTag(28,41,0,1,6,0,0,0,0);
		SetTileTag(28,42,1,1,6,0,1,0,0);
		SetTileTag(28,43,1,1,6,0,1,0,0);
		SetTileTag(28,44,0,1,6,0,0,0,0);
		SetTileTag(28,45,7,1,16,0,0,0,0);
		SetTileTag(28,46,1,1,16,0,0,0,0);
		SetTileTag(28,47,1,1,16,0,0,0,0);
		SetTileTag(28,48,8,1,16,0,0,0,0);
		SetTileTag(28,49,0,1,30,0,0,0,0);
		SetTileTag(28,50,0,1,30,0,0,0,0);
		SetTileTag(28,51,5,1,8,0,1,0,0);
		SetTileTag(28,52,1,1,8,0,1,0,0);
		SetTileTag(28,53,3,1,8,0,1,0,0);
		SetTileTag(28,54,0,1,30,0,0,0,0);
		SetTileTag(28,55,0,1,30,0,0,0,0);
		SetTileTag(28,56,0,1,22,0,0,0,0);
		SetTileTag(28,57,0,1,24,0,0,0,0);
		SetTileTag(28,58,0,1,22,0,0,0,0);
		SetTileTag(28,59,8,1,10,0,0,0,0);
		SetTileTag(28,60,0,1,30,0,0,0,0);
		SetTileTag(28,61,0,1,30,0,0,0,0);
		SetTileTag(28,62,0,1,8,0,0,0,0);
		SetTileTag(28,63,0,1,30,0,0,0,0);
		SetTileTag(29,0,0,1,30,0,0,0,0);
		SetTileTag(29,1,0,1,30,0,0,0,0);
		SetTileTag(29,2,0,1,30,0,0,0,0);
		SetTileTag(29,3,0,1,30,0,0,0,0);
		SetTileTag(29,4,0,1,30,0,0,0,0);
		SetTileTag(29,5,0,1,24,0,0,0,0);
		SetTileTag(29,6,0,1,20,0,0,0,0);
		SetTileTag(29,7,0,1,20,0,0,0,0);
		SetTileTag(29,8,0,1,26,0,0,0,0);
		SetTileTag(29,9,1,1,20,0,0,0,0);
		SetTileTag(29,10,1,1,20,0,0,0,0);
		SetTileTag(29,11,0,1,24,0,0,0,0);
		SetTileTag(29,12,0,1,24,0,0,0,0);
		SetTileTag(29,13,0,1,24,0,0,0,0);
		SetTileTag(29,14,0,1,24,0,0,0,0);
		SetTileTag(29,15,9,1,14,0,0,0,0);
		SetTileTag(29,16,0,1,24,0,0,0,0);
		SetTileTag(29,17,1,1,24,0,0,0,0);
		SetTileTag(29,18,1,1,24,0,0,0,0);
		SetTileTag(29,19,1,1,24,0,0,0,0);
		SetTileTag(29,20,1,1,24,0,0,0,0);
		SetTileTag(29,21,0,1,4,0,0,0,0);
		SetTileTag(29,22,1,1,4,0,1,0,0);
		SetTileTag(29,23,1,1,4,0,1,0,0);
		SetTileTag(29,24,3,1,4,0,1,0,0);
		SetTileTag(29,25,1,1,24,0,0,0,0);
		SetTileTag(29,26,1,1,24,0,0,0,0);
		SetTileTag(29,27,0,1,30,0,0,0,0);
		SetTileTag(29,28,1,1,24,0,0,0,0);
		SetTileTag(29,29,3,1,24,0,0,0,0);
		SetTileTag(29,30,0,1,30,0,0,0,0);
		SetTileTag(29,31,0,1,0,0,0,0,0);
		SetTileTag(29,32,0,1,0,0,0,0,0);
		SetTileTag(29,33,0,1,30,0,0,0,0);
		SetTileTag(29,34,5,1,24,0,0,0,0);
		SetTileTag(29,35,1,1,24,0,0,0,0);
		SetTileTag(29,36,0,1,30,0,0,0,0);
		SetTileTag(29,37,1,1,6,0,1,0,0);
		SetTileTag(29,38,1,1,6,0,1,0,0);
		SetTileTag(29,39,2,1,6,0,1,0,0);
		SetTileTag(29,40,0,1,6,0,0,0,0);
		SetTileTag(29,41,0,1,6,0,0,0,0);
		SetTileTag(29,42,5,1,6,0,1,0,0);
		SetTileTag(29,43,1,1,6,0,1,0,0);
		SetTileTag(29,44,2,1,6,0,1,0,0);
		SetTileTag(29,45,0,1,6,0,0,0,0);
		SetTileTag(29,46,5,1,16,0,0,0,0);
		SetTileTag(29,47,3,1,16,0,0,0,0);
		SetTileTag(29,48,1,1,18,0,0,0,0);
		SetTileTag(29,49,2,1,18,0,0,0,0);
		SetTileTag(29,50,0,1,8,0,0,0,0);
		SetTileTag(29,51,0,1,8,0,0,0,0);
		SetTileTag(29,52,0,1,30,0,0,0,0);
		SetTileTag(29,53,0,1,30,0,0,0,0);
		SetTileTag(29,54,0,1,30,0,0,0,0);
		SetTileTag(29,55,0,1,30,0,0,0,0);
		SetTileTag(29,56,1,1,24,0,0,0,0);
		SetTileTag(29,57,1,1,24,0,0,0,0);
		SetTileTag(29,58,0,1,18,0,0,0,0);
		SetTileTag(29,59,1,1,12,0,0,0,0);
		SetTileTag(29,60,7,1,10,0,0,0,0);
		SetTileTag(29,61,2,1,10,0,1,0,0);
		SetTileTag(29,62,0,1,18,0,0,0,0);
		SetTileTag(29,63,0,1,30,0,0,0,0);
		SetTileTag(30,0,0,1,30,0,0,0,0);
		SetTileTag(30,1,4,1,24,0,0,0,0);
		SetTileTag(30,2,1,1,24,0,0,0,0);
		SetTileTag(30,3,2,1,24,0,0,0,0);
		SetTileTag(30,4,0,1,24,0,0,0,0);
		SetTileTag(30,5,0,1,24,0,0,0,0);
		SetTileTag(30,6,0,1,24,0,0,0,0);
		SetTileTag(30,7,0,1,24,0,0,0,0);
		SetTileTag(30,8,4,1,24,0,0,0,0);
		SetTileTag(30,9,1,1,20,0,0,0,0);
		SetTileTag(30,10,1,1,20,0,0,0,0);
		SetTileTag(30,11,0,1,24,0,0,0,0);
		SetTileTag(30,12,1,1,12,0,0,0,0);
		SetTileTag(30,13,1,1,14,0,0,0,0);
		SetTileTag(30,14,1,1,14,0,0,0,0);
		SetTileTag(30,15,1,1,14,0,0,0,0);
		SetTileTag(30,16,0,1,24,0,0,0,0);
		SetTileTag(30,17,1,1,24,0,0,0,0);
		SetTileTag(30,18,1,1,22,0,0,0,0);
		SetTileTag(30,19,1,1,22,0,0,0,0);
		SetTileTag(30,20,1,1,24,0,0,0,0);
		SetTileTag(30,21,0,1,4,0,0,0,0);
		SetTileTag(30,22,1,1,4,0,1,0,0);
		SetTileTag(30,23,1,1,4,0,1,0,0);
		SetTileTag(30,24,0,1,4,0,0,0,0);
		SetTileTag(30,25,8,1,24,0,0,0,0);
		SetTileTag(30,26,3,1,24,0,0,0,0);
		SetTileTag(30,27,0,1,30,0,0,0,0);
		SetTileTag(30,28,1,1,24,0,0,0,0);
		SetTileTag(30,29,0,1,30,0,0,0,0);
		SetTileTag(30,30,4,1,8,0,0,0,0);
		SetTileTag(30,31,1,1,8,0,0,0,0);
		SetTileTag(30,32,1,1,8,0,0,0,0);
		SetTileTag(30,33,2,1,8,0,0,0,0);
		SetTileTag(30,34,0,1,30,0,0,0,0);
		SetTileTag(30,35,1,1,24,0,0,0,0);
		SetTileTag(30,36,0,1,30,0,0,0,0);
		SetTileTag(30,37,1,1,6,0,1,0,0);
		SetTileTag(30,38,1,1,6,0,1,0,0);
		SetTileTag(30,39,1,1,6,0,1,0,0);
		SetTileTag(30,40,0,1,6,0,0,0,0);
		SetTileTag(30,41,0,1,6,0,0,0,0);
		SetTileTag(30,42,0,1,6,0,0,0,0);
		SetTileTag(30,43,1,1,6,0,1,0,0);
		SetTileTag(30,44,1,1,6,0,1,0,0);
		SetTileTag(30,45,1,1,6,0,1,0,0);
		SetTileTag(30,46,2,1,6,0,1,0,0);
		SetTileTag(30,47,0,1,6,0,0,0,0);
		SetTileTag(30,48,5,1,18,0,0,0,0);
		SetTileTag(30,49,8,1,18,0,0,0,0);
		SetTileTag(30,50,4,1,20,0,0,0,0);
		SetTileTag(30,51,2,1,20,0,0,0,0);
		SetTileTag(30,52,0,1,8,0,0,0,0);
		SetTileTag(30,53,2,1,24,0,0,0,0);
		SetTileTag(30,54,0,1,30,0,0,0,0);
		SetTileTag(30,55,0,1,30,0,0,0,0);
		SetTileTag(30,56,1,1,24,0,0,0,0);
		SetTileTag(30,57,1,1,24,0,0,0,0);
		SetTileTag(30,58,0,1,18,0,0,0,0);
		SetTileTag(30,59,1,1,12,0,0,0,0);
		SetTileTag(30,60,7,1,10,0,0,0,0);
		SetTileTag(30,61,1,1,10,0,1,0,0);
		SetTileTag(30,62,0,1,8,0,0,0,0);
		SetTileTag(30,63,0,1,30,0,0,0,0);
		SetTileTag(31,0,0,1,30,0,0,0,0);
		SetTileTag(31,1,1,1,24,0,0,0,0);
		SetTileTag(31,2,1,1,24,0,0,0,0);
		SetTileTag(31,3,7,1,22,0,0,0,0);
		SetTileTag(31,4,7,1,20,0,0,0,0);
		SetTileTag(31,5,1,1,20,0,0,0,0);
		SetTileTag(31,6,1,1,20,0,0,0,0);
		SetTileTag(31,7,1,1,20,0,0,0,0);
		SetTileTag(31,8,1,1,20,0,0,0,0);
		SetTileTag(31,9,1,1,20,0,0,0,0);
		SetTileTag(31,10,1,1,20,0,0,0,0);
		SetTileTag(31,11,0,1,24,0,0,0,0);
		SetTileTag(31,12,1,1,14,0,0,0,0);
		SetTileTag(31,13,1,1,14,0,0,0,0);
		SetTileTag(31,14,1,1,14,0,0,0,0);
		SetTileTag(31,15,1,1,14,0,0,0,0);
		SetTileTag(31,16,0,1,24,0,0,0,0);
		SetTileTag(31,17,1,1,24,0,0,0,0);
		SetTileTag(31,18,1,1,20,0,1,0,0);
		SetTileTag(31,19,1,1,20,0,1,0,0);
		SetTileTag(31,20,1,1,24,0,0,0,0);
		SetTileTag(31,21,0,1,4,0,0,0,0);
		SetTileTag(31,22,1,1,4,0,1,0,0);
		SetTileTag(31,23,1,1,4,0,1,0,0);
		SetTileTag(31,24,0,1,4,0,0,0,0);
		SetTileTag(31,25,0,1,24,0,0,0,0);
		SetTileTag(31,26,0,1,24,0,0,0,0);
		SetTileTag(31,27,0,1,30,0,0,0,0);
		SetTileTag(31,28,1,1,24,0,0,0,0);
		SetTileTag(31,29,0,1,24,0,0,0,0);
		SetTileTag(31,30,1,1,8,0,0,0,0);
		SetTileTag(31,31,1,1,0,0,0,0,0);
		SetTileTag(31,32,1,1,0,0,0,0,0);
		SetTileTag(31,33,1,1,8,0,0,0,0);
		SetTileTag(31,34,0,1,0,0,0,0,0);
		SetTileTag(31,35,1,1,24,0,0,0,0);
		SetTileTag(31,36,0,1,30,0,0,0,0);
		SetTileTag(31,37,5,1,6,0,1,0,0);
		SetTileTag(31,38,1,1,6,0,1,0,0);
		SetTileTag(31,39,1,1,6,0,1,0,0);
		SetTileTag(31,40,1,1,6,0,1,0,0);
		SetTileTag(31,41,0,1,6,0,0,0,0);
		SetTileTag(31,42,0,1,6,0,0,0,0);
		SetTileTag(31,43,5,1,6,0,1,0,0);
		SetTileTag(31,44,1,1,6,0,1,0,0);
		SetTileTag(31,45,1,1,6,0,1,0,0);
		SetTileTag(31,46,1,1,6,0,1,0,0);
		SetTileTag(31,47,0,1,6,0,0,0,0);
		SetTileTag(31,48,0,1,30,0,0,0,0);
		SetTileTag(31,49,1,1,20,0,0,0,0);
		SetTileTag(31,50,1,1,20,0,0,0,0);
		SetTileTag(31,51,1,1,20,0,0,0,0);
		SetTileTag(31,52,6,1,20,0,0,0,0);
		SetTileTag(31,53,6,1,22,0,0,0,0);
		SetTileTag(31,54,1,1,24,0,0,0,0);
		SetTileTag(31,55,1,1,24,0,0,1,0);
		SetTileTag(31,56,1,1,24,0,0,0,0);
		SetTileTag(31,57,1,1,24,0,0,0,0);
		SetTileTag(31,58,0,1,8,0,0,0,0);
		SetTileTag(31,59,8,1,12,0,0,0,0);
		SetTileTag(31,60,7,1,10,0,0,0,0);
		SetTileTag(31,61,3,1,10,0,1,0,0);
		SetTileTag(31,62,0,1,8,0,0,0,0);
		SetTileTag(31,63,0,1,30,0,0,0,0);
		SetTileTag(32,0,0,1,30,0,0,0,0);
		SetTileTag(32,1,1,1,24,0,0,0,0);
		SetTileTag(32,2,1,1,24,0,0,0,0);
		SetTileTag(32,3,7,1,22,0,0,0,0);
		SetTileTag(32,4,7,1,20,0,0,0,0);
		SetTileTag(32,5,1,1,20,0,0,0,0);
		SetTileTag(32,6,1,1,20,0,0,0,0);
		SetTileTag(32,7,1,1,20,0,0,0,0);
		SetTileTag(32,8,1,1,20,0,0,0,0);
		SetTileTag(32,9,1,1,20,0,0,0,0);
		SetTileTag(32,10,1,1,20,0,0,0,0);
		SetTileTag(32,11,0,1,24,0,0,0,0);
		SetTileTag(32,12,1,1,14,0,0,0,0);
		SetTileTag(32,13,1,1,14,0,0,0,0);
		SetTileTag(32,14,1,1,14,0,0,0,0);
		SetTileTag(32,15,1,1,14,0,0,0,0);
		SetTileTag(32,16,0,1,24,0,0,0,0);
		SetTileTag(32,17,1,1,24,0,0,0,0);
		SetTileTag(32,18,1,1,20,0,1,0,0);
		SetTileTag(32,19,1,1,20,0,1,0,0);
		SetTileTag(32,20,1,1,24,0,0,0,0);
		SetTileTag(32,21,0,1,4,0,0,0,0);
		SetTileTag(32,22,1,1,4,0,1,0,0);
		SetTileTag(32,23,1,1,4,0,1,0,0);
		SetTileTag(32,24,2,1,4,0,1,0,0);
		SetTileTag(32,25,0,1,4,0,0,0,0);
		SetTileTag(32,26,0,1,24,0,0,0,0);
		SetTileTag(32,27,0,1,30,0,0,0,0);
		SetTileTag(32,28,1,1,24,0,0,0,0);
		SetTileTag(32,29,0,1,0,0,0,0,0);
		SetTileTag(32,30,1,1,8,0,0,0,0);
		SetTileTag(32,31,1,1,0,0,0,0,0);
		SetTileTag(32,32,1,1,0,0,0,0,0);
		SetTileTag(32,33,1,1,8,0,0,0,0);
		SetTileTag(32,34,0,1,0,0,0,0,0);
		SetTileTag(32,35,1,1,24,0,0,0,0);
		SetTileTag(32,36,0,1,24,0,0,0,0);
		SetTileTag(32,37,0,1,24,0,0,0,0);
		SetTileTag(32,38,0,1,30,0,0,0,0);
		SetTileTag(32,39,1,1,6,0,1,0,0);
		SetTileTag(32,40,1,1,6,0,1,0,0);
		SetTileTag(32,41,2,1,6,0,1,0,0);
		SetTileTag(32,42,0,1,6,0,0,0,0);
		SetTileTag(32,43,0,1,6,0,0,0,0);
		SetTileTag(32,44,0,1,6,0,0,0,0);
		SetTileTag(32,45,5,1,6,0,1,0,0);
		SetTileTag(32,46,1,1,6,0,1,0,0);
		SetTileTag(32,47,2,1,6,0,1,0,0);
		SetTileTag(32,48,0,1,30,0,0,0,0);
		SetTileTag(32,49,1,1,20,0,0,0,0);
		SetTileTag(32,50,3,1,20,0,0,0,0);
		SetTileTag(32,51,0,1,30,0,0,0,0);
		SetTileTag(32,52,0,1,30,0,0,0,0);
		SetTileTag(32,53,5,1,24,0,0,0,0);
		SetTileTag(32,54,3,1,24,0,0,0,0);
		SetTileTag(32,55,0,1,24,0,0,0,0);
		SetTileTag(32,56,0,1,18,0,0,0,0);
		SetTileTag(32,57,1,1,24,0,0,0,0);
		SetTileTag(32,58,0,1,8,0,0,0,0);
		SetTileTag(32,59,8,1,14,0,0,0,0);
		SetTileTag(32,60,0,1,24,0,0,0,0);
		SetTileTag(32,61,0,1,8,0,0,0,0);
		SetTileTag(32,62,0,1,8,0,0,0,0);
		SetTileTag(32,63,0,1,30,0,0,0,0);
		SetTileTag(33,0,0,1,30,0,0,0,0);
		SetTileTag(33,1,5,1,24,0,0,0,0);
		SetTileTag(33,2,1,1,24,0,0,0,0);
		SetTileTag(33,3,3,1,24,0,0,0,0);
		SetTileTag(33,4,0,1,24,0,0,0,0);
		SetTileTag(33,5,0,1,24,0,0,0,0);
		SetTileTag(33,6,0,1,24,0,0,0,0);
		SetTileTag(33,7,0,1,24,0,0,0,0);
		SetTileTag(33,8,1,1,20,0,0,1,0);
		SetTileTag(33,9,0,1,24,0,0,0,0);
		SetTileTag(33,10,0,1,24,0,0,0,0);
		SetTileTag(33,11,0,1,24,0,0,0,0);
		SetTileTag(33,12,1,1,14,0,0,0,0);
		SetTileTag(33,13,1,1,14,0,0,0,0);
		SetTileTag(33,14,1,1,14,0,0,0,0);
		SetTileTag(33,15,1,1,14,0,0,0,0);
		SetTileTag(33,16,0,1,24,0,0,0,0);
		SetTileTag(33,17,1,1,24,0,0,0,0);
		SetTileTag(33,18,1,1,22,0,0,0,0);
		SetTileTag(33,19,1,1,22,0,0,0,0);
		SetTileTag(33,20,1,1,24,0,0,0,0);
		SetTileTag(33,21,0,1,4,0,0,0,0);
		SetTileTag(33,22,1,1,4,0,1,0,0);
		SetTileTag(33,23,1,1,4,0,1,0,0);
		SetTileTag(33,24,1,1,4,0,1,0,0);
		SetTileTag(33,25,0,1,4,0,0,0,0);
		SetTileTag(33,26,0,1,30,0,0,0,0);
		SetTileTag(33,27,0,1,30,0,0,0,0);
		SetTileTag(33,28,1,1,24,0,0,0,0);
		SetTileTag(33,29,0,1,30,0,0,0,0);
		SetTileTag(33,30,5,1,8,0,0,0,0);
		SetTileTag(33,31,1,1,8,0,0,0,0);
		SetTileTag(33,32,1,1,8,0,0,0,0);
		SetTileTag(33,33,3,1,8,0,0,0,0);
		SetTileTag(33,34,0,1,30,0,0,0,0);
		SetTileTag(33,35,1,1,24,0,0,0,0);
		SetTileTag(33,36,0,1,24,0,0,0,0);
		SetTileTag(33,37,0,1,24,0,0,0,0);
		SetTileTag(33,38,0,1,30,0,0,0,0);
		SetTileTag(33,39,5,1,6,0,1,0,0);
		SetTileTag(33,40,1,1,6,0,1,0,0);
		SetTileTag(33,41,1,1,6,0,1,0,0);
		SetTileTag(33,42,0,1,6,0,0,0,0);
		SetTileTag(33,43,0,1,6,0,0,0,0);
		SetTileTag(33,44,0,1,6,0,0,0,0);
		SetTileTag(33,45,4,1,6,0,1,0,0);
		SetTileTag(33,46,1,1,6,0,1,0,0);
		SetTileTag(33,47,3,1,6,0,1,0,0);
		SetTileTag(33,48,4,1,18,0,0,0,0);
		SetTileTag(33,49,9,1,18,0,0,0,0);
		SetTileTag(33,50,0,1,30,0,0,0,0);
		SetTileTag(33,51,0,1,30,0,0,0,0);
		SetTileTag(33,52,0,1,30,0,0,0,0);
		SetTileTag(33,53,0,1,30,0,0,0,0);
		SetTileTag(33,54,0,1,8,0,0,0,0);
		SetTileTag(33,55,0,1,8,0,0,0,0);
		SetTileTag(33,56,0,1,18,0,0,0,0);
		SetTileTag(33,57,1,1,24,0,0,0,0);
		SetTileTag(33,58,0,1,8,0,0,0,0);
		SetTileTag(33,59,1,1,16,0,0,0,0);
		SetTileTag(33,60,6,1,16,0,0,0,0);
		SetTileTag(33,61,1,1,18,0,0,0,0);
		SetTileTag(33,62,0,1,8,0,0,0,0);
		SetTileTag(33,63,0,1,30,0,0,0,0);
		SetTileTag(34,0,0,1,30,0,0,0,0);
		SetTileTag(34,1,0,1,30,0,0,0,0);
		SetTileTag(34,2,0,1,30,0,0,0,0);
		SetTileTag(34,3,0,1,24,0,0,0,0);
		SetTileTag(34,4,0,1,24,0,0,0,0);
		SetTileTag(34,5,0,1,24,0,0,0,0);
		SetTileTag(34,6,0,1,18,0,0,0,0);
		SetTileTag(34,7,0,1,24,0,0,0,0);
		SetTileTag(34,8,1,1,20,0,0,0,0);
		SetTileTag(34,9,1,1,20,0,0,0,0);
		SetTileTag(34,10,1,1,20,0,0,0,0);
		SetTileTag(34,11,0,1,24,0,0,0,0);
		SetTileTag(34,12,0,1,24,0,0,0,0);
		SetTileTag(34,13,0,1,24,0,0,0,0);
		SetTileTag(34,14,0,1,24,0,0,0,0);
		SetTileTag(34,15,0,1,24,0,0,0,0);
		SetTileTag(34,16,0,1,24,0,0,0,0);
		SetTileTag(34,17,1,1,24,0,0,0,0);
		SetTileTag(34,18,1,1,24,0,0,0,0);
		SetTileTag(34,19,1,1,24,0,0,0,0);
		SetTileTag(34,20,1,1,24,0,0,0,0);
		SetTileTag(34,21,0,1,4,0,0,0,0);
		SetTileTag(34,22,1,1,4,0,1,0,0);
		SetTileTag(34,23,1,1,4,0,1,0,0);
		SetTileTag(34,24,1,1,4,0,1,0,0);
		SetTileTag(34,25,2,1,4,0,1,0,0);
		SetTileTag(34,26,0,1,30,0,0,0,0);
		SetTileTag(34,27,0,1,30,0,0,0,0);
		SetTileTag(34,28,1,1,24,0,0,0,0);
		SetTileTag(34,29,2,1,24,0,0,0,0);
		SetTileTag(34,30,0,1,30,0,0,0,0);
		SetTileTag(34,31,0,1,0,0,0,0,0);
		SetTileTag(34,32,0,1,0,0,0,0,0);
		SetTileTag(34,33,0,1,30,0,0,0,0);
		SetTileTag(34,34,4,1,24,0,0,0,0);
		SetTileTag(34,35,1,1,24,0,0,0,0);
		SetTileTag(34,36,0,1,24,0,0,0,0);
		SetTileTag(34,37,0,1,30,0,0,0,0);
		SetTileTag(34,38,0,1,30,0,0,0,0);
		SetTileTag(34,39,0,1,30,0,0,0,0);
		SetTileTag(34,40,1,1,6,0,1,0,0);
		SetTileTag(34,41,1,1,6,0,1,0,0);
		SetTileTag(34,42,0,1,6,0,0,0,0);
		SetTileTag(34,43,4,1,6,0,1,0,0);
		SetTileTag(34,44,1,1,6,0,1,0,0);
		SetTileTag(34,45,1,1,6,0,1,0,0);
		SetTileTag(34,46,1,1,6,0,1,0,0);
		SetTileTag(34,47,0,1,6,0,0,0,0);
		SetTileTag(34,48,5,1,18,0,0,0,0);
		SetTileTag(34,49,1,1,18,0,0,0,0);
		SetTileTag(34,50,2,1,18,0,0,0,0);
		SetTileTag(34,51,4,1,20,0,0,0,0);
		SetTileTag(34,52,2,1,20,0,0,0,0);
		SetTileTag(34,53,4,1,20,0,0,0,0);
		SetTileTag(34,54,0,1,8,0,0,0,0);
		SetTileTag(34,55,0,1,8,0,0,0,0);
		SetTileTag(34,56,0,1,18,0,0,0,0);
		SetTileTag(34,57,1,1,24,0,0,0,0);
		SetTileTag(34,58,0,1,24,0,0,0,0);
		SetTileTag(34,59,0,1,18,0,0,0,0);
		SetTileTag(34,60,0,1,24,0,0,0,0);
		SetTileTag(34,61,8,1,18,0,0,0,0);
		SetTileTag(34,62,0,1,8,0,0,0,0);
		SetTileTag(34,63,0,1,30,0,0,0,0);
		SetTileTag(35,0,0,1,30,0,0,0,0);
		SetTileTag(35,1,0,1,30,0,0,0,0);
		SetTileTag(35,2,4,1,24,0,0,0,0);
		SetTileTag(35,3,8,1,20,0,0,0,0);
		SetTileTag(35,4,1,1,24,0,0,0,0);
		SetTileTag(35,5,2,1,24,0,0,0,0);
		SetTileTag(35,6,0,1,20,0,0,0,0);
		SetTileTag(35,7,0,1,24,0,0,0,0);
		SetTileTag(35,8,5,1,20,0,0,0,0);
		SetTileTag(35,9,1,1,20,0,0,0,0);
		SetTileTag(35,10,1,1,20,0,0,0,0);
		SetTileTag(35,11,0,1,24,0,0,0,0);
		SetTileTag(35,12,0,1,24,0,0,0,0);
		SetTileTag(35,13,0,1,24,0,0,0,0);
		SetTileTag(35,14,0,1,24,0,0,0,0);
		SetTileTag(35,15,0,1,24,0,0,0,0);
		SetTileTag(35,16,0,1,24,0,0,0,0);
		SetTileTag(35,17,0,1,20,0,0,0,0);
		SetTileTag(35,18,0,1,20,0,0,0,0);
		SetTileTag(35,19,0,1,20,0,0,0,0);
		SetTileTag(35,20,0,1,20,0,0,0,0);
		SetTileTag(35,21,0,1,4,0,0,0,0);
		SetTileTag(35,22,5,1,4,0,1,0,0);
		SetTileTag(35,23,1,1,4,0,1,0,0);
		SetTileTag(35,24,1,1,4,0,1,0,0);
		SetTileTag(35,25,1,1,4,0,1,0,0);
		SetTileTag(35,26,0,1,24,0,0,0,0);
		SetTileTag(35,27,4,1,24,0,0,0,0);
		SetTileTag(35,28,1,1,24,0,0,0,0);
		SetTileTag(35,29,1,1,24,0,0,0,0);
		SetTileTag(35,30,1,1,24,0,0,0,0);
		SetTileTag(35,31,1,1,24,0,0,0,0);
		SetTileTag(35,32,1,1,24,0,0,0,0);
		SetTileTag(35,33,1,1,24,0,0,0,0);
		SetTileTag(35,34,1,1,24,0,0,0,0);
		SetTileTag(35,35,1,1,24,0,0,0,0);
		SetTileTag(35,36,1,1,24,0,0,0,0);
		SetTileTag(35,37,1,1,24,0,0,0,0);
		SetTileTag(35,38,2,1,24,0,0,0,0);
		SetTileTag(35,39,0,1,24,0,0,0,0);
		SetTileTag(35,40,1,1,6,0,1,0,0);
		SetTileTag(35,41,1,1,6,0,1,0,0);
		SetTileTag(35,42,1,1,6,0,1,0,0);
		SetTileTag(35,43,1,1,6,0,1,0,0);
		SetTileTag(35,44,1,1,6,0,1,0,0);
		SetTileTag(35,45,1,1,6,0,1,0,0);
		SetTileTag(35,46,3,1,6,0,1,0,0);
		SetTileTag(35,47,0,1,6,0,0,0,0);
		SetTileTag(35,48,0,1,6,0,0,0,0);
		SetTileTag(35,49,8,1,18,0,0,0,0);
		SetTileTag(35,50,1,1,18,0,0,0,0);
		SetTileTag(35,51,6,1,18,0,0,0,0);
		SetTileTag(35,52,1,1,20,0,0,0,0);
		SetTileTag(35,53,6,1,20,0,0,0,0);
		SetTileTag(35,54,2,1,22,0,0,0,0);
		SetTileTag(35,55,0,1,8,0,0,0,0);
		SetTileTag(35,56,0,1,18,0,0,0,0);
		SetTileTag(35,57,1,1,24,0,0,0,0);
		SetTileTag(35,58,1,1,24,0,0,1,0);
		SetTileTag(35,59,7,1,22,0,0,0,0);
		SetTileTag(35,60,7,1,20,0,0,0,0);
		SetTileTag(35,61,1,1,20,0,0,0,0);
		SetTileTag(35,62,0,1,8,0,0,0,0);
		SetTileTag(35,63,0,1,30,0,0,0,0);
		SetTileTag(36,0,0,1,30,0,0,0,0);
		SetTileTag(36,1,0,1,30,0,0,0,0);
		SetTileTag(36,2,1,1,24,0,0,0,0);
		SetTileTag(36,3,1,1,22,0,0,0,0);
		SetTileTag(36,4,6,1,22,0,0,0,0);
		SetTileTag(36,5,7,1,22,0,0,0,0);
		SetTileTag(36,6,7,1,20,0,0,0,0);
		SetTileTag(36,7,1,1,20,0,0,0,0);
		SetTileTag(36,8,1,1,20,0,0,1,0);
		SetTileTag(36,9,1,1,20,0,0,0,0);
		SetTileTag(36,10,1,1,20,0,0,0,0);
		SetTileTag(36,11,0,1,24,0,0,0,0);
		SetTileTag(36,12,0,1,24,0,0,0,0);
		SetTileTag(36,13,0,1,24,0,0,0,0);
		SetTileTag(36,14,0,1,24,0,0,0,0);
		SetTileTag(36,15,0,1,24,0,0,0,0);
		SetTileTag(36,16,0,1,24,0,0,0,0);
		SetTileTag(36,17,0,1,20,0,0,0,0);
		SetTileTag(36,18,0,1,20,0,0,0,0);
		SetTileTag(36,19,0,1,20,0,0,0,0);
		SetTileTag(36,20,0,1,20,0,0,0,0);
		SetTileTag(36,21,0,1,4,0,0,0,0);
		SetTileTag(36,22,4,1,24,0,0,0,0);
		SetTileTag(36,23,1,1,24,0,0,0,0);
		SetTileTag(36,24,1,1,4,0,1,0,0);
		SetTileTag(36,25,1,1,4,0,1,0,0);
		SetTileTag(36,26,1,1,24,0,0,0,0);
		SetTileTag(36,27,1,1,24,0,0,0,0);
		SetTileTag(36,28,1,1,24,0,0,0,0);
		SetTileTag(36,29,7,1,22,0,0,0,0);
		SetTileTag(36,30,7,1,20,0,0,0,0);
		SetTileTag(36,31,1,1,20,0,0,0,0);
		SetTileTag(36,32,1,1,20,0,0,0,0);
		SetTileTag(36,33,6,1,20,0,0,0,0);
		SetTileTag(36,34,6,1,22,0,0,0,0);
		SetTileTag(36,35,1,1,24,0,0,0,0);
		SetTileTag(36,36,1,1,24,0,0,0,0);
		SetTileTag(36,37,1,1,24,0,0,0,0);
		SetTileTag(36,38,1,1,24,0,0,0,0);
		SetTileTag(36,39,0,1,24,0,0,0,0);
		SetTileTag(36,40,5,1,6,0,1,0,0);
		SetTileTag(36,41,1,1,6,0,1,0,0);
		SetTileTag(36,42,1,1,6,0,1,0,0);
		SetTileTag(36,43,3,1,6,0,1,0,0);
		SetTileTag(36,44,5,1,6,0,1,0,0);
		SetTileTag(36,45,1,1,6,0,1,0,0);
		SetTileTag(36,46,0,1,6,0,0,0,0);
		SetTileTag(36,47,4,1,18,0,0,0,0);
		SetTileTag(36,48,6,1,18,0,0,0,0);
		SetTileTag(36,49,1,1,20,0,0,0,0);
		SetTileTag(36,50,5,1,18,0,0,0,0);
		SetTileTag(36,51,3,1,18,0,0,0,0);
		SetTileTag(36,52,0,1,8,0,0,0,0);
		SetTileTag(36,53,1,1,22,0,0,0,0);
		SetTileTag(36,54,1,1,22,0,0,0,0);
		SetTileTag(36,55,0,1,8,0,0,0,0);
		SetTileTag(36,56,0,1,18,0,0,0,0);
		SetTileTag(36,57,1,1,24,0,0,0,0);
		SetTileTag(36,58,0,1,8,0,0,0,0);
		SetTileTag(36,59,0,1,24,0,0,0,0);
		SetTileTag(36,60,0,1,8,0,0,0,0);
		SetTileTag(36,61,0,1,8,0,0,0,0);
		SetTileTag(36,62,0,1,8,0,0,0,0);
		SetTileTag(36,63,0,1,30,0,0,0,0);
		SetTileTag(37,0,0,1,30,0,0,0,0);
		SetTileTag(37,1,0,1,30,0,0,0,0);
		SetTileTag(37,2,5,1,24,0,0,0,0);
		SetTileTag(37,3,9,1,20,0,0,0,0);
		SetTileTag(37,4,1,1,24,0,0,0,0);
		SetTileTag(37,5,3,1,24,0,0,0,0);
		SetTileTag(37,6,0,1,20,0,0,0,0);
		SetTileTag(37,7,0,1,24,0,0,0,0);
		SetTileTag(37,8,4,1,20,0,0,0,0);
		SetTileTag(37,9,1,1,20,0,0,0,0);
		SetTileTag(37,10,1,1,20,0,0,0,0);
		SetTileTag(37,11,1,1,20,0,0,0,0);
		SetTileTag(37,12,1,1,20,0,0,1,0);
		SetTileTag(37,13,1,1,20,0,0,0,0);
		SetTileTag(37,14,1,1,20,0,0,0,0);
		SetTileTag(37,15,1,1,20,0,0,0,0);
		SetTileTag(37,16,1,1,20,0,0,0,0);
		SetTileTag(37,17,1,1,20,0,0,0,0);
		SetTileTag(37,18,1,1,20,0,0,0,0);
		SetTileTag(37,19,6,1,20,0,0,0,0);
		SetTileTag(37,20,6,1,22,0,0,0,0);
		SetTileTag(37,21,1,1,24,0,0,0,0);
		SetTileTag(37,22,1,1,24,0,0,0,0);
		SetTileTag(37,23,1,1,24,0,0,0,0);
		SetTileTag(37,24,8,1,4,0,1,0,0);
		SetTileTag(37,25,8,1,4,0,1,0,0);
		SetTileTag(37,26,1,1,24,0,0,0,0);
		SetTileTag(37,27,1,1,24,0,0,0,0);
		SetTileTag(37,28,1,1,24,0,0,0,0);
		SetTileTag(37,29,1,1,24,0,0,0,0);
		SetTileTag(37,30,1,1,24,0,0,0,0);
		SetTileTag(37,31,1,1,24,0,0,0,0);
		SetTileTag(37,32,1,1,24,0,0,0,0);
		SetTileTag(37,33,1,1,24,0,0,0,0);
		SetTileTag(37,34,1,1,24,0,0,0,0);
		SetTileTag(37,35,1,1,24,0,0,0,0);
		SetTileTag(37,36,1,1,24,0,0,0,0);
		SetTileTag(37,37,1,1,24,0,0,0,0);
		SetTileTag(37,38,1,1,24,0,0,0,0);
		SetTileTag(37,39,0,1,6,0,0,0,0);
		SetTileTag(37,40,4,1,6,0,1,0,0);
		SetTileTag(37,41,1,1,6,0,1,0,0);
		SetTileTag(37,42,3,1,6,0,1,0,0);
		SetTileTag(37,43,0,1,6,0,0,0,0);
		SetTileTag(37,44,0,1,6,0,0,0,0);
		SetTileTag(37,45,3,1,6,0,1,0,0);
		SetTileTag(37,46,0,1,6,0,0,0,0);
		SetTileTag(37,47,5,1,18,0,0,0,0);
		SetTileTag(37,48,6,1,18,0,0,0,0);
		SetTileTag(37,49,3,1,20,0,0,0,0);
		SetTileTag(37,50,0,1,6,0,0,0,0);
		SetTileTag(37,51,0,1,8,0,0,0,0);
		SetTileTag(37,52,0,1,22,0,0,0,0);
		SetTileTag(37,53,1,1,22,0,0,0,0);
		SetTileTag(37,54,1,1,22,0,0,0,0);
		SetTileTag(37,55,0,1,8,0,0,0,0);
		SetTileTag(37,56,0,1,18,0,0,0,0);
		SetTileTag(37,57,1,1,24,0,0,0,0);
		SetTileTag(37,58,7,1,22,0,0,0,0);
		SetTileTag(37,59,7,1,20,0,0,0,0);
		SetTileTag(37,60,7,1,18,0,0,0,0);
		SetTileTag(37,61,2,1,18,0,0,0,0);
		SetTileTag(37,62,0,1,8,0,0,0,0);
		SetTileTag(37,63,0,1,30,0,0,0,0);
		SetTileTag(38,0,0,1,30,0,0,0,0);
		SetTileTag(38,1,0,1,30,0,0,0,0);
		SetTileTag(38,2,0,1,30,0,0,0,0);
		SetTileTag(38,3,1,1,20,0,0,0,0);
		SetTileTag(38,4,1,1,20,0,0,0,0);
		SetTileTag(38,5,1,1,20,0,0,1,0);
		SetTileTag(38,6,1,1,20,0,0,0,0);
		SetTileTag(38,7,0,1,30,0,0,0,0);
		SetTileTag(38,8,1,1,20,0,0,0,0);
		SetTileTag(38,9,1,1,20,0,0,0,0);
		SetTileTag(38,10,1,1,20,0,0,0,0);
		SetTileTag(38,11,0,1,30,0,0,0,0);
		SetTileTag(38,12,0,1,30,0,0,0,0);
		SetTileTag(38,13,0,1,30,0,0,0,0);
		SetTileTag(38,14,0,1,30,0,0,0,0);
		SetTileTag(38,15,0,1,30,0,0,0,0);
		SetTileTag(38,16,0,1,30,0,0,0,0);
		SetTileTag(38,17,0,1,30,0,0,0,0);
		SetTileTag(38,18,0,1,30,0,0,0,0);
		SetTileTag(38,19,0,1,20,0,0,0,0);
		SetTileTag(38,20,0,1,20,0,0,0,0);
		SetTileTag(38,21,0,1,20,0,0,0,0);
		SetTileTag(38,22,5,1,24,0,0,0,0);
		SetTileTag(38,23,1,1,24,0,0,0,0);
		SetTileTag(38,24,1,1,6,0,1,0,0);
		SetTileTag(38,25,1,1,6,0,1,0,0);
		SetTileTag(38,26,1,1,24,0,0,0,0);
		SetTileTag(38,27,1,1,24,0,0,0,0);
		SetTileTag(38,28,3,1,24,0,0,0,0);
		SetTileTag(38,29,0,1,6,0,0,0,0);
		SetTileTag(38,30,0,1,6,0,0,0,0);
		SetTileTag(38,31,0,1,30,0,0,0,0);
		SetTileTag(38,32,0,1,30,0,0,0,0);
		SetTileTag(38,33,0,1,30,0,0,0,0);
		SetTileTag(38,34,0,1,30,0,0,0,0);
		SetTileTag(38,35,0,1,30,0,0,0,0);
		SetTileTag(38,36,5,1,24,0,0,0,0);
		SetTileTag(38,37,1,1,24,0,0,0,0);
		SetTileTag(38,38,1,1,24,0,0,0,0);
		SetTileTag(38,39,1,1,6,0,1,0,0);
		SetTileTag(38,40,1,1,6,0,1,0,0);
		SetTileTag(38,41,1,1,6,0,1,0,0);
		SetTileTag(38,42,1,1,24,0,0,0,0);
		SetTileTag(38,43,1,1,24,0,0,0,0);
		SetTileTag(38,44,0,1,6,0,0,0,0);
		SetTileTag(38,45,0,1,6,0,0,0,0);
		SetTileTag(38,46,0,1,6,0,0,0,0);
		SetTileTag(38,47,0,1,6,0,0,0,0);
		SetTileTag(38,48,0,1,6,0,0,0,0);
		SetTileTag(38,49,0,1,6,0,0,0,0);
		SetTileTag(38,50,0,1,6,0,0,0,0);
		SetTileTag(38,51,0,1,8,0,0,0,0);
		SetTileTag(38,52,0,1,8,0,0,0,0);
		SetTileTag(38,53,5,1,22,0,0,0,0);
		SetTileTag(38,54,3,1,22,0,0,0,0);
		SetTileTag(38,55,0,1,8,0,0,0,0);
		SetTileTag(38,56,1,1,24,0,0,0,0);
		SetTileTag(38,57,1,1,24,0,0,0,0);
		SetTileTag(38,58,7,1,22,0,0,0,0);
		SetTileTag(38,59,7,1,20,0,0,0,0);
		SetTileTag(38,60,7,1,18,0,0,0,0);
		SetTileTag(38,61,7,1,16,0,0,0,0);
		SetTileTag(38,62,0,1,8,0,0,0,0);
		SetTileTag(38,63,0,1,30,0,0,0,0);
		SetTileTag(39,0,0,1,30,0,0,0,0);
		SetTileTag(39,1,0,1,30,0,0,0,0);
		SetTileTag(39,2,0,1,30,0,0,0,0);
		SetTileTag(39,3,0,1,24,0,0,0,0);
		SetTileTag(39,4,0,1,24,0,0,0,0);
		SetTileTag(39,5,0,1,30,0,0,0,0);
		SetTileTag(39,6,9,1,18,0,0,0,0);
		SetTileTag(39,7,0,1,30,0,0,0,0);
		SetTileTag(39,8,0,1,30,0,0,0,0);
		SetTileTag(39,9,0,1,30,0,0,0,0);
		SetTileTag(39,10,0,1,24,0,0,0,0);
		SetTileTag(39,11,0,1,30,0,0,0,0);
		SetTileTag(39,12,0,1,30,0,0,0,0);
		SetTileTag(39,13,0,1,30,0,0,0,0);
		SetTileTag(39,14,0,1,30,0,0,0,0);
		SetTileTag(39,15,0,1,30,0,0,0,0);
		SetTileTag(39,16,0,1,30,0,0,0,0);
		SetTileTag(39,17,0,1,30,0,0,0,0);
		SetTileTag(39,18,0,1,30,0,0,0,0);
		SetTileTag(39,19,0,1,30,0,0,0,0);
		SetTileTag(39,20,0,1,30,0,0,0,0);
		SetTileTag(39,21,0,1,30,0,0,0,0);
		SetTileTag(39,22,0,1,30,0,0,0,0);
		SetTileTag(39,23,0,1,30,0,0,0,0);
		SetTileTag(39,24,5,1,6,0,1,0,0);
		SetTileTag(39,25,1,1,6,0,1,0,0);
		SetTileTag(39,26,1,1,6,0,1,0,0);
		SetTileTag(39,27,1,1,20,0,0,0,0);
		SetTileTag(39,28,2,1,20,0,0,0,0);
		SetTileTag(39,29,0,1,6,0,0,0,0);
		SetTileTag(39,30,0,1,6,0,0,0,0);
		SetTileTag(39,31,0,1,30,0,0,0,0);
		SetTileTag(39,32,0,1,30,0,0,0,0);
		SetTileTag(39,33,0,1,30,0,0,0,0);
		SetTileTag(39,34,0,1,30,0,0,0,0);
		SetTileTag(39,35,0,1,30,0,0,0,0);
		SetTileTag(39,36,0,1,30,0,0,0,0);
		SetTileTag(39,37,1,1,24,0,0,0,0);
		SetTileTag(39,38,1,1,24,0,0,0,0);
		SetTileTag(39,39,1,1,6,0,1,0,0);
		SetTileTag(39,40,1,1,6,0,1,0,0);
		SetTileTag(39,41,1,1,6,0,1,0,0);
		SetTileTag(39,42,1,1,24,0,0,0,0);
		SetTileTag(39,43,1,1,24,0,0,0,0);
		SetTileTag(39,44,0,1,6,0,0,0,0);
		SetTileTag(39,45,0,1,6,0,0,0,0);
		SetTileTag(39,46,0,1,30,0,0,0,0);
		SetTileTag(39,47,0,1,8,0,0,0,0);
		SetTileTag(39,48,0,1,8,0,0,0,0);
		SetTileTag(39,49,0,1,8,0,0,0,0);
		SetTileTag(39,50,0,1,30,0,0,0,0);
		SetTileTag(39,51,0,1,8,0,0,0,0);
		SetTileTag(39,52,0,1,8,0,0,0,0);
		SetTileTag(39,53,0,1,30,0,0,0,0);
		SetTileTag(39,54,0,1,30,0,0,0,0);
		SetTileTag(39,55,0,1,8,0,0,0,0);
		SetTileTag(39,56,1,1,24,0,0,0,0);
		SetTileTag(39,57,1,1,24,0,0,0,0);
		SetTileTag(39,58,7,1,22,0,0,0,0);
		SetTileTag(39,59,7,1,20,0,0,0,0);
		SetTileTag(39,60,7,1,18,0,0,0,0);
		SetTileTag(39,61,3,1,18,0,0,0,0);
		SetTileTag(39,62,0,1,8,0,0,0,0);
		SetTileTag(39,63,0,1,30,0,0,0,0);
		SetTileTag(40,0,0,1,30,0,0,0,0);
		SetTileTag(40,1,0,1,30,0,0,0,0);
		SetTileTag(40,2,0,1,26,0,0,0,0);
		SetTileTag(40,3,0,1,26,0,0,0,0);
		SetTileTag(40,4,0,1,26,0,0,0,0);
		SetTileTag(40,5,0,1,26,0,0,0,0);
		SetTileTag(40,6,9,1,16,0,0,0,0);
		SetTileTag(40,7,0,1,0,0,0,0,0);
		SetTileTag(40,8,0,1,0,0,0,0,0);
		SetTileTag(40,9,0,1,0,0,0,0,0);
		SetTileTag(40,10,0,1,0,0,0,0,0);
		SetTileTag(40,11,0,1,0,0,0,0,0);
		SetTileTag(40,12,0,1,0,0,0,0,0);
		SetTileTag(40,13,0,1,0,0,0,0,0);
		SetTileTag(40,14,0,1,0,0,0,0,0);
		SetTileTag(40,15,0,1,0,0,0,0,0);
		SetTileTag(40,16,0,1,0,0,0,0,0);
		SetTileTag(40,17,0,1,0,0,0,0,0);
		SetTileTag(40,18,0,1,0,0,0,0,0);
		SetTileTag(40,19,0,1,0,0,0,0,0);
		SetTileTag(40,20,0,1,0,0,0,0,0);
		SetTileTag(40,21,0,1,0,0,0,0,0);
		SetTileTag(40,22,0,1,0,0,0,0,0);
		SetTileTag(40,23,0,1,30,0,0,0,0);
		SetTileTag(40,24,0,1,6,0,0,0,0);
		SetTileTag(40,25,5,1,6,0,1,0,0);
		SetTileTag(40,26,1,1,6,0,1,0,0);
		SetTileTag(40,27,1,1,6,0,1,0,0);
		SetTileTag(40,28,1,1,6,0,1,0,0);
		SetTileTag(40,29,1,1,6,0,1,0,0);
		SetTileTag(40,30,2,1,6,0,1,0,0);
		SetTileTag(40,31,0,1,6,0,0,0,0);
		SetTileTag(40,32,0,1,6,0,0,0,0);
		SetTileTag(40,33,0,1,6,0,0,0,0);
		SetTileTag(40,34,0,1,30,0,0,0,0);
		SetTileTag(40,35,0,1,30,0,0,0,0);
		SetTileTag(40,36,0,1,30,0,0,0,0);
		SetTileTag(40,37,1,1,24,0,0,0,0);
		SetTileTag(40,38,1,1,24,0,0,0,0);
		SetTileTag(40,39,1,1,6,0,1,0,0);
		SetTileTag(40,40,3,1,6,0,1,0,0);
		SetTileTag(40,41,0,1,6,0,0,0,0);
		SetTileTag(40,42,1,1,24,0,0,0,0);
		SetTileTag(40,43,1,1,24,0,0,0,0);
		SetTileTag(40,44,1,1,24,0,0,0,0);
		SetTileTag(40,45,1,1,24,0,0,0,0);
		SetTileTag(40,46,1,1,24,0,0,0,0);
		SetTileTag(40,47,1,1,24,0,0,0,0);
		SetTileTag(40,48,1,1,24,0,0,0,0);
		SetTileTag(40,49,1,1,24,0,0,0,0);
		SetTileTag(40,50,1,1,24,0,0,0,0);
		SetTileTag(40,51,1,1,24,0,0,0,0);
		SetTileTag(40,52,1,1,24,0,0,0,0);
		SetTileTag(40,53,1,1,24,0,0,0,0);
		SetTileTag(40,54,1,1,24,0,0,0,0);
		SetTileTag(40,55,1,1,24,0,0,0,0);
		SetTileTag(40,56,1,1,24,0,0,0,0);
		SetTileTag(40,57,1,1,24,0,0,0,0);
		SetTileTag(40,58,0,1,8,0,0,0,0);
		SetTileTag(40,59,0,1,8,0,0,0,0);
		SetTileTag(40,60,0,1,8,0,0,0,0);
		SetTileTag(40,61,0,1,8,0,0,0,0);
		SetTileTag(40,62,0,1,8,0,0,0,0);
		SetTileTag(40,63,0,1,30,0,0,0,0);
		SetTileTag(41,0,0,1,30,0,0,0,0);
		SetTileTag(41,1,0,1,30,0,0,0,0);
		SetTileTag(41,2,0,1,30,0,0,0,0);
		SetTileTag(41,3,1,1,16,0,0,0,0);
		SetTileTag(41,4,1,1,16,0,0,0,0);
		SetTileTag(41,5,1,1,16,0,0,0,0);
		SetTileTag(41,6,1,1,16,0,0,0,0);
		SetTileTag(41,7,0,1,0,0,0,0,0);
		SetTileTag(41,8,0,1,0,0,0,0,0);
		SetTileTag(41,9,0,1,24,0,0,0,0);
		SetTileTag(41,10,0,1,30,0,0,0,0);
		SetTileTag(41,11,0,1,30,0,0,0,0);
		SetTileTag(41,12,0,1,24,0,0,0,0);
		SetTileTag(41,13,0,1,30,0,0,0,0);
		SetTileTag(41,14,0,1,24,0,0,0,0);
		SetTileTag(41,15,5,1,24,0,0,0,0);
		SetTileTag(41,16,1,1,24,0,0,0,0);
		SetTileTag(41,17,1,1,24,0,0,0,0);
		SetTileTag(41,18,3,1,24,0,0,0,0);
		SetTileTag(41,19,0,1,30,0,0,0,0);
		SetTileTag(41,20,0,1,30,0,0,0,0);
		SetTileTag(41,21,0,1,30,0,0,0,0);
		SetTileTag(41,22,0,1,30,0,0,0,0);
		SetTileTag(41,23,0,1,30,0,0,0,0);
		SetTileTag(41,24,0,1,30,0,0,0,0);
		SetTileTag(41,25,0,1,6,0,0,0,0);
		SetTileTag(41,26,5,1,6,0,1,0,0);
		SetTileTag(41,27,1,1,6,0,1,0,0);
		SetTileTag(41,28,1,1,6,0,1,0,0);
		SetTileTag(41,29,1,1,6,0,1,0,0);
		SetTileTag(41,30,1,1,6,0,1,0,0);
		SetTileTag(41,31,0,1,6,0,0,0,0);
		SetTileTag(41,32,0,1,6,0,0,0,0);
		SetTileTag(41,33,0,1,6,0,0,0,0);
		SetTileTag(41,34,0,1,6,0,0,0,0);
		SetTileTag(41,35,0,1,6,0,0,0,0);
		SetTileTag(41,36,0,1,6,0,0,0,0);
		SetTileTag(41,37,1,1,24,0,0,0,0);
		SetTileTag(41,38,1,1,24,0,0,0,0);
		SetTileTag(41,39,1,1,6,0,1,0,0);
		SetTileTag(41,40,0,1,6,0,0,0,0);
		SetTileTag(41,41,0,1,6,0,0,0,0);
		SetTileTag(41,42,1,1,24,0,0,0,0);
		SetTileTag(41,43,1,1,24,0,0,0,0);
		SetTileTag(41,44,1,1,24,0,0,0,0);
		SetTileTag(41,45,1,1,24,0,0,0,0);
		SetTileTag(41,46,1,1,24,0,0,0,0);
		SetTileTag(41,47,1,1,24,0,0,0,0);
		SetTileTag(41,48,1,1,24,0,0,0,0);
		SetTileTag(41,49,1,1,24,0,0,0,0);
		SetTileTag(41,50,1,1,24,0,0,0,0);
		SetTileTag(41,51,1,1,24,0,0,0,0);
		SetTileTag(41,52,1,1,24,0,0,0,0);
		SetTileTag(41,53,1,1,24,0,0,0,0);
		SetTileTag(41,54,1,1,24,0,0,0,0);
		SetTileTag(41,55,1,1,24,0,0,0,0);
		SetTileTag(41,56,1,1,24,0,0,0,0);
		SetTileTag(41,57,1,1,24,0,0,0,0);
		SetTileTag(41,58,0,1,18,0,0,0,0);
		SetTileTag(41,59,0,1,18,0,0,0,0);
		SetTileTag(41,60,0,1,18,0,0,0,0);
		SetTileTag(41,61,0,1,18,0,0,0,0);
		SetTileTag(41,62,0,1,8,0,0,0,0);
		SetTileTag(41,63,0,1,30,0,0,0,0);
		SetTileTag(42,0,0,1,30,0,0,0,0);
		SetTileTag(42,1,0,1,30,0,0,0,0);
		SetTileTag(42,2,0,1,30,0,0,0,0);
		SetTileTag(42,3,1,1,16,0,0,0,0);
		SetTileTag(42,4,0,1,24,0,0,0,0);
		SetTileTag(42,5,0,1,30,0,0,0,0);
		SetTileTag(42,6,0,1,30,0,0,0,0);
		SetTileTag(42,7,0,1,0,0,0,0,0);
		SetTileTag(42,8,0,1,0,0,0,0,0);
		SetTileTag(42,9,0,1,30,0,0,0,0);
		SetTileTag(42,10,0,1,30,0,0,0,0);
		SetTileTag(42,11,0,1,30,0,0,0,0);
		SetTileTag(42,12,0,1,24,0,0,0,0);
		SetTileTag(42,13,0,1,30,0,0,0,0);
		SetTileTag(42,14,0,1,30,0,0,0,0);
		SetTileTag(42,15,0,1,24,0,0,0,0);
		SetTileTag(42,16,1,1,24,0,0,0,0);
		SetTileTag(42,17,1,1,24,0,0,0,0);
		SetTileTag(42,18,0,1,30,0,0,0,0);
		SetTileTag(42,19,0,1,30,0,0,0,0);
		SetTileTag(42,20,0,1,30,0,0,0,0);
		SetTileTag(42,21,0,1,30,0,0,0,0);
		SetTileTag(42,22,0,1,30,0,0,0,0);
		SetTileTag(42,23,0,1,30,0,0,0,0);
		SetTileTag(42,24,0,1,30,0,0,0,0);
		SetTileTag(42,25,0,1,30,0,0,0,0);
		SetTileTag(42,26,0,1,6,0,0,0,0);
		SetTileTag(42,27,5,1,6,0,1,0,0);
		SetTileTag(42,28,1,1,6,0,1,0,0);
		SetTileTag(42,29,1,1,6,0,1,0,0);
		SetTileTag(42,30,1,1,6,0,1,0,0);
		SetTileTag(42,31,2,1,6,0,1,0,0);
		SetTileTag(42,32,0,1,6,0,0,0,0);
		SetTileTag(42,33,0,1,6,0,0,0,0);
		SetTileTag(42,34,0,1,6,0,0,0,0);
		SetTileTag(42,35,0,1,6,0,0,0,0);
		SetTileTag(42,36,4,1,6,0,1,0,0);
		SetTileTag(42,37,1,1,6,0,1,0,0);
		SetTileTag(42,38,1,1,6,0,1,0,0);
		SetTileTag(42,39,1,1,6,0,1,0,0);
		SetTileTag(42,40,2,1,6,0,1,0,0);
		SetTileTag(42,41,0,1,6,0,0,0,0);
		SetTileTag(42,42,0,1,30,0,0,0,0);
		SetTileTag(42,43,0,1,30,0,0,0,0);
		SetTileTag(42,44,0,1,30,0,0,0,0);
		SetTileTag(42,45,0,1,20,0,0,0,0);
		SetTileTag(42,46,0,1,30,0,0,0,0);
		SetTileTag(42,47,0,1,30,0,0,0,0);
		SetTileTag(42,48,0,1,30,0,0,0,0);
		SetTileTag(42,49,0,1,8,0,0,0,0);
		SetTileTag(42,50,0,1,8,0,0,0,0);
		SetTileTag(42,51,1,1,24,0,0,1,0);
		SetTileTag(42,52,0,1,18,0,0,0,0);
		SetTileTag(42,53,0,1,24,0,0,0,0);
		SetTileTag(42,54,0,1,18,0,0,0,0);
		SetTileTag(42,55,0,1,18,0,0,0,0);
		SetTileTag(42,56,0,1,18,0,0,0,0);
		SetTileTag(42,57,0,1,18,0,0,0,0);
		SetTileTag(42,58,0,1,18,0,0,0,0);
		SetTileTag(42,59,0,1,24,0,0,0,0);
		SetTileTag(42,60,0,1,18,0,0,0,0);
		SetTileTag(42,61,0,1,18,0,0,0,0);
		SetTileTag(42,62,0,1,8,0,0,0,0);
		SetTileTag(42,63,0,1,30,0,0,0,0);
		SetTileTag(43,0,0,1,30,0,0,0,0);
		SetTileTag(43,1,0,1,30,0,0,0,0);
		SetTileTag(43,2,0,1,30,0,0,0,0);
		SetTileTag(43,3,8,1,16,0,0,0,0);
		SetTileTag(43,4,0,1,24,0,0,0,0);
		SetTileTag(43,5,0,1,30,0,0,0,0);
		SetTileTag(43,6,0,1,30,0,0,0,0);
		SetTileTag(43,7,0,1,0,0,0,0,0);
		SetTileTag(43,8,0,1,0,0,0,0,0);
		SetTileTag(43,9,2,1,24,0,0,0,0);
		SetTileTag(43,10,0,1,30,0,0,0,0);
		SetTileTag(43,11,0,1,30,0,0,0,0);
		SetTileTag(43,12,0,1,24,0,0,0,0);
		SetTileTag(43,13,0,1,30,0,0,0,0);
		SetTileTag(43,14,0,1,24,0,0,0,0);
		SetTileTag(43,15,0,1,24,0,0,0,0);
		SetTileTag(43,16,1,1,24,0,0,0,0);
		SetTileTag(43,17,1,1,24,0,0,0,0);
		SetTileTag(43,18,0,1,24,0,0,0,0);
		SetTileTag(43,19,4,1,24,0,0,0,0);
		SetTileTag(43,20,1,1,24,0,0,0,0);
		SetTileTag(43,21,1,1,24,0,0,0,0);
		SetTileTag(43,22,1,1,24,0,0,0,0);
		SetTileTag(43,23,2,1,24,0,0,0,0);
		SetTileTag(43,24,0,1,30,0,0,0,0);
		SetTileTag(43,25,0,1,30,0,0,0,0);
		SetTileTag(43,26,0,1,6,0,0,0,0);
		SetTileTag(43,27,0,1,6,0,0,0,0);
		SetTileTag(43,28,0,1,6,0,0,0,0);
		SetTileTag(43,29,5,1,6,0,1,0,0);
		SetTileTag(43,30,1,1,6,0,1,0,0);
		SetTileTag(43,31,1,1,6,0,1,0,0);
		SetTileTag(43,32,1,1,6,0,1,0,0);
		SetTileTag(43,33,1,1,6,0,1,0,0);
		SetTileTag(43,34,1,1,6,0,1,0,0);
		SetTileTag(43,35,1,1,6,0,1,0,0);
		SetTileTag(43,36,1,1,6,0,1,0,0);
		SetTileTag(43,37,1,1,6,0,1,0,0);
		SetTileTag(43,38,1,1,6,0,1,0,0);
		SetTileTag(43,39,1,1,6,0,1,0,0);
		SetTileTag(43,40,1,1,6,0,1,0,0);
		SetTileTag(43,41,0,1,6,0,0,0,0);
		SetTileTag(43,42,1,1,14,0,0,0,0);
		SetTileTag(43,43,1,1,0,0,0,0,0);
		SetTileTag(43,44,1,1,4,0,0,0,0);
		SetTileTag(43,45,1,1,0,0,0,0,0);
		SetTileTag(43,46,1,1,0,0,0,0,0);
		SetTileTag(43,47,1,1,0,0,0,0,0);
		SetTileTag(43,48,1,1,0,0,0,0,0);
		SetTileTag(43,49,1,1,2,0,0,0,0);
		SetTileTag(43,50,0,1,30,0,0,0,0);
		SetTileTag(43,51,1,1,24,0,0,0,0);
		SetTileTag(43,52,1,1,24,0,0,0,0);
		SetTileTag(43,53,2,1,24,0,0,0,0);
		SetTileTag(43,54,0,1,18,0,0,0,0);
		SetTileTag(43,55,4,1,24,0,0,0,0);
		SetTileTag(43,56,1,1,24,0,0,0,0);
		SetTileTag(43,57,1,1,24,0,0,0,0);
		SetTileTag(43,58,1,1,24,0,0,0,0);
		SetTileTag(43,59,1,1,24,0,0,0,0);
		SetTileTag(43,60,2,1,24,0,0,0,0);
		SetTileTag(43,61,0,1,18,0,0,0,0);
		SetTileTag(43,62,0,1,8,0,0,0,0);
		SetTileTag(43,63,0,1,30,0,0,0,0);
		SetTileTag(44,0,0,1,30,0,0,0,0);
		SetTileTag(44,1,0,1,30,0,0,0,0);
		SetTileTag(44,2,0,1,30,0,0,0,0);
		SetTileTag(44,3,1,1,18,0,0,0,0);
		SetTileTag(44,4,4,1,2,0,1,0,0);
		SetTileTag(44,5,1,1,2,0,1,0,0);
		SetTileTag(44,6,2,1,2,0,1,0,0);
		SetTileTag(44,7,0,1,0,0,0,0,0);
		SetTileTag(44,8,0,1,0,0,0,0,0);
		SetTileTag(44,9,1,1,24,0,0,0,0);
		SetTileTag(44,10,2,1,24,0,0,0,0);
		SetTileTag(44,11,0,1,30,0,0,0,0);
		SetTileTag(44,12,0,1,24,0,0,0,0);
		SetTileTag(44,13,0,1,30,0,0,0,0);
		SetTileTag(44,14,0,1,30,0,0,0,0);
		SetTileTag(44,15,0,1,24,0,0,0,0);
		SetTileTag(44,16,1,1,24,0,0,0,0);
		SetTileTag(44,17,1,1,24,0,0,0,0);
		SetTileTag(44,18,4,1,24,0,0,0,0);
		SetTileTag(44,19,1,1,24,0,0,0,0);
		SetTileTag(44,20,1,1,24,0,0,0,0);
		SetTileTag(44,21,1,1,24,0,0,0,0);
		SetTileTag(44,22,1,1,24,0,0,0,0);
		SetTileTag(44,23,1,1,24,0,0,0,0);
		SetTileTag(44,24,2,1,24,0,0,0,0);
		SetTileTag(44,25,0,1,30,0,0,0,0);
		SetTileTag(44,26,0,1,6,0,0,0,0);
		SetTileTag(44,27,0,1,6,0,0,0,0);
		SetTileTag(44,28,0,1,6,0,0,0,0);
		SetTileTag(44,29,0,1,6,0,0,0,0);
		SetTileTag(44,30,1,1,6,0,1,0,0);
		SetTileTag(44,31,1,1,6,0,1,0,0);
		SetTileTag(44,32,1,1,6,0,1,0,0);
		SetTileTag(44,33,1,1,6,0,1,0,0);
		SetTileTag(44,34,1,1,6,0,1,0,0);
		SetTileTag(44,35,1,1,6,0,1,0,0);
		SetTileTag(44,36,1,1,6,0,1,0,0);
		SetTileTag(44,37,1,1,6,0,1,0,0);
		SetTileTag(44,38,1,1,6,0,1,0,0);
		SetTileTag(44,39,1,1,6,0,1,0,0);
		SetTileTag(44,40,1,1,6,0,1,0,0);
		SetTileTag(44,41,0,1,6,0,0,0,0);
		SetTileTag(44,42,1,1,0,0,0,0,0);
		SetTileTag(44,43,1,1,0,0,0,0,0);
		SetTileTag(44,44,1,1,0,0,0,0,0);
		SetTileTag(44,45,1,1,0,0,0,0,0);
		SetTileTag(44,46,1,1,0,0,0,0,0);
		SetTileTag(44,47,1,1,0,0,0,0,0);
		SetTileTag(44,48,0,1,8,0,0,0,0);
		SetTileTag(44,49,1,1,4,0,0,0,0);
		SetTileTag(44,50,0,1,30,0,0,0,0);
		SetTileTag(44,51,1,1,24,0,0,0,0);
		SetTileTag(44,52,1,1,24,0,0,0,0);
		SetTileTag(44,53,1,1,24,0,0,0,0);
		SetTileTag(44,54,0,1,18,0,0,0,0);
		SetTileTag(44,55,1,1,24,0,0,0,0);
		SetTileTag(44,56,1,1,24,0,0,0,0);
		SetTileTag(44,57,1,1,24,0,0,0,0);
		SetTileTag(44,58,1,1,24,0,0,0,0);
		SetTileTag(44,59,1,1,24,0,0,0,0);
		SetTileTag(44,60,1,1,24,0,0,0,0);
		SetTileTag(44,61,0,1,18,0,0,0,0);
		SetTileTag(44,62,0,1,8,0,0,0,0);
		SetTileTag(44,63,0,1,30,0,0,0,0);
		SetTileTag(45,0,0,1,30,0,0,0,0);
		SetTileTag(45,1,0,1,30,0,0,0,0);
		SetTileTag(45,2,0,1,30,0,0,0,0);
		SetTileTag(45,3,1,1,18,0,0,0,0);
		SetTileTag(45,4,1,1,2,0,1,0,0);
		SetTileTag(45,5,1,1,2,0,1,0,0);
		SetTileTag(45,6,1,1,2,0,1,0,0);
		SetTileTag(45,7,2,1,2,0,1,0,0);
		SetTileTag(45,8,0,1,0,0,0,0,0);
		SetTileTag(45,9,1,1,24,0,0,0,0);
		SetTileTag(45,10,1,1,24,0,0,0,0);
		SetTileTag(45,11,1,1,24,0,0,0,0);
		SetTileTag(45,12,1,1,24,0,0,0,0);
		SetTileTag(45,13,1,1,24,0,0,0,0);
		SetTileTag(45,14,1,1,24,0,0,0,0);
		SetTileTag(45,15,1,1,24,0,0,0,0);
		SetTileTag(45,16,1,1,24,0,0,0,0);
		SetTileTag(45,17,1,1,24,0,0,0,0);
		SetTileTag(45,18,1,1,24,0,0,0,0);
		SetTileTag(45,19,3,1,24,0,0,0,0);
		SetTileTag(45,20,0,1,30,0,0,0,0);
		SetTileTag(45,21,0,1,30,0,0,0,0);
		SetTileTag(45,22,5,1,24,0,0,0,0);
		SetTileTag(45,23,1,1,24,0,0,0,0);
		SetTileTag(45,24,1,1,24,0,0,0,0);
		SetTileTag(45,25,0,1,24,0,0,0,0);
		SetTileTag(45,26,0,1,24,0,0,0,0);
		SetTileTag(45,27,0,1,6,0,0,0,0);
		SetTileTag(45,28,0,1,6,0,0,0,0);
		SetTileTag(45,29,4,1,6,0,1,0,0);
		SetTileTag(45,30,1,1,6,0,1,0,0);
		SetTileTag(45,31,1,1,6,0,1,0,0);
		SetTileTag(45,32,3,1,6,0,1,0,0);
		SetTileTag(45,33,0,1,6,0,0,0,0);
		SetTileTag(45,34,0,1,6,0,0,0,0);
		SetTileTag(45,35,0,1,6,0,0,0,0);
		SetTileTag(45,36,5,1,6,0,1,0,0);
		SetTileTag(45,37,1,1,6,0,1,0,0);
		SetTileTag(45,38,1,1,6,0,1,0,0);
		SetTileTag(45,39,3,1,6,0,1,0,0);
		SetTileTag(45,40,0,1,6,0,0,0,0);
		SetTileTag(45,41,0,1,6,0,0,0,0);
		SetTileTag(45,42,1,1,16,0,0,0,0);
		SetTileTag(45,43,1,1,0,0,0,0,0);
		SetTileTag(45,44,1,1,6,0,0,0,0);
		SetTileTag(45,45,1,1,0,0,0,0,0);
		SetTileTag(45,46,1,1,0,0,0,0,0);
		SetTileTag(45,47,1,1,0,0,0,0,0);
		SetTileTag(45,48,0,1,8,0,0,0,0);
		SetTileTag(45,49,1,1,6,0,0,0,0);
		SetTileTag(45,50,0,1,30,0,0,0,0);
		SetTileTag(45,51,1,1,24,0,0,0,0);
		SetTileTag(45,52,1,1,24,0,0,0,0);
		SetTileTag(45,53,3,1,24,0,0,0,0);
		SetTileTag(45,54,0,1,24,0,0,0,0);
		SetTileTag(45,55,1,1,24,0,0,0,0);
		SetTileTag(45,56,1,1,24,0,0,0,0);
		SetTileTag(45,57,1,1,24,0,0,0,0);
		SetTileTag(45,58,0,1,18,0,0,0,0);
		SetTileTag(45,59,1,1,24,0,0,0,0);
		SetTileTag(45,60,1,1,24,0,0,0,0);
		SetTileTag(45,61,0,1,18,0,0,0,0);
		SetTileTag(45,62,0,1,8,0,0,0,0);
		SetTileTag(45,63,0,1,30,0,0,0,0);
		SetTileTag(46,0,0,1,30,0,0,0,0);
		SetTileTag(46,1,0,1,30,0,0,0,0);
		SetTileTag(46,2,0,1,30,0,0,0,0);
		SetTileTag(46,3,1,1,18,0,0,0,0);
		SetTileTag(46,4,1,1,2,0,1,0,0);
		SetTileTag(46,5,1,1,18,0,0,0,0);
		SetTileTag(46,6,1,1,18,0,0,0,0);
		SetTileTag(46,7,1,1,2,0,1,0,0);
		SetTileTag(46,8,1,1,18,0,0,1,0);
		SetTileTag(46,9,1,1,18,0,0,0,0);
		SetTileTag(46,10,6,1,18,0,0,0,0);
		SetTileTag(46,11,6,1,20,0,0,0,0);
		SetTileTag(46,12,6,1,22,0,0,0,0);
		SetTileTag(46,13,1,1,24,0,0,0,0);
		SetTileTag(46,14,1,1,24,0,0,0,0);
		SetTileTag(46,15,1,1,24,0,0,0,0);
		SetTileTag(46,16,1,1,24,0,0,0,0);
		SetTileTag(46,17,1,1,24,0,0,0,0);
		SetTileTag(46,18,1,1,24,0,0,0,0);
		SetTileTag(46,19,0,1,30,0,0,0,0);
		SetTileTag(46,20,0,1,30,0,0,0,0);
		SetTileTag(46,21,0,1,30,0,0,0,0);
		SetTileTag(46,22,0,1,30,0,0,0,0);
		SetTileTag(46,23,1,1,24,0,0,0,0);
		SetTileTag(46,24,1,1,24,0,0,0,0);
		SetTileTag(46,25,0,1,24,0,0,0,0);
		SetTileTag(46,26,0,1,30,0,0,0,0);
		SetTileTag(46,27,0,1,30,0,0,0,0);
		SetTileTag(46,28,0,1,6,0,0,0,0);
		SetTileTag(46,29,1,1,6,0,1,0,0);
		SetTileTag(46,30,3,1,6,0,1,0,0);
		SetTileTag(46,31,0,1,8,0,0,0,0);
		SetTileTag(46,32,0,1,8,0,0,0,0);
		SetTileTag(46,33,0,1,6,0,0,0,0);
		SetTileTag(46,34,0,1,6,0,0,0,0);
		SetTileTag(46,35,0,1,6,0,0,0,0);
		SetTileTag(46,36,0,1,6,0,0,0,0);
		SetTileTag(46,37,1,1,24,0,0,0,0);
		SetTileTag(46,38,1,1,24,0,0,0,0);
		SetTileTag(46,39,0,1,6,0,0,0,0);
		SetTileTag(46,40,0,1,24,0,0,0,0);
		SetTileTag(46,41,0,1,24,0,0,0,0);
		SetTileTag(46,42,1,1,0,0,0,0,0);
		SetTileTag(46,43,1,1,0,0,0,0,0);
		SetTileTag(46,44,1,1,0,0,0,0,0);
		SetTileTag(46,45,1,1,0,0,0,0,0);
		SetTileTag(46,46,1,1,0,0,0,0,0);
		SetTileTag(46,47,1,1,0,0,0,0,0);
		SetTileTag(46,48,0,1,8,0,0,0,0);
		SetTileTag(46,49,1,1,8,0,0,0,0);
		SetTileTag(46,50,0,1,8,0,0,0,0);
		SetTileTag(46,51,1,1,24,0,0,0,0);
		SetTileTag(46,52,0,1,18,0,0,0,0);
		SetTileTag(46,53,0,1,18,0,0,0,0);
		SetTileTag(46,54,0,1,24,0,0,0,0);
		SetTileTag(46,55,1,1,24,0,0,0,0);
		SetTileTag(46,56,1,1,24,0,0,0,0);
		SetTileTag(46,57,1,1,24,0,0,0,0);
		SetTileTag(46,58,0,1,18,0,0,0,0);
		SetTileTag(46,59,1,1,24,0,0,0,0);
		SetTileTag(46,60,1,1,24,0,0,0,0);
		SetTileTag(46,61,0,1,24,0,0,0,0);
		SetTileTag(46,62,0,1,8,0,0,0,0);
		SetTileTag(46,63,0,1,8,0,0,0,0);
		SetTileTag(47,0,0,1,30,0,0,0,0);
		SetTileTag(47,1,0,1,30,0,0,0,0);
		SetTileTag(47,2,4,1,2,0,1,0,0);
		SetTileTag(47,3,1,1,2,0,1,0,0);
		SetTileTag(47,4,1,1,2,0,1,0,0);
		SetTileTag(47,5,1,1,2,0,1,0,0);
		SetTileTag(47,6,1,1,2,0,1,0,0);
		SetTileTag(47,7,1,1,2,0,1,0,0);
		SetTileTag(47,8,0,1,0,0,0,0,0);
		SetTileTag(47,9,1,1,24,0,0,0,0);
		SetTileTag(47,10,1,1,24,0,0,0,0);
		SetTileTag(47,11,1,1,24,0,0,0,0);
		SetTileTag(47,12,1,1,24,0,0,0,0);
		SetTileTag(47,13,1,1,24,0,0,0,0);
		SetTileTag(47,14,1,1,24,0,0,0,0);
		SetTileTag(47,15,1,1,24,0,0,0,0);
		SetTileTag(47,16,1,1,24,0,0,0,0);
		SetTileTag(47,17,1,1,24,0,0,0,0);
		SetTileTag(47,18,1,1,24,0,0,0,0);
		SetTileTag(47,19,2,1,24,0,0,0,0);
		SetTileTag(47,20,0,1,30,0,0,0,0);
		SetTileTag(47,21,0,1,30,0,0,0,0);
		SetTileTag(47,22,4,1,24,0,0,0,0);
		SetTileTag(47,23,1,1,24,0,0,0,0);
		SetTileTag(47,24,1,1,24,0,0,0,0);
		SetTileTag(47,25,0,1,24,0,0,0,0);
		SetTileTag(47,26,0,1,30,0,0,0,0);
		SetTileTag(47,27,0,1,30,0,0,0,0);
		SetTileTag(47,28,0,1,6,0,0,0,0);
		SetTileTag(47,29,8,1,6,0,1,0,0);
		SetTileTag(47,30,0,1,6,0,0,0,0);
		SetTileTag(47,31,0,1,8,0,0,0,0);
		SetTileTag(47,32,0,1,8,0,0,0,0);
		SetTileTag(47,33,0,1,30,0,0,0,0);
		SetTileTag(47,34,0,1,30,0,0,0,0);
		SetTileTag(47,35,0,1,30,0,0,0,0);
		SetTileTag(47,36,0,1,30,0,0,0,0);
		SetTileTag(47,37,1,1,24,0,0,0,0);
		SetTileTag(47,38,1,1,24,0,0,0,0);
		SetTileTag(47,39,0,1,30,0,0,0,0);
		SetTileTag(47,40,0,1,24,0,0,0,0);
		SetTileTag(47,41,0,1,8,0,0,0,0);
		SetTileTag(47,42,1,1,18,0,0,0,0);
		SetTileTag(47,43,1,1,0,0,0,0,0);
		SetTileTag(47,44,1,1,8,0,0,0,0);
		SetTileTag(47,45,1,1,0,0,0,0,0);
		SetTileTag(47,46,1,1,0,0,0,0,0);
		SetTileTag(47,47,1,1,0,0,0,0,0);
		SetTileTag(47,48,0,1,8,0,0,0,0);
		SetTileTag(47,49,1,1,10,0,0,0,0);
		SetTileTag(47,50,0,1,8,0,0,0,0);
		SetTileTag(47,51,1,1,24,0,0,1,0);
		SetTileTag(47,52,0,1,18,0,0,0,0);
		SetTileTag(47,53,1,1,0,0,1,0,0);
		SetTileTag(47,54,1,1,26,0,0,0,0);
		SetTileTag(47,55,1,1,24,0,0,0,0);
		SetTileTag(47,56,1,1,24,0,0,0,0);
		SetTileTag(47,57,1,1,22,0,0,0,0);
		SetTileTag(47,58,0,1,18,0,0,0,0);
		SetTileTag(47,59,1,1,24,0,0,0,0);
		SetTileTag(47,60,1,1,24,0,0,0,0);
		SetTileTag(47,61,0,1,18,0,0,0,0);
		SetTileTag(47,62,0,1,8,0,0,0,0);
		SetTileTag(47,63,0,1,8,0,0,0,0);
		SetTileTag(48,0,0,1,30,0,0,0,0);
		SetTileTag(48,1,0,1,30,0,0,0,0);
		SetTileTag(48,2,5,1,2,0,1,0,0);
		SetTileTag(48,3,1,1,2,0,1,0,0);
		SetTileTag(48,4,1,1,2,0,1,0,0);
		SetTileTag(48,5,1,1,18,0,0,0,0);
		SetTileTag(48,6,1,1,2,0,1,0,0);
		SetTileTag(48,7,3,1,2,0,1,0,0);
		SetTileTag(48,8,0,1,0,0,0,0,0);
		SetTileTag(48,9,1,1,24,0,0,0,0);
		SetTileTag(48,10,3,1,24,0,0,0,0);
		SetTileTag(48,11,0,1,30,0,0,0,0);
		SetTileTag(48,12,0,1,24,0,0,0,0);
		SetTileTag(48,13,0,1,24,0,0,0,0);
		SetTileTag(48,14,0,1,30,0,0,0,0);
		SetTileTag(48,15,0,1,30,0,0,0,0);
		SetTileTag(48,16,1,1,24,0,0,0,0);
		SetTileTag(48,17,1,1,24,0,0,0,0);
		SetTileTag(48,18,5,1,24,0,0,0,0);
		SetTileTag(48,19,1,1,24,0,0,0,0);
		SetTileTag(48,20,1,1,24,0,0,0,0);
		SetTileTag(48,21,1,1,24,0,0,0,0);
		SetTileTag(48,22,1,1,24,0,0,0,0);
		SetTileTag(48,23,1,1,24,0,0,0,0);
		SetTileTag(48,24,3,1,24,0,0,0,0);
		SetTileTag(48,25,0,1,30,0,0,0,0);
		SetTileTag(48,26,0,1,30,0,0,0,0);
		SetTileTag(48,27,0,1,30,0,0,0,0);
		SetTileTag(48,28,4,1,8,0,1,0,0);
		SetTileTag(48,29,1,1,8,0,1,0,0);
		SetTileTag(48,30,0,1,30,0,0,0,0);
		SetTileTag(48,31,0,1,8,0,0,0,0);
		SetTileTag(48,32,0,1,8,0,0,0,0);
		SetTileTag(48,33,0,1,30,0,0,0,0);
		SetTileTag(48,34,0,1,30,0,0,0,0);
		SetTileTag(48,35,0,1,30,0,0,0,0);
		SetTileTag(48,36,0,1,30,0,0,0,0);
		SetTileTag(48,37,9,1,22,0,0,0,0);
		SetTileTag(48,38,1,1,24,0,0,0,0);
		SetTileTag(48,39,0,1,30,0,0,0,0);
		SetTileTag(48,40,0,1,20,0,0,0,0);
		SetTileTag(48,41,0,1,8,0,0,0,0);
		SetTileTag(48,42,1,1,0,0,0,0,0);
		SetTileTag(48,43,1,1,0,0,0,0,0);
		SetTileTag(48,44,1,1,0,0,0,0,0);
		SetTileTag(48,45,1,1,0,0,0,0,0);
		SetTileTag(48,46,1,1,0,0,0,0,0);
		SetTileTag(48,47,1,1,0,0,0,0,0);
		SetTileTag(48,48,0,1,8,0,0,0,0);
		SetTileTag(48,49,1,1,12,0,0,0,0);
		SetTileTag(48,50,0,1,8,0,0,0,0);
		SetTileTag(48,51,1,1,24,0,0,0,0);
		SetTileTag(48,52,2,1,24,0,0,0,0);
		SetTileTag(48,53,0,1,18,0,0,0,0);
		SetTileTag(48,54,0,1,18,0,0,0,0);
		SetTileTag(48,55,0,1,18,0,0,0,0);
		SetTileTag(48,56,0,1,18,0,0,0,0);
		SetTileTag(48,57,0,1,18,0,0,0,0);
		SetTileTag(48,58,0,1,18,0,0,0,0);
		SetTileTag(48,59,1,1,24,0,0,0,0);
		SetTileTag(48,60,3,1,24,0,0,0,0);
		SetTileTag(48,61,0,1,18,0,0,0,0);
		SetTileTag(48,62,0,1,8,0,0,0,0);
		SetTileTag(48,63,0,1,8,0,0,0,0);
		SetTileTag(49,0,0,1,30,0,0,0,0);
		SetTileTag(49,1,0,1,30,0,0,0,0);
		SetTileTag(49,2,1,1,18,0,0,0,0);
		SetTileTag(49,3,1,1,2,0,1,0,0);
		SetTileTag(49,4,1,1,2,0,1,0,0);
		SetTileTag(49,5,1,1,18,0,0,0,0);
		SetTileTag(49,6,1,1,2,0,1,0,0);
		SetTileTag(49,7,0,1,18,0,0,0,0);
		SetTileTag(49,8,0,1,0,0,0,0,0);
		SetTileTag(49,9,3,1,24,0,0,0,0);
		SetTileTag(49,10,0,1,30,0,0,0,0);
		SetTileTag(49,11,0,1,30,0,0,0,0);
		SetTileTag(49,12,0,1,24,0,0,0,0);
		SetTileTag(49,13,0,1,24,0,0,0,0);
		SetTileTag(49,14,0,1,30,0,0,0,0);
		SetTileTag(49,15,0,1,30,0,0,0,0);
		SetTileTag(49,16,1,1,24,0,0,0,0);
		SetTileTag(49,17,1,1,24,0,0,0,0);
		SetTileTag(49,18,0,1,30,0,0,0,0);
		SetTileTag(49,19,5,1,24,0,0,0,0);
		SetTileTag(49,20,1,1,24,0,0,0,0);
		SetTileTag(49,21,1,1,24,0,0,0,0);
		SetTileTag(49,22,1,1,24,0,0,0,0);
		SetTileTag(49,23,3,1,24,0,0,0,0);
		SetTileTag(49,24,0,1,30,0,0,0,0);
		SetTileTag(49,25,0,1,30,0,0,0,0);
		SetTileTag(49,26,0,1,30,0,0,0,0);
		SetTileTag(49,27,0,1,30,0,0,0,0);
		SetTileTag(49,28,1,1,8,0,1,0,0);
		SetTileTag(49,29,1,1,8,0,1,0,0);
		SetTileTag(49,30,0,1,30,0,0,0,0);
		SetTileTag(49,31,0,1,8,0,0,0,0);
		SetTileTag(49,32,0,1,8,0,0,0,0);
		SetTileTag(49,33,0,1,30,0,0,0,0);
		SetTileTag(49,34,0,1,30,0,0,0,0);
		SetTileTag(49,35,0,1,30,0,0,0,0);
		SetTileTag(49,36,0,1,30,0,0,0,0);
		SetTileTag(49,37,9,1,20,0,0,0,0);
		SetTileTag(49,38,1,1,24,0,0,0,0);
		SetTileTag(49,39,0,1,24,0,0,0,0);
		SetTileTag(49,40,1,1,20,0,0,0,0);
		SetTileTag(49,41,1,1,20,0,0,0,0);
		SetTileTag(49,42,1,1,20,0,0,0,0);
		SetTileTag(49,43,1,1,0,0,0,0,0);
		SetTileTag(49,44,1,1,10,0,0,0,0);
		SetTileTag(49,45,1,1,0,0,0,0,0);
		SetTileTag(49,46,1,1,0,0,0,0,0);
		SetTileTag(49,47,1,1,0,0,0,0,0);
		SetTileTag(49,48,0,1,8,0,0,0,0);
		SetTileTag(49,49,1,1,14,0,0,0,0);
		SetTileTag(49,50,0,1,8,0,0,0,0);
		SetTileTag(49,51,1,1,24,0,0,0,0);
		SetTileTag(49,52,1,1,24,0,0,0,0);
		SetTileTag(49,53,1,1,24,0,0,0,0);
		SetTileTag(49,54,1,1,24,0,0,0,0);
		SetTileTag(49,55,1,1,24,0,0,0,0);
		SetTileTag(49,56,1,1,24,0,0,0,0);
		SetTileTag(49,57,1,1,24,0,0,0,0);
		SetTileTag(49,58,1,1,24,0,0,0,0);
		SetTileTag(49,59,1,1,24,0,0,0,0);
		SetTileTag(49,60,0,1,18,0,0,0,0);
		SetTileTag(49,61,0,1,18,0,0,0,0);
		SetTileTag(49,62,0,1,8,0,0,0,0);
		SetTileTag(49,63,0,1,8,0,0,0,0);
		SetTileTag(50,0,0,1,30,0,0,0,0);
		SetTileTag(50,1,0,1,30,0,0,0,0);
		SetTileTag(50,2,1,1,18,0,0,0,0);
		SetTileTag(50,3,1,1,2,0,1,0,0);
		SetTileTag(50,4,1,1,2,0,1,0,0);
		SetTileTag(50,5,1,1,2,0,1,0,0);
		SetTileTag(50,6,1,1,2,0,1,0,0);
		SetTileTag(50,7,2,1,2,0,1,0,0);
		SetTileTag(50,8,0,1,0,0,0,0,0);
		SetTileTag(50,9,0,1,30,0,0,0,0);
		SetTileTag(50,10,0,1,30,0,0,0,0);
		SetTileTag(50,11,0,1,30,0,0,0,0);
		SetTileTag(50,12,0,1,24,0,0,0,0);
		SetTileTag(50,13,0,1,24,0,0,0,0);
		SetTileTag(50,14,0,1,30,0,0,0,0);
		SetTileTag(50,15,0,1,24,0,0,0,0);
		SetTileTag(50,16,1,1,24,0,0,0,0);
		SetTileTag(50,17,1,1,24,0,0,0,0);
		SetTileTag(50,18,0,1,24,0,0,0,0);
		SetTileTag(50,19,0,1,30,0,0,0,0);
		SetTileTag(50,20,0,1,30,0,0,0,0);
		SetTileTag(50,21,0,1,30,0,0,0,0);
		SetTileTag(50,22,0,1,30,0,0,0,0);
		SetTileTag(50,23,0,1,30,0,0,0,0);
		SetTileTag(50,24,0,1,30,0,0,0,0);
		SetTileTag(50,25,0,1,10,0,0,0,0);
		SetTileTag(50,26,0,1,10,0,0,0,0);
		SetTileTag(50,27,0,1,30,0,0,0,0);
		SetTileTag(50,28,1,1,8,0,1,0,0);
		SetTileTag(50,29,3,1,8,0,1,0,0);
		SetTileTag(50,30,0,1,16,0,0,0,0);
		SetTileTag(50,31,0,1,16,0,0,0,0);
		SetTileTag(50,32,0,1,16,0,0,0,0);
		SetTileTag(50,33,0,1,16,0,0,0,0);
		SetTileTag(50,34,0,1,16,0,0,0,0);
		SetTileTag(50,35,0,1,30,0,0,0,0);
		SetTileTag(50,36,0,1,30,0,0,0,0);
		SetTileTag(50,37,9,1,18,0,0,0,0);
		SetTileTag(50,38,1,1,24,0,0,0,0);
		SetTileTag(50,39,0,1,30,0,0,0,0);
		SetTileTag(50,40,1,1,20,0,0,0,0);
		SetTileTag(50,41,1,1,20,0,0,0,0);
		SetTileTag(50,42,0,1,18,0,0,0,0);
		SetTileTag(50,43,1,1,0,0,0,0,0);
		SetTileTag(50,44,1,1,0,0,0,0,0);
		SetTileTag(50,45,1,1,0,0,0,0,0);
		SetTileTag(50,46,1,1,0,0,0,0,0);
		SetTileTag(50,47,1,1,0,0,0,0,0);
		SetTileTag(50,48,0,1,8,0,0,0,0);
		SetTileTag(50,49,1,1,16,0,0,0,0);
		SetTileTag(50,50,0,1,8,0,0,0,0);
		SetTileTag(50,51,1,1,24,0,0,0,0);
		SetTileTag(50,52,7,1,22,0,0,0,0);
		SetTileTag(50,53,7,1,20,0,0,0,0);
		SetTileTag(50,54,1,1,20,0,0,0,0);
		SetTileTag(50,55,1,1,20,0,0,0,0);
		SetTileTag(50,56,1,1,20,0,0,0,0);
		SetTileTag(50,57,1,1,20,0,0,0,0);
		SetTileTag(50,58,1,1,20,0,0,0,0);
		SetTileTag(50,59,1,1,24,0,0,0,0);
		SetTileTag(50,60,0,1,18,0,0,0,0);
		SetTileTag(50,61,0,1,18,0,0,0,0);
		SetTileTag(50,62,0,1,8,0,0,0,0);
		SetTileTag(50,63,0,1,8,0,0,0,0);
		SetTileTag(51,0,0,1,30,0,0,0,0);
		SetTileTag(51,1,0,1,30,0,0,0,0);
		SetTileTag(51,2,4,1,2,0,1,0,0);
		SetTileTag(51,3,1,1,2,0,1,0,0);
		SetTileTag(51,4,1,1,2,0,1,0,0);
		SetTileTag(51,5,1,1,2,0,1,0,0);
		SetTileTag(51,6,1,1,2,0,1,0,0);
		SetTileTag(51,7,3,1,2,0,1,0,0);
		SetTileTag(51,8,0,1,18,0,0,0,0);
		SetTileTag(51,9,0,1,30,0,0,0,0);
		SetTileTag(51,10,0,1,30,0,0,0,0);
		SetTileTag(51,11,0,1,30,0,0,0,0);
		SetTileTag(51,12,0,1,24,0,0,0,0);
		SetTileTag(51,13,0,1,24,0,0,0,0);
		SetTileTag(51,14,0,1,30,0,0,0,0);
		SetTileTag(51,15,4,1,24,0,0,0,0);
		SetTileTag(51,16,1,1,24,0,0,0,0);
		SetTileTag(51,17,1,1,24,0,0,0,0);
		SetTileTag(51,18,2,1,24,0,0,0,0);
		SetTileTag(51,19,0,1,30,0,0,0,0);
		SetTileTag(51,20,0,1,30,0,0,0,0);
		SetTileTag(51,21,0,1,30,0,0,0,0);
		SetTileTag(51,22,0,1,30,0,0,0,0);
		SetTileTag(51,23,0,1,30,0,0,0,0);
		SetTileTag(51,24,0,1,30,0,0,0,0);
		SetTileTag(51,25,0,1,10,0,0,0,0);
		SetTileTag(51,26,0,1,10,0,0,0,0);
		SetTileTag(51,27,4,1,8,0,1,0,0);
		SetTileTag(51,28,1,1,8,0,1,0,0);
		SetTileTag(51,29,0,1,8,0,0,0,0);
		SetTileTag(51,30,1,1,20,0,0,0,0);
		SetTileTag(51,31,7,1,18,0,0,0,0);
		SetTileTag(51,32,7,1,16,0,0,0,0);
		SetTileTag(51,33,7,1,14,0,0,0,0);
		SetTileTag(51,34,6,1,14,0,0,0,0);
		SetTileTag(51,35,2,1,16,0,0,0,0);
		SetTileTag(51,36,0,1,30,0,0,0,0);
		SetTileTag(51,37,9,1,16,0,0,0,0);
		SetTileTag(51,38,1,1,24,0,0,0,0);
		SetTileTag(51,39,0,1,30,0,0,0,0);
		SetTileTag(51,40,5,1,20,0,0,0,0);
		SetTileTag(51,41,3,1,20,0,0,0,0);
		SetTileTag(51,42,4,1,0,0,0,0,0);
		SetTileTag(51,43,1,1,0,0,0,0,0);
		SetTileTag(51,44,1,1,0,0,0,0,0);
		SetTileTag(51,45,1,1,0,0,0,0,0);
		SetTileTag(51,46,1,1,0,0,0,0,0);
		SetTileTag(51,47,1,1,0,0,0,0,0);
		SetTileTag(51,48,0,1,0,0,0,0,0);
		SetTileTag(51,49,1,1,18,0,0,0,0);
		SetTileTag(51,50,0,1,8,0,0,0,0);
		SetTileTag(51,51,1,1,24,0,0,0,0);
		SetTileTag(51,52,1,1,20,0,0,0,0);
		SetTileTag(51,53,1,1,20,0,0,0,0);
		SetTileTag(51,54,1,1,18,0,1,0,0);
		SetTileTag(51,55,1,1,18,0,1,0,0);
		SetTileTag(51,56,1,1,18,0,1,0,0);
		SetTileTag(51,57,1,1,20,0,0,0,0);
		SetTileTag(51,58,1,1,20,0,0,0,0);
		SetTileTag(51,59,1,1,24,0,0,0,0);
		SetTileTag(51,60,0,1,18,0,0,0,0);
		SetTileTag(51,61,0,1,18,0,0,0,0);
		SetTileTag(51,62,0,1,8,0,0,0,0);
		SetTileTag(51,63,0,1,8,0,0,0,0);
		SetTileTag(52,0,0,1,30,0,0,0,0);
		SetTileTag(52,1,0,1,30,0,0,0,0);
		SetTileTag(52,2,1,1,2,0,1,0,0);
		SetTileTag(52,3,1,1,2,0,1,0,0);
		SetTileTag(52,4,1,1,2,0,1,0,0);
		SetTileTag(52,5,1,1,18,0,0,0,0);
		SetTileTag(52,6,1,1,18,0,0,0,0);
		SetTileTag(52,7,0,1,30,0,0,0,0);
		SetTileTag(52,8,0,1,30,0,0,0,0);
		SetTileTag(52,9,0,1,30,0,0,0,0);
		SetTileTag(52,10,0,1,30,0,0,0,0);
		SetTileTag(52,11,0,1,30,0,0,0,0);
		SetTileTag(52,12,0,1,30,0,0,0,0);
		SetTileTag(52,13,0,1,30,0,0,0,0);
		SetTileTag(52,14,0,1,30,0,0,0,0);
		SetTileTag(52,15,0,1,30,0,0,0,0);
		SetTileTag(52,16,0,1,30,0,0,0,0);
		SetTileTag(52,17,0,1,30,0,0,0,0);
		SetTileTag(52,18,0,1,10,0,0,0,0);
		SetTileTag(52,19,0,1,10,0,0,0,0);
		SetTileTag(52,20,0,1,10,0,0,0,0);
		SetTileTag(52,21,0,1,10,0,0,0,0);
		SetTileTag(52,22,0,1,10,0,0,0,0);
		SetTileTag(52,23,4,1,10,0,1,0,0);
		SetTileTag(52,24,1,1,10,0,1,0,0);
		SetTileTag(52,25,1,1,10,0,1,0,0);
		SetTileTag(52,26,7,1,8,0,1,0,0);
		SetTileTag(52,27,1,1,8,0,1,0,0);
		SetTileTag(52,28,1,1,8,0,1,0,0);
		SetTileTag(52,29,0,1,8,0,0,0,0);
		SetTileTag(52,30,8,1,20,0,0,0,0);
		SetTileTag(52,31,1,1,24,0,0,0,0);
		SetTileTag(52,32,1,1,24,0,0,0,0);
		SetTileTag(52,33,1,1,24,0,0,0,0);
		SetTileTag(52,34,6,1,14,0,0,0,0);
		SetTileTag(52,35,1,1,16,0,0,0,0);
		SetTileTag(52,36,1,1,16,0,0,1,0);
		SetTileTag(52,37,1,1,16,0,0,0,0);
		SetTileTag(52,38,1,1,24,0,0,0,0);
		SetTileTag(52,39,0,1,30,0,0,0,0);
		SetTileTag(52,40,0,1,8,0,0,0,0);
		SetTileTag(52,41,0,1,0,0,0,0,0);
		SetTileTag(52,42,1,1,0,0,0,0,0);
		SetTileTag(52,43,1,1,0,0,0,0,0);
		SetTileTag(52,44,1,1,0,0,0,0,0);
		SetTileTag(52,45,1,1,0,0,0,0,0);
		SetTileTag(52,46,1,1,24,0,0,0,0);
		SetTileTag(52,47,1,1,22,0,0,0,0);
		SetTileTag(52,48,1,1,20,0,0,0,0);
		SetTileTag(52,49,1,1,18,0,0,0,0);
		SetTileTag(52,50,0,1,8,0,0,0,0);
		SetTileTag(52,51,1,1,24,0,0,0,0);
		SetTileTag(52,52,1,1,20,0,0,0,0);
		SetTileTag(52,53,1,1,20,0,0,0,0);
		SetTileTag(52,54,1,1,18,0,1,0,0);
		SetTileTag(52,55,1,1,18,0,1,0,0);
		SetTileTag(52,56,1,1,18,0,1,0,0);
		SetTileTag(52,57,1,1,20,0,0,0,0);
		SetTileTag(52,58,1,1,20,0,0,0,0);
		SetTileTag(52,59,1,1,24,0,0,0,0);
		SetTileTag(52,60,0,1,18,0,0,0,0);
		SetTileTag(52,61,0,1,18,0,0,0,0);
		SetTileTag(52,62,0,1,8,0,0,0,0);
		SetTileTag(52,63,0,1,8,0,0,0,0);
		SetTileTag(53,0,0,1,30,0,0,0,0);
		SetTileTag(53,1,0,1,30,0,0,0,0);
		SetTileTag(53,2,1,1,2,0,1,0,0);
		SetTileTag(53,3,1,1,2,0,1,0,0);
		SetTileTag(53,4,3,1,2,0,1,0,0);
		SetTileTag(53,5,5,1,18,0,0,0,0);
		SetTileTag(53,6,1,1,18,0,0,0,0);
		SetTileTag(53,7,0,1,30,0,0,0,0);
		SetTileTag(53,8,0,1,30,0,0,0,0);
		SetTileTag(53,9,0,1,30,0,0,0,0);
		SetTileTag(53,10,0,1,30,0,0,0,0);
		SetTileTag(53,11,0,1,30,0,0,0,0);
		SetTileTag(53,12,0,1,30,0,0,0,0);
		SetTileTag(53,13,0,1,30,0,0,0,0);
		SetTileTag(53,14,0,1,30,0,0,0,0);
		SetTileTag(53,15,0,1,30,0,0,0,0);
		SetTileTag(53,16,0,1,30,0,0,0,0);
		SetTileTag(53,17,0,1,30,0,0,0,0);
		SetTileTag(53,18,0,1,10,0,0,0,0);
		SetTileTag(53,19,0,1,10,0,0,0,0);
		SetTileTag(53,20,0,1,10,0,0,0,0);
		SetTileTag(53,21,0,1,10,0,0,0,0);
		SetTileTag(53,22,7,1,10,0,1,0,0);
		SetTileTag(53,23,1,1,10,0,1,0,0);
		SetTileTag(53,24,1,1,10,0,1,0,0);
		SetTileTag(53,25,1,1,10,0,1,0,0);
		SetTileTag(53,26,7,1,8,0,1,0,0);
		SetTileTag(53,27,3,1,8,0,1,0,0);
		SetTileTag(53,28,0,1,8,0,0,0,0);
		SetTileTag(53,29,0,1,8,0,0,0,0);
		SetTileTag(53,30,8,1,22,0,0,0,0);
		SetTileTag(53,31,1,1,24,0,0,0,0);
		SetTileTag(53,32,1,1,24,0,0,0,0);
		SetTileTag(53,33,1,1,24,0,0,0,0);
		SetTileTag(53,34,0,1,20,0,0,0,0);
		SetTileTag(53,35,0,1,20,0,0,0,0);
		SetTileTag(53,36,0,1,20,0,0,0,0);
		SetTileTag(53,37,0,1,14,0,0,0,0);
		SetTileTag(53,38,1,1,24,0,0,0,0);
		SetTileTag(53,39,2,1,24,0,0,0,0);
		SetTileTag(53,40,0,1,8,0,0,0,0);
		SetTileTag(53,41,0,1,0,0,0,0,0);
		SetTileTag(53,42,1,1,0,0,0,0,0);
		SetTileTag(53,43,1,1,0,0,0,0,0);
		SetTileTag(53,44,1,1,0,0,0,0,0);
		SetTileTag(53,45,1,1,0,0,0,0,0);
		SetTileTag(53,46,1,1,24,0,0,0,0);
		SetTileTag(53,47,0,1,18,0,0,0,0);
		SetTileTag(53,48,0,1,18,0,0,0,0);
		SetTileTag(53,49,0,1,18,0,0,0,0);
		SetTileTag(53,50,4,1,24,0,0,0,0);
		SetTileTag(53,51,1,1,24,0,0,0,0);
		SetTileTag(53,52,7,1,22,0,0,0,0);
		SetTileTag(53,53,7,1,20,0,0,0,0);
		SetTileTag(53,54,1,1,20,0,0,0,0);
		SetTileTag(53,55,1,1,20,0,0,0,0);
		SetTileTag(53,56,1,1,20,0,0,0,0);
		SetTileTag(53,57,1,1,20,0,0,0,0);
		SetTileTag(53,58,1,1,20,0,0,0,0);
		SetTileTag(53,59,1,1,24,0,0,0,0);
		SetTileTag(53,60,0,1,18,0,0,0,0);
		SetTileTag(53,61,0,1,18,0,0,0,0);
		SetTileTag(53,62,0,1,8,0,0,0,0);
		SetTileTag(53,63,0,1,8,0,0,0,0);
		SetTileTag(54,0,0,1,30,0,0,0,0);
		SetTileTag(54,1,0,1,30,0,0,0,0);
		SetTileTag(54,2,1,1,4,0,0,0,0);
		SetTileTag(54,3,0,1,16,0,0,0,0);
		SetTileTag(54,4,2,1,20,0,0,0,0);
		SetTileTag(54,5,0,1,16,0,0,0,0);
		SetTileTag(54,6,9,1,16,0,0,0,0);
		SetTileTag(54,7,0,1,30,0,0,0,0);
		SetTileTag(54,8,0,1,30,0,0,0,0);
		SetTileTag(54,9,0,1,30,0,0,0,0);
		SetTileTag(54,10,0,1,30,0,0,0,0);
		SetTileTag(54,11,0,1,30,0,0,0,0);
		SetTileTag(54,12,0,1,30,0,0,0,0);
		SetTileTag(54,13,0,1,30,0,0,0,0);
		SetTileTag(54,14,0,1,30,0,0,0,0);
		SetTileTag(54,15,0,1,30,0,0,0,0);
		SetTileTag(54,16,0,1,30,0,0,0,0);
		SetTileTag(54,17,0,1,30,0,0,0,0);
		SetTileTag(54,18,0,1,10,0,0,0,0);
		SetTileTag(54,19,0,1,12,0,0,0,0);
		SetTileTag(54,20,0,1,12,0,0,0,0);
		SetTileTag(54,21,4,1,12,0,1,0,0);
		SetTileTag(54,22,7,1,10,0,1,0,0);
		SetTileTag(54,23,3,1,10,0,1,0,0);
		SetTileTag(54,24,0,1,10,0,0,0,0);
		SetTileTag(54,25,0,1,10,0,0,0,0);
		SetTileTag(54,26,0,1,10,0,0,0,0);
		SetTileTag(54,27,0,1,8,0,0,0,0);
		SetTileTag(54,28,0,1,0,0,0,0,0);
		SetTileTag(54,29,0,1,0,0,0,0,0);
		SetTileTag(54,30,1,1,24,0,0,0,0);
		SetTileTag(54,31,1,1,24,0,0,0,0);
		SetTileTag(54,32,7,1,22,0,0,0,0);
		SetTileTag(54,33,7,1,20,0,0,0,0);
		SetTileTag(54,34,7,1,18,0,0,0,0);
		SetTileTag(54,35,7,1,16,0,0,0,0);
		SetTileTag(54,36,0,1,24,0,0,0,0);
		SetTileTag(54,37,0,1,20,0,0,0,0);
		SetTileTag(54,38,1,1,24,0,0,0,0);
		SetTileTag(54,39,1,1,24,0,0,0,0);
		SetTileTag(54,40,1,1,24,0,0,1,0);
		SetTileTag(54,41,1,1,24,0,0,0,0);
		SetTileTag(54,42,1,1,24,0,0,0,0);
		SetTileTag(54,43,1,1,24,0,0,0,0);
		SetTileTag(54,44,1,1,24,0,0,0,0);
		SetTileTag(54,45,1,1,24,0,0,0,0);
		SetTileTag(54,46,1,1,24,0,0,0,0);
		SetTileTag(54,47,1,1,24,0,0,1,0);
		SetTileTag(54,48,1,1,24,0,0,0,0);
		SetTileTag(54,49,1,1,24,0,0,0,0);
		SetTileTag(54,50,1,1,24,0,0,0,0);
		SetTileTag(54,51,1,1,24,0,0,0,0);
		SetTileTag(54,52,1,1,24,0,0,0,0);
		SetTileTag(54,53,1,1,24,0,0,0,0);
		SetTileTag(54,54,1,1,24,0,0,0,0);
		SetTileTag(54,55,1,1,24,0,0,0,0);
		SetTileTag(54,56,1,1,24,0,0,0,0);
		SetTileTag(54,57,1,1,24,0,0,0,0);
		SetTileTag(54,58,1,1,24,0,0,0,0);
		SetTileTag(54,59,1,1,24,0,0,0,0);
		SetTileTag(54,60,0,1,18,0,0,0,0);
		SetTileTag(54,61,0,1,18,0,0,0,0);
		SetTileTag(54,62,0,1,30,0,0,0,0);
		SetTileTag(54,63,0,1,30,0,0,0,0);
		SetTileTag(55,0,0,1,30,0,0,0,0);
		SetTileTag(55,1,0,1,30,0,0,0,0);
		SetTileTag(55,2,8,1,4,0,0,0,0);
		SetTileTag(55,3,0,1,16,0,0,0,0);
		SetTileTag(55,4,1,1,16,0,0,0,0);
		SetTileTag(55,5,1,1,16,0,0,0,0);
		SetTileTag(55,6,1,1,16,0,0,0,0);
		SetTileTag(55,7,0,1,30,0,0,0,0);
		SetTileTag(55,8,0,1,30,0,0,0,0);
		SetTileTag(55,9,1,1,16,0,0,0,0);
		SetTileTag(55,10,1,1,16,0,0,0,0);
		SetTileTag(55,11,1,1,16,0,0,0,0);
		SetTileTag(55,12,1,1,18,0,0,0,0);
		SetTileTag(55,13,1,1,20,0,0,0,0);
		SetTileTag(55,14,1,1,20,0,0,0,0);
		SetTileTag(55,15,1,1,20,0,0,0,0);
		SetTileTag(55,16,1,1,18,0,0,0,0);
		SetTileTag(55,17,0,1,30,0,0,0,0);
		SetTileTag(55,18,0,1,10,0,0,0,0);
		SetTileTag(55,19,0,1,12,0,0,0,0);
		SetTileTag(55,20,1,1,12,0,1,0,0);
		SetTileTag(55,21,1,1,12,0,1,0,0);
		SetTileTag(55,22,7,1,10,0,1,0,0);
		SetTileTag(55,23,0,1,10,0,0,0,0);
		SetTileTag(55,24,0,1,10,0,0,0,0);
		SetTileTag(55,25,0,1,10,0,0,0,0);
		SetTileTag(55,26,0,1,8,0,0,0,0);
		SetTileTag(55,27,0,1,8,0,0,0,0);
		SetTileTag(55,28,0,1,8,0,0,0,0);
		SetTileTag(55,29,0,1,8,0,0,0,0);
		SetTileTag(55,30,9,1,22,0,0,0,0);
		SetTileTag(55,31,1,1,24,0,0,0,0);
		SetTileTag(55,32,1,1,24,0,0,0,0);
		SetTileTag(55,33,1,1,24,0,0,0,0);
		SetTileTag(55,34,0,1,14,0,0,0,0);
		SetTileTag(55,35,0,1,20,0,0,0,0);
		SetTileTag(55,36,0,1,20,0,0,0,0);
		SetTileTag(55,37,0,1,14,0,0,0,0);
		SetTileTag(55,38,1,1,24,0,0,0,0);
		SetTileTag(55,39,3,1,24,0,0,0,0);
		SetTileTag(55,40,0,1,30,0,0,0,0);
		SetTileTag(55,41,0,1,30,0,0,0,0);
		SetTileTag(55,42,0,1,30,0,0,0,0);
		SetTileTag(55,43,0,1,18,0,0,0,0);
		SetTileTag(55,44,0,1,18,0,0,0,0);
		SetTileTag(55,45,0,1,18,0,0,0,0);
		SetTileTag(55,46,1,1,24,0,0,1,0);
		SetTileTag(55,47,0,1,18,0,0,0,0);
		SetTileTag(55,48,0,1,24,0,0,0,0);
		SetTileTag(55,49,1,1,24,0,0,0,0);
		SetTileTag(55,50,0,1,18,0,0,0,0);
		SetTileTag(55,51,0,1,18,0,0,0,0);
		SetTileTag(55,52,0,1,18,0,0,0,0);
		SetTileTag(55,53,0,1,18,0,0,0,0);
		SetTileTag(55,54,1,1,24,0,0,0,0);
		SetTileTag(55,55,1,1,24,0,0,0,0);
		SetTileTag(55,56,1,1,24,0,0,0,0);
		SetTileTag(55,57,0,1,18,0,0,0,0);
		SetTileTag(55,58,0,1,18,0,0,0,0);
		SetTileTag(55,59,1,1,24,0,0,1,0);
		SetTileTag(55,60,0,1,18,0,0,0,0);
		SetTileTag(55,61,0,1,18,0,0,0,0);
		SetTileTag(55,62,0,1,30,0,0,0,0);
		SetTileTag(55,63,0,1,30,0,0,0,0);
		SetTileTag(56,0,0,1,30,0,0,0,0);
		SetTileTag(56,1,0,1,30,0,0,0,0);
		SetTileTag(56,2,8,1,6,0,0,0,0);
		SetTileTag(56,3,0,1,30,0,0,0,0);
		SetTileTag(56,4,1,1,16,0,0,0,0);
		SetTileTag(56,5,1,1,16,0,0,0,0);
		SetTileTag(56,6,1,1,16,0,0,0,0);
		SetTileTag(56,7,1,1,16,0,0,0,0);
		SetTileTag(56,8,1,1,16,0,0,0,0);
		SetTileTag(56,9,1,1,16,0,0,0,0);
		SetTileTag(56,10,0,1,30,0,0,0,0);
		SetTileTag(56,11,0,1,22,0,0,0,0);
		SetTileTag(56,12,0,1,30,0,0,0,0);
		SetTileTag(56,13,0,1,30,0,0,0,0);
		SetTileTag(56,14,8,1,20,0,0,0,0);
		SetTileTag(56,15,0,1,30,0,0,0,0);
		SetTileTag(56,16,1,1,16,0,0,0,0);
		SetTileTag(56,17,0,1,30,0,0,0,0);
		SetTileTag(56,18,0,1,10,0,0,0,0);
		SetTileTag(56,19,0,1,12,0,0,0,0);
		SetTileTag(56,20,1,1,12,0,1,0,0);
		SetTileTag(56,21,3,1,12,0,1,0,0);
		SetTileTag(56,22,0,1,10,0,0,0,0);
		SetTileTag(56,23,0,1,10,0,0,0,0);
		SetTileTag(56,24,0,1,10,0,0,0,0);
		SetTileTag(56,25,0,1,10,0,0,0,0);
		SetTileTag(56,26,0,1,8,0,0,0,0);
		SetTileTag(56,27,0,1,24,0,0,0,0);
		SetTileTag(56,28,0,1,24,0,0,0,0);
		SetTileTag(56,29,0,1,24,0,0,0,0);
		SetTileTag(56,30,9,1,20,0,0,0,0);
		SetTileTag(56,31,1,1,24,0,0,0,0);
		SetTileTag(56,32,1,1,24,0,0,0,0);
		SetTileTag(56,33,1,1,24,0,0,0,0);
		SetTileTag(56,34,6,1,14,0,0,0,0);
		SetTileTag(56,35,1,1,16,0,0,0,0);
		SetTileTag(56,36,1,1,16,0,0,1,0);
		SetTileTag(56,37,1,1,16,0,0,0,0);
		SetTileTag(56,38,1,1,24,0,0,0,0);
		SetTileTag(56,39,0,1,30,0,0,0,0);
		SetTileTag(56,40,0,1,30,0,0,0,0);
		SetTileTag(56,41,0,1,30,0,0,0,0);
		SetTileTag(56,42,0,1,30,0,0,0,0);
		SetTileTag(56,43,0,1,18,0,0,0,0);
		SetTileTag(56,44,0,1,18,0,0,0,0);
		SetTileTag(56,45,1,1,24,0,0,0,0);
		SetTileTag(56,46,1,1,24,0,0,0,0);
		SetTileTag(56,47,0,1,18,0,0,0,0);
		SetTileTag(56,48,0,1,18,0,0,0,0);
		SetTileTag(56,49,1,1,24,0,0,1,0);
		SetTileTag(56,50,0,1,18,0,0,0,0);
		SetTileTag(56,51,1,1,26,0,0,0,0);
		SetTileTag(56,52,1,1,24,0,0,0,0);
		SetTileTag(56,53,0,1,18,0,0,0,0);
		SetTileTag(56,54,1,1,24,0,0,0,0);
		SetTileTag(56,55,1,1,24,0,0,0,0);
		SetTileTag(56,56,1,1,24,0,0,0,0);
		SetTileTag(56,57,0,1,18,0,0,0,0);
		SetTileTag(56,58,1,1,24,0,0,0,0);
		SetTileTag(56,59,1,1,24,0,0,0,0);
		SetTileTag(56,60,1,1,24,0,0,0,0);
		SetTileTag(56,61,0,1,18,0,0,0,0);
		SetTileTag(56,62,0,1,30,0,0,0,0);
		SetTileTag(56,63,0,1,30,0,0,0,0);
		SetTileTag(57,0,0,1,30,0,0,0,0);
		SetTileTag(57,1,0,1,30,0,0,0,0);
		SetTileTag(57,2,8,1,8,0,0,0,0);
		SetTileTag(57,3,0,1,30,0,0,0,0);
		SetTileTag(57,4,3,1,20,0,0,0,0);
		SetTileTag(57,5,0,1,30,0,0,0,0);
		SetTileTag(57,6,1,1,16,0,0,1,0);
		SetTileTag(57,7,0,1,30,0,0,0,0);
		SetTileTag(57,8,0,1,30,0,0,0,0);
		SetTileTag(57,9,0,1,30,0,0,0,0);
		SetTileTag(57,10,0,1,30,0,0,0,0);
		SetTileTag(57,11,0,1,22,0,0,0,0);
		SetTileTag(57,12,1,1,22,0,0,0,0);
		SetTileTag(57,13,1,1,22,0,0,0,0);
		SetTileTag(57,14,1,1,22,0,0,0,0);
		SetTileTag(57,15,0,1,30,0,0,0,0);
		SetTileTag(57,16,1,1,14,0,0,0,0);
		SetTileTag(57,17,1,1,14,0,0,0,0);
		SetTileTag(57,18,0,1,10,0,0,0,0);
		SetTileTag(57,19,4,1,12,0,1,0,0);
		SetTileTag(57,20,1,1,12,0,1,0,0);
		SetTileTag(57,21,0,1,12,0,0,0,0);
		SetTileTag(57,22,0,1,10,0,0,0,0);
		SetTileTag(57,23,0,1,10,0,0,0,0);
		SetTileTag(57,24,0,1,10,0,0,0,0);
		SetTileTag(57,25,0,1,10,0,0,0,0);
		SetTileTag(57,26,0,1,8,0,0,0,0);
		SetTileTag(57,27,0,1,24,0,0,0,0);
		SetTileTag(57,28,0,1,24,0,0,0,0);
		SetTileTag(57,29,0,1,24,0,0,0,0);
		SetTileTag(57,30,1,1,20,0,0,0,0);
		SetTileTag(57,31,7,1,18,0,0,0,0);
		SetTileTag(57,32,7,1,16,0,0,0,0);
		SetTileTag(57,33,7,1,14,0,0,0,0);
		SetTileTag(57,34,6,1,14,0,0,0,0);
		SetTileTag(57,35,3,1,16,0,0,0,0);
		SetTileTag(57,36,0,1,30,0,0,0,0);
		SetTileTag(57,37,8,1,16,0,0,0,0);
		SetTileTag(57,38,1,1,24,0,0,0,0);
		SetTileTag(57,39,0,1,30,0,0,0,0);
		SetTileTag(57,40,0,1,30,0,0,0,0);
		SetTileTag(57,41,0,1,30,0,0,0,0);
		SetTileTag(57,42,0,1,30,0,0,0,0);
		SetTileTag(57,43,0,1,18,0,0,0,0);
		SetTileTag(57,44,0,1,18,0,0,0,0);
		SetTileTag(57,45,1,1,24,0,0,0,0);
		SetTileTag(57,46,1,1,24,0,0,0,0);
		SetTileTag(57,47,0,1,18,0,0,0,0);
		SetTileTag(57,48,1,1,24,0,0,0,0);
		SetTileTag(57,49,1,1,24,0,0,0,0);
		SetTileTag(57,50,0,1,18,0,0,0,0);
		SetTileTag(57,51,1,1,24,0,0,0,0);
		SetTileTag(57,52,1,1,24,0,0,0,0);
		SetTileTag(57,53,1,1,24,0,0,1,0);
		SetTileTag(57,54,1,1,24,0,0,0,0);
		SetTileTag(57,55,1,1,24,0,0,0,0);
		SetTileTag(57,56,1,1,24,0,0,0,0);
		SetTileTag(57,57,0,1,24,0,0,0,0);
		SetTileTag(57,58,1,1,24,0,0,0,0);
		SetTileTag(57,59,1,1,24,0,0,0,0);
		SetTileTag(57,60,1,1,24,0,0,0,0);
		SetTileTag(57,61,0,1,18,0,0,0,0);
		SetTileTag(57,62,0,1,30,0,0,0,0);
		SetTileTag(57,63,0,1,30,0,0,0,0);
		SetTileTag(58,0,0,1,30,0,0,0,0);
		SetTileTag(58,1,0,1,30,0,0,0,0);
		SetTileTag(58,2,1,1,10,0,0,0,0);
		SetTileTag(58,3,6,1,10,0,0,0,0);
		SetTileTag(58,4,6,1,12,0,0,0,0);
		SetTileTag(58,5,6,1,14,0,0,0,0);
		SetTileTag(58,6,1,1,16,0,0,0,0);
		SetTileTag(58,7,0,1,30,0,0,0,0);
		SetTileTag(58,8,0,1,30,0,0,0,0);
		SetTileTag(58,9,0,1,30,0,0,0,0);
		SetTileTag(58,10,0,1,30,0,0,0,0);
		SetTileTag(58,11,0,1,22,0,0,0,0);
		SetTileTag(58,12,1,1,22,0,0,0,0);
		SetTileTag(58,13,1,1,26,0,0,0,0);
		SetTileTag(58,14,1,1,22,0,0,0,0);
		SetTileTag(58,15,0,1,30,0,0,0,0);
		SetTileTag(58,16,1,1,14,0,0,0,0);
		SetTileTag(58,17,1,1,14,0,0,0,0);
		SetTileTag(58,18,7,1,12,0,0,0,0);
		SetTileTag(58,19,1,1,12,0,1,0,0);
		SetTileTag(58,20,1,1,12,0,1,0,0);
		SetTileTag(58,21,0,1,12,0,0,0,0);
		SetTileTag(58,22,0,1,12,0,0,0,0);
		SetTileTag(58,23,0,1,12,0,0,0,0);
		SetTileTag(58,24,0,1,12,0,0,0,0);
		SetTileTag(58,25,0,1,8,0,0,0,0);
		SetTileTag(58,26,0,1,8,0,0,0,0);
		SetTileTag(58,27,0,1,24,0,0,0,0);
		SetTileTag(58,28,0,1,24,0,0,0,0);
		SetTileTag(58,29,0,1,24,0,0,0,0);
		SetTileTag(58,30,0,1,24,0,0,0,0);
		SetTileTag(58,31,0,1,24,0,0,0,0);
		SetTileTag(58,32,0,1,24,0,0,0,0);
		SetTileTag(58,33,0,1,24,0,0,0,0);
		SetTileTag(58,34,0,1,30,0,0,0,0);
		SetTileTag(58,35,0,1,30,0,0,0,0);
		SetTileTag(58,36,0,1,30,0,0,0,0);
		SetTileTag(58,37,8,1,18,0,0,0,0);
		SetTileTag(58,38,1,1,24,0,0,0,0);
		SetTileTag(58,39,0,1,30,0,0,0,0);
		SetTileTag(58,40,0,1,30,0,0,0,0);
		SetTileTag(58,41,0,1,30,0,0,0,0);
		SetTileTag(58,42,0,1,30,0,0,0,0);
		SetTileTag(58,43,0,1,18,0,0,0,0);
		SetTileTag(58,44,0,1,18,0,0,0,0);
		SetTileTag(58,45,1,1,24,0,0,0,0);
		SetTileTag(58,46,1,1,24,0,0,0,0);
		SetTileTag(58,47,0,1,18,0,0,0,0);
		SetTileTag(58,48,1,1,24,0,0,0,0);
		SetTileTag(58,49,1,1,24,0,0,0,0);
		SetTileTag(58,50,0,1,18,0,0,0,0);
		SetTileTag(58,51,1,1,24,0,0,0,0);
		SetTileTag(58,52,1,1,24,0,0,0,0);
		SetTileTag(58,53,0,1,18,0,0,0,0);
		SetTileTag(58,54,5,1,24,0,0,0,0);
		SetTileTag(58,55,1,1,24,0,0,0,0);
		SetTileTag(58,56,3,1,24,0,0,0,0);
		SetTileTag(58,57,0,1,18,0,0,0,0);
		SetTileTag(58,58,0,1,18,0,0,0,0);
		SetTileTag(58,59,0,1,18,0,0,0,0);
		SetTileTag(58,60,0,1,18,0,0,0,0);
		SetTileTag(58,61,0,1,18,0,0,0,0);
		SetTileTag(58,62,0,1,30,0,0,0,0);
		SetTileTag(58,63,0,1,30,0,0,0,0);
		SetTileTag(59,0,0,1,30,0,0,0,0);
		SetTileTag(59,1,0,1,30,0,0,0,0);
		SetTileTag(59,2,0,1,30,0,0,0,0);
		SetTileTag(59,3,0,1,30,0,0,0,0);
		SetTileTag(59,4,0,1,30,0,0,0,0);
		SetTileTag(59,5,0,1,30,0,0,0,0);
		SetTileTag(59,6,0,1,30,0,0,0,0);
		SetTileTag(59,7,0,1,30,0,0,0,0);
		SetTileTag(59,8,0,1,30,0,0,0,0);
		SetTileTag(59,9,0,1,30,0,0,0,0);
		SetTileTag(59,10,0,1,30,0,0,0,0);
		SetTileTag(59,11,0,1,22,0,0,0,0);
		SetTileTag(59,12,1,1,22,0,0,0,0);
		SetTileTag(59,13,1,1,22,0,0,0,0);
		SetTileTag(59,14,1,1,22,0,0,0,0);
		SetTileTag(59,15,0,1,0,0,0,0,0);
		SetTileTag(59,16,1,1,14,0,0,0,0);
		SetTileTag(59,17,1,1,14,0,0,0,0);
		SetTileTag(59,18,0,1,14,0,0,0,0);
		SetTileTag(59,19,8,1,12,0,1,0,0);
		SetTileTag(59,20,8,1,12,0,1,0,0);
		SetTileTag(59,21,0,1,14,0,0,0,0);
		SetTileTag(59,22,0,1,14,0,0,0,0);
		SetTileTag(59,23,0,1,14,0,0,0,0);
		SetTileTag(59,24,0,1,12,0,0,0,0);
		SetTileTag(59,25,0,1,8,0,0,0,0);
		SetTileTag(59,26,0,1,8,0,0,0,0);
		SetTileTag(59,27,0,1,24,0,0,0,0);
		SetTileTag(59,28,0,1,24,0,0,0,0);
		SetTileTag(59,29,0,1,24,0,0,0,0);
		SetTileTag(59,30,0,1,24,0,0,0,0);
		SetTileTag(59,31,0,1,24,0,0,0,0);
		SetTileTag(59,32,0,1,24,0,0,0,0);
		SetTileTag(59,33,0,1,24,0,0,0,0);
		SetTileTag(59,34,0,1,30,0,0,0,0);
		SetTileTag(59,35,0,1,30,0,0,0,0);
		SetTileTag(59,36,0,1,30,0,0,0,0);
		SetTileTag(59,37,8,1,20,0,0,0,0);
		SetTileTag(59,38,1,1,24,0,0,0,0);
		SetTileTag(59,39,0,1,30,0,0,0,0);
		SetTileTag(59,40,0,1,30,0,0,0,0);
		SetTileTag(59,41,0,1,30,0,0,0,0);
		SetTileTag(59,42,0,1,30,0,0,0,0);
		SetTileTag(59,43,0,1,18,0,0,0,0);
		SetTileTag(59,44,0,1,18,0,0,0,0);
		SetTileTag(59,45,1,1,24,0,0,0,0);
		SetTileTag(59,46,1,1,24,0,0,0,0);
		SetTileTag(59,47,0,1,18,0,0,0,0);
		SetTileTag(59,48,0,1,18,0,0,0,0);
		SetTileTag(59,49,0,1,30,0,0,0,0);
		SetTileTag(59,50,0,1,30,0,0,0,0);
		SetTileTag(59,51,1,1,24,0,0,0,0);
		SetTileTag(59,52,1,1,24,0,0,0,0);
		SetTileTag(59,53,0,1,18,0,0,0,0);
		SetTileTag(59,54,0,1,18,0,0,0,0);
		SetTileTag(59,55,0,1,18,0,0,0,0);
		SetTileTag(59,56,0,1,18,0,0,0,0);
		SetTileTag(59,57,0,1,18,0,0,0,0);
		SetTileTag(59,58,0,1,18,0,0,0,0);
		SetTileTag(59,59,0,1,18,0,0,0,0);
		SetTileTag(59,60,0,1,18,0,0,0,0);
		SetTileTag(59,61,0,1,18,0,0,0,0);
		SetTileTag(59,62,0,1,30,0,0,0,0);
		SetTileTag(59,63,0,1,30,0,0,0,0);
		SetTileTag(60,0,0,1,30,0,0,0,0);
		SetTileTag(60,1,0,1,30,0,0,0,0);
		SetTileTag(60,2,0,1,30,0,0,0,0);
		SetTileTag(60,3,0,1,30,0,0,0,0);
		SetTileTag(60,4,0,1,30,0,0,0,0);
		SetTileTag(60,5,0,1,30,0,0,0,0);
		SetTileTag(60,6,0,1,30,0,0,0,0);
		SetTileTag(60,7,0,1,30,0,0,0,0);
		SetTileTag(60,8,0,1,30,0,0,0,0);
		SetTileTag(60,9,0,1,30,0,0,0,0);
		SetTileTag(60,10,0,1,30,0,0,0,0);
		SetTileTag(60,11,0,1,30,0,0,0,0);
		SetTileTag(60,12,0,1,30,0,0,0,0);
		SetTileTag(60,13,0,1,30,0,0,0,0);
		SetTileTag(60,14,0,1,30,0,0,0,0);
		SetTileTag(60,15,0,1,30,0,0,0,0);
		SetTileTag(60,16,0,1,30,0,0,0,0);
		SetTileTag(60,17,0,1,14,0,0,0,0);
		SetTileTag(60,18,0,1,14,0,0,0,0);
		SetTileTag(60,19,1,1,14,0,1,0,0);
		SetTileTag(60,20,1,1,14,0,1,0,0);
		SetTileTag(60,21,0,1,14,0,0,0,0);
		SetTileTag(60,22,0,1,14,0,0,0,0);
		SetTileTag(60,23,0,1,14,0,0,0,0);
		SetTileTag(60,24,0,1,12,0,0,0,0);
		SetTileTag(60,25,0,1,8,0,0,0,0);
		SetTileTag(60,26,0,1,8,0,0,0,0);
		SetTileTag(60,27,0,1,20,0,0,0,0);
		SetTileTag(60,28,0,1,8,0,0,0,0);
		SetTileTag(60,29,0,1,8,0,0,0,0);
		SetTileTag(60,30,0,1,8,0,0,0,0);
		SetTileTag(60,31,0,1,24,0,0,0,0);
		SetTileTag(60,32,0,1,24,0,0,0,0);
		SetTileTag(60,33,0,1,24,0,0,0,0);
		SetTileTag(60,34,0,1,30,0,0,0,0);
		SetTileTag(60,35,0,1,30,0,0,0,0);
		SetTileTag(60,36,0,1,30,0,0,0,0);
		SetTileTag(60,37,8,1,22,0,0,0,0);
		SetTileTag(60,38,1,1,24,0,0,0,0);
		SetTileTag(60,39,0,1,30,0,0,0,0);
		SetTileTag(60,40,0,1,30,0,0,0,0);
		SetTileTag(60,41,0,1,30,0,0,0,0);
		SetTileTag(60,42,0,1,30,0,0,0,0);
		SetTileTag(60,43,0,1,18,0,0,0,0);
		SetTileTag(60,44,0,1,18,0,0,0,0);
		SetTileTag(60,45,0,1,18,0,0,0,0);
		SetTileTag(60,46,0,1,18,0,0,0,0);
		SetTileTag(60,47,0,1,18,0,0,0,0);
		SetTileTag(60,48,0,1,18,0,0,0,0);
		SetTileTag(60,49,1,1,24,0,1,0,0);
		SetTileTag(60,50,1,1,26,0,0,0,0);
		SetTileTag(60,51,1,1,24,0,0,0,0);
		SetTileTag(60,52,1,1,24,0,0,0,0);
		SetTileTag(60,53,0,1,18,0,0,0,0);
		SetTileTag(60,54,0,1,18,0,0,0,0);
		SetTileTag(60,55,0,1,18,0,0,0,0);
		SetTileTag(60,56,0,1,18,0,0,0,0);
		SetTileTag(60,57,0,1,18,0,0,0,0);
		SetTileTag(60,58,0,1,18,0,0,0,0);
		SetTileTag(60,59,0,1,30,0,0,0,0);
		SetTileTag(60,60,0,1,30,0,0,0,0);
		SetTileTag(60,61,0,1,30,0,0,0,0);
		SetTileTag(60,62,0,1,30,0,0,0,0);
		SetTileTag(60,63,0,1,30,0,0,0,0);
		SetTileTag(61,0,0,1,30,0,0,0,0);
		SetTileTag(61,1,0,1,30,0,0,0,0);
		SetTileTag(61,2,0,1,30,0,0,0,0);
		SetTileTag(61,3,0,1,30,0,0,0,0);
		SetTileTag(61,4,0,1,30,0,0,0,0);
		SetTileTag(61,5,0,1,30,0,0,0,0);
		SetTileTag(61,6,0,1,30,0,0,0,0);
		SetTileTag(61,7,0,1,30,0,0,0,0);
		SetTileTag(61,8,0,1,30,0,0,0,0);
		SetTileTag(61,9,0,1,30,0,0,0,0);
		SetTileTag(61,10,0,1,30,0,0,0,0);
		SetTileTag(61,11,0,1,30,0,0,0,0);
		SetTileTag(61,12,0,1,30,0,0,0,0);
		SetTileTag(61,13,0,1,30,0,0,0,0);
		SetTileTag(61,14,0,1,30,0,0,0,0);
		SetTileTag(61,15,0,1,30,0,0,0,0);
		SetTileTag(61,16,0,1,30,0,0,0,0);
		SetTileTag(61,17,0,1,14,0,0,0,0);
		SetTileTag(61,18,0,1,14,0,0,0,0);
		SetTileTag(61,19,5,1,14,0,1,0,0);
		SetTileTag(61,20,1,1,14,0,1,0,0);
		SetTileTag(61,21,2,1,14,0,1,0,0);
		SetTileTag(61,22,0,1,14,0,0,0,0);
		SetTileTag(61,23,0,1,14,0,0,0,0);
		SetTileTag(61,24,0,1,12,0,0,0,0);
		SetTileTag(61,25,0,1,8,0,0,0,0);
		SetTileTag(61,26,0,1,8,0,0,0,0);
		SetTileTag(61,27,0,1,8,0,0,0,0);
		SetTileTag(61,28,0,1,8,0,0,0,0);
		SetTileTag(61,29,0,1,8,0,0,0,0);
		SetTileTag(61,30,0,1,8,0,0,0,0);
		SetTileTag(61,31,0,1,8,0,0,0,0);
		SetTileTag(61,32,0,1,8,0,0,0,0);
		SetTileTag(61,33,0,1,30,0,0,0,0);
		SetTileTag(61,34,0,1,30,0,0,0,0);
		SetTileTag(61,35,0,1,30,0,0,0,0);
		SetTileTag(61,36,0,1,30,0,0,0,0);
		SetTileTag(61,37,1,1,24,0,0,0,0);
		SetTileTag(61,38,1,1,24,0,0,0,0);
		SetTileTag(61,39,0,1,30,0,0,0,0);
		SetTileTag(61,40,0,1,30,0,0,0,0);
		SetTileTag(61,41,0,1,30,0,0,0,0);
		SetTileTag(61,42,0,1,30,0,0,0,0);
		SetTileTag(61,43,0,1,30,0,0,0,0);
		SetTileTag(61,44,0,1,30,0,0,0,0);
		SetTileTag(61,45,0,1,30,0,0,0,0);
		SetTileTag(61,46,0,1,30,0,0,0,0);
		SetTileTag(61,47,0,1,30,0,0,0,0);
		SetTileTag(61,48,0,1,30,0,0,0,0);
		SetTileTag(61,49,0,1,30,0,0,0,0);
		SetTileTag(61,50,0,1,30,0,0,0,0);
		SetTileTag(61,51,0,1,30,0,0,0,0);
		SetTileTag(61,52,0,1,30,0,0,0,0);
		SetTileTag(61,53,0,1,30,0,0,0,0);
		SetTileTag(61,54,0,1,30,0,0,0,0);
		SetTileTag(61,55,0,1,30,0,0,0,0);
		SetTileTag(61,56,0,1,30,0,0,0,0);
		SetTileTag(61,57,0,1,30,0,0,0,0);
		SetTileTag(61,58,0,1,30,0,0,0,0);
		SetTileTag(61,59,0,1,30,0,0,0,0);
		SetTileTag(61,60,0,1,30,0,0,0,0);
		SetTileTag(61,61,0,1,30,0,0,0,0);
		SetTileTag(61,62,0,1,30,0,0,0,0);
		SetTileTag(61,63,0,1,30,0,0,0,0);
		SetTileTag(62,0,0,1,30,0,0,0,0);
		SetTileTag(62,1,0,1,30,0,0,0,0);
		SetTileTag(62,2,0,1,30,0,0,0,0);
		SetTileTag(62,3,0,1,30,0,0,0,0);
		SetTileTag(62,4,0,1,30,0,0,0,0);
		SetTileTag(62,5,0,1,30,0,0,0,0);
		SetTileTag(62,6,0,1,30,0,0,0,0);
		SetTileTag(62,7,0,1,30,0,0,0,0);
		SetTileTag(62,8,0,1,30,0,0,0,0);
		SetTileTag(62,9,0,1,30,0,0,0,0);
		SetTileTag(62,10,0,1,30,0,0,0,0);
		SetTileTag(62,11,0,1,30,0,0,0,0);
		SetTileTag(62,12,0,1,30,0,0,0,0);
		SetTileTag(62,13,0,1,30,0,0,0,0);
		SetTileTag(62,14,0,1,30,0,0,0,0);
		SetTileTag(62,15,0,1,30,0,0,0,0);
		SetTileTag(62,16,0,1,30,0,0,0,0);
		SetTileTag(62,17,0,1,30,0,0,0,0);
		SetTileTag(62,18,0,1,30,0,0,0,0);
		SetTileTag(62,19,0,1,30,0,0,0,0);
		SetTileTag(62,20,0,1,30,0,0,0,0);
		SetTileTag(62,21,0,1,30,0,0,0,0);
		SetTileTag(62,22,0,1,30,0,0,0,0);
		SetTileTag(62,23,0,1,30,0,0,0,0);
		SetTileTag(62,24,0,1,8,0,0,0,0);
		SetTileTag(62,25,0,1,8,0,0,0,0);
		SetTileTag(62,26,0,1,8,0,0,0,0);
		SetTileTag(62,27,0,1,8,0,0,0,0);
		SetTileTag(62,28,0,1,8,0,0,0,0);
		SetTileTag(62,29,0,1,8,0,0,0,0);
		SetTileTag(62,30,0,1,8,0,0,0,0);
		SetTileTag(62,31,0,1,8,0,0,0,0);
		SetTileTag(62,32,0,1,8,0,0,0,0);
		SetTileTag(62,33,0,1,30,0,0,0,0);
		SetTileTag(62,34,0,1,30,0,0,0,0);
		SetTileTag(62,35,0,1,30,0,0,0,0);
		SetTileTag(62,36,0,1,24,0,0,0,0);
		SetTileTag(62,37,0,1,30,0,0,0,0);
		SetTileTag(62,38,0,1,30,0,0,0,0);
		SetTileTag(62,39,0,1,30,0,0,0,0);
		SetTileTag(62,40,0,1,30,0,0,0,0);
		SetTileTag(62,41,0,1,30,0,0,0,0);
		SetTileTag(62,42,0,1,30,0,0,0,0);
		SetTileTag(62,43,0,1,30,0,0,0,0);
		SetTileTag(62,44,0,1,30,0,0,0,0);
		SetTileTag(62,45,0,1,30,0,0,0,0);
		SetTileTag(62,46,0,1,30,0,0,0,0);
		SetTileTag(62,47,0,1,30,0,0,0,0);
		SetTileTag(62,48,0,1,30,0,0,0,0);
		SetTileTag(62,49,0,1,30,0,0,0,0);
		SetTileTag(62,50,0,1,30,0,0,0,0);
		SetTileTag(62,51,0,1,30,0,0,0,0);
		SetTileTag(62,52,0,1,30,0,0,0,0);
		SetTileTag(62,53,0,1,30,0,0,0,0);
		SetTileTag(62,54,0,1,30,0,0,0,0);
		SetTileTag(62,55,0,1,30,0,0,0,0);
		SetTileTag(62,56,0,1,30,0,0,0,0);
		SetTileTag(62,57,0,1,30,0,0,0,0);
		SetTileTag(62,58,0,1,30,0,0,0,0);
		SetTileTag(62,59,0,1,30,0,0,0,0);
		SetTileTag(62,60,0,1,30,0,0,0,0);
		SetTileTag(62,61,0,1,30,0,0,0,0);
		SetTileTag(62,62,0,1,30,0,0,0,0);
		SetTileTag(62,63,0,1,30,0,0,0,0);
		SetTileTag(63,0,0,1,30,0,0,0,0);
		SetTileTag(63,1,0,1,30,0,0,0,0);
		SetTileTag(63,2,0,1,30,0,0,0,0);
		SetTileTag(63,3,0,1,30,0,0,0,0);
		SetTileTag(63,4,0,1,30,0,0,0,0);
		SetTileTag(63,5,0,1,30,0,0,0,0);
		SetTileTag(63,6,0,1,30,0,0,0,0);
		SetTileTag(63,7,0,1,30,0,0,0,0);
		SetTileTag(63,8,0,1,30,0,0,0,0);
		SetTileTag(63,9,0,1,30,0,0,0,0);
		SetTileTag(63,10,0,1,30,0,0,0,0);
		SetTileTag(63,11,0,1,30,0,0,0,0);
		SetTileTag(63,12,0,1,30,0,0,0,0);
		SetTileTag(63,13,0,1,30,0,0,0,0);
		SetTileTag(63,14,0,1,30,0,0,0,0);
		SetTileTag(63,15,0,1,30,0,0,0,0);
		SetTileTag(63,16,0,1,30,0,0,0,0);
		SetTileTag(63,17,0,1,30,0,0,0,0);
		SetTileTag(63,18,0,1,30,0,0,0,0);
		SetTileTag(63,19,0,1,30,0,0,0,0);
		SetTileTag(63,20,0,1,30,0,0,0,0);
		SetTileTag(63,21,0,1,30,0,0,0,0);
		SetTileTag(63,22,0,1,30,0,0,0,0);
		SetTileTag(63,23,0,1,30,0,0,0,0);
		SetTileTag(63,24,0,1,30,0,0,0,0);
		SetTileTag(63,25,0,1,30,0,0,0,0);
		SetTileTag(63,26,0,1,30,0,0,0,0);
		SetTileTag(63,27,0,1,30,0,0,0,0);
		SetTileTag(63,28,0,1,30,0,0,0,0);
		SetTileTag(63,29,0,1,30,0,0,0,0);
		SetTileTag(63,30,0,1,30,0,0,0,0);
		SetTileTag(63,31,0,1,30,0,0,0,0);
		SetTileTag(63,32,0,1,30,0,0,0,0);
		SetTileTag(63,33,0,1,30,0,0,0,0);
		SetTileTag(63,34,0,1,30,0,0,0,0);
		SetTileTag(63,35,0,1,30,0,0,0,0);
		SetTileTag(63,36,0,1,30,0,0,0,0);
		SetTileTag(63,37,0,1,30,0,0,0,0);
		SetTileTag(63,38,0,1,30,0,0,0,0);
		SetTileTag(63,39,0,1,30,0,0,0,0);
		SetTileTag(63,40,0,1,30,0,0,0,0);
		SetTileTag(63,41,0,1,30,0,0,0,0);
		SetTileTag(63,42,0,1,30,0,0,0,0);
		SetTileTag(63,43,0,1,30,0,0,0,0);
		SetTileTag(63,44,0,1,30,0,0,0,0);
		SetTileTag(63,45,0,1,30,0,0,0,0);
		SetTileTag(63,46,0,1,30,0,0,0,0);
		SetTileTag(63,47,0,1,30,0,0,0,0);
		SetTileTag(63,48,0,1,30,0,0,0,0);
		SetTileTag(63,49,0,1,30,0,0,0,0);
		SetTileTag(63,50,0,1,30,0,0,0,0);
		SetTileTag(63,51,0,1,30,0,0,0,0);
		SetTileTag(63,52,0,1,30,0,0,0,0);
		SetTileTag(63,53,0,1,30,0,0,0,0);
		SetTileTag(63,54,0,1,30,0,0,0,0);
		SetTileTag(63,55,0,1,30,0,0,0,0);
		SetTileTag(63,56,0,1,30,0,0,0,0);
		SetTileTag(63,57,0,1,30,0,0,0,0);
		SetTileTag(63,58,0,1,30,0,0,0,0);
		SetTileTag(63,59,0,1,30,0,0,0,0);
		SetTileTag(63,60,0,1,30,0,0,0,0);
		SetTileTag(63,61,0,1,30,0,0,0,0);
		SetTileTag(63,62,0,1,30,0,0,0,0);
		SetTileTag(63,63,0,1,30,0,0,0,0);*/
	}


	[MenuItem("MyTools/CreateNavMeshes")]
	static void CreateNavMeshObjects()
	{
		//THIS DOES NOT WORK ~!!!!
		return;
	/*	
		for (int x=0; x< 15; x++)
		{
		GameObject myObj = new GameObject();
			myObj.name="Navmesh_" + x;

		myObj.transform.position=new Vector3(38.36103f, 0.0f, 38.44547f);
		myObj.transform.localScale=new Vector3(8.117478f, 0.8f, 7.982839f);

		RAIN.Navigation.NavMesh.NavMeshRig nav=myObj.AddComponent<RAIN.Navigation.NavMesh.NavMeshRig>(); 
		//nav	=GameObject.Find ("GroundMesh").GetComponent<RAIN.Navigation.NavMesh>();
		//	nav.NavMesh.GraphTags.IsReadOnly=false;
		//	nav.NavMesh.GraphTags.Add("LAND");
		//nav.NavMesh.Graph.Tags.Add("LAND");


			for (int y =0; y< 15;y++)
			{
				nav.NavMesh.UnwalkableTags.Add("WATER_" + y);
				if ( y != x)
				{
					nav.NavMesh.UnwalkableTags.Add("ROOM_" + y);
				}					
			}
		}
		*/
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
			Debug.Log (myObj.name + " is enchanted. Take a look at it please.");
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

	static void Create_a_create_object_trap(GameObject myObj)
	{
		//Add some gamevars
		//ObjectVariables objVar = 
		//myObj.AddComponent<ObjectVariables>();
		myObj.AddComponent<a_create_object_trap>();
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

	static void CreateDoor(GameObject myObj, string DoorTexturePath, int DoorKey, int Locked)
	{
		GameObject myInstance = Resources.Load("Models/uw1_door") as GameObject;
		GameObject newObj = (GameObject)GameObject.Instantiate(myInstance);
		ObjectInteraction doorInteract = myObj.GetComponent<ObjectInteraction>();
		//doorInteract.isDoor=true;
		//doorInteract.ItemType=4;
		//doorInteract.item_id=-1;//ugh
		doorInteract.Link = DoorKey;
		newObj.name=myObj.name + "_Model";
		newObj.transform.parent=myObj.transform;
		newObj.transform.position = myObj.transform.position;
		newObj.GetComponent<Renderer>().material.mainTexture= Resources.Load <Texture2D> (DoorTexturePath);
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
	}

	static void CreatePortcullis(GameObject myObj, int DoorKey, int Locked)
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
		myObj.AddComponent<Readable>();
		ObjectInteraction objINt = myObj.GetComponent<ObjectInteraction>();
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
		cn.NoOfSlots = NoOfSlots;
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
			case 255://No conversation/monsters
			case 258:
			case 259:
			case 261:
			case 264:
			case 265:
			case 266:
			case 273:
			case 274:
			case 275:
			case 279:
			case 284:
			case 283:
			case 294:
			case 298:
			case 303:
			case 308:
				break;
			case 1://Corby
				cnv=(Conversation)myObj.AddComponent<Conversation_1>();break;
			case 2://Shak
				cnv=(Conversation)myObj.AddComponent<Conversation_1>();break;
			case 3://Goldthirst
				cnv=(Conversation)myObj.AddComponent<Conversation_3>();break;
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
			case 24://prisoner
				cnv=(Conversation)myObj.AddComponent<Conversation_24>();break;
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
			case 149://Meredith
				cnv=(Conversation)myObj.AddComponent<Conversation_149>();break;
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
		SpriteController.transform.parent = myObj.transform;
		SpriteController.transform.localScale=new Vector3(0.1f,0.5f,0.5f);
		SpriteController.transform.localPosition=new Vector3(0.0f,0.25f,0.0f);
		MeshRenderer mr = SpriteController.GetComponent<MeshRenderer>();
		mr.material= (Material)Resources.Load ("Materials/tmobj/tmobj_" + tmObj_index);

		BoxCollider bx = myObj.GetComponent<BoxCollider>();
		bx.center= new Vector3(0.0f,0.25f,0.0f);
		bx.size=new Vector3(0.1f,0.5f,0.5f);
		bx.isTrigger=false;

		bx=SpriteController.GetComponent<BoxCollider>();
		bx.enabled=false;
		Component.DestroyImmediate (bx);
		

	}

	static void AddFishingPole(GameObject myObj)
	{
		myObj.AddComponent<FishingPole>();
	}

	static void AddInstrument(GameObject myObj)
	{
		myObj.AddComponent<Instrument>();
		AudioSource audio = myObj.AddComponent<AudioSource>();
		audio.loop=false;
		audio.playOnAwake=false;
		audio.clip=Resources.Load <AudioClip>("SFX/instrument");
	}


}


