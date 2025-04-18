using SonicBloom.Koreo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class musicBeatControl : MonoBehaviour
{
    #region Kore事件ID字符串
    private const string leftMoveID = "leftMove";
    private const string leftAttackID = "leftAttack";
    private const string rightMoveID = "rightMove";
    private const string rightAttackID = "rightAttack";
    #endregion
    [SerializeField] private Image lightCirclePrefab;
    [SerializeField] private GameObject lightCircleParent;
    [SerializeField] private enemy mEnemy;
    #region 按钮
    [SerializeField] private RectTransform leftMoveBu;
    [SerializeField] private RectTransform leftAttackBu;
    [SerializeField] private RectTransform rightMoveBu;
    [SerializeField] private RectTransform rightAttackBu;
    #endregion
    private void Start()
    {
        Koreographer.Instance.RegisterForEvents(leftMoveID, leftMoveBorn);
        Koreographer.Instance.RegisterForEvents(leftAttackID, leftAttackBorn);
        Koreographer.Instance.RegisterForEvents(rightMoveID, rightMoveBorn);
        Koreographer.Instance.RegisterForEvents(rightAttackID, rightAttackBorn);
    }
    #region 生成光圈与设置敌人行动序列
    private void leftMoveBorn(KoreographyEvent myEvent)
    {
        Image newImage = Instantiate(lightCirclePrefab, lightCircleParent.transform);
        newImage.rectTransform.position = leftMoveBu.position;
        levelGlobalControl.instance.currentAperture = newImage.gameObject;
        StartCoroutine(setFps(actType.leftMove, newImage));
    }
    private void leftAttackBorn(KoreographyEvent myEvent)
    {
        Image newImage = Instantiate(lightCirclePrefab, lightCircleParent.transform);
        newImage.rectTransform.position = leftAttackBu.position;
        levelGlobalControl.instance.currentAperture = newImage.gameObject;
        StartCoroutine(setFps(actType.leftAttack, newImage));
    }
    private void rightMoveBorn(KoreographyEvent myEvent)
    {
        Image newImage = Instantiate(lightCirclePrefab, lightCircleParent.transform);
        newImage.rectTransform.position = rightMoveBu.position;
        levelGlobalControl.instance.currentAperture = newImage.gameObject;
        StartCoroutine(setFps(actType.rightMove, newImage));
    }
    private void rightAttackBorn(KoreographyEvent myEvent)
    {
        Image newImage = Instantiate(lightCirclePrefab, lightCircleParent.transform);
        newImage.rectTransform.position = rightAttackBu.position;
        levelGlobalControl.instance.currentAperture = newImage.gameObject;
        StartCoroutine(setFps(actType.rightAttack, newImage));
    }
    #endregion
    private void OnDestroy()
    {
        Koreographer.Instance.ClearEventRegister();
    }
    private IEnumerator setFps(actType type,Image fps)
    {
        yield return new WaitForSeconds(.42f);
        levelGlobalControl.instance.setActType(type);
        fps.color = new Color(1,.38f,.38f);
        if(type == actType.leftMove||type == actType.rightMove)
        {
            mEnemy.playAttack();
        }
    }
}