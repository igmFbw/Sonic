using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
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
        damage = GetComponentInParent<playerProperties>().attackPower;
        levelGlobalControl.instance.enemy.GetComponent<enemyProperties>().hurt(damage);
    }
}