using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    #region Singleton
    public static Equipment instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    public EquipmentSlot equipSlot;

    public double armourModifier;
    public double physicalDamageModifier;
    public double fireDamageModifier;
    public double lightningDamageMod;
    public double coldDamageMod;
    public double critChanceMod;
    public double critMultiMod;
    public double maxLifeMod;
    public double maxManaMod;
    public double leechMod;
    public double fireResMod;
    public double coldResMod;
    public double lightningResMod;
    public double lifeGainedOnHitMod;
    public double chanceToIgniteMod;
    public double chanceToFreezeMod;
    public double chanceToShockMod;
    public double lightningPenMod;
    public double coldPenMod;
    public double firePenMod;
    public double manaGainedOnHitMod;
    public double critChanceWithFireMod;
    public double critChanceWithLightningMod;
    public double critChanceWithColdMod;
    public double critMultiWithFireMod;
    public double critMultiWithColdMod;
    public double critMultiWithLightningMod;
    public double dotMod;
    public double coldDotMod;
    public double fireDotMod;
    public double lightningDotMod;
    public bool hasChangedText;
    public double shockEffectiveness;


    public override void Use()
    {
        base.Use();

        //equip item 
        EquipmentManager.instance.Equip(this);
        
        //add it to the character ui

        // remove it from inventory
        RemoveFromInventory();
    }

}

public enum EquipmentSlot { Helmet, Chest, Boots, Weapon, offHand, Ring, Amulet, Shoulders, Belt, Bracers }
