using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum equipType
{
    weapon,shield
}
public class equipData : MonoBehaviour
{
    public equipType type;
    public Sprite itemSprite;
    public string itemName;
    public float durability;
    public float power;
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
        if (type == equipType.weapon)
            power += 5;
        else
            power *= 2;
        return true;
    }
}