using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class SkillCard : ScriptableObject
{
    public new string name;

    public string description;
    public string cardType;
    public Sprite artwork;
    
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
    public double baseChanceToFreeze = 25;
    public double baseChanceToShock = 25;
    public double baseChanceToIgnite = 25;

    public string advancedMod1;
    public string advancedMod2;
    public string advancedMod3;
    public string advancedMod4;
    public string advancedMod5;
    public string advancedMod6;

    public void DisplayAdvancedInfo()
    {
        //Debug.Log(name + " " + description + "Cost " + baseManaCost); //later on display crit chance multi etc.
    }


    

}
