using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image icon;
    Item item;
    public Button removeButton;


    public GameObject itemDescription;
    public Transform itemDescriptionTransform;
    public ChangeTextToItemDescription changeText;


    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
        //itemDescription = Instantiate(itemDescription, new Vector3(transform.position.x - 250, transform.position.y, itemDescriptionTransform.position.z), Quaternion.identity, itemDescriptionTransform);
        changeText = itemDescription.GetComponent<ChangeTextToItemDescription>();

        Equipment newEquipment = (Equipment)newItem; //this is important it converts the item to an equipment 
        changeText.ChangeElements(newEquipment);
        itemDescription.SetActive(false);
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
        itemDescription.SetActive(false);
    }

    public void OnRemoveButton()
    {
        itemDescription.SetActive(false);
        Inventory.instance.Remove(item);
    }

    public void UseItem()
    {
        if(item != null)
        {
            item.Use();
        }
    }


    public void OnPointerEnter(PointerEventData eventData)
    {

        if (item != null)
        {

            //Debug.Log("hovering over equipment slot with an item");
            itemDescription.SetActive(true);
        }



    }

    public void OnPointerExit(PointerEventData eventData)
    {
        itemDescription.SetActive(false);

    }
}
