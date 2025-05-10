using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class drawCard : MonoBehaviour
{
    [SerializeField] private Transform turnTable;     
    [SerializeField] private List<equipData> cardList; 
    [SerializeField] private float spinDuration = 4f; 
    [SerializeField] private AnimationCurve spinCurve = AnimationCurve.EaseInOut(0, 0, 1, 1); // 减速曲线

    private equipData selectedItem; // 临时存储中奖项
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

    }
}
