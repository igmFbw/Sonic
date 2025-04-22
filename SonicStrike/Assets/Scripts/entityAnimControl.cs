using System;
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
        anim.SetBool("isAttack", true);
    }
    public void turnHurt()
    {
        anim.SetBool("isHurt", true);
    }
    
}
