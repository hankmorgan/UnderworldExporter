#include <fbxsdk.h>
#include "tilemap.h"
#include "gameobjects.h"
#include "main.h"
#include "fbxExport.h"
#include "gameobjectsrender.h"
#include "textures.h"
#include <vector>

int PrimCount=0;


//FbxSurfacePhong* gMaterial[280];// = NULL;
bool InitializeSdkObjects(FbxManager*& pManager, FbxScene*& pScene);
void DestroySdkObjects(FbxManager* pManager, bool pExitStatus);
void SetInitialCubeData();
bool SaveScene(FbxManager* pSdkManager, FbxDocument* pScene, const char* pFilename, int pFileFormat, bool pEmbedMedia);
void RenderFBXTile(FbxScene*& gScene, int game, int x, int y, tile &t, short Water, short invert, short skipFloor, short skipCeil);
void RenderFBXSolidTile(FbxScene*& gScene, int x, int y, tile &t, short Water);
void RenderFBXOpenTile(FbxScene*& gScene, int x, int y, tile &t, short Water, short invert);
void RenderFBXCuboid(FbxScene*& gScene, int x, int y, tile &t, short Water, int Bottom, int Top, char *TileName);
void RenderFBXCuboid(FbxScene*& gScene, int x, int y, tile &t, short Water, int Bottom, int Top, char *TileName,
	FbxVector4 lControlPoint0,
	FbxVector4 lControlPoint1,
	FbxVector4 lControlPoint2,
	FbxVector4 lControlPoint3,
	FbxVector4 lControlPoint4,
	FbxVector4 lControlPoint5,
	FbxVector4 lControlPoint6,
	FbxVector4 lControlPoint7,
	float HorzOffsetEastPos, float HorzOffsetEastScale,
	float HorzOffsetWestPos, float HorzOffsetWestScale,
	float HorzOffsetNorthPos, float HorzOffsetNorthScale,
	float HorzOffsetSouthPos, float HorzOffsetSouthScale
	);

void RenderFBXCuboid(FbxScene*& gScene, int x, int y, tile &t, short Water, int Bottom, int Top, char *TileName,
	FbxVector4 lControlPoint0,
	FbxVector4 lControlPoint1,
	FbxVector4 lControlPoint2,
	FbxVector4 lControlPoint3,
	FbxVector4 lControlPoint4,
	FbxVector4 lControlPoint5,
	FbxVector4 lControlPoint6,
	FbxVector4 lControlPoint7,
	float VertOffsetPos, float VertOffsetScale
	);
void RenderFBXDiagSEPortion(FbxScene*& gScene, int Bottom, int Top, tile t, char *TileName);
void RenderFBXDiagSWPortion(FbxScene*& gScene, int Bottom, int Top, tile t, char *TileName);
void RenderFBXDiagNWPortion(FbxScene*& gScene, int Bottom, int Top, tile t, char *TileName);
void RenderFBXDiagNEPortion(FbxScene*& gScene, int Bottom, int Top, tile t, char *TileName);
void RenderFBXDiagSETile(FbxScene*& gScene, int x, int y, tile &t, short Water, short invert);
void RenderFBXDiagSWTile(FbxScene*& gScene, int x, int y, tile &t, short Water, short invert);
void RenderFBXDiagNWTile(FbxScene*& gScene, int x, int y, tile &t, short Water, short invert);
void RenderFBXDiagNETile(FbxScene*& gScene, int x, int y, tile &t, short Water, short invert);
void RenderFBXSlopeNTile(FbxScene*& gScene, int x, int y, tile &t, short Water, short invert);
void RenderFBXSlopeSTile(FbxScene*& gScene, int x, int y, tile &t, short Water, short invert);
void RenderFBXSlopeETile(FbxScene*& gScene, int x, int y, tile &t, short Water, short invert);
void RenderFBXSlopeWTile(FbxScene*& gScene, int x, int y, tile &t, short Water, short invert);
void RenderFBXRidgeSETile(FbxScene*& gScene, int x, int y, tile &t, short Water, short invert);
void RenderFBXRidgeNETile(FbxScene*& gScene, int x, int y, tile &t, short Water, short invert);
void RenderFBXRidgeSWTile(FbxScene*& gScene, int x, int y, tile &t, short Water, short invert);
void RenderFBXRidgeNWTile(FbxScene*& gScene, int x, int y, tile &t, short Water, short invert);
void RenderFBXValleyNETile(FbxScene*& gScene, int x, int y, tile &t, short Water, short invert);
void RenderFBXValleySETile(FbxScene*& gScene, int x, int y, tile &t, short Water, short invert);
void RenderFBXValleySWTile(FbxScene*& gScene, int x, int y, tile &t, short Water, short invert);
void RenderFBXValleyNWTile(FbxScene*& gScene, int x, int y, tile &t, short Water, short invert);
//void RenderSlopedFBXCuboid(FbxScene*& gScene, int x, int y, tile &t, short Water, int Bottom, int Top, int SlopeDir, int Steepness, int Floor);
void RenderSlopedFBXCuboid(FbxScene*& gScene, int x, int y, tile &t, short Water, int Bottom, int Top, int SlopeDir, int Steepness, int Floor, char *TileName);
void CreateFBXMaterials(FbxScene*& gScene, int game);
int FloorTexture(FbxScene*& gScene, FbxNode*& lNode, int face, tile t);
int WallTexture(FbxScene*& gScene, FbxNode*& lNode, int face, tile t);
void RenderFBXPlane(FbxScene*& gScene, int x, int y, tile &t, short Water, int Bottom, int Top, char *TileName, int face, int Surface
	, int CP0_x, int  CP0_Y, int CP0_Z
	, int CP1_x, int  CP1_Y, int CP1_Z
	, int CP2_x, int  CP2_Y, int CP2_Z
	, int CP3_x, int  CP3_Y, int CP3_Z
	, FbxVector4 Normal
	);
void insertTexture(int *texArray, int targetIndex, int textureNo, int arraysize);
float CalcCeilOffset(int game, int face, tile &t);
void RenderFBXDoorway(FbxScene*& gScene, int game, int x, int y, tile &t, ObjectItem currDoor);
void RenderFBXPillars(FbxScene*& gScene, int game, tile LevelInfo[64][64], ObjectItem objList[1600]);
void RenderFBXBridges(FbxScene*& gScene, int game, tile LevelInfo[64][64], ObjectItem objList[1600]);
void RenderTerrainChangeTiles(FbxScene*& gScene, int game, tile LevelInfo[64][64], ObjectItem objList[1600]);
void CreateDoorModel(FbxScene*& gScene);
void CreateShockBridgeModel(FbxScene*& gScene);

//
//int    gCubeNumber = 1;     // Cube Number
//int    gCubeRotationAxis = 1;     // Cube Rotation Axis 0==X, 1==Y, 2==Z
//double gCubeXPos = 0.0;   // initial CubXPos
//double gCubeYPos = 20.0;  // initial CubeYPos
//double gCubeZPos = 0.0;   // initial CubeZPos


//FbxAnimLayer* gAnimLayer = NULL;  // holder of animation curves
//FbxString* gAppPath = NULL;     // path where the application started

/* Tab character ("\t") counter */
int numTabs = 0;

extern int iGame;
extern long SHOCK_CEILING_HEIGHT;
extern long UW_CEILING_HEIGHT;

///**
//* Print the required number of tabs.
//*/
//void PrintTabs() {
//	for (int i = 0; i < numTabs; i++)
//		printf("\t");
//	}
//
///**
//* Return a string-based representation based on the attribute type.
//*/
//FbxString GetAttributeTypeName(FbxNodeAttribute::EType type) {
//	switch (type) {
//			case FbxNodeAttribute::eUnknown: return "unidentified";
//			case FbxNodeAttribute::eNull: return "null";
//			case FbxNodeAttribute::eMarker: return "marker";
//			case FbxNodeAttribute::eSkeleton: return "skeleton";
//			case FbxNodeAttribute::eMesh: return "mesh";
//			case FbxNodeAttribute::eNurbs: return "nurbs";
//			case FbxNodeAttribute::ePatch: return "patch";
//			case FbxNodeAttribute::eCamera: return "camera";
//			case FbxNodeAttribute::eCameraStereo: return "stereo";
//			case FbxNodeAttribute::eCameraSwitcher: return "camera switcher";
//			case FbxNodeAttribute::eLight: return "light";
//			case FbxNodeAttribute::eOpticalReference: return "optical reference";
//			case FbxNodeAttribute::eOpticalMarker: return "marker";
//			case FbxNodeAttribute::eNurbsCurve: return "nurbs curve";
//			case FbxNodeAttribute::eTrimNurbsSurface: return "trim nurbs surface";
//			case FbxNodeAttribute::eBoundary: return "boundary";
//			case FbxNodeAttribute::eNurbsSurface: return "nurbs surface";
//			case FbxNodeAttribute::eShape: return "shape";
//			case FbxNodeAttribute::eLODGroup: return "lodgroup";
//			case FbxNodeAttribute::eSubDiv: return "subdiv";
//			default: return "unknown";
//		}
//	}
//
//
//
///**
//* Print an attribute.
//*/
//void PrintAttribute(FbxNodeAttribute* pAttribute) {
//	if (!pAttribute) return;
//
//	FbxString typeName = GetAttributeTypeName(pAttribute->GetAttributeType());
//	FbxString attrName = pAttribute->GetName();
//	PrintTabs();
//	// Note: to retrieve the character array of a FbxString, use its Buffer() method.
//	printf("<attribute type='%s' name='%s'/>\n", typeName.Buffer(), attrName.Buffer());
//	}
//
//
///**
//* Print a node, its attributes, and all its children recursively.
//*/
//void PrintNode(FbxNode* pNode) {
//	PrintTabs();
//	const char* nodeName = pNode->GetName();
//	FbxDouble3 translation = pNode->LclTranslation.Get();
//	FbxDouble3 rotation = pNode->LclRotation.Get();
//	FbxDouble3 scaling = pNode->LclScaling.Get();
//
//	// Print the contents of the node.
//	printf("<node name='%s' translation='(%f, %f, %f)' rotation='(%f, %f, %f)' scaling='(%f, %f, %f)'>\n",
//		nodeName,
//		translation[0], translation[1], translation[2],
//		rotation[0], rotation[1], rotation[2],
//		scaling[0], scaling[1], scaling[2]
//		);
//	numTabs++;
//
//	// Print the node's attributes.
//	for (int i = 0; i < pNode->GetNodeAttributeCount(); i++)
//		PrintAttribute(pNode->GetNodeAttributeByIndex(i));
//
//	// Recursively print the children.
//	for (int j = 0; j < pNode->GetChildCount(); j++)
//		PrintNode(pNode->GetChild(j));
//
//	numTabs--;
//	PrintTabs();
//	printf("</node>\n");
//	}
//
//
//
//void FBXTest()
//	{
//
//	// Change the following filename to a suitable filename value.
//	const char* lFilename = "uw1_1.fbx";
//
//	// Initialize the SDK manager. This object handles all our memory management.
//	FbxManager* lSdkManager = FbxManager::Create();
//
//	// Create the IO settings object.
//	FbxIOSettings *ios = FbxIOSettings::Create(lSdkManager, IOSROOT);
//	lSdkManager->SetIOSettings(ios);
//
//	// Create an importer using the SDK manager.
//	FbxImporter* lImporter = FbxImporter::Create(lSdkManager, "");
//
//	// Use the first argument as the filename for the importer.
//	if (!lImporter->Initialize(lFilename, -1, lSdkManager->GetIOSettings())) {
//		printf("Call to FbxImporter::Initialize() failed.\n");
//		printf("Error returned: %s\n\n", lImporter->GetStatus().GetErrorString());
//		exit(-1);
//		}
//
//	// Create a new scene so that it can be populated by the imported file.
//	FbxScene* lScene = FbxScene::Create(lSdkManager, "myScene");
//
//	// Import the contents of the file into the scene.
//	lImporter->Import(lScene);
//
//	// The file is imported; so get rid of the importer.
//	lImporter->Destroy();
//
//	// Print the nodes of the scene and their attributes recursively.
//	// Note that we are not printing the root node because it should
//	// not contain any attributes.
//	FbxNode* lRootNode = lScene->GetRootNode();
//	if (lRootNode) {
//		for (int i = 0; i < lRootNode->GetChildCount(); i++)
//			PrintNode(lRootNode->GetChild(i));
//		}
//	// Destroy the SDK manager and all the other objects it was handling.
//	lSdkManager->Destroy();
//	}
//
//void FBXExport()
//	{
//
//	// Initialize the FbxManager and the FbxScene
//	if (InitializeSdkObjects(gSdkManager, gScene) == false)
//		{
//		return;
//		}
//
//	// create a marker
//	FbxNode* lMarker = CreateMarker(gScene, "Marker");
//
//	// create a camera
//	FbxNode* lCamera = CreateCamera(gScene, "Camera");
//
//	// create a single texture shared by all cubes
//	CreateTexture(gScene);
//	CreateTexture2(gScene);
//	// create a material shared by all faces of all cubes
//	CreateMaterial(gScene);
//	CreateMaterial2(gScene);
//	// set the camera point of interest on the marker
//	SetCameraPointOfInterest(lCamera, lMarker);
//
//	// set the marker position
//	SetMarkerDefaultPosition(lMarker);
//
//	// set the camera position
//	SetCameraDefaultPosition(lCamera);
//
//	// animate the camera
//	//AnimateCamera(lCamera, gAnimLayer);
//
//	// build a minimum scene graph
//	FbxNode* lRootNode = gScene->GetRootNode();
//	lRootNode->AddChild(lMarker);
//	lRootNode->AddChild(lCamera);
//
//
//	// create a new cube with option selected
//	CreateCube(1, 0);
//
//	SaveScene(gSdkManager, gScene, "fbx_output.fbx", 0, true); // true -> embed texture file
//
//	return;
//
//
//	}



bool InitializeSdkObjects(FbxManager*& pManager, FbxScene*& pScene)
	{
	//The first thing to do is to create the FBX Manager which is the object allocator for almost all the classes in the SDK
	pManager = FbxManager::Create();
	if (!pManager)
		{
		FBXSDK_printf("Error: Unable to create FBX Manager!\n");
		exit(1);
		}
	else FBXSDK_printf("Autodesk FBX SDK version %s\n", pManager->GetVersion());

	//Create an IOSettings object. This object holds all import/export settings.
	FbxIOSettings* ios = FbxIOSettings::Create(pManager, IOSROOT);
	pManager->SetIOSettings(ios);

	//Create an FBX scene. This object holds most objects imported/exported from/to files.
	pScene = FbxScene::Create(pManager, "My Scene");
	if (!pScene)
		{
		FBXSDK_printf("Error: Unable to create FBX scene!\n");
		exit(1);
		}
	return true;
	}

void DestroySdkObjects(FbxManager* pManager, bool pExitStatus)
	{
	//Delete the FBX Manager. All the objects that have been allocated using the FBX Manager and that haven't been explicitly destroyed are also automatically destroyed.
	if (pManager) pManager->Destroy();
	if (pExitStatus) FBXSDK_printf("Program Success!\n");
	}


//// Create a global texture for cube.
//void CreateTexture(FbxScene* pScene)
//	{
//	gTexture = FbxFileTexture::Create(pScene, "Diffuse Texture");
//
//	// Resource file must be in the application's directory.
//	//FbxString lTexPath = gAppPath ? *gAppPath + "\\uw1_000.jpg" : "";
//	FbxString lTexPath = "uw1_000.jpg";
//
//	// Set texture properties.
//	gTexture->SetFileName(lTexPath.Buffer());
//	gTexture->SetTextureUse(FbxTexture::eStandard);
//	gTexture->SetMappingType(FbxTexture::eUV);
//	gTexture->SetMaterialUse(FbxFileTexture::eModelMaterial);
//	gTexture->SetSwapUV(false);
//	gTexture->SetTranslation(0.0, 0.0);
//	gTexture->SetScale(1.0, 1.0);
//	gTexture->SetRotation(0.0, 0.0);
//	}
//
//// Create a global texture for cube.
//void CreateTexture2(FbxScene* pScene)
//	{
//	gTexture2 = FbxFileTexture::Create(pScene, "Diffuse Texture2");
//
//	// Resource file must be in the application's directory.
//	//FbxString lTexPath = gAppPath ? *gAppPath + "\\uw1_261.tga" : "";
//	FbxString lTexPath = "uw1_261.tga";
//
//	// Set texture properties.
//	gTexture2->SetFileName(lTexPath.Buffer());
//	gTexture2->SetTextureUse(FbxTexture::eStandard);
//	gTexture2->SetMappingType(FbxTexture::eUV);
//	gTexture2->SetMaterialUse(FbxFileTexture::eModelMaterial);
//	gTexture2->SetSwapUV(false);
//	gTexture2->SetTranslation(0.0, 0.0);
//	gTexture2->SetScale(1.0, 1.0);
//	gTexture2->SetRotation(0.0, 0.0);
//	}
//
//
//// Set target of the camera.
//void SetCameraPointOfInterest(FbxNode* pCamera, FbxNode* pPointOfInterest)
//	{
//	// Set the camera to always point at this node.
//	pCamera->SetTarget(pPointOfInterest);
//	}
//
//// Set marker default position.
//void SetMarkerDefaultPosition(FbxNode* pMarker)
//	{
//	// The marker is positioned above the origin. There is no rotation and no scaling.
//	pMarker->LclTranslation.Set(FbxVector4(0.0, 40.0, 0.0));
//	pMarker->LclRotation.Set(FbxVector4(0.0, 0.0, 0.0));
//	pMarker->LclScaling.Set(FbxVector4(1.0, 1.0, 1.0));
//	}
//
//// Compute the camera position.
//void SetCameraDefaultPosition(FbxNode* pCamera)
//	{
//	// set the initial camera position
//	FbxVector4 lCameraLocation(0.0, 200.0, -100.0);
//	pCamera->LclTranslation.Set(lCameraLocation);
//	}
//
//// Create global material for cube.
//void CreateMaterial(FbxScene* pScene)
//	{
//	FbxString lMaterialName = "material";
//	FbxString lShadingName = "Phong";
//	FbxDouble3 lBlack(0.0, 0.0, 0.0);
//	FbxDouble3 lRed(1.0, 0.0, 0.0);
//	FbxDouble3 lDiffuseColor(0.75, 0.75, 0.0);
//	gMaterial = FbxSurfacePhong::Create(pScene, lMaterialName.Buffer());
//
//	// Generate primary and secondary colors.
//	gMaterial->Emissive.Set(lBlack);
//	gMaterial->Ambient.Set(lRed);
//	gMaterial->Diffuse.Set(lDiffuseColor);
//	gMaterial->TransparencyFactor.Set(40.5);
//	gMaterial->ShadingModel.Set(lShadingName);
//	gMaterial->Shininess.Set(0.5);
//
//	// the texture need to be connected to the material on the corresponding property
//	if (gTexture)
//		gMaterial->Diffuse.ConnectSrcObject(gTexture);
//	}

//void AddMaterials(FbxMesh* pMesh)
//	{
//	FbxSurfacePhong* gMaterial = NULL;
//	// Set material mapping.
//	FbxGeometryElementMaterial* lMaterialElement = pMesh->CreateElementMaterial();
//	lMaterialElement->SetMappingMode(FbxGeometryElement::eByPolygon);
//	lMaterialElement->SetReferenceMode(FbxGeometryElement::eIndexToDirect);
//
//	//get the node of mesh, add material for it.
//	FbxNode* lNode = pMesh->GetNode();
//	if (lNode == NULL)
//		return;
//	lNode->AddMaterial(gMaterial);
//	//lNode->AddMaterial(gMaterial2);
//	// We are in eByPolygon, so there's only need for 6 index (a cube has 6 polygons).
//	lMaterialElement->GetIndexArray().SetCount(6);
//
//	// Set the Index 0 to 6 to the material in position 0 of the direct array.
//	for (int i = 0; i<6; ++i)
//	if (i == 0)
//		{
//		lMaterialElement->GetIndexArray().SetAt(i, 1);
//		}
//	else
//		{
//		lMaterialElement->GetIndexArray().SetAt(i, 0);
//		}
//		
//	}



