using System.Collections;
using UnityEngine;

public class ItemPickup : Interactable
{

    public Equipment equipment;
    public override void Interact()
     {
         base.Interact();

         //pick up item 
         PickUp();
     }

     void PickUp()
     {
         Debug.Log("Pick up item " + equipment.name);

        //add to inventory
        bool wasPickedUp = Inventory.instance.Add(equipment); //the bool checks if the item is picked up by giving the method "Add" a return type oof bool

        if (wasPickedUp)
        {
            Destroy(gameObject);
        }
        
     }


}
