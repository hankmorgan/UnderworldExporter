using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a_hack_trap_platformwave : a_hack_trap {
    //Raises or lowers tiles along a line
    //X000X111X
    //X = stationary platforms.
    //0 or 1 = tiles that goes up or down
    //The two sets of moving tiles are mirrored
    //Owner appears to control what state this trap is in  (always seems to be an odd number)
    //Owner is 5 at the highest peak (the first set)
    //Owner is 9 when flat
    //Owner is 13 when lowest
    //Example in void
    //10,51 to 10,45,  10,48 stays still in the middle.


    /// <summary>
    /// The colliders that are in contact with the trigger.
    /// </summary>
   // public Collider[,] colliders;

    /// <summary>
    /// The position of the center of the tile.
    /// </summary>
    public Vector3 TileVector;

    /// <summary>
    /// The contact area that detects the presence of objects.
    /// </summary>
    public Vector3 ContactArea = new Vector3(0.59f, 0.15f, 0.59f);

    const int baseHeight = 18;

    public override void ExecuteTrap(object_base src, int triggerX, int triggerY, int State)
    {
        //I would have expected to increment by 2 but there appears to be two seperate trigger chains acting on this trap in game
        owner++;
        if (owner > 15)
        {
            owner = 1;
        }

        switch (owner)
        {
            case 1:
                ChangeTileHeight(10, 49, baseHeight-2);
                ChangeTileHeight(10, 50, baseHeight);
                ChangeTileHeight(10, 51, baseHeight-2);

                ChangeTileHeight(10, 45, baseHeight + 2);
                ChangeTileHeight(10, 46, baseHeight);
                ChangeTileHeight(10, 47, baseHeight + 2);

                break;
            case 3:
                ChangeTileHeight(10, 49, baseHeight + 4 -2);
                ChangeTileHeight(10, 50, baseHeight + 4 );
                ChangeTileHeight(10, 51, baseHeight + 4 -2);

                ChangeTileHeight(10, 45, baseHeight  -4 + 2);
                ChangeTileHeight(10, 46, baseHeight -4 );
                ChangeTileHeight(10, 47, baseHeight -4 + 2);

                break;
            case 5:
                ChangeTileHeight(10, 49, baseHeight+6-2);
                ChangeTileHeight(10, 50, baseHeight + 6);
                ChangeTileHeight(10, 51, baseHeight+6-2);

                ChangeTileHeight(10, 45, baseHeight -6 + 2);
                ChangeTileHeight(10, 46, baseHeight - 6 );
                ChangeTileHeight(10, 47, baseHeight -6 + 2);

                break;
            case 7:
                ChangeTileHeight(10, 49, baseHeight+4-2);
                ChangeTileHeight(10, 50, baseHeight + 4);
                ChangeTileHeight(10, 51, baseHeight+4-2);

                ChangeTileHeight(10, 45, baseHeight -4+2);
                ChangeTileHeight(10, 46, baseHeight -4);
                ChangeTileHeight(10, 47, baseHeight -4+2);

                break;
            case 9:
                ChangeTileHeight(10, 49, baseHeight);
                ChangeTileHeight(10, 50, baseHeight);
                ChangeTileHeight(10, 51, baseHeight);

                ChangeTileHeight(10, 45, baseHeight );
                ChangeTileHeight(10, 46, baseHeight );
                ChangeTileHeight(10, 47, baseHeight);

                break;
            case 11:
                ChangeTileHeight(10, 49, baseHeight-4+2);
                ChangeTileHeight(10, 50, baseHeight -4);
                ChangeTileHeight(10, 51, baseHeight-4+2);

                ChangeTileHeight(10, 45, baseHeight +4-2);
                ChangeTileHeight(10, 46, baseHeight +4 );
                ChangeTileHeight(10, 47, baseHeight +4-2);

                break;
            case 13:
                ChangeTileHeight(10, 49, baseHeight-6+2);
                ChangeTileHeight(10, 50, baseHeight -6);
                ChangeTileHeight(10, 51, baseHeight-6+2);

                ChangeTileHeight(10, 45, baseHeight +6-2);
                ChangeTileHeight(10, 46, baseHeight+6);
                ChangeTileHeight(10, 47, baseHeight + 6-2);

                break;
            case 15:
                ChangeTileHeight(10, 49, baseHeight-4+2);
                ChangeTileHeight(10, 50, baseHeight - 4);
                ChangeTileHeight(10, 51, baseHeight-4+2);

                ChangeTileHeight(10, 45, baseHeight +4-2);
                ChangeTileHeight(10, 46, baseHeight + 4 );
                ChangeTileHeight(10, 47, baseHeight +4-2);

                break;
        }
    }


    void ChangeTileHeight(int tileX, int tileY, int newHeight)
    {
        TileInfo t = CurrentTileMap().Tiles[tileX, tileY];
        //int curHeight = CurrentTileMap().Tiles[tileX, tileX].floorHeight;
        //Debug.Log("Changing height from " + curHeight + " to " + newHeight  + " at " + owner);
        //int diff = newHeight - curHeight;
        t.floorHeight = (short)newHeight;
        GameObject platformTile = GameWorldController.FindTile(tileX, tileY, TileMap.SURFACE_FLOOR);
        TileVector = CurrentTileMap().getTileVector(tileX, tileY);
        Collider[] colliders = Physics.OverlapBox(TileVector, ContactArea);
        
        MoveObjectsInContact((float)(newHeight) * 0.15f, colliders);
        
        //CurrentTileMap().Tiles[tileX, tileX].TileNeedsUpdate();
        DestroyImmediate(platformTile);
        TileMapRenderer.RenderTile(GameWorldController.instance.LevelModel, t.tileX, t.tileY, t, false, false, false, true);
        //MoveTile(platformTile.transform, new Vector3(0f, (float)(diff) * 0.3f, 0f), 0.1f, tileX, tileY);
    }


    public override bool WillFireRepeatedly()
    {
        return true;
    }

    //protected void MoveTile(Transform platform, Vector3 dist, float traveltime, int TileXToWatch, int TileYToWatch)
    //{
    //    //Co-routine to move the tile to it's target position.
    //    //float rate = 1.0f / traveltime;
    //    //float index = 0.0f;
    //    //Vector3 StartPos = platform.position;
    //    //Vector3 EndPos = StartPos + dist;
    //    //this.transform.position = StartPos;


    //    DestroyImmediate(platform.gameObject);


    //    //while (index < 1.0f)
    //    //{
    //    //    Vector3 OldPosition = platform.position;
    //    //    platform.position = Vector3.Lerp(StartPos, EndPos, index);
    //    //    float height = TileVector.y;
    //    //    //move
    //    //    this.transform.position = platform.position;
    //    //    index += rate * Time.deltaTime;
    //    //    yield return new WaitForSeconds(0.01f);
    //    //}
    //    MoveObjectsInContact(EndPos.y, colliders);
    //    //platform.position = EndPos;
    //    //this.transform.position = EndPos;
    //}


    /// <summary>
    /// Moves the objects in contact.
    /// </summary>
    /// <param name="Height">Height.</param>
    /// Could be better.
    public void MoveObjectsInContact(float Height, Collider[] colliders)
    {
        for (int i = 0; i <= colliders.GetUpperBound(0); i++)
        {
            if (colliders[i].gameObject.GetComponent<ObjectInteraction>() != null)
            {
                if (colliders[i].gameObject.GetComponent<ObjectInteraction>().isMoveable())
                {
                    Vector3 objPosition = colliders[i].gameObject.transform.position;
                    UnFreezeMovement(colliders[i].gameObject);
                    colliders[i].gameObject.transform.position = new Vector3(objPosition.x, Height, objPosition.z);
                }
            }
        }
    }

}
