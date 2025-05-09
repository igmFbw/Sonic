using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class playerProperties : properties
{
    public float maxShield;
    public float currentShield;
    [SerializeField] private healthBar shieldBar;
    protected override void Start()
    {
        base.Start();
        if (playerEquip.instance.weapnEquip != null)
        {
            if (playerEquip.instance.weapnEquip.durability > 0)
                attackPower += playerEquip.instance.weapnEquip.power;
        }
        if (playerEquip.instance.shieldEquip != null)
        {
            if (playerEquip.instance.shieldEquip.durability > 0)
            {
                currentShield = playerEquip.instance.shieldEquip.basicData.basicPower;
                shieldBar.initValue(Mathf.RoundToInt(maxHealth));
            }

        }
    }
    public override void die()
    {
        levelGlobalControl.instance.auidoPlayer.Stop();
        levelGlobalControl.instance.lose();
    }

    public override void hurt(float damage)
    {
        if (currentShield <= 0)
            base.hurt(damage);
        else
        {
            currentShield -= damage;
            if (currentShield <= 0)
                levelGlobalControl.instance.player.shieldAnim.playDisappear();
            shieldBar.updateValue(Mathf.RoundToInt(currentShield),"shield: ");
        }
    }
}
