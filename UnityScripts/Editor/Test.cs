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
		myObj= CreateGameObject("BROKEN_LEVER_04_04_01_0049",4.800000f,4.462500f,5.695313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0615",true);
		
		myObj= CreateGameObject("FRAGMENTATION_GRENADE_04_04_01_0648",5.400000f,0.150000f,5.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0177",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,55, 0);
		
		myObj= CreateGameObject("FRAGMENTATION_GRENADE_04_04_01_0647",5.400000f,0.150000f,5.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0177",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,55, 0);
		
		myObj= CreateGameObject("SV_TRANQ_DARTS_04_04_01_0387",5.400000f,0.093750f,5.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0058",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,19, 0);
		
		myObj= CreateGameObject("SV_NEEDLE_DARTS_04_04_01_0489",5.400000f,0.093750f,5.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0055",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,18, 0);
		
		myObj= CreateGameObject("SV_NEEDLE_DARTS_04_04_01_0436",5.400000f,0.093750f,5.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0055",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,18, 0);
		
		myObj= CreateGameObject("SV_NEEDLE_DARTS_04_04_01_0660",5.400000f,0.093750f,5.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0055",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,18, 0);
		
		myObj= CreateGameObject("SV_NEEDLE_DARTS_04_04_01_0493",5.400000f,0.093750f,5.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0055",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,18, 0);
		
		myObj= CreateGameObject("GROUP_ACCESS_CARD_2",5.400000f,0.131250f,5.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0788",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",5,233, 0);
		CreateKey(myObj, 0);
		
		myObj= CreateGameObject("FRAGMENTATION_GRENADE_04_04_01_0477",5.400000f,0.150000f,5.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0177",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,55, 0);
		
		myObj= CreateGameObject("BEVERAGE_CONTAINER_04_04_01_0478",5.400000f,0.093750f,5.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0568",true);
		
		myObj= CreateGameObject("SKULL_04_04_01_0479",5.400000f,0.112500f,5.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0718",true);
		
		myObj= CreateGameObject("SKULL_04_04_01_0481",5.400000f,0.112500f,5.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0718",true);
		
		myObj= CreateGameObject("LAND_MINE_04_04_01_0671",5.400000f,0.150000f,5.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0189",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,59, 0);
		
		myObj= CreateGameObject("LAND_MINE_04_04_01_0492",5.400000f,0.150000f,5.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0189",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,59, 0);
		
		myObj= CreateGameObject("FRAGMENTATION_GRENADE_04_04_01_0664",5.400000f,0.150000f,5.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0177",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,55, 0);
		
		myObj= CreateGameObject("BIOLOGICAL_SYSTEMS_MONITOR_04_04_01_0550",5.400000f,0.131250f,5.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0235",true);
		
		myObj= CreateGameObject("FRAGMENTATION_GRENADE_04_04_01_0549",5.400000f,0.150000f,5.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0177",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,55, 0);
		
		myObj= CreateGameObject("FRAGMENTATION_GRENADE_04_04_01_0548",5.400000f,0.150000f,5.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0177",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,55, 0);
		
		myObj= CreateGameObject("MULTIMEDIA_DATA_READER_04_04_01_0147",5.400000f,0.075000f,5.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0246",true);
		
		myObj= CreateGameObject("EMAIL_04_04_01_0321",5.395312f,0.093750f,5.770312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0281",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",13,105, 0);
		
		myObj= CreateGameObject("SV_NEEDLE_DARTS_04_04_01_0018",5.400000f,0.093750f,5.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0055",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,18, 0);
		
		myObj= CreateGameObject("BIOLOGICAL_SYSTEMS_MONITOR_04_04_01_0138",5.470313f,0.131250f,5.657813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0235",true);
		
		myObj= CreateGameObject("REPORT_THIS_AS_A_BUG_27_08_01_0710",32.995312f,2.550000f,10.795313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("REPORT_THIS_AS_A_BUG_28_08_01_0712",34.195313f,2.550000f,10.795313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("REPORT_THIS_AS_A_BUG_30_08_01_0711",36.595314f,2.550000f,10.795313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("REPORT_THIS_AS_A_BUG_31_08_01_0709",37.795311f,2.550000f,10.795313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("REPORT_THIS_AS_A_BUG_33_08_01_0045",40.195313f,2.550000f,10.795313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("REPORT_THIS_AS_A_BUG_34_08_01_0564",41.395313f,2.550000f,10.795313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("REPORT_THIS_AS_A_BUG_36_08_01_0571",43.795311f,2.550000f,10.795313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("REPORT_THIS_AS_A_BUG_37_08_01_0039",44.995312f,2.550000f,10.795313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("BROKEN_GUN_28_09_01_0265",33.670311f,1.368750f,11.995313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0592",true);
		
		myObj= CreateGameObject("HUMAN_CORPSE_31_09_01_0268",37.607811f,1.575000f,11.995313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0642",true);
		
		myObj= CreateGameObject("GRAFFITI_34_09_01_0512",41.245312f,1.631250f,11.432813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0399",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",62,128, 0);
		
		myObj= CreateGameObject("BULLET_HOLE_36_09_01_0500",44.207813f,1.631250f,11.245313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0836",true);
		
		myObj= CreateGameObject("BULLET_HOLE_37_09_01_0046",45.257813f,1.706250f,11.095312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0836",true);
		
		myObj= CreateGameObject("BULLET_HOLE_37_09_01_0077",45.000000f,1.537500f,11.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0836",true);
		
		myObj= CreateGameObject("LAND_MINE_20_10_01_0339",24.600000f,1.350000f,12.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0189",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,59, 0);
		
		myObj= CreateGameObject("GAS_GRENADE_20_10_01_0087",24.782812f,1.350000f,12.196875f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0183",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,57, 0);
		
		myObj= CreateGameObject("FRAGMENTATION_GRENADE_20_10_01_0088",24.857813f,1.350000f,12.707812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0177",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,55, 0);
		
		myObj= CreateGameObject("CRATE_21_10_01_0518",25.570313f,1.387500f,12.407812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1400",true);
		
		myObj= CreateGameObject("CRATE_21_10_01_0517",25.457813f,1.387500f,12.857813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1400",true);
		
		myObj= CreateGameObject("CRATE_22_10_01_0521",27.332813f,1.387500f,12.820313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1400",true);
		
		myObj= CreateGameObject("HUMAN_CORPSE_23_10_01_0467",28.420313f,1.556250f,12.970312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0632",true);
		
		myObj= CreateGameObject("HUMAN_CORPSE_23_10_01_0466",28.200001f,1.462500f,12.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0692",true);
		
		myObj= CreateGameObject("SPARQ_BEAM_24_10_01_0323",29.400000f,1.293750f,12.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0034",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,11, 0);
		
		myObj= CreateGameObject("HUMAN_CORPSE_26_10_01_0256",31.799999f,1.575000f,12.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0672",true);
		
		myObj= CreateGameObject("SKULL_27_10_01_0056",33.000000f,1.312500f,12.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0718",true);
		
		myObj= CreateGameObject("HUMAN_CORPSE_28_10_01_0099",34.200001f,1.462500f,12.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0692",true);
		
		myObj= CreateGameObject("DARK_LORD_TUAOHTUA_29_10_01_0704",35.400002f,1.800000f,12.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("HUMAN_CORPSE_30_10_01_0270",36.599998f,1.575000f,12.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0672",true);
		
		myObj= CreateGameObject("HUMAN_CORPSE_32_10_01_0267",39.000000f,1.575000f,12.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0672",true);
		
		myObj= CreateGameObject("BROKEN_GUN_32_10_01_0279",38.657814f,1.368750f,12.670313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0592",true);
		
		myObj= CreateGameObject("HUMAN_CORPSE_33_10_01_0280",40.200001f,1.575000f,12.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0642",true);
		
		myObj= CreateGameObject("BROKEN_GUN_36_10_01_0275",44.095314f,1.368750f,13.157812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0592",true);
		
		myObj= CreateGameObject("SKELETON_36_10_01_0274",43.682812f,1.575000f,13.157812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0702",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,210, 0);
		
		myObj= CreateGameObject("HUMAN_CORPSE_37_10_01_0196",45.000000f,1.556250f,12.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0642",true);
		
		myObj= CreateGameObject("BRIEFCASE_38_10_01_0246",46.200001f,1.443750f,12.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0588",true);
		
		myObj= CreateGameObject("STAMINUP__STIMULANT_20_11_01_0342",24.107813f,1.350000f,14.207812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0200",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,63, 0);
		
		myObj= CreateGameObject("SKULL_20_11_01_0341",24.482813f,1.312500f,14.320313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0718",true);
		
		myObj= CreateGameObject("HUMANOID_MUTANT_20_11_01_0340",24.000000f,1.593750f,13.945313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1541",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,439, 0);
		
		myObj= CreateGameObject("SPARQ_BEAM_21_11_01_0410",25.457813f,1.293750f,13.382813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0034",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,11, 0);
		
		myObj= CreateGameObject("CRATE_21_11_01_0516",25.645313f,1.387500f,14.132813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1400",true);
		
		myObj= CreateGameObject("HUMAN_CORPSE_21_11_01_0469",26.057812f,1.462500f,13.232813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0692",true);
		
		myObj= CreateGameObject("CRATE_22_11_01_0519",27.000000f,1.575000f,13.800000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1402",true);
		
		myObj= CreateGameObject("HUMAN_CORPSE_24_11_01_0464",29.432812f,1.556250f,13.200000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0642",true);
		
		myObj= CreateGameObject("BROKEN_GUN_26_11_01_0127",32.207813f,1.368750f,13.532812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0592",true);
		
		myObj= CreateGameObject("HUMAN_CORPSE_26_11_01_0052",32.170311f,1.575000f,13.345312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0632",true);
		
		myObj= CreateGameObject("STAMINUP__STIMULANT_26_11_01_0070",31.799999f,1.350000f,13.800000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0200",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,63, 0);
		
		myObj= CreateGameObject("STAMINUP__STIMULANT_26_11_01_0075",32.020313f,1.350000f,14.020312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0200",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,63, 0);
		
		myObj= CreateGameObject("BUTTON_27_11_01_0703",33.482811f,1.800000f,14.395312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0885",false);
		CreateSHOCKActivators(myObj,7);
		AddACTION_LIGHTING(myObj);
		
		myObj= CreateGameObject("HUMAN_CORPSE_27_11_01_0161",32.620312f,1.575000f,13.720312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0642",true);
		
		myObj= CreateGameObject("CART_29_11_01_0611",35.400002f,1.200000f,13.800000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("HUMAN_CORPSE_31_11_01_0269",37.799999f,1.462500f,13.800000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0692",true);
		
		myObj= CreateGameObject("GRATING_33_11_01_0175",40.200001f,1.800000f,14.395312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1076",true);
		
		myObj= CreateGameObject("EXPLOSION_RESIDUE_34_11_01_0277",41.395313f,1.200000f,13.757813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0840",true);
		
		myObj= CreateGameObject("GRATING_34_11_01_0003",41.400002f,1.800000f,14.395312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1076",true);
		
		myObj= CreateGameObject("HUMAN_CORPSE_37_11_01_0273",45.332813f,1.575000f,14.020312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0632",true);
		
		myObj= CreateGameObject("BULLET_HOLE_38_11_01_0065",45.782814f,2.118750f,14.395312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0836",true);
		
		myObj= CreateGameObject("BULLET_HOLE_38_11_01_0396",46.795311f,1.781250f,13.607813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0836",true);
		
		myObj= CreateGameObject("BLOOD_STAIN_38_11_01_0379",46.270313f,1.200000f,13.757813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0846",true);
		
		myObj= CreateGameObject("EMAIL_38_11_01_0319",46.200001f,1.293750f,13.800000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0281",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",13,105, 0);
		
		myObj= CreateGameObject("NULL_TRIGGER_17_12_01_0163",21.000000f,1.800000f,15.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 12,0,0,0,0,0);
		AddACTION_CHOICE(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_17_12_01_0337",21.000000f,1.800000f,15.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 7,0,0,0,0,0);
		AddACTION_LIGHTING(myObj);
		
		myObj= CreateGameObject("KEYPAD_PANEL_23_12_01_0291",27.600000f,2.062500f,14.695313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0991",false);
		CreateSHOCKActivators(myObj,0);
		AddACTION_DO_NOTHING(myObj);
		
		myObj= CreateGameObject("STORAGE_ROOM_DOOR_023_012",28.200001f,1.200000f,14.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1045",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,0,1,2406);
		
		myObj= CreateGameObject("ICON_23_12_01_0515",27.600000f,2.006250f,15.482813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0395",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",62,127, 0);
		
		myObj= CreateGameObject("HUMAN_BONES_26_12_01_0072",31.457813f,1.462500f,14.957812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0712",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,211, 0);
		
		myObj= CreateGameObject("CAMERA_28_12_01_0421",33.599998f,2.193750f,14.470312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("DOOR_028_012",34.200001f,1.200000f,14.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1039",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,0,0,2404);
		
		myObj= CreateGameObject("BEAM_BLAST_35_12_01_0057",42.599998f,1.650000f,15.595312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0831",true);
		
		myObj= CreateGameObject("GRAFFITI_36_12_01_0513",44.395313f,1.912500f,14.995313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0399",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",62,128, 0);
		
		myObj= CreateGameObject("REPAIRBOT_21_13_01_0192",25.799999f,1.593750f,16.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1571",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,449, 0);
		
		myObj= CreateGameObject("SEVERED_HEAD_25_13_01_0083",30.600000f,1.425000f,16.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0724",true);
		
		myObj= CreateGameObject("DARK_LORD_TUAOHTUA_27_13_01_0707",33.000000f,1.800000f,16.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("BUTTON_27_13_01_0702",32.995312f,2.100000f,16.795313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0885",false);
		CreateSHOCKActivators(myObj,7);
		AddACTION_LIGHTING(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_29_13_01_0211",35.400002f,1.800000f,16.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 7,0,0,0,0,0);
		AddACTION_LIGHTING(myObj);
		
		myObj= CreateGameObject("HUMANOID_MUTANT_30_13_01_0203",36.028126f,1.593750f,16.546875f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1541",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,439, 0);
		
		myObj= CreateGameObject("DOOR_034_013",41.400002f,1.200000f,16.795313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1039",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,0,0,2404);
		
		myObj= CreateGameObject("BLAST_DOOR_036_013",43.799999f,1.200000f,15.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1027",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,10,0,2400);
		
		myObj= CreateGameObject("SERVICE_ACCESS_DOOR_024_014",29.400000f,1.200000f,16.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1030",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,0,0,2401);
		
		myObj= CreateGameObject("NULL_TRIGGER_26_14_01_0300",31.799999f,1.593750f,17.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "",0,"",0,"",0,"",0);
		
		myObj= CreateGameObject("SWITCH_27_14_01_0210",33.000000f,1.275000f,17.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0881",false);
		CreateSHOCKActivators(myObj,0);
		AddACTION_DO_NOTHING(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_29_14_01_0680",35.400002f,1.800000f,17.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 11,0,0,0,0,0);
		AddACTION_TIMER(myObj);
		
		myObj= CreateGameObject("CAMERA_30_14_01_0420",36.632813f,3.543750f,16.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("CHAIR_35_14_01_0378",42.632813f,1.200000f,17.470312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("HUMAN_CORPSE_36_14_01_0111",44.395313f,1.462500f,17.245312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0692",true);
		
		myObj= CreateGameObject("HUMAN_CORPSE_38_14_01_0281",46.200001f,1.575000f,17.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0672",true);
		
		myObj= CreateGameObject("BROKEN_GUN_38_14_01_0282",46.457813f,1.368750f,17.132813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0592",true);
		
		myObj= CreateGameObject("EMAIL_40_14_01_0318",48.220314f,1.293750f,17.732813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0281",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",13,105, 0);
		
		myObj= CreateGameObject("HUMAN_CORPSE_40_14_01_0283",48.257813f,1.556250f,17.282812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0632",true);
		
		myObj= CreateGameObject("HUMANOID_MUTANT_41_14_01_0286",49.799999f,1.593750f,17.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1541",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,439, 0);
		
		myObj= CreateGameObject("LARGE_BUTTON_23_15_01_0289",28.232813f,1.912500f,18.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0905",false);
		CreateSHOCKActivators(myObj,7);
		AddACTION_LIGHTING(myObj);
		
		myObj= CreateGameObject("FERN_28_15_01_0122",34.200001f,1.350000f,18.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0507",true);
		
		
		myObj= CreateGameObject("CRATE_32_15_01_0468",39.107811f,3.787500f,18.820313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1400",true);
		
		myObj= CreateGameObject("CRATE_33_15_01_0134",39.632813f,3.787500f,18.970312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1400",true);
		
		myObj= CreateGameObject("GAS_GRENADE_35_15_01_0706",43.045311f,1.350000f,18.370312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0183",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,57, 0);
		
		myObj= CreateGameObject("DESK_35_15_01_0069",42.295311f,1.200000f,18.407812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("DEBRIS_39_15_01_0383",47.357811f,1.256250f,18.745312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0598",true);
		
		myObj= CreateGameObject("DEBRIS_43_15_01_0384",52.307812f,1.181250f,18.932812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0601",true);
		
		myObj= CreateGameObject("HUMAN_CORPSE_21_16_01_0118",25.799999f,0.356250f,19.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0672",true);
		
		myObj= CreateGameObject("SMALL_PLANT_27_16_01_0124",32.695313f,1.425000f,19.945313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0516",true);
		
		myObj= CreateGameObject("GRASS_29_16_01_0073",35.400002f,1.575000f,19.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0495",true);
		
		myObj= CreateGameObject("SIGN_30_16_01_0514",37.195313f,2.325000f,19.795313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0390",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",62,126, 0);
		
		myObj= CreateGameObject("HUMANOID_MUTANT_37_16_01_0285",45.032814f,1.593750f,19.645313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1541",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,439, 0);
		
		myObj= CreateGameObject("DEBRIS_38_16_01_0197",46.270313f,1.500000f,19.682812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0604",true);
		
		myObj= CreateGameObject("HUMANOID_MUTANT_42_16_01_0287",51.000000f,1.593750f,19.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1541",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,439, 0);
		
		myObj= CreateGameObject("NULL_TRIGGER_15_17_01_0578",18.600000f,2.400000f,21.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 0,0,0,0,0,0);
		AddACTION_DO_NOTHING(myObj);
		
		myObj= CreateGameObject("ECOLOGY_TRIGGER_16_17_01_0437",19.799999f,1.800000f,21.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1373",true);
		
		myObj= CreateGameObject("WORDS_16_17_01_0248",19.232813f,2.662500f,20.882813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("WORDS_16_17_01_0249",19.200001f,2.418750f,21.145313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("CAMERA_16_17_01_0415",20.395313f,3.243750f,20.582813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("NULL_TRIGGER_17_17_01_0288",21.000000f,1.800000f,21.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "",0,"",0,"",0,"",0);
		
		myObj= CreateGameObject("ACCESS_PANEL_18_17_01_0577",22.795313f,1.950000f,21.267187f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0959",false);
		CreateSHOCKActivators(myObj,0);
		AddACTION_DO_NOTHING(myObj);
		
		myObj= CreateGameObject("MEDIPATCH__HEALING_AGENT_18_17_01_0137",21.895313f,1.537500f,20.807812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,66, 0);
		
		myObj= CreateGameObject("MEDIPATCH__HEALING_AGENT_22_17_01_0658",26.807812f,3.600000f,21.107813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,66, 0);
		
		myObj= CreateGameObject("MEDIPATCH__HEALING_AGENT_22_17_01_0657",26.920313f,3.600000f,21.332813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,66, 0);
		
		myObj= CreateGameObject("SHRUB_28_17_01_0081",34.200001f,1.781250f,21.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0492",true);
		
		myObj= CreateGameObject("EMAIL_29_17_01_0462",35.807812f,1.293750f,20.882813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0281",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",13,105, 0);
		
		myObj= CreateGameObject("GRASS_29_17_01_0080",35.400002f,1.575000f,21.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0495",true);
		
		myObj= CreateGameObject("SEVERED_HEAD_30_17_01_0156",36.970314f,1.425000f,20.920313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0734",true);
		
		myObj= CreateGameObject("HUMAN_CORPSE_30_17_01_0461",36.599998f,1.556250f,21.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0642",true);
		
		myObj= CreateGameObject("DH_07_STUNGUN_43_17_01_0382",51.857811f,1.368750f,20.995312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0043",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,14, 0);
		
		myObj= CreateGameObject("HUMAN_CORPSE_43_17_01_0381",52.200001f,1.556250f,21.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0632",true);
		
		myObj= CreateGameObject("HIDDEN_DOOR_046_017",56.395313f,1.200000f,21.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1141",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,0,0,2438);
		
		myObj= CreateGameObject("SV_TRANQ_DARTS_47_17_01_0568",56.957813f,1.293750f,20.770313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0058",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,19, 0);
		
		myObj= CreateGameObject("ML_TEFLON_COATED_ROUNDS_47_17_01_0670",57.182812f,1.293750f,21.295313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0052",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,17, 0);
		
		myObj= CreateGameObject("STORAGE_ROOM_DOOR_015_018",19.195313f,1.800000f,22.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1045",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,10,0,2406);
		
		myObj= CreateGameObject("HUMAN_BONES_17_18_01_0038",20.657812f,1.462500f,22.082813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0712",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,211, 0);
		
		
		myObj= CreateGameObject("NULL_TRIGGER_18_18_01_0112",22.200001f,0.600000f,22.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 9,0,0,0,0,0);
		AddACTION_MOVING_PLATFORM(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_18_18_01_0113",22.200001f,0.600000f,22.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 9,0,0,0,0,0);
		AddACTION_MOVING_PLATFORM(myObj);
		
		myObj= CreateGameObject("SV_23_DARTGUN_19_18_01_0336",23.357813f,0.225000f,22.495312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0004",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,1, 0);
		
		myObj= CreateGameObject("STAMINUP__STIMULANT_19_18_01_0335",23.207813f,0.150000f,21.895313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0200",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,63, 0);
		
		myObj= CreateGameObject("SWITCH_19_18_01_0126",23.357813f,0.787500f,22.795313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0881",false);
		CreateSHOCKActivators(myObj,12);
		AddACTION_CHOICE(myObj);
		
		myObj= CreateGameObject("HUMAN_BONES_19_18_01_0061",23.400000f,0.262500f,22.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0712",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,211, 0);
		
		myObj= CreateGameObject("NULL_TRIGGER_20_18_01_0006",24.600000f,1.800000f,22.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_20_18_01_0036", 0,"DOOR_026_021", 0,"",0,"",0);
		
		myObj= CreateGameObject("NULL_TRIGGER_20_18_01_0036",24.600000f,1.800000f,22.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 4,0,0,0,0,0);
		AddACTION_SET_VARIABLE(myObj);
		
		myObj= CreateGameObject("ENERGY_CHARGE_STATION_22_18_01_0659",27.000000f,1.800000f,22.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0952",true);
		
		myObj= CreateGameObject("CRATE_23_18_01_0663",28.270313f,1.987500f,22.307812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1400",true);
		
		myObj= CreateGameObject("BRIDGE_24_18_01_0170",29.400000f,1.762500f,22.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("SV_23_DARTGUN_25_18_01_0035",30.220312f,0.825000f,22.420313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0004",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,1, 0);
		
		myObj= CreateGameObject("SHRUB_27_18_01_0202",33.220314f,1.781250f,22.232813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0492",true);
		
		myObj= CreateGameObject("FERN_28_18_01_0125",34.420311f,1.593750f,22.420313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0507",true);
		
		myObj= CreateGameObject("GRASS_29_18_01_0148",35.507813f,1.575000f,21.820313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0495",true);
		
		myObj= CreateGameObject("CRATE_37_18_01_0689",45.445313f,1.387500f,22.082813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1400",true);
		
		myObj= CreateGameObject("WORKER_HELMET_38_18_01_0097",46.420311f,1.387500f,22.645313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0582",true);
		
		myObj= CreateGameObject("CRATE_38_18_01_0688",45.970314f,1.387500f,22.457813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1400",true);
		
		myObj= CreateGameObject("NULL_TRIGGER_44_18_01_0338",53.400002f,1.800000f,22.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "",0,"",0,"",0,"",0);
		
		myObj= CreateGameObject("CRATE_12_19_01_0488",14.995313f,1.987500f,22.832813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1400",true);
		
		myObj= CreateGameObject("CRATE_12_19_01_0487",15.482813f,1.987500f,23.357813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1400",true);
		
		myObj= CreateGameObject("CRATE_12_19_01_0486",15.000000f,1.987500f,23.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1400",true);
		
		myObj= CreateGameObject("CRATE_14_19_01_0490",17.400000f,1.987500f,23.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1400",true);
		
		myObj= CreateGameObject("BONES_17_19_01_0103",21.370312f,1.368750f,23.170313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0715",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,212, 0);
		
		myObj= CreateGameObject("SEVERED_LIMB_17_19_01_0101",21.000000f,1.500000f,23.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0720",true);
		
		myObj= CreateGameObject("NULL_TRIGGER_19_19_01_0576",23.400000f,1.200000f,23.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,1,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_19_19_01_0575", 0,"NULL_TRIGGER_19_19_01_0574", 0,"",0,"",0);
		
		myObj= CreateGameObject("NULL_TRIGGER_19_19_01_0575",23.400000f,1.200000f,23.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 4,1,0,0,0,0);
		AddACTION_SET_VARIABLE(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_19_19_01_0574",23.400000f,1.200000f,23.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 7,1,0,0,0,0);
		AddACTION_LIGHTING(myObj);
		
		myObj= CreateGameObject("EMAIL_20_19_01_0485",24.257813f,0.693750f,23.357813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0281",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",13,105, 0);
		
		myObj= CreateGameObject("HUMAN_CORPSE_20_19_01_0484",24.895313f,0.956250f,23.432812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0632",true);
		
		myObj= CreateGameObject("ICON_20_19_01_0078",24.820313f,1.200000f,22.832813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0395",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",62,127, 0);
		
		myObj= CreateGameObject("KEYPAD_PANEL_20_19_01_0096",24.000000f,1.200000f,23.770313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0991",false);
		CreateSHOCKActivators(myObj,0);
		AddACTION_DO_NOTHING(myObj);
		
		myObj= CreateGameObject("SERV_BOT_23_19_01_0135",28.232813f,0.993750f,23.957813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1574",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,450, 0);
		
		myObj= CreateGameObject("BRIDGE_24_19_01_0143",29.400000f,1.762500f,23.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("SV_NEEDLE_DARTS_25_19_01_0191",30.595312f,0.693750f,23.582813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0055",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,18, 0);
		
		myObj= CreateGameObject("CONTROL_PEDESTAL_25_19_01_0131",30.000000f,0.637500f,23.545313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("SHRUBBERY_28_19_01_0121",34.420311f,1.781250f,23.282812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0529",true);
		
		myObj= CreateGameObject("GRASS_29_19_01_0074",35.245312f,1.575000f,23.245312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0495",true);
		
		myObj= CreateGameObject("CYBORG_DRONE_30_19_01_0352",36.599998f,1.650000f,23.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1604",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,460, 0);
		
		myObj= CreateGameObject("CAMERA_34_19_01_0419",41.920311f,2.587500f,22.907812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("STORAGE_ROOM_DOOR_035_019",43.195313f,1.200000f,23.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1045",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,10,0,2406);
		
		myObj= CreateGameObject("CRATE_38_19_01_0690",46.200001f,1.575000f,23.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1402",true);
		
		myObj= CreateGameObject("MEDIPATCH__HEALING_AGENT_38_19_01_0412",46.045311f,1.350000f,22.982813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,66, 0);
		
		myObj= CreateGameObject("CYBORG_ASSASSIN_42_19_01_0347",51.000000f,1.593750f,23.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1610",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,462, 0);
		
		myObj= CreateGameObject("WRAPPER_17_20_01_0136",20.620312f,1.312500f,24.820313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0570",true);
		
		
		
		myObj= CreateGameObject("DOOR_020_020",24.000000f,0.600000f,24.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1039",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,0,1,2404);
		
		myObj= CreateGameObject("STANDARD_ACCESS_CARD_1",31.682812f,0.731250f,24.970312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0761",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",5,224, 0);
		CreateKey(myObj, 0);
		
		myObj= CreateGameObject("LEAD_PIPE_26_20_01_0665",31.757813f,0.900000f,24.707813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0028",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,9, 0);
		
		myObj= CreateGameObject("NAVIGATION_AND_MAPPING_UNIT_26_20_01_0471",31.382813f,0.675000f,24.857813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0239",true);
		
		myObj= CreateGameObject("BRIEFCASE_26_20_01_0231",31.607813f,0.843750f,24.557812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0588",true);
		
		myObj= CreateGameObject("BERSERK_COMBAT_BOOSTER_26_20_01_0190",32.132813f,0.750000f,24.407812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0205",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,65, 0);
		
		myObj= CreateGameObject("STAMINUP__STIMULANT_26_20_01_0095",31.982813f,0.750000f,24.857813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0200",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,63, 0);
		
		myObj= CreateGameObject("SYSTEM_ANALYZER_26_20_01_0002",32.170311f,0.656250f,24.820313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0263",true);
		
		myObj= CreateGameObject("ICON_34_20_01_0212",41.995312f,2.287500f,24.632813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0395",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",62,127, 0);
		
		myObj= CreateGameObject("SKELETON_36_20_01_0199",43.870312f,1.556250f,24.332813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0702",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,210, 0);
		
		myObj= CreateGameObject("DEAD_MUTANT_37_20_01_0692",45.000000f,2.700000f,24.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1178",true);
		
		myObj= CreateGameObject("ML_STANDARD_ROUNDS_37_20_01_0691",45.000000f,2.493750f,24.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0049",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,16, 0);
		
		myObj= CreateGameObject("HUMANOID_MUTANT_38_20_01_0219",46.200001f,1.593750f,24.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1541",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,439, 0);
		
		myObj= CreateGameObject("BROKEN_CLOCK_38_20_01_0198",46.200001f,1.406250f,24.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0610",true);
		
		myObj= CreateGameObject("NULL_TRIGGER_41_20_01_0236",49.799999f,1.800000f,24.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 7,0,0,0,0,0);
		AddACTION_LIGHTING(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_46_20_01_0139",55.799999f,1.800000f,24.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 0,0,17,48,1,255);
		AddACTION_DO_NOTHING(myObj);
		
		myObj= CreateGameObject("BED_11_21_01_0169",14.020312f,1.481250f,25.907812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("NULL_TRIGGER_14_21_01_0452",17.400000f,1.800000f,25.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "",0,"",0,"",0,"",0);
		
		myObj= CreateGameObject("DOOR_015_021",19.195313f,1.200000f,25.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1039",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,1,0,2404);
		
		myObj= CreateGameObject("SERV_BOT_20_21_01_0004",24.557812f,0.956250f,25.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1574",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,450, 0);
		
		myObj= CreateGameObject("NULL_TRIGGER_20_21_01_0205",24.600000f,1.800000f,25.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_41_30_01_0208", 0,"NULL_TRIGGER_20_22_01_0141", 0,"NULL_TRIGGER_29_13_01_0211", 0,"",0);
		
		myObj= CreateGameObject("CAMERA_21_21_01_0414",26.057812f,1.818750f,25.532812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("SCREEN_24_21_01_0661",29.995312f,2.625000f,25.795313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",63,135, 0);
		
		myObj= CreateGameObject("DOOR_026_021",31.799999f,0.600000f,26.395313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1039",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,0,1,2404);
		
		myObj= CreateGameObject("SEVERED_LIMB_40_21_01_0107",48.295311f,1.350000f,26.020313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0720",true);
		
		myObj= CreateGameObject("HUMANOID_MUTANT_40_21_01_0293",48.599998f,1.443750f,25.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1541",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,439, 0);
		
		myObj= CreateGameObject("HUMAN_BONES_41_21_01_0084",49.457813f,1.312500f,25.720312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0712",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,211, 0);
		
		myObj= CreateGameObject("HUMANOID_MUTANT_44_21_01_0294",53.470314f,1.593750f,25.532812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1541",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,439, 0);
		
		myObj= CreateGameObject("SHODAN_TRIGGER_46_21_01_0483",55.799999f,1.800000f,25.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1376",true);
		
		myObj= CreateGameObject("HIDDEN_DOOR_046_021",56.395313f,1.200000f,25.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1141",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,255,1,2438);
		
		myObj= CreateGameObject("MAGNUM_2100_48_21_01_0656",58.045311f,1.387500f,25.832813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0007",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,2, 0);
		
		myObj= CreateGameObject("EMP_GRENADE_48_21_01_0085",58.420311f,1.350000f,25.795313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0180",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,56, 0);
		
		myObj= CreateGameObject("EMP_GRENADE_48_21_01_0386",58.270313f,1.350000f,25.607813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0180",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,56, 0);
		
		myObj= CreateGameObject("EMP_GRENADE_48_21_01_0385",58.345314f,1.350000f,26.020313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0180",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,56, 0);
		
		myObj= CreateGameObject("GROUP_ACCESS_CARD_1",13.800000f,1.331250f,27.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0788",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",5,233, 0);
		CreateKey(myObj, 0);
		
		myObj= CreateGameObject("EMAIL_11_22_01_0315",13.532812f,1.293750f,27.295313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0281",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",13,105, 0);
		
		myObj= CreateGameObject("SEVERED_HEAD_15_22_01_0458",18.557812f,3.225000f,26.770313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0724",true);
		
		myObj= CreateGameObject("HUMANOID_MUTANT_17_22_01_0195",20.906250f,1.593750f,26.868750f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1541",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,439, 0);
		
		myObj= CreateGameObject("SKULL_18_22_01_0102",21.932812f,1.312500f,26.882813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0718",true);
		
		myObj= CreateGameObject("SCREEN_20_22_01_0187",24.032812f,1.293750f,26.995312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",63,132, 0);
		
		myObj= CreateGameObject("NULL_TRIGGER_20_22_01_0141",24.600000f,1.800000f,27.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 7,0,0,0,0,0);
		AddACTION_LIGHTING(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_21_22_01_0062",25.799999f,1.800000f,27.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 11,0,0,0,0,0);
		AddACTION_TIMER(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_25_22_01_0696",30.600000f,1.200000f,27.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "DOOR_026_024", 0,"DOOR_026_021", 0,"",0,"",0);
		
		myObj= CreateGameObject("BUTTON_26_22_01_0176",31.232813f,1.331250f,26.882813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0889",false);
		CreateSHOCKActivators(myObj,6);
		AddACTION_ACTIVATE(myObj, "DOOR_026_021", 0,"",0,"",0,"",0);
		
		myObj= CreateGameObject("EMAIL_33_22_01_0454",39.895313f,1.293750f,26.995312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0281",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",13,105, 0);
		
		myObj= CreateGameObject("HUMAN_CORPSE_33_22_01_0453",40.200001f,1.575000f,27.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0632",true);
		
		myObj= CreateGameObject("CHEMICAL_TANK_37_22_01_0684",45.032814f,1.593750f,26.957813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1413",true);
		
		myObj= CreateGameObject("CHEMICAL_TANK_38_22_01_0687",46.200001f,1.593750f,27.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1413",true);
		
		myObj= CreateGameObject("CYBORG_DRONE_38_22_01_0303",45.632813f,1.650000f,27.595312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1604",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,460, 0);
		
		myObj= CreateGameObject("SKULL_43_22_01_0389",52.200001f,1.162500f,27.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0718",true);
		
		myObj= CreateGameObject("BED_11_23_01_0168",14.020312f,1.481250f,28.232813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("SERV_BOT_12_23_01_0278",15.000000f,1.593750f,28.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1574",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,450, 0);
		
		myObj= CreateGameObject("CART_13_23_01_0612",16.345312f,1.200000f,28.120312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("BULKHEAD_DOOR_017_023",21.000000f,1.200000f,27.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1120",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,0,0,2431);
		
		myObj= CreateGameObject("BULKHEAD_DOOR_018_023",22.200001f,1.200000f,27.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1123",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,0,0,2432);
		
		myObj= CreateGameObject("WORDS_29_23_01_0699",35.765625f,2.250000f,28.795313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("WORDS_30_23_01_0718",36.346874f,2.250000f,28.795313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("LEVEL_ENTRY_TRIGGER_31_23_01_0695",37.799999f,1.800000f,28.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1364",false);
		CreateNull_Trigger(myObj, 2,1,0,0,0,0);
		AddACTION_RESURRECTION(myObj);
		
		myObj= CreateGameObject("LARGE_BUTTON_35_23_01_0117",42.370312f,1.800000f,28.795313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0905",false);
		CreateSHOCKActivators(myObj,6);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_33_25_01_0354", 0,"",0,"",0,"",0);
		
		myObj= CreateGameObject("BLAST_DOOR_035_023",43.195313f,1.200000f,28.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1027",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,0,0,2400);
		
		myObj= CreateGameObject("CHEMICAL_TANK_38_23_01_0685",46.200001f,1.593750f,28.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1413",true);
		
		myObj= CreateGameObject("HUMAN_CORPSE_40_23_01_0017",48.599998f,1.425000f,28.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0662",true);
		
		myObj= CreateGameObject("SKULL_41_23_01_0257",49.645313f,1.162500f,28.382813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0718",true);
		
		myObj= CreateGameObject("HUMANOID_MUTANT_45_23_01_0295",54.599998f,2.043750f,28.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1541",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,439, 0);
		
		myObj= CreateGameObject("NULL_TRIGGER_10_24_01_0353",12.600000f,2.400000f,29.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "",0,"",0,"",0,"",0);
		
		myObj= CreateGameObject("GRAFFITI_17_24_01_0044",20.845312f,2.718750f,28.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0399",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",62,128, 0);
		
		myObj= CreateGameObject("BONES_17_24_01_0043",20.695313f,1.406250f,29.470312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0715",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,212, 0);
		
		myObj= CreateGameObject("DOOR_026_024",31.799999f,0.600000f,28.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1039",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,1,0,2404);
		
		
		myObj= CreateGameObject("MEDIPATCH__HEALING_AGENT_28_24_01_0133",33.820313f,1.800000f,29.395313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,66, 0);
		
		myObj= CreateGameObject("NULL_TRIGGER_29_24_01_0209",35.400002f,2.250000f,29.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_17_33_01_0601", 0,"NULL_TRIGGER_12_45_01_0602", 0,"",0,"",0);
		
		myObj= CreateGameObject("NULL_TRIGGER_29_24_01_0599",35.400002f,2.250000f,29.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_29_13_01_0211", 0,"NULL_TRIGGER_17_12_01_0337", 0,"NULL_TRIGGER_41_20_01_0236", 0,"NULL_TRIGGER_29_24_01_0209", 0);
		
		myObj= CreateGameObject("NULL_TRIGGER_29_24_01_0064",35.400002f,2.250000f,29.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_27_25_01_0151", 0,"NULL_TRIGGER_26_27_01_0252", 0,"NULL_TRIGGER_41_30_01_0208", 0,"NULL_TRIGGER_29_24_01_0599", 0);
		
		myObj= CreateGameObject("NULL_TRIGGER_29_24_01_0066",35.400002f,2.250000f,29.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 11,0,0,0,0,0);
		AddACTION_TIMER(myObj);
		
		myObj= CreateGameObject("LEVEL_ENTRY_TRIGGER_30_24_01_0037",36.599998f,2.250000f,29.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1364",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_29_24_01_0066", 0,"",0,"",0,"",0);
		
		myObj= CreateGameObject("CHEMICAL_TANK_37_24_01_0686",45.000000f,1.593750f,29.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1413",true);
		
		myObj= CreateGameObject("EMAIL_38_24_01_0460",46.157814f,1.293750f,29.995312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0281",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",13,105, 0);
		
		myObj= CreateGameObject("SCREEN_40_24_01_0128",48.000000f,1.631250f,29.395313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",63,135, 0);
		
		myObj= CreateGameObject("HUMANOID_MUTANT_07_25_01_0132",9.000000f,0.393750f,30.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1541",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,439, 0);
		
		myObj= CreateGameObject("CHAIR_11_25_01_0620",13.800000f,1.800000f,30.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("BLOOD_STAIN_12_25_01_0472",14.770312f,1.800000f,30.632813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0846",true);
		
		myObj= CreateGameObject("SEVERED_HEAD_12_25_01_0470",15.000000f,2.025000f,30.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0724",true);
		
		myObj= CreateGameObject("BERSERK_COMBAT_BOOSTER_13_25_01_0173",16.345312f,2.400000f,30.857813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0205",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,65, 0);
		
		myObj= CreateGameObject("SCOPE_13_25_01_0621",15.820313f,2.250000f,30.895313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("SCREEN_13_25_01_0617",15.970312f,2.625000f,30.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",63,132, 0);
		
		myObj= CreateGameObject("STAMINUP__STIMULANT_13_25_01_0172",16.200001f,2.400000f,30.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0200",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,63, 0);
		
		myObj= CreateGameObject("SCREEN_14_25_01_0618",17.432812f,2.625000f,30.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",63,132, 0);
		
		myObj= CreateGameObject("TESTTUBE_RACK_14_25_01_0615",17.507813f,2.250000f,30.707813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("HUMAN_CORPSE_20_25_01_0271",24.600000f,0.956250f,30.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0632",true);
		
		myObj= CreateGameObject("ICON_21_25_01_0431",25.200001f,2.325000f,30.782812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0395",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",62,127, 0);
		
		myObj= CreateGameObject("NULL_TRIGGER_27_25_01_0151",33.000000f,1.200000f,30.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 7,0,0,0,0,0);
		AddACTION_LIGHTING(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_32_25_01_0054",39.000000f,1.800000f,30.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 9,0,0,0,0,0);
		AddACTION_MOVING_PLATFORM(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_32_25_01_0109",39.000000f,1.800000f,30.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 9,0,0,0,0,0);
		AddACTION_MOVING_PLATFORM(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_33_25_01_0354",40.200001f,1.800000f,30.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 12,0,0,0,0,0);
		AddACTION_CHOICE(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_33_25_01_0034",40.200001f,1.800000f,30.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 9,0,0,0,0,0);
		AddACTION_MOVING_PLATFORM(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_33_25_01_0012",40.200001f,1.800000f,30.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_32_25_01_0054", 0,"NULL_TRIGGER_33_25_01_0031", 0,"NULL_TRIGGER_34_25_01_0033", 0,"",0);
		
		myObj= CreateGameObject("NULL_TRIGGER_33_25_01_0032",40.200001f,1.800000f,30.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_32_25_01_0109", 0,"NULL_TRIGGER_33_25_01_0034", 0,"NULL_TRIGGER_34_25_01_0053", 0,"",0);
		
		myObj= CreateGameObject("NULL_TRIGGER_33_25_01_0031",40.200001f,1.800000f,30.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 9,0,0,0,0,0);
		AddACTION_MOVING_PLATFORM(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_34_25_01_0033",41.400002f,1.800000f,30.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 9,0,0,0,0,0);
		AddACTION_MOVING_PLATFORM(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_34_25_01_0053",41.400002f,1.800000f,30.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 9,0,0,0,0,0);
		AddACTION_MOVING_PLATFORM(myObj);
		
		myObj= CreateGameObject("HUMAN_CORPSE_36_25_01_0459",43.799999f,1.575000f,30.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0672",true);
		
		myObj= CreateGameObject("STAMINUP__STIMULANT_38_25_01_0305",46.307812f,1.350000f,30.632813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0200",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,63, 0);
		
		myObj= CreateGameObject("MEDIPATCH__HEALING_AGENT_38_25_01_0304",45.857811f,1.350000f,30.145313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,66, 0);
		
		myObj= CreateGameObject("SEVERED_LIMB_38_25_01_0457",45.970314f,1.500000f,30.595312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0720",true);
		
		myObj= CreateGameObject("HUMAN_CORPSE_38_25_01_0455",46.200001f,1.556250f,30.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0642",true);
		
		myObj= CreateGameObject("SPARQ_BEAM_40_25_01_0204",48.407814f,1.143750f,30.632813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0034",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,11, 0);
		
		myObj= CreateGameObject("SKULL_41_25_01_0258",49.532814f,1.162500f,30.745312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0718",true);
		
		myObj= CreateGameObject("WORDS_46_25_01_0239",55.200001f,3.018750f,30.670313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		
		myObj= CreateGameObject("NULL_TRIGGER_47_25_01_0607",57.000000f,1.800000f,30.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 11,0,0,0,0,0);
		AddACTION_TIMER(myObj);
		
		myObj= CreateGameObject("MEDIPATCH__HEALING_AGENT_08_26_01_0225",9.857813f,0.150000f,32.057812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,66, 0);
		
		myObj= CreateGameObject("HUMAN_CORPSE_08_26_01_0224",10.200000f,0.356250f,31.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0642",true);
		
		myObj= CreateGameObject("HUMANOID_MUTANT_09_26_01_0188",11.400000f,0.393750f,31.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1541",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,439, 0);
		
		myObj= CreateGameObject("SCOPE_11_26_01_0622",13.382813f,2.250000f,32.057812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("SENSAROUND_MULTI_VIEW_UNIT_11_26_01_0179",13.800000f,2.343750f,31.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0227",true);
		
		myObj= CreateGameObject("HUMANOID_MUTANT_12_26_01_0040",15.000000f,2.193750f,31.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1541",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,439, 0);
		
		myObj= CreateGameObject("DOOR_015_026",19.195313f,1.200000f,31.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1039",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,1,0,2404);
		
		myObj= CreateGameObject("SERV_BOT_21_26_01_0098",25.200001f,0.956250f,31.532812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1574",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,450, 0);
		
		myObj= CreateGameObject("SURGERY_MACHINE_26_26_01_0613",31.799999f,0.600000f,31.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("ENERGY_CHARGE_STATION_28_26_01_0411",34.200001f,1.293750f,31.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0952",true);
		
		myObj= CreateGameObject("WORDS_31_26_01_0581",37.570313f,2.100000f,31.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("HUMAN_BONES_32_26_01_0015",39.145313f,1.462500f,31.495312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0712",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,211, 0);
		
		myObj= CreateGameObject("SKULL_32_26_01_0164",38.920311f,1.312500f,31.607813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0718",true);
		
		myObj= CreateGameObject("LARGE_BUTTON_34_26_01_0536",41.995312f,2.006250f,31.795313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0905",false);
		CreateSHOCKActivators(myObj,6);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_33_25_01_0354", 0,"",0,"",0,"",0);
		
		myObj= CreateGameObject("SKELETON_39_26_01_0388",47.400002f,1.556250f,31.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0702",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,210, 0);
		
		myObj= CreateGameObject("CRATE_42_26_01_0534",51.182812f,1.537500f,31.982813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1400",true);
		
		myObj= CreateGameObject("BLAST_DOOR_046_026",55.799999f,2.100000f,31.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1027",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,0,0,2400);
		
		myObj= CreateGameObject("SWITCH_55_26_01_0605",66.599998f,1.275000f,31.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0881",false);
		CreateSHOCKActivators(myObj,0);
		AddACTION_DO_NOTHING(myObj);
		
		myObj= CreateGameObject("HUMAN_CORPSE_11_27_01_0473",13.800000f,2.175000f,33.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0642",true);
		
		myObj= CreateGameObject("EMAIL_12_27_01_0474",14.400000f,1.893750f,32.732811f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0281",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",13,105, 0);
		
		myObj= CreateGameObject("CAMERA_20_27_01_0413",24.000000f,2.193750f,33.595314f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("WORDS_23_27_01_0698",28.420313f,2.118750f,33.595314f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("WORDS_23_27_01_0697",28.345312f,1.781250f,33.595314f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("NULL_TRIGGER_26_27_01_0252",31.799999f,1.200000f,33.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 7,0,0,0,0,0);
		AddACTION_LIGHTING(myObj);
		
		myObj= CreateGameObject("CRITTER_AI_HINT_28_27_01_0311",34.200001f,1.593750f,33.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1361",true);
		
		myObj= CreateGameObject("WRAPPER_33_27_01_0100",40.200001f,1.312500f,33.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0570",true);
		
		myObj= CreateGameObject("SCREEN_35_27_01_0177",42.670311f,1.912500f,32.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",63,132, 0);
		
		myObj= CreateGameObject("SCREEN_35_27_01_0178",42.670311f,2.887500f,32.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",63,132, 0);
		
		myObj= CreateGameObject("CRITTER_AI_HINT_36_27_01_0310",43.799999f,1.593750f,33.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1361",true);
		
		myObj= CreateGameObject("CYBORG_DRONE_37_27_01_0251",45.000000f,1.650000f,33.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1604",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,460, 0);
		
		myObj= CreateGameObject("REPULSOR_43_27_01_0366",52.200001f,1.050000f,33.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1370",false);
		
		myObj= CreateGameObject("SIGHT_VISION_ENHANCEMENT_49_27_01_0394",59.695313f,3.750000f,33.070313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0203",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,64, 0);
		
		myObj= CreateGameObject("FIRST_AID_KIT_50_27_01_0395",60.295311f,3.768750f,33.032814f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0750",true);
		
		myObj= CreateGameObject("HIDDEN_DOOR_015_028",19.195313f,1.800000f,34.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1141",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,0,0,2438);
		
		myObj= CreateGameObject("FRAGMENTATION_GRENADE_15_28_01_0674",18.600000f,1.950000f,34.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0177",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,55, 0);
		
		myObj= CreateGameObject("FRAGMENTATION_GRENADE_15_28_01_0673",18.370312f,1.950000f,33.857811f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0177",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,55, 0);
		
		myObj= CreateGameObject("SWITCH_20_28_01_0093",24.600000f,1.275000f,34.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0881",false);
		CreateSHOCKActivators(myObj,0);
		AddACTION_DO_NOTHING(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_24_28_01_0129",29.400000f,1.800000f,34.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,1,0,0,0);
		AddACTION_ACTIVATE(myObj, "",0,"",0,"",0,"",0);
		
		myObj= CreateGameObject("NULL_TRIGGER_26_28_01_0152",31.799999f,1.800000f,34.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,1,0,0,0);
		AddACTION_ACTIVATE(myObj, "",0,"",0,"",0,"",0);
		
		myObj= CreateGameObject("WORDS_27_28_01_0059",32.400002f,2.043750f,34.157814f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("EXPLOSION_RESIDUE_27_28_01_0008",32.400002f,2.531250f,34.270313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0840",true);
		
		myObj= CreateGameObject("NULL_TRIGGER_30_28_01_0200",36.599998f,0.600000f,34.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 9,0,0,0,0,0);
		AddACTION_MOVING_PLATFORM(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_30_28_01_0027",36.599998f,0.600000f,34.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 9,0,0,0,0,0);
		AddACTION_MOVING_PLATFORM(myObj);
		
		
		myObj= CreateGameObject("HIDDEN_DOOR_037_028",45.595314f,1.200000f,34.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1141",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,0,0,2438);
		
		myObj= CreateGameObject("HUMANOID_MUTANT_45_28_01_0297",54.599998f,2.493750f,34.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1541",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,439, 0);
		
		myObj= CreateGameObject("NULL_TRIGGER_46_28_01_0114",55.799999f,2.700000f,34.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_46_28_01_0298", 0,"NULL_TRIGGER_46_28_01_0299", 0,"",0,"",0);
		
		myObj= CreateGameObject("NULL_TRIGGER_46_28_01_0299",55.799999f,2.700000f,34.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 24,0,0,0,0,0);
		AddACTION_CHANGE_TYPE(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_46_28_01_0298",55.799999f,2.700000f,34.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 24,0,0,0,0,0);
		AddACTION_CHANGE_TYPE(myObj);
		
		myObj= CreateGameObject("ACCESS_PANEL_47_28_01_0259",56.732811f,2.812500f,34.270313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0974",false);
		CreateSHOCKActivators(myObj,0);
		AddACTION_DO_NOTHING(myObj);
		
		myObj= CreateGameObject("BEVERAGE_CONTAINER_49_28_01_0393",59.545311f,3.693750f,33.895313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0568",true);
		
		myObj= CreateGameObject("BEVERAGE_CONTAINER_49_28_01_0392",59.132813f,3.693750f,34.345314f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0568",true);
		
		myObj= CreateGameObject("STORAGE_ROOM_DOOR_050_028",61.195313f,3.600000f,34.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1045",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,0,0,2406);
		
		myObj= CreateGameObject("STORAGE_ROOM_DOOR_011_029",13.200000f,1.200000f,35.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1045",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,0,1,2406);
		
		myObj= CreateGameObject("EMAIL_12_29_01_0399",15.257813f,1.293750f,35.095314f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0281",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",13,105, 0);
		
		myObj= CreateGameObject("SEVERED_LIMB_13_29_01_0491",16.345312f,1.500000f,35.620312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0720",true);
		
		myObj= CreateGameObject("SCREEN_28_29_01_0185",34.195313f,3.337500f,35.995312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",63,132, 0);
		
		myObj= CreateGameObject("LEVER_30_29_01_0432",36.032814f,0.600000f,35.470314f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0897",false);
		CreateSHOCKActivators(myObj,6);
		AddACTION_ACTIVATE(myObj, "ENTRY_TRIGGER_30_28_01_0158", 0,"",0,"",0,"",0);
		
		myObj= CreateGameObject("CONTROL_PEDESTAL_31_29_01_0442",37.799999f,0.000000f,35.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("BERSERK_COMBAT_BOOSTER_32_29_01_0444",39.370312f,0.150000f,35.920311f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0205",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,65, 0);
		
		myObj= CreateGameObject("BERSERK_COMBAT_BOOSTER_32_29_01_0443",39.107811f,0.150000f,35.920311f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0205",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,65, 0);
		
		myObj= CreateGameObject("CONTROL_PEDESTAL_32_29_01_0441",39.070313f,0.037500f,35.357811f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("SV_TRANQ_DARTS_33_29_01_0566",40.082813f,0.393750f,35.620312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0058",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,19, 0);
		
		myObj= CreateGameObject("NULL_TRIGGER_34_29_01_0683",41.400002f,0.600000f,35.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 0,0,0,0,0,0);
		AddACTION_DO_NOTHING(myObj);
		
		myObj= CreateGameObject("NITROPACK_39_29_01_0667",47.095314f,1.350000f,35.657814f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0192",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,60, 0);
		
		myObj= CreateGameObject("ELEPHANT_JORP_46_29_01_0290",55.799999f,2.062500f,35.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0563",true);
		
		myObj= CreateGameObject("CRATE_49_29_01_0646",59.545311f,0.337500f,35.432812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1400",true);
		
		myObj= CreateGameObject("EMAIL_51_29_01_0465",61.799999f,3.693750f,35.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0281",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",13,105, 0);
		
		myObj= CreateGameObject("HUMAN_CORPSE_52_29_01_0511",63.000000f,3.975000f,35.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0672",true);
		
		myObj= CreateGameObject("SB_20_MAGPULSE_10_30_01_0171",12.407812f,1.500000f,37.082813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0022",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,7, 0);
		
		myObj= CreateGameObject("MEDIPATCH__HEALING_AGENT_10_30_01_0223",12.600000f,1.350000f,36.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,66, 0);
		
		myObj= CreateGameObject("LEVEL_ENTRY_TRIGGER_11_30_01_0653",13.800000f,1.800000f,36.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1364",false);
		CreateNull_Trigger(myObj, 6,0,30,0,1,0);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_11_31_01_0654", 0,"NULL_TRIGGER_11_31_01_0655", 0,"",0,"",0);
		
		myObj= CreateGameObject("HUMAN_CORPSE_12_30_01_0014",14.957812f,1.575000f,36.632813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0672",true);
		
		myObj= CreateGameObject("DOOR_015_030",18.000000f,1.200000f,36.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1039",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,0,0,2404);
		
		myObj= CreateGameObject("HUMANOID_MUTANT_16_30_01_0082",19.799999f,1.593750f,36.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1541",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,439, 0);
		
		myObj= CreateGameObject("HUMANOID_MUTANT_19_30_01_0194",23.981251f,1.593750f,36.421875f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1541",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,439, 0);
		
		myObj= CreateGameObject("SCREEN_23_30_01_0245",28.195313f,2.437500f,36.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",63,135, 0);
		
		myObj= CreateGameObject("BUTTON_27_30_01_0700",32.995312f,2.250000f,37.195313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0885",false);
		CreateSHOCKActivators(myObj,7);
		AddACTION_LIGHTING(myObj);
		
		myObj= CreateGameObject("SCREEN_31_30_01_0448",37.795311f,2.437500f,36.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",63,135, 0);
		
		myObj= CreateGameObject("NULL_TRIGGER_31_30_01_0708",37.799999f,0.600000f,36.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 22,0,0,0,0,0);
		AddACTION_MESSAGE(myObj);
		
		myObj= CreateGameObject("REPULSOR_31_30_01_0668",37.799999f,0.600000f,36.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1370",false);
		
		myObj= CreateGameObject("SCREEN_31_30_01_0449",37.200001f,2.437500f,36.595314f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",63,135, 0);
		
		myObj= CreateGameObject("CAMERA_31_30_01_0348",37.420311f,1.631250f,36.182812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("BUTTON_32_30_01_0529",38.545311f,3.187500f,36.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0889",false);
		CreateSHOCKActivators(myObj,19);
		AddACTION_CHANGE_STATE(myObj);
		
		myObj= CreateGameObject("ACCESS_PANEL_32_30_01_0682",38.545311f,2.887500f,36.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0964",false);
		CreateSHOCKActivators(myObj,0);
		AddACTION_DO_NOTHING(myObj);
		
		myObj= CreateGameObject("CAMERA_32_30_01_0351",39.482811f,1.631250f,36.145313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("MEDIPATCH__HEALING_AGENT_33_30_01_0499",39.932812f,0.150000f,36.932812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,66, 0);
		
		myObj= CreateGameObject("CYBORG_DRONE_33_30_01_0346",40.200001f,0.450000f,36.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1604",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,460, 0);
		
		myObj= CreateGameObject("CRITTER_AI_HINT_36_30_01_0309",43.799999f,1.593750f,36.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1361",true);
		
		myObj= CreateGameObject("SCREEN_38_30_01_0433",46.795311f,2.381250f,36.557812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",63,132, 0);
		
		myObj= CreateGameObject("CAMERA_38_30_01_0418",46.495312f,2.625000f,36.257813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("LARGE_BUTTON_38_30_01_0110",46.795311f,1.781250f,36.857811f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0905",false);
		CreateSHOCKActivators(myObj,6);
		AddACTION_ACTIVATE(myObj, "ENTRY_TRIGGER_39_31_01_0714", 0,"",0,"",0,"",0);
		
		myObj= CreateGameObject("NULL_TRIGGER_39_30_01_0207",47.400002f,2.400000f,36.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,1,0,0,0);
		AddACTION_ACTIVATE(myObj, "",0,"",0,"",0,"",0);
		
		myObj= CreateGameObject("NULL_TRIGGER_41_30_01_0208",49.799999f,1.800000f,36.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 7,0,0,0,0,0);
		AddACTION_LIGHTING(myObj);
		
		myObj= CreateGameObject("ELEPHANT_JORP_46_30_01_0292",55.799999f,2.062500f,36.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0563",true);
		
		myObj= CreateGameObject("BATTERY_PACK_50_30_01_0405",60.599998f,1.762500f,36.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0756",true);
		
		myObj= CreateGameObject("STAMINUP__STIMULANT_10_31_01_0222",12.600000f,1.350000f,37.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0200",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,63, 0);
		
		myObj= CreateGameObject("NULL_TRIGGER_11_31_01_0655",13.800000f,1.800000f,37.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "STORAGE_ROOM_DOOR_011_032", 0,"",0,"",0,"",0);
		
		myObj= CreateGameObject("NULL_TRIGGER_11_31_01_0654",13.800000f,1.800000f,37.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "STORAGE_ROOM_DOOR_011_029", 0,"",0,"",0,"",0);
		
		myObj= CreateGameObject("HUMANOID_MUTANT_12_31_01_0142",15.000000f,1.593750f,37.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1541",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,439, 0);
		
		myObj= CreateGameObject("BUTTON_17_31_01_0701",20.995312f,2.006250f,38.395313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0885",false);
		CreateSHOCKActivators(myObj,7);
		AddACTION_LIGHTING(myObj);
		
		myObj= CreateGameObject("SCREEN_17_31_01_0079",20.995312f,3.112500f,37.795311f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",63,132, 0);
		
		myObj= CreateGameObject("LUMP_OF_CLOTHES_17_31_01_0104",21.000000f,1.443750f,37.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0585",true);
		
		myObj= CreateGameObject("NULL_TRIGGER_19_31_01_0600",23.400000f,1.800000f,37.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "",0,"",0,"",0,"",0);
		
		myObj= CreateGameObject("HUMANOID_MUTANT_23_31_01_0244",28.082813f,0.393750f,37.982811f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1541",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,439, 0);
		
		
		myObj= CreateGameObject("SCREEN_28_31_01_0186",34.195313f,3.318750f,37.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",63,132, 0);
		
		myObj= CreateGameObject("CONTROL_PEDESTAL_30_31_01_0440",36.599998f,0.000000f,37.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("CYBORG_DRONE_30_31_01_0345",37.157814f,0.450000f,37.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1604",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,460, 0);
		
		myObj= CreateGameObject("CAMERA_31_31_01_0349",37.345314f,1.631250f,38.245312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("SCREEN_32_31_01_0446",38.995312f,2.437500f,38.395313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",63,135, 0);
		
		myObj= CreateGameObject("SCREEN_32_31_01_0447",39.595314f,2.437500f,37.795311f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",63,135, 0);
		
		myObj= CreateGameObject("CAMERA_32_31_01_0350",39.520313f,1.631250f,38.282814f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("BUTTON_33_31_01_0662",40.795311f,0.150000f,37.832813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0889",false);
		CreateSHOCKActivators(myObj,19);
		AddACTION_CHANGE_STATE(myObj);
		
		myObj= CreateGameObject("CONTROL_PEDESTAL_33_31_01_0582",40.200001f,0.000000f,37.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("HOPPER_34_31_01_0307",41.957813f,2.193750f,37.757813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1583",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,453, 0);
		
		
		myObj= CreateGameObject("NULL_TRIGGER_39_31_01_0215",47.400002f,1.800000f,37.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 9,0,0,0,0,0);
		AddACTION_MOVING_PLATFORM(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_39_31_01_0214",47.400002f,1.800000f,37.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 9,0,0,0,0,0);
		AddACTION_MOVING_PLATFORM(myObj);
		
		myObj= CreateGameObject("DOOR_041_031",49.200001f,3.600000f,37.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1039",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,0,1,2404);
		
		myObj= CreateGameObject("HUMANOID_MUTANT_45_31_01_0296",54.599998f,2.793750f,37.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1541",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,439, 0);
		
		myObj= CreateGameObject("CRATE_47_31_01_0694",57.107811f,2.587500f,38.132813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1400",true);
		
		myObj= CreateGameObject("HUMAN_CORPSE_53_31_01_0510",64.199997f,3.956250f,37.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0672",true);
		
		myObj= CreateGameObject("STORAGE_ROOM_DOOR_011_032",13.200000f,1.200000f,39.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1045",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,0,1,2406);
		
		myObj= CreateGameObject("SCREEN_18_32_01_0067",22.007813f,2.925000f,38.995312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",63,132, 0);
		
		myObj= CreateGameObject("SIGHT_VISION_ENHANCEMENT_22_32_01_0325",27.595312f,0.150000f,39.257813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0203",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,64, 0);
		
		myObj= CreateGameObject("SIGHT_VISION_ENHANCEMENT_22_32_01_0324",27.445313f,0.150000f,39.107811f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0203",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,64, 0);
		
		myObj= CreateGameObject("SV_23_DARTGUN_23_32_01_0242",28.200001f,0.225000f,39.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0004",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,1, 0);
		
		myObj= CreateGameObject("FRAGMENTATION_GRENADE_23_32_01_0120",27.970312f,0.112500f,39.407814f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0177",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,55, 0);
		
		myObj= CreateGameObject("CYBORG_DRONE_29_32_01_0580",35.400002f,2.250000f,39.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1604",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,460, 0);
		
		myObj= CreateGameObject("CONTROL_PEDESTAL_32_32_01_0439",39.000000f,0.000000f,39.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("WORDS_38_32_01_0496",46.795311f,1.800000f,38.995312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("SCREEN_38_32_01_0434",46.795311f,2.381250f,39.032814f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",63,132, 0);
		
		myObj= CreateGameObject("CAMERA_38_32_01_0417",46.532814f,2.625000f,39.332813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("BROKEN_LEVER_40_32_01_0494",49.195313f,4.331250f,38.507813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0618",true);
		
		myObj= CreateGameObject("LARGE_BUTTON_40_32_01_0159",48.000000f,4.200000f,38.732811f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0905",false);
		CreateSHOCKActivators(myObj,6);
		AddACTION_ACTIVATE(myObj, "ENTRY_TRIGGER_39_31_01_0714", 0,"",0,"",0,"",0);
		
		myObj= CreateGameObject("BRIDGE_44_32_01_0364",53.400002f,2.343750f,39.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("HIDDEN_DOOR_015_033",19.195313f,1.200000f,40.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1141",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,0,0,2438);
		
		myObj= CreateGameObject("MEDIPATCH__HEALING_AGENT_15_33_01_0676",18.557812f,1.350000f,39.857811f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,66, 0);
		
		myObj= CreateGameObject("MEDIPATCH__HEALING_AGENT_15_33_01_0675",18.820313f,1.350000f,40.532814f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,66, 0);
		
		myObj= CreateGameObject("NULL_TRIGGER_17_33_01_0601",21.000000f,1.800000f,40.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 7,0,0,0,0,0);
		AddACTION_LIGHTING(myObj);
		
		myObj= CreateGameObject("DOOR_019_033",23.995312f,1.200000f,40.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1039",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,0,0,2404);
		
		myObj= CreateGameObject("WRAPPER_19_33_01_0105",23.695313f,1.312500f,40.045311f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0570",true);
		
		myObj= CreateGameObject("NULL_TRIGGER_37_33_01_0206",45.000000f,1.800000f,40.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,1,0,0,0);
		AddACTION_ACTIVATE(myObj, "",0,"",0,"",0,"",0);
		
		myObj= CreateGameObject("SV_NEEDLE_DARTS_47_33_01_0377",56.582813f,2.493750f,40.532814f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0055",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,18, 0);
		
		myObj= CreateGameObject("CYBORG_DRONE_20_34_01_0313",24.600000f,2.850000f,41.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1604",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,460, 0);
		
		myObj= CreateGameObject("CRITTER_AI_HINT_28_34_01_0312",34.200001f,1.593750f,41.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1361",true);
		
		myObj= CreateGameObject("WRAPPER_28_34_01_0042",34.270313f,1.312500f,41.020313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0570",true);
		
		myObj= CreateGameObject("DEBRIS_30_34_01_0071",36.599998f,1.331250f,41.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0601",true);
		
		myObj= CreateGameObject("CRITTER_AI_HINT_35_34_01_0308",42.599998f,1.593750f,41.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1361",true);
		
		myObj= CreateGameObject("ENERGY_CHARGE_STATION_38_34_01_0679",46.200001f,3.600000f,41.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0952",true);
		
		myObj= CreateGameObject("HIDDEN_DOOR_038_034",46.795311f,3.600000f,41.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1141",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,0,0,2438);
		
		myObj= CreateGameObject("CONTROL_PEDESTAL_11_35_01_0509",13.800000f,0.000000f,42.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("BULKHEAD_DOOR_016_035",19.799999f,1.200000f,42.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1123",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,0,1,2432);
		
		myObj= CreateGameObject("NULL_TRIGGER_17_35_01_0024",21.000000f,1.800000f,42.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 4,1,0,0,0,0);
		AddACTION_SET_VARIABLE(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_17_35_01_0023",21.000000f,1.800000f,42.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "BULKHEAD_DOOR_017_035", 0,"",0,"",0,"",0);
		
		myObj= CreateGameObject("LEVER_17_35_01_0130",21.595312f,1.800000f,42.595314f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0897",false);
		CreateSHOCKActivators(myObj,6);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_17_35_01_0024", 0,"NULL_TRIGGER_17_35_01_0023", 0,"",0,"",0);
		
		myObj= CreateGameObject("BULKHEAD_DOOR_017_035",21.000000f,1.200000f,42.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1120",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,0,1,2431);
		
		myObj= CreateGameObject("DH_07_STUNGUN_26_35_01_0331",32.170311f,2.568750f,42.557812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0043",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,14, 0);
		
		myObj= CreateGameObject("FRAGMENTATION_GRENADE_26_35_01_0106",31.607813f,2.550000f,42.670311f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0177",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,55, 0);
		
		myObj= CreateGameObject("HIDDEN_DOOR_030_035",36.599998f,0.000000f,42.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1141",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,0,0,2438);
		
		myObj= CreateGameObject("BRIDGE_31_35_01_0020",37.799999f,1.162500f,42.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("BURN_RESIDUE_35_35_01_0476",42.632813f,2.437500f,43.195313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0843",true);
		
		myObj= CreateGameObject("ICON_35_35_01_0435",42.000000f,3.056250f,43.195313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0395",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",62,127, 0);
		
		myObj= CreateGameObject("FIRE_EXTINGUISHER_37_35_01_0026",45.182812f,3.843750f,42.932812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0579",true);
		
		myObj= CreateGameObject("FIRST_AID_KIT_41_35_01_0376",49.757813f,2.568750f,42.445313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0750",true);
		
		myObj= CreateGameObject("X_RAY_MACHINE_13_36_01_0624",16.200001f,0.000000f,43.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("HOSPITAL_BED_13_36_01_0508",16.270313f,0.037500f,43.832813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		
		myObj= CreateGameObject("DESTROYED_DRONE_CYBORG_18_36_01_0501",22.200001f,1.650000f,43.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1494",true);
		
		myObj= CreateGameObject("NULL_TRIGGER_19_36_01_0063",23.400000f,1.800000f,43.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 12,0,0,0,0,0);
		AddACTION_CHOICE(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_19_36_01_0007",23.400000f,1.800000f,43.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 9,0,0,0,0,0);
		AddACTION_MOVING_PLATFORM(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_19_36_01_0009",23.400000f,1.800000f,43.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 9,0,0,0,0,0);
		AddACTION_MOVING_PLATFORM(myObj);
		
		myObj= CreateGameObject("ENERGY_GRATING_023_036",28.200001f,2.400000f,43.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,0,0,2424);
		
		myObj= CreateGameObject("STORAGE_ROOM_DOOR_026_036",31.799999f,2.400000f,44.395313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1045",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,10,0,2406);
		
		myObj= CreateGameObject("WORDS_30_36_01_0567",36.632813f,2.850000f,44.395313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("BURN_RESIDUE_30_36_01_0086",36.000000f,2.625000f,43.757813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0843",true);
		
		myObj= CreateGameObject("CAMERA_31_36_01_0416",37.307812f,3.337500f,44.395313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("BRIDGE_31_36_01_0619",37.799999f,1.162500f,43.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("NULL_TRIGGER_31_36_01_0584",37.799999f,1.800000f,43.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "",0,"",0,"",0,"",0);
		
		myObj= CreateGameObject("CYBORG_DRONE_34_36_01_0302",41.400002f,4.050000f,43.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1604",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,460, 0);
		
		myObj= CreateGameObject("SKULL_34_36_01_0157",41.400002f,3.712500f,43.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0718",true);
		
		myObj= CreateGameObject("FIRST_AID_KIT_46_36_01_0051",55.799999f,0.318750f,43.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0750",true);
		
		myObj= CreateGameObject("BRIDGE_46_36_01_0255",55.799999f,2.343750f,43.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("HUMANOID_MUTANT_09_37_01_0284",11.400000f,1.593750f,45.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1541",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,439, 0);
		
		myObj= CreateGameObject("PAPERS_12_37_01_0717",14.920313f,0.150000f,44.882813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0573",true);
		
		myObj= CreateGameObject("CYBERSPACE_TERMINAL_12_37_01_0535",14.995313f,0.581250f,45.370312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0949",true);
		
		myObj= CreateGameObject("MEDICAL_ACCESS_CARD_1",17.732813f,0.131250f,44.582813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0773",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",5,228, 0);
		CreateKey(myObj, 0);
		
		
		myObj= CreateGameObject("ELEVATOR_PANEL_15_37_01_0030",18.000000f,1.912500f,44.995312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0983",false);
		CreateSHOCKActivators(myObj,1);
		AddACTION_TRANSPORT_LEVEL(myObj);
		
		myObj= CreateGameObject("ELEVATOR_DOOR_015_037",18.600000f,1.200000f,44.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1109",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,0,0,2427);
		
		myObj= CreateGameObject("EMAIL_18_37_01_0021",21.782812f,1.293750f,44.545311f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0281",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",13,105, 0);
		
		myObj= CreateGameObject("LARGE_BUTTON_18_37_01_0016",22.195313f,1.818750f,45.595314f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0905",false);
		CreateSHOCKActivators(myObj,6);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_19_36_01_0063", 0,"",0,"",0,"",0);
		
		
		myObj= CreateGameObject("WORDS_20_37_01_0715",25.082813f,3.337500f,44.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("LARGE_BUTTON_20_37_01_0220",24.295313f,3.000000f,44.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0905",false);
		CreateSHOCKActivators(myObj,6);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_19_36_01_0063", 0,"",0,"",0,"",0);
		
		myObj= CreateGameObject("CYBORG_ASSASSIN_27_37_01_0089",32.400002f,2.793750f,44.957813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1610",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,462, 0);
		
		myObj= CreateGameObject("BRIDGE_31_37_01_0719",37.799999f,1.162500f,45.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("DOOR_035_037",42.599998f,3.600000f,45.595314f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1039",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,0,0,2404);
		
		myObj= CreateGameObject("DOOR_039_037",47.400002f,3.600000f,45.595314f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1039",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,0,0,2404);
		
		myObj= CreateGameObject("ELEPHANT_JORP_45_37_01_0243",54.599998f,2.343750f,45.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0563",true);
		
		myObj= CreateGameObject("CONCUSSION_BOMB_16_38_01_0149",20.095312f,2.550000f,46.157814f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0186",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,58, 0);
		
		myObj= CreateGameObject("SKELETON_16_38_01_0406",19.945313f,2.775000f,46.195313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0702",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,210, 0);
		
		myObj= CreateGameObject("LEAD_PIPE_17_38_01_0047",20.882813f,2.700000f,46.007813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0028",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,9, 0);
		
		myObj= CreateGameObject("BROKEN_GUN_17_38_01_0407",21.220312f,2.568750f,45.895313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0592",true);
		
		myObj= CreateGameObject("ENERGY_GRATING_023_038",28.200001f,2.400000f,46.795311f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,0,0,2424);
		
		myObj= CreateGameObject("FORCE_DOOR_031_038",37.799999f,1.200000f,45.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,0,1,2423);
		
		myObj= CreateGameObject("HUMAN_CORPSE_34_38_01_0272",41.400002f,3.975000f,46.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0672",true);
		
		myObj= CreateGameObject("EMERGENCY_LEVER_39_38_01_0627",46.799999f,4.462500f,46.495312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0909",false);
		CreateSHOCKActivators(myObj,6);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_38_39_01_0628", 0,"NULL_TRIGGER_38_39_01_0408", 0,"NULL_TRIGGER_38_39_01_0320", 0,"",0);
		
		myObj= CreateGameObject("VIAL_42_38_01_0642",51.000000f,4.162500f,46.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1420",true);
		
		myObj= CreateGameObject("VIAL_42_38_01_0641",50.920311f,4.162500f,46.345314f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1420",true);
		
		myObj= CreateGameObject("FLASK_42_38_01_0640",50.695313f,4.162500f,46.045311f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1423",true);
		
		myObj= CreateGameObject("ELEPHANT_JORP_45_38_01_0180",54.599998f,2.343750f,46.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0563",true);
		
		myObj= CreateGameObject("SV_TRANQ_DARTS_28_39_01_0726",34.570313f,0.093750f,47.545311f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0058",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,19, 0);
		
		myObj= CreateGameObject("HUMAN_CORPSE_29_39_01_0724",35.507813f,0.375000f,47.807812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0662",true);
		
		myObj= CreateGameObject("GAS_GRENADE_31_39_01_0213",37.870312f,1.350000f,47.282814f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0183",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,57, 0);
		
		myObj= CreateGameObject("GAS_GRENADE_33_39_01_0716",40.532814f,0.150000f,47.170311f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0183",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,57, 0);
		
		myObj= CreateGameObject("GAS_GRENADE_33_39_01_0380",40.200001f,0.150000f,47.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0183",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,57, 0);
		
		myObj= CreateGameObject("CHAIR_34_39_01_0193",41.357811f,3.600000f,47.432812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("EMAIL_35_39_01_0317",42.599998f,4.200000f,47.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0281",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",13,105, 0);
		
		myObj= CreateGameObject("TESTTUBE_RACK_36_39_01_0616",43.532814f,4.200000f,47.282814f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("MICROSCOPE_36_39_01_0625",44.057812f,4.200000f,47.095314f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("SPARQ_BEAM_37_39_01_0094",44.770313f,4.293750f,47.057812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0034",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,11, 0);
		
		myObj= CreateGameObject("THERMOS_37_39_01_0643",45.182812f,4.312500f,47.245312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1417",true);
		
		myObj= CreateGameObject("PERSONAL_ACCESS_CARD_1",44.920311f,4.331250f,47.432812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0791",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",5,234, 0);
		CreateKey(myObj, 0);
		
		myObj= CreateGameObject("NULL_TRIGGER_38_39_01_0628",46.200001f,1.800000f,47.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 15,1,0,0,0,0);
		AddACTION_EMAIL(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_38_39_01_0320",46.200001f,1.800000f,47.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 13,0,0,0,0,0);
		AddACTION_UNKNOWN(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_38_39_01_0408",46.200001f,1.800000f,47.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 3,0,0,0,0,0);
		AddACTION_CLONE(myObj);
		
		myObj= CreateGameObject("SCREEN_39_39_01_0533",46.799999f,4.181250f,47.395313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",63,135, 0);
		
		myObj= CreateGameObject("DH_07_STUNGUN_39_39_01_0108",47.620312f,3.768750f,47.320313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0043",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,14, 0);
		
		myObj= CreateGameObject("FLASK_40_39_01_0639",48.820313f,4.162500f,47.245312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1423",true);
		
		myObj= CreateGameObject("BEAKER_40_39_01_0532",48.599998f,4.162500f,47.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1426",true);
		
		myObj= CreateGameObject("SCOPE_41_39_01_0623",49.795311f,4.050000f,46.982811f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("TESTTUBE_RACK_41_39_01_0614",49.307812f,4.050000f,47.245312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("PAPERS_42_39_01_0480",50.507813f,4.200000f,47.207813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0573",true);
		
		myObj= CreateGameObject("HUMANOID_MUTANT_47_39_01_0650",57.000000f,0.543750f,47.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1541",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,439, 0);
		
		myObj= CreateGameObject("HUMAN_CORPSE_49_39_01_0264",59.732811f,3.956250f,47.395313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0662",true);
		
		myObj= CreateGameObject("LEVER_49_39_01_0365",59.400002f,4.200000f,47.995312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0897",false);
		CreateSHOCKActivators(myObj,12);
		AddACTION_CHOICE(myObj);
		
		myObj= CreateGameObject("CAMERA_11_40_01_0429",14.395312f,2.212500f,48.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("IRIS_DOOR_014_040",17.995312f,1.200000f,48.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1126",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,0,1,2433);
		
		myObj= CreateGameObject("CHEMICAL_TANK_16_40_01_0048",19.907812f,1.593750f,48.182812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1413",true);
		
		myObj= CreateGameObject("CRATE_17_40_01_0524",21.070313f,1.387500f,48.820313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1400",true);
		
		myObj= CreateGameObject("CHEMICAL_TANK_18_40_01_0608",22.607813f,1.593750f,48.857811f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1413",true);
		
		myObj= CreateGameObject("CRATE_19_40_01_0123",23.732813f,1.387500f,48.295311f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1400",true);
		
		myObj= CreateGameObject("CHEMICAL_TANK_20_40_01_0610",24.782812f,1.593750f,48.332813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1413",true);
		
		myObj= CreateGameObject("CRATE_20_40_01_0520",24.257813f,1.387500f,48.857811f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1400",true);
		
		myObj= CreateGameObject("TOXIC_WASTE_BARREL_21_40_01_0609",25.799999f,1.593750f,48.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1410",true);
		
		myObj= CreateGameObject("CYBORG_DRONE_26_40_01_0367",31.832813f,2.850000f,48.670311f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1604",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,460, 0);
		
		myObj= CreateGameObject("HUMAN_CORPSE_28_40_01_0725",34.795311f,0.375000f,48.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0682",true);
		
		myObj= CreateGameObject("ILLUDIUM_CADMIUM_BATTERY_29_40_01_0723",35.170311f,0.112500f,48.332813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0744",true);
		
		myObj= CreateGameObject("REFLEX_REACTION_AID_29_40_01_0722",35.545311f,0.150000f,48.520313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0212",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,67, 0);
		
		myObj= CreateGameObject("NITROPACK_29_40_01_0721",35.400002f,0.150000f,48.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0192",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,60, 0);
		
		myObj= CreateGameObject("SWITCH_30_40_01_0450",36.932812f,1.912500f,48.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0881",false);
		CreateSHOCKActivators(myObj,6);
		AddACTION_ACTIVATE(myObj, "FORCE_DOOR_031_038", 0,"",0,"",0,"",0);
		
		
		myObj= CreateGameObject("CYBORG_ASSASSIN_37_40_01_0262",45.000000f,1.593750f,48.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1610",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,462, 0);
		
		myObj= CreateGameObject("CYBORG_ASSASSIN_45_40_01_0263",54.970314f,2.793750f,48.595314f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1610",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,462, 0);
		
		myObj= CreateGameObject("NULL_TRIGGER_49_40_01_0371",59.400002f,1.200000f,48.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_49_40_01_0370", 0,"NULL_TRIGGER_49_40_01_0326", 0,"",0,"",0);
		
		myObj= CreateGameObject("NULL_TRIGGER_49_40_01_0372",59.400002f,1.200000f,48.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_49_40_01_0217", 0,"NULL_TRIGGER_49_40_01_0373", 0,"",0,"",0);
		
		myObj= CreateGameObject("NULL_TRIGGER_49_40_01_0370",59.400002f,1.200000f,48.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 24,0,0,0,0,0);
		AddACTION_CHANGE_TYPE(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_49_40_01_0326",59.400002f,1.200000f,48.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 24,0,0,0,0,0);
		AddACTION_CHANGE_TYPE(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_49_40_01_0217",59.400002f,1.200000f,48.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 24,0,0,0,0,0);
		AddACTION_CHANGE_TYPE(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_49_40_01_0373",59.400002f,1.200000f,48.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 24,0,0,0,0,0);
		AddACTION_CHANGE_TYPE(myObj);
		
		myObj= CreateGameObject("SWITCH_12_41_01_0525",14.400000f,1.818750f,49.795311f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0881",false);
		CreateSHOCKActivators(myObj,6);
		AddACTION_ACTIVATE(myObj, "IRIS_DOOR_014_040", 0,"",0,"",0,"",0);
		
		myObj= CreateGameObject("BEVERAGE_CONTAINER_21_41_01_0526",25.799999f,0.093750f,49.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0568",true);
		
		myObj= CreateGameObject("FRAGMENTATION_GRENADE_21_41_01_0528",25.799999f,0.150000f,49.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0177",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,55, 0);
		
		myObj= CreateGameObject("FRAGMENTATION_GRENADE_21_41_01_0522",25.799999f,0.150000f,49.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0177",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,55, 0);
		
		myObj= CreateGameObject("EMP_GRENADE_21_41_01_0527",25.799999f,0.150000f,49.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0180",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,56, 0);
		
		myObj= CreateGameObject("CATWALK_26_41_01_0260",31.795313f,2.343750f,50.245312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("CATWALK_27_41_01_0261",32.957813f,2.343750f,50.245312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("REPULSOR_30_41_01_0055",36.599998f,1.800000f,49.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1370",false);
		
		myObj= CreateGameObject("FRAGMENTATION_GRENADE_47_41_01_0649",57.295311f,0.300000f,49.870312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0177",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,55, 0);
		
		myObj= CreateGameObject("EMAIL_16_42_01_0316",19.799999f,2.493750f,51.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0281",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",13,105, 0);
		
		myObj= CreateGameObject("CAMERA_16_42_01_0424",19.495312f,3.375000f,50.620312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("FORCE_DOOR_017_042",21.595312f,2.400000f,51.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,0,0,2423);
		
		myObj= CreateGameObject("CYBORG_DRONE_17_42_01_0328",21.000000f,2.850000f,51.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1604",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,460, 0);
		
		myObj= CreateGameObject("NULL_TRIGGER_19_42_01_0540",23.400000f,3.000000f,51.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_19_42_01_0538", 0,"NULL_TRIGGER_18_43_01_0397", 0,"",0,"",0);
		
		myObj= CreateGameObject("NULL_TRIGGER_19_42_01_0539",23.400000f,3.000000f,51.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_19_42_01_0537", 0,"NULL_TRIGGER_18_43_01_0160", 0,"",0,"",0);
		
		myObj= CreateGameObject("NULL_TRIGGER_19_42_01_0538",23.400000f,3.000000f,51.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 22,0,0,0,0,0);
		AddACTION_MESSAGE(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_19_42_01_0537",23.400000f,3.000000f,51.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 22,0,0,0,0,0);
		AddACTION_MESSAGE(myObj);
		
		myObj= CreateGameObject("CYBORG_ASSASSIN_20_42_01_0330",24.600000f,2.793750f,51.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1610",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,462, 0);
		
		myObj= CreateGameObject("ENERGY_GRATING_023_042",28.200001f,2.400000f,51.595314f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,0,0,2424);
		
		myObj= CreateGameObject("REPULSOR_26_42_01_0451",31.799999f,0.600000f,51.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1370",false);
		
		myObj= CreateGameObject("FRAGMENTATION_GRENADE_28_42_01_0693",34.345314f,2.550000f,51.182812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0177",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,55, 0);
		
		myObj= CreateGameObject("WORDS_35_42_01_0570",42.000000f,1.706250f,51.032814f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("SWITCH_14_43_01_0603",17.400000f,1.875000f,52.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0881",false);
		CreateSHOCKActivators(myObj,0);
		AddACTION_DO_NOTHING(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_18_43_01_0237",22.200001f,3.000000f,52.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 12,0,0,0,0,0);
		AddACTION_CHOICE(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_18_43_01_0397",22.200001f,3.000000f,52.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 4,0,0,0,0,0);
		AddACTION_SET_VARIABLE(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_18_43_01_0160",22.200001f,3.000000f,52.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 4,0,0,0,0,0);
		AddACTION_SET_VARIABLE(myObj);
		
		myObj= CreateGameObject("LEVER_18_43_01_0227",22.795313f,2.925000f,52.120312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0899",false);
		CreateSHOCKActivators(myObj,6);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_18_43_01_0237", 0,"",0,"",0,"",0);
		
		myObj= CreateGameObject("GRATING_18_43_01_0232",22.200001f,3.000000f,51.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1073",true);
		
		myObj= CreateGameObject("PLAYER_DEATH_TRIGGER_19_43_01_0230",23.400000f,3.000000f,52.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1349",true);
		
		myObj= CreateGameObject("NULL_TRIGGER_19_43_01_0229",23.400000f,3.000000f,52.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 1,0,0,0,0,0);
		AddACTION_TRANSPORT_LEVEL(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_19_43_01_0228",23.400000f,3.000000f,52.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 2,0,0,0,0,0);
		AddACTION_RESURRECTION(myObj);
		
		myObj= CreateGameObject("WORDS_20_43_01_0153",24.000000f,2.737500f,52.270313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("ICON_20_43_01_0234",24.000000f,3.225000f,52.195313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0395",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",62,127, 0);
		
		myObj= CreateGameObject("CYBORG_DRONE_25_43_01_0329",30.600000f,2.850000f,52.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1604",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,460, 0);
		
		myObj= CreateGameObject("CAMERA_26_43_01_0425",32.320313f,3.543750f,52.757813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("CYBORG_ASSASSIN_31_43_01_0398",37.799999f,2.793750f,52.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1610",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,462, 0);
		
		myObj= CreateGameObject("CYBORG_DRONE_38_43_01_0314",46.757813f,2.850000f,52.307812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1604",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,460, 0);
		
		myObj= CreateGameObject("NULL_TRIGGER_42_43_01_0604",51.000000f,1.800000f,52.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 7,0,0,0,0,0);
		AddACTION_LIGHTING(myObj);
		
		myObj= CreateGameObject("CYBORG_DRONE_16_44_01_0092",19.832813f,2.850000f,53.395313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1604",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,460, 0);
		
		myObj= CreateGameObject("CAMERA_16_44_01_0423",19.457813f,3.375000f,53.770313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("SCREEN_18_44_01_0369",22.195313f,3.000000f,53.995312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",63,135, 0);
		
		myObj= CreateGameObject("ENERGY_GRATING_019_044",23.995312f,2.400000f,53.395313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,0,0,2424);
		
		myObj= CreateGameObject("NULL_TRIGGER_21_44_01_0557",25.799999f,3.000000f,53.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 12,0,0,0,0,0);
		AddACTION_CHOICE(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_21_44_01_0596",25.799999f,3.000000f,53.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 24,0,0,0,0,0);
		AddACTION_CHANGE_TYPE(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_21_44_01_0589",25.799999f,3.000000f,53.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 24,0,0,0,0,0);
		AddACTION_CHANGE_TYPE(myObj);
		
		myObj= CreateGameObject("CYBORG_DRONE_22_44_01_0368",26.821875f,0.450000f,53.793751f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1604",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,460, 0);
		
		myObj= CreateGameObject("CYBORG_DRONE_23_44_01_0091",28.200001f,2.850000f,53.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1604",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,460, 0);
		
		myObj= CreateGameObject("NULL_TRIGGER_25_44_01_0595",30.600000f,0.600000f,53.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 12,0,0,0,0,0);
		AddACTION_CHOICE(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_25_44_01_0594",30.600000f,0.600000f,53.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 24,0,0,0,0,0);
		AddACTION_CHANGE_TYPE(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_25_44_01_0556",30.600000f,0.600000f,53.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 24,0,0,0,0,0);
		AddACTION_CHANGE_TYPE(myObj);
		
		myObj= CreateGameObject("BUTTON_28_44_01_0554",34.795311f,0.750000f,53.545311f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0889",false);
		CreateSHOCKActivators(myObj,6);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_25_44_01_0595", 0,"",0,"",0,"",0);
		
		myObj= CreateGameObject("FORCE_DOOR_28_44_01_0551",34.200001f,0.600000f,53.995312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("NULL_TRIGGER_29_44_01_0356",35.400002f,1.200000f,53.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "",0,"",0,"",0,"",0);
		
		myObj= CreateGameObject("MEDIPATCH__HEALING_AGENT_37_44_01_0409",44.732811f,2.550000f,53.395313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,66, 0);
		
		myObj= CreateGameObject("NULL_TRIGGER_12_45_01_0602",15.000000f,1.200000f,54.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 7,0,0,0,0,0);
		AddACTION_LIGHTING(myObj);
		
		myObj= CreateGameObject("DEATH_WATCH_TRIGGER_21_45_01_0562",25.799999f,3.450000f,54.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1352",false);
		CreateNull_Trigger(myObj, 6,1,47,2,0,1);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_25_44_01_0594", 0,"NULL_TRIGGER_21_45_01_0588", 0,"",0,"",0);
		
		myObj= CreateGameObject("NULL_TRIGGER_21_45_01_0563",25.799999f,3.450000f,54.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 22,0,0,0,0,0);
		AddACTION_MESSAGE(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_21_45_01_0587",25.799999f,3.450000f,54.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 4,0,0,0,0,0);
		AddACTION_SET_VARIABLE(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_21_45_01_0588",25.799999f,3.450000f,54.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 4,0,0,0,0,0);
		AddACTION_SET_VARIABLE(myObj);
		
		myObj= CreateGameObject("CAMERA_22_45_01_0559",26.545313f,0.900000f,55.195313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("BATTERY_PACK_22_45_01_0644",26.995312f,0.112500f,54.407814f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0756",true);
		
		myObj= CreateGameObject("BATTERY_PACK_22_45_01_0560",27.000000f,0.112500f,54.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0756",true);
		
		myObj= CreateGameObject("BUTTON_23_45_01_0592",28.326563f,0.731250f,54.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0889",false);
		CreateSHOCKActivators(myObj,6);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_21_46_01_0597", 0,"",0,"",0,"",0);
		
		myObj= CreateGameObject("FORCE_DOOR_23_45_01_0553",28.795313f,0.600000f,54.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("BUTTON_24_45_01_0558",29.245312f,0.731250f,55.195313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0889",false);
		CreateSHOCKActivators(myObj,6);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_21_46_01_0597", 0,"",0,"",0,"",0);
		
		
		myObj= CreateGameObject("BUTTON_26_45_01_0593",31.945313f,0.731250f,55.195313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0889",false);
		CreateSHOCKActivators(myObj,6);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_21_44_01_0557", 0,"",0,"",0,"",0);
		
		myObj= CreateGameObject("BUTTON_27_45_01_0586",33.145313f,0.731250f,54.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0889",false);
		CreateSHOCKActivators(myObj,6);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_25_44_01_0595", 0,"",0,"",0,"",0);
		
		myObj= CreateGameObject("BUTTON_27_45_01_0555",32.821877f,0.731250f,54.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0889",false);
		CreateSHOCKActivators(myObj,6);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_21_44_01_0557", 0,"",0,"",0,"",0);
		
		myObj= CreateGameObject("FORCE_DOOR_27_45_01_0552",33.595314f,0.600000f,54.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("CYBORG_DRONE_30_45_01_0221",36.599998f,2.850000f,54.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1604",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,460, 0);
		
		myObj= CreateGameObject("NULL_TRIGGER_31_45_01_0344",37.799999f,3.000000f,54.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 23,1,0,0,0,0);
		AddACTION_SPAWN(myObj);
		
		
		myObj= CreateGameObject("CAMERA_35_45_01_0430",43.157814f,3.318750f,54.032814f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("ENERGY_GRATING_038_045",46.200001f,2.400000f,54.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,0,0,2424);
		
		myObj= CreateGameObject("BERSERK_COMBAT_BOOSTER_16_46_01_0334",19.495312f,2.550000f,55.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0205",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,65, 0);
		
		myObj= CreateGameObject("BROKEN_GUN_16_46_01_0333",19.457813f,2.568750f,55.645313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0592",true);
		
		myObj= CreateGameObject("SKELETON_16_46_01_0332",19.799999f,2.756250f,55.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0702",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,210, 0);
		
		myObj= CreateGameObject("GRATING_17_46_01_0155",20.400000f,3.000000f,55.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1073",true);
		
		myObj= CreateGameObject("SCREEN_18_46_01_0530",22.195313f,2.981250f,55.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",63,135, 0);
		
		myObj= CreateGameObject("EMAIL_18_46_01_0505",21.782812f,2.493750f,55.720314f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0281",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",13,105, 0);
		
		myObj= CreateGameObject("HUMAN_CORPSE_18_46_01_0504",22.757813f,2.756250f,55.795311f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0632",true);
		
		myObj= CreateGameObject("DESTROYED_ASSASSIN_CYBORG_18_46_01_0503",22.200001f,2.793750f,55.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1500",true);
		
		myObj= CreateGameObject("CAMERA_18_46_01_0422",22.795313f,3.543750f,55.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("NULL_TRIGGER_21_46_01_0597",25.799999f,2.850000f,55.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 12,0,0,0,0,0);
		AddACTION_CHOICE(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_21_46_01_0591",25.799999f,2.850000f,55.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 24,0,0,0,0,0);
		AddACTION_CHANGE_TYPE(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_21_46_01_0590",25.799999f,2.850000f,55.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 24,0,0,0,0,0);
		AddACTION_CHANGE_TYPE(myObj);
		
		myObj= CreateGameObject("CYBORG_DRONE_22_46_01_0360",27.257813f,2.700000f,55.870312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1604",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,460, 0);
		
		myObj= CreateGameObject("CYBORG_DRONE_24_46_01_0174",29.732813f,2.700000f,55.982811f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1604",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,460, 0);
		
		myObj= CreateGameObject("CYBORG_DRONE_26_46_01_0060",31.982813f,2.756250f,56.231251f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1604",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,460, 0);
		
		myObj= CreateGameObject("CAMERA_30_46_01_0426",36.370312f,3.431250f,55.832813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("WORDS_36_46_01_0569",43.799999f,2.700000f,56.395313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("CYBORG_DRONE_40_46_01_0400",48.932812f,0.600000f,56.132813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1604",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,460, 0);
		
		myObj= CreateGameObject("CONTROL_PEDESTAL_41_46_01_0167",49.907814f,0.150000f,55.945313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("ML_41_PISTOL_43_46_01_0565",52.200001f,0.300000f,55.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0001",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,0, 0);
		
		myObj= CreateGameObject("GRATING_17_47_01_0322",20.400000f,3.000000f,57.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1073",true);
		
		myObj= CreateGameObject("SCREEN_18_47_01_0531",22.200001f,2.981250f,57.595314f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",63,135, 0);
		
		myObj= CreateGameObject("CYBORG_DRONE_20_47_01_0090",24.600000f,2.850000f,57.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1604",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,460, 0);
		
		
		myObj= CreateGameObject("REPULSOR_35_47_01_0579",42.599998f,0.600000f,57.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1370",false);
		
		myObj= CreateGameObject("COMPUTER_NODE_41_47_01_0166",49.799999f,0.150000f,57.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("COMPUTER_NODE_42_47_01_0145",51.000000f,0.150000f,57.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("CYBORG_DRONE_20_48_01_0363",24.478125f,2.250000f,58.724998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1604",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,460, 0);
		
		myObj= CreateGameObject("CYBORG_DRONE_22_48_01_0362",26.845312f,2.250000f,58.645313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1604",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,460, 0);
		
		myObj= CreateGameObject("CAMERA_30_48_01_0427",36.407814f,3.393750f,58.157814f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("COMPUTER_NODE_41_48_01_0144",49.799999f,0.150000f,58.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("COMPUTER_NODE_42_48_01_0115",51.000000f,0.150000f,58.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("DEATH_WATCH_TRIGGER_44_48_01_0475",53.400002f,1.200000f,58.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1352",false);
		CreateNull_Trigger(myObj, 6,1,8,0,7,0);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_45_48_01_0645", 80,"NULL_TRIGGER_20_51_01_0357", 0,"NULL_TRIGGER_31_45_01_0344", 0,"",0);
		
		myObj= CreateGameObject("NULL_TRIGGER_45_48_01_0645",54.599998f,1.200000f,58.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 15,0,0,0,0,0);
		AddACTION_EMAIL(myObj);
		
		myObj= CreateGameObject("CYBORG_ASSASSIN_27_49_01_0401",33.032814f,2.193750f,59.395313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1610",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,462, 0);
		
		myObj= CreateGameObject("SKULL_29_49_01_0403",35.432812f,0.712500f,59.770313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0718",true);
		
		myObj= CreateGameObject("MEDIPATCH__HEALING_AGENT_29_49_01_0404",35.695313f,0.750000f,59.657814f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,66, 0);
		
		myObj= CreateGameObject("LUMP_OF_CLOTHES_30_49_01_0402",36.599998f,0.243750f,59.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0585",true);
		
		myObj= CreateGameObject("CYBORG_WARRIOR_35_49_01_0306",42.599998f,2.887500f,59.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1607",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,461, 0);
		
		
		myObj= CreateGameObject("CAMERA_39_49_01_0428",47.995312f,1.181250f,59.995312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("NULL_TRIGGER_41_49_01_0583",50.170311f,3.168750f,59.432812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "",0,"",0,"",0,"",0);
		
		myObj= CreateGameObject("SCREEN_43_49_01_0238",52.795311f,0.862500f,59.357811f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",63,132, 0);
		
		myObj= CreateGameObject("DEATH_WATCH_TRIGGER_44_49_01_0445",53.400002f,1.200000f,59.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1352",false);
		CreateNull_Trigger(myObj, 6,0,8,0,7,0);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_45_49_01_0506", 0,"NULL_TRIGGER_46_49_01_0375", 0,"NULL_TRIGGER_46_49_01_0507", 0,"",0);
		
		myObj= CreateGameObject("NULL_TRIGGER_45_49_01_0506",54.599998f,1.200000f,59.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 4,0,0,0,0,0);
		AddACTION_SET_VARIABLE(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_46_49_01_0507",55.799999f,1.200000f,59.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 19,0,33,16,4,0);
		AddACTION_CHANGE_STATE(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_46_49_01_0375",55.799999f,1.200000f,59.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 19,0,33,16,4,0);
		AddACTION_CHANGE_STATE(myObj);
		
		myObj= CreateGameObject("CYBORG_DRONE_23_50_01_0361",28.040625f,2.250000f,60.159374f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1604",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,460, 0);
		
		myObj= CreateGameObject("CYBORG_DRONE_25_50_01_0359",30.417187f,2.250000f,60.168751f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1604",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,460, 0);
		
		myObj= CreateGameObject("DEATH_WATCH_TRIGGER_36_50_01_0276",43.799999f,0.600000f,60.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1352",false);
		CreateNull_Trigger(myObj, 4,0,8,0,7,0);
		AddACTION_SET_VARIABLE(myObj);
		
		myObj= CreateGameObject("SWITCH_20_51_01_0355",24.600000f,0.675000f,61.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0881",false);
		CreateSHOCKActivators(myObj,0);
		AddACTION_DO_NOTHING(myObj);
		
		myObj= CreateGameObject("NULL_TRIGGER_20_51_01_0357",24.600000f,1.200000f,61.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 21,0,0,0,0,0);
		AddACTION_AWAKEN(myObj);
		
		myObj= CreateGameObject("STORAGE_ROOM_DOOR_031_051",37.799999f,0.000000f,61.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1045",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		CreateShockDoor(myObj,0,0,2406);
		
		myObj= CreateGameObject("CRATE_20_52_01_0545",24.407812f,1.575000f,63.070313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1402",true);
		
		myObj= CreateGameObject("MEDIPATCH__HEALING_AGENT_22_52_01_0343",27.000000f,1.350000f,63.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,66, 0);
		
		myObj= CreateGameObject("SCREEN_28_52_01_0543",34.195313f,2.981250f,62.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",63,135, 0);
		
		myObj= CreateGameObject("SCREEN_29_52_01_0544",35.395313f,3.000000f,62.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",63,135, 0);
		
		myObj= CreateGameObject("CYBORG_DRONE_30_52_01_0358",36.557812f,1.650000f,62.995312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1604",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,460, 0);
		
		myObj= CreateGameObject("SCREEN_30_52_01_0542",36.595314f,3.000000f,62.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",63,135, 0);
		
		myObj= CreateGameObject("BUTTON_30_52_01_0541",37.195313f,2.118750f,63.107811f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0889",false);
		CreateSHOCKActivators(myObj,9);
		AddACTION_MOVING_PLATFORM(myObj);
		
		myObj= CreateGameObject("TOXIC_WASTE_BARREL_31_52_01_0637",37.907814f,0.393750f,63.407814f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1410",true);
		
		myObj= CreateGameObject("TOXIC_WASTE_BARREL_32_52_01_0634",39.000000f,0.393750f,63.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1410",true);
		
		myObj= CreateGameObject("CRATE_20_53_01_0547",24.670313f,1.387500f,63.857811f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1400",true);
		
		myObj= CreateGameObject("CRATE_21_53_01_0546",25.799999f,1.575000f,64.199997f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1402",true);
		
		myObj= CreateGameObject("CHEMICAL_TANK_31_53_01_0631",37.799999f,0.393750f,64.199997f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1413",true);
		
		myObj= CreateGameObject("TOXIC_WASTE_BARREL_32_53_01_0635",39.145313f,0.393750f,63.745312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1410",true);
		
		myObj= CreateGameObject("CHEMICAL_TANK_32_53_01_0632",39.032814f,0.393750f,64.532814f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1413",true);
		
		myObj= CreateGameObject("CHEMICAL_TANK_33_53_01_0633",39.857811f,0.393750f,64.120316f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1413",true);
		
		myObj= CreateGameObject("TURBO_MOTION_BOOSTER_SYSTEM_31_54_01_0636",38.057812f,0.112500f,65.095314f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0257",true);
		
		myObj= CreateGameObject("CHEMICAL_TANK_31_54_01_0629",38.020313f,0.393750f,65.432816f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1413",true);
		
		myObj= CreateGameObject("CHEMICAL_TANK_32_54_01_0630",38.845314f,0.393750f,65.432816f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1413",true);








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

	static void CreateUWActivators(GameObject myObj,string activatortype, string target, int triggerX, int triggerY, int state, int maxstate, int item_id)
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
				buttonScript.item_id=item_id;
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

	static void CreateSHOCKActivators(GameObject myObj, int TriggerAction)
	{
		GameObject Button = new GameObject(myObj.name + "_activator");
		Button.transform.parent= myObj.transform;
		ShockButtonHandler shockbuttonScript = Button.AddComponent<ShockButtonHandler>();
		shockbuttonScript.TriggerAction= TriggerAction;

		BoxCollider box= Button.AddComponent<BoxCollider>();
		box.transform.position = myObj.transform.position;
		box.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
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

	static void AddACTION_CHOICE(GameObject myObj)
	{
		Action_Choice ac= myObj.AddComponent<Action_Choice>();
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

	static void AddACTION_MOVING_PLATFORM(GameObject myObj)
	{
		Action_Moving_Platform mp = myObj.AddComponent<Action_Moving_Platform>();
	}

	static void AddACTION_SET_VARIABLE(GameObject myObj)
	{
		Action_Set_Variable SV = myObj.AddComponent<Action_Set_Variable>();
	}

	static void AddACTION_CHANGE_STATE(GameObject myObj)
	{
		Action_Change_State ac = myObj.AddComponent<Action_Change_State>();
	}

	static void AddACTION_SPAWN(GameObject myObj)
	{
		Action_Spawn acp = myObj.AddComponent<Action_Spawn>();
	}

	static void AddACTION_MESSAGE(GameObject myObj)
	{
		Action_Message am = myObj.AddComponent<Action_Message>();
	}

	static void AddACTION_CHANGE_TYPE(GameObject myObj)
	{
		Action_Change_Type act = myObj.AddComponent<Action_Change_Type>();
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
}
