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


    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
        skillCard = parent.transform.GetChild(1).gameObject;
        dragAndDrop = skillCard.GetComponent<DragAndDrop>();
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
    }
    public void OnPointerDown(PointerEventData eventData)
    {

        //dragAndDrop.gameObject.SetActive(false);
        dragAndDrop.isDragging = true;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        dragAndDrop.transform.position = dragAndDrop.cardPositionStart;
        dragAndDrop.DecreaseScale();
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        offset = mousePos - transform.position;
        dragAndDrop.isDragging = true;
        canvasGroup.blocksRaycasts = false;
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        dragAndDrop.isDragging = true;
        
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y);


        dragAndDrop.transform.position = mousePos - offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("end drag");
        //canvasGroup.blocksRaycasts = true;
        dragAndDrop.transform.position = dragAndDrop.cardPositionStart;
        dragAndDrop.isDragging = false;
        canvasGroup.blocksRaycasts = true;
    }
}
