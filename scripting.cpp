#include <stdio.h>
#include <stdlib.h>
#include <fstream>
#include <math.h>
#include <string.h>
#include "gameobjects.h"
#include "gamestrings.h"
#include "tilemap.h"
#include "main.h"
#include "scripting.h"

FILE *fGLOBALS;	
FILE *fMAIN;
FILE *fBODY;

int lookupString(int BlockNo, int StringNo, char StringOut[255] );
void scriptShockButtons(tile LevelInfo[64][64], ObjectItem objList[1600], ObjectItem currObj);
void scriptShockTriggerAction(tile LevelInfo[64][64], ObjectItem objList[1600], ObjectItem currObj);
void shockScriptActivate(ObjectItem objList[1600], ObjectItem targetObj);
void MovingPlatformSCRIPT(int triggerX, int triggerY, int targetFloor, int targetCeiling, tile LevelInfo[64][64]);
void toggleSCRIPT(ObjectItem objList[1600], ObjectItem currObj);
void scriptShockButtonsActions(tile LevelInfo[64][64], ObjectItem objList[1600], ObjectItem currObj);

extern long SHOCK_CEILING_HEIGHT;
extern long UW_CEILING_HEIGHT;

short globals[255];

void EMAILScript(char objName[80], ObjectItem currObj, int logChunk)
{
	//printf("void start_%s()\n{",UniqueObjectName(currObj));
	fprintf(fBODY,"\n\t$data_reader_trigger.setKey(\"snd_say\",\"shock_audio_log_%04d\");",logChunk);
	fprintf(fBODY,"\n\t$data_reader_trigger.activate($player1);\n");
	//printf("\n}\n\n");
}


void a_change_terrain_trapSCRIPT(ObjectItem currObj, int targetX, int targetY, int dimX, int dimY)
{
int i;
int j;
int k;
k = 0;

for (i=0;i<dimX;i++)
	{
	for (j=0;j<dimY;j++)
		{
		fprintf(fBODY,"\t$initial_%s_%03d.remove();\n"
			,UniqueObjectName(currObj));
		k++;
		}
	}

	fprintf(fBODY,"\t$final%s.show();\n"    
		,UniqueObjectName(currObj));
}

void a_delete_object_trapSCRIPT(ObjectItem objList[1600], int objectToDelete)
{
    fprintf(fBODY,"\t$%s_%03d_%03d_%03d.hide();"
		,objectMasters[objList[objectToDelete].item_id].desc,objList[objectToDelete].tileX ,objList[objectToDelete].tileY ,objList[objectToDelete].index );

}

void a_text_string_trapSCRIPT(int stringId, int targetLevelNo)
{
char pStr[255];

if (lookupString(9, 64 * (targetLevelNo) + stringId ,pStr))
	{
	fprintf(fBODY,"\tsys.println(\"%s\");\n",pStr );
	}
else
	{
	fprintf(fBODY,"\tsys.println(\"Text trap String not found %3\n\");\n", stringId );
	}
}

void enchantmentSCRIPT(int stringId)
{
char pStr[255];
if (lookupString(9, 6 ,pStr))
	{
	fprintf(fBODY,"\tsys.println(\"Enchantment:%s\");",pStr );
	}
else
	{
	fprintf(fBODY,"\tsys.println(\"Enchantment String not found %3\");", stringId );
	}
}

void a_teleport_trapSCRIPT(ObjectItem currObj, int x, int y, int TargetLevelNo, int triggerX, int triggerY)
{
if (TargetLevelNo !=0 )	//Move to another level
	{
	    fprintf(fBODY,"\tsys.setcvar(\"targetX\",\"%d\");\n",x);
        fprintf(fBODY,"\tsys.setcvar(\"targetY\",\"%d\");\n",y);
        fprintf(fBODY,"\tsys.trigger($trigger_endlevel_%03d_%03d);\n",triggerX,triggerY);
	}
else
	{
	fprintf(fBODY,"\t$%s.activate($player1);\n"
		,UniqueObjectName(currObj));
	}
}


void a_do_trap_cameraSCRIPT(char objDesc[80], int triggerX, int triggerY, int objId)
{
//chainArray(objDescription) & "_" & Format(TriggerTargetX, "00#") & "_" & Format(TriggerTargetY, "00#")

     fprintf(fBODY,"\tsys.wait(1);\n");
     fprintf(fBODY,"\t$%s_%03d_%03d.activate($player1);\n",objDesc,triggerX,triggerY);
	 fprintf(fBODY,"\tsys.wait(10);\n");
     fprintf(fBODY,"\t$%s_%03d_%03d.activate($player1);\n",objDesc,triggerX,triggerY);
}

void a_do_trap_platformSCRIPT(char objDesc[80], int triggerX, int triggerY, int objId,int state,int up, int down)
{
    fprintf(fBODY,"\tif ( %s_%03d_%03d_state ==8)\n\t\t{\n",objDesc,triggerX,triggerY);
    fprintf(fBODY,"\t\t$floor_%03d_%03d.move( DOWN, %d );\n", objDesc,triggerX,triggerY,down);
    fprintf(fBODY,"\t\t%s_floor_%03d_%03d_state = 0;\n}\n", triggerX,triggerY);
    fprintf(fBODY,"\telse\n\t\t{\n");
    fprintf(fBODY,"\t\t$floor_%03d_%03d.move ( UP, %d );\n" ,triggerX,triggerY,up);
    fprintf(fBODY,"\t\t%s_floor_%03d_%03d_state++ ;\n\t}\n",objDesc,triggerX,triggerY);
}

void a_lock(int doorX, int doorY, int targetState)
{
switch (targetState)
	{
	case 1:	//Try open
	    fprintf(fBODY,"\t$a_door_%03d_%03d.Open();\n",doorX,doorY);
		break;
	case 2:	//Try close
        fprintf(fBODY,"\t$a_door_%03d_%03d.Close();\n",doorX,doorY);
        fprintf(fBODY,"\tsys.wait(5);\n");
        fprintf(fBODY,"\t$a_door_%03d_%03d.Lock();",doorX,doorY);	
		break;
	default:	//toggle
		fprintf(fBODY,"\t$a_lock_%03d_%03d.activate($player1);\n",doorX,doorY);
		break;
	}
}

void entranceteleporters()
{
//todo
}

void tobedone(char desc[80])
	{
	fprintf(fBODY,"\tsys.println(\"TODO:%s\");\n",desc);
	}


void a_set_variable_trapSCRIPT(int variable, int value, int operation)
{
   //       heading  operation    bit-field operation
   //       0        add          set bit
   //       1        sub          clear bit
   //       2        set          set bit
   //       3        and          set bit
   //       4        or           set bit
   //       5        xor          flip bit
   //       6        shl          set bit
	if (variable != 0) 
		{
		switch(operation)
			{
			case 0 : //add
				fprintf(fBODY,"\tvar_%d += %d ;\n",variable,value);
				break;
			case 1:  //sub
				fprintf(fBODY,"\tvar_%d -= %d ;\n",variable,value);
				break;
			case 2 : //set
				fprintf(fBODY,"\tvar_%d  = %d ;\n",variable,value);
				break;
			case 3 : //and
				fprintf(fBODY,"\tvar_%d &= %d ;\n",variable,value); //Does this work??
				break;
			case 4:  //or
				fprintf(fBODY,"\tvar_%d  |=  %d ;\n",variable,value);
				break;
			case 5 : //xor ! ((a&b) & (a|b))
				fprintf(fBODY,"\tvar_%d = (~( var_%d & %d) ) & ( var_%d | %d) ;\n",variable,variable,value,variable,value);
				break;
			case 6:  //shiftleft double by value times
				fprintf(fBODY,"\tvar_%d = (var_%d * %d ) & 63 ;\n",variable,variable,2*value);
				break;
           }
    }
   else
   {
	//bitwise	'todo
	//    switch operation
	//        Case 0  'set
	//        Case 1  'clear
	//        Case 2  'set
	//        Case 3  'set
	//        Case 4  'set
	//        Case 5  'flip
	//        Case 6  'set

	//pOut = pOut & vbNewLine & "sys.println(var_" & variable & ");" & vbNewLine
	}
}
void a_check_variable_trapSCRIPT(int variable, int value)
{
//Will need to expand on this for more complex checks

 fprintf(fBODY,"\tif (var_%d == %d) \n{\n",variable,value);
}

void addConditionals(int noofCond)
{
int i = 1;
for(i=1;i<=noofCond;i++)
	{
    fprintf(fBODY,"\n}");
    }
}





