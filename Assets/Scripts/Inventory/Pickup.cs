using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    //!!!THIS!!!
    //     |
    //     v
    //##################################################
    public int itemID; //Variable that we will use to determine what this item is. Example -> ID: 0 = Knife/Scalpel
    //##################################################
    //     ^
    //     |
    //!!!THIS!!!

    void OnTriggerStay2D(Collider2D other) //Maybe try and change "OnTriggerStay2D" to "OnTrigger2D". Could solve the item pickup collision bug.
    {
        if (other.gameObject == Game_Manager.Instance.PC.gameObject)
        {
            if (Input.GetKeyDown(KeyCode.E)) //When the 'E' key (doesn't matter if it's with caps or not) is pressed.
            {
                Game_Manager.Instance.PickupItem(itemID); //We move the item to the inventory.
                Destroy(gameObject); //We destroy the picked-up item.
            }
        }
    }
}