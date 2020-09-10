using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardLibrarySlot : MonoBehaviour
{

    public Image icon;

    GameObject card;
    // Start is called before the first frame update
    void Start()
    {
        //icon = gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearSlot()
    {
        //Debug.Log("Clear Slot");
    }

    public void AddItem(GameObject newCard)
    {
        card = newCard;
        icon.sprite = card.GetComponent<CardDisplay>().artworkImage.sprite;
        icon.enabled = true;
    }

}
