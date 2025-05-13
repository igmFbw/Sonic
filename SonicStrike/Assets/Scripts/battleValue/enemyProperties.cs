using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class enemyProperties : properties
{
    public override void hurt(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
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