//0       1        2                       3       4      5   6   7     8       9      10       11     12
//Index   Type    Description             TileX   TileY   x   y   z   heading qual    owner   link    flags
void buildScriptsUW(int game,tile LevelInfo[64][64],ObjectItem objList[1600],int LevelNo)
{
int conditionalCount =0;
int TriggerTargetX=-1;
int TriggerTargetY=-1;
int TriggerQuality=-1;
int TriggerFlags=-1;
int TriggerHomeX=-1;
int TriggerHomeY=-1;

if (fopen_s(&fBODY,SCRIPT_BODY_FILE, "w")!=0)
	{
	printf("Unable to create output file for body");
	return;
	}
if (fopen_s(&fGLOBALS, SCRIPT_GlOBAL_FILE, "w")!=0)
	{
	printf("Unable to create output file for globals");
	return;
	}
if (fopen_s(&fMAIN, SCRIPT_MAIN_FILE, "w")!=0)
	{
	printf("Unable to create output file for main");
	return;
	}	
	
fprintf(fMAIN,"\nvoid main()\n{\n");
	for (int y=63; y>=0;y--)
		{
		for (int x=0; x<64;x++)
			{
			if(LevelInfo[x][y].indexObjectList !=0)	//there is an object in this tile
				{

				long nextObj = LevelInfo[x][y].indexObjectList;
				while (nextObj !=0)
					{
					if ((isTrigger(objList[nextObj]) || (isButton(objList[nextObj])) || (isTrigger(objList[objList[nextObj].link]))))
						{
						//printObject(objList[nextObj],1);	//Prints the first object the inital trigger.
						fprintf(fBODY,"\n\nvoid start_%s()\n{\n",
								UniqueObjectName(objList[nextObj]));
						conditionalCount = 0;
						TriggerTargetX=objList[nextObj].quality ;
						TriggerTargetY=objList[nextObj].owner ;
						TriggerQuality=objList[nextObj].quality ;
						TriggerFlags=objList[nextObj].flags ;
						TriggerHomeX=objList[nextObj].tileX ;
						TriggerHomeY=objList[nextObj].tileY ;					
						
						long nextInChain = objList[nextObj].link;	//for uw.
						while (nextInChain !=0)
							{
							if (isTrigger(objList[nextInChain]) || (isButton(objList[nextInChain])) || (isTrap(objList[nextInChain])) || (isLock(objList[nextInChain])))
								{
								switch (objectMasters[objList[nextInChain].item_id].type)
									{
									case A_DELETE_OBJECT_TRAP:	//Need to stop on this due to infinite loops if the trigger object is being deleted.
									case LOCK://A lock uses it's link to set the key needed. stop here.
										{
										//printObject(objList[nextInChain],1);fprintf(fBODY,"\n");
										//scriptChainFunctions(objList[nextInChain]);
										scriptChainFunctionsUW(objList,objList[nextInChain],&conditionalCount,&TriggerTargetX,&TriggerTargetY,&TriggerQuality,&TriggerFlags,&TriggerHomeX,&TriggerHomeY,LevelNo);
										nextInChain=0;
										break;
										}
									default:
										{
										//printObject(objList[nextInChain],1); fprintf(fBODY,"\n");
										scriptChainFunctionsUW(objList,objList[nextInChain],&conditionalCount,&TriggerTargetX,&TriggerTargetY,&TriggerQuality,&TriggerFlags,&TriggerHomeX,&TriggerHomeY,LevelNo);
										nextInChain = objList[nextInChain].link;
										break;
										}
									}
								}
							else
								{
								//if (nextInChain !=0)
								//{
									//fprintf(fBODY,"break on no trigger,trap or button\n");
									//printObject(objList[nextInChain],1);	fprintf(fBODY,"\n");								
									nextInChain=0;
								//	}
								}
							}
						//Now end the function call here
						addConditionals(conditionalCount+1);	//+1 to close it out.
						}
					nextObj=nextObject(objList[nextObj]);						
					}
				}
			}
		}
	fclose(fBODY);
	fprintf(fMAIN,"\n}\n");	
	fclose(fMAIN);
	fclose(fGLOBALS);
	
	//now merge these three together
	FILE *fFINALSCRIPT;
	char line[255];
	if (fopen_s(&fFINALSCRIPT,SCRIPT_FINAL_FILE, "w")==0)
		{
		fprintf(fFINALSCRIPT,"#ifndef __game%d_%d_script__\n#__game%d_%d_script__\n",game,LevelNo,game,LevelNo);
		
	
		if (fopen_s(&fBODY, SCRIPT_GlOBAL_FILE, "r")!=0)
			{
			printf("Unable to read output file for globals");
			}
		else
			{
			while (fgets(line,255,fBODY))
				{
				fprintf(fFINALSCRIPT,"%s",line);
				}
				fclose(fBODY);	
			}
		if (fopen_s(&fBODY, SCRIPT_MAIN_FILE, "r")!=0)
			{
			printf("Unable to read output file for main");
			}
		else
			{
			while (fgets(line,255,fBODY))
				{
				fprintf(fFINALSCRIPT,"%s",line);
				}
				fclose(fBODY);
			}		
			
		if (fopen_s(&fBODY,SCRIPT_BODY_FILE, "r")!=0)
			{
			printf("Unable to read output file for body");
			}
		else
			{
			while (fgets(line,255,fBODY))
				{
				fprintf(fFINALSCRIPT,"%s",line);
				}
				fclose(fBODY);
			}					
				
		fprintf(fFINALSCRIPT,"#endif //__game%d_%d_script__",game,LevelNo);
		fclose(fFINALSCRIPT);
		}		
	else
		{
		printf("Unable to open output file");
		}
	
}




void scriptChainFunctionsUW(ObjectItem objList[1600], ObjectItem currObj,int *conditionalCount, int *TriggerTargetX,int *TriggerTargetY,int *TriggerQuality,int *TriggerFlags,int *TriggerHomeX,int *TriggerHomeY,int scriptLevelNo)
	{
	//picks which script to generate.
    switch (objectMasters[currObj.item_id].type)
		{
    case A_DAMAGE_TRAP:
        tobedone("A_DAMAGE_TRAP");
        break;
    case A_TELEPORT_TRAP:
        a_teleport_trapSCRIPT(currObj, currObj.tileX , currObj.tileY, currObj.zpos, *TriggerHomeX, *TriggerHomeY);
        break;
    case A_ARROW_TRAP:
        tobedone("A_ARROW_TRAP");
        break;
    case A_DO_TRAP:
		switch(currObj.quality)
			{
			case 2:	//Camera
				{
				a_do_trap_cameraSCRIPT(objectMasters[currObj.item_id].desc,*TriggerTargetX,*TriggerTargetY, currObj.index );
				break;
				}
			case 3:
				{
				fprintf(fGLOBALS,"\nfloat %s_%03d_%03d_state = %d; \n",objectMasters[currObj.item_id].desc, *TriggerTargetX, *TriggerTargetY,*TriggerFlags);
				a_do_trap_platformSCRIPT(objectMasters[currObj.item_id].desc, *TriggerTargetX, *TriggerTargetY,currObj.index,*TriggerFlags,BrushSizeZ,8*BrushSizeZ);
				break;
				}
			}
        break;
    case A_PIT_TRAP:
        tobedone("A_PIT_TRAP");
        break;
    case A_CHANGE_TERRAIN_TRAP:
        a_change_terrain_trapSCRIPT(currObj,*TriggerTargetX,*TriggerTargetY,currObj.x,currObj.y);
		//fprintf(fMAIN, "$final_%s.hide();\n",objectMasters[currObj.item_id].desc, *TriggerTargetX, *TriggerTargetY,currObj.index );
		fprintf(fMAIN, "$final_%s.hide();\n",UniqueObjectName(currObj));
        break;
    case A_SPELLTRAP:
        tobedone("A_SPELLTRAP");
        break;
    case A_CREATE_OBJECT_TRAP:
        tobedone("A_CREATE_OBJECT_TRAP");
        break;
    case A_DOOR_TRAP:
        *TriggerQuality = currObj.quality;
        a_lock(*TriggerTargetX, *TriggerTargetY, *TriggerQuality);
        break;
//    case A_LOCK:
        //skip this not needed implemented above
 //       break;
    case A_WARD_TRAP:
        tobedone("A_WARD_TRAP");
        break;
    case A_TELL_TRAP:
        tobedone("A_TELL_TRAP");
        break;
    case A_DELETE_OBJECT_TRAP:
        a_delete_object_trapSCRIPT(objList , currObj.link);
        break;
    case AN_INVENTORY_TRAP:
        tobedone("AN_INVENTORY_TRAP");
        break;
    case A_SET_VARIABLE_TRAP:
        fprintf(fGLOBALS,"\nfloat $var_%d = 0; \n",currObj.zpos);
        a_set_variable_trapSCRIPT(currObj.zpos, (((currObj.owner & 0x7) <<3) | (currObj.y )), currObj.heading / 45);
        break;
    case A_CHECK_VARIABLE_TRAP:
        a_check_variable_trapSCRIPT(currObj.zpos, (((currObj.owner & 0x7) <<3) | (currObj.y )));
        conditionalCount++;
        break;
    case A_COMBINATION_TRAP:
        tobedone("A_COMBINATION_TRAP");
        break;
    case A_TEXT_STRING_TRAP:
        a_text_string_trapSCRIPT(currObj.owner,scriptLevelNo);
        break;        
    case A_MOVE_TRIGGER:
    case A_PICK_UP_TRIGGER: 
    case A_USE_TRIGGER: 
	case A_LOOK_TRIGGER:  
	case A_STEP_ON_TRIGGER: 
    case AN_UNLOCK_TRIGGER:	       
        *TriggerTargetX =currObj.quality ;
        *TriggerTargetY = currObj.owner;
        break;
//    case ENCHANTMENT:  //Cast a spell
//       enchantment(currObj.link);
//		break;        
		}
	}
	
