using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class weaponInformation : equipInformationUI
{
    public weapon item;
    [SerializeField] private Text powerText;
    [SerializeField] private Text levelText;
    [SerializeField] private Text gradeCost;
    public void setImage(Sprite s, weapon go, Vector2 ve)
    {
        gameObject.SetActive(true);
        itemImage.sprite = s;
        item = go;
        GetComponent<RectTransform>().position = ve;
        nameText.text = go.basicData.itemName;
        durabilityText.text = "耐久度:" + go.durability.ToString();
        if (go.basicData.quality == 1)
            qualityText.text = "品质: 普通";
        else if (go.basicData.quality == 2)
            qualityText.text = "品质: 优秀";
        else if (go.basicData.quality == 3)
            qualityText.text = "品质: 稀有";
        else if (go.basicData.quality == 4)
            qualityText.text = "品质: 史诗";
        else
            qualityText.text = "品质: 传奇";
        powerText.text = "攻击力: " + go.power.ToString();
        levelText.text = "等级: " + go.level;
    }
    public override void equip()
    {
        uiSthConrtol.instance.bag.weaponList.Remove(item);
        if (playerEquip.instance.weapnEquip != null && playerEquip.instance.weapnEquip.basicData != null)
            uiSthConrtol.instance.bag.weaponList.Add(playerEquip.instance.weapnEquip);
        playerEquip.instance.weapnEquip = item;
        uiSthConrtol.instance.bagui.uodatePlots(0);
        uiSthConrtol.instance.weaponPlot.updateImage(item);
        uiSthConrtol.instance.powerText.text = (10 + item.power).ToString();
        gameObject.SetActive(false);
    }
    public override void throwItem()
    {
        uiSthConrtol.instance.bag.weaponList.Remove(item);
        uiSthConrtol.instance.bagui.uodatePlots(0);
        gameObject.SetActive(false);
    }
    public override void fix()
    {
        if (item.durability == 100)
        {
            uiSthConrtol.instance.setTip("耐久度已满不需要修复");
            return;
        }
        if (100 - item.durability > playerEquip.instance.money)
        {
            uiSthConrtol.instance.setTip("没有足够的节奏核心");
            return;
        }
        durabilityText.text = "耐久度: 100";
        playerEquip.instance.money -= (100 - item.durability);
        item.durability = 100;
        uiSthConrtol.instance.updateCoin();
    }
    public void UpGrade()
    {
        if(item.level==5)
        {
            uiSthConrtol.instance.setTip("该武器已经满级");
            return;
        }
        if(playerEquip.instance.money<item.upGradeCost)
        {
            uiSthConrtol.instance.setTip("没有足够的节奏核心");
            return;
        }
        item.upGrade();
        powerText.text = "攻击力: " + item.power.ToString();
        levelText.text = "等级: " + item.level;
        playerEquip.instance.money -= item.upGradeCost;
        uiSthConrtol.instance.updateCoin();
    }
    public void setGradeText()
    {
        gradeCost.text = "花费" + item.upGradeCost.ToString() + "节奏核心升级";
    }
}
