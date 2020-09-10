using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class CardStats : MonoBehaviour
{
    public SkillCard card;
    public Unit playerUnit;
    public Unit enemyUnit;

    public new string name;

    public double baseArmour;
    public double basePhysicalDamage;
    public double baseFireDamage;
    public double baseColdDamage;
    public double baseLightningDamage;
    public int baseManaCost;
    public double baseCritChance = 5;
    public double baseCritMulti = 1.5;
    public double baseLifeLeech;
    public double baseDamageOverTime;
    public double baseNumOfAttacks = 1;
    public double totalNumOfAttacks;
    public bool didCrit;
    public double baseChanceToFreeze = 0;
    public double baseChanceToShock = 0;
    public double baseChanceToIgnite = 0;
    public double baseShockEffectiveness;
    public int baseTurnsIgnited;

    public bool didFreeze;
    public bool didShock;
    public bool didIgnite;

    public string cardType;
    public string advancedMod1;
    public string advancedMod2;
    public string advancedMod3;
    public string advancedMod4;
    public string advancedMod5;
    public string advancedMod6;

    public double totalIgniteDamage;

    public bool descriptionHasBeenInstantiated;

    void Start()
    {
        name = card.name;
        didCrit = false;
        didFreeze = false;
        cardType = card.cardType;
        baseArmour = card.baseArmour;
        basePhysicalDamage = card.basePhysicalDamage;
        baseFireDamage = card.baseFireDamage;
        baseColdDamage = card.baseColdDamage;
        baseLightningDamage = card.baseLightningDamage;
        baseManaCost = card.baseManaCost;
        baseCritChance = card.baseCritChance;
        baseCritMulti = card.baseCritMulti;
        baseLifeLeech = card.baseLifeLeech;
        baseDamageOverTime = card.baseDamageOverTime;
        baseNumOfAttacks = card.baseNumOfAttacks;
        baseChanceToFreeze = card.baseChanceToFreeze;
        baseChanceToShock = card.baseChanceToShock;
        baseChanceToIgnite = card.baseChanceToIgnite;
        baseShockEffectiveness = 1.5;
        baseTurnsIgnited = 3;

        advancedMod1 = card.advancedMod1;
        advancedMod2 = card.advancedMod2;
        advancedMod3 = card.advancedMod3;
        advancedMod4 = card.advancedMod4;
        advancedMod5 = card.advancedMod5;
        advancedMod6 = card.advancedMod6;

        descriptionHasBeenInstantiated = false;

        //totalNumOfAttacks = baseNumOfAttacks + playerUnit.numOfAttacks.GetValue();  i need to add a reference to player unit with the player manager

        //continue this tomorrow
    }

    public double CalculatedTotalSpellDamage(Unit playerUnit, Unit enemyUnit)
    {
        
        //double totalSpellDamage = playerUnit.fireDamage.GetValue() + baseFireDamage;

        double fireMulti = playerUnit.fireDamage.GetValue() / 100; //get fire multi
        double totalFireDamage = baseFireDamage * (1 + fireMulti); //base  * (fire multi)

        double coldMulti = playerUnit.coldDamage.GetValue() / 100;
        double totalColdDamage = baseColdDamage * (1 + coldMulti);

        double lightningMulti = playerUnit.lightningDamage.GetValue() / 100;
        double totalLightningDamage = baseLightningDamage * (1 + lightningMulti);

        double physicalMulti = playerUnit.physicalDamage.GetValue() / 100;
        double totalPhysicalDamage = basePhysicalDamage * (1 + physicalMulti);

        if (name == "Shield Slam")
        {
            totalPhysicalDamage = playerUnit.currentArmour;
        }

        double totalSpellDamage = totalFireDamage + totalColdDamage + totalLightningDamage + totalPhysicalDamage; // + totalColdDamage + totalLightningDamage + critDamage;

       
        #region CheckFreeze
        //check if freeze is succesful
        double randomFreezeValue = Random.Range(0, 100);
        double freezeChanceToDec = playerUnit.chanceToFreeze.GetValue() / 100;
        if (randomFreezeValue < baseChanceToFreeze * (1 + freezeChanceToDec))
        {
            didFreeze = true;
            Debug.Log(didFreeze + "did freeze");
            enemyUnit.isFrozen = true;
        }
        #endregion

        #region CheckShock
        //check if freeze is succesful
        double randomShockValue = Random.Range(0, 100);
        double shockChanceToDec = playerUnit.chanceToShock.GetValue() / 100;
        double increasedShockEffectiveness = playerUnit.shockEffectiveness.GetValue() / 100;

        if (enemyUnit.isShocked == true)
        {
            totalSpellDamage = totalSpellDamage * (baseShockEffectiveness * (1 + increasedShockEffectiveness));
            Debug.Log(didShock + "enemy unit is shcoked");
        }

        if (randomShockValue < baseChanceToShock * (1 + shockChanceToDec))
        {
            didShock = true;
            Debug.Log(didShock + "did Shock");
            enemyUnit.isShocked = true;
            
        }
        #endregion

        

        #region CheckCrit
        //check if crit is succesful 
        double randomCritValue = Random.Range(0, 100);
        double critChanceToDec = playerUnit.critChance.GetValue() / 100;
        double critMultiToDec = playerUnit.critMulti.GetValue() / 100;

        if (randomCritValue < baseCritChance * (1 + critChanceToDec))
        {
            totalSpellDamage = totalSpellDamage * (baseCritMulti * (1 + critMultiToDec));
            didCrit = true;
        }
        else
        {
            didCrit = false;
        }
        #endregion


        #region CheckIgnite
        //check if freeze is succesful
        double randomIgniteValue = Random.Range(0, 100);
        double igniteChanceToDec = playerUnit.chanceToIgnite.GetValue() / 100;
        if (randomIgniteValue < baseChanceToIgnite * (1 + igniteChanceToDec))
        {
            didIgnite = true;
            Debug.Log(didIgnite + "did ignite");
            enemyUnit.isIgnited = true;
            totalIgniteDamage = enemyUnit.GetIgniteDamage(totalSpellDamage, baseTurnsIgnited);
        }
        #endregion

        #region SubtractDamageFromArmour
        double damageBeforeArmour = totalSpellDamage;
        totalSpellDamage = totalSpellDamage - enemyUnit.currentArmour;

        enemyUnit.currentArmour = enemyUnit.currentArmour - damageBeforeArmour;

        if (enemyUnit.currentArmour < 0)
        {
            enemyUnit.currentArmour = 0;
        }
        #endregion

        return totalSpellDamage;
    }


    public double CalculateArmour(Unit playerUnit, Unit enemyUnit)
    {
        double armourMulti = playerUnit.armour.GetValue() / 100;
        double totalArmour = baseArmour * (1 + armourMulti);

        return totalArmour;
    }

}
