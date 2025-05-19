using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class enemyProperties : properties
{
    [SerializeField] private Image yuanShen;
    public override void hurt(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            yuanShen.color = Color.yellow;
            healthyBar.updateValue(0);
            levelGlobalControl.instance.moneyAcquire += Mathf.RoundToInt(damage);
            healthyBar.updateValue(levelGlobalControl.instance.moneyAcquire, "Point:");
        }
        else
        {
            healthyBar.updateValue(Mathf.RoundToInt(currentHealth));
        }
    }
}