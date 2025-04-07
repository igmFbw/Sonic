using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class playerProperties : properties
{
    #region 能力
    [SerializeField] private int perfectCombo = 0;
    [SerializeField] private float damageBoost = 0;
    [SerializeField] private float totalDamage = 0;
    #endregion

    #region 判定系数
    enum JudgementCoefficient //判断
    {
        Perfect,
        Great,
        Miss
    }
    [SerializeField] private float perfect = 1.2f;
    [SerializeField] private float great = 0.8f;
    [SerializeField] private float miss = 0.02f;
    [SerializeField] JudgementCoefficient judgementCoefficient = JudgementCoefficient.Perfect;
    #endregion
    private void Update()
    {
        ComboCounter();
        DamageBoostCalculation();
    }

    private void DamageBoostCalculation()
    {
        damageBoost = perfectCombo / 10 * 0.05f;
        if(damageBoost > 0.5f ) 
        {
            damageBoost = 0.5f;
        }
    }

    private void ComboCounter()
    {
        if(judgementCoefficient == JudgementCoefficient.Perfect)
        {
            perfectCombo++;
        }
        else
        {
            perfectCombo = 0; 
        }
        
    }

    public void Atttack(float judge)
    {
        totalDamage = attackPower * judge;
        totalDamage += totalDamage * damageBoost;
    }
    public void Evade(float damage)
    {
        switch (judgementCoefficient)
        {
            case JudgementCoefficient.Perfect://不会受到伤害
                break;
            case JudgementCoefficient.Great://擦伤 10%
                maxHealth -= damage * 0.1f;
                break;
            case JudgementCoefficient.Miss:
                maxHealth -= damage;
                break;
        }
    }


}