void BuildScriptsShock(int game,tile LevelInfo[64][64],ObjectItem objList[1600],int LevelNo)
{
	
if (fopen_s(&fBODY,SCRIPT_BODY_FILE, "w")!=0)
	{
	printf("Unable to create output file for body");
	return;
	}
if (fopen_s(&fGLOBALS, SCRIPT_GlOBAL_FILE, "w")!=0)
	{
	printf("Unable to create output file for globals");
	return;
	}

if (fopen_s(&fMAIN, SCRIPT_MAIN_FILE, "w") != 0)
{
	printf("Unable to create output file for globals");
	return;
}
	//fprintf(fBODY,"#ifndef __game%d_%d_script__\n#define __game%d_%d_script__\n",game,LevelNo,game,LevelNo);

	for (int y=63; y>=0;y--)
		{
		for (int x=0; x<64;x++)
			{
			if(LevelInfo[x][y].indexObjectList !=0)	//there is an object in this tile
				{//traverse the list 
				int nextObj = LevelInfo[x][y].indexObjectList;
				while (nextObj!=0)
					{
					//is it something that starts a script
					//This does not include screens just yet.
					if ((isButtonSHOCK(objList[nextObj])) 
							|| (isLog(objList[nextObj])) 
								|| (isTriggerSHOCK(objList[nextObj]))
									|| (objectMasters[objList[nextObj].item_id].DeathWatch  >=1))
						{
						if (isTriggerSHOCK(objList[nextObj]) && (objList[nextObj].item_id != 378))
						{//Create global variables for testing conditions.
							if ((objList[nextObj].conditions[0] >0) && (objList[nextObj].conditions[0])<255)
							{
								if (globals[objList[nextObj].conditions[0]]!=1)	//A new global
								{//add the new global here.
									fprintf(fGLOBALS, "\tfloat global_var_%d = 0;\n", objList[nextObj].conditions[0]);
									globals[objList[nextObj].conditions[0]] = 1;
								}
							}
							//create a global for testing conditions

						}
						//Create the function call.
						fprintf(fBODY,"\n\n\nvoid start_%s()\n{\n",
								UniqueObjectName(objList[nextObj]));

						//Create the function body. Unlike UW where I parsed the chain here I associate each trigger with a script so all I do activate each trigger when I need them
						//Note that I will need to know the type of object I will be triggering for things like door locks which don't follow the naming convention.
						switch (objList[nextObj].ObjectClass)
							{
							case SOFTWARE_LOGS:
								if (isLog(objList[nextObj]))
									{//Creates the script that plays a log.
									EMAILScript(objectMasters[objList[nextObj].item_id].desc
										,objList[nextObj]
										,objList[nextObj].shockProperties[SOFT_PROPERTY_LOG]);
									}
								break;
								
							case SWITCHES_PANELS:
									//Control the appearance of the switch here
								fprintf(fBODY, "\n\t\tfloat buttonState = $%s.getGuiFloat(GUI_ENTITY1, \"buttonstate\");", UniqueObjectName(objList[nextObj]));
								fprintf(fBODY, "\n\t\tif (buttonState == 0)\n\t\t\t{$%s.setGuiFloat(GUI_ENTITY1, \"buttonstate\", 1);}", UniqueObjectName(objList[nextObj]));
								fprintf(fBODY, "\n\t\telse\n\t\t\t{$%s.setGuiFloat(GUI_ENTITY1, \"buttonstate\", 0);}\n", UniqueObjectName(objList[nextObj]));

								//There are many types of switch with different properties
									scriptShockButtons(LevelInfo,objList,objList[nextObj]);
								break;
								
							case TRAPS_MARKERS:
								scriptShockTriggerAction(LevelInfo,objList,objList[nextObj]);
								break;
							
							default:
								//Something else that can start a script. 
								if (objectMasters[objList[nextObj].item_id].DeathWatch >=1) //A deathwatch scriptcall.
									{
									fprintf(fBODY, "\tdeathwatch_%d%d%d++;\n",
										objList[nextObj].ObjectClass, objList[nextObj].ObjectSubClass, objList[nextObj].ObjectSubClassIndex);
									fprintf(fBODY, "\tdeathwatch_script(%d%d%d);\n",
										objList[nextObj].ObjectClass, objList[nextObj].ObjectSubClass, objList[nextObj].ObjectSubClassIndex);
									}
								break;
							}
							
						//end the function
						fprintf(fBODY,"}\n");
						}
						
				nextObj= objList[nextObj].next;						
					}
						
				}
			}
		}
	//Now add the scripts for the email actions
	for (int i = 0; i < 1600; i++)
	{
		if (objList[i].InUseFlag == 1)
		{
			if (isTriggerSHOCK(objList[i]))
			{
				if (objList[i].TriggerAction == ACTION_EMAIL)
				{
					fprintf(fBODY, "\n\n\nvoid start_%s_email()\n{\n",
						UniqueObjectName(objList[i]));
					EMAILScript(objectMasters[objList[i].item_id].desc
						, objList[i]
						, objList[i].shockProperties[TRIG_PROPERTY_EMAIL]);
					fprintf(fBODY, "\n}\n");
				}
			}
		}
	}
	//Add the death watch script
	fprintf(fGLOBALS, "\n\n\nvoid deathwatch_script(float objectId);\n");//the declaration
	fprintf(fBODY, "\n\n\nvoid deathwatch_script(float objectId)\n{\n");
	for (int i = 0; i < 1600; i++)
	{
		if ((objList[i].ObjectClass == 12) && (objList[i].ObjectSubClass == 0) && (objList[i].ObjectSubClassIndex == 4))
		{
			if (objList[i].conditions[3] == 0)
			{
				int k = getShockObjectIndex(objList[i].conditions[2], objList[i].conditions[1], objList[i].conditions[0]);
			fprintf(fBODY, "\tif ((objectId==%d%d%d) && (deathwatch_%d%d%d>=%d))\n\t{\n", 
					objList[i].conditions[2],
					objList[i].conditions[1],
					objList[i].conditions[0],
					objList[i].conditions[2],
					objList[i].conditions[1],
					objList[i].conditions[0],
					objectMasters[k].DeathWatch);
			fprintf(fBODY, "\t\t$runscript_%s.activate($player1);\n\t}\n", UniqueObjectName(objList[i]));
			}
		}
	}
	fprintf(fBODY, "\n}\n");
	//Add the deathwatch globals
	for (int i = 0; i <= 1024; i++)
		{
		if (objectMasters[i].DeathWatch >= 1)
			{//This class of objects is being watched
			fprintf(fGLOBALS, "\tfloat deathwatch_%d%d%d = 0;\n", objectMasters[i].objClass, objectMasters[i].objSubClass, objectMasters[i].objSubClassIndex);
			}
		}

	//The destructable screens
	for (int i = 0; i < 1600; i++)
	{
		if ((objList[i].item_id == 132) || (objList[i].item_id == 134) || (objList[i].item_id == 135))
		{
			fprintf(fGLOBALS, "\nvoid start_%s_destroy();\n",UniqueObjectName(objList[i]));//the declaration
			fprintf(fBODY, "\n\n\nvoid start_%s_destroy()\n{\n", UniqueObjectName(objList[i]));
			fprintf(fBODY, "\t$%s.setGuiFloat(GUI_ENTITY1, \"destroyed\", 1);\n}\n", UniqueObjectName(objList[i]));
		}
	}
	fclose(fBODY);
	//fprintf(fMAIN,"\n}\n");	
	//fclose(fMAIN);
	fclose(fGLOBALS);
	
	//now merge these three together
	FILE *fFINALSCRIPT;
	char line[255];
	if (fopen_s(&fFINALSCRIPT,SCRIPT_FINAL_FILE, "w")==0)
		{
		fprintf(fFINALSCRIPT,"#ifndef __game%d_%d_script__\n#define __game%d_%d_script__\n",game,LevelNo,game,LevelNo);
		
	
		if (fopen_s(&fBODY, SCRIPT_GlOBAL_FILE, "r")!=0)
			{
			printf("Unable to read output file for globals");
			}
		else
			{
			while (fgets(line,255,fBODY))
				{
				fprintf(fFINALSCRIPT,"%s",line);
				}
				fclose(fBODY);	
			}

		//Add the void main that starts our level entry triggers
		fprintf(fFINALSCRIPT, "\nvoid main()\n\t{\n");
		fprintf(fFINALSCRIPT, "\tsys.println(\"shock\");\n");
			

			for (int i = 0; i < 1600; i++)
			{
				if (objectMasters[objList[i].item_id].type  == SHOCK_TRIGGER_LEVEL)	//A level entry trigger
				{
					fprintf(fFINALSCRIPT, "\t$runscript_%s.activate($player1);\n", UniqueObjectName(objList[i]));
				}
			}
			fprintf(fFINALSCRIPT, "\n\t}");
		
			
		if (fopen_s(&fBODY,SCRIPT_BODY_FILE, "r")!=0)
			{
			printf("Unable to read output file for body");
			}
		else
			{
			while (fgets(line,255,fBODY))
				{
				fprintf(fFINALSCRIPT,"%s",line);
				}
				fclose(fBODY);
			}					
				
		fprintf(fFINALSCRIPT,"#endif //__game%d_%d_script__",game,LevelNo);
		fclose(fFINALSCRIPT);
		}		
	else
		{
		printf("Unable to open output file");
		}}



