using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTextToItemDescription : MonoBehaviour
{
    Equipment equipment;
    public Text nameText;
    public Text prefixMod1Text;
    public Text prefixMod2Text;
    public Text prefixMod3Text;
    public Text suffixMod1Text;
    public Text suffixMod2Text;
    public Text suffixMod3Text;

    public int numOfMods = 0;


    public List<Text> itemDescriptions = new List<Text>();
    public List<string> itemMods = new List<string>();
    public List<string> itemModCheckNull = new List<string>();
    //public float alpha;

    // Start is called before the first frame update
    void Start()
    {
        //alpha = GetComponent<CanvasGroup>().alpha;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeElements(Equipment equipment)
    {



        itemMods.Add(equipment.fireDamageModifier.ToString() + "% increased fire damage");
        itemMods.Add(equipment.physicalDamageModifier.ToString() + "% increased physical damage");
        itemMods.Add(equipment.lightningDamageMod.ToString() + "% increased lightning damage");
        itemMods.Add(equipment.coldDamageMod.ToString() + "% Increased cold damage");
        itemMods.Add(equipment.critChanceMod.ToString() + "% Increased crit chance");
        itemMods.Add(equipment.critMultiMod.ToString() + "% Increased crit multi");
        itemMods.Add(equipment.fireResMod.ToString() + "% More fire resistance");
        itemMods.Add(equipment.coldResMod.ToString() + "% More cold resistance");
        itemMods.Add(equipment.lightningResMod.ToString() + "% More lightning resistance");
        itemMods.Add(equipment.chanceToFreezeMod.ToString() + "% increased chance to freeze");
        itemMods.Add(equipment.chanceToShockMod.ToString() + "% increased chance to shock");
        itemMods.Add(equipment.chanceToIgniteMod.ToString() + "% increased chance to ignite");
        itemMods.Add("+" + equipment.maxLifeMod.ToString() + " to maximum life");
        itemMods.Add(equipment.armourModifier.ToString() + "% increased armour gained");
        itemMods.Add("+" + equipment.maxManaMod.ToString() + " to maximum mana");
        itemMods.Add(equipment.shockEffectiveness.ToString() + " %increased effect of shock");


        itemModCheckNull.Add(equipment.fireDamageModifier.ToString());
        itemModCheckNull.Add(equipment.physicalDamageModifier.ToString());
        itemModCheckNull.Add(equipment.lightningDamageMod.ToString());
        itemModCheckNull.Add(equipment.coldDamageMod.ToString());
        itemModCheckNull.Add(equipment.critChanceMod.ToString());
        itemModCheckNull.Add(equipment.critMultiMod.ToString());
        itemModCheckNull.Add(equipment.fireResMod.ToString());
        itemModCheckNull.Add(equipment.coldResMod.ToString());
        itemModCheckNull.Add(equipment.lightningResMod.ToString());
        itemModCheckNull.Add(equipment.chanceToFreezeMod.ToString());
        itemModCheckNull.Add(equipment.chanceToShockMod.ToString());
        itemModCheckNull.Add(equipment.chanceToIgniteMod.ToString());
        itemModCheckNull.Add(equipment.maxLifeMod.ToString());
        itemModCheckNull.Add(equipment.armourModifier.ToString());
        itemModCheckNull.Add(equipment.maxManaMod.ToString());
        itemModCheckNull.Add(equipment.shockEffectiveness.ToString());

        itemDescriptions.Add(prefixMod1Text);
        itemDescriptions.Add(prefixMod2Text);
        itemDescriptions.Add(prefixMod3Text);
        itemDescriptions.Add(suffixMod1Text);
        itemDescriptions.Add(suffixMod2Text);
        itemDescriptions.Add(suffixMod3Text);

        numOfMods = 0;
        for (int i = 0; i < itemModCheckNull.Count; i++)
        {

            if (itemModCheckNull[i] != 0.ToString())
            {
                numOfMods++;
                //Debug.Log(numOfMods + "num of mods");
            }

        }

        for (int i = 0; i < itemDescriptions.Count; i++)
        {
            itemDescriptions[i].text = null;
        }



        int iterator = 0;
        for (int j = 0; j < itemModCheckNull.Count; j++)
        {
            if (itemModCheckNull[j] != 0.ToString())
            {

                itemDescriptions[iterator].text = itemMods[j];
                iterator++;

            }
        }




        nameText.text = equipment.name.ToString();
        //prefixMod1Text.text = equipment.fireDamageModifier.ToString() + "% increased fire damage.";
        //prefixMod2Text.text = equipment.physicalDamageModifier.ToString() + "% increased physical damage.";

        itemMods.Clear();

        itemModCheckNull.Clear();


        itemDescriptions.Clear();


    }



    public void ChangeTransparency(float transparency)
    {
        this.GetComponent<CanvasGroup>().alpha = transparency;


    }

    public void RemoveModifiers(Equipment oldItem)
    {
        
    }

}
