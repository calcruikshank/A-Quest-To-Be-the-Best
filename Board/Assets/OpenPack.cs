using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenPack : MonoBehaviour
{

    public GameObject fireball;
   
    public Transform cardSpawn1;
    public Transform cardSpawn2;
    public Transform cardSpawn3;
    public Transform cardSpawn4;
    public Transform cardSpawn5;


    public CanvasGroup canvasGroup;


    public void Start()
    {
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
        
    }
    public void OpenAPack()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        GameObject randomCard1 = Instantiate(fireball, cardSpawn1);
        GameObject randomCard2 = Instantiate(fireball, cardSpawn2);
        GameObject randomCard3 = Instantiate(fireball, cardSpawn3);
        GameObject randomCard4 = Instantiate(fireball, cardSpawn4);
        GameObject randomCard5 = Instantiate(fireball, cardSpawn5);

        bool wasAddedToLibrary = CardLibrary.instance.Add(randomCard1);
        wasAddedToLibrary = CardLibrary.instance.Add(randomCard2);
        wasAddedToLibrary = CardLibrary.instance.Add(randomCard3);
        wasAddedToLibrary = CardLibrary.instance.Add(randomCard4);
        wasAddedToLibrary = CardLibrary.instance.Add(randomCard5);

        if (wasAddedToLibrary != false)
        {
            StartCoroutine(DestroyCards(randomCard1, randomCard2, randomCard3, randomCard4, randomCard5));
            


        }

    }

    IEnumerator DestroyCards(GameObject randomCard1, GameObject randomCard2, GameObject randomCard3, GameObject randomCard4, GameObject randomCard5)
    {
        
        yield return new WaitForSeconds(2f);
        randomCard1.SetActive(false);
        randomCard2.SetActive(false);
        randomCard3.SetActive(false);
        randomCard4.SetActive(false);
        randomCard5.SetActive(false);

        gameObject.SetActive(false);
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }


}
