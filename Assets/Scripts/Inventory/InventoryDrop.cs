using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryDrop : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            InventoryItem newItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            InventorySlot OriginalSlot = newItem.originalSlot.GetComponent<InventorySlot>();

            // Revert OnDrag Changes
            newItem.canvasGroup.blocksRaycasts = true;

            if (newItem.inWeaponSlot)
            {
                OriginalSlot.currentItem = null;
                OriginalSlot.isFull = false;
                Game_Manager.Instance.weaponID = -1;
                Game_Manager.Instance.DestroyWeapon();
                Game_Manager.Instance.DropItem(newItem);
            }
            else if (newItem.inArmourSlot)
            {
                OriginalSlot.currentItem = null;
                OriginalSlot.isFull = false;
                Game_Manager.Instance.armourID = -1;
                Game_Manager.Instance.DestroyArmour();
                Game_Manager.Instance.DropItem(newItem);
            }
            else
            {
                OriginalSlot.currentItem = null;
                OriginalSlot.isFull = false;
                Game_Manager.Instance.DropItem(newItem);
            }
        }
    }
}