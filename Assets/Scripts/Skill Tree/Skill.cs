using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewSkill", menuName = "TheXIncident/Skills/NewSkill", order = 1)]
public class Skill : ScriptableObject
{

    public string skillName;
    public int pointsToUpgrade;
    public int skillID;
    public int previousSkillID;
    public int previousSkillID2;
    public Sprite skillSprite;

    [TextArea(1, 3)]
    public string skillDes;
    public bool isUpgrade;


    public int extraLife;
    public int extraSpeed;
    public int extraDamage;
    public int healYouself;

    void Awake()
    {
        isUpgrade = false;
    }

}
