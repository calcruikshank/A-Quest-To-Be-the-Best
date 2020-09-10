using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurnCardIntoTarget : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDropHandler
{
    public GameObject currentCard;
    public CanvasGroup canvasGroup;
    public DragAndDrop dragAndDrop;
    public GameObject target;
    public CanvasGroup targetCanvas;
    public CardStats cardStats;
    public BattleSystem battleSystem;
    

    // Start is called before the first frame update
    void Start()
    {
        targetCanvas = target.GetComponent<CanvasGroup>();
        targetCanvas.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        target.transform.position = mousePos;

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            GameObject currentPositionParent = eventData.pointerDrag;
            if (currentPositionParent.transform.childCount > 1)
            {
                currentCard = eventData.pointerDrag.transform.GetChild(1).gameObject; //gets current card
                dragAndDrop = currentCard.GetComponent<DragAndDrop>();
                cardStats = currentCard.GetComponent<CardStats>();
                if (dragAndDrop.isDragging == true)
                {
                    if (cardStats.cardType == "spell")
                    {
                        //Debug.Log(currentCard + " entered neutral area");
                        canvasGroup = currentCard.GetComponent<CanvasGroup>();
                        canvasGroup.alpha = 0;
                        targetCanvas.alpha = 1;
                    }
                    if (cardStats.cardType == "aura")
                    {
                        //highlight
                    }
                    else
                    {

                    }
                   
                }
            }
        }
        


    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }

    public void OnDrop(PointerEventData eventData)
    {

        //Debug.Log("Dropped");
        GameObject currentCard = eventData.pointerDrag; //this gets whatever game object was dragged into the enemy area
        
        if (currentCard != null && cardStats.cardType == "aura")
        {
            //use
            battleSystem.PlayerCastsAura(currentCard);
           
            
            //add to graveyard

        }

        if (currentCard != null && cardStats.cardType == "defense")
        {
            //use
            battleSystem.PlayerCastsDefense(currentCard);


            //add to graveyard

        }
    }
}
