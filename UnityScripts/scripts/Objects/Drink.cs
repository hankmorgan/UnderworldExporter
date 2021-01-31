using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Drink : Food {

    public override bool Eat()
    {
        int FoodValue = GameWorldController.instance.objDat.nutritionStats[item_id - 176].FoodValue;
        bool DrinkIsAlcoholic = false;
        int StringNo;



        //uw1 strings
            //000~001~237~The water refreshes you. \n
            //000~001~238~You drink the port. \n
            //000~001~239~You drink the dark ale. \n

        //uw2 strings
            //000~001~252~The water refreshes you. \n
            //000~001~253~You drink the wine. \n
            //000~001~254~You drink the dark ale. \n

        switch (_RES)
        {
            case GAME_UW2:
                switch(item_id)
                {
                    case 187: //ale
                        StringNo = 254;
                        DrinkIsAlcoholic = true;
                        break;
                    case 189://wine
                        StringNo = 253;
                        DrinkIsAlcoholic = true;
                        break;
                    default://water
                        StringNo = 252;
                        break;
                }
                break;
            default:
                switch (item_id)
                {
                    case 186: //ale
                        StringNo = 239;
                        DrinkIsAlcoholic = true;
                        break;
                    case 190://port
                        StringNo = 238;
                        DrinkIsAlcoholic = true;
                        break;
                    default://water
                        StringNo = 237;
                        break;
                }
                break;
        }

        UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, StringNo));

        if (DrinkIsAlcoholic)
        {
            UWCharacter.Instance.Intoxication -= FoodValue;
            if (UWCharacter.Instance.Intoxication > 63)
            {
                UWCharacter.Instance.Intoxication = 63;
            }

            //Do a skill check for drunkeness vs strength.
            Skills.SkillRollResult result = Skills.SkillRoll(UWCharacter.Instance.PlayerSkills.STR, UWCharacter.Instance.Intoxication);
            switch (result)
            {
                case Skills.SkillRollResult.CriticalFailure:

                    //clear intoxicaion.
                    UWCharacter.Instance.Intoxication = 0;
                    //Pass out drumk
                    //000~001~256~As the alcohol hits you, you stumble and collapse into sleep. \n
                    UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, StringController.str_as_the_alcohol_hits_you_you_stumble_and_collapse_into_sleep_));
                    //sleep
                    UWCharacter.Instance.Sleep();
                    //wake up unstable
                    UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, StringController.str_you_wake_feeling_somewhat_unstable_but_better_));
                    break;
                case Skills.SkillRollResult.CriticalSuccess:
                    //heal 2 points of health and you feel better.
                    UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, StringController.str_the_drink_makes_you_feel_a_little_better_for_now_));

                    UWCharacter.Instance.CurVIT = UWCharacter.Instance.CurVIT + 2;
                    if (UWCharacter.Instance.CurVIT > UWCharacter.Instance.MaxVIT)
                    {
                        UWCharacter.Instance.CurVIT = UWCharacter.Instance.MaxVIT;
                    }
                    break;
                default:
                    //screen shake
                    CameraShake.instance.ShakeCombat(0.5f);
                    break;
            }
        }
        else
        {//water Healing effect. (water should be 1 point (-1 in table)
            FoodValue = Mathf.Abs(FoodValue);
            UWCharacter.Instance.CurVIT +=FoodValue ;
            if (UWCharacter.Instance.CurVIT > UWCharacter.Instance.MaxVIT)
            {
                UWCharacter.Instance.CurVIT = UWCharacter.Instance.MaxVIT;
            }
            //Clear intoxication as well.
            UWCharacter.Instance.Intoxication = 0;
        }
        if (_RES == GAME_UW2)
        {//Some food items leave left overs
            LeftOvers();
        }
        objInt().consumeObject();//destroy and remove from inventory/world.
        return true;    
    }
}
