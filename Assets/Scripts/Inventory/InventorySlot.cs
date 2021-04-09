using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public InventoryItem currentItem;
    public bool weaponSlot = false;
    public bool armourSlot = false;
    public bool isFull = false;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            InventoryItem newItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            InventorySlot OriginalSlot = newItem.originalSlot.GetComponent<InventorySlot>();

            //Original Slot != This Slot
            if (newItem.originalSlot != this.transform)
            {
                //Slot == full
                if (isFull)
                {
                    //Dragging into weapon slot from normal slot
                    if (weaponSlot && newItem.equipType == 1 && OriginalSlot.currentItem.equipType == 1)
                    {
                        Debug.Log("Dropped Item: Full Weapon Slot");

                        //Swapping InventoryItem:currentItem
                        InventoryItem swapCurrent = currentItem;
                        currentItem = newItem;
                        OriginalSlot.currentItem = swapCurrent;

                        //Swapping InventoryItem:inWeaponSlot
                        currentItem.inWeaponSlot = true;
                        OriginalSlot.currentItem.inWeaponSlot = false;

                        //Swapping Parent
                        eventData.pointerDrag.transform.SetParent(gameObject.transform);
                        OriginalSlot.currentItem.transform.SetParent(OriginalSlot.transform);
                        OriginalSlot.currentItem.originalSlot = OriginalSlot.transform;

                        //Spawning Weapon
                        Game_Manager.Instance.weaponID = currentItem.itemID;
                        Game_Manager.Instance.SpawnWeapon();
                    }

                    //Dragging into armour slot from normal slot
                    else if (armourSlot && newItem.equipType == 2 && OriginalSlot.currentItem.equipType == 2)
                    {
                        Debug.Log("Dropped Item: Full Armour Slot");

                        //Swapping InventoryItem:currentItem
                        InventoryItem swapCurrent = currentItem;
                        currentItem = newItem;
                        OriginalSlot.currentItem = swapCurrent;

                        //Swapping InventoryItem:inArmourSlot
                        currentItem.inArmourSlot = false;
                        OriginalSlot.currentItem.inArmourSlot = true;

                        //Swapping Parent
                        eventData.pointerDrag.transform.SetParent(gameObject.transform);
                        OriginalSlot.currentItem.transform.SetParent(OriginalSlot.transform);
                        OriginalSlot.currentItem.originalSlot = OriginalSlot.transform;

                        //Spawning Armour
                        Game_Manager.Instance.armourID = OriginalSlot.currentItem.itemID;
                        Game_Manager.Instance.SpawnArmour();
                    }

                    //Dragging into normal slot from weapon slot
                    else if (!weaponSlot && currentItem.equipType == 1 && newItem.equipType == 1 && newItem.inWeaponSlot)
                    {
                        Debug.Log("Dropped Item: Full Weapon Slot [Other]");

                        // Swapping InventoryItem:currentItem 
                        InventoryItem swapCurrent = currentItem;
                        currentItem = newItem;
                        OriginalSlot.currentItem = swapCurrent;

                        // Swapping InventoryItem:inWeaponSlot
                        currentItem.inWeaponSlot = false;
                        OriginalSlot.currentItem.inWeaponSlot = true;

                        // Swapping Parent
                        eventData.pointerDrag.transform.SetParent(gameObject.transform);
                        OriginalSlot.currentItem.transform.SetParent(OriginalSlot.transform);
                        OriginalSlot.currentItem.originalSlot = OriginalSlot.transform;

                        // Spawning Weapon
                        Game_Manager.Instance.weaponID = OriginalSlot.currentItem.itemID;
                        Game_Manager.Instance.SpawnWeapon();
                    }

                    // Dragging into normal slot from armour slot
                    else if (!armourSlot && currentItem.equipType == 2 && newItem.equipType == 2 && newItem.inArmourSlot)
                    {
                        Debug.Log("Dropped Item: Full Armour Slot [Other]");

                        // Swapping InventoryItem:currentItem 
                        InventoryItem swapCurrent = currentItem;
                        currentItem = newItem;
                        OriginalSlot.currentItem = swapCurrent;

                        // Swapping InventoryItem:inArmourSlot
                        currentItem.inArmourSlot = false;
                        OriginalSlot.currentItem.inArmourSlot = true;

                        // Swapping Parent
                        eventData.pointerDrag.transform.SetParent(gameObject.transform);
                        OriginalSlot.currentItem.transform.SetParent(OriginalSlot.transform);
                        OriginalSlot.currentItem.originalSlot = OriginalSlot.transform;

                        // Spawning Armour
                        Game_Manager.Instance.armourID = OriginalSlot.currentItem.itemID;
                        Game_Manager.Instance.SpawnArmour();
                    }

                    // Slot swapping in inventory
                    else if (!OriginalSlot.currentItem.inArmourSlot && !OriginalSlot.currentItem.inWeaponSlot && !currentItem.inWeaponSlot && !currentItem.inArmourSlot)
                    {
                        Debug.Log("Dropped Item: Full Inventory Slot");

                        // Swapping InventoryItem:currentItem 
                        InventoryItem swapCurrent = currentItem;
                        currentItem = newItem;
                        OriginalSlot.currentItem = swapCurrent;

                        // Swapping Parent
                        eventData.pointerDrag.transform.SetParent(gameObject.transform);
                        OriginalSlot.currentItem.transform.SetParent(OriginalSlot.transform);
                        OriginalSlot.currentItem.originalSlot = OriginalSlot.transform;
                    }
                    // Returning To Original Slot
                    else
                    {
                        Debug.Log("Dropped Item: Returning to original slot");
                    }
                }

                // Slot != Full //
                else if (!isFull)
                {
                    // Moving Into Weapon Slot
                    if (weaponSlot && newItem.equipType == 1)
                    {
                        Debug.Log("Dropped Item: Empty Weapon Slot");

                        // Emptying Original Slot
                        OriginalSlot.isFull = false;
                        OriginalSlot.currentItem = null;

                        // Filling This Slot
                        isFull = true;
                        currentItem = newItem;
                        currentItem.inWeaponSlot = true;

                        // Swapping Parents
                        eventData.pointerDrag.transform.SetParent(gameObject.transform);
                        currentItem.originalSlot = this.transform;

                        // Spawning Weapon
                        Game_Manager.Instance.weaponID = currentItem.itemID;
                        Game_Manager.Instance.SpawnWeapon();
                    }
                    // Moving Into Armour Slot
                    else if (armourSlot && newItem.equipType == 2)
                    {
                        Debug.Log("Dropped Item: Empty Armour Slot");

                        // Emptying Original Slot
                        OriginalSlot.isFull = false;
                        OriginalSlot.currentItem = null;

                        // Filling This Slot
                        isFull = true;
                        currentItem = newItem;
                        currentItem.inArmourSlot = true;

                        // Swapping Parents
                        eventData.pointerDrag.transform.SetParent(gameObject.transform);
                        currentItem.originalSlot = this.transform;

                        // Spawning Armour
                        Game_Manager.Instance.armourID = currentItem.itemID;
                        Game_Manager.Instance.SpawnArmour();

                    }
                    // Moving Out Of Weapon Slot
                    else if (OriginalSlot.weaponSlot == true && newItem.inWeaponSlot == true && !armourSlot)
                    {
                        Debug.Log("Dropped Item: Empty Inventory Slot");

                        // Emptying Original Slot
                        OriginalSlot.isFull = false;
                        OriginalSlot.currentItem = null;

                        // Filling This Slot
                        isFull = true;
                        currentItem = newItem;
                        currentItem.inWeaponSlot = false;

                        // Swapping Parents
                        eventData.pointerDrag.transform.SetParent(gameObject.transform);
                        currentItem.originalSlot = this.transform;

                        // Destroying Weapon
                        Game_Manager.Instance.weaponID = -1;
                        Game_Manager.Instance.DestroyWeapon();
                    }
                    // Moving Out Of Armour Slot
                    else if (OriginalSlot.armourSlot == true && newItem.inArmourSlot == true && !weaponSlot)
                    {
                        Debug.Log("Dropped Item: Empty Inventory Slot");

                        // Emptying Original Slot
                        OriginalSlot.isFull = false;
                        OriginalSlot.currentItem = null;

                        // Filling This Slot
                        isFull = true;
                        currentItem = newItem;
                        currentItem.inArmourSlot = false;

                        // Swapping Parents
                        eventData.pointerDrag.transform.SetParent(gameObject.transform);
                        currentItem.originalSlot = this.transform;

                        // Destroying Weapon
                        Game_Manager.Instance.armourID = -1;
                        Game_Manager.Instance.DestroyArmour();
                    }
                    // Moving To Empty Slot
                    else if (!OriginalSlot.armourSlot && !armourSlot && !OriginalSlot.weaponSlot && !weaponSlot)
                    {
                        // Emptying Original Slot
                        OriginalSlot.isFull = false;
                        OriginalSlot.currentItem = null;

                        // Filling This Slot
                        isFull = true;
                        currentItem = newItem;

                        // Swapping Parents
                        eventData.pointerDrag.transform.SetParent(gameObject.transform);
                        currentItem.originalSlot = this.transform;
                    }
                    // Returning to Original Slot
                    else
                    {
                        Debug.Log("Dropped Item: Returning to original slot");
                    }
                }
            }
        }
    }
}
