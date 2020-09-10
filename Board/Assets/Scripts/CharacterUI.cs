using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CharacterUI : MonoBehaviour
{

    public GameObject characterUI;
    public Transform equipmentSlotsParent;
    EquipmentSlotUI[] equipSlots;
    EquipmentManager equipmentManager;
    Equipment equipment;

    public GameObject itemDescriptionParent;

    public bool charUIisActive;

    // Start is called before the first frame update
    void Start()
    {
        equipmentManager = EquipmentManager.instance;
        equipmentManager.onItemEquippedCallback += UpdateUI;
        equipment = Equipment.instance;

        equipSlots = equipmentSlotsParent.GetComponentsInChildren<EquipmentSlotUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            //Debug.Log("Pressed c");
            
            characterUI.SetActive(!characterUI.activeSelf);

        }

        if (characterUI.active == false)
        {
            
            charUIisActive = false;
        }
        else
        {
            
            charUIisActive = true;
        }
    }

    void UpdateUI()
    {
        //Debug.Log("Updating Character UI");

        //Debug.Log(equipmentManager.slotIndex);
        equipSlots[equipmentManager.slotIndex].EquipItem(equipmentManager.currentEquipmentArray[equipmentManager.slotIndex]);
    }
}
