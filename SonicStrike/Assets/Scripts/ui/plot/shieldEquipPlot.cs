using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class shieldEquipPlot : equipPlot
{
    private shield equipItem;
    public override void OnPointerClick(PointerEventData eventData)
    {

        if(!bag.gameObject.activeSelf)
        {
            bag.gameObject.SetActive(true);
            bag.openBag(1);
        }
        else
        {
            if (equipItem == null || equipItem.basicData == null)
                return;
            playerEquip.instance.shieldEquip = null;
            itemSprite.sprite = whiteSprite;
            uiSthConrtol.instance.bag.shieldList.Add(equipItem);
            bag.uodatePlots(1);
            equipItem = null;
        }
    }
    public void updateImage(shield item)
    {
        equipItem = item;
        itemSprite.sprite = equipItem.basicData.itemSprite;
    }
}
