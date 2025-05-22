using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class playerAnimControl : entityAnimControl
{
    public void walkCall()
    {
        anim.SetBool("isMove", false);
    }
    public void turnWalk()
    {
        anim.SetBool("isMove", true);
    }
    public override void dodgeCall()
    {
        base.dodgeCall();
        levelGlobalControl.instance.player.isDodge = false;
        anim.SetBool("isDodge", false);
    }
    public void attack()
    {
        levelGlobalControl.instance.enemy.playHurt();
        float damage;
        damage = levelGlobalControl.instance.player.playerStat.attackPower;
        levelGlobalControl.instance.enemy.GetComponent<enemyProperties>().hurt(damage);
    }
    public override void turnHurt()
    {
        if (levelGlobalControl.instance.player.playerStat.currentShield <= 0)
            base.turnHurt();
        else
        {
            levelGlobalControl.instance.player.shieldAnim.playHurt();
        }

    }
}