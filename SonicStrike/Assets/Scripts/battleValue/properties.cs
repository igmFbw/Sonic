using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class properties : MonoBehaviour
{
    [SerializeField] protected float maxHealth;
    [SerializeField] protected float attackPower;
    protected float currentHealth;
    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void hurt(float damage)
    {
        currentHealth -= damage;
    }
    public virtual void attack()
    {

    }
}
