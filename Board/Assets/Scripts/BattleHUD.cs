using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Slider hpSlider;
    public Text manaText;
    public Text lifeText;
    public Text armourText;
    public GameObject attackIntention;
    public GameObject defendIntention;
    public Text attackAmount;
    public Text defendAmount;

    public void SetHUD(Unit unit)
    {
        hpSlider.maxValue = (float)unit.maxLife;
        hpSlider.value = (float)unit.currentLife;
        
    }


    public void SetLife(double hp)
    {
        hpSlider.value = (float)hp;
        lifeText.text = hp.ToString();
    }

    public void SetMana(int currentMana, int maxMana)
    {
        manaText.text = currentMana.ToString() + "/" + maxMana.ToString();
    }

    public void SetArmour(Unit unit)
    {
        armourText.text = unit.currentArmour.ToString();
    }

    public void SetIntention(int intention, double attackValue)
    {
        Debug.Log(intention);
        if (intention == 0)
        {
            attackIntention.SetActive(true);//dont forget to send in what to set the text to
            defendIntention.SetActive(false);
            attackAmount.text = attackValue.ToString();
            return;
        }

        if (intention == 2)
        {
            attackIntention.SetActive(false);//dont forget to send in what to set the text to
            defendIntention.SetActive(true);
            return;
        }

        else
        {
            attackIntention.SetActive(false);//dont forget to send in what to set the text to
            defendIntention.SetActive(false);
            return;
        }
    }
}