//// Create global material for cube.
//void CreateMaterial2(FbxScene* pScene)
//	{
//	FbxString lMaterialName = "material2";
//	FbxString lShadingName = "Phong";
//	FbxDouble3 lBlack(0.0, 0.0, 0.0);
//	FbxDouble3 lRed(1.0, 0.0, 0.0);
//	FbxDouble3 lDiffuseColor(0.75, 0.75, 0.0);
//	gMaterial2 = FbxSurfacePhong::Create(pScene, lMaterialName.Buffer());
//
//	// Generate primary and secondary colors.
//	gMaterial2->Emissive.Set(lBlack);
//	gMaterial2->Ambient.Set(lRed);
//	gMaterial2->Diffuse.Set(lDiffuseColor);
//	gMaterial2->TransparencyFactor.Set(40.5);
//	gMaterial2->ShadingModel.Set(lShadingName);
//	gMaterial2->Shininess.Set(0.5);
//
//	// the texture need to be connected to the material on the corresponding property
//	if (gTexture2)
//		gMaterial2->Diffuse.ConnectSrcObject(gTexture2);
//	}
//
//// Reset camera values
//void SetInitialCubeData()
//	{
//	gCubeNumber = 1;     // Cube Number
//	gCubeRotationAxis = 1;     // Cube Rotation Axis 0==X, 1==Y, 2==Z
//	gCubeXPos = 0.0;   // initial CubXPos
//	gCubeYPos = 20.0;  // initial CubeYPos
//	gCubeZPos = 0.0;   // initial CubeZPos
//	}
//
//// Create a marker to use a point of interest for the camera. 
//FbxNode* CreateMarker(FbxScene* pScene, char* pName)
//	{
//	FbxMarker* lMarker = FbxMarker::Create(pScene, pName);
//
//	FbxNode* lNode = FbxNode::Create(pScene, pName);
//
//	lNode->SetNodeAttribute(lMarker);
//
//	return lNode;
//	}
//
//// Create a camera.
//FbxNode* CreateCamera(FbxScene* pScene, char* pName)
//	{
//	FbxCamera* lCamera = FbxCamera::Create(pScene, pName);
//
//	// Set camera property for a classic TV projection with aspect ratio 4:3
//	lCamera->SetFormat(FbxCamera::eNTSC);
//
//	FbxNode* lNode = FbxNode::Create(pScene, pName);
//
//	lNode->SetNodeAttribute(lCamera);
//
//	return lNode;
//	}
//
//
//// create a new cube
//void CreateCube(bool pWithTexture, bool pAnimate)
//	{
//	// make a new cube name
//	FbxString lCubeName = "Cube number ";
//	lCubeName += FbxString(gCubeNumber);
//
//	// create a new cube
//	CreateCubeDetailed(lCubeName.Buffer(),
//		gCubeXPos,
//		gCubeYPos,
//		gCubeZPos,
//		gCubeRotationAxis,
//		pWithTexture,
//		pAnimate
//		);
//
//	// compute for next cube creation    
//	gCubeNumber++; // cube number
//
//	// set next pos
//	if (gCubeXPos >= 0.0)
//		{
//		gCubeXPos += 50.0;
//		gCubeXPos *= -1.0;
//		gCubeRotationAxis++; // change rotation axis
//		}
//	else
//		{
//		gCubeXPos *= -1.0;
//		}
//
//	// go up
//	gCubeYPos += 30.0;
//
//	if (gCubeRotationAxis > 2) gCubeRotationAxis = 0; // cube rotation
//	}
//
//
//// create a new cube
//void CreateCubeDetailed(char* pCubeName,
//	double pX,
//	double pY,
//	double pZ,
//	int pRotateAxe,
//	bool pWithTexture,
//	bool pAnimate
//	)
//	{
//	FbxNode* lCube = CreateCubeMesh(gScene, pCubeName);
//
//	// set the cube position
//	lCube->LclTranslation.Set(FbxVector4(pX, pY, pZ));
//
//	//if (pAnimate)
//	//	{
//	//	AnimateCube(lCube, gAnimLayer, pRotateAxe);
//	//	}
//
//	if (pWithTexture)
//		{
//		// if we asked to create the cube with a texture, we need 
//		// a material present because the texture connects to the
//		// material DiffuseColor property
//		AddMaterials(lCube->GetMesh());
//		}
//
//	gScene->GetRootNode()->AddChild(lCube);
//	}
//
//
//// Create a cube mesh. 
//FbxNode* CreateCubeMesh(FbxScene* pScene, char* pName)
//	{
//	int i, j;
//	FbxMesh* lMesh = FbxMesh::Create(pScene, pName);
//
//	FbxVector4 lControlPoint0(-50, 0, 50);
//	FbxVector4 lControlPoint1(50, 0, 50);
//	FbxVector4 lControlPoint2(50, 100, 50);
//	FbxVector4 lControlPoint3(-50, 100, 50);
//	FbxVector4 lControlPoint4(-50, 0, -50);
//	FbxVector4 lControlPoint5(50, 0, -50);
//	FbxVector4 lControlPoint6(50, 100, -50);
//	FbxVector4 lControlPoint7(-50, 100, -50);
//
//	FbxVector4 lNormalXPos(1, 0, 0);
//	FbxVector4 lNormalXNeg(-1, 0, 0);
//	FbxVector4 lNormalYPos(0, 1, 0);
//	FbxVector4 lNormalYNeg(0, -1, 0);
//	FbxVector4 lNormalZPos(0, 0, 1);
//	FbxVector4 lNormalZNeg(0, 0, -1);
//
//	// Create control points.
//	lMesh->InitControlPoints(24);
//	FbxVector4* lControlPoints = lMesh->GetControlPoints();
//
//	lControlPoints[0] = lControlPoint0;
//	lControlPoints[1] = lControlPoint1;
//	lControlPoints[2] = lControlPoint2;
//	lControlPoints[3] = lControlPoint3;
//	lControlPoints[4] = lControlPoint1;
//	lControlPoints[5] = lControlPoint5;
//	lControlPoints[6] = lControlPoint6;
//	lControlPoints[7] = lControlPoint2;
//	lControlPoints[8] = lControlPoint5;
//	lControlPoints[9] = lControlPoint4;
//	lControlPoints[10] = lControlPoint7;
//	lControlPoints[11] = lControlPoint6;
//	lControlPoints[12] = lControlPoint4;
//	lControlPoints[13] = lControlPoint0;
//	lControlPoints[14] = lControlPoint3;
//	lControlPoints[15] = lControlPoint7;
//	lControlPoints[16] = lControlPoint3;
//	lControlPoints[17] = lControlPoint2;
//	lControlPoints[18] = lControlPoint6;
//	lControlPoints[19] = lControlPoint7;
//	lControlPoints[20] = lControlPoint1;
//	lControlPoints[21] = lControlPoint0;
//	lControlPoints[22] = lControlPoint4;
//	lControlPoints[23] = lControlPoint5;
//
//	// We want to have one normal for each vertex (or control point),
//	// so we set the mapping mode to eByControlPoint.
//	FbxGeometryElementNormal* lGeometryElementNormal = lMesh->CreateElementNormal();
//
//	lGeometryElementNormal->SetMappingMode(FbxGeometryElement::eByControlPoint);
//
//	// Set the normal values for every control point.
//	lGeometryElementNormal->SetReferenceMode(FbxGeometryElement::eDirect);
//
//	lGeometryElementNormal->GetDirectArray().Add(lNormalZPos);
//	lGeometryElementNormal->GetDirectArray().Add(lNormalZPos);
//	lGeometryElementNormal->GetDirectArray().Add(lNormalZPos);
//	lGeometryElementNormal->GetDirectArray().Add(lNormalZPos);
//	lGeometryElementNormal->GetDirectArray().Add(lNormalXPos);
//	lGeometryElementNormal->GetDirectArray().Add(lNormalXPos);
//	lGeometryElementNormal->GetDirectArray().Add(lNormalXPos);
//	lGeometryElementNormal->GetDirectArray().Add(lNormalXPos);
//	lGeometryElementNormal->GetDirectArray().Add(lNormalZNeg);
//	lGeometryElementNormal->GetDirectArray().Add(lNormalZNeg);
//	lGeometryElementNormal->GetDirectArray().Add(lNormalZNeg);
//	lGeometryElementNormal->GetDirectArray().Add(lNormalZNeg);
//	lGeometryElementNormal->GetDirectArray().Add(lNormalXNeg);
//	lGeometryElementNormal->GetDirectArray().Add(lNormalXNeg);
//	lGeometryElementNormal->GetDirectArray().Add(lNormalXNeg);
//	lGeometryElementNormal->GetDirectArray().Add(lNormalXNeg);
//	lGeometryElementNormal->GetDirectArray().Add(lNormalYPos);
//	lGeometryElementNormal->GetDirectArray().Add(lNormalYPos);
//	lGeometryElementNormal->GetDirectArray().Add(lNormalYPos);
//	lGeometryElementNormal->GetDirectArray().Add(lNormalYPos);
//	lGeometryElementNormal->GetDirectArray().Add(lNormalYNeg);
//	lGeometryElementNormal->GetDirectArray().Add(lNormalYNeg);
//	lGeometryElementNormal->GetDirectArray().Add(lNormalYNeg);
//	lGeometryElementNormal->GetDirectArray().Add(lNormalYNeg);
//
//
//	// Array of polygon vertices.
//	int lPolygonVertices[] = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13,
//		14, 15, 16, 17, 18, 19, 20, 21, 22, 23 };
//
//
//	// Create UV for Diffuse channel.
//	FbxGeometryElementUV* lUVDiffuseElement = lMesh->CreateElementUV("DiffuseUV");
//	FBX_ASSERT(lUVDiffuseElement != NULL);
//	lUVDiffuseElement->SetMappingMode(FbxGeometryElement::eByPolygonVertex);
//	lUVDiffuseElement->SetReferenceMode(FbxGeometryElement::eIndexToDirect);
//
//	FbxVector2 lVectors0(0, 0);
//	FbxVector2 lVectors1(1, 0);
//	FbxVector2 lVectors2(1, 1);
//	FbxVector2 lVectors3(0, 1);
//
//	lUVDiffuseElement->GetDirectArray().Add(lVectors0);
//	lUVDiffuseElement->GetDirectArray().Add(lVectors1);
//	lUVDiffuseElement->GetDirectArray().Add(lVectors2);
//	lUVDiffuseElement->GetDirectArray().Add(lVectors3);
//
//	//Now we have set the UVs as eIndexToDirect reference and in eByPolygonVertex  mapping mode
//	//we must update the size of the index array.
//	lUVDiffuseElement->GetIndexArray().SetCount(24);
//
//	// Create polygons. Assign texture and texture UV indices.
//	for (i = 0; i < 6; i++)
//		{
//		// all faces of the cube have the same texture
//		lMesh->BeginPolygon(-1, -1, -1, false);
//
//		for (j = 0; j < 4; j++)
//			{
//			// Control point index
//			lMesh->AddPolygon(lPolygonVertices[i * 4 + j]);
//
//			// update the index array of the UVs that map the texture to the face
//			lUVDiffuseElement->GetIndexArray().SetAt(i * 4 + j, j);
//			}
//
//		lMesh->EndPolygon();
//		}
//
//	// create a FbxNode
//	FbxNode* lNode = FbxNode::Create(pScene, pName);
//
//	// set the node attribute
//	lNode->SetNodeAttribute(lMesh);
//
//	// set the shading mode to view texture
//	lNode->SetShadingMode(FbxNode::eTextureShading);
//
//	// rescale the cube
//	lNode->LclScaling.Set(FbxVector4(0.3, 0.3, 0.3));
//
//	// return the FbxNode
//	return lNode;
//	}



	// to save a scene to a FBX file
	bool SaveScene(FbxManager* pSdkManager, FbxDocument* pScene, const char* pFilename, int pFileFormat, bool pEmbedMedia)
		{
		if (pSdkManager == NULL) return false;
		if (pScene == NULL) return false;
		if (pFilename == NULL) return false;

		bool lStatus = true;

		// Create an exporter.
		FbxExporter* lExporter = FbxExporter::Create(pSdkManager, "");

		if (pFileFormat < 0 || pFileFormat >= pSdkManager->GetIOPluginRegistry()->GetWriterFormatCount())
			{
			// Write in fall back format if pEmbedMedia is true
			pFileFormat = pSdkManager->GetIOPluginRegistry()->GetNativeWriterFormat();

			if (!pEmbedMedia)
				{
				//Try to export in ASCII if possible
				int lFormatIndex, lFormatCount = pSdkManager->GetIOPluginRegistry()->GetWriterFormatCount();

				for (lFormatIndex = 0; lFormatIndex<lFormatCount; lFormatIndex++)
					{
					if (pSdkManager->GetIOPluginRegistry()->WriterIsFBX(lFormatIndex))
						{
						FbxString lDesc = pSdkManager->GetIOPluginRegistry()->GetWriterFormatDescription(lFormatIndex);
						char *lASCII = "ascii";
						if (lDesc.Find(lASCII) >= 0)
							{
							pFileFormat = lFormatIndex;
							break;
							}
						}
					}
				}
			}

		// Initialize the exporter by providing a filename.
		if (lExporter->Initialize(pFilename, pFileFormat, pSdkManager->GetIOSettings()) == false)
			{
			return false;
			}

		// Set the export states. By default, the export states are always set to 
		// true except for the option eEXPORT_TEXTURE_AS_EMBEDDED. The code below 
		// shows how to change these states.
		//IOS_REF.SetBoolProp(EXP_FBX_MATERIAL, true);
		//IOS_REF.SetBoolProp(EXP_FBX_TEXTURE, true);
		//IOS_REF.SetBoolProp(EXP_FBX_EMBEDDED, pEmbedMedia);
		//IOS_REF.SetBoolProp(EXP_FBX_SHAPE, true);
		//IOS_REF.SetBoolProp(EXP_FBX_GOBO, true);
		//IOS_REF.SetBoolProp(EXP_FBX_ANIMATION, true);
		//IOS_REF.SetBoolProp(EXP_FBX_GLOBAL_SETTINGS, true);

		// Export the scene.
		lStatus = lExporter->Export(pScene);

		// Destroy the exporter.
		lExporter->Destroy();

		return lStatus;
		}

void RenderFBXLevel(tile LevelInfo[64][64], ObjectItem objList[1600], int game)
	{
	int x; int y;
	int skipCeil = 0;
	FbxManager*   gSdkManager = NULL;
	FbxScene*        gScene = NULL;
	iGame = game;
	//Levels use different ceiling heights.
	//Shock is variable, UW is fixed.
	switch (game)
		{
			case SHOCK:
				{
				CEILING_HEIGHT = SHOCK_CEILING_HEIGHT;
				break;
				}
			default://UW1&2
				{
				skipCeil = 1;
				CEILING_HEIGHT = UW_CEILING_HEIGHT;
				break;
				}
		}

	// Initialize the FbxManager and the FbxScene
	if (InitializeSdkObjects(gSdkManager, gScene) == false)
		{
		return;
		}

	CreateFBXMaterials(gScene,game);

	for (y = 0; y <= 63; y++)
		{
		for (x = 0; x <= 63; x++)
			{
				RenderFBXTile(gScene, game, x, y, LevelInfo[x][y], 0, 0, 0, skipCeil);
				RenderFBXTile(gScene, game, x, y, LevelInfo[x][y], 1, 0, 0, skipCeil);
			}

		}
	tile tmp;
	if (game != SHOCK)
		{
		//Ceiling
		tmp.tileType = 1;
		tmp.Render = 1;
		tmp.isWater = 0;
		tmp.tileX = 0;
		tmp.tileY = 0;
		tmp.DimX = 64;
		tmp.DimY = 64;
		tmp.ceilingHeight = 0;
		tmp.floorTexture = LevelInfo[0][0].shockCeilingTexture;
		tmp.shockCeilingTexture = LevelInfo[0][0].shockCeilingTexture;
		tmp.East = LevelInfo[0][0].shockCeilingTexture;//CAULK;
		tmp.West = LevelInfo[0][0].shockCeilingTexture;//CAULK;
		tmp.North = LevelInfo[0][0].shockCeilingTexture;//CAULK;
		tmp.South = LevelInfo[0][0].shockCeilingTexture;//CAULK;
		tmp.shockEastCeilHeight = 0;
		tmp.shockWestCeilHeight = 0;
		tmp.shockNorthCeilHeight = 0;
		tmp.shockSouthCeilHeight = 0;
		RenderFBXTile(gScene, game, x, y, tmp, 0, 0, 1, 0);
		}
//Tmp code for generating all materials into unity
//	for (int j = 0; j < 261; j++)
//		{
//		tmp.DimX=1;tmp.DimY=1;
//		tmp.North = j;
//		RenderFBXTile(gScene, game, 0, j, tmp, 0, 0, 1, 0);
//		}
	//Now render a room to store objects
	tmp.DimX = 1;
	tmp.DimY = 1;
	tmp.floorHeight = 0;
	for (x = 65; x < 68; x++)
		{
		for (y = 65; y < 68; y++)
			{
			tmp.tileX = x;
			tmp.tileY = y;
			if ((x != 66) || (y!=66))
				{
				tmp.tileType = 0;
				}
			else
				{
				tmp.tileType = 1;
				}
			RenderFBXTile(gScene, game, x, y, tmp, 0, 0, 0, 0);
			}
		}
//And at 99,99 for special stuff.
	for (x = 98; x < 101; x++)
		{
		for (y = 98; y < 101; y++)
			{
			tmp.tileX = x;
			tmp.tileY = y;
			if ((x != 99) || (y != 99))
				{
				tmp.tileType = 0;
				}
			else
				{
				tmp.tileType = 1;
				}
			RenderFBXTile(gScene, game, x, y, tmp, 0, 0, 0, 0);
			}
		}

//Render doors
	if (game != SHOCK)
		{
		for (y = 0; y <= 63; y++)
			{
			for (x = 0; x <= 63; x++)
				{
				if ((LevelInfo[x][y].hasElevator == 0))//Elevators are rendered as func_statics
					{
					if (LevelInfo[x][y].isDoor == 1)
						{//Adds a UW door frame.
						RenderFBXDoorway(gScene,game, x, y, LevelInfo[x][y], objList[LevelInfo[x][y].DoorIndex]);
						}
					}
				}
			}
		}

//Render Pillars
	if (game != SHOCK)
		{
		RenderFBXBridges(gScene, game, LevelInfo, objList);
		RenderFBXPillars(gScene,game,LevelInfo,objList);
		RenderTerrainChangeTiles(gScene,game,LevelInfo,objList);
		}
	

	//CreateDoorModel(gScene);
	//CreateShockBridgeModel(gScene);
	SaveScene(gSdkManager, gScene, "level.fbx", 1, true);
	}

void RenderFBXTile(FbxScene*& gScene,int game, int x, int y, tile &t, short Water, short invert, short skipFloor, short skipCeil)
	{
	//Picks the tile to render based on tile type/flags.
	switch (t.tileType)
		{
			case TILE_SOLID:	//0
				{	//solid
				RenderFBXSolidTile(gScene, x, y, t, Water);
				return;
				}
			case TILE_OPEN:		//1
				{//open
				if (skipFloor != 1) { RenderFBXOpenTile(gScene,x, y, t, Water, 0); }	//floor
				if ((skipCeil != 1)) { RenderFBXOpenTile(gScene,x, y, t, Water, 1); }	//ceiling	
				return;
				}
			case 2:
				{//diag se
				if (skipFloor != 1) { RenderFBXDiagSETile(gScene, x, y, t, Water, 0); }//floor
				if ((skipCeil != 1)) { RenderFBXDiagSETile(gScene, x, y, t, Water, 1); }
				return;
				}

			case 3:
				{	//diag sw
				if (skipFloor != 1) { RenderFBXDiagSWTile(gScene, x, y, t, Water, 0); }//floor
				if ((skipCeil != 1)) { RenderFBXDiagSWTile(gScene, x, y, t, Water, 1); }
				return;
				}

			case 4:
				{	//diag ne
				if (skipFloor != 1) { RenderFBXDiagNETile(gScene, x, y, t, Water, invert); }//floor
				if ((skipCeil != 1)) { RenderFBXDiagNETile(gScene, x, y, t, Water, 1); }
				return;
				}

			case 5:
				{//diag nw
				if (skipFloor != 1) { RenderFBXDiagNWTile(gScene, x, y, t, Water, invert); }//floor
				if ((skipCeil != 1)) { RenderFBXDiagNWTile(gScene, x, y, t, Water, 1); }
				return;
				}

			case TILE_SLOPE_N:	//6
				{//slope n
				switch (t.shockSlopeFlag)
					{
						case SLOPE_BOTH_PARALLEL:
							{
							if (skipFloor != 1) { RenderFBXSlopeNTile(gScene, x, y, t, Water, 0); }//floor
							if ((skipCeil != 1)) { RenderFBXSlopeNTile(gScene, x, y, t, Water, 1); }
							break;
							}
						case SLOPE_BOTH_OPPOSITE:
							{
							if (skipFloor != 1) { RenderFBXSlopeNTile(gScene, x, y, t, Water, 0); }//floor
							if ((skipCeil != 1)) { RenderFBXSlopeSTile(gScene, x, y, t, Water, 1); }
							break;
							}
						case SLOPE_FLOOR_ONLY:
							{
							if (skipFloor != 1) { RenderFBXSlopeNTile(gScene, x, y, t, Water, 0); }//floor
							if ((skipCeil != 1)) { RenderFBXOpenTile(gScene,x, y, t, Water, 1); }	//ceiling
							break;
							}
						case SLOPE_CEILING_ONLY:
							{
							if (skipFloor != 1) { RenderFBXOpenTile(gScene, x, y, t, Water, 0); }	//floor
							RenderFBXSlopeNTile(gScene, x, y, t, Water, 1);
							break;
							}
					}
				return;
				}
			case TILE_SLOPE_S: //slope s	7
				{
				switch (t.shockSlopeFlag)
					{
						case SLOPE_BOTH_PARALLEL:
							{
							if (skipFloor != 1) { RenderFBXSlopeSTile(gScene, x, y, t, Water, 0); }	//floor
							RenderFBXSlopeSTile(gScene, x, y, t, Water, 1);
							break;
							}
						case SLOPE_BOTH_OPPOSITE:
							{
							if (skipFloor != 1) { RenderFBXSlopeSTile(gScene, x, y, t, Water, 0); }	//floor
							RenderFBXSlopeNTile(gScene, x, y, t, Water, 1);
							break;
							}
						case SLOPE_FLOOR_ONLY:
							{
							if (skipFloor != 1) { RenderFBXSlopeSTile(gScene, x, y, t, Water, 0); }	//floor
							if ((skipCeil != 1)) { RenderFBXOpenTile(gScene, x, y, t, Water, 1); }	//ceiling
							break;
							}
						case SLOPE_CEILING_ONLY:
							{
							if (skipFloor != 1) { RenderFBXOpenTile(gScene, x, y, t, Water, 0); }	//floor
							if ((skipCeil != 1)) { RenderFBXSlopeSTile(gScene, x, y, t, Water, 1); }
							break;
							}
					}
				return;
				}
			case TILE_SLOPE_E:		//slope e 8	
				{
				switch (t.shockSlopeFlag)
					{
						case SLOPE_BOTH_PARALLEL:
							{
							if (skipFloor != 1) { RenderFBXSlopeETile(gScene, x, y, t, Water, 0); }//floor
							RenderFBXSlopeETile(gScene, x, y, t, Water, 1);
							break;
							}
						case SLOPE_BOTH_OPPOSITE:
							{
							if (skipFloor != 1) { RenderFBXSlopeETile(gScene, x, y, t, Water, 0); }//floor
							RenderFBXSlopeWTile(gScene, x, y, t, Water, 1);
							break;
							}
						case SLOPE_FLOOR_ONLY:
							{
							if (skipFloor != 1) { RenderFBXSlopeETile(gScene, x, y, t, Water, 0); }//floor
							if ((skipCeil != 1)) { RenderFBXOpenTile(gScene, x, y, t, Water, 1); }	//ceiling
							break;
							}
						case SLOPE_CEILING_ONLY:
							{
							if (skipFloor != 1) { RenderFBXOpenTile(gScene, x, y, t, Water, 0); }	//floor
							if ((skipCeil != 1)) { RenderFBXSlopeETile(gScene, x, y, t, Water, 1); }
							break;
							}
					}
				return;
				}
			case TILE_SLOPE_W: 	//9
				{ //slope w
				switch (t.shockSlopeFlag)
					{
						case SLOPE_BOTH_PARALLEL:
							{
							if (skipFloor != 1) { RenderFBXSlopeWTile(gScene, x, y, t, Water, 0); }//floor
							if ((skipCeil != 1)) { RenderFBXSlopeWTile(gScene, x, y, t, Water, 1); }
							break;
							}
						case SLOPE_BOTH_OPPOSITE:
							{
							if (skipFloor != 1) { RenderFBXSlopeWTile(gScene, x, y, t, Water, 0); }//floor
							if ((skipCeil != 1)) { RenderFBXSlopeETile(gScene, x, y, t, Water, 1); }
							break;
							}
						case SLOPE_FLOOR_ONLY:
							{
							if (skipFloor != 1) { RenderFBXSlopeWTile(gScene, x, y, t, Water, 0); }//floor
							if ((skipCeil != 1)) { RenderFBXOpenTile(gScene, x, y, t, Water, 1); }	//ceiling
							break;
							}
						case SLOPE_CEILING_ONLY:
							{
							if (skipFloor != 1) { RenderFBXOpenTile(gScene, x, y, t, Water, 0); }	//floor
							if ((skipCeil != 1)) { RenderFBXSlopeWTile(gScene, x, y, t, Water, 1); }
							break;
							}
					}
				return;
				}
			case TILE_VALLEY_NW:
				{	//valleyNw(a)
				switch (t.shockSlopeFlag)
					{
						case SLOPE_BOTH_PARALLEL:
							{
							if (skipFloor != 1) { RenderFBXValleyNWTile(gScene, x, y, t, Water, 0); }//floor
							if ((skipCeil != 1)) { RenderFBXValleyNWTile(gScene, x, y, t, Water, 1); }
							break;
							}
						case SLOPE_BOTH_OPPOSITE:
							{
							if (skipFloor != 1) { RenderFBXValleyNWTile(gScene, x, y, t, Water, 0); }//floor
							if ((skipCeil != 1)) { RenderFBXValleySETile(gScene, x, y, t, Water, 1); }
							break;
							}
						case SLOPE_FLOOR_ONLY:
							{
							if (skipFloor != 1) { RenderFBXValleyNWTile(gScene, x, y, t, Water, 0); }//floor
							if ((skipCeil != 1)) { RenderFBXOpenTile(gScene, x, y, t, Water, 1); }	//ceiling
							break;
							}
						case SLOPE_CEILING_ONLY:
							{
							if (skipFloor != 1) { RenderFBXOpenTile(gScene, x, y, t, Water, 0); }	//floor
							if ((skipCeil != 1)) { RenderFBXValleyNWTile(gScene, x, y, t, Water, 1); }
							break;
							}
					}
				return;
				}
			case TILE_VALLEY_NE:
				{	//valleyne(b)
				switch (t.shockSlopeFlag)
					{
						case SLOPE_BOTH_PARALLEL:
							{
							if (skipFloor != 1) { RenderFBXValleyNETile(gScene, x, y, t, Water, 0); }//floor
							if ((skipCeil != 1)) { RenderFBXValleyNETile(gScene, x, y, t, Water, 1); }
							break;
							}
						case SLOPE_BOTH_OPPOSITE:
							{
							if (skipFloor != 1) { RenderFBXValleyNETile(gScene, x, y, t, Water, 0); }//floor
							if ((skipCeil != 1)) { RenderFBXValleySWTile(gScene, x, y, t, Water, 1); }
							break;
							}
						case SLOPE_FLOOR_ONLY:
							{
							if (skipFloor != 1) { RenderFBXValleyNETile(gScene, x, y, t, Water, 0); }//floor
							if ((skipCeil != 1)) { RenderFBXOpenTile(gScene, x, y, t, Water, 1); }	//ceiling
							break;
							}
						case SLOPE_CEILING_ONLY:
							{
							if (skipFloor != 1) { RenderFBXOpenTile(gScene, x, y, t, Water, 0); }//floor
							if ((skipCeil != 1)) { RenderFBXValleyNETile(gScene, x, y, t, Water, 1); }
							break;
							}
					}
				return;
				}
			case TILE_VALLEY_SE:
				{	//valleyse(c)
				switch (t.shockSlopeFlag)
					{
						case SLOPE_BOTH_PARALLEL:
							{
							if (skipFloor != 1) { RenderFBXValleySETile(gScene, x, y, t, Water, 0); }//floor
							if ((skipCeil != 1)) { RenderFBXValleySETile(gScene, x, y, t, Water, 1); }
							break;
							}
						case SLOPE_BOTH_OPPOSITE:
							{
							if (skipFloor != 1) { RenderFBXValleySETile(gScene, x, y, t, Water, 0); }//floor
							if ((skipCeil != 1)) { RenderFBXValleyNWTile(gScene, x, y, t, Water, 1); }
							break;
							}
						case SLOPE_FLOOR_ONLY:
							{
							if (skipFloor != 1) { RenderFBXValleySETile(gScene, x, y, t, Water, 0); }//floor
							if ((skipCeil != 1)) { RenderFBXOpenTile(gScene, x, y, t, Water, 1); }	//ceiling
							break;
							}
						case SLOPE_CEILING_ONLY:
							{
							if (skipFloor != 1) { RenderFBXOpenTile(gScene, x, y, t, Water, 0); }	//floor
							if ((skipCeil != 1)) { RenderFBXValleySETile(gScene, x, y, t, Water, 1); }
							break;
							}
					}
				return;
				}
			case TILE_VALLEY_SW:
				{	//valleysw(d)
				switch (t.shockSlopeFlag)
					{
						case SLOPE_BOTH_PARALLEL:
							{
							if (skipFloor != 1) { RenderFBXValleySWTile(gScene, x, y, t, Water, 0); }//floor
							if ((skipCeil != 1)) { RenderFBXValleySWTile(gScene, x, y, t, Water, 1); }
							break;
							}
						case SLOPE_BOTH_OPPOSITE:
							{
							if (skipFloor != 1) { RenderFBXValleySWTile(gScene, x, y, t, Water, 0); }//floor
							if ((skipCeil != 1)) { RenderFBXValleyNETile(gScene, x, y, t, Water, 1); }
							break;
							}
						case SLOPE_FLOOR_ONLY:
							{
							if (skipFloor != 1) { RenderFBXValleySWTile(gScene, x, y, t, Water, 0); }//floor
							if ((skipCeil != 1)) { RenderFBXOpenTile(gScene, x, y, t, Water, 1); }	//ceiling
							break;
							}
						case SLOPE_CEILING_ONLY:
							{
							if (skipFloor != 1) { RenderFBXOpenTile(gScene, x, y, t, Water, 0); }	//floor
							if ((skipCeil != 1)) { RenderFBXValleySWTile(gScene, x, y, t, Water, 1); }
							break;
							}
					}
				return;
				}
			case TILE_RIDGE_SE:
				{	//ridge se(f)
				switch (t.shockSlopeFlag)
					{
						case SLOPE_BOTH_PARALLEL:
							{
							if (skipFloor != 1) { RenderFBXRidgeSETile(gScene, x, y, t, Water, 0); }//floor
							if ((skipCeil != 1)) { RenderFBXRidgeSETile(gScene, x, y, t, Water, 1); }
							break;
							}
						case SLOPE_BOTH_OPPOSITE:
							{
							if (skipFloor != 1) { RenderFBXRidgeSETile(gScene, x, y, t, Water, 0); }//floor
							if ((skipCeil != 1)) { RenderFBXRidgeNWTile(gScene, x, y, t, Water, 1); }
							break;
							}
						case SLOPE_FLOOR_ONLY:
							{
							if (skipFloor != 1) { RenderFBXRidgeSETile(gScene, x, y, t, Water, 0); }//floor
							if ((skipCeil != 1)) { RenderFBXOpenTile(gScene, x, y, t, Water, 1); }	//ceiling
							break;
							}
						case SLOPE_CEILING_ONLY:
							{
							if (skipFloor != 1) { RenderFBXOpenTile(gScene, x, y, t, Water, 0); }//floor
							if ((skipCeil != 1)) { RenderFBXValleySETile(gScene, x, y, t, Water, 1); }
							break;
							}
					}
				return;
				}
			case TILE_RIDGE_SW:
				{	//ridgesw(g)
				switch (t.shockSlopeFlag)
					{
						case SLOPE_BOTH_PARALLEL:
							{
							if (skipFloor != 1) { RenderFBXRidgeSWTile(gScene, x, y, t, Water, 0); }//floor
							if ((skipCeil != 1)) { RenderFBXRidgeSWTile(gScene, x, y, t, Water, 1); }
							break;
							}
						case SLOPE_BOTH_OPPOSITE:
							{
							if (skipFloor != 1) { RenderFBXRidgeSWTile(gScene, x, y, t, Water, 0); }//floor
							if ((skipCeil != 1)) { RenderFBXRidgeNETile(gScene, x, y, t, Water, 1); }
							break;
							}
						case SLOPE_FLOOR_ONLY:
							{
							if (skipFloor != 1) { RenderFBXRidgeSWTile(gScene, x, y, t, Water, 0); }//floor
							if ((skipCeil != 1)) { RenderFBXOpenTile(gScene, x, y, t, Water, 1); }	//ceiling
							break;
							}
						case SLOPE_CEILING_ONLY:
							{
							if (skipFloor != 1) { RenderFBXOpenTile(gScene, x, y, t, Water, 0); }	//floor
							if ((skipCeil != 1)) { RenderFBXValleySWTile(gScene, x, y, t, Water, 1); }
							break;
							}
					}
				return;
				}
			case TILE_RIDGE_NW:
				{	//ridgenw(h)
				switch (t.shockSlopeFlag)
					{
						case SLOPE_BOTH_PARALLEL:
							{
							if (skipFloor != 1) { RenderFBXRidgeNWTile(gScene, x, y, t, Water, 0); }//floor
							if ((skipCeil != 1)) { RenderFBXRidgeNWTile(gScene, x, y, t, Water, 1); }
							break;
							}
						case SLOPE_BOTH_OPPOSITE:
							{
							if (skipFloor != 1) { RenderFBXRidgeNWTile(gScene, x, y, t, Water, 0); }//floor
							if ((skipCeil != 1)) { RenderFBXRidgeSETile(gScene, x, y, t, Water, 1); }
							break;
							}
						case SLOPE_FLOOR_ONLY:
							{
							if (skipFloor != 1) { RenderFBXRidgeNWTile(gScene, x, y, t, Water, 0); }//floor
							if ((skipCeil != 1)) { RenderFBXOpenTile(gScene, x, y, t, Water, 1); }	//ceiling
							break;
							}
						case SLOPE_CEILING_ONLY:
							{
							if (skipFloor != 1) { RenderFBXOpenTile(gScene, x, y, t, Water, 0); }	//floor
							if ((skipCeil != 1)) { RenderFBXValleyNWTile(gScene, x, y, t, Water, 1); }
							break;
							}
					}
				return;
				}
			case TILE_RIDGE_NE:
				{	//ridgene(i)
				switch (t.shockSlopeFlag)
					{
						case SLOPE_BOTH_PARALLEL:
							{
							if (skipFloor != 1) { RenderFBXRidgeNETile(gScene, x, y, t, Water, 0); }//floor
							if ((skipCeil != 1)) { RenderFBXRidgeNETile(gScene, x, y, t, Water, 1); }
							break;
							}
						case SLOPE_BOTH_OPPOSITE:
							{
							if (skipFloor != 1) { RenderFBXRidgeNETile(gScene, x, y, t, Water, 0); }//floor
							if ((skipCeil != 1)) { RenderFBXRidgeSWTile(gScene, x, y, t, Water, 1); }
							break;
							}
						case SLOPE_FLOOR_ONLY:
							{
							if (skipFloor != 1) { RenderFBXRidgeNETile(gScene, x, y, t, Water, 0); }//floor
							if ((skipCeil != 1)) { RenderFBXOpenTile(gScene, x, y, t, Water, 1); }	//ceiling
							break;
							}
						case SLOPE_CEILING_ONLY:
							{
							if (skipFloor != 1) { RenderFBXOpenTile(gScene, x, y, t, Water, 0); }	//floor
							if ((skipCeil != 1)) { RenderFBXValleyNETile(gScene, x, y, t, Water, 1); }
							break;
							}
					}			
				}
	}
}

