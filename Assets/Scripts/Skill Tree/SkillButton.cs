using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    public Image skillImage;
    public Text skillNameText;
    public Text skillDesText;
    private Image buttonImage;


    public int skillButtonId;

    public Skill skill;
    void Start()
    {
        buttonImage = GetComponent<Image>();
    }

    void Awake()
    {
        skillButtonId = skill.skillID;
    }

    void Update()
    {
        if (!skill.isUpgrade)
        {
            buttonImage.color = Color.gray;
        }
        else
        {
            buttonImage.color = Color.white;
        }
    }
    public void PressSkillButton()
    {

        Debug.Log(skill.name);
        SkillManager.instance.activateSkill = skill;
        skillImage.sprite = skill.skillSprite;
        skillNameText.text = skill.skillName;
        skillDesText.text = skill.skillDes;
    }
}
