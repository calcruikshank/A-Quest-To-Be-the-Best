using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{

    #region Singleton
    public static EquipmentManager instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    public delegate void OnItemEquipped();
    public OnItemEquipped onItemEquippedCallback;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    public int slotIndex;

    public Equipment[] currentEquipmentArray;

    public ChangeTextToItemDescription changeText;

    void Start()
    {
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipmentArray = new Equipment[numSlots];
    }

    public void Equip(Equipment newItem)
    {
        slotIndex = (int)newItem.equipSlot;

        Equipment oldItem = null;

        if(currentEquipmentArray[slotIndex] != null)
        {
            oldItem = currentEquipmentArray[slotIndex];
            Inventory.instance.Add(oldItem); //you can make inventory.instance a variable with inventory = Inventory.instance and just call inventory.Add();
           
        }

        currentEquipmentArray[slotIndex] = newItem;

        if (onItemEquippedCallback != null)
        {
            onItemEquippedCallback.Invoke();
        }
        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }
    }

}