void RenderFBXSolidTile(FbxScene*& gScene, int x, int y, tile &t, short Water)
{
if (t.Render == 1)
	{
	if (t.isWater == Water)
		{
		char TileName[80]="";
		sprintf_s(TileName, 80, "%s_%02d_%02d\0", "Tile", x, y);
		RenderFBXCuboid(gScene, x, y, t, Water, -2, CEILING_HEIGHT + 1, TileName);
		PrimCount++;
		}
	}
}

void RenderFBXOpenTile(FbxScene*& gScene, int x, int y, tile &t, short Water, short invert)
	{
	if (t.Render == 1){
		char TileName[80] = "";
		if (t.isWater == Water)
			{
			if (invert == 0)
				{
				//Bottom face 
				if ((t.hasElevator == 0))
					{
					if (t.BullFrog >0)
						{
						sprintf_s(TileName, 80, "%s_%02d_%02d\0", "Bullfrog", x, y);
						RenderFBXCuboid(gScene, x, y, t, Water, -16, t.floorHeight,TileName);
						}
					else
						{
						sprintf_s(TileName, 80, "%s_%02d_%02d\0", "Tile", x, y);//Floor_%02d_%02d
						RenderFBXCuboid(gScene, x, y, t, Water, -2, t.floorHeight, TileName);
						}
					}
				else
					{
					sprintf_s(TileName, 80, "%s_%02d_%02d\0", "Tile", x, y);
					RenderFBXCuboid(gScene, x, y, t, Water, -CEILING_HEIGHT, t.floorHeight, TileName);
					}
				}
			else
				{
				//Ceiling version of the tile
				sprintf_s(TileName, 80, "%s_%02d_%02d\0", "Ceiling", x, y);
				RenderFBXCuboid(gScene, x, y, t, Water, CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + 1, TileName);
				}
			}
		}
	}

void RenderFBXCuboid(FbxScene*& gScene, int x, int y, tile &t, short Water, int Bottom, int Top, char *TileName)
{
FbxVector4 lNormalXPos(1, 0, 0);
FbxVector4 lNormalXNeg(-1, 0, 0);
FbxVector4 lNormalYPos(0, 1, 0);
FbxVector4 lNormalYNeg(0, -1, 0);
FbxVector4 lNormalZPos(0, 0, 1);
FbxVector4 lNormalZNeg(0, 0, -1);

FbxString lCubeName = TileName;
//lCubeName += FbxString(gCubeNumber);

// create a new cube
int i, j;
FbxMesh* lMesh = FbxMesh::Create(gScene, lCubeName);

FbxVector4 lControlPoint0(t.tileX*BrushSizeX, t.tileY*BrushSizeY, Top*BrushSizeZ);
FbxVector4 lControlPoint1((t.tileX + t.DimX)*BrushSizeX, t.tileY*BrushSizeY, Top*BrushSizeZ);
FbxVector4 lControlPoint2((t.tileX + t.DimX)*BrushSizeX, (t.tileY + t.DimY)*BrushSizeY, Top*BrushSizeZ);
FbxVector4 lControlPoint3(t.tileX*BrushSizeX, (t.tileY + t.DimY)*BrushSizeY, Top*BrushSizeZ);
FbxVector4 lControlPoint4(t.tileX*BrushSizeX, t.tileY*BrushSizeY, Bottom*BrushSizeZ);
FbxVector4 lControlPoint5((t.tileX + t.DimX)*BrushSizeX, t.tileY*BrushSizeY, Bottom*BrushSizeZ);
FbxVector4 lControlPoint6((t.tileX + t.DimX)*BrushSizeX, (t.tileY + t.DimY)*BrushSizeY, Bottom*BrushSizeZ);
FbxVector4 lControlPoint7(t.tileX*BrushSizeX, (t.tileY + t.DimY)*BrushSizeY, Bottom*BrushSizeZ);


// Create control points.
lMesh->InitControlPoints(24);
FbxVector4* lControlPoints = lMesh->GetControlPoints();
//These directions are wrongly labeled???!!!
//Top
lControlPoints[0] = lControlPoint0;//0,1,2,3
lControlPoints[1] = lControlPoint1;
lControlPoints[2] = lControlPoint2;
lControlPoints[3] = lControlPoint3;

//was Bottom is probably east.
//lControlPoints[4] = lControlPoint1;
//lControlPoints[5] = lControlPoint5;
//lControlPoints[6] = lControlPoint6;
//lControlPoints[7] = lControlPoint2;
lControlPoints[4] = lControlPoint5;
lControlPoints[5] = lControlPoint6;
lControlPoints[6] = lControlPoint2;
lControlPoints[7] = lControlPoint1;

//not East?
lControlPoints[8] = lControlPoint5;
lControlPoints[9] = lControlPoint4;
lControlPoints[10] = lControlPoint7;
lControlPoints[11] = lControlPoint6;


//West
lControlPoints[12] = lControlPoint7;
lControlPoints[13] = lControlPoint4;
lControlPoints[14] = lControlPoint0;
lControlPoints[15] = lControlPoint3;

//North
lControlPoints[16] = lControlPoint6;
lControlPoints[17] = lControlPoint7;
lControlPoints[18] = lControlPoint3;
lControlPoints[19] = lControlPoint2;

//South
lControlPoints[20] = lControlPoint4;
lControlPoints[21] = lControlPoint5;
lControlPoints[22] = lControlPoint1;
lControlPoints[23] = lControlPoint0;


// We want to have one normal for each vertex (or control point),
// so we set the mapping mode to eByControlPoint.
FbxGeometryElementNormal* lGeometryElementNormal = lMesh->CreateElementNormal();

lGeometryElementNormal->SetMappingMode(FbxGeometryElement::eByControlPoint);

// Set the normal values for every control point.
lGeometryElementNormal->SetReferenceMode(FbxGeometryElement::eDirect);
//top
lGeometryElementNormal->GetDirectArray().Add(lNormalZPos);
lGeometryElementNormal->GetDirectArray().Add(lNormalZPos);
lGeometryElementNormal->GetDirectArray().Add(lNormalZPos);
lGeometryElementNormal->GetDirectArray().Add(lNormalZPos);

lGeometryElementNormal->GetDirectArray().Add(lNormalXPos);
lGeometryElementNormal->GetDirectArray().Add(lNormalXPos);
lGeometryElementNormal->GetDirectArray().Add(lNormalXPos);
lGeometryElementNormal->GetDirectArray().Add(lNormalXPos);

lGeometryElementNormal->GetDirectArray().Add(lNormalZNeg);//was neg
lGeometryElementNormal->GetDirectArray().Add(lNormalZNeg);
lGeometryElementNormal->GetDirectArray().Add(lNormalZNeg);
lGeometryElementNormal->GetDirectArray().Add(lNormalZNeg);
//north?
lGeometryElementNormal->GetDirectArray().Add(lNormalXNeg);//was Neg
lGeometryElementNormal->GetDirectArray().Add(lNormalXNeg);
lGeometryElementNormal->GetDirectArray().Add(lNormalXNeg);
lGeometryElementNormal->GetDirectArray().Add(lNormalXNeg);

lGeometryElementNormal->GetDirectArray().Add(lNormalYPos);
lGeometryElementNormal->GetDirectArray().Add(lNormalYPos);
lGeometryElementNormal->GetDirectArray().Add(lNormalYPos);
lGeometryElementNormal->GetDirectArray().Add(lNormalYPos);

lGeometryElementNormal->GetDirectArray().Add(lNormalYNeg);//WasNeg
lGeometryElementNormal->GetDirectArray().Add(lNormalYNeg);
lGeometryElementNormal->GetDirectArray().Add(lNormalYNeg);
lGeometryElementNormal->GetDirectArray().Add(lNormalYNeg);


// Array of polygon vertices.
int lPolygonVertices[] = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13,
14, 15, 16, 17, 18, 19, 20, 21, 22, 23 };


// Create UV for Diffuse channel.
FbxGeometryElementUV* lUVDiffuseElement = lMesh->CreateElementUV("DiffuseUV");
FBX_ASSERT(lUVDiffuseElement != NULL);
lUVDiffuseElement->SetMappingMode(FbxGeometryElement::eByPolygonVertex);
lUVDiffuseElement->SetReferenceMode(FbxGeometryElement::eIndexToDirect);
//Iamhere
printf("Not tested yet!");
float PolySize= Top-Bottom;
float offset=0;//-0.125;
offset = CalcCeilOffset(iGame, fNORTH, t);
FbxVector2 lVectorsNorth0(0, Bottom*0.125 - offset);//bottom left corner
FbxVector2 lVectorsNorth1(t.DimX , Bottom*0.125 - offset);//bottom right corner
FbxVector2 lVectorsNorth2(t.DimX , (PolySize / 8) + (Bottom*0.125) - offset);//top right corner
FbxVector2 lVectorsNorth3(0, (PolySize / 8) + (Bottom*0.125) - offset);//top left corner.
offset = CalcCeilOffset(iGame, fSOUTH, t);
FbxVector2 lVectorsSouth0(0, Bottom*0.125 - offset);//bottom left corner
FbxVector2 lVectorsSouth1(t.DimX , Bottom*0.125 - offset);//bottom right corner
FbxVector2 lVectorsSouth2(t.DimX, (PolySize / 8) + (Bottom*0.125) - offset);//top right corner
FbxVector2 lVectorsSouth3(0, (PolySize / 8) + (Bottom*0.125) - offset);//top left corner.
offset = CalcCeilOffset(iGame, fEAST, t);
FbxVector2 lVectorsEast0(0, Bottom*0.125 - offset);//bottom left corner
FbxVector2 lVectorsEast1(t.DimY , Bottom*0.125 - offset);//bottom right corner
FbxVector2 lVectorsEast2(t.DimY, (PolySize / 8) + (Bottom*0.125) - offset);//top right corner
FbxVector2 lVectorsEast3(0, (PolySize / 8) + (Bottom*0.125) - offset);//top left corner.
offset = CalcCeilOffset(iGame, fWEST, t);
FbxVector2 lVectorsWest0(0, Bottom*0.125 - offset);//bottom left corner
FbxVector2 lVectorsWest1(t.DimY, Bottom*0.125 - offset);//bottom right corner
FbxVector2 lVectorsWest2(t.DimY, (PolySize / 8) + (Bottom*0.125) - offset);//top right corner
FbxVector2 lVectorsWest3(0, (PolySize / 8) + (Bottom*0.125) - offset);//top left corner.

//bottom vectors
FbxVector2 lVectorsBottom0(0, 0);
FbxVector2 lVectorsBottom1(1 * t.DimX, 0);
FbxVector2 lVectorsBottom2(1 * t.DimX, 1 * t.DimY);
FbxVector2 lVectorsBottom3(0, 1 * t.DimY);

//top vectors
FbxVector2 lVectorsTop0(0, 0);
FbxVector2 lVectorsTop1(1*t.DimX, 0);
FbxVector2 lVectorsTop2(1 * t.DimX, 1 * t.DimY);
FbxVector2 lVectorsTop3(0, 1 * t.DimY);
//Top
lUVDiffuseElement->GetDirectArray().Add(lVectorsTop0);
lUVDiffuseElement->GetDirectArray().Add(lVectorsTop1);
lUVDiffuseElement->GetDirectArray().Add(lVectorsTop2);
lUVDiffuseElement->GetDirectArray().Add(lVectorsTop3);
//East

lUVDiffuseElement->GetDirectArray().Add(lVectorsEast0);
lUVDiffuseElement->GetDirectArray().Add(lVectorsEast1);
lUVDiffuseElement->GetDirectArray().Add(lVectorsEast2);
lUVDiffuseElement->GetDirectArray().Add(lVectorsEast3);
//Bottom
lUVDiffuseElement->GetDirectArray().Add(lVectorsBottom0);
lUVDiffuseElement->GetDirectArray().Add(lVectorsBottom1);
lUVDiffuseElement->GetDirectArray().Add(lVectorsBottom2);
lUVDiffuseElement->GetDirectArray().Add(lVectorsBottom3);
//West
lUVDiffuseElement->GetDirectArray().Add(lVectorsWest0);
lUVDiffuseElement->GetDirectArray().Add(lVectorsWest1);
lUVDiffuseElement->GetDirectArray().Add(lVectorsWest2);
lUVDiffuseElement->GetDirectArray().Add(lVectorsWest3);
//North
lUVDiffuseElement->GetDirectArray().Add(lVectorsNorth0);
lUVDiffuseElement->GetDirectArray().Add(lVectorsNorth1);
lUVDiffuseElement->GetDirectArray().Add(lVectorsNorth2);
lUVDiffuseElement->GetDirectArray().Add(lVectorsNorth3);
//South
lUVDiffuseElement->GetDirectArray().Add(lVectorsSouth0);
lUVDiffuseElement->GetDirectArray().Add(lVectorsSouth1);
lUVDiffuseElement->GetDirectArray().Add(lVectorsSouth2);
lUVDiffuseElement->GetDirectArray().Add(lVectorsSouth3);


//FbxGeometryElementUV* lUVElement = lMesh->GetElementUV(0);
//lUVElement->

//Now we have set the UVs as eIndexToDirect reference and in eByPolygonVertex  mapping mode
//we must update the size of the index array.
lUVDiffuseElement->GetIndexArray().SetCount(24);
int k=0;
// Create polygons. Assign texture and texture UV indices.
for (i = 0; i < 6; i++)
	{
	// all faces of the cube have the same texture
	lMesh->BeginPolygon(-1, -1, -1, false);

			for (j = 0; j < 4; j++)
				{
				// Control point index
				lMesh->AddPolygon(lPolygonVertices[i * 4 + j]);
				// update the index array of the UVs that map the texture to the face
				lUVDiffuseElement->GetIndexArray().SetAt(i * 4 + j, k);
				k++;
				}

	lMesh->EndPolygon();
	}

// create a FbxNode
FbxNode* lNode = FbxNode::Create(gScene, lCubeName);

// set the node attribute
lNode->SetNodeAttribute(lMesh);

// set the shading mode to view texture
lNode->SetShadingMode(FbxNode::eTextureShading);


//Assigned the materials to the mesh

FbxGeometryElementMaterial* lMaterialElement = lMesh->CreateElementMaterial();
lMaterialElement->SetMappingMode(FbxGeometryElement::eByPolygon);
lMaterialElement->SetReferenceMode(FbxGeometryElement::eIndexToDirect);


if (lNode == NULL)
return;

// We are in eByPolygon, so there's only need for 6 index (a cube has 6 polygons).
lMaterialElement->GetIndexArray().SetCount(6);

int TextureArray[] = { 0, 999, 999, 999, 999, 999, 999 };
int ceilTex = -1;
int eastTex = -1;
int westTex = -1;
int southTex = -1;
int northTex = -1;
int bottomTex = -1;

ceilTex = FloorTexture(gScene, lNode, fCEIL, t);//0
eastTex = WallTexture(gScene, lNode, fEAST, t);//1
westTex = WallTexture(gScene, lNode, fWEST, t);//2
southTex = WallTexture(gScene, lNode, fSOUTH, t);//3
northTex = WallTexture(gScene, lNode, fNORTH, t);//4
bottomTex = FloorTexture(gScene, lNode, fBOTTOM, t);//5

insertTexture(TextureArray, 1, bottomTex, 6);
insertTexture(TextureArray, 3, ceilTex, 6);
insertTexture(TextureArray, 2, eastTex, 6);
insertTexture(TextureArray, 4, westTex, 6);
insertTexture(TextureArray, 5, northTex, 6);
insertTexture(TextureArray, 6, southTex, 7);

int counter=0;
for (int i = 1;i<=6;i++)
	{
	if (TextureArray[i] >= 0)
		{//Just add the material at that index.
		//printf("\nAdding Material %d at %d", TextureArray[i],i);
		lNode->AddMaterial(gScene->GetMaterial(TextureArray[i]));
		//Turn that texture index back into a counter.
		TextureArray[i]=counter;
		counter++;
		}
	}

for (int i = 1; i <= 6; i++)
	{
	if (TextureArray[i] < 0)
		{
		lMaterialElement->GetIndexArray().SetAt(i-1, TextureArray[-TextureArray[i]]);
		}
	else
		{
		lMaterialElement->GetIndexArray().SetAt(i-1, TextureArray[i]);
		}
	}

gScene->GetRootNode()->AddChild(lNode);


}

void RenderFBXCuboid(FbxScene*& gScene, int x, int y, tile &t, short Water, int Bottom, int Top, char *TileName,
	FbxVector4 lControlPoint0,
	FbxVector4 lControlPoint1,
	FbxVector4 lControlPoint2,
	FbxVector4 lControlPoint3,
	FbxVector4 lControlPoint4,
	FbxVector4 lControlPoint5,
	FbxVector4 lControlPoint6,
	FbxVector4 lControlPoint7,
	float HorzOffsetEastPos, float HorzOffsetEastScale,
	float HorzOffsetWestPos, float HorzOffsetWestScale,
	float HorzOffsetNorthPos, float HorzOffsetNorthScale,
	float HorzOffsetSouthPos, float HorzOffsetSouthScale
)
	{
	FbxVector4 lNormalXPos(1, 0, 0);
	FbxVector4 lNormalXNeg(-1, 0, 0);
	FbxVector4 lNormalYPos(0, 1, 0);
	FbxVector4 lNormalYNeg(0, -1, 0);
	FbxVector4 lNormalZPos(0, 0, 1);
	FbxVector4 lNormalZNeg(0, 0, -1);

	FbxString lCubeName = TileName;
	//lCubeName += FbxString(gCubeNumber);

	// create a new cube
	int i, j;
	FbxMesh* lMesh = FbxMesh::Create(gScene, lCubeName);

	// Create control points.
	lMesh->InitControlPoints(24);
	FbxVector4* lControlPoints = lMesh->GetControlPoints();
	//These directions are wrongly labeled???!!!
	//Top
	lControlPoints[0] = lControlPoint0;
	lControlPoints[1] = lControlPoint1;
	lControlPoints[2] = lControlPoint2;
	lControlPoints[3] = lControlPoint3;

	//east.
	lControlPoints[4] = lControlPoint5;
	lControlPoints[5] = lControlPoint6;
	lControlPoints[6] = lControlPoint2;
	lControlPoints[7] = lControlPoint1;

	//not East?
	lControlPoints[8] = lControlPoint5;
	lControlPoints[9] = lControlPoint4;
	lControlPoints[10] = lControlPoint7;
	lControlPoints[11] = lControlPoint6;


	//West
	lControlPoints[12] = lControlPoint7;
	lControlPoints[13] = lControlPoint4;
	lControlPoints[14] = lControlPoint0;
	lControlPoints[15] = lControlPoint3;

	//North
	lControlPoints[16] = lControlPoint6;
	lControlPoints[17] = lControlPoint7;
	lControlPoints[18] = lControlPoint3;
	lControlPoints[19] = lControlPoint2;

	//South
	lControlPoints[20] = lControlPoint4;
	lControlPoints[21] = lControlPoint5;
	lControlPoints[22] = lControlPoint1;
	lControlPoints[23] = lControlPoint0;


	// We want to have one normal for each vertex (or control point),
	// so we set the mapping mode to eByControlPoint.
	FbxGeometryElementNormal* lGeometryElementNormal = lMesh->CreateElementNormal();

	lGeometryElementNormal->SetMappingMode(FbxGeometryElement::eByControlPoint);

	// Set the normal values for every control point.
	lGeometryElementNormal->SetReferenceMode(FbxGeometryElement::eDirect);
	//top
	lGeometryElementNormal->GetDirectArray().Add(lNormalZPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalZPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalZPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalZPos);

	lGeometryElementNormal->GetDirectArray().Add(lNormalXPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalXPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalXPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalXPos);

	lGeometryElementNormal->GetDirectArray().Add(lNormalZNeg);//was neg
	lGeometryElementNormal->GetDirectArray().Add(lNormalZNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalZNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalZNeg);
	//north?
	lGeometryElementNormal->GetDirectArray().Add(lNormalXNeg);//was Neg
	lGeometryElementNormal->GetDirectArray().Add(lNormalXNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalXNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalXNeg);

	lGeometryElementNormal->GetDirectArray().Add(lNormalYPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalYPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalYPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalYPos);

	lGeometryElementNormal->GetDirectArray().Add(lNormalYNeg);//WasNeg
	lGeometryElementNormal->GetDirectArray().Add(lNormalYNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalYNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalYNeg);


	// Array of polygon vertices.
	int lPolygonVertices[] = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13,
		14, 15, 16, 17, 18, 19, 20, 21, 22, 23 };


	// Create UV for Diffuse channel.
	FbxGeometryElementUV* lUVDiffuseElement = lMesh->CreateElementUV("DiffuseUV");
	FBX_ASSERT(lUVDiffuseElement != NULL);
	lUVDiffuseElement->SetMappingMode(FbxGeometryElement::eByPolygonVertex);
	lUVDiffuseElement->SetReferenceMode(FbxGeometryElement::eIndexToDirect);

	float PolySize = Top - Bottom;
	float offset = 0;//-0.125;
	offset = CalcCeilOffset(iGame, fNORTH, t);
	FbxVector2 lVectorsNorth0(HorzOffsetNorthPos, Bottom*0.125 - offset);//bottom left corner
	FbxVector2 lVectorsNorth1(HorzOffsetNorthScale, Bottom*0.125 - offset);//bottom right corner
	FbxVector2 lVectorsNorth2(HorzOffsetNorthScale, (PolySize / 8) + (Bottom*0.125) - offset);//top right corner
	FbxVector2 lVectorsNorth3(HorzOffsetNorthPos, (PolySize / 8) + (Bottom*0.125) - offset);//top left corner.
	offset = CalcCeilOffset(iGame, fSOUTH, t);
	FbxVector2 lVectorsSouth0(HorzOffsetSouthPos, Bottom*0.125 - offset);//bottom left corner
	FbxVector2 lVectorsSouth1(HorzOffsetSouthScale, Bottom*0.125 - offset);//bottom right corner
	FbxVector2 lVectorsSouth2(HorzOffsetSouthScale, (PolySize / 8) + (Bottom*0.125) - offset);//top right corner
	FbxVector2 lVectorsSouth3(HorzOffsetSouthPos, (PolySize / 8) + (Bottom*0.125) - offset);//top left corner.
	offset = CalcCeilOffset(iGame, fEAST, t);
	FbxVector2 lVectorsEast0(HorzOffsetEastPos, Bottom*0.125 - offset);//bottom left corner
	FbxVector2 lVectorsEast1(HorzOffsetEastScale, Bottom*0.125 - offset);//bottom right corner
	FbxVector2 lVectorsEast2(HorzOffsetEastScale, (PolySize / 8) + (Bottom*0.125) - offset);//top right corner
	FbxVector2 lVectorsEast3(HorzOffsetEastPos, (PolySize / 8) + (Bottom*0.125) - offset);//top left corner.
	offset = CalcCeilOffset(iGame, fWEST, t);
	FbxVector2 lVectorsWest0(HorzOffsetWestPos, Bottom*0.125 - offset);//bottom left corner
	FbxVector2 lVectorsWest1(HorzOffsetWestScale, Bottom*0.125 - offset);//bottom right corner
	FbxVector2 lVectorsWest2(HorzOffsetWestScale, (PolySize / 8) + (Bottom*0.125) - offset);//top right corner
	FbxVector2 lVectorsWest3(HorzOffsetWestPos, (PolySize / 8) + (Bottom*0.125) - offset);//top left corner.

	//bottom vectors
	FbxVector2 lVectorsBottom0(0, 0);
	FbxVector2 lVectorsBottom1(1 * t.DimX, 0);
	FbxVector2 lVectorsBottom2(1 * t.DimX, 1 * t.DimY);
	FbxVector2 lVectorsBottom3(0, 1 * t.DimY);

	//top vectors
	FbxVector2 lVectorsTop0(0, 0);
	FbxVector2 lVectorsTop1(1 * t.DimX, 0);
	FbxVector2 lVectorsTop2(1 * t.DimX, 1 * t.DimY);
	FbxVector2 lVectorsTop3(0, 1 * t.DimY);
	//Top
	lUVDiffuseElement->GetDirectArray().Add(lVectorsTop0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsTop1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsTop2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsTop3);
	//East

	lUVDiffuseElement->GetDirectArray().Add(lVectorsEast0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsEast1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsEast2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsEast3);
	//Bottom
	lUVDiffuseElement->GetDirectArray().Add(lVectorsBottom0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsBottom1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsBottom2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsBottom3);
	//West
	lUVDiffuseElement->GetDirectArray().Add(lVectorsWest0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsWest1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsWest2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsWest3);
	//North
	lUVDiffuseElement->GetDirectArray().Add(lVectorsNorth0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsNorth1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsNorth2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsNorth3);
	//South
	lUVDiffuseElement->GetDirectArray().Add(lVectorsSouth0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsSouth1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsSouth2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsSouth3);


	//FbxGeometryElementUV* lUVElement = lMesh->GetElementUV(0);
	//lUVElement->

	//Now we have set the UVs as eIndexToDirect reference and in eByPolygonVertex  mapping mode
	//we must update the size of the index array.
	lUVDiffuseElement->GetIndexArray().SetCount(24);
	int k = 0;
	// Create polygons. Assign texture and texture UV indices.
	for (i = 0; i < 6; i++)
		{
		// all faces of the cube have the same texture
		lMesh->BeginPolygon(-1, -1, -1, false);

		for (j = 0; j < 4; j++)
			{
			// Control point index
			lMesh->AddPolygon(lPolygonVertices[i * 4 + j]);
			// update the index array of the UVs that map the texture to the face
			lUVDiffuseElement->GetIndexArray().SetAt(i * 4 + j, k);
			k++;
			}

		lMesh->EndPolygon();
		}

	// create a FbxNode
	FbxNode* lNode = FbxNode::Create(gScene, lCubeName);

	// set the node attribute
	lNode->SetNodeAttribute(lMesh);

	// set the shading mode to view texture
	lNode->SetShadingMode(FbxNode::eTextureShading);


	//Assigned the materials to the mesh

	FbxGeometryElementMaterial* lMaterialElement = lMesh->CreateElementMaterial();
	lMaterialElement->SetMappingMode(FbxGeometryElement::eByPolygon);
	lMaterialElement->SetReferenceMode(FbxGeometryElement::eIndexToDirect);


	if (lNode == NULL)
		return;

	// We are in eByPolygon, so there's only need for 6 index (a cube has 6 polygons).
	lMaterialElement->GetIndexArray().SetCount(6);

	int TextureArray[] = { 0, 999, 999, 999, 999, 999, 999 };
	int ceilTex = -1;
	int eastTex = -1;
	int westTex = -1;
	int southTex = -1;
	int northTex = -1;
	int bottomTex = -1;

	ceilTex = FloorTexture(gScene, lNode, fCEIL, t);//0
	eastTex = WallTexture(gScene, lNode, fEAST, t);//1
	westTex = WallTexture(gScene, lNode, fWEST, t);//2
	southTex = WallTexture(gScene, lNode, fSOUTH, t);//3
	northTex = WallTexture(gScene, lNode, fNORTH, t);//4
	bottomTex = FloorTexture(gScene, lNode, fBOTTOM, t);//5

	insertTexture(TextureArray, 1, bottomTex, 6);
	insertTexture(TextureArray, 3, ceilTex, 6);
	insertTexture(TextureArray, 2, eastTex, 6);
	insertTexture(TextureArray, 4, westTex, 6);
	insertTexture(TextureArray, 5, northTex, 6);
	insertTexture(TextureArray, 6, southTex, 7);

	int counter = 0;
	for (int i = 1; i <= 6; i++)
		{
		if (TextureArray[i] >= 0)
			{//Just add the material at that index.
			//printf("\nAdding Material %d at %d", TextureArray[i],i);
			lNode->AddMaterial(gScene->GetMaterial(TextureArray[i]));
			//Turn that texture index back into a counter.
			TextureArray[i] = counter;
			counter++;
			}
		}

	for (int i = 1; i <= 6; i++)
		{
		if (TextureArray[i] < 0)
			{
			lMaterialElement->GetIndexArray().SetAt(i - 1, TextureArray[-TextureArray[i]]);
			}
		else
			{
			lMaterialElement->GetIndexArray().SetAt(i - 1, TextureArray[i]);
			}
		}

	gScene->GetRootNode()->AddChild(lNode);
	}


