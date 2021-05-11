﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[System.Serializable]
public class Level
{
    public int experience;
    public int currentLevel;
    public Action OnLevelUp;

    public int MAX_EXP;
    public int maxLevel = 20;
    public int biomass = 0;

   public Level(int level, Action OnLvlUp)
    {
        MAX_EXP = GetXPForLevel(maxLevel);
        currentLevel = level;
        experience = GetXPForLevel(level);
        OnLevelUp = OnLvlUp;
        
    }

    public int GetXPForLevel(int level)
    {
        if (level > maxLevel)
            return 0;

        int firstPass = 0;
        int secondPass = 0;
        for(int levelCycle = 1; levelCycle < level; levelCycle++)
        {
            firstPass += (int)Math.Floor(levelCycle + (300.0f * Math.Pow(2.0f, levelCycle / 7.0f)));
            secondPass = firstPass / 4;
        }
        if (secondPass > MAX_EXP && MAX_EXP != 0)
            return MAX_EXP;

        if (secondPass < 0)
            return MAX_EXP;


        return secondPass;
    }

    public int GetLevelForXP (int exp)
    {
        if (exp > MAX_EXP)
            return MAX_EXP;

        int firstPass = 0;
        int secondPass = 0;
        for (int levelCycle = 1; levelCycle <= maxLevel; levelCycle++)
        {
            firstPass += (int)Math.Floor(levelCycle + (300.0f * Math.Pow(2.0f, levelCycle / 7.0f)));
            secondPass = firstPass / 4;

            if (secondPass > exp)
                return levelCycle;
        }

        if (exp > secondPass)
            return maxLevel;

        return 0;
    }

    public bool AddExp(int amount)
    {
        if(amount + experience < 0 || experience > MAX_EXP)
        {
            if (experience > MAX_EXP)
                experience = MAX_EXP;

            return false;
        }

        int oldLevel = GetLevelForXP(experience);
        experience += amount;
        if (oldLevel < GetLevelForXP(experience))
        {
            if (currentLevel < GetLevelForXP(experience))
            {
                currentLevel = GetLevelForXP(experience);
                biomass++;
                if (OnLevelUp != null)
                    OnLevelUp.Invoke();
                return true;
            }
        }
        return false;
    }
}
