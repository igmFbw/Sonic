using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class enemyProperties : properties
{
    [SerializeField] private float[] healthArr = {8000,13000,18000,23000,28000,33000,38000,43000,48000,53000};
    [SerializeField] private float[] attackArr = {25,30,35,40,45,50,55,60,65,70};
    [SerializeField] private int level;//¹Ø¿¨
    [SerializeField] private int weaponGrade;//ÎäÆ÷µÈ¼¶
    private void Awake()
    {
        InitializationAttribute();
    }

    private void InitializationAttribute()
    {
        if(level>=10)
        {
            level = 10;
        }        
        maxHealth = healthArr[level-1] + 0.15f * weaponGrade;
        attackPower = attackArr[level-1] + 0.15f * weaponGrade;
    }
}
