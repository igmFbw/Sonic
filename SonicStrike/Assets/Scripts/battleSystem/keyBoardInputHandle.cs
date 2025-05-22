using UnityEngine;
using UnityEngine.UI;
public class keyBoardInputHandle : MonoBehaviour
{
    #region °´Å¥
    [SerializeField] private RectTransform leftMoveBuRt;
    [SerializeField] private RectTransform leftAttackBuRt;
    [SerializeField] private RectTransform rightMoveBuRt;
    [SerializeField] private RectTransform rightAttackBuRt;
    #endregion
    [SerializeField] private Image clickRightPrefab;
    [SerializeField] private Image clickErrorPrefab;
    [SerializeField] private Transform clickEffectParent;
    [SerializeField] private player mPlayer;
    private void Update()
    {
        
    }
    private void resetFps()
    {
        Destroy(levelGlobalControl.instance.currentAperture);
    }
    private void playClickEffect(Vector3 pos,Image clickEffect)
    {
        Image newImage = Instantiate(clickEffect, clickEffectParent);
        newImage.rectTransform.position = pos;
        Destroy(newImage.gameObject, .3f);
    }
}
