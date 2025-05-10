using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class shieldInformation : equipInformationUI
{
    [SerializeField] private Text powerText;
    public shield item;
    public void setImage(Sprite s,shield go,Vector2 ve)
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
        powerText.text = "����ֵ: " + go.basicData.basicPower.ToString();
    }
    public override void equip()
    {
        uiSthConrtol.instance.bag.shieldList.Remove(item);
        if (playerEquip.instance.shieldEquip != null&&playerEquip.instance.shieldEquip.basicData!=null)
            uiSthConrtol.instance.bag.shieldList.Add(playerEquip.instance.shieldEquip);
        playerEquip.instance.shieldEquip = item;
        uiSthConrtol.instance.bagui.uodatePlots(1);
        uiSthConrtol.instance.shieldPlot.updateImage(item);
        gameObject.SetActive(false);
    }
    public override void throwItem()
    {
        uiSthConrtol.instance.bag.shieldList.Remove(item);
        uiSthConrtol.instance.bagui.uodatePlots(1);
        gameObject.SetActive(false);
    }
    public override void fix()
    {
        if(item.durability == 100)
        {
            uiSthConrtol.instance.setTip("�;ö���������Ҫ�޸�");
            return;
        }
        if (100 - item.durability > playerEquip.instance.money)
        {
            uiSthConrtol.instance.setTip("û���㹻�Ľ������");
            return;
        }
        item.durability = 100;
        durabilityText.text = "�;ö�: 100";
        playerEquip.instance.money -= 100 - item.durability;
        uiSthConrtol.instance.updateCoin();
    }
}
