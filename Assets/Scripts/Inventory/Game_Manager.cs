using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class ingameEquipment
{
    public string name = "Equipment";
    public GameObject prefab;
    public GameObject inventoryItem;
    public GameObject worldItem;
}

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager Instance;

    public int weaponID = -1;
    public int armourID = -1;

    public GameObject spawnedWeapon;
    public GameObject spawnedArmour;

    public PlayerControler PC;

    public InventorySlot[] inventorySlots;
    public Canvas interfaceCanvas;
    public Transform draggables;

    public ingameEquipment[] equipment;

    // Main //
    void Awake()
    {
        Game_Manager.Instance = this;
    }

    public void DestroyWeapon()
    {
        if (spawnedWeapon != null)
        {
            Destroy(spawnedWeapon);
        }
    }
    public void DestroyArmour()
    {
        if (spawnedArmour != null)
        {
            Destroy(spawnedArmour);
        }
    }

    public void SpawnWeapon()
    {
        DestroyWeapon();

        if (weaponID != -1)
        {
            spawnedWeapon = Instantiate(equipment[weaponID].prefab, PC.hand);
        }
    }
    public void SpawnArmour()
    {
        DestroyArmour();

        if (armourID != -1)
        {
            spawnedArmour = Instantiate(equipment[armourID].prefab, PC.body);
        }
    }
    public void PickupItem(int itemID)
    {
        bool foundSlot = false;

        for (int i = 2; i < inventorySlots.Length; i++)
        {
            if (!inventorySlots[i].isFull)
            {
                GameObject GO = Instantiate(equipment[itemID].inventoryItem, inventorySlots[i].gameObject.transform);
                inventorySlots[i].currentItem = GO.GetComponent<InventoryItem>();
                inventorySlots[i].isFull = true;
                foundSlot = true;
                break;
            }
        }

        if (foundSlot == false)
        {
            Instantiate(equipment[itemID].worldItem, PC.transform.position + new Vector3(0, 0, 0), Quaternion.identity); //CHANGE vector3
        }
    }
    public void DropItem(InventoryItem item)
    {
        Instantiate(equipment[item.itemID].worldItem, PC.transform.position + new Vector3(0, 0, 0), Quaternion.identity);
        Destroy(item.gameObject);
    }
}