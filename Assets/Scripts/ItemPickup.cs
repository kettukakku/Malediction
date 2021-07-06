using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
   public Item item;

   void PickUp ()
   {
       Debug.Log("Picked up " + item.name);
       bool wasPickedUp = Inventory.instance.Add(item);
   }
}
