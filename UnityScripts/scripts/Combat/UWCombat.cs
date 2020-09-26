using UnityEngine;
using System.Collections;

public class UWCombat : Combat
{
    public static UWCombat instance;

    /// The melee weapon currently held by the player.
    public WeaponMelee currWeapon;
    /// The current ranged weapon held by the player
    public WeaponRanged currWeaponRanged;
    /// The inventory object that is to be launched in the next ranged attack. 
    private ObjectInteraction currentAmmo;

    ///What animation to play for this weapon swing
    private string CurrentStrike;

    private short CurrentStrikeAnimation;

    int DamageImpactStart
    {
        get
        {
            switch(_RES)
            {
                case GAME_UW2:
                    return 43;
                default:
                    return 46;
            }
        }
    }

    int DamageImpactEnd
    {
        get
        {
            switch (_RES)
            {
                case GAME_UW2:
                    return 47;
                default:
                    return 50;
            }
        }
    }

    private void Awake()
    {
        instance = this;
    }


    public override void PlayerCombatIdle()
    {
        base.PlayerCombatIdle();

        if ((AttackCharging == false) && (AttackExecuting == false))
        { ///If not charging an attack and not executing an attack it will check interaction mode.
			if ((UWCharacter.InteractionMode == UWCharacter.InteractionModeAttack))
            {///Sets the weapon, race and handedness of the weapon animation.
                if (IsMelee())
                {
                    UWHUD.instance.wpa.SetAnimation = GetWeaponOffset() + GetHandOffset() + 6;//For ready						
                }
            }
            else
            {///Or Hides the weapon by animating the player putting it away.
				UWHUD.instance.wpa.SetAnimation = -1; //"WeaponPutAway";
            }
        }
    }

    /// <summary>
    /// Begins the combat state of the player. Sets AttackCharging.
    /// Animates the weapon becoming ready.
    /// For ranged weaponry it checks for the weapon ammo.
    /// </summary>
    public override void CombatBegin()
    {
        chargeRate =10f * (GetWeaponSpeed() );

        if (IsMelee())
        {///If melee sets the proper weapon drawn back animation.
			CurrentStrike = GetStrikeType();
            CurrentStrikeAnimation = GetStrikeOffset();
            UWHUD.instance.wpa.SetAnimation = GetWeaponOffset() + CurrentStrikeAnimation + GetHandOffset() + 0; //charge
        }
        else
        {
            ///If ranged check for ammo as defined by the Weapon
            /// If ammo if found give the player a targeting crosshair
            currentAmmo = UWCharacter.Instance.playerInventory.findObjInteractionByID(currWeaponRanged.AmmoType());
            if ((currentAmmo == null) && (ObjectInteraction.Alias(currWeaponRanged.AmmoType()) != currWeaponRanged.AmmoType()))
            {//Ammo type has an alias. try and find that instead.
                currentAmmo = UWCharacter.Instance.playerInventory.findObjInteractionByID(ObjectInteraction.Alias(currWeaponRanged.AmmoType()));
            }
            if (currentAmmo == null)
            {//No ammo.
                UWHUD.instance.MessageScroll.Add("Sorry, you have no " + StringController.instance.GetObjectNounUW(currWeaponRanged.AmmoType()));
                return;
            }
            else
            {
                //Change the crosshair
                UWHUD.instance.CursorIcon = UWHUD.instance.CursorIconTarget;
            }
        }
        ///Starts the counter
        AttackCharging = true;
        Charge = 0;
    }

    /// <summary>
    /// Increases the Charge by the charge rate * Time.deltaTime.
    /// </summary>
    public override void CombatCharging()
    {//While still charging increase the charge by the charge rate.
        Charge = (Charge + (chargeRate * Time.deltaTime));
        if (Charge > 100)
        {
            Charge = 100;
        }
    }