void RenderFBXCuboid(FbxScene*& gScene, int x, int y, tile &t, short Water, int Bottom, int Top, char *TileName,
	FbxVector4 lControlPoint0,
	FbxVector4 lControlPoint1,
	FbxVector4 lControlPoint2,
	FbxVector4 lControlPoint3,
	FbxVector4 lControlPoint4,
	FbxVector4 lControlPoint5,
	FbxVector4 lControlPoint6,
	FbxVector4 lControlPoint7,
	float VertOffsetPos, float VertOffsetScale
	)
	{
	/* FBX Cube with Preset vertical UV settings*/
	FbxVector4 lNormalXPos(1, 0, 0);
	FbxVector4 lNormalXNeg(-1, 0, 0);
	FbxVector4 lNormalYPos(0, 1, 0);
	FbxVector4 lNormalYNeg(0, -1, 0);
	FbxVector4 lNormalZPos(0, 0, 1);
	FbxVector4 lNormalZNeg(0, 0, -1);

	FbxString lCubeName = TileName;
	//lCubeName += FbxString(gCubeNumber);

	// create a new cube
	int i, j;
	FbxMesh* lMesh = FbxMesh::Create(gScene, lCubeName);

	// Create control points.
	lMesh->InitControlPoints(24);
	FbxVector4* lControlPoints = lMesh->GetControlPoints();
	//These directions are wrongly labeled???!!!
	//Top
	lControlPoints[0] = lControlPoint0;//0,1,2,3
	lControlPoints[1] = lControlPoint1;
	lControlPoints[2] = lControlPoint2;
	lControlPoints[3] = lControlPoint3;

	//east.
	lControlPoints[4] = lControlPoint5;
	lControlPoints[5] = lControlPoint6;
	lControlPoints[6] = lControlPoint2;
	lControlPoints[7] = lControlPoint1;

	//not East?
	lControlPoints[8] = lControlPoint5;
	lControlPoints[9] = lControlPoint4;
	lControlPoints[10] = lControlPoint7;
	lControlPoints[11] = lControlPoint6;


	//West
	lControlPoints[12] = lControlPoint7;
	lControlPoints[13] = lControlPoint4;
	lControlPoints[14] = lControlPoint0;
	lControlPoints[15] = lControlPoint3;

	//North
	lControlPoints[16] = lControlPoint6;
	lControlPoints[17] = lControlPoint7;
	lControlPoints[18] = lControlPoint3;
	lControlPoints[19] = lControlPoint2;

	//South
	lControlPoints[20] = lControlPoint4;
	lControlPoints[21] = lControlPoint5;
	lControlPoints[22] = lControlPoint1;
	lControlPoints[23] = lControlPoint0;


	// We want to have one normal for each vertex (or control point),
	// so we set the mapping mode to eByControlPoint.
	FbxGeometryElementNormal* lGeometryElementNormal = lMesh->CreateElementNormal();

	lGeometryElementNormal->SetMappingMode(FbxGeometryElement::eByControlPoint);

	// Set the normal values for every control point.
	lGeometryElementNormal->SetReferenceMode(FbxGeometryElement::eDirect);
	//top
	lGeometryElementNormal->GetDirectArray().Add(lNormalZPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalZPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalZPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalZPos);

	lGeometryElementNormal->GetDirectArray().Add(lNormalXPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalXPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalXPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalXPos);

	lGeometryElementNormal->GetDirectArray().Add(lNormalZNeg);//was neg
	lGeometryElementNormal->GetDirectArray().Add(lNormalZNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalZNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalZNeg);
	//north?
	lGeometryElementNormal->GetDirectArray().Add(lNormalXNeg);//was Neg
	lGeometryElementNormal->GetDirectArray().Add(lNormalXNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalXNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalXNeg);

	lGeometryElementNormal->GetDirectArray().Add(lNormalYPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalYPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalYPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalYPos);

	lGeometryElementNormal->GetDirectArray().Add(lNormalYNeg);//WasNeg
	lGeometryElementNormal->GetDirectArray().Add(lNormalYNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalYNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalYNeg);


	// Array of polygon vertices.
	int lPolygonVertices[] = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13,
		14, 15, 16, 17, 18, 19, 20, 21, 22, 23 };


	// Create UV for Diffuse channel.
	FbxGeometryElementUV* lUVDiffuseElement = lMesh->CreateElementUV("DiffuseUV");
	FBX_ASSERT(lUVDiffuseElement != NULL);
	lUVDiffuseElement->SetMappingMode(FbxGeometryElement::eByPolygonVertex);
	lUVDiffuseElement->SetReferenceMode(FbxGeometryElement::eIndexToDirect);
	printf("NOT TESTED YET!!!!");

	FbxVector2 lVectorsNorth0(0, VertOffsetPos);//bottom left corner
	FbxVector2 lVectorsNorth1(1*t.DimY, VertOffsetPos);//bottom right corner
	FbxVector2 lVectorsNorth2(1 * t.DimY, VertOffsetScale);//top right corner
	FbxVector2 lVectorsNorth3(0, VertOffsetScale);//top left corner.

	FbxVector2 lVectorsSouth0(0, VertOffsetPos);//bottom left corner
	FbxVector2 lVectorsSouth1(-1 * t.DimY, VertOffsetPos);//bottom right corner
	FbxVector2 lVectorsSouth2(-1 * t.DimY, VertOffsetScale);//top right corner
	FbxVector2 lVectorsSouth3(0, VertOffsetScale);//top left corner.

	FbxVector2 lVectorsEast0(0, VertOffsetPos);//bottom left corner
	FbxVector2 lVectorsEast1(1 * t.DimX, VertOffsetPos);//bottom right corner
	FbxVector2 lVectorsEast2(1 * t.DimX, VertOffsetScale);//top right corner
	FbxVector2 lVectorsEast3(0, VertOffsetScale);//top left corner.

	FbxVector2 lVectorsWest0(0, VertOffsetPos);//bottom left corner
	FbxVector2 lVectorsWest1(1 * t.DimX, VertOffsetPos);//bottom right corner
	FbxVector2 lVectorsWest2(1 * t.DimX, VertOffsetScale);//top right corner
	FbxVector2 lVectorsWest3(0, VertOffsetScale);//top left corner.

	//bottom vectors
	FbxVector2 lVectorsBottom0(0, 0);
	FbxVector2 lVectorsBottom1(1 * t.DimX, 0);
	FbxVector2 lVectorsBottom2(1 * t.DimX, 1 * t.DimY);
	FbxVector2 lVectorsBottom3(0, 1 * t.DimY);

	//top vectors
	FbxVector2 lVectorsTop0(0, 0);
	FbxVector2 lVectorsTop1(1 * t.DimX, 0);
	FbxVector2 lVectorsTop2(1 * t.DimX, 1 * t.DimY);
	FbxVector2 lVectorsTop3(0, 1 * t.DimY);
	//Top
	lUVDiffuseElement->GetDirectArray().Add(lVectorsTop0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsTop1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsTop2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsTop3);
	//East

	lUVDiffuseElement->GetDirectArray().Add(lVectorsEast0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsEast1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsEast2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsEast3);
	//Bottom
	lUVDiffuseElement->GetDirectArray().Add(lVectorsBottom0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsBottom1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsBottom2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsBottom3);
	//West
	lUVDiffuseElement->GetDirectArray().Add(lVectorsWest0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsWest1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsWest2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsWest3);
	//North
	lUVDiffuseElement->GetDirectArray().Add(lVectorsNorth0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsNorth1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsNorth2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsNorth3);
	//South
	lUVDiffuseElement->GetDirectArray().Add(lVectorsSouth0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsSouth1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsSouth2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsSouth3);


	//FbxGeometryElementUV* lUVElement = lMesh->GetElementUV(0);
	//lUVElement->

	//Now we have set the UVs as eIndexToDirect reference and in eByPolygonVertex  mapping mode
	//we must update the size of the index array.
	lUVDiffuseElement->GetIndexArray().SetCount(24);
	int k = 0;
	// Create polygons. Assign texture and texture UV indices.
	for (i = 0; i < 6; i++)
		{
		// all faces of the cube have the same texture
		lMesh->BeginPolygon(-1, -1, -1, false);

		for (j = 0; j < 4; j++)
			{
			// Control point index
			lMesh->AddPolygon(lPolygonVertices[i * 4 + j]);
			// update the index array of the UVs that map the texture to the face
			lUVDiffuseElement->GetIndexArray().SetAt(i * 4 + j, k);
			k++;
			}

		lMesh->EndPolygon();
		}

	// create a FbxNode
	FbxNode* lNode = FbxNode::Create(gScene, lCubeName);

	// set the node attribute
	lNode->SetNodeAttribute(lMesh);

	// set the shading mode to view texture
	lNode->SetShadingMode(FbxNode::eTextureShading);


	//Assigned the materials to the mesh

	FbxGeometryElementMaterial* lMaterialElement = lMesh->CreateElementMaterial();
	lMaterialElement->SetMappingMode(FbxGeometryElement::eByPolygon);
	lMaterialElement->SetReferenceMode(FbxGeometryElement::eIndexToDirect);


	if (lNode == NULL)
		return;

	// We are in eByPolygon, so there's only need for 6 index (a cube has 6 polygons).
	lMaterialElement->GetIndexArray().SetCount(6);

	int TextureArray[] = { 0, 999, 999, 999, 999, 999, 999 };
	int ceilTex = -1;
	int eastTex = -1;
	int westTex = -1;
	int southTex = -1;
	int northTex = -1;
	int bottomTex = -1;

	ceilTex = FloorTexture(gScene, lNode, fCEIL, t);//0
	eastTex = WallTexture(gScene, lNode, fEAST, t);//1
	westTex = WallTexture(gScene, lNode, fWEST, t);//2
	southTex = WallTexture(gScene, lNode, fSOUTH, t);//3
	northTex = WallTexture(gScene, lNode, fNORTH, t);//4
	bottomTex = FloorTexture(gScene, lNode, fBOTTOM, t);//5

	insertTexture(TextureArray, 1, bottomTex, 6);
	insertTexture(TextureArray, 3, ceilTex, 6);
	insertTexture(TextureArray, 2, eastTex, 6);
	insertTexture(TextureArray, 4, westTex, 6);
	insertTexture(TextureArray, 5, northTex, 6);
	insertTexture(TextureArray, 6, southTex, 7);

	int counter = 0;
	for (int i = 1; i <= 6; i++)
		{
		if (TextureArray[i] >= 0)
			{//Just add the material at that index.
			//printf("\nAdding Material %d at %d", TextureArray[i],i);
			lNode->AddMaterial(gScene->GetMaterial(TextureArray[i]));
			//Turn that texture index back into a counter.
			TextureArray[i] = counter;
			counter++;
			}
		}

	for (int i = 1; i <= 6; i++)
		{
		if (TextureArray[i] < 0)
			{
			lMaterialElement->GetIndexArray().SetAt(i - 1, TextureArray[-TextureArray[i]]);
			}
		else
			{
			lMaterialElement->GetIndexArray().SetAt(i - 1, TextureArray[i]);
			}
		}

	gScene->GetRootNode()->AddChild(lNode);
	}

void insertTexture(int *texArray, int targetIndex, int textureNo,int arraysize)
	{
int AlreadyInsertedAt=999;
for (int i = 1; i <= arraysize; i++)
		{
		if ((texArray[i] == (textureNo)) && (targetIndex != i))
			{
			AlreadyInsertedAt=i;
			}
		}
	if (AlreadyInsertedAt == 999)
		{//I'm free to add this texture/material
		texArray[targetIndex]=textureNo;
		}
	else
		{//In this case instead of storing the texture I store minus the index to actually use.
		texArray[targetIndex]= -AlreadyInsertedAt;
		}
	}

void RenderFBXPlane(FbxScene*& gScene, int x, int y, tile &t, short Water, int Bottom, int Top, char *TileName, int face, int Surface
	, int CP0_x, int  CP0_Y, int CP0_Z
	, int CP1_x, int  CP1_Y, int CP1_Z
	, int CP2_x, int  CP2_Y, int CP2_Z
	, int CP3_x, int  CP3_Y, int CP3_Z
	, FbxVector4 Normal
)
	{
	FbxString lCubeName = TileName;
	//lCubeName += FbxString(gCubeNumber);
	FbxMesh* lMesh = FbxMesh::Create(gScene, lCubeName);
	FbxVector4 lControlPoint0(CP0_x, CP0_Y, CP0_Z);
	FbxVector4 lControlPoint1(CP1_x, CP1_Y, CP1_Z);
	FbxVector4 lControlPoint2(CP2_x, CP2_Y, CP2_Z);
	FbxVector4 lControlPoint3(CP3_x, CP3_Y, CP3_Z);
	//FbxVector4 lNormalYPos(0, 1, 0);
	// Create control points.
	lMesh->InitControlPoints(4);
	FbxVector4* lControlPoints = lMesh->GetControlPoints();
	lControlPoints[0] = lControlPoint0;
	lControlPoints[1] = lControlPoint1;
	lControlPoints[2] = lControlPoint2;
	lControlPoints[3] = lControlPoint3;
	// We want to have one normal for each vertex (or control point),
	// so we set the mapping mode to eByControlPoint.
	FbxGeometryElementNormal* lGeometryElementNormal = lMesh->CreateElementNormal();
	lGeometryElementNormal->SetMappingMode(FbxGeometryElement::eByControlPoint);
	// Set the normal values for every control point.
	lGeometryElementNormal->SetReferenceMode(FbxGeometryElement::eDirect);
	lGeometryElementNormal->GetDirectArray().Add(Normal);
	lGeometryElementNormal->GetDirectArray().Add(Normal);
	lGeometryElementNormal->GetDirectArray().Add(Normal);
	lGeometryElementNormal->GetDirectArray().Add(Normal);
	// Array of polygon vertices.
	int lPolygonVertices[] = { 0, 1, 2, 3 };
	// Create UV for Diffuse channel.
	FbxGeometryElementUV* lUVDiffuseElement = lMesh->CreateElementUV("DiffuseUV");
	FBX_ASSERT(lUVDiffuseElement != NULL);
	lUVDiffuseElement->SetMappingMode(FbxGeometryElement::eByPolygonVertex);
	lUVDiffuseElement->SetReferenceMode(FbxGeometryElement::eIndexToDirect);

	FbxVector2 lVectors0(0, 0);
	FbxVector2 lVectors1(1, 0);
	FbxVector2 lVectors2(1, 1);
	FbxVector2 lVectors3(0, 1);

	lUVDiffuseElement->GetDirectArray().Add(lVectors0);
	lUVDiffuseElement->GetDirectArray().Add(lVectors1);
	lUVDiffuseElement->GetDirectArray().Add(lVectors2);
	lUVDiffuseElement->GetDirectArray().Add(lVectors3);

	//Now we have set the UVs as eIndexToDirect reference and in eByPolygonVertex  mapping mode
	//we must update the size of the index array.
	lUVDiffuseElement->GetIndexArray().SetCount(4);
	lMesh->BeginPolygon(-1, -1, -1, false);

	for (int j = 0; j < 4; j++)
		{
		// Control point index
		lMesh->AddPolygon(lPolygonVertices[ j]);

		// update the index array of the UVs that map the texture to the face
		lUVDiffuseElement->GetIndexArray().SetAt(j, j);
		}

	lMesh->EndPolygon();
	// create a FbxNode
	FbxNode* lNode = FbxNode::Create(gScene, lCubeName);

	// set the node attribute
	lNode->SetNodeAttribute(lMesh);

	// set the shading mode to view texture
	lNode->SetShadingMode(FbxNode::eTextureShading);


	//Assigned the materials to the mesh

	FbxGeometryElementMaterial* lMaterialElement = lMesh->CreateElementMaterial();
	lMaterialElement->SetMappingMode(FbxGeometryElement::eByPolygon);
	lMaterialElement->SetReferenceMode(FbxGeometryElement::eIndexToDirect);
	lMaterialElement->GetIndexArray().SetCount(1);

	if (lNode == NULL)
		return;
	switch (Surface)
		{
		case SURFACE_CEIL:
		case SURFACE_FLOOR:
		case SURFACE_SLOPE:
			FloorTexture(gScene, lNode, face, t);
			break;
		case SURFACE_WALL:
			WallTexture(gScene,lNode,face,t);
			break;
		}
			
	lMaterialElement->GetIndexArray().SetAt(0, 0);
	gScene->GetRootNode()->AddChild(lNode);


	}

void RenderFBXDiagSETile(FbxScene*& gScene, int x, int y, tile &t, short Water, short invert)
	{
	char TileName[80] = "";
	int BLeftX; int BLeftY; int BLeftZ; int TLeftX; int TLeftY; int TLeftZ; int TRightX; int TRightY; int TRightZ;

	if (t.Render == 1)
		{
		if (invert == 0)
			{

			if (Water != 1)
				{
				//the wall part
				sprintf_s(TileName, 80, "%s_%02d_%02d\0", "Wall", x, y);
				RenderFBXDiagSEPortion(gScene, -2, CEILING_HEIGHT + 1, t,TileName);

				}
			if (t.isWater == Water)
				{
				//it's floor
				//RenderFBXDiagNWPortion(gScene, -2, t.floorHeight, t,"DiagNW1");
				RenderFBXOpenTile(gScene, x, y, t, Water, 0);
				}
			}
		else
			{//it's ceiling
			//RenderFBXDiagNWPortion(gScene, CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + 1, t, "DiagNW2a");
			RenderFBXOpenTile(gScene, x, y, t, Water, 1);
			}
		}
	return;
	}

void RenderFBXDiagNWTile(FbxScene*& gScene, int x, int y, tile &t, short Water, short invert)
	{
	char TileName[80] = "";
	if (t.Render == 1)
		{
		if (invert == 0)
			{
			if (Water != 1)
				{
				//It's wall.
				sprintf_s(TileName, 80, "%s_%02d_%02d\0", "Wall", x, y);
				RenderFBXDiagNWPortion(gScene, -2, CEILING_HEIGHT + 1, t, TileName);
				}


			if (t.isWater == Water)
				{
				//it's floor
				//RenderFBXDiagSEPortion(gScene, -2, t.floorHeight, t, "DiagSE2");
				RenderFBXOpenTile(gScene, x, y, t, Water, 0);
				}
			}
		else
			{//it's ceiling
			//RenderFBXDiagSEPortion(gScene, CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + 1, t, "DiagSE3");
			RenderFBXOpenTile(gScene, x, y, t, Water, 1);
			}
		}
	return;
	}

void RenderFBXDiagSWTile(FbxScene*& gScene, int x, int y, tile &t, short Water, short invert)
	{
	char TileName[80] = "";
	if (t.Render == 1)
		{
		if (invert == 0)
			{
			if (Water != 1)
				{
				//Its wall
				sprintf_s(TileName, 80, "%s_%02d_%02d\0", "Wall", x, y);
				RenderFBXDiagSWPortion(gScene, -2, CEILING_HEIGHT + 1, t, TileName);
				}
			if (t.isWater == Water)
				{
				//it's floor
				//RenderFBXDiagNEPortion(gScene, -2, t.floorHeight, t,"TileNe1");
				RenderFBXOpenTile(gScene, x, y, t, Water, 0);
				}
			}
		else
			{
			//its' ceiling.
			//RenderFBXDiagNEPortion(gScene, CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + 1, t, "TileNe2");
			RenderFBXOpenTile(gScene, x, y, t, Water, 1);
			}
		}
	return;
	}

void RenderFBXDiagNETile(FbxScene*& gScene, int x, int y, tile &t, short Water, short invert)
	{
	char TileName[80] = "";
	if (t.Render == 1){
		if (invert == 0)
			{

			if (Water != 1)
				{
				sprintf_s(TileName, 80, "%s_%02d_%02d\0", "Wall", x, y);
				RenderFBXDiagNEPortion(gScene, -2, CEILING_HEIGHT + 1, t, TileName);
				}
			if (t.isWater == Water)
				{
				//it's floor
				//RenderFBXDiagSWPortion(gScene, -2, t.floorHeight, t, "DiagSW2");
				RenderFBXOpenTile(gScene, x, y, t, Water, 0);
				}
			}
		else
			{//it's ceiling
			//RenderFBXDiagSWPortion(gScene, CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + 1, t, "DiagSE3");
			RenderFBXOpenTile(gScene, x, y, t, Water, 1);
			}
		}
	return;
	}

