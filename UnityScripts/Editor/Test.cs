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
		myObj= CreateGameObject("BROKEN_LEVER_04_04_01_0049",4.820000f,4.462500f,5.695313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0615",true);
		
		myObj= CreateGameObject("FRAGMENTATION_GRENADE_04_04_01_0648",5.380000f,0.150000f,5.380000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0177",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,55, 0);
		
		myObj= CreateGameObject("FRAGMENTATION_GRENADE_04_04_01_0647",5.380000f,0.150000f,5.380000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0177",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,55, 0);
		
		myObj= CreateGameObject("SV_TRANQ_DARTS_04_04_01_0387",5.380000f,0.093750f,5.380000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0058",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,19, 0);
		
		myObj= CreateGameObject("SV_NEEDLE_DARTS_04_04_01_0489",5.380000f,0.093750f,5.380000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0055",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,18, 0);
		
		myObj= CreateGameObject("SV_NEEDLE_DARTS_04_04_01_0436",5.380000f,0.093750f,5.380000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0055",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,18, 0);
		
		myObj= CreateGameObject("SV_NEEDLE_DARTS_04_04_01_0660",5.380000f,0.093750f,5.380000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0055",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,18, 0);
		
		myObj= CreateGameObject("SV_NEEDLE_DARTS_04_04_01_0493",5.380000f,0.093750f,5.380000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0055",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,18, 0);
		
		myObj= CreateGameObject("GROUP_ACCESS_CARD_2",5.380000f,0.131250f,5.380000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0788",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",5,233, 0);
		CreateKey(myObj, 0);
		
		myObj= CreateGameObject("FRAGMENTATION_GRENADE_04_04_01_0477",5.380000f,0.150000f,5.380000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0177",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,55, 0);
		
		myObj= CreateGameObject("BEVERAGE_CONTAINER_04_04_01_0478",5.380000f,0.093750f,5.380000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0568",true);
		
		myObj= CreateGameObject("SKULL_04_04_01_0479",5.380000f,0.112500f,5.380000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0718",true);
		
		myObj= CreateGameObject("SKULL_04_04_01_0481",5.380000f,0.112500f,5.380000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0718",true);
		
		myObj= CreateGameObject("LAND_MINE_04_04_01_0671",5.380000f,0.150000f,5.380000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0189",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,59, 0);
		
		myObj= CreateGameObject("LAND_MINE_04_04_01_0492",5.380000f,0.150000f,5.380000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0189",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,59, 0);
		
		myObj= CreateGameObject("FRAGMENTATION_GRENADE_04_04_01_0664",5.380000f,0.150000f,5.380000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0177",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,55, 0);
		
		myObj= CreateGameObject("BIOLOGICAL_SYSTEMS_MONITOR_04_04_01_0550",5.380000f,0.131250f,5.380000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0235",true);
		
		myObj= CreateGameObject("FRAGMENTATION_GRENADE_04_04_01_0549",5.380000f,0.150000f,5.380000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0177",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,55, 0);
		
		myObj= CreateGameObject("FRAGMENTATION_GRENADE_04_04_01_0548",5.380000f,0.150000f,5.380000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0177",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,55, 0);
		
		myObj= CreateGameObject("MULTIMEDIA_DATA_READER_04_04_01_0147",5.380000f,0.075000f,5.380000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0246",true);
		
		myObj= CreateGameObject("EMAIL_04_04_01_0321",5.395312f,0.093750f,5.770312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0281",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",13,105, 0);
		
		myObj= CreateGameObject("SV_NEEDLE_DARTS_04_04_01_0018",5.380000f,0.093750f,5.380000f);
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
		
		myObj= CreateGameObject("BULLET_HOLE_37_09_01_0077",44.980000f,1.537500f,11.380000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0836",true);
		
		myObj= CreateGameObject("LAND_MINE_20_10_01_0339",24.580000f,1.350000f,12.580000f);
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
		
		myObj= CreateGameObject("HUMAN_CORPSE_23_10_01_0466",28.180000f,1.462500f,12.580000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0692",true);
		
		myObj= CreateGameObject("SPARQ_BEAM_24_10_01_0323",29.379999f,1.293750f,12.580000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0034",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,11, 0);
		
		myObj= CreateGameObject("HUMAN_CORPSE_26_10_01_0256",31.780001f,1.575000f,12.580000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0672",true);
		
		myObj= CreateGameObject("SKULL_27_10_01_0056",32.980000f,1.312500f,12.580000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0718",true);
		
		myObj= CreateGameObject("HUMAN_CORPSE_28_10_01_0099",34.180000f,1.462500f,12.580000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0692",true);
		
		myObj= CreateGameObject("DARK_LORD_TUAOHTUA_29_10_01_0704",35.380001f,1.800000f,12.580000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("HUMAN_CORPSE_30_10_01_0270",36.580002f,1.575000f,12.580000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0672",true);
		
		myObj= CreateGameObject("HUMAN_CORPSE_32_10_01_0267",38.980000f,1.575000f,12.580000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0672",true);
		
		myObj= CreateGameObject("BROKEN_GUN_32_10_01_0279",38.657814f,1.368750f,12.670313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0592",true);
		
		myObj= CreateGameObject("HUMAN_CORPSE_33_10_01_0280",40.180000f,1.575000f,12.580000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0642",true);
		
		myObj= CreateGameObject("BROKEN_GUN_36_10_01_0275",44.095314f,1.368750f,13.157812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0592",true);
		
		myObj= CreateGameObject("SKELETON_36_10_01_0274",43.682812f,1.575000f,13.157812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0702",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,210, 0);
		
		myObj= CreateGameObject("HUMAN_CORPSE_37_10_01_0196",44.980000f,1.556250f,12.580000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0642",true);
		
		myObj= CreateGameObject("BRIEFCASE_38_10_01_0246",46.180000f,1.443750f,12.580000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0588",true);
		
		myObj= CreateGameObject("STAMINUP__STIMULANT_20_11_01_0342",24.107813f,1.350000f,14.207812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0200",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,63, 0);
		
		myObj= CreateGameObject("SKULL_20_11_01_0341",24.482813f,1.312500f,14.320313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0718",true);
		
		myObj = new GameObject("HUMANOID_MUTANT_20_11_01_0340");
		pos = new Vector3(24.020000f, 1.593750f, 13.945313f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"439","Sprites/objects_1350_1541");
		
		myObj= CreateGameObject("SPARQ_BEAM_21_11_01_0410",25.457813f,1.293750f,13.382813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0034",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,11, 0);
		
		myObj= CreateGameObject("CRATE_21_11_01_0516",25.645313f,1.387500f,14.132813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1400",true);
		
		myObj= CreateGameObject("HUMAN_CORPSE_21_11_01_0469",26.057812f,1.462500f,13.232813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0692",true);
		
		myObj= CreateGameObject("CRATE_22_11_01_0519",26.980000f,1.575000f,13.780000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1402",true);
		
		myObj= CreateGameObject("HUMAN_CORPSE_24_11_01_0464",29.432812f,1.556250f,13.220000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0642",true);
		
		myObj= CreateGameObject("BROKEN_GUN_26_11_01_0127",32.207813f,1.368750f,13.532812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0592",true);
		
		myObj= CreateGameObject("HUMAN_CORPSE_26_11_01_0052",32.170311f,1.575000f,13.345312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0632",true);
		
		myObj= CreateGameObject("STAMINUP__STIMULANT_26_11_01_0070",31.780001f,1.350000f,13.780000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0200",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,63, 0);
		
		myObj= CreateGameObject("STAMINUP__STIMULANT_26_11_01_0075",32.020313f,1.350000f,14.020312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0200",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,63, 0);
		
		myObj= CreateGameObject("BUTTON_27_11_01_0703",33.482811f,1.800000f,14.395312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0885",false);
		CreateSHOCKActivators(myObj,7);
		AddACTION_LIGHTING(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("HUMAN_CORPSE_27_11_01_0161",32.620312f,1.575000f,13.720312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0642",true);
		
		myObj= CreateGameObject("CART_29_11_01_0611",35.380001f,1.200000f,13.780000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("HUMAN_CORPSE_31_11_01_0269",37.779999f,1.462500f,13.780000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0692",true);
		
		myObj= CreateGameObject("GRATING_33_11_01_0175",40.180000f,1.800000f,14.395312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1076",true);
		
		myObj= CreateGameObject("EXPLOSION_RESIDUE_34_11_01_0277",41.395313f,1.200000f,13.757813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0840",true);
		
		myObj= CreateGameObject("GRATING_34_11_01_0003",41.380001f,1.800000f,14.395312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1076",true);
		
		myObj= CreateGameObject("HUMAN_CORPSE_37_11_01_0273",45.332813f,1.575000f,14.020312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0632",true);
		
		myObj= CreateGameObject("BULLET_HOLE_38_11_01_0065",45.782814f,2.118750f,14.395312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0836",true);
		
		myObj= CreateGameObject("BULLET_HOLE_38_11_01_0396",46.795311f,1.781250f,13.607813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0836",true);
		
		myObj= CreateGameObject("BLOOD_STAIN_38_11_01_0379",46.270313f,1.200000f,13.757813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0846",true);
		
		myObj= CreateGameObject("EMAIL_38_11_01_0319",46.180000f,1.293750f,13.780000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0281",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",13,105, 0);
		
		myObj= CreateGameObject("NULL_TRIGGER_17_12_01_0163",20.980000f,1.800000f,14.980000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 12,0,0,0,0,0);
		AddACTION_CHOICE(myObj,"NULL_TRIGGER_18_18_01_0112", "NULL_TRIGGER_18_18_01_0113");
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_17_12_01_0337",20.980000f,1.800000f,14.980000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 7,0,0,0,0,0);
		AddACTION_LIGHTING(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("KEYPAD_PANEL_23_12_01_0291",27.620001f,2.062500f,14.695313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0991",false);
		CreateSHOCKActivators(myObj,0);
		AddACTION_DO_NOTHING(myObj, "STORAGE_ROOM_DOOR_023_012");
		SetRotation(myObj,(float)-0.000000,(float)270.000000,(float)0.000000);
		
		myObj= CreateGameObject("STORAGE_ROOM_DOOR_023_012",28.180000f,1.200000f,14.420000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1045",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)180.000000,(float)0.000000);
		CreateShockDoor(myObj,0,1,2406);
		
		myObj= CreateGameObject("ICON_23_12_01_0515",27.620001f,2.006250f,15.482813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0395",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",62,127, 0);
		
		myObj= CreateGameObject("HUMAN_BONES_26_12_01_0072",31.457813f,1.462500f,14.957812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0712",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,211, 0);
		
		myObj= CreateGameObject("CAMERA_28_12_01_0421",33.619999f,2.193750f,14.470312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("DOOR_028_012",34.180000f,1.200000f,14.420000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1039",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)180.000000,(float)0.000000);
		CreateShockDoor(myObj,0,0,2404);
		
		myObj= CreateGameObject("BEAM_BLAST_35_12_01_0057",42.580002f,1.650000f,15.595312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0831",true);
		
		myObj= CreateGameObject("GRAFFITI_36_12_01_0513",44.395313f,1.912500f,14.995313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0399",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",62,128, 0);
		
		myObj = new GameObject("REPAIRBOT_21_13_01_0192");
		pos = new Vector3(25.780001f, 1.593750f, 16.180000f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"449","Sprites/objects_1350_1571");
		
		myObj= CreateGameObject("SEVERED_HEAD_25_13_01_0083",30.580000f,1.425000f,16.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0724",true);
		
		myObj= CreateGameObject("DARK_LORD_TUAOHTUA_27_13_01_0707",32.980000f,1.800000f,16.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("BUTTON_27_13_01_0702",32.995312f,2.100000f,16.795313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0885",false);
		CreateSHOCKActivators(myObj,7);
		AddACTION_LIGHTING(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_29_13_01_0211",35.380001f,1.800000f,16.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 7,0,0,0,0,0);
		AddACTION_LIGHTING(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj = new GameObject("HUMANOID_MUTANT_30_13_01_0203");
		pos = new Vector3(36.028126f, 1.593750f, 16.546875f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"439","Sprites/objects_1350_1541");
		
		myObj= CreateGameObject("DOOR_034_013",41.380001f,1.200000f,16.795313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1039",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		CreateShockDoor(myObj,0,0,2404);
		
		myObj= CreateGameObject("BLAST_DOOR_036_013",43.779999f,1.200000f,15.620000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1027",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)180.000000,(float)0.000000);
		CreateShockDoor(myObj,10,0,2400);
		
		myObj= CreateGameObject("SERVICE_ACCESS_DOOR_024_014",29.379999f,1.200000f,16.820000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1030",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)180.000000,(float)0.000000);
		CreateShockDoor(myObj,0,0,2401);
		
		myObj= CreateGameObject("NULL_TRIGGER_26_14_01_0300",31.780001f,1.593750f,17.379999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "",0,"",0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("SWITCH_27_14_01_0210",32.980000f,1.275000f,17.379999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0881",false);
		CreateSHOCKActivators(myObj,0);
		AddACTION_DO_NOTHING(myObj, "ML_41_PISTOL_00_00_01_0000");
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_29_14_01_0680",35.380001f,1.800000f,17.379999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 11,0,0,0,0,0);
		AddACTION_TIMER(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("CAMERA_30_14_01_0420",36.632813f,3.543750f,16.820000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("CHAIR_35_14_01_0378",42.632813f,1.200000f,17.470312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("HUMAN_CORPSE_36_14_01_0111",44.395313f,1.462500f,17.245312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0692",true);
		
		myObj= CreateGameObject("HUMAN_CORPSE_38_14_01_0281",46.180000f,1.575000f,17.379999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0672",true);
		
		myObj= CreateGameObject("BROKEN_GUN_38_14_01_0282",46.457813f,1.368750f,17.132813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0592",true);
		
		myObj= CreateGameObject("EMAIL_40_14_01_0318",48.220314f,1.293750f,17.732813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0281",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",13,105, 0);
		
		myObj= CreateGameObject("HUMAN_CORPSE_40_14_01_0283",48.257813f,1.556250f,17.282812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0632",true);
		
		myObj = new GameObject("HUMANOID_MUTANT_41_14_01_0286");
		pos = new Vector3(49.779999f, 1.593750f, 17.379999f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"439","Sprites/objects_1350_1541");
		
		myObj= CreateGameObject("LARGE_BUTTON_23_15_01_0289",28.232813f,1.912500f,18.020000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0905",false);
		CreateSHOCKActivators(myObj,7);
		AddACTION_LIGHTING(myObj);
		SetRotation(myObj,(float)-0.000000,(float)180.000000,(float)0.000000);
		
		myObj= CreateGameObject("FERN_28_15_01_0122",34.180000f,1.350000f,18.580000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0507",true);
		
		myObj= CreateGameObject("ENTRY_TRIGGER_30_15_01_0150",36.599998f,2.400000f,18.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1340",false);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_29_14_01_0680", 0,"",0,"",0,"",0);
		CreateEntry_Trigger(myObj, 6,1,0,0,0,0);
		CreateCollider(myObj,1.20f,4.800000f,1.20f);
		
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
		
		myObj= CreateGameObject("HUMAN_CORPSE_21_16_01_0118",25.780001f,0.356250f,19.780001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0672",true);
		
		myObj= CreateGameObject("SMALL_PLANT_27_16_01_0124",32.695313f,1.425000f,19.945313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0516",true);
		
		myObj= CreateGameObject("GRASS_29_16_01_0073",35.380001f,1.575000f,19.780001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0495",true);
		
		myObj= CreateGameObject("SIGN_30_16_01_0514",37.195313f,2.325000f,19.795313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0390",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",62,126, 0);
		
		myObj = new GameObject("HUMANOID_MUTANT_37_16_01_0285");
		pos = new Vector3(45.032814f, 1.593750f, 19.645313f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"439","Sprites/objects_1350_1541");
		
		myObj= CreateGameObject("DEBRIS_38_16_01_0197",46.270313f,1.500000f,19.682812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0604",true);
		
		myObj = new GameObject("HUMANOID_MUTANT_42_16_01_0287");
		pos = new Vector3(50.980000f, 1.593750f, 19.780001f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"439","Sprites/objects_1350_1541");
		
		myObj= CreateGameObject("NULL_TRIGGER_15_17_01_0578",18.580000f,2.400000f,20.980000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 0,0,0,0,0,0);
		AddACTION_DO_NOTHING(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("ECOLOGY_TRIGGER_16_17_01_0437",19.780001f,1.800000f,20.980000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1373",true);
		
		myObj= CreateGameObject("WORDS_16_17_01_0248",19.232813f,2.662500f,20.882813f);
		CreateWords(myObj, 28, 602, 4, 0);
		SetRotation(myObj,(float)-0.000000,(float)270.000000,(float)0.000000);
		
		myObj= CreateGameObject("WORDS_16_17_01_0249",19.219999f,2.418750f,21.145313f);
		CreateWords(myObj, 3, 606, 4, 0);
		SetRotation(myObj,(float)-0.000000,(float)270.000000,(float)0.000000);
		
		myObj= CreateGameObject("CAMERA_16_17_01_0415",20.395313f,3.243750f,20.582813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("NULL_TRIGGER_17_17_01_0288",20.980000f,1.800000f,20.980000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "",0,"",0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("ACCESS_PANEL_18_17_01_0577",22.795313f,1.950000f,21.267187f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0959",false);
		CreateSHOCKActivators(myObj,0);
		AddACTION_DO_NOTHING(myObj, "NULL_TRIGGER_19_19_01_0576");
		SetRotation(myObj,(float)-0.000000,(float)90.000000,(float)0.000000);
		
		myObj= CreateGameObject("MEDIPATCH__HEALING_AGENT_18_17_01_0137",21.895313f,1.537500f,20.807812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,66, 0);
		
		myObj= CreateGameObject("MEDIPATCH__HEALING_AGENT_22_17_01_0658",26.807812f,3.600000f,21.107813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,66, 0);
		
		myObj= CreateGameObject("MEDIPATCH__HEALING_AGENT_22_17_01_0657",26.920313f,3.600000f,21.332813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,66, 0);
		
		myObj= CreateGameObject("SHRUB_28_17_01_0081",34.180000f,1.781250f,20.980000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0492",true);
		
		myObj= CreateGameObject("EMAIL_29_17_01_0462",35.807812f,1.293750f,20.882813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0281",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",13,105, 0);
		
		myObj= CreateGameObject("GRASS_29_17_01_0080",35.380001f,1.575000f,20.980000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0495",true);
		
		myObj= CreateGameObject("SEVERED_HEAD_30_17_01_0156",36.970314f,1.425000f,20.920313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0734",true);
		
		myObj= CreateGameObject("HUMAN_CORPSE_30_17_01_0461",36.580002f,1.556250f,20.980000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0642",true);
		
		myObj= CreateGameObject("DH_07_STUNGUN_43_17_01_0382",51.857811f,1.368750f,20.995312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0043",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,14, 0);
		
		myObj= CreateGameObject("HUMAN_CORPSE_43_17_01_0381",52.180000f,1.556250f,20.980000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0632",true);
		
		myObj= CreateGameObject("HIDDEN_DOOR_046_017",56.395313f,1.200000f,20.980000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1141",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)90.000000,(float)0.000000);
		CreateShockDoor(myObj,0,0,2438);
		
		myObj= CreateGameObject("SV_TRANQ_DARTS_47_17_01_0568",56.957813f,1.293750f,20.770313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0058",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,19, 0);
		
		myObj= CreateGameObject("ML_TEFLON_COATED_ROUNDS_47_17_01_0670",57.182812f,1.293750f,21.295313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0052",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,17, 0);
		
		myObj= CreateGameObject("STORAGE_ROOM_DOOR_015_018",19.195313f,1.800000f,22.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1045",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)90.000000,(float)0.000000);
		CreateShockDoor(myObj,10,0,2406);
		
		myObj= CreateGameObject("HUMAN_BONES_17_18_01_0038",20.657812f,1.462500f,22.082813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0712",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,211, 0);
		
		myObj= CreateGameObject("ENTRY_TRIGGER_18_18_01_0573",22.200001f,2.400000f,22.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1340",false);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_17_12_01_0163", 0,"",0,"",0,"",0);
		CreateEntry_Trigger(myObj, 6,0,252,0,1,0);
		CreateCollider(myObj,1.20f,4.800000f,1.20f);
		
		myObj= CreateGameObject("NULL_TRIGGER_18_18_01_0112",22.180000f,0.600000f,22.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 9,0,0,0,0,0);
		AddACTION_MOVING_PLATFORM(myObj, 18, 18, 0, -4063, 1);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_18_18_01_0113",22.180000f,0.600000f,22.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 9,0,0,0,0,0);
		AddACTION_MOVING_PLATFORM(myObj, 18, 18, 8, -4063, 1);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("SV_23_DARTGUN_19_18_01_0336",23.357813f,0.225000f,22.495312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0004",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,1, 0);
		
		myObj= CreateGameObject("STAMINUP__STIMULANT_19_18_01_0335",23.207813f,0.150000f,21.895313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0200",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,63, 0);
		
		myObj= CreateGameObject("SWITCH_19_18_01_0126",23.357813f,0.787500f,22.795313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0881",false);
		CreateSHOCKActivators(myObj,12);
		AddACTION_CHOICE(myObj,"NULL_TRIGGER_18_18_01_0112", "NULL_TRIGGER_18_18_01_0113");
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("HUMAN_BONES_19_18_01_0061",23.379999f,0.262500f,22.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0712",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,211, 0);
		
		myObj= CreateGameObject("NULL_TRIGGER_20_18_01_0006",24.580000f,1.800000f,22.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_20_18_01_0036", 0,"DOOR_026_021", 0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_20_18_01_0036",24.580000f,1.800000f,22.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 4,0,0,0,0,0);
		AddACTION_SET_VARIABLE(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("ENERGY_CHARGE_STATION_22_18_01_0659",26.980000f,1.800000f,22.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0952",true);
		
		myObj= CreateGameObject("CRATE_23_18_01_0663",28.270313f,1.987500f,22.307812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1400",true);
		
		myObj= CreateGameObject("BRIDGE_24_18_01_0170",29.379999f,1.762500f,22.180000f);
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
		
		myObj= CreateGameObject("NULL_TRIGGER_44_18_01_0338",53.380001f,1.800000f,22.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "",0,"",0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("CRATE_12_19_01_0488",14.995313f,1.987500f,22.832813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1400",true);
		
		myObj= CreateGameObject("CRATE_12_19_01_0487",15.482813f,1.987500f,23.357813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1400",true);
		
		myObj= CreateGameObject("CRATE_12_19_01_0486",14.980000f,1.987500f,23.379999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1400",true);
		
		myObj= CreateGameObject("CRATE_14_19_01_0490",17.379999f,1.987500f,23.379999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1400",true);
		
		myObj= CreateGameObject("BONES_17_19_01_0103",21.370312f,1.368750f,23.170313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0715",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,212, 0);
		
		myObj= CreateGameObject("SEVERED_LIMB_17_19_01_0101",20.980000f,1.500000f,23.379999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0720",true);
		
		myObj= CreateGameObject("NULL_TRIGGER_19_19_01_0576",23.379999f,1.200000f,23.379999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,1,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_19_19_01_0575", 0,"NULL_TRIGGER_19_19_01_0574", 0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_19_19_01_0575",23.379999f,1.200000f,23.379999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 4,1,0,0,0,0);
		AddACTION_SET_VARIABLE(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_19_19_01_0574",23.379999f,1.200000f,23.379999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 7,1,0,0,0,0);
		AddACTION_LIGHTING(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("EMAIL_20_19_01_0485",24.257813f,0.693750f,23.357813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0281",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",13,105, 0);
		
		myObj= CreateGameObject("HUMAN_CORPSE_20_19_01_0484",24.895313f,0.956250f,23.432812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0632",true);
		
		myObj= CreateGameObject("ICON_20_19_01_0078",24.820313f,1.200000f,22.832813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0395",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",62,127, 0);
		
		myObj= CreateGameObject("KEYPAD_PANEL_20_19_01_0096",24.020000f,1.200000f,23.770313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0991",false);
		CreateSHOCKActivators(myObj,0);
		AddACTION_DO_NOTHING(myObj, "DOOR_020_020");
		SetRotation(myObj,(float)-0.000000,(float)270.000000,(float)0.000000);
		
		myObj = new GameObject("SERV_BOT_23_19_01_0135");
		pos = new Vector3(28.232813f, 0.993750f, 23.957813f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"450","Sprites/objects_1350_1574");
		
		myObj= CreateGameObject("BRIDGE_24_19_01_0143",29.379999f,1.762500f,23.379999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("SV_NEEDLE_DARTS_25_19_01_0191",30.595312f,0.693750f,23.582813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0055",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,18, 0);
		
		myObj= CreateGameObject("CONTROL_PEDESTAL_25_19_01_0131",30.020000f,0.637500f,23.545313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("SHRUBBERY_28_19_01_0121",34.420311f,1.781250f,23.282812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0529",true);
		
		myObj= CreateGameObject("GRASS_29_19_01_0074",35.245312f,1.575000f,23.245312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0495",true);
		
		myObj = new GameObject("CYBORG_DRONE_30_19_01_0352");
		pos = new Vector3(36.580002f, 1.650000f, 23.379999f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"460","Sprites/objects_1350_1604");
		
		myObj= CreateGameObject("CAMERA_34_19_01_0419",41.920311f,2.587500f,22.907812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("STORAGE_ROOM_DOOR_035_019",43.195313f,1.200000f,23.379999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1045",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)90.000000,(float)0.000000);
		CreateShockDoor(myObj,10,0,2406);
		
		myObj= CreateGameObject("CRATE_38_19_01_0690",46.180000f,1.575000f,23.379999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1402",true);
		
		myObj= CreateGameObject("MEDIPATCH__HEALING_AGENT_38_19_01_0412",46.045311f,1.350000f,22.982813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,66, 0);
		
		myObj = new GameObject("CYBORG_ASSASSIN_42_19_01_0347");
		pos = new Vector3(50.980000f, 1.593750f, 23.379999f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"462","Sprites/objects_1350_1610");
		
		myObj= CreateGameObject("WRAPPER_17_20_01_0136",20.620312f,1.312500f,24.820313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0570",true);
		
		myObj= CreateGameObject("ENTRY_TRIGGER_19_20_01_0713",23.400000f,2.400000f,24.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1340",false);
		AddACTION_SET_VARIABLE(myObj);
		CreateEntry_Trigger(myObj, 4,1,0,0,0,0);
		CreateCollider(myObj,1.20f,4.800000f,1.20f);
		
		myObj= CreateGameObject("ENTRY_TRIGGER_20_20_01_0502",24.600000f,2.400000f,24.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1340",false);
		AddACTION_EMAIL(myObj);
		CreateEntry_Trigger(myObj, 15,1,0,0,0,0);
		CreateCollider(myObj,1.20f,4.800000f,1.20f);
		
		myObj= CreateGameObject("DOOR_020_020",24.020000f,0.600000f,24.580000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1039",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)270.000000,(float)0.000000);
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
		
		myObj= CreateGameObject("DEAD_MUTANT_37_20_01_0692",44.980000f,2.700000f,24.580000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1178",true);
		
		myObj= CreateGameObject("ML_STANDARD_ROUNDS_37_20_01_0691",44.980000f,2.493750f,24.580000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0049",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,16, 0);
		
		myObj = new GameObject("HUMANOID_MUTANT_38_20_01_0219");
		pos = new Vector3(46.180000f, 1.593750f, 24.580000f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"439","Sprites/objects_1350_1541");
		
		myObj= CreateGameObject("BROKEN_CLOCK_38_20_01_0198",46.180000f,1.406250f,24.580000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0610",true);
		
		myObj= CreateGameObject("NULL_TRIGGER_41_20_01_0236",49.779999f,1.800000f,24.580000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 7,0,0,0,0,0);
		AddACTION_LIGHTING(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_46_20_01_0139",55.779999f,1.800000f,24.580000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 0,0,17,48,1,255);
		AddACTION_DO_NOTHING(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("BED_11_21_01_0169",14.020312f,1.481250f,25.907812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("NULL_TRIGGER_14_21_01_0452",17.379999f,1.800000f,25.780001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "",0,"",0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("DOOR_015_021",19.195313f,1.200000f,25.780001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1039",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)90.000000,(float)0.000000);
		CreateShockDoor(myObj,1,0,2404);
		
		myObj = new GameObject("SERV_BOT_20_21_01_0004");
		pos = new Vector3(24.557812f, 0.956250f, 25.219999f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"450","Sprites/objects_1350_1574");
		
		myObj= CreateGameObject("NULL_TRIGGER_20_21_01_0205",24.580000f,1.800000f,25.780001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_41_30_01_0208", 0,"NULL_TRIGGER_20_22_01_0141", 0,"NULL_TRIGGER_29_13_01_0211", 0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("CAMERA_21_21_01_0414",26.057812f,1.818750f,25.532812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("SCREEN_24_21_01_0661",29.995312f,2.625000f,25.795313f);
		CreateComputerScreen(myObj,81,4,0);
		SetRotation(myObj,(float)-0.000000,(float)90.000000,(float)0.000000);
		
		myObj= CreateGameObject("DOOR_026_021",31.780001f,0.600000f,26.395313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1039",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		CreateShockDoor(myObj,0,1,2404);
		
		myObj= CreateGameObject("SEVERED_LIMB_40_21_01_0107",48.295311f,1.350000f,26.020313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0720",true);
		
		myObj = new GameObject("HUMANOID_MUTANT_40_21_01_0293");
		pos = new Vector3(48.580002f, 1.443750f, 25.780001f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"439","Sprites/objects_1350_1541");
		
		myObj= CreateGameObject("HUMAN_BONES_41_21_01_0084",49.457813f,1.312500f,25.720312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0712",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,211, 0);
		
		myObj = new GameObject("HUMANOID_MUTANT_44_21_01_0294");
		pos = new Vector3(53.470314f, 1.593750f, 25.532812f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"439","Sprites/objects_1350_1541");
		
		myObj= CreateGameObject("SHODAN_TRIGGER_46_21_01_0483",55.779999f,1.800000f,25.780001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1376",true);
		
		myObj= CreateGameObject("HIDDEN_DOOR_046_021",56.395313f,1.200000f,25.780001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1141",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)90.000000,(float)0.000000);
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
		
		myObj= CreateGameObject("GROUP_ACCESS_CARD_1",13.780000f,1.331250f,26.980000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0788",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",5,233, 0);
		CreateKey(myObj, 0);
		
		myObj= CreateGameObject("EMAIL_11_22_01_0315",13.532812f,1.293750f,27.295313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0281",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",13,105, 0);
		
		myObj= CreateGameObject("SEVERED_HEAD_15_22_01_0458",18.557812f,3.225000f,26.770313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0724",true);
		
		myObj = new GameObject("HUMANOID_MUTANT_17_22_01_0195");
		pos = new Vector3(20.906250f, 1.593750f, 26.868750f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"439","Sprites/objects_1350_1541");
		
		myObj= CreateGameObject("SKULL_18_22_01_0102",21.932812f,1.312500f,26.882813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0718",true);
		
		myObj= CreateGameObject("SCREEN_20_22_01_0187",24.032812f,1.293750f,26.995312f);
		CreateComputerScreen(myObj,6,4,1);
		SetRotation(myObj,(float)-0.000000,(float)270.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_20_22_01_0141",24.580000f,1.800000f,26.980000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 7,0,0,0,0,0);
		AddACTION_LIGHTING(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_21_22_01_0062",25.780001f,1.800000f,26.980000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 11,0,0,0,0,0);
		AddACTION_TIMER(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_25_22_01_0696",30.580000f,1.200000f,26.980000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "DOOR_026_024", 0,"DOOR_026_021", 0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("BUTTON_26_22_01_0176",31.232813f,1.331250f,26.882813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0889",false);
		CreateSHOCKActivators(myObj,6);
		AddACTION_ACTIVATE(myObj, "DOOR_026_021", 0,"",0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)270.000000,(float)0.000000);
		
		myObj= CreateGameObject("EMAIL_33_22_01_0454",39.895313f,1.293750f,26.995312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0281",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",13,105, 0);
		
		myObj= CreateGameObject("HUMAN_CORPSE_33_22_01_0453",40.180000f,1.575000f,26.980000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0632",true);
		
		myObj= CreateGameObject("CHEMICAL_TANK_37_22_01_0684",45.032814f,1.593750f,26.957813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1413",true);
		
		myObj= CreateGameObject("CHEMICAL_TANK_38_22_01_0687",46.180000f,1.593750f,26.980000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1413",true);
		
		myObj = new GameObject("CYBORG_DRONE_38_22_01_0303");
		pos = new Vector3(45.632813f, 1.650000f, 27.595312f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"460","Sprites/objects_1350_1604");
		
		myObj= CreateGameObject("SKULL_43_22_01_0389",52.180000f,1.162500f,26.980000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0718",true);
		
		myObj= CreateGameObject("BED_11_23_01_0168",14.020312f,1.481250f,28.232813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj = new GameObject("SERV_BOT_12_23_01_0278");
		pos = new Vector3(14.980000f, 1.593750f, 28.180000f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"450","Sprites/objects_1350_1574");
		
		myObj= CreateGameObject("CART_13_23_01_0612",16.345312f,1.200000f,28.120312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("BULKHEAD_DOOR_017_023",20.980000f,1.200000f,27.620001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1120",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		CreateShockDoor(myObj,0,0,2431);
		
		myObj= CreateGameObject("BULKHEAD_DOOR_018_023",22.180000f,1.200000f,27.620001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1123",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		CreateShockDoor(myObj,0,0,2432);
		
		myObj= CreateGameObject("WORDS_29_23_01_0699",35.765625f,2.250000f,28.795313f);
		CreateWords(myObj, 102, 602, 4, 2);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("WORDS_30_23_01_0718",36.346874f,2.250000f,28.795313f);
		CreateWords(myObj, 103, 602, 4, 2);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("LEVEL_ENTRY_TRIGGER_31_23_01_0695",37.779999f,1.800000f,28.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1364",false);
		CreateNull_Trigger(myObj, 2,1,0,0,0,0);
		AddACTION_RESURRECTION(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("LARGE_BUTTON_35_23_01_0117",42.370312f,1.800000f,28.795313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0905",false);
		CreateSHOCKActivators(myObj,6);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_33_25_01_0354", 0,"",0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("BLAST_DOOR_035_023",43.195313f,1.200000f,28.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1027",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)90.000000,(float)0.000000);
		CreateShockDoor(myObj,0,0,2400);
		
		myObj= CreateGameObject("CHEMICAL_TANK_38_23_01_0685",46.180000f,1.593750f,28.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1413",true);
		
		myObj= CreateGameObject("HUMAN_CORPSE_40_23_01_0017",48.580002f,1.425000f,28.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0662",true);
		
		myObj= CreateGameObject("SKULL_41_23_01_0257",49.645313f,1.162500f,28.382813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0718",true);
		
		myObj = new GameObject("HUMANOID_MUTANT_45_23_01_0295");
		pos = new Vector3(54.580002f, 2.043750f, 28.180000f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"439","Sprites/objects_1350_1541");
		
		myObj= CreateGameObject("NULL_TRIGGER_10_24_01_0353",12.580000f,2.400000f,29.379999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "",0,"",0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("GRAFFITI_17_24_01_0044",20.845312f,2.718750f,28.820000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0399",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",62,128, 0);
		
		myObj= CreateGameObject("BONES_17_24_01_0043",20.695313f,1.406250f,29.470312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0715",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,212, 0);
		
		myObj= CreateGameObject("DOOR_026_024",31.780001f,0.600000f,28.820000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1039",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)180.000000,(float)0.000000);
		CreateShockDoor(myObj,1,0,2404);
		
		myObj= CreateGameObject("ENTRY_TRIGGER_26_24_01_0146",31.799999f,2.400000f,29.400000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1340",false);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_29_24_01_0066", 0,"",0,"",0,"",0);
		CreateEntry_Trigger(myObj, 6,0,0,0,0,0);
		CreateCollider(myObj,1.20f,4.800000f,1.20f);
		
		myObj= CreateGameObject("MEDIPATCH__HEALING_AGENT_28_24_01_0133",33.820313f,1.800000f,29.395313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,66, 0);
		
		myObj= CreateGameObject("NULL_TRIGGER_29_24_01_0209",35.380001f,2.250000f,29.379999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_17_33_01_0601", 0,"NULL_TRIGGER_12_45_01_0602", 0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_29_24_01_0599",35.380001f,2.250000f,29.379999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_29_13_01_0211", 0,"NULL_TRIGGER_17_12_01_0337", 0,"NULL_TRIGGER_41_20_01_0236", 0,"NULL_TRIGGER_29_24_01_0209", 0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_29_24_01_0064",35.380001f,2.250000f,29.379999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_27_25_01_0151", 0,"NULL_TRIGGER_26_27_01_0252", 0,"NULL_TRIGGER_41_30_01_0208", 0,"NULL_TRIGGER_29_24_01_0599", 0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_29_24_01_0066",35.380001f,2.250000f,29.379999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 11,0,0,0,0,0);
		AddACTION_TIMER(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("LEVEL_ENTRY_TRIGGER_30_24_01_0037",36.580002f,2.250000f,29.379999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1364",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_29_24_01_0066", 0,"",0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("CHEMICAL_TANK_37_24_01_0686",44.980000f,1.593750f,29.379999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1413",true);
		
		myObj= CreateGameObject("EMAIL_38_24_01_0460",46.157814f,1.293750f,29.995312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0281",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",13,105, 0);
		
		myObj= CreateGameObject("SCREEN_40_24_01_0128",48.020000f,1.631250f,29.395313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		CreateComputerScreen(myObj,0,100,1);
		SetRotation(myObj,(float)-0.000000,(float)270.000000,(float)0.000000);
		
		myObj = new GameObject("HUMANOID_MUTANT_07_25_01_0132");
		pos = new Vector3(8.980000f, 0.393750f, 30.580000f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"439","Sprites/objects_1350_1541");
		
		myObj= CreateGameObject("CHAIR_11_25_01_0620",13.780000f,1.800000f,30.580000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("BLOOD_STAIN_12_25_01_0472",14.770312f,1.800000f,30.632813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0846",true);
		
		myObj= CreateGameObject("SEVERED_HEAD_12_25_01_0470",14.980000f,2.025000f,30.580000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0724",true);
		
		myObj= CreateGameObject("BERSERK_COMBAT_BOOSTER_13_25_01_0173",16.345312f,2.400000f,30.857813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0205",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,65, 0);
		
		myObj= CreateGameObject("SCOPE_13_25_01_0621",15.820313f,2.250000f,30.895313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("SCREEN_13_25_01_0617",15.970312f,2.625000f,30.020000f);
		CreateComputerScreen(myObj,85,4,0);
		SetRotation(myObj,(float)-0.000000,(float)180.000000,(float)0.000000);
		
		myObj= CreateGameObject("STAMINUP__STIMULANT_13_25_01_0172",16.180000f,2.400000f,30.580000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0200",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,63, 0);
		
		myObj= CreateGameObject("SCREEN_14_25_01_0618",17.432812f,2.625000f,30.020000f);
		CreateComputerScreen(myObj,81,4,0);
		SetRotation(myObj,(float)-0.000000,(float)180.000000,(float)0.000000);
		
		myObj= CreateGameObject("TESTTUBE_RACK_14_25_01_0615",17.507813f,2.250000f,30.707813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("HUMAN_CORPSE_20_25_01_0271",24.580000f,0.956250f,30.580000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0632",true);
		
		myObj= CreateGameObject("ICON_21_25_01_0431",25.219999f,2.325000f,30.782812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0395",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",62,127, 0);
		
		myObj= CreateGameObject("NULL_TRIGGER_27_25_01_0151",32.980000f,1.200000f,30.580000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 7,0,0,0,0,0);
		AddACTION_LIGHTING(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_32_25_01_0054",38.980000f,1.800000f,30.580000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 9,0,0,0,0,0);
		AddACTION_MOVING_PLATFORM(myObj, 32, 25, 256, 24, 2);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_32_25_01_0109",38.980000f,1.800000f,30.580000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 9,0,0,0,0,0);
		AddACTION_MOVING_PLATFORM(myObj, 32, 25, 256, 7, 2);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_33_25_01_0354",40.180000f,1.800000f,30.580000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 12,0,0,0,0,0);
		AddACTION_CHOICE(myObj,"NULL_TRIGGER_33_25_01_0012", "NULL_TRIGGER_33_25_01_0032");
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_33_25_01_0034",40.180000f,1.800000f,30.580000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 9,0,0,0,0,0);
		AddACTION_MOVING_PLATFORM(myObj, 33, 25, 256, 7, 2);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_33_25_01_0012",40.180000f,1.800000f,30.580000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_32_25_01_0054", 0,"NULL_TRIGGER_33_25_01_0031", 0,"NULL_TRIGGER_34_25_01_0033", 0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_33_25_01_0032",40.180000f,1.800000f,30.580000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_32_25_01_0109", 0,"NULL_TRIGGER_33_25_01_0034", 0,"NULL_TRIGGER_34_25_01_0053", 0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_33_25_01_0031",40.180000f,1.800000f,30.580000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 9,0,0,0,0,0);
		AddACTION_MOVING_PLATFORM(myObj, 33, 25, 256, 24, 2);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_34_25_01_0033",41.380001f,1.800000f,30.580000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 9,0,0,0,0,0);
		AddACTION_MOVING_PLATFORM(myObj, 34, 25, 256, 24, 2);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_34_25_01_0053",41.380001f,1.800000f,30.580000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 9,0,0,0,0,0);
		AddACTION_MOVING_PLATFORM(myObj, 34, 25, 256, 7, 2);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("HUMAN_CORPSE_36_25_01_0459",43.779999f,1.575000f,30.580000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0672",true);
		
		myObj= CreateGameObject("STAMINUP__STIMULANT_38_25_01_0305",46.307812f,1.350000f,30.632813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0200",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,63, 0);
		
		myObj= CreateGameObject("MEDIPATCH__HEALING_AGENT_38_25_01_0304",45.857811f,1.350000f,30.145313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,66, 0);
		
		myObj= CreateGameObject("SEVERED_LIMB_38_25_01_0457",45.970314f,1.500000f,30.595312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0720",true);
		
		myObj= CreateGameObject("HUMAN_CORPSE_38_25_01_0455",46.180000f,1.556250f,30.580000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0642",true);
		
		myObj= CreateGameObject("SPARQ_BEAM_40_25_01_0204",48.407814f,1.143750f,30.632813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0034",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,11, 0);
		
		myObj= CreateGameObject("SKULL_41_25_01_0258",49.532814f,1.162500f,30.745312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0718",true);
		
		myObj= CreateGameObject("WORDS_46_25_01_0239",55.220001f,3.018750f,30.670313f);
		CreateWords(myObj, 18, 606, 4, 0);
		SetRotation(myObj,(float)-0.000000,(float)270.000000,(float)0.000000);
		
		myObj= CreateGameObject("ENTRY_TRIGGER_46_25_01_0606",55.799999f,2.400000f,30.600000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1340",false);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_47_25_01_0607", 0,"",0,"",0,"",0);
		CreateEntry_Trigger(myObj, 6,1,0,0,0,0);
		CreateCollider(myObj,1.20f,4.800000f,1.20f);
		
		myObj= CreateGameObject("NULL_TRIGGER_47_25_01_0607",56.980000f,1.800000f,30.580000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 11,0,0,0,0,0);
		AddACTION_TIMER(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("MEDIPATCH__HEALING_AGENT_08_26_01_0225",9.857813f,0.150000f,32.057812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,66, 0);
		
		myObj= CreateGameObject("HUMAN_CORPSE_08_26_01_0224",10.180000f,0.356250f,31.780001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0642",true);
		
		myObj = new GameObject("HUMANOID_MUTANT_09_26_01_0188");
		pos = new Vector3(11.380000f, 0.393750f, 31.780001f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"439","Sprites/objects_1350_1541");
		
		myObj= CreateGameObject("SCOPE_11_26_01_0622",13.382813f,2.250000f,32.057812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("SENSAROUND_MULTI_VIEW_UNIT_11_26_01_0179",13.780000f,2.343750f,31.780001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0227",true);
		
		myObj = new GameObject("HUMANOID_MUTANT_12_26_01_0040");
		pos = new Vector3(14.980000f, 2.193750f, 31.780001f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"439","Sprites/objects_1350_1541");
		
		myObj= CreateGameObject("DOOR_015_026",19.195313f,1.200000f,31.780001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1039",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)90.000000,(float)0.000000);
		CreateShockDoor(myObj,1,0,2404);
		
		myObj = new GameObject("SERV_BOT_21_26_01_0098");
		pos = new Vector3(25.219999f, 0.956250f, 31.532812f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"450","Sprites/objects_1350_1574");
		
		myObj= CreateGameObject("SURGERY_MACHINE_26_26_01_0613",31.780001f,0.600000f,31.780001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("ENERGY_CHARGE_STATION_28_26_01_0411",34.180000f,1.293750f,31.780001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0952",true);
		
		myObj= CreateGameObject("WORDS_31_26_01_0581",37.570313f,2.100000f,31.219999f);
		CreateWords(myObj, 19, 606, 4, 0);
		SetRotation(myObj,(float)-0.000000,(float)180.000000,(float)0.000000);
		
		myObj= CreateGameObject("HUMAN_BONES_32_26_01_0015",39.145313f,1.462500f,31.495312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0712",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,211, 0);
		
		myObj= CreateGameObject("SKULL_32_26_01_0164",38.920311f,1.312500f,31.607813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0718",true);
		
		myObj= CreateGameObject("LARGE_BUTTON_34_26_01_0536",41.995312f,2.006250f,31.795313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0905",false);
		CreateSHOCKActivators(myObj,6);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_33_25_01_0354", 0,"",0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)90.000000,(float)0.000000);
		
		myObj= CreateGameObject("SKELETON_39_26_01_0388",47.380001f,1.556250f,31.780001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0702",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,210, 0);
		
		myObj= CreateGameObject("CRATE_42_26_01_0534",51.182812f,1.537500f,31.982813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1400",true);
		
		myObj= CreateGameObject("BLAST_DOOR_046_026",55.779999f,2.100000f,31.219999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1027",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)180.000000,(float)0.000000);
		CreateShockDoor(myObj,0,0,2400);
		
		myObj= CreateGameObject("SWITCH_55_26_01_0605",66.580002f,1.275000f,31.780001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0881",false);
		CreateSHOCKActivators(myObj,0);
		AddACTION_DO_NOTHING(myObj, "ML_41_PISTOL_00_00_01_0000");
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("HUMAN_CORPSE_11_27_01_0473",13.780000f,2.175000f,32.980000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0642",true);
		
		myObj= CreateGameObject("EMAIL_12_27_01_0474",14.420000f,1.893750f,32.732811f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0281",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",13,105, 0);
		
		myObj= CreateGameObject("CAMERA_20_27_01_0413",24.020000f,2.193750f,33.595314f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("WORDS_23_27_01_0698",28.420313f,2.118750f,33.595314f);
		CreateWords(myObj, 89, 606, 4, 0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("WORDS_23_27_01_0697",28.345312f,1.781250f,33.595314f);
		CreateWords(myObj, 90, 606, 4, 0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_26_27_01_0252",31.780001f,1.200000f,32.980000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 7,0,0,0,0,0);
		AddACTION_LIGHTING(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("CRITTER_AI_HINT_28_27_01_0311",34.180000f,1.593750f,32.980000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1361",true);
		
		myObj= CreateGameObject("WRAPPER_33_27_01_0100",40.180000f,1.312500f,32.980000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0570",true);
		
		myObj= CreateGameObject("SCREEN_35_27_01_0177",42.670311f,1.912500f,32.419998f);
		CreateComputerScreen(myObj,8,4,0);
		SetRotation(myObj,(float)-0.000000,(float)180.000000,(float)0.000000);
		
		myObj= CreateGameObject("SCREEN_35_27_01_0178",42.670311f,2.887500f,32.419998f);
		CreateComputerScreen(myObj,55,4,0);
		SetRotation(myObj,(float)-0.000000,(float)180.000000,(float)0.000000);
		
		myObj= CreateGameObject("CRITTER_AI_HINT_36_27_01_0310",43.779999f,1.593750f,32.980000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1361",true);
		
		myObj = new GameObject("CYBORG_DRONE_37_27_01_0251");
		pos = new Vector3(44.980000f, 1.650000f, 32.980000f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"460","Sprites/objects_1350_1604");
		
		myObj= CreateGameObject("REPULSOR_43_27_01_0366",52.180000f,1.050000f,32.980000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1370",false);
		
		myObj= CreateGameObject("SIGHT_VISION_ENHANCEMENT_49_27_01_0394",59.695313f,3.750000f,33.070313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0203",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,64, 0);
		
		myObj= CreateGameObject("FIRST_AID_KIT_50_27_01_0395",60.295311f,3.768750f,33.032814f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0750",true);
		
		myObj= CreateGameObject("HIDDEN_DOOR_015_028",19.195313f,1.800000f,34.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1141",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)90.000000,(float)0.000000);
		CreateShockDoor(myObj,0,0,2438);
		
		myObj= CreateGameObject("FRAGMENTATION_GRENADE_15_28_01_0674",18.580000f,1.950000f,34.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0177",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,55, 0);
		
		myObj= CreateGameObject("FRAGMENTATION_GRENADE_15_28_01_0673",18.370312f,1.950000f,33.857811f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0177",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,55, 0);
		
		myObj= CreateGameObject("SWITCH_20_28_01_0093",24.580000f,1.275000f,34.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0881",false);
		CreateSHOCKActivators(myObj,0);
		AddACTION_DO_NOTHING(myObj, "ML_41_PISTOL_00_00_01_0000");
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_24_28_01_0129",29.379999f,1.800000f,34.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,1,0,0,0);
		AddACTION_ACTIVATE(myObj, "",0,"",0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_26_28_01_0152",31.780001f,1.800000f,34.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,1,0,0,0);
		AddACTION_ACTIVATE(myObj, "",0,"",0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("WORDS_27_28_01_0059",32.419998f,2.043750f,34.157814f);
		CreateWords(myObj, 20, 606, 4, 0);
		SetRotation(myObj,(float)-0.000000,(float)270.000000,(float)0.000000);
		
		myObj= CreateGameObject("EXPLOSION_RESIDUE_27_28_01_0008",32.419998f,2.531250f,34.270313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0840",true);
		
		myObj= CreateGameObject("NULL_TRIGGER_30_28_01_0200",36.580002f,0.600000f,34.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 9,0,0,0,0,0);
		AddACTION_MOVING_PLATFORM(myObj, 30, 28, 0, -4063, 1);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_30_28_01_0027",36.580002f,0.600000f,34.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 9,0,0,0,0,0);
		AddACTION_MOVING_PLATFORM(myObj, 30, 28, 8, -4063, 1);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("ENTRY_TRIGGER_30_28_01_0158",36.599998f,2.400000f,34.200001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1340",false);
		AddACTION_CHOICE(myObj,"NULL_TRIGGER_30_28_01_0200", "NULL_TRIGGER_30_28_01_0027");
		CreateEntry_Trigger(myObj, 12,0,0,0,0,0);
		CreateCollider(myObj,1.20f,4.800000f,1.20f);
		
		myObj= CreateGameObject("HIDDEN_DOOR_037_028",45.595314f,1.200000f,34.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1141",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)90.000000,(float)0.000000);
		CreateShockDoor(myObj,0,0,2438);
		
		myObj = new GameObject("HUMANOID_MUTANT_45_28_01_0297");
		pos = new Vector3(54.580002f, 2.493750f, 34.180000f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"439","Sprites/objects_1350_1541");
		
		myObj= CreateGameObject("NULL_TRIGGER_46_28_01_0114",55.779999f,2.700000f,34.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_46_28_01_0298", 0,"NULL_TRIGGER_46_28_01_0299", 0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_46_28_01_0299",55.779999f,2.700000f,34.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 24,0,0,0,0,0);
		AddACTION_CHANGE_TYPE(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_46_28_01_0298",55.779999f,2.700000f,34.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 24,0,0,0,0,0);
		AddACTION_CHANGE_TYPE(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("ACCESS_PANEL_47_28_01_0259",56.732811f,2.812500f,34.270313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0974",false);
		CreateSHOCKActivators(myObj,0);
		AddACTION_DO_NOTHING(myObj, "NULL_TRIGGER_46_28_01_0114");
		SetRotation(myObj,(float)-315.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("BEVERAGE_CONTAINER_49_28_01_0393",59.545311f,3.693750f,33.895313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0568",true);
		
		myObj= CreateGameObject("BEVERAGE_CONTAINER_49_28_01_0392",59.132813f,3.693750f,34.345314f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0568",true);
		
		myObj= CreateGameObject("STORAGE_ROOM_DOOR_050_028",61.195313f,3.600000f,34.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1045",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)90.000000,(float)0.000000);
		CreateShockDoor(myObj,0,0,2406);
		
		myObj= CreateGameObject("STORAGE_ROOM_DOOR_011_029",13.220000f,1.200000f,35.380001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1045",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)270.000000,(float)0.000000);
		CreateShockDoor(myObj,0,1,2406);
		
		myObj= CreateGameObject("EMAIL_12_29_01_0399",15.257813f,1.293750f,35.095314f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0281",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",13,105, 0);
		
		myObj= CreateGameObject("SEVERED_LIMB_13_29_01_0491",16.345312f,1.500000f,35.620312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0720",true);
		
		myObj= CreateGameObject("SCREEN_28_29_01_0185",34.195313f,3.337500f,35.995312f);
		CreateComputerScreen(myObj,91,4,1);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("LEVER_30_29_01_0432",36.032814f,0.600000f,35.470314f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0897",false);
		CreateSHOCKActivators(myObj,6);
		AddACTION_ACTIVATE(myObj, "ENTRY_TRIGGER_30_28_01_0158", 0,"",0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)270.000000,(float)0.000000);
		
		myObj= CreateGameObject("CONTROL_PEDESTAL_31_29_01_0442",37.779999f,0.000000f,35.380001f);
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
		
		myObj= CreateGameObject("NULL_TRIGGER_34_29_01_0683",41.380001f,0.600000f,35.380001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 0,0,0,0,0,0);
		AddACTION_DO_NOTHING(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NITROPACK_39_29_01_0667",47.095314f,1.350000f,35.657814f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0192",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,60, 0);
		
		myObj= CreateGameObject("ELEPHANT_JORP_46_29_01_0290",55.779999f,2.062500f,35.380001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0563",true);
		
		myObj= CreateGameObject("CRATE_49_29_01_0646",59.545311f,0.337500f,35.432812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1400",true);
		
		myObj= CreateGameObject("EMAIL_51_29_01_0465",61.779999f,3.693750f,35.380001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0281",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",13,105, 0);
		
		myObj= CreateGameObject("HUMAN_CORPSE_52_29_01_0511",62.980000f,3.975000f,35.380001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0672",true);
		
		myObj= CreateGameObject("SB_20_MAGPULSE_10_30_01_0171",12.407812f,1.500000f,37.082813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0022",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,7, 0);
		
		myObj= CreateGameObject("MEDIPATCH__HEALING_AGENT_10_30_01_0223",12.580000f,1.350000f,36.580002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,66, 0);
		
		myObj= CreateGameObject("LEVEL_ENTRY_TRIGGER_11_30_01_0653",13.780000f,1.800000f,36.580002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1364",false);
		CreateNull_Trigger(myObj, 6,0,30,0,1,0);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_11_31_01_0654", 0,"NULL_TRIGGER_11_31_01_0655", 0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("HUMAN_CORPSE_12_30_01_0014",14.957812f,1.575000f,36.632813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0672",true);
		
		myObj= CreateGameObject("DOOR_015_030",18.020000f,1.200000f,36.580002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1039",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)270.000000,(float)0.000000);
		CreateShockDoor(myObj,0,0,2404);
		
		myObj = new GameObject("HUMANOID_MUTANT_16_30_01_0082");
		pos = new Vector3(19.780001f, 1.593750f, 36.580002f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"439","Sprites/objects_1350_1541");
		
		myObj = new GameObject("HUMANOID_MUTANT_19_30_01_0194");
		pos = new Vector3(23.981251f, 1.593750f, 36.421875f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"439","Sprites/objects_1350_1541");
		
		myObj= CreateGameObject("SCREEN_23_30_01_0245",28.195313f,2.437500f,36.020000f);
		CreateComputerScreen(myObj,8,4,1);
		SetRotation(myObj,(float)-0.000000,(float)180.000000,(float)0.000000);
		
		myObj= CreateGameObject("BUTTON_27_30_01_0700",32.995312f,2.250000f,37.195313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0885",false);
		CreateSHOCKActivators(myObj,7);
		AddACTION_LIGHTING(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("SCREEN_31_30_01_0448",37.795311f,2.437500f,36.020000f);
		CreateSurveillanceScreen(myObj,"NULL_TRIGGER_31_36_01_0584");
		SetRotation(myObj,(float)-0.000000,(float)180.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_31_30_01_0708",37.779999f,0.600000f,36.580002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 22,0,0,0,0,0);
		AddACTION_MESSAGE(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("REPULSOR_31_30_01_0668",37.779999f,0.600000f,36.580002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1370",false);
		
		myObj= CreateGameObject("SCREEN_31_30_01_0449",37.220001f,2.437500f,36.595314f);
		CreateComputerScreen(myObj,81,4,1);
		SetRotation(myObj,(float)-0.000000,(float)270.000000,(float)0.000000);
		
		myObj= CreateGameObject("CAMERA_31_30_01_0348",37.420311f,1.631250f,36.182812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("BUTTON_32_30_01_0529",38.545311f,3.187500f,36.020000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0889",false);
		CreateSHOCKActivators(myObj,19);
		AddACTION_CHANGE_STATE(myObj);
		SetRotation(myObj,(float)-0.000000,(float)180.000000,(float)0.000000);
		
		myObj= CreateGameObject("ACCESS_PANEL_32_30_01_0682",38.545311f,2.887500f,36.020000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0964",false);
		CreateSHOCKActivators(myObj,0);
		AddACTION_DO_NOTHING(myObj, "FORCE_DOOR_031_038");
		SetRotation(myObj,(float)-0.000000,(float)180.000000,(float)0.000000);
		
		myObj= CreateGameObject("CAMERA_32_30_01_0351",39.482811f,1.631250f,36.145313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("MEDIPATCH__HEALING_AGENT_33_30_01_0499",39.932812f,0.150000f,36.932812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,66, 0);
		
		myObj = new GameObject("CYBORG_DRONE_33_30_01_0346");
		pos = new Vector3(40.180000f, 0.450000f, 36.580002f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"460","Sprites/objects_1350_1604");
		
		myObj= CreateGameObject("CRITTER_AI_HINT_36_30_01_0309",43.779999f,1.593750f,36.580002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1361",true);
		
		myObj= CreateGameObject("SCREEN_38_30_01_0433",46.795311f,2.381250f,36.557812f);
		CreateComputerScreen(myObj,79,4,1);
		SetRotation(myObj,(float)-0.000000,(float)90.000000,(float)0.000000);
		
		myObj= CreateGameObject("CAMERA_38_30_01_0418",46.495312f,2.625000f,36.257813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("LARGE_BUTTON_38_30_01_0110",46.795311f,1.781250f,36.857811f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0905",false);
		CreateSHOCKActivators(myObj,6);
		AddACTION_ACTIVATE(myObj, "ENTRY_TRIGGER_39_31_01_0714", 0,"",0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)90.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_39_30_01_0207",47.380001f,2.400000f,36.580002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,1,0,0,0);
		AddACTION_ACTIVATE(myObj, "",0,"",0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_41_30_01_0208",49.779999f,1.800000f,36.580002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 7,0,0,0,0,0);
		AddACTION_LIGHTING(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("ELEPHANT_JORP_46_30_01_0292",55.779999f,2.062500f,36.580002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0563",true);
		
		myObj= CreateGameObject("BATTERY_PACK_50_30_01_0405",60.580002f,1.762500f,36.580002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0756",true);
		
		myObj= CreateGameObject("STAMINUP__STIMULANT_10_31_01_0222",12.580000f,1.350000f,37.779999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0200",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,63, 0);
		
		myObj= CreateGameObject("NULL_TRIGGER_11_31_01_0655",13.780000f,1.800000f,37.779999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "STORAGE_ROOM_DOOR_011_032", 0,"",0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_11_31_01_0654",13.780000f,1.800000f,37.779999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "STORAGE_ROOM_DOOR_011_029", 0,"",0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj = new GameObject("HUMANOID_MUTANT_12_31_01_0142");
		pos = new Vector3(14.980000f, 1.593750f, 37.779999f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"439","Sprites/objects_1350_1541");
		
		myObj= CreateGameObject("BUTTON_17_31_01_0701",20.995312f,2.006250f,38.395313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0885",false);
		CreateSHOCKActivators(myObj,7);
		AddACTION_LIGHTING(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("SCREEN_17_31_01_0079",20.995312f,3.112500f,37.795311f);
		CreateComputerScreen(myObj,40,4,0);
		SetRotation(myObj,(float)-43.593750,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("LUMP_OF_CLOTHES_17_31_01_0104",20.980000f,1.443750f,37.779999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0585",true);
		
		myObj= CreateGameObject("NULL_TRIGGER_19_31_01_0600",23.379999f,1.800000f,37.779999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "",0,"",0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj = new GameObject("HUMANOID_MUTANT_23_31_01_0244");
		pos = new Vector3(28.082813f, 0.393750f, 37.982811f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"439","Sprites/objects_1350_1541");
		
		
		myObj= CreateGameObject("SCREEN_28_31_01_0186",34.195313f,3.318750f,37.220001f);
		CreateComputerScreen(myObj,0,4,0);
		SetRotation(myObj,(float)-0.000000,(float)180.000000,(float)0.000000);
		
		myObj= CreateGameObject("CONTROL_PEDESTAL_30_31_01_0440",36.580002f,0.000000f,37.779999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj = new GameObject("CYBORG_DRONE_30_31_01_0345");
		pos = new Vector3(37.157814f, 0.450000f, 37.220001f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"460","Sprites/objects_1350_1604");
		
		myObj= CreateGameObject("CAMERA_31_31_01_0349",37.345314f,1.631250f,38.245312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("SCREEN_32_31_01_0446",38.995312f,2.437500f,38.395313f);
		CreateSurveillanceScreen(myObj,"NULL_TRIGGER_41_49_01_0583");
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("SCREEN_32_31_01_0447",39.595314f,2.437500f,37.795311f);
		CreateComputerScreen(myObj,89,4,1);
		SetRotation(myObj,(float)-0.000000,(float)90.000000,(float)0.000000);
		
		myObj= CreateGameObject("CAMERA_32_31_01_0350",39.520313f,1.631250f,38.282814f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("BUTTON_33_31_01_0662",40.795311f,0.150000f,37.832813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0889",false);
		CreateSHOCKActivators(myObj,19);
		AddACTION_CHANGE_STATE(myObj);
		SetRotation(myObj,(float)-0.000000,(float)90.000000,(float)0.000000);
		
		myObj= CreateGameObject("CONTROL_PEDESTAL_33_31_01_0582",40.180000f,0.000000f,37.779999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj = new GameObject("HOPPER_34_31_01_0307");
		pos = new Vector3(41.957813f, 2.193750f, 37.757813f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"453","Sprites/objects_1350_1583");
		
		myObj= CreateGameObject("ENTRY_TRIGGER_39_31_01_0714",47.400002f,2.400000f,37.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1340",false);
		AddACTION_CHOICE(myObj,"NULL_TRIGGER_39_31_01_0215", "NULL_TRIGGER_39_31_01_0214");
		CreateEntry_Trigger(myObj, 12,0,0,0,0,0);
		CreateCollider(myObj,1.20f,4.800000f,1.20f);
		
		myObj= CreateGameObject("NULL_TRIGGER_39_31_01_0215",47.380001f,1.800000f,37.779999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 9,0,0,0,0,0);
		AddACTION_MOVING_PLATFORM(myObj, 39, 31, 8, -4063, 1);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_39_31_01_0214",47.380001f,1.800000f,37.779999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 9,0,0,0,0,0);
		AddACTION_MOVING_PLATFORM(myObj, 39, 31, 24, -4063, 1);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("DOOR_041_031",49.220001f,3.600000f,37.779999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1039",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)270.000000,(float)0.000000);
		CreateShockDoor(myObj,0,1,2404);
		
		myObj = new GameObject("HUMANOID_MUTANT_45_31_01_0296");
		pos = new Vector3(54.580002f, 2.793750f, 37.779999f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"439","Sprites/objects_1350_1541");
		
		myObj= CreateGameObject("CRATE_47_31_01_0694",57.107811f,2.587500f,38.132813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1400",true);
		
		myObj= CreateGameObject("HUMAN_CORPSE_53_31_01_0510",64.180000f,3.956250f,37.779999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0672",true);
		
		myObj= CreateGameObject("STORAGE_ROOM_DOOR_011_032",13.220000f,1.200000f,38.980000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1045",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)270.000000,(float)0.000000);
		CreateShockDoor(myObj,0,1,2406);
		
		myObj= CreateGameObject("SCREEN_18_32_01_0067",22.007813f,2.925000f,38.995312f);
		CreateComputerScreen(myObj,50,4,0);
		SetRotation(myObj,(float)-43.593750,(float)270.000000,(float)0.000000);
		
		myObj= CreateGameObject("SIGHT_VISION_ENHANCEMENT_22_32_01_0325",27.595312f,0.150000f,39.257813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0203",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,64, 0);
		
		myObj= CreateGameObject("SIGHT_VISION_ENHANCEMENT_22_32_01_0324",27.445313f,0.150000f,39.107811f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0203",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,64, 0);
		
		myObj= CreateGameObject("SV_23_DARTGUN_23_32_01_0242",28.180000f,0.225000f,38.980000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0004",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,1, 0);
		
		myObj= CreateGameObject("FRAGMENTATION_GRENADE_23_32_01_0120",27.970312f,0.112500f,39.407814f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0177",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,55, 0);
		
		myObj = new GameObject("CYBORG_DRONE_29_32_01_0580");
		pos = new Vector3(35.380001f, 2.250000f, 38.980000f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"460","Sprites/objects_1350_1604");
		
		myObj= CreateGameObject("CONTROL_PEDESTAL_32_32_01_0439",38.980000f,0.000000f,38.980000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("WORDS_38_32_01_0496",46.795311f,1.800000f,38.995312f);
		CreateWords(myObj, 18, 606, 4, 0);
		SetRotation(myObj,(float)-0.000000,(float)90.000000,(float)0.000000);
		
		myObj= CreateGameObject("SCREEN_38_32_01_0434",46.795311f,2.381250f,39.032814f);
		CreateComputerScreen(myObj,43,4,43);
		SetRotation(myObj,(float)-0.000000,(float)90.000000,(float)0.000000);
		
		myObj= CreateGameObject("CAMERA_38_32_01_0417",46.532814f,2.625000f,39.332813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("BROKEN_LEVER_40_32_01_0494",49.195313f,4.331250f,38.507813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0618",true);
		
		myObj= CreateGameObject("LARGE_BUTTON_40_32_01_0159",48.020000f,4.200000f,38.732811f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0905",false);
		CreateSHOCKActivators(myObj,6);
		AddACTION_ACTIVATE(myObj, "ENTRY_TRIGGER_39_31_01_0714", 0,"",0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)270.000000,(float)0.000000);
		
		myObj= CreateGameObject("BRIDGE_44_32_01_0364",53.380001f,2.343750f,38.980000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("HIDDEN_DOOR_015_033",19.195313f,1.200000f,40.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1141",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)90.000000,(float)0.000000);
		CreateShockDoor(myObj,0,0,2438);
		
		myObj= CreateGameObject("MEDIPATCH__HEALING_AGENT_15_33_01_0676",18.557812f,1.350000f,39.857811f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,66, 0);
		
		myObj= CreateGameObject("MEDIPATCH__HEALING_AGENT_15_33_01_0675",18.820313f,1.350000f,40.532814f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,66, 0);
		
		myObj= CreateGameObject("NULL_TRIGGER_17_33_01_0601",20.980000f,1.800000f,40.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 7,0,0,0,0,0);
		AddACTION_LIGHTING(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("DOOR_019_033",23.995312f,1.200000f,40.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1039",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)90.000000,(float)0.000000);
		CreateShockDoor(myObj,0,0,2404);
		
		myObj= CreateGameObject("WRAPPER_19_33_01_0105",23.695313f,1.312500f,40.045311f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0570",true);
		
		myObj= CreateGameObject("NULL_TRIGGER_37_33_01_0206",44.980000f,1.800000f,40.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,1,0,0,0);
		AddACTION_ACTIVATE(myObj, "",0,"",0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("SV_NEEDLE_DARTS_47_33_01_0377",56.582813f,2.493750f,40.532814f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0055",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,18, 0);
		
		myObj = new GameObject("CYBORG_DRONE_20_34_01_0313");
		pos = new Vector3(24.580000f, 2.850000f, 41.380001f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"460","Sprites/objects_1350_1604");
		
		myObj= CreateGameObject("CRITTER_AI_HINT_28_34_01_0312",34.180000f,1.593750f,41.380001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1361",true);
		
		myObj= CreateGameObject("WRAPPER_28_34_01_0042",34.270313f,1.312500f,41.020313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0570",true);
		
		myObj= CreateGameObject("DEBRIS_30_34_01_0071",36.580002f,1.331250f,41.380001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0601",true);
		
		myObj= CreateGameObject("CRITTER_AI_HINT_35_34_01_0308",42.580002f,1.593750f,41.380001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1361",true);
		
		myObj= CreateGameObject("ENERGY_CHARGE_STATION_38_34_01_0679",46.180000f,3.600000f,41.380001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0952",true);
		
		myObj= CreateGameObject("HIDDEN_DOOR_038_034",46.795311f,3.600000f,41.380001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1141",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)90.000000,(float)0.000000);
		CreateShockDoor(myObj,0,0,2438);
		
		myObj= CreateGameObject("CONTROL_PEDESTAL_11_35_01_0509",13.780000f,0.000000f,42.580002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("BULKHEAD_DOOR_016_035",19.780001f,1.200000f,42.020000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1123",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)180.000000,(float)0.000000);
		CreateShockDoor(myObj,0,1,2432);
		
		myObj= CreateGameObject("NULL_TRIGGER_17_35_01_0024",20.980000f,1.800000f,42.580002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 4,1,0,0,0,0);
		AddACTION_SET_VARIABLE(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_17_35_01_0023",20.980000f,1.800000f,42.580002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "BULKHEAD_DOOR_017_035", 0,"",0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("LEVER_17_35_01_0130",21.595312f,1.800000f,42.595314f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0897",false);
		CreateSHOCKActivators(myObj,6);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_17_35_01_0024", 0,"NULL_TRIGGER_17_35_01_0023", 0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)90.000000,(float)0.000000);
		
		myObj= CreateGameObject("BULKHEAD_DOOR_017_035",20.980000f,1.200000f,42.020000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1120",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)180.000000,(float)0.000000);
		CreateShockDoor(myObj,0,1,2431);
		
		myObj= CreateGameObject("DH_07_STUNGUN_26_35_01_0331",32.170311f,2.568750f,42.557812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0043",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,14, 0);
		
		myObj= CreateGameObject("FRAGMENTATION_GRENADE_26_35_01_0106",31.607813f,2.550000f,42.670311f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0177",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,55, 0);
		
		myObj= CreateGameObject("HIDDEN_DOOR_030_035",36.580002f,0.000000f,42.580002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1141",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-90.000000,(float)0.000000,(float)0.000000);
		CreateShockDoor(myObj,0,0,2438);
		
		myObj= CreateGameObject("BRIDGE_31_35_01_0020",37.779999f,1.162500f,42.580002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("BURN_RESIDUE_35_35_01_0476",42.632813f,2.437500f,43.195313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0843",true);
		
		myObj= CreateGameObject("ICON_35_35_01_0435",42.020000f,3.056250f,43.195313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0395",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",62,127, 0);
		
		myObj= CreateGameObject("FIRE_EXTINGUISHER_37_35_01_0026",45.182812f,3.843750f,42.932812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0579",true);
		
		myObj= CreateGameObject("FIRST_AID_KIT_41_35_01_0376",49.757813f,2.568750f,42.445313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0750",true);
		
		myObj= CreateGameObject("X_RAY_MACHINE_13_36_01_0624",16.180000f,0.000000f,43.779999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("HOSPITAL_BED_13_36_01_0508",16.270313f,0.037500f,43.832813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("ENTRY_TRIGGER_17_36_01_0498",21.000000f,2.400000f,43.799999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1340",false);
		AddACTION_MESSAGE(myObj);
		CreateEntry_Trigger(myObj, 22,1,17,144,112,0);
		CreateCollider(myObj,1.20f,4.800000f,1.20f);
		
		myObj= CreateGameObject("DESTROYED_DRONE_CYBORG_18_36_01_0501",22.180000f,1.650000f,43.779999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1494",true);
		
		myObj= CreateGameObject("NULL_TRIGGER_19_36_01_0063",23.379999f,1.800000f,43.779999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 12,0,0,0,0,0);
		AddACTION_CHOICE(myObj,"NULL_TRIGGER_19_36_01_0007", "NULL_TRIGGER_19_36_01_0009");
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_19_36_01_0007",23.379999f,1.800000f,43.779999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 9,0,0,0,0,0);
		AddACTION_MOVING_PLATFORM(myObj, 19, 37, 8, -4063, 1);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_19_36_01_0009",23.379999f,1.800000f,43.779999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 9,0,0,0,0,0);
		AddACTION_MOVING_PLATFORM(myObj, 19, 37, 16, -4063, 1);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("ENERGY_GRATING_023_036",28.180000f,2.400000f,43.779999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		CreateShockDoor(myObj,0,0,2424);
		
		myObj= CreateGameObject("STORAGE_ROOM_DOOR_026_036",31.780001f,2.400000f,44.395313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1045",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		CreateShockDoor(myObj,10,0,2406);
		
		myObj= CreateGameObject("WORDS_30_36_01_0567",36.632813f,2.850000f,44.395313f);
		CreateWords(myObj, 17, 606, 4, 0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("BURN_RESIDUE_30_36_01_0086",36.020000f,2.625000f,43.757813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0843",true);
		
		myObj= CreateGameObject("CAMERA_31_36_01_0416",37.307812f,3.337500f,44.395313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("BRIDGE_31_36_01_0619",37.779999f,1.162500f,43.779999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("NULL_TRIGGER_31_36_01_0584",37.779999f,1.800000f,43.779999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "",0,"",0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj = new GameObject("CYBORG_DRONE_34_36_01_0302");
		pos = new Vector3(41.380001f, 4.050000f, 43.779999f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"460","Sprites/objects_1350_1604");
		
		myObj= CreateGameObject("SKULL_34_36_01_0157",41.380001f,3.712500f,43.779999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0718",true);
		
		myObj= CreateGameObject("FIRST_AID_KIT_46_36_01_0051",55.779999f,0.318750f,43.779999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0750",true);
		
		myObj= CreateGameObject("BRIDGE_46_36_01_0255",55.779999f,2.343750f,43.779999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj = new GameObject("HUMANOID_MUTANT_09_37_01_0284");
		pos = new Vector3(11.380000f, 1.593750f, 44.980000f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"439","Sprites/objects_1350_1541");
		
		myObj= CreateGameObject("PAPERS_12_37_01_0717",14.920313f,0.150000f,44.882813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0573",true);
		
		myObj= CreateGameObject("CYBERSPACE_TERMINAL_12_37_01_0535",14.995313f,0.581250f,45.370312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0949",true);
		
		myObj= CreateGameObject("MEDICAL_ACCESS_CARD_1",17.732813f,0.131250f,44.582813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0773",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",5,228, 0);
		CreateKey(myObj, 0);
		
		myObj= CreateGameObject("ENTRY_TRIGGER_15_37_01_0727",18.600000f,2.400000f,45.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1340",false);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_38_39_01_0320", 0,"NULL_TRIGGER_38_39_01_0408", 0,"",0,"",0);
		CreateEntry_Trigger(myObj, 6,1,0,0,0,0);
		CreateCollider(myObj,1.20f,4.800000f,1.20f);
		
		myObj= CreateGameObject("ELEVATOR_PANEL_15_37_01_0030",18.020000f,1.912500f,44.995312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0983",false);
		CreateSHOCKActivators(myObj,1);
		AddACTION_TRANSPORT_LEVEL(myObj);
		SetRotation(myObj,(float)-0.000000,(float)270.000000,(float)0.000000);
		
		myObj= CreateGameObject("ELEVATOR_DOOR_015_037",18.580000f,1.200000f,44.419998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1109",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)180.000000,(float)0.000000);
		CreateShockDoor(myObj,0,0,2427);
		
		myObj= CreateGameObject("EMAIL_18_37_01_0021",21.782812f,1.293750f,44.545311f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0281",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",13,105, 0);
		
		myObj= CreateGameObject("LARGE_BUTTON_18_37_01_0016",22.195313f,1.818750f,45.595314f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0905",false);
		CreateSHOCKActivators(myObj,6);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_19_36_01_0063", 0,"",0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("ENTRY_TRIGGER_19_37_01_0681",23.400000f,2.400000f,45.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1340",false);
		AddACTION_EMAIL(myObj);
		CreateEntry_Trigger(myObj, 15,1,0,0,0,0);
		CreateCollider(myObj,1.20f,4.800000f,1.20f);
		
		myObj= CreateGameObject("WORDS_20_37_01_0715",25.082813f,3.337500f,44.419998f);
		CreateWords(myObj, 92, 606, 4, 0);
		SetRotation(myObj,(float)-0.000000,(float)180.000000,(float)0.000000);
		
		myObj= CreateGameObject("LARGE_BUTTON_20_37_01_0220",24.295313f,3.000000f,44.419998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0905",false);
		CreateSHOCKActivators(myObj,6);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_19_36_01_0063", 0,"",0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)180.000000,(float)0.000000);
		
		myObj = new GameObject("CYBORG_ASSASSIN_27_37_01_0089");
		pos = new Vector3(32.419998f, 2.793750f, 44.957813f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"462","Sprites/objects_1350_1610");
		
		myObj= CreateGameObject("BRIDGE_31_37_01_0719",37.779999f,1.162500f,44.980000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("DOOR_035_037",42.580002f,3.600000f,45.595314f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1039",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		CreateShockDoor(myObj,0,0,2404);
		
		myObj= CreateGameObject("DOOR_039_037",47.380001f,3.600000f,45.595314f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1039",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		CreateShockDoor(myObj,0,0,2404);
		
		myObj= CreateGameObject("ELEPHANT_JORP_45_37_01_0243",54.580002f,2.343750f,44.980000f);
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
		
		myObj= CreateGameObject("ENERGY_GRATING_023_038",28.180000f,2.400000f,46.795311f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		CreateShockDoor(myObj,0,0,2424);
		
		myObj= CreateGameObject("FORCE_DOOR_031_038",37.779999f,1.200000f,45.619999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)180.000000,(float)0.000000);
		CreateShockDoor(myObj,0,1,2423);
		
		myObj= CreateGameObject("HUMAN_CORPSE_34_38_01_0272",41.380001f,3.975000f,46.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0672",true);
		
		myObj= CreateGameObject("EMERGENCY_LEVER_39_38_01_0627",46.820000f,4.462500f,46.495312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0909",false);
		CreateSHOCKActivators(myObj,6);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_38_39_01_0628", 0,"NULL_TRIGGER_38_39_01_0408", 0,"NULL_TRIGGER_38_39_01_0320", 0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)270.000000,(float)0.000000);
		
		myObj= CreateGameObject("VIAL_42_38_01_0642",50.980000f,4.162500f,46.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1420",true);
		
		myObj= CreateGameObject("VIAL_42_38_01_0641",50.920311f,4.162500f,46.345314f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1420",true);
		
		myObj= CreateGameObject("FLASK_42_38_01_0640",50.695313f,4.162500f,46.045311f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1423",true);
		
		myObj= CreateGameObject("ELEPHANT_JORP_45_38_01_0180",54.580002f,2.343750f,46.180000f);
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
		
		myObj= CreateGameObject("GAS_GRENADE_33_39_01_0380",40.180000f,0.150000f,47.380001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0183",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,57, 0);
		
		myObj= CreateGameObject("CHAIR_34_39_01_0193",41.357811f,3.600000f,47.432812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("EMAIL_35_39_01_0317",42.580002f,4.200000f,47.380001f);
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
		
		myObj= CreateGameObject("NULL_TRIGGER_38_39_01_0628",46.180000f,1.800000f,47.380001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 15,1,0,0,0,0);
		AddACTION_EMAIL(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_38_39_01_0320",46.180000f,1.800000f,47.380001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 13,0,0,0,0,0);
		AddACTION_UNKNOWN(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_38_39_01_0408",46.180000f,1.800000f,47.380001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 3,0,0,0,0,0);
		AddACTION_CLONE(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("SCREEN_39_39_01_0533",46.820000f,4.181250f,47.395313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		CreateComputerScreen(myObj,0,100,1);
		SetRotation(myObj,(float)-0.000000,(float)270.000000,(float)0.000000);
		
		myObj= CreateGameObject("DH_07_STUNGUN_39_39_01_0108",47.620312f,3.768750f,47.320313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0043",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,14, 0);
		
		myObj= CreateGameObject("FLASK_40_39_01_0639",48.820313f,4.162500f,47.245312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1423",true);
		
		myObj= CreateGameObject("BEAKER_40_39_01_0532",48.580002f,4.162500f,47.380001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1426",true);
		
		myObj= CreateGameObject("SCOPE_41_39_01_0623",49.795311f,4.050000f,46.982811f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("TESTTUBE_RACK_41_39_01_0614",49.307812f,4.050000f,47.245312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("PAPERS_42_39_01_0480",50.507813f,4.200000f,47.207813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0573",true);
		
		myObj = new GameObject("HUMANOID_MUTANT_47_39_01_0650");
		pos = new Vector3(56.980000f, 0.543750f, 47.380001f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"439","Sprites/objects_1350_1541");
		
		myObj= CreateGameObject("HUMAN_CORPSE_49_39_01_0264",59.732811f,3.956250f,47.395313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0662",true);
		
		myObj= CreateGameObject("LEVER_49_39_01_0365",59.380001f,4.200000f,47.995312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0897",false);
		CreateSHOCKActivators(myObj,12);
		AddACTION_CHOICE(myObj,"NULL_TRIGGER_49_40_01_0371", "NULL_TRIGGER_49_40_01_0372");
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("CAMERA_11_40_01_0429",14.395312f,2.212500f,48.020000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("IRIS_DOOR_014_040",17.995312f,1.200000f,48.580002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1126",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)90.000000,(float)0.000000);
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
		
		myObj= CreateGameObject("TOXIC_WASTE_BARREL_21_40_01_0609",25.780001f,1.593750f,48.580002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1410",true);
		
		myObj = new GameObject("CYBORG_DRONE_26_40_01_0367");
		pos = new Vector3(31.832813f, 2.850000f, 48.670311f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"460","Sprites/objects_1350_1604");
		
		myObj= CreateGameObject("HUMAN_CORPSE_28_40_01_0725",34.795311f,0.375000f,48.020000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0682",true);
		
		myObj= CreateGameObject("ILLUDIUM_CADMIUM_BATTERY_29_40_01_0723",35.170311f,0.112500f,48.332813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0744",true);
		
		myObj= CreateGameObject("REFLEX_REACTION_AID_29_40_01_0722",35.545311f,0.150000f,48.520313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0212",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,67, 0);
		
		myObj= CreateGameObject("NITROPACK_29_40_01_0721",35.380001f,0.150000f,48.580002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0192",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,60, 0);
		
		myObj= CreateGameObject("SWITCH_30_40_01_0450",36.932812f,1.912500f,48.020000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0881",false);
		CreateSHOCKActivators(myObj,6);
		AddACTION_ACTIVATE(myObj, "FORCE_DOOR_031_038", 0,"",0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)180.000000,(float)0.000000);
		
		myObj= CreateGameObject("ENTRY_TRIGGER_33_40_01_0216",40.200001f,2.400000f,48.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1340",false);
		AddACTION_MOVING_PLATFORM(myObj, 33, 40, 0, -4063, 1);
		CreateEntry_Trigger(myObj, 9,0,0,0,0,0);
		CreateCollider(myObj,1.20f,4.800000f,1.20f);
		
		myObj = new GameObject("CYBORG_ASSASSIN_37_40_01_0262");
		pos = new Vector3(44.980000f, 1.593750f, 48.580002f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"462","Sprites/objects_1350_1610");
		
		myObj = new GameObject("CYBORG_ASSASSIN_45_40_01_0263");
		pos = new Vector3(54.970314f, 2.793750f, 48.595314f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"462","Sprites/objects_1350_1610");
		
		myObj= CreateGameObject("NULL_TRIGGER_49_40_01_0371",59.380001f,1.200000f,48.580002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_49_40_01_0370", 0,"NULL_TRIGGER_49_40_01_0326", 0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_49_40_01_0372",59.380001f,1.200000f,48.580002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_49_40_01_0217", 0,"NULL_TRIGGER_49_40_01_0373", 0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_49_40_01_0370",59.380001f,1.200000f,48.580002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 24,0,0,0,0,0);
		AddACTION_CHANGE_TYPE(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_49_40_01_0326",59.380001f,1.200000f,48.580002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 24,0,0,0,0,0);
		AddACTION_CHANGE_TYPE(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_49_40_01_0217",59.380001f,1.200000f,48.580002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 24,0,0,0,0,0);
		AddACTION_CHANGE_TYPE(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_49_40_01_0373",59.380001f,1.200000f,48.580002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 24,0,0,0,0,0);
		AddACTION_CHANGE_TYPE(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("SWITCH_12_41_01_0525",14.420000f,1.818750f,49.795311f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0881",false);
		CreateSHOCKActivators(myObj,6);
		AddACTION_ACTIVATE(myObj, "IRIS_DOOR_014_040", 0,"",0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)270.000000,(float)0.000000);
		
		myObj= CreateGameObject("BEVERAGE_CONTAINER_21_41_01_0526",25.780001f,0.093750f,49.779999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0568",true);
		
		myObj= CreateGameObject("FRAGMENTATION_GRENADE_21_41_01_0528",25.780001f,0.150000f,49.779999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0177",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,55, 0);
		
		myObj= CreateGameObject("FRAGMENTATION_GRENADE_21_41_01_0522",25.780001f,0.150000f,49.779999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0177",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,55, 0);
		
		myObj= CreateGameObject("EMP_GRENADE_21_41_01_0527",25.780001f,0.150000f,49.779999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0180",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,56, 0);
		
		myObj= CreateGameObject("CATWALK_26_41_01_0260",31.795313f,2.343750f,50.245312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("CATWALK_27_41_01_0261",32.957813f,2.343750f,50.245312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("REPULSOR_30_41_01_0055",36.580002f,1.800000f,49.779999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1370",false);
		
		myObj= CreateGameObject("FRAGMENTATION_GRENADE_47_41_01_0649",57.295311f,0.300000f,49.870312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0177",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,55, 0);
		
		myObj= CreateGameObject("EMAIL_16_42_01_0316",19.780001f,2.493750f,50.980000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0281",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",13,105, 0);
		
		myObj= CreateGameObject("CAMERA_16_42_01_0424",19.495312f,3.375000f,50.620312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("FORCE_DOOR_017_042",21.595312f,2.400000f,50.980000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)90.000000,(float)0.000000);
		CreateShockDoor(myObj,0,0,2423);
		
		myObj = new GameObject("CYBORG_DRONE_17_42_01_0328");
		pos = new Vector3(20.980000f, 2.850000f, 50.980000f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"460","Sprites/objects_1350_1604");
		
		myObj= CreateGameObject("NULL_TRIGGER_19_42_01_0540",23.379999f,3.000000f,50.980000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_19_42_01_0538", 0,"NULL_TRIGGER_18_43_01_0397", 0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_19_42_01_0539",23.379999f,3.000000f,50.980000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_19_42_01_0537", 0,"NULL_TRIGGER_18_43_01_0160", 0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_19_42_01_0538",23.379999f,3.000000f,50.980000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 22,0,0,0,0,0);
		AddACTION_MESSAGE(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_19_42_01_0537",23.379999f,3.000000f,50.980000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 22,0,0,0,0,0);
		AddACTION_MESSAGE(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj = new GameObject("CYBORG_ASSASSIN_20_42_01_0330");
		pos = new Vector3(24.580000f, 2.793750f, 50.980000f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"462","Sprites/objects_1350_1610");
		
		myObj= CreateGameObject("ENERGY_GRATING_023_042",28.180000f,2.400000f,51.595314f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		CreateShockDoor(myObj,0,0,2424);
		
		myObj= CreateGameObject("REPULSOR_26_42_01_0451",31.780001f,0.600000f,50.980000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1370",false);
		
		myObj= CreateGameObject("FRAGMENTATION_GRENADE_28_42_01_0693",34.345314f,2.550000f,51.182812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0177",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,55, 0);
		
		myObj= CreateGameObject("WORDS_35_42_01_0570",42.020000f,1.706250f,51.032814f);
		CreateWords(myObj, 71, 602, 4, 2);
		SetRotation(myObj,(float)-0.000000,(float)270.000000,(float)0.000000);
		
		myObj= CreateGameObject("SWITCH_14_43_01_0603",17.379999f,1.875000f,52.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0881",false);
		CreateSHOCKActivators(myObj,0);
		AddACTION_DO_NOTHING(myObj, "ML_41_PISTOL_00_00_01_0000");
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_18_43_01_0237",22.180000f,3.000000f,52.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 12,0,0,0,0,0);
		AddACTION_CHOICE(myObj,"NULL_TRIGGER_19_42_01_0539", "NULL_TRIGGER_19_42_01_0540");
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_18_43_01_0397",22.180000f,3.000000f,52.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 4,0,0,0,0,0);
		AddACTION_SET_VARIABLE(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_18_43_01_0160",22.180000f,3.000000f,52.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 4,0,0,0,0,0);
		AddACTION_SET_VARIABLE(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("LEVER_18_43_01_0227",22.795313f,2.925000f,52.120312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0899",false);
		CreateSHOCKActivators(myObj,6);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_18_43_01_0237", 0,"",0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)90.000000,(float)0.000000);
		
		myObj= CreateGameObject("GRATING_18_43_01_0232",22.180000f,3.000000f,51.619999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1073",true);
		
		myObj= CreateGameObject("PLAYER_DEATH_TRIGGER_19_43_01_0230",23.379999f,3.000000f,52.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1349",true);
		
		myObj= CreateGameObject("NULL_TRIGGER_19_43_01_0229",23.379999f,3.000000f,52.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 1,0,0,0,0,0);
		AddACTION_TRANSPORT_LEVEL(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_19_43_01_0228",23.379999f,3.000000f,52.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 2,0,0,0,0,0);
		AddACTION_RESURRECTION(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("WORDS_20_43_01_0153",24.020000f,2.737500f,52.270313f);
		CreateWords(myObj, 85, 609, 10, 0);
		SetRotation(myObj,(float)-0.000000,(float)270.000000,(float)340.312500);
		
		myObj= CreateGameObject("ICON_20_43_01_0234",24.020000f,3.225000f,52.195313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0395",false);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",62,127, 0);
		
		myObj = new GameObject("CYBORG_DRONE_25_43_01_0329");
		pos = new Vector3(30.580000f, 2.850000f, 52.180000f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"460","Sprites/objects_1350_1604");
		
		myObj= CreateGameObject("CAMERA_26_43_01_0425",32.320313f,3.543750f,52.757813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj = new GameObject("CYBORG_ASSASSIN_31_43_01_0398");
		pos = new Vector3(37.779999f, 2.793750f, 52.180000f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"462","Sprites/objects_1350_1610");
		
		myObj = new GameObject("CYBORG_DRONE_38_43_01_0314");
		pos = new Vector3(46.757813f, 2.850000f, 52.307812f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"460","Sprites/objects_1350_1604");
		
		myObj= CreateGameObject("NULL_TRIGGER_42_43_01_0604",50.980000f,1.800000f,52.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 7,0,0,0,0,0);
		AddACTION_LIGHTING(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj = new GameObject("CYBORG_DRONE_16_44_01_0092");
		pos = new Vector3(19.832813f, 2.850000f, 53.395313f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"460","Sprites/objects_1350_1604");
		
		myObj= CreateGameObject("CAMERA_16_44_01_0423",19.457813f,3.375000f,53.770313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("SCREEN_18_44_01_0369",22.195313f,3.000000f,53.995312f);
		CreateComputerScreen(myObj,0,4,0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("ENERGY_GRATING_019_044",23.995312f,2.400000f,53.395313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)90.000000,(float)0.000000);
		CreateShockDoor(myObj,0,0,2424);
		
		myObj= CreateGameObject("NULL_TRIGGER_21_44_01_0557",25.780001f,3.000000f,53.380001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 12,0,0,0,0,0);
		AddACTION_CHOICE(myObj,"NULL_TRIGGER_21_44_01_0596", "NULL_TRIGGER_21_44_01_0589");
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_21_44_01_0596",25.780001f,3.000000f,53.380001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 24,0,0,0,0,0);
		AddACTION_CHANGE_TYPE(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_21_44_01_0589",25.780001f,3.000000f,53.380001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 24,0,0,0,0,0);
		AddACTION_CHANGE_TYPE(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj = new GameObject("CYBORG_DRONE_22_44_01_0368");
		pos = new Vector3(26.821875f, 0.450000f, 53.793751f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"460","Sprites/objects_1350_1604");
		
		myObj = new GameObject("CYBORG_DRONE_23_44_01_0091");
		pos = new Vector3(28.180000f, 2.850000f, 53.380001f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"460","Sprites/objects_1350_1604");
		
		myObj= CreateGameObject("NULL_TRIGGER_25_44_01_0595",30.580000f,0.600000f,53.380001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 12,0,0,0,0,0);
		AddACTION_CHOICE(myObj,"NULL_TRIGGER_25_44_01_0594", "NULL_TRIGGER_25_44_01_0556");
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_25_44_01_0594",30.580000f,0.600000f,53.380001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 24,0,0,0,0,0);
		AddACTION_CHANGE_TYPE(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_25_44_01_0556",30.580000f,0.600000f,53.380001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 24,0,0,0,0,0);
		AddACTION_CHANGE_TYPE(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("BUTTON_28_44_01_0554",34.795311f,0.750000f,53.545311f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0889",false);
		CreateSHOCKActivators(myObj,6);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_25_44_01_0595", 0,"",0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)90.000000,(float)0.000000);
		
		myObj= CreateGameObject("FORCE_DOOR_28_44_01_0551",34.180000f,0.600000f,53.995312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("NULL_TRIGGER_29_44_01_0356",35.380001f,1.200000f,53.380001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "",0,"",0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("MEDIPATCH__HEALING_AGENT_37_44_01_0409",44.732811f,2.550000f,53.395313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,66, 0);
		
		myObj= CreateGameObject("NULL_TRIGGER_12_45_01_0602",14.980000f,1.200000f,54.580002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 7,0,0,0,0,0);
		AddACTION_LIGHTING(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("DEATH_WATCH_TRIGGER_21_45_01_0562",25.780001f,3.450000f,54.580002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1352",false);
		CreateNull_Trigger(myObj, 6,1,47,2,0,1);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_25_44_01_0594", 0,"NULL_TRIGGER_21_45_01_0588", 0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_21_45_01_0563",25.780001f,3.450000f,54.580002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 22,0,0,0,0,0);
		AddACTION_MESSAGE(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_21_45_01_0587",25.780001f,3.450000f,54.580002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 4,0,0,0,0,0);
		AddACTION_SET_VARIABLE(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_21_45_01_0588",25.780001f,3.450000f,54.580002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 4,0,0,0,0,0);
		AddACTION_SET_VARIABLE(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("CAMERA_22_45_01_0559",26.545313f,0.900000f,55.195313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("BATTERY_PACK_22_45_01_0644",26.995312f,0.112500f,54.407814f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0756",true);
		
		myObj= CreateGameObject("BATTERY_PACK_22_45_01_0560",26.980000f,0.112500f,54.580002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0756",true);
		
		myObj= CreateGameObject("BUTTON_23_45_01_0592",28.326563f,0.731250f,54.020000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0889",false);
		CreateSHOCKActivators(myObj,6);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_21_46_01_0597", 0,"",0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)180.000000,(float)0.000000);
		
		myObj= CreateGameObject("FORCE_DOOR_23_45_01_0553",28.795313f,0.600000f,54.580002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("BUTTON_24_45_01_0558",29.245312f,0.731250f,55.195313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0889",false);
		CreateSHOCKActivators(myObj,6);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_21_46_01_0597", 0,"",0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("ENTRY_TRIGGER_26_45_01_0585",31.799999f,2.400000f,54.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1340",false);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_21_45_01_0563", 0,"NULL_TRIGGER_25_44_01_0556", 0,"NULL_TRIGGER_21_45_01_0587", 0,"",0);
		CreateEntry_Trigger(myObj, 6,1,0,0,0,0);
		CreateCollider(myObj,1.20f,4.800000f,1.20f);
		
		myObj= CreateGameObject("BUTTON_26_45_01_0593",31.945313f,0.731250f,55.195313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0889",false);
		CreateSHOCKActivators(myObj,6);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_21_44_01_0557", 0,"",0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("BUTTON_27_45_01_0586",33.145313f,0.731250f,54.020000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0889",false);
		CreateSHOCKActivators(myObj,6);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_25_44_01_0595", 0,"",0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)180.000000,(float)0.000000);
		
		myObj= CreateGameObject("BUTTON_27_45_01_0555",32.821877f,0.731250f,54.020000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0889",false);
		CreateSHOCKActivators(myObj,6);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_21_44_01_0557", 0,"",0,"",0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)180.000000,(float)0.000000);
		
		myObj= CreateGameObject("FORCE_DOOR_27_45_01_0552",33.595314f,0.600000f,54.580002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj = new GameObject("CYBORG_DRONE_30_45_01_0221");
		pos = new Vector3(36.580002f, 2.850000f, 54.580002f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"460","Sprites/objects_1350_1604");
		
		myObj= CreateGameObject("NULL_TRIGGER_31_45_01_0344",37.779999f,3.000000f,54.580002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 23,1,0,0,0,0);
		AddACTION_SPAWN(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("ENTRY_TRIGGER_32_45_01_0184",39.000000f,2.400000f,54.599998f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1340",false);
		AddACTION_MESSAGE(myObj);
		CreateEntry_Trigger(myObj, 22,1,0,0,0,0);
		CreateCollider(myObj,1.20f,4.800000f,1.20f);
		
		myObj= CreateGameObject("CAMERA_35_45_01_0430",43.157814f,3.318750f,54.032814f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("ENERGY_GRATING_038_045",46.180000f,2.400000f,54.020000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)180.000000,(float)0.000000);
		CreateShockDoor(myObj,0,0,2424);
		
		myObj= CreateGameObject("BERSERK_COMBAT_BOOSTER_16_46_01_0334",19.495312f,2.550000f,55.220001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0205",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,65, 0);
		
		myObj= CreateGameObject("BROKEN_GUN_16_46_01_0333",19.457813f,2.568750f,55.645313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0592",true);
		
		myObj= CreateGameObject("SKELETON_16_46_01_0332",19.780001f,2.756250f,55.779999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0702",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,210, 0);
		
		myObj= CreateGameObject("GRATING_17_46_01_0155",20.420000f,3.000000f,55.779999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1073",true);
		
		myObj= CreateGameObject("SCREEN_18_46_01_0530",22.195313f,2.981250f,55.220001f);
		CreateComputerScreen(myObj,81,4,1);
		SetRotation(myObj,(float)-0.000000,(float)180.000000,(float)0.000000);
		
		myObj= CreateGameObject("EMAIL_18_46_01_0505",21.782812f,2.493750f,55.720314f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0281",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",13,105, 0);
		
		myObj= CreateGameObject("HUMAN_CORPSE_18_46_01_0504",22.757813f,2.756250f,55.795311f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0632",true);
		
		myObj= CreateGameObject("DESTROYED_ASSASSIN_CYBORG_18_46_01_0503",22.180000f,2.793750f,55.779999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1500",true);
		
		myObj= CreateGameObject("CAMERA_18_46_01_0422",22.795313f,3.543750f,55.220001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("NULL_TRIGGER_21_46_01_0597",25.780001f,2.850000f,55.779999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 12,0,0,0,0,0);
		AddACTION_CHOICE(myObj,"NULL_TRIGGER_21_46_01_0590", "NULL_TRIGGER_21_46_01_0591");
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_21_46_01_0591",25.780001f,2.850000f,55.779999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 24,0,0,0,0,0);
		AddACTION_CHANGE_TYPE(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_21_46_01_0590",25.780001f,2.850000f,55.779999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 24,0,0,0,0,0);
		AddACTION_CHANGE_TYPE(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj = new GameObject("CYBORG_DRONE_22_46_01_0360");
		pos = new Vector3(27.257813f, 2.700000f, 55.870312f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"460","Sprites/objects_1350_1604");
		
		myObj = new GameObject("CYBORG_DRONE_24_46_01_0174");
		pos = new Vector3(29.732813f, 2.700000f, 55.982811f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"460","Sprites/objects_1350_1604");
		
		myObj = new GameObject("CYBORG_DRONE_26_46_01_0060");
		pos = new Vector3(31.982813f, 2.756250f, 56.231251f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"460","Sprites/objects_1350_1604");
		
		myObj= CreateGameObject("CAMERA_30_46_01_0426",36.370312f,3.431250f,55.832813f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("WORDS_36_46_01_0569",43.779999f,2.700000f,56.395313f);
		CreateWords(myObj, 66, 602, 4, 0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj = new GameObject("CYBORG_DRONE_40_46_01_0400");
		pos = new Vector3(48.932812f, 0.600000f, 56.132813f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"460","Sprites/objects_1350_1604");
		
		myObj= CreateGameObject("CONTROL_PEDESTAL_41_46_01_0167",49.907814f,0.150000f,55.945313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("ML_41_PISTOL_43_46_01_0565",52.180000f,0.300000f,55.779999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0001",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",1,0, 0);
		
		myObj= CreateGameObject("GRATING_17_47_01_0322",20.420000f,3.000000f,56.980000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1073",true);
		
		myObj= CreateGameObject("SCREEN_18_47_01_0531",22.180000f,2.981250f,57.595314f);
		CreateComputerScreen(myObj,85,4,1);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj = new GameObject("CYBORG_DRONE_20_47_01_0090");
		pos = new Vector3(24.580000f, 2.850000f, 56.980000f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"460","Sprites/objects_1350_1604");
		
		myObj= CreateGameObject("ENTRY_TRIGGER_27_47_01_0598",33.000000f,2.400000f,57.000000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1340",false);
		AddACTION_MOVING_PLATFORM(myObj, 29, 47, 4095, 8, 2);
		CreateEntry_Trigger(myObj, 9,0,0,0,0,0);
		CreateCollider(myObj,1.20f,4.800000f,1.20f);
		
		myObj= CreateGameObject("REPULSOR_35_47_01_0579",42.580002f,0.600000f,56.980000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1370",false);
		
		myObj= CreateGameObject("COMPUTER_NODE_41_47_01_0166",49.779999f,0.150000f,56.980000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("COMPUTER_NODE_42_47_01_0145",50.980000f,0.150000f,56.980000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj = new GameObject("CYBORG_DRONE_20_48_01_0363");
		pos = new Vector3(24.478125f, 2.250000f, 58.724998f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"460","Sprites/objects_1350_1604");
		
		myObj = new GameObject("CYBORG_DRONE_22_48_01_0362");
		pos = new Vector3(26.845312f, 2.250000f, 58.645313f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"460","Sprites/objects_1350_1604");
		
		myObj= CreateGameObject("CAMERA_30_48_01_0427",36.407814f,3.393750f,58.157814f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("COMPUTER_NODE_41_48_01_0144",49.779999f,0.150000f,58.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("COMPUTER_NODE_42_48_01_0115",50.980000f,0.150000f,58.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("DEATH_WATCH_TRIGGER_44_48_01_0475",53.380001f,1.200000f,58.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1352",false);
		CreateNull_Trigger(myObj, 6,1,8,0,7,0);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_45_48_01_0645", 80,"NULL_TRIGGER_20_51_01_0357", 0,"NULL_TRIGGER_31_45_01_0344", 0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_45_48_01_0645",54.580002f,1.200000f,58.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 15,0,0,0,0,0);
		AddACTION_EMAIL(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj = new GameObject("CYBORG_ASSASSIN_27_49_01_0401");
		pos = new Vector3(33.032814f, 2.193750f, 59.395313f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"462","Sprites/objects_1350_1610");
		
		myObj= CreateGameObject("SKULL_29_49_01_0403",35.432812f,0.712500f,59.770313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0718",true);
		
		myObj= CreateGameObject("MEDIPATCH__HEALING_AGENT_29_49_01_0404",35.695313f,0.750000f,59.657814f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,66, 0);
		
		myObj= CreateGameObject("LUMP_OF_CLOTHES_30_49_01_0402",36.580002f,0.243750f,59.380001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0585",true);
		
		myObj = new GameObject("CYBORG_WARRIOR_35_49_01_0306");
		pos = new Vector3(42.580002f, 2.887500f, 59.380001f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"461","Sprites/objects_1350_1607");
		
		myObj= CreateGameObject("ENTRY_TRIGGER_37_49_01_0165",45.000000f,2.400000f,59.400002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1340",false);
		AddACTION_MESSAGE(myObj);
		CreateEntry_Trigger(myObj, 22,1,0,0,0,0);
		CreateCollider(myObj,1.20f,4.800000f,1.20f);
		
		myObj= CreateGameObject("CAMERA_39_49_01_0428",47.995312f,1.181250f,59.995312f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",true);
		
		myObj= CreateGameObject("NULL_TRIGGER_41_49_01_0583",50.170311f,3.168750f,59.432812f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 6,0,0,0,0,0);
		AddACTION_ACTIVATE(myObj, "",0,"",0,"",0,"",0);
		SetRotation(myObj,(float)-326.250000,(float)180.000000,(float)0.000000);
		
		myObj= CreateGameObject("SCREEN_43_49_01_0238",52.795311f,0.862500f,59.357811f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0000",false);
		CreateComputerScreen(myObj,0,100,1);
		SetRotation(myObj,(float)-0.000000,(float)90.000000,(float)0.000000);
		
		myObj= CreateGameObject("DEATH_WATCH_TRIGGER_44_49_01_0445",53.380001f,1.200000f,59.380001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1352",false);
		CreateNull_Trigger(myObj, 6,0,8,0,7,0);
		AddACTION_ACTIVATE(myObj, "NULL_TRIGGER_45_49_01_0506", 0,"NULL_TRIGGER_46_49_01_0375", 0,"NULL_TRIGGER_46_49_01_0507", 0,"",0);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_45_49_01_0506",54.580002f,1.200000f,59.380001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 4,0,0,0,0,0);
		AddACTION_SET_VARIABLE(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_46_49_01_0507",55.779999f,1.200000f,59.380001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 19,0,33,16,4,0);
		AddACTION_CHANGE_STATE(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_46_49_01_0375",55.779999f,1.200000f,59.380001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 19,0,33,16,4,0);
		AddACTION_CHANGE_STATE(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj = new GameObject("CYBORG_DRONE_23_50_01_0361");
		pos = new Vector3(28.040625f, 2.250000f, 60.159374f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"460","Sprites/objects_1350_1604");
		
		myObj = new GameObject("CYBORG_DRONE_25_50_01_0359");
		pos = new Vector3(30.417187f, 2.250000f, 60.168751f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"460","Sprites/objects_1350_1604");
		
		myObj= CreateGameObject("DEATH_WATCH_TRIGGER_36_50_01_0276",43.779999f,0.600000f,60.580002f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1352",false);
		CreateNull_Trigger(myObj, 4,0,8,0,7,0);
		AddACTION_SET_VARIABLE(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("SWITCH_20_51_01_0355",24.580000f,0.675000f,61.779999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0881",false);
		CreateSHOCKActivators(myObj,0);
		AddACTION_DO_NOTHING(myObj, "ML_41_PISTOL_00_00_01_0000");
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("NULL_TRIGGER_20_51_01_0357",24.580000f,1.200000f,61.779999f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1343",false);
		CreateNull_Trigger(myObj, 21,0,0,0,0,0);
		AddACTION_AWAKEN(myObj);
		SetRotation(myObj,(float)-0.000000,(float)0.000000,(float)0.000000);
		
		myObj= CreateGameObject("STORAGE_ROOM_DOOR_031_051",37.779999f,0.000000f,61.220001f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1045",false);
		SetScale(myObj,(float)1.875000,(float)1.875000,(float)1.875000);
		SetRotation(myObj,(float)-0.000000,(float)180.000000,(float)0.000000);
		CreateShockDoor(myObj,0,0,2406);
		
		myObj= CreateGameObject("CRATE_20_52_01_0545",24.407812f,1.575000f,63.070313f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1402",true);
		
		myObj= CreateGameObject("MEDIPATCH__HEALING_AGENT_22_52_01_0343",26.980000f,1.350000f,62.980000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0209",true);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,"guis/assets/hud/inventory_icons/NOTHING.tga",18,66, 0);
		
		myObj= CreateGameObject("SCREEN_28_52_01_0543",34.195313f,2.981250f,62.419998f);
		CreateComputerScreen(myObj,51,4,0);
		SetRotation(myObj,(float)-0.000000,(float)180.000000,(float)0.000000);
		
		myObj= CreateGameObject("SCREEN_29_52_01_0544",35.395313f,3.000000f,62.419998f);
		CreateComputerScreen(myObj,89,4,0);
		SetRotation(myObj,(float)-0.000000,(float)180.000000,(float)0.000000);
		
		myObj = new GameObject("CYBORG_DRONE_30_52_01_0358");
		pos = new Vector3(36.557812f, 1.650000f, 62.995312f);
		myObj.transform.position = pos;
		CreateNPC(myObj,"460","Sprites/objects_1350_1604");
		
		myObj= CreateGameObject("SCREEN_30_52_01_0542",36.595314f,3.000000f,62.419998f);
		CreateComputerScreen(myObj,31,4,0);
		SetRotation(myObj,(float)-0.000000,(float)180.000000,(float)0.000000);
		
		myObj= CreateGameObject("BUTTON_30_52_01_0541",37.195313f,2.118750f,63.107811f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_0889",false);
		CreateSHOCKActivators(myObj,9);
		AddACTION_MOVING_PLATFORM(myObj, 25, 51, 25, -19, 2);
		SetRotation(myObj,(float)-0.000000,(float)90.000000,(float)0.000000);
		
		myObj= CreateGameObject("TOXIC_WASTE_BARREL_31_52_01_0637",37.907814f,0.393750f,63.407814f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1410",true);
		
		myObj= CreateGameObject("TOXIC_WASTE_BARREL_32_52_01_0634",38.980000f,0.393750f,62.980000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1410",true);
		
		myObj= CreateGameObject("CRATE_20_53_01_0547",24.670313f,1.387500f,63.857811f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1400",true);
		
		myObj= CreateGameObject("CRATE_21_53_01_0546",25.780001f,1.575000f,64.180000f);
		CreateObjectGraphics(myObj,"Sprites/objects_1350_1402",true);
		
		myObj= CreateGameObject("CHEMICAL_TANK_31_53_01_0631",37.779999f,0.393750f,64.180000f);
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
}
