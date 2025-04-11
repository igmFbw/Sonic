using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class entityAnimControl
{
    [SerializeField] protected Animator anim;
    public Action attackEnd;
    public Action hurtEnd;
    public void stopAttack()
    {
        attackEnd?.Invoke();
    }
    public void stopHurt()
    {
        hurtEnd?.Invoke();
    }
}
