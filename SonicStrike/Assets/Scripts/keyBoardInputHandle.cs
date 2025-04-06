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
    [SerializeField] private Image clickEffectPrefab;
    [SerializeField] private Transform clickEffectParent;
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
                playClickEffect(leftMoveBuRt.position);
            }
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            if (levelGlobalControl.instance.actFps == actType.leftAttack)
            {
                resetFps();
                playClickEffect(leftAttackBuRt.position);
            }
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            if (levelGlobalControl.instance.actFps == actType.rightMove)
            {
                resetFps();
                playClickEffect(rightMoveBuRt.position);
            }
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            if (levelGlobalControl.instance.actFps == actType.rightAttack)
            {
                resetFps();
                playClickEffect(rightAttackBuRt.position);
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
