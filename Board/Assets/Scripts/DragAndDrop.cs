using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    public Vector3 offset;
    public CanvasGroup canvasGroup;
    public Vector3 cardPositionStart;
    public Quaternion cardRotationPosition;
    public GameObject currentCard;
    public bool isDragging;
    public Transform currentCardPosition;
    

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.blocksRaycasts = false;
    }
     
    
   

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.position = cardPositionStart;
        //Debug.Log("begin drag");
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        offset = mousePos - transform.position;
        //canvasGroup.blocksRaycasts = false; //this makes it so the raycast goes through the object when it begins dragging allowing us to drop into enemy area
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        isDragging = true;
        //Debug.Log("drag");
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        
        
        transform.position = mousePos - offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("end drag");
        //canvasGroup.blocksRaycasts = true;
        transform.position = cardPositionStart;
        isDragging = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("Pointer down");
        //BlockRaycast();
        transform.position = cardPositionStart;

    }

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("Pointer down");
    }

    


    public void BlockRaycast()
    {
        //canvasGroup.blocksRaycasts = true;
    }

    public void UnblockRaycast()
    {
        //canvasGroup.blocksRaycasts = false;
    }

    public void IncreaseScale(GameObject cardPositionOnHover)
    {
        cardPositionStart = new Vector3(transform.position.x, transform.position.y);
        Vector3 hoverCardPosition = new Vector3(cardPositionOnHover.transform.position.x, cardPositionOnHover.transform.position.y);
        //Debug.Log("hovering over " + currentCard);
        transform.localScale = new Vector3(2, 2, 2);
        transform.position = hoverCardPosition;
    }

    public void DecreaseScale()
    {
        transform.localScale = new Vector3(1, 1, 1);
        
        
    }

    public void ResetPosition()
    {
        transform.position = cardPositionStart;
    }



}
