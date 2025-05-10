using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainScene : MonoBehaviour
{
    public void returnMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
