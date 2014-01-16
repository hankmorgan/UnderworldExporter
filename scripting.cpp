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

void EMAILScript(char objName[80], ObjectItem currObj, int logChunk)
{
	fprintf(fBODY,"void start_%s()\n{",UniqueObjectName(currObj));
	fprintf(fBODY,"\n$data_reader_trigger.setKey(\"snd_say\",\"shock_audio_log_%04d\");",logChunk);
	fprintf(fBODY,"\n$data_reader_trigger.activate($player1);");
	fprintf(fBODY,"\n}\n\n");
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
    fprintf(fBODY,"\t\t$%s_%03d_%03d.move( DOWN, 105 );\n", objDesc,triggerX,triggerY,down);
    fprintf(fBODY,"\t\t%s_%03d_%03d_state = 0;\n}\n", objDesc,triggerX,triggerY);
    fprintf(fBODY,"\telse\n\t\t{\n");
    fprintf(fBODY,"\t\t$%s_%03d_%03d.move ( UP, 15 );\n" ,objDesc,triggerX,triggerY,up);
    fprintf(fBODY,"\t\t%s_%03d_%03d_state++ ;\n\t}\n",objDesc,triggerX,triggerY);
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
						fprintf(fBODY,"\n\nvoid start_%s_%03d_%03d_%03d()\n{\n",
								objectMasters[objList[nextObj].item_id].desc,x,y,objList[nextObj].index);
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
				a_do_trap_platformSCRIPT(objectMasters[currObj.item_id].desc, *TriggerTargetX, *TriggerTargetY,currObj.index,*TriggerFlags,30,210);
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
//At the moment I just generate email logs.

	if (fopen_s(&fBODY,SCRIPT_FINAL_FILE, "w")==0)
		{
		fprintf(fBODY,"#ifndef __game%d_%d_script__\n#define __game%d_%d_script__\n",game,LevelNo,game,LevelNo);

			//printf("\nPrint out audio logs for :%d\n",LevelNo);	
			//printf("Desc ObjID TileX TileY LogChunk\n");
			for (int y=63; y>=0;y--)
			{
			for (int x=0; x<64;x++)
				{
				if(LevelInfo[x][y].indexObjectList !=0)
					{
					long nextShockObj = LevelInfo[x][y].indexObjectList;
					while (nextShockObj !=0)
						{
						if (isLog(objList[nextShockObj])==1)
							{
							EMAILScript(objectMasters[objList[nextShockObj].item_id].desc
												,objList[nextShockObj]
												,objList[nextShockObj].shockProperties[SOFT_PROPERTY_LOG]);
							}
						nextShockObj=objList[nextShockObj].next ;
						}
					}
				}
			}
		fprintf(fBODY,"#endif //__game%d_%d_script__",game,LevelNo);
		fclose(fBODY);
	}

}