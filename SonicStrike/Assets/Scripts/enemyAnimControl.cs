using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class enemyAnimControl : entityAnimControl
{
    [SerializeField] private playerAnimControl pAnim;
    private Vector3 pos;
    #region ����Ҷ����ؼ�֡ƥ��
    public void setPlayerDodge()
    {
        pAnim.anim.SetBool("dodgeKey", true);
    }
    #endregion
    public void turnDodge(Vector3 pos)
    {
        anim.SetBool("isDodge", true);
        this.pos = pos; 
    }
    public void exchangePos()
    {
        levelGlobalControl.instance.enemy.transform.position = this.pos;
    }
    public void attack()
    {
        if (levelGlobalControl.instance.player.isDodge)
            return;
        levelGlobalControl.instance.player.playHurt();
        float damage;
        damage = GetComponentInParent<enemyProperties>().attackPower;
        levelGlobalControl.instance.player.GetComponent<playerProperties>().hurt(damage);
    }
}
