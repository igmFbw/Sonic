using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
public class mainMenu : MonoBehaviour
{
    [SerializeField] private Button startGameBu;
    [SerializeField] private Button exitGameBu;
    [SerializeField] private CanvasGroup blackImage;
    private void Start()
    {
        startGameBu.onClick.AddListener(() =>
        {
            blackImage.gameObject.SetActive(true);
            blackImage.DOFade(1, 2);
            StartCoroutine(changeScene());       
        });
        exitGameBu.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
    private IEnumerator changeScene()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(1);
    }
}
