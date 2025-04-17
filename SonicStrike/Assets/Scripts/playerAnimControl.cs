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
}
