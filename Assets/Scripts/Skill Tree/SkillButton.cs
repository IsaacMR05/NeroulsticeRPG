using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    public Image skillImage;
    public Text skillNameText;
    public Text skillDesText;

    public int skillButtonId;

    public Skill skill;

    void Awake()
    {
        skillButtonId = skill.skillID;
    }
    public void PressSkillButton()
    {
        /*
        SkillManager.instance.activateSkill = skill;
        skillImage.sprite = SkillManager.instance.skills[skillButtonId].skillSprite;
        skillNameText.text = SkillManager.instance.skills[skillButtonId].skillName;
        skillDesText.text = SkillManager.instance.skills[skillButtonId].skillDes;
        */
        Debug.Log(skill.name);
        SkillManager.instance.activateSkill = skill;
        skillImage.sprite = skill.skillSprite;
        skillNameText.text = skill.skillName;
        skillDesText.text = skill.skillDes;
    }
}
