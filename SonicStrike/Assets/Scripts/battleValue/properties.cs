using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class properties : MonoBehaviour
{
    public float maxHealth;
    public float attackPower;
    protected float currentHealth;
    [SerializeField] private healthBar healthyBar;
    protected virtual void Start()
    {
        currentHealth = maxHealth;
        healthyBar.initValue(Mathf.FloorToInt(maxHealth));
    }
    public void hurt(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            die();
        }
        healthyBar.updateValue(Mathf.FloorToInt(currentHealth));
    }
    public virtual void die()
    {

    }
}
