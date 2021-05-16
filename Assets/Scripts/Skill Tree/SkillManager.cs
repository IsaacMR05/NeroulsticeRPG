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
        if (activateSkill != null)
        {

            if (player.level.biomass >= activateSkill.pointsToUpgrade && !activateSkill.isUpgrade)
            {
                if (activateSkill.previousSkillID == -1 && activateSkill.previousSkillID2 == -1)
                {
                    unlocked = true;

                }
                else if (skills[activateSkill.previousSkillID].isUpgrade || skills[activateSkill.previousSkillID2].isUpgrade)
                {
                    unlocked = true;
                }
                else
                {
                    unlocked = false;

                }
            }
            else
            {
                unlocked = false;

            }

            unlockButton.SetActive(unlocked);
            lockedButton.SetActive(!unlocked);
        }
    }

    public void UnlockSkill()
    {
        activateSkill.isUpgrade = true;

        player.level.biomass -= activateSkill.pointsToUpgrade;
        playerHealth.maxHealth += activateSkill.extraLife;
        playerHealth.healYouself += activateSkill.healYouself;
        playerSpeed.sprintingSpeed += activateSkill.extraSpeed;
        playerSpeed.walkingSpeed += activateSkill.extraSpeed;
    }

}
