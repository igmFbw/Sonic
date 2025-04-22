using UnityEngine;
using UnityEngine.UI;
public class keyBoardInputHandle : MonoBehaviour
{
    #region °´Å¥
    [SerializeField] private RectTransform leftMoveBuRt;
    [SerializeField] private RectTransform leftAttackBuRt;
    [SerializeField] private RectTransform rightMoveBuRt;
    [SerializeField] private RectTransform rightAttackBuRt;
    /*private Button leftMoveBu;
    private Button leftAttackBu;
    private Button rightMoveBu;
    private Button rightAttackBu;*/
    #endregion
    [SerializeField] private Image clickRightPrefab;
    [SerializeField] private Image clickErrorPrefab;
    [SerializeField] private Transform clickEffectParent;
    [SerializeField] private player mPlayer;
    /*private void Awake()
    {
        leftMoveBu = leftMoveBuRt.GetComponent<Button>();
        leftAttackBu = leftAttackBuRt.GetComponent<Button>();
        rightAttackBu = rightAttackBuRt.GetComponent<Button>();
        rightMoveBu = rightMoveBuRt.GetComponent<Button>();
    }*/
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (levelGlobalControl.instance.actFps == actType.leftMove)
            {
                resetFps();
                playClickEffect(leftMoveBuRt.position, clickRightPrefab);
                mPlayer.playDodge();
            }
            else
                playClickEffect(leftMoveBuRt.position, clickErrorPrefab);
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            if (levelGlobalControl.instance.actFps == actType.leftAttack)
            {
                resetFps();
                playClickEffect(leftAttackBuRt.position, clickRightPrefab);
                mPlayer.playAttack();
            }
            else
                playClickEffect(leftAttackBuRt.position, clickErrorPrefab);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            if (levelGlobalControl.instance.actFps == actType.rightMove)
            {
                resetFps();
                playClickEffect(rightMoveBuRt.position, clickRightPrefab);
                mPlayer.playDodge();
            }
            else
                playClickEffect(rightMoveBuRt.position, clickErrorPrefab);
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            if (levelGlobalControl.instance.actFps == actType.rightAttack)
            {
                resetFps();
                playClickEffect(rightAttackBuRt.position, clickRightPrefab);
                mPlayer.playAttack();
            }
            else
                playClickEffect(rightAttackBuRt.position, clickErrorPrefab);
        }
    }
    private void resetFps()
    {
        Destroy(levelGlobalControl.instance.currentAperture);
        levelGlobalControl.instance.clearCurrentFps();
    }
    private void playClickEffect(Vector3 pos,Image clickEffect)
    {
        Image newImage = Instantiate(clickEffect, clickEffectParent);
        newImage.rectTransform.position = pos;
        Destroy(newImage.gameObject, .3f);
    }
}
