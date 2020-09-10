using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStats : MonoBehaviour
{
    public SkillCard card;

    public double baseArmour;
    public double basePhysicalDamage;
    public double baseFireDamage;
    public double baseColdDamage;
    public double baseLightningDamage;
    public int baseManaCost;
    public double baseCritChance;
    public double baseCritMulti;
    public double baseLifeLeech;
    public double baseDamageOverTime;

    void Start()
    {
        baseArmour = card.baseArmour;
        basePhysicalDamage = card.basePhysicalDamage;
        baseFireDamage = card.baseFireDamage;
        baseColdDamage = card.baseColdDamage;
        baseManaCost = card.baseManaCost;
        //continue this tomorrow
    }

}
