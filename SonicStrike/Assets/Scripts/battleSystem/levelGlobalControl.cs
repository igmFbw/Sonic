using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;
public class levelGlobalControl : MonoBehaviour
{
    public static levelGlobalControl instance;
    public player player;
    public enemy enemy;
    public AudioSource auidoPlayer;
    [SerializeField] private CanvasGroup blackImage;
    [SerializeField] private GameObject winUI;
    [SerializeField] private GameObject loseUI;
    public int moneyAcquire;
    [SerializeField] private RectTransform acquireItem;
    [SerializeField] private Text acquireText;
    [SerializeField] private int levelIndex;
    [SerializeField] private Slider attackSlider;
    [SerializeField] private Slider hurtSlider;
    private int attackCount;
    private int hurtCount;
    private void Awake()
    {
        instance = this;
        moneyAcquire = 0;
    }
    private void OnDestroy()
    {
        instance = null;
    }
    public void win()
    {
        blackImage.gameObject.SetActive(true);
        Sequence se = DOTween.Sequence();
        se.Append(blackImage.DOFade(1, 1).OnComplete(() => winUI.SetActive(true) ));
        se.Append(winUI.GetComponent<CanvasGroup>().DOFade(1, 1));
        if (levelIndex > playerEquip.instance.levelNum)
            playerEquip.instance.levelNumAcquire = levelIndex;
        acquireEffect();
    }
    public void lose()
    {
        blackImage.gameObject.SetActive(true);
        Sequence se = DOTween.Sequence();
        se.Append(blackImage.DOFade(1, 1).OnComplete(() => loseUI.SetActive(true)));
        se.Append(loseUI.GetComponent<CanvasGroup>().DOFade(1, 1));
        acquireEffect();
    }
    public void acquireEffect()
    {
        if (moneyAcquire <= 0)
        {
            playerEquip.instance.moneyAcquire = 0;
            return;
        }
        playerEquip.instance.moneyAcquire = moneyAcquire;
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
    public void attackClick()
    {
        attackCount += 20;
        attackSlider.value = attackCount;
    }
    public void hurtClick()
    {
        hurtCount += 20;
        hurtSlider.value = hurtCount;
    }
    public void attack()
    {
        if (attackCount >= 100)
            player.playAttack();
        attackCount = 0;
        attackSlider.value = attackCount;
    }
    public void dodge()
    {
        if (hurtCount >= 100)
            player.playDodge();
        hurtCount = 0;
        hurtSlider.value = hurtCount;
    }
}
