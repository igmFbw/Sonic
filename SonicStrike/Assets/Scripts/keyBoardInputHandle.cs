using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class keyBoardInputHandle : MonoBehaviour
{
    #region ∞¥≈•Œª÷√
    [SerializeField] private RectTransform leftMoveBu;
    [SerializeField] private RectTransform leftAttackBu;
    [SerializeField] private RectTransform rightMoveBu;
    [SerializeField] private RectTransform rightAttackBu;
    #endregion
    [SerializeField] private Image clickEffectPrefab;
    [SerializeField] private Transform clickEffectParent;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if(levelGlobalControl.instance.actFps == actType.leftMove)
            {
                resetFps();
                playClickEffect(leftMoveBu.position);
            }
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            if (levelGlobalControl.instance.actFps == actType.leftAttack)
            {
                resetFps();
                playClickEffect(leftAttackBu.position);
            }
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            if (levelGlobalControl.instance.actFps == actType.rightMove)
            {
                resetFps();
                playClickEffect(rightMoveBu.position);
            }
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            if (levelGlobalControl.instance.actFps == actType.rightAttack)
            {
                resetFps();
                playClickEffect(rightAttackBu.position);
            }
        }
    }
    private void resetFps()
    {
        Destroy(levelGlobalControl.instance.currentAperture);
        levelGlobalControl.instance.clearCurrentFps();
    }
    private void playClickEffect(Vector3 pos)
    {
        Image newImage = Instantiate(clickEffectPrefab, clickEffectParent);
        newImage.rectTransform.position = pos;
        Destroy(newImage.gameObject, .3f);
    }
}
