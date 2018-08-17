using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Compass : GuiBase_Draggable
{

    //Updates the compass display based on the characters heading.

    private int PreviousHeading = -1;
    public const int NORTH = 0;
    public const int NORTHNORTHEAST = 1;
    public const int NORTHEAST = 2;
    public const int EASTNORTHEAST = 3;
    public const int EAST = 4;
    public const int EASTSOUTHEAST = 5;
    public const int SOUTHEAST = 6;
    public const int SOUTHSOUTHEAST = 7;
    public const int SOUTH = 8;
    public const int SOUTHSOUTHWEST = 9;
    public const int SOUTHWEST = 10;
    public const int WESTSOUTHWEST = 11;
    public const int WEST = 12;
    public const int WESTNORTHWEST = 13;
    public const int NORTHWEST = 14;
    public const int NORTHNORTHWEST = 15;

    private RawImage comp;
    public RawImage[] NorthIndicators = new RawImage[16];

    private Texture2D[] CompassPoles = new Texture2D[4];

    public override void Start()
    {
        base.Start();
        comp = this.GetComponent<RawImage>();

        for (int i = 0; i < 4; i++)
        {
            //CompassPoles[i]=Resources.Load <Texture2D> (_RES +"/HUD/Compass/Compass_000"+i.ToString());
            CompassPoles[i] = GameWorldController.instance.grCompass.LoadImageAt(i);
        }
        if (_RES == GAME_UW2)
        {
            rectT = new RectTransform[2];
            rectT[0] = this.GetComponent<RectTransform>();
            rectT[1] = UWHUD.instance.powergem.transform.parent.GetComponent<RectTransform>();
        }

    }

    public static int getCompassHeadingOffset(GameObject src, GameObject dst)
    {
        //Get the relative heading in words of the dst from the source.
        int Offset = 0;
        Vector3 dstPosition = new Vector3(dst.transform.position.x, 0, dst.transform.position.z);
        Vector3 srcPosition = new Vector3(src.transform.position.x, 0, src.transform.position.z);

        float angle = Mathf.Atan2(dstPosition.z - srcPosition.z, dstPosition.x - srcPosition.x) * 180 / Mathf.PI;

        if ((angle > -22.5) && (angle <= +22.5))
        {
            //East";	
            Offset = 2;
        }
        else if ((angle > 22.5) && (angle <= +67.5))
        {
            //return "NorthEast";	
            Offset = 1;
        }
        else
                        if ((angle > 67.5) && (angle <= +112.5))
        {
            //return "North";
            Offset = 0;
        }
        else   if ((angle > 112.5) && (angle <= +157.5))
        {
            //return "NorthWest";		
            Offset = 7;
        }
        else  if ((angle > 157.5) && (angle <= +180.0))
        {
            //return "West";	
            Offset = 6;
        }
        else  if ((angle > -180.0) && (angle <= -157.5))
        {
            //return "West";	
            Offset = 5;
        }
        else if ((angle > -157.5) && (angle <= -112.5))
        {
            //return "southwest";	
            Offset = 5;
        }
        else  if ((angle > -112.5) && (angle <= -67.5))
        {
            //return "south";		
            Offset = 4;
        }
        else if ((angle > -67.5) && (angle <= -22.5))
        {
            //return "southeast";		
            Offset = 3;
        }
        /*
000~001~036~to the North	0
000~001~037~to the Northeast 	1
000~001~038~to the East	2
000~001~039~to the Southeast 3
000~001~040~to the South 4
000~001~041~to the Southwest 5
000~001~042~to the West	6
000~001~043~to the Northwest 7
*/
        return Offset;
    }

    public static string getCompassHeading(GameObject src, GameObject dst)
    {//String representation of the above.
        int Offset = Compass.getCompassHeadingOffset(src, dst);

        return StringController.instance.GetString(1, StringController.str_to_the_north + Offset);  //36	
    }



    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (PreviousHeading != UWCharacter.Instance.currentHeading)
        {
            UpdateNorthIndicator();
            PreviousHeading = UWCharacter.Instance.currentHeading;
            switch (UWCharacter.Instance.currentHeading)
            {
                case NORTH:
                case SOUTH:
                case WEST:
                case EAST:
                    {
                        comp.texture = CompassPoles[0];//Resources.Load <Texture2D> ("HUD/Compass/Compass_0000");
                        break;
                    }
                case NORTHWEST:
                case NORTHEAST:
                case SOUTHEAST:
                case SOUTHWEST:
                    {
                        comp.texture = CompassPoles[2];//Resources.Load <Texture2D> ("HUD/Compass/Compass_0002");
                        break;
                    }
                case NORTHNORTHWEST:
                case EASTNORTHEAST:
                case SOUTHSOUTHEAST:
                case WESTSOUTHWEST:
                    {
                        comp.texture = CompassPoles[1];//Resources.Load <Texture2D> ("HUD/Compass/Compass_0001");
                        break;
                    }
                default:
                    {
                        comp.texture = CompassPoles[3];//Resources.Load <Texture2D> ("HUD/Compass/Compass_0003");
                        break;
                    }

            }
        }
    }

    void UpdateNorthIndicator()
    {
        for (int i = 0; i < 16; i++)
        {
            NorthIndicators[i].enabled = (i == UWCharacter.Instance.currentHeading);
        }
    }



    public void OnClick()
    {
        if (Dragging == true) { return; }
        if ((WindowDetectUW.WaitingForInput) || (ConversationVM.InConversation)) { return; }
        UWHUD.instance.MessageScroll.Clear();
        switch (_RES)
        {
            case GAME_UW2:
                StatusStringForUW2(); break;
            default:
                StatusStringForUW1();break;
        }

    }

    private static void StatusStringForUW1()
    {
        GetFedAndFatiqueStatus();

        GetAbyssLevel();

        GetDurationOfQuest();

        GuessTimeOfDay();
    }

    private static void StatusStringForUW2()
    {
        GetFedAndFatiqueStatus();

        GetLabyrinthOfWorldsLevel();

        GuessTimeOfDay();
    }

    private static void GetAbyssLevel()
    {
        UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, StringController.str_you_are_on_the_)
                + StringController.instance.GetString(1, 411 + GameWorldController.instance.LevelNo)
                + StringController.instance.GetString(1, StringController.str__level_of_the_abyss_));
    }

    /// <summary>
    /// Prints what world you are in for UW2
    /// </summary>
    private static void GetLabyrinthOfWorldsLevel()
    {
        GameWorldController.Worlds world = GameWorldController.GetWorld(GameWorldController.instance.LevelNo);
        switch(world)
        {
            case GameWorldController.Worlds.Britannia:
                //TODO: At start of game the fact your are in Britannia is not printed.
                UWHUD.instance.MessageScroll.Add(
                    StringController.instance.GetString(1, 73)
                    + StringController.instance.GetString(1, 75));
                break;
            case GameWorldController.Worlds.PrisonTower:
                GetWorldKnowledgeString(0,76);break;
            case GameWorldController.Worlds.Killorn:
                GetWorldKnowledgeString(1,77); break;
            case GameWorldController.Worlds.Ice:
                GetWorldKnowledgeString(2,78); break;
            case GameWorldController.Worlds.Talorus:
                GetWorldKnowledgeString(3,79); break;
            case GameWorldController.Worlds.Academy:
                GetWorldKnowledgeString(4,80); break;
            case GameWorldController.Worlds.Pits:
                GetWorldKnowledgeString(5,82); break;
            case GameWorldController.Worlds.Tomb:
                GetWorldKnowledgeString(6,81); break;
            case GameWorldController.Worlds.Ethereal:
                GetWorldKnowledgeString(7,83); break;
        }
    }

    /*
000~001~073~You are in 
000~001~074~an alternate dimension
000~001~075~Britannia
000~001~076~The Prison Tower
000~001~077~Killorn Keep
000~001~078~the Ice Caverns
000~001~079~Talorus
000~001~080~the Scintillus Academy Final Exam
000~001~081~the Tomb of Praecor Loth
000~001~082~the Pits of Carnage
000~001~083~the Ethereal Void
    */
    public static void GetWorldKnowledgeString(int index, int stringNo)
    {
        int questval = Quest.instance.QuestVariables[131];
        questval = (questval >> index) & 0x1;
        if (questval ==1)
        {
            UWHUD.instance.MessageScroll.Add(
                StringController.instance.GetString(1, 73) + StringController.instance.GetString(1, stringNo));
        }
        else
        {//Unknown alternate dimension
            UWHUD.instance.MessageScroll.Add(
                StringController.instance.GetString(1, 73) 
                + StringController.instance.GetString(1, 74)
                );
        }
    }

    private static void GetFedAndFatiqueStatus()
    {
        UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, StringController.str_you_are_currently_)
                + UWCharacter.Instance.GetFedStatus()
                                      + " and "
                + UWCharacter.Instance.GetFatiqueStatus());
    }

    private static void GetDurationOfQuest()
    {
        if (GameClock.day() < 10)
        {
            UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, StringController.str_it_is_the_)
                    + StringController.instance.GetString(1, 411 + GameClock.day())
                    + StringController.instance.GetString(1, StringController.str__day_of_your_imprisonment_));
        }
        else
        {//incountable
            UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, StringController.str_it_has_been_an_uncountable_number_of_days_since_you_entered_the_abyss_));
        }
    }

    private static void GuessTimeOfDay()
    {
        UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, StringController.str_you_guess_that_it_is_currently_)
                        + StringController.instance.GetString(1, StringController.str_night_1 + ((GameClock.hour()) / 2)));
    }

}
