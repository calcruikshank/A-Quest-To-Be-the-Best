using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomItem : MonoBehaviour
{
    public int numOfMods;
    public int itemTier;

    #region Equipment Types
    public int helmet;
    public int shoulders;
    public int amulet;
    public int weapon;
    public int offHand;
    public int boots;
    public int ring;
    public int belt;
    public int chest;
    public int bracers;
    #endregion

    public int rarity;

    #region ItemSpawnLocations GameObjects
    public GameObject itemSpawn1;
    public GameObject itemSpawn2;
    public GameObject itemSpawn3;
    public GameObject itemSpawn4;
    public GameObject itemSpawn5;
    public GameObject itemSpawn6;
    public GameObject itemSpawn7;
    #endregion

    public GameObject ankh;
    public GameObject scimitar;
    public GameObject twoHandAxe;
    public GameObject oneHandAxe;
    public GameObject oneHandSword;
    public GameObject hammer;
    public GameObject wand;
    public GameObject dagger;
    public GameObject wizardStaff;
    public GameObject woodWand;
    public GameObject twoHandHammer;
    public GameObject pvcPipe;
    public GameObject sawAmulet;
    public GameObject staffOfTheSerpent;
    public GameObject fleshCleaver;
    public GameObject daggerTwo;
    public GameObject cleaver;
    public GameObject boneDagger;
    public GameObject scythe;
    public GameObject bat;

    public GameObject randomHelmet;

    public List<GameObject> itemPool = new List<GameObject>();
    public List<GameObject> itemSpawn = new List<GameObject>();
    public List<double> itemModPool = new List<double>();


    public double totalWeight;


    public double armourWeight = 25;
    public double lifeWeight = 50;
    public double fireDamageWeight = 50;
    public double coldDamageWeight = 50;
    public double lightningDamageWeight = 50;
    public double critChanceWeight = 25;
    public double critMultiWeight = 20;
    public double fireResWeight = 50;
    public double coldResWeight = 50;
    public double lightningResWeight = 50;
    public double increasedMaxManaWeight = 10;
    public double igniteWeight = 25;
    public double shockWeight = 25;
    public double freezeWeight = 25;


    public int iterateVar;


    public bool hasFireDamage;
    public bool hasColdDamage;
    public bool hasLightningDamage;
    public bool hasFireRes;
    public bool hasColdRes;
    public bool hasLightningRes;
    public bool hasCritChance;
    public bool hasCritMulti;
    public bool hasLife;
    public bool hasArmour;
    public bool hasLifeOnHit;
    public bool hasShock;
    public bool hasIgnite;
    public bool hasFreeze;
    public bool hasShockEffectiveness;
    public bool hasMaxMana;
    public bool hasPhysDamage;

    // Start is called before the first frame update
    void Start()
    {
        #region Assigning ItemSpawns
        itemSpawn1 = GameObject.Find("/Item Spawn Locations/Item Spawn Location 1");
        itemSpawn2 = GameObject.Find("/Item Spawn Locations/Item Spawn Location 2");
        itemSpawn3 = GameObject.Find("/Item Spawn Locations/Item Spawn Location 3");
        itemSpawn4 = GameObject.Find("/Item Spawn Locations/Item Spawn Location 4");
        itemSpawn5 = GameObject.Find("/Item Spawn Locations/Item Spawn Location 5");
        itemSpawn6 = GameObject.Find("/Item Spawn Locations/Item Spawn Location 6");
        itemSpawn7 = GameObject.Find("/Item Spawn Locations/Item Spawn Location 7");
        #endregion

        #region AddItemsToLists
        itemSpawn.Add(itemSpawn1);
        itemSpawn.Add(itemSpawn2);
        itemSpawn.Add(itemSpawn3);
        itemSpawn.Add(itemSpawn4);
        itemSpawn.Add(itemSpawn5);
        itemSpawn.Add(itemSpawn6);
        itemSpawn.Add(itemSpawn7);

        itemPool.Add(ankh);
        itemPool.Add(scimitar);
        itemPool.Add(twoHandAxe);
        itemPool.Add(oneHandAxe);
        itemPool.Add(oneHandSword);
        itemPool.Add(hammer);
        itemPool.Add(wand);
        itemPool.Add(dagger);
        itemPool.Add(wizardStaff);
        itemPool.Add(woodWand);
        itemPool.Add(twoHandHammer);
        itemPool.Add(pvcPipe);
        itemPool.Add(sawAmulet);
        itemPool.Add(staffOfTheSerpent);
        itemPool.Add(fleshCleaver);
        itemPool.Add(daggerTwo);
        itemPool.Add(cleaver);
        itemPool.Add(boneDagger);
        itemPool.Add(scythe);
        itemPool.Add(bat);
        itemPool.Add(randomHelmet);
        itemPool.Add(randomHelmet);
        itemPool.Add(randomHelmet);
        itemPool.Add(randomHelmet);
        itemPool.Add(randomHelmet);
        itemPool.Add(randomHelmet);
        itemPool.Add(randomHelmet);
        itemPool.Add(randomHelmet);
        itemPool.Add(randomHelmet);
        //itemSpawnOne = GameObject.FindGameObjectWithTag("ItemSpawn").transform;

        helmet = 0;
        chest = 1;
        boots = 2;
        weapon = 3;
        offHand = 4;
        ring = 5;
        amulet = 6;
        shoulders = 7;
        belt = 8;
        bracers = 9;


        itemModPool.Add(armourWeight);
        itemModPool.Add(lifeWeight);
        itemModPool.Add(lightningDamageWeight);
        itemModPool.Add(coldDamageWeight);
        itemModPool.Add(fireDamageWeight);
        itemModPool.Add(lightningResWeight);
        itemModPool.Add(coldResWeight);
        itemModPool.Add(fireResWeight);
        itemModPool.Add(increasedMaxManaWeight);
        itemModPool.Add(shockWeight);
        itemModPool.Add(freezeWeight);
        itemModPool.Add(igniteWeight);
        itemModPool.Add(critChanceWeight);
        itemModPool.Add(critMultiWeight);
        #endregion

        itemModPool.Sort(); //sort values from least to greatest 
        itemModPool.Reverse(); //now from greatest to least
        for (int i = 0; i < itemModPool.Count; i++)
        {
            totalWeight += itemModPool[i];
            //Debug.Log(totalWeight);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnRandomEquipment(int level)
    {
        //instantiate a random number of items
        int randomNumber = Random.Range(1, itemSpawn.Count);
        //Debug.Log(level);
        for (int i = 0; i < randomNumber; i++)
        {
            int randomIndex = Random.Range(0, itemPool.Count);


            //Debug.Log(itemSpawn[i]);
            //Debug.Log(itemPool[randomIndex]);
            //get the componenet ItemPickup.Item.ChangeMods(); of itemPool[randomRange] 
            //GameObject item = Instantiate(staffWeapon, itemSpawnOne);

            //my current idea to differentiate between each equipment type is to get the component ItemPickup.item of itemPool[randomRange] and send it to a method which checks to see what enum type it is

            GameObject equipment = Instantiate(itemPool[randomIndex], itemSpawn[i].transform); //instantiates the game object where the equipment scriptable object will go
            Equipment randomEquipment = Instantiate(itemPool[randomIndex].GetComponent<ItemPickup>().equipment); //instantiates a new equipment Scriptable Object

            equipment.GetComponent<ItemPickup>().equipment = randomEquipment; //assigns scriptable object to the new game object
                                                                              //double randomStat = Random.Range(0, 100);
                                                                              //randomEquipment.fireDamageModifier = randomStat;

            //GenerateMods(randomEquipment);


            //int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
            //int numSlots = System.Enum.GetNames(typeof(EquipmentSlot));

            #region
            if (level < 10)
            {
                itemTier = 1;
            }
            if (level < 20 && level >= 10)
            {
                itemTier = 2;
            }
            if (level < 30 && level >= 20)
            {
                itemTier = 3;
            }
            if (level < 40 && level >= 30)
            {
                itemTier = 4;
            }
            if (level < 50 && level >= 40)
            {
                itemTier = 5;
            }
            if (level < 60 && level >= 50)
            {
                itemTier = 6;
            }
            if (level < 70 && level >= 60)
            {
                itemTier = 7;
            }
            if (level < 80 && level >= 70)
            {
                itemTier = 8;
            }
            if (level < 90 && level >= 80)
            {
                itemTier = 9;
            }
            if (level >= 90)
            {
                itemTier = 10;
                //Debug.Log(itemTier + " item tier");
            }
            #endregion

            int equipmentType = (int)randomEquipment.equipSlot;
            if (equipmentType == weapon)
            {
                numOfMods = Random.Range(1, 7);
                GenerateModsWeapon(numOfMods, itemTier, randomEquipment);
            }

            if (equipmentType == helmet)
            {
                numOfMods = Random.Range(1, 7);
                GenerateModsHelmet(numOfMods, itemTier, randomEquipment);
            }

        }

    }



    public void GenerateModsWeapon(int numOfMods, int itemTier, Equipment randomEquipment)
    {

        #region ResettingModifierValues
        //reset the bools to check if item has it too false
        hasFireDamage = false;
        hasColdDamage = false;
        hasLightningDamage = false;
        hasLightningRes = false;
        hasColdRes = false;
        hasFireRes = false;
        hasLife = false;
        hasArmour = false;
        hasShock = false;
        hasFreeze = false;
        hasIgnite = false;
        hasCritChance = false;
        hasCritMulti = false;
        hasShockEffectiveness = false;
        hasMaxMana = false;
        hasPhysDamage = false;

        randomEquipment.armourModifier = 0;
        randomEquipment.physicalDamageModifier = 0;
        randomEquipment.fireDamageModifier = 0;
        randomEquipment.lightningDamageMod = 0;
        randomEquipment.coldDamageMod = 0;
        randomEquipment.critChanceMod = 0;
        randomEquipment.critMultiMod = 0;
        randomEquipment.maxLifeMod = 0;
        randomEquipment.maxManaMod = 0;
        randomEquipment.leechMod = 0;
        randomEquipment.fireResMod = 0;
        randomEquipment.coldResMod = 0;
        randomEquipment.lightningResMod = 0;
        randomEquipment.lifeGainedOnHitMod = 0;
        randomEquipment.chanceToIgniteMod = 0;
        randomEquipment.chanceToFreezeMod = 0;
        randomEquipment.chanceToShockMod = 0;
        randomEquipment.lightningPenMod = 0;
        randomEquipment.coldPenMod = 0;
        randomEquipment.firePenMod = 0;
        randomEquipment.manaGainedOnHitMod = 0;
        randomEquipment.critChanceWithFireMod = 0;
        randomEquipment.critChanceWithLightningMod = 0;
        randomEquipment.critChanceWithColdMod = 0;
        randomEquipment.critMultiWithFireMod = 0;
        randomEquipment.critMultiWithColdMod = 0;
        randomEquipment.critMultiWithLightningMod = 0;
        randomEquipment.dotMod = 0;
        randomEquipment.coldDotMod = 0;
        randomEquipment.fireDotMod = 0;
        randomEquipment.lightningDotMod = 0;
        #endregion

        for (int i = 0; i < numOfMods; i++)
        {

            double randomWeight = Random.Range(0, (float)totalWeight);
            foreach (var weight in itemModPool)
            {

                if (randomWeight <= weight)
                {

                    if (weight == 50)
                    {

                        int randomStatWithinList = Random.Range(0, 8);
                        if (randomStatWithinList == 0 && hasFireDamage == false)
                        {

                            randomEquipment.fireDamageModifier = Random.Range(1, itemTier * 10);
                            hasFireDamage = true;
                            break;
                        }
                        if (randomStatWithinList == 1 && hasColdDamage == false)
                        {
                            randomEquipment.coldDamageMod = Random.Range(1, itemTier * 10);
                            hasColdDamage = true;

                            break;
                        }
                        if (randomStatWithinList == 2 && hasLightningDamage == false)
                        {
                            randomEquipment.lightningDamageMod = Random.Range(1, itemTier * 10);
                            hasLightningDamage = true;

                            break;
                        }
                        if (randomStatWithinList == 3 && hasFireRes == false)
                        {
                            randomEquipment.fireResMod = Random.Range(1, itemTier * 4);
                            hasFireRes = true;

                            break;
                        }
                        if (randomStatWithinList == 4 && hasColdRes == false)
                        {
                            randomEquipment.coldResMod = Random.Range(1, itemTier * 4);
                            hasColdRes = true;

                            break;
                        }
                        if (randomStatWithinList == 5 && hasLightningRes == false)
                        {
                            randomEquipment.lightningResMod = Random.Range(1, itemTier * 4);
                            hasLightningRes = true;

                            break;
                        }
                        if (randomStatWithinList == 6 && hasLife == false)
                        {
                            randomEquipment.maxLifeMod = Random.Range(1, itemTier * 12);
                            hasLife = true;

                            break;
                        }
                        if (randomStatWithinList == 7 && hasPhysDamage == false)
                        {
                            randomEquipment.physicalDamageModifier = Random.Range(1, itemTier * 10);
                            hasPhysDamage = true;

                            break;
                        }

                    }
                    if (weight == 25)// need to add bools to check if item already has it 
                    {

                        int randomStatWithinList = Random.Range(0, 4);
                        int itemModRangeMax = itemTier * 10;
                        //armour, crit chance, ignite, shock, freeze
                        if (randomStatWithinList == 0 && hasArmour == false)
                        {
                            randomEquipment.armourModifier = Random.Range(1, itemTier * 10);
                            hasArmour = true;
                            break;
                        }
                        if (randomStatWithinList == 1 && hasCritChance == false)
                        {
                            randomEquipment.critChanceMod = Random.Range(1, itemTier * 10);
                            hasCritChance = true;
                            break;
                        }
                        if (randomStatWithinList == 2 && hasIgnite == false)
                        {
                            randomEquipment.chanceToIgniteMod = Random.Range(1, itemTier * 10);
                            hasIgnite = true;
                            break;
                        }
                        if (randomStatWithinList == 3 && hasFreeze == false)
                        {
                            randomEquipment.chanceToFreezeMod = Random.Range(1, itemTier * 10);
                            hasFreeze = true;
                            break;
                        }
                        if (randomStatWithinList == 4 && hasShock == false)
                        {
                            randomEquipment.chanceToShockMod = Random.Range(1, itemTier * 10);
                            hasShock = true;
                            break;
                        }


                    }

                    if (weight == 20)
                    {

                        int randomStatWithinList = Random.Range(0, 2);
                        if (randomStatWithinList == 0 && hasCritMulti == false)
                        {
                            randomEquipment.critMultiMod = Random.Range(1, itemTier * 5);
                            hasCritMulti = true;
                            break;
                        }
                        if (randomStatWithinList == 1 && hasShockEffectiveness == false)
                        {
                            randomEquipment.shockEffectiveness = Random.Range(1, itemTier * 5);
                            hasShockEffectiveness = true;
                            break;
                        }
                    }

                    if (weight == 10 && hasMaxMana == false)
                    {
                        randomEquipment.maxManaMod = Random.Range(1, 3);
                        hasMaxMana = true;
                        break;
                    }


                }
                else
                {
                    randomWeight -= weight;
                }
            }
        }

    }



    public void GenerateModsHelmet(int numOfMods, int itemTier, Equipment randomEquipment)
    {

        #region ResettingModifierValues
        //reset the bools to check if item has it too false
        hasFireDamage = false;
        hasColdDamage = false;
        hasLightningDamage = false;
        hasLightningRes = false;
        hasColdRes = false;
        hasFireRes = false;
        hasLife = false;
        hasArmour = false;
        hasShock = false;
        hasFreeze = false;
        hasIgnite = false;
        hasCritChance = false;
        hasCritMulti = false;
        hasShockEffectiveness = false;
        hasMaxMana = false;
        hasPhysDamage = false;

        randomEquipment.armourModifier = 0;
        randomEquipment.physicalDamageModifier = 0;
        randomEquipment.fireDamageModifier = 0;
        randomEquipment.lightningDamageMod = 0;
        randomEquipment.coldDamageMod = 0;
        randomEquipment.critChanceMod = 0;
        randomEquipment.critMultiMod = 0;
        randomEquipment.maxLifeMod = 0;
        randomEquipment.maxManaMod = 0;
        randomEquipment.leechMod = 0;
        randomEquipment.fireResMod = 0;
        randomEquipment.coldResMod = 0;
        randomEquipment.lightningResMod = 0;
        randomEquipment.lifeGainedOnHitMod = 0;
        randomEquipment.chanceToIgniteMod = 0;
        randomEquipment.chanceToFreezeMod = 0;
        randomEquipment.chanceToShockMod = 0;
        randomEquipment.lightningPenMod = 0;
        randomEquipment.coldPenMod = 0;
        randomEquipment.firePenMod = 0;
        randomEquipment.manaGainedOnHitMod = 0;
        randomEquipment.critChanceWithFireMod = 0;
        randomEquipment.critChanceWithLightningMod = 0;
        randomEquipment.critChanceWithColdMod = 0;
        randomEquipment.critMultiWithFireMod = 0;
        randomEquipment.critMultiWithColdMod = 0;
        randomEquipment.critMultiWithLightningMod = 0;
        randomEquipment.dotMod = 0;
        randomEquipment.coldDotMod = 0;
        randomEquipment.fireDotMod = 0;
        randomEquipment.lightningDotMod = 0;
        #endregion

        for (int i = 0; i < numOfMods; i++)
        {

            double randomWeight = Random.Range(0, (float)totalWeight);
            foreach (var weight in itemModPool)
            {

                if (randomWeight <= weight)
                {

                    if (weight == 50)
                    {

                        int randomStatWithinList = Random.Range(0, 8);
                        if (randomStatWithinList == 0 && hasFireDamage == false)
                        {

                            randomEquipment.fireDamageModifier = Random.Range(1, itemTier * 10);
                            hasFireDamage = true;
                            break;
                        }
                        if (randomStatWithinList == 1 && hasColdDamage == false)
                        {
                            randomEquipment.coldDamageMod = Random.Range(1, itemTier * 10);
                            hasColdDamage = true;

                            break;
                        }
                        if (randomStatWithinList == 2 && hasLightningDamage == false)
                        {
                            randomEquipment.lightningDamageMod = Random.Range(1, itemTier * 10);
                            hasLightningDamage = true;

                            break;
                        }
                        if (randomStatWithinList == 3 && hasFireRes == false)
                        {
                            randomEquipment.fireResMod = Random.Range(1, itemTier * 4);
                            hasFireRes = true;

                            break;
                        }
                        if (randomStatWithinList == 4 && hasColdRes == false)
                        {
                            randomEquipment.coldResMod = Random.Range(1, itemTier * 4);
                            hasColdRes = true;

                            break;
                        }
                        if (randomStatWithinList == 5 && hasLightningRes == false)
                        {
                            randomEquipment.lightningResMod = Random.Range(1, itemTier * 4);
                            hasLightningRes = true;

                            break;
                        }
                        if (randomStatWithinList == 6 && hasLife == false)
                        {
                            randomEquipment.maxLifeMod = Random.Range(1, itemTier * 12);
                            hasLife = true;

                            break;
                        }
                        if (randomStatWithinList == 7 && hasPhysDamage == false)
                        {
                            randomEquipment.physicalDamageModifier = Random.Range(1, itemTier * 10);
                            hasPhysDamage = true;

                            break;
                        }
                    }
                    if (weight == 25)// need to add bools to check if item already has it 
                    {

                        int randomStatWithinList = Random.Range(0, 4);
                        int itemModRangeMax = itemTier * 10;
                        //armour, crit chance, ignite, shock, freeze
                        if (randomStatWithinList == 0 && hasArmour == false)
                        {
                            randomEquipment.armourModifier = Random.Range(1, itemTier * 10);
                            hasArmour = true;
                            break;
                        }
                        if (randomStatWithinList == 1 && hasCritChance == false)
                        {
                            randomEquipment.critChanceMod = Random.Range(1, itemTier * 10);
                            hasCritChance = true;
                            break;
                        }
                        if (randomStatWithinList == 2 && hasIgnite == false)
                        {
                            randomEquipment.chanceToIgniteMod = Random.Range(1, itemTier * 10);
                            hasIgnite = true;
                            break;
                        }
                        if (randomStatWithinList == 3 && hasFreeze == false)
                        {
                            randomEquipment.chanceToFreezeMod = Random.Range(1, itemTier * 10);
                            hasFreeze = true;
                            break;
                        }
                        if (randomStatWithinList == 4 && hasShock == false)
                        {
                            randomEquipment.chanceToShockMod = Random.Range(1, itemTier * 10);
                            hasShock = true;
                            break;
                        }


                    }

                    if (weight == 20)
                    {

                        int randomStatWithinList = Random.Range(0, 2);
                        if (randomStatWithinList == 0 && hasCritMulti == false)
                        {
                            randomEquipment.critMultiMod = Random.Range(1, itemTier * 5);
                            hasCritMulti = true;
                            break;
                        }
                        if (randomStatWithinList == 1 && hasShockEffectiveness == false)
                        {
                            randomEquipment.shockEffectiveness = Random.Range(1, itemTier * 5);
                            hasShockEffectiveness = true;
                            break;
                        }
                    }

                    if (weight == 10 && hasMaxMana == false)
                    {
                        randomEquipment.maxManaMod = Random.Range(1, 3);
                        hasMaxMana = true;
                        break;
                    }


                }
                else
                {
                    randomWeight -= weight;
                }
            }
        }

    }
}