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
    public int upGradeCost;
    public void  calculateExp()
    {
        upGradeCost =  500 * level * level - 500 * level + 2000;
    }
    public void upGrade()
    {
        level++;
        power += 5;
        calculateExp();
    }
}
