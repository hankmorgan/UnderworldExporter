using UnityEngine;
using System.Collections;

/// <summary>
/// Base monobehavior for Underworld Exporter (UWE)
/// </summary>
/// Some common utility code.
public class UWEBase : MonoBehaviour
{

    public const string GAME_UWDEMO = "UW0";
    public const string GAME_UW1 = "UW1";
    public const string GAME_UW2 = "UW2";
    public const string GAME_SHOCK = "SHOCK";
    public const string GAME_TNOVA = "TNOVA";
    /// <summary>
    /// The folder containing the resources for this game.
    /// </summary>
    public static string _RES = GAME_UW1;

    public static bool EditorMode = false;

    public static char sep;

    /// <summary>
    /// Returns or sets the object that the player is holding.
    /// </summary>
    public static ObjectInteraction CurrentObjectInHand
    {
        get
        {
            if (UWCharacter.Instance != null)
            {
                if (UWCharacter.Instance.playerInventory != null)
                {
                    return UWCharacter.Instance.playerInventory.ObjectInHand;
                }
            }
            return null;
        }
        set
        {
            UWCharacter.Instance.playerInventory.ObjectInHand = value;
        }     
    }

    /// <summary>
    /// Gets the impact point of this object
    /// </summary>
    /// <returns>The impact point.</returns>
    public virtual Vector3 GetImpactPoint()
    {
        return this.transform.position;
    }




    /// <summary>
    /// Freezes the movement of the specified object if it has a rigid body attached.
    /// </summary>
    /// <param name="myObj">My object.</param>
    public static void FreezeMovement(GameObject myObj)
    {//Stop objects which can move in the 3d world from moving when they are in the inventory or containers.
        Rigidbody rg = myObj.GetComponent<Rigidbody>();
        if (rg != null)
        {
            rg.useGravity = false;
            rg.constraints =
                    RigidbodyConstraints.FreezeRotationX
                    | RigidbodyConstraints.FreezeRotationY
                    | RigidbodyConstraints.FreezeRotationZ
                    | RigidbodyConstraints.FreezePositionX
                    | RigidbodyConstraints.FreezePositionY
                    | RigidbodyConstraints.FreezePositionZ;
        }
    }

    public static void FreezeMovement(ObjectInteraction myObj)
    {
        FreezeMovement(myObj.gameObject);
    }

    /// <summary>
    /// Unfreeze the movement of the specified object if it has a rigid body attached.
    /// </summary>
    /// <param name="myObj">My object.</param>
    public static void UnFreezeMovement(GameObject myObj)
    {//Allow objects which can move in the 3d world to moving when they are released.
        Rigidbody rg = myObj.GetComponent<Rigidbody>();
        if (rg != null)
        {
            rg.useGravity = true;
            rg.constraints =
                    RigidbodyConstraints.FreezeRotationX
                    | RigidbodyConstraints.FreezeRotationY
                    | RigidbodyConstraints.FreezeRotationZ;
        }
    }

    public static void UnFreezeMovement(ObjectInteraction myObj)
    {
        UnFreezeMovement(myObj.gameObject);
    }


    /// <summary>
    /// Returns the current map object list
    /// </summary>
    /// <returns>The object list.</returns>
    public static ObjectLoader CurrentObjectList()
    {
        if (GameWorldController.instance.LevelNo == -1)
        {
            return null;
        }
        else
        {
            return GameWorldController.instance.objectList[GameWorldController.instance.LevelNo];
        }
    }

    /// <summary>
    /// Returns the current tile map
    /// </summary>
    /// <returns>The tile map.</returns>
    public static TileMap CurrentTileMap()
    {
        if (GameWorldController.instance.LevelNo == -1)
        {
            return null;
        }
        else
        {
            return GameWorldController.instance.Tilemaps[GameWorldController.instance.LevelNo];
        }

    }

    public static AutoMap CurrentAutoMap()
    {
        if (GameWorldController.instance.LevelNo == -1)
        {
            return null;
        }
        else
        {
            return GameWorldController.instance.AutoMaps[GameWorldController.instance.LevelNo];
        }
    }



}
