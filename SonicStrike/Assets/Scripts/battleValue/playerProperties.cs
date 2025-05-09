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
    //public void equip(int )
}
