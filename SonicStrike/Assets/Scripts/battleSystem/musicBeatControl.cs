using DG.Tweening;
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
    private const string exchangePosID = "exchangePos";
    private const string levelEndID = "levelEnd";
    #endregion
    [SerializeField] private Image lightCirclePrefab;
    [SerializeField] private GameObject lightCircleParent;
    [SerializeField] private enemy mEnemy;
    [SerializeField] private Transform came;
    [SerializeField] private Transform cameraLeftPos;
    [SerializeField] private Transform enemyLeftPos;
    [SerializeField] private Transform enemyRightPos;
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
        Koreographer.Instance.RegisterForEvents(exchangePosID, changeDir);
        Koreographer.Instance.RegisterForEvents(levelEndID, levelEnd);
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
        fps.color = new Color(1,.38f,.38f);
        levelGlobalControl.instance.setActType(type);
        if (type == actType.leftMove||type == actType.rightMove)
        {
            mEnemy.playAttack();
        }
    }
    public void changeDir(KoreographyEvent myEvent)
    {
        if(came.position == new Vector3(0,0,-10))
        {
            came.DOMove(cameraLeftPos.position, 1.5f);
            levelGlobalControl.instance.player.transform.eulerAngles = new Vector3(0, 0, 0);
            levelGlobalControl.instance.enemy.transform.eulerAngles = new Vector3(0, 0, 0);
            levelGlobalControl.instance.enemy.playDodge(enemyLeftPos.position);
        }
        else
        {
            came.DOMove(new Vector3(0,0,-10), 1.5f);
            levelGlobalControl.instance.player.transform.eulerAngles = new Vector3(0, 180, 0);
            levelGlobalControl.instance.enemy.transform.eulerAngles = new Vector3(0, 180, 0);
            levelGlobalControl.instance.enemy.playDodge(enemyRightPos.position);
        }
    }
    public void levelEnd(KoreographyEvent myEvent)
    {
        if (levelGlobalControl.instance.enemy.prop.currentHealth >= 0)
        {
            levelGlobalControl.instance.lose();
        }
        else
        {
            levelGlobalControl.instance.win();
        }
    }
}