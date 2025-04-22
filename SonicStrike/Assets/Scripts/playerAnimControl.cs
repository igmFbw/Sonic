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
        anim.SetBool("eDodge", false);
    }
}
