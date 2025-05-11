using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class startPlay : MonoBehaviour
{
    [SerializeField] private AudioSource au;
    [SerializeField] private AudioSource auSelf;
    public void startGame()
    {
        au.Play();
        Destroy(gameObject);
    }
    public void sound()
    {
        auSelf.Play();
    }
}
