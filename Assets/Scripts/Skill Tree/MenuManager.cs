using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [HideInInspector] private bool skillTreeInput;
    [HideInInspector] private bool inventoryInput;

    public GameObject skillTree;
    private bool skillTreeState;
    private bool lastSkillTreeState;


    public GameObject inventory;
    private bool inventoryState;
    private bool lastInventoryState;

    // Start is called before the first frame update
    void Start()
    {
        skillTree.SetActive(false);
        inventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ManageSkillTree();
        ManageInventory();
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
}
