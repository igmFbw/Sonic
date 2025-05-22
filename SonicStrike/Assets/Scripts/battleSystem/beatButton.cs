using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class beatButton : MonoBehaviour
{
    [SerializeField] private Animator anim;
    public void turnClick()
    {
        anim.SetBool("isClick", true);
    }
    public void clickCall()
    {
        anim.SetBool("isClick", false);
    }
    public void turnError()
    {
        anim.SetBool("isError", true);
    }
    public void errorCall()
    {
        anim.SetBool("isError", false);
    }
}
