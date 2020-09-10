using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    public string unitLevel;

    

    public double maxLife = 100;
    public double currentLife { get; private set; }
    public Stat physicalDamage;
    public Stat fireDamage;
    public Stat armour;
    public Stat fireResistance;
    //spublic double totalDamage;
    public int maximumMana = 3;
    public int currentMana { get; set; }

    void Awake()
    {
        currentLife = maxLife;
        currentMana = maximumMana;
    }

    

    public void TakeDamage(double totalDamage)
    {
        //totalDamage -= armour.GetValue();

        if (totalDamage < 0)
        {
            totalDamage = 0;
        }

        currentLife -= totalDamage;
        Debug.Log(transform.name + " takes " + totalDamage);

        if (currentLife <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        //override
        Debug.Log(transform.name + " died");
    }

    public void TakeDamageSpell(double physicalDamage, GameObject cardBeingCast)
    {
        GameObject card = cardBeingCast.transform.GetChild(1).gameObject; //this will convert the card posiiton parent to the correct card child 
        CardStats cardStats = card.GetComponent<CardStats>(); //then this gets the component card stats god damn im good
        double totalSpellDamage = cardStats.baseFireDamage + physicalDamage;
        //totalDamage -= armour.GetValue();

        //destroy cardbeingcast for now but later change it so it goes into graveyard
        Destroy(cardBeingCast);

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

    public double CalculateTotalDamage(Unit currentUnitTakingDamage)
    {
        double totalPhysDamage = physicalDamage.GetValue() - currentUnitTakingDamage.armour.GetValue(); //has to pass in current unit

        double fireResistanceMulti = (100 - currentUnitTakingDamage.fireResistance.GetValue()) / 100;
        double totalFireDamage = fireDamage.GetValue() * fireResistanceMulti;

        double totalDamage = totalFireDamage + totalPhysDamage;
        return totalDamage;
        
    }





















}