void RenderFBXDiagSEPortion(FbxScene*& gScene, int Bottom, int Top, tile t, char *TileName)
	{
	FbxVector4 lNormalXPos(1, 0, 0);
	FbxVector4 lNormalXNeg(-1, 0, 0);
	FbxVector4 lNormalYPos(0, 1, 0);
	FbxVector4 lNormalYNeg(0, -1, 0);
	FbxVector4 lNormalZPos(0, 0, 1);
	FbxVector4 lNormalZNeg(0, 0, -1);

	FbxString lCubeName = TileName;
	//lCubeName += FbxString(gCubeNumber);

	// create a new cube
	int i, j;
	FbxMesh* lMesh = FbxMesh::Create(gScene, lCubeName);

	FbxVector4 lControlPoint0(t.tileX*BrushSizeX, t.tileY*BrushSizeY, Top*BrushSizeZ);
	FbxVector4 lControlPoint1((t.tileX + 0)*BrushSizeX, t.tileY*BrushSizeY, Top*BrushSizeZ);
	FbxVector4 lControlPoint2((t.tileX + t.DimX)*BrushSizeX, (t.tileY + t.DimY)*BrushSizeY, Top*BrushSizeZ);
	FbxVector4 lControlPoint3(t.tileX*BrushSizeX, (t.tileY + t.DimY)*BrushSizeY, Top*BrushSizeZ);
	FbxVector4 lControlPoint4(t.tileX*BrushSizeX, t.tileY*BrushSizeY, Bottom*BrushSizeZ);
	FbxVector4 lControlPoint5((t.tileX + 0)*BrushSizeX, t.tileY*BrushSizeY, Bottom*BrushSizeZ);
	FbxVector4 lControlPoint6((t.tileX + t.DimX)*BrushSizeX, (t.tileY + t.DimY)*BrushSizeY, Bottom*BrushSizeZ);
	FbxVector4 lControlPoint7(t.tileX*BrushSizeX, (t.tileY + t.DimY)*BrushSizeY, Bottom*BrushSizeZ);


	// Create control points.
	lMesh->InitControlPoints(24);
	FbxVector4* lControlPoints = lMesh->GetControlPoints();
	//These directions are wrongly labeled???!!!
	//Top
	lControlPoints[0] = lControlPoint0;
	lControlPoints[1] = lControlPoint1;
	lControlPoints[2] = lControlPoint2;
	lControlPoints[3] = lControlPoint3;

	//was Bottom is probably east.
	//lControlPoints[4] = lControlPoint1;
	//lControlPoints[5] = lControlPoint5;
	//lControlPoints[6] = lControlPoint6;
	//lControlPoints[7] = lControlPoint2;
	lControlPoints[4] = lControlPoint5;
	lControlPoints[5] = lControlPoint6;
	lControlPoints[6] = lControlPoint2;
	lControlPoints[7] = lControlPoint1;

	//not East?
	lControlPoints[8] = lControlPoint5;
	lControlPoints[9] = lControlPoint4;
	lControlPoints[10] = lControlPoint7;
	lControlPoints[11] = lControlPoint6;


	//West
	lControlPoints[12] = lControlPoint7;
	lControlPoints[13] = lControlPoint4;
	lControlPoints[14] = lControlPoint0;
	lControlPoints[15] = lControlPoint3;

	//North
	lControlPoints[16] = lControlPoint6;
	lControlPoints[17] = lControlPoint7;
	lControlPoints[18] = lControlPoint3;
	lControlPoints[19] = lControlPoint2;

	//South
	lControlPoints[20] = lControlPoint4;
	lControlPoints[21] = lControlPoint5;
	lControlPoints[22] = lControlPoint1;
	lControlPoints[23] = lControlPoint0;


	// We want to have one normal for each vertex (or control point),
	// so we set the mapping mode to eByControlPoint.
	FbxGeometryElementNormal* lGeometryElementNormal = lMesh->CreateElementNormal();

	lGeometryElementNormal->SetMappingMode(FbxGeometryElement::eByControlPoint);

	// Set the normal values for every control point.
	lGeometryElementNormal->SetReferenceMode(FbxGeometryElement::eDirect);
	//top
	lGeometryElementNormal->GetDirectArray().Add(lNormalZPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalZPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalZPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalZPos);

	lGeometryElementNormal->GetDirectArray().Add(lNormalXPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalXPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalXPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalXPos);

	lGeometryElementNormal->GetDirectArray().Add(lNormalZNeg);//was neg
	lGeometryElementNormal->GetDirectArray().Add(lNormalZNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalZNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalZNeg);
	//north?
	lGeometryElementNormal->GetDirectArray().Add(lNormalXNeg);//was Neg
	lGeometryElementNormal->GetDirectArray().Add(lNormalXNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalXNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalXNeg);

	lGeometryElementNormal->GetDirectArray().Add(lNormalYPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalYPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalYPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalYPos);

	lGeometryElementNormal->GetDirectArray().Add(lNormalYNeg);//WasNeg
	lGeometryElementNormal->GetDirectArray().Add(lNormalYNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalYNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalYNeg);


	// Array of polygon vertices.
	int lPolygonVertices[] = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13,
		14, 15, 16, 17, 18, 19, 20, 21, 22, 23 };


	// Create UV for Diffuse channel.
	FbxGeometryElementUV* lUVDiffuseElement = lMesh->CreateElementUV("DiffuseUV");
	FBX_ASSERT(lUVDiffuseElement != NULL);
	lUVDiffuseElement->SetMappingMode(FbxGeometryElement::eByPolygonVertex);
	lUVDiffuseElement->SetReferenceMode(FbxGeometryElement::eIndexToDirect);

	float PolySize = Top - Bottom;
	float offset = 0;//-0.125;
	offset = CalcCeilOffset(iGame, fNORTH, t);
	FbxVector2 lVectorsNorth0(0, Bottom*0.125 - offset);//bottom left corner
	FbxVector2 lVectorsNorth1(1, Bottom*0.125 - offset);//bottom right corner
	FbxVector2 lVectorsNorth2(1, (PolySize / 8) + (Bottom*0.125) - offset);//top right corner
	FbxVector2 lVectorsNorth3(0, (PolySize / 8) + (Bottom*0.125) - offset);//top left corner.
	offset = CalcCeilOffset(iGame, fSELF, t);//south
	FbxVector2 lVectorsSouth0(0, Bottom*0.125 - offset);//bottom left corner
	FbxVector2 lVectorsSouth1(1, Bottom*0.125 - offset);//bottom right corner
	FbxVector2 lVectorsSouth2(1, (PolySize / 8) + (Bottom*0.125) - offset);//top right corner
	FbxVector2 lVectorsSouth3(0, (PolySize / 8) + (Bottom*0.125) - offset);//top left corner.
	offset = CalcCeilOffset(iGame, fSELF, t); //east
	FbxVector2 lVectorsEast0(0, Bottom*0.125 - offset);//bottom left corner
	FbxVector2 lVectorsEast1(1, Bottom*0.125 - offset);//bottom right corner
	FbxVector2 lVectorsEast2(1, (PolySize / 8) + (Bottom*0.125) - offset);//top right corner
	FbxVector2 lVectorsEast3(0, (PolySize / 8) + (Bottom*0.125) - offset);//top left corner.
	offset = CalcCeilOffset(iGame, fWEST, t);
	FbxVector2 lVectorsWest0(0, Bottom*0.125 - offset);//bottom left corner
	FbxVector2 lVectorsWest1(1, Bottom*0.125 - offset);//bottom right corner
	FbxVector2 lVectorsWest2(1, (PolySize / 8) + (Bottom*0.125) - offset);//top right corner
	FbxVector2 lVectorsWest3(0, (PolySize / 8) + (Bottom*0.125) - offset);//top left corner.

	//bottom vectors
	FbxVector2 lVectorsBottom0(0, 0);
	FbxVector2 lVectorsBottom1(1, 0);
	FbxVector2 lVectorsBottom2(1, 1);
	FbxVector2 lVectorsBottom3(0, 1);

	//top vectors
	FbxVector2 lVectorsTop0(0, 0);
	FbxVector2 lVectorsTop1(1, 0);
	FbxVector2 lVectorsTop2(1, 1);
	FbxVector2 lVectorsTop3(0, 1);
	//Top
	lUVDiffuseElement->GetDirectArray().Add(lVectorsTop0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsTop1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsTop2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsTop3);
	//East

	lUVDiffuseElement->GetDirectArray().Add(lVectorsEast0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsEast1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsEast2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsEast3);
	//Bottom
	lUVDiffuseElement->GetDirectArray().Add(lVectorsBottom0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsBottom1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsBottom2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsBottom3);
	//West
	lUVDiffuseElement->GetDirectArray().Add(lVectorsWest0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsWest1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsWest2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsWest3);
	//North
	lUVDiffuseElement->GetDirectArray().Add(lVectorsNorth0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsNorth1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsNorth2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsNorth3);
	//South
	lUVDiffuseElement->GetDirectArray().Add(lVectorsSouth0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsSouth1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsSouth2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsSouth3);


	//FbxGeometryElementUV* lUVElement = lMesh->GetElementUV(0);
	//lUVElement->

	//Now we have set the UVs as eIndexToDirect reference and in eByPolygonVertex  mapping mode
	//we must update the size of the index array.
	lUVDiffuseElement->GetIndexArray().SetCount(24);
	int k = 0;
	// Create polygons. Assign texture and texture UV indices.
	for (i = 0; i < 6; i++)
		{
		// all faces of the cube have the same texture
		lMesh->BeginPolygon(-1, -1, -1, false);

		for (j = 0; j < 4; j++)
			{
			// Control point index
			lMesh->AddPolygon(lPolygonVertices[i * 4 + j]);
			// update the index array of the UVs that map the texture to the face
			lUVDiffuseElement->GetIndexArray().SetAt(i * 4 + j, k);
			k++;
			}

		lMesh->EndPolygon();
		}

	// create a FbxNode
	FbxNode* lNode = FbxNode::Create(gScene, lCubeName);

	// set the node attribute
	lNode->SetNodeAttribute(lMesh);

	// set the shading mode to view texture
	lNode->SetShadingMode(FbxNode::eTextureShading);


	//Assigned the materials to the mesh

	FbxGeometryElementMaterial* lMaterialElement = lMesh->CreateElementMaterial();
	lMaterialElement->SetMappingMode(FbxGeometryElement::eByPolygon);
	lMaterialElement->SetReferenceMode(FbxGeometryElement::eIndexToDirect);


	if (lNode == NULL)
		return;

	// We are in eByPolygon, so there's only need for 6 index (a cube has 6 polygons).
	lMaterialElement->GetIndexArray().SetCount(6);

	int TextureArray[] = { 0, 999, 999, 999, 999, 999, 999 };
	int ceilTex = -1;
	int eastTex = -1;
	int westTex = -1;
	int southTex = -1;
	int northTex = -1;
	int bottomTex = -1;

	ceilTex = FloorTexture(gScene, lNode, fCEIL, t);//0
	eastTex = WallTexture(gScene, lNode, fSELF, t);//1//east
	westTex = WallTexture(gScene, lNode, fWEST, t);//2
	southTex = WallTexture(gScene, lNode, fSELF, t);//3//south
	northTex = WallTexture(gScene, lNode, fNORTH, t);//4
	bottomTex = FloorTexture(gScene, lNode, fBOTTOM, t);//5

	insertTexture(TextureArray, 1, bottomTex, 6);
	insertTexture(TextureArray, 3, ceilTex, 6);
	insertTexture(TextureArray, 2, eastTex, 6);
	insertTexture(TextureArray, 4, westTex, 6);
	insertTexture(TextureArray, 5, northTex, 6);
	insertTexture(TextureArray, 6, southTex, 7);

	int counter = 0;
	for (int i = 1; i <= 6; i++)
		{
		if (TextureArray[i] >= 0)
			{//Just add the material at that index.
			//printf("\nAdding Material %d at %d", TextureArray[i],i);
			lNode->AddMaterial(gScene->GetMaterial(TextureArray[i]));
			//Turn that texture index back into a counter.
			TextureArray[i] = counter;
			counter++;
			}
		}

	for (int i = 1; i <= 6; i++)
		{
		if (TextureArray[i] < 0)
			{
			lMaterialElement->GetIndexArray().SetAt(i - 1, TextureArray[-TextureArray[i]]);
			}
		else
			{
			lMaterialElement->GetIndexArray().SetAt(i - 1, TextureArray[i]);
			}
		}

	gScene->GetRootNode()->AddChild(lNode);


	return;
	}

void RenderFBXDiagSWPortion(FbxScene*& gScene, int Bottom, int Top, tile t, char *TileName)
	{
	FbxVector4 lNormalXPos(1, 0, 0);
	FbxVector4 lNormalXNeg(-1, 0, 0);
	FbxVector4 lNormalYPos(0, 1, 0);
	FbxVector4 lNormalYNeg(0, -1, 0);
	FbxVector4 lNormalZPos(0, 0, 1);
	FbxVector4 lNormalZNeg(0, 0, -1);

	FbxString lCubeName = TileName;
	//lCubeName += FbxString(gCubeNumber);

	// create a new cube
	int i, j;
	FbxMesh* lMesh = FbxMesh::Create(gScene, lCubeName);
	//(t.tileX + t.DimX)
	FbxVector4 lControlPoint0((t.tileX + t.DimX)*BrushSizeX, t.tileY*BrushSizeY, Top*BrushSizeZ);
	FbxVector4 lControlPoint1((t.tileX + t.DimX)*BrushSizeX, t.tileY*BrushSizeY, Top*BrushSizeZ);
	FbxVector4 lControlPoint2((t.tileX + t.DimX)*BrushSizeX, (t.tileY + t.DimY)*BrushSizeY, Top*BrushSizeZ);
	FbxVector4 lControlPoint3(t.tileX*BrushSizeX, (t.tileY + t.DimY)*BrushSizeY, Top*BrushSizeZ);
	FbxVector4 lControlPoint4((t.tileX + t.DimX)*BrushSizeX, t.tileY*BrushSizeY, Bottom*BrushSizeZ);
	FbxVector4 lControlPoint5((t.tileX + t.DimX)*BrushSizeX, t.tileY*BrushSizeY, Bottom*BrushSizeZ);
	FbxVector4 lControlPoint6((t.tileX + t.DimX)*BrushSizeX, (t.tileY + t.DimY)*BrushSizeY, Bottom*BrushSizeZ);
	FbxVector4 lControlPoint7(t.tileX*BrushSizeX, (t.tileY + t.DimY)*BrushSizeY, Bottom*BrushSizeZ);


	// Create control points.
	lMesh->InitControlPoints(24);
	FbxVector4* lControlPoints = lMesh->GetControlPoints();
	//These directions are wrongly labeled???!!!
	//Top
	lControlPoints[0] = lControlPoint0;
	lControlPoints[1] = lControlPoint1;
	lControlPoints[2] = lControlPoint2;
	lControlPoints[3] = lControlPoint3;

	//was Bottom is probably east.
	//lControlPoints[4] = lControlPoint1;
	//lControlPoints[5] = lControlPoint5;
	//lControlPoints[6] = lControlPoint6;
	//lControlPoints[7] = lControlPoint2;
	lControlPoints[4] = lControlPoint5;
	lControlPoints[5] = lControlPoint6;
	lControlPoints[6] = lControlPoint2;
	lControlPoints[7] = lControlPoint1;

	//not East?
	lControlPoints[8] = lControlPoint5;
	lControlPoints[9] = lControlPoint4;
	lControlPoints[10] = lControlPoint7;
	lControlPoints[11] = lControlPoint6;


	//West
	lControlPoints[12] = lControlPoint7;
	lControlPoints[13] = lControlPoint4;
	lControlPoints[14] = lControlPoint0;
	lControlPoints[15] = lControlPoint3;

	//North
	lControlPoints[16] = lControlPoint6;
	lControlPoints[17] = lControlPoint7;
	lControlPoints[18] = lControlPoint3;
	lControlPoints[19] = lControlPoint2;

	//South
	lControlPoints[20] = lControlPoint4;
	lControlPoints[21] = lControlPoint5;
	lControlPoints[22] = lControlPoint1;
	lControlPoints[23] = lControlPoint0;


	// We want to have one normal for each vertex (or control point),
	// so we set the mapping mode to eByControlPoint.
	FbxGeometryElementNormal* lGeometryElementNormal = lMesh->CreateElementNormal();

	lGeometryElementNormal->SetMappingMode(FbxGeometryElement::eByControlPoint);

	// Set the normal values for every control point.
	lGeometryElementNormal->SetReferenceMode(FbxGeometryElement::eDirect);
	//top
	lGeometryElementNormal->GetDirectArray().Add(lNormalZPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalZPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalZPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalZPos);

	lGeometryElementNormal->GetDirectArray().Add(lNormalXPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalXPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalXPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalXPos);

	lGeometryElementNormal->GetDirectArray().Add(lNormalZNeg);//was neg
	lGeometryElementNormal->GetDirectArray().Add(lNormalZNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalZNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalZNeg);
	//north?
	lGeometryElementNormal->GetDirectArray().Add(lNormalXNeg);//was Neg
	lGeometryElementNormal->GetDirectArray().Add(lNormalXNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalXNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalXNeg);

	lGeometryElementNormal->GetDirectArray().Add(lNormalYPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalYPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalYPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalYPos);

	lGeometryElementNormal->GetDirectArray().Add(lNormalYNeg);//WasNeg
	lGeometryElementNormal->GetDirectArray().Add(lNormalYNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalYNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalYNeg);


	// Array of polygon vertices.
	int lPolygonVertices[] = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13,
		14, 15, 16, 17, 18, 19, 20, 21, 22, 23 };


	// Create UV for Diffuse channel.
	FbxGeometryElementUV* lUVDiffuseElement = lMesh->CreateElementUV("DiffuseUV");
	FBX_ASSERT(lUVDiffuseElement != NULL);
	lUVDiffuseElement->SetMappingMode(FbxGeometryElement::eByPolygonVertex);
	lUVDiffuseElement->SetReferenceMode(FbxGeometryElement::eIndexToDirect);

	float PolySize = Top - Bottom;
	float offset = 0;//-0.125;
	offset = CalcCeilOffset(iGame, fNORTH, t);
	FbxVector2 lVectorsNorth0(0, Bottom*0.125 - offset);//bottom left corner
	FbxVector2 lVectorsNorth1(1, Bottom*0.125 - offset);//bottom right corner
	FbxVector2 lVectorsNorth2(1, (PolySize / 8) + (Bottom*0.125) - offset);//top right corner
	FbxVector2 lVectorsNorth3(0, (PolySize / 8) + (Bottom*0.125) - offset);//top left corner.
	offset = CalcCeilOffset(iGame, fSELF, t);//South
	FbxVector2 lVectorsSouth0(0, Bottom*0.125 - offset);//bottom left corner
	FbxVector2 lVectorsSouth1(1, Bottom*0.125 - offset);//bottom right corner
	FbxVector2 lVectorsSouth2(1, (PolySize / 8) + (Bottom*0.125) - offset);//top right corner
	FbxVector2 lVectorsSouth3(0, (PolySize / 8) + (Bottom*0.125) - offset);//top left corner.
	offset = CalcCeilOffset(iGame, fEAST, t);
	FbxVector2 lVectorsEast0(0, Bottom*0.125 - offset);//bottom left corner
	FbxVector2 lVectorsEast1(1, Bottom*0.125 - offset);//bottom right corner
	FbxVector2 lVectorsEast2(1, (PolySize / 8) + (Bottom*0.125) - offset);//top right corner
	FbxVector2 lVectorsEast3(0, (PolySize / 8) + (Bottom*0.125) - offset);//top left corner.
	offset = CalcCeilOffset(iGame, fSELF, t);//west
	FbxVector2 lVectorsWest0(0, Bottom*0.125 - offset);//bottom left corner
	FbxVector2 lVectorsWest1(1, Bottom*0.125 - offset);//bottom right corner
	FbxVector2 lVectorsWest2(1, (PolySize / 8) + (Bottom*0.125) - offset);//top right corner
	FbxVector2 lVectorsWest3(0, (PolySize / 8) + (Bottom*0.125) - offset);//top left corner.

	//bottom vectors
	FbxVector2 lVectorsBottom0(0, 0);
	FbxVector2 lVectorsBottom1(1, 0);
	FbxVector2 lVectorsBottom2(1, 1);
	FbxVector2 lVectorsBottom3(0, 1);

	//top vectors
	FbxVector2 lVectorsTop0(0, 0);
	FbxVector2 lVectorsTop1(1, 0);
	FbxVector2 lVectorsTop2(1, 1);
	FbxVector2 lVectorsTop3(0, 1);
	//Top
	lUVDiffuseElement->GetDirectArray().Add(lVectorsTop0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsTop1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsTop2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsTop3);
	//East

	lUVDiffuseElement->GetDirectArray().Add(lVectorsEast0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsEast1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsEast2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsEast3);
	//Bottom
	lUVDiffuseElement->GetDirectArray().Add(lVectorsBottom0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsBottom1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsBottom2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsBottom3);
	//West
	lUVDiffuseElement->GetDirectArray().Add(lVectorsWest0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsWest1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsWest2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsWest3);
	//North
	lUVDiffuseElement->GetDirectArray().Add(lVectorsNorth0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsNorth1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsNorth2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsNorth3);
	//South
	lUVDiffuseElement->GetDirectArray().Add(lVectorsSouth0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsSouth1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsSouth2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsSouth3);


	//FbxGeometryElementUV* lUVElement = lMesh->GetElementUV(0);
	//lUVElement->

	//Now we have set the UVs as eIndexToDirect reference and in eByPolygonVertex  mapping mode
	//we must update the size of the index array.
	lUVDiffuseElement->GetIndexArray().SetCount(24);
	int k = 0;
	// Create polygons. Assign texture and texture UV indices.
	for (i = 0; i < 6; i++)
		{
		// all faces of the cube have the same texture
		lMesh->BeginPolygon(-1, -1, -1, false);

		for (j = 0; j < 4; j++)
			{
			// Control point index
			lMesh->AddPolygon(lPolygonVertices[i * 4 + j]);
			// update the index array of the UVs that map the texture to the face
			lUVDiffuseElement->GetIndexArray().SetAt(i * 4 + j, k);
			k++;
			}

		lMesh->EndPolygon();
		}

	// create a FbxNode
	FbxNode* lNode = FbxNode::Create(gScene, lCubeName);

	// set the node attribute
	lNode->SetNodeAttribute(lMesh);

	// set the shading mode to view texture
	lNode->SetShadingMode(FbxNode::eTextureShading);


	//Assigned the materials to the mesh

	FbxGeometryElementMaterial* lMaterialElement = lMesh->CreateElementMaterial();
	lMaterialElement->SetMappingMode(FbxGeometryElement::eByPolygon);
	lMaterialElement->SetReferenceMode(FbxGeometryElement::eIndexToDirect);


	if (lNode == NULL)
		return;

	// We are in eByPolygon, so there's only need for 6 index (a cube has 6 polygons).
	lMaterialElement->GetIndexArray().SetCount(6);

	int TextureArray[] = { 0, 999, 999, 999, 999, 999, 999 };
	int ceilTex = -1;
	int eastTex = -1;
	int westTex = -1;
	int southTex = -1;
	int northTex = -1;
	int bottomTex = -1;

	ceilTex = FloorTexture(gScene, lNode, fCEIL, t);//0
	eastTex = WallTexture(gScene, lNode, fEAST, t);//1
	westTex = WallTexture(gScene, lNode, fSELF, t);//2/west
	southTex = WallTexture(gScene, lNode, fSELF, t);//3/South
	northTex = WallTexture(gScene, lNode, fNORTH, t);//4
	bottomTex = FloorTexture(gScene, lNode, fBOTTOM, t);//5

	insertTexture(TextureArray, 1, bottomTex, 6);
	insertTexture(TextureArray, 3, ceilTex, 6);
	insertTexture(TextureArray, 2, eastTex, 6);
	insertTexture(TextureArray, 4, westTex, 6);
	insertTexture(TextureArray, 5, northTex, 6);
	insertTexture(TextureArray, 6, southTex, 7);

	int counter = 0;
	for (int i = 1; i <= 6; i++)
		{
		if (TextureArray[i] >= 0)
			{//Just add the material at that index.
			//printf("\nAdding Material %d at %d", TextureArray[i],i);
			lNode->AddMaterial(gScene->GetMaterial(TextureArray[i]));
			//Turn that texture index back into a counter.
			TextureArray[i] = counter;
			counter++;
			}
		}

	for (int i = 1; i <= 6; i++)
		{
		if (TextureArray[i] < 0)
			{
			lMaterialElement->GetIndexArray().SetAt(i - 1, TextureArray[-TextureArray[i]]);
			}
		else
			{
			lMaterialElement->GetIndexArray().SetAt(i - 1, TextureArray[i]);
			}
		}

	gScene->GetRootNode()->AddChild(lNode);


	}

