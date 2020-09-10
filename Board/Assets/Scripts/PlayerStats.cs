using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Unit
{
    // Start is called before the first frame update
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(50);
        }
    }

    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if(newItem != null)
        {
            armour.AddModifier(newItem.armourModifier);
            physicalDamage.AddModifier(newItem.physicalDamageModifier);
            fireDamage.AddModifier(newItem.fireDamageModifier);
            lightningDamage.AddModifier(newItem.lightningDamageMod);
            coldDamage.AddModifier(newItem.coldDamageMod);
            coldRes.AddModifier(newItem.coldResMod);
            fireResistance.AddModifier(newItem.fireResMod);
            lightningRes.AddModifier(newItem.lightningResMod);
            critChance.AddModifier(newItem.critChanceMod);
            critMulti.AddModifier(newItem.critMultiMod);
            chanceToFreeze.AddModifier(newItem.chanceToFreezeMod);
            chanceToIgnite.AddModifier(newItem.chanceToIgniteMod);
            chanceToShock.AddModifier(newItem.chanceToShockMod);

            maxLifeMod.AddModifier(newItem.maxLifeMod);
            maxLife = newItem.maxLifeMod + maxLife;
            
          
            maxMana.AddModifier(newItem.maxManaMod);

            shockEffectiveness.AddModifier(newItem.shockEffectiveness);

        }

        if(oldItem != null)
        {
            armour.RemoveModifier(oldItem.armourModifier);
            physicalDamage.RemoveModifier(oldItem.physicalDamageModifier);
            fireDamage.RemoveModifier(oldItem.fireDamageModifier);
            lightningDamage.RemoveModifier(oldItem.lightningDamageMod);
            coldDamage.RemoveModifier(oldItem.coldDamageMod);
            coldRes.RemoveModifier(oldItem.coldResMod);
            fireResistance.RemoveModifier(oldItem.fireResMod);
            lightningRes.RemoveModifier(oldItem.lightningResMod);
            critChance.RemoveModifier(oldItem.critChanceMod);
            critMulti.RemoveModifier(oldItem.critMultiMod);
            chanceToFreeze.RemoveModifier(oldItem.chanceToFreezeMod);
            chanceToIgnite.RemoveModifier(oldItem.chanceToIgniteMod);
            chanceToShock.RemoveModifier(oldItem.chanceToShockMod);

            maxLifeMod.RemoveModifier(oldItem.maxLifeMod);
            maxLife = maxLife - oldItem.maxLifeMod;
           

            maxMana.RemoveModifier(oldItem.maxManaMod);

            shockEffectiveness.RemoveModifier(oldItem.shockEffectiveness);

        }
        
    }
}
