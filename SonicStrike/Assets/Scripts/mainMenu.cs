using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class mainMenu : MonoBehaviour
{
    [SerializeField] private Button startGameBu;
    [SerializeField] private Button exitGameBu;
    [SerializeField] private GameObject blackImage;
    private void Start()
    {
        startGameBu.onClick.AddListener(() =>
        {
            blackImage.SetActive(true);
            StartCoroutine(changeScene());       
        });
        exitGameBu.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
    private IEnumerator changeScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }
}
