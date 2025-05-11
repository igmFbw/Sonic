using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainScene : MonoBehaviour
{
    [SerializeField] private AudioSource au;
    public void returnMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Update()
    {
        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            au.Play();
        }
    }
}
