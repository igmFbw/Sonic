using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class startPlay : MonoBehaviour
{
    [SerializeField] private AudioSource au;
    [SerializeField] private AudioSource auSelf;
    [SerializeField] private GameObject plot;
    public void startGame()
    {
        au.Play();
        plot.SetActive(false);
        Destroy(gameObject);
    }
    public void sound()
    {
        auSelf.Play();
    }
}