void scriptShockButtons(tile LevelInfo[64][64], ObjectItem objList[1600], ObjectItem currObj)
{

if (currObj.ObjectSubClass ==0)
	{//regular buttons and switches. Activates a target trigger.
	//if(currObj.shockProperties[BUTTON_PROPERTY_TRIGGER] > 0)
	//{
		//printf("\t$%s.activate();\n",UniqueObjectName(objList[currObj.shockProperties[BUTTON_PROPERTY_TRIGGER]]));
	//		}
	//	}
	//else
	//	{
	//	fprintf(fBODY,"\tsys.println(\"This button does nothing!\");\n");
	//	}
	scriptShockButtonsActions(LevelInfo, objList, currObj);
	return;
	}
if((currObj.ObjectSubClass==2) && (currObj.ObjectSubClassIndex==0))
	{//cyberspace terminal
	int cybLevelX = currObj.shockProperties[0];
	int cybLevelY = currObj.shockProperties[1];
	int cybLevelZ = currObj.shockProperties[2];
	int cybLevelNo = currObj.shockProperties[3]; 
	fprintf(fBODY,"\tsys.println(\"Teleporting to a cyberspace level:%d@(%d,%d,%d)\");\n",cybLevelNo,cybLevelX,cybLevelY,cybLevelZ);
	return;
	}

if((currObj.ObjectSubClass==2) && (currObj.ObjectSubClassIndex>=1))
	{//Fixup station/energy station
	int ChargeLevel = currObj.shockProperties[0] ;  //Amount of charge?/? always 255
	int SecurityLevel = currObj.shockProperties[1] ;	//Security level?? //reuse timer??
	fprintf(fBODY,"\tsys.println(\"Charging up: %d , Security level? %d\");\n",ChargeLevel,SecurityLevel);
	return;
	}
if((currObj.ObjectSubClass==3) && (currObj.ObjectSubClassIndex<=3))
	{	
	//puzzle panels. need to see them in the wild before I know what other stuff does. At the moment I just fire them off.
	//if bit 28 is set (0x10000000) it is a block puzzle, else it is a wire puzzle.
	fprintf(fBODY,"\tsys.println(\"Puzzle type was: %d\");\n",currObj.shockProperties[BUTTON_PROPERTY_PUZZLE]);
	//printf("\t$%s.activate();\n",UniqueObjectName(objList[currObj.shockProperties[BUTTON_PROPERTY_TRIGGER]])); 
	shockScriptActivate(objList,objList[currObj.shockProperties[BUTTON_PROPERTY_TRIGGER]]);
	return;
	}

if((currObj.ObjectSubClass==3) && ((currObj.ObjectSubClassIndex==4) || (currObj.ObjectSubClassIndex==5) || (currObj.ObjectSubClassIndex==6)))
	{//elevators

	//Elevators (9 3 5):
	//000C  int16 Map index of Panel of target Level1 (this means the panel no itself!)
	//000E  int16 Map index of Panel of target Level2
	//0012  int16 Map index of Panel of target Level3
	//0018  int16 Bitfield of accessible Levels (Actual)
	//001A  int16 Bitfield of accessible Levels (Shaft)
	//	    Levels with a 1 in the "shaft" field but not in the "Actual" field
	//	     give a "Shaft damage: Unable to go there" message.
		
	int Level1_panel =currObj.shockProperties[0];
	int Level2_panel =currObj.shockProperties[1];
	int Level3_panel =currObj.shockProperties[2];
	//currObj.shockProperties[3]//bitfields for access
	//currObj.shockProperties[4]
	
    //printf("\tsys.setcvar(\"targetPanel %d\");\n",y); //eventually set this with the selected value.
    fprintf(fBODY,"\tsys.println(\"Moving levels possible panels are: %d, %d, %d \");\n",Level1_panel,Level2_panel,Level3_panel);
    //printf("\tsys.trigger($trigger_endlevel_%03d_%03d);\n",triggerX,triggerY);//need to set the map name in script  in shock 
	
	return;
	}

if((currObj.ObjectSubClass==3) && ((currObj.ObjectSubClassIndex==7) || (currObj.ObjectSubClassIndex==8) ))
	{
	//Number Pads
	//000C	int16	Combination in BCD
	//000E  int16 Map Object to trigger
	//0018  int16 Map Object to Extra Trigger (?)
	int combo = currObj.shockProperties[BUTTON_PROPERTY_COMBO] ;	
	
	//objList[objIndex].shockProperties[3];	//extra trigger?
	fprintf(fBODY,"\tsys.println(\"You correcty guess the combination code %d\");\n",combo);
	shockScriptActivate(objList,objList[currObj.shockProperties[BUTTON_PROPERTY_TRIGGER]]);
	//printf("\t$%s.activate();\n",UniqueObjectName(objList[currObj.shockProperties[BUTTON_PROPERTY_TRIGGER]])); 
	return;
	}


	fprintf(fBODY,"\t//Unknown Script @ %s ;\n",UniqueObjectName(currObj)); 
//unknown object if all other tests fail. set the usual trigger value and keep an eye on this statement in debugging.
	fprintf(fBODY,"\tsys.println(\"Other/unknown Button type.\");\n");
	//printf("\t$%s.activate();\n",UniqueObjectName(objList[currObj.shockProperties[BUTTON_PROPERTY_TRIGGER]])); 
	//shockScriptActivate(objList,objList[currObj.shockProperties[BUTTON_PROPERTY_TRIGGER]]);
	scriptShockButtonsActions(LevelInfo, objList, currObj);
}


void addGlobalTest(ObjectItem objList[1600], ObjectItem currObj, short VarOnly)
{
	if (globals[currObj.conditions[0]] != 1)
	{//create it's global if we don't have it already.
		fprintf(fGLOBALS, "\tfloat global_var_%d = 0; //This global was created in addGlobalTest for %s!\n", currObj.conditions[0], UniqueObjectName(currObj));
		globals[currObj.conditions[0]] = 1;
	}
	//add the test
	if (VarOnly == 0)
	{
		fprintf(fBODY, "\tif (global_var_%d >= %d)\n\t{\n", currObj.conditions[0], currObj.conditions[2]);
	}	
}
void addGlobal(int varIndex)
{
	if (globals[varIndex] != 1)
	{//create it's global if we don't have it already.
		fprintf(fGLOBALS, "\tfloat global_var_%d = 0; //This global was created in addGlobal!\n", varIndex);
		globals[varIndex] = 1;
	}
}

