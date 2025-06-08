using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum buttonType
{
    attack,hurt
}
public class beatButton : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private AudioSource audioPlayer;
    [SerializeField] private AudioClip rightSound;
    [SerializeField] private AudioClip errorSound;
    [SerializeField] private buttonType type;
    private List<aperture> apertureList;
    private void Awake()
    {
        apertureList = new List<aperture>();
    }
    public void click()
    {
        if (apertureList.Count > 0 && apertureList[0].canClick)
        {
            turnClick();
            Destroy(apertureList[0].gameObject);
            audioPlayer.clip = rightSound;
            audioPlayer.Play();
            if (type == buttonType.hurt)
                levelGlobalControl.instance.hurtClick();
            else
                levelGlobalControl.instance.attackClick();
        }
        else
        {
            turnError();
            audioPlayer.clip = errorSound;
            audioPlayer.Play();
        }
    }
    public void addAperture(aperture ap)
    {
        apertureList.Add(ap);
    }
    public void removeAperture()
    {
        apertureList.RemoveAt(0);
    }
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
