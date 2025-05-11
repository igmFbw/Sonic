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
        durabilityText.text = "�;ö�:" + go.durability.ToString();
        if (go.basicData.quality == 1)
            qualityText.text = "Ʒ��: ��ͨ";
        else if (go.basicData.quality == 2)
            qualityText.text = "Ʒ��: ����";
        else if (go.basicData.quality == 3)
            qualityText.text = "Ʒ��: ϡ��";
        else if (go.basicData.quality == 4)
            qualityText.text = "Ʒ��: ʷʫ";
        else
            qualityText.text = "Ʒ��: ����";
        powerText.text = "������: " + go.power.ToString();
        levelText.text = "�ȼ�: " + go.level;
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
            uiSthConrtol.instance.setTip("�;ö���������Ҫ�޸�");
            return;
        }
        if (100 - item.durability > playerEquip.instance.money)
        {
            uiSthConrtol.instance.setTip("û���㹻�Ľ������");
            return;
        }
        durabilityText.text = "�;ö�: 100";
        playerEquip.instance.money -= (100 - item.durability);
        item.durability = 100;
        uiSthConrtol.instance.updateCoin();
    }
    public void UpGrade()
    {
        if(item.level==5)
        {
            uiSthConrtol.instance.setTip("�������Ѿ�����");
            return;
        }
        if(playerEquip.instance.money<item.upGradeCost)
        {
            uiSthConrtol.instance.setTip("û���㹻�Ľ������");
            return;
        }
        item.upGrade();
        powerText.text = "������: " + item.power.ToString();
        levelText.text = "�ȼ�: " + item.level;
        playerEquip.instance.money -= item.upGradeCost;
        uiSthConrtol.instance.updateCoin();
    }
    public void setGradeText()
    {
        gradeCost.text = "����" + item.upGradeCost.ToString() + "�����������";
    }
}
