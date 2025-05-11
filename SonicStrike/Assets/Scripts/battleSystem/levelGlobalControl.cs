using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public enum actType
{
    idle,leftAttack,leftMove,rightMove,rightAttack
}
public class levelGlobalControl : MonoBehaviour
{
    public static levelGlobalControl instance;
    public player player;
    public enemy enemy;
    public actType actFps;
    public GameObject currentAperture;
    public AudioSource auidoPlayer;
    [SerializeField] private CanvasGroup blackImage;
    [SerializeField] private GameObject winUI;
    [SerializeField] private GameObject loseUI;
    public int moneyAcquire;
    [SerializeField] private RectTransform acquireItem;
    [SerializeField] private Text acquireText;
    [SerializeField] private int levelIndex;
    private void Awake()
    {
        instance = this;
        moneyAcquire = 0;
    }
    private void Start()
    {
        actFps = actType.idle;
    }
    private void OnDestroy()
    {
        instance = null;
    }
    public void setActType(actType type)
    {
        actFps = type;
        Invoke("clearCurrentFps", .419f);
    }
    public void clearCurrentFps()
    {
        actFps = actType.idle;
    }
    public void win()
    {
        blackImage.gameObject.SetActive(true);
        Sequence se = DOTween.Sequence();
        se.Append(blackImage.DOFade(1, 1).OnComplete(() => winUI.SetActive(true) ));
        se.Append(winUI.GetComponent<CanvasGroup>().DOFade(1, 1));
        if (levelIndex > playerEquip.instance.levelNum)
            playerEquip.instance.levelNum = levelIndex;
    }
    public void lose()
    {
        blackImage.gameObject.SetActive(true);
        Sequence se = DOTween.Sequence();
        se.Append(blackImage.DOFade(1, 1).OnComplete(() => loseUI.SetActive(true)));
        se.Append(loseUI.GetComponent<CanvasGroup>().DOFade(1, 1));
    }
    public void aquireEffect()
    {
        acquireItem.gameObject.SetActive(true);
        acquireText.text = moneyAcquire.ToString();
        Sequence se = DOTween.Sequence();
        se.Append(acquireItem.DOScale(new Vector3(1, 1, 1), 1));
        se.Append(acquireItem.DOScale(new Vector3(0, 0, 0), 2));
        se.AppendCallback(() => acquireItem.gameObject.SetActive(false));
    }
    public void returnMainScene()
    {
        SceneManager.LoadScene(1);
    }
}
