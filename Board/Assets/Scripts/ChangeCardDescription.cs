using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCardDescription : MonoBehaviour
{
    public CardStats cardStats;


    public Text nameText;
    public Text advancedStat1;
    public Text advancedStat2;
    public Text advancedStat3;
    public Text advancedStat4;
    public Text advancedStat5;
    public Text advancedStat6;
    //set these advanced stats on the cards that way i can just change the text to the cardStats.advancedstatx

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CardDescription(GameObject skillCard)
    {
        cardStats = skillCard.GetComponent<CardStats>();
        nameText.text = cardStats.name;

        advancedStat1.text = cardStats.advancedMod1;
        advancedStat2.text = cardStats.advancedMod2;
        advancedStat3.text = cardStats.advancedMod3;
        advancedStat4.text = cardStats.advancedMod4;
        advancedStat5.text = cardStats.advancedMod5;
        advancedStat6.text = cardStats.advancedMod6;

        Debug.Log(skillCard + " this is the skill card");
    }
}
