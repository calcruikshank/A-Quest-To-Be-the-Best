using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{


    public SkillCard card;
   

    public Text nameText;
    public Text descriptionText;
    public Image artworkImage;

    public Text manaText;
    
    // Start is called before the first frame update
    void Start()
    {
        card.DisplayAdvancedInfo();
        nameText.text = card.name;
        descriptionText.text = card.description;
        artworkImage.sprite = card.artwork;
        manaText.text = card.baseManaCost.ToString();
    }

   
}
