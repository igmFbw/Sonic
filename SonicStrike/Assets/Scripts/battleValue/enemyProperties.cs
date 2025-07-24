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
        if(currentHealth == 0)
        {
            healthyBar.updateValue(0);
        }
        else if (currentHealth < 0)
        {
            yuanShen.color = Color.yellow;
            levelGlobalControl.instance.moneyAcquire += Mathf.RoundToInt(damage);
            if (levelGlobalControl.instance.moneyAcquire > maxHealth)
                levelGlobalControl.instance.moneyAcquire = Mathf.RoundToInt(maxHealth);
            healthyBar.updateValue(levelGlobalControl.instance.moneyAcquire, "Point:");
        }
        else
        {
            healthyBar.updateValue(Mathf.RoundToInt(currentHealth));
        }
    }
}