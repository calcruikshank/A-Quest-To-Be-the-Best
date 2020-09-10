using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int unitLevel;

    public bool hasDied = false;

    public double maxLife;
    public double currentLife { get; set; }
    public Stat physicalDamage;
    public Stat fireDamage;
    public Stat armour;
    public Stat fireResistance;
    public Stat coldRes;
    public Stat lightningRes;
    public Stat coldDamage;
    public Stat lightningDamage;
    public Stat critChance;
    public Stat critMulti;
    public Stat maxLifeMod;
    public Stat maxMana;
    public Stat leech;
    public Stat lifeGainedOnHit;
    public Stat chanceToIgnite;
    public Stat chanceToFreeze;
    public Stat chanceToShock;
    public Stat lightningPen;
    public Stat coldPen;
    public Stat firePen;
    public Stat manaGainedOnHit;
    public Stat critChanceWithFire;
    public Stat critChanceWithCold;
    public Stat critChanceWithLightning;
    public Stat numOfAttacks;
    public bool isFrozen = false;
    public bool isShocked = false;
    public bool isIgnited = false;
    public double currentArmour;
    public double damageBeforeArmour;
    public Stat shockEffectiveness;
    

    public bool arcaneLibrary = false;
    public bool hasThorns;
    public int numOfThorns;
    public int numOfTurnsIgnited;

    public double damageTakenFromIgnite;
    //spublic double totalDamage;
    public int maximumMana = 3;
    public int currentMana { get; set; }
    //public int level;

    void Awake()
    {
        currentLife = maxLife;
        currentMana = maximumMana;
    }

    public void Start()
    {
        //maxLife = 100;
        currentArmour = 0;
    }
  

    

    public void TakeDamage(double totalDamage)
    {
        //totalDamage -= armour.GetValue();

        if (totalDamage < 0)
        {
            totalDamage = 0;
        }

        currentLife -= totalDamage;
        //Debug.Log(transform.name + " takes " + totalDamage);

        if (currentLife <= 0)
        {

            Die();
        }
    }

    public virtual void Die()
    {
        //override
        //Debug.Log(transform.name + " died");


        hasDied = false;
}

    public void TakeDamageSpell(GameObject cardBeingCast, double totalSpellDamage)
    {
        GameObject card = cardBeingCast.transform.GetChild(1).gameObject; //this will convert the card posiiton parent to the correct card child 
        CardStats cardStats = card.GetComponent<CardStats>(); //then this gets the component card stats god damn im good
                                                              //double totalSpellDamage = cardStats.baseFireDamage + physicalDamage;
                                                              //totalDamage -= armour.GetValue();


        //destroy cardbeingcast for now but later change it so it goes into graveyard
        //Destroy(cardBeingCast);


        if (totalSpellDamage < 0)
        {
            totalSpellDamage = 0;
        }

        currentLife -= totalSpellDamage;
        Debug.Log(transform.name + " takes " + totalSpellDamage);

        if (currentLife <= 0)
        {
            Die();
        }
    }

    public double CalculateTotalDamage(Unit currentUnitTakingDamage)//this is for when the enemy attacks the player
    {
        double totalPhysDamage = physicalDamage.GetValue(); //has to pass in current unit

        double fireResistanceMulti = (100 - currentUnitTakingDamage.fireResistance.GetValue()) / 100;
        double totalFireDamage = fireDamage.GetValue() * fireResistanceMulti;

        double totalDamage = totalFireDamage + totalPhysDamage;

        damageBeforeArmour = totalDamage;
        totalDamage = totalDamage - currentUnitTakingDamage.currentArmour;

        currentUnitTakingDamage.currentArmour = currentUnitTakingDamage.currentArmour - damageBeforeArmour;
        if (currentUnitTakingDamage.currentArmour < 0)
        {
            currentUnitTakingDamage.currentArmour = 0;
        }
        
        return totalDamage;
        
    }

    public void TakeThornDamage(double totalThornDamage, Unit currentUnitTakingDamage)
    {
        if (totalThornDamage < 0)
        {
            totalThornDamage = 0;
        }
        
        double damageTakenFromThorns = totalThornDamage * 3;
        damageBeforeArmour = damageTakenFromThorns;
        damageTakenFromThorns = damageTakenFromThorns - currentUnitTakingDamage.currentArmour;
        currentUnitTakingDamage.currentArmour = currentUnitTakingDamage.currentArmour - damageBeforeArmour;

        if (currentUnitTakingDamage.currentArmour < 0)
        {
            currentUnitTakingDamage.currentArmour = 0;
        }

        if (damageTakenFromThorns < 0)
        {
            damageTakenFromThorns = 0;
        }

        currentLife -= damageTakenFromThorns;
    }

    public void GainArmour(double totalArmour)
    {
        currentArmour = currentArmour + totalArmour;
        Debug.Log(currentArmour + " current Armour");
    }

    public void TakeIgniteDamage(Unit currentUnitTakingDamage)
    {
        


        if (currentUnitTakingDamage.numOfTurnsIgnited <= 0)
        {
            currentUnitTakingDamage.numOfTurnsIgnited = 0;
            currentUnitTakingDamage.isIgnited = false;
        }

        if (currentUnitTakingDamage.numOfTurnsIgnited > 0)
        {
            currentLife -= damageTakenFromIgnite;
            currentUnitTakingDamage.numOfTurnsIgnited--;
            Debug.Log("total damage from ignite this turn " + damageTakenFromIgnite);
            
        }
        
    }

    public double GetIgniteDamage(double totalSpellDamage, int baseTurnsIgnited)
    {
        numOfTurnsIgnited += baseTurnsIgnited;
        if (totalSpellDamage < 0)
        {
            totalSpellDamage = 0;
        }
        damageTakenFromIgnite += totalSpellDamage / 2;
        return damageTakenFromIgnite;
    }

    public double TotalEnemyDamageValue()
    {
        double totalDamage = lightningDamage.GetValue() + fireDamage.GetValue() + physicalDamage.GetValue() + coldDamage.GetValue(); //before armour and resistances this is just used to display on the enemy intention
        return totalDamage;
    }


    public void ResetArmour()
    {
        currentArmour = 0;
    }












}


