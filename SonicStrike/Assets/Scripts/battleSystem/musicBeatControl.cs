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
    private const string attackID = "attack";
    private const string dodgeID = "dodge";
    private const string levelEndID = "levelEnd";
    #endregion
    [SerializeField] private aperture lightCirclePrefab;
    [SerializeField] private enemy mEnemy;
    [SerializeField] private Transform came;
    [SerializeField] private Transform cameraLeftPos;
    [SerializeField] private Transform enemyLeftPos;
    [SerializeField] private Transform enemyRightPos;
    #region 按钮
    [SerializeField] private beatButton leftMoveBu;
    [SerializeField] private beatButton leftAttackBu;
    [SerializeField] private beatButton rightMoveBu;
    [SerializeField] private beatButton rightAttackBu;
    #endregion
    private void Start()
    {
        Koreographer.Instance.RegisterForEvents(leftMoveID, leftMoveBorn);
        Koreographer.Instance.RegisterForEvents(leftAttackID, leftAttackBorn);
        Koreographer.Instance.RegisterForEvents(rightMoveID, rightMoveBorn);
        Koreographer.Instance.RegisterForEvents(rightAttackID, rightAttackBorn);
        Koreographer.Instance.RegisterForEvents(exchangePosID, changeDir);
        Koreographer.Instance.RegisterForEvents(levelEndID, levelEnd);
        Koreographer.Instance.RegisterForEvents(attackID, playerAttack);
        Koreographer.Instance.RegisterForEvents(dodgeID, playerDodge);
    }
    #region 生成光圈与设置敌人行动序列
    private void leftMoveBorn(KoreographyEvent myEvent)
    {
        aperture go = Instantiate(lightCirclePrefab, leftMoveBu.transform);
        go.transform.position = leftMoveBu.transform.position;
        go.setBu(leftMoveBu);
        leftMoveBu.addAperture(go);
    }
    private void leftAttackBorn(KoreographyEvent myEvent)
    {
        aperture go = Instantiate(lightCirclePrefab, leftAttackBu.transform);
        go.transform.position = leftAttackBu.transform.position;
        go.setBu(leftAttackBu);
        leftAttackBu.addAperture(go);
    }
    private void rightMoveBorn(KoreographyEvent myEvent)
    {
        aperture go = Instantiate(lightCirclePrefab, rightMoveBu.transform);
        go.transform.position = rightMoveBu.transform.position;
        go.setBu(rightMoveBu);
        rightMoveBu.addAperture(go);
    }
    private void rightAttackBorn(KoreographyEvent myEvent)
    {
        aperture go = Instantiate(lightCirclePrefab, rightAttackBu.transform);
        go.transform.position = rightAttackBu.transform.position;
        go.setBu(rightAttackBu);
        rightAttackBu.addAperture(go);
    }
    private void playerAttack(KoreographyEvent myEvent)
    {
        levelGlobalControl.instance.attack();
    }
    private void playerDodge(KoreographyEvent myEvent)
    {
        levelGlobalControl.instance.dodge();
    }
    #endregion
    private void OnDestroy()
    {
        Koreographer.Instance.ClearEventRegister();
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
        playerEquip.instance.isBattle = true;
    }
}