void scriptShockTriggerAction(tile LevelInfo[64][64], ObjectItem objList[1600], ObjectItem currObj)
{
	if ((currObj.conditions[0] > 0) && (currObj.conditions[0] < 255) && (currObj.item_id !=378) && (currObj.TriggerAction != ACTION_MESSAGE))
		{//Add a global test
		addGlobalTest(objList, currObj,0);
		}
	if (currObj.TriggerOnce == 1)
	{
		if (currObj.TriggerOnceGlobal == 0)
			{//add it's global
				fprintf(fGLOBALS, "\tfloat %s_triggered = 0;\n", UniqueObjectName(currObj));
				currObj.TriggerOnceGlobal = 1;
			}
		fprintf(fBODY, "\tif (%s_triggered == 0)\n\t{\n", UniqueObjectName(currObj));
		fprintf(fBODY, "\t%s_triggered = 1;\n", UniqueObjectName(currObj));
	}
	fprintf(fBODY, "\tsys.println(\"%d\");\n",currObj.index);	//Default output so at least something happens.
switch (currObj.TriggerAction)
	{ 
	case ACTION_DO_NOTHING :
		{
		fprintf(fBODY,"\tsys.println(\"Do nothing. Or maybe a default action.\");\n");
		break;	
		}
	case ACTION_TRANSPORT_LEVEL:
		{
		//todo: set up my teleport destinations in advance!
		int teleportX = currObj.shockProperties[TRIG_PROPERTY_TARGET_X];	//Target X of teleport
		int teleportY = currObj.shockProperties[TRIG_PROPERTY_TARGET_Y]; //Target Y of teleport
		int teleportZ = currObj.shockProperties[TRIG_PROPERTY_TARGET_Z];	//Target Z of teleport
		fprintf(fBODY,"\tsys.println(\"Teleporting to %d %d %d \");\n",teleportX,teleportY,teleportZ);
		break;
		}
	case ACTION_RESURRECTION:
		{
		currObj.shockProperties[TRIG_PROPERTY_VALUE];//Target Health
		fprintf(fBODY,"\tsys.println(\"You live again. Or maybe get turned into a cyborg.\");\n");
		break;
		}
	case ACTION_CLONE:
		{
		//	000C	int16	Object to transport.
		//	000E	int16	Delete flag?
		//	0010	int16	Tile destination X
		//	0014	int16	Tile destination Y
		//	0018	int16	Destination height?		
		//printf("\tACTION_CLONE\n");
		//printf("\t\tObject to transport:%d\n",getValAtAddress(sub_ark,add_ptr+0xC,16));
		//printf("\t\tDeleteFlag?:%d\n",getValAtAddress(sub_ark,add_ptr+0xE,16));
		//printf("\t\tDestination tileX:%d\n",getValAtAddress(sub_ark,add_ptr+0x10,16));
		//printf("\t\tDestination tileY:%d\n",getValAtAddress(sub_ark,add_ptr+0x14,16));
		//printf("\t\tDestination height:%d\n",getValAtAddress(sub_ark,add_ptr+0x18,16));
		int objToMove = currObj.shockProperties[TRIG_PROPERTY_OBJECT];	//obj to transport
		//objList[objIndex].shockProperties[TRIG_PROPERTY_FLAG]//Delete flag
		int teleportX =currObj.shockProperties[TRIG_PROPERTY_TARGET_X] ;	//Target X
		int teleportY = currObj.shockProperties[TRIG_PROPERTY_TARGET_Y] ;	//Target Y
		int teleportZ =currObj.shockProperties[TRIG_PROPERTY_TARGET_Z] ;	//Target z
		fprintf(fBODY,"\tsys.println(\"Object cloned. %d (%d,%d,%d)\");\n",objToMove,teleportX,teleportY,teleportZ);
		break;
		}
	case ACTION_SET_VARIABLE:
		{
		//000C	int16	variable to set
		//0010	int16	value
		//0012	int16	?? action 00 set 01 add
		//0014	int16	Optional message to receive
		int varToSet = currObj.shockProperties[TRIG_PROPERTY_VARIABLE];
		int valToSet = currObj.shockProperties[TRIG_PROPERTY_VALUE];
		int Operation = currObj.shockProperties[TRIG_PROPERTY_OPERATION];
		int Message = currObj.shockProperties[TRIG_PROPERTY_MESSAGE1];
		fprintf(fBODY,"\tsys.println(\"Variable %d set. Value %d, %d operation. Message %d \");\n",varToSet,valToSet,Operation,Message);
		if ((currObj.item_id != 378) && ((varToSet >=0) && (varToSet <255)))
		{
			addGlobal(varToSet);
			switch (Operation)
			{
			case 0:		//set value
				fprintf(fBODY, "\tglobal_var_%d = %d;\n", varToSet, valToSet);
				break;
			case 1:		//Add value
				fprintf(fBODY, "\tglobal_var_%d += %d;\n", varToSet, valToSet);
				break;
			default:
				fprintf(fBODY, "\tsys.println(\"Unknown operation %d operation.\");\n", Operation);
			}
			if (Message >= 1)
			{	//play back a message here?
				fprintf(fBODY, "\n\t$data_reader_trigger.setKey(\"snd_say\",\"shock_audio_bark_%d\");", Message);
				fprintf(fBODY, "\n\t$data_reader_trigger.activate($player1);\n");
			}
		}
		break;
		}
	case ACTION_ACTIVATE:
		{
		//000C	int16	1st object to activate.
		//000E	int16	Delay before activating object 1.
		//0010	...	Up to 4 objects and delays stored here.		
		//printf("\tACTION_ACTIVATE\n");
		if ( currObj.shockProperties[0]> 0)
			{
			if (currObj.shockProperties[1] != 0){ fprintf(fBODY, "\tsys.wait(%d);\n", currObj.shockProperties[1] / 10); }
			shockScriptActivate(objList,objList[currObj.shockProperties[0]]);
			}
		if ( currObj.shockProperties[2]> 0)
			{
			if (currObj.shockProperties[3] != 0){ fprintf(fBODY, "\tsys.wait(%d);\n", currObj.shockProperties[3] / 10); }
			shockScriptActivate(objList,objList[currObj.shockProperties[2]]);
			}	
		if (( currObj.shockProperties[4]> 0) &&  (currObj.shockProperties[4]< 1600))
			{
			if (currObj.shockProperties[5] != 0){ fprintf(fBODY, "\tsys.wait(%d);\n", currObj.shockProperties[5] / 10); }
			shockScriptActivate(objList,objList[currObj.shockProperties[4]]);
			}	
		if ( currObj.shockProperties[6]> 0)
			{
			if (currObj.shockProperties[7] != 0){ fprintf(fBODY, "\tsys.wait(%d);\n", currObj.shockProperties[7] / 10); }
			shockScriptActivate(objList,objList[currObj.shockProperties[6]]); 
			//printf("\t$%s.activate();\n",UniqueObjectName(objList[currObj.shockProperties[6]])); 
			}

		break;
		}
	case ACTION_LIGHTING:
	{
	//000C	int16	Control point 1
	//000E	int16	Control point 2
	//	...	?
	//printf("\tACTION_LIGHTING\n");
	//printf("\t\tControl point 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
	//printf("\t\tControl point 2%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
	//printf("\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
	//printf("\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
	//printf("\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
	//printf("\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
	//printf("\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
	//printf("\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));
	//objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_1] 
	//objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_2] 
		//shade = (0.50) * (1 - ((float)LevelInfo[x][y].shockShadeUpper / 15));
		if (ENABLE_LIGHTING == 1)
		{
							
			int shadeUpper1 = currObj.shockProperties[TRIG_PROPERTY_UPPERSHADE_1]; //TRIG_PROPERTY_UPPERSHADE
			int shadeLower1 = currObj.shockProperties[TRIG_PROPERTY_LOWERSHADE_1];
			int shadeUpper2 = currObj.shockProperties[TRIG_PROPERTY_UPPERSHADE_2]; //TRIG_PROPERTY_UPPERSHADE
			int shadeLower2 = currObj.shockProperties[TRIG_PROPERTY_LOWERSHADE_2];

			int x1 = objList[currObj.shockProperties[TRIG_PROPERTY_CONTROL_1]].tileX;
			int y1 = objList[currObj.shockProperties[TRIG_PROPERTY_CONTROL_1]].tileY;
			int x2 = objList[currObj.shockProperties[TRIG_PROPERTY_CONTROL_2]].tileX; 
			int y2 = objList[currObj.shockProperties[TRIG_PROPERTY_CONTROL_2]].tileY;
			int xMin; int xMax;
			int yMin; int yMax;

			if (x1 >= x2)
				{ xMin = x2; xMax = x1; }
			else
				{ xMin = x1; xMax = x2; }
			if (y1 >= y2)
			{
				yMin = y2; yMax = y1;
			}
			else
			{
				yMin = y1; yMax = y2;
			}
			//fprintf(fBODY, "\tfloat dir = 1;\n");
			fprintf(fBODY, "\tfloat shade = 0;\n");
			fprintf(fBODY, "\tfloat shadeUpperAdj =0;");
			fprintf(fBODY, "\tfloat shadeLowerAdj =0;\n");
			fprintf(fBODY, "\tif (%s_light_state == 0)\n\t{\n", UniqueObjectName(currObj));
			fprintf(fBODY, "\tshadeUpperAdj =%d; shadeLowerAdj =%d;\n\t}\n\telse\n\t{\n", shadeUpper1, shadeLower1);
			fprintf(fBODY, "\tshadeUpperAdj =%d; shadeLowerAdj =%d;\n\t}\n", shadeUpper2, shadeLower2);

			//fprintf(fBODY, "\tif (%s_light_state == 0)\n\t{\n", UniqueObjectName(currObj));
			//fprintf(fBODY, "\t\tdir = -1 ;\n\t\t%s_light_state = 1;\n\t}\n\telse\n\t{\n", UniqueObjectName(currObj));
			//fprintf(fBODY, "\t\tdir = 1 ;\n\t\t%s_light_state = 0;\n\t}\n",  UniqueObjectName(currObj));

			for (int x = xMin; x <= xMax; x++)
			{
				for (int y = yMin; y <= yMax; y++)
				{
					if (LevelInfo[x][y].tileType != 0)
					{
						//if ((LevelInfo[x][y].shadeUpperGlobal == 0) && ((shadeUpper1 >= 1) || (shadeUpper2 >=1)))
						//{//add a global for this light
						//	//fprintf(fGLOBALS, "\n\tfloat light_%02d_%02d_upper_state = %d;\n",x,y, LevelInfo[x][y].shockShadeUpper);
						//	LevelInfo[x][y].shadeUpperGlobal = 1;
						//}
						//if ((LevelInfo[x][y].shadeLowerGlobal == 0) && ((shadeLower1 >= 1) || (shadeLower2 >= 1)))
						//	{//add a global for this light
						//	//fprintf(fGLOBALS, "\n\tfloat light_%02d_%02d_lower_state = %d;\n",x,y, LevelInfo[x][y].shockShadeLower);
						//	LevelInfo[x][y].shadeLowerGlobal = 1;
						//	}
					

					
						if ((shadeUpper1 >= 1) || (shadeUpper2 >= 1))
						{
							//fprintf(fBODY, "\tshade =  (0.50) * (1 - ((%d + (dir * %d)) / 15)) ;\n", x, y, LevelInfo[x][y].shockShadeUpper);
							fprintf(fBODY, "\tshade = (0.50) * (1 - ((%d - shadeUpperAdj) / 15));\n", LevelInfo[x][y].shockShadeUpper);
							//fprintf(fBODY, "\tlight_%02d_%02d_upper_state = light_%02d_%02d_upper_state + (dir * %d);\n", x, y,x,y,shadeUpper);
							//fprintf(fBODY, "\tsys.println(\"Setting upper shade %02d %02d\"); \n",x,y);
							//fprintf(fBODY, "\tsys.println(shade); \n");
							fprintf(fBODY, "\t$light_%02d_%02d_upper.setColor( shade,shade,shade );\n", x, y);
						}
						if ((shadeLower1 >= 1) || (shadeLower2 >= 1))
						{
							//fprintf(fBODY, "\tshade =  (0.50) * (1 - ((light_%02d_%02d_lower_state + (dir * %d)) / 15)) ;\n", x, y, shadeLower);
							fprintf(fBODY, "\tshade = (0.50) * (1 - ((%d - shadeLowerAdj) / 15));\n", LevelInfo[x][y].shockShadeLower);
							//fprintf(fBODY, "\tlight_%02d_%02d_lower_state = light_%02d_%02d_lower_state + (dir * %d);\n", x, y, x, y, shadeLower);
							//fprintf(fBODY, "\tsys.println(\"Setting lower shade %02d %02d\"); \n", x, y);
							//fprintf(fBODY, "\tsys.println(shade); \n");
							fprintf(fBODY, "\t$light_%02d_%02d_lower.setColor( shade,shade,shade );\n", x, y);
						}
					}

				}
			}
			fprintf(fGLOBALS, "\tfloat %s_light_state = 0;\n",UniqueObjectName(currObj));	//Global for the master trigger state for on / off behaviour.
			//fprintf(fBODY, "\tif (%s_light_state == 0)\n\t{\n", UniqueObjectName(currObj));
			//fprintf(fBODY, "\t\t%s_light_state = 1;\n\t}\n\telse\n\t{\n", UniqueObjectName(currObj));
			//fprintf(fBODY, "\t\t%s_light_state = 0;\n\t}\n", UniqueObjectName(currObj));

			fprintf(fBODY, "\tif (%s_light_state == 0)\n\t{\n", UniqueObjectName(currObj));
			fprintf(fBODY, "\t\t%s_light_state = 1;\n\t}\n\telse\n\t{\n", UniqueObjectName(currObj));
			fprintf(fBODY, "\t\t%s_light_state = 0;\n\t}\n", UniqueObjectName(currObj));
		}
		else
		{
							
			fprintf(fBODY,"\tsys.println(\"Lighting control cp1=%d cp2=%d\");\n",currObj.shockProperties[TRIG_PROPERTY_CONTROL_1],currObj.shockProperties[TRIG_PROPERTY_CONTROL_2]);		
		}

		break;
		}
	case ACTION_EFFECT:
		{
/*		printf("\tACTION_EFFECT\n");
		printf("\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
		printf("\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
		printf("\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
		printf("\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
		printf("\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
		printf("\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
		printf("\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
		printf("\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));	*/	
		fprintf(fBODY,"\tsys.println(\"Special Effect\");\n");		
		break;
		}
	case ACTION_MOVING_PLATFORM:
		{
		//000C	int16	Tile x coord of platform
		//0010	int16	Tile y coord of platform
		//0014	int16	Target floor height
		//0016	int16	Target ceiling height
		//0018	int16	Speed
		//printf("\tACTION_MOVING_PLATFORM\n");
		//printf("\t\tTileX of Platform:%d\n",getValAtAddress(sub_ark,add_ptr+0x0C,16));
		//printf("\t\tTileY of Platform:%d\n",getValAtAddress(sub_ark,add_ptr+0x10,16));
		//printf("\t\tTarget floor height:%d\n",getValAtAddress(sub_ark,add_ptr+0x14,16));
		//printf("\t\tTarget ceiling height:%d\n",getValAtAddress(sub_ark,add_ptr+0x16,16));
		//printf("\t\tSpeed:%d\n",getValAtAddress(sub_ark,add_ptr+0x18,16));
		int triggerX = currObj.shockProperties[TRIG_PROPERTY_TARGET_X];
		int triggerY = currObj.shockProperties[TRIG_PROPERTY_TARGET_Y];
		int targetFloor = currObj.shockProperties[TRIG_PROPERTY_FLOOR];
		int targetCeiling = currObj.shockProperties[TRIG_PROPERTY_CEILING];
		//objList[objIndex].shockProperties[TRIG_PROPERTY_SPEED] = getValAtAddress(sub_ark,add_ptr+0x18,16);
		
		MovingPlatformSCRIPT(triggerX,triggerY,targetFloor,targetCeiling,LevelInfo);

		
		break;
		
		}
	case ACTION_TIMER:
		{
			if (currObj.shockProperties[0]> 0)
				{
					if (currObj.shockProperties[1] != 0){ fprintf(fBODY, "\tsys.wait(%d);\n", currObj.shockProperties[1] / 10); }
					shockScriptActivate(objList, objList[currObj.shockProperties[0]]);
				}
			break;
		}
	case ACTION_CHOICE:
		{//A toggle?
		//000C	int16	Trigger 1
		//0010	int16	Trigger 2
/*		printf("\tACTION_CHOICE\n");
		printf("\t\tTrigger1:%d\n",getValAtAddress(sub_ark,add_ptr+0x0C,16));
		printf("\t\tTrigger2:%d\n",getValAtAddress(sub_ark,add_ptr+0x10,16));
		
		printf("\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
		printf("\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
		printf("\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));	
		printf("\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
		printf("\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));*/	
		//currObj.shockProperties[TRIG_PROPERTY_TRIG_1] = getValAtAddress(sub_ark,add_ptr+0x0C,16);	
		//currObj.shockProperties[TRIG_PROPERTY_TRIG_2] = getValAtAddress(sub_ark,add_ptr+0x10,16);	
		
	    toggleSCRIPT(objList, currObj);
		break;
		}
	case ACTION_EMAIL:
		{
		//printf("\tACTION_EMAIL\n");
		//	0F Player receives email
		//000C	int16	Chunk no. of email (offset from 2441 0x0989)
		//printf("\t\tEmail chunk:", getValAtAddress(sub_ark,add_ptr+0x0C,16)+2441);
		//objList[objIndex].shockProperties[TRIG_PROPERTY_EMAIL] =getValAtAddress(sub_ark,add_ptr+0x0C,16)+2441;
		fprintf(fBODY,"\tsys.println(\"You got mail:%d\");\n", currObj.shockProperties[TRIG_PROPERTY_EMAIL]);	//Add a readable to the inventory?
		fprintf(fBODY, "\t$player1.addInvItem($%s_email);\n", UniqueObjectName(currObj));
		//And activate it straight away/
		//fprintf(fBODY, "\t$%s_email.activate($player1);\n", UniqueObjectName(currObj));
		EMAILScript("", currObj, currObj.shockProperties[TRIG_PROPERTY_EMAIL]);
		break;
		
		}
	case ACTION_RADAWAY:
		{
		//printf("\tACTION_RADAWAY\n");
		//printf("\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
		//printf("\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
		//printf("\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
		//printf("\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
		//printf("\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
		//printf("\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
		//printf("\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
		//printf("\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));	
		fprintf(fBODY,"\tsys.println(\"Radiation Treatment\");\n");
		break;
		}
	case ACTION_CHANGE_STATE:
		{
		//printf("\tACTION_CHANGE_STATE\n");
		//printf("\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
		//printf("\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
		//printf("\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
		//printf("\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
		//printf("\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
		//printf("\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
		//printf("\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
		//printf("\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));	
		fprintf(fBODY,"\tsys.println(\"Change state.\");\n");
		break;
		}
	case ACTION_MESSAGE:
		{
		//16 Trap message
		//000C	int16	"Success" message
		//0010	int16	"Fail" message
		//printf("\tACTION_MESSAGE\n");
		//	printf("\t\tSuccess Message%d\n",getValAtAddress(sub_ark,add_ptr+0x0C,16));
		//printf("\t\tFail Message:%d\n",getValAtAddress(sub_ark,add_ptr+0x10,16));
		//objList[objIndex].shockProperties[TRIG_PROPERTY_MESSAGE1]=getValAtAddress(sub_ark,add_ptr+0x0C,16);
		//objList[objIndex].shockProperties[TRIG_PROPERTY_MESSAGE2]=getValAtAddress(sub_ark,add_ptr+0x10,16);
		//fprintf(fBODY,"\tsys.println(\"Message\");\n");
		if ((currObj.conditions[0] > 0) && (currObj.conditions[0] < 255))	//has a condition
		{
			addGlobalTest(objList, currObj,0);
			//play the success message
			fprintf(fBODY, "\n\t$data_reader_trigger.setKey(\"snd_say\",\"shock_audio_bark_%d\");", currObj.shockProperties[TRIG_PROPERTY_MESSAGE1]);
			fprintf(fBODY, "\n\t$data_reader_trigger.activate($player1);\n\t}");
			//else the fail message
			fprintf(fBODY, "\n\telse\n\t{\n\t$data_reader_trigger.setKey(\"snd_say\",\"shock_audio_bark_%d\");", currObj.shockProperties[TRIG_PROPERTY_MESSAGE2]);
			fprintf(fBODY, "\n\t$data_reader_trigger.activate($player1);\n\t}\n");
		}
		else
		{//Just play the fail message
			fprintf(fBODY, "\n\t$data_reader_trigger.setKey(\"snd_say\",\"shock_audio_bark_%d\");", currObj.shockProperties[TRIG_PROPERTY_MESSAGE2]);
			fprintf(fBODY, "\n\t$data_reader_trigger.activate($player1);\n");
		}
		//objList[objIndex].shockProperties[TRIG_PROPERTY_MESSAGE1] = getValAtAddress(sub_ark, add_ptr + 0x0C, 16);
		//objList[objIndex].shockProperties[TRIG_PROPERTY_MESSAGE2] = getValAtAddress(sub_ark, add_ptr + 0x10, 16);
		break;
		}
	case ACTION_SPAWN:	
		{
		//000C	int32	Class/subclass/type of object to spawn
		//0010	int16	Control point 1 (object)
		//0012	int16	Control point 2 (object)
		//0014		??
		//0018		??	
		//printf("\tACTION_SPAWN\n");
		//printf("\t\Class-sub-type to spawn:%d\n",getValAtAddress(sub_ark,add_ptr+0x0C,32));
		//printf("\t\tControl point object1:%d\n",getValAtAddress(sub_ark,add_ptr+0x10,16));
		//printf("\t\tControl point object2:%d\n",getValAtAddress(sub_ark,add_ptr+0x12,16));
		//printf("\t\t??:%d\n",getValAtAddress(sub_ark,add_ptr+0x14,16));		
		//printf("\t\t??:%d\n",getValAtAddress(sub_ark,add_ptr+0x18,16));	
		//objList[objIndex].shockProperties[TRIG_PROPERTY_TYPE]=getValAtAddress(sub_ark,add_ptr+0x0C,32);
		//objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_1]=getValAtAddress(sub_ark,add_ptr+0x10,16);
		//objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_1]=getValAtAddress(sub_ark,add_ptr+0x12,16);
		
		fprintf(fBODY,"\tsys.println(\"Spawn\");\n");
		break;
		}	
	case ACTION_CHANGE_TYPE:
		{
		//000C	int16	Object ID to change.
		//0010	int8	New type.
		//0012		??
		//printf("\tACTION_CHANGE_TYPE\n");
		//printf("\t\Object to Change:%d\n",getValAtAddress(sub_ark,add_ptr+0x0C,16));
		//printf("\t\tNew Type:%d\n",getValAtAddress(sub_ark,add_ptr+0x10,8));
		//printf("\t\t??:%d\n",getValAtAddress(sub_ark,add_ptr+0x12,16));	
			
		//objList[objIndex].shockProperties[TRIG_PROPERTY_OBJECT] =getValAtAddress(sub_ark,add_ptr+0x0C,16);
		//objList[objIndex].shockProperties[TRIG_PROPERTY_TYPE] =getValAtAddress(sub_ark,add_ptr+0x10,8);
		int objToChange = currObj.shockProperties[TRIG_PROPERTY_OBJECT];
		int newObjType = currObj.shockProperties[TRIG_PROPERTY_TYPE];
		int newObjTypeID = getObjectIDByClass(objList[objToChange].ObjectClass, objList[objToChange].ObjectSubClass, currObj.shockProperties[TRIG_PROPERTY_TYPE]);
		
		fprintf(fBODY, "\tsys.println(\"Changing %s to a %s\");\n",
			UniqueObjectName(objList[objToChange]),
			getObjectNameByClass(objList[objToChange].ObjectClass, objList[objToChange].ObjectSubClass, newObjType));

		fprintf(fBODY, "\t$%s.setModel(\"%s\");\n", UniqueObjectName(objList[objToChange]),objectMasters[newObjTypeID].path);
		fprintf(fBODY, "\t$%s.becomeSolid();\n", UniqueObjectName(objList[objToChange]));

		break;
		}
	default:
		{
		//printf("\tUnknown triggeraction:%d\n",TriggerType);
		fprintf(fBODY,"\tsys.println(\"Unknown trigger action:%d\");\n",currObj.TriggerAction);
		}	
	
	}
	if (currObj.TriggerOnce == 1)
	{
		fprintf(fBODY, "\t}\n");
	}
	if ((currObj.conditions[0] > 0) && (currObj.conditions[0] < 255) && (currObj.item_id != 378) && (currObj.TriggerAction != ACTION_MESSAGE))
	{
		fprintf(fBODY, "\t}\n");
	}
}

