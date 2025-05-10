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
        powerText.text = "护盾值: " + go.basicData.basicPower.ToString();
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
            uiSthConrtol.instance.setTip("耐久度已满不需要修复");
            return;
        }
        if (100 - item.durability > playerEquip.instance.money)
        {
            uiSthConrtol.instance.setTip("没有足够的节奏核心");
            return;
        }
        item.durability = 100;
        durabilityText.text = "耐久度: 100";
        playerEquip.instance.money -= 100 - item.durability;
        uiSthConrtol.instance.updateCoin();
    }
}
