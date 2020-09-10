using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckUI : MonoBehaviour
{

    public GameObject deckUI;
    public Transform deckSlotsParent;
    DeckSlot[] deckSlots;
    public GameObject deckLibrary;
    CardLibrarySlot[] librarySlots;
    public Transform libraryParent;

    public CardLibrary cardLibrary;
    // Start is called before the first frame update
    void Start()
    {
        cardLibrary = CardLibrary.instance;
        cardLibrary.onPackOpenedCallback += UpdateUI;

        librarySlots = libraryParent.GetComponentsInChildren<CardLibrarySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            //Debug.Log("Pressed c");
            deckUI.SetActive(!deckUI.activeSelf);
        }
    }

    public void OpenDeckLibrary()
    {
        deckLibrary.SetActive(!deckLibrary.activeSelf);
        deckUI.SetActive(!deckUI.activeSelf);
    }

    void UpdateUI()
    {
        //Debug.Log("Updating UI");

        for (int i = 0; i < librarySlots.Length; i++)
        {
            if (i < cardLibrary.skillCards.Count)
            {
                librarySlots[i].AddItem(cardLibrary.skillCards[i]);
            }
            else
            {
                librarySlots[i].ClearSlot();
            }
        }
    }
}
