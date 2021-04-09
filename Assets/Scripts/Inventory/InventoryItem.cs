using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerClickHandler
{
    RectTransform rectTransform;
    public CanvasGroup canvasGroup;
    public Transform originalSlot;

    public bool inArmourSlot = false;
    public bool inWeaponSlot = false;
    public int itemID;
    public int equipType = 0; // 0 = None | 1 = Weapon | 2 = Armour //

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / Game_Manager.Instance.interfaceCanvas.scaleFactor;
        gameObject.transform.SetParent(Game_Manager.Instance.draggables);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        rectTransform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
        originalSlot = transform.parent.transform;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        // Revert State //
        canvasGroup.blocksRaycasts = true;
        rectTransform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
        if (transform.parent == Game_Manager.Instance.draggables)
        {
            transform.SetParent(originalSlot);
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right && !eventData.dragging)
        {
            InventorySlot currentSlot = transform.parent.GetComponent<InventorySlot>();

            // If this item is in the weapon slot
            if (currentSlot.weaponSlot)
            {
                for (int i = 2; i < Game_Manager.Instance.inventorySlots.Length; i++)
                {
                    Debug.Log("Searching for Slot...");
                    if (Game_Manager.Instance.inventorySlots[i].isFull == false)
                    {
                        Debug.Log("Found slot: " + Game_Manager.Instance.inventorySlots[i].name);

                        // Emptying Previous Slot
                        currentSlot.isFull = false;
                        currentSlot.currentItem = null;

                        // Occupying New Slot
                        Game_Manager.Instance.inventorySlots[i].currentItem = this;
                        Game_Manager.Instance.inventorySlots[i].isFull = true;

                        // Changing 
                        inWeaponSlot = false;
                        transform.SetParent(Game_Manager.Instance.inventorySlots[i].transform);
                        Game_Manager.Instance.DestroyWeapon();

                        break;
                    }
                }
            }
            // If this item is in the armour slot
            if (currentSlot.armourSlot)
            {
                for (int i = 2; i < Game_Manager.Instance.inventorySlots.Length; i++)
                {
                    Debug.Log("Searching for Slot...");
                    if (Game_Manager.Instance.inventorySlots[i].isFull == false)
                    {
                        Debug.Log("Found slot: " + Game_Manager.Instance.inventorySlots[i].name);

                        // Emptying Previous Slot
                        currentSlot.isFull = false;
                        currentSlot.currentItem = null;

                        // Occupying New Slot
                        Game_Manager.Instance.inventorySlots[i].currentItem = this;
                        Game_Manager.Instance.inventorySlots[i].isFull = true;

                        // Changing 
                        inArmourSlot = false;
                        transform.SetParent(Game_Manager.Instance.inventorySlots[i].transform);
                        Game_Manager.Instance.DestroyArmour();

                        break;
                    }
                }
            }
            // If this item is NOT in the weapon slot and Equip Type == Weapon
            else if (!currentSlot.weaponSlot && equipType == 1)
            {
                if (Game_Manager.Instance.inventorySlots[0].isFull)
                {
                    // Setting Inventory Slot
                    currentSlot.currentItem = Game_Manager.Instance.inventorySlots[0].currentItem;
                    currentSlot.currentItem.inWeaponSlot = false;
                    currentSlot.currentItem.gameObject.transform.SetParent(currentSlot.transform);

                    // Setting Weapon Slot
                    Game_Manager.Instance.inventorySlots[0].currentItem = this;
                    inWeaponSlot = true;
                    gameObject.transform.SetParent(Game_Manager.Instance.inventorySlots[0].transform);
                    Game_Manager.Instance.weaponID = itemID;
                    Game_Manager.Instance.SpawnWeapon();
                }
                else
                {
                    // Resetting Old Slot
                    currentSlot.currentItem = null;
                    currentSlot.isFull = false;

                    // Setting Weapon Slot
                    Game_Manager.Instance.inventorySlots[0].currentItem = this;
                    Game_Manager.Instance.inventorySlots[0].isFull = true;
                    inWeaponSlot = true;
                    gameObject.transform.SetParent(Game_Manager.Instance.inventorySlots[0].transform);
                    Game_Manager.Instance.weaponID = itemID;
                    Game_Manager.Instance.SpawnWeapon();
                }
            }
            // If this item is NOT in the armour slot and Equip Type == Armour
            else if (!currentSlot.armourSlot && equipType == 2)
            {
                if (Game_Manager.Instance.inventorySlots[1].isFull)
                {
                    // Setting Inventory Slot
                    currentSlot.currentItem = Game_Manager.Instance.inventorySlots[1].currentItem;
                    currentSlot.currentItem.inArmourSlot = false;
                    currentSlot.currentItem.gameObject.transform.SetParent(currentSlot.transform);

                    // Setting Weapon Slot
                    Game_Manager.Instance.inventorySlots[1].currentItem = this;
                    inArmourSlot = true;
                    transform.SetParent(Game_Manager.Instance.inventorySlots[1].transform);
                    Game_Manager.Instance.armourID = itemID;
                    Game_Manager.Instance.SpawnArmour();
                }
                else
                {
                    // Resetting Old Slot
                    currentSlot.currentItem = null;
                    currentSlot.isFull = false;

                    // Setting Weapon Slot
                    Game_Manager.Instance.inventorySlots[1].currentItem = this;
                    Game_Manager.Instance.inventorySlots[1].isFull = true;
                    inArmourSlot = true;
                    gameObject.transform.SetParent(Game_Manager.Instance.inventorySlots[1].transform);
                    Game_Manager.Instance.armourID = itemID;
                    Game_Manager.Instance.SpawnArmour();
                }
            }
        }
    }
}