using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class shieldAnimControl : MonoBehaviour
{
    [SerializeField] private Animator anim;
    public void hurtCalled()
    {
        anim.SetBool("isHurt", false);
    }
    public void playHurt()
    {
        anim.SetBool("isHurt", true);
    }
    public void playDisappear()
    {
        anim.SetBool("isDisappear", true);
    }
}