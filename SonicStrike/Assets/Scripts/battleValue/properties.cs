using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class properties : MonoBehaviour
{
    public float maxHealth;
    public float attackPower;
    public float currentHealth;
    [SerializeField] protected healthBar healthyBar;
    protected virtual void Start()
    {
        currentHealth = maxHealth;
        healthyBar.initValue(Mathf.RoundToInt(maxHealth));
    }
    public virtual void hurt(float damage)
    {
        currentHealth -= damage;
        healthyBar.updateValue(Mathf.RoundToInt(currentHealth));
        if (currentHealth <= 0)
        {
            healthyBar.updateValue(0);
            die();
        }
    }
    public virtual void die()
    {

    }
}
