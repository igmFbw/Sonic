using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class weaponEquipPlot : equipPlot
{
    private weapon equipItem;
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (!bag.gameObject.activeSelf)
        {
            bag.gameObject.SetActive(true);
            bag.openBag(0);
        }
        else
        {
            if (equipItem == null || equipItem.basicData == null)
                return;
            playerEquip.instance.weapnEquip = null;
            itemSprite.sprite = whiteSprite;
            uiSthConrtol.instance.powerText.text = "10";
            uiSthConrtol.instance.bag.weaponList.Add(equipItem);
            bag.uodatePlots(0);
            equipItem = null;
        }
    }
    public void updateImage(weapon item)
    {
        equipItem = item;
        itemSprite.sprite = equipItem.basicData.itemSprite;
    }
}
