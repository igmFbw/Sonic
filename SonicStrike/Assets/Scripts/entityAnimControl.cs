using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class entityAnimControl : MonoBehaviour
{
    public Animator anim;

    public void attackCall()
    {
        anim.SetBool("isAttack", false);
    }
    public void hurtCall()
    {
        anim.SetBool("isHurt", false);
    }
    public virtual void dodgeCall()
    {
        anim.SetBool("isDodge", false);
    }
    public void turnDodge()
    {
        anim.SetBool("isDodge", true);
    }
    public void turnAttack()
    {
        int index = Random.Range(1, 3);
        anim.SetBool("isAttack", true);
        anim.SetInteger("attackIndex", index);
    }
    public void turnHurt()
    {
        anim.SetBool("isHurt", true);
    }
    
}
