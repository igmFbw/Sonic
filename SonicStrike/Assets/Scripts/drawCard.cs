using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class drawCard : MonoBehaviour
{
    [SerializeField] private Transform turnTable;     
    [SerializeField] private List<equipData> cardList; 
    [SerializeField] private float spinDuration = 4f; 
    [SerializeField] private AnimationCurve spinCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    private equipData selectedItem;
    private bool isSpin = false;
    [SerializeField] private CanvasGroup acquireCg;
    [SerializeField] private RectTransform acquireRt;
    [SerializeField] private Image aquireSprite;
    private void OnEnable()
    {
        isSpin = false;
    }
    private int computeChance()
    {
        int num = Random.Range(0, 101);
        int n = playerEquip.instance.levelNum;
        if (n == 0)
        {
            if (num <= 50) return 1;
            else if (num <= 80) return 2;
            else if (num <= 95) return 3;
            else if (num <= 98) return 4;
            else return 5;
        }
        else if (n == 1)
        {
            if (num <= 16) return 1;
            else if (num <= 66) return 2;
            else if (num <= 89) return 3;
            else if (num <= 95) return 4;
            else return 5;
        }
        else if (n == 2)
        {
            if (num <= 10) return 1;
            else if (num <= 34) return 2;
            else if (num <= 84) return 3;
            else if (num <= 92) return 4;
            else return 5;
        }
        else
        {
            if (num <= 4) return 1;
            else if (num <= 14) return 2;
            else if (num <= 36) return 3;
            else if (num <= 88) return 4;
            else return 5;
        }
    }
    private equipData computeType()
    {
        int type = Random.Range(0, 101);
        int n = computeChance();
        if (n == 1)
            return (type <= 55) ? cardList[0] : cardList[5];
        else if (n == 2)
            return (type <= 55) ? cardList[2] : cardList[7];
        else if (n == 3)
            return (type <= 55) ? cardList[4] : cardList[9];
        else if (n == 4)
            return (type <= 55) ? cardList[6] : cardList[1];
        else
            return (type <= 55) ? cardList[8] : cardList[3];
    }
    public void StartDraw()
    {
        if (isSpin)
            return;
        isSpin = true;
        StartCoroutine(wait());
        if (playerEquip.instance.money < 200)
        {
            uiSthConrtol.instance.setTip("没有足够的节奏核心");
            return;
        }
        playerEquip.instance.money -= 200;
        uiSthConrtol.instance.updateCoin();
        selectedItem = computeType(); 
        int index = cardList.IndexOf(selectedItem); 
        float sectorAngle = 36;
        float minAngle = index * sectorAngle;
        float maxAngle = minAngle + sectorAngle;
        float targetAngle = Random.Range(minAngle+1, maxAngle);
        float finalAngle = 360f * 5 + targetAngle; 
        StartCoroutine(SpinWheel(finalAngle));
    }
    private IEnumerator SpinWheel(float angle)
    {
        float elapsed = 0f;
        float startAngle = turnTable.eulerAngles.z;
        float endAngle = angle;
        while (elapsed < spinDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / spinDuration;
            float z = Mathf.Lerp(startAngle, endAngle, spinCurve.Evaluate(t));
            turnTable.eulerAngles = new Vector3(0, 0, z);
            yield return null;
        }
        turnTable.eulerAngles = new Vector3(0, 0, endAngle);
        givePrize(selectedItem);
    }
    private void givePrize(equipData item)
    {
        if (item.type == equipType.weapon)
        {
            weapon go = new weapon();
            go.basicData = item as weaponData;
            go.power = Mathf.RoundToInt(item.basicPower);
            go.durability = 100;
            go.level = 1;
            go.upGradeCost = 2000;
            uiSthConrtol.instance.bag.weaponList.Add(go);
        }
        else
        {
            shield go = new shield();
            go.basicData = item as shieldData;
            go.durability = 100;
            uiSthConrtol.instance.bag.shieldList.Add(go);
        }
        acquireCg.gameObject.SetActive(true);
        aquireSprite.sprite = item.itemSprite;
        Sequence se = DOTween.Sequence();
        acquireCg.DOFade(1, 1);
        se.Append(acquireRt.DOScale(new Vector3(1, 1, 1), 1));
        se.Append(acquireCg.DOFade(0, 2));
        se.Append(acquireRt.DOScale(new Vector3(0, 0, 0), 0.1f));
        se.AppendCallback(() => acquireRt.gameObject.SetActive(false));
    }
    private IEnumerator wait()
    {
        yield return new WaitForSeconds(6);
        isSpin = false;
    }
}
