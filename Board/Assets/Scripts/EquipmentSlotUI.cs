using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EquipmentSlotUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image icon;
    Equipment equipment;
    
    public GameObject itemDescription;
    public ChangeTextToItemDescription changeText;

    public Transform itemDescriptionTransform;

    // Start is called before the first frame update
    void Start()
    {
        itemDescription.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EquipItem(Equipment newEquipment)
    {
        equipment = newEquipment;
        icon.sprite = equipment.icon;
        icon.enabled = true;
        //removeButton.interactable = true;
        
        itemDescription = Instantiate(itemDescription, new Vector3(transform.position.x + 250, transform.position.y, itemDescriptionTransform.position.z), Quaternion.identity, itemDescriptionTransform);
        changeText = itemDescription.GetComponent<ChangeTextToItemDescription>();
        changeText.ChangeElements(newEquipment);
        itemDescription.SetActive(false);

    }

    public void ClearSlot()
    {
        equipment = null;

        icon.sprite = null;
        icon.enabled = false;
        //removeButton.interactable = false;
        itemDescription.SetActive(false);
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (equipment != null)
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


