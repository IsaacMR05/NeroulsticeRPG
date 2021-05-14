using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;

    public Skill[] skills;
    public SkillButton[] skillButtons;
    public GameObject unlockButton;
    public GameObject lockedButton;
    private bool unlocked = false;
    public Player player;
    public Health_Manager playerHealth;
    public PlayerControler playerSpeed;

   public Skill activateSkill;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
        
        
    }

    void Update()
    {
        ShowUnlockButton();

    }

    private void ShowUnlockButton()
    {
        Debug.Log(activateSkill.name);
        if (player.level.biomass >= activateSkill.pointsToUpgrade && !activateSkill.isUpgrade)
        {
            if (activateSkill.previousSkillID == -1 && activateSkill.previousSkillID2 == -1)
            {
                unlocked = true;
                Debug.Log("true");

            }
            else if (skills[activateSkill.previousSkillID].isUpgrade || skills[activateSkill.previousSkillID2].isUpgrade)
            {
                unlocked = true;
                Debug.Log("true 2");
            }
            else
            {
                unlocked = false;
                Debug.Log("false");

            }
        }
        else
        {
            unlocked = false;
            Debug.Log("false 2");

        }
        Debug.Log("ShowUnlockButton");

        unlockButton.SetActive(unlocked);
        lockedButton.SetActive(!unlocked);

    }

    public void UnlockSkill()
    {
        activateSkill.isUpgrade = true;

        player.level.biomass -= activateSkill.pointsToUpgrade;
        playerHealth.maxHealth += activateSkill.extraLife;
        playerSpeed.maxSpeed += activateSkill.extraSpeed;
    }

}
