using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class mainMenu : MonoBehaviour
{
    [SerializeField] private Button startGameBu;
    [SerializeField] private Button loadGameBu;
    [SerializeField] private Button exitGameBu;
    private void Start()
    {
        startGameBu.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(1);          
        });
        loadGameBu.onClick.AddListener(() =>
        {
            
        });
        exitGameBu.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
}
