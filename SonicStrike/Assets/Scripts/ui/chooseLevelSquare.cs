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
        SceneManager.LoadScene(levelIndex);
    }
}
