using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyArea : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public BattleSystem battleSystem;
    public TurnCardIntoTarget cardIntoTarget;
    public GameObject targetOnEnemy;
    public CanvasGroup targetOnEnemyCanvas;
    public DragAndDrop dragAndDrop;
    public GameObject currentCardHover;
    public CardStats cardStats;

    public void OnDrop(PointerEventData eventData)
    {
        
        //Debug.Log("Dropped");
        GameObject currentCard = eventData.pointerDrag; //this gets whatever game object was dragged into the enemy area

        if(currentCard != null)
        {
            //use
            battleSystem.PlayerCastsSpell(currentCard);
            cardIntoTarget.targetCanvas.alpha = 0;
            targetOnEnemyCanvas.alpha = 0;
            //add to graveyard
            
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {

            currentCardHover = eventData.pointerDrag.transform.GetChild(1).gameObject; //gets current card
            cardStats = currentCardHover.GetComponent<CardStats>();
            if (currentCardHover != null && cardStats.cardType == "spell")
            {
                targetOnEnemyCanvas.alpha = 1;
            }
        }
            
        
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        targetOnEnemyCanvas.alpha = 0;
    }

    public void Update()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        targetOnEnemy.transform.position = mousePos;
    }
    public void Start()
    {
        targetOnEnemyCanvas = targetOnEnemy.GetComponent<CanvasGroup>();
    }
}
