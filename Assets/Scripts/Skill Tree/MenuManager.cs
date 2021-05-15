using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [HideInInspector] private bool skillTreeInput;
    [HideInInspector] private bool inventoryInput;
    [HideInInspector] private bool menuInput;


    public GameObject skillTree;
    public bool skillTreeState;
    public bool lastSkillTreeState;


    public GameObject inventory;
    public bool inventoryState;
    public bool lastInventoryState;

    public GameObject menu;
    public bool menuState;
    public bool lastMenuState;

    // Start is called before the first frame update
    void Start()
    {
        skillTree.SetActive(false);
        inventory.SetActive(false);
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ManageSkillTree();
        ManageInventory();
        ManageMenu();
    }

    private void ManageSkillTree()
    {
        skillTreeInput = Input.GetKeyDown(KeyCode.Tab);

        if (skillTreeInput != lastSkillTreeState && lastSkillTreeState == false)
        {
            skillTreeState = true;
        }
        else if (!skillTreeInput != lastSkillTreeState && lastSkillTreeState == true)
        {
            skillTreeState = false;
        }

        skillTree.SetActive(skillTreeState);

        lastSkillTreeState = skillTreeState;

    }

    private void ManageInventory()
    {
        inventoryInput = Input.GetKeyDown(KeyCode.I);

        if (inventoryInput != lastInventoryState && lastInventoryState == false)
        {
            inventoryState = true;
        }
        else if (!inventoryInput != lastInventoryState && lastInventoryState == true)
        {
            inventoryState = false;
        }

        inventory.SetActive(inventoryState);

        lastInventoryState = inventoryState;

    }

    private void ManageMenu()
    {
        menuInput = Input.GetKeyDown(KeyCode.Escape);

        if (menuInput != lastMenuState && lastMenuState == false)
        {
            menuState = true;
        }
        else if (!menuInput != lastMenuState && lastMenuState == true)
        {
            menuState = false;
        }

        menu.SetActive(menuState);

        lastMenuState = menuState;

    }
}
