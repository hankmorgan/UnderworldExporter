using UnityEngine;
using System.Collections;

public class FishingPole : object_base {

public override bool use ()
	{
		if (objInt.PickedUp==true)
		{
			if (playerUW.playerInventory.ObjectInHand=="")
			{
				GoFish();
				return true;
			}
			else
			{
				return FailMessage();//No use on behaviour for this object.
			}
		}
		else
		{
			return false;
		}

	}


	private void GoFish()
	{
		int tileX=(int)(playerUW.transform.position.x/1.2f);
		int tileY=(int)(playerUW.transform.position.z/1.2f);
	

		for (int x=-1; x<=1;x++)
		{//test the tile and it's neighbours for water.
			for (int y=-1; y<=1;y++)
			{
				if (GameWorldController.instance.Tilemap.isWater[tileX+x,tileY+y])
				{
					if (Random.Range (0,10)>=7)
					{//catch something or test for encumerance
						//000~001~099~You catch a lovely fish.
						//000~001~102~You feel a nibble, but the fish gets away.
						ml.Add (playerUW.StringControl.GetString (1,99));
						GameObject fishy = CreateFish();
						playerUW.playerInventory.ObjectInHand=fishy.name;
						ObjectInteraction FishobjInt = fishy.GetComponent<ObjectInteraction>();
						if (FishobjInt!=null)
						{
							FishobjInt.UpdateAnimation();
							playerUW.CursorIcon= FishobjInt.InventoryDisplay.texture;
						}

						UWCharacter.InteractionMode=UWCharacter.InteractionModePickup;
						InteractionModeControl.UpdateNow=true;
					}
					else
					{//000~001~100~No luck this time.
						ml.Add (playerUW.StringControl.GetString (1,100));
					}
					return;
				}
			}
		}
		//000~001~101~You cannot fish there.  Perhaps somewhere else.
		ml.Add (playerUW.StringControl.GetString (1,101));
	}


	GameObject CreateFish()
	{//Create food

		//int ObjectNo = 182;
		GameObject myObj=  new GameObject("SummonedObject_" + playerUW.PlayerMagic.SummonCount++);
		myObj.layer=LayerMask.NameToLayer("UWObjects");
		myObj.transform.position = playerUW.playerInventory.InventoryMarker.transform.position;
		myObj.transform.parent=playerUW.playerInventory.InventoryMarker.transform;
		CreateObjectGraphics(myObj,"Sprites/OBJECTS_182",true);
		//CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_" +ObjectNo, "Sprites/OBJECTS_"+ObjectNo, "Sprites/OBJECTS_"+ObjectNo, ObjectInteraction.FOOD, ObjectNo, 1, 40, 0, 1, 0, 1);
		CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_182", "Sprites/OBJECTS_182", "Sprites/OBJECTS_182", ObjectInteraction.FOOD, 182, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);

		Food fd = myObj.AddComponent<Food>();
		fd.Nutrition=5;//TODO:determine values to use here.
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
			WindowDetectUW.FreezeMovement(myObj);
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


}