void shockScriptActivate(ObjectItem objList[1600], ObjectItem targetObj)
{
//produces the code to activate a particular obect. some objects are special cases but in general it's all handled by the trigger.

if (targetObj.InUseFlag ==1)
{
switch(objectMasters[targetObj.item_id].type )
	{
	case DOOR:	//For a door I activate it's lock object
		fprintf(fBODY,"\t$a_lock_%03d_%03d.activate($player1);\n",targetObj.tileX, targetObj.tileY); 
		break;
	case SHOCK_TRIGGER_NULL:	//I activate the script call. *Nullscript can be many things such as cameras so I will need to account for that at some stage.
		if (targetObj.TriggerAction == ACTION_TIMER)
			{	//Activates a timer linked to the null trigger
			fprintf(fBODY, "\t$timer_%s.activate($player1);\n", UniqueObjectName(targetObj));
			}
		else
		{
			fprintf(fBODY, "\t$runscript_%s.activate($player1);\n", UniqueObjectName(targetObj));
		}
		
		break;
	case SHOCK_TRIGGER_REPULSOR:
		fprintf(fBODY,"\t$runscript_%s.activate($player1);\n", UniqueObjectName(targetObj)); 
		break;
	default:
		fprintf(fBODY,"\t$%s.activate($player1);\n", UniqueObjectName(targetObj)); 
	}
}
else
	{
		fprintf(fBODY,"\tsys.println(\"Object %d: Not in use\");\n", targetObj.index ); 
	}
}