void RenderFBXDiagNWPortion(FbxScene*& gScene, int Bottom, int Top, tile t, char *TileName)
	{
	FbxVector4 lNormalXPos(1, 0, 0);
	FbxVector4 lNormalXNeg(-1, 0, 0);
	FbxVector4 lNormalYPos(0, 1, 0);
	FbxVector4 lNormalYNeg(0, -1, 0);
	FbxVector4 lNormalZPos(0, 0, 1);
	FbxVector4 lNormalZNeg(0, 0, -1);

	FbxString lCubeName = TileName;
	//lCubeName += FbxString(gCubeNumber);

	// create a new cube
	int i, j;
	FbxMesh* lMesh = FbxMesh::Create(gScene, lCubeName);

	FbxVector4 lControlPoint0(t.tileX*BrushSizeX, t.tileY*BrushSizeY, Top*BrushSizeZ);
	FbxVector4 lControlPoint1((t.tileX + t.DimX)*BrushSizeX, t.tileY*BrushSizeY, Top*BrushSizeZ);
	FbxVector4 lControlPoint2((t.tileX + t.DimX)*BrushSizeX, (t.tileY + t.DimY)*BrushSizeY, Top*BrushSizeZ);
	FbxVector4 lControlPoint3(t.tileX*BrushSizeX, (t.tileY + 0)*BrushSizeY, Top*BrushSizeZ);
	FbxVector4 lControlPoint4(t.tileX*BrushSizeX, t.tileY*BrushSizeY, Bottom*BrushSizeZ);
	FbxVector4 lControlPoint5((t.tileX + t.DimX)*BrushSizeX, t.tileY*BrushSizeY, Bottom*BrushSizeZ);
	FbxVector4 lControlPoint6((t.tileX + t.DimX)*BrushSizeX, (t.tileY + t.DimY)*BrushSizeY, Bottom*BrushSizeZ);
	FbxVector4 lControlPoint7(t.tileX*BrushSizeX, (t.tileY + 0)*BrushSizeY, Bottom*BrushSizeZ);


	// Create control points.
	lMesh->InitControlPoints(24);
	FbxVector4* lControlPoints = lMesh->GetControlPoints();
	//These directions are wrongly labeled???!!!
	//Top
	lControlPoints[0] = lControlPoint0;
	lControlPoints[1] = lControlPoint1;
	lControlPoints[2] = lControlPoint2;
	lControlPoints[3] = lControlPoint3;

	//was Bottom is probably east.
	//lControlPoints[4] = lControlPoint1;
	//lControlPoints[5] = lControlPoint5;
	//lControlPoints[6] = lControlPoint6;
	//lControlPoints[7] = lControlPoint2;
	lControlPoints[4] = lControlPoint5;
	lControlPoints[5] = lControlPoint6;
	lControlPoints[6] = lControlPoint2;
	lControlPoints[7] = lControlPoint1;

	//not East?
	lControlPoints[8] = lControlPoint5;
	lControlPoints[9] = lControlPoint4;
	lControlPoints[10] = lControlPoint7;
	lControlPoints[11] = lControlPoint6;


	//West
	lControlPoints[12] = lControlPoint7;
	lControlPoints[13] = lControlPoint4;
	lControlPoints[14] = lControlPoint0;
	lControlPoints[15] = lControlPoint3;

	//North
	lControlPoints[16] = lControlPoint6;
	lControlPoints[17] = lControlPoint7;
	lControlPoints[18] = lControlPoint3;
	lControlPoints[19] = lControlPoint2;

	//South
	lControlPoints[20] = lControlPoint4;
	lControlPoints[21] = lControlPoint5;
	lControlPoints[22] = lControlPoint1;
	lControlPoints[23] = lControlPoint0;


	// We want to have one normal for each vertex (or control point),
	// so we set the mapping mode to eByControlPoint.
	FbxGeometryElementNormal* lGeometryElementNormal = lMesh->CreateElementNormal();

	lGeometryElementNormal->SetMappingMode(FbxGeometryElement::eByControlPoint);

	// Set the normal values for every control point.
	lGeometryElementNormal->SetReferenceMode(FbxGeometryElement::eDirect);
	//top
	lGeometryElementNormal->GetDirectArray().Add(lNormalZPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalZPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalZPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalZPos);

	lGeometryElementNormal->GetDirectArray().Add(lNormalXPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalXPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalXPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalXPos);

	lGeometryElementNormal->GetDirectArray().Add(lNormalZNeg);//was neg
	lGeometryElementNormal->GetDirectArray().Add(lNormalZNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalZNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalZNeg);
	//north?
	lGeometryElementNormal->GetDirectArray().Add(lNormalXNeg);//was Neg
	lGeometryElementNormal->GetDirectArray().Add(lNormalXNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalXNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalXNeg);

	lGeometryElementNormal->GetDirectArray().Add(lNormalYPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalYPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalYPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalYPos);

	lGeometryElementNormal->GetDirectArray().Add(lNormalYNeg);//WasNeg
	lGeometryElementNormal->GetDirectArray().Add(lNormalYNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalYNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalYNeg);


	// Array of polygon vertices.
	int lPolygonVertices[] = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13,
		14, 15, 16, 17, 18, 19, 20, 21, 22, 23 };


	// Create UV for Diffuse channel.
	FbxGeometryElementUV* lUVDiffuseElement = lMesh->CreateElementUV("DiffuseUV");
	FBX_ASSERT(lUVDiffuseElement != NULL);
	lUVDiffuseElement->SetMappingMode(FbxGeometryElement::eByPolygonVertex);
	lUVDiffuseElement->SetReferenceMode(FbxGeometryElement::eIndexToDirect);

	float PolySize = Top - Bottom;
	float offset = 0;//-0.125;
	offset = CalcCeilOffset(iGame, fNORTH, t);
	FbxVector2 lVectorsNorth0(0, Bottom*0.125 - offset);//bottom left corner
	FbxVector2 lVectorsNorth1(1, Bottom*0.125 - offset);//bottom right corner
	FbxVector2 lVectorsNorth2(1, (PolySize / 8) + (Bottom*0.125) - offset);//top right corner
	FbxVector2 lVectorsNorth3(0, (PolySize / 8) + (Bottom*0.125) - offset);//top left corner.
	offset = CalcCeilOffset(iGame, fSOUTH, t);
	FbxVector2 lVectorsSouth0(0, Bottom*0.125 - offset);//bottom left corner
	FbxVector2 lVectorsSouth1(1, Bottom*0.125 - offset);//bottom right corner
	FbxVector2 lVectorsSouth2(1, (PolySize / 8) + (Bottom*0.125) - offset);//top right corner
	FbxVector2 lVectorsSouth3(0, (PolySize / 8) + (Bottom*0.125) - offset);//top left corner.
	offset = CalcCeilOffset(iGame, fEAST, t);
	FbxVector2 lVectorsEast0(0, Bottom*0.125 - offset);//bottom left corner
	FbxVector2 lVectorsEast1(1, Bottom*0.125 - offset);//bottom right corner
	FbxVector2 lVectorsEast2(1, (PolySize / 8) + (Bottom*0.125) - offset);//top right corner
	FbxVector2 lVectorsEast3(0, (PolySize / 8) + (Bottom*0.125) - offset);//top left corner.
	offset = CalcCeilOffset(iGame, fWEST, t);
	FbxVector2 lVectorsWest0(0, Bottom*0.125 - offset);//bottom left corner
	FbxVector2 lVectorsWest1(1, Bottom*0.125 - offset);//bottom right corner
	FbxVector2 lVectorsWest2(1, (PolySize / 8) + (Bottom*0.125) - offset);//top right corner
	FbxVector2 lVectorsWest3(0, (PolySize / 8) + (Bottom*0.125) - offset);//top left corner.

	//bottom vectors
	FbxVector2 lVectorsBottom0(0, 0);
	FbxVector2 lVectorsBottom1(1, 0);
	FbxVector2 lVectorsBottom2(1, 1);
	FbxVector2 lVectorsBottom3(0, 1);

	//top vectors
	FbxVector2 lVectorsTop0(0, 0);
	FbxVector2 lVectorsTop1(1, 0);
	FbxVector2 lVectorsTop2(1, 1);
	FbxVector2 lVectorsTop3(0, 1);
	//Top
	lUVDiffuseElement->GetDirectArray().Add(lVectorsTop0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsTop1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsTop2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsTop3);
	//East

	lUVDiffuseElement->GetDirectArray().Add(lVectorsEast0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsEast1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsEast2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsEast3);
	//Bottom
	lUVDiffuseElement->GetDirectArray().Add(lVectorsBottom0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsBottom1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsBottom2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsBottom3);
	//West
	lUVDiffuseElement->GetDirectArray().Add(lVectorsWest0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsWest1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsWest2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsWest3);
	//North
	lUVDiffuseElement->GetDirectArray().Add(lVectorsNorth0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsNorth1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsNorth2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsNorth3);
	//South
	lUVDiffuseElement->GetDirectArray().Add(lVectorsSouth0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsSouth1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsSouth2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsSouth3);


	//FbxGeometryElementUV* lUVElement = lMesh->GetElementUV(0);
	//lUVElement->

	//Now we have set the UVs as eIndexToDirect reference and in eByPolygonVertex  mapping mode
	//we must update the size of the index array.
	lUVDiffuseElement->GetIndexArray().SetCount(24);
	int k = 0;
	// Create polygons. Assign texture and texture UV indices.
	for (i = 0; i < 6; i++)
		{
		// all faces of the cube have the same texture
		lMesh->BeginPolygon(-1, -1, -1, false);

		for (j = 0; j < 4; j++)
			{
			// Control point index
			lMesh->AddPolygon(lPolygonVertices[i * 4 + j]);
			// update the index array of the UVs that map the texture to the face
			lUVDiffuseElement->GetIndexArray().SetAt(i * 4 + j, k);
			k++;
			}

		lMesh->EndPolygon();
		}

	// create a FbxNode
	FbxNode* lNode = FbxNode::Create(gScene, lCubeName);

	// set the node attribute
	lNode->SetNodeAttribute(lMesh);

	// set the shading mode to view texture
	lNode->SetShadingMode(FbxNode::eTextureShading);


	//Assigned the materials to the mesh

	FbxGeometryElementMaterial* lMaterialElement = lMesh->CreateElementMaterial();
	lMaterialElement->SetMappingMode(FbxGeometryElement::eByPolygon);
	lMaterialElement->SetReferenceMode(FbxGeometryElement::eIndexToDirect);


	if (lNode == NULL)
		return;

	// We are in eByPolygon, so there's only need for 6 index (a cube has 6 polygons).
	lMaterialElement->GetIndexArray().SetCount(6);

	int TextureArray[] = { 0, 999, 999, 999, 999, 999, 999 };
	int ceilTex = -1;
	int eastTex = -1;
	int westTex = -1;
	int southTex = -1;
	int northTex = -1;
	int bottomTex = -1;

	ceilTex = FloorTexture(gScene, lNode, fCEIL, t);//0
	eastTex = WallTexture(gScene, lNode, fEAST, t);//1
	westTex = WallTexture(gScene, lNode, fSELF, t);//2//west
	southTex = WallTexture(gScene, lNode, fSOUTH, t);//3
	northTex = WallTexture(gScene, lNode, fSELF, t);//4north
	bottomTex = FloorTexture(gScene, lNode, fBOTTOM, t);//5

	insertTexture(TextureArray, 1, bottomTex, 6);
	insertTexture(TextureArray, 3, ceilTex, 6);
	insertTexture(TextureArray, 2, eastTex, 6);
	insertTexture(TextureArray, 4, westTex, 6);
	insertTexture(TextureArray, 5, northTex, 6);
	insertTexture(TextureArray, 6, southTex, 7);

	int counter = 0;
	for (int i = 1; i <= 6; i++)
		{
		if (TextureArray[i] >= 0)
			{//Just add the material at that index.
			//printf("\nAdding Material %d at %d", TextureArray[i],i);
			lNode->AddMaterial(gScene->GetMaterial(TextureArray[i]));
			//Turn that texture index back into a counter.
			TextureArray[i] = counter;
			counter++;
			}
		}

	for (int i = 1; i <= 6; i++)
		{
		if (TextureArray[i] < 0)
			{
			lMaterialElement->GetIndexArray().SetAt(i - 1, TextureArray[-TextureArray[i]]);
			}
		else
			{
			lMaterialElement->GetIndexArray().SetAt(i - 1, TextureArray[i]);
			}
		}

	gScene->GetRootNode()->AddChild(lNode);


	}

void RenderFBXDiagNEPortion(FbxScene*& gScene, int Bottom, int Top, tile t, char *TileName)
	{
	FbxVector4 lNormalXPos(1, 0, 0);
	FbxVector4 lNormalXNeg(-1, 0, 0);
	FbxVector4 lNormalYPos(0, 1, 0);
	FbxVector4 lNormalYNeg(0, -1, 0);
	FbxVector4 lNormalZPos(0, 0, 1);
	FbxVector4 lNormalZNeg(0, 0, -1);

	FbxString lCubeName = TileName;
	//lCubeName += FbxString(gCubeNumber);

	// create a new cube
	int i, j;
	FbxMesh* lMesh = FbxMesh::Create(gScene, lCubeName);

	FbxVector4 lControlPoint0(t.tileX*BrushSizeX, t.tileY*BrushSizeY, Top*BrushSizeZ);
	FbxVector4 lControlPoint1((t.tileX + t.DimX)*BrushSizeX, t.tileY*BrushSizeY, Top*BrushSizeZ);
	FbxVector4 lControlPoint2((t.tileX + t.DimX)*BrushSizeX, (t.tileY + 0)*BrushSizeY, Top*BrushSizeZ);
	FbxVector4 lControlPoint3(t.tileX*BrushSizeX, (t.tileY + t.DimY)*BrushSizeY, Top*BrushSizeZ);
	FbxVector4 lControlPoint4(t.tileX*BrushSizeX, t.tileY*BrushSizeY, Bottom*BrushSizeZ);
	FbxVector4 lControlPoint5((t.tileX + t.DimX)*BrushSizeX, t.tileY*BrushSizeY, Bottom*BrushSizeZ);
	FbxVector4 lControlPoint6((t.tileX + t.DimX)*BrushSizeX, (t.tileY + 0)*BrushSizeY, Bottom*BrushSizeZ);
	FbxVector4 lControlPoint7(t.tileX*BrushSizeX, (t.tileY + t.DimY)*BrushSizeY, Bottom*BrushSizeZ);


	// Create control points.
	lMesh->InitControlPoints(24);
	FbxVector4* lControlPoints = lMesh->GetControlPoints();
	//These directions are wrongly labeled???!!!
	//Top
	lControlPoints[0] = lControlPoint0;
	lControlPoints[1] = lControlPoint1;
	lControlPoints[2] = lControlPoint2;
	lControlPoints[3] = lControlPoint3;

	//was Bottom is probably east.
	//lControlPoints[4] = lControlPoint1;
	//lControlPoints[5] = lControlPoint5;
	//lControlPoints[6] = lControlPoint6;
	//lControlPoints[7] = lControlPoint2;
	lControlPoints[4] = lControlPoint5;
	lControlPoints[5] = lControlPoint6;
	lControlPoints[6] = lControlPoint2;
	lControlPoints[7] = lControlPoint1;

	//not East?
	lControlPoints[8] = lControlPoint5;
	lControlPoints[9] = lControlPoint4;
	lControlPoints[10] = lControlPoint7;
	lControlPoints[11] = lControlPoint6;


	//West
	lControlPoints[12] = lControlPoint7;
	lControlPoints[13] = lControlPoint4;
	lControlPoints[14] = lControlPoint0;
	lControlPoints[15] = lControlPoint3;

	//North
	lControlPoints[16] = lControlPoint6;
	lControlPoints[17] = lControlPoint7;
	lControlPoints[18] = lControlPoint3;
	lControlPoints[19] = lControlPoint2;

	//South
	lControlPoints[20] = lControlPoint4;
	lControlPoints[21] = lControlPoint5;
	lControlPoints[22] = lControlPoint1;
	lControlPoints[23] = lControlPoint0;


	// We want to have one normal for each vertex (or control point),
	// so we set the mapping mode to eByControlPoint.
	FbxGeometryElementNormal* lGeometryElementNormal = lMesh->CreateElementNormal();

	lGeometryElementNormal->SetMappingMode(FbxGeometryElement::eByControlPoint);

	// Set the normal values for every control point.
	lGeometryElementNormal->SetReferenceMode(FbxGeometryElement::eDirect);
	//top
	lGeometryElementNormal->GetDirectArray().Add(lNormalZPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalZPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalZPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalZPos);

	lGeometryElementNormal->GetDirectArray().Add(lNormalXPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalXPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalXPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalXPos);

	lGeometryElementNormal->GetDirectArray().Add(lNormalZNeg);//was neg
	lGeometryElementNormal->GetDirectArray().Add(lNormalZNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalZNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalZNeg);
	//north?
	lGeometryElementNormal->GetDirectArray().Add(lNormalXNeg);//was Neg
	lGeometryElementNormal->GetDirectArray().Add(lNormalXNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalXNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalXNeg);

	lGeometryElementNormal->GetDirectArray().Add(lNormalYPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalYPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalYPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalYPos);

	lGeometryElementNormal->GetDirectArray().Add(lNormalYNeg);//WasNeg
	lGeometryElementNormal->GetDirectArray().Add(lNormalYNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalYNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalYNeg);


	// Array of polygon vertices.
	int lPolygonVertices[] = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13,
		14, 15, 16, 17, 18, 19, 20, 21, 22, 23 };


	// Create UV for Diffuse channel.
	FbxGeometryElementUV* lUVDiffuseElement = lMesh->CreateElementUV("DiffuseUV");
	FBX_ASSERT(lUVDiffuseElement != NULL);
	lUVDiffuseElement->SetMappingMode(FbxGeometryElement::eByPolygonVertex);
	lUVDiffuseElement->SetReferenceMode(FbxGeometryElement::eIndexToDirect);

	float PolySize = Top - Bottom;
	float offset = 0;//-0.125;
	offset = CalcCeilOffset(iGame, fSELF, t);//was north
	FbxVector2 lVectorsNorth0(0, Bottom*0.125 - offset);//bottom left corner
	FbxVector2 lVectorsNorth1(1, Bottom*0.125 - offset);//bottom right corner
	FbxVector2 lVectorsNorth2(1, (PolySize / 8) + (Bottom*0.125) - offset);//top right corner
	FbxVector2 lVectorsNorth3(0, (PolySize / 8) + (Bottom*0.125) - offset);//top left corner.
	offset = CalcCeilOffset(iGame, fSOUTH, t);
	FbxVector2 lVectorsSouth0(0, Bottom*0.125 - offset);//bottom left corner
	FbxVector2 lVectorsSouth1(1, Bottom*0.125 - offset);//bottom right corner
	FbxVector2 lVectorsSouth2(1, (PolySize / 8) + (Bottom*0.125) - offset);//top right corner
	FbxVector2 lVectorsSouth3(0, (PolySize / 8) + (Bottom*0.125) - offset);//top left corner.
	offset = CalcCeilOffset(iGame, fSELF, t);//was east
	FbxVector2 lVectorsEast0(0, Bottom*0.125 - offset);//bottom left corner
	FbxVector2 lVectorsEast1(1, Bottom*0.125 - offset);//bottom right corner
	FbxVector2 lVectorsEast2(1, (PolySize / 8) + (Bottom*0.125) - offset);//top right corner
	FbxVector2 lVectorsEast3(0, (PolySize / 8) + (Bottom*0.125) - offset);//top left corner.
	offset = CalcCeilOffset(iGame, fWEST, t);
	FbxVector2 lVectorsWest0(0, Bottom*0.125 - offset);//bottom left corner
	FbxVector2 lVectorsWest1(1, Bottom*0.125 - offset);//bottom right corner
	FbxVector2 lVectorsWest2(1, (PolySize / 8) + (Bottom*0.125) - offset);//top right corner
	FbxVector2 lVectorsWest3(0, (PolySize / 8) + (Bottom*0.125) - offset);//top left corner.

	//bottom vectors
	FbxVector2 lVectorsBottom0(0, 0);
	FbxVector2 lVectorsBottom1(1, 0);
	FbxVector2 lVectorsBottom2(1, 1);
	FbxVector2 lVectorsBottom3(0, 1);

	//top vectors
	FbxVector2 lVectorsTop0(0, 0);
	FbxVector2 lVectorsTop1(1, 0);
	FbxVector2 lVectorsTop2(1, 1);
	FbxVector2 lVectorsTop3(0, 1);
	//Top
	lUVDiffuseElement->GetDirectArray().Add(lVectorsTop0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsTop1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsTop2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsTop3);
	//East

	lUVDiffuseElement->GetDirectArray().Add(lVectorsEast0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsEast1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsEast2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsEast3);
	//Bottom
	lUVDiffuseElement->GetDirectArray().Add(lVectorsBottom0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsBottom1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsBottom2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsBottom3);
	//West
	lUVDiffuseElement->GetDirectArray().Add(lVectorsWest0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsWest1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsWest2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsWest3);
	//North
	lUVDiffuseElement->GetDirectArray().Add(lVectorsNorth0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsNorth1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsNorth2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsNorth3);
	//South
	lUVDiffuseElement->GetDirectArray().Add(lVectorsSouth0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsSouth1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsSouth2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsSouth3);


	//FbxGeometryElementUV* lUVElement = lMesh->GetElementUV(0);
	//lUVElement->

	//Now we have set the UVs as eIndexToDirect reference and in eByPolygonVertex  mapping mode
	//we must update the size of the index array.
	lUVDiffuseElement->GetIndexArray().SetCount(24);
	int k = 0;
	// Create polygons. Assign texture and texture UV indices.
	for (i = 0; i < 6; i++)
		{
		// all faces of the cube have the same texture
		lMesh->BeginPolygon(-1, -1, -1, false);

		for (j = 0; j < 4; j++)
			{
			// Control point index
			lMesh->AddPolygon(lPolygonVertices[i * 4 + j]);
			// update the index array of the UVs that map the texture to the face
			lUVDiffuseElement->GetIndexArray().SetAt(i * 4 + j, k);
			k++;
			}

		lMesh->EndPolygon();
		}

	// create a FbxNode
	FbxNode* lNode = FbxNode::Create(gScene, lCubeName);

	// set the node attribute
	lNode->SetNodeAttribute(lMesh);

	// set the shading mode to view texture
	lNode->SetShadingMode(FbxNode::eTextureShading);


	//Assigned the materials to the mesh

	FbxGeometryElementMaterial* lMaterialElement = lMesh->CreateElementMaterial();
	lMaterialElement->SetMappingMode(FbxGeometryElement::eByPolygon);
	lMaterialElement->SetReferenceMode(FbxGeometryElement::eIndexToDirect);


	if (lNode == NULL)
		return;

	// We are in eByPolygon, so there's only need for 6 index (a cube has 6 polygons).
	lMaterialElement->GetIndexArray().SetCount(6);

	int TextureArray[] = { 0, 999, 999, 999, 999, 999, 999 };
	int ceilTex = -1;
	int eastTex = -1;
	int westTex = -1;
	int southTex = -1;
	int northTex = -1;
	int bottomTex = -1;

	ceilTex = FloorTexture(gScene, lNode, fCEIL, t);//0
	eastTex = WallTexture(gScene, lNode, fSELF, t);//1 east
	westTex = WallTexture(gScene, lNode, fWEST, t);//2
	southTex = WallTexture(gScene, lNode, fSOUTH, t);//3
	northTex = WallTexture(gScene, lNode, fSELF, t);//4//north
	bottomTex = FloorTexture(gScene, lNode, fBOTTOM, t);//5

	insertTexture(TextureArray, 1, bottomTex, 6);
	insertTexture(TextureArray, 3, ceilTex, 6);
	insertTexture(TextureArray, 2, eastTex, 6);
	insertTexture(TextureArray, 4, westTex, 6);
	insertTexture(TextureArray, 5, northTex, 6);
	insertTexture(TextureArray, 6, southTex, 7);

	int counter = 0;
	for (int i = 1; i <= 6; i++)
		{
		if (TextureArray[i] >= 0)
			{//Just add the material at that index.
			//printf("\nAdding Material %d at %d", TextureArray[i],i);
			lNode->AddMaterial(gScene->GetMaterial(TextureArray[i]));
			//Turn that texture index back into a counter.
			TextureArray[i] = counter;
			counter++;
			}
		}

	for (int i = 1; i <= 6; i++)
		{
		if (TextureArray[i] < 0)
			{
			lMaterialElement->GetIndexArray().SetAt(i - 1, TextureArray[-TextureArray[i]]);
			}
		else
			{
			lMaterialElement->GetIndexArray().SetAt(i - 1, TextureArray[i]);
			}
		}

	gScene->GetRootNode()->AddChild(lNode);

	}

void RenderFBXValleyNWTile(FbxScene*& gScene, int x, int y, tile &t, short Water, short invert)
	{
	int originalTile = t.tileType;
	t.tileType = TILE_SLOPE_N;
	RenderFBXSlopeNTile(gScene, x, y, t, Water, invert);
	t.tileType = TILE_SLOPE_W;
	RenderFBXSlopeWTile(gScene, x, y, t, Water, invert);
	t.tileType = originalTile;
	return;
	}

void RenderFBXValleyNETile(FbxScene*& gScene, int x, int y, tile &t, short Water, short invert)
	{
	int originalTile = t.tileType;
	t.tileType = TILE_SLOPE_E;
	RenderFBXSlopeETile(gScene, x, y, t, Water, invert);
	t.tileType = TILE_SLOPE_N;
	RenderFBXSlopeNTile(gScene, x, y, t, Water, invert);
	t.tileType = originalTile;
	return;
	}

void RenderFBXValleySWTile(FbxScene*& gScene, int x, int y, tile &t, short Water, short invert)
	{
	int originalTile = t.tileType;
	t.tileType = TILE_SLOPE_W;
	RenderFBXSlopeWTile(gScene, x, y, t, Water, invert);
	t.tileType = TILE_SLOPE_S;
	RenderFBXSlopeSTile(gScene, x, y, t, Water, invert);
	t.tileType = originalTile;
	return;
	}

void RenderFBXValleySETile(FbxScene*& gScene, int x, int y, tile &t, short Water, short invert)
	{
	int originalTile = t.tileType;
	t.tileType = TILE_SLOPE_E;
	RenderFBXSlopeETile(gScene, x, y, t, Water, invert);
	t.tileType = TILE_SLOPE_S;
	RenderFBXSlopeSTile(gScene, x, y, t, Water, invert);
	t.tileType = originalTile;
	return;
	}

void RenderFBXRidgeNWTile(FbxScene*& gScene, int x, int y, tile &t, short Water, short invert)
	{

	if (t.Render == 1)
		{
		if (invert == 0)

			{//consists of a slope n and a slope w
			if (t.isWater == Water)
				{
				RenderFBXSlopeNTile(gScene, x, y, t, Water, invert);
				RenderFBXSlopeWTile(gScene, x, y, t, Water, invert);
				}
			}
		else
			{
			//made of upper slope e and upper slope s

			RenderFBXSlopeETile(gScene, x, y, t, Water, invert);
			RenderFBXSlopeSTile(gScene, x, y, t, Water, invert);
			}

		}
	return;
	}

void RenderFBXRidgeNETile(FbxScene*& gScene, int x, int y, tile &t, short Water, short invert)
	{
	//consists of a slope n and a slope e

	if (t.Render == 1){
		if (invert == 0){
			if (t.isWater == Water)
				{
				RenderFBXSlopeNTile(gScene, x, y, t, Water, invert);
				RenderFBXSlopeETile(gScene, x, y, t, Water, invert);
				}
			}
		else
			{//invert is south and west slopes
			RenderFBXSlopeSTile(gScene, x, y, t, Water, invert);
			RenderFBXSlopeWTile(gScene, x, y, t, Water, invert);
			}
		}

	return;
	}

void RenderFBXRidgeSWTile(FbxScene*& gScene, int x, int y, tile &t, short Water, short invert)
	{
	//consists of a slope s and a slope w
	if (t.Render == 1)
	if (invert == 0)
		{
			{
			if (t.isWater == Water)
				{
				RenderFBXSlopeSTile(gScene, x, y, t, Water, invert);
				RenderFBXSlopeWTile(gScene, x, y, t, Water, invert);
				}
				}
		}
	else
		{	//invert is n and w slopes
		//render a ceiling version of this tile
		RenderFBXSlopeNTile(gScene, x, y, t, Water, invert);
		RenderFBXSlopeWTile(gScene, x, y, t, Water, invert);

		}
	return;
	}

void RenderFBXRidgeSETile(FbxScene*& gScene, int x, int y, tile &t, short Water, short invert)
	{
	//consists of a slope s and a slope e
	//done

	if (t.Render == 1)
		{
		if (invert == 0)
			{
			if (t.isWater == Water)
				{
				RenderFBXSlopeSTile(gScene, x, y, t, Water, invert);
				RenderFBXSlopeETile(gScene, x, y, t, Water, invert);
				}
			}
		else
			{//invert is n w
			//render a ceiling version of this tile
			//top and bottom faces move up
			RenderFBXSlopeNTile(gScene, x, y, t, Water, invert);
			RenderFBXSlopeWTile(gScene, x, y, t, Water, invert);
			}
		}
	return;
	}

void RenderFBXSlopeNTile(FbxScene*& gScene, int x, int y, tile &t, short Water, short invert)
	{
	char TileName[80] = "";
	if (t.Render == 1){
		if (invert == 0)
			{
			if (t.isWater == Water)
				{
				//A floor
				sprintf_s(TileName, 80, "%s_%02d_%02d\0", "Tile", x, y);
				RenderSlopedFBXCuboid(gScene, x, y, t, Water, -2, t.floorHeight, TILE_SLOPE_N, t.shockSteep, 1, TileName);
				}
			}
		else
			{
			//It's invert
			sprintf_s(TileName, 80, "%s_%02d_%02d\0", "Ceiling", x, y);
			RenderSlopedFBXCuboid(gScene, x, y, t, Water, CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + 1, TILE_SLOPE_N, t.shockSteep, 0, TileName);
			}
		}
	return;
	}

void RenderFBXSlopeSTile(FbxScene*& gScene, int x, int y, tile &t, short Water, short invert)
	{
	char TileName[80] = "";
	if (t.Render == 1){
		if (invert == 0)
			{
			if (t.isWater == Water)
				{
				//A floor
				sprintf_s(TileName, 80, "%s_%02d_%02d\0", "Tile", x, y);
				RenderSlopedFBXCuboid(gScene, x, y, t, Water, -2, t.floorHeight, TILE_SLOPE_S, t.shockSteep, 1, TileName);
				}
			}
		else
			{
			//It's invert
			sprintf_s(TileName, 80, "%s_%02d_%02d\0", "Ceiling", x, y);
			RenderSlopedFBXCuboid(gScene, x, y, t, Water, CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + 1, TILE_SLOPE_S, t.shockSteep, 0, TileName);
			}
		}
	return;
	}

void RenderFBXSlopeWTile(FbxScene*& gScene, int x, int y, tile &t, short Water, short invert)
	{
	char TileName[80] = "";
	if (t.Render == 1){
		if (invert == 0)
			{
			if (t.isWater == Water)
				{
				//A floor
				sprintf_s(TileName, 80, "%s_%02d_%02d\0", "Tile", x, y);
				RenderSlopedFBXCuboid(gScene, x, y, t, Water, -2, t.floorHeight, TILE_SLOPE_W, t.shockSteep, 1, TileName);
				}
			}
		else
			{
			//It's invert
			sprintf_s(TileName, 80, "%s_%02d_%02d\0", "Ceiling", x, y);
			RenderSlopedFBXCuboid(gScene, x, y, t, Water, CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + 1, TILE_SLOPE_W, t.shockSteep, 0, TileName);
			}
		}
	return;
	}

