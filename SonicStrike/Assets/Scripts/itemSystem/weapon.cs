using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class weapon
{
    public weaponData basicData;
    public int durability;
    public int power;
    public int level;
    public int experience;
    public int currExperience;
    public int upGradeCost;
    public int calculateExp()
    {
        return 500 * level * level - 500 * level + 2000;
    }
    public bool upGrade(int experienceCost)
    {
        if (experienceCost > currExperience)
            return false;
        experience -= experienceCost;
        level++;
            power += 5;
        return true;
    }
}
