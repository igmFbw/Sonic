using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class chooseLevelSquare : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] private int levelIndex;

    public void OnPointerClick(PointerEventData eventData)
    {
        uiSthConrtol.instance.blackImage.SetActive(true);
        StartCoroutine(changeScene());
    }
    private IEnumerator changeScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(levelIndex);
    }
}