    /// <summary>
    /// Executes the melee attack after the attack has been released.
    /// Casts a ray from the centre of the screen in mouselook mode or from the cursor position
    /// Waits a period of time after the release before casting the ray.
    /// </summary>
    public override IEnumerator ExecuteMelee(string StrikeType, float StrikeCharge)
    {
        yield return new WaitForSeconds(0.4f);

        Ray ray;
        if (UWCharacter.Instance.MouseLookEnabled == true)
        {
            ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        }
        else
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        }

        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit, weaponRange))
        {
            if (!hit.transform.Equals(this.transform))
            {
                ObjectInteraction objInt = hit.transform.gameObject.GetComponent<ObjectInteraction>();
                if (objInt != null)
                {
                    //Debug.Log("Hitting " + objInt.name);
                    switch (objInt.GetItemType())
                    {
                        case ObjectInteraction.NPC_TYPE:
                            PC_Hits_NPC(UWCharacter.Instance, currWeapon, CurrentStrike, StrikeCharge, objInt.GetComponent<NPC>(), hit);
                            break;
                        default:
                            Impact.SpawnHitImpact(Impact.ImpactDamage(), (ray.origin + hit.point) / 2f, DamageImpactStart, DamageImpactEnd);
                            objInt.Attack((short)GetPlayerBaseDamage(currWeapon, CurrentStrike), UWCharacter.Instance.gameObject);
                            break;
                    }
                }
                else
                {//Probably hit a wall or tile floor
                    Impact.SpawnHitImpact(Impact.ImpactDamage(), (ray.origin + hit.point) / 2f, DamageImpactStart, DamageImpactEnd);
                    if (currWeapon != null)
                    {
                        short durability = currWeapon.getDurability();
                        if (durability <= 30)
                        {
                            currWeapon.SelfDamage((short)(Mathf.Max(0, Random.Range(1, durability + 1) - durability)));
                        }
                    }

                    if (ObjectInteraction.PlaySoundEffects)
                    {
                        UWCharacter.Instance.aud.clip = MusicController.instance.SoundEffects[MusicController.SOUND_EFFECT_MELEE_MISS_1];
                        UWCharacter.Instance.aud.Play();
                    }
                }
            }
        }
        else
        {
            if (ObjectInteraction.PlaySoundEffects)
            {
                UWCharacter.Instance.aud.clip = MusicController.instance.SoundEffects[MusicController.SOUND_EFFECT_MELEE_MISS_1];
                UWCharacter.Instance.aud.Play();
            }
            if (currWeapon != null)
            {
                currWeapon.onHit(null);
            }
        }

        ///Ends the attack and wait for a period before allowing another action.
        AttackExecuting = false;
        UWHUD.instance.window.UWWindowWait(1.0f);

    }

    /// <summary>
    /// Execution of ranged attacks
    /// </summary>
    public override void ExecuteRanged(float charge)
    {
        base.ExecuteRanged(charge);

        ///Removes the cursor
        UWHUD.instance.CursorIcon = UWHUD.instance.CursorIconDefault;
        ///Launches the ammo using LaunchAmmo
        if (currentAmmo != null)
        {
            //currentAmmo.consumeObject ();
            LaunchAmmo(charge);
        }
    }

    /// <summary>
    /// Releases the attack.
    /// </summary>
    public override void ReleaseAttack()
    {
        if (UWHUD.instance.window.JustClicked == false)
        {
            if (IsMelee())
            {///Sets the weapon, race and handedness animation.
				if (CurrentStrike == "")
                {
                    CurrentStrike = GetStrikeType();
                }
                UWHUD.instance.wpa.SetAnimation = GetWeaponOffset() + CurrentStrikeAnimation + GetHandOffset() + 1;//exeute
                AttackExecuting = true;
                StartCoroutine(ExecuteMelee(CurrentStrike, Charge));
            }
            else
            {//Ranged attack
                ExecuteRanged(Charge);
            }
            ///Ends the attack.
            Charge = 0.0f;
            AttackCharging = false;
        }
    }


    /// <summary>
    /// Determines whether this current weapn is melee or ranged
    /// </summary>
    /// <returns><c>true</c> if this instance is melee; otherwise, <c>false</c>.</returns>
    public bool IsMelee()
    {//Is the player using a melee weapon.
        if (GetWeapon() == "Ranged")
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    /// <summary>
    /// Gets the weapon type
    /// One of sword, axe, mace or fist for melee
    /// or Ranged for ranged weapons
    /// </summary>
    /// <returns>The weapon.</returns>
    public string GetWeapon()
    {
        if (currWeapon != null)
        {
            switch (currWeapon.GetSkill())
            {
                case 3:
                    return "Sword";
                case 4:
                    return "Axe";
                case 5:
                    return "Mace";
                default:
                    return "Fist";
            }
        }
        else
        {
            if (currWeaponRanged != null)
            {
                return "Ranged";
            }
            else
            {
                return "Fist";
            }
        }
    }

    public short GetWeaponOffset()
    {
        if (currWeapon != null)
        {
            switch (currWeapon.GetSkill())
            {
                case 3:
                    return 0;
                case 4:
                    return 7;
                case 5:
                    return 14;
                default:
                    return 21;
            }
        }
        else
        {
            if (currWeaponRanged != null)
            {
                return -1;
            }
            else
            {
                return 21;
            }
        }
    }

    /// <summary>
    /// Gets the race of the charcter for displaying their skin colour based on the Body variable of UWCharacter
    /// </summary>
    /// <returns>The race.</returns>
    public string GetRace()
    {
        switch (UWCharacter.Instance.Body)
        {
            case 0:
            case 2:
            case 3:
            case 4:
                return "White";
            default:
                return "Black";
        }
    }

    /// <summary>
    /// Gets the handedness of the character
    /// </summary>
    /// <returns>The hand.</returns>
    public string GetHand()
    {
        if (UWCharacter.Instance.isLefty)
        {
            return "Left";
        }
        else
        {
            return "Right";
        }
    }

    public short GetHandOffset()
    {
        if (UWCharacter.Instance.isLefty)
        {
            return 28;
        }
        else
        {
            return 0;
        }
    }

    /// <summary>
    /// Gets the type of the strike based on where the mouse cursor is located on the Y axis of the viewport.
    /// Returns one of Bash, Slash or Stab
    /// </summary>
    /// <returns>The strike type.</returns>
    public string GetStrikeType()
    {
        if (!UWCharacter.Instance.MouseLookEnabled)
        {
            if (Camera.main.ScreenToViewportPoint(Input.mousePosition).y > 0.666f)
            {
                return "Bash";
            }
            else if (Camera.main.ScreenToViewportPoint(Input.mousePosition).y > 0.333f)
            {
                return "Slash";
            }
            else
            {
                return "Stab";
            }
        }
        else
        {
            switch (Random.Range(1, 4))
            {
                case 1:
                    return "Bash";
                case 2:
                    return "Slash";
                case 3:
                default:
                    return "Stab";
            }
        }

    }

    public short GetStrikeOffset()
    {
        if (!UWCharacter.Instance.MouseLookEnabled)
        {
            if (Camera.main.ScreenToViewportPoint(Input.mousePosition).y > 0.666f)
            {
                return 2;//bash
            }
            else if (Camera.main.ScreenToViewportPoint(Input.mousePosition).y > 0.333f)
            {
                return 0;//Slash
            }
            else
            {
                 return 4;//stab
            }
        }
        else
        {
            switch (Random.Range(1, 4))
            {
                case 1:
                    return 2;
                case 2:
                    return 4;
                case 3:
                default:
                    return 0;
            }
        }

    }


    /// <summary>
    /// Get how fast the attack charge builds up on the weapon.
    /// </summary>
    /// <returns></returns>
    public float GetWeaponSpeed()
    {
        if (currWeapon != null)
        {
            return (float)GameWorldController.instance.objDat.weaponStats[currWeapon.item_id].WeaponSpeed;
        }
        else
        {//a fist
            return (float)GameWorldController.instance.objDat.weaponStats[15].WeaponSpeed;
        }
    }


    /// <summary>
    /// Launchs the ammo.
    /// </summary>
    /// <returns><c>true</c>, if ammo was launched, <c>false</c> otherwise.</returns>
    bool LaunchAmmo(float charge)
    {
        if (currentAmmo != null)
        {
            Ray ray;
            if (UWCharacter.Instance.MouseLookEnabled == true)
            {
                ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            }
            else
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            }

            RaycastHit hit = new RaycastHit();
            float dropRange = 0.5f;
            if (!Physics.Raycast(ray, out hit, dropRange))
            {///Checks No object interferes with the launch
				float force = 1000.0f * (charge / 100.0f);
                GameObject launchedItem;
                if (currentAmmo.GetQty() == 1)
                {
                    launchedItem = currentAmmo.gameObject;
                    UWCharacter.Instance.playerInventory.RemoveItem(currentAmmo);
                    //launchedItem.transform.parent=GameWorldController.instance.DynamicObjectMarker();
                    GameWorldController.MoveToWorld(launchedItem);
                    launchedItem.transform.position = ray.GetPoint(dropRange - 0.1f);
                }
                else
                {//reduce this quantity by one and create a copy in the world
                    ObjectLoaderInfo newobjt = ObjectLoader.newObject(currWeaponRanged.AmmoType(), 40, 0, 1, 256);
                    launchedItem = ObjectInteraction.CreateNewObject(CurrentTileMap(), newobjt, CurrentObjectList().objInfo, GameWorldController.instance.DynamicObjectMarker().gameObject, ray.GetPoint(dropRange - 0.1f)).gameObject;
                    currentAmmo.consumeObject();
                }
                launchedItem.GetComponent<ObjectInteraction>().isquant = 1;
                UnFreezeMovement(launchedItem);
                Vector3 ThrowDir = ray.GetPoint(dropRange) - ray.origin;

                ///Apply the force along the direction of the ray that the player has targetted along.
                launchedItem.GetComponent<Rigidbody>().AddForce(ThrowDir * force);
                GameObject myObjChild = new GameObject(launchedItem.name + "_damage");
                myObjChild.transform.position = launchedItem.transform.position;
                myObjChild.transform.parent = launchedItem.transform;
                ///Appends ProjectileDamage to the projectile to act as the damage delivery method.
                ProjectileDamage pd = myObjChild.AddComponent<ProjectileDamage>();
                pd.Source = UWCharacter.Instance.gameObject;
                pd.Damage = (short)currWeaponRanged.Damage(); //   (short)(10.0f*(Charge/100.0f));
                pd.AttackCharge = charge;
                pd.AttackScore = UWCharacter.Instance.PlayerSkills.GetSkill(Skills.SkillAttack) / 2 + UWCharacter.Instance.PlayerSkills.GetSkill(Skills.SkillMissile);
                return true;
            }
            else
            {
                return false;
            }

        }
        else
        {//No ammo?? Should not happen
            return false;
        }
    }

    //Combat calcs

    /// <summary>
    /// Calculate the attack charge to be applied to player attack damage.
    /// </summary>
    /// <param name="Strikecharge"></param>
    /// <param name="MinCharge"></param>
    /// <param name="MaxCharge"></param>
    /// <param name="BaseDamage"></param>
    public static short CalcAttackChargeDamage(short Strikecharge, short MinCharge, short MaxCharge, short BaseDamage)
    {
        short result;
        result = (short)(MaxCharge - MinCharge);
        result = (short)((result * Strikecharge) / 100);
        result = (short)(MinCharge + result);
        result = (short)((BaseDamage*result) >> 7);
        return result;
    }


    /// <summary>
    /// In UW2 damage seems to be divided by 6 and in that many times a 1-6 damage roll is ran. If there is a remainder then a 1-remainder damage roll is made
    /// </summary>
    /// <param name="NoOfRolls"></param>
    /// <param name="Die"></param>
    /// <returns></returns>
    public static short DamageRoll(short NoOfRolls, short Die)
    {
        short result = 0;
        if (Die == 0 || NoOfRolls == 0)
        {
            return 0;
        }
        for (int i =0; i<NoOfRolls;i++)
        {
            result += (short)Random.Range(1, Die + 1);
        }
        return result;
    }

    /// <summary>
    /// Calculates a flat bonus to attack score and attack damage based on the relative headings of the attacker and defender
    /// </summary>
    /// <param name="attacker"></param>
    /// <param name="defender"></param>
    /// <returns></returns>
    public static int CalcFlankingBonus(int attacker, int defender)
    {
        int result = defender - attacker;
        if (result < 0) { result = 8 + result; }
        if (result > 4) { result = 8 - result; }
        return result;
    }


    /// <summary>
    /// Combat calculations for PC hitting an NPC
    /// </summary>
    /// <param name="playerUW">Player Character</param>
    /// <param name="npc">Npc.</param>
    /// <param name="hit">Hit.</param>
    public static void PC_Hits_NPC(UWCharacter playerUW, WeaponMelee currentWeapon, string StrikeName, float StrikeCharge, NPC npc, RaycastHit hit)
    {

        int attackScore = 0;

        int flankingbonus = 0; //need to calcu but depending on relative headings between attacker and defender.
        int magicbonus = 0;//currently unknown what provides this but is calculated by casting/5 + 0xA when set.
        short MinCharge;
        short MaxCharge;

        if (npc != null)
        {
            //recalc position to get the correct heading for the flanking bonus
            npc.objInt().UpdatePosition();
            flankingbonus = CalcFlankingBonus(playerUW.currentHeading, npc.objInt().heading);
        }


        if (currentWeapon != null)
        {
            attackScore = (playerUW.PlayerSkills.GetSkill(Skills.SkillAttack) >> 1) + playerUW.PlayerSkills.GetSkill(currentWeapon.GetSkill()) + (playerUW.PlayerSkills.DEX / 7) + magicbonus + flankingbonus;
            if (GameWorldController.instance.difficulty == 0)
            {//bonus of 7 for easy difficulty
                attackScore += 7;
            }
            attackScore += currentWeapon.AccuracyBonus();//Given by the accuracy enchantments. Note in vanilla UW2 accuracy actually increases damage and not attack score. This is fixed here.

            MinCharge = currentWeapon.GetMinCharge();
            MaxCharge = currentWeapon.GetMaxCharge();
        }
        else
        {

            //use the unarmed calculations
            attackScore = (playerUW.PlayerSkills.GetSkill(Skills.SkillAttack) >> 1) + playerUW.PlayerSkills.GetSkill(Skills.SkillUnarmed) + (playerUW.PlayerSkills.DEX / 7) + magicbonus + flankingbonus;
            if (GameWorldController.instance.difficulty == 0)
            {//bonus of 7 for easy difficulty
                attackScore += 7;
            }
            MinCharge = WeaponMelee.GetMeleeMinCharge();
            MaxCharge = WeaponMelee.GetMeleeMaxCharge();
        }


        //Get base damage 
        int BaseSwingDamage = GetPlayerBaseDamage(currentWeapon, StrikeName);
        int basePower = (short)(GameWorldController.instance.objDat.critterStats[63].Strength / 9); //the player is actually a critter so power in this case is their STR.
        int WeaponBonusDamage = 0;
        if (currentWeapon != null)
        {
            WeaponBonusDamage = currentWeapon.DamageBonus();
        }
        else
        {//unarmed
            basePower = (short)(GameWorldController.instance.objDat.critterStats[63].Strength / 6); //the player is actually a critter so power in this case is their STR.
            basePower += (playerUW.PlayerSkills.GetSkill(Skills.SkillUnarmed) / 5);
        }


        //scale base damage by charge. Min damage is always 2.
        short Damage = (short)(basePower + BaseSwingDamage + WeaponBonusDamage);

        // damage % 6 no of 1D6s to calculate the actual damage and then add the remainder as a final roll 1-remainder
        Damage = (short)(DamageRoll((short)(Damage / 6), 6) + DamageRoll(1, (short)(Damage % 6)));

        //Damage is scaled by the amount of weapon charge built up.
        Damage = CalcAttackChargeDamage((short)StrikeCharge, MinCharge, MaxCharge, Damage);

        //And a flat flanking bonus 
        Damage += (short)flankingbonus;

        //Min damage will be 2.
        Damage = (short)(Mathf.Max(Damage, 2));

        Skills.SkillRollResult rollresult = Skills.SkillRoll(attackScore, npc.Defence());

        bool CriticalHit = RollForCritDamage(ref Damage, rollresult);
        switch (rollresult)
        {
            case Skills.SkillRollResult.CriticalSuccess:
            case Skills.SkillRollResult.Success:
                {
                    Debug.Log("Base Damage = " + ((short)(basePower + BaseSwingDamage + WeaponBonusDamage)) + " Final Damage = " + Damage);
                    if (CriticalHit)
                    {
                        Impact.SpawnHitImpact(Impact.ImpactBlood(), npc.GetImpactPoint() + Vector3.up * 0.1f, npc.objInt().GetHitFrameStart(), npc.objInt().GetHitFrameEnd());
                    }
                    npc.ApplyAttack(Damage, playerUW.gameObject);
                    Impact.SpawnHitImpact(Impact.ImpactBlood(), npc.GetImpactPoint(), npc.objInt().GetHitFrameStart(), npc.objInt().GetHitFrameEnd());
                    if (currentWeapon != null)
                    {///Performs the onHit action of the melee weapon.
                        currentWeapon.onHit(hit.transform.gameObject);
                    }
                    break;
                }

            case Skills.SkillRollResult.Failure:
                npc.ApplyAttack(0, playerUW.gameObject);
                npc.npc_aud.PlayCombatMissed();
                break;
            case Skills.SkillRollResult.CriticalFailure:
                {
                    npc.ApplyAttack(0, playerUW.gameObject);
                    npc.npc_aud.PlayCombatMissed();
                    //Damage weapon
                    short durability = currentWeapon.getDurability();
                    if (durability <= 30)
                    {
                        currentWeapon.SelfDamage((short)Mathf.Max(0, Random.Range(0, npc.EquipDamage + 1) - durability));
                    }
                    break;
                }
        }
    }


    /// <summary>
    /// Calculate any possible critical hit/damage.
    /// </summary>
    /// <param name="Damage"></param>
    /// <param name="rollresult"></param>
    /// <returns></returns>
    private static bool RollForCritDamage(ref short Damage, Skills.SkillRollResult rollresult)
    {
        bool CriticalHit = false;
        if (rollresult == Skills.SkillRollResult.CriticalSuccess)
        {
            //based on dissasembly a crit is a 50:50 chance after the critical roll is scored

            //seems to be a 50:50 chance for a crit which gives double damage.
            //(48+(rng 0-30)) >>5
            int crit = (48 + Random.Range(0, 31) >> 5);
            Damage = (short)(Damage * crit);
            CriticalHit = true;
        }

        return CriticalHit;
    }
    
    /// <summary>
    /// NPC hits player
    /// </summary>
    /// <param name="playerUW">Player U.</param>
    /// <param name="npc">Npc.</param>
    public static void NPC_Hits_PC(UWCharacter playerUW, NPC npc)
     {
        int flankingbonus = 0;
        flankingbonus = CalcFlankingBonus(npc.objInt().heading, playerUW.currentHeading);
        int attackScore = npc.CurrentAttackScore + (npc.EquipDamage >> 1) + Random.Range(0, 5) + 7 + flankingbonus; //+Maybe Npc Level

        //Player defence
        //defence skill + sum of all armour+(skill with current weapon >>1) + unknownbonus(stored in critterdata)
        int DefenderScore = playerUW.PlayerSkills.GetSkill(Skills.SkillDefense) + playerUW.playerInventory.ArmourProtection;   
        if (playerUW.PlayerCombat.currWeapon != null)
        {
            DefenderScore += (playerUW.PlayerSkills.GetSkill(playerUW.PlayerCombat.currWeapon.GetSkill())>>1);
        }
        else
        {
            DefenderScore += (playerUW.PlayerSkills.GetSkill(Skills.SkillUnarmed) >> 1);
        }    

        Skills.SkillRollResult rollresult = Skills.SkillRoll(attackScore, DefenderScore);
        if ((_RES == GAME_UW1) && (npc.item_id == 124) && (rollresult == Skills.SkillRollResult.CriticalFailure || rollresult == Skills.SkillRollResult.Failure))
        {
            rollresult = Skills.SkillRollResult.Success;//Slasher of veils will always hit.
        }

        short Damage = 0;
        Damage = (short)(npc.CurrentAttackDamage + (npc.Strength / 5));
        Damage = (short)Mathf.Max(Damage, 2);
        int baseDamage = Damage;

        bool CriticalHit = RollForCritDamage(ref Damage, rollresult);
        // damage % 6 no of 1D6s to calculate the actual damage and then add the remainder as a final roll 1-remainder
        Damage = (short)(DamageRoll((short)(Damage / 6), 6) + DamageRoll(1, (short)(Damage % 6)));


        //TODO: damage for NPCS is scaled based on a lookup table and a property in their mobile data. This is similar to the player attack charge. (values stored in segment_60 in UW2 exe)
        //Lookup appears to be based on the value in the object at 0xF ( bits 12 to 15)
        //For now just scale it randomly
        Damage = (short)Random.Range(2, Damage + 1);

        switch (rollresult)
        {
            case Skills.SkillRollResult.CriticalSuccess:
            case Skills.SkillRollResult.Success:
                {
                    Debug.Log("Base Damage = " + (short)(baseDamage) + " Final Damage = " + Damage);
                    playerUW.ApplyDamage(Damage, npc.gameObject);

                    //TODO: restore equipment damage and poisoning.

                    //Ten more seconds of combat music
                    MusicController.LastAttackCounter = 10.0f; 
                    if (ObjectInteraction.PlaySoundEffects)
                    {
                        UWCharacter.Instance.aud.clip = MusicController.instance.SoundEffects[MusicController.SOUND_EFFECT_MELEE_HIT_1];
                        UWCharacter.Instance.aud.Play();
                    }
                    break;
                }
            case Skills.SkillRollResult.Failure:
            case Skills.SkillRollResult.CriticalFailure:
                //a miss.
                break;
        }


            ////////    int PlayerDefence = 0;
            ////////    if (playerUW.PlayerCombat.currWeapon != null)
            ////////    {
            ////////        PlayerDefence = playerUW.PlayerSkills.GetSkill(Skills.SkillDefense) + (playerUW.PlayerSkills.GetSkill(playerUW.PlayerCombat.currWeapon.GetSkill() + 1) / 2);
            ////////    }
            ////////    else
            ////////    {
            ////////        PlayerDefence = playerUW.PlayerSkills.GetSkill(Skills.SkillDefense) + (playerUW.PlayerSkills.GetSkill(Skills.SkillUnarmed) / 2);
            ////////    }
            ////////    int toHit = Mathf.Max(PlayerDefence - npc.Dexterity, 0);
            ////////    int roll = Random.Range(-1, 31);
            ////////    if ((_RES == GAME_UW1) && (npc.item_id == 124))
            ////////    {
            ////////        roll = 30;//Slasher will always hit.
            ////////    }
            ////////    int BaseDamage = npc.CurrentAttackDamage;//get the damage of the current attack
            ////////    if (((roll >= toHit) || (roll >= 30)) && (roll > -1))
            ////////    {
            ////////        int PlayerArmourScore = playerUW.playerInventory.getArmourScore();
            ////////        int ReducedDamage = Mathf.Max(1, BaseDamage - PlayerArmourScore);
            ////////        //Hit
            ////////        playerUW.ApplyDamage(Random.Range(1, ReducedDamage + 1), npc.gameObject);
            ////////        //reduce damage by protection
            ////////        if (BaseDamage > PlayerArmourScore)
            ////////        {
            ////////            //apply equipment damage to a random piece of armour
            ////////            playerUW.playerInventory.ApplyArmourDamage((short)Random.Range(0, npc.ArmourDamage + 1));
            ////////        }
            ////////        if (npc.PoisonLevel() > 0)
            ////////        {//roll for poisoning.
            ////////            if (!UWCharacter.Instance.isPoisonResistant())
            ////////            {//Player has resistence against poisoning
            ////////                int PoisonRoll = Random.Range(1, 30);
            ////////                if (PoisonRoll < npc.PoisonLevel())
            ////////                {
            ////////                    int PoisonToAdd = Random.Range(1, npc.PoisonLevel() + 1);
            ////////                    int newPlayPoison = (short)Mathf.Min(playerUW.play_poison + PoisonToAdd, 15);
            ////////                    UWCharacter.Instance.play_poison = (short)newPlayPoison;
            ////////                    if (UWCharacter.Instance.poison_timer == 0)
            ////////                    {
            ////////                        UWCharacter.Instance.poison_timer = 30f;
            ////////                    }
            ////////                }
            ////////            }

            ////////        }

            ////////        MusicController.LastAttackCounter = 10.0f; //Ten more seconds of combat music
            ////////        if (ObjectInteraction.PlaySoundEffects)
            ////////        {
            ////////            UWCharacter.Instance.aud.clip = MusicController.instance.SoundEffects[MusicController.SOUND_EFFECT_MELEE_HIT_1];
            ////////            UWCharacter.Instance.aud.Play();
            ////////        }
            ////////    }
        }

    /// <summary>
    /// NPC hits another NPC
    /// </summary>
    /// <param name="targetNPC">Target NP.</param>
    /// <param name="originNPC">Origin NP.</param>
    public static void NPC_Hits_NPC(NPC targetNPC, NPC originNPC)
    {
        //TODO: update with above calculations.
        
        int Defence = targetNPC.Defence();
        int Attack = originNPC.Dexterity;
        int toHit = Mathf.Max(Defence - Attack, 1);
        int roll = Random.Range(-1, 31);
        int BaseDamage = Random.Range(1, originNPC.CurrentAttackDamage + 1);
        if (((roll >= toHit) || (roll >= 30)) && (roll > -1))
        {
            targetNPC.ApplyAttack((short)BaseDamage, originNPC.gameObject);
            Impact.SpawnHitImpact(Impact.ImpactBlood(), targetNPC.GetImpactPoint(), targetNPC.objInt().GetHitFrameStart(), targetNPC.objInt().GetHitFrameEnd());
            if (ObjectInteraction.PlaySoundEffects)
            {
                originNPC.objInt().aud.clip = MusicController.instance.SoundEffects[MusicController.SOUND_EFFECT_MELEE_HIT_1];
                originNPC.objInt().aud.Play();
            }
        }
    }


    public static int GetPlayerBaseDamage(WeaponMelee currentWeapon, string StrikeName)
    {
        int BaseDamage = 1;
        if (currentWeapon != null)
        {
            switch (StrikeName)
            {
                case "SLASH":
                    BaseDamage = currentWeapon.GetSlash(); break;
                case "BASH":
                    BaseDamage = currentWeapon.GetBash(); break;
                case "STAB":
                default:
                    BaseDamage = currentWeapon.GetStab(); break;
            }
        }
        else
        {
            switch (StrikeName)
            {
                case "SLASH":
                    BaseDamage = WeaponMelee.getMeleeSlash(); break;
                case "BASH":
                    BaseDamage = WeaponMelee.getMeleeBash(); break;
                case "STAB":
                default:
                    BaseDamage = WeaponMelee.getMeleeStab(); break;
            }
        }
        return BaseDamage;
    }

    static int GetHitSound()
    {
        if (instance.currWeapon!=null)
        {
            return Random.Range(7, 9);
        }
        else
        {
            return Random.Range(3, 5);//Punch sounds.
        }
    }
}