using UnityEngine;
using System.Collections;
/// <summary>
/// Decal object_base for flat wall mounted objects like signs and switches.
/// </summary>
/// TODO:make switches extend further out than tmaps.
public class Decal : object_base
{

    protected override void Start()
    {
        base.Start();

        //Line up decals to walls where the decal is set to be on an edge.
        int tileX = ObjectTileX;
        int tileY = ObjectTileY;
        int x = xpos;
        int y = ypos;
        int decalheading = heading * 45;
        Vector3 objPos = this.transform.position;
        Vector3 adjustment = Vector3.zero;
        if (TileMap.ValidTile(tileX, tileY))
        {//TODO:this is probably wrong!!
            switch (CurrentTileMap().Tiles[tileX, tileY].tileType)
            {
                case TileMap.TILE_OPEN:
                    {
                        if ((x == 0) && ((decalheading == ObjectInteraction.HEADINGSOUTH) || (decalheading == ObjectInteraction.HEADINGNORTH)))
                        {//Move object Right.
                            adjustment += new Vector3(0.2f, 0, 0);
                        }
                        if ((x == 7) && ((decalheading == ObjectInteraction.HEADINGSOUTH) || (decalheading == ObjectInteraction.HEADINGNORTH)))
                        {//Move object left.
                            adjustment += new Vector3(-0.2f, 0, 0);
                        }

                        if ((y == 0) && ((decalheading == ObjectInteraction.HEADINGEAST) || (decalheading == ObjectInteraction.HEADINGWEST)))
                        {//move object forward
                            adjustment += new Vector3(0, 0, 0.2f);
                        }

                        if ((y == 7) && ((decalheading == ObjectInteraction.HEADINGEAST) || (decalheading == ObjectInteraction.HEADINGWEST)))
                        {//Move object backward..
                            adjustment += new Vector3(0, 0, -0.2f);
                        }
                        break;
                    }

                case TileMap.TILE_DIAG_NW:
                    if ((decalheading == ObjectInteraction.HEADINGNORTHWEST))
                    {//This decal clips into the wall
                        adjustment += new Vector3(-0.02f, 0, +0.02f);
                    }
                    break;


                case TileMap.TILE_DIAG_NE:
                    if ((decalheading == ObjectInteraction.HEADINGNORTHEAST))
                    {//This decal is out from the wall.
                        adjustment += new Vector3(+0.02f, 0, +0.02f);
                    }
                    break;


                case TileMap.TILE_DIAG_SE:
                    if ((decalheading == ObjectInteraction.HEADINGSOUTHEAST))
                    {//This decal is out from the wall.
                        adjustment += new Vector3(-0.08f, 0, +0.08f);
                    }
                    break;

                case TileMap.TILE_DIAG_SW:
                    if ((decalheading == ObjectInteraction.HEADINGSOUTHWEST))
                    {//This decal is out from the wall.
                        adjustment += new Vector3(+0.08f, 0, +0.08f);
                    }
                    break;

                default:
                    break;
            }
            this.transform.position = objPos + adjustment;
        }
    }
}
