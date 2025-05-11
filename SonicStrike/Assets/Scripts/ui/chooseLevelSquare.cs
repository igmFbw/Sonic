using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class chooseLevelSquare : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] private int levelIndex;
    [SerializeField] private GameObject lockImage;
    private void OnEnable()
    {
        if (levelIndex - 2 > playerEquip.instance.levelNum)
            lockImage.SetActive(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (levelIndex - 2 > playerEquip.instance.levelNum)
        {
            uiSthConrtol.instance.setTip("请先通过前置关卡");
            return;
        }
        uiSthConrtol.instance.blackImage.SetActive(true);
        StartCoroutine(changeScene());
    }
    private IEnumerator changeScene()
    {
        uiSthConrtol.instance.saveManage.saveGame();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(levelIndex);
    }
}
