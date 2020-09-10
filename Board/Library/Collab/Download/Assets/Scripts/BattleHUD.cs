using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Slider hpSlider;
    public Text manaText;

    public void SetHUD(Unit unit)
    {
        hpSlider.maxValue = (float)unit.maxLife;
        hpSlider.value = (float)unit.currentLife;
        
    }


    public void SetLife(double hp)
    {
        hpSlider.value = (float)hp;
    }

    public void SetMana(int currentMana, int maxMana)
    {
        manaText.text = currentMana.ToString() + "/" + maxMana.ToString();
    }
}