void RenderFBXSlopeETile(FbxScene*& gScene, int x, int y, tile &t, short Water, short invert)
	{
	char TileName[80] = "";
	if (t.Render == 1){
		if (invert == 0)
			{
			if (t.isWater == Water)
				{
				//A floor
				sprintf_s(TileName, 80, "%s_%02d_%02d\0", "Tile", x, y);
				RenderSlopedFBXCuboid(gScene, x, y, t, Water, -2, t.floorHeight, TILE_SLOPE_E, t.shockSteep, 1, TileName);
				}
			}
		else
			{
			//It's invert
			sprintf_s(TileName, 80, "%s_%02d_%02d\0", "Ceiling", x, y);
			RenderSlopedFBXCuboid(gScene, x, y, t, Water, CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + 1, TILE_SLOPE_E, t.shockSteep, 0, TileName);
			}
		}
	return;
	}

void RenderSlopedFBXCuboid(FbxScene*& gScene, int x, int y, tile &t, short Water, int Bottom, int Top, int SlopeDir, int Steepness, int Floor, char *TileName)
	{
	int AdjustUpperNorth = 0;
	int AdjustUpperSouth = 0;
	int AdjustUpperEast = 0;
	int AdjustUpperWest = 0;

	int AdjustLowerNorth = 0;
	int AdjustLowerSouth = 0;
	int AdjustLowerEast = 0;
	int AdjustLowerWest = 0;
	if (Floor == 1)
		{
		switch (SlopeDir)
			{
			case TILE_SLOPE_N:
				AdjustUpperNorth = Steepness*BrushSizeZ;
				break;
			case TILE_SLOPE_S:
				AdjustUpperSouth = Steepness*BrushSizeZ;
				break;
			case TILE_SLOPE_E:
				AdjustUpperEast = Steepness*BrushSizeZ;
				break;
			case TILE_SLOPE_W:
				AdjustUpperWest = Steepness*BrushSizeZ;
				break;
			}
		}
	if (Floor == 0)
		{
		switch (SlopeDir)
			{
				case TILE_SLOPE_N:
					AdjustLowerNorth = -Steepness*BrushSizeZ;
					break;
				case TILE_SLOPE_S:
					AdjustLowerSouth = -Steepness*BrushSizeZ;
					break;
				case TILE_SLOPE_E:
					AdjustLowerEast = -Steepness*BrushSizeZ;
					break;
				case TILE_SLOPE_W:
					AdjustLowerWest = -Steepness*BrushSizeZ;
					break;
			}
		}

	FbxString lCubeName = TileName;
	//lCubeName += FbxString(gCubeNumber);
	// create a new cube
	int i, j;
	FbxMesh* lMesh = FbxMesh::Create(gScene, lCubeName);

	FbxVector4 lControlPoint0(t.tileX*BrushSizeX, t.tileY*BrushSizeY, Top*BrushSizeZ + AdjustUpperWest + AdjustUpperSouth);
	FbxVector4 lControlPoint1((t.tileX + t.DimX)*BrushSizeX, t.tileY*BrushSizeY, Top*BrushSizeZ + AdjustUpperEast + AdjustUpperSouth);
	FbxVector4 lControlPoint2((t.tileX + t.DimX)*BrushSizeX, (t.tileY + t.DimY)*BrushSizeY, Top*BrushSizeZ + AdjustUpperEast + AdjustUpperNorth);
	FbxVector4 lControlPoint3(t.tileX*BrushSizeX, (t.tileY + t.DimY)*BrushSizeY, Top*BrushSizeZ + AdjustUpperWest + AdjustUpperNorth);
	
	FbxVector4 lControlPoint4(t.tileX*BrushSizeX, t.tileY*BrushSizeY, Bottom*BrushSizeZ + AdjustLowerEast + AdjustLowerNorth);
	FbxVector4 lControlPoint5((t.tileX + t.DimX)*BrushSizeX, t.tileY*BrushSizeY, Bottom*BrushSizeZ + AdjustLowerWest + AdjustLowerNorth);
	FbxVector4 lControlPoint6((t.tileX + t.DimX)*BrushSizeX, (t.tileY + t.DimY)*BrushSizeY, Bottom*BrushSizeZ+ AdjustLowerWest + AdjustLowerSouth);
	FbxVector4 lControlPoint7(t.tileX*BrushSizeX, (t.tileY + t.DimY)*BrushSizeY, Bottom*BrushSizeZ + AdjustLowerEast + AdjustLowerSouth);

	FbxVector4 lNormalXPos(1, 0, 0);
	FbxVector4 lNormalXNeg(-1, 0, 0);
	FbxVector4 lNormalYPos(0, 1, 0);
	FbxVector4 lNormalYNeg(0, -1, 0);
	FbxVector4 lNormalZPos(0, 0, 1);
	FbxVector4 lNormalZNeg(0, 0, -1);
	
	// Create control points.
	lMesh->InitControlPoints(24);
	FbxVector4* lControlPoints = lMesh->GetControlPoints();

	//These directions are wrongly labeled???!!!
	//Top
	switch (t.tileType)
		{
			case TILE_SLOPE_N:
		    case TILE_SLOPE_S:
				lControlPoints[0] = lControlPoint2;
				lControlPoints[1] = lControlPoint3;
				lControlPoints[2] = lControlPoint0;
				lControlPoints[3] = lControlPoint1;
				break;
			default:
				lControlPoints[0] = lControlPoint0;
				lControlPoints[1] = lControlPoint1;
				lControlPoints[2] = lControlPoint2;
				lControlPoints[3] = lControlPoint3;
				break;
		}


	//was Bottom is probably east.
	//lControlPoints[4] = lControlPoint1;
	//lControlPoints[5] = lControlPoint5;
	//lControlPoints[6] = lControlPoint6;
	//lControlPoints[7] = lControlPoint2;
	lControlPoints[4] = lControlPoint5;
	lControlPoints[5] = lControlPoint6;
	lControlPoints[6] = lControlPoint2;
	lControlPoints[7] = lControlPoint1;


	//not East?
	lControlPoints[8] = lControlPoint5;
	lControlPoints[9] = lControlPoint4;
	lControlPoints[10] = lControlPoint7;
	lControlPoints[11] = lControlPoint6;


	//West
	lControlPoints[12] = lControlPoint7;
	lControlPoints[13] = lControlPoint4;
	lControlPoints[14] = lControlPoint0;
	lControlPoints[15] = lControlPoint3;

	//North
	lControlPoints[16] = lControlPoint6;
	lControlPoints[17] = lControlPoint7;
	lControlPoints[18] = lControlPoint3;
	lControlPoints[19] = lControlPoint2;

	//South
	lControlPoints[20] = lControlPoint4;
	lControlPoints[21] = lControlPoint5;
	lControlPoints[22] = lControlPoint1;
	lControlPoints[23] = lControlPoint0;

	// We want to have one normal for each vertex (or control point),
	// so we set the mapping mode to eByControlPoint.
	FbxGeometryElementNormal* lGeometryElementNormal = lMesh->CreateElementNormal();

	lGeometryElementNormal->SetMappingMode(FbxGeometryElement::eByControlPoint);

	// Set the normal values for every control point.
	lGeometryElementNormal->SetReferenceMode(FbxGeometryElement::eDirect);

	lGeometryElementNormal->GetDirectArray().Add(lNormalZPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalZPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalZPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalZPos);

	lGeometryElementNormal->GetDirectArray().Add(lNormalXPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalXPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalXPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalXPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalZNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalZNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalZNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalZNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalXNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalXNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalXNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalXNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalYPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalYPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalYPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalYPos);
	lGeometryElementNormal->GetDirectArray().Add(lNormalYNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalYNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalYNeg);
	lGeometryElementNormal->GetDirectArray().Add(lNormalYNeg);


	// Array of polygon vertices.
	int lPolygonVertices[] = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13,
		14, 15, 16, 17, 18, 19, 20, 21, 22, 23 };


	// Create UV for Diffuse channel.
	FbxGeometryElementUV* lUVDiffuseElement = lMesh->CreateElementUV("DiffuseUV");
	FBX_ASSERT(lUVDiffuseElement != NULL);
	lUVDiffuseElement->SetMappingMode(FbxGeometryElement::eByPolygonVertex);
	lUVDiffuseElement->SetReferenceMode(FbxGeometryElement::eIndexToDirect);

	float PolySize = Top - Bottom;
	float offset = 0;//-0.125;
	offset = CalcCeilOffset(iGame, fNORTH, t);
	FbxVector2 lVectorsNorth0(0, Bottom*0.125 - offset);//bottom left corner
	FbxVector2 lVectorsNorth1(1, Bottom*0.125 - offset);//bottom right corner
	FbxVector2 lVectorsNorth2(1, (PolySize / 8) + (Bottom*0.125) - offset);//top right corner
	FbxVector2 lVectorsNorth3(0, (PolySize / 8) + (Bottom*0.125) - offset);//top left corner.
	offset = CalcCeilOffset(iGame, fSOUTH, t);
	FbxVector2 lVectorsSouth0(0, Bottom*0.125 - offset);//bottom left corner
	FbxVector2 lVectorsSouth1(1, Bottom*0.125 - offset);//bottom right corner
	FbxVector2 lVectorsSouth2(1, (PolySize / 8) + (Bottom*0.125) - offset);//top right corner
	FbxVector2 lVectorsSouth3(0, (PolySize / 8) + (Bottom*0.125) - offset);//top left corner.
	offset = CalcCeilOffset(iGame, fEAST, t);
	FbxVector2 lVectorsEast0(0, Bottom*0.125 - offset);//bottom left corner
	FbxVector2 lVectorsEast1(1, Bottom*0.125 - offset);//bottom right corner
	FbxVector2 lVectorsEast2(1, (PolySize / 8) + (Bottom*0.125) - offset);//top right corner
	FbxVector2 lVectorsEast3(0, (PolySize / 8) + (Bottom*0.125) - offset);//top left corner.
	offset = CalcCeilOffset(iGame, fWEST, t);
	FbxVector2 lVectorsWest0(0, Bottom*0.125 - offset);//bottom left corner
	FbxVector2 lVectorsWest1(1, Bottom*0.125 - offset);//bottom right corner
	FbxVector2 lVectorsWest2(1, (PolySize / 8) + (Bottom*0.125) - offset);//top right corner
	FbxVector2 lVectorsWest3(0, (PolySize / 8) + (Bottom*0.125) - offset);//top left corner.

	//bottom vectors
	FbxVector2 lVectorsBottom0(0, 0);
	FbxVector2 lVectorsBottom1(1, 0);
	FbxVector2 lVectorsBottom2(1, 1);
	FbxVector2 lVectorsBottom3(0, 1);

	//top vectors
	FbxVector2 lVectorsTop0(0, 0);
	FbxVector2 lVectorsTop1(1, 0);
	FbxVector2 lVectorsTop2(1, 1);
	FbxVector2 lVectorsTop3(0, 1);
	//Top
	lUVDiffuseElement->GetDirectArray().Add(lVectorsTop0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsTop1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsTop2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsTop3);
	//East

	lUVDiffuseElement->GetDirectArray().Add(lVectorsEast0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsEast1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsEast2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsEast3);
	//Bottom
	lUVDiffuseElement->GetDirectArray().Add(lVectorsBottom0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsBottom1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsBottom2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsBottom3);
	//West
	lUVDiffuseElement->GetDirectArray().Add(lVectorsWest0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsWest1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsWest2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsWest3);
	//North
	lUVDiffuseElement->GetDirectArray().Add(lVectorsNorth0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsNorth1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsNorth2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsNorth3);
	//South
	lUVDiffuseElement->GetDirectArray().Add(lVectorsSouth0);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsSouth1);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsSouth2);
	lUVDiffuseElement->GetDirectArray().Add(lVectorsSouth3);


	//FbxGeometryElementUV* lUVElement = lMesh->GetElementUV(0);
	//lUVElement->

	//Now we have set the UVs as eIndexToDirect reference and in eByPolygonVertex  mapping mode
	//we must update the size of the index array.
	lUVDiffuseElement->GetIndexArray().SetCount(24);
	int k = 0;
	// Create polygons. Assign texture and texture UV indices.
	for (i = 0; i < 6; i++)
		{
		// all faces of the cube have the same texture
		lMesh->BeginPolygon(-1, -1, -1, false);

		for (j = 0; j < 4; j++)
			{
			// Control point index
			lMesh->AddPolygon(lPolygonVertices[i * 4 + j]);
			// update the index array of the UVs that map the texture to the face
			lUVDiffuseElement->GetIndexArray().SetAt(i * 4 + j, k);
			k++;
			}
		lMesh->EndPolygon();
		}

	// create a FbxNode
	FbxNode* lNode = FbxNode::Create(gScene, lCubeName);

	// set the node attribute
	lNode->SetNodeAttribute(lMesh);

	// set the shading mode to view texture
	lNode->SetShadingMode(FbxNode::eTextureShading);


	//Assigned the materials to the mesh

	FbxGeometryElementMaterial* lMaterialElement = lMesh->CreateElementMaterial();
	lMaterialElement->SetMappingMode(FbxGeometryElement::eByPolygon);
	lMaterialElement->SetReferenceMode(FbxGeometryElement::eIndexToDirect);


	if (lNode == NULL)
		return;

	// We are in eByPolygon, so there's only need for 6 index (a cube has 6 polygons).
	lMaterialElement->GetIndexArray().SetCount(6);

	int TextureArray[] = { 0, 999, 999, 999, 999, 999, 999 };
	int ceilTex = -1;
	int eastTex = -1;
	int westTex = -1;
	int southTex = -1;
	int northTex = -1;
	int bottomTex = -1;

	ceilTex = FloorTexture(gScene, lNode, fCEIL, t);//0
	eastTex = WallTexture(gScene, lNode, fEAST, t);//1
	westTex = WallTexture(gScene, lNode, fWEST, t);//2
	southTex = WallTexture(gScene, lNode, fSOUTH, t);//3
	northTex = WallTexture(gScene, lNode, fNORTH, t);//4
	bottomTex = FloorTexture(gScene, lNode, fBOTTOM, t);//5

	insertTexture(TextureArray, 1, bottomTex, 6);
	insertTexture(TextureArray, 3, ceilTex, 6);
	insertTexture(TextureArray, 2, eastTex, 6);
	insertTexture(TextureArray, 4, westTex, 6);
	insertTexture(TextureArray, 5, northTex, 6);
	insertTexture(TextureArray, 6, southTex, 7);

	int counter = 0;
	for (int i = 1; i <= 6; i++)
		{
		if (TextureArray[i] >= 0)
			{//Just add the material at that index.
			//printf("\nAdding Material %d at %d", TextureArray[i],i);
			lNode->AddMaterial(gScene->GetMaterial(TextureArray[i]));
			//Turn that texture index back into a counter.
			TextureArray[i] = counter;
			counter++;
			}
		}

	for (int i = 1; i <= 6; i++)
		{
		if (TextureArray[i] < 0)
			{
			lMaterialElement->GetIndexArray().SetAt(i - 1, TextureArray[-TextureArray[i]]);
			}
		else
			{
			lMaterialElement->GetIndexArray().SetAt(i - 1, TextureArray[i]);
			}
		}

	gScene->GetRootNode()->AddChild(lNode);

	}

void CreateFBXMaterials(FbxScene*& gScene, int game)
	{
	/*Populates the texture list for the fbx model file*/
	FbxFileTexture* gTexture = NULL;
	FbxSurfacePhong* gMaterial = NULL;
	int NoOfMaterials =0;
	switch (game)
		{
		case UWDEMO:
		case UW1:
			NoOfMaterials = 269;
			break;
		case UW2:
			NoOfMaterials = 255;
			break;
		case SHOCK:
			NoOfMaterials = 339;
			break;
		}

	for (int i = 0; i <= NoOfMaterials; i++)
		{
		char MaterialName[20] = "";
		switch (game)
			{
			case UWDEMO:
			case UW1:
				sprintf_s(MaterialName, 20, textureMasters[i].path);
				//if (i <= 262)
				//	{//Regular textures
				//	sprintf_s(MaterialName, 20, "uw1_%03d\0", i);
				//	}
				//else if(i <= 266)
				//	{//pillars
				//	sprintf_s(MaterialName, 20, "tmobj_%02d\0", i-263);
				//	}
				//else if (i <= 268)
				//	{//pillars
				//	sprintf_s(MaterialName, 20, "tmobj_%02d\0", i - 263);
				//	}
				break;
			case UW2:
				sprintf_s(MaterialName, 20, "uw2_%03d\0", i);
				break;
			case SHOCK:
				//sprintf_s(MaterialName, 20, "shock_%03d\0", i);
				sprintf_s(MaterialName, 20, textureMasters[i].path);
				break;
			}
		
		FbxString lMaterialName = MaterialName;
		FbxString lShadingName = "Phong";
		FbxDouble3 lBlack(0.0, 0.0, 0.0);
		FbxDouble3 lRed(1.0, 0.0, 0.0);
		FbxDouble3 lDiffuseColor(0.75, 0.75, 0.0);
		gMaterial = FbxSurfacePhong::Create(gScene, lMaterialName.Buffer());
		// Generate primary and secondary colors.
		gMaterial->Emissive.Set(lBlack);
		gMaterial->Ambient.Set(lRed);
		gMaterial->Diffuse.Set(lDiffuseColor);
		gMaterial->TransparencyFactor.Set(40.5);
		gMaterial->ShadingModel.Set(lShadingName);
		gMaterial->Shininess.Set(0.5);
		//Create the matching texture
		char textureName[44] = "";
		sprintf_s(textureName, 44, "%s.tga\0", MaterialName);
		gTexture = FbxFileTexture::Create(gScene, MaterialName);

		// Resource file must be in the application's directory.

		FbxString lTexPath = textureName;

		// Set texture properties.
		gTexture->SetFileName(lTexPath.Buffer());
		gTexture->SetTextureUse(FbxTexture::eStandard);
		//gTexture->SetMappingType(FbxTexture::eUV);
		gTexture->SetMappingType(FbxTexture::EMappingType::eUV);
		gTexture->SetMaterialUse(FbxFileTexture::eModelMaterial);
		gTexture->SetSwapUV(false);
		gTexture->SetTranslation(0.0, 0.0);
		gTexture->SetScale(1, 1);
		gTexture->SetRotation(0, 0.0);
		gTexture->SetWrapMode(FbxTexture::EWrapMode::eRepeat, FbxTexture::EWrapMode::eRepeat);

		gMaterial->Diffuse.ConnectSrcObject(gTexture);

		}
	}

int WallTexture(FbxScene*& gScene, FbxNode*& lNode, int face, tile t)
	{
	int wallTexture;
	float uAx_1 = 0;
	float uAx_2 = 1;
	float uAx_3 = 0;
	float uAx_4 = 0;
	float vAx_1 = 0;
	float vAx_2 = 0;
	float vAx_3 = -1;
	float vAx_4 = 0;
	//int textureOffset = 1;
	int ceilOffset = 0;
	wallTexture = t.wallTexture;
	if (iGame == SHOCK)
		{ //I need to calculate an offset for SHOCK.
		ceilOffset = t.ceilingHeight;
		}

	switch (face)
		{
			case fSOUTH:
				wallTexture = t.South;
				if ((iGame == SHOCK))
					{
					ceilOffset = t.shockSouthCeilHeight;
					}
				uAx_1 = 1;
				uAx_2 = 0;
				uAx_3 = 0;
				uAx_4 = 0;
				vAx_1 = 0;
				vAx_2 = 0;
				vAx_3 = -1;
				vAx_4 = 0;
				break;
			case fNORTH:
				wallTexture = t.North;
				if ((iGame == SHOCK))
					{
					ceilOffset = t.shockNorthCeilHeight;
					}
				uAx_1 = -1;
				uAx_2 = 0;
				uAx_3 = 0;
				uAx_4 = 0;
				vAx_1 = 0;
				vAx_2 = 0;
				vAx_3 = -1;
				vAx_4 = 0;
				break;
			case fEAST:
				wallTexture = t.East;
				if ((iGame == SHOCK))
					{
					ceilOffset = t.shockEastCeilHeight;
					}
				uAx_1 = 0;
				uAx_2 = 1;
				uAx_3 = 0;
				uAx_4 = 0;
				vAx_1 = 0;
				vAx_2 = 0;
				vAx_3 = -1;
				vAx_4 = 0;
				break;
			case fWEST:
				wallTexture = t.West;
				if ((iGame == SHOCK))
					{
					ceilOffset = t.shockWestCeilHeight;
					}
				uAx_1 = 0;
				uAx_2 = -1;
				uAx_3 = 0;
				uAx_4 = 0;
				vAx_1 = 0;
				vAx_2 = 0;
				vAx_3 = -1;
				vAx_4 = 0;
				break;
		}
	if ((wallTexture<0) || (wallTexture >512))
		{
		wallTexture = 0;
		}

	if (iGame == SHOCK)
		{
		float shock_ceil = SHOCK_CEILING_HEIGHT;
		float floorOffset = shock_ceil - ceilOffset - 8;	//The floor of the tile if it is 1 texture tall.
		while (floorOffset >= 8)	//Reduce the offset to 0 to 7 since textures go up in steps of 1/8ths
			{
			floorOffset -= 8;
			}
		vAx_4 = (floorOffset)* 16;
		}
	
	//lNode->AddMaterial(gMaterial[wallTexture]);
	//printf("\nTexture is %d", wallTexture);
	//lNode->AddMaterial(gScene->GetMaterial(wallTexture));
	return wallTexture;
	//fprintf(MAPFILE, "\t\t\t\"material\" \"%s\"\n", textureMasters[wallTexture].path);
	//fprintf(MAPFILE, "\t\t\t\"uaxis\" \"[%f %f %f %f] %f\"\n", uAx_1, uAx_2, uAx_3, uAx_4, 0.9375);
	//fprintf(MAPFILE, "\t\t\t\"vaxis\" \"[%f %f %f %f] %f\"\n", vAx_1, vAx_2, vAx_3, vAx_4, 0.9375);
	}

int FloorTexture(FbxScene*& gScene, FbxNode*& lNode, int face, tile t)
	{
	int floorTexture;

	if (face == fCEIL)
		{
		floorTexture = t.shockCeilingTexture;
		}
	else
		{
		floorTexture = t.floorTexture;
		}

	if ((floorTexture<0) || (floorTexture >512))
		{
		floorTexture = 0;
		}

	//lNode->AddMaterial(gMaterial[floorTexture]);//Top
	//printf("\nTexture is %d", floorTexture);
	//lNode->AddMaterial(gScene->GetMaterial(floorTexture));
	return floorTexture;
	}

float CalcCeilOffset(int game, int face, tile &t)
	{
	int ceilOffset = t.ceilingHeight;

	if (game != SHOCK)
		{
		return 0;
		}
	else
		{
		switch (face)
			{
				case fEAST:
					ceilOffset = t.shockEastCeilHeight; break;
				case fWEST:
					ceilOffset = t.shockWestCeilHeight; break;
				case fSOUTH:
					ceilOffset = t.shockSouthCeilHeight; break;
				case fNORTH:
					ceilOffset = t.shockNorthCeilHeight; break;
			}
		float shock_ceil = SHOCK_CEILING_HEIGHT;
		float floorOffset = shock_ceil - ceilOffset - 8;	//The floor of the tile if it is 1 texture tall.
		while (floorOffset >= 8)	//Reduce the offset to 0 to 7 since textures go up in steps of 1/8ths
			{
			floorOffset -= 8;
			}
		return floorOffset * 0.125;
		}

	}