void MovingPlatformSCRIPT(int triggerX, int triggerY, int targetFloor, int targetCeiling, tile LevelInfo[64][64])
{
		//000C	int16	Tile x coord of platform
		//0010	int16	Tile y coord of platform
		//0014	int16	Target floor height
		//0016	int16	Target ceiling height
		//0018	int16	Speed
		//printf("\tACTION_MOVING_PLATFORM\n");
		//printf("\t\tTileX of Platform:%d\n",getValAtAddress(sub_ark,add_ptr+0x0C,16));
		//printf("\t\tTileY of Platform:%d\n",getValAtAddress(sub_ark,add_ptr+0x10,16));
		//printf("\t\tTarget floor height:%d\n",getValAtAddress(sub_ark,add_ptr+0x14,16));
		//printf("\t\tTarget ceiling height:%d\n",getValAtAddress(sub_ark,add_ptr+0x16,16));
		//printf("\t\tSpeed:%d\n",getValAtAddress(sub_ark,add_ptr+0x18,16));
		
		//int triggerX = currObj.shockProperties[TRIG_PROPERTY_TARGET_X];
		//int triggerY = currObj.shockProperties[TRIG_PROPERTY_TARGET_Y];
		//int targetFloor = currObj.shockProperties[TRIG_PROPERTY_FLOOR];
		//int targetCeiling = CEILING_HEIGHT - currObj.shockProperties[TRIG_PROPERTY_CEILING];
		//objList[objIndex].shockProperties[TRIG_PROPERTY_SPEED] = getValAtAddress(sub_ark,add_ptr+0x18,16);
		targetCeiling =  targetCeiling;	//needs to be offset from the top.
		const char *objDesc="lift";

			switch (LevelInfo[triggerX][triggerY].hasElevator)
				{
				case 1: //floor only moves
					if (LevelInfo[triggerX][triggerY].global !=1)
						{
						fprintf(fGLOBALS,"\tfloat %s_%03d_%03d_floor_state = %d;\n", objDesc,triggerX,triggerY,LevelInfo[triggerX][triggerY].floorHeight );
						LevelInfo[triggerX][triggerY].global =1;	//Global is already created.
						}
					
					fprintf(fBODY,"\tfloat displacement = %d - %s_%03d_%03d_floor_state;\n",targetFloor, objDesc,triggerX,triggerY );
					fprintf(fBODY,"\t$floor_%03d_%03d.move( UP, displacement * %d  );\n", triggerX,triggerY,BrushSizeZ);
					fprintf(fBODY,"\t%s_%03d_%03d_floor_state = %d ;\n\n", objDesc,triggerX,triggerY,targetFloor);
					break;
				case 2:	//Ceiling only moves
					if (LevelInfo[triggerX][triggerY].global !=1)
						{
						fprintf(fGLOBALS,"\tfloat %s_%03d_%03d_ceiling_state = %d;\n", objDesc,triggerX,triggerY,SHOCK_CEILING_HEIGHT - LevelInfo[triggerX][triggerY].ceilingHeight );
						LevelInfo[triggerX][triggerY].global =1;	//Global is already created.
						}					
					fprintf(fBODY,"\tfloat displacement = %d - %s_%03d_%03d_ceiling_state;\n",targetCeiling, objDesc,triggerX,triggerY );
					fprintf(fBODY,"\t$ceiling_%03d_%03d.move( UP, displacement * %d );\n", triggerX,triggerY,BrushSizeZ);
					fprintf(fBODY,"\t%s_%03d_%03d_ceiling_state = %d ;\n\n", objDesc,triggerX,triggerY,targetCeiling);
					break;
				case 3: //both move
					if (LevelInfo[triggerX][triggerY].global !=1)
						{
						fprintf(fGLOBALS,"\tfloat %s_%03d_%03d_floor_state = %d;\n", objDesc,triggerX,triggerY,LevelInfo[triggerX][triggerY].floorHeight );
						fprintf(fGLOBALS,"\tfloat %s_%03d_%03d_ceiling_state = %d;\n", objDesc,triggerX,triggerY,LevelInfo[triggerX][triggerY].ceilingHeight );
						LevelInfo[triggerX][triggerY].global =1;	//Global is already created.
						}
					//printf("\tsys.println(\"Initial floor global should be\" + %d);\n",LevelInfo[triggerX][triggerY].floorHeight);	
					
					fprintf(fBODY,"\tfloat displacement = %d - %s_%03d_%03d_floor_state;\n",targetFloor, objDesc,triggerX,triggerY );
					fprintf(fBODY,"\t$floor_%03d_%03d.move( UP, displacement * %d );\n",triggerX,triggerY,BrushSizeZ);
					fprintf(fBODY,"\t%s_%03d_%03d_floor_state = %d ;\n\n", objDesc,triggerX,triggerY,targetFloor);
					
					fprintf(fBODY,"\tsys.println(\"Initial ceiling global should be\" + %d);\n",LevelInfo[triggerX][triggerY].floorHeight);	
					fprintf(fBODY,"\tdisplacement = %d - %s_%03d_%03d_ceiling_state;\n",targetCeiling, objDesc,triggerX,triggerY );
					fprintf(fBODY,"\t$ceiling_%03d_%03d.move( UP, displacement * %d );\n", triggerX,triggerY,BrushSizeZ);
					fprintf(fBODY,"\t%s_%03d_%03d_ceiling_state = %d ;\n\n", objDesc,triggerX,triggerY,targetCeiling);
					
					
				}
			}

