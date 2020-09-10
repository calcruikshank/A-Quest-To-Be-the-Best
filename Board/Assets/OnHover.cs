using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    
    public DragAndDrop dragAndDrop;
    public GameObject parent;
    public GameObject skillCard;
    public Vector3 offset;
    private CanvasGroup canvasGroup;
    public GameObject cardPositionOnHover;
    public GameObject target;
    public CanvasGroup targetCanvas;

    public Transform itemDescriptionTransform;
    public ChangeCardDescription changeCardDesription;
    public GameObject cardDescription;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        targetCanvas = target.GetComponent<CanvasGroup>();

    }

    // Update is called once per frame
    void Update()
    {
        if (skillCard != null && Input.GetKey(KeyCode.LeftAlt))
        {
            //Debug.Log("Left alt was pressed while hovering " + skillCard);
            if (skillCard.GetComponent<CardStats>().descriptionHasBeenInstantiated == false)
            {
                cardDescription = Instantiate(cardDescription, new Vector3(transform.position.x, transform.position.y + 250, itemDescriptionTransform.position.z), Quaternion.identity, itemDescriptionTransform);
                changeCardDesription = cardDescription.GetComponent<ChangeCardDescription>();
                changeCardDesription.CardDescription(skillCard);
            }
           
            
            cardDescription.SetActive(true);
            skillCard.GetComponent<CardStats>().descriptionHasBeenInstantiated = true;
        }
        if (cardDescription != null && Input.GetKeyUp(KeyCode.LeftAlt))
        {
            cardDescription.SetActive(false);

        }
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (transform.childCount > 1)
        {
            //skillCard = parent.transform.GetChild(1).gameObject;
            skillCard = eventData.pointerEnter.transform.GetChild(1).gameObject; //this doesnt rely on parent but above also works

            dragAndDrop = skillCard.GetComponent<DragAndDrop>();
            

        }

        if (dragAndDrop != null && dragAndDrop.isDragging == false)
        {
            //Debug.Log("entered transform");
            //dragAndDrop.BlockRaycast();
            dragAndDrop.IncreaseScale(cardPositionOnHover);
            transform.SetAsLastSibling();
        }


    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (dragAndDrop != null)
        {
            //Debug.Log("entered transform");
            //dragAndDrop.BlockRaycast();
            dragAndDrop.DecreaseScale();
            dragAndDrop.ResetPosition();
        }
        cardDescription.SetActive(false);
        skillCard = null;
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {

        //dragAndDrop.gameObject.SetActive(false);
        if (transform.childCount > 1)
        {
            dragAndDrop.isDragging = true;
        }
            
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (transform.childCount > 1)
        {
            dragAndDrop.transform.position = dragAndDrop.cardPositionStart;
            dragAndDrop.DecreaseScale();
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
            offset = mousePos - transform.position;
            dragAndDrop.isDragging = true;
            canvasGroup.blocksRaycasts = false;
            dragAndDrop.canvasGroup.blocksRaycasts = true;
        }
           
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (transform.childCount > 1)
        {
            dragAndDrop.isDragging = true;

            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y);


            dragAndDrop.transform.position = mousePos - offset;
        }
            
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (transform.childCount > 1)
        {
            //Debug.Log("end drag");
            //canvasGroup.blocksRaycasts = true;
            dragAndDrop.transform.position = dragAndDrop.cardPositionStart;
            dragAndDrop.isDragging = false;
            canvasGroup.blocksRaycasts = true;
            dragAndDrop.canvasGroup.blocksRaycasts = false;
            targetCanvas.alpha = 0;
            dragAndDrop.canvasGroup.alpha = 1;
           
        }
        
    }
}