void RenderFBXDoorway(FbxScene*& gScene, int game, int x, int y, tile &t, ObjectItem currDoor)
	{//Renders Door frames for UW
	//TODO:Define door widths in config file. 
	//int DOORWIDTH = 60;
	//int doorHeight = 96;
	//int DOORHEIGHTUNITS =6;
	int FrameSideX = (BrushSizeX - DOORWIDTH) / 2;
	int FrameSideY = (BrushSizeY - DOORWIDTH) / 2;
	int resolution=7;
	//float DOORTHICKNESS = 2;
	float BrushX = BrushSizeX;
	float BrushY = BrushSizeY;
	float BrushZ = BrushSizeZ;
	float doorOffset = 0;

	float x0; float y0; float z0;
	float x1; float y1; float z1;

	float offX = (x*BrushX) + ((currDoor.x) * (BrushX / resolution));//from obj position code
	float offY = (y*BrushY) + ((currDoor.y) * (BrushY / resolution));
	float offZ = (currDoor.zpos) >> 2;//The floor level of the actual door object
	offZ = t.floorHeight;
	int heading = 0;

	tile tmpt;
	tmpt.tileType = TILE_SOLID;//t.tileType;
	tmpt.DimX = 1;
	tmpt.DimY = 1;

	tmpt.East = t.wallTexture;
	tmpt.West = t.wallTexture;
	tmpt.South = t.wallTexture;
	tmpt.North = t.wallTexture;
	tmpt.floorHeight=t.ceilingHeight;//this is deliberate
	tmpt.ceilingHeight=t.ceilingHeight;
	tmpt.tileX=t.tileX;
	tmpt.tileY = t.tileY;
	if (game != SHOCK)
		{
		heading = currDoor.heading;
		}
	
	switch (heading)
		{
		case EAST:
		case WEST:
			{
			if (currDoor.x == 0)
				{
				doorOffset = +2;
				}
			if (currDoor.x == 7)
				{
				doorOffset = -2;
				}

			if (heading == EAST)
				{
				offY = (y*BrushY) + ((BrushY - DOORWIDTH) / 2) + DOORWIDTH;
				}
			else
				{
				offY = (y*BrushY) + ((BrushY - DOORWIDTH) / 2);
				}
		
/*
left side. east west door	
*/
			x1 = ((offX + DOORTHICKNESS + doorOffset));
			y1 = ((y + 1)*BrushY);
			z1 = BrushZ * (CEILING_HEIGHT + 1); //(offZ*BrushZ + doorHeight);
			x0 = ((offX - DOORTHICKNESS + doorOffset));
			if (heading == EAST)
				{
				y0 = (offY);
				//fprintf(MAPFILE, "( 0 -1 0 %f )", +(offY));
				}
			else
				{
				y0 = (offY)+DOORWIDTH;
				}
			z0 = -2*BrushZ;
			FbxVector4 lControlPointl0(x0, y0, z1);
			FbxVector4 lControlPointl1(x1, y0, z1);
			FbxVector4 lControlPointl2(x1, y1, z1);
			FbxVector4 lControlPointl3(x0, y1, z1);
			FbxVector4 lControlPointl4(x0, y0, z0);
			FbxVector4 lControlPointl5(x1, y0, z0);
			FbxVector4 lControlPointl6(x1, y1, z0);
			FbxVector4 lControlPointl7(x0, y1, z0);
			RenderFBXCuboid(gScene, x, y, tmpt, 0, -2, CEILING_HEIGHT + 1, "lefthand",
				lControlPointl0, lControlPointl1, lControlPointl2, lControlPointl3, 
				lControlPointl4, lControlPointl5, lControlPointl6, lControlPointl7, 
				-FrameSideY / BrushY, (((BrushY - DOORWIDTH) / 2) / BrushY) - (FrameSideY / BrushY),
				0, ((BrushY - DOORWIDTH) / 2) / BrushY,
				0, 1, 
				0, 1);

/* 
right side east west door
*/
			x1=((offX + DOORTHICKNESS + doorOffset));
			if (heading == EAST)
				{
				y1=(offY - DOORWIDTH);
				}
			else
				{
				y1=(offY);
				}
			z1 = BrushZ * (CEILING_HEIGHT + 1);
			x0=+((offX - DOORTHICKNESS + doorOffset));
			y0=+(y * BrushY);
			z0 = -2 * BrushZ;
			FbxVector4 lControlPointr0(x0, y0, z1);
			FbxVector4 lControlPointr1(x1, y0, z1);
			FbxVector4 lControlPointr2(x1, y1, z1);
			FbxVector4 lControlPointr3(x0, y1, z1);
			FbxVector4 lControlPointr4(x0, y0, z0);
			FbxVector4 lControlPointr5(x1, y0, z0);
			FbxVector4 lControlPointr6(x1, y1, z0);
			FbxVector4 lControlPointr7(x0, y1, z0);
			RenderFBXCuboid(gScene, x, y, tmpt, 0, -2, CEILING_HEIGHT + 1, "rightdoor",
				lControlPointr0, lControlPointr1, lControlPointr2, lControlPointr3,
				lControlPointr4, lControlPointr5, lControlPointr6, lControlPointr7, 
				0, ((BrushY - DOORWIDTH) / 2) / BrushY, 
				-FrameSideY / BrushY, (((BrushY - DOORWIDTH) / 2) / BrushY) - (FrameSideY / BrushY),
				0, 1, 
				0, 1);


/*
over the door, east west door
*/			tmpt.tileType = TILE_OPEN;//Treat this as a dropped ceiling.
			tmpt.ceilingHeight = CEILING_HEIGHT - t.floorHeight - DOORHEIGHTUNITS;
			x1 = ((offX + DOORTHICKNESS + doorOffset));
			y1 = ((y + 1)*BrushY);
			z1 = BrushZ * (CEILING_HEIGHT + 1);
			x0 = +((offX - DOORTHICKNESS + doorOffset));
			y0 = +(y * BrushY);
			z0 = (CEILING_HEIGHT - tmpt.ceilingHeight) * BrushZ;
			FbxVector4 lControlPointo0(x0, y0, z1);
			FbxVector4 lControlPointo1(x1, y0, z1);
			FbxVector4 lControlPointo2(x1, y1, z1);
			FbxVector4 lControlPointo3(x0, y1, z1);
			FbxVector4 lControlPointo4(x0, y0, z0);
			FbxVector4 lControlPointo5(x1, y0, z0);
			FbxVector4 lControlPointo6(x1, y1, z0);
			FbxVector4 lControlPointo7(x0, y1, z0);
			RenderFBXCuboid(gScene, x, y, tmpt, 0, CEILING_HEIGHT - tmpt.ceilingHeight, CEILING_HEIGHT + 1, "over",
				lControlPointo0, lControlPointo1, lControlPointo2, lControlPointo3,
				lControlPointo4, lControlPointo5, lControlPointo6, lControlPointo7, 0, 1,0,1,0,1,0,1);

			break;
			}
		
	case NORTH:
	case SOUTH:
			{
			if (currDoor.y == 0)
				{
				doorOffset = +2;
				}
			if (currDoor.y == 7)
				{
				doorOffset = -2;
				}
			if (heading == NORTH) 
				{
				offX = (x*BrushSizeX) + ((BrushSizeX - DOORWIDTH) / 2) + DOORWIDTH;
				}
			else
				{
				offX = (x*BrushSizeX) + ((BrushSizeX - DOORWIDTH) / 2);
				}

			/*Left Side. north south door*/
			//left side
			//east face 
			if ((heading == NORTH) || (heading == SHOCK_NORTH))
				{
				x1= (offX - DOORWIDTH);
				}
			else
				{
				x1 = (offX);
				}
			//north face 
			y1=(offY + DOORTHICKNESS + doorOffset);
			//top face
			//z1=(offZ*BrushZ + doorHeight);
			z1 = BrushZ * (CEILING_HEIGHT + 1); //(offZ*BrushZ + doorHeight);
			//west face
			x0=((x)*BrushX);
			//south face
			y0=(offY - DOORTHICKNESS + doorOffset);
			//bottom face

			z0 = -2 * BrushZ;
			FbxVector4 lControlPointl0(x0, y0, z1);
			FbxVector4 lControlPointl1(x1, y0, z1);
			FbxVector4 lControlPointl2(x1, y1, z1);
			FbxVector4 lControlPointl3(x0, y1, z1);
			FbxVector4 lControlPointl4(x0, y0, z0);
			FbxVector4 lControlPointl5(x1, y0, z0);
			FbxVector4 lControlPointl6(x1, y1, z0);
			FbxVector4 lControlPointl7(x0, y1, z0);
			RenderFBXCuboid(gScene, x, y, tmpt, 0, -2, CEILING_HEIGHT + 1, "lefthand_ns",
				lControlPointl0, lControlPointl1, lControlPointl2, lControlPointl3,
				lControlPointl4, lControlPointl5, lControlPointl6, lControlPointl7,
				0, 1,
				0, 1,
				-FrameSideX / BrushX, (((BrushX - DOORWIDTH) / 2) / BrushX) - (FrameSideX / BrushX),
				0, ((BrushX - DOORWIDTH) / 2) / BrushX
				);

			/*Right side. north south doorway*/
			//right
			//east face 
			x1=((x + 1)*BrushX);
			//north face 
			y1=(offY + DOORTHICKNESS + doorOffset);
			//top face
			//z1=(offZ*BrushZ + doorHeight);
			z1 = BrushZ * (CEILING_HEIGHT + 1);
			//west face
			if ((heading == NORTH) || (heading == SHOCK_NORTH))
				{
				x0=(offX);
				}
			else
				{
				x0=(offX + DOORWIDTH);
				}
			//south face
			y0=(offY - DOORTHICKNESS + doorOffset);
			//bottom face
			//z0= offZ * BrushZ);	//to go underneath
			z0 = -2 * BrushZ;
			FbxVector4 lControlPointr0(x0, y0, z1);
			FbxVector4 lControlPointr1(x1, y0, z1);
			FbxVector4 lControlPointr2(x1, y1, z1);
			FbxVector4 lControlPointr3(x0, y1, z1);
			FbxVector4 lControlPointr4(x0, y0, z0);
			FbxVector4 lControlPointr5(x1, y0, z0);
			FbxVector4 lControlPointr6(x1, y1, z0);
			FbxVector4 lControlPointr7(x0, y1, z0);
			RenderFBXCuboid(gScene, x, y, tmpt, 0, -2, CEILING_HEIGHT + 1, "rightdoorns",
				lControlPointr0, lControlPointr1, lControlPointr2, lControlPointr3,
				lControlPointr4, lControlPointr5, lControlPointr6, lControlPointr7,
				0, 1,
				0, 1,
				0, ((BrushY - DOORWIDTH) / 2) / BrushY,
				-FrameSideY / BrushY, (((BrushY - DOORWIDTH) / 2) / BrushY) - (FrameSideY / BrushY));

			/*Over the door North South*/
			tmpt.tileType = TILE_OPEN;//Treat this as a dropped ceiling.
			tmpt.ceilingHeight = CEILING_HEIGHT - t.floorHeight - DOORHEIGHTUNITS;
			//top
			//east face 
			x1= ((x + 1)*BrushX);
			//north face 
			y1= (offY + DOORTHICKNESS + doorOffset);
			//top face
			z1 = BrushZ * (CEILING_HEIGHT + 1);
			//west face
			x0=+(x*BrushX);
			//south face
			y0=+(offY - DOORTHICKNESS + doorOffset);
			//bottom face
			z0 = (CEILING_HEIGHT - tmpt.ceilingHeight) * BrushZ;
			FbxVector4 lControlPointo0(x0, y0, z1);
			FbxVector4 lControlPointo1(x1, y0, z1);
			FbxVector4 lControlPointo2(x1, y1, z1);
			FbxVector4 lControlPointo3(x0, y1, z1);
			FbxVector4 lControlPointo4(x0, y0, z0);
			FbxVector4 lControlPointo5(x1, y0, z0);
			FbxVector4 lControlPointo6(x1, y1, z0);
			FbxVector4 lControlPointo7(x0, y1, z0);
			RenderFBXCuboid(gScene, x, y, tmpt, 0, CEILING_HEIGHT - tmpt.ceilingHeight, CEILING_HEIGHT + 1, "overns",
				lControlPointo0, lControlPointo1, lControlPointo2, lControlPointo3,
				lControlPointo4, lControlPointo5, lControlPointo6, lControlPointo7, 0, 1, 0, 1, 0, 1, 0, 1);
			break;
			}
		}
	}

void RenderFBXPillars(FbxScene*& gScene, int game, tile LevelInfo[64][64], ObjectItem objList[1600])
	{
	//Renders a pillar as a brush. I can't use an object here since it needs to extend to variable heights etc.
	int x; int y;
	float offX; float offY; float offZ;
	float x0; float y0; float z0;
	float x1; float y1; float z1;

	for (y = 0; y <= 63; y++)
		{
		for (x = 0; x <= 63; x++)
			{
			if ((LevelInfo[x][y].indexObjectList != 0))
				{
				long nextObj = LevelInfo[x][y].indexObjectList;
				while (nextObj != 0)
					{
					if (objectMasters[objList[nextObj].item_id].type == PILLAR)
						{
						int textureIndex = objList[nextObj].flags & 0x3F;
						tile tmpt;
						tmpt.tileType = TILE_SOLID;//t.tileType;
						tmpt.DimX = 1;
						tmpt.DimY = 1;
						tmpt.wallTexture = 263 + textureIndex;
						tmpt.floorTexture = LevelInfo[x][y].floorTexture;
						tmpt.East =263 + textureIndex;// LevelInfo[x][y].wallTexture;
						tmpt.West = 263 + textureIndex;// LevelInfo[x][y].wallTexture;
						tmpt.South = 263 + textureIndex;//LevelInfo[x][y].wallTexture;
						tmpt.North = 263 + textureIndex;//LevelInfo[x][y].wallTexture;
						tmpt.floorHeight = LevelInfo[x][y].ceilingHeight;//this is deliberate
						tmpt.ceilingHeight = LevelInfo[x][y].ceilingHeight;
						tmpt.tileX = LevelInfo[x][y].tileX;
						tmpt.tileY = LevelInfo[x][y].tileY;

						int objType = objectMasters[objList[nextObj].item_id].type;
						CalcObjectXYZ(game, &offX, &offY, &offZ, LevelInfo, objList, nextObj, x, y);	//Gets its position.
						//Draw it around this point
							//Bottom 2 bits give the index of the pillar texture
						x1 = offX + 5;
						y1 = offY+5;
						z1 = BrushSizeZ * (CEILING_HEIGHT + 1); //(offZ*BrushZ + doorHeight);
						x0 = offX - 5;
						y0 = offY - 5;
						z0 = -2 * BrushSizeZ;
						FbxVector4 lControlPointl0(x0, y0, z1);
						FbxVector4 lControlPointl1(x1, y0, z1);
						FbxVector4 lControlPointl2(x1, y1, z1);
						FbxVector4 lControlPointl3(x0, y1, z1);
						FbxVector4 lControlPointl4(x0, y0, z0);
						FbxVector4 lControlPointl5(x1, y0, z0);
						FbxVector4 lControlPointl6(x1, y1, z0);
						FbxVector4 lControlPointl7(x0, y1, z0);
						RenderFBXCuboid(gScene, x, y, tmpt, 0, -2, CEILING_HEIGHT + 1, "Pillar",
							lControlPointl0, lControlPointl1, lControlPointl2, lControlPointl3,
							lControlPointl4, lControlPointl5, lControlPointl6, lControlPointl7,
							0, 1,
							0, 1,
							0, 1,
							0, 1);



						}
					nextObj = objList[nextObj].next;
					}
				}
			}
		}
	}


void RenderTerrainChangeTiles(FbxScene*& gScene, int game, tile LevelInfo[64][64], ObjectItem objList[1600])
	{

	for (int k = 0; k < 1024; k++)
		{
		if (objectMasters[objList[k].item_id].type == A_CHANGE_TERRAIN_TRAP)
			{

			for (int i = 0; i <= objList[k].x; i++)
				{
				for (int j = 0; j <= objList[k].y; j++)
					{
					//Then render a func static for how it ends up.

					tile t;	//temporary tile for rendering.
					t.tileX = objList[k].tileX+64+i;
					t.tileY = objList[k].tileY+j;
					t.tileType = objList[k].quality & 0x01;
					t.Render = 1;
					t.floorHeight = ((objList[k].zpos >> 3) >> 2) * 8;	//heights in uw are shifted
					t.floorHeight = (objList[k].zpos >> 2);	//heights in uw are shifted
					t.ceilingHeight = 0;
					if (game != UW2)
						{//Texture is supposed to be an index into the texture list!
						t.floorTexture = objList[k].texture ;  //(objList[k].quality >> 1) + 210;
						}
					else
						{
						t.floorTexture = LevelInfo[objList[k].tileX][objList[k].tileY].floorTexture;//?
						}
					t.shockCeilingTexture = LevelInfo[objList[k].tileX + i][objList[k].tileY + j].shockCeilingTexture;
					t.wallTexture = LevelInfo[objList[k].tileX + i][objList[k].tileY + j].wallTexture;
					t.West = LevelInfo[objList[k].tileX + i][objList[k].tileY + j].West;
					t.East = LevelInfo[objList[k].tileX + i][objList[k].tileY + j].East;
					t.North = LevelInfo[objList[k].tileX + i][objList[k].tileY + j].North;
					t.South = LevelInfo[objList[k].tileX + i][objList[k].tileY + j].South;
					t.isWater = 0;
					t.DimY = 1;
					t.DimX = 1;
					t.hasElevator = 0;
					t.BullFrog = 0;
					//RenderFBXTile(gScene,game,64+t.tileX,60+t.tileY,t,0,0,0,1);

					char TileName[80] = "";
					sprintf_s(TileName, 80, "%s_%02d_%02d\0", UniqueObjectName(objList[k]), i, j);

					if (t.tileType == TILE_SOLID)
						{
						RenderFBXCuboid(gScene, objList[k].tileX + i, objList[k].tileY + j, t, t.isWater, -2, CEILING_HEIGHT + 1, TileName);
						}
					else
						{
						RenderFBXCuboid(gScene, objList[k].tileX + i, objList[k].tileY + j, t, t.isWater, -2, t.floorHeight, TileName);
						}
					}
				}
			}
		}
	}


void RenderFBXBridges(FbxScene*& gScene, int game, tile LevelInfo[64][64], ObjectItem objList[1600])
	{
	//Renders bridges as a brush. I can't use an object here since it needs to extend to variable heights etc.
	int x; int y;
	float offX; float offY; float offZ;
	float x0; float y0; float z0;
	float x1; float y1; float z1;
	if (game != SHOCK)
		{
		for (y = 0; y <= 63; y++)
			{
			for (x = 0; x <= 63; x++)
				{
				if ((LevelInfo[x][y].indexObjectList != 0))
					{
					long nextObj = LevelInfo[x][y].indexObjectList;
					while (nextObj != 0)
						{
						if (objectMasters[objList[nextObj].item_id].type == BRIDGE)
							{
							int textureIndex = objList[nextObj].flags & 0x3F;
							tile tmpt;
							tmpt.tileType = TILE_OPEN;//t.tileType;
							tmpt.DimX = 1;
							tmpt.DimY = 1;
							tmpt.wallTexture = 267 + textureIndex;
							tmpt.floorTexture = 267 + textureIndex;
							tmpt.shockCeilingTexture = 267 + textureIndex;
							tmpt.East = 267 + textureIndex;// LevelInfo[x][y].wallTexture;
							tmpt.West = 267 + textureIndex;// LevelInfo[x][y].wallTexture;
							tmpt.South = 267 + textureIndex;//LevelInfo[x][y].wallTexture;
							tmpt.North = 267 + textureIndex;//LevelInfo[x][y].wallTexture;
							tmpt.floorHeight = LevelInfo[x][y].ceilingHeight;//this is deliberate
							tmpt.ceilingHeight = LevelInfo[x][y].ceilingHeight;
							tmpt.tileX = LevelInfo[x][y].tileX;
							tmpt.tileY = LevelInfo[x][y].tileY;
						
							int objType = objectMasters[objList[nextObj].item_id].type;
							CalcObjectXYZ(game, &offX, &offY, &offZ, LevelInfo, objList, nextObj, x, y);	//Gets its position.
							//Move it's xy to the center of the tile
							offX = x*BrushSizeX + BrushSizeX / 2;
							offY = y*BrushSizeY + BrushSizeY / 2;
							//Draw it around this point
							//Bottom 2 bits give the index of the pillar texture
							x1 = offX + BrushSizeX / 2;
							y1 = offY + BrushSizeY / 2;
							z1 = offZ + 7.5;
							x0 = offX - BrushSizeX / 2;
							y0 = offY - BrushSizeY / 2;
							z0 = offZ - 7.5;
							FbxVector4 lControlPointl0(x0, y0, z1);
							FbxVector4 lControlPointl1(x1, y0, z1);
							FbxVector4 lControlPointl2(x1, y1, z1);
							FbxVector4 lControlPointl3(x0, y1, z1);
							FbxVector4 lControlPointl4(x0, y0, z0);
							FbxVector4 lControlPointl5(x1, y0, z0);
							FbxVector4 lControlPointl6(x1, y1, z0);
							FbxVector4 lControlPointl7(x0, y1, z0);
							char BridgeName[20];
							sprintf_s(BridgeName, "BRIDGE_%02d_%02d", x, y);
							RenderFBXCuboid(gScene, x, y, tmpt, 0, z0, z1, BridgeName,
								lControlPointl0, lControlPointl1, lControlPointl2, lControlPointl3,
								lControlPointl4, lControlPointl5, lControlPointl6, lControlPointl7,
								0, 1,
								0, 1,
								0, 1,
								0, 1);
							}
						nextObj = objList[nextObj].next;
						}
					}
				}
			}
		}
	else
		{//System Shock style bridge.
		return;
		for (y = 0; y <= 63; y++)
			{
			for (x = 0; x <= 63; x++)
				{
				if ((LevelInfo[x][y].indexObjectList != 0))
					{
					long nextObj = LevelInfo[x][y].indexObjectList;
					while (nextObj != 0)
						{
						if (objectMasters[objList[nextObj].item_id].type == SHOCK_BRIDGE)
							{
							tile tmpt;
							tmpt.tileType = TILE_OPEN;//t.tileType;
							tmpt.DimX = 1;
							tmpt.DimY = 1;
							if (objList[nextObj].shockProperties[BRIDGE_SIDE_TEXTURE_SOURCE] == 1)//Texture is in main texture map.
								{
								tmpt.wallTexture = objList[nextObj].shockProperties[BRIDGE_SIDE_TEXTURE];
								}
							else
								{//Add 325 for citimat.res textures.
								tmpt.wallTexture = 325+objList[nextObj].shockProperties[BRIDGE_SIDE_TEXTURE];
								}
							tmpt.East = tmpt.wallTexture;
							tmpt.West = tmpt.wallTexture;
							tmpt.South = tmpt.wallTexture;
							tmpt.North = tmpt.wallTexture;

							if (objList[nextObj].shockProperties[BRIDGE_TOP_BOTTOM_TEXTURE_SOURCE] == 1)//Texture is in main texture map.
								{
								tmpt.floorTexture = objList[nextObj].shockProperties[BRIDGE_TOP_BOTTOM_TEXTURE];
								tmpt.shockCeilingTexture = objList[nextObj].shockProperties[BRIDGE_TOP_BOTTOM_TEXTURE];
								}
							else
								{//Add 325 for citimat.res textures.
								tmpt.floorTexture = 325 + objList[nextObj].shockProperties[BRIDGE_TOP_BOTTOM_TEXTURE];
								tmpt.shockCeilingTexture = 325 + objList[nextObj].shockProperties[BRIDGE_TOP_BOTTOM_TEXTURE];
								}
														

							tmpt.floorHeight = LevelInfo[x][y].ceilingHeight;//this is deliberate
							tmpt.ceilingHeight = LevelInfo[x][y].ceilingHeight;
							tmpt.shockNorthCeilHeight = LevelInfo[x][y].ceilingHeight;
							tmpt.shockSouthCeilHeight = LevelInfo[x][y].ceilingHeight;
							tmpt.shockEastCeilHeight = LevelInfo[x][y].ceilingHeight;
							tmpt.shockWestCeilHeight = LevelInfo[x][y].ceilingHeight;
							tmpt.tileX = LevelInfo[x][y].tileX;
							tmpt.tileY = LevelInfo[x][y].tileY;

							int objType = objectMasters[objList[nextObj].item_id].type;
							CalcObjectXYZ(game, &offX, &offY, &offZ, LevelInfo, objList, nextObj, x, y);	//Gets its position.
							//Move it's xy to the center of the tile
							//offX = x*BrushSizeX + BrushSizeX / 2;
							//offY = y*BrushSizeY + BrushSizeY / 2;
							//Draw it around this point
							x1 = offX + BrushSizeX / 2;
							y1 = offY + BrushSizeY / 2;
							z1 = offZ + 0.1;
							x0 = offX - BrushSizeX / 2;
							y0 = offY - BrushSizeY / 2;
							z0 = offZ - 0.1;
							FbxVector4 lControlPointl0(x0, y0, z1);
							FbxVector4 lControlPointl1(x1, y0, z1);
							FbxVector4 lControlPointl2(x1, y1, z1);
							FbxVector4 lControlPointl3(x0, y1, z1);
							FbxVector4 lControlPointl4(x0, y0, z0);
							FbxVector4 lControlPointl5(x1, y0, z0);
							FbxVector4 lControlPointl6(x1, y1, z0);
							FbxVector4 lControlPointl7(x0, y1, z0);
							RenderFBXCuboid(gScene, x, y, tmpt, 0, z0, z1, "Bridge",
								lControlPointl0, lControlPointl1, lControlPointl2, lControlPointl3,
								lControlPointl4, lControlPointl5, lControlPointl6, lControlPointl7,
								0, 1,
								0, 1,
								0, 1,
								0, 1);
							}
						nextObj = objList[nextObj].next;
						}
					}
				}
			}
		}
	}

void CreateDoorModel(FbxScene*& gScene)
	{
	//int DOORWIDTH = 60;
	//int DOORHEIGHTUNITS = 6;
	float x0; float y0; float z0;
	float x1; float y1; float z1;
	x0 = 0;
	x1 = DOORWIDTH;
	y0= - DOORTHICKNESS;
	y1 = +DOORTHICKNESS;
	z0 = 0;
	z1 = DOORHEIGHTUNITS*BrushSizeZ;

	FbxVector4 lControlPointl0(x0, y0, z1);
	FbxVector4 lControlPointl1(x1, y0, z1);
	FbxVector4 lControlPointl2(x1, y1, z1);
	FbxVector4 lControlPointl3(x0, y1, z1);
	FbxVector4 lControlPointl4(x0, y0, z0);
	FbxVector4 lControlPointl5(x1, y0, z0);
	FbxVector4 lControlPointl6(x1, y1, z0);
	FbxVector4 lControlPointl7(x0, y1, z0);

	tile tmpt;
	tmpt.tileType = TILE_OPEN;//t.tileType;
	tmpt.DimX = 1;
	tmpt.DimY = 1;
	tmpt.wallTexture = 269; 
	tmpt.floorTexture = 269;
	tmpt.shockCeilingTexture = 269;
	tmpt.East = 269;// LevelInfo[x][y].wallTexture;
	tmpt.West = 269;// LevelInfo[x][y].wallTexture;
	tmpt.South = 269;//LevelInfo[x][y].wallTexture;
	tmpt.North = 269;//LevelInfo[x][y].wallTexture;
	tmpt.floorHeight = 0;
	tmpt.ceilingHeight =16;
	tmpt.tileX = 0;
	tmpt.tileY = 0;


	RenderFBXCuboid(gScene, 0, 0, tmpt, 0, z0, z1, "Door",
		lControlPointl0, lControlPointl1, lControlPointl2, lControlPointl3,
		lControlPointl4, lControlPointl5, lControlPointl6, lControlPointl7,
		0, 54.0/64.0);
	}

void CreateShockBridgeModel(FbxScene*& gScene)
	{
	//int DOORWIDTH = 60;
	//int DOORHEIGHTUNITS = 6;
	float x0; float y0; float z0;
	float x1; float y1; float z1;
	x0 = - BrushSizeX / 2;
	x1 = + BrushSizeX / 2;
	y0 = - BrushSizeY / 2;
	y1 = + BrushSizeY / 2;
	z0 = -1;
	z1 = +1;

	FbxVector4 lControlPointl0(x0, y0, z1);
	FbxVector4 lControlPointl1(x1, y0, z1);
	FbxVector4 lControlPointl2(x1, y1, z1);
	FbxVector4 lControlPointl3(x0, y1, z1);
	FbxVector4 lControlPointl4(x0, y0, z0);
	FbxVector4 lControlPointl5(x1, y0, z0);
	FbxVector4 lControlPointl6(x1, y1, z0);
	FbxVector4 lControlPointl7(x0, y1, z0);

	tile tmpt;
	tmpt.tileType = TILE_OPEN;//t.tileType;
	tmpt.DimX = 1;
	tmpt.DimY = 1;
	tmpt.wallTexture = 325;
	tmpt.floorTexture = 325;
	tmpt.shockCeilingTexture = 325;
	tmpt.East = 326;// LevelInfo[x][y].wallTexture;
	tmpt.West = 326;// LevelInfo[x][y].wallTexture;
	tmpt.South = 326;//LevelInfo[x][y].wallTexture;
	tmpt.North = 326;//LevelInfo[x][y].wallTexture;
	tmpt.floorHeight = 0;
	tmpt.ceilingHeight = 16;
	tmpt.shockNorthCeilHeight = tmpt.ceilingHeight;
	tmpt.shockSouthCeilHeight = tmpt.ceilingHeight;
	tmpt.shockEastCeilHeight = tmpt.ceilingHeight;
	tmpt.shockWestCeilHeight = tmpt.ceilingHeight;
	tmpt.tileX = 0;
	tmpt.tileY = 0;


	RenderFBXCuboid(gScene, 0, 0, tmpt, 0, z0, z1, "Bridge",
		lControlPointl0, lControlPointl1, lControlPointl2, lControlPointl3,
		lControlPointl4, lControlPointl5, lControlPointl6, lControlPointl7,
		0, 54.0 / 64.0);
	}