void toggleSCRIPT(ObjectItem objList[1600], ObjectItem currObj)
{
	//An action_choice trigger action.- a toggle.
	//fprintf(fBODY, "\tsys.println(\"Is this a toggle?\");\n");
	if (objList[currObj.index].global != 1)
	{	//Add a global state for this toggle
		fprintf(fGLOBALS, "\tfloat %s_state = 1;\n", UniqueObjectName(currObj));
		objList[currObj.index].global = 1;
	}
	fprintf(fBODY, "\tif (%s_state == 1)", UniqueObjectName(currObj));
	fprintf(fBODY, "\n\t\t{\n\t");
	shockScriptActivate(objList, objList[currObj.shockProperties[TRIG_PROPERTY_TRIG_1]]);
	fprintf(fBODY, "\t\t%s_state = 0;\n\t\t}", UniqueObjectName(currObj));
	fprintf(fBODY, "\n\telse\n\t\t{\n\t");
	shockScriptActivate(objList, objList[currObj.shockProperties[TRIG_PROPERTY_TRIG_2]]);
	fprintf(fBODY, "\n\t\t%s_state = 1 ;\n\t\t}\n", UniqueObjectName(currObj));
}

void scriptShockButtonsActions(tile LevelInfo[64][64], ObjectItem objList[1600], ObjectItem currObj)
{
	switch (currObj.TriggerAction)
	{
	case ACTION_CHANGE_STATE:	//There is some sort of value change going on here. I need to see more examples.
		{
		fprintf(fBODY, "\tsys.println(\"Action change state by switch:%s)\");\n", UniqueObjectName(currObj));
		shockScriptActivate(objList, objList[currObj.shockProperties[BUTTON_PROPERTY_TRIGGER_2]]);
		break;
		}
	case ACTION_ACTIVATE: //sets off a bunch of triggers
		{
			fprintf(fBODY, "\tsys.println(\"Action activate by switch:%s)\");\n", UniqueObjectName(currObj));
			if (currObj.shockProperties[0] > 0)
			{
				if (currObj.shockProperties[1] != 0){ fprintf(fBODY, "\tsys.wait(%d);\n", currObj.shockProperties[1] / 10); }
				shockScriptActivate(objList, objList[currObj.shockProperties[0]]);
			}
			if (currObj.shockProperties[2] > 0)
			{
				if (currObj.shockProperties[3] != 0){ fprintf(fBODY, "\tsys.wait(%d);\n", currObj.shockProperties[3] / 10); }
				shockScriptActivate(objList, objList[currObj.shockProperties[2]]);
			}
			if ((currObj.shockProperties[4] > 0) && (currObj.shockProperties[4]< 1600))
			{
				if (currObj.shockProperties[5] != 0){ fprintf(fBODY, "\tsys.wait(%d);\n", currObj.shockProperties[5] / 10); }
				shockScriptActivate(objList, objList[currObj.shockProperties[4]]);
			}
			if (currObj.shockProperties[6]> 0)
			{
				if (currObj.shockProperties[7] != 0){ fprintf(fBODY, "\tsys.wait(%d);\n", currObj.shockProperties[7] / 10); }
				shockScriptActivate(objList, objList[currObj.shockProperties[6]]);
			}
			break;
		}
	case ACTION_MOVING_PLATFORM:
		{
		int triggerX = currObj.shockProperties[TRIG_PROPERTY_TARGET_X];
		int triggerY = currObj.shockProperties[TRIG_PROPERTY_TARGET_Y];
		int targetFloor = currObj.shockProperties[TRIG_PROPERTY_FLOOR];
		int targetCeiling = currObj.shockProperties[TRIG_PROPERTY_CEILING];
		MovingPlatformSCRIPT(triggerX, triggerY, targetFloor, targetCeiling, LevelInfo);
		break;
		}
	case ACTION_CHOICE:
		{
		toggleSCRIPT(objList, currObj);
		break;
		}
	case ACTION_LIGHTING:
		{
		fprintf(fBODY, "\tsys.println(\"Lighting control cp1=%d cp2=%d\");\n", currObj.shockProperties[TRIG_PROPERTY_CONTROL_1], currObj.shockProperties[TRIG_PROPERTY_CONTROL_2]);
		break;
		}
	case ACTION_MESSAGE:
		{
		fprintf(fBODY, "\n\t$data_reader_trigger.setKey(\"snd_say\",\"shock_audio_bark_%d\");", currObj.shockProperties[TRIG_PROPERTY_MESSAGE2]);
		fprintf(fBODY, "\n\t$data_reader_trigger.activate($player1);\n");
		break;
		}
	case ACTION_CHANGE_TYPE:
		{
		//fprintf(fBODY, "\tsys.println(\"Change Type\");\n");
		int objToChange = currObj.shockProperties[TRIG_PROPERTY_OBJECT];
		int newObjType = currObj.shockProperties[TRIG_PROPERTY_TYPE];
		fprintf(fBODY, "\tsys.println(\"Changing %s to an %s\");\n",
				UniqueObjectName(objList[objToChange]),
				getObjectNameByClass(objList[objToChange].ObjectClass, objList[objToChange].ObjectSubClass,newObjType));

		//printf("\t\tChanges to %s\n", getObjectNameByClass(objList[objIndex].ObjectClass, objList[objIndex].ObjectSubClass, objList[objIndex].ObjectSubClassIndex);

		break;
		}
	default:
		{
			if (currObj.TriggerAction != ACTION_DO_NOTHING)	//default
			{
				fprintf(fBODY, "\tsys.println(\"New switch trigger action %d for %s)\");\n", currObj.TriggerAction, UniqueObjectName(currObj));
			}
			if (currObj.shockProperties[BUTTON_PROPERTY_TRIGGER] < 1600)
			{
				shockScriptActivate(objList, objList[currObj.shockProperties[BUTTON_PROPERTY_TRIGGER]]); break;
			}
		}
	}
}