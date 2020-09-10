using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemStatsOnCharacter : MonoBehaviour
{
    public bool offense;
    public bool defense;
    public bool other;

    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;
    public Text text5;
    public Text text6;
    public Text text7;
    public Text text8;
    public Text text9;
    public Text text10;
    public Text text11;

    public Button offenseButton;
    public Button defenseButton;
    public Button otherButton;

    public BattleSystem battleSystem;
    
    public Unit playerUnit;

    // Start is called before the first frame update
    void Start()
    {
        
        playerUnit = battleSystem.playerUnit;
        offense = true;
        defense = false;
        other = false;

        

    }

    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log(offenseItemDescription["Increased physical damage: "]);
        

        if (offense == true)
        {
            ChangeTextToOffense();
        }

        if (defense == true)
        {
            ChangeTextToDefense();
        }

        if (other == true)
        {
            ChangeTextToOther();
            
        }
    }

    public void ChangeTextToOffense()
    {
        offense = true;
        defense = false;
        other = false;
        
        text1.text = "Increased physical damage: " + playerUnit.physicalDamage.GetValue() + "%";
        text2.text = "Increased fire damage: " + playerUnit.fireDamage.GetValue() + "%";
        text3.text = "Increased cold damage: " + playerUnit.coldDamage.GetValue() + "%";
        text4.text = "Increased lightning damage: " + playerUnit.lightningDamage.GetValue() + "%";
        text5.text = "Increased critical strike chance: " + playerUnit.critChance.GetValue() + "%";
        text6.text = "Increased critical strike multiplier: " + playerUnit.critMulti.GetValue() + "%";
        text7.text = "Increased chance to ignite: " + playerUnit.chanceToIgnite.GetValue() + "%";
        text8.text = "Increased chance to shock: " + playerUnit.chanceToShock.GetValue() + "%";
        text9.text = "Increased chance to freeze: " + playerUnit.chanceToFreeze.GetValue() + "%";
        text10.text = "Increased shock effectiveness: " + playerUnit.shockEffectiveness.GetValue() + "%";
    }

    public void ChangeTextToDefense()
    {
        offense = false;
        defense = true;
        other = false;
        
        text1.text = "+" + playerUnit.maxLifeMod.GetValue() + " to maximum life";
        text2.text = "More fire resistance: " + playerUnit.fireResistance.GetValue() + "%";
        text3.text = "More cold resistance: " + playerUnit.coldRes.GetValue() + "%";
        text4.text = "More lightning resistance: " + playerUnit.lightningRes.GetValue() + "%";
        text5.text = "Increased armour gained: " + playerUnit.armour.GetValue() + "%";
        text6.text = "";
        text7.text = "";
        text8.text = "";
        text9.text = "";
        text10.text = "";
    }

    public void ChangeTextToOther()
    {
        offense = false;
        defense = false;
        other = true;
        text1.text = "+" + playerUnit.maxMana.GetValue() + " to maximum mana";
        text2.text = "";
        text3.text = "";
        text4.text = "";
        text5.text = "";
        text6.text = "";
        text7.text = "";
        text8.text = "";
        text9.text = "";
        text10.text = "";
    }
}
