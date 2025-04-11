using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum playerFps
{
    idle,attack,hurt,dodge
}
public class player : MonoBehaviour
{
    [SerializeField] private Animator anim;
    public playerFps playerAction;
    private void Start()
    {
        playerAction = playerFps.idle;
    }

    #region ¶¯»­Æ÷×ª»»
    public void attackCall()
    {
        anim.SetBool("isAttack", false);
    }
    public void walkCall()
    {
        anim.SetBool("isMove", false);
    }
    public void hurtCall()
    {
        anim.SetBool("isHurt", false);
    }
    public void dodgeCall()
    {
        anim.SetBool("isDodge", false);
    }
    public void turnAttack()
    {
        anim.SetBool("isAttack", true);
    }
    public void turnWalk()
    {
        anim.SetBool("isMove", true);
    }
    public void turnHurt()
    {
        anim.SetBool("isHurt", true);
    }
    public void turnDodge()
    {
        anim.SetBool("isDodge", true);
    }
    #endregion
}
