using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainScene : MonoBehaviour
{
    [SerializeField] private AudioSource au;
    public static int choose = 0;
    public static int sceneControl = 0;